gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.discussions.wwp_discussionswc', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.discussions.wwp_discussionswc" ;
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
      this.A10WWPEntityId=gx.fn.getIntegerValue("WWPENTITYID",'.') ;
      this.AV8WWPEntityId=gx.fn.getIntegerValue("vWWPENTITYID",'.') ;
      this.AV24WWPDiscussionMessageEntityRecordId=gx.fn.getControlValue("vWWPDISCUSSIONMESSAGEENTITYRECORDID") ;
      this.A84WWPDiscussionMessageThreadId=gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGETHREADID",'.') ;
      this.AV35Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.AV14IsFirstDiscussionRecord=gx.fn.getControlValue("vISFIRSTDISCUSSIONRECORD") ;
      this.A40000WWPUserExtendedPhoto_GXI=gx.fn.getControlValue("WWPUSEREXTENDEDPHOTO_GXI") ;
      this.AV25WWPDiscussionMessageIdToExpand=gx.fn.getIntegerValue("vWWPDISCUSSIONMESSAGEIDTOEXPAND",'.') ;
      this.AV28WWPSubscriptionEntityRecordDescription=gx.fn.getControlValue("vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION") ;
      this.AV27WWPNotificationLink=gx.fn.getControlValue("vWWPNOTIFICATIONLINK") ;
      this.AV26WWPEntityName=gx.fn.getControlValue("vWWPENTITYNAME") ;
      this.AV7WWPDiscussionMessage=gx.fn.getControlValue("vWWPDISCUSSIONMESSAGE") ;
      this.AV24WWPDiscussionMessageEntityRecordId=gx.fn.getControlValue("vWWPDISCUSSIONMESSAGEENTITYRECORDID") ;
      this.AV8WWPEntityId=gx.fn.getIntegerValue("vWWPENTITYID",'.') ;
      this.AV35Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.AV14IsFirstDiscussionRecord=gx.fn.getControlValue("vISFIRSTDISCUSSIONRECORD") ;
      this.AV25WWPDiscussionMessageIdToExpand=gx.fn.getIntegerValue("vWWPDISCUSSIONMESSAGEIDTOEXPAND",'.') ;
      this.AV28WWPSubscriptionEntityRecordDescription=gx.fn.getControlValue("vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION") ;
      this.AV27WWPNotificationLink=gx.fn.getControlValue("vWWPNOTIFICATIONLINK") ;
   };
   this.e20272_client=function()
   {
      this.clearMessages();
      gx.fn.setCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible", !gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible") );
      gx.fn.setCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible", !gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible") );
      if ( gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible") != 0 )
      {
         this.refreshComponent("DISCUSSIONSONETHREADCOLLAPSEDWC") ;
      }
      else
      {
         if ( this.AV13IsDiscussionAnswersWCLoaded )
         {
            this.refreshComponent("WCDISCUSSIONSONETHREADWC") ;
         }
         else
         {
            this.createWebComponent('Wcdiscussionsonethreadwc','WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadWC',[this.A83WWPDiscussionMessageId,this.AV28WWPSubscriptionEntityRecordDescription,this.AV27WWPNotificationLink]);
            this.AV13IsDiscussionAnswersWCLoaded =  true  ;
         }
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible")',ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWCCELL',prop:'Visible'},{ctrl:'WCDISCUSSIONSONETHREADWC'},{av:'AV13IsDiscussionAnswersWCLoaded',fld:'vISDISCUSSIONANSWERSWCLOADED',pic:''}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e11271_client=function()
   {
      this.clearMessages();
      /* Start For Each Line in Grid */
      var rowIdx16 = 1 ;
      var currentRowIdx16 = gx.fn.currentGridRowImpl(16) ;
      var rowIdxS16 ;
      var gridObj16 = gx.O.getGridById(16,0) ;
      while ( rowIdx16 <= gridObj16.grid.rows.length )
      {
         rowIdxS16 =  gx.text.padl( gx.text.tostring( rowIdx16), 4, "0")  ;
         gridObj16.instanciateRow(gridObj16.grid.getRowById(rowIdx16 - 1));
         gx.fn.setCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible", false );
         gx.fn.setCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible", true );
         this.refreshComponent("DISCUSSIONSONETHREADCOLLAPSEDWC") ;
         rowIdx16 = gx.num.trunc( rowIdx16 + 1 ,0) ;
         this.refreshRowOutputs([{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible")',ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWCCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("NEWTHREADCELL","Visible")',ctrl:'NEWTHREADCELL',prop:'Visible'}]);
      }
      if ( currentRowIdx16 )
      {
         gridObj16.instanciateRow(currentRowIdx16);
      }
      gx.fn.setCtrlProperty("NEWTHREADCELL","Visible", true );
      gx.fn.usrSetFocus("vMESSAGE") ;
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible")',ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWCCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("NEWTHREADCELL","Visible")',ctrl:'NEWTHREADCELL',prop:'Visible'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e16272_client=function()
   {
      return this.executeServerEvent("'FIRSTPAGE'", true, arguments[0], false, false);
   };
   this.e17272_client=function()
   {
      return this.executeServerEvent("'PREVIOUSPAGE'", true, arguments[0], false, false);
   };
   this.e18272_client=function()
   {
      return this.executeServerEvent("'NEXTPAGE'", true, arguments[0], false, false);
   };
   this.e19272_client=function()
   {
      return this.executeServerEvent("'LASTPAGE'", true, arguments[0], false, false);
   };
   this.e12272_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e21272_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,34,35,37,38,39,40,41,42,43,44,46,47,49,50,51,54,55,57,58,59,60,61,62,63,64,65,66,67,68,70,71,72,73];
   this.GXLastCtrlId =73;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",16,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.discussions.wwp_discussionswc",[],true,1,false,true,0,false,false,false,"",0,"px",0,"px","Novo registro",true,false,true,null,null,false,"",true,[1,1,1,1],false,0,false,false);
   var GridContainer = this.GridContainer;
   GridContainer.startDiv(17,"Unnamedtablefsgrid","0px","0px");
   GridContainer.startDiv(18,"","0px","0px");
   GridContainer.startDiv(19,"Discussioncardcell","0px","0px");
   GridContainer.startDiv(20,"Discussioncard","0px","0px");
   GridContainer.startDiv(21,"","0px","0px");
   GridContainer.startDiv(22,"","0px","0px");
   GridContainer.startDiv(23,"Tablecard","0px","0px");
   GridContainer.startDiv(24,"","0px","0px");
   GridContainer.startDiv(25,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addBitmap("&Userextendedphoto","vUSEREXTENDEDPHOTO",26,0,"",0,"",null,"","","AttributeDiscussionImage","");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(27,"","0px","0px");
   GridContainer.startDiv(28,"Tabletitle","0px","0px");
   GridContainer.startDiv(29,"","0px","0px");
   GridContainer.startDiv(30,"","0px","0px");
   GridContainer.startTable("Tablemergedwwpuserextendedfullname",31,"0px");
   GridContainer.startRow("","","","","","");
   GridContainer.startCell("","","","","","","","","","MergeDataCell");
   GridContainer.startDiv(34,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(2,35,"WWPUSEREXTENDEDFULLNAME","","","WWPUserExtendedFullName","svchar",80,"chr",100,80,"left",null,[],2,"WWPUserExtendedFullName",true,0,false,false,"SimpleCardAttributeTitle",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(37,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(87,38,"WWPDISCUSSIONMESSAGEDATE","","","WWPDiscussionMessageDate","dtime",14,"chr",14,14,"right",null,[],87,"WWPDiscussionMessageDate",true,5,false,false,"AttributeDiscussionDate",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.endRow();
   GridContainer.endTable();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(39,"","0px","0px");
   GridContainer.startDiv(40,"","0px","0px");
   GridContainer.startDiv(41,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addMultipleLineEdit(88,42,"WWPDISCUSSIONMESSAGEMESSAGE","","WWPDiscussionMessageMessage","svchar",80,"chr",5,"row","400",400,"left",null,true,false,0,"");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(43,"","0px","0px");
   GridContainer.startDiv(44,"Wcdiscussionsonethreadcell","0px","0px");
   GridContainer.addWebComponent("Wcdiscussionsonethreadwc");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(46,"","0px","0px");
   GridContainer.startDiv(47,"Discussionsonethreadcollapsedwccell","0px","0px");
   GridContainer.addWebComponent("Discussionsonethreadcollapsedwc");
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.startDiv(49,"","0px","0px");
   GridContainer.startDiv(50,"","0px","0px");
   GridContainer.startTable("Unnamedtablecontentfsgrid",51,"0px");
   GridContainer.startRow("","","","","","");
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(54,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addCheckBox("Isdiscussionanswerswcloaded",55,"vISDISCUSSIONANSWERSWCLOADED","","","IsDiscussionAnswersWCLoaded","boolean","true","false",null,true,false,4,"chr","");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.startCell("","","","","","","","","","");
   GridContainer.startDiv(57,"","0px","0px");
   GridContainer.addLabel();
   GridContainer.addSingleLineEdit(83,58,"WWPDISCUSSIONMESSAGEID","","","WWPDiscussionMessageId","int",10,"chr",10,10,"right",null,[],83,"WWPDiscussionMessageId",true,0,false,false,"Attribute",1,"");
   GridContainer.endDiv();
   GridContainer.endCell();
   GridContainer.endRow();
   GridContainer.endTable();
   GridContainer.endDiv();
   GridContainer.endDiv();
   GridContainer.endDiv();
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   this.UCMENTIONSContainer = gx.uc.getNew(this, 69, 64, "WWP_Suggest_UC", this.CmpContext + "UCMENTIONSContainer", "Ucmentions", "UCMENTIONS");
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
   GXValidFnc[9]={ id: 9, fld:"UNNAMEDTABLE1",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"DISCUSSIONSTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"NEWTHREAD", format:0,grid:0,evt:"e11271_client", ctrltype: "textblock"};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"GRIDCELL",grid:0};
   GXValidFnc[17]={ id: 17, fld:"UNNAMEDTABLEFSGRID",grid:16};
   GXValidFnc[18]={ id: 18, fld:"",grid:16};
   GXValidFnc[19]={ id: 19, fld:"DISCUSSIONCARDCELL",grid:16};
   GXValidFnc[20]={ id: 20, fld:"DISCUSSIONCARD",grid:16,evt:"e20272_client"};
   GXValidFnc[21]={ id: 21, fld:"",grid:16};
   GXValidFnc[22]={ id: 22, fld:"",grid:16};
   GXValidFnc[23]={ id: 23, fld:"TABLECARD",grid:16};
   GXValidFnc[24]={ id: 24, fld:"",grid:16};
   GXValidFnc[25]={ id: 25, fld:"",grid:16};
   GXValidFnc[26]={ id:26 ,lvl:2,type:"bits",len:1024,dec:0,sign:false,ro:1,isacc:0,grid:16,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSEREXTENDEDPHOTO",gxz:"ZV20UserExtendedPhoto",gxold:"OV20UserExtendedPhoto",gxvar:"AV20UserExtendedPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV20UserExtendedPhoto=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV20UserExtendedPhoto=Value},v2c:function(row){gx.fn.setGridMultimediaValue("vUSEREXTENDEDPHOTO",row || gx.fn.currentGridRowImpl(16),gx.O.AV20UserExtendedPhoto,gx.O.AV34Userextendedphoto_GXI)},c2v:function(row){gx.O.AV34Userextendedphoto_GXI=this.val_GXI();if(this.val(row)!==undefined)gx.O.AV20UserExtendedPhoto=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vUSEREXTENDEDPHOTO",row || gx.fn.currentGridRowImpl(16))},val_GXI:function(row){return gx.fn.getGridControlValue("vUSEREXTENDEDPHOTO_GXI",row || gx.fn.currentGridRowImpl(16))}, gxvar_GXI:'AV34Userextendedphoto_GXI',nac:gx.falseFn};
   GXValidFnc[27]={ id: 27, fld:"",grid:16};
   GXValidFnc[28]={ id: 28, fld:"TABLETITLE",grid:16};
   GXValidFnc[29]={ id: 29, fld:"",grid:16};
   GXValidFnc[30]={ id: 30, fld:"",grid:16};
   GXValidFnc[31]={ id: 31, fld:"TABLEMERGEDWWPUSEREXTENDEDFULLNAME",grid:16};
   GXValidFnc[34]={ id: 34, fld:"",grid:16};
   GXValidFnc[35]={ id:35 ,lvl:2,type:"svchar",len:100,dec:0,sign:false,ro:1,isacc:0,grid:16,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",gxz:"Z2WWPUserExtendedFullName",gxold:"O2WWPUserExtendedFullName",gxvar:"A2WWPUserExtendedFullName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A2WWPUserExtendedFullName=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z2WWPUserExtendedFullName=Value},v2c:function(row){gx.fn.setGridControlValue("WWPUSEREXTENDEDFULLNAME",row || gx.fn.currentGridRowImpl(16),gx.O.A2WWPUserExtendedFullName,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A2WWPUserExtendedFullName=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPUSEREXTENDEDFULLNAME",row || gx.fn.currentGridRowImpl(16))},nac:gx.falseFn};
   GXValidFnc[37]={ id: 37, fld:"",grid:16};
   GXValidFnc[38]={ id:38 ,lvl:2,type:"dtime",len:8,dec:5,sign:false,ro:1,isacc:0,grid:16,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEDATE",gxz:"Z87WWPDiscussionMessageDate",gxold:"O87WWPDiscussionMessageDate",gxvar:"A87WWPDiscussionMessageDate",dp:{f:0,st:true,wn:false,mf:false,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(Value)},v2c:function(row){gx.fn.setGridControlValue("WWPDISCUSSIONMESSAGEDATE",row || gx.fn.currentGridRowImpl(16),gx.O.A87WWPDiscussionMessageDate,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A87WWPDiscussionMessageDate=gx.fn.toDatetimeValue(this.val(row))},val:function(row){return gx.fn.getGridDateTimeValue("WWPDISCUSSIONMESSAGEDATE",row || gx.fn.currentGridRowImpl(16))},nac:gx.falseFn};
   GXValidFnc[39]={ id: 39, fld:"",grid:16};
   GXValidFnc[40]={ id: 40, fld:"",grid:16};
   GXValidFnc[41]={ id: 41, fld:"",grid:16};
   GXValidFnc[42]={ id:42 ,lvl:2,type:"svchar",len:400,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:16,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEMESSAGE",gxz:"Z88WWPDiscussionMessageMessage",gxold:"O88WWPDiscussionMessageMessage",gxvar:"A88WWPDiscussionMessageMessage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A88WWPDiscussionMessageMessage=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z88WWPDiscussionMessageMessage=Value},v2c:function(row){gx.fn.setGridControlValue("WWPDISCUSSIONMESSAGEMESSAGE",row || gx.fn.currentGridRowImpl(16),gx.O.A88WWPDiscussionMessageMessage,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A88WWPDiscussionMessageMessage=this.val(row)},val:function(row){return gx.fn.getGridControlValue("WWPDISCUSSIONMESSAGEMESSAGE",row || gx.fn.currentGridRowImpl(16))},nac:gx.falseFn};
   GXValidFnc[43]={ id: 43, fld:"",grid:16};
   GXValidFnc[44]={ id: 44, fld:"WCDISCUSSIONSONETHREADCELL",grid:16};
   GXValidFnc[46]={ id: 46, fld:"",grid:16};
   GXValidFnc[47]={ id: 47, fld:"DISCUSSIONSONETHREADCOLLAPSEDWCCELL",grid:16};
   GXValidFnc[49]={ id: 49, fld:"",grid:16};
   GXValidFnc[50]={ id: 50, fld:"",grid:16};
   GXValidFnc[51]={ id: 51, fld:"UNNAMEDTABLECONTENTFSGRID",grid:16};
   GXValidFnc[54]={ id: 54, fld:"",grid:16};
   GXValidFnc[55]={ id:55 ,lvl:2,type:"boolean",len:4,dec:0,sign:false,ro:0,isacc:0,grid:16,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vISDISCUSSIONANSWERSWCLOADED",gxz:"ZV13IsDiscussionAnswersWCLoaded",gxold:"OV13IsDiscussionAnswersWCLoaded",gxvar:"AV13IsDiscussionAnswersWCLoaded",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV13IsDiscussionAnswersWCLoaded=gx.lang.booleanValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV13IsDiscussionAnswersWCLoaded=gx.lang.booleanValue(Value)},v2c:function(row){gx.fn.setGridCheckBoxValue("vISDISCUSSIONANSWERSWCLOADED",row || gx.fn.currentGridRowImpl(16),gx.O.AV13IsDiscussionAnswersWCLoaded,true)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV13IsDiscussionAnswersWCLoaded=gx.lang.booleanValue(this.val(row))},val:function(row){return gx.fn.getGridControlValue("vISDISCUSSIONANSWERSWCLOADED",row || gx.fn.currentGridRowImpl(16))},nac:gx.falseFn,values:['true','false']};
   GXValidFnc[57]={ id: 57, fld:"",grid:16};
   GXValidFnc[58]={ id:58 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:16,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEID",gxz:"Z83WWPDiscussionMessageId",gxold:"O83WWPDiscussionMessageId",gxvar:"A83WWPDiscussionMessageId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z83WWPDiscussionMessageId=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("WWPDISCUSSIONMESSAGEID",row || gx.fn.currentGridRowImpl(16),gx.O.A83WWPDiscussionMessageId,0);if (typeof(this.dom_hdl) == 'function') this.dom_hdl.call(gx.O);},c2v:function(row){if(this.val(row)!==undefined)gx.O.A83WWPDiscussionMessageId=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("WWPDISCUSSIONMESSAGEID",row || gx.fn.currentGridRowImpl(16),'.')},nac:gx.falseFn};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"NEWTHREADCELL",grid:0};
   GXValidFnc[61]={ id: 61, fld:"TABLENEWTHREAD",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id: 63, fld:"",grid:0};
   GXValidFnc[64]={ id:64 ,lvl:0,type:"svchar",len:400,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMESSAGE",gxz:"ZV15Message",gxold:"OV15Message",gxvar:"AV15Message",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV15Message=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV15Message=Value},v2c:function(){gx.fn.setControlValue("vMESSAGE",gx.O.AV15Message,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV15Message=this.val()},val:function(){return gx.fn.getControlValue("vMESSAGE")},nac:gx.falseFn};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"ENTER", format:1,grid:0,evt:"e12272_client",std:"ENTER", ctrltype: "textblock"};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id: 68, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};
   GXValidFnc[73]={ id:73 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPDISCUSSIONMESSAGEENTITYRECORDID",gxz:"Z89WWPDiscussionMessageEntityRecordId",gxold:"O89WWPDiscussionMessageEntityRecordId",gxvar:"A89WWPDiscussionMessageEntityRecordId",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A89WWPDiscussionMessageEntityRecordId=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z89WWPDiscussionMessageEntityRecordId=Value},v2c:function(){gx.fn.setControlValue("WWPDISCUSSIONMESSAGEENTITYRECORDID",gx.O.A89WWPDiscussionMessageEntityRecordId,0)},c2v:function(){if(this.val()!==undefined)gx.O.A89WWPDiscussionMessageEntityRecordId=this.val()},val:function(){return gx.fn.getControlValue("WWPDISCUSSIONMESSAGEENTITYRECORDID")},nac:gx.falseFn};
   this.ZV20UserExtendedPhoto = "" ;
   this.OV20UserExtendedPhoto = "" ;
   this.Z2WWPUserExtendedFullName = "" ;
   this.O2WWPUserExtendedFullName = "" ;
   this.Z87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.O87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.Z88WWPDiscussionMessageMessage = "" ;
   this.O88WWPDiscussionMessageMessage = "" ;
   this.ZV13IsDiscussionAnswersWCLoaded = false ;
   this.OV13IsDiscussionAnswersWCLoaded = false ;
   this.Z83WWPDiscussionMessageId = 0 ;
   this.O83WWPDiscussionMessageId = 0 ;
   this.AV15Message = "" ;
   this.ZV15Message = "" ;
   this.OV15Message = "" ;
   this.A89WWPDiscussionMessageEntityRecordId = "" ;
   this.Z89WWPDiscussionMessageEntityRecordId = "" ;
   this.O89WWPDiscussionMessageEntityRecordId = "" ;
   this.AV15Message = "" ;
   this.A89WWPDiscussionMessageEntityRecordId = "" ;
   this.A40000WWPUserExtendedPhoto_GXI = "" ;
   this.AV26WWPEntityName = "" ;
   this.AV24WWPDiscussionMessageEntityRecordId = "" ;
   this.AV28WWPSubscriptionEntityRecordDescription = "" ;
   this.AV27WWPNotificationLink = "" ;
   this.A84WWPDiscussionMessageThreadId = 0 ;
   this.A10WWPEntityId = 0 ;
   this.A1WWPUserExtendedId = "" ;
   this.AV20UserExtendedPhoto = "" ;
   this.A2WWPUserExtendedFullName = "" ;
   this.A87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.A88WWPDiscussionMessageMessage = "" ;
   this.AV13IsDiscussionAnswersWCLoaded = false ;
   this.A83WWPDiscussionMessageId = 0 ;
   this.AV8WWPEntityId = 0 ;
   this.AV35Pgmname = "" ;
   this.AV14IsFirstDiscussionRecord = false ;
   this.AV25WWPDiscussionMessageIdToExpand = 0 ;
   this.AV7WWPDiscussionMessage = {WWPDiscussionMessageId:0,WWPDiscussionMessageDate:gx.date.nullDate(),WWPDiscussionMessageThreadId:0,WWPDiscussionMessageMessage:"",WWPUserExtendedId:"",WWPUserExtendedPhoto:"",WWPUserExtendedPhoto_GXI:"",WWPUserExtendedFullName:"",WWPEntityId:0,WWPEntityName:"",WWPDiscussionMessageEntityRecordId:"",Mode:"",Initialized:0,WWPDiscussionMessageId_Z:0,WWPDiscussionMessageDate_Z:gx.date.nullDate(),WWPDiscussionMessageThreadId_Z:0,WWPDiscussionMessageMessage_Z:"",WWPUserExtendedId_Z:"",WWPUserExtendedFullName_Z:"",WWPEntityId_Z:0,WWPEntityName_Z:"",WWPDiscussionMessageEntityRecordId_Z:"",WWPUserExtendedPhoto_GXI_Z:"",WWPDiscussionMessageThreadId_N:0} ;
   this.Events = {"e16272_client": ["'FIRSTPAGE'", true] ,"e17272_client": ["'PREVIOUSPAGE'", true] ,"e18272_client": ["'NEXTPAGE'", true] ,"e19272_client": ["'LASTPAGE'", true] ,"e12272_client": ["ENTER", true] ,"e21272_client": ["CANCEL", true] ,"e20272_client": ["DISCUSSIONCARD.CLICK", false] ,"e11271_client": ["NEWTHREAD.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'gx.fn.getCtrlProperty("vISDISCUSSIONANSWERSWCLOADED","Visible")',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'sPrefix'},{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'A84WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{ctrl:'GRID',prop:'Rows'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV7WWPDiscussionMessage',fld:'vWWPDISCUSSIONMESSAGE',pic:'',hsh:true},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''}],[{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'gx.fn.getCtrlProperty("GRIDCELL","Visible")',ctrl:'GRIDCELL',prop:'Visible'},{av:'AV13IsDiscussionAnswersWCLoaded',fld:'vISDISCUSSIONANSWERSWCLOADED',pic:''},{av:'gx.fn.getCtrlProperty("NEWTHREAD","Visible")',ctrl:'NEWTHREAD',prop:'Visible'}]];
   this.EvtParms["START"] = [[{av:'AV26WWPEntityName',fld:'vWWPENTITYNAME',pic:''},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''}],[{av:'this.UCMENTIONSContainer.GAMOAuthToken',ctrl:'UCMENTIONS',prop:'GAMOAuthToken'},{av:'this.UCMENTIONSContainer.ItemHtmlTemplate',ctrl:'UCMENTIONS',prop:'ItemHtmlTemplate'},{av:'gx.fn.getCtrlProperty("vISDISCUSSIONANSWERSWCLOADED","Visible")',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEENTITYRECORDID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEENTITYRECORDID',prop:'Visible'},{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV7WWPDiscussionMessage',fld:'vWWPDISCUSSIONMESSAGE',pic:'',hsh:true},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'sPrefix'}]];
   this.EvtParms["GRID.LOAD"] = [[{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''}],[{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("NEWTHREADCELL","Visible")',ctrl:'NEWTHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("GRIDCELL","Visible")',ctrl:'GRIDCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("NEWTHREAD","Visible")',ctrl:'NEWTHREAD',prop:'Visible'},{av:'AV20UserExtendedPhoto',fld:'vUSEREXTENDEDPHOTO',pic:''},{ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWC'},{ctrl:'WCDISCUSSIONSONETHREADWC'},{av:'AV13IsDiscussionAnswersWCLoaded',fld:'vISDISCUSSIONANSWERSWCLOADED',pic:''},{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible")',ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWCCELL',prop:'Visible'}]];
   this.EvtParms["'FIRSTPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("vISDISCUSSIONANSWERSWCLOADED","Visible")',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV7WWPDiscussionMessage',fld:'vWWPDISCUSSIONMESSAGE',pic:'',hsh:true},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["'PREVIOUSPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("vISDISCUSSIONANSWERSWCLOADED","Visible")',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV7WWPDiscussionMessage',fld:'vWWPDISCUSSIONMESSAGE',pic:'',hsh:true},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["'NEXTPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("vISDISCUSSIONANSWERSWCLOADED","Visible")',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV7WWPDiscussionMessage',fld:'vWWPDISCUSSIONMESSAGE',pic:'',hsh:true},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["'LASTPAGE'"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("vISDISCUSSIONANSWERSWCLOADED","Visible")',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV7WWPDiscussionMessage',fld:'vWWPDISCUSSIONMESSAGE',pic:'',hsh:true},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["ENTER"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV24WWPDiscussionMessageEntityRecordId',fld:'vWWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("vISDISCUSSIONANSWERSWCLOADED","Visible")',ctrl:'vISDISCUSSIONANSWERSWCLOADED',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WWPDISCUSSIONMESSAGEID","Visible")',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV7WWPDiscussionMessage',fld:'vWWPDISCUSSIONMESSAGE',pic:'',hsh:true},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'sPrefix'},{av:'AV26WWPEntityName',fld:'vWWPENTITYNAME',pic:''},{av:'this.UCMENTIONSContainer.SelectedItemsJson',ctrl:'UCMENTIONS',prop:'SelectedItemsJson'},{av:'AV15Message',fld:'vMESSAGE',pic:''},{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A84WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'}],[{av:'AV8WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV15Message',fld:'vMESSAGE',pic:''},{av:'gx.fn.getCtrlProperty("NEWTHREADCELL","Visible")',ctrl:'NEWTHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'AV14IsFirstDiscussionRecord',fld:'vISFIRSTDISCUSSIONRECORD',pic:'',hsh:true},{av:'AV25WWPDiscussionMessageIdToExpand',fld:'vWWPDISCUSSIONMESSAGEIDTOEXPAND',pic:'ZZZZZZZZZ9',hsh:true},{av:'gx.fn.getCtrlProperty("GRIDCELL","Visible")',ctrl:'GRIDCELL',prop:'Visible'},{av:'AV13IsDiscussionAnswersWCLoaded',fld:'vISDISCUSSIONANSWERSWCLOADED',pic:''},{av:'gx.fn.getCtrlProperty("NEWTHREAD","Visible")',ctrl:'NEWTHREAD',prop:'Visible'}]];
   this.EvtParms["DISCUSSIONCARD.CLICK"] = [[{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible")',ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWCCELL',prop:'Visible'},{av:'AV13IsDiscussionAnswersWCLoaded',fld:'vISDISCUSSIONANSWERSWCLOADED',pic:''},{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'AV28WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'AV27WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''}],[{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible")',ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWCCELL',prop:'Visible'},{ctrl:'WCDISCUSSIONSONETHREADWC'},{av:'AV13IsDiscussionAnswersWCLoaded',fld:'vISDISCUSSIONANSWERSWCLOADED',pic:''}]];
   this.EvtParms["NEWTHREAD.CLICK"] = [[{av:'AV15Message',fld:'vMESSAGE',pic:''}],[{av:'gx.fn.getCtrlProperty("WCDISCUSSIONSONETHREADCELL","Visible")',ctrl:'WCDISCUSSIONSONETHREADCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("DISCUSSIONSONETHREADCOLLAPSEDWCCELL","Visible")',ctrl:'DISCUSSIONSONETHREADCOLLAPSEDWCCELL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("NEWTHREADCELL","Visible")',ctrl:'NEWTHREADCELL',prop:'Visible'}]];
   this.EnterCtrl = ["ENTER"];
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID", 0, "char", 40, 0);
   this.setVCMap("A10WWPEntityId", "WWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("AV8WWPEntityId", "vWWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("AV24WWPDiscussionMessageEntityRecordId", "vWWPDISCUSSIONMESSAGEENTITYRECORDID", 0, "svchar", 100, 0);
   this.setVCMap("A84WWPDiscussionMessageThreadId", "WWPDISCUSSIONMESSAGETHREADID", 0, "int", 10, 0);
   this.setVCMap("AV35Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV14IsFirstDiscussionRecord", "vISFIRSTDISCUSSIONRECORD", 0, "boolean", 4, 0);
   this.setVCMap("A40000WWPUserExtendedPhoto_GXI", "WWPUSEREXTENDEDPHOTO_GXI", 0, "svchar", 2048, 0);
   this.setVCMap("AV25WWPDiscussionMessageIdToExpand", "vWWPDISCUSSIONMESSAGEIDTOEXPAND", 0, "int", 10, 0);
   this.setVCMap("AV28WWPSubscriptionEntityRecordDescription", "vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION", 0, "svchar", 40, 0);
   this.setVCMap("AV27WWPNotificationLink", "vWWPNOTIFICATIONLINK", 0, "svchar", 40, 0);
   this.setVCMap("AV26WWPEntityName", "vWWPENTITYNAME", 0, "svchar", 100, 0);
   this.setVCMap("AV7WWPDiscussionMessage", "vWWPDISCUSSIONMESSAGE", 0, "WWPBaseObjects\Discussions\WWP_DiscussionMessage", 0, 0);
   this.setVCMap("AV24WWPDiscussionMessageEntityRecordId", "vWWPDISCUSSIONMESSAGEENTITYRECORDID", 0, "svchar", 100, 0);
   this.setVCMap("AV8WWPEntityId", "vWWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("AV35Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV14IsFirstDiscussionRecord", "vISFIRSTDISCUSSIONRECORD", 0, "boolean", 4, 0);
   this.setVCMap("AV25WWPDiscussionMessageIdToExpand", "vWWPDISCUSSIONMESSAGEIDTOEXPAND", 0, "int", 10, 0);
   this.setVCMap("AV28WWPSubscriptionEntityRecordDescription", "vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION", 0, "svchar", 40, 0);
   this.setVCMap("AV27WWPNotificationLink", "vWWPNOTIFICATIONLINK", 0, "svchar", 40, 0);
   this.setVCMap("AV24WWPDiscussionMessageEntityRecordId", "vWWPDISCUSSIONMESSAGEENTITYRECORDID", 0, "svchar", 100, 0);
   this.setVCMap("AV8WWPEntityId", "vWWPENTITYID", 0, "int", 10, 0);
   this.setVCMap("AV35Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV14IsFirstDiscussionRecord", "vISFIRSTDISCUSSIONRECORD", 0, "boolean", 4, 0);
   this.setVCMap("AV25WWPDiscussionMessageIdToExpand", "vWWPDISCUSSIONMESSAGEIDTOEXPAND", 0, "int", 10, 0);
   this.setVCMap("AV28WWPSubscriptionEntityRecordDescription", "vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION", 0, "svchar", 40, 0);
   this.setVCMap("AV27WWPNotificationLink", "vWWPNOTIFICATIONLINK", 0, "svchar", 40, 0);
   GridContainer.addRefreshingParm({rfrProp:"Rows", gxGrid:"Grid"});
   GridContainer.addRefreshingVar({rfrVar:"AV24WWPDiscussionMessageEntityRecordId"});
   GridContainer.addRefreshingVar({rfrVar:"AV8WWPEntityId"});
   GridContainer.addRefreshingVar({rfrVar:"AV35Pgmname"});
   GridContainer.addRefreshingVar({rfrVar:"AV13IsDiscussionAnswersWCLoaded", rfrProp:"Visible", gxAttId:"Isdiscussionanswerswcloaded"});
   GridContainer.addRefreshingVar({rfrVar:"A83WWPDiscussionMessageId", rfrProp:"Visible", gxAttId:"83"});
   GridContainer.addRefreshingVar({rfrVar:"AV14IsFirstDiscussionRecord"});
   GridContainer.addRefreshingVar({rfrVar:"AV25WWPDiscussionMessageIdToExpand"});
   GridContainer.addRefreshingVar({rfrVar:"AV28WWPSubscriptionEntityRecordDescription"});
   GridContainer.addRefreshingVar({rfrVar:"AV27WWPNotificationLink"});
   GridContainer.addRefreshingVar({rfrVar:"AV7WWPDiscussionMessage"});
   GridContainer.addRefreshingVar(this.GXValidFnc[73]);
   GridContainer.addRefreshingParm({rfrVar:"AV24WWPDiscussionMessageEntityRecordId"});
   GridContainer.addRefreshingParm({rfrVar:"AV8WWPEntityId"});
   GridContainer.addRefreshingParm({rfrVar:"AV35Pgmname"});
   GridContainer.addRefreshingParm({rfrVar:"AV13IsDiscussionAnswersWCLoaded", rfrProp:"Visible", gxAttId:"Isdiscussionanswerswcloaded"});
   GridContainer.addRefreshingParm({rfrVar:"A83WWPDiscussionMessageId", rfrProp:"Visible", gxAttId:"83"});
   GridContainer.addRefreshingParm({rfrVar:"AV14IsFirstDiscussionRecord"});
   GridContainer.addRefreshingParm({rfrVar:"AV25WWPDiscussionMessageIdToExpand"});
   GridContainer.addRefreshingParm({rfrVar:"AV28WWPSubscriptionEntityRecordDescription"});
   GridContainer.addRefreshingParm({rfrVar:"AV27WWPNotificationLink"});
   GridContainer.addRefreshingParm({rfrVar:"AV7WWPDiscussionMessage"});
   GridContainer.addRefreshingParm(this.GXValidFnc[73]);
   this.Initialize( );
   this.setComponent({id: "GX_PROCESS" ,GXClass: null , Prefix: "W00-1" , lvl: 1 });
   this.setComponent({id: "WCDISCUSSIONSONETHREADWC" ,GXClass: null , Prefix: "W0045" , lvl: 2 });
   this.setComponent({id: "DISCUSSIONSONETHREADCOLLAPSEDWC" ,GXClass: null , Prefix: "W0048" , lvl: 2 });
   this.setSDTMapping( "WWPBaseObjects\\WWPGridState" , {
      "FilterValues":{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});
   this.setSDTMapping( "GeneXusSecurity\\GAMSession" , {
      "User":{sdt:"GeneXusSecurity\\GAMUser"}});
   this.setSDTMapping( "WWPBaseObjects\\WWPTransactionContext" , {
      "Attributes":{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});
});
