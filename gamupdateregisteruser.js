gx.evt.autoSkip=!1;gx.define("gamupdateregisteruser",!1,function(){this.ServerClass="gamupdateregisteruser";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV18CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV19ApplicationClientId=gx.fn.getControlValue("vAPPLICATIONCLIENTID")};this.Validv_Birthday=function(){return this.validCliEvt("Validv_Birthday",0,function(){try{var n=gx.util.balloon.getNew("vBIRTHDAY");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV5Birthday)===0||new gx.date.gxdate(this.AV5Birthday).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Birthday fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gender=function(){return this.validCliEvt("Validv_Gender",0,function(){try{var n=gx.util.balloon.getNew("vGENDER");if(this.AnyError=0,!(gx.text.compare(this.AV10Gender,"N")==0||gx.text.compare(this.AV10Gender,"F")==0||gx.text.compare(this.AV10Gender,"M")==0))try{n.setError("Campo Gender fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e120a2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140a1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63];this.GXLastCtrlId=63;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLECONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"HEADERORIGINAL",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLELOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"SIGNIN",format:0,grid:0,ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"UNNAMEDTABLE1",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV14Name",gxold:"OV14Name",gxvar:"AV14Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV14Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"EMAIL_CELL",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",gxz:"ZV6EMail",gxold:"OV6EMail",gxvar:"AV6EMail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6EMail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6EMail=n)},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV6EMail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV6EMail=this.val())},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"FIRSTNAME_CELL",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTNAME",gxz:"ZV9FirstName",gxold:"OV9FirstName",gxvar:"AV9FirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9FirstName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9FirstName=n)},v2c:function(){gx.fn.setControlValue("vFIRSTNAME",gx.O.AV9FirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9FirstName=this.val())},val:function(){return gx.fn.getControlValue("vFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"LASTNAME_CELL",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLASTNAME",gxz:"ZV13LastName",gxold:"OV13LastName",gxvar:"AV13LastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13LastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13LastName=n)},v2c:function(){gx.fn.setControlValue("vLASTNAME",gx.O.AV13LastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13LastName=this.val())},val:function(){return gx.fn.getControlValue("vLASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(41,function(){});n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"BIRTHDAY_CELL",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Birthday,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBIRTHDAY",gxz:"ZV5Birthday",gxold:"OV5Birthday",gxvar:"AV5Birthday",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Birthday=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5Birthday=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vBIRTHDAY",gx.O.AV5Birthday,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Birthday=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vBIRTHDAY")},nac:gx.falseFn};this.declareDomainHdlr(46,function(){});n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"GENDER_CELL",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Gender,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENDER",gxz:"ZV10Gender",gxold:"OV10Gender",gxvar:"AV10Gender",ucs:[],op:[51],ip:[51],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV10Gender=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10Gender=n)},v2c:function(){gx.fn.setComboBoxValue("vGENDER",gx.O.AV10Gender)},c2v:function(){this.val()!==undefined&&(gx.O.AV10Gender=this.val())},val:function(){return gx.fn.getControlValue("vGENDER")},nac:gx.falseFn};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"BTNENTER",grid:0,evt:"e120a2_client",std:"ENTER"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"BTNCANCEL",grid:0,evt:"e140a1_client"};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"TABLEERROR",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};this.AV14Name="";this.ZV14Name="";this.OV14Name="";this.AV6EMail="";this.ZV6EMail="";this.OV6EMail="";this.AV9FirstName="";this.ZV9FirstName="";this.OV9FirstName="";this.AV13LastName="";this.ZV13LastName="";this.OV13LastName="";this.AV5Birthday=gx.date.nullDate();this.ZV5Birthday=gx.date.nullDate();this.OV5Birthday=gx.date.nullDate();this.AV10Gender="";this.ZV10Gender="";this.OV10Gender="";this.AV14Name="";this.AV6EMail="";this.AV9FirstName="";this.AV13LastName="";this.AV5Birthday=gx.date.nullDate();this.AV10Gender="";this.AV19ApplicationClientId="";this.AV18CheckRequiredFieldsResult=!1;this.Events={e120a2_client:["ENTER",!0],e140a1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV19ApplicationClientId",fld:"vAPPLICATIONCLIENTID",pic:"",hsh:!0}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Backcolor"},{av:'gx.fn.getCtrlProperty("LAYOUTMAINTABLE","Class")',ctrl:"LAYOUTMAINTABLE",prop:"Class"},{av:'gx.fn.getCtrlProperty("TABLEERROR","Visible")',ctrl:"TABLEERROR",prop:"Visible"},{av:"AV14Name",fld:"vNAME",pic:""},{av:"AV6EMail",fld:"vEMAIL",pic:""},{av:"AV9FirstName",fld:"vFIRSTNAME",pic:""},{av:"AV13LastName",fld:"vLASTNAME",pic:""},{av:"AV5Birthday",fld:"vBIRTHDAY",pic:""},{ctrl:"vGENDER"},{av:"AV10Gender",fld:"vGENDER",pic:""},{av:'gx.fn.getCtrlProperty("EMAIL_CELL","Class")',ctrl:"EMAIL_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("FIRSTNAME_CELL","Class")',ctrl:"FIRSTNAME_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("LASTNAME_CELL","Class")',ctrl:"LASTNAME_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("BIRTHDAY_CELL","Class")',ctrl:"BIRTHDAY_CELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("GENDER_CELL","Class")',ctrl:"GENDER_CELL",prop:"Class"}]];this.EvtParms.ENTER=[[{av:"AV18CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:"AV14Name",fld:"vNAME",pic:""},{av:"AV6EMail",fld:"vEMAIL",pic:""},{av:"AV9FirstName",fld:"vFIRSTNAME",pic:""},{av:"AV13LastName",fld:"vLASTNAME",pic:""},{av:"AV5Birthday",fld:"vBIRTHDAY",pic:""},{ctrl:"vGENDER"},{av:"AV10Gender",fld:"vGENDER",pic:""},{av:"AV19ApplicationClientId",fld:"vAPPLICATIONCLIENTID",pic:"",hsh:!0}],[{av:"AV18CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT",pic:""},{av:'gx.fn.getCtrlProperty("TABLEERROR","Visible")',ctrl:"TABLEERROR",prop:"Visible"}]];this.EvtParms.VALIDV_BIRTHDAY=[[],[]];this.EvtParms.VALIDV_GENDER=[[],[]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV18CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV19ApplicationClientId","vAPPLICATIONCLIENTID",0,"char",120,0);this.Initialize()});gx.wi(function(){gx.createParentObj(gamupdateregisteruser)})