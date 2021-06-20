gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.subscriptions.wwp_subscriptionspanel', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.subscriptions.wwp_subscriptionspanel" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.anyGridBaseTable = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV28Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.A1WWPUserExtendedId=gx.fn.getControlValue("WWPUSEREXTENDEDID") ;
      this.AV31Udparg1=gx.fn.getControlValue("vUDPARG1") ;
      this.A23WWPSubscriptionSubscribed=gx.fn.getControlValue("WWPSUBSCRIPTIONSUBSCRIBED") ;
      this.A11WWPSubscriptionRoleId=gx.fn.getControlValue("WWPSUBSCRIPTIONROLEID") ;
      this.AV23WWPSubscriptionRoleIdCollection=gx.fn.getControlValue("vWWPSUBSCRIPTIONROLEIDCOLLECTION") ;
      this.AV8WWPNotificationId=gx.fn.getIntegerValue("vWWPNOTIFICATIONID",'.') ;
      this.A22WWPSubscriptionEntityRecordId=gx.fn.getControlValue("WWPSUBSCRIPTIONENTITYRECORDID") ;
      this.AV20WWPSubscriptionEntityRecordId=gx.fn.getControlValue("vWWPSUBSCRIPTIONENTITYRECORDID") ;
      this.A13WWPSubscriptionId=gx.fn.getIntegerValue("WWPSUBSCRIPTIONID",'.') ;
      this.AV24WWPNotificationDefinitionId=gx.fn.getIntegerValue("vWWPNOTIFICATIONDEFINITIONID",'.') ;
      this.AV14RecordAttDescription=gx.fn.getControlValue("vRECORDATTDESCRIPTION") ;
      this.AV6WWPEntityName=gx.fn.getControlValue("vWWPENTITYNAME") ;
      this.AV7WWPNotificationAppliesTo=gx.fn.getIntegerValue("vWWPNOTIFICATIONAPPLIESTO",'.') ;
      this.AV5WWPEntityId=gx.fn.getIntegerValue("vWWPENTITYID",'.') ;
      this.AV7WWPNotificationAppliesTo=gx.fn.getIntegerValue("vWWPNOTIFICATIONAPPLIESTO",'.') ;
      this.AV28Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.A1WWPUserExtendedId=gx.fn.getControlValue("WWPUSEREXTENDEDID") ;
      this.AV31Udparg1=gx.fn.getControlValue("vUDPARG1") ;
      this.A23WWPSubscriptionSubscribed=gx.fn.getControlValue("WWPSUBSCRIPTIONSUBSCRIBED") ;
      this.A11WWPSubscriptionRoleId=gx.fn.getControlValue("WWPSUBSCRIPTIONROLEID") ;
      this.AV23WWPSubscriptionRoleIdCollection=gx.fn.getControlValue("vWWPSUBSCRIPTIONROLEIDCOLLECTION") ;
      this.AV8WWPNotificationId=gx.fn.getIntegerValue("vWWPNOTIFICATIONID",'.') ;
      this.A22WWPSubscriptionEntityRecordId=gx.fn.getControlValue("WWPSUBSCRIPTIONENTITYRECORDID") ;
      this.AV20WWPSubscriptionEntityRecordId=gx.fn.getControlValue("vWWPSUBSCRIPTIONENTITYRECORDID") ;
      this.A13WWPSubscriptionId=gx.fn.getIntegerValue("WWPSUBSCRIPTIONID",'.') ;
      this.AV24WWPNotificationDefinitionId=gx.fn.getIntegerValue("vWWPNOTIFICATIONDEFINITIONID",'.') ;
   };
   this.e15252_client=function()
   {
      return this.executeServerEvent("'FIRSTPAGE'", true, arguments[0], false, false);
   };
   this.e16252_client=function()
   {
      return this.executeServerEvent("'PREVIOUSPAGE'", true, arguments[0], false, false);
   };
   this.e17252_client=function()
   {
      return this.executeServerEvent("'NEXTPAGE'", true, arguments[0], false, false);
   };
   this.e18252_client=function()
   {
      return this.executeServerEvent("'LASTPAGE'", true, arguments[0], false, false);
   };
   this.e11252_client=function()
   {
      return this.executeServerEvent("TABLESUBSCRIPTIONITEM.CLICK", true, arguments[0], false, true);
   };
   this.e19252_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e20252_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,25,26,28,29];
   this.GXLastCtrlId =29;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",9,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.subscriptions.wwp_subscriptionspanel",[],true,1,false,true,0,false,false,false,"",0,"px",0,"px","Novo registro",true,false,true,null,null,false,"",true,[1,1,1,1],false,0,false,false);
   var GridContainer = this.GridContainer;
   GridContainer.startDiv(10,"Unnamedtablefsgrid","0px","0px");
   GridContainer.startDiv(11,"","0px","0px");
   GridContainer.startDiv(12,"","0px","0px");
   GridContainer.startDiv(13,"Tablesubscriptionitem","0px","0px");
   GridContainer.startDiv(14,"","0px","0px");
   GridContainer.startDiv(15,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addCheckBox("Includenotification",16,"vINCLUDENOTIFICATION","","","IncludeNotification","boolean","true","false",null,true,false,4,"chr","");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(17,"","0px","0px");
   GridContainer.startDiv(18,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addMultipleLineEdit(25,19,"WWPNOTIFICATIONDEFINITIONDESCRIPTION","","WWPNotificationDefinitionDescription","svchar",80,"chr",3,"row","200",200,"left",null,true,false,0,"");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(20,"","0px","0px");
   GridContainer.startDiv(21,"","0px","0px");
   GridContainer.startTable("Unnamedtablecontentfsgrid",22,"0px");
   GridContainer.startRow("","","","","","");
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(25,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(14,26,"WWPNOTIFICATIONDEFINITIONID","","","WWPNotificationDefinitionId","int",10,"chr",10,10,"right",null,[],14,"WWPNotificationDefinitionId",true,0,false,false,"Attribute",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(28,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit("Wwpsubscriptionid",29,"vWWPSUBSCRIPTIONID","","","WWPSubscriptionId","int",10,"chr",10,10,"right",null,[],"Wwpsubscriptionid","WWPSubscriptionId",true,0,false,false,"Attribute",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.endRow();
   GridContainer.endTable();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"UNNAMEDTABLEFSGRID",grid:9};
   GXValidFnc[11]={ id: 11, fld:"",grid:9};
   GXValidFnc[12]={ id: 12, fld:"",grid:9};
   GXValidFnc[13]={ id: 13, fld:"TABLESUBSCRIPTIONITEM",grid:9,evt:"e11252_client"};
   GXValidFnc[14]={ id: 14, fld:"",grid:9};
   GXValidFnc[15]={ id: 15, fld:"",grid:9};
   GXValidFnc[16]={ id:16 ,lvl:2,type:"boolean",len:4,dec:0,sign:false,ro:0,isacc:0,grid:9,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vINCLUDENOTIFICATION",gxz:"ZV12IncludeNotification",gxold:"OV12IncludeNotification",gxvar:"AV12IncludeNotification",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV12IncludeNotification=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV12IncludeNotification=gx.lang.booleanValue(Value)},v2c:function(row){gx.fn.setGridCheckBoxValue("vINCLUDENOTIFICATION",row || gx.fn.currentGridRowImpl(9),gx.O.AV12IncludeNotification,true)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV12IncludeNotification=gx.lang.booleanValue(this.val(row))},val:function(row){return gx.fn.getGridControlValue("vINCLUDENOTIFICATION",row || gx.fn.currentGridRowImpl(9))},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[17]={ id: 17, fld:"",grid:9};
   GXValidFnc[18]={ id: 18, fld:"",grid:9};
   GXValidFnc[19]={ id:19 ,lvl:2,type:"svchar",len:200,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:9,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONDESCRIPTION",gxz:"Z25WWPNotificationDefinitionDescription",gxold:"O25WWPNotificationDefinitionDescription",gxvar:"A25WWPNotificationDefinitionDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A25WWPNotificationDefinitionDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z25WWPNotificationDefinitionDescription=Value},v2c:function(row){gx.fn.setGridControlValue("WWPNOTIFICATIONDEFINITIONDESCRIPTION",row || gx.fn.currentGridRowImpl(9),gx.O.A25WWPNotificationDefinitionDescription,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A25WWPNotificationDefinitionDescription=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPNOTIFICATIONDEFINITIONDESCRIPTION",row || gx.fn.currentGridRowImpl(9))},nac:gx.falseFn};
   GXValidFnc[20]={ id: 20, fld:"",grid:9};
   GXValidFnc[21]={ id: 21, fld:"",grid:9};
   GXValidFnc[22]={ id: 22, fld:"UNNAMEDTABLECONTENTFSGRID",grid:9};
   GXValidFnc[25]={ id: 25, fld:"",grid:9};
   GXValidFnc[26]={ id:26 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:9,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONID",gxz:"Z14WWPNotificationDefinitionId",gxold:"O14WWPNotificationDefinitionId",gxvar:"A14WWPNotificationDefinitionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z14WWPNotificationDefinitionId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("WWPNOTIFICATIONDEFINITIONID",row || gx.fn.currentGridRowImpl(9),gx.O.A14WWPNotificationDefinitionId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("WWPNOTIFICATIONDEFINITIONID",row || gx.fn.currentGridRowImpl(9),'.')},nac:gx.falseFn};
   GXValidFnc[28]={ id: 28, fld:"",grid:9};
   GXValidFnc[29]={ id:29 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,isacc:0,grid:9,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWWPSUBSCRIPTIONID",gxz:"ZV22WWPSubscriptionId",gxold:"OV22WWPSubscriptionId",gxvar:"AV22WWPSubscriptionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.AV22WWPSubscriptionId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV22WWPSubscriptionId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("vWWPSUBSCRIPTIONID",row || gx.fn.currentGridRowImpl(9),gx.O.AV22WWPSubscriptionId,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV22WWPSubscriptionId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("vWWPSUBSCRIPTIONID",row || gx.fn.currentGridRowImpl(9),'.')},nac:gx.falseFn};
   this.ZV12IncludeNotification = false ;
   this.OV12IncludeNotification = false ;
   this.Z25WWPNotificationDefinitionDescription = "" ;
   this.O25WWPNotificationDefinitionDescription = "" ;
   this.Z14WWPNotificationDefinitionId = 0 ;
   this.O14WWPNotificationDefinitionId = 0 ;
   this.ZV22WWPSubscriptionId = 0 ;
   this.OV22WWPSubscriptionId = 0 ;
   this.AV6WWPEntityName = "" ;
   this.AV7WWPNotificationAppliesTo = 0 ;
   this.AV20WWPSubscriptionEntityRecordId = "" ;
   this.AV14RecordAttDescription = "" ;
   this.A27WWPNotificationDefinitionAllowUserSubscription = false ;
   this.A26WWPNotificationDefinitionAppliesTo = 0 ;
   this.A10WWPEntityId = 0 ;
   this.AV12IncludeNotification = false ;
   this.A25WWPNotificationDefinitionDescription = "" ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.AV22WWPSubscriptionId = 0 ;
   this.A22WWPSubscriptionEntityRecordId = "" ;
   this.A11WWPSubscriptionRoleId = "" ;
   this.A23WWPSubscriptionSubscribed = false ;
   this.A1WWPUserExtendedId = "" ;
   this.A13WWPSubscriptionId = 0 ;
   this.A12WWPEntityName = "" ;
   this.AV28Pgmname = "" ;
   this.AV31Udparg1 = "" ;
   this.AV23WWPSubscriptionRoleIdCollection = [ ] ;
   this.AV8WWPNotificationId = 0 ;
   this.AV24WWPNotificationDefinitionId = 0 ;
   this.AV5WWPEntityId = 0 ;
   this.Events = {"e15252_client": ["'FIRSTPAGE'", true] ,"e16252_client": ["'PREVIOUSPAGE'", true] ,"e17252_client": ["'NEXTPAGE'", true] ,"e18252_client": ["'LASTPAGE'", true] ,"e11252_client": ["TABLESUBSCRIPTIONITEM.CLICK", true] ,"e19252_client": ["ENTER", true] ,"e20252_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'sPrefix'},{ctrl:'GRID',prop:'Rows'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true}],[]];
   this.EvtParms["START"] = [[{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'AV6WWPEntityName',fld:'vWWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}]];
   this.EvtParms["GRID.LOAD"] = [[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true}],[{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV12IncludeNotification',fld:'vINCLUDENOTIFICATION',pic:''},{av:'AV22WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'}]];
   this.EvtParms["'FIRSTPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}],[]];
   this.EvtParms["'PREVIOUSPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}],[]];
   this.EvtParms["'NEXTPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}],[]];
   this.EvtParms["'LASTPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONDEFINITIONID","Visible")',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vWWPSUBSCRIPTIONID","Visible")',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}],[]];
   this.EvtParms["TABLESUBSCRIPTIONITEM.CLICK"] = [[{av:'AV12IncludeNotification',fld:'vINCLUDENOTIFICATION',grid:9,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_9',ctrl:'GRID',grid:9,prop:'GridRC'},{av:'AV22WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',grid:9,pic:'ZZZZZZZZZ9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',grid:9,pic:'ZZZZZZZZZ9'},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV14RecordAttDescription',fld:'vRECORDATTDESCRIPTION',pic:''}],[{av:'AV12IncludeNotification',fld:'vINCLUDENOTIFICATION',pic:''},{av:'AV22WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'}]];
   this.setVCMap("AV28Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("AV31Udparg1", "vUDPARG1", 0, "char", 40, 0);
   this.setVCMap("A23WWPSubscriptionSubscribed", "WWPSUBSCRIPTIONSUBSCRIBED", 0, "boolean", 4, 0);
   this.setVCMap("A11WWPSubscriptionRoleId", "WWPSUBSCRIPTIONROLEID", 0, "char", 40, 0);
   this.setVCMap("AV23WWPSubscriptionRoleIdCollection", "vWWPSUBSCRIPTIONROLEIDCOLLECTION", 0, "Collchar", 0, 0);
   this.setVCMap("AV8WWPNotificationId", "vWWPNOTIFICATIONID", 0, "int", 10, 0);
   this.setVCMap("A22WWPSubscriptionEntityRecordId", "WWPSUBSCRIPTIONENTITYRECORDID", 0, "svchar", 2000, 0);
   this.setVCMap("AV20WWPSubscriptionEntityRecordId", "vWWPSUBSCRIPTIONENTITYRECORDID", 0, "svchar", 2000, 0);
   this.setVCMap("A13WWPSubscriptionId", "WWPSUBSCRIPTIONID", 0, "int", 10, 0);
   this.setVCMap("AV24WWPNotificationDefinitionId", "vWWPNOTIFICATIONDEFINITIONID", 0, "int", 10, 0);
   this.setVCMap("AV14RecordAttDescription", "vRECORDATTDESCRIPTION", 0, "svchar", 40, 0);
   this.setVCMap("AV6WWPEntityName", "vWWPENTITYNAME", 0, "svchar", 100, 0);
   this.setVCMap("AV7WWPNotificationAppliesTo", "vWWPNOTIFICATIONAPPLIESTO", 0, "int", 1, 0);
   this.setVCMap("AV5WWPEntityId", "vWWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("AV7WWPNotificationAppliesTo", "vWWPNOTIFICATIONAPPLIESTO", 0, "int", 1, 0);
   this.setVCMap("AV28Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("AV31Udparg1", "vUDPARG1", 0, "char", 40, 0);
   this.setVCMap("A23WWPSubscriptionSubscribed", "WWPSUBSCRIPTIONSUBSCRIBED", 0, "boolean", 4, 0);
   this.setVCMap("A11WWPSubscriptionRoleId", "WWPSUBSCRIPTIONROLEID", 0, "char", 40, 0);
   this.setVCMap("AV23WWPSubscriptionRoleIdCollection", "vWWPSUBSCRIPTIONROLEIDCOLLECTION", 0, "Collchar", 0, 0);
   this.setVCMap("AV8WWPNotificationId", "vWWPNOTIFICATIONID", 0, "int", 10, 0);
   this.setVCMap("A22WWPSubscriptionEntityRecordId", "WWPSUBSCRIPTIONENTITYRECORDID", 0, "svchar", 2000, 0);
   this.setVCMap("AV20WWPSubscriptionEntityRecordId", "vWWPSUBSCRIPTIONENTITYRECORDID", 0, "svchar", 2000, 0);
   this.setVCMap("A13WWPSubscriptionId", "WWPSUBSCRIPTIONID", 0, "int", 10, 0);
   this.setVCMap("AV24WWPNotificationDefinitionId", "vWWPNOTIFICATIONDEFINITIONID", 0, "int", 10, 0);
   this.setVCMap("AV5WWPEntityId", "vWWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("AV7WWPNotificationAppliesTo", "vWWPNOTIFICATIONAPPLIESTO", 0, "int", 1, 0);
   this.setVCMap("AV28Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("AV31Udparg1", "vUDPARG1", 0, "char", 40, 0);
   this.setVCMap("A23WWPSubscriptionSubscribed", "WWPSUBSCRIPTIONSUBSCRIBED", 0, "boolean", 4, 0);
   this.setVCMap("A11WWPSubscriptionRoleId", "WWPSUBSCRIPTIONROLEID", 0, "char", 40, 0);
   this.setVCMap("AV23WWPSubscriptionRoleIdCollection", "vWWPSUBSCRIPTIONROLEIDCOLLECTION", 0, "Collchar", 0, 0);
   this.setVCMap("AV8WWPNotificationId", "vWWPNOTIFICATIONID", 0, "int", 10, 0);
   this.setVCMap("A22WWPSubscriptionEntityRecordId", "WWPSUBSCRIPTIONENTITYRECORDID", 0, "svchar", 2000, 0);
   this.setVCMap("AV20WWPSubscriptionEntityRecordId", "vWWPSUBSCRIPTIONENTITYRECORDID", 0, "svchar", 2000, 0);
   this.setVCMap("A13WWPSubscriptionId", "WWPSUBSCRIPTIONID", 0, "int", 10, 0);
   this.setVCMap("AV24WWPNotificationDefinitionId", "vWWPNOTIFICATIONDEFINITIONID", 0, "int", 10, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV5WWPEntityId"});
   GridContainer.addRefreshingVar({rfrVar:"AV7WWPNotificationAppliesTo"});
   GridContainer.addRefreshingVar({rfrVar:"AV28Pgmname"});
   GridContainer.addRefreshingVar({rfrVar:"A14WWPNotificationDefinitionId", rfrProp:"Visible", gxAttId:"14"});
   GridContainer.addRefreshingVar({rfrVar:"AV22WWPSubscriptionId", rfrProp:"Visible", gxAttId:"Wwpsubscriptionid"});
   GridContainer.addRefreshingVar({rfrVar:"A1WWPUserExtendedId"});
   GridContainer.addRefreshingVar({rfrVar:"AV31Udparg1"});
   GridContainer.addRefreshingVar({rfrVar:"A23WWPSubscriptionSubscribed"});
   GridContainer.addRefreshingVar({rfrVar:"A11WWPSubscriptionRoleId"});
   GridContainer.addRefreshingVar({rfrVar:"AV23WWPSubscriptionRoleIdCollection"});
   GridContainer.addRefreshingVar({rfrVar:"AV8WWPNotificationId"});
   GridContainer.addRefreshingVar({rfrVar:"A22WWPSubscriptionEntityRecordId"});
   GridContainer.addRefreshingVar({rfrVar:"AV20WWPSubscriptionEntityRecordId"});
   GridContainer.addRefreshingVar({rfrVar:"A13WWPSubscriptionId"});
   GridContainer.addRefreshingVar({rfrVar:"AV24WWPNotificationDefinitionId"});
   GridContainer.addRefreshingParm({rfrVar:"AV5WWPEntityId"});
   GridContainer.addRefreshingParm({rfrVar:"AV7WWPNotificationAppliesTo"});
   GridContainer.addRefreshingParm({rfrVar:"AV28Pgmname"});
   GridContainer.addRefreshingParm({rfrVar:"A14WWPNotificationDefinitionId", rfrProp:"Visible", gxAttId:"14"});
   GridContainer.addRefreshingParm({rfrVar:"AV22WWPSubscriptionId", rfrProp:"Visible", gxAttId:"Wwpsubscriptionid"});
   GridContainer.addRefreshingParm({rfrVar:"A1WWPUserExtendedId"});
   GridContainer.addRefreshingParm({rfrVar:"AV31Udparg1"});
   GridContainer.addRefreshingParm({rfrVar:"A23WWPSubscriptionSubscribed"});
   GridContainer.addRefreshingParm({rfrVar:"A11WWPSubscriptionRoleId"});
   GridContainer.addRefreshingParm({rfrVar:"AV23WWPSubscriptionRoleIdCollection"});
   GridContainer.addRefreshingParm({rfrVar:"AV8WWPNotificationId"});
   GridContainer.addRefreshingParm({rfrVar:"A22WWPSubscriptionEntityRecordId"});
   GridContainer.addRefreshingParm({rfrVar:"AV20WWPSubscriptionEntityRecordId"});
   GridContainer.addRefreshingParm({rfrVar:"A13WWPSubscriptionId"});
   GridContainer.addRefreshingParm({rfrVar:"AV24WWPNotificationDefinitionId"});
   this.Initialize( );
   this.setSDTMapping( "WWPBaseObjects\\WWPGridState" , {
      "FilterValues":{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},
      "DynamicFilters":{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});
   this.setSDTMapping( "WWPBaseObjects\\WWPGridState.DynamicFilter" , {
      "Dsc":{extr:"d"}});
});
