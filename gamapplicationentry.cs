using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gamapplicationentry : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamapplicationentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamapplicationentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref long aP1_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV15Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV15Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavMainmenu = new GXCombobox();
         chkavAccessrequirespermission = new GXCheckbox();
         chkavClientaccessuniquebyuser = new GXCheckbox();
         chkavClientallowremoteauth = new GXCheckbox();
         chkavClientallowgetuserroles = new GXCheckbox();
         chkavClientallowgetuseradddata = new GXCheckbox();
         chkavEnvironmentsecureprotocol = new GXCheckbox();
         chkavAutoregisteranomymoususer = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15Id = (long)(NumberUtil.Val( GetPar( "Id"), "."));
                  AssignAttri("", false, "AV15Id", StringUtil.LTrimStr( (decimal)(AV15Id), 12, 0));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "gamapplicationentry_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0V2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202142815511930", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamapplicationentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15Id,12,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0V2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gamapplicationentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15Id,12,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMApplicationEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aplicação" ;
      }

      protected void WB0V0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "Geral", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_Internalname, "Id", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Id), 12, 0, ",", "")), ((edtavId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15Id), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV15Id), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavId_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "right", false, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "Guid", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV14GUID), StringUtil.RTrim( context.localUtil.Format( AV14GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavGuid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV16Name), StringUtil.RTrim( context.localUtil.Format( AV16Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Descrição", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV11Dsc), StringUtil.RTrim( context.localUtil.Format( AV11Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavVersion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVersion_Internalname, "Versão", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVersion_Internalname, StringUtil.RTrim( AV18Version), StringUtil.RTrim( context.localUtil.Format( AV18Version, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVersion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavVersion_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCompany_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCompany_Internalname, "Companhia", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCompany_Internalname, StringUtil.RTrim( AV9Company), StringUtil.RTrim( context.localUtil.Format( AV9Company, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCompany_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCompany_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCopyright_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCopyright_Internalname, "Direitos autorais", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCopyright_Internalname, StringUtil.RTrim( AV10Copyright), StringUtil.RTrim( context.localUtil.Format( AV10Copyright, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCopyright_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCopyright_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavMainmenu_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMainmenu_Internalname, "Menu principal", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMainmenu, cmbavMainmenu_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV36MainMenu), 12, 0)), 1, cmbavMainmenu_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMainmenu.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, "HLP_GAMApplicationEntry.htm");
            cmbavMainmenu.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36MainMenu), 12, 0));
            AssignProp("", false, cmbavMainmenu_Internalname, "Values", (string)(cmbavMainmenu.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavHomeobject_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHomeobject_Internalname, "Objeto de ínicio", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHomeobject_Internalname, AV39HomeObject, StringUtil.RTrim( context.localUtil.Format( AV39HomeObject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHomeobject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavHomeobject_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientlocallogoutobject_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientlocallogoutobject_Internalname, "Objeto local de logout", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientlocallogoutobject_Internalname, AV40ClientLocalLogoutObject, StringUtil.RTrim( context.localUtil.Format( AV40ClientLocalLogoutObject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientlocallogoutobject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientlocallogoutobject_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAccessrequirespermission_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAccessrequirespermission_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAccessrequirespermission_Internalname, StringUtil.BoolToStr( AV5AccessRequiresPermission), "", " ", 1, chkavAccessrequirespermission.Enabled, "true", "Permissões são obrigatórios?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(70, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,70);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblClientapplicationdata_title_Internalname, "Dados do aplicativo cliente", "", "", lblClientapplicationdata_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "ClientApplicationData") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientid_Internalname, "Id do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientid_Internalname, StringUtil.RTrim( AV7ClientId), StringUtil.RTrim( context.localUtil.Format( AV7ClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMClientApplicationId", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientsecret_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientsecret_Internalname, "Segredo do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientsecret_Internalname, StringUtil.RTrim( AV8ClientSecret), StringUtil.RTrim( context.localUtil.Format( AV8ClientSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientsecret_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientsecret_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMClientApplicationSecret", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavClientaccessuniquebyuser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientaccessuniquebyuser_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientaccessuniquebyuser_Internalname, StringUtil.BoolToStr( AV34ClientAccessUniqueByUser), "", " ", 1, chkavClientaccessuniquebyuser.Enabled, "true", "O acesso de usuário é único?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclientrevoked_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockclientrevoked_Internalname, "Revogada", "", "", lblTextblockclientrevoked_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_96_0V2( true) ;
         }
         else
         {
            wb_table1_96_0V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_96_0V2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRemoteauthentication_title_Internalname, "Autenticação remota", "", "", lblRemoteauthentication_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "RemoteAuthentication") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavClientallowremoteauth_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowremoteauth_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowremoteauth_Internalname, StringUtil.BoolToStr( AV31ClientAllowRemoteAuth), "", " ", 1, chkavClientallowremoteauth.Enabled, "true", "Permitir autenticação remota?", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientallowgetuserroles_cell_Internalname, 1, 0, "px", 0, "px", divClientallowgetuserroles_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavClientallowgetuserroles.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetuserroles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuserroles_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuserroles_Internalname, StringUtil.BoolToStr( AV32ClientAllowGetUserRoles), "", " ", chkavClientallowgetuserroles.Visible, chkavClientallowgetuserroles.Enabled, "true", "Você pode obter funções de usuário?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(116, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,116);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientallowgetuseradddata_cell_Internalname, 1, 0, "px", 0, "px", divClientallowgetuseradddata_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavClientallowgetuseradddata.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavClientallowgetuseradddata_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuseradddata_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuseradddata_Internalname, StringUtil.BoolToStr( AV42ClientAllowGetUserAddData), "", " ", chkavClientallowgetuseradddata.Visible, chkavClientallowgetuseradddata.Enabled, "true", "Você pode obter dados adicionais dos usuários?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(121, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,121);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientlocalloginurl_cell_Internalname, 1, 0, "px", 0, "px", divClientlocalloginurl_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavClientlocalloginurl_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientlocalloginurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientlocalloginurl_Internalname, "Url local de login", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientlocalloginurl_Internalname, AV21ClientLocalLoginURL, StringUtil.RTrim( context.localUtil.Format( AV21ClientLocalLoginURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientlocalloginurl_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientlocalloginurl_Visible, edtavClientlocalloginurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientcallbackurl_cell_Internalname, 1, 0, "px", 0, "px", divClientcallbackurl_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavClientcallbackurl_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientcallbackurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientcallbackurl_Internalname, "Url de retorno", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientcallbackurl_Internalname, AV22ClientCallbackURL, StringUtil.RTrim( context.localUtil.Format( AV22ClientCallbackURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientcallbackurl_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientcallbackurl_Visible, edtavClientcallbackurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientimageurl_cell_Internalname, 1, 0, "px", 0, "px", divClientimageurl_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavClientimageurl_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientimageurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientimageurl_Internalname, "URL da imagem	", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientimageurl_Internalname, AV23ClientImageURL, StringUtil.RTrim( context.localUtil.Format( AV23ClientImageURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientimageurl_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientimageurl_Visible, edtavClientimageurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclientencryptionkey_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblockclientencryptionkey_cell_Internalname, 1, 0, "px", 0, "px", divTextblockclientencryptionkey_cell_Class, "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockclientencryptionkey_Internalname, "Chave privada de criptografia", "", "", lblTextblockclientencryptionkey_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_142_0V2( true) ;
         }
         else
         {
            wb_table2_142_0V2( false) ;
         }
         return  ;
      }

      protected void wb_table2_142_0V2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientrepositoryguid_cell_Internalname, 1, 0, "px", 0, "px", divClientrepositoryguid_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavClientrepositoryguid_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientrepositoryguid_Internalname, "Guid do repositório", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientrepositoryguid_Internalname, StringUtil.RTrim( AV41ClientRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV41ClientRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientrepositoryguid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", edtavClientrepositoryguid_Visible, edtavClientrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnvironmentsettings_title_Internalname, "Configurações de ambiente", "", "", lblEnvironmentsettings_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "EnvironmentSettings") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentname_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentname_Internalname, StringUtil.RTrim( AV24EnvironmentName), StringUtil.RTrim( context.localUtil.Format( AV24EnvironmentName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavEnvironmentsecureprotocol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEnvironmentsecureprotocol_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEnvironmentsecureprotocol_Internalname, StringUtil.BoolToStr( AV26EnvironmentSecureProtocol), "", " ", 1, chkavEnvironmentsecureprotocol.Enabled, "true", "É https?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(166, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,166);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEnvironmenthost_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmenthost_Internalname, "Host", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmenthost_Internalname, StringUtil.RTrim( AV27EnvironmentHost), StringUtil.RTrim( context.localUtil.Format( AV27EnvironmentHost, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmenthost_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmenthost_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentport_Internalname, "Porto", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28EnvironmentPort), 5, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV28EnvironmentPort), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,175);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentport_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentport_Enabled, 1, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentvirtualdirectory_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentvirtualdirectory_Internalname, "Diretório virtual", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentvirtualdirectory_Internalname, StringUtil.RTrim( AV25EnvironmentVirtualDirectory), StringUtil.RTrim( context.localUtil.Format( AV25EnvironmentVirtualDirectory, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentvirtualdirectory_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentvirtualdirectory_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentprogrampackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentprogrampackage_Internalname, "Pacote", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentprogrampackage_Internalname, StringUtil.RTrim( AV29EnvironmentProgramPackage), StringUtil.RTrim( context.localUtil.Format( AV29EnvironmentProgramPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentprogrampackage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentprogrampackage_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEnvironmentprogramextension_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentprogramextension_Internalname, "Extensão", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentprogramextension_Internalname, StringUtil.RTrim( AV30EnvironmentProgramExtension), StringUtil.RTrim( context.localUtil.Format( AV30EnvironmentProgramExtension, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentprogramextension_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentprogramextension_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAutoregisteranomymoususer_Internalname, StringUtil.BoolToStr( AV19AutoRegisterAnomymousUser), "", "", chkavAutoregisteranomymoususer.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(200, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,200);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148565", 0) ;
            }
            Form.Meta.addItem("description", "Aplicação", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0V0( ) ;
      }

      protected void WS0V2( )
      {
         START0V2( ) ;
         EVT0V2( ) ;
      }

      protected void EVT0V2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGENERATEKEYGAMREMOTE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoGenerateKeyGAMRemote' */
                              E120V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREVOKEALLOW'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoRevokeAllow' */
                              E130V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E140V2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E150V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CLOSE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Close' */
                              E160V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E170V2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0V2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavGuid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavMainmenu.ItemCount > 0 )
         {
            AV36MainMenu = (long)(NumberUtil.Val( cmbavMainmenu.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV36MainMenu), 12, 0))), "."));
            AssignAttri("", false, "AV36MainMenu", StringUtil.LTrimStr( (decimal)(AV36MainMenu), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMainmenu.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36MainMenu), 12, 0));
            AssignProp("", false, cmbavMainmenu_Internalname, "Values", cmbavMainmenu.ToJavascriptSource(), true);
         }
         AV5AccessRequiresPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV5AccessRequiresPermission));
         AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
         AV34ClientAccessUniqueByUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV34ClientAccessUniqueByUser));
         AssignAttri("", false, "AV34ClientAccessUniqueByUser", AV34ClientAccessUniqueByUser);
         AV31ClientAllowRemoteAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV31ClientAllowRemoteAuth));
         AssignAttri("", false, "AV31ClientAllowRemoteAuth", AV31ClientAllowRemoteAuth);
         AV32ClientAllowGetUserRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV32ClientAllowGetUserRoles));
         AssignAttri("", false, "AV32ClientAllowGetUserRoles", AV32ClientAllowGetUserRoles);
         AV42ClientAllowGetUserAddData = StringUtil.StrToBool( StringUtil.BoolToStr( AV42ClientAllowGetUserAddData));
         AssignAttri("", false, "AV42ClientAllowGetUserAddData", AV42ClientAllowGetUserAddData);
         AV26EnvironmentSecureProtocol = StringUtil.StrToBool( StringUtil.BoolToStr( AV26EnvironmentSecureProtocol));
         AssignAttri("", false, "AV26EnvironmentSecureProtocol", AV26EnvironmentSecureProtocol);
         AV19AutoRegisterAnomymousUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV19AutoRegisterAnomymousUser));
         AssignAttri("", false, "AV19AutoRegisterAnomymousUser", AV19AutoRegisterAnomymousUser);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavClientrevoked_Enabled = 0;
         AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
         edtavClientencryptionkey_Enabled = 0;
         AssignProp("", false, edtavClientencryptionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientencryptionkey_Enabled), 5, 0), true);
         edtavClientrepositoryguid_Enabled = 0;
         AssignProp("", false, edtavClientrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Enabled), 5, 0), true);
      }

      protected void RF0V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E150V2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E170V2 ();
            WB0V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0V2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavClientrevoked_Enabled = 0;
         AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
         edtavClientencryptionkey_Enabled = 0;
         AssignProp("", false, edtavClientencryptionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientencryptionkey_Enabled), 5, 0), true);
         edtavClientrepositoryguid_Enabled = 0;
         AssignProp("", false, edtavClientrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gxuitabspanel_tabs_Pagecount = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), ",", "."));
            Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
            /* Read variables values. */
            AV14GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV14GUID", AV14GUID);
            AV16Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV16Name", AV16Name);
            AV11Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri("", false, "AV11Dsc", AV11Dsc);
            AV18Version = cgiGet( edtavVersion_Internalname);
            AssignAttri("", false, "AV18Version", AV18Version);
            AV9Company = cgiGet( edtavCompany_Internalname);
            AssignAttri("", false, "AV9Company", AV9Company);
            AV10Copyright = cgiGet( edtavCopyright_Internalname);
            AssignAttri("", false, "AV10Copyright", AV10Copyright);
            cmbavMainmenu.CurrentValue = cgiGet( cmbavMainmenu_Internalname);
            AV36MainMenu = (long)(NumberUtil.Val( cgiGet( cmbavMainmenu_Internalname), "."));
            AssignAttri("", false, "AV36MainMenu", StringUtil.LTrimStr( (decimal)(AV36MainMenu), 12, 0));
            AV39HomeObject = cgiGet( edtavHomeobject_Internalname);
            AssignAttri("", false, "AV39HomeObject", AV39HomeObject);
            AV40ClientLocalLogoutObject = cgiGet( edtavClientlocallogoutobject_Internalname);
            AssignAttri("", false, "AV40ClientLocalLogoutObject", AV40ClientLocalLogoutObject);
            AV5AccessRequiresPermission = StringUtil.StrToBool( cgiGet( chkavAccessrequirespermission_Internalname));
            AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
            AV7ClientId = cgiGet( edtavClientid_Internalname);
            AssignAttri("", false, "AV7ClientId", AV7ClientId);
            AV8ClientSecret = cgiGet( edtavClientsecret_Internalname);
            AssignAttri("", false, "AV8ClientSecret", AV8ClientSecret);
            AV34ClientAccessUniqueByUser = StringUtil.StrToBool( cgiGet( chkavClientaccessuniquebyuser_Internalname));
            AssignAttri("", false, "AV34ClientAccessUniqueByUser", AV34ClientAccessUniqueByUser);
            if ( context.localUtil.VCDateTime( cgiGet( edtavClientrevoked_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Client Revoked"}), 1, "vCLIENTREVOKED");
               GX_FocusControl = edtavClientrevoked_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV35ClientRevoked = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV35ClientRevoked", context.localUtil.TToC( AV35ClientRevoked, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV35ClientRevoked = context.localUtil.CToT( cgiGet( edtavClientrevoked_Internalname));
               AssignAttri("", false, "AV35ClientRevoked", context.localUtil.TToC( AV35ClientRevoked, 10, 5, 0, 3, "/", ":", " "));
            }
            AV31ClientAllowRemoteAuth = StringUtil.StrToBool( cgiGet( chkavClientallowremoteauth_Internalname));
            AssignAttri("", false, "AV31ClientAllowRemoteAuth", AV31ClientAllowRemoteAuth);
            AV32ClientAllowGetUserRoles = StringUtil.StrToBool( cgiGet( chkavClientallowgetuserroles_Internalname));
            AssignAttri("", false, "AV32ClientAllowGetUserRoles", AV32ClientAllowGetUserRoles);
            AV42ClientAllowGetUserAddData = StringUtil.StrToBool( cgiGet( chkavClientallowgetuseradddata_Internalname));
            AssignAttri("", false, "AV42ClientAllowGetUserAddData", AV42ClientAllowGetUserAddData);
            AV21ClientLocalLoginURL = cgiGet( edtavClientlocalloginurl_Internalname);
            AssignAttri("", false, "AV21ClientLocalLoginURL", AV21ClientLocalLoginURL);
            AV22ClientCallbackURL = cgiGet( edtavClientcallbackurl_Internalname);
            AssignAttri("", false, "AV22ClientCallbackURL", AV22ClientCallbackURL);
            AV23ClientImageURL = cgiGet( edtavClientimageurl_Internalname);
            AssignAttri("", false, "AV23ClientImageURL", AV23ClientImageURL);
            AV33ClientEncryptionKey = cgiGet( edtavClientencryptionkey_Internalname);
            AssignAttri("", false, "AV33ClientEncryptionKey", AV33ClientEncryptionKey);
            AV41ClientRepositoryGUID = cgiGet( edtavClientrepositoryguid_Internalname);
            AssignAttri("", false, "AV41ClientRepositoryGUID", AV41ClientRepositoryGUID);
            AV24EnvironmentName = cgiGet( edtavEnvironmentname_Internalname);
            AssignAttri("", false, "AV24EnvironmentName", AV24EnvironmentName);
            AV26EnvironmentSecureProtocol = StringUtil.StrToBool( cgiGet( chkavEnvironmentsecureprotocol_Internalname));
            AssignAttri("", false, "AV26EnvironmentSecureProtocol", AV26EnvironmentSecureProtocol);
            AV27EnvironmentHost = cgiGet( edtavEnvironmenthost_Internalname);
            AssignAttri("", false, "AV27EnvironmentHost", AV27EnvironmentHost);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vENVIRONMENTPORT");
               GX_FocusControl = edtavEnvironmentport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28EnvironmentPort = 0;
               AssignAttri("", false, "AV28EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV28EnvironmentPort), 5, 0));
            }
            else
            {
               AV28EnvironmentPort = (int)(context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ",", "."));
               AssignAttri("", false, "AV28EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV28EnvironmentPort), 5, 0));
            }
            AV25EnvironmentVirtualDirectory = cgiGet( edtavEnvironmentvirtualdirectory_Internalname);
            AssignAttri("", false, "AV25EnvironmentVirtualDirectory", AV25EnvironmentVirtualDirectory);
            AV29EnvironmentProgramPackage = cgiGet( edtavEnvironmentprogrampackage_Internalname);
            AssignAttri("", false, "AV29EnvironmentProgramPackage", AV29EnvironmentProgramPackage);
            AV30EnvironmentProgramExtension = cgiGet( edtavEnvironmentprogramextension_Internalname);
            AssignAttri("", false, "AV30EnvironmentProgramExtension", AV30EnvironmentProgramExtension);
            AV19AutoRegisterAnomymousUser = StringUtil.StrToBool( cgiGet( chkavAutoregisteranomymoususer_Internalname));
            AssignAttri("", false, "AV19AutoRegisterAnomymousUser", AV19AutoRegisterAnomymousUser);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110V2 ();
         if (returnInSub) return;
      }

      protected void E110V2( )
      {
         /* Start Routine */
         returnInSub = false;
         chkavAutoregisteranomymoususer.Visible = 0;
         AssignProp("", false, chkavAutoregisteranomymoususer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAutoregisteranomymoususer.Visible), 5, 0), true);
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV6Application.load( AV15Id);
            AV14GUID = AV6Application.gxTpr_Guid;
            AssignAttri("", false, "AV14GUID", AV14GUID);
            AV16Name = AV6Application.gxTpr_Name;
            AssignAttri("", false, "AV16Name", AV16Name);
            AV11Dsc = AV6Application.gxTpr_Description;
            AssignAttri("", false, "AV11Dsc", AV11Dsc);
            AV18Version = AV6Application.gxTpr_Version;
            AssignAttri("", false, "AV18Version", AV18Version);
            AV10Copyright = AV6Application.gxTpr_Copyright;
            AssignAttri("", false, "AV10Copyright", AV10Copyright);
            AV9Company = AV6Application.gxTpr_Companyname;
            AssignAttri("", false, "AV9Company", AV9Company);
            AV52GXV2 = 1;
            AV51GXV1 = AV6Application.getmenus(AV37MenuFilter, out  AV13Errors);
            while ( AV52GXV2 <= AV51GXV1.Count )
            {
               AV38Menu = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV51GXV1.Item(AV52GXV2));
               cmbavMainmenu.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV38Menu.gxTpr_Id), 12, 0)), AV38Menu.gxTpr_Name, 0);
               AV52GXV2 = (int)(AV52GXV2+1);
            }
            AV36MainMenu = AV6Application.gxTpr_Mainmenuid;
            AssignAttri("", false, "AV36MainMenu", StringUtil.LTrimStr( (decimal)(AV36MainMenu), 12, 0));
            AV5AccessRequiresPermission = AV6Application.gxTpr_Accessrequirespermission;
            AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
            AV19AutoRegisterAnomymousUser = AV6Application.gxTpr_Clientautoregisteranomymoususer;
            AssignAttri("", false, "AV19AutoRegisterAnomymousUser", AV19AutoRegisterAnomymousUser);
            AV7ClientId = AV6Application.gxTpr_Clientid;
            AssignAttri("", false, "AV7ClientId", AV7ClientId);
            AV8ClientSecret = AV6Application.gxTpr_Clientsecret;
            AssignAttri("", false, "AV8ClientSecret", AV8ClientSecret);
            AV34ClientAccessUniqueByUser = AV6Application.gxTpr_Clientaccessuniquebyuser;
            AssignAttri("", false, "AV34ClientAccessUniqueByUser", AV34ClientAccessUniqueByUser);
            AV35ClientRevoked = AV6Application.gxTpr_Clientrevoked;
            AssignAttri("", false, "AV35ClientRevoked", context.localUtil.TToC( AV35ClientRevoked, 10, 5, 0, 3, "/", ":", " "));
            AV31ClientAllowRemoteAuth = AV6Application.gxTpr_Clientallowremoteauthentication;
            AssignAttri("", false, "AV31ClientAllowRemoteAuth", AV31ClientAllowRemoteAuth);
            AV32ClientAllowGetUserRoles = AV6Application.gxTpr_Clientallowgetuserroles;
            AssignAttri("", false, "AV32ClientAllowGetUserRoles", AV32ClientAllowGetUserRoles);
            AV42ClientAllowGetUserAddData = AV6Application.gxTpr_Clientallowgetuseradditionaldata;
            AssignAttri("", false, "AV42ClientAllowGetUserAddData", AV42ClientAllowGetUserAddData);
            AV21ClientLocalLoginURL = AV6Application.gxTpr_Clientlocalloginurl;
            AssignAttri("", false, "AV21ClientLocalLoginURL", AV21ClientLocalLoginURL);
            AV22ClientCallbackURL = AV6Application.gxTpr_Clientcallbackurl;
            AssignAttri("", false, "AV22ClientCallbackURL", AV22ClientCallbackURL);
            AV23ClientImageURL = AV6Application.gxTpr_Clientimageurl;
            AssignAttri("", false, "AV23ClientImageURL", AV23ClientImageURL);
            AV33ClientEncryptionKey = AV6Application.gxTpr_Clientencryptionkey;
            AssignAttri("", false, "AV33ClientEncryptionKey", AV33ClientEncryptionKey);
            AV40ClientLocalLogoutObject = AV6Application.gxTpr_Logoutobject;
            AssignAttri("", false, "AV40ClientLocalLogoutObject", AV40ClientLocalLogoutObject);
            AV39HomeObject = AV6Application.gxTpr_Homeobject;
            AssignAttri("", false, "AV39HomeObject", AV39HomeObject);
            AV41ClientRepositoryGUID = AV6Application.gxTpr_Clientrepositoryguid;
            AssignAttri("", false, "AV41ClientRepositoryGUID", AV41ClientRepositoryGUID);
            AV24EnvironmentName = AV6Application.gxTpr_Environment.gxTpr_Name;
            AssignAttri("", false, "AV24EnvironmentName", AV24EnvironmentName);
            AV26EnvironmentSecureProtocol = AV6Application.gxTpr_Environment.gxTpr_Secureprotocol;
            AssignAttri("", false, "AV26EnvironmentSecureProtocol", AV26EnvironmentSecureProtocol);
            AV27EnvironmentHost = AV6Application.gxTpr_Environment.gxTpr_Host;
            AssignAttri("", false, "AV27EnvironmentHost", AV27EnvironmentHost);
            AV28EnvironmentPort = AV6Application.gxTpr_Environment.gxTpr_Port;
            AssignAttri("", false, "AV28EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV28EnvironmentPort), 5, 0));
            AV25EnvironmentVirtualDirectory = AV6Application.gxTpr_Environment.gxTpr_Virtualdirectory;
            AssignAttri("", false, "AV25EnvironmentVirtualDirectory", AV25EnvironmentVirtualDirectory);
            AV29EnvironmentProgramPackage = AV6Application.gxTpr_Environment.gxTpr_Programpackage;
            AssignAttri("", false, "AV29EnvironmentProgramPackage", AV29EnvironmentProgramPackage);
            AV30EnvironmentProgramExtension = AV6Application.gxTpr_Environment.gxTpr_Programextension;
            AssignAttri("", false, "AV30EnvironmentProgramExtension", AV30EnvironmentProgramExtension);
            if ( (DateTime.MinValue==AV6Application.gxTpr_Clientrevoked) )
            {
               bttBtnrevokeallow_Caption = "Revoke";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
            else
            {
               bttBtnrevokeallow_Caption = "Authorize";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavGuid_Enabled = 0;
            AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavVersion_Enabled = 0;
            AssignProp("", false, edtavVersion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVersion_Enabled), 5, 0), true);
            edtavCopyright_Enabled = 0;
            AssignProp("", false, edtavCopyright_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCopyright_Enabled), 5, 0), true);
            edtavCompany_Enabled = 0;
            AssignProp("", false, edtavCompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCompany_Enabled), 5, 0), true);
            cmbavMainmenu.Enabled = 0;
            AssignProp("", false, cmbavMainmenu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMainmenu.Enabled), 5, 0), true);
            chkavAccessrequirespermission.Enabled = 0;
            AssignProp("", false, chkavAccessrequirespermission_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAccessrequirespermission.Enabled), 5, 0), true);
            edtavClientid_Enabled = 0;
            AssignProp("", false, edtavClientid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientid_Enabled), 5, 0), true);
            edtavClientsecret_Enabled = 0;
            AssignProp("", false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            chkavClientaccessuniquebyuser.Enabled = 0;
            AssignProp("", false, chkavClientaccessuniquebyuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientaccessuniquebyuser.Enabled), 5, 0), true);
            edtavClientrevoked_Enabled = 0;
            AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
            chkavClientallowremoteauth.Enabled = 0;
            AssignProp("", false, chkavClientallowremoteauth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowremoteauth.Enabled), 5, 0), true);
            chkavClientallowgetuserroles.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuserroles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserroles.Enabled), 5, 0), true);
            chkavClientallowgetuseradddata.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuseradddata.Enabled), 5, 0), true);
            edtavClientlocalloginurl_Enabled = 0;
            AssignProp("", false, edtavClientlocalloginurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientlocalloginurl_Enabled), 5, 0), true);
            edtavClientcallbackurl_Enabled = 0;
            AssignProp("", false, edtavClientcallbackurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientcallbackurl_Enabled), 5, 0), true);
            edtavClientimageurl_Enabled = 0;
            AssignProp("", false, edtavClientimageurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientimageurl_Enabled), 5, 0), true);
            edtavClientencryptionkey_Enabled = 0;
            AssignProp("", false, edtavClientencryptionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientencryptionkey_Enabled), 5, 0), true);
            edtavClientrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavClientrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Enabled), 5, 0), true);
            edtavHomeobject_Enabled = 0;
            AssignProp("", false, edtavHomeobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomeobject_Enabled), 5, 0), true);
            edtavClientlocallogoutobject_Enabled = 0;
            AssignProp("", false, edtavClientlocallogoutobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientlocallogoutobject_Enabled), 5, 0), true);
            edtavEnvironmentname_Enabled = 0;
            AssignProp("", false, edtavEnvironmentname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentname_Enabled), 5, 0), true);
            chkavEnvironmentsecureprotocol.Enabled = 0;
            AssignProp("", false, chkavEnvironmentsecureprotocol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEnvironmentsecureprotocol.Enabled), 5, 0), true);
            edtavEnvironmenthost_Enabled = 0;
            AssignProp("", false, edtavEnvironmenthost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmenthost_Enabled), 5, 0), true);
            edtavEnvironmentport_Enabled = 0;
            AssignProp("", false, edtavEnvironmentport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentport_Enabled), 5, 0), true);
            edtavEnvironmentvirtualdirectory_Enabled = 0;
            AssignProp("", false, edtavEnvironmentvirtualdirectory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentvirtualdirectory_Enabled), 5, 0), true);
            edtavEnvironmentprogrampackage_Enabled = 0;
            AssignProp("", false, edtavEnvironmentprogrampackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogrampackage_Enabled), 5, 0), true);
            edtavEnvironmentprogramextension_Enabled = 0;
            AssignProp("", false, edtavEnvironmentprogramextension_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogramextension_Enabled), 5, 0), true);
            bttBtngeneratekeygamremote_Visible = 0;
            AssignProp("", false, bttBtngeneratekeygamremote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngeneratekeygamremote_Visible), 5, 0), true);
            bttBtnenter_Caption = "Delete";
            AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         chkavAutoregisteranomymoususer.Visible = 0;
         AssignProp("", false, chkavAutoregisteranomymoususer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAutoregisteranomymoususer.Visible), 5, 0), true);
      }

      protected void E120V2( )
      {
         /* 'DoGenerateKeyGAMRemote' Routine */
         returnInSub = false;
         AV33ClientEncryptionKey = Crypto.GetEncryptionKey( );
         AssignAttri("", false, "AV33ClientEncryptionKey", AV33ClientEncryptionKey);
         /*  Sending Event outputs  */
      }

      protected void E130V2( )
      {
         /* 'DoRevokeAllow' Routine */
         returnInSub = false;
         AV6Application.load( AV15Id);
         if ( (DateTime.MinValue==AV6Application.gxTpr_Clientrevoked) )
         {
            AV20isOk = AV6Application.revokeclient(out  AV13Errors);
         }
         else
         {
            AV20isOk = AV6Application.authorizeclient(out  AV13Errors);
         }
         if ( AV20isOk )
         {
            if ( (DateTime.MinValue==AV6Application.gxTpr_Clientrevoked) )
            {
               bttBtnrevokeallow_Caption = "Revoke";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
            else
            {
               bttBtnrevokeallow_Caption = "Authorize";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
            context.CommitDataStores("gamapplicationentry",pr_default);
            context.DoAjaxRefresh();
         }
         else
         {
            /* Execute user subroutine: 'ERRORS' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            chkavClientallowgetuserroles.Visible = 0;
            AssignProp("", false, chkavClientallowgetuserroles_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserroles.Visible), 5, 0), true);
            divClientallowgetuserroles_cell_Class = "Invisible";
            AssignProp("", false, divClientallowgetuserroles_cell_Internalname, "Class", divClientallowgetuserroles_cell_Class, true);
         }
         else
         {
            chkavClientallowgetuserroles.Visible = 1;
            AssignProp("", false, chkavClientallowgetuserroles_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserroles.Visible), 5, 0), true);
            divClientallowgetuserroles_cell_Class = "col-xs-12 col-sm-6 DscTop";
            AssignProp("", false, divClientallowgetuserroles_cell_Internalname, "Class", divClientallowgetuserroles_cell_Class, true);
         }
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            chkavClientallowgetuseradddata.Visible = 0;
            AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuseradddata.Visible), 5, 0), true);
            divClientallowgetuseradddata_cell_Class = "Invisible";
            AssignProp("", false, divClientallowgetuseradddata_cell_Internalname, "Class", divClientallowgetuseradddata_cell_Class, true);
         }
         else
         {
            chkavClientallowgetuseradddata.Visible = 1;
            AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuseradddata.Visible), 5, 0), true);
            divClientallowgetuseradddata_cell_Class = "col-xs-12 col-sm-6 DscTop";
            AssignProp("", false, divClientallowgetuseradddata_cell_Internalname, "Class", divClientallowgetuseradddata_cell_Class, true);
         }
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            edtavClientlocalloginurl_Visible = 0;
            AssignProp("", false, edtavClientlocalloginurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientlocalloginurl_Visible), 5, 0), true);
            divClientlocalloginurl_cell_Class = "Invisible";
            AssignProp("", false, divClientlocalloginurl_cell_Internalname, "Class", divClientlocalloginurl_cell_Class, true);
         }
         else
         {
            edtavClientlocalloginurl_Visible = 1;
            AssignProp("", false, edtavClientlocalloginurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientlocalloginurl_Visible), 5, 0), true);
            divClientlocalloginurl_cell_Class = "col-xs-12 col-sm-6 DscTop";
            AssignProp("", false, divClientlocalloginurl_cell_Internalname, "Class", divClientlocalloginurl_cell_Class, true);
         }
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            edtavClientcallbackurl_Visible = 0;
            AssignProp("", false, edtavClientcallbackurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientcallbackurl_Visible), 5, 0), true);
            divClientcallbackurl_cell_Class = "Invisible";
            AssignProp("", false, divClientcallbackurl_cell_Internalname, "Class", divClientcallbackurl_cell_Class, true);
         }
         else
         {
            edtavClientcallbackurl_Visible = 1;
            AssignProp("", false, edtavClientcallbackurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientcallbackurl_Visible), 5, 0), true);
            divClientcallbackurl_cell_Class = "col-xs-12 col-sm-6 DscTop";
            AssignProp("", false, divClientcallbackurl_cell_Internalname, "Class", divClientcallbackurl_cell_Class, true);
         }
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            edtavClientimageurl_Visible = 0;
            AssignProp("", false, edtavClientimageurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientimageurl_Visible), 5, 0), true);
            divClientimageurl_cell_Class = "Invisible";
            AssignProp("", false, divClientimageurl_cell_Internalname, "Class", divClientimageurl_cell_Class, true);
         }
         else
         {
            edtavClientimageurl_Visible = 1;
            AssignProp("", false, edtavClientimageurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientimageurl_Visible), 5, 0), true);
            divClientimageurl_cell_Class = "col-xs-12 col-sm-6 DscTop";
            AssignProp("", false, divClientimageurl_cell_Internalname, "Class", divClientimageurl_cell_Class, true);
         }
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            edtavClientencryptionkey_Visible = 0;
            AssignProp("", false, edtavClientencryptionkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientencryptionkey_Visible), 5, 0), true);
            cellClientencryptionkey_cell_Class = "Invisible";
            AssignProp("", false, cellClientencryptionkey_cell_Internalname, "Class", cellClientencryptionkey_cell_Class, true);
            divTextblockclientencryptionkey_cell_Class = "Invisible";
            AssignProp("", false, divTextblockclientencryptionkey_cell_Internalname, "Class", divTextblockclientencryptionkey_cell_Class, true);
         }
         else
         {
            edtavClientencryptionkey_Visible = 1;
            AssignProp("", false, edtavClientencryptionkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientencryptionkey_Visible), 5, 0), true);
            cellClientencryptionkey_cell_Class = "MergeDataCell";
            AssignProp("", false, cellClientencryptionkey_cell_Internalname, "Class", cellClientencryptionkey_cell_Class, true);
            divTextblockclientencryptionkey_cell_Class = "col-sm-12 MergeLabelCell";
            AssignProp("", false, divTextblockclientencryptionkey_cell_Internalname, "Class", divTextblockclientencryptionkey_cell_Class, true);
         }
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            edtavClientrepositoryguid_Visible = 0;
            AssignProp("", false, edtavClientrepositoryguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Visible), 5, 0), true);
            divClientrepositoryguid_cell_Class = "Invisible";
            AssignProp("", false, divClientrepositoryguid_cell_Internalname, "Class", divClientrepositoryguid_cell_Class, true);
         }
         else
         {
            edtavClientrepositoryguid_Visible = 1;
            AssignProp("", false, edtavClientrepositoryguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Visible), 5, 0), true);
            divClientrepositoryguid_cell_Class = "col-xs-12 col-sm-6 DscTop";
            AssignProp("", false, divClientrepositoryguid_cell_Internalname, "Class", divClientrepositoryguid_cell_Class, true);
         }
         if ( ! ( AV31ClientAllowRemoteAuth ) )
         {
            bttBtngeneratekeygamremote_Visible = 0;
            AssignProp("", false, bttBtngeneratekeygamremote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngeneratekeygamremote_Visible), 5, 0), true);
         }
         else
         {
            edtavClientrepositoryguid_Visible = 1;
            AssignProp("", false, edtavClientrepositoryguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Visible), 5, 0), true);
            bttBtngeneratekeygamremote_Visible = 1;
            AssignProp("", false, bttBtngeneratekeygamremote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngeneratekeygamremote_Visible), 5, 0), true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E140V2 ();
         if (returnInSub) return;
      }

      protected void E140V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV6Application.load( AV15Id);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            AV6Application.gxTpr_Name = AV16Name;
            AV6Application.gxTpr_Description = AV11Dsc;
            AV6Application.gxTpr_Version = AV18Version;
            AV6Application.gxTpr_Copyright = AV10Copyright;
            AV6Application.gxTpr_Companyname = AV9Company;
            AV6Application.gxTpr_Mainmenuid = AV36MainMenu;
            AV6Application.gxTpr_Accessrequirespermission = AV5AccessRequiresPermission;
            AV6Application.gxTpr_Clientautoregisteranomymoususer = AV19AutoRegisterAnomymousUser;
            AV6Application.gxTpr_Clientid = AV7ClientId;
            AV6Application.gxTpr_Clientsecret = AV8ClientSecret;
            AV6Application.gxTpr_Clientaccessuniquebyuser = AV34ClientAccessUniqueByUser;
            AV6Application.gxTpr_Clientallowremoteauthentication = AV31ClientAllowRemoteAuth;
            AV6Application.gxTpr_Clientallowgetuserroles = AV32ClientAllowGetUserRoles;
            AV6Application.gxTpr_Clientallowgetuseradditionaldata = AV42ClientAllowGetUserAddData;
            AV6Application.gxTpr_Clientlocalloginurl = AV21ClientLocalLoginURL;
            AV6Application.gxTpr_Clientcallbackurl = AV22ClientCallbackURL;
            AV6Application.gxTpr_Clientimageurl = AV23ClientImageURL;
            AV6Application.gxTpr_Clientencryptionkey = AV33ClientEncryptionKey;
            AV6Application.gxTpr_Logoutobject = AV40ClientLocalLogoutObject;
            AV6Application.gxTpr_Homeobject = AV39HomeObject;
            AV6Application.gxTpr_Clientrepositoryguid = AV41ClientRepositoryGUID;
            AV6Application.gxTpr_Environment.gxTpr_Name = AV24EnvironmentName;
            AV6Application.gxTpr_Environment.gxTpr_Secureprotocol = AV26EnvironmentSecureProtocol;
            AV6Application.gxTpr_Environment.gxTpr_Host = AV27EnvironmentHost;
            AV6Application.gxTpr_Environment.gxTpr_Port = AV28EnvironmentPort;
            AV6Application.gxTpr_Environment.gxTpr_Virtualdirectory = AV25EnvironmentVirtualDirectory;
            AV6Application.gxTpr_Environment.gxTpr_Programpackage = AV29EnvironmentProgramPackage;
            AV6Application.gxTpr_Environment.gxTpr_Programextension = AV30EnvironmentProgramExtension;
            AV6Application.save();
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV6Application.delete();
         }
         if ( AV6Application.success() )
         {
            context.CommitDataStores("gamapplicationentry",pr_default);
            CallWebObject(formatLink("gamwwapplications.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV13Errors = AV6Application.geterrors();
            /* Execute user subroutine: 'ERRORS' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E150V2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            bttBtnrevokeallow_Visible = 1;
            AssignProp("", false, bttBtnrevokeallow_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnrevokeallow_Visible), 5, 0), true);
         }
         else
         {
            bttBtnrevokeallow_Visible = 0;
            AssignProp("", false, bttBtnrevokeallow_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnrevokeallow_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E160V2( )
      {
         /* 'Close' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(string)Gx_mode,(long)AV15Id});
         context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV15Id"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'ERRORS' Routine */
         returnInSub = false;
         if ( AV13Errors.Count > 0 )
         {
            AV53GXV3 = 1;
            while ( AV53GXV3 <= AV13Errors.Count )
            {
               AV12Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13Errors.Item(AV53GXV3));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV12Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV12Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV53GXV3 = (int)(AV53GXV3+1);
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E170V2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_142_0V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedclientencryptionkey_Internalname, tblTablemergedclientencryptionkey_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellClientencryptionkey_cell_Internalname+"\"  class='"+cellClientencryptionkey_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientencryptionkey_Internalname, "Client Encryption Key", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientencryptionkey_Internalname, StringUtil.RTrim( AV33ClientEncryptionKey), StringUtil.RTrim( context.localUtil.Format( AV33ClientEncryptionKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientencryptionkey_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", edtavClientencryptionkey_Visible, edtavClientencryptionkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "left", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngeneratekeygamremote_Internalname, "", "Gerar chave de gamremote", bttBtngeneratekeygamremote_Jsonclick, 5, "Gerar chave de gamremote", "", StyleString, ClassString, bttBtngeneratekeygamremote_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOGENERATEKEYGAMREMOTE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_142_0V2e( true) ;
         }
         else
         {
            wb_table2_142_0V2e( false) ;
         }
      }

      protected void wb_table1_96_0V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedclientrevoked_Internalname, tblTablemergedclientrevoked_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientrevoked_Internalname, "Client Revoked", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavClientrevoked_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavClientrevoked_Internalname, context.localUtil.TToC( AV35ClientRevoked, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV35ClientRevoked, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientrevoked_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavClientrevoked_Enabled, 1, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_bitmap( context, edtavClientrevoked_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavClientrevoked_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMApplicationEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrevokeallow_Internalname, "", bttBtnrevokeallow_Caption, bttBtnrevokeallow_Jsonclick, 5, "Revogação", "", StyleString, ClassString, bttBtnrevokeallow_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREVOKEALLOW\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_96_0V2e( true) ;
         }
         else
         {
            wb_table1_96_0V2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV15Id = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV15Id", StringUtil.LTrimStr( (decimal)(AV15Id), 12, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0V2( ) ;
         WS0V2( ) ;
         WE0V2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281551357", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gamapplicationentry.js", "?20214281551358", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavMainmenu.Name = "vMAINMENU";
         cmbavMainmenu.WebTags = "";
         if ( cmbavMainmenu.ItemCount > 0 )
         {
            AV36MainMenu = (long)(NumberUtil.Val( cmbavMainmenu.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV36MainMenu), 12, 0))), "."));
            AssignAttri("", false, "AV36MainMenu", StringUtil.LTrimStr( (decimal)(AV36MainMenu), 12, 0));
         }
         chkavAccessrequirespermission.Name = "vACCESSREQUIRESPERMISSION";
         chkavAccessrequirespermission.WebTags = "";
         chkavAccessrequirespermission.Caption = "Permissões são obrigatórios?";
         AssignProp("", false, chkavAccessrequirespermission_Internalname, "TitleCaption", chkavAccessrequirespermission.Caption, true);
         chkavAccessrequirespermission.CheckedValue = "false";
         AV5AccessRequiresPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV5AccessRequiresPermission));
         AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
         chkavClientaccessuniquebyuser.Name = "vCLIENTACCESSUNIQUEBYUSER";
         chkavClientaccessuniquebyuser.WebTags = "";
         chkavClientaccessuniquebyuser.Caption = "O acesso de usuário é único?";
         AssignProp("", false, chkavClientaccessuniquebyuser_Internalname, "TitleCaption", chkavClientaccessuniquebyuser.Caption, true);
         chkavClientaccessuniquebyuser.CheckedValue = "false";
         AV34ClientAccessUniqueByUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV34ClientAccessUniqueByUser));
         AssignAttri("", false, "AV34ClientAccessUniqueByUser", AV34ClientAccessUniqueByUser);
         chkavClientallowremoteauth.Name = "vCLIENTALLOWREMOTEAUTH";
         chkavClientallowremoteauth.WebTags = "";
         chkavClientallowremoteauth.Caption = "Permitir autenticação remota?";
         AssignProp("", false, chkavClientallowremoteauth_Internalname, "TitleCaption", chkavClientallowremoteauth.Caption, true);
         chkavClientallowremoteauth.CheckedValue = "false";
         AV31ClientAllowRemoteAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV31ClientAllowRemoteAuth));
         AssignAttri("", false, "AV31ClientAllowRemoteAuth", AV31ClientAllowRemoteAuth);
         chkavClientallowgetuserroles.Name = "vCLIENTALLOWGETUSERROLES";
         chkavClientallowgetuserroles.WebTags = "";
         chkavClientallowgetuserroles.Caption = "Você pode obter funções de usuário?";
         AssignProp("", false, chkavClientallowgetuserroles_Internalname, "TitleCaption", chkavClientallowgetuserroles.Caption, true);
         chkavClientallowgetuserroles.CheckedValue = "false";
         AV32ClientAllowGetUserRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV32ClientAllowGetUserRoles));
         AssignAttri("", false, "AV32ClientAllowGetUserRoles", AV32ClientAllowGetUserRoles);
         chkavClientallowgetuseradddata.Name = "vCLIENTALLOWGETUSERADDDATA";
         chkavClientallowgetuseradddata.WebTags = "";
         chkavClientallowgetuseradddata.Caption = "Você pode obter dados adicionais dos usuários?";
         AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "TitleCaption", chkavClientallowgetuseradddata.Caption, true);
         chkavClientallowgetuseradddata.CheckedValue = "false";
         AV42ClientAllowGetUserAddData = StringUtil.StrToBool( StringUtil.BoolToStr( AV42ClientAllowGetUserAddData));
         AssignAttri("", false, "AV42ClientAllowGetUserAddData", AV42ClientAllowGetUserAddData);
         chkavEnvironmentsecureprotocol.Name = "vENVIRONMENTSECUREPROTOCOL";
         chkavEnvironmentsecureprotocol.WebTags = "";
         chkavEnvironmentsecureprotocol.Caption = "É https?";
         AssignProp("", false, chkavEnvironmentsecureprotocol_Internalname, "TitleCaption", chkavEnvironmentsecureprotocol.Caption, true);
         chkavEnvironmentsecureprotocol.CheckedValue = "false";
         AV26EnvironmentSecureProtocol = StringUtil.StrToBool( StringUtil.BoolToStr( AV26EnvironmentSecureProtocol));
         AssignAttri("", false, "AV26EnvironmentSecureProtocol", AV26EnvironmentSecureProtocol);
         chkavAutoregisteranomymoususer.Name = "vAUTOREGISTERANOMYMOUSUSER";
         chkavAutoregisteranomymoususer.WebTags = "";
         chkavAutoregisteranomymoususer.Caption = "";
         AssignProp("", false, chkavAutoregisteranomymoususer_Internalname, "TitleCaption", chkavAutoregisteranomymoususer.Caption, true);
         chkavAutoregisteranomymoususer.CheckedValue = "false";
         AV19AutoRegisterAnomymousUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV19AutoRegisterAnomymousUser));
         AssignAttri("", false, "AV19AutoRegisterAnomymousUser", AV19AutoRegisterAnomymousUser);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         edtavId_Internalname = "vID";
         edtavGuid_Internalname = "vGUID";
         edtavName_Internalname = "vNAME";
         edtavDsc_Internalname = "vDSC";
         edtavVersion_Internalname = "vVERSION";
         edtavCompany_Internalname = "vCOMPANY";
         edtavCopyright_Internalname = "vCOPYRIGHT";
         cmbavMainmenu_Internalname = "vMAINMENU";
         edtavHomeobject_Internalname = "vHOMEOBJECT";
         edtavClientlocallogoutobject_Internalname = "vCLIENTLOCALLOGOUTOBJECT";
         chkavAccessrequirespermission_Internalname = "vACCESSREQUIRESPERMISSION";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         lblClientapplicationdata_title_Internalname = "CLIENTAPPLICATIONDATA_TITLE";
         edtavClientid_Internalname = "vCLIENTID";
         edtavClientsecret_Internalname = "vCLIENTSECRET";
         chkavClientaccessuniquebyuser_Internalname = "vCLIENTACCESSUNIQUEBYUSER";
         lblTextblockclientrevoked_Internalname = "TEXTBLOCKCLIENTREVOKED";
         edtavClientrevoked_Internalname = "vCLIENTREVOKED";
         bttBtnrevokeallow_Internalname = "BTNREVOKEALLOW";
         tblTablemergedclientrevoked_Internalname = "TABLEMERGEDCLIENTREVOKED";
         divTablesplittedclientrevoked_Internalname = "TABLESPLITTEDCLIENTREVOKED";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblRemoteauthentication_title_Internalname = "REMOTEAUTHENTICATION_TITLE";
         chkavClientallowremoteauth_Internalname = "vCLIENTALLOWREMOTEAUTH";
         chkavClientallowgetuserroles_Internalname = "vCLIENTALLOWGETUSERROLES";
         divClientallowgetuserroles_cell_Internalname = "CLIENTALLOWGETUSERROLES_CELL";
         chkavClientallowgetuseradddata_Internalname = "vCLIENTALLOWGETUSERADDDATA";
         divClientallowgetuseradddata_cell_Internalname = "CLIENTALLOWGETUSERADDDATA_CELL";
         edtavClientlocalloginurl_Internalname = "vCLIENTLOCALLOGINURL";
         divClientlocalloginurl_cell_Internalname = "CLIENTLOCALLOGINURL_CELL";
         edtavClientcallbackurl_Internalname = "vCLIENTCALLBACKURL";
         divClientcallbackurl_cell_Internalname = "CLIENTCALLBACKURL_CELL";
         edtavClientimageurl_Internalname = "vCLIENTIMAGEURL";
         divClientimageurl_cell_Internalname = "CLIENTIMAGEURL_CELL";
         lblTextblockclientencryptionkey_Internalname = "TEXTBLOCKCLIENTENCRYPTIONKEY";
         divTextblockclientencryptionkey_cell_Internalname = "TEXTBLOCKCLIENTENCRYPTIONKEY_CELL";
         edtavClientencryptionkey_Internalname = "vCLIENTENCRYPTIONKEY";
         cellClientencryptionkey_cell_Internalname = "CLIENTENCRYPTIONKEY_CELL";
         bttBtngeneratekeygamremote_Internalname = "BTNGENERATEKEYGAMREMOTE";
         tblTablemergedclientencryptionkey_Internalname = "TABLEMERGEDCLIENTENCRYPTIONKEY";
         divTablesplittedclientencryptionkey_Internalname = "TABLESPLITTEDCLIENTENCRYPTIONKEY";
         edtavClientrepositoryguid_Internalname = "vCLIENTREPOSITORYGUID";
         divClientrepositoryguid_cell_Internalname = "CLIENTREPOSITORYGUID_CELL";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblEnvironmentsettings_title_Internalname = "ENVIRONMENTSETTINGS_TITLE";
         edtavEnvironmentname_Internalname = "vENVIRONMENTNAME";
         chkavEnvironmentsecureprotocol_Internalname = "vENVIRONMENTSECUREPROTOCOL";
         edtavEnvironmenthost_Internalname = "vENVIRONMENTHOST";
         edtavEnvironmentport_Internalname = "vENVIRONMENTPORT";
         edtavEnvironmentvirtualdirectory_Internalname = "vENVIRONMENTVIRTUALDIRECTORY";
         edtavEnvironmentprogrampackage_Internalname = "vENVIRONMENTPROGRAMPACKAGE";
         edtavEnvironmentprogramextension_Internalname = "vENVIRONMENTPROGRAMEXTENSION";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavAutoregisteranomymoususer_Internalname = "vAUTOREGISTERANOMYMOUSUSER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavAutoregisteranomymoususer.Caption = "";
         chkavEnvironmentsecureprotocol.Caption = " ";
         chkavClientallowgetuseradddata.Caption = " ";
         chkavClientallowgetuserroles.Caption = " ";
         chkavClientallowremoteauth.Caption = " ";
         chkavClientaccessuniquebyuser.Caption = " ";
         chkavAccessrequirespermission.Caption = " ";
         bttBtnrevokeallow_Visible = 1;
         edtavClientrevoked_Jsonclick = "";
         bttBtngeneratekeygamremote_Visible = 1;
         edtavClientencryptionkey_Jsonclick = "";
         cellClientencryptionkey_cell_Class = "";
         edtavClientencryptionkey_Visible = 1;
         edtavClientencryptionkey_Enabled = 1;
         edtavClientrevoked_Enabled = 1;
         bttBtnrevokeallow_Caption = "Revogação";
         chkavAutoregisteranomymoususer.Visible = 1;
         bttBtnenter_Caption = "Confirmar";
         bttBtnenter_Visible = 1;
         edtavEnvironmentprogramextension_Jsonclick = "";
         edtavEnvironmentprogramextension_Enabled = 1;
         edtavEnvironmentprogrampackage_Jsonclick = "";
         edtavEnvironmentprogrampackage_Enabled = 1;
         edtavEnvironmentvirtualdirectory_Jsonclick = "";
         edtavEnvironmentvirtualdirectory_Enabled = 1;
         edtavEnvironmentport_Jsonclick = "";
         edtavEnvironmentport_Enabled = 1;
         edtavEnvironmenthost_Jsonclick = "";
         edtavEnvironmenthost_Enabled = 1;
         chkavEnvironmentsecureprotocol.Enabled = 1;
         edtavEnvironmentname_Jsonclick = "";
         edtavEnvironmentname_Enabled = 1;
         edtavClientrepositoryguid_Jsonclick = "";
         edtavClientrepositoryguid_Enabled = 1;
         edtavClientrepositoryguid_Visible = 1;
         divClientrepositoryguid_cell_Class = "col-xs-12 col-sm-6";
         divTextblockclientencryptionkey_cell_Class = "col-xs-12";
         edtavClientimageurl_Jsonclick = "";
         edtavClientimageurl_Enabled = 1;
         edtavClientimageurl_Visible = 1;
         divClientimageurl_cell_Class = "col-xs-12 col-sm-6";
         edtavClientcallbackurl_Jsonclick = "";
         edtavClientcallbackurl_Enabled = 1;
         edtavClientcallbackurl_Visible = 1;
         divClientcallbackurl_cell_Class = "col-xs-12 col-sm-6";
         edtavClientlocalloginurl_Jsonclick = "";
         edtavClientlocalloginurl_Enabled = 1;
         edtavClientlocalloginurl_Visible = 1;
         divClientlocalloginurl_cell_Class = "col-xs-12 col-sm-6";
         chkavClientallowgetuseradddata.Enabled = 1;
         chkavClientallowgetuseradddata.Visible = 1;
         divClientallowgetuseradddata_cell_Class = "col-xs-12 col-sm-6";
         chkavClientallowgetuserroles.Enabled = 1;
         chkavClientallowgetuserroles.Visible = 1;
         divClientallowgetuserroles_cell_Class = "col-xs-12 col-sm-6";
         chkavClientallowremoteauth.Enabled = 1;
         chkavClientaccessuniquebyuser.Enabled = 1;
         edtavClientsecret_Jsonclick = "";
         edtavClientsecret_Enabled = 1;
         edtavClientid_Jsonclick = "";
         edtavClientid_Enabled = 1;
         chkavAccessrequirespermission.Enabled = 1;
         edtavClientlocallogoutobject_Jsonclick = "";
         edtavClientlocallogoutobject_Enabled = 1;
         edtavHomeobject_Jsonclick = "";
         edtavHomeobject_Enabled = 1;
         cmbavMainmenu_Jsonclick = "";
         cmbavMainmenu.Enabled = 1;
         edtavCopyright_Jsonclick = "";
         edtavCopyright_Enabled = 1;
         edtavCompany_Jsonclick = "";
         edtavCompany_Enabled = 1;
         edtavVersion_Jsonclick = "";
         edtavVersion_Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 0;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "";
         Gxuitabspanel_tabs_Pagecount = 4;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Aplicação";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'BTNREVOKEALLOW',prop:'Visible'},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]}");
         setEventMetadata("'DOGENERATEKEYGAMREMOTE'","{handler:'E120V2',iparms:[{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]");
         setEventMetadata("'DOGENERATEKEYGAMREMOTE'",",oparms:[{av:'AV33ClientEncryptionKey',fld:'vCLIENTENCRYPTIONKEY',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]}");
         setEventMetadata("'DOREVOKEALLOW'","{handler:'E130V2',iparms:[{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]");
         setEventMetadata("'DOREVOKEALLOW'",",oparms:[{ctrl:'BTNREVOKEALLOW',prop:'Caption'},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E140V2',iparms:[{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV11Dsc',fld:'vDSC',pic:''},{av:'AV18Version',fld:'vVERSION',pic:''},{av:'AV10Copyright',fld:'vCOPYRIGHT',pic:''},{av:'AV9Company',fld:'vCOMPANY',pic:''},{av:'cmbavMainmenu'},{av:'AV36MainMenu',fld:'vMAINMENU',pic:'ZZZZZZZZZZZ9'},{av:'AV7ClientId',fld:'vCLIENTID',pic:''},{av:'AV8ClientSecret',fld:'vCLIENTSECRET',pic:''},{av:'AV21ClientLocalLoginURL',fld:'vCLIENTLOCALLOGINURL',pic:''},{av:'AV22ClientCallbackURL',fld:'vCLIENTCALLBACKURL',pic:''},{av:'AV23ClientImageURL',fld:'vCLIENTIMAGEURL',pic:''},{av:'AV33ClientEncryptionKey',fld:'vCLIENTENCRYPTIONKEY',pic:''},{av:'AV40ClientLocalLogoutObject',fld:'vCLIENTLOCALLOGOUTOBJECT',pic:''},{av:'AV39HomeObject',fld:'vHOMEOBJECT',pic:''},{av:'AV41ClientRepositoryGUID',fld:'vCLIENTREPOSITORYGUID',pic:''},{av:'AV24EnvironmentName',fld:'vENVIRONMENTNAME',pic:''},{av:'AV27EnvironmentHost',fld:'vENVIRONMENTHOST',pic:''},{av:'AV28EnvironmentPort',fld:'vENVIRONMENTPORT',pic:'ZZZZ9'},{av:'AV25EnvironmentVirtualDirectory',fld:'vENVIRONMENTVIRTUALDIRECTORY',pic:''},{av:'AV29EnvironmentProgramPackage',fld:'vENVIRONMENTPROGRAMPACKAGE',pic:''},{av:'AV30EnvironmentProgramExtension',fld:'vENVIRONMENTPROGRAMEXTENSION',pic:''},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]}");
         setEventMetadata("'CLOSE'","{handler:'E160V2',iparms:[{av:'AV15Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]");
         setEventMetadata("'CLOSE'",",oparms:[{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]}");
         setEventMetadata("VALIDV_CLIENTREVOKED","{handler:'Validv_Clientrevoked',iparms:[{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]");
         setEventMetadata("VALIDV_CLIENTREVOKED",",oparms:[{av:'AV5AccessRequiresPermission',fld:'vACCESSREQUIRESPERMISSION',pic:''},{av:'AV34ClientAccessUniqueByUser',fld:'vCLIENTACCESSUNIQUEBYUSER',pic:''},{av:'AV31ClientAllowRemoteAuth',fld:'vCLIENTALLOWREMOTEAUTH',pic:''},{av:'AV32ClientAllowGetUserRoles',fld:'vCLIENTALLOWGETUSERROLES',pic:''},{av:'AV42ClientAllowGetUserAddData',fld:'vCLIENTALLOWGETUSERADDDATA',pic:''},{av:'AV26EnvironmentSecureProtocol',fld:'vENVIRONMENTSECUREPROTOCOL',pic:''},{av:'AV19AutoRegisterAnomymousUser',fld:'vAUTOREGISTERANOMYMOUSUSER',pic:''}]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         TempTags = "";
         AV14GUID = "";
         AV16Name = "";
         AV11Dsc = "";
         AV18Version = "";
         AV9Company = "";
         AV10Copyright = "";
         AV39HomeObject = "";
         AV40ClientLocalLogoutObject = "";
         lblClientapplicationdata_title_Jsonclick = "";
         AV7ClientId = "";
         AV8ClientSecret = "";
         lblTextblockclientrevoked_Jsonclick = "";
         lblRemoteauthentication_title_Jsonclick = "";
         AV21ClientLocalLoginURL = "";
         AV22ClientCallbackURL = "";
         AV23ClientImageURL = "";
         lblTextblockclientencryptionkey_Jsonclick = "";
         AV41ClientRepositoryGUID = "";
         lblEnvironmentsettings_title_Jsonclick = "";
         AV24EnvironmentName = "";
         AV27EnvironmentHost = "";
         AV25EnvironmentVirtualDirectory = "";
         AV29EnvironmentProgramPackage = "";
         AV30EnvironmentProgramExtension = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV35ClientRevoked = (DateTime)(DateTime.MinValue);
         AV33ClientEncryptionKey = "";
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV6Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV51GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV37MenuFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV38Menu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         bttBtngeneratekeygamremote_Jsonclick = "";
         bttBtnrevokeallow_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamapplicationentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamapplicationentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
         edtavClientrevoked_Enabled = 0;
         edtavClientencryptionkey_Enabled = 0;
         edtavClientrepositoryguid_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavId_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavVersion_Enabled ;
      private int edtavCompany_Enabled ;
      private int edtavCopyright_Enabled ;
      private int edtavHomeobject_Enabled ;
      private int edtavClientlocallogoutobject_Enabled ;
      private int edtavClientid_Enabled ;
      private int edtavClientsecret_Enabled ;
      private int edtavClientlocalloginurl_Visible ;
      private int edtavClientlocalloginurl_Enabled ;
      private int edtavClientcallbackurl_Visible ;
      private int edtavClientcallbackurl_Enabled ;
      private int edtavClientimageurl_Visible ;
      private int edtavClientimageurl_Enabled ;
      private int edtavClientrepositoryguid_Visible ;
      private int edtavClientrepositoryguid_Enabled ;
      private int edtavEnvironmentname_Enabled ;
      private int edtavEnvironmenthost_Enabled ;
      private int AV28EnvironmentPort ;
      private int edtavEnvironmentport_Enabled ;
      private int edtavEnvironmentvirtualdirectory_Enabled ;
      private int edtavEnvironmentprogrampackage_Enabled ;
      private int edtavEnvironmentprogramextension_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavClientrevoked_Enabled ;
      private int edtavClientencryptionkey_Enabled ;
      private int AV52GXV2 ;
      private int bttBtngeneratekeygamremote_Visible ;
      private int edtavClientencryptionkey_Visible ;
      private int bttBtnrevokeallow_Visible ;
      private int AV53GXV3 ;
      private int idxLst ;
      private long AV15Id ;
      private long wcpOAV15Id ;
      private long AV36MainMenu ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gxuitabspanel_tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string edtavId_Internalname ;
      private string edtavId_Jsonclick ;
      private string edtavGuid_Internalname ;
      private string TempTags ;
      private string AV14GUID ;
      private string edtavGuid_Jsonclick ;
      private string edtavName_Internalname ;
      private string AV16Name ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Internalname ;
      private string AV11Dsc ;
      private string edtavDsc_Jsonclick ;
      private string edtavVersion_Internalname ;
      private string AV18Version ;
      private string edtavVersion_Jsonclick ;
      private string edtavCompany_Internalname ;
      private string AV9Company ;
      private string edtavCompany_Jsonclick ;
      private string edtavCopyright_Internalname ;
      private string AV10Copyright ;
      private string edtavCopyright_Jsonclick ;
      private string cmbavMainmenu_Internalname ;
      private string cmbavMainmenu_Jsonclick ;
      private string edtavHomeobject_Internalname ;
      private string edtavHomeobject_Jsonclick ;
      private string edtavClientlocallogoutobject_Internalname ;
      private string edtavClientlocallogoutobject_Jsonclick ;
      private string chkavAccessrequirespermission_Internalname ;
      private string lblClientapplicationdata_title_Internalname ;
      private string lblClientapplicationdata_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string edtavClientid_Internalname ;
      private string AV7ClientId ;
      private string edtavClientid_Jsonclick ;
      private string edtavClientsecret_Internalname ;
      private string AV8ClientSecret ;
      private string edtavClientsecret_Jsonclick ;
      private string chkavClientaccessuniquebyuser_Internalname ;
      private string divTablesplittedclientrevoked_Internalname ;
      private string lblTextblockclientrevoked_Internalname ;
      private string lblTextblockclientrevoked_Jsonclick ;
      private string lblRemoteauthentication_title_Internalname ;
      private string lblRemoteauthentication_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string chkavClientallowremoteauth_Internalname ;
      private string divClientallowgetuserroles_cell_Internalname ;
      private string divClientallowgetuserroles_cell_Class ;
      private string chkavClientallowgetuserroles_Internalname ;
      private string divClientallowgetuseradddata_cell_Internalname ;
      private string divClientallowgetuseradddata_cell_Class ;
      private string chkavClientallowgetuseradddata_Internalname ;
      private string divClientlocalloginurl_cell_Internalname ;
      private string divClientlocalloginurl_cell_Class ;
      private string edtavClientlocalloginurl_Internalname ;
      private string edtavClientlocalloginurl_Jsonclick ;
      private string divClientcallbackurl_cell_Internalname ;
      private string divClientcallbackurl_cell_Class ;
      private string edtavClientcallbackurl_Internalname ;
      private string edtavClientcallbackurl_Jsonclick ;
      private string divClientimageurl_cell_Internalname ;
      private string divClientimageurl_cell_Class ;
      private string edtavClientimageurl_Internalname ;
      private string edtavClientimageurl_Jsonclick ;
      private string divTablesplittedclientencryptionkey_Internalname ;
      private string divTextblockclientencryptionkey_cell_Internalname ;
      private string divTextblockclientencryptionkey_cell_Class ;
      private string lblTextblockclientencryptionkey_Internalname ;
      private string lblTextblockclientencryptionkey_Jsonclick ;
      private string divClientrepositoryguid_cell_Internalname ;
      private string divClientrepositoryguid_cell_Class ;
      private string edtavClientrepositoryguid_Internalname ;
      private string AV41ClientRepositoryGUID ;
      private string edtavClientrepositoryguid_Jsonclick ;
      private string lblEnvironmentsettings_title_Internalname ;
      private string lblEnvironmentsettings_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavEnvironmentname_Internalname ;
      private string AV24EnvironmentName ;
      private string edtavEnvironmentname_Jsonclick ;
      private string chkavEnvironmentsecureprotocol_Internalname ;
      private string edtavEnvironmenthost_Internalname ;
      private string AV27EnvironmentHost ;
      private string edtavEnvironmenthost_Jsonclick ;
      private string edtavEnvironmentport_Internalname ;
      private string edtavEnvironmentport_Jsonclick ;
      private string edtavEnvironmentvirtualdirectory_Internalname ;
      private string AV25EnvironmentVirtualDirectory ;
      private string edtavEnvironmentvirtualdirectory_Jsonclick ;
      private string edtavEnvironmentprogrampackage_Internalname ;
      private string AV29EnvironmentProgramPackage ;
      private string edtavEnvironmentprogrampackage_Jsonclick ;
      private string edtavEnvironmentprogramextension_Internalname ;
      private string AV30EnvironmentProgramExtension ;
      private string edtavEnvironmentprogramextension_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavAutoregisteranomymoususer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavClientrevoked_Internalname ;
      private string edtavClientencryptionkey_Internalname ;
      private string AV33ClientEncryptionKey ;
      private string bttBtnrevokeallow_Caption ;
      private string bttBtnrevokeallow_Internalname ;
      private string bttBtngeneratekeygamremote_Internalname ;
      private string cellClientencryptionkey_cell_Class ;
      private string cellClientencryptionkey_cell_Internalname ;
      private string sStyleString ;
      private string tblTablemergedclientencryptionkey_Internalname ;
      private string edtavClientencryptionkey_Jsonclick ;
      private string bttBtngeneratekeygamremote_Jsonclick ;
      private string tblTablemergedclientrevoked_Internalname ;
      private string edtavClientrevoked_Jsonclick ;
      private string bttBtnrevokeallow_Jsonclick ;
      private DateTime AV35ClientRevoked ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool AV5AccessRequiresPermission ;
      private bool AV34ClientAccessUniqueByUser ;
      private bool AV31ClientAllowRemoteAuth ;
      private bool AV32ClientAllowGetUserRoles ;
      private bool AV42ClientAllowGetUserAddData ;
      private bool AV26EnvironmentSecureProtocol ;
      private bool AV19AutoRegisterAnomymousUser ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV20isOk ;
      private string AV39HomeObject ;
      private string AV40ClientLocalLogoutObject ;
      private string AV21ClientLocalLoginURL ;
      private string AV22ClientCallbackURL ;
      private string AV23ClientImageURL ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_Id ;
      private GXCombobox cmbavMainmenu ;
      private GXCheckbox chkavAccessrequirespermission ;
      private GXCheckbox chkavClientaccessuniquebyuser ;
      private GXCheckbox chkavClientallowremoteauth ;
      private GXCheckbox chkavClientallowgetuserroles ;
      private GXCheckbox chkavClientallowgetuseradddata ;
      private GXCheckbox chkavEnvironmentsecureprotocol ;
      private GXCheckbox chkavAutoregisteranomymoususer ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV51GXV1 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV6Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV38Menu ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter AV37MenuFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17User ;
   }

   public class gamapplicationentry__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       dynamic table = buf;
       switch ( cursor )
       {
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

    public string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class gamapplicationentry__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     dynamic table = buf;
     switch ( cursor )
     {
     }
  }

  public void setParameters( int cursor ,
                             IFieldSetter stmt ,
                             Object[] parms )
  {
     switch ( cursor )
     {
     }
  }

}

}
