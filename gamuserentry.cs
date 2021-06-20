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
   public class gamuserentry : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamuserentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamuserentry( IGxContext context )
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
                           ref string aP1_UserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV39UserId = aP1_UserId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_UserId=this.AV39UserId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavUserauthenticationtypename = new GXCombobox();
         cmbavUsergender = new GXCombobox();
         chkavUserisactive = new GXCheckbox();
         chkavUserisenabledinrepository = new GXCheckbox();
         chkavUserdontreceiveinformation = new GXCheckbox();
         chkavUserisblocked = new GXCheckbox();
         chkavUsercannotchangepassword = new GXCheckbox();
         chkavUsermustchangepassword = new GXCheckbox();
         chkavUserpasswordneverexpires = new GXCheckbox();
         cmbavUsersecuritypolicyid = new GXCombobox();
         chkavUser_isenabledinrepository = new GXCheckbox();
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
                  AV39UserId = GetPar( "UserId");
                  AssignAttri("", false, "AV39UserId", AV39UserId);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39UserId, "")), context));
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
            return "gamuserentry_Execute" ;
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
         PA1H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1H2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281553459", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV39UserId))}, new string[] {"Gx_mode","UserId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39UserId, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Language, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"GAMUserEntry");
         forbiddenHiddens.Add("UserActivationDate", context.localUtil.Format( AV28UserActivationDate, "99/99/9999 99:99"));
         AV42UserIsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV42UserIsEnabledInRepository));
         AssignAttri("", false, "AV42UserIsEnabledInRepository", AV42UserIsEnabledInRepository);
         forbiddenHiddens.Add("UserIsEnabledInRepository", StringUtil.BoolToStr( AV42UserIsEnabledInRepository));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("gamuserentry:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.RTrim( AV39UserId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39UserId, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV14CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV20Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERAUTHENTICATIONTYPET", StringUtil.RTrim( AV53UserAuthenticationTypeT));
         GxWebStd.gx_hidden_field( context, "vPASSWORD", StringUtil.RTrim( AV21Password));
         GXCCtlgxBlob = "vWWPUSEREXTENDEDPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, AV7WWPUserExtendedPhoto);
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
            WE1H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1H2( ) ;
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
         return formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV39UserId))}, new string[] {"Gx_mode","UserId"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMUserEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuário" ;
      }

      protected void WB1H0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserauthenticationtypename_cell_Internalname, 1, 0, "px", 0, "px", divUserauthenticationtypename_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavUserauthenticationtypename.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavUserauthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUserauthenticationtypename_Internalname, "Tipo de autorização", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUserauthenticationtypename, cmbavUserauthenticationtypename_Internalname, StringUtil.RTrim( AV29UserAuthenticationTypeName), 1, cmbavUserauthenticationtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavUserauthenticationtypename.Visible, cmbavUserauthenticationtypename.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, "HLP_GAMUserEntry.htm");
            cmbavUserauthenticationtypename.CurrentValue = StringUtil.RTrim( AV29UserAuthenticationTypeName);
            AssignProp("", false, cmbavUserauthenticationtypename_Internalname, "Values", (string)(cmbavUserauthenticationtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "Nome de usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV45UserName, StringUtil.RTrim( context.localUtil.Format( AV45UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUseremail_cell_Internalname, 1, 0, "px", 0, "px", divUseremail_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUseremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUseremail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUseremail_Internalname, AV34UserEmail, StringUtil.RTrim( context.localUtil.Format( AV34UserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUseremail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUseremail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserfirstname_cell_Internalname, 1, 0, "px", 0, "px", divUserfirstname_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserfirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserfirstname_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserfirstname_Internalname, StringUtil.RTrim( AV36UserFirstName), StringUtil.RTrim( context.localUtil.Format( AV36UserFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserfirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserfirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserlastname_cell_Internalname, 1, 0, "px", 0, "px", divUserlastname_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserlastname_Internalname, "Sobrenome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserlastname_Internalname, StringUtil.RTrim( AV43UserLastName), StringUtil.RTrim( context.localUtil.Format( AV43UserLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserlastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserpassword_cell_Internalname, 1, 0, "px", 0, "px", divUserpassword_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "Senha", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV47UserPassword), StringUtil.RTrim( context.localUtil.Format( AV47UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpassword_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPasswordconf_cell_Internalname, 1, 0, "px", 0, "px", divPasswordconf_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPasswordconf_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, "Conf. senha", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV22PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV22PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "Attribute", "", "", "", "", edtavPasswordconf_Visible, edtavPasswordconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserexternalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserexternalid_Internalname, "Id externo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserexternalid_Internalname, AV35UserExternalId, StringUtil.RTrim( context.localUtil.Format( AV35UserExternalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserexternalid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserexternalid_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserbirthday_cell_Internalname, 1, 0, "px", 0, "px", divUserbirthday_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserbirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserbirthday_Internalname, "Data de nascimento", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUserbirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUserbirthday_Internalname, context.localUtil.Format(AV30UserBirthday, "99/99/9999"), context.localUtil.Format( AV30UserBirthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserbirthday_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavUserbirthday_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavUserbirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUserbirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUsergender_cell_Internalname, 1, 0, "px", 0, "px", divUsergender_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavUsergender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsergender_Internalname, "Sexo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsergender, cmbavUsergender_Internalname, StringUtil.RTrim( AV37UserGender), 1, cmbavUsergender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsergender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, "HLP_GAMUserEntry.htm");
            cmbavUsergender.CurrentValue = StringUtil.RTrim( AV37UserGender);
            AssignProp("", false, cmbavUsergender_Internalname, "Values", (string)(cmbavUsergender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserphone_cell_Internalname, 1, 0, "px", 0, "px", divUserphone_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserphone_Internalname, "Telefone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserphone_Internalname, StringUtil.RTrim( AV8UserPhone), StringUtil.RTrim( context.localUtil.Format( AV8UserPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserphone_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserurlprofile_cell_Internalname, 1, 0, "px", 0, "px", divUserurlprofile_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserurlprofile_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserurlprofile_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserurlprofile_Internalname, "Url do perfil", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserurlprofile_Internalname, AV51UserURLProfile, StringUtil.RTrim( context.localUtil.Format( AV51UserURLProfile, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", edtavUserurlprofile_Link, edtavUserurlprofile_Linktarget, "", "", edtavUserurlprofile_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserurlprofile_Visible, edtavUserurlprofile_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserurlimage_cell_Internalname, 1, 0, "px", 0, "px", divUserurlimage_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserurlimage_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserurlimage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserurlimage_Internalname, "Url da imagem", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserurlimage_Internalname, AV50UserURLImage, StringUtil.RTrim( context.localUtil.Format( AV50UserURLImage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserurlimage_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserurlimage_Visible, edtavUserurlimage_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedwwpuserextendedphoto_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockwwpuserextendedphoto_Internalname, "Foto", "", "", lblTextblockwwpuserextendedphoto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            wb_table1_84_1H2( true) ;
         }
         else
         {
            wb_table1_84_1H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_84_1H2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserisactive_cell_Internalname, 1, 0, "px", 0, "px", divUserisactive_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavUserisactive.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserisactive_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserisactive_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserisactive_Internalname, StringUtil.BoolToStr( AV40UserIsActive), "", " ", chkavUserisactive.Visible, chkavUserisactive.Enabled, "true", "Ativo?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUseractivationdate_cell_Internalname, 1, 0, "px", 0, "px", divUseractivationdate_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUseractivationdate_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUseractivationdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUseractivationdate_Internalname, "Data de ativação", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUseractivationdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUseractivationdate_Internalname, context.localUtil.TToC( AV28UserActivationDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV28UserActivationDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUseractivationdate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", edtavUseractivationdate_Visible, edtavUseractivationdate_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavUseractivationdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavUseractivationdate_Visible==0)||(edtavUseractivationdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteduserisenabledinrepository_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblockuserisenabledinrepository_cell_Internalname, 1, 0, "px", 0, "px", divTextblockuserisenabledinrepository_cell_Class, "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockuserisenabledinrepository_Internalname, "", "", "", lblTextblockuserisenabledinrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_106_1H2( true) ;
         }
         else
         {
            wb_table2_106_1H2( false) ;
         }
         return  ;
      }

      protected void wb_table2_106_1H2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserdatelasauthentication_cell_Internalname, 1, 0, "px", 0, "px", divUserdatelasauthentication_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserdatelasauthentication_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserdatelasauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserdatelasauthentication_Internalname, "Data da última autenticação", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUserdatelasauthentication_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUserdatelasauthentication_Internalname, context.localUtil.TToC( AV32UserDateLasAuthentication, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV32UserDateLasAuthentication, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserdatelasauthentication_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", edtavUserdatelasauthentication_Visible, edtavUserdatelasauthentication_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "right", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavUserdatelasauthentication_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavUserdatelasauthentication_Visible==0)||(edtavUserdatelasauthentication_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserdontreceiveinformation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserdontreceiveinformation_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserdontreceiveinformation_Internalname, StringUtil.BoolToStr( AV33UserDontReceiveInformation), "", " ", 1, chkavUserdontreceiveinformation.Enabled, "true", "Eu não desejo receber informação", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(121, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,121);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserisblocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserisblocked_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserisblocked_Internalname, StringUtil.BoolToStr( AV41UserIsBlocked), "", " ", 1, chkavUserisblocked.Enabled, "true", "Está bloqueado?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(126, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,126);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUsercannotchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUsercannotchangepassword_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUsercannotchangepassword_Internalname, StringUtil.BoolToStr( AV31UserCannotChangePassword), "", " ", 1, chkavUsercannotchangepassword.Enabled, "true", "Você não pode alterar a senha", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(130, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,130);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUsermustchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUsermustchangepassword_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUsermustchangepassword_Internalname, StringUtil.BoolToStr( AV44UserMustChangePassword), "", " ", 1, chkavUsermustchangepassword.Enabled, "true", "Você deve alterar a senha", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(135, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,135);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserpasswordneverexpires_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserpasswordneverexpires_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserpasswordneverexpires_Internalname, StringUtil.BoolToStr( AV48UserPasswordNeverExpires), "", " ", 1, chkavUserpasswordneverexpires.Enabled, "true", "A senha nunca expira", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(139, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,139);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavUsersecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsersecuritypolicyid_Internalname, "Política de segurança", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsersecuritypolicyid, cmbavUsersecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV49UserSecurityPolicyId), 9, 0)), 1, cmbavUsersecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavUsersecuritypolicyid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "", true, "HLP_GAMUserEntry.htm");
            cmbavUsersecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49UserSecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavUsersecuritypolicyid_Internalname, "Values", (string)(cmbavUsersecuritypolicyid.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUser_isenabledinrepository_Internalname, StringUtil.BoolToStr( AV27User.gxTpr_Isenabledinrepository), "", "", chkavUser_isenabledinrepository.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(155, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,155);\"");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserguid_Internalname, StringUtil.RTrim( AV38UserGUID), StringUtil.RTrim( context.localUtil.Format( AV38UserGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserguid_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMUserEntry.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsernamespace_Internalname, StringUtil.RTrim( AV46UserNameSpace), StringUtil.RTrim( context.localUtil.Format( AV46UserNameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsernamespace_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsernamespace_Visible, 1, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "left", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1H2( )
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
            Form.Meta.addItem("description", "Usuário", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1H0( ) ;
      }

      protected void WS1H2( )
      {
         START1H2( ) ;
         EVT1H2( ) ;
      }

      protected void EVT1H2( )
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
                              E111H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOENABLEUSERINREPO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoEnableUserinRepo' */
                              E121H2 ();
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
                                    E131H2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VWWPUSEREXTENDEDPHOTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VUSERAUTHENTICATIONTYPENAME.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E151H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E161H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E171H2 ();
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

      protected void WE1H2( )
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

      protected void PA1H2( )
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
               GX_FocusControl = cmbavUserauthenticationtypename_Internalname;
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
         if ( cmbavUserauthenticationtypename.ItemCount > 0 )
         {
            AV29UserAuthenticationTypeName = cmbavUserauthenticationtypename.getValidValue(AV29UserAuthenticationTypeName);
            AssignAttri("", false, "AV29UserAuthenticationTypeName", AV29UserAuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUserauthenticationtypename.CurrentValue = StringUtil.RTrim( AV29UserAuthenticationTypeName);
            AssignProp("", false, cmbavUserauthenticationtypename_Internalname, "Values", cmbavUserauthenticationtypename.ToJavascriptSource(), true);
         }
         if ( cmbavUsergender.ItemCount > 0 )
         {
            AV37UserGender = cmbavUsergender.getValidValue(AV37UserGender);
            AssignAttri("", false, "AV37UserGender", AV37UserGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsergender.CurrentValue = StringUtil.RTrim( AV37UserGender);
            AssignProp("", false, cmbavUsergender_Internalname, "Values", cmbavUsergender.ToJavascriptSource(), true);
         }
         AV40UserIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV40UserIsActive));
         AssignAttri("", false, "AV40UserIsActive", AV40UserIsActive);
         AV42UserIsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV42UserIsEnabledInRepository));
         AssignAttri("", false, "AV42UserIsEnabledInRepository", AV42UserIsEnabledInRepository);
         AV33UserDontReceiveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV33UserDontReceiveInformation));
         AssignAttri("", false, "AV33UserDontReceiveInformation", AV33UserDontReceiveInformation);
         AV41UserIsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV41UserIsBlocked));
         AssignAttri("", false, "AV41UserIsBlocked", AV41UserIsBlocked);
         AV31UserCannotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV31UserCannotChangePassword));
         AssignAttri("", false, "AV31UserCannotChangePassword", AV31UserCannotChangePassword);
         AV44UserMustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV44UserMustChangePassword));
         AssignAttri("", false, "AV44UserMustChangePassword", AV44UserMustChangePassword);
         AV48UserPasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV48UserPasswordNeverExpires));
         AssignAttri("", false, "AV48UserPasswordNeverExpires", AV48UserPasswordNeverExpires);
         if ( cmbavUsersecuritypolicyid.ItemCount > 0 )
         {
            AV49UserSecurityPolicyId = (int)(NumberUtil.Val( cmbavUsersecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49UserSecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV49UserSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV49UserSecurityPolicyId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsersecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49UserSecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavUsersecuritypolicyid_Internalname, "Values", cmbavUsersecuritypolicyid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUseractivationdate_Enabled = 0;
         AssignProp("", false, edtavUseractivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseractivationdate_Enabled), 5, 0), true);
         chkavUserisenabledinrepository.Enabled = 0;
         AssignProp("", false, chkavUserisenabledinrepository_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserisenabledinrepository.Enabled), 5, 0), true);
         edtavUserdatelasauthentication_Enabled = 0;
         AssignProp("", false, edtavUserdatelasauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserdatelasauthentication_Enabled), 5, 0), true);
      }

      protected void RF1H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E161H2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E171H2 ();
            WB1H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1H2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.RTrim( AV39UserId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39UserId, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV20Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Language, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavUseractivationdate_Enabled = 0;
         AssignProp("", false, edtavUseractivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseractivationdate_Enabled), 5, 0), true);
         chkavUserisenabledinrepository.Enabled = 0;
         AssignProp("", false, chkavUserisenabledinrepository_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserisenabledinrepository.Enabled), 5, 0), true);
         edtavUserdatelasauthentication_Enabled = 0;
         AssignProp("", false, edtavUserdatelasauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserdatelasauthentication_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            /* Read variables values. */
            cmbavUserauthenticationtypename.CurrentValue = cgiGet( cmbavUserauthenticationtypename_Internalname);
            AV29UserAuthenticationTypeName = cgiGet( cmbavUserauthenticationtypename_Internalname);
            AssignAttri("", false, "AV29UserAuthenticationTypeName", AV29UserAuthenticationTypeName);
            AV45UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV45UserName", AV45UserName);
            AV34UserEmail = cgiGet( edtavUseremail_Internalname);
            AssignAttri("", false, "AV34UserEmail", AV34UserEmail);
            AV36UserFirstName = cgiGet( edtavUserfirstname_Internalname);
            AssignAttri("", false, "AV36UserFirstName", AV36UserFirstName);
            AV43UserLastName = cgiGet( edtavUserlastname_Internalname);
            AssignAttri("", false, "AV43UserLastName", AV43UserLastName);
            AV47UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV47UserPassword", AV47UserPassword);
            AV22PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV22PasswordConf", AV22PasswordConf);
            AV35UserExternalId = cgiGet( edtavUserexternalid_Internalname);
            AssignAttri("", false, "AV35UserExternalId", AV35UserExternalId);
            if ( context.localUtil.VCDate( cgiGet( edtavUserbirthday_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"User Birthday"}), 1, "vUSERBIRTHDAY");
               GX_FocusControl = edtavUserbirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30UserBirthday = DateTime.MinValue;
               AssignAttri("", false, "AV30UserBirthday", context.localUtil.Format(AV30UserBirthday, "99/99/9999"));
            }
            else
            {
               AV30UserBirthday = context.localUtil.CToD( cgiGet( edtavUserbirthday_Internalname), 2);
               AssignAttri("", false, "AV30UserBirthday", context.localUtil.Format(AV30UserBirthday, "99/99/9999"));
            }
            cmbavUsergender.CurrentValue = cgiGet( cmbavUsergender_Internalname);
            AV37UserGender = cgiGet( cmbavUsergender_Internalname);
            AssignAttri("", false, "AV37UserGender", AV37UserGender);
            AV8UserPhone = cgiGet( edtavUserphone_Internalname);
            AssignAttri("", false, "AV8UserPhone", AV8UserPhone);
            AV51UserURLProfile = cgiGet( edtavUserurlprofile_Internalname);
            AssignAttri("", false, "AV51UserURLProfile", AV51UserURLProfile);
            AV50UserURLImage = cgiGet( edtavUserurlimage_Internalname);
            AssignAttri("", false, "AV50UserURLImage", AV50UserURLImage);
            AV7WWPUserExtendedPhoto = cgiGet( edtavWwpuserextendedphoto_Internalname);
            AV40UserIsActive = StringUtil.StrToBool( cgiGet( chkavUserisactive_Internalname));
            AssignAttri("", false, "AV40UserIsActive", AV40UserIsActive);
            if ( context.localUtil.VCDateTime( cgiGet( edtavUseractivationdate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"User Activation Date"}), 1, "vUSERACTIVATIONDATE");
               GX_FocusControl = edtavUseractivationdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28UserActivationDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV28UserActivationDate", context.localUtil.TToC( AV28UserActivationDate, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV28UserActivationDate = context.localUtil.CToT( cgiGet( edtavUseractivationdate_Internalname));
               AssignAttri("", false, "AV28UserActivationDate", context.localUtil.TToC( AV28UserActivationDate, 10, 5, 0, 3, "/", ":", " "));
            }
            AV42UserIsEnabledInRepository = StringUtil.StrToBool( cgiGet( chkavUserisenabledinrepository_Internalname));
            AssignAttri("", false, "AV42UserIsEnabledInRepository", AV42UserIsEnabledInRepository);
            if ( context.localUtil.VCDateTime( cgiGet( edtavUserdatelasauthentication_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"User Date Las Authentication"}), 1, "vUSERDATELASAUTHENTICATION");
               GX_FocusControl = edtavUserdatelasauthentication_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32UserDateLasAuthentication = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV32UserDateLasAuthentication", context.localUtil.TToC( AV32UserDateLasAuthentication, 10, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV32UserDateLasAuthentication = context.localUtil.CToT( cgiGet( edtavUserdatelasauthentication_Internalname));
               AssignAttri("", false, "AV32UserDateLasAuthentication", context.localUtil.TToC( AV32UserDateLasAuthentication, 10, 5, 0, 3, "/", ":", " "));
            }
            AV33UserDontReceiveInformation = StringUtil.StrToBool( cgiGet( chkavUserdontreceiveinformation_Internalname));
            AssignAttri("", false, "AV33UserDontReceiveInformation", AV33UserDontReceiveInformation);
            AV41UserIsBlocked = StringUtil.StrToBool( cgiGet( chkavUserisblocked_Internalname));
            AssignAttri("", false, "AV41UserIsBlocked", AV41UserIsBlocked);
            AV31UserCannotChangePassword = StringUtil.StrToBool( cgiGet( chkavUsercannotchangepassword_Internalname));
            AssignAttri("", false, "AV31UserCannotChangePassword", AV31UserCannotChangePassword);
            AV44UserMustChangePassword = StringUtil.StrToBool( cgiGet( chkavUsermustchangepassword_Internalname));
            AssignAttri("", false, "AV44UserMustChangePassword", AV44UserMustChangePassword);
            AV48UserPasswordNeverExpires = StringUtil.StrToBool( cgiGet( chkavUserpasswordneverexpires_Internalname));
            AssignAttri("", false, "AV48UserPasswordNeverExpires", AV48UserPasswordNeverExpires);
            cmbavUsersecuritypolicyid.CurrentValue = cgiGet( cmbavUsersecuritypolicyid_Internalname);
            AV49UserSecurityPolicyId = (int)(NumberUtil.Val( cgiGet( cmbavUsersecuritypolicyid_Internalname), "."));
            AssignAttri("", false, "AV49UserSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV49UserSecurityPolicyId), 9, 0));
            AV27User.gxTpr_Isenabledinrepository = StringUtil.StrToBool( cgiGet( chkavUser_isenabledinrepository_Internalname));
            AV38UserGUID = cgiGet( edtavUserguid_Internalname);
            AssignAttri("", false, "AV38UserGUID", AV38UserGUID);
            AV46UserNameSpace = cgiGet( edtavUsernamespace_Internalname);
            AssignAttri("", false, "AV46UserNameSpace", AV46UserNameSpace);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7WWPUserExtendedPhoto)) )
            {
               GXCCtlgxBlob = "vWWPUSEREXTENDEDPHOTO" + "_gxBlob";
               AV7WWPUserExtendedPhoto = cgiGet( GXCCtlgxBlob);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"GAMUserEntry");
            AV28UserActivationDate = context.localUtil.CToT( cgiGet( edtavUseractivationdate_Internalname));
            AssignAttri("", false, "AV28UserActivationDate", context.localUtil.TToC( AV28UserActivationDate, 10, 5, 0, 3, "/", ":", " "));
            forbiddenHiddens.Add("UserActivationDate", context.localUtil.Format( AV28UserActivationDate, "99/99/9999 99:99"));
            AV42UserIsEnabledInRepository = StringUtil.StrToBool( cgiGet( chkavUserisenabledinrepository_Internalname));
            AssignAttri("", false, "AV42UserIsEnabledInRepository", AV42UserIsEnabledInRepository);
            forbiddenHiddens.Add("UserIsEnabledInRepository", StringUtil.BoolToStr( AV42UserIsEnabledInRepository));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("gamuserentry:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E111H2 ();
         if (returnInSub) return;
      }

      protected void E111H2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV24Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         cmbavUserauthenticationtypename.removeAllItems();
         AV11AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV20Language, out  AV16Errors);
         AV63GXV2 = 1;
         while ( AV63GXV2 <= AV11AuthenticationTypes.Count )
         {
            AV12AuthenticationTypesIns = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV11AuthenticationTypes.Item(AV63GXV2));
            cmbavUserauthenticationtypename.addItem(AV12AuthenticationTypesIns.gxTpr_Name, AV12AuthenticationTypesIns.gxTpr_Description, 0);
            AV63GXV2 = (int)(AV63GXV2+1);
         }
         AV25SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV17FilterSecPol, out  AV16Errors);
         cmbavUsersecuritypolicyid.addItem("0", "(Nenhum)", 0);
         AV64GXV3 = 1;
         while ( AV64GXV3 <= AV25SecurityPolicies.Count )
         {
            AV26SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV25SecurityPolicies.Item(AV64GXV3));
            cmbavUsersecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV26SecurityPolicy.gxTpr_Id), 9, 0)), AV26SecurityPolicy.gxTpr_Name, 0);
            AV64GXV3 = (int)(AV64GXV3+1);
         }
         bttBtnenableuserinrepo_Visible = 0;
         AssignProp("", false, bttBtnenableuserinrepo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenableuserinrepo_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            cmbavUserauthenticationtypename.Enabled = 1;
            AssignProp("", false, cmbavUserauthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUserauthenticationtypename.Enabled), 5, 0), true);
            AV29UserAuthenticationTypeName = "local";
            AssignAttri("", false, "AV29UserAuthenticationTypeName", AV29UserAuthenticationTypeName);
            AV46UserNameSpace = AV24Repository.gxTpr_Namespace;
            AssignAttri("", false, "AV46UserNameSpace", AV46UserNameSpace);
            imgUserphoto_Visible = 0;
            AssignProp("", false, imgUserphoto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUserphoto_Visible), 5, 0), true);
         }
         else
         {
            AV27User.load( AV39UserId);
            AV38UserGUID = AV27User.gxTpr_Guid;
            AssignAttri("", false, "AV38UserGUID", AV38UserGUID);
            AV46UserNameSpace = AV27User.gxTpr_Namespace;
            AssignAttri("", false, "AV46UserNameSpace", AV46UserNameSpace);
            AV29UserAuthenticationTypeName = AV27User.gxTpr_Authenticationtypename;
            AssignAttri("", false, "AV29UserAuthenticationTypeName", AV29UserAuthenticationTypeName);
            AV45UserName = AV27User.gxTpr_Name;
            AssignAttri("", false, "AV45UserName", AV45UserName);
            AV34UserEmail = AV27User.gxTpr_Email;
            AssignAttri("", false, "AV34UserEmail", AV34UserEmail);
            AV36UserFirstName = AV27User.gxTpr_Firstname;
            AssignAttri("", false, "AV36UserFirstName", AV36UserFirstName);
            AV43UserLastName = AV27User.gxTpr_Lastname;
            AssignAttri("", false, "AV43UserLastName", AV43UserLastName);
            AV35UserExternalId = AV27User.gxTpr_Externalid;
            AssignAttri("", false, "AV35UserExternalId", AV35UserExternalId);
            AV30UserBirthday = AV27User.gxTpr_Birthday;
            AssignAttri("", false, "AV30UserBirthday", context.localUtil.Format(AV30UserBirthday, "99/99/9999"));
            AV37UserGender = AV27User.gxTpr_Gender;
            AssignAttri("", false, "AV37UserGender", AV37UserGender);
            AV51UserURLProfile = AV27User.gxTpr_Urlprofile;
            AssignAttri("", false, "AV51UserURLProfile", AV51UserURLProfile);
            AV50UserURLImage = AV27User.gxTpr_Urlimage;
            AssignAttri("", false, "AV50UserURLImage", AV50UserURLImage);
            AV40UserIsActive = AV27User.gxTpr_Isactive;
            AssignAttri("", false, "AV40UserIsActive", AV40UserIsActive);
            AV28UserActivationDate = AV27User.gxTpr_Activationdate;
            AssignAttri("", false, "AV28UserActivationDate", context.localUtil.TToC( AV28UserActivationDate, 10, 5, 0, 3, "/", ":", " "));
            AV42UserIsEnabledInRepository = AV27User.gxTpr_Isenabledinrepository;
            AssignAttri("", false, "AV42UserIsEnabledInRepository", AV42UserIsEnabledInRepository);
            AV33UserDontReceiveInformation = AV27User.gxTpr_Dontreceiveinformation;
            AssignAttri("", false, "AV33UserDontReceiveInformation", AV33UserDontReceiveInformation);
            AV41UserIsBlocked = AV27User.gxTpr_Isblocked;
            AssignAttri("", false, "AV41UserIsBlocked", AV41UserIsBlocked);
            AV31UserCannotChangePassword = AV27User.gxTpr_Cannotchangepassword;
            AssignAttri("", false, "AV31UserCannotChangePassword", AV31UserCannotChangePassword);
            AV44UserMustChangePassword = AV27User.gxTpr_Mustchangepassword;
            AssignAttri("", false, "AV44UserMustChangePassword", AV44UserMustChangePassword);
            AV48UserPasswordNeverExpires = AV27User.gxTpr_Passwordneverexpires;
            AssignAttri("", false, "AV48UserPasswordNeverExpires", AV48UserPasswordNeverExpires);
            AV49UserSecurityPolicyId = AV27User.gxTpr_Securitypolicyid;
            AssignAttri("", false, "AV49UserSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV49UserSecurityPolicyId), 9, 0));
            AV47UserPassword = AV27User.gxTpr_Password;
            AssignAttri("", false, "AV47UserPassword", AV47UserPassword);
            AV32UserDateLasAuthentication = AV27User.gxTpr_Datelastauthentication;
            AssignAttri("", false, "AV32UserDateLasAuthentication", context.localUtil.TToC( AV32UserDateLasAuthentication, 10, 5, 0, 3, "/", ":", " "));
            AV8UserPhone = AV27User.gxTpr_Phone;
            AssignAttri("", false, "AV8UserPhone", AV8UserPhone);
            cmbavUserauthenticationtypename.Enabled = 0;
            AssignProp("", false, cmbavUserauthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUserauthenticationtypename.Enabled), 5, 0), true);
            AV13AuthTypeId = AV9AuthenticationType.gettypebyname(AV10AuthenticationTypeName, out  AV16Errors);
            if ( StringUtil.StrCmp(AV13AuthTypeId, "GAMLocal") == 0 )
            {
               edtavUsername_Enabled = 1;
               AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
            }
            else
            {
               edtavUsername_Enabled = 0;
               AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
            }
            AV6WWPUserExtended.Load(AV27User.gxTpr_Guid);
            if ( AV6WWPUserExtended.Success() )
            {
               if ( StringUtil.StrCmp(AV6WWPUserExtended.gxTpr_Wwpuserextendedphoto_gxi, "") != 0 )
               {
                  imgUserphoto_Bitmap = AV6WWPUserExtended.gxTpr_Wwpuserextendedphoto_gxi;
                  AssignProp("", false, imgUserphoto_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgUserphoto_Bitmap)), true);
                  AssignProp("", false, imgUserphoto_Internalname, "SrcSet", context.GetImageSrcSet( imgUserphoto_Bitmap), true);
               }
               else
               {
                  imgUserphoto_Visible = 0;
                  AssignProp("", false, imgUserphoto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUserphoto_Visible), 5, 0), true);
               }
            }
            else
            {
               imgUserphoto_Visible = 0;
               AssignProp("", false, imgUserphoto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUserphoto_Visible), 5, 0), true);
            }
            bttBtnenableuserinrepo_Caption = (AV42UserIsEnabledInRepository ? "Disable" : "Enable");
            AssignProp("", false, bttBtnenableuserinrepo_Internalname, "Caption", bttBtnenableuserinrepo_Caption, true);
         }
         if ( AV18IsActive )
         {
            chkavUserisactive.Enabled = 0;
            AssignProp("", false, chkavUserisactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserisactive.Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            bttBtnenableuserinrepo_Visible = 1;
            AssignProp("", false, bttBtnenableuserinrepo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenableuserinrepo_Visible), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavUsername_Enabled = 0;
            AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
            edtavUseremail_Enabled = 0;
            AssignProp("", false, edtavUseremail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseremail_Enabled), 5, 0), true);
            edtavUserfirstname_Enabled = 0;
            AssignProp("", false, edtavUserfirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserfirstname_Enabled), 5, 0), true);
            edtavUserlastname_Enabled = 0;
            AssignProp("", false, edtavUserlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserlastname_Enabled), 5, 0), true);
            edtavUserurlprofile_Enabled = 0;
            AssignProp("", false, edtavUserurlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserurlprofile_Enabled), 5, 0), true);
            edtavUserurlimage_Enabled = 0;
            AssignProp("", false, edtavUserurlimage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserurlimage_Enabled), 5, 0), true);
            edtavUserexternalid_Enabled = 0;
            AssignProp("", false, edtavUserexternalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserexternalid_Enabled), 5, 0), true);
            edtavUserbirthday_Enabled = 0;
            AssignProp("", false, edtavUserbirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserbirthday_Enabled), 5, 0), true);
            cmbavUsergender.Enabled = 0;
            AssignProp("", false, cmbavUsergender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsergender.Enabled), 5, 0), true);
            chkavUserisactive.Enabled = 0;
            AssignProp("", false, chkavUserisactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserisactive.Enabled), 5, 0), true);
            chkavUserdontreceiveinformation.Enabled = 0;
            AssignProp("", false, chkavUserdontreceiveinformation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserdontreceiveinformation.Enabled), 5, 0), true);
            chkavUsercannotchangepassword.Enabled = 0;
            AssignProp("", false, chkavUsercannotchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUsercannotchangepassword.Enabled), 5, 0), true);
            chkavUsermustchangepassword.Enabled = 0;
            AssignProp("", false, chkavUsermustchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUsermustchangepassword.Enabled), 5, 0), true);
            chkavUserisblocked.Enabled = 0;
            AssignProp("", false, chkavUserisblocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserisblocked.Enabled), 5, 0), true);
            chkavUserpasswordneverexpires.Enabled = 0;
            AssignProp("", false, chkavUserpasswordneverexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserpasswordneverexpires.Enabled), 5, 0), true);
            cmbavUsersecuritypolicyid.Enabled = 0;
            AssignProp("", false, cmbavUsersecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsersecuritypolicyid.Enabled), 5, 0), true);
            edtavUserphone_Enabled = 0;
            AssignProp("", false, edtavUserphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserphone_Enabled), 5, 0), true);
            edtavWwpuserextendedphoto_Enabled = 0;
            AssignProp("", false, edtavWwpuserextendedphoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpuserextendedphoto_Enabled), 5, 0), true);
            bttBtnenter_Caption = "Delete";
            AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         chkavUser_isenabledinrepository.Visible = 0;
         AssignProp("", false, chkavUser_isenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUser_isenabledinrepository.Visible), 5, 0), true);
         edtavUserguid_Visible = 0;
         AssignProp("", false, edtavUserguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserguid_Visible), 5, 0), true);
         edtavUsernamespace_Visible = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Visible), 5, 0), true);
      }

      protected void E121H2( )
      {
         /* 'DoEnableUserinRepo' Routine */
         returnInSub = false;
         AV27User.load( AV39UserId);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            if ( AV42UserIsEnabledInRepository )
            {
               AV19isOK = AV27User.repositorydisable(out  AV16Errors);
            }
            else
            {
               AV19isOK = AV27User.repositoryenable(out  AV16Errors);
            }
            if ( ! AV19isOK )
            {
               AV65GXV4 = 1;
               while ( AV65GXV4 <= AV16Errors.Count )
               {
                  AV15Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV16Errors.Item(AV65GXV4));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV15Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV15Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV65GXV4 = (int)(AV65GXV4+1);
               }
            }
            else
            {
               context.CommitDataStores("gamuserentry",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV39UserId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV39UserId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27User", AV27User);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV24Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV14CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45UserName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome de usuário", "", "", "", "", "", "", "", ""),  "error",  edtavUsername_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
         if ( ( AV24Repository.gxTpr_Requiredemail ) && String.IsNullOrEmpty(StringUtil.RTrim( AV34UserEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavUseremail_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
         if ( ( AV24Repository.gxTpr_Requiredfirstname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV36UserFirstName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavUserfirstname_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
         if ( ( AV24Repository.gxTpr_Requiredlastname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV43UserLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Sobrenome", "", "", "", "", "", "", "", ""),  "error",  edtavUserlastname_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
         if ( ( AV24Repository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV47UserPassword)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Senha", "", "", "", "", "", "", "", ""),  "error",  edtavUserpassword_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
         if ( ( AV24Repository.gxTpr_Requiredbirthday ) && (DateTime.MinValue==AV30UserBirthday) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Data de nascimento", "", "", "", "", "", "", "", ""),  "error",  edtavUserbirthday_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
         if ( ( AV24Repository.gxTpr_Requiredgender ) && String.IsNullOrEmpty(StringUtil.RTrim( AV37UserGender)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Sexo", "", "", "", "", "", "", "", ""),  "error",  cmbavUsergender_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
         if ( ( AV24Repository.gxTpr_Requiredgender ) && String.IsNullOrEmpty(StringUtil.RTrim( AV8UserPhone)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Telefone", "", "", "", "", "", "", "", ""),  "error",  edtavUserphone_Internalname,  "true",  ""));
            AV14CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         AV24Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV13AuthTypeId = AV9AuthenticationType.gettypebyname(AV29UserAuthenticationTypeName, out  AV16Errors);
         if ( ! ( ( cmbavUserauthenticationtypename.ItemCount > 1 ) ) )
         {
            cmbavUserauthenticationtypename.Visible = 0;
            AssignProp("", false, cmbavUserauthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUserauthenticationtypename.Visible), 5, 0), true);
            divUserauthenticationtypename_cell_Class = "Invisible";
            AssignProp("", false, divUserauthenticationtypename_cell_Internalname, "Class", divUserauthenticationtypename_cell_Class, true);
         }
         else
         {
            cmbavUserauthenticationtypename.Visible = 1;
            AssignProp("", false, cmbavUserauthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUserauthenticationtypename.Visible), 5, 0), true);
            divUserauthenticationtypename_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserauthenticationtypename_cell_Internalname, "Class", divUserauthenticationtypename_cell_Class, true);
         }
         if ( AV24Repository.gxTpr_Requiredemail )
         {
            divUseremail_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divUseremail_cell_Internalname, "Class", divUseremail_cell_Class, true);
         }
         else
         {
            divUseremail_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUseremail_cell_Internalname, "Class", divUseremail_cell_Class, true);
         }
         if ( AV24Repository.gxTpr_Requiredfirstname )
         {
            divUserfirstname_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divUserfirstname_cell_Internalname, "Class", divUserfirstname_cell_Class, true);
         }
         else
         {
            divUserfirstname_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserfirstname_cell_Internalname, "Class", divUserfirstname_cell_Class, true);
         }
         if ( AV24Repository.gxTpr_Requiredlastname )
         {
            divUserlastname_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divUserlastname_cell_Internalname, "Class", divUserlastname_cell_Class, true);
         }
         else
         {
            divUserlastname_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserlastname_cell_Internalname, "Class", divUserlastname_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV13AuthTypeId, "GAMLocal") == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) )
         {
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            divUserpassword_cell_Class = "Invisible";
            AssignProp("", false, divUserpassword_cell_Internalname, "Class", divUserpassword_cell_Class, true);
         }
         else
         {
            edtavUserpassword_Visible = 1;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            if ( AV24Repository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               divUserpassword_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
               AssignProp("", false, divUserpassword_cell_Internalname, "Class", divUserpassword_cell_Class, true);
            }
            else
            {
               divUserpassword_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
               AssignProp("", false, divUserpassword_cell_Internalname, "Class", divUserpassword_cell_Class, true);
            }
         }
         if ( ! ( ( StringUtil.StrCmp(AV13AuthTypeId, "GAMLocal") == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) )
         {
            edtavPasswordconf_Visible = 0;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            divPasswordconf_cell_Class = "Invisible";
            AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
         }
         else
         {
            edtavPasswordconf_Visible = 1;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            divPasswordconf_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
         }
         if ( AV24Repository.gxTpr_Requiredbirthday )
         {
            divUserbirthday_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divUserbirthday_cell_Internalname, "Class", divUserbirthday_cell_Class, true);
         }
         else
         {
            divUserbirthday_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserbirthday_cell_Internalname, "Class", divUserbirthday_cell_Class, true);
         }
         if ( AV24Repository.gxTpr_Requiredgender )
         {
            divUsergender_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divUsergender_cell_Internalname, "Class", divUsergender_cell_Class, true);
         }
         else
         {
            divUsergender_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUsergender_cell_Internalname, "Class", divUsergender_cell_Class, true);
         }
         if ( AV24Repository.gxTpr_Requiredgender )
         {
            divUserphone_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divUserphone_cell_Internalname, "Class", divUserphone_cell_Class, true);
         }
         else
         {
            divUserphone_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserphone_cell_Internalname, "Class", divUserphone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavUserurlprofile_Visible = 0;
            AssignProp("", false, edtavUserurlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserurlprofile_Visible), 5, 0), true);
            divUserurlprofile_cell_Class = "Invisible";
            AssignProp("", false, divUserurlprofile_cell_Internalname, "Class", divUserurlprofile_cell_Class, true);
         }
         else
         {
            edtavUserurlprofile_Visible = 1;
            AssignProp("", false, edtavUserurlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserurlprofile_Visible), 5, 0), true);
            divUserurlprofile_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserurlprofile_cell_Internalname, "Class", divUserurlprofile_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavUserurlimage_Visible = 0;
            AssignProp("", false, edtavUserurlimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserurlimage_Visible), 5, 0), true);
            divUserurlimage_cell_Class = "Invisible";
            AssignProp("", false, divUserurlimage_cell_Internalname, "Class", divUserurlimage_cell_Class, true);
         }
         else
         {
            edtavUserurlimage_Visible = 1;
            AssignProp("", false, edtavUserurlimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserurlimage_Visible), 5, 0), true);
            divUserurlimage_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserurlimage_cell_Internalname, "Class", divUserurlimage_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            chkavUserisactive.Visible = 0;
            AssignProp("", false, chkavUserisactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUserisactive.Visible), 5, 0), true);
            divUserisactive_cell_Class = "Invisible";
            AssignProp("", false, divUserisactive_cell_Internalname, "Class", divUserisactive_cell_Class, true);
         }
         else
         {
            chkavUserisactive.Visible = 1;
            AssignProp("", false, chkavUserisactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUserisactive.Visible), 5, 0), true);
            divUserisactive_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserisactive_cell_Internalname, "Class", divUserisactive_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavUseractivationdate_Visible = 0;
            AssignProp("", false, edtavUseractivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseractivationdate_Visible), 5, 0), true);
            divUseractivationdate_cell_Class = "Invisible";
            AssignProp("", false, divUseractivationdate_cell_Internalname, "Class", divUseractivationdate_cell_Class, true);
         }
         else
         {
            edtavUseractivationdate_Visible = 1;
            AssignProp("", false, edtavUseractivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseractivationdate_Visible), 5, 0), true);
            divUseractivationdate_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUseractivationdate_cell_Internalname, "Class", divUseractivationdate_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            chkavUserisenabledinrepository.Visible = 0;
            AssignProp("", false, chkavUserisenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUserisenabledinrepository.Visible), 5, 0), true);
            cellUserisenabledinrepository_cell_Class = "Invisible";
            AssignProp("", false, cellUserisenabledinrepository_cell_Internalname, "Class", cellUserisenabledinrepository_cell_Class, true);
            divTextblockuserisenabledinrepository_cell_Class = "Invisible";
            AssignProp("", false, divTextblockuserisenabledinrepository_cell_Internalname, "Class", divTextblockuserisenabledinrepository_cell_Class, true);
         }
         else
         {
            chkavUserisenabledinrepository.Visible = 1;
            AssignProp("", false, chkavUserisenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUserisenabledinrepository.Visible), 5, 0), true);
            cellUserisenabledinrepository_cell_Class = "MergeDataCell";
            AssignProp("", false, cellUserisenabledinrepository_cell_Internalname, "Class", cellUserisenabledinrepository_cell_Class, true);
            divTextblockuserisenabledinrepository_cell_Class = "col-sm-12 MergeLabelCell";
            AssignProp("", false, divTextblockuserisenabledinrepository_cell_Internalname, "Class", divTextblockuserisenabledinrepository_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavUserdatelasauthentication_Visible = 0;
            AssignProp("", false, edtavUserdatelasauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserdatelasauthentication_Visible), 5, 0), true);
            divUserdatelasauthentication_cell_Class = "Invisible";
            AssignProp("", false, divUserdatelasauthentication_cell_Internalname, "Class", divUserdatelasauthentication_cell_Class, true);
         }
         else
         {
            edtavUserdatelasauthentication_Visible = 1;
            AssignProp("", false, edtavUserdatelasauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserdatelasauthentication_Visible), 5, 0), true);
            divUserdatelasauthentication_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divUserdatelasauthentication_cell_Internalname, "Class", divUserdatelasauthentication_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E131H2 ();
         if (returnInSub) return;
      }

      protected void E131H2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV14CheckRequiredFieldsResult )
         {
            AV27User.gxTpr_Guid = AV39UserId;
            AV23PasswordIsOK = true;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV52AuthenticationTypesI = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV20Language, out  AV16Errors);
                  AV66GXV5 = 1;
                  while ( AV66GXV5 <= AV52AuthenticationTypesI.Count )
                  {
                     AV12AuthenticationTypesIns = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV52AuthenticationTypesI.Item(AV66GXV5));
                     if ( StringUtil.StrCmp(AV12AuthenticationTypesIns.gxTpr_Description, AV29UserAuthenticationTypeName) == 0 )
                     {
                        AV53UserAuthenticationTypeT = AV12AuthenticationTypesIns.gxTpr_Type;
                        AssignAttri("", false, "AV53UserAuthenticationTypeT", AV53UserAuthenticationTypeT);
                     }
                     AV66GXV5 = (int)(AV66GXV5+1);
                  }
                  if ( StringUtil.StrCmp(AV53UserAuthenticationTypeT, "GAMLocal") == 0 )
                  {
                     if ( StringUtil.StrCmp(AV47UserPassword, AV22PasswordConf) != 0 )
                     {
                        AV23PasswordIsOK = false;
                        GX_msglist.addItem("A senha não coincide com a confirmação");
                     }
                  }
                  else
                  {
                     AV21Password = "";
                     AssignAttri("", false, "AV21Password", AV21Password);
                  }
               }
               if ( AV23PasswordIsOK )
               {
                  AV27User.load( AV39UserId);
                  AV27User.gxTpr_Authenticationtypename = AV29UserAuthenticationTypeName;
                  AV27User.gxTpr_Name = AV45UserName;
                  AV27User.gxTpr_Email = AV34UserEmail;
                  AV27User.gxTpr_Firstname = AV36UserFirstName;
                  AV27User.gxTpr_Lastname = AV43UserLastName;
                  AV27User.gxTpr_Externalid = AV35UserExternalId;
                  AV27User.gxTpr_Birthday = AV30UserBirthday;
                  AV27User.gxTpr_Gender = AV37UserGender;
                  AV27User.gxTpr_Urlprofile = AV51UserURLProfile;
                  AV27User.gxTpr_Urlimage = AV50UserURLImage;
                  AV27User.gxTpr_Isactive = AV40UserIsActive;
                  AV27User.gxTpr_Activationdate = AV28UserActivationDate;
                  AV27User.gxTpr_Isenabledinrepository = AV42UserIsEnabledInRepository;
                  AV27User.gxTpr_Dontreceiveinformation = AV33UserDontReceiveInformation;
                  AV27User.gxTpr_Isblocked = AV41UserIsBlocked;
                  AV27User.gxTpr_Cannotchangepassword = AV31UserCannotChangePassword;
                  AV27User.gxTpr_Mustchangepassword = AV44UserMustChangePassword;
                  AV27User.gxTpr_Passwordneverexpires = AV48UserPasswordNeverExpires;
                  AV27User.gxTpr_Securitypolicyid = AV49UserSecurityPolicyId;
                  AV27User.gxTpr_Password = AV47UserPassword;
                  AV27User.gxTpr_Phone = AV8UserPhone;
                  AV27User.save();
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV27User.delete();
            }
            if ( AV23PasswordIsOK )
            {
               if ( AV27User.success() )
               {
                  if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
                  {
                     new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended(context ).execute(  AV27User.gxTpr_Guid,  AV7WWPUserExtendedPhoto) ;
                  }
                  else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     new GeneXus.Programs.wwpbaseobjects.wwp_updateuserextendedphoto(context ).execute(  AV27User.gxTpr_Guid,  AV7WWPUserExtendedPhoto) ;
                  }
                  context.CommitDataStores("gamuserentry",pr_default);
                  context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV39UserId});
                  context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV39UserId"});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
               else
               {
                  AV16Errors = AV27User.geterrors();
                  AV67GXV6 = 1;
                  while ( AV67GXV6 <= AV16Errors.Count )
                  {
                     AV15Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV16Errors.Item(AV67GXV6));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV15Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV15Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV67GXV6 = (int)(AV67GXV6+1);
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27User", AV27User);
      }

      protected void E141H2( )
      {
         /* Wwpuserextendedphoto_Controlvaluechanged Routine */
         returnInSub = false;
         AV14CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
         /* Execute user subroutine: 'CHECKEXTENSIONIMAGE' */
         S132 ();
         if (returnInSub) return;
         if ( AV14CheckRequiredFieldsResult )
         {
            if ( StringUtil.StrCmp(AV7WWPUserExtendedPhoto, "") != 0 )
            {
               imgUserphoto_Visible = 0;
               AssignProp("", false, imgUserphoto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgUserphoto_Visible), 5, 0), true);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E151H2( )
      {
         /* Userauthenticationtypename_Isvalid Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E161H2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            edtavUserurlprofile_Linktarget = "_blank";
            AssignProp("", false, edtavUserurlprofile_Internalname, "Linktarget", edtavUserurlprofile_Linktarget, true);
            edtavUserurlprofile_Link = formatLink(AV51UserURLProfile) ;
            AssignProp("", false, edtavUserurlprofile_Internalname, "Link", edtavUserurlprofile_Link, true);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKEXTENSIONIMAGE' Routine */
         returnInSub = false;
         if ( AV7WWPUserExtendedPhoto.Length != 0 )
         {
            AV5WWPUserExtendedPhotoExtension = AV7WWPUserExtendedPhoto;
            AV5WWPUserExtendedPhotoExtension = StringUtil.Upper( StringUtil.Substring( AV5WWPUserExtendedPhotoExtension, StringUtil.StringSearchRev( AV5WWPUserExtendedPhotoExtension, ".", -1)+1, -1));
            if ( ( StringUtil.StrCmp(AV5WWPUserExtendedPhotoExtension, "JPEG") != 0 ) && ( StringUtil.StrCmp(AV5WWPUserExtendedPhotoExtension, "JPG") != 0 ) && ( StringUtil.StrCmp(AV5WWPUserExtendedPhotoExtension, "PNG") != 0 ) && ( StringUtil.StrCmp(AV5WWPUserExtendedPhotoExtension, "GIF") != 0 ) )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Invalid User Photo File Type",  "error",  edtavWwpuserextendedphoto_Internalname,  "true",  ""));
               AV14CheckRequiredFieldsResult = false;
               AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E171H2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_106_1H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeduserisenabledinrepository_Internalname, tblTablemergeduserisenabledinrepository_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellUserisenabledinrepository_cell_Internalname+"\"  class='"+cellUserisenabledinrepository_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserisenabledinrepository_Internalname, "User Is Enabled In Repository", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserisenabledinrepository_Internalname, StringUtil.BoolToStr( AV42UserIsEnabledInRepository), "", "User Is Enabled In Repository", chkavUserisenabledinrepository.Visible, chkavUserisenabledinrepository.Enabled, "true", "Você está habilitado no repositório?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(110, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,110);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenableuserinrepo_Internalname, "", bttBtnenableuserinrepo_Caption, bttBtnenableuserinrepo_Jsonclick, 5, "Habilitar", "", StyleString, ClassString, bttBtnenableuserinrepo_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOENABLEUSERINREPO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_106_1H2e( true) ;
         }
         else
         {
            wb_table2_106_1H2e( false) ;
         }
      }

      protected void wb_table1_84_1H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedwwpuserextendedphoto_Internalname, tblTablemergedwwpuserextendedphoto_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWwpuserextendedphoto_Internalname, "WWPUser Extended Photo", "gx-form-item AttributeLabel HideBlobContentLabel", 0, true, "width: 25%;");
            ClassString = "Attribute HideBlobContent";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            edtavWwpuserextendedphoto_Filetype = "tmp";
            AssignProp("", false, edtavWwpuserextendedphoto_Internalname, "Filetype", edtavWwpuserextendedphoto_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7WWPUserExtendedPhoto)) )
            {
               gxblobfileaux.Source = AV7WWPUserExtendedPhoto;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavWwpuserextendedphoto_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavWwpuserextendedphoto_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV7WWPUserExtendedPhoto = gxblobfileaux.GetURI();
                  AssignProp("", false, edtavWwpuserextendedphoto_Internalname, "URL", context.PathToRelativeUrl( AV7WWPUserExtendedPhoto), true);
                  edtavWwpuserextendedphoto_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtavWwpuserextendedphoto_Internalname, "Filetype", edtavWwpuserextendedphoto_Filetype, true);
               }
               AssignProp("", false, edtavWwpuserextendedphoto_Internalname, "URL", context.PathToRelativeUrl( AV7WWPUserExtendedPhoto), true);
            }
            GxWebStd.gx_blob_field( context, edtavWwpuserextendedphoto_Internalname, StringUtil.RTrim( AV7WWPUserExtendedPhoto), context.PathToRelativeUrl( AV7WWPUserExtendedPhoto), (String.IsNullOrEmpty(StringUtil.RTrim( edtavWwpuserextendedphoto_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavWwpuserextendedphoto_Filetype)) ? AV7WWPUserExtendedPhoto : edtavWwpuserextendedphoto_Filetype)) : edtavWwpuserextendedphoto_Contenttype), false, "", edtavWwpuserextendedphoto_Parameters, 0, edtavWwpuserextendedphoto_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavWwpuserextendedphoto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "ExtendedUserPhoto";
            StyleString = "";
            sImgUrl = imgUserphoto_Bitmap;
            GxWebStd.gx_bitmap( context, imgUserphoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgUserphoto_Visible, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMUserEntry.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_84_1H2e( true) ;
         }
         else
         {
            wb_table1_84_1H2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV39UserId = (string)getParm(obj,1);
         AssignAttri("", false, "AV39UserId", AV39UserId);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV39UserId, "")), context));
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
         PA1H2( ) ;
         WS1H2( ) ;
         WE1H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815543241", true, true);
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
         context.AddJavascriptSource("gamuserentry.js", "?202142815543245", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavUserauthenticationtypename.Name = "vUSERAUTHENTICATIONTYPENAME";
         cmbavUserauthenticationtypename.WebTags = "";
         if ( cmbavUserauthenticationtypename.ItemCount > 0 )
         {
            AV29UserAuthenticationTypeName = cmbavUserauthenticationtypename.getValidValue(AV29UserAuthenticationTypeName);
            AssignAttri("", false, "AV29UserAuthenticationTypeName", AV29UserAuthenticationTypeName);
         }
         cmbavUsergender.Name = "vUSERGENDER";
         cmbavUsergender.WebTags = "";
         cmbavUsergender.addItem("N", "Não especificado", 0);
         cmbavUsergender.addItem("F", "Feminino", 0);
         cmbavUsergender.addItem("M", "Masculino", 0);
         if ( cmbavUsergender.ItemCount > 0 )
         {
            AV37UserGender = cmbavUsergender.getValidValue(AV37UserGender);
            AssignAttri("", false, "AV37UserGender", AV37UserGender);
         }
         chkavUserisactive.Name = "vUSERISACTIVE";
         chkavUserisactive.WebTags = "";
         chkavUserisactive.Caption = "Ativo?";
         AssignProp("", false, chkavUserisactive_Internalname, "TitleCaption", chkavUserisactive.Caption, true);
         chkavUserisactive.CheckedValue = "false";
         AV40UserIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV40UserIsActive));
         AssignAttri("", false, "AV40UserIsActive", AV40UserIsActive);
         chkavUserisenabledinrepository.Name = "vUSERISENABLEDINREPOSITORY";
         chkavUserisenabledinrepository.WebTags = "";
         chkavUserisenabledinrepository.Caption = "Você está habilitado no repositório?";
         AssignProp("", false, chkavUserisenabledinrepository_Internalname, "TitleCaption", chkavUserisenabledinrepository.Caption, true);
         chkavUserisenabledinrepository.CheckedValue = "false";
         AV42UserIsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV42UserIsEnabledInRepository));
         AssignAttri("", false, "AV42UserIsEnabledInRepository", AV42UserIsEnabledInRepository);
         chkavUserdontreceiveinformation.Name = "vUSERDONTRECEIVEINFORMATION";
         chkavUserdontreceiveinformation.WebTags = "";
         chkavUserdontreceiveinformation.Caption = "Eu não desejo receber informação";
         AssignProp("", false, chkavUserdontreceiveinformation_Internalname, "TitleCaption", chkavUserdontreceiveinformation.Caption, true);
         chkavUserdontreceiveinformation.CheckedValue = "false";
         AV33UserDontReceiveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV33UserDontReceiveInformation));
         AssignAttri("", false, "AV33UserDontReceiveInformation", AV33UserDontReceiveInformation);
         chkavUserisblocked.Name = "vUSERISBLOCKED";
         chkavUserisblocked.WebTags = "";
         chkavUserisblocked.Caption = "Está bloqueado?";
         AssignProp("", false, chkavUserisblocked_Internalname, "TitleCaption", chkavUserisblocked.Caption, true);
         chkavUserisblocked.CheckedValue = "false";
         AV41UserIsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV41UserIsBlocked));
         AssignAttri("", false, "AV41UserIsBlocked", AV41UserIsBlocked);
         chkavUsercannotchangepassword.Name = "vUSERCANNOTCHANGEPASSWORD";
         chkavUsercannotchangepassword.WebTags = "";
         chkavUsercannotchangepassword.Caption = "Você não pode alterar a senha";
         AssignProp("", false, chkavUsercannotchangepassword_Internalname, "TitleCaption", chkavUsercannotchangepassword.Caption, true);
         chkavUsercannotchangepassword.CheckedValue = "false";
         AV31UserCannotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV31UserCannotChangePassword));
         AssignAttri("", false, "AV31UserCannotChangePassword", AV31UserCannotChangePassword);
         chkavUsermustchangepassword.Name = "vUSERMUSTCHANGEPASSWORD";
         chkavUsermustchangepassword.WebTags = "";
         chkavUsermustchangepassword.Caption = "Você deve alterar a senha";
         AssignProp("", false, chkavUsermustchangepassword_Internalname, "TitleCaption", chkavUsermustchangepassword.Caption, true);
         chkavUsermustchangepassword.CheckedValue = "false";
         AV44UserMustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV44UserMustChangePassword));
         AssignAttri("", false, "AV44UserMustChangePassword", AV44UserMustChangePassword);
         chkavUserpasswordneverexpires.Name = "vUSERPASSWORDNEVEREXPIRES";
         chkavUserpasswordneverexpires.WebTags = "";
         chkavUserpasswordneverexpires.Caption = "A senha nunca expira";
         AssignProp("", false, chkavUserpasswordneverexpires_Internalname, "TitleCaption", chkavUserpasswordneverexpires.Caption, true);
         chkavUserpasswordneverexpires.CheckedValue = "false";
         AV48UserPasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV48UserPasswordNeverExpires));
         AssignAttri("", false, "AV48UserPasswordNeverExpires", AV48UserPasswordNeverExpires);
         cmbavUsersecuritypolicyid.Name = "vUSERSECURITYPOLICYID";
         cmbavUsersecuritypolicyid.WebTags = "";
         if ( cmbavUsersecuritypolicyid.ItemCount > 0 )
         {
            AV49UserSecurityPolicyId = (int)(NumberUtil.Val( cmbavUsersecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49UserSecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV49UserSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV49UserSecurityPolicyId), 9, 0));
         }
         chkavUser_isenabledinrepository.Name = "USER_ISENABLEDINREPOSITORY";
         chkavUser_isenabledinrepository.WebTags = "";
         chkavUser_isenabledinrepository.Caption = "";
         AssignProp("", false, chkavUser_isenabledinrepository_Internalname, "TitleCaption", chkavUser_isenabledinrepository.Caption, true);
         chkavUser_isenabledinrepository.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavUserauthenticationtypename_Internalname = "vUSERAUTHENTICATIONTYPENAME";
         divUserauthenticationtypename_cell_Internalname = "USERAUTHENTICATIONTYPENAME_CELL";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUseremail_Internalname = "vUSEREMAIL";
         divUseremail_cell_Internalname = "USEREMAIL_CELL";
         edtavUserfirstname_Internalname = "vUSERFIRSTNAME";
         divUserfirstname_cell_Internalname = "USERFIRSTNAME_CELL";
         edtavUserlastname_Internalname = "vUSERLASTNAME";
         divUserlastname_cell_Internalname = "USERLASTNAME_CELL";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divUserpassword_cell_Internalname = "USERPASSWORD_CELL";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         divPasswordconf_cell_Internalname = "PASSWORDCONF_CELL";
         edtavUserexternalid_Internalname = "vUSEREXTERNALID";
         edtavUserbirthday_Internalname = "vUSERBIRTHDAY";
         divUserbirthday_cell_Internalname = "USERBIRTHDAY_CELL";
         cmbavUsergender_Internalname = "vUSERGENDER";
         divUsergender_cell_Internalname = "USERGENDER_CELL";
         edtavUserphone_Internalname = "vUSERPHONE";
         divUserphone_cell_Internalname = "USERPHONE_CELL";
         edtavUserurlprofile_Internalname = "vUSERURLPROFILE";
         divUserurlprofile_cell_Internalname = "USERURLPROFILE_CELL";
         edtavUserurlimage_Internalname = "vUSERURLIMAGE";
         divUserurlimage_cell_Internalname = "USERURLIMAGE_CELL";
         lblTextblockwwpuserextendedphoto_Internalname = "TEXTBLOCKWWPUSEREXTENDEDPHOTO";
         edtavWwpuserextendedphoto_Internalname = "vWWPUSEREXTENDEDPHOTO";
         imgUserphoto_Internalname = "USERPHOTO";
         tblTablemergedwwpuserextendedphoto_Internalname = "TABLEMERGEDWWPUSEREXTENDEDPHOTO";
         divTablesplittedwwpuserextendedphoto_Internalname = "TABLESPLITTEDWWPUSEREXTENDEDPHOTO";
         chkavUserisactive_Internalname = "vUSERISACTIVE";
         divUserisactive_cell_Internalname = "USERISACTIVE_CELL";
         edtavUseractivationdate_Internalname = "vUSERACTIVATIONDATE";
         divUseractivationdate_cell_Internalname = "USERACTIVATIONDATE_CELL";
         lblTextblockuserisenabledinrepository_Internalname = "TEXTBLOCKUSERISENABLEDINREPOSITORY";
         divTextblockuserisenabledinrepository_cell_Internalname = "TEXTBLOCKUSERISENABLEDINREPOSITORY_CELL";
         chkavUserisenabledinrepository_Internalname = "vUSERISENABLEDINREPOSITORY";
         cellUserisenabledinrepository_cell_Internalname = "USERISENABLEDINREPOSITORY_CELL";
         bttBtnenableuserinrepo_Internalname = "BTNENABLEUSERINREPO";
         tblTablemergeduserisenabledinrepository_Internalname = "TABLEMERGEDUSERISENABLEDINREPOSITORY";
         divTablesplitteduserisenabledinrepository_Internalname = "TABLESPLITTEDUSERISENABLEDINREPOSITORY";
         edtavUserdatelasauthentication_Internalname = "vUSERDATELASAUTHENTICATION";
         divUserdatelasauthentication_cell_Internalname = "USERDATELASAUTHENTICATION_CELL";
         chkavUserdontreceiveinformation_Internalname = "vUSERDONTRECEIVEINFORMATION";
         chkavUserisblocked_Internalname = "vUSERISBLOCKED";
         chkavUsercannotchangepassword_Internalname = "vUSERCANNOTCHANGEPASSWORD";
         chkavUsermustchangepassword_Internalname = "vUSERMUSTCHANGEPASSWORD";
         chkavUserpasswordneverexpires_Internalname = "vUSERPASSWORDNEVEREXPIRES";
         cmbavUsersecuritypolicyid_Internalname = "vUSERSECURITYPOLICYID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavUser_isenabledinrepository_Internalname = "USER_ISENABLEDINREPOSITORY";
         edtavUserguid_Internalname = "vUSERGUID";
         edtavUsernamespace_Internalname = "vUSERNAMESPACE";
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
         chkavUser_isenabledinrepository.Caption = "";
         chkavUserpasswordneverexpires.Caption = " ";
         chkavUsermustchangepassword.Caption = " ";
         chkavUsercannotchangepassword.Caption = " ";
         chkavUserisblocked.Caption = " ";
         chkavUserdontreceiveinformation.Caption = " ";
         chkavUserisenabledinrepository.Caption = "User Is Enabled In Repository";
         chkavUserisactive.Caption = " ";
         imgUserphoto_Visible = 1;
         imgUserphoto_Bitmap = "(none)";
         edtavWwpuserextendedphoto_Jsonclick = "";
         edtavWwpuserextendedphoto_Parameters = "";
         edtavWwpuserextendedphoto_Contenttype = "";
         edtavWwpuserextendedphoto_Filetype = "";
         bttBtnenableuserinrepo_Visible = 1;
         chkavUserisenabledinrepository.Enabled = 1;
         cellUserisenabledinrepository_cell_Class = "";
         chkavUserisenabledinrepository.Visible = 1;
         edtavWwpuserextendedphoto_Enabled = 1;
         bttBtnenableuserinrepo_Caption = "Habilitar";
         edtavUsernamespace_Jsonclick = "";
         edtavUsernamespace_Visible = 1;
         edtavUserguid_Jsonclick = "";
         edtavUserguid_Visible = 1;
         chkavUser_isenabledinrepository.Visible = 1;
         bttBtnenter_Caption = "Confirmar";
         bttBtnenter_Visible = 1;
         cmbavUsersecuritypolicyid_Jsonclick = "";
         cmbavUsersecuritypolicyid.Enabled = 1;
         chkavUserpasswordneverexpires.Enabled = 1;
         chkavUsermustchangepassword.Enabled = 1;
         chkavUsercannotchangepassword.Enabled = 1;
         chkavUserisblocked.Enabled = 1;
         chkavUserdontreceiveinformation.Enabled = 1;
         edtavUserdatelasauthentication_Jsonclick = "";
         edtavUserdatelasauthentication_Enabled = 1;
         edtavUserdatelasauthentication_Visible = 1;
         divUserdatelasauthentication_cell_Class = "col-xs-12 col-sm-6";
         divTextblockuserisenabledinrepository_cell_Class = "col-xs-12";
         edtavUseractivationdate_Jsonclick = "";
         edtavUseractivationdate_Enabled = 1;
         edtavUseractivationdate_Visible = 1;
         divUseractivationdate_cell_Class = "col-xs-12 col-sm-6";
         chkavUserisactive.Enabled = 1;
         chkavUserisactive.Visible = 1;
         divUserisactive_cell_Class = "col-xs-12 col-sm-6";
         edtavUserurlimage_Jsonclick = "";
         edtavUserurlimage_Enabled = 1;
         edtavUserurlimage_Visible = 1;
         divUserurlimage_cell_Class = "col-xs-12 col-sm-6";
         edtavUserurlprofile_Jsonclick = "";
         edtavUserurlprofile_Linktarget = "";
         edtavUserurlprofile_Link = "";
         edtavUserurlprofile_Enabled = 1;
         edtavUserurlprofile_Visible = 1;
         divUserurlprofile_cell_Class = "col-xs-12 col-sm-6";
         edtavUserphone_Jsonclick = "";
         edtavUserphone_Enabled = 1;
         divUserphone_cell_Class = "col-xs-12 col-sm-6";
         cmbavUsergender_Jsonclick = "";
         cmbavUsergender.Enabled = 1;
         divUsergender_cell_Class = "col-xs-12 col-sm-6";
         edtavUserbirthday_Jsonclick = "";
         edtavUserbirthday_Enabled = 1;
         divUserbirthday_cell_Class = "col-xs-12 col-sm-6";
         edtavUserexternalid_Jsonclick = "";
         edtavUserexternalid_Enabled = 1;
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         edtavPasswordconf_Visible = 1;
         divPasswordconf_cell_Class = "col-xs-12 col-sm-6";
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         divUserpassword_cell_Class = "col-xs-12 col-sm-6";
         edtavUserlastname_Jsonclick = "";
         edtavUserlastname_Enabled = 1;
         divUserlastname_cell_Class = "col-xs-12 col-sm-6";
         edtavUserfirstname_Jsonclick = "";
         edtavUserfirstname_Enabled = 1;
         divUserfirstname_cell_Class = "col-xs-12 col-sm-6";
         edtavUseremail_Jsonclick = "";
         edtavUseremail_Enabled = 1;
         divUseremail_cell_Class = "col-xs-12 col-sm-6";
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavUserauthenticationtypename_Jsonclick = "";
         cmbavUserauthenticationtypename.Enabled = 1;
         cmbavUserauthenticationtypename.Visible = 1;
         divUserauthenticationtypename_cell_Class = "col-xs-12 col-sm-6";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Usuário";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuário";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV51UserURLProfile',fld:'vUSERURLPROFILE',pic:''},{av:'AV20Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV39UserId',fld:'vUSERID',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV28UserActivationDate',fld:'vUSERACTIVATIONDATE',pic:'99/99/9999 99:99'},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavUserurlprofile_Linktarget',ctrl:'vUSERURLPROFILE',prop:'Linktarget'},{av:'edtavUserurlprofile_Link',ctrl:'vUSERURLPROFILE',prop:'Link'},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("'DOENABLEUSERINREPO'","{handler:'E121H2',iparms:[{av:'AV39UserId',fld:'vUSERID',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("'DOENABLEUSERINREPO'",",oparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E131H2',iparms:[{av:'AV14CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV39UserId',fld:'vUSERID',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV20Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'cmbavUserauthenticationtypename'},{av:'AV29UserAuthenticationTypeName',fld:'vUSERAUTHENTICATIONTYPENAME',pic:''},{av:'AV53UserAuthenticationTypeT',fld:'vUSERAUTHENTICATIONTYPET',pic:''},{av:'AV47UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV22PasswordConf',fld:'vPASSWORDCONF',pic:''},{av:'AV21Password',fld:'vPASSWORD',pic:''},{av:'AV45UserName',fld:'vUSERNAME',pic:''},{av:'AV34UserEmail',fld:'vUSEREMAIL',pic:''},{av:'AV36UserFirstName',fld:'vUSERFIRSTNAME',pic:''},{av:'AV43UserLastName',fld:'vUSERLASTNAME',pic:''},{av:'AV35UserExternalId',fld:'vUSEREXTERNALID',pic:''},{av:'AV30UserBirthday',fld:'vUSERBIRTHDAY',pic:''},{av:'cmbavUsergender'},{av:'AV37UserGender',fld:'vUSERGENDER',pic:''},{av:'AV51UserURLProfile',fld:'vUSERURLPROFILE',pic:''},{av:'AV50UserURLImage',fld:'vUSERURLIMAGE',pic:''},{av:'AV28UserActivationDate',fld:'vUSERACTIVATIONDATE',pic:'99/99/9999 99:99'},{av:'cmbavUsersecuritypolicyid'},{av:'AV49UserSecurityPolicyId',fld:'vUSERSECURITYPOLICYID',pic:'ZZZZZZZZ9'},{av:'AV8UserPhone',fld:'vUSERPHONE',pic:''},{av:'AV7WWPUserExtendedPhoto',fld:'vWWPUSEREXTENDEDPHOTO',pic:''},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV53UserAuthenticationTypeT',fld:'vUSERAUTHENTICATIONTYPET',pic:''},{av:'AV21Password',fld:'vPASSWORD',pic:''},{av:'AV14CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("VWWPUSEREXTENDEDPHOTO.CONTROLVALUECHANGED","{handler:'E141H2',iparms:[{av:'AV7WWPUserExtendedPhoto',fld:'vWWPUSEREXTENDEDPHOTO',pic:''},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("VWWPUSEREXTENDEDPHOTO.CONTROLVALUECHANGED",",oparms:[{av:'AV14CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'imgUserphoto_Visible',ctrl:'USERPHOTO',prop:'Visible'},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("VUSERAUTHENTICATIONTYPENAME.ISVALID","{handler:'E151H2',iparms:[{av:'cmbavUserauthenticationtypename'},{av:'AV29UserAuthenticationTypeName',fld:'vUSERAUTHENTICATIONTYPENAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("VUSERAUTHENTICATIONTYPENAME.ISVALID",",oparms:[{av:'cmbavUserauthenticationtypename'},{av:'divUserauthenticationtypename_cell_Class',ctrl:'USERAUTHENTICATIONTYPENAME_CELL',prop:'Class'},{av:'divUseremail_cell_Class',ctrl:'USEREMAIL_CELL',prop:'Class'},{av:'divUserfirstname_cell_Class',ctrl:'USERFIRSTNAME_CELL',prop:'Class'},{av:'divUserlastname_cell_Class',ctrl:'USERLASTNAME_CELL',prop:'Class'},{av:'edtavUserpassword_Visible',ctrl:'vUSERPASSWORD',prop:'Visible'},{av:'divUserpassword_cell_Class',ctrl:'USERPASSWORD_CELL',prop:'Class'},{av:'edtavPasswordconf_Visible',ctrl:'vPASSWORDCONF',prop:'Visible'},{av:'divPasswordconf_cell_Class',ctrl:'PASSWORDCONF_CELL',prop:'Class'},{av:'divUserbirthday_cell_Class',ctrl:'USERBIRTHDAY_CELL',prop:'Class'},{av:'divUsergender_cell_Class',ctrl:'USERGENDER_CELL',prop:'Class'},{av:'divUserphone_cell_Class',ctrl:'USERPHONE_CELL',prop:'Class'},{av:'edtavUserurlprofile_Visible',ctrl:'vUSERURLPROFILE',prop:'Visible'},{av:'divUserurlprofile_cell_Class',ctrl:'USERURLPROFILE_CELL',prop:'Class'},{av:'edtavUserurlimage_Visible',ctrl:'vUSERURLIMAGE',prop:'Visible'},{av:'divUserurlimage_cell_Class',ctrl:'USERURLIMAGE_CELL',prop:'Class'},{av:'chkavUserisactive.Visible',ctrl:'vUSERISACTIVE',prop:'Visible'},{av:'divUserisactive_cell_Class',ctrl:'USERISACTIVE_CELL',prop:'Class'},{av:'edtavUseractivationdate_Visible',ctrl:'vUSERACTIVATIONDATE',prop:'Visible'},{av:'divUseractivationdate_cell_Class',ctrl:'USERACTIVATIONDATE_CELL',prop:'Class'},{av:'chkavUserisenabledinrepository.Visible',ctrl:'vUSERISENABLEDINREPOSITORY',prop:'Visible'},{av:'cellUserisenabledinrepository_cell_Class',ctrl:'USERISENABLEDINREPOSITORY_CELL',prop:'Class'},{av:'divTextblockuserisenabledinrepository_cell_Class',ctrl:'TEXTBLOCKUSERISENABLEDINREPOSITORY_CELL',prop:'Class'},{av:'edtavUserdatelasauthentication_Visible',ctrl:'vUSERDATELASAUTHENTICATION',prop:'Visible'},{av:'divUserdatelasauthentication_cell_Class',ctrl:'USERDATELASAUTHENTICATION_CELL',prop:'Class'},{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("VALIDV_USERBIRTHDAY","{handler:'Validv_Userbirthday',iparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("VALIDV_USERBIRTHDAY",",oparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("VALIDV_USERGENDER","{handler:'Validv_Usergender',iparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("VALIDV_USERGENDER",",oparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("VALIDV_USERACTIVATIONDATE","{handler:'Validv_Useractivationdate',iparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("VALIDV_USERACTIVATIONDATE",",oparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
         setEventMetadata("VALIDV_USERDATELASAUTHENTICATION","{handler:'Validv_Userdatelasauthentication',iparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]");
         setEventMetadata("VALIDV_USERDATELASAUTHENTICATION",",oparms:[{av:'AV40UserIsActive',fld:'vUSERISACTIVE',pic:''},{av:'AV42UserIsEnabledInRepository',fld:'vUSERISENABLEDINREPOSITORY',pic:''},{av:'AV33UserDontReceiveInformation',fld:'vUSERDONTRECEIVEINFORMATION',pic:''},{av:'AV41UserIsBlocked',fld:'vUSERISBLOCKED',pic:''},{av:'AV31UserCannotChangePassword',fld:'vUSERCANNOTCHANGEPASSWORD',pic:''},{av:'AV44UserMustChangePassword',fld:'vUSERMUSTCHANGEPASSWORD',pic:''},{av:'AV48UserPasswordNeverExpires',fld:'vUSERPASSWORDNEVEREXPIRES',pic:''},{av:'AV27User.gxTpr_Isenabledinrepository',fld:'USER_ISENABLEDINREPOSITORY',pic:''}]}");
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
         wcpOAV39UserId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV20Language = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         AV28UserActivationDate = (DateTime)(DateTime.MinValue);
         AV53UserAuthenticationTypeT = "";
         AV21Password = "";
         GXCCtlgxBlob = "";
         AV7WWPUserExtendedPhoto = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV29UserAuthenticationTypeName = "";
         AV45UserName = "";
         AV34UserEmail = "";
         AV36UserFirstName = "";
         AV43UserLastName = "";
         AV47UserPassword = "";
         AV22PasswordConf = "";
         AV35UserExternalId = "";
         AV30UserBirthday = DateTime.MinValue;
         AV37UserGender = "";
         AV8UserPhone = "";
         AV51UserURLProfile = "";
         AV50UserURLImage = "";
         lblTextblockwwpuserextendedphoto_Jsonclick = "";
         lblTextblockuserisenabledinrepository_Jsonclick = "";
         AV32UserDateLasAuthentication = (DateTime)(DateTime.MinValue);
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV27User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV38UserGUID = "";
         AV46UserNameSpace = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         hsh = "";
         AV24Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV11AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV16Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12AuthenticationTypesIns = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV25SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV17FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV26SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV13AuthTypeId = "";
         AV10AuthenticationTypeName = "";
         AV9AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV6WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV15Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV52AuthenticationTypesI = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV5WWPUserExtendedPhotoExtension = "";
         sStyleString = "";
         bttBtnenableuserinrepo_Jsonclick = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         sImgUrl = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamuserentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamuserentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavUseractivationdate_Enabled = 0;
         chkavUserisenabledinrepository.Enabled = 0;
         edtavUserdatelasauthentication_Enabled = 0;
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
      private int edtavUsername_Enabled ;
      private int edtavUseremail_Enabled ;
      private int edtavUserfirstname_Enabled ;
      private int edtavUserlastname_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int edtavPasswordconf_Visible ;
      private int edtavPasswordconf_Enabled ;
      private int edtavUserexternalid_Enabled ;
      private int edtavUserbirthday_Enabled ;
      private int edtavUserphone_Enabled ;
      private int edtavUserurlprofile_Visible ;
      private int edtavUserurlprofile_Enabled ;
      private int edtavUserurlimage_Visible ;
      private int edtavUserurlimage_Enabled ;
      private int edtavUseractivationdate_Visible ;
      private int edtavUseractivationdate_Enabled ;
      private int edtavUserdatelasauthentication_Visible ;
      private int edtavUserdatelasauthentication_Enabled ;
      private int AV49UserSecurityPolicyId ;
      private int bttBtnenter_Visible ;
      private int edtavUserguid_Visible ;
      private int edtavUsernamespace_Visible ;
      private int AV63GXV2 ;
      private int AV64GXV3 ;
      private int bttBtnenableuserinrepo_Visible ;
      private int imgUserphoto_Visible ;
      private int edtavWwpuserextendedphoto_Enabled ;
      private int AV65GXV4 ;
      private int AV66GXV5 ;
      private int AV67GXV6 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV39UserId ;
      private string wcpOGx_mode ;
      private string wcpOAV39UserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV20Language ;
      private string GXKey ;
      private string AV53UserAuthenticationTypeT ;
      private string AV21Password ;
      private string GXCCtlgxBlob ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUserauthenticationtypename_cell_Internalname ;
      private string divUserauthenticationtypename_cell_Class ;
      private string cmbavUserauthenticationtypename_Internalname ;
      private string TempTags ;
      private string AV29UserAuthenticationTypeName ;
      private string cmbavUserauthenticationtypename_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string divUseremail_cell_Internalname ;
      private string divUseremail_cell_Class ;
      private string edtavUseremail_Internalname ;
      private string edtavUseremail_Jsonclick ;
      private string divUserfirstname_cell_Internalname ;
      private string divUserfirstname_cell_Class ;
      private string edtavUserfirstname_Internalname ;
      private string AV36UserFirstName ;
      private string edtavUserfirstname_Jsonclick ;
      private string divUserlastname_cell_Internalname ;
      private string divUserlastname_cell_Class ;
      private string edtavUserlastname_Internalname ;
      private string AV43UserLastName ;
      private string edtavUserlastname_Jsonclick ;
      private string divUserpassword_cell_Internalname ;
      private string divUserpassword_cell_Class ;
      private string edtavUserpassword_Internalname ;
      private string AV47UserPassword ;
      private string edtavUserpassword_Jsonclick ;
      private string divPasswordconf_cell_Internalname ;
      private string divPasswordconf_cell_Class ;
      private string edtavPasswordconf_Internalname ;
      private string AV22PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string edtavUserexternalid_Internalname ;
      private string edtavUserexternalid_Jsonclick ;
      private string divUserbirthday_cell_Internalname ;
      private string divUserbirthday_cell_Class ;
      private string edtavUserbirthday_Internalname ;
      private string edtavUserbirthday_Jsonclick ;
      private string divUsergender_cell_Internalname ;
      private string divUsergender_cell_Class ;
      private string cmbavUsergender_Internalname ;
      private string AV37UserGender ;
      private string cmbavUsergender_Jsonclick ;
      private string divUserphone_cell_Internalname ;
      private string divUserphone_cell_Class ;
      private string edtavUserphone_Internalname ;
      private string AV8UserPhone ;
      private string edtavUserphone_Jsonclick ;
      private string divUserurlprofile_cell_Internalname ;
      private string divUserurlprofile_cell_Class ;
      private string edtavUserurlprofile_Internalname ;
      private string edtavUserurlprofile_Link ;
      private string edtavUserurlprofile_Linktarget ;
      private string edtavUserurlprofile_Jsonclick ;
      private string divUserurlimage_cell_Internalname ;
      private string divUserurlimage_cell_Class ;
      private string edtavUserurlimage_Internalname ;
      private string edtavUserurlimage_Jsonclick ;
      private string divTablesplittedwwpuserextendedphoto_Internalname ;
      private string lblTextblockwwpuserextendedphoto_Internalname ;
      private string lblTextblockwwpuserextendedphoto_Jsonclick ;
      private string divUserisactive_cell_Internalname ;
      private string divUserisactive_cell_Class ;
      private string chkavUserisactive_Internalname ;
      private string divUseractivationdate_cell_Internalname ;
      private string divUseractivationdate_cell_Class ;
      private string edtavUseractivationdate_Internalname ;
      private string edtavUseractivationdate_Jsonclick ;
      private string divTablesplitteduserisenabledinrepository_Internalname ;
      private string divTextblockuserisenabledinrepository_cell_Internalname ;
      private string divTextblockuserisenabledinrepository_cell_Class ;
      private string lblTextblockuserisenabledinrepository_Internalname ;
      private string lblTextblockuserisenabledinrepository_Jsonclick ;
      private string divUserdatelasauthentication_cell_Internalname ;
      private string divUserdatelasauthentication_cell_Class ;
      private string edtavUserdatelasauthentication_Internalname ;
      private string edtavUserdatelasauthentication_Jsonclick ;
      private string chkavUserdontreceiveinformation_Internalname ;
      private string chkavUserisblocked_Internalname ;
      private string chkavUsercannotchangepassword_Internalname ;
      private string chkavUsermustchangepassword_Internalname ;
      private string chkavUserpasswordneverexpires_Internalname ;
      private string cmbavUsersecuritypolicyid_Internalname ;
      private string cmbavUsersecuritypolicyid_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavUser_isenabledinrepository_Internalname ;
      private string edtavUserguid_Internalname ;
      private string AV38UserGUID ;
      private string edtavUserguid_Jsonclick ;
      private string edtavUsernamespace_Internalname ;
      private string AV46UserNameSpace ;
      private string edtavUsernamespace_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavUserisenabledinrepository_Internalname ;
      private string edtavWwpuserextendedphoto_Internalname ;
      private string hsh ;
      private string bttBtnenableuserinrepo_Internalname ;
      private string imgUserphoto_Internalname ;
      private string AV13AuthTypeId ;
      private string AV10AuthenticationTypeName ;
      private string bttBtnenableuserinrepo_Caption ;
      private string cellUserisenabledinrepository_cell_Class ;
      private string cellUserisenabledinrepository_cell_Internalname ;
      private string sStyleString ;
      private string tblTablemergeduserisenabledinrepository_Internalname ;
      private string bttBtnenableuserinrepo_Jsonclick ;
      private string tblTablemergedwwpuserextendedphoto_Internalname ;
      private string edtavWwpuserextendedphoto_Filetype ;
      private string edtavWwpuserextendedphoto_Contenttype ;
      private string edtavWwpuserextendedphoto_Parameters ;
      private string edtavWwpuserextendedphoto_Jsonclick ;
      private string sImgUrl ;
      private DateTime AV28UserActivationDate ;
      private DateTime AV32UserDateLasAuthentication ;
      private DateTime AV30UserBirthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV42UserIsEnabledInRepository ;
      private bool AV14CheckRequiredFieldsResult ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool AV40UserIsActive ;
      private bool AV33UserDontReceiveInformation ;
      private bool AV41UserIsBlocked ;
      private bool AV31UserCannotChangePassword ;
      private bool AV44UserMustChangePassword ;
      private bool AV48UserPasswordNeverExpires ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18IsActive ;
      private bool AV19isOK ;
      private bool AV23PasswordIsOK ;
      private string AV45UserName ;
      private string AV34UserEmail ;
      private string AV35UserExternalId ;
      private string AV51UserURLProfile ;
      private string AV50UserURLImage ;
      private string AV5WWPUserExtendedPhotoExtension ;
      private string imgUserphoto_Bitmap ;
      private string AV7WWPUserExtendedPhoto ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV9AuthenticationType ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_UserId ;
      private GXCombobox cmbavUserauthenticationtypename ;
      private GXCombobox cmbavUsergender ;
      private GXCheckbox chkavUserisactive ;
      private GXCheckbox chkavUserisenabledinrepository ;
      private GXCheckbox chkavUserdontreceiveinformation ;
      private GXCheckbox chkavUserisblocked ;
      private GXCheckbox chkavUsercannotchangepassword ;
      private GXCheckbox chkavUsermustchangepassword ;
      private GXCheckbox chkavUserpasswordneverexpires ;
      private GXCombobox cmbavUsersecuritypolicyid ;
      private GXCheckbox chkavUser_isenabledinrepository ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV11AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV52AuthenticationTypesI ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV25SecurityPolicies ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV6WWPUserExtended ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV15Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV12AuthenticationTypesIns ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV17FilterSecPol ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV24Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV27User ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV26SecurityPolicy ;
   }

   public class gamuserentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamuserentry__default : DataStoreHelperBase, IDataStoreHelper
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
