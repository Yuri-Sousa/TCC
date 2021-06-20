var DeveloperMenu = {
	initialize: function () {
		Function.prototype.closure = function (obj, args, appendArgs) {
			var fun = this;
			return function () {
				var funcArgs = args || arguments;
				if (appendArgs === true) {
					funcArgs = Array.prototype.slice.call(arguments, 0);
					funcArgs = funcArgs.concat(args);
				}
				return fun.apply(obj || window, funcArgs);
			};
		};

		DeveloperMenu.Menu.QRCodesMode = document.location.search.substring(1) == 'qrcode';

		DeveloperMenu.Menu.initialize(function () {
			DeveloperMenu.Menu.loadWebApplications(function () {
				this.loadSdApplications(function () {
					var defaultNavItem = DeveloperMenu.Dom.el("nav-webobjects"),
						iosNavItem = DeveloperMenu.Dom.el("nav-ios"),
						hashValue = document.location.hash,
						navItem,
						navTarget;

					this.attachHandlers();

					// Scroll to SD boxes only if qrcode flag is passed
					if (DeveloperMenu.Menu.QRCodesMode) {
							DeveloperMenu.Dom.el("ios").scrollIntoView();
							DeveloperMenu.Menu.setNavMenuOptionSelected(iosNavItem);
					}
					else {
						if (!hashValue) {
							DeveloperMenu.Menu.setNavMenuOptionSelected(defaultNavItem);
						}
						else {
							hashValue = document.location.hash.substring(1);
							navItem = DeveloperMenu.Dom.el("nav-" + hashValue);
							navTarget = DeveloperMenu.Dom.el(hashValue);
							if (navTarget) {
								navTarget.scrollIntoView();
							}
							DeveloperMenu.Menu.setNavMenuOptionSelected(navItem);
						}
					}

					DeveloperMenu.Dom.removeClass(document.body, "loading");
				});
			});
		});
	},

	Devices: {
		Android: "Android",
		iOS: "iOS"
	},

	Dom: {
		el: function (id) {
			if (id.tagName)
				return id;
			return document.getElementById(id);
		},

		byTag: function (name, root) {
			root = root || document;
			return root.getElementsByTagName(name);
		},

		byClass: function (name, tag, root) {
			if (document.getElementsByClassName) {
				var root = root || document;
				return root.getElementsByClassName(name);
			}
			else {
				var classElements = [];
				var els = this.byTag(tag || '*', root);
				var len = els.length;
				var pattern = new RegExp("(^|\\s)" + name + "(\\s|$)");
				for (i = 0, j = 0; i < len; i++) {
					if (pattern.test(els[i].className)) {
						classElements[j] = els[i];
						j++;
					}
				}
				return classElements;
			}
		},

		hasClass: function (id, className) {
			var el = DeveloperMenu.Dom.el(id);
			if (el) {
				return className && (' ' + el.className + ' ').indexOf(' ' + className + ' ') != -1;
			}
		},

		addClass: function (id, className) {
			var el = DeveloperMenu.Dom.el(id);
			if (el) {
				if (className && !this.hasClass(id, className)) {
					el.className = el.className + " " + className;
				}
			}
		},

		classReCache: {},
		removeClass: function (id, className) {
			var el = DeveloperMenu.Dom.el(id);
			if (el) {
				if (this.hasClass(id, className)) {
					var re = this.classReCache[className];
					if (!re) {
						re = new RegExp('(?:^|\\s+)' + className + '(?:\\s+|$)', "g");
						this.classReCache[className] = re;
					}
					el.className = el.className.replace(re, " ");
				}
			}
		},

		attachEvent: function (el, evtName, handler, scope) {
			if (scope)
				handler = handler.closure(scope);
			if (el.addEventListener)
				el.addEventListener(evtName, handler, false);
			else
				el.attachEvent('on' + evtName, handler);
		},

		getComputedStyle: function (el, style) {
			var computedStyle;
			if (typeof el.currentStyle != 'undefined') {
				computedStyle = el.currentStyle;
			}
			else {
				computedStyle = document.defaultView.getComputedStyle(el, null);
			}

			return computedStyle[style];
		},

		getEventTarget: function (e, className, levels) {
			var node = e.target || e.srcElement,
				depth = levels + 1;
			while (node && depth--) {
				if (this.hasClass(node, className))
					return node;
				node = node.parentNode;
			}
		}
	},

	Util: {
		getStaticUrl: function () {
			return DeveloperMenu.Util.staticUrl;
		},

		getCurrentUrl: function () {
			var href = document.location.href;
			return href.substring(0, href.lastIndexOf('/'));
		},

		getAppBaseUrl: function () {
			var appBaseUrl = this.getCurrentUrl();
			var staticUrl = this.getStaticUrl();
			if (staticUrl)
				appBaseUrl = appBaseUrl.replace(new RegExp(staticUrl + "$"), "");

			if (appBaseUrl.substring(appBaseUrl.length - 1) == "/")
				appBaseUrl = appBaseUrl.substr(0, appBaseUrl.length - 1)

			return appBaseUrl;
		},

		QR_CODE_GENERATOR_URL: "http://sdx.genexus.com/agetqrcode.aspx?",

		getQRCodeImage: function (url) {
			return this.QR_CODE_GENERATOR_URL + url;
		}

	},

	Browser: {
		isIE: function () {
			var ua = navigator.userAgent;
			return (ua.indexOf("MSIE") != -1 || ua.indexOf("Trident") != -1 || ua.indexOf("Edge") != -1);
		}
	},

	Menu: {
		initialize: function (callback) {
			wgxpath.install();
			if (DeveloperMenu.Browser.isIE()) {
				DeveloperMenu.Dom.addClass(document.body, 'ie');
			}

			this.loadFile({
				url: 'gxcfg.js?' + Math.random(),
				success: function (req) {
					var matches = req.responseText.match(/gx\.setStaticDirectory\([^;]+\);/g);
					if (matches && matches[0])
						eval(matches[0]);
					else
						DeveloperMenu.Util.staticUrl = "";
					matches = req.responseText.match(/gx\.navMenuDsc\s*=\s*[^;]+(?:;|$)/g);
					if (matches && matches[0])
						eval(matches[0]);
				},
				failure: function () {
					DeveloperMenu.Util.staticUrl = "";
				},
				allways: callback,
				scope: this
			});
		},

		useDescription: function () {
			if (gx.navMenuDsc !== undefined) {
				return gx.navMenuDsc;
			}
			return false;
		},

		loadFile: function (options) {
			var req = DeveloperMenu.Ajax.getRequestObj(),
				successFn,
				failureFn;
			if (req) {
				failureFn = function (req) {
					options.failure.call(this, req);
					if (options.allways) {
						options.allways.call(this, req)
					}
				};

				successFn = function (req) {
					if (req.readyState == 4) {
						if (req.status == 200) {
							options.success.call(this, req);
							if (options.allways) {
								options.allways.call(this, req)
							}
							return;
						}
						failureFn.call(this, req);
					}
				}
				if (DeveloperMenu.Browser.isIE())
					req.onreadystatechange = successFn.closure(options.scope, [req]);
				else {
					req.onload = successFn.closure(options.scope, [req]);
					req.onerror = failureFn.closure(options.scope, [req]);
				}


				req.open(options.method || 'GET', options.url);

				req.send();
			}
		},

		loadWebApplications: function (callback) {
			this.loadFile({
				url: 'DeveloperMenu.xml?' + Math.random(),
				success: this.loadWebApplicationsCallback,
				failure: this.loadWebApplicationsFailureCallback,
				allways: callback,
				scope: this
			});
		},

		loadSdApplications: function (callback) {
			this.loadFile({
				url: DeveloperMenu.Util.getAppBaseUrl() + '/gxmetadata/sdapps.json?' + Math.random(),
				success: function (req) {
						var sdApps = {};
						if (req.responseText) {
							if (window.JSON) {
								sdApps = JSON.parse(req.responseText);
							}
							else {
								eval("sdApps = " + req.responseText);
							}
							if (sdApps.apps && sdApps.apps.length > 0) {
								this.enableSD();
								this.updateKbnImage();
								this.renderAndroidMenu(sdApps);
							}
							else {
								this.disableSD();
							}
							return;
						}
				},
				failure: function (req) {
					this.disableSD();
				},
				allways: callback,
				scope: this
			});
		},

		getObjectPropertiesFromXml: function (xmlDoc, rootNode) {
			var getNodeValue = function (nodeName) {
				var doc = xmlDoc.evaluate ? xmlDoc : document,
					result = doc.evaluate(nodeName, rootNode, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null),
					value;
				if (result && result.singleNodeValue) {
					value = result.singleNodeValue.textContent;
					if (value === undefined) {
						value = result.singleNodeValue.text;
					}
					return value;
				}
				return "";
			};

			return properties = {
				name: getNodeValue('ObjName'),
				description:  getNodeValue('ObjDesc'),
				url:  getNodeValue('ObjLink'),
				type: getNodeValue('ObjCls')
			};
		},

		getObjectsFromXml: function (xmlDoc) {
			var doc = xmlDoc.evaluate ? xmlDoc : document,
				xmlObjects = doc.evaluate('/Objects/Object', xmlDoc, null, XPathResult.ANY_TYPE, null),
				objectNode = xmlObjects.iterateNext(),
				objectList = [],
				objectProperties;

			while (objectNode) {
				objectProperties = this.getObjectPropertiesFromXml(xmlDoc, objectNode);
				objectList.push(objectProperties);
				objectNode = xmlObjects.iterateNext();
			}

			return objectList;
		},

		loadWebApplicationsCallback: function (req) {
			if (req.responseXML) {
				var objectList = this.getObjectsFromXml(req.responseXML);
				this.renderWebMenu(objectList);
			}
		},

		loadWebApplicationsFailureCallback: function (req) {
			var webMenuElement, objsBoxEl, objMenuOptEl;
			if (DeveloperMenu.Menu.QRCodesMode) {
				objsBoxEl = DeveloperMenu.Dom.el("objs-box");
				DeveloperMenu.Dom.addClass(objsBoxEl, "hidden");
				objMenuOptEl = DeveloperMenu.Dom.el("nav-webobjects");
				DeveloperMenu.Dom.addClass(objMenuOptEl, "hidden");
			}
			else {
				webMenuElement = DeveloperMenu.Dom.el("objs-list");
				webMenuElement.innerHTML = "Something went wrong loading developermenu.xml";
			}
		},

		ENABLED_SD_BOX_CLASS: 'box-disabled',
		enableSD: function () {
			DeveloperMenu.Dom.removeClass(document.body, "sd-off");
		},

		disableSD: function () {
			DeveloperMenu.Dom.addClass(document.body, "sd-off");
		},

		updateKbnImage: function () {
			var appUrl = DeveloperMenu.Util.getAppBaseUrl(),
				kbnQRCodeEl = DeveloperMenu.Dom.el('kbn-qrcode'),
				qrCodeUrl = DeveloperMenu.Util.getQRCodeImage(appUrl);

			kbnQRCodeEl.src = qrCodeUrl;
		},

		getFileNameByDevice: function (app, device) {
			if (device == DeveloperMenu.Devices.Android)
				return app.n + '.' + "apk";
			return "";
		},

		renderAndroidMenu: function (sdApps) {
			var buffer = [],
				app,
				androidMenuElement = DeveloperMenu.Dom.el("sdapps-box-content"),
				i,
				len,
				fileName,
				fileUrl,
				qrCodeUrl;

			if (sdApps.apps && sdApps.apps.length > 0) {
				for (i = 0, len = sdApps.apps.length; i < len; i++) {
					app = sdApps.apps[i];
					fileName = this.getFileNameByDevice(app, DeveloperMenu.Devices.Android);
					fileUrl = DeveloperMenu.Util.getAppBaseUrl() + "/" + fileName;
					qrCodeUrl = DeveloperMenu.Util.getQRCodeImage(fileUrl);

					buffer.push([
						'<div class="action-box qrcode-box">',
							'<figure>',
								'<a class="qrcode-link" href="', fileUrl, '" target="_blank"><img class="qrcode" src="', qrCodeUrl, '" alt="', app.n, ' QR code"/></a>',
								'<figcaption>',
									'<header>',
										'<h2>', app.n, '</h2>',
									'</header>',
									'<a href="', fileUrl, '" target="_blank">Download</a>',
								'</figcaption>',
							'</figure>',
							'<img src="devmenu/Zoom_In.png" alt="Zoom QR code" title="Click to zoom QR code" class="qrcode-zoom"/>',
						'</div>'
					].join(""));
				}

				androidMenuElement.innerHTML = buffer.join("");
				this.checkSDDownloadLinks();
			}
		},

		renderWebMenu: function (objectList) {
			var buffer = [],
				obj,
				webMenuElement = DeveloperMenu.Dom.el("objs-list"),
				objsBox,
				i,
				len,
				nameText;

			if (objectList.length === 0) {
				var webMenuElement = DeveloperMenu.Dom.el("objs-list");
				webMenuElement.innerHTML = "Sorry, no web objects to show at this time.";
				return;
			}

			objectList = objectList.sort(function (a, b) {
				var aName = a.name.toLowerCase(),
					bName = b.name.toLowerCase();
				if (aName > bName) {
					return 1;
				}
				if (aName < bName) {
					return -1;
				}
				return 0;
			});

			for (i=0, len=objectList.length; i<len; i++) {
				obj = objectList[i];
				nameText = DeveloperMenu.Menu.useDescription() ? obj.description : obj.name;
				buffer.push([
					'<li>',
						'<a class="obj-class-', obj.type,'" href="', obj.url ,'" title="', obj.description,'">',
							nameText.replace(/\\/g, "."),
						'</a>',
					'</li>'
				].join(""));
			}

			webMenuElement.innerHTML = buffer.join("");
		},

		attachHandlers: function () {
			DeveloperMenu.Dom.attachEvent(document.body, 'click', this.handleBodyClick, this);
		},

		handleBodyClick: function (e) {
			e = e || event;
			var target = DeveloperMenu.Dom.getEventTarget(e, 'qrcode-zoom', 1);
			if (target) {
				this.handleZoomClick(target, e);
			}
			else {
				target = DeveloperMenu.Dom.getEventTarget(e, 'nav-item', 1);
				if (target)
					this.setNavMenuOptionSelected(target);
			}
		},

		handleZoomClick: function (el, e) {
			var boxEl = el.parentNode;
			if (DeveloperMenu.Dom.hasClass(boxEl, "zoomed")) {
				DeveloperMenu.Dom.removeClass(boxEl, "zoomed");
				el.src = "devmenu/Zoom_In.png";
			}
			else {
				DeveloperMenu.Dom.addClass(boxEl, "zoomed");
				el.src = "devmenu/Zoom_Out.png";
			}
		},

		setNavMenuOptionSelected: function (el) {
			var selected = DeveloperMenu.Dom.byClass('selected')
			if (selected.length) {
				DeveloperMenu.Dom.removeClass(selected[0], "selected");
			}
			DeveloperMenu.Dom.addClass(el, "selected");
		},

		checkSDDownloadLinks: function () {
			setTimeout((function () {
				var appMatrixEl = DeveloperMenu.Dom.el('sdapps-box');
				var links = DeveloperMenu.Dom.byClass('qrcode-link', 'a', appMatrixEl);
				for (var i = 0, len = links.length; i < len; i++) {
					this.checkDownloadLink(links[i]);
				}
			}).closure(this), 100);
		},

		checkDownloadLink: function (qrCodeUrlEl) {
			var qrCodeBox = qrCodeUrlEl.parentNode.parentNode;
			var turnBoxOff = function () {
				DeveloperMenu.Dom.addClass(qrCodeBox, "off");
				qrCodeBox.setAttribute('title', 'Package is not available for download.');
			};
			this.loadFile({
				url: qrCodeUrlEl.href,
				success: function (req) {
					if (req.readyState == 4) {
						if (req.status == 404) {
							turnBoxOff();
						}
					}
				},
				failure: turnBoxOff,
				method: "HEAD",
				scope: this
			});
		}
	},

	Ajax: {
		getRequestObj: function () {
			var req = null;
			if (window.XMLHttpRequest) {
				req = new XMLHttpRequest();
			}
			if (!req) {
				try {
					req = new ActiveXObject('Msxml2.XMLHTTP');
				}
				catch (e) {
					try {
						req = new ActiveXObject('Microsoft.XMLHTTP');
					}
					catch (e) { }
				}
			}
			return req;
		}
	}
};

gx = {
	setStaticDirectory: function (url) {
		DeveloperMenu.Util.staticUrl = url;
	},
	text: {
		chr: function (code) {
			return String.fromCharCode(code);
		}
	}
};

// WA for older IE versions, so CSS can be applied to header elements
if (DeveloperMenu.Browser.isIE())
	document.createElement("header");
