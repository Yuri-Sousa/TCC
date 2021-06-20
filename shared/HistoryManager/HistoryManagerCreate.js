function dhtmlHistoryCreate() {
	window.dhtmlHistory.create({
		debugMode: false,
		toJSON: function(o) {
			return rshJSON.stringify(o);
		},
		fromJSON: function(s) {
			return rshJSON.parse(s);
		},
		blankPagePath: gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "shared/HistoryManager/rsh/", true)
	});
}
dhtmlHistoryCreate();