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
   public class homeiot : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public homeiot( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public homeiot( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "" ;
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
         PA2E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2E2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142918311114", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("homeiot.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"HomeIOT");
         forbiddenHiddens.Add("ValueCard1", context.localUtil.Format( (decimal)(AV29ValueCard1), "ZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("ValueCard3", context.localUtil.Format( (decimal)(AV31ValueCard3), "ZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("ValueCard2", context.localUtil.Format( (decimal)(AV28ValueCard2), "ZZ,ZZZ,ZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("homeiot:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vISCONNECTED", AV9IsConnected);
         GxWebStd.gx_hidden_field( context, "GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40001GXC2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40002GXC2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40003GXC2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40004GXC1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40005GXC2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40006GXC2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40007GXC2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Width", StringUtil.RTrim( Dvpanel_panel1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autowidth", StringUtil.BoolToStr( Dvpanel_panel1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autoheight", StringUtil.BoolToStr( Dvpanel_panel1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Cls", StringUtil.RTrim( Dvpanel_panel1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Title", StringUtil.RTrim( Dvpanel_panel1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Collapsible", StringUtil.BoolToStr( Dvpanel_panel1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Collapsed", StringUtil.BoolToStr( Dvpanel_panel1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panel1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Iconposition", StringUtil.RTrim( Dvpanel_panel1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANEL1_Autoscroll", StringUtil.BoolToStr( Dvpanel_panel1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Width", StringUtil.RTrim( Dvpanel_tablecards2_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecards2_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecards2_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Cls", StringUtil.RTrim( Dvpanel_tablecards2_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Title", StringUtil.RTrim( Dvpanel_tablecards2_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecards2_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecards2_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecards2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Iconposition", StringUtil.RTrim( Dvpanel_tablecards2_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS2_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecards2_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_REGISTROIGN_ON_Circlecaptiontype", StringUtil.RTrim( Ucprogress_qtde_registroign_on_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_REGISTROIGN_ON_Caption", StringUtil.RTrim( Ucprogress_qtde_registroign_on_Caption));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_REGISTROIGN_ON_Subtitle", StringUtil.RTrim( Ucprogress_qtde_registroign_on_Subtitle));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_REGISTROIGN_ON_Cls", StringUtil.RTrim( Ucprogress_qtde_registroign_on_Cls));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_REGISTROIGN_ON_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress_qtde_registroign_on_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_REGISTROIGN_ON_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress_qtde_registroign_on_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS__QTDE_REGISTROIGN_OFF_Circlecaptiontype", StringUtil.RTrim( Ucprogress__qtde_registroign_off_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS__QTDE_REGISTROIGN_OFF_Caption", StringUtil.RTrim( Ucprogress__qtde_registroign_off_Caption));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS__QTDE_REGISTROIGN_OFF_Subtitle", StringUtil.RTrim( Ucprogress__qtde_registroign_off_Subtitle));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS__QTDE_REGISTROIGN_OFF_Cls", StringUtil.RTrim( Ucprogress__qtde_registroign_off_Cls));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS__QTDE_REGISTROIGN_OFF_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress__qtde_registroign_off_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS__QTDE_REGISTROIGN_OFF_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress__qtde_registroign_off_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Circlecaptiontype", StringUtil.RTrim( Ucprogress_qtde_veiculosemmovimento_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Caption", StringUtil.RTrim( Ucprogress_qtde_veiculosemmovimento_Caption));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Subtitle", StringUtil.RTrim( Ucprogress_qtde_veiculosemmovimento_Subtitle));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Cls", StringUtil.RTrim( Ucprogress_qtde_veiculosemmovimento_Cls));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress_qtde_veiculosemmovimento_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress_qtde_veiculosemmovimento_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Width", StringUtil.RTrim( Dvpanel_tablecards_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecards_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecards_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Cls", StringUtil.RTrim( Dvpanel_tablecards_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Title", StringUtil.RTrim( Dvpanel_tablecards_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecards_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Iconposition", StringUtil.RTrim( Dvpanel_tablecards_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecards_Autoscroll));
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
            WE2E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("homeiot.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "HomeIOT" ;
      }

      public override string GetPgmdesc( )
      {
         return "Home" ;
      }

      protected void WB2E0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_panel1.SetProperty("Width", Dvpanel_panel1_Width);
            ucDvpanel_panel1.SetProperty("AutoWidth", Dvpanel_panel1_Autowidth);
            ucDvpanel_panel1.SetProperty("AutoHeight", Dvpanel_panel1_Autoheight);
            ucDvpanel_panel1.SetProperty("Cls", Dvpanel_panel1_Cls);
            ucDvpanel_panel1.SetProperty("Title", Dvpanel_panel1_Title);
            ucDvpanel_panel1.SetProperty("Collapsible", Dvpanel_panel1_Collapsible);
            ucDvpanel_panel1.SetProperty("Collapsed", Dvpanel_panel1_Collapsed);
            ucDvpanel_panel1.SetProperty("ShowCollapseIcon", Dvpanel_panel1_Showcollapseicon);
            ucDvpanel_panel1.SetProperty("IconPosition", Dvpanel_panel1_Iconposition);
            ucDvpanel_panel1.SetProperty("AutoScroll", Dvpanel_panel1_Autoscroll);
            ucDvpanel_panel1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panel1_Internalname, "DVPANEL_PANEL1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANEL1Container"+"Panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanel1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableconexao_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;align-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIconstatusconexao_Internalname, lblIconstatusconexao_Caption, "", "", lblIconstatusconexao_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtstatus_Internalname, lblTxtstatus_Caption, "", "", lblTxtstatus_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeSizeLarge AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnalterarconexao_Internalname, "", bttBtnalterarconexao_Caption, bttBtnalterarconexao_Jsonclick, 5, "Desconectar", "", StyleString, ClassString, bttBtnalterarconexao_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOALTERARCONEXAO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecards2.SetProperty("Width", Dvpanel_tablecards2_Width);
            ucDvpanel_tablecards2.SetProperty("AutoWidth", Dvpanel_tablecards2_Autowidth);
            ucDvpanel_tablecards2.SetProperty("AutoHeight", Dvpanel_tablecards2_Autoheight);
            ucDvpanel_tablecards2.SetProperty("Cls", Dvpanel_tablecards2_Cls);
            ucDvpanel_tablecards2.SetProperty("Title", Dvpanel_tablecards2_Title);
            ucDvpanel_tablecards2.SetProperty("Collapsible", Dvpanel_tablecards2_Collapsible);
            ucDvpanel_tablecards2.SetProperty("Collapsed", Dvpanel_tablecards2_Collapsed);
            ucDvpanel_tablecards2.SetProperty("ShowCollapseIcon", Dvpanel_tablecards2_Showcollapseicon);
            ucDvpanel_tablecards2.SetProperty("IconPosition", Dvpanel_tablecards2_Iconposition);
            ucDvpanel_tablecards2.SetProperty("AutoScroll", Dvpanel_tablecards2_Autoscroll);
            ucDvpanel_tablecards2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecards2_Internalname, "DVPANEL_TABLECARDS2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECARDS2Container"+"TableCards2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards2_Internalname, 1, 0, "px", 0, "px", "PanelCardContainer", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_Internalname, 1, 0, "px", 0, "px", "TableCardNumber", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard1_Internalname, "Value Card1", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ValueCard1), 10, 0, ",", "")), ((edtavValuecard1_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29ValueCard1), "ZZ,ZZZ,ZZ9")) : context.localUtil.Format( (decimal)(AV29ValueCard1), "ZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard1_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard1_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard1caption_Internalname, "Quantidade de Frotas", "", "", lblMoreinfocard1caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_Internalname, 1, 0, "px", 0, "px", "TableCardNumber", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard3_Internalname, "Value Card3", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ValueCard3), 10, 0, ",", "")), ((edtavValuecard3_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31ValueCard3), "ZZ,ZZZ,ZZ9")) : context.localUtil.Format( (decimal)(AV31ValueCard3), "ZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard3_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard3_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard3caption_Internalname, "Quantidade de Rastreadores", "", "", lblMoreinfocard3caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValuecard2_Internalname, "Value Card2", "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValuecard2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ValueCard2), 10, 0, ",", "")), ((edtavValuecard2_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV28ValueCard2), "ZZ,ZZZ,ZZ9")) : context.localUtil.Format( (decimal)(AV28ValueCard2), "ZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValuecard2_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavValuecard2_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMoreinfocard2caption_Internalname, "Quantidade de Veículos", "", "", lblMoreinfocard2caption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_HomeIOT.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HomeTopPanel CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecards.SetProperty("Width", Dvpanel_tablecards_Width);
            ucDvpanel_tablecards.SetProperty("AutoWidth", Dvpanel_tablecards_Autowidth);
            ucDvpanel_tablecards.SetProperty("AutoHeight", Dvpanel_tablecards_Autoheight);
            ucDvpanel_tablecards.SetProperty("Cls", Dvpanel_tablecards_Cls);
            ucDvpanel_tablecards.SetProperty("Title", Dvpanel_tablecards_Title);
            ucDvpanel_tablecards.SetProperty("Collapsible", Dvpanel_tablecards_Collapsible);
            ucDvpanel_tablecards.SetProperty("Collapsed", Dvpanel_tablecards_Collapsed);
            ucDvpanel_tablecards.SetProperty("ShowCollapseIcon", Dvpanel_tablecards_Showcollapseicon);
            ucDvpanel_tablecards.SetProperty("IconPosition", Dvpanel_tablecards_Iconposition);
            ucDvpanel_tablecards.SetProperty("AutoScroll", Dvpanel_tablecards_Autoscroll);
            ucDvpanel_tablecards.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecards_Internalname, "DVPANEL_TABLECARDSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECARDSContainer"+"TableCards"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;align-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop30", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableprogresscards_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;align-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUcprogress_qtde_registroign_on.SetProperty("CircleCaptionType", Ucprogress_qtde_registroign_on_Circlecaptiontype);
            ucUcprogress_qtde_registroign_on.SetProperty("Caption", Ucprogress_qtde_registroign_on_Caption);
            ucUcprogress_qtde_registroign_on.SetProperty("Subtitle", Ucprogress_qtde_registroign_on_Subtitle);
            ucUcprogress_qtde_registroign_on.SetProperty("Cls", Ucprogress_qtde_registroign_on_Cls);
            ucUcprogress_qtde_registroign_on.SetProperty("CircleWidth", Ucprogress_qtde_registroign_on_Circlewidth);
            ucUcprogress_qtde_registroign_on.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Ucprogress_qtde_registroign_on_Internalname, "UCPROGRESS_QTDE_REGISTROIGN_ONContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUcprogress__qtde_registroign_off.SetProperty("CircleCaptionType", Ucprogress__qtde_registroign_off_Circlecaptiontype);
            ucUcprogress__qtde_registroign_off.SetProperty("Caption", Ucprogress__qtde_registroign_off_Caption);
            ucUcprogress__qtde_registroign_off.SetProperty("Subtitle", Ucprogress__qtde_registroign_off_Subtitle);
            ucUcprogress__qtde_registroign_off.SetProperty("Cls", Ucprogress__qtde_registroign_off_Cls);
            ucUcprogress__qtde_registroign_off.SetProperty("CircleWidth", Ucprogress__qtde_registroign_off_Circlewidth);
            ucUcprogress__qtde_registroign_off.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Ucprogress__qtde_registroign_off_Internalname, "UCPROGRESS__QTDE_REGISTROIGN_OFFContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUcprogress_qtde_veiculosemmovimento.SetProperty("CircleCaptionType", Ucprogress_qtde_veiculosemmovimento_Circlecaptiontype);
            ucUcprogress_qtde_veiculosemmovimento.SetProperty("Caption", Ucprogress_qtde_veiculosemmovimento_Caption);
            ucUcprogress_qtde_veiculosemmovimento.SetProperty("Subtitle", Ucprogress_qtde_veiculosemmovimento_Subtitle);
            ucUcprogress_qtde_veiculosemmovimento.SetProperty("Cls", Ucprogress_qtde_veiculosemmovimento_Cls);
            ucUcprogress_qtde_veiculosemmovimento.SetProperty("CircleWidth", Ucprogress_qtde_veiculosemmovimento_Circlewidth);
            ucUcprogress_qtde_veiculosemmovimento.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Ucprogress_qtde_veiculosemmovimento_Internalname, "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTOContainer");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2E2( )
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
            Form.Meta.addItem("description", "Home", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2E0( ) ;
      }

      protected void WS2E2( )
      {
         START2E2( ) ;
         EVT2E2( ) ;
      }

      protected void EVT2E2( )
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
                              E112E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOALTERARCONEXAO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAlterarConexao' */
                              E122E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E132E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
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

      protected void WE2E2( )
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

      protected void PA2E2( )
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
               GX_FocusControl = edtavValuecard1_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavValuecard1_Enabled = 0;
         AssignProp("", false, edtavValuecard1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard1_Enabled), 5, 0), true);
         edtavValuecard3_Enabled = 0;
         AssignProp("", false, edtavValuecard3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard3_Enabled), 5, 0), true);
         edtavValuecard2_Enabled = 0;
         AssignProp("", false, edtavValuecard2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard2_Enabled), 5, 0), true);
      }

      protected void RF2E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E132E2 ();
            WB2E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2E2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavValuecard1_Enabled = 0;
         AssignProp("", false, edtavValuecard1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard1_Enabled), 5, 0), true);
         edtavValuecard3_Enabled = 0;
         AssignProp("", false, edtavValuecard3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard3_Enabled), 5, 0), true);
         edtavValuecard2_Enabled = 0;
         AssignProp("", false, edtavValuecard2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValuecard2_Enabled), 5, 0), true);
         /* Using cursor H002E3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = H002E3_A40000GXC1[0];
            n40000GXC1 = H002E3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(0);
         /* Using cursor H002E5 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001GXC2 = H002E5_A40001GXC2[0];
            n40001GXC2 = H002E5_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
            AssignAttri("", false, "A40001GXC2", StringUtil.LTrimStr( (decimal)(A40001GXC2), 9, 0));
         }
         pr_default.close(1);
         /* Using cursor H002E7 */
         pr_default.execute(2);
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40002GXC2 = H002E7_A40002GXC2[0];
            n40002GXC2 = H002E7_n40002GXC2[0];
         }
         else
         {
            A40002GXC2 = 0;
            n40002GXC2 = false;
            AssignAttri("", false, "A40002GXC2", StringUtil.LTrimStr( (decimal)(A40002GXC2), 9, 0));
         }
         pr_default.close(2);
         /* Using cursor H002E9 */
         pr_default.execute(3);
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40003GXC2 = H002E9_A40003GXC2[0];
            n40003GXC2 = H002E9_n40003GXC2[0];
         }
         else
         {
            A40003GXC2 = 0;
            n40003GXC2 = false;
            AssignAttri("", false, "A40003GXC2", StringUtil.LTrimStr( (decimal)(A40003GXC2), 9, 0));
         }
         pr_default.close(3);
         /* Using cursor H002E11 */
         pr_default.execute(4, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40004GXC1 = H002E11_A40004GXC1[0];
            n40004GXC1 = H002E11_n40004GXC1[0];
         }
         else
         {
            A40004GXC1 = 0;
            n40004GXC1 = false;
            AssignAttri("", false, "A40004GXC1", StringUtil.LTrimStr( (decimal)(A40004GXC1), 9, 0));
         }
         pr_default.close(4);
         /* Using cursor H002E13 */
         pr_default.execute(5, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A40005GXC2 = H002E13_A40005GXC2[0];
            n40005GXC2 = H002E13_n40005GXC2[0];
         }
         else
         {
            A40005GXC2 = 0;
            n40005GXC2 = false;
            AssignAttri("", false, "A40005GXC2", StringUtil.LTrimStr( (decimal)(A40005GXC2), 9, 0));
         }
         pr_default.close(5);
         /* Using cursor H002E15 */
         pr_default.execute(6, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A40006GXC2 = H002E15_A40006GXC2[0];
            n40006GXC2 = H002E15_n40006GXC2[0];
         }
         else
         {
            A40006GXC2 = 0;
            n40006GXC2 = false;
            AssignAttri("", false, "A40006GXC2", StringUtil.LTrimStr( (decimal)(A40006GXC2), 9, 0));
         }
         pr_default.close(6);
         /* Using cursor H002E17 */
         pr_default.execute(7, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A40007GXC2 = H002E17_A40007GXC2[0];
            n40007GXC2 = H002E17_n40007GXC2[0];
         }
         else
         {
            A40007GXC2 = 0;
            n40007GXC2 = false;
            AssignAttri("", false, "A40007GXC2", StringUtil.LTrimStr( (decimal)(A40007GXC2), 9, 0));
         }
         pr_default.close(7);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_panel1_Width = cgiGet( "DVPANEL_PANEL1_Width");
            Dvpanel_panel1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autowidth"));
            Dvpanel_panel1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autoheight"));
            Dvpanel_panel1_Cls = cgiGet( "DVPANEL_PANEL1_Cls");
            Dvpanel_panel1_Title = cgiGet( "DVPANEL_PANEL1_Title");
            Dvpanel_panel1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Collapsible"));
            Dvpanel_panel1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Collapsed"));
            Dvpanel_panel1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Showcollapseicon"));
            Dvpanel_panel1_Iconposition = cgiGet( "DVPANEL_PANEL1_Iconposition");
            Dvpanel_panel1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANEL1_Autoscroll"));
            Dvpanel_tablecards2_Width = cgiGet( "DVPANEL_TABLECARDS2_Width");
            Dvpanel_tablecards2_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS2_Autowidth"));
            Dvpanel_tablecards2_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS2_Autoheight"));
            Dvpanel_tablecards2_Cls = cgiGet( "DVPANEL_TABLECARDS2_Cls");
            Dvpanel_tablecards2_Title = cgiGet( "DVPANEL_TABLECARDS2_Title");
            Dvpanel_tablecards2_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS2_Collapsible"));
            Dvpanel_tablecards2_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS2_Collapsed"));
            Dvpanel_tablecards2_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS2_Showcollapseicon"));
            Dvpanel_tablecards2_Iconposition = cgiGet( "DVPANEL_TABLECARDS2_Iconposition");
            Dvpanel_tablecards2_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS2_Autoscroll"));
            Ucprogress_qtde_registroign_on_Circlecaptiontype = cgiGet( "UCPROGRESS_QTDE_REGISTROIGN_ON_Circlecaptiontype");
            Ucprogress_qtde_registroign_on_Caption = cgiGet( "UCPROGRESS_QTDE_REGISTROIGN_ON_Caption");
            Ucprogress_qtde_registroign_on_Subtitle = cgiGet( "UCPROGRESS_QTDE_REGISTROIGN_ON_Subtitle");
            Ucprogress_qtde_registroign_on_Cls = cgiGet( "UCPROGRESS_QTDE_REGISTROIGN_ON_Cls");
            Ucprogress_qtde_registroign_on_Percentage = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS_QTDE_REGISTROIGN_ON_Percentage"), ",", "."));
            Ucprogress_qtde_registroign_on_Circlewidth = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS_QTDE_REGISTROIGN_ON_Circlewidth"), ",", "."));
            Ucprogress__qtde_registroign_off_Circlecaptiontype = cgiGet( "UCPROGRESS__QTDE_REGISTROIGN_OFF_Circlecaptiontype");
            Ucprogress__qtde_registroign_off_Caption = cgiGet( "UCPROGRESS__QTDE_REGISTROIGN_OFF_Caption");
            Ucprogress__qtde_registroign_off_Subtitle = cgiGet( "UCPROGRESS__QTDE_REGISTROIGN_OFF_Subtitle");
            Ucprogress__qtde_registroign_off_Cls = cgiGet( "UCPROGRESS__QTDE_REGISTROIGN_OFF_Cls");
            Ucprogress__qtde_registroign_off_Percentage = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS__QTDE_REGISTROIGN_OFF_Percentage"), ",", "."));
            Ucprogress__qtde_registroign_off_Circlewidth = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS__QTDE_REGISTROIGN_OFF_Circlewidth"), ",", "."));
            Ucprogress_qtde_veiculosemmovimento_Circlecaptiontype = cgiGet( "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Circlecaptiontype");
            Ucprogress_qtde_veiculosemmovimento_Caption = cgiGet( "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Caption");
            Ucprogress_qtde_veiculosemmovimento_Subtitle = cgiGet( "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Subtitle");
            Ucprogress_qtde_veiculosemmovimento_Cls = cgiGet( "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Cls");
            Ucprogress_qtde_veiculosemmovimento_Percentage = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Percentage"), ",", "."));
            Ucprogress_qtde_veiculosemmovimento_Circlewidth = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO_Circlewidth"), ",", "."));
            Dvpanel_tablecards_Width = cgiGet( "DVPANEL_TABLECARDS_Width");
            Dvpanel_tablecards_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autowidth"));
            Dvpanel_tablecards_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoheight"));
            Dvpanel_tablecards_Cls = cgiGet( "DVPANEL_TABLECARDS_Cls");
            Dvpanel_tablecards_Title = cgiGet( "DVPANEL_TABLECARDS_Title");
            Dvpanel_tablecards_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsible"));
            Dvpanel_tablecards_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsed"));
            Dvpanel_tablecards_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Showcollapseicon"));
            Dvpanel_tablecards_Iconposition = cgiGet( "DVPANEL_TABLECARDS_Iconposition");
            Dvpanel_tablecards_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoscroll"));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValuecard1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValuecard1_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUECARD1");
               GX_FocusControl = edtavValuecard1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV29ValueCard1 = 0;
               AssignAttri("", false, "AV29ValueCard1", StringUtil.LTrimStr( (decimal)(AV29ValueCard1), 8, 0));
            }
            else
            {
               AV29ValueCard1 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard1_Internalname), ",", "."));
               AssignAttri("", false, "AV29ValueCard1", StringUtil.LTrimStr( (decimal)(AV29ValueCard1), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValuecard3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValuecard3_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUECARD3");
               GX_FocusControl = edtavValuecard3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31ValueCard3 = 0;
               AssignAttri("", false, "AV31ValueCard3", StringUtil.LTrimStr( (decimal)(AV31ValueCard3), 8, 0));
            }
            else
            {
               AV31ValueCard3 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard3_Internalname), ",", "."));
               AssignAttri("", false, "AV31ValueCard3", StringUtil.LTrimStr( (decimal)(AV31ValueCard3), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValuecard2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValuecard2_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALUECARD2");
               GX_FocusControl = edtavValuecard2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28ValueCard2 = 0;
               AssignAttri("", false, "AV28ValueCard2", StringUtil.LTrimStr( (decimal)(AV28ValueCard2), 8, 0));
            }
            else
            {
               AV28ValueCard2 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard2_Internalname), ",", "."));
               AssignAttri("", false, "AV28ValueCard2", StringUtil.LTrimStr( (decimal)(AV28ValueCard2), 8, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"HomeIOT");
            AV29ValueCard1 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard1_Internalname), ",", "."));
            AssignAttri("", false, "AV29ValueCard1", StringUtil.LTrimStr( (decimal)(AV29ValueCard1), 8, 0));
            forbiddenHiddens.Add("ValueCard1", context.localUtil.Format( (decimal)(AV29ValueCard1), "ZZ,ZZZ,ZZ9"));
            AV31ValueCard3 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard3_Internalname), ",", "."));
            AssignAttri("", false, "AV31ValueCard3", StringUtil.LTrimStr( (decimal)(AV31ValueCard3), 8, 0));
            forbiddenHiddens.Add("ValueCard3", context.localUtil.Format( (decimal)(AV31ValueCard3), "ZZ,ZZZ,ZZ9"));
            AV28ValueCard2 = (int)(context.localUtil.CToN( cgiGet( edtavValuecard2_Internalname), ",", "."));
            AssignAttri("", false, "AV28ValueCard2", StringUtil.LTrimStr( (decimal)(AV28ValueCard2), 8, 0));
            forbiddenHiddens.Add("ValueCard2", context.localUtil.Format( (decimal)(AV28ValueCard2), "ZZ,ZZZ,ZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("homeiot:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E112E2 ();
         if (returnInSub) return;
      }

      protected void E112E2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_guid1 = (Guid)(AV7MqttConnectionGUID);
         new buscarconexaomqtt(context ).execute( out  GXt_guid1) ;
         AV7MqttConnectionGUID = (Guid)((Guid)(GXt_guid1));
         if ( (Guid.Empty==AV7MqttConnectionGUID) )
         {
            lblIconstatusconexao_Caption = "<i class='fas fa-times-circle AttributeColorDanger' style='font-size: 100px'></i>";
            AssignProp("", false, lblIconstatusconexao_Internalname, "Caption", lblIconstatusconexao_Caption, true);
            lblTxtstatus_Caption = "Desconectado";
            AssignProp("", false, lblTxtstatus_Internalname, "Caption", lblTxtstatus_Caption, true);
            bttBtnalterarconexao_Caption = "Conectar";
            AssignProp("", false, bttBtnalterarconexao_Internalname, "Caption", bttBtnalterarconexao_Caption, true);
         }
         else
         {
            AV10MQTTStatus = AV8MQTT.isconnected(AV7MqttConnectionGUID, out  AV9IsConnected);
            if ( AV9IsConnected )
            {
               lblIconstatusconexao_Caption = "<i class='fas fa-check-circle AttributeColorSuccess' style='font-size: 100px'></i>";
               AssignProp("", false, lblIconstatusconexao_Internalname, "Caption", lblIconstatusconexao_Caption, true);
               lblTxtstatus_Caption = "Conectado";
               AssignProp("", false, lblTxtstatus_Internalname, "Caption", lblTxtstatus_Caption, true);
               bttBtnalterarconexao_Caption = "Desconectar";
               AssignProp("", false, bttBtnalterarconexao_Internalname, "Caption", bttBtnalterarconexao_Caption, true);
            }
            else if ( ! AV9IsConnected )
            {
               lblIconstatusconexao_Caption = "<i class='fas fa-times-circle AttributeColorDanger' style='font-size: 100px'></i>";
               AssignProp("", false, lblIconstatusconexao_Internalname, "Caption", lblIconstatusconexao_Caption, true);
               lblTxtstatus_Caption = "Desconectado";
               AssignProp("", false, lblTxtstatus_Internalname, "Caption", lblTxtstatus_Caption, true);
               bttBtnalterarconexao_Caption = "Conectar";
               AssignProp("", false, bttBtnalterarconexao_Internalname, "Caption", bttBtnalterarconexao_Caption, true);
            }
         }
         /* Execute user subroutine: 'CARREGARGRAFICOS' */
         S112 ();
         if (returnInSub) return;
         if ( ! AV37IsAdministrator )
         {
            bttBtnalterarconexao_Visible = 0;
            AssignProp("", false, bttBtnalterarconexao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnalterarconexao_Visible), 5, 0), true);
         }
      }

      protected void E122E2( )
      {
         /* 'DoAlterarConexao' Routine */
         returnInSub = false;
         if ( AV9IsConnected )
         {
            new desconectarmqtt(context ).execute( out  AV12IsSucessoDesconexao) ;
            if ( AV12IsSucessoDesconexao )
            {
               lblIconstatusconexao_Caption = "<i class='fas fa-times-circle AttributeColorDanger' style='font-size: 100px'></i>";
               AssignProp("", false, lblIconstatusconexao_Internalname, "Caption", lblIconstatusconexao_Caption, true);
               AV9IsConnected = false;
               AssignAttri("", false, "AV9IsConnected", AV9IsConnected);
               lblTxtstatus_Caption = "Desconectado";
               AssignProp("", false, lblTxtstatus_Internalname, "Caption", lblTxtstatus_Caption, true);
               bttBtnalterarconexao_Caption = "Conectar";
               AssignProp("", false, bttBtnalterarconexao_Internalname, "Caption", bttBtnalterarconexao_Caption, true);
               GX_msglist.addItem("Desconectado com sucesso!");
            }
            else
            {
               lblIconstatusconexao_Caption = "<i class='fas fa-check-circle AttributeColorSuccess' style='font-size: 100px'></i>";
               AssignProp("", false, lblIconstatusconexao_Internalname, "Caption", lblIconstatusconexao_Caption, true);
               AV9IsConnected = true;
               AssignAttri("", false, "AV9IsConnected", AV9IsConnected);
               lblTxtstatus_Caption = "Conectado";
               AssignProp("", false, lblTxtstatus_Internalname, "Caption", lblTxtstatus_Caption, true);
               bttBtnalterarconexao_Caption = "Desconectar";
               AssignProp("", false, bttBtnalterarconexao_Internalname, "Caption", bttBtnalterarconexao_Caption, true);
               GX_msglist.addItem("Ocorreu uma falha ao desconectar, tente novamente.");
            }
         }
         else if ( ! AV9IsConnected )
         {
            new conectarmqtt(context ).execute( out  AV11IsSucessoConexao) ;
            if ( AV11IsSucessoConexao )
            {
               lblIconstatusconexao_Caption = "<i class='fas fa-check-circle AttributeColorSuccess' style='font-size: 100px'></i>";
               AssignProp("", false, lblIconstatusconexao_Internalname, "Caption", lblIconstatusconexao_Caption, true);
               AV9IsConnected = true;
               AssignAttri("", false, "AV9IsConnected", AV9IsConnected);
               lblTxtstatus_Caption = "Conectado";
               AssignProp("", false, lblTxtstatus_Internalname, "Caption", lblTxtstatus_Caption, true);
               bttBtnalterarconexao_Caption = "Desconectar";
               AssignProp("", false, bttBtnalterarconexao_Internalname, "Caption", bttBtnalterarconexao_Caption, true);
               GX_msglist.addItem("Conexão bem sucedida!");
               new subscrevermqtt(context).executeSubmit( ) ;
            }
            else
            {
               lblIconstatusconexao_Caption = "<i class='fas fa-times-circle AttributeColorDanger' style='font-size: 100px'></i>";
               AssignProp("", false, lblIconstatusconexao_Internalname, "Caption", lblIconstatusconexao_Caption, true);
               AV9IsConnected = false;
               AssignAttri("", false, "AV9IsConnected", AV9IsConnected);
               lblTxtstatus_Caption = "Desconectado";
               AssignProp("", false, lblTxtstatus_Internalname, "Caption", lblTxtstatus_Caption, true);
               bttBtnalterarconexao_Caption = "Conectar";
               AssignProp("", false, bttBtnalterarconexao_Internalname, "Caption", bttBtnalterarconexao_Caption, true);
               GX_msglist.addItem("Ocorreu uma falha ao conectar, tente novamente.");
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'CARREGARGRAFICOS' Routine */
         returnInSub = false;
         /* Using cursor H002E19 */
         pr_default.execute(8);
         if ( (pr_default.getStatus(8) != 101) )
         {
            A40000GXC1 = H002E19_A40000GXC1[0];
            n40000GXC1 = H002E19_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(8);
         /* Using cursor H002E21 */
         pr_default.execute(9);
         if ( (pr_default.getStatus(9) != 101) )
         {
            A40001GXC2 = H002E21_A40001GXC2[0];
            n40001GXC2 = H002E21_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
            AssignAttri("", false, "A40001GXC2", StringUtil.LTrimStr( (decimal)(A40001GXC2), 9, 0));
         }
         pr_default.close(9);
         /* Using cursor H002E23 */
         pr_default.execute(10);
         if ( (pr_default.getStatus(10) != 101) )
         {
            A40002GXC2 = H002E23_A40002GXC2[0];
            n40002GXC2 = H002E23_n40002GXC2[0];
         }
         else
         {
            A40002GXC2 = 0;
            n40002GXC2 = false;
            AssignAttri("", false, "A40002GXC2", StringUtil.LTrimStr( (decimal)(A40002GXC2), 9, 0));
         }
         pr_default.close(10);
         /* Using cursor H002E25 */
         pr_default.execute(11);
         if ( (pr_default.getStatus(11) != 101) )
         {
            A40003GXC2 = H002E25_A40003GXC2[0];
            n40003GXC2 = H002E25_n40003GXC2[0];
         }
         else
         {
            A40003GXC2 = 0;
            n40003GXC2 = false;
            AssignAttri("", false, "A40003GXC2", StringUtil.LTrimStr( (decimal)(A40003GXC2), 9, 0));
         }
         pr_default.close(11);
         /* Using cursor H002E27 */
         pr_default.execute(12, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A40004GXC1 = H002E27_A40004GXC1[0];
            n40004GXC1 = H002E27_n40004GXC1[0];
         }
         else
         {
            A40004GXC1 = 0;
            n40004GXC1 = false;
            AssignAttri("", false, "A40004GXC1", StringUtil.LTrimStr( (decimal)(A40004GXC1), 9, 0));
         }
         pr_default.close(12);
         /* Using cursor H002E29 */
         pr_default.execute(13, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A40005GXC2 = H002E29_A40005GXC2[0];
            n40005GXC2 = H002E29_n40005GXC2[0];
         }
         else
         {
            A40005GXC2 = 0;
            n40005GXC2 = false;
            AssignAttri("", false, "A40005GXC2", StringUtil.LTrimStr( (decimal)(A40005GXC2), 9, 0));
         }
         pr_default.close(13);
         /* Using cursor H002E31 */
         pr_default.execute(14, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A40006GXC2 = H002E31_A40006GXC2[0];
            n40006GXC2 = H002E31_n40006GXC2[0];
         }
         else
         {
            A40006GXC2 = 0;
            n40006GXC2 = false;
            AssignAttri("", false, "A40006GXC2", StringUtil.LTrimStr( (decimal)(A40006GXC2), 9, 0));
         }
         pr_default.close(14);
         /* Using cursor H002E33 */
         pr_default.execute(15, new Object[] {AV30GAMGUID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A40007GXC2 = H002E33_A40007GXC2[0];
            n40007GXC2 = H002E33_n40007GXC2[0];
         }
         else
         {
            A40007GXC2 = 0;
            n40007GXC2 = false;
            AssignAttri("", false, "A40007GXC2", StringUtil.LTrimStr( (decimal)(A40007GXC2), 9, 0));
         }
         pr_default.close(15);
         new buscargamguidusuariologado(context ).execute( out  AV30GAMGUID) ;
         AssignAttri("", false, "AV30GAMGUID", AV30GAMGUID);
         AV37IsAdministrator = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).checkrole("Administrator");
         AssignAttri("", false, "AV37IsAdministrator", AV37IsAdministrator);
         if ( AV37IsAdministrator )
         {
            AV23QtdVeiculos = A40000GXC1;
            AV25QtdVeiculosIGN_ON = A40001GXC2;
            AV24QtdVeiculosIGN_OFF = A40002GXC2;
            AV27QtdVeiculos_EmMovimento = A40003GXC2;
         }
         else
         {
            AV23QtdVeiculos = A40004GXC1;
            AV25QtdVeiculosIGN_ON = A40005GXC2;
            AV24QtdVeiculosIGN_OFF = A40006GXC2;
            AV27QtdVeiculos_EmMovimento = A40007GXC2;
         }
         if ( ! (0==AV23QtdVeiculos) )
         {
            Ucprogress_qtde_registroign_on_Percentage = (int)((AV25QtdVeiculosIGN_ON/ (decimal)(AV23QtdVeiculos))*100);
            ucUcprogress_qtde_registroign_on.SendProperty(context, "", false, Ucprogress_qtde_registroign_on_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Ucprogress_qtde_registroign_on_Percentage), 9, 0));
            Ucprogress_qtde_registroign_on_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(AV25QtdVeiculosIGN_ON), 10, 0));
            ucUcprogress_qtde_registroign_on.SendProperty(context, "", false, Ucprogress_qtde_registroign_on_Internalname, "Caption", Ucprogress_qtde_registroign_on_Caption);
            Ucprogress__qtde_registroign_off_Percentage = (int)((AV24QtdVeiculosIGN_OFF/ (decimal)(AV23QtdVeiculos))*100);
            ucUcprogress__qtde_registroign_off.SendProperty(context, "", false, Ucprogress__qtde_registroign_off_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Ucprogress__qtde_registroign_off_Percentage), 9, 0));
            Ucprogress__qtde_registroign_off_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(AV24QtdVeiculosIGN_OFF), 10, 0));
            ucUcprogress__qtde_registroign_off.SendProperty(context, "", false, Ucprogress__qtde_registroign_off_Internalname, "Caption", Ucprogress__qtde_registroign_off_Caption);
            Ucprogress_qtde_veiculosemmovimento_Percentage = (int)((AV27QtdVeiculos_EmMovimento/ (decimal)(AV23QtdVeiculos))*100);
            ucUcprogress_qtde_veiculosemmovimento.SendProperty(context, "", false, Ucprogress_qtde_veiculosemmovimento_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Ucprogress_qtde_veiculosemmovimento_Percentage), 9, 0));
            Ucprogress_qtde_veiculosemmovimento_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(AV27QtdVeiculos_EmMovimento), 10, 0));
            ucUcprogress_qtde_veiculosemmovimento.SendProperty(context, "", false, Ucprogress_qtde_veiculosemmovimento_Internalname, "Caption", Ucprogress_qtde_veiculosemmovimento_Caption);
         }
         else
         {
            Ucprogress_qtde_registroign_on_Percentage = 0;
            ucUcprogress_qtde_registroign_on.SendProperty(context, "", false, Ucprogress_qtde_registroign_on_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Ucprogress_qtde_registroign_on_Percentage), 9, 0));
            Ucprogress_qtde_registroign_on_Caption = "0";
            ucUcprogress_qtde_registroign_on.SendProperty(context, "", false, Ucprogress_qtde_registroign_on_Internalname, "Caption", Ucprogress_qtde_registroign_on_Caption);
            Ucprogress__qtde_registroign_off_Percentage = 0;
            ucUcprogress__qtde_registroign_off.SendProperty(context, "", false, Ucprogress__qtde_registroign_off_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Ucprogress__qtde_registroign_off_Percentage), 9, 0));
            Ucprogress__qtde_registroign_off_Caption = "0";
            ucUcprogress__qtde_registroign_off.SendProperty(context, "", false, Ucprogress__qtde_registroign_off_Internalname, "Caption", Ucprogress__qtde_registroign_off_Caption);
            Ucprogress_qtde_veiculosemmovimento_Percentage = 0;
            ucUcprogress_qtde_veiculosemmovimento.SendProperty(context, "", false, Ucprogress_qtde_veiculosemmovimento_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Ucprogress_qtde_veiculosemmovimento_Percentage), 9, 0));
            Ucprogress_qtde_veiculosemmovimento_Caption = "0";
            ucUcprogress_qtde_veiculosemmovimento.SendProperty(context, "", false, Ucprogress_qtde_veiculosemmovimento_Internalname, "Caption", Ucprogress_qtde_veiculosemmovimento_Caption);
         }
         /* Optimized group. */
         pr_default.dynParam(16, new Object[]{ new Object[]{
                                              AV37IsAdministrator ,
                                              A96FrotaProprietarioGAMGUID ,
                                              AV30GAMGUID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H002E34 */
         pr_default.execute(16, new Object[] {AV30GAMGUID});
         cV29ValueCard1 = H002E34_AV29ValueCard1[0];
         AssignAttri("", false, "cV29ValueCard1", StringUtil.LTrimStr( (decimal)(cV29ValueCard1), 8, 0));
         pr_default.close(16);
         AV29ValueCard1 = (int)(AV29ValueCard1+cV29ValueCard1*1);
         AssignAttri("", false, "AV29ValueCard1", StringUtil.LTrimStr( (decimal)(AV29ValueCard1), 8, 0));
         /* End optimized group. */
         /* Optimized group. */
         pr_default.dynParam(17, new Object[]{ new Object[]{
                                              AV37IsAdministrator ,
                                              A105VeiculoGAMGUID ,
                                              AV30GAMGUID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H002E35 */
         pr_default.execute(17, new Object[] {AV30GAMGUID});
         cV28ValueCard2 = H002E35_AV28ValueCard2[0];
         AssignAttri("", false, "cV28ValueCard2", StringUtil.LTrimStr( (decimal)(cV28ValueCard2), 8, 0));
         pr_default.close(17);
         AV28ValueCard2 = (int)(AV28ValueCard2+cV28ValueCard2*1);
         AssignAttri("", false, "AV28ValueCard2", StringUtil.LTrimStr( (decimal)(AV28ValueCard2), 8, 0));
         /* End optimized group. */
         /* Optimized group. */
         pr_default.dynParam(18, new Object[]{ new Object[]{
                                              AV37IsAdministrator ,
                                              A151RastreadorGAMGUIDProprietario ,
                                              AV30GAMGUID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H002E36 */
         pr_default.execute(18, new Object[] {AV30GAMGUID});
         cV31ValueCard3 = H002E36_AV31ValueCard3[0];
         AssignAttri("", false, "cV31ValueCard3", StringUtil.LTrimStr( (decimal)(cV31ValueCard3), 8, 0));
         pr_default.close(18);
         AV31ValueCard3 = (int)(AV31ValueCard3+cV31ValueCard3*1);
         AssignAttri("", false, "AV31ValueCard3", StringUtil.LTrimStr( (decimal)(AV31ValueCard3), 8, 0));
         /* End optimized group. */
      }

      protected void nextLoad( )
      {
      }

      protected void E132E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA2E2( ) ;
         WS2E2( ) ;
         WE2E2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918311556", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("homeiot.js", "?202142918311558", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblIconstatusconexao_Internalname = "ICONSTATUSCONEXAO";
         lblTxtstatus_Internalname = "TXTSTATUS";
         bttBtnalterarconexao_Internalname = "BTNALTERARCONEXAO";
         divTableconexao_Internalname = "TABLECONEXAO";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         edtavValuecard1_Internalname = "vVALUECARD1";
         lblMoreinfocard1caption_Internalname = "MOREINFOCARD1CAPTION";
         divCard1_Internalname = "CARD1";
         edtavValuecard3_Internalname = "vVALUECARD3";
         lblMoreinfocard3caption_Internalname = "MOREINFOCARD3CAPTION";
         divCard3_Internalname = "CARD3";
         edtavValuecard2_Internalname = "vVALUECARD2";
         lblMoreinfocard2caption_Internalname = "MOREINFOCARD2CAPTION";
         divCard2_Internalname = "CARD2";
         divTablecards2_Internalname = "TABLECARDS2";
         Dvpanel_tablecards2_Internalname = "DVPANEL_TABLECARDS2";
         Ucprogress_qtde_registroign_on_Internalname = "UCPROGRESS_QTDE_REGISTROIGN_ON";
         Ucprogress__qtde_registroign_off_Internalname = "UCPROGRESS__QTDE_REGISTROIGN_OFF";
         Ucprogress_qtde_veiculosemmovimento_Internalname = "UCPROGRESS_QTDE_VEICULOSEMMOVIMENTO";
         divTableprogresscards_Internalname = "TABLEPROGRESSCARDS";
         divTablecards_Internalname = "TABLECARDS";
         Dvpanel_tablecards_Internalname = "DVPANEL_TABLECARDS";
         divTablecontent_Internalname = "TABLECONTENT";
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
         edtavValuecard2_Jsonclick = "";
         edtavValuecard2_Enabled = 1;
         edtavValuecard3_Jsonclick = "";
         edtavValuecard3_Enabled = 1;
         edtavValuecard1_Jsonclick = "";
         edtavValuecard1_Enabled = 1;
         bttBtnalterarconexao_Caption = "Desconectar";
         bttBtnalterarconexao_Visible = 1;
         lblTxtstatus_Caption = "Conectado";
         lblIconstatusconexao_Caption = "<i class='fas fa-check-circle AttributeColorSuccess' style='font-size: 100px'></i>";
         Dvpanel_tablecards_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Iconposition = "Right";
         Dvpanel_tablecards_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Title = "";
         Dvpanel_tablecards_Cls = "PanelNoHeader";
         Dvpanel_tablecards_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Width = "100%";
         Ucprogress_qtde_veiculosemmovimento_Circlewidth = 180;
         Ucprogress_qtde_veiculosemmovimento_Percentage = 0;
         Ucprogress_qtde_veiculosemmovimento_Cls = "ProgressBigCircleBaseColor";
         Ucprogress_qtde_veiculosemmovimento_Subtitle = "Veículos em Movimento";
         Ucprogress_qtde_veiculosemmovimento_Caption = "0";
         Ucprogress_qtde_veiculosemmovimento_Circlecaptiontype = "CaptionAndSubtitle";
         Ucprogress__qtde_registroign_off_Circlewidth = 180;
         Ucprogress__qtde_registroign_off_Percentage = 0;
         Ucprogress__qtde_registroign_off_Cls = "ProgressBigCircleBaseColor";
         Ucprogress__qtde_registroign_off_Subtitle = "Veículos C/ IGN OFF";
         Ucprogress__qtde_registroign_off_Caption = "0";
         Ucprogress__qtde_registroign_off_Circlecaptiontype = "CaptionAndSubtitle";
         Ucprogress_qtde_registroign_on_Circlewidth = 180;
         Ucprogress_qtde_registroign_on_Percentage = 0;
         Ucprogress_qtde_registroign_on_Cls = "ProgressBigCircleBaseColor";
         Ucprogress_qtde_registroign_on_Subtitle = "Veículos C/ IGN ON";
         Ucprogress_qtde_registroign_on_Caption = "0";
         Ucprogress_qtde_registroign_on_Circlecaptiontype = "CaptionAndSubtitle";
         Dvpanel_tablecards2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecards2_Iconposition = "Right";
         Dvpanel_tablecards2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecards2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecards2_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecards2_Title = "";
         Dvpanel_tablecards2_Cls = "PanelNoHeader";
         Dvpanel_tablecards2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecards2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecards2_Width = "100%";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Status do Rastreamento";
         Dvpanel_panel1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Home";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV29ValueCard1',fld:'vVALUECARD1',pic:'ZZ,ZZZ,ZZ9'},{av:'AV31ValueCard3',fld:'vVALUECARD3',pic:'ZZ,ZZZ,ZZ9'},{av:'AV28ValueCard2',fld:'vVALUECARD2',pic:'ZZ,ZZZ,ZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOALTERARCONEXAO'","{handler:'E122E2',iparms:[{av:'AV9IsConnected',fld:'vISCONNECTED',pic:''}]");
         setEventMetadata("'DOALTERARCONEXAO'",",oparms:[{av:'lblIconstatusconexao_Caption',ctrl:'ICONSTATUSCONEXAO',prop:'Caption'},{av:'AV9IsConnected',fld:'vISCONNECTED',pic:''},{av:'lblTxtstatus_Caption',ctrl:'TXTSTATUS',prop:'Caption'},{ctrl:'BTNALTERARCONEXAO',prop:'Caption'}]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblIconstatusconexao_Jsonclick = "";
         lblTxtstatus_Jsonclick = "";
         TempTags = "";
         bttBtnalterarconexao_Jsonclick = "";
         ucDvpanel_tablecards2 = new GXUserControl();
         lblMoreinfocard1caption_Jsonclick = "";
         lblMoreinfocard3caption_Jsonclick = "";
         lblMoreinfocard2caption_Jsonclick = "";
         ucDvpanel_tablecards = new GXUserControl();
         ucUcprogress_qtde_registroign_on = new GXUserControl();
         ucUcprogress__qtde_registroign_off = new GXUserControl();
         ucUcprogress_qtde_veiculosemmovimento = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H002E3_A40000GXC1 = new int[1] ;
         H002E3_n40000GXC1 = new bool[] {false} ;
         H002E5_A40001GXC2 = new int[1] ;
         H002E5_n40001GXC2 = new bool[] {false} ;
         H002E7_A40002GXC2 = new int[1] ;
         H002E7_n40002GXC2 = new bool[] {false} ;
         H002E9_A40003GXC2 = new int[1] ;
         H002E9_n40003GXC2 = new bool[] {false} ;
         AV30GAMGUID = "";
         H002E11_A40004GXC1 = new int[1] ;
         H002E11_n40004GXC1 = new bool[] {false} ;
         H002E13_A40005GXC2 = new int[1] ;
         H002E13_n40005GXC2 = new bool[] {false} ;
         H002E15_A40006GXC2 = new int[1] ;
         H002E15_n40006GXC2 = new bool[] {false} ;
         H002E17_A40007GXC2 = new int[1] ;
         H002E17_n40007GXC2 = new bool[] {false} ;
         hsh = "";
         AV7MqttConnectionGUID = (Guid)(Guid.Empty);
         GXt_guid1 = (Guid)(Guid.Empty);
         AV10MQTTStatus = new SdtMqttStatus(context);
         AV8MQTT = new SdtMQTT(context);
         H002E19_A40000GXC1 = new int[1] ;
         H002E19_n40000GXC1 = new bool[] {false} ;
         H002E21_A40001GXC2 = new int[1] ;
         H002E21_n40001GXC2 = new bool[] {false} ;
         H002E23_A40002GXC2 = new int[1] ;
         H002E23_n40002GXC2 = new bool[] {false} ;
         H002E25_A40003GXC2 = new int[1] ;
         H002E25_n40003GXC2 = new bool[] {false} ;
         H002E27_A40004GXC1 = new int[1] ;
         H002E27_n40004GXC1 = new bool[] {false} ;
         H002E29_A40005GXC2 = new int[1] ;
         H002E29_n40005GXC2 = new bool[] {false} ;
         H002E31_A40006GXC2 = new int[1] ;
         H002E31_n40006GXC2 = new bool[] {false} ;
         H002E33_A40007GXC2 = new int[1] ;
         H002E33_n40007GXC2 = new bool[] {false} ;
         A96FrotaProprietarioGAMGUID = "";
         H002E34_AV29ValueCard1 = new int[1] ;
         A105VeiculoGAMGUID = "";
         H002E35_AV28ValueCard2 = new int[1] ;
         A151RastreadorGAMGUIDProprietario = "";
         H002E36_AV31ValueCard3 = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.homeiot__default(),
            new Object[][] {
                new Object[] {
               H002E3_A40000GXC1, H002E3_n40000GXC1
               }
               , new Object[] {
               H002E5_A40001GXC2, H002E5_n40001GXC2
               }
               , new Object[] {
               H002E7_A40002GXC2, H002E7_n40002GXC2
               }
               , new Object[] {
               H002E9_A40003GXC2, H002E9_n40003GXC2
               }
               , new Object[] {
               H002E11_A40004GXC1, H002E11_n40004GXC1
               }
               , new Object[] {
               H002E13_A40005GXC2, H002E13_n40005GXC2
               }
               , new Object[] {
               H002E15_A40006GXC2, H002E15_n40006GXC2
               }
               , new Object[] {
               H002E17_A40007GXC2, H002E17_n40007GXC2
               }
               , new Object[] {
               H002E19_A40000GXC1, H002E19_n40000GXC1
               }
               , new Object[] {
               H002E21_A40001GXC2, H002E21_n40001GXC2
               }
               , new Object[] {
               H002E23_A40002GXC2, H002E23_n40002GXC2
               }
               , new Object[] {
               H002E25_A40003GXC2, H002E25_n40003GXC2
               }
               , new Object[] {
               H002E27_A40004GXC1, H002E27_n40004GXC1
               }
               , new Object[] {
               H002E29_A40005GXC2, H002E29_n40005GXC2
               }
               , new Object[] {
               H002E31_A40006GXC2, H002E31_n40006GXC2
               }
               , new Object[] {
               H002E33_A40007GXC2, H002E33_n40007GXC2
               }
               , new Object[] {
               H002E34_AV29ValueCard1
               }
               , new Object[] {
               H002E35_AV28ValueCard2
               }
               , new Object[] {
               H002E36_AV31ValueCard3
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavValuecard1_Enabled = 0;
         edtavValuecard3_Enabled = 0;
         edtavValuecard2_Enabled = 0;
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV29ValueCard1 ;
      private int AV31ValueCard3 ;
      private int AV28ValueCard2 ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int A40002GXC2 ;
      private int A40003GXC2 ;
      private int A40004GXC1 ;
      private int A40005GXC2 ;
      private int A40006GXC2 ;
      private int A40007GXC2 ;
      private int Ucprogress_qtde_registroign_on_Percentage ;
      private int Ucprogress_qtde_registroign_on_Circlewidth ;
      private int Ucprogress__qtde_registroign_off_Percentage ;
      private int Ucprogress__qtde_registroign_off_Circlewidth ;
      private int Ucprogress_qtde_veiculosemmovimento_Percentage ;
      private int Ucprogress_qtde_veiculosemmovimento_Circlewidth ;
      private int bttBtnalterarconexao_Visible ;
      private int edtavValuecard1_Enabled ;
      private int edtavValuecard3_Enabled ;
      private int edtavValuecard2_Enabled ;
      private int cV29ValueCard1 ;
      private int cV28ValueCard2 ;
      private int cV31ValueCard3 ;
      private int idxLst ;
      private long AV23QtdVeiculos ;
      private long AV25QtdVeiculosIGN_ON ;
      private long AV24QtdVeiculosIGN_OFF ;
      private long AV27QtdVeiculos_EmMovimento ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_panel1_Width ;
      private string Dvpanel_panel1_Cls ;
      private string Dvpanel_panel1_Title ;
      private string Dvpanel_panel1_Iconposition ;
      private string Dvpanel_tablecards2_Width ;
      private string Dvpanel_tablecards2_Cls ;
      private string Dvpanel_tablecards2_Title ;
      private string Dvpanel_tablecards2_Iconposition ;
      private string Ucprogress_qtde_registroign_on_Circlecaptiontype ;
      private string Ucprogress_qtde_registroign_on_Caption ;
      private string Ucprogress_qtde_registroign_on_Subtitle ;
      private string Ucprogress_qtde_registroign_on_Cls ;
      private string Ucprogress__qtde_registroign_off_Circlecaptiontype ;
      private string Ucprogress__qtde_registroign_off_Caption ;
      private string Ucprogress__qtde_registroign_off_Subtitle ;
      private string Ucprogress__qtde_registroign_off_Cls ;
      private string Ucprogress_qtde_veiculosemmovimento_Circlecaptiontype ;
      private string Ucprogress_qtde_veiculosemmovimento_Caption ;
      private string Ucprogress_qtde_veiculosemmovimento_Subtitle ;
      private string Ucprogress_qtde_veiculosemmovimento_Cls ;
      private string Dvpanel_tablecards_Width ;
      private string Dvpanel_tablecards_Cls ;
      private string Dvpanel_tablecards_Title ;
      private string Dvpanel_tablecards_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_panel1_Internalname ;
      private string divPanel1_Internalname ;
      private string divTableconexao_Internalname ;
      private string lblIconstatusconexao_Internalname ;
      private string lblIconstatusconexao_Caption ;
      private string lblIconstatusconexao_Jsonclick ;
      private string lblTxtstatus_Internalname ;
      private string lblTxtstatus_Caption ;
      private string lblTxtstatus_Jsonclick ;
      private string TempTags ;
      private string bttBtnalterarconexao_Internalname ;
      private string bttBtnalterarconexao_Caption ;
      private string bttBtnalterarconexao_Jsonclick ;
      private string Dvpanel_tablecards2_Internalname ;
      private string divTablecards2_Internalname ;
      private string divCard1_Internalname ;
      private string edtavValuecard1_Internalname ;
      private string edtavValuecard1_Jsonclick ;
      private string lblMoreinfocard1caption_Internalname ;
      private string lblMoreinfocard1caption_Jsonclick ;
      private string divCard3_Internalname ;
      private string edtavValuecard3_Internalname ;
      private string edtavValuecard3_Jsonclick ;
      private string lblMoreinfocard3caption_Internalname ;
      private string lblMoreinfocard3caption_Jsonclick ;
      private string divCard2_Internalname ;
      private string edtavValuecard2_Internalname ;
      private string edtavValuecard2_Jsonclick ;
      private string lblMoreinfocard2caption_Internalname ;
      private string lblMoreinfocard2caption_Jsonclick ;
      private string Dvpanel_tablecards_Internalname ;
      private string divTablecards_Internalname ;
      private string divTableprogresscards_Internalname ;
      private string Ucprogress_qtde_registroign_on_Internalname ;
      private string Ucprogress__qtde_registroign_off_Internalname ;
      private string Ucprogress_qtde_veiculosemmovimento_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string AV30GAMGUID ;
      private string hsh ;
      private string A96FrotaProprietarioGAMGUID ;
      private string A105VeiculoGAMGUID ;
      private string A151RastreadorGAMGUIDProprietario ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9IsConnected ;
      private bool Dvpanel_panel1_Autowidth ;
      private bool Dvpanel_panel1_Autoheight ;
      private bool Dvpanel_panel1_Collapsible ;
      private bool Dvpanel_panel1_Collapsed ;
      private bool Dvpanel_panel1_Showcollapseicon ;
      private bool Dvpanel_panel1_Autoscroll ;
      private bool Dvpanel_tablecards2_Autowidth ;
      private bool Dvpanel_tablecards2_Autoheight ;
      private bool Dvpanel_tablecards2_Collapsible ;
      private bool Dvpanel_tablecards2_Collapsed ;
      private bool Dvpanel_tablecards2_Showcollapseicon ;
      private bool Dvpanel_tablecards2_Autoscroll ;
      private bool Dvpanel_tablecards_Autowidth ;
      private bool Dvpanel_tablecards_Autoheight ;
      private bool Dvpanel_tablecards_Collapsible ;
      private bool Dvpanel_tablecards_Collapsed ;
      private bool Dvpanel_tablecards_Showcollapseicon ;
      private bool Dvpanel_tablecards_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC2 ;
      private bool n40003GXC2 ;
      private bool n40004GXC1 ;
      private bool n40005GXC2 ;
      private bool n40006GXC2 ;
      private bool n40007GXC2 ;
      private bool returnInSub ;
      private bool AV37IsAdministrator ;
      private bool AV12IsSucessoDesconexao ;
      private bool AV11IsSucessoConexao ;
      private Guid AV7MqttConnectionGUID ;
      private Guid GXt_guid1 ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucDvpanel_tablecards2 ;
      private GXUserControl ucDvpanel_tablecards ;
      private GXUserControl ucUcprogress_qtde_registroign_on ;
      private GXUserControl ucUcprogress__qtde_registroign_off ;
      private GXUserControl ucUcprogress_qtde_veiculosemmovimento ;
      private SdtMQTT AV8MQTT ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H002E3_A40000GXC1 ;
      private bool[] H002E3_n40000GXC1 ;
      private int[] H002E5_A40001GXC2 ;
      private bool[] H002E5_n40001GXC2 ;
      private int[] H002E7_A40002GXC2 ;
      private bool[] H002E7_n40002GXC2 ;
      private int[] H002E9_A40003GXC2 ;
      private bool[] H002E9_n40003GXC2 ;
      private int[] H002E11_A40004GXC1 ;
      private bool[] H002E11_n40004GXC1 ;
      private int[] H002E13_A40005GXC2 ;
      private bool[] H002E13_n40005GXC2 ;
      private int[] H002E15_A40006GXC2 ;
      private bool[] H002E15_n40006GXC2 ;
      private int[] H002E17_A40007GXC2 ;
      private bool[] H002E17_n40007GXC2 ;
      private int[] H002E19_A40000GXC1 ;
      private bool[] H002E19_n40000GXC1 ;
      private int[] H002E21_A40001GXC2 ;
      private bool[] H002E21_n40001GXC2 ;
      private int[] H002E23_A40002GXC2 ;
      private bool[] H002E23_n40002GXC2 ;
      private int[] H002E25_A40003GXC2 ;
      private bool[] H002E25_n40003GXC2 ;
      private int[] H002E27_A40004GXC1 ;
      private bool[] H002E27_n40004GXC1 ;
      private int[] H002E29_A40005GXC2 ;
      private bool[] H002E29_n40005GXC2 ;
      private int[] H002E31_A40006GXC2 ;
      private bool[] H002E31_n40006GXC2 ;
      private int[] H002E33_A40007GXC2 ;
      private bool[] H002E33_n40007GXC2 ;
      private int[] H002E34_AV29ValueCard1 ;
      private int[] H002E35_AV28ValueCard2 ;
      private int[] H002E36_AV31ValueCard3 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtMqttStatus AV10MQTTStatus ;
   }

   public class homeiot__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002E34( IGxContext context ,
                                              bool AV37IsAdministrator ,
                                              string A96FrotaProprietarioGAMGUID ,
                                              string AV30GAMGUID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Frota]";
         if ( ! AV37IsAdministrator )
         {
            AddWhere(sWhereString, "([FrotaProprietarioGAMGUID] = @AV30GAMGUID)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H002E35( IGxContext context ,
                                              bool AV37IsAdministrator ,
                                              string A105VeiculoGAMGUID ,
                                              string AV30GAMGUID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Veiculo]";
         if ( ! AV37IsAdministrator )
         {
            AddWhere(sWhereString, "([VeiculoGAMGUID] = @AV30GAMGUID)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H002E36( IGxContext context ,
                                              bool AV37IsAdministrator ,
                                              string A151RastreadorGAMGUIDProprietario ,
                                              string AV30GAMGUID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[1];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Rastreador]";
         if ( ! AV37IsAdministrator )
         {
            AddWhere(sWhereString, "([RastreadorGAMGUIDProprietario] = @AV30GAMGUID)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 16 :
                     return conditional_H002E34(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
               case 17 :
                     return conditional_H002E35(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
               case 18 :
                     return conditional_H002E36(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002E3;
          prmH002E3 = new Object[] {
          };
          Object[] prmH002E5;
          prmH002E5 = new Object[] {
          };
          Object[] prmH002E7;
          prmH002E7 = new Object[] {
          };
          Object[] prmH002E9;
          prmH002E9 = new Object[] {
          };
          Object[] prmH002E11;
          prmH002E11 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E13;
          prmH002E13 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E15;
          prmH002E15 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E17;
          prmH002E17 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E19;
          prmH002E19 = new Object[] {
          };
          Object[] prmH002E21;
          prmH002E21 = new Object[] {
          };
          Object[] prmH002E23;
          prmH002E23 = new Object[] {
          };
          Object[] prmH002E25;
          prmH002E25 = new Object[] {
          };
          Object[] prmH002E27;
          prmH002E27 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E29;
          prmH002E29 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E31;
          prmH002E31 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E33;
          prmH002E33 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E34;
          prmH002E34 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E35;
          prmH002E35 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          Object[] prmH002E36;
          prmH002E36 = new Object[] {
          new Object[] {"@AV30GAMGUID",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("H002E3", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM [Veiculo] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E5", "SELECT COALESCE( T1.[GXC2], 0) AS GXC2 FROM (SELECT COUNT(*) AS GXC2 FROM [UltimoDadoLido] WHERE [UltimoDadoLidoIgnicao] = 1 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E7", "SELECT COALESCE( T1.[GXC2], 0) AS GXC3 FROM (SELECT COUNT(*) AS GXC2 FROM [UltimoDadoLido] WHERE [UltimoDadoLidoIgnicao] = 2 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E9", "SELECT COALESCE( T1.[GXC2], 0) AS GXC4 FROM (SELECT COUNT(*) AS GXC2 FROM [UltimoDadoLido] WHERE ( [UltimoDadoLidoVelocidade] > 0) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E11", "SELECT COALESCE( T1.[GXC1], 0) AS GXC5 FROM (SELECT COUNT(*) AS GXC1 FROM [Veiculo] WHERE [VeiculoGAMGUID] = @AV30GAMGUID ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E13", "SELECT COALESCE( T1.[GXC2], 0) AS GXC6 FROM (SELECT COUNT(*) AS GXC2 FROM ([UltimoDadoLido] T2 LEFT JOIN [Veiculo] T3 ON T3.[VeiculoPlaca] = T2.[UltimoDadoLidoPlaca]) WHERE (T2.[UltimoDadoLidoIgnicao] = 1) AND (COALESCE( T3.[VeiculoGAMGUID], '') = @AV30GAMGUID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E15", "SELECT COALESCE( T1.[GXC2], 0) AS GXC7 FROM (SELECT COUNT(*) AS GXC2 FROM ([UltimoDadoLido] T2 LEFT JOIN [Veiculo] T3 ON T3.[VeiculoPlaca] = T2.[UltimoDadoLidoPlaca]) WHERE (T2.[UltimoDadoLidoIgnicao] = 2) AND (COALESCE( T3.[VeiculoGAMGUID], '') = @AV30GAMGUID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E17", "SELECT COALESCE( T1.[GXC2], 0) AS GXC8 FROM (SELECT COUNT(*) AS GXC2 FROM ([UltimoDadoLido] T2 LEFT JOIN [Veiculo] T3 ON T3.[VeiculoPlaca] = T2.[UltimoDadoLidoPlaca]) WHERE (( T2.[UltimoDadoLidoVelocidade] > 0)) AND (COALESCE( T3.[VeiculoGAMGUID], '') = @AV30GAMGUID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E19", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM [Veiculo] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E21", "SELECT COALESCE( T1.[GXC2], 0) AS GXC2 FROM (SELECT COUNT(*) AS GXC2 FROM [UltimoDadoLido] WHERE [UltimoDadoLidoIgnicao] = 1 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E23", "SELECT COALESCE( T1.[GXC2], 0) AS GXC3 FROM (SELECT COUNT(*) AS GXC2 FROM [UltimoDadoLido] WHERE [UltimoDadoLidoIgnicao] = 2 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E25", "SELECT COALESCE( T1.[GXC2], 0) AS GXC4 FROM (SELECT COUNT(*) AS GXC2 FROM [UltimoDadoLido] WHERE ( [UltimoDadoLidoVelocidade] > 0) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E27", "SELECT COALESCE( T1.[GXC1], 0) AS GXC5 FROM (SELECT COUNT(*) AS GXC1 FROM [Veiculo] WHERE [VeiculoGAMGUID] = @AV30GAMGUID ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E29", "SELECT COALESCE( T1.[GXC2], 0) AS GXC6 FROM (SELECT COUNT(*) AS GXC2 FROM ([UltimoDadoLido] T2 LEFT JOIN [Veiculo] T3 ON T3.[VeiculoPlaca] = T2.[UltimoDadoLidoPlaca]) WHERE (T2.[UltimoDadoLidoIgnicao] = 1) AND (COALESCE( T3.[VeiculoGAMGUID], '') = @AV30GAMGUID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E31", "SELECT COALESCE( T1.[GXC2], 0) AS GXC7 FROM (SELECT COUNT(*) AS GXC2 FROM ([UltimoDadoLido] T2 LEFT JOIN [Veiculo] T3 ON T3.[VeiculoPlaca] = T2.[UltimoDadoLidoPlaca]) WHERE (T2.[UltimoDadoLidoIgnicao] = 2) AND (COALESCE( T3.[VeiculoGAMGUID], '') = @AV30GAMGUID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E33", "SELECT COALESCE( T1.[GXC2], 0) AS GXC8 FROM (SELECT COUNT(*) AS GXC2 FROM ([UltimoDadoLido] T2 LEFT JOIN [Veiculo] T3 ON T3.[VeiculoPlaca] = T2.[UltimoDadoLidoPlaca]) WHERE (( T2.[UltimoDadoLidoVelocidade] > 0)) AND (COALESCE( T3.[VeiculoGAMGUID], '') = @AV30GAMGUID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E34", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E35", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E35,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E36", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E36,1, GxCacheFrequency.OFF ,true,false )
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
             case 0 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 1 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 2 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 3 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 4 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 5 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 6 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 7 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 8 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 9 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 10 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 11 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 12 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 13 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 14 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 15 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.wasNull(1);
                return;
             case 16 :
                table[0][0] = rslt.getInt(1);
                return;
             case 17 :
                table[0][0] = rslt.getInt(1);
                return;
             case 18 :
                table[0][0] = rslt.getInt(1);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx;
       switch ( cursor )
       {
             case 4 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 5 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 12 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 13 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 14 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 15 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 16 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[1]);
                }
                return;
             case 17 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[1]);
                }
                return;
             case 18 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[1]);
                }
                return;
       }
    }

 }

}
