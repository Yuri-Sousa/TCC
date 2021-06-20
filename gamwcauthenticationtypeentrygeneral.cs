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
   public class gamwcauthenticationtypeentrygeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public gamwcauthenticationtypeentrygeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
      }

      public gamwcauthenticationtypeentrygeneral( IGxContext context )
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
                           ref string aP1_Name ,
                           ref string aP2_TypeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV34Name = aP1_Name;
         this.AV37TypeId = aP2_TypeId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV34Name;
         aP2_TypeId=this.AV37TypeId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavFunctionid = new GXCombobox();
         chkavIsenable = new GXCheckbox();
         cmbavWsversion = new GXCombobox();
         cmbavWsserversecureprotocol = new GXCombobox();
         cmbavCusversion = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  Gx_mode = GetPar( "Mode");
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  AV34Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV34Name", AV34Name);
                  AV37TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV37TypeId", AV37TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA122( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS122( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Authentication Type Entry General") ;
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
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202142815462992", false, true);
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwcauthenticationtypeentrygeneral.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV34Name)),UrlEncode(StringUtil.RTrim(AV37TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV34Name", StringUtil.RTrim( wcpOAV34Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV37TypeId", StringUtil.RTrim( wcpOAV37TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV37TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Width", StringUtil.RTrim( Dvpanel_fb_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Autowidth", StringUtil.BoolToStr( Dvpanel_fb_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Autoheight", StringUtil.BoolToStr( Dvpanel_fb_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Cls", StringUtil.RTrim( Dvpanel_fb_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Title", StringUtil.RTrim( Dvpanel_fb_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Collapsible", StringUtil.BoolToStr( Dvpanel_fb_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Collapsed", StringUtil.BoolToStr( Dvpanel_fb_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_fb_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Iconposition", StringUtil.RTrim( Dvpanel_fb_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_FB_Autoscroll", StringUtil.BoolToStr( Dvpanel_fb_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Width", StringUtil.RTrim( Dvpanel_tw_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Autowidth", StringUtil.BoolToStr( Dvpanel_tw_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Autoheight", StringUtil.BoolToStr( Dvpanel_tw_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Cls", StringUtil.RTrim( Dvpanel_tw_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Title", StringUtil.RTrim( Dvpanel_tw_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Collapsible", StringUtil.BoolToStr( Dvpanel_tw_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Collapsed", StringUtil.BoolToStr( Dvpanel_tw_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tw_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Iconposition", StringUtil.RTrim( Dvpanel_tw_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TW_Autoscroll", StringUtil.BoolToStr( Dvpanel_tw_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Width", StringUtil.RTrim( Dvpanel_ws_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Autowidth", StringUtil.BoolToStr( Dvpanel_ws_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Autoheight", StringUtil.BoolToStr( Dvpanel_ws_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Cls", StringUtil.RTrim( Dvpanel_ws_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Title", StringUtil.RTrim( Dvpanel_ws_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Collapsible", StringUtil.BoolToStr( Dvpanel_ws_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Collapsed", StringUtil.BoolToStr( Dvpanel_ws_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_ws_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Iconposition", StringUtil.RTrim( Dvpanel_ws_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_WS_Autoscroll", StringUtil.BoolToStr( Dvpanel_ws_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Width", StringUtil.RTrim( Dvpanel_ext_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Autowidth", StringUtil.BoolToStr( Dvpanel_ext_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Autoheight", StringUtil.BoolToStr( Dvpanel_ext_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Cls", StringUtil.RTrim( Dvpanel_ext_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Title", StringUtil.RTrim( Dvpanel_ext_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Collapsible", StringUtil.BoolToStr( Dvpanel_ext_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Collapsed", StringUtil.BoolToStr( Dvpanel_ext_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_ext_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Iconposition", StringUtil.RTrim( Dvpanel_ext_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_EXT_Autoscroll", StringUtil.BoolToStr( Dvpanel_ext_Autoscroll));
      }

      protected void RenderHtmlCloseForm122( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "GAMWCAuthenticationTypeEntryGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Authentication Type Entry General" ;
      }

      protected void WB120( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "gamwcauthenticationtypeentrygeneral.aspx");
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV34Name), StringUtil.RTrim( context.localUtil.Format( AV34Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFunctionid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFunctionid_Internalname, "Função", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV28FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV28FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", (string)(cmbavFunctionid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Descrição", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV25Dsc), StringUtil.RTrim( context.localUtil.Format( AV25Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenable_Internalname, "Habilitado?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV33IsEnable), "", "Habilitado?", 1, chkavIsenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(34, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,34);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavAdditionalscope_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAdditionalscope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdditionalscope_Internalname, "Escopo adicional", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdditionalscope_Internalname, AV5AdditionalScope, StringUtil.RTrim( context.localUtil.Format( AV5AdditionalScope, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdditionalscope_Jsonclick, 0, "Attribute", "", "", "", "", edtavAdditionalscope_Visible, edtavAdditionalscope_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSmallimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSmallimagename_Internalname, "Nome da imagem pequena", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV36SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV36SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSmallimagename_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavBigimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBigimagename_Internalname, "Nome da imagem grande", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV14BigImageName), StringUtil.RTrim( context.localUtil.Format( AV14BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavBigimagename_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTblfacebook_Internalname, divTblfacebook_Visible, 0, "px", 0, "px", "Table100x100", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_fb.SetProperty("Width", Dvpanel_fb_Width);
            ucDvpanel_fb.SetProperty("AutoWidth", Dvpanel_fb_Autowidth);
            ucDvpanel_fb.SetProperty("AutoHeight", Dvpanel_fb_Autoheight);
            ucDvpanel_fb.SetProperty("Cls", Dvpanel_fb_Cls);
            ucDvpanel_fb.SetProperty("Title", Dvpanel_fb_Title);
            ucDvpanel_fb.SetProperty("Collapsible", Dvpanel_fb_Collapsible);
            ucDvpanel_fb.SetProperty("Collapsed", Dvpanel_fb_Collapsed);
            ucDvpanel_fb.SetProperty("ShowCollapseIcon", Dvpanel_fb_Showcollapseicon);
            ucDvpanel_fb.SetProperty("IconPosition", Dvpanel_fb_Iconposition);
            ucDvpanel_fb.SetProperty("AutoScroll", Dvpanel_fb_Autoscroll);
            ucDvpanel_fb.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_fb_Internalname, sPrefix+"DVPANEL_FBContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_FBContainer"+"Fb"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divFb_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientid_Internalname, "Id do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientid_Internalname, AV16ClientId, StringUtil.RTrim( context.localUtil.Format( AV16ClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientid_Enabled, 1, "text", "", 80, "chr", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavClientsecret_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientsecret_Internalname, "Segredo do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientsecret_Internalname, AV17ClientSecret, StringUtil.RTrim( context.localUtil.Format( AV17ClientSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientsecret_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientsecret_Enabled, 1, "text", "", 80, "chr", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSiteurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSiteurl_Internalname, "Url do site", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSiteurl_Internalname, AV35SiteURL, StringUtil.RTrim( context.localUtil.Format( AV35SiteURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSiteurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSiteurl_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavImpersonate_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavImpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImpersonate_Internalname, "Personificar", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImpersonate_Internalname, StringUtil.RTrim( AV32Impersonate), StringUtil.RTrim( context.localUtil.Format( AV32Impersonate, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImpersonate_Jsonclick, 0, "Attribute", "", "", "", "", edtavImpersonate_Visible, edtavImpersonate_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGamrserverurl_cell_Internalname, 1, 0, "px", 0, "px", divGamrserverurl_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavGamrserverurl_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavGamrserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrserverurl_Internalname, "Url do servidor remoto", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrserverurl_Internalname, AV31GAMRServerURL, StringUtil.RTrim( context.localUtil.Format( AV31GAMRServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrserverurl_Jsonclick, 0, "Attribute", "", "", "", "", edtavGamrserverurl_Visible, edtavGamrserverurl_Enabled, 0, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGamrprivateencryptkey_cell_Internalname, 1, 0, "px", 0, "px", divGamrprivateencryptkey_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavGamrprivateencryptkey_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavGamrprivateencryptkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrprivateencryptkey_Internalname, "Chave privada de criptografia", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrprivateencryptkey_Internalname, StringUtil.RTrim( AV29GAMRPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV29GAMRPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrprivateencryptkey_Jsonclick, 0, "Attribute", "", "", "", "", edtavGamrprivateencryptkey_Visible, edtavGamrprivateencryptkey_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGamrrepositoryguid_cell_Internalname, 1, 0, "px", 0, "px", divGamrrepositoryguid_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavGamrrepositoryguid_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavGamrrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamrrepositoryguid_Internalname, "Guid", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamrrepositoryguid_Internalname, StringUtil.RTrim( AV30GAMRRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV30GAMRRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamrrepositoryguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavGamrrepositoryguid_Visible, edtavGamrrepositoryguid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTbltwitter_Internalname, divTbltwitter_Visible, 0, "px", 0, "px", "Table100x100", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tw.SetProperty("Width", Dvpanel_tw_Width);
            ucDvpanel_tw.SetProperty("AutoWidth", Dvpanel_tw_Autowidth);
            ucDvpanel_tw.SetProperty("AutoHeight", Dvpanel_tw_Autoheight);
            ucDvpanel_tw.SetProperty("Cls", Dvpanel_tw_Cls);
            ucDvpanel_tw.SetProperty("Title", Dvpanel_tw_Title);
            ucDvpanel_tw.SetProperty("Collapsible", Dvpanel_tw_Collapsible);
            ucDvpanel_tw.SetProperty("Collapsed", Dvpanel_tw_Collapsed);
            ucDvpanel_tw.SetProperty("ShowCollapseIcon", Dvpanel_tw_Showcollapseicon);
            ucDvpanel_tw.SetProperty("IconPosition", Dvpanel_tw_Iconposition);
            ucDvpanel_tw.SetProperty("AutoScroll", Dvpanel_tw_Autoscroll);
            ucDvpanel_tw.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tw_Internalname, sPrefix+"DVPANEL_TWContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TWContainer"+"Tw"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTw_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavConsumerkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConsumerkey_Internalname, "Chave do consumidor", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConsumerkey_Internalname, StringUtil.RTrim( AV18ConsumerKey), StringUtil.RTrim( context.localUtil.Format( AV18ConsumerKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConsumerkey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavConsumerkey_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavConsumersecret_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConsumersecret_Internalname, "Segredo do consumidor", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConsumersecret_Internalname, StringUtil.RTrim( AV19ConsumerSecret), StringUtil.RTrim( context.localUtil.Format( AV19ConsumerSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConsumersecret_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavConsumersecret_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCallbackurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCallbackurl_Internalname, "Url de retorno", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCallbackurl_Internalname, AV15CallbackURL, StringUtil.RTrim( context.localUtil.Format( AV15CallbackURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCallbackurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCallbackurl_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTblwebservice_Internalname, divTblwebservice_Visible, 0, "px", 0, "px", "Table100x100", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_ws.SetProperty("Width", Dvpanel_ws_Width);
            ucDvpanel_ws.SetProperty("AutoWidth", Dvpanel_ws_Autowidth);
            ucDvpanel_ws.SetProperty("AutoHeight", Dvpanel_ws_Autoheight);
            ucDvpanel_ws.SetProperty("Cls", Dvpanel_ws_Cls);
            ucDvpanel_ws.SetProperty("Title", Dvpanel_ws_Title);
            ucDvpanel_ws.SetProperty("Collapsible", Dvpanel_ws_Collapsible);
            ucDvpanel_ws.SetProperty("Collapsed", Dvpanel_ws_Collapsed);
            ucDvpanel_ws.SetProperty("ShowCollapseIcon", Dvpanel_ws_Showcollapseicon);
            ucDvpanel_ws.SetProperty("IconPosition", Dvpanel_ws_Iconposition);
            ucDvpanel_ws.SetProperty("AutoScroll", Dvpanel_ws_Autoscroll);
            ucDvpanel_ws.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_ws_Internalname, sPrefix+"DVPANEL_WSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_WSContainer"+"WS"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divWs_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavWsversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWsversion_Internalname, "Versão do serviço web", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWsversion, cmbavWsversion_Internalname, StringUtil.RTrim( AV47WSVersion), 1, cmbavWsversion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavWsversion.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "", true, "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            cmbavWsversion.CurrentValue = StringUtil.RTrim( AV47WSVersion);
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Values", (string)(cmbavWsversion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWsimpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsimpersonate_Internalname, "Personificar", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsimpersonate_Internalname, StringUtil.RTrim( AV54WSImpersonate), StringUtil.RTrim( context.localUtil.Format( AV54WSImpersonate, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsimpersonate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWsimpersonate_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedwsprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockwsprivateencryptkey_Internalname, "Chave privada de criptografia", "", "", lblTextblockwsprivateencryptkey_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_134_122( true) ;
         }
         else
         {
            wb_table1_134_122( false) ;
         }
         return  ;
      }

      protected void wb_table1_134_122e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWsservername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsservername_Internalname, "Nome do servidor", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsservername_Internalname, StringUtil.RTrim( AV43WSServerName), StringUtil.RTrim( context.localUtil.Format( AV43WSServerName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsservername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWsservername_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWsserverport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsserverport_Internalname, "Porta do servidor", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsserverport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44WSServerPort), 5, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44WSServerPort), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,149);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsserverport_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWsserverport_Enabled, 1, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWsserverbaseurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsserverbaseurl_Internalname, "Url base", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsserverbaseurl_Internalname, AV42WSServerBaseURL, StringUtil.RTrim( context.localUtil.Format( AV42WSServerBaseURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsserverbaseurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWsserverbaseurl_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavWsserversecureprotocol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWsserversecureprotocol_Internalname, "Protocolo seguro", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWsserversecureprotocol, cmbavWsserversecureprotocol_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0)), 1, cmbavWsserversecureprotocol_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavWsserversecureprotocol.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "", true, "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            cmbavWsserversecureprotocol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0));
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Values", (string)(cmbavWsserversecureprotocol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWstimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWstimeout_Internalname, "Acabou o tempo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWstimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46WSTimeout), 5, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46WSTimeout), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,162);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWstimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWstimeout_Enabled, 1, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWspackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWspackage_Internalname, "Embale o serviço web", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWspackage_Internalname, StringUtil.RTrim( AV40WSPackage), StringUtil.RTrim( context.localUtil.Format( AV40WSPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWspackage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWspackage_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWsname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsname_Internalname, "Nome do serviço web", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsname_Internalname, StringUtil.RTrim( AV39WSName), StringUtil.RTrim( context.localUtil.Format( AV39WSName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWsname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWsextension_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsextension_Internalname, "Extensão do serviço web", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsextension_Internalname, StringUtil.RTrim( AV38WSExtension), StringUtil.RTrim( context.localUtil.Format( AV38WSExtension, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsextension_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWsextension_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
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
            GxWebStd.gx_div_start( context, divTblexternal_Internalname, divTblexternal_Visible, 0, "px", 0, "px", "Table100x100", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_ext.SetProperty("Width", Dvpanel_ext_Width);
            ucDvpanel_ext.SetProperty("AutoWidth", Dvpanel_ext_Autowidth);
            ucDvpanel_ext.SetProperty("AutoHeight", Dvpanel_ext_Autoheight);
            ucDvpanel_ext.SetProperty("Cls", Dvpanel_ext_Cls);
            ucDvpanel_ext.SetProperty("Title", Dvpanel_ext_Title);
            ucDvpanel_ext.SetProperty("Collapsible", Dvpanel_ext_Collapsible);
            ucDvpanel_ext.SetProperty("Collapsed", Dvpanel_ext_Collapsed);
            ucDvpanel_ext.SetProperty("ShowCollapseIcon", Dvpanel_ext_Showcollapseicon);
            ucDvpanel_ext.SetProperty("IconPosition", Dvpanel_ext_Iconposition);
            ucDvpanel_ext.SetProperty("AutoScroll", Dvpanel_ext_Autoscroll);
            ucDvpanel_ext.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_ext_Internalname, sPrefix+"DVPANEL_EXTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_EXTContainer"+"Ext"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divExt_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavCusversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCusversion_Internalname, "Versão json", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCusversion, cmbavCusversion_Internalname, StringUtil.RTrim( AV24CusVersion), 1, cmbavCusversion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavCusversion.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "", true, "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            cmbavCusversion.CurrentValue = StringUtil.RTrim( AV24CusVersion);
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Values", (string)(cmbavCusversion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCusimpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusimpersonate_Internalname, "Personificar", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusimpersonate_Internalname, StringUtil.RTrim( AV53CusImpersonate), StringUtil.RTrim( context.localUtil.Format( AV53CusImpersonate, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,193);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusimpersonate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusimpersonate_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcusprivateencryptkey_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcusprivateencryptkey_Internalname, "Chave privada de criptografia", "", "", lblTextblockcusprivateencryptkey_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_201_122( true) ;
         }
         else
         {
            wb_table2_201_122( false) ;
         }
         return  ;
      }

      protected void wb_table2_201_122e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCusfilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusfilename_Internalname, "Nome do arquivo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusfilename_Internalname, StringUtil.RTrim( AV21CusFileName), StringUtil.RTrim( context.localUtil.Format( AV21CusFileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusfilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusfilename_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCuspackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuspackage_Internalname, "Pacote", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuspackage_Internalname, StringUtil.RTrim( AV22CusPackage), StringUtil.RTrim( context.localUtil.Format( AV22CusPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,216);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuspackage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCuspackage_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCusclassname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusclassname_Internalname, "Nome da classe", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 220,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusclassname_Internalname, StringUtil.RTrim( AV20CusClassName), StringUtil.RTrim( context.localUtil.Format( AV20CusClassName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,220);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusclassname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusclassname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 225,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 227,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
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

      protected void START122( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148565", 0) ;
               }
               Form.Meta.addItem("description", "Authentication Type Entry General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP120( ) ;
            }
         }
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGENKEYCUSTOM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoGenKeyCustom' */
                                    E12122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGENKEY'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoGenKey' */
                                    E13122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E14122 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GENERATEKEY'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'GenerateKey' */
                                    E15122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GENERATEKEYCUSTOM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'GenerateKeyCustom' */
                                    E16122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E17122 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18122 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP120( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavFunctionid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE122( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm122( ) ;
            }
         }
      }

      protected void PA122( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavFunctionid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavFunctionid.ItemCount > 0 )
         {
            AV28FunctionId = cmbavFunctionid.getValidValue(AV28FunctionId);
            AssignAttri(sPrefix, false, "AV28FunctionId", AV28FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV28FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV33IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV33IsEnable));
         AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
         if ( cmbavWsversion.ItemCount > 0 )
         {
            AV47WSVersion = cmbavWsversion.getValidValue(AV47WSVersion);
            AssignAttri(sPrefix, false, "AV47WSVersion", AV47WSVersion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWsversion.CurrentValue = StringUtil.RTrim( AV47WSVersion);
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Values", cmbavWsversion.ToJavascriptSource(), true);
         }
         if ( cmbavWsserversecureprotocol.ItemCount > 0 )
         {
            AV45WSServerSecureProtocol = (short)(NumberUtil.Val( cmbavWsserversecureprotocol.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0))), "."));
            AssignAttri(sPrefix, false, "AV45WSServerSecureProtocol", StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWsserversecureprotocol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0));
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Values", cmbavWsserversecureprotocol.ToJavascriptSource(), true);
         }
         if ( cmbavCusversion.ItemCount > 0 )
         {
            AV24CusVersion = cmbavCusversion.getValidValue(AV24CusVersion);
            AssignAttri(sPrefix, false, "AV24CusVersion", AV24CusVersion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCusversion.CurrentValue = StringUtil.RTrim( AV24CusVersion);
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Values", cmbavCusversion.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF122( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF122( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E17122 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E18122 ();
            WB120( ) ;
         }
      }

      protected void send_integrity_lvl_hashes122( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP120( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11122 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV34Name = cgiGet( sPrefix+"wcpOAV34Name");
            wcpOAV37TypeId = cgiGet( sPrefix+"wcpOAV37TypeId");
            Dvpanel_fb_Width = cgiGet( sPrefix+"DVPANEL_FB_Width");
            Dvpanel_fb_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_FB_Autowidth"));
            Dvpanel_fb_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_FB_Autoheight"));
            Dvpanel_fb_Cls = cgiGet( sPrefix+"DVPANEL_FB_Cls");
            Dvpanel_fb_Title = cgiGet( sPrefix+"DVPANEL_FB_Title");
            Dvpanel_fb_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_FB_Collapsible"));
            Dvpanel_fb_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_FB_Collapsed"));
            Dvpanel_fb_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_FB_Showcollapseicon"));
            Dvpanel_fb_Iconposition = cgiGet( sPrefix+"DVPANEL_FB_Iconposition");
            Dvpanel_fb_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_FB_Autoscroll"));
            Dvpanel_tw_Width = cgiGet( sPrefix+"DVPANEL_TW_Width");
            Dvpanel_tw_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TW_Autowidth"));
            Dvpanel_tw_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TW_Autoheight"));
            Dvpanel_tw_Cls = cgiGet( sPrefix+"DVPANEL_TW_Cls");
            Dvpanel_tw_Title = cgiGet( sPrefix+"DVPANEL_TW_Title");
            Dvpanel_tw_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TW_Collapsible"));
            Dvpanel_tw_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TW_Collapsed"));
            Dvpanel_tw_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TW_Showcollapseicon"));
            Dvpanel_tw_Iconposition = cgiGet( sPrefix+"DVPANEL_TW_Iconposition");
            Dvpanel_tw_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TW_Autoscroll"));
            Dvpanel_ws_Width = cgiGet( sPrefix+"DVPANEL_WS_Width");
            Dvpanel_ws_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_WS_Autowidth"));
            Dvpanel_ws_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_WS_Autoheight"));
            Dvpanel_ws_Cls = cgiGet( sPrefix+"DVPANEL_WS_Cls");
            Dvpanel_ws_Title = cgiGet( sPrefix+"DVPANEL_WS_Title");
            Dvpanel_ws_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_WS_Collapsible"));
            Dvpanel_ws_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_WS_Collapsed"));
            Dvpanel_ws_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_WS_Showcollapseicon"));
            Dvpanel_ws_Iconposition = cgiGet( sPrefix+"DVPANEL_WS_Iconposition");
            Dvpanel_ws_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_WS_Autoscroll"));
            Dvpanel_ext_Width = cgiGet( sPrefix+"DVPANEL_EXT_Width");
            Dvpanel_ext_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_EXT_Autowidth"));
            Dvpanel_ext_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_EXT_Autoheight"));
            Dvpanel_ext_Cls = cgiGet( sPrefix+"DVPANEL_EXT_Cls");
            Dvpanel_ext_Title = cgiGet( sPrefix+"DVPANEL_EXT_Title");
            Dvpanel_ext_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_EXT_Collapsible"));
            Dvpanel_ext_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_EXT_Collapsed"));
            Dvpanel_ext_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_EXT_Showcollapseicon"));
            Dvpanel_ext_Iconposition = cgiGet( sPrefix+"DVPANEL_EXT_Iconposition");
            Dvpanel_ext_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_EXT_Autoscroll"));
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV34Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV34Name", AV34Name);
            }
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV28FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV28FunctionId", AV28FunctionId);
            AV25Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
            AV33IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
            AV5AdditionalScope = cgiGet( edtavAdditionalscope_Internalname);
            AssignAttri(sPrefix, false, "AV5AdditionalScope", AV5AdditionalScope);
            AV36SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV36SmallImageName", AV36SmallImageName);
            AV14BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV14BigImageName", AV14BigImageName);
            AV16ClientId = cgiGet( edtavClientid_Internalname);
            AssignAttri(sPrefix, false, "AV16ClientId", AV16ClientId);
            AV17ClientSecret = cgiGet( edtavClientsecret_Internalname);
            AssignAttri(sPrefix, false, "AV17ClientSecret", AV17ClientSecret);
            AV35SiteURL = cgiGet( edtavSiteurl_Internalname);
            AssignAttri(sPrefix, false, "AV35SiteURL", AV35SiteURL);
            AV32Impersonate = cgiGet( edtavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV32Impersonate", AV32Impersonate);
            AV31GAMRServerURL = cgiGet( edtavGamrserverurl_Internalname);
            AssignAttri(sPrefix, false, "AV31GAMRServerURL", AV31GAMRServerURL);
            AV29GAMRPrivateEncryptKey = cgiGet( edtavGamrprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV29GAMRPrivateEncryptKey", AV29GAMRPrivateEncryptKey);
            AV30GAMRRepositoryGUID = cgiGet( edtavGamrrepositoryguid_Internalname);
            AssignAttri(sPrefix, false, "AV30GAMRRepositoryGUID", AV30GAMRRepositoryGUID);
            AV18ConsumerKey = cgiGet( edtavConsumerkey_Internalname);
            AssignAttri(sPrefix, false, "AV18ConsumerKey", AV18ConsumerKey);
            AV19ConsumerSecret = cgiGet( edtavConsumersecret_Internalname);
            AssignAttri(sPrefix, false, "AV19ConsumerSecret", AV19ConsumerSecret);
            AV15CallbackURL = cgiGet( edtavCallbackurl_Internalname);
            AssignAttri(sPrefix, false, "AV15CallbackURL", AV15CallbackURL);
            cmbavWsversion.CurrentValue = cgiGet( cmbavWsversion_Internalname);
            AV47WSVersion = cgiGet( cmbavWsversion_Internalname);
            AssignAttri(sPrefix, false, "AV47WSVersion", AV47WSVersion);
            AV54WSImpersonate = cgiGet( edtavWsimpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV54WSImpersonate", AV54WSImpersonate);
            AV41WSPrivateEncryptKey = cgiGet( edtavWsprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV41WSPrivateEncryptKey", AV41WSPrivateEncryptKey);
            AV43WSServerName = cgiGet( edtavWsservername_Internalname);
            AssignAttri(sPrefix, false, "AV43WSServerName", AV43WSServerName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWSSERVERPORT");
               GX_FocusControl = edtavWsserverport_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44WSServerPort = 0;
               AssignAttri(sPrefix, false, "AV44WSServerPort", StringUtil.LTrimStr( (decimal)(AV44WSServerPort), 5, 0));
            }
            else
            {
               AV44WSServerPort = (int)(context.localUtil.CToN( cgiGet( edtavWsserverport_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV44WSServerPort", StringUtil.LTrimStr( (decimal)(AV44WSServerPort), 5, 0));
            }
            AV42WSServerBaseURL = cgiGet( edtavWsserverbaseurl_Internalname);
            AssignAttri(sPrefix, false, "AV42WSServerBaseURL", AV42WSServerBaseURL);
            cmbavWsserversecureprotocol.CurrentValue = cgiGet( cmbavWsserversecureprotocol_Internalname);
            AV45WSServerSecureProtocol = (short)(NumberUtil.Val( cgiGet( cmbavWsserversecureprotocol_Internalname), "."));
            AssignAttri(sPrefix, false, "AV45WSServerSecureProtocol", StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWSTIMEOUT");
               GX_FocusControl = edtavWstimeout_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV46WSTimeout = 0;
               AssignAttri(sPrefix, false, "AV46WSTimeout", StringUtil.LTrimStr( (decimal)(AV46WSTimeout), 5, 0));
            }
            else
            {
               AV46WSTimeout = (int)(context.localUtil.CToN( cgiGet( edtavWstimeout_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV46WSTimeout", StringUtil.LTrimStr( (decimal)(AV46WSTimeout), 5, 0));
            }
            AV40WSPackage = cgiGet( edtavWspackage_Internalname);
            AssignAttri(sPrefix, false, "AV40WSPackage", AV40WSPackage);
            AV39WSName = cgiGet( edtavWsname_Internalname);
            AssignAttri(sPrefix, false, "AV39WSName", AV39WSName);
            AV38WSExtension = cgiGet( edtavWsextension_Internalname);
            AssignAttri(sPrefix, false, "AV38WSExtension", AV38WSExtension);
            cmbavCusversion.CurrentValue = cgiGet( cmbavCusversion_Internalname);
            AV24CusVersion = cgiGet( cmbavCusversion_Internalname);
            AssignAttri(sPrefix, false, "AV24CusVersion", AV24CusVersion);
            AV53CusImpersonate = cgiGet( edtavCusimpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV53CusImpersonate", AV53CusImpersonate);
            AV23CusPrivateEncryptKey = cgiGet( edtavCusprivateencryptkey_Internalname);
            AssignAttri(sPrefix, false, "AV23CusPrivateEncryptKey", AV23CusPrivateEncryptKey);
            AV21CusFileName = cgiGet( edtavCusfilename_Internalname);
            AssignAttri(sPrefix, false, "AV21CusFileName", AV21CusFileName);
            AV22CusPackage = cgiGet( edtavCuspackage_Internalname);
            AssignAttri(sPrefix, false, "AV22CusPackage", AV22CusPackage);
            AV20CusClassName = cgiGet( edtavCusclassname_Internalname);
            AssignAttri(sPrefix, false, "AV20CusClassName", AV20CusClassName);
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
         E11122 ();
         if (returnInSub) return;
      }

      protected void E11122( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            edtavName_Enabled = 1;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
         }
         else
         {
            edtavName_Enabled = 0;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            AV28FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV28FunctionId", AV28FunctionId);
            if ( StringUtil.StrCmp(AV37TypeId, "GAMLocal") == 0 )
            {
               AV10AuthenticationTypeLocal.load( AV34Name);
               AV28FunctionId = AV10AuthenticationTypeLocal.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV28FunctionId", AV28FunctionId);
               AV33IsEnable = AV10AuthenticationTypeLocal.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
               AV25Dsc = AV10AuthenticationTypeLocal.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Facebook") == 0 )
            {
               cmbavFunctionid.Enabled = 0;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV7AuthenticationTypeFacebook.load( AV34Name);
               AV33IsEnable = AV7AuthenticationTypeFacebook.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
               AV25Dsc = AV7AuthenticationTypeFacebook.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
               AV16ClientId = AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientid;
               AssignAttri(sPrefix, false, "AV16ClientId", AV16ClientId);
               AV17ClientSecret = AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientsecret;
               AssignAttri(sPrefix, false, "AV17ClientSecret", AV17ClientSecret);
               AV35SiteURL = AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Siteurl;
               AssignAttri(sPrefix, false, "AV35SiteURL", AV35SiteURL);
               AV5AdditionalScope = AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV5AdditionalScope", AV5AdditionalScope);
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Google") == 0 )
            {
               cmbavFunctionid.Enabled = 0;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV9AuthenticationTypeGoogle.load( AV34Name);
               AV33IsEnable = AV9AuthenticationTypeGoogle.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
               AV25Dsc = AV9AuthenticationTypeGoogle.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
               AV16ClientId = AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientid;
               AssignAttri(sPrefix, false, "AV16ClientId", AV16ClientId);
               AV17ClientSecret = AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientsecret;
               AssignAttri(sPrefix, false, "AV17ClientSecret", AV17ClientSecret);
               AV35SiteURL = AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Siteurl;
               AssignAttri(sPrefix, false, "AV35SiteURL", AV35SiteURL);
               AV5AdditionalScope = AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV5AdditionalScope", AV5AdditionalScope);
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV8AuthenticationTypeGAMRemote.load( AV34Name);
               AV28FunctionId = AV8AuthenticationTypeGAMRemote.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV28FunctionId", AV28FunctionId);
               AV33IsEnable = AV8AuthenticationTypeGAMRemote.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
               AV25Dsc = AV8AuthenticationTypeGAMRemote.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
               AV32Impersonate = AV8AuthenticationTypeGAMRemote.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV32Impersonate", AV32Impersonate);
               AV16ClientId = AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientid;
               AssignAttri(sPrefix, false, "AV16ClientId", AV16ClientId);
               AV17ClientSecret = AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientsecret;
               AssignAttri(sPrefix, false, "AV17ClientSecret", AV17ClientSecret);
               AV35SiteURL = AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurl;
               AssignAttri(sPrefix, false, "AV35SiteURL", AV35SiteURL);
               AV5AdditionalScope = AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV5AdditionalScope", AV5AdditionalScope);
               AV31GAMRServerURL = AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverurl;
               AssignAttri(sPrefix, false, "AV31GAMRServerURL", AV31GAMRServerURL);
               AV29GAMRPrivateEncryptKey = AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverkey;
               AssignAttri(sPrefix, false, "AV29GAMRPrivateEncryptKey", AV29GAMRPrivateEncryptKey);
               AV30GAMRRepositoryGUID = AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoterepositoryguid;
               AssignAttri(sPrefix, false, "AV30GAMRRepositoryGUID", AV30GAMRRepositoryGUID);
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Twitter") == 0 )
            {
               cmbavFunctionid.Enabled = 0;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV12AuthenticationTypeTwitter.load( AV34Name);
               AV33IsEnable = AV12AuthenticationTypeTwitter.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
               AV25Dsc = AV12AuthenticationTypeTwitter.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
               AV18ConsumerKey = AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumerkey;
               AssignAttri(sPrefix, false, "AV18ConsumerKey", AV18ConsumerKey);
               AV19ConsumerSecret = AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumersecret;
               AssignAttri(sPrefix, false, "AV19ConsumerSecret", AV19ConsumerSecret);
               AV15CallbackURL = AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Callbackurl;
               AssignAttri(sPrefix, false, "AV15CallbackURL", AV15CallbackURL);
               AV5AdditionalScope = AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Additionalscope;
               AssignAttri(sPrefix, false, "AV5AdditionalScope", AV5AdditionalScope);
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "ExternalWebService") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV13AuthenticationTypeWebService.load( AV34Name);
               AV28FunctionId = AV13AuthenticationTypeWebService.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV28FunctionId", AV28FunctionId);
               AV33IsEnable = AV13AuthenticationTypeWebService.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
               AV25Dsc = AV13AuthenticationTypeWebService.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
               AV54WSImpersonate = AV13AuthenticationTypeWebService.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV54WSImpersonate", AV54WSImpersonate);
               AV47WSVersion = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Version;
               AssignAttri(sPrefix, false, "AV47WSVersion", AV47WSVersion);
               AV41WSPrivateEncryptKey = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Privateencryptkey;
               AssignAttri(sPrefix, false, "AV41WSPrivateEncryptKey", AV41WSPrivateEncryptKey);
               AV43WSServerName = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV43WSServerName", AV43WSServerName);
               AV44WSServerPort = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Port;
               AssignAttri(sPrefix, false, "AV44WSServerPort", StringUtil.LTrimStr( (decimal)(AV44WSServerPort), 5, 0));
               AV42WSServerBaseURL = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Baseurl;
               AssignAttri(sPrefix, false, "AV42WSServerBaseURL", AV42WSServerBaseURL);
               AV45WSServerSecureProtocol = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Secureprotocol;
               AssignAttri(sPrefix, false, "AV45WSServerSecureProtocol", StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0));
               AV46WSTimeout = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Timeout;
               AssignAttri(sPrefix, false, "AV46WSTimeout", StringUtil.LTrimStr( (decimal)(AV46WSTimeout), 5, 0));
               AV40WSPackage = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Package;
               AssignAttri(sPrefix, false, "AV40WSPackage", AV40WSPackage);
               AV39WSName = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Name;
               AssignAttri(sPrefix, false, "AV39WSName", AV39WSName);
               AV38WSExtension = AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Extension;
               AssignAttri(sPrefix, false, "AV38WSExtension", AV38WSExtension);
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Custom") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV6AuthenticationTypeCustom.load( AV34Name);
               AV28FunctionId = AV6AuthenticationTypeCustom.gxTpr_Functionid;
               AssignAttri(sPrefix, false, "AV28FunctionId", AV28FunctionId);
               AV33IsEnable = AV6AuthenticationTypeCustom.gxTpr_Isenable;
               AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
               AV25Dsc = AV6AuthenticationTypeCustom.gxTpr_Description;
               AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
               AV53CusImpersonate = AV6AuthenticationTypeCustom.gxTpr_Impersonate;
               AssignAttri(sPrefix, false, "AV53CusImpersonate", AV53CusImpersonate);
               AV24CusVersion = AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Version;
               AssignAttri(sPrefix, false, "AV24CusVersion", AV24CusVersion);
               AV23CusPrivateEncryptKey = AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Privateencryptkey;
               AssignAttri(sPrefix, false, "AV23CusPrivateEncryptKey", AV23CusPrivateEncryptKey);
               AV21CusFileName = AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Filename;
               AssignAttri(sPrefix, false, "AV21CusFileName", AV21CusFileName);
               AV22CusPackage = AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Package;
               AssignAttri(sPrefix, false, "AV22CusPackage", AV22CusPackage);
               AV20CusClassName = AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Classname;
               AssignAttri(sPrefix, false, "AV20CusClassName", AV20CusClassName);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnenter_Visible = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            bttBtngenkey_Visible = 0;
            AssignProp(sPrefix, false, bttBtngenkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngenkey_Visible), 5, 0), true);
            bttBtngenkeycustom_Visible = 0;
            AssignProp(sPrefix, false, bttBtngenkeycustom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngenkeycustom_Visible), 5, 0), true);
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
            chkavIsenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavIsenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenable.Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavWsimpersonate_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsimpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsimpersonate_Enabled), 5, 0), true);
            cmbavWsversion.Enabled = 0;
            AssignProp(sPrefix, false, cmbavWsversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWsversion.Enabled), 5, 0), true);
            edtavWsprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsprivateencryptkey_Enabled), 5, 0), true);
            edtavWsservername_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsservername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsservername_Enabled), 5, 0), true);
            edtavWsserverport_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsserverport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsserverport_Enabled), 5, 0), true);
            edtavWsserverbaseurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsserverbaseurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsserverbaseurl_Enabled), 5, 0), true);
            cmbavWsserversecureprotocol.Enabled = 0;
            AssignProp(sPrefix, false, cmbavWsserversecureprotocol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWsserversecureprotocol.Enabled), 5, 0), true);
            edtavWstimeout_Enabled = 0;
            AssignProp(sPrefix, false, edtavWstimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWstimeout_Enabled), 5, 0), true);
            edtavWspackage_Enabled = 0;
            AssignProp(sPrefix, false, edtavWspackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWspackage_Enabled), 5, 0), true);
            edtavWsname_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsname_Enabled), 5, 0), true);
            edtavWsextension_Enabled = 0;
            AssignProp(sPrefix, false, edtavWsextension_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWsextension_Enabled), 5, 0), true);
            edtavClientid_Enabled = 0;
            AssignProp(sPrefix, false, edtavClientid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientid_Enabled), 5, 0), true);
            edtavClientsecret_Enabled = 0;
            AssignProp(sPrefix, false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            edtavSiteurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavSiteurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSiteurl_Enabled), 5, 0), true);
            edtavAdditionalscope_Enabled = 0;
            AssignProp(sPrefix, false, edtavAdditionalscope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdditionalscope_Enabled), 5, 0), true);
            edtavConsumerkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavConsumerkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConsumerkey_Enabled), 5, 0), true);
            edtavConsumersecret_Enabled = 0;
            AssignProp(sPrefix, false, edtavConsumersecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConsumersecret_Enabled), 5, 0), true);
            edtavCallbackurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavCallbackurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCallbackurl_Enabled), 5, 0), true);
            edtavCusimpersonate_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusimpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusimpersonate_Enabled), 5, 0), true);
            cmbavCusversion.Enabled = 0;
            AssignProp(sPrefix, false, cmbavCusversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCusversion.Enabled), 5, 0), true);
            edtavCusprivateencryptkey_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusprivateencryptkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusprivateencryptkey_Enabled), 5, 0), true);
            edtavCusfilename_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusfilename_Enabled), 5, 0), true);
            edtavCuspackage_Enabled = 0;
            AssignProp(sPrefix, false, edtavCuspackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCuspackage_Enabled), 5, 0), true);
            edtavCusclassname_Enabled = 0;
            AssignProp(sPrefix, false, edtavCusclassname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCusclassname_Enabled), 5, 0), true);
            bttBtnenter_Caption = "Delete";
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
         }
         /* Execute user subroutine: 'REFRESHAUTHENTICATIONTYPE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E12122( )
      {
         /* 'DoGenKeyCustom' Routine */
         returnInSub = false;
         AV23CusPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV23CusPrivateEncryptKey", AV23CusPrivateEncryptKey);
         /*  Sending Event outputs  */
      }

      protected void E13122( )
      {
         /* 'DoGenKey' Routine */
         returnInSub = false;
         AV41WSPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV41WSPrivateEncryptKey", AV41WSPrivateEncryptKey);
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 ) ) )
         {
            edtavGamrserverurl_Visible = 0;
            AssignProp(sPrefix, false, edtavGamrserverurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrserverurl_Visible), 5, 0), true);
            divGamrserverurl_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divGamrserverurl_cell_Internalname, "Class", divGamrserverurl_cell_Class, true);
         }
         else
         {
            edtavGamrserverurl_Visible = 1;
            AssignProp(sPrefix, false, edtavGamrserverurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrserverurl_Visible), 5, 0), true);
            divGamrserverurl_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp(sPrefix, false, divGamrserverurl_cell_Internalname, "Class", divGamrserverurl_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 ) ) )
         {
            edtavGamrprivateencryptkey_Visible = 0;
            AssignProp(sPrefix, false, edtavGamrprivateencryptkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrprivateencryptkey_Visible), 5, 0), true);
            divGamrprivateencryptkey_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divGamrprivateencryptkey_cell_Internalname, "Class", divGamrprivateencryptkey_cell_Class, true);
         }
         else
         {
            edtavGamrprivateencryptkey_Visible = 1;
            AssignProp(sPrefix, false, edtavGamrprivateencryptkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrprivateencryptkey_Visible), 5, 0), true);
            divGamrprivateencryptkey_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp(sPrefix, false, divGamrprivateencryptkey_cell_Internalname, "Class", divGamrprivateencryptkey_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 ) ) )
         {
            edtavGamrrepositoryguid_Visible = 0;
            AssignProp(sPrefix, false, edtavGamrrepositoryguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrrepositoryguid_Visible), 5, 0), true);
            divGamrrepositoryguid_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divGamrrepositoryguid_cell_Internalname, "Class", divGamrrepositoryguid_cell_Class, true);
         }
         else
         {
            edtavGamrrepositoryguid_Visible = 1;
            AssignProp(sPrefix, false, edtavGamrrepositoryguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrrepositoryguid_Visible), 5, 0), true);
            divGamrrepositoryguid_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp(sPrefix, false, divGamrrepositoryguid_cell_Internalname, "Class", divGamrrepositoryguid_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14122 ();
         if (returnInSub) return;
      }

      protected void E14122( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            if ( StringUtil.StrCmp(AV37TypeId, "GAMLocal") == 0 )
            {
               AV10AuthenticationTypeLocal.load( AV34Name);
               AV10AuthenticationTypeLocal.gxTpr_Name = AV34Name;
               AV10AuthenticationTypeLocal.gxTpr_Functionid = AV28FunctionId;
               AV10AuthenticationTypeLocal.gxTpr_Isenable = AV33IsEnable;
               AV10AuthenticationTypeLocal.gxTpr_Description = AV25Dsc;
               AV10AuthenticationTypeLocal.save();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Facebook") == 0 )
            {
               AV7AuthenticationTypeFacebook.load( AV34Name);
               AV7AuthenticationTypeFacebook.gxTpr_Name = AV34Name;
               AV7AuthenticationTypeFacebook.gxTpr_Isenable = AV33IsEnable;
               AV7AuthenticationTypeFacebook.gxTpr_Description = AV25Dsc;
               AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientid = AV16ClientId;
               AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Clientsecret = AV17ClientSecret;
               AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Siteurl = AV35SiteURL;
               AV7AuthenticationTypeFacebook.gxTpr_Facebook.gxTpr_Additionalscope = AV5AdditionalScope;
               AV7AuthenticationTypeFacebook.save();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Google") == 0 )
            {
               AV9AuthenticationTypeGoogle.load( AV34Name);
               AV9AuthenticationTypeGoogle.gxTpr_Name = AV34Name;
               AV9AuthenticationTypeGoogle.gxTpr_Isenable = AV33IsEnable;
               AV9AuthenticationTypeGoogle.gxTpr_Description = AV25Dsc;
               AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientid = AV16ClientId;
               AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Clientsecret = AV17ClientSecret;
               AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Siteurl = AV35SiteURL;
               AV9AuthenticationTypeGoogle.gxTpr_Google.gxTpr_Additionalscope = AV5AdditionalScope;
               AV9AuthenticationTypeGoogle.save();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 )
            {
               AV8AuthenticationTypeGAMRemote.load( AV34Name);
               AV8AuthenticationTypeGAMRemote.gxTpr_Name = AV34Name;
               AV8AuthenticationTypeGAMRemote.gxTpr_Functionid = AV28FunctionId;
               AV8AuthenticationTypeGAMRemote.gxTpr_Isenable = AV33IsEnable;
               AV8AuthenticationTypeGAMRemote.gxTpr_Description = AV25Dsc;
               AV8AuthenticationTypeGAMRemote.gxTpr_Impersonate = AV32Impersonate;
               AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientid = AV16ClientId;
               AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Clientsecret = AV17ClientSecret;
               AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Siteurl = AV35SiteURL;
               AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Additionalscope = AV5AdditionalScope;
               AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverurl = AV31GAMRServerURL;
               AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoteserverkey = AV29GAMRPrivateEncryptKey;
               AV8AuthenticationTypeGAMRemote.gxTpr_Gamremote.gxTpr_Remoterepositoryguid = AV30GAMRRepositoryGUID;
               AV8AuthenticationTypeGAMRemote.save();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Twitter") == 0 )
            {
               AV12AuthenticationTypeTwitter.load( AV34Name);
               AV12AuthenticationTypeTwitter.gxTpr_Name = AV34Name;
               AV12AuthenticationTypeTwitter.gxTpr_Isenable = AV33IsEnable;
               AV12AuthenticationTypeTwitter.gxTpr_Description = AV25Dsc;
               AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumerkey = AV18ConsumerKey;
               AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Consumersecret = AV19ConsumerSecret;
               AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Callbackurl = AV15CallbackURL;
               AV12AuthenticationTypeTwitter.gxTpr_Twitter.gxTpr_Additionalscope = AV5AdditionalScope;
               AV12AuthenticationTypeTwitter.save();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "ExternalWebService") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV13AuthenticationTypeWebService.load( AV34Name);
               AV13AuthenticationTypeWebService.gxTpr_Name = AV34Name;
               AV13AuthenticationTypeWebService.gxTpr_Functionid = AV28FunctionId;
               AV13AuthenticationTypeWebService.gxTpr_Isenable = AV33IsEnable;
               AV13AuthenticationTypeWebService.gxTpr_Description = AV25Dsc;
               AV13AuthenticationTypeWebService.gxTpr_Impersonate = AV54WSImpersonate;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Version = AV47WSVersion;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Privateencryptkey = AV41WSPrivateEncryptKey;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Timeout = AV46WSTimeout;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Package = AV40WSPackage;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Name = AV39WSName;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Extension = AV38WSExtension;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Name = AV43WSServerName;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Port = AV44WSServerPort;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Baseurl = AV42WSServerBaseURL;
               AV13AuthenticationTypeWebService.gxTpr_Webservice.gxTpr_Server.gxTpr_Secureprotocol = (short)(NumberUtil.Val( StringUtil.Str( (decimal)(AV45WSServerSecureProtocol), 1, 0), "."));
               AV13AuthenticationTypeWebService.save();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Custom") == 0 )
            {
               cmbavFunctionid.Enabled = 1;
               AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
               AV6AuthenticationTypeCustom.load( AV34Name);
               AV6AuthenticationTypeCustom.gxTpr_Name = AV34Name;
               AV6AuthenticationTypeCustom.gxTpr_Functionid = AV28FunctionId;
               AV6AuthenticationTypeCustom.gxTpr_Isenable = AV33IsEnable;
               AV6AuthenticationTypeCustom.gxTpr_Description = AV25Dsc;
               AV6AuthenticationTypeCustom.gxTpr_Impersonate = AV53CusImpersonate;
               AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Version = AV24CusVersion;
               AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Privateencryptkey = AV23CusPrivateEncryptKey;
               AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Filename = AV21CusFileName;
               AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Package = AV22CusPackage;
               AV6AuthenticationTypeCustom.gxTpr_Custom.gxTpr_Classname = AV20CusClassName;
               AV6AuthenticationTypeCustom.save();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            if ( StringUtil.StrCmp(AV37TypeId, "GAMLocal") == 0 )
            {
               AV10AuthenticationTypeLocal.load( AV34Name);
               AV10AuthenticationTypeLocal.delete();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Facebook") == 0 )
            {
               AV7AuthenticationTypeFacebook.load( AV34Name);
               AV7AuthenticationTypeFacebook.delete();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Google") == 0 )
            {
               AV9AuthenticationTypeGoogle.load( AV34Name);
               AV9AuthenticationTypeGoogle.delete();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Twitter") == 0 )
            {
               AV12AuthenticationTypeTwitter.load( AV34Name);
               AV12AuthenticationTypeTwitter.delete();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "ExternalWebService") == 0 )
            {
               AV13AuthenticationTypeWebService.load( AV34Name);
               AV13AuthenticationTypeWebService.delete();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "Custom") == 0 )
            {
               AV6AuthenticationTypeCustom.load( AV34Name);
               AV6AuthenticationTypeCustom.delete();
            }
            else if ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 )
            {
               AV8AuthenticationTypeGAMRemote.load( AV34Name);
               AV8AuthenticationTypeGAMRemote.delete();
            }
         }
         if ( StringUtil.StrCmp(AV37TypeId, "GAMLocal") == 0 )
         {
            if ( AV10AuthenticationTypeLocal.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentrygeneral",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV34Name","AV37TypeId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Facebook") == 0 )
         {
            if ( AV7AuthenticationTypeFacebook.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentrygeneral",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV34Name","AV37TypeId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Google") == 0 )
         {
            if ( AV9AuthenticationTypeGoogle.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentrygeneral",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV34Name","AV37TypeId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Twitter") == 0 )
         {
            if ( AV12AuthenticationTypeTwitter.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentrygeneral",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV34Name","AV37TypeId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "ExternalWebService") == 0 )
         {
            if ( AV13AuthenticationTypeWebService.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentrygeneral",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV34Name","AV37TypeId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Custom") == 0 )
         {
            if ( AV6AuthenticationTypeCustom.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentrygeneral",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV34Name","AV37TypeId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               AV27Errors = AV6AuthenticationTypeCustom.geterrors();
            }
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 )
         {
            if ( AV8AuthenticationTypeGAMRemote.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentrygeneral",pr_default);
               context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV34Name,(string)AV37TypeId});
               context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV34Name","AV37TypeId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               AV27Errors = AV8AuthenticationTypeGAMRemote.geterrors();
            }
         }
         AV27Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV27Errors.Count )
         {
            AV26Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV27Errors.Item(AV58GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV26Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV26Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6AuthenticationTypeCustom", AV6AuthenticationTypeCustom);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13AuthenticationTypeWebService", AV13AuthenticationTypeWebService);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12AuthenticationTypeTwitter", AV12AuthenticationTypeTwitter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8AuthenticationTypeGAMRemote", AV8AuthenticationTypeGAMRemote);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9AuthenticationTypeGoogle", AV9AuthenticationTypeGoogle);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7AuthenticationTypeFacebook", AV7AuthenticationTypeFacebook);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10AuthenticationTypeLocal", AV10AuthenticationTypeLocal);
      }

      protected void E15122( )
      {
         /* 'GenerateKey' Routine */
         returnInSub = false;
         AV41WSPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV41WSPrivateEncryptKey", AV41WSPrivateEncryptKey);
         /*  Sending Event outputs  */
      }

      protected void E16122( )
      {
         /* 'GenerateKeyCustom' Routine */
         returnInSub = false;
         AV23CusPrivateEncryptKey = Crypto.GetEncryptionKey( );
         AssignAttri(sPrefix, false, "AV23CusPrivateEncryptKey", AV23CusPrivateEncryptKey);
         /*  Sending Event outputs  */
      }

      protected void E17122( )
      {
         /* Refresh Routine */
         returnInSub = false;
         divTblfacebook_Visible = 0;
         AssignProp(sPrefix, false, divTblfacebook_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblfacebook_Visible), 5, 0), true);
         edtavAdditionalscope_Visible = 0;
         AssignProp(sPrefix, false, edtavAdditionalscope_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdditionalscope_Visible), 5, 0), true);
         divTbltwitter_Visible = 0;
         AssignProp(sPrefix, false, divTbltwitter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbltwitter_Visible), 5, 0), true);
         divTblwebservice_Visible = 0;
         AssignProp(sPrefix, false, divTblwebservice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblwebservice_Visible), 5, 0), true);
         divTblexternal_Visible = 0;
         AssignProp(sPrefix, false, divTblexternal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblexternal_Visible), 5, 0), true);
         edtavImpersonate_Visible = 0;
         AssignProp(sPrefix, false, edtavImpersonate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImpersonate_Visible), 5, 0), true);
         edtavGamrprivateencryptkey_Visible = 0;
         AssignProp(sPrefix, false, edtavGamrprivateencryptkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrprivateencryptkey_Visible), 5, 0), true);
         edtavGamrserverurl_Visible = 0;
         AssignProp(sPrefix, false, edtavGamrserverurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrserverurl_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV37TypeId, "GAMLocal") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Facebook") == 0 )
         {
            divTblfacebook_Visible = 1;
            AssignProp(sPrefix, false, divTblfacebook_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblfacebook_Visible), 5, 0), true);
            edtavAdditionalscope_Visible = 1;
            AssignProp(sPrefix, false, edtavAdditionalscope_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdditionalscope_Visible), 5, 0), true);
            Dvpanel_fb_Title = "Facebook";
            ucDvpanel_fb.SendProperty(context, sPrefix, false, Dvpanel_fb_Internalname, "Title", Dvpanel_fb_Title);
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Google") == 0 )
         {
            divTblfacebook_Visible = 1;
            AssignProp(sPrefix, false, divTblfacebook_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblfacebook_Visible), 5, 0), true);
            edtavAdditionalscope_Visible = 1;
            AssignProp(sPrefix, false, edtavAdditionalscope_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdditionalscope_Visible), 5, 0), true);
            Dvpanel_fb_Title = "Google";
            ucDvpanel_fb.SendProperty(context, sPrefix, false, Dvpanel_fb_Internalname, "Title", Dvpanel_fb_Title);
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Twitter") == 0 )
         {
            divTbltwitter_Visible = 1;
            AssignProp(sPrefix, false, divTbltwitter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbltwitter_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "ExternalWebService") == 0 )
         {
            divTblwebservice_Visible = 1;
            AssignProp(sPrefix, false, divTblwebservice_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblwebservice_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "Custom") == 0 )
         {
            divTblexternal_Visible = 1;
            AssignProp(sPrefix, false, divTblexternal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblexternal_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV37TypeId, "GAMRemote") == 0 )
         {
            divTblfacebook_Visible = 1;
            AssignProp(sPrefix, false, divTblfacebook_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblfacebook_Visible), 5, 0), true);
            edtavAdditionalscope_Visible = 1;
            AssignProp(sPrefix, false, edtavAdditionalscope_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdditionalscope_Visible), 5, 0), true);
            Dvpanel_fb_Title = "Remote";
            ucDvpanel_fb.SendProperty(context, sPrefix, false, Dvpanel_fb_Internalname, "Title", Dvpanel_fb_Title);
            edtavImpersonate_Visible = 1;
            AssignProp(sPrefix, false, edtavImpersonate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImpersonate_Visible), 5, 0), true);
            edtavGamrprivateencryptkey_Visible = 1;
            AssignProp(sPrefix, false, edtavGamrprivateencryptkey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrprivateencryptkey_Visible), 5, 0), true);
            edtavGamrserverurl_Visible = 1;
            AssignProp(sPrefix, false, edtavGamrserverurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamrserverurl_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'REFRESHAUTHENTICATIONTYPE' Routine */
         returnInSub = false;
      }

      protected void nextLoad( )
      {
      }

      protected void E18122( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_201_122( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcusprivateencryptkey_Internalname, tblTablemergedcusprivateencryptkey_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusprivateencryptkey_Internalname, "Cus Private Encrypt Key", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusprivateencryptkey_Internalname, StringUtil.RTrim( AV23CusPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV23CusPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,205);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusprivateencryptkey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellMarginLeft'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngenkeycustom_Internalname, "", "Gerar chave", bttBtngenkeycustom_Jsonclick, 5, "Gerar chave", "", StyleString, ClassString, bttBtngenkeycustom_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOGENKEYCUSTOM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_201_122e( true) ;
         }
         else
         {
            wb_table2_201_122e( false) ;
         }
      }

      protected void wb_table1_134_122( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedwsprivateencryptkey_Internalname, tblTablemergedwsprivateencryptkey_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWsprivateencryptkey_Internalname, "WSPrivate Encrypt Key", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWsprivateencryptkey_Internalname, StringUtil.RTrim( AV41WSPrivateEncryptKey), StringUtil.RTrim( context.localUtil.Format( AV41WSPrivateEncryptKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWsprivateencryptkey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWsprivateencryptkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='CellMarginLeft'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngenkey_Internalname, "", "Gerar chave", bttBtngenkey_Jsonclick, 5, "Gerar chave", "", StyleString, ClassString, bttBtngenkey_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOGENKEY\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_134_122e( true) ;
         }
         else
         {
            wb_table1_134_122e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV34Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV34Name", AV34Name);
         AV37TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV37TypeId", AV37TypeId);
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
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV34Name = (string)((string)getParm(obj,1));
         sCtrlAV37TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA122( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "gamwcauthenticationtypeentrygeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA122( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV34Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV34Name", AV34Name);
            AV37TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV37TypeId", AV37TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV34Name = cgiGet( sPrefix+"wcpOAV34Name");
         wcpOAV37TypeId = cgiGet( sPrefix+"wcpOAV37TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV34Name, wcpOAV34Name) != 0 ) || ( StringUtil.StrCmp(AV37TypeId, wcpOAV37TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV34Name = AV34Name;
         wcpOAV37TypeId = AV37TypeId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV34Name = cgiGet( sPrefix+"AV34Name_CTRL");
         if ( StringUtil.Len( sCtrlAV34Name) > 0 )
         {
            AV34Name = cgiGet( sCtrlAV34Name);
            AssignAttri(sPrefix, false, "AV34Name", AV34Name);
         }
         else
         {
            AV34Name = cgiGet( sPrefix+"AV34Name_PARM");
         }
         sCtrlAV37TypeId = cgiGet( sPrefix+"AV37TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV37TypeId) > 0 )
         {
            AV37TypeId = cgiGet( sCtrlAV37TypeId);
            AssignAttri(sPrefix, false, "AV37TypeId", AV37TypeId);
         }
         else
         {
            AV37TypeId = cgiGet( sPrefix+"AV37TypeId_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA122( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS122( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS122( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV34Name_PARM", StringUtil.RTrim( AV34Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV34Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV34Name_CTRL", StringUtil.RTrim( sCtrlAV34Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV37TypeId_PARM", StringUtil.RTrim( AV37TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV37TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV37TypeId_CTRL", StringUtil.RTrim( sCtrlAV37TypeId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE122( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815503743", true, true);
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
         context.AddJavascriptSource("gamwcauthenticationtypeentrygeneral.js", "?202142815503754", false, true);
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
         cmbavFunctionid.Name = "vFUNCTIONID";
         cmbavFunctionid.WebTags = "";
         cmbavFunctionid.addItem("AuthenticationAndRoles", "Autenticação e perfis", 0);
         cmbavFunctionid.addItem("OnlyAuthentication", "Só autenticação", 0);
         if ( cmbavFunctionid.ItemCount > 0 )
         {
         }
         chkavIsenable.Name = "vISENABLE";
         chkavIsenable.WebTags = "";
         chkavIsenable.Caption = "";
         AssignProp(sPrefix, false, chkavIsenable_Internalname, "TitleCaption", chkavIsenable.Caption, true);
         chkavIsenable.CheckedValue = "false";
         cmbavWsversion.Name = "vWSVERSION";
         cmbavWsversion.WebTags = "";
         cmbavWsversion.addItem("GAM10", "Versão 1.0", 0);
         cmbavWsversion.addItem("GAM20", "Versão 2.0", 0);
         if ( cmbavWsversion.ItemCount > 0 )
         {
         }
         cmbavWsserversecureprotocol.Name = "vWSSERVERSECUREPROTOCOL";
         cmbavWsserversecureprotocol.WebTags = "";
         cmbavWsserversecureprotocol.addItem("0", "Não", 0);
         cmbavWsserversecureprotocol.addItem("1", "Sim", 0);
         if ( cmbavWsserversecureprotocol.ItemCount > 0 )
         {
         }
         cmbavCusversion.Name = "vCUSVERSION";
         cmbavCusversion.WebTags = "";
         cmbavCusversion.addItem("GAM10", "Versão 1.0", 0);
         cmbavCusversion.addItem("GAM20", "Versão 2.0", 0);
         if ( cmbavCusversion.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavName_Internalname = sPrefix+"vNAME";
         cmbavFunctionid_Internalname = sPrefix+"vFUNCTIONID";
         edtavDsc_Internalname = sPrefix+"vDSC";
         chkavIsenable_Internalname = sPrefix+"vISENABLE";
         edtavAdditionalscope_Internalname = sPrefix+"vADDITIONALSCOPE";
         edtavSmallimagename_Internalname = sPrefix+"vSMALLIMAGENAME";
         edtavBigimagename_Internalname = sPrefix+"vBIGIMAGENAME";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         edtavClientid_Internalname = sPrefix+"vCLIENTID";
         edtavClientsecret_Internalname = sPrefix+"vCLIENTSECRET";
         edtavSiteurl_Internalname = sPrefix+"vSITEURL";
         edtavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         edtavGamrserverurl_Internalname = sPrefix+"vGAMRSERVERURL";
         divGamrserverurl_cell_Internalname = sPrefix+"GAMRSERVERURL_CELL";
         edtavGamrprivateencryptkey_Internalname = sPrefix+"vGAMRPRIVATEENCRYPTKEY";
         divGamrprivateencryptkey_cell_Internalname = sPrefix+"GAMRPRIVATEENCRYPTKEY_CELL";
         edtavGamrrepositoryguid_Internalname = sPrefix+"vGAMRREPOSITORYGUID";
         divGamrrepositoryguid_cell_Internalname = sPrefix+"GAMRREPOSITORYGUID_CELL";
         divFb_Internalname = sPrefix+"FB";
         Dvpanel_fb_Internalname = sPrefix+"DVPANEL_FB";
         divTblfacebook_Internalname = sPrefix+"TBLFACEBOOK";
         edtavConsumerkey_Internalname = sPrefix+"vCONSUMERKEY";
         edtavConsumersecret_Internalname = sPrefix+"vCONSUMERSECRET";
         edtavCallbackurl_Internalname = sPrefix+"vCALLBACKURL";
         divTw_Internalname = sPrefix+"TW";
         Dvpanel_tw_Internalname = sPrefix+"DVPANEL_TW";
         divTbltwitter_Internalname = sPrefix+"TBLTWITTER";
         cmbavWsversion_Internalname = sPrefix+"vWSVERSION";
         edtavWsimpersonate_Internalname = sPrefix+"vWSIMPERSONATE";
         lblTextblockwsprivateencryptkey_Internalname = sPrefix+"TEXTBLOCKWSPRIVATEENCRYPTKEY";
         edtavWsprivateencryptkey_Internalname = sPrefix+"vWSPRIVATEENCRYPTKEY";
         bttBtngenkey_Internalname = sPrefix+"BTNGENKEY";
         tblTablemergedwsprivateencryptkey_Internalname = sPrefix+"TABLEMERGEDWSPRIVATEENCRYPTKEY";
         divTablesplittedwsprivateencryptkey_Internalname = sPrefix+"TABLESPLITTEDWSPRIVATEENCRYPTKEY";
         edtavWsservername_Internalname = sPrefix+"vWSSERVERNAME";
         edtavWsserverport_Internalname = sPrefix+"vWSSERVERPORT";
         edtavWsserverbaseurl_Internalname = sPrefix+"vWSSERVERBASEURL";
         cmbavWsserversecureprotocol_Internalname = sPrefix+"vWSSERVERSECUREPROTOCOL";
         edtavWstimeout_Internalname = sPrefix+"vWSTIMEOUT";
         edtavWspackage_Internalname = sPrefix+"vWSPACKAGE";
         edtavWsname_Internalname = sPrefix+"vWSNAME";
         edtavWsextension_Internalname = sPrefix+"vWSEXTENSION";
         divWs_Internalname = sPrefix+"WS";
         Dvpanel_ws_Internalname = sPrefix+"DVPANEL_WS";
         divTblwebservice_Internalname = sPrefix+"TBLWEBSERVICE";
         cmbavCusversion_Internalname = sPrefix+"vCUSVERSION";
         edtavCusimpersonate_Internalname = sPrefix+"vCUSIMPERSONATE";
         lblTextblockcusprivateencryptkey_Internalname = sPrefix+"TEXTBLOCKCUSPRIVATEENCRYPTKEY";
         edtavCusprivateencryptkey_Internalname = sPrefix+"vCUSPRIVATEENCRYPTKEY";
         bttBtngenkeycustom_Internalname = sPrefix+"BTNGENKEYCUSTOM";
         tblTablemergedcusprivateencryptkey_Internalname = sPrefix+"TABLEMERGEDCUSPRIVATEENCRYPTKEY";
         divTablesplittedcusprivateencryptkey_Internalname = sPrefix+"TABLESPLITTEDCUSPRIVATEENCRYPTKEY";
         edtavCusfilename_Internalname = sPrefix+"vCUSFILENAME";
         edtavCuspackage_Internalname = sPrefix+"vCUSPACKAGE";
         edtavCusclassname_Internalname = sPrefix+"vCUSCLASSNAME";
         divExt_Internalname = sPrefix+"EXT";
         Dvpanel_ext_Internalname = sPrefix+"DVPANEL_EXT";
         divTblexternal_Internalname = sPrefix+"TBLEXTERNAL";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkavIsenable.Caption = "Habilitado?";
         bttBtngenkey_Visible = 1;
         edtavWsprivateencryptkey_Jsonclick = "";
         bttBtngenkeycustom_Visible = 1;
         edtavCusprivateencryptkey_Jsonclick = "";
         edtavCusprivateencryptkey_Enabled = 1;
         edtavWsprivateencryptkey_Enabled = 1;
         bttBtnenter_Caption = "Confirmar";
         bttBtnenter_Visible = 1;
         edtavCusclassname_Jsonclick = "";
         edtavCusclassname_Enabled = 1;
         edtavCuspackage_Jsonclick = "";
         edtavCuspackage_Enabled = 1;
         edtavCusfilename_Jsonclick = "";
         edtavCusfilename_Enabled = 1;
         edtavCusimpersonate_Jsonclick = "";
         edtavCusimpersonate_Enabled = 1;
         cmbavCusversion_Jsonclick = "";
         cmbavCusversion.Enabled = 1;
         divTblexternal_Visible = 1;
         edtavWsextension_Jsonclick = "";
         edtavWsextension_Enabled = 1;
         edtavWsname_Jsonclick = "";
         edtavWsname_Enabled = 1;
         edtavWspackage_Jsonclick = "";
         edtavWspackage_Enabled = 1;
         edtavWstimeout_Jsonclick = "";
         edtavWstimeout_Enabled = 1;
         cmbavWsserversecureprotocol_Jsonclick = "";
         cmbavWsserversecureprotocol.Enabled = 1;
         edtavWsserverbaseurl_Jsonclick = "";
         edtavWsserverbaseurl_Enabled = 1;
         edtavWsserverport_Jsonclick = "";
         edtavWsserverport_Enabled = 1;
         edtavWsservername_Jsonclick = "";
         edtavWsservername_Enabled = 1;
         edtavWsimpersonate_Jsonclick = "";
         edtavWsimpersonate_Enabled = 1;
         cmbavWsversion_Jsonclick = "";
         cmbavWsversion.Enabled = 1;
         divTblwebservice_Visible = 1;
         edtavCallbackurl_Jsonclick = "";
         edtavCallbackurl_Enabled = 1;
         edtavConsumersecret_Jsonclick = "";
         edtavConsumersecret_Enabled = 1;
         edtavConsumerkey_Jsonclick = "";
         edtavConsumerkey_Enabled = 1;
         divTbltwitter_Visible = 1;
         edtavGamrrepositoryguid_Jsonclick = "";
         edtavGamrrepositoryguid_Enabled = 1;
         edtavGamrrepositoryguid_Visible = 1;
         divGamrrepositoryguid_cell_Class = "col-xs-12 col-sm-6";
         edtavGamrprivateencryptkey_Jsonclick = "";
         edtavGamrprivateencryptkey_Enabled = 1;
         edtavGamrprivateencryptkey_Visible = 1;
         divGamrprivateencryptkey_cell_Class = "col-xs-12 col-sm-6";
         edtavGamrserverurl_Jsonclick = "";
         edtavGamrserverurl_Enabled = 1;
         edtavGamrserverurl_Visible = 1;
         divGamrserverurl_cell_Class = "col-xs-12 col-sm-6";
         edtavImpersonate_Jsonclick = "";
         edtavImpersonate_Enabled = 1;
         edtavImpersonate_Visible = 1;
         edtavSiteurl_Jsonclick = "";
         edtavSiteurl_Enabled = 1;
         edtavClientsecret_Jsonclick = "";
         edtavClientsecret_Enabled = 1;
         edtavClientid_Jsonclick = "";
         edtavClientid_Enabled = 1;
         divTblfacebook_Visible = 1;
         edtavBigimagename_Jsonclick = "";
         edtavBigimagename_Enabled = 1;
         edtavSmallimagename_Jsonclick = "";
         edtavSmallimagename_Enabled = 1;
         edtavAdditionalscope_Jsonclick = "";
         edtavAdditionalscope_Enabled = 1;
         edtavAdditionalscope_Visible = 1;
         chkavIsenable.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         cmbavFunctionid_Jsonclick = "";
         cmbavFunctionid.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 0;
         Dvpanel_ext_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_ext_Iconposition = "Right";
         Dvpanel_ext_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_ext_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_ext_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_ext_Title = "External";
         Dvpanel_ext_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_ext_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_ext_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_ext_Width = "100%";
         Dvpanel_ws_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_ws_Iconposition = "Right";
         Dvpanel_ws_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_ws_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_ws_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_ws_Title = "Web Service";
         Dvpanel_ws_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_ws_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_ws_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_ws_Width = "100%";
         Dvpanel_tw_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tw_Iconposition = "Right";
         Dvpanel_tw_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tw_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tw_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tw_Title = "Twitter";
         Dvpanel_tw_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tw_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tw_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tw_Width = "100%";
         Dvpanel_fb_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_fb_Iconposition = "Right";
         Dvpanel_fb_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_fb_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_fb_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_fb_Title = "Facebook";
         Dvpanel_fb_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_fb_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_fb_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_fb_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV37TypeId',fld:'vTYPEID',pic:''},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'divTblfacebook_Visible',ctrl:'TBLFACEBOOK',prop:'Visible'},{av:'edtavAdditionalscope_Visible',ctrl:'vADDITIONALSCOPE',prop:'Visible'},{av:'divTbltwitter_Visible',ctrl:'TBLTWITTER',prop:'Visible'},{av:'divTblwebservice_Visible',ctrl:'TBLWEBSERVICE',prop:'Visible'},{av:'divTblexternal_Visible',ctrl:'TBLEXTERNAL',prop:'Visible'},{av:'edtavImpersonate_Visible',ctrl:'vIMPERSONATE',prop:'Visible'},{av:'edtavGamrprivateencryptkey_Visible',ctrl:'vGAMRPRIVATEENCRYPTKEY',prop:'Visible'},{av:'edtavGamrserverurl_Visible',ctrl:'vGAMRSERVERURL',prop:'Visible'},{av:'Dvpanel_fb_Title',ctrl:'DVPANEL_FB',prop:'Title'},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("'DOGENKEYCUSTOM'","{handler:'E12122',iparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("'DOGENKEYCUSTOM'",",oparms:[{av:'AV23CusPrivateEncryptKey',fld:'vCUSPRIVATEENCRYPTKEY',pic:''},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("'DOGENKEY'","{handler:'E13122',iparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("'DOGENKEY'",",oparms:[{av:'AV41WSPrivateEncryptKey',fld:'vWSPRIVATEENCRYPTKEY',pic:''},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E14122',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV30GAMRRepositoryGUID',fld:'vGAMRREPOSITORYGUID',pic:''},{av:'AV29GAMRPrivateEncryptKey',fld:'vGAMRPRIVATEENCRYPTKEY',pic:''},{av:'AV31GAMRServerURL',fld:'vGAMRSERVERURL',pic:''},{av:'AV35SiteURL',fld:'vSITEURL',pic:''},{av:'AV17ClientSecret',fld:'vCLIENTSECRET',pic:''},{av:'AV16ClientId',fld:'vCLIENTID',pic:''},{av:'AV32Impersonate',fld:'vIMPERSONATE',pic:''},{av:'AV5AdditionalScope',fld:'vADDITIONALSCOPE',pic:''},{av:'AV15CallbackURL',fld:'vCALLBACKURL',pic:''},{av:'AV19ConsumerSecret',fld:'vCONSUMERSECRET',pic:''},{av:'AV18ConsumerKey',fld:'vCONSUMERKEY',pic:''},{av:'cmbavWsserversecureprotocol'},{av:'AV45WSServerSecureProtocol',fld:'vWSSERVERSECUREPROTOCOL',pic:'9'},{av:'AV42WSServerBaseURL',fld:'vWSSERVERBASEURL',pic:''},{av:'AV44WSServerPort',fld:'vWSSERVERPORT',pic:'ZZZZ9'},{av:'AV43WSServerName',fld:'vWSSERVERNAME',pic:''},{av:'AV38WSExtension',fld:'vWSEXTENSION',pic:''},{av:'AV39WSName',fld:'vWSNAME',pic:''},{av:'AV40WSPackage',fld:'vWSPACKAGE',pic:''},{av:'AV46WSTimeout',fld:'vWSTIMEOUT',pic:'ZZZZ9'},{av:'AV41WSPrivateEncryptKey',fld:'vWSPRIVATEENCRYPTKEY',pic:''},{av:'cmbavWsversion'},{av:'AV47WSVersion',fld:'vWSVERSION',pic:''},{av:'AV54WSImpersonate',fld:'vWSIMPERSONATE',pic:''},{av:'AV20CusClassName',fld:'vCUSCLASSNAME',pic:''},{av:'AV22CusPackage',fld:'vCUSPACKAGE',pic:''},{av:'AV21CusFileName',fld:'vCUSFILENAME',pic:''},{av:'AV23CusPrivateEncryptKey',fld:'vCUSPRIVATEENCRYPTKEY',pic:''},{av:'cmbavCusversion'},{av:'AV24CusVersion',fld:'vCUSVERSION',pic:''},{av:'AV53CusImpersonate',fld:'vCUSIMPERSONATE',pic:''},{av:'AV25Dsc',fld:'vDSC',pic:''},{av:'cmbavFunctionid'},{av:'AV28FunctionId',fld:'vFUNCTIONID',pic:''},{av:'AV34Name',fld:'vNAME',pic:''},{av:'AV37TypeId',fld:'vTYPEID',pic:''},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'cmbavFunctionid'},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("'GENERATEKEY'","{handler:'E15122',iparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("'GENERATEKEY'",",oparms:[{av:'AV41WSPrivateEncryptKey',fld:'vWSPRIVATEENCRYPTKEY',pic:''},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("'GENERATEKEYCUSTOM'","{handler:'E16122',iparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("'GENERATEKEYCUSTOM'",",oparms:[{av:'AV23CusPrivateEncryptKey',fld:'vCUSPRIVATEENCRYPTKEY',pic:''},{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("VALIDV_FUNCTIONID","{handler:'Validv_Functionid',iparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("VALIDV_FUNCTIONID",",oparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("VALIDV_WSVERSION","{handler:'Validv_Wsversion',iparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("VALIDV_WSVERSION",",oparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
         setEventMetadata("VALIDV_CUSVERSION","{handler:'Validv_Cusversion',iparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]");
         setEventMetadata("VALIDV_CUSVERSION",",oparms:[{av:'AV33IsEnable',fld:'vISENABLE',pic:''}]}");
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
         wcpOAV34Name = "";
         wcpOAV37TypeId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV28FunctionId = "";
         AV25Dsc = "";
         AV5AdditionalScope = "";
         AV36SmallImageName = "";
         AV14BigImageName = "";
         ucDvpanel_fb = new GXUserControl();
         AV16ClientId = "";
         AV17ClientSecret = "";
         AV35SiteURL = "";
         AV32Impersonate = "";
         AV31GAMRServerURL = "";
         AV29GAMRPrivateEncryptKey = "";
         AV30GAMRRepositoryGUID = "";
         ucDvpanel_tw = new GXUserControl();
         AV18ConsumerKey = "";
         AV19ConsumerSecret = "";
         AV15CallbackURL = "";
         ucDvpanel_ws = new GXUserControl();
         AV47WSVersion = "";
         AV54WSImpersonate = "";
         lblTextblockwsprivateencryptkey_Jsonclick = "";
         AV43WSServerName = "";
         AV42WSServerBaseURL = "";
         AV45WSServerSecureProtocol = 0;
         AV40WSPackage = "";
         AV39WSName = "";
         AV38WSExtension = "";
         ucDvpanel_ext = new GXUserControl();
         AV24CusVersion = "";
         AV53CusImpersonate = "";
         lblTextblockcusprivateencryptkey_Jsonclick = "";
         AV21CusFileName = "";
         AV22CusPackage = "";
         AV20CusClassName = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41WSPrivateEncryptKey = "";
         AV23CusPrivateEncryptKey = "";
         AV10AuthenticationTypeLocal = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeLocal(context);
         AV7AuthenticationTypeFacebook = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFacebook(context);
         AV9AuthenticationTypeGoogle = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGoogle(context);
         AV8AuthenticationTypeGAMRemote = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemote(context);
         AV12AuthenticationTypeTwitter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeTwitter(context);
         AV13AuthenticationTypeWebService = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWebService(context);
         AV6AuthenticationTypeCustom = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeCustom(context);
         AV27Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV26Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         bttBtngenkeycustom_Jsonclick = "";
         bttBtngenkey_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV34Name = "";
         sCtrlAV37TypeId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentrygeneral__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentrygeneral__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short AV45WSServerSecureProtocol ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavAdditionalscope_Visible ;
      private int edtavAdditionalscope_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int divTblfacebook_Visible ;
      private int edtavClientid_Enabled ;
      private int edtavClientsecret_Enabled ;
      private int edtavSiteurl_Enabled ;
      private int edtavImpersonate_Visible ;
      private int edtavImpersonate_Enabled ;
      private int edtavGamrserverurl_Visible ;
      private int edtavGamrserverurl_Enabled ;
      private int edtavGamrprivateencryptkey_Visible ;
      private int edtavGamrprivateencryptkey_Enabled ;
      private int edtavGamrrepositoryguid_Visible ;
      private int edtavGamrrepositoryguid_Enabled ;
      private int divTbltwitter_Visible ;
      private int edtavConsumerkey_Enabled ;
      private int edtavConsumersecret_Enabled ;
      private int edtavCallbackurl_Enabled ;
      private int divTblwebservice_Visible ;
      private int edtavWsimpersonate_Enabled ;
      private int edtavWsservername_Enabled ;
      private int AV44WSServerPort ;
      private int edtavWsserverport_Enabled ;
      private int edtavWsserverbaseurl_Enabled ;
      private int AV46WSTimeout ;
      private int edtavWstimeout_Enabled ;
      private int edtavWspackage_Enabled ;
      private int edtavWsname_Enabled ;
      private int edtavWsextension_Enabled ;
      private int divTblexternal_Visible ;
      private int edtavCusimpersonate_Enabled ;
      private int edtavCusfilename_Enabled ;
      private int edtavCuspackage_Enabled ;
      private int edtavCusclassname_Enabled ;
      private int bttBtnenter_Visible ;
      private int bttBtngenkey_Visible ;
      private int bttBtngenkeycustom_Visible ;
      private int edtavWsprivateencryptkey_Enabled ;
      private int edtavCusprivateencryptkey_Enabled ;
      private int AV58GXV1 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV34Name ;
      private string AV37TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV34Name ;
      private string wcpOAV37TypeId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_fb_Width ;
      private string Dvpanel_fb_Cls ;
      private string Dvpanel_fb_Title ;
      private string Dvpanel_fb_Iconposition ;
      private string Dvpanel_tw_Width ;
      private string Dvpanel_tw_Cls ;
      private string Dvpanel_tw_Title ;
      private string Dvpanel_tw_Iconposition ;
      private string Dvpanel_ws_Width ;
      private string Dvpanel_ws_Cls ;
      private string Dvpanel_ws_Title ;
      private string Dvpanel_ws_Iconposition ;
      private string Dvpanel_ext_Width ;
      private string Dvpanel_ext_Cls ;
      private string Dvpanel_ext_Title ;
      private string Dvpanel_ext_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string cmbavFunctionid_Internalname ;
      private string AV28FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string edtavDsc_Internalname ;
      private string AV25Dsc ;
      private string edtavDsc_Jsonclick ;
      private string chkavIsenable_Internalname ;
      private string edtavAdditionalscope_Internalname ;
      private string edtavAdditionalscope_Jsonclick ;
      private string edtavSmallimagename_Internalname ;
      private string AV36SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string edtavBigimagename_Internalname ;
      private string AV14BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string divTblfacebook_Internalname ;
      private string Dvpanel_fb_Internalname ;
      private string divFb_Internalname ;
      private string edtavClientid_Internalname ;
      private string edtavClientid_Jsonclick ;
      private string edtavClientsecret_Internalname ;
      private string edtavClientsecret_Jsonclick ;
      private string edtavSiteurl_Internalname ;
      private string edtavSiteurl_Jsonclick ;
      private string edtavImpersonate_Internalname ;
      private string AV32Impersonate ;
      private string edtavImpersonate_Jsonclick ;
      private string divGamrserverurl_cell_Internalname ;
      private string divGamrserverurl_cell_Class ;
      private string edtavGamrserverurl_Internalname ;
      private string edtavGamrserverurl_Jsonclick ;
      private string divGamrprivateencryptkey_cell_Internalname ;
      private string divGamrprivateencryptkey_cell_Class ;
      private string edtavGamrprivateencryptkey_Internalname ;
      private string AV29GAMRPrivateEncryptKey ;
      private string edtavGamrprivateencryptkey_Jsonclick ;
      private string divGamrrepositoryguid_cell_Internalname ;
      private string divGamrrepositoryguid_cell_Class ;
      private string edtavGamrrepositoryguid_Internalname ;
      private string AV30GAMRRepositoryGUID ;
      private string edtavGamrrepositoryguid_Jsonclick ;
      private string divTbltwitter_Internalname ;
      private string Dvpanel_tw_Internalname ;
      private string divTw_Internalname ;
      private string edtavConsumerkey_Internalname ;
      private string AV18ConsumerKey ;
      private string edtavConsumerkey_Jsonclick ;
      private string edtavConsumersecret_Internalname ;
      private string AV19ConsumerSecret ;
      private string edtavConsumersecret_Jsonclick ;
      private string edtavCallbackurl_Internalname ;
      private string edtavCallbackurl_Jsonclick ;
      private string divTblwebservice_Internalname ;
      private string Dvpanel_ws_Internalname ;
      private string divWs_Internalname ;
      private string cmbavWsversion_Internalname ;
      private string AV47WSVersion ;
      private string cmbavWsversion_Jsonclick ;
      private string edtavWsimpersonate_Internalname ;
      private string AV54WSImpersonate ;
      private string edtavWsimpersonate_Jsonclick ;
      private string divTablesplittedwsprivateencryptkey_Internalname ;
      private string lblTextblockwsprivateencryptkey_Internalname ;
      private string lblTextblockwsprivateencryptkey_Jsonclick ;
      private string edtavWsservername_Internalname ;
      private string AV43WSServerName ;
      private string edtavWsservername_Jsonclick ;
      private string edtavWsserverport_Internalname ;
      private string edtavWsserverport_Jsonclick ;
      private string edtavWsserverbaseurl_Internalname ;
      private string edtavWsserverbaseurl_Jsonclick ;
      private string cmbavWsserversecureprotocol_Internalname ;
      private string cmbavWsserversecureprotocol_Jsonclick ;
      private string edtavWstimeout_Internalname ;
      private string edtavWstimeout_Jsonclick ;
      private string edtavWspackage_Internalname ;
      private string AV40WSPackage ;
      private string edtavWspackage_Jsonclick ;
      private string edtavWsname_Internalname ;
      private string AV39WSName ;
      private string edtavWsname_Jsonclick ;
      private string edtavWsextension_Internalname ;
      private string AV38WSExtension ;
      private string edtavWsextension_Jsonclick ;
      private string divTblexternal_Internalname ;
      private string Dvpanel_ext_Internalname ;
      private string divExt_Internalname ;
      private string cmbavCusversion_Internalname ;
      private string AV24CusVersion ;
      private string cmbavCusversion_Jsonclick ;
      private string edtavCusimpersonate_Internalname ;
      private string AV53CusImpersonate ;
      private string edtavCusimpersonate_Jsonclick ;
      private string divTablesplittedcusprivateencryptkey_Internalname ;
      private string lblTextblockcusprivateencryptkey_Internalname ;
      private string lblTextblockcusprivateencryptkey_Jsonclick ;
      private string edtavCusfilename_Internalname ;
      private string AV21CusFileName ;
      private string edtavCusfilename_Jsonclick ;
      private string edtavCuspackage_Internalname ;
      private string AV22CusPackage ;
      private string edtavCuspackage_Jsonclick ;
      private string edtavCusclassname_Internalname ;
      private string AV20CusClassName ;
      private string edtavCusclassname_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV41WSPrivateEncryptKey ;
      private string edtavWsprivateencryptkey_Internalname ;
      private string AV23CusPrivateEncryptKey ;
      private string edtavCusprivateencryptkey_Internalname ;
      private string bttBtngenkey_Internalname ;
      private string bttBtngenkeycustom_Internalname ;
      private string sStyleString ;
      private string tblTablemergedcusprivateencryptkey_Internalname ;
      private string edtavCusprivateencryptkey_Jsonclick ;
      private string bttBtngenkeycustom_Jsonclick ;
      private string tblTablemergedwsprivateencryptkey_Internalname ;
      private string edtavWsprivateencryptkey_Jsonclick ;
      private string bttBtngenkey_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV34Name ;
      private string sCtrlAV37TypeId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_fb_Autowidth ;
      private bool Dvpanel_fb_Autoheight ;
      private bool Dvpanel_fb_Collapsible ;
      private bool Dvpanel_fb_Collapsed ;
      private bool Dvpanel_fb_Showcollapseicon ;
      private bool Dvpanel_fb_Autoscroll ;
      private bool Dvpanel_tw_Autowidth ;
      private bool Dvpanel_tw_Autoheight ;
      private bool Dvpanel_tw_Collapsible ;
      private bool Dvpanel_tw_Collapsed ;
      private bool Dvpanel_tw_Showcollapseicon ;
      private bool Dvpanel_tw_Autoscroll ;
      private bool Dvpanel_ws_Autowidth ;
      private bool Dvpanel_ws_Autoheight ;
      private bool Dvpanel_ws_Collapsible ;
      private bool Dvpanel_ws_Collapsed ;
      private bool Dvpanel_ws_Showcollapseicon ;
      private bool Dvpanel_ws_Autoscroll ;
      private bool Dvpanel_ext_Autowidth ;
      private bool Dvpanel_ext_Autoheight ;
      private bool Dvpanel_ext_Collapsible ;
      private bool Dvpanel_ext_Collapsed ;
      private bool Dvpanel_ext_Showcollapseicon ;
      private bool Dvpanel_ext_Autoscroll ;
      private bool wbLoad ;
      private bool AV33IsEnable ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV5AdditionalScope ;
      private string AV16ClientId ;
      private string AV17ClientSecret ;
      private string AV35SiteURL ;
      private string AV31GAMRServerURL ;
      private string AV15CallbackURL ;
      private string AV42WSServerBaseURL ;
      private GXUserControl ucDvpanel_fb ;
      private GXUserControl ucDvpanel_tw ;
      private GXUserControl ucDvpanel_ws ;
      private GXUserControl ucDvpanel_ext ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeId ;
      private GXCombobox cmbavFunctionid ;
      private GXCheckbox chkavIsenable ;
      private GXCombobox cmbavWsversion ;
      private GXCombobox cmbavWsserversecureprotocol ;
      private GXCombobox cmbavCusversion ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV27Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeCustom AV6AuthenticationTypeCustom ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV26Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFacebook AV7AuthenticationTypeFacebook ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGAMRemote AV8AuthenticationTypeGAMRemote ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeGoogle AV9AuthenticationTypeGoogle ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeLocal AV10AuthenticationTypeLocal ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeTwitter AV12AuthenticationTypeTwitter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeWebService AV13AuthenticationTypeWebService ;
   }

   public class gamwcauthenticationtypeentrygeneral__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwcauthenticationtypeentrygeneral__default : DataStoreHelperBase, IDataStoreHelper
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
