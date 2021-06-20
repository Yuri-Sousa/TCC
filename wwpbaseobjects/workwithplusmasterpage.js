gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.workwithplusmasterpage', false, function () {
   this.ServerClass =  "wwpbaseobjects.workwithplusmasterpage" ;
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
      this.AV15ProgramDescription=gx.fn.getControlValue("vPROGRAMDESCRIPTION_MPAGE") ;
      this.AV27DVelop_Menu=gx.fn.getControlValue("vDVELOP_MENU_MPAGE") ;
      this.AV14IndexToAddItems=gx.fn.getIntegerValue("vINDEXTOADDITEMS_MPAGE",'.') ;
      this.AV17NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO_MPAGE") ;
      this.A1WWPUserExtendedId=gx.fn.getControlValue("WWPUSEREXTENDEDID_MPAGE") ;
      this.AV39Udparg1=gx.fn.getControlValue("vUDPARG1_MPAGE") ;
      this.A73WWPNotificationIsRead=gx.fn.getControlValue("WWPNOTIFICATIONISREAD_MPAGE") ;
      this.AV17NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO_MPAGE") ;
   };
   this.Validv_Pickerdummyvariable=function()
   {
      return this.validCliEvt("Validv_Pickerdummyvariable", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("vPICKERDUMMYVARIABLE_MPAGE");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.AV35PickerDummyVariable)===0) || new gx.date.gxdate( this.AV35PickerDummyVariable ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
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
   this.e182c1_client=function()
   {
      this.clearMessages();
      if ( gx.text.compare( this.DDO_BOOKMARKS_MPAGEContainer.ActiveEventKey , "Bookmark" ) == 0 )
      {
         this.s122_client();
      }
      if ( gx.text.compare( this.DDO_BOOKMARKS_MPAGEContainer.ActiveEventKey , "AddBookmark" ) == 0 )
      {
         this.BOOKMARK_MODAL_MPAGEContainer.Confirm() ;
      }
      else if ( gx.text.compare( this.DDO_BOOKMARKS_MPAGEContainer.ActiveEventKey , "ManageBookmarks" ) == 0 )
      {
         this.popupOpenUrl(gx.http.formatLink("wwpbaseobjects.managefilters.aspx",["AppBookmarks"]), []);
      }
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.s122_client=function()
   {
      this.BOOKMARK_MODAL_MPAGEContainer.Confirm() ;
   };
   this.e192c1_client=function()
   {
      this.clearMessages();
      this.createWebComponent('Wwpaux_wc','WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC',[]);
      this.refreshOutputs([{ctrl:'WWPAUX_WC_MPAGE'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e202c1_client=function()
   {
      this.clearMessages();
      this.createWebComponent('Wwpaux_wc','WWPBaseObjects.WWP_MasterPageTopActionsWC',[]);
      this.refreshOutputs([{ctrl:'WWPAUX_WC_MPAGE'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e122c2_client=function()
   {
      return this.executeServerEvent("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE", false, null, true, true);
   };
   this.e112c2_client=function()
   {
      return this.executeServerEvent("BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE", false, null, true, true);
   };
   this.e142c2_client=function()
   {
      return this.executeServerEvent("ONMESSAGE_GX1_MPAGE", true, null, true, false);
   };
   this.e162c2_client=function()
   {
      return this.executeServerEvent("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE", true, null, true, true);
   };
   this.e212c2_client=function()
   {
      return this.executeServerEvent("ENTER_MPAGE", true, null, false, false);
   };
   this.e222c2_client=function()
   {
      return this.executeServerEvent("CANCEL_MPAGE", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,14,15,16,18,20,22,23,24,25,26,27,28,29,31,32,33,34,35,36,37,39,40,42,43,45,46,48,49,50,51,52,54,55,56,57,58,63];
   this.GXLastCtrlId =63;
   this.UCMENU_MPAGEContainer = gx.uc.getNew(this, 13, 0, "DVelop_DVHorizontalMenu", "UCMENU_MPAGEContainer", "Ucmenu", "UCMENU_MPAGE");
   var UCMENU_MPAGEContainer = this.UCMENU_MPAGEContainer;
   UCMENU_MPAGEContainer.setProp("Class", "Class", "", "char");
   UCMENU_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCMENU_MPAGEContainer.setProp("Cls", "Cls", "HorizontalBorderColor", "str");
   UCMENU_MPAGEContainer.addV2CFunction('AV27DVelop_Menu', "vDVELOP_MENU_MPAGE", 'SetMenu');
   UCMENU_MPAGEContainer.addC2VFunction(function(UC) { UC.ParentObject.AV27DVelop_Menu=UC.GetMenu();gx.fn.setControlValue("vDVELOP_MENU_MPAGE",UC.ParentObject.AV27DVelop_Menu); });
   UCMENU_MPAGEContainer.setProp("CollapsedTitle", "Collapsedtitle", "Y-Track", "str");
   UCMENU_MPAGEContainer.setProp("ResizeWidth", "Resizewidth", "767", "str");
   UCMENU_MPAGEContainer.setProp("Code", "Code", "", "char");
   UCMENU_MPAGEContainer.setProp("MenuType", "Menutype", "Regular", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionEnabled", "Moreoptionenabled", true, "bool");
   UCMENU_MPAGEContainer.setProp("MoreOptionType", "Moreoptiontype", "Slider", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionCaption", "Moreoptioncaption", "WWP_More", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionIcon", "Moreoptionicon", "fa fa-bars", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionShowIconsOnInnerOptions", "Moreoptionshowiconsoninneroptions", false, "bool");
   UCMENU_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   UCMENU_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCMENU_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCMENU_MPAGEContainer);
   this.DDO_BOOKMARKS_MPAGEContainer = gx.uc.getNew(this, 17, 0, "BootstrapDropDownOptions", "DDO_BOOKMARKS_MPAGEContainer", "Ddo_bookmarks", "DDO_BOOKMARKS_MPAGE");
   var DDO_BOOKMARKS_MPAGEContainer = this.DDO_BOOKMARKS_MPAGEContainer;
   DDO_BOOKMARKS_MPAGEContainer.setProp("Class", "Class", "", "char");
   DDO_BOOKMARKS_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   DDO_BOOKMARKS_MPAGEContainer.setProp("IconType", "Icontype", "FontIcon", "str");
   DDO_BOOKMARKS_MPAGEContainer.setProp("Icon", "Icon", "far fa-star HorizontalBorderColorActionGroupOnlyIcon", "str");
   DDO_BOOKMARKS_MPAGEContainer.setProp("Caption", "Caption", "", "str");
   DDO_BOOKMARKS_MPAGEContainer.setDynProp("Tooltip", "Tooltip", "", "str");
   DDO_BOOKMARKS_MPAGEContainer.setProp("Cls", "Cls", "HorizontalBorderColorActionGroupHeader", "str");
   DDO_BOOKMARKS_MPAGEContainer.setProp("ActiveEventKey", "Activeeventkey", "", "char");
   DDO_BOOKMARKS_MPAGEContainer.setDynProp("TitleControlAlign", "Titlecontrolalign", "Automatic", "str");
   DDO_BOOKMARKS_MPAGEContainer.setProp("DropDownOptionsType", "Dropdownoptionstype", "Regular", "str");
   DDO_BOOKMARKS_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   DDO_BOOKMARKS_MPAGEContainer.setProp("TitleControlIdToReplace", "Titlecontrolidtoreplace", "", "str");
   DDO_BOOKMARKS_MPAGEContainer.addV2CFunction('AV9BookmarksData', "vBOOKMARKSDATA_MPAGE", 'SetDropDownOptionsData');
   DDO_BOOKMARKS_MPAGEContainer.addC2VFunction(function(UC) { UC.ParentObject.AV9BookmarksData=UC.GetDropDownOptionsData();gx.fn.setControlValue("vBOOKMARKSDATA_MPAGE",UC.ParentObject.AV9BookmarksData); });
   DDO_BOOKMARKS_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   DDO_BOOKMARKS_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   DDO_BOOKMARKS_MPAGEContainer.addEventHandler("OnOptionClicked", this.e182c1_client);
   this.setUserControl(DDO_BOOKMARKS_MPAGEContainer);
   this.DDC_NOTIFICATIONSWC_MPAGEContainer = gx.uc.getNew(this, 19, 0, "BootstrapDropDownOptions", "DDC_NOTIFICATIONSWC_MPAGEContainer", "Ddc_notificationswc", "DDC_NOTIFICATIONSWC_MPAGE");
   var DDC_NOTIFICATIONSWC_MPAGEContainer = this.DDC_NOTIFICATIONSWC_MPAGEContainer;
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Class", "Class", "", "char");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("IconType", "Icontype", "FontIcon", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Icon", "Icon", "far fa-bell HorizontalBorderColorActionGroupOnlyIcon", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Caption", "Caption", "999", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Tooltip", "Tooltip", "", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Cls", "Cls", "DropDownNotification HorizontalBorderColorActionGroupHeader", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("ComponentWidth", "Componentwidth", 400, "num");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("TitleControlAlign", "Titlecontrolalign", "Automatic", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("DropDownOptionsType", "Dropdownoptionstype", "Component", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("TitleControlIdToReplace", "Titlecontrolidtoreplace", "", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("ShowLoading", "Showloading", true, "bool");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Load", "Load", "OnEveryClick", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("KeepOpened", "Keepopened", false, "bool");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Trigger", "Trigger", "Click", "str");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   DDC_NOTIFICATIONSWC_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   DDC_NOTIFICATIONSWC_MPAGEContainer.addEventHandler("OnLoadComponent", this.e192c1_client);
   this.setUserControl(DDC_NOTIFICATIONSWC_MPAGEContainer);
   this.DDC_ADMINAG_MPAGEContainer = gx.uc.getNew(this, 21, 0, "BootstrapDropDownOptions", "DDC_ADMINAG_MPAGEContainer", "Ddc_adminag", "DDC_ADMINAG_MPAGE");
   var DDC_ADMINAG_MPAGEContainer = this.DDC_ADMINAG_MPAGEContainer;
   DDC_ADMINAG_MPAGEContainer.setProp("Class", "Class", "", "char");
   DDC_ADMINAG_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   DDC_ADMINAG_MPAGEContainer.setProp("IconType", "Icontype", "FontIcon", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("Icon", "Icon", "fas fa-user-circle HorizontalBorderColorUserIcon ", "str");
   DDC_ADMINAG_MPAGEContainer.setDynProp("Caption", "Caption", "Administrator", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("Tooltip", "Tooltip", "", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("Cls", "Cls", "HorizontalBorderColorActionGroupHeader", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("ComponentWidth", "Componentwidth", 200, "num");
   DDC_ADMINAG_MPAGEContainer.setProp("TitleControlAlign", "Titlecontrolalign", "Automatic", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("DropDownOptionsType", "Dropdownoptionstype", "Component", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   DDC_ADMINAG_MPAGEContainer.setProp("TitleControlIdToReplace", "Titlecontrolidtoreplace", "", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("ShowLoading", "Showloading", true, "bool");
   DDC_ADMINAG_MPAGEContainer.setProp("Load", "Load", "OnEveryClick", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("KeepOpened", "Keepopened", false, "bool");
   DDC_ADMINAG_MPAGEContainer.setProp("Trigger", "Trigger", "Click", "str");
   DDC_ADMINAG_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   DDC_ADMINAG_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   DDC_ADMINAG_MPAGEContainer.addEventHandler("OnLoadComponent", this.e202c1_client);
   this.setUserControl(DDC_ADMINAG_MPAGEContainer);
   this.UCMESSAGE_MPAGEContainer = gx.uc.getNew(this, 38, 0, "DVelop_DVMessage", "UCMESSAGE_MPAGEContainer", "Ucmessage", "UCMESSAGE_MPAGE");
   var UCMESSAGE_MPAGEContainer = this.UCMESSAGE_MPAGEContainer;
   UCMESSAGE_MPAGEContainer.setProp("Class", "Class", "", "char");
   UCMESSAGE_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCMESSAGE_MPAGEContainer.setProp("Width", "Width", "300", "str");
   UCMESSAGE_MPAGEContainer.setProp("MinHeight", "Minheight", "16", "str");
   UCMESSAGE_MPAGEContainer.setProp("StylingType", "Stylingtype", "fontawesome", "str");
   UCMESSAGE_MPAGEContainer.setProp("DefaultMessageType", "Defaultmessagetype", "notice", "str");
   UCMESSAGE_MPAGEContainer.setProp("StopOnError", "Stoponerror", true, "bool");
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
   this.UCTOOLTIP_MPAGEContainer = gx.uc.getNew(this, 41, 0, "BootstrapTooltip", "UCTOOLTIP_MPAGEContainer", "Uctooltip", "UCTOOLTIP_MPAGE");
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
   this.WWPUTILITIES_MPAGEContainer = gx.uc.getNew(this, 44, 0, "DVelop_WorkWithPlusUtilities", "WWPUTILITIES_MPAGEContainer", "Wwputilities", "WWPUTILITIES_MPAGE");
   var WWPUTILITIES_MPAGEContainer = this.WWPUTILITIES_MPAGEContainer;
   WWPUTILITIES_MPAGEContainer.setProp("Class", "Class", "", "char");
   WWPUTILITIES_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   WWPUTILITIES_MPAGEContainer.setProp("EnableAutoUpdateFromDocumentTitle", "Enableautoupdatefromdocumenttitle", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableFixObjectFitCover", "Enablefixobjectfitcover", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableFloatingLabels", "Enablefloatinglabels", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EmpowerTabs", "Empowertabs", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableUpdateRowSelectionStatus", "Enableupdaterowselectionstatus", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("CurrentTab_ReturnUrl", "Currenttab_returnurl", "", "char");
   WWPUTILITIES_MPAGEContainer.setProp("EnableConvertComboToBootstrapSelect", "Enableconvertcombotobootstrapselect", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnResizing", "Allowcolumnresizing", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnReordering", "Allowcolumnreordering", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnDragging", "Allowcolumndragging", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnsRestore", "Allowcolumnsrestore", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("RestoreColumnsIconClass", "Restorecolumnsiconclass", "fas fa-undo", "str");
   WWPUTILITIES_MPAGEContainer.setProp("PagBarIncludeGoTo", "Pagbarincludegoto", true, "bool");
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
   this.WWPDATEPICKER_MPAGEContainer = gx.uc.getNew(this, 47, 0, "WWP_DatePicker_UC", "WWPDATEPICKER_MPAGEContainer", "Wwpdatepicker", "WWPDATEPICKER_MPAGE");
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
   this.LOADER1_MPAGEContainer = gx.uc.getNew(this, 53, 0, "Loader", "LOADER1_MPAGEContainer", "Loader1", "LOADER1_MPAGE");
   var LOADER1_MPAGEContainer = this.LOADER1_MPAGEContainer;
   LOADER1_MPAGEContainer.setProp("Class", "Class", "", "char");
   LOADER1_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   LOADER1_MPAGEContainer.setProp("Loader", "Loader", "2", "str");
   LOADER1_MPAGEContainer.setProp("BaseColor", "Basecolor", gx.color.fromRGB(8,160,134), "color");
   LOADER1_MPAGEContainer.setProp("Size", "Size", "100px", "str");
   LOADER1_MPAGEContainer.setProp("Image", "Image", "", "str");
   LOADER1_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   LOADER1_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   LOADER1_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(LOADER1_MPAGEContainer);
   this.BOOKMARK_MODAL_MPAGEContainer = gx.uc.getNew(this, 61, 57, "BootstrapConfirmPanel", "BOOKMARK_MODAL_MPAGEContainer", "Bookmark_modal", "BOOKMARK_MODAL_MPAGE");
   var BOOKMARK_MODAL_MPAGEContainer = this.BOOKMARK_MODAL_MPAGEContainer;
   BOOKMARK_MODAL_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   BOOKMARK_MODAL_MPAGEContainer.setProp("Width", "Width", "735", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("Height", "Height", "100", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("Class", "Class", "", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("Title", "Title", "Add/Edit Bookmark", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("ConfirmationText", "Confirmationtext", "", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("YesButtonCaption", "Yesbuttoncaption", "", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("NoButtonCaption", "Nobuttoncaption", "", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("CancelButtonCaption", "Cancelbuttoncaption", "", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("YesButtonPosition", "Yesbuttonposition", "right", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("ConfirmType", "Confirmtype", "", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("Comment", "Comment", "No", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("BodyType", "Bodytype", "WebComponent", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("BodyContentInternalName", "Bodycontentinternalname", "", "char");
   BOOKMARK_MODAL_MPAGEContainer.setProp("Result", "Result", "", "char");
   BOOKMARK_MODAL_MPAGEContainer.setProp("TextType", "Texttype", "1", "str");
   BOOKMARK_MODAL_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   BOOKMARK_MODAL_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   BOOKMARK_MODAL_MPAGEContainer.addEventHandler("Close", this.e112c2_client);
   BOOKMARK_MODAL_MPAGEContainer.addEventHandler("OnLoadComponent", this.e122c2_client);
   this.setUserControl(BOOKMARK_MODAL_MPAGEContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"TABLEHEADER",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"HEADER",grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"TABLEUSERROLE",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"TABLECONTENT",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"TEXTBLOCKTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"TABLEFOOTER",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"TEXTBLOCKFOOTER", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"UCLOADER",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};
   GXValidFnc[57]={ id:57 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Pickerdummyvariable,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPICKERDUMMYVARIABLE_MPAGE",gxz:"ZV35PickerDummyVariable",gxold:"OV35PickerDummyVariable",gxvar:"AV35PickerDummyVariable",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[57],ip:[57],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV35PickerDummyVariable=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV35PickerDummyVariable=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("vPICKERDUMMYVARIABLE_MPAGE",gx.O.AV35PickerDummyVariable,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV35PickerDummyVariable=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("vPICKERDUMMYVARIABLE_MPAGE")},nac:gx.falseFn};
   GXValidFnc[58]={ id: 58, fld:"TABLEBOOKMARK_MODAL",grid:0};
   GXValidFnc[63]={ id: 63, fld:"DIV_WWPAUXWC",grid:0};
   this.AV35PickerDummyVariable = gx.date.nullDate() ;
   this.ZV35PickerDummyVariable = gx.date.nullDate() ;
   this.OV35PickerDummyVariable = gx.date.nullDate() ;
   this.AV27DVelop_Menu = [ ] ;
   this.AV9BookmarksData = [ ] ;
   this.AV35PickerDummyVariable = gx.date.nullDate() ;
   this.A73WWPNotificationIsRead = false ;
   this.A1WWPUserExtendedId = "" ;
   this.AV32Httprequest = {} ;
   this.AV15ProgramDescription = "" ;
   this.AV14IndexToAddItems = 0 ;
   this.AV17NotificationInfo = {Id:"",Object:"",Message:""} ;
   this.AV39Udparg1 = "" ;
   this.addOnMessage('', "e142c2_client", [["GeneXus\Server\NotificationInfo","vNOTIFICATIONINFO_MPAGE","AV17NotificationInfo"]], this.e142c2_client);
   this.Events = {"e122c2_client": ["BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE", true] ,"e112c2_client": ["BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE", true] ,"e142c2_client": ["ONMESSAGE_GX1_MPAGE", true] ,"e162c2_client": ["GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE", true] ,"e212c2_client": ["ENTER_MPAGE", true] ,"e222c2_client": ["CANCEL_MPAGE", true] ,"e182c1_client": ["DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE", false] ,"e192c1_client": ["DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE", false] ,"e202c1_client": ["DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE", false]};
   this.EvtParms["REFRESH_MPAGE"] = [[{ctrl:'FORM_MPAGE',prop:'Caption'},{av:'this.AV32Httprequest.Baseurl',ctrl:'vHTTPREQUEST_MPAGE',prop:'Baseurl'},{av:'AV27DVelop_Menu',fld:'vDVELOP_MENU_MPAGE',pic:''},{av:'AV15ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true},{av:'AV14IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true}],[{av:'gx.fn.getCtrlProperty("TEXTBLOCKTITLE_MPAGE","Caption")',ctrl:'TEXTBLOCKTITLE_MPAGE',prop:'Caption'},{av:'AV9BookmarksData',fld:'vBOOKMARKSDATA_MPAGE',pic:''},{av:'AV15ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true},{av:'AV14IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true}]];
   this.EvtParms["START_MPAGE"] = [[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID_MPAGE',pic:''},{av:'AV39Udparg1',fld:'vUDPARG1_MPAGE',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD_MPAGE',pic:''},{av:'this.DDC_NOTIFICATIONSWC_MPAGEContainer.Icon',ctrl:'DDC_NOTIFICATIONSWC_MPAGE',prop:'Icon'}],[{ctrl:'FORM_MPAGE',prop:'Headerrawhtml'},{av:'gx.fn.getCtrlProperty("LAYOUTMAINTABLE_MPAGE","Class")',ctrl:'LAYOUTMAINTABLE_MPAGE',prop:'Class'},{av:'AV27DVelop_Menu',fld:'vDVELOP_MENU_MPAGE',pic:''},{av:'AV9BookmarksData',fld:'vBOOKMARKSDATA_MPAGE',pic:''},{av:'this.DDC_ADMINAG_MPAGEContainer.Caption',ctrl:'DDC_ADMINAG_MPAGE',prop:'Caption'},{av:'this.DDO_BOOKMARKS_MPAGEContainer.Tooltip',ctrl:'DDO_BOOKMARKS_MPAGE',prop:'Tooltip'},{av:'this.DDO_BOOKMARKS_MPAGEContainer.TitleControlAlign',ctrl:'DDO_BOOKMARKS_MPAGE',prop:'TitleControlAlign'}]];
   this.EvtParms["DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE"] = [[{av:'this.DDO_BOOKMARKS_MPAGEContainer.ActiveEventKey',ctrl:'DDO_BOOKMARKS_MPAGE',prop:'ActiveEventKey'}],[]];
   this.EvtParms["BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE"] = [[{av:'this.AV32Httprequest.Baseurl',ctrl:'vHTTPREQUEST_MPAGE',prop:'Baseurl'},{av:'AV15ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true}],[{ctrl:'WWPAUX_WC_MPAGE'}]];
   this.EvtParms["BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE"] = [[],[]];
   this.EvtParms["DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE"] = [[],[{ctrl:'WWPAUX_WC_MPAGE'}]];
   this.EvtParms["DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE"] = [[],[{ctrl:'WWPAUX_WC_MPAGE'}]];
   this.EvtParms["GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE"] = [[],[]];
   this.addExoEventHandler("Master_RefreshHeader", this.e162c2_client);
   this.EvtParms["ONMESSAGE_GX1_MPAGE"] = [[{av:'AV17NotificationInfo',fld:'vNOTIFICATIONINFO_MPAGE',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID_MPAGE',pic:''},{av:'AV39Udparg1',fld:'vUDPARG1_MPAGE',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD_MPAGE',pic:''},{av:'this.DDC_NOTIFICATIONSWC_MPAGEContainer.Icon',ctrl:'DDC_NOTIFICATIONSWC_MPAGE',prop:'Icon'}],[]];
   this.EvtParms["VALIDV_PICKERDUMMYVARIABLE"] = [[],[]];
   this.setVCMap("AV15ProgramDescription", "vPROGRAMDESCRIPTION_MPAGE", 0, "svchar", 1000, 0);
   this.setVCMap("AV27DVelop_Menu", "vDVELOP_MENU_MPAGE", 0, "CollWWPBaseObjects\DVelop_Menu.Item", 0, 0);
   this.setVCMap("AV14IndexToAddItems", "vINDEXTOADDITEMS_MPAGE", 0, "int", 4, 0);
   this.setVCMap("AV17NotificationInfo", "vNOTIFICATIONINFO_MPAGE", 0, "GeneXus\Server\NotificationInfo", 0, 0);
   this.setVCMap("A1WWPUserExtendedId", "WWPUSEREXTENDEDID_MPAGE", 0, "char", 40, 0);
   this.setVCMap("AV39Udparg1", "vUDPARG1_MPAGE", 0, "char", 40, 0);
   this.setVCMap("A73WWPNotificationIsRead", "WWPNOTIFICATIONISREAD_MPAGE", 0, "boolean", 4, 0);
   this.setVCMap("AV17NotificationInfo", "vNOTIFICATIONINFO_MPAGE", 0, "GeneXus\Server\NotificationInfo", 0, 0);
   this.Initialize( );
   this.setComponent({id: "WWPAUX_WC" ,GXClass: null , Prefix: "MPW0064" , lvl: 1 });
});
gx.wi( function() { gx.createMasterPage(wwpbaseobjects.workwithplusmasterpage);});
