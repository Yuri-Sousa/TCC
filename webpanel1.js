gx.evt.autoSkip=!1;gx.define("webpanel1",!1,function(){var r,o,s,h,n,u,t,f,i,e;this.ServerClass="webpanel1";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e132y2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e142y2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];r=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,16,18,20,22,25,26,27,29,30,33,34,35];this.GXLastCtrlId=35;this.UCPROGRESS1Container=gx.uc.getNew(this,15,0,"DVProgressIndicator","UCPROGRESS1Container","Ucprogress1","UCPROGRESS1");o=this.UCPROGRESS1Container;o.setProp("Class","Class","","char");o.setProp("Enabled","Enabled",!0,"boolean");o.setProp("Type","Type","Circle","str");o.setProp("CircleCaptionType","Circlecaptiontype","CaptionAndSubtitle","str");o.setProp("Caption","Caption","3,154","str");o.setProp("Subtitle","Subtitle","Applications","str");o.setProp("RawHTML","Rawhtml","","char");o.setProp("Cls","Cls","ProgressBigCircleBaseColor","str");o.setProp("Percentage","Percentage",20,"num");o.setProp("BarWidth","Barwidth","","char");o.setProp("CircleWidth","Circlewidth",180,"num");o.setProp("CircleProgressWidth","Circleprogresswidth",8,"num");o.setProp("AnimateOnStart","Animateonstart",!0,"bool");o.setProp("Visible","Visible",!0,"bool");o.setProp("Gx Control Type","Gxcontroltype","","int");o.setC2ShowFunction(function(n){n.show()});this.setUserControl(o);this.UCPROGRESS2Container=gx.uc.getNew(this,17,0,"DVProgressIndicator","UCPROGRESS2Container","Ucprogress2","UCPROGRESS2");s=this.UCPROGRESS2Container;s.setProp("Class","Class","","char");s.setProp("Enabled","Enabled",!0,"boolean");s.setProp("Type","Type","Circle","str");s.setProp("CircleCaptionType","Circlecaptiontype","CaptionAndSubtitle","str");s.setProp("Caption","Caption","1,546","str");s.setProp("Subtitle","Subtitle","New Issues","str");s.setProp("RawHTML","Rawhtml","","char");s.setProp("Cls","Cls","ProgressBigCircleBaseColor","str");s.setProp("Percentage","Percentage",60,"num");s.setProp("BarWidth","Barwidth","","char");s.setProp("CircleWidth","Circlewidth",180,"num");s.setProp("CircleProgressWidth","Circleprogresswidth",8,"num");s.setProp("AnimateOnStart","Animateonstart",!0,"bool");s.setProp("Visible","Visible",!0,"bool");s.setProp("Gx Control Type","Gxcontroltype","","int");s.setC2ShowFunction(function(n){n.show()});this.setUserControl(s);this.UCPROGRESS3Container=gx.uc.getNew(this,19,0,"DVProgressIndicator","UCPROGRESS3Container","Ucprogress3","UCPROGRESS3");h=this.UCPROGRESS3Container;h.setProp("Class","Class","","char");h.setProp("Enabled","Enabled",!0,"boolean");h.setProp("Type","Type","Circle","str");h.setProp("CircleCaptionType","Circlecaptiontype","CaptionAndSubtitle","str");h.setProp("Caption","Caption","912","str");h.setProp("Subtitle","Subtitle","Active Customers","str");h.setProp("RawHTML","Rawhtml","","char");h.setProp("Cls","Cls","ProgressBigCircleBaseColor","str");h.setProp("Percentage","Percentage",40,"num");h.setProp("BarWidth","Barwidth","","char");h.setProp("CircleWidth","Circlewidth",180,"num");h.setProp("CircleProgressWidth","Circleprogresswidth",8,"num");h.setProp("AnimateOnStart","Animateonstart",!0,"bool");h.setProp("Visible","Visible",!0,"bool");h.setProp("Gx Control Type","Gxcontroltype","","int");h.setC2ShowFunction(function(n){n.show()});this.setUserControl(h);this.UTCHARTCOLUMNLINEContainer=gx.uc.getNew(this,21,0,"QueryViewer","UTCHARTCOLUMNLINEContainer","Utchartcolumnline","UTCHARTCOLUMNLINE");n=this.UTCHARTCOLUMNLINEContainer;n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("ObjectId","Objectid","0","str");n.setProp("ObjectType","Objecttype","","str");n.setProp("QueryInfo","Queryinfo","","char");n.setProp("IsExternalQuery","Isexternalquery",!1,"boolean");n.setProp("ExternalQueryResult","Externalqueryresult","","char");n.setProp("ObjectInfo","Objectinfo","","char");n.addV2CFunction("AV7Elements","vELEMENTS","SetAxes");n.addC2VFunction(function(n){n.ParentObject.AV7Elements=n.GetAxes();gx.fn.setControlValue("vELEMENTS",n.ParentObject.AV7Elements)});n.setProp("AllowElementsOrderChange","Allowchangeaxesorder",!1,"bool");n.addV2CFunction("AV8Parameters","vPARAMETERS","SetParameters");n.addC2VFunction(function(n){n.ParentObject.AV8Parameters=n.GetParameters();gx.fn.setControlValue("vPARAMETERS",n.ParentObject.AV8Parameters)});n.setProp("ObjectName","Objectname","","str");n.setProp("Object","Objectcall","","str");n.setProp("Class","Class","QueryViewerBar","str");n.setProp("ShrinkToFit","Shrinktofit",!1,"boolean");n.setProp("AutoResize","Autoresize",!1,"boolean");n.setProp("AutoResizeType","Autoresizetype","","char");n.setProp("Width","Width","100%","str");n.setProp("Height","Height","248px","str");n.setProp("Axes Selectors","Showaxesselectors","","char");n.setProp("FontFamily","Fontfamily","","char");n.setProp("FontSize","Fontsize","","int");n.setProp("FontColor","Fontcolor","","int");n.setProp("AutoRefreshGroup","Autorefreshgroup","","str");n.setProp("DisableColumnSort","Disablecolumnsort",!1,"boolean");n.setProp("AllowSelection","Allowselection",!1,"bool");n.setProp("RememberLayout","Rememberlayout",!0,"bool");n.setProp("ExportToXML","Exporttoxml",!1,"bool");n.setProp("ExportToHTML","Exporttohtml",!0,"bool");n.setProp("ExportToXLS","Exporttoxls",!1,"bool");n.setProp("ExportToXLSX","Exporttoxlsx",!0,"bool");n.setProp("ExportToPDF","Exporttopdf",!0,"bool");n.setProp("Type","Type","Chart","str");n.setProp("ShowDataAs","Showdataas","","char");n.setProp("Orientation","Orientation","","char");n.setProp("IncludeTrend","Includetrend",!1,"boolean");n.setProp("TrendPeriod","Trendperiod","","char");n.setProp("IncludeSparkline","Includesparkline",!1,"boolean");n.setProp("IncludeMaxAndMin","Includemaxandmin",!1,"boolean");n.setProp("ChartType","Charttype","ColumnLine","str");n.setProp("Title","Title","","str");n.setProp("PlotSeries","Plotseries","","str");n.setProp("ShowValues","Showvalues",!0,"bool");n.setProp("XAxisLabels","Xaxislabels","Horizontally","str");n.setProp("XAxisIntersectionAtZero","Xaxisintersectionatzero",!1,"bool");n.setProp("XAxisTitle","Xaxistitle","","str");n.setProp("YAxisTitle","Yaxistitle","","str");n.setProp("Paging","Paging",!1,"boolean");n.setProp("PageSize","Pagesize","","int");n.setProp("CurrentPage","Currentpage","","int");n.setProp("ShowDataLabelsIn","Showdatalabelsin","","char");n.addV2CFunction("AV9ItemClickData","vITEMCLICKDATA","SetItemClickData");n.addC2VFunction(function(n){n.ParentObject.AV9ItemClickData=n.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",n.ParentObject.AV9ItemClickData)});n.addV2CFunction("AV10ItemDoubleClickData","vITEMDOUBLECLICKDATA","SetItemDoubleClickData");n.addC2VFunction(function(n){n.ParentObject.AV10ItemDoubleClickData=n.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",n.ParentObject.AV10ItemDoubleClickData)});n.addV2CFunction("AV11DragAndDropData","vDRAGANDDROPDATA","SetDragAndDropData");n.addC2VFunction(function(n){n.ParentObject.AV11DragAndDropData=n.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",n.ParentObject.AV11DragAndDropData)});n.addV2CFunction("AV12FilterChangedData","vFILTERCHANGEDDATA","SetFilterChangedData");n.addC2VFunction(function(n){n.ParentObject.AV12FilterChangedData=n.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",n.ParentObject.AV12FilterChangedData)});n.addV2CFunction("AV13ItemExpandData","vITEMEXPANDDATA","SetItemExpandData");n.addC2VFunction(function(n){n.ParentObject.AV13ItemExpandData=n.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",n.ParentObject.AV13ItemExpandData)});n.addV2CFunction("AV14ItemCollapseData","vITEMCOLLAPSEDATA","SetItemCollapseData");n.addC2VFunction(function(n){n.ParentObject.AV14ItemCollapseData=n.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",n.ParentObject.AV14ItemCollapseData)});n.setProp("AppSettings","Appsettings","","char");n.setProp("AvoidAutomaticShow","Avoidautomaticshow",!1,"boolean");n.setProp("ExecuteShow","Executeshow",!1,"boolean");n.setProp("ServiceUrl","Serviceurl","","char");n.setProp("GenType","Gentype","","char");n.setProp("DesignRenderOutputType","Designrenderoutputtype","","char");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);this.DVPANEL_TABLECARDSContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLECARDSContainer","Dvpanel_tablecards","DVPANEL_TABLECARDS");u=this.DVPANEL_TABLECARDSContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","100%","str");u.setProp("Height","Height","100","str");u.setProp("AutoWidth","Autowidth",!1,"bool");u.setProp("AutoHeight","Autoheight",!0,"bool");u.setProp("Cls","Cls","PanelNoHeader","str");u.setProp("ShowHeader","Showheader",!0,"bool");u.setProp("Title","Title","","str");u.setProp("Collapsible","Collapsible",!1,"bool");u.setProp("Collapsed","Collapsed",!1,"bool");u.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");u.setProp("IconPosition","Iconposition","Right","str");u.setProp("AutoScroll","Autoscroll",!1,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.UTCHARTSMOOTHAREAContainer=gx.uc.getNew(this,28,0,"QueryViewer","UTCHARTSMOOTHAREAContainer","Utchartsmootharea","UTCHARTSMOOTHAREA");t=this.UTCHARTSMOOTHAREAContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("ObjectId","Objectid","0","str");t.setProp("ObjectType","Objecttype","","str");t.setProp("QueryInfo","Queryinfo","","char");t.setProp("IsExternalQuery","Isexternalquery",!1,"boolean");t.setProp("ExternalQueryResult","Externalqueryresult","","char");t.setProp("ObjectInfo","Objectinfo","","char");t.addV2CFunction("AV7Elements","vELEMENTS","SetAxes");t.addC2VFunction(function(n){n.ParentObject.AV7Elements=n.GetAxes();gx.fn.setControlValue("vELEMENTS",n.ParentObject.AV7Elements)});t.setProp("AllowElementsOrderChange","Allowchangeaxesorder",!1,"bool");t.addV2CFunction("AV8Parameters","vPARAMETERS","SetParameters");t.addC2VFunction(function(n){n.ParentObject.AV8Parameters=n.GetParameters();gx.fn.setControlValue("vPARAMETERS",n.ParentObject.AV8Parameters)});t.setProp("ObjectName","Objectname","","str");t.setProp("Object","Objectcall","","str");t.setProp("Class","Class","QueryViewer","str");t.setProp("ShrinkToFit","Shrinktofit",!1,"boolean");t.setProp("AutoResize","Autoresize",!1,"boolean");t.setProp("AutoResizeType","Autoresizetype","","char");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100%","str");t.setProp("Axes Selectors","Showaxesselectors","","char");t.setProp("FontFamily","Fontfamily","","char");t.setProp("FontSize","Fontsize","","int");t.setProp("FontColor","Fontcolor","","int");t.setProp("AutoRefreshGroup","Autorefreshgroup","","str");t.setProp("DisableColumnSort","Disablecolumnsort",!1,"boolean");t.setProp("AllowSelection","Allowselection",!1,"bool");t.setProp("RememberLayout","Rememberlayout",!0,"bool");t.setProp("ExportToXML","Exporttoxml",!1,"bool");t.setProp("ExportToHTML","Exporttohtml",!0,"bool");t.setProp("ExportToXLS","Exporttoxls",!1,"bool");t.setProp("ExportToXLSX","Exporttoxlsx",!0,"bool");t.setProp("ExportToPDF","Exporttopdf",!0,"bool");t.setProp("Type","Type","Chart","str");t.setProp("ShowDataAs","Showdataas","","char");t.setProp("Orientation","Orientation","","char");t.setProp("IncludeTrend","Includetrend",!1,"boolean");t.setProp("TrendPeriod","Trendperiod","","char");t.setProp("IncludeSparkline","Includesparkline",!1,"boolean");t.setProp("IncludeMaxAndMin","Includemaxandmin",!1,"boolean");t.setProp("ChartType","Charttype","StackedArea","str");t.setProp("Title","Title","","str");t.setProp("PlotSeries","Plotseries","InTheSameChart","str");t.setProp("ShowValues","Showvalues",!0,"bool");t.setProp("XAxisLabels","Xaxislabels","Horizontally","str");t.setProp("XAxisIntersectionAtZero","Xaxisintersectionatzero",!1,"bool");t.setProp("XAxisTitle","Xaxistitle","","str");t.setProp("YAxisTitle","Yaxistitle","","str");t.setProp("Paging","Paging",!1,"boolean");t.setProp("PageSize","Pagesize","","int");t.setProp("CurrentPage","Currentpage","","int");t.setProp("ShowDataLabelsIn","Showdatalabelsin","","char");t.addV2CFunction("AV9ItemClickData","vITEMCLICKDATA","SetItemClickData");t.addC2VFunction(function(n){n.ParentObject.AV9ItemClickData=n.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",n.ParentObject.AV9ItemClickData)});t.addV2CFunction("AV10ItemDoubleClickData","vITEMDOUBLECLICKDATA","SetItemDoubleClickData");t.addC2VFunction(function(n){n.ParentObject.AV10ItemDoubleClickData=n.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",n.ParentObject.AV10ItemDoubleClickData)});t.addV2CFunction("AV11DragAndDropData","vDRAGANDDROPDATA","SetDragAndDropData");t.addC2VFunction(function(n){n.ParentObject.AV11DragAndDropData=n.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",n.ParentObject.AV11DragAndDropData)});t.addV2CFunction("AV12FilterChangedData","vFILTERCHANGEDDATA","SetFilterChangedData");t.addC2VFunction(function(n){n.ParentObject.AV12FilterChangedData=n.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",n.ParentObject.AV12FilterChangedData)});t.addV2CFunction("AV13ItemExpandData","vITEMEXPANDDATA","SetItemExpandData");t.addC2VFunction(function(n){n.ParentObject.AV13ItemExpandData=n.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",n.ParentObject.AV13ItemExpandData)});t.addV2CFunction("AV14ItemCollapseData","vITEMCOLLAPSEDATA","SetItemCollapseData");t.addC2VFunction(function(n){n.ParentObject.AV14ItemCollapseData=n.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",n.ParentObject.AV14ItemCollapseData)});t.setProp("AppSettings","Appsettings","","char");t.setProp("AvoidAutomaticShow","Avoidautomaticshow",!1,"boolean");t.setProp("ExecuteShow","Executeshow",!1,"boolean");t.setProp("ServiceUrl","Serviceurl","","char");t.setProp("GenType","Gentype","","char");t.setProp("DesignRenderOutputType","Designrenderoutputtype","","char");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.DVPANEL_TABLECHART1Container=gx.uc.getNew(this,23,0,"BootstrapPanel","DVPANEL_TABLECHART1Container","Dvpanel_tablechart1","DVPANEL_TABLECHART1");f=this.DVPANEL_TABLECHART1Container;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","Sales Table","str");f.setProp("Collapsible","Collapsible",!1,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.UTCHARTSMOOTHLINEContainer=gx.uc.getNew(this,36,0,"QueryViewer","UTCHARTSMOOTHLINEContainer","Utchartsmoothline","UTCHARTSMOOTHLINE");i=this.UTCHARTSMOOTHLINEContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("ObjectId","Objectid","0","str");i.setProp("ObjectType","Objecttype","","str");i.setProp("QueryInfo","Queryinfo","","char");i.setProp("IsExternalQuery","Isexternalquery",!1,"boolean");i.setProp("ExternalQueryResult","Externalqueryresult","","char");i.setProp("ObjectInfo","Objectinfo","","char");i.addV2CFunction("AV7Elements","vELEMENTS","SetAxes");i.addC2VFunction(function(n){n.ParentObject.AV7Elements=n.GetAxes();gx.fn.setControlValue("vELEMENTS",n.ParentObject.AV7Elements)});i.setProp("AllowElementsOrderChange","Allowchangeaxesorder",!1,"bool");i.addV2CFunction("AV8Parameters","vPARAMETERS","SetParameters");i.addC2VFunction(function(n){n.ParentObject.AV8Parameters=n.GetParameters();gx.fn.setControlValue("vPARAMETERS",n.ParentObject.AV8Parameters)});i.setProp("ObjectName","Objectname","","str");i.setProp("Object","Objectcall","","str");i.setProp("Class","Class","QueryViewer","str");i.setProp("ShrinkToFit","Shrinktofit",!1,"boolean");i.setProp("AutoResize","Autoresize",!1,"boolean");i.setProp("AutoResizeType","Autoresizetype","","char");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","450px","str");i.setProp("Axes Selectors","Showaxesselectors","","char");i.setProp("FontFamily","Fontfamily","","char");i.setProp("FontSize","Fontsize","","int");i.setProp("FontColor","Fontcolor","","int");i.setProp("AutoRefreshGroup","Autorefreshgroup","","str");i.setProp("DisableColumnSort","Disablecolumnsort",!1,"boolean");i.setProp("AllowSelection","Allowselection",!1,"bool");i.setProp("RememberLayout","Rememberlayout",!0,"bool");i.setProp("ExportToXML","Exporttoxml",!1,"bool");i.setProp("ExportToHTML","Exporttohtml",!0,"bool");i.setProp("ExportToXLS","Exporttoxls",!1,"bool");i.setProp("ExportToXLSX","Exporttoxlsx",!0,"bool");i.setProp("ExportToPDF","Exporttopdf",!0,"bool");i.setProp("Type","Type","Chart","str");i.setProp("ShowDataAs","Showdataas","","char");i.setProp("Orientation","Orientation","","char");i.setProp("IncludeTrend","Includetrend",!1,"boolean");i.setProp("TrendPeriod","Trendperiod","","char");i.setProp("IncludeSparkline","Includesparkline",!1,"boolean");i.setProp("IncludeMaxAndMin","Includemaxandmin",!1,"boolean");i.setProp("ChartType","Charttype","SmoothLine","str");i.setProp("Title","Title","","str");i.setProp("PlotSeries","Plotseries","InTheSameChart","str");i.setProp("ShowValues","Showvalues",!0,"bool");i.setProp("XAxisLabels","Xaxislabels","Horizontally","str");i.setProp("XAxisIntersectionAtZero","Xaxisintersectionatzero",!1,"bool");i.setProp("XAxisTitle","Xaxistitle","","str");i.setProp("YAxisTitle","Yaxistitle","","str");i.setProp("Paging","Paging",!1,"boolean");i.setProp("PageSize","Pagesize","","int");i.setProp("CurrentPage","Currentpage","","int");i.setProp("ShowDataLabelsIn","Showdatalabelsin","","char");i.addV2CFunction("AV9ItemClickData","vITEMCLICKDATA","SetItemClickData");i.addC2VFunction(function(n){n.ParentObject.AV9ItemClickData=n.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",n.ParentObject.AV9ItemClickData)});i.addV2CFunction("AV10ItemDoubleClickData","vITEMDOUBLECLICKDATA","SetItemDoubleClickData");i.addC2VFunction(function(n){n.ParentObject.AV10ItemDoubleClickData=n.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",n.ParentObject.AV10ItemDoubleClickData)});i.addV2CFunction("AV11DragAndDropData","vDRAGANDDROPDATA","SetDragAndDropData");i.addC2VFunction(function(n){n.ParentObject.AV11DragAndDropData=n.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",n.ParentObject.AV11DragAndDropData)});i.addV2CFunction("AV12FilterChangedData","vFILTERCHANGEDDATA","SetFilterChangedData");i.addC2VFunction(function(n){n.ParentObject.AV12FilterChangedData=n.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",n.ParentObject.AV12FilterChangedData)});i.addV2CFunction("AV13ItemExpandData","vITEMEXPANDDATA","SetItemExpandData");i.addC2VFunction(function(n){n.ParentObject.AV13ItemExpandData=n.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",n.ParentObject.AV13ItemExpandData)});i.addV2CFunction("AV14ItemCollapseData","vITEMCOLLAPSEDATA","SetItemCollapseData");i.addC2VFunction(function(n){n.ParentObject.AV14ItemCollapseData=n.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",n.ParentObject.AV14ItemCollapseData)});i.setProp("AppSettings","Appsettings","","char");i.setProp("AvoidAutomaticShow","Avoidautomaticshow",!1,"boolean");i.setProp("ExecuteShow","Executeshow",!1,"boolean");i.setProp("ServiceUrl","Serviceurl","","char");i.setProp("GenType","Gentype","","char");i.setProp("DesignRenderOutputType","Designrenderoutputtype","","char");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.DVPANEL_TABLECHART4Container=gx.uc.getNew(this,31,0,"BootstrapPanel","DVPANEL_TABLECHART4Container","Dvpanel_tablechart4","DVPANEL_TABLECHART4");e=this.DVPANEL_TABLECHART4Container;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("Width","Width","100%","str");e.setProp("Height","Height","100","str");e.setProp("AutoWidth","Autowidth",!1,"bool");e.setProp("AutoHeight","Autoheight",!0,"bool");e.setProp("Cls","Cls","PanelCard_GrayTitle","str");e.setProp("ShowHeader","Showheader",!0,"bool");e.setProp("Title","Title","Task Board","str");e.setProp("Collapsible","Collapsible",!1,"bool");e.setProp("Collapsed","Collapsed",!1,"bool");e.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");e.setProp("IconPosition","Iconposition","Right","str");e.setProp("AutoScroll","Autoscroll",!1,"bool");e.setProp("Visible","Visible",!0,"bool");e.setProp("Gx Control Type","Gxcontroltype","","int");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);r[2]={id:2,fld:"",grid:0};r[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};r[4]={id:4,fld:"",grid:0};r[5]={id:5,fld:"",grid:0};r[6]={id:6,fld:"TABLEMAIN",grid:0};r[7]={id:7,fld:"",grid:0};r[8]={id:8,fld:"",grid:0};r[11]={id:11,fld:"TABLECARDS",grid:0};r[12]={id:12,fld:"",grid:0};r[13]={id:13,fld:"TABLEPROGRESSCARDS",grid:0};r[14]={id:14,fld:"",grid:0};r[16]={id:16,fld:"",grid:0};r[18]={id:18,fld:"",grid:0};r[20]={id:20,fld:"",grid:0};r[22]={id:22,fld:"",grid:0};r[25]={id:25,fld:"TABLECHART1",grid:0};r[26]={id:26,fld:"",grid:0};r[27]={id:27,fld:"",grid:0};r[29]={id:29,fld:"",grid:0};r[30]={id:30,fld:"",grid:0};r[33]={id:33,fld:"TABLECHART4",grid:0};r[34]={id:34,fld:"",grid:0};r[35]={id:35,fld:"",grid:0};this.AV7Elements=[];this.Events={e132y2_client:["ENTER",!0],e142y2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.START=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(webpanel1)})