gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.wwp_selectimportfile', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.wwp_selectimportfile" ;
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
      this.AV9ImportType=gx.fn.getControlValue("vIMPORTTYPE") ;
      this.AV5ErrorMsgs=gx.fn.getControlValue("vERRORMSGS") ;
      this.AV6ExtraParmsJson=gx.fn.getControlValue("vEXTRAPARMSJSON") ;
      this.AV14TransactionName=gx.fn.getControlValue("vTRANSACTIONNAME") ;
   };
   this.e110u1_client=function()
   {
      this.clearMessages();
      this.addMessage("<#CLEAR#>");
      WWPActions.WCPopup_Close("") ;
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e130u2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e150u2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24];
   this.GXLastCtrlId =24;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"TABLEATTRIBUTES",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id:17 ,lvl:0,type:"bitstr",len:1024,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILTERTOUPLOAD",gxz:"ZV7FilterToUpload",gxold:"OV7FilterToUpload",gxvar:"AV7FilterToUpload",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7FilterToUpload=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV7FilterToUpload=Value},v2c:function(){gx.fn.setBlobValue("vFILTERTOUPLOAD",gx.O.AV7FilterToUpload)},c2v:function(){if(this.val()!==undefined)gx.O.AV7FilterToUpload=this.val()},val:function(){return gx.fn.getBlobValue("vFILTERTOUPLOAD")},nac:gx.falseFn};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"BTNENTER",grid:0,evt:"e130u2_client",std:"ENTER"};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"BTNUCANCEL",grid:0,evt:"e110u1_client"};
   this.AV7FilterToUpload = "" ;
   this.ZV7FilterToUpload = "" ;
   this.OV7FilterToUpload = "" ;
   this.AV7FilterToUpload = "" ;
   this.AV14TransactionName = "" ;
   this.AV9ImportType = "" ;
   this.AV6ExtraParmsJson = "" ;
   this.AV5ErrorMsgs = [ ] ;
   this.Events = {"e130u2_client": ["ENTER", true] ,"e150u2_client": ["CANCEL", true] ,"e110u1_client": ["'DOUCANCEL'", false]};
   this.EvtParms["REFRESH"] = [[{av:'AV5ErrorMsgs',fld:'vERRORMSGS',pic:'',hsh:true}],[]];
   this.EvtParms["START"] = [[],[]];
   this.EvtParms["'DOUCANCEL'"] = [[],[]];
   this.EvtParms["ENTER"] = [[{ctrl:'vFILTERTOUPLOAD',prop:'Filename'},{av:'AV7FilterToUpload',fld:'vFILTERTOUPLOAD',pic:''},{av:'AV9ImportType',fld:'vIMPORTTYPE',pic:''},{av:'AV5ErrorMsgs',fld:'vERRORMSGS',pic:'',hsh:true},{av:'AV6ExtraParmsJson',fld:'vEXTRAPARMSJSON',pic:''},{av:'AV14TransactionName',fld:'vTRANSACTIONNAME',pic:''}],[{av:'AV7FilterToUpload',fld:'vFILTERTOUPLOAD',pic:''}]];
   this.EnterCtrl = ["BTNENTER"];
   this.setVCMap("AV9ImportType", "vIMPORTTYPE", 0, "svchar", 40, 0);
   this.setVCMap("AV5ErrorMsgs", "vERRORMSGS", 0, "CollGeneXus\Common\Messages.Message", 0, 0);
   this.setVCMap("AV6ExtraParmsJson", "vEXTRAPARMSJSON", 0, "svchar", 40, 0);
   this.setVCMap("AV14TransactionName", "vTRANSACTIONNAME", 0, "svchar", 40, 0);
   this.Initialize( );
});
