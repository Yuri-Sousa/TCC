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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gamwcauthenticationtypeentrysaml20 : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public gamwcauthenticationtypeentrysaml20( )
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

      public gamwcauthenticationtypeentrysaml20( IGxContext context )
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
         this.AV32Name = aP1_Name;
         this.AV41TypeId = aP2_TypeId;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV32Name;
         aP2_TypeId=this.AV41TypeId;
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
         chkavForceauthn = new GXCheckbox();
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
                  AV32Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV32Name", AV32Name);
                  AV41TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV32Name,(string)AV41TypeId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_229 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_229"), "."));
                  nGXsfl_229_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_229_idx"), "."));
                  sGXsfl_229_idx = GetPar( "sGXsfl_229_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
                  Gx_mode = GetPar( "Mode");
                  AV19IsEnable = StringUtil.StrToBool( GetPar( "IsEnable"));
                  AV15ForceAuthn = StringUtil.StrToBool( GetPar( "ForceAuthn"));
                  AV51UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( GetPar( "UserInfoResponseUserLastNameGenAuto"));
                  AV45UserInfoResponseUserErrorDescriptionTag = GetPar( "UserInfoResponseUserErrorDescriptionTag");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV19IsEnable, AV15ForceAuthn, AV51UserInfoResponseUserLastNameGenAuto, AV45UserInfoResponseUserErrorDescriptionTag, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
                  return  ;
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
            PA142( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS142( ) ;
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
            context.SendWebValue( "GAMWCAuthentication Type Entry Saml20") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281545597", false, true);
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwcauthenticationtypeentrysaml20.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV32Name)),UrlEncode(StringUtil.RTrim(AV41TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_229", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_229), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV66GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV32Name", StringUtil.RTrim( wcpOAV32Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV41TypeId", StringUtil.RTrim( wcpOAV41TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV41TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", StringUtil.RTrim( AV45UserInfoResponseUserErrorDescriptionTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Width", StringUtil.RTrim( Dvpanel_unnamedtable8_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Cls", StringUtil.RTrim( Dvpanel_unnamedtable8_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Title", StringUtil.RTrim( Dvpanel_unnamedtable8_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable8_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Width", StringUtil.RTrim( Dvpanel_unnamedtable4_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Cls", StringUtil.RTrim( Dvpanel_unnamedtable4_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Title", StringUtil.RTrim( Dvpanel_unnamedtable4_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable4_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Autoscroll));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm142( )
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
         return "GAMWCAuthenticationTypeEntrySaml20" ;
      }

      public override string GetPgmdesc( )
      {
         return "GAMWCAuthentication Type Entry Saml20" ;
      }

      protected void WB140( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "gamwcauthenticationtypeentrysaml20.aspx");
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
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV32Name), StringUtil.RTrim( context.localUtil.Format( AV32Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV16FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV16FunctionId);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV10Dsc), StringUtil.RTrim( context.localUtil.Format( AV10Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV19IsEnable), "", "Habilitado?", 1, chkavIsenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(34, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,34);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImpersonate_Internalname, StringUtil.RTrim( AV18Impersonate), StringUtil.RTrim( context.localUtil.Format( AV18Impersonate, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImpersonate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavImpersonate_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV40SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV40SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSmallimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV7BigImageName), StringUtil.RTrim( context.localUtil.Format( AV7BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavBigimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "Geral", "", "", lblGeneral_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavForceauthn_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavForceauthn_Internalname, "Forçar autenticação", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavForceauthn_Internalname, StringUtil.BoolToStr( AV15ForceAuthn), "", "Forçar autenticação", 1, chkavForceauthn.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAuthncontext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthncontext_Internalname, "Contexto de autenticação", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthncontext_Internalname, StringUtil.RTrim( AV6AuthnContext), StringUtil.RTrim( context.localUtil.Format( AV6AuthnContext, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthncontext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthncontext_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavLocalsiteurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocalsiteurl_Internalname, "Url local do site", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocalsiteurl_Internalname, AV30LocalSiteURL, StringUtil.RTrim( context.localUtil.Format( AV30LocalSiteURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocalsiteurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocalsiteurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavIdentityproviderentityid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavIdentityproviderentityid_Internalname, "Id do provedor de identidade", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavIdentityproviderentityid_Internalname, AV38IdentityProviderEntityID, StringUtil.RTrim( context.localUtil.Format( AV38IdentityProviderEntityID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavIdentityproviderentityid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavIdentityproviderentityid_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavServiceproviderentityid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServiceproviderentityid_Internalname, "Id da entidade proveedora de serviços", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServiceproviderentityid_Internalname, AV37ServiceProviderEntityID, StringUtil.RTrim( context.localUtil.Format( AV37ServiceProviderEntityID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServiceproviderentityid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavServiceproviderentityid_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSamlendpointlocation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSamlendpointlocation_Internalname, "Localização do ponto final do saml", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSamlendpointlocation_Internalname, AV36SamlEndpointLocation, StringUtil.RTrim( context.localUtil.Format( AV36SamlEndpointLocation, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSamlendpointlocation_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSamlendpointlocation_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            ucDvpanel_unnamedtable8.SetProperty("Width", Dvpanel_unnamedtable8_Width);
            ucDvpanel_unnamedtable8.SetProperty("AutoWidth", Dvpanel_unnamedtable8_Autowidth);
            ucDvpanel_unnamedtable8.SetProperty("AutoHeight", Dvpanel_unnamedtable8_Autoheight);
            ucDvpanel_unnamedtable8.SetProperty("Cls", Dvpanel_unnamedtable8_Cls);
            ucDvpanel_unnamedtable8.SetProperty("Title", Dvpanel_unnamedtable8_Title);
            ucDvpanel_unnamedtable8.SetProperty("Collapsible", Dvpanel_unnamedtable8_Collapsible);
            ucDvpanel_unnamedtable8.SetProperty("Collapsed", Dvpanel_unnamedtable8_Collapsed);
            ucDvpanel_unnamedtable8.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable8_Showcollapseicon);
            ucDvpanel_unnamedtable8.SetProperty("IconPosition", Dvpanel_unnamedtable8_Iconposition);
            ucDvpanel_unnamedtable8.SetProperty("AutoScroll", Dvpanel_unnamedtable8_Autoscroll);
            ucDvpanel_unnamedtable8.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable8_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE8Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE8Container"+"UnnamedTable8"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSinglelogoutendpoint_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSinglelogoutendpoint_Internalname, "O endpoint de feche da sessão é único?", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSinglelogoutendpoint_Internalname, AV39SingleLogoutendpoint, StringUtil.RTrim( context.localUtil.Format( AV39SingleLogoutendpoint, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSinglelogoutendpoint_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSinglelogoutendpoint_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCredentials_title_Internalname, "Credenciais", "", "", lblCredentials_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Credentials") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable4.SetProperty("Width", Dvpanel_unnamedtable4_Width);
            ucDvpanel_unnamedtable4.SetProperty("AutoWidth", Dvpanel_unnamedtable4_Autowidth);
            ucDvpanel_unnamedtable4.SetProperty("AutoHeight", Dvpanel_unnamedtable4_Autoheight);
            ucDvpanel_unnamedtable4.SetProperty("Cls", Dvpanel_unnamedtable4_Cls);
            ucDvpanel_unnamedtable4.SetProperty("Title", Dvpanel_unnamedtable4_Title);
            ucDvpanel_unnamedtable4.SetProperty("Collapsible", Dvpanel_unnamedtable4_Collapsible);
            ucDvpanel_unnamedtable4.SetProperty("Collapsed", Dvpanel_unnamedtable4_Collapsed);
            ucDvpanel_unnamedtable4.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable4_Showcollapseicon);
            ucDvpanel_unnamedtable4.SetProperty("IconPosition", Dvpanel_unnamedtable4_Iconposition);
            ucDvpanel_unnamedtable4.SetProperty("AutoScroll", Dvpanel_unnamedtable4_Autoscroll);
            ucDvpanel_unnamedtable4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable4_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE4Container"+"UnnamedTable4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeystpathcredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystpathcredential_Internalname, "Caminho do keystore", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystpathcredential_Internalname, AV28KeyStPathCredential, StringUtil.RTrim( context.localUtil.Format( AV28KeyStPathCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystpathcredential_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeystpathcredential_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeystpwdcredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystpwdcredential_Internalname, "Senha do armazenamento de chaves", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystpwdcredential_Internalname, StringUtil.RTrim( AV29KeyStPwdCredential), StringUtil.RTrim( context.localUtil.Format( AV29KeyStPwdCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystpwdcredential_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeystpwdcredential_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeyaliascredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeyaliascredential_Internalname, "Certificado de pseudónimo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeyaliascredential_Internalname, StringUtil.RTrim( AV21KeyAliasCredential), StringUtil.RTrim( context.localUtil.Format( AV21KeyAliasCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeyaliascredential_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeyaliascredential_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeystorecredential_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystorecredential_Internalname, "Formato do armazenamento de chaves", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystorecredential_Internalname, StringUtil.RTrim( AV24KeyStoreCredential), StringUtil.RTrim( context.localUtil.Format( AV24KeyStoreCredential, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystorecredential_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeystorecredential_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeystorefilepathtrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystorefilepathtrustcred_Internalname, "Caminho do armazen de confiança", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystorefilepathtrustcred_Internalname, AV25KeyStoreFilePathTrustCred, StringUtil.RTrim( context.localUtil.Format( AV25KeyStoreFilePathTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystorefilepathtrustcred_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeystorefilepathtrustcred_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeystorepwdtrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystorepwdtrustcred_Internalname, "Senha do armazen de confiança", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystorepwdtrustcred_Internalname, StringUtil.RTrim( AV26KeyStorePwdTrustCred), StringUtil.RTrim( context.localUtil.Format( AV26KeyStorePwdTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystorepwdtrustcred_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeystorepwdtrustcred_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeyaliastrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeyaliastrustcred_Internalname, "Certificado de pseudónimo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeyaliastrustcred_Internalname, StringUtil.RTrim( AV22KeyAliasTrustCred), StringUtil.RTrim( context.localUtil.Format( AV22KeyAliasTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeyaliastrustcred_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeyaliastrustcred_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavKeystoretrustcred_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKeystoretrustcred_Internalname, "Formato do armazen de confiança", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKeystoretrustcred_Internalname, StringUtil.RTrim( AV27KeyStoreTrustCred), StringUtil.RTrim( context.localUtil.Format( AV27KeyStoreTrustCred, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKeystoretrustcred_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavKeystoretrustcred_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUserinfo_title_Internalname, "Resposta da informação do usuário", "", "", lblUserinfo_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "UserInfo") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuseremailtag_Internalname, StringUtil.RTrim( AV44UserInfoResponseUserEmailTag), StringUtil.RTrim( context.localUtil.Format( AV44UserInfoResponseUserEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuseremailtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuseremailtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserexternalidtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserexternalidtag_Internalname, "Tag de id externo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserexternalidtag_Internalname, StringUtil.RTrim( AV46UserInfoResponseUserExternalIdTag), StringUtil.RTrim( context.localUtil.Format( AV46UserInfoResponseUserExternalIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserexternalidtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserexternalidtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseusernametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusernametag_Internalname, "Tag do nome do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusernametag_Internalname, StringUtil.RTrim( AV53UserInfoResponseUserNameTag), StringUtil.RTrim( context.localUtil.Format( AV53UserInfoResponseUserNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusernametag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusernametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserfirstnametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserfirstnametag_Internalname, "Tag do nome do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserfirstnametag_Internalname, StringUtil.RTrim( AV47UserInfoResponseUserFirstNameTag), StringUtil.RTrim( context.localUtil.Format( AV47UserInfoResponseUserFirstNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserfirstnametag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserfirstnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinforesponseuserlastnamegenauto_Internalname, StringUtil.BoolToStr( AV51UserInfoResponseUserLastNameGenAuto), "", "Gerar automaticamente o sobrenome", 1, chkavUserinforesponseuserlastnamegenauto.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(175, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,175);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlastnametag_Internalname, StringUtil.RTrim( AV52UserInfoResponseUserLastNameTag), StringUtil.RTrim( context.localUtil.Format( AV52UserInfoResponseUserLastNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlastnametag_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserinforesponseuserlastnametag_Visible, edtavUserinforesponseuserlastnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendertag_Internalname, StringUtil.RTrim( AV48UserInfoResponseUserGenderTag), StringUtil.RTrim( context.localUtil.Format( AV48UserInfoResponseUserGenderTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendertag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusergendertag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendervalues_Internalname, AV49UserInfoResponseUserGenderValues, StringUtil.RTrim( context.localUtil.Format( AV49UserInfoResponseUserGenderValues, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,188);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendervalues_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusergendervalues_Enabled, 1, "text", "", 0, "px", 1, "row", 400, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserbirthdaytag_Internalname, StringUtil.RTrim( AV43UserInfoResponseUserBirthdayTag), StringUtil.RTrim( context.localUtil.Format( AV43UserInfoResponseUserBirthdayTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,193);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserbirthdaytag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserbirthdaytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlimagetag_Internalname, StringUtil.RTrim( AV55UserInfoResponseUserURLImageTag), StringUtil.RTrim( context.localUtil.Format( AV55UserInfoResponseUserURLImageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,197);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlimagetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserurlimagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlprofiletag_Internalname, StringUtil.RTrim( AV56UserInfoResponseUserURLProfileTag), StringUtil.RTrim( context.localUtil.Format( AV56UserInfoResponseUserURLProfileTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,202);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlprofiletag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserurlprofiletag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlanguagetag_Internalname, StringUtil.RTrim( AV50UserInfoResponseUserLanguageTag), StringUtil.RTrim( context.localUtil.Format( AV50UserInfoResponseUserLanguageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlanguagetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserlanguagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusertimezonetag_Internalname, StringUtil.RTrim( AV54UserInfoResponseUserTimeZoneTag), StringUtil.RTrim( context.localUtil.Format( AV54UserInfoResponseUserTimeZoneTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusertimezonetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusertimezonetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 215,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV42UserInfoResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV42UserInfoResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,215);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseerrordescriptiontag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseerrordescriptiontag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 223,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(229), 3, 0)+","+"null"+");", "Inserir", bttBtnadd_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtnadd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"229\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDynamicpropname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nome do atributo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDynamicproptag_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Tag do atributo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionBaseColorAttribute"+"\" "+" style=\""+((edtavDeleteproperty_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV11DynamicPropName));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12DynamicPropTag));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV65DeleteProperty));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeleteproperty_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDeleteproperty_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeleteproperty_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 229 )
         {
            wbEnd = 0;
            nRC_GXsfl_229 = (int)(nGXsfl_229_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV63GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV64GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV66GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 240,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(229), 3, 0)+","+"null"+");", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 242,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(229), 3, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'" + sPrefix + "',false,'" + sGXsfl_229_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridcurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63GridCurrentPage), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV63GridCurrentPage), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,246);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridcurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridcurrentpage_Visible, 1, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMWCAuthenticationTypeEntrySaml20.htm");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 229 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START142( )
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
               Form.Meta.addItem("description", "GAMWCAuthentication Type Entry Saml20", 0) ;
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
               STRUP140( ) ;
            }
         }
      }

      protected void WS142( )
      {
         START142( ) ;
         EVT142( ) ;
      }

      protected void EVT142( )
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
                                 STRUP140( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11142 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E12142 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAdd' */
                                    E13142 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
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
                                          E14142 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDynamicpropname_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VDELETEPROPERTY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VDELETEPROPERTY.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              nGXsfl_229_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_229_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_229_idx), 4, 0), 4, "0");
                              SubsflControlProps_2292( ) ;
                              AV11DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV11DynamicPropName);
                              AV12DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV12DynamicPropTag);
                              AV65DeleteProperty = cgiGet( edtavDeleteproperty_Internalname);
                              AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty)) ? AV71Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV65DeleteProperty))), !bGXsfl_229_Refreshing);
                              AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV65DeleteProperty), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E15142 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E16142 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E17142 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETEPROPERTY.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E18142 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP140( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE142( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm142( ) ;
            }
         }
      }

      protected void PA142( )
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2292( ) ;
         while ( nGXsfl_229_idx <= nRC_GXsfl_229 )
         {
            sendrow_2292( ) ;
            nGXsfl_229_idx = ((subGrid_Islastpage==1)&&(nGXsfl_229_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_229_idx+1);
            sGXsfl_229_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_229_idx), 4, 0), 4, "0");
            SubsflControlProps_2292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string Gx_mode ,
                                       bool AV19IsEnable ,
                                       bool AV15ForceAuthn ,
                                       bool AV51UserInfoResponseUserLastNameGenAuto ,
                                       string AV45UserInfoResponseUserErrorDescriptionTag ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E16142 ();
         GRID_nCurrentRecord = 0;
         RF142( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
            AV16FunctionId = cmbavFunctionid.getValidValue(AV16FunctionId);
            AssignAttri(sPrefix, false, "AV16FunctionId", AV16FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV16FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV19IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV19IsEnable));
         AssignAttri(sPrefix, false, "AV19IsEnable", AV19IsEnable);
         AV15ForceAuthn = StringUtil.StrToBool( StringUtil.BoolToStr( AV15ForceAuthn));
         AssignAttri(sPrefix, false, "AV15ForceAuthn", AV15ForceAuthn);
         AV51UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( StringUtil.BoolToStr( AV51UserInfoResponseUserLastNameGenAuto));
         AssignAttri(sPrefix, false, "AV51UserInfoResponseUserLastNameGenAuto", AV51UserInfoResponseUserLastNameGenAuto);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF142( ) ;
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

      protected void RF142( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 229;
         /* Execute user event: Refresh */
         E16142 ();
         nGXsfl_229_idx = 1;
         sGXsfl_229_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_229_idx), 4, 0), 4, "0");
         SubsflControlProps_2292( ) ;
         bGXsfl_229_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_2292( ) ;
            E17142 ();
            if ( ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_229_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E17142 ();
            }
            wbEnd = 229;
            WB140( ) ;
         }
         bGXsfl_229_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes142( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", StringUtil.RTrim( AV45UserInfoResponseUserErrorDescriptionTag));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(((subGrid_Islastpage==1) ? subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( ))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : (decimal)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1))) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV19IsEnable, AV15ForceAuthn, AV51UserInfoResponseUserLastNameGenAuto, AV45UserInfoResponseUserErrorDescriptionTag, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV19IsEnable, AV15ForceAuthn, AV51UserInfoResponseUserLastNameGenAuto, AV45UserInfoResponseUserErrorDescriptionTag, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV19IsEnable, AV15ForceAuthn, AV51UserInfoResponseUserLastNameGenAuto, AV45UserInfoResponseUserErrorDescriptionTag, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV19IsEnable, AV15ForceAuthn, AV51UserInfoResponseUserLastNameGenAuto, AV45UserInfoResponseUserErrorDescriptionTag, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV19IsEnable, AV15ForceAuthn, AV51UserInfoResponseUserLastNameGenAuto, AV45UserInfoResponseUserErrorDescriptionTag, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP140( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15142 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_229 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_229"), ",", "."));
            AV64GridPageCount = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."));
            AV66GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV32Name = cgiGet( sPrefix+"wcpOAV32Name");
            wcpOAV41TypeId = cgiGet( sPrefix+"wcpOAV41TypeId");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Dvpanel_unnamedtable8_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Width");
            Dvpanel_unnamedtable8_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Autowidth"));
            Dvpanel_unnamedtable8_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoheight"));
            Dvpanel_unnamedtable8_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Cls");
            Dvpanel_unnamedtable8_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Title");
            Dvpanel_unnamedtable8_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsible"));
            Dvpanel_unnamedtable8_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsed"));
            Dvpanel_unnamedtable8_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Showcollapseicon"));
            Dvpanel_unnamedtable8_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Iconposition");
            Dvpanel_unnamedtable8_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoscroll"));
            Dvpanel_unnamedtable4_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Width");
            Dvpanel_unnamedtable4_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Autowidth"));
            Dvpanel_unnamedtable4_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoheight"));
            Dvpanel_unnamedtable4_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Cls");
            Dvpanel_unnamedtable4_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Title");
            Dvpanel_unnamedtable4_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsible"));
            Dvpanel_unnamedtable4_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsed"));
            Dvpanel_unnamedtable4_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Showcollapseicon"));
            Dvpanel_unnamedtable4_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Iconposition");
            Dvpanel_unnamedtable4_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoscroll"));
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
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), ",", "."));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
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
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            /* Read variables values. */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV32Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV32Name", AV32Name);
            }
            cmbavFunctionid.Name = cmbavFunctionid_Internalname;
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV16FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV16FunctionId", AV16FunctionId);
            AV10Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV10Dsc", AV10Dsc);
            AV19IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV19IsEnable", AV19IsEnable);
            AV18Impersonate = cgiGet( edtavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV18Impersonate", AV18Impersonate);
            AV40SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV40SmallImageName", AV40SmallImageName);
            AV7BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV7BigImageName", AV7BigImageName);
            AV15ForceAuthn = StringUtil.StrToBool( cgiGet( chkavForceauthn_Internalname));
            AssignAttri(sPrefix, false, "AV15ForceAuthn", AV15ForceAuthn);
            AV6AuthnContext = cgiGet( edtavAuthncontext_Internalname);
            AssignAttri(sPrefix, false, "AV6AuthnContext", AV6AuthnContext);
            AV30LocalSiteURL = cgiGet( edtavLocalsiteurl_Internalname);
            AssignAttri(sPrefix, false, "AV30LocalSiteURL", AV30LocalSiteURL);
            AV38IdentityProviderEntityID = cgiGet( edtavIdentityproviderentityid_Internalname);
            AssignAttri(sPrefix, false, "AV38IdentityProviderEntityID", AV38IdentityProviderEntityID);
            AV37ServiceProviderEntityID = cgiGet( edtavServiceproviderentityid_Internalname);
            AssignAttri(sPrefix, false, "AV37ServiceProviderEntityID", AV37ServiceProviderEntityID);
            AV36SamlEndpointLocation = cgiGet( edtavSamlendpointlocation_Internalname);
            AssignAttri(sPrefix, false, "AV36SamlEndpointLocation", AV36SamlEndpointLocation);
            AV39SingleLogoutendpoint = cgiGet( edtavSinglelogoutendpoint_Internalname);
            AssignAttri(sPrefix, false, "AV39SingleLogoutendpoint", AV39SingleLogoutendpoint);
            AV28KeyStPathCredential = cgiGet( edtavKeystpathcredential_Internalname);
            AssignAttri(sPrefix, false, "AV28KeyStPathCredential", AV28KeyStPathCredential);
            AV29KeyStPwdCredential = cgiGet( edtavKeystpwdcredential_Internalname);
            AssignAttri(sPrefix, false, "AV29KeyStPwdCredential", AV29KeyStPwdCredential);
            AV21KeyAliasCredential = cgiGet( edtavKeyaliascredential_Internalname);
            AssignAttri(sPrefix, false, "AV21KeyAliasCredential", AV21KeyAliasCredential);
            AV24KeyStoreCredential = cgiGet( edtavKeystorecredential_Internalname);
            AssignAttri(sPrefix, false, "AV24KeyStoreCredential", AV24KeyStoreCredential);
            AV25KeyStoreFilePathTrustCred = cgiGet( edtavKeystorefilepathtrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV25KeyStoreFilePathTrustCred", AV25KeyStoreFilePathTrustCred);
            AV26KeyStorePwdTrustCred = cgiGet( edtavKeystorepwdtrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV26KeyStorePwdTrustCred", AV26KeyStorePwdTrustCred);
            AV22KeyAliasTrustCred = cgiGet( edtavKeyaliastrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV22KeyAliasTrustCred", AV22KeyAliasTrustCred);
            AV27KeyStoreTrustCred = cgiGet( edtavKeystoretrustcred_Internalname);
            AssignAttri(sPrefix, false, "AV27KeyStoreTrustCred", AV27KeyStoreTrustCred);
            AV44UserInfoResponseUserEmailTag = cgiGet( edtavUserinforesponseuseremailtag_Internalname);
            AssignAttri(sPrefix, false, "AV44UserInfoResponseUserEmailTag", AV44UserInfoResponseUserEmailTag);
            AV46UserInfoResponseUserExternalIdTag = cgiGet( edtavUserinforesponseuserexternalidtag_Internalname);
            AssignAttri(sPrefix, false, "AV46UserInfoResponseUserExternalIdTag", AV46UserInfoResponseUserExternalIdTag);
            AV53UserInfoResponseUserNameTag = cgiGet( edtavUserinforesponseusernametag_Internalname);
            AssignAttri(sPrefix, false, "AV53UserInfoResponseUserNameTag", AV53UserInfoResponseUserNameTag);
            AV47UserInfoResponseUserFirstNameTag = cgiGet( edtavUserinforesponseuserfirstnametag_Internalname);
            AssignAttri(sPrefix, false, "AV47UserInfoResponseUserFirstNameTag", AV47UserInfoResponseUserFirstNameTag);
            AV51UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( cgiGet( chkavUserinforesponseuserlastnamegenauto_Internalname));
            AssignAttri(sPrefix, false, "AV51UserInfoResponseUserLastNameGenAuto", AV51UserInfoResponseUserLastNameGenAuto);
            AV52UserInfoResponseUserLastNameTag = cgiGet( edtavUserinforesponseuserlastnametag_Internalname);
            AssignAttri(sPrefix, false, "AV52UserInfoResponseUserLastNameTag", AV52UserInfoResponseUserLastNameTag);
            AV48UserInfoResponseUserGenderTag = cgiGet( edtavUserinforesponseusergendertag_Internalname);
            AssignAttri(sPrefix, false, "AV48UserInfoResponseUserGenderTag", AV48UserInfoResponseUserGenderTag);
            AV49UserInfoResponseUserGenderValues = cgiGet( edtavUserinforesponseusergendervalues_Internalname);
            AssignAttri(sPrefix, false, "AV49UserInfoResponseUserGenderValues", AV49UserInfoResponseUserGenderValues);
            AV43UserInfoResponseUserBirthdayTag = cgiGet( edtavUserinforesponseuserbirthdaytag_Internalname);
            AssignAttri(sPrefix, false, "AV43UserInfoResponseUserBirthdayTag", AV43UserInfoResponseUserBirthdayTag);
            AV55UserInfoResponseUserURLImageTag = cgiGet( edtavUserinforesponseuserurlimagetag_Internalname);
            AssignAttri(sPrefix, false, "AV55UserInfoResponseUserURLImageTag", AV55UserInfoResponseUserURLImageTag);
            AV56UserInfoResponseUserURLProfileTag = cgiGet( edtavUserinforesponseuserurlprofiletag_Internalname);
            AssignAttri(sPrefix, false, "AV56UserInfoResponseUserURLProfileTag", AV56UserInfoResponseUserURLProfileTag);
            AV50UserInfoResponseUserLanguageTag = cgiGet( edtavUserinforesponseuserlanguagetag_Internalname);
            AssignAttri(sPrefix, false, "AV50UserInfoResponseUserLanguageTag", AV50UserInfoResponseUserLanguageTag);
            AV54UserInfoResponseUserTimeZoneTag = cgiGet( edtavUserinforesponseusertimezonetag_Internalname);
            AssignAttri(sPrefix, false, "AV54UserInfoResponseUserTimeZoneTag", AV54UserInfoResponseUserTimeZoneTag);
            AV42UserInfoResponseErrorDescriptionTag = cgiGet( edtavUserinforesponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV42UserInfoResponseErrorDescriptionTag", AV42UserInfoResponseErrorDescriptionTag);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDCURRENTPAGE");
               GX_FocusControl = edtavGridcurrentpage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV63GridCurrentPage = 0;
               AssignAttri(sPrefix, false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
            }
            else
            {
               AV63GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E15142 ();
         if (returnInSub) return;
      }

      protected void E15142( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'INITAUTHENTICATIONSAML' */
         S112 ();
         if (returnInSub) return;
         AV16FunctionId = "OnlyAuthentication";
         AssignAttri(sPrefix, false, "AV16FunctionId", AV16FunctionId);
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               bttBtnenter_Visible = 0;
               AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            }
            bttBtnadd_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadd_Visible), 5, 0), true);
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
            edtavServiceproviderentityid_Enabled = 0;
            AssignProp(sPrefix, false, edtavServiceproviderentityid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavServiceproviderentityid_Enabled), 5, 0), true);
            edtavIdentityproviderentityid_Enabled = 0;
            AssignProp(sPrefix, false, edtavIdentityproviderentityid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavIdentityproviderentityid_Enabled), 5, 0), true);
            edtavSamlendpointlocation_Enabled = 0;
            AssignProp(sPrefix, false, edtavSamlendpointlocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSamlendpointlocation_Enabled), 5, 0), true);
            edtavSinglelogoutendpoint_Enabled = 0;
            AssignProp(sPrefix, false, edtavSinglelogoutendpoint_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSinglelogoutendpoint_Enabled), 5, 0), true);
            edtavLocalsiteurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavLocalsiteurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocalsiteurl_Enabled), 5, 0), true);
            edtavKeystpathcredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystpathcredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystpathcredential_Enabled), 5, 0), true);
            edtavKeystpwdcredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystpwdcredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystpwdcredential_Enabled), 5, 0), true);
            edtavKeyaliascredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeyaliascredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeyaliascredential_Enabled), 5, 0), true);
            edtavKeystorecredential_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystorecredential_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystorecredential_Enabled), 5, 0), true);
            edtavKeystorefilepathtrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystorefilepathtrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystorefilepathtrustcred_Enabled), 5, 0), true);
            edtavKeystorepwdtrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystorepwdtrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystorepwdtrustcred_Enabled), 5, 0), true);
            edtavKeyaliastrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeyaliastrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeyaliastrustcred_Enabled), 5, 0), true);
            edtavKeystoretrustcred_Enabled = 0;
            AssignProp(sPrefix, false, edtavKeystoretrustcred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKeystoretrustcred_Enabled), 5, 0), true);
            chkavForceauthn.Enabled = 0;
            AssignProp(sPrefix, false, chkavForceauthn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavForceauthn.Enabled), 5, 0), true);
            edtavAuthncontext_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthncontext_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthncontext_Enabled), 5, 0), true);
            edtavUserinforesponseuserbirthdaytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserbirthdaytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserbirthdaytag_Enabled), 5, 0), true);
            edtavUserinforesponseuseremailtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuseremailtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuseremailtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserexternalidtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserexternalidtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserexternalidtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserfirstnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserfirstnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserfirstnametag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendertag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendertag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendertag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendervalues_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendervalues_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendervalues_Enabled), 5, 0), true);
            edtavUserinforesponseuserlanguagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlanguagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlanguagetag_Enabled), 5, 0), true);
            chkavUserinforesponseuserlastnamegenauto.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinforesponseuserlastnamegenauto.Enabled), 5, 0), true);
            edtavUserinforesponseuserlastnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Enabled), 5, 0), true);
            edtavUserinforesponseusernametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusernametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusernametag_Enabled), 5, 0), true);
            edtavUserinforesponseusertimezonetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusertimezonetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusertimezonetag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlimagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlimagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlimagetag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlprofiletag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlprofiletag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlprofiletag_Enabled), 5, 0), true);
            edtavUserinforesponseerrordescriptiontag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseerrordescriptiontag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseerrordescriptiontag_Enabled), 5, 0), true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               edtavName_Enabled = 1;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
            else
            {
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV63GridCurrentPage = 1;
         AssignAttri(sPrefix, false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
         edtavGridcurrentpage_Visible = 0;
         AssignProp(sPrefix, false, edtavGridcurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridcurrentpage_Visible), 5, 0), true);
         AV64GridPageCount = -1;
         AssignAttri(sPrefix, false, "AV64GridPageCount", StringUtil.LTrimStr( (decimal)(AV64GridPageCount), 10, 0));
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16142( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         edtavDeleteproperty_Enabled = 0;
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeleteproperty_Enabled), 5, 0), !bGXsfl_229_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E17142( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserproperties.Count )
         {
            AV17GAMPropertySimple = ((GeneXus.Programs.genexussecurity.SdtGAMPropertySimple)AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserproperties.Item(AV70GXV1));
            AV65DeleteProperty = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavDeleteproperty_Internalname, AV65DeleteProperty);
            AV71Deleteproperty_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( )));
            edtavDeleteproperty_Tooltiptext = "";
            AV11DynamicPropName = AV17GAMPropertySimple.gxTpr_Id;
            AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV11DynamicPropName);
            AV12DynamicPropTag = AV17GAMPropertySimple.gxTpr_Value;
            AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV12DynamicPropTag);
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtavDeleteproperty_Visible = 0;
               edtavDynamicpropname_Enabled = 0;
               edtavDynamicproptag_Enabled = 0;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 229;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_2292( ) ;
               GRID_nEOF = 1;
               GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
               {
                  GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
               }
            }
            if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
            {
               GRID_nEOF = 0;
               GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            }
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_229_Refreshing )
            {
               context.DoAjaxLoad(229, GridRow);
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E11142( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV63GridCurrentPage = (long)(AV63GridCurrentPage-1);
            AssignAttri(sPrefix, false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            AV63GridCurrentPage = (long)(AV63GridCurrentPage+1);
            AssignAttri(sPrefix, false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
            subgrid_nextpage( ) ;
         }
         else
         {
            AV62PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            AV63GridCurrentPage = AV62PageToGo;
            AssignAttri(sPrefix, false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
            subgrid_gotopage( AV62PageToGo) ;
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E12142( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV63GridCurrentPage = 1;
         AssignAttri(sPrefix, false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13142( )
      {
         /* 'DoAdd' Routine */
         returnInSub = false;
         AV65DeleteProperty = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty)) ? AV71Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV65DeleteProperty))), !bGXsfl_229_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV65DeleteProperty), true);
         AV71Deleteproperty_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty)) ? AV71Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV65DeleteProperty))), !bGXsfl_229_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV65DeleteProperty), true);
         edtavDeleteproperty_Visible = 1;
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDeleteproperty_Visible), 5, 0), !bGXsfl_229_Refreshing);
         edtavDynamicpropname_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_229_Refreshing);
         edtavDynamicpropname_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_229_Refreshing);
         edtavDynamicproptag_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_229_Refreshing);
         edtavDynamicproptag_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_229_Refreshing);
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            sendrow_2292( ) ;
            GRID_nEOF = 1;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
            {
               GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
            }
         }
         if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         }
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_229_Refreshing )
         {
            context.DoAjaxLoad(229, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! AV51UserInfoResponseUserLastNameGenAuto ) )
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
         E14142 ();
         if (returnInSub) return;
      }

      protected void E14142( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            /* Execute user subroutine: 'SAVEAUTHENTICATIONSAML' */
            S132 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV5AuthenticationTypeSaml20.load( AV32Name);
            AV5AuthenticationTypeSaml20.delete();
         }
         if ( AV5AuthenticationTypeSaml20.success() && ( AV14Errors.Count == 0 ) )
         {
            context.CommitDataStores("gamwcauthenticationtypeentrysaml20",pr_default);
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV32Name,(string)AV41TypeId});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV32Name","AV41TypeId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV14Errors = AV5AuthenticationTypeSaml20.geterrors();
            AV72GXV2 = 1;
            while ( AV72GXV2 <= AV14Errors.Count )
            {
               AV13Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14Errors.Item(AV72GXV2));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV13Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV13Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV72GXV2 = (int)(AV72GXV2+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AuthenticationTypeSaml20", AV5AuthenticationTypeSaml20);
      }

      protected void E18142( )
      {
         /* Deleteproperty_Click Routine */
         returnInSub = false;
         AV65DeleteProperty = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty)) ? AV71Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV65DeleteProperty))), !bGXsfl_229_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV65DeleteProperty), true);
         AV71Deleteproperty_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( )));
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty)) ? AV71Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV65DeleteProperty))), !bGXsfl_229_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV65DeleteProperty), true);
         edtavDeleteproperty_Visible = 0;
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDeleteproperty_Visible), 5, 0), !bGXsfl_229_Refreshing);
         edtavDynamicpropname_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_229_Refreshing);
         edtavDynamicproptag_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_229_Refreshing);
         AV11DynamicPropName = "";
         AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV11DynamicPropName);
         AV12DynamicPropTag = "";
         AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV12DynamicPropTag);
         AV5AuthenticationTypeSaml20.gxTpr_Name = AV32Name;
         AV5AuthenticationTypeSaml20.removeuserinfoproperty( AV11DynamicPropName, out  AV14Errors);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AuthenticationTypeSaml20", AV5AuthenticationTypeSaml20);
      }

      protected void S112( )
      {
         /* 'INITAUTHENTICATIONSAML' Routine */
         returnInSub = false;
         AV5AuthenticationTypeSaml20.load( AV32Name);
         AV32Name = AV5AuthenticationTypeSaml20.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV32Name", AV32Name);
         AV19IsEnable = AV5AuthenticationTypeSaml20.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV19IsEnable", AV19IsEnable);
         AV10Dsc = AV5AuthenticationTypeSaml20.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV10Dsc", AV10Dsc);
         AV40SmallImageName = AV5AuthenticationTypeSaml20.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV40SmallImageName", AV40SmallImageName);
         AV7BigImageName = AV5AuthenticationTypeSaml20.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV7BigImageName", AV7BigImageName);
         AV18Impersonate = AV5AuthenticationTypeSaml20.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV18Impersonate", AV18Impersonate);
         AV37ServiceProviderEntityID = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Serviceproviderentityid;
         AssignAttri(sPrefix, false, "AV37ServiceProviderEntityID", AV37ServiceProviderEntityID);
         AV38IdentityProviderEntityID = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Identityproviderentityid;
         AssignAttri(sPrefix, false, "AV38IdentityProviderEntityID", AV38IdentityProviderEntityID);
         AV6AuthnContext = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Authncontext;
         AssignAttri(sPrefix, false, "AV6AuthnContext", AV6AuthnContext);
         AV15ForceAuthn = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Forceauthn;
         AssignAttri(sPrefix, false, "AV15ForceAuthn", AV15ForceAuthn);
         AV21KeyAliasCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliascredential;
         AssignAttri(sPrefix, false, "AV21KeyAliasCredential", AV21KeyAliasCredential);
         AV22KeyAliasTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliastrustcred;
         AssignAttri(sPrefix, false, "AV22KeyAliasTrustCred", AV22KeyAliasTrustCred);
         AV24KeyStoreCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorecredential;
         AssignAttri(sPrefix, false, "AV24KeyStoreCredential", AV24KeyStoreCredential);
         AV25KeyStoreFilePathTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorefilepathtrustcred;
         AssignAttri(sPrefix, false, "AV25KeyStoreFilePathTrustCred", AV25KeyStoreFilePathTrustCred);
         AV26KeyStorePwdTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorepwdtrustcred;
         AssignAttri(sPrefix, false, "AV26KeyStorePwdTrustCred", AV26KeyStorePwdTrustCred);
         AV27KeyStoreTrustCred = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystoretrustcred;
         AssignAttri(sPrefix, false, "AV27KeyStoreTrustCred", AV27KeyStoreTrustCred);
         AV28KeyStPathCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpathcredential;
         AssignAttri(sPrefix, false, "AV28KeyStPathCredential", AV28KeyStPathCredential);
         AV29KeyStPwdCredential = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpwdcredential;
         AssignAttri(sPrefix, false, "AV29KeyStPwdCredential", AV29KeyStPwdCredential);
         AV36SamlEndpointLocation = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Samlendpointlocation;
         AssignAttri(sPrefix, false, "AV36SamlEndpointLocation", AV36SamlEndpointLocation);
         AV30LocalSiteURL = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Localsiteurl;
         AssignAttri(sPrefix, false, "AV30LocalSiteURL", AV30LocalSiteURL);
         AV39SingleLogoutendpoint = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Singlelogoutendpoint;
         AssignAttri(sPrefix, false, "AV39SingleLogoutendpoint", AV39SingleLogoutendpoint);
         AV45UserInfoResponseUserErrorDescriptionTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV45UserInfoResponseUserErrorDescriptionTag", AV45UserInfoResponseUserErrorDescriptionTag);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45UserInfoResponseUserErrorDescriptionTag, "")), context));
         AV43UserInfoResponseUserBirthdayTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name;
         AssignAttri(sPrefix, false, "AV43UserInfoResponseUserBirthdayTag", AV43UserInfoResponseUserBirthdayTag);
         AV44UserInfoResponseUserEmailTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuseremail_name;
         AssignAttri(sPrefix, false, "AV44UserInfoResponseUserEmailTag", AV44UserInfoResponseUserEmailTag);
         AV46UserInfoResponseUserExternalIdTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name;
         AssignAttri(sPrefix, false, "AV46UserInfoResponseUserExternalIdTag", AV46UserInfoResponseUserExternalIdTag);
         AV47UserInfoResponseUserFirstNameTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name;
         AssignAttri(sPrefix, false, "AV47UserInfoResponseUserFirstNameTag", AV47UserInfoResponseUserFirstNameTag);
         AV48UserInfoResponseUserGenderTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_name;
         AssignAttri(sPrefix, false, "AV48UserInfoResponseUserGenderTag", AV48UserInfoResponseUserGenderTag);
         AV49UserInfoResponseUserGenderValues = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_values;
         AssignAttri(sPrefix, false, "AV49UserInfoResponseUserGenderValues", AV49UserInfoResponseUserGenderValues);
         AV50UserInfoResponseUserLanguageTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name;
         AssignAttri(sPrefix, false, "AV50UserInfoResponseUserLanguageTag", AV50UserInfoResponseUserLanguageTag);
         AV51UserInfoResponseUserLastNameGenAuto = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic;
         AssignAttri(sPrefix, false, "AV51UserInfoResponseUserLastNameGenAuto", AV51UserInfoResponseUserLastNameGenAuto);
         AV52UserInfoResponseUserLastNameTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name;
         AssignAttri(sPrefix, false, "AV52UserInfoResponseUserLastNameTag", AV52UserInfoResponseUserLastNameTag);
         AV53UserInfoResponseUserNameTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusername_name;
         AssignAttri(sPrefix, false, "AV53UserInfoResponseUserNameTag", AV53UserInfoResponseUserNameTag);
         AV54UserInfoResponseUserTimeZoneTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name;
         AssignAttri(sPrefix, false, "AV54UserInfoResponseUserTimeZoneTag", AV54UserInfoResponseUserTimeZoneTag);
         AV55UserInfoResponseUserURLImageTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name;
         AssignAttri(sPrefix, false, "AV55UserInfoResponseUserURLImageTag", AV55UserInfoResponseUserURLImageTag);
         AV56UserInfoResponseUserURLProfileTag = AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name;
         AssignAttri(sPrefix, false, "AV56UserInfoResponseUserURLProfileTag", AV56UserInfoResponseUserURLProfileTag);
      }

      protected void S132( )
      {
         /* 'SAVEAUTHENTICATIONSAML' Routine */
         returnInSub = false;
         AV5AuthenticationTypeSaml20.load( AV32Name);
         AV5AuthenticationTypeSaml20.gxTpr_Name = AV32Name;
         AV5AuthenticationTypeSaml20.gxTpr_Isenable = AV19IsEnable;
         AV5AuthenticationTypeSaml20.gxTpr_Description = AV10Dsc;
         AV5AuthenticationTypeSaml20.gxTpr_Smallimagename = AV40SmallImageName;
         AV5AuthenticationTypeSaml20.gxTpr_Bigimagename = AV7BigImageName;
         AV5AuthenticationTypeSaml20.gxTpr_Impersonate = AV18Impersonate;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Serviceproviderentityid = AV37ServiceProviderEntityID;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Identityproviderentityid = AV38IdentityProviderEntityID;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Authncontext = AV6AuthnContext;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Forceauthn = AV15ForceAuthn;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliascredential = AV21KeyAliasCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keyaliastrustcred = AV22KeyAliasTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorecredential = AV24KeyStoreCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorefilepathtrustcred = AV25KeyStoreFilePathTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystorepwdtrustcred = AV26KeyStorePwdTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystoretrustcred = AV27KeyStoreTrustCred;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpathcredential = AV28KeyStPathCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Keystpwdcredential = AV29KeyStPwdCredential;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Samlendpointlocation = AV36SamlEndpointLocation;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Singlelogoutendpoint = AV39SingleLogoutendpoint;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Localsiteurl = AV30LocalSiteURL;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name = AV45UserInfoResponseUserErrorDescriptionTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name = AV43UserInfoResponseUserBirthdayTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuseremail_name = AV44UserInfoResponseUserEmailTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name = AV46UserInfoResponseUserExternalIdTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name = AV47UserInfoResponseUserFirstNameTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_name = AV48UserInfoResponseUserGenderTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusergender_values = AV49UserInfoResponseUserGenderValues;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name = AV50UserInfoResponseUserLanguageTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic = AV51UserInfoResponseUserLastNameGenAuto;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name = AV52UserInfoResponseUserLastNameTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusername_name = AV53UserInfoResponseUserNameTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name = AV54UserInfoResponseUserTimeZoneTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name = AV55UserInfoResponseUserURLImageTag;
         AV5AuthenticationTypeSaml20.gxTpr_Saml20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name = AV56UserInfoResponseUserURLProfileTag;
         AV5AuthenticationTypeSaml20.save();
         /* Start For Each Line */
         nRC_GXsfl_229 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_229"), ",", "."));
         nGXsfl_229_fel_idx = 0;
         while ( nGXsfl_229_fel_idx < nRC_GXsfl_229 )
         {
            nGXsfl_229_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_229_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_229_fel_idx+1);
            sGXsfl_229_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_229_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_2292( ) ;
            AV11DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
            AV12DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
            AV65DeleteProperty = cgiGet( edtavDeleteproperty_Internalname);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11DynamicPropName)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12DynamicPropTag)) )
            {
               AV17GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
               AV17GAMPropertySimple.gxTpr_Id = AV11DynamicPropName;
               AV17GAMPropertySimple.gxTpr_Value = AV12DynamicPropTag;
               if ( ! AV5AuthenticationTypeSaml20.setuserinfoproperty(AV17GAMPropertySimple, out  AV14Errors) )
               {
                  AV74GXV3 = 1;
                  while ( AV74GXV3 <= AV14Errors.Count )
                  {
                     AV13Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14Errors.Item(AV74GXV3));
                     context.StatusMessage( StringUtil.Format( "%1 (GAM%2)", AV13Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV13Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", "") );
                     AV74GXV3 = (int)(AV74GXV3+1);
                  }
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_229_fel_idx == 0 )
         {
            nGXsfl_229_idx = 1;
            sGXsfl_229_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_229_idx), 4, 0), 4, "0");
            SubsflControlProps_2292( ) ;
         }
         nGXsfl_229_fel_idx = 1;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV32Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV32Name", AV32Name);
         AV41TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
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
         PA142( ) ;
         WS142( ) ;
         WE142( ) ;
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
         sCtrlAV32Name = (string)((string)getParm(obj,1));
         sCtrlAV41TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA142( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "gamwcauthenticationtypeentrysaml20", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA142( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV32Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV32Name", AV32Name);
            AV41TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV32Name = cgiGet( sPrefix+"wcpOAV32Name");
         wcpOAV41TypeId = cgiGet( sPrefix+"wcpOAV41TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV32Name, wcpOAV32Name) != 0 ) || ( StringUtil.StrCmp(AV41TypeId, wcpOAV41TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV32Name = AV32Name;
         wcpOAV41TypeId = AV41TypeId;
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
         sCtrlAV32Name = cgiGet( sPrefix+"AV32Name_CTRL");
         if ( StringUtil.Len( sCtrlAV32Name) > 0 )
         {
            AV32Name = cgiGet( sCtrlAV32Name);
            AssignAttri(sPrefix, false, "AV32Name", AV32Name);
         }
         else
         {
            AV32Name = cgiGet( sPrefix+"AV32Name_PARM");
         }
         sCtrlAV41TypeId = cgiGet( sPrefix+"AV41TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV41TypeId) > 0 )
         {
            AV41TypeId = cgiGet( sCtrlAV41TypeId);
            AssignAttri(sPrefix, false, "AV41TypeId", AV41TypeId);
         }
         else
         {
            AV41TypeId = cgiGet( sPrefix+"AV41TypeId_PARM");
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
         PA142( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS142( ) ;
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
         WS142( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV32Name_PARM", StringUtil.RTrim( AV32Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV32Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV32Name_CTRL", StringUtil.RTrim( sCtrlAV32Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV41TypeId_PARM", StringUtil.RTrim( AV41TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV41TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV41TypeId_CTRL", StringUtil.RTrim( sCtrlAV41TypeId));
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
         WE142( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815461444", true, true);
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
         context.AddJavascriptSource("gamwcauthenticationtypeentrysaml20.js", "?202142815461444", false, true);
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_2292( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_229_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_229_idx;
         edtavDeleteproperty_Internalname = sPrefix+"vDELETEPROPERTY_"+sGXsfl_229_idx;
      }

      protected void SubsflControlProps_fel_2292( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_229_fel_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_229_fel_idx;
         edtavDeleteproperty_Internalname = sPrefix+"vDELETEPROPERTY_"+sGXsfl_229_fel_idx;
      }

      protected void sendrow_2292( )
      {
         SubsflControlProps_2292( ) ;
         WB140( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_229_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_229_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_229_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDynamicpropname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDynamicpropname_Enabled!=0)&&(edtavDynamicpropname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 230,'"+sPrefix+"',false,'"+sGXsfl_229_idx+"',229)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicpropname_Internalname,StringUtil.RTrim( AV11DynamicPropName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDynamicpropname_Enabled!=0)&&(edtavDynamicpropname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,230);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicpropname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDynamicpropname_Visible,(int)edtavDynamicpropname_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)229,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMPropertyId",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDynamicproptag_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDynamicproptag_Enabled!=0)&&(edtavDynamicproptag_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 231,'"+sPrefix+"',false,'"+sGXsfl_229_idx+"',229)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicproptag_Internalname,StringUtil.RTrim( AV12DynamicPropTag),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDynamicproptag_Enabled!=0)&&(edtavDynamicproptag_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,231);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicproptag_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDynamicproptag_Visible,(int)edtavDynamicproptag_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)229,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDeleteproperty_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavDeleteproperty_Enabled!=0)&&(edtavDeleteproperty_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 232,'"+sPrefix+"',false,'',229)\"" : " ");
            ClassString = "ActionBaseColorAttribute";
            StyleString = "";
            AV65DeleteProperty_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty))&&String.IsNullOrEmpty(StringUtil.RTrim( AV71Deleteproperty_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV65DeleteProperty)) ? AV71Deleteproperty_GXI : context.PathToRelativeUrl( AV65DeleteProperty));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleteproperty_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavDeleteproperty_Visible,(int)edtavDeleteproperty_Enabled,(string)"",(string)edtavDeleteproperty_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDeleteproperty_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETEPROPERTY.CLICK."+sGXsfl_229_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV65DeleteProperty_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes142( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_229_idx = ((subGrid_Islastpage==1)&&(nGXsfl_229_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_229_idx+1);
            sGXsfl_229_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_229_idx), 4, 0), 4, "0");
            SubsflControlProps_2292( ) ;
         }
         /* End function sendrow_2292 */
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
         chkavForceauthn.Name = "vFORCEAUTHN";
         chkavForceauthn.WebTags = "";
         chkavForceauthn.Caption = "";
         AssignProp(sPrefix, false, chkavForceauthn_Internalname, "TitleCaption", chkavForceauthn.Caption, true);
         chkavForceauthn.CheckedValue = "false";
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
         edtavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         edtavSmallimagename_Internalname = sPrefix+"vSMALLIMAGENAME";
         edtavBigimagename_Internalname = sPrefix+"vBIGIMAGENAME";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         lblGeneral_title_Internalname = sPrefix+"GENERAL_TITLE";
         chkavForceauthn_Internalname = sPrefix+"vFORCEAUTHN";
         edtavAuthncontext_Internalname = sPrefix+"vAUTHNCONTEXT";
         edtavLocalsiteurl_Internalname = sPrefix+"vLOCALSITEURL";
         edtavIdentityproviderentityid_Internalname = sPrefix+"vIDENTITYPROVIDERENTITYID";
         edtavServiceproviderentityid_Internalname = sPrefix+"vSERVICEPROVIDERENTITYID";
         edtavSamlendpointlocation_Internalname = sPrefix+"vSAMLENDPOINTLOCATION";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         Dvpanel_unnamedtable7_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE7";
         edtavSinglelogoutendpoint_Internalname = sPrefix+"vSINGLELOGOUTENDPOINT";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         Dvpanel_unnamedtable8_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE8";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         lblCredentials_title_Internalname = sPrefix+"CREDENTIALS_TITLE";
         edtavKeystpathcredential_Internalname = sPrefix+"vKEYSTPATHCREDENTIAL";
         edtavKeystpwdcredential_Internalname = sPrefix+"vKEYSTPWDCREDENTIAL";
         edtavKeyaliascredential_Internalname = sPrefix+"vKEYALIASCREDENTIAL";
         edtavKeystorecredential_Internalname = sPrefix+"vKEYSTORECREDENTIAL";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         Dvpanel_unnamedtable4_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE4";
         edtavKeystorefilepathtrustcred_Internalname = sPrefix+"vKEYSTOREFILEPATHTRUSTCRED";
         edtavKeystorepwdtrustcred_Internalname = sPrefix+"vKEYSTOREPWDTRUSTCRED";
         edtavKeyaliastrustcred_Internalname = sPrefix+"vKEYALIASTRUSTCRED";
         edtavKeystoretrustcred_Internalname = sPrefix+"vKEYSTORETRUSTCRED";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         Dvpanel_unnamedtable5_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE5";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         lblUserinfo_title_Internalname = sPrefix+"USERINFO_TITLE";
         edtavUserinforesponseuseremailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREMAILTAG";
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
         bttBtnadd_Internalname = sPrefix+"BTNADD";
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME";
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG";
         edtavDeleteproperty_Internalname = sPrefix+"vDELETEPROPERTY";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         Dvpanel_unnamedtable2_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE2";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = sPrefix+"GXUITABSPANEL_TABS";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavGridcurrentpage_Internalname = sPrefix+"vGRIDCURRENTPAGE";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         chkavForceauthn.Caption = "Forçar autenticação";
         chkavIsenable.Caption = "Habilitado?";
         edtavDeleteproperty_Jsonclick = "";
         edtavDynamicproptag_Jsonclick = "";
         edtavDynamicpropname_Jsonclick = "";
         edtavGridcurrentpage_Jsonclick = "";
         edtavGridcurrentpage_Visible = 1;
         bttBtnenter_Caption = "Confirmar";
         bttBtnenter_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDeleteproperty_Tooltiptext = "";
         subGrid_Header = "";
         edtavDeleteproperty_Enabled = 1;
         edtavDeleteproperty_Visible = -1;
         edtavDynamicproptag_Enabled = 1;
         edtavDynamicproptag_Visible = -1;
         edtavDynamicpropname_Enabled = 1;
         edtavDynamicpropname_Visible = -1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         bttBtnadd_Visible = 1;
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
         edtavUserinforesponseuseremailtag_Jsonclick = "";
         edtavUserinforesponseuseremailtag_Enabled = 1;
         edtavKeystoretrustcred_Jsonclick = "";
         edtavKeystoretrustcred_Enabled = 1;
         edtavKeyaliastrustcred_Jsonclick = "";
         edtavKeyaliastrustcred_Enabled = 1;
         edtavKeystorepwdtrustcred_Jsonclick = "";
         edtavKeystorepwdtrustcred_Enabled = 1;
         edtavKeystorefilepathtrustcred_Jsonclick = "";
         edtavKeystorefilepathtrustcred_Enabled = 1;
         edtavKeystorecredential_Jsonclick = "";
         edtavKeystorecredential_Enabled = 1;
         edtavKeyaliascredential_Jsonclick = "";
         edtavKeyaliascredential_Enabled = 1;
         edtavKeystpwdcredential_Jsonclick = "";
         edtavKeystpwdcredential_Enabled = 1;
         edtavKeystpathcredential_Jsonclick = "";
         edtavKeystpathcredential_Enabled = 1;
         edtavSinglelogoutendpoint_Jsonclick = "";
         edtavSinglelogoutendpoint_Enabled = 1;
         edtavSamlendpointlocation_Jsonclick = "";
         edtavSamlendpointlocation_Enabled = 1;
         edtavServiceproviderentityid_Jsonclick = "";
         edtavServiceproviderentityid_Enabled = 1;
         edtavIdentityproviderentityid_Jsonclick = "";
         edtavIdentityproviderentityid_Enabled = 1;
         edtavLocalsiteurl_Jsonclick = "";
         edtavLocalsiteurl_Enabled = 1;
         edtavAuthncontext_Jsonclick = "";
         edtavAuthncontext_Enabled = 1;
         chkavForceauthn.Enabled = 1;
         edtavBigimagename_Jsonclick = "";
         edtavBigimagename_Enabled = 1;
         edtavSmallimagename_Jsonclick = "";
         edtavSmallimagename_Enabled = 1;
         edtavImpersonate_Jsonclick = "";
         edtavImpersonate_Enabled = 1;
         chkavIsenable.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         cmbavFunctionid_Jsonclick = "";
         cmbavFunctionid.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 0;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "";
         Gxuitabspanel_tabs_Pagecount = 3;
         Dvpanel_unnamedtable2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Iconposition = "Right";
         Dvpanel_unnamedtable2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Title = "Atributos de usuário personalizados";
         Dvpanel_unnamedtable2_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Width = "100%";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_unnamedtable5_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Iconposition = "Right";
         Dvpanel_unnamedtable5_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable5_Title = "Credenciais da resposta";
         Dvpanel_unnamedtable5_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable5_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable5_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Width = "100%";
         Dvpanel_unnamedtable4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Iconposition = "Right";
         Dvpanel_unnamedtable4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable4_Title = "Solicita credenciais";
         Dvpanel_unnamedtable4_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Width = "100%";
         Dvpanel_unnamedtable8_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Iconposition = "Right";
         Dvpanel_unnamedtable8_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable8_Title = "Fechar sessão";
         Dvpanel_unnamedtable8_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable8_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable8_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Width = "100%";
         Dvpanel_unnamedtable7_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Iconposition = "Right";
         Dvpanel_unnamedtable7_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Title = "Iniciar sessão";
         Dvpanel_unnamedtable7_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable7_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Width = "100%";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'sPrefix'},{av:'AV45UserInfoResponseUserErrorDescriptionTag',fld:'vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG',pic:'',hsh:true},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavDeleteproperty_Enabled',ctrl:'vDELETEPROPERTY',prop:'Enabled'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E17142',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV65DeleteProperty',fld:'vDELETEPROPERTY',pic:''},{av:'edtavDeleteproperty_Tooltiptext',ctrl:'vDELETEPROPERTY',prop:'Tooltiptext'},{av:'AV11DynamicPropName',fld:'vDYNAMICPROPNAME',pic:''},{av:'AV12DynamicPropTag',fld:'vDYNAMICPROPTAG',pic:''},{av:'edtavDeleteproperty_Visible',ctrl:'vDELETEPROPERTY',prop:'Visible'},{av:'edtavDynamicpropname_Enabled',ctrl:'vDYNAMICPROPNAME',prop:'Enabled'},{av:'edtavDynamicproptag_Enabled',ctrl:'vDYNAMICPROPTAG',prop:'Enabled'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11142',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV45UserInfoResponseUserErrorDescriptionTag',fld:'vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG',pic:'',hsh:true},{av:'sPrefix'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'edtavDeleteproperty_Enabled',ctrl:'vDELETEPROPERTY',prop:'Enabled'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12142',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV45UserInfoResponseUserErrorDescriptionTag',fld:'vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG',pic:'',hsh:true},{av:'sPrefix'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("'DOADD'","{handler:'E13142',iparms:[{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("'DOADD'",",oparms:[{av:'AV65DeleteProperty',fld:'vDELETEPROPERTY',pic:''},{av:'edtavDeleteproperty_Visible',ctrl:'vDELETEPROPERTY',prop:'Visible'},{av:'edtavDynamicpropname_Enabled',ctrl:'vDYNAMICPROPNAME',prop:'Enabled'},{av:'edtavDynamicpropname_Visible',ctrl:'vDYNAMICPROPNAME',prop:'Visible'},{av:'edtavDynamicproptag_Enabled',ctrl:'vDYNAMICPROPTAG',prop:'Enabled'},{av:'edtavDynamicproptag_Visible',ctrl:'vDYNAMICPROPTAG',prop:'Visible'},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E14142',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV32Name',fld:'vNAME',pic:''},{av:'AV41TypeId',fld:'vTYPEID',pic:''},{av:'AV10Dsc',fld:'vDSC',pic:''},{av:'AV40SmallImageName',fld:'vSMALLIMAGENAME',pic:''},{av:'AV7BigImageName',fld:'vBIGIMAGENAME',pic:''},{av:'AV18Impersonate',fld:'vIMPERSONATE',pic:''},{av:'AV37ServiceProviderEntityID',fld:'vSERVICEPROVIDERENTITYID',pic:''},{av:'AV38IdentityProviderEntityID',fld:'vIDENTITYPROVIDERENTITYID',pic:''},{av:'AV6AuthnContext',fld:'vAUTHNCONTEXT',pic:''},{av:'AV21KeyAliasCredential',fld:'vKEYALIASCREDENTIAL',pic:''},{av:'AV22KeyAliasTrustCred',fld:'vKEYALIASTRUSTCRED',pic:''},{av:'AV24KeyStoreCredential',fld:'vKEYSTORECREDENTIAL',pic:''},{av:'AV25KeyStoreFilePathTrustCred',fld:'vKEYSTOREFILEPATHTRUSTCRED',pic:''},{av:'AV26KeyStorePwdTrustCred',fld:'vKEYSTOREPWDTRUSTCRED',pic:''},{av:'AV27KeyStoreTrustCred',fld:'vKEYSTORETRUSTCRED',pic:''},{av:'AV28KeyStPathCredential',fld:'vKEYSTPATHCREDENTIAL',pic:''},{av:'AV29KeyStPwdCredential',fld:'vKEYSTPWDCREDENTIAL',pic:''},{av:'AV36SamlEndpointLocation',fld:'vSAMLENDPOINTLOCATION',pic:''},{av:'AV39SingleLogoutendpoint',fld:'vSINGLELOGOUTENDPOINT',pic:''},{av:'AV30LocalSiteURL',fld:'vLOCALSITEURL',pic:''},{av:'AV45UserInfoResponseUserErrorDescriptionTag',fld:'vUSERINFORESPONSEUSERERRORDESCRIPTIONTAG',pic:'',hsh:true},{av:'AV43UserInfoResponseUserBirthdayTag',fld:'vUSERINFORESPONSEUSERBIRTHDAYTAG',pic:''},{av:'AV44UserInfoResponseUserEmailTag',fld:'vUSERINFORESPONSEUSEREMAILTAG',pic:''},{av:'AV46UserInfoResponseUserExternalIdTag',fld:'vUSERINFORESPONSEUSEREXTERNALIDTAG',pic:''},{av:'AV47UserInfoResponseUserFirstNameTag',fld:'vUSERINFORESPONSEUSERFIRSTNAMETAG',pic:''},{av:'AV48UserInfoResponseUserGenderTag',fld:'vUSERINFORESPONSEUSERGENDERTAG',pic:''},{av:'AV49UserInfoResponseUserGenderValues',fld:'vUSERINFORESPONSEUSERGENDERVALUES',pic:''},{av:'AV50UserInfoResponseUserLanguageTag',fld:'vUSERINFORESPONSEUSERLANGUAGETAG',pic:''},{av:'AV52UserInfoResponseUserLastNameTag',fld:'vUSERINFORESPONSEUSERLASTNAMETAG',pic:''},{av:'AV53UserInfoResponseUserNameTag',fld:'vUSERINFORESPONSEUSERNAMETAG',pic:''},{av:'AV54UserInfoResponseUserTimeZoneTag',fld:'vUSERINFORESPONSEUSERTIMEZONETAG',pic:''},{av:'AV55UserInfoResponseUserURLImageTag',fld:'vUSERINFORESPONSEUSERURLIMAGETAG',pic:''},{av:'AV56UserInfoResponseUserURLProfileTag',fld:'vUSERINFORESPONSEUSERURLPROFILETAG',pic:''},{av:'AV11DynamicPropName',fld:'vDYNAMICPROPNAME',grid:229,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_229',ctrl:'GRID',grid:229,prop:'GridRC'},{av:'AV12DynamicPropTag',fld:'vDYNAMICPROPTAG',grid:229,pic:''},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("VDELETEPROPERTY.CLICK","{handler:'E18142',iparms:[{av:'AV32Name',fld:'vNAME',pic:''},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("VDELETEPROPERTY.CLICK",",oparms:[{av:'AV65DeleteProperty',fld:'vDELETEPROPERTY',pic:''},{av:'edtavDeleteproperty_Visible',ctrl:'vDELETEPROPERTY',prop:'Visible'},{av:'edtavDynamicpropname_Visible',ctrl:'vDYNAMICPROPNAME',prop:'Visible'},{av:'edtavDynamicproptag_Visible',ctrl:'vDYNAMICPROPTAG',prop:'Visible'},{av:'AV11DynamicPropName',fld:'vDYNAMICPROPNAME',pic:''},{av:'AV12DynamicPropTag',fld:'vDYNAMICPROPTAG',pic:''},{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("VALIDV_FUNCTIONID","{handler:'Validv_Functionid',iparms:[{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("VALIDV_FUNCTIONID",",oparms:[{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Deleteproperty',iparms:[{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV19IsEnable',fld:'vISENABLE',pic:''},{av:'AV15ForceAuthn',fld:'vFORCEAUTHN',pic:''},{av:'AV51UserInfoResponseUserLastNameGenAuto',fld:'vUSERINFORESPONSEUSERLASTNAMEGENAUTO',pic:''}]}");
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
         wcpOAV32Name = "";
         wcpOAV41TypeId = "";
         Gridpaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV45UserInfoResponseUserErrorDescriptionTag = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV66GridAppliedFilters = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV16FunctionId = "";
         AV10Dsc = "";
         AV18Impersonate = "";
         AV40SmallImageName = "";
         AV7BigImageName = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         AV6AuthnContext = "";
         AV30LocalSiteURL = "";
         ucDvpanel_unnamedtable7 = new GXUserControl();
         AV38IdentityProviderEntityID = "";
         AV37ServiceProviderEntityID = "";
         AV36SamlEndpointLocation = "";
         ucDvpanel_unnamedtable8 = new GXUserControl();
         AV39SingleLogoutendpoint = "";
         lblCredentials_title_Jsonclick = "";
         ucDvpanel_unnamedtable4 = new GXUserControl();
         AV28KeyStPathCredential = "";
         AV29KeyStPwdCredential = "";
         AV21KeyAliasCredential = "";
         AV24KeyStoreCredential = "";
         ucDvpanel_unnamedtable5 = new GXUserControl();
         AV25KeyStoreFilePathTrustCred = "";
         AV26KeyStorePwdTrustCred = "";
         AV22KeyAliasTrustCred = "";
         AV27KeyStoreTrustCred = "";
         lblUserinfo_title_Jsonclick = "";
         AV44UserInfoResponseUserEmailTag = "";
         AV46UserInfoResponseUserExternalIdTag = "";
         AV53UserInfoResponseUserNameTag = "";
         AV47UserInfoResponseUserFirstNameTag = "";
         AV52UserInfoResponseUserLastNameTag = "";
         AV48UserInfoResponseUserGenderTag = "";
         AV49UserInfoResponseUserGenderValues = "";
         AV43UserInfoResponseUserBirthdayTag = "";
         AV55UserInfoResponseUserURLImageTag = "";
         AV56UserInfoResponseUserURLProfileTag = "";
         AV50UserInfoResponseUserLanguageTag = "";
         AV54UserInfoResponseUserTimeZoneTag = "";
         AV42UserInfoResponseErrorDescriptionTag = "";
         ucDvpanel_unnamedtable2 = new GXUserControl();
         bttBtnadd_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV11DynamicPropName = "";
         AV12DynamicPropTag = "";
         AV65DeleteProperty = "";
         ucGridpaginationbar = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV71Deleteproperty_GXI = "";
         AV5AuthenticationTypeSaml20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSaml20(context);
         AV17GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
         GridRow = new GXWebRow();
         AV14Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV32Name = "";
         sCtrlAV41TypeId = "";
         ROClassString = "";
         sImgUrl = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentrysaml20__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentrysaml20__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_229 ;
      private int nGXsfl_229_idx=1 ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavImpersonate_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int edtavAuthncontext_Enabled ;
      private int edtavLocalsiteurl_Enabled ;
      private int edtavIdentityproviderentityid_Enabled ;
      private int edtavServiceproviderentityid_Enabled ;
      private int edtavSamlendpointlocation_Enabled ;
      private int edtavSinglelogoutendpoint_Enabled ;
      private int edtavKeystpathcredential_Enabled ;
      private int edtavKeystpwdcredential_Enabled ;
      private int edtavKeyaliascredential_Enabled ;
      private int edtavKeystorecredential_Enabled ;
      private int edtavKeystorefilepathtrustcred_Enabled ;
      private int edtavKeystorepwdtrustcred_Enabled ;
      private int edtavKeyaliastrustcred_Enabled ;
      private int edtavKeystoretrustcred_Enabled ;
      private int edtavUserinforesponseuseremailtag_Enabled ;
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
      private int bttBtnadd_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavDynamicpropname_Visible ;
      private int edtavDynamicproptag_Visible ;
      private int edtavDeleteproperty_Visible ;
      private int edtavDynamicpropname_Enabled ;
      private int edtavDynamicproptag_Enabled ;
      private int edtavDeleteproperty_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int bttBtnenter_Visible ;
      private int edtavGridcurrentpage_Visible ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int subGrid_Recordcount ;
      private int AV70GXV1 ;
      private int AV62PageToGo ;
      private int AV72GXV2 ;
      private int nGXsfl_229_fel_idx=1 ;
      private int AV74GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV64GridPageCount ;
      private long AV63GridCurrentPage ;
      private long GRID_nCurrentRecord ;
      private string Gx_mode ;
      private string AV32Name ;
      private string AV41TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV32Name ;
      private string wcpOAV41TypeId ;
      private string Gridpaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_229_idx="0001" ;
      private string AV45UserInfoResponseUserErrorDescriptionTag ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_unnamedtable7_Width ;
      private string Dvpanel_unnamedtable7_Cls ;
      private string Dvpanel_unnamedtable7_Title ;
      private string Dvpanel_unnamedtable7_Iconposition ;
      private string Dvpanel_unnamedtable8_Width ;
      private string Dvpanel_unnamedtable8_Cls ;
      private string Dvpanel_unnamedtable8_Title ;
      private string Dvpanel_unnamedtable8_Iconposition ;
      private string Dvpanel_unnamedtable4_Width ;
      private string Dvpanel_unnamedtable4_Cls ;
      private string Dvpanel_unnamedtable4_Title ;
      private string Dvpanel_unnamedtable4_Iconposition ;
      private string Dvpanel_unnamedtable5_Width ;
      private string Dvpanel_unnamedtable5_Cls ;
      private string Dvpanel_unnamedtable5_Title ;
      private string Dvpanel_unnamedtable5_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Dvpanel_unnamedtable2_Width ;
      private string Dvpanel_unnamedtable2_Cls ;
      private string Dvpanel_unnamedtable2_Title ;
      private string Dvpanel_unnamedtable2_Iconposition ;
      private string Gxuitabspanel_tabs_Class ;
      private string Grid_empowerer_Gridinternalname ;
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
      private string AV16FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string edtavDsc_Internalname ;
      private string AV10Dsc ;
      private string edtavDsc_Jsonclick ;
      private string chkavIsenable_Internalname ;
      private string edtavImpersonate_Internalname ;
      private string AV18Impersonate ;
      private string edtavImpersonate_Jsonclick ;
      private string edtavSmallimagename_Internalname ;
      private string AV40SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string edtavBigimagename_Internalname ;
      private string AV7BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string chkavForceauthn_Internalname ;
      private string edtavAuthncontext_Internalname ;
      private string AV6AuthnContext ;
      private string edtavAuthncontext_Jsonclick ;
      private string edtavLocalsiteurl_Internalname ;
      private string edtavLocalsiteurl_Jsonclick ;
      private string Dvpanel_unnamedtable7_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string edtavIdentityproviderentityid_Internalname ;
      private string edtavIdentityproviderentityid_Jsonclick ;
      private string edtavServiceproviderentityid_Internalname ;
      private string edtavServiceproviderentityid_Jsonclick ;
      private string edtavSamlendpointlocation_Internalname ;
      private string edtavSamlendpointlocation_Jsonclick ;
      private string Dvpanel_unnamedtable8_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string edtavSinglelogoutendpoint_Internalname ;
      private string edtavSinglelogoutendpoint_Jsonclick ;
      private string lblCredentials_title_Internalname ;
      private string lblCredentials_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string Dvpanel_unnamedtable4_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string edtavKeystpathcredential_Internalname ;
      private string edtavKeystpathcredential_Jsonclick ;
      private string edtavKeystpwdcredential_Internalname ;
      private string AV29KeyStPwdCredential ;
      private string edtavKeystpwdcredential_Jsonclick ;
      private string edtavKeyaliascredential_Internalname ;
      private string AV21KeyAliasCredential ;
      private string edtavKeyaliascredential_Jsonclick ;
      private string edtavKeystorecredential_Internalname ;
      private string AV24KeyStoreCredential ;
      private string edtavKeystorecredential_Jsonclick ;
      private string Dvpanel_unnamedtable5_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string edtavKeystorefilepathtrustcred_Internalname ;
      private string edtavKeystorefilepathtrustcred_Jsonclick ;
      private string edtavKeystorepwdtrustcred_Internalname ;
      private string AV26KeyStorePwdTrustCred ;
      private string edtavKeystorepwdtrustcred_Jsonclick ;
      private string edtavKeyaliastrustcred_Internalname ;
      private string AV22KeyAliasTrustCred ;
      private string edtavKeyaliastrustcred_Jsonclick ;
      private string edtavKeystoretrustcred_Internalname ;
      private string AV27KeyStoreTrustCred ;
      private string edtavKeystoretrustcred_Jsonclick ;
      private string lblUserinfo_title_Internalname ;
      private string lblUserinfo_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavUserinforesponseuseremailtag_Internalname ;
      private string AV44UserInfoResponseUserEmailTag ;
      private string edtavUserinforesponseuseremailtag_Jsonclick ;
      private string edtavUserinforesponseuserexternalidtag_Internalname ;
      private string AV46UserInfoResponseUserExternalIdTag ;
      private string edtavUserinforesponseuserexternalidtag_Jsonclick ;
      private string edtavUserinforesponseusernametag_Internalname ;
      private string AV53UserInfoResponseUserNameTag ;
      private string edtavUserinforesponseusernametag_Jsonclick ;
      private string edtavUserinforesponseuserfirstnametag_Internalname ;
      private string AV47UserInfoResponseUserFirstNameTag ;
      private string edtavUserinforesponseuserfirstnametag_Jsonclick ;
      private string chkavUserinforesponseuserlastnamegenauto_Internalname ;
      private string divUserinforesponseuserlastnametag_cell_Internalname ;
      private string divUserinforesponseuserlastnametag_cell_Class ;
      private string edtavUserinforesponseuserlastnametag_Internalname ;
      private string AV52UserInfoResponseUserLastNameTag ;
      private string edtavUserinforesponseuserlastnametag_Jsonclick ;
      private string edtavUserinforesponseusergendertag_Internalname ;
      private string AV48UserInfoResponseUserGenderTag ;
      private string edtavUserinforesponseusergendertag_Jsonclick ;
      private string edtavUserinforesponseusergendervalues_Internalname ;
      private string edtavUserinforesponseusergendervalues_Jsonclick ;
      private string edtavUserinforesponseuserbirthdaytag_Internalname ;
      private string AV43UserInfoResponseUserBirthdayTag ;
      private string edtavUserinforesponseuserbirthdaytag_Jsonclick ;
      private string edtavUserinforesponseuserurlimagetag_Internalname ;
      private string AV55UserInfoResponseUserURLImageTag ;
      private string edtavUserinforesponseuserurlimagetag_Jsonclick ;
      private string edtavUserinforesponseuserurlprofiletag_Internalname ;
      private string AV56UserInfoResponseUserURLProfileTag ;
      private string edtavUserinforesponseuserurlprofiletag_Jsonclick ;
      private string edtavUserinforesponseuserlanguagetag_Internalname ;
      private string AV50UserInfoResponseUserLanguageTag ;
      private string edtavUserinforesponseuserlanguagetag_Jsonclick ;
      private string edtavUserinforesponseusertimezonetag_Internalname ;
      private string AV54UserInfoResponseUserTimeZoneTag ;
      private string edtavUserinforesponseusertimezonetag_Jsonclick ;
      private string edtavUserinforesponseerrordescriptiontag_Internalname ;
      private string AV42UserInfoResponseErrorDescriptionTag ;
      private string edtavUserinforesponseerrordescriptiontag_Jsonclick ;
      private string Dvpanel_unnamedtable2_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string bttBtnadd_Internalname ;
      private string bttBtnadd_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string AV11DynamicPropName ;
      private string AV12DynamicPropTag ;
      private string edtavDeleteproperty_Tooltiptext ;
      private string Gridpaginationbar_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGridcurrentpage_Internalname ;
      private string edtavGridcurrentpage_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavDynamicpropname_Internalname ;
      private string edtavDynamicproptag_Internalname ;
      private string edtavDeleteproperty_Internalname ;
      private string sGXsfl_229_fel_idx="0001" ;
      private string sCtrlGx_mode ;
      private string sCtrlAV32Name ;
      private string sCtrlAV41TypeId ;
      private string ROClassString ;
      private string edtavDynamicpropname_Jsonclick ;
      private string edtavDynamicproptag_Jsonclick ;
      private string sImgUrl ;
      private string edtavDeleteproperty_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19IsEnable ;
      private bool AV15ForceAuthn ;
      private bool AV51UserInfoResponseUserLastNameGenAuto ;
      private bool Dvpanel_unnamedtable7_Autowidth ;
      private bool Dvpanel_unnamedtable7_Autoheight ;
      private bool Dvpanel_unnamedtable7_Collapsible ;
      private bool Dvpanel_unnamedtable7_Collapsed ;
      private bool Dvpanel_unnamedtable7_Showcollapseicon ;
      private bool Dvpanel_unnamedtable7_Autoscroll ;
      private bool Dvpanel_unnamedtable8_Autowidth ;
      private bool Dvpanel_unnamedtable8_Autoheight ;
      private bool Dvpanel_unnamedtable8_Collapsible ;
      private bool Dvpanel_unnamedtable8_Collapsed ;
      private bool Dvpanel_unnamedtable8_Showcollapseicon ;
      private bool Dvpanel_unnamedtable8_Autoscroll ;
      private bool Dvpanel_unnamedtable4_Autowidth ;
      private bool Dvpanel_unnamedtable4_Autoheight ;
      private bool Dvpanel_unnamedtable4_Collapsible ;
      private bool Dvpanel_unnamedtable4_Collapsed ;
      private bool Dvpanel_unnamedtable4_Showcollapseicon ;
      private bool Dvpanel_unnamedtable4_Autoscroll ;
      private bool Dvpanel_unnamedtable5_Autowidth ;
      private bool Dvpanel_unnamedtable5_Autoheight ;
      private bool Dvpanel_unnamedtable5_Collapsible ;
      private bool Dvpanel_unnamedtable5_Collapsed ;
      private bool Dvpanel_unnamedtable5_Showcollapseicon ;
      private bool Dvpanel_unnamedtable5_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Dvpanel_unnamedtable2_Autowidth ;
      private bool Dvpanel_unnamedtable2_Autoheight ;
      private bool Dvpanel_unnamedtable2_Collapsible ;
      private bool Dvpanel_unnamedtable2_Collapsed ;
      private bool Dvpanel_unnamedtable2_Showcollapseicon ;
      private bool Dvpanel_unnamedtable2_Autoscroll ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_229_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV65DeleteProperty_IsBlob ;
      private string AV66GridAppliedFilters ;
      private string AV30LocalSiteURL ;
      private string AV38IdentityProviderEntityID ;
      private string AV37ServiceProviderEntityID ;
      private string AV36SamlEndpointLocation ;
      private string AV39SingleLogoutendpoint ;
      private string AV28KeyStPathCredential ;
      private string AV25KeyStoreFilePathTrustCred ;
      private string AV49UserInfoResponseUserGenderValues ;
      private string AV71Deleteproperty_GXI ;
      private string AV65DeleteProperty ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucDvpanel_unnamedtable7 ;
      private GXUserControl ucDvpanel_unnamedtable8 ;
      private GXUserControl ucDvpanel_unnamedtable4 ;
      private GXUserControl ucDvpanel_unnamedtable5 ;
      private GXUserControl ucDvpanel_unnamedtable2 ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeId ;
      private GXCombobox cmbavFunctionid ;
      private GXCheckbox chkavIsenable ;
      private GXCheckbox chkavForceauthn ;
      private GXCheckbox chkavUserinforesponseuserlastnamegenauto ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSaml20 AV5AuthenticationTypeSaml20 ;
      private GeneXus.Programs.genexussecurity.SdtGAMPropertySimple AV17GAMPropertySimple ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV13Error ;
   }

   public class gamwcauthenticationtypeentrysaml20__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwcauthenticationtypeentrysaml20__default : DataStoreHelperBase, IDataStoreHelper
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
