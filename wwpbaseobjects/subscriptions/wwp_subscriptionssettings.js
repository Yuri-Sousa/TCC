gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.subscriptions.wwp_subscriptionssettings', false, function () {
   this.ServerClass =  "wwpbaseobjects.subscriptions.wwp_subscriptionssettings" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV41Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.A12WWPEntityName=gx.fn.getControlValue("WWPENTITYNAME") ;
      this.A10WWPEntityId=gx.fn.getIntegerValue("WWPENTITYID",'.') ;
      this.A27WWPNotificationDefinitionAllowUserSubscription=gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION") ;
      this.A1WWPUserExtendedId=gx.fn.getControlValue("WWPUSEREXTENDEDID") ;
      this.AV44Udparg2=gx.fn.getControlValue("vUDPARG2") ;
      this.A23WWPSubscriptionSubscribed=gx.fn.getControlValue("WWPSUBSCRIPTIONSUBSCRIBED") ;
      this.A11WWPSubscriptionRoleId=gx.fn.getControlValue("WWPSUBSCRIPTIONROLEID") ;
      this.A14WWPNotificationDefinitionId=gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",'.') ;
      this.AV41Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.A12WWPEntityName=gx.fn.getControlValue("WWPENTITYNAME") ;
      this.A10WWPEntityId=gx.fn.getIntegerValue("WWPENTITYID",'.') ;
      this.A27WWPNotificationDefinitionAllowUserSubscription=gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION") ;
      this.A1WWPUserExtendedId=gx.fn.getControlValue("WWPUSEREXTENDEDID") ;
      this.AV44Udparg2=gx.fn.getControlValue("vUDPARG2") ;
      this.A23WWPSubscriptionSubscribed=gx.fn.getControlValue("WWPSUBSCRIPTIONSUBSCRIBED") ;
      this.A11WWPSubscriptionRoleId=gx.fn.getControlValue("WWPSUBSCRIPTIONROLEID") ;
      this.A14WWPNotificationDefinitionId=gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",'.') ;
   };
   this.e21202_client=function()
   {
      this.clearMessages();
      this.createWebComponent('Grid_dwc','WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsWC',[this.AV29WWPEntityId,this.AV17NotifShowOnlySubscribedEvents]);
      this.refreshOutputs([{ctrl:'GRID_DWC'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e11202_client=function()
   {
      return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE", false, null, true, true);
   };
   this.e12202_client=function()
   {
      return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE", false, null, true, true);
   };
   this.e13202_client=function()
   {
      return this.executeServerEvent("VMAIL.CLICK", true, null, false, true);
   };
   this.e14202_client=function()
   {
      return this.executeServerEvent("VSMS.CLICK", true, null, false, true);
   };
   this.e15202_client=function()
   {
      return this.executeServerEvent("VSD.CLICK", true, null, false, true);
   };
   this.e16202_client=function()
   {
      return this.executeServerEvent("VDESKTOP.CLICK", true, null, false, true);
   };
   this.e17202_client=function()
   {
      return this.executeServerEvent("VNOTIFSHOWONLYSUBSCRIBEDEVENTS.CLICK", true, null, false, true);
   };
   this.e22202_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e23202_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,44,45,46,47,48,50,51,53,54,55];
   this.GXLastCtrlId =55;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",43,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.subscriptions.wwp_subscriptionssettings",[],false,1,false,true,0,false,false,false,"",0,"px",0,"px","Novo registro",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit("Wwpentityname",44,"vWWPENTITYNAME","Entity","","WWPEntityName","svchar",0,"px",100,80,"left",null,[],"Wwpentityname","WWPEntityName",true,0,false,false,"Attribute",1,"WWColumn");
   GridContainer.addSingleLineEdit("Wwpentityid",45,"vWWPENTITYID","","","WWPEntityId","int",0,"px",10,10,"right",null,[],"Wwpentityid","WWPEntityId",false,0,false,false,"Attribute",1,"WWColumn");
   GridContainer.addSingleLineEdit("Detailwebcomponent",46,"vDETAILWEBCOMPONENT","","","DetailWebComponent","char",0,"px",20,20,"left","e21202_client",[],"Detailwebcomponent","DetailWebComponent",true,0,false,false,"Attribute",1,"WWIconActionColumn WCD_ActionColumn");
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   this.DVPANEL_UNNAMEDTABLE1Container = gx.uc.getNew(this, 9, 0, "BootstrapPanel", "DVPANEL_UNNAMEDTABLE1Container", "Dvpanel_unnamedtable1", "DVPANEL_UNNAMEDTABLE1");
   var DVPANEL_UNNAMEDTABLE1Container = this.DVPANEL_UNNAMEDTABLE1Container;
   DVPANEL_UNNAMEDTABLE1Container.setProp("Class", "Class", "", "char");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Enabled", "Enabled", true, "boolean");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Width", "Width", "100%", "str");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Height", "Height", "100", "str");
   DVPANEL_UNNAMEDTABLE1Container.setProp("AutoWidth", "Autowidth", false, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("AutoHeight", "Autoheight", true, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Cls", "Cls", "PanelFilled Panel_BaseColor", "str");
   DVPANEL_UNNAMEDTABLE1Container.setProp("ShowHeader", "Showheader", true, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Title", "Title", "Receive notifications by", "str");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Collapsible", "Collapsible", true, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Collapsed", "Collapsed", false, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("ShowCollapseIcon", "Showcollapseicon", false, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("IconPosition", "Iconposition", "Right", "str");
   DVPANEL_UNNAMEDTABLE1Container.setProp("AutoScroll", "Autoscroll", false, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Visible", "Visible", true, "bool");
   DVPANEL_UNNAMEDTABLE1Container.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   DVPANEL_UNNAMEDTABLE1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(DVPANEL_UNNAMEDTABLE1Container);
   this.GRIDPAGINATIONBARContainer = gx.uc.getNew(this, 49, 14, "DVelop_DVPaginationBar", "GRIDPAGINATIONBARContainer", "Gridpaginationbar", "GRIDPAGINATIONBAR");
   var GRIDPAGINATIONBARContainer = this.GRIDPAGINATIONBARContainer;
   GRIDPAGINATIONBARContainer.setProp("Enabled", "Enabled", true, "boolean");
   GRIDPAGINATIONBARContainer.setProp("Class", "Class", "PaginationBar", "str");
   GRIDPAGINATIONBARContainer.setProp("ShowFirst", "Showfirst", false, "bool");
   GRIDPAGINATIONBARContainer.setProp("ShowPrevious", "Showprevious", true, "bool");
   GRIDPAGINATIONBARContainer.setProp("ShowNext", "Shownext", true, "bool");
   GRIDPAGINATIONBARContainer.setProp("ShowLast", "Showlast", false, "bool");
   GRIDPAGINATIONBARContainer.setProp("PagesToShow", "Pagestoshow", 5, "num");
   GRIDPAGINATIONBARContainer.setProp("PagingButtonsPosition", "Pagingbuttonsposition", "Right", "str");
   GRIDPAGINATIONBARContainer.setProp("PagingCaptionPosition", "Pagingcaptionposition", "Left", "str");
   GRIDPAGINATIONBARContainer.setProp("EmptyGridClass", "Emptygridclass", "PaginationBarEmptyGrid", "str");
   GRIDPAGINATIONBARContainer.setProp("SelectedPage", "Selectedpage", "", "char");
   GRIDPAGINATIONBARContainer.setProp("RowsPerPageSelector", "Rowsperpageselector", true, "bool");
   GRIDPAGINATIONBARContainer.setDynProp("RowsPerPageSelectedValue", "Rowsperpageselectedvalue", 10, "num");
   GRIDPAGINATIONBARContainer.setProp("RowsPerPageOptions", "Rowsperpageoptions", "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50", "str");
   GRIDPAGINATIONBARContainer.setProp("First", "First", "First", "str");
   GRIDPAGINATIONBARContainer.setProp("Previous", "Previous", "WWP_PagingPreviousCaption", "str");
   GRIDPAGINATIONBARContainer.setProp("Next", "Next", "WWP_PagingNextCaption", "str");
   GRIDPAGINATIONBARContainer.setProp("Last", "Last", "Last", "str");
   GRIDPAGINATIONBARContainer.setProp("Caption", "Caption", "Página <CURRENT_PAGE> de <TOTAL_PAGES>", "str");
   GRIDPAGINATIONBARContainer.setProp("EmptyGridCaption", "Emptygridcaption", "WWP_PagingEmptyGridCaption", "str");
   GRIDPAGINATIONBARContainer.setProp("RowsPerPageCaption", "Rowsperpagecaption", "WWP_PagingRowsPerPage", "str");
   GRIDPAGINATIONBARContainer.addV2CFunction('AV8GridCurrentPage', "vGRIDCURRENTPAGE", 'SetCurrentPage');
   GRIDPAGINATIONBARContainer.addC2VFunction(function(UC) { UC.ParentObject.AV8GridCurrentPage=UC.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",UC.ParentObject.AV8GridCurrentPage); });
   GRIDPAGINATIONBARContainer.addV2CFunction('AV9GridPageCount', "vGRIDPAGECOUNT", 'SetPageCount');
   GRIDPAGINATIONBARContainer.addC2VFunction(function(UC) { UC.ParentObject.AV9GridPageCount=UC.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",UC.ParentObject.AV9GridPageCount); });
   GRIDPAGINATIONBARContainer.setProp("RecordCount", "Recordcount", '', "str");
   GRIDPAGINATIONBARContainer.setProp("Page", "Page", '', "str");
   GRIDPAGINATIONBARContainer.addV2CFunction('AV36GridAppliedFilters', "vGRIDAPPLIEDFILTERS", 'SetAppliedFilters');
   GRIDPAGINATIONBARContainer.addC2VFunction(function(UC) { UC.ParentObject.AV36GridAppliedFilters=UC.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",UC.ParentObject.AV36GridAppliedFilters); });
   GRIDPAGINATIONBARContainer.setProp("Visible", "Visible", true, "bool");
   GRIDPAGINATIONBARContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   GRIDPAGINATIONBARContainer.setC2ShowFunction(function(UC) { UC.show(); });
   GRIDPAGINATIONBARContainer.addEventHandler("ChangePage", this.e11202_client);
   GRIDPAGINATIONBARContainer.addEventHandler("ChangeRowsPerPage", this.e12202_client);
   this.setUserControl(GRIDPAGINATIONBARContainer);
   this.DVPANEL_UNNAMEDTABLE2Container = gx.uc.getNew(this, 26, 14, "BootstrapPanel", "DVPANEL_UNNAMEDTABLE2Container", "Dvpanel_unnamedtable2", "DVPANEL_UNNAMEDTABLE2");
   var DVPANEL_UNNAMEDTABLE2Container = this.DVPANEL_UNNAMEDTABLE2Container;
   DVPANEL_UNNAMEDTABLE2Container.setProp("Class", "Class", "", "char");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Enabled", "Enabled", true, "boolean");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Width", "Width", "100%", "str");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Height", "Height", "100", "str");
   DVPANEL_UNNAMEDTABLE2Container.setProp("AutoWidth", "Autowidth", false, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("AutoHeight", "Autoheight", true, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Cls", "Cls", "PanelNoHeader", "str");
   DVPANEL_UNNAMEDTABLE2Container.setProp("ShowHeader", "Showheader", true, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Title", "Title", "", "str");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Collapsible", "Collapsible", true, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Collapsed", "Collapsed", false, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("ShowCollapseIcon", "Showcollapseicon", false, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("IconPosition", "Iconposition", "Right", "str");
   DVPANEL_UNNAMEDTABLE2Container.setProp("AutoScroll", "Autoscroll", false, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Visible", "Visible", true, "bool");
   DVPANEL_UNNAMEDTABLE2Container.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   DVPANEL_UNNAMEDTABLE2Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(DVPANEL_UNNAMEDTABLE2Container);
   this.GRID_EMPOWERERContainer = gx.uc.getNew(this, 56, 14, "WWP_GridEmpowerer", "GRID_EMPOWERERContainer", "Grid_empowerer", "GRID_EMPOWERER");
   var GRID_EMPOWERERContainer = this.GRID_EMPOWERERContainer;
   GRID_EMPOWERERContainer.setProp("Class", "Class", "", "char");
   GRID_EMPOWERERContainer.setProp("Enabled", "Enabled", true, "boolean");
   GRID_EMPOWERERContainer.setDynProp("GridInternalName", "Gridinternalname", "", "char");
   GRID_EMPOWERERContainer.setProp("HasCategories", "Hascategories", false, "bool");
   GRID_EMPOWERERContainer.setProp("InfiniteScrolling", "Infinitescrolling", "False", "str");
   GRID_EMPOWERERContainer.setProp("HasTitleSettings", "Hastitlesettings", false, "bool");
   GRID_EMPOWERERContainer.setProp("HasColumnsSelector", "Hascolumnsselector", false, "bool");
   GRID_EMPOWERERContainer.setProp("HasRowGroups", "Hasrowgroups", false, "bool");
   GRID_EMPOWERERContainer.setProp("FixedColumns", "Fixedcolumns", "", "str");
   GRID_EMPOWERERContainer.setProp("PopoversInGrid", "Popoversingrid", "", "str");
   GRID_EMPOWERERContainer.setProp("Visible", "Visible", true, "bool");
   GRID_EMPOWERERContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(GRID_EMPOWERERContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"UNNAMEDTABLE1",grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id:14 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMAIL",gxz:"ZV15Mail",gxold:"OV15Mail",gxvar:"AV15Mail",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.AV15Mail=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV15Mail=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("vMAIL",gx.O.AV15Mail,true)},c2v:function(){if(this.val()!==undefined)gx.O.AV15Mail=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("vMAIL")},nac:gx.falseFn,evt:"e13202_client",values:['true','false']};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id:17 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSMS",gxz:"ZV22Sms",gxold:"OV22Sms",gxvar:"AV22Sms",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.AV22Sms=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV22Sms=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("vSMS",gx.O.AV22Sms,true)},c2v:function(){if(this.val()!==undefined)gx.O.AV22Sms=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("vSMS")},nac:gx.falseFn,evt:"e14202_client",values:['true','false']};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id:20 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDESKTOP",gxz:"ZV5Desktop",gxold:"OV5Desktop",gxvar:"AV5Desktop",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.AV5Desktop=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV5Desktop=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("vDESKTOP",gx.O.AV5Desktop,true)},c2v:function(){if(this.val()!==undefined)gx.O.AV5Desktop=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("vDESKTOP")},nac:gx.falseFn,evt:"e16202_client",values:['true','false']};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id:23 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSD",gxz:"ZV19SD",gxold:"OV19SD",gxvar:"AV19SD",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.AV19SD=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV19SD=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("vSD",gx.O.AV19SD,true)},c2v:function(){if(this.val()!==undefined)gx.O.AV19SD=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("vSD")},nac:gx.falseFn,evt:"e15202_client",values:['true','false']};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"UNNAMEDTABLE2",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"TABLEHEADER",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id:34 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNOTIFSHOWONLYSUBSCRIBEDEVENTS",gxz:"ZV17NotifShowOnlySubscribedEvents",gxold:"OV17NotifShowOnlySubscribedEvents",gxvar:"AV17NotifShowOnlySubscribedEvents",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.AV17NotifShowOnlySubscribedEvents=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV17NotifShowOnlySubscribedEvents=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("vNOTIFSHOWONLYSUBSCRIBEDEVENTS",gx.O.AV17NotifShowOnlySubscribedEvents,true)},c2v:function(){if(this.val()!==undefined)gx.O.AV17NotifShowOnlySubscribedEvents=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("vNOTIFSHOWONLYSUBSCRIBEDEVENTS")},nac:gx.falseFn,evt:"e17202_client",values:['true','false']};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id:37 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILTERFULLTEXT",gxz:"ZV7FilterFullText",gxold:"OV7FilterFullText",gxvar:"AV7FilterFullText",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7FilterFullText=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV7FilterFullText=Value},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV7FilterFullText,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.AV7FilterFullText=this.val()},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};
   this.declareDomainHdlr( 37 , function() {
   });
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[44]={ id:44 ,lvl:2,type:"svchar",len:100,dec:0,sign:false,ro:0,isacc:0,grid:43,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWWPENTITYNAME",gxz:"ZV30WWPEntityName",gxold:"OV30WWPEntityName",gxvar:"AV30WWPEntityName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.AV30WWPEntityName=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV30WWPEntityName=Value},v2c:function(row){gx.fn.setGridControlValue("vWWPENTITYNAME",row || gx.fn.currentGridRowImpl(43),gx.O.AV30WWPEntityName,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV30WWPEntityName=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vWWPENTITYNAME",row || gx.fn.currentGridRowImpl(43))},nac:gx.falseFn};
   GXValidFnc[45]={ id:45 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,isacc:0,grid:43,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWWPENTITYID",gxz:"ZV29WWPEntityId",gxold:"OV29WWPEntityId",gxvar:"AV29WWPEntityId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.AV29WWPEntityId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV29WWPEntityId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("vWWPENTITYID",row || gx.fn.currentGridRowImpl(43),gx.O.AV29WWPEntityId,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV29WWPEntityId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("vWWPENTITYID",row || gx.fn.currentGridRowImpl(43),'.')},nac:gx.falseFn};
   GXValidFnc[46]={ id:46 ,lvl:2,type:"char",len:20,dec:0,sign:false,ro:0,isacc:0,grid:43,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDETAILWEBCOMPONENT",gxz:"ZV6DetailWebComponent",gxold:"OV6DetailWebComponent",gxvar:"AV6DetailWebComponent",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.AV6DetailWebComponent=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV6DetailWebComponent=Value},v2c:function(row){gx.fn.setGridControlValue("vDETAILWEBCOMPONENT",row || gx.fn.currentGridRowImpl(43),gx.O.AV6DetailWebComponent,1)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV6DetailWebComponent=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vDETAILWEBCOMPONENT",row || gx.fn.currentGridRowImpl(43))},nac:gx.falseFn,evt:"e21202_client"};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"CELL_GRID_DWC",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};
   this.AV15Mail = false ;
   this.ZV15Mail = false ;
   this.OV15Mail = false ;
   this.AV22Sms = false ;
   this.ZV22Sms = false ;
   this.OV22Sms = false ;
   this.AV5Desktop = false ;
   this.ZV5Desktop = false ;
   this.OV5Desktop = false ;
   this.AV19SD = false ;
   this.ZV19SD = false ;
   this.OV19SD = false ;
   this.AV17NotifShowOnlySubscribedEvents = false ;
   this.ZV17NotifShowOnlySubscribedEvents = false ;
   this.OV17NotifShowOnlySubscribedEvents = false ;
   this.AV7FilterFullText = "" ;
   this.ZV7FilterFullText = "" ;
   this.OV7FilterFullText = "" ;
   this.ZV30WWPEntityName = "" ;
   this.OV30WWPEntityName = "" ;
   this.ZV29WWPEntityId = 0 ;
   this.OV29WWPEntityId = 0 ;
   this.ZV6DetailWebComponent = "" ;
   this.OV6DetailWebComponent = "" ;
   this.AV15Mail = false ;
   this.AV22Sms = false ;
   this.AV5Desktop = false ;
   this.AV19SD = false ;
   this.AV17NotifShowOnlySubscribedEvents = false ;
   this.AV7FilterFullText = "" ;
   this.AV8GridCurrentPage = 0 ;
   this.AV30WWPEntityName = "" ;
   this.AV29WWPEntityId = 0 ;
   this.AV6DetailWebComponent = "" ;
   this.A10WWPEntityId = 0 ;
   this.A12WWPEntityName = "" ;
   this.A40000GXC1 = 0 ;
   this.A11WWPSubscriptionRoleId = "" ;
   this.A23WWPSubscriptionSubscribed = false ;
   this.A1WWPUserExtendedId = "" ;
   this.A27WWPNotificationDefinitionAllowUserSubscription = false ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.A6WWPUserExtendedSMSNotif = false ;
   this.A5WWPUserExtendedEmaiNotif = false ;
   this.A8WWPUserExtendedDesktopNotif = false ;
   this.A7WWPUserExtendedMobileNotif = false ;
   this.AV41Pgmname = "" ;
   this.AV44Udparg2 = "" ;
   this.Events = {"e11202_client": ["GRIDPAGINATIONBAR.CHANGEPAGE", true] ,"e12202_client": ["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE", true] ,"e13202_client": ["VMAIL.CLICK", true] ,"e14202_client": ["VSMS.CLICK", true] ,"e15202_client": ["VSD.CLICK", true] ,"e16202_client": ["VDESKTOP.CLICK", true] ,"e17202_client": ["VNOTIFSHOWONLYSUBSCRIBEDEVENTS.CLICK", true] ,"e22202_client": ["ENTER", true] ,"e23202_client": ["CANCEL", true] ,"e21202_client": ["VDETAILWEBCOMPONENT.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{ctrl:'GRID',prop:'Rows'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV8GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV36GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["START"] = [[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV40Udparg1',fld:'vUDPARG1',pic:''},{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A5WWPUserExtendedEmaiNotif',fld:'WWPUSEREXTENDEDEMAINOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'gx.fn.getCtrlProperty("CELL_GRID_DWC","Class")',ctrl:'CELL_GRID_DWC',prop:'Class'},{ctrl:'GRID',prop:'Rows'},{av:'this.GRID_EMPOWERERContainer.GridInternalName',ctrl:'GRID_EMPOWERER',prop:'GridInternalName'},{ctrl:'FORM',prop:'Caption'},{av:'this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'},{av:'AV7FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'this.GRIDPAGINATIONBARContainer.SelectedPage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{ctrl:'GRID',prop:'Rows'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["GRID.LOAD"] = [[{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{ctrl:'GRID',prop:'Rows'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV6DetailWebComponent',fld:'vDETAILWEBCOMPONENT',pic:''},{av:'AV30WWPEntityName',fld:'vWWPENTITYNAME',pic:''},{av:'AV29WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A40000GXC1',fld:'GXC1',pic:'999999999'},{av:'AV9GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["VDETAILWEBCOMPONENT.CLICK"] = [[{av:'AV29WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{ctrl:'GRID_DWC'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["VMAIL.CLICK"] = [[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["VSMS.CLICK"] = [[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["VSD.CLICK"] = [[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["VDESKTOP.CLICK"] = [[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.EvtParms["VNOTIFSHOWONLYSUBSCRIBEDEVENTS.CLICK"] = [[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}],[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]];
   this.setVCMap("AV41Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A12WWPEntityName", "WWPENTITYNAME", 0, "svchar", 100, 0);
   this.setVCMap("A10WWPEntityId", "WWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("A27WWPNotificationDefinitionAllowUserSubscription", "WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION", 0, "boolean", 4, 0);
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("AV44Udparg2", "vUDPARG2", 0, "char", 40, 0);
   this.setVCMap("A23WWPSubscriptionSubscribed", "WWPSUBSCRIPTIONSUBSCRIBED", 0, "boolean", 4, 0);
   this.setVCMap("A11WWPSubscriptionRoleId", "WWPSUBSCRIPTIONROLEID", 0, "char", 40, 0);
   this.setVCMap("A14WWPNotificationDefinitionId", "WWPNOTIFICATIONDEFINITIONID", 0, "int", 10, 0);
   this.setVCMap("AV41Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A12WWPEntityName", "WWPENTITYNAME", 0, "svchar", 100, 0);
   this.setVCMap("A10WWPEntityId", "WWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("A27WWPNotificationDefinitionAllowUserSubscription", "WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION", 0, "boolean", 4, 0);
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("AV44Udparg2", "vUDPARG2", 0, "char", 40, 0);
   this.setVCMap("A23WWPSubscriptionSubscribed", "WWPSUBSCRIPTIONSUBSCRIBED", 0, "boolean", 4, 0);
   this.setVCMap("A11WWPSubscriptionRoleId", "WWPSUBSCRIPTIONROLEID", 0, "char", 40, 0);
   this.setVCMap("A14WWPNotificationDefinitionId", "WWPNOTIFICATIONDEFINITIONID", 0, "int", 10, 0);
   this.setVCMap("AV41Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A12WWPEntityName", "WWPENTITYNAME", 0, "svchar", 100, 0);
   this.setVCMap("A10WWPEntityId", "WWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("A27WWPNotificationDefinitionAllowUserSubscription", "WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION", 0, "boolean", 4, 0);
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("AV44Udparg2", "vUDPARG2", 0, "char", 40, 0);
   this.setVCMap("A23WWPSubscriptionSubscribed", "WWPSUBSCRIPTIONSUBSCRIBED", 0, "boolean", 4, 0);
   this.setVCMap("A11WWPSubscriptionRoleId", "WWPSUBSCRIPTIONROLEID", 0, "char", 40, 0);
   this.setVCMap("A14WWPNotificationDefinitionId", "WWPNOTIFICATIONDEFINITIONID", 0, "int", 10, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV41Pgmname"});
   GridContainer.addRefreshingVar(this.GXValidFnc[34]);
   GridContainer.addRefreshingVar(this.GXValidFnc[37]);
   GridContainer.addRefreshingVar({rfrVar:"A12WWPEntityName"});
   GridContainer.addRefreshingVar({rfrVar:"A10WWPEntityId"});
   GridContainer.addRefreshingVar({rfrVar:"A27WWPNotificationDefinitionAllowUserSubscription"});
   GridContainer.addRefreshingVar({rfrVar:"A1WWPUserExtendedId"});
   GridContainer.addRefreshingVar({rfrVar:"AV44Udparg2"});
   GridContainer.addRefreshingVar({rfrVar:"A23WWPSubscriptionSubscribed"});
   GridContainer.addRefreshingVar({rfrVar:"A11WWPSubscriptionRoleId"});
   GridContainer.addRefreshingVar({rfrVar:"A14WWPNotificationDefinitionId"});
   GridContainer.addRefreshingParm({rfrVar:"AV41Pgmname"});
   GridContainer.addRefreshingParm(this.GXValidFnc[34]);
   GridContainer.addRefreshingParm(this.GXValidFnc[37]);
   GridContainer.addRefreshingParm({rfrVar:"A12WWPEntityName"});
   GridContainer.addRefreshingParm({rfrVar:"A10WWPEntityId"});
   GridContainer.addRefreshingParm({rfrVar:"A27WWPNotificationDefinitionAllowUserSubscription"});
   GridContainer.addRefreshingParm({rfrVar:"A1WWPUserExtendedId"});
   GridContainer.addRefreshingParm({rfrVar:"AV44Udparg2"});
   GridContainer.addRefreshingParm({rfrVar:"A23WWPSubscriptionSubscribed"});
   GridContainer.addRefreshingParm({rfrVar:"A11WWPSubscriptionRoleId"});
   GridContainer.addRefreshingParm({rfrVar:"A14WWPNotificationDefinitionId"});
   GridContainer.addRefreshingParm(this.GXValidFnc[14]);
   GridContainer.addRefreshingParm(this.GXValidFnc[17]);
   GridContainer.addRefreshingParm(this.GXValidFnc[20]);
   GridContainer.addRefreshingParm(this.GXValidFnc[23]);
   this.Initialize( );
   this.setComponent({id: "GRID_DWC" ,GXClass: null , Prefix: "W0052" , lvl: 1 });
   this.setSDTMapping( "WWPBaseObjects\\WWPGridState" , {
      "FilterValues":{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.subscriptions.wwp_subscriptionssettings);});
