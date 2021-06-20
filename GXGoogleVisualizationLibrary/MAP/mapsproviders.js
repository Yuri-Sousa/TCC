function GoogleProvider(mapControl) {
	var markers = [];
	var polygons = [];
	var lines = [];
	var Circles = [];
	var lastMarker = 0;
	var map;
	var mapContainer;
	var version = "9.0.4";
	var TRavelModeString;

	/************************ GOOGLE PROVIDER CODE **********************************/
	/********************************************************************************/

	var isEO = gx.lang.emptyObject;
	var gxBoolean = gx.lang.gxBoolean;

	this.GoogleShow = function (isPostback) {
		//Map Options Config
		
		var varstyle = GoogleGetStyle(mapControl.Style);
		var mapType = mapControl.GoogleMap.MapType || mapControl.Type;
		mapType = GoogleMapGetType(mapType);

		var myOptions = {
			center: GetGoogleMapCenter(mapControl),
			mapTypeId: mapType,
			zoom: parseInt(mapControl.GoogleMap.MapZoom || mapControl.Precision, 10),
			mapTypeControl: mapControl.Type_Control != "GType_False",
			mapTypeControlOptions: {
				style: GoogleMapGetTypeStyle(mapControl.MapType_Control_Style)
			},
			scaleControl: mapControl.Scale_Control != "GScale_False",
			navigationControl: true,
			navigationControlOptions: {
				style: GoogleMapGetNavigationStyle(mapControl.Navigation_Control_Style)
			},
			scrollwheel: gxBoolean(mapControl.ScrollWheel)
		};

		if (!mapControl.Ready) {
			var container = document.getElementById(mapControl.ContainerName);
			container.style.width = gx.dom.addUnits(mapControl.Width);
			container.style.height = gx.dom.addUnits(mapControl.Height);
			mapContainer = document.createElement("div");
			mapContainer.setAttribute("id", mapControl.ContainerName + "_MAP");
			mapContainer.style.width = gx.dom.addUnits(mapControl.Width);
			mapContainer.style.height = gx.dom.addUnits(mapControl.Height);
			container.appendChild(mapContainer);
			mapControl.Ready = true;


			map = new google.maps.Map(mapContainer, myOptions);
		} else {
			map.setOptions(myOptions);
			clearAllMarkers();
		}

		var gMapPoints = mapControl.GoogleMap.Points;
		if (mapControl.GoogleMap && gMapPoints) {
			// Points
			var point;

			for (var i = 0; gMapPoints[i] != undefined; i++) {
				var infowin = null;
				var myLatlng = new google.maps.LatLng(gMapPoints[i].PointLat, gMapPoints[i].PointLong);
				pointTitle = gMapPoints[i].PointInfowinTit;

				var buildAnchor = function (text, linkUrl, target) {
					target = target || "";
					return "<a href='" + linkUrl + "' target='" + target + "'>" + text + "</a>";
				};

				var aTarget = (mapControl.OpenLinksInNewWindow == "OpenNew_True") ? '_blank' : '';
				var aLink = gMapPoints[i].PointInfowinLink;

				if (!isEO(pointTitle)) {
					if (!gMapPoints[i].PointInfowinLink || gMapPoints[i].PointInfowinLinkDsc)
						infowin = "<B>" + pointTitle + "</B><Br>";
					else
						infowin = buildAnchor(pointTitle, aLink, aTarget);
				}
				if (!isEO(gMapPoints[i].PointInfowinDesc))
					infowin += gMapPoints[i].PointInfowinDesc + "<Br>";

				if (!isEO(gMapPoints[i].PointInfowinLink) && gMapPoints[i].PointInfowinLinkDsc)
					infowin += buildAnchor(gMapPoints[i].PointInfowinLinkDsc, aLink, aTarget) + "<Br><Br>";

				var varUrl = gMapPoints[i].PointInfowinImg;
				if (!isEO(varUrl))
					infowin += "<img src=" + '"' + varUrl + '"' + "/>" + "<Br>";

				var htmlInfowin = gMapPoints[i].PointInfowinHtml;
				if (!isEO(htmlInfowin))
					infowin = htmlInfowin;

				//Marker
				if (infowin == null)
					infowin = createInfoWin(myLatlng);

				var marker = new google.maps.Marker({
					position: myLatlng,
					map: map,
					title: pointTitle,
					icon: GoogleGetIcon(gMapPoints[i].PointIcon || mapControl.Icon),
					draggable: gxBoolean(gMapPoints[i].PointDraggable),
					flat: gxBoolean(gMapPoints[i].PointFlat),
					clickable: !isEO(gMapPoints[i].PointClickable) ? gxBoolean(gMapPoints[i].PointClickable) : true,
					visible: !isEO(gMapPoints[i].PointVisible) ? gxBoolean(gMapPoints[i].PointVisible) : true,
					htmlinfo: infowin
				});
				marker.idx = i;
				//Save Marker object
				markers[i] = marker;

				////////////////Config Marker Listeners
				//Associate Marker to infowin
				google.maps.event.addListener(marker, 'click', function () {
					if (this.htmlinfo != undefined) {
						var infowindow = new google.maps.InfoWindow();
						infowindow.setContent(this.htmlinfo);
						infowindow.setPosition(this.position);
						infowindow.open(marker.map);
					}
					if (mapControl.MarkerClick) {
						ControlSetLocation(this.position);
						mapControl.MarkerClick();
					}
				});
				SetMarkerDragEndListeners(marker);

				if (gMapPoints[i].Deletable) {
					SetMarkerDobleClickListener(marker);
				}

			}

			//Set center in the last marker
			//map.setCenter(myLatlng);
		}

		// Lines
		var gMapLines = mapControl.GoogleMap.Lines;
		if (gMapLines) {
			for (var i = 0; gMapLines[i] != undefined; i++) {
				var polygonLinePath = [];
				for (var j = 0; gMapLines[i].Points[j] != undefined; j++) {
					polygonLinePath[j] = new google.maps.LatLng(gMapLines[i].Points[j].PointLat, gMapLines[i].Points[j].PointLong);
				}

				var polyline = new google.maps.Polyline({
					path: polygonLinePath, 
					strokeColor: (gMapLines[i].LineStrokeColor == "") ? "#FF0000" : gMapLines[i].LineStrokeColor, 
					strokeWeight: (gMapLines[i].LineStrokeWeight == 0) ? 2 : gMapLines[i].LineStrokeWeight, 
					strokeOpacity: (gMapLines[i].LineStrokeOpacity == 0) ? 1.0 : gMapLines[i].LineStrokeOpacity, 
					map: map 
				});
				polyline.setMap(map);
				lines.push(polyline);
			}
		}


		//Circle
		var gMapCircles = mapControl.GoogleMap.Circles;
		if (gMapCircles) {
			var CirclesPath = [];
			for (var i = 0; gMapCircles[i] != undefined; i++) {
				var Circle1 = gMapCircles[i]

				var CircleFill1, CircleStroke1, CircleFillOpa1, CircleStrokeOpa1, CirclestrokeWeight1;

				if (Circle1.CircleFill == "" || Circle1.CircleFill == undefined)
					CircleFill1 = '#FF0000';
				else
					CircleFill1 = Circle1.CircleFill;

				if (Circle1.CircleStroke == "" || Circle1.CircleStroke == undefined)
					CircleStroke1 = '#FF0000';
				else
					CircleStroke1 = Circle1.CircleStroke;

				if (Circle1.CircleFillOpacity == 0 || Circle1.CircleFillOpacity == undefined)
					CircleFillOpa1 = 0.35;
				else
					CircleFillOpa1 = Circle1.CircleFillOpacity;


				if (Circle1.CircleStrokeOpacity == 0 || Circle1.CircleStrokeOpacity == undefined)
					CircleStrokeOpa1 = 0.8;
				else
					CircleStrokeOpa1 = Circle1.CircleStrokeOpacity;

				if (Circle1.CirclestrokeWeight == 0 || Circle1.CirclestrokeWeight == undefined)
					CirclestrokeWeight1 = 2;
				else
					CirclestrokeWeight1 = Circle1.CirclestrokeWeight;


				var Circle = new google.maps.Circle({
					strokeColor: CircleStroke1,
					strokeOpacity: CircleStrokeOpa1,
					strokeWeight: CirclestrokeWeight1,
					fillColor: CircleFill1,
					fillOpacity: CircleFillOpa1,
					map: map,
					center: {
						lat: Number(Circle1.Latitude),
						lng: Number(Circle1.Longitude)
					},
					radius: Circle1.Radius
				});
				Circle.setMap(map);
				Circles.push(Circle);
			}
		}

		//Polygons
		var gMapPolygons = mapControl.GoogleMap.Polygons;
		if (gMapPolygons) {
			for (var i = 0; !isEO(gMapPolygons[i]) ; i++) {
				var polygonPath = [];

				//Get Paths
				for (var j = 0; gMapPolygons[i].Paths[j] != undefined; j++) {
					polygonPath[j] = new google.maps.LatLng(gMapPolygons[i].Paths[j].PathLat, gMapPolygons[i].Paths[j].PathLong);

				}

				var polygonInfowin = gMapPolygons[i].PolygonInfowinHtml;
				var polygon = new google.maps.Polygon({
					fillColor: gMapPolygons[i].PolygonFill,
					fillOpacity: gMapPolygons[i].PolygonFillOpacity,
					map: map,
					strokeColor: gMapPolygons[i].PolygonStroke,
					strokeOpacity: gMapPolygons[i].PolygonStrokeOpacity,
					strokeWeight: gMapPolygons[i].PolygonStrokeWeight,
					paths: polygonPath,
					htmlinfo: polygonInfowin
				});

				polygons.push(polygon);
				//Associate Polygon to infowin
				if (!isEO(polygonInfowin)) {

					//InfoWin
					google.maps.event.addListener(polygon, 'click', function (event) {
						var infowindow = new google.maps.InfoWindow();
						infowindow.setContent(this.htmlinfo);
						infowindow.setPosition(event.latLng);
						infowindow.open(polygon.map);

						//agregar el marker SOLO para dentro del poligono, sino no lo toma
						var markerOpts = {
							position: event.latLng,
							map: map,
							draggable: true,
							clickable: false,
							title: ""
						};
						var marker = createMarker(markerOpts);

						//Replace Marker object
						markers.push(marker);
						ControlAddMarker(marker, mapControl);
					});
				}
			}
		}

		//Routing
		var gMapRouting = mapControl.GoogleMap.Routing;
		if (gMapRouting) {
			if (gMapRouting.length > 0) {
				TRavelModeString = GetTRavelMode(TRavelModeString);
				var originPoint = new google.maps.LatLng(gMapRouting[0].Latitude, gMapRouting[0].Longitude);
				var destinationPoint = new google.maps.LatLng(gMapRouting[0].Latitude, gMapRouting[0].Longitude);
				for (var i = 1; gMapRouting[i] != undefined; i++) {
				 destinationPoint = new google.maps.LatLng(gMapRouting[i].Latitude, gMapRouting[i].Longitude);
				 calculateAndDisplayRoute(originPoint, destinationPoint, TRavelModeString);
				 originPoint = destinationPoint;
				}
			}
		}

		function GetTRavelMode(TRavelModeString){
			switch (mapControl.Travel_Mode) {
				case '1':
					return TRavelModeString = 'DRIVING';	
				case '2':
					return TRavelModeString = 'WALKING';
				case '3':
					return TRavelModeString = 'BICYCLING';			
				case '4':
					return TRavelModeString = 'TRANSIT';
			}
		}
		
		function calculateAndDisplayRoute(originPoint, destinationPoint, TRavelModeString) {
			var directionsService = new google.maps.DirectionsService;
			var directionsDisplay = new google.maps.DirectionsRenderer;	
			directionsDisplay.setMap(map);
			directionsService.route({
				origin: originPoint,
				destination: destinationPoint,
				travelMode: TRavelModeString
			}, function(response, status) {
			if (status === 'OK') {
				directionsDisplay.setDirections(response);
			} else {
				window.alert('Directions request failed due to ' + status);
			}
        });
      }
		
		
		

		//KML
		if (mapControl.KML) {
			var src = 'http://' + mapControl.KMLURL;
			var ctaLayer = new google.maps.KmlLayer(src,{
				//map:map,
				//preserveViewport:true
			});
			ctaLayer.setMap(map);
		}

		if (!isPostback)
			initializeMapHandlers();
	}
	////////////////Config Marker Listeners

	this.GoogleCleanup = function () {
		clearAllMarkers();
		$(mapContainer).remove();
	};

	function initializeMapHandlers() {

		////////////////Config Map Listeners
		google.maps.event.addListener(map, 'zoom_changed', function () {
			var zoomLevel = map.getZoom();
			if (zoomLevel == 0) {
				zoomLevel = 10;
				map.setZoom(zoomLevel);
			}
		});

		var singleClick = false;
		var clearSingleClick = function (fun) {
			singleClick = false;
		};

		google.maps.event.addListener(map, 'click', function (event) {
			singleClick = true;
			setTimeout(runIfNotDblClick.closure(this, [event]), 500);
		});
		google.maps.event.addListener(map, 'dblclick', clearSingleClick);


		var runIfNotDblClick = function (event) {
			if (singleClick) {
				switch (mapControl.Onclick) {
					case 'add_Marker':

						var position = event.latLng;
						var markerOpts = {
							position: position,
							map: map,
							draggable: true,
							clickable: false,
							title: ""
						};
						var marker = createMarker(markerOpts);

						//Save Marker object
						markers.push(marker);
						ControlAddMarker(marker, mapControl);
						//Center the map
						if (mapControl.CenterWhenClick) map.setCenter(position);

						SetMarkerDragEndListeners(marker);
						SetMarkerDobleClickListener(marker);
						ControlSetLocation(position);
						if (mapControl.Click)
							mapControl.Click();

						break;
					case 'getvalue':

						//var position = this.latLng;
						var position = event.latLng;
						clearAllPoints();    //ClearAllMarkers();

						var markerOpts = {
							position: position,
							map: map,
							draggable: true,
							clickable: false,
							title: ""
						};
						var marker = createMarker(markerOpts);

						//Replace Marker object
						markers.push(marker);
						ControlAddMarker(marker, mapControl);
						if (mapControl.CenterWhenClick) map.setCenter(position);

						SetMarkerDragEndListeners(marker);
						SetMarkerDobleClickListener(marker);
						ControlSetLocation(position);
						if (mapControl.Click)
							mapControl.Click();
						break;
					case 'set_return':

						var returnValue = event.latLng.lat() + "," + event.latLng.lng();
						gx.popup.gxReturn([returnValue]);
						break;
					default:
						break;
				}


			}
		};
	}

	function SetMarkerDragEndListeners(marker) {
		//Allows drag and set the latLng when dragend
		google.maps.event.addListener(marker, 'dragend', function (event) {
			marker.map.setCenter(event.latLng);
			ControlSetLocation(event.latLng);
			ControlAddMarker(marker, mapControl);
		});
	}

	function createInfoWin(position) {
		return "<B>Latitude: </B>" + position.lat() + "<Br>" + "<B>Longitude: </B>" + position.lng() + "<Br>";
	}

	function createMarker(markerOpts) {
		var infowindow = new google.maps.InfoWindow({
			content: createInfoWin(markerOpts.position),
			position: markerOpts.position
		});

		var marker = new google.maps.Marker(markerOpts);

		google.maps.event.addListener(marker, 'click', function () {
			infowindow.open(map, marker);
		});
		return marker;
	}

	function clearAllPoints() {
		for (var i = 0; i < markers.length; i++) {
			markers[i].setMap(null);
		}
		markers = [];
		mapControl.GoogleMap.Points = [];
	}

	this.MoveMarker = function(id, lat, lng){
		var marker = this.markers[id];
		if (marker){
			var latlng = new google.maps.LatLng(lat, lng);
			marker.setPosition(latlng);
		}
	};
	function clearAllMarkers() {
		for (var i = 0; i < markers.length; i++) {
			markers[i].setMap(null);
		}
		markers = [];
		for (var i = 0; i < polygons.length; i++) {
			polygons[i].setMap(null);
		}
		polygons = [];
		for (var i = 0; i < lines.length; i++) {
			lines[i].setMap(null);
		}
		lines = [];
		for (var i = 0; i < Circles.length; i++) {
			Circles[i].setMap(null);
		}
		Circles = [];
	}

	function SetMarkerDobleClickListener(marker) {
		//Delete when dobleclick
		google.maps.event.addListener(marker, 'dblclick', function (event) {
			marker.setMap(null);
			mapControl.GoogleMap.Points.splice(marker.idx, 1);
		});
	}

	function ControlSetLocation(location) {
		mapControl.SetClickLatitude(location.lat().toString());
		mapControl.SetClickLongitude(location.lng().toString());

		var el = document.getElementById(mapControl.InformationControl.toUpperCase());
		if (el)
			el.innerHTML = location;
	}

	function GetGoogleMapCenter(GoogleMapControl) {
		var myLatLng;
		Coord = GoogleMapControl.City;
		if (Coord === "Specific Coordinate") {
			Coord = "0,0";
		} 
		if (!isEO(Coord) && Coord != "0,0")
		{
			Coord = Coord.split(',');
			myLatLng = new google.maps.LatLng(Coord[0], Coord[1]);
		}
		else {
			var latitude = GoogleMapControl.Latitude || GoogleMapControl.GoogleMap.MapLatitude;
			var longitude = GoogleMapControl.Longitude || GoogleMapControl.GoogleMap.MapLongitude;
			if (!isEO(latitude) && !isEO(longitude))
				myLatLng = new google.maps.LatLng(latitude, longitude);
		}
		return myLatLng;
	}

	this.GetGoogleMapData = function (GoogleMapControl) {
		if (GoogleMapControl.Provider == 'GOOGLE') {
			GoogleMapControl.GoogleMap.MapZoom = map.getZoom();
			GoogleMapControl.GoogleMap.MapLatitude = map.center.lat();
			GoogleMapControl.GoogleMap.MapLongitude = map.center.lng();
			GoogleMapControl.GoogleMap.MapType = ControlMapGetType(map.mapTypeId);
		}
		return GoogleMapControl.GoogleMap;
	}


	function ControlAddMarker(marker, mapControl) {
		if (!mapControl.GoogleMap.Points)
			mapControl.GoogleMap.Points = [];
		var idx = (marker.idx != undefined) ? marker.idx : mapControl.GoogleMap.Points.length;
		mapControl.GoogleMap.Points[idx] = {
			PointLat: marker.position.lat().toString(),
			PointLong: marker.position.lng().toString(),
			PointDraggable: marker.draggable,
			PointInfowinTit: marker.title,
			PointInfowinHTML: marker.htmlinfo,
			PointInfowinDesc: "",
			PointInfowinLink: "",
			PointInfowinImg: ""
		};
		marker.idx = idx;
	}

	function GoogleMapGetType(ControlType) {
		// Map Type
		switch (ControlType) {
			case gxMap.TYPE_NORMAL:
				type = google.maps.MapTypeId.ROADMAP;
				break;
			case gxMap.TYPE_SATELLITE:
				type = google.maps.MapTypeId.SATELLITE;
				break;
			case gxMap.TYPE_HYBRID:
				type = google.maps.MapTypeId.HYBRID;
				break;
			case gxMap.TYPE_TERRAIN:
				type = google.maps.MapTypeId.TERRAIN;
				break;
			default:
				type = google.maps.MapTypeId.ROADMAP;
		}
		return type;
	}

	function ControlMapGetType(GoogleType) {
		// Map Type
		switch (GoogleType) {
			case google.maps.MapTypeId.ROADMAP:
				type = gxMap.TYPE_NORMAL;
				break;
			case google.maps.MapTypeId.SATELLITE:
				type = gxMap.TYPE_SATELLITE;
				break;
			case google.maps.MapTypeId.HYBRID:
				type = gxMap.TYPE_HYBRID;
				break;
			case google.maps.MapTypeId.TERRAIN:
				type = gxMap.TYPE_TERRAIN;
				break;
		}
		return type;
	}

	function GoogleMapGetNavigationStyle(style) {
		// Navigation Style
		switch (style) {
			case "DEFAULT":
				googleStyle = google.maps.NavigationControlStyle.DEFAULT;
				break;
			case "ANDROID":
				googleStyle = google.maps.NavigationControlStyle.ANDROID;
				break;
			case "SMALL":
				googleStyle = google.maps.NavigationControlStyle.SMALL;
				break;
			case "ZOOM_PAN":
				googleStyle = google.maps.NavigationControlStyle.ZOOM_PAN;
				break;
		}
		return googleStyle;
	}

	function GoogleMapGetTypeStyle(style) {
		// Navigation Style
		switch (style) {
			case "DEFAULT":
				googleStyle = google.maps.MapTypeControlStyle.DEFAULT;
				break;
			case "DROPDOWN_MENU":
				googleStyle = google.maps.MapTypeControlStyle.DROPDOWN_MENU;
				break;
			case "HORIZONTAL_BAR":
				googleStyle = google.maps.MapTypeControlStyle.HORIZONTAL_BAR;
				break;
		}
		return googleStyle;
	}

	function GoogleGetIcon(pointicon) {
		// Create our "tiny" marker icon
		switch (pointicon) {
			case "Default":
			case "":
				iconImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "GXGoogleVisualizationLibrary/MAP/Images/default.png", true);
				break;
			case "Blue":
			case "blue":
				iconImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "GXGoogleVisualizationLibrary/MAP/Images/blue.png", true);
				break;
			case "Green":
			case "green":
				iconImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "GXGoogleVisualizationLibrary/MAP/Images/green.png", true);
				break;
			case "Orange":
			case "orange":
				iconImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "GXGoogleVisualizationLibrary/MAP/Images/orange.png", true);
				break;
			case "Red":
			case "red":
				iconImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "GXGoogleVisualizationLibrary/MAP/Images/red.png", true);
				break;
			case "Pink":
			case "pink":
				iconImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "GXGoogleVisualizationLibrary/MAP/Images/pink.png", true);
				break;
			default:
				iconImage = pointicon;
				break;
		}

		//Si se quiere agregar mas argumentos MarkerImage(url:string, size?:Size, origin?:Point, anchor?:Point, scaledSize?:Size)
		markerImage = new google.maps.MarkerImage(iconImage,
			// This marker is 20 pixels wide by 32 pixels tall.
			//new google.maps.Size(20, 32),
			new google.maps.Size(mapControl.IconWidth, mapControl.IconHeigth),
			// The origin for this image is 0,0.
			new google.maps.Point(0, 0),
			// The anchor for this image is the base of the flagpole at 0,32.
			new google.maps.Point(mapControl.AnchorLeft, mapControl.AnchorTop));
		return markerImage;
	}
	 function GoogleGetStyle(style1) {
		 
		 switch (style1) {
			case "GStyle_Standard":
				varstyle = GoogleGetSTANDARDStyle();
				break;
			case "GStyle_Silver":
				varstyle = GoogleGetSILVERStyle();
				break;
			case "GStyle_Retro":
				varstyle = GoogleGetRETROStyle()
				break;
			case "GStyle_Dark":
				varstyle = GoogleGetDARKStyle();
				break;
			case "GStyle_Nigth":
				varstyle = GoogleGetNIGTHStyle();
				break;
			case "GStyle_Aubergine":
				varstyle = GoogleGetAUBERGINEStyle()
				break;
		    default:
				varstyle = GoogleGetSTANDARDStyle();
				break;
		 }	
		 var resultado = JSON.parse(varstyle);
		 return resultado;
	 }
	function GoogleGetSTANDARDStyle()
	 {
		varstyle = '[]';
        return varstyle;     
	 }
	function GoogleGetRETROStyle()
	 {
		varstyle = '[  {    "elementType": "geometry",    "stylers": [      {        "color": "#ebe3cd"      }    ]  },  {    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#523735"      }    ]  },  {    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#f5f1e6"      }    ]  },  {    "featureType": "administrative",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#c9b2a6"      }    ]  },  {    "featureType": "administrative.land_parcel",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#dcd2be"      }    ]  },  {    "featureType": "administrative.land_parcel",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#ae9e90"      }    ]  },  {    "featureType": "landscape.natural",    "elementType": "geometry",    "stylers": [      {        "color": "#dfd2ae"      }    ]  },  {    "featureType": "poi",    "elementType": "geometry",    "stylers": [      {        "color": "#dfd2ae"      }    ]  },  {    "featureType": "poi",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#93817c"      }    ]  },  {    "featureType": "poi.park",    "elementType": "geometry.fill",    "stylers": [      {        "color": "#a5b076"      }    ]  },  {    "featureType": "poi.park",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#447530"      }    ]  },  {    "featureType": "road",    "elementType": "geometry",    "stylers": [      {        "color": "#f5f1e6"      }    ]  },  {    "featureType": "road.arterial",    "elementType": "geometry",    "stylers": [      {        "color": "#fdfcf8"      }    ]  },  {    "featureType": "road.highway",    "elementType": "geometry",    "stylers": [      {        "color": "#f8c967"      }    ]  },  {    "featureType": "road.highway",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#e9bc62"      }    ]  },  {    "featureType": "road.highway.controlled_access",    "elementType": "geometry",    "stylers": [      {        "color": "#e98d58"      }    ]  },  {    "featureType": "road.highway.controlled_access",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#db8555"      }    ]  },  {    "featureType": "road.local",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#806b63"      }    ]  },  {    "featureType": "transit.line",    "elementType": "geometry",    "stylers": [      {        "color": "#dfd2ae"      }    ]  },  {    "featureType": "transit.line",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#8f7d77"      }    ]  },  {    "featureType": "transit.line",    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#ebe3cd"      }    ]  },  {    "featureType": "transit.station",    "elementType": "geometry",    "stylers": [      {        "color": "#dfd2ae"      }    ]  },  {    "featureType": "water",    "elementType": "geometry.fill",    "stylers": [      {        "color": "#b9d3c2"      }    ]  },  {    "featureType": "water",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#92998d"      }    ]  }]';
        return varstyle;     
	 }
	 
	function GoogleGetDARKStyle()
	 {
		varstyle = '[  {    "elementType": "geometry",    "stylers": [      {        "color": "#212121"      }    ]  },  {    "elementType": "labels.icon",    "stylers": [      {        "visibility": "off"      }    ]  },  {    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#757575"      }    ]  },  {    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#212121"      }    ]  },  {    "featureType": "administrative",    "elementType": "geometry",    "stylers": [      {        "color": "#757575"      }    ]  },  {    "featureType": "administrative.country",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#9e9e9e"      }    ]  },  {    "featureType": "administrative.land_parcel",    "stylers": [      {        "visibility": "off"      }    ]  },  {    "featureType": "administrative.locality",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#bdbdbd"      }    ]  },  {    "featureType": "poi",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#757575"      }    ]  },  {    "featureType": "poi.park",    "elementType": "geometry",    "stylers": [      {        "color": "#181818"      }    ]  },  {    "featureType": "poi.park",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#616161"      }    ]  },  {    "featureType": "poi.park",    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#1b1b1b"      }    ]  },  {    "featureType": "road",    "elementType": "geometry.fill",    "stylers": [      {        "color": "#2c2c2c"      }    ]  },  {    "featureType": "road",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#8a8a8a"      }    ]  },  {    "featureType": "road.arterial",    "elementType": "geometry",    "stylers": [      {        "color": "#373737"      }    ]  },  {    "featureType": "road.highway",    "elementType": "geometry",    "stylers": [      {        "color": "#3c3c3c"      }    ]  },  {    "featureType": "road.highway.controlled_access",    "elementType": "geometry",    "stylers": [      {        "color": "#4e4e4e"      }    ]  },  {    "featureType": "road.local",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#616161"      }    ]  },  {    "featureType": "transit",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#757575"      }    ]  },  {    "featureType": "water",    "elementType": "geometry",    "stylers": [      {        "color": "#000000"      }    ]  },  {    "featureType": "water",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#3d3d3d"      }    ]  }]';
		return varstyle;
	 }
	
	function GoogleGetNIGTHStyle()
	 {
		varstyle = '[  {    "elementType": "geometry",    "stylers": [      {        "color": "#242f3e"      }    ]  },  {    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#746855"      }    ]  },  {    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#242f3e"      }    ]  },  {    "featureType": "administrative.locality",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#d59563"      }    ]  },  {    "featureType": "poi",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#d59563"      }    ]  },  {    "featureType": "poi.park",    "elementType": "geometry",    "stylers": [      {        "color": "#263c3f"      }    ]  },  {    "featureType": "poi.park",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#6b9a76"      }    ]  },  {    "featureType": "road",    "elementType": "geometry",    "stylers": [      {        "color": "#38414e"      }    ]  },  {    "featureType": "road",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#212a37"      }    ]  },  {    "featureType": "road",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#9ca5b3"      }    ]  },  {    "featureType": "road.highway",    "elementType": "geometry",    "stylers": [      {        "color": "#746855"      }    ]  },  {    "featureType": "road.highway",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#1f2835"      }    ]  },  {    "featureType": "road.highway",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#f3d19c"      }    ]  },  {    "featureType": "transit",    "elementType": "geometry",    "stylers": [      {        "color": "#2f3948"      }    ]  },  {    "featureType": "transit.station",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#d59563"      }    ]  },  {    "featureType": "water",    "elementType": "geometry",    "stylers": [      {        "color": "#17263c"      }    ]  },  {    "featureType": "water",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#515c6d"      }    ]  },  {    "featureType": "water",    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#17263c"      }    ]  }]';
		return varstyle;
	 }
	
 	function GoogleGetAUBERGINEStyle()
	 {
		varstyle = '[  {    "elementType": "geometry",    "stylers": [      {        "color": "#1d2c4d"      }    ]  },  {    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#8ec3b9"      }    ]  },  {    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#1a3646"      }    ]  },  {    "featureType": "administrative.country",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#4b6878"      }    ]  },  {    "featureType": "administrative.land_parcel",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#64779e"      }    ]  },  {    "featureType": "administrative.province",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#4b6878"      }    ]  },  {    "featureType": "landscape.man_made",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#334e87"      }    ]  },  {    "featureType": "landscape.natural",    "elementType": "geometry",    "stylers": [      {        "color": "#023e58"      }    ]  },  {    "featureType": "poi",    "elementType": "geometry",    "stylers": [      {        "color": "#283d6a"      }    ]  },  {    "featureType": "poi",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#6f9ba5"      }    ]  },  {    "featureType": "poi",    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#1d2c4d"      }    ]  },  {    "featureType": "poi.park",    "elementType": "geometry.fill",    "stylers": [      {        "color": "#023e58"      }    ]  },  {    "featureType": "poi.park",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#3C7680"      }    ]  },  {    "featureType": "road",    "elementType": "geometry",    "stylers": [      {        "color": "#304a7d"      }    ]  },  {    "featureType": "road",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#98a5be"      }    ]  },  {    "featureType": "road",    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#1d2c4d"      }    ]  },  {    "featureType": "road.highway",    "elementType": "geometry",    "stylers": [      {        "color": "#2c6675"      }    ]  },  {    "featureType": "road.highway",    "elementType": "geometry.stroke",    "stylers": [      {        "color": "#255763"      }    ]  },  {    "featureType": "road.highway",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#b0d5ce"      }    ]  },  {    "featureType": "road.highway",    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#023e58"      }    ]  },  {    "featureType": "transit",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#98a5be"      }    ]  },  {    "featureType": "transit",    "elementType": "labels.text.stroke",    "stylers": [      {        "color": "#1d2c4d"      }    ]  },  {    "featureType": "transit.line",    "elementType": "geometry.fill",    "stylers": [      {        "color": "#283d6a"      }    ]  },  {    "featureType": "transit.station",    "elementType": "geometry",    "stylers": [      {        "color": "#3a4762"      }    ]  },  {    "featureType": "water",    "elementType": "geometry",    "stylers": [      {        "color": "#0e1626"      }    ]  },  {    "featureType": "water",    "elementType": "labels.text.fill",    "stylers": [      {        "color": "#4e6d70"      }    ]  }]';
		return varstyle;
	 }
	 	 
	function GoogleGetSILVERStyle() {
		
		varstyle = '[';
		varstyle += '		  {';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#f5f5f5"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"elementType": "labels.icon",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"visibility": "off"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#616161"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"elementType": "labels.text.stroke",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#f5f5f5"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "administrative.land_parcel",';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#bdbdbd"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "poi",';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#eeeeee"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "poi",';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#757575"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "poi.park",';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#e5e5e5"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "poi.park",';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#9e9e9e"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "road",';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#ffffff"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "road.arterial",';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#757575"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "road.highway",';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#dadada"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "road.highway",';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#616161"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "road.local",';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#9e9e9e"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "transit.line",';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#e5e5e5"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "transit.station",';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#eeeeee"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "water",';
		varstyle += '			"elementType": "geometry",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#c9c9c9"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  },';
		varstyle += '		  {';
		varstyle += '			"featureType": "water",';
		varstyle += '			"elementType": "labels.text.fill",';
		varstyle += '			"stylers": [';
		varstyle += '			  {';
		varstyle += '				"color": "#9e9e9e"';
		varstyle += '			  }';
		varstyle += '			]';
		varstyle += '		  }';
		varstyle += '		]'
        return varstyle;
		}
}
/************************ YAHOO PROVIDER CODE ***********************************/
/********************************************************************************/

function YahooCreateMarker(point, title) {
	var marker = new YMarker(point);
	YEvent.Capture(marker, EventsList.MouseClick, function () { marker.openSmartWindow(title); });
	return marker;
}


function YahooShow(GxMapControl) {
	var mapControl = GxMapControl;
	document.getElementById(mapControl.ContainerName).innerHTML = '<div id="' + mapControl.ContainerName + '_MAP" style="width: ' + mapControl.Width + 'px; height: ' + mapControl.Height + 'px;"></div>';
	var map = new YMap(document.getElementById(GxMapControl.ContainerName + '_MAP'));

	Coord = mapControl.City;
	Coord = Coord.split(',');

	if (Coord != "0,0") map.drawZoomAndCenter(new YGeoPoint(Coord[0], Coord[1]), parseInt(mapControl.Precision));
	else map.drawZoomAndCenter(new YGeoPoint(mapControl.Latitude, mapControl.Longitude), parseInt(mapControl.Precision));


	// Controls
	if (mapControl.Type_Control == gxMap.CONTROL_TYPE_VISIBLE)
		map.addTypeControl();
	if (mapControl.Small_Zoom_Control == gxMap.CONTROL_SMALL_ZOOM_VISIBLE)
		map.addZoomShort();
	if (mapControl.Scale_Control == gxMap.CONTROL_SCALE_VISIBLE)
		map.addZoomScale();
	else
		map.removeZoomScale();
	if (mapControl.Large_Control == gxMap.CONTROL_LARGE_VISIBLE) {
		map.addPanControl();
		map.addZoomLong();
	}
	if (mapControl.Small_Control == gxMap.CONTROL_SMALL_VISIBLE) {
		map.addPanControl();
		map.addZoomShort();
	}

	// Map Type
	switch (mapControl.Type) {
		case gxMap.TYPE_NORMAL:
			map.setMapType(YAHOO_MAP_REG);
			break;
		case gxMap.TYPE_SATELLITE:
			map.setMapType(YAHOO_MAP_SAT);
			break;
		case gxMap.TYPE_HYBRID:
			map.setMapType(YAHOO_MAP_HYB);
			break;
	}

	// Points
	var point;
	var infowin;
	for (var i = 0; mapControl.GoogleMap.Points[i] != undefined; i++) {
		point = new YGeoPoint(mapControl.GoogleMap.Points[i].PointLat, mapControl.GoogleMap.Points[i].PointLong);
		infowin = "<B>" + mapControl.GoogleMap.Points[i].PointInfowinTit + "</B><Br>";
		infowin += mapControl.GoogleMap.Points[i].PointInfowinDesc + "<Br>";
		infowin += "<A HREF=" + mapControl.GoogleMap.Points[i].PointInfowinLink + ">" + mapControl.GoogleMap.Points[i].PointInfowinLinkDsc + "</A>" + "<Br>";
		var varUrl = mapControl.GoogleMap.Points[i].PointInfowinImg;
		infowin += "<img src=" + '"' + varUrl + '"' + "/>" + "<Br>";
		map.addOverlay(YahooCreateMarker(point, infowin));
	}
}




/************************ BAIDU PROVIDER CODE ***********************************/
/********************************************************************************/






function BaiduShow(BaiduMapControl) {
	var mapControl = BaiduMapControl;
	if (!mapControl.Ready) {

		var container = document.getElementById(mapControl.ContainerName);
		var mapContainer = document.createElement("div");
		mapContainer.setAttribute("id", mapControl.ContainerName + "_MAP");
		mapContainer.style.width = gx.dom.addUnits(mapControl.Width);
		mapContainer.style.height = gx.dom.addUnits(mapControl.Height);
		container.appendChild(mapContainer);
		map = new BMap.Map(mapContainer);
		mapControl.Ready = true;
	}
	else {
		map.clearOverlays();
	}


	var Coord = mapControl.City;
	var point;
	Coord = Coord.split(',');
	if (Coord != "0,0") {
		point = new BMap.Point(Coord[1], Coord[0]);
	}
	else {
		point = new BMap.Point(mapControl.Longitude, mapControl.Latitude);
	}
	map.centerAndZoom(point, parseInt(mapControl.Precision));
	map.enableScrollWheelZoom();
	BaiduDrawPoints(mapControl, map);
	BaiduDrawLines(mapControl, map);
}


function BaiduDrawLines(mapControl, map) {
	if (mapControl.GoogleMap.Lines != undefined) {
		var opacity;
		var weight;
		var color;
		for (var i = 0; mapControl.GoogleMap.Lines[i] != undefined; i++) {
			var polygonPath = [];
			for (var j = 0; mapControl.GoogleMap.Lines[i].Points[j] != undefined; j++) {
				polygonPath[j] = new BMap.Point(mapControl.GoogleMap.Lines[i].Points[j].PointLong, mapControl.GoogleMap.Lines[i].Points[j].PointLat);
			}
			opacity = (mapControl.GoogleMap.Lines[i].LineStrokeOpacity == 0) ? 0.5 : mapControl.GoogleMap.Lines[i].LineStrokeOpacity;
			weight = (mapControl.GoogleMap.Lines[i].LineStrokeWeight == 0) ? 6 : mapControl.GoogleMap.Lines[i].LineStrokeWeight;
			color = (mapControl.GoogleMap.Lines[i].LineStrokeColor == "") ? "blue" : mapControl.GoogleMap.Lines[i].LineStrokeColor;

			var polyline = new BMap.Polyline(polygonPath, { strokeColor: color, strokeWeight: weight, strokeOpacity: opacity });
			map.addOverlay(polyline);
		}
	}
}


function BaiduDrawPoints(mapControl, map) {
	if (mapControl.GoogleMap.Points != undefined) {
		for (var i = 0; mapControl.GoogleMap.Points[i] != undefined; i++) {
			if (mapControl.GoogleMap.Points[i].PointIcon != "" && mapControl.GoogleMap.Points[i].PointIcon != undefined)
			{
				var myIcon = new BMap.Icon(mapControl.GoogleMap.Points[i].PointIcon, new BMap.Size(300,157));
				var marker = new BMap.Marker(new BMap.Point(mapControl.GoogleMap.Points[i].PointLong, mapControl.GoogleMap.Points[i].PointLat), {icon:myIcon});
			}
			else
			var marker = new BMap.Marker(new BMap.Point(mapControl.GoogleMap.Points[i].PointLong, mapControl.GoogleMap.Points[i].PointLat));
			marker.addEventListener("click", function (obj) {
				for (var i = 0; mapControl.GoogleMap.Points[i] != undefined; i++) {
					if ((mapControl.GoogleMap.Points[i].PointLong == obj.currentTarget.point.lng) && (mapControl.GoogleMap.Points[i].PointLat == obj.currentTarget.point.lat)) {
						var infowin = "<B>" + mapControl.GoogleMap.Points[i].PointInfowinTit + "</B><Br>";
						infowin += mapControl.GoogleMap.Points[i].PointInfowinDesc + "<Br>";
						infowin += "<A HREF=" + mapControl.GoogleMap.Points[i].PointInfowinLink + ">" + mapControl.GoogleMap.Points[i].PointInfowinLinkDsc + "</A>" + "<Br>";
						var varUrl = mapControl.GoogleMap.Points[i].PointInfowinImg;
						infowin += "<img src=" + '"' + varUrl + '"' + "/>" + "<Br>";
					}
				}

				var infoWindow1 = new BMap.InfoWindow(infowin);
				this.openInfoWindow(infoWindow1);
			}
			);
			map.addOverlay(marker);
		}
	}
}
