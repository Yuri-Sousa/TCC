gx.evt.autoSkip=!1;gx.define("gam_masterpage",!1,function(){this.ServerClass="gam_masterpage";this.PackageName="GeneXus.Security.Backend";this.setObjectType("web");this.IsMasterPage=!0;this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e130t2_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e140t2_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,7,8];this.GXLastCtrlId=8;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};this.Events={e130t2_client:["ENTER_MPAGE",!0],e140t2_client:["CANCEL_MPAGE",!0]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms.START_MPAGE=[[],[{ctrl:"HEADER1_MPAGE"}]];this.Initialize();this.setComponent({id:"HEADER1",GXClass:null,Prefix:"MPW0006",lvl:1})});gx.wi(function(){gx.createMasterPage(gam_masterpage)})