gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.sms.wwp_sms', false, function () {
   this.ServerClass =  "wwpbaseobjects.sms.wwp_sms" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",'.') ;
   };
   this.Valid_Wwpsmsid=function()
   {
      return this.validSrvEvt("Valid_Wwpsmsid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpsmsstatus=function()
   {
      return this.validCliEvt("Valid_Wwpsmsstatus", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPSMSSTATUS");
         this.AnyError  = 0;
         if ( ! ( ( this.A29WWPSMSStatus == 1 ) || ( this.A29WWPSMSStatus == 2 ) || ( this.A29WWPSMSStatus == 3 ) ) )
         {
            try {
               gxballoon.setError("Campo SMS Status fora do intervalo");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Wwpsmscreated=function()
   {
      return this.validCliEvt("Valid_Wwpsmscreated", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPSMSCREATED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A35WWPSMSCreated)==0) || new gx.date.gxdate( this.A35WWPSMSCreated ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo SMS Created fora do intervalo");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Wwpsmsscheduled=function()
   {
      return this.validCliEvt("Valid_Wwpsmsscheduled", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPSMSSCHEDULED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A36WWPSMSScheduled)==0) || new gx.date.gxdate( this.A36WWPSMSScheduled ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo SMS Scheduled fora do intervalo");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Wwpsmsprocessed=function()
   {
      return this.validCliEvt("Valid_Wwpsmsprocessed", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPSMSPROCESSED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A30WWPSMSProcessed)===0) || new gx.date.gxdate( this.A30WWPSMSProcessed ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo SMS Processed fora do intervalo");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Wwpnotificationid=function()
   {
      return this.validSrvEvt("Valid_Wwpnotificationid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e11044_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12044_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87];
   this.GXLastCtrlId =87;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13044_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14044_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15044_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16044_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17044_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpsmsid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSID",gxz:"Z15WWPSMSId",gxold:"O15WWPSMSId",gxvar:"A15WWPSMSId",ucs:[],op:[73,68,63,58,53,48,43,38,33],ip:[73,68,63,58,53,48,43,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A15WWPSMSId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z15WWPSMSId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPSMSID",gx.O.A15WWPSMSId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A15WWPSMSId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPSMSID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSMESSAGE",gxz:"Z32WWPSMSMessage",gxold:"O32WWPSMSMessage",gxvar:"A32WWPSMSMessage",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A32WWPSMSMessage=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z32WWPSMSMessage=Value},v2c:function(){gx.fn.setControlValue("WWPSMSMESSAGE",gx.O.A32WWPSMSMessage,0)},c2v:function(){if(this.val()!==undefined)gx.O.A32WWPSMSMessage=this.val()},val:function(){return gx.fn.getControlValue("WWPSMSMESSAGE")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSSENDERNUMBER",gxz:"Z33WWPSMSSenderNumber",gxold:"O33WWPSMSSenderNumber",gxvar:"A33WWPSMSSenderNumber",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A33WWPSMSSenderNumber=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z33WWPSMSSenderNumber=Value},v2c:function(){gx.fn.setControlValue("WWPSMSSENDERNUMBER",gx.O.A33WWPSMSSenderNumber,0)},c2v:function(){if(this.val()!==undefined)gx.O.A33WWPSMSSenderNumber=this.val()},val:function(){return gx.fn.getControlValue("WWPSMSSENDERNUMBER")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSRECIPIENTNUMBERS",gxz:"Z34WWPSMSRecipientNumbers",gxold:"O34WWPSMSRecipientNumbers",gxvar:"A34WWPSMSRecipientNumbers",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A34WWPSMSRecipientNumbers=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z34WWPSMSRecipientNumbers=Value},v2c:function(){gx.fn.setControlValue("WWPSMSRECIPIENTNUMBERS",gx.O.A34WWPSMSRecipientNumbers,0)},c2v:function(){if(this.val()!==undefined)gx.O.A34WWPSMSRecipientNumbers=this.val()},val:function(){return gx.fn.getControlValue("WWPSMSRECIPIENTNUMBERS")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpsmsstatus,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSSTATUS",gxz:"Z29WWPSMSStatus",gxold:"O29WWPSMSStatus",gxvar:"A29WWPSMSStatus",ucs:[],op:[48],ip:[48],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A29WWPSMSStatus=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z29WWPSMSStatus=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("WWPSMSSTATUS",gx.O.A29WWPSMSStatus);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A29WWPSMSStatus=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPSMSSTATUS",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 48 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpsmscreated,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSCREATED",gxz:"Z35WWPSMSCreated",gxold:"O35WWPSMSCreated",gxvar:"A35WWPSMSCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[53],ip:[53],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A35WWPSMSCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z35WWPSMSCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPSMSCREATED",gx.O.A35WWPSMSCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A35WWPSMSCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPSMSCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpsmsscheduled,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSSCHEDULED",gxz:"Z36WWPSMSScheduled",gxold:"O36WWPSMSScheduled",gxvar:"A36WWPSMSScheduled",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[58],ip:[58],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A36WWPSMSScheduled=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z36WWPSMSScheduled=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPSMSSCHEDULED",gx.O.A36WWPSMSScheduled,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A36WWPSMSScheduled=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPSMSSCHEDULED")},nac:gx.falseFn};
   this.declareDomainHdlr( 58 , function() {
   });
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpsmsprocessed,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSPROCESSED",gxz:"Z30WWPSMSProcessed",gxold:"O30WWPSMSProcessed",gxvar:"A30WWPSMSProcessed",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[63],ip:[63],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A30WWPSMSProcessed=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z30WWPSMSProcessed=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPSMSPROCESSED",gx.O.A30WWPSMSProcessed,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A30WWPSMSProcessed=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPSMSPROCESSED")},nac:gx.falseFn};
   this.declareDomainHdlr( 63 , function() {
   });
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPSMSDETAIL",gxz:"Z31WWPSMSDetail",gxold:"O31WWPSMSDetail",gxvar:"A31WWPSMSDetail",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A31WWPSMSDetail=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z31WWPSMSDetail=Value},v2c:function(){gx.fn.setControlValue("WWPSMSDETAIL",gx.O.A31WWPSMSDetail,0)},c2v:function(){if(this.val()!==undefined)gx.O.A31WWPSMSDetail=this.val()},val:function(){return gx.fn.getControlValue("WWPSMSDETAIL")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",gxz:"Z16WWPNotificationId",gxold:"O16WWPNotificationId",gxvar:"A16WWPNotificationId",ucs:[],op:[78],ip:[78,73],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z16WWPNotificationId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONID",gx.O.A16WWPNotificationId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 73 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",gxz:"Z37WWPNotificationCreated",gxold:"O37WWPNotificationCreated",gxvar:"A37WWPNotificationCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONCREATED",gx.O.A37WWPNotificationCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 78 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id: 83, fld:"BTN_ENTER",grid:0,evt:"e11044_client",std:"ENTER"};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"BTN_CANCEL",grid:0,evt:"e12044_client"};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"BTN_DELETE",grid:0,evt:"e18044_client",std:"DELETE"};
   this.A15WWPSMSId = 0 ;
   this.Z15WWPSMSId = 0 ;
   this.O15WWPSMSId = 0 ;
   this.A32WWPSMSMessage = "" ;
   this.Z32WWPSMSMessage = "" ;
   this.O32WWPSMSMessage = "" ;
   this.A33WWPSMSSenderNumber = "" ;
   this.Z33WWPSMSSenderNumber = "" ;
   this.O33WWPSMSSenderNumber = "" ;
   this.A34WWPSMSRecipientNumbers = "" ;
   this.Z34WWPSMSRecipientNumbers = "" ;
   this.O34WWPSMSRecipientNumbers = "" ;
   this.A29WWPSMSStatus = 0 ;
   this.Z29WWPSMSStatus = 0 ;
   this.O29WWPSMSStatus = 0 ;
   this.A35WWPSMSCreated = gx.date.nullDate() ;
   this.Z35WWPSMSCreated = gx.date.nullDate() ;
   this.O35WWPSMSCreated = gx.date.nullDate() ;
   this.A36WWPSMSScheduled = gx.date.nullDate() ;
   this.Z36WWPSMSScheduled = gx.date.nullDate() ;
   this.O36WWPSMSScheduled = gx.date.nullDate() ;
   this.A30WWPSMSProcessed = gx.date.nullDate() ;
   this.Z30WWPSMSProcessed = gx.date.nullDate() ;
   this.O30WWPSMSProcessed = gx.date.nullDate() ;
   this.A31WWPSMSDetail = "" ;
   this.Z31WWPSMSDetail = "" ;
   this.O31WWPSMSDetail = "" ;
   this.A16WWPNotificationId = 0 ;
   this.Z16WWPNotificationId = 0 ;
   this.O16WWPNotificationId = 0 ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.Z37WWPNotificationCreated = gx.date.nullDate() ;
   this.O37WWPNotificationCreated = gx.date.nullDate() ;
   this.A15WWPSMSId = 0 ;
   this.Gx_BScreen = 0 ;
   this.A32WWPSMSMessage = "" ;
   this.A33WWPSMSSenderNumber = "" ;
   this.A34WWPSMSRecipientNumbers = "" ;
   this.A29WWPSMSStatus = 0 ;
   this.A35WWPSMSCreated = gx.date.nullDate() ;
   this.A36WWPSMSScheduled = gx.date.nullDate() ;
   this.A30WWPSMSProcessed = gx.date.nullDate() ;
   this.A31WWPSMSDetail = "" ;
   this.A16WWPNotificationId = 0 ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.Events = {"e11044_client": ["ENTER", true] ,"e12044_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_WWPSMSID"] = [[{av:'A15WWPSMSId',fld:'WWPSMSID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{ctrl:'WWPSMSSTATUS'},{av:'A29WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'},{av:'A35WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A36WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'}],[{av:'A32WWPSMSMessage',fld:'WWPSMSMESSAGE',pic:''},{av:'A33WWPSMSSenderNumber',fld:'WWPSMSSENDERNUMBER',pic:''},{av:'A34WWPSMSRecipientNumbers',fld:'WWPSMSRECIPIENTNUMBERS',pic:''},{ctrl:'WWPSMSSTATUS'},{av:'A29WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'},{av:'A35WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A36WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A30WWPSMSProcessed',fld:'WWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A31WWPSMSDetail',fld:'WWPSMSDETAIL',pic:''},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z15WWPSMSId'},{av:'Z32WWPSMSMessage'},{av:'Z33WWPSMSSenderNumber'},{av:'Z34WWPSMSRecipientNumbers'},{av:'Z29WWPSMSStatus'},{av:'Z35WWPSMSCreated'},{av:'Z36WWPSMSScheduled'},{av:'Z30WWPSMSProcessed'},{av:'Z31WWPSMSDetail'},{av:'Z16WWPNotificationId'},{av:'Z37WWPNotificationCreated'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_WWPSMSSTATUS"] = [[{ctrl:'WWPSMSSTATUS'},{av:'A29WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'}],[{ctrl:'WWPSMSSTATUS'},{av:'A29WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'}]];
   this.EvtParms["VALID_WWPSMSCREATED"] = [[{av:'A35WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'}],[{av:'A35WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPSMSSCHEDULED"] = [[{av:'A36WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'}],[{av:'A36WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPSMSPROCESSED"] = [[{av:'A30WWPSMSProcessed',fld:'WWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999'}],[{av:'A30WWPSMSProcessed',fld:'WWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPNOTIFICATIONID"] = [[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}],[{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("Gx_BScreen", "vGXBSCREEN", 0, "int", 1, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.sms.wwp_sms);});
