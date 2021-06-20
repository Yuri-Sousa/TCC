gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.discussions.wwp_discussionmessagemention', false, function () {
   this.ServerClass =  "wwpbaseobjects.discussions.wwp_discussionmessagemention" ;
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
   this.Valid_Wwpdiscussionmessageid=function()
   {
      return this.validSrvEvt("Valid_Wwpdiscussionmessageid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpdiscussionmentionuserid=function()
   {
      return this.validSrvEvt("Valid_Wwpdiscussionmentionuserid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e110c13_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e120c13_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52];
   this.GXLastCtrlId =52;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e130c13_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e140c13_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e150c13_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e160c13_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e170c13_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpdiscussionmessageid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEID",gxz:"Z83WWPDiscussionMessageId",gxold:"O83WWPDiscussionMessageId",gxvar:"A83WWPDiscussionMessageId",ucs:[],op:[33],ip:[33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z83WWPDiscussionMessageId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEID",gx.O.A83WWPDiscussionMessageId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGEID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEDATE",gxz:"Z87WWPDiscussionMessageDate",gxold:"O87WWPDiscussionMessageDate",gxvar:"A87WWPDiscussionMessageDate",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEDATE",gx.O.A87WWPDiscussionMessageDate,0)},c2v:function(){if(this.val()!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPDISCUSSIONMESSAGEDATE")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"char",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpdiscussionmentionuserid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMENTIONUSERID",gxz:"Z85WWPDiscussionMentionUserId",gxold:"O85WWPDiscussionMentionUserId",gxvar:"A85WWPDiscussionMentionUserId",ucs:[],op:[43],ip:[43,38,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A85WWPDiscussionMentionUserId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z85WWPDiscussionMentionUserId=Value},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMENTIONUSERID",gx.O.A85WWPDiscussionMentionUserId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A85WWPDiscussionMentionUserId=this.val()},val:function(){return gx.fn.getControlValue("WWPDISCUSSIONMENTIONUSERID")},nac:gx.falseFn};
   this.declareDomainHdlr( 38 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMENTIONUSERNAME",gxz:"Z86WWPDiscussionMentionUserName",gxold:"O86WWPDiscussionMentionUserName",gxvar:"A86WWPDiscussionMentionUserName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A86WWPDiscussionMentionUserName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z86WWPDiscussionMentionUserName=Value},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMENTIONUSERNAME",gx.O.A86WWPDiscussionMentionUserName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A86WWPDiscussionMentionUserName=this.val()},val:function(){return gx.fn.getControlValue("WWPDISCUSSIONMENTIONUSERNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 43 , function() {
   });
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"BTN_ENTER",grid:0,evt:"e110c13_client",std:"ENTER"};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"BTN_CANCEL",grid:0,evt:"e120c13_client"};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"BTN_DELETE",grid:0,evt:"e180c13_client",std:"DELETE"};
   this.A83WWPDiscussionMessageId = 0 ;
   this.Z83WWPDiscussionMessageId = 0 ;
   this.O83WWPDiscussionMessageId = 0 ;
   this.A87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.Z87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.O87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.A85WWPDiscussionMentionUserId = "" ;
   this.Z85WWPDiscussionMentionUserId = "" ;
   this.O85WWPDiscussionMentionUserId = "" ;
   this.A86WWPDiscussionMentionUserName = "" ;
   this.Z86WWPDiscussionMentionUserName = "" ;
   this.O86WWPDiscussionMentionUserName = "" ;
   this.A83WWPDiscussionMessageId = 0 ;
   this.A85WWPDiscussionMentionUserId = "" ;
   this.A87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.A86WWPDiscussionMentionUserName = "" ;
   this.Events = {"e110c13_client": ["ENTER", true] ,"e120c13_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_WWPDISCUSSIONMESSAGEID"] = [[{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}],[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}]];
   this.EvtParms["VALID_WWPDISCUSSIONMENTIONUSERID"] = [[{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A85WWPDiscussionMentionUserId',fld:'WWPDISCUSSIONMENTIONUSERID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}],[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A86WWPDiscussionMentionUserName',fld:'WWPDISCUSSIONMENTIONUSERNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83WWPDiscussionMessageId'},{av:'Z85WWPDiscussionMentionUserId'},{av:'Z87WWPDiscussionMessageDate'},{av:'Z86WWPDiscussionMentionUserName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.discussions.wwp_discussionmessagemention);});
