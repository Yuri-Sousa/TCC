gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.notifications.web.wwp_webclient', false, function () {
   this.ServerClass =  "wwpbaseobjects.notifications.web.wwp_webclient" ;
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
   this.Valid_Wwpwebclientid=function()
   {
      return this.validSrvEvt("Valid_Wwpwebclientid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpwebclientbrowserid=function()
   {
      return this.validCliEvt("Valid_Wwpwebclientbrowserid", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBCLIENTBROWSERID");
         this.AnyError  = 0;
         if ( ! ( ( this.A43WWPWebClientBrowserId == 0 ) || ( this.A43WWPWebClientBrowserId == 1 ) || ( this.A43WWPWebClientBrowserId == 2 ) || ( this.A43WWPWebClientBrowserId == 3 ) || ( this.A43WWPWebClientBrowserId == 5 ) || ( this.A43WWPWebClientBrowserId == 6 ) || ( this.A43WWPWebClientBrowserId == 7 ) || ( this.A43WWPWebClientBrowserId == 8 ) || ( this.A43WWPWebClientBrowserId == 9 ) ) )
         {
            try {
               gxballoon.setError("Campo Web Client Browser Id fora do intervalo");
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
   this.Valid_Wwpwebclientfirstregistered=function()
   {
      return this.validCliEvt("Valid_Wwpwebclientfirstregistered", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBCLIENTFIRSTREGISTERED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A45WWPWebClientFirstRegistered)==0) || new gx.date.gxdate( this.A45WWPWebClientFirstRegistered ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Web Client First Registered fora do intervalo");
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
   this.Valid_Wwpwebclientlastregistered=function()
   {
      return this.validCliEvt("Valid_Wwpwebclientlastregistered", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPWEBCLIENTLASTREGISTERED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A46WWPWebClientLastRegistered)==0) || new gx.date.gxdate( this.A46WWPWebClientLastRegistered ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Web Client Last Registered fora do intervalo");
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
   this.e11066_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12066_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62];
   this.GXLastCtrlId =62;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13066_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14066_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15066_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16066_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17066_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebclientid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBCLIENTID",gxz:"Z18WWPWebClientId",gxold:"O18WWPWebClientId",gxvar:"A18WWPWebClientId",ucs:[],op:[53,48,43,38,33],ip:[53,48,43,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A18WWPWebClientId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z18WWPWebClientId=Value},v2c:function(){gx.fn.setControlValue("WWPWEBCLIENTID",gx.O.A18WWPWebClientId,0)},c2v:function(){if(this.val()!==undefined)gx.O.A18WWPWebClientId=this.val()},val:function(){return gx.fn.getControlValue("WWPWEBCLIENTID")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebclientbrowserid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBCLIENTBROWSERID",gxz:"Z43WWPWebClientBrowserId",gxold:"O43WWPWebClientBrowserId",gxvar:"A43WWPWebClientBrowserId",ucs:[],op:[33],ip:[33],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A43WWPWebClientBrowserId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z43WWPWebClientBrowserId=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("WWPWEBCLIENTBROWSERID",gx.O.A43WWPWebClientBrowserId);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A43WWPWebClientBrowserId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPWEBCLIENTBROWSERID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 33 , function() {
   });
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBCLIENTBROWSERVERSION",gxz:"Z44WWPWebClientBrowserVersion",gxold:"O44WWPWebClientBrowserVersion",gxvar:"A44WWPWebClientBrowserVersion",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A44WWPWebClientBrowserVersion=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z44WWPWebClientBrowserVersion=Value},v2c:function(){gx.fn.setControlValue("WWPWEBCLIENTBROWSERVERSION",gx.O.A44WWPWebClientBrowserVersion,0)},c2v:function(){if(this.val()!==undefined)gx.O.A44WWPWebClientBrowserVersion=this.val()},val:function(){return gx.fn.getControlValue("WWPWEBCLIENTBROWSERVERSION")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebclientfirstregistered,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBCLIENTFIRSTREGISTERED",gxz:"Z45WWPWebClientFirstRegistered",gxold:"O45WWPWebClientFirstRegistered",gxvar:"A45WWPWebClientFirstRegistered",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[43],ip:[43],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A45WWPWebClientFirstRegistered=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z45WWPWebClientFirstRegistered=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPWEBCLIENTFIRSTREGISTERED",gx.O.A45WWPWebClientFirstRegistered,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A45WWPWebClientFirstRegistered=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPWEBCLIENTFIRSTREGISTERED")},nac:gx.falseFn};
   this.declareDomainHdlr( 43 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpwebclientlastregistered,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPWEBCLIENTLASTREGISTERED",gxz:"Z46WWPWebClientLastRegistered",gxold:"O46WWPWebClientLastRegistered",gxvar:"A46WWPWebClientLastRegistered",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[48],ip:[48],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A46WWPWebClientLastRegistered=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z46WWPWebClientLastRegistered=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPWEBCLIENTLASTREGISTERED",gx.O.A46WWPWebClientLastRegistered,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A46WWPWebClientLastRegistered=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPWEBCLIENTLASTREGISTERED")},nac:gx.falseFn};
   this.declareDomainHdlr( 48 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"char",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpuserextendedid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDID",gxz:"Z1WWPUserExtendedId",gxold:"O1WWPUserExtendedId",gxvar:"A1WWPUserExtendedId",ucs:[],op:[],ip:[53],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1WWPUserExtendedId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1WWPUserExtendedId=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDID",gx.O.A1WWPUserExtendedId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1WWPUserExtendedId=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDID")},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"BTN_ENTER",grid:0,evt:"e11066_client",std:"ENTER"};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"BTN_CANCEL",grid:0,evt:"e12066_client"};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"BTN_DELETE",grid:0,evt:"e18066_client",std:"DELETE"};
   this.A18WWPWebClientId = "" ;
   this.Z18WWPWebClientId = "" ;
   this.O18WWPWebClientId = "" ;
   this.A43WWPWebClientBrowserId = 0 ;
   this.Z43WWPWebClientBrowserId = 0 ;
   this.O43WWPWebClientBrowserId = 0 ;
   this.A44WWPWebClientBrowserVersion = "" ;
   this.Z44WWPWebClientBrowserVersion = "" ;
   this.O44WWPWebClientBrowserVersion = "" ;
   this.A45WWPWebClientFirstRegistered = gx.date.nullDate() ;
   this.Z45WWPWebClientFirstRegistered = gx.date.nullDate() ;
   this.O45WWPWebClientFirstRegistered = gx.date.nullDate() ;
   this.A46WWPWebClientLastRegistered = gx.date.nullDate() ;
   this.Z46WWPWebClientLastRegistered = gx.date.nullDate() ;
   this.O46WWPWebClientLastRegistered = gx.date.nullDate() ;
   this.A1WWPUserExtendedId = "" ;
   this.Z1WWPUserExtendedId = "" ;
   this.O1WWPUserExtendedId = "" ;
   this.A18WWPWebClientId = "" ;
   this.Gx_BScreen = 0 ;
   this.A43WWPWebClientBrowserId = 0 ;
   this.A44WWPWebClientBrowserVersion = "" ;
   this.A45WWPWebClientFirstRegistered = gx.date.nullDate() ;
   this.A46WWPWebClientLastRegistered = gx.date.nullDate() ;
   this.A1WWPUserExtendedId = "" ;
   this.Events = {"e11066_client": ["ENTER", true] ,"e12066_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_WWPWEBCLIENTID"] = [[{ctrl:'WWPWEBCLIENTBROWSERID'},{av:'A43WWPWebClientBrowserId',fld:'WWPWEBCLIENTBROWSERID',pic:'ZZZ9'},{av:'A18WWPWebClientId',fld:'WWPWEBCLIENTID',pic:''},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A45WWPWebClientFirstRegistered',fld:'WWPWEBCLIENTFIRSTREGISTERED',pic:'99/99/9999 99:99:99.999'},{av:'A46WWPWebClientLastRegistered',fld:'WWPWEBCLIENTLASTREGISTERED',pic:'99/99/9999 99:99:99.999'}],[{ctrl:'WWPWEBCLIENTBROWSERID'},{av:'A43WWPWebClientBrowserId',fld:'WWPWEBCLIENTBROWSERID',pic:'ZZZ9'},{av:'A44WWPWebClientBrowserVersion',fld:'WWPWEBCLIENTBROWSERVERSION',pic:''},{av:'A45WWPWebClientFirstRegistered',fld:'WWPWEBCLIENTFIRSTREGISTERED',pic:'99/99/9999 99:99:99.999'},{av:'A46WWPWebClientLastRegistered',fld:'WWPWEBCLIENTLASTREGISTERED',pic:'99/99/9999 99:99:99.999'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z18WWPWebClientId'},{av:'Z43WWPWebClientBrowserId'},{av:'Z44WWPWebClientBrowserVersion'},{av:'Z45WWPWebClientFirstRegistered'},{av:'Z46WWPWebClientLastRegistered'},{av:'Z1WWPUserExtendedId'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_WWPWEBCLIENTBROWSERID"] = [[{ctrl:'WWPWEBCLIENTBROWSERID'},{av:'A43WWPWebClientBrowserId',fld:'WWPWEBCLIENTBROWSERID',pic:'ZZZ9'}],[{ctrl:'WWPWEBCLIENTBROWSERID'},{av:'A43WWPWebClientBrowserId',fld:'WWPWEBCLIENTBROWSERID',pic:'ZZZ9'}]];
   this.EvtParms["VALID_WWPWEBCLIENTFIRSTREGISTERED"] = [[{av:'A45WWPWebClientFirstRegistered',fld:'WWPWEBCLIENTFIRSTREGISTERED',pic:'99/99/9999 99:99:99.999'}],[{av:'A45WWPWebClientFirstRegistered',fld:'WWPWEBCLIENTFIRSTREGISTERED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPWEBCLIENTLASTREGISTERED"] = [[{av:'A46WWPWebClientLastRegistered',fld:'WWPWEBCLIENTLASTREGISTERED',pic:'99/99/9999 99:99:99.999'}],[{av:'A46WWPWebClientLastRegistered',fld:'WWPWEBCLIENTLASTREGISTERED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPUSEREXTENDEDID"] = [[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''}],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("Gx_BScreen", "vGXBSCREEN", 0, "int", 1, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.notifications.web.wwp_webclient);});
