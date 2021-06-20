gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.homeprogressbarcirclewc', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.homeprogressbarcirclewc" ;
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
      this.AV6Percentage=gx.fn.getIntegerValue("vPERCENTAGE",'.') ;
   };
   this.e130s2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140s2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13];
   this.GXLastCtrlId =13;
   this.UCPBContainer = gx.uc.getNew(this, 9, 0, "DVProgressIndicator", this.CmpContext + "UCPBContainer", "Ucpb", "UCPB");
   var UCPBContainer = this.UCPBContainer;
   UCPBContainer.setProp("Class", "Class", "", "char");
   UCPBContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCPBContainer.setProp("Type", "Type", "Circle", "str");
   UCPBContainer.setProp("CircleCaptionType", "Circlecaptiontype", "Caption", "str");
   UCPBContainer.setDynProp("Caption", "Caption", "45%", "str");
   UCPBContainer.setProp("Subtitle", "Subtitle", "", "char");
   UCPBContainer.setProp("RawHTML", "Rawhtml", "", "char");
   UCPBContainer.setProp("Cls", "Cls", "CardsMenuProgressIndicatorCircle", "str");
   UCPBContainer.setDynProp("Percentage", "Percentage", 45, "num");
   UCPBContainer.setProp("BarWidth", "Barwidth", "", "char");
   UCPBContainer.setProp("CircleWidth", "Circlewidth", 46, "num");
   UCPBContainer.setProp("CircleProgressWidth", "Circleprogresswidth", 3, "num");
   UCPBContainer.setProp("AnimateOnStart", "Animateonstart", true, "bool");
   UCPBContainer.setProp("Visible", "Visible", true, "bool");
   UCPBContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCPBContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCPBContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id:13 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vOPTIONTITLE",gxz:"ZV5OptionTitle",gxold:"OV5OptionTitle",gxvar:"AV5OptionTitle",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV5OptionTitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5OptionTitle=Value},v2c:function(){gx.fn.setControlValue("vOPTIONTITLE",gx.O.AV5OptionTitle,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV5OptionTitle=this.val()},val:function(){return gx.fn.getControlValue("vOPTIONTITLE")},nac:gx.falseFn};
   this.AV5OptionTitle = "" ;
   this.AV6Percentage = 0 ;
   this.Events = {"e130s2_client": ["ENTER", true] ,"e140s2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[{av:'AV6Percentage',fld:'vPERCENTAGE',pic:'ZZZ9'}],[{av:'this.UCPBContainer.Percentage',ctrl:'UCPB',prop:'Percentage'},{av:'this.UCPBContainer.Caption',ctrl:'UCPB',prop:'Caption'}]];
   this.setVCMap("AV6Percentage", "vPERCENTAGE", 0, "int", 4, 0);
   this.Initialize( );
});
