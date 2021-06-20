gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.subscriptions.wwp_subscription', false, function () {
   this.ServerClass =  "wwpbaseobjects.subscriptions.wwp_subscription" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A10WWPEntityId=gx.fn.getIntegerValue("WWPENTITYID",'.') ;
   };
   this.Valid_Wwpsubscriptionid=function()
   {
      return this.validSrvEvt("Valid_Wwpsubscriptionid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpnotificationdefinitionid=function()
   {
      return this.validSrvEvt("Valid_Wwpnotificationdefinitionid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpuserextendedid=function()
   {
      return this.validSrvEvt("Valid_Wwpuserextendedid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e11033_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12033_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82];
   this.GXLastCtrlId =82;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"TABLEMAIN",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13033_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14033_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15033_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16033_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17033_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpsubscriptionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSUBSCRIPTIONID",gxz:"Z13WWPSubscriptionId",gxold:"O13WWPSubscriptionId",gxvar:"A13WWPSubscriptionId",ucs:[],op:[48,33,73,68,63,58],ip:[48,33,73,68,63,58,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A13WWPSubscriptionId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z13WWPSubscriptionId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPSUBSCRIPTIONID",gx.O.A13WWPSubscriptionId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A13WWPSubscriptionId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPSUBSCRIPTIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONID",gxz:"Z14WWPNotificationDefinitionId",gxold:"O14WWPNotificationDefinitionId",gxvar:"A14WWPNotificationDefinitionId",ucs:[],op:[43,38],ip:[43,38,33],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z14WWPNotificationDefinitionId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONID",gx.O.A14WWPNotificationDefinitionId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 33 , function() {
   });
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:1,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONDESCRIPTION",gxz:"Z25WWPNotificationDefinitionDescription",gxold:"O25WWPNotificationDefinitionDescription",gxvar:"A25WWPNotificationDefinitionDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A25WWPNotificationDefinitionDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z25WWPNotificationDefinitionDescription=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONDESCRIPTION",gx.O.A25WWPNotificationDefinitionDescription,0)},c2v:function(){if(this.val()!==undefined)gx.O.A25WWPNotificationDefinitionDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONDESCRIPTION")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYNAME",gxz:"Z12WWPEntityName",gxold:"O12WWPEntityName",gxvar:"A12WWPEntityName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A12WWPEntityName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z12WWPEntityName=Value},v2c:function(){gx.fn.setControlValue("WWPENTITYNAME",gx.O.A12WWPEntityName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A12WWPEntityName=this.val()},val:function(){return gx.fn.getControlValue("WWPENTITYNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 43 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"char",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpuserextendedid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDID",gxz:"Z1WWPUserExtendedId",gxold:"O1WWPUserExtendedId",gxvar:"A1WWPUserExtendedId",ucs:[],op:[53],ip:[53,48],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1WWPUserExtendedId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1WWPUserExtendedId=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDID",gx.O.A1WWPUserExtendedId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1WWPUserExtendedId=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDID")},nac:gx.falseFn};
   this.declareDomainHdlr( 48 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",gxz:"Z2WWPUserExtendedFullName",gxold:"O2WWPUserExtendedFullName",gxvar:"A2WWPUserExtendedFullName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2WWPUserExtendedFullName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2WWPUserExtendedFullName=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDFULLNAME",gx.O.A2WWPUserExtendedFullName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2WWPUserExtendedFullName=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDFULLNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"svchar",len:2000,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSUBSCRIPTIONENTITYRECORDID",gxz:"Z22WWPSubscriptionEntityRecordId",gxold:"O22WWPSubscriptionEntityRecordId",gxvar:"A22WWPSubscriptionEntityRecordId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A22WWPSubscriptionEntityRecordId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z22WWPSubscriptionEntityRecordId=Value},v2c:function(){gx.fn.setControlValue("WWPSUBSCRIPTIONENTITYRECORDID",gx.O.A22WWPSubscriptionEntityRecordId,0)},c2v:function(){if(this.val()!==undefined)gx.O.A22WWPSubscriptionEntityRecordId=this.val()},val:function(){return gx.fn.getControlValue("WWPSUBSCRIPTIONENTITYRECORDID")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSUBSCRIPTIONENTITYRECORDDESCRIPTION",gxz:"Z24WWPSubscriptionEntityRecordDescription",gxold:"O24WWPSubscriptionEntityRecordDescription",gxvar:"A24WWPSubscriptionEntityRecordDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A24WWPSubscriptionEntityRecordDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z24WWPSubscriptionEntityRecordDescription=Value},v2c:function(){gx.fn.setControlValue("WWPSUBSCRIPTIONENTITYRECORDDESCRIPTION",gx.O.A24WWPSubscriptionEntityRecordDescription,0)},c2v:function(){if(this.val()!==undefined)gx.O.A24WWPSubscriptionEntityRecordDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPSUBSCRIPTIONENTITYRECORDDESCRIPTION")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"char",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSUBSCRIPTIONROLEID",gxz:"Z11WWPSubscriptionRoleId",gxold:"O11WWPSubscriptionRoleId",gxvar:"A11WWPSubscriptionRoleId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A11WWPSubscriptionRoleId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z11WWPSubscriptionRoleId=Value},v2c:function(){gx.fn.setControlValue("WWPSUBSCRIPTIONROLEID",gx.O.A11WWPSubscriptionRoleId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A11WWPSubscriptionRoleId=this.val()},val:function(){return gx.fn.getControlValue("WWPSUBSCRIPTIONROLEID")},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSUBSCRIPTIONSUBSCRIBED",gxz:"Z23WWPSubscriptionSubscribed",gxold:"O23WWPSubscriptionSubscribed",gxvar:"A23WWPSubscriptionSubscribed",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A23WWPSubscriptionSubscribed=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z23WWPSubscriptionSubscribed=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("WWPSUBSCRIPTIONSUBSCRIBED",gx.O.A23WWPSubscriptionSubscribed,true)},c2v:function(){if(this.val()!==undefined)gx.O.A23WWPSubscriptionSubscribed=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPSUBSCRIPTIONSUBSCRIBED")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"BTN_ENTER",grid:0,evt:"e11033_client",std:"ENTER"};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"BTN_CANCEL",grid:0,evt:"e12033_client"};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"BTN_DELETE",grid:0,evt:"e18033_client",std:"DELETE"};
   this.A13WWPSubscriptionId = 0 ;
   this.Z13WWPSubscriptionId = 0 ;
   this.O13WWPSubscriptionId = 0 ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.Z14WWPNotificationDefinitionId = 0 ;
   this.O14WWPNotificationDefinitionId = 0 ;
   this.A25WWPNotificationDefinitionDescription = "" ;
   this.Z25WWPNotificationDefinitionDescription = "" ;
   this.O25WWPNotificationDefinitionDescription = "" ;
   this.A12WWPEntityName = "" ;
   this.Z12WWPEntityName = "" ;
   this.O12WWPEntityName = "" ;
   this.A1WWPUserExtendedId = "" ;
   this.Z1WWPUserExtendedId = "" ;
   this.O1WWPUserExtendedId = "" ;
   this.A2WWPUserExtendedFullName = "" ;
   this.Z2WWPUserExtendedFullName = "" ;
   this.O2WWPUserExtendedFullName = "" ;
   this.A22WWPSubscriptionEntityRecordId = "" ;
   this.Z22WWPSubscriptionEntityRecordId = "" ;
   this.O22WWPSubscriptionEntityRecordId = "" ;
   this.A24WWPSubscriptionEntityRecordDescription = "" ;
   this.Z24WWPSubscriptionEntityRecordDescription = "" ;
   this.O24WWPSubscriptionEntityRecordDescription = "" ;
   this.A11WWPSubscriptionRoleId = "" ;
   this.Z11WWPSubscriptionRoleId = "" ;
   this.O11WWPSubscriptionRoleId = "" ;
   this.A23WWPSubscriptionSubscribed = false ;
   this.Z23WWPSubscriptionSubscribed = false ;
   this.O23WWPSubscriptionSubscribed = false ;
   this.A10WWPEntityId = 0 ;
   this.A13WWPSubscriptionId = 0 ;
   this.A2WWPUserExtendedFullName = "" ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.A25WWPNotificationDefinitionDescription = "" ;
   this.A12WWPEntityName = "" ;
   this.A1WWPUserExtendedId = "" ;
   this.A22WWPSubscriptionEntityRecordId = "" ;
   this.A24WWPSubscriptionEntityRecordDescription = "" ;
   this.A11WWPSubscriptionRoleId = "" ;
   this.A23WWPSubscriptionSubscribed = false ;
   this.Events = {"e11033_client": ["ENTER", true] ,"e12033_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}],[{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]];
   this.EvtParms["REFRESH"] = [[{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}],[{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]];
   this.EvtParms["VALID_WWPSUBSCRIPTIONID"] = [[{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}],[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A24WWPSubscriptionEntityRecordDescription',fld:'WWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z13WWPSubscriptionId'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z1WWPUserExtendedId'},{av:'Z22WWPSubscriptionEntityRecordId'},{av:'Z24WWPSubscriptionEntityRecordDescription'},{av:'Z11WWPSubscriptionRoleId'},{av:'Z23WWPSubscriptionSubscribed'},{av:'Z10WWPEntityId'},{av:'Z25WWPNotificationDefinitionDescription'},{av:'Z12WWPEntityName'},{av:'Z2WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONDEFINITIONID"] = [[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}],[{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]];
   this.EvtParms["VALID_WWPUSEREXTENDEDID"] = [[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}],[{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("A10WWPEntityId", "WWPENTITYID", 0, "int", 10, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.subscriptions.wwp_subscription);});
