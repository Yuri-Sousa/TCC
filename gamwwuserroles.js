gx.evt.autoSkip=!1;gx.define("gamwwuserroles",!1,function(){var n,i,r,t,f,u;this.ServerClass="gamwwuserroles";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV57ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV71Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV28UserId=gx.fn.getControlValue("vUSERID");this.AV37GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV67IsAuthorized_Back=gx.fn.getControlValue("vISAUTHORIZED_BACK");this.AV68IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT");this.AV27RolesId=gx.fn.getIntegerValue("vROLESID",".");this.AV57ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV71Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV28UserId=gx.fn.getControlValue("vUSERID")};this.s152_client=function(){this.AV11DisplayInheritRoles=!1};this.e121p2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e131p2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e111p2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e141p2_client=function(){return this.executeServerEvent("'DOBACK'",!1,null,!1,!1)};this.e151p2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e191p2_client=function(){return this.executeServerEvent("VDELETE.CLICK",!0,arguments[0],!1,!1)};this.e201p2_client=function(){return this.executeServerEvent("'DOADD'",!0,arguments[0],!1,!1)};this.e211p2_client=function(){return this.executeServerEvent("VBTNMAINROLE.CLICK",!0,arguments[0],!1,!1)};this.e221p2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e231p2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,20,21,22,23,28,31,32,33,34,35,37,38,39,40,41,43,44,45,46,47,48,49,51,52,53];this.GXLastCtrlId=53;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",42,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamwwuserroles",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit("Delete",43,"vDELETE","","Eliminar","Delete","char",0,"px",20,20,"left","e191p2_client",[],"Delete","Delete",!0,0,!1,!1,"Attribute",1,"WWIconActionColumn");i.addSingleLineEdit("Btnmainrole",44,"vBTNMAINROLE","","","BtnMainRole","char",120,"px",10,10,"left","e211p2_client",[],"Btnmainrole","BtnMainRole",!0,0,!1,!1,"Attribute",1,"WWActionColumn");i.addSingleLineEdit("Name",45,"vNAME","Perfil","","Name","char",0,"px",120,80,"left",null,[],"Name","Name",!0,0,!1,!1,"Attribute",1,"WWColumn");i.addSingleLineEdit("Id",46,"vID","Key Numeric Long","","Id","int",0,"px",12,12,"right",null,[],"Id","Id",!1,0,!1,!1,"Attribute",1,"WWColumn");i.addSingleLineEdit("Guid",47,"vGUID","Guid","","GUID","char",0,"px",40,40,"left",null,[],"Guid","GUID",!1,0,!1,!1,"Attribute",1,"WWColumn");this.GridContainer.emptyText="";this.setGrid(i);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");r=this.DVPANEL_TABLEHEADERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelNoHeader","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Opções","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,50,33,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV64GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV64GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV64GridCurrentPage)});t.addV2CFunction("AV18GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV18GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV18GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV66GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV66GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV66GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e121p2_client);t.addEventHandler("ChangeRowsPerPage",this.e131p2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,54,33,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,26,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");u=this.DDO_MANAGEFILTERSContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-filter","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");u.setProp("Cls","Cls","ManageFilters","str");u.setProp("ActiveEventKey","Activeeventkey","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.addV2CFunction("AV61ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV61ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV61ManageFiltersData)});u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e111p2_client);this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[11]={id:11,fld:"TABLEHEADER",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"TABLEACTIONS",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"BTNBACK",grid:0,evt:"e141p2_client"};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTNINSERT",grid:0,evt:"e151p2_client"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TABLERIGHTHEADER",grid:0};n[28]={id:28,fld:"TABLEFILTERS",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYINHERITROLES",gxz:"ZV11DisplayInheritRoles",gxold:"OV11DisplayInheritRoles",gxvar:"AV11DisplayInheritRoles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV11DisplayInheritRoles=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11DisplayInheritRoles=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vDISPLAYINHERITROLES",gx.O.AV11DisplayInheritRoles,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11DisplayInheritRoles=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vDISPLAYINHERITROLES")},nac:gx.falseFn,values:["true","false"]};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[43]={id:43,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV5Delete",gxold:"OV5Delete",gxvar:"AV5Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV5Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(42),gx.O.AV5Delete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(42))},nac:gx.falseFn,evt:"e191p2_client"};n[44]={id:44,lvl:2,type:"char",len:10,dec:0,sign:!1,ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNMAINROLE",gxz:"ZV9BtnMainRole",gxold:"OV9BtnMainRole",gxvar:"AV9BtnMainRole",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV9BtnMainRole=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9BtnMainRole=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNMAINROLE",n||gx.fn.currentGridRowImpl(42),gx.O.AV9BtnMainRole,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9BtnMainRole=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNMAINROLE",n||gx.fn.currentGridRowImpl(42))},nac:gx.falseFn,evt:"e211p2_client"};n[45]={id:45,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV24Name",gxold:"OV24Name",gxvar:"AV24Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV24Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(42),gx.O.AV24Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(42))},nac:gx.falseFn};n[46]={id:46,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",gxz:"ZV22Id",gxold:"OV22Id",gxvar:"AV22Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV22Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(42),gx.O.AV22Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV22Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(42),".")},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:42,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGUID",gxz:"ZV21GUID",gxold:"OV21GUID",gxvar:"AV21GUID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV21GUID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21GUID=n)},v2c:function(n){gx.fn.setGridControlValue("vGUID",n||gx.fn.currentGridRowImpl(42),gx.O.AV21GUID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21GUID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vGUID",n||gx.fn.currentGridRowImpl(42))},nac:gx.falseFn};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV11DisplayInheritRoles=!1;this.ZV11DisplayInheritRoles=!1;this.OV11DisplayInheritRoles=!1;this.ZV5Delete="";this.OV5Delete="";this.ZV9BtnMainRole="";this.OV9BtnMainRole="";this.ZV24Name="";this.OV24Name="";this.ZV22Id=0;this.OV22Id=0;this.ZV21GUID="";this.OV21GUID="";this.AV61ManageFiltersData=[];this.AV11DisplayInheritRoles=!1;this.AV64GridCurrentPage=0;this.AV28UserId="";this.AV5Delete="";this.AV9BtnMainRole="";this.AV24Name="";this.AV22Id=0;this.AV21GUID="";this.AV57ManageFiltersExecutionStep=0;this.AV71Pgmname="";this.AV37GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV67IsAuthorized_Back=!1;this.AV68IsAuthorized_Insert=!1;this.AV27RolesId=0;this.Events={e121p2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e131p2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e111p2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e141p2_client:["'DOBACK'",!0],e151p2_client:["'DOINSERT'",!0],e191p2_client:["VDELETE.CLICK",!0],e201p2_client:["'DOADD'",!0],e211p2_client:["VBTNMAINROLE.CLICK",!0],e221p2_client:["ENTER",!0],e231p2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms.START=[[{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"this.GRID_EMPOWERERContainer.GridInternalName",ctrl:"GRID_EMPOWERER",prop:"GridInternalName"},{ctrl:"FORM",prop:"Caption"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{ctrl:"GRID",prop:"Rows"},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV5Delete",fld:"vDELETE",pic:""},{av:"AV9BtnMainRole",fld:"vBTNMAINROLE",pic:"",hsh:!0},{av:"AV18GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV24Name",fld:"vNAME",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:"AV21GUID",fld:"vGUID",pic:""},{av:"AV22Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["'DOBACK'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["VDELETE.CLICK"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV22Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["'DOADD'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.EvtParms["VBTNMAINROLE.CLICK"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV71Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV28UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{av:"AV27RolesId",fld:"vROLESID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV9BtnMainRole",fld:"vBTNMAINROLE",pic:"",hsh:!0},{av:"AV22Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}],[{av:"AV57ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV64GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV66GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV67IsAuthorized_Back",fld:"vISAUTHORIZED_BACK",pic:"",hsh:!0},{ctrl:"BTNBACK",prop:"Visible"},{av:"AV68IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",pic:"",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{av:"AV61ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV11DisplayInheritRoles",fld:"vDISPLAYINHERITROLES",pic:""}]];this.setVCMap("AV57ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV71Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28UserId","vUSERID",0,"char",40,0);this.setVCMap("AV37GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV67IsAuthorized_Back","vISAUTHORIZED_BACK",0,"boolean",4,0);this.setVCMap("AV68IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV27RolesId","vROLESID",0,"int",12,0);this.setVCMap("AV57ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV71Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28UserId","vUSERID",0,"char",40,0);this.setVCMap("AV57ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV71Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV28UserId","vUSERID",0,"char",40,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV57ManageFiltersExecutionStep"});i.addRefreshingVar({rfrVar:"AV71Pgmname"});i.addRefreshingVar(this.GXValidFnc[33]);i.addRefreshingVar({rfrVar:"AV28UserId"});i.addRefreshingVar({rfrVar:"AV67IsAuthorized_Back"});i.addRefreshingVar({rfrVar:"AV68IsAuthorized_Insert"});i.addRefreshingVar({rfrVar:"AV27RolesId"});i.addRefreshingParm({rfrVar:"AV57ManageFiltersExecutionStep"});i.addRefreshingParm({rfrVar:"AV71Pgmname"});i.addRefreshingParm(this.GXValidFnc[33]);i.addRefreshingParm({rfrVar:"AV28UserId"});i.addRefreshingParm({rfrVar:"AV67IsAuthorized_Back"});i.addRefreshingParm({rfrVar:"AV68IsAuthorized_Insert"});i.addRefreshingParm({rfrVar:"AV27RolesId"});this.Initialize();this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationPermission",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector",{Columns:{sdt:"WWPBaseObjects\\WWPColumnsSelector.Column"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector.Column",{ColumnName:{extr:"C"},IsVisible:{extr:"V"},DisplayName:{extr:"D"},Order:{extr:"O"},Category:{extr:"G"},Fixed:{extr:"F"}})});gx.wi(function(){gx.createParentObj(gamwwuserroles)})