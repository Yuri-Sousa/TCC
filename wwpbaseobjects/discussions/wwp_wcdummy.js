gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.discussions.wwp_wcdummy', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.discussions.wwp_wcdummy" ;
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
   this.e122a2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e132a2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3];
   this.GXLastCtrlId =3;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   this.Events = {"e122a2_client": ["ENTER", true] ,"e132a2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.Initialize( );
});
