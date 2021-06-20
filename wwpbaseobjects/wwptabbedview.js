gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.wwptabbedview', true, function (CmpContext) {
   this.ServerClass =  "wwpbaseobjects.wwptabbedview" ;
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
      this.AV5Tabs=gx.fn.getControlValue("vTABS") ;
      this.AV7TabCode=gx.fn.getControlValue("vTABCODE") ;
   };
   this.e120q2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e130q2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,8,11,17,19,22,24,26,28,31,34];
   this.GXLastCtrlId =34;
   this.TabsgridContainer = new gx.grid.grid(this, 2,"WbpLvl2",14,"Tabsgrid","Tabsgrid","TabsgridContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.wwptabbedview",[],true,0,false,true,0,false,false,false,"",0,"px",0,"px","Novo registro",false,false,false,null,null,false,"",false,[1,1,1,1],false,0,false,false);
   var TabsgridContainer = this.TabsgridContainer;
   TabsgridContainer.startRow("","","top","","","");
   TabsgridContainer.startCell("","","bottom","","","","","","","");
   TabsgridContainer.addBitmap("Begintab","BEGINTAB",17,0,"px",0,"px",null,"","","Image","");
   TabsgridContainer.endCell();
   TabsgridContainer.startCell("","","top","","","","63px","","","");
   TabsgridContainer.startTable("Tabletab",19,"0px");
   TabsgridContainer.addHtmlCode("<tbody>");
   TabsgridContainer.startRow("","","","","","");
   TabsgridContainer.startCell("","","","","","","","","","");
   TabsgridContainer.addTextBlock('TAB',null,22);
   TabsgridContainer.endCell();
   TabsgridContainer.endRow();
   TabsgridContainer.addHtmlCode("</tbody>");
   TabsgridContainer.endTable();
   TabsgridContainer.endCell();
   TabsgridContainer.endRow();
   this.TabsgridContainer.emptyText = "";
   this.setGrid(TabsgridContainer);
   GXValidFnc[2]={ id: 2, fld:"TABLE4",grid:0};
   GXValidFnc[5]={ id: 5, fld:"TABLE3",grid:0};
   GXValidFnc[8]={ id: 8, fld:"TABLE1",grid:0};
   GXValidFnc[11]={ id: 11, fld:"TABLETABS",grid:0};
   GXValidFnc[17]={ id: 17, fld:"BEGINTAB",grid:14};
   GXValidFnc[19]={ id: 19, fld:"TABLETAB",grid:14};
   GXValidFnc[22]={ id: 22, fld:"TAB", format:0,grid:14, ctrltype: "textblock"};
   GXValidFnc[24]={ id: 24, fld:"ENDTAB",grid:0};
   GXValidFnc[26]={ id: 26, fld:"TABPREVIOUS",grid:0};
   GXValidFnc[28]={ id: 28, fld:"TABNEXT",grid:0};
   GXValidFnc[31]={ id: 31, fld:"TABLE2",grid:0};
   GXValidFnc[34]={ id: 34, fld:"TABLECOMPONENT",grid:0};
   this.AV5Tabs = [ ] ;
   this.AV7TabCode = "" ;
   this.Events = {"e120q2_client": ["ENTER", true] ,"e130q2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'TABSGRID_nFirstRecordOnPage'},{av:'TABSGRID_nEOF'},{av:'sPrefix'}],[]];
   this.setVCMap("AV5Tabs", "vTABS", 0, "CollWWPBaseObjects\WWPTabOptions.TabOptionsItem", 0, 0);
   this.setVCMap("AV7TabCode", "vTABCODE", 0, "char", 50, 0);
   this.Initialize( );
   this.setComponent({id: "COMPONENT" ,GXClass: null , Prefix: "W0037" , lvl: 1 });
});
