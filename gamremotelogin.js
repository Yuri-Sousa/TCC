gx.evt.autoSkip=!1;gx.define("gamremotelogin",!1,function(){this.ServerClass="gamremotelogin";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV32ApplicationClientId=gx.fn.getControlValue("vAPPLICATIONCLIENTID");this.AV18Language=gx.fn.getControlValue("vLANGUAGE");this.AV30UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",".")};this.e120f2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e150f2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,24,25,28,29,32,33,36,37,38,39,40,41,42,45,46,47,48,49,50,51,54,57,58,61,62,65,66,67,68,69,70];this.GXLastCtrlId=70;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLECONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"HEADERORIGINAL",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLELOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"SIGNIN",format:0,grid:0,ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"UNNAMEDTABLE1",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGOAPPCLIENT",gxz:"ZV20LogoAppClient",gxold:"OV20LogoAppClient",gxvar:"AV20LogoAppClient",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20LogoAppClient=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20LogoAppClient=n)},v2c:function(){gx.fn.setMultimediaValue("vLOGOAPPCLIENT",gx.O.AV20LogoAppClient,gx.O.AV41Logoappclient_GXI)},c2v:function(){gx.O.AV41Logoappclient_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV20LogoAppClient=this.val())},val:function(){return gx.fn.getBlobValue("vLOGOAPPCLIENT")},val_GXI:function(){return gx.fn.getControlValue("vLOGOAPPCLIENT_GXI")},gxvar_GXI:"AV41Logoappclient_GXI",nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCMPNAME",gxz:"ZV34CmpName",gxold:"OV34CmpName",gxvar:"AV34CmpName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV34CmpName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV34CmpName=n)},v2c:function(){gx.fn.setControlValue("vCMPNAME",gx.O.AV34CmpName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV34CmpName=this.val())},val:function(){return gx.fn.getControlValue("vCMPNAME")},nac:gx.falseFn};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGONTO",gxz:"ZV21LogOnTo",gxold:"OV21LogOnTo",gxvar:"AV21LogOnTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV21LogOnTo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21LogOnTo=n)},v2c:function(){gx.fn.setComboBoxValue("vLOGONTO",gx.O.AV21LogOnTo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV21LogOnTo=this.val())},val:function(){return gx.fn.getControlValue("vLOGONTO")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});n[36]={id:36,fld:"UNNAMEDTABLEUSERNAME",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TEXTBLOCKUSERNAME",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",gxz:"ZV28UserName",gxold:"OV28UserName",gxvar:"AV28UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV28UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(42,function(){});n[45]={id:45,fld:"UNNAMEDTABLEUSERPASSWORD",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"TEXTBLOCKUSERPASSWORD",format:0,grid:0,ctrltype:"textblock"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",gxz:"ZV29UserPassword",gxold:"OV29UserPassword",gxvar:"AV29UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV29UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV29UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV29UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(51,function(){});n[54]={id:54,fld:"FORGOTPASSWORD",format:1,grid:0,ctrltype:"textblock"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEEPMELOGGEDIN",gxz:"ZV17KeepMeLoggedIn",gxold:"OV17KeepMeLoggedIn",gxvar:"AV17KeepMeLoggedIn",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV17KeepMeLoggedIn=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17KeepMeLoggedIn=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vKEEPMELOGGEDIN",gx.O.AV17KeepMeLoggedIn,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17KeepMeLoggedIn=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vKEEPMELOGGEDIN")},nac:gx.falseFn,values:["true","false"]};n[61]={id:61,fld:"",grid:0};n[62]={id:62,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREMEMBERME",gxz:"ZV22RememberMe",gxold:"OV22RememberMe",gxvar:"AV22RememberMe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV22RememberMe=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV22RememberMe=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vREMEMBERME",gx.O.AV22RememberMe,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV22RememberMe=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vREMEMBERME")},nac:gx.falseFn,values:["true","false"]};n[65]={id:65,fld:"BTNENTER",grid:0,evt:"e120f2_client",std:"ENTER"};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"TABLELOGINERROR",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};this.AV41Logoappclient_GXI="";this.AV20LogoAppClient="";this.ZV20LogoAppClient="";this.OV20LogoAppClient="";this.AV34CmpName="";this.ZV34CmpName="";this.OV34CmpName="";this.AV21LogOnTo="";this.ZV21LogOnTo="";this.OV21LogOnTo="";this.AV28UserName="";this.ZV28UserName="";this.OV28UserName="";this.AV29UserPassword="";this.ZV29UserPassword="";this.OV29UserPassword="";this.AV17KeepMeLoggedIn=!1;this.ZV17KeepMeLoggedIn=!1;this.OV17KeepMeLoggedIn=!1;this.AV22RememberMe=!1;this.ZV22RememberMe=!1;this.OV22RememberMe=!1;this.AV20LogoAppClient="";this.AV34CmpName="";this.AV21LogOnTo="";this.AV28UserName="";this.AV29UserPassword="";this.AV17KeepMeLoggedIn=!1;this.AV22RememberMe=!1;this.AV32ApplicationClientId="";this.AV18Language="";this.AV30UserRememberMe=0;this.Events={e120f2_client:["ENTER",!0],e150f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV32ApplicationClientId",fld:"vAPPLICATIONCLIENTID",pic:""},{av:"AV28UserName",fld:"vUSERNAME",pic:""},{av:"AV18Language",fld:"vLANGUAGE",pic:"",hsh:!0},{av:"AV30UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""}],[{av:"AV32ApplicationClientId",fld:"vAPPLICATIONCLIENTID",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""},{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TABLELOGINERROR","Visible")',ctrl:"TABLELOGINERROR",prop:"Visible"},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""}]];this.EvtParms.START=[[{av:"AV32ApplicationClientId",fld:"vAPPLICATIONCLIENTID",pic:""},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""}],[{ctrl:"FORM",prop:"Backcolor"},{av:"AV34CmpName",fld:"vCMPNAME",pic:""},{av:'gx.fn.getCtrlProperty("TABLELOGINERROR","Visible")',ctrl:"TABLELOGINERROR",prop:"Visible"},{av:'gx.fn.getCtrlProperty("FORGOTPASSWORD","Link")',ctrl:"FORGOTPASSWORD",prop:"Link"},{av:'gx.fn.getCtrlProperty("vLOGOAPPCLIENT","Visible")',ctrl:"vLOGOAPPCLIENT",prop:"Visible"},{av:'gx.fn.getCtrlProperty("LOGOAPPCLIENT_CELL","Class")',ctrl:"LOGOAPPCLIENT_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCMPNAME","Visible")',ctrl:"vCMPNAME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("CMPNAME_CELL","Class")',ctrl:"CMPNAME_CELL",prop:"Class"},{ctrl:"vLOGONTO"},{av:'gx.fn.getCtrlProperty("LOGONTO_CELL","Class")',ctrl:"LOGONTO_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:'gx.fn.getCtrlProperty("KEEPMELOGGEDIN_CELL","Class")',ctrl:"KEEPMELOGGEDIN_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("REMEMBERME_CELL","Class")',ctrl:"REMEMBERME_CELL",prop:"Class"},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""}]];this.EvtParms.ENTER=[[{ctrl:"vLOGONTO"},{av:"AV21LogOnTo",fld:"vLOGONTO",pic:""},{av:"AV28UserName",fld:"vUSERNAME",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV32ApplicationClientId",fld:"vAPPLICATIONCLIENTID",pic:""},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""}],[{av:"AV32ApplicationClientId",fld:"vAPPLICATIONCLIENTID",pic:""},{av:"AV29UserPassword",fld:"vUSERPASSWORD",pic:""},{av:'gx.fn.getCtrlProperty("TABLELOGINERROR","Visible")',ctrl:"TABLELOGINERROR",prop:"Visible"},{av:"AV17KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV22RememberMe",fld:"vREMEMBERME",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV32ApplicationClientId","vAPPLICATIONCLIENTID",0,"char",40,0);this.setVCMap("AV18Language","vLANGUAGE",0,"char",3,0);this.setVCMap("AV30UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.Initialize()});gx.wi(function(){gx.createParentObj(gamremotelogin)})