gx.evt.autoSkip=!1;gx.define("gamwwrepositories",!1,function(){var t,r,f,i,n,u,o,e;this.ServerClass="gamwwrepositories";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV52ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV47ColumnsSelector=gx.fn.getControlValue("vCOLUMNSSELECTOR");this.AV69Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV63IsAuthorized_Display=gx.fn.getControlValue("vISAUTHORIZED_DISPLAY");this.AV64IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV65IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE");this.AV21IsAuthorized_Id=gx.fn.getControlValue("vISAUTHORIZED_ID");this.AV33GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV66IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT");this.AV52ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV47ColumnsSelector=gx.fn.getControlValue("vCOLUMNSSELECTOR");this.AV69Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV63IsAuthorized_Display=gx.fn.getControlValue("vISAUTHORIZED_DISPLAY");this.AV64IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV65IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE");this.AV21IsAuthorized_Id=gx.fn.getControlValue("vISAUTHORIZED_ID")};this.s172_client=function(){this.AV10FilName=""};this.e121l2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e131l2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e141l2_client=function(){return this.executeServerEvent("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!1,null,!0,!0)};this.e111l2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e191l2_client=function(){return this.executeServerEvent("VGRIDACTIONS.CLICK",!0,arguments[0],!1,!1)};this.e151l2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e201l2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e211l2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,20,21,22,23,28,31,32,33,34,35,37,38,39,40,41,43,44,45,46,47,49,50,51];this.GXLastCtrlId=51;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",42,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamwwrepositories",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addComboBox("Gridactions",43,"vGRIDACTIONS","","GridActions","int","e191l2_client",0,!0,!1,0,"px","WWActionGroupColumn");r.addSingleLineEdit("Id",44,"vID","Id","","Id","int",0,"px",12,12,"right",null,[],"Id","Id",!0,0,!1,!1,"Attribute",1,"WWColumn hidden-xs");r.addSingleLineEdit("Name",45,"vNAME","Nome","","Name","char",410,"px",254,80,"left",null,[],"Name","Name",!0,0,!1,!1,"Attribute",1,"WWColumn");this.GridContainer.emptyText="";this.setGrid(r);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");f=this.DVPANEL_TABLEHEADERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("Width","Width","100%","str");f.setProp("Height","Height","100","str");f.setProp("AutoWidth","Autowidth",!1,"bool");f.setProp("AutoHeight","Autoheight",!0,"bool");f.setProp("Cls","Cls","PanelNoHeader","str");f.setProp("ShowHeader","Showheader",!0,"bool");f.setProp("Title","Title","Opções","str");f.setProp("Collapsible","Collapsible",!0,"bool");f.setProp("Collapsed","Collapsed",!1,"bool");f.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");f.setProp("IconPosition","Iconposition","Right","str");f.setProp("AutoScroll","Autoscroll",!1,"bool");f.setProp("Visible","Visible",!0,"bool");f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,48,33,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV59GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV59GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV59GridCurrentPage)});i.addV2CFunction("AV24GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV24GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV24GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV62GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV62GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV62GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e121l2_client);i.addEventHandler("ChangeRowsPerPage",this.e131l2_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,52,33,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:Id|2:Name","str");n.setProp("ColumnsSortValues","Columnssortvalues","|","str");n.setProp("IncludeSortASC","Includesortasc","","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","T","str");n.setProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","","str");n.setProp("FilterType","Filtertype","","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","","str");n.setProp("DataListType","Datalisttype","","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV58DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV58DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV58DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);this.DDO_GRIDCOLUMNSSELECTORContainer=gx.uc.getNew(this,53,33,"BootstrapDropDownOptions","DDO_GRIDCOLUMNSSELECTORContainer","Ddo_gridcolumnsselector","DDO_GRIDCOLUMNSSELECTOR");u=this.DDO_GRIDCOLUMNSSELECTORContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","Image","str");u.setProp("Icon","Icon","","str");u.setProp("Caption","Caption","Seleciona colunas","str");u.setProp("Tooltip","Tooltip","WWP_EditColumnsTooltip","str");u.setProp("Cls","Cls","ColumnsSelector hidden-xs","str");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","GridColumnsSelector","str");u.setProp("Visible","Visible",!0,"bool");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("ColumnsSelectorValues","Columnsselectorvalues","","char");u.setProp("UpdateButtonText","Updatebuttontext","","str");u.addV2CFunction("AV58DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");u.addC2VFunction(function(n){n.ParentObject.AV58DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV58DDO_TitleSettingsIcons)});u.addV2CFunction("AV47ColumnsSelector","vCOLUMNSSELECTOR","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV47ColumnsSelector=n.GetDropDownOptionsData();gx.fn.setControlValue("vCOLUMNSSELECTOR",n.ParentObject.AV47ColumnsSelector)});u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnColumnsChanged",this.e141l2_client);this.setUserControl(u);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,54,33,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");o=this.GRID_EMPOWERERContainer;o.setProp("Class","Class","","char");o.setProp("Enabled","Enabled",!0,"boolean");o.setDynProp("GridInternalName","Gridinternalname","","char");o.setProp("HasCategories","Hascategories",!1,"bool");o.setProp("InfiniteScrolling","Infinitescrolling","False","str");o.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");o.setProp("HasColumnsSelector","Hascolumnsselector",!0,"bool");o.setProp("HasRowGroups","Hasrowgroups",!1,"bool");o.setProp("FixedColumns","Fixedcolumns","","str");o.setProp("PopoversInGrid","Popoversingrid","","str");o.setProp("Visible","Visible",!0,"bool");o.setC2ShowFunction(function(n){n.show()});this.setUserControl(o);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,26,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");e=this.DDO_MANAGEFILTERSContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("IconType","Icontype","FontIcon","str");e.setProp("Icon","Icon","fas fa-filter","str");e.setProp("Caption","Caption","","str");e.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");e.setProp("Cls","Cls","ManageFilters","str");e.setProp("ActiveEventKey","Activeeventkey","","char");e.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");e.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");e.setProp("Visible","Visible",!0,"bool");e.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");e.addV2CFunction("AV56ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");e.addC2VFunction(function(n){n.ParentObject.AV56ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV56ManageFiltersData)});e.setProp("Gx Control Type","Gxcontroltype","","int");e.setC2ShowFunction(function(n){n.show()});e.addEventHandler("OnOptionClicked",this.e111l2_client);this.setUserControl(e);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[11]={id:11,fld:"TABLEHEADER",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"TABLEACTIONS",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"BTNINSERT",grid:0,evt:"e151l2_client"};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"BTNEDITCOLUMNS",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"TABLERIGHTHEADER",grid:0};t[28]={id:28,fld:"TABLEFILTERS",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",gxz:"ZV10FilName",gxold:"OV10FilName",gxvar:"AV10FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV10FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"",grid:0};t[39]={id:39,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[43]={id:43,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGRIDACTIONS",gxz:"ZV60GridActions",gxold:"OV60GridActions",gxvar:"AV60GridActions",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV60GridActions=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV60GridActions=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vGRIDACTIONS",n||gx.fn.currentGridRowImpl(42),gx.O.AV60GridActions)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV60GridActions=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vGRIDACTIONS",n||gx.fn.currentGridRowImpl(42),".")},nac:gx.falseFn,evt:"e191l2_client"};t[44]={id:44,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",gxz:"ZV13Id",gxold:"OV13Id",gxvar:"AV13Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV13Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV13Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(42),gx.O.AV13Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(42),".")},nac:gx.falseFn};t[45]={id:45,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV14Name",gxold:"OV14Name",gxvar:"AV14Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(42),gx.O.AV14Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(42))},nac:gx.falseFn};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV10FilName="";this.ZV10FilName="";this.OV10FilName="";this.ZV60GridActions=0;this.OV60GridActions=0;this.ZV13Id=0;this.OV13Id=0;this.ZV14Name="";this.OV14Name="";this.AV56ManageFiltersData=[];this.AV10FilName="";this.AV59GridCurrentPage=0;this.AV58DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:""};this.AV60GridActions=0;this.AV13Id=0;this.AV14Name="";this.AV52ManageFiltersExecutionStep=0;this.AV47ColumnsSelector={Columns:[]};this.AV69Pgmname="";this.AV63IsAuthorized_Display=!1;this.AV64IsAuthorized_Update=!1;this.AV65IsAuthorized_Delete=!1;this.AV21IsAuthorized_Id=!1;this.AV33GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV66IsAuthorized_Insert=!1;this.Events={e121l2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e131l2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e141l2_client:["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!0],e111l2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e191l2_client:["VGRIDACTIONS.CLICK",!0],e151l2_client:["'DOINSERT'",!0],e201l2_client:["ENTER",!0],e211l2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{ctrl:"GRID",prop:"Rows"},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0}],[{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("vID","Visible")',ctrl:"vID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vNAME","Visible")',ctrl:"vNAME",prop:"Visible"},{av:"AV59GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV62GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV56ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms.START=[[{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"this.GRID_EMPOWERERContainer.GridInternalName",ctrl:"GRID_EMPOWERER",prop:"GridInternalName"},{av:"this.DDO_GRIDCOLUMNSSELECTORContainer.GridInternalName",ctrl:"DDO_GRIDCOLUMNSSELECTOR",prop:"GridInternalName"},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.GridInternalName",ctrl:"DDO_GRID",prop:"GridInternalName"},{ctrl:"FORM",prop:"Caption"},{av:"AV58DDO_TitleSettingsIcons",fld:"vDDO_TITLESETTINGSICONS",pic:""},{av:"this.DDO_GRIDCOLUMNSSELECTORContainer.TitleControlIdToReplace",ctrl:"DDO_GRIDCOLUMNSSELECTOR",prop:"TitleControlIdToReplace"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"},{av:"AV56ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{ctrl:"GRID",prop:"Rows"},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0}],[{av:"AV24GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV14Name",fld:"vNAME",pic:""},{ctrl:"vGRIDACTIONS"},{av:"AV60GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"},{av:'gx.fn.getCtrlProperty("vID","Link")',ctrl:"vID",prop:"Link"}]];this.EvtParms["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.DDO_GRIDCOLUMNSSELECTORContainer.ColumnsSelectorValues",ctrl:"DDO_GRIDCOLUMNSSELECTOR",prop:"ColumnsSelectorValues"}],[{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:'gx.fn.getCtrlProperty("vID","Visible")',ctrl:"vID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vNAME","Visible")',ctrl:"vNAME",prop:"Visible"},{av:"AV59GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV62GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV56ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("vID","Visible")',ctrl:"vID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vNAME","Visible")',ctrl:"vNAME",prop:"Visible"},{av:"AV59GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV62GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV56ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["VGRIDACTIONS.CLICK"]=[[{ctrl:"vGRIDACTIONS"},{av:"AV60GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{ctrl:"vGRIDACTIONS"},{av:"AV60GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"},{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("vID","Visible")',ctrl:"vID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vNAME","Visible")',ctrl:"vNAME",prop:"Visible"},{av:"AV59GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV62GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV56ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:"AV69Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV21IsAuthorized_Id",fld:"vISAUTHORIZED_ID",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0}],[{av:"AV52ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV47ColumnsSelector",fld:"vCOLUMNSSELECTOR",pic:""},{av:'gx.fn.getCtrlProperty("vID","Visible")',ctrl:"vID",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vNAME","Visible")',ctrl:"vNAME",prop:"Visible"},{av:"AV59GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV62GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",pic:"",hsh:!0},{av:"AV64IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV65IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"AV66IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV56ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.setVCMap("AV52ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV47ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV69Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV63IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV64IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV65IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV21IsAuthorized_Id","vISAUTHORIZED_ID",0,"boolean",4,0);this.setVCMap("AV33GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV66IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV52ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV47ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV69Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV63IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV64IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV65IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV21IsAuthorized_Id","vISAUTHORIZED_ID",0,"boolean",4,0);this.setVCMap("AV52ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV47ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV69Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV63IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV64IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV65IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV21IsAuthorized_Id","vISAUTHORIZED_ID",0,"boolean",4,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar({rfrVar:"AV52ManageFiltersExecutionStep"});r.addRefreshingVar({rfrVar:"AV47ColumnsSelector"});r.addRefreshingVar({rfrVar:"AV69Pgmname"});r.addRefreshingVar(this.GXValidFnc[33]);r.addRefreshingVar({rfrVar:"AV63IsAuthorized_Display"});r.addRefreshingVar({rfrVar:"AV64IsAuthorized_Update"});r.addRefreshingVar({rfrVar:"AV65IsAuthorized_Delete"});r.addRefreshingVar({rfrVar:"AV21IsAuthorized_Id"});r.addRefreshingVar({rfrVar:"AV66IsAuthorized_Insert"});r.addRefreshingParm({rfrVar:"AV52ManageFiltersExecutionStep"});r.addRefreshingParm({rfrVar:"AV47ColumnsSelector"});r.addRefreshingParm({rfrVar:"AV69Pgmname"});r.addRefreshingParm(this.GXValidFnc[33]);r.addRefreshingParm({rfrVar:"AV63IsAuthorized_Display"});r.addRefreshingParm({rfrVar:"AV64IsAuthorized_Update"});r.addRefreshingParm({rfrVar:"AV65IsAuthorized_Delete"});r.addRefreshingParm({rfrVar:"AV21IsAuthorized_Id"});r.addRefreshingParm({rfrVar:"AV66IsAuthorized_Insert"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("GeneXusSecurity\\GAMRepositoryCreate",{Application:{sdt:"GeneXusSecurity\\GAMApplication"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector",{Columns:{sdt:"WWPBaseObjects\\WWPColumnsSelector.Column"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector.Column",{ColumnName:{extr:"C"},IsVisible:{extr:"V"},DisplayName:{extr:"D"},Order:{extr:"O"},Category:{extr:"G"},Fixed:{extr:"F"}})});gx.wi(function(){gx.createParentObj(gamwwrepositories)})