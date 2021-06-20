gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.notifications.common.wwp_notification', false, function () {
   this.ServerClass =  "wwpbaseobjects.notifications.common.wwp_notification" ;
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
   this.Valid_Wwpnotificationid=function()
   {
      return this.validSrvEvt("Valid_Wwpnotificationid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpnotificationdefinitionid=function()
   {
      return this.validSrvEvt("Valid_Wwpnotificationdefinitionid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpnotificationcreated=function()
   {
      return this.validCliEvt("Valid_Wwpnotificationcreated", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPNOTIFICATIONCREATED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A37WWPNotificationCreated)==0) || new gx.date.gxdate( this.A37WWPNotificationCreated ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Notification Created Date fora do intervalo");
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
   this.Valid_Wwpnotificationlink=function()
   {
      return this.validCliEvt("Valid_Wwpnotificationlink", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPNOTIFICATIONLINK");
         this.AnyError  = 0;
         if ( ! ( gx.util.regExp.isMatch(this.A71WWPNotificationLink, "^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            try {
               gxballoon.setError("O valor de Notification Link não coincide com o padrão especificado");
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
   this.Valid_Wwpuserextendedid=function()
   {
      return this.validSrvEvt("Valid_Wwpuserextendedid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e11088_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12088_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92];
   this.GXLastCtrlId =92;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13088_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14088_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15088_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16088_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17088_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",gxz:"Z16WWPNotificationId",gxold:"O16WWPNotificationId",gxvar:"A16WWPNotificationId",ucs:[],op:[73,33,83,68,63,58,53,48,43],ip:[73,33,83,68,63,58,53,48,43,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z16WWPNotificationId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONID",gx.O.A16WWPNotificationId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONID",gxz:"Z14WWPNotificationDefinitionId",gxold:"O14WWPNotificationDefinitionId",gxvar:"A14WWPNotificationDefinitionId",ucs:[],op:[38],ip:[38,33],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z14WWPNotificationDefinitionId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONID",gx.O.A14WWPNotificationDefinitionId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 33 , function() {
   });
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONNAME",gxz:"Z53WWPNotificationDefinitionName",gxold:"O53WWPNotificationDefinitionName",gxvar:"A53WWPNotificationDefinitionName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A53WWPNotificationDefinitionName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z53WWPNotificationDefinitionName=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONNAME",gx.O.A53WWPNotificationDefinitionName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A53WWPNotificationDefinitionName=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 38 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationcreated,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",gxz:"Z37WWPNotificationCreated",gxold:"O37WWPNotificationCreated",gxvar:"A37WWPNotificationCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[43],ip:[43],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONCREATED",gx.O.A37WWPNotificationCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 43 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONICON",gxz:"Z68WWPNotificationIcon",gxold:"O68WWPNotificationIcon",gxvar:"A68WWPNotificationIcon",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A68WWPNotificationIcon=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z68WWPNotificationIcon=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONICON",gx.O.A68WWPNotificationIcon,0)},c2v:function(){if(this.val()!==undefined)gx.O.A68WWPNotificationIcon=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONICON")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONTITLE",gxz:"Z69WWPNotificationTitle",gxold:"O69WWPNotificationTitle",gxvar:"A69WWPNotificationTitle",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A69WWPNotificationTitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z69WWPNotificationTitle=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONTITLE",gx.O.A69WWPNotificationTitle,0)},c2v:function(){if(this.val()!==undefined)gx.O.A69WWPNotificationTitle=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONTITLE")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONSHORTDESCRIPTION",gxz:"Z70WWPNotificationShortDescription",gxold:"O70WWPNotificationShortDescription",gxvar:"A70WWPNotificationShortDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A70WWPNotificationShortDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z70WWPNotificationShortDescription=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONSHORTDESCRIPTION",gx.O.A70WWPNotificationShortDescription,0)},c2v:function(){if(this.val()!==undefined)gx.O.A70WWPNotificationShortDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONSHORTDESCRIPTION")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"svchar",len:1000,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationlink,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONLINK",gxz:"Z71WWPNotificationLink",gxold:"O71WWPNotificationLink",gxvar:"A71WWPNotificationLink",ucs:[],op:[],ip:[63],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A71WWPNotificationLink=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z71WWPNotificationLink=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONLINK",gx.O.A71WWPNotificationLink,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A71WWPNotificationLink=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONLINK")},nac:gx.falseFn};
   this.declareDomainHdlr( 63 , function() {
   });
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONISREAD",gxz:"Z73WWPNotificationIsRead",gxold:"O73WWPNotificationIsRead",gxvar:"A73WWPNotificationIsRead",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A73WWPNotificationIsRead=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z73WWPNotificationIsRead=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("WWPNOTIFICATIONISREAD",gx.O.A73WWPNotificationIsRead,true)},c2v:function(){if(this.val()!==undefined)gx.O.A73WWPNotificationIsRead=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONISREAD")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"char",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpuserextendedid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDID",gxz:"Z1WWPUserExtendedId",gxold:"O1WWPUserExtendedId",gxvar:"A1WWPUserExtendedId",ucs:[],op:[78],ip:[78,73],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1WWPUserExtendedId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1WWPUserExtendedId=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDID",gx.O.A1WWPUserExtendedId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1WWPUserExtendedId=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDID")},nac:gx.falseFn};
   this.declareDomainHdlr( 73 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",gxz:"Z2WWPUserExtendedFullName",gxold:"O2WWPUserExtendedFullName",gxvar:"A2WWPUserExtendedFullName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2WWPUserExtendedFullName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2WWPUserExtendedFullName=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDFULLNAME",gx.O.A2WWPUserExtendedFullName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2WWPUserExtendedFullName=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDFULLNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 78 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id:83 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONMETADATA",gxz:"Z54WWPNotificationMetadata",gxold:"O54WWPNotificationMetadata",gxvar:"A54WWPNotificationMetadata",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A54WWPNotificationMetadata=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z54WWPNotificationMetadata=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONMETADATA",gx.O.A54WWPNotificationMetadata,0)},c2v:function(){if(this.val()!==undefined)gx.O.A54WWPNotificationMetadata=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONMETADATA")},nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id: 88, fld:"BTN_ENTER",grid:0,evt:"e11088_client",std:"ENTER"};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"BTN_CANCEL",grid:0,evt:"e12088_client"};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"BTN_DELETE",grid:0,evt:"e18088_client",std:"DELETE"};
   this.A16WWPNotificationId = 0 ;
   this.Z16WWPNotificationId = 0 ;
   this.O16WWPNotificationId = 0 ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.Z14WWPNotificationDefinitionId = 0 ;
   this.O14WWPNotificationDefinitionId = 0 ;
   this.A53WWPNotificationDefinitionName = "" ;
   this.Z53WWPNotificationDefinitionName = "" ;
   this.O53WWPNotificationDefinitionName = "" ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.Z37WWPNotificationCreated = gx.date.nullDate() ;
   this.O37WWPNotificationCreated = gx.date.nullDate() ;
   this.A68WWPNotificationIcon = "" ;
   this.Z68WWPNotificationIcon = "" ;
   this.O68WWPNotificationIcon = "" ;
   this.A69WWPNotificationTitle = "" ;
   this.Z69WWPNotificationTitle = "" ;
   this.O69WWPNotificationTitle = "" ;
   this.A70WWPNotificationShortDescription = "" ;
   this.Z70WWPNotificationShortDescription = "" ;
   this.O70WWPNotificationShortDescription = "" ;
   this.A71WWPNotificationLink = "" ;
   this.Z71WWPNotificationLink = "" ;
   this.O71WWPNotificationLink = "" ;
   this.A73WWPNotificationIsRead = false ;
   this.Z73WWPNotificationIsRead = false ;
   this.O73WWPNotificationIsRead = false ;
   this.A1WWPUserExtendedId = "" ;
   this.Z1WWPUserExtendedId = "" ;
   this.O1WWPUserExtendedId = "" ;
   this.A2WWPUserExtendedFullName = "" ;
   this.Z2WWPUserExtendedFullName = "" ;
   this.O2WWPUserExtendedFullName = "" ;
   this.A54WWPNotificationMetadata = "" ;
   this.Z54WWPNotificationMetadata = "" ;
   this.O54WWPNotificationMetadata = "" ;
   this.A16WWPNotificationId = 0 ;
   this.Gx_BScreen = 0 ;
   this.A2WWPUserExtendedFullName = "" ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.A53WWPNotificationDefinitionName = "" ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.A68WWPNotificationIcon = "" ;
   this.A69WWPNotificationTitle = "" ;
   this.A70WWPNotificationShortDescription = "" ;
   this.A71WWPNotificationLink = "" ;
   this.A73WWPNotificationIsRead = false ;
   this.A1WWPUserExtendedId = "" ;
   this.A54WWPNotificationMetadata = "" ;
   this.Events = {"e11088_client": ["ENTER", true] ,"e12088_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]];
   this.EvtParms["REFRESH"] = [[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONID"] = [[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A68WWPNotificationIcon',fld:'WWPNOTIFICATIONICON',pic:''},{av:'A69WWPNotificationTitle',fld:'WWPNOTIFICATIONTITLE',pic:''},{av:'A70WWPNotificationShortDescription',fld:'WWPNOTIFICATIONSHORTDESCRIPTION',pic:''},{av:'A71WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z16WWPNotificationId'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z37WWPNotificationCreated'},{av:'Z68WWPNotificationIcon'},{av:'Z69WWPNotificationTitle'},{av:'Z70WWPNotificationShortDescription'},{av:'Z71WWPNotificationLink'},{av:'Z73WWPNotificationIsRead'},{av:'Z1WWPUserExtendedId'},{av:'Z54WWPNotificationMetadata'},{av:'Z53WWPNotificationDefinitionName'},{av:'Z2WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONDEFINITIONID"] = [[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONCREATED"] = [[{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONLINK"] = [[{av:'A71WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]];
   this.EvtParms["VALID_WWPUSEREXTENDEDID"] = [[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("Gx_BScreen", "vGXBSCREEN", 0, "int", 1, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.notifications.common.wwp_notification);});
