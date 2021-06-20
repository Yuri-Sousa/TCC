var fnc = function() {
	
gx.printing.useGXPrintServer = true;
gx.printing.showConnectErrors = true;
gx.printing.serviceUrl = 'http://localhost:8000/print';

gx.printing.makeCorsRequest = function(data) {
	
	var createCORSRequest = function(method, url) {
		var xhr = new XMLHttpRequest();
		if ("withCredentials" in xhr) {
			// Chrome/Firefox/Opera/Safari.
			xhr.open(method, url, true);
		} else if (typeof XDomainRequest != "undefined") {
			// IE.
			xhr = new XDomainRequest();
			xhr.open(method, url);
		} else {
			xhr = null;
		}
		return xhr;
	};
	
	var url = gx.printing.serviceUrl;

	var xhr = createCORSRequest('POST', url);
	if (!xhr) {
		gx.dbg.logMsg('gx.printing.makeCorsRequest CORS not supported ' + url);
		return;
	}

	xhr.onload = function() {
		var text = xhr.responseText;
	};

	xhr.onerror = function() {
		var fnc = function(msg) {
			if (gx.printing.showConnectErrors === true) {
				if (gx.util.alert && typeof gx.util.alert.showError == 'function') {
					gx.util.alert.showError(msg)
				}
				else {
					alert( msg);
				}
			}
		}
		fnc(gx.getMessage("GXM_NetworkError").replace('%1', url));
		gx.dbg.logMsg('gx.printing.makeCorsRequest Error calling at ' + url);
	};
	xhr.send(gx.json.serializeJson(data));
};

gx.printing.print = function (printInfo) {
    if (printInfo)
		this.printDirect(printInfo);
};

gx.printing.printDirect = function(printInfo) {
	if (gx.printing.useGXPrintServer) {
		printInfo.baseURL = location.origin + '/' + gx.basePath + gx.staticDirectory;
		gx.printing.makeCorsRequest(printInfo);				
	}
	else {
		var IFrameControl = gx.dom.byId(gx.printing.IFrameId);
		if (!IFrameControl) {
			IFrameControl = document.createElement('IFRAME');
			IFrameControl.id = gx.printing.IFrameId;
			IFrameControl.style.visibility = 'hidden';
			document.body.appendChild(IFrameControl);
		}
		IFrameControl.src = printInfo.reportFile;
		IFrameControl.onload = function() {
			this.contentWindow.print();
			var self = this;
			var cleanup = function () {
				self.onload = null;
				self.src = '';
			};
			setTimeout(cleanup, 2000);
		}
	}
};
};

document.addEventListener("DOMContentLoaded", fnc);
