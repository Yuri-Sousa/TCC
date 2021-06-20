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
   public class relatorioutilizacao : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public relatorioutilizacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relatorioutilizacao( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdtrelatorioutilizacaos") == 0 )
            {
               nRC_GXsfl_76 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_76"), "."));
               nGXsfl_76_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_76_idx"), "."));
               sGXsfl_76_idx = GetPar( "sGXsfl_76_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridsdtrelatorioutilizacaos_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdtrelatorioutilizacaos") == 0 )
            {
               subGridsdtrelatorioutilizacaos_Rows = (int)(NumberUtil.Val( GetPar( "subGridsdtrelatorioutilizacaos_Rows"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridsdtrelatorioutilizacaos_refresh( subGridsdtrelatorioutilizacaos_Rows) ;
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
            return "relatorioutilizacao_Execute" ;
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
         PA2U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2U2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142918563916", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("4RLoader/4RLoaderRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("relatorioutilizacao.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtrelatorioutilizacao", AV7SDTRelatorioUtilizacao);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtrelatorioutilizacao", AV7SDTRelatorioUtilizacao);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_76), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVEICULOID_DATA", AV13VeiculoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVEICULOID_DATA", AV13VeiculoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOUTILIZACAOSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20GridSDTRelatorioUtilizacaosCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOUTILIZACAOSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21GridSDTRelatorioUtilizacaosPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOUTILIZACAOSAPPLIEDFILTERS", AV29GridSDTRelatorioUtilizacaosAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTRELATORIOUTILIZACAO", AV7SDTRelatorioUtilizacao);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTRELATORIOUTILIZACAO", AV7SDTRelatorioUtilizacao);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vEXISTEERRO", AV22ExisteErro);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV25NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV25NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Cls", StringUtil.RTrim( Combo_veiculoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Selectedvalue_set", StringUtil.RTrim( Combo_veiculoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Selectedtext_set", StringUtil.RTrim( Combo_veiculoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Gamoauthtoken", StringUtil.RTrim( Combo_veiculoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Datalistproc", StringUtil.RTrim( Combo_veiculoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_veiculoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Emptyitemtext", StringUtil.RTrim( Combo_veiculoid_Emptyitemtext));
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Width", StringUtil.RTrim( Dvpanel_tableexport_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Autowidth", StringUtil.BoolToStr( Dvpanel_tableexport_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Autoheight", StringUtil.BoolToStr( Dvpanel_tableexport_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Cls", StringUtil.RTrim( Dvpanel_tableexport_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Title", StringUtil.RTrim( Dvpanel_tableexport_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Collapsible", StringUtil.BoolToStr( Dvpanel_tableexport_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Collapsed", StringUtil.BoolToStr( Dvpanel_tableexport_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableexport_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Iconposition", StringUtil.RTrim( Dvpanel_tableexport_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableexport_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Class", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridsdtrelatorioutilizacaospaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridsdtrelatorioutilizacaospaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridsdtrelatorioutilizacaospaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridsdtrelatorioutilizacaospaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioutilizacaospaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Next", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "LOADERRELATORIOUTILIZACAO_Loader", StringUtil.RTrim( Loaderrelatorioutilizacao_Loader));
         GxWebStd.gx_hidden_field( context, "LOADERRELATORIOUTILIZACAO_Basecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(Loaderrelatorioutilizacao_Basecolor), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridsdtrelatorioutilizacaos_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Selectedvalue_get", StringUtil.RTrim( Combo_veiculoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_Message", AV25NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtrelatorioutilizacaospaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Selectedvalue_get", StringUtil.RTrim( Combo_veiculoid_Selectedvalue_get));
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
            WE2U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2U2( ) ;
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
         return formatLink("relatorioutilizacao.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "RelatorioUtilizacao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Relatório de Utilização" ;
      }

      protected void WB2U0( )
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
            GxWebStd.gx_div_start( context, divPanel1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbldados_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedveiculoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_veiculoid_Internalname, "Placa", "", "", lblTextblockcombo_veiculoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_RelatorioUtilizacao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_veiculoid.SetProperty("Caption", Combo_veiculoid_Caption);
            ucCombo_veiculoid.SetProperty("Cls", Combo_veiculoid_Cls);
            ucCombo_veiculoid.SetProperty("DataListProc", Combo_veiculoid_Datalistproc);
            ucCombo_veiculoid.SetProperty("DataListProcParametersPrefix", Combo_veiculoid_Datalistprocparametersprefix);
            ucCombo_veiculoid.SetProperty("EmptyItemText", Combo_veiculoid_Emptyitemtext);
            ucCombo_veiculoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
            ucCombo_veiculoid.SetProperty("DropDownOptionsData", AV13VeiculoId_Data);
            ucCombo_veiculoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_veiculoid_Internalname, "COMBO_VEICULOIDContainer");
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
            GxWebStd.gx_div_start( context, divTabledeate_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddatainicio_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdatainicio_Internalname, "Intervalo de consulta", "", "", lblTextblockdatainicio_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_RelatorioUtilizacao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_39_2U2( true) ;
         }
         else
         {
            wb_table1_39_2U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_39_2U2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavValorcombustivel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValorcombustivel_Internalname, "Valor do combustível (R$)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValorcombustivel_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9ValorCombustivel, 21, 2, ",", "")), ((edtavValorcombustivel_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( AV9ValorCombustivel, "ZZZZZZZZZZZZ9.99 R$/L")) : context.localUtil.Format( AV9ValorCombustivel, "ZZZZZZZZZZZZ9.99 R$/L")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValorcombustivel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValorcombustivel_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 1, -1, 0, true, "ValorCombustivel", "right", false, "", "HLP_RelatorioUtilizacao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavConsumopresumido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConsumopresumido_Internalname, "Consumo Médio (Km/L)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConsumopresumido_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ConsumoPresumido), 13, 0, ",", "")), ((edtavConsumopresumido_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10ConsumoPresumido), "ZZZZZZZ9 KM/L")) : context.localUtil.Format( (decimal)(AV10ConsumoPresumido), "ZZZZZZZ9 KM/L")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConsumopresumido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavConsumopresumido_Enabled, 0, "text", "", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "ConsumoPresumido", "right", false, "", "HLP_RelatorioUtilizacao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncalcular_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(76), 2, 0)+","+"null"+");", "Calcular", bttBtncalcular_Jsonclick, 5, "Calcular", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCALCULAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RelatorioUtilizacao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableexport.SetProperty("Width", Dvpanel_tableexport_Width);
            ucDvpanel_tableexport.SetProperty("AutoWidth", Dvpanel_tableexport_Autowidth);
            ucDvpanel_tableexport.SetProperty("AutoHeight", Dvpanel_tableexport_Autoheight);
            ucDvpanel_tableexport.SetProperty("Cls", Dvpanel_tableexport_Cls);
            ucDvpanel_tableexport.SetProperty("Title", Dvpanel_tableexport_Title);
            ucDvpanel_tableexport.SetProperty("Collapsible", Dvpanel_tableexport_Collapsible);
            ucDvpanel_tableexport.SetProperty("Collapsed", Dvpanel_tableexport_Collapsed);
            ucDvpanel_tableexport.SetProperty("ShowCollapseIcon", Dvpanel_tableexport_Showcollapseicon);
            ucDvpanel_tableexport.SetProperty("IconPosition", Dvpanel_tableexport_Iconposition);
            ucDvpanel_tableexport.SetProperty("AutoScroll", Dvpanel_tableexport_Autoscroll);
            ucDvpanel_tableexport.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableexport_Internalname, "DVPANEL_TABLEEXPORTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEEXPORTContainer"+"TableExport"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableexport_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportpdf_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(76), 2, 0)+","+"null"+");", "PDF", bttBtnexportpdf_Jsonclick, 5, "PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTPDF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RelatorioUtilizacao.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsdtrelatorioutilizacaostablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridsdtrelatorioutilizacaosContainer.SetWrapped(nGXWrapped);
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridsdtrelatorioutilizacaosContainer"+"DivS\" data-gxgridid=\"76\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridsdtrelatorioutilizacaos_Internalname, subGridsdtrelatorioutilizacaos_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridsdtrelatorioutilizacaos_Backcolorstyle == 0 )
               {
                  subGridsdtrelatorioutilizacaos_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridsdtrelatorioutilizacaos_Class) > 0 )
                  {
                     subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"Title";
                  }
               }
               else
               {
                  subGridsdtrelatorioutilizacaos_Titlebackstyle = 1;
                  if ( subGridsdtrelatorioutilizacaos_Backcolorstyle == 1 )
                  {
                     subGridsdtrelatorioutilizacaos_Titlebackcolor = subGridsdtrelatorioutilizacaos_Allbackcolor;
                     if ( StringUtil.Len( subGridsdtrelatorioutilizacaos_Class) > 0 )
                     {
                        subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridsdtrelatorioutilizacaos_Class) > 0 )
                     {
                        subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Placa") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Data/Hora Inicial") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Data/Hora Final") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Distância Total (Km)") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Consumo Total (L)") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Total Gasto (R$)") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("GridName", "Gridsdtrelatorioutilizacaos");
            }
            else
            {
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("GridName", "Gridsdtrelatorioutilizacaos");
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Header", subGridsdtrelatorioutilizacaos_Header);
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Backcolorstyle), 1, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("CmpContext", "");
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("InMasterPage", "false");
               GridsdtrelatorioutilizacaosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioutilizacaosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioutilizacao__placa_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddColumnProperties(GridsdtrelatorioutilizacaosColumn);
               GridsdtrelatorioutilizacaosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioutilizacaosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioutilizacao__datahorainicial_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddColumnProperties(GridsdtrelatorioutilizacaosColumn);
               GridsdtrelatorioutilizacaosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioutilizacaosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioutilizacao__datahorafinal_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddColumnProperties(GridsdtrelatorioutilizacaosColumn);
               GridsdtrelatorioutilizacaosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioutilizacaosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioutilizacao__distanciatotal_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddColumnProperties(GridsdtrelatorioutilizacaosColumn);
               GridsdtrelatorioutilizacaosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioutilizacaosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioutilizacao__consumototal_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddColumnProperties(GridsdtrelatorioutilizacaosColumn);
               GridsdtrelatorioutilizacaosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioutilizacaosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioutilizacao__valorcombustivel_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddColumnProperties(GridsdtrelatorioutilizacaosColumn);
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Selectedindex), 4, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Allowselection), 1, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Selectioncolor), 9, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Allowhovering), 1, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Hoveringcolor), 9, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Allowcollapsing), 1, 0, ".", "")));
               GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            nRC_GXsfl_76 = (int)(nGXsfl_76_idx-1);
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV32GXV1 = nGXsfl_76_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsdtrelatorioutilizacaosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdtrelatorioutilizacaos", GridsdtrelatorioutilizacaosContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsdtrelatorioutilizacaosContainerData", GridsdtrelatorioutilizacaosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsdtrelatorioutilizacaosContainerData"+"V", GridsdtrelatorioutilizacaosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtrelatorioutilizacaosContainerData"+"V"+"\" value='"+GridsdtrelatorioutilizacaosContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("Class", Gridsdtrelatorioutilizacaospaginationbar_Class);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("ShowFirst", Gridsdtrelatorioutilizacaospaginationbar_Showfirst);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("ShowPrevious", Gridsdtrelatorioutilizacaospaginationbar_Showprevious);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("ShowNext", Gridsdtrelatorioutilizacaospaginationbar_Shownext);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("ShowLast", Gridsdtrelatorioutilizacaospaginationbar_Showlast);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("PagesToShow", Gridsdtrelatorioutilizacaospaginationbar_Pagestoshow);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("PagingButtonsPosition", Gridsdtrelatorioutilizacaospaginationbar_Pagingbuttonsposition);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("PagingCaptionPosition", Gridsdtrelatorioutilizacaospaginationbar_Pagingcaptionposition);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("EmptyGridClass", Gridsdtrelatorioutilizacaospaginationbar_Emptygridclass);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("RowsPerPageSelector", Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselector);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("RowsPerPageOptions", Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageoptions);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("Previous", Gridsdtrelatorioutilizacaospaginationbar_Previous);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("Next", Gridsdtrelatorioutilizacaospaginationbar_Next);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("Caption", Gridsdtrelatorioutilizacaospaginationbar_Caption);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("EmptyGridCaption", Gridsdtrelatorioutilizacaospaginationbar_Emptygridcaption);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("RowsPerPageCaption", Gridsdtrelatorioutilizacaospaginationbar_Rowsperpagecaption);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("CurrentPage", AV20GridSDTRelatorioUtilizacaosCurrentPage);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("PageCount", AV21GridSDTRelatorioUtilizacaosPageCount);
            ucGridsdtrelatorioutilizacaospaginationbar.SetProperty("AppliedFilters", AV29GridSDTRelatorioUtilizacaosAppliedFilters);
            ucGridsdtrelatorioutilizacaospaginationbar.Render(context, "dvelop.dvpaginationbar", Gridsdtrelatorioutilizacaospaginationbar_Internalname, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, divUcloader_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucLoaderrelatorioutilizacao.SetProperty("Loader", Loaderrelatorioutilizacao_Loader);
            ucLoaderrelatorioutilizacao.SetProperty("BaseColor", Loaderrelatorioutilizacao_Basecolor);
            ucLoaderrelatorioutilizacao.Render(context, "4rloader", Loaderrelatorioutilizacao_Internalname, "LOADERRELATORIOUTILIZACAOContainer");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVeiculoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8VeiculoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8VeiculoId), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVeiculoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavVeiculoid_Visible, 1, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioUtilizacao.htm");
            /* User Defined Control */
            ucGridsdtrelatorioutilizacaos_empowerer.Render(context, "wwp.gridempowerer", Gridsdtrelatorioutilizacaos_empowerer_Internalname, "GRIDSDTRELATORIOUTILIZACAOS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV32GXV1 = nGXsfl_76_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsdtrelatorioutilizacaosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdtrelatorioutilizacaos", GridsdtrelatorioutilizacaosContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtrelatorioutilizacaosContainerData", GridsdtrelatorioutilizacaosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtrelatorioutilizacaosContainerData"+"V", GridsdtrelatorioutilizacaosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtrelatorioutilizacaosContainerData"+"V"+"\" value='"+GridsdtrelatorioutilizacaosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2U2( )
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
            Form.Meta.addItem("description", "Relatório de Utilização", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2U0( ) ;
      }

      protected void WS2U2( )
      {
         START2U2( ) ;
         EVT2U2( ) ;
      }

      protected void EVT2U2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_VEICULOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTPDF'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportPDF' */
                              E142U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCALCULAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCalcular' */
                              E152U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Onmessage_gx1 */
                              E162U2 ();
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "GRIDSDTRELATORIOUTILIZACAOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_76_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
                              SubsflControlProps_762( ) ;
                              AV32GXV1 = (int)(nGXsfl_76_idx+GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage);
                              if ( ( AV7SDTRelatorioUtilizacao.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
                              {
                                 AV7SDTRelatorioUtilizacao.CurrentItem = ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E172U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E182U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOUTILIZACAOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E162U2 ();
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
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E162U2 ();
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

      protected void WE2U2( )
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

      protected void PA2U2( )
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
               GX_FocusControl = edtavDatainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdtrelatorioutilizacaos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_762( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            sendrow_762( ) ;
            nGXsfl_76_idx = ((subGridsdtrelatorioutilizacaos_Islastpage==1)&&(nGXsfl_76_idx+1>subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsdtrelatorioutilizacaosContainer)) ;
         /* End function gxnrGridsdtrelatorioutilizacaos_newrow */
      }

      protected void gxgrGridsdtrelatorioutilizacaos_refresh( int subGridsdtrelatorioutilizacaos_Rows )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E182U2 ();
         GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord = 0;
         RF2U2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridsdtrelatorioutilizacaos_refresh */
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
         RF2U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtrelatorioutilizacao__placa_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__placa_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__datahorainicial_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__datahorainicial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__datahorainicial_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__datahorafinal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__datahorafinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__datahorafinal_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__distanciatotal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__distanciatotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__distanciatotal_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__consumototal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__consumototal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__consumototal_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__valorcombustivel_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__valorcombustivel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__valorcombustivel_Enabled), 5, 0), !bGXsfl_76_Refreshing);
      }

      protected void RF2U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsdtrelatorioutilizacaosContainer.ClearRows();
         }
         wbStart = 76;
         /* Execute user event: Refresh */
         E182U2 ();
         nGXsfl_76_idx = 1;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         bGXsfl_76_Refreshing = true;
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("GridName", "Gridsdtrelatorioutilizacaos");
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("CmpContext", "");
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("InMasterPage", "false");
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Backcolorstyle), 1, 0, ".", "")));
         GridsdtrelatorioutilizacaosContainer.PageSize = subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_762( ) ;
            E192U2 ();
            if ( ( GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord > 0 ) && ( GRIDSDTRELATORIOUTILIZACAOS_nGridOutOfScope == 0 ) && ( nGXsfl_76_idx == 1 ) )
            {
               GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord = 0;
               GRIDSDTRELATORIOUTILIZACAOS_nGridOutOfScope = 1;
               subgridsdtrelatorioutilizacaos_firstpage( ) ;
               E192U2 ();
            }
            wbEnd = 76;
            WB2U0( ) ;
         }
         bGXsfl_76_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2U2( )
      {
      }

      protected int subGridsdtrelatorioutilizacaos_fnc_Pagecount( )
      {
         GRIDSDTRELATORIOUTILIZACAOS_nRecordCount = subGridsdtrelatorioutilizacaos_fnc_Recordcount( );
         if ( ((int)((GRIDSDTRELATORIOUTILIZACAOS_nRecordCount) % (subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOUTILIZACAOS_nRecordCount/ (decimal)(subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOUTILIZACAOS_nRecordCount/ (decimal)(subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGridsdtrelatorioutilizacaos_fnc_Recordcount( )
      {
         return AV7SDTRelatorioUtilizacao.Count ;
      }

      protected int subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )
      {
         if ( subGridsdtrelatorioutilizacaos_Rows > 0 )
         {
            return subGridsdtrelatorioutilizacaos_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdtrelatorioutilizacaos_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage/ (decimal)(subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgridsdtrelatorioutilizacaos_firstpage( )
      {
         GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioutilizacaos_refresh( subGridsdtrelatorioutilizacaos_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtrelatorioutilizacaos_nextpage( )
      {
         GRIDSDTRELATORIOUTILIZACAOS_nRecordCount = subGridsdtrelatorioutilizacaos_fnc_Recordcount( );
         if ( ( GRIDSDTRELATORIOUTILIZACAOS_nRecordCount >= subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ) ) && ( GRIDSDTRELATORIOUTILIZACAOS_nEOF == 0 ) )
         {
            GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage+subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsdtrelatorioutilizacaosContainer.AddObjectProperty("GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage", GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioutilizacaos_refresh( subGridsdtrelatorioutilizacaos_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDTRELATORIOUTILIZACAOS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdtrelatorioutilizacaos_previouspage( )
      {
         if ( GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage >= subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ) )
         {
            GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage-subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioutilizacaos_refresh( subGridsdtrelatorioutilizacaos_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtrelatorioutilizacaos_lastpage( )
      {
         GRIDSDTRELATORIOUTILIZACAOS_nRecordCount = subGridsdtrelatorioutilizacaos_fnc_Recordcount( );
         if ( GRIDSDTRELATORIOUTILIZACAOS_nRecordCount > subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDTRELATORIOUTILIZACAOS_nRecordCount) % (subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOUTILIZACAOS_nRecordCount-subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOUTILIZACAOS_nRecordCount-((int)((GRIDSDTRELATORIOUTILIZACAOS_nRecordCount) % (subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioutilizacaos_refresh( subGridsdtrelatorioutilizacaos_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdtrelatorioutilizacaos_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = (long)(subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioutilizacaos_refresh( subGridsdtrelatorioutilizacaos_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSdtrelatorioutilizacao__placa_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__placa_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__datahorainicial_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__datahorainicial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__datahorainicial_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__datahorafinal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__datahorafinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__datahorafinal_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__distanciatotal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__distanciatotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__distanciatotal_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__consumototal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__consumototal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__consumototal_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavSdtrelatorioutilizacao__valorcombustivel_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioutilizacao__valorcombustivel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioutilizacao__valorcombustivel_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E172U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtrelatorioutilizacao"), AV7SDTRelatorioUtilizacao);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vVEICULOID_DATA"), AV13VeiculoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTRELATORIOUTILIZACAO"), AV7SDTRelatorioUtilizacao);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV25NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_76 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ",", "."));
            AV20GridSDTRelatorioUtilizacaosCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDSDTRELATORIOUTILIZACAOSCURRENTPAGE"), ",", "."));
            AV21GridSDTRelatorioUtilizacaosPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDSDTRELATORIOUTILIZACAOSPAGECOUNT"), ",", "."));
            AV29GridSDTRelatorioUtilizacaosAppliedFilters = cgiGet( "vGRIDSDTRELATORIOUTILIZACAOSAPPLIEDFILTERS");
            GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage"), ",", "."));
            GRIDSDTRELATORIOUTILIZACAOS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOUTILIZACAOS_nEOF"), ",", "."));
            subGridsdtrelatorioutilizacaos_Rows = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOUTILIZACAOS_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Rows), 6, 0, ".", "")));
            Combo_veiculoid_Cls = cgiGet( "COMBO_VEICULOID_Cls");
            Combo_veiculoid_Selectedvalue_set = cgiGet( "COMBO_VEICULOID_Selectedvalue_set");
            Combo_veiculoid_Selectedtext_set = cgiGet( "COMBO_VEICULOID_Selectedtext_set");
            Combo_veiculoid_Gamoauthtoken = cgiGet( "COMBO_VEICULOID_Gamoauthtoken");
            Combo_veiculoid_Datalistproc = cgiGet( "COMBO_VEICULOID_Datalistproc");
            Combo_veiculoid_Datalistprocparametersprefix = cgiGet( "COMBO_VEICULOID_Datalistprocparametersprefix");
            Combo_veiculoid_Emptyitemtext = cgiGet( "COMBO_VEICULOID_Emptyitemtext");
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
            Dvpanel_tableexport_Width = cgiGet( "DVPANEL_TABLEEXPORT_Width");
            Dvpanel_tableexport_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Autowidth"));
            Dvpanel_tableexport_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Autoheight"));
            Dvpanel_tableexport_Cls = cgiGet( "DVPANEL_TABLEEXPORT_Cls");
            Dvpanel_tableexport_Title = cgiGet( "DVPANEL_TABLEEXPORT_Title");
            Dvpanel_tableexport_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Collapsible"));
            Dvpanel_tableexport_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Collapsed"));
            Dvpanel_tableexport_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Showcollapseicon"));
            Dvpanel_tableexport_Iconposition = cgiGet( "DVPANEL_TABLEEXPORT_Iconposition");
            Dvpanel_tableexport_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Autoscroll"));
            Gridsdtrelatorioutilizacaospaginationbar_Class = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Class");
            Gridsdtrelatorioutilizacaospaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Showfirst"));
            Gridsdtrelatorioutilizacaospaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Showprevious"));
            Gridsdtrelatorioutilizacaospaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Shownext"));
            Gridsdtrelatorioutilizacaospaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Showlast"));
            Gridsdtrelatorioutilizacaospaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Pagestoshow"), ",", "."));
            Gridsdtrelatorioutilizacaospaginationbar_Pagingbuttonsposition = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Pagingbuttonsposition");
            Gridsdtrelatorioutilizacaospaginationbar_Pagingcaptionposition = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Pagingcaptionposition");
            Gridsdtrelatorioutilizacaospaginationbar_Emptygridclass = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Emptygridclass");
            Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageselector"));
            Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageoptions = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageoptions");
            Gridsdtrelatorioutilizacaospaginationbar_Previous = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Previous");
            Gridsdtrelatorioutilizacaospaginationbar_Next = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Next");
            Gridsdtrelatorioutilizacaospaginationbar_Caption = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Caption");
            Gridsdtrelatorioutilizacaospaginationbar_Emptygridcaption = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Emptygridcaption");
            Gridsdtrelatorioutilizacaospaginationbar_Rowsperpagecaption = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpagecaption");
            Loaderrelatorioutilizacao_Loader = cgiGet( "LOADERRELATORIOUTILIZACAO_Loader");
            Loaderrelatorioutilizacao_Basecolor = (int)(context.localUtil.CToN( cgiGet( "LOADERRELATORIOUTILIZACAO_Basecolor"), ",", "."));
            Gridsdtrelatorioutilizacaos_empowerer_Gridinternalname = cgiGet( "GRIDSDTRELATORIOUTILIZACAOS_EMPOWERER_Gridinternalname");
            Gridsdtrelatorioutilizacaospaginationbar_Selectedpage = cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Selectedpage");
            Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Combo_veiculoid_Selectedvalue_get = cgiGet( "COMBO_VEICULOID_Selectedvalue_get");
            nRC_GXsfl_76 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ",", "."));
            nGXsfl_76_fel_idx = 0;
            while ( nGXsfl_76_fel_idx < nRC_GXsfl_76 )
            {
               nGXsfl_76_fel_idx = ((subGridsdtrelatorioutilizacaos_Islastpage==1)&&(nGXsfl_76_fel_idx+1>subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_fel_idx+1);
               sGXsfl_76_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_762( ) ;
               AV32GXV1 = (int)(nGXsfl_76_fel_idx+GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage);
               if ( ( AV7SDTRelatorioUtilizacao.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
               {
                  AV7SDTRelatorioUtilizacao.CurrentItem = ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1));
               }
            }
            if ( nGXsfl_76_fel_idx == 0 )
            {
               nGXsfl_76_idx = 1;
               sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
               SubsflControlProps_762( ) ;
            }
            nGXsfl_76_fel_idx = 1;
            /* Read variables values. */
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatainicio_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Inicio"}), 1, "vDATAINICIO");
               GX_FocusControl = edtavDatainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11DataInicio = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV11DataInicio", context.localUtil.TToC( AV11DataInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV11DataInicio = context.localUtil.CToT( cgiGet( edtavDatainicio_Internalname));
               AssignAttri("", false, "AV11DataInicio", context.localUtil.TToC( AV11DataInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatafim_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Fim"}), 1, "vDATAFIM");
               GX_FocusControl = edtavDatafim_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12DataFim = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV12DataFim", context.localUtil.TToC( AV12DataFim, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV12DataFim = context.localUtil.CToT( cgiGet( edtavDatafim_Internalname));
               AssignAttri("", false, "AV12DataFim", context.localUtil.TToC( AV12DataFim, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValorcombustivel_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValorcombustivel_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALORCOMBUSTIVEL");
               GX_FocusControl = edtavValorcombustivel_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9ValorCombustivel = 0;
               AssignAttri("", false, "AV9ValorCombustivel", StringUtil.LTrimStr( AV9ValorCombustivel, 16, 2));
            }
            else
            {
               AV9ValorCombustivel = context.localUtil.CToN( cgiGet( edtavValorcombustivel_Internalname), ",", ".");
               AssignAttri("", false, "AV9ValorCombustivel", StringUtil.LTrimStr( AV9ValorCombustivel, 16, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConsumopresumido_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConsumopresumido_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONSUMOPRESUMIDO");
               GX_FocusControl = edtavConsumopresumido_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10ConsumoPresumido = 0;
               AssignAttri("", false, "AV10ConsumoPresumido", StringUtil.LTrimStr( (decimal)(AV10ConsumoPresumido), 8, 0));
            }
            else
            {
               AV10ConsumoPresumido = (int)(context.localUtil.CToN( cgiGet( edtavConsumopresumido_Internalname), ",", "."));
               AssignAttri("", false, "AV10ConsumoPresumido", StringUtil.LTrimStr( (decimal)(AV10ConsumoPresumido), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVeiculoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVeiculoid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVEICULOID");
               GX_FocusControl = edtavVeiculoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8VeiculoId = 0;
               AssignAttri("", false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 8, 0));
            }
            else
            {
               AV8VeiculoId = (int)(context.localUtil.CToN( cgiGet( edtavVeiculoid_Internalname), ",", "."));
               AssignAttri("", false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 8, 0));
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
         E172U2 ();
         if (returnInSub) return;
      }

      protected void E172U2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV16GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV17GAMErrors);
         Combo_veiculoid_Gamoauthtoken = AV16GAMSession.gxTpr_Token;
         ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "GAMOAuthToken", Combo_veiculoid_Gamoauthtoken);
         edtavVeiculoid_Visible = 0;
         AssignProp("", false, edtavVeiculoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVeiculoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOVEICULOID' */
         S112 ();
         if (returnInSub) return;
         Gridsdtrelatorioutilizacaos_empowerer_Gridinternalname = subGridsdtrelatorioutilizacaos_Internalname;
         ucGridsdtrelatorioutilizacaos_empowerer.SendProperty(context, "", false, Gridsdtrelatorioutilizacaos_empowerer_Internalname, "GridInternalName", Gridsdtrelatorioutilizacaos_empowerer_Gridinternalname);
         subGridsdtrelatorioutilizacaos_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Rows), 6, 0, ".", "")));
         Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue = subGridsdtrelatorioutilizacaos_Rows;
         ucGridsdtrelatorioutilizacaospaginationbar.SendProperty(context, "", false, Gridsdtrelatorioutilizacaospaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue), 9, 0));
         GX_FocusControl = bttBtncalcular_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E182U2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV20GridSDTRelatorioUtilizacaosCurrentPage = subGridsdtrelatorioutilizacaos_fnc_Currentpage( );
         AssignAttri("", false, "AV20GridSDTRelatorioUtilizacaosCurrentPage", StringUtil.LTrimStr( (decimal)(AV20GridSDTRelatorioUtilizacaosCurrentPage), 10, 0));
         AV21GridSDTRelatorioUtilizacaosPageCount = subGridsdtrelatorioutilizacaos_fnc_Pagecount( );
         AssignAttri("", false, "AV21GridSDTRelatorioUtilizacaosPageCount", StringUtil.LTrimStr( (decimal)(AV21GridSDTRelatorioUtilizacaosPageCount), 10, 0));
         GX_FocusControl = bttBtncalcular_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
         /*  Sending Event outputs  */
      }

      private void E192U2( )
      {
         /* Gridsdtrelatorioutilizacaos_Load Routine */
         returnInSub = false;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV7SDTRelatorioUtilizacao.Count )
         {
            AV7SDTRelatorioUtilizacao.CurrentItem = ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 76;
            }
            if ( ( subGridsdtrelatorioutilizacaos_Islastpage == 1 ) || ( subGridsdtrelatorioutilizacaos_Rows == 0 ) || ( ( GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord >= GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage ) && ( GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord < GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage + subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_762( ) ;
               GRIDSDTRELATORIOUTILIZACAOS_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nEOF), 1, 0, ".", "")));
               if ( GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord + 1 >= subGridsdtrelatorioutilizacaos_fnc_Recordcount( ) )
               {
                  GRIDSDTRELATORIOUTILIZACAOS_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOUTILIZACAOS_nEOF), 1, 0, ".", "")));
               }
            }
            GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord = (long)(GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_76_Refreshing )
            {
               context.DoAjaxLoad(76, GridsdtrelatorioutilizacaosRow);
            }
            AV32GXV1 = (int)(AV32GXV1+1);
         }
      }

      protected void E122U2( )
      {
         /* Gridsdtrelatorioutilizacaospaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridsdtrelatorioutilizacaospaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgridsdtrelatorioutilizacaos_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridsdtrelatorioutilizacaospaginationbar_Selectedpage, "Next") == 0 )
         {
            AV19PageToGo = subGridsdtrelatorioutilizacaos_fnc_Currentpage( );
            AV19PageToGo = (int)(AV19PageToGo+1);
            subgridsdtrelatorioutilizacaos_gotopage( AV19PageToGo) ;
         }
         else
         {
            AV19PageToGo = (int)(NumberUtil.Val( Gridsdtrelatorioutilizacaospaginationbar_Selectedpage, "."));
            subgridsdtrelatorioutilizacaos_gotopage( AV19PageToGo) ;
         }
      }

      protected void E132U2( )
      {
         /* Gridsdtrelatorioutilizacaospaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridsdtrelatorioutilizacaos_Rows = Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOUTILIZACAOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioutilizacaos_Rows), 6, 0, ".", "")));
         subgridsdtrelatorioutilizacaos_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142U2( )
      {
         AV32GXV1 = (int)(nGXsfl_76_idx+GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage);
         if ( AV7SDTRelatorioUtilizacao.Count >= AV32GXV1 )
         {
            AV7SDTRelatorioUtilizacao.CurrentItem = ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1));
         }
         /* 'DoExportPDF' Routine */
         returnInSub = false;
         AV24ClientId = AV23Socket.gxTpr_Clientid;
         AV27CacheName = "RelatorioUtilizacao_" + StringUtil.Trim( AV24ClientId);
         CacheAPI.Database.Set(AV27CacheName, AV7SDTRelatorioUtilizacao.ToJSonString(false), 3);
         /* Window Datatype Object Property */
         AV28window.Url = formatLink("aexportrelatoriodeutilizacaopdf.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV24ClientId))}, new string[] {"ClientId"}) ;
         AV28window.SetReturnParms(new Object[] {});
         AV28window.Height = 800;
         AV28window.Width = 1200;
         context.NewWindow(AV28window);
         /*  Sending Event outputs  */
      }

      protected void E152U2( )
      {
         /* 'DoCalcular' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VERIFICARERROS' */
         S122 ();
         if (returnInSub) return;
         if ( ! AV22ExisteErro )
         {
            this.executeUsercontrolMethod("", false, "LOADERRELATORIOUTILIZACAOContainer", "Insert", "", new Object[] {});
            AV24ClientId = AV23Socket.gxTpr_Clientid;
            new gerarelatorioutilizacao(context).executeSubmit(  AV24ClientId,  AV11DataInicio,  AV12DataFim,  AV8VeiculoId,  AV9ValorCombustivel,  AV10ConsumoPresumido) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E112U2( )
      {
         /* Combo_veiculoid_Onoptionclicked Routine */
         returnInSub = false;
         AV8VeiculoId = (int)(NumberUtil.Val( Combo_veiculoid_Selectedvalue_get, "."));
         AssignAttri("", false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 8, 0));
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOVEICULOID' Routine */
         returnInSub = false;
         AV39GXLvl129 = 0;
         AV40Udparg1 = new buscargamguidusuariologado(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A105VeiculoGAMGUID ,
                                              AV40Udparg1 ,
                                              AV8VeiculoId ,
                                              A98VeiculoId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H002U2 */
         pr_default.execute(0, new Object[] {AV8VeiculoId, AV40Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A105VeiculoGAMGUID = H002U2_A105VeiculoGAMGUID[0];
            A98VeiculoId = H002U2_A98VeiculoId[0];
            A100VeiculoPlaca = H002U2_A100VeiculoPlaca[0];
            AV39GXLvl129 = 1;
            Combo_veiculoid_Selectedtext_set = A100VeiculoPlaca;
            ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedText_set", Combo_veiculoid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV39GXLvl129 == 0 )
         {
            Combo_veiculoid_Selectedtext_set = "";
            ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedText_set", Combo_veiculoid_Selectedtext_set);
         }
         Combo_veiculoid_Selectedvalue_set = ((0==AV8VeiculoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV8VeiculoId), 8, 0)));
         ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedValue_set", Combo_veiculoid_Selectedvalue_set);
      }

      protected void E162U2( )
      {
         AV32GXV1 = (int)(nGXsfl_76_idx+GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage);
         if ( AV7SDTRelatorioUtilizacao.Count >= AV32GXV1 )
         {
            AV7SDTRelatorioUtilizacao.CurrentItem = ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1));
         }
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         new fixonmessage(context ).execute( ) ;
         if ( StringUtil.StrCmp(AV25NotificationInfo.gxTpr_Id, "RelatorioUtilizacao_Erro") == 0 )
         {
            GX_msglist.addItem("Não foi encontrado resultado para os parâmetros inseridos.");
            this.executeUsercontrolMethod("", false, "LOADERRELATORIOUTILIZACAOContainer", "Remove", "", new Object[] {});
         }
         else if ( StringUtil.StrCmp(AV25NotificationInfo.gxTpr_Id, "RelatorioUtilizacao_Sucesso") == 0 )
         {
            AV26SDTRelatorioUtilizacaoItem = new SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem(context);
            AV26SDTRelatorioUtilizacaoItem.FromJSonString(AV25NotificationInfo.gxTpr_Message, null);
            AV7SDTRelatorioUtilizacao.Add(AV26SDTRelatorioUtilizacaoItem, 0);
            gx_BV76 = true;
            this.executeUsercontrolMethod("", false, "LOADERRELATORIOUTILIZACAOContainer", "Remove", "", new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTRelatorioUtilizacao", AV7SDTRelatorioUtilizacao);
         nGXsfl_76_bak_idx = nGXsfl_76_idx;
         gxgrGridsdtrelatorioutilizacaos_refresh( subGridsdtrelatorioutilizacaos_Rows) ;
         nGXsfl_76_idx = nGXsfl_76_bak_idx;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
      }

      protected void S122( )
      {
         /* 'VERIFICARERROS' Routine */
         returnInSub = false;
         AV22ExisteErro = false;
         AssignAttri("", false, "AV22ExisteErro", AV22ExisteErro);
         if ( (DateTime.MinValue==AV11DataInicio) || (DateTime.MinValue==AV12DataFim) )
         {
            AV22ExisteErro = true;
            AssignAttri("", false, "AV22ExisteErro", AV22ExisteErro);
            GX_msglist.addItem("Intervalo de consulta inválido.");
         }
         else if ( AV11DataInicio > AV12DataFim )
         {
            AV22ExisteErro = true;
            AssignAttri("", false, "AV22ExisteErro", AV22ExisteErro);
            GX_msglist.addItem("Intervalo de consulta inválido.");
         }
         else if ( ( DateTimeUtil.TDiff( AV12DataFim, AV11DataInicio) / ( double )( 3600 ) / ( double )( 24 ) ) > 90 )
         {
            AV22ExisteErro = true;
            AssignAttri("", false, "AV22ExisteErro", AV22ExisteErro);
            GX_msglist.addItem("Intervalo de consulta máximo é de 90 dias.");
         }
         else if ( (Convert.ToDecimal(0)==AV9ValorCombustivel) )
         {
            AV22ExisteErro = true;
            AssignAttri("", false, "AV22ExisteErro", AV22ExisteErro);
            GX_msglist.addItem("Informe o Valor do combustível.");
         }
         else if ( (0==AV10ConsumoPresumido) )
         {
            AV22ExisteErro = true;
            AssignAttri("", false, "AV22ExisteErro", AV22ExisteErro);
            GX_msglist.addItem("Informe o Consumo Médio.");
         }
      }

      protected void wb_table1_39_2U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddatainicio_Internalname, tblTablemergeddatainicio_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatainicio_Internalname, "Data Inicio", "gx-form-item AttributeDateTimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_76_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatainicio_Internalname, context.localUtil.TToC( AV11DataInicio, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV11DataInicio, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatainicio_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatainicio_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioUtilizacao.htm");
            GxWebStd.gx_bitmap( context, edtavDatainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RelatorioUtilizacao.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtdata_Internalname, "<p style='padding-top:8px;padding-left:4px'>até</p>", "", "", lblTxtdata_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 1, "HLP_RelatorioUtilizacao.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatafim_Internalname, "Data Fim", "gx-form-item AttributeDateTimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_76_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatafim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatafim_Internalname, context.localUtil.TToC( AV12DataFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV12DataFim, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatafim_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatafim_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioUtilizacao.htm");
            GxWebStd.gx_bitmap( context, edtavDatafim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatafim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RelatorioUtilizacao.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_39_2U2e( true) ;
         }
         else
         {
            wb_table1_39_2U2e( false) ;
         }
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
         PA2U2( ) ;
         WS2U2( ) ;
         WE2U2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("4RLoader/spinner.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918564474", true, true);
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
         context.AddJavascriptSource("relatorioutilizacao.js", "?202142918564476", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("4RLoader/4RLoaderRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_762( )
      {
         edtavSdtrelatorioutilizacao__placa_Internalname = "SDTRELATORIOUTILIZACAO__PLACA_"+sGXsfl_76_idx;
         edtavSdtrelatorioutilizacao__datahorainicial_Internalname = "SDTRELATORIOUTILIZACAO__DATAHORAINICIAL_"+sGXsfl_76_idx;
         edtavSdtrelatorioutilizacao__datahorafinal_Internalname = "SDTRELATORIOUTILIZACAO__DATAHORAFINAL_"+sGXsfl_76_idx;
         edtavSdtrelatorioutilizacao__distanciatotal_Internalname = "SDTRELATORIOUTILIZACAO__DISTANCIATOTAL_"+sGXsfl_76_idx;
         edtavSdtrelatorioutilizacao__consumototal_Internalname = "SDTRELATORIOUTILIZACAO__CONSUMOTOTAL_"+sGXsfl_76_idx;
         edtavSdtrelatorioutilizacao__valorcombustivel_Internalname = "SDTRELATORIOUTILIZACAO__VALORCOMBUSTIVEL_"+sGXsfl_76_idx;
      }

      protected void SubsflControlProps_fel_762( )
      {
         edtavSdtrelatorioutilizacao__placa_Internalname = "SDTRELATORIOUTILIZACAO__PLACA_"+sGXsfl_76_fel_idx;
         edtavSdtrelatorioutilizacao__datahorainicial_Internalname = "SDTRELATORIOUTILIZACAO__DATAHORAINICIAL_"+sGXsfl_76_fel_idx;
         edtavSdtrelatorioutilizacao__datahorafinal_Internalname = "SDTRELATORIOUTILIZACAO__DATAHORAFINAL_"+sGXsfl_76_fel_idx;
         edtavSdtrelatorioutilizacao__distanciatotal_Internalname = "SDTRELATORIOUTILIZACAO__DISTANCIATOTAL_"+sGXsfl_76_fel_idx;
         edtavSdtrelatorioutilizacao__consumototal_Internalname = "SDTRELATORIOUTILIZACAO__CONSUMOTOTAL_"+sGXsfl_76_fel_idx;
         edtavSdtrelatorioutilizacao__valorcombustivel_Internalname = "SDTRELATORIOUTILIZACAO__VALORCOMBUSTIVEL_"+sGXsfl_76_fel_idx;
      }

      protected void sendrow_762( )
      {
         SubsflControlProps_762( ) ;
         WB2U0( ) ;
         if ( ( subGridsdtrelatorioutilizacaos_Rows * 1 == 0 ) || ( nGXsfl_76_idx <= subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsdtrelatorioutilizacaosRow = GXWebRow.GetNew(context,GridsdtrelatorioutilizacaosContainer);
            if ( subGridsdtrelatorioutilizacaos_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdtrelatorioutilizacaos_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdtrelatorioutilizacaos_Class, "") != 0 )
               {
                  subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"Odd";
               }
            }
            else if ( subGridsdtrelatorioutilizacaos_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdtrelatorioutilizacaos_Backstyle = 0;
               subGridsdtrelatorioutilizacaos_Backcolor = subGridsdtrelatorioutilizacaos_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdtrelatorioutilizacaos_Class, "") != 0 )
               {
                  subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"Uniform";
               }
            }
            else if ( subGridsdtrelatorioutilizacaos_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdtrelatorioutilizacaos_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdtrelatorioutilizacaos_Class, "") != 0 )
               {
                  subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"Odd";
               }
               subGridsdtrelatorioutilizacaos_Backcolor = (int)(0x0);
            }
            else if ( subGridsdtrelatorioutilizacaos_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdtrelatorioutilizacaos_Backstyle = 1;
               if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
               {
                  subGridsdtrelatorioutilizacaos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtrelatorioutilizacaos_Class, "") != 0 )
                  {
                     subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"Even";
                  }
               }
               else
               {
                  subGridsdtrelatorioutilizacaos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtrelatorioutilizacaos_Class, "") != 0 )
                  {
                     subGridsdtrelatorioutilizacaos_Linesclass = subGridsdtrelatorioutilizacaos_Class+"Odd";
                  }
               }
            }
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_76_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioutilizacaosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioutilizacao__placa_Internalname,((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Placa,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioutilizacao__placa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioutilizacao__placa_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)7,(short)0,(short)0,(short)76,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioutilizacaosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioutilizacao__datahorainicial_Internalname,context.localUtil.TToC( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Datahorainicial, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Datahorainicial, "99/99/9999 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioutilizacao__datahorainicial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioutilizacao__datahorainicial_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)76,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioutilizacaosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioutilizacao__datahorafinal_Internalname,context.localUtil.TToC( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Datahorafinal, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Datahorafinal, "99/99/9999 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioutilizacao__datahorafinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioutilizacao__datahorafinal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)76,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioutilizacaosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioutilizacao__distanciatotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Distanciatotal, 10, 2, ",", "")),((edtavSdtrelatorioutilizacao__distanciatotal_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Distanciatotal, "ZZZZZZ9.99")) : context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Distanciatotal, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioutilizacao__distanciatotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioutilizacao__distanciatotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)76,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioutilizacaosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioutilizacao__consumototal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Consumototal, 10, 2, ",", "")),((edtavSdtrelatorioutilizacao__consumototal_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Consumototal, "ZZZZZZ9.99")) : context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Consumototal, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioutilizacao__consumototal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioutilizacao__consumototal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)76,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioutilizacaosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioutilizacaosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioutilizacao__valorcombustivel_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Valorcombustivel, 16, 2, ",", "")),((edtavSdtrelatorioutilizacao__valorcombustivel_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Valorcombustivel, "ZZZZZZZZZZZZ9.99")) : context.localUtil.Format( ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV7SDTRelatorioUtilizacao.Item(AV32GXV1)).gxTpr_Valorcombustivel, "ZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioutilizacao__valorcombustivel_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioutilizacao__valorcombustivel_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)76,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2U2( ) ;
            GridsdtrelatorioutilizacaosContainer.AddRow(GridsdtrelatorioutilizacaosRow);
            nGXsfl_76_idx = ((subGridsdtrelatorioutilizacaos_Islastpage==1)&&(nGXsfl_76_idx+1>subGridsdtrelatorioutilizacaos_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         /* End function sendrow_762 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_veiculoid_Internalname = "TEXTBLOCKCOMBO_VEICULOID";
         Combo_veiculoid_Internalname = "COMBO_VEICULOID";
         divTablesplittedveiculoid_Internalname = "TABLESPLITTEDVEICULOID";
         lblTextblockdatainicio_Internalname = "TEXTBLOCKDATAINICIO";
         edtavDatainicio_Internalname = "vDATAINICIO";
         lblTxtdata_Internalname = "TXTDATA";
         edtavDatafim_Internalname = "vDATAFIM";
         tblTablemergeddatainicio_Internalname = "TABLEMERGEDDATAINICIO";
         divTablesplitteddatainicio_Internalname = "TABLESPLITTEDDATAINICIO";
         divTabledeate_Internalname = "TABLEDEATE";
         edtavValorcombustivel_Internalname = "vVALORCOMBUSTIVEL";
         edtavConsumopresumido_Internalname = "vCONSUMOPRESUMIDO";
         bttBtncalcular_Internalname = "BTNCALCULAR";
         divTbldados_Internalname = "TBLDADOS";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnexportpdf_Internalname = "BTNEXPORTPDF";
         divTableexport_Internalname = "TABLEEXPORT";
         Dvpanel_tableexport_Internalname = "DVPANEL_TABLEEXPORT";
         divTablecontent_Internalname = "TABLECONTENT";
         edtavSdtrelatorioutilizacao__placa_Internalname = "SDTRELATORIOUTILIZACAO__PLACA";
         edtavSdtrelatorioutilizacao__datahorainicial_Internalname = "SDTRELATORIOUTILIZACAO__DATAHORAINICIAL";
         edtavSdtrelatorioutilizacao__datahorafinal_Internalname = "SDTRELATORIOUTILIZACAO__DATAHORAFINAL";
         edtavSdtrelatorioutilizacao__distanciatotal_Internalname = "SDTRELATORIOUTILIZACAO__DISTANCIATOTAL";
         edtavSdtrelatorioutilizacao__consumototal_Internalname = "SDTRELATORIOUTILIZACAO__CONSUMOTOTAL";
         edtavSdtrelatorioutilizacao__valorcombustivel_Internalname = "SDTRELATORIOUTILIZACAO__VALORCOMBUSTIVEL";
         Gridsdtrelatorioutilizacaospaginationbar_Internalname = "GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR";
         divGridsdtrelatorioutilizacaostablewithpaginationbar_Internalname = "GRIDSDTRELATORIOUTILIZACAOSTABLEWITHPAGINATIONBAR";
         Loaderrelatorioutilizacao_Internalname = "LOADERRELATORIOUTILIZACAO";
         divUcloader_Internalname = "UCLOADER";
         divTablemain_Internalname = "TABLEMAIN";
         edtavVeiculoid_Internalname = "vVEICULOID";
         Gridsdtrelatorioutilizacaos_empowerer_Internalname = "GRIDSDTRELATORIOUTILIZACAOS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridsdtrelatorioutilizacaos_Internalname = "GRIDSDTRELATORIOUTILIZACAOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavSdtrelatorioutilizacao__valorcombustivel_Jsonclick = "";
         edtavSdtrelatorioutilizacao__consumototal_Jsonclick = "";
         edtavSdtrelatorioutilizacao__distanciatotal_Jsonclick = "";
         edtavSdtrelatorioutilizacao__datahorafinal_Jsonclick = "";
         edtavSdtrelatorioutilizacao__datahorainicial_Jsonclick = "";
         edtavSdtrelatorioutilizacao__placa_Jsonclick = "";
         edtavDatafim_Jsonclick = "";
         edtavDatafim_Enabled = 1;
         edtavDatainicio_Jsonclick = "";
         edtavDatainicio_Enabled = 1;
         edtavSdtrelatorioutilizacao__valorcombustivel_Enabled = -1;
         edtavSdtrelatorioutilizacao__consumototal_Enabled = -1;
         edtavSdtrelatorioutilizacao__distanciatotal_Enabled = -1;
         edtavSdtrelatorioutilizacao__datahorafinal_Enabled = -1;
         edtavSdtrelatorioutilizacao__datahorainicial_Enabled = -1;
         edtavSdtrelatorioutilizacao__placa_Enabled = -1;
         edtavVeiculoid_Jsonclick = "";
         edtavVeiculoid_Visible = 1;
         subGridsdtrelatorioutilizacaos_Allowcollapsing = 0;
         subGridsdtrelatorioutilizacaos_Allowselection = 0;
         subGridsdtrelatorioutilizacaos_Header = "";
         edtavSdtrelatorioutilizacao__valorcombustivel_Enabled = 0;
         edtavSdtrelatorioutilizacao__consumototal_Enabled = 0;
         edtavSdtrelatorioutilizacao__distanciatotal_Enabled = 0;
         edtavSdtrelatorioutilizacao__datahorafinal_Enabled = 0;
         edtavSdtrelatorioutilizacao__datahorainicial_Enabled = 0;
         edtavSdtrelatorioutilizacao__placa_Enabled = 0;
         subGridsdtrelatorioutilizacaos_Class = "GridWithPaginationBar WorkWith";
         subGridsdtrelatorioutilizacaos_Backcolorstyle = 0;
         edtavConsumopresumido_Jsonclick = "";
         edtavConsumopresumido_Enabled = 1;
         edtavValorcombustivel_Jsonclick = "";
         edtavValorcombustivel_Enabled = 1;
         Combo_veiculoid_Caption = "";
         Loaderrelatorioutilizacao_Basecolor = (int)(0x08A086);
         Loaderrelatorioutilizacao_Loader = "2";
         Gridsdtrelatorioutilizacaospaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridsdtrelatorioutilizacaospaginationbar_Emptygridcaption = "Nenhum resultado foi encontrado.";
         Gridsdtrelatorioutilizacaospaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridsdtrelatorioutilizacaospaginationbar_Next = "WWP_PagingNextCaption";
         Gridsdtrelatorioutilizacaospaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue = 10;
         Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridsdtrelatorioutilizacaospaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridsdtrelatorioutilizacaospaginationbar_Pagingcaptionposition = "Left";
         Gridsdtrelatorioutilizacaospaginationbar_Pagingbuttonsposition = "Right";
         Gridsdtrelatorioutilizacaospaginationbar_Pagestoshow = 5;
         Gridsdtrelatorioutilizacaospaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridsdtrelatorioutilizacaospaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridsdtrelatorioutilizacaospaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridsdtrelatorioutilizacaospaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridsdtrelatorioutilizacaospaginationbar_Class = "PaginationBar";
         Dvpanel_tableexport_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Iconposition = "Right";
         Dvpanel_tableexport_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableexport_Title = "Opções";
         Dvpanel_tableexport_Cls = "PanelNoHeader";
         Dvpanel_tableexport_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableexport_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Width = "100%";
         Dvpanel_panel1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panel1_Iconposition = "Right";
         Dvpanel_panel1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panel1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panel1_Title = "Dados";
         Dvpanel_panel1_Cls = "PanelNoHeader";
         Dvpanel_panel1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panel1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panel1_Width = "100%";
         Combo_veiculoid_Emptyitemtext = "Selecione";
         Combo_veiculoid_Datalistprocparametersprefix = " \"ComboName\": \"VeiculoId\"";
         Combo_veiculoid_Datalistproc = "RelatorioUtilizacaoLoadDVCombo";
         Combo_veiculoid_Cls = "ExtendedCombo Attribute";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Relatório de Utilização";
         subGridsdtrelatorioutilizacaos_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOUTILIZACAOS_nEOF'},{av:'AV7SDTRelatorioUtilizacao',fld:'vSDTRELATORIOUTILIZACAO',grid:76,pic:''},{av:'nRC_GXsfl_76',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'GridRC'},{av:'subGridsdtrelatorioutilizacaos_Rows',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'Rows'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20GridSDTRelatorioUtilizacaosCurrentPage',fld:'vGRIDSDTRELATORIOUTILIZACAOSCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV21GridSDTRelatorioUtilizacaosPageCount',fld:'vGRIDSDTRELATORIOUTILIZACAOSPAGECOUNT',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRIDSDTRELATORIOUTILIZACAOS.LOAD","{handler:'E192U2',iparms:[]");
         setEventMetadata("GRIDSDTRELATORIOUTILIZACAOS.LOAD",",oparms:[]}");
         setEventMetadata("GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR.CHANGEPAGE","{handler:'E122U2',iparms:[{av:'GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOUTILIZACAOS_nEOF'},{av:'AV7SDTRelatorioUtilizacao',fld:'vSDTRELATORIOUTILIZACAO',grid:76,pic:''},{av:'nRC_GXsfl_76',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'GridRC'},{av:'subGridsdtrelatorioutilizacaos_Rows',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'Rows'},{av:'Gridsdtrelatorioutilizacaospaginationbar_Selectedpage',ctrl:'GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132U2',iparms:[{av:'GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOUTILIZACAOS_nEOF'},{av:'AV7SDTRelatorioUtilizacao',fld:'vSDTRELATORIOUTILIZACAO',grid:76,pic:''},{av:'nRC_GXsfl_76',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'GridRC'},{av:'subGridsdtrelatorioutilizacaos_Rows',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'Rows'},{av:'Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDSDTRELATORIOUTILIZACAOSPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridsdtrelatorioutilizacaos_Rows',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'Rows'}]}");
         setEventMetadata("'DOEXPORTPDF'","{handler:'E142U2',iparms:[{av:'AV7SDTRelatorioUtilizacao',fld:'vSDTRELATORIOUTILIZACAO',grid:76,pic:''},{av:'GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'GridRC'}]");
         setEventMetadata("'DOEXPORTPDF'",",oparms:[]}");
         setEventMetadata("'DOCALCULAR'","{handler:'E152U2',iparms:[{av:'AV22ExisteErro',fld:'vEXISTEERRO',pic:''},{av:'AV11DataInicio',fld:'vDATAINICIO',pic:'99/99/99 99:99'},{av:'AV12DataFim',fld:'vDATAFIM',pic:'99/99/99 99:99'},{av:'AV8VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'},{av:'AV9ValorCombustivel',fld:'vVALORCOMBUSTIVEL',pic:'ZZZZZZZZZZZZ9.99 R$/L'},{av:'AV10ConsumoPresumido',fld:'vCONSUMOPRESUMIDO',pic:'ZZZZZZZ9 KM/L'}]");
         setEventMetadata("'DOCALCULAR'",",oparms:[{av:'AV10ConsumoPresumido',fld:'vCONSUMOPRESUMIDO',pic:'ZZZZZZZ9 KM/L'},{av:'AV9ValorCombustivel',fld:'vVALORCOMBUSTIVEL',pic:'ZZZZZZZZZZZZ9.99 R$/L'},{av:'AV8VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'},{av:'AV12DataFim',fld:'vDATAFIM',pic:'99/99/99 99:99'},{av:'AV11DataInicio',fld:'vDATAINICIO',pic:'99/99/99 99:99'},{av:'AV22ExisteErro',fld:'vEXISTEERRO',pic:''}]}");
         setEventMetadata("COMBO_VEICULOID.ONOPTIONCLICKED","{handler:'E112U2',iparms:[{av:'Combo_veiculoid_Selectedvalue_get',ctrl:'COMBO_VEICULOID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_VEICULOID.ONOPTIONCLICKED",",oparms:[{av:'AV8VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E162U2',iparms:[{av:'AV25NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''},{av:'AV7SDTRelatorioUtilizacao',fld:'vSDTRELATORIOUTILIZACAO',grid:76,pic:''},{av:'GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'GridRC'},{av:'GRIDSDTRELATORIOUTILIZACAOS_nEOF'},{av:'subGridsdtrelatorioutilizacaos_Rows',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'Rows'}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[{av:'AV7SDTRelatorioUtilizacao',fld:'vSDTRELATORIOUTILIZACAO',grid:76,pic:''},{av:'GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRIDSDTRELATORIOUTILIZACAOS',prop:'GridRC'}]}");
         setEventMetadata("VALIDV_DATAINICIO","{handler:'Validv_Datainicio',iparms:[]");
         setEventMetadata("VALIDV_DATAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_DATAFIM","{handler:'Validv_Datafim',iparms:[]");
         setEventMetadata("VALIDV_DATAFIM",",oparms:[]}");
         setEventMetadata("VALIDV_VEICULOID","{handler:'Validv_Veiculoid',iparms:[]");
         setEventMetadata("VALIDV_VEICULOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         Gridsdtrelatorioutilizacaospaginationbar_Selectedpage = "";
         Combo_veiculoid_Selectedvalue_get = "";
         AV25NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV7SDTRelatorioUtilizacao = new GXBaseCollection<SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem>( context, "SDTRelatorioUtilizacaoItem", "RastreamentoTCC");
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13VeiculoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29GridSDTRelatorioUtilizacaosAppliedFilters = "";
         Combo_veiculoid_Selectedvalue_set = "";
         Combo_veiculoid_Selectedtext_set = "";
         Combo_veiculoid_Gamoauthtoken = "";
         Gridsdtrelatorioutilizacaos_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_panel1 = new GXUserControl();
         lblTextblockcombo_veiculoid_Jsonclick = "";
         ucCombo_veiculoid = new GXUserControl();
         lblTextblockdatainicio_Jsonclick = "";
         TempTags = "";
         bttBtncalcular_Jsonclick = "";
         ucDvpanel_tableexport = new GXUserControl();
         bttBtnexportpdf_Jsonclick = "";
         GridsdtrelatorioutilizacaosContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridsdtrelatorioutilizacaos_Linesclass = "";
         GridsdtrelatorioutilizacaosColumn = new GXWebColumn();
         ucGridsdtrelatorioutilizacaospaginationbar = new GXUserControl();
         ucLoaderrelatorioutilizacao = new GXUserControl();
         ucGridsdtrelatorioutilizacaos_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11DataInicio = (DateTime)(DateTime.MinValue);
         AV12DataFim = (DateTime)(DateTime.MinValue);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV17GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GridsdtrelatorioutilizacaosRow = new GXWebRow();
         AV24ClientId = "";
         AV23Socket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV27CacheName = "";
         AV28window = new GXWindow();
         AV40Udparg1 = "";
         scmdbuf = "";
         A105VeiculoGAMGUID = "";
         H002U2_A105VeiculoGAMGUID = new string[] {""} ;
         H002U2_A98VeiculoId = new int[1] ;
         H002U2_A100VeiculoPlaca = new string[] {""} ;
         A100VeiculoPlaca = "";
         AV26SDTRelatorioUtilizacaoItem = new SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem(context);
         lblTxtdata_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relatorioutilizacao__default(),
            new Object[][] {
                new Object[] {
               H002U2_A105VeiculoGAMGUID, H002U2_A98VeiculoId, H002U2_A100VeiculoPlaca
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtrelatorioutilizacao__placa_Enabled = 0;
         edtavSdtrelatorioutilizacao__datahorainicial_Enabled = 0;
         edtavSdtrelatorioutilizacao__datahorafinal_Enabled = 0;
         edtavSdtrelatorioutilizacao__distanciatotal_Enabled = 0;
         edtavSdtrelatorioutilizacao__consumototal_Enabled = 0;
         edtavSdtrelatorioutilizacao__valorcombustivel_Enabled = 0;
      }

      private short GRIDSDTRELATORIOUTILIZACAOS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridsdtrelatorioutilizacaos_Backcolorstyle ;
      private short subGridsdtrelatorioutilizacaos_Titlebackstyle ;
      private short subGridsdtrelatorioutilizacaos_Allowselection ;
      private short subGridsdtrelatorioutilizacaos_Allowhovering ;
      private short subGridsdtrelatorioutilizacaos_Allowcollapsing ;
      private short subGridsdtrelatorioutilizacaos_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV39GXLvl129 ;
      private short nGXWrapped ;
      private short subGridsdtrelatorioutilizacaos_Backstyle ;
      private int Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_76 ;
      private int nGXsfl_76_idx=1 ;
      private int subGridsdtrelatorioutilizacaos_Rows ;
      private int Gridsdtrelatorioutilizacaospaginationbar_Pagestoshow ;
      private int Loaderrelatorioutilizacao_Basecolor ;
      private int edtavValorcombustivel_Enabled ;
      private int AV10ConsumoPresumido ;
      private int edtavConsumopresumido_Enabled ;
      private int subGridsdtrelatorioutilizacaos_Titlebackcolor ;
      private int subGridsdtrelatorioutilizacaos_Allbackcolor ;
      private int edtavSdtrelatorioutilizacao__placa_Enabled ;
      private int edtavSdtrelatorioutilizacao__datahorainicial_Enabled ;
      private int edtavSdtrelatorioutilizacao__datahorafinal_Enabled ;
      private int edtavSdtrelatorioutilizacao__distanciatotal_Enabled ;
      private int edtavSdtrelatorioutilizacao__consumototal_Enabled ;
      private int edtavSdtrelatorioutilizacao__valorcombustivel_Enabled ;
      private int subGridsdtrelatorioutilizacaos_Selectedindex ;
      private int subGridsdtrelatorioutilizacaos_Selectioncolor ;
      private int subGridsdtrelatorioutilizacaos_Hoveringcolor ;
      private int AV32GXV1 ;
      private int AV8VeiculoId ;
      private int edtavVeiculoid_Visible ;
      private int subGridsdtrelatorioutilizacaos_Islastpage ;
      private int GRIDSDTRELATORIOUTILIZACAOS_nGridOutOfScope ;
      private int nGXsfl_76_fel_idx=1 ;
      private int AV19PageToGo ;
      private int A98VeiculoId ;
      private int nGXsfl_76_bak_idx=1 ;
      private int edtavDatainicio_Enabled ;
      private int edtavDatafim_Enabled ;
      private int idxLst ;
      private int subGridsdtrelatorioutilizacaos_Backcolor ;
      private long GRIDSDTRELATORIOUTILIZACAOS_nFirstRecordOnPage ;
      private long AV20GridSDTRelatorioUtilizacaosCurrentPage ;
      private long AV21GridSDTRelatorioUtilizacaosPageCount ;
      private long GRIDSDTRELATORIOUTILIZACAOS_nCurrentRecord ;
      private long GRIDSDTRELATORIOUTILIZACAOS_nRecordCount ;
      private decimal AV9ValorCombustivel ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Selectedpage ;
      private string Combo_veiculoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_76_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_veiculoid_Cls ;
      private string Combo_veiculoid_Selectedvalue_set ;
      private string Combo_veiculoid_Selectedtext_set ;
      private string Combo_veiculoid_Gamoauthtoken ;
      private string Combo_veiculoid_Datalistproc ;
      private string Combo_veiculoid_Datalistprocparametersprefix ;
      private string Combo_veiculoid_Emptyitemtext ;
      private string Dvpanel_panel1_Width ;
      private string Dvpanel_panel1_Cls ;
      private string Dvpanel_panel1_Title ;
      private string Dvpanel_panel1_Iconposition ;
      private string Dvpanel_tableexport_Width ;
      private string Dvpanel_tableexport_Cls ;
      private string Dvpanel_tableexport_Title ;
      private string Dvpanel_tableexport_Iconposition ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Class ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Pagingbuttonsposition ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Pagingcaptionposition ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Emptygridclass ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageoptions ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Previous ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Next ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Caption ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Emptygridcaption ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Rowsperpagecaption ;
      private string Loaderrelatorioutilizacao_Loader ;
      private string Gridsdtrelatorioutilizacaos_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_panel1_Internalname ;
      private string divPanel1_Internalname ;
      private string divTbldados_Internalname ;
      private string divTablesplittedveiculoid_Internalname ;
      private string lblTextblockcombo_veiculoid_Internalname ;
      private string lblTextblockcombo_veiculoid_Jsonclick ;
      private string Combo_veiculoid_Caption ;
      private string Combo_veiculoid_Internalname ;
      private string divTabledeate_Internalname ;
      private string divTablesplitteddatainicio_Internalname ;
      private string lblTextblockdatainicio_Internalname ;
      private string lblTextblockdatainicio_Jsonclick ;
      private string edtavValorcombustivel_Internalname ;
      private string TempTags ;
      private string edtavValorcombustivel_Jsonclick ;
      private string edtavConsumopresumido_Internalname ;
      private string edtavConsumopresumido_Jsonclick ;
      private string bttBtncalcular_Internalname ;
      private string bttBtncalcular_Jsonclick ;
      private string Dvpanel_tableexport_Internalname ;
      private string divTableexport_Internalname ;
      private string bttBtnexportpdf_Internalname ;
      private string bttBtnexportpdf_Jsonclick ;
      private string divGridsdtrelatorioutilizacaostablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridsdtrelatorioutilizacaos_Internalname ;
      private string subGridsdtrelatorioutilizacaos_Class ;
      private string subGridsdtrelatorioutilizacaos_Linesclass ;
      private string subGridsdtrelatorioutilizacaos_Header ;
      private string Gridsdtrelatorioutilizacaospaginationbar_Internalname ;
      private string divUcloader_Internalname ;
      private string Loaderrelatorioutilizacao_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavVeiculoid_Internalname ;
      private string edtavVeiculoid_Jsonclick ;
      private string Gridsdtrelatorioutilizacaos_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavDatainicio_Internalname ;
      private string edtavSdtrelatorioutilizacao__placa_Internalname ;
      private string edtavSdtrelatorioutilizacao__datahorainicial_Internalname ;
      private string edtavSdtrelatorioutilizacao__datahorafinal_Internalname ;
      private string edtavSdtrelatorioutilizacao__distanciatotal_Internalname ;
      private string edtavSdtrelatorioutilizacao__consumototal_Internalname ;
      private string edtavSdtrelatorioutilizacao__valorcombustivel_Internalname ;
      private string sGXsfl_76_fel_idx="0001" ;
      private string edtavDatafim_Internalname ;
      private string AV40Udparg1 ;
      private string scmdbuf ;
      private string A105VeiculoGAMGUID ;
      private string tblTablemergeddatainicio_Internalname ;
      private string edtavDatainicio_Jsonclick ;
      private string lblTxtdata_Internalname ;
      private string lblTxtdata_Jsonclick ;
      private string edtavDatafim_Jsonclick ;
      private string ROClassString ;
      private string edtavSdtrelatorioutilizacao__placa_Jsonclick ;
      private string edtavSdtrelatorioutilizacao__datahorainicial_Jsonclick ;
      private string edtavSdtrelatorioutilizacao__datahorafinal_Jsonclick ;
      private string edtavSdtrelatorioutilizacao__distanciatotal_Jsonclick ;
      private string edtavSdtrelatorioutilizacao__consumototal_Jsonclick ;
      private string edtavSdtrelatorioutilizacao__valorcombustivel_Jsonclick ;
      private DateTime AV11DataInicio ;
      private DateTime AV12DataFim ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22ExisteErro ;
      private bool Dvpanel_panel1_Autowidth ;
      private bool Dvpanel_panel1_Autoheight ;
      private bool Dvpanel_panel1_Collapsible ;
      private bool Dvpanel_panel1_Collapsed ;
      private bool Dvpanel_panel1_Showcollapseicon ;
      private bool Dvpanel_panel1_Autoscroll ;
      private bool Dvpanel_tableexport_Autowidth ;
      private bool Dvpanel_tableexport_Autoheight ;
      private bool Dvpanel_tableexport_Collapsible ;
      private bool Dvpanel_tableexport_Collapsed ;
      private bool Dvpanel_tableexport_Showcollapseicon ;
      private bool Dvpanel_tableexport_Autoscroll ;
      private bool Gridsdtrelatorioutilizacaospaginationbar_Showfirst ;
      private bool Gridsdtrelatorioutilizacaospaginationbar_Showprevious ;
      private bool Gridsdtrelatorioutilizacaospaginationbar_Shownext ;
      private bool Gridsdtrelatorioutilizacaospaginationbar_Showlast ;
      private bool Gridsdtrelatorioutilizacaospaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV76 ;
      private string AV29GridSDTRelatorioUtilizacaosAppliedFilters ;
      private string AV24ClientId ;
      private string AV27CacheName ;
      private string A100VeiculoPlaca ;
      private GXWebGrid GridsdtrelatorioutilizacaosContainer ;
      private GXWebRow GridsdtrelatorioutilizacaosRow ;
      private GXWebColumn GridsdtrelatorioutilizacaosColumn ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_veiculoid ;
      private GXUserControl ucDvpanel_tableexport ;
      private GXUserControl ucGridsdtrelatorioutilizacaospaginationbar ;
      private GXUserControl ucLoaderrelatorioutilizacao ;
      private GXUserControl ucGridsdtrelatorioutilizacaos_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H002U2_A105VeiculoGAMGUID ;
      private int[] H002U2_A98VeiculoId ;
      private string[] H002U2_A100VeiculoPlaca ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem> AV7SDTRelatorioUtilizacao ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13VeiculoId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV17GAMErrors ;
      private GXWebForm Form ;
      private GXWindow AV28window ;
      private SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem AV26SDTRelatorioUtilizacaoItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV16GAMSession ;
      private GeneXus.Core.genexus.server.SdtSocket AV23Socket ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV25NotificationInfo ;
   }

   public class relatorioutilizacao__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002U2( IGxContext context ,
                                             string A105VeiculoGAMGUID ,
                                             string AV40Udparg1 ,
                                             int AV8VeiculoId ,
                                             int A98VeiculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT TOP 1 [VeiculoGAMGUID], [VeiculoId], [VeiculoPlaca] FROM [Veiculo]";
         AddWhere(sWhereString, "([VeiculoId] = @AV8VeiculoId)");
         if ( ! new verificaradministrador(context).executeUdp( ) )
         {
            AddWhere(sWhereString, "([VeiculoGAMGUID] = @AV40Udparg1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VeiculoId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002U2;
          prmH002U2 = new Object[] {
          new Object[] {"@AV8VeiculoId",SqlDbType.Int,8,0} ,
          new Object[] {"@AV40Udparg1",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("H002U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U2,1, GxCacheFrequency.OFF ,false,true )
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
                table[0][0] = rslt.getString(1, 40);
                table[1][0] = rslt.getInt(2);
                table[2][0] = rslt.getVarchar(3);
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
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[2]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[3]);
                }
                return;
       }
    }

 }

}
