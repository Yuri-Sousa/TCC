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
   public class gamsecuritypolicyentry : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamsecuritypolicyentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamsecuritypolicyentry( IGxContext context )
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
         this.AV7Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV7Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions = new GXCombobox();
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
                  AV7Id = (long)(NumberUtil.Val( GetPar( "Id"), "."));
                  AssignAttri("", false, "AV7Id", StringUtil.LTrimStr( (decimal)(AV7Id), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Id), "ZZZZZZZZZZZ9"), context));
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
            return "gamsecuritypolicyentry_Execute" ;
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
         PA1E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1E2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142815523824", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamsecuritypolicyentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7Id,12,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"GAMSecurityPolicyEntry");
         forbiddenHiddens.Add("SecurityPolicyGUID", StringUtil.RTrim( context.localUtil.Format( AV20SecurityPolicyGUID, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("gamsecuritypolicyentry:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Id), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Width", StringUtil.RTrim( Dvpanel_onlyweb_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Autowidth", StringUtil.BoolToStr( Dvpanel_onlyweb_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Autoheight", StringUtil.BoolToStr( Dvpanel_onlyweb_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Cls", StringUtil.RTrim( Dvpanel_onlyweb_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Title", StringUtil.RTrim( Dvpanel_onlyweb_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Collapsible", StringUtil.BoolToStr( Dvpanel_onlyweb_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Collapsed", StringUtil.BoolToStr( Dvpanel_onlyweb_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_onlyweb_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Iconposition", StringUtil.RTrim( Dvpanel_onlyweb_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYWEB_Autoscroll", StringUtil.BoolToStr( Dvpanel_onlyweb_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Width", StringUtil.RTrim( Dvpanel_onlysd_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Autowidth", StringUtil.BoolToStr( Dvpanel_onlysd_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Autoheight", StringUtil.BoolToStr( Dvpanel_onlysd_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Cls", StringUtil.RTrim( Dvpanel_onlysd_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Title", StringUtil.RTrim( Dvpanel_onlysd_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Collapsible", StringUtil.BoolToStr( Dvpanel_onlysd_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Collapsed", StringUtil.BoolToStr( Dvpanel_onlysd_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_onlysd_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Iconposition", StringUtil.RTrim( Dvpanel_onlysd_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ONLYSD_Autoscroll", StringUtil.BoolToStr( Dvpanel_onlysd_Autoscroll));
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
            WE1E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1E2( ) ;
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
         return formatLink("gamsecuritypolicyentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7Id,12,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMSecurityPolicyEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Política de segurança" ;
      }

      protected void WB1E0( )
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
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableLabel50Percent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyid_Internalname, "Id", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19SecurityPolicyId), 9, 0, ",", "")), ((edtavSecuritypolicyid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19SecurityPolicyId), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV19SecurityPolicyId), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavSecuritypolicyid_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumShort", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyguid_Internalname, "Guid", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyguid_Internalname, StringUtil.RTrim( AV20SecurityPolicyGUID), StringUtil.RTrim( context.localUtil.Format( AV20SecurityPolicyGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyguid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavSecuritypolicyguid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyname_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyname_Internalname, StringUtil.RTrim( AV21SecurityPolicyName), StringUtil.RTrim( context.localUtil.Format( AV21SecurityPolicyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyname_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "TableLabel50Percent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyperiodchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyperiodchangepassword_Internalname, "Período para alterar (dias)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyperiodchangepassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12SecurityPolicyPeriodChangePassword), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12SecurityPolicyPeriodChangePassword), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyperiodchangepassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyperiodchangepassword_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyminimumtimetochangepasswords_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyminimumtimetochangepasswords_Internalname, "Min. tempo de troca de senha (minutos)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyminimumtimetochangepasswords_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SecurityPolicyMinimumTimeToChangePasswords), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13SecurityPolicyMinimumTimeToChangePasswords), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyminimumtimetochangepasswords_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyminimumtimetochangepasswords_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyminimumlengthpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyminimumlengthpassword_Internalname, "Min. comprimento da senha", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyminimumlengthpassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14SecurityPolicyMinimumLengthPassword), 2, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14SecurityPolicyMinimumLengthPassword), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyminimumlengthpassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyminimumlengthpassword_Enabled, 1, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyminimumnumericcharacterspassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyminimumnumericcharacterspassword_Internalname, "Min. caracteres numéricos", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyminimumnumericcharacterspassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SecurityPolicyMinimumNumericCharactersPassword), 2, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15SecurityPolicyMinimumNumericCharactersPassword), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyminimumnumericcharacterspassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyminimumnumericcharacterspassword_Enabled, 1, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname, "Min. as letras maiúsculas", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16SecurityPolicyMinimumUpperCaseCharactersPassword), 2, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16SecurityPolicyMinimumUpperCaseCharactersPassword), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyminimumuppercasecharacterspassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyminimumuppercasecharacterspassword_Enabled, 1, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyminimumspecialcharacterspassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyminimumspecialcharacterspassword_Internalname, "Min. caracteres especiais", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyminimumspecialcharacterspassword_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17SecurityPolicyMinimumSpecialCharactersPassword), 2, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17SecurityPolicyMinimumSpecialCharactersPassword), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyminimumspecialcharacterspassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyminimumspecialcharacterspassword_Enabled, 1, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicymaximumpasswordhistoryentries_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicymaximumpasswordhistoryentries_Internalname, "Max. entradas de senha na história", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicymaximumpasswordhistoryentries_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18SecurityPolicyMaximumPasswordHistoryEntries), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18SecurityPolicyMaximumPasswordHistoryEntries), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicymaximumpasswordhistoryentries_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicymaximumpasswordhistoryentries_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_onlyweb.SetProperty("Width", Dvpanel_onlyweb_Width);
            ucDvpanel_onlyweb.SetProperty("AutoWidth", Dvpanel_onlyweb_Autowidth);
            ucDvpanel_onlyweb.SetProperty("AutoHeight", Dvpanel_onlyweb_Autoheight);
            ucDvpanel_onlyweb.SetProperty("Cls", Dvpanel_onlyweb_Cls);
            ucDvpanel_onlyweb.SetProperty("Title", Dvpanel_onlyweb_Title);
            ucDvpanel_onlyweb.SetProperty("Collapsible", Dvpanel_onlyweb_Collapsible);
            ucDvpanel_onlyweb.SetProperty("Collapsed", Dvpanel_onlyweb_Collapsed);
            ucDvpanel_onlyweb.SetProperty("ShowCollapseIcon", Dvpanel_onlyweb_Showcollapseicon);
            ucDvpanel_onlyweb.SetProperty("IconPosition", Dvpanel_onlyweb_Iconposition);
            ucDvpanel_onlyweb.SetProperty("AutoScroll", Dvpanel_onlyweb_Autoscroll);
            ucDvpanel_onlyweb.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_onlyweb_Internalname, "DVPANEL_ONLYWEBContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_ONLYWEBContainer"+"OnlyWeb"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divOnlyweb_Internalname, 1, 0, "px", 0, "px", "TableLabel50Percent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname, "Permitir várias sessões web simultâneas", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecuritypolicyallowmultipleconcurrentwebsessions, cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0)), 1, cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecuritypolicyallowmultipleconcurrentwebsessions.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, "HLP_GAMSecurityPolicyEntry.htm");
            cmbavSecuritypolicyallowmultipleconcurrentwebsessions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0));
            AssignProp("", false, cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname, "Values", (string)(cmbavSecuritypolicyallowmultipleconcurrentwebsessions.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicywebsessiontimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicywebsessiontimeout_Internalname, "Tempo de espera da sessão (minutos)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicywebsessiontimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SecurityPolicyWebSessionTimeout), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11SecurityPolicyWebSessionTimeout), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicywebsessiontimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicywebsessiontimeout_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_onlysd.SetProperty("Width", Dvpanel_onlysd_Width);
            ucDvpanel_onlysd.SetProperty("AutoWidth", Dvpanel_onlysd_Autowidth);
            ucDvpanel_onlysd.SetProperty("AutoHeight", Dvpanel_onlysd_Autoheight);
            ucDvpanel_onlysd.SetProperty("Cls", Dvpanel_onlysd_Cls);
            ucDvpanel_onlysd.SetProperty("Title", Dvpanel_onlysd_Title);
            ucDvpanel_onlysd.SetProperty("Collapsible", Dvpanel_onlysd_Collapsible);
            ucDvpanel_onlysd.SetProperty("Collapsed", Dvpanel_onlysd_Collapsed);
            ucDvpanel_onlysd.SetProperty("ShowCollapseIcon", Dvpanel_onlysd_Showcollapseicon);
            ucDvpanel_onlysd.SetProperty("IconPosition", Dvpanel_onlysd_Iconposition);
            ucDvpanel_onlysd.SetProperty("AutoScroll", Dvpanel_onlysd_Autoscroll);
            ucDvpanel_onlysd.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_onlysd_Internalname, "DVPANEL_ONLYSDContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_ONLYSDContainer"+"OnlySD"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divOnlysd_Internalname, 1, 0, "px", 0, "px", "TableLabel50Percent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyoauthtokenexpire_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyoauthtokenexpire_Internalname, "Oauth token expirar na (minutos)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyoauthtokenexpire_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SecurityPolicyOauthTokenExpire), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9SecurityPolicyOauthTokenExpire), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyoauthtokenexpire_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyoauthtokenexpire_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname, "Max. renovações de tokens", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22SecurityPolicyOauthTokenMaximumRenovations), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22SecurityPolicyOauthTokenMaximumRenovations), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuritypolicyoauthtokenmaximumrenovations_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuritypolicyoauthtokenmaximumrenovations_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMSecurityPolicyEntry.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMSecurityPolicyEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1E2( )
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
            Form.Meta.addItem("description", "Política de segurança", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1E0( ) ;
      }

      protected void WS1E2( )
      {
         START1E2( ) ;
         EVT1E2( ) ;
      }

      protected void EVT1E2( )
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
                              E111E2 ();
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
                                    E121E2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E131E2 ();
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

      protected void WE1E2( )
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

      protected void PA1E2( )
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
               GX_FocusControl = edtavSecuritypolicyid_Internalname;
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
         if ( cmbavSecuritypolicyallowmultipleconcurrentwebsessions.ItemCount > 0 )
         {
            AV10SecurityPolicyAllowMultipleConcurrentWebSessions = (short)(NumberUtil.Val( cmbavSecuritypolicyallowmultipleconcurrentwebsessions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0))), "."));
            AssignAttri("", false, "AV10SecurityPolicyAllowMultipleConcurrentWebSessions", StringUtil.LTrimStr( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecuritypolicyallowmultipleconcurrentwebsessions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0));
            AssignProp("", false, cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname, "Values", cmbavSecuritypolicyallowmultipleconcurrentwebsessions.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSecuritypolicyid_Enabled = 0;
         AssignProp("", false, edtavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyid_Enabled), 5, 0), true);
         edtavSecuritypolicyguid_Enabled = 0;
         AssignProp("", false, edtavSecuritypolicyguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyguid_Enabled), 5, 0), true);
      }

      protected void RF1E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E131E2 ();
            WB1E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1E2( )
      {
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Id), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSecuritypolicyid_Enabled = 0;
         AssignProp("", false, edtavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyid_Enabled), 5, 0), true);
         edtavSecuritypolicyguid_Enabled = 0;
         AssignProp("", false, edtavSecuritypolicyguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyguid_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111E2 ();
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
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            Dvpanel_onlyweb_Width = cgiGet( "DVPANEL_ONLYWEB_Width");
            Dvpanel_onlyweb_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYWEB_Autowidth"));
            Dvpanel_onlyweb_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYWEB_Autoheight"));
            Dvpanel_onlyweb_Cls = cgiGet( "DVPANEL_ONLYWEB_Cls");
            Dvpanel_onlyweb_Title = cgiGet( "DVPANEL_ONLYWEB_Title");
            Dvpanel_onlyweb_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYWEB_Collapsible"));
            Dvpanel_onlyweb_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYWEB_Collapsed"));
            Dvpanel_onlyweb_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYWEB_Showcollapseicon"));
            Dvpanel_onlyweb_Iconposition = cgiGet( "DVPANEL_ONLYWEB_Iconposition");
            Dvpanel_onlyweb_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYWEB_Autoscroll"));
            Dvpanel_onlysd_Width = cgiGet( "DVPANEL_ONLYSD_Width");
            Dvpanel_onlysd_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYSD_Autowidth"));
            Dvpanel_onlysd_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYSD_Autoheight"));
            Dvpanel_onlysd_Cls = cgiGet( "DVPANEL_ONLYSD_Cls");
            Dvpanel_onlysd_Title = cgiGet( "DVPANEL_ONLYSD_Title");
            Dvpanel_onlysd_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYSD_Collapsible"));
            Dvpanel_onlysd_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYSD_Collapsed"));
            Dvpanel_onlysd_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYSD_Showcollapseicon"));
            Dvpanel_onlysd_Iconposition = cgiGet( "DVPANEL_ONLYSD_Iconposition");
            Dvpanel_onlysd_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_ONLYSD_Autoscroll"));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYID");
               GX_FocusControl = edtavSecuritypolicyid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19SecurityPolicyId = 0;
               AssignAttri("", false, "AV19SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV19SecurityPolicyId), 9, 0));
            }
            else
            {
               AV19SecurityPolicyId = (int)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyid_Internalname), ",", "."));
               AssignAttri("", false, "AV19SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV19SecurityPolicyId), 9, 0));
            }
            AV20SecurityPolicyGUID = cgiGet( edtavSecuritypolicyguid_Internalname);
            AssignAttri("", false, "AV20SecurityPolicyGUID", AV20SecurityPolicyGUID);
            AV21SecurityPolicyName = cgiGet( edtavSecuritypolicyname_Internalname);
            AssignAttri("", false, "AV21SecurityPolicyName", AV21SecurityPolicyName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyperiodchangepassword_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyperiodchangepassword_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYPERIODCHANGEPASSWORD");
               GX_FocusControl = edtavSecuritypolicyperiodchangepassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12SecurityPolicyPeriodChangePassword = 0;
               AssignAttri("", false, "AV12SecurityPolicyPeriodChangePassword", StringUtil.LTrimStr( (decimal)(AV12SecurityPolicyPeriodChangePassword), 4, 0));
            }
            else
            {
               AV12SecurityPolicyPeriodChangePassword = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyperiodchangepassword_Internalname), ",", "."));
               AssignAttri("", false, "AV12SecurityPolicyPeriodChangePassword", StringUtil.LTrimStr( (decimal)(AV12SecurityPolicyPeriodChangePassword), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumtimetochangepasswords_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumtimetochangepasswords_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYMINIMUMTIMETOCHANGEPASSWORDS");
               GX_FocusControl = edtavSecuritypolicyminimumtimetochangepasswords_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13SecurityPolicyMinimumTimeToChangePasswords = 0;
               AssignAttri("", false, "AV13SecurityPolicyMinimumTimeToChangePasswords", StringUtil.LTrimStr( (decimal)(AV13SecurityPolicyMinimumTimeToChangePasswords), 4, 0));
            }
            else
            {
               AV13SecurityPolicyMinimumTimeToChangePasswords = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumtimetochangepasswords_Internalname), ",", "."));
               AssignAttri("", false, "AV13SecurityPolicyMinimumTimeToChangePasswords", StringUtil.LTrimStr( (decimal)(AV13SecurityPolicyMinimumTimeToChangePasswords), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumlengthpassword_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumlengthpassword_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYMINIMUMLENGTHPASSWORD");
               GX_FocusControl = edtavSecuritypolicyminimumlengthpassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14SecurityPolicyMinimumLengthPassword = 0;
               AssignAttri("", false, "AV14SecurityPolicyMinimumLengthPassword", StringUtil.LTrimStr( (decimal)(AV14SecurityPolicyMinimumLengthPassword), 2, 0));
            }
            else
            {
               AV14SecurityPolicyMinimumLengthPassword = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumlengthpassword_Internalname), ",", "."));
               AssignAttri("", false, "AV14SecurityPolicyMinimumLengthPassword", StringUtil.LTrimStr( (decimal)(AV14SecurityPolicyMinimumLengthPassword), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumnumericcharacterspassword_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumnumericcharacterspassword_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYMINIMUMNUMERICCHARACTERSPASSWORD");
               GX_FocusControl = edtavSecuritypolicyminimumnumericcharacterspassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15SecurityPolicyMinimumNumericCharactersPassword = 0;
               AssignAttri("", false, "AV15SecurityPolicyMinimumNumericCharactersPassword", StringUtil.LTrimStr( (decimal)(AV15SecurityPolicyMinimumNumericCharactersPassword), 2, 0));
            }
            else
            {
               AV15SecurityPolicyMinimumNumericCharactersPassword = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumnumericcharacterspassword_Internalname), ",", "."));
               AssignAttri("", false, "AV15SecurityPolicyMinimumNumericCharactersPassword", StringUtil.LTrimStr( (decimal)(AV15SecurityPolicyMinimumNumericCharactersPassword), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYMINIMUMUPPERCASECHARACTERSPASSWORD");
               GX_FocusControl = edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16SecurityPolicyMinimumUpperCaseCharactersPassword = 0;
               AssignAttri("", false, "AV16SecurityPolicyMinimumUpperCaseCharactersPassword", StringUtil.LTrimStr( (decimal)(AV16SecurityPolicyMinimumUpperCaseCharactersPassword), 2, 0));
            }
            else
            {
               AV16SecurityPolicyMinimumUpperCaseCharactersPassword = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname), ",", "."));
               AssignAttri("", false, "AV16SecurityPolicyMinimumUpperCaseCharactersPassword", StringUtil.LTrimStr( (decimal)(AV16SecurityPolicyMinimumUpperCaseCharactersPassword), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumspecialcharacterspassword_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumspecialcharacterspassword_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYMINIMUMSPECIALCHARACTERSPASSWORD");
               GX_FocusControl = edtavSecuritypolicyminimumspecialcharacterspassword_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17SecurityPolicyMinimumSpecialCharactersPassword = 0;
               AssignAttri("", false, "AV17SecurityPolicyMinimumSpecialCharactersPassword", StringUtil.LTrimStr( (decimal)(AV17SecurityPolicyMinimumSpecialCharactersPassword), 2, 0));
            }
            else
            {
               AV17SecurityPolicyMinimumSpecialCharactersPassword = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyminimumspecialcharacterspassword_Internalname), ",", "."));
               AssignAttri("", false, "AV17SecurityPolicyMinimumSpecialCharactersPassword", StringUtil.LTrimStr( (decimal)(AV17SecurityPolicyMinimumSpecialCharactersPassword), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicymaximumpasswordhistoryentries_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicymaximumpasswordhistoryentries_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYMAXIMUMPASSWORDHISTORYENTRIES");
               GX_FocusControl = edtavSecuritypolicymaximumpasswordhistoryentries_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18SecurityPolicyMaximumPasswordHistoryEntries = 0;
               AssignAttri("", false, "AV18SecurityPolicyMaximumPasswordHistoryEntries", StringUtil.LTrimStr( (decimal)(AV18SecurityPolicyMaximumPasswordHistoryEntries), 4, 0));
            }
            else
            {
               AV18SecurityPolicyMaximumPasswordHistoryEntries = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicymaximumpasswordhistoryentries_Internalname), ",", "."));
               AssignAttri("", false, "AV18SecurityPolicyMaximumPasswordHistoryEntries", StringUtil.LTrimStr( (decimal)(AV18SecurityPolicyMaximumPasswordHistoryEntries), 4, 0));
            }
            cmbavSecuritypolicyallowmultipleconcurrentwebsessions.CurrentValue = cgiGet( cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname);
            AV10SecurityPolicyAllowMultipleConcurrentWebSessions = (short)(NumberUtil.Val( cgiGet( cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname), "."));
            AssignAttri("", false, "AV10SecurityPolicyAllowMultipleConcurrentWebSessions", StringUtil.LTrimStr( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicywebsessiontimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicywebsessiontimeout_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYWEBSESSIONTIMEOUT");
               GX_FocusControl = edtavSecuritypolicywebsessiontimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11SecurityPolicyWebSessionTimeout = 0;
               AssignAttri("", false, "AV11SecurityPolicyWebSessionTimeout", StringUtil.LTrimStr( (decimal)(AV11SecurityPolicyWebSessionTimeout), 4, 0));
            }
            else
            {
               AV11SecurityPolicyWebSessionTimeout = (short)(context.localUtil.CToN( cgiGet( edtavSecuritypolicywebsessiontimeout_Internalname), ",", "."));
               AssignAttri("", false, "AV11SecurityPolicyWebSessionTimeout", StringUtil.LTrimStr( (decimal)(AV11SecurityPolicyWebSessionTimeout), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyoauthtokenexpire_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyoauthtokenexpire_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYOAUTHTOKENEXPIRE");
               GX_FocusControl = edtavSecuritypolicyoauthtokenexpire_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9SecurityPolicyOauthTokenExpire = 0;
               AssignAttri("", false, "AV9SecurityPolicyOauthTokenExpire", StringUtil.LTrimStr( (decimal)(AV9SecurityPolicyOauthTokenExpire), 6, 0));
            }
            else
            {
               AV9SecurityPolicyOauthTokenExpire = (int)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyoauthtokenexpire_Internalname), ",", "."));
               AssignAttri("", false, "AV9SecurityPolicyOauthTokenExpire", StringUtil.LTrimStr( (decimal)(AV9SecurityPolicyOauthTokenExpire), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSECURITYPOLICYOAUTHTOKENMAXIMUMRENOVATIONS");
               GX_FocusControl = edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22SecurityPolicyOauthTokenMaximumRenovations = 0;
               AssignAttri("", false, "AV22SecurityPolicyOauthTokenMaximumRenovations", StringUtil.LTrimStr( (decimal)(AV22SecurityPolicyOauthTokenMaximumRenovations), 6, 0));
            }
            else
            {
               AV22SecurityPolicyOauthTokenMaximumRenovations = (int)(context.localUtil.CToN( cgiGet( edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname), ",", "."));
               AssignAttri("", false, "AV22SecurityPolicyOauthTokenMaximumRenovations", StringUtil.LTrimStr( (decimal)(AV22SecurityPolicyOauthTokenMaximumRenovations), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"GAMSecurityPolicyEntry");
            AV20SecurityPolicyGUID = cgiGet( edtavSecuritypolicyguid_Internalname);
            AssignAttri("", false, "AV20SecurityPolicyGUID", AV20SecurityPolicyGUID);
            forbiddenHiddens.Add("SecurityPolicyGUID", StringUtil.RTrim( context.localUtil.Format( AV20SecurityPolicyGUID, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("gamsecuritypolicyentry:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E111E2 ();
         if (returnInSub) return;
      }

      protected void E111E2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV8SecurityPolicy.load( (int)(AV7Id));
            AV19SecurityPolicyId = AV8SecurityPolicy.gxTpr_Id;
            AssignAttri("", false, "AV19SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV19SecurityPolicyId), 9, 0));
            AV20SecurityPolicyGUID = AV8SecurityPolicy.gxTpr_Guid;
            AssignAttri("", false, "AV20SecurityPolicyGUID", AV20SecurityPolicyGUID);
            AV21SecurityPolicyName = AV8SecurityPolicy.gxTpr_Name;
            AssignAttri("", false, "AV21SecurityPolicyName", AV21SecurityPolicyName);
            AV12SecurityPolicyPeriodChangePassword = AV8SecurityPolicy.gxTpr_Periodchangepassword;
            AssignAttri("", false, "AV12SecurityPolicyPeriodChangePassword", StringUtil.LTrimStr( (decimal)(AV12SecurityPolicyPeriodChangePassword), 4, 0));
            AV13SecurityPolicyMinimumTimeToChangePasswords = AV8SecurityPolicy.gxTpr_Minimumtimetochangepasswords;
            AssignAttri("", false, "AV13SecurityPolicyMinimumTimeToChangePasswords", StringUtil.LTrimStr( (decimal)(AV13SecurityPolicyMinimumTimeToChangePasswords), 4, 0));
            AV14SecurityPolicyMinimumLengthPassword = AV8SecurityPolicy.gxTpr_Minimumlengthpassword;
            AssignAttri("", false, "AV14SecurityPolicyMinimumLengthPassword", StringUtil.LTrimStr( (decimal)(AV14SecurityPolicyMinimumLengthPassword), 2, 0));
            AV15SecurityPolicyMinimumNumericCharactersPassword = AV8SecurityPolicy.gxTpr_Minimumnumericcharacterspassword;
            AssignAttri("", false, "AV15SecurityPolicyMinimumNumericCharactersPassword", StringUtil.LTrimStr( (decimal)(AV15SecurityPolicyMinimumNumericCharactersPassword), 2, 0));
            AV16SecurityPolicyMinimumUpperCaseCharactersPassword = AV8SecurityPolicy.gxTpr_Minimumuppercasecharacterspassword;
            AssignAttri("", false, "AV16SecurityPolicyMinimumUpperCaseCharactersPassword", StringUtil.LTrimStr( (decimal)(AV16SecurityPolicyMinimumUpperCaseCharactersPassword), 2, 0));
            AV17SecurityPolicyMinimumSpecialCharactersPassword = AV8SecurityPolicy.gxTpr_Minimumspecialcharacterspassword;
            AssignAttri("", false, "AV17SecurityPolicyMinimumSpecialCharactersPassword", StringUtil.LTrimStr( (decimal)(AV17SecurityPolicyMinimumSpecialCharactersPassword), 2, 0));
            AV18SecurityPolicyMaximumPasswordHistoryEntries = AV8SecurityPolicy.gxTpr_Maximumpasswordhistoryentries;
            AssignAttri("", false, "AV18SecurityPolicyMaximumPasswordHistoryEntries", StringUtil.LTrimStr( (decimal)(AV18SecurityPolicyMaximumPasswordHistoryEntries), 4, 0));
            AV10SecurityPolicyAllowMultipleConcurrentWebSessions = AV8SecurityPolicy.gxTpr_Allowmultipleconcurrentwebsessions;
            AssignAttri("", false, "AV10SecurityPolicyAllowMultipleConcurrentWebSessions", StringUtil.LTrimStr( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0));
            AV11SecurityPolicyWebSessionTimeout = AV8SecurityPolicy.gxTpr_Websessiontimeout;
            AssignAttri("", false, "AV11SecurityPolicyWebSessionTimeout", StringUtil.LTrimStr( (decimal)(AV11SecurityPolicyWebSessionTimeout), 4, 0));
            AV9SecurityPolicyOauthTokenExpire = AV8SecurityPolicy.gxTpr_Oauthtokenexpire;
            AssignAttri("", false, "AV9SecurityPolicyOauthTokenExpire", StringUtil.LTrimStr( (decimal)(AV9SecurityPolicyOauthTokenExpire), 6, 0));
            AV22SecurityPolicyOauthTokenMaximumRenovations = AV8SecurityPolicy.gxTpr_Oauthtokenmaximumrenovations;
            AssignAttri("", false, "AV22SecurityPolicyOauthTokenMaximumRenovations", StringUtil.LTrimStr( (decimal)(AV22SecurityPolicyOauthTokenMaximumRenovations), 6, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavSecuritypolicyname_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyname_Enabled), 5, 0), true);
            cmbavSecuritypolicyallowmultipleconcurrentwebsessions.Enabled = 0;
            AssignProp("", false, cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecuritypolicyallowmultipleconcurrentwebsessions.Enabled), 5, 0), true);
            edtavSecuritypolicywebsessiontimeout_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicywebsessiontimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicywebsessiontimeout_Enabled), 5, 0), true);
            edtavSecuritypolicyoauthtokenexpire_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyoauthtokenexpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyoauthtokenexpire_Enabled), 5, 0), true);
            edtavSecuritypolicyoauthtokenmaximumrenovations_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyoauthtokenmaximumrenovations_Enabled), 5, 0), true);
            edtavSecuritypolicyperiodchangepassword_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyperiodchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyperiodchangepassword_Enabled), 5, 0), true);
            edtavSecuritypolicyminimumtimetochangepasswords_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyminimumtimetochangepasswords_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyminimumtimetochangepasswords_Enabled), 5, 0), true);
            edtavSecuritypolicyminimumlengthpassword_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyminimumlengthpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyminimumlengthpassword_Enabled), 5, 0), true);
            edtavSecuritypolicyminimumnumericcharacterspassword_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyminimumnumericcharacterspassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyminimumnumericcharacterspassword_Enabled), 5, 0), true);
            edtavSecuritypolicyminimumuppercasecharacterspassword_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyminimumuppercasecharacterspassword_Enabled), 5, 0), true);
            edtavSecuritypolicyminimumspecialcharacterspassword_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicyminimumspecialcharacterspassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicyminimumspecialcharacterspassword_Enabled), 5, 0), true);
            edtavSecuritypolicymaximumpasswordhistoryentries_Enabled = 0;
            AssignProp("", false, edtavSecuritypolicymaximumpasswordhistoryentries_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuritypolicymaximumpasswordhistoryentries_Enabled), 5, 0), true);
            bttBtnenter_Caption = "Delete";
            AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E121E2 ();
         if (returnInSub) return;
      }

      protected void E121E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8SecurityPolicy.load( (int)(AV7Id));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            AV19SecurityPolicyId = AV8SecurityPolicy.gxTpr_Id;
            AssignAttri("", false, "AV19SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV19SecurityPolicyId), 9, 0));
            AV8SecurityPolicy.gxTpr_Guid = AV20SecurityPolicyGUID;
            AV8SecurityPolicy.gxTpr_Name = AV21SecurityPolicyName;
            AV8SecurityPolicy.gxTpr_Periodchangepassword = AV12SecurityPolicyPeriodChangePassword;
            AV8SecurityPolicy.gxTpr_Minimumtimetochangepasswords = AV13SecurityPolicyMinimumTimeToChangePasswords;
            AV8SecurityPolicy.gxTpr_Minimumlengthpassword = AV14SecurityPolicyMinimumLengthPassword;
            AV8SecurityPolicy.gxTpr_Minimumnumericcharacterspassword = AV15SecurityPolicyMinimumNumericCharactersPassword;
            AV8SecurityPolicy.gxTpr_Minimumuppercasecharacterspassword = AV16SecurityPolicyMinimumUpperCaseCharactersPassword;
            AV8SecurityPolicy.gxTpr_Minimumspecialcharacterspassword = AV17SecurityPolicyMinimumSpecialCharactersPassword;
            AV8SecurityPolicy.gxTpr_Maximumpasswordhistoryentries = AV18SecurityPolicyMaximumPasswordHistoryEntries;
            AV8SecurityPolicy.gxTpr_Allowmultipleconcurrentwebsessions = (short)(NumberUtil.Val( StringUtil.Str( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0), "."));
            AV8SecurityPolicy.gxTpr_Websessiontimeout = AV11SecurityPolicyWebSessionTimeout;
            AV8SecurityPolicy.gxTpr_Oauthtokenexpire = AV9SecurityPolicyOauthTokenExpire;
            AV8SecurityPolicy.gxTpr_Oauthtokenmaximumrenovations = (short)(AV22SecurityPolicyOauthTokenMaximumRenovations);
            AV8SecurityPolicy.save();
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV8SecurityPolicy.delete();
         }
         if ( AV8SecurityPolicy.success() )
         {
            context.CommitDataStores("gamsecuritypolicyentry",pr_default);
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(long)AV7Id});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV7Id"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV6Errors = AV8SecurityPolicy.geterrors();
            AV31GXV1 = 1;
            while ( AV31GXV1 <= AV6Errors.Count )
            {
               AV5Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV6Errors.Item(AV31GXV1));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV5Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV5Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV31GXV1 = (int)(AV31GXV1+1);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E131E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV7Id = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV7Id", StringUtil.LTrimStr( (decimal)(AV7Id), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Id), "ZZZZZZZZZZZ9"), context));
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
         PA1E2( ) ;
         WS1E2( ) ;
         WE1E2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815524079", true, true);
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
         context.AddJavascriptSource("gamsecuritypolicyentry.js", "?202142815524080", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions.Name = "vSECURITYPOLICYALLOWMULTIPLECONCURRENTWEBSESSIONS";
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions.WebTags = "";
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions.addItem("1", "Sim, desde um endereço IP diferente", 0);
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions.addItem("2", "Sim, desde o mesmo endereço IP", 0);
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions.addItem("3", "Único", 0);
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions.addItem("4", "Não", 0);
         if ( cmbavSecuritypolicyallowmultipleconcurrentwebsessions.ItemCount > 0 )
         {
            AV10SecurityPolicyAllowMultipleConcurrentWebSessions = (short)(NumberUtil.Val( cmbavSecuritypolicyallowmultipleconcurrentwebsessions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0))), "."));
            AssignAttri("", false, "AV10SecurityPolicyAllowMultipleConcurrentWebSessions", StringUtil.LTrimStr( (decimal)(AV10SecurityPolicyAllowMultipleConcurrentWebSessions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavSecuritypolicyid_Internalname = "vSECURITYPOLICYID";
         edtavSecuritypolicyguid_Internalname = "vSECURITYPOLICYGUID";
         edtavSecuritypolicyname_Internalname = "vSECURITYPOLICYNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         edtavSecuritypolicyperiodchangepassword_Internalname = "vSECURITYPOLICYPERIODCHANGEPASSWORD";
         edtavSecuritypolicyminimumtimetochangepasswords_Internalname = "vSECURITYPOLICYMINIMUMTIMETOCHANGEPASSWORDS";
         edtavSecuritypolicyminimumlengthpassword_Internalname = "vSECURITYPOLICYMINIMUMLENGTHPASSWORD";
         edtavSecuritypolicyminimumnumericcharacterspassword_Internalname = "vSECURITYPOLICYMINIMUMNUMERICCHARACTERSPASSWORD";
         edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname = "vSECURITYPOLICYMINIMUMUPPERCASECHARACTERSPASSWORD";
         edtavSecuritypolicyminimumspecialcharacterspassword_Internalname = "vSECURITYPOLICYMINIMUMSPECIALCHARACTERSPASSWORD";
         edtavSecuritypolicymaximumpasswordhistoryentries_Internalname = "vSECURITYPOLICYMAXIMUMPASSWORDHISTORYENTRIES";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname = "vSECURITYPOLICYALLOWMULTIPLECONCURRENTWEBSESSIONS";
         edtavSecuritypolicywebsessiontimeout_Internalname = "vSECURITYPOLICYWEBSESSIONTIMEOUT";
         divOnlyweb_Internalname = "ONLYWEB";
         Dvpanel_onlyweb_Internalname = "DVPANEL_ONLYWEB";
         edtavSecuritypolicyoauthtokenexpire_Internalname = "vSECURITYPOLICYOAUTHTOKENEXPIRE";
         edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname = "vSECURITYPOLICYOAUTHTOKENMAXIMUMRENOVATIONS";
         divOnlysd_Internalname = "ONLYSD";
         Dvpanel_onlysd_Internalname = "DVPANEL_ONLYSD";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
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
         bttBtnenter_Caption = "Confirmar";
         bttBtnenter_Visible = 1;
         edtavSecuritypolicyoauthtokenmaximumrenovations_Jsonclick = "";
         edtavSecuritypolicyoauthtokenmaximumrenovations_Enabled = 1;
         edtavSecuritypolicyoauthtokenexpire_Jsonclick = "";
         edtavSecuritypolicyoauthtokenexpire_Enabled = 1;
         edtavSecuritypolicywebsessiontimeout_Jsonclick = "";
         edtavSecuritypolicywebsessiontimeout_Enabled = 1;
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Jsonclick = "";
         cmbavSecuritypolicyallowmultipleconcurrentwebsessions.Enabled = 1;
         edtavSecuritypolicymaximumpasswordhistoryentries_Jsonclick = "";
         edtavSecuritypolicymaximumpasswordhistoryentries_Enabled = 1;
         edtavSecuritypolicyminimumspecialcharacterspassword_Jsonclick = "";
         edtavSecuritypolicyminimumspecialcharacterspassword_Enabled = 1;
         edtavSecuritypolicyminimumuppercasecharacterspassword_Jsonclick = "";
         edtavSecuritypolicyminimumuppercasecharacterspassword_Enabled = 1;
         edtavSecuritypolicyminimumnumericcharacterspassword_Jsonclick = "";
         edtavSecuritypolicyminimumnumericcharacterspassword_Enabled = 1;
         edtavSecuritypolicyminimumlengthpassword_Jsonclick = "";
         edtavSecuritypolicyminimumlengthpassword_Enabled = 1;
         edtavSecuritypolicyminimumtimetochangepasswords_Jsonclick = "";
         edtavSecuritypolicyminimumtimetochangepasswords_Enabled = 1;
         edtavSecuritypolicyperiodchangepassword_Jsonclick = "";
         edtavSecuritypolicyperiodchangepassword_Enabled = 1;
         edtavSecuritypolicyname_Jsonclick = "";
         edtavSecuritypolicyname_Enabled = 1;
         edtavSecuritypolicyguid_Jsonclick = "";
         edtavSecuritypolicyguid_Enabled = 1;
         edtavSecuritypolicyid_Jsonclick = "";
         edtavSecuritypolicyid_Enabled = 1;
         Dvpanel_onlysd_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_onlysd_Iconposition = "Right";
         Dvpanel_onlysd_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_onlysd_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_onlysd_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_onlysd_Title = "Só smart devices";
         Dvpanel_onlysd_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_onlysd_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_onlysd_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_onlysd_Width = "100%";
         Dvpanel_onlyweb_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_onlyweb_Iconposition = "Right";
         Dvpanel_onlyweb_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_onlyweb_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_onlyweb_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_onlyweb_Title = "Só web";
         Dvpanel_onlyweb_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_onlyweb_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_onlyweb_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_onlyweb_Width = "100%";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = "Configurações de senha";
         Dvpanel_unnamedtable1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Política de segurança";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Política de segurança";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV7Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV20SecurityPolicyGUID',fld:'vSECURITYPOLICYGUID',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E121E2',iparms:[{av:'AV7Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV20SecurityPolicyGUID',fld:'vSECURITYPOLICYGUID',pic:''},{av:'AV21SecurityPolicyName',fld:'vSECURITYPOLICYNAME',pic:''},{av:'AV12SecurityPolicyPeriodChangePassword',fld:'vSECURITYPOLICYPERIODCHANGEPASSWORD',pic:'ZZZ9'},{av:'AV13SecurityPolicyMinimumTimeToChangePasswords',fld:'vSECURITYPOLICYMINIMUMTIMETOCHANGEPASSWORDS',pic:'ZZZ9'},{av:'AV14SecurityPolicyMinimumLengthPassword',fld:'vSECURITYPOLICYMINIMUMLENGTHPASSWORD',pic:'Z9'},{av:'AV15SecurityPolicyMinimumNumericCharactersPassword',fld:'vSECURITYPOLICYMINIMUMNUMERICCHARACTERSPASSWORD',pic:'Z9'},{av:'AV16SecurityPolicyMinimumUpperCaseCharactersPassword',fld:'vSECURITYPOLICYMINIMUMUPPERCASECHARACTERSPASSWORD',pic:'Z9'},{av:'AV17SecurityPolicyMinimumSpecialCharactersPassword',fld:'vSECURITYPOLICYMINIMUMSPECIALCHARACTERSPASSWORD',pic:'Z9'},{av:'AV18SecurityPolicyMaximumPasswordHistoryEntries',fld:'vSECURITYPOLICYMAXIMUMPASSWORDHISTORYENTRIES',pic:'ZZZ9'},{av:'cmbavSecuritypolicyallowmultipleconcurrentwebsessions'},{av:'AV10SecurityPolicyAllowMultipleConcurrentWebSessions',fld:'vSECURITYPOLICYALLOWMULTIPLECONCURRENTWEBSESSIONS',pic:'ZZZ9'},{av:'AV11SecurityPolicyWebSessionTimeout',fld:'vSECURITYPOLICYWEBSESSIONTIMEOUT',pic:'ZZZ9'},{av:'AV9SecurityPolicyOauthTokenExpire',fld:'vSECURITYPOLICYOAUTHTOKENEXPIRE',pic:'ZZZZZ9'},{av:'AV22SecurityPolicyOauthTokenMaximumRenovations',fld:'vSECURITYPOLICYOAUTHTOKENMAXIMUMRENOVATIONS',pic:'ZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV19SecurityPolicyId',fld:'vSECURITYPOLICYID',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("VALIDV_SECURITYPOLICYALLOWMULTIPLECONCURRENTWEBSESSIONS","{handler:'Validv_Securitypolicyallowmultipleconcurrentwebsessions',iparms:[]");
         setEventMetadata("VALIDV_SECURITYPOLICYALLOWMULTIPLECONCURRENTWEBSESSIONS",",oparms:[]}");
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
         forbiddenHiddens = new GXProperties();
         AV20SecurityPolicyGUID = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV21SecurityPolicyName = "";
         ucDvpanel_unnamedtable1 = new GXUserControl();
         ucDvpanel_onlyweb = new GXUserControl();
         ucDvpanel_onlysd = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         hsh = "";
         AV8SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV6Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamsecuritypolicyentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamsecuritypolicyentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSecuritypolicyid_Enabled = 0;
         edtavSecuritypolicyguid_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV12SecurityPolicyPeriodChangePassword ;
      private short AV13SecurityPolicyMinimumTimeToChangePasswords ;
      private short AV14SecurityPolicyMinimumLengthPassword ;
      private short AV15SecurityPolicyMinimumNumericCharactersPassword ;
      private short AV16SecurityPolicyMinimumUpperCaseCharactersPassword ;
      private short AV17SecurityPolicyMinimumSpecialCharactersPassword ;
      private short AV18SecurityPolicyMaximumPasswordHistoryEntries ;
      private short AV10SecurityPolicyAllowMultipleConcurrentWebSessions ;
      private short AV11SecurityPolicyWebSessionTimeout ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV19SecurityPolicyId ;
      private int edtavSecuritypolicyid_Enabled ;
      private int edtavSecuritypolicyguid_Enabled ;
      private int edtavSecuritypolicyname_Enabled ;
      private int edtavSecuritypolicyperiodchangepassword_Enabled ;
      private int edtavSecuritypolicyminimumtimetochangepasswords_Enabled ;
      private int edtavSecuritypolicyminimumlengthpassword_Enabled ;
      private int edtavSecuritypolicyminimumnumericcharacterspassword_Enabled ;
      private int edtavSecuritypolicyminimumuppercasecharacterspassword_Enabled ;
      private int edtavSecuritypolicyminimumspecialcharacterspassword_Enabled ;
      private int edtavSecuritypolicymaximumpasswordhistoryentries_Enabled ;
      private int edtavSecuritypolicywebsessiontimeout_Enabled ;
      private int AV9SecurityPolicyOauthTokenExpire ;
      private int edtavSecuritypolicyoauthtokenexpire_Enabled ;
      private int AV22SecurityPolicyOauthTokenMaximumRenovations ;
      private int edtavSecuritypolicyoauthtokenmaximumrenovations_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV31GXV1 ;
      private int idxLst ;
      private long AV7Id ;
      private long wcpOAV7Id ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV20SecurityPolicyGUID ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string Dvpanel_onlyweb_Width ;
      private string Dvpanel_onlyweb_Cls ;
      private string Dvpanel_onlyweb_Title ;
      private string Dvpanel_onlyweb_Iconposition ;
      private string Dvpanel_onlysd_Width ;
      private string Dvpanel_onlysd_Cls ;
      private string Dvpanel_onlysd_Title ;
      private string Dvpanel_onlysd_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavSecuritypolicyid_Internalname ;
      private string TempTags ;
      private string edtavSecuritypolicyid_Jsonclick ;
      private string edtavSecuritypolicyguid_Internalname ;
      private string edtavSecuritypolicyguid_Jsonclick ;
      private string edtavSecuritypolicyname_Internalname ;
      private string AV21SecurityPolicyName ;
      private string edtavSecuritypolicyname_Jsonclick ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavSecuritypolicyperiodchangepassword_Internalname ;
      private string edtavSecuritypolicyperiodchangepassword_Jsonclick ;
      private string edtavSecuritypolicyminimumtimetochangepasswords_Internalname ;
      private string edtavSecuritypolicyminimumtimetochangepasswords_Jsonclick ;
      private string edtavSecuritypolicyminimumlengthpassword_Internalname ;
      private string edtavSecuritypolicyminimumlengthpassword_Jsonclick ;
      private string edtavSecuritypolicyminimumnumericcharacterspassword_Internalname ;
      private string edtavSecuritypolicyminimumnumericcharacterspassword_Jsonclick ;
      private string edtavSecuritypolicyminimumuppercasecharacterspassword_Internalname ;
      private string edtavSecuritypolicyminimumuppercasecharacterspassword_Jsonclick ;
      private string edtavSecuritypolicyminimumspecialcharacterspassword_Internalname ;
      private string edtavSecuritypolicyminimumspecialcharacterspassword_Jsonclick ;
      private string edtavSecuritypolicymaximumpasswordhistoryentries_Internalname ;
      private string edtavSecuritypolicymaximumpasswordhistoryentries_Jsonclick ;
      private string Dvpanel_onlyweb_Internalname ;
      private string divOnlyweb_Internalname ;
      private string cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Internalname ;
      private string cmbavSecuritypolicyallowmultipleconcurrentwebsessions_Jsonclick ;
      private string edtavSecuritypolicywebsessiontimeout_Internalname ;
      private string edtavSecuritypolicywebsessiontimeout_Jsonclick ;
      private string Dvpanel_onlysd_Internalname ;
      private string divOnlysd_Internalname ;
      private string edtavSecuritypolicyoauthtokenexpire_Internalname ;
      private string edtavSecuritypolicyoauthtokenexpire_Jsonclick ;
      private string edtavSecuritypolicyoauthtokenmaximumrenovations_Internalname ;
      private string edtavSecuritypolicyoauthtokenmaximumrenovations_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool Dvpanel_onlyweb_Autowidth ;
      private bool Dvpanel_onlyweb_Autoheight ;
      private bool Dvpanel_onlyweb_Collapsible ;
      private bool Dvpanel_onlyweb_Collapsed ;
      private bool Dvpanel_onlyweb_Showcollapseicon ;
      private bool Dvpanel_onlyweb_Autoscroll ;
      private bool Dvpanel_onlysd_Autowidth ;
      private bool Dvpanel_onlysd_Autoheight ;
      private bool Dvpanel_onlysd_Collapsible ;
      private bool Dvpanel_onlysd_Collapsed ;
      private bool Dvpanel_onlysd_Showcollapseicon ;
      private bool Dvpanel_onlysd_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucDvpanel_onlyweb ;
      private GXUserControl ucDvpanel_onlysd ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_Id ;
      private GXCombobox cmbavSecuritypolicyallowmultipleconcurrentwebsessions ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV6Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV5Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV8SecurityPolicy ;
   }

   public class gamsecuritypolicyentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamsecuritypolicyentry__default : DataStoreHelperBase, IDataStoreHelper
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
