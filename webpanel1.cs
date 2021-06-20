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
   public class webpanel1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public webpanel1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public webpanel1( IGxContext context )
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
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "webpanel1_Execute" ;
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
         PA2Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2Y2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021419929428", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("webpanel1.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV7Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV7Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV8Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV8Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV9ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV9ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV10ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV10ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV11DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV11DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV13ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV13ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV14ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV14ItemCollapseData);
         }
         GxWebStd.gx_hidden_field( context, "UCPROGRESS1_Circlecaptiontype", StringUtil.RTrim( Ucprogress1_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS1_Caption", StringUtil.RTrim( Ucprogress1_Caption));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS1_Subtitle", StringUtil.RTrim( Ucprogress1_Subtitle));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS1_Cls", StringUtil.RTrim( Ucprogress1_Cls));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS1_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress1_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS1_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress1_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS2_Circlecaptiontype", StringUtil.RTrim( Ucprogress2_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS2_Caption", StringUtil.RTrim( Ucprogress2_Caption));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS2_Subtitle", StringUtil.RTrim( Ucprogress2_Subtitle));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS2_Cls", StringUtil.RTrim( Ucprogress2_Cls));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS2_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress2_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS2_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress2_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS3_Circlecaptiontype", StringUtil.RTrim( Ucprogress3_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS3_Caption", StringUtil.RTrim( Ucprogress3_Caption));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS3_Subtitle", StringUtil.RTrim( Ucprogress3_Subtitle));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS3_Cls", StringUtil.RTrim( Ucprogress3_Cls));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS3_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress3_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROGRESS3_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucprogress3_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Class", StringUtil.RTrim( Utchartcolumnline_Class));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Height", StringUtil.RTrim( Utchartcolumnline_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Type", StringUtil.RTrim( Utchartcolumnline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Charttype", StringUtil.RTrim( Utchartcolumnline_Charttype));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Plotseries", StringUtil.RTrim( Utchartcolumnline_Plotseries));
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
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Type", StringUtil.RTrim( Utchartsmootharea_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Charttype", StringUtil.RTrim( Utchartsmootharea_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Height", StringUtil.RTrim( Utchartsmoothline_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Type", StringUtil.RTrim( Utchartsmoothline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Charttype", StringUtil.RTrim( Utchartsmoothline_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Width", StringUtil.RTrim( Dvpanel_tablechart4_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart4_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Cls", StringUtil.RTrim( Dvpanel_tablechart4_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Title", StringUtil.RTrim( Dvpanel_tablechart4_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Iconposition", StringUtil.RTrim( Dvpanel_tablechart4_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoscroll));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE2Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2Y2( ) ;
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
         return formatLink("webpanel1.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WebPanel1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Web Panel1" ;
      }

      protected void WB2Y0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 HomeTopPanel", "left", "top", "", "", "div");
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
            ucUcprogress1.SetProperty("CircleCaptionType", Ucprogress1_Circlecaptiontype);
            ucUcprogress1.SetProperty("Caption", Ucprogress1_Caption);
            ucUcprogress1.SetProperty("Subtitle", Ucprogress1_Subtitle);
            ucUcprogress1.SetProperty("Cls", Ucprogress1_Cls);
            ucUcprogress1.SetProperty("Percentage", Ucprogress1_Percentage);
            ucUcprogress1.SetProperty("CircleWidth", Ucprogress1_Circlewidth);
            ucUcprogress1.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Ucprogress1_Internalname, "UCPROGRESS1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUcprogress2.SetProperty("CircleCaptionType", Ucprogress2_Circlecaptiontype);
            ucUcprogress2.SetProperty("Caption", Ucprogress2_Caption);
            ucUcprogress2.SetProperty("Subtitle", Ucprogress2_Subtitle);
            ucUcprogress2.SetProperty("Cls", Ucprogress2_Cls);
            ucUcprogress2.SetProperty("Percentage", Ucprogress2_Percentage);
            ucUcprogress2.SetProperty("CircleWidth", Ucprogress2_Circlewidth);
            ucUcprogress2.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Ucprogress2_Internalname, "UCPROGRESS2Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUcprogress3.SetProperty("CircleCaptionType", Ucprogress3_Circlecaptiontype);
            ucUcprogress3.SetProperty("Caption", Ucprogress3_Caption);
            ucUcprogress3.SetProperty("Subtitle", Ucprogress3_Subtitle);
            ucUcprogress3.SetProperty("Cls", Ucprogress3_Cls);
            ucUcprogress3.SetProperty("Percentage", Ucprogress3_Percentage);
            ucUcprogress3.SetProperty("CircleWidth", Ucprogress3_Circlewidth);
            ucUcprogress3.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Ucprogress3_Internalname, "UCPROGRESS3Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "hidden-xs CellChartNoLines", "left", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV7Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV8Parameters);
            ucUtchartcolumnline.SetProperty("Class", Utchartcolumnline_Class);
            ucUtchartcolumnline.SetProperty("Height", Utchartcolumnline_Height);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("ChartType", Utchartcolumnline_Charttype);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("PlotSeries", Utchartcolumnline_Plotseries);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV9ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV10ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV11DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV12FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucUtchartcolumnline.Render(context, "queryviewer", Utchartcolumnline_Internalname, "UTCHARTCOLUMNLINEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-7 col-lg-8 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmootharea.SetProperty("Elements", AV7Elements);
            ucUtchartsmootharea.SetProperty("Parameters", AV8Parameters);
            ucUtchartsmootharea.SetProperty("Type", Utchartsmootharea_Type);
            ucUtchartsmootharea.SetProperty("ChartType", Utchartsmootharea_Charttype);
            ucUtchartsmootharea.SetProperty("Title", Utchartsmootharea_Title);
            ucUtchartsmootharea.SetProperty("ItemClickData", AV9ItemClickData);
            ucUtchartsmootharea.SetProperty("ItemDoubleClickData", AV10ItemDoubleClickData);
            ucUtchartsmootharea.SetProperty("DragAndDropData", AV11DragAndDropData);
            ucUtchartsmootharea.SetProperty("FilterChangedData", AV12FilterChangedData);
            ucUtchartsmootharea.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucUtchartsmootharea.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucUtchartsmootharea.Render(context, "queryviewer", Utchartsmootharea_Internalname, "UTCHARTSMOOTHAREAContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 col-lg-8 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart4.SetProperty("Width", Dvpanel_tablechart4_Width);
            ucDvpanel_tablechart4.SetProperty("AutoWidth", Dvpanel_tablechart4_Autowidth);
            ucDvpanel_tablechart4.SetProperty("AutoHeight", Dvpanel_tablechart4_Autoheight);
            ucDvpanel_tablechart4.SetProperty("Cls", Dvpanel_tablechart4_Cls);
            ucDvpanel_tablechart4.SetProperty("Title", Dvpanel_tablechart4_Title);
            ucDvpanel_tablechart4.SetProperty("Collapsible", Dvpanel_tablechart4_Collapsible);
            ucDvpanel_tablechart4.SetProperty("Collapsed", Dvpanel_tablechart4_Collapsed);
            ucDvpanel_tablechart4.SetProperty("ShowCollapseIcon", Dvpanel_tablechart4_Showcollapseicon);
            ucDvpanel_tablechart4.SetProperty("IconPosition", Dvpanel_tablechart4_Iconposition);
            ucDvpanel_tablechart4.SetProperty("AutoScroll", Dvpanel_tablechart4_Autoscroll);
            ucDvpanel_tablechart4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart4_Internalname, "DVPANEL_TABLECHART4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART4Container"+"TableChart4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmoothline.SetProperty("Elements", AV7Elements);
            ucUtchartsmoothline.SetProperty("Parameters", AV8Parameters);
            ucUtchartsmoothline.SetProperty("Height", Utchartsmoothline_Height);
            ucUtchartsmoothline.SetProperty("Type", Utchartsmoothline_Type);
            ucUtchartsmoothline.SetProperty("ChartType", Utchartsmoothline_Charttype);
            ucUtchartsmoothline.SetProperty("Title", Utchartsmoothline_Title);
            ucUtchartsmoothline.SetProperty("ItemClickData", AV9ItemClickData);
            ucUtchartsmoothline.SetProperty("ItemDoubleClickData", AV10ItemDoubleClickData);
            ucUtchartsmoothline.SetProperty("DragAndDropData", AV11DragAndDropData);
            ucUtchartsmoothline.SetProperty("FilterChangedData", AV12FilterChangedData);
            ucUtchartsmoothline.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucUtchartsmoothline.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucUtchartsmoothline.Render(context, "queryviewer", Utchartsmoothline_Internalname, "UTCHARTSMOOTHLINEContainer");
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
         }
         wbLoad = true;
      }

      protected void START2Y2( )
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
            Form.Meta.addItem("description", "Web Panel1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2Y0( ) ;
      }

      protected void WS2Y2( )
      {
         START2Y2( ) ;
         EVT2Y2( ) ;
      }

      protected void EVT2Y2( )
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
                              E112Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E122Y2 ();
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

      protected void WE2Y2( )
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

      protected void PA2Y2( )
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
         RF2Y2( ) ;
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

      protected void RF2Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E122Y2 ();
            WB2Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2Y2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV7Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV8Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV9ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV10ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV11DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV12FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV13ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV14ItemCollapseData);
            /* Read saved values. */
            Ucprogress1_Circlecaptiontype = cgiGet( "UCPROGRESS1_Circlecaptiontype");
            Ucprogress1_Caption = cgiGet( "UCPROGRESS1_Caption");
            Ucprogress1_Subtitle = cgiGet( "UCPROGRESS1_Subtitle");
            Ucprogress1_Cls = cgiGet( "UCPROGRESS1_Cls");
            Ucprogress1_Percentage = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS1_Percentage"), ",", "."));
            Ucprogress1_Circlewidth = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS1_Circlewidth"), ",", "."));
            Ucprogress2_Circlecaptiontype = cgiGet( "UCPROGRESS2_Circlecaptiontype");
            Ucprogress2_Caption = cgiGet( "UCPROGRESS2_Caption");
            Ucprogress2_Subtitle = cgiGet( "UCPROGRESS2_Subtitle");
            Ucprogress2_Cls = cgiGet( "UCPROGRESS2_Cls");
            Ucprogress2_Percentage = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS2_Percentage"), ",", "."));
            Ucprogress2_Circlewidth = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS2_Circlewidth"), ",", "."));
            Ucprogress3_Circlecaptiontype = cgiGet( "UCPROGRESS3_Circlecaptiontype");
            Ucprogress3_Caption = cgiGet( "UCPROGRESS3_Caption");
            Ucprogress3_Subtitle = cgiGet( "UCPROGRESS3_Subtitle");
            Ucprogress3_Cls = cgiGet( "UCPROGRESS3_Cls");
            Ucprogress3_Percentage = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS3_Percentage"), ",", "."));
            Ucprogress3_Circlewidth = (int)(context.localUtil.CToN( cgiGet( "UCPROGRESS3_Circlewidth"), ",", "."));
            Utchartcolumnline_Class = cgiGet( "UTCHARTCOLUMNLINE_Class");
            Utchartcolumnline_Height = cgiGet( "UTCHARTCOLUMNLINE_Height");
            Utchartcolumnline_Type = cgiGet( "UTCHARTCOLUMNLINE_Type");
            Utchartcolumnline_Charttype = cgiGet( "UTCHARTCOLUMNLINE_Charttype");
            Utchartcolumnline_Plotseries = cgiGet( "UTCHARTCOLUMNLINE_Plotseries");
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
            Utchartsmootharea_Type = cgiGet( "UTCHARTSMOOTHAREA_Type");
            Utchartsmootharea_Charttype = cgiGet( "UTCHARTSMOOTHAREA_Charttype");
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Utchartsmoothline_Height = cgiGet( "UTCHARTSMOOTHLINE_Height");
            Utchartsmoothline_Type = cgiGet( "UTCHARTSMOOTHLINE_Type");
            Utchartsmoothline_Charttype = cgiGet( "UTCHARTSMOOTHLINE_Charttype");
            Dvpanel_tablechart4_Width = cgiGet( "DVPANEL_TABLECHART4_Width");
            Dvpanel_tablechart4_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autowidth"));
            Dvpanel_tablechart4_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoheight"));
            Dvpanel_tablechart4_Cls = cgiGet( "DVPANEL_TABLECHART4_Cls");
            Dvpanel_tablechart4_Title = cgiGet( "DVPANEL_TABLECHART4_Title");
            Dvpanel_tablechart4_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsible"));
            Dvpanel_tablechart4_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsed"));
            Dvpanel_tablechart4_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Showcollapseicon"));
            Dvpanel_tablechart4_Iconposition = cgiGet( "DVPANEL_TABLECHART4_Iconposition");
            Dvpanel_tablechart4_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoscroll"));
            /* Read variables values. */
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
         E112Y2 ();
         if (returnInSub) return;
      }

      protected void E112Y2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void nextLoad( )
      {
      }

      protected void E122Y2( )
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
         PA2Y2( ) ;
         WS2Y2( ) ;
         WE2Y2( ) ;
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
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214199294477", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("webpanel1.js", "?20214199294478", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Ucprogress1_Internalname = "UCPROGRESS1";
         Ucprogress2_Internalname = "UCPROGRESS2";
         Ucprogress3_Internalname = "UCPROGRESS3";
         divTableprogresscards_Internalname = "TABLEPROGRESSCARDS";
         Utchartcolumnline_Internalname = "UTCHARTCOLUMNLINE";
         divTablecards_Internalname = "TABLECARDS";
         Dvpanel_tablecards_Internalname = "DVPANEL_TABLECARDS";
         Utchartsmootharea_Internalname = "UTCHARTSMOOTHAREA";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         Utchartsmoothline_Internalname = "UTCHARTSMOOTHLINE";
         divTablechart4_Internalname = "TABLECHART4";
         Dvpanel_tablechart4_Internalname = "DVPANEL_TABLECHART4";
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
         Utchartsmoothline_Title = "";
         Utchartsmootharea_Title = "";
         Utchartcolumnline_Title = "";
         Dvpanel_tablechart4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Iconposition = "Right";
         Dvpanel_tablechart4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Title = "Task Board";
         Dvpanel_tablechart4_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablechart4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Width = "100%";
         Utchartsmoothline_Charttype = "SmoothLine";
         Utchartsmoothline_Type = "Chart";
         Utchartsmoothline_Height = "450px";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Title = "Sales Table";
         Dvpanel_tablechart1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Utchartsmootharea_Charttype = "StackedArea";
         Utchartsmootharea_Type = "Chart";
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
         Utchartcolumnline_Plotseries = "";
         Utchartcolumnline_Charttype = "ColumnLine";
         Utchartcolumnline_Type = "Chart";
         Utchartcolumnline_Height = "248px";
         Utchartcolumnline_Class = "QueryViewerBar";
         Ucprogress3_Circlewidth = 180;
         Ucprogress3_Percentage = 40;
         Ucprogress3_Cls = "ProgressBigCircleBaseColor";
         Ucprogress3_Subtitle = "Active Customers";
         Ucprogress3_Caption = "912";
         Ucprogress3_Circlecaptiontype = "CaptionAndSubtitle";
         Ucprogress2_Circlewidth = 180;
         Ucprogress2_Percentage = 60;
         Ucprogress2_Cls = "ProgressBigCircleBaseColor";
         Ucprogress2_Subtitle = "New Issues";
         Ucprogress2_Caption = "1,546";
         Ucprogress2_Circlecaptiontype = "CaptionAndSubtitle";
         Ucprogress1_Circlewidth = 180;
         Ucprogress1_Percentage = 20;
         Ucprogress1_Cls = "ProgressBigCircleBaseColor";
         Ucprogress1_Subtitle = "Applications";
         Ucprogress1_Caption = "3,154";
         Ucprogress1_Circlecaptiontype = "CaptionAndSubtitle";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Web Panel1";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
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
         AV7Elements = new GXBaseCollection<SdtQueryViewerElements_Element>( context, "Element", "RastreamentoTCC");
         AV8Parameters = new GXBaseCollection<SdtQueryViewerParameters_Parameter>( context, "Parameter", "RastreamentoTCC");
         AV9ItemClickData = new SdtQueryViewerItemClickData(context);
         AV10ItemDoubleClickData = new SdtQueryViewerItemDoubleClickData(context);
         AV11DragAndDropData = new SdtQueryViewerDragAndDropData(context);
         AV12FilterChangedData = new SdtQueryViewerFilterChangedData(context);
         AV13ItemExpandData = new SdtQueryViewerItemExpandData(context);
         AV14ItemCollapseData = new SdtQueryViewerItemCollapseData(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tablecards = new GXUserControl();
         ucUcprogress1 = new GXUserControl();
         ucUcprogress2 = new GXUserControl();
         ucUcprogress3 = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         ucDvpanel_tablechart1 = new GXUserControl();
         ucUtchartsmootharea = new GXUserControl();
         ucDvpanel_tablechart4 = new GXUserControl();
         ucUtchartsmoothline = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int Ucprogress1_Percentage ;
      private int Ucprogress1_Circlewidth ;
      private int Ucprogress2_Percentage ;
      private int Ucprogress2_Circlewidth ;
      private int Ucprogress3_Percentage ;
      private int Ucprogress3_Circlewidth ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ucprogress1_Circlecaptiontype ;
      private string Ucprogress1_Caption ;
      private string Ucprogress1_Subtitle ;
      private string Ucprogress1_Cls ;
      private string Ucprogress2_Circlecaptiontype ;
      private string Ucprogress2_Caption ;
      private string Ucprogress2_Subtitle ;
      private string Ucprogress2_Cls ;
      private string Ucprogress3_Circlecaptiontype ;
      private string Ucprogress3_Caption ;
      private string Ucprogress3_Subtitle ;
      private string Ucprogress3_Cls ;
      private string Utchartcolumnline_Class ;
      private string Utchartcolumnline_Height ;
      private string Utchartcolumnline_Type ;
      private string Utchartcolumnline_Charttype ;
      private string Utchartcolumnline_Plotseries ;
      private string Dvpanel_tablecards_Width ;
      private string Dvpanel_tablecards_Cls ;
      private string Dvpanel_tablecards_Title ;
      private string Dvpanel_tablecards_Iconposition ;
      private string Utchartsmootharea_Type ;
      private string Utchartsmootharea_Charttype ;
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Utchartsmoothline_Height ;
      private string Utchartsmoothline_Type ;
      private string Utchartsmoothline_Charttype ;
      private string Dvpanel_tablechart4_Width ;
      private string Dvpanel_tablechart4_Cls ;
      private string Dvpanel_tablechart4_Title ;
      private string Dvpanel_tablechart4_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecards_Internalname ;
      private string divTablecards_Internalname ;
      private string divTableprogresscards_Internalname ;
      private string Ucprogress1_Internalname ;
      private string Ucprogress2_Internalname ;
      private string Ucprogress3_Internalname ;
      private string Utchartcolumnline_Title ;
      private string Utchartcolumnline_Internalname ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string Utchartsmootharea_Title ;
      private string Utchartsmootharea_Internalname ;
      private string Dvpanel_tablechart4_Internalname ;
      private string divTablechart4_Internalname ;
      private string Utchartsmoothline_Title ;
      private string Utchartsmoothline_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablecards_Autowidth ;
      private bool Dvpanel_tablecards_Autoheight ;
      private bool Dvpanel_tablecards_Collapsible ;
      private bool Dvpanel_tablecards_Collapsed ;
      private bool Dvpanel_tablecards_Showcollapseicon ;
      private bool Dvpanel_tablecards_Autoscroll ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_tablechart4_Autowidth ;
      private bool Dvpanel_tablechart4_Autoheight ;
      private bool Dvpanel_tablechart4_Collapsible ;
      private bool Dvpanel_tablechart4_Collapsed ;
      private bool Dvpanel_tablechart4_Showcollapseicon ;
      private bool Dvpanel_tablechart4_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucDvpanel_tablecards ;
      private GXUserControl ucUcprogress1 ;
      private GXUserControl ucUcprogress2 ;
      private GXUserControl ucUcprogress3 ;
      private GXUserControl ucUtchartcolumnline ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucUtchartsmootharea ;
      private GXUserControl ucDvpanel_tablechart4 ;
      private GXUserControl ucUtchartsmoothline ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtQueryViewerElements_Element> AV7Elements ;
      private GXBaseCollection<SdtQueryViewerParameters_Parameter> AV8Parameters ;
      private GXWebForm Form ;
      private SdtQueryViewerItemClickData AV9ItemClickData ;
      private SdtQueryViewerItemDoubleClickData AV10ItemDoubleClickData ;
      private SdtQueryViewerDragAndDropData AV11DragAndDropData ;
      private SdtQueryViewerFilterChangedData AV12FilterChangedData ;
      private SdtQueryViewerItemExpandData AV13ItemExpandData ;
      private SdtQueryViewerItemCollapseData AV14ItemCollapseData ;
   }

}
