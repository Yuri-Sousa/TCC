gx.evt.autoSkip=!1;gx.define("gamconnectionentry",!1,function(){var n,t,i;this.ServerClass="gamconnectionentry";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.Gx_mode=gx.fn.getControlValue("vMODE")};this.s122_client=function(){gx.text.compare(this.Gx_mode,"INS")==0?(gx.fn.setCtrlProperty("vUSERPASSWORD","Visible",!0),gx.fn.setCtrlProperty("USERPASSWORD_CELL","Class","col-xs-12 col-sm-6 DataContentCell DscTop")):(gx.fn.setCtrlProperty("vUSERPASSWORD","Visible",!1),gx.fn.setCtrlProperty("USERPASSWORD_CELL","Class","Invisible"));gx.text.compare(this.Gx_mode,"XML")==0?gx.fn.setCtrlProperty("DVPANEL_GAMCONNECTION_CELL","Class","col-xs-12 CellMarginTop"):gx.fn.setCtrlProperty("DVPANEL_GAMCONNECTION_CELL","Class","Invisible")};this.e12172_client=function(){return this.executeServerEvent("'DOGENKEY'",!1,null,!1,!1)};this.e13172_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15171_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,46,47,49,50,51,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70];this.GXLastCtrlId=70;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Conexão","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.DVPANEL_GAMCONNECTIONContainer=gx.uc.getNew(this,52,22,"BootstrapPanel","DVPANEL_GAMCONNECTIONContainer","Dvpanel_gamconnection","DVPANEL_GAMCONNECTION");i=this.DVPANEL_GAMCONNECTIONContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelFilled Panel_BaseColor","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Conteúdo do connection.gam","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCONNECTIONNAME",gxz:"ZV8ConnectionName",gxold:"OV8ConnectionName",gxvar:"AV8ConnectionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8ConnectionName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8ConnectionName=n)},v2c:function(){gx.fn.setControlValue("vCONNECTIONNAME",gx.O.AV8ConnectionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV8ConnectionName=this.val())},val:function(){return gx.fn.getControlValue("vCONNECTIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",gxz:"ZV14UserName",gxold:"OV14UserName",gxvar:"AV14UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV14UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"USERPASSWORD_CELL",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",gxz:"ZV15UserPassword",gxold:"OV15UserPassword",gxvar:"AV15UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV15UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCHALLENGEEXPIRE",gxz:"ZV5ChallengeExpire",gxold:"OV5ChallengeExpire",gxvar:"AV5ChallengeExpire",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5ChallengeExpire=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5ChallengeExpire=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCHALLENGEEXPIRE",gx.O.AV5ChallengeExpire,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5ChallengeExpire=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCHALLENGEEXPIRE",".")},nac:gx.falseFn};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"TABLESPLITTEDKEY",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"TEXTBLOCKKEY",format:0,grid:0,ctrltype:"textblock"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"TABLEMERGEDKEY",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"char",len:32,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEY",gxz:"ZV12Key",gxold:"OV12Key",gxvar:"AV12Key",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12Key=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Key=n)},v2c:function(){gx.fn.setControlValue("vKEY",gx.O.AV12Key,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12Key=this.val())},val:function(){return gx.fn.getControlValue("vKEY")},nac:gx.falseFn};this.declareDomainHdlr(47,function(){});n[49]={id:49,fld:"BTNGENKEY",grid:0,evt:"e12172_client"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"DVPANEL_GAMCONNECTION_CELL",grid:0};n[54]={id:54,fld:"GAMCONNECTION",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"char",len:2e3,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCONNECTIONFILEXML",gxz:"ZV7ConnectionFileXML",gxold:"OV7ConnectionFileXML",gxvar:"AV7ConnectionFileXML",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7ConnectionFileXML=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7ConnectionFileXML=n)},v2c:function(){gx.fn.setControlValue("vCONNECTIONFILEXML",gx.O.AV7ConnectionFileXML,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7ConnectionFileXML=this.val())},val:function(){return gx.fn.getControlValue("vCONNECTIONFILEXML")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTNENTER",grid:0,evt:"e13172_client",std:"ENTER"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"BTNCANCEL",grid:0,evt:"e15171_client"};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[70]={id:70,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPCONNECTIONNAME",gxz:"ZV13pConnectionName",gxold:"OV13pConnectionName",gxvar:"AV13pConnectionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13pConnectionName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13pConnectionName=n)},v2c:function(){gx.fn.setControlValue("vPCONNECTIONNAME",gx.O.AV13pConnectionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13pConnectionName=this.val())},val:function(){return gx.fn.getControlValue("vPCONNECTIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(70,function(){});this.AV8ConnectionName="";this.ZV8ConnectionName="";this.OV8ConnectionName="";this.AV14UserName="";this.ZV14UserName="";this.OV14UserName="";this.AV15UserPassword="";this.ZV15UserPassword="";this.OV15UserPassword="";this.AV5ChallengeExpire=0;this.ZV5ChallengeExpire=0;this.OV5ChallengeExpire=0;this.AV12Key="";this.ZV12Key="";this.OV12Key="";this.AV7ConnectionFileXML="";this.ZV7ConnectionFileXML="";this.OV7ConnectionFileXML="";this.AV13pConnectionName="";this.ZV13pConnectionName="";this.OV13pConnectionName="";this.AV8ConnectionName="";this.AV14UserName="";this.AV15UserPassword="";this.AV5ChallengeExpire=0;this.AV12Key="";this.AV7ConnectionFileXML="";this.AV13pConnectionName="";this.Gx_mode="";this.Events={e12172_client:["'DOGENKEY'",!0],e13172_client:["ENTER",!0],e15171_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV13pConnectionName",fld:"vPCONNECTIONNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7ConnectionFileXML",fld:"vCONNECTIONFILEXML",pic:""}],[{av:"AV8ConnectionName",fld:"vCONNECTIONNAME",pic:""},{av:'gx.fn.getCtrlProperty("vCONNECTIONFILEXML","Visible")',ctrl:"vCONNECTIONFILEXML",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vPCONNECTIONNAME","Visible")',ctrl:"vPCONNECTIONNAME",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vCONNECTIONNAME","Enabled")',ctrl:"vCONNECTIONNAME",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vUSERNAME","Enabled")',ctrl:"vUSERNAME",prop:"Enabled"},{av:"AV14UserName",fld:"vUSERNAME",pic:""},{av:"AV15UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV5ChallengeExpire",fld:"vCHALLENGEEXPIRE",pic:"ZZZZZ9"},{av:"AV12Key",fld:"vKEY",pic:""},{ctrl:"BTNENTER",prop:"Visible"},{ctrl:"BTNGENKEY",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vCHALLENGEEXPIRE","Enabled")',ctrl:"vCHALLENGEEXPIRE",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vKEY","Enabled")',ctrl:"vKEY",prop:"Enabled"},{ctrl:"BTNENTER",prop:"Caption"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORD","Visible")',ctrl:"vUSERPASSWORD",prop:"Visible"},{av:'gx.fn.getCtrlProperty("USERPASSWORD_CELL","Class")',ctrl:"USERPASSWORD_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("DVPANEL_GAMCONNECTION_CELL","Class")',ctrl:"DVPANEL_GAMCONNECTION_CELL",prop:"Class"}]];this.EvtParms["'DOGENKEY'"]=[[],[{av:"AV12Key",fld:"vKEY",pic:""}]];this.EvtParms.ENTER=[[{av:"AV8ConnectionName",fld:"vCONNECTIONNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV14UserName",fld:"vUSERNAME",pic:""},{av:"AV15UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV5ChallengeExpire",fld:"vCHALLENGEEXPIRE",pic:"ZZZZZ9"},{av:"AV12Key",fld:"vKEY",pic:""},{av:"AV13pConnectionName",fld:"vPCONNECTIONNAME",pic:""}],[]];this.EnterCtrl=["BTNENTER"];this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.Initialize()});gx.wi(function(){gx.createParentObj(gamconnectionentry)})