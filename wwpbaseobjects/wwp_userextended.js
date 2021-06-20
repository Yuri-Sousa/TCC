gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.wwp_userextended', false, function () {
   this.ServerClass =  "wwpbaseobjects.wwp_userextended" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A40000WWPUserExtendedPhoto_GXI=gx.fn.getControlValue("WWPUSEREXTENDEDPHOTO_GXI") ;
   };
   this.Valid_Wwpuserextendedid=function()
   {
      return this.validSrvEvt("Valid_Wwpuserextendedid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e11011_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12011_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77];
   this.GXLastCtrlId =77;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"TABLEMAIN",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e13011_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e14011_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e15011_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e16011_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e17011_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"char",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpuserextendedid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDID",gxz:"Z1WWPUserExtendedId",gxold:"O1WWPUserExtendedId",gxvar:"A1WWPUserExtendedId",ucs:[],op:[38,48,43,68,63,58,53,33],ip:[38,48,43,68,63,58,53,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1WWPUserExtendedId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1WWPUserExtendedId=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDID",gx.O.A1WWPUserExtendedId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1WWPUserExtendedId=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDID")},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDPHOTO",gxz:"Z4WWPUserExtendedPhoto",gxold:"O4WWPUserExtendedPhoto",gxvar:"A4WWPUserExtendedPhoto",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A4WWPUserExtendedPhoto=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z4WWPUserExtendedPhoto=Value},v2c:function(){gx.fn.setMultimediaValue("WWPUSEREXTENDEDPHOTO",gx.O.A4WWPUserExtendedPhoto,gx.O.A40000WWPUserExtendedPhoto_GXI)},c2v:function(){gx.O.A40000WWPUserExtendedPhoto_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.A4WWPUserExtendedPhoto=this.val()},val:function(){return gx.fn.getBlobValue("WWPUSEREXTENDEDPHOTO")},val_GXI:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDPHOTO_GXI")}, gxvar_GXI:'A40000WWPUserExtendedPhoto_GXI',nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",gxz:"Z2WWPUserExtendedFullName",gxold:"O2WWPUserExtendedFullName",gxvar:"A2WWPUserExtendedFullName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2WWPUserExtendedFullName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2WWPUserExtendedFullName=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDFULLNAME",gx.O.A2WWPUserExtendedFullName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2WWPUserExtendedFullName=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDFULLNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 38 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"char",len:20,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDPHONE",gxz:"Z9WWPUserExtendedPhone",gxold:"O9WWPUserExtendedPhone",gxvar:"A9WWPUserExtendedPhone",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A9WWPUserExtendedPhone=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z9WWPUserExtendedPhone=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDPHONE",gx.O.A9WWPUserExtendedPhone,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A9WWPUserExtendedPhone=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDPHONE")},nac:gx.falseFn};
   this.declareDomainHdlr( 43 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDEMAIL",gxz:"Z3WWPUserExtendedEmail",gxold:"O3WWPUserExtendedEmail",gxvar:"A3WWPUserExtendedEmail",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A3WWPUserExtendedEmail=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z3WWPUserExtendedEmail=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDEMAIL",gx.O.A3WWPUserExtendedEmail,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A3WWPUserExtendedEmail=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDEMAIL")},nac:gx.falseFn};
   this.declareDomainHdlr( 48 , function() {
      gx.fn.setCtrlProperty("WWPUSEREXTENDEDEMAIL","Link", (!gx.fn.getCtrlProperty("WWPUSEREXTENDEDEMAIL","Enabled") ? "mailto:"+this.A3WWPUserExtendedEmail : "") );
   });
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"boolean",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDEMAINOTIF",gxz:"Z5WWPUserExtendedEmaiNotif",gxold:"O5WWPUserExtendedEmaiNotif",gxvar:"A5WWPUserExtendedEmaiNotif",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A5WWPUserExtendedEmaiNotif=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z5WWPUserExtendedEmaiNotif=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDEMAINOTIF",gx.O.A5WWPUserExtendedEmaiNotif,0)},c2v:function(){if(this.val()!==undefined)gx.O.A5WWPUserExtendedEmaiNotif=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDEMAINOTIF")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDSMSNOTIF",gxz:"Z6WWPUserExtendedSMSNotif",gxold:"O6WWPUserExtendedSMSNotif",gxvar:"A6WWPUserExtendedSMSNotif",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A6WWPUserExtendedSMSNotif=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z6WWPUserExtendedSMSNotif=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("WWPUSEREXTENDEDSMSNOTIF",gx.O.A6WWPUserExtendedSMSNotif,true)},c2v:function(){if(this.val()!==undefined)gx.O.A6WWPUserExtendedSMSNotif=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDSMSNOTIF")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDMOBILENOTIF",gxz:"Z7WWPUserExtendedMobileNotif",gxold:"O7WWPUserExtendedMobileNotif",gxvar:"A7WWPUserExtendedMobileNotif",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A7WWPUserExtendedMobileNotif=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z7WWPUserExtendedMobileNotif=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("WWPUSEREXTENDEDMOBILENOTIF",gx.O.A7WWPUserExtendedMobileNotif,true)},c2v:function(){if(this.val()!==undefined)gx.O.A7WWPUserExtendedMobileNotif=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDMOBILENOTIF")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"boolean",len:4,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDDESKTOPNOTIF",gxz:"Z8WWPUserExtendedDesktopNotif",gxold:"O8WWPUserExtendedDesktopNotif",gxvar:"A8WWPUserExtendedDesktopNotif",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"checkbox",v2v:function(Value){if(Value!==undefined)gx.O.A8WWPUserExtendedDesktopNotif=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z8WWPUserExtendedDesktopNotif=gx.lang.booleanValue(Value)},v2c:function(){gx.fn.setCheckBoxValue("WWPUSEREXTENDEDDESKTOPNOTIF",gx.O.A8WWPUserExtendedDesktopNotif,true)},c2v:function(){if(this.val()!==undefined)gx.O.A8WWPUserExtendedDesktopNotif=gx.lang.booleanValue(this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDDESKTOPNOTIF")},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id: 73, fld:"BTN_ENTER",grid:0,evt:"e11011_client",std:"ENTER"};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"BTN_CANCEL",grid:0,evt:"e12011_client"};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"BTN_DELETE",grid:0,evt:"e18011_client",std:"DELETE"};
   this.A1WWPUserExtendedId = "" ;
   this.Z1WWPUserExtendedId = "" ;
   this.O1WWPUserExtendedId = "" ;
   this.A40000WWPUserExtendedPhoto_GXI = "" ;
   this.A4WWPUserExtendedPhoto = "" ;
   this.Z4WWPUserExtendedPhoto = "" ;
   this.O4WWPUserExtendedPhoto = "" ;
   this.A2WWPUserExtendedFullName = "" ;
   this.Z2WWPUserExtendedFullName = "" ;
   this.O2WWPUserExtendedFullName = "" ;
   this.A9WWPUserExtendedPhone = "" ;
   this.Z9WWPUserExtendedPhone = "" ;
   this.O9WWPUserExtendedPhone = "" ;
   this.A3WWPUserExtendedEmail = "" ;
   this.Z3WWPUserExtendedEmail = "" ;
   this.O3WWPUserExtendedEmail = "" ;
   this.A5WWPUserExtendedEmaiNotif = false ;
   this.Z5WWPUserExtendedEmaiNotif = false ;
   this.O5WWPUserExtendedEmaiNotif = false ;
   this.A6WWPUserExtendedSMSNotif = false ;
   this.Z6WWPUserExtendedSMSNotif = false ;
   this.O6WWPUserExtendedSMSNotif = false ;
   this.A7WWPUserExtendedMobileNotif = false ;
   this.Z7WWPUserExtendedMobileNotif = false ;
   this.O7WWPUserExtendedMobileNotif = false ;
   this.A8WWPUserExtendedDesktopNotif = false ;
   this.Z8WWPUserExtendedDesktopNotif = false ;
   this.O8WWPUserExtendedDesktopNotif = false ;
   this.A40000WWPUserExtendedPhoto_GXI = "" ;
   this.A1WWPUserExtendedId = "" ;
   this.A2WWPUserExtendedFullName = "" ;
   this.A3WWPUserExtendedEmail = "" ;
   this.A9WWPUserExtendedPhone = "" ;
   this.A4WWPUserExtendedPhoto = "" ;
   this.A5WWPUserExtendedEmaiNotif = false ;
   this.A6WWPUserExtendedSMSNotif = false ;
   this.A7WWPUserExtendedMobileNotif = false ;
   this.A8WWPUserExtendedDesktopNotif = false ;
   this.Events = {"e11011_client": ["ENTER", true] ,"e12011_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}],[{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]];
   this.EvtParms["REFRESH"] = [[{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}],[{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]];
   this.EvtParms["VALID_WWPUSEREXTENDEDID"] = [[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}],[{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A5WWPUserExtendedEmaiNotif',fld:'WWPUSEREXTENDEDEMAINOTIF',pic:''},{av:'A9WWPUserExtendedPhone',fld:'WWPUSEREXTENDEDPHONE',pic:''},{av:'A3WWPUserExtendedEmail',fld:'WWPUSEREXTENDEDEMAIL',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1WWPUserExtendedId'},{av:'Z4WWPUserExtendedPhoto'},{av:'Z40000WWPUserExtendedPhoto_GXI'},{av:'Z5WWPUserExtendedEmaiNotif'},{av:'Z6WWPUserExtendedSMSNotif'},{av:'Z7WWPUserExtendedMobileNotif'},{av:'Z8WWPUserExtendedDesktopNotif'},{av:'Z9WWPUserExtendedPhone'},{av:'Z3WWPUserExtendedEmail'},{av:'Z2WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("A40000WWPUserExtendedPhoto_GXI", "WWPUSEREXTENDEDPHOTO_GXI", 0, "svchar", 2048, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.wwp_userextended);});
