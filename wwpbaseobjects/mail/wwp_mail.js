gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.mail.wwp_mail', false, function () {
   this.ServerClass =  "wwpbaseobjects.mail.wwp_mail" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.anyGridBaseTable = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",'.') ;
   };
   this.Valid_Wwpmailid=function()
   {
      return this.validSrvEvt("Valid_Wwpmailid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpmailstatus=function()
   {
      return this.validCliEvt("Valid_Wwpmailstatus", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPMAILSTATUS");
         this.AnyError  = 0;
         if ( ! ( ( this.A72WWPMailStatus == 1 ) || ( this.A72WWPMailStatus == 2 ) || ( this.A72WWPMailStatus == 3 ) ) )
         {
            try {
               gxballoon.setError("Campo Mail Status fora do intervalo");
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
   this.Valid_Wwpmailcreated=function()
   {
      return this.validCliEvt("Valid_Wwpmailcreated", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPMAILCREATED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A81WWPMailCreated)==0) || new gx.date.gxdate( this.A81WWPMailCreated ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Mail Created fora do intervalo");
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
   this.Valid_Wwpmailscheduled=function()
   {
      return this.validCliEvt("Valid_Wwpmailscheduled", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPMAILSCHEDULED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A82WWPMailScheduled)==0) || new gx.date.gxdate( this.A82WWPMailScheduled ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Mail Scheduled fora do intervalo");
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
   this.Valid_Wwpmailprocessed=function()
   {
      return this.validCliEvt("Valid_Wwpmailprocessed", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("WWPMAILPROCESSED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.A77WWPMailProcessed)===0) || new gx.date.gxdate( this.A77WWPMailProcessed ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Mail Processed fora do intervalo");
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
   this.Valid_Wwpnotificationid=function()
   {
      return this.validSrvEvt("Valid_Wwpnotificationid", 0).then((function (ret) {
      return ret;
      }).closure(this));
   }
   this.Valid_Wwpmailattachmentname=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(104);
      return this.validCliEvt("Valid_Wwpmailattachmentname", 104, function () {
      try {
         if(  gx.fn.currentGridRowImpl(104) ===0) {
            return true;
         }
         var gxballoon = gx.util.balloon.getNew("WWPMAILATTACHMENTNAME", gx.fn.currentGridRowImpl(104));
         this.AnyError  = 0;
         this.sMode11 =  this.Gx_mode  ;
         this.Gx_mode =  gx.fn.getGridRowMode(11,104)  ;
         this.standaloneModal0A11( );
         this.standaloneNotModal0A11( );
         if ( gx.fn.gridDuplicateKey(105) )
         {
            gxballoon.setError(gx.text.format( gx.getMessage( "GXM_1004"), "Attachments", "", "", "", "", "", "", "", ""));
            this.AnyError = gx.num.trunc( 1 ,0) ;
         }

      }
      catch(e){}
      try {
          this.Gx_mode =  this.sMode11  ;
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.standaloneModal0A11=function()
   {
      try {
         if ( gx.text.compare( this.Gx_mode , "INS" ) != 0 )
         {
            gx.fn.setCtrlProperty("WWPMAILATTACHMENTNAME","Enabled", 0 );
         }
         else
         {
            gx.fn.setCtrlProperty("WWPMAILATTACHMENTNAME","Enabled", 1 );
         }
      }
      catch(e){}
   }
   this.standaloneNotModal0A11=function()
   {
   }
   this.e110a10_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e120a10_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,105,106,107,108,109,110,111,112,113,114,115];
   this.GXLastCtrlId =115;
   this.Gridwwp_mail_attachmentsContainer = new gx.grid.grid(this, 11,"Attachments",104,"Gridwwp_mail_attachments","Gridwwp_mail_attachments","Gridwwp_mail_attachmentsContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.mail.wwp_mail",[21],false,1,false,true,5,false,false,false,"",0,"px",0,"px","Novo registro",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var Gridwwp_mail_attachmentsContainer = this.Gridwwp_mail_attachmentsContainer;
   Gridwwp_mail_attachmentsContainer.addSingleLineEdit(21,105,"WWPMAILATTACHMENTNAME","Attachment Name","","WWPMailAttachmentName","svchar",0,"px",40,40,"left",null,[],21,"WWPMailAttachmentName",true,0,false,false,"Attribute",1,"");
   Gridwwp_mail_attachmentsContainer.addSingleLineEdit(76,106,"WWPMAILATTACHMENTFILE","Attachment File","","WWPMailAttachmentFile","vchar",0,"px",2097152,80,"left",null,[],76,"WWPMailAttachmentFile",true,0,false,false,"Attribute",1,"");
   this.Gridwwp_mail_attachmentsContainer.emptyText = "";
   this.setGrid(Gridwwp_mail_attachmentsContainer);
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
   GXValidFnc[12]={ id: 12, fld:"BTN_FIRST",grid:0,evt:"e130a10_client",std:"FIRST"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"BTN_PREVIOUS",grid:0,evt:"e140a10_client",std:"PREVIOUS"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"BTN_NEXT",grid:0,evt:"e150a10_client",std:"NEXT"};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTN_LAST",grid:0,evt:"e160a10_client",std:"LAST"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTN_SELECT",grid:0,evt:"e170a10_client",std:"SELECT"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id:28 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridwwp_mail_attachmentsContainer],fld:"WWPMAILID",gxz:"Z20WWPMailId",gxold:"O20WWPMailId",gxvar:"A20WWPMailId",ucs:[],op:[93,88,83,78,73,68,63,58,53,48,43,38,33],ip:[93,88,83,78,73,68,63,58,53,48,43,38,33,28],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A20WWPMailId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z20WWPMailId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPMAILID",gx.O.A20WWPMailId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A20WWPMailId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPMAILID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 28 , function() {
   });
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id:33 ,lvl:0,type:"svchar",len:80,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSUBJECT",gxz:"Z61WWPMailSubject",gxold:"O61WWPMailSubject",gxvar:"A61WWPMailSubject",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A61WWPMailSubject=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z61WWPMailSubject=Value},v2c:function(){gx.fn.setControlValue("WWPMAILSUBJECT",gx.O.A61WWPMailSubject,0)},c2v:function(){if(this.val()!==undefined)gx.O.A61WWPMailSubject=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILSUBJECT")},nac:gx.falseFn};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id:38 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILBODY",gxz:"Z55WWPMailBody",gxold:"O55WWPMailBody",gxvar:"A55WWPMailBody",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A55WWPMailBody=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z55WWPMailBody=Value},v2c:function(){gx.fn.setControlValue("WWPMAILBODY",gx.O.A55WWPMailBody,1);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A55WWPMailBody=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILBODY")},nac:gx.falseFn};
   this.declareDomainHdlr( 38 , function() {
   });
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id:43 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILTO",gxz:"Z62WWPMailTo",gxold:"O62WWPMailTo",gxvar:"A62WWPMailTo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A62WWPMailTo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z62WWPMailTo=Value},v2c:function(){gx.fn.setControlValue("WWPMAILTO",gx.O.A62WWPMailTo,0)},c2v:function(){if(this.val()!==undefined)gx.O.A62WWPMailTo=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILTO")},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id:48 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILCC",gxz:"Z74WWPMailCC",gxold:"O74WWPMailCC",gxvar:"A74WWPMailCC",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A74WWPMailCC=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z74WWPMailCC=Value},v2c:function(){gx.fn.setControlValue("WWPMAILCC",gx.O.A74WWPMailCC,0)},c2v:function(){if(this.val()!==undefined)gx.O.A74WWPMailCC=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILCC")},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILBCC",gxz:"Z75WWPMailBCC",gxold:"O75WWPMailBCC",gxvar:"A75WWPMailBCC",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A75WWPMailBCC=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z75WWPMailBCC=Value},v2c:function(){gx.fn.setControlValue("WWPMAILBCC",gx.O.A75WWPMailBCC,0)},c2v:function(){if(this.val()!==undefined)gx.O.A75WWPMailBCC=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILBCC")},nac:gx.falseFn};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id:58 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSENDERADDRESS",gxz:"Z63WWPMailSenderAddress",gxold:"O63WWPMailSenderAddress",gxvar:"A63WWPMailSenderAddress",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A63WWPMailSenderAddress=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z63WWPMailSenderAddress=Value},v2c:function(){gx.fn.setControlValue("WWPMAILSENDERADDRESS",gx.O.A63WWPMailSenderAddress,0)},c2v:function(){if(this.val()!==undefined)gx.O.A63WWPMailSenderAddress=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILSENDERADDRESS")},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id:63 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSENDERNAME",gxz:"Z64WWPMailSenderName",gxold:"O64WWPMailSenderName",gxvar:"A64WWPMailSenderName",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A64WWPMailSenderName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z64WWPMailSenderName=Value},v2c:function(){gx.fn.setControlValue("WWPMAILSENDERNAME",gx.O.A64WWPMailSenderName,0)},c2v:function(){if(this.val()!==undefined)gx.O.A64WWPMailSenderName=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILSENDERNAME")},nac:gx.falseFn};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id:68 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailstatus,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSTATUS",gxz:"Z72WWPMailStatus",gxold:"O72WWPMailStatus",gxvar:"A72WWPMailStatus",ucs:[],op:[68],ip:[68],
						nacdep:[],ctrltype:"combo",v2v:function(Value){if(Value!==undefined)gx.O.A72WWPMailStatus=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z72WWPMailStatus=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("WWPMAILSTATUS",gx.O.A72WWPMailStatus);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A72WWPMailStatus=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPMAILSTATUS",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 68 , function() {
   });
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailcreated,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILCREATED",gxz:"Z81WWPMailCreated",gxold:"O81WWPMailCreated",gxvar:"A81WWPMailCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[73],ip:[73],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A81WWPMailCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z81WWPMailCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPMAILCREATED",gx.O.A81WWPMailCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A81WWPMailCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPMAILCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 73 , function() {
   });
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id:78 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailscheduled,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILSCHEDULED",gxz:"Z82WWPMailScheduled",gxold:"O82WWPMailScheduled",gxvar:"A82WWPMailScheduled",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[78],ip:[78],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A82WWPMailScheduled=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z82WWPMailScheduled=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPMAILSCHEDULED",gx.O.A82WWPMailScheduled,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A82WWPMailScheduled=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPMAILSCHEDULED")},nac:gx.falseFn};
   this.declareDomainHdlr( 78 , function() {
   });
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id:83 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpmailprocessed,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILPROCESSED",gxz:"Z77WWPMailProcessed",gxold:"O77WWPMailProcessed",gxvar:"A77WWPMailProcessed",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[83],ip:[83],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A77WWPMailProcessed=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z77WWPMailProcessed=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPMAILPROCESSED",gx.O.A77WWPMailProcessed,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A77WWPMailProcessed=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPMAILPROCESSED")},nac:gx.falseFn};
   this.declareDomainHdlr( 83 , function() {
   });
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id:88 ,lvl:0,type:"vchar",len:2097152,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILDETAIL",gxz:"Z78WWPMailDetail",gxold:"O78WWPMailDetail",gxvar:"A78WWPMailDetail",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A78WWPMailDetail=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z78WWPMailDetail=Value},v2c:function(){gx.fn.setControlValue("WWPMAILDETAIL",gx.O.A78WWPMailDetail,0)},c2v:function(){if(this.val()!==undefined)gx.O.A78WWPMailDetail=this.val()},val:function(){return gx.fn.getControlValue("WWPMAILDETAIL")},nac:gx.falseFn};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"",grid:0};
   GXValidFnc[93]={ id:93 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",gxz:"Z16WWPNotificationId",gxold:"O16WWPNotificationId",gxvar:"A16WWPNotificationId",ucs:[],op:[98],ip:[98,93],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z16WWPNotificationId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONID",gx.O.A16WWPNotificationId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 93 , function() {
   });
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id: 95, fld:"",grid:0};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id:98 ,lvl:0,type:"dtime",len:10,dec:12,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",gxz:"Z37WWPNotificationCreated",gxold:"O37WWPNotificationCreated",gxvar:"A37WWPNotificationCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z37WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONCREATED",gx.O.A37WWPNotificationCreated,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A37WWPNotificationCreated=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED")},nac:gx.falseFn};
   this.declareDomainHdlr( 98 , function() {
   });
   GXValidFnc[99]={ id: 99, fld:"",grid:0};
   GXValidFnc[100]={ id: 100, fld:"",grid:0};
   GXValidFnc[101]={ id: 101, fld:"TITLEATTACHMENTS", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[102]={ id: 102, fld:"",grid:0};
   GXValidFnc[103]={ id: 103, fld:"",grid:0};
   GXValidFnc[105]={ id:105 ,lvl:11,type:"svchar",len:40,dec:0,sign:false,ro:0,isacc:1,grid:104,gxgrid:this.Gridwwp_mail_attachmentsContainer,fnc:this.Valid_Wwpmailattachmentname,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILATTACHMENTNAME",gxz:"Z21WWPMailAttachmentName",gxold:"O21WWPMailAttachmentName",gxvar:"A21WWPMailAttachmentName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A21WWPMailAttachmentName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z21WWPMailAttachmentName=Value},v2c:function(row){gx.fn.setGridControlValue("WWPMAILATTACHMENTNAME",row || gx.fn.currentGridRowImpl(104),gx.O.A21WWPMailAttachmentName,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A21WWPMailAttachmentName=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPMAILATTACHMENTNAME",row || gx.fn.currentGridRowImpl(104))},nac:gx.falseFn};
   GXValidFnc[106]={ id:106 ,lvl:11,type:"vchar",len:2097152,dec:0,sign:false,ro:0,isacc:1,grid:104,gxgrid:this.Gridwwp_mail_attachmentsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPMAILATTACHMENTFILE",gxz:"Z76WWPMailAttachmentFile",gxold:"O76WWPMailAttachmentFile",gxvar:"A76WWPMailAttachmentFile",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A76WWPMailAttachmentFile=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z76WWPMailAttachmentFile=Value},v2c:function(row){gx.fn.setGridControlValue("WWPMAILATTACHMENTFILE",row || gx.fn.currentGridRowImpl(104),gx.O.A76WWPMailAttachmentFile,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A76WWPMailAttachmentFile=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPMAILATTACHMENTFILE",row || gx.fn.currentGridRowImpl(104))},nac:gx.falseFn};
   GXValidFnc[107]={ id: 107, fld:"",grid:0};
   GXValidFnc[108]={ id: 108, fld:"",grid:0};
   GXValidFnc[109]={ id: 109, fld:"",grid:0};
   GXValidFnc[110]={ id: 110, fld:"",grid:0};
   GXValidFnc[111]={ id: 111, fld:"BTN_ENTER",grid:0,evt:"e110a10_client",std:"ENTER"};
   GXValidFnc[112]={ id: 112, fld:"",grid:0};
   GXValidFnc[113]={ id: 113, fld:"BTN_CANCEL",grid:0,evt:"e120a10_client"};
   GXValidFnc[114]={ id: 114, fld:"",grid:0};
   GXValidFnc[115]={ id: 115, fld:"BTN_DELETE",grid:0,evt:"e180a10_client",std:"DELETE"};
   this.A20WWPMailId = 0 ;
   this.Z20WWPMailId = 0 ;
   this.O20WWPMailId = 0 ;
   this.A61WWPMailSubject = "" ;
   this.Z61WWPMailSubject = "" ;
   this.O61WWPMailSubject = "" ;
   this.A55WWPMailBody = "" ;
   this.Z55WWPMailBody = "" ;
   this.O55WWPMailBody = "" ;
   this.A62WWPMailTo = "" ;
   this.Z62WWPMailTo = "" ;
   this.O62WWPMailTo = "" ;
   this.A74WWPMailCC = "" ;
   this.Z74WWPMailCC = "" ;
   this.O74WWPMailCC = "" ;
   this.A75WWPMailBCC = "" ;
   this.Z75WWPMailBCC = "" ;
   this.O75WWPMailBCC = "" ;
   this.A63WWPMailSenderAddress = "" ;
   this.Z63WWPMailSenderAddress = "" ;
   this.O63WWPMailSenderAddress = "" ;
   this.A64WWPMailSenderName = "" ;
   this.Z64WWPMailSenderName = "" ;
   this.O64WWPMailSenderName = "" ;
   this.A72WWPMailStatus = 0 ;
   this.Z72WWPMailStatus = 0 ;
   this.O72WWPMailStatus = 0 ;
   this.A81WWPMailCreated = gx.date.nullDate() ;
   this.Z81WWPMailCreated = gx.date.nullDate() ;
   this.O81WWPMailCreated = gx.date.nullDate() ;
   this.A82WWPMailScheduled = gx.date.nullDate() ;
   this.Z82WWPMailScheduled = gx.date.nullDate() ;
   this.O82WWPMailScheduled = gx.date.nullDate() ;
   this.A77WWPMailProcessed = gx.date.nullDate() ;
   this.Z77WWPMailProcessed = gx.date.nullDate() ;
   this.O77WWPMailProcessed = gx.date.nullDate() ;
   this.A78WWPMailDetail = "" ;
   this.Z78WWPMailDetail = "" ;
   this.O78WWPMailDetail = "" ;
   this.A16WWPNotificationId = 0 ;
   this.Z16WWPNotificationId = 0 ;
   this.O16WWPNotificationId = 0 ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.Z37WWPNotificationCreated = gx.date.nullDate() ;
   this.O37WWPNotificationCreated = gx.date.nullDate() ;
   this.Z21WWPMailAttachmentName = "" ;
   this.O21WWPMailAttachmentName = "" ;
   this.Z76WWPMailAttachmentFile = "" ;
   this.O76WWPMailAttachmentFile = "" ;
   this.A21WWPMailAttachmentName = "" ;
   this.A76WWPMailAttachmentFile = "" ;
   this.A20WWPMailId = 0 ;
   this.Gx_BScreen = 0 ;
   this.A61WWPMailSubject = "" ;
   this.A55WWPMailBody = "" ;
   this.A62WWPMailTo = "" ;
   this.A74WWPMailCC = "" ;
   this.A75WWPMailBCC = "" ;
   this.A63WWPMailSenderAddress = "" ;
   this.A64WWPMailSenderName = "" ;
   this.A72WWPMailStatus = 0 ;
   this.A81WWPMailCreated = gx.date.nullDate() ;
   this.A82WWPMailScheduled = gx.date.nullDate() ;
   this.A77WWPMailProcessed = gx.date.nullDate() ;
   this.A78WWPMailDetail = "" ;
   this.A16WWPNotificationId = 0 ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.Events = {"e110a10_client": ["ENTER", true] ,"e120a10_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true}],[]];
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["VALID_WWPMAILID"] = [[{av:'A20WWPMailId',fld:'WWPMAILID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{ctrl:'WWPMAILSTATUS'},{av:'A72WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'},{av:'A81WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A82WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'}],[{av:'A61WWPMailSubject',fld:'WWPMAILSUBJECT',pic:''},{av:'A55WWPMailBody',fld:'WWPMAILBODY',pic:''},{av:'A62WWPMailTo',fld:'WWPMAILTO',pic:''},{av:'A74WWPMailCC',fld:'WWPMAILCC',pic:''},{av:'A75WWPMailBCC',fld:'WWPMAILBCC',pic:''},{av:'A63WWPMailSenderAddress',fld:'WWPMAILSENDERADDRESS',pic:''},{av:'A64WWPMailSenderName',fld:'WWPMAILSENDERNAME',pic:''},{ctrl:'WWPMAILSTATUS'},{av:'A72WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'},{av:'A81WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A82WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A77WWPMailProcessed',fld:'WWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A78WWPMailDetail',fld:'WWPMAILDETAIL',pic:''},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z20WWPMailId'},{av:'Z61WWPMailSubject'},{av:'Z55WWPMailBody'},{av:'Z62WWPMailTo'},{av:'Z74WWPMailCC'},{av:'Z75WWPMailBCC'},{av:'Z63WWPMailSenderAddress'},{av:'Z64WWPMailSenderName'},{av:'Z72WWPMailStatus'},{av:'Z81WWPMailCreated'},{av:'Z82WWPMailScheduled'},{av:'Z77WWPMailProcessed'},{av:'Z78WWPMailDetail'},{av:'Z16WWPNotificationId'},{av:'Z37WWPNotificationCreated'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]];
   this.EvtParms["VALID_WWPMAILSTATUS"] = [[{ctrl:'WWPMAILSTATUS'},{av:'A72WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'}],[{ctrl:'WWPMAILSTATUS'},{av:'A72WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'}]];
   this.EvtParms["VALID_WWPMAILCREATED"] = [[{av:'A81WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'}],[{av:'A81WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPMAILSCHEDULED"] = [[{av:'A82WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'}],[{av:'A82WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPMAILPROCESSED"] = [[{av:'A77WWPMailProcessed',fld:'WWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999'}],[{av:'A77WWPMailProcessed',fld:'WWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPNOTIFICATIONID"] = [[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}],[{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]];
   this.EvtParms["VALID_WWPMAILATTACHMENTNAME"] = [[],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("Gx_BScreen", "vGXBSCREEN", 0, "int", 1, 0);
   Gridwwp_mail_attachmentsContainer.addPostingVar({rfrVar:"Gx_mode"});
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.mail.wwp_mail);});
