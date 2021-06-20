gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.notifications.web.wwp_webnotification', false, function () {
   this.ServerClass =  "wwpbaseobjects.notifications.web.wwp_webnotification" ;
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
      this.A14WWPNotificationDefinitionId=gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",'.') ;
   };
   this.Valid_Wwpwebnotificationid=function()
   {
      return this.validSrvEvt("Valid_Wwpwebnotificationid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpnotificationid=function()
   {
      return this.validSrvEvt("Valid_Wwpnotificationid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpwebnotificationstatus=function()
   {
      return this.validCliEvt("Valid_Wwpwebnotificationstatus", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBNOTIFICATIONSTATUS");
         this.AnyError  = 0;
         if ( ! ( ( this.A48WWPWebNotificationStatus == 1 ) || ( this.A48WWPWebNotificationStatus == 2 ) || ( this.A48WWPWebNotificationStatus == 3 ) ) )
         {
            try {
               gxballoon.setError("Campo Web Notification Status fora do intervalo");
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
   this.Valid_Wwpwebnotificationcreated=function()
   {
      return this.validCliEvt("Valid_Wwpwebnotificationcreated", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBNOTIFICATIONCREATED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A41WWPWebNotificationCreated)==0) || new gx.date.gxdate( this.A41WWPWebNotificationCreated ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Web Notification Created fora do intervalo");
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
   this.Valid_Wwpwebnotificationscheduled=function()
   {
      return this.validCliEvt("Valid_Wwpwebnotificationscheduled", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBNOTIFICATIONSCHEDULED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A52WWPWebNotificationScheduled)==0) || new gx.date.gxdate( this.A52WWPWebNotificationScheduled ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Web Notification Scheduled fora do intervalo");
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
   this.Valid_Wwpwebnotificationprocessed=function()
   {
      return this.validCliEvt("Valid_Wwpwebnotificationprocessed", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBNOTIFICATIONPROCESSED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A49WWPWebNotificationProcessed)==0) || new gx.date.gxdate( this.A49WWPWebNotificationProcessed ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Web Notification Processed fora do intervalo");
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
   this.Valid_Wwpwebnotificationread=function()
   {
      return this.validCliEvt("Valid_Wwpwebnotificationread", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBNOTIFICATIONREAD");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A42WWPWebNotificationRead)===0) || new gx.date.gxdate( this.A42WWPWebNotificationRead ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Web Notification Read fora do intervalo");
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
   this.e11055_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12055_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112];
   this.GXLastCtrlId =112;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13055_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14055_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15055_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16055_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17055_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebnotificationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONID",gxz:"Z17WWPWebNotificationId",gxold:"O17WWPWebNotificationId",gxvar:"A17WWPWebNotificationId",ucs:[],op:[38,103,98,93,88,83,78,73,68,63,58,33],ip:[38,103,98,93,88,83,78,73,68,63,58,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A17WWPWebNotificationId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z17WWPWebNotificationId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONID",gx.O.A17WWPWebNotificationId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A17WWPWebNotificationId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPWEBNOTIFICATIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONTITLE",gxz:"Z38WWPWebNotificationTitle",gxold:"O38WWPWebNotificationTitle",gxvar:"A38WWPWebNotificationTitle",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A38WWPWebNotificationTitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z38WWPWebNotificationTitle=Value},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONTITLE",gx.O.A38WWPWebNotificationTitle,0)},c2v:function(){if(this.val()!==undefined)gx.O.A38WWPWebNotificationTitle=this.val()},val:function(){return gx.fn.getControlValue("WWPWEBNOTIFICATIONTITLE")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",gxz:"Z16WWPNotificationId",gxold:"O16WWPNotificationId",gxvar:"A16WWPNotificationId",ucs:[],op:[53,48,43],ip:[53,48,43,38],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z16WWPNotificationId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONID",gx.O.A16WWPNotificationId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 38 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",gxz:"Z37WWPNotificationCreated",gxold:"O37WWPNotificationCreated",gxvar:"A37WWPNotificationCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONCREATED",gx.O.A37WWPNotificationCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 43 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:1,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONMETADATA",gxz:"Z54WWPNotificationMetadata",gxold:"O54WWPNotificationMetadata",gxvar:"A54WWPNotificationMetadata",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A54WWPNotificationMetadata=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z54WWPNotificationMetadata=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONMETADATA",gx.O.A54WWPNotificationMetadata,0)},c2v:function(){if(this.val()!==undefined)gx.O.A54WWPNotificationMetadata=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONMETADATA")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONNAME",gxz:"Z53WWPNotificationDefinitionName",gxold:"O53WWPNotificationDefinitionName",gxvar:"A53WWPNotificationDefinitionName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A53WWPNotificationDefinitionName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z53WWPNotificationDefinitionName=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONNAME",gx.O.A53WWPNotificationDefinitionName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A53WWPNotificationDefinitionName=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"svchar",len:120,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONTEXT",gxz:"Z39WWPWebNotificationText",gxold:"O39WWPWebNotificationText",gxvar:"A39WWPWebNotificationText",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A39WWPWebNotificationText=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z39WWPWebNotificationText=Value},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONTEXT",gx.O.A39WWPWebNotificationText,0)},c2v:function(){if(this.val()!==undefined)gx.O.A39WWPWebNotificationText=this.val()},val:function(){return gx.fn.getControlValue("WWPWEBNOTIFICATIONTEXT")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"svchar",len:255,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONICON",gxz:"Z40WWPWebNotificationIcon",gxold:"O40WWPWebNotificationIcon",gxvar:"A40WWPWebNotificationIcon",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A40WWPWebNotificationIcon=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z40WWPWebNotificationIcon=Value},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONICON",gx.O.A40WWPWebNotificationIcon,0)},c2v:function(){if(this.val()!==undefined)gx.O.A40WWPWebNotificationIcon=this.val()},val:function(){return gx.fn.getControlValue("WWPWEBNOTIFICATIONICON")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONCLIENTID",gxz:"Z47WWPWebNotificationClientId",gxold:"O47WWPWebNotificationClientId",gxvar:"A47WWPWebNotificationClientId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A47WWPWebNotificationClientId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z47WWPWebNotificationClientId=Value},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONCLIENTID",gx.O.A47WWPWebNotificationClientId,0)},c2v:function(){if(this.val()!==undefined)gx.O.A47WWPWebNotificationClientId=this.val()},val:function(){return gx.fn.getControlValue("WWPWEBNOTIFICATIONCLIENTID")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebnotificationstatus,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONSTATUS",gxz:"Z48WWPWebNotificationStatus",gxold:"O48WWPWebNotificationStatus",gxvar:"A48WWPWebNotificationStatus",ucs:[],op:[73],ip:[73],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A48WWPWebNotificationStatus=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z48WWPWebNotificationStatus=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("WWPWEBNOTIFICATIONSTATUS",gx.O.A48WWPWebNotificationStatus);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A48WWPWebNotificationStatus=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPWEBNOTIFICATIONSTATUS",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 73 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebnotificationcreated,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONCREATED",gxz:"Z41WWPWebNotificationCreated",gxold:"O41WWPWebNotificationCreated",gxvar:"A41WWPWebNotificationCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[78],ip:[78],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A41WWPWebNotificationCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z41WWPWebNotificationCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONCREATED",gx.O.A41WWPWebNotificationCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A41WWPWebNotificationCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPWEBNOTIFICATIONCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 78 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id:83 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebnotificationscheduled,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONSCHEDULED",gxz:"Z52WWPWebNotificationScheduled",gxold:"O52WWPWebNotificationScheduled",gxvar:"A52WWPWebNotificationScheduled",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[83],ip:[83],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A52WWPWebNotificationScheduled=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z52WWPWebNotificationScheduled=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONSCHEDULED",gx.O.A52WWPWebNotificationScheduled,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A52WWPWebNotificationScheduled=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPWEBNOTIFICATIONSCHEDULED")},nac:gx.falseFn};
   this.declareDomainHdlr( 83 , function() {
   });
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id:88 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebnotificationprocessed,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONPROCESSED",gxz:"Z49WWPWebNotificationProcessed",gxold:"O49WWPWebNotificationProcessed",gxvar:"A49WWPWebNotificationProcessed",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[88],ip:[88],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A49WWPWebNotificationProcessed=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z49WWPWebNotificationProcessed=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONPROCESSED",gx.O.A49WWPWebNotificationProcessed,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A49WWPWebNotificationProcessed=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPWEBNOTIFICATIONPROCESSED")},nac:gx.falseFn};
   this.declareDomainHdlr( 88 , function() {
   });
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"",grid:0};
   GXValidFnc[93]={ id:93 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebnotificationread,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONREAD",gxz:"Z42WWPWebNotificationRead",gxold:"O42WWPWebNotificationRead",gxvar:"A42WWPWebNotificationRead",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[93],ip:[93],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A42WWPWebNotificationRead=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z42WWPWebNotificationRead=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONREAD",gx.O.A42WWPWebNotificationRead,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A42WWPWebNotificationRead=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPWEBNOTIFICATIONREAD")},nac:gx.falseFn};
   this.declareDomainHdlr( 93 , function() {
   });
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id: 95, fld:"",grid:0};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id:98 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONDETAIL",gxz:"Z50WWPWebNotificationDetail",gxold:"O50WWPWebNotificationDetail",gxvar:"A50WWPWebNotificationDetail",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A50WWPWebNotificationDetail=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z50WWPWebNotificationDetail=Value},v2c:function(){gx.fn.setControlValue("WWPWEBNOTIFICATIONDETAIL",gx.O.A50WWPWebNotificationDetail,0)},c2v:function(){if(this.val()!==undefined)gx.O.A50WWPWebNotificationDetail=this.val()},val:function(){return gx.fn.getControlValue("WWPWEBNOTIFICATIONDETAIL")},nac:gx.falseFn};
   GXValidFnc[99]={ id: 99, fld:"",grid:0};
   GXValidFnc[100]={ id: 100, fld:"",grid:0};
   GXValidFnc[101]={ id: 101, fld:"",grid:0};
   GXValidFnc[102]={ id: 102, fld:"",grid:0};
   GXValidFnc[103]={ id:103 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBNOTIFICATIONRECEIVED",gxz:"Z51WWPWebNotificationReceived",gxold:"O51WWPWebNotificationReceived",gxvar:"A51WWPWebNotificationReceived",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A51WWPWebNotificationReceived=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z51WWPWebNotificationReceived=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("WWPWEBNOTIFICATIONRECEIVED",gx.O.A51WWPWebNotificationReceived,true)},c2v:function(){if(this.val()!==undefined)gx.O.A51WWPWebNotificationReceived=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPWEBNOTIFICATIONRECEIVED")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[104]={ id: 104, fld:"",grid:0};
   GXValidFnc[105]={ id: 105, fld:"",grid:0};
   GXValidFnc[106]={ id: 106, fld:"",grid:0};
   GXValidFnc[107]={ id: 107, fld:"",grid:0};
   GXValidFnc[108]={ id: 108, fld:"BTN_ENTER",grid:0,evt:"e11055_client",std:"ENTER"};
   GXValidFnc[109]={ id: 109, fld:"",grid:0};
   GXValidFnc[110]={ id: 110, fld:"BTN_CANCEL",grid:0,evt:"e12055_client"};
   GXValidFnc[111]={ id: 111, fld:"",grid:0};
   GXValidFnc[112]={ id: 112, fld:"BTN_DELETE",grid:0,evt:"e18055_client",std:"DELETE"};
   this.A17WWPWebNotificationId = 0 ;
   this.Z17WWPWebNotificationId = 0 ;
   this.O17WWPWebNotificationId = 0 ;
   this.A38WWPWebNotificationTitle = "" ;
   this.Z38WWPWebNotificationTitle = "" ;
   this.O38WWPWebNotificationTitle = "" ;
   this.A16WWPNotificationId = 0 ;
   this.Z16WWPNotificationId = 0 ;
   this.O16WWPNotificationId = 0 ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.Z37WWPNotificationCreated = gx.date.nullDate() ;
   this.O37WWPNotificationCreated = gx.date.nullDate() ;
   this.A54WWPNotificationMetadata = "" ;
   this.Z54WWPNotificationMetadata = "" ;
   this.O54WWPNotificationMetadata = "" ;
   this.A53WWPNotificationDefinitionName = "" ;
   this.Z53WWPNotificationDefinitionName = "" ;
   this.O53WWPNotificationDefinitionName = "" ;
   this.A39WWPWebNotificationText = "" ;
   this.Z39WWPWebNotificationText = "" ;
   this.O39WWPWebNotificationText = "" ;
   this.A40WWPWebNotificationIcon = "" ;
   this.Z40WWPWebNotificationIcon = "" ;
   this.O40WWPWebNotificationIcon = "" ;
   this.A47WWPWebNotificationClientId = "" ;
   this.Z47WWPWebNotificationClientId = "" ;
   this.O47WWPWebNotificationClientId = "" ;
   this.A48WWPWebNotificationStatus = 0 ;
   this.Z48WWPWebNotificationStatus = 0 ;
   this.O48WWPWebNotificationStatus = 0 ;
   this.A41WWPWebNotificationCreated = gx.date.nullDate() ;
   this.Z41WWPWebNotificationCreated = gx.date.nullDate() ;
   this.O41WWPWebNotificationCreated = gx.date.nullDate() ;
   this.A52WWPWebNotificationScheduled = gx.date.nullDate() ;
   this.Z52WWPWebNotificationScheduled = gx.date.nullDate() ;
   this.O52WWPWebNotificationScheduled = gx.date.nullDate() ;
   this.A49WWPWebNotificationProcessed = gx.date.nullDate() ;
   this.Z49WWPWebNotificationProcessed = gx.date.nullDate() ;
   this.O49WWPWebNotificationProcessed = gx.date.nullDate() ;
   this.A42WWPWebNotificationRead = gx.date.nullDate() ;
   this.Z42WWPWebNotificationRead = gx.date.nullDate() ;
   this.O42WWPWebNotificationRead = gx.date.nullDate() ;
   this.A50WWPWebNotificationDetail = "" ;
   this.Z50WWPWebNotificationDetail = "" ;
   this.O50WWPWebNotificationDetail = "" ;
   this.A51WWPWebNotificationReceived = false ;
   this.Z51WWPWebNotificationReceived = false ;
   this.O51WWPWebNotificationReceived = false ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.A17WWPWebNotificationId = 0 ;
   this.Gx_BScreen = 0 ;
   this.A38WWPWebNotificationTitle = "" ;
   this.A16WWPNotificationId = 0 ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.A54WWPNotificationMetadata = "" ;
   this.A53WWPNotificationDefinitionName = "" ;
   this.A39WWPWebNotificationText = "" ;
   this.A40WWPWebNotificationIcon = "" ;
   this.A47WWPWebNotificationClientId = "" ;
   this.A48WWPWebNotificationStatus = 0 ;
   this.A41WWPWebNotificationCreated = gx.date.nullDate() ;
   this.A52WWPWebNotificationScheduled = gx.date.nullDate() ;
   this.A49WWPWebNotificationProcessed = gx.date.nullDate() ;
   this.A42WWPWebNotificationRead = gx.date.nullDate() ;
   this.A50WWPWebNotificationDetail = "" ;
   this.A51WWPWebNotificationReceived = false ;
   this.Events = {"e11055_client": ["ENTER", true] ,"e12055_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["REFRESH"] = [[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["VALID_WWPWEBNOTIFICATIONID"] = [[{av:'A17WWPWebNotificationId',fld:'WWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{ctrl:'WWPWEBNOTIFICATIONSTATUS'},{av:'A48WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A41WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A52WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A38WWPWebNotificationTitle',fld:'WWPWEBNOTIFICATIONTITLE',pic:''},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A39WWPWebNotificationText',fld:'WWPWEBNOTIFICATIONTEXT',pic:''},{av:'A40WWPWebNotificationIcon',fld:'WWPWEBNOTIFICATIONICON',pic:''},{av:'A47WWPWebNotificationClientId',fld:'WWPWEBNOTIFICATIONCLIENTID',pic:''},{ctrl:'WWPWEBNOTIFICATIONSTATUS'},{av:'A48WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A41WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A52WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A49WWPWebNotificationProcessed',fld:'WWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A42WWPWebNotificationRead',fld:'WWPWEBNOTIFICATIONREAD',pic:'99/99/9999 99:99:99.999'},{av:'A50WWPWebNotificationDetail',fld:'WWPWEBNOTIFICATIONDETAIL',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z17WWPWebNotificationId'},{av:'Z38WWPWebNotificationTitle'},{av:'Z16WWPNotificationId'},{av:'Z39WWPWebNotificationText'},{av:'Z40WWPWebNotificationIcon'},{av:'Z47WWPWebNotificationClientId'},{av:'Z48WWPWebNotificationStatus'},{av:'Z41WWPWebNotificationCreated'},{av:'Z52WWPWebNotificationScheduled'},{av:'Z49WWPWebNotificationProcessed'},{av:'Z42WWPWebNotificationRead'},{av:'Z50WWPWebNotificationDetail'},{av:'Z51WWPWebNotificationReceived'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z37WWPNotificationCreated'},{av:'Z54WWPNotificationMetadata'},{av:'Z53WWPNotificationDefinitionName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONID"] = [[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["VALID_WWPWEBNOTIFICATIONSTATUS"] = [[{ctrl:'WWPWEBNOTIFICATIONSTATUS'},{av:'A48WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{ctrl:'WWPWEBNOTIFICATIONSTATUS'},{av:'A48WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["VALID_WWPWEBNOTIFICATIONCREATED"] = [[{av:'A41WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A41WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["VALID_WWPWEBNOTIFICATIONSCHEDULED"] = [[{av:'A52WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A52WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["VALID_WWPWEBNOTIFICATIONPROCESSED"] = [[{av:'A49WWPWebNotificationProcessed',fld:'WWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A49WWPWebNotificationProcessed',fld:'WWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EvtParms["VALID_WWPWEBNOTIFICATIONREAD"] = [[{av:'A42WWPWebNotificationRead',fld:'WWPWEBNOTIFICATIONREAD',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}],[{av:'A42WWPWebNotificationRead',fld:'WWPWEBNOTIFICATIONREAD',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("Gx_BScreen", "vGXBSCREEN", 0, "int", 1, 0);
   this.setVCMap("A14WWPNotificationDefinitionId", "WWPNOTIFICATIONDEFINITIONID", 0, "int", 10, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.notifications.web.wwp_webnotification);});
