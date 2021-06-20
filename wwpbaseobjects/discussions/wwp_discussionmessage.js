gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.discussions.wwp_discussionmessage', false, function () {
   this.ServerClass =  "wwpbaseobjects.discussions.wwp_discussionmessage" ;
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
   this.Valid_Wwpdiscussionmessageid=function()
   {
      return this.validSrvEvt("Valid_Wwpdiscussionmessageid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpdiscussionmessagedate=function()
   {
      return this.validCliEvt("Valid_Wwpdiscussionmessagedate", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPDISCUSSIONMESSAGEDATE");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A87WWPDiscussionMessageDate)==0) || new gx.date.gxdate( this.A87WWPDiscussionMessageDate ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Message Date fora do intervalo");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.Valid_Wwpdiscussionmessagethreadid=function()
   {
      return this.validSrvEvt("Valid_Wwpdiscussionmessagethreadid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpuserextendedid=function()
   {
      return this.validSrvEvt("Valid_Wwpuserextendedid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpentityid=function()
   {
      return this.validSrvEvt("Valid_Wwpentityid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.e110b12_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e120b12_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82];
   this.GXLastCtrlId =82;
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e130b12_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e140b12_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e150b12_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e160b12_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e170b12_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpdiscussionmessageid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEID",gxz:"Z83WWPDiscussionMessageId",gxold:"O83WWPDiscussionMessageId",gxvar:"A83WWPDiscussionMessageId",ucs:[],op:[38,63,48,73,43,33],ip:[38,63,48,73,43,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z83WWPDiscussionMessageId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEID",gx.O.A83WWPDiscussionMessageId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGEID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"dtime",len:8,dec:5,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpdiscussionmessagedate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEDATE",gxz:"Z87WWPDiscussionMessageDate",gxold:"O87WWPDiscussionMessageDate",gxvar:"A87WWPDiscussionMessageDate",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[33],ip:[33],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEDATE",gx.O.A87WWPDiscussionMessageDate,0)},c2v:function(){if(this.val()!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPDISCUSSIONMESSAGEDATE")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpdiscussionmessagethreadid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGETHREADID",gxz:"Z84WWPDiscussionMessageThreadId",gxold:"O84WWPDiscussionMessageThreadId",gxvar:"A84WWPDiscussionMessageThreadId",ucs:[],op:[],ip:[38],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A84WWPDiscussionMessageThreadId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z84WWPDiscussionMessageThreadId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGETHREADID",gx.O.A84WWPDiscussionMessageThreadId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A84WWPDiscussionMessageThreadId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGETHREADID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 38 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"svchar",len:400,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEMESSAGE",gxz:"Z88WWPDiscussionMessageMessage",gxold:"O88WWPDiscussionMessageMessage",gxvar:"A88WWPDiscussionMessageMessage",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A88WWPDiscussionMessageMessage=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z88WWPDiscussionMessageMessage=Value},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEMESSAGE",gx.O.A88WWPDiscussionMessageMessage,0)},c2v:function(){if(this.val()!==undefined)gx.O.A88WWPDiscussionMessageMessage=this.val()},val:function(){return gx.fn.getControlValue("WWPDISCUSSIONMESSAGEMESSAGE")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"char",len:40,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpuserextendedid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDID",gxz:"Z1WWPUserExtendedId",gxold:"O1WWPUserExtendedId",gxvar:"A1WWPUserExtendedId",ucs:[],op:[58,53],ip:[58,53,48],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1WWPUserExtendedId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z1WWPUserExtendedId=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDID",gx.O.A1WWPUserExtendedId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A1WWPUserExtendedId=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDID")},nac:gx.falseFn};
   this.declareDomainHdlr( 48 , function() {
   });
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDPHOTO",gxz:"Z4WWPUserExtendedPhoto",gxold:"O4WWPUserExtendedPhoto",gxvar:"A4WWPUserExtendedPhoto",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A4WWPUserExtendedPhoto=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z4WWPUserExtendedPhoto=Value},v2c:function(){gx.fn.setMultimediaValue("WWPUSEREXTENDEDPHOTO",gx.O.A4WWPUserExtendedPhoto,gx.O.A40000WWPUserExtendedPhoto_GXI)},c2v:function(){gx.O.A40000WWPUserExtendedPhoto_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.A4WWPUserExtendedPhoto=this.val()},val:function(){return gx.fn.getBlobValue("WWPUSEREXTENDEDPHOTO")},val_GXI:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDPHOTO_GXI")}, gxvar_GXI:'A40000WWPUserExtendedPhoto_GXI',nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",gxz:"Z2WWPUserExtendedFullName",gxold:"O2WWPUserExtendedFullName",gxvar:"A2WWPUserExtendedFullName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2WWPUserExtendedFullName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2WWPUserExtendedFullName=Value},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDFULLNAME",gx.O.A2WWPUserExtendedFullName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A2WWPUserExtendedFullName=this.val()},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDFULLNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 58 , function() {
   });
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpentityid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYID",gxz:"Z10WWPEntityId",gxold:"O10WWPEntityId",gxvar:"A10WWPEntityId",ucs:[],op:[68],ip:[68,63],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A10WWPEntityId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z10WWPEntityId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPENTITYID",gx.O.A10WWPEntityId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A10WWPEntityId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPENTITYID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 63 , function() {
   });
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYNAME",gxz:"Z12WWPEntityName",gxold:"O12WWPEntityName",gxvar:"A12WWPEntityName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A12WWPEntityName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z12WWPEntityName=Value},v2c:function(){gx.fn.setControlValue("WWPENTITYNAME",gx.O.A12WWPEntityName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A12WWPEntityName=this.val()},val:function(){return gx.fn.getControlValue("WWPENTITYNAME")},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEENTITYRECORDID",gxz:"Z89WWPDiscussionMessageEntityRecordId",gxold:"O89WWPDiscussionMessageEntityRecordId",gxvar:"A89WWPDiscussionMessageEntityRecordId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A89WWPDiscussionMessageEntityRecordId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z89WWPDiscussionMessageEntityRecordId=Value},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEENTITYRECORDID",gx.O.A89WWPDiscussionMessageEntityRecordId,0)},c2v:function(){if(this.val()!==undefined)gx.O.A89WWPDiscussionMessageEntityRecordId=this.val()},val:function(){return gx.fn.getControlValue("WWPDISCUSSIONMESSAGEENTITYRECORDID")},nac:gx.falseFn};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"BTN_ENTER",grid:0,evt:"e110b12_client",std:"ENTER"};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"BTN_CANCEL",grid:0,evt:"e120b12_client"};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"BTN_DELETE",grid:0,evt:"e180b12_client",std:"DELETE"};
   this.A83WWPDiscussionMessageId = 0 ;
   this.Z83WWPDiscussionMessageId = 0 ;
   this.O83WWPDiscussionMessageId = 0 ;
   this.A87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.Z87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.O87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.A84WWPDiscussionMessageThreadId = 0 ;
   this.Z84WWPDiscussionMessageThreadId = 0 ;
   this.O84WWPDiscussionMessageThreadId = 0 ;
   this.A88WWPDiscussionMessageMessage = "" ;
   this.Z88WWPDiscussionMessageMessage = "" ;
   this.O88WWPDiscussionMessageMessage = "" ;
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
   this.A10WWPEntityId = 0 ;
   this.Z10WWPEntityId = 0 ;
   this.O10WWPEntityId = 0 ;
   this.A12WWPEntityName = "" ;
   this.Z12WWPEntityName = "" ;
   this.O12WWPEntityName = "" ;
   this.A89WWPDiscussionMessageEntityRecordId = "" ;
   this.Z89WWPDiscussionMessageEntityRecordId = "" ;
   this.O89WWPDiscussionMessageEntityRecordId = "" ;
   this.A40000WWPUserExtendedPhoto_GXI = "" ;
   this.A83WWPDiscussionMessageId = 0 ;
   this.A87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.A1WWPUserExtendedId = "" ;
   this.A2WWPUserExtendedFullName = "" ;
   this.A84WWPDiscussionMessageThreadId = 0 ;
   this.A88WWPDiscussionMessageMessage = "" ;
   this.A4WWPUserExtendedPhoto = "" ;
   this.A10WWPEntityId = 0 ;
   this.A12WWPEntityName = "" ;
   this.A89WWPDiscussionMessageEntityRecordId = "" ;
   this.Events = {"e110b12_client": ["ENTER", true] ,"e120b12_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_WWPDISCUSSIONMESSAGEID"] = [[{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''}],[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A84WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'A88WWPDiscussionMessageMessage',fld:'WWPDISCUSSIONMESSAGEMESSAGE',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83WWPDiscussionMessageId'},{av:'Z87WWPDiscussionMessageDate'},{av:'Z1WWPUserExtendedId'},{av:'Z84WWPDiscussionMessageThreadId'},{av:'Z88WWPDiscussionMessageMessage'},{av:'Z10WWPEntityId'},{av:'Z89WWPDiscussionMessageEntityRecordId'},{av:'Z4WWPUserExtendedPhoto'},{av:'Z40000WWPUserExtendedPhoto_GXI'},{av:'Z2WWPUserExtendedFullName'},{av:'Z12WWPEntityName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_WWPDISCUSSIONMESSAGEDATE"] = [[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}],[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}]];
   this.EvtParms["VALID_WWPDISCUSSIONMESSAGETHREADID"] = [[{av:'A84WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["VALID_WWPUSEREXTENDEDID"] = [[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''}],[{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''}]];
   this.EvtParms["VALID_WWPENTITYID"] = [[{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''}],[{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''}]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("A40000WWPUserExtendedPhoto_GXI", "WWPUSEREXTENDEDPHOTO_GXI", 0, "svchar", 2048, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.discussions.wwp_discussionmessage);});
