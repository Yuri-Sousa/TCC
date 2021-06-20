/* START OF FILE - ..\js\gxapi_i.js - */
gx.setGxObyCtx = function( cmpCtx, inMaster) {
	var gxObj;
	if (cmpCtx != undefined) {
		gxObj = gx.getObj(cmpCtx, inMaster);
		if (gxObj)
			gx.setGxO(cmpCtx, inMaster);
	}
	return gx.O;
};

gx.parentGridRow = function (GridId, gxO) {
	var curRow = gx.fn.currentGridRowImpl(GridId);
	var grid = gxO.getGridById(GridId, curRow);
	if (grid && grid.parentGrid) {
		curRow = gx.fn.currentGridRow(grid.parentGrid.gridId);
	}
	else
	{
		curRow = undefined;
	}
	return curRow;
};

gx.applyPicture = function (vStruct, value, Ctrl) {			
	if (!gx.lang.emptyObject(vStruct) && !gx.lang.emptyObject(gx.rtPicture(vStruct, Ctrl)) && !gx.lang.emptyObject(vStruct.type)) {
		try {
			switch (vStruct.type) {
				case 'int':
				case 'decimal':
					return gx.num.formatNumber(value, vStruct.dec, gx.rtPicture(vStruct, Ctrl), vStruct.len, vStruct.sign, true);
				case 'char':
					return value;
					//case 'date':
					//	return this.OldDate( ctrlName, varName);
					//case 'dtime':
					//	return this.OldDateTime( ctrlName, varName);
				default:
					return value;
			}
		}
		catch (e) {
			//invalid number
		}
	}			
	return value;
};

gx.SetOld = function (Fld, Ctrl, Var) {
	var ctrlId = Ctrl;
	var GridId = gx.fn.controlGridId(Fld);
	if (GridId > 0) {
		ctrlId = Ctrl + '_' + gx.fn.currentGridRow(GridId);
	}
	gx.fn.setHidden(ctrlId, gx.getVar(Var));
},

gx.Old = function (Fld, Ctrl) {
	try {
		var ctrlId = Ctrl;
		var GridId = gx.fn.controlGridId(Fld);
		if (GridId > 0) {
			ctrlId = Ctrl + '_' + gx.fn.currentGridRow(GridId);
		}
		var oldValue = gx.fn.getHidden(ctrlId);
		if (typeof (oldValue) == 'undefined' && (gx.O.CmpContext != '')) {
			oldValue = gx.fn.getHidden(gx.O.CmpContext + ctrlId);
		}
		return oldValue;
	}
	catch (e) {
		gx.dbg.logEx(e, 'gxapi.js', 'Old');
	}
	return '';
};

gx.OldInteger = function (Fld, Var) {
	var nIntVal = parseInt(gx.Old(Fld, Var), 10);
	return isNaN(nIntVal) ? 0 : nIntVal;
};

gx.OldDecimal = function (Fld, Var) {
	var nDecVal = gx.num.parseFloat(gx.Old(Fld, Var), gx.thousandSeparator, gx.decimalPoint);
	return isNaN(nDecVal) ? 0 : nDecVal;
};

gx.OldDate = function (Fld, Var) {
	var gxD = new gx.date.gxdate(gx.Old(Fld, Var), 'Y4MD');
	return gxD.getStringWithFmt(gx.dateFormat);
};

gx.OldDateTime = function (Fld, Var) {
	var gxD = new gx.date.gxdate(gx.Old(Fld, Var), 'Y4MD');
	return gxD.getStringWithFmt(gx.dateFormat) + ' ' + gxD.getTimeString(true, true);
};

gx.dom_i =(function($){
	return {

	el: function (id, avoidName, avoidSpan, noCaching) {
		//Critical function, changes here impact performance
		if (!id) {
			return null;
		}
		else if (typeof id === 'string') {			
			var ctrl = this.byId(id);
			if (ctrl != null) {
				return ctrl;
			}
			if (!avoidSpan) {
				ctrl = this.byId("span_" + id);
				if (ctrl != null) {
					return ctrl;
				}
			}
			if (avoidName) {
				return null;
			}
			ctrl = this.byName(id);
			if (ctrl != null && ctrl.length > 0) {
				if (!ctrl[0].id) {
					ctrl[0].id = id;
				}
				return ctrl[0];
			}	
			return null;
		}
		else {
			return id;
		}
	},

	matchesSelector: (function () {
		var useJQuery;
		return function (el, selector) {
			var matchesFn;
			var el = gx.dom.byId(el);

			matchesFn = (el.matches || el.matchesSelector || el.msMatchesSelector || el.mozMatchesSelector || el.webkitMatchesSelector || el.oMatchesSelector);
			
			if (useJQuery === undefined) {
				useJQuery = gx.util.browser.isIE() && gx.util.browser.ieVersion() <= 8;
			}
			if (useJQuery || !matchesFn) {
				return $(el).is(selector);
			}
			else {
				if (matchesFn) {
					return matchesFn.call(el, selector);
				}
			}
			return false;
		};
	})(),

	hasAttribute: function(el, attrName) {
		return el.hasAttribute ? el.hasAttribute(attrName): el[attrName] !== undefined;
	},
	
	hasClass: function (id, className) {
		var el = gx.dom.el(id, true);
		if (el) {
			if (el.classList) {
				return el.classList.contains(className);
			}
			return className && (' ' + el.className + ' ').indexOf(' ' + className + ' ') != -1;
		}
	},

	addPrefixClass: function (el, prefixClass) {
		if (el) {
			var $el = $(el);
			if (el.className && !$el.attr('data-gx-unprefixed-class')) {
				$el.attr('data-gx-unprefixed-class', el.className);
				var classes = el.className.split(" ");
				classes.splice(0, 0, "");
				el.className += classes.join(" " + prefixClass);
			}
		}
	},

	removePrefixClass: function (el, prefixClass) {
		if (el) {
			var $el = $(el);
			if (el.className.search(new RegExp("(^|\\s)" + prefixClass)) >= 0) {
				var oldClassName = $el.attr('data-gx-unprefixed-class');
				$el.removeAttr('data-gx-unprefixed-class');
				el.className = oldClassName || el.className.substring(prefixClass.length);
			}
		}
	},

	addClass: function (id, className) {
		var el = gx.dom.el(id, true);
		if (el && className) {
			if (el.classList) {
				if (className.indexOf(" ") > 0) {
					el.classList.add.apply(el.classList, className.split(" "));
				}
				else {
					el.classList.add(className);
				}
			}
			else {
				if (!this.hasClass(id, className)) {
					el.className = el.className + (el.className ? " " : "") + className;
				}
			}
		}
	},

	classReCache: {},
	removeClass: function (id, className) {
		var el = gx.dom.el(id, true);
		if (el) {
			if (el.classList) {
				el.classList.remove(className);
			}
			else {
				if (this.hasClass(id, className)) {
					var re = this.classReCache[className];
					if (!re) {
						re = new RegExp('(?:^|\\s+)' + className + '(?:\\s+|$)', "g");
						this.classReCache[className] = re;
					}
					el.className = el.className.replace(re, " ");
				}
			}
		}
	},

	hasTransition: function (el) {
		if (el && Modernizr.csstransitions) {
			var browser = gx.util.browser;
			var property = "transitionDuration";
			if (browser.isIE())
				property = "msTransitionDuration";
			if (browser.isWebkit())
				property = "webkitTransitionDuration";
			else if (browser.isFirefox())
				property = "MozTransitionDuration";
			else if (browser.isOpera())
				property = "OTransitionDuration";

			var value = parseFloat(gx.dom.getComputedStyle(el)[property], 10);
			return value !== 0 && !isNaN(value);
		}
		return false;
	},

	hasAnimation: function (el) {
		if (el && Modernizr.csstransitions)
		{
			var browser = gx.util.browser;
			var property = "animationName";
			if (browser.isIE())
				property = "msAnimationName";
			if (browser.isWebkit())
				property = "webkitAnimationName";
			else if (browser.isFirefox())
				property = "MozAnimationName";
			else if (browser.isOpera())
				property = "OAnimationName";

			var value = gx.dom.getComputedStyle(el)[property];
			return value && value != 'none';
		}
		return false;
	},

	isMultimediaElement: function (el) {
		return el.tagName == 'SPAN' && (gx.dom.hasClass(el, "gx-video-placeholder") || gx.dom.hasClass(el, "gx-audio-placeholder") || gx.dom.hasClass(el, "gx-download-placeholder"))
	},

	purgeElement: function (d, atts) {
		var a = atts || d.attributes, i, l, n;
		if (a) {
			l = a.length;
			for (i = 0; i < l; i += 1) {
				n = a[i].name || a[i];
				if (typeof d[n] === 'function') {
					d[n] = null;
				}
			}
		}
	},

	purge: function (d, onlyChildNodes) {
		if (!onlyChildNodes) {
			this.purgeElement(d);
		}

		var childNodes = d.childNodes;
		if (childNodes) {
			for (var i = 0, l = childNodes.length; i < l; i++) {
				gx.dom.purge(childNodes[i], false);
			}
		}
	},

	shouldPurge: function () {
		return gx.purgeElements && gx.util.browser.isOldIE();
	},

	form: function () {
		if (this._form == null) {
			this._form = document.forms["MAINFORM"];
			if (!this._form)
				this._form = document.forms[0];
		}
		return this._form;
	},

	indexElements: function () {
		try {
			var els = gx.fn.getFormElements();
			var len = els.length;
			for (var i = 0; i < len; i++) {
				els[i].gxIndex = i;
			}
		}		
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'indexElements');
		}
	},

	setAttribute: function (Control, AttName, AttValue) {
		var doSetAtt = function () {
			try {
				var Ctrls = gx.dom.byName(Control);
				if (Ctrls != null && Ctrls.length > 0) {
					var rLen = Ctrls.length;
					for (var i = 0; i < rLen; i++) {
						Ctrls[i].setAttribute(AttName, AttValue);
					}
				} else {
					var Ctrl = gx.dom.byId(Control);
					if (Ctrl != null)
						Ctrl.setAttribute(AttName, AttValue);
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'setAttribute');
			}
		};

		if (document.gxReadyState == 'loading') {
			gx.fx.obs.addObserver('gx.onload', this, doSetAtt, { single: true });
		}
		else {
			doSetAtt.apply(this);
		}
	},

	createInput: function (ControlId, Type) {
		var newH = document.createElement("input");
		newH.type = Type;
		newH.id = ControlId;
		newH.name = ControlId;
		gx.dom.form().appendChild(newH);
		return newH;
	},
	
	hasSelectedFile: function () {
		var inputs = $('input[type="file"]');
		var len = inputs.length;
		if (!len)
			return false;
		for (var i = 0; i < len; i++) {
			if (!gx.lang.emptyObject(inputs[i].value)) {
				return true;
			}
		}
		return false;			
	},

	hasSubmitControl: function () {
		var inputs = this.byTag("input");
		var len = inputs.length;
		if (!len)
			return false;
		for (var i = 0; i < len; i++) {
			var iType = inputs[i].getAttribute('type');
			if ((iType == 'submit') || (iType == 'image'))
				return true;
		}
		return false;
	},

	styles: function () {
		var sheets = document.styleSheets;
		if (typeof (sheets) != 'undefined') {
			var styles = [];
			var len = sheets.length;
			for (var i = 0; i < len; i++) {
				var sheet = sheets[i].href;
				if (!gx.lang.emptyObject(sheet))
					styles.push(sheet);
			}
			return styles;
		}
		return [];
	},

	getComputedStyle: function (el) {
		try {
			if (el.nodeName == '#document')
				return null;
			else if (typeof (window['getComputedStyle']) == 'function')
				return window.getComputedStyle(el);
			else if (typeof (el.currentStyle) != 'undefined')
				return el.currentStyle;
			else return el.style;
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'getComputedStyle');
			return null;
		}
	},

	getStyle: function (ctrl, key) {
		var value = '';
		try {
			if (typeof (window['getComputedStyle']) == 'function')
				value = window.getComputedStyle(ctrl, null)[key];
			else if (typeof (ctrl.currentStyle) != 'undefined')
				value = ctrl.currentStyle[key];
			else
				value = ctrl.style[key];
			var nValue = parseInt(value);
			if (!isNaN(nValue))
				value = nValue;
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'getStyle');
		}
		return value;
	},

	CSS_URL_REGEXP: /url\(["\']?(?!(?:https?:|\/))([^"\)]+)["\']?\)/ig,
	CSS_BASE_URL_REGEXP: /(.+\/)[^\/]+$/ig,
	cssRules: null,
	cacheStyleSheet: function(ss, fixUrls) {
		var cssText,
			baseUrl = ss.href ? ss.href.replace(this.CSS_BASE_URL_REGEXP, "$1") : document.location.href,
			ssRules;

		if(!this.cssRules){
			this.cssRules = [];
		}

		try {
			ssRules = ss.cssRules || ss.rules;
			if (ssRules) {
				for (var i = 0, len = ssRules.length; i < len; i++) {
					cssText = ssRules[i].cssText;
					if (fixUrls) {
						cssText = cssText.replace(this.CSS_URL_REGEXP, 'url("' + baseUrl + '$1")');
					}
					this.cssRules.push(cssText);
				}
			}
		}
		catch(e) {}
	},

	getCssRules: function(refreshCache, fixUrls) {
		var ds = document.styleSheets;
		if (this.cssRules === null || refreshCache) {
			this.cssRules = [];
			for (var i=0, len=ds.length; i < len; i++) {
				try {
					if (!ds[i].disabled) {
						this.cacheStyleSheet(ds[i], fixUrls);
					}
				} catch(e) {}
			}
		}
		return this.cssRules;
	},
	
	setStyleElement: function(styleEl, content, append) {
		try {
			styleEl.innerHTML = (append ? styleEl.innerHTML : "") + content;
		}
		catch (e) {
			styleEl.styleSheet.cssText = (append ? styleEl.styleSheet.cssText : "") + content;
		}
	},

	isButton: function (Ctrl) {
		if (Ctrl != undefined && Ctrl != null)
			return (Ctrl.type == 'submit') || (Ctrl.type == 'button');
		return false;
	},

	isRadio: function (Ctrl) {
		return (Ctrl && Ctrl.tagName == "INPUT" && Ctrl.type == "radio");
	},

	editControls: {
		'text': true,
		'password': true,
		'color': true,
		'date': true,
		'datetime': true,
		'datetime-local': true,
		'email': true,
		'number': true,
		'search': true,
		'url': true,
		'tel': true,
		'month': true,
		'week': true
	},

	isEditControl: function (Ctrl) {
		if (Ctrl && Ctrl.tagName == "INPUT") {
			return this.editControls[Ctrl.type] || false;
		}
		return false;
	},

	isTextControl: function (Ctrl) {
		return Ctrl && Ctrl.tagName === "INPUT" && Ctrl.type === 'text';
	},

	isDateControl: function (Ctrl) {
		return Ctrl.type == "date" || Ctrl.type == "datetime" || Ctrl.type == "datetime-local";
	},

	isButtonLike: function (Ctrl) {
		if (!Ctrl)
			return false;
		if (this.isButton(Ctrl) || gx.dom.hasAttribute(Ctrl, gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR))
			return true;
		if (Ctrl && Ctrl.nodeName === 'INPUT')
			return (Ctrl.type === 'file' || (Ctrl.type === 'image' || Ctrl.type === 'checkbox') && typeof (Ctrl.onclick) == "function");
		return false;
	},

	iFrameDoc: function (iFrame) {
		try {
			if (iFrame.contentDocument)
				return iFrame.contentDocument;
			if (iFrame.contentWindow) {
				return iFrame.contentWindow.document;
			}
		}
		catch (e) {
		}
		return null;
	},

	forEachChild: function (control, ctx, func) {
		if (control && control.childNodes && typeof (func) == 'function') {
			var len = control.childNodes.length;
			for (var i = 0; i < len; i++) {
				if (func.call(ctx, control.childNodes[i]) === false) {
					break;
				}
			}
		}
	},

	isTextWithLink: function (Control) {
		if (Control != null) {
			if ((Control.tagName == 'A') && Control.childNodes && (Control.childNodes.length > 0)) {
				var childNode = Control.firstChild;
				if (this.innerChildIsText(childNode))
					return true;

			}
		}
		return false;
	},

	isImageWithLink: function (el) {
		var childElement;
		if (el && el.tagName === "A" && el.href) {
			childElement = el.firstElementChild;
			if (!gx.dom.hasClass(childElement, "gx-prompt")) {
				if (childElement && childElement.tagName === "IMG") {
					return true;
				}
			}
		}
		return false;
	},

	isChildNode: function (Child, Parent) {
		if (Child.frameElement)
			Child = Child.frameElement;
		if (Child == Parent)
			return true;
		while (Child.parentNode) {
			if (Child == Parent)
				return true;
			if (Child.parentNode == Parent)
				return true;
			Child = Child.parentNode;
		}
		return false;
	},

	NodeLevel: function (el) {
		var nLvl = 0;
		while (el.parentNode) {
			if (el.id || el.name)
				nLvl++;
			el = el.parentNode;
		}
		return nLvl;
	},

	findParentByTagName: function (el, tagName, max) {
		var parent = el.parentNode;
		tagName = tagName.toUpperCase();
		i = 0;
		while (parent) {
			if (max && i == max)
				return;
			i++;
			if (parent.tagName == tagName)
				return parent;
			parent = parent.parentNode;
		}
	},

	innerChildIsText: function (childNode) {
		while (childNode != null) {
			if (childNode.nodeName && (childNode.nodeName == '#text'))
				return true;
			childNode = childNode.firstChild;
		}
		return false;
	},

	allChildrenAreText: function (parentNode) {
		var childNode = parentNode.firstChild;
		while (childNode) {
			var nType = childNode.nodeName.toLowerCase();
			if (nType !== '#text' && nType !== 'pre' && childNode.offsetParent != null)
				return false;
			childNode = childNode.nextSibling;
		}
		return true;
	},

	position: function (el) {
		var offset = $(el).offset();	
		return { x: Math.floor(offset.left), y: Math.floor(offset.top) };
	},

	dimensions: function (el) {
		var ctrl = $(el);
		return { w: ctrl.outerWidth(), h: ctrl.outerHeight() };
	},

	windowDimensions: function (frameDoc) {
		var doc = frameDoc.documentElement;
		var body = frameDoc.body;
		if (doc && doc.scrollHeight) {
			var sH = Math.max(doc.scrollHeight, body.scrollHeight);
			var sW = Math.max(doc.scrollWidth, body.scrollWidth);
			var cH = Math.max(doc.clientHeight, body.clientHeight);
			var cW = Math.max(doc.clientWidth, body.clientWidth);
			return { scrollWidth: sW, scrollHeight: sH, clientHeight: cH, clientWidth: cW };
		} else {
			return {
				scrollWidth: body.scrollWidth, scrollHeight: body.scrollHeight,
				clientHeight: body.clientHeight, clientWidth: body.clientWidth
			};
		}
	},

	documentScroll: function (doc) {
		var doc = doc || document,
			sTop = -1, sLeft = -1;
		try {
			sTop = (doc.documentElement.scrollTop || doc.body.scrollTop);
			sLeft = (doc.documentElement.scrollLeft || doc.body.scrollLeft);
		}
		catch (e) {}
		return { scrollTop: sTop, scrollLeft: sLeft };
	},
	
	documentScrollable: function (doc) {
		var doc = doc || document;
		var scroll = {x:false, y:false};
		var dimensions = gx.dom.windowDimensions(doc);		
		
		if (dimensions.scrollHeight > dimensions.clientHeight) {
			scroll.x = true;
		}
		if (dimensions.scrollWidth > dimensions.clientWidth) {
			scroll.x = true;
		}				
		return scroll;
	},

	autofitIFrame: function (evt) {
		var loadEvt = window.event || evt;
		var frameCtrl = gx.evt.source(loadEvt);
		var frameDoc = window.frames[frameCtrl.name].document;
		if (!frameDoc || frameCtrl.width != '' || frameCtrl.height != '')
			return;
		var dims = gx.dom.windowDimensions(frameDoc);
		var docW = dims.scrollWidth ? (dims.scrollWidth + 10) : null;
		var docH = dims.scrollHeight ? (dims.scrollHeight + 10) : null;
		if (docW && docH) {
			frameCtrl.style.width = docW + 'px';
			frameCtrl.style.height = docH + 'px';
		}
	},

	fitToParent: function (ctrl) {
		if (!gx.util.browser.isIE()) {
			if (ctrl && ctrl.childNodes) {
				var firstTable = null;
				var len = ctrl.childNodes.length;
				for (var i = 0; i < len; i++) {
					var elem = ctrl.childNodes[i];
					if (elem.nodeName == 'TABLE') {
						firstTable = elem;
						break;
					}
				}
				if (firstTable != null) {
					if (firstTable.style.width.indexOf('%') != -1)
						ctrl.style.width = gx.dom.addUnits(firstTable.style.width);
					if (firstTable.style.height.indexOf('%') != -1)
						ctrl.style.height = gx.dom.addUnits(firstTable.style.height);
				}
			}
		}
	},

	redrawControl: function (Control) {
		if (!gx.util.browser.isIE() || (gx.util.browser.ieVersion() >= 6))
			gx.html.setOuterHtml(Control, Control.outerHTML);
		else
			setTimeout(function () { gx.html.setOuterHtml(Control, Control.outerHTML); }, 100);
	},

	setCaretPosition: function (ctrl, pos) {
		if (ctrl != null) {
			if (ctrl.createTextRange) {
				var range = ctrl.createTextRange();
				range.move('character', pos);
				range.select();
			}
			else {
				if (ctrl.selectionStart) {
					ctrl.focus();
					ctrl.setSelectionRange(pos, pos);
				}
				else {
					ctrl.focus();
				}
			}
		}
	},

	replaceAtCaretPosition: function (ctrl, text) {
		var selStart = ctrl.selectionStart;
		var selEnd = ctrl.selectionEnd;
		if (document.selection) {
			var bookmark = document.selection.createRange().getBookmark();
			ctrl.selection = ctrl.createTextRange();
			ctrl.selection.moveToBookmark(bookmark);
			ctrl.selectLeft = ctrl.createTextRange();
			ctrl.selectLeft.collapse(true);
			ctrl.selectLeft.setEndPoint("EndToStart", ctrl.selection);
			selStart = ctrl.selectLeft.text.length + 1;
			selEnd = ctrl.selectLeft.text.length + ((ctrl.selection.text.length == 0) ? 1 : ctrl.selection.text.length);
		}  
		else
		{
			selStart = ctrl.selectionStart;
			selEnd = ctrl.selectionEnd;
		}
		if (ctrl.setRangeText) {
			ctrl.setRangeText( text, selStart, selEnd, 'end');
		}
		else {
			ctrl.value = ctrl.value.substr( 0, selStart) + text + ctrl.value.substr( selStart, ctrl.value.length);
			gx.dom.setCaretPosition(ctrl, selStart + text.length);					
		}
		
	},

	spanValue: function (el) {
		var val = el.nodeValue;
		if (gx.lang.emptyObject(val))
			val = el.innerText || el.textContent;
		if (gx.lang.emptyObject(val))
			val = '';
		return val;
	},

	removeControlSafe: function (ctrl) {
		if (!this._avoidLeaksDiv) {
			this._avoidLeaksDiv = document.createElement('DIV');
		}
		this._avoidLeaksDiv.appendChild(ctrl);
		if (gx.dom.shouldPurge())
			gx.dom.purge(this._avoidLeaksDiv);
		this._avoidLeaksDiv.innerHTML = '';
	},

	removeControl: function (ctrl) {
		if (document.createRange == null)
			ctrl.removeNode(true);
		else {
			var range = document.createRange();
			if (ctrl) {
				range.selectNode(ctrl);
				range.deleteContents();
			}
		}
	},

	radioToObj: function (Ctrl, value) {
		var obj = { s: '', v: [] };
		var items;
		if (!Ctrl)
			return obj;
		if (gx.dom.isRadio(Ctrl)) {
			obj.s = Ctrl.value;
			items = gx.dom.byName(Ctrl.name);
			var len = items.length;
			for (var i = 0; i < len; i++) {
				var $option = $(items[i]);
				var $label = $("label[for='" + items[i].id + "']").first();
				obj.v.push([$option.val(), $label.text().trim()]);
			}
		}
		return obj;
	},

	comboBoxToObj: function (Ctrl, value) {
		try {
			var obj = { s: '', v: [] }
			if (!Ctrl)
				return obj;
			if (Ctrl.tagName === 'SELECT') {
				obj.s = Ctrl.value;
				var len = Ctrl.options.length;
				for (var i = 0; i < len; i++) {
					var $option = $(Ctrl.options[i]);														
					obj.v.push([$option.val(), $option.text()]);
				}
			}
			else if (Ctrl.tagName === 'SPAN') //Combo readonly
			{
				if (Ctrl.hasAttribute(gx.GxObject.GX_DATA_RAW_VALUE_ATTR)) {
					return gx.json.evalJSON(Ctrl.getAttribute(gx.GxObject.GX_DATA_RAW_VALUE_ATTR));
				}
				else {
					var text = gx.fn.getControlValue_span(Ctrl);
					obj.v.push([value, text]);
					obj.s = value;
				}
			}
			return obj;
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'comboBoxToObj');
		}
		return null;
	},

	unitPattern: /\d+(px|em|%|en|ex|pt|in|cm|mm|pc|s|ch|rem|vh|vw|vmin|vmax|q)$/i,
	addUnits: function (dim, defaultUnit) {
		if (dim === "" || dim == "auto")
			return dim;

		if (dim === undefined)
			return '';

		if (typeof dim == "number" || !this.unitPattern.test(dim))
			return dim + (defaultUnit || 'px');

		return dim;
	},

	getActiveElement: function (doc) {
			doc = doc || document;
			var activeElement;
			try {
				activeElement = doc.activeElement;
				if (!activeElement || !activeElement.nodeName) {
				  activeElement = doc.body;
				}
			} catch (e) {
				activeElement = doc.body;
			}
	
			return activeElement;
		},
	
	getCaretOffset: function (element) {
		if (element && element.tagName === "INPUT" && element.type === "text" && typeof(element.selectionStart) !== 'undefined')
			return {s:element.selectionStart, e:element.selectionEnd};
		return {s:0, e:0};
	},
	
	setCaretOffset: function(element, offset) {
		if (element && element.tagName == "INPUT" && element.type == "text" && element.setSelectionRange)
			element.setSelectionRange(offset.s, offset.e);
	},			

	write: function (data, doc) {
		doc = doc || document;
		doc.write(data);
	},
	
	writeError: function( text, message, code, el) {
		gx.dbg.write( text);
		el = el || document;
		el.head.innerHTML = "";
		var b = el.body;
		b.innerHTML = text;
	},

	MASK_CLASS: "gx-mask",
	UNMASK_CLASS: "gx-unmask",
	MASK_RELATIVE_CLASS: "gx-masked-relative",
	MASKED_CLASS: "gx-masked",
	isMaskElement: function(el) {
		return this.hasClass(el, this.MASK_CLASS);
	},
	mask: function (el) {
		el = this.el(el);

		if (el && !this.hasClass(el, this.MASK_RELATIVE_CLASS)) {
			var maskEl,
				browser = gx.util.browser,
				ieVersion = browser.ieVersion(),
				fixHeight = (ieVersion == 6 || (browser.isIE && browser.isCompatMode())),
				setExpressionSupported = !!el.style.setExpression;

			if (!$(el).is("body") || this.getComputedStyle(el)['position'] != 'static') {
				this.addClass(el, this.MASK_RELATIVE_CLASS);
			}

			maskEl = document.createElement("div");
			maskEl.className = this.MASK_CLASS;
			
			if (el.tagName == 'TABLE') {
				var $maskEl = $(maskEl),
				$el = $(el);
				$maskEl.width($el.width());
				$maskEl.insertAfter($el);
				$maskEl.parent().addClass(this.MASK_RELATIVE_CLASS);
			}
			else {
				el.appendChild(maskEl);
			}
			this.addClass(el, this.MASKED_CLASS);

			if (fixHeight && setExpressionSupported) {
				try {
					maskEl.style.setExpression('height', 'this.parentNode.' + (el == document.body ? 'scrollHeight' : 'offsetHeight') + ' + "px"');
				} catch (e) { }
			}
			else {
				var heightValue = this.getComputedStyle(el)['height'];
				if (browser.isIE && !(browser.ieVersion == 7 && !browser.isCompatMode()) && heightValue == 'auto') {
					maskEl.style.height = heightValue;
				}
			}
			if (browser.isIE() && (ieVersion <= 7 || browser.isCompatMode())) {
				var $maskEl = $(maskEl);
				var opacity = this.getComputedStyle(maskEl)['opacity'];
				if (opacity)
					$(maskEl).css('opacity', opacity);
			}	
			return maskEl;
		}
	},

	unmask: function (el) {
		el = this.el(el);
		var maskEl;
		
		if (el.tagName == 'TABLE') {
			var s_el = el.nextSibling;
			if (s_el && s_el.tagName == 'DIV' && this.hasClass(s_el, this.MASK_CLASS)) {
				maskEl = s_el;
			}
		}
		else
		{
			for (var i = 0, len = el.childNodes.length; i < len; i++) {
				if (el.childNodes[i].tagName == 'DIV' && 
						this.hasClass(el.childNodes[i], this.MASK_CLASS) &&
						!this.hasClass(el.childNodes[i], this.UNMASK_CLASS)) {
					maskEl = el.childNodes[i];
					break;
				}
			}
		}
		if (maskEl && !maskEl.removed) {
			maskEl.removed = true;
			if (maskEl.style.clearExpression) {
				maskEl.style.clearExpression('width');
				maskEl.style.clearExpression('height');
			}
			this.removeClass(el, this.MASKED_CLASS);
			var fxEventName = (gx.dom.hasTransition(maskEl) ? gx.dom.TRANSITION_END_EVENT : gx.dom.hasAnimation(maskEl) ? gx.dom.ANIMATION_END_EVENT : false);
			var fnc = (function() {
				if (el.tagName == 'TABLE') {
					if (maskEl.parentNode) {
						gx.dom.removeClass(maskEl.parentNode, this.MASK_RELATIVE_CLASS);
						maskEl.parentNode.removeChild(maskEl);
					}
				}
				else {
					if (maskEl.parentNode == el) {
						el.removeChild(maskEl);
					}
				}
				gx.dom.removeClass(el, this.MASK_RELATIVE_CLASS);
			}).closure(this);
			if (fxEventName)
				gx.evt.attach(maskEl, fxEventName, fnc, false, { single: true, useCapture: true, timeout: 300 });
			else
				fnc();
			this.addClass(maskEl, this.UNMASK_CLASS);
		}
		else {
			this.removeClass(el, this.MASKED_CLASS);
			this.removeClass(el, this.MASK_RELATIVE_CLASS);
		}
	},

	replaceWithFx: function(oldEl, newEl, options) {
		var options = options || {},
			enteringClass = options.enteringClass || 'entering',
			leavingClass = options.leavingClass || 'leaving',
			enterDurationClass = options.enterDurationClass || 'enter-fx-duration',
			leaveDurationClass = options.leaveDurationClass || 'leave-fx-duration',
			transitioningClass = options.transitioningClass || 'transitioning',
			transitionTimeout = options.transitionTimeout || 1500;

		var useFx = function (el) {
			return el.childNodes.length > 0 && (gx.dom.hasAnimation(el) || gx.dom.hasTransition(el)) && !gx.dom.hasClass(el.parentNode, transitioningClass);
		};
		
		var getFxEventName = function (el) {
			return gx.dom.hasAnimation(el) ? gx.dom.ANIMATION_END_EVENT : (gx.dom.hasTransition(el) ? gx.dom.TRANSITION_END_EVENT : false);
		};

		if (oldEl.tagName == 'BODY') {
			gx.dom.addClass(oldEl, oldEl.className + "-fx");
			oldEl.style.position = 'static';
		}

		if (newEl.tagName == 'BODY') {
			gx.dom.addClass(newEl, newEl.className + "-fx");
		}

		var parentNode = oldEl.parentNode,
			useLeavingFx = useFx(oldEl),
			useEnteringFx = useFx(newEl),
			useParallelFx = oldEl.tagName != 'BODY';

		if (useLeavingFx || useEnteringFx) {
			var iframe = document.createElement('iframe'),
				iframeCt = document.createElement('div'),
				iframeDoc,
				rule,
				styleSheet,
				cssRules,
				oldElStyle = this.getComputedStyle(oldEl),
				oldElWidth = oldElStyle['width'],
				oldElHeight = oldElStyle['height'],
				i,
				len,
				leavingFxEventName = getFxEventName(oldEl),
				enteringFxEventName = getFxEventName(newEl),
				leavingTransFn,
				enteringTransFn,
				transitionEndFn,
				leavingTransTimeoutHdlr,
				enteringTransTimeoutHdlr,
				transStatus = 0,
				idx = 0;

			gx.dom.addClass(parentNode, transitioningClass);

			if (oldEl.tagName != 'BODY' && newEl.tagName != 'BODY') {
				if (useLeavingFx) {
					// A temporal iframe is created to be able to have in the same page the old and new content, 
					// regardless of repeated element ids.
					// All the CSS rules of the document must be copied to the temp iframe, as well as the document type, so there
					// are no visual differences.
					iframe.setAttribute("scrolling", "no");
					iframe.setAttribute("frameborder", "0");
					iframe.style.width = gx.dom.addUnits(window.innerWidth);
					iframe.style.height = gx.dom.addUnits(window.innerHeight);
					iframe.style.display = 'none';

					iframeCt.appendChild(iframe);
					iframeCt.style.width = oldElWidth;
					iframeCt.style.height = oldElHeight;
					iframeCt.style.overflow = 'hidden';

					gx.spa.dettachContent(oldEl);
					
					oldEl.insertBefore(iframeCt, oldEl.firstChild);

					iframeDoc = iframe.contentDocument;
					try {
						iframeDoc.open();
						iframeDoc.write(this.getDocTypeDeclaration(document));
						iframeDoc.write("<html>");
						iframeDoc.write("<head></head>");
						iframeDoc.write("<body><div></div></body>");
						iframeDoc.write("</html>");
						iframeDoc.close();
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxapi.js', 'replaceWithFx');
						var aDiv = iframeDoc.createElement('div');
						iframeDoc.body.appendChild(aDiv);
					}

					if (iframeDoc.documentElement) {
						iframeDoc.documentElement.className = "gx-fx-iframe";
					}
					iframeDoc.body.style.margin = '0';
					iframeDoc.body.className = gx.dom.form().className;

					iframeDoc.head.appendChild(document.createElement('style'));
					styleSheet = iframeDoc.styleSheets[0];
					cssRules = gx.dom.getCssRules(true, true);
					for (i=0, len=cssRules.length; i<len; i++) {
						try {
							styleSheet.insertRule(cssRules[i], idx);
							idx++;
						}
						catch (e) {
							gx.dbg.write('Warning: CSS Stylesheet rule not loaded:' + cssRules[i]);									
						}
					}

					iframeDoc.body.firstChild.style.width = oldElWidth;
					iframeDoc.body.firstChild.style.height = oldElHeight;
					while (oldEl.childNodes[1]) {
						iframeDoc.body.firstChild.appendChild(oldEl.childNodes[1]);
					}

					iframe.style.display = 'block';
				}
				else {
					if (useEnteringFx) {
						oldEl.style.display = 'none';
					}
				}
			}

			gx.dom.addClass(newEl, enteringClass);
			gx.dom.addClass(newEl, enterDurationClass);
			gx.dom.addClass(oldEl, leaveDurationClass);
			if (options.domAdd !== false) {
				parentNode.appendChild(newEl);
			}

			var applyTransFn = function() {
				// Fire transitionEndCallback when both transitions ended
				transitionEndFn = function() {
					if (transStatus === 2) {
						gx.dom.removeClass(parentNode, transitioningClass);
						if (useParallelFx) {
							if (options.transitionEndCallback) {
								newEl = options.transitionEndCallback(oldEl, newEl);
							}
							
							if (options.domRemove !== false && oldEl.parentNode == parentNode) {
								parentNode.removeChild(oldEl);
							}
						}
						gx.dom.removeClass(newEl, enterDurationClass);
					}
					else {
						if (!useParallelFx) {
							if (options.transitionEndCallback) {
								newEl = options.transitionEndCallback(oldEl, newEl);
							}
							gx.dom.removeClass(newEl, enteringClass);
							if (useEnteringFx) {
								enteringTransTimeoutHdlr = setTimeout(enteringTransFn, transitionTimeout);
							}
						}
					}
				};

				if (useLeavingFx) {
					// Leaving element transition end callback
					leavingTransFn = function(){
						clearTimeout(leavingTransTimeoutHdlr);
						transStatus++;
						if (options.leavingTransCallback) {
							options.leavingTransCallback(oldEl, newEl);
						}
						transitionEndFn();
					};
					gx.evt.attach(oldEl, leavingFxEventName, leavingTransFn, false, { single: true, useCapture: true });
				}
				else {
					transStatus++;
					transitionEndFn();
				}

				if (useEnteringFx) {
					// Entering element transition end callback
					enteringTransFn = function(){
						// WA for Webkit: The handler kept firing after removing the element 
						// from the DOM (only when BODY is replaced). This way, if it's fired
						// more than once, the handler is manually detached.
						if (transStatus >= 2) {
							gx.evt.detach(newEl, enteringFxEventName, enteringTransFn);
							return;
						}
						clearTimeout(enteringTransTimeoutHdlr);
						transStatus++;
						if (options.enteringTransCallback) {
							options.enteringTransCallback(oldEl, newEl);
						}
						transitionEndFn();
					};
					gx.evt.attach(newEl, enteringFxEventName, enteringTransFn, false, { single: true, useCapture: true });
				}
				else {
					transStatus++;
					transitionEndFn();
				}

				gx.lang.requestAnimationFrame(function () {
					gx.dom.addClass(oldEl, leavingClass);
					if (useParallelFx) {
						gx.dom.removeClass(newEl, enteringClass);
						if (useEnteringFx) {
							enteringTransTimeoutHdlr = setTimeout(enteringTransFn, transitionTimeout);
						}
					}

					// A timeout is setup in case the transition doesn't work
					if (useLeavingFx) {
						leavingTransTimeoutHdlr = setTimeout(leavingTransFn, transitionTimeout);
					}
				});
			};

			if (options.beforeTransitionStart) {
				// If options.beforeTransitionStart returns true, it means it executed applyTransFn (thus applying the transition)
				// so it is not called.
				if (options.beforeTransitionStart(applyTransFn) !== true) {
					applyTransFn();
				}
			}
			else {
				applyTransFn();
			}
		}
		else {
			if (options.domRemove !== false) {
				parentNode.removeChild(oldEl);
			}
			if (options.domAdd !== false) {
				if (oldEl.parentNode == parentNode) {
					parentNode.replaceChild(newEl, oldEl);
				}
				else {
					parentNode.appendChild(newEl);
				}
			}

			if (options.beforeTransitionStart) {
				options.beforeTransitionStart();
			}
			
			if (options.leavingTransCallback) {
				options.leavingTransCallback(oldEl, newEl);
			}
			
			if (options.enteringTransCallback) {
				options.enteringTransCallback(oldEl, newEl);
			}
			
			if (options.transitionEndCallback) {
				newEl = options.transitionEndCallback(oldEl, newEl);
			}
			
		}
	},
	
	getDocTypeDeclaration: function(doc) {
		doc = doc || document;
		var doctype = doc.doctype;
			parts = ["!DOCTYPE"];

		if (!doctype) {
			return "";
		}

		parts.push(doctype.name || "html");
		if (doctype.publicId) {
			parts.push('PUBLIC');
			parts.push('"' + doctype.publicId + '"');
		}
		if (doctype.systemId) {
			parts.push('"' + doctype.systemId + '"');
		}
		
		return "<" + parts.join(" ") + ">";
	},

	createShadowRoot: function (el) {
		el = this.el(el);
		if (el.createShadowRoot) {
			return el.createShadowRoot();
		}
		else if (el.webkitCreateShadowRoot) {
			return el.webkitCreateShadowRoot();
		}
		
		return false;
	},

	fixes: (function () {
		var DOM_FIXES_STYLE_ID = "gx-dom-fixes",
			TABLE_PADDING_CLASS_PREFIX = "gx-tab-padding-fix-",
			TABLE_SPACING_CLASS_PREFIX = "gx-tab-spacing-fix-",
			TABLE_PADDING_CLASS_REGEX = new RegExp(TABLE_PADDING_CLASS_PREFIX + "\\d+", "ig"),
			TABLE_SPACING_CLASS_REGEX = new RegExp(TABLE_SPACING_CLASS_PREFIX + "\\d+", "ig");

		var allCellPaddings = {},
			allCellSpacings = {},
			cellPaddingsTemplate,
			cellSpacingsTemplate;

		var alignmentTemplate,
			alignmentProperties = {
				"center": {
					marginLeft: 'auto',
					marginRight: 'auto',
					className: "gx-center-align",
					alignment: "center"
				},
				"right": {
					marginLeft: 'auto',
					marginRight: 0,
					className: "gx-right-align",
					alignment: "right"
				},
				"left": {
					marginLeft: 0,
					marginRight: 'auto',
					className: "gx-left-align",
					alignment: "left"
				}
			};

		return {
			resetFixesStyleElement: function () {
				allCellPaddings = {};
				allCellSpacings = {};
				$("#" + DOM_FIXES_STYLE_ID).empty();
			},

			getFixesStyleElement: function () {
				var styleEl = $("#" + DOM_FIXES_STYLE_ID)[0],
					themeEl;
				if (!styleEl) {
					styleEl = document.createElement("style");
					styleEl.id = DOM_FIXES_STYLE_ID;
					themeEl = gx.getThemeElement();
					$('head')[0].insertBefore(styleEl, themeEl);
					if (gx.util.browser.isIE()) {
						$(themeEl).insertAfter(styleEl);
					}
				}
				return styleEl;
			},

			html5: function (root) {
				var browser = gx.util.browser,
					isIE = browser.isIE(),
					i,
					styleBuffer = [],
					styleEl;

				$("TABLE", root || document.body).each(function () {
					var $table = $(this);
					$table.attr({
						"align": $table.data("align")
					})
				});

				if (!root) {
					if (!alignmentTemplate) {
						for (var alignment in alignmentProperties) {
							gx.lang.apply(alignmentProperties[alignment], {
								wcClassName: gx.GxObject.WEBCOMPONENT_CLASS_NAME,
								wcBodyClassName: gx.GxObject.WEBCOMPONENT_BODY_CLASS_NAME,
								contHolderClassName: 'gx-content-placeholder',
								contHolderBodyClassName: 'gx-ct-body',
								elements: [ { el: 'p' }, { el: 'table' }, { el: 'div' }, { el: 'fieldset', last: true } ]
							});
						}

						alignmentTemplate = [
							".{{className}} \{",
								"text-align:{{alignment}};",
							"\}",
							'{{#elements}}',
								".{{className}} > {{el}},",
								".{{className}} > div.{{contHolderClassName}} > div.{{contHolderBodyClassName}} > {{el}}, ",
								".{{className}} > div.{{wcClassName}} > div.{{wcBodyClassName}} > {{el}}{{^last}},{{/last}}",
							'{{/elements}}', 
							'\{',
								"margin-left:{{marginLeft}};",
								"margin-right:{{marginRight}};",
							"\}"
							].join("");
						Mustache.parse(alignmentTemplate);
					}
					for (var alignment in alignmentProperties) {
						styleBuffer.push(Mustache.render(alignmentTemplate, alignmentProperties[alignment]));
					}
					styleEl = this.getFixesStyleElement();
					gx.dom.setStyleElement(styleEl, styleBuffer.join(""), true);
				}

				if (isIE || browser.isOpera()) {
					$("td[data-align]", root || document.body).each(function () {
						var $cell = $(this),
							dataAlign = $cell.attr("data-align").toLowerCase(),
							newClass = alignmentProperties[dataAlign].className,
							classAttr = $cell.attr("class") || "";

						if (classAttr) {
							classAttr = " " + classAttr;
						}

						$cell.attr("align", dataAlign);
						if (!$cell.hasClass(newClass)) {
							$cell.attr("class", newClass + classAttr)
						}
						
						$cell.children("div." + alignmentProperties[dataAlign].contHolderClassName).children('div.' + alignmentProperties[dataAlign].contHolderBodyClassName).addClass(newClass);
						$cell.children("div." + alignmentProperties[dataAlign].wcClassName).children('div.' + alignmentProperties[dataAlign].wcBodyClassName).addClass(newClass);
					});
				}
			},
			
			setPopupMinWidth: function () {						
				var currentPopup = gx.popup.getPopup()
				if (currentPopup) {
					if (gx.runtimeTemplates) {
						var minWidth = this.getPopupMinWidth();														
						$(document.documentElement).css("min-width", gx.dom.addUnits(minWidth));
						$(document.documentElement).addClass('gx-popup-document');
					}
					if (currentPopup.autoresize || currentPopup.autoresize === undefined) {
						$(document.documentElement).css("height", "auto");
					}

				}
			},

			getPopupMinWidth: function () {
				var currentPopup = gx.popup.getPopup(),
					minWidth = SMALL_MIN_SIZE;
				if (currentPopup) {							
					minWidth = currentPopup.width;
					if (currentPopup.autoresize || currentPopup.autoresize === undefined) {
						var SMALL_MIN_SIZE = 600,
							MEDIUM_MIN_SIZE = 800,
							LARGE_MIN_SIZE = 900,
							EXTRA_SMALL_SIZE_DELTA = 20,
							EXTRA_SMALL_BREAK_SIZE = 768,
							SMALL_BREAK_SIZE = 992,
							MEDIUM_BREAK_SIZE = 1200;

						var windowWidth = $(currentPopup.window).width();
						minWidth = MEDIUM_MIN_SIZE;

						if (windowWidth >= MEDIUM_BREAK_SIZE) {
							minWidth = LARGE_MIN_SIZE;
						}
						if (windowWidth >= EXTRA_SMALL_BREAK_SIZE && windowWidth < SMALL_BREAK_SIZE) {
							minWidth = SMALL_MIN_SIZE;
						}
						if (windowWidth < EXTRA_SMALL_BREAK_SIZE) {
							minWidth = windowWidth - EXTRA_SMALL_SIZE_DELTA;
						}								
					}							
				}
				return minWidth;
			},

			fixTableResets: function (root) {
				var newCellPaddings = [],
					newCellSpacings = [],
					styleEl = this.getFixesStyleElement();

				if (!cellPaddingsTemplate) {
					cellPaddingsTemplate = "{{#.}}." + TABLE_PADDING_CLASS_PREFIX + "{{.}}\{padding:{{.}}px\}{{/.}}";
					Mustache.parse(cellPaddingsTemplate);
				}
				if (!cellSpacingsTemplate) {
					cellSpacingsTemplate = "{{#.}}." + TABLE_SPACING_CLASS_PREFIX + "{{.}}\{border-collapse:separate; border-spacing:{{.}}px\}{{/.}}"
					Mustache.parse(cellSpacingsTemplate);
				}

				var $tables = $("table[data-cellpadding], table[data-cellspacing]", root || document.body);
				
				$tables.each(function () {
					var cellPadding = this.getAttribute("data-cellpadding");
					if (cellPadding !== undefined) {
						if (!allCellPaddings[cellPadding]) {
							allCellPaddings[cellPadding] = cellPadding;
							newCellPaddings.push(cellPadding);
						}
						$("tbody > tr > td, tbody > tr > th, tr > td, tr > th", this).each(function () {
							this.className = TABLE_PADDING_CLASS_PREFIX + cellPadding + " " + this.className.replace(TABLE_PADDING_CLASS_REGEX, "");
						});
					}
					var cellSpacing = this.getAttribute("data-cellspacing");
					if (cellSpacing !== undefined) {
						if (!allCellSpacings[cellSpacing]) {
							allCellSpacings[cellSpacing] = cellSpacing;
							newCellSpacings.push(cellSpacing);
						}
						this.className = TABLE_SPACING_CLASS_PREFIX + cellSpacing + " " + this.className.replace(TABLE_SPACING_CLASS_REGEX, "");
					}
				});

				gx.dom.setStyleElement(styleEl, Mustache.render(cellPaddingsTemplate, newCellPaddings) + Mustache.render(cellSpacingsTemplate, newCellSpacings), true);
			},
			
			createLegacyNotification: function () {
				var id = "gx_ajax_notification",
					selector = "div#" + id;
				if (!$(selector).length)
					$('<div id="gx_ajax_notification" style="display:none;"></div>').appendTo(document.body);
			}
		};
	})(),

	_deinit: function () {
		this._form = null;		
		if (this._avoidLeaksDiv != null) {
			if (gx.dom.shouldPurge())
				gx.dom.purge(this._avoidLeaksDiv);
			this._avoidLeaksDiv = null;
		}
		if (window) {
			window.__objs = null;
			window.__funs = null;
			window.__args = null;
		}
	},
	
	element_in_scroll: function(container, elem) {
		var offset = $(elem)[0].offsetTop - $(container)[0].offsetTop  - $(container).scrollTop();
		return (container && $(elem)[0]) ? (offset < $(container).height()) : false;
	}
	}
})(gx.$);

$.extend( gx.dom, gx.dom_i);

gx.evt_i = (function($) {

	return {
	
	eachKeyAutorefreshType: function( type) {
		return !gx.lang.isNumericType(type) && !gx.lang.isDateType(type);
	},


	waitGridRefresh:function( toDoFnc) {
		if ( gx.evt.refreshGridCallback instanceof Array)
			gx.evt.refreshGridCallback.push( toDoFnc)
		else
			toDoFnc.call();
	},

	notifyRefreshGrid:function( ) {
		if ( gx.evt.refreshGridCallback && gx.evt.refreshGridCallback instanceof Array)	{
			while (gx.evt.refreshGridCallback.length > 0) {
				var toDocFnc = gx.evt.refreshGridCallback.pop();
				if (typeof (toDocFnc) == 'function')
					toDocFnc.call();
			}
			gx.evt.refreshGridCallback = undefined;
		}
	},

	clearHooks: function () {
		var len = this.hooks.length;
		for (var i = 0; i < len; i++) {
			var hook = this.hooks[i];
			try {
				this.detach(hook.c, hook.e, hook.f);
				hook.c = null;
				hook.f = null;
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'clearHooks');
			}
			this.hooks[i] = null;
			hook = null;
		}
		this.hooks = [];
	},

	source: function (evt) {
		return (evt.target || evt.currentTarget || evt.srcElement);
	},
	
	createEvent: function( type, bubbles, cancelable, extraData)
	{
		var evt;
		bubbles = (bubbles === undefined) ? true : bubbles;
		cancelable = (cancelable === undefined) ? true : cancelable;
		extraData = extraData || {};
		if (window.CustomEvent) {
			evt = new CustomEvent(type, {bubbles: bubbles, cancelable:cancelable, detail: extraData});
		} 
		else {
			evt = document.createEvent('CustomEvent');
			evt.initCustomEvent(type, bubbles, cancelable, extraData);
		}
		return evt;
	},

	dispatch: function(obj, evt)
	{
		return (obj.dispatchEvent) ? obj.dispatchEvent(evt) : obj.fireEvent("on" + evt.type, evt);
	},
	
	fireEvent: function( obj, type)
	{
		gx.evt.dispatch( obj, gx.evt.createEvent(type));
		
	},

	detach: function (obj, evt, handler, options) {
		try {
			options = options || {};
			if (typeof (evt) == "string") {
				if (obj.removeEventListener) {
					obj.removeEventListener(evt, handler, options.useCapture || false);
				}
				else if (obj.detachEvent) {
					obj.detachEvent('on' + evt, handler);
				}
				else {
					obj['on' + evt] = null;
				}
			}
			else if (gx.lang.isArray(evt)) {
				for (var i = 0, len = evt.length; i < len; i++) {
					this.detach(obj, evt[i], handler, options);
				}
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'detach');
		}
	},


	stopPropagation: function (evt) {
		if (evt) {
			if (evt.stopPropagation) {
				evt.stopPropagation();
			} else {
				evt.cancelBubble = true;
			} 
		}
	},

	cancel: function (evt, cancel) {
		if (cancel && gx.util.browser.isIE() && typeof (evt.keyCode != 'undefined')) {
			try { evt.keyCode = 0; } catch (e) { }
		}
		if (typeof (evt.preventDefault) == 'undefined') {
			evt.cancelBubble = cancel;
			evt.returnValue = !cancel;
		}
		else {
			if (cancel) {
				evt.preventDefault();
				evt.stopPropagation();
			}
		}
	},


	checkCtrlFocus: function (Control) {
		try {
			if (gx.evt.fixWebKitOnFocus() && Control.type == 'button') {
				if (gx.fn.isAccepted(Control)) {
					if (Control.onfocus != undefined) { Control.onfocus(); }
				}
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'checkCtrlFocus');
		}
	},

	doClick: function (ControlId, Event) {
		if (!gx.isInputEnabled())
			return;
		var eventSource = gx.evt.source(Event);
		if (eventSource.type != 'button' && eventSource.type != 'submit') {
			var Control = gx.dom.el(ControlId);
			if (gx.fn.isAccepted(Control)) {
				if (Control.onfocus != undefined) { Control.onfocus(); }
				if (Control.onclick != undefined) { Control.onclick(); }
				if (Control.nodeName == 'INPUT' && Control.type == 'submit') {
					gx.dom.form().submit();
				}
			}
		}
	},

	executeOnblur: function (gxCurrentFocusControlId,  gxCurrentFocusControl) {
		var gxLastFocusCtrl = gx.csv.lastId;
		var gxFocusCtrl = gx.O.focusControl;

		gx.O.focusControl = gxCurrentFocusControlId;
		this.onblur(gxCurrentFocusControl, gx.O.focusControl);

		gx.O.focusControl = gxFocusCtrl;
		gx.csv.lastId = gxLastFocusCtrl;
	},

	onblur: function (Ctrl, gxLastFocusCtrl) {
		if (!gx.O || gx.csv.IgnoreBlur === true)
			return;
		var ctrlRow = gx.fn.controlRowId(Ctrl);
		gx.csv.lastId = gxLastFocusCtrl;
		try {
			var vStruct = gx.fn.validStruct(gxLastFocusCtrl);
			if (vStruct && vStruct.gxgrid != null)
				vStruct.gxgrid.updateControlValue(vStruct, false, ctrlRow);
			var Elem = gx.csv.lastControl;
			if (Elem) {
				var MaxLength = Elem.getAttribute("maxlength");
				if (MaxLength > 0 && Elem.value.length > MaxLength)
					Elem.value = Elem.value.substring(0, MaxLength);
				if (vStruct && vStruct.type == 'bits' && vStruct.ro == 0) {
					var fileInput = gx.fn.getControlGridRef(vStruct.fld, vStruct.gxgrid ? vStruct.gxgrid.gridId : "");
					// WA: Webkit browsers don't set focus on input='file' controls when clicked.
					if (gx.util.browser.isWebkit() && Elem.id.indexOf(vStruct.fld) < 0)
						Elem = fileInput;
					var multimediaCt = gx.html.multimediaUpload.getContainer(fileInput);
					gx.html.multimediaUpload.refreshPreviewImg(multimediaCt, Elem);
				}
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'onblur');
		}
	},

	onfocus: function () {
		var fun = function () {
			var deferred = $.Deferred();
			gx.fx.obs.notify('gx.onbeforefocus', arguments);
			gx.evt.onfocus_impl.apply(gx.evt, arguments).then(function () {
				gx.fx.obs.notify('gx.onafterfocus');
				deferred.resolve();
			});
			return deferred.promise();
		};

		if (gx.evt.is_button_mouse_event === true || gx.fx.delayedValidation) {
			gx.fx.obs.addObserver('gx.validation', this, fun.closure(this, arguments), { single: true, async: true });
		}
		else {
			fun.apply(gx.evt, arguments);
		}
	},

	onfocus_impl: function (Ctrl, gxFocusCtrl, gxWCP, gxInMasterPage, gxCurrentRow, gxCurrentGrid, gxAddLines) {
		var onfocusDeferred = $.Deferred();
		if (gx.csv.deferredOnchange) {
			gx.lang.doExecTimeout( gx.csv.deferredOnchange);
		}						
		gxCurrentRow = gx.fn.controlRowIndex(Ctrl) || gxCurrentRow;
		try {
			gx.grid.clearActiveGrid();
			if (gx.spa.isNavigating()) {
				return onfocusDeferred.resolve(false).promise();
			}
			gx.evt.setReady(false);
			if (!gx.fn.checkPopupFocus(Ctrl)) {
				gx.evt.setReady(true);
				return onfocusDeferred.resolve(false).promise();
			}
			var NewComponentContext = false;
			if (gx.csv.cmpCtx != gxWCP) {
				NewComponentContext = true;
				gx.O.fromValid = 0;
			}
			gx.setGxO(gxWCP, gxInMasterPage);
			gx.fn.refreshControlOldValue( Ctrl);
			if (NewComponentContext)
				gx.fn.changeCmpContext();
			gx.fn.initOld(Ctrl);
			try {
				if (gx.grid.lastFocusCtrl != null) {
					gx.csv.lastId = gx.grid.lastFocusCtrl;
					gx.grid.lastFocusCtrl = null;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'onfocus');
			}
			gx.csv.rowChanged = false;
			gx.csv.lastControl = Ctrl;
			if (gxCurrentGrid == 0 || gxCurrentRow != '') {
				gx.fn.setCurrentGridRow(gxCurrentGrid, gxCurrentRow);
			}
			gx.fx.installSuggest(Ctrl);
			var gridChange = false;
			if (gx.csv.lastGrid != gxCurrentGrid) {
				gx.csv.lastRow[gxCurrentGrid] = null;
				if (!gxAddLines) {
					if (gx.csv.lastGrid < gxCurrentGrid) {
						var firstGridCtrl = gx.fn.firstGridControl(gxCurrentGrid);
						if (gx.O.fromValid > firstGridCtrl)
							gx.O.fromValid = firstGridCtrl;
					}
					gx.csv.lastGrid = gxCurrentGrid;
				}
				gridChange = true;
			}
			if (gxFocusCtrl > 0) {
				gx.O.focusControl = gxFocusCtrl;
			}
			if (!gx.csv.onloadFocus) {
				try { gx.fx.ctx.notify(Ctrl); }
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'onfocus');
				}
			}
			if (gx.csv.disableFocus) {
				gx.csv.disableFocus = false;
				gx.evt.setReady(true);
				return onfocusDeferred.resolve(true).promise();
			}
			try {
				var cMode = gx.fn.getControlValue("Mode");
				if (cMode == 'DLT' || cMode == 'DSP') {
					gx.evt.setReady(true);
					return onfocusDeferred.resolve(true).promise();
				}
				if (gx.O.isTransaction() && gx.dom.isButton(Ctrl) && !gx.evt.isEnterEvtCtrl(Ctrl) && !gx.evt.isCheckEvtCtrl(Ctrl) && !gxAddLines) {
					gx.evt.setReady(true);
					return onfocusDeferred.resolve(true).promise();
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'onfocus');
			}

			if (gx.O.isTransaction()) {
				if (Ctrl.gxdisabled && gx.csv.lastControl != null) {
					cn = gx.fn.getControlIndex(Ctrl) + 1;
					if (cn != -1) {
						NextFocus = gx.fn.searchFocusFwd(cn);
						if (NextFocus != null) {
							gx.fn.setFocus(NextFocus);
							gx.evt.setReady(true);
							return onfocusDeferred.resolve(true).promise();;
						}
					}
					gx.fn.setFocus(gx.csv.lastControl);
					gx.evt.setReady(true);
					return onfocusDeferred.resolve(true).promise();
				}
			}

			if (gx.csv.invalidForcedCtrl) {
				gx.fn.setFocusOnError(gx.csv.invalidForcedCtrl.id)
				gx.csv.invalidForcedCtrl = null;
				gx.evt.setReady(true);
				return onfocusDeferred.resolve(true).promise();
			}
			if (gx.csv.invalidControl != null && gx.csv.invalidControl != Ctrl && gx.O.focusControl >= gx.csv.invalidId) {
				if (gx.csv.invalidControl == Ctrl) {
					gx.csv.validate(gx.csv.invalidControl, gx.csv.invalidId, false, gx.O, gxCurrentRow).done(function (isValid) {
						if (isValid) {
							gx.csv.invalidControl = null;
							gx.evt.setReady(true);
						}
						onfocusDeferred.resolve(true);
					});
					return onfocusDeferred.promise();
				}
			}
			if (gxAddLines) {
				gx.O.fromValid = gx.fn.firstGridControl(gx.csv.lastGrid);
				gx.O.toValid = gx.fn.firstCtrlAfterGrid(gx.O.fromValid, gx.csv.lastGrid);
				gx.O.focusControl = gx.O.toValid;
			}
			else {
				gx.O.toValid = gx.O.focusControl;
				if (gx.O.focusControl < gx.O.fromValid) {
					gx.O.fromValid = gx.O.focusControl;
				}
			}
			if ((gx.csv.lastRow[gxCurrentGrid] != undefined) && (gx.csv.lastRow[gxCurrentGrid] != gxCurrentRow) && !gridChange) {
				//Go to upper or lower row in the same grid
				if (gx.O.fromValid == gx.O.toValid)
					gx.csv.lastId = gx.O.fromValid;
			}
			var allIds = gx.fn.controlIds();
			if (allIds.length > 0) {
				if (gx.O.fromValid < allIds[0])
					gx.O.fromValid = allIds[0];
			}

			if (gx.lang.emptyObject(gx.csv.lastRow[gxCurrentGrid]) && gxCurrentGrid != 0) {
				gx.csv.rowChanged = true;
				gx.csv.lastRow[gxCurrentGrid] = gxCurrentRow;
			}
			var gxO = gx.O,
				lastId = gx.csv.lastId;
			var vStruct = gx.fn.validStruct(lastId, gxO);
			if (vStruct) {
				var lastRow = gx.csv.lastRow[vStruct.grid];
			}
			gx.csv.checkRowChange(lastId, gridChange, gxO, lastRow).done(function (rowValidated) {
				var goForwardInGrids = false;
				var goBackwardInGridRows = false;
				var afterValidateFn = function () {
					if (gx.csv.invalidControl == null) {
							if (Ctrl.nodeName === 'SELECT' || !gx.util.browser.isSafari() || (gx.dom.isTextControl(Ctrl) && Ctrl.selectionEnd === 0)) {
								gx.fn.setSelection(Ctrl);
							}
					}
					gx.csv.disableFocusCondition();
					gx.evt.setReady(true);
					onfocusDeferred.resolve(true);
				};
				
				if (!gx.lang.emptyObject(lastRow) && !gx.lang.emptyObject(gxCurrentRow) && lastRow.length > gxCurrentRow.length) {
					var currRowLen = gxCurrentRow.length;
					var lastRowParent = lastRow.substring((lastRow).length - currRowLen);
					goForwardInGrids = parseInt(lastRowParent) < parseInt(gxCurrentRow);
				}
				if (gx.csv.backwardGridValidation) {
					//Go to an upper row 
					if (!gx.lang.emptyObject(lastRow) && !gx.lang.emptyObject(gxCurrentRow) && lastRow.length == gxCurrentRow.length && parseInt(lastRow) > parseInt(gxCurrentRow)) {
						goBackwardInGridRows = gxO.focusControl > gx.fn.firstGridControl(gxCurrentGrid);
					}
					//Go to a lower row AND ControlId is lower than lastId
					if (!gx.lang.emptyObject(lastRow) && !gx.lang.emptyObject(gxCurrentRow) && lastRow.length == gxCurrentRow.length && parseInt(lastRow) < parseInt(gxCurrentRow)) {
						goBackwardInGridRows = (gxO.focusControl < lastId) && (gxO.focusControl > gx.fn.firstGridControl(gxCurrentGrid));
					}
				}

				if (rowValidated && gx.csv.invalidControl == null && goBackwardInGridRows) {
					gxO.fromValid = gx.fn.firstGridControl(gxCurrentGrid);
					gx.csv.validControls(gxO.fromValid, gxO.focusControl, true, gx.O);
				}
				else if ((!rowValidated || gridChange) && (gxO.focusControl >= lastId || goForwardInGrids)) {
					if (gx.fn.lastMainLevelCtrlId(lastId, gxCurrentGrid)) {
						var lastIdCtrl = gx.fn.getControlRefById(lastId)
						if (lastIdCtrl && lastIdCtrl.getAttribute(gx.csv.GX_VALID_ATTRIBUTE) === 1)
							gxO.fromValid = lastId + 1;
					}
					gx.csv.validateAll(gxO).done(afterValidateFn);
				}
				else {
					gxO.toValid = gxO.focusControl;
					afterValidateFn();
				}
			});
			if (gxCurrentGrid && gxCurrentRow) {
				var grid = gx.O.getGridById(gxCurrentGrid, gxCurrentRow);
				if (grid && grid.allowSelection) {
					grid.setSelection(parseInt(gxCurrentRow, 10) - 1);
				}
			}
			return onfocusDeferred.promise();
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'onfocus');
		}
		return onfocusDeferred.resolve(false).promise();
	},

	userOnload: function () {
		try {
			if (typeof (window['GXOnloadUsr']) == 'function') {
				GXOnloadUsr();
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'userOnload');
		}
	},

	onload: function () {
		gx.objectLoad().done( function () {
			gx.spa.start({
				listeners: {
					'onnavigatestart': function () {
						gx.dom.addClass(document.body, 'gx-spa-navigating');
					},
					'onnavigate': function () {
						gx.dom.removeClass(document.body, 'gx-spa-navigating');
					},
					'onbeforesend': function (eventObject, spaRequestHeader, mpRequestHeader) {
						if (gx.pO.MasterPage)
							eventObject.req.setRequestHeader(mpRequestHeader, gx.pO.MasterPage.ServerClass);
					},
					'onbeforeprocessresponse': function (eventObject, responseText, gxObjectClass, sourceMpClass, targetMpClass, sameMp) {
						gx.reinit(!sameMp);
					},
					'oncontentreplace': function (eventObject, responseText, contents, objectName, sourceMpObj, sourceMpName, targetMpName, sameMp) {
						var objectClass = gx.lang.getType(objectName),
							mpName = (sourceMpName == targetMpName ? sourceMpName : targetMpName),
							mpClass = mpName ? gx.lang.getType(mpName.toLowerCase()) : false,
							jsonResponse = gx.ajax.getJsonResponse();

						if (jsonResponse)
							gx.fn.setJsonHiddens(null, jsonResponse.gxHiddens, false);
						objectClass.prototype = new gx.GxObject;
						gx.setParentObj(new objectClass());
						if (sameMp) {
							gx.setMasterPage(sourceMpObj);
						}
						else {
							if (mpClass)
								gx.setMasterPage(new mpClass());
						}

						gx.ajax.clearJsonResponse();
						if (jsonResponse) {
							gx.ajax.setJsonResponse({ 
								response: jsonResponse, 
								isPostBack: false, 
								afterCmpLoaded: function () {
									if (sameMp) {
										sourceMpObj.restoreTargetComponents();
										sourceMpObj.restoreExoEventHandlers();
									}
									gx.objectLoad(jsonResponse.gxGrids, jsonResponse.gxHiddens).done(function() {
										gx.pO.SetStandaloneVars();
									});
								}, 
								gxObject: gx.O
							});
						}
						else {
							gx.objectLoad();
						}
					}
				}
			});
			gx.livePrevWS._init();
		});
	},

	onunload: function (unloadMasterPage) {
		gx.objectUnload(unloadMasterPage);
		gx.spa.stop();
	},

	onclick: function (evt) {
		var onClickEventObject = { event: evt };
		gx.fx.obs.notify("gx.onclick", [onClickEventObject]);
		if (onClickEventObject.cancel) {
			return;
		}
		gx.evt.setReady(false);
		if (!gx.isInputEnabled(evt)) {
			gx.evt.cancel(evt, true);
		}
		gx.evt.mouse.update(evt);
		setTimeout(function () {
			gx.fx.ctx.notify();
		}, 10);
		gx.evt.setReady(true);
	},
	
	ontouchstart: function (evt) {
		var mousedown = gx.evt.onmousedown.closure(this, [evt]);
		if (gx.dom.documentScrollable().x || gx.dom.documentScrollable().y) {					
			gx.evt.touchTimer = window.setTimeout(mousedown, 150);
		}
		else {
			mousedown();			
		}
	},
	
	onmousedown: function (evt) {
		var evtObj = window.event || evt,
			sourceEl = gx.evt.source(evtObj);

		if (sourceEl && gx.util.browser.ieVersion() <= 8 && $(sourceEl).is('shape')) {
			return false;
		}

		gx.evt.is_button_mouse_event = gx.dom.isButtonLike(sourceEl);
		gx.evt.mouse.update(evt);
		var dnd = gx.fx.dnd;
		dnd.deleteClonControl();
		var dragSource = dnd.getSource(evtObj);
		if (!gx.dom.isMaskElement(evtObj.target) && dragSource != null) {
			gx.evt.cancel(evtObj, true);
			gx.setGxO(dragSource.obj);
			dnd.drag(dragSource.obj, dragSource.types, dragSource.hdl);
		}
	},

	onmousemove: function (evt) {
		gx.evt.mouse.update(evt);
		var dnd = gx.fx.dnd;
		var isIE = gx.util.browser.isIE();
		if (gx.popup.ispopup() && gx.popup.ext.compatMode()) {
			var pExt = gx.popup.ext;
			pExt.movepopup();
			if ((pExt.currIDb != null) || (pExt.currRS != null)) {
				return false;
			}
		}
		if (dnd.obj != null) {
			var evtObj = window.event || evt;
			gx.evt.cancel(evtObj, true);
			var dropTarget = gx.fx.dnd.getTarget(evtObj, dnd.obj.gxDragTypes);
			if (dropTarget != null)
				dnd.over();
			dnd.moveControl(dnd.dragCtrl);
		}
	},

	onmouseup: function (evt) {
		window.clearTimeout(gx.evt.touchTimer);
		gx.evt.is_button_mouse_event = false;
		gx.evt.mouse.update(evt);
		var dnd = gx.fx.dnd;
		if (dnd.dragCtrl != null) {
			var evtObj = window.event || evt;
			var dropTarget = dnd.getTarget(evtObj, dnd.obj.gxDragTypes);
			if (dropTarget != null) {
				dnd.deleteClonControl();
				gx.setGxO(dropTarget.obj);
				dnd.drop(dnd.dropCtrl, dropTarget.obj, dropTarget.hdl);
			}
			else {
				dnd.restoreControl();
			}
			var evtObj = window.event || evt;
			gx.evt.cancel(evtObj, true);
		}
		dnd.out();
		dnd.dragCtrl = null;
		dnd.obj = null;
		if (gx.popup.ispopup()) {
			gx.popup.ext.currRS = null;
		}
	},

	ondblclick: function (evt) {
		gx.evt.mouse.update(evt);
		var evtObj = window.event || evt;
		if (gx.util.browser.isOldIE() || !gx.fx.dom.delayedDispatch(evt)) {
			gx.fx.dom.raiseEvent('dblclick', evtObj);
		}
	},

	onwindowblur: function (evt) {
		gx.fx.dnd.deleteClonControl();
	},

	checkMaxLength: function (Ctrl, MaxLength, event) {
		var Evt = window.event || event,
			isIE = gx.util.browser.isIE(),
			keyCode = Evt.keyCode;
		if (isIE) {
			if (Evt.type == "keydown" && keyCode == 229) {
				if (Ctrl.value.length <= MaxLength) {
					Ctrl.ImeKey = true;
					return true;
				} else {
					return false;
				}
			}
			else if (Evt.type == "keyup" && keyCode == 8 && Ctrl.ImeKey && Ctrl.value.length + 1 >= MaxLength) {
				Ctrl.value = Ctrl.value.substring(0, Ctrl.value.length - 1);
				Ctrl.ImeKey = false;
				return true;
			}
		}
		if (Evt.type == "keyup" || isIE) {
			return (Ctrl.value.length + 1 <= MaxLength) || (keyCode == 8 || keyCode == 9 || keyCode == 46 || (keyCode >= 35 && keyCode <= 40));
		}
	},

	fireControlValueChange: function(gxO, Ctrl, evt) {
		var deferred = $.Deferred();
		if (!gxO || !Ctrl) {
			//This should be an error..
			return deferred.resolve();
		}
		var vStruct = gxO.getValidStructFld(Ctrl);
		if (vStruct && vStruct.evt_cvc) {
			gx.evt.startValidation(vStruct.gxgrid);
			gx.evt.stopPropagation(evt);
			return gxO[vStruct.evt_cvc].call(gxO).always( function () {
				gx.evt.endValidation(vStruct.gxGrid, gx.evt.types.VALUECHANGED);
			});
		}
		return $.Deferred().resolve();
	},

	fireControlValueChanging: function(gxO, Ctrl) {
		var deferred = $.Deferred();
		if (!gxO || !Ctrl) {
			//This should be an error..
			return deferred.resolve();
		}
		var vStruct = gxO.getValidStructFld(Ctrl);
		if (vStruct) {
			var isFreestyleCtrl = vStruct.gxgrid && vStruct.gxgrid.isFreestyle;
			var evt_cvcing = vStruct.evt_cvcing && !vStruct.gxsgprm;  //Not supported when Suggest is ON.
			if (evt_cvcing)
				gx.evt.startValidation(vStruct.gxgrid);	
			if (evt_cvcing || isFreestyleCtrl) {
				if (typeof(vStruct.c2v) == 'function')
					vStruct.c2v();
				if (typeof(vStruct.v2bc) == 'function')
					vStruct.v2bc.call(gxO);
			}
			if (evt_cvcing) {
				return gxO[vStruct.evt_cvcing].call(gxO).always(function () {
					gx.evt.endValidation(vStruct.gxGrid, gx.evt.types.VALUECHANGING);
				});
			}
		}
		return deferred.resolve();
	},

	oncontrolvaluechanging: function (event) {
		var iKeyCode = event.keyCode;
		if (iKeyCode != 8 && iKeyCode < 32 || (iKeyCode >= 33 && iKeyCode < 46) || (iKeyCode >= 112 && iKeyCode <= 123)) {
			return;
		}
		var Ctrl = gx.evt.source(event);
		if (!Ctrl)
			return;

		gx.evt.fireControlValueChanging(gx.O, Ctrl);
	},

	onkeypress: function (event, hasenter, skiponenter) {		
		event = event || window.event;
		if (!event)
			return;
		
		var isEnterKey = event.keyCode === 13;
		if (event.keyCode === 27) //ESC
		{
			if (gx.evt.shouldIgnoreEscKey()) {
				gx.evt.cancel(event, true);
			}
		}

		var fn = gx.fn, 
			browser = gx.util.browser,
			eventObject = {
				event: event,
				hasEnter: hasenter,
				skipOnEnter: skiponenter,
				cancel: false
			};

		if (event.keyCode === 27) //ESC
		{
			if (gx.popup.ispopup()) {
				fn.cancelWindow();
				return;
			}
		}

		gx.fx.obs.notify("gx.keypress", [eventObject]);
		if (eventObject.cancel) {
			return;
		}

		if (isEnterKey && !gx.isInputEnabled()) {
			this.cancel(event, true);
		}
		if (!gx.O || (gx.O.isTransaction() && gx.O.Gx_mode == 'DSP' && this.invalidDSPKey(event))) {
			this.cancel(event, true);
			return false;
		}

		this.lastKey = event.keyCode;
		this.shiftPressed = event.shiftKey;
		var ctrlPressed = event.ctrlKey;

		var Ctrl = gx.evt.source(event) || gx.dom.getActiveElement() || gx.csv.lastControl;

		if (!gx.evt.validKeypressForCtrl(Ctrl, event)) {
			this.cancel(event, true);
		}
		
		if (event.keyCode !== 9) //Tab key should not invalidate ctrl.
			gx.csv.invalidateCtrl(Ctrl, event);

		if (this.isEnterEvtCtrl(Ctrl) && this.isTriggerKey(event)) {
			if (this.cancelAndRefresh(event))
				return;
		}

		this.checkFuncKey(event, Ctrl);

		if (event.charCode == 32 || event.keyCode == 32 || (isEnterKey && !skiponenter)) {
			if (gx.dom.hasClass(Ctrl, 'gx_newrow')) {
				$(Ctrl).find('span').trigger('click');
			}
		}

		if ((!isEnterKey || !skiponenter) && gx.grid.handleKeyPressEvt(event))
			return;

		switch (event.keyCode) {											
		case 13: //enter
			var triggersEvt = this.triggersEvt(Ctrl);
			if (skiponenter) {
				if (fn.enterHasFocus())
					return;
				if (this.shiftPressed && Ctrl.nodeName === 'TEXTAREA')
					return;
				if (ctrlPressed && Ctrl.nodeName === 'TEXTAREA') {
					gx.dom.replaceAtCaretPosition(Ctrl, '\n');
					this.cancel(event, true); //some browsers  (ff, ie) fire this event twice.
					return;
				}
				else {
					if (browser.isIE() && Ctrl.type != 'file') {
						if (gx.evt.isEnterEvtCtrl(Ctrl)) {
							gx.O.executeEnterEvent(event, Ctrl);
						}
						this.lastKey = 9;
						event.keyCode = this.lastKey;
						this.cancel(event, true);
						fn.skipFocus(skiponenter, Ctrl);						
					}
					else {
						if (Ctrl.value && browser.isIE() && Ctrl.tagName != 'SELECT') {
							var tmpValue = Ctrl.value;
							Ctrl.value = "";
							Ctrl.value = tmpValue;
						}
						fn.skipFocus(skiponenter);
						this.cancel(event, true);
					}
					this.enter = false;
				}
			}
			else if (!triggersEvt) {
				gx.O.executeEnterEvent(event, Ctrl);
			}
			break;
		}
	},

	onkeyup: function (domevent) {
		var event = window.event ? window.event : domevent;
		var evel = gx.evt.source(event);
		var maxlen = evel.getAttribute("maxlength") || (evel.getAttribute("max") ? evel.getAttribute("max").length : 0);
		var value = typeof (evel.value) == "undefined" ? "" : evel.value;
		if ((evel.type == "" && event.keyCode == 9) || (this.autoSkip && evel.type != "" && !this.isControlKey(this.lastKey) && value.length >= maxlen && maxlen > 0)) {
			if (!this.skipPromptCtrl) {
				return;
			}

			if (gx.dom.isTextWithLink(evel) || gx.dom.isImageWithLink(evel)) {
				var controlId = evel.id || (evel.tagName == 'A' && evel.parentNode ? evel.parentNode.id : "");
				if (controlId) {
					var vStructId = gx.O.getValidStructId(controlId);
					gx.evt.onfocus(evel, vStructId, '', false, '', 0)
				}
				return;
			}
			var ctrlFocuseable = evel.getAttribute('gxfocusable');
			if (ctrlFocuseable != null && ctrlFocuseable == '1') {
				return;
			}
			var el = gx.fn.getControlIndex(gx.csv.invalidControl ? gx.csv.invalidControl : gx.csv.lastControl);
			if (el == -1)
				return true;
			var Control = gx.fn.searchFocus(this.shiftPressed ? el - 1 : el + 1, !this.shiftPressed);
			gx.fn.setFocus(Control);
		}
		gx.grid.handleKeyUpEvt(event);
	},

	shouldIgnoreEscKey: function () {
		var currentPopup = gx.popup.getPopup();
		return gx.evt.processing || (currentPopup && currentPopup.state == 'opening');
	},
	
	validKeypressForCtrl: function(Ctrl, event) {
		var ctrlSelection = function(Ctrl) {
			if (Ctrl.selectionStart !== null && Ctrl.selectionStart !== undefined) {
				return Ctrl.selectionEnd - Ctrl.selectionStart;
			}
			else {
				if (window.getSelection) {
					return window.getSelection().toString().length;
				}
			}
			return undefined;
		}
		var vStruct = gx.O.getValidStructFld(Ctrl);
		if (vStruct) {
			var pic = gx.rtPicture(vStruct, Ctrl),
			LenDec = gx.numericLenDec( pic),
			decimals = LenDec.Decimals,
			integers = LenDec.Integers,
			type = vStruct.type,
			value = Ctrl.value;
			if (type == 'int' || type == 'decimal') {
				if (event.key === 'e') {
					return false;
				}
				var selLen = ctrlSelection( Ctrl);
				if (selLen === undefined) {
					return true;
				}
				if (gx.util.browser.isFirefox() && Ctrl.type == "number" && decimals === 0) {
					//WA Firefox wont return selection for input type=number controls v63.0.3
					if (!Ctrl.gxoninput && Ctrl.max && Ctrl.min ) {
						Ctrl.gxoninput = true;
						var fnc = function(Ctrl) {
							if (Ctrl.max && Ctrl.min ) {
								var nVal = Number(Ctrl.value);
								if (( nVal > Ctrl.max ) || (nVal < Ctrl.min )) {
									Ctrl.value = Ctrl.value.substr(0,Ctrl.max.length);
								}
							}
						};
						gx.evt.attach( Ctrl, "input", fnc.closure(this,[Ctrl]));
					}
				}
				else
				{
					if (!isNaN(Number(event.key))) {
						digits = value.split("").filter(function(c){ return c>='0' && c<='9'}).length;							
						value = gx.num.normalize_decimal_sep(pic, gx.thousandSeparator, gx.decimalPoint, value);
						picinputs = integers + (value.indexOf(gx.decimalPoint) == -1 ? 0 : decimals);
						return ((digits - selLen) < picinputs);
					}	
				}	
			}
		}
		return true;
	},						

	setEventRow: function (GxObj, Control) {
		var ctrlGrid = gx.fn.rowGridId(Control);
		var ctrlRow = ctrlGrid && (gx.fn.controlRowId(Control) || gx.fn.currentGridRowImpl(ctrlGrid) || '0001');
		if (ctrlGrid && ctrlRow) {
			if (Control.gxGridName != undefined) {
				gx.fn.setHidden(GxObj.CmpContext + Control.gxGridName.toUpperCase() + "_ROW", ctrlRow);
			}
			gx.evt.setCurrentGridRows(ctrlGrid, ctrlRow);
		}
		gx.csv.lastEvtRow = ctrlRow;
	},

	ctrlOnchange: function (Mode, IsConfirmed, IsKey, Button, sIdiom) {
		gx.csv.pkDirty = IsKey;
		if (Mode.value == "UPD") {
			if (IsConfirmed.value == "1") {
				if (IsKey) {
					if (Button != null)
						Button.value = gx.getMessage("GXM_captionadd");
				}
				else {
					if (Button != null)
						Button.value = gx.getMessage("GXM_captionupdate");
				}
				IsConfirmed.value = "0";
			}
			else {
				if (IsKey) {
					if (Button != null)
						Button.value = gx.getMessage("GXM_captionadd");
				}
			}
		}
		else if (Mode.value == "INS") {
			if (IsConfirmed.value == "1") {
				if (Button != null)
					Button.value = gx.getMessage("GXM_captionadd");
				IsConfirmed.value = "0";
			}
		}
	},

	onchange: function () {
		var fun = function () {
			return gx.evt.onchange_impl.apply(gx.evt, arguments);
		}
		if (gx.fx.delayedValidation)
			gx.fx.obs.addObserver('gx.validation', this, fun.closure(this, arguments), { single: true, async: true });
		else
			fun.apply(gx.evt, arguments);
	},

	onchange_impl: function(Ctrl, event, preventValid) {
		var onChangeDeferred = $.Deferred();
		gx.evt.setReady(false);
		gx.evt.lastControl = Ctrl;
		var CtrlValue = gx.fn.getControlValue(Ctrl.type == "radio" ? Ctrl.name : gx.dom.id(Ctrl));

		var fixWebKitOnfocus = (gx.evt.fixWebKitOnFocus() && Ctrl.type === "radio");
		if (fixWebKitOnfocus) {
			//WebKit Radio buttons don't receive focus event: https://bugs.webkit.org/show_bug.cgi?id=92029
			Ctrl.onfocus();
		}
		var vStruct = gx.O.getValidStructFld(Ctrl);
		var changed = false;
		var finallyCallback = function() {
			delete gx.fx.delayedValidation;
			gx.evt.setReady(true);

			var fireOnblur = (gx.util.browser.isWebkit() && (Ctrl.type == "radio" || Ctrl.type == "checkbox" || Ctrl.type == "file"));
			var doValidControls = false;

			if (changed && vStruct && (gx.fn.lastMainLevelCtrlId(gx.O.focusControl, vStruct.grid) || vStruct.gxsgprm)) {
				fireOnblur = true;
				doValidControls = true;
			}
			if (preventValid) {
				doValidControls = false;
			}

			if (fireOnblur && Ctrl.onblur) {
				Ctrl.onblur();
			}

			var endCallback = function () {
				gx.evt.execUsrOnchange(Ctrl);
				gx.fx.obs.notify('gx.validation');
				onChangeDeferred.resolve();
			};

			if (doValidControls && (typeof(Ctrl.GXFormatError) == 'undefined' || Ctrl.GXFormatError == false)) {//doValidControls solo si onblur valida ok
				gx.csv.validControls(gx.O.focusControl, gx.O.focusControl + 1, true, gx.O).then(endCallback);
			}
			else {
				endCallback();
			}
		};

		if (gx.csv.controlValueHasChanged(Ctrl, CtrlValue, vStruct)) {
			changed = true;
			gx.fn.setControlValue("IsModified", "1");
			gx.fn.setControlValue("IsConfirmed", "0");
			gx.csv.invalidateGXCtrl(Ctrl);
			var jsCode = '',
				execOnChange = true,
				gxO = gx.O;
			if (vStruct) {
				if (typeof(vStruct.c2v) == 'function')
					vStruct.c2v();
				if (typeof(vStruct.v2bc) == 'function')
					vStruct.v2bc.call(gx.O);
			}
			if (!preventValid) {
				gx.fn.setControlOldValue(Ctrl, CtrlValue);
			}
			var validationCallback = function() {
				var deferred = $.Deferred();
				if (Ctrl.type == "select-one" || Ctrl.type == "checkbox" || Ctrl.type == "radio") {
					execOnChange = false;
					gx.evt.setReady(false);
					var ctrlRow = (vStruct) ? gx.fn.currentGridRowImpl(vStruct.grid) : null;
					gx.csv.validate(Ctrl, vStruct.id || gx.O.focusControl, true, gx.O, ctrlRow).done(function(isValid) {
						if (isValid) {
							if (gx.csv.invalidControl == Ctrl) {
								gx.csv.invalidControl = null;
							}
						}
						gx.evt.execOnchange(Ctrl, isValid);
						gx.evt.setReady(true);
						deferred.resolve();
					}).fail(function() {
						gx.evt.setReady(true);
						deferred.resolve();
					});
				}			
				if (execOnChange) {
					gx.evt.execOnchange(Ctrl, false);
					deferred.resolve();
				}
				return deferred.promise();
			};
			var doAll = function() {
				validationCallback
					.call(this)
					.then(finallyCallback.closure(this));
			};
			var atExitFnc = doAll.closure(this);
			gx.csv.deferredOnchange = gx.lang.doCallTimeout( function () {
					delete gx.csv.deferredOnchange;
					gx.evt.fireControlValueChange(gxO, Ctrl, event).always(atExitFnc);
				}, 
				this, [], 100);
		} else {
			finallyCallback.call(this);
		}
		return onChangeDeferred.promise();
	},

	execOnchange: function (Ctrl, validated, notModified) {
		var jsCode = '';
		if (Ctrl.attributes["data-gxoch1"]) {
			try { jsCode += Ctrl.attributes["data-gxoch1"].value + ';'; }
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'execOnchange');
			}
		}
		if (gx.fn.isAccepted(Ctrl) && Ctrl.attributes["data-gxoch2"]) {
			try { jsCode += Ctrl.attributes["data-gxoch2"].value + ';'; }
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'execOnchange');
			}
		}
		try {
			if (jsCode != '')
				eval(jsCode);
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxapi.js', 'execOnchange');
		}
		if (!validated)
			gx.fn.setControlGxValid(Ctrl, "0");
		if (!notModified) {
			Ctrl.setAttribute("gxctrlchanged", '1');
			gx.fn.setControlValue("IsModified", "1");
		}
		if ( notModified !== true) {
			gx.fn.setControlValue("IsConfirmed", "0");
		}
	},

	execUsrOnchange: function (Ctrl) {
		var jsCode = '';
		try { jsCode = Ctrl.attributes["data-gxoch0"].value; }
		catch (e) {
			return true;
		}
		var fnc = new Function(jsCode);
		var ret = fnc.call(Ctrl);
		return ret;
	},

	jsEvent: function (ctrl) {
		if (!gx.isInputEnabled())
			return false;
		var evtCode = ctrl.getAttribute ? (ctrl.getAttribute('data-jsevent') || ctrl.getAttribute('jsevent')) : ctrl.jsevent;
		if (!gx.lang.emptyObject(evtCode)) {
			return eval(evtCode);
		}
		return true;
	},

	isEnterEvtCtrl: function (ctrl) {
		if (gx.O.EnterCtrl) {
			var ctrlName = gx.dom.id(ctrl);
			if (!ctrlName && ctrl.tagName == 'A')
				ctrlName = ctrl.parentNode.id;
			if (ctrlName && ctrlName.indexOf('span_') == 0)
				ctrlName = ctrlName.substring(5);

			if (!ctrlName)
				return false;

			var enterCtrls = gx.O.EnterCtrl,
				gridId = gx.fn.rowGridId(ctrl);
			for (var i = 0, len = enterCtrls.length; i < len; i++) {
				var enterCt = gx.csv.ctxControlId(enterCtrls[i]);
				// If the control is inside a grid, consider the row number for matching
				// gx.fn.currentGridRow is not used because the current row is set when a control with onfocus event
				// is focused, and sometimes no control inside a grid has this event.
				if (gridId && ctrlName.search(new RegExp(".*" + enterCt + "_[0-9]{4}$")) != -1)
					return true;
				if (enterCt == ctrlName)
					return true;
			}
		}
		return false;
	},

	isCheckEvtCtrl: function (ctrl) {
		if (!gx.lang.emptyObject(gx.O.CheckCtrl)) {
			var ctrlName = gx.dom.id(ctrl);
			for (var c in gx.O.CheckCtrl) {
				if (gx.O.CheckCtrl[c] == ctrlName)
					return true;
				if ((gx.O.CmpContext + gx.O.CheckCtrl[c]) == ctrlName)
					return true;
			}
		}
		return false;
	},

	isTriggerKey: function (event) {
		var len = this.triggerKeys.length;
		for (var i = 0; i < len; i++) {
			if ((event.keyCode == this.triggerKeys[i]) || (event.charCode == this.triggerKeys[i]))
				return true;
		}
		return false;
	},

	isControlKey: function (key) {
		var len = this.controlKeys.length;
		for (var i = 0; i < len; i++) {
			if (key == this.controlKeys[i])
				return true;
		}
		return false;
	},

	invalidDSPKey: function (evt) {
		var fKey = evt.keyCode - 111;
		if (evt.shiftKey)
			fKey += 12;
		if (this.keyListeners[fKey] && this.keyListeners[fKey][gx.O.CmpContext] == 'ENTER')
			return true;
		if (evt.keyCode == 13)
			return true;
		return false;
	},

	addKeyListener: function (cmpCtx, key, evt) {
		if (key == 1)
			document.body.onhelp = gx.falseFn
		if (this.keyListeners[key] == undefined)
			this.keyListeners[key] = [];
		this.keyListeners[key][cmpCtx] = evt;
	},

	setEvtName: function (evt, ctrl) {
		gx.fn.setHidden("_EventName", evt);
	},

	cancelAndRefresh: function (evt) { //Will execute async refresh. 
		var gxO = gx.O;
		if (gxO && gxO.conditionsChanged) {
			this.cancel(evt, true);
			if (!gxO.autoRefresh)
				this.resetGridsPagingVarsIfConditionsChanged(gxO.Grids || []);
			if (!gxO.autoRefresh && !gxO.hasEnterEvent && !gxO.anyGridBaseTable) //No Enter Event & No autorefresh & any grid without base table.
				return false;
			else
				gxO.executeServerEvent('RFR', false);
			return true;
		}
		return false;
	},

	resetGridsPagingVarsIfConditionsChanged: function (Grids) {
		var changed = false;
		$.each( Grids, function( i, cgrid) {
			if (cgrid.conditionsChanged && cgrid.conditionsChanged()) {
				cgrid.setPagingVars(0, 0);
				changed = true;
			}
		});
		return changed;
	},

	setGridEvt: function (gridId, rowId) {
		if (!gx.isInputEnabled())
			return;
		if (!gx.lang.emptyObject(gridId)) {
			if (gx.lang.emptyObject(rowId)) {
				var gridObj = gx.fn.getGridObj(gridId);
				if (gridObj) {
					rowId = gx.fn.getHidden(gx.O.CmpContext + gridObj.gridName.toUpperCase() + "_ROW");
				}
			}
			gx.fn.setHidden("_EventGridId", gridId);
			gx.fn.setHidden("_EventRowId", rowId);
			if (rowId) {
				gx.fn.setCurrentGridRow(gridId, rowId);
			}
		}
	},

	checkFuncKey: function (evt, el) {
		var fKey = this.lastKey - 111;
		if (evt.shiftKey) {
			fKey += 12;
		}
		if (fKey > 0 && fKey <= 24 && (this.keyListeners[fKey] != undefined)) {
			var gxEvent = this.keyListeners[fKey][gx.O.CmpContext];
			if (typeof (gxEvent) != 'undefined') {
				this.execFnKeyEvt(evt, gx.O, gxEvent, el);
			}
			else {
				for (var cmpCtx in this.keyListeners[fKey]) {
					gxEvent = this.keyListeners[fKey][cmpCtx];
					if (typeof (gxEvent) != 'undefined') {
						var gxObj = gx.getObj(cmpCtx, false);
						if (gxObj != null) {
							this.execFnKeyEvt(evt, gxObj, gxEvent, el);
							break;
						}
					}
				}
			}
		}
	},

	execFnKeyEvt: function (evt, gxObj, gxEvent, el) {
		if (gx.evt.processing || gx.spa.isNavigating())
			return;
		this.cancel(evt, true);
		if (gxEvent == "PROMPT") {
			var vStruct = gxObj.getValidStructFld(el);
			if (vStruct && vStruct.attachedCtrls) {
				var attCtrls = vStruct.attachedCtrls;
				for (var i = 0, len = attCtrls.length; i < len; i++) {
					var ctrl = attCtrls[i];
					if (ctrl && ctrl.info && ctrl.info.isPrompt) {
						var ctrlId = attCtrls[i].id;
						if (typeof (gxObj.promptKeyHandlers[ctrlId]) == 'function') {
							var rowId = (vStruct.grid > 0) ? "_" + gx.fn.currentGridRowImpl(vStruct.grid) : "";
							var el = gx.dom.el(gxObj.CmpContext + ctrlId + rowId);
							gxObj.promptKeyHandlers[ctrlId].call(gxObj, el);
						}
					}
				}
			}
		}
		else if (gxObj.isTransaction() && gxEvent == 'SELECT') {
			var selectBtn = gx.dom.byId(gxObj.CmpContext + "BTN_SELECT");
			if (selectBtn && typeof (selectBtn.click) == 'function') {
				selectBtn.click();
			}
		}
		else {
			gxObj.executeEvent(gxEvent, false);	
		}
	},

	keyModifiesValue: function (evt) {
		var keyCode = (window.event) ? evt.keyCode : evt.which;
		if ((keyCode>= 32 && keyCode <= 127) || keyCode == 229) {
			return true;
		}
		return false;
	},

	triggersEvt: function (ctrl) {
		if (!gx.lang.emptyObject(ctrl)) {
			if (ctrl == gx.evt.dummyCtrl)
				return true;
			var triggersEvtNodes = gx.config.evt.triggersEvtNodes || {};
			if (ctrl.nodeName === 'A' || ctrl.nodeName === 'TEXTAREA' || triggersEvtNodes[ctrl.nodeName])
				return true;
			else if (ctrl.nodeName === 'INPUT') {
				if (ctrl.type === 'button' || ctrl.type === 'image')
					return true;
			}
			else if (ctrl.tagName === 'IMG' && gx.dom.hasAttribute(ctrl, gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR)) {
				return true;
			}
		}
		return false;
	},

	setProcessing: function (value, cond) {
		if ((typeof (cond) == 'undefined') || cond) {
			if (!gx.evt.redirecting) {
				gx.evt.processing = value;
				gx.evt.setReady(!gx.evt.processing);
				if (!gx.evt.processing) {
					gx.fx.obs.notify('gx.endprocessing');
				}
			}
		}
	},
	
	startValidation: function(gxgrid, force) {
		if (gxgrid || force) {
			gx.csv.validatingGrid = gxgrid;
			gx.csv.validating = true;
		}
	},

	endValidation: function (gxgrid, validKind) {
		if (!gxgrid || gxgrid === gx.csv.validatingGrid){
			gx.csv.validatingGrid = null;
			gx.csv.validating = false;
			//if (!skipNotify)
			gx.fx.obs.notify('gx.onaftervalidate', [validKind]);
		}
	},

	setReady: function (isReady) {
		gx.evt.userReadyCnt += isReady ? -1 : 1;
		gx.evt.userReadyCnt = (gx.evt.userReadyCnt < 0) ? 0 : gx.evt.userReadyCnt;
		gx.evt.userReady = (gx.evt.userReadyCnt == 0);
		if (isNaN(gx.evt.userReadyCnt))
			gx.evt.userReadyCnt = 0;
	},

	EVT_ROW_ID_REGEXP: /\.(([0-9]{4})+)$/,
	
	setCurrentGridRows: function( GridId, rowId) {
		while (GridId > 0 && rowId && rowId.length && rowId.length >= 4) {
			var currRow = rowId.substr( 0, 4);
			var parentRow = rowId.substr( 4);
			gx.fn.setCurrentGridRow(GridId, currRow);
			var gridObj = gx.O.getGridById(GridId, parentRow);
			if (gridObj) {
				gridObj = gridObj.parentGrid;
			}
			GridId = (gridObj) ? gridObj.gridId : 0;
			rowId = rowId.substr( 4, rowId.length);
		}					
	},

	canExecuteEvent: function(evt, force) {
		return !(!force && ((gx.spa.isNavigating() || gx.evt.redirecting) || !gx.csv.validating && (gx.lang.emptyObject(evt) || gx.evt.processing ))); 
	},

	execEvt: function ( cmpCtx, inMaster, evt, ctrl, gridId, sync, srvCommand, disableForm, callback, force, failCallback, enterKeyPressed) {
		gx.dbg.logPerf('execEvt');
		if ( gx.text.contains( evt, 'EENTER')) {
		gx.ajax.saveFormForAutoComplete();
		}
		var callFailCallback = function () {
			if (failCallback) {
				failCallback.call();
			}
		};

		if (!this.canExecuteEvent(evt, force)) {
			callFailCallback();
			return;
		}

		var gxObj = gx.setGxObyCtx(cmpCtx, inMaster);
		var rowGridId = gridId;
		var rowId_res = this.EVT_ROW_ID_REGEXP.exec(evt);
		var rowId = (rowId_res && rowId_res.length > 1) ? rowId_res[1] : null;
		if (rowId_res && rowId_res.length > 2) {
			gx.evt.setCurrentGridRows(rowGridId, rowId);
		}
		if (! rowId) {
			rowId = gx.fn.currentGridRowImpl(rowGridId);
		}

		if (!force && gxObj && gxObj.inputHasFormatErrors(evt, gridId, rowId)) {
			callFailCallback();
			return;
		}

		var doNotifyValidation = true;
		var notifyValidation = function () {
			gx.fx.obs.notify('gx.validation', null, (function () {
				gx.setGxObyCtx(cmpCtx, inMaster);
				if (srvCommand) {
					gx.evt.srvCommand = true;
					if (ctrl) {
						rowGridId = gx.fn.rowGridId(ctrl);
						rowId = gx.fn.controlRowId(ctrl);
						if (!gx.lang.emptyObject(rowGridId) && !gx.lang.emptyObject(rowId)) {
							gx.csv.lastGrid = rowGridId;
							gx.fn.setCurrentGridRow(rowGridId, rowId);
						}
					}
				}
				if (gx.csv.lastId > 0 && !gx.csv.validatingAll) {
					
					var vStruct = gx.O.getValidStruct(gx.csv.lastId);
					var CtrlId = (gx.evt.isEnterEvtCtrl(ctrl) && ctrl.id > 0) ? gx.O.getValidStructId(ctrl.id) : gx.O.focusControl;
					var goForward = CtrlId < gx.csv.lastId; 
					if ((goForward && (gx.evt.isEnterEvtCtrl(ctrl) || (vStruct && vStruct.isuc)))  || enterKeyPressed)
					{
						gx.csv.validatingAll = true;
						gx.O.fromValid = gx.csv.lastId;
						gx.O.toValid = gx.csv.lastId + 1;
						gx.csv.validateAll();		
						gx.csv.validatingAll = false;
					}
				}
				this.setEvtName(evt, ctrl);
				this.lastEvent = evt;
				if (!srvCommand && (gx.grid.drawAtServer || (ctrl && ctrl.nodeName == 'INPUT' && ctrl.type == 'submit'))) {
					this.execEvtSubmit(evt, ctrl);
				}
				else {
					gx.evt.setProcessing(true);
					var oldDoPost = function() {
						gx.ajax.doPost((gx.http.useNamedParameters(gx.ajax.selfUrl())? 'gxevent=' : '') + gx.ajax.encryptParms(gx.pO, 'gxajaxEvt'), sync, disableForm, callback);
					};
					if (gx.pO.supportAjaxEvents) {
						gx.evt.dispatcher.dispatch(evt, gx.O, rowGridId, rowId, true, undefined, disableForm)
							.done(function(success) {  
								(!success && callFailCallback());
								(callback && callback(success)); 
							}).fail(oldDoPost);
					}
					else {
						gx.evt.execNonFullAjaxEvent(oldDoPost);
					}
				}
			}).closure(this));
		};

		if (gx.evt.fixWebKitOnFocus() && gx.dom.isButtonLike(ctrl) && ctrl != gx.csv.lastControl && ctrl.onfocus != undefined) {
			doNotifyValidation = false;
			gx.fx.obs.addObserver('gx.onafterfocus', this, notifyValidation, { single: true });
			ctrl.onfocus();
		}

		if (doNotifyValidation) {
			notifyValidation.call(this);
		}
	},

	execEvtSubmit: function (evt, ctrl) {
		if (!gx.isInputEnabled())
			return;
		gx.evt.setProcessing(true);
		gx.O.startFeedback();
		gx.fx.obs.notify('gx.onbeforeevent', [evt, ctrl]);
		gx.fn.objectOnpost();
		gx.http.saveState();
		gx.fn.forceEnableControls(false);
		var form = gx.dom.form();
		var currentPopup = gx.popup.getPopup();
		if (currentPopup != null) {
			var url = form.action;
			var currentLvl = currentPopup.window.gx.popup.lvl;
			if (currentLvl != -1) {
				var text = gx.http.urlParameterPrefix(url);
				text += encodeURIComponent('gxPopupLevel=' + currentLvl + ';');
				url += text;
				form.action = url;
			}
		}
		form.submit();
	},

	execCliEvt: function ( cmpCtx, inMaster, cliEvtName, evtGridName, gridRow, parms) {
		var deferred = $.Deferred();
		
		if (!this.canExecuteEvent(true, false)) {
			return deferred.reject();
		}

		gx.fx.obs.notify('gx.validation');
		parms = (parms != undefined) ? parms : [];
		var gxObj = gx.getObj(cmpCtx, inMaster),
			gridId;
		if (gxObj != null) {
			gx.setGxO(cmpCtx, inMaster);
			if (typeof (evtGridName) == 'string' && evtGridName != '' && (arguments.length > 4)) {
				var grid = gxObj.getGrid(evtGridName)
				grid.instanciateRow(gridRow);
				gridId = grid.gridId;
			}
			if (gxObj.inputHasFormatErrors(gxObj.getServerEventName(cliEvtName), gridId, gridRow))
				return deferred.reject();

			var isServerEvent = gxObj.isServerEvent(cliEvtName);
			gx.evt.setProcessing(true, !isServerEvent);
			gxObj.execC2VFunctions();
			var callback = function () {
				gx.popup.waitCallback(function () {
					gx.evt.setProcessing(false, (!gx.csv.validating && !isServerEvent));
				});
				if (gxObj.conditionsChanged) {
					gxObj.executeServerEvent('RFR', true);
				}
				else {
					gx.fx.obs.notify('gx.onafterevent', []);
				}
				deferred.resolve();
			};

			var oldCall = function() {
				gxObj[cliEvtName](parms);
				callback();
				gx.fx.obs.notify('gx.afterNonFullajax');
			};

			if (gx.pO.supportAjaxEvents) {
				gx.evt.dispatcher.dispatch(gxObj.getServerEventName(cliEvtName), gxObj, gridId, gridRow, false, parms)
					.done(callback)
					.fail(oldCall);
			}
			else {
				gx.evt.execNonFullAjaxEvent(oldCall);
			}
			return deferred.promise();
		}
		return deferred.reject();
	},
	
	execNonFullAjaxEvent: function (fn) {
		gx.evt.NonFullAjaxserialRunner = gx.evt.NonFullAjaxserialRunner || gx.evt.serialRunner();
		gx.fx.obs.addObserver('gx.afterNonFullajax', gx.evt, function(){gx.evt.NonFullAjaxserialRunner.signalEndTask()}, { single: true });
		gx.evt.NonFullAjaxserialRunner.addTask( fn);
	},
	
	fixWebKitOnFocus: function () {
		var browser = gx.util.browser;
		if (browser.isWebkit() && !browser.isChrome())
			return true;

		if (browser.isChrome() && browser.chromeVersion() < 30)
			return true;

		return false;
	},

	dispatcherTimeout: 100,
	
	dispatcher: function () {
		var removeRepeatedEvents = function (arr, messageType) {
			var result = [];
			var i, j;
			var evt;
			var eventDeferredsMap = {};
			var deferreds;

			for (i=0; i<arr.length; i++) {
				evt = arr[i];
				if (!eventDeferredsMap[evt.eventName]) {
					eventDeferredsMap[evt.eventName] = [];
				}
				eventDeferredsMap[evt.eventName].push(evt.deferred);

				if (result.length === 0 || evt.eventName !== result[result.length-1].eventName) {
					result.push(evt);
				}
			}

			// Make sure to fire all the deferreds, event those from
			// removed events that were repeated.
			for (i=0; i<result.length; i++) {
				evt = result[i];
				deferreds = eventDeferredsMap[evt.eventName];
				for (j=0; j<deferreds.length; j++) {
					if (evt.deferred !== deferreds[j]) {
						evt.deferred.done((function () {
							this.resolve.apply(this, arguments);
						}).closure(deferreds[j]));
					}
				}
			}

			return result;
		};

		return {
			dispatchedEvents: {},

			serialRunner: gx.evt.serialRunner(),

			getContextKey: function (gxO, grid, row, type) {
				return type + (gxO.CmpContext + gxO.ServerClass) + (grid || "") + (row || "");
			},

			getEventParmsMetadata: function (eventName, gxO, type) {
				return gxO.EvtParms[eventName][type == "input" ? 0 : 1];
			},

			eventDepends: function(dependantEvent, dependencieEvent, gxO) {
				var dependencies = this.getEventParmsMetadata(dependencieEvent, gxO, "output"),
					dependants = this.getEventParmsMetadata(dependantEvent, gxO, "input"),
					dependencieKey,
					dependantKey;
				for (var i=0, ilen=dependencies.length; i<ilen; i++) {
					dependencieKey = gx.ajax.resolveParmKey(dependencies[i]);
					for (var j=0, jlen=dependants.length; j<jlen; j++) {
						dependantKey = gx.ajax.resolveParmKey(dependants[j]);
						if (dependencieKey == dependantKey) {
							return true;
						}
					}
				}
				return false;
			},

			initialize: function() {
				this.t && clearTimeout(this.t);
				this.serialRunner = gx.evt.serialRunner();
				this.dispatchedEvents = {};
			},

			beforeDispatch: function(gxO) {
				var secToken = gx.ajax.getSecurityToken(gxO);
				if (secToken) {
					gxO.InternalParms[secToken.id] = secToken.value;
				}
			},

			types: {
				event: "event",
				validation: "validation"
			},

			dispatch: function(dirtyEventName, gxO, grid, row, serverSide, evtArguments, disableForm, type) {
				type = type || gx.evt.dispatcher.types.event;
				serverSide = (serverSide === undefined) || serverSide;
				var deferred = $.Deferred();
				var clientSideFunction;
				if  (typeof dirtyEventName === "object") {
					clientSideFunction = dirtyEventName.fn;
					dirtyEventName = dirtyEventName.eventName;
				}
				var cleanEventName = gxO.cleanEventName(dirtyEventName);
				var clientSideEventName = gxO.getClientEventName(dirtyEventName);

				if (type === gx.evt.dispatcher.types.validation) {
					cleanEventName = dirtyEventName.toUpperCase();
					clientSideEventName = dirtyEventName;
				}
				else {
					cleanEventName = gxO.cleanEventName(dirtyEventName);
					clientSideEventName = gxO.getClientEventName(dirtyEventName);
				}

				this.beforeDispatch(gxO);
				
				if (!gxO.EvtParms[cleanEventName]) {
					deferred.reject();
					return deferred.promise();
				}
				var contextKey = this.getContextKey(gxO, grid, row, type),
					dispatchedEvts = this.dispatchedEvents[contextKey],
					eventObj = {
						eventName: cleanEventName,
						clientSideEventName: clientSideEventName,
						clientSideFunction: !serverSide 
												? (clientSideFunction || gxO[clientSideEventName]).closure(gxO, evtArguments || []) 
												: null,
						serverSide: serverSide,
						deferred: deferred,
						arguments: evtArguments,
						disableForm: disableForm
					};

				if (dispatchedEvts) {
					dispatchedEvts.events.push(eventObj);
				}
				else {
					dispatchedEvts = {
						gxO: gxO,
						grid: grid,
						row: row,
						type: type,
						events: [eventObj]
					};
					this.dispatchedEvents[contextKey] = dispatchedEvts;
					this.t = setTimeout(
						this.serialRunner.addTask.closure(this.serialRunner, [this.dispatchTimeoutCallback.closure(this, [contextKey])]), 
						gx.evt.dispatcherTimeout
					);
				}
				return deferred.promise();
			},

			dispatchTimeoutCallback: function(contextKey) {
				var dispatchedEvts = this.dispatchedEvents[contextKey],
					messageType = dispatchedEvts.type,
					gxO = dispatchedEvts.gxO,
					grid = dispatchedEvts.grid,
					row = dispatchedEvts.row,
					clientSideIndependentEvents = [],
					restOfEvents = [],
					eventsToRun,
					eventObj,
					isIndependent,
					messages = [],
					message,
					previousIsServerSide,
					eventsDeferreds = {},
					eventName;

				delete this.dispatchedEvents[contextKey];

				if (messageType !== gx.evt.dispatcher.types.validation) {
					// Order events according to dependencies. Independent client side events go first. The rest are executed
					// in the same order as they were dispatched.
					for (var i=0, len=dispatchedEvts.events.length; i<len; i++) {
						eventObj = dispatchedEvts.events[i];
						if (!eventObj.serverSide) {
							isIndependent = true;
							for (var j=0; j<i; j++) {
								if (this.eventDepends(eventObj.eventName, dispatchedEvts.events[j].eventName, gxO)) {
									isIndependent = false;
									break;
								}
							}
							if (isIndependent) {
								clientSideIndependentEvents.push(eventObj);
							}
							else {
								restOfEvents.push(eventObj);
							}
						}
						else {
							restOfEvents.push(eventObj);
						}
					}
				}
				else {
					// No re-ordering of validations. The order has already been resolved and must remain unchanged.
					restOfEvents = dispatchedEvts.events;
				}
				eventsToRun = removeRepeatedEvents(clientSideIndependentEvents, messageType)
								.concat(removeRepeatedEvents(restOfEvents, messageType));

				// Create event blocks
				previousIsServerSide = false;
				for (var i=0, len=eventsToRun.length; i<len; i++) {
					eventName = eventsToRun[i].eventName;
					if (!eventsDeferreds[eventName]) {
						eventsDeferreds[eventName] = [];
					}
					eventsDeferreds[eventName].push(eventsToRun[i].deferred);
					if (previousIsServerSide && eventsToRun[i].serverSide) {
						message.addMethod(eventName);
					}
					else {
						message = this.createMessage(messageType, eventName, gxO, grid, row, eventsToRun[i].serverSide, eventsToRun[i].disableForm);
						if (!eventsToRun[i].serverSide) {
							message.callback = eventsToRun[i].clientSideFunction;
						}
						messages.push(message);
					}
					previousIsServerSide = eventsToRun[i].serverSide;
				}

				var endMessage = function (message, success, result) {
					for (var i=0, len=message.methods.length; i<len; i++) {
						var deferredsList = eventsDeferreds[message.methods[i]];
						for (var j=0; j<deferredsList.length; j++) {
							var deferred = deferredsList[j];
							if (deferred) {
								success ? deferred.resolve(result) : deferred.reject(result);
							}
						}
					}
				};

				// Run each block after the previous has finished
				runCount = 0;
				var serialRunner = this.serialRunner;
				var runner = function () {
					if (runCount < messages.length) {
						var message = messages[runCount++],
							isLastMsg = runCount == messages.length;
						message.call().done(function (result) {							
							endMessage(message, true, result);
							runner();
							if (isLastMsg) {
								serialRunner.signalEndTask();
							}
						}).fail(function (result) {
							endMessage(message, false, result);							
							for (var j = runCount; j < messages.length; j++) {
								endMessage(messages[j], false, result);
							}
							serialRunner.signalEndTask();
						});

					}
				};
				runner();
			},

			createMessage: function (messageType, method, gxO, grid, row, serverSide, disableForm) {
				if (messageType === gx.evt.dispatcher.types.validation) {
					return new gx.ajax.validationMessage(method, gxO, grid, row, serverSide, disableForm);
				}

				return new gx.ajax.message(method, gxO, grid, row, serverSide, disableForm);
			}
		};
	}(),

	mouse: {
		x: -1,
		y: -1,

		update: function (evt) {
			try {
				if (!gx.lang.emptyObject(evt.touches)) {
					if  (evt.touches.length > 0) {								
						this.x = evt.touches[0].pageX;
						this.y = evt.touches[0].pageY;
					}							
				}
				else if (gx.util.browser.isIE()) {
					this.x = event.clientX + gx.dom.documentScroll().scrollLeft;
					this.y = event.clientY + gx.dom.documentScroll().scrollTop;
				} 
				else {													
					this.x = evt.pageX;
					this.y = evt.pageY;							
				}
				
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'mouse update');
			}
		}
	},
	
	_deinit: function () {
		this.lastControl = null;
		this.lastEvent = null;
		this.dummyCtrl = {};
		this.keyListeners = {};
		this.hooks = [];
	}
	}
})(gx.$);
	
gx.csv_i =  (function($) {
	var runControlValidation = function (controlsToValidate, scope, callback, returns) {
		var promises = [];
		for (var i=0; i<controlsToValidate.length; i++) {
			promises.push(scope.validControl.apply(scope, controlsToValidate[i]));
		}
		$.when.apply($, promises).done(callback);
	};

	return {
			GX_OLD_VALUE_ATTRIBUTE: 'data-gxoldvalue',
			GX_VALID_ATTRIBUTE: 'data-gxvalid',
			pkDirty: false,
			validating: false,
			lastRow: [],
			rowChanged: false,
			currentId: 0,
			lastId: 0,
			lastControl: null,
			lastActiveControl: null,
			lastGrid: 0,
			cmpCtx: '',
			anyError: false,
			userFocus: null,
			focusControl: null,
			invalidControl: null,
			invalidForcedCtrl: null,
			validActivatedControl: null,
			disableFocus: false,
			validatingUC: null,
			validatingGrid: null,
			instanciatedRowGrid: null,
			lastEvtResponse: null,
			lastEvtRow: null,
			invalidId: 0,
			stopOnError: false,
			dismissSeconds: 0,
			messagePosition: 'right',
			oneAtAtime: true,
			gxFormatErrors: [],

		
			resetRow: function() {
				gx.csv.lastEvtRow = null;
				gx.csv.validatingGrid = null;
				gx.csv.instanciatedRowGrid = null;
			},
			
			validateAll: function (gxO) {
				var deferred = $.Deferred();
				gxO = gxO || gx.O;

				this.validControls(gxO.fromValid, gxO.toValid, false, gxO).done((function () {
					try {
						if (this.invalidControl == null || !gx.csv.stopOnError)
							gxO.fromValid = gxO.toValid;
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxapi.js', 'validateAll');
					}
					deferred.resolve();
				}).closure(this));

				return deferred.promise();
			},

			validControls: function (FromControl, TargetControl, bForceCheck, gxO, toUpperRowInGrid) {
				var deferred = $.Deferred(),
					bRet = true,
					bFailedCtrl = -1,
					controlsToValidate = [],
					lvlFrom=0, lvlTarget=0, isValid, lvlCtrl=0, ret,
					validFullGrid = gx.csv.fullGridValidation && (TargetControl - FromControl) >=1 && gx.O.isTransaction(),
					validStruct;

				gxO = gxO || gx.O;

				gxO.startFeedback();
				var resolve = function (bRet) {
					gxO.endFeedback();
					deferred.resolve(bRet);
				};

				var setFocusResolver = function (bRet, bFailedCtrl) {
					if (gx.csv.stopOnError) {
						if (bFailedCtrl != -1) {
							var _GXValidStruct = gx.fn.validStruct(bFailedCtrl, gxO);
							var Control = gx.fn.getControlGridRef(_GXValidStruct.fld, _GXValidStruct.grid);
							gx.csv.disableFocus = document.activeElement !== Control;
							if (gx.fn.isAccepted(Control, gxO))
								gx.fn.setFocus(Control);
							else
								gx.fn.setFocus(gx.evt.lastControl);
						}
						else if (!gx.dom.isButton(gx.csv.lastControl) && gx.csv.validActivatedControl != null) {
							gx.fn.setFocus(gx.csv.validActivatedControl);
						}
					}
				};

				try {
					gx.csv.validActivatedControl = null;
					gx.csv.invalidControl = null;
					gx.csv.invalidId = 0;
					validStruct = null;
					if (TargetControl > FromControl) {
						if (validFullGrid)
						{
							validStruct = gx.fn.validStruct(FromControl);
							if (validStruct != undefined && validStruct.lvl != undefined)
								lvlFrom = validStruct.lvl;
								
							validStruct = gx.fn.validStruct(TargetControl);
							if (validStruct != undefined && validStruct.lvl != undefined)
								lvlTarget = validStruct.lvl;
						}

						var controlsToValidate = [];
						for (var i = FromControl; i < TargetControl; i++) {
							validStruct = gx.fn.validStruct(i);
							var GXValidRow;
							if (validStruct) {
								GXValidRow = gx.fn.currentGridRowImpl(validStruct.grid);
							}
							controlsToValidate.push([i, bForceCheck, gxO, GXValidRow, toUpperRowInGrid]);

							//Valid Full Grid							
							if (validFullGrid && i > FromControl && i < TargetControl)
							{
								if (validStruct != undefined && validStruct.lvl != undefined)
								{
									lvlCtrl = validStruct.lvl;
									if (lvlCtrl != lvlFrom && lvlCtrl != lvlTarget && validStruct && validStruct.grid)
									{
										var gridObj = gx.fn.getGridObj(validStruct.grid);
										var len = gridObj.grid.rows.length;
										var gridCurrentRow = gx.fn.currentGridRowImpl(validStruct.grid);
										//Si se esta validando el ultimo control de una row, y TargetControl esta fuera del grid, entonces se dispara la validacion de las demas rows
										var lastGridCtrl = gx.fn.lastGridControl(validStruct.grid);
										if (i==lastGridCtrl)
										{
											var firstGridCtrl = gx.fn.firstGridControl(validStruct.grid);

											for (var rowIdx = 0; rowIdx < len; rowIdx++) { 
												var rowObj = gridObj.grid.rows[rowIdx];
												var IsRemoved = rowObj.gxDeleted();
												var RecordExists = rowObj.gxExists();
												var RecordIsMod = rowObj.gxIsMod();
												if (!IsRemoved && (RecordExists || RecordIsMod) && rowObj.gxId != gridCurrentRow) {
													for (var colIdx = firstGridCtrl; colIdx <= lastGridCtrl; colIdx++) { 
														controlsToValidate.push([colIdx, bForceCheck, gxO, gridCurrentRow, rowObj.gxId]);
													}
												}
											}
										}
									}
								}
							}
						}
						if (controlsToValidate.length > 0) {
							gx.evt.setProcessing(true);
							runControlValidation(controlsToValidate, this, function () {
								var bRet = true,
									bFailedCtrl = -1;
								for (var i=0, len=arguments.length; i < len; i++) {
									var isValid = arguments[i].ret;
									if (bRet && !isValid) {
										bFailedCtrl = arguments[i].ctrl;
										bRet = false;
										break;
									}
								}
								setFocusResolver(bRet, bFailedCtrl);
								gx.evt.setProcessing(false);
								resolve(bRet);
							});
							return deferred.promise();
						}
						else {
							setFocusResolver(bRet, bFailedCtrl);
							resolve(bRet);
						}
					}
					else {
						setFocusResolver(bRet, bFailedCtrl);
						resolve(bRet);
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'validControls');
				}
				return deferred.promise();
			},

			validControl: function (Id, bForceCheck, gxO, gridRow, toUpperRowInGrid) {
				var deferred = $.Deferred(),
					gxO = gxO || gx.O,
					bRet = true,
					bFailedCtrl = -1,
					validStruct = gx.fn.validStruct(Id, gxO),
					GXValidRow,
					shouldResolveOnReturn = true;

				if (validStruct != undefined) {
					if (validStruct.grid != 0) {
						GXValidRow = gridRow ? gridRow : gx.fn.currentGridRowImpl(validStruct.grid);
						if (!gx.lang.emptyObject(GXValidRow))
							gx.fn.setCurrentGridRow(validStruct.grid, GXValidRow);
					}
					if (validStruct.isuc == true) {
						if (validStruct.grid != 0) {
							GXValidRow = gridRow ? gridRow : gx.fn.currentGridRowImpl(validStruct.grid);
						}
						else {
							GXValidRow = null;
						}
						var uc = validStruct.getUCInstance(GXValidRow) || validStruct.uc; 
						validStruct.uc.execC2VFunctions();
					}
					else {
						if (typeof (validStruct.c2v) == 'function')
							validStruct.c2v();
					}
					if (typeof (validStruct.v2bc) == 'function')
						validStruct.v2bc.call(gxO);
					try {
						if (validStruct.lvl == 0 || ((validStruct.grid != 0) && gx.fn.gridRowIsMod(validStruct.lvl, gx.fn.currentGridRow(validStruct.grid))) || !gxO.isTransaction()) {
							var Control = null;
							if (validStruct.isuc == true)
								Control = validStruct.uc.getRealControl();
							else
								Control = gx.fn.getControlGridRef(validStruct.fld, validStruct.grid);
							if (Control) {
								this.validate(Control, Id, bForceCheck, gxO, gridRow, toUpperRowInGrid).done(function (bValid) {
									try {
										var rowIsRemoved = false,
											bRet = true,
											bFailedCtrl = -1;
										if (validStruct.grid != 0)
											rowIsRemoved = gx.fn.rowIsRemoved(validStruct.grid, gx.fn.currentGridRow(validStruct.grid));
										if (!bValid && !rowIsRemoved) {
											gx.csv.invalidControl = Control;
											gx.csv.invalidId = Id;
											bRet = false;
											bFailedCtrl = Id;
										}

										gx.csv.lastId = Id;
										if (gx.fn.isAccepted(Control) == false) {
											gx.evt.executeOnblur(Id, Control);

											if (Control.getAttribute("data-gxhiddenonchange") != Control.value) {
												Control.setAttribute("data-gxhiddenonchange", Control.value);
												gx.evt.execOnchange(Control, false, true);
											}
										}
									}
									catch (e) {
										gx.dbg.logEx(e, 'gxapi.js', 'validControl - callback');
									}

									deferred.resolve({ ret: bRet, ctrl: bFailedCtrl});
								});
								shouldResolveOnReturn = false;
								return deferred.promise();
							}
						}
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxapi.js', 'validControl');
					}
				}
				if (shouldResolveOnReturn) {
					deferred.resolve({ ret: bRet, ctrl: bFailedCtrl});
				}
				return deferred.promise();
			},

			validate: function (Ctrl, i, bForceCheck, gxO, ctrlRow, toUpperRowInGrid) {
				var deferred = $.Deferred(),
					gxO = gxO || gx.O;
				var shouldResolveOnReturn = true;
				gx.csv.anyError = false;
				var validStruct = gx.fn.validStruct(i, gxO);
				if (validStruct == undefined) {
					deferred.resolve(true);
					return deferred.promise();
				}
				gx.csv.refreshVars(validStruct, gxO);
				if ((validStruct.fnc == null) && (validStruct.isvalid == null)) {
					//numeric grid filters refresh on lostfocus
					if (Ctrl.tagName != "SELECT" && Ctrl.type != "checkbox" && !gx.evt.eachKeyAutorefreshType(validStruct.type) && !gx.lang.emptyObject(validStruct.rgrid)) {
						var len = validStruct.rgrid.length;
						for (var j = 0; j < len; j++) {
							validStruct.rgrid[j].filterVarChanged();
						}
					}
					deferred.resolve(true);
					return deferred.promise();
				}

				try {
					var jsCode = '';
					if (i != -1 && (bForceCheck || (Ctrl.getAttribute(gx.csv.GX_VALID_ATTRIBUTE) != "1"))) {
						gx.csv.currentId = i;
						gx.evt.startValidation(validStruct.gxgrid, true);
						gx.csv.refreshVars(validStruct);
						
						var vStructValidCallback = function (validRet) {
							if (gxO.AnyError == 1) {
								if (gx.lang.emptyObject(gx.csv.invalidControl))
									gx.csv.invalidControl = Ctrl;
								gx.csv.anyError = true;
								gxO.AnyError = 0;
							}

							if (gx.csv.anyError)
								validRet = !gx.csv.anyError;
							if (!validRet) {
								gx.evt.endValidation();
								deferred.resolve(false);
								return deferred.promise();
							}
							gx.csv.refreshControls(validStruct, gxO, ctrlRow);
							gx.csv.invalidateDeps(i, gxO);
							if (!gx.lang.emptyObject(validStruct.rgrid) && !gx.lang.emptyObject(validStruct.hc)) {
								var len = validStruct.rgrid.length;
								for (var j = 0; j < len; j++) {
									validStruct.rgrid[j].filterVarChanged();
								}
							}
							var ctrlIsAccepted = gx.fn.isAccepted(Ctrl, false, gxO);
							var callback = function () {
								deferred.resolve(true);
								try {
									if (!toUpperRowInGrid) { //Si no se dispar? isValid (toUpperRowInGrid=true) => no se modifica el valor de Ctrl.gxvalid
										//Si Ctrl esta en un grid, y fue una validacion server side que disparo un refresh del grid, Ctrl es una referencia a un control que fue sustituido (redibujado) en el dom.
										var DomCtrl = gx.dom.byId(Ctrl.id);

										if (ctrlIsAccepted) {
											gx.fn.setControlGxValid(DomCtrl, "1");
										}
										else {
											gx.fn.setControlGxValid(DomCtrl, "0");
										}
									}
									gx.evt.endValidation();
								}
								catch (e) {
									gx.dbg.logEx(e, 'gxapi.js', 'validate');
								}
							};

							//Is valid del usuario se ejecuta si gx.csv.GX_VALID_ATTRIBUTE!=1, independientemente de bForceCheck
							//toUpperRowInGrid indica que Ctrl esta en una row superior al control de donde viene el foco, dentro del mismo grid, alli no se dispara la IsValid del usuario(porque se va hacia atras), pero si la validacion anterior, para instanciar valores de la row en variables.
							if (validStruct.isvalid != null && ctrlIsAccepted && Ctrl.getAttribute(gx.csv.GX_VALID_ATTRIBUTE) != "1" && !toUpperRowInGrid) {
								var grid = validStruct.gxgrid ? validStruct.gxgrid : null;
								var evtName = validStruct.isvalid;
								if (gx.pO.supportAjaxEvents) {
									var gridId = validStruct.gxgrid ? validStruct.gxgrid.gridId : false,
										row = gridId ? gx.fn.currentGridRowImpl(gridId) : '',
										serverEvent = gxO.isServerEvent(evtName);

									if (evtName) {
										gx.evt.dispatcher.dispatch(gxO.getServerEventName(evtName), gxO, gridId, row, serverEvent)
											.done(callback)
											.fail(callback);
									}
									else {
										gxO[evtName]().then(callback);
									}
									return;
								}
								else {
									var oldGrid = gx.csv.instanciatedRowGrid;
									gx.csv.instanciatedRowGrid = grid;
									gxO[evtName]().then(function () {
										gx.csv.instanciatedRowGrid = oldGrid;
										callback();
									});
								}
							}
							else {
								callback();
							}
						};

						shouldResolveOnReturn = false;
						var validRet = false;
						if (validStruct.isuc)
							vStructValidCallback.call(this, validStruct.fnc.call(validStruct.uc));
						else if (validStruct.fnc != null) {
							var validResult = validStruct.fnc.call(gxO);
							if (validResult && validResult.done) {
								// The validation returned a promise
								validResult.done(vStructValidCallback.closure(this)); 	//call FieldValidation
							}
							else {
								// The validation returned a value
								vStructValidCallback.call(this, validResult);
							}
						}
						else {
							vStructValidCallback.call(this, true);
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'validate');
				}

				if (shouldResolveOnReturn) {
					deferred.resolve(true);
				}
				return deferred.promise();
			},

			invalidateForm: function () {
				if (gx.O.AnyError == 1) {
					return;
				}
				var ctrlIds = gx.fn.controlIds();
				var len = ctrlIds.length;
				for (var i = 0; i < len; i++) {
					var validStruct = gx.fn.validStruct(ctrlIds[i]);
					if (validStruct && validStruct.fld && !validStruct.isuc) {
						var ctrl = gx.fn.getControlGridRef(validStruct.fld, validStruct.grid);
						this.invalidateGXCtrl(ctrl, false);
					}
				}
			},

			invalidateGXCtrl: function (Ctrl, checkChanged) {
				if (typeof checkChanged === 'undefined') {
					checkChanged = true;					
				}
				if (Ctrl) {					
					if ((Ctrl.getAttribute(gx.csv.GX_VALID_ATTRIBUTE) == 1) && (!checkChanged || gx.csv.controlValueHasChanged(Ctrl))) {
						gx.fn.setControlGxValid(Ctrl, "0");
					}
				}
			},


			invalidateCtrl: function (Ctrl, keyEvt) {
				try {
					this.invalidateGXCtrl(Ctrl);
					var validStruct = gx.fn.validStruct(gx.O.focusControl);
					if (validStruct && validStruct.grid != 0 && gx.evt.keyModifiesValue(keyEvt)) {						
						var ctrlRow = gx.fn.controlRowId(Ctrl) || gx.fn.currentGridRowImpl(validStruct.grid) || '0001';
						validStruct.gxgrid.setRowModified(ctrlRow);
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'invalidateCtrl');
				}
			},

			invalidateDeps: function (id, gxO) {
				var ctrlIds = gx.fn.controlIds(gxO);
				var len = ctrlIds.length;
				for (var i = 0; i < len; i++) {
					var cId = ctrlIds[i];
					if (cId > id) {
						var validStruct = gx.fn.validStruct(cId, gxO);
						var len1 = validStruct.ip ? validStruct.ip.length : 0;
						for (var j = 0; j < len1; j++) {
							if (validStruct.ip[j] == id) {
								if (validStruct.grid == 0) {
									var ctrl = gx.fn.getControlGridRef(validStruct.fld, validStruct.grid);
									if (ctrl) {
										gx.fn.setControlGxValid(ctrl, '0');
									}
								}
								else {
									var gridObj = gx.fn.getGridObj(validStruct.grid);
									if (gridObj) {
										var len2 = gridObj.grid.rows.length;
										for (var k = 0; k < len2; k++) {
											var row = gridObj.grid.rows[k];
											var rowRemoved = row.gxDeleted();
											var rowExists = row.gxExists();
											if (!rowRemoved && rowExists) {
												gridObj.setRowModified(row.gxId);
												var ctrl = gx.fn.getControlRef(validStruct.fld + '_' + row.gxId);
												if (ctrl) {
													gx.fn.setControlGxValid(ctrl, '0');
												}
											}
										}
									}
								}
							}
						}
					}
				}
			},

			controlValueHasChanged: function (Ctrl, currentValue, vStruct) {
				if (!Ctrl)
					return false;

				if (typeof(currentValue) === 'undefined')
					currentValue = Ctrl.value;
				var ctrlOldValue = Ctrl.getAttribute(gx.csv.GX_OLD_VALUE_ATTRIBUTE),
					oldValue = gx.applyPicture(vStruct, ctrlOldValue, Ctrl);
				
				return ctrlOldValue === null || oldValue !== gx.applyPicture(vStruct, currentValue, Ctrl) || 
					(gx.evt.fixWebKitOnFocus() && Ctrl.type === "radio"); //WebKit Radio buttons don't receive focus event: https://bugs.webkit.org/show_bug.cgi?id=92029
			},

			setFormatError: function(Ctrl, error) {
				Ctrl = gx.dom.el(Ctrl);
				if (Ctrl.id) {
					if (error || typeof(error) == 'undefined') {
						this.gxFormatErrors[Ctrl.id] = true;
						Ctrl.GXFormatError = true;
					}
					else {
						delete this.gxFormatErrors[Ctrl.id];
						Ctrl.GXFormatError = false;
					}
				}
			},
			
			
			anyFormatError: function() {
				return gx.lang.emptyObj(this.gxFormatErrors) === false;
			},
			
			disableFocusCondition: function () {
				if (typeof (gx.fn.validStruct(gx.O.focusControl)) == "undefined")
					return false;
				try {
					var sMode = gx.getVar("Gx_mode");
					if (gx.csv.lastGrid > 0)
						gx.setVar("Gx_mode", gx.fn.getGridRowMode(gx.fn.gridLvl(gx.csv.lastGrid), gx.csv.lastGrid));
					var vStruct = gx.fn.validStruct(gx.O.focusControl);
					if (vStruct && vStruct.nac && vStruct.nac.call(gx.O) == true) {
						cn = gx.fn.getControlIndex(gx.csv.lastControl) + 1;
						var NextFocus = gx.fn.searchFocusFwd(cn);
						if (NextFocus != null)
							gx.fn.setFocus(NextFocus);
						gx.setVar("Gx_mode", sMode);
						return true;
					}
					gx.setVar("Gx_mode", sMode);
				}
				catch (e) { }
				return false;
			},

			loadScreen: function (callback) {
				try {
					if (gx.csv.pkDirty) {
						gx.csv.pkDirty = false;
						gx.fn.clearOldKeys();
						gx.evt.execEvt(gx.csv.cmpCtx, false, gx.csv.cmpCtx + 'ELSCR.', gx.evt.dummyCtrl, null, true, undefined, undefined, callback, false);
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'loadScreen');
				}
			},

			CTRL_ROW_INDEX_REGEXP: /(.*)_([0-9]{4})+$/,

			ctxControlId: function (ControlId, gxO) {
				var cmpContext,
					gxOMP = gxO || gx.O;
				
				if (gxOMP && gxOMP.IsMasterPage && ControlId.indexOf('MP') != 0) {
					//MasterPage grid controls 
					var rowId_res = this.CTRL_ROW_INDEX_REGEXP.exec(ControlId);
					if (rowId_res && rowId_res.length > 1) {
						var fldId = rowId_res[1], row_id = (rowId_res.length > 2) ? '_' + rowId_res[2] : '';
						return fldId + (fldId.indexOf('_MPAGE') === -1 ? '_MPAGE' : '') + row_id ;
					}
				}
				cmpContext = (gxO ? gxO.CmpContext : this.cmpCtx) || "";
				if (cmpContext && ControlId.indexOf(cmpContext) == 0) {					
					return ControlId;					
				}

				if (ControlId.search(gx.GxObject.CONTROL_CMP_REGEX) >= 0)
					return ControlId;
				return cmpContext + ControlId;
			},

			isProperty: function (Target) {
				if (Target instanceof Array && Target.length == 2)
					return true;
				if (typeof (Target) == 'object') {
					if (typeof (Target[0]) != 'undefined' && typeof (Target[1]) != 'undefined')
						return true;
				}
				return false;
			},

			checkGridChange: function( gridObj, gridChange, gxO, lastRow) {
				if (gridObj) {
					var gridId = gridObj.gridId,
						GXValidRow = gx.fn.currentGridRowImpl(gridId);
					gx.csv.validGridRowChange( gridId, GXValidRow, gxO, GXValidRow).done( function() {
						var gridObj = gxO.getGridById( gridId, lastRow);
						gx.csv.checkGridChange( gridObj.parentGrid, true, gxO, lastRow);}
					);
				}
			},
			
			checkRowChange: function (Ctrl, gridChange, gxO, lastRow) {
				var deferred = $.Deferred();
				try {
					var vStruct = gx.fn.validStruct(Ctrl, gxO);
					if (typeof (vStruct) != 'undefined') {
						var GridId = vStruct.grid;
						if (GridId != 0) {
							var GXValidRow = gx.fn.currentGridRowImpl(GridId);
							if (GXValidRow && (GXValidRow != lastRow || gridChange) && GXValidRow.length > 1 && lastRow && lastRow.length > 1) {
								gx.csv.rowChanged = true;
								var bkpBScreen = gxO.Gx_BScreen;
								gxO.Gx_BScreen = 1;
								gx.csv.validGridRowChange(GridId, GXValidRow, gxO, lastRow).done(function (isValid) {
									if (isValid) {
										var gridObj = gxO.getGridById(GridId, lastRow);
										if (gridObj) {
											gridObj.instanciateRow(GXValidRow); //setCurrentGridRow and instanciate variables
											if (gridObj.parentGrid) {
												gx.csv.checkGridChange( gridObj.parentGrid, true, gxO, lastRow);
											}
										}
									}
									gxO.Gx_BScreen = bkpBScreen;
									deferred.resolve(true);
								});
							}
							else {
								deferred.resolve(false);
							}
							if (GXValidRow != undefined)
								gx.fn.setCurrentGridRow(GridId, GXValidRow);
						}
						else {
							deferred.resolve(false);
						}
					}
					else {
						deferred.resolve(false);
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'checkRowChange');
				}
				return deferred.promise();
			},

			validGridRow: function (GridId, GXValidRow) {
				if (GXValidRow != undefined)
					gx.fn.setCurrentGridRow(GridId, GXValidRow);
				var firstGridCtrl = gx.fn.firstGridControl(GridId);
				var lastGridCtrl = gx.fn.lastGridControl(GridId);
				gx.csv.validControls(firstGridCtrl, lastGridCtrl + 1, true, gx.O);
			},

			validGridRowChange: function (GridId, GXValidRow, gxO, lastRow) {
				var deferred = $.Deferred();
				if (lastRow != undefined)
					gx.fn.setCurrentGridRow(GridId, lastRow);
				var firstGridCtrl = gx.fn.firstGridControl(GridId, gxO),
					lastGridCtrl = gx.fn.lastGridControl(GridId, gxO);
				var toUpperRowInGrid = (!gx.lang.emptyObject(lastRow) && !gx.lang.emptyObject(GXValidRow) && lastRow.length == GXValidRow.length && parseInt(lastRow) > parseInt(GXValidRow));
				gx.csv.validControls(firstGridCtrl, lastGridCtrl + 1, true, gxO, toUpperRowInGrid).done(function (bRet) {
					if (bRet || !gx.csv.stopOnError)
						gx.csv.changeGridRow(GridId, firstGridCtrl, GXValidRow);
					deferred.resolve(bRet);
				});
				return deferred.promise();
			},

			changeGridRow: function (GridId, firstGridCtrl, GXValidRow) {
				gx.csv.lastId = firstGridCtrl;
				if (gx.O.fromValid > firstGridCtrl)
					gx.O.fromValid = firstGridCtrl;
				gx.csv.lastRow[GridId] = GXValidRow;
				Gx_BScreen = 1;
			},

			targetRowIsMod: function (vStructId) {
				var vStruct = gx.fn.validStruct(vStructId);
				if (vStruct) {
					return gx.fn.gridRowIsMod(vStruct.lvl, gx.fn.currentGridRow(vStruct.grid));
				}
				return false;
			},

			refreshVars: function (validStruct, gxO) {
				var len = validStruct.ip ? validStruct.ip.length : 0;
				for (var i = 0; i < len; i++) {
					try {
						if (typeof (gx.fn.validStruct(validStruct.ip[i], gxO).c2v) == 'function')
							gx.fn.validStruct(validStruct.ip[i], gxO).c2v();
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxapi.js', 'refreshVars');
					}
				}
			},

			refreshControls: function (validStruct, gxO, row) {
				var len = validStruct.op ? validStruct.op.length : 0;
				for (var i = 0; i < len; i++) {
					try {
						var VStr = gx.fn.validStruct(validStruct.op[i], gxO);
						gx.fn.v2c(VStr, null, null, row);
						var Ctrl = null;
						if (VStr.grid == 0)
							Ctrl = gx.dom.el(gx.csv.ctxControlId(VStr.fld));
						else
							Ctrl = gx.fn.getControlGridRef(VStr.fld, VStr.grid, row);
						if (Ctrl)
							gx.fn.setControlGxValid(Ctrl, "0");
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxapi.js', 'refreshControls');
					}
				}
				len = validStruct.ucs ? validStruct.ucs.length : 0;
				for (var i = 0; i < len; i++) {
					try {
						gx.fn.validStruct(validStruct.ucs[i], gxO).uc.execV2CFunctions(true);
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxapi.js', 'refreshControls');
					}
				}
			},

			setValidValues: function (InputArr, OutputArr, ValuesArr) {
				var msgArray = [];
				if (ValuesArr.length - OutputArr.length > 1) {
				var hiddenArray = gx.json.evalJSON(ValuesArr[ValuesArr.length - 1]);
				for (h in hiddenArray) {
					gx.fn.setHidden(h, hiddenArray[h]);
				}
					msgArray = gx.json.evalJSON(ValuesArr[ValuesArr.length - 2]);
				}
				var msgs = {};
				var msgItem = {
					fields: InputArr,
					msgs: msgArray
				};
				if (gx.O.cmpCtx)
					msgs[gx.O.cmpCtx] = msgItem
				else
					msgs["MAIN"] = msgItem;
				gx.fn.setErrorViewer(msgs);
				if (!gx.O.AnyError) {
					var anyGrid = false;
					var len = OutputArr.length;
					for (var i = 0; i < len; i++) {
						var Target = OutputArr[i];
						var Value = ValuesArr[i];

						if (this.isProperty(Target))//Property
						{
							var validStruct = gx.fn.vStructForVar(Target[0]) || gx.O.getValidStructFld(Target[0]);
							if (validStruct != null) {
								gx.fn.setCtrlProperty(validStruct.fld, Target[1], Value);
							}
						}
						else {
							//Hide Code
							var validStruct = gx.fn.validStruct(this.currentId);
							if (!gx.lang.emptyObject(validStruct) && !gx.lang.emptyObject(validStruct.hc)) {
								if (validStruct.hc == Target) {
									gx.O[validStruct.hc] = Value;
									gx.fn.setHidden(this.cmpCtx + "GXH_" + validStruct.fld, Value);
								}
								else if (validStruct.hd == Target) {
									gx.O[validStruct.hd] = Value;
								}
							}
							//Attribute or Grid
							validStruct = gx.fn.vStructForVarWId(Target, this.currentId);
							if (!gx.lang.emptyObject(validStruct)) {
								var Ctrl = gx.fn.screen_CtrlRef(validStruct.fld);
								if (!gx.lang.emptyObject(Ctrl)) {
									if (Value instanceof Object) {
										if (Ctrl.tagName == "SELECT") {
											if (Ctrl.selectedIndex != -1 && gx.fn.invalidEmptyValue(Value))
												Value.s = Ctrl.options[Ctrl.selectedIndex].value;
											var comboId = gx.dom.id(Ctrl);
											gx.fn.loadComboBox(comboId, Value.v);
											gx.fn.setComboBoxValue(comboId, Value.s);
										}
										else if (!gx.lang.emptyObject(Value.s)) {
											Value.s = gx.fn.trimSelectValue(Value.s, validStruct.type);
										}
										var valueDesc = gx.fn.selectedDescription(Value, validStruct.type);
										if (gx.lang.emptyObject(Value.s) && !gx.lang.emptyObject(Ctrl.value))
											Value = Ctrl.value;
										else if (Ctrl.tagName == "SPAN" && !gx.lang.emptyObject(Value.s) && !gx.lang.emptyObject(valueDesc))
											Value = valueDesc;
										else
											Value = Value.s;
										gx.fn.setControlValue_span_safe(this.cmpCtx + validStruct.fld, Value, 0);
									}
								}

								if (validStruct.v2v) {
									validStruct.v2v(Value);
									gx.fn.v2c(validStruct, Value, validStruct.type == "bits");
								}
							}
							else {
								//HC en grid
								validStruct = gx.fn.vStructForHC(Target);
								if (validStruct != null) {
									var gRow = '';
									if (validStruct.grid != 0)
										gRow = '_' + gx.fn.currentGridRow(validStruct.grid);
									gx.fn.setHidden(this.cmpCtx + "GXHC" + validStruct.fld + gRow, Value);
								}

								var Grid = gx.fn.gridObjFromGxO(Target);
								if (Grid != undefined) {
									anyGrid = true;
									Grid.loadGrid({rowProps:Value});
								}
								else {
									if (!gx.fn.saveLvlOldParm(Target, Value)) {
										continue;
									}
									gx.setVar(Target, Value);
									gx.fn.setGridHidden(Target, Value);
								}
							}
						}
					}
				}
				gx.O.refreshOlds();
				gx.fn.enableDisableDelete();
				if (anyGrid) {
					gx.dom.indexElements();
				}
			},

			_deinit: function () {
				this.lastRow = [];
				this.gxFormatErrors = [];
				this.lastControl = null;
				this.lastActiveControl = null;
				this.userFocus = null;
				this.focusControl = null;
				this.invalidControl = null;
				this.invalidForcedCtrl = null;
				this.validActivatedControl = null;
				this.validatingUC = null;
				this.validatingGrid = null;
				this.lastEvtResponse = null;
				this.lastEvtRow = null;
			}
		}
})(gx.$);
	
gx.http_i = (function ($) {
		var GX_STATE_ELEMENT_ID = "GXState";
		var GX_AJAX_MULTIPART_ELEMENT_ID = "GXAjaxMultipart";
		var GX_AJAX_AUTH_TOKEN = "X-GXAUTH-TOKEN";
		
		return {
			STATE_UNSENT: 0,
			STATE_DONE: 4,
			STATUS_OK: 200,
			STATUS_UNAUTHORIZED: 401,
			STATUS_FORBIDDEN: 403,
			STATUS_SESSION_TO: 440,
			iframeName: 'gxPostIFrame',
			viewState: null,
			viewStateLoaded: false,
			oldState: null,
			useBase64State: false,
			useStateSignature: false,
			lastStatus: 0,
			lastResponse: '',

			modes: {
				none: 0,
				full: 1,
				call: 2,
				retval: 3
			},
			
			validJsonResponse: function( event, data) {
				if (data[0] != '{' && event.status == 200 && event.getResponseHeader('Content-Type').toLowerCase().indexOf('application/json') != 0) {
					gx.dbg.logEx('Unexpected AJAX respose format "' + event.getResponseHeader('Content-Type') + '"; Reloading page');
					gx.http.reload(true);
					return false;
				}
				return true;
			},

			saveHidden: function (HiddenName, Data, Create) {
				var Control = gx.dom.el(HiddenName, false, true, true);
				if (Control != null) {
					gx.fn.setControlValue_impl(HiddenName, Data);
				}
				else if (Create) {
					gx.dom.createInput(HiddenName, "hidden");
					gx.fn.setControlValue_impl(HiddenName, Data);
				}
			},

			clearMultipartHidden: function () {
				this.saveHidden(GX_AJAX_MULTIPART_ELEMENT_ID, '', false);
			},

			clearState: function () {
				this.viewState = null;
				this.viewStateLoaded = false;
				$(gx.dom.el(GX_STATE_ELEMENT_ID)).val('{}');
			},
			
			applyWellKnownPtys: function() {
				gx.wpo(function() {
				if (this.viewState['FORM_Caption']) {
					gx.fn.setCtrlPropertyImpl( document, 'Caption', this.viewState['FORM_Caption']);
				}
				}, this);
			},

			loadState: function () {
				gx.dbg.logPerf('loadState');
				this.viewState = {};
				this.viewStateLoaded = false;
				var gxState = gx.dom.el(GX_STATE_ELEMENT_ID);
				if (gxState) {
					var hiddenValues = gxState.value;
					var decoded = hiddenValues;
					if (this.useBase64State) {
						decoded = gx.base64.decode(hiddenValues);
					}
					this.viewState = gx.json.evalJSON(decoded);
					this.viewStateLoaded = true;
					this.applyWellKnownPtys();
				}
				gx.dbg.logPerf('loadState', 'GXState Loaded');
			},

			saveState: function (allFields) {
				if (!this.viewState) {
					return;
				}
				var hiddenValues = gx.json.serializeJson(this.viewState, allFields);
				var hiddenValue = hiddenValues;
				if (this.useBase64State) {
					hiddenValue = gx.base64.encode(hiddenValues);
				}
				var Control = gx.dom.el(GX_STATE_ELEMENT_ID);
				if (Control == null) {
					gx.dom.createInput(GX_STATE_ELEMENT_ID, "hidden");
				}
				else {
					this.oldState = Control.value;
				}
				gx.fn.setControlValue_impl(GX_STATE_ELEMENT_ID, hiddenValue);
				if (this.useStateSignature) {
					gx.http.setStateHsh(hiddenValue);
					gx.http.setHsh();
				}
			},
			setStateHsh: function (state) {
				var hshId = "GXHSH12";
				var Control = gx.dom.el(hshId);
				if (Control == null) {
					gx.dom.createInput(hshId, "hidden");
				}
				var res = gx.MD5.getHsh(state);
				gx.fn.setControlValue_impl(hshId, res);
			},
			setHsh: function () {
				var len = gx.pO.WebComponents.length;
				var objFound = false;
				for (var i = 0; i < len; i++) {
					gx.http.setObjectHsh(gx.pO.WebComponents[i]);
				}
				gx.http.setObjectHsh(gx.pO);
			},
			setObjectHsh: function (obj) {
				var ctrlIds = obj.getControlIdsh();
				if (ctrlIds == null) {
					return;
				}
				var pfx = '';
				if (obj.IsComponent && obj.CmpContext != null) {
					pfx = obj.CmpContext;
				}
				var tgt = "";
				for (var i = 0; i < ctrlIds.length; i++) {
					validStruct = obj.getValidStruct(ctrlIds[i]);
					if (validStruct && typeof (validStruct.val) == 'function') {
						var fldVal = gx.fn.getControlValue_impl(pfx + validStruct.fld);
						if (validStruct.ctrltype == 'checkbox' && gx.text.trim(fldVal) == '') {
							tgt = tgt + validStruct.val();
						}
						else {
							tgt = tgt + fldVal;
						}
					}
				}
				gx.http.createHsh(pfx + 'GXHSH11', tgt);
			},
			createHsh: function (hshId, toHshStr) {
				var Control = gx.dom.el(hshId);
				if (Control == null) {
					gx.dom.createInput(hshId, "hidden");
				}
				var res = gx.MD5.getHsh(toHshStr);
				gx.fn.setControlValue_impl(hshId, res);
			},
			refreshState: function () {
				if (this.oldState != null) {
					var stateCtrl = gx.dom.el('GXState');
					stateCtrl.value = this.oldState;
					this.oldState = null;
				}
			},

			getCookie: function (name) {
				name = name + '=';
				var cookies = document.cookie.split(';');
				var len = cookies.length;
				for (var i = 0; i < len; i++) {
					var cook = cookies[i];
					while (cook.charAt(0) == ' ')
						cook = cook.substring(1, cook.length);
					if (cook.indexOf(name) == 0)
						return cook.substring(name.length, cook.length);
				}
				return null;
			},

			setCookie: function (name, value, nDays, isSession, path) {
				path = (path)? ";path=" + path + ";": "";
				nDays = nDays || 1;
				var exp = new Date(new Date().getTime() + 3600000 * 24 * nDays);
				var stringCookie = name + '=' + escape(value) + path;	
				isSession ? stringCookie += '; session;': stringCookie += '; expires=' + exp.toGMTString();
				location.protocol == 'https:' ? stringCookie += 'secure; samesite=none;' : null;
				document.cookie = stringCookie;
				return (this.getCookie(name) == value);
			},

			checkResponseStatus: function (req, warnOnTimeout) {
				if (req.status == this.STATUS_FORBIDDEN)
					return false;
				if (req.status == this.STATUS_SESSION_TO) {
					gx.http.reloadOnTimeout(warnOnTimeout);
					return true;
				}
				else if (this.isBadResponse(req)) {
					gx.ajax.enableForm();
					gx.util.alert.showError(gx.getMessage("GXM_NetworkError").replace('%1', req.status));
					return true;
				}
				else if (req.status == this.STATUS_UNAUTHORIZED) {
					if (gx.pO.OnSessionTimeout == gx.timeoutActions.ignore) {
						gx.http.reload();
					}
					else if (gx.pO.OnSessionTimeout == gx.timeoutActions.warn) {
						gx.http.reloadOnTimeout(warnOnTimeout);
					}
					return true;
				}
				return false;
			},

			isSessionTimeoutError: function (req, exc) {
				if (!gx.gen.isDotNet() && (exc && req) && gx.pO.AjaxSecurity) {
					if (req.readyState == this.STATE_DONE) {
						if (exc.name == 'NS_ERROR_FAILURE' && exc.result == 2147500037) //FF
						{
							return true;
						}
						else if (exc.name == 'Error' && exc.number == -2146697209) //IE
						{
							return true;
						}
						else if (exc.name == 'NETWORK_ERR' && exc.code == 101) //CHR
						{
							return true;
						}
					}
				}
				return false;
			},

			reloadOnTimeout: function (alwaysWarn) {
				if ((alwaysWarn || gx.pO.fullAjax || gx.pO.AjaxSecurity) && confirm(gx.getMessage("GXM_sessionexpired"))) {
					gx.http.reload();
					return true;
				}
				else {
					gx.ajax.enableForm();
					return false;
				}
			},

			reload: function (forceFullGet) {
				if (document.location.hash == "") {
					this.redirect(location.href, false, forceFullGet);
				}
				else {
					document.location.reload();
				}
			},

			redirect: function (url, disableFrm, forceFullGet, gxO) {
				gxO = gxO || gx.O;
				gx.evt.setProcessing(true);				
				var currentPopup = gx.popup.getPopup();
				if (currentPopup != null && gx.util.sameAppUrl(url)) {
					var currentLvl = currentPopup.window.gx.popup.lvl;
					if (currentLvl != -1) {
						var text = gx.http.urlParameterPrefix(url);
						text += encodeURIComponent('gxPopupLevel=' + currentLvl + ';');
						url += text;
					}
				}
				if (!gx.isabsoluteurl(url)) {
					url = gx.absoluteurl(url);
				}
				
				if (disableFrm) {
					gx.evt.redirecting = true;					
				}
				else {					
					setTimeout(function () {
						if (gx.pO != gxO)
							gxO.endFeedback();
						else
							gx.ajax.enableForm();
						gx.evt.setProcessing(false);
					}, 200);
				}
					
				if (gx.spa.started && !forceFullGet) {
					gx.spa.redirect(url);	
					if (gx.pO != gxO)
						gxO.endFeedback();
					else
						gx.ajax.enableForm();
				}
				else {					
					location.href = url;
				}
			},

			getRequest: function () {
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
			},
			
			postDataFormat: {	HTTP: 0, JSON: 1},

			getPostData: function (info, dataFormat) {
				dataFormat = dataFormat || gx.http.postDataFormat.HTTP;
				var postData = dataFormat == gx.http.postDataFormat.HTTP ? [] : {};
				if (info.reqData) {
					postData = info.reqData;
				}
				else {
					var frm = info.formNode,
						elements = (frm.tagName == 'Form') ? frm.elements : $('input[type!=file],textarea,select'),
						len = elements.length;
					for (var i = 0; i < len; i++) {
						var data = gx.http.elementPostData(elements[i], dataFormat);
						if (data != null) {
							if (dataFormat == gx.http.postDataFormat.HTTP)
								postData.push(data);
							else
								postData[data[0]] = data[1];
						}
					}
				}
				if (gx.lang.isArray(postData) && dataFormat == gx.http.postDataFormat.HTTP)
						postData = postData.join('&') + '&';
				return postData;
			},

			elementPostData: function (el, dataFormat) {
				if (gx.json.isNonSerializable(el.name))
					return null;
				if (el.tagName == 'FIELDSET')
					return null;
				var value = '';
				if (el.type == 'select-multiple') {
					var len = el.options.length;
					for (var j = 0; j < len; j++) {
						if (el.options[j].selected)
							value = el.options[j].value;
					}
				}
				else if (el.type == 'radio' || el.type == 'checkbox') {
					if (el.checked)
						value = el.value;
					else if (el.type == 'radio')
						return null;
				}
				else if (el.type === 'image' ) {
					value = el.src;
				}
				else
					value = this.element_gxvalue(el);
				return (dataFormat == gx.http.postDataFormat.HTTP) ? encodeURIComponent(el.name) + '=' + encodeURIComponent(value) : [el.name, value];
			},

			element_gxvalue: function (el) {
				if (el.gxtype && el.gxtype.type == 'dtime') {
					dt = new gx.date.gxdate(el.value, gx.dateFormat);
					dt.HasTimePart = (el.gxtype.dec > 0);
					dt.HasDatePart = (el.gxtype.len > 0);
					return gx.date.dttoc(dt, el.gxtype.len, el.gxtype.dec);
				}
				return el.value;
			},

			// Precondition req != null, we should use some Assert function
			doHandleRequest: function (req, info) {
				if (req.readyState == this.STATE_DONE) {
					gx.evt.setReady(false);
					gx.evt.setProcessing(false, !gx.csv.validating);
					if (req.status == this.STATUS_OK || info.handleAllStatusCodes) {
						var url = new gx.util.Url(req.responseURL);
						if (gx.text.endsWith(url.path, '.html')) {
							window.location.href = req.responseURL;
							return;
						}
						if (this.isOffline(req)) {
							this.handleOffline(req);
							if (info.offline) {
								info.offline.call(info.obj || window, req, info);
							}
						}
						this.doCallHandler(req, info);
					}
					else {
						if (!gx.http.checkResponseStatus(req, info.warnOnTimeout)) {//Check for session timeout or forbidden status code.
							gx.lang.doCallTimeout(gx.dom.writeError, document, [req.responseText, gx.getMessage("GXM_runtimeappsrv"), req.status], 50);
						}
					}
					if (info.always) {
						info.always.call(info.obj || window, req, info);
					}
					// WA: Internet Explorer throws an exception when the window is closed in a server-side user event
					if (window.gx) {
						gx.evt.setReady(true);
						gx.dbg.logPerf('execEvt', 'Event Executed');
						gx.dbg.printPerformanceLog();
					}
				}
			},

			onRequestError: function (req, info) {
				if (info.error)
					info.error.call(info.obj || window, req, info);
				if (info.always) {
					info.always.call(info.obj || window, req, info);
				}
				gx.evt.setProcessing(false, !gx.csv.validating);
				if (req.readyState == this.STATE_DONE) {
					gx.http.checkResponseStatus(req, info.warnOnTimeout);
				}
				else if (this.isBadResponse(req)) {
					gx.http.reloadOnTimeout(info.warnOnTimeout);
				}
			},

			isBadResponse: function (req) {
				if (req.status == this.STATE_UNSENT && gx.lang.emptyObject(req.responseText))
					return true;
				return false;
			},

			doCall: function (info) {
				info.gxInitiator = gx.util.executionContext.getContext();
				gx.util.alert.hide();
				if (!info.handler && typeof (info.load) == 'function')
					info.handler = info.load;
				if (typeof (info.sync) != 'boolean')
					info.sync = false;
				if (!info.method)
					info.method = 'POST';
				if (info.multipart && info.method == 'POST') {
					this.doMultipartPost(info);
				}
				else {
					var req = this.getRequest();
					if (req != null) {
						if ((typeof (info.handler) == 'function') && !info.sync) {
							var onreadyFunc = gx.http.doHandleRequest.closure(this, [req, info]);
							var onerrorFunc = gx.http.onRequestError.closure(this, [req, info]);
							if (gx.util.browser.isIE() && gx.util.browser.ieVersion() <= 9) {
								req.onreadystatechange = onreadyFunc;
							}
							else {
								req.onload = onreadyFunc;
								req.onerror = onerrorFunc;
							}
						}
						var reqData = null;
						if (info.method == 'POST')
							reqData = gx.http.getPostData(info);
						var url = (info.avoidCache !== false) ? this.uncache(info.url) : info.url;
						req.open(info.method, url, !info.sync);
						if (info.ajaxHeader !== false)
							req.setRequestHeader(gx.ajax.reqHeader, '1');
						if (info.method == 'POST')
							req.setRequestHeader('Content-Type', info.contentType ? info.contentType : 'application/x-www-form-urlencoded');
						if (gx.sec.secToken && gx.AjaxSecurity && gx.OnSessionTimeout == gx.timeoutActions.ignore)
							req.setRequestHeader(gx.sec.secTokenName, gx.sec.secToken);

						this.setSecurityToken(req, info.gxO);										

						if (info.beforeSend)
							info.beforeSend.call(info.obj || window, req);
						try {
							req.send(reqData);
						}
						catch (e) {
							gx.dbg.logEx(e, 'gxapi.js', 'doCall');
						}

						if ((typeof (info.handler) == 'function') && info.sync) {
							gx.http.doHandleRequest(req, info);
						}

						return req;
					}
				}

				return null;
			},

			doCallHandler: function (req, info) {
				//Async request from previous page
				if( info.gxInitiator && gx.util.executionContext.changedContext(info.gxInitiator))
					return;
				if (info.obj)
					info.handler.call(info.obj, null, req.responseText, req);
				else
					info.handler(null, req.responseText, req);
				// WA: Internet Explorer throws an exception when the window is closed in a server-side user event
				if (window.gx) {
					if (typeof (info.onReady) === 'function')
						info.onReady();
				}
			},

			doMultipartPost: function (info) {
				gx.http.saveState(true);
				var iFrame = this.getPostIFrame();
				iFrame.gxPostInfo = info;
				var frm = info.formNode;
				info.oldAction = frm.getAttribute('action');
				frm.setAttribute('action', info.url);
				info.oldTarget = frm.getAttribute('target');
				frm.setAttribute('target', this.iframeName);
				if (info.reqData) {
					gx.http.saveHidden(GX_AJAX_MULTIPART_ELEMENT_ID, info.reqData, true);
					this.setSecurityToken(null, info.gxO);
				}
				frm.submit();
			},

			setSecurityToken: function (req, gxO) {					
				var token = gx.ajax.getSecurityToken(gxO);
				if (token) {
					if (gx.dom.hasSelectedFile())
						gx.http.saveHidden(GX_AJAX_AUTH_TOKEN, token.value, true);
					else
						req.setRequestHeader(GX_AJAX_AUTH_TOKEN, token.value);	
				}					
			},
			
			useReadyStateEvent: function () {
				return gx.util.browser.isIE() && gx.util.browser.ieVersion() < 11;
			},

			iFrameloadEventName: function () {
				return this.useReadyStateEvent() ? 'readystatechange' : 'load';
			},

			getPostIFrame: function () {
				var name = this.iframeName;
				var iFrame = gx.dom.byId(name);
				if (iFrame && iFrame.frameElement) {
					iFrame = iFrame.frameElement;
				}
				if (!iFrame) {
					var div = document.createElement('div');
					div.innerHTML = '<iframe id="' + name + '" name="' + name + '" src="about:blank">';
					document.body.appendChild(div);
					iFrame = div.firstChild;
					document.body.appendChild(iFrame);
					window[name] = iFrame;
					iFrame.name = name;
					iFrame.setAttribute('name', name);
					iFrame.id = name;
					iFrame.style.position = 'absolute';
					iFrame.style.left = '0px';
					iFrame.style.top = '0px';
					iFrame.style.height = '1px';
					iFrame.style.width = '1px';
					iFrame.style.visibility = 'hidden';
				}
				gx.evt.attach(iFrame, this.iFrameloadEventName(), gx.http.iframeOnload);
				return iFrame;
			},
			
			iFrameJsonResponse: function (frameBody) {
				return $(frameBody).find("input[data-response-content-type='application/json']").val();				
			},
			
			captureIframeHTTPStatusCode: function(frameDoc) {
				var regExp = /HTTP Status (\d\d\d)/gi,
				status = 0;
				
				if (frameDoc.title) {
					var cap = regExp.exec( frameDoc.title);
					if (cap.length > 0) {
						status = Number(cap[1]);
					}
				}
				return {status:status};				
			},
			
			iframeOnload: function () {
				var iFrame = gx.dom.byId(gx.http.iframeName);
				if (gx.http.useReadyStateEvent()) {
					if (iFrame.readyState != 'complete') {
						return;
					}
				}
																			
				gx.evt.setProcessing(false, !gx.csv.validating);
				if (!iFrame)
					iFrame = window.frames[gx.http.iframeName];
				if (iFrame && iFrame.frameElement) {
					iFrame = iFrame.frameElement;
				}
				if (iFrame) {
					if (gx.http.useReadyStateEvent()) {
						iFrame.src = "about:blank";
						gx.evt.detach(iFrame, gx.http.iFrameloadEventName(), gx.http.iframeOnload);
					}
					var info = iFrame.gxPostInfo;
					var frm = info.formNode;
					frm.setAttribute('action', info.oldAction);
					frm.setAttribute('target', info.oldTarget);
					var frameDoc = iFrame.contentDocument ? iFrame.contentDocument : iFrame.contentWindow.document;
					if (frameDoc) {							
						var frameBody = frameDoc.body;								
													
						var base64Response = gx.http.iFrameJsonResponse(frameBody);
						var isGxMultpartResponse = !gx.lang.emptyObject(base64Response);
						
						if (!isGxMultpartResponse) {  //When fullajax and no fullajax objects are mixed. 
							isGxMultpartResponse = gx.dom.allChildrenAreText(frameBody);
							if (isGxMultpartResponse)
								base64Response = gx.http.multipartResponse(frameBody);
						}
						if (isGxMultpartResponse) {
							var response = gx.base64.decode(base64Response);
							gx.http.clearMultipartHidden();
							info.handler(null, response, info);
							if (window.gx) {
								if (typeof (info.onReady) === 'function')
									info.onReady();
							}
							if (info.always) {
								info.always.call(info.obj || window, null, info);
							}
						}
						else {
							var event = gx.http.captureIframeHTTPStatusCode(frameDoc);
							if (!gx.http.checkResponseStatus(event, info.warnOnTimeout)) {
								document.write(frameDoc.documentElement.innerHTML);
							}
						}
					}
				}
			},

			multipartResponse: function (body) {
				var responseText = '';
				try {
					responseText = $(body).text();
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'multipartResponse');
				}
				return responseText;
			},

			uncache: function (url) {
				var date = new Date();
				var time = date.getTime();
				return url + gx.http.urlParameterPrefix(url) + 'gx-no-cache=' + time
			},

			callBackend_simple: function (sURL, ExecAtFail, AvoidFormDisable, Method, PostData, AvoidUncache, Async, Headers) {
				gx.http.callBackend_impl( undefined, sURL, ExecAtFail, gx.http.modes.none, AvoidFormDisable, Method, PostData, AvoidUncache, Async, Headers);
			},

			callBackend: function (backcall, sURL, sufix, ExecAtFail, Mode, AvoidFormDisable, Method, PostData, AvoidUncache, Async, Headers) {
				gx.http.callBackend_impl( backcall, sURL, ExecAtFail, Mode, AvoidFormDisable, Method, PostData, AvoidUncache, Async, Headers);
			},

			callBackend_impl: function (backcall, sURL, ExecAtFail, Mode, AvoidFormDisable, Method, PostData, AvoidUncache, Async, Headers, failCallback) {
				var _xmlHttp = this.getRequest();
				var Headers = Headers || {};
				if (_xmlHttp) {
					try {
						var gxO = gx.O;
						if (!AvoidFormDisable) {
							gxO.startFeedback();
						}
						var reqMethod = (typeof (Method) != 'undefined') ? Method : 'GET';
						var reqData = (typeof (PostData) != 'undefined') ? PostData : null;
						var async = (typeof (Async) != 'undefined') ? Async : false;
						if (!AvoidUncache) {
							sURL = this.uncache(sURL);
						}
						_xmlHttp.open(reqMethod, sURL, async);
						_xmlHttp.setRequestHeader(gx.ajax.reqHeader, '2');
						for (var H in Headers)
							_xmlHttp.setRequestHeader(H, Headers[H]);
						try {
							if (reqMethod == 'POST')
								_xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
							else if (gx.sec.secToken && gx.O.AjaxSecurity && gx.pO.OnSessionTimeout == gx.timeoutActions.ignore)
								_xmlHttp.setRequestHeader(gx.sec.secTokenName, gx.sec.secToken);
						}
						catch(e)
						{
							gx.dbg.logEx(e, 'gxapi.js', 'callBackend_impl: gx.O cannot be null');
						}

						var callback = (function () {
							if (!AvoidFormDisable) {
								gxO.endFeedback();
							}
							this.lastStatus = _xmlHttp.status;
							this.lastResponse = _xmlHttp.responseText;
							if ((_xmlHttp.readyState != this.STATE_DONE) || (_xmlHttp.status != this.STATUS_OK)) //Firefox and Chrome will go with onerror handler. 
							{
								if (!gx.http.checkResponseStatus(_xmlHttp)) //Check for session timeout or forbidden status code. If not, will not refresh page, so continue with error. 
								{
									window.status = 'GXAjax HTTP error: (' + _xmlHttp.status + ') - ' + _xmlHttp.statusText;
									gx.dbg.logEx(_xmlHttp.responseText);
									if (failCallback) {
										failCallback();
									}
								}
							}
							else {
								if (Mode != this.modes.none) {
									if (this.lastResponse && this.lastResponse.length > 0 && this.lastResponse.charAt(0) != '<') {
										this.lastStatus = 0;

										try {
											if (Mode == this.modes.full)
												this.handleFull(this.lastResponse)
											else
												if (Mode == this.modes.call)
													return this.handleCall(this.lastResponse, backcall)
											return this.handleRetVal(this.lastResponse, backcall, ExecAtFail)
										}
										catch (e) {
											gx.dbg.logEx(e, 'gxapi.js', 'callBackend');
											if (failCallback) {
												failCallback();
											}
										}
									}
									else {
										window.status = 'GXAjax HTTP error: (bad response format)';
										if (failCallback) {
											failCallback();
										}
									}
								}
							}
						}).closure(this)

						if (async) {
							if (gx.util.browser.isIE() && gx.util.browser.ieVersion() <= 9) {
								_xmlHttp.onreadystatechange = callback;
							}
							else {
								_xmlHttp.onload = callback;
							}
						}
						_xmlHttp.send(reqData);

						if (!async) {
							callback();
						}
					}
					catch (e) {
						window.status = 'GXAjax HTTP error: ' + e.message;
					}
					window.status = '';
				}
			},

			handleFull: function (Response) {
				var event = {};
				event.status = 200;
				event.responseText = "";
				gx.http.postHandler(null, Response, event);
			},

			handleCall: function (ResponseText, backcall) {
				if (backcall) {
					var arr = $.parseJSON(ResponseText);
					if (gx.lang.isArray(arr))
						return backcall( arr);
					gx.dbg.logEx(e, 'gxapi.js', 'handleCall: Unexpected server response format (Expected array): ' + ResponseText);
				}
			},

			handleRetVal: function (ResponseText, backcall, ExecAtFail) {
				var Response = gx.json.evalJSON(ResponseText);
				var result = Response[0];
				this.lastStatus = Response[1];
				if (this.lastStatus == undefined)
					this.lastStatus = 0;
				if (backcall && (ExecAtFail || this.lastStatus == null || this.lastStatus == 0)) {
					var arr = $.parseJSON(ResponseText);
					if (gx.lang.isArray(arr))
						return backcall( arr);
					gx.dbg.logEx(e, 'gxapi.js', 'handleCall: Unexpected server response format (Expected array): ' + ResponseText);
				}
				else
				{
					return result;
				}
			},

			postHandler: function (type, data, event, ctx) {
				try {
					gx.csv.lastEvtResponse = null;

					 if (event.status < 200 || event.status > 299) {
						 gx.dom.writeError( event.responseText, gx.getMessage("GXM_runtimeappsrv"), event.status);
					 }
					 else {
						 if (gx.http.validJsonResponse( event, data)) {
							var DataObj = gx.json.evalJSON(data);
							if (DataObj == null)
								gx.dom.writeError( data.toString(), gx.getMessage("GXM_runtimeappsrv"), event.status)
							 else {
								gx.http.refreshState();
								gx.csv.lastEvtResponse = DataObj;
								gx.fn.forceEnableControls(true);
								gx.ajax.setPostResponse(DataObj, gx.O, ctx).done(function (willLeavePage) {
									if (!willLeavePage) {
										gx.fx.obs.notify('gx.onafterevent', [DataObj]);
										gx.fx.obs.notify('gx.afterNonFullajax');
									}
								});
							}
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'postHandler');
				}
			},

			encodeUriSegment: function (queryParm) {
				return encodeURIComponent(queryParm).replace(/%20/g, '+');
			},

			formatLink: function (url, parms, paramNames) {
				url = gx.ajax.objectUrl(url);
				if (parms && parms.length > 0) {
					var separator = ',';
					var parmName = '';
					if (paramNames) {
						separator = '&';
					}
					url += '?';
					var len = parms.length;
					for (var i = 0; i < len; i++) {
						if (i > 0) {
							url += separator;
						}
						if (paramNames) {
							parmName = paramNames[i] + '=';
						}
						url += parmName + gx.http.encodeUriSegment(typeof(parms[i].getUrlVal) == 'function' ? parms[i].getUrlVal() : parms[i]);
					}
				}
				return url;
			},

			loadScripts: function (scripts, callback, i, ignoreExisting) {
				if (typeof (i) == 'undefined') {
					i = 0;
				}
				if (i >= scripts.length) {
					callback();
				}
				else {
					gx.http.loadScript(scripts[i], (function (scripts, callback, i) {
						gx.http.loadScripts(scripts, callback, i + 1, ignoreExisting);
					}).closure(this, [scripts, callback, i]), ignoreExisting);
				}
			},

			loadStyle: function (url, callback, beforeTheme, id) {
				var style = id ? gx.dom.byId(id) : null;
				var enablePreloading = false;
				if (style) {
					style.href = url;
				}
				else {
					var head = gx.dom.byTag('head')[0];
					style = document.createElement("link");
					//disabled for gx-ui compatibility issue 69571
					if (enablePreloading && style.as != undefined) {
						style.rel = 'preload';
						style.as = 'style';
					}
					else {
						style.rel = 'stylesheet';
					}
					style.type = 'text/css'
					style.href = url;
					if (typeof (callback) == 'function') {
						style.onload = callback;
					}
					if (beforeTheme) {
						var themeEl = gx.getThemeElement();
						$(style).insertBefore(themeEl);
						// Workaround for IE because it considers every dynamically added stylesheets with more weight
						// thant does statically declared in the HTML, regardless its position in the DOM tree.
						if (gx.util.browser.isIE()) {
							$(themeEl).insertAfter(style);
						}
					}
					else {
						head.appendChild(style);
					}
				}
			},

			applyDeferredStyles: function () {
				$("link[rel='preload'][as='style']").each( function(i,el) {
					el.rel = "stylesheet";
				});
			},
			
			loadStyles: function () {
				var styles = gx.fn.getHidden('GX_STYLE_FILES');
				if (!gx.lang.emptyObject(styles)) {
					for (var i = 0; i < styles.length; i++) {
						var style = styles[i];
						style = gx.util.resolveUrl(style);
						if (!gx.cache.fileLoaded(style)) {
							gx.cache.addRemoteFile(style);
							this.loadStyle(style);
						}
					}
				}
			},

			doCommands: function () {
				var cmds = gx.fn.getHidden('GX_SRV_COMMANDS');
				if (!gx.lang.emptyObject(cmds)) {
					gx.ajax.dispatchCommands(cmds);
				}
			},

			isOffline: function (req) {
				return req.getResponseHeader("X-GX-OFFLINE") === "1";
			},
			
			handleOffline: function (req) {
				gx.util.alert.showError(gx.getMessage('GXM_OfflineUnsupported'));
			},

			useNamedParameters: function (queryString) {
				if (gx.csv.useNamedParameters === false) {
					return false;
				}				
				return queryString.indexOf('=') > -1;
			},
			urlParameterSeparator: function (queryString) {
				return this.useNamedParameters(queryString) ? '&' : ',';
			},
			urlParameterPrefix: function (url) {
				var indexOfQuery = url.indexOf('?');
				if (indexOfQuery > -1) {
					if (indexOfQuery == url.length - 1)
						return '';
					else
						return this.urlParameterSeparator(url);
				} else {
					return '?';
				}
			}			
		}
})(gx.$);

gx.$.extend( gx.evt, gx.evt_i);
gx.$.extend( gx.csv, gx.csv_i);
gx.$.extend( gx.http, gx.http_i);

var defaultConfig = {	
	popup: {
		ignoreCmdsOnCancel: false
	},
	
	websocket: {		
	},
	
	timezone: {
		reload: true
	},
	
	evt: {
		dblclick: {
			delay: 450
		}
	},

	csv: {
		scrollTopOnError: false
	}
};

gx.config = gx.$.extend( {}, defaultConfig, window["gxCustomConfig"] || {} );

var GlobalEvents = (function ($) {
	return {		
		executeMethod: function(methodName, parms) {			
			gx.fx.obs.notify(methodName, parms);
			try {
				var parentWindow = window;
				while (parentWindow != null && parentWindow.parent !== parentWindow) {
					parentWindow = parentWindow.parent;
					if (parentWindow != window && parentWindow.gx) {						
						parentWindow.gx.fx.obs.notify(methodName, parms);
					}
				}					
			}
			catch (e) {}
		}
	};
})(jQuery);

if (gx.util.browser.isIE())
{
(function () {

  if ( typeof window.CustomEvent === "function" ) return false;

  function CustomEvent ( event, params ) {
    params = params || { bubbles: false, cancelable: false, detail: undefined };
    var evt = document.createEvent( 'CustomEvent' );
    evt.initCustomEvent( event, params.bubbles, params.cancelable, params.detail );
    return evt;
   }

  CustomEvent.prototype = window.Event.prototype;

  window.CustomEvent = CustomEvent;
})();
}

gx.fx.obs.addObserver('gx.onload', gx, function () {
	var serviceWorkerOptions = {};
	if (gx.serviceWorkerUrl) {
		if ('serviceWorker' in navigator) {
			if (gx.staticDirectory) {
				if (gx.basePath)
					serviceWorkerOptions = {
						scope: gx.util.resourceUrl(gx.basePath, false) + "/"
					};
			}
			navigator.serviceWorker
				.register(gx.serviceWorkerUrl, serviceWorkerOptions)
				.then(function (registration) {
					console.log('Service Worker Registered:', gx.serviceWorkerUrl, 'scope: ', registration.scope);
				});
		}
	}
});

/* END OF FILE - ..\js\gxapi_i.js - */
/* START OF FILE - ..\js\gxfrmutl_i.js - */
(function($) {
	var prot = gx.GxObject.prototype;
	
	prot.sPrefix = function() { 
		return this.CmpContext;
	};

	prot.declareDomainHdlr = function( id, fnc) {
		this.GXValidFnc[id].dom_hdl = fnc;
	};

	prot.setVCMap = function (ctrlName, id, grid, type ,len, dec) {
		this.VarControlMap[ctrlName] = {
			id: id,
			grid: grid,
			type: type,
			length: len,
			decimals: dec
		};
	};

	prot.setSDTMapping = function (SDTType, metadata) {
		this.SDTMap = this.SDTMap || {};
		this.SDTMap[SDTType] = metadata;
		var extrn = {};
		for (var pty in metadata) {
			if (metadata[pty].extr) {
				extrn[metadata[pty].extr] = pty;
			}
		} 
		metadata.extrn = extrn;
	};	
	
	prot.applySDTVarMapping = function( Target, Varname) {
		var Typename;
		if (this.VarControlMap[Varname] && this.VarControlMap[Varname].type) {
			Typename = this.VarControlMap[Varname].type;
		}
		return this.applySDTMapping( Target, Typename, true);
	};
	
	prot.applySDTMapping = function( Target, Typename, modeImport) {
		if (Target && Typename) {
			var Mapping = this.SDTMap ? this.SDTMap[Typename] : undefined;
			var pty;
			if (Mapping){
				for (pty in Mapping.extrn) {
					if (modeImport) {
						//fromJson
						Target[Mapping.extrn[pty]] = Target[pty];
						delete Target[pty];
					}
					else {
						//ToJson
						Target[pty] = Target[Mapping.extrn[pty]];
						delete Target[Mapping.extrn[pty]];						
					}
				}
				for (pty in Mapping) {
					if (Mapping[pty].sdt) {
						var collLength = Target[pty] ? Target[pty].length : 0;
						if (collLength)	{
							for (var i = 0; i< collLength; i++) {
								this.applySDTMapping( Target[pty][i], Mapping[pty].sdt, modeImport);
							}							
						}
						else {
							this.applySDTMapping( Target[pty], Mapping[pty].sdt, modeImport);
						}
					}
				}
			}
		}
		return Target;
	};

	prot.Initialize = function () {
		this.InitStandaloneVars();
		gx.wpo(function() {
			this.initTargets();
		}, this);
	};

	prot.InitStandaloneVars = function () {
		var oldGxo = gx.O;
		gx.setGxO(this);
		this.SetStandaloneVars();
		if (oldGxo != null) {
			gx.setGxO(oldGxo);
		}
	};

	prot.getCmpType = function (cmpContext) {
		var cmpType = this.cmpRegex.exec(cmpContext);
		this.cmpRegex.lastIndex = 0;
		return cmpType;
	};

	prot.getContainer = function () {
		if (this.containerControl) {
			return gx.dom.byId(this.containerControl);
		}

		if (!this.CmpContext && !this.IsMasterPage)
			return $('.gx-content-placeholder').get(0) || document.body;

		var cmpCtrl,
			cmpType = this.getCmpType(this.CmpContext);

		if (cmpType)
			cmpCtrl = gx.dom.byId(cmpType[1] + "gxHTMLWrp" + cmpType[2] + (cmpType[3] || ''));
		if (cmpCtrl)
			return cmpCtrl;
	};

	prot.setContainer = function (container) {
		this.containerControl = container;
	};

	prot.setObjectType = function (Type) {
		this.ObjectType = Type;
	};

	prot.getObjectType = function () {
		return this.ObjectType;
	};

	prot.isTransaction = function () {
		if (this._isTrn != null) {
			return this._isTrn;
		}
		this._isTrn = (this.getObjectType() == 'trn');
		return this._isTrn;
	};

	prot.setAjaxSecurity = function (enabled) {
		this.AjaxSecurity = enabled;
	};

	prot.setOnAjaxSessionTimeout = function (action) {
		switch (action) {
			case 'Warn':
				this.OnSessionTimeout = gx.timeoutActions.warn;
				break;
			case 'CallObj':
				this.OnSessionTimeout = gx.timeoutActions.callObj;
		}
	}
	prot.addKeyListener = function (fKey, evt) {
		gx.evt.addKeyListener(this.CmpContext, fKey, evt);
	};

	prot.clearMessages = function () {
		this.MsgList.length = 0;
	};

	prot.addMessage = function (Msg) {
		this.MsgList.push(Msg);
	};

	prot.showMessages = function (keepMsgs) {
		var msgsArr = [];
		var len = this.MsgList.length;
		for (var i = 0; i < len; i++) {
			var msgItem = this.MsgList[i];
			if (typeof(msgItem) === 'string')
				msgsArr.push({ att: '', type: 2, text: this.MsgList[i] });
			else
				msgsArr.push(msgItem);
		}
		var msgs = {};
		var msgsKey = (this.CmpContext == '') ? 'MAIN' : this.CmpContext;
		msgs[msgsKey] = msgsArr;
		if (keepMsgs)
			gx.fn.setErrorViewer(msgs, false);
		else
			gx.fn.setErrorViewer(msgs);
		this.clearMessages();
	};

	prot.setPrompt = function (CtrlId, Deps) {
		gx.fn.attachCtrl(this.CmpContext + CtrlId, { id: CtrlId, isPrompt: true, wc: this.CmpContext, mp: this.IsMasterPage, controls: Deps, obj: this });
		if (!this.promptKeyHandlers)
			this.promptKeyHandlers = {};
			this.promptKeyHandlers[CtrlId] = function (ctrl) {
			var el = ctrl || gx.dom.el(CtrlId);
			var anchor = el.parentNode;
			if (anchor && anchor.href) {
				var match = anchor.href.match("javascript:(.+)");
				if (match && match.length > 1) {
					var code = decodeURIComponent(match[1]);
					try {
						eval(code);
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxfrmutl.js', 'setPrompt');
					}
				}
			}
		};
	};

	prot.readServerVars = function () {
		if (!gx.lang.emptyObject(gx.csv.lastEvtResponse)) {
			var objValues = [];
			var vals = gx.csv.lastEvtResponse.gxValues;
			var len = vals.length;
			for (var i = 0; i < len; i++) {
				var objV = vals[i];
				if (objV.CmpContext == this.CmpContext && gx.lang.booleanValue(objV.IsMasterPage) == this.IsMasterPage) {
					objValues.push(objV);
					break;
				}
			}
			gx.fn.setJsonValues(objValues);
		}
	};

	prot.call = function (objUrl, args, target, paramNames) {
		if (gx.nav.willRedirect(objUrl)) {
			if (gx.csv.useNamedParameters === false) {
				paramNames = undefined;
			}
			this.postEventRedirect = {
				url: gx.http.formatLink(objUrl, args, paramNames),
				forceDisableFrm: false
			};
		}
		else {
			gx.nav.call.apply(gx.nav, arguments);
		}
	};

	prot.callUrl = function (objUrlWithParms, target) {
		if (gx.nav.willRedirectByUrl(objUrlWithParms)) {
			this.postEventRedirect = {
				url: objUrlWithParms,
				forceDisableFrm: false
			};
		}
		else {
			gx.nav.callUrl.apply(gx.nav, arguments);
		}
	};

	prot.popupOpen = function (popupData) {
		this.postEventPopupCommands.push({
			popup: gx.lang.clone(popupData)
		});
	};

	prot.popupOpenUrl = function (url, parms) {
		this.postEventPopupCommands.push({
			popup: gx.popup.openUrlToOpenPopupParms(url, parms)
		});
	};

	prot.refreshInputs = function (Inputs) {
		var len = Inputs.length;
		for (var i = 0; i < len; i++) {
			var inObj = Inputs[i];
			var validStruct = this.getValidStructFld(inObj[1]);
			if (validStruct != null && typeof (validStruct.c2v) == 'function')
				validStruct.c2v();
		}
	};

	prot.refreshOutputs_impl = function (Outputs) {
		var controls = [];
		for (var i = 0, len = Outputs.length; i < len; i++) {
			var outObj = Outputs[i];
			if (outObj.fld) {
				var validStruct = this.getValidStructFld(outObj.fld);
				if (validStruct != null) {
					gx.fn.v2c(validStruct);
					var ctrl = gx.fn.getControlGridRef(validStruct.fld, validStruct.grid);		
					gx.csv.invalidateGXCtrl(ctrl);				
					gx.fn.setControlOldValue(ctrl, validStruct.val());
				}
				else {
					var varValue = this.getVariable(outObj.av);
					if (varValue != null && typeof (varValue) == 'object') {
						var formBC = this.getFormBCForVar(outObj.av);
						if (formBC != null) {
							this.bcToScreen(formBC, varValue);
						}
						var boundGrid = this.getGridForColl(outObj.av);
						if (boundGrid) {
							boundGrid.refreshCollection(varValue);
						}
					}
					gx.fn.setHidden(gx.csv.ctxControlId(outObj.fld, this), varValue);
				}
			}
			else if (outObj.ctrl) {
				controls.push(outObj);
			}
		}
		gx.uc.StartRender();
		for (var i = 0, len = controls.length; i < len; i++) {
			var outObj = controls[i];
			if (gx.uc.isUserControl(outObj.ctrl)) {
				outObj.ctrl.execV2CFunctions(false);
				outObj.ctrl.execShowFunction();
			}
		}
		gx.uc.EndRender();
	};
	
	prot.OnClientEventEnd = function() {
		gx.fn.usrSetFocus_commit();
	};

	prot.refreshOutputs = function (Outputs) {
		var commands = this.postEventPopupCommands;
		this.postEventPopupCommands = [];

		if (this.postEventRedirect) {
			commands.push({
				redirect: this.postEventRedirect
			});
			delete this.postEventRedirect;
		}

		if (commands.length > 0) {
			gx.ajax.dispatchCommands(commands);
		}
		this.refreshOutputs_impl(Outputs);
		this.showMessages();
	};

	prot.refreshRowOutputs = function (Outputs) {
		this.refreshOutputs_impl(Outputs);
	};

	prot.refreshServerOutputs = function (Outputs) {
		var len = Outputs.length;
		for (var i = 0; i < len; i++) {
			var outObj = Outputs[i];
			var hiddenValue = gx.fn.getHidden(this.CmpContext + outObj.fld);
			if (hiddenValue != undefined) {
				var vStruct = this.getValidStructFld(outObj.fld);
				if (vStruct && vStruct.v2v) {
					vStruct.v2v(hiddenValue);						
					gx.fn.v2c(vStruct, hiddenValue);
				}
				else {
					this.setVariable(Outputs[i].av, hiddenValue);
				}
			}
		}
	}

	prot.getContextObject = function (ControlId) {
		var validStruct = this.getValidStructFld(ControlId);
		if (validStruct != null) {
			var Value = gx.fn.getControlValue_impl(this.CmpContext + ControlId);
			if (Value != null)
				return Value;
		}
		return "";
	};

	prot.getValidStructId = function (Fld) {
		if (!gx.lang.emptyObject(Fld)) {
			var ctrlIds = this.getControlIds();
			for (var i = 0; i < ctrlIds.length; i++) {
				var validStruct = this.getValidStruct(ctrlIds[i]);
				if (this.isSameField(validStruct, Fld))
					return ctrlIds[i];
			}
		}
		return -1;
	};

	prot.getValidStructFld = function (Fld) {
		if (typeof Fld == 'function' || typeof Fld == 'object' && Fld.tagName) {
			if (typeof Fld == 'object' && (Fld.type === 'radio') && Fld.name) {
				Fld = Fld.name;
			}
			else {
				Fld = gx.dom.id(Fld);
			}
		}
		var cachedValue = this.getValidStructFld_cache[Fld];
		if (cachedValue)
			return cachedValue;
		if (!gx.lang.emptyObject(Fld)) {
			var ctrlIds = this.getControlIds();
			var len = ctrlIds.length;
			for (var i = 0; i < len; i++) {
				var validStruct = this.getValidStruct(ctrlIds[i]);
				if (this.isSameField(validStruct, Fld)) {
					this.getValidStructFld_cache[Fld] = validStruct;
					return validStruct;
				}
			}
		}
		this.getValidStructFld_cache[Fld] = null;
		return null;
	};

	prot.isSameField = function (validStruct, TestFld) {
		var Fld = validStruct.fld;
		if (Fld == TestFld) {
			return true;
		}
		if (this.IsComponent) {
			var ctxIdx = TestFld.indexOf(this.CmpContext);
			if (ctxIdx == 0)
				TestFld = TestFld.substring(this.CmpContext.length);
		}
		if (validStruct.grid != 0) {
			TestFld = TestFld.replace(this.rowPatternRegex, '')
		}
		if (this.IsMasterPage) {
			Fld = Fld.replace(/_MPAGE$/,'');
			TestFld = TestFld.replace(/_MPAGE$/,'');
		}
		return (Fld == TestFld);
	};

	prot.getUserFocus = function () {
		var usrFocusId = gx.fn.getHidden(this.CmpContext + 'GX_FocusControl');
		if (!gx.lang.emptyObject(usrFocusId) && usrFocusId != 'notset') {
			var Control = gx.dom.byId(usrFocusId);
			if (!gx.lang.emptyObject(Control) && !gx.fn.isAccepted(Control)) {
				var tCmp = gx.csv.cmpCtx;
				gx.csv.cmpCtx = this.CmpContext;
				var tgxo = gx.O;
				gx.O = this;
				Control = gx.fn.firstAcceptedControl(gx.popup.ispopup());
				gx.O = tgxo;
				gx.csv.cmpCtx = tCmp;
				if (!gx.lang.emptyObject(Control))
					usrFocusId = Control.id;
				else
					usrFocusId = "";
			}
		}
		if (gx.lang.emptyObject(usrFocusId)) {
			if (this.hasMasterPage()) {
				usrFocusId = this.MasterPage.getUserFocus();
				if (!gx.lang.emptyObject(usrFocusId))
					return usrFocusId;
			}
			var mpComponents = [];
			for (var i = 0; i < this.WebComponents.length; i++) {
				//Components in the current object first
				if (this.WebComponents[i].CmpContext.indexOf('MP') == 0)
					mpComponents.push(this.WebComponents[i]);
				else {
					usrFocusId = this.WebComponents[i].getUserFocus();
					if (!gx.lang.emptyObject(usrFocusId))
						return usrFocusId;
				}
			}
			for (var j = 0; j < mpComponents.length; j++) {
				//Components in the master page
				usrFocusId = mpComponents[j].getUserFocus();
				if (!gx.lang.emptyObject(usrFocusId))
					return usrFocusId;
			}
		}
		return usrFocusId;
	};

	prot.getGridColumn = function(ControlId, rowId) {
		var GridColumn = null,
			gridObj = null,
			gridId = gx.fn.controlGridId(ControlId);
		if (gridId != 0) {
			gridObj = gx.O.getGridById(gridId, rowId);
			if (gridObj) {
				GridColumn = gridObj.grid.getColumnByHtmlName(ControlId);
			}
		}
		return GridColumn;
	};

	prot.hasMasterPage = function () {
		return (this.MasterPage != null);
	};

	prot.setComponent = function (CmpCtrl) {
		this.CmpControls[CmpCtrl.id.toLowerCase()] = CmpCtrl;
	};

	prot.getComponentByPrefix = function (cmpCtx) {		
		var Cmps = $.map(this.CmpControls, function(Cmp,i) {
			return (Cmp.Prefix == cmpCtx) ? Cmp : null;
		});
		return Cmps.length == 1 ? Cmps[0] : null;
	};

	prot.refreshGrid = function(GridCtrl)
	{
		var grid = this.getGrid(GridCtrl);
		if (grid) {
			grid.doRefresh();
		}
	}

	prot.refreshComponent = function ( CmpCtrl) {
		var cmp = this.getWebComponent(this.CmpContext + this.getComponentData(CmpCtrl).Prefix);
		if (cmp) {
			gx.evt.dispatcher.dispatch('REFRESH', cmp);
		}
		else {
			var gridId = gx.fn.controlGridId(CmpCtrl);
			if (gridId !== 0) {
				cmp = gx.pO.getWebComponent(this.CmpContext + this.getComponentData(CmpCtrl).Prefix + gx.fn.currentGridRow(gridId));
				if (cmp)
					gx.evt.dispatcher.dispatch('REFRESH', cmp);
			}
		}
	};

	prot.getComponentPrefix = function (CtrlName) {
		var wc = this.getComponentData(CtrlName);
		if (wc) {
			return (wc.Prefix || '');
		}
		return '';
	};

	prot.getComponentData = function (CtrlName) {
		return this.CmpControls[CtrlName.toLowerCase()];
	};

	prot.createWebComponent = function (CtrlName, PgmName, Parms, gRow, TargetCtrlId, CmpPrefix, callback) {
		var gridId, targetEl;
		CmpPrefix = CmpPrefix || this.getComponentPrefix(CtrlName);
		if (!gRow)
		{
			gridId = gx.fn.controlGridId(CtrlName);
			gRow = (gridId !== 0) ? gx.fn.currentGridRow(gridId) : '';
		}
		TargetCtrlId = TargetCtrlId || this.CmpContext + 'gxHTMLWrp' + CmpPrefix + gRow;
		CmpPrefix = this.CmpContext + CmpPrefix;
		var gxO = gx.getObj(CmpPrefix, false);
		if (gxO) {
			gxO.startFeedback();
		}
		else {
			targetEl = gx.dom.byId(TargetCtrlId);
			if (targetEl.firstChild) {
				gx.dom.mask(TargetCtrlId);
			}
		}
		var javaPackage = (gx.gen.isJava() && gx.pO.PackageName && !gx.text.startsWith(PgmName, '/')) ? gx.pO.PackageName + '.' : "";
		gx.ajax.dynComponent(javaPackage + PgmName, Parms, CmpPrefix, gRow).done(function (srvResponse) {
			if (!srvResponse.DynComponentMap) {
				srvResponse.DynComponentMap = {};
			}
			srvResponse.DynComponentMap[CmpPrefix + gRow] = TargetCtrlId;
			gx.ajax.setJsonResponse({
				response: srvResponse, 
				isPostBack: true, 
				gxObject: gxO || gx.O, 
				afterCmpLoaded: function () {
					if (callback) {
						callback(CmpPrefix);
					}
				}
			});
			if (gxO) {
				gxO.endFeedback();
			}
			else {
				gx.dom.unmask(TargetCtrlId);
			}
		});
	};

	prot.registerComponent = function (gxComponent) {
		this.WebComponents[gxComponent.CmpContext] = gxComponent;
		this.WebComponents.push(gxComponent);
	};

	prot.setWebComponent = function (gxComponent, gxHiddens) {
		this.deleteComponent(gxComponent.CmpContext, gxComponent, false);
		if (gxHiddens) {
			this.restoreComponentHiddens(gxComponent.CmpContext, gxHiddens);
		}
		this.registerComponent(gxComponent);
		gxComponent.JustCreated = true;
		gx.fn.setHidden(gxComponent.CmpContext, gxComponent.ServerClass);
		gx.fx.obs.notify('webcom.render', [gxComponent]);
	};

	prot.getWebComponent = function (cmpCtx) {
		return this.WebComponents[cmpCtx];
	};

	prot.deleteComponent = function (cmpCtx, newCompObj, deleteHiddens) {
		deleteHiddens = typeof(deleteHiddens) == 'undefined' ? true : deleteHiddens;
		var cmpObj = this.getWebComponent(cmpCtx);
		if (cmpObj) {
			var javaPackage = (gx.gen.isJava() && cmpObj.PackageName) ? cmpObj.PackageName + '.' : "";
			gx.cache.deleteInlineCode(cmpCtx + javaPackage + cmpObj.ServerClass.toLowerCase());
			if (deleteHiddens)
				this.deleteComponentHiddens(cmpCtx);
			if (!gx.lang.emptyObject(newCompObj))
				gx.fn.setHidden(newCompObj.CmpContext, newCompObj.ServerClass);
			cmpObj.ondestroy();
			delete this.WebComponents[cmpCtx];
			var len = this.WebComponents.length;
			for (var i = 0; i < len; i++) {
				if (this.WebComponents[i].CmpContext == cmpCtx) {
					this.WebComponents.splice(i, 1);
					break;
				}
			}
			var j = gx.attachedControls.length;
			while (j--) {
				var aCtrl = gx.attachedControls[j];
				if (aCtrl.info.wc === cmpCtx){
					gx.attachedControls.splice(j, 1);
				}
			}
			var localArray = this.WebComponents;
			for (var currentCtx in localArray) {
				if (isNaN(parseInt(currentCtx))) {
					if (currentCtx.indexOf(cmpCtx) === 0) {
						this.deleteComponent(currentCtx);
					}
				}
			}
		}
	};

	prot.deleteComponentHiddens = function (cmpCtx) {
		var cmpRegex;
		if (gx.lang.isArray(cmpCtx)) {
			if (cmpCtx.length == 0) {
				return;
			}
			cmpRegex = gx.fn.getCmpRegex("(" + cmpCtx.join("|") + ")");
		}
		else {
			cmpRegex = gx.fn.getCmpRegex(cmpCtx);
		}
		var hiddens = gx.fn.filterHiddens(cmpRegex, gx.http.viewState);
		for (var hiddenName in hiddens) {
			if (hiddenName)
				gx.fn.deleteHidden(hiddenName);
		}
	};

	prot.restoreComponentHiddens = function (cmpCtx, gxHiddens) {
		var cmpRegex = gx.fn.getCmpRegex(cmpCtx);
		var hiddens = gx.fn.filterHiddens(cmpRegex, gxHiddens);
		for (var hiddenName in hiddens) {
			if (hiddenName)
				gx.fn.setHidden(hiddenName, hiddens[hiddenName]);
		}
	};

	prot.setCmpContext = function (cmpCtx) {
		if (cmpCtx != undefined) {
			this.IsTypeComponent = true;
			if (cmpCtx !== '')
				this.IsComponent = true;
			this.CmpContext = cmpCtx;
		}
	};

	prot.getOldLvl = function (Name) {
		for (var lvl in this.LvlOlds) {
			var lvlOlds = this.LvlOlds[lvl];
			var len = lvlOlds.length;
			for (var i = 0; i < len; i++) {
				if (lvlOlds[i] == Name)
					return lvl;
			}
		}
		return -1;
	};

	prot.refreshDependantGrids = function (validStruct) {
		var len = this.Grids.length;
		for (var i = 0; i < len; i++) {
			var gxGrid = this.Grids[i];
			var refreshVars = gxGrid.refreshVars;
			var len1 = refreshVars.length;
			for (var j = 0; j < len1; j++) {
				if (refreshVars[j].fld == validStruct.fld) {
					gxGrid.filterVarChanged();
					break;
				}
			}
		}
	};

	prot.getCtrlPropertyValue = function (control, property) {
		var value = gx.fn.getCtrlProperty(control, property);
		if (value === undefined)
			value = gx.fn.getHidden(control + "_" + property);

		return value;
	};

	prot.setGrid = function (gxGrid) {
		this.Grids[gxGrid.gridName] = gxGrid;
		this.GridsUpper[gxGrid.gridName.toUpperCase()] = gxGrid;
		var gridIdx = this.getGridIdxByName(gxGrid.gridName);
		if (gridIdx != -1) {
			this.Grids[gridIdx] = gxGrid;
		}
		else {
			this.Grids.push(gxGrid);
		}
	};

	prot.getGrid = function (gridName) {
		gridName = gridName || '';
		return this.Grids[gridName] || this.GridsUpper[gridName.toUpperCase()];
	};

	prot.getGridIdxByProp = function (checkFnc) {
		var len = this.Grids.length;
		for (var i = 0; i < len; i++) {
			var gxGrid = this.Grids[i];
			if (checkFnc(gxGrid))
				return i;
		}
		return -1;
	};

	prot.getGridIdxByName = function (gridName) {
		return this.getGridIdxByProp( function(gxGrid) { return gxGrid.gridName === gridName});
	};

	prot.getGridByBaseName = function (gridName) {
		var idx = this.getGridIdxByProp( function(gxGrid) { return gxGrid.gridName === gridName || gxGrid.grid.GridBaseName === gridName});
		return idx === -1 ? null : this.Grids[idx];
	};

	prot.getGridIdx = function (gridId) {
		var len = this.Grids.length;
		for (var i = 0; i < len; i++) {
			var gxGrid = this.Grids[i];
			if (gxGrid.gridId == gridId)
				return i;
		}
		return -1;
	};

	prot.getGridById = function (gridId, row) {
		var row = row || '';
		var len = this.Grids.length;
		for (var i = 0; i < len; i++) {
			var gxGrid = this.Grids[i];
			if (gxGrid.gridId == gridId && (!gxGrid.parentRow || gx.text.endsWith(row, gxGrid.parentRow.gxId)))
				return gxGrid;
		}
		return null;
	};

	prot.getGridForColl = function (collVarName) {
		var len = this.Grids.length;
		for (var i = 0; i < len; i++) {
			var gxGrid = this.Grids[i];
			if (gxGrid.boundedCollName == collVarName)
				return gxGrid;
		}
		return null;
	};

	prot.getFormBCForVar = function (varName) {
		for (var bcName in this.FormBCs) {
			var bc = this.FormBCs[bcName];
			if (bc && bc.gxvar == varName)
				return bc;
		}
		return null;
	};

	prot.getGridBC = function (bcName) {
		var bcName1 = bcName;
		if (this.IsComponent) {
			var ctxIdx = bcName.indexOf(this.CmpContext);
			if (ctxIdx === 0)
				bcName1 = bcName.substring(this.CmpContext.length);
		}
		return this.GridBCs[bcName1];
	};

	prot.getFormBC = function (bcName) {
		var bcName1 = bcName;
		if (this.IsComponent) {
			var ctxIdx = bcName.indexOf(this.CmpContext);
			if (ctxIdx === 0)
				bcName1 = bcName.substring(this.CmpContext.length);
		}
		return this.FormBCs[bcName1];
	};

	prot.addGridBCProperty = function (bcName, bcProp, vStruct, bcVarName) {
		var bc = this.getGridBC(bcName);
		if (typeof (bc) == 'undefined') {
			bc = {};
			bc.gxvar = bcVarName;
			this.GridBCs[bcName] = bc;
		}
		this.addBCProperties(bc, bcProp, vStruct, bcVarName);
	};

	prot.addBCProperty = function (bcName, bcProp, vStruct, bcVarName) {
		var bc = this.getFormBC(bcName);
		if (typeof (bc) == 'undefined') {
			bc = {};
			bc.gxvar = bcVarName;
			this.FormBCs[bcName] = bc;
		}
		this.addBCProperties(bc, bcProp, vStruct, bcVarName);
	};

	prot.addBCProperties = function (bc, bcProp, vStruct, bcVarName) {
		if(bc){
			if (bcProp instanceof Array) {
				var obj = bc;
				var len = bcProp.length;
				var v2bcFunc = function () {
					var propValue = this[vStruct.gxvar];
					if (!gx.lang.emptyObject(vStruct.hc)) {
						propValue = this[vStruct.hc];
					}
					if (vStruct.type == 'date') {
						var dateObj = new gx.date.gxdate(propValue);
						propValue = dateObj.getString('Y4MD');
					}
					else if (vStruct.type === 'bitstr' && gx.pO.fullAjax) {
						var ctrl = gx.fn.getControlGridRef(vStruct.fld, vStruct.grid);
						if (ctrl && $(ctrl).val())
							propValue = "gxformdataref:" + ctrl.id;
					}
					this.valueToBCProp(this[bcVarName], bcProp, vStruct, propValue);
				};
				for (var i = 0; i < len; i++) {
					if (typeof (obj[bcProp[i]]) == 'undefined') {
						if (i < len - 1) {
							obj[bcProp[i]] = {};
						}
						else {
							obj[bcProp[i]] = vStruct;
							if (typeof (this[bcVarName]) == 'object') {
								vStruct.v2bc = v2bcFunc;
							}
							break;
						}
					}
					obj = obj[bcProp[i]];
				}
			}
			else if (typeof (bcProp) == 'string') {
				bc[bcProp] = vStruct;
			}
		}
	};

	prot.valueToBCProp = function (bc, bcProp, vStruct, pValue) {
		try {
			if(bc){
				var obj = bc;
				var len = bcProp.length;
				for (var i = 0; i < len; i++) {
					if (gx.lang.isArray(obj) && vStruct && vStruct.grid) {
						if (obj.length == 0)
							continue;
						var gxGrid = gx.fn.getGridObj(vStruct.grid);
						var firstRecordOnPage = (gxGrid && gxGrid.grid && !gxGrid.InfiniteScrolling) ? gxGrid.grid.firstRecordOnPage : 0;
						var sRow = gx.fn.currentGridRow(vStruct.grid);
						if (sRow.length > 4)
							sRow = sRow.substr(sRow.length - ((i + 1) * 4), 4);
						obj = obj[Number(firstRecordOnPage || 0) + Number(sRow) - 1];
					}
					if (obj) {
						if (len > 1 && i < len - 1 && obj[bcProp[i]] === undefined) {
							obj[bcProp[i]] = {};
						}
						if (typeof (obj[bcProp[i]]) == 'object' && i < len - 1) { //bcProp[i] es un subnivel del sdt (no un elemento 'hoja') => es object y no es el ultimo del array bcProp.
							obj = obj[bcProp[i]];
						}
						else {
							obj[bcProp[i]] = pValue;
							if (obj[bcProp[i]  + "_N"] !== undefined) {
								obj[bcProp[i]  + "_N"] = 0;
							}
							break;
						}
					}
				}
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfrmutl.js', 'valueToBCProp');
		}
	};

	prot.bcToScreen = function (bc, data) {
		for (var prop in bc) {
			if (prop == 'gxvar') {
				continue;
			}
			try {
				if (typeof (data[prop]) == 'object') {
					this.bcToScreen(bc[prop], data[prop]);
				}
				else {
					var vStruct = bc[prop];
					if ((vStruct.grid == 0 || (gx.csv.validatingGrid && vStruct.grid == gx.csv.validatingGrid.gridId)) && gx.lang.emptyObject(vStruct.hc)) {
						if (data[prop] != undefined) {
							if (vStruct.v2v) {
								vStruct.v2v(data[prop]);
								gx.fn.v2c(vStruct, data[prop]);									
							}
						}
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'bcToScreen');
			}
		}
	};

	prot.addGridUCEventHandler = function (CtrlName, EvtName, EvtHandler) {
		if (gx.lang.emptyObject(this.GridUCsEvts[CtrlName]))
			this.GridUCsEvts[CtrlName] = [];
		this.GridUCsEvts[CtrlName].push({ e: EvtName, h: EvtHandler });
	};

	prot.getGridUCEventHandlers = function (CtrlName) {
		var handlers = this.GridUCsEvts[CtrlName];
		if (gx.lang.emptyObject(handlers))
			return [];
		return handlers;
	};

	prot.setGridUCDynProp = function (CtrlName, PropName, HiddenName, Value, PropType) {
		this.setGridUCProp(CtrlName, PropName, HiddenName, Value, PropType);
	};

	prot.setGridUCProp = function (CtrlName, PropName, HiddenName, Value, PropType) {
		if (gx.lang.emptyObject(this.GridUCsProps[CtrlName]))
			this.GridUCsProps[CtrlName] = [];
		this.GridUCsProps[CtrlName].push({ p: PropName, h: HiddenName, v: Value, t: PropType });
		if (PropName == "InternalTitle") {
			this.GridUCsProps[CtrlName].title = Value;
		}
	};

	prot.getGridUCProperties = function (CtrlName) {
		var props = this.GridUCsProps[CtrlName];
		if (gx.lang.emptyObject(props))
			return [];
		return props;
	};

	prot.addUsercontrolBinding = function (VarName, CtrlName, UC) {
		if (!this.UCBindings[VarName]) {
			this.UCBindings[VarName] = {
				fld: CtrlName,
				uc: []
			};
			this.UCBindingsHiddens[CtrlName] = this.UCBindings[VarName];
		}
		if (!gx.util.inArray(UC, this.UCBindings[VarName].uc)) {
			this.UCBindings[VarName].uc.push(UC);
		}
	};

	prot.setUserControl = function (gxUC) {
		if (!gxUC.ContainerName)
			return;
		this.UserControls[gxUC.ContainerName] = gxUC;
	};

	prot.getUserControl = function (cName) {
		var uc = this.UserControls[cName];
		if (!uc && this.CmpContext != '') {
			uc = this.UserControls[this.CmpContext + cName];
		}
		return uc;
	};

	prot.getUserControlGrids = function () {
		return $.map(this.Grids, function (item) {
		  if (item.grid && item.isUsercontrol)
			return item.grid;
		});
	};

	prot.execV2CFunctions = function (Show, userControls, ShowGridUcs) {
		ShowGridUcs = (ShowGridUcs === undefined) || ShowGridUcs;
		if (!userControls) {
			userControls = this.UserControls;
		}			
		var gxO = this;
		gx.uc.StartRender();
		$.each(userControls, function (i, uc) {
			if (uc && gxO == uc.ParentObject && (ShowGridUcs || !uc.GridId)) {
				uc.updateAndShow(Show);
			}
		});
		gx.uc.EndRender();
	};

	prot.execC2VFunctions = function () {			
		$.each(this.UserControls, function (i, uc) {
			try { uc.execC2VFunctions(); }
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'execC2VFunctions');
			}
			try { uc.saveProperties(); }
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'execC2VFunctions');
			}
		});
	};

	prot.setMode = function () {
		gx.fn.setHidden(this.CmpContext + "_MODE", this.Gx_mode);
		gx.fn.setHidden(this.CmpContext + "Mode", this.Gx_mode);
	};

	prot.setVariable = function (VarName, Value) {
		this[VarName] = Value;
		var FormattedValue = Value;
		if (VarName.indexOf(this.CmpContext) != 0)
			gx.fn.setHidden(this.CmpContext + VarName, Value);
		if (this.VarControlMap[VarName] != undefined) {
			var type = this.VarControlMap[VarName].type;
			if (type == "date" || type == "dtime") {
				if (typeof (Value) == "string") {
					Value = new gx.date.gxdate(Value);
					this[VarName] = Value;
				}
				if (type == "date")
					FormattedValue = Value.getStringWithFmt('Y4MD');
				else
				{
					var dtdec = this.VarControlMap[VarName].decimals;
					FormattedValue = Value.getStringWithFmt('Y4MD') + ' ' + Value.getTimeString(true, true, dtdec > 1, dtdec >= 12);
				}
			}
			if (type == "decimal" && gx.decimalPoint != '.') {
				FormattedValue = Value.toString().replace('.', gx.decimalPoint);
				if (typeof (Value) == "string")
					this[VarName] = gx.num.parseFloat(Value);
			}
			else if (type == "int" && typeof (Value) == "string") {
				this[VarName] = gx.num.parseInt(Value);
			}
			gx.fn.setHidden(this.CmpContext + this.VarControlMap[VarName].id, FormattedValue);
		}
		if (VarName == "Gx_mode")
			this.setMode();
		if (this.UCBindings[VarName] != undefined)
			gx.fn.setHidden(this.CmpContext + this.UCBindings[VarName].fld, Value);
	};

	prot.getVariable = function (VarName) {
		return this[VarName];
	};

	prot.isServerEvent = function (ClientEvtName) {
		return this.Events[ClientEvtName][1] || false;
	};

	prot.getServerEventName = function (ClientEvtName) {
		return this.Events[ClientEvtName][0] || "";
	};

	prot.getClientEventName = function (ServerEvtName) {
		for (var evtName in this.Events) {
			if (this.Events[evtName][0] == ServerEvtName) {
				return evtName;
			}
		}
		return "";
	};

	var MAPPED_EVENTS = {
		"RFR": "REFRESH",
		"RFR_MPAGE": "REFRESH"
	};

	var FIRE_EVT_IF_INPUT_ERRORS = [
		'.CONTROLVALUECHANGED',
		'.CONTROLVALUECHANGING'
	];
	
	var shouldCancelEventIfInputError = function (dirtyEventName) {
		for (var i = 0; i < FIRE_EVT_IF_INPUT_ERRORS.length; i++) {
			if (dirtyEventName.indexOf(FIRE_EVT_IF_INPUT_ERRORS[i]) >=0) {
				return false;
			}
		}
		return true;
	};

	prot.cleanEventName = function(dirtyEventName) {
		dirtyEventName = dirtyEventName.replace(new RegExp('^' + this.CmpContext), '');
		var exp = (gx.pO.fullAjax)? /^E('?(.*)\.?'?)/: /^E('?(\w+)\.?([^\.]*)'?)/;
		var tmpName = exp.exec(dirtyEventName);
		var cleanName = (tmpName && tmpName.length && tmpName.length > 1) ? tmpName[1].replace(/\.\d*$/,'') : dirtyEventName;
		return MAPPED_EVENTS[cleanName] || cleanName;
	};

	prot.inputHasFormatErrors = function (dirtyEventName, grid, row) {
		var i,
			inputParms,
			cleanEventName = this.cleanEventName(dirtyEventName),
			element,
			vStruct,
			anyErr = false,
			anyFormatError = gx.csv.anyFormatError(),
			elementWithErrorId;

		if (!this.fullAjax && anyFormatError) {
			return true;
		}
			
		if (!anyFormatError) {
			return false;
		}
			
		if (!this.EvtParms[cleanEventName]) {
			return false;
		}

		if (!shouldCancelEventIfInputError(cleanEventName)) {
			return false;
		}

		inputParms = this.EvtParms[cleanEventName][0];
		var self = this;
		var anyError = function (vStruct) {
			if (vStruct) {
				if (grid && row && vStruct.grid == grid) {
					element = gx.fn.getControlGridRef(vStruct.fld, grid, row);
					if (element && element.id && gx.csv.gxFormatErrors[element.id]) {
						return true;
					}
				}
				else {
					element = gx.fn.getControlGridRef(vStruct.fld, vStruct.grid);
					if (element && element.id) {
						for (elementWithErrorId in gx.csv.gxFormatErrors) {
							if (vStruct == self.getValidStructFld(elementWithErrorId)) {
								return true;
							}
						}
					}
				}
			}	
			return false;
		};
		
		for (i=0, len=inputParms.length; i<len && !anyErr; i++) {
			var inputParm = inputParms[i];
			if (inputParm.postForm)
				return anyFormatError;

			if (inputParm.fld) {
				vStruct = this.getValidStructFld(inputParm.fld);
				if (vStruct) {
					anyErr = anyErr || anyError(vStruct);
				}
				else {
					var formBC = this.getFormBCForVar(inputParm.av);						
					if (formBC != null) {							
						for (var idx in formBC){
							vStruct = formBC[idx];
							if (typeof(vStruct) === 'object') {
								anyErr = anyErr || anyError(vStruct);
							}
						}
					}
				}
			}
		}			
		return anyErr;
	};

	prot.setEventParameters = function (ParmsData, Values) {
		gx.csv.lastEvtRow = null;
		gx.O = this;
		var allSameGrid = true;
		var pGrid = -1;
		gx.csv.cmpCtx = this.CmpContext;
		var len = ParmsData.length;
		for (var i = 0; i < len; i++) {
			var ParmName = ParmsData[i][0];
			var CtrlName = ParmsData[i][1];
			var VarName = ParmsData[i][2];
			var found = false;
			if (Values instanceof ExoParameters) {
				this.setVariable(VarName, Values.parms[i]);
				found = true;
			}
			else {
				for (var valProp in Values) {
					if (valProp.toLowerCase() == ParmName.toLowerCase()) {
						this.setVariable(VarName, Values[valProp]);
						found = true;
						break;
					}
				}
			}
			if (!found)
				this.setVariable(VarName, Values);
			var validStruct = this.getValidStructFld(CtrlName);
			if (validStruct != null) {
				if ((validStruct.grid != 0) && (pGrid == -1))
					pGrid = validStruct.grid;
				else if ((validStruct.grid != 0) && (validStruct.grid != pGrid))
					allSameGrid = false;
				gx.fn.v2c(validStruct);
			}
			else
				gx.fn.setHidden(this.CmpContext + CtrlName, this.getVariable(VarName));
		}
		if (allSameGrid)
			gx.csv.lastEvtRow = gx.fn.currentGridRowImpl(pGrid);
	};

	prot.executeEvent = function (evtName, synch, rowGxId, force, evtGridName) {
		gx.O = this;
		gx.csv.cmpCtx = this.CmpContext;
		var cliEventName = this.getClientEventName(evtName),
			isServerEvent = (cliEventName)? this.isServerEvent(cliEventName): true,
			parms = '',
			deferred,
			gridObj;

		if (isServerEvent) {
			if (evtGridName) {
				gridObj = this.getGrid(evtGridName)
				if (gridObj && rowGxId) {
					gridObj.instanciateRow(rowGxId);
				}
				else {
					gx.csv.instanciatedRowGrid = null;
				}
			}
			else {
				gx.csv.instanciatedRowGrid = null;
			}

			deferred = this.executeServerEvent(evtName, synch, rowGxId, force, this.fullAjax && !rowGxId && !evtGridName);
		}
		else {
			deferred = gx.evt.execCliEvt( this.CmpContext, this.IsMasterPage, cliEventName, evtGridName, rowGxId, parms);
		}
		gx.csv.instanciatedRowGrid = null;
		return deferred;
	};


	prot.executeServerEvent = function (EvtName, Synch, EvtRow, Force, GlobalContextEvent) {
		var deferred = $.Deferred();
		gx.O = this;
		gx.csv.cmpCtx = this.CmpContext;
		var synchReq = true;
		if ((Synch != undefined) && (Synch == false))
			synchReq = false;
		var row = (typeof (EvtRow) == 'string') ? EvtRow : '';
		if (!gx.lang.emptyObject(gx.csv.lastEvtRow))
			row = gx.csv.lastEvtRow;
		var CurrentGrid = gx.csv.validatingGrid || gx.csv.instanciatedRowGrid;
		if (CurrentGrid && CurrentGrid.parentObject != this) {
			CurrentGrid = null;
		}
		var gridId = !gx.lang.emptyObject(CurrentGrid) ? CurrentGrid.gridId : false;
		if (GlobalContextEvent) {
			row = ''
			gridId = null;
		}
		else {
			if (row == '' && gridId)
				row = gx.csv.lastRow[gridId];
			if (typeof (row) == 'undefined' )
				row = gx.fn.currentGridRowImpl(CurrentGrid.gridId);
		}
		var evtName = this.CmpContext + "E" + EvtName + '.' + (row || "");
		var afterFnc = function() {			
			deferred.resolve();
		}
		var failFnc = function() {			
			deferred.reject();
		}
		gx.evt.execEvt(this.CmpContext, this.IsMasterPage, evtName, gx.evt.dummyCtrl, gridId, synchReq, null, null, afterFnc, Force, failFnc, false);
		return deferred.promise();
	};

	prot.executeEnterEvent = function (evt, ctrl, disableForm) {
		//gx.evt.onchange_impl(ctrl, true); CM: Do not call onchange_impl here, see blame
		var gxOEnter = this.gxOWithEnter(ctrl);
		var forceEnter = false;
		if (ctrl && ctrl.onblur)
			ctrl.onblur();
		if (gx.pO.fullAjax || gxOEnter == null) { //Si no es fullajax y tiene evento Enter => Enter ejecuta refresh implicito
			if (evt && gx.evt.cancelAndRefresh(evt)) {
				if (gxOEnter != null && !gxOEnter.autoRefresh && gxOEnter.hasEnterEvent && !gxOEnter.anyGridBaseTable) //grid sin tabla base, autorefresh=no, Enter definido => Refresh+Evento Enter
					forceEnter = true;
				else 
					return;
			}
		}
		if (evt) {
			if (gx.dom.hasSubmitControl()) {
				gx.evt.cancel(evt, true);
			}
			if (ctrl && ctrl.nodeName == 'INPUT' && gx.dom.isEditControl(ctrl)) {
				gx.evt.cancel(evt, true);
			}
		}
		else {
			forceEnter = true;
		}

		if (gxOEnter != null) {
			var enterName = 'ENTER';
			if (gxOEnter.IsMasterPage)
				enterName = enterName + '_MPAGE';
			enterName = gxOEnter.CmpContext + 'E' + enterName + '.';
			var gridId;
			if (ctrl && gx.evt.isEnterEvtCtrl(ctrl)) {
				var rowId = gx.fn.controlRowId(ctrl),
					gridId = gx.fn.controlGridId(ctrl.id);
				if (rowId)
					enterName += rowId;
			}			
			gx.evt.execEvt(gxOEnter.CmpContext, gxOEnter.IsMasterPage, enterName, gx.evt.dummyCtrl, gridId, false, null, disableForm, null, forceEnter, undefined, gxOEnter != null);
			if (evt) {
				gx.evt.cancel(evt, true);
			}
		}
	};

	prot.gxOWithEnter = function (ctrlEvt) {
		if (ctrlEvt) {
			var contextData = gx.json.evalJSON($(ctrlEvt).attr(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR) || '{}');
			if (contextData && contextData.length > 1) {					
				var gxO = gx.getObj(contextData[0], contextData[1]);
				if (gxO && gxO.hasEnterEvent)
					return gxO;
			}
		}
		if (this.hasEnterEvent) {
			return this;
		}
		else if (this.IsComponent) {
			var cmpType = this.getCmpType(this.CmpContext);
			var isMPage = ((cmpType[1] == '') && (cmpType[0].indexOf('MP') == 0));
			var parent = gx.getObj(cmpType[1], isMPage);
			if (!gx.lang.emptyObject(parent)) {
				return parent.gxOWithEnter();
			}
		}
		else if (this.hasMasterPage()) {
			return this.MasterPage.gxOWithEnter();
		}
		return null;
	};

	prot.getLastControlId = function () {
		return this.GXLastCtrlId;
	};

	prot.getValidStruct = function (ctrlId) {
		return this.GXValidFnc[ctrlId];
	};

	prot.getControlIds = function () {
		return this.GXCtrlIds;
	};

	prot.getControlIdsh = function () {
		return this.GXCtrlIdsh;
	};

	prot.getUsercontrolFromChild = function (Child) {			
		$.each(this.UserControls, function (i, uc) {
			var ctrl = uc.getContainerControl();
			if (gx.dom.isChildNode(Child, ctrl))
				return uc;
		});
		return null;
	};

	prot.installFlatLevelDatePickers = function () {
		var validStruct = null;
		var ctrlIds = this.getControlIds();
		var len = ctrlIds.length;
		for (var i = 0; i < len; i++) {
			validStruct = this.getValidStruct(ctrlIds[i]);
			if ((validStruct != undefined) && (validStruct.grid == 0) && (validStruct.dp != undefined)) {
				var controlId = this.CmpContext + validStruct.fld;
				gx.fn.installDatePicker(controlId, validStruct, this, validStruct.dp.f, validStruct.dp.st, validStruct.dp.wn, validStruct.dp.mf, gx.fn.datePickerFormat(validStruct.dp.pic, validStruct.dp.dec, validStruct.len), validStruct.len, validStruct.dp.dec);
			}
		}
	};

	prot.installImageControls = function () {
		var containers = gx.dom.byClass(gx.html.multimediaUpload.gxCssClass);
		for (var i = 0, len = containers.length; i < len; i++) {
			gx.html.multimediaUpload.createControl(containers[i]);
		}
		gx.fx.obs.addObserver('gx.multimedia.clear', this, this.clearMultimediaValue);
	};

	prot.initControlsEnabledFlag = function (vStruct) {
		if (vStruct.type != 'bits' && vStruct.type != 'audio' && vStruct.type != 'video') {
			var el = gx.fn.getControlRef(vStruct.fld);
			if (el) {
				var isEnabled = gx.http.viewState[gx.dom.id(el) + "_Enabled"];
				if (isEnabled !== undefined) {
					gx.fn.setEnabledProperty(el, gx.lang.gxBoolean(isEnabled), false);
				}
			}
		}
	};

	prot.initControlsBehaviour = function () {
		var gxO = this;
		$.each(gx.O.GXValidFnc, function (i, vStruct) {
			if (vStruct && vStruct.fld ) {			
				gxO.initControlsEnabledFlag(vStruct);
				if (vStruct.gxsgprm) {				
					var Ctrl = gx.fn.getControlRef(vStruct.fld);
					if (Ctrl)
						gx.fx.installSuggest(Ctrl);
				}
			}
		});
	};


	var evaluateCode = function (conditionCode) {
		if (gx.lang.emptyObject(conditionCode)) {
			return false;
		}
		var fn;
		try {
			fn = new Function("return " + conditionCode);
		}
		catch (e) {
			return gx.lang.doEval(conditionCode); //For compatibility reasons, try to eval js code.
		}
		try {
			return fn();
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfrmutl.js', 'evaluateCode');
		}
		return false;
	};

	var getConditionCode = function (el) {
		var lTagName = el.tagName.toLowerCase();
		if (lTagName == "img" || lTagName == "input") {
			return $(el).attr(gx.GxObject.GX_EVENT_CONDITION_DATA_ATTR);
		}
		else {
			return $('a[' + gx.GxObject.GX_EVENT_CONDITION_DATA_ATTR + ']', el).attr(gx.GxObject.GX_EVENT_CONDITION_DATA_ATTR);
		}
	};

	var elementIsFocusable = (function () {
		var focusableTagNames = {
			'select': true,
			'textarea': true
		};

		var focusableInputTypes = gx.lang.apply({
			'radio': true,
			'checkbox': true,
			'file': true
			
		}, gx.dom.editControls);

		return function (el) {
			if (!el) {
				return false;
			}
			var tagName = el.tagName.toLowerCase();
			return tagName == "input" ? focusableInputTypes[el.type.toLowerCase()] : focusableTagNames[tagName];
		};
	})();

	var isFocusableElementLabel = function (el) {
		var forElId, forEl;
		if (el && el.tagName.toLowerCase() == "label") {
			forElId = el.getAttribute('for');
			if (forElId) {
				forEl = gx.dom.el(forElId)
				return elementIsFocusable(forEl) && gx.fn.isVisible(forEl, 0);
			}
		}
		return false;
	};

	var dispatchControlEvent = function (domEvt) {
		if (domEvt.type === "keypress" && (
				domEvt.keyCode !== 13 &&
				(domEvt.keyCode !== 32 || !gx.dom.isButton(domEvt))
			)) { //Only enter Event (for keypress Evt) should be processed here.
			return; 
		}
		var target = domEvt.target,
			$target = $(target),
			$currentTarget = $(domEvt.currentTarget),
			contextData = gx.json.evalJSON($currentTarget.attr(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR)),
			fld = $currentTarget.attr(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR),
			gxO;

		// Ignore plain anchors
		if (target && target.tagName.toUpperCase() === 'A' && $(target).attr(gx.GxObject.GX_EVENT_DATA_ATTR) === undefined && target.href) {
			return;
		}

		if (contextData && contextData.length > 1) {
			gxO = gx.getObj(contextData[0], contextData[1]);
		}

		if (!gxO) {
			domEvt.preventDefault();
			return;
		}

		if ($currentTarget.hasClass("gx-disabled")) {
			return;
		}

		if ((elementIsFocusable(target) || isFocusableElementLabel(target)) && !$(target).is($currentTarget)) {
			return;
		}

		if (gx.dom.hasAttribute(target, gx.GxObject.GX_EVENT_EVENT_IN_PROGRESS)) {
			return;
		}
		
		domEvt.stopPropagation();
		var fnc = function() {
		if (doubleClickEvtNotSupported())
			dispatchEvent_IE7.apply(this, [domEvt, $target, gxO, fld]);
		else
			dispatchEvent.apply(this, [domEvt, $target, gxO, fld]);
		};
		if (gx.evt.processing) {
			gx.fx.obs.addObserver('gx.endprocessing', this, fnc, { single: true });
		} 
		else {
			fnc.call(this);
		}
	};

	var doubleClickEvtNotSupported = function () {
		return gx.util.browser.isOldIE() && !gx.util.browser.isWinCE();
	};

	var dispatchEvent = function (domEvt, $target, gxO, fld ) {			
		var dispatchFunction = function () {
			gx.csv.resetRow();
			var vStruct = gxO.getValidStructFld(fld);
			if (vStruct && vStruct.grid) {
				gx.evt.setEventRow(gxO, $target.get(0));
			}
			$target.removeAttr(gx.GxObject.GX_EVENT_CONTROL_DELAYED_ATTR);
			gxO.handleControlEvent(domEvt, fld, this);
		}.closure(this);
								
		if (gx.fx.dom.delayedDispatch(domEvt))
		{
			if ($target.attr(gx.GxObject.GX_EVENT_CONTROL_DELAYED_ATTR)) {						
				gx.fx.dom.raiseEvent('dblclick', domEvt);
				return;
			}
			var t = setTimeout(dispatchFunction, gx.config.evt.dblclick.delay);				
			$target.attr(gx.GxObject.GX_EVENT_CONTROL_DELAYED_ATTR, t);
		}
		else
		{
			dispatchFunction.call();
		}
	}

	var dispatchEvent_IE7 = function (domEvt, $target, gxO, fld ) {
		if ($target.attr(gx.GxObject.GX_EVENT_CONTROL_DELAYED_ATTR)) {				
			return;
		}
		var dispatchFunction = function () {
			gx.csv.resetRow();
			var vStruct = gxO.getValidStructFld(fld);
			if (vStruct && vStruct.grid) {
				gx.evt.setEventRow(gxO, $target.get(0));
			}
			$target.removeAttr(gx.GxObject.GX_EVENT_CONTROL_DELAYED_ATTR);
			gxO.handleControlEvent(domEvt, fld, this);
		}.closure(this);
								
		if (gx.fx.dom.delayedDispatch(domEvt))
		{				
			var t = setTimeout(dispatchFunction, gx.config.evt.dblclick.delay);				
			$target.attr(gx.GxObject.GX_EVENT_CONTROL_DELAYED_ATTR, t);
		}
		else
		{
			dispatchFunction.call();
		}
	}



	var cancelEvent = function (domEvt, stopPropagation, preventDefault) {
		try { //IE7 Jquery throws exception
			if (preventDefault)				
				domEvt.preventDefault();
			if (stopPropagation)
				domEvt.stopPropagation();
		}
		catch (e) {}
	};

	function readControlEventAttribute(el, attribute) {
		var $el = $(el),
			readOnlyCtrl = $el.is('SPAN,DIV');
		return $el.attr(attribute) || 
					(readOnlyCtrl ? 
						$el.find("> a")
							.first()
							.attr(attribute) 
						:
						'');
	};

	prot.handleControlEvent = function (domEvt, fld, el) {
		var controlEventMap = this.controlEventMap;
		if (!controlEventMap[fld])
			return;

		var vStruct = controlEventMap[fld], 				
			clientEventName = controlEventMap[fld].evt,
			evtData = this.Events[clientEventName],
			evtName = evtData ? this.Events[clientEventName][0] : controlEventMap[fld].std,
			jsScriptType = readControlEventAttribute(el, gx.GxObject.GX_EVENT_DATA_ATTR),
			jsScriptCode = readControlEventAttribute(el, gx.GxObject.GX_EVENT_CODE_DATA_ATTR),
			conditionCode = getConditionCode(el),
			rowGxId = (vStruct.grid > 0)? gx.fn.controlRowId(domEvt.currentTarget): null,
			gridObj = this.getGridById(vStruct.grid, rowGxId),
			gridName,
			preventDefault = true,
			forceOnChange = false,
			$target = $(domEvt.target);
		
		// Click on combo controls is not handled, as we want to fire the event when the value changes.
		if (vStruct.ctrltype == "combo")
			return;

		switch (jsScriptType) {
			case "1":
				cancelEvent(domEvt, true, true);
				if (!conditionCode || evaluateCode(conditionCode)) {
					gx.fn.closeWindow();
				}
				break;
			case "3": //Help command
			case "4":
				cancelEvent(domEvt, true, true);
				if (jsScriptCode) {
					evaluateCode(jsScriptCode);
				}
				break;
			case "8":
				gx.ajax.doRefresh(this);
				break;
			default:
				if (!conditionCode || evaluateCode(conditionCode)) {
					if (gridObj) {
						gridName = gridObj.gridName;
					}
					if (vStruct.ctrltype === "checkbox") {
						gx.fn.checkboxClick(vStruct, el, vStruct.values[0], vStruct.values[1]);
						preventDefault = false;
						forceOnChange = true;
					}
					if (evtName) {
						$target.attr(gx.GxObject.GX_EVENT_EVENT_IN_PROGRESS, true);
						this.executeEvent(evtName, false, rowGxId, false, gridName).always(
							function(ctrlTarget) {
								if (!gx.evt.redirecting) {
									var fnc = function() { $(ctrlTarget).attr(gx.GxObject.GX_EVENT_EVENT_IN_PROGRESS, null)};
									if (gx.spa.isNavigatingRaw()) {
										gx.spa.addObserver('onnavigate', this, fnc, {single:true});
									}
									else
										fnc();
								}
							}.closure(this, [$target])
						);
					}
					if (forceOnChange) {
						gx.evt.onchange(el);
					}
				}
				cancelEvent(domEvt, true, preventDefault);
				break;
		}
	};

	prot.registerCtrlsEventHandlers = function () {
		var i,
			len,
			ctrlIds = this.GXCtrlIds,
			vStructList = this.GXValidFnc,
			vStruct,
			isMp = this.IsMasterPage,
			cmpContext = this.CmpContext,
			mpSufix = isMp ? "_MPAGE" : "",
			eventSelector = "[" + gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR + "]",
			selectorBase,
			selectorReadOnly,
			selector,
			$controlElement,
			isParentObject = !cmpContext && !isMp,
			hasEvt,
			excludedCtrlTypes = gx.GxObject.GX_EVENT_EXCLUDED_CTRLTYPES,
			controlEventMap,
			needsDataContext;
		
		if (this.listeningControlEvents === undefined) {
			this.listeningControlEvents = false;
		}
		if (!this.controlEventMap) {
			this.controlEventMap = {};
		}
		controlEventMap = this.controlEventMap;
		for (i=0, len=ctrlIds.length; i<len; i++) {
			vStruct = vStructList[ctrlIds[i]];
			hasEvt = gx.fn.controlFiresEvent(vStruct);
			needsDataContext = hasEvt || (this.hasEnterEvent && !gx.lang.emptyObject(vStruct.ctrltype));				
			if (!gx.util.inArray(vStruct.ctrltype, excludedCtrlTypes) && (hasEvt || needsDataContext)) {
				if (hasEvt)
					controlEventMap[vStruct.fld] = vStruct;
				if (vStruct.grid === 0) {
					selectorBase = cmpContext + vStruct.fld + (vStruct.gxvar ? "" : mpSufix);
					selectorReadOnly = "#span_" + selectorBase;
					selector = "#" + selectorBase;
					if (vStruct.gxvar && $(selectorReadOnly).length > 0) {
						$controlElement = $(selectorReadOnly);
					}
					else {
						$controlElement = $(selector);
					}
					if (hasEvt) {
						$controlElement.attr(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);						
						// If the control is an image, make it focusable
						if ($controlElement.is("img")) {
							$controlElement.attr("tabindex", "0");
						}
						if (!elementIsFocusable($controlElement.get(0))) {
							$controlElement.attr("tabindex", "0");
						}
					}
					$controlElement.attr(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, gx.json.serializeJson([cmpContext, isMp]));
				}
			}
		}

		if (isParentObject) {
			if (!this.listeningControlEvents) {
				this.listeningControlEvents = true;
				$(document.body).on('click keypress', eventSelector, dispatchControlEvent);
			}
		}
	};

	prot.unregisterCtrlsEventHandlers = function () {
		if (this.listeningControlEvents) {
			$(document.body).off('click keypress', dispatchControlEvent);
		}
		this.listeningControlEvents = false;
	};

	prot.clearMultimediaValue = function (el) {
		var elements = gx.html.multimediaUpload.getElements(el);
		elements.fileField.onchange(elements.fileField);
		gx.fn.setHidden(elements.fileField.id, "");
		gx.fn.setHidden(elements.uriField.id, "");
		gx.fn.setHidden(elements.fileField.id + "_gxBlob", "");
	};

	prot.refreshOlds = function () {
		for (var lvl in this.LvlOlds) {
			var lvlOlds = this.LvlOlds[lvl];
			if (typeof (lvlOlds) != 'function') {
				var gridId = gx.fn.lvlGrid(parseInt(lvl, 10));
				var gridRow;
				if (gridId != 0) {
					gridRow = gx.fn.currentGridRow(gridId);
					if (gridRow === '9999')
						continue;
				}

				var len = lvlOlds.length;
				for (var i = 0; i < len; i++) {
					var name = lvlOlds[i];
					var varName = name;
					var oldVal = '';
					var vStruct = gx.fn.vStructForOld(varName);
					if (vStruct) {
						if (!vStruct.gxgrid || vStruct.gxgrid.grid.rows.length > 0)
							oldVal = gx.typedOld(vStruct.fld, varName, vStruct.type);
					}
					else {
						if (!gx.lang.emptyObject(gridRow))
							name += '_' + gridRow;
						oldVal = gx.fn.getHidden( this.CmpContext + name);
					}
					if (typeof (oldVal) != 'undefined') {
						if (!vStruct) {
							window[varName] = oldVal;
						}
						this[varName] = oldVal;
					}
				}
			}
		}
	};

	var ExoParameters = function (parms) {
		this.parms = parms;
		return this;
	};

	prot.addExoEventHandler = function (exoEventName, handler) {
		var exoEventHandler = function () {
			var oldGxO = gx.O;
			gx.setGxO(this);
			handler.call(this, null, null, new ExoParameters(Array.prototype.slice.call(arguments, 0)));
			gx.setGxO(oldGxO);
		};
		gx.fx.obs.addObserver(exoEventName, this, exoEventHandler);
		this.exoEventHandlers = this.exoEventHandlers || {};
		this.exoEventHandlers[exoEventName] = exoEventHandler;
	};

	prot.deleteExoEventHandlers = function () {
		for (var exoEventName in this.exoEventHandlers) {
			if (this.exoEventHandlers.hasOwnProperty(exoEventName)) {
				gx.fx.obs.deleteObserver(exoEventName, this, this.exoEventHandlers[exoEventName]);
			}
		}
	};

	prot.restoreExoEventHandlers = function () {
		for (var exoEventName in this.exoEventHandlers) {
			gx.fx.obs.addObserver(exoEventName, this, this.exoEventHandlers[exoEventName]);
		}
	};

	prot.deleteEventHandlers = function () {
		try {
			this.unregisterCtrlsEventHandlers();
			gx.fx.ctx.deleteHandlers(this);
			gx.fx.dnd.deleteHandlers(this);
			this.deleteExoEventHandlers();
			gx.fx.dom.deleteEventHandlers(this);
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfrmutl.js', 'deleteEventHandlers');
		}
	};

	prot.ondestroy = function () {
		try {
			this.endFeedback();
			this.deleteEventHandlers();
			$.each(this.UserControls, function (i, uc) {
				if (!gx.lang.emptyObject(uc.destroy)) {
					try {
						uc.destroy();
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxfrmutl.js', 'ondestroy');
					}
				}
			});
			this.UserControls = [];
			delete this.containerControl;
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfrmutl.js', 'ondestroy');
		}
	};

	prot.onpost = function () {
		var gxO = gx.O;
		gx.setGxO(this);
		if (this.hasMasterPage())
			this.MasterPage.onpost();
		var len = this.WebComponents.length;
		for (var i = 0; i < len; i++) {
			this.WebComponents[i].onpost();
		}
		if (this.ReadonlyForm && this.IsComponent && gxO != this) {
			this.roControlsAsHidden();
		}
		this.execC2VFunctions();
		gx.setGxO(gxO);
	};

	prot.roControlsAsHidden = function () {
		var ctrlIds = this.getControlIds();
		var len = ctrlIds.length;
		for (var i = 0; i < len; i++) {
			var validStruct = this.getValidStruct(ctrlIds[i]);
			if (validStruct.grid == 0 && typeof (validStruct.val) == 'function') {
				var ctrlId = this.CmpContext + validStruct.fld;
				var ctrl = gx.dom.el(ctrlId);
				if (ctrl && !gx.fn.isAccepted(ctrl))
					gx.fn.setHidden(ctrlId, gx.fn.getControlValue(ctrlId));
			}
		}
	};

	prot.onload = function (loadGrids, forceAfterLoad) {
		var deferred = $.Deferred(),
			arrDeferreds = [];
		gx.dbg.logPerf('objectOnload_' + this.CmpContext + this.ServerClass);
		gx.setGxO(this);
		this.screenToVars();		
		gx.wmp( function() {	
				if (this.hasMasterPage()) {
					this.MasterPage.onload();
					gx.setGxO(this);
				}
			}, this);

		var len = this.Grids.length;
		if (loadGrids !== false) {
			for (var i = 0; i < len; i++) {
				arrDeferreds.push( this.Grids[i].loadGrid());
			}
		}

		len = this.WebComponents.length;
		for (var i = 0; i < len; i++) {
			arrDeferreds.push( this.WebComponents[i].onload(loadGrids));
		}
		if (forceAfterLoad) {
			this.afterLoad()
		}
		else {
			gx.wr( this.afterLoad.closure(this), this);
		}
		gx.dbg.logPerf('objectOnload_' + this.CmpContext + this.ServerClass);
		var _this = this;
		$.when.apply($, arrDeferreds).done(function () {
			_this.onLoadDeferred.resolve();
		});
	};

	prot.afterLoad = function () {
		gx.dbg.logPerf('objectAfterLoad_' + this.CmpContext + this.ServerClass);
		gx.setGxO(this);
		this.installFlatLevelDatePickers();
		this.installImageControls();
		this.refreshOlds();
		this.initControlsBehaviour();
		this.execV2CFunctions(true, undefined, false);
		this.JustCreated = false;
		this.registerCtrlsEventHandlers();

		gx.$.map(gx.$('input[data-gx-disable], select[data-gx-disable]', this.getContainer()), function( el, i) {
			gx.fn.disableCtrl( el.getAttribute('data-gx-disable'));
			el.removeAttribute('data-gx-disable');
		});

		if (this === gx.pO) {
			gx.ui.controls.actionGroup.init();
			gx.dom.indexElements();
			gx.fn.doAttachs();
		}
		gx.dbg.logPerf('objectAfterLoad_' + this.CmpContext + this.ServerClass);
		gx.goOnload();
	};


	prot.onunload = function (unloadMasterPage) {
		if (this.hasMasterPage() && unloadMasterPage !== false)
			this.MasterPage.onunload();
		var len = this.Grids.length;
		for (var i = len - 1; i >= 0; i--) {
			delete this.Grids[this.Grids[i].gridName];
			this.Grids[i].cleanup();
			this.Grids.splice(i, 1);
		}
		len = this.WebComponents.length;
		for (var i = len - 1; i >= 0; i--) {
			delete this.WebComponents[this.WebComponents[i].CmpContext];
			this.WebComponents[i].onunload();
			this.WebComponents.splice(i, 1);
		}
		this.getValidStructFld_cache = {};
		gx.fn.cleanAttachedCtrls();
		this.ondestroy();
	};

	prot.clean = function (unloadMasterPage) {
		this.cleanHiddens();
		this.onunload(unloadMasterPage);
	};

	prot.cleanHiddens = function () {
		gx.http.clearState();
		gx.http.clearMultipartHidden();
	};

	prot.screenToVars = function () {
		try {
			var ctrlIds = this.getControlIds();
			var len = ctrlIds.length;
			for (var i = 0; i < len; i++) {
				var validStruct = this.getValidStruct(ctrlIds[i]);
				if (validStruct && validStruct.lvl == 0 && typeof (validStruct.c2v) == 'function')
					validStruct.c2v();
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfrmutl.js', 'screenToVars');
		}
	};

	prot.postbackLoad = function (userControls, newComponents) {
		var isJustCreatedComponent = this.IsComponent && this.JustCreated;
		if (this.hasMasterPage())
			this.MasterPage.postbackLoad(userControls);
		var len = this.WebComponents.length;
		for (var i = 0; i < len; i++) {
			this.WebComponents[i].postbackLoad(userControls);
		}
		if (isJustCreatedComponent) {
			this.installImageControls();
			this.installFlatLevelDatePickers();
			this.registerCtrlsEventHandlers();
		}
		this.execV2CFunctions(true, isJustCreatedComponent ? false : userControls);
		this.JustCreated = false;
		this.conditionsChanged = false;

		if (this === gx.pO) {
			gx.fn.doAttachs(newComponents);
		}
		gx.goOnload();
		this.onLoadDeferred.resolve();
	};

	prot.addDragSource = function (ControlId, CSSClass, Types, Handler) {
		gx.fx.dnd.addSource(this, ControlId, CSSClass, Types, Handler);
	};

	prot.addDropTarget = function (ControlId, CSSClass, Types, Handler) {
		gx.fx.dnd.addTarget(this, ControlId, CSSClass, Types, Handler);
	};

	prot.addContextSetter = function (ControlId, CSSClass, Types, Handler) {
		gx.fx.ctx.addSetter(this, ControlId, CSSClass, Types, Handler);
	};

	prot.addContextTracker = function (ControlId, CSSClass, Types, Handler) {
		gx.fx.ctx.addTracker(this, Types, Handler);
	};
	prot.addOnMessage = function (GroupName, EventName, Types, Handler, NoWait) {
		gx.fx.notifications.addTracker(this, GroupName, EventName, Types, Handler, NoWait);
	};

	prot.addEventHandler = function (EvtType, ControlId, Handler) {
		gx.fx.dom.addEventHandler(this, EvtType, ControlId, Handler);
	};

	prot.updateBitmapValue = function (controlId, blobProperty, uriProperty, value) {
		var multimediaCt = gx.html.multimediaUpload.getContainer(controlId);
		var type = gx.html.multimediaUpload.getOptionValue(multimediaCt);
		if (type == "file")
			this[blobProperty] = value;
		else
			this[uriProperty] = value;
	};

	var getNotificationDelay = function () {
		return gx.NotificationDelay === undefined ? 200 : gx.NotificationDelay;
	};
	
	prot.getFeedbackContainer = function() {
		return (gx.pO && !gx.pO.fullAjax || this == gx.pO) ? document.body : this.getContainer();
	};

	prot.startFeedback = function(immediately, swallowKeys) {
		this.feedbackCallCounter++;
		
		if (swallowKeys) {
			gx.fx.obs.addObserver('gx.keypress', this, this.swallowKeys);
		}

		var feedbackDelay = (immediately === true)? 0: getNotificationDelay(),
			timeoutObj;

		var fn = function() {
			var container = this.getFeedbackContainer();
			if (container) {
				gx.dom.mask(container);
			}
		};


		if (this.feedbackCallCounter == 1) {
			if (feedbackDelay === 0) {
				fn.call(this);
			}
			else {
				if (this.feedbackTimeoutId)
					return;
				timeoutObj = gx.lang.doCallTimeout(fn, this, arguments, feedbackDelay);
				this.feedbackTimeoutId = timeoutObj.t;
			}
		}
	};

	prot.swallowKeys = function (eventObject) {
		if (eventObject.event.keyCode !== 9) {
			eventObject.cancel = true;
			eventObject.event.preventDefault();
		}
	};

	prot.endFeedback = function() {
		gx.fx.obs.deleteObserver('gx.keypress', this, this.swallowKeys);

		if (this.feedbackCallCounter > 0)
			this.feedbackCallCounter--;
		if (this.feedbackCallCounter == 0) {
			if (this.feedbackTimeoutId) {
				clearTimeout(this.feedbackTimeoutId);
				this.feedbackTimeoutId = false;
			}

			var container = this.getFeedbackContainer();
			if (container) {
				gx.dom.unmask(container);
			}
		}
	};

	prot.isFeedbackOn = function () {
		return this.feedbackCallCounter > 0;
	};


	var CENTER_TARGET_CLASS = "gx-center-target",
		DOC_ELEMENT_BLOCKING_CLASS = "gx-blocking";

	var initSingleTarget = function () {
		var targetsCounter = 9996,
			mp = this;

		return function (target) {
			var prefix = "MPW" + (targetsCounter++),
				elementId = mp.CmpContext + 'gxHTMLWrp' + prefix;

			mp.setComponent({
				id: getWebComponentNameByTarget(target),
				GXClass: null,
				Prefix: prefix,
				lvl: 1
			});

			return $('<div class="gx-call-target ' + target + ' off empty"><div class="' + gx.GxObject.WEBCOMPONENT_CLASS_NAME + '" id="' + elementId +'"></div></div>');
		};
	}.call(this);

	var initCenterTarget = function () {
		var $form = $(gx.dom.form()),
			$abstractFormCt = $form.children('[data-abstract-form]')
								.first();

		if (!$abstractFormCt.length) {
			$abstractFormCt = $("<div></div>");
			$abstractFormCt.append($form.children());
			$form.append($abstractFormCt);
		}

		return $abstractFormCt.addClass("gx-center-target");
	};

	var getWebComponentNameByTarget = function (target) {
		return "GX-" + target.toUpperCase() + "-TARGET";
	};

	var layoutTargets = function (centerTarget, topTarget, rightTarget, bottomTarget, leftTarget) {
		$('<div id="gx-column-targets"></div>')
			.insertBefore(centerTarget)
			.append(leftTarget)
			.append(centerTarget)
			.append(rightTarget)
			.before(topTarget)
			.after(bottomTarget);
	};
	
	prot.initSingleTarget = function (target) {
		var prefix = "MPW" + (this.targetsCounter++),
			elementId = this.CmpContext + 'gxHTMLWrp' + prefix;

		this.setComponent({
			id: getWebComponentNameByTarget(target),
			GXClass: null,
			Prefix: prefix,
			lvl: 1
		});

		return $('<div class="gx-call-target ' + target + ' off empty"><div class="' + gx.GxObject.WEBCOMPONENT_CLASS_NAME + '" id="' + elementId +'"></div></div>');
	};

	prot.initTargets = function () {
		var centerTarget, topTarget, rightTarget, bottomTarget, leftTarget;

		if (gx.pO && gx.pO.fullAjax && this.IsMasterPage) {
			centerTarget = initCenterTarget();
			topTarget = this.initSingleTarget("top");
			rightTarget = this.initSingleTarget("right");
			bottomTarget = this.initSingleTarget("bottom");
			leftTarget = this.initSingleTarget("left");
			layoutTargets(centerTarget, topTarget, rightTarget, bottomTarget, leftTarget);
		}
	};

	prot.createObjectInTarget = function (target, objClass, args) {
		target = target.toLowerCase();
		var targetSelector = resolveTargetSelector(target);
		this.createWebComponent(getWebComponentNameByTarget(target), objClass, args, undefined, undefined, undefined, function (cmpPrefix) {
			this.targetComponents = this.targetComponents || {};
			var cmp = gx.pO.getWebComponent(cmpPrefix);
			if (cmp) {
				this.targetComponents[target] = cmp;
			}
		});
		$(targetSelector.selector).removeClass("empty");
	};

	prot.restoreTargetComponents = function () {
		var target;
		this.targetComponents = this.targetComponents || {};
		for (target in this.targetComponents) {
			if (targetComponents.hasOwnProperty(target)) {
				gx.pO.registerComponent(this.targetComponents[target]);
			}
		}
	};

	var resolveTargetSelector = function (target) {
		return {
			selector: ".gx-call-target." + target,
			centerSelector: "." + CENTER_TARGET_CLASS
		};
	};

	var clickHandler,
		clickHandlerOptions = { useCapture: true };
	prot.showTarget = function (target, autoHide) {
		target = target.toLowerCase();
		var targetSelector = resolveTargetSelector(target),
			selector = targetSelector.selector,
			centerSelector = targetSelector.centerSelector,
			doHideTarget;

		$(targetSelector.selector).removeClass("empty");

		$(selector).removeClass("off");
		$(centerSelector).addClass("slideout " + target);
		$(document.documentElement).addClass(DOC_ELEMENT_BLOCKING_CLASS);
		gx.fx.obs.notify("gx.targetshown", [target]);

		if (autoHide !== false) {
			clickHandler = (function(e) { 
				if(!$(e.target).closest(selector).length && !$(e.target).is(selector)) {
					if($(selector).is(":visible")) {
						doHideTarget.call(this);
						e.stopImmediatePropagation();
						e.preventDefault();
					}
				}
			}).closure(this);

			doHideTarget = function () {
				this.hideTarget(target);
			};

			gx.evt.attach(document, 'click', clickHandler, false, clickHandlerOptions);

			gx.spa.addObserver('onnavigate', this, doHideTarget);
		}
	};

	prot.hideTarget = function (target) {
		target = target.toLowerCase();
		var targetSelector = resolveTargetSelector(target),
			selector = targetSelector.selector,
			centerSelector = targetSelector.centerSelector;

		$(selector).addClass("off");
		$(centerSelector).removeClass("slideout " + target);
		$(document.documentElement).removeClass(DOC_ELEMENT_BLOCKING_CLASS);
		gx.evt.detach(document, 'click', clickHandler, clickHandlerOptions);
		gx.fx.obs.notify("gx.targethidden", [target]);
	};

	prot.collapseTarget = function (target) {
		target = target.toLowerCase();
		var targetSelector = resolveTargetSelector(target),
			selector = targetSelector.selector,
			centerSelector = targetSelector.centerSelector;

		this.showTarget(target, false);
		$(selector).addClass("collapsed");
		$(centerSelector).addClass("collapsed");
		gx.fx.obs.notify("gx.targetcollapsed", [target]);
	};

	prot.expandTarget = function (target) {
		target = target.toLowerCase();
		var targetSelector = resolveTargetSelector(target),
			selector = targetSelector.selector,
			centerSelector = targetSelector.centerSelector;

		this.showTarget(target, false);
		$(selector).removeClass("collapsed");
		$(centerSelector).removeClass("collapsed");
		gx.fx.obs.notify("gx.targetexpanded", [target]);
	};

	var appendArgs = function (args, item) {
		var args = Array.prototype.slice.call(args, 0);
		args.push(item);
		return args;
	};

	prot.validSrvEvt = function () {
		return gx.ajax.validSrvEvt.apply(gx.ajax, appendArgs(arguments, this));
	};

	prot.validCliEvt = function () {
		return gx.ajax.validCliEvt.apply(gx.ajax, appendArgs(arguments, this));
	};


})(gx.$);


gx.lang.apply(gx.GxObject.prototype, new gx.util.Observable());



gx.printing = (function($) {
	return {
	
    IFrameId: 'gxprintHelper_Iframe',

	print: function (printInfo) {
        this.printDirect(printInfo);
	},

    printDirect: function(printInfo) {		
    	if (printInfo) {
			gx.printing._deinit();		
			$iframe = $('<iframe>');
			$iframe.attr('id', gx.printing.IFrameId)
			.css({'visibility':'hidden', 'position': 'absolute', 'top': '-1000px', 'left': '-1000px'});			
			$(document.body).append($iframe)
			$iframe[0].onload = function() {
				this.contentWindow.print();				
	        }
	        $iframe.attr('src' ,printInfo.reportFile);	        
	    }
    },

	_deinit: function() {
		$( "#" + gx.printing.IFrameId).remove();		
	}
	}
})(gx.$);

gx.thread = {
	Map: function () {
		this.map = {};

		this.add = function (k, o) {
			this.map[k] = o;
		}

		this.remove = function (k) {
			delete this.map[k];
		}

		this.get = function (k) {
			return k == null ? null : this.map[k];
		}

		this.first = function () {
			return this.get(this.nextKey());
		}

		this.next = function (k) {
			return this.get(this.nextKey(k));
		}

		this.nextKey = function (k) {
			for (i in this.map) {
				if (!k) {
					return i;
				}
				if (k == i) {
					k = null;
				}
			}
			return null;
		}
	},

	Command: function (obj, func, args) {
		if (!gx.thread.Command.LastID) {
			gx.thread.Command.LastID = 0;
		}

		this.id = ++gx.thread.Command.LastID;

		this.execute = function () {
			func.apply(obj, args);
		}

		this.syncExecute = function () {
			new gx.thread.Mutex(this, 'execute');
		}
	},

	Mutex: function (obj, func, args, callback) {
		if (!gx.thread.Mutex.Wait) {
			gx.thread.Mutex.Wait = new gx.thread.Map();
		}

		gx.thread.Mutex.SLICE = function (cmdID, startID) {
			gx.thread.Mutex.Wait.get(cmdID).attempt(gx.thread.Mutex.Wait.get(startID));
		}

		this.attempt = function (start) {
			for (var j = start; j; j = gx.thread.Mutex.Wait.next(j.c.id)) {
				if (j.enter || (j.number && (j.number < this.number || (j.number == this.number && j.c.id < this.c.id))))
					return setTimeout('gx.thread.Mutex.SLICE(' + this.c.id + ',' + j.c.id + ')', 10);
			}
			try {
				retVal = this.c.execute();
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'Mutex Call');
			}
			this.number = 0;
			gx.thread.Mutex.Wait.remove(this.c.id);
			if (typeof (callback) == 'function') {
				try {
					callback.call(obj, retVal);
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'Mutex CallBack');
				}
			}
		}

		this.c = new gx.thread.Command(obj, func, args);
		gx.thread.Mutex.Wait.add(this.c.id, this);
		this.enter = true;
		this.number = (new Date()).getTime();
		this.enter = false;
		this.attempt(gx.thread.Mutex.Wait.first());
	}
};

gx.sec = {
	key: null,
	iv: null,
	keyName: 'GX_AJAX_KEY',
	ivName: 'GX_AJAX_IV',
	secToken: null,
	secTokenName: 'AJAX_SECURITY_TOKEN',

	loadKey: function () {
		var k = gx.fn.getHidden(this.keyName);
		if (gx.lang.emptyObject(k))
			this.key = null;
		else
			this.key = k;
		if (this.key != null) {
			this.loadSecToken();
		}
		this.iv = gx.fn.getHidden(this.ivName);
	},

	loadSecToken: function () {
		var t = gx.fn.getHidden(this.secTokenName);
		if (gx.lang.emptyObject(t))
			this.secToken = null;
		else
			this.secToken = t;
	},

	encrypt: function (Value, Key) {
		try {
			Key = (Key == null) ? this.key : Key;
			if (Key != null) {
				var alg = this.rijndael;
				Key = alg.hexToByteArray(Key);
				var encrypted;
				if (this.iv != null) {
					encrypted = alg.rijndaelEncrypt(Value, Key, "CBC", alg.hexToByteArray(this.iv));
				} else {
					encrypted = alg.rijndaelEncrypt(Value, Key);
				}
				var encoded = alg.byteArrayToHex(encrypted);
				return encoded;
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfrmutl.js', 'encrypt');
		}
		return Value;
	},

	decrypt: function (Value, Key) {
		try {
			Key = (Key == null) ? this.key : Key;
			if (Key != null) {
				var alg = this.rijndael;
				Key = alg.hexToByteArray(Key);
				var decoded = alg.hexToByteArray(Value);
				var decrypted = alg.rijndaelDecrypt(decoded, Key, "CBC");
				return alg.byteArrayToString(decrypted);
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfrmutl.js', 'decrypt');
		}
		return Value;
	},

	_init: function () {
		this.rijndael._init();
	}
};

gx.MD5 = {
	RotateLeft: function (lValue, iShiftBits) {
		return (lValue << iShiftBits) | (lValue >>> (32 - iShiftBits));
	},

	AddUnsigned: function (lX, lY) {
		var lX4, lY4, lX8, lY8, lResult;
		lX8 = (lX & 0x80000000);
		lY8 = (lY & 0x80000000);
		lX4 = (lX & 0x40000000);
		lY4 = (lY & 0x40000000);
		lResult = (lX & 0x3FFFFFFF) + (lY & 0x3FFFFFFF);
		if (lX4 & lY4) {
			return (lResult ^ 0x80000000 ^ lX8 ^ lY8);
		}
		if (lX4 | lY4) {
			if (lResult & 0x40000000) {
				return (lResult ^ 0xC0000000 ^ lX8 ^ lY8);
			} else {
				return (lResult ^ 0x40000000 ^ lX8 ^ lY8);
			}
		} else {
			return (lResult ^ lX8 ^ lY8);
		}
	},

	F: function (x, y, z) { return (x & y) | ((~x) & z); },
	G: function (x, y, z) { return (x & z) | (y & (~z)); },
	H: function (x, y, z) { return (x ^ y ^ z); },
	I: function (x, y, z) { return (y ^ (x | (~z))); },

	FF: function (a, b, c, d, x, s, ac) {
		a = gx.MD5.AddUnsigned(a, gx.MD5.AddUnsigned(gx.MD5.AddUnsigned(gx.MD5.F(b, c, d), x), ac));
		return gx.MD5.AddUnsigned(gx.MD5.RotateLeft(a, s), b);
	},

	GG: function (a, b, c, d, x, s, ac) {
		a = gx.MD5.AddUnsigned(a, gx.MD5.AddUnsigned(gx.MD5.AddUnsigned(gx.MD5.G(b, c, d), x), ac));
		return gx.MD5.AddUnsigned(gx.MD5.RotateLeft(a, s), b);
	},

	HH: function (a, b, c, d, x, s, ac) {
		a = gx.MD5.AddUnsigned(a, gx.MD5.AddUnsigned(gx.MD5.AddUnsigned(gx.MD5.H(b, c, d), x), ac));
		return gx.MD5.AddUnsigned(gx.MD5.RotateLeft(a, s), b);
	},

	II: function (a, b, c, d, x, s, ac) {
		a = gx.MD5.AddUnsigned(a, gx.MD5.AddUnsigned(gx.MD5.AddUnsigned(gx.MD5.I(b, c, d), x), ac));
		return gx.MD5.AddUnsigned(gx.MD5.RotateLeft(a, s), b);
	},

	ConvertToWordArray: function (string) {
		var lWordCount;
		var lMessageLength = string.length;
		var lNumberOfWords_temp1 = lMessageLength + 8;
		var lNumberOfWords_temp2 = (lNumberOfWords_temp1 - (lNumberOfWords_temp1 % 64)) / 64;
		var lNumberOfWords = (lNumberOfWords_temp2 + 1) * 16;
		var lWordArray = Array(lNumberOfWords - 1);
		var lBytePosition = 0;
		var lByteCount = 0;
		while (lByteCount < lMessageLength) {
			lWordCount = (lByteCount - (lByteCount % 4)) / 4;
			lBytePosition = (lByteCount % 4) * 8;
			lWordArray[lWordCount] = (lWordArray[lWordCount] | (string.charCodeAt(lByteCount) << lBytePosition));
			lByteCount++;
		}
		lWordCount = (lByteCount - (lByteCount % 4)) / 4;
		lBytePosition = (lByteCount % 4) * 8;
		lWordArray[lWordCount] = lWordArray[lWordCount] | (0x80 << lBytePosition);
		lWordArray[lNumberOfWords - 2] = lMessageLength << 3;
		lWordArray[lNumberOfWords - 1] = lMessageLength >>> 29;
		return lWordArray;
	},

	WordToHex: function (lValue) {
		var WordToHexValue = "", WordToHexValue_temp = "", lByte, lCount;
		for (lCount = 0; lCount <= 3; lCount++) {
			lByte = (lValue >>> (lCount * 8)) & 255;
			WordToHexValue_temp = "0" + lByte.toString(16);
			WordToHexValue = WordToHexValue + WordToHexValue_temp.substr(WordToHexValue_temp.length - 2, 2);
		}
		return WordToHexValue;
	},

	Utf8Encode: function (string) {
		string = string.replace(/\r\n/g, "\n");
		var utftext = "";

		for (var n = 0; n < string.length; n++) {

			var c = string.charCodeAt(n);

			if (c < 128) {
				utftext += String.fromCharCode(c);
			}
			else if ((c > 127) && (c < 2048)) {
				utftext += String.fromCharCode((c >> 6) | 192);
				utftext += String.fromCharCode((c & 63) | 128);
			}
			else {
				utftext += String.fromCharCode((c >> 12) | 224);
				utftext += String.fromCharCode(((c >> 6) & 63) | 128);
				utftext += String.fromCharCode((c & 63) | 128);
			}
		}
		return utftext;
	},
	getHsh: function (string) {
		var x = Array();
		var k, AA, BB, CC, DD, a, b, c, d;
		var S11 = 7, S12 = 12, S13 = 17, S14 = 22;
		var S21 = 5, S22 = 9, S23 = 14, S24 = 20;
		var S31 = 4, S32 = 11, S33 = 16, S34 = 23;
		var S41 = 6, S42 = 10, S43 = 15, S44 = 21;

		string = gx.MD5.Utf8Encode(string);

		x = gx.MD5.ConvertToWordArray(string);

		a = 0x67452301; b = 0xEFCDAB89; c = 0x98BADCFE; d = 0x10325476;

		for (k = 0; k < x.length; k += 16) {
			AA = a; BB = b; CC = c; DD = d;
			a = gx.MD5.FF(a, b, c, d, x[k + 0], S11, 0xD76AA478);
			d = gx.MD5.FF(d, a, b, c, x[k + 1], S12, 0xE8C7B756);
			c = gx.MD5.FF(c, d, a, b, x[k + 2], S13, 0x242070DB);
			b = gx.MD5.FF(b, c, d, a, x[k + 3], S14, 0xC1BDCEEE);
			a = gx.MD5.FF(a, b, c, d, x[k + 4], S11, 0xF57C0FAF);
			d = gx.MD5.FF(d, a, b, c, x[k + 5], S12, 0x4787C62A);
			c = gx.MD5.FF(c, d, a, b, x[k + 6], S13, 0xA8304613);
			b = gx.MD5.FF(b, c, d, a, x[k + 7], S14, 0xFD469501);
			a = gx.MD5.FF(a, b, c, d, x[k + 8], S11, 0x698098D8);
			d = gx.MD5.FF(d, a, b, c, x[k + 9], S12, 0x8B44F7AF);
			c = gx.MD5.FF(c, d, a, b, x[k + 10], S13, 0xFFFF5BB1);
			b = gx.MD5.FF(b, c, d, a, x[k + 11], S14, 0x895CD7BE);
			a = gx.MD5.FF(a, b, c, d, x[k + 12], S11, 0x6B901122);
			d = gx.MD5.FF(d, a, b, c, x[k + 13], S12, 0xFD987193);
			c = gx.MD5.FF(c, d, a, b, x[k + 14], S13, 0xA679438E);
			b = gx.MD5.FF(b, c, d, a, x[k + 15], S14, 0x49B40821);
			a = gx.MD5.GG(a, b, c, d, x[k + 1], S21, 0xF61E2562);
			d = gx.MD5.GG(d, a, b, c, x[k + 6], S22, 0xC040B340);
			c = gx.MD5.GG(c, d, a, b, x[k + 11], S23, 0x265E5A51);
			b = gx.MD5.GG(b, c, d, a, x[k + 0], S24, 0xE9B6C7AA);
			a = gx.MD5.GG(a, b, c, d, x[k + 5], S21, 0xD62F105D);
			d = gx.MD5.GG(d, a, b, c, x[k + 10], S22, 0x2441453);
			c = gx.MD5.GG(c, d, a, b, x[k + 15], S23, 0xD8A1E681);
			b = gx.MD5.GG(b, c, d, a, x[k + 4], S24, 0xE7D3FBC8);
			a = gx.MD5.GG(a, b, c, d, x[k + 9], S21, 0x21E1CDE6);
			d = gx.MD5.GG(d, a, b, c, x[k + 14], S22, 0xC33707D6);
			c = gx.MD5.GG(c, d, a, b, x[k + 3], S23, 0xF4D50D87);
			b = gx.MD5.GG(b, c, d, a, x[k + 8], S24, 0x455A14ED);
			a = gx.MD5.GG(a, b, c, d, x[k + 13], S21, 0xA9E3E905);
			d = gx.MD5.GG(d, a, b, c, x[k + 2], S22, 0xFCEFA3F8);
			c = gx.MD5.GG(c, d, a, b, x[k + 7], S23, 0x676F02D9);
			b = gx.MD5.GG(b, c, d, a, x[k + 12], S24, 0x8D2A4C8A);
			a = gx.MD5.HH(a, b, c, d, x[k + 5], S31, 0xFFFA3942);
			d = gx.MD5.HH(d, a, b, c, x[k + 8], S32, 0x8771F681);
			c = gx.MD5.HH(c, d, a, b, x[k + 11], S33, 0x6D9D6122);
			b = gx.MD5.HH(b, c, d, a, x[k + 14], S34, 0xFDE5380C);
			a = gx.MD5.HH(a, b, c, d, x[k + 1], S31, 0xA4BEEA44);
			d = gx.MD5.HH(d, a, b, c, x[k + 4], S32, 0x4BDECFA9);
			c = gx.MD5.HH(c, d, a, b, x[k + 7], S33, 0xF6BB4B60);
			b = gx.MD5.HH(b, c, d, a, x[k + 10], S34, 0xBEBFBC70);
			a = gx.MD5.HH(a, b, c, d, x[k + 13], S31, 0x289B7EC6);
			d = gx.MD5.HH(d, a, b, c, x[k + 0], S32, 0xEAA127FA);
			c = gx.MD5.HH(c, d, a, b, x[k + 3], S33, 0xD4EF3085);
			b = gx.MD5.HH(b, c, d, a, x[k + 6], S34, 0x4881D05);
			a = gx.MD5.HH(a, b, c, d, x[k + 9], S31, 0xD9D4D039);
			d = gx.MD5.HH(d, a, b, c, x[k + 12], S32, 0xE6DB99E5);
			c = gx.MD5.HH(c, d, a, b, x[k + 15], S33, 0x1FA27CF8);
			b = gx.MD5.HH(b, c, d, a, x[k + 2], S34, 0xC4AC5665);
			a = gx.MD5.II(a, b, c, d, x[k + 0], S41, 0xF4292244);
			d = gx.MD5.II(d, a, b, c, x[k + 7], S42, 0x432AFF97);
			c = gx.MD5.II(c, d, a, b, x[k + 14], S43, 0xAB9423A7);
			b = gx.MD5.II(b, c, d, a, x[k + 5], S44, 0xFC93A039);
			a = gx.MD5.II(a, b, c, d, x[k + 12], S41, 0x655B59C3);
			d = gx.MD5.II(d, a, b, c, x[k + 3], S42, 0x8F0CCC92);
			c = gx.MD5.II(c, d, a, b, x[k + 10], S43, 0xFFEFF47D);
			b = gx.MD5.II(b, c, d, a, x[k + 1], S44, 0x85845DD1);
			a = gx.MD5.II(a, b, c, d, x[k + 8], S41, 0x6FA87E4F);
			d = gx.MD5.II(d, a, b, c, x[k + 15], S42, 0xFE2CE6E0);
			c = gx.MD5.II(c, d, a, b, x[k + 6], S43, 0xA3014314);
			b = gx.MD5.II(b, c, d, a, x[k + 13], S44, 0x4E0811A1);
			a = gx.MD5.II(a, b, c, d, x[k + 4], S41, 0xF7537E82);
			d = gx.MD5.II(d, a, b, c, x[k + 11], S42, 0xBD3AF235);
			c = gx.MD5.II(c, d, a, b, x[k + 2], S43, 0x2AD7D2BB);
			b = gx.MD5.II(b, c, d, a, x[k + 9], S44, 0xEB86D391);
			a = gx.MD5.AddUnsigned(a, AA);
			b = gx.MD5.AddUnsigned(b, BB);
			c = gx.MD5.AddUnsigned(c, CC);
			d = gx.MD5.AddUnsigned(d, DD);
		}
		var temp = gx.MD5.WordToHex(a) + gx.MD5.WordToHex(b) + gx.MD5.WordToHex(c) + gx.MD5.WordToHex(d);
		return temp.toLowerCase();
	}
};

gx.base64 = {
	b64: [],
	f64: [],

	decode: function (encStr) {
		try {
			if (window.atob) {
				return decodeURIComponent(atob(encStr).split('').map(function(c) {
					return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
				}).join(''));
			}
		}
		catch (e) {}
		return this.bytesToString(this.bytesFromUTF8Bytes(this.decodeImpl(encStr)));
	},

	encode: function (decStr) {
		try {
			if (window.btoa) {
				return btoa(encodeURIComponent(decStr).replace(/%([0-9A-F]{2})/g,
					function toSolidBytes(match, p1) {
						return String.fromCharCode('0x' + p1);
					}
				));
			}
		}
		catch (e) {}
		return this.encodeImpl(this.UTF8BytesFromString(decStr));
	},

	bytesFromUTF8Bytes: function (Arr) {
		var outArr = [];
		var i = 0;
		var c = c1 = c2 = 0;
		var len = Arr.length;
		while (i < len) {
			c = Arr[i];
			if (c < 128) {
				outArr.push(c);
				i++;
			}
			else if ((c > 191) && (c < 224)) {
				c2 = Arr[i + 1];
				outArr.push(((c & 31) << 6) | (c2 & 63));
				i += 2;
			}
			else {
				c2 = Arr[i + 1];
				c3 = Arr[i + 2];
				outArr.push(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
				i += 3;
			}
		}
		return outArr;
	},

	UTF8BytesFromString: function (Str) {
		Str = Str.replace(/\r\n/g, "\n");

		var utf8Arr = [];
		var len = Str.length;
		for (var n = 0; n < len; n++) {
			var c = Str.charCodeAt(n);
			if (c < 128) {
				utf8Arr.push(c);
			}
			else if ((c > 127) && (c < 2048)) {
				utf8Arr.push((c >> 6) | 192);
				utf8Arr.push(((c & 63) | 128));
			}
			else {
				utf8Arr.push(((c >> 12) | 224));
				utf8Arr.push((((c >> 6) & 63) | 128));
				utf8Arr.push(((c & 63) | 128));
			}
		}
		return utf8Arr;
	},

	bytesToString: function (Arr) {
		var BUFFER_SIZE = gx.util.browser.isChrome() ? 32765 : 50000;
		var strOut = [];
		while (Arr.length >= BUFFER_SIZE) {
			strOut.push(eval("String.fromCharCode(" + Arr.slice(0, BUFFER_SIZE).join(",") + ");"));
			Arr = Arr.slice(BUFFER_SIZE);
		}
		if (Arr.length != 0) {
			strOut.push(eval("String.fromCharCode(" + Arr.join(",") + ");"));
		}
		return strOut.join("");
	},

	decodeImpl: function (t) {
		var f64 = this.f64;
		var d = [];
		var i = 0;
		t = t.replace(/\n|\r/g, ""); t = t.replace(/=/g, "");
		var len = t.length;
		while (i < len) {
			d[d.length] = (f64[t.charAt(i)] << 2) | (f64[t.charAt(i + 1)] >> 4);
			d[d.length] = (((f64[t.charAt(i + 1)] & 15) << 4) | (f64[t.charAt(i + 2)] >> 2));
			d[d.length] = (((f64[t.charAt(i + 2)] & 3) << 6) | (f64[t.charAt(i + 3)]));
			i += 4;
		}
		if (t.length % 4 == 2)
			d = d.slice(0, d.length - 2);
		if (t.length % 4 == 3)
			d = d.slice(0, d.length - 1);
		return d;
	},

	encodeImpl: function (d) {
		var b64 = this.b64;
		var r = [];
		var i = 0;
		var dl = d.length;
		if ((dl % 3) == 1) {
			d[d.length] = 0;
			d[d.length] = 0;
		}
		if ((dl % 3) == 2)
			d[d.length] = 0;
		var len = d.length;
		while (i < len) {
			r[r.length] = b64[d[i] >> 2];
			r[r.length] = b64[((d[i] & 3) << 4) | (d[i + 1] >> 4)];
			r[r.length] = b64[((d[i + 1] & 15) << 2) | (d[i + 2] >> 6)];
			r[r.length] = b64[d[i + 2] & 63];
			i += 3;
		}
		if ((dl % 3) == 1)
			r[r.length - 1] = r[r.length - 2] = "=";
		if ((dl % 3) == 2)
			r[r.length - 1] = "=";
		var t = r.join("");
		return t;
	},

	_init: function () {
		var b64s = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/';
		var len = b64s.length;
		for (var i = 0; i < len; i++) {
			var c = b64s.charAt(i);
			this.b64[i] = c;
			this.f64[c] = i;
		}
	}
};

gx.webSocket = function (wsOpts) {
	var maxRetries = 3,
		retryDelay = 10000;

	this.reconnect = true;
	this.opened = false;
	this.initialized = false;
	this.retryCount = 0;
	this.maxRetries = wsOpts.maxRetries || maxRetries;
	this.retryDelay = wsOpts.retryDelay || retryDelay;

	var supported = function() {
		return "WebSocket" in window;
	};
	
	this._init = function(wsOpts) {
		if (!this.initialized && supported()) {	
			var wsOpts = wsOpts || {};
			wsOpts.clientId = wsOpts.clientId || '';
			wsOpts.basePath = wsOpts.basePath || '';
			this.namespace = '.' + wsOpts.namespace;
			try {
				var wsUrl = wsOpts.wsProtocol + wsOpts.host + wsOpts.basePath + wsOpts.resourceUrl + wsOpts.clientId;
				this.create(wsOpts.wsURL || wsUrl);
				this.initialized = true;
				this.wsOpts = wsOpts;
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'Could not initialize WebSocket');
			}
		}
	};

	var _this = this;
	var doRetry = function() {
		this.opened = false;
		this.initialized = false;
		if ( this.reconnect && (this.maxRetries == -1 || this.retryCount < this.maxRetries)) {
			this.retryCount++;
			gx.lang.doCallTimeout(this._init, this, [this.wsOpts], retryDelay);
		}
	};
	
	this.create = function(wsUrl) {
		try {
			this.ws = new WebSocket(wsUrl);
			this.ws.onopen = function () {
				_this.opened = true;
				_this.retryCount = 0;
				gx.fx.obs.notify('gx.ws.onOpen'+_this.namespace, []);
			};
			
			this.ws.onerror = function (msg) {
				gx.dbg.logDebug("gx.webSocket - Error: " + msg.data);
				gx.fx.obs.notify('gx.ws.onError'+_this.namespace, [msg.data]);
			};

			this.ws.onmessage = function (msg) {
				gx.dbg.logDebug("gx.webSocket - New Message: " + msg.data);
				gx.fx.obs.notify('gx.ws.onMessage'+_this.namespace, [msg.data]);
			};

			this.ws.onclose = function () {
				gx.dbg.logDebug("gx.webSocket - OnClose");
				if (_this.opened) {
					_this.retryCount = 0;
					doRetry.apply(_this);
				}
			};
		} 
		catch(e) {
			gx.lang.doCallTimeout(gx.fx.obs.notify, gx.fx.obs, ['gx.ws.onCtxError' + _this.namespace, [e]], 100);
		}
	};		

	window.onbeforeunload = function () {
		if (_this.opened) {
			_this.ws.close();
		}
	};
	
	this.close = function() {
		if (_this.opened) {
                        _this.opened = false;
			_this.ws.close();
		}
	};

	this.send = function( msg) {
		if (this.ws) {
			this.ws.send( msg);
		}
		else
			gx.dbg.logDebug("gx.webSocket - ws is not initialized");
	};

	this._init(wsOpts);
}

gx.util.alert = (function ($) {
	var initialized = false, 
	idSelector = '#gx-main-error', 
	shown = false;
	
	var init = function() {
		if (!initialized || $(idSelector).length == 0) {
			$(gx.dom.form()).prepend("<div id='gx-main-error' style='display:none;'></div>");
			initialized = true;
		}
		hide();
	};

	var show = function( Opts) {
		var Opts = Opts || {},
			message = Opts.message || '',
			cssClasses = Opts.cssClass || '',
			cssDisBtnClass = Opts.cssDisBtnClass || '',
			dataDisAtt = Opts.dataDisAtt,
			dismissmitAt = Opts.dismissmitAt;
			
		init();
		var gxError = $(idSelector);
		gxError.html('<div class="' + cssClasses + '"><button type="button" class="' + cssDisBtnClass + '" data-dismiss="' + dataDisAtt + '" onclick=\'$(this).parent().hide();\' aria-hidden="true">&times;</button><span>' + message + '</span></div>');
		gxError.slideDown();
		shown = true;
		if (dismissmitAt) {
			window.setTimeout(function() { hide() }, dismissmitAt);
		}
	};

	var hide = function() {
		if (shown) {
			$(idSelector).fadeOut( 500, function() {$(this).empty();});
			shown = false;
		}
	};
		
	return {			
		
		showMessage: function(message, Opts) {
			var cssClass = "alert alert-warning alert-dismissable gx-ajax-error",
				cssDisBtnClass = "close",
				dataDisAtt = "alert";
			var gxError = $(idSelector);
			show( $.extend({	message: message, 
								cssClass:cssClass, 
								cssDisBtnClass:cssDisBtnClass, 
								dataDisAtt:dataDisAtt
							},
							Opts)
				);
		},

		showError: function(message, Opts) {
			var cssClass = "alert alert-danger alert-dismissable gx-ajax-error",
				cssDisBtnClass = "close",
				dataDisAtt = "alert";
			var gxError = $(idSelector);
			show( $.extend({	message: message, 
					cssClass:cssClass, 
					cssDisBtnClass:cssDisBtnClass, 
					dataDisAtt:dataDisAtt},
					Opts)
				);
		},
		
		hide: hide
	}
})(gx.$);

gx.geolocation = (function ($) {
	return {
		attachedCtrls: null,

		_init: function () {
			attachedCtrls = [];
		},

		getMyPosition: function (Ctrl) {
			Ctrl.attachedCtrl = $("#" + Ctrl.id.replace(/_geoLocMe$/, ""))[0];
			attachedCtrls.push(Ctrl);
			if (navigator.geolocation)
				navigator.geolocation.getCurrentPosition(this.positionHandler, this.handle_errors);
			else {
				msg = "Your browser does not support HTML5 Geolocalization";
				gx.pO.clearMessages();
				gx.pO.addMessage(msg);
				gx.pO.refreshOutputs([]);
			}
		},

		positionHandler: function (a) {
			var Ctrl = attachedCtrls.shift();
			var d = gx.fn.validStruct(gx.O.getValidStructId(Ctrl.attachedCtrl.id));
			var c = a.coords.latitude + "," + a.coords.longitude;
			gx.evt.setEventRow(gx.pO, Ctrl.attachedCtrl);
			if (d.v2v) {
				d.v2v(c);
				d.v2c();
			}
			if (d.gxgrid)
				d.gxgrid.updateControlValue(d, true);
		},

		handle_errors: function (a) {
			var b = attachedCtrls.shift();
			var msg;
			switch (a.code) {
				case a.PERMISSION_DENIED:
					msg = "user did not share geolocation data";
					break;
				case a.POSITION_UNAVAILABLE:
					msg = "could not detect current position";
					break;
				case a.TIMEOUT:
					msg = "retrieving position timed out";
					break;
				default:
					msg = "unknown error";
			}
			gx.pO.clearMessages();
			gx.pO.addMessage(msg);
			gx.pO.refreshOutputs([]);
		}

	};
})(gx.$);
/* END OF FILE - ..\js\gxfrmutl_i.js - */
/* START OF FILE - ..\js\rijndael.js - */
/* rijndael.js      Rijndael Reference Implementation
   Copyright (c) 2001 Fritz Schneider
 
 This software is provided as-is, without express or implied warranty.  
 Permission to use, copy, modify, distribute or sell this software, with or
 without fee, for any purpose and by any individual or organization, is hereby
 granted, provided that the above copyright notice and this paragraph appear 
 in all copies. Distribution as a part of an application or binary must
 include the above copyright notice in the documentation and/or other materials
 provided with the application or distribution.


   As the above disclaimer notes, you are free to use this code however you
   want. However, I would request that you send me an email 
   (fritz /at/ cs /dot/ ucsd /dot/ edu) to say hi if you find this code useful
   or instructional. Seeing that people are using the code acts as 
   encouragement for me to continue development. If you *really* want to thank
   me you can buy the book I wrote with Thomas Powell, _JavaScript:
   _The_Complete_Reference_ :)

   This code is an UNOPTIMIZED REFERENCE implementation of Rijndael. 
   If there is sufficient interest I can write an optimized (word-based, 
   table-driven) version, although you might want to consider using a 
   compiled language if speed is critical to your application. As it stands,
   one run of the monte carlo test (10,000 encryptions) can take up to 
   several minutes, depending upon your processor. You shouldn't expect more
   than a few kilobytes per second in throughput.

   Also note that there is very little error checking in these functions. 
   Doing proper error checking is always a good idea, but the ideal 
   implementation (using the instanceof operator and exceptions) requires
   IE5+/NS6+, and I've chosen to implement this code so that it is compatible
   with IE4/NS4. 

   And finally, because JavaScript doesn't have an explicit byte/char data 
   type (although JavaScript 2.0 most likely will), when I refer to "byte" 
   in this code I generally mean "32 bit integer with value in the interval 
   [0,255]" which I treat as a byte.

   See http://www-cse.ucsd.edu/~fritz/rijndael.html for more documentation
   of the (very simple) API provided by this code.

                                               Fritz Schneider
                                               fritz at cs.ucsd.edu
 
*/

gx.sec.rijndael = {
	// Rijndael parameters --  Valid values are 128, 192, or 256

	keySizeInBits: 128,
	blockSizeInBits: 128,

	// The number of rounds for the cipher, indexed by [Nk][Nb]
	roundsArray: [, , , , [, , , , 10, , 12, , 14], ,
	                   [, , , , 12, , 12, , 14], ,
	                   [, , , , 14, , 14, , 14]],

	///////  You shouldn't have to modify anything below this line except for
	///////  the function getRandomBytes().
	//
	// Note: in the following code the two dimensional arrays are indexed as
	//       you would probably expect, as array[row][column]. The state arrays
	//       are 2d arrays of the form state[4][Nb].

	// The number of bytes to shift by in shiftRow, indexed by [Nb][row]
	shiftOffsets: [, , , , [, 1, 2, 3], , [, 1, 2, 3], , [, 1, 3, 4]],

	// The round constants used in subkey expansion
	Rcon: [0x01, 0x02, 0x04, 0x08, 0x10, 0x20,
					0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8,
					0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc,
					0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4,
					0xb3, 0x7d, 0xfa, 0xef, 0xc5, 0x91],

	// Precomputed lookup table for the SBox
	SBox: [99, 124, 119, 123, 242, 107, 111, 197, 48, 1, 103, 43, 254, 215, 171,
				 118, 202, 130, 201, 125, 250, 89, 71, 240, 173, 212, 162, 175, 156, 164,
				 114, 192, 183, 253, 147, 38, 54, 63, 247, 204, 52, 165, 229, 241, 113,
				 216, 49, 21, 4, 199, 35, 195, 24, 150, 5, 154, 7, 18, 128, 226,
				 235, 39, 178, 117, 9, 131, 44, 26, 27, 110, 90, 160, 82, 59, 214,
				 179, 41, 227, 47, 132, 83, 209, 0, 237, 32, 252, 177, 91, 106, 203,
				 190, 57, 74, 76, 88, 207, 208, 239, 170, 251, 67, 77, 51, 133, 69,
				 249, 2, 127, 80, 60, 159, 168, 81, 163, 64, 143, 146, 157, 56, 245,
				 188, 182, 218, 33, 16, 255, 243, 210, 205, 12, 19, 236, 95, 151, 68,
				  23, 196, 167, 126, 61, 100, 93, 25, 115, 96, 129, 79, 220, 34, 42,
				 144, 136, 70, 238, 184, 20, 222, 94, 11, 219, 224, 50, 58, 10, 73,
				   6, 36, 92, 194, 211, 172, 98, 145, 149, 228, 121, 231, 200, 55, 109,
				 141, 213, 78, 169, 108, 86, 244, 234, 101, 122, 174, 8, 186, 120, 37,
				  46, 28, 166, 180, 198, 232, 221, 116, 31, 75, 189, 139, 138, 112, 62,
				 181, 102, 72, 3, 246, 14, 97, 53, 87, 185, 134, 193, 29, 158, 225,
				 248, 152, 17, 105, 217, 142, 148, 155, 30, 135, 233, 206, 85, 40, 223,
				 140, 161, 137, 13, 191, 230, 66, 104, 65, 153, 45, 15, 176, 84, 187,
				  22],

	// Precomputed lookup table for the inverse SBox
	SBoxInverse: [82, 9, 106, 213, 48, 54, 165, 56, 191, 64, 163, 158, 129, 243, 215,
								251, 124, 227, 57, 130, 155, 47, 255, 135, 52, 142, 67, 68, 196, 222,
								233, 203, 84, 123, 148, 50, 166, 194, 35, 61, 238, 76, 149, 11, 66,
								250, 195, 78, 8, 46, 161, 102, 40, 217, 36, 178, 118, 91, 162, 73,
								109, 139, 209, 37, 114, 248, 246, 100, 134, 104, 152, 22, 212, 164, 92,
								204, 93, 101, 182, 146, 108, 112, 72, 80, 253, 237, 185, 218, 94, 21,
								 70, 87, 167, 141, 157, 132, 144, 216, 171, 0, 140, 188, 211, 10, 247,
								228, 88, 5, 184, 179, 69, 6, 208, 44, 30, 143, 202, 63, 15, 2,
								193, 175, 189, 3, 1, 19, 138, 107, 58, 145, 17, 65, 79, 103, 220,
								234, 151, 242, 207, 206, 240, 180, 230, 115, 150, 172, 116, 34, 231, 173,
								 53, 133, 226, 249, 55, 232, 28, 117, 223, 110, 71, 241, 26, 113, 29,
								 41, 197, 137, 111, 183, 98, 14, 170, 24, 190, 27, 252, 86, 62, 75,
								198, 210, 121, 32, 154, 219, 192, 254, 120, 205, 90, 244, 31, 221, 168,
								 51, 136, 7, 199, 49, 177, 18, 16, 89, 39, 128, 236, 95, 96, 81,
								127, 169, 25, 181, 74, 13, 45, 229, 122, 159, 147, 201, 156, 239, 160,
								224, 59, 77, 174, 42, 245, 176, 200, 235, 187, 60, 131, 83, 153, 97,
								 23, 43, 4, 126, 186, 119, 214, 38, 225, 105, 20, 99, 85, 33, 12,
								125],

	// This method circularly shifts the array left by the number of elements
	// given in its parameter. It returns the resulting array and is used for 
	// the ShiftRow step. Note that shift() and push() could be used for a more 
	// elegant solution, but they require IE5.5+, so I chose to do it manually. 

	cyclicShiftLeft: function (theArray, positions) {
		var temp = theArray.slice(0, positions);
		theArray = theArray.slice(positions).concat(temp);
		return theArray;
	},

	// Multiplies the element "poly" of GF(2^8) by x. See the Rijndael spec.

	xtime: function (poly) {
		poly <<= 1;
		return ((poly & 0x100) ? (poly ^ 0x11B) : (poly));
	},

	// Multiplies the two elements of GF(2^8) together and returns the result.
	// See the Rijndael spec, but should be straightforward: for each power of
	// the indeterminant that has a 1 coefficient in x, add y times that power
	// to the result. x and y should be bytes representing elements of GF(2^8)

	mult_GF256: function (x, y) {
		var bit, result = 0;

		for (bit = 1; bit < 256; bit *= 2, y = this.xtime(y)) {
			if (x & bit)
				result ^= y;
		}
		return result;
	},

	// Performs the substitution step of the cipher. State is the 2d array of
	// state information (see spec) and direction is string indicating whether
	// we are performing the forward substitution ("encrypt") or inverse 
	// substitution (anything else)

	byteSub: function (state, direction) {
		var S;
		if (direction == "encrypt")           // Point S to the SBox we're using
			S = this.SBox;
		else
			S = this.SBoxInverse;
		for (var i = 0; i < 4; i++)           // Substitute for every byte in state
			for (var j = 0; j < this.Nb; j++)
				state[i][j] = S[state[i][j]];
	},

	// Performs the row shifting step of the cipher.

	shiftRow: function (state, direction) {
		for (var i = 1; i < 4; i++)               // Row 0 never shifts
			if (direction == "encrypt")
				state[i] = this.cyclicShiftLeft(state[i], this.shiftOffsets[this.Nb][i]);
			else
				state[i] = this.cyclicShiftLeft(state[i], this.Nb - this.shiftOffsets[this.Nb][i]);
	},

	// Performs the column mixing step of the cipher. Most of these steps can
	// be combined into table lookups on 32bit values (at least for encryption)
	// to greatly increase the speed. 

	mixColumn: function (state, direction) {
		var b = [];                            // Result of matrix multiplications
		for (var j = 0; j < this.Nb; j++) {    // Go through each column...
			for (var i = 0; i < 4; i++) {        // and for each row in the column...
				if (direction == "encrypt")
					b[i] = this.mult_GF256(state[i][j], 2) ^          // perform mixing
						   this.mult_GF256(state[(i + 1) % 4][j], 3) ^
						   state[(i + 2) % 4][j] ^
						   state[(i + 3) % 4][j];
				else
					b[i] = this.mult_GF256(state[i][j], 0xE) ^
						   this.mult_GF256(state[(i + 1) % 4][j], 0xB) ^
						   this.mult_GF256(state[(i + 2) % 4][j], 0xD) ^
						   this.mult_GF256(state[(i + 3) % 4][j], 9);
			}
			for (var i = 0; i < 4; i++)          // Place result back into column
				state[i][j] = b[i];
		}
	},

	// Adds the current round key to the state information. Straightforward.

	addRoundKey: function (state, roundKey) {
		for (var j = 0; j < this.Nb; j++) {            // Step through columns...
			state[0][j] ^= (roundKey[j] & 0xFF);         // and XOR
			state[1][j] ^= ((roundKey[j] >> 8) & 0xFF);
			state[2][j] ^= ((roundKey[j] >> 16) & 0xFF);
			state[3][j] ^= ((roundKey[j] >> 24) & 0xFF);
		}
	},

	// This function creates the expanded key from the input (128/192/256-bit)
	// key. The parameter key is an array of bytes holding the value of the key.
	// The returned value is an array whose elements are the 32-bit words that 
	// make up the expanded key.

	keyExpansion: function (key) {
		var expandedKey = [];
		var temp;

		// in case the key size or parameters were changed...
		this.Nk = this.keySizeInBits / 32;
		this.Nb = this.blockSizeInBits / 32;
		this.Nr = this.roundsArray[this.Nk][this.Nb];

		for (var j = 0; j < this.Nk; j++)     // Fill in input key first
			expandedKey[j] =
			  (key[4 * j]) | (key[4 * j + 1] << 8) | (key[4 * j + 2] << 16) | (key[4 * j + 3] << 24);

		// Now walk down the rest of the array filling in expanded key bytes as
		// per Rijndael's spec
		for (j = this.Nk; j < this.Nb * (this.Nr + 1) ; j++) {    // For each word of expanded key
			temp = expandedKey[j - 1];
			if (j % this.Nk == 0)
				temp = ((this.SBox[(temp >> 8) & 0xFF]) |
						 (this.SBox[(temp >> 16) & 0xFF] << 8) |
						 (this.SBox[(temp >> 24) & 0xFF] << 16) |
						 (this.SBox[temp & 0xFF] << 24)) ^ this.Rcon[Math.floor(j / this.Nk) - 1];
			else if (this.Nk > 6 && j % this.Nk == 4)
				temp = (this.SBox[(temp >> 24) & 0xFF] << 24) |
					   (this.SBox[(temp >> 16) & 0xFF] << 16) |
					   (this.SBox[(temp >> 8) & 0xFF] << 8) |
					   (this.SBox[temp & 0xFF]);
			expandedKey[j] = expandedKey[j - this.Nk] ^ temp;
		}
		return expandedKey;
	},

	// Rijndael's round functions... 

	Round: function (state, roundKey) {
		this.byteSub(state, "encrypt");
		this.shiftRow(state, "encrypt");
		this.mixColumn(state, "encrypt");
		this.addRoundKey(state, roundKey);
	},

	InverseRound: function (state, roundKey) {
		this.addRoundKey(state, roundKey);
		this.mixColumn(state, "decrypt");
		this.shiftRow(state, "decrypt");
		this.byteSub(state, "decrypt");
	},

	FinalRound: function (state, roundKey) {
		this.byteSub(state, "encrypt");
		this.shiftRow(state, "encrypt");
		this.addRoundKey(state, roundKey);
	},

	InverseFinalRound: function (state, roundKey) {
		this.addRoundKey(state, roundKey);
		this.shiftRow(state, "decrypt");
		this.byteSub(state, "decrypt");
	},

	// encrypt is the basic encryption function. It takes parameters
	// block, an array of bytes representing a plaintext block, and expandedKey,
	// an array of words representing the expanded key previously returned by
	// keyExpansion(). The ciphertext block is returned as an array of bytes.

	encrypt: function (block, expandedKey) {
		var i;
		if (!block || block.length * 8 != this.blockSizeInBits)
			return;
		if (!expandedKey)
			return;

		block = this.packBytes(block);
		this.addRoundKey(block, expandedKey);
		for (i = 1; i < this.Nr; i++)
			this.Round(block, expandedKey.slice(this.Nb * i, this.Nb * (i + 1)));
		this.FinalRound(block, expandedKey.slice(this.Nb * this.Nr));
		return this.unpackBytes(block);
	},

	// decrypt is the basic decryption function. It takes parameters
	// block, an array of bytes representing a ciphertext block, and expandedKey,
	// an array of words representing the expanded key previously returned by
	// keyExpansion(). The decrypted block is returned as an array of bytes.

	decrypt: function (block, expandedKey) {
		var i;
		if (!block || block.length * 8 != this.blockSizeInBits)
			return;
		if (!expandedKey)
			return;

		block = this.packBytes(block);
		this.InverseFinalRound(block, expandedKey.slice(this.Nb * this.Nr));
		for (i = this.Nr - 1; i > 0; i--)
			this.InverseRound(block, expandedKey.slice(this.Nb * i, this.Nb * (i + 1)));
		this.addRoundKey(block, expandedKey);
		return this.unpackBytes(block);
	},

	// This method takes a byte array (byteArray) and converts it to a string by
	// applying String.fromCharCode() to each value and concatenating the result.
	// The resulting string is returned. Note that this function SKIPS zero bytes
	// under the assumption that they are padding added in formatPlaintext().
	// Obviously, do not invoke this method on raw data that can contain zero
	// bytes. It is really only appropriate for printable ASCII/Latin-1 
	// values. Roll your own function for more robust functionality :)

	byteArrayToString: function (byteArray) {
		var result = "";
		var len = byteArray.length;
		for (var i = 0; i < len; i++)
			if (byteArray[i] != 0)
				result += String.fromCharCode(byteArray[i]);
		return result;
	},

	stringToByteArray: function (strText) {
		var result = [];
		var len = strText.length;
		for (var i = 0; i < len; i++)
			result[result.length] = strText.charCodeAt();
		return result;
	},

	// This function takes an array of bytes (byteArray) and converts them
	// to a hexadecimal string. Array element 0 is found at the beginning of 
	// the resulting string, high nibble first. Consecutive elements follow
	// similarly, for example [16, 255] --> "10ff". The function returns a 
	// string.

	byteArrayToHex: function (byteArray) {
		var result = "";
		if (!byteArray)
			return;
		var len = byteArray.length;
		for (var i = 0; i < len; i++)
			result += ((byteArray[i] < 16) ? "0" : "") + byteArray[i].toString(16);

		return result;
	},

	// This function converts a string containing hexadecimal digits to an 
	// array of bytes. The resulting byte array is filled in the order the
	// values occur in the string, for example "10FF" --> [16, 255]. This
	// function returns an array. 

	hexToByteArray: function (hexString) {
		var byteArray = [];
		if (hexString.length % 2)             // must have even length
			return;
		if (hexString.indexOf("0x") == 0 || hexString.indexOf("0X") == 0)
			hexString = hexString.substring(2);
		var len = hexString.length;
		for (var i = 0; i < len; i += 2)
			byteArray[Math.floor(i / 2)] = parseInt(hexString.slice(i, i + 2), 16);
		return byteArray;
	},

	// This function packs an array of bytes into the four row form defined by
	// Rijndael. It assumes the length of the array of bytes is divisible by
	// four. Bytes are filled in according to the Rijndael spec (starting with
	// column 0, row 0 to 3). This function returns a 2d array.

	packBytes: function (octets) {
		var state = [];
		if (!octets || octets.length % 4)
			return;

		state[0] = [];
		state[1] = [];
		state[2] = [];
		state[3] = [];
		var len = octets.length;
		for (var j = 0; j < len; j += 4) {
			state[0][j / 4] = octets[j];
			state[1][j / 4] = octets[j + 1];
			state[2][j / 4] = octets[j + 2];
			state[3][j / 4] = octets[j + 3];
		}
		return state;
	},

	// This function unpacks an array of bytes from the four row format preferred
	// by Rijndael into a single 1d array of bytes. It assumes the input "packed"
	// is a packed array. Bytes are filled in according to the Rijndael spec. 
	// This function returns a 1d array of bytes.

	unpackBytes: function (packed) {
		var result = [];
		var len = packed[0].length;
		for (var j = 0; j < len; j++) {
			result[result.length] = packed[0][j];
			result[result.length] = packed[1][j];
			result[result.length] = packed[2][j];
			result[result.length] = packed[3][j];
		}
		return result;
	},

	// This function takes a prospective plaintext (string or array of bytes)
	// and pads it with zero bytes if its length is not a multiple of the block 
	// size. If plaintext is a string, it is converted to an array of bytes
	// in the process. The type checking can be made much nicer using the 
	// instanceof operator, but this operator is not available until IE5.0 so I 
	// chose to use the heuristic below. 

	formatPlaintext: function (plaintext) {
		var bpb = this.blockSizeInBits / 8;			// bytes per block
		var i;

		// if primitive string or String instance
		if (typeof plaintext == "string" || plaintext.indexOf) {
			plaintext = plaintext.split("");
			// Unicode issues here (ignoring high byte)
			var len = plaintext.length;
			for (i = 0; i < len; i++)
				plaintext[i] = plaintext[i].charCodeAt(0) & 0xFF;
		}

		for (i = bpb - (plaintext.length % bpb) ; i > 0 && i < bpb; i--)
			plaintext[plaintext.length] = 0;

		return plaintext;
	},

	// rijndaelEncrypt(plaintext, key, mode)
	// Encrypts the plaintext using the given key and in the given mode. 
	// The parameter "plaintext" can either be a string or an array of bytes. 
	// The parameter "key" must be an array of key bytes. If you have a hex 
	// string representing the key, invoke hexToByteArray() on it to convert it 
	// to an array of bytes. The third parameter "mode" is a string indicating
	// the encryption mode to use, either "ECB" or "CBC". If the parameter is
	// omitted, ECB is assumed.
	// 
	// An array of bytes representing the cihpertext is returned. To convert 
	// this array to hex, invoke byteArrayToHex() on it. If you are using this 
	// "for real" it is a good idea to change the function getRandomBytes() to 
	// something that returns truly random bits.

	rijndaelEncrypt: function (plaintext, key, mode, ivector) {
		var expandedKey, i, aBlock;
		var bpb = this.blockSizeInBits / 8;     // bytes per block
		var ct;                                 // ciphertext

		if (!plaintext || !key)
			return;
		if (key.length * 8 != this.keySizeInBits)
			return;
		if (mode == "CBC") {
			ct = ivector;
		}
		else {
			mode = "ECB";
			ct = [];
		}

		// convert plaintext to byte array and pad with zeros if necessary. 
		plaintext = this.formatPlaintext(plaintext);

		expandedKey = this.keyExpansion(key);

		for (var block = 0; block < plaintext.length / bpb; block++) {
			aBlock = plaintext.slice(block * bpb, (block + 1) * bpb);
			if (mode == "CBC") 
				for (var i = 0; i < bpb; i++)
					aBlock[i] ^= ct[block * bpb + i];
			ct = ct.concat(this.encrypt(aBlock, expandedKey));
		}

		return ct;
	},

	// rijndaelDecrypt(ciphertext, key, mode)
	// Decrypts the using the given key and mode. The parameter "ciphertext" 
	// must be an array of bytes. The parameter "key" must be an array of key 
	// bytes. If you have a hex string representing the ciphertext or key, 
	// invoke hexToByteArray() on it to convert it to an array of bytes. The
	// parameter "mode" is a string, either "CBC" or "ECB".
	// 
	// An array of bytes representing the plaintext is returned. To convert 
	// this array to a hex string, invoke byteArrayToHex() on it. To convert it 
	// to a string of characters, you can use byteArrayToString().

	rijndaelDecrypt: function (ciphertext, key, mode) {
		var expandedKey;
		var bpb = this.blockSizeInBits / 8;     // bytes per block
		var pt = [];                   					// plaintext array
		var aBlock;                             // a decrypted block
		var block;                              // current block number

		if (!ciphertext || !key || typeof ciphertext == "string")
			return;
		if (key.length * 8 != this.keySizeInBits)
			return;
		if (!mode)
			mode = "ECB";                         // assume ECB if mode omitted

		expandedKey = this.keyExpansion(key);

		// work backwards to accomodate CBC mode 
		for (block = (ciphertext.length / bpb) - 1; block > 0; block--) {
			aBlock =
			 this.decrypt(ciphertext.slice(block * bpb, (block + 1) * bpb), expandedKey);
			if (mode == "CBC")
				for (var i = 0; i < bpb; i++)
					pt[(block - 1) * bpb + i] = aBlock[i] ^ ciphertext[(block - 1) * bpb + i];
			else
				pt = aBlock.concat(pt);
		}

		// do last block if ECB (skips the IV in CBC)
		if (mode == "ECB")
			pt = this.decrypt(ciphertext.slice(0, bpb), expandedKey).concat(pt);

		return pt;
	},

	_init: function () {
		// Cipher parameters ... do not change these
		this.Nk = this.keySizeInBits / 32;
		this.Nb = this.blockSizeInBits / 32;
		this.Nr = this.roundsArray[this.Nk][this.Nb];
	}
};
/* END OF FILE - ..\js\rijndael.js - */
/* START OF FILE - ..\js\gxpopup.js - */
gx.popup = (function ($) {
	var MAX_CHECK_LOADED_TIMES_PDF = 10,
		POPUP_HEADER_CLASS = 'PopupHeader gx-popup-header',
		POPUP_RESIZE_CLASS = 'gx-popup-resize',		
		POPUP_CONTENT_CLASS = 'PopupContent gx-popup-content',
		POPUP_DEFAULT = 'gx-popup-default',
		POPUP_CLASS = 'PopupBorder gx-popup' + " " + POPUP_DEFAULT,		
		POPUP_CLOSE_CLASS = 'PopupHeaderButton gx-popup-close',
		POPUP_CENTERED_CLASS = 'gx-popup-centered',
		POPUP__HORIZONTAL_CENTERED_CLASS = 'gx-popup-horizontal-center',
		POPUP_INITIAL_SIZE_CLASS = 'gx-popup-initial',
		POPUP_IFRAME_CONTAINER_ATTR = 'data-gx-popup-ct';

	return {
		lvl: -1,
		currentPopup: null,
		currentPrompt: null,
		showParentPopups: false,

		Dialog: function () {
			this.id = '';
			this.autoresize = 1;
			this.width = 0;
			this.height = 0;
			this.position = 0;
			this.top = 0;
			this.cssClass = '';
			this.left = 0;
			this.zindex = 1000;
			this.lvl = -1;
			this.parentPopup = null;
			this.window = null;
			this.document = null;
			this.Opener = null;
			this.InternalPopup = null;
			this.state = 'created';
			this.callbacks = {};
			
			var bodyClickHandler = (function (e) {
				if ($(this.getEl()).find(e.target).length === 0) {
					$(document.body).off("click", bodyClickHandler);
					this.close();
				}
			}).closure(this);

			this.open = function (cfg) {
				this.state = 'opening';
				this.id = cfg.id || "gxdialog";
				this.callbacks = cfg.callbacks;
				var resizable = cfg.resizable === undefined || cfg.resizable;
				var popupClass = POPUP_CLASS;
				if (this.cssClass){
					popupClass = popupClass.replace(POPUP_DEFAULT, '');
					popupClass += " " + this.cssClass;
				}
				gx.popup.ext.window(this, false, 0, 0, cfg.w, cfg.h, cfg.contentHtml, "white", cfg.title, "black", "black", "black", "black", cfg.isModal === undefined || cfg.isModal, true, true, resizable, false, gx.ajax.getImageUrl(gx, 'resizeImage'), POPUP_HEADER_CLASS, POPUP_CLOSE_CLASS, POPUP_CONTENT_CLASS, popupClass, "PopupShadow", cfg.showParentPopups, false, cfg.callbacks, cfg.parentElement);
				gx.popup.ext.win.gx.popup.setPopup(this);
				this.state = 'opened'

				setTimeout(function () {
					$(document.body).on("click", bodyClickHandler);
				}, 1);
			};

			this.close = function () {
				$(document.body).off("click", bodyClickHandler);
				this.state = 'closing'
				gx.popup.ext.close(this, this.callbacks.beforeClose);
				this.cleanup();
				this.state = 'closed'
			};

			this.cleanup = function () {
				delete this.InternalPopup;
				delete this.window;
				delete this.document;
				delete this.Opener;
				delete this.parentPopup;
				delete this.InternalPopup;
				delete this.callbacks;
			};

			this.isActive = function () {
				return !(this.state == 'closed' || this.state == 'closing');
			};
			
			this.getEl = function() {
				return gx.dom.byId(this.id + '_b');
			};
		},

		Popup: function (popupData, IsPrompt) {
			this.url = '';
			this.frameDocument = null;
			this.frameWindow = null;
			this.ReturnParms = [];
			this.RawReturnedParms = [];
			this.ModifCtrl = null;
			this.IsPrompt = (IsPrompt) ? IsPrompt : false;
			this.PromptIsGet = false;
			this.OncloseCmds = [];
			this.CustomRenderGrid = null;

			this.setPopupData = function () {
				if (gx.lang.isArray(popupData)) {
					this.url = popupData[0];
					this.autoresize = popupData[1];
					this.width = popupData[2];
					this.height = popupData[3];
					this.position = popupData[4];
					this.top = popupData[5];
					this.left = popupData[6];
					this.OncloseCmds = popupData[7] || [];
					this.ReturnParms = popupData[8] || [];
					this.cssClass = popupData[9];
				}
				else if (popupData && popupData.Url) {
					this.url = popupData.Url;
					if (typeof (popupData.Autoresize) != 'undefined')
						this.autoresize = popupData.Autoresize;
					if (typeof (popupData.Width) != 'undefined')
						this.width = popupData.Width;
					if (typeof (popupData.Height) != 'undefined')
						this.height = popupData.Height;
					if (typeof (popupData.Position) != 'undefined')
						this.position = popupData.Position;
					if (typeof (popupData.Top) != 'undefined')
						this.top = popupData.Top;
					if (typeof (popupData.Left) != 'undefined')
						this.left = popupData.Left;
					if (typeof (popupData.Class) != 'undefined')
						this.cssClass = popupData.Class;
					if (typeof (popupData.OncloseCmds) != 'undefined')
						this.OncloseCmds = popupData.OncloseCmds;
					if (typeof (popupData.ReturnParms) != 'undefined')
						this.ReturnParms = popupData.ReturnParms;
				}
			}

			this.open = function () {
				this.state = 'opening';
				var pOpener = gx.popup.gxOpener();
				this.lvl = -1;
				if (pOpener && pOpener.gx && pOpener.gx.popup.ext.win && pOpener.gx.popup.ext.win.gx) {
					this.lvl = pOpener.gx.popup.ext.win.gx.popup.lvl;
				}
				else {
					this.lvl = gx.popup.lvl;
				}
				if (document.gxPopup != null) {
					this.parentPopup = document.gxPopup;
					this.zindex = gx.popup.ext.zdx + document.gxPopup.zindex;
				}
				else {
					this.zindex = gx.popup.ext.zdx;
				}
				var sUrl = this.url;
				if (this.IsPrompt) {
					gx.popup.currentPrompt = this;
					var sParms = "?";
					var parm = "";
					var parmValue = "";
					var len = this.ReturnParms.length;
					for (var i = 0; i < len; i++) {
						parm = "";
						if (!gx.lang.emptyObject(this.ReturnParms[i].Ctrl))
							parm = gx.util.urlValue(this.ReturnParms[i].Ctrl) + ",";
						else if (typeof this.ReturnParms[i] == "string")
							parm = gx.util.urlValue(this.ReturnParms[i]) + ",";
						else if (typeof this.ReturnParms[i] == "number")
							parm = gx.util.urlValue(this.ReturnParms[i].toString()) + ",";
						else if (this.CustomRenderGrid) {
							parmValue = this.CustomRenderGrid.grid.getCellValue(this.ReturnParms[i].id);
							if (!gx.lang.emptyObject(parmValue))
								parm = gx.util.urlValue(parmValue + "") + ",";
						}
						else if (!gx.lang.emptyObject(this.ReturnParms[i].id)){
							parmValue = gx.fn.getHidden(this.ReturnParms[i].id);
							if (!gx.lang.emptyObject(parmValue)){
								parm = gx.util.urlValue(parmValue);
							}
							parm += ",";
						}
						else
							continue;

						if (this.ReturnParms[i].IOType == 'out')
							sParms += ",";
						else
							sParms += parm;
						if ((this.ReturnParms[i].isLastKey) && (gx.fn.isOutputParm(this.ReturnParms[i])) && (!this.PromptIsGet)) {
							gx.fn.setControlValue('_EventName', this.Opener.CmpContext);
							this.PromptIsGet = true;
						}
					}
					if (this.ModifCtrl != null)
						this.ModifCtrl.value = 1;
					sUrl += sParms;
				}
				var activeElement = document.activeElement;
				if (gx.csv.lastControl && (activeElement && gx.util.inArray(activeElement.tagName, ['BODY', 'FORM']))) {
					activeElement = gx.csv.lastControl;
				}
				if (activeElement) {
					if (activeElement) {
						this.callerActiveElement = activeElement;
					}
					if (activeElement.blur) {
						activeElement.blur();
					}
				}
				this.InternalPopup = gx.popup.Impl(this, sUrl, this.autoresize, this.width, this.height, this.position, this.top, this.left);
			}

			this.getOutputParms = function () {
				var outputParms = [];
				if (this.IsPrompt) {
					var len = this.ReturnParms.length;
					for (var i = 0; i < len; i++) {
						var promptParm = this.ReturnParms[i];
						if (gx.fn.isOutputParm(promptParm))
							outputParms.push(promptParm);
					}
				}
				else {
					return this.ReturnParms;
				}
				return outputParms;
			}

			this.close = function (cParms, opts, gxO) {
				opts = opts || {};
				this.state = 'closing';
				if (cParms) {
					this.RawReturnedParms = cParms;
				}
				var win = window;
				if (gx.popup.ext.win) {
					win = gx.popup.ext.win;
					gx.ajax.windowClosed(gx.popup.ext.win.gx.popup.lvl);
					gx.popup.ext.win.gx.popup.lvl--;
				}
				else {
					gx.ajax.windowClosed(gx.popup.lvl);
					gx.popup.lvl--;
				}

				var customRenderSetCellValue = function () {
					var deferred = $.Deferred();
					this.setCellValue.apply(this, arguments);
					return deferred.resolve();
				};

				var close_impl = function () {
					var i, len;

					if (this.beforeClose) {
						this.beforeClose(cParms);
					}
					if (!this.isPdf && this.frameWindow && this.frameWindow.gx) {
						if (this.IsPrompt) {
							if (this.parentPopup == null)
								gx.popup.currentPrompt = null;
							else
								this.parentPopup.frameWindow.gx.popup.currentPrompt = null;
						}
						this.frameWindow.gx.evt.onunload.call(this.frameWindow);
						if (!gx.util.browser.isIE()) {
							this.frameDocument.gxPopup = null;
						}
						this.frameDocument = null;
						this.frameWindow = null;
					}
					gx.popup.ext.close(this);
					var returnParms = this.getOutputParms();

					var afterCloseFn = (function () {
						if (opts && opts.ignoreCmds === true)
							this.OncloseCmds = [];
						gx.ajax.dispatchCommands(this.OncloseCmds, undefined, { updateParms: returnParms });
						this.cleanup();
						this.state = 'closed';
						if (this.afterClose) {
							this.afterClose(cParms);
						}
						if (this.parentPopup) {
							this.parentPopup.frameWindow.gx.fx.obs.notify("popup.afterclose", [this]);
						}
						else {
							gx.fx.obs.notify("popup.afterclose", [this]);
						}
					}).closure(this);
					var callAfterClose = true;

					if ((cParms != null) && (this.IsPrompt)) {
						if (gxO && opts.parmsMetadata && opts.updateParms) {
							len = opts.parmsMetadata.length;
							for (i = 0; i < len; i++) {
								var parmMetadata = opts.parmsMetadata[i];
								if (gx.util.inArray(parmMetadata, opts.updateParms))
									cParms[i] = gxO[parmMetadata];
							}
						}

						len = cParms.length;
						var func = gx.popup.assignPromptFields;
						var scope = gx.popup;
						if (!gx.lang.emptyObject(this.CustomRenderGrid)) {
							func = customRenderSetCellValue;
							scope = this.CustomRenderGrid.grid;
						}

						callAfterClose = false;
						func.call(scope, returnParms, cParms).then((function () {
							var edtCtrl = null;
							len = returnParms.length;
							for (i = 0; i < len; i++) {
								var ctrl = returnParms[i].Ctrl;
								if (gx.fn.isAccepted(ctrl)) {
									edtCtrl = ctrl;
								}
							}
							if (edtCtrl && gx.TabOnPrompSelect) {
								var el = gx.fn.getControlIndex(edtCtrl);
								if (el != -1) {
									edtCtrl = gx.fn.searchFocus(el + 1, true);
								}
							}
							gx.fn.setFocus(edtCtrl);

							if (this.PromptIsGet) {
								if (this.Opener.fullAjax) {
									var ControlId,
									validStruct;
									ControlId = gx.csv.ctxControlId(edtCtrl.id);
									if (ControlId) {
										validStruct = gx.O.getValidStructFld(ControlId);
									}
									if (validStruct) {
										gx.csv.validControls(validStruct.id, validStruct.id + 1, true, this.Opener);
									}
								}
								else {
									gx.csv.loadScreen(function () {
										gx.fn.setFocus(edtCtrl); // setFocus before loadScreen does not always work
										afterCloseFn();
									});
									return;
								}
							} else {
								try {
									gx.evt.ctrlOnchange(gx.fn.getControlValue(this.Opener.CmpContext + 'Mode'),
									gx.fn.getControlValue(this.Opener.CmpContext + 'IsConfirmed'), (typeof (window.GXPkIsDirty) == "undefined" ? false : window.GXPkIsDirty), null, 'eng');
								}
								catch (e) {
									gx.dbg.logEx(e, 'gxpopup.js', 'close');
								}
							}
							afterCloseFn();
						}).closure(this));

					}
					else if (cParms) {
						if (returnParms && returnParms instanceof Array && returnParms.length > 0) {
							gx.fn.setReturnParms(this.Opener, returnParms, cParms, this.CustomRenderGrid);
						}
					}

					if (callAfterClose) {
						afterCloseFn();
					}
				};

				var browser = gx.util.browser;
				if (browser.isFirefox() || browser.isIE()) {
					win.setTimeout(close_impl.closure(this), 10);
				}
				else {
					close_impl.call(this);
				}
			};

			this.setFocusFirst = function () {
				if (this.frameWindow.gx) {
					this.frameWindow.gx.fn.setFocusOnload(false);
				}
			}

			this.cleanup = function () {
				try {
					this.OncloseCmds = [];
					this.ReturnParms = [];
					this.PromptIsGet = false;
					this.InternalPopup = null;
					this.window = null;
					this.document = null;
					this.Opener = null;
					this.parentPopup = null;
					this.RawReturnedParms = [];
					this.ModifCtrl = null;
					this.InternalPopup = null;
					this.CustomRenderGrid = null;
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxpopup.js', 'popupObj.cleanup');
				}
			}

			this.setPopupData();
		},

		getWindowIframeElement: function (win) {
			var iframeEl;		
			var iframes = win.document.getElementsByTagName("iframe");
			for (var i = 0; i < iframes.length && !iframeEl; i++) {
				var el = iframes[i];
				if (el.contentWindow === window) {
					iframeEl = el;
				}
			}		
			return iframeEl;
		},

		gxOpener: function () {
			try {
				parent.gxTestAvailable = 1;
				var iframeEl = this.getWindowIframeElement(parent);
				if (iframeEl && $(iframeEl).attr(POPUP_IFRAME_CONTAINER_ATTR) !== undefined) {
					return parent;
				}
				return window;
			}
			catch (e) {
			}
			return null;
		},

		setFocus: function () {
			var popUp = this.getPopup();
			if (popUp) {
				popUp.window.frames[0].focus();
			}
		},

		ispopup: function () {
			return (this.getPopup() != null);
		},

		popupurl: function () {
			return this.getPopup().url;
		},

		waitCallback: function (callback) {
			var popup = gx.popup.getPopup();
			if (popup) {
				if (popup.state == 'opened') {
					callback();
				}
				else {
					gx.lang.doCallTimeout(gx.popup.waitCallback, gx.popup, [callback], 50);
				}
			}
			else {
				callback();
			}
		},

		getPopup: function () {
			var pOpener = this.gxOpener();
			try {
				if (!gx.lang.emptyObject(pOpener) && !gx.lang.emptyObject(pOpener.gx)) {
					return pOpener.gx.popup.currentPopup;
				}
			}
			catch (e) {
			}
			return null;
		},

		setPopup: function (gxP) {
			this.currentPopup = gxP;
		},

		open: function (popupData, gxO) {
			return this.openPopup(popupData, gxO);
		},

		openUrlToOpenPopupParms: function (url, returnParms, props) {
			var az = 1;
			var w = 0;
			var h = 0;
			var p = 0;
			var t = 0;
			var l = 0;
			if (props) {
				az = props[0];
				w = props[1];
				h = props[2];
				p = props[3];
				t = props[4];
				l = props[5];
			}
			return [url, az, w, h, p, t, l, [], returnParms];
		},

		openUrl: function () {
			return this.openPopup(this.openUrlToOpenPopupParms.apply(this, arguments));
		},

		openPopup: function (popupData, gxO) {
			var currentPopup = this.getPopup();
			var grid, i, len, vStruct;
			if (!currentPopup || currentPopup.Opener !== gx.O || !gx.lang.isArray(popupData)) {
				var popup = new this.Popup(popupData, false);
				popup.Opener = gxO || gx.O;
				for (i=0, len=popup.ReturnParms.length; i<len; i++) {
					vStruct = gx.fn.vStructForVar(popup.ReturnParms[i]);
					if (vStruct && vStruct.grid) {
						grid = gx.O.getGridById(vStruct.grid);
						if (grid) {
							break;
						}
					}
				}
				if (grid && grid.isUsercontrol) {
					popup.CustomRenderGrid = grid;
				}
				popup.open();
				return popup;
			}
			else {
				currentPopup.OncloseCmds.push({popup: popupData});
			}
		},

		openDialog: function (dialogCfg) {
			var dialog = new this.Dialog();
			dialog.Opener = gx.O;

			dialog.open(dialogCfg);
			return dialog;
		},

		openPrompt: function (PgmName, PgmParms, IsMod, CmpCtx, InMasterPage, IsAuto) {
			if (gx.popup.currentPrompt == null) {
				if (CmpCtx) {
					gx.setGxO(CmpCtx, InMasterPage);
				}
				var Ctrl = PgmParms[0].Ctrl;
				var isUserControl = false;
				var rowGridId;
				var rowId;
				var grid;
				if (Ctrl) {
					rowGridId = gx.fn.rowGridId(Ctrl);
					rowId = gx.fn.controlRowId(Ctrl);
					if (!gx.lang.emptyObject(rowGridId) && !gx.lang.emptyObject(rowId)) {
						gx.csv.lastGrid = rowGridId;
						gx.fn.setCurrentGridRow(rowGridId, rowId);
					}
				}
				else {
					var Id;
					for (var i = 0, len = PgmParms.length; i < len; i++) {
						if (PgmParms[i].IOType) {
							Id = PgmParms[i].id
							break;
						}
					}
					if (Id) {
						var vStruct = gx.O.getValidStructFld(Id);
						if (!gx.lang.emptyObject(vStruct)) {
							grid = gx.O.getGridById(vStruct.grid);
							if (grid) {
								isUserControl = grid.isUsercontrol;
								if (isUserControl) {
									rowGridId = grid.gridId + "";
									rowId = (!gx.lang.emptyObject(grid.grid.getSelectedRow)) ? gx.text.padl(grid.grid.getSelectedRow() + "", 4, "0") : undefined;
									if (!gx.lang.emptyObject(rowGridId) && !gx.lang.emptyObject(rowId)) {
										gx.csv.lastGrid = rowGridId;
										gx.fn.setCurrentGridRow(rowGridId, rowId);
									}
								}
							}
						}
					}
				}
				if (!IsAuto && !this.outParmsAccepted(PgmParms) && !isUserControl)
					return;
				var popup = new this.Popup([PgmName, 1, 0, 0, 0, 0, 0, [], PgmParms], true);
				popup.IsMod = IsMod;
				popup.Opener = gx.getObj(CmpCtx, InMasterPage);
				if (isUserControl) {
					popup.CustomRenderGrid = grid;
				}
				popup.open();
			}
		},

		outParmsAccepted: function (Parms) {
			var len = Parms.length;
			var anyOut = false;
			for (var i = 0; i < len; i++) {
				var parm = Parms[i];
				if (gx.fn.isOutputParm(parm))
					anyOut = true;
				if (gx.fn.isOutputParm(parm) && parm.Ctrl && gx.fn.isAccepted(parm.Ctrl))
					return true;
			}
			return !anyOut;
		},

		gxReturn: function (Parms) {
			gx.fn.closeWindow(Parms);
		},

		parmId: function (Ctrl) {
			var id = gx.dom.id(Ctrl);
			if (id.indexOf('span_') === 0) {
				id = id.substring(5);
			}
			return id;
		},

		popuplvl: function() {
			var popup = gx.popup.getPopup();
			if (!popup || !popup.window)
				return -1;
			return popup.window.gx.popup.lvl;
		},
		
		assignPromptFields: function (allParams, cParms) {
			var assignPromises = [];
			var gxO = gx.O,
				orderedParams = [],
				ctrlIdx = 99999,
				len = cParms.length,
				i = 0;
			for (i = 0; i < len; i++) {
				var Parms = allParams[i],
					PValue = cParms[i];
				if (!Parms.Ctrl || gx.lang.emptyObject(Parms))
					continue;
				gx.csv.pkDirty = (Parms.isKey);
				if (Parms.Ctrl.type == "checkbox" && Parms.Ctrl.value != PValue)
					Parms.Ctrl.checked = !Parms.Ctrl.checked;
				if (Parms.Ctrl.value != PValue && (Parms.isKey))
					gx.popup.gxOpener().GXPkIsDirty = true;
				var ControlId = gx.csv.ctxControlId(this.parmId(Parms.Ctrl));
				var validStruct = gxO.getValidStructFld(ControlId);

				orderedParams.push(
				{
					'idx': (validStruct)? validStruct.id: ctrlIdx++,
					'ParmCtrl': Parms.Ctrl,
					'ControlId': ControlId,
					'VStruct': validStruct,
					'PValue': PValue
				});				
			}
			var compareFnc = function(a,b) {
				if (a.idx < b.idx)
				return -1;
				if (a.idx > b.idx)
				return 1;
				return 0;
			};
			orderedParams.sort(compareFnc);
			
			for (i = 0; i < orderedParams.length; i++) {
				this.assignPromptFieldValue(orderedParams[i], gxO);
			}
			
			for (i = 0; i < orderedParams.length; i++) {
				assignPromises.push(this.assignAndValidatePromptField(orderedParams[i], gxO));
			}

			return $.when.apply($, assignPromises);
		},

		assignPromptFieldValue: function (obj) {
			var	validStruct = obj.VStruct,
				ParmCtrl = obj.ParmCtrl,
				PValue = obj.PValue;
			if (!gx.lang.emptyObject(validStruct) && !gx.lang.emptyObject(validStruct.v2c) && (validStruct.type == 'date' || validStruct.type == 'dtime')) {
				validStruct.v2v(PValue);
				gx.fn.v2c(validStruct, PValue);	
			}
			else {
				gx.fn.setControlValue(this.parmId(ParmCtrl), PValue, 0);
			}
			gx.fn.setControlGxValid(ParmCtrl, "0");
			gx.evt.execOnchange(ParmCtrl);
			var spanObj = gx.dom.byId('span_' + ParmCtrl.name);
			if (spanObj != null) {
				if (spanObj.childNodes.length === 0)
					spanObj.appendChild(gx.popup.gxOpener().document.createTextNode(""));
				var spanChild = spanObj.childNodes[0];
				spanChild.nodeValue = PValue;
			}
			if (validStruct && validStruct.gxgrid) {
				validStruct.gxgrid.updateControlValue(validStruct, false);
			}				
		},
				
		assignAndValidatePromptField: function (obj, gxO) {
			var deferred = $.Deferred();
			var returnResolved = true;
			var ControlId = obj.ControlId,
				validStruct = obj.VStruct;
			var toValid;

			var callback = (function () {
				gx.popup.assignPromptFieldValue(obj);
				gx.util.balloon.clear(ControlId);
				if (toValid) {
					//Validate ParmCtrl
					gx.O.toValid = toValid + 1;
					gx.csv.validateAll().done(function () {
						if (!gx.lang.emptyObject(validStruct.rgrid)) {
							var len = validStruct.rgrid.length;
							for (var i = 0; i < len; i++) {
								validStruct.rgrid[i].filterVarChanged();
							}
							deferred.resolve();
							return;
						}
					});
				}

				deferred.resolve();
			}).closure(this);

			if (!gx.lang.emptyObject(validStruct)) {
				toValid = gxO.getValidStructId(validStruct.fld);
				if (toValid) {
					//Validate previous controls
					if (toValid > gx.O.toValid) {
						gxO.toValid = toValid;
					}
					returnResolved = false;
					gx.csv.validateAll().done(callback);
				}
			}

			if (returnResolved) {
				deferred.resolve();
			}

			return deferred.promise();
		},

		autofit: function () {
			var popup = this.getPopup();
			if (!gx.lang.emptyObject(popup) && popup.state == 'opened') {
				this.ext.autofit(popup, null, false);
			}
		},

		Impl: function (popupObj, url, autoresize, width, height, position, top, left) {
			var borderClass = POPUP_CLASS,
				shadowClass = 'PopupShadow';			
			if (popupObj.cssClass){
				borderClass = borderClass.replace(POPUP_DEFAULT, "");
				borderClass += " " + popupObj.cssClass; 
			}
			return new this.ext.popUp(popupObj, autoresize, position, left, top, width, height, "gxp", url, "white", "#00385c", "16pt serif", "GxPopup", "#00385c", "white", "lightgrey", "#00568c", "black", true, false, true, true, true, true, false, 'min.gif', 'max.gif', 'close.gif', gx.ajax.getImageUrl(gx, 'resizeImage'), POPUP_HEADER_CLASS, POPUP_CLOSE_CLASS, POPUP_CONTENT_CLASS, borderClass, shadowClass, undefined);
		},

		setZIndex: function (ctrl) {
			var zIndex = gx.dom.getStyle(ctrl, 'zIndex');
			if (isNaN(zIndex))
				zIndex = 999;
			zIndex++;
			this.zindex = zIndex;
			this.ext.zdx = zIndex;
		},

		ext: {													
			currIDb: null,
			xoff: 0,
			yoff: 0,
			currRS: null,
			rsxoff: 0,
			rsyoff: 0,
			zdx: 1000,
			sdiff: 5,
			win: null,
			doc: null,

			compatMode: function () {
				return !gx.runtimeTemplates || (gx.util.browser.isIE() & gx.util.browser.ieVersion() <= 8);
			},

			hide: function (id) {
				var byId = gx.dom.byId;
				if (gx.popup.ext.compatMode()) {
					
					byId(id + '_t').style.visibility = "hidden";
					byId(id + '_c').style.visibility = "hidden";
					byId(id + '_rs').style.visibility = "hidden";
				}
				byId(id + '_b').style.visibility = "hidden";				
			},

			show: function (id) {
				var byId = gx.dom.byId,
					$b = $("#" + id + '_b');
				if (gx.popup.ext.compatMode()) {
					
					byId(id + '_t').style.visibility = "visible";
					byId(id + '_c').style.visibility = "visible";
					byId(id + '_rs').style.visibility = "visible";
				}
				else
				{
					$(document.body).toggleClass('gx-popup-opened', true);
				}				
				$b.css('visibility','visible');
			},

			close: function (popupObj, beforeClose) {
				$(document.body).toggleClass('gx-popup-opened', false);
				if (beforeClose && typeof (beforeClose) == 'function' && beforeClose() === false)
					return;
				if (popupObj.draggable) {
					popupObj.draggable.deinit();
				}
				if (popupObj.resizable) {
					popupObj.resizable.deinit();
				}
				gx.popup.ext.iFrame = null;
				gx.popup.ext.win = null;
				gx.popup.ext.doc = null;
				gx.popup.ext.currIDb = null;
				gx.popup.ext.currRS = null;
				var id = popupObj.id;
				var container = document.getElementById(id + '_b');
				var iFrame = document.getElementById(id + '_ifrm');			

				gx.popup.ext.deinitmodal(popupObj);
				gx.popup.setPopup(popupObj.parentPopup);
				var callerActiveElement = popupObj.callerActiveElement;
				if (callerActiveElement && callerActiveElement.focus) {
					callerActiveElement.focus();
				}
				if (popupObj.parentPopup) {
					popupObj.parentPopup.frameWindow.gx.fx.obs.notify("popup.close", [popupObj]);
				}
				else {
					gx.fx.obs.notify("popup.close", [popupObj]);
				}
				if (iFrame)
					iFrame.src = gx.util.getIFrameEmptySrc(); //avoid iframe reloading FFox
				if (gx.util.browser.isIE() && gx.util.browser.ieVersion() == 7) // IE7 bug
				{
					container.parentNode.removeChild(container);
				}
				else {
					gx.dom.removeControlSafe(container);
				}
			},

			move: function (ids, x, y) {
				var $wB = $("#" + ids + '_b');
				$wB.toggleClass(POPUP_CENTERED_CLASS, false);
				if (x !== undefined) {
					$wB.css( {left: Math.max(x, 0)}).toggleClass(POPUP__HORIZONTAL_CENTERED_CLASS, false);
				}
				else
					$wB.toggleClass(POPUP__HORIZONTAL_CENTERED_CLASS, true);	
				if (y !== undefined)
					$wB.css( {top: Math.max(y, 0)});
			},

			resize: function (ids, rx, ry) {	
				var byId = gx.dom.byId;
				if (byId(ids + '_rs').rsEnable) {
						var rsEl = byId(ids + "_rs");
						var bEl = byId(ids + "_b");
						var tEl = byId(ids + "_t");
						var cEl = byId(ids + "_c");

						if (gx.popup.ext.compatMode()) {
							rsEl.style.left = Math.max(rx, 92) + 'px';
							rsEl.style.top = Math.max(ry, 72) + 'px';
							bEl.style.width = Math.max(rx + 8, 100) + 'px';
							bEl.style.height = Math.max(ry + 8, 80) + 'px';
							tEl.style.width = Math.max(rx + 3, 92) + 'px';
							cEl.style.width = Math.max(rx - 5, 87) + 'px';
							cEl.style.height = Math.max(ry - 28, 44) + 'px';
						}
						else
						{
							var iFrame = document.getElementById(ids + '_ifrm');		
							$(iFrame).css({ width: rx, height: ry} );
						}
					this.resizePopupContent( rx, ry);
				}				
			},
			
			movepopup: function () {
				
				if ((this.currIDb != null)) {
					this.move(this.currIDb.cid, gx.evt.mouse.x + this.xoff, gx.evt.mouse.y + this.yoff);
				}
				if ((this.currRS != null)) {
					this.resize(this.currRS.cid, gx.evt.mouse.x + this.rsxoff, gx.evt.mouse.y + this.rsyoff);
				}

				return false;
			},

			stopRS: function () {
				gx.popup.ext.currRS = null;
			},

			startRS: function (evt, el) {
				var pExt = gx.popup.ext,
					ex = evt.pageX,
					ey = evt.pageY,
					$el = $(el);
				if (gx.popup.ext.compatMode()) {
					pExt.rsxoff = parseInt(el.style.left, 0) - ex;
					pExt.rsyoff = parseInt(el.style.top, 0) - ey;
				}
				else {
					pExt.rsxoff = $el.position().left - ex;
					pExt.rsyoff = $el.position().top - ey;
				}
				pExt.currRS = el;				
				return false;
			},

			changez: function (v) {
				var th = (v != null) ? v : this;
				var pExt = gx.popup.ext;
				var byId = gx.dom.byId;				
				th.style.zIndex = ++pExt.zdx;
				byId(th.cid + "_rs").style.zIndex = ++pExt.zdx;
			},

			stopdrag: function () {
				var pExt = gx.popup.ext;
				pExt.currIDb = null;				
			},

			grab_id: function (evt, el) {
				var pExt = gx.popup.ext,
					byId = gx.dom.byId,
					popup = byId(el.cid + "_b");
				gx.evt.mouse.update(evt);
				var ex = gx.evt.mouse.x;
				var ey = gx.evt.mouse.y;
				if (gx.popup.ext.compatMode()) {
					pExt.xoff = parseInt(popup.style.left, 0) - ex;
					pExt.yoff = parseInt(popup.style.top, 0) - ey;
				}
				else {
					pExt.xoff = $(popup).position().left - ex;
					pExt.yoff = $(popup).position().top - ey;
				}
				pExt.currIDb = popup;
				return false;
			},
	

			subBox: function (x, y, w, h, bgc, id) {
				var v = document.createElement('div');
				v.setAttribute('id', id);				
				v.style.position = 'absolute';
				v.style.left = x + 'px';
				v.style.top = y + 'px';
				v.style.width = w + 'px';
				v.style.height = h + 'px';
				v.style.visibility = 'visible';
				v.style.padding = '0px';
				v.style.width = w + 'px';
				return v;
			},

			window: function () {
				if (!gx.popup.ext.compatMode())
					this.window_responsive.apply(this, arguments);
				else
					this.window_compat.apply(this, arguments);

			},

			window_responsive: function (popupObj, autoSize, x, y, w, h, contentHtml, bgcolor, title, titlecolor, bordercolor, scrollcolor, shadowcolor, ismodal, showonstart, isdrag, isresize, isExt, rsImg, headCls, btnCls, cntCls, brdCls, shdwCls, showParentPopups, swallowKeys, callbacks, parentElement) {
				showParentPopups = (showParentPopups !== undefined) ? showParentPopups : gx.popup.showParentPopups;
				var cid = popupObj.id
				if (!this.win)
					this.win = window;
				if (!this.doc)
					this.doc = this.win.document;

				var byId = this.win.gx.dom.byId.closure(this.win.gx.dom);
				
				var outerdiv = $('<div/>', { 
											id: cid + '_b',
											style: (!showonstart)? 'visibility:hidden;': ''
								})[0];				
				$(outerdiv).addClass('gx-responsive-popup ' + POPUP_CENTERED_CLASS + " " + brdCls + " " + POPUP_INITIAL_SIZE_CLASS);

				var titlebar = $('<div/>', { id: cid + '_t'})[0];
				
				titlebar.className = headCls;
				titlebar.innerHTML = '<span id="' + cid + '_gxtitle" class="PopupTitle">' + title + '</span><span class="' + btnCls + '"; id="' + cid + '_cls"></span>';
				
				var content = $('<div/>', { id: cid + '_c'})[0];
				content.className = cntCls;				
				if (typeof (contentHtml) == 'string')
					content.innerHTML = contentHtml;
				else
					content.appendChild(contentHtml);
				outerdiv.appendChild(titlebar);
				outerdiv.appendChild(content);
				
				parentElement = gx.dom.byId(parentElement) || this.doc.body;
				parentElement.appendChild(outerdiv);
				if (!showonstart) {
					this.hide(cid);
				}
				var wB = byId(cid + '_b'),
					wCLS = byId(cid + '_cls');

				wB.cid = cid;
				wB.isExt = (isExt) ? true : false;
				var wT = byId(cid + '_t');
				wT.cid = cid;
				if (isresize) {
					popupObj.resizable = new gx.popup.ext.resizable(wB, cid, rsImg, outerdiv);
				}
				if (isdrag) {
					popupObj.draggable = new gx.popup.ext.draggable(wB, wT);
				}
				gx.evt.attach(wCLS, 'click', callbacks.close || this.close.closure(this, [popupObj, callbacks.beforeClose]));
				if (ismodal || showParentPopups) {
					this.initmodal(popupObj, showParentPopups, swallowKeys);
				}
			},
			
			resizable: function (container, cid, rsImg, outerdiv) {
				var initialized;
				var isMouseDown = false;
				var mouseX;
				var mouseY;
				var containerElement;
				var mouseUp;
				var mousemove;
				
				this.init = function(container, cid, rsImg, outerdiv) {
					var rdiv = $('<div/>', { id: cid + '_rs'})[0];
					rdiv.className += POPUP_RESIZE_CLASS;
					rdiv.innerHTML = '<img src="' + rsImg + '" width="7px" height="7px" alt="' + gx.getMessage("GXM_resize") + '">';
					rdiv.rsEnable = true;
					rdiv.style.cursor = 'se-resize';
					rdiv.cid = cid;
					outerdiv.appendChild(rdiv);
					containerElement = container;
					rdiv.firstChild.addEventListener('dragstart', function(e) {
						gx.evt.cancel(e, true);
					}, true);
					mouseUp = this.onMouseup.closure(this);
					mousemove = this.onMousemove.closure(this);
					rdiv.addEventListener('mousedown', this.onMousedown.closure(this));
					document.addEventListener('mouseup', mouseUp);
					document.addEventListener('mousemove', mousemove); 
					initialized = true;
				},

				this.deinit = function() {
					if (initialized) {
						document.removeEventListener('mouseup', mouseUp);
						document.removeEventListener('mousemove', mousemove);
						containerElement = null;
						initialized = null;
					}
				};

				this.onMousemove = function (event) {
					if (!isMouseDown) return;
					var iFrame = $(containerElement).find("iframe");
					$('iframe').css('pointer-events', 'none');
					var multiplier = ($(containerElement).hasClass(POPUP_CENTERED_CLASS))? 2: 1;
					var deltaX = event.clientX - mouseX;
					var deltaY = event.clientY - mouseY;
					var elWidth = $(iFrame).width() + (deltaX * multiplier);
					var elHeight = $(iFrame).height() + (deltaY * multiplier);
					$(iFrame).css({ width: elWidth, height: elHeight} );
					mouseX = event.clientX;
					mouseY = event.clientY;
				};

				this.onMousedown = function (event) {
					mouseX = event.clientX;
					mouseY = event.clientY;
					isMouseDown = true;
				};

				this.onMouseup = function() {
					if (!isMouseDown) return;
					$('iframe').css('pointer-events', '');
					isMouseDown = false;
				};

				this.init(container, cid, rsImg, outerdiv);
			},

			draggable: function (cElement, moveElement) {
				var initialized;
				var isMouseDown = false;
				var mouseX;
				var mouseY;
				var elementX = 0;
				var elementY = 0;
				var containerElement;
				var moveableElement;
				var mouseUp;
				var mousemove;
				var mouseDown;
				
				this.init = function(cElement, moveElement) {
					containerElement = cElement;
					moveableElement = moveElement;
					mouseDown = this.onMousedown.closure(this);
					mousemove = this.onMousemove.closure(this);
					mouseUp = this.onMouseup.closure(this);
					containerElement.addEventListener('mousedown', mouseDown);
					containerElement.addEventListener('mouseup', mouseUp);
					document.addEventListener('mousemove', mousemove);
					initialized = true;
				};

				this.deinit = function() {
					if (initialized) {
						containerElement.removeEventListener('mousedown', mouseDown);
						containerElement.removeEventListener('mouseup', mouseUp);
						document.removeEventListener('mousemove', mousemove);
						moveableElement = null;
						containerElement = null;
						initialized = null;
					}
				};

				this.onMousemove = function (event) {
					if (!isMouseDown) return;
					$('iframe').css('pointer-events', 'none');
					var deltaX = event.clientX - mouseX;
					var deltaY = event.clientY - mouseY;
					containerElement.style.left = elementX + deltaX + 'px';
					containerElement.style.top = elementY + deltaY + 'px';
				};

				this.onMousedown = function (event) {
					if (event.target === moveableElement) {
						var $elem = $(containerElement);
						elementX = $elem.position().left;
						elementY = $elem.position().top;
						$elem.css({ left: elementX, top: elementY }).toggleClass(POPUP_CENTERED_CLASS + " " + POPUP__HORIZONTAL_CENTERED_CLASS, false);
						mouseX = event.clientX;
						mouseY = event.clientY;
						isMouseDown = true;
					}
				};

				this.onMouseup = function() {
					if (!isMouseDown) return;
					$('iframe').css('pointer-events', '');
					isMouseDown = false;
					elementX = parseInt(containerElement.style.left, 10) || 0;
					elementY = parseInt(containerElement.style.top, 10) || 0;
				};

				this.init(cElement, moveElement);
			},

			window_compat: function (popupObj, autoSize, x, y, w, h, contentHtml, bgcolor, title, titlecolor, bordercolor, scrollcolor, shadowcolor, ismodal, showonstart, isdrag, isresize, isExt, rsImg, headCls, btnCls, cntCls, brdCls, shdwCls, showParentPopups, swallowKeys, callbacks, parentElement) {
				showParentPopups = (showParentPopups !== undefined) ? showParentPopups : gx.popup.showParentPopups;
				var cid = popupObj.id

				if (!this.win)
					this.win = window;
				if (!this.doc)
					this.doc = this.win.document;

				var byId = this.win.gx.dom.byId.closure(this.win.gx.dom);

				var initialWidth = 100;
				w = Math.max(w, initialWidth);
				h = Math.max(h, 80);
				var rdiv = new this.subBox(w - 8, h - 8, 7, 7, '', cid + '_rs');
				if (isresize) {
					rdiv.className += POPUP_RESIZE_CLASS;					
					rdiv.innerHTML = '<img src="' + rsImg + '" width="7px" height="7px" alt="' + gx.getMessage("GXM_resize") + '" style="box-sizing:content-box">';
					rdiv.style.cursor = 'se-resize';
				}
				rdiv.rsEnable = isresize;
				var tw = w + 4;
				var th = h + 6;
				var outerdiv = new this.subBox(x, y, w, h, bordercolor, cid + '_b');
				outerdiv.className = brdCls;
				outerdiv.style.display = "block";
				outerdiv.style.boxSizing = "content-box";	
				outerdiv.style.zIndex = ++this.zdx;
				if (!showonstart) {
					outerdiv.style.visibility = "hidden";
				}
				tw = w - 5;
				th = h - 4;
				var titlebar = new this.subBox(2, 2, tw, 20, titlecolor, cid + '_t');
				titlebar.style.overflow = "hidden";
				titlebar.style.boxSizing = "content-box";
				titlebar.className = headCls;
				titlebar.innerHTML = '<span id="' + cid + '_gxtitle" class="PopupTitle" style="box-sizing:border-box;white-space:nowrap;position:absolute;padding:2px;">' + title + '</span><span class="' + btnCls + '" style="z-index:' + (++this.zdx) + ';" id="' + cid + '_cls"></span>';				
				tw = w - 13;
				var content = new this.subBox(2, 24, tw, h - 36, bgcolor, cid + '_c');
				content.className = cntCls;
				if (typeof (contentHtml) == 'string')
					content.innerHTML = contentHtml;
				else
					content.appendChild(contentHtml);

				content.style.overflow = "hidden";
				content.style.boxSizing = "content-box";				
				if (!showonstart) {
					outerdiv.style.visibility = "hidden";
					titlebar.style.visibility = "hidden";
					content.style.visibility = "hidden";					
				}
				outerdiv.appendChild(titlebar);
				outerdiv.appendChild(content);
				outerdiv.appendChild(rdiv);
				parentElement = gx.dom.byId(parentElement) || this.doc.body;
				parentElement.appendChild(outerdiv);
				if (!showonstart) {
					this.hide(cid);
				}
				var wB = byId(cid + '_b');
				wB.cid = cid;
				wB.isExt = (isExt) ? true : false;
				var wT = byId(cid + '_t');
				wT.cid = cid;
				if (isresize) {
					var wRS = byId(cid + '_rs');
					wRS.cid = cid;
					wRS.style.boxSizing = "content-box";
					gx.evt.attach(wRS, 'mousedown', this.startRS.closure(this, [wRS], true));
					gx.evt.attach(wRS, 'mouseup', this.stopRS.closure(this, [wRS], true));
				}
				var wCLS = byId(cid + '_cls');				
				gx.evt.attach(wCLS, 'click', callbacks.close || this.close.closure(this, [popupObj, callbacks.beforeClose]));
				if (isdrag) {
					gx.evt.attach(wT, 'mousedown', function (evt) {
						this.grab_id(evt, wT);						
						gx.evt.attach(wB, 'mouseup', this.stopdrag.closure(this, [wT], true), this, { single: true});
					}, this);
					if (isresize) {
						gx.evt.attach(rdiv.firstChild, 'dragstart', function(e) {
							gx.evt.cancel(e, true);
						}, true);
					}
				}
				if (ismodal || showParentPopups) {					
					this.initmodal(popupObj, showParentPopups, swallowKeys);
				}
			},

			popUp: function (popupObj, autoSize, popCentered, x, y, w, h, cid, text, bgcolor, textcolor, fontstyleset, title, titlecolor, titletextcolor, bordercolor, scrollcolor, shadowcolor, ismodal, showonstart, isdrag, isresize, oldOK, isExt, popOnce, minImg, maxImg, clsImg, rsImg, headCls, btnCls, cntCls, brdCls, shdwCls, showParentPopups) {
				var pExt = gx.popup.ext;
				var win;
				if (popupObj.parentPopup != null) {
					win = popupObj.parentPopup.window;
					pExt = win.gx.popup.ext;
					pExt.win = win;
					pExt.doc = win.document;
					gx.popup.ext = pExt;
				}
				else {
					pExt.win = window;
					pExt.doc = pExt.win.document;
				}

				pExt.win.gx.popup.setPopup(popupObj);

				popupObj.window = pExt.win;
				popupObj.document = pExt.doc;

				pExt.win.gx.popup.lvl++;

				cid = cid + pExt.win.gx.popup.lvl;
				popupObj.id = cid;

				if (!popupObj.IsPrompt && !gx.util.sameAppUrl(text)) {
					ismodal = false;
					gx.popup.setPopup(null);
					var ctr = new Date();
					ctr = ctr.getTime();
					var t = (isExt) ? text : '';
					var posn = '';
					if (popCentered == 1) {
						posn = 'left=' + x + ',top=' + y;
					}
					var pdims = '';
					if (!autoSize) { //autoSize ==0
						pdims = ",width=" + w + ",height=" + h;
					}
					win = window.open(t, "gx" + ctr, "status=no,menubar=no" + pdims + ",resizable=" + ((isresize) ? "yes" : "no") + ",scrollbars=yes," + posn);
				}
				else {
					text += gx.http.urlParameterPrefix(text);
					text += encodeURIComponent('gxPopupLevel=' + pExt.win.gx.popup.lvl + ';');
					var	contentHtml = '',
						iframeTitle = gx.util.getFileName(text);

					iframeTitle = iframeTitle.charAt(0).toUpperCase() + iframeTitle.slice(1);
					if (gx.popup.ext.compatMode()) {
						var sizeValue = (gx.HTML5)? 'auto': '100%';
						contentHtml = '<iframe id="' + cid + '_ifrm" src="' + text + '" width="' + sizeValue + '" height="' + sizeValue + '" frameborder="0" style="overflow:auto;" title="' + iframeTitle + '" ' + POPUP_IFRAME_CONTAINER_ATTR + '=""></iframe>';
					}
					else {
						var minWidth = (!autoSize && w > 0)? w: gx.dom.fixes.getPopupMinWidth();
						var iFrameNode = $('<iframe/>', { 
							id: cid + '_ifrm', 
							src: text,
							title: iframeTitle,
							style: 'width:' + gx.dom.addUnits(minWidth)
						});
						iFrameNode.attr(POPUP_IFRAME_CONTAINER_ATTR, "");
						contentHtml = iFrameNode[0].outerHTML;						
						if (gx.util.browser.isIPad()) { //Hack for iOS Safari bug where IFRAME cannot get max-height because scroll would not work.
							contentHtml = '<div class="iframe-container">' + contentHtml + '</div>';
						}
					}
					var callbacks = {
						close: popupObj.close.closure(popupObj, [null, { ignoreCmds: gx.config.popup.ignoreCmdsOnCancel }])
					};
					pExt.window(popupObj, autoSize, x, y, w, h, contentHtml, bgcolor, title, titlecolor, bordercolor, scrollcolor, shadowcolor, ismodal, showonstart, isdrag, isresize, isExt, rsImg, headCls, btnCls, cntCls, brdCls, shdwCls, showParentPopups, true, callbacks);
					var iFrame = pExt.win.gx.dom.byId(cid + '_ifrm');
					pExt.iFrame = iFrame;
					gx.lang.doCallTimeout(pExt.showIfLoaded, pExt, [popupObj, iFrame, 1], 50);
				}
			},

			initmodal: function (popupObj, showParentPopups, swallowKeys) {
				popupObj.showParentPopups = showParentPopups;
				if (popupObj.parentPopup == null) {
					gx.ajax.disableForm(swallowKeys, true);
				}
				else {
					if (!showParentPopups)
						this.hide(popupObj.parentPopup.id);
				}
			},

			deinitmodal: function (popupObj) {
				if (popupObj.parentPopup == null) {
					gx.ajax.enableForm();
				}
				else {
					this.show(popupObj.parentPopup.id);
					var frame = popupObj.parentPopup.frameWindow;
					if (frame && frame.gx) {
						popupObj.parentPopup.frameWindow.gx.ajax.enableForm();
					}
				}
			},

			getDocumentContentType: function(doc) {
				return doc.contentType || $(doc.querySelector('meta[http-equiv="content-type"]')).attr('content');
			},
			
			isPDFPopup: function (iFrame, popupObj) {
				if (popupObj.isPdf === undefined) {				
					//Hack for IE and FF PDF Plugin. Document cannot be accessed when PDF inside iframe.
					var src = iFrame.src;
					if (gx.util.getContentTypeFromExt(src) == gx.util.contentTypes.pdf) {
						popupObj.isPdf = true;
						return true;
					}

					var cType = gx.util.contentTypes.html;
					try {
						var doc = iFrame.contentDocument;
						doc = iFrame.contentWindow.document;
						cType = this.getDocumentContentType(doc);
						if (cType == gx.util.contentTypes.pdf) {
							popupObj.isPdf = true;
							return true;
						}
					}
					catch (e) {
						cType = null;
					}
					
					if (gx.lang.emptyObject(cType)) {
						var lastResponseHeader;
						var headInfo = {};
						headInfo.url = src;
						headInfo.method = 'HEAD';
						headInfo.sync = true;
						headInfo.ajaxHeader = false;
						headInfo.handler = function (type, data, req) { lastResponseHeader = req.getResponseHeader('Content-Type'); };
						headInfo.obj = true;
						gx.http.doCall(headInfo);
						if (lastResponseHeader && lastResponseHeader.indexOf(gx.util.contentTypes.pdf) >= 0) {
							popupObj.isPdf = true;
							return true;
						}
					}
					return false;
				}
				else {
					return popupObj.isPdf;
				}
				
			},

			showIfLoaded: function (popupObj, iFrame, times) {
				try {
					if (popupObj.isActive()) {
						if (this.docReady(iFrame, times) || (times > MAX_CHECK_LOADED_TIMES_PDF && this.isPDFPopup(iFrame, popupObj))) {
							var frameDoc = gx.dom.iFrameDoc(iFrame),
								frameDocLoaded = false;
							try {
								frameDocLoaded = (frameDoc && frameDoc.URL != 'about:blank');
							}
							catch (e) {
							}
							var isPdf = this.isPDFPopup(iFrame, popupObj);
							if (frameDocLoaded || isPdf) {
								popupObj.state = 'opened';
								this.autofit(popupObj, frameDoc, true);
								return;
							}
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxpopup.js', 'showIfLoaded');
				}
				times++;
				gx.lang.doCallTimeout(gx.popup.ext.showIfLoaded, gx.popup.ext, [popupObj, iFrame, times], times * 50);
			},

			docReady: function (iFrame, times) {
				if (iFrame.readyState == 'complete')
					return true;
				var frameDoc = gx.dom.iFrameDoc(iFrame);
				if (frameDoc) {
					var readyState;
					try {
						readyState = (typeof (frameDoc.gxReadyState) != 'undefined') ? frameDoc.gxReadyState : frameDoc.readyState;
					}
					catch(e) {
						return true;
					}
					if (readyState == 'complete')
						return true;
				}
				if (!gx.util.browser.isIE() && times >= 50 && frameDoc && frameDoc.body && frameDoc.body.childNodes.length !== 0) {
					return true;
				}
				return false;
			},

			resizePopupContent: function (width, height) {
				if (!gx.HTML5 || !this.iFrame)
					return;
				var frameDoc = gx.dom.iFrameDoc(this.iFrame),
					docHeight = (height > 0)? height: '100%',
					docWidth = (width > 0)? width: '100%',
					$iFrame = $(this.iFrame),
					fixedSize = width > 0 && height > 0,
					compatMode = gx.popup.ext.compatMode(),					
					isResponsive;

				if (frameDoc) {
					var mainEl = frameDoc.documentElement;
					if (mainEl) {
						if(compatMode) {
							docWidth = docHeight = "100%";
						}
						else
						{				
							try {
								isResponsive = $iFrame[0].contentWindow.gx && $iFrame[0].contentWindow.gx.runtimeTemplates;
							}
							catch (e) {}
							
							if (!fixedSize) {
								if (!isResponsive) {
									$iFrame.width(50);
								}
								$(mainEl).width(mainEl.offsetWidth);
							}
							else {
								$(mainEl).width(width);								
								$(mainEl).height(height);								
								$(mainEl).css("min-width", '');	
								$iFrame.width(docWidth);
								$iFrame.height(docHeight);																
							}
							docWidth = Math.max(
								Math.max(frameDoc.body.scrollWidth, frameDoc.documentElement.scrollWidth),
								Math.max(frameDoc.body.offsetWidth, frameDoc.documentElement.offsetWidth)								
							);
							
							//We add scrollbar width to popup width in order not to display horizontal scrollbar. 
							try {
								docWidth += ($(window).height() <= frameDoc.body.offsetHeight)? $.position.scrollbarWidth(): 0;							
							} catch(e) {}
							
							docHeight = undefined;
						}																		
					}
				}				
				$iFrame.width(docWidth);
				if (docHeight === undefined) {
					docHeight = Math.max(
						Math.max(frameDoc.body.scrollHeight, frameDoc.documentElement.scrollHeight),
						Math.max(frameDoc.body.offsetHeight, frameDoc.documentElement.offsetHeight)								
					);					
				}
				$iFrame.height(docHeight);				
			},
			
			autofit: function () {
				if (!gx.popup.ext.compatMode())
					this.autofit_responsive.apply(this, arguments);
				else
					this.autofit_comp.apply(this, arguments);
			}, 

			autofit_responsive: function (popupObj, frameDoc, doShow) {
				if (gx.lang.emptyObject(popupObj))
					return;

				var pDoc = document,
					id = popupObj.id,
					isPDFPopup = popupObj.isPdf,
					$cEl = $('#' + id + '_c');					
				
				if (!this.doc)
					this.doc = popupObj.document;
				pDoc = this.doc;
				var iFrame = pDoc.getElementById(id + '_ifrm'),
					$titleEl = $(pDoc.getElementById(id + '_gxtitle'));

				if (!frameDoc && gx.popup.ispopup()) {
					frameDoc = gx.dom.iFrameDoc(iFrame);
				}
				
				this.iFrame = this.iFrame || iFrame;
				
				$titleEl.text(frameDoc && !isPDFPopup ? frameDoc.title : '');
			
				popupObj.frameDocument = frameDoc;
				popupObj.frameWindow = iFrame.contentWindow;
				if (frameDoc && !isPDFPopup)
					frameDoc.gxPopup = popupObj;

				if (gx.util.browser.isIPad()) {				
					$cEl.css("overflow-y", "auto");
					$cEl.css("-webkit-overflow-scrolling", "touch");
				}
				
				var insideiFrame = window.self !== window.top,
					vMaxHeight,					
					scrollTop,
					scrollLeft;

				if (insideiFrame) {
					var docInfo = this.getiFrameSizeInfo(pDoc);
					if (docInfo.accessParentFrame) {						
						scrollTop = docInfo.scrollTop;
						vMaxHeight = docInfo.maxHeight + Math.min(window.top.document.body.scrollTop - docInfo.y, 0) - 50;  //50 = Estimated PopupHeader Height
						$cEl.css('max-height', vMaxHeight).parent().css('margin-top', '0px');
						var minY = Math.max(window.top.document.body.scrollTop - docInfo.y, 0);
						var realheight = Math.min(frameDoc.body.offsetHeight, vMaxHeight);						
						this.move(id, scrollLeft, minY + scrollTop + ((vMaxHeight - realheight) / 2));						
					}
				}

				var width, height;
				if (isPDFPopup) {
					$cEl.addClass('gx-popup-pdf');
					width = pDoc.body.clientWidth * 0.5;
					height = pDoc.body.clientHeight * 0.85;
				}				
				if (!popupObj.autoresize) {	
					width = popupObj.width;
					height = popupObj.height;						
				}		
								
				this.resizePopupContent(width, height);
				if (doShow) {										
					if (popupObj.position) {						
						var top = parseInt(popupObj.top, 0);
						var left = parseInt(popupObj.left, 0);
						this.move(id, left, top);
					}
					this.show(id);					
				}
			},


			autofit_comp: function (popupObj, frameDoc, doShow) {
				if (gx.lang.emptyObject(popupObj))
					return;

				var pDoc = document;
				if (pDoc.gxPopup != null)
					popupObj.zindex = this.zdx + pDoc.gxPopup.zindex;
				else
					popupObj.zindex = this.zdx;

				var id = popupObj.id;
				var isPDFPopup = popupObj.isPdf;
				
				if (!this.doc)
					this.doc = popupObj.document;
				pDoc = this.doc;
				var iFrame = pDoc.getElementById(id + '_ifrm');
				if (!frameDoc && gx.popup.ispopup()) {
					frameDoc = gx.dom.iFrameDoc(iFrame);
				}
				popupObj.frameDocument = frameDoc;
				popupObj.frameWindow = iFrame.contentWindow;
				if (frameDoc && !isPDFPopup)
					frameDoc.gxPopup = popupObj;

				var rsEl = pDoc.getElementById(id + '_rs');
				var tEl = pDoc.getElementById(id + '_t');
				var bEl = pDoc.getElementById(id + '_b');
				var cEl = pDoc.getElementById(id + '_c');
				var titleEl = pDoc.getElementById(id + '_gxtitle');

				titleEl.innerHTML = frameDoc && !isPDFPopup ? frameDoc.title : '';
				titleEl.style.width = 'auto';

				var cElComputedStyle = gx.dom.getComputedStyle(cEl);
				var tElComputedStyle = gx.dom.getComputedStyle(tEl);
				var bElComputedStyle = gx.dom.getComputedStyle(bEl);
				var rsElComputedStyle = gx.dom.getComputedStyle(rsEl);
				

				var cH = parseInt(cElComputedStyle.height, 0),
					cW = parseInt(cElComputedStyle.width, 0),
					docInfo = this.getiFrameSizeInfo(pDoc),
					vWidth = docInfo.maxWidth,
					vHeight = docInfo.maxHeight,
					scrollTop = docInfo.scrollTop,
					scrollLeft = docInfo.scrollLeft,
					framePositionX = docInfo.x,
					framePositionY = docInfo.y,
					dims = gx.dom.dimensions(bEl);

				if (!popupObj.autoresize) { //autoresize==0
					cH = popupObj.height - cH + dims.h;
					cW = popupObj.width - cW + dims.w;
				}

				var diffW = popupObj.width - cW;
				var diffH = popupObj.height - cH;

				if (popupObj.autoresize) { //autresize != 0
					if (!isPDFPopup && frameDoc) {
						var mainEl = (gx.HTML5) ? frameDoc.documentElement || frameDoc.body : frameDoc.body;
						var scrollWidth, 
							scrollbarwidth = (doShow && gx.util.browser.isEdge())? $.position.scrollbarWidth(): 0;
						if (mainEl) {
							if (!mainEl.gxwidth) {
								mainEl.gxwidth = mainEl.scrollWidth;
							}
							scrollWidth = mainEl.gxwidth + scrollbarwidth;
							var dW = mainEl.gxwidth  + 30 - vWidth;
							var dH = mainEl.scrollHeight + 30 - vHeight;
							var wOffset = 0;

							diffW = Math.max(scrollWidth, titleEl.clientWidth + 15) - cW - ((dW > 0) ? dW : 0) + wOffset;
							diffH = mainEl.scrollHeight - cH - ((dH > 0) ? dH : 0);
						}
						else if (gx.util.browser.isIE()) {
							if (diffW < 0) diffW = 0;
							if (diffH < 0) diffH = 0;
						}
					}
					else {
						if (isPDFPopup) {
							//Default value when autoresize is enabled and could not get iframe document body height and width. Example: PDF + IE + Popup.
							diffW = pDoc.body.clientWidth / 2;
							diffH = pDoc.body.clientHeight / 2;
						}
					}
				}

				var top = parseInt(popupObj.top, 0);
				var left = parseInt(popupObj.left, 0);

				if (!popupObj.position) { //position  == 0
					top = (vHeight - diffH) / 2 - (dims.h / 2) + scrollTop - framePositionY;
					left = (vWidth - diffW) / 2 - (dims.w / 2) + scrollLeft - framePositionX;

					if (top < 0) {
						top = 5;
						diffH = diffH - 5;
					}
					if (left < 0) {
						left = 5;
						diffW = diffW - 5;
					}
				}
				

				bEl.style.top = parseInt(top, 0) + "px";
				bEl.style.left = parseInt(left, 0) + "px";

				if (!popupObj.autoresize) {//autoresize == 0
					cH = popupObj.height;
					cW = popupObj.width;				

					rsEl.style.left = Math.max(cW, 92) + 'px';
					rsEl.style.top = Math.max(cH, 72) + 'px';
					bEl.style.width = Math.max(cW + 8, 100) + 'px';
					bEl.style.height = Math.max(cH + 8, 80) + 'px';				

					tEl.style.width = Math.max(cW + 3, 92) + 'px';
					cEl.style.width = Math.max(cW - 5, 87) + 'px';
					cEl.style.height = Math.max(cH - 28, 44) + 'px';
				}
				else {
					var resolveValue = function (a, b) {
						var value = parseInt(a, 0) + b;
						return value > 0 ? value : a;
					};
					tEl.style.width = resolveValue(tElComputedStyle.width, diffW) + "px";

					bEl.style.height = resolveValue(bElComputedStyle.height, diffH) + "px";
					bEl.style.width = resolveValue(bElComputedStyle.width, diffW) + "px";

					cEl.style.height = resolveValue(cElComputedStyle.height, diffH) + "px";
					cEl.style.width = resolveValue(cElComputedStyle.width, diffW) + "px";				
					var offset = gx.util.browser.isIE() ? 4 : 2;
					rsEl.style.top = (parseInt(bElComputedStyle.height, 0) - parseInt(rsElComputedStyle.height, 0) - offset) + "px";
					rsEl.style.left = (parseInt(bElComputedStyle.width, 0) - parseInt(rsElComputedStyle.width, 0) - offset) + "px";
				}

				if (gx.util.browser.isIPad() || gx.util.browser.isIPhone()) {				
					cEl.style["overflow-y"] = "auto";
					cEl.style["-webkit-overflow-scrolling"] = "touch";
				}
				else
					cEl.style.overflow = "hidden";

				if (isPDFPopup && gx.util.browser.isIE()){
					this.resizePopupContent( "100%", "100%");
				}
				else
				{
					this.resizePopupContent( parseInt(cEl.offsetWidth, 10), parseInt(cEl.offsetHeight, 10));
				}
				if (doShow) {
					this.show(id);
				}
			},

			getiFrameSizeInfo: function(pDoc) {
				var windowInfo = gx.util.getWindowInfo(),
					accessFrame = windowInfo.canAccessFrame,
					info = { x: 0, y: 0, accessParentFrame:accessFrame };
				
				
				if (!accessFrame || window == window.top || gx.lang.emptyObject(window.top)) {
					info.maxWidth = window.innerWidth || pDoc.documentElement.clientWidth || pDoc.body.offsetWidth;
					info.maxHeight = window.innerHeight || pDoc.documentElement.clientHeight || pDoc.body.offsetHeight;					
					info.scrollTop = gx.dom.documentScroll(pDoc).scrollTop;
					info.scrollLeft = gx.dom.documentScroll(pDoc).scrollLeft;
				}
				else {
					var framePosition = gx.dom.position(window.frameElement);					
					if (window.top.document.body.clientHeight > pDoc.body.clientHeight) {
						info.maxHeight = pDoc.body.clientHeight;
					}
					else {
						info.maxHeight = window.top.document.body.clientHeight;
						info.y = framePosition.y;
					}
					info.scrollTop = pDoc.body.scrollTop;
					info.scrollLeft = pDoc.body.scrollLeft;
					
					info.maxWidth = Math.min(window.top.document.body.clientWidth, pDoc.body.clientWidth);
					if (window.top.document.body.clientWidth > pDoc.body.clientWidth) {
						info.maxWidth = pDoc.body.clientWidth;
					}
					else {
						info.maxWidth = window.top.document.body.clientWidth;
						info.x = framePosition.x;
					}
				}
				return info;
			},

			_init: function () {
			}
		},

		_init: function () {
			gx.lang.inherits(this.Popup, this.Dialog)
			this.ext._init();
			var popup = this.getPopup();
			if (popup) {
				try {
					if (popup.frameDocument) {
						if (gx.util.browser.isIE()) {
							popup.frameDocument = popup.frameWindow.document;
						}
						else {
							popup.frameDocument.gxPopup = popup;
						}
					}
				}
				catch (e) {
					popup.frameDocument = popup.frameWindow.document;
					gx.dbg.logEx(e, 'gxpopup.js', '_init');
				}
				var popupExt = popup.window.gx.popup;
				gx.fx.obs.addObserver('gx.onload', popupExt, function () { this.autofit(); }.closure(popupExt));
				gx.fx.obs.addObserver('grid.onafterrefresh', popupExt, function (gridObj, rows1, rows2) {
					if (rows1 < rows2) {
						this.autofit();
					}
				}.closure(popupExt));
				gx.fx.obs.addObserver('gx.onafterevent', popupExt, function () { this.autofit(); }.closure(popupExt));
			}
		}
	}
})(gx.$);
/* END OF FILE - ..\js\gxpopup.js - */
/* START OF FILE - ..\js\gxcallrpc.js - */
gx.ajax = (function ($) {
	var VAR_QUERYSTRING_REGEX = /\?(.*)/;
	var GX_FULL_AJAX_REQUEST_HEADER = "X-FULL-AJAX-REQUEST";

	var logExternalObjectUnexpectedMsg = function (type, msg, name) {
		gx.dbg.logMsg("Unable to execute external object " + type + " - " + msg + "(" + name + ")");
	};

	function setGridRow(grid, row, gxO) {
		if (grid > 0) {
			gxO = gxO || gx.O;
			gx.fn.setCurrentGridRow(grid, row);
			var gridObj = gxO.getGridById(grid);
			if (gridObj) {
				gridObj.instanciateRow(row);
			}
		}
	}

	return {
		reqHeader: 'GxAjaxRequest',
		resourceProvider: '',
		dfTimer: null,
		resolveParmKey: function (parm) {
			var key = false;
			if (parm.av) {
				key = parm.av;
			}
			else if (parm.ctrl && parm.prop) {
				key = parm.ctrl + parm.prop;
			}
			else if (parm.ctrl) {
				key = parm.ctrl;
			}
			return key;
		},
		
		serviceUrl: function (ParmString) {
			var url = gx.ajax.selfUrl();
			if (ParmString)
			{					
				if (VAR_QUERYSTRING_REGEX.test(url))
					url = url.replace(VAR_QUERYSTRING_REGEX, '?' + ParmString + gx.http.urlParameterSeparator(url) + '$1');
				else
					url += '?' + ParmString;
			}
			return url;
		},

		validationMessage: function (method, gxO, grid, row, serverSide, disableForm) {
			var message = new gx.ajax.message(method, gxO, grid, row, serverSide, disableForm);

			return gx.lang.apply(message, {
				isValidation: true,
				beforeCall: gx.emptyFn,
				beforeAjaxCall: function (postInfo) {
					postInfo.warnOnTimeout = true;
					postInfo.beforeSend = function (req) {
						req.setRequestHeader(GX_FULL_AJAX_REQUEST_HEADER, "1");
					}
				},
				beforeProcesResponse: function (processResponseOpt) {
					var i,
						validationInput = [],
						validationInputMetadata = this.getParmsMetadata("input");

					for (i=0; i<validationInputMetadata.length; i++) {
						if (validationInputMetadata[i].av) {
							validationInput.push(validationInputMetadata[i].av);
						}
					}

					processResponseOpt.isValidation = true;
					processResponseOpt.validationInput = validationInput;
				}
			});
		},

		message: function (method, gxO, grid, row, serverSide, disableForm) {
			var deferred;

			return {
				disableForm: disableForm,
				gxO: gxO,
				grid: grid,
				row: row,
				methods: [method],
				isValidation: false,

				addMethod: function (method) {
					this.methods.push(method)
				},

				gridsData: function () {
					var grid = this.gxO.getGridById( this.grid, this.row);
					var grids = {};
					var setGriData = function( cgrid, grids) {
						var parentRow = (cgrid.parentRow)? cgrid.parentRow.gxId: "";
						grids[cgrid.gridName] = {
								id: cgrid.gridId,
								lastRow: Math.max( 0, Number(cgrid.lastRowId)),
								pRow: parentRow
						};
					}
					if (grid) {
						var setChildGrids = function(grid, grids, gxO, row) {
							var isDescendantGrid = function(parentGrid, childGrid) {
								if (!parentGrid) {
									return null;
								}
								if (childGrid.parentGrid === parentGrid && gx.text.startsWith(childGrid.parentRow.gxId, row)) {
									return childGrid;
								}
								return isDescendantGrid( parentGrid.parentGrid, childGrid);									
							}
							var isDescendant = function( childGrid) {
								return isDescendantGrid( grid, childGrid);
							}
							var childGrids = $.map( gx.O.Grids, isDescendant);
							$.each(childGrids, function(i, cgrid) {
								setGriData( cgrid, grids);
							});
						}
						var setGridsWithParents = function(grid, grids) {
							if (grid) {
								setGriData( grid, grids);
								var curRow = gx.fn.currentGridRowImpl( grid.gridId);
								if (curRow)	{
									grids[grid.gridName].lastRow = Math.max( 0, Number(curRow) - 1);
								}
								setGridsWithParents(grid.parentGrid, grids);
							}
						}
						setChildGrids(grid, grids, this.gxO, this.row);
						setGridsWithParents( grid, grids);
					}
					else {
						$.each(this.gxO.Grids, function(i, cgrid) {
							setGriData( cgrid, grids);
						});
					}
					return grids;
				},

				to_json: function () {
					var o = {
						MPage: this.gxO.IsMasterPage, 
						cmpCtx: this.gxO.CmpContext, 
						parms: this.parms,
						hsh: this.hashedParms,
						objClass: this.gxO.ServerClass,
						pkgName: this.gxO.PackageName || "", 
						events: this.methods
					};
					if (this.fullPost)
						o.fullPost = this.fullPost;
					this.addGXStateParms(o);
					if (this.grid) {
						o.grid = this.grid;
					}
					o.grids = this.gridsData();
					if (this.row) {
						o.row = this.row.substring(0, 4);
						o.pRow = this.row.substring(4);
					}
					return gx.json.serializeJson(o);
				},

				getParmsMetadata: function (type) {
					var parms = [],
						parmsHash = {};
					for (var j = 0, len = this.methods.length; j < len; j++) {
						var method = this.methods[j];
						if (!this.gxO.EvtParms[method])
							continue;
						var methodParms = this.gxO.EvtParms[method][type == "input" ? 0 : 1];
						for (var i = 0; i < methodParms.length; i++) {
							if (methodParms[i].postForm || methodParms[i].sPrefix || methodParms[i].sSFPrefix || methodParms[i].sCompEvt)
								parms.push(methodParms[i]);
							else  {
								var key = gx.ajax.resolveParmKey(methodParms[i]);
								if (key) {
									if (parmsHash[key] === undefined) {
										parmsHash[key] = parms.length;
										parms.push(methodParms[i]);
									}
									else {
										if (parms[parmsHash[key]].grid === undefined && methodParms[i].grid !== undefined) {
											parms[parmsHash[key]] = methodParms[i];
										}
									}
								}
							}
						}
					}
					return parms;
				},

				parmFromHidden: function(vStruct, gxO) 
				{
					var gxOld = gx.O;
					var value;
					gx.setGxO(gxO);
					if (!gx.lang.emptyObject(vStruct) && !gx.lang.emptyObject(gxO) && vStruct.v2v) {
						var fld = this.gxO.IsMasterPage ? vStruct.fld + '_MPAGE' : gx.O.CmpContext + vStruct.fld;
						var hvalue = gx.fn.getHidden( fld);
						vStruct.v2v(hvalue);
						value = gxO[vStruct.gxvar];
					}
					gx.setGxO(gxOld);
					return value;
				},

				getInputParms: function () {
					var parmsMetadata = this.getParmsMetadata("input"),
						CmpContext = this.gxO.CmpContext,
						inputParms = [],
						hashedParms = [],
						parm,
						value,
						vStruct,
						ctrl,
						gRow,
						ctrlJSON;
					for (var i = 0, len = parmsMetadata.length; i < len; i++) {
						vStruct = undefined;
						value = undefined;
						ctrlJSON = "";
						parm = parmsMetadata[i];
						if (parm.postForm)	{
							var postInfo = {};
							postInfo.formNode = this.gxO.getContainer() || gx.dom.form();
							this.fullPost = gx.http.getPostData( postInfo, gx.http.postDataFormat.JSON);
							for (var h in gx.http.viewState) {
								if (!this.fullPost[h] && gx.http.viewState[h] !== undefined) {
									this.fullPost[h] = gx.http.viewState[h];
								}
							}
						}
						else if (this.gxO.isTransaction() && this.grid > 0 && this.row && parm.av === 'Gx_mode' && parm.fld === 'vMODE')
						{
							inputParms.push(gx.fn.getGridRowModeImpl(gx.fn.gridLvl(this.grid), this.grid, this.row));
						}
						else if (parm.prop == 'Referrer') {
							inputParms.push(gx.referrer ? gx.referrer : document.referrer);
						}
						else if (parm.sPrefix) {
							inputParms.push(this.gxO.sPrefix());
						}
						else if (parm.sSFPrefix) {
							inputParms.push('');
						}
						else if (parm.sCompEvt) {
							inputParms.push(gx.fn.getHidden("_EventName").replace(this.gxO.sPrefix(),''));
						}
						else if (parm.ctrl) {
							if (parm.prop) {
								if (parm.prop == 'GridRC') {
									var parentRow = gx.parentGridRow(parm.grid, this.gxO);
									var rowSuffix = parentRow ? ('_'+parentRow):'';
									value = {gridRC: gx.fn.getHidden( this.gxO.sPrefix() + parm.av +rowSuffix), rowSuffix:rowSuffix};
								}
								else {
									value = this.gxO.getCtrlPropertyValue(this.gxO.sPrefix() + parm.ctrl, parm.prop);
								}
							} 
							else {
									vStruct = this.gxO.getValidStructFld(parm.ctrl);
									if (vStruct) {
										ctrl = gx.fn.getControlGridRef(vStruct.fld, vStruct.grid);
										if (gx.html.controls.isMultiSelection(vStruct.ctrltype)) {
											ctrlJSON = gx.dom.comboBoxToObj(ctrl, value);
										}
										else {
											if (vStruct.ctrltype === "radio") {
												ctrlJSON = gx.dom.radioToObj(ctrl, value);
											}
										}

										if (ctrlJSON) {
											value = ctrlJSON;
										}
									}
								}
							inputParms.push((value !== undefined)? value: null);
						}
						else {
							vStruct = this.getParmVarVStruct(parm);

							if (vStruct && typeof (vStruct.c2v) == 'function' && typeof (vStruct.val) == 'function') {
								var vRow = (vStruct.grid === this.grid)? this.row: gx.fn.currentGridRowImpl(vStruct.grid);
								if (vStruct.val(vRow) !== undefined) {
									vStruct.c2v(vRow);
								}
							}

							if (vStruct && vStruct.isuc === true) {
								gRow = this.row || ((vStruct && vStruct.grid) ? gx.fn.currentGridRowImpl(vStruct.grid) : undefined);
								var uc = vStruct.getUCInstance(gRow) || vStruct.uc; 
								uc.execC2VFunctions();
							}
							if (typeof (this.gxO[parm.av]) == 'function') {
								value = this.gxO[parm.av](this.row);
							}
							else if (this.gxO[parm.av] === undefined) {
								value = (parm.fld) ? gx.fn.getControlValue(parm.fld) : '';
							}
							else {
								value = this.gxO[parm.av];
							}

							var vStructOld = gx.fn.vStructForOld(parm.av);
							if (vStructOld && (vStructOld.type == "date" || vStructOld.type == "dtime")) {
								if (typeof (value) === "string") {
									value = new gx.date.gxdate(value);
								}
							}

							// For compatibility reasons, for validation messages, dates without date part
							// are serialized as "0001/01/01..." instead of the default serialization (1899/01/01...)
							if (this.isValidation) {
								if (value instanceof gx.date.gxdate && !value.HasDatePart) {
									var newValue = new gx.date.gxdate("");
									newValue.assign_date(value);
									newValue.JsonNullFormat = gx.date.jsonNullFormat.YearOne;
									value = newValue;
								}
							}

							if (parm.grid !== undefined) {
								var colVal = value;
								var gridColData = [];
								$.each( this.gxO.Grids, function( i, cGrid) {
									if (cGrid.gridId === parm.grid) {
										var parentRow = (cGrid.parentRow)? cGrid.parentRow.gxId: "";
										if (vStruct) {
											value = {
												pRow: parentRow,
												c: [],
												hc: [],
												hsh: [],
												v: colVal
											};                      
											for (var j = 1; j <= cGrid.lastRowId; j++) {
												gRow = gx.grid.getPaddedRowId(j);
												var val = (vStruct.isuc)? gx.fn.getControlValue(vStruct.fld + "_" + gRow + parentRow): vStruct.val(gRow + parentRow);																																	
												value.c.push(val);
												if (parm.hsh)
													value.hsh.push(gx.fn.getHash(CmpContext, vStruct.fld, gRow + parentRow));
												if (!gx.lang.emptyObject(vStruct.hc)) {
													value.hc.push(gx.fn.getControlValue("GXHC" + vStruct.fld + "_" + gRow + parentRow));
												}
											}
										}
										else
										{ 
											if (gx.lang.isArray(value)) { //Collection based grid
												value = {       
													pRow: parentRow,               
													c: value,
													v: value[Number(gx.fn.currentGridRowImpl(parm.grid)) - 1]
												};
											}
										}
										gridColData.push(value);
									}
								});
								value = gridColData;            
							}
							else {
								if (parm.hsh) {
									if (vStruct && vStruct.grid) {
										gRow = gx.fn.currentGridRowImpl(vStruct.grid) || '';
										if (gRow === '') {
											value = this.parmFromHidden(vStruct, this.gxO);
										}
									}
									else {
										gRow = '';
									}	
									hashedParms.push({hsh:gx.fn.getHash(this.gxO.CmpContext, parm.fld, gRow), row: gRow});
								}
							}
							inputParms.push((value !== undefined)? value: null);
						}
					}
					return {input:inputParms, hashed: hashedParms};
				},

				refreshOutputParms: function () {
					var parmsMetadata = this.getParmsMetadata("output"),
						parm,
						vStruct,
						gRow;
					for (var i = 0, len = parmsMetadata.length; i < len; i++) {
						vStruct = undefined;
						parm = parmsMetadata[i];

						vStruct = this.getParmVarVStruct(parm);

						if (vStruct && vStruct.grid && typeof (vStruct.c2v) == 'function' && typeof (vStruct.val) == 'function') {
							gRow = gx.fn.currentGridRowImpl(vStruct.grid);
							if (vStruct.val(gRow) !== undefined) {
								vStruct.v2c(gRow);
							}
						}
					}
				},

				getParmVarVStruct: function (parm) {
					var gridObject, gridColumn;

					if (parm.fld !== undefined) {
						return parm.fld ? this.gxO.getValidStructFld(parm.fld) : null;
					}
					else {
						if (this.grid && this.row) {
							gridObject = this.gxO.getGridById(this.grid);
							if (gridObject) {
								gridColumn = gridObject.grid.getColumnForVar(parm.av);
								if (gridColumn) {
									return this.gxO.getValidStruct(gridColumn.gxId);
								}
							}
						}
					}
				},

				addGXStateParms: function (obj) {
					var gxstate = {};

					if (gx.notifications && gx.notifications.webSocket.initialized && gx.fn.getHidden("GX_WEBSOCKET_ID"))
					{
						gxstate.GX_WEBSOCKET_ID = gx.fn.getHidden("GX_WEBSOCKET_ID");
					}

					if (!gx.lang.emptyObj(gxstate)) {
						obj.gxstate = gxstate;
					}
				},

				beforeCall: function () {
					if (serverSide) {
						gx.fn.objectOnpost();
					}
				},

				call: function () {
					deferred = $.Deferred();
					var gxOld = gx.O;
					gx.setGxO(this.gxO);
					var oldRow;
					if (this.grid && this.row) {
						oldRow = gx.fn.currentGridRowImpl(this.grid);
						gx.fn.setCurrentGridRow(this.grid, this.row);
					}
					this.beforeCall();
					var parms = this.getInputParms(); //It must be always executed.
					if (serverSide) {
						this.parms = parms.input;
						this.hashedParms = parms.hashed;
						this.doAjaxCall(false, this.disableForm);
					}
					else {
						this.doClientSideCall();
						this.refreshOutputParms();
					}
					if (this.grid && this.row) {
						gx.fn.setCurrentGridRow(this.grid, oldRow);
					}
					gx.setGxO(gxOld);
					return deferred.promise();
				},

				doAjaxCall: function (Synch, disableForm) {
					var ParmString = this.to_json();
					gx.evt.setProcessing(true);
					if (disableForm !== false) {
						this.startFeedback();
					}
					gx.fx.obs.notify('gx.onbeforeevent', [ParmString, Synch]);
					var postInfo = gx.ajax.getPostInfo(this.gxO, ParmString, Synch);
					postInfo.handler = this.ajaxCallHandler.closure(this);
					postInfo.error = this.ajaxCallError.closure(this);
					postInfo.handleAllStatusCodes = true;
					postInfo.url = gx.ajax.serviceUrl((gx.http.useNamedParameters(gx.ajax.selfUrl()) ? 'gxevent=' : '') + gx.ajax.encryptParms(this.gxO, 'gxfullajaxEvt'));
					postInfo.reqData = ParmString;
					postInfo.always = this.callback;
					postInfo.contentType = 'application/json';
					this.beforeAjaxCall(postInfo);
					gx.http.doCall(postInfo);
				},

				beforeAjaxCall: gx.emptyFn,

				doClientSideCall: function () {
					var result = this.callback();
					deferred.resolve(result);
				},

				ajaxCallError:function() {
					deferred.resolve(false);
					gxO.endFeedback();
				},
				afterAjaxCallHandler: function (callFailed, DataObj) {
					gx.evt.setProcessing(false);
					deferred.resolve(!callFailed);
					if (callFailed) {
						gx.fx.obs.notify('gx.onafterevent', [DataObj]);
					}
				},

				ajaxCallHandler: function (type, data, event) {
					gx.evt.enter = false;
					gx.csv.lastEvtResponse = null;
					gx.http.lastStatus = event.status;
					var callFailed = false,
						DataObj;
					if (event.status == gx.http.STATUS_FORBIDDEN) {
						gx.util.alert.showError(gx.getMessage("GXM_runtimeappsrv") + ' (' + event.status + ')');
						callFailed = true;
					}
					else {
						if (gx.http.checkResponseStatus(event, this.isValidation)) {
							callFailed = true;
							//Handled by checkResponse
						}
						else if (event.status < 200 || event.status > 299) {
							gx.dom.writeError( event.responseText, gx.getMessage("GXM_runtimeappsrv"), event.status);
							callFailed = true;
						}
						else {
							if (gx.http.validJsonResponse( event, data)) {
								DataObj = gx.json.evalJSON(data);
								if (DataObj == null)
									gx.dom.writeError( data.toString(), gx.getMessage("GXM_runtimeappsrv"), event.status);
								else {
									gx.csv.lastEvtResponse = DataObj;

									var processResponseOpt = {
										response: DataObj, 
										isPostBack: true, 
										gxObject: this.gxO, 
										gridId: this.grid, 
										row: this.row
									};

									this.beforeProcesResponse(processResponseOpt);

									gx.ajax.setJsonResponse(processResponseOpt).done(function () {
										gx.fx.obs.notify('gx.onafterevent', [DataObj]);
									});
								}
							}
							else {
								callFailed = true;
							}
						}
					}
					this.afterAjaxCallHandler(callFailed, DataObj);
				},

				beforeProcesResponse: gx.emptyFn,

				startFeedback: function () {
					this.gxO.startFeedback(false, this.isValidation);
				}
			};
		},

		maxGETLength: function (gxObj) {
			// Max GET length varies according to Ajax security level. Parameters after encrypting are much longer than without encryption.
			// The returned value must be compared to unencrypted parameters.
			return (gxObj.AjaxSecurity) ? 600 : 1350;
		},

		getImageUrl: function (_this, imageVar) {
			var imageId = _this[imageVar];
			if (gx.lang.emptyObject(imageId))
				return "";
			if (typeof (imageId) == 'object')
				_this[imageVar] = gx.ajax.resolveImageUrl(imageId);
			return gx.util.resourceUrl(gx.basePath + gx.staticDirectory + _this[imageVar], true);
		},

		imageGuidToUrl: function (imgId) {
			try {
				if (!gx.lang.emptyObject(this.resourceProvider)) {
					var sUrl = gx.ajax.objectUrl(this.resourceProvider) + '?image,' + encodeURIComponent(imgId) + ',,' + encodeURIComponent(gx.theme);
					gx.http.callBackend_simple(sUrl, true, true, 'GET', null, true);
					return gx.http.lastResponse;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxcallrpc.js', 'getImageUrl');
			}
			return imgId;
		},

		resolveImageUrl: function (imgMetadata) {
			var i, imgObj;
			for (i=0; i<imgMetadata.length; i++) {
				imgObj = imgMetadata[i];
				if (imgObj.l == gx.languageCode && imgObj.t == gx.theme) {
					return (imgObj.i ? "Resources/" : "") + imgObj.p;
				}
			}
		},

		sendHeader: function (Headers) {
			try {
				if (!gx.lang.emptyObject(this.resourceProvider)) {
					var sUrl = location.href;
					gx.http.callBackend_simple( sUrl, true, true, 'HEAD', null, true, true, Headers);
					return true;
				}
			}
			catch (e) { }
			return false;
		},

		encryptParms: function (gxObj, parms) {
			return (gxObj.AjaxSecurity) ? gx.sec.encrypt(parms) : parms;
		},

		doPost: function (ParmString, Synch, disableForm, callback) {
			if (disableForm !== false) {
				gx.O.startFeedback();
			}
			gx.fx.obs.notify('gx.onbeforeevent', [ParmString, Synch]);
			gx.fn.objectOnpost();
			gx.http.saveState();
			gx.fn.forceEnableControls(false);
			var postInfo = this.getPostInfo(gx.O, ParmString, Synch);	
			postInfo.url = gx.ajax.serviceUrl(ParmString);		
			postInfo.onReady = function () { 
				gx.evt.setProcessing(false); 
				if (disableForm !== false && !gx.popup.getPopup()) {
					gx.O.endFeedback();
				}
			};
			postInfo.always = callback;
			gx.http.doCall(postInfo);
		},

		getPostInfo: function (gxO, ParmString, Synch) {
			var postInfo = {};			
			postInfo.formNode = gx.dom.form();
			postInfo.method = 'POST';
			postInfo.encoding = 'UTF-8';
			postInfo.useCash = false;
			postInfo.gxO = gxO;			
			if (Synch === true)
				postInfo.sync = true;
			postInfo.handler = gx.http.postHandler;
			this.multipartInfo(postInfo);
			return postInfo;
		},	
		
		multipartInfo: function (postInfo) {
			var hasFile = gx.dom.hasSelectedFile();
			if (hasFile) {
				postInfo.multipart = true;
				postInfo.mimetype = "text/html";
				postInfo.formNode.encoding = "multipart/form-data";
			}
		},
	

		dispatchRefreshCommand: function (command, gxO) {
			var isFormRefresh = (command.refresh_form !== undefined),
				refreshMethod = command.refresh || command.refresh_form,
				rfrName,
				gxOEvent,
				isNoGridEvent;

			if (refreshMethod == 'GET') {
				gx.http.reload(true);
			}
			else {
				rfrName = 'RFR';
				if (gxO.IsMasterPage)
					rfrName = rfrName + '_MPAGE';
				gxOEvent = (isFormRefresh || !gx.pO.fullAjax) ? gx.pO: gxO;
				isNoGridEvent = gxOEvent.fullAjax; //Refresh Command never fires a Grid Event.
				return gxOEvent.executeServerEvent(rfrName, !gx.pO.fullAjax, null, true, isNoGridEvent);
			}
			return $.Deferred().resolve();
		},

		doRefresh: function (gxO) {
			var rfrName = (gxO.IsMasterPage)?'RFR_MPAGE': 'RFR';			
			gxO = (!gx.pO.fullAjax) ? gx.pO: gxO;				
			gxO.executeServerEvent(rfrName, true, null, true, gxO.fullAjax);			
		},
		
		dispatchCommands: function (Commands, gxO, opts, commandIndexStart) {
			opts = opts || {};
			var redirect,
				tempGxO,
				oldgxO,
				ignoreCmds = opts.ignoreCmds || [],
				methodsExecuted;

			commandIndexStart = commandIndexStart === undefined ? 0 : commandIndexStart;
			gxO = gxO || gx.O;

			if (Commands && Commands.length > 0) {
				var len = Commands.length;
				for (var i = commandIndexStart; i < len; i++) {
					var Command = Commands[i];
					var cmdName = (Object.keys)? Object.keys(Command)[0]: "";
					if (gx.util.inArray(cmdName, ignoreCmds))
						continue;
					if (Command.set_focus) {
						gx.fn.usrSetFocus(Command.set_focus);
					}
					if (Command.print) {
						gx.printing.print(Command.print);
					}
					if (Command.close) {
						var returnParms = [];
						if (Command.close.values instanceof Array) {
							returnParms = Command.close.values;
						}
						gx.fn.closeWindow(returnParms, {
							parmsMetadata: Command.close.metadata,
							updateParms: opts.updateParms
						}, gxO);
					}
					if (Command.refresh !== undefined || Command.refresh_form !== undefined || Command.cmp_refresh === '') {
						gx.ajax.dispatchRefreshCommand(Command, gxO).then(function () {
							gx.ajax.dispatchCommands(Commands, gxO, opts, i + 1);
						});
						return;
					}
					if (Command.redirect) {
						redirect = Command.redirect;
						redirect.url = gx.ajax.removeGXParms(redirect.url);
						gx.http.redirect(redirect.url, redirect.forceDisableFrm === 1, redirect.forceDisableFrm === 2, gxO);
					}
					if (Command.calltarget) {
						gx.nav.callFromServerRedirect(Command.calltarget.url, Command.calltarget.target);
					}
					if (Command.callback) {
						Command.callback.apply(Command.callback.scope, Command.args || []);
					}
					if (Command.cmp_refresh) {
						var cmp = gx.pO.getWebComponent(Command.cmp_refresh);
						gx.evt.dispatcher.dispatch('REFRESH', cmp);
					}
					if (Command.popup) {
						gxO.endFeedback();
						if (Commands.length > i + 1) {
							if (gx.lang.isArray(Command.popup)) {
								Command.popup[7] = Commands.slice(i + 1);
							}
							else {
								Command.popup.OncloseCmds = Commands.slice(i + 1);
							}
						}
						gx.popup.open(Command.popup, gxO);
						break;
					}
					if (Command.ucmethod) {
						tempGxO = gx.getObj(Command.ucmethod.CmpContext, Command.ucmethod.IsMasterPage);
						if (tempGxO) {
							oldgxO = gx.O;
							gx.setGxO(tempGxO);
							var uc = gx.O.getUserControl(Command.ucmethod.Control);
							if (uc) {
								if (typeof (uc[Command.ucmethod.Method]) == 'function') {
									try {
										uc[Command.ucmethod.Method].apply(uc, Command.ucmethod.Parms);
										methodsExecuted = true;
									}
									catch (e){
										gx.dbg.logEx(e, 'gxcallrpc.js', 'Failed to execute usercontrol method: ' + Command.ucmethod.Method);
									}
								}
							}
							gx.setGxO(oldgxO);
						}
					}
					if (Command.exomethod) {
						gx.ajax.dispatchExoMethod(Command.exomethod);
						methodsExecuted = true;
					}
					if (Command.exoprop) {
						gx.ajax.dispatchExoProperty(Command.exoprop);
					}
				}
				if (methodsExecuted) {
					gxO.showMessages(true);
				}
			}
			gx.fn.usrSetFocus_commit();
		},
		
		resolveExoObject: function (gxO, objectName) {
			var exoObject = gxO[objectName],
				objectNameParts,
				baseObject,
				i,
				len;
			if (!exoObject) {
				objectNameParts = objectName.split('.');
				baseObject = window;
				for (i=0, len=objectNameParts.length; i<len; i++) {
					baseObject = baseObject[objectNameParts[i]];
					if (baseObject === undefined)
						return;
				}
				exoObject = baseObject;
			}

			return exoObject;
		},
		
		dispatchExoMethod: function (exoCommand) {
			var tempGxO = gx.getObj(exoCommand.CmpContext, exoCommand.IsMasterPage),
				oldgxO,
				exoObject,
				exoMethod;

			if (tempGxO) {
				oldgxO = gx.O;
				gx.setGxO(tempGxO);
				try {
					exoObject = this.resolveExoObject(tempGxO, exoCommand.ObjectName);
					if (exoObject && exoCommand.ObjectName === "GlobalEvents") {
						exoObject.executeMethod(exoCommand.Method, exoCommand.Parms);
					}
					else {
						if (exoCommand.IsEvent) {
							gx.fx.obs.notify(exoCommand.Method, exoCommand.Parms);
						}
						else {						
							if (exoObject) {
								exoMethod = exoObject[exoCommand.Method];
								if (exoMethod) {
									exoMethod.apply(exoObject, exoCommand.Parms);
								}							
								else {
									logExternalObjectUnexpectedMsg("method", "Method not found", exoCommand.Method);
								}
							}
							else {
								logExternalObjectUnexpectedMsg("method", "Object not found", exoCommand.ObjectName);
							}
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxcallrpc.js', 'dispatchCommands');
				}
				finally {
					gx.setGxO(oldgxO);
				}
			}
		},

		dispatchExoProperty: function (exoCommand) {
			var tempGxO = gx.getObj(exoCommand.CmpContext, exoCommand.IsMasterPage),
				oldgxO,
				exoObject;

			if (tempGxO) {
				oldgxO = gx.O;
				gx.setGxO(tempGxO);
				try {
					exoObject = this.resolveExoObject(tempGxO, exoCommand.ObjectName);
					if (exoObject) {
						exoObject[exoCommand.PropertyName] = exoCommand.Value;
					}
					else {
						logExternalObjectUnexpectedMsg("property", "Object not found", exoCommand.ObjectName);
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxcallrpc.js', 'dispatchCommands');
				}
				finally {
					gx.setGxO(oldgxO);
				}
			}
		},

		ROW_ID_REGEXP: /[0-9]{4}$/,
		
		dispatchPreCommands: function (Commands, gxO, gxComponents, gxHiddens, gxValues, gxGrids, gxProps, row) {
			gxO = gxO || gx.O;
			if (Commands && Commands.length > 0) {
				var len = Commands.length;
				var grid;
				for (var i = 0; i < len; i++) {
					var Command = Commands[i];
					if (Command.load) {
						grid = gxO.getGridById(Command.load.grid, row)
						if (grid) {
							Command.load.props.values = Command.load.values;
							grid.loadNewRows(Command.load.props);
						}
					}
					else if (Command.addlines) {
						gx.lang.doCall(gx.fn.setJsonValues, gxValues);
						gx.lang.doCall(gx.fn.setJsonProperties, gxProps, row);
						grid = gxO.getGridById(Command.addlines.grid, row)
						if (grid)
							grid.getNewRows(Command.addlines.count);
					}
				}
			}
		},

		willLeavePage: function (Commands) {
			if (Commands) {
				var len = Commands.length;
				for (var i = 0; i < len; i++) {
					var Command = Commands[i];
					if (Command.close)
						return true;
				}
			}
			return false;
		},

		getRedirectCommand: function (Commands) {
			if (Commands) {
				var len = Commands.length;
				for (var i = 0; i < len; i++) {
					var Command = Commands[i];
					if (Command.popup) {
						return null;
					}
					if (Command.redirect) {
						return Command;
					}
				}
			}
			return null;
		},

		saveJsonResponse: function (response) {
			this.lastJsonResponse = response;
		},

		clearJsonResponse: function () {
			delete this.lastJsonResponse;
		},

		getJsonResponse: function () {
			if (this.lastJsonResponse)
				delete this.lastJsonResponse.gxCommands; //Already processed during PageLoad
			return this.lastJsonResponse;
		},

		setPostResponse: function (response, gxO, ctx) {
			return this.setJsonResponse(
			{
				response: response, 
				isPostBack: true, 
				gxObject: gxO || gx.O, 
				context:ctx 
			});
		},
		
		setJsonResponse: function (opts) {
			var deferred = $.Deferred(),
				response = opts.response,
				isPostback = opts.isPostBack,
				afterCmpLoaded = opts.afterCmpLoaded,
				gxO = opts.gxObject,
				gridId = opts.gridId,
				row = opts.row,
				context = opts.context || {},
				isValidation = !!opts.isValidation;
				
			var fn = gx.fn,
				doFunc = gx.lang.doCall,
				oldGxO,
				oldRow,
				willLeavePage = this.willLeavePage(response.gxCommands),
				shouldUpdatePropertyFn = this.getShouldUpdatePropertyFunction(response);

			if (gxO) {
				oldGxO = gx.O;
				gx.O = gxO;
			}
			var endFeedbackFnc = function(gxO, isPostback) {
				if (isPostback || !gx.popup.currentPopup) {
					gxO.endFeedback();
				}
			};
			
			if (gridId && row) {
				oldRow = gx.fn.currentGridRow(gridId);
				gx.fn.setCurrentGridRow(gridId, row);
			}
			if (gx.evt.srvCommand) {
				gx.evt.srvCommand = false;
				doFunc(gx.ajax.dispatchCommands, response.gxCommands, gxO);
				deferred.resolve(willLeavePage);
			}
			else { 
				var redirectCommand = this.getRedirectCommand(response.gxCommands);
				if (redirectCommand && redirectCommand.redirect.forceDisableFrm === 1) {
					doFunc(gx.ajax.dispatchCommands, response.gxCommands, gxO, { ignoreCmds: ['refresh', 'cmp_refresh'] });
					deferred.resolve(willLeavePage);
				}
				else if (willLeavePage) {
					doFunc(gx.ajax.dispatchCommands, response.gxCommands, gxO);
					deferred.resolve(willLeavePage);
				}
				else {
					doFunc(gx.ajax.dispatchPreCommands, response.gxCommands, gxO, response.gxComponents, response.gxHiddens, response.gxValues, response.gxGrids, response.gxProps, row);
					doFunc(fn.clearCompontHiddens, response.gxComponents);
					var hiddensUCs = doFunc(fn.setJsonHiddens, gxO, response.gxHiddens);
					doFunc(fn.setJsonComponents, response.gxComponents, response.DynComponentMap, response.gxHiddens, function (newComponents) {
						gx.http.loadStyles();
						gx.updateTheme();
						if (isPostback) {
							gx.fn.installComponents(false);
						}
						if (typeof (afterCmpLoaded) == 'function') {
							afterCmpLoaded();
						}
						if (oldGxO) {
							gx.O = oldGxO;
						}
						var valuesUCs = doFunc(fn.setJsonValues, response.gxValues, isValidation, gridId, row, shouldUpdatePropertyFn);
						var propUCs = doFunc(fn.setJsonProperties, response.gxProps, row);
						var gridUCs = [];
						var newCompUCs = $.map(newComponents, function (comp) {
							var cmpCtx = fn.cmpContextFromCtrl(comp),
								gxWcObj = gx.pO.WebComponents[cmpCtx];
							if (gxWcObj) {
								return gx.lang.objToArray(gxWcObj.UserControls).concat(gxWcObj.getUserControlGrids());
							}
						});
						if (!isValidation && (gxO.isTransaction() || !gxO.fullAjax)) {
							gx.util.balloon.clearAll();
						}
						fn.enableDisableDelete();
						if (isPostback) {
							gridUCs = doFunc(fn.loadJsonGrids, response.gxGrids, isPostback);
						}

						if (isValidation) {
							gx.ajax.transformValidationMessages(opts, gxO, response.gxMessages);
						}

						doFunc(fn.setErrorViewer, response.gxMessages);
						if (isPostback) {
							var userControls;
							if (gx.pO.supportAjaxEvents) {
								userControls = gx.lang.arrayUnique(propUCs.concat(valuesUCs, newCompUCs, gridUCs, hiddensUCs));
							}
							fn.objectPostback(userControls, newComponents);
							if (!isValidation) {
								fn.setFocusAfterLoad(true);
							}
							gx.dom.indexElements();
						}

						if (!context.autoRefreshing) {
							endFeedbackFnc(gxO, isPostback);
						}

						doFunc(gx.ajax.dispatchCommands, response.gxCommands, gxO);
						if (oldRow) {
							gx.fn.setCurrentGridRowSafe(gridId, oldRow);
						}
						deferred.resolve(willLeavePage);
					}, isPostback);
				}
			}
			return deferred;
		},

		getShouldUpdatePropertyFunction: function (response) {
			var i, j, k;
			var grid;
			var propertiesToIgnore = {};
			
			if (response.gxGrids) {
				for (i=0; i<response.gxGrids.length; i++) {
					grid = response.gxGrids[i];
					for (j=0; j<grid.Count; j++) {
						for (k=0; k<grid[j].Props.length; k++) {
							propertiesToIgnore[grid[j].Props[k][0]] = true;
						}
					}
				}
			}

			return function shouldUpdateProperty(property) {
				return !propertiesToIgnore[property];
			}
		},

		transformValidationMessages: function (opts, gxO, messages) {
			var ctx = gxO.cmpCtx || "MAIN";
			if (typeof(messages[ctx]) != 'undefined') {
				messages[ctx] = {
					fields: opts.validationInput,
					msgs: messages[ctx]
				};
			}
		},

		disableForm: function (swallowKeys, immediately) {
			swallowKeys = (swallowKeys === undefined) || swallowKeys;
			gx.pO.startFeedback(immediately, swallowKeys);
		},

		enableForm: function (gxO) {
			gxO = gxO || gx.O;
			if (gx.pO)
				gx.pO.endFeedback();
			if (gxO != gx.pO)
				gxO.endFeedback();
		},

		isFormEnabled: function () {
			if (gx.pO)
				return !gx.pO.isFeedbackOn() && !gx.O.isFeedbackOn();
			return true;
		},
		
		saveFormForAutoComplete:function(){
			if (!gx.ajax.formAutocomplete || gx.grid.drawAtServer || (gx.util.browser.isIE() && (gx.util.browser.isCompatMode() || document.documentMode <= 7 || gx.util.browser.ieVersion() <= 7) ))
				return;
			
			var GX_IFRAME_FFORM_AUTOC = 'gx_iframe_force_ajax_autocomplete';
			var form = gx.dom.form();
			
			var tmpIframe = document.createElement('iframe');
			tmpIframe.id = GX_IFRAME_FFORM_AUTOC;
			tmpIframe.name = GX_IFRAME_FFORM_AUTOC;		
			tmpIframe.style.cssText = 'display: none';
			tmpIframe.src="/content/blank";
			document.body.appendChild(tmpIframe);

			var tmpSubmitBtn = document.createElement('input');
			tmpSubmitBtn.type = 'submit';
			tmpSubmitBtn.style.cssText = 'display: none';
			form.appendChild(tmpSubmitBtn);

			var oldTarget = form.target;
			var oldAction = form.action;
			form.target = tmpIframe.name;
			form.action = tmpIframe.src;
			var jQBtn = $(tmpSubmitBtn);
			var stopPropagation = function (event) { 
				event.stopPropagation(); 
				return true;  
			};
			gx.evt.attach(tmpSubmitBtn, 'click', stopPropagation);			
			jQBtn.trigger('click');

			setTimeout(function () {
				form.target = oldTarget;
				form.action = oldAction;
				form.removeChild(tmpSubmitBtn);
				document.body.removeChild(tmpIframe);
			});
		},

		suggest: function (gxO, ControlId, ControlRefresh, CtrlSvc, bTypeAhead, suggParms, sdtParms) {
			var CtrlId = ControlRefresh;
			var SuggestProvider = new gx.fx.suggestProvider(gxO, ControlId, ControlRefresh, CtrlSvc);
			return new gx.fx.autoSuggestControl(gx.fn.screen_CtrlRef(ControlRefresh), SuggestProvider, CtrlId, bTypeAhead, suggParms, sdtParms);
		},

		hideCode: function (InputParms, ControlId, ControlRefresh) {
			var backcall = function( VarValues) { gx.fn.setVarValues(ControlRefresh, VarValues)};
			var sURL = this.objectUrl() + '?';
			var sParms = 'gxajaxHideCode_' + ControlId;
			var len = InputParms.length;
			for (var i = 0; i < len; i++)
				sParms += ',' + encodeURIComponent(eval(InputParms[i]));
			sURL += gx.ajax.encryptParms(gx.O, sParms);
			gx.http.callBackend_impl( backcall, sURL, true, gx.http.modes.retval);
			return this.lastStatus;
		},

		callCrl: function (ActionParameters, ControlRefresh, RefreshGrid) {
			var funcCall = RefreshGrid ? gx.fn.setGridComboValues : gx.fn.setComboValues;
			var ctrlName = RefreshGrid ? ControlRefresh : gx.fn.screen_CtrlRef(ControlRefresh).name;
			var backcall = function( VarValues) { funcCall(ctrlName, VarValues)};			
			var sURL = this.objectUrl() + '?';
			var sParms = 'gxajaxCallCrl_' + ControlRefresh + ",";
			sParms += this.arrayToUrl(ActionParameters);
			sURL += gx.ajax.encryptParms(gx.O, sParms);
			gx.http.callBackend_impl( backcall, sURL, true, gx.http.modes.retval);
		},

		refreshGrid: function (GxGrid, refreshParms) {
			var gxOld = gx.O;
			gx.setGxO(GxGrid.parentObject);

			var method = 'GET',
				sURL = gx.ajax.gxObjectUrl(GxGrid.parentObject) + '?',
				allParms = 'gxajaxGridRefresh_' + GxGrid.gridName + ',' + refreshParms,
				postData;

			gx.fx.obs.notify('grid.onbeforerefresh', [GxGrid]);
			// Check parameters length. If too long, send a POST with parameters as form variables.
			GxGrid.autoRefreshing = true;
			gx.csv.autoRefreshing = GxGrid;
			var rowsLen1 = GxGrid.grid.rows.length;
			GxGrid.setPagingVars(0, 0);
			if (allParms.length > gx.ajax.maxGETLength(gx.O)) {
				method = 'POST';

				postData = ["GXEvent=" + gx.ajax.encryptParms(gx.O, "gxajaxGridRefresh_" + GxGrid.gridName)];
				var parmsList = refreshParms.split(',');
				for (var i = 0, len = parmsList.length; i < len; i++)
					postData.push("GXParm" + i + "=" + parmsList[i]);
			}
			else {
				sURL += gx.ajax.encryptParms(gx.O, allParms);
			}
			GxGrid.grid.mask();
			gx.http.doCall({
				method: method,
				url: sURL,
				reqData: postData,
				handler: function (type, responseText, event) {					
					gx.http.postHandler(type, responseText, event, {autoRefreshing: true});
					var rowsLen2 = GxGrid.grid.rows.length;
					gx.fx.obs.notify('grid.onafterrefresh', [GxGrid, rowsLen1, rowsLen2]);
				},
				always: function () {
					gx.csv.autoRefreshing = null;
					GxGrid.autoRefreshing = false;
					GxGrid.grid.unmask();
					gx.setGxO(gxOld);
				}
			});
		},

		newRows: function (CmpCtx, InMasterPage, GridName, gxRows, gxRowIndex, gxRowId, gxParentRow, gHandler) {
			var sURL = this.objectUrl() + '?',
				parameters = [],
				gxO = gx.O,
				gridObj = gx.fn.gridObj(CmpCtx, (gxParentRow) ? (GridName + '_' + gxParentRow) : GridName, InMasterPage),
				postData = null, 
				method = "GET",
				strBody = null,
				evtName = 'gxajaxNewRow_' + GridName;
			
			parameters.push(evtName);
			parameters.push(gxRows);
			parameters.push(gxRowIndex);
			parameters.push(gxRowId);
									
			if (gxO.IsComponent || gxO.IsTypeComponent) {
				parameters.push(gxO.CmpContext);			
			}
			parameters = parameters.concat(gridObj.getParmsValues(false, gridObj.postingVariables));
			
			strBody = parameters.join(',');			
			if (strBody.length > gx.ajax.maxGETLength(gxO)) {
				method = 'POST';
				postData = ["GXEvent=" + gx.ajax.encryptParms(gxO, evtName)];				
				for (var i = 1, len = parameters.length; i < len; i++) {
					postData.push("GXParm" + (i - 1) + "=" + parameters[i]);
				}
				strBody = postData.join('&');
			} 
			else {
				sURL += gx.ajax.encryptParms(gxO, strBody);
				strBody = null;
			}
						
			gx.http.callBackend_simple(sURL, true, null, method, strBody);
			var response = gx.http.lastResponse;
			if (response) {
				var newRowsInfo = gx.json.evalJSON(response);
				gHandler.call(gridObj, newRowsInfo);
				gx.dom.indexElements();
				gx.fx.obs.notify('gx.onafterevent', [newRowsInfo]);
			}
		},

		loadCrl: function (GXAction, ActionParameters, ActionResults) {
			if (gx.fn.getControlValue("IsConfirmed") == "1") {
				this.lastStatus = 0;
				return;
			}
			var backcall = function( VarValues) { gx.fn.setVarValues(ActionResults, VarValues)};
			var sURL = this.objectUrl() + '?';
			var sParms = 'gxajaxExecAct_' + GXAction + ',';
			sParms += this.arrayToUrl(ActionParameters);
			sURL += gx.ajax.encryptParms(gx.O, sParms);
			gx.http.callBackend_impl( backcall, sURL, true, gx.http.modes.retval);
		},

		udp: function (GXAction, InputParameters, OutputParameters) {
			var backcall = function( VarValues) { gx.fn.setVarValues(OutputParameters, VarValues)};
			var sURL = this.objectUrl() + '?';
			var sParms = GXAction + ',';
			sParms += this.arrayToUrl(InputParameters);
			sURL += gx.ajax.encryptParms(gx.O, sParms);
			gx.http.callBackend_impl( backcall, sURL, true, gx.http.modes.retval);
		},

		srvEvt: function (GXEvent, GXAction, InputParameters, OutputParameters) {
			var backcall = function( VarValues) { gx.fn.setVarValues(OutputParameters, VarValues)};
			var sURL = this.objectUrl() + '?';
			var sParms = GXEvent + ',' + GXAction + ',';
			sParms += this.arrayToUrl(InputParameters);
			sURL += gx.ajax.encryptParms(gx.O, sParms);
			gx.http.callBackend_impl( backcall, sURL, true, gx.http.modes.full);
		},

		validSrvEvt: function (GXAction, grid, gxO) {
			var currentRow = gx.fn.currentGridRowImpl(grid),
				oldCurrentRow;
			if (grid > 0) {
				oldCurrentRow = gx.fn.currentGridRowImpl(grid);
				setGridRow(grid, currentRow, gxO);
			}
			if (gx.fx.delayedValidation) {
				var deferred = $.Deferred();
				var args = arguments;
				gx.fx.obs.addObserver('gx.validation', this, function () {
					return this.validSrvEvt_impl.apply(this, args).then(function (ret) {
						deferred.resolve(ret);
						setGridRow(grid, oldCurrentRow, gxO);
					});
				}, { single: true, async: true });
				return deferred.promise();
			}
			else {
				return this.validSrvEvt_impl.apply(this, arguments).then(function (ret) {
					setGridRow(grid, oldCurrentRow, gxO);
					return ret;
				});
			}
		},
		
		validCliEvt: function (GXAction, grid, fn, gxO) {
			gxO = gxO || gx.O;
			return gx.evt.dispatcher.dispatch(
				{ eventName: GXAction, fn: fn }, 
				gxO, 
				grid, 
				gx.fn.currentGridRowImpl(grid), 
				false, 
				undefined, 
				undefined, 
				gx.evt.dispatcher.types.validation
			);
		},

		validSrvEvt_impl: function (GXAction, grid, gxO) {
			gxO = gxO || gx.O;
			var currentRow = gx.fn.currentGridRowImpl(grid);
			
			return gx.evt.dispatcher.dispatch(
				GXAction, 
				gxO, 
				grid, 
				currentRow, 
				true, 
				undefined, 
				undefined, 
				gx.evt.dispatcher.types.validation
			).then(function(ret) {
				gxO.refreshOlds();
				return ret;
			});
		},

		getParmsPostData: function (Parms) {
			var sURL = '';
			for (var i = 0; i < Parms.length; i++) {
				if (i > 0)
					sURL += '&';
				sURL += 'GXParm' + i + '=' + this.parmToUrl(Parms[i], true);
			}
			return sURL;
		},

		getCallerUrl: function (Lvl) {
			if (gx.stackSupported()) {
				var stack = gx.call_stack_storage.get(gx.stackId(Lvl));
				stack = stack || []; //En el stack SIEMPRE hay al menos un elemento que es la url en la que estoy. Por lo tanto pido la anterior. 
				var url = (stack.length == 1 && stack[0] != gx.ajax.selfUrl()) ? stack[0] : "";
				url = (stack.length > 1) ? stack[stack.length - 2] : url;
				return url;
			}
			else {
				return gx.fn.getHidden("sCallerURL");
			}
		},

		pushReferer: function (PopupLevel, url) {
			if (typeof (url) == 'undefined') {
				url = location.href;
			}
			else {
				url = gx.absoluteurl(url);
			}
			if (gx.stackSupported()) {
				if (typeof (PopupLevel) == 'undefined') {
					PopupLevel = gx.popup.popuplvl();
				}
				var stack = gx.call_stack_storage.get(gx.stackId(PopupLevel));
				stack = stack || [];
				if (url != gx.util.lastArray(stack))
					stack.push(url);
				gx.call_stack_storage.set(gx.stackId(PopupLevel), stack);
			}
			else {
				var sURL = this.objectUrl() + '?';
				var sParms = "dyncall,PushReferer," + encodeURIComponent(url);
				sURL += gx.ajax.encryptParms(gx.O, sParms);
				gx.http.callBackend_simple(sURL, true, true);
			}
		},


		windowClosed: function (PopupLevel) {
			if (gx.stackSupported()) {
				if (PopupLevel == -1) {
					var key = gx.stackId(gx.popup.popuplvl());
					var stack = gx.call_stack_storage.get(key);
					stack = stack || [];
					stack.pop();
					gx.call_stack_storage.set(key, stack);
				}
				else {
					gx.call_stack_storage.remove(gx.stackId(PopupLevel));
				}
			} else {
				var serverFunc = '';
				if (PopupLevel == -1)
					serverFunc = ',PopReferer';
				else
					serverFunc = ',DeleteReferer,' + PopupLevel.toString();
				var sURL = this.objectUrl() + '?';
				var sParms = "dyncall" + serverFunc;
				sURL += gx.ajax.encryptParms(gx.O, sParms);
				gx.http.callBackend_simple(sURL, true, true);
			}
		},

		aggSel: function (ControlId, Act, ActionParameters) {
			var sURL = this.objectUrl() + '?';
			var sParms = 'gxajaxAggSel' + Act + '_' + ControlId + ",";
			sParms += this.arrayToUrl(ActionParameters);
			sURL += gx.ajax.encryptParms(gx.O, sParms);
			var res = gx.http.callBackend_impl( null, sURL, false, gx.http.modes.retval);
			return res[0];
		},

		aggSelDecimal: function (ControlId, Act, ThSep, DecPoint, ActionParameters) {
			return gx.num.parseFloat(this.aggSel(ControlId, Act, ActionParameters), ThSep, DecPoint);
		},

		aggSelInteger: function (ControlId, Act, ActionParameters) {
			return parseInt(this.aggSel(ControlId, Act, ActionParameters), 10);
		},

		dynComponent: function (Name, Parms, Prefix, Row) {
			var deferred = $.Deferred();
			Name = gx.util.removeBaseUrl(Name).toLowerCase();
			var fullName = Name;
			if (gx.gen.isDotNet())
				fullName += '.aspx';
			var sURL = gx.ajax.objectUrl(fullName);
			var GXEvent = 'dyncomponent';
			var postData = 'GXEvent=' + gx.ajax.encryptParms(gx.O, GXEvent) + '&GXAction=' + encodeURIComponent(Prefix) + '&GXParm0=' + encodeURIComponent(Row);
			for (var i = 0; i < Parms.length; i++)
				postData += '&GXParm' + (i + 1).toString() + '=' + encodeURIComponent(typeof(Parms[i].getUrlVal) == 'function' ? Parms[i].getUrlVal() : Parms[i]);

			gx.http.doCall({
				method: 'POST',
				url: sURL,
				reqData: postData,
				handler: function(type, responseText) {
					deferred.resolve(gx.json.evalJSON(responseText));
				},
				error: function() {
					deferred.reject();
				}
			});
			return deferred.promise();
		},

		selfUrl: function () {
			return location.href.replace(/#[\s\S]*$/, '');
		},

		removeGXParms: function (url) {
			return url.replace(/\?gxajaxEvt,?|\?gxportlet,?/, '?');
		},

		getSecurityToken: function(gxO) {
			if (gxO && gxO.ajaxSecurityToken) {
				var cmpCtx = (gxO.CmpContext)? gxO.CmpContext: "";
				var secId = "GX_AUTH_" + cmpCtx + gxO.ServerClass;
				secId = secId.toUpperCase();
				var tokenValue = gx.fn.getHidden(secId) || gxO.InternalParms[secId];
				return { id: secId, value: tokenValue };
			}			
		},
		
		arrayToUrl: function (Parameters, serializeControls) {
			var sURL = '';
			var len = Parameters.length;
			for (var i = 0; i < len; i++) {
				sURL += this.parmToUrl(Parameters[i], serializeControls) + ',';
			}
			return sURL;
		},

		parmToUrl: function (Parm, serializeControls) {
			var value = eval(Parm);
			if (value instanceof Array && value.length == 2 && typeof (value[0]) == 'string' && typeof (value[1]) == 'string') // Property
			{
				var validStruct = gx.fn.vStructForVar(value[0]);
				if (validStruct != null) {
					value = gx.fn.getGridCtrlProperty(validStruct.grid, validStruct.fld, value[1]);
				}
			}
			if (serializeControls) {
				var vStruct = gx.fn.vStructForVar(gx.unprefixVar(Parm));
				if (vStruct != null) {
					if (gx.html.controls.isMultiSelection(vStruct.ctrltype)) {
						var ctrl = gx.fn.getControlGridRef(vStruct.fld, vStruct.grid);
						var ctrlJSON = gx.dom.comboBoxToObj(ctrl, value);
						if (ctrlJSON) {
							value = ctrlJSON;
						}
					}
				}
			}
			if (typeof (value) == 'object') {
				value = gx.json.serializeJson(value);
			}
			if (typeof (value) == 'undefined' || value == null) {
				var setted = false;
				if (Parm) {
					var gxoIdx = Parm.indexOf('gx.O.');
					if (gxoIdx === 0) {
						Parm = gx.unprefixVar(Parm);
						var hidVal = gx.fn.getHidden(gx.O.CmpContext + Parm);
						if (hidVal != null && typeof (hidVal) != 'undefined') {
							value = hidVal;
							setted = true;
						}
					}
				}
				if (!setted) {
					value = '';
				}
			}
			return encodeURIComponent(value);
		},

		gxObjectUrl: function (gxO) {
			var ObjUrl = '';
			if (gxO && gxO.serviceUrl) {
				ObjUrl = gxO.serviceUrl;
			}
			else if (gxO.fullAjax && gxO) {
				ObjUrl = gx.fn.getControlValue(gxO.CmpContext + '_CMPPGM') || '';					
			}
			return this.objectUrl(ObjUrl);
		},

		objectUrl: function (Obj) {
			var ObjUrl = '';
			if (Obj)
				ObjUrl = Obj;
			else {
				if (gx.csv.cmpCtx) //string with length >= 1
					ObjUrl = gx.fn.getControlValue(gx.csv.cmpCtx + '_CMPPGM');
				else
					ObjUrl = gx.ajax.selfUrl();
				if (ObjUrl != null) {
					ObjUrl = ObjUrl.replace(/\?.*/, '');
					ObjUrl = ObjUrl.replace(/#[\s\S]*$/, '');
				}
				ObjUrl = this.objnameFromUrl(ObjUrl);
			}
			return gx.absoluteurl(ObjUrl);
		},

		objnameFromUrl: function (url) {
			if (url.indexOf('?') >= 0)
				url = url.split('?')[0];
			var parts = url.split('/');
			var len = parts.length;
			if (len === 0)
				return url;
			return parts[len - 1];
		},

		_init: function () {
			this.resourceProvider = gx.fn.getHidden('GX_RES_PROVIDER');
			if (gx.stackSupported()) {
				var nav = gx.json.evalJSON(gx.fn.getHidden("GX_NAV"));
				if (nav) {
					for (var i = 0; i < nav.length; i++) {
						gx.ajax.pushReferer(gx.popup.popuplvl(), nav[i]);
					}
				}
				gx.ajax.pushReferer(gx.popup.popuplvl(), window.location.toString());
			}
		}
	};
})(gx.$);
/* END OF FILE - ..\js\gxcallrpc.js - */
/* START OF FILE - ..\js\gxballoon.js - */
gx.util.balloon = {
	balloons: {},
	timerOn: false,
	lastLbl: null,

	impl: function () {
		this.init = function (id, sourceElements) {
			this.id = id;
			this.balloonid = id + "_Balloon";
			this.hasMessage = false;
			this.messageErr = '';
			this.messageWar = '';
			this.isError = false;
			this.active = true;
			this.errorValue = null;
			this.sourceElements = sourceElements || [];
		}

		this.clear = function () {
			this.hasMessage = false;
			this.messageErr = '';
			this.messageWar = '';
			this.active = false;
			this.errorValue = null;
			gx.util.balloon.lastLbl = null;
		}

		this.setMessage = function (message) {
			if (!this.hasMessage) {
				this.messageWar = message;
				this.hasMessage = true;
			}
		}
		
		this.setAsFormatError = function () {
			this.isFormatError = true;
			gx.csv.setFormatError(this.id, false);
		}

		this.setError = function (message) {
			if (!this.hasMessage) {
				this.messageErr = message;
				this.isError = true;
				this.hasMessage = true;
				if (this.isFormatError) {
					gx.csv.setFormatError(this.id);
				}
			}
		}

		function findTriggerElement(control, sourceElements) {
			var triggerEl = $("#" + control.id + "_dp_trigger");
			if (triggerEl.length > 0) {
				return triggerEl.get(0);
			}

			if (sourceElements && sourceElements.length > 0) {
				triggerEl = $("[data-gx-attached-ctrl~='" + control.id + "']");
				if (triggerEl.length > 0) {
					return triggerEl.parent().get(0);
				}
			}
		}

		this.create = function (id, Control, Class, Msg) {
			var div, txt1, triggerEl, label, $gxAttributeEl;
			label = document.createElement("span");
			label.id = id;
			label.className = Class;
			div = document.createElement("div");
			div.style.position = "absolute";
			div.style.zIndex = 100;
			div.style.display = "none";
			txt1 = document.createTextNode(Msg);
			label.appendChild(txt1);
			div.appendChild(label);
			if (gx.csv.messagePosition == "right" || gx.csv.messagePosition == "bottom") {
				$gxAttributeEl = $(Control).closest('.gx-attribute');
				if (gx.csv.overlap === true && gx.runtimeTemplates && $gxAttributeEl.length > 0) {
					$gxAttributeEl.append(div);
				}
				else {
					triggerEl = findTriggerElement(Control);
					if (triggerEl) {
						if (triggerEl.id.indexOf("_dp_trigger") >= 0) {
							$(triggerEl).closest('.dp_container').append(div);
						}
						else {
							$(triggerEl).after(div);
						}
					}
					else {
						$(Control).after(div);
					}
				}
			}
			else {
				if (gx.csv.overlap === true) {
					$(Control).after(div);
				}
				else {
					$(Control).before(div);
				}
			}
			if (gx.csv.overlap === true) {
				label.style.position = "static";
				label.style.zIndex = "1";
			}
			else {
				div.style.position = "relative";
				label.style.position = "relative";
			}
			return label;
		}

		this.getControlValue = function () {
			var values = [gx.fn.getControlValue(this.id)];
			for (var i = 0, len = this.sourceElements.length; i < len; i++) {
				values.push(gx.fn.getControlValue(this.sourceElements[i]));
			}
			return values.join(";");
		};

		this.groupControl = function (id) {
			var Control = gx.dom.el(id);
			if (Control && Control.nodeName === 'INPUT' && Control.type === 'radio') {
				if (Control.parentNode && Control.parentNode.tagName == 'SPAN')
					Control = Control.parentNode;
				else {
					Control = gx.dom.findParentByTagName(Control, 'table');
				}
			}
			return Control;
		}

		this.hideBalloon = function (label) {
			var div = label.parentNode;
			try {
				if (div) {
					div.style.display = "none";
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxballoon.js', 'hideBalloon');
			}
		}

		this.showBalloon = function (label) {
			try {
				var messagePosition = gx.csv.messagePosition,
					Control = gx.dom.el(this.id),
					div = label.parentNode,
					$div = $(div),
					my,
					at,
					collision = (gx.popup.ispopup())? "flipfit": "none",
					ofEl = Control,
					triggerEl = findTriggerElement(Control, this.sourceElements);

				gx.lang.requestAnimationFrame(function () {
					if (gx.csv.overlap === true) {
						switch(messagePosition) {
							case "top":
								my = "left bottom";
								at = "left top";
								break;
							case "right":
								my = "left center";
								at = "right center";
								ofEl = triggerEl || ofEl;
								break;
							case "bottom":
								my = "left top";
								at = "left bottom";
								break;
							case "left":
								my = "right center";
								at = "left center";
								break;
						}

						$div.fadeIn().css("display","block");
						$div.position({
							my: my,
							at: at,
							of: ofEl,
							collision: collision
						});
					}
					else {
						if ((messagePosition == "top" || messagePosition == "bottom") && (gx.csv.overlap === false)) {
							div.style.display = "block";
						}
						else {
							div.style.display = "inline";
						}
					}
				});
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxballoon.js', 'showBalloon');
			}
		}

		this.show = function (batch) {
			var spanControl, 
				Control, 
				prefix, 
				text, 
				created, 
				label, 
				ControlBalloon, 
				ControlList, 
				i,
				len;
			if (document.readyState !== undefined && document.readyState != 'complete')
				return;
			try {
				if (this.hasMessage === false)
					return true;
				Control = gx.dom.el(this.id);
				if ((Control === null) && (gx.csv.validatingUC !== null))
					Control = gx.csv.validatingUC.getContainerControl();
				if (Control.type == 'hidden') {
					spanControl = gx.dom.byId('span_' + this.id);
					if (spanControl !== null)
						Control = spanControl;
				}
				else if (Control.nodeName === 'INPUT' && Control.type === 'radio')
				{
					ControlList = gx.dom.byName(gx.dom.id(Control));
					if (Control.parentNode && Control.parentNode.tagName == 'SPAN')
						Control = Control.parentNode;
					else
					{
						ControlBalloon = ControlList[0];
						Control = gx.dom.findParentByTagName(Control, 'table');
					}
				}
				if (!ControlList) {
					ControlList = [Control];
					for (i = 0, len = this.sourceElements.length; i < len; i++) {
						ControlList.push(gx.dom.el(this.sourceElements[i]));
					}
				}
				else {
					var controls = [];
					for (i = 0, len = ControlList.length; i < len; i++) {
						controls.push(ControlList[i])
					}
					ControlList = controls;
				}

				created = true;
				this.active = true;
				if (this.messageErr.length > 0) {
					prefix = "Error";
					text = this.messageErr;
				}
				else if (this.messageWar.length > 0) {
					prefix = "Warning";
					text = gx.html.encode(this.messageWar);
				}

				if (prefix !== "") {
					var cssClass = prefix + "Messages";
					gx.dom.addPrefixClass(Control, prefix);
					label = gx.dom.byId(this.balloonid);
					if (label) {
						label.innerHTML = text;
						created = false;
					}
					else
						label = this.create(this.balloonid, ControlBalloon ? ControlBalloon : Control, cssClass, text);
				}
				if (gx.util.balloon.lastLbl && gx.csv.oneAtAtime)
					this.hideBalloon(gx.util.balloon.lastLbl);
				gx.util.balloon.lastLbl = label;

				if (batch === true) {
					if (!gx.csv.oneAtAtime)
						this.showBalloon(label);
				} else {
					this.showBalloon(label);
				}
				if (gx.util.balloon.timerOn === false && gx.csv.dismissSeconds > 0) {
					gx.util.balloon.timerOn = true;
					this.timerId = setTimeout(function () { gx.util.balloon.clearAll(); }, gx.csv.dismissSeconds * 1000);
				} else if (created) {
					if (gx.csv.oneAtAtime) {
						gx.evt.attach(Control, "mouseout", gx.util.balloon.cvsMouseOutHandler.closure(this));
						gx.evt.attach(Control, "mouseover", gx.util.balloon.cvsMouseOverHandler.closure(this));
					}
					len = ControlList.length;
					for (i = 0; i < len; i++) {
						if (ControlList[i].nodeName === 'INPUT' && ControlList[i].type === 'radio')
							gx.evt.attach(ControlList[i], "change", gx.util.balloon.cvsHide, this);
						else
							gx.evt.attach(ControlList[i], "blur", gx.util.balloon.cvsHide, this);
					}
				}
				this.errorValue = this.getControlValue();
			}
			catch (E) {
				gx.dbg.logEx(E, 'gxballoon.js', 'show');
			}
			return !this.isError;
		}
	},

	cvsHide: function () {
		var Control, ctrl, ctrlValue;
		try {
			Control = this.groupControl(this.id);
			ctrlValue = this.getControlValue();
			if (ctrlValue == this.errorValue) {
				return;
			}
			this.errorValue = ctrlValue;
			ctrl = gx.dom.byId(this.balloonid);
			if (ctrl != null) {
				if (Control) {
					gx.dom.removePrefixClass(Control, "Error");
					gx.dom.removePrefixClass(Control, "Warning");
				}
				this.hideBalloon(ctrl);
				this.active = false;
			}
		}
		catch (e) { }
	},

	cvsMouseOutHandler: function () {
		if (!this.active) return;
		var label = gx.dom.byId(this.balloonid);
		if (label != null) {
			if (gx.util.balloon.lastLbl) {
				if (gx.util.balloon.lastLbl.id != label.id)
					this.hideBalloon(label);
			} else
				this.hideBalloon(label);
		}
	},

	cvsMouseOverHandler: function () {
		if (!this.active) return;
		var label = gx.dom.byId(this.balloonid);
		if (label != null)
			this.showBalloon(label);
	},

	clearAll: function () {
		var b, hide, index;
		this.timerOn = false;
		for (index in this.balloons) {
			b = this.balloons[index];
			hide = gx.util.balloon.cvsHide.closure(b);
			b.clear();
			hide();
		}
	},

	clear: function (ctrlId) {
		var Id, b, hide;
		try {
			Id = gx.csv.ctxControlId(ctrlId);
			if (this.balloons[Id]) {
				b = this.balloons[Id];
				hide = gx.util.balloon.cvsHide.closure(b);
				b.clear();
				hide();
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxballoon.js', 'clear');
		}
	},

	getNew: function (Id, RowId, SourceElements) {
		SourceElements = SourceElements || [];
		var Ctrl, ctrlId, b, i, len = SourceElements.length;
		if (typeof (RowId) != 'undefined')
			Id = Id + '_' + RowId;
		try {
			Ctrl = gx.fn.screen_CtrlRef(Id);
			ctrlId = gx.dom.id(Ctrl);
			Id = gx.csv.ctxControlId(ctrlId);
			for (i = 0; i < len; i++) {
				Ctrl = gx.fn.screen_CtrlRef(SourceElements[i]);
				ctrlId = gx.dom.id(Ctrl);
				SourceElements[i] = gx.csv.ctxControlId(ctrlId);
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxballoon.js', 'getNew');
		}
		if (this.balloons[Id]) {
			b = this.balloons[Id];
			b.sourceElements = SourceElements || [];
			b.clear();
		}
		else {
			b = new this.impl();
			this.balloons[Id] = b;
			b.init(Id, SourceElements);
		}
		return b;
	}
};
/* END OF FILE - ..\js\gxballoon.js - */
/* START OF FILE - ..\js\gxtimezone.js - */
/*
 MIT License - https://bitbucket.org/pellepim/jstimezonedetect/src/default/LICENCE.txt

 For usage and examples, visit:
 http://pellepim.bitbucket.org/jstz/

 Copyright (c) Jon Nylander
*/
(function(n){var i=function(){var n={"America/Denver":["America/Mazatlan"],"Europe/London":["Africa/Casablanca"],"America/Chicago":["America/Mexico_City"],"America/Asuncion":["America/Campo_Grande","America/Santiago"],"America/Montevideo":["America/Sao_Paulo","America/Santiago"],"Asia/Beirut":"Asia/Amman Asia/Jerusalem Europe/Helsinki Asia/Damascus Africa/Cairo Asia/Gaza Europe/Minsk".split(" "),"Pacific/Auckland":["Pacific/Fiji"],"America/Los_Angeles":["America/Santa_Isabel"],"America/New_York":["America/Havana"],
"America/Halifax":["America/Goose_Bay"],"America/Godthab":["America/Miquelon"],"Asia/Dubai":["Asia/Yerevan"],"Asia/Jakarta":["Asia/Krasnoyarsk"],"Asia/Shanghai":["Asia/Irkutsk","Australia/Perth"],"Australia/Sydney":["Australia/Lord_Howe"],"Asia/Tokyo":["Asia/Yakutsk"],"Asia/Dhaka":["Asia/Omsk"],"Asia/Baku":["Asia/Yerevan"],"Australia/Brisbane":["Asia/Vladivostok"],"Pacific/Noumea":["Asia/Vladivostok"],"Pacific/Majuro":["Asia/Kamchatka","Pacific/Fiji"],"Pacific/Tongatapu":["Pacific/Apia"],"Asia/Baghdad":["Europe/Minsk",
"Europe/Moscow"],"Asia/Karachi":["Asia/Yekaterinburg"],"Africa/Johannesburg":["Asia/Gaza","Africa/Cairo"]},p=function(d){d=-d.getTimezoneOffset();return null!==d?d:0},r=function(){var d=p(new Date(2014,0,2)),a=p(new Date(2014,5,2)),b=d-a;return 0>b?d+",1":0<b?a+",1,s":d+",0"},s=function(){var d;if(!("undefined"===typeof Intl||"undefined"===typeof Intl.DateTimeFormat))if(d=Intl.DateTimeFormat(),!("undefined"===typeof d||"undefined"===typeof d.resolvedOptions))if((d=d.resolvedOptions().timeZone)&&(-1<
d.indexOf("/")||"UTC"===d))return d},q=function a(b,g,c){"undefined"===typeof g&&(g=864E5,c=36E5);for(var f=(new Date(b.getTime()-g)).getTime(),b=b.getTime()+g,i=(new Date(f)).getTimezoneOffset(),h=null;f<b-c;){var m=new Date(f);if(m.getTimezoneOffset()!==i){h=m;break}f+=c}return 864E5===g?a(h,36E5,6E4):36E5===g?a(h,6E4,1E3):h},t=function(a,b,g,c){if("N/A"!==g)return g;if("Asia/Beirut"===b){if("Africa/Cairo"===c.name&&13983768E5===a[6].s&&14116788E5===a[6].e||"Asia/Jerusalem"===c.name&&13959648E5===
a[6].s&&14118588E5===a[6].e)return 0}else if("America/Santiago"===b){if("America/Asuncion"===c.name&&14124816E5===a[6].s&&1397358E6===a[6].e||"America/Campo_Grande"===c.name&&14136912E5===a[6].s&&13925196E5===a[6].e)return 0}else if("America/Montevideo"===b){if("America/Sao_Paulo"===c.name&&14136876E5===a[6].s&&1392516E6===a[6].e)return 0}else if("Pacific/Auckland"===b&&"Pacific/Fiji"===c.name&&14142456E5===a[6].s&&13961016E5===a[6].e)return 0;return g},u=function(a,b){for(var g={},c=i.olson.dst_rules.zones,
f=c.length,l=n[b],h=0;h<f;h++){var m=c[h],j;j=c[h];for(var k=0,e=0;e<a.length;e++)if(j.rules[e]&&a[e]){if(a[e].s>=j.rules[e].s&&a[e].e<=j.rules[e].e)k=0,k+=Math.abs(a[e].s-j.rules[e].s),k+=Math.abs(j.rules[e].e-a[e].e);else{k="N/A";break}if(864E6<k){k="N/A";break}}j=k=t(a,b,k,j);"N/A"!==j&&(g[m.name]=j)}for(var o in g)if(g.hasOwnProperty(o))for(c=0;c<l.length;c++)if(l[c]===o)return o;return b},v=function(a){var b=function(){for(var a=[],b=0;b<i.olson.dst_rules.years.length;b++){var f;f=i.olson.dst_rules.years[b];
var l=(new Date(f,0,1,0,0,1,0)).getTime();f=(new Date(f,12,31,23,59,59)).getTime();for(var h=(new Date(l)).getTimezoneOffset(),m=null,j=null;l<f-864E5;){var k=new Date(l),e=k.getTimezoneOffset();e!==h&&(e<h&&(m=k),e>h&&(j=k),h=e);l+=864E5}f=m&&j?{s:q(m).getTime(),e:q(j).getTime()}:!1;a.push(f)}return a}();return function(a){for(var b=0;b<a.length;b++)if(!1!==a[b])return!0;return!1}(b)?u(b,a):a};return{determine:function(){var a=navigator.userAgent.toLowerCase(),b=s();if(!b){if(-1!=a.indexOf("firefox")&&
("undefined"!==typeof Intl&&"undefined"!==typeof Intl.DateTimeFormat)&&(a=Intl.DateTimeFormat(void 0,{timeZoneName:"long"}).format(new Date).toLowerCase(),-1!=a.indexOf("montevideo")||-1!=a.indexOf("uruguay")))b="America/Montevideo";b||(b=i.olson.timezones[r()]);"undefined"!==typeof n[b]&&(b=v(b))}return{name:function(){return b}}}}}();i.olson=i.olson||{};i.olson.timezones={"-720,0":"Etc/GMT+12","-660,0":"Pacific/Pago_Pago","-660,1,s":"Pacific/Apia","-600,1":"America/Adak","-600,0":"Pacific/Honolulu",
"-570,0":"Pacific/Marquesas","-540,0":"Pacific/Gambier","-540,1":"America/Anchorage","-480,1":"America/Los_Angeles","-480,0":"Pacific/Pitcairn","-420,0":"America/Phoenix","-420,1":"America/Denver","-360,0":"America/Guatemala","-360,1":"America/Chicago","-360,1,s":"Pacific/Easter","-300,0":"America/Bogota","-300,1":"America/New_York","-270,0":"America/Caracas","-240,1":"America/Halifax","-240,0":"America/Santo_Domingo","-240,1,s":"America/Asuncion","-210,1":"America/St_Johns","-180,1":"America/Godthab",
"-180,0":"America/Argentina/Buenos_Aires","-180,1,s":"America/Montevideo","-120,0":"America/Noronha","-120,1":"America/Noronha","-60,1":"Atlantic/Azores","-60,0":"Atlantic/Cape_Verde","0,0":"UTC","0,1":"Europe/London","60,1":"Europe/Berlin","60,0":"Africa/Lagos","60,1,s":"Africa/Windhoek","120,1":"Asia/Beirut","120,0":"Africa/Johannesburg","180,0":"Asia/Baghdad","180,1":"Europe/Moscow","210,1":"Asia/Tehran","240,0":"Asia/Dubai","240,1":"Asia/Baku","270,0":"Asia/Kabul","300,1":"Asia/Yekaterinburg",
"300,0":"Asia/Karachi","330,0":"Asia/Kolkata","345,0":"Asia/Kathmandu","360,0":"Asia/Dhaka","360,1":"Asia/Omsk","390,0":"Asia/Rangoon","420,1":"Asia/Krasnoyarsk","420,0":"Asia/Jakarta","480,0":"Asia/Shanghai","480,1":"Asia/Irkutsk","525,0":"Australia/Eucla","525,1,s":"Australia/Eucla","540,1":"Asia/Yakutsk","540,0":"Asia/Tokyo","570,0":"Australia/Darwin","570,1,s":"Australia/Adelaide","600,0":"Australia/Brisbane","600,1":"Asia/Vladivostok","600,1,s":"Australia/Sydney","630,1,s":"Australia/Lord_Howe",
"660,1":"Asia/Kamchatka","660,0":"Pacific/Noumea","690,0":"Pacific/Norfolk","720,1,s":"Pacific/Auckland","720,0":"Pacific/Majuro","765,1,s":"Pacific/Chatham","780,0":"Pacific/Tongatapu","780,1,s":"Pacific/Apia","840,0":"Pacific/Kiritimati"};i.olson.dst_rules={years:[2008,2009,2010,2011,2012,2013,2014],zones:[{name:"Africa/Cairo",rules:[{e:12199572E5,s:12090744E5},{e:1250802E6,s:1240524E6},{e:12858804E5,s:12840696E5},!1,!1,!1,{e:14116788E5,s:1406844E6}]},{name:"Africa/Casablanca",rules:[{e:12202236E5,
s:12122784E5},{e:12508092E5,s:12438144E5},{e:1281222E6,s:12727584E5},{e:13120668E5,s:13017888E5},{e:13489704E5,s:1345428E6},{e:13828392E5,s:13761E8},{e:14142888E5,s:14069448E5}]},{name:"America/Asuncion",rules:[{e:12050316E5,s:12243888E5},{e:12364812E5,s:12558384E5},{e:12709548E5,s:12860784E5},{e:13024044E5,s:1317528E6},{e:1333854E6,s:13495824E5},{e:1364094E6,s:1381032E6},{e:13955436E5,s:14124816E5}]},{name:"America/Campo_Grande",rules:[{e:12032172E5,s:12243888E5},{e:12346668E5,s:12558384E5},{e:12667212E5,
s:1287288E6},{e:12981708E5,s:13187376E5},{e:13302252E5,s:1350792E6},{e:136107E7,s:13822416E5},{e:13925196E5,s:14136912E5}]},{name:"America/Goose_Bay",rules:[{e:122559486E4,s:120503526E4},{e:125704446E4,s:123648486E4},{e:128909886E4,s:126853926E4},{e:13205556E5,s:129998886E4},{e:13520052E5,s:13314456E5},{e:13834548E5,s:13628952E5},{e:14149044E5,s:13943448E5}]},{name:"America/Havana",rules:[{e:12249972E5,s:12056436E5},{e:12564468E5,s:12364884E5},{e:12885012E5,s:12685428E5},{e:13211604E5,s:13005972E5},
{e:13520052E5,s:13332564E5},{e:13834548E5,s:13628916E5},{e:14149044E5,s:13943412E5}]},{name:"America/Mazatlan",rules:[{e:1225008E6,s:12074724E5},{e:12564576E5,s:1238922E6},{e:1288512E6,s:12703716E5},{e:13199616E5,s:13018212E5},{e:13514112E5,s:13332708E5},{e:13828608E5,s:13653252E5},{e:14143104E5,s:13967748E5}]},{name:"America/Mexico_City",rules:[{e:12250044E5,s:12074688E5},{e:1256454E6,s:12389184E5},{e:12885084E5,s:1270368E6},{e:1319958E6,s:13018176E5},{e:13514076E5,s:13332672E5},{e:13828572E5,s:13653216E5},
{e:14143068E5,s:13967712E5}]},{name:"America/Miquelon",rules:[{e:12255984E5,s:12050388E5},{e:1257048E6,s:12364884E5},{e:12891024E5,s:12685428E5},{e:1320552E6,s:12999924E5},{e:13520016E5,s:1331442E6},{e:13834512E5,s:13628916E5},{e:14149008E5,s:13943412E5}]},{name:"America/Santa_Isabel",rules:[{e:12250116E5,s:1207476E6},{e:12564612E5,s:12389256E5},{e:12885156E5,s:12703752E5},{e:13199652E5,s:13018248E5},{e:13514148E5,s:13332744E5},{e:13828644E5,s:13653288E5},{e:1414314E6,s:13967784E5}]},{name:"America/Santiago",
rules:[{e:1206846E6,s:1223784E6},{e:1237086E6,s:12552336E5},{e:127035E7,s:12866832E5},{e:13048236E5,s:13138992E5},{e:13356684E5,s:13465584E5},{e:1367118E6,s:13786128E5},{e:13985676E5,s:14100624E5}]},{name:"America/Sao_Paulo",rules:[{e:12032136E5,s:12243852E5},{e:12346632E5,s:12558348E5},{e:12667176E5,s:12872844E5},{e:12981672E5,s:1318734E6},{e:13302216E5,s:13507884E5},{e:13610664E5,s:1382238E6},{e:1392516E6,s:14136876E5}]},{name:"Asia/Amman",rules:[{e:1225404E6,s:12066552E5},{e:12568536E5,s:12381048E5},
{e:12883032E5,s:12695544E5},{e:13197528E5,s:13016088E5},!1,!1,{e:14147064E5,s:13959576E5}]},{name:"Asia/Damascus",rules:[{e:12254868E5,s:120726E7},{e:125685E7,s:12381048E5},{e:12882996E5,s:12701592E5},{e:13197492E5,s:13016088E5},{e:13511988E5,s:13330584E5},{e:13826484E5,s:1364508E6},{e:14147028E5,s:13959576E5}]},{name:"Asia/Dubai",rules:[!1,!1,!1,!1,!1,!1,!1]},{name:"Asia/Gaza",rules:[{e:12199572E5,s:12066552E5},{e:12520152E5,s:12381048E5},{e:1281474E6,s:126964086E4},{e:1312146E6,s:130160886E4},{e:13481784E5,
s:13330584E5},{e:13802292E5,s:1364508E6},{e:1414098E6,s:13959576E5}]},{name:"Asia/Irkutsk",rules:[{e:12249576E5,s:12068136E5},{e:12564072E5,s:12382632E5},{e:12884616E5,s:12697128E5},!1,!1,!1,!1]},{name:"Asia/Jerusalem",rules:[{e:12231612E5,s:12066624E5},{e:1254006E6,s:1238112E6},{e:1284246E6,s:12695616E5},{e:131751E7,s:1301616E6},{e:13483548E5,s:13330656E5},{e:13828284E5,s:13645152E5},{e:1414278E6,s:13959648E5}]},{name:"Asia/Kamchatka",rules:[{e:12249432E5,s:12067992E5},{e:12563928E5,s:12382488E5},
{e:12884508E5,s:12696984E5},!1,!1,!1,!1]},{name:"Asia/Krasnoyarsk",rules:[{e:12249612E5,s:12068172E5},{e:12564108E5,s:12382668E5},{e:12884652E5,s:12697164E5},!1,!1,!1,!1]},{name:"Asia/Omsk",rules:[{e:12249648E5,s:12068208E5},{e:12564144E5,s:12382704E5},{e:12884688E5,s:126972E7},!1,!1,!1,!1]},{name:"Asia/Vladivostok",rules:[{e:12249504E5,s:12068064E5},{e:12564E8,s:1238256E6},{e:12884544E5,s:12697056E5},!1,!1,!1,!1]},{name:"Asia/Yakutsk",rules:[{e:1224954E6,s:120681E7},{e:12564036E5,s:12382596E5},{e:1288458E6,
s:12697092E5},!1,!1,!1,!1]},{name:"Asia/Yekaterinburg",rules:[{e:12249684E5,s:12068244E5},{e:1256418E6,s:1238274E6},{e:12884724E5,s:12697236E5},!1,!1,!1,!1]},{name:"Asia/Yerevan",rules:[{e:1224972E6,s:1206828E6},{e:12564216E5,s:12382776E5},{e:1288476E6,s:12697272E5},{e:13199256E5,s:13011768E5},!1,!1,!1]},{name:"Australia/Lord_Howe",rules:[{e:12074076E5,s:12231342E5},{e:12388572E5,s:12545838E5},{e:12703068E5,s:12860334E5},{e:13017564E5,s:1317483E6},{e:1333206E6,s:13495374E5},{e:13652604E5,s:1380987E6},
{e:139671E7,s:14124366E5}]},{name:"Australia/Perth",rules:[{e:12068136E5,s:12249576E5},!1,!1,!1,!1,!1,!1]},{name:"Europe/Helsinki",rules:[{e:12249828E5,s:12068388E5},{e:12564324E5,s:12382884E5},{e:12884868E5,s:1269738E6},{e:13199364E5,s:13011876E5},{e:1351386E6,s:13326372E5},{e:13828356E5,s:13646916E5},{e:14142852E5,s:13961412E5}]},{name:"Europe/Minsk",rules:[{e:12249792E5,s:12068352E5},{e:12564288E5,s:12382848E5},{e:12884832E5,s:12697344E5},!1,!1,!1,!1]},{name:"Europe/Moscow",rules:[{e:12249756E5,
s:12068316E5},{e:12564252E5,s:12382812E5},{e:12884796E5,s:12697308E5},!1,!1,!1,!1]},{name:"Pacific/Apia",rules:[!1,!1,!1,{e:13017528E5,s:13168728E5},{e:13332024E5,s:13489272E5},{e:13652568E5,s:13803768E5},{e:13967064E5,s:14118264E5}]},{name:"Pacific/Fiji",rules:[!1,!1,{e:12696984E5,s:12878424E5},{e:13271544E5,s:1319292E6},{e:1358604E6,s:13507416E5},{e:139005E7,s:1382796E6},{e:14215032E5,s:14148504E5}]},{name:"Europe/London",rules:[{e:12249828E5,s:12068388E5},{e:12564324E5,s:12382884E5},{e:12884868E5,
s:1269738E6},{e:13199364E5,s:13011876E5},{e:1351386E6,s:13326372E5},{e:13828356E5,s:13646916E5},{e:14142852E5,s:13961412E5}]}]};"undefined"!==typeof module&&"undefined"!==typeof module.exports?module.exports=i:"undefined"!==typeof define&&null!==define&&null!=define.amd?define([],function(){return i}):"undefined"===typeof n?window.jstz=i:n.jstz=i})();
/* END OF FILE - ..\js\gxtimezone.js - */
/* START OF FILE - ..\GenCommon\js\livepreview.js - */
// jshint options

gx.livePrev = (function ($) {
	var SERVER_REQUEST_RETRY_TIMEOUT = 100,
		GXLIVEPREVIEW_HIDESUBEL_CSSCLASS = 'gxlivepreview-hidesubelements',
		getInfo = gx.ajax.getPostInfo("", false);
		postInfo = gx.ajax.getPostInfo("", false);
	
	var url2Base64Content= function( url) {
		return url.replace(/^data:(image\/png;base64)?,/,'');
		};	
	var select_elements = function( gxO, gxCtrlIdO) {
		var gxCtrlId = gxO.CmpContext + gxCtrlIdO;
		if (gxO == gx.pO.MasterPage)
			gxCtrlId = gxCtrlId + '_MPAGE';
		var jqElements_sel = $('#'+gxCtrlId);
		if (jqElements_sel.length == 0)
			jqElements_sel = $("[id^="+gxCtrlId+"]");
		if (jqElements_sel.length == 0)
			jqElements_sel = $("[name="+gxCtrlId+"]");
		if (jqElements_sel.length == 0)
			jqElements_sel = $("[name^="+gxCtrlId+"]");
		if (jqElements_sel.length == 0)
			jqElements_sel = $("[id^=span_"+gxCtrlId+"]");
		return jqElements_sel;
	};
	var postition_element = function( jqElement, MssEl) {
		if (jqElement) {
			var offset = jqElement.offset();
			if (offset) {
				MssEl.x = offset.left;
				MssEl.y = offset.top;
			}					
			MssEl.w = jqElement.outerWidth();
			MssEl.h = jqElement.outerHeight();
		}
	};			
	var component2GXCtrl = function( CmpPrefix) {
		var Cmp = gx.pO.getComponentByPrefix(CmpPrefix) || (gx.pO.MasterPage ? gx.pO.MasterPage.getComponentByPrefix(CmpPrefix) : null);
		if (Cmp) {
			return Cmp.id;
		}
		var len = gx.pO.WebComponents.length;
		for (var i = 0; i < len; i++) {
			Cmp = gx.pO.WebComponents[i];
			Cmp = Cmp.getComponentByPrefix(CmpPrefix.replace(new RegExp("^"+Cmp.CmpContext), ''));
			if (Cmp) {
				return Cmp.id;
			}
		}
		return null;
	};
	var beforeSend = function(req) {
		req.setRequestHeader('GeneXus-Language', gx.languageCode);
		req.setRequestHeader('DeviceOSName', 'Web');
		req.setRequestHeader('DeviceName', 'Web Simulator');
		req.setRequestHeader('DeviceId', clientGUID);
		req.setRequestHeader('GeneXus-Theme', gx.theme);
	};
	
	return {
	}
})(gx.$);

gx.livePrevWS = {
	FIRST_PORT: 30100,
	LAST_PORT: 30120,
	MAX_RETRY:3,
	retry_count:0,

	onError: function()	{
		if ( gx.livePrevWS.IPNamesIdx < gx.livePrevWS.IPNames.length - 1) {
				gx.livePrevWS.IPNamesIdx +=1;
				gx.livePrevWS.host = gx.livePrevWS.IPNames[gx.livePrevWS.IPNamesIdx];
				gx.livePrev.port = gx.livePrevWS.FIRST_PORT;
				gx.livePrevWS.Connect();
		}
		else {
			if (gx.livePrev.port < gx.livePrevWS.LAST_PORT) {
				gx.livePrevWS.IPNamesIdx =0;
				gx.livePrev.port +=1;
				gx.livePrevWS.Connect();
			}
			else {
				gx.util.alert.showMessage('Can not Connect to LivePreview', {dismissmitAt:5000});
			}
		}
	},
	onMessage: function( msg) {
		var searchStyleByHRef = function( href) {
			var sArr = $.map(document.styleSheets, function( s) {
				return (s.href == href) ? s : null;
			});
			return sArr.length > 0 ? sArr[0] : undefined;
		};
		
		var normalizeCompare = function( val1, val2, compare) {
			return compare((val1||'').replace(/(\r\n|\r|\n| )/gm, '').toLowerCase() , (val2||'').replace(/(\r\n|\r|\n| )/gm, '').toLowerCase());
		}
		
		var replaceCSSRule = function( styleSheet, selector, cssCode) {
			var cssRules = styleSheet.cssRules;
			var idx = cssRules.length;
			var found = false;
			var partial = false;
			$.each(cssRules, function( i, r) {
				if (r && r.selectorText && normalizeCompare(r.selectorText, selector.replace(':', '::'), function(a,b){ return a == b} )) {
					styleSheet.deleteRule( i);
					idx = i;
					found = true;
					return;
				}
			});
			if (!found) {
				$.each(cssRules, function( i, r) {
					if (r && r.selectorText && normalizeCompare(r.selectorText, selector.replace(':', '::') + ',', function(a,b){ return a.indexOf(b) == 0})) {
						styleSheet.deleteRule( i);
						idx = i;
						styleSheet.insertRule( r.selectorText + cssCode.replace(/.*{/, "{"), idx);
						partial = true;
					}
				});
			}
			if (!partial) {
				styleSheet.insertRule( cssCode, idx);
			}
		}
		
		var processCSS = function (data) {
			var themeStyle = gx.getThemeElement();
			var id = themeStyle.id;
			var styleSheet = searchStyleByHRef( themeStyle.href);
			if (styleSheet) {
				var isMediaRule = data.indexOf('@media',0) == 0;
				var arrSelector = data.split(/{|}/);
				for (var idx=0; idx < arrSelector.length - 1; idx+=2) {
					var selector = arrSelector[idx].replace(/(\r\n|\r|\n| *$)/gm, '');
					if (!gx.lang.emptyObject(selector)) {
						if (isMediaRule) {
							$.each(styleSheet.cssRules, function( i, r) {
								if (isMediaRule && !r.selectorText) {
									var cssMediaSelector = r.cssText.split(/{/)[0];
									if ( normalizeCompare(cssMediaSelector.replace(/ all and/gm, ''), selector)) {
										selector = arrSelector[idx + 1].replace(/(\r\n|\r|\n| )/gm, '');
										replaceCSSRule( r, selector, selector + ' {' + arrSelector[idx + 2] + '}');
										return;
									}
								}
							});
						}
						else {
							replaceCSSRule( styleSheet, selector, selector + ' {' + arrSelector[idx + 1] + '}');
						}
					}
				}
			}
		};
		var msg = gx.json.evalJSON(msg);
		if (msg.Type === 'KBOK') {
			gx.util.alert.showMessage('Connected to LivePreview at ' + gx.livePrevWS.host + ' on port ' + gx.livePrev.port, {dismissmitAt:2000});
		}
		else {
			if (msg.Type === 'KBDoesNotMatchGUID') {
				gx.livePrevWS.onError();			
			}
			else {
				if (msg.Type === 'ThemeStyleChanged') {
					processCSS( msg.Data);
				}
			}
		}
	},
	onOpen: function()	{
		if (gx.livePrevWS.timeOutHdlr) {
			clearTimeout(gx.livePrevWS.timeOutHdlr);
		}
		gx.livePrevWS.retry_count = 0;
		gx.livePrevWS.SocketConnect();
	},
	onTimeout: function()	{
		gx.livePrevWS.webSocket.close();
		gx.livePrevWS.onError();
	},
	SocketConnect: function () {
		objData = 
		{
		  "KBUUID": gx.livePrevWS.KBUUID,
		  "Language": gx.languageCode,
		  "KBName": "TestWS",
		  "DeviceName": "Web Simulator",
		  "DeviceId": gx.livePrevWS.clientGUID,
		  "DeviceType": 0,
		  "DeviceOSName": "Web",
		  "Theme": gx.theme,
		  "Type": "Connect",
		  "Data": {
			"Name": gx.livePrevWS.KBName,
			"UUID": gx.livePrevWS.KBUUID
			}
		};
		gx.livePrevWS.webSocket.send(gx.json.serializeJson(objData));
	},	
	Connect:function () {
		var wsOpts = {};
		gx.livePrev.port = gx.livePrev.port || gx.livePrevWS.FIRST_PORT;
		wsOpts.port = gx.livePrev.port;
		wsOpts.wsProtocol = (location.protocol === 'https:')? "wss://": "ws://";
		wsOpts.host = gx.livePrevWS.host + ":" + wsOpts.port;
		wsOpts.resourceUrl = "/live/";
		wsOpts.namespace = "livepreview";
		wsOpts.maxRetries = 10;
		wsOpts.retryDelay = 50;

		if (gx.livePrevWS.webSocket)
			gx.livePrevWS.webSocket.close();
		gx.livePrevWS.webSocket = new gx.webSocket(wsOpts);
		gx.livePrevWS.timeOutHdlr = setTimeout(gx.livePrevWS.onTimeout, 3000);
	},
	
	_init: function () {
		var isEnabled = function() {
				return !gx.lang.emptyObject(gx.livePreviewUri);
		};
		if (isEnabled()) {
			gx.fx.obs.addObserver('gx.ws.onOpen.livepreview', gx.livePrevWS, gx.livePrevWS.onOpen, { single: false });
			gx.fx.obs.addObserver('gx.ws.onMessage.livepreview', gx.livePrevWS, gx.livePrevWS.onMessage, { single: false });
			gx.fx.obs.addObserver('gx.ws.onError.livepreview', gx.livePrevWS, gx.livePrevWS.onError, { single: false });
			gx.fx.obs.addObserver('gx.ws.onCtxError.livepreview', gx.livePrevWS, gx.livePrevWS.onError, { single: false });
			var ClientGUIDKey = "GXClientID",
				generateClientGUID = function() {
					var clientGUID = gx.http.getCookie(ClientGUIDKey);
					clientGUID = clientGUID || gx.guid.generate();
					gx.http.setCookie(ClientGUIDKey, clientGUID, 1, false);
					return clientGUID;
				};
			if (!gx.livePrevWS.clientGUID)
				gx.livePrevWS.clientGUID = generateClientGUID();
			var KBName = '',
				IPNames = [],
				KBUUID = gx.livePreviewUri.split('?');
			if (KBUUID.length > 0) {
				KBUUID = KBUUID[1];

				KBUUID = KBUUID.split(':');
				if (KBUUID.length > 2) {
					KBName = KBUUID[1];
					IPNames = KBUUID[2].substring( 1, KBUUID[2].length-1).split(',');
					KBUUID = KBUUID[0];
				}
			}
			gx.livePrevWS.IPNamesIdx = 0;
			gx.livePrevWS.IPNames = IPNames;
			gx.livePrevWS.KBName = KBName;
			gx.livePrevWS.KBUUID = KBUUID;
			gx.livePrevWS.host = gx.livePrevWS.IPNames[0];
		    gx.http.loadScript(gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "html2canvas.js" + '?' + gx.gxBuild, false), gx.livePrevWS.Connect);
		}
	}
}

/* END OF FILE - ..\GenCommon\js\livepreview.js - */
/* START OF FILE - ..\GenCommon\js\nav.js - */
gx.nav = (function () {
	var useWebComponent = (function () {
		var wcTargets = {
			"top": true,
			"right": true,
			"bottom": true,
			"left": true
		};

		return function (target) {
			return !!wcTargets[target.toLowerCase()];
		};
	})();
	
	var resolveObjClass = function (objUrl) {
		var objClass = objUrl;
		if (gx.gen.isDotNet())
			objClass = objUrl.replace(/\.aspx$/, "");
		if (gx.gen.isJava() && gx.pO.PackageName && gx.text.startsWith(objUrl, gx.pO.PackageName))
			objClass = objUrl.substring(gx.pO.PackageName.length + 1);
		return objClass;
	};

	var resolveObjectAndArgsByUrl = function (objUrlWithParms) {
		var urlParts = objUrlWithParms.split("?"),
			args, i, len;
		if (urlParts.length > 0) {
			args = urlParts.length == 2 ? urlParts[1].split(gx.http.urlParameterSeparator(objUrlWithParms)) : [];
			for (i = 0, len = args.length; i < len; i++) {
				args[i] = gx.http.useNamedParameters(objUrlWithParms)? decodeURIComponent(args[i].split("=")[1]) : decodeURIComponent(args[i]);
			}
			return {
				obj: urlParts[0],
				args: args
			};
		}
		return false;
	};
	
	var currentTargets = {};
	
	return {
		setCallTarget: function (objClass, target) {
			currentTargets[objClass.toLowerCase()] = target.toLowerCase();
		},

		willRedirect: function (obj) {
			if (gx.pO && !gx.pO.fullAjax) {
				return true;
			}
			return !useWebComponent(currentTargets[resolveObjClass(obj).toLowerCase()] || "");
		},

		willRedirectByUrl: function (objUrlWithParms) {
			var objData = resolveObjectAndArgsByUrl(objUrlWithParms);
			return this.willRedirect(objData.obj, objData.args);
		},

		call: function (objUrl, args, target) {
			var objClass = resolveObjClass(objUrl),
				masterPage = gx.pO.MasterPage;
			target = target || currentTargets[objClass.toLowerCase()] || "";

			delete currentTargets[objClass.toLowerCase()];

			if (gx.pO && !gx.pO.fullAjax) {
				gx.http.redirect(gx.http.formatLink(objUrl, args), false, false, gx.pO);
				return;
			}
			
			if (useWebComponent(target)) {
				if (masterPage) {
					masterPage.createObjectInTarget(target, objClass, args);
				}
			}
			else {
				gx.http.redirect(gx.http.formatLink(objUrl, args), false, false, gx.pO);
			}
		},

		callUrl: function (objUrlWithParms, target) {
			var objData = resolveObjectAndArgsByUrl(objUrlWithParms);
			if (objData) {
				this.call(objData.obj, objData.args, target);
			}
		},

		callFromServerRedirect: function (objUrlWithParms, target) {
			this.callUrl(objUrlWithParms, target);
		}
	};
})(gx.$);
/* END OF FILE - ..\GenCommon\js\nav.js - */
/* START OF FILE - ..\GenCommon\js\jquery-ui.js - */
/*! jQuery UI - v1.11.4 - 2016-07-07
* http://jqueryui.com
* Includes: position.js
* Copyright jQuery Foundation and other contributors; Licensed MIT */

(function( factory ) {
	if ( typeof define === "function" && define.amd ) {

		// AMD. Register as an anonymous module.
		define([ "jquery" ], factory );
	} else {

		// Browser globals
		factory( jQuery );
	}
}(function( $ ) {
/*!
 * jQuery UI Position 1.11.4
 * http://jqueryui.com
 *
 * Copyright jQuery Foundation and other contributors
 * Released under the MIT license.
 * http://jquery.org/license
 *
 * http://api.jqueryui.com/position/
 */

(function() {

$.ui = $.ui || {};

var cachedScrollbarWidth, supportsOffsetFractions,
	max = Math.max,
	abs = Math.abs,
	round = Math.round,
	rhorizontal = /left|center|right/,
	rvertical = /top|center|bottom/,
	roffset = /[\+\-]\d+(\.[\d]+)?%?/,
	rposition = /^\w+/,
	rpercent = /%$/,
	_position = $.fn.position;

function getOffsets( offsets, width, height ) {
	return [
		parseFloat( offsets[ 0 ] ) * ( rpercent.test( offsets[ 0 ] ) ? width / 100 : 1 ),
		parseFloat( offsets[ 1 ] ) * ( rpercent.test( offsets[ 1 ] ) ? height / 100 : 1 )
	];
}

function parseCss( element, property ) {
	return parseInt( $.css( element, property ), 10 ) || 0;
}

function isWindow( obj ) {
	return obj != null && obj === obj.window;
}

function getDimensions( elem ) {
	var raw = elem[0];
	if ( raw.nodeType === 9 ) {
		return {
			width: elem.width(),
			height: elem.height(),
			offset: { top: 0, left: 0 }
		};
	}
	if ( isWindow( raw ) ) {
		return {
			width: elem.width(),
			height: elem.height(),
			offset: { top: elem.scrollTop(), left: elem.scrollLeft() }
		};
	}
	if ( raw.preventDefault ) {
		return {
			width: 0,
			height: 0,
			offset: { top: raw.pageY, left: raw.pageX }
		};
	}
	return {
		width: elem.outerWidth(),
		height: elem.outerHeight(),
		offset: elem.offset()
	};
}

$.position = {
	scrollbarWidth: function() {
		if ( cachedScrollbarWidth !== undefined ) {
			return cachedScrollbarWidth;
		}
		var w1, w2,
			div = $( "<div style='display:block;position:absolute;width:50px;height:50px;overflow:hidden;'><div style='height:100px;width:auto;'></div></div>" ),
			innerDiv = div.children()[0];

		$( "body" ).append( div );
		w1 = innerDiv.offsetWidth;
		div.css( "overflow", "scroll" );

		w2 = innerDiv.offsetWidth;

		if ( w1 === w2 ) {
			w2 = div[0].clientWidth;
		}

		div.remove();

		return (cachedScrollbarWidth = w1 - w2);
	},
	getScrollInfo: function( within ) {
		var overflowX = within.isWindow || within.isDocument ? "" :
				within.element.css( "overflow-x" ),
			overflowY = within.isWindow || within.isDocument ? "" :
				within.element.css( "overflow-y" ),
			hasOverflowX = overflowX === "scroll" ||
				( overflowX === "auto" && within.width < within.element[0].scrollWidth ),
			hasOverflowY = overflowY === "scroll" ||
				( overflowY === "auto" && within.height < within.element[0].scrollHeight );
		return {
			width: hasOverflowY ? $.position.scrollbarWidth() : 0,
			height: hasOverflowX ? $.position.scrollbarWidth() : 0
		};
	},
	getWithinInfo: function( element ) {
		var withinElement = $( element || window ),
			isElemWindow = isWindow( withinElement[0] ),
			isDocument = !!withinElement[ 0 ] && withinElement[ 0 ].nodeType === 9,
			hasOffset = !isElemWindow && !isDocument;
		return {
			element: withinElement,
			isWindow: isElemWindow,
			isDocument: isDocument,
			offset: hasOffset ? $( element ).offset() : { left: 0, top: 0 },
			scrollLeft: withinElement.scrollLeft(),
			scrollTop: withinElement.scrollTop(),

			// support: jQuery 1.6.x
			// jQuery 1.6 doesn't support .outerWidth/Height() on documents or windows
			width: isElemWindow || isDocument ? withinElement.width() : withinElement.outerWidth(),
			height: isElemWindow || isDocument ? withinElement.height() : withinElement.outerHeight()
		};
	}
};

$.fn.position = function( options ) {
	if ( !options || !options.of ) {
		return _position.apply( this, arguments );
	}

	// make a copy, we don't want to modify arguments
	options = $.extend( {}, options );

	var atOffset, targetWidth, targetHeight, targetOffset, basePosition, dimensions,
		target = $( options.of ),
		within = $.position.getWithinInfo( options.within ),
		scrollInfo = $.position.getScrollInfo( within ),
		collision = ( options.collision || "flip" ).split( " " ),
		offsets = {},
		raw = target[0];

	dimensions = getDimensions( target );
	if ( target[0].preventDefault ) {
		// force left top to allow flipping
		options.at = "left top";
	}
	targetWidth = dimensions.width;
	targetHeight = dimensions.height;
	targetOffset = dimensions.offset;
	if (targetOffset.top + targetOffset.left === 0 && !target.is(":visible")) {
		targetOffset = $(raw.parentElement).offset();
		targetWidth = $(raw.parentElement).width();
	}

	// clone to reuse original targetOffset later
	basePosition = $.extend( {}, targetOffset );

	// force my and at to have valid horizontal and vertical positions
	// if a value is missing or invalid, it will be converted to center
	$.each( [ "my", "at" ], function() {
		var pos = ( options[ this ] || "" ).split( " " ),
			horizontalOffset,
			verticalOffset;

		if ( pos.length === 1) {
			pos = rhorizontal.test( pos[ 0 ] ) ?
				pos.concat( [ "center" ] ) :
				rvertical.test( pos[ 0 ] ) ?
					[ "center" ].concat( pos ) :
					[ "center", "center" ];
		}
		pos[ 0 ] = rhorizontal.test( pos[ 0 ] ) ? pos[ 0 ] : "center";
		pos[ 1 ] = rvertical.test( pos[ 1 ] ) ? pos[ 1 ] : "center";

		// calculate offsets
		horizontalOffset = roffset.exec( pos[ 0 ] );
		verticalOffset = roffset.exec( pos[ 1 ] );
		offsets[ this ] = [
			horizontalOffset ? horizontalOffset[ 0 ] : 0,
			verticalOffset ? verticalOffset[ 0 ] : 0
		];

		// reduce to just the positions without the offsets
		options[ this ] = [
			rposition.exec( pos[ 0 ] )[ 0 ],
			rposition.exec( pos[ 1 ] )[ 0 ]
		];
	});

	// normalize collision option
	if ( collision.length === 1 ) {
		collision[ 1 ] = collision[ 0 ];
	}

	if ( options.at[ 0 ] === "right" ) {
		basePosition.left += targetWidth;
	} else if ( options.at[ 0 ] === "center" ) {
		basePosition.left += targetWidth / 2;
	}

	if ( options.at[ 1 ] === "bottom" ) {
		basePosition.top += targetHeight;
	} else if ( options.at[ 1 ] === "center" ) {
		basePosition.top += targetHeight / 2;
	}

	atOffset = getOffsets( offsets.at, targetWidth, targetHeight );
	basePosition.left += atOffset[ 0 ];
	basePosition.top += atOffset[ 1 ];

	return this.each(function() {
		var collisionPosition, using,
			elem = $( this ),
			elemWidth = elem.outerWidth(),
			elemHeight = elem.outerHeight(),
			marginLeft = parseCss( this, "marginLeft" ),
			marginTop = parseCss( this, "marginTop" ),
			collisionWidth = elemWidth + marginLeft + parseCss( this, "marginRight" ) + scrollInfo.width,
			collisionHeight = elemHeight + marginTop + parseCss( this, "marginBottom" ) + scrollInfo.height,
			position = $.extend( {}, basePosition ),
			myOffset = getOffsets( offsets.my, elem.outerWidth(), elem.outerHeight() );

		if ( options.my[ 0 ] === "right" ) {
			position.left -= elemWidth;
		} else if ( options.my[ 0 ] === "center" ) {
			position.left -= elemWidth / 2;
		}

		if ( options.my[ 1 ] === "bottom" ) {
			position.top -= elemHeight;
		} else if ( options.my[ 1 ] === "center" ) {
			position.top -= elemHeight / 2;
		}

		position.left += myOffset[ 0 ];
		position.top += myOffset[ 1 ];

		// if the browser doesn't support fractions, then round for consistent results
		if ( !supportsOffsetFractions ) {
			position.left = round( position.left );
			position.top = round( position.top );
		}

		collisionPosition = {
			marginLeft: marginLeft,
			marginTop: marginTop
		};

		$.each( [ "left", "top" ], function( i, dir ) {
			if ( $.ui.position[ collision[ i ] ] ) {
				$.ui.position[ collision[ i ] ][ dir ]( position, {
					targetWidth: targetWidth,
					targetHeight: targetHeight,
					elemWidth: elemWidth,
					elemHeight: elemHeight,
					collisionPosition: collisionPosition,
					collisionWidth: collisionWidth,
					collisionHeight: collisionHeight,
					offset: [ atOffset[ 0 ] + myOffset[ 0 ], atOffset [ 1 ] + myOffset[ 1 ] ],
					my: options.my,
					at: options.at,
					within: within,
					elem: elem
				});
			}
		});

		if ( options.using ) {
			// adds feedback as second argument to using callback, if present
			using = function( props ) {
				var left = targetOffset.left - position.left,
					right = left + targetWidth - elemWidth,
					top = targetOffset.top - position.top,
					bottom = top + targetHeight - elemHeight,
					feedback = {
						target: {
							element: target,
							left: targetOffset.left,
							top: targetOffset.top,
							width: targetWidth,
							height: targetHeight
						},
						element: {
							element: elem,
							left: position.left,
							top: position.top,
							width: elemWidth,
							height: elemHeight
						},
						horizontal: right < 0 ? "left" : left > 0 ? "right" : "center",
						vertical: bottom < 0 ? "top" : top > 0 ? "bottom" : "middle"
					};
				if ( targetWidth < elemWidth && abs( left + right ) < targetWidth ) {
					feedback.horizontal = "center";
				}
				if ( targetHeight < elemHeight && abs( top + bottom ) < targetHeight ) {
					feedback.vertical = "middle";
				}
				if ( max( abs( left ), abs( right ) ) > max( abs( top ), abs( bottom ) ) ) {
					feedback.important = "horizontal";
				} else {
					feedback.important = "vertical";
				}
				options.using.call( this, props, feedback );
			};
		}

		elem.offset( $.extend( position, { using: using } ) );
	});
};

$.ui.position = {
	fit: {
		left: function( position, data ) {
			var within = data.within,
				withinOffset = within.isWindow ? within.scrollLeft : within.offset.left,
				outerWidth = within.width,
				collisionPosLeft = position.left - data.collisionPosition.marginLeft,
				overLeft = withinOffset - collisionPosLeft,
				overRight = collisionPosLeft + data.collisionWidth - outerWidth - withinOffset,
				newOverRight;

			// element is wider than within
			if ( data.collisionWidth > outerWidth ) {
				// element is initially over the left side of within
				if ( overLeft > 0 && overRight <= 0 ) {
					newOverRight = position.left + overLeft + data.collisionWidth - outerWidth - withinOffset;
					position.left += overLeft - newOverRight;
				// element is initially over right side of within
				} else if ( overRight > 0 && overLeft <= 0 ) {
					position.left = withinOffset;
				// element is initially over both left and right sides of within
				} else {
					if ( overLeft > overRight ) {
						position.left = withinOffset + outerWidth - data.collisionWidth;
					} else {
						position.left = withinOffset;
					}
				}
			// too far left -> align with left edge
			} else if ( overLeft > 0 ) {
				position.left += overLeft;
			// too far right -> align with right edge
			} else if ( overRight > 0 ) {
				position.left -= overRight;
			// adjust based on position and margin
			} else {
				position.left = max( position.left - collisionPosLeft, position.left );
			}
		},
		top: function( position, data ) {
			var within = data.within,
				withinOffset = within.isWindow ? within.scrollTop : within.offset.top,
				outerHeight = data.within.height,
				collisionPosTop = position.top - data.collisionPosition.marginTop,
				overTop = withinOffset - collisionPosTop,
				overBottom = collisionPosTop + data.collisionHeight - outerHeight - withinOffset,
				newOverBottom;

			// element is taller than within
			if ( data.collisionHeight > outerHeight ) {
				// element is initially over the top of within
				if ( overTop > 0 && overBottom <= 0 ) {
					newOverBottom = position.top + overTop + data.collisionHeight - outerHeight - withinOffset;
					position.top += overTop - newOverBottom;
				// element is initially over bottom of within
				} else if ( overBottom > 0 && overTop <= 0 ) {
					position.top = withinOffset;
				// element is initially over both top and bottom of within
				} else {
					if ( overTop > overBottom ) {
						position.top = withinOffset + outerHeight - data.collisionHeight;
					} else {
						position.top = withinOffset;
					}
				}
			// too far up -> align with top
			} else if ( overTop > 0 ) {
				position.top += overTop;
			// too far down -> align with bottom edge
			} else if ( overBottom > 0 ) {
				position.top -= overBottom;
			// adjust based on position and margin
			} else {
				position.top = max( position.top - collisionPosTop, position.top );
			}
		}
	},
	flip: {
		left: function( position, data ) {
			var within = data.within,
				withinOffset = within.offset.left + within.scrollLeft,
				outerWidth = within.width,
				offsetLeft = within.isWindow ? within.scrollLeft : within.offset.left,
				collisionPosLeft = position.left - data.collisionPosition.marginLeft,
				overLeft = collisionPosLeft - offsetLeft,
				overRight = collisionPosLeft + data.collisionWidth - outerWidth - offsetLeft,
				myOffset = data.my[ 0 ] === "left" ?
					-data.elemWidth :
					data.my[ 0 ] === "right" ?
						data.elemWidth :
						0,
				atOffset = data.at[ 0 ] === "left" ?
					data.targetWidth :
					data.at[ 0 ] === "right" ?
						-data.targetWidth :
						0,
				offset = -2 * data.offset[ 0 ],
				newOverRight,
				newOverLeft;

			if ( overLeft < 0 ) {
				newOverRight = position.left + myOffset + atOffset + offset + data.collisionWidth - outerWidth - withinOffset;
				if ( newOverRight < 0 || newOverRight < abs( overLeft ) ) {
					position.left += myOffset + atOffset + offset;
				}
			} else if ( overRight > 0 ) {
				newOverLeft = position.left - data.collisionPosition.marginLeft + myOffset + atOffset + offset - offsetLeft;
				if ( newOverLeft > 0 || abs( newOverLeft ) < overRight ) {
					position.left += myOffset + atOffset + offset;
				}
			}
		},
		top: function( position, data ) {
			var within = data.within,
				withinOffset = within.offset.top + within.scrollTop,
				outerHeight = within.height,
				offsetTop = within.isWindow ? within.scrollTop : within.offset.top,
				collisionPosTop = position.top - data.collisionPosition.marginTop,
				overTop = collisionPosTop - offsetTop,
				overBottom = collisionPosTop + data.collisionHeight - outerHeight - offsetTop,
				top = data.my[ 1 ] === "top",
				myOffset = top ?
					-data.elemHeight :
					data.my[ 1 ] === "bottom" ?
						data.elemHeight :
						0,
				atOffset = data.at[ 1 ] === "top" ?
					data.targetHeight :
					data.at[ 1 ] === "bottom" ?
						-data.targetHeight :
						0,
				offset = -2 * data.offset[ 1 ],
				newOverTop,
				newOverBottom;
			if ( overTop < 0 ) {
				newOverBottom = position.top + myOffset + atOffset + offset + data.collisionHeight - outerHeight - withinOffset;
				if ( newOverBottom < 0 || newOverBottom < abs( overTop ) ) {
					position.top += myOffset + atOffset + offset;
				}
			} else if ( overBottom > 0 ) {
				newOverTop = position.top - data.collisionPosition.marginTop + myOffset + atOffset + offset - offsetTop;
				if ( newOverTop > 0 || abs( newOverTop ) < overBottom ) {
					position.top += myOffset + atOffset + offset;
				}
			}
		}
	},
	flipfit: {
		left: function() {
			$.ui.position.flip.left.apply( this, arguments );
			$.ui.position.fit.left.apply( this, arguments );
		},
		top: function() {
			$.ui.position.flip.top.apply( this, arguments );
			$.ui.position.fit.top.apply( this, arguments );
		}
	}
};

// fraction support test
(function() {
	var testElement, testElementParent, testElementStyle, offsetLeft, i,
		body = document.getElementsByTagName( "body" )[ 0 ],
		div = document.createElement( "div" );

	//Create a "fake body" for testing based on method used in jQuery.support
	testElement = document.createElement( body ? "div" : "body" );
	testElementStyle = {
		visibility: "hidden",
		width: 0,
		height: 0,
		border: 0,
		margin: 0,
		background: "none"
	};
	if ( body ) {
		$.extend( testElementStyle, {
			position: "absolute",
			left: "-1000px",
			top: "-1000px"
		});
	}
	for ( i in testElementStyle ) {
		testElement.style[ i ] = testElementStyle[ i ];
	}
	testElement.appendChild( div );
	testElementParent = body || document.documentElement;
	testElementParent.insertBefore( testElement, testElementParent.firstChild );

	div.style.cssText = "position: absolute; left: 10.7432222px;";

	offsetLeft = $( div ).offset().left;
	supportsOffsetFractions = offsetLeft > 10 && offsetLeft < 11;

	testElement.innerHTML = "";
	testElementParent.removeChild( testElement );
})();

})();

var position = $.ui.position;



}));
/* END OF FILE - ..\GenCommon\js\jquery-ui.js - */
