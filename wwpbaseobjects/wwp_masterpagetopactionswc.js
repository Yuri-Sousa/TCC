gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.wwp_masterpagetopactionswc', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.wwp_masterpagetopactionswc" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.e12312_client=function()
   {
      return this.executeServerEvent("'DOACTIONCHANGEPASSWORD'", true, null, false, false);
   };
   this.e13312_client=function()
   {
      return this.executeServerEvent("'DOLOGOUT'", true, null, false, false);
   };
   this.e15312_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e16312_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,19,20];
   this.GXLastCtrlId =20;
   this.BTNACTIONCHANGEPASSWORDContainer = gx.uc.getNew(this, 18, 12, "WWP_IconButton", this.CmpContext + "BTNACTIONCHANGEPASSWORDContainer", "Btnactionchangepassword", "BTNACTIONCHANGEPASSWORD");
   var BTNACTIONCHANGEPASSWORDContainer = this.BTNACTIONCHANGEPASSWORDContainer;
   BTNACTIONCHANGEPASSWORDContainer.setProp("Enabled", "Enabled", true, "boolean");
   BTNACTIONCHANGEPASSWORDContainer.setProp("BeforeIconClass", "Beforeiconclass", "fa fa-lock FontIconTopRightActions", "str");
   BTNACTIONCHANGEPASSWORDContainer.setProp("AfterIconClass", "Aftericonclass", "", "str");
   BTNACTIONCHANGEPASSWORDContainer.addEventHandler("Event", this.e12312_client);
   BTNACTIONCHANGEPASSWORDContainer.setProp("Caption", "Caption", "Alterar sua senha", "str");
   BTNACTIONCHANGEPASSWORDContainer.setProp("Class", "Class", "MasterPageTopActionsOption", "str");
   BTNACTIONCHANGEPASSWORDContainer.setProp("Visible", "Visible", true, "bool");
   BTNACTIONCHANGEPASSWORDContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(BTNACTIONCHANGEPASSWORDContainer);
   this.BTNLOGOUTContainer = gx.uc.getNew(this, 21, 12, "WWP_IconButton", this.CmpContext + "BTNLOGOUTContainer", "Btnlogout", "BTNLOGOUT");
   var BTNLOGOUTContainer = this.BTNLOGOUTContainer;
   BTNLOGOUTContainer.setProp("Enabled", "Enabled", true, "boolean");
   BTNLOGOUTContainer.setProp("BeforeIconClass", "Beforeiconclass", "fas fa-sign-out-alt FontIconTopRightActions", "str");
   BTNLOGOUTContainer.setProp("AfterIconClass", "Aftericonclass", "", "str");
   BTNLOGOUTContainer.addEventHandler("Event", this.e13312_client);
   BTNLOGOUTContainer.setProp("Caption", "Caption", "Fechar sessão", "str");
   BTNLOGOUTContainer.setProp("Class", "Class", "MasterPageTopActionsOption", "str");
   BTNLOGOUTContainer.setProp("Visible", "Visible", true, "bool");
   BTNLOGOUTContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(BTNLOGOUTContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"USERINFORMATION",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id:12 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERIMAGE",gxz:"ZV5UserImage",gxold:"OV5UserImage",gxvar:"AV5UserImage",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV5UserImage=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5UserImage=Value},v2c:function(){gx.fn.setMultimediaValue("vUSERIMAGE",gx.O.AV5UserImage,gx.O.AV15Userimage_GXI)},c2v:function(){gx.O.AV15Userimage_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV5UserImage=this.val()},val:function(){return gx.fn.getBlobValue("vUSERIMAGE")},val_GXI:function(){return gx.fn.getControlValue("vUSERIMAGE_GXI")}, gxvar_GXI:'AV15Userimage_GXI',nac:gx.falseFn};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id:15 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",gxz:"ZV6UserName",gxold:"OV6UserName",gxvar:"AV6UserName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV6UserName=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV6UserName=Value},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV6UserName,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV6UserName=this.val()},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   this.AV15Userimage_GXI = "" ;
   this.AV5UserImage = "" ;
   this.ZV5UserImage = "" ;
   this.OV5UserImage = "" ;
   this.AV6UserName = "" ;
   this.ZV6UserName = "" ;
   this.OV6UserName = "" ;
   this.AV5UserImage = "" ;
   this.AV6UserName = "" ;
   this.Events = {"e12312_client": ["'DOACTIONCHANGEPASSWORD'", true] ,"e13312_client": ["'DOLOGOUT'", true] ,"e15312_client": ["ENTER", true] ,"e16312_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[],[{av:'AV6UserName',fld:'vUSERNAME',pic:''},{av:'AV5UserImage',fld:'vUSERIMAGE',pic:''}]];
   this.EvtParms["'DOACTIONCHANGEPASSWORD'"] = [[],[]];
   this.EvtParms["'DOLOGOUT'"] = [[],[]];
   this.Initialize( );
});
