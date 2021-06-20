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
   public class gamwcauthenticationtypeentryoauth20 : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public gamwcauthenticationtypeentryoauth20( )
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

      public gamwcauthenticationtypeentryoauth20( IGxContext context )
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
         this.AV29Name = aP1_Name;
         this.AV57TypeId = aP2_TypeId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV29Name;
         aP2_TypeId=this.AV57TypeId;
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
         chkavAuthresptypeinclude = new GXCheckbox();
         chkavAuthscopeinclude = new GXCheckbox();
         chkavAuthstateinclude = new GXCheckbox();
         chkavAuthclientidinclude = new GXCheckbox();
         chkavAuthclientsecretinclude = new GXCheckbox();
         chkavAuthredirurlinclude = new GXCheckbox();
         cmbavTokenmethod = new GXCombobox();
         chkavTokengranttypeinclude = new GXCheckbox();
         chkavTokenaccesscodeinclude = new GXCheckbox();
         chkavTokencliidinclude = new GXCheckbox();
         chkavTokenclisecretinclude = new GXCheckbox();
         chkavTokenredirecturlinclude = new GXCheckbox();
         chkavAutovalidateexternaltokenandrefresh = new GXCheckbox();
         cmbavUserinfomethod = new GXCombobox();
         chkavUserinfoaccesstokeninclude = new GXCheckbox();
         chkavUserinfoclientidinclude = new GXCheckbox();
         chkavUserinfoclientsecretinclude = new GXCheckbox();
         chkavUserinfouseridinclude = new GXCheckbox();
         chkavUserinforesponseuserlastnamegenauto = new GXCheckbox();
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
                  AV29Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV29Name", AV29Name);
                  AV57TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV57TypeId", AV57TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV29Name,(string)AV57TypeId});
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
            PA112( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS112( ) ;
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
            context.SendWebValue( "Authentication Type Entry Oauth20") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281546292", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwcauthenticationtypeentryoauth20.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV29Name)),UrlEncode(StringUtil.RTrim(AV57TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV29Name", StringUtil.RTrim( wcpOAV29Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV57TypeId", StringUtil.RTrim( wcpOAV57TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV57TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Width", StringUtil.RTrim( Dvpanel_unnamedtable10_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Cls", StringUtil.RTrim( Dvpanel_unnamedtable10_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Title", StringUtil.RTrim( Dvpanel_unnamedtable10_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable10_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Width", StringUtil.RTrim( Dvpanel_unnamedtable9_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Cls", StringUtil.RTrim( Dvpanel_unnamedtable9_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Title", StringUtil.RTrim( Dvpanel_unnamedtable9_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable9_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Width", StringUtil.RTrim( Dvpanel_unnamedtable6_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Cls", StringUtil.RTrim( Dvpanel_unnamedtable6_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Title", StringUtil.RTrim( Dvpanel_unnamedtable6_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable6_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE6_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Width", StringUtil.RTrim( Dvpanel_unnamedtable7_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Cls", StringUtil.RTrim( Dvpanel_unnamedtable7_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Title", StringUtil.RTrim( Dvpanel_unnamedtable7_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable7_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Width", StringUtil.RTrim( Dvpanel_unnamedtable5_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Cls", StringUtil.RTrim( Dvpanel_unnamedtable5_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Title", StringUtil.RTrim( Dvpanel_unnamedtable5_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable5_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Width", StringUtil.RTrim( Dvpanel_unnamedtable3_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Cls", StringUtil.RTrim( Dvpanel_unnamedtable3_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Title", StringUtil.RTrim( Dvpanel_unnamedtable3_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable3_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Width", StringUtil.RTrim( Dvpanel_unnamedtable2_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Cls", StringUtil.RTrim( Dvpanel_unnamedtable2_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Title", StringUtil.RTrim( Dvpanel_unnamedtable2_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable2_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
      }

      protected void RenderHtmlCloseForm112( )
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
         return "GAMWCAuthenticationTypeEntryOauth20" ;
      }

      public override string GetPgmdesc( )
      {
         return "Authentication Type Entry Oauth20" ;
      }

      protected void WB110( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "gamwcauthenticationtypeentryoauth20.aspx");
               context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
               context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
               context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
               context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
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
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV29Name), StringUtil.RTrim( context.localUtil.Format( AV29Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV26FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV26FunctionId);
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
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV23Dsc), StringUtil.RTrim( context.localUtil.Format( AV23Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenable_Internalname, "Habilitado?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV28IsEnable), "", "Habilitado?", 1, chkavIsenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(33, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,33);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAdditionalscope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdditionalscope_Internalname, "Escopo adicional", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdditionalscope_Internalname, AV93AdditionalScope, StringUtil.RTrim( context.localUtil.Format( AV93AdditionalScope, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdditionalscope_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAdditionalscope_Enabled, 0, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavImpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImpersonate_Internalname, "Personificar", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImpersonate_Internalname, StringUtil.RTrim( AV27Impersonate), StringUtil.RTrim( context.localUtil.Format( AV27Impersonate, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImpersonate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavImpersonate_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV36SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV36SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSmallimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV22BigImageName), StringUtil.RTrim( context.localUtil.Format( AV22BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavBigimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, sPrefix+"GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "Geral", "", "", lblGeneral_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOauth20clientidtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientidtag_Internalname, "Tag do ID do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientidtag_Internalname, StringUtil.RTrim( AV30Oauth20ClientIdTag), StringUtil.RTrim( context.localUtil.Format( AV30Oauth20ClientIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientidtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientidtag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOauth20clientidvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientidvalue_Internalname, "Valor do ID do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientidvalue_Internalname, AV31Oauth20ClientIdValue, StringUtil.RTrim( context.localUtil.Format( AV31Oauth20ClientIdValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientidvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientidvalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOauth20clientsecrettag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientsecrettag_Internalname, "Tag do segredo do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientsecrettag_Internalname, StringUtil.RTrim( AV32Oauth20ClientSecretTag), StringUtil.RTrim( context.localUtil.Format( AV32Oauth20ClientSecretTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientsecrettag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientsecrettag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOauth20clientsecretvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientsecretvalue_Internalname, "Valor do segredo do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientsecretvalue_Internalname, AV33Oauth20ClientSecretValue, StringUtil.RTrim( context.localUtil.Format( AV33Oauth20ClientSecretValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientsecretvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientsecretvalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOauth20redirecturltag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20redirecturltag_Internalname, "Tag de redirecionamento de url", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20redirecturltag_Internalname, StringUtil.RTrim( AV34Oauth20RedirectURLTag), StringUtil.RTrim( context.localUtil.Format( AV34Oauth20RedirectURLTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20redirecturltag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20redirecturltag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOauth20redirecturlvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20redirecturlvalue_Internalname, "Valor de redirecionamento de url", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20redirecturlvalue_Internalname, AV35Oauth20RedirectURLvalue, StringUtil.RTrim( context.localUtil.Format( AV35Oauth20RedirectURLvalue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20redirecturlvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20redirecturlvalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAuthorization_title_Internalname, "Autorização", "", "", lblAuthorization_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Authorization") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthorizeurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthorizeurl_Internalname, "Url", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthorizeurl_Internalname, AV10AuthorizeURL, StringUtil.RTrim( context.localUtil.Format( AV10AuthorizeURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthorizeurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthorizeurl_Enabled, 0, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable9.SetProperty("Width", Dvpanel_unnamedtable9_Width);
            ucDvpanel_unnamedtable9.SetProperty("AutoWidth", Dvpanel_unnamedtable9_Autowidth);
            ucDvpanel_unnamedtable9.SetProperty("AutoHeight", Dvpanel_unnamedtable9_Autoheight);
            ucDvpanel_unnamedtable9.SetProperty("Cls", Dvpanel_unnamedtable9_Cls);
            ucDvpanel_unnamedtable9.SetProperty("Title", Dvpanel_unnamedtable9_Title);
            ucDvpanel_unnamedtable9.SetProperty("Collapsible", Dvpanel_unnamedtable9_Collapsible);
            ucDvpanel_unnamedtable9.SetProperty("Collapsed", Dvpanel_unnamedtable9_Collapsed);
            ucDvpanel_unnamedtable9.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable9_Showcollapseicon);
            ucDvpanel_unnamedtable9.SetProperty("IconPosition", Dvpanel_unnamedtable9_Iconposition);
            ucDvpanel_unnamedtable9.SetProperty("AutoScroll", Dvpanel_unnamedtable9_Autoscroll);
            ucDvpanel_unnamedtable9.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable9_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE9Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE9Container"+"UnnamedTable9"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAuthresptypeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthresptypeinclude_Internalname, "Incluir tipo de resposta", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthresptypeinclude_Internalname, StringUtil.BoolToStr( AV14AuthRespTypeInclude), "", "Incluir tipo de resposta", 1, chkavAuthresptypeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(105, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,105);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthresptypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresptypetag_Internalname, "Tag do tipo de resposta", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresptypetag_Internalname, StringUtil.RTrim( AV15AuthRespTypeTag), StringUtil.RTrim( context.localUtil.Format( AV15AuthRespTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresptypetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresptypetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthresptypevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresptypevalue_Internalname, "Valor do tipo de resposta", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresptypevalue_Internalname, AV16AuthRespTypeValue, StringUtil.RTrim( context.localUtil.Format( AV16AuthRespTypeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresptypevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresptypevalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAuthscopeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthscopeinclude_Internalname, "Incluir escopo", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthscopeinclude_Internalname, StringUtil.BoolToStr( AV17AuthScopeInclude), "", "Incluir escopo", 1, chkavAuthscopeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthscopetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthscopetag_Internalname, "Tag do escopo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthscopetag_Internalname, StringUtil.RTrim( AV18AuthScopeTag), StringUtil.RTrim( context.localUtil.Format( AV18AuthScopeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthscopetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthscopetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthscopevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthscopevalue_Internalname, "Valor do escopo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthscopevalue_Internalname, AV19AuthScopeValue, StringUtil.RTrim( context.localUtil.Format( AV19AuthScopeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthscopevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthscopevalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAuthstateinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthstateinclude_Internalname, "Incluir estado", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthstateinclude_Internalname, StringUtil.BoolToStr( AV91AuthStateInclude), "", "Incluir estado", 1, chkavAuthstateinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(131, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,131);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthstatetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthstatetag_Internalname, "Tag de estado", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthstatetag_Internalname, StringUtil.RTrim( AV20AuthStateTag), StringUtil.RTrim( context.localUtil.Format( AV20AuthStateTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthstatetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthstatetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAuthclientidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthclientidinclude_Internalname, "Inclua o id do cliente", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthclientidinclude_Internalname, StringUtil.BoolToStr( AV7AuthClientIdInclude), "", "Inclua o id do cliente", 1, chkavAuthclientidinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(140, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,140);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAuthclientsecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthclientsecretinclude_Internalname, "Incluir o segredo do cliente", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthclientsecretinclude_Internalname, StringUtil.BoolToStr( AV8AuthClientSecretInclude), "", "Incluir o segredo do cliente", 1, chkavAuthclientsecretinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(144, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,144);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAuthredirurlinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthredirurlinclude_Internalname, "Incluir url de redirecionamento", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthredirurlinclude_Internalname, StringUtil.BoolToStr( AV92AuthRedirURLInclude), "", "Incluir url de redirecionamento", 1, chkavAuthredirurlinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(148, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,148);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthadditionalparameters_Internalname, "Parâmetros adicionais", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthadditionalparameters_Internalname, StringUtil.RTrim( AV5AuthAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV5AuthAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthadditionalparameters_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthadditionalparameters_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthadditionalparameterssd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthadditionalparameterssd_Internalname, "Parâmetros adicionais para smart devices", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthadditionalparameterssd_Internalname, StringUtil.RTrim( AV6AuthAdditionalParametersSD), StringUtil.RTrim( context.localUtil.Format( AV6AuthAdditionalParametersSD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthadditionalparameterssd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthadditionalparameterssd_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable10.SetProperty("Width", Dvpanel_unnamedtable10_Width);
            ucDvpanel_unnamedtable10.SetProperty("AutoWidth", Dvpanel_unnamedtable10_Autowidth);
            ucDvpanel_unnamedtable10.SetProperty("AutoHeight", Dvpanel_unnamedtable10_Autoheight);
            ucDvpanel_unnamedtable10.SetProperty("Cls", Dvpanel_unnamedtable10_Cls);
            ucDvpanel_unnamedtable10.SetProperty("Title", Dvpanel_unnamedtable10_Title);
            ucDvpanel_unnamedtable10.SetProperty("Collapsible", Dvpanel_unnamedtable10_Collapsible);
            ucDvpanel_unnamedtable10.SetProperty("Collapsed", Dvpanel_unnamedtable10_Collapsed);
            ucDvpanel_unnamedtable10.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable10_Showcollapseicon);
            ucDvpanel_unnamedtable10.SetProperty("IconPosition", Dvpanel_unnamedtable10_Iconposition);
            ucDvpanel_unnamedtable10.SetProperty("AutoScroll", Dvpanel_unnamedtable10_Autoscroll);
            ucDvpanel_unnamedtable10.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable10_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE10Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE10Container"+"UnnamedTable10"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthresponseaccesscodetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresponseaccesscodetag_Internalname, "Tag de código de acesso", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresponseaccesscodetag_Internalname, StringUtil.RTrim( AV12AuthResponseAccessCodeTag), StringUtil.RTrim( context.localUtil.Format( AV12AuthResponseAccessCodeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresponseaccesscodetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresponseaccesscodetag_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthresponseerrordesctag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresponseerrordesctag_Internalname, "Tag de descrição do erro", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresponseerrordesctag_Internalname, StringUtil.RTrim( AV13AuthResponseErrorDescTag), StringUtil.RTrim( context.localUtil.Format( AV13AuthResponseErrorDescTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresponseerrordesctag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresponseerrordesctag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblToken_title_Internalname, "Token", "", "", lblToken_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Token") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenurl_Internalname, "Url", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenurl_Internalname, AV56TokenURL, StringUtil.RTrim( context.localUtil.Format( AV56TokenURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,182);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenurl_Enabled, 0, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable5.SetProperty("Width", Dvpanel_unnamedtable5_Width);
            ucDvpanel_unnamedtable5.SetProperty("AutoWidth", Dvpanel_unnamedtable5_Autowidth);
            ucDvpanel_unnamedtable5.SetProperty("AutoHeight", Dvpanel_unnamedtable5_Autoheight);
            ucDvpanel_unnamedtable5.SetProperty("Cls", Dvpanel_unnamedtable5_Cls);
            ucDvpanel_unnamedtable5.SetProperty("Title", Dvpanel_unnamedtable5_Title);
            ucDvpanel_unnamedtable5.SetProperty("Collapsible", Dvpanel_unnamedtable5_Collapsible);
            ucDvpanel_unnamedtable5.SetProperty("Collapsed", Dvpanel_unnamedtable5_Collapsed);
            ucDvpanel_unnamedtable5.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable5_Showcollapseicon);
            ucDvpanel_unnamedtable5.SetProperty("IconPosition", Dvpanel_unnamedtable5_Iconposition);
            ucDvpanel_unnamedtable5.SetProperty("AutoScroll", Dvpanel_unnamedtable5_Autoscroll);
            ucDvpanel_unnamedtable5.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable5_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE5Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE5Container"+"UnnamedTable5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavTokenmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTokenmethod_Internalname, "Método do token", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTokenmethod, cmbavTokenmethod_Internalname, StringUtil.RTrim( AV46TokenMethod), 1, cmbavTokenmethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavTokenmethod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,192);\"", "", true, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavTokenmethod.CurrentValue = StringUtil.RTrim( AV46TokenMethod);
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Values", (string)(cmbavTokenmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenheaderkeytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderkeytag_Internalname, "Tag do cabeçalho", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderkeytag_Internalname, StringUtil.RTrim( AV44TokenHeaderKeyTag), StringUtil.RTrim( context.localUtil.Format( AV44TokenHeaderKeyTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderkeytag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenheaderkeytag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenheaderkeyvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderkeyvalue_Internalname, "Valor do cabeçalho", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderkeyvalue_Internalname, AV45TokenHeaderKeyValue, StringUtil.RTrim( context.localUtil.Format( AV45TokenHeaderKeyValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,200);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderkeyvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenheaderkeyvalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTokengranttypeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokengranttypeinclude_Internalname, "Tipo de concessão", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokengranttypeinclude_Internalname, StringUtil.BoolToStr( AV41TokenGrantTypeInclude), "", "Tipo de concessão", 1, chkavTokengranttypeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(205, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,205);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokengranttypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokengranttypetag_Internalname, "Tag do tipo de concessão", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokengranttypetag_Internalname, StringUtil.RTrim( AV42TokenGrantTypeTag), StringUtil.RTrim( context.localUtil.Format( AV42TokenGrantTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,209);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokengranttypetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokengranttypetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokengranttypevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokengranttypevalue_Internalname, "Valor do tipo de concessão", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 213,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokengranttypevalue_Internalname, AV43TokenGrantTypeValue, StringUtil.RTrim( context.localUtil.Format( AV43TokenGrantTypeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,213);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokengranttypevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokengranttypevalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTokenaccesscodeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenaccesscodeinclude_Internalname, "Incluir código de acesso", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 218,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenaccesscodeinclude_Internalname, StringUtil.BoolToStr( AV37TokenAccessCodeInclude), "", "Incluir código de acesso", 1, chkavTokenaccesscodeinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(218, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,218);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTokencliidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokencliidinclude_Internalname, "Inclua o id do cliente", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 222,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokencliidinclude_Internalname, StringUtil.BoolToStr( AV39TokenCliIdInclude), "", "Inclua o id do cliente", 1, chkavTokencliidinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(222, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,222);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTokenclisecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenclisecretinclude_Internalname, "Incluir o segredo do cliente", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenclisecretinclude_Internalname, StringUtil.BoolToStr( AV40TokenCliSecretInclude), "", "Incluir o segredo do cliente", 1, chkavTokenclisecretinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(226, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,226);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTokenredirecturlinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenredirecturlinclude_Internalname, "Incluir url de redirecionamento", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenredirecturlinclude_Internalname, StringUtil.BoolToStr( AV47TokenRedirectURLInclude), "", "Incluir url de redirecionamento", 1, chkavTokenredirecturlinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(231, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,231);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenadditionalparameters_Internalname, "Parâmetros adicionais", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 235,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenadditionalparameters_Internalname, StringUtil.RTrim( AV38TokenAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV38TokenAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,235);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenadditionalparameters_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenadditionalparameters_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable6.SetProperty("Width", Dvpanel_unnamedtable6_Width);
            ucDvpanel_unnamedtable6.SetProperty("AutoWidth", Dvpanel_unnamedtable6_Autowidth);
            ucDvpanel_unnamedtable6.SetProperty("AutoHeight", Dvpanel_unnamedtable6_Autoheight);
            ucDvpanel_unnamedtable6.SetProperty("Cls", Dvpanel_unnamedtable6_Cls);
            ucDvpanel_unnamedtable6.SetProperty("Title", Dvpanel_unnamedtable6_Title);
            ucDvpanel_unnamedtable6.SetProperty("Collapsible", Dvpanel_unnamedtable6_Collapsible);
            ucDvpanel_unnamedtable6.SetProperty("Collapsed", Dvpanel_unnamedtable6_Collapsed);
            ucDvpanel_unnamedtable6.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable6_Showcollapseicon);
            ucDvpanel_unnamedtable6.SetProperty("IconPosition", Dvpanel_unnamedtable6_Iconposition);
            ucDvpanel_unnamedtable6.SetProperty("AutoScroll", Dvpanel_unnamedtable6_Autoscroll);
            ucDvpanel_unnamedtable6.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable6_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE6Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE6Container"+"UnnamedTable6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenresponseaccesstokentag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseaccesstokentag_Internalname, "Tag de código de acesso", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseaccesstokentag_Internalname, StringUtil.RTrim( AV49TokenResponseAccessTokenTag), StringUtil.RTrim( context.localUtil.Format( AV49TokenResponseAccessTokenTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,244);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseaccesstokentag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseaccesstokentag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenresponsetokentypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponsetokentypetag_Internalname, "Tag do tipo de token", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 248,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponsetokentypetag_Internalname, StringUtil.RTrim( AV54TokenResponseTokenTypeTag), StringUtil.RTrim( context.localUtil.Format( AV54TokenResponseTokenTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,248);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponsetokentypetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponsetokentypetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenresponseexpiresintag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseexpiresintag_Internalname, "Tag 'expira em'", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 253,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseexpiresintag_Internalname, StringUtil.RTrim( AV51TokenResponseExpiresInTag), StringUtil.RTrim( context.localUtil.Format( AV51TokenResponseExpiresInTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,253);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseexpiresintag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseexpiresintag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenresponsescopetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponsescopetag_Internalname, "Tag do escopo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 257,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponsescopetag_Internalname, StringUtil.RTrim( AV53TokenResponseScopeTag), StringUtil.RTrim( context.localUtil.Format( AV53TokenResponseScopeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,257);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponsescopetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponsescopetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenresponseuseridtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseuseridtag_Internalname, "Tag do id do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 262,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseuseridtag_Internalname, StringUtil.RTrim( AV55TokenResponseUserIdTag), StringUtil.RTrim( context.localUtil.Format( AV55TokenResponseUserIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,262);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseuseridtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseuseridtag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenresponserefreshtokentag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponserefreshtokentag_Internalname, "Tag de atualização do token", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponserefreshtokentag_Internalname, StringUtil.RTrim( AV52TokenResponseRefreshTokenTag), StringUtil.RTrim( context.localUtil.Format( AV52TokenResponseRefreshTokenTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,266);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponserefreshtokentag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponserefreshtokentag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenresponseerrordescriptiontag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseerrordescriptiontag_Internalname, "Tag de descrição do erro", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 271,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV50TokenResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV50TokenResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,271);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseerrordescriptiontag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseerrordescriptiontag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            ucDvpanel_unnamedtable7.SetProperty("Width", Dvpanel_unnamedtable7_Width);
            ucDvpanel_unnamedtable7.SetProperty("AutoWidth", Dvpanel_unnamedtable7_Autowidth);
            ucDvpanel_unnamedtable7.SetProperty("AutoHeight", Dvpanel_unnamedtable7_Autoheight);
            ucDvpanel_unnamedtable7.SetProperty("Cls", Dvpanel_unnamedtable7_Cls);
            ucDvpanel_unnamedtable7.SetProperty("Title", Dvpanel_unnamedtable7_Title);
            ucDvpanel_unnamedtable7.SetProperty("Collapsible", Dvpanel_unnamedtable7_Collapsible);
            ucDvpanel_unnamedtable7.SetProperty("Collapsed", Dvpanel_unnamedtable7_Collapsed);
            ucDvpanel_unnamedtable7.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable7_Showcollapseicon);
            ucDvpanel_unnamedtable7.SetProperty("IconPosition", Dvpanel_unnamedtable7_Iconposition);
            ucDvpanel_unnamedtable7.SetProperty("AutoScroll", Dvpanel_unnamedtable7_Autoscroll);
            ucDvpanel_unnamedtable7.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable7_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE7Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE7Container"+"UnnamedTable7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAutovalidateexternaltokenandrefresh_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAutovalidateexternaltokenandrefresh_Internalname, "Validar token externo", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAutovalidateexternaltokenandrefresh_Internalname, StringUtil.BoolToStr( AV21AutovalidateExternalTokenAndRefresh), "", "Validar token externo", 1, chkavAutovalidateexternaltokenandrefresh.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(281, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,281);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTokenrefreshtokenurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenrefreshtokenurl_Internalname, "Url de atualização do token", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 285,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenrefreshtokenurl_Internalname, AV48TokenRefreshTokenURL, StringUtil.RTrim( context.localUtil.Format( AV48TokenRefreshTokenURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,285);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenrefreshtokenurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenrefreshtokenurl_Enabled, 0, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUserinfo_title_Internalname, "Informação do usuário", "", "", lblUserinfo_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "UserInfo") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinfourl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfourl_Internalname, "Url", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 295,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfourl_Internalname, AV83UserInfoURL, StringUtil.RTrim( context.localUtil.Format( AV83UserInfoURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,295);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfourl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfourl_Enabled, 0, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable2.SetProperty("Width", Dvpanel_unnamedtable2_Width);
            ucDvpanel_unnamedtable2.SetProperty("AutoWidth", Dvpanel_unnamedtable2_Autowidth);
            ucDvpanel_unnamedtable2.SetProperty("AutoHeight", Dvpanel_unnamedtable2_Autoheight);
            ucDvpanel_unnamedtable2.SetProperty("Cls", Dvpanel_unnamedtable2_Cls);
            ucDvpanel_unnamedtable2.SetProperty("Title", Dvpanel_unnamedtable2_Title);
            ucDvpanel_unnamedtable2.SetProperty("Collapsible", Dvpanel_unnamedtable2_Collapsible);
            ucDvpanel_unnamedtable2.SetProperty("Collapsed", Dvpanel_unnamedtable2_Collapsed);
            ucDvpanel_unnamedtable2.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable2_Showcollapseicon);
            ucDvpanel_unnamedtable2.SetProperty("IconPosition", Dvpanel_unnamedtable2_Iconposition);
            ucDvpanel_unnamedtable2.SetProperty("AutoScroll", Dvpanel_unnamedtable2_Autoscroll);
            ucDvpanel_unnamedtable2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable2_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE2Container"+"UnnamedTable2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavUserinfomethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUserinfomethod_Internalname, "Método de informação do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 305,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUserinfomethod, cmbavUserinfomethod_Internalname, StringUtil.RTrim( AV67UserInfoMethod), 1, cmbavUserinfomethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUserinfomethod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,305);\"", "", true, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavUserinfomethod.CurrentValue = StringUtil.RTrim( AV67UserInfoMethod);
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Values", (string)(cmbavUserinfomethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinfoheaderkeytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoheaderkeytag_Internalname, "Tag do cabeçalho", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 310,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoheaderkeytag_Internalname, StringUtil.RTrim( AV65UserInfoHeaderKeyTag), StringUtil.RTrim( context.localUtil.Format( AV65UserInfoHeaderKeyTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,310);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoheaderkeytag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoheaderkeytag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinfoheaderkeyvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoheaderkeyvalue_Internalname, "Valor do cabeçalho", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 314,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoheaderkeyvalue_Internalname, AV66UserInfoHeaderKeyValue, StringUtil.RTrim( context.localUtil.Format( AV66UserInfoHeaderKeyValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,314);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoheaderkeyvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoheaderkeyvalue_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserinfoaccesstokeninclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoaccesstokeninclude_Internalname, "Incluir token de acesso", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 319,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoaccesstokeninclude_Internalname, StringUtil.BoolToStr( AV58UserInfoAccessTokenInclude), "", "Incluir token de acesso", 1, chkavUserinfoaccesstokeninclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(319, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,319);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinfoaccesstokenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoaccesstokenname_Internalname, "Tag de token de acesso", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 323,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoaccesstokenname_Internalname, StringUtil.RTrim( AV59UserInfoAccessTokenName), StringUtil.RTrim( context.localUtil.Format( AV59UserInfoAccessTokenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,323);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoaccesstokenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoaccesstokenname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserinfoclientidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoclientidinclude_Internalname, "Inclua o id do cliente", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 328,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoclientidinclude_Internalname, StringUtil.BoolToStr( AV61UserInfoClientIdInclude), "", "Inclua o id do cliente", 1, chkavUserinfoclientidinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(328, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,328);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinfoclientidname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoclientidname_Internalname, "Tag do ID do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 332,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoclientidname_Internalname, StringUtil.RTrim( AV62UserInfoClientIdName), StringUtil.RTrim( context.localUtil.Format( AV62UserInfoClientIdName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,332);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoclientidname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoclientidname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserinfoclientsecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoclientsecretinclude_Internalname, "Incluir o segredo do cliente", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 337,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoclientsecretinclude_Internalname, StringUtil.BoolToStr( AV63UserInfoClientSecretInclude), "", "Incluir o segredo do cliente", 1, chkavUserinfoclientsecretinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(337, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,337);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinfoclientsecretname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoclientsecretname_Internalname, "Tag do segredo do cliente", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 341,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoclientsecretname_Internalname, StringUtil.RTrim( AV64UserInfoClientSecretName), StringUtil.RTrim( context.localUtil.Format( AV64UserInfoClientSecretName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,341);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoclientsecretname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoclientsecretname_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserinfouseridinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfouseridinclude_Internalname, "Incluir id do usuário", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 346,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfouseridinclude_Internalname, StringUtil.BoolToStr( AV84UserInfoUserIdInclude), "", "Incluir id do usuário", 1, chkavUserinfouseridinclude.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(346, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,346);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinfoadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoadditionalparameters_Internalname, "Parâmetros adicionais", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 350,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoadditionalparameters_Internalname, StringUtil.RTrim( AV60UserInfoAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV60UserInfoAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,350);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoadditionalparameters_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoadditionalparameters_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable3.SetProperty("Width", Dvpanel_unnamedtable3_Width);
            ucDvpanel_unnamedtable3.SetProperty("AutoWidth", Dvpanel_unnamedtable3_Autowidth);
            ucDvpanel_unnamedtable3.SetProperty("AutoHeight", Dvpanel_unnamedtable3_Autoheight);
            ucDvpanel_unnamedtable3.SetProperty("Cls", Dvpanel_unnamedtable3_Cls);
            ucDvpanel_unnamedtable3.SetProperty("Title", Dvpanel_unnamedtable3_Title);
            ucDvpanel_unnamedtable3.SetProperty("Collapsible", Dvpanel_unnamedtable3_Collapsible);
            ucDvpanel_unnamedtable3.SetProperty("Collapsed", Dvpanel_unnamedtable3_Collapsed);
            ucDvpanel_unnamedtable3.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable3_Showcollapseicon);
            ucDvpanel_unnamedtable3.SetProperty("IconPosition", Dvpanel_unnamedtable3_Iconposition);
            ucDvpanel_unnamedtable3.SetProperty("AutoScroll", Dvpanel_unnamedtable3_Autoscroll);
            ucDvpanel_unnamedtable3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable3_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE3Container"+"UnnamedTable3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuseremailtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuseremailtag_Internalname, "Tag do e-mail do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 360,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuseremailtag_Internalname, StringUtil.RTrim( AV70UserInfoResponseUserEmailTag), StringUtil.RTrim( context.localUtil.Format( AV70UserInfoResponseUserEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,360);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuseremailtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuseremailtag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserverifiedemailtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserverifiedemailtag_Internalname, "Tag do e-mail do usuário verificado", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 364,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserverifiedemailtag_Internalname, StringUtil.RTrim( AV82UserInfoResponseUserVerifiedEmailTag), StringUtil.RTrim( context.localUtil.Format( AV82UserInfoResponseUserVerifiedEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,364);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserverifiedemailtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserverifiedemailtag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserexternalidtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserexternalidtag_Internalname, "Tag de id externo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 369,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserexternalidtag_Internalname, StringUtil.RTrim( AV71UserInfoResponseUserExternalIdTag), StringUtil.RTrim( context.localUtil.Format( AV71UserInfoResponseUserExternalIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,369);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserexternalidtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserexternalidtag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseusernametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusernametag_Internalname, "Tag do nome do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 373,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusernametag_Internalname, StringUtil.RTrim( AV78UserInfoResponseUserNameTag), StringUtil.RTrim( context.localUtil.Format( AV78UserInfoResponseUserNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,373);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusernametag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusernametag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserfirstnametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserfirstnametag_Internalname, "Tag do nome do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 378,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserfirstnametag_Internalname, StringUtil.RTrim( AV72UserInfoResponseUserFirstNameTag), StringUtil.RTrim( context.localUtil.Format( AV72UserInfoResponseUserFirstNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,378);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserfirstnametag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserfirstnametag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavUserinforesponseuserlastnamegenauto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinforesponseuserlastnamegenauto_Internalname, "Gerar automaticamente o sobrenome", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 383,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinforesponseuserlastnamegenauto_Internalname, StringUtil.BoolToStr( AV76UserInfoResponseUserLastNameGenAuto), "", "Gerar automaticamente o sobrenome", 1, chkavUserinforesponseuserlastnamegenauto.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,383);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserinforesponseuserlastnametag_cell_Internalname, 1, 0, "px", 0, "px", divUserinforesponseuserlastnametag_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserinforesponseuserlastnametag_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserlastnametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserlastnametag_Internalname, "Tag do sobrenome do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 387,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlastnametag_Internalname, StringUtil.RTrim( AV77UserInfoResponseUserLastNameTag), StringUtil.RTrim( context.localUtil.Format( AV77UserInfoResponseUserLastNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,387);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlastnametag_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserinforesponseuserlastnametag_Visible, edtavUserinforesponseuserlastnametag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseusergendertag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusergendertag_Internalname, "Tag do sexo do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 392,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendertag_Internalname, StringUtil.RTrim( AV73UserInfoResponseUserGenderTag), StringUtil.RTrim( context.localUtil.Format( AV73UserInfoResponseUserGenderTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,392);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendertag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusergendertag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseusergendervalues_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusergendervalues_Internalname, "Valores do sexo do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 396,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendervalues_Internalname, AV74UserInfoResponseUserGenderValues, StringUtil.RTrim( context.localUtil.Format( AV74UserInfoResponseUserGenderValues, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,396);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendervalues_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusergendervalues_Enabled, 0, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserbirthdaytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserbirthdaytag_Internalname, "Tag do aniversário do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 401,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserbirthdaytag_Internalname, StringUtil.RTrim( AV69UserInfoResponseUserBirthdayTag), StringUtil.RTrim( context.localUtil.Format( AV69UserInfoResponseUserBirthdayTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,401);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserbirthdaytag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserbirthdaytag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserurlimagetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlimagetag_Internalname, "Marcar o url da imagem do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 405,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlimagetag_Internalname, StringUtil.RTrim( AV80UserInfoResponseUserURLImageTag), StringUtil.RTrim( context.localUtil.Format( AV80UserInfoResponseUserURLImageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,405);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlimagetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserurlimagetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserurlprofiletag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlprofiletag_Internalname, "Marcar o url do perfil do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 410,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlprofiletag_Internalname, StringUtil.RTrim( AV81UserInfoResponseUserURLProfileTag), StringUtil.RTrim( context.localUtil.Format( AV81UserInfoResponseUserURLProfileTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,410);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlprofiletag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserurlprofiletag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserlanguagetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserlanguagetag_Internalname, "Tag do idioma do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 414,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlanguagetag_Internalname, StringUtil.RTrim( AV75UserInfoResponseUserLanguageTag), StringUtil.RTrim( context.localUtil.Format( AV75UserInfoResponseUserLanguageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,414);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlanguagetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserlanguagetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseusertimezonetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusertimezonetag_Internalname, "Tag do fuso horário do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 419,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusertimezonetag_Internalname, StringUtil.RTrim( AV79UserInfoResponseUserTimeZoneTag), StringUtil.RTrim( context.localUtil.Format( AV79UserInfoResponseUserTimeZoneTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,419);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusertimezonetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusertimezonetag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseerrordescriptiontag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseerrordescriptiontag_Internalname, "Tag de descrição do erro", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 423,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV68UserInfoResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV68UserInfoResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,423);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseerrordescriptiontag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseerrordescriptiontag_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 428,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 430,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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

      protected void START112( )
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
               Form.Meta.addItem("description", "Authentication Type Entry Oauth20", 0) ;
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
               STRUP110( ) ;
            }
         }
      }

      protected void WS112( )
      {
         START112( ) ;
         EVT112( ) ;
      }

      protected void EVT112( )
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
                                 STRUP110( ) ;
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
                                 STRUP110( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11112 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP110( ) ;
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
                                          E12112 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP110( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E13112 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP110( ) ;
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

      protected void WE112( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm112( ) ;
            }
         }
      }

      protected void PA112( )
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
            AV26FunctionId = cmbavFunctionid.getValidValue(AV26FunctionId);
            AssignAttri(sPrefix, false, "AV26FunctionId", AV26FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV26FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV28IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsEnable));
         AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
         AV14AuthRespTypeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV14AuthRespTypeInclude));
         AssignAttri(sPrefix, false, "AV14AuthRespTypeInclude", AV14AuthRespTypeInclude);
         AV17AuthScopeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV17AuthScopeInclude));
         AssignAttri(sPrefix, false, "AV17AuthScopeInclude", AV17AuthScopeInclude);
         AV91AuthStateInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV91AuthStateInclude));
         AssignAttri(sPrefix, false, "AV91AuthStateInclude", AV91AuthStateInclude);
         AV7AuthClientIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV7AuthClientIdInclude));
         AssignAttri(sPrefix, false, "AV7AuthClientIdInclude", AV7AuthClientIdInclude);
         AV8AuthClientSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV8AuthClientSecretInclude));
         AssignAttri(sPrefix, false, "AV8AuthClientSecretInclude", AV8AuthClientSecretInclude);
         AV92AuthRedirURLInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV92AuthRedirURLInclude));
         AssignAttri(sPrefix, false, "AV92AuthRedirURLInclude", AV92AuthRedirURLInclude);
         if ( cmbavTokenmethod.ItemCount > 0 )
         {
            AV46TokenMethod = cmbavTokenmethod.getValidValue(AV46TokenMethod);
            AssignAttri(sPrefix, false, "AV46TokenMethod", AV46TokenMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTokenmethod.CurrentValue = StringUtil.RTrim( AV46TokenMethod);
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Values", cmbavTokenmethod.ToJavascriptSource(), true);
         }
         AV41TokenGrantTypeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV41TokenGrantTypeInclude));
         AssignAttri(sPrefix, false, "AV41TokenGrantTypeInclude", AV41TokenGrantTypeInclude);
         AV37TokenAccessCodeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV37TokenAccessCodeInclude));
         AssignAttri(sPrefix, false, "AV37TokenAccessCodeInclude", AV37TokenAccessCodeInclude);
         AV39TokenCliIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV39TokenCliIdInclude));
         AssignAttri(sPrefix, false, "AV39TokenCliIdInclude", AV39TokenCliIdInclude);
         AV40TokenCliSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV40TokenCliSecretInclude));
         AssignAttri(sPrefix, false, "AV40TokenCliSecretInclude", AV40TokenCliSecretInclude);
         AV47TokenRedirectURLInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV47TokenRedirectURLInclude));
         AssignAttri(sPrefix, false, "AV47TokenRedirectURLInclude", AV47TokenRedirectURLInclude);
         AV21AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( StringUtil.BoolToStr( AV21AutovalidateExternalTokenAndRefresh));
         AssignAttri(sPrefix, false, "AV21AutovalidateExternalTokenAndRefresh", AV21AutovalidateExternalTokenAndRefresh);
         if ( cmbavUserinfomethod.ItemCount > 0 )
         {
            AV67UserInfoMethod = cmbavUserinfomethod.getValidValue(AV67UserInfoMethod);
            AssignAttri(sPrefix, false, "AV67UserInfoMethod", AV67UserInfoMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUserinfomethod.CurrentValue = StringUtil.RTrim( AV67UserInfoMethod);
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Values", cmbavUserinfomethod.ToJavascriptSource(), true);
         }
         AV58UserInfoAccessTokenInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV58UserInfoAccessTokenInclude));
         AssignAttri(sPrefix, false, "AV58UserInfoAccessTokenInclude", AV58UserInfoAccessTokenInclude);
         AV61UserInfoClientIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV61UserInfoClientIdInclude));
         AssignAttri(sPrefix, false, "AV61UserInfoClientIdInclude", AV61UserInfoClientIdInclude);
         AV63UserInfoClientSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV63UserInfoClientSecretInclude));
         AssignAttri(sPrefix, false, "AV63UserInfoClientSecretInclude", AV63UserInfoClientSecretInclude);
         AV84UserInfoUserIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV84UserInfoUserIdInclude));
         AssignAttri(sPrefix, false, "AV84UserInfoUserIdInclude", AV84UserInfoUserIdInclude);
         AV76UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( StringUtil.BoolToStr( AV76UserInfoResponseUserLastNameGenAuto));
         AssignAttri(sPrefix, false, "AV76UserInfoResponseUserLastNameGenAuto", AV76UserInfoResponseUserLastNameGenAuto);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF112( ) ;
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

      protected void RF112( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13112 ();
            WB110( ) ;
         }
      }

      protected void send_integrity_lvl_hashes112( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP110( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11112 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV29Name = cgiGet( sPrefix+"wcpOAV29Name");
            wcpOAV57TypeId = cgiGet( sPrefix+"wcpOAV57TypeId");
            Dvpanel_unnamedtable10_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Width");
            Dvpanel_unnamedtable10_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Autowidth"));
            Dvpanel_unnamedtable10_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoheight"));
            Dvpanel_unnamedtable10_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Cls");
            Dvpanel_unnamedtable10_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Title");
            Dvpanel_unnamedtable10_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsible"));
            Dvpanel_unnamedtable10_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsed"));
            Dvpanel_unnamedtable10_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Showcollapseicon"));
            Dvpanel_unnamedtable10_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Iconposition");
            Dvpanel_unnamedtable10_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoscroll"));
            Dvpanel_unnamedtable9_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Width");
            Dvpanel_unnamedtable9_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Autowidth"));
            Dvpanel_unnamedtable9_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoheight"));
            Dvpanel_unnamedtable9_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Cls");
            Dvpanel_unnamedtable9_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Title");
            Dvpanel_unnamedtable9_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsible"));
            Dvpanel_unnamedtable9_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsed"));
            Dvpanel_unnamedtable9_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Showcollapseicon"));
            Dvpanel_unnamedtable9_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Iconposition");
            Dvpanel_unnamedtable9_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoscroll"));
            Dvpanel_unnamedtable6_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Width");
            Dvpanel_unnamedtable6_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Autowidth"));
            Dvpanel_unnamedtable6_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Autoheight"));
            Dvpanel_unnamedtable6_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Cls");
            Dvpanel_unnamedtable6_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Title");
            Dvpanel_unnamedtable6_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Collapsible"));
            Dvpanel_unnamedtable6_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Collapsed"));
            Dvpanel_unnamedtable6_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Showcollapseicon"));
            Dvpanel_unnamedtable6_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Iconposition");
            Dvpanel_unnamedtable6_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE6_Autoscroll"));
            Dvpanel_unnamedtable7_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Width");
            Dvpanel_unnamedtable7_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Autowidth"));
            Dvpanel_unnamedtable7_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoheight"));
            Dvpanel_unnamedtable7_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Cls");
            Dvpanel_unnamedtable7_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Title");
            Dvpanel_unnamedtable7_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsible"));
            Dvpanel_unnamedtable7_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsed"));
            Dvpanel_unnamedtable7_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Showcollapseicon"));
            Dvpanel_unnamedtable7_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Iconposition");
            Dvpanel_unnamedtable7_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoscroll"));
            Dvpanel_unnamedtable5_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Width");
            Dvpanel_unnamedtable5_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Autowidth"));
            Dvpanel_unnamedtable5_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoheight"));
            Dvpanel_unnamedtable5_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Cls");
            Dvpanel_unnamedtable5_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Title");
            Dvpanel_unnamedtable5_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsible"));
            Dvpanel_unnamedtable5_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsed"));
            Dvpanel_unnamedtable5_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Showcollapseicon"));
            Dvpanel_unnamedtable5_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Iconposition");
            Dvpanel_unnamedtable5_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoscroll"));
            Dvpanel_unnamedtable3_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Width");
            Dvpanel_unnamedtable3_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autowidth"));
            Dvpanel_unnamedtable3_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoheight"));
            Dvpanel_unnamedtable3_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Cls");
            Dvpanel_unnamedtable3_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Title");
            Dvpanel_unnamedtable3_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsible"));
            Dvpanel_unnamedtable3_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsed"));
            Dvpanel_unnamedtable3_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Showcollapseicon"));
            Dvpanel_unnamedtable3_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Iconposition");
            Dvpanel_unnamedtable3_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoscroll"));
            Dvpanel_unnamedtable2_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Width");
            Dvpanel_unnamedtable2_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Autowidth"));
            Dvpanel_unnamedtable2_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoheight"));
            Dvpanel_unnamedtable2_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Cls");
            Dvpanel_unnamedtable2_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Title");
            Dvpanel_unnamedtable2_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsible"));
            Dvpanel_unnamedtable2_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsed"));
            Dvpanel_unnamedtable2_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Showcollapseicon"));
            Dvpanel_unnamedtable2_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Iconposition");
            Dvpanel_unnamedtable2_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoscroll"));
            Gxuitabspanel_tabs_Pagecount = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GXUITABSPANEL_TABS_Pagecount"), ",", "."));
            Gxuitabspanel_tabs_Class = cgiGet( sPrefix+"GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( sPrefix+"GXUITABSPANEL_TABS_Historymanagement"));
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV29Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV29Name", AV29Name);
            }
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV26FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV26FunctionId", AV26FunctionId);
            AV23Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV23Dsc", AV23Dsc);
            AV28IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
            AV93AdditionalScope = cgiGet( edtavAdditionalscope_Internalname);
            AssignAttri(sPrefix, false, "AV93AdditionalScope", AV93AdditionalScope);
            AV27Impersonate = cgiGet( edtavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
            AV36SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV36SmallImageName", AV36SmallImageName);
            AV22BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV22BigImageName", AV22BigImageName);
            AV30Oauth20ClientIdTag = cgiGet( edtavOauth20clientidtag_Internalname);
            AssignAttri(sPrefix, false, "AV30Oauth20ClientIdTag", AV30Oauth20ClientIdTag);
            AV31Oauth20ClientIdValue = cgiGet( edtavOauth20clientidvalue_Internalname);
            AssignAttri(sPrefix, false, "AV31Oauth20ClientIdValue", AV31Oauth20ClientIdValue);
            AV32Oauth20ClientSecretTag = cgiGet( edtavOauth20clientsecrettag_Internalname);
            AssignAttri(sPrefix, false, "AV32Oauth20ClientSecretTag", AV32Oauth20ClientSecretTag);
            AV33Oauth20ClientSecretValue = cgiGet( edtavOauth20clientsecretvalue_Internalname);
            AssignAttri(sPrefix, false, "AV33Oauth20ClientSecretValue", AV33Oauth20ClientSecretValue);
            AV34Oauth20RedirectURLTag = cgiGet( edtavOauth20redirecturltag_Internalname);
            AssignAttri(sPrefix, false, "AV34Oauth20RedirectURLTag", AV34Oauth20RedirectURLTag);
            AV35Oauth20RedirectURLvalue = cgiGet( edtavOauth20redirecturlvalue_Internalname);
            AssignAttri(sPrefix, false, "AV35Oauth20RedirectURLvalue", AV35Oauth20RedirectURLvalue);
            AV10AuthorizeURL = cgiGet( edtavAuthorizeurl_Internalname);
            AssignAttri(sPrefix, false, "AV10AuthorizeURL", AV10AuthorizeURL);
            AV14AuthRespTypeInclude = StringUtil.StrToBool( cgiGet( chkavAuthresptypeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV14AuthRespTypeInclude", AV14AuthRespTypeInclude);
            AV15AuthRespTypeTag = cgiGet( edtavAuthresptypetag_Internalname);
            AssignAttri(sPrefix, false, "AV15AuthRespTypeTag", AV15AuthRespTypeTag);
            AV16AuthRespTypeValue = cgiGet( edtavAuthresptypevalue_Internalname);
            AssignAttri(sPrefix, false, "AV16AuthRespTypeValue", AV16AuthRespTypeValue);
            AV17AuthScopeInclude = StringUtil.StrToBool( cgiGet( chkavAuthscopeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV17AuthScopeInclude", AV17AuthScopeInclude);
            AV18AuthScopeTag = cgiGet( edtavAuthscopetag_Internalname);
            AssignAttri(sPrefix, false, "AV18AuthScopeTag", AV18AuthScopeTag);
            AV19AuthScopeValue = cgiGet( edtavAuthscopevalue_Internalname);
            AssignAttri(sPrefix, false, "AV19AuthScopeValue", AV19AuthScopeValue);
            AV91AuthStateInclude = StringUtil.StrToBool( cgiGet( chkavAuthstateinclude_Internalname));
            AssignAttri(sPrefix, false, "AV91AuthStateInclude", AV91AuthStateInclude);
            AV20AuthStateTag = cgiGet( edtavAuthstatetag_Internalname);
            AssignAttri(sPrefix, false, "AV20AuthStateTag", AV20AuthStateTag);
            AV7AuthClientIdInclude = StringUtil.StrToBool( cgiGet( chkavAuthclientidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV7AuthClientIdInclude", AV7AuthClientIdInclude);
            AV8AuthClientSecretInclude = StringUtil.StrToBool( cgiGet( chkavAuthclientsecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV8AuthClientSecretInclude", AV8AuthClientSecretInclude);
            AV92AuthRedirURLInclude = StringUtil.StrToBool( cgiGet( chkavAuthredirurlinclude_Internalname));
            AssignAttri(sPrefix, false, "AV92AuthRedirURLInclude", AV92AuthRedirURLInclude);
            AV5AuthAdditionalParameters = cgiGet( edtavAuthadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV5AuthAdditionalParameters", AV5AuthAdditionalParameters);
            AV6AuthAdditionalParametersSD = cgiGet( edtavAuthadditionalparameterssd_Internalname);
            AssignAttri(sPrefix, false, "AV6AuthAdditionalParametersSD", AV6AuthAdditionalParametersSD);
            AV12AuthResponseAccessCodeTag = cgiGet( edtavAuthresponseaccesscodetag_Internalname);
            AssignAttri(sPrefix, false, "AV12AuthResponseAccessCodeTag", AV12AuthResponseAccessCodeTag);
            AV13AuthResponseErrorDescTag = cgiGet( edtavAuthresponseerrordesctag_Internalname);
            AssignAttri(sPrefix, false, "AV13AuthResponseErrorDescTag", AV13AuthResponseErrorDescTag);
            AV56TokenURL = cgiGet( edtavTokenurl_Internalname);
            AssignAttri(sPrefix, false, "AV56TokenURL", AV56TokenURL);
            cmbavTokenmethod.CurrentValue = cgiGet( cmbavTokenmethod_Internalname);
            AV46TokenMethod = cgiGet( cmbavTokenmethod_Internalname);
            AssignAttri(sPrefix, false, "AV46TokenMethod", AV46TokenMethod);
            AV44TokenHeaderKeyTag = cgiGet( edtavTokenheaderkeytag_Internalname);
            AssignAttri(sPrefix, false, "AV44TokenHeaderKeyTag", AV44TokenHeaderKeyTag);
            AV45TokenHeaderKeyValue = cgiGet( edtavTokenheaderkeyvalue_Internalname);
            AssignAttri(sPrefix, false, "AV45TokenHeaderKeyValue", AV45TokenHeaderKeyValue);
            AV41TokenGrantTypeInclude = StringUtil.StrToBool( cgiGet( chkavTokengranttypeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV41TokenGrantTypeInclude", AV41TokenGrantTypeInclude);
            AV42TokenGrantTypeTag = cgiGet( edtavTokengranttypetag_Internalname);
            AssignAttri(sPrefix, false, "AV42TokenGrantTypeTag", AV42TokenGrantTypeTag);
            AV43TokenGrantTypeValue = cgiGet( edtavTokengranttypevalue_Internalname);
            AssignAttri(sPrefix, false, "AV43TokenGrantTypeValue", AV43TokenGrantTypeValue);
            AV37TokenAccessCodeInclude = StringUtil.StrToBool( cgiGet( chkavTokenaccesscodeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV37TokenAccessCodeInclude", AV37TokenAccessCodeInclude);
            AV39TokenCliIdInclude = StringUtil.StrToBool( cgiGet( chkavTokencliidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV39TokenCliIdInclude", AV39TokenCliIdInclude);
            AV40TokenCliSecretInclude = StringUtil.StrToBool( cgiGet( chkavTokenclisecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV40TokenCliSecretInclude", AV40TokenCliSecretInclude);
            AV47TokenRedirectURLInclude = StringUtil.StrToBool( cgiGet( chkavTokenredirecturlinclude_Internalname));
            AssignAttri(sPrefix, false, "AV47TokenRedirectURLInclude", AV47TokenRedirectURLInclude);
            AV38TokenAdditionalParameters = cgiGet( edtavTokenadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV38TokenAdditionalParameters", AV38TokenAdditionalParameters);
            AV49TokenResponseAccessTokenTag = cgiGet( edtavTokenresponseaccesstokentag_Internalname);
            AssignAttri(sPrefix, false, "AV49TokenResponseAccessTokenTag", AV49TokenResponseAccessTokenTag);
            AV54TokenResponseTokenTypeTag = cgiGet( edtavTokenresponsetokentypetag_Internalname);
            AssignAttri(sPrefix, false, "AV54TokenResponseTokenTypeTag", AV54TokenResponseTokenTypeTag);
            AV51TokenResponseExpiresInTag = cgiGet( edtavTokenresponseexpiresintag_Internalname);
            AssignAttri(sPrefix, false, "AV51TokenResponseExpiresInTag", AV51TokenResponseExpiresInTag);
            AV53TokenResponseScopeTag = cgiGet( edtavTokenresponsescopetag_Internalname);
            AssignAttri(sPrefix, false, "AV53TokenResponseScopeTag", AV53TokenResponseScopeTag);
            AV55TokenResponseUserIdTag = cgiGet( edtavTokenresponseuseridtag_Internalname);
            AssignAttri(sPrefix, false, "AV55TokenResponseUserIdTag", AV55TokenResponseUserIdTag);
            AV52TokenResponseRefreshTokenTag = cgiGet( edtavTokenresponserefreshtokentag_Internalname);
            AssignAttri(sPrefix, false, "AV52TokenResponseRefreshTokenTag", AV52TokenResponseRefreshTokenTag);
            AV50TokenResponseErrorDescriptionTag = cgiGet( edtavTokenresponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV50TokenResponseErrorDescriptionTag", AV50TokenResponseErrorDescriptionTag);
            AV21AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( cgiGet( chkavAutovalidateexternaltokenandrefresh_Internalname));
            AssignAttri(sPrefix, false, "AV21AutovalidateExternalTokenAndRefresh", AV21AutovalidateExternalTokenAndRefresh);
            AV48TokenRefreshTokenURL = cgiGet( edtavTokenrefreshtokenurl_Internalname);
            AssignAttri(sPrefix, false, "AV48TokenRefreshTokenURL", AV48TokenRefreshTokenURL);
            AV83UserInfoURL = cgiGet( edtavUserinfourl_Internalname);
            AssignAttri(sPrefix, false, "AV83UserInfoURL", AV83UserInfoURL);
            cmbavUserinfomethod.CurrentValue = cgiGet( cmbavUserinfomethod_Internalname);
            AV67UserInfoMethod = cgiGet( cmbavUserinfomethod_Internalname);
            AssignAttri(sPrefix, false, "AV67UserInfoMethod", AV67UserInfoMethod);
            AV65UserInfoHeaderKeyTag = cgiGet( edtavUserinfoheaderkeytag_Internalname);
            AssignAttri(sPrefix, false, "AV65UserInfoHeaderKeyTag", AV65UserInfoHeaderKeyTag);
            AV66UserInfoHeaderKeyValue = cgiGet( edtavUserinfoheaderkeyvalue_Internalname);
            AssignAttri(sPrefix, false, "AV66UserInfoHeaderKeyValue", AV66UserInfoHeaderKeyValue);
            AV58UserInfoAccessTokenInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoaccesstokeninclude_Internalname));
            AssignAttri(sPrefix, false, "AV58UserInfoAccessTokenInclude", AV58UserInfoAccessTokenInclude);
            AV59UserInfoAccessTokenName = cgiGet( edtavUserinfoaccesstokenname_Internalname);
            AssignAttri(sPrefix, false, "AV59UserInfoAccessTokenName", AV59UserInfoAccessTokenName);
            AV61UserInfoClientIdInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoclientidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV61UserInfoClientIdInclude", AV61UserInfoClientIdInclude);
            AV62UserInfoClientIdName = cgiGet( edtavUserinfoclientidname_Internalname);
            AssignAttri(sPrefix, false, "AV62UserInfoClientIdName", AV62UserInfoClientIdName);
            AV63UserInfoClientSecretInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoclientsecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV63UserInfoClientSecretInclude", AV63UserInfoClientSecretInclude);
            AV64UserInfoClientSecretName = cgiGet( edtavUserinfoclientsecretname_Internalname);
            AssignAttri(sPrefix, false, "AV64UserInfoClientSecretName", AV64UserInfoClientSecretName);
            AV84UserInfoUserIdInclude = StringUtil.StrToBool( cgiGet( chkavUserinfouseridinclude_Internalname));
            AssignAttri(sPrefix, false, "AV84UserInfoUserIdInclude", AV84UserInfoUserIdInclude);
            AV60UserInfoAdditionalParameters = cgiGet( edtavUserinfoadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV60UserInfoAdditionalParameters", AV60UserInfoAdditionalParameters);
            AV70UserInfoResponseUserEmailTag = cgiGet( edtavUserinforesponseuseremailtag_Internalname);
            AssignAttri(sPrefix, false, "AV70UserInfoResponseUserEmailTag", AV70UserInfoResponseUserEmailTag);
            AV82UserInfoResponseUserVerifiedEmailTag = cgiGet( edtavUserinforesponseuserverifiedemailtag_Internalname);
            AssignAttri(sPrefix, false, "AV82UserInfoResponseUserVerifiedEmailTag", AV82UserInfoResponseUserVerifiedEmailTag);
            AV71UserInfoResponseUserExternalIdTag = cgiGet( edtavUserinforesponseuserexternalidtag_Internalname);
            AssignAttri(sPrefix, false, "AV71UserInfoResponseUserExternalIdTag", AV71UserInfoResponseUserExternalIdTag);
            AV78UserInfoResponseUserNameTag = cgiGet( edtavUserinforesponseusernametag_Internalname);
            AssignAttri(sPrefix, false, "AV78UserInfoResponseUserNameTag", AV78UserInfoResponseUserNameTag);
            AV72UserInfoResponseUserFirstNameTag = cgiGet( edtavUserinforesponseuserfirstnametag_Internalname);
            AssignAttri(sPrefix, false, "AV72UserInfoResponseUserFirstNameTag", AV72UserInfoResponseUserFirstNameTag);
            AV76UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( cgiGet( chkavUserinforesponseuserlastnamegenauto_Internalname));
            AssignAttri(sPrefix, false, "AV76UserInfoResponseUserLastNameGenAuto", AV76UserInfoResponseUserLastNameGenAuto);
            AV77UserInfoResponseUserLastNameTag = cgiGet( edtavUserinforesponseuserlastnametag_Internalname);
            AssignAttri(sPrefix, false, "AV77UserInfoResponseUserLastNameTag", AV77UserInfoResponseUserLastNameTag);
            AV73UserInfoResponseUserGenderTag = cgiGet( edtavUserinforesponseusergendertag_Internalname);
            AssignAttri(sPrefix, false, "AV73UserInfoResponseUserGenderTag", AV73UserInfoResponseUserGenderTag);
            AV74UserInfoResponseUserGenderValues = cgiGet( edtavUserinforesponseusergendervalues_Internalname);
            AssignAttri(sPrefix, false, "AV74UserInfoResponseUserGenderValues", AV74UserInfoResponseUserGenderValues);
            AV69UserInfoResponseUserBirthdayTag = cgiGet( edtavUserinforesponseuserbirthdaytag_Internalname);
            AssignAttri(sPrefix, false, "AV69UserInfoResponseUserBirthdayTag", AV69UserInfoResponseUserBirthdayTag);
            AV80UserInfoResponseUserURLImageTag = cgiGet( edtavUserinforesponseuserurlimagetag_Internalname);
            AssignAttri(sPrefix, false, "AV80UserInfoResponseUserURLImageTag", AV80UserInfoResponseUserURLImageTag);
            AV81UserInfoResponseUserURLProfileTag = cgiGet( edtavUserinforesponseuserurlprofiletag_Internalname);
            AssignAttri(sPrefix, false, "AV81UserInfoResponseUserURLProfileTag", AV81UserInfoResponseUserURLProfileTag);
            AV75UserInfoResponseUserLanguageTag = cgiGet( edtavUserinforesponseuserlanguagetag_Internalname);
            AssignAttri(sPrefix, false, "AV75UserInfoResponseUserLanguageTag", AV75UserInfoResponseUserLanguageTag);
            AV79UserInfoResponseUserTimeZoneTag = cgiGet( edtavUserinforesponseusertimezonetag_Internalname);
            AssignAttri(sPrefix, false, "AV79UserInfoResponseUserTimeZoneTag", AV79UserInfoResponseUserTimeZoneTag);
            AV68UserInfoResponseErrorDescriptionTag = cgiGet( edtavUserinforesponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV68UserInfoResponseErrorDescriptionTag", AV68UserInfoResponseErrorDescriptionTag);
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
         E11112 ();
         if (returnInSub) return;
      }

      protected void E11112( )
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
            AV26FunctionId = "OnlyAuthentication";
            AssignAttri(sPrefix, false, "AV26FunctionId", AV26FunctionId);
            /* Execute user subroutine: 'INITAUTHENTICATIONOAUTH20' */
            S112 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnenter_Visible = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
            chkavIsenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavIsenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenable.Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavSmallimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavSmallimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSmallimagename_Enabled), 5, 0), true);
            edtavBigimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavBigimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBigimagename_Enabled), 5, 0), true);
            edtavImpersonate_Enabled = 0;
            AssignProp(sPrefix, false, edtavImpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavImpersonate_Enabled), 5, 0), true);
            bttBtnenter_Caption = "Delete";
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
         }
         /* Execute user subroutine: 'REFRESHAUTHENTICATIONTYPE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! AV76UserInfoResponseUserLastNameGenAuto ) )
         {
            edtavUserinforesponseuserlastnametag_Visible = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            divUserinforesponseuserlastnametag_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divUserinforesponseuserlastnametag_cell_Internalname, "Class", divUserinforesponseuserlastnametag_cell_Class, true);
         }
         else
         {
            edtavUserinforesponseuserlastnametag_Visible = 1;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            divUserinforesponseuserlastnametag_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp(sPrefix, false, divUserinforesponseuserlastnametag_cell_Internalname, "Class", divUserinforesponseuserlastnametag_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12112 ();
         if (returnInSub) return;
      }

      protected void E12112( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'SAVEAUTHENTICATIONOAUTH20' */
            S142 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV9AuthenticationTypeOauth20.load( AV29Name);
            AV9AuthenticationTypeOauth20.delete();
         }
         if ( AV9AuthenticationTypeOauth20.success() )
         {
            context.CommitDataStores("gamwcauthenticationtypeentryoauth20",pr_default);
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV29Name,(string)AV57TypeId});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV29Name","AV57TypeId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         AV25Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV25Errors.Count )
         {
            AV24Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV25Errors.Item(AV97GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV24Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV24Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9AuthenticationTypeOauth20", AV9AuthenticationTypeOauth20);
      }

      protected void S122( )
      {
         /* 'REFRESHAUTHENTICATIONTYPE' Routine */
         returnInSub = false;
         AV26FunctionId = "OnlyAuthentication";
         AssignAttri(sPrefix, false, "AV26FunctionId", AV26FunctionId);
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'INITAUTHENTICATIONOAUTH20' Routine */
         returnInSub = false;
         AV9AuthenticationTypeOauth20.load( AV29Name);
         AV29Name = AV9AuthenticationTypeOauth20.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV28IsEnable = AV9AuthenticationTypeOauth20.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV28IsEnable", AV28IsEnable);
         AV23Dsc = AV9AuthenticationTypeOauth20.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV23Dsc", AV23Dsc);
         AV36SmallImageName = AV9AuthenticationTypeOauth20.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV36SmallImageName", AV36SmallImageName);
         AV22BigImageName = AV9AuthenticationTypeOauth20.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV22BigImageName", AV22BigImageName);
         AV27Impersonate = AV9AuthenticationTypeOauth20.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV27Impersonate", AV27Impersonate);
         AV30Oauth20ClientIdTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_name;
         AssignAttri(sPrefix, false, "AV30Oauth20ClientIdTag", AV30Oauth20ClientIdTag);
         AV31Oauth20ClientIdValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_value;
         AssignAttri(sPrefix, false, "AV31Oauth20ClientIdValue", AV31Oauth20ClientIdValue);
         AV32Oauth20ClientSecretTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_name;
         AssignAttri(sPrefix, false, "AV32Oauth20ClientSecretTag", AV32Oauth20ClientSecretTag);
         AV33Oauth20ClientSecretValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_value;
         AssignAttri(sPrefix, false, "AV33Oauth20ClientSecretValue", AV33Oauth20ClientSecretValue);
         AV34Oauth20RedirectURLTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_name;
         AssignAttri(sPrefix, false, "AV34Oauth20RedirectURLTag", AV34Oauth20RedirectURLTag);
         AV35Oauth20RedirectURLvalue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_value;
         AssignAttri(sPrefix, false, "AV35Oauth20RedirectURLvalue", AV35Oauth20RedirectURLvalue);
         AV10AuthorizeURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV10AuthorizeURL", AV10AuthorizeURL);
         AV14AuthRespTypeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Redirecturl_include;
         AssignAttri(sPrefix, false, "AV14AuthRespTypeInclude", AV14AuthRespTypeInclude);
         AV15AuthRespTypeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_name;
         AssignAttri(sPrefix, false, "AV15AuthRespTypeTag", AV15AuthRespTypeTag);
         AV16AuthRespTypeValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_value;
         AssignAttri(sPrefix, false, "AV16AuthRespTypeValue", AV16AuthRespTypeValue);
         AV17AuthScopeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_include;
         AssignAttri(sPrefix, false, "AV17AuthScopeInclude", AV17AuthScopeInclude);
         AV18AuthScopeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_name;
         AssignAttri(sPrefix, false, "AV18AuthScopeTag", AV18AuthScopeTag);
         AV19AuthScopeValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_value;
         AssignAttri(sPrefix, false, "AV19AuthScopeValue", AV19AuthScopeValue);
         AV91AuthStateInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_include;
         AssignAttri(sPrefix, false, "AV91AuthStateInclude", AV91AuthStateInclude);
         AV20AuthStateTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_name;
         AssignAttri(sPrefix, false, "AV20AuthStateTag", AV20AuthStateTag);
         AV7AuthClientIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV7AuthClientIdInclude", AV7AuthClientIdInclude);
         AV8AuthClientSecretInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV8AuthClientSecretInclude", AV8AuthClientSecretInclude);
         AV92AuthRedirURLInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Redirecturl_include;
         AssignAttri(sPrefix, false, "AV92AuthRedirURLInclude", AV92AuthRedirURLInclude);
         AV5AuthAdditionalParameters = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV5AuthAdditionalParameters", AV5AuthAdditionalParameters);
         AV6AuthAdditionalParametersSD = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparametersnativesd;
         AssignAttri(sPrefix, false, "AV6AuthAdditionalParametersSD", AV6AuthAdditionalParametersSD);
         AV12AuthResponseAccessCodeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseaccesscode_name;
         AssignAttri(sPrefix, false, "AV12AuthResponseAccessCodeTag", AV12AuthResponseAccessCodeTag);
         AV13AuthResponseErrorDescTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV13AuthResponseErrorDescTag", AV13AuthResponseErrorDescTag);
         AV56TokenURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV56TokenURL", AV56TokenURL);
         AV46TokenMethod = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Method;
         AssignAttri(sPrefix, false, "AV46TokenMethod", AV46TokenMethod);
         AV44TokenHeaderKeyTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_key;
         AssignAttri(sPrefix, false, "AV44TokenHeaderKeyTag", AV44TokenHeaderKeyTag);
         AV45TokenHeaderKeyValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_value;
         AssignAttri(sPrefix, false, "AV45TokenHeaderKeyValue", AV45TokenHeaderKeyValue);
         AV41TokenGrantTypeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_include;
         AssignAttri(sPrefix, false, "AV41TokenGrantTypeInclude", AV41TokenGrantTypeInclude);
         AV42TokenGrantTypeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_name;
         AssignAttri(sPrefix, false, "AV42TokenGrantTypeTag", AV42TokenGrantTypeTag);
         AV43TokenGrantTypeValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_value;
         AssignAttri(sPrefix, false, "AV43TokenGrantTypeValue", AV43TokenGrantTypeValue);
         AV37TokenAccessCodeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Accesscode_include;
         AssignAttri(sPrefix, false, "AV37TokenAccessCodeInclude", AV37TokenAccessCodeInclude);
         AV39TokenCliIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV39TokenCliIdInclude", AV39TokenCliIdInclude);
         AV40TokenCliSecretInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV40TokenCliSecretInclude", AV40TokenCliSecretInclude);
         AV47TokenRedirectURLInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Redirecturl_include;
         AssignAttri(sPrefix, false, "AV47TokenRedirectURLInclude", AV47TokenRedirectURLInclude);
         AV38TokenAdditionalParameters = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV38TokenAdditionalParameters", AV38TokenAdditionalParameters);
         AV49TokenResponseAccessTokenTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseaccesstoken_name;
         AssignAttri(sPrefix, false, "AV49TokenResponseAccessTokenTag", AV49TokenResponseAccessTokenTag);
         AV54TokenResponseTokenTypeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsetokentype_name;
         AssignAttri(sPrefix, false, "AV54TokenResponseTokenTypeTag", AV54TokenResponseTokenTypeTag);
         AV51TokenResponseExpiresInTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseexpiresin_name;
         AssignAttri(sPrefix, false, "AV51TokenResponseExpiresInTag", AV51TokenResponseExpiresInTag);
         AV53TokenResponseScopeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsescope_name;
         AssignAttri(sPrefix, false, "AV53TokenResponseScopeTag", AV53TokenResponseScopeTag);
         AV55TokenResponseUserIdTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseuserid_name;
         AssignAttri(sPrefix, false, "AV55TokenResponseUserIdTag", AV55TokenResponseUserIdTag);
         AV52TokenResponseRefreshTokenTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responserefreshtoken_name;
         AssignAttri(sPrefix, false, "AV52TokenResponseRefreshTokenTag", AV52TokenResponseRefreshTokenTag);
         AV50TokenResponseErrorDescriptionTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV50TokenResponseErrorDescriptionTag", AV50TokenResponseErrorDescriptionTag);
         AV21AutovalidateExternalTokenAndRefresh = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Autovalidateexternaltokenandrefresh;
         AssignAttri(sPrefix, false, "AV21AutovalidateExternalTokenAndRefresh", AV21AutovalidateExternalTokenAndRefresh);
         AV48TokenRefreshTokenURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Refreshtoken_url;
         AssignAttri(sPrefix, false, "AV48TokenRefreshTokenURL", AV48TokenRefreshTokenURL);
         AV83UserInfoURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV83UserInfoURL", AV83UserInfoURL);
         AV67UserInfoMethod = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Method;
         AssignAttri(sPrefix, false, "AV67UserInfoMethod", AV67UserInfoMethod);
         AV65UserInfoHeaderKeyTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_key;
         AssignAttri(sPrefix, false, "AV65UserInfoHeaderKeyTag", AV65UserInfoHeaderKeyTag);
         AV66UserInfoHeaderKeyValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_value;
         AssignAttri(sPrefix, false, "AV66UserInfoHeaderKeyValue", AV66UserInfoHeaderKeyValue);
         AV58UserInfoAccessTokenInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_include;
         AssignAttri(sPrefix, false, "AV58UserInfoAccessTokenInclude", AV58UserInfoAccessTokenInclude);
         AV59UserInfoAccessTokenName = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_name;
         AssignAttri(sPrefix, false, "AV59UserInfoAccessTokenName", AV59UserInfoAccessTokenName);
         AV61UserInfoClientIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV61UserInfoClientIdInclude", AV61UserInfoClientIdInclude);
         AV62UserInfoClientIdName = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_name;
         AssignAttri(sPrefix, false, "AV62UserInfoClientIdName", AV62UserInfoClientIdName);
         AV63UserInfoClientSecretInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV63UserInfoClientSecretInclude", AV63UserInfoClientSecretInclude);
         AV64UserInfoClientSecretName = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_name;
         AssignAttri(sPrefix, false, "AV64UserInfoClientSecretName", AV64UserInfoClientSecretName);
         AV84UserInfoUserIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Userid_include;
         AssignAttri(sPrefix, false, "AV84UserInfoUserIdInclude", AV84UserInfoUserIdInclude);
         AV60UserInfoAdditionalParameters = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV60UserInfoAdditionalParameters", AV60UserInfoAdditionalParameters);
         AV70UserInfoResponseUserEmailTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuseremail_name;
         AssignAttri(sPrefix, false, "AV70UserInfoResponseUserEmailTag", AV70UserInfoResponseUserEmailTag);
         AV82UserInfoResponseUserVerifiedEmailTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserverifiedemail_name;
         AssignAttri(sPrefix, false, "AV82UserInfoResponseUserVerifiedEmailTag", AV82UserInfoResponseUserVerifiedEmailTag);
         AV71UserInfoResponseUserExternalIdTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name;
         AssignAttri(sPrefix, false, "AV71UserInfoResponseUserExternalIdTag", AV71UserInfoResponseUserExternalIdTag);
         AV78UserInfoResponseUserNameTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusername_name;
         AssignAttri(sPrefix, false, "AV78UserInfoResponseUserNameTag", AV78UserInfoResponseUserNameTag);
         AV72UserInfoResponseUserFirstNameTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name;
         AssignAttri(sPrefix, false, "AV72UserInfoResponseUserFirstNameTag", AV72UserInfoResponseUserFirstNameTag);
         AV76UserInfoResponseUserLastNameGenAuto = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic;
         AssignAttri(sPrefix, false, "AV76UserInfoResponseUserLastNameGenAuto", AV76UserInfoResponseUserLastNameGenAuto);
         AV77UserInfoResponseUserLastNameTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name;
         AssignAttri(sPrefix, false, "AV77UserInfoResponseUserLastNameTag", AV77UserInfoResponseUserLastNameTag);
         AV73UserInfoResponseUserGenderTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_name;
         AssignAttri(sPrefix, false, "AV73UserInfoResponseUserGenderTag", AV73UserInfoResponseUserGenderTag);
         AV74UserInfoResponseUserGenderValues = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_values;
         AssignAttri(sPrefix, false, "AV74UserInfoResponseUserGenderValues", AV74UserInfoResponseUserGenderValues);
         AV69UserInfoResponseUserBirthdayTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name;
         AssignAttri(sPrefix, false, "AV69UserInfoResponseUserBirthdayTag", AV69UserInfoResponseUserBirthdayTag);
         AV80UserInfoResponseUserURLImageTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name;
         AssignAttri(sPrefix, false, "AV80UserInfoResponseUserURLImageTag", AV80UserInfoResponseUserURLImageTag);
         AV81UserInfoResponseUserURLProfileTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name;
         AssignAttri(sPrefix, false, "AV81UserInfoResponseUserURLProfileTag", AV81UserInfoResponseUserURLProfileTag);
         AV75UserInfoResponseUserLanguageTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name;
         AssignAttri(sPrefix, false, "AV75UserInfoResponseUserLanguageTag", AV75UserInfoResponseUserLanguageTag);
         AV79UserInfoResponseUserTimeZoneTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name;
         AssignAttri(sPrefix, false, "AV79UserInfoResponseUserTimeZoneTag", AV79UserInfoResponseUserTimeZoneTag);
         AV68UserInfoResponseErrorDescriptionTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV68UserInfoResponseErrorDescriptionTag", AV68UserInfoResponseErrorDescriptionTag);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV9AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         }
      }

      protected void S142( )
      {
         /* 'SAVEAUTHENTICATIONOAUTH20' Routine */
         returnInSub = false;
         AV9AuthenticationTypeOauth20.load( AV29Name);
         AV9AuthenticationTypeOauth20.gxTpr_Name = AV29Name;
         AV9AuthenticationTypeOauth20.gxTpr_Isenable = AV28IsEnable;
         AV9AuthenticationTypeOauth20.gxTpr_Description = AV23Dsc;
         AV9AuthenticationTypeOauth20.gxTpr_Smallimagename = AV36SmallImageName;
         AV9AuthenticationTypeOauth20.gxTpr_Bigimagename = AV22BigImageName;
         AV9AuthenticationTypeOauth20.gxTpr_Impersonate = AV27Impersonate;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_name = AV30Oauth20ClientIdTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_value = AV31Oauth20ClientIdValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_name = AV32Oauth20ClientSecretTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_value = AV33Oauth20ClientSecretValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_name = AV34Oauth20RedirectURLTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_value = AV35Oauth20RedirectURLvalue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Url = AV10AuthorizeURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_include = AV14AuthRespTypeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_name = AV15AuthRespTypeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_value = AV16AuthRespTypeValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_include = AV17AuthScopeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_name = AV18AuthScopeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_value = AV19AuthScopeValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_include = AV91AuthStateInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_name = AV20AuthStateTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientid_include = AV7AuthClientIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientsecret_include = AV8AuthClientSecretInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Redirecturl_include = AV92AuthRedirURLInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparameters = AV5AuthAdditionalParameters;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparametersnativesd = AV6AuthAdditionalParametersSD;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseaccesscode_name = AV12AuthResponseAccessCodeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseerrordescription_name = AV13AuthResponseErrorDescTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Url = AV56TokenURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Method = AV46TokenMethod;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_key = AV44TokenHeaderKeyTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_value = AV45TokenHeaderKeyValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_include = AV41TokenGrantTypeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_name = AV42TokenGrantTypeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_value = AV43TokenGrantTypeValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Accesscode_include = AV37TokenAccessCodeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientid_include = AV39TokenCliIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientsecret_include = AV40TokenCliSecretInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Redirecturl_include = AV47TokenRedirectURLInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Additionalparameters = AV38TokenAdditionalParameters;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseaccesstoken_name = AV49TokenResponseAccessTokenTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsetokentype_name = AV54TokenResponseTokenTypeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseexpiresin_name = AV51TokenResponseExpiresInTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsescope_name = AV53TokenResponseScopeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseuserid_name = AV55TokenResponseUserIdTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responserefreshtoken_name = AV52TokenResponseRefreshTokenTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseerrordescription_name = AV50TokenResponseErrorDescriptionTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Autovalidateexternaltokenandrefresh = AV21AutovalidateExternalTokenAndRefresh;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Autovalidateexternaltokenandrefresh = AV21AutovalidateExternalTokenAndRefresh;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Refreshtoken_url = AV48TokenRefreshTokenURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Url = AV83UserInfoURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Method = AV67UserInfoMethod;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_key = AV65UserInfoHeaderKeyTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_value = AV66UserInfoHeaderKeyValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_include = AV58UserInfoAccessTokenInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_name = AV59UserInfoAccessTokenName;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_include = AV61UserInfoClientIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_name = AV62UserInfoClientIdName;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_include = AV63UserInfoClientSecretInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_name = AV64UserInfoClientSecretName;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Userid_include = AV84UserInfoUserIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Additionalparameters = AV60UserInfoAdditionalParameters;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuseremail_name = AV70UserInfoResponseUserEmailTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserverifiedemail_name = AV82UserInfoResponseUserVerifiedEmailTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name = AV71UserInfoResponseUserExternalIdTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusername_name = AV78UserInfoResponseUserNameTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name = AV72UserInfoResponseUserFirstNameTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic = AV76UserInfoResponseUserLastNameGenAuto;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name = AV77UserInfoResponseUserLastNameTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_name = AV73UserInfoResponseUserGenderTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_values = AV74UserInfoResponseUserGenderValues;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name = AV69UserInfoResponseUserBirthdayTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name = AV80UserInfoResponseUserURLImageTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name = AV81UserInfoResponseUserURLProfileTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name = AV75UserInfoResponseUserLanguageTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name = AV79UserInfoResponseUserTimeZoneTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name = AV68UserInfoResponseErrorDescriptionTag;
         AV9AuthenticationTypeOauth20.save();
      }

      protected void nextLoad( )
      {
      }

      protected void E13112( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV29Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         AV57TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV57TypeId", AV57TypeId);
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
         PA112( ) ;
         WS112( ) ;
         WE112( ) ;
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
         sCtrlAV29Name = (string)((string)getParm(obj,1));
         sCtrlAV57TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA112( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "gamwcauthenticationtypeentryoauth20", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA112( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV29Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV29Name", AV29Name);
            AV57TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV57TypeId", AV57TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV29Name = cgiGet( sPrefix+"wcpOAV29Name");
         wcpOAV57TypeId = cgiGet( sPrefix+"wcpOAV57TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV29Name, wcpOAV29Name) != 0 ) || ( StringUtil.StrCmp(AV57TypeId, wcpOAV57TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV29Name = AV29Name;
         wcpOAV57TypeId = AV57TypeId;
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
         sCtrlAV29Name = cgiGet( sPrefix+"AV29Name_CTRL");
         if ( StringUtil.Len( sCtrlAV29Name) > 0 )
         {
            AV29Name = cgiGet( sCtrlAV29Name);
            AssignAttri(sPrefix, false, "AV29Name", AV29Name);
         }
         else
         {
            AV29Name = cgiGet( sPrefix+"AV29Name_PARM");
         }
         sCtrlAV57TypeId = cgiGet( sPrefix+"AV57TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV57TypeId) > 0 )
         {
            AV57TypeId = cgiGet( sCtrlAV57TypeId);
            AssignAttri(sPrefix, false, "AV57TypeId", AV57TypeId);
         }
         else
         {
            AV57TypeId = cgiGet( sPrefix+"AV57TypeId_PARM");
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
         PA112( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS112( ) ;
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
         WS112( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV29Name_PARM", StringUtil.RTrim( AV29Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29Name_CTRL", StringUtil.RTrim( sCtrlAV29Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV57TypeId_PARM", StringUtil.RTrim( AV57TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV57TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV57TypeId_CTRL", StringUtil.RTrim( sCtrlAV57TypeId));
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
         WE112( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815482922", true, true);
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
         context.AddJavascriptSource("gamwcauthenticationtypeentryoauth20.js", "?202142815482933", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         chkavAuthresptypeinclude.Name = "vAUTHRESPTYPEINCLUDE";
         chkavAuthresptypeinclude.WebTags = "";
         chkavAuthresptypeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthresptypeinclude_Internalname, "TitleCaption", chkavAuthresptypeinclude.Caption, true);
         chkavAuthresptypeinclude.CheckedValue = "false";
         chkavAuthscopeinclude.Name = "vAUTHSCOPEINCLUDE";
         chkavAuthscopeinclude.WebTags = "";
         chkavAuthscopeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthscopeinclude_Internalname, "TitleCaption", chkavAuthscopeinclude.Caption, true);
         chkavAuthscopeinclude.CheckedValue = "false";
         chkavAuthstateinclude.Name = "vAUTHSTATEINCLUDE";
         chkavAuthstateinclude.WebTags = "";
         chkavAuthstateinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthstateinclude_Internalname, "TitleCaption", chkavAuthstateinclude.Caption, true);
         chkavAuthstateinclude.CheckedValue = "false";
         chkavAuthclientidinclude.Name = "vAUTHCLIENTIDINCLUDE";
         chkavAuthclientidinclude.WebTags = "";
         chkavAuthclientidinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthclientidinclude_Internalname, "TitleCaption", chkavAuthclientidinclude.Caption, true);
         chkavAuthclientidinclude.CheckedValue = "false";
         chkavAuthclientsecretinclude.Name = "vAUTHCLIENTSECRETINCLUDE";
         chkavAuthclientsecretinclude.WebTags = "";
         chkavAuthclientsecretinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthclientsecretinclude_Internalname, "TitleCaption", chkavAuthclientsecretinclude.Caption, true);
         chkavAuthclientsecretinclude.CheckedValue = "false";
         chkavAuthredirurlinclude.Name = "vAUTHREDIRURLINCLUDE";
         chkavAuthredirurlinclude.WebTags = "";
         chkavAuthredirurlinclude.Caption = "";
         AssignProp(sPrefix, false, chkavAuthredirurlinclude_Internalname, "TitleCaption", chkavAuthredirurlinclude.Caption, true);
         chkavAuthredirurlinclude.CheckedValue = "false";
         cmbavTokenmethod.Name = "vTOKENMETHOD";
         cmbavTokenmethod.WebTags = "";
         cmbavTokenmethod.addItem("POST", "POST", 0);
         cmbavTokenmethod.addItem("GET", "GET", 0);
         if ( cmbavTokenmethod.ItemCount > 0 )
         {
         }
         chkavTokengranttypeinclude.Name = "vTOKENGRANTTYPEINCLUDE";
         chkavTokengranttypeinclude.WebTags = "";
         chkavTokengranttypeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokengranttypeinclude_Internalname, "TitleCaption", chkavTokengranttypeinclude.Caption, true);
         chkavTokengranttypeinclude.CheckedValue = "false";
         chkavTokenaccesscodeinclude.Name = "vTOKENACCESSCODEINCLUDE";
         chkavTokenaccesscodeinclude.WebTags = "";
         chkavTokenaccesscodeinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenaccesscodeinclude_Internalname, "TitleCaption", chkavTokenaccesscodeinclude.Caption, true);
         chkavTokenaccesscodeinclude.CheckedValue = "false";
         chkavTokencliidinclude.Name = "vTOKENCLIIDINCLUDE";
         chkavTokencliidinclude.WebTags = "";
         chkavTokencliidinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokencliidinclude_Internalname, "TitleCaption", chkavTokencliidinclude.Caption, true);
         chkavTokencliidinclude.CheckedValue = "false";
         chkavTokenclisecretinclude.Name = "vTOKENCLISECRETINCLUDE";
         chkavTokenclisecretinclude.WebTags = "";
         chkavTokenclisecretinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenclisecretinclude_Internalname, "TitleCaption", chkavTokenclisecretinclude.Caption, true);
         chkavTokenclisecretinclude.CheckedValue = "false";
         chkavTokenredirecturlinclude.Name = "vTOKENREDIRECTURLINCLUDE";
         chkavTokenredirecturlinclude.WebTags = "";
         chkavTokenredirecturlinclude.Caption = "";
         AssignProp(sPrefix, false, chkavTokenredirecturlinclude_Internalname, "TitleCaption", chkavTokenredirecturlinclude.Caption, true);
         chkavTokenredirecturlinclude.CheckedValue = "false";
         chkavAutovalidateexternaltokenandrefresh.Name = "vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         chkavAutovalidateexternaltokenandrefresh.WebTags = "";
         chkavAutovalidateexternaltokenandrefresh.Caption = "";
         AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "TitleCaption", chkavAutovalidateexternaltokenandrefresh.Caption, true);
         chkavAutovalidateexternaltokenandrefresh.CheckedValue = "false";
         cmbavUserinfomethod.Name = "vUSERINFOMETHOD";
         cmbavUserinfomethod.WebTags = "";
         cmbavUserinfomethod.addItem("POST", "POST", 0);
         cmbavUserinfomethod.addItem("GET", "GET", 0);
         if ( cmbavUserinfomethod.ItemCount > 0 )
         {
         }
         chkavUserinfoaccesstokeninclude.Name = "vUSERINFOACCESSTOKENINCLUDE";
         chkavUserinfoaccesstokeninclude.WebTags = "";
         chkavUserinfoaccesstokeninclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfoaccesstokeninclude_Internalname, "TitleCaption", chkavUserinfoaccesstokeninclude.Caption, true);
         chkavUserinfoaccesstokeninclude.CheckedValue = "false";
         chkavUserinfoclientidinclude.Name = "vUSERINFOCLIENTIDINCLUDE";
         chkavUserinfoclientidinclude.WebTags = "";
         chkavUserinfoclientidinclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfoclientidinclude_Internalname, "TitleCaption", chkavUserinfoclientidinclude.Caption, true);
         chkavUserinfoclientidinclude.CheckedValue = "false";
         chkavUserinfoclientsecretinclude.Name = "vUSERINFOCLIENTSECRETINCLUDE";
         chkavUserinfoclientsecretinclude.WebTags = "";
         chkavUserinfoclientsecretinclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfoclientsecretinclude_Internalname, "TitleCaption", chkavUserinfoclientsecretinclude.Caption, true);
         chkavUserinfoclientsecretinclude.CheckedValue = "false";
         chkavUserinfouseridinclude.Name = "vUSERINFOUSERIDINCLUDE";
         chkavUserinfouseridinclude.WebTags = "";
         chkavUserinfouseridinclude.Caption = "";
         AssignProp(sPrefix, false, chkavUserinfouseridinclude_Internalname, "TitleCaption", chkavUserinfouseridinclude.Caption, true);
         chkavUserinfouseridinclude.CheckedValue = "false";
         chkavUserinforesponseuserlastnamegenauto.Name = "vUSERINFORESPONSEUSERLASTNAMEGENAUTO";
         chkavUserinforesponseuserlastnamegenauto.WebTags = "";
         chkavUserinforesponseuserlastnamegenauto.Caption = "";
         AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "TitleCaption", chkavUserinforesponseuserlastnamegenauto.Caption, true);
         chkavUserinforesponseuserlastnamegenauto.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavName_Internalname = sPrefix+"vNAME";
         cmbavFunctionid_Internalname = sPrefix+"vFUNCTIONID";
         edtavDsc_Internalname = sPrefix+"vDSC";
         chkavIsenable_Internalname = sPrefix+"vISENABLE";
         edtavAdditionalscope_Internalname = sPrefix+"vADDITIONALSCOPE";
         edtavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         edtavSmallimagename_Internalname = sPrefix+"vSMALLIMAGENAME";
         edtavBigimagename_Internalname = sPrefix+"vBIGIMAGENAME";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         lblGeneral_title_Internalname = sPrefix+"GENERAL_TITLE";
         edtavOauth20clientidtag_Internalname = sPrefix+"vOAUTH20CLIENTIDTAG";
         edtavOauth20clientidvalue_Internalname = sPrefix+"vOAUTH20CLIENTIDVALUE";
         edtavOauth20clientsecrettag_Internalname = sPrefix+"vOAUTH20CLIENTSECRETTAG";
         edtavOauth20clientsecretvalue_Internalname = sPrefix+"vOAUTH20CLIENTSECRETVALUE";
         edtavOauth20redirecturltag_Internalname = sPrefix+"vOAUTH20REDIRECTURLTAG";
         edtavOauth20redirecturlvalue_Internalname = sPrefix+"vOAUTH20REDIRECTURLVALUE";
         divUnnamedtable11_Internalname = sPrefix+"UNNAMEDTABLE11";
         lblAuthorization_title_Internalname = sPrefix+"AUTHORIZATION_TITLE";
         edtavAuthorizeurl_Internalname = sPrefix+"vAUTHORIZEURL";
         chkavAuthresptypeinclude_Internalname = sPrefix+"vAUTHRESPTYPEINCLUDE";
         edtavAuthresptypetag_Internalname = sPrefix+"vAUTHRESPTYPETAG";
         edtavAuthresptypevalue_Internalname = sPrefix+"vAUTHRESPTYPEVALUE";
         chkavAuthscopeinclude_Internalname = sPrefix+"vAUTHSCOPEINCLUDE";
         edtavAuthscopetag_Internalname = sPrefix+"vAUTHSCOPETAG";
         edtavAuthscopevalue_Internalname = sPrefix+"vAUTHSCOPEVALUE";
         chkavAuthstateinclude_Internalname = sPrefix+"vAUTHSTATEINCLUDE";
         edtavAuthstatetag_Internalname = sPrefix+"vAUTHSTATETAG";
         chkavAuthclientidinclude_Internalname = sPrefix+"vAUTHCLIENTIDINCLUDE";
         chkavAuthclientsecretinclude_Internalname = sPrefix+"vAUTHCLIENTSECRETINCLUDE";
         chkavAuthredirurlinclude_Internalname = sPrefix+"vAUTHREDIRURLINCLUDE";
         edtavAuthadditionalparameters_Internalname = sPrefix+"vAUTHADDITIONALPARAMETERS";
         edtavAuthadditionalparameterssd_Internalname = sPrefix+"vAUTHADDITIONALPARAMETERSSD";
         edtavAuthresponseaccesscodetag_Internalname = sPrefix+"vAUTHRESPONSEACCESSCODETAG";
         edtavAuthresponseerrordesctag_Internalname = sPrefix+"vAUTHRESPONSEERRORDESCTAG";
         divUnnamedtable10_Internalname = sPrefix+"UNNAMEDTABLE10";
         Dvpanel_unnamedtable10_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE10";
         divUnnamedtable9_Internalname = sPrefix+"UNNAMEDTABLE9";
         Dvpanel_unnamedtable9_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE9";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         lblToken_title_Internalname = sPrefix+"TOKEN_TITLE";
         edtavTokenurl_Internalname = sPrefix+"vTOKENURL";
         cmbavTokenmethod_Internalname = sPrefix+"vTOKENMETHOD";
         edtavTokenheaderkeytag_Internalname = sPrefix+"vTOKENHEADERKEYTAG";
         edtavTokenheaderkeyvalue_Internalname = sPrefix+"vTOKENHEADERKEYVALUE";
         chkavTokengranttypeinclude_Internalname = sPrefix+"vTOKENGRANTTYPEINCLUDE";
         edtavTokengranttypetag_Internalname = sPrefix+"vTOKENGRANTTYPETAG";
         edtavTokengranttypevalue_Internalname = sPrefix+"vTOKENGRANTTYPEVALUE";
         chkavTokenaccesscodeinclude_Internalname = sPrefix+"vTOKENACCESSCODEINCLUDE";
         chkavTokencliidinclude_Internalname = sPrefix+"vTOKENCLIIDINCLUDE";
         chkavTokenclisecretinclude_Internalname = sPrefix+"vTOKENCLISECRETINCLUDE";
         chkavTokenredirecturlinclude_Internalname = sPrefix+"vTOKENREDIRECTURLINCLUDE";
         edtavTokenadditionalparameters_Internalname = sPrefix+"vTOKENADDITIONALPARAMETERS";
         edtavTokenresponseaccesstokentag_Internalname = sPrefix+"vTOKENRESPONSEACCESSTOKENTAG";
         edtavTokenresponsetokentypetag_Internalname = sPrefix+"vTOKENRESPONSETOKENTYPETAG";
         edtavTokenresponseexpiresintag_Internalname = sPrefix+"vTOKENRESPONSEEXPIRESINTAG";
         edtavTokenresponsescopetag_Internalname = sPrefix+"vTOKENRESPONSESCOPETAG";
         edtavTokenresponseuseridtag_Internalname = sPrefix+"vTOKENRESPONSEUSERIDTAG";
         edtavTokenresponserefreshtokentag_Internalname = sPrefix+"vTOKENRESPONSEREFRESHTOKENTAG";
         edtavTokenresponseerrordescriptiontag_Internalname = sPrefix+"vTOKENRESPONSEERRORDESCRIPTIONTAG";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         Dvpanel_unnamedtable6_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE6";
         chkavAutovalidateexternaltokenandrefresh_Internalname = sPrefix+"vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         edtavTokenrefreshtokenurl_Internalname = sPrefix+"vTOKENREFRESHTOKENURL";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         Dvpanel_unnamedtable7_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE7";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         Dvpanel_unnamedtable5_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE5";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         lblUserinfo_title_Internalname = sPrefix+"USERINFO_TITLE";
         edtavUserinfourl_Internalname = sPrefix+"vUSERINFOURL";
         cmbavUserinfomethod_Internalname = sPrefix+"vUSERINFOMETHOD";
         edtavUserinfoheaderkeytag_Internalname = sPrefix+"vUSERINFOHEADERKEYTAG";
         edtavUserinfoheaderkeyvalue_Internalname = sPrefix+"vUSERINFOHEADERKEYVALUE";
         chkavUserinfoaccesstokeninclude_Internalname = sPrefix+"vUSERINFOACCESSTOKENINCLUDE";
         edtavUserinfoaccesstokenname_Internalname = sPrefix+"vUSERINFOACCESSTOKENNAME";
         chkavUserinfoclientidinclude_Internalname = sPrefix+"vUSERINFOCLIENTIDINCLUDE";
         edtavUserinfoclientidname_Internalname = sPrefix+"vUSERINFOCLIENTIDNAME";
         chkavUserinfoclientsecretinclude_Internalname = sPrefix+"vUSERINFOCLIENTSECRETINCLUDE";
         edtavUserinfoclientsecretname_Internalname = sPrefix+"vUSERINFOCLIENTSECRETNAME";
         chkavUserinfouseridinclude_Internalname = sPrefix+"vUSERINFOUSERIDINCLUDE";
         edtavUserinfoadditionalparameters_Internalname = sPrefix+"vUSERINFOADDITIONALPARAMETERS";
         edtavUserinforesponseuseremailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREMAILTAG";
         edtavUserinforesponseuserverifiedemailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSERVERIFIEDEMAILTAG";
         edtavUserinforesponseuserexternalidtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREXTERNALIDTAG";
         edtavUserinforesponseusernametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERNAMETAG";
         edtavUserinforesponseuserfirstnametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERFIRSTNAMETAG";
         chkavUserinforesponseuserlastnamegenauto_Internalname = sPrefix+"vUSERINFORESPONSEUSERLASTNAMEGENAUTO";
         edtavUserinforesponseuserlastnametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERLASTNAMETAG";
         divUserinforesponseuserlastnametag_cell_Internalname = sPrefix+"USERINFORESPONSEUSERLASTNAMETAG_CELL";
         edtavUserinforesponseusergendertag_Internalname = sPrefix+"vUSERINFORESPONSEUSERGENDERTAG";
         edtavUserinforesponseusergendervalues_Internalname = sPrefix+"vUSERINFORESPONSEUSERGENDERVALUES";
         edtavUserinforesponseuserbirthdaytag_Internalname = sPrefix+"vUSERINFORESPONSEUSERBIRTHDAYTAG";
         edtavUserinforesponseuserurlimagetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERURLIMAGETAG";
         edtavUserinforesponseuserurlprofiletag_Internalname = sPrefix+"vUSERINFORESPONSEUSERURLPROFILETAG";
         edtavUserinforesponseuserlanguagetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERLANGUAGETAG";
         edtavUserinforesponseusertimezonetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERTIMEZONETAG";
         edtavUserinforesponseerrordescriptiontag_Internalname = sPrefix+"vUSERINFORESPONSEERRORDESCRIPTIONTAG";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         Dvpanel_unnamedtable3_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE3";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         Dvpanel_unnamedtable2_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE2";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = sPrefix+"GXUITABSPANEL_TABS";
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
         chkavUserinforesponseuserlastnamegenauto.Caption = "Gerar automaticamente o sobrenome";
         chkavUserinfouseridinclude.Caption = "Incluir id do usuário";
         chkavUserinfoclientsecretinclude.Caption = "Incluir o segredo do cliente";
         chkavUserinfoclientidinclude.Caption = "Inclua o id do cliente";
         chkavUserinfoaccesstokeninclude.Caption = "Incluir token de acesso";
         chkavAutovalidateexternaltokenandrefresh.Caption = "Validar token externo";
         chkavTokenredirecturlinclude.Caption = "Incluir url de redirecionamento";
         chkavTokenclisecretinclude.Caption = "Incluir o segredo do cliente";
         chkavTokencliidinclude.Caption = "Inclua o id do cliente";
         chkavTokenaccesscodeinclude.Caption = "Incluir código de acesso";
         chkavTokengranttypeinclude.Caption = "Tipo de concessão";
         chkavAuthredirurlinclude.Caption = "Incluir url de redirecionamento";
         chkavAuthclientsecretinclude.Caption = "Incluir o segredo do cliente";
         chkavAuthclientidinclude.Caption = "Inclua o id do cliente";
         chkavAuthstateinclude.Caption = "Incluir estado";
         chkavAuthscopeinclude.Caption = "Incluir escopo";
         chkavAuthresptypeinclude.Caption = "Incluir tipo de resposta";
         chkavIsenable.Caption = "Habilitado?";
         bttBtnenter_Caption = "Confirmar";
         bttBtnenter_Visible = 1;
         edtavUserinforesponseerrordescriptiontag_Jsonclick = "";
         edtavUserinforesponseerrordescriptiontag_Enabled = 1;
         edtavUserinforesponseusertimezonetag_Jsonclick = "";
         edtavUserinforesponseusertimezonetag_Enabled = 1;
         edtavUserinforesponseuserlanguagetag_Jsonclick = "";
         edtavUserinforesponseuserlanguagetag_Enabled = 1;
         edtavUserinforesponseuserurlprofiletag_Jsonclick = "";
         edtavUserinforesponseuserurlprofiletag_Enabled = 1;
         edtavUserinforesponseuserurlimagetag_Jsonclick = "";
         edtavUserinforesponseuserurlimagetag_Enabled = 1;
         edtavUserinforesponseuserbirthdaytag_Jsonclick = "";
         edtavUserinforesponseuserbirthdaytag_Enabled = 1;
         edtavUserinforesponseusergendervalues_Jsonclick = "";
         edtavUserinforesponseusergendervalues_Enabled = 1;
         edtavUserinforesponseusergendertag_Jsonclick = "";
         edtavUserinforesponseusergendertag_Enabled = 1;
         edtavUserinforesponseuserlastnametag_Jsonclick = "";
         edtavUserinforesponseuserlastnametag_Enabled = 1;
         edtavUserinforesponseuserlastnametag_Visible = 1;
         divUserinforesponseuserlastnametag_cell_Class = "col-xs-12 col-sm-6";
         chkavUserinforesponseuserlastnamegenauto.Enabled = 1;
         edtavUserinforesponseuserfirstnametag_Jsonclick = "";
         edtavUserinforesponseuserfirstnametag_Enabled = 1;
         edtavUserinforesponseusernametag_Jsonclick = "";
         edtavUserinforesponseusernametag_Enabled = 1;
         edtavUserinforesponseuserexternalidtag_Jsonclick = "";
         edtavUserinforesponseuserexternalidtag_Enabled = 1;
         edtavUserinforesponseuserverifiedemailtag_Jsonclick = "";
         edtavUserinforesponseuserverifiedemailtag_Enabled = 1;
         edtavUserinforesponseuseremailtag_Jsonclick = "";
         edtavUserinforesponseuseremailtag_Enabled = 1;
         edtavUserinfoadditionalparameters_Jsonclick = "";
         edtavUserinfoadditionalparameters_Enabled = 1;
         chkavUserinfouseridinclude.Enabled = 1;
         edtavUserinfoclientsecretname_Jsonclick = "";
         edtavUserinfoclientsecretname_Enabled = 1;
         chkavUserinfoclientsecretinclude.Enabled = 1;
         edtavUserinfoclientidname_Jsonclick = "";
         edtavUserinfoclientidname_Enabled = 1;
         chkavUserinfoclientidinclude.Enabled = 1;
         edtavUserinfoaccesstokenname_Jsonclick = "";
         edtavUserinfoaccesstokenname_Enabled = 1;
         chkavUserinfoaccesstokeninclude.Enabled = 1;
         edtavUserinfoheaderkeyvalue_Jsonclick = "";
         edtavUserinfoheaderkeyvalue_Enabled = 1;
         edtavUserinfoheaderkeytag_Jsonclick = "";
         edtavUserinfoheaderkeytag_Enabled = 1;
         cmbavUserinfomethod_Jsonclick = "";
         cmbavUserinfomethod.Enabled = 1;
         edtavUserinfourl_Jsonclick = "";
         edtavUserinfourl_Enabled = 1;
         edtavTokenrefreshtokenurl_Jsonclick = "";
         edtavTokenrefreshtokenurl_Enabled = 1;
         chkavAutovalidateexternaltokenandrefresh.Enabled = 1;
         edtavTokenresponseerrordescriptiontag_Jsonclick = "";
         edtavTokenresponseerrordescriptiontag_Enabled = 1;
         edtavTokenresponserefreshtokentag_Jsonclick = "";
         edtavTokenresponserefreshtokentag_Enabled = 1;
         edtavTokenresponseuseridtag_Jsonclick = "";
         edtavTokenresponseuseridtag_Enabled = 1;
         edtavTokenresponsescopetag_Jsonclick = "";
         edtavTokenresponsescopetag_Enabled = 1;
         edtavTokenresponseexpiresintag_Jsonclick = "";
         edtavTokenresponseexpiresintag_Enabled = 1;
         edtavTokenresponsetokentypetag_Jsonclick = "";
         edtavTokenresponsetokentypetag_Enabled = 1;
         edtavTokenresponseaccesstokentag_Jsonclick = "";
         edtavTokenresponseaccesstokentag_Enabled = 1;
         edtavTokenadditionalparameters_Jsonclick = "";
         edtavTokenadditionalparameters_Enabled = 1;
         chkavTokenredirecturlinclude.Enabled = 1;
         chkavTokenclisecretinclude.Enabled = 1;
         chkavTokencliidinclude.Enabled = 1;
         chkavTokenaccesscodeinclude.Enabled = 1;
         edtavTokengranttypevalue_Jsonclick = "";
         edtavTokengranttypevalue_Enabled = 1;
         edtavTokengranttypetag_Jsonclick = "";
         edtavTokengranttypetag_Enabled = 1;
         chkavTokengranttypeinclude.Enabled = 1;
         edtavTokenheaderkeyvalue_Jsonclick = "";
         edtavTokenheaderkeyvalue_Enabled = 1;
         edtavTokenheaderkeytag_Jsonclick = "";
         edtavTokenheaderkeytag_Enabled = 1;
         cmbavTokenmethod_Jsonclick = "";
         cmbavTokenmethod.Enabled = 1;
         edtavTokenurl_Jsonclick = "";
         edtavTokenurl_Enabled = 1;
         edtavAuthresponseerrordesctag_Jsonclick = "";
         edtavAuthresponseerrordesctag_Enabled = 1;
         edtavAuthresponseaccesscodetag_Jsonclick = "";
         edtavAuthresponseaccesscodetag_Enabled = 1;
         edtavAuthadditionalparameterssd_Jsonclick = "";
         edtavAuthadditionalparameterssd_Enabled = 1;
         edtavAuthadditionalparameters_Jsonclick = "";
         edtavAuthadditionalparameters_Enabled = 1;
         chkavAuthredirurlinclude.Enabled = 1;
         chkavAuthclientsecretinclude.Enabled = 1;
         chkavAuthclientidinclude.Enabled = 1;
         edtavAuthstatetag_Jsonclick = "";
         edtavAuthstatetag_Enabled = 1;
         chkavAuthstateinclude.Enabled = 1;
         edtavAuthscopevalue_Jsonclick = "";
         edtavAuthscopevalue_Enabled = 1;
         edtavAuthscopetag_Jsonclick = "";
         edtavAuthscopetag_Enabled = 1;
         chkavAuthscopeinclude.Enabled = 1;
         edtavAuthresptypevalue_Jsonclick = "";
         edtavAuthresptypevalue_Enabled = 1;
         edtavAuthresptypetag_Jsonclick = "";
         edtavAuthresptypetag_Enabled = 1;
         chkavAuthresptypeinclude.Enabled = 1;
         edtavAuthorizeurl_Jsonclick = "";
         edtavAuthorizeurl_Enabled = 1;
         edtavOauth20redirecturlvalue_Jsonclick = "";
         edtavOauth20redirecturlvalue_Enabled = 1;
         edtavOauth20redirecturltag_Jsonclick = "";
         edtavOauth20redirecturltag_Enabled = 1;
         edtavOauth20clientsecretvalue_Jsonclick = "";
         edtavOauth20clientsecretvalue_Enabled = 1;
         edtavOauth20clientsecrettag_Jsonclick = "";
         edtavOauth20clientsecrettag_Enabled = 1;
         edtavOauth20clientidvalue_Jsonclick = "";
         edtavOauth20clientidvalue_Enabled = 1;
         edtavOauth20clientidtag_Jsonclick = "";
         edtavOauth20clientidtag_Enabled = 1;
         edtavBigimagename_Jsonclick = "";
         edtavBigimagename_Enabled = 1;
         edtavSmallimagename_Jsonclick = "";
         edtavSmallimagename_Enabled = 1;
         edtavImpersonate_Jsonclick = "";
         edtavImpersonate_Enabled = 1;
         edtavAdditionalscope_Jsonclick = "";
         edtavAdditionalscope_Enabled = 1;
         chkavIsenable.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         cmbavFunctionid_Jsonclick = "";
         cmbavFunctionid.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 0;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "";
         Gxuitabspanel_tabs_Pagecount = 4;
         Dvpanel_unnamedtable2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Iconposition = "Right";
         Dvpanel_unnamedtable2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_unnamedtable2_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Title = "Configuração avançada";
         Dvpanel_unnamedtable2_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Width = "100%";
         Dvpanel_unnamedtable3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Iconposition = "Right";
         Dvpanel_unnamedtable3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Title = "Resposta";
         Dvpanel_unnamedtable3_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Width = "100%";
         Dvpanel_unnamedtable5_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Iconposition = "Right";
         Dvpanel_unnamedtable5_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_unnamedtable5_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable5_Title = "Configuração avançada";
         Dvpanel_unnamedtable5_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable5_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable5_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Width = "100%";
         Dvpanel_unnamedtable7_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Iconposition = "Right";
         Dvpanel_unnamedtable7_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Title = "Token de atualização";
         Dvpanel_unnamedtable7_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable7_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Width = "100%";
         Dvpanel_unnamedtable6_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Iconposition = "Right";
         Dvpanel_unnamedtable6_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable6_Title = "Resposta";
         Dvpanel_unnamedtable6_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable6_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable6_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Width = "100%";
         Dvpanel_unnamedtable9_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable9_Iconposition = "Right";
         Dvpanel_unnamedtable9_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable9_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_unnamedtable9_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable9_Title = "Configuração avançada";
         Dvpanel_unnamedtable9_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable9_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable9_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable9_Width = "100%";
         Dvpanel_unnamedtable10_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Iconposition = "Right";
         Dvpanel_unnamedtable10_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable10_Title = "Resposta";
         Dvpanel_unnamedtable10_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable10_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable10_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Width = "100%";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E12112',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV29Name',fld:'vNAME',pic:''},{av:'AV57TypeId',fld:'vTYPEID',pic:''},{av:'AV23Dsc',fld:'vDSC',pic:''},{av:'AV36SmallImageName',fld:'vSMALLIMAGENAME',pic:''},{av:'AV22BigImageName',fld:'vBIGIMAGENAME',pic:''},{av:'AV27Impersonate',fld:'vIMPERSONATE',pic:''},{av:'AV30Oauth20ClientIdTag',fld:'vOAUTH20CLIENTIDTAG',pic:''},{av:'AV31Oauth20ClientIdValue',fld:'vOAUTH20CLIENTIDVALUE',pic:''},{av:'AV32Oauth20ClientSecretTag',fld:'vOAUTH20CLIENTSECRETTAG',pic:''},{av:'AV33Oauth20ClientSecretValue',fld:'vOAUTH20CLIENTSECRETVALUE',pic:''},{av:'AV34Oauth20RedirectURLTag',fld:'vOAUTH20REDIRECTURLTAG',pic:''},{av:'AV35Oauth20RedirectURLvalue',fld:'vOAUTH20REDIRECTURLVALUE',pic:''},{av:'AV10AuthorizeURL',fld:'vAUTHORIZEURL',pic:''},{av:'AV15AuthRespTypeTag',fld:'vAUTHRESPTYPETAG',pic:''},{av:'AV16AuthRespTypeValue',fld:'vAUTHRESPTYPEVALUE',pic:''},{av:'AV18AuthScopeTag',fld:'vAUTHSCOPETAG',pic:''},{av:'AV19AuthScopeValue',fld:'vAUTHSCOPEVALUE',pic:''},{av:'AV20AuthStateTag',fld:'vAUTHSTATETAG',pic:''},{av:'AV5AuthAdditionalParameters',fld:'vAUTHADDITIONALPARAMETERS',pic:''},{av:'AV6AuthAdditionalParametersSD',fld:'vAUTHADDITIONALPARAMETERSSD',pic:''},{av:'AV12AuthResponseAccessCodeTag',fld:'vAUTHRESPONSEACCESSCODETAG',pic:''},{av:'AV13AuthResponseErrorDescTag',fld:'vAUTHRESPONSEERRORDESCTAG',pic:''},{av:'AV56TokenURL',fld:'vTOKENURL',pic:''},{av:'cmbavTokenmethod'},{av:'AV46TokenMethod',fld:'vTOKENMETHOD',pic:''},{av:'AV44TokenHeaderKeyTag',fld:'vTOKENHEADERKEYTAG',pic:''},{av:'AV45TokenHeaderKeyValue',fld:'vTOKENHEADERKEYVALUE',pic:''},{av:'AV42TokenGrantTypeTag',fld:'vTOKENGRANTTYPETAG',pic:''},{av:'AV43TokenGrantTypeValue',fld:'vTOKENGRANTTYPEVALUE',pic:''},{av:'AV38TokenAdditionalParameters',fld:'vTOKENADDITIONALPARAMETERS',pic:''},{av:'AV49TokenResponseAccessTokenTag',fld:'vTOKENRESPONSEACCESSTOKENTAG',pic:''},{av:'AV54TokenResponseTokenTypeTag',fld:'vTOKENRESPONSETOKENTYPETAG',pic:''},{av:'AV51TokenResponseExpiresInTag',fld:'vTOKENRESPONSEEXPIRESINTAG',pic:''},{av:'AV53TokenResponseScopeTag',fld:'vTOKENRESPONSESCOPETAG',pic:''},{av:'AV55TokenResponseUserIdTag',fld:'vTOKENRESPONSEUSERIDTAG',pic:''},{av:'AV52TokenResponseRefreshTokenTag',fld:'vTOKENRESPONSEREFRESHTOKENTAG',pic:''},{av:'AV50TokenResponseErrorDescriptionTag',fld:'vTOKENRESPONSEERRORDESCRIPTIONTAG',pic:''},{av:'AV48TokenRefreshTokenURL',fld:'vTOKENREFRESHTOKENURL',pic:''},{av:'AV83UserInfoURL',fld:'vUSERINFOURL',pic:''},{av:'cmbavUserinfomethod'},{av:'AV67UserInfoMethod',fld:'vUSERINFOMETHOD',pic:''},{av:'AV65UserInfoHeaderKeyTag',fld:'vUSERINFOHEADERKEYTAG',pic:''},{av:'AV66UserInfoHeaderKeyValue',fld:'vUSERINFOHEADERKEYVALUE',pic:''},{av:'AV59UserInfoAccessTokenName',fld:'vUSERINFOACCESSTOKENNAME',pic:''},{av:'AV62UserInfoClientIdName',fld:'vUSERINFOCLIENTIDNAME',pic:''},{av:'AV64UserInfoClientSecretName',fld:'vUSERINFOCLIENTSECRETNAME',pic:''},{av:'AV60UserInfoAdditionalParameters',fld:'vUSERINFOADDITIONALPARAMETERS',pic:''},{av:'AV70UserInfoResponseUserEmailTag',fld:'vUSERINFORESPONSEUSEREMAILTAG',pic:''},{av:'AV82UserInfoResponseUserVerifiedEmailTag',fld:'vUSERINFORESPONSEUSERVERIFIEDEMAILTAG',pic:''},{av:'AV71UserInfoResponseUserExternalIdTag',fld:'vUSERINFORESPONSEUSEREXTERNALIDTAG',pic:''},{av:'AV78UserInfoResponseUserNameTag',fld:'vUSERINFORESPONSEUSERNAMETAG',pic:''},{av:'AV72UserInfoResponseUserFirstNameTag',fld:'vUSERINFORESPONSEUSERFIRSTNAMETAG',pic:''},{av:'AV77UserInfoResponseUserLastNameTag',fld:'vUSERINFORESPONSEUSERLASTNAMETAG',pic:''},{av:'AV73UserInfoResponseUserGenderTag',fld:'vUSERINFORESPONSEUSERGENDERTAG',pic:''},{av:'AV74UserInfoResponseUserGenderValues',fld:'vUSERINFORESPONSEUSERGENDERVALUES',pic:''},{av:'AV69UserInfoResponseUserBirthdayTag',fld:'vUSERINFORESPONSEUSERBIRTHDAYTAG',pic:''},{av:'AV80UserInfoResponseUserURLImageTag',fld:'vUSERINFORESPONSEUSERURLIMAGETAG',pic:''},{av:'AV81UserInfoResponseUserURLProfileTag',fld:'vUSERINFORESPONSEUSERURLPROFILETAG',pic:''},{av:'AV75UserInfoResponseUserLanguageTag',fld:'vUSERINFORESPONSEUSERLANGUAGETAG',pic:''},{av:'AV79UserInfoResponseUserTimeZoneTag',fld:'vUSERINFORESPONSEUSERTIMEZONETAG',pic:''},{av:'AV68UserInfoResponseErrorDescriptionTag',fld:'vUSERINFORESPONSEERRORDESCRIPTIONTAG',pic:''},{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("VALIDV_FUNCTIONID","{handler:'Validv_Functionid',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("VALIDV_FUNCTIONID",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("VALIDV_TOKENMETHOD","{handler:'Validv_Tokenmethod',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("VALIDV_TOKENMETHOD",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("VALIDV_USERINFOMETHOD","{handler:'Validv_Userinfomethod',iparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("VALIDV_USERINFOMETHOD",",oparms:[{av:'AV28IsEnable',fld:'vISENABLE',pic:''},{av:'AV14AuthRespTypeInclude',fld:'vAUTHRESPTYPEINCLUDE',pic:''},{av:'AV17AuthScopeInclude',fld:'vAUTHSCOPEINCLUDE',pic:''},{av:'AV91AuthStateInclude',fld:'vAUTHSTATEINCLUDE',pic:''},{av:'AV7AuthClientIdInclude',fld:'vAUTHCLIENTIDINCLUDE',pic:''},{av:'AV8AuthClientSecretInclude',fld:'vAUTHCLIENTSECRETINCLUDE',pic:''},{av:'AV92AuthRedirURLInclude',fld:'vAUTHREDIRURLINCLUDE',pic:''},{av:'AV41TokenGrantTypeInclude',fld:'vTOKENGRANTTYPEINCLUDE',pic:''},{av:'AV37TokenAccessCodeInclude',fld:'vTOKENACCESSCODEINCLUDE',pic:''},{av:'AV39TokenCliIdInclude',fld:'vTOKENCLIIDINCLUDE',pic:''},{av:'AV40TokenCliSecretInclude',fld:'vTOKENCLISECRETINCLUDE',pic:''},{av:'AV47TokenRedirectURLInclude',fld:'vTOKENREDIRECTURLINCLUDE',pic:''},{av:'AV21AutovalidateExternalTokenAndRefresh',fld:'vAUTOVALIDATEEXTERNALTOKENANDREFRESH',pic:''},{av:'AV58UserInfoAccessTokenInclude',fld:'vUSERINFOACCESSTOKENINCLUDE',pic:''},{av:'AV61UserInfoClientIdInclude',fld:'vUSERINFOCLIENTIDINCLUDE',pic:''},{av:'AV63UserInfoClientSecretInclude',fld:'vUSERINFOCLIENTSECRETINCLUDE',pic:''},{av:'AV84UserInfoUserIdInclude',fld:'vUSERINFOUSERIDINCLUDE',pic:''},{av:'AV76UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
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
         wcpOAV29Name = "";
         wcpOAV57TypeId = "";
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
         AV26FunctionId = "";
         AV23Dsc = "";
         AV93AdditionalScope = "";
         AV27Impersonate = "";
         AV36SmallImageName = "";
         AV22BigImageName = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         AV30Oauth20ClientIdTag = "";
         AV31Oauth20ClientIdValue = "";
         AV32Oauth20ClientSecretTag = "";
         AV33Oauth20ClientSecretValue = "";
         AV34Oauth20RedirectURLTag = "";
         AV35Oauth20RedirectURLvalue = "";
         lblAuthorization_title_Jsonclick = "";
         AV10AuthorizeURL = "";
         ucDvpanel_unnamedtable9 = new GXUserControl();
         AV15AuthRespTypeTag = "";
         AV16AuthRespTypeValue = "";
         AV18AuthScopeTag = "";
         AV19AuthScopeValue = "";
         AV20AuthStateTag = "";
         AV5AuthAdditionalParameters = "";
         AV6AuthAdditionalParametersSD = "";
         ucDvpanel_unnamedtable10 = new GXUserControl();
         AV12AuthResponseAccessCodeTag = "";
         AV13AuthResponseErrorDescTag = "";
         lblToken_title_Jsonclick = "";
         AV56TokenURL = "";
         ucDvpanel_unnamedtable5 = new GXUserControl();
         AV46TokenMethod = "";
         AV44TokenHeaderKeyTag = "";
         AV45TokenHeaderKeyValue = "";
         AV42TokenGrantTypeTag = "";
         AV43TokenGrantTypeValue = "";
         AV38TokenAdditionalParameters = "";
         ucDvpanel_unnamedtable6 = new GXUserControl();
         AV49TokenResponseAccessTokenTag = "";
         AV54TokenResponseTokenTypeTag = "";
         AV51TokenResponseExpiresInTag = "";
         AV53TokenResponseScopeTag = "";
         AV55TokenResponseUserIdTag = "";
         AV52TokenResponseRefreshTokenTag = "";
         AV50TokenResponseErrorDescriptionTag = "";
         ucDvpanel_unnamedtable7 = new GXUserControl();
         AV48TokenRefreshTokenURL = "";
         lblUserinfo_title_Jsonclick = "";
         AV83UserInfoURL = "";
         ucDvpanel_unnamedtable2 = new GXUserControl();
         AV67UserInfoMethod = "";
         AV65UserInfoHeaderKeyTag = "";
         AV66UserInfoHeaderKeyValue = "";
         AV59UserInfoAccessTokenName = "";
         AV62UserInfoClientIdName = "";
         AV64UserInfoClientSecretName = "";
         AV60UserInfoAdditionalParameters = "";
         ucDvpanel_unnamedtable3 = new GXUserControl();
         AV70UserInfoResponseUserEmailTag = "";
         AV82UserInfoResponseUserVerifiedEmailTag = "";
         AV71UserInfoResponseUserExternalIdTag = "";
         AV78UserInfoResponseUserNameTag = "";
         AV72UserInfoResponseUserFirstNameTag = "";
         AV77UserInfoResponseUserLastNameTag = "";
         AV73UserInfoResponseUserGenderTag = "";
         AV74UserInfoResponseUserGenderValues = "";
         AV69UserInfoResponseUserBirthdayTag = "";
         AV80UserInfoResponseUserURLImageTag = "";
         AV81UserInfoResponseUserURLProfileTag = "";
         AV75UserInfoResponseUserLanguageTag = "";
         AV79UserInfoResponseUserTimeZoneTag = "";
         AV68UserInfoResponseErrorDescriptionTag = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         AV25Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV24Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV29Name = "";
         sCtrlAV57TypeId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentryoauth20__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentryoauth20__default(),
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
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavAdditionalscope_Enabled ;
      private int edtavImpersonate_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int edtavOauth20clientidtag_Enabled ;
      private int edtavOauth20clientidvalue_Enabled ;
      private int edtavOauth20clientsecrettag_Enabled ;
      private int edtavOauth20clientsecretvalue_Enabled ;
      private int edtavOauth20redirecturltag_Enabled ;
      private int edtavOauth20redirecturlvalue_Enabled ;
      private int edtavAuthorizeurl_Enabled ;
      private int edtavAuthresptypetag_Enabled ;
      private int edtavAuthresptypevalue_Enabled ;
      private int edtavAuthscopetag_Enabled ;
      private int edtavAuthscopevalue_Enabled ;
      private int edtavAuthstatetag_Enabled ;
      private int edtavAuthadditionalparameters_Enabled ;
      private int edtavAuthadditionalparameterssd_Enabled ;
      private int edtavAuthresponseaccesscodetag_Enabled ;
      private int edtavAuthresponseerrordesctag_Enabled ;
      private int edtavTokenurl_Enabled ;
      private int edtavTokenheaderkeytag_Enabled ;
      private int edtavTokenheaderkeyvalue_Enabled ;
      private int edtavTokengranttypetag_Enabled ;
      private int edtavTokengranttypevalue_Enabled ;
      private int edtavTokenadditionalparameters_Enabled ;
      private int edtavTokenresponseaccesstokentag_Enabled ;
      private int edtavTokenresponsetokentypetag_Enabled ;
      private int edtavTokenresponseexpiresintag_Enabled ;
      private int edtavTokenresponsescopetag_Enabled ;
      private int edtavTokenresponseuseridtag_Enabled ;
      private int edtavTokenresponserefreshtokentag_Enabled ;
      private int edtavTokenresponseerrordescriptiontag_Enabled ;
      private int edtavTokenrefreshtokenurl_Enabled ;
      private int edtavUserinfourl_Enabled ;
      private int edtavUserinfoheaderkeytag_Enabled ;
      private int edtavUserinfoheaderkeyvalue_Enabled ;
      private int edtavUserinfoaccesstokenname_Enabled ;
      private int edtavUserinfoclientidname_Enabled ;
      private int edtavUserinfoclientsecretname_Enabled ;
      private int edtavUserinfoadditionalparameters_Enabled ;
      private int edtavUserinforesponseuseremailtag_Enabled ;
      private int edtavUserinforesponseuserverifiedemailtag_Enabled ;
      private int edtavUserinforesponseuserexternalidtag_Enabled ;
      private int edtavUserinforesponseusernametag_Enabled ;
      private int edtavUserinforesponseuserfirstnametag_Enabled ;
      private int edtavUserinforesponseuserlastnametag_Visible ;
      private int edtavUserinforesponseuserlastnametag_Enabled ;
      private int edtavUserinforesponseusergendertag_Enabled ;
      private int edtavUserinforesponseusergendervalues_Enabled ;
      private int edtavUserinforesponseuserbirthdaytag_Enabled ;
      private int edtavUserinforesponseuserurlimagetag_Enabled ;
      private int edtavUserinforesponseuserurlprofiletag_Enabled ;
      private int edtavUserinforesponseuserlanguagetag_Enabled ;
      private int edtavUserinforesponseusertimezonetag_Enabled ;
      private int edtavUserinforesponseerrordescriptiontag_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV97GXV1 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV29Name ;
      private string AV57TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV29Name ;
      private string wcpOAV57TypeId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_unnamedtable10_Width ;
      private string Dvpanel_unnamedtable10_Cls ;
      private string Dvpanel_unnamedtable10_Title ;
      private string Dvpanel_unnamedtable10_Iconposition ;
      private string Dvpanel_unnamedtable9_Width ;
      private string Dvpanel_unnamedtable9_Cls ;
      private string Dvpanel_unnamedtable9_Title ;
      private string Dvpanel_unnamedtable9_Iconposition ;
      private string Dvpanel_unnamedtable6_Width ;
      private string Dvpanel_unnamedtable6_Cls ;
      private string Dvpanel_unnamedtable6_Title ;
      private string Dvpanel_unnamedtable6_Iconposition ;
      private string Dvpanel_unnamedtable7_Width ;
      private string Dvpanel_unnamedtable7_Cls ;
      private string Dvpanel_unnamedtable7_Title ;
      private string Dvpanel_unnamedtable7_Iconposition ;
      private string Dvpanel_unnamedtable5_Width ;
      private string Dvpanel_unnamedtable5_Cls ;
      private string Dvpanel_unnamedtable5_Title ;
      private string Dvpanel_unnamedtable5_Iconposition ;
      private string Dvpanel_unnamedtable3_Width ;
      private string Dvpanel_unnamedtable3_Cls ;
      private string Dvpanel_unnamedtable3_Title ;
      private string Dvpanel_unnamedtable3_Iconposition ;
      private string Dvpanel_unnamedtable2_Width ;
      private string Dvpanel_unnamedtable2_Cls ;
      private string Dvpanel_unnamedtable2_Title ;
      private string Dvpanel_unnamedtable2_Iconposition ;
      private string Gxuitabspanel_tabs_Class ;
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
      private string AV26FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string edtavDsc_Internalname ;
      private string AV23Dsc ;
      private string edtavDsc_Jsonclick ;
      private string chkavIsenable_Internalname ;
      private string edtavAdditionalscope_Internalname ;
      private string edtavAdditionalscope_Jsonclick ;
      private string edtavImpersonate_Internalname ;
      private string AV27Impersonate ;
      private string edtavImpersonate_Jsonclick ;
      private string edtavSmallimagename_Internalname ;
      private string AV36SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string edtavBigimagename_Internalname ;
      private string AV22BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtable11_Internalname ;
      private string edtavOauth20clientidtag_Internalname ;
      private string AV30Oauth20ClientIdTag ;
      private string edtavOauth20clientidtag_Jsonclick ;
      private string edtavOauth20clientidvalue_Internalname ;
      private string edtavOauth20clientidvalue_Jsonclick ;
      private string edtavOauth20clientsecrettag_Internalname ;
      private string AV32Oauth20ClientSecretTag ;
      private string edtavOauth20clientsecrettag_Jsonclick ;
      private string edtavOauth20clientsecretvalue_Internalname ;
      private string edtavOauth20clientsecretvalue_Jsonclick ;
      private string edtavOauth20redirecturltag_Internalname ;
      private string AV34Oauth20RedirectURLTag ;
      private string edtavOauth20redirecturltag_Jsonclick ;
      private string edtavOauth20redirecturlvalue_Internalname ;
      private string edtavOauth20redirecturlvalue_Jsonclick ;
      private string lblAuthorization_title_Internalname ;
      private string lblAuthorization_title_Jsonclick ;
      private string divUnnamedtable8_Internalname ;
      private string edtavAuthorizeurl_Internalname ;
      private string edtavAuthorizeurl_Jsonclick ;
      private string Dvpanel_unnamedtable9_Internalname ;
      private string divUnnamedtable9_Internalname ;
      private string chkavAuthresptypeinclude_Internalname ;
      private string edtavAuthresptypetag_Internalname ;
      private string AV15AuthRespTypeTag ;
      private string edtavAuthresptypetag_Jsonclick ;
      private string edtavAuthresptypevalue_Internalname ;
      private string edtavAuthresptypevalue_Jsonclick ;
      private string chkavAuthscopeinclude_Internalname ;
      private string edtavAuthscopetag_Internalname ;
      private string AV18AuthScopeTag ;
      private string edtavAuthscopetag_Jsonclick ;
      private string edtavAuthscopevalue_Internalname ;
      private string edtavAuthscopevalue_Jsonclick ;
      private string chkavAuthstateinclude_Internalname ;
      private string edtavAuthstatetag_Internalname ;
      private string AV20AuthStateTag ;
      private string edtavAuthstatetag_Jsonclick ;
      private string chkavAuthclientidinclude_Internalname ;
      private string chkavAuthclientsecretinclude_Internalname ;
      private string chkavAuthredirurlinclude_Internalname ;
      private string edtavAuthadditionalparameters_Internalname ;
      private string AV5AuthAdditionalParameters ;
      private string edtavAuthadditionalparameters_Jsonclick ;
      private string edtavAuthadditionalparameterssd_Internalname ;
      private string AV6AuthAdditionalParametersSD ;
      private string edtavAuthadditionalparameterssd_Jsonclick ;
      private string Dvpanel_unnamedtable10_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string edtavAuthresponseaccesscodetag_Internalname ;
      private string AV12AuthResponseAccessCodeTag ;
      private string edtavAuthresponseaccesscodetag_Jsonclick ;
      private string edtavAuthresponseerrordesctag_Internalname ;
      private string AV13AuthResponseErrorDescTag ;
      private string edtavAuthresponseerrordesctag_Jsonclick ;
      private string lblToken_title_Internalname ;
      private string lblToken_title_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string edtavTokenurl_Internalname ;
      private string edtavTokenurl_Jsonclick ;
      private string Dvpanel_unnamedtable5_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string cmbavTokenmethod_Internalname ;
      private string AV46TokenMethod ;
      private string cmbavTokenmethod_Jsonclick ;
      private string edtavTokenheaderkeytag_Internalname ;
      private string AV44TokenHeaderKeyTag ;
      private string edtavTokenheaderkeytag_Jsonclick ;
      private string edtavTokenheaderkeyvalue_Internalname ;
      private string edtavTokenheaderkeyvalue_Jsonclick ;
      private string chkavTokengranttypeinclude_Internalname ;
      private string edtavTokengranttypetag_Internalname ;
      private string AV42TokenGrantTypeTag ;
      private string edtavTokengranttypetag_Jsonclick ;
      private string edtavTokengranttypevalue_Internalname ;
      private string edtavTokengranttypevalue_Jsonclick ;
      private string chkavTokenaccesscodeinclude_Internalname ;
      private string chkavTokencliidinclude_Internalname ;
      private string chkavTokenclisecretinclude_Internalname ;
      private string chkavTokenredirecturlinclude_Internalname ;
      private string edtavTokenadditionalparameters_Internalname ;
      private string AV38TokenAdditionalParameters ;
      private string edtavTokenadditionalparameters_Jsonclick ;
      private string Dvpanel_unnamedtable6_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string edtavTokenresponseaccesstokentag_Internalname ;
      private string AV49TokenResponseAccessTokenTag ;
      private string edtavTokenresponseaccesstokentag_Jsonclick ;
      private string edtavTokenresponsetokentypetag_Internalname ;
      private string AV54TokenResponseTokenTypeTag ;
      private string edtavTokenresponsetokentypetag_Jsonclick ;
      private string edtavTokenresponseexpiresintag_Internalname ;
      private string AV51TokenResponseExpiresInTag ;
      private string edtavTokenresponseexpiresintag_Jsonclick ;
      private string edtavTokenresponsescopetag_Internalname ;
      private string AV53TokenResponseScopeTag ;
      private string edtavTokenresponsescopetag_Jsonclick ;
      private string edtavTokenresponseuseridtag_Internalname ;
      private string AV55TokenResponseUserIdTag ;
      private string edtavTokenresponseuseridtag_Jsonclick ;
      private string edtavTokenresponserefreshtokentag_Internalname ;
      private string AV52TokenResponseRefreshTokenTag ;
      private string edtavTokenresponserefreshtokentag_Jsonclick ;
      private string edtavTokenresponseerrordescriptiontag_Internalname ;
      private string AV50TokenResponseErrorDescriptionTag ;
      private string edtavTokenresponseerrordescriptiontag_Jsonclick ;
      private string Dvpanel_unnamedtable7_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string chkavAutovalidateexternaltokenandrefresh_Internalname ;
      private string edtavTokenrefreshtokenurl_Internalname ;
      private string edtavTokenrefreshtokenurl_Jsonclick ;
      private string lblUserinfo_title_Internalname ;
      private string lblUserinfo_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavUserinfourl_Internalname ;
      private string edtavUserinfourl_Jsonclick ;
      private string Dvpanel_unnamedtable2_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string cmbavUserinfomethod_Internalname ;
      private string AV67UserInfoMethod ;
      private string cmbavUserinfomethod_Jsonclick ;
      private string edtavUserinfoheaderkeytag_Internalname ;
      private string AV65UserInfoHeaderKeyTag ;
      private string edtavUserinfoheaderkeytag_Jsonclick ;
      private string edtavUserinfoheaderkeyvalue_Internalname ;
      private string edtavUserinfoheaderkeyvalue_Jsonclick ;
      private string chkavUserinfoaccesstokeninclude_Internalname ;
      private string edtavUserinfoaccesstokenname_Internalname ;
      private string AV59UserInfoAccessTokenName ;
      private string edtavUserinfoaccesstokenname_Jsonclick ;
      private string chkavUserinfoclientidinclude_Internalname ;
      private string edtavUserinfoclientidname_Internalname ;
      private string AV62UserInfoClientIdName ;
      private string edtavUserinfoclientidname_Jsonclick ;
      private string chkavUserinfoclientsecretinclude_Internalname ;
      private string edtavUserinfoclientsecretname_Internalname ;
      private string AV64UserInfoClientSecretName ;
      private string edtavUserinfoclientsecretname_Jsonclick ;
      private string chkavUserinfouseridinclude_Internalname ;
      private string edtavUserinfoadditionalparameters_Internalname ;
      private string AV60UserInfoAdditionalParameters ;
      private string edtavUserinfoadditionalparameters_Jsonclick ;
      private string Dvpanel_unnamedtable3_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavUserinforesponseuseremailtag_Internalname ;
      private string AV70UserInfoResponseUserEmailTag ;
      private string edtavUserinforesponseuseremailtag_Jsonclick ;
      private string edtavUserinforesponseuserverifiedemailtag_Internalname ;
      private string AV82UserInfoResponseUserVerifiedEmailTag ;
      private string edtavUserinforesponseuserverifiedemailtag_Jsonclick ;
      private string edtavUserinforesponseuserexternalidtag_Internalname ;
      private string AV71UserInfoResponseUserExternalIdTag ;
      private string edtavUserinforesponseuserexternalidtag_Jsonclick ;
      private string edtavUserinforesponseusernametag_Internalname ;
      private string AV78UserInfoResponseUserNameTag ;
      private string edtavUserinforesponseusernametag_Jsonclick ;
      private string edtavUserinforesponseuserfirstnametag_Internalname ;
      private string AV72UserInfoResponseUserFirstNameTag ;
      private string edtavUserinforesponseuserfirstnametag_Jsonclick ;
      private string chkavUserinforesponseuserlastnamegenauto_Internalname ;
      private string divUserinforesponseuserlastnametag_cell_Internalname ;
      private string divUserinforesponseuserlastnametag_cell_Class ;
      private string edtavUserinforesponseuserlastnametag_Internalname ;
      private string AV77UserInfoResponseUserLastNameTag ;
      private string edtavUserinforesponseuserlastnametag_Jsonclick ;
      private string edtavUserinforesponseusergendertag_Internalname ;
      private string AV73UserInfoResponseUserGenderTag ;
      private string edtavUserinforesponseusergendertag_Jsonclick ;
      private string edtavUserinforesponseusergendervalues_Internalname ;
      private string edtavUserinforesponseusergendervalues_Jsonclick ;
      private string edtavUserinforesponseuserbirthdaytag_Internalname ;
      private string AV69UserInfoResponseUserBirthdayTag ;
      private string edtavUserinforesponseuserbirthdaytag_Jsonclick ;
      private string edtavUserinforesponseuserurlimagetag_Internalname ;
      private string AV80UserInfoResponseUserURLImageTag ;
      private string edtavUserinforesponseuserurlimagetag_Jsonclick ;
      private string edtavUserinforesponseuserurlprofiletag_Internalname ;
      private string AV81UserInfoResponseUserURLProfileTag ;
      private string edtavUserinforesponseuserurlprofiletag_Jsonclick ;
      private string edtavUserinforesponseuserlanguagetag_Internalname ;
      private string AV75UserInfoResponseUserLanguageTag ;
      private string edtavUserinforesponseuserlanguagetag_Jsonclick ;
      private string edtavUserinforesponseusertimezonetag_Internalname ;
      private string AV79UserInfoResponseUserTimeZoneTag ;
      private string edtavUserinforesponseusertimezonetag_Jsonclick ;
      private string edtavUserinforesponseerrordescriptiontag_Internalname ;
      private string AV68UserInfoResponseErrorDescriptionTag ;
      private string edtavUserinforesponseerrordescriptiontag_Jsonclick ;
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
      private string sCtrlGx_mode ;
      private string sCtrlAV29Name ;
      private string sCtrlAV57TypeId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_unnamedtable10_Autowidth ;
      private bool Dvpanel_unnamedtable10_Autoheight ;
      private bool Dvpanel_unnamedtable10_Collapsible ;
      private bool Dvpanel_unnamedtable10_Collapsed ;
      private bool Dvpanel_unnamedtable10_Showcollapseicon ;
      private bool Dvpanel_unnamedtable10_Autoscroll ;
      private bool Dvpanel_unnamedtable9_Autowidth ;
      private bool Dvpanel_unnamedtable9_Autoheight ;
      private bool Dvpanel_unnamedtable9_Collapsible ;
      private bool Dvpanel_unnamedtable9_Collapsed ;
      private bool Dvpanel_unnamedtable9_Showcollapseicon ;
      private bool Dvpanel_unnamedtable9_Autoscroll ;
      private bool Dvpanel_unnamedtable6_Autowidth ;
      private bool Dvpanel_unnamedtable6_Autoheight ;
      private bool Dvpanel_unnamedtable6_Collapsible ;
      private bool Dvpanel_unnamedtable6_Collapsed ;
      private bool Dvpanel_unnamedtable6_Showcollapseicon ;
      private bool Dvpanel_unnamedtable6_Autoscroll ;
      private bool Dvpanel_unnamedtable7_Autowidth ;
      private bool Dvpanel_unnamedtable7_Autoheight ;
      private bool Dvpanel_unnamedtable7_Collapsible ;
      private bool Dvpanel_unnamedtable7_Collapsed ;
      private bool Dvpanel_unnamedtable7_Showcollapseicon ;
      private bool Dvpanel_unnamedtable7_Autoscroll ;
      private bool Dvpanel_unnamedtable5_Autowidth ;
      private bool Dvpanel_unnamedtable5_Autoheight ;
      private bool Dvpanel_unnamedtable5_Collapsible ;
      private bool Dvpanel_unnamedtable5_Collapsed ;
      private bool Dvpanel_unnamedtable5_Showcollapseicon ;
      private bool Dvpanel_unnamedtable5_Autoscroll ;
      private bool Dvpanel_unnamedtable3_Autowidth ;
      private bool Dvpanel_unnamedtable3_Autoheight ;
      private bool Dvpanel_unnamedtable3_Collapsible ;
      private bool Dvpanel_unnamedtable3_Collapsed ;
      private bool Dvpanel_unnamedtable3_Showcollapseicon ;
      private bool Dvpanel_unnamedtable3_Autoscroll ;
      private bool Dvpanel_unnamedtable2_Autowidth ;
      private bool Dvpanel_unnamedtable2_Autoheight ;
      private bool Dvpanel_unnamedtable2_Collapsible ;
      private bool Dvpanel_unnamedtable2_Collapsed ;
      private bool Dvpanel_unnamedtable2_Showcollapseicon ;
      private bool Dvpanel_unnamedtable2_Autoscroll ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool AV28IsEnable ;
      private bool AV14AuthRespTypeInclude ;
      private bool AV17AuthScopeInclude ;
      private bool AV91AuthStateInclude ;
      private bool AV7AuthClientIdInclude ;
      private bool AV8AuthClientSecretInclude ;
      private bool AV92AuthRedirURLInclude ;
      private bool AV41TokenGrantTypeInclude ;
      private bool AV37TokenAccessCodeInclude ;
      private bool AV39TokenCliIdInclude ;
      private bool AV40TokenCliSecretInclude ;
      private bool AV47TokenRedirectURLInclude ;
      private bool AV21AutovalidateExternalTokenAndRefresh ;
      private bool AV58UserInfoAccessTokenInclude ;
      private bool AV61UserInfoClientIdInclude ;
      private bool AV63UserInfoClientSecretInclude ;
      private bool AV84UserInfoUserIdInclude ;
      private bool AV76UserInfoResponseUserLastNameGenAuto ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV93AdditionalScope ;
      private string AV31Oauth20ClientIdValue ;
      private string AV33Oauth20ClientSecretValue ;
      private string AV35Oauth20RedirectURLvalue ;
      private string AV10AuthorizeURL ;
      private string AV16AuthRespTypeValue ;
      private string AV19AuthScopeValue ;
      private string AV56TokenURL ;
      private string AV45TokenHeaderKeyValue ;
      private string AV43TokenGrantTypeValue ;
      private string AV48TokenRefreshTokenURL ;
      private string AV83UserInfoURL ;
      private string AV66UserInfoHeaderKeyValue ;
      private string AV74UserInfoResponseUserGenderValues ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucDvpanel_unnamedtable9 ;
      private GXUserControl ucDvpanel_unnamedtable10 ;
      private GXUserControl ucDvpanel_unnamedtable5 ;
      private GXUserControl ucDvpanel_unnamedtable6 ;
      private GXUserControl ucDvpanel_unnamedtable7 ;
      private GXUserControl ucDvpanel_unnamedtable2 ;
      private GXUserControl ucDvpanel_unnamedtable3 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeId ;
      private GXCombobox cmbavFunctionid ;
      private GXCheckbox chkavIsenable ;
      private GXCheckbox chkavAuthresptypeinclude ;
      private GXCheckbox chkavAuthscopeinclude ;
      private GXCheckbox chkavAuthstateinclude ;
      private GXCheckbox chkavAuthclientidinclude ;
      private GXCheckbox chkavAuthclientsecretinclude ;
      private GXCheckbox chkavAuthredirurlinclude ;
      private GXCombobox cmbavTokenmethod ;
      private GXCheckbox chkavTokengranttypeinclude ;
      private GXCheckbox chkavTokenaccesscodeinclude ;
      private GXCheckbox chkavTokencliidinclude ;
      private GXCheckbox chkavTokenclisecretinclude ;
      private GXCheckbox chkavTokenredirecturlinclude ;
      private GXCheckbox chkavAutovalidateexternaltokenandrefresh ;
      private GXCombobox cmbavUserinfomethod ;
      private GXCheckbox chkavUserinfoaccesstokeninclude ;
      private GXCheckbox chkavUserinfoclientidinclude ;
      private GXCheckbox chkavUserinfoclientsecretinclude ;
      private GXCheckbox chkavUserinfouseridinclude ;
      private GXCheckbox chkavUserinforesponseuserlastnamegenauto ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV25Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20 AV9AuthenticationTypeOauth20 ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV24Error ;
   }

   public class gamwcauthenticationtypeentryoauth20__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwcauthenticationtypeentryoauth20__default : DataStoreHelperBase, IDataStoreHelper
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
