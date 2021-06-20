gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.editbookmark', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.editbookmark" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV29i=gx.fn.getIntegerValue("vI",'.') ;
      this.AV18IsEdit=gx.fn.getControlValue("vISEDIT") ;
      this.AV16InBookmarkURL=gx.fn.getControlValue("vINBOOKMARKURL") ;
      this.AV9BookmarkPageDescription=gx.fn.getControlValue("vBOOKMARKPAGEDESCRIPTION") ;
   };
   this.Validv_Bookmarkurl=function()
   {
      return this.validCliEvt("Validv_Bookmarkurl", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("vBOOKMARKURL");
         this.AnyError  = 0;
         gxballoon.setAsFormatError();
         if ( ! ( gx.util.regExp.isMatch(this.AV10BookmarkURL, "^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            try {
               gxballoon.setError("O valor de Bookmark URL não coincide com o padrão especificado");
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
   this.e112b1_client=function()
   {
      this.clearMessages();
      WWPActions.WCPopup_Close("") ;
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e132b2_client=function()
   {
      return this.executeServerEvent("'DODEL'", false, null, false, false);
   };
   this.e142b2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e162b2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39];
   this.GXLastCtrlId =39;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"TABLECONTENT",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"UNNAMEDTABLEBOOKMARKNAME",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TEXTBLOCKBOOKMARKNAME", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id:21 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBOOKMARKNAME",gxz:"ZV5BookmarkName",gxold:"OV5BookmarkName",gxvar:"AV5BookmarkName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV5BookmarkName=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5BookmarkName=Value},v2c:function(){gx.fn.setControlValue("vBOOKMARKNAME",gx.O.AV5BookmarkName,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV5BookmarkName=this.val()},val:function(){return gx.fn.getControlValue("vBOOKMARKNAME")},nac:gx.falseFn};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"UNNAMEDTABLEBOOKMARKURL",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"TEXTBLOCKBOOKMARKURL", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id:30 ,lvl:0,type:"svchar",len:1000,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Bookmarkurl,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBOOKMARKURL",gxz:"ZV10BookmarkURL",gxold:"OV10BookmarkURL",gxvar:"AV10BookmarkURL",ucs:[],op:[],ip:[30],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV10BookmarkURL=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV10BookmarkURL=Value},v2c:function(){gx.fn.setControlValue("vBOOKMARKURL",gx.O.AV10BookmarkURL,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.AV10BookmarkURL=this.val()},val:function(){return gx.fn.getControlValue("vBOOKMARKURL")},nac:gx.falseFn};
   this.declareDomainHdlr( 30 , function() {
   });
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"BTNENTER",grid:0,evt:"e142b2_client",std:"ENTER"};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"BTNDEL",grid:0,evt:"e132b2_client"};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"BTNUSERCANCEL",grid:0,evt:"e112b1_client"};
   this.AV5BookmarkName = "" ;
   this.ZV5BookmarkName = "" ;
   this.OV5BookmarkName = "" ;
   this.AV10BookmarkURL = "" ;
   this.ZV10BookmarkURL = "" ;
   this.OV10BookmarkURL = "" ;
   this.AV5BookmarkName = "" ;
   this.AV10BookmarkURL = "" ;
   this.AV16InBookmarkURL = "" ;
   this.AV9BookmarkPageDescription = "" ;
   this.AV29i = 0 ;
   this.AV18IsEdit = false ;
   this.Events = {"e132b2_client": ["'DODEL'", true] ,"e142b2_client": ["ENTER", true] ,"e162b2_client": ["CANCEL", true] ,"e112b1_client": ["'DOUSERCANCEL'", false]};
   this.EvtParms["REFRESH"] = [[{av:'AV29i',fld:'vI',pic:'ZZZ9',hsh:true}],[]];
   this.EvtParms["START"] = [[{av:'AV16InBookmarkURL',fld:'vINBOOKMARKURL',pic:''},{av:'AV9BookmarkPageDescription',fld:'vBOOKMARKPAGEDESCRIPTION',pic:''}],[{av:'AV10BookmarkURL',fld:'vBOOKMARKURL',pic:''},{av:'AV5BookmarkName',fld:'vBOOKMARKNAME',pic:''},{av:'AV29i',fld:'vI',pic:'ZZZ9',hsh:true},{ctrl:'BTNDEL',prop:'Visible'},{ctrl:'FORM',prop:'Caption'}]];
   this.EvtParms["'DODEL'"] = [[{av:'AV29i',fld:'vI',pic:'ZZZ9',hsh:true}],[]];
   this.EvtParms["'DOUSERCANCEL'"] = [[],[]];
   this.EvtParms["ENTER"] = [[{av:'AV5BookmarkName',fld:'vBOOKMARKNAME',pic:''},{av:'AV10BookmarkURL',fld:'vBOOKMARKURL',pic:''},{av:'AV18IsEdit',fld:'vISEDIT',pic:''}],[{av:'AV5BookmarkName',fld:'vBOOKMARKNAME',pic:''},{av:'AV18IsEdit',fld:'vISEDIT',pic:''}]];
   this.EvtParms["VALIDV_BOOKMARKURL"] = [[],[]];
   this.EnterCtrl = ["BTNENTER"];
   this.setVCMap("AV29i", "vI", 0, "int", 4, 0);
   this.setVCMap("AV18IsEdit", "vISEDIT", 0, "boolean", 4, 0);
   this.setVCMap("AV16InBookmarkURL", "vINBOOKMARKURL", 0, "svchar", 1000, 0);
   this.setVCMap("AV9BookmarkPageDescription", "vBOOKMARKPAGEDESCRIPTION", 0, "svchar", 200, 0);
   this.Initialize( );
});
