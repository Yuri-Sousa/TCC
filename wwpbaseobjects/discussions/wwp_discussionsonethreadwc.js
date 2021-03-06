gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.discussions.wwp_discussionsonethreadwc', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.discussions.wwp_discussionsonethreadwc" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.anyGridBaseTable = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A1WWPUserExtendedId=gx.fn.getControlValue("WWPUSEREXTENDEDID") ;
      this.AV35Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.A40000WWPUserExtendedPhoto_GXI=gx.fn.getControlValue("WWPUSEREXTENDEDPHOTO_GXI") ;
      this.AV15WWPDiscussionMessageThreadId=gx.fn.getIntegerValue("vWWPDISCUSSIONMESSAGETHREADID",'.') ;
      this.AV22WWPNotificationLink=gx.fn.getControlValue("vWWPNOTIFICATIONLINK") ;
      this.AV21WWPSubscriptionEntityRecordDescription=gx.fn.getControlValue("vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION") ;
      this.AV24NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO") ;
      this.AV15WWPDiscussionMessageThreadId=gx.fn.getIntegerValue("vWWPDISCUSSIONMESSAGETHREADID",'.') ;
      this.AV35Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.AV24NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO") ;
   };
   this.e11292_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e12292_client=function()
   {
      return this.executeServerEvent("ONMESSAGE_GX1", true, null, true, false);
   };
   this.e16292_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,18,19,20,21,22,23,24,25,26,27,30,31,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,50,51,52,53];
   this.GXLastCtrlId =53;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.discussions.wwp_discussionsonethreadwc",[],true,1,false,true,0,true,false,false,"",0,"px",0,"px","Novo registro",true,false,false,null,null,false,"",true,[1,1,1,1],false,0,false,false);
   var GridContainer = this.GridContainer;
   GridContainer.startDiv(13,"Unnamedtablefsgrid","0px","0px");
   GridContainer.startDiv(14,"","0px","0px");
   GridContainer.startTable("Unnamedtablecontentfsgrid",15,"0px");
   GridContainer.startRow("","","","","","");
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(18,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(83,19,"WWPDISCUSSIONMESSAGEID","","","WWPDiscussionMessageId","int",10,"chr",10,10,"right",null,[],83,"WWPDiscussionMessageId",true,0,false,false,"Attribute",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.endRow();
   GridContainer.endTable();
   GridContainer.endDiv();
   GridContainer.startDiv(20,"","0px","0px");
   GridContainer.startDiv(21,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addBitmap("&Userextendedphoto","vUSEREXTENDEDPHOTO",22,0,"",0,"",null,"","","AttributeDiscussionThreadImage","");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(23,"","0px","0px");
   GridContainer.startDiv(24,"Tabletitle","0px","0px");
   GridContainer.startDiv(25,"","0px","0px");
   GridContainer.startDiv(26,"","0px","0px");
   GridContainer.startTable("Tablemergedwwpuserextendedfullname",27,"0px");
   GridContainer.startRow("","","","","","");
   GridContainer.startCell("","","","","","","","","","MergeDataCell");
   GridContainer.startDiv(30,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(2,31,"WWPUSEREXTENDEDFULLNAME","","","WWPUserExtendedFullName","svchar",80,"chr",100,80,"left",null,[],2,"WWPUserExtendedFullName",true,0,false,false,"SimpleCardAttributeTitle",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(33,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(87,34,"WWPDISCUSSIONMESSAGEDATE","","","WWPDiscussionMessageDate","dtime",14,"chr",14,14,"right",null,[],87,"WWPDiscussionMessageDate",true,5,false,false,"AttributeDiscussionDate",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.endRow();
   GridContainer.endTable();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(35,"","0px","0px");
   GridContainer.startDiv(36,"","0px","0px");
   GridContainer.startDiv(37,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addMultipleLineEdit(88,38,"WWPDISCUSSIONMESSAGEMESSAGE","","WWPDiscussionMessageMessage","svchar",80,"chr",5,"row","400",400,"left",null,true,false,0,"");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   this.UCMENTIONSContainer = gx.uc.getNew(this, 49, 44, "WWP_Suggest_UC", this.CmpContext + "UCMENTIONSContainer", "Ucmentions", "UCMENTIONS");
   var UCMENTIONSContainer = this.UCMENTIONSContainer;
   UCMENTIONSContainer.setProp("Class", "Class", "", "char");
   UCMENTIONSContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCMENTIONSContainer.setProp("Cls", "Cls", "", "str");
   UCMENTIONSContainer.setDynProp("GAMOAuthToken", "Gamoauthtoken", "", "char");
   UCMENTIONSContainer.setProp("DataListProc", "Datalistproc", "WWPBaseObjects.Discussions.WWP_GetUsersForDiscussionMentions", "str");
   UCMENTIONSContainer.setDynProp("ItemHtmlTemplate", "Itemhtmltemplate", "", "str");
   UCMENTIONSContainer.setProp("SelectedItemsJson", "Selecteditemsjson", "", "char");
   UCMENTIONSContainer.setProp("Visible", "Visible", true, "bool");
   UCMENTIONSContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCMENTIONSContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCMENTIONSContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"UNNAMEDTABLEFSGRID",grid:12};
   GXValidFnc[14]={ id: 14, fld:"",grid:12};
   GXValidFnc[15]={ id: 15, fld:"UNNAMEDTABLECONTENTFSGRID",grid:12};
   GXValidFnc[18]={ id: 18, fld:"",grid:12};
   GXValidFnc[19]={ id:19 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEID",gxz:"Z83WWPDiscussionMessageId",gxold:"O83WWPDiscussionMessageId",gxvar:"A83WWPDiscussionMessageId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z83WWPDiscussionMessageId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("WWPDISCUSSIONMESSAGEID",row || gx.fn.currentGridRowImpl(12),gx.O.A83WWPDiscussionMessageId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("WWPDISCUSSIONMESSAGEID",row || gx.fn.currentGridRowImpl(12),'.')},nac:gx.falseFn};
   GXValidFnc[20]={ id: 20, fld:"",grid:12};
   GXValidFnc[21]={ id: 21, fld:"",grid:12};
   GXValidFnc[22]={ id:22 ,lvl:2,type:"bits",len:1024,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSEREXTENDEDPHOTO",gxz:"ZV13UserExtendedPhoto",gxold:"OV13UserExtendedPhoto",gxvar:"AV13UserExtendedPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV13UserExtendedPhoto=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV13UserExtendedPhoto=Value},v2c:function(row){gx.fn.setGridMultimediaValue("vUSEREXTENDEDPHOTO",row || gx.fn.currentGridRowImpl(12),gx.O.AV13UserExtendedPhoto,gx.O.AV34Userextendedphoto_GXI)},c2v:function(row){gx.O.AV34Userextendedphoto_GXI=this.val_GXI();if(this.val(row)!==undefined)gx.O.AV13UserExtendedPhoto=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vUSEREXTENDEDPHOTO",row || gx.fn.currentGridRowImpl(12))},val_GXI:function(row){return gx.fn.getGridControlValue("vUSEREXTENDEDPHOTO_GXI",row || gx.fn.currentGridRowImpl(12))}, gxvar_GXI:'AV34Userextendedphoto_GXI',nac:gx.falseFn};
   GXValidFnc[23]={ id: 23, fld:"",grid:12};
   GXValidFnc[24]={ id: 24, fld:"TABLETITLE",grid:12};
   GXValidFnc[25]={ id: 25, fld:"",grid:12};
   GXValidFnc[26]={ id: 26, fld:"",grid:12};
   GXValidFnc[27]={ id: 27, fld:"TABLEMERGEDWWPUSEREXTENDEDFULLNAME",grid:12};
   GXValidFnc[30]={ id: 30, fld:"",grid:12};
   GXValidFnc[31]={ id:31 ,lvl:2,type:"svchar",len:100,dec:0,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",gxz:"Z2WWPUserExtendedFullName",gxold:"O2WWPUserExtendedFullName",gxvar:"A2WWPUserExtendedFullName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A2WWPUserExtendedFullName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2WWPUserExtendedFullName=Value},v2c:function(row){gx.fn.setGridControlValue("WWPUSEREXTENDEDFULLNAME",row || gx.fn.currentGridRowImpl(12),gx.O.A2WWPUserExtendedFullName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A2WWPUserExtendedFullName=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPUSEREXTENDEDFULLNAME",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[33]={ id: 33, fld:"",grid:12};
   GXValidFnc[34]={ id:34 ,lvl:2,type:"dtime",len:8,dec:5,sign:false,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEDATE",gxz:"Z87WWPDiscussionMessageDate",gxold:"O87WWPDiscussionMessageDate",gxvar:"A87WWPDiscussionMessageDate",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2c:function(row){gx.fn.setGridControlValue("WWPDISCUSSIONMESSAGEDATE",row || gx.fn.currentGridRowImpl(12),gx.O.A87WWPDiscussionMessageDate,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(this.val(row))},val:function(row){return gx.fn.getGridDateTimeValue("WWPDISCUSSIONMESSAGEDATE",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[35]={ id: 35, fld:"",grid:12};
   GXValidFnc[36]={ id: 36, fld:"",grid:12};
   GXValidFnc[37]={ id: 37, fld:"",grid:12};
   GXValidFnc[38]={ id:38 ,lvl:2,type:"svchar",len:400,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEMESSAGE",gxz:"Z88WWPDiscussionMessageMessage",gxold:"O88WWPDiscussionMessageMessage",gxvar:"A88WWPDiscussionMessageMessage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A88WWPDiscussionMessageMessage=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z88WWPDiscussionMessageMessage=Value},v2c:function(row){gx.fn.setGridControlValue("WWPDISCUSSIONMESSAGEMESSAGE",row || gx.fn.currentGridRowImpl(12),gx.O.A88WWPDiscussionMessageMessage,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A88WWPDiscussionMessageMessage=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPDISCUSSIONMESSAGEMESSAGE",row || gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"UNNAMEDTABLE1",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id:44 ,lvl:0,type:"svchar",len:400,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMESSAGE",gxz:"ZV16Message",gxold:"OV16Message",gxvar:"AV16Message",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV16Message=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV16Message=Value},v2c:function(){gx.fn.setControlValue("vMESSAGE",gx.O.AV16Message,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV16Message=this.val()},val:function(){return gx.fn.getControlValue("vMESSAGE")},nac:gx.falseFn};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"ENTER", format:1,grid:0,evt:"e11292_client",std:"ENTER", ctrltype: "textblock"};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};
   GXValidFnc[53]={ id:53 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGETHREADID",gxz:"Z84WWPDiscussionMessageThreadId",gxold:"O84WWPDiscussionMessageThreadId",gxvar:"A84WWPDiscussionMessageThreadId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A84WWPDiscussionMessageThreadId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z84WWPDiscussionMessageThreadId=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGETHREADID",gx.O.A84WWPDiscussionMessageThreadId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(){if(this.val()!==undefined)gx.O.A84WWPDiscussionMessageThreadId=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGETHREADID",'.')},nac:gx.falseFn};
   this.declareDomainHdlr( 53 , function() {
   });
   this.Z83WWPDiscussionMessageId = 0 ;
   this.O83WWPDiscussionMessageId = 0 ;
   this.ZV13UserExtendedPhoto = "" ;
   this.OV13UserExtendedPhoto = "" ;
   this.Z2WWPUserExtendedFullName = "" ;
   this.O2WWPUserExtendedFullName = "" ;
   this.Z87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.O87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.Z88WWPDiscussionMessageMessage = "" ;
   this.O88WWPDiscussionMessageMessage = "" ;
   this.AV16Message = "" ;
   this.ZV16Message = "" ;
   this.OV16Message = "" ;
   this.A84WWPDiscussionMessageThreadId = 0 ;
   this.Z84WWPDiscussionMessageThreadId = 0 ;
   this.O84WWPDiscussionMessageThreadId = 0 ;
   this.AV16Message = "" ;
   this.A84WWPDiscussionMessageThreadId = 0 ;
   this.A40000WWPUserExtendedPhoto_GXI = "" ;
   this.AV15WWPDiscussionMessageThreadId = 0 ;
   this.AV21WWPSubscriptionEntityRecordDescription = "" ;
   this.AV22WWPNotificationLink = "" ;
   this.A1WWPUserExtendedId = "" ;
   this.A83WWPDiscussionMessageId = 0 ;
   this.AV13UserExtendedPhoto = "" ;
   this.A2WWPUserExtendedFullName = "" ;
   this.A87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.A88WWPDiscussionMessageMessage = "" ;
   this.AV35Pgmname = "" ;
   this.AV24NotificationInfo = {Id:"",Object:"",Message:""} ;
   this.addOnMessage('', "e12292_client", [["GeneXus\Server\NotificationInfo","vNOTIFICATIONINFO","AV24NotificationInfo"]], this.e12292_client);
   this.Events = {"e11292_client": ["ENTER", true] ,"e12292_client": ["ONMESSAGE_GX1", true] ,"e16292_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{ctrl:'GRID',prop:'Rows'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[]];
   this.EvtParms["START"] = [[{av:'AV16Message',fld:'vMESSAGE',pic:''},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'}],[{av:'this.UCMENTIONSContainer.GAMOAuthToken',ctrl:'UCMENTIONS',prop:'GAMOAuthToken'},{av:'this.UCMENTIONSContainer.ItemHtmlTemplate',ctrl:'UCMENTIONS',prop:'ItemHtmlTemplate'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGETHREADID","Visible")',ctrl:'WWPDISCUSSIONMESSAGETHREADID',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'}]];
   this.EvtParms["GRID.LOAD"] = [[{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''}],[{av:'gx.fn.getCtrlProperty("GRID","Visible")',ctrl:'GRID',prop:'Visible'},{av:'AV13UserExtendedPhoto',fld:'vUSEREXTENDEDPHOTO',pic:''}]];
   this.EvtParms["ENTER"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV22WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV21WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'this.UCMENTIONSContainer.SelectedItemsJson',ctrl:'UCMENTIONS',prop:'SelectedItemsJson'},{av:'AV16Message',fld:'vMESSAGE',pic:''}],[{av:'AV16Message',fld:'vMESSAGE',pic:''}]];
   this.EvtParms["ONMESSAGE_GX1"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV24NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''}],[]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{ctrl:'GRID',prop:'Rows'}],[]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{ctrl:'GRID',prop:'Rows'}],[]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{ctrl:'GRID',prop:'Rows'}],[]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{ctrl:'GRID',prop:'Rows'}],[]];
   this.EnterCtrl = ["ENTER"];
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("AV35Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("A40000WWPUserExtendedPhoto_GXI", "WWPUSEREXTENDEDPHOTO_GXI", 0, "svchar", 2048, 0);
   this.setVCMap("AV15WWPDiscussionMessageThreadId", "vWWPDISCUSSIONMESSAGETHREADID", 0, "int", 10, 0);
   this.setVCMap("AV22WWPNotificationLink", "vWWPNOTIFICATIONLINK", 0, "svchar", 1000, 0);
   this.setVCMap("AV21WWPSubscriptionEntityRecordDescription", "vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION", 0, "svchar", 200, 0);
   this.setVCMap("AV24NotificationInfo", "vNOTIFICATIONINFO", 0, "GeneXus\Server\NotificationInfo", 0, 0);
   this.setVCMap("AV15WWPDiscussionMessageThreadId", "vWWPDISCUSSIONMESSAGETHREADID", 0, "int", 10, 0);
   this.setVCMap("AV35Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV24NotificationInfo", "vNOTIFICATIONINFO", 0, "GeneXus\Server\NotificationInfo", 0, 0);
   this.setVCMap("AV15WWPDiscussionMessageThreadId", "vWWPDISCUSSIONMESSAGETHREADID", 0, "int", 10, 0);
   this.setVCMap("AV35Pgmname", "vPGMNAME", 0, "char", 129, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV15WWPDiscussionMessageThreadId"});
   GridContainer.addRefreshingVar({rfrVar:"AV35Pgmname"});
   GridContainer.addRefreshingVar({rfrVar:"A83WWPDiscussionMessageId", rfrProp:"Visible", gxAttId:"83"});
   GridContainer.addRefreshingParm({rfrVar:"AV15WWPDiscussionMessageThreadId"});
   GridContainer.addRefreshingParm({rfrVar:"AV35Pgmname"});
   GridContainer.addRefreshingParm({rfrVar:"A83WWPDiscussionMessageId", rfrProp:"Visible", gxAttId:"83"});
   this.Initialize( );
   this.setSDTMapping( "WWPBaseObjects\\WWPGridState" , {
      "FilterValues":{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},
      "DynamicFilters":{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});
   this.setSDTMapping( "WWPBaseObjects\\WWPGridState.DynamicFilter" , {
      "Dsc":{extr:"d"}});
   this.setSDTMapping( "WWPBaseObjects\\WWPTransactionContext" , {
      "Attributes":{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});
   this.setSDTMapping( "GeneXusSecurity\\GAMSession" , {
      "User":{sdt:"GeneXusSecurity\\GAMUser"}});
});
