gx.evt.autoSkip=!1;gx.define("gamwwroleroles",!1,function(){var n,i,r,t,f,u;this.ServerClass="gamwwroleroles";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV36ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV49Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV21RoleIdAux=gx.fn.getIntegerValue("vROLEIDAUX",".");this.AV33GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV45IsAuthorized_Back=gx.fn.getControlValue("vISAUTHORIZED_BACK");this.AV46IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT");this.AV20RoleId=gx.fn.getIntegerValue("vROLEID",".");this.AV36ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV49Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV21RoleIdAux=gx.fn.getIntegerValue("vROLEIDAUX",".")};this.s152_client=function(){this.AV10FilName="";this.AV9FilExternalId=""};this.e121m2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e131m2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e111m2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e191m2_client=function(){return this.executeServerEvent("VGRIDACTIONS.CLICK",!0,arguments[0],!1,!1)};this.e141m2_client=function(){return this.executeServerEvent("'DOBACK'",!1,null,!1,!1)};this.e151m2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e201m2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e211m2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,20,21,22,23,28,31,32,33,36,37,38,39,40,42,43,44,45,46,48,49,50,51,52,54,55,56];this.GXLastCtrlId=56;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",47,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamwwroleroles",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addComboBox("Gridactions",48,"vGRIDACTIONS","","GridActions","int","e191m2_client",0,!0,!1,0,"px","WWActionGroupColumn");i.addSingleLineEdit("Id",49,"vID","Id","","Id","int",0,"px",12,12,"right",null,[],"Id","Id",!1,0,!1,!1,"Attribute",1,"WWColumn");i.addSingleLineEdit("Name",50,"vNAME","Nome","","Name","char",410,"px",254,80,"left",null,[],"Name","Name",!0,0,!1,!1,"Attribute",1,"WWColumn");this.GridContainer.emptyText="";this.setGrid(i);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");r=this.DVPANEL_TABLEHEADERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelNoHeader","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Opções","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,53,33,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV42GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV42GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV42GridCurrentPage)});t.addV2CFunction("AV13GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV13GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV13GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV44GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV44GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV44GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e121m2_client);t.addEventHandler("ChangeRowsPerPage",this.e131m2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,57,33,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,26,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");u=this.DDO_MANAGEFILTERSContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-filter","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");u.setProp("Cls","Cls","ManageFilters","str");u.setProp("ActiveEventKey","Activeeventkey","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.addV2CFunction("AV40ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV40ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV40ManageFiltersData)});u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e111m2_client);this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[11]={id:11,fld:"TABLEHEADER",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"TABLEACTIONS",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"BTNBACK",grid:0,evt:"e141m2_client"};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTNINSERT",grid:0,evt:"e151m2_client"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TABLERIGHTHEADER",grid:0};n[28]={id:28,fld:"TABLEFILTERS",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",gxz:"ZV10FilName",gxold:"OV10FilName",gxvar:"AV10FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV10FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILEXTERNALID",gxz:"ZV9FilExternalId",gxold:"OV9FilExternalId",gxvar:"AV9FilExternalId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9FilExternalId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9FilExternalId=n)},v2c:function(){gx.fn.setControlValue("vFILEXTERNALID",gx.O.AV9FilExternalId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9FilExternalId=this.val())},val:function(){return gx.fn.getControlValue("vFILEXTERNALID")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[48]={id:48,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:47,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGRIDACTIONS",gxz:"ZV43GridActions",gxold:"OV43GridActions",gxvar:"AV43GridActions",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV43GridActions=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV43GridActions=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("vGRIDACTIONS",n||gx.fn.currentGridRowImpl(47),gx.O.AV43GridActions)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV43GridActions=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vGRIDACTIONS",n||gx.fn.currentGridRowImpl(47),".")},nac:gx.falseFn,evt:"e191m2_client"};n[49]={id:49,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:47,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",gxz:"ZV14Id",gxold:"OV14Id",gxvar:"AV14Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV14Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(47),gx.O.AV14Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(47),".")},nac:gx.falseFn};n[50]={id:50,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:47,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV16Name",gxold:"OV16Name",gxvar:"AV16Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV16Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(47),gx.O.AV16Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(47))},nac:gx.falseFn};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV10FilName="";this.ZV10FilName="";this.OV10FilName="";this.AV9FilExternalId="";this.ZV9FilExternalId="";this.OV9FilExternalId="";this.ZV43GridActions=0;this.OV43GridActions=0;this.ZV14Id=0;this.OV14Id=0;this.ZV16Name="";this.OV16Name="";this.AV40ManageFiltersData=[];this.AV10FilName="";this.AV9FilExternalId="";this.AV42GridCurrentPage=0;this.AV20RoleId=0;this.AV21RoleIdAux=0;this.AV43GridActions=0;this.AV14Id=0;this.AV16Name="";this.AV36ManageFiltersExecutionStep=0;this.AV49Pgmname="";this.AV33GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV45IsAuthorized_Back=!1;this.AV46IsAuthorized_Insert=!1;this.Events={e121m2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e131m2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e111m2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e191m2_client:["VGRIDACTIONS.CLICK",!0],e141m2_client:["'DOBACK'",!0],e151m2_client:["'DOINSERT'",!0],e201m2_client:["ENTER",!0],e211m2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV42GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV44GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms.START=[[{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"this.GRID_EMPOWERERContainer.GridInternalName",ctrl:"GRID_EMPOWERER",prop:"GridInternalName"},{ctrl:"FORM",prop:"Caption"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{ctrl:"GRID",prop:"Rows"},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""}],[{av:"AV13GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV14Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV16Name",fld:"vNAME",pic:""},{ctrl:"vGRIDACTIONS"},{av:"AV43GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV42GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV44GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["VGRIDACTIONS.CLICK"]=[[{ctrl:"vGRIDACTIONS"},{av:"AV43GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV14Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{ctrl:"vGRIDACTIONS"},{av:"AV43GridActions",fld:"vGRIDACTIONS",pic:"ZZZ9"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV42GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV44GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["'DOBACK'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV42GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV44GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV49Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV9FilExternalId",fld:"vFILEXTERNALID",pic:""},{av:"AV21RoleIdAux",fld:"vROLEIDAUX",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV20RoleId",fld:"vROLEID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV42GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV44GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV45IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV46IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.setVCMap("AV36ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV49Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV21RoleIdAux","vROLEIDAUX",0,"int",12,0);this.setVCMap("AV33GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV45IsAuthorized_Back","vISAUTHORIZED_BACK",0,"boolean",4,0);this.setVCMap("AV46IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV20RoleId","vROLEID",0,"int",12,0);this.setVCMap("AV36ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV49Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV21RoleIdAux","vROLEIDAUX",0,"int",12,0);this.setVCMap("AV36ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV49Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV21RoleIdAux","vROLEIDAUX",0,"int",12,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV36ManageFiltersExecutionStep"});i.addRefreshingVar({rfrVar:"AV49Pgmname"});i.addRefreshingVar(this.GXValidFnc[33]);i.addRefreshingVar(this.GXValidFnc[38]);i.addRefreshingVar({rfrVar:"AV21RoleIdAux"});i.addRefreshingVar({rfrVar:"AV45IsAuthorized_Back"});i.addRefreshingVar({rfrVar:"AV46IsAuthorized_Insert"});i.addRefreshingVar({rfrVar:"AV20RoleId"});i.addRefreshingParm({rfrVar:"AV36ManageFiltersExecutionStep"});i.addRefreshingParm({rfrVar:"AV49Pgmname"});i.addRefreshingParm(this.GXValidFnc[33]);i.addRefreshingParm(this.GXValidFnc[38]);i.addRefreshingParm({rfrVar:"AV21RoleIdAux"});i.addRefreshingParm({rfrVar:"AV45IsAuthorized_Back"});i.addRefreshingParm({rfrVar:"AV46IsAuthorized_Insert"});i.addRefreshingParm({rfrVar:"AV20RoleId"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}})});gx.wi(function(){gx.createParentObj(gamwwroleroles)})