gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.addressdisplay', false, function () {
   this.ServerClass =  "wwpbaseobjects.addressdisplay" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV5Address=gx.fn.getControlValue("vADDRESS") ;
      this.AV6Geolocation=gx.fn.getControlValue("vGEOLOCATION") ;
   };
   this.e130m2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140m2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5];
   this.GXLastCtrlId =5;
   GXValidFnc[2]={ id: 2, fld:"TABLEMAIN",grid:0};
   GXValidFnc[5]={ id: 5, fld:"UTEMBEDDEDPAGE",grid:0};
   this.AV5Address = "" ;
   this.AV6Geolocation = "" ;
   this.Events = {"e130m2_client": ["ENTER", true] ,"e140m2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'AV5Address',fld:'vADDRESS',pic:'',hsh:true},{av:'AV6Geolocation',fld:'vGEOLOCATION',pic:'',hsh:true}],[]];
   this.EvtParms["START"] = [[{av:'AV5Address',fld:'vADDRESS',pic:'',hsh:true},{av:'AV6Geolocation',fld:'vGEOLOCATION',pic:'',hsh:true}],[{ctrl:'GOOGLEMAPSEMBPAGE',prop:'Source'}]];
   this.setVCMap("AV5Address", "vADDRESS", 0, "svchar", 1000, 0);
   this.setVCMap("AV6Geolocation", "vGEOLOCATION", 0, "svchar", 200, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.addressdisplay);});
