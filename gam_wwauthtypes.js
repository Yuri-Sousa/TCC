gx.evt.autoSkip=!1;gx.define("gam_wwauthtypes",!1,function(){var n,t;this.ServerClass="gam_wwauthtypes";this.PackageName="GeneXus.Security.Backend";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Typeid=function(){var n=gx.fn.currentGridRowImpl(23);return this.validCliEvt("Validv_Typeid",23,function(){try{var n=gx.util.balloon.getNew("vTYPEID");if(this.AnyError=0,!(gx.text.compare(this.AV13TypeId,"AppleID")==0||gx.text.compare(this.AV13TypeId,"Custom")==0||gx.text.compare(this.AV13TypeId,"ExternalWebService")==0||gx.text.compare(this.AV13TypeId,"Facebook")==0||gx.text.compare(this.AV13TypeId,"GAMLocal")==0||gx.text.compare(this.AV13TypeId,"GAMRemote")==0||gx.text.compare(this.AV13TypeId,"GAMRemoteRest")==0||gx.text.compare(this.AV13TypeId,"Google")==0||gx.text.compare(this.AV13TypeId,"Twitter")==0||gx.text.compare(this.AV13TypeId,"Oauth20")==0||gx.text.compare(this.AV13TypeId,"Saml20")==0||gx.text.compare(this.AV13TypeId,"WeChat")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Type Id"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110e2_client=function(){return this.executeServerEvent("'ADDNEW'",!1,null,!1,!1)};this.e130e2_client=function(){return this.executeServerEvent("VNAME.CLICK",!0,arguments[0],!1,!1)};this.e140e2_client=function(){return this.executeServerEvent("VBTNUPD.CLICK",!0,arguments[0],!1,!1)};this.e150e2_client=function(){return this.executeServerEvent("VBTNTESTWS.CLICK",!0,arguments[0],!1,!1)};this.e160e2_client=function(){return this.executeServerEvent("VBTNDLT.CLICK",!0,arguments[0],!1,!1)};this.e170e2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e180e2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,21,22,24,25,26,27,28];this.GXLastCtrlId=28;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",23,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwauthtypes",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Name",24,"vNAME",gx.getMessage("Name"),"","Name","char",0,"px",60,60,"left","e130e2_client",[],"Name","Name",!0,0,!1,!1,"Attribute TextLikeLink SmallLink",1,"WWColumn");t.addComboBox("Typeid",25,"vTYPEID",gx.getMessage("Authentication  Types"),"TypeId","char",null,0,!0,!1,0,"px","WWColumn WWSecondaryColumn");t.addSingleLineEdit("Btnupd",26,"vBTNUPD","","","BtnUpd","char",0,"px",20,20,"left","e140e2_client",[],"Btnupd","BtnUpd",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btntestws",27,"vBTNTESTWS","","","BtnTestWS","char",0,"px",20,20,"left","e150e2_client",[],"Btntestws","BtnTestWS",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btndlt",28,"vBTNDLT","","","BtnDlt","char",0,"px",20,20,"left","e160e2_client",[],"Btndlt","BtnDlt",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");this.GridwwContainer.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE2",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"ADDNEW",grid:0,evt:"e110e2_client"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",gxz:"ZV10FilName",gxold:"OV10FilName",gxvar:"AV10FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV10FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TABLE1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV12Name",gxold:"OV12Name",gxvar:"AV12Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(23),gx.O.AV12Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn,evt:"e130e2_client"};n[25]={id:25,lvl:2,type:"char",len:30,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:this.Validv_Typeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTYPEID",gxz:"ZV13TypeId",gxold:"OV13TypeId",gxvar:"AV13TypeId",ucs:[],op:[25],ip:[25],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV13TypeId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13TypeId=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vTYPEID",n||gx.fn.currentGridRowImpl(23),gx.O.AV13TypeId);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13TypeId=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vTYPEID",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn};n[26]={id:26,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUPD",gxz:"ZV8BtnUpd",gxold:"OV8BtnUpd",gxvar:"AV8BtnUpd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV8BtnUpd=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8BtnUpd=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(23),gx.O.AV8BtnUpd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8BtnUpd=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn,evt:"e140e2_client"};n[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNTESTWS",gxz:"ZV7BtnTestWS",gxold:"OV7BtnTestWS",gxvar:"AV7BtnTestWS",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV7BtnTestWS=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7BtnTestWS=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNTESTWS",n||gx.fn.currentGridRowImpl(23),gx.O.AV7BtnTestWS,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV7BtnTestWS=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNTESTWS",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn,evt:"e150e2_client"};n[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNDLT",gxz:"ZV6BtnDlt",gxold:"OV6BtnDlt",gxvar:"AV6BtnDlt",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV6BtnDlt=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6BtnDlt=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(23),gx.O.AV6BtnDlt,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6BtnDlt=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn,evt:"e160e2_client"};this.AV10FilName="";this.ZV10FilName="";this.OV10FilName="";this.ZV12Name="";this.OV12Name="";this.ZV13TypeId="";this.OV13TypeId="";this.ZV8BtnUpd="";this.OV8BtnUpd="";this.ZV7BtnTestWS="";this.OV7BtnTestWS="";this.ZV6BtnDlt="";this.OV6BtnDlt="";this.AV10FilName="";this.AV12Name="";this.AV13TypeId="";this.AV8BtnUpd="";this.AV7BtnTestWS="";this.AV6BtnDlt="";this.Events={e110e2_client:["'ADDNEW'",!0],e130e2_client:["VNAME.CLICK",!0],e140e2_client:["VBTNUPD.CLICK",!0],e150e2_client:["VBTNTESTWS.CLICK",!0],e160e2_client:["VBTNDLT.CLICK",!0],e170e2_client:["ENTER",!0],e180e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV10FilName",fld:"vFILNAME",pic:""}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV10FilName",fld:"vFILNAME",pic:""}],[{av:"AV8BtnUpd",fld:"vBTNUPD",pic:""},{av:"AV6BtnDlt",fld:"vBTNDLT",pic:""},{av:"AV7BtnTestWS",fld:"vBTNTESTWS",pic:""},{av:"AV12Name",fld:"vNAME",pic:""},{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""},{av:'gx.fn.getCtrlProperty("vBTNTESTWS","Visible")',ctrl:"vBTNTESTWS",prop:"Visible"}]];this.EvtParms["'ADDNEW'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV10FilName",fld:"vFILNAME",pic:""}],[]];this.EvtParms["VNAME.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV12Name",fld:"vNAME",pic:""},{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""}],[{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""},{av:"AV12Name",fld:"vNAME",pic:""}]];this.EvtParms["VBTNUPD.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV12Name",fld:"vNAME",pic:""},{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""}],[{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""},{av:"AV12Name",fld:"vNAME",pic:""}]];this.EvtParms["VBTNTESTWS.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV12Name",fld:"vNAME",pic:""},{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""}],[{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""},{av:"AV12Name",fld:"vNAME",pic:""}]];this.EvtParms["VBTNDLT.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV10FilName",fld:"vFILNAME",pic:""},{av:"AV12Name",fld:"vNAME",pic:""},{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""}],[{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""},{av:"AV12Name",fld:"vNAME",pic:""}]];this.EvtParms.VALIDV_TYPEID=[[{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""}],[{ctrl:"vTYPEID"},{av:"AV13TypeId",fld:"vTYPEID",pic:""}]];t.addRefreshingVar(this.GXValidFnc[14]);t.addRefreshingParm(this.GXValidFnc[14]);this.Initialize()});gx.wi(function(){gx.createParentObj(gam_wwauthtypes)})