function gxMap($) {
	var loadOnShow;

	this.Ready = false;

	this.SetClickLatitude = function (data) {
		this.ClickLatitude = data;
	}
	this.GetClickLatitude = function () {
		return this.ClickLatitude;
	}
	this.SetClickLongitude = function (data) {
		this.ClickLongitude = data;
	}
	this.GetClickLongitude = function () {
		return this.ClickLongitude;
	}

	this.SetData = function (data) {
		this.GoogleMap = data;
		if (!gxMap.ScriptLoaded) {
			var remoteScripts = [];
			gxMap.maps.push(this);
			switch (this.Provider) {
				case 'GOOGLE':
					remoteScripts.push("https://maps.google.com/maps/api/js?key=" + this.GoogleApiKey + "&callback=gxMap.doShowExternal");
					break;
				case 'YAHOO':
					remoteScripts.push('http://us.js2.yimg.com/us.js.yimg.com/lib/common/utils/2/dom_2.0.1-b2.js');
					remoteScripts.push('http://us.js2.yimg.com/us.js.yimg.com/lib/common/utils/2/event_2.0.0-b2.js');
					remoteScripts.push('http://us.js2.yimg.com/us.js.yimg.com/lib/common/utils/2/dragdrop_2.0.1-b4.js');
					remoteScripts.push('http://us.js2.yimg.com/us.js.yimg.com/lib/common/utils/2/animation_2.0.1-b2.js');
					remoteScripts.push('http://us.js2.yimg.com/us.js.yimg.com/lib/map/js/api/ymapapi_3_7_1_10.js');

					gxMap.YAHOO = gxMap.YAHOO || {};
					gxMap.YAHOO.namespace = function (_1) {
						if (!_1 || !_1.length) {
							return null;
						}
						var _2 = _1.split(".");
						var _3 = gxMap.YAHOO;
						for (var i = (_2[0] == "YAHOO") ? 1 : 0; i < _2.length; ++i) {
							_3[_2[i]] = _3[_2[i]] || {};
							_3 = _3[_2[i]];
						}
						return _3;
					};

					gxMap.YAHOO.namespace("util");
					gxMap.YAHOO.namespace("widget");
					gxMap.YAHOO.namespace("example");
					gxMap.YMAPPID = "YpuWfrTV34H0XCOGprbPUfpm5ofYqbUGFUxAd_IozWcbb_xiiWiO0821Kp0oknuY6Q--";

					break;
				case 'BAIDU':
					remoteScripts.push("//api.map.baidu.com/api?key=" + this.BaiduKey + "&v=1.4&services=true&callback=gxMap.doShowExternal");
					break;
			}
			gx.http.loadScripts(remoteScripts, function () {
				gxMap.ScriptLoaded = true;
				return true;
			});
		}
		else {
			loadOnShow = true;
		}
	}

	this.GetData = function () {
		switch (this.Provider) {
				case 'GOOGLE':
					return this.googleProvider.GetGoogleMapData(this);
					break;
				case 'BAIDU':
					return this.GoogleMap;
					break;
				//case 'YAHOO':
				//	YahooShow(map);
				//	break;
	} }

	this.show = function () {
		if (!this.IsPostBack) {
			if (loadOnShow) {
				switch (this.Provider) {
				case 'GOOGLE':
					this.doShow();
					break;
				case 'BAIDU':
					BaiduShow(this);
					break;
				//case 'YAHOO':
				//	YahooShow(map);
				//// YahooShowExternal(map);
				//	break;
			}}
		} else {
			switch (this.Provider) {
				case 'GOOGLE':
					this.googleProvider.GoogleShow(true);
					break;
				case 'BAIDU':
					BaiduShow(this);
					break;
				case 'YAHOO':
					YahooShow(this);
					break;
			}
		}
	}

	this.destroy = function () {
		for (var len = gxMap.maps.length, i = len - 1; i >= 0; i--) {
			if (gxMap.maps[i] == this) {
				gxMap.maps.splice(i, 1);
				break;
			}
		}
		if (this.Provider == "GOOGLE") {
			this.googleProvider.GoogleCleanup();
		}
	}

	this.doShow = function () {
		switch (this.Provider) {
			case "YAHOO":
				YahooShowExternal(this);
				break;
			case 'GOOGLE':
				this.googleProvider = new GoogleProvider(this);
				this.googleProvider.GoogleShow(false);
				break;
			case 'BAIDU':
				BaiduShow(this);
				break;
		}
	}

	function YahooShowExternal(gxmapinstance) {
		window.setTimeout(function () {
			if (window.YMap) {
				YahooShow(gxmapinstance);
			} else {
				YahooShowExternal(gxmapinstance);
			}
		}, 100);

		return true;
	}
}

gxMap.maps = [];
gxMap.doShowExternal = function () {
	for (var i = 0; i < gxMap.maps.length; i++) {
		gxMap.maps[i].doShow();
	}
}

gxMap.CONTROL_SMALL_VISIBLE = 'GSmall_True';
gxMap.CONTROL_TYPE_VISIBLE = 'GType_True';
gxMap.CONTROL_OVERVIEW_VISIBLE = 'GOverviewMap_True';
gxMap.CONTROL_LARGE_VISIBLE = 'GLarge_True';
gxMap.CONTROL_SMALL_ZOOM_VISIBLE = 'GSmallZoom_True';
gxMap.CONTROL_SCALE_VISIBLE = 'GScale_True';
gxMap.TYPE_NORMAL = 'G_NORMAL_MAP';
gxMap.TYPE_SATELLITE = 'G_SATELLITE_MAP';
gxMap.TYPE_HYBRID = 'G_HYBRID_MAP';
gxMap.TYPE_TERRAIN = 'G_TERRAIN_MAP';
gxMap.Version = "8.3.9";
gxMap.YAHOO;
gxMap.YMAPPID;

