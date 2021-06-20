gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.mail.wwp_mailtemplate', false, function () {
   this.ServerClass =  "wwpbaseobjects.mail.wwp_mailtemplate" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Valid_Wwpmailtemplatename=function()
   {
      return this.validSrvEvt("Valid_Wwpmailtemplatename", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e12092_client=function()
   {
      return this.executeServerEvent("AFTER TRN", true, null, false, false);
   };
   this.e13099_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e14099_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62];
   this.GXLastCtrlId =62;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e15099_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e16099_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e17099_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e18099_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e19099_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"svchar",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailtemplatename,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTEMPLATENAME",gxz:"Z19WWPMailTemplateName",gxold:"O19WWPMailTemplateName",gxvar:"A19WWPMailTemplateName",ucs:[],op:[53,48,43,38,33],ip:[53,48,43,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A19WWPMailTemplateName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z19WWPMailTemplateName=Value},v2c:function(){gx.fn.setControlValue("WWPMAILTEMPLATENAME",gx.O.A19WWPMailTemplateName,0)},c2v:function(){if(this.val()!==undefined)gx.O.A19WWPMailTemplateName=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILTEMPLATENAME")},nac:gx.falseFn};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTEMPLATEDESCRIPTION",gxz:"Z79WWPMailTemplateDescription",gxold:"O79WWPMailTemplateDescription",gxvar:"A79WWPMailTemplateDescription",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A79WWPMailTemplateDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z79WWPMailTemplateDescription=Value},v2c:function(){gx.fn.setControlValue("WWPMAILTEMPLATEDESCRIPTION",gx.O.A79WWPMailTemplateDescription,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A79WWPMailTemplateDescription=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILTEMPLATEDESCRIPTION")},nac:gx.falseFn};
   this.declareDomainHdlr( 33 , function() {
   });
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"svchar",len:80,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTEMPLATESUBJECT",gxz:"Z80WWPMailTemplateSubject",gxold:"O80WWPMailTemplateSubject",gxvar:"A80WWPMailTemplateSubject",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A80WWPMailTemplateSubject=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z80WWPMailTemplateSubject=Value},v2c:function(){gx.fn.setControlValue("WWPMAILTEMPLATESUBJECT",gx.O.A80WWPMailTemplateSubject,0)},c2v:function(){if(this.val()!==undefined)gx.O.A80WWPMailTemplateSubject=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILTEMPLATESUBJECT")},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTEMPLATEBODY",gxz:"Z65WWPMailTemplateBody",gxold:"O65WWPMailTemplateBody",gxvar:"A65WWPMailTemplateBody",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A65WWPMailTemplateBody=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z65WWPMailTemplateBody=Value},v2c:function(){gx.fn.setControlValue("WWPMAILTEMPLATEBODY",gx.O.A65WWPMailTemplateBody,1);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A65WWPMailTemplateBody=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILTEMPLATEBODY")},nac:gx.falseFn};
   this.declareDomainHdlr( 43 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTEMPLATESENDERADDRESS",gxz:"Z66WWPMailTemplateSenderAddress",gxold:"O66WWPMailTemplateSenderAddress",gxvar:"A66WWPMailTemplateSenderAddress",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A66WWPMailTemplateSenderAddress=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z66WWPMailTemplateSenderAddress=Value},v2c:function(){gx.fn.setControlValue("WWPMAILTEMPLATESENDERADDRESS",gx.O.A66WWPMailTemplateSenderAddress,0)},c2v:function(){if(this.val()!==undefined)gx.O.A66WWPMailTemplateSenderAddress=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILTEMPLATESENDERADDRESS")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTEMPLATESENDERNAME",gxz:"Z67WWPMailTemplateSenderName",gxold:"O67WWPMailTemplateSenderName",gxvar:"A67WWPMailTemplateSenderName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A67WWPMailTemplateSenderName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z67WWPMailTemplateSenderName=Value},v2c:function(){gx.fn.setControlValue("WWPMAILTEMPLATESENDERNAME",gx.O.A67WWPMailTemplateSenderName,0)},c2v:function(){if(this.val()!==undefined)gx.O.A67WWPMailTemplateSenderName=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILTEMPLATESENDERNAME")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"BTN_ENTER",grid:0,evt:"e13099_client",std:"ENTER"};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"BTN_CANCEL",grid:0,evt:"e14099_client"};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"BTN_DELETE",grid:0,evt:"e20099_client",std:"DELETE"};
   this.A19WWPMailTemplateName = "" ;
   this.Z19WWPMailTemplateName = "" ;
   this.O19WWPMailTemplateName = "" ;
   this.A79WWPMailTemplateDescription = "" ;
   this.Z79WWPMailTemplateDescription = "" ;
   this.O79WWPMailTemplateDescription = "" ;
   this.A80WWPMailTemplateSubject = "" ;
   this.Z80WWPMailTemplateSubject = "" ;
   this.O80WWPMailTemplateSubject = "" ;
   this.A65WWPMailTemplateBody = "" ;
   this.Z65WWPMailTemplateBody = "" ;
   this.O65WWPMailTemplateBody = "" ;
   this.A66WWPMailTemplateSenderAddress = "" ;
   this.Z66WWPMailTemplateSenderAddress = "" ;
   this.O66WWPMailTemplateSenderAddress = "" ;
   this.A67WWPMailTemplateSenderName = "" ;
   this.Z67WWPMailTemplateSenderName = "" ;
   this.O67WWPMailTemplateSenderName = "" ;
   this.A19WWPMailTemplateName = "" ;
   this.A79WWPMailTemplateDescription = "" ;
   this.A80WWPMailTemplateSubject = "" ;
   this.A65WWPMailTemplateBody = "" ;
   this.A66WWPMailTemplateSenderAddress = "" ;
   this.A67WWPMailTemplateSenderName = "" ;
   this.Events = {"e12092_client": ["AFTER TRN", true] ,"e13099_client": ["ENTER", true] ,"e14099_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[],[]];
   this.EvtParms["AFTER TRN"] = [[],[]];
   this.EvtParms["VALID_WWPMAILTEMPLATENAME"] = [[{av:'A19WWPMailTemplateName',fld:'WWPMAILTEMPLATENAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A79WWPMailTemplateDescription',fld:'WWPMAILTEMPLATEDESCRIPTION',pic:''},{av:'A80WWPMailTemplateSubject',fld:'WWPMAILTEMPLATESUBJECT',pic:''},{av:'A65WWPMailTemplateBody',fld:'WWPMAILTEMPLATEBODY',pic:''},{av:'A66WWPMailTemplateSenderAddress',fld:'WWPMAILTEMPLATESENDERADDRESS',pic:''},{av:'A67WWPMailTemplateSenderName',fld:'WWPMAILTEMPLATESENDERNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z19WWPMailTemplateName'},{av:'Z79WWPMailTemplateDescription'},{av:'Z80WWPMailTemplateSubject'},{av:'Z65WWPMailTemplateBody'},{av:'Z66WWPMailTemplateSenderAddress'},{av:'Z67WWPMailTemplateSenderName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.mail.wwp_mailtemplate);});
