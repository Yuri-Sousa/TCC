/* START OF FILE - ..\QueryViewerRender.src.js - */
//Highcharts Version 6.0.2
//Pivot JS Version 1.2.5.9

function QueryViewer() {
	this.enableServerDebug = false;
	this.oat_element = "";
	this.IsExternalQuery = false;
	this.ExternalQueryResult = "[]";
	this.ServerPagingForTable = true;
	this.ServerPagingForPivotTable = true;
	this.UseRecordsetCache = true;
	this.MaximumCacheSize = 100;
	this.MinutesToKeepInRecordsetCache = 5;
	this.ReturnSampleData = false;

	// ------------------------------------------------- Set/Get methods --------------------------------------------------

	this.SetDragAndDropData = function (data) {
		this.DragAndDropData = data;
	}

	this.GetDragAndDropData = function () {
		return this.DragAndDropData;
	}

	this.SetItemExpandData = function (data) {
		this.ItemExpandData = data;
	}

	this.GetItemExpandData = function () {
		return this.ItemExpandData;
	}

	this.SetItemCollapseData = function (data) {
		this.ItemCollapseData = data;
	}

	this.GetItemCollapseData = function () {
		return this.ItemCollapseData;
	}

	this.SetFilterChangedData = function (data) {
		this.FilterChangedData = data;
	}

	this.GetFilterChangedData = function () {
		return this.FilterChangedData;
	}

	this.SetItemClickData = function (data) {
		this.ItemClickData = data;
	}

	this.GetItemClickData = function () {
		return this.ItemClickData;
	}

	this.SetItemDoubleClickData = function (data) {
		this.ItemDoubleClickData = data;
	}

	this.GetItemDoubleClickData = function () {
		return this.ItemDoubleClickData;
	}

	this.SetParameters = function (data) {
		this.Parameters = data;
	}

	this.GetParameters = function () {
		return this.Parameters;
	}

	this.SetAxes = function (data) {
		this.Axes = data;
	}

	this.GetAxes = function () {
		return this.Axes;
	}

	// ---------------------------------------------------Other Methods ---------------------------------------------------

	this.show = function () {
		if (!gx.lang.gxBoolean(this.AvoidAutomaticShow) || gx.lang.gxBoolean(this.ExecuteShow)) {	// Used only in GXquery to avoid Show() function execution
			if (gx.lang.gxBoolean(this.Visible)) {
				this.getContainerControl().style.display = "";
				qv.collection[this.userControlId()] = this;
				this._isAutorefresh = false;
				this.realShow();
			}
			else
				this.getContainerControl().style.display = "none";
		}
		if (gx.lang.gxBoolean(this.AvoidAutomaticShow))
			this.ExecuteShow = false;
	}

	this.GetMetadata = function () {
		switch (this.RealType) {
			case QueryViewerOutputType.Card:
				return qv.card.GetMetadataCard(this);
			case QueryViewerOutputType.Chart:
				return qv.chart.GetMetadataChart(this);
			default:
				return qv.pivot.GetMetadataPivot(this);
		}
	}

	this.GetData = function () {
		switch (this.RealType) {
			case QueryViewerOutputType.Card:
				return qv.card.GetDataCard(this);
			case QueryViewerOutputType.Chart:
				return qv.chart.GetDataChart(this);
			default:
				return qv.pivot.GetDataPivot(this);
		}
	}

	this.GetFilteredData = function () {
		switch (this.RealType) {
			case QueryViewerOutputType.Card:
				return qv.card.GetDataCard(this);		// en las Cards coincide el GetData con el GetFilteredData
			case QueryViewerOutputType.Chart:
				return qv.chart.GetDataChart(this);		// en las Charts coincide el GetData con el GetFilteredData
			default:
				return qv.pivot.GetFilteredDataPivot(this);
		}
	}

	this.NotifyMetadata = function () {
		var metadata = this.GetMetadata();
		qv.util.ExecuteTracker("CollQueryViewerElements.Element", metadata);
	}

	this.NotifyData = function () {
		var data = this.GetData();
		var sdtdata = {};
		sdtdata.XmlData = data;
		qv.util.ExecuteTracker("QueryViewerData", sdtdata);
	}

	this.NotifyFilteredData = function () {
		var data = this.GetFilteredData();
		var sdtdata = {};
		sdtdata.XmlData = data;
		qv.util.ExecuteTracker("QueryViewerFilteredData", sdtdata);
	}

	this.NextPage = function () {
		this.oat_element.moveToNextPage()
	}

	this.FirstPage = function () {
		this.oat_element.moveToFirstPage()
	}

	this.PreviousPage = function () {
		this.oat_element.moveToPreviousPage()
	}

	this.LastPage = function () {
		this.oat_element.moveToLastPage()
	}
	
	this.Select = function (selection) {
		if (this.SelectionAllowed()) {
			var validAxes = 0;
			for (var i = 0; i < selection.length; i++) {
				var axis = this.GetAxisByName(selection[i].Name);
				if (axis != null) {
					selection[i].DataField = axis.DataField;
					validAxes += 1;
				}
				else
					if (selection[i].DataField)
						delete selection[i].DataField;
			}
			if (validAxes > 0)
				switch (this.RealType) {
					case QueryViewerOutputType.Chart:
						qv.chart.Select(this, selection);
						break;
					case QueryViewerOutputType.Table:
					case QueryViewerOutputType.PivotTable:
						qv.pivot.Select(this, selection);
						break;
				}
			else
				switch (this.RealType) {
					case QueryViewerOutputType.Chart:
						qv.chart.Deselect(this);
						break;
					case QueryViewerOutputType.Table:
					case QueryViewerOutputType.PivotTable:
						qv.pivot.Deselect(this);
						break;
				}
		}
	}

	// ------------------------------------------------------ Private ------------------------------------------------------

	this.CanRefreshControl = function () {
		return this._ControlRenderedTo == this.RealType;
	}

	this.IsAutoResize = function () {
		if (this.RealType == QueryViewerOutputType.Chart)
			return false;
		else
			return gx.lang.gxBoolean(this.AutoResize);
	}

	this.SetContainerSize = function (container) {
		if (!this.IsAutoResize()) {
			if (this.Width != "")
				container.style.width = gx.dom.addUnits(this.Width);
			if (this.Height != "")
				container.style.height = gx.dom.addUnits(this.Height);
		}
		else {
			switch (this.AutoResizeType) {
				case QueryViewerAutoresizeType.Both:
					// do nothing
					break;
				case QueryViewerAutoresizeType.Vertical:
					if (!gx.util.browser.isIE() && this.Width != "")
						container.style.width = gx.dom.addUnits(this.Width);
					break;
				case QueryViewerAutoresizeType.Horizontal:
					if (this.Height != "")
						container.style.height = gx.dom.addUnits(this.Height);
					break;
			}
		}
		if (!this.IsAutoResize() || (this.IsAutoResize() && this.AutoResizeType == QueryViewerAutoresizeType.Vertical && !gx.util.browser.isIE()))
			container.style.overflow = 'auto';
	}

	this.realShow = function () {
		if (!gx.lang.gxBoolean(this.IsExternalQuery)) {
			qv.util.showActivityIndicator(this);
		}
		this.FixSDTReferences();
		this.calculateRealOutputType((function () {
			var container = document.getElementById(this.ContainerName);
			this.SetContainerSize(container);
			if (!this.CanRefreshControl()) {
				container = qv.util.dom.getEmptyContainer(this);
				qv.util.dom.createDiv(container, this.userControlId(), "", "", { width: gx.dom.addUnits(this.Width), height: gx.dom.addUnits(this.Height) }, "");
			}
			if (gx.lang.gxBoolean(this.RememberLayout) && !this._isAutorefresh && this.AutoRefreshGroup != "")
				qv.util.autorefresh.LoadAxesAndParametersState(this);
			if (this.RealType == QueryViewerOutputType.Table || this.RealType == QueryViewerOutputType.PivotTable)
				qv.pivot.tryToRenderPivotTable(this);
			else if (this.RealType == QueryViewerOutputType.Card)
				qv.card.tryToRenderCard(this);
			else
				qv.chart.tryToRenderChart(this);
		}).closure(this));
	}

	this.FixSDTReferences = function() {
	
		function isNotNullObject(obj) {
			return typeof obj === 'object' && obj != null;
		}
		
		if (!Array.isArray(this.Axes))
			this.Axes = [];
		if (!Array.isArray(this.Parameters))
			this.Parameters = [];
		if (!isNotNullObject(this.ItemClickData))
			this.ItemClickData = {};
		if (!isNotNullObject(this.ItemDoubleClickData))
			this.ItemDoubleClickData = {};
		if (!isNotNullObject(this.ItemExpandData))
			this.ItemExpandData = {};
		if (!isNotNullObject(this.ItemCollapseData))
			this.ItemCollapseData = {};
		if (!isNotNullObject(this.DragAndDropData))
			this.DragAndDropData = {};			
		if (!isNotNullObject(this.FilterChangedData))
			this.FilterChangedData = {};			
	}
	
	this.calculateRealOutputType = function (callback) {
		if (this.Type == QueryViewerOutputType.Default) {
			this.getDefaultOutput((function (output, qViewer) {
				if (output != QueryViewerOutputType.Table && output != QueryViewerOutputType.PivotTable && output != QueryViewerOutputType.Card) {
					qViewer.RealType = QueryViewerOutputType.Chart;
					qViewer.RealChartType = output;
				} else
					qViewer.RealType = output;
				callback();
			}).closure(this));
		}
		else {
			if ((this.Type != undefined) && (this.Type != ""))
				this.RealType = this.Type;
			else
				this.RealType = QueryViewerOutputType.Table;
			if ((this.ChartType != undefined) && (this.ChartType != ""))
				this.RealChartType = this.ChartType;
			else
				this.RealChartType = "";
			callback();
		}
	}

	this.userControlId = function () {
		return this.ContainerName.replace("Container", "") + "_" + this.ControlName; // Nombre único y diferente al contenedor
	}

	this.ExternalQueryResultObj = function () {
		if (this._ExternalQueryResultObj == undefined || this.ExternalQueryResult != this._LastExternalQueryResult) {
			this._ExternalQueryResultObj = eval('(' + this.ExternalQueryResult + ')');
			this._LastExternalQueryResult = this.ExternalQueryResult;
		}
		return this._ExternalQueryResultObj;
	}

	this.GetAxisByName = function (name) {
		for (var i = 0; i < this.Metadata.Axes.length; i++)
			if (this.Metadata.Axes[i].Name == name)
				return this.Metadata.Axes[i];
		return null;
	}

	this.SelectionAllowed = function() {
		return gx.lang.gxBoolean(this.AllowSelection) && this.RealType != QueryViewerOutputType.Card && !(this.RealType == QueryViewerOutputType.Chart && (this.RealChartType == QueryViewerChartType.CircularGauge || this.RealChartType == QueryViewerChartType.LinearGauge));	// Las gráficas gauge no tienen eje X
	}

	// Asynchronous Ajax Calls
	this.calculatePivottableData = qv.services.createAsyncServerCallFn(this, qv.services.url.getDataURL, qv.services.postInfo.Data, "GetData");

	this.calculatePivottableMetadata = qv.services.createAsyncServerCallFn(this, qv.services.url.getMetadataURL, qv.services.postInfo.Metadata, "GetMetadata", qv.util.css.replaceCssClasses);

	this.getDefaultOutput = qv.services.createAsyncServerCallFn(this, qv.services.url.getDefaultOutputURL, qv.services.postInfo.DefaultOutput, "GetDefaultOutput");

	this.getQueryParameters = qv.services.createAsyncServerCallFn(this, qv.services.url.getQueryParametersURL, qv.services.postInfo.getQueryParameters, "GetQueryParameters");

	this.getAttributeValues = qv.services.createAsyncServerCallFn(this, qv.services.url.getAttributeValuesURL, qv.services.postInfo.AttributeValues, "GetAttributeValues");

	this.getPageDataForTable = qv.services.createAsyncServerCallFn(this, qv.services.url.getPageDataForTableURL, qv.services.postInfo.TablePageData, "GetPageDataForTable");

	this.getPageDataForPivotTable = qv.services.createAsyncServerCallFn(this, qv.services.url.getPageDataForPivotTableURL, qv.services.postInfo.PivotTablePageData, "GetPageDataForPivotTable");

	this.getRecordsetCacheKey = qv.services.createAsyncServerCallFn(this, qv.services.url.getRecordsetCacheKeyURL, qv.services.postInfo.RecordsetCacheKey, "GetRecordsetCacheKey");

	// Synchronous Ajax Calls
	this.getPivottableDataSync = function () { return qv.services.CallServerSync(this, qv.services.url.getDataURL, qv.services.postInfo.Data) };

	this.getAttributeValuesSync = function (postInfoParms) { return qv.services.CallServerSync(this, qv.services.url.getAttributeValuesURL, qv.services.postInfo.AttributeValues, postInfoParms) };

	this.getPageDataForTableSync = function (postInfoParms) { return qv.services.CallServerSync(this, qv.services.url.getPageDataForTableURL, qv.services.postInfo.TablePageData, postInfoParms) };


}
/* END OF FILE - ..\QueryViewerRender.src.js - */
