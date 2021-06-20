function HistoryManager()
{
	this.start = function(){
		if (gx.grid.drawAtServer)
			return;
		HistoryManager.Initialize(this);
		this.UpdateProperties();
	};
	
	this.destroy = function(){
		if (gx.grid.drawAtServer)
			return;
		HistoryManager.RemoveListener(this);
	};
	
	this.urlListener = function(){
		if (gx.grid.drawAtServer)
			return;
		if (gx.spa.isNavigating()) {
			gx.spa.addObserver('onnavigatecomplete', this, this.fireUrlChanged, { single: true });
		}
		else {
			this.fireUrlChanged();
		}
	};

	this.fireUrlChanged = function () {
		if (this.URLChanged){
			this.UpdateProperties();
			this.URLChanged();
		}
	};

	this.getId = function(){
		return (this.ParentObject ? this.ParentObject.CmpContext || "" + "-" + this.ParentObject.ServerClass || "" : "") + "-" + this.ControlName;
	};

	this.AddHistoryPoint = function(pointId, fireUrlChangedEvent){
		if (gx.grid.drawAtServer)
			return;
		HistoryManager.AddHistoryPoint(pointId, !(fireUrlChangedEvent === true));
	};
	
	this.UpdateProperties = function(){
		if (gx.grid.drawAtServer)
			return;
		this.Hash = (document.location.hash.length > 0) ? document.location.hash.substr(1) : "";
		this.URL = document.location.href;
		this.QueryString = (document.location.search.length > 0) ? document.location.search.substr(1) : "";
	};
}

HistoryManager.listeners = {};

HistoryManager.listenerFn = function(){
	if (gx.grid.drawAtServer)
		return;
	for (var listener in HistoryManager.listeners){
		var fn = HistoryManager.listeners[listener];
		if (fn){
			fn();
		}
	}
};

HistoryManager.Initialize = function (uc) {
	if (window.dhtmlHistory.isSupported){
		if (!HistoryManager.m_initialized){
			HistoryManager.m_initialized = true;
			if (!window.dhtmlHistory.isCreated)
				dhtmlHistoryCreate();
			window.dhtmlHistory.initialize();
			gx.fx.obs.addObserver('gx.onunload', HistoryManager, HistoryManager.Destroy);
			window.dhtmlHistory.addListener(HistoryManager.listenerFn);
		}
	
		if (!uc.IsPostBack){
			HistoryManager.AddListener(uc);
			if (document.location.hash != ""){
				gx.evt.on_ready(uc, function(){
					setTimeout(function () {
						window.dhtmlHistory.checkLocation();
						window.dhtmlHistory.fireHistoryEvent(document.location.hash);
					}, 10);
				});
			}
		}
	}
};

HistoryManager.Destroy = function () {
	window.dhtmlHistory.destroy();
	HistoryManager.m_initialized = false;
	delete gx.spa.ignoreClick;
};

HistoryManager.AddListener = function(inst){
	if (gx.grid.drawAtServer)
		return;
	HistoryManager.listeners[inst.getId()] = function(){
		HistoryManager.PushReferer(window.location.hash);
		inst.urlListener();
	};
};

HistoryManager.PushReferer = function(anchor) {
	var curLoc,
		url,
		anchor = anchor ? '#' + anchor.replace('#','') : '';
	if (gx.ajax && typeof(gx.ajax.pushReferer) == 'function') {
		curLoc = window.location.toString();
		url = (curLoc.indexOf('#') >= 0) ? curLoc.replace(/#.*$/, anchor) : curLoc + anchor;
		gx.ajax.pushReferer(gx.popup.popuplvl(), url);
	}
};

HistoryManager.RemoveListener = function(inst){
	if (gx.grid.drawAtServer)
		return;
	delete HistoryManager.listeners[inst.getId()];
};

HistoryManager.AddHistoryPoint = function(anchor, avoidURLChangedEvent, event, ignoreClick){
	if (gx.grid.drawAtServer)
		return;
	if (event)
		event.stopPropagation();		
	else {
		if (gx.spa && ignoreClick !== false)
			gx.spa.ignoreClick = true;
	}
		
	// anchor: History point identifier
	// avoidURLChangedEvent: Set to true if you want to avoid fireing the URLChanged event with the hash change. Set to false if you want to fire the URLChanged event.
	if (window.dhtmlHistory.isSupported){
		if (avoidURLChangedEvent) {
			window.dhtmlHistory.add(anchor);
			HistoryManager.PushReferer(anchor);
		}
		else{
			if (window.dhtmlHistory.isIE){
				window.dhtmlHistory.ignoreLocationChange = true; // Set to true to avoid fireing the URLChanged event twice in IE.
			}
			document.location.hash = "#" + anchor;
		}

		return false;
	}
	else
		return true;
};