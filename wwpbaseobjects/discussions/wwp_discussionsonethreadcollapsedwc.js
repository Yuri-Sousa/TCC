gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.A40000GXC1=gx.fn.getIntegerValue("GXC1",'.') ;
      this.AV11WWPDiscussionMessageThreadId=gx.fn.getIntegerValue("vWWPDISCUSSIONMESSAGETHREADID",'.') ;
      this.A83WWPDiscussionMessageId=gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGEID",'.') ;
      this.A84WWPDiscussionMessageThreadId=gx.fn.getIntegerValue("WWPDISCUSSIONMESSAGETHREADID",'.') ;
      this.A87WWPDiscussionMessageDate=gx.fn.getDateTimeValue("WWPDISCUSSIONMESSAGEDATE") ;
      this.AV13NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO") ;
      this.AV13NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO") ;
   };
   this.e12282_client=function()
   {
      return this.executeServerEvent("ONMESSAGE_GX1", true, null, true, false);
   };
   this.e15282_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e16282_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,15,16,18,19];
   this.GXLastCtrlId =19;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"TABLECONTENT",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"HIDDENANSWERSCELL",grid:0};
   GXValidFnc[12]={ id: 12, fld:"TABLEMERGEDHIDDENANSWERS",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id:16 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vHIDDENANSWERS",gxz:"ZV7HiddenAnswers",gxold:"OV7HiddenAnswers",gxvar:"AV7HiddenAnswers",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7HiddenAnswers=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV7HiddenAnswers=Value},v2c:function(){gx.fn.setControlValue("vHIDDENANSWERS",gx.O.AV7HiddenAnswers,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV7HiddenAnswers=this.val()},val:function(){return gx.fn.getControlValue("vHIDDENANSWERS")},nac:gx.falseFn};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id:19 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vHIDDENANSWERSLASTON",gxz:"ZV8HiddenAnswersLastOn",gxold:"OV8HiddenAnswersLastOn",gxvar:"AV8HiddenAnswersLastOn",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV8HiddenAnswersLastOn=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV8HiddenAnswersLastOn=Value},v2c:function(){gx.fn.setControlValue("vHIDDENANSWERSLASTON",gx.O.AV8HiddenAnswersLastOn,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV8HiddenAnswersLastOn=this.val()},val:function(){return gx.fn.getControlValue("vHIDDENANSWERSLASTON")},nac:gx.falseFn};
   this.AV7HiddenAnswers = "" ;
   this.ZV7HiddenAnswers = "" ;
   this.OV7HiddenAnswers = "" ;
   this.AV8HiddenAnswersLastOn = "" ;
   this.ZV8HiddenAnswersLastOn = "" ;
   this.OV8HiddenAnswersLastOn = "" ;
   this.AV7HiddenAnswers = "" ;
   this.AV8HiddenAnswersLastOn = "" ;
   this.AV11WWPDiscussionMessageThreadId = 0 ;
   this.A84WWPDiscussionMessageThreadId = 0 ;
   this.A87WWPDiscussionMessageDate = gx.date.nullDate() ;
   this.A83WWPDiscussionMessageId = 0 ;
   this.AV13NotificationInfo = {Id:"",Object:"",Message:""} ;
   this.addOnMessage('', "e12282_client", [["GeneXus\Server\NotificationInfo","vNOTIFICATIONINFO","AV13NotificationInfo"]], this.e12282_client);
   this.Events = {"e12282_client": ["ONMESSAGE_GX1", true] ,"e15282_client": ["ENTER", true] ,"e16282_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'AV11WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A84WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}],[{av:'A40000GXC1',fld:'GXC1',pic:'999999999'},{av:'AV8HiddenAnswersLastOn',fld:'vHIDDENANSWERSLASTON',pic:''},{av:'gx.fn.getCtrlProperty("vHIDDENANSWERSLASTON","Visible")',ctrl:'vHIDDENANSWERSLASTON',prop:'Visible'},{av:'AV7HiddenAnswers',fld:'vHIDDENANSWERS',pic:''},{av:'gx.fn.getCtrlProperty("vHIDDENANSWERS","Class")',ctrl:'vHIDDENANSWERS',prop:'Class'}]];
   this.EvtParms["START"] = [[],[]];
   this.EvtParms["ONMESSAGE_GX1"] = [[{av:'AV13NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''}],[]];
   this.setVCMap("A40000GXC1", "GXC1", 0, "int", 9, 0);
   this.setVCMap("AV11WWPDiscussionMessageThreadId", "vWWPDISCUSSIONMESSAGETHREADID", 0, "int", 10, 0);
   this.setVCMap("A83WWPDiscussionMessageId", "WWPDISCUSSIONMESSAGEID", 0, "int", 10, 0);
   this.setVCMap("A84WWPDiscussionMessageThreadId", "WWPDISCUSSIONMESSAGETHREADID", 0, "int", 10, 0);
   this.setVCMap("A87WWPDiscussionMessageDate", "WWPDISCUSSIONMESSAGEDATE", 0, "dtime", 8, 5);
   this.setVCMap("AV13NotificationInfo", "vNOTIFICATIONINFO", 0, "GeneXus\Server\NotificationInfo", 0, 0);
   this.setVCMap("AV13NotificationInfo", "vNOTIFICATIONINFO", 0, "GeneXus\Server\NotificationInfo", 0, 0);
   this.Initialize( );
});
