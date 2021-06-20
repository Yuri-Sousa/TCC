gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.notifications.common.wwp_notificationdefinition', false, function () {
   this.ServerClass =  "wwpbaseobjects.notifications.common.wwp_notificationdefinition" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Wwpnotificationdefinitionid=function()
   {
      return this.validSrvEvt("Valid_Wwpnotificationdefinitionid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpnotificationdefinitionappliesto=function()
   {
      return this.validCliEvt("Valid_Wwpnotificationdefinitionappliesto", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPNOTIFICATIONDEFINITIONAPPLIESTO");
         this.AnyError  = 0;
         if ( ! ( ( this.A26WWPNotificationDefinitionAppliesTo == 1 ) || ( this.A26WWPNotificationDefinitionAppliesTo == 2 ) ) )
         {
            try {
               gxballoon.setError("Campo Notification Definition Applies To fora do intervalo");
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
   this.Valid_Wwpnotificationdefinitionlink=function()
   {
      return this.validCliEvt("Valid_Wwpnotificationdefinitionlink", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPNOTIFICATIONDEFINITIONLINK");
         this.AnyError  = 0;
         if ( ! ( gx.util.regExp.isMatch(this.A60WWPNotificationDefinitionLink, "^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            try {
               gxballoon.setError("O valor de Notification Definition Default Link não coincide com o padrão especificado");
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
   this.Valid_Wwpentityid=function()
   {
      return this.validSrvEvt("Valid_Wwpentityid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e11077_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12077_client=function()
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13077_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14077_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15077_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16077_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17077_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONID",gxz:"Z14WWPNotificationDefinitionId",gxold:"O14WWPNotificationDefinitionId",gxvar:"A14WWPNotificationDefinitionId",ucs:[],op:[78,73,68,63,58,53,48,43,38,33],ip:[78,73,68,63,58,53,48,43,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z14WWPNotificationDefinitionId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONID",gx.O.A14WWPNotificationDefinitionId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A14WWPNotificationDefinitionId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONNAME",gxz:"Z53WWPNotificationDefinitionName",gxold:"O53WWPNotificationDefinitionName",gxvar:"A53WWPNotificationDefinitionName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A53WWPNotificationDefinitionName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z53WWPNotificationDefinitionName=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONNAME",gx.O.A53WWPNotificationDefinitionName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A53WWPNotificationDefinitionName=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 33 , function() {
   });
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"int",len:1,dec:0,sign:false,pic:"9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionappliesto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONAPPLIESTO",gxz:"Z26WWPNotificationDefinitionAppliesTo",gxold:"O26WWPNotificationDefinitionAppliesTo",gxvar:"A26WWPNotificationDefinitionAppliesTo",ucs:[],op:[38],ip:[38],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A26WWPNotificationDefinitionAppliesTo=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z26WWPNotificationDefinitionAppliesTo=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("WWPNOTIFICATIONDEFINITIONAPPLIESTO",gx.O.A26WWPNotificationDefinitionAppliesTo);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A26WWPNotificationDefinitionAppliesTo=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONAPPLIESTO",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 38 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION",gxz:"Z27WWPNotificationDefinitionAllowUserSubscription",gxold:"O27WWPNotificationDefinitionAllowUserSubscription",gxvar:"A27WWPNotificationDefinitionAllowUserSubscription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A27WWPNotificationDefinitionAllowUserSubscription=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z27WWPNotificationDefinitionAllowUserSubscription=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION",gx.O.A27WWPNotificationDefinitionAllowUserSubscription,true)},c2v:function(){if(this.val()!==undefined)gx.O.A27WWPNotificationDefinitionAllowUserSubscription=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONDESCRIPTION",gxz:"Z25WWPNotificationDefinitionDescription",gxold:"O25WWPNotificationDefinitionDescription",gxvar:"A25WWPNotificationDefinitionDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A25WWPNotificationDefinitionDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z25WWPNotificationDefinitionDescription=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONDESCRIPTION",gx.O.A25WWPNotificationDefinitionDescription,0)},c2v:function(){if(this.val()!==undefined)gx.O.A25WWPNotificationDefinitionDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONDESCRIPTION")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONICON",gxz:"Z56WWPNotificationDefinitionIcon",gxold:"O56WWPNotificationDefinitionIcon",gxvar:"A56WWPNotificationDefinitionIcon",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A56WWPNotificationDefinitionIcon=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z56WWPNotificationDefinitionIcon=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONICON",gx.O.A56WWPNotificationDefinitionIcon,0)},c2v:function(){if(this.val()!==undefined)gx.O.A56WWPNotificationDefinitionIcon=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONICON")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONTITLE",gxz:"Z57WWPNotificationDefinitionTitle",gxold:"O57WWPNotificationDefinitionTitle",gxvar:"A57WWPNotificationDefinitionTitle",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A57WWPNotificationDefinitionTitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z57WWPNotificationDefinitionTitle=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONTITLE",gx.O.A57WWPNotificationDefinitionTitle,0)},c2v:function(){if(this.val()!==undefined)gx.O.A57WWPNotificationDefinitionTitle=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONTITLE")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"svchar",len:200,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONSHORTDESCRIPTION",gxz:"Z58WWPNotificationDefinitionShortDescription",gxold:"O58WWPNotificationDefinitionShortDescription",gxvar:"A58WWPNotificationDefinitionShortDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A58WWPNotificationDefinitionShortDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z58WWPNotificationDefinitionShortDescription=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONSHORTDESCRIPTION",gx.O.A58WWPNotificationDefinitionShortDescription,0)},c2v:function(){if(this.val()!==undefined)gx.O.A58WWPNotificationDefinitionShortDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONSHORTDESCRIPTION")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"svchar",len:1000,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONLONGDESCRIPTION",gxz:"Z59WWPNotificationDefinitionLongDescription",gxold:"O59WWPNotificationDefinitionLongDescription",gxvar:"A59WWPNotificationDefinitionLongDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A59WWPNotificationDefinitionLongDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z59WWPNotificationDefinitionLongDescription=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONLONGDESCRIPTION",gx.O.A59WWPNotificationDefinitionLongDescription,0)},c2v:function(){if(this.val()!==undefined)gx.O.A59WWPNotificationDefinitionLongDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONLONGDESCRIPTION")},nac:gx.falseFn};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"svchar",len:1000,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionlink,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONLINK",gxz:"Z60WWPNotificationDefinitionLink",gxold:"O60WWPNotificationDefinitionLink",gxvar:"A60WWPNotificationDefinitionLink",ucs:[],op:[],ip:[73],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A60WWPNotificationDefinitionLink=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z60WWPNotificationDefinitionLink=Value},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONLINK",gx.O.A60WWPNotificationDefinitionLink,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A60WWPNotificationDefinitionLink=this.val()},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONLINK")},nac:gx.falseFn};
   this.declareDomainHdlr( 73 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpentityid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYID",gxz:"Z10WWPEntityId",gxold:"O10WWPEntityId",gxvar:"A10WWPEntityId",ucs:[],op:[83],ip:[83,78],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A10WWPEntityId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z10WWPEntityId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPENTITYID",gx.O.A10WWPEntityId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A10WWPEntityId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPENTITYID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 78 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id:83 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYNAME",gxz:"Z12WWPEntityName",gxold:"O12WWPEntityName",gxvar:"A12WWPEntityName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A12WWPEntityName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z12WWPEntityName=Value},v2c:function(){gx.fn.setControlValue("WWPENTITYNAME",gx.O.A12WWPEntityName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A12WWPEntityName=this.val()},val:function(){return gx.fn.getControlValue("WWPENTITYNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 83 , function() {
   });
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id: 88, fld:"BTN_ENTER",grid:0,evt:"e11077_client",std:"ENTER"};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"BTN_CANCEL",grid:0,evt:"e12077_client"};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"BTN_DELETE",grid:0,evt:"e18077_client",std:"DELETE"};
   this.A14WWPNotificationDefinitionId = 0 ;
   this.Z14WWPNotificationDefinitionId = 0 ;
   this.O14WWPNotificationDefinitionId = 0 ;
   this.A53WWPNotificationDefinitionName = "" ;
   this.Z53WWPNotificationDefinitionName = "" ;
   this.O53WWPNotificationDefinitionName = "" ;
   this.A26WWPNotificationDefinitionAppliesTo = 0 ;
   this.Z26WWPNotificationDefinitionAppliesTo = 0 ;
   this.O26WWPNotificationDefinitionAppliesTo = 0 ;
   this.A27WWPNotificationDefinitionAllowUserSubscription = false ;
   this.Z27WWPNotificationDefinitionAllowUserSubscription = false ;
   this.O27WWPNotificationDefinitionAllowUserSubscription = false ;
   this.A25WWPNotificationDefinitionDescription = "" ;
   this.Z25WWPNotificationDefinitionDescription = "" ;
   this.O25WWPNotificationDefinitionDescription = "" ;
   this.A56WWPNotificationDefinitionIcon = "" ;
   this.Z56WWPNotificationDefinitionIcon = "" ;
   this.O56WWPNotificationDefinitionIcon = "" ;
   this.A57WWPNotificationDefinitionTitle = "" ;
   this.Z57WWPNotificationDefinitionTitle = "" ;
   this.O57WWPNotificationDefinitionTitle = "" ;
   this.A58WWPNotificationDefinitionShortDescription = "" ;
   this.Z58WWPNotificationDefinitionShortDescription = "" ;
   this.O58WWPNotificationDefinitionShortDescription = "" ;
   this.A59WWPNotificationDefinitionLongDescription = "" ;
   this.Z59WWPNotificationDefinitionLongDescription = "" ;
   this.O59WWPNotificationDefinitionLongDescription = "" ;
   this.A60WWPNotificationDefinitionLink = "" ;
   this.Z60WWPNotificationDefinitionLink = "" ;
   this.O60WWPNotificationDefinitionLink = "" ;
   this.A10WWPEntityId = 0 ;
   this.Z10WWPEntityId = 0 ;
   this.O10WWPEntityId = 0 ;
   this.A12WWPEntityName = "" ;
   this.Z12WWPEntityName = "" ;
   this.O12WWPEntityName = "" ;
   this.A14WWPNotificationDefinitionId = 0 ;
   this.A53WWPNotificationDefinitionName = "" ;
   this.A26WWPNotificationDefinitionAppliesTo = 0 ;
   this.A27WWPNotificationDefinitionAllowUserSubscription = false ;
   this.A25WWPNotificationDefinitionDescription = "" ;
   this.A56WWPNotificationDefinitionIcon = "" ;
   this.A57WWPNotificationDefinitionTitle = "" ;
   this.A58WWPNotificationDefinitionShortDescription = "" ;
   this.A59WWPNotificationDefinitionLongDescription = "" ;
   this.A60WWPNotificationDefinitionLink = "" ;
   this.A10WWPEntityId = 0 ;
   this.A12WWPEntityName = "" ;
   this.Events = {"e11077_client": ["ENTER", true] ,"e12077_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}],[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]];
   this.EvtParms["REFRESH"] = [[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}],[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONDEFINITIONID"] = [[{ctrl:'WWPNOTIFICATIONDEFINITIONAPPLIESTO'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}],[{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{ctrl:'WWPNOTIFICATIONDEFINITIONAPPLIESTO'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A56WWPNotificationDefinitionIcon',fld:'WWPNOTIFICATIONDEFINITIONICON',pic:''},{av:'A57WWPNotificationDefinitionTitle',fld:'WWPNOTIFICATIONDEFINITIONTITLE',pic:''},{av:'A58WWPNotificationDefinitionShortDescription',fld:'WWPNOTIFICATIONDEFINITIONSHORTDESCRIPTION',pic:''},{av:'A59WWPNotificationDefinitionLongDescription',fld:'WWPNOTIFICATIONDEFINITIONLONGDESCRIPTION',pic:''},{av:'A60WWPNotificationDefinitionLink',fld:'WWPNOTIFICATIONDEFINITIONLINK',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z53WWPNotificationDefinitionName'},{av:'Z26WWPNotificationDefinitionAppliesTo'},{av:'Z27WWPNotificationDefinitionAllowUserSubscription'},{av:'Z25WWPNotificationDefinitionDescription'},{av:'Z56WWPNotificationDefinitionIcon'},{av:'Z57WWPNotificationDefinitionTitle'},{av:'Z58WWPNotificationDefinitionShortDescription'},{av:'Z59WWPNotificationDefinitionLongDescription'},{av:'Z60WWPNotificationDefinitionLink'},{av:'Z10WWPEntityId'},{av:'Z12WWPEntityName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONDEFINITIONAPPLIESTO"] = [[{ctrl:'WWPNOTIFICATIONDEFINITIONAPPLIESTO'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}],[{ctrl:'WWPNOTIFICATIONDEFINITIONAPPLIESTO'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]];
   this.EvtParms["VALID_WWPNOTIFICATIONDEFINITIONLINK"] = [[{av:'A60WWPNotificationDefinitionLink',fld:'WWPNOTIFICATIONDEFINITIONLINK',pic:''},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}],[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]];
   this.EvtParms["VALID_WWPENTITYID"] = [[{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}],[{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.notifications.common.wwp_notificationdefinition);});
