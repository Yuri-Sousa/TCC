gx.evt.autoSkip=!1;gx.define("gam_dashboard",!1,function(){this.ServerClass="gam_dashboard";this.PackageName="GeneXus.Security.Backend";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e132u2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e142u2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3];this.GXLastCtrlId=3;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};this.Events={e132u2_client:["ENTER",!0],e142u2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.START=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(gam_dashboard)})