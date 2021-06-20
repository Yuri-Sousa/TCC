gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.notifications.common.wwp_visualizenotification', false, function () {
   this.ServerClass =  "wwpbaseobjects.notifications.common.wwp_visualizenotification" ;
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
      this.AV7WWPNotificationId=gx.fn.getIntegerValue("vWWPNOTIFICATIONID",'.') ;
   };
   this.e121z2_client=function()
   {
      return this.executeServerEvent("'DOMARKASREAD'", true, null, false, false);
   };
   this.e141z2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e151z2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31];
   this.GXLastCtrlId =31;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"TABLEFSCARD",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"UNNAMEDTABLE1",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"NOTIFICATIONITEMICON", format:2,grid:0, ctrltype: "textblock"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"TABLECONTENT",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"UNNAMEDTABLE2",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id:22 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:1,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONTITLE",gxz:"Z69WWPNotificationTitle",gxold:"O69WWPNotificationTitle",gxvar:"A69WWPNotificationTitle",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A69WWPNotificationTitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z69WWPNotificationTitle=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONTITLE",gx.O.A69WWPNotificationTitle,0)},c2v:function(){if(this.val()!==undefined)gx.O.A69WWPNotificationTitle=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONTITLE")},nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",gxz:"Z37WWPNotificationCreated",gxold:"O37WWPNotificationCreated",gxvar:"A37WWPNotificationCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONCREATED",gx.O.A37WWPNotificationCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 25 , function() {
   });
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"MARKASREAD", format:1,grid:0,evt:"e121z2_client", ctrltype: "textblock"};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:1,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONSHORTDESCRIPTION",gxz:"Z70WWPNotificationShortDescription",gxold:"O70WWPNotificationShortDescription",gxvar:"A70WWPNotificationShortDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A70WWPNotificationShortDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z70WWPNotificationShortDescription=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONSHORTDESCRIPTION",gx.O.A70WWPNotificationShortDescription,0)},c2v:function(){if(this.val()!==undefined)gx.O.A70WWPNotificationShortDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONSHORTDESCRIPTION")},nac:gx.falseFn};
   this.A69WWPNotificationTitle = "" ;
   this.Z69WWPNotificationTitle = "" ;
   this.O69WWPNotificationTitle = "" ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.Z37WWPNotificationCreated = gx.date.nullDate() ;
   this.O37WWPNotificationCreated = gx.date.nullDate() ;
   this.A70WWPNotificationShortDescription = "" ;
   this.Z70WWPNotificationShortDescription = "" ;
   this.O70WWPNotificationShortDescription = "" ;
   this.A69WWPNotificationTitle = "" ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.A70WWPNotificationShortDescription = "" ;
   this.AV7WWPNotificationId = 0 ;
   this.A16WWPNotificationId = 0 ;
   this.A73WWPNotificationIsRead = false ;
   this.A1WWPUserExtendedId = "" ;
   this.A71WWPNotificationLink = "" ;
   this.A54WWPNotificationMetadata = "" ;
   this.Events = {"e121z2_client": ["'DOMARKASREAD'", true] ,"e141z2_client": ["ENTER", true] ,"e151z2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'AV7WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["START"] = [[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV13Pgmname',fld:'vPGMNAME',pic:''},{av:'A71WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:''},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''}],[{av:'gx.fn.getCtrlProperty("TABLEMAIN","Width")',ctrl:'TABLEMAIN',prop:'Width'}]];
   this.EvtParms["'DOMARKASREAD'"] = [[{av:'AV7WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["LOAD"] = [[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'gx.fn.getCtrlProperty("MARKASREAD","Caption")',ctrl:'MARKASREAD',prop:'Caption'},{av:'gx.fn.getCtrlProperty("MARKASREAD","Tooltiptext")',ctrl:'MARKASREAD',prop:'Tooltiptext'}]];
   this.setVCMap("AV7WWPNotificationId", "vWWPNOTIFICATIONID", 0, "int", 10, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.notifications.common.wwp_visualizenotification);});
