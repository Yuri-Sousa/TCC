gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.homeprogressbarwc', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.homeprogressbarwc" ;
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
      this.AV9BarDescription=gx.fn.getControlValue("vBARDESCRIPTION") ;
      this.AV6Percentage=gx.fn.getIntegerValue("vPERCENTAGE",'.') ;
   };
   this.e130t2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140t2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16];
   this.GXLastCtrlId =16;
   this.PROGRESSBAR1Container = gx.uc.getNew(this, 12, 0, "DVProgressIndicator", this.CmpContext + "PROGRESSBAR1Container", "Progressbar1", "PROGRESSBAR1");
   var PROGRESSBAR1Container = this.PROGRESSBAR1Container;
   PROGRESSBAR1Container.setProp("Class", "Class", "", "char");
   PROGRESSBAR1Container.setProp("Enabled", "Enabled", true, "boolean");
   PROGRESSBAR1Container.setProp("Type", "Type", "Bar", "str");
   PROGRESSBAR1Container.setProp("CircleCaptionType", "Circlecaptiontype", "", "char");
   PROGRESSBAR1Container.setProp("Caption", "Caption", "", "str");
   PROGRESSBAR1Container.setProp("Subtitle", "Subtitle", "", "char");
   PROGRESSBAR1Container.setProp("RawHTML", "Rawhtml", "", "char");
   PROGRESSBAR1Container.setProp("Cls", "Cls", "", "str");
   PROGRESSBAR1Container.setDynProp("Percentage", "Percentage", 83, "num");
   PROGRESSBAR1Container.setProp("BarWidth", "Barwidth", "100%", "str");
   PROGRESSBAR1Container.setProp("CircleWidth", "Circlewidth", '', "int");
   PROGRESSBAR1Container.setProp("CircleProgressWidth", "Circleprogresswidth", '', "int");
   PROGRESSBAR1Container.setProp("AnimateOnStart", "Animateonstart", true, "bool");
   PROGRESSBAR1Container.setProp("Visible", "Visible", true, "bool");
   PROGRESSBAR1Container.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   PROGRESSBAR1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(PROGRESSBAR1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"DESCRIPTIONPROGRESSBAR1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id:16 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vOPTIONTITLE",gxz:"ZV5OptionTitle",gxold:"OV5OptionTitle",gxvar:"AV5OptionTitle",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV5OptionTitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5OptionTitle=Value},v2c:function(){gx.fn.setControlValue("vOPTIONTITLE",gx.O.AV5OptionTitle,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV5OptionTitle=this.val()},val:function(){return gx.fn.getControlValue("vOPTIONTITLE")},nac:gx.falseFn};
   this.AV5OptionTitle = "" ;
   this.AV9BarDescription = "" ;
   this.AV6Percentage = 0 ;
   this.Events = {"e130t2_client": ["ENTER", true] ,"e140t2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[{av:'AV6Percentage',fld:'vPERCENTAGE',pic:'Z9'},{av:'AV9BarDescription',fld:'vBARDESCRIPTION',pic:''}],[{av:'this.PROGRESSBAR1Container.Percentage',ctrl:'PROGRESSBAR1',prop:'Percentage'},{av:'gx.fn.getCtrlProperty("DESCRIPTIONPROGRESSBAR1","Caption")',ctrl:'DESCRIPTIONPROGRESSBAR1',prop:'Caption'}]];
   this.setVCMap("AV9BarDescription", "vBARDESCRIPTION", 0, "svchar", 40, 0);
   this.setVCMap("AV6Percentage", "vPERCENTAGE", 0, "int", 2, 0);
   this.Initialize( );
});
