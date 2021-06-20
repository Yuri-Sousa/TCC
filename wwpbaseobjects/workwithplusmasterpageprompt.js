gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.workwithplusmasterpageprompt', false, function () {
   this.ServerClass =  "wwpbaseobjects.workwithplusmasterpageprompt" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.IsMasterPage=true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.Validv_Pickerdummyvariable=function()
   {
      return this.validCliEvt("Validv_Pickerdummyvariable", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("vPICKERDUMMYVARIABLE_MPAGE");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.AV5PickerDummyVariable)===0) || new gx.date.gxdate( this.AV5PickerDummyVariable ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Picker Dummy Variable fora do intervalo");
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
   this.e130h2_client=function()
   {
      return this.executeServerEvent("ENTER_MPAGE", true, null, false, false);
   };
   this.e140h2_client=function()
   {
      return this.executeServerEvent("CANCEL_MPAGE", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,16,17,19,20,22,23,24,25];
   this.GXLastCtrlId =25;
   this.UCMESSAGE_MPAGEContainer = gx.uc.getNew(this, 12, 0, "DVelop_DVMessage", "UCMESSAGE_MPAGEContainer", "Ucmessage", "UCMESSAGE_MPAGE");
   var UCMESSAGE_MPAGEContainer = this.UCMESSAGE_MPAGEContainer;
   UCMESSAGE_MPAGEContainer.setProp("Class", "Class", "", "char");
   UCMESSAGE_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCMESSAGE_MPAGEContainer.setProp("Width", "Width", "300", "str");
   UCMESSAGE_MPAGEContainer.setProp("MinHeight", "Minheight", "16", "str");
   UCMESSAGE_MPAGEContainer.setProp("StylingType", "Stylingtype", "fontawesome", "str");
   UCMESSAGE_MPAGEContainer.setProp("DefaultMessageType", "Defaultmessagetype", "notice", "str");
   UCMESSAGE_MPAGEContainer.setProp("StopOnError", "Stoponerror", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("TitleEscape", "Titleescape", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("TextEscape", "Textescape", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("ChangeNewLinesToBRs", "Changenewlinestobrs", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Hide", "Hide", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("DelayUntilHide", "Delayuntilhide", 8000, "num");
   UCMESSAGE_MPAGEContainer.setProp("MouseHideReset", "Mousehidereset", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("MessageAdditionalClasses", "Messageadditionalclasses", "", "str");
   UCMESSAGE_MPAGEContainer.setProp("MessageCornerClass", "Messagecornerclass", "", "str");
   UCMESSAGE_MPAGEContainer.setProp("Shadow", "Shadow", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Opacity", "Opacity", "1", "str");
   UCMESSAGE_MPAGEContainer.setProp("StackVerticalFirstPos", "Stackverticalfirstpos", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("StackHorizontalFirstPos", "Stackhorizontalfirstpos", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("StackVerticalSpacing", "Stackverticalspacing", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("StackHorizontalSpacing", "Stackhorizontalspacing", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("EffectIn", "Effectin", "fade", "str");
   UCMESSAGE_MPAGEContainer.setProp("EffectOut", "Effectout", "fade", "str");
   UCMESSAGE_MPAGEContainer.setProp("AnimationSpeed", "Animationspeed", 600, "num");
   UCMESSAGE_MPAGEContainer.setProp("StartPosition", "Startposition", "TopRight", "str");
   UCMESSAGE_MPAGEContainer.setProp("NextMessagePosition", "Nextmessageposition", "down", "str");
   UCMESSAGE_MPAGEContainer.setProp("Closer", "Closer", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("CloserHover", "Closerhover", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Sticker", "Sticker", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("StickerHover", "Stickerhover", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("LabelCloseButton", "Labelclosebutton", "Close", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelStickButton", "Labelstickbutton", "Stick", "str");
   UCMESSAGE_MPAGEContainer.setProp("showEvenOnNonblock", "Showevenonnonblock", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("NonBlock", "Nonblock", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("NonBlockOpacity", "Nonblockopacity", ".2", "str");
   UCMESSAGE_MPAGEContainer.setProp("EnableHistory", "Enablehistory", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Menu", "Menu", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("FixedMenu", "Fixedmenu", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("MaxOnScreen", "Maxonscreen", "Infinity", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelRedisplay", "Labelredisplay", "Redisplay", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelAll", "Labelall", "All", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelLast", "Labellast", "Last", "str");
   UCMESSAGE_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCMESSAGE_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCMESSAGE_MPAGEContainer);
   this.UCTOOLTIP_MPAGEContainer = gx.uc.getNew(this, 15, 0, "BootstrapTooltip", "UCTOOLTIP_MPAGEContainer", "Uctooltip", "UCTOOLTIP_MPAGE");
   var UCTOOLTIP_MPAGEContainer = this.UCTOOLTIP_MPAGEContainer;
   UCTOOLTIP_MPAGEContainer.setProp("Class", "Class", "", "char");
   UCTOOLTIP_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCTOOLTIP_MPAGEContainer.setProp("ClassSelector", "Classselector", "BootstrapTooltip", "str");
   UCTOOLTIP_MPAGEContainer.setProp("DefaultPosition", "Defaultposition", "bottom", "str");
   UCTOOLTIP_MPAGEContainer.setProp("LabelsShowDelay", "Labelsshowdelay", 300, "num");
   UCTOOLTIP_MPAGEContainer.setProp("ButtonsShowDelay", "Buttonsshowdelay", 300, "num");
   UCTOOLTIP_MPAGEContainer.setProp("InputsShowDelay", "Inputsshowdelay", 300, "num");
   UCTOOLTIP_MPAGEContainer.setProp("ImagesShowDelay", "Imagesshowdelay", 0, "num");
   UCTOOLTIP_MPAGEContainer.setProp("HideDelay", "Hidedelay", 0, "num");
   UCTOOLTIP_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   UCTOOLTIP_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCTOOLTIP_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCTOOLTIP_MPAGEContainer);
   this.WWPUTILITIES_MPAGEContainer = gx.uc.getNew(this, 18, 0, "DVelop_WorkWithPlusUtilities", "WWPUTILITIES_MPAGEContainer", "Wwputilities", "WWPUTILITIES_MPAGE");
   var WWPUTILITIES_MPAGEContainer = this.WWPUTILITIES_MPAGEContainer;
   WWPUTILITIES_MPAGEContainer.setProp("Class", "Class", "", "char");
   WWPUTILITIES_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   WWPUTILITIES_MPAGEContainer.setProp("EnableAutoUpdateFromDocumentTitle", "Enableautoupdatefromdocumenttitle", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableFixObjectFitCover", "Enablefixobjectfitcover", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableFloatingLabels", "Enablefloatinglabels", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EmpowerTabs", "Empowertabs", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableUpdateRowSelectionStatus", "Enableupdaterowselectionstatus", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("CurrentTab_ReturnUrl", "Currenttab_returnurl", "", "char");
   WWPUTILITIES_MPAGEContainer.setProp("EnableConvertComboToBootstrapSelect", "Enableconvertcombotobootstrapselect", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnResizing", "Allowcolumnresizing", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnReordering", "Allowcolumnreordering", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnDragging", "Allowcolumndragging", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnsRestore", "Allowcolumnsrestore", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("RestoreColumnsIconClass", "Restorecolumnsiconclass", "fas fa-undo", "str");
   WWPUTILITIES_MPAGEContainer.setProp("PagBarIncludeGoTo", "Pagbarincludegoto", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("UpdateButtonText", "Updatebuttontext", "WWP_ColumnsSelectorButton", "str");
   WWPUTILITIES_MPAGEContainer.setProp("AddNewOption", "Addnewoption", "WWP_AddNewOption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("OnlySelectedValues", "Onlyselectedvalues", "WWP_OnlySelectedValues", "str");
   WWPUTILITIES_MPAGEContainer.setProp("MultipleValuesSeparator", "Multiplevaluesseparator", ", ", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SelectAll", "Selectall", "WWP_SelectAll", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SortASC", "Sortasc", "WWP_TSSortASC", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SortDSC", "Sortdsc", "WWP_TSSortDSC", "str");
   WWPUTILITIES_MPAGEContainer.setProp("AllowGroupText", "Allowgrouptext", "WWP_GroupByOption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("FixLeftText", "Fixlefttext", "WWP_TSFixLeft", "str");
   WWPUTILITIES_MPAGEContainer.setProp("FixRightText", "Fixrighttext", "WWP_TSFixRight", "str");
   WWPUTILITIES_MPAGEContainer.setProp("LoadingData", "Loadingdata", "WWP_TSLoading", "str");
   WWPUTILITIES_MPAGEContainer.setProp("CleanFilter", "Cleanfilter", "WWP_TSCleanFilter", "str");
   WWPUTILITIES_MPAGEContainer.setProp("RangeFilterFrom", "Rangefilterfrom", "WWP_TSFrom", "str");
   WWPUTILITIES_MPAGEContainer.setProp("RangeFilterTo", "Rangefilterto", "WWP_TSTo", "str");
   WWPUTILITIES_MPAGEContainer.setProp("RangePickerInviteMessage", "Rangepickerinvitemessage", "WWP_TSRangePickerInviteMessage", "str");
   WWPUTILITIES_MPAGEContainer.setProp("NoResultsFound", "Noresultsfound", "WWP_TSNoResults", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SearchButtonText", "Searchbuttontext", "WWP_TSSearchButtonCaption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SearchMultipleValuesButtonText", "Searchmultiplevaluesbuttontext", "WWP_FilterSelected", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorFixedLeftCategory", "Columnselectorfixedleftcategory", "WWP_ColumnSelectorFixedLeftCategory", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorFixedRightCategory", "Columnselectorfixedrightcategory", "WWP_ColumnSelectorFixedRightCategory", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorNotFixedCategory", "Columnselectornotfixedcategory", "WWP_ColumnSelectorNotFixedCategory", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorFixedEmpty", "Columnselectorfixedempty", "WWP_ColumnSelectorFixedEmpty", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorRestoreTooltip", "Columnselectorrestoretooltip", "WWP_SelectColumns_RestoreDefault", "str");
   WWPUTILITIES_MPAGEContainer.setProp("PagBarGoToCaption", "Pagbargotocaption", "WWP_PaginationBarGoToCaption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("PagBarGoToIconClass", "Pagbargotoiconclass", "fas fa-redo", "str");
   WWPUTILITIES_MPAGEContainer.setProp("PagBarGoToTooltip", "Pagbargototooltip", "WWP_PaginationBarGoToTooltip", "str");
   WWPUTILITIES_MPAGEContainer.setProp("PagBarEmptyFilteredGridCaption", "Pagbaremptyfilteredgridcaption", "WWP_PaginationBarEmptyFilteredGridCaption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   WWPUTILITIES_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(WWPUTILITIES_MPAGEContainer);
   this.WWPDATEPICKER_MPAGEContainer = gx.uc.getNew(this, 21, 0, "WWP_DatePicker_UC", "WWPDATEPICKER_MPAGEContainer", "Wwpdatepicker", "WWPDATEPICKER_MPAGE");
   var WWPDATEPICKER_MPAGEContainer = this.WWPDATEPICKER_MPAGEContainer;
   WWPDATEPICKER_MPAGEContainer.setProp("Class", "Class", "", "char");
   WWPDATEPICKER_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   WWPDATEPICKER_MPAGEContainer.setProp("MinYear", "Minyear", 1970, "num");
   WWPDATEPICKER_MPAGEContainer.setProp("MaxYear", "Maxyear", 2040, "num");
   WWPDATEPICKER_MPAGEContainer.setProp("Style", "Style", "Light", "str");
   WWPDATEPICKER_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   WWPDATEPICKER_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   WWPDATEPICKER_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(WWPDATEPICKER_MPAGEContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};
   GXValidFnc[25]={ id:25 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Pickerdummyvariable,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPICKERDUMMYVARIABLE_MPAGE",gxz:"ZV5PickerDummyVariable",gxold:"OV5PickerDummyVariable",gxvar:"AV5PickerDummyVariable",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[25],ip:[25],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV5PickerDummyVariable=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV5PickerDummyVariable=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("vPICKERDUMMYVARIABLE_MPAGE",gx.O.AV5PickerDummyVariable,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV5PickerDummyVariable=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("vPICKERDUMMYVARIABLE_MPAGE")},nac:gx.falseFn};
   this.AV5PickerDummyVariable = gx.date.nullDate() ;
   this.Events = {"e130h2_client": ["ENTER_MPAGE", true] ,"e140h2_client": ["CANCEL_MPAGE", true]};
   this.EvtParms["REFRESH_MPAGE"] = [[],[]];
   this.EvtParms["START_MPAGE"] = [[],[{av:'gx.fn.getCtrlProperty("LAYOUTMAINTABLE_MPAGE","Class")',ctrl:'LAYOUTMAINTABLE_MPAGE',prop:'Class'}]];
   this.EvtParms["VALIDV_PICKERDUMMYVARIABLE"] = [[],[]];
   this.Initialize( );
});
gx.wi( function() { gx.createMasterPage(wwpbaseobjects.workwithplusmasterpageprompt);});
