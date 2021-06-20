gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.notifications.common.wwp_visualizeallnotifications', false, function () {
   this.ServerClass =  "wwpbaseobjects.notifications.common.wwp_visualizeallnotifications" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.anyGridBaseTable = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.A68WWPNotificationIcon=gx.fn.getControlValue("WWPNOTIFICATIONICON") ;
      this.A37WWPNotificationCreated=gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED") ;
      this.A73WWPNotificationIsRead=gx.fn.getControlValue("WWPNOTIFICATIONISREAD") ;
      this.AV15IsAuthorized_ManageSubscriptions=gx.fn.getControlValue("vISAUTHORIZED_MANAGESUBSCRIPTIONS") ;
      this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME") ;
   };
   this.Validv_Wwpnotificationcreated=function()
   {
      var currentRow = gx.fn.currentGridRowImpl(26);
      return this.validCliEvt("Validv_Wwpnotificationcreated", 26, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("vWWPNOTIFICATIONCREATED");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.AV18WWPNotificationCreated)===0) || new gx.date.gxdate( this.AV18WWPNotificationCreated ).compare( gx.date.ymdhmstot( 1753, 1, 1, 0, 0, 0) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo WWPNotification Created fora do intervalo");
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
   this.e17242_client=function()
   {
      this.clearMessages();
      this.call("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx", [this.A16WWPNotificationId], null, ["WWPNotificationId"]);
      this.refreshOutputs([{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e16242_client=function()
   {
      return this.executeServerEvent("'DOMARKASREAD'", true, arguments[0], false, false);
   };
   this.e11242_client=function()
   {
      return this.executeServerEvent("'DOMARKALLASREAD'", false, null, false, false);
   };
   this.e12242_client=function()
   {
      return this.executeServerEvent("'DOMANAGESUBSCRIPTIONS'", false, null, false, false);
   };
   this.e18242_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e19242_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,14,15,16,17,18,19,20,21,22,23,24,25,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,60,61,63,64,66,67];
   this.GXLastCtrlId =67;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",26,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.notifications.common.wwp_visualizeallnotifications",[],true,1,false,true,0,true,false,false,"",0,"px",0,"px","Novo registro",true,false,false,null,null,false,"",true,[1,1,1,1],true,1,false,false);
   var GridContainer = this.GridContainer;
   GridContainer.startDiv(27,"Unnamedtablefsgrid","0px","0px");
   GridContainer.startDiv(28,"","0px","0px");
   GridContainer.startDiv(29,"","0px","0px");
   GridContainer.startDiv(30,"Tablefscard","0px","0px");
   GridContainer.startDiv(31,"","0px","0px");
   GridContainer.startDiv(32,"","0px","0px");
   GridContainer.startDiv(33,"Unnamedtable1","0px","0px");
   GridContainer.startDiv(34,"","0px","0px");
   GridContainer.addTextBlock('NOTIFICATIONITEMICON',null,35);
   GridContainer.endDiv();
   GridContainer.startDiv(36,"","0px","0px");
   GridContainer.startDiv(37,"Tablecontent","0px","0px");
   GridContainer.startDiv(38,"","0px","0px");
   GridContainer.startDiv(39,"","0px","0px");
   GridContainer.startDiv(40,"Unnamedtable2","0px","0px");
   GridContainer.startDiv(41,"","0px","0px");
   GridContainer.startDiv(42,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addMultipleLineEdit(69,43,"WWPNOTIFICATIONTITLE","","WWPNotificationTitle","svchar",80,"chr",3,"row","200",200,"left",null,true,false,0,"");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(44,"","0px","0px");
   GridContainer.startDiv(45,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit("Wwpnotificationcreated",46,"vWWPNOTIFICATIONCREATED","","","WWPNotificationCreated","dtime",14,"chr",14,14,"right",null,[],"Wwpnotificationcreated","WWPNotificationCreated",true,5,false,false,"NotificationItemDatetime",1,"");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(47,"","0px","0px");
   GridContainer.addTextBlock('VISUALIZE',"e17242_client",48);
   GridContainer.endDiv();
   GridContainer.startDiv(49,"","0px","0px");
   GridContainer.addTextBlock('MARKASREAD',"e16242_client",50);
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(51,"","0px","0px");
   GridContainer.startDiv(52,"","0px","0px");
   GridContainer.startDiv(53,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addMultipleLineEdit(70,54,"WWPNOTIFICATIONSHORTDESCRIPTION","","WWPNotificationShortDescription","svchar",80,"chr",3,"row","200",200,"left",null,true,false,0,"");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(55,"","0px","0px");
   GridContainer.startDiv(56,"","0px","0px");
   GridContainer.startTable("Unnamedtablecontentfsgrid",57,"0px");
   GridContainer.startRow("","","","","","");
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(60,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(16,61,"WWPNOTIFICATIONID","","","WWPNotificationId","int",10,"chr",10,10,"right",null,[],16,"WWPNotificationId",true,0,false,false,"Attribute",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(63,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(71,64,"WWPNOTIFICATIONLINK","","","WWPNotificationLink","svchar",80,"chr",1000,80,"left",null,[],71,"WWPNotificationLink",true,0,false,false,"Attribute",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(66,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addMultipleLineEdit(54,67,"WWPNOTIFICATIONMETADATA","","WWPNotificationMetadata","vchar",80,"chr",10,"row","2097152",2097152,"left",null,true,false,0,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.endRow();
   GridContainer.endTable();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   this.DVPANEL_TABLEHEADERContainer = gx.uc.getNew(this, 12, 0, "BootstrapPanel", "DVPANEL_TABLEHEADERContainer", "Dvpanel_tableheader", "DVPANEL_TABLEHEADER");
   var DVPANEL_TABLEHEADERContainer = this.DVPANEL_TABLEHEADERContainer;
   DVPANEL_TABLEHEADERContainer.setProp("Class", "Class", "", "char");
   DVPANEL_TABLEHEADERContainer.setProp("Enabled", "Enabled", true, "boolean");
   DVPANEL_TABLEHEADERContainer.setProp("Width", "Width", "100%", "str");
   DVPANEL_TABLEHEADERContainer.setProp("Height", "Height", "100", "str");
   DVPANEL_TABLEHEADERContainer.setProp("AutoWidth", "Autowidth", false, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("AutoHeight", "Autoheight", true, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("Cls", "Cls", "PanelNoHeader", "str");
   DVPANEL_TABLEHEADERContainer.setProp("ShowHeader", "Showheader", true, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("Title", "Title", "Opções", "str");
   DVPANEL_TABLEHEADERContainer.setProp("Collapsible", "Collapsible", true, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("Collapsed", "Collapsed", false, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("ShowCollapseIcon", "Showcollapseicon", false, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("IconPosition", "Iconposition", "Right", "str");
   DVPANEL_TABLEHEADERContainer.setProp("AutoScroll", "Autoscroll", false, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("Visible", "Visible", true, "bool");
   DVPANEL_TABLEHEADERContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   DVPANEL_TABLEHEADERContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(DVPANEL_TABLEHEADERContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"TABLEHEADER",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"BTNMARKALLASREAD",grid:0,evt:"e11242_client"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"BTNMANAGESUBSCRIPTIONS",grid:0,evt:"e12242_client"};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"NONOTIFICATIONS", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"UNNAMEDTABLEFSGRID",grid:26};
   GXValidFnc[28]={ id: 28, fld:"",grid:26};
   GXValidFnc[29]={ id: 29, fld:"",grid:26};
   GXValidFnc[30]={ id: 30, fld:"TABLEFSCARD",grid:26};
   GXValidFnc[31]={ id: 31, fld:"",grid:26};
   GXValidFnc[32]={ id: 32, fld:"",grid:26};
   GXValidFnc[33]={ id: 33, fld:"UNNAMEDTABLE1",grid:26};
   GXValidFnc[34]={ id: 34, fld:"",grid:26};
   GXValidFnc[35]={ id: 35, fld:"NOTIFICATIONITEMICON", format:2,grid:26, ctrltype: "textblock"};
   GXValidFnc[36]={ id: 36, fld:"",grid:26};
   GXValidFnc[37]={ id: 37, fld:"TABLECONTENT",grid:26};
   GXValidFnc[38]={ id: 38, fld:"",grid:26};
   GXValidFnc[39]={ id: 39, fld:"",grid:26};
   GXValidFnc[40]={ id: 40, fld:"UNNAMEDTABLE2",grid:26};
   GXValidFnc[41]={ id: 41, fld:"",grid:26};
   GXValidFnc[42]={ id: 42, fld:"",grid:26};
   GXValidFnc[43]={ id:43 ,lvl:2,type:"svchar",len:200,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONTITLE",gxz:"Z69WWPNotificationTitle",gxold:"O69WWPNotificationTitle",gxvar:"A69WWPNotificationTitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A69WWPNotificationTitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z69WWPNotificationTitle=Value},v2c:function(row){gx.fn.setGridControlValue("WWPNOTIFICATIONTITLE",row || gx.fn.currentGridRowImpl(26),gx.O.A69WWPNotificationTitle,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A69WWPNotificationTitle=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPNOTIFICATIONTITLE",row || gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};
   GXValidFnc[44]={ id: 44, fld:"",grid:26};
   GXValidFnc[45]={ id: 45, fld:"",grid:26};
   GXValidFnc[46]={ id:46 ,lvl:2,type:"dtime",len:8,dec:5,sign:false,ro:0,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:this.Validv_Wwpnotificationcreated,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWWPNOTIFICATIONCREATED",gxz:"ZV18WWPNotificationCreated",gxold:"OV18WWPNotificationCreated",gxvar:"AV18WWPNotificationCreated",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV18WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV18WWPNotificationCreated=gx.fn.toDatetimeValue(Value)},v2c:function(row){gx.fn.setGridControlValue("vWWPNOTIFICATIONCREATED",row || gx.fn.currentGridRowImpl(26),gx.O.AV18WWPNotificationCreated,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV18WWPNotificationCreated=gx.fn.toDatetimeValue(this.val(row))},val:function(row){return gx.fn.getGridDateTimeValue("vWWPNOTIFICATIONCREATED",row || gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};
   GXValidFnc[47]={ id: 47, fld:"",grid:26};
   GXValidFnc[48]={ id: 48, fld:"VISUALIZE", format:1,grid:26,evt:"e17242_client", ctrltype: "textblock"};
   GXValidFnc[49]={ id: 49, fld:"",grid:26};
   GXValidFnc[50]={ id: 50, fld:"MARKASREAD", format:1,grid:26,evt:"e16242_client", ctrltype: "textblock"};
   GXValidFnc[51]={ id: 51, fld:"",grid:26};
   GXValidFnc[52]={ id: 52, fld:"",grid:26};
   GXValidFnc[53]={ id: 53, fld:"",grid:26};
   GXValidFnc[54]={ id:54 ,lvl:2,type:"svchar",len:200,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONSHORTDESCRIPTION",gxz:"Z70WWPNotificationShortDescription",gxold:"O70WWPNotificationShortDescription",gxvar:"A70WWPNotificationShortDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A70WWPNotificationShortDescription=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z70WWPNotificationShortDescription=Value},v2c:function(row){gx.fn.setGridControlValue("WWPNOTIFICATIONSHORTDESCRIPTION",row || gx.fn.currentGridRowImpl(26),gx.O.A70WWPNotificationShortDescription,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A70WWPNotificationShortDescription=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPNOTIFICATIONSHORTDESCRIPTION",row || gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};
   GXValidFnc[55]={ id: 55, fld:"",grid:26};
   GXValidFnc[56]={ id: 56, fld:"",grid:26};
   GXValidFnc[57]={ id: 57, fld:"UNNAMEDTABLECONTENTFSGRID",grid:26};
   GXValidFnc[60]={ id: 60, fld:"",grid:26};
   GXValidFnc[61]={ id:61 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",gxz:"Z16WWPNotificationId",gxold:"O16WWPNotificationId",gxvar:"A16WWPNotificationId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z16WWPNotificationId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("WWPNOTIFICATIONID",row || gx.fn.currentGridRowImpl(26),gx.O.A16WWPNotificationId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A16WWPNotificationId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("WWPNOTIFICATIONID",row || gx.fn.currentGridRowImpl(26),'.')},nac:gx.falseFn};
   GXValidFnc[63]={ id: 63, fld:"",grid:26};
   GXValidFnc[64]={ id:64 ,lvl:2,type:"svchar",len:1000,dec:0,sign:false,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONLINK",gxz:"Z71WWPNotificationLink",gxold:"O71WWPNotificationLink",gxvar:"A71WWPNotificationLink",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'url',v2v:function(Value){if(Value!==undefined)gx.O.A71WWPNotificationLink=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z71WWPNotificationLink=Value},v2c:function(row){gx.fn.setGridControlValue("WWPNOTIFICATIONLINK",row || gx.fn.currentGridRowImpl(26),gx.O.A71WWPNotificationLink,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A71WWPNotificationLink=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPNOTIFICATIONLINK",row || gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};
   GXValidFnc[66]={ id: 66, fld:"",grid:26};
   GXValidFnc[67]={ id:67 ,lvl:2,type:"vchar",len:2097152,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONMETADATA",gxz:"Z54WWPNotificationMetadata",gxold:"O54WWPNotificationMetadata",gxvar:"A54WWPNotificationMetadata",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A54WWPNotificationMetadata=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z54WWPNotificationMetadata=Value},v2c:function(row){gx.fn.setGridControlValue("WWPNOTIFICATIONMETADATA",row || gx.fn.currentGridRowImpl(26),gx.O.A54WWPNotificationMetadata,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A54WWPNotificationMetadata=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPNOTIFICATIONMETADATA",row || gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};
   this.Z69WWPNotificationTitle = "" ;
   this.O69WWPNotificationTitle = "" ;
   this.ZV18WWPNotificationCreated = gx.date.nullDate() ;
   this.OV18WWPNotificationCreated = gx.date.nullDate() ;
   this.Z70WWPNotificationShortDescription = "" ;
   this.O70WWPNotificationShortDescription = "" ;
   this.Z16WWPNotificationId = 0 ;
   this.O16WWPNotificationId = 0 ;
   this.Z71WWPNotificationLink = "" ;
   this.O71WWPNotificationLink = "" ;
   this.Z54WWPNotificationMetadata = "" ;
   this.O54WWPNotificationMetadata = "" ;
   this.A1WWPUserExtendedId = "" ;
   this.A68WWPNotificationIcon = "" ;
   this.A73WWPNotificationIsRead = false ;
   this.A37WWPNotificationCreated = gx.date.nullDate() ;
   this.A69WWPNotificationTitle = "" ;
   this.AV18WWPNotificationCreated = gx.date.nullDate() ;
   this.A70WWPNotificationShortDescription = "" ;
   this.A16WWPNotificationId = 0 ;
   this.A71WWPNotificationLink = "" ;
   this.A54WWPNotificationMetadata = "" ;
   this.AV22Pgmname = "" ;
   this.AV15IsAuthorized_ManageSubscriptions = false ;
   this.Events = {"e16242_client": ["'DOMARKASREAD'", true] ,"e11242_client": ["'DOMARKALLASREAD'", true] ,"e12242_client": ["'DOMANAGESUBSCRIPTIONS'", true] ,"e18242_client": ["ENTER", true] ,"e19242_client": ["CANCEL", true] ,"e17242_client": ["'DOVISUALIZE'", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["START"] = [[{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("TABLEMAIN","Width")',ctrl:'TABLEMAIN',prop:'Width'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{ctrl:'GRID',prop:'Rows'},{ctrl:'FORM',prop:'Caption'}]];
   this.EvtParms["GRID.LOAD"] = [[{av:'A71WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:''},{av:'A68WWPNotificationIcon',fld:'WWPNOTIFICATIONICON',pic:''},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("VISUALIZE","Visible")',ctrl:'VISUALIZE',prop:'Visible'},{av:'gx.fn.getCtrlProperty("NOTIFICATIONITEMICON","Caption")',ctrl:'NOTIFICATIONITEMICON',prop:'Caption'},{av:'AV18WWPNotificationCreated',fld:'vWWPNOTIFICATIONCREATED',pic:'99/99/99 99:99'},{av:'gx.fn.getCtrlProperty("MARKASREAD","Caption")',ctrl:'MARKASREAD',prop:'Caption'},{av:'gx.fn.getCtrlProperty("MARKASREAD","Tooltiptext")',ctrl:'MARKASREAD',prop:'Tooltiptext'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONTITLE","Class")',ctrl:'WWPNOTIFICATIONTITLE',prop:'Class'}]];
   this.EvtParms["'DOVISUALIZE'"] = [[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}],[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]];
   this.EvtParms["'DOMARKASREAD'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["'DOMARKALLASREAD'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["'DOMANAGESUBSCRIPTIONS'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONID","Visible")',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONLINK","Visible")',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPNOTIFICATIONMETADATA","Visible")',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("NONOTIFICATIONS","Visible")',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]];
   this.EvtParms["VALIDV_WWPNOTIFICATIONCREATED"] = [[{av:'AV18WWPNotificationCreated',fld:'vWWPNOTIFICATIONCREATED',pic:'99/99/99 99:99'}],[{av:'AV18WWPNotificationCreated',fld:'vWWPNOTIFICATIONCREATED',pic:'99/99/99 99:99'}]];
   this.setVCMap("AV22Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A68WWPNotificationIcon", "WWPNOTIFICATIONICON", 0, "svchar", 100, 0);
   this.setVCMap("A37WWPNotificationCreated", "WWPNOTIFICATIONCREATED", 0, "dtime", 10, 12);
   this.setVCMap("A73WWPNotificationIsRead", "WWPNOTIFICATIONISREAD", 0, "boolean", 4, 0);
   this.setVCMap("AV15IsAuthorized_ManageSubscriptions", "vISAUTHORIZED_MANAGESUBSCRIPTIONS", 0, "boolean", 4, 0);
   this.setVCMap("AV22Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV22Pgmname", "vPGMNAME", 0, "char", 129, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV22Pgmname"});
   GridContainer.addRefreshingVar({rfrVar:"A16WWPNotificationId", rfrProp:"Visible", gxAttId:"16"});
   GridContainer.addRefreshingVar({rfrVar:"A71WWPNotificationLink", rfrProp:"Visible", gxAttId:"71"});
   GridContainer.addRefreshingVar({rfrVar:"A54WWPNotificationMetadata", rfrProp:"Visible", gxAttId:"54"});
   GridContainer.addRefreshingVar({rfrVar:"AV15IsAuthorized_ManageSubscriptions"});
   GridContainer.addRefreshingParm({rfrVar:"AV22Pgmname"});
   GridContainer.addRefreshingParm({rfrVar:"A16WWPNotificationId", rfrProp:"Visible", gxAttId:"16"});
   GridContainer.addRefreshingParm({rfrVar:"A71WWPNotificationLink", rfrProp:"Visible", gxAttId:"71"});
   GridContainer.addRefreshingParm({rfrVar:"A54WWPNotificationMetadata", rfrProp:"Visible", gxAttId:"54"});
   GridContainer.addRefreshingParm({rfrVar:"AV15IsAuthorized_ManageSubscriptions"});
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.notifications.common.wwp_visualizeallnotifications);});
