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
   public class relatorioposicao : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public relatorioposicao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relatorioposicao( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdtrelatorioposicoess") == 0 )
            {
               nRC_GXsfl_68 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_68"), "."));
               nGXsfl_68_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_68_idx"), "."));
               sGXsfl_68_idx = GetPar( "sGXsfl_68_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridsdtrelatorioposicoess_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdtrelatorioposicoess") == 0 )
            {
               subGridsdtrelatorioposicoess_Rows = (int)(NumberUtil.Val( GetPar( "subGridsdtrelatorioposicoess_Rows"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridsdtrelatorioposicoess_refresh( subGridsdtrelatorioposicoess_Rows) ;
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
            return "relatorioposicao_Execute" ;
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
         PA2S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2S2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142918562210", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("relatorioposicao.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtrelatorioposicoes", AV15SDTRelatorioPosicoes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtrelatorioposicoes", AV15SDTRelatorioPosicoes);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_68", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_68), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVEICULOID_DATA", AV8VeiculoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVEICULOID_DATA", AV8VeiculoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOPOSICOESSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridSDTRelatorioPosicoessCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOPOSICOESSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19GridSDTRelatorioPosicoessPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOPOSICOESSAPPLIEDFILTERS", AV29GridSDTRelatorioPosicoessAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTRELATORIOPOSICOES", AV15SDTRelatorioPosicoes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTRELATORIOPOSICOES", AV15SDTRelatorioPosicoes);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vEXISTEERRO", AV20ExisteErro);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV23NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV23NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "vJSON", AV28JSON);
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Class", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridsdtrelatorioposicoesspaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridsdtrelatorioposicoesspaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridsdtrelatorioposicoesspaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridsdtrelatorioposicoesspaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioposicoesspaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Next", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "LOADERRELATORIOPOSICAO_Loader", StringUtil.RTrim( Loaderrelatorioposicao_Loader));
         GxWebStd.gx_hidden_field( context, "LOADERRELATORIOPOSICAO_Basecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(Loaderrelatorioposicao_Basecolor), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridsdtrelatorioposicoess_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Selectedvalue_get", StringUtil.RTrim( Combo_veiculoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtrelatorioposicoesspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            WE2S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2S2( ) ;
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
         return formatLink("relatorioposicao.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "RelatorioPosicao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Relatório de Posições" ;
      }

      protected void WB2S0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_veiculoid_Internalname, "Placa", "", "", lblTextblockcombo_veiculoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_RelatorioPosicao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_veiculoid.SetProperty("Caption", Combo_veiculoid_Caption);
            ucCombo_veiculoid.SetProperty("Cls", Combo_veiculoid_Cls);
            ucCombo_veiculoid.SetProperty("DataListProc", Combo_veiculoid_Datalistproc);
            ucCombo_veiculoid.SetProperty("DataListProcParametersPrefix", Combo_veiculoid_Datalistprocparametersprefix);
            ucCombo_veiculoid.SetProperty("EmptyItemText", Combo_veiculoid_Emptyitemtext);
            ucCombo_veiculoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucCombo_veiculoid.SetProperty("DropDownOptionsData", AV8VeiculoId_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockdatainicio_Internalname, "Intervalo de consulta", "", "", lblTextblockdatainicio_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_RelatorioPosicao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_39_2S2( true) ;
         }
         else
         {
            wb_table1_39_2S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_39_2S2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconsultar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(68), 2, 0)+","+"null"+");", "Consultar", bttBtnconsultar_Jsonclick, 5, "Consultar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCONSULTAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RelatorioPosicao.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportexcel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(68), 2, 0)+","+"null"+");", "Excel", bttBtnexportexcel_Jsonclick, 5, "Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RelatorioPosicao.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportpdf_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(68), 2, 0)+","+"null"+");", "PDF", bttBtnexportpdf_Jsonclick, 5, "PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTPDF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RelatorioPosicao.htm");
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
            GxWebStd.gx_div_start( context, divGridsdtrelatorioposicoesstablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridsdtrelatorioposicoessContainer.SetWrapped(nGXWrapped);
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridsdtrelatorioposicoessContainer"+"DivS\" data-gxgridid=\"68\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridsdtrelatorioposicoess_Internalname, subGridsdtrelatorioposicoess_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridsdtrelatorioposicoess_Backcolorstyle == 0 )
               {
                  subGridsdtrelatorioposicoess_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridsdtrelatorioposicoess_Class) > 0 )
                  {
                     subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"Title";
                  }
               }
               else
               {
                  subGridsdtrelatorioposicoess_Titlebackstyle = 1;
                  if ( subGridsdtrelatorioposicoess_Backcolorstyle == 1 )
                  {
                     subGridsdtrelatorioposicoess_Titlebackcolor = subGridsdtrelatorioposicoess_Allbackcolor;
                     if ( StringUtil.Len( subGridsdtrelatorioposicoess_Class) > 0 )
                     {
                        subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridsdtrelatorioposicoess_Class) > 0 )
                     {
                        subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Data/Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Placa") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Lat/Lng") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Ignição") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tensão") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Velocidade") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Odômetro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Horímetro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridsdtrelatorioposicoessContainer.AddObjectProperty("GridName", "Gridsdtrelatorioposicoess");
            }
            else
            {
               GridsdtrelatorioposicoessContainer.AddObjectProperty("GridName", "Gridsdtrelatorioposicoess");
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Header", subGridsdtrelatorioposicoess_Header);
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Backcolorstyle), 1, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("CmpContext", "");
               GridsdtrelatorioposicoessContainer.AddObjectProperty("InMasterPage", "false");
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__datahora_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__placa_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__latlng_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__ignicao_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__tensao_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__velocidade_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__odometro_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatorioposicoessColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatorioposicoes__horimetro_Enabled), 5, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddColumnProperties(GridsdtrelatorioposicoessColumn);
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Selectedindex), 4, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Allowselection), 1, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Selectioncolor), 9, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Allowhovering), 1, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Hoveringcolor), 9, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Allowcollapsing), 1, 0, ".", "")));
               GridsdtrelatorioposicoessContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 68 )
         {
            wbEnd = 0;
            nRC_GXsfl_68 = (int)(nGXsfl_68_idx-1);
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV32GXV1 = nGXsfl_68_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsdtrelatorioposicoessContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdtrelatorioposicoess", GridsdtrelatorioposicoessContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsdtrelatorioposicoessContainerData", GridsdtrelatorioposicoessContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsdtrelatorioposicoessContainerData"+"V", GridsdtrelatorioposicoessContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtrelatorioposicoessContainerData"+"V"+"\" value='"+GridsdtrelatorioposicoessContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("Class", Gridsdtrelatorioposicoesspaginationbar_Class);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("ShowFirst", Gridsdtrelatorioposicoesspaginationbar_Showfirst);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("ShowPrevious", Gridsdtrelatorioposicoesspaginationbar_Showprevious);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("ShowNext", Gridsdtrelatorioposicoesspaginationbar_Shownext);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("ShowLast", Gridsdtrelatorioposicoesspaginationbar_Showlast);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("PagesToShow", Gridsdtrelatorioposicoesspaginationbar_Pagestoshow);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("PagingButtonsPosition", Gridsdtrelatorioposicoesspaginationbar_Pagingbuttonsposition);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("PagingCaptionPosition", Gridsdtrelatorioposicoesspaginationbar_Pagingcaptionposition);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("EmptyGridClass", Gridsdtrelatorioposicoesspaginationbar_Emptygridclass);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("RowsPerPageSelector", Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselector);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("RowsPerPageOptions", Gridsdtrelatorioposicoesspaginationbar_Rowsperpageoptions);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("Previous", Gridsdtrelatorioposicoesspaginationbar_Previous);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("Next", Gridsdtrelatorioposicoesspaginationbar_Next);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("Caption", Gridsdtrelatorioposicoesspaginationbar_Caption);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("EmptyGridCaption", Gridsdtrelatorioposicoesspaginationbar_Emptygridcaption);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("RowsPerPageCaption", Gridsdtrelatorioposicoesspaginationbar_Rowsperpagecaption);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("CurrentPage", AV18GridSDTRelatorioPosicoessCurrentPage);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("PageCount", AV19GridSDTRelatorioPosicoessPageCount);
            ucGridsdtrelatorioposicoesspaginationbar.SetProperty("AppliedFilters", AV29GridSDTRelatorioPosicoessAppliedFilters);
            ucGridsdtrelatorioposicoesspaginationbar.Render(context, "dvelop.dvpaginationbar", Gridsdtrelatorioposicoesspaginationbar_Internalname, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBARContainer");
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
            ucLoaderrelatorioposicao.SetProperty("Loader", Loaderrelatorioposicao_Loader);
            ucLoaderrelatorioposicao.SetProperty("BaseColor", Loaderrelatorioposicao_Basecolor);
            ucLoaderrelatorioposicao.Render(context, "4rloader", Loaderrelatorioposicao_Internalname, "LOADERRELATORIOPOSICAOContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_68_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVeiculoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VeiculoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7VeiculoId), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVeiculoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavVeiculoid_Visible, 1, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioPosicao.htm");
            /* User Defined Control */
            ucGridsdtrelatorioposicoess_empowerer.Render(context, "wwp.gridempowerer", Gridsdtrelatorioposicoess_empowerer_Internalname, "GRIDSDTRELATORIOPOSICOESS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 68 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV32GXV1 = nGXsfl_68_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsdtrelatorioposicoessContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdtrelatorioposicoess", GridsdtrelatorioposicoessContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtrelatorioposicoessContainerData", GridsdtrelatorioposicoessContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtrelatorioposicoessContainerData"+"V", GridsdtrelatorioposicoessContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtrelatorioposicoessContainerData"+"V"+"\" value='"+GridsdtrelatorioposicoessContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2S2( )
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
            Form.Meta.addItem("description", "Relatório de Posições", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2S0( ) ;
      }

      protected void WS2S2( )
      {
         START2S2( ) ;
         EVT2S2( ) ;
      }

      protected void EVT2S2( )
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
                              E112S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportExcel' */
                              E142S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTPDF'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportPDF' */
                              E152S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONSULTAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConsultar' */
                              E162S2 ();
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
                              E172S2 ();
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 30), "GRIDSDTRELATORIOPOSICOESS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_68_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
                              SubsflControlProps_682( ) ;
                              AV32GXV1 = (int)(nGXsfl_68_idx+GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage);
                              if ( ( AV15SDTRelatorioPosicoes.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
                              {
                                 AV15SDTRelatorioPosicoes.CurrentItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1));
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
                                    E182S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOPOSICOESS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E202S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E172S2 ();
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
                                    E172S2 ();
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

      protected void WE2S2( )
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

      protected void PA2S2( )
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

      protected void gxnrGridsdtrelatorioposicoess_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_682( ) ;
         while ( nGXsfl_68_idx <= nRC_GXsfl_68 )
         {
            sendrow_682( ) ;
            nGXsfl_68_idx = ((subGridsdtrelatorioposicoess_Islastpage==1)&&(nGXsfl_68_idx+1>subGridsdtrelatorioposicoess_fnc_Recordsperpage( )) ? 1 : nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsdtrelatorioposicoessContainer)) ;
         /* End function gxnrGridsdtrelatorioposicoess_newrow */
      }

      protected void gxgrGridsdtrelatorioposicoess_refresh( int subGridsdtrelatorioposicoess_Rows )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E192S2 ();
         GRIDSDTRELATORIOPOSICOESS_nCurrentRecord = 0;
         RF2S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridsdtrelatorioposicoess_refresh */
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
         RF2S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtrelatorioposicoes__datahora_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__datahora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__datahora_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__placa_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__placa_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__latlng_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__latlng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__latlng_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__ignicao_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__ignicao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__ignicao_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__tensao_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__tensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__tensao_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__velocidade_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__velocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__velocidade_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__odometro_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__odometro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__odometro_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__horimetro_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__horimetro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__horimetro_Enabled), 5, 0), !bGXsfl_68_Refreshing);
      }

      protected void RF2S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsdtrelatorioposicoessContainer.ClearRows();
         }
         wbStart = 68;
         /* Execute user event: Refresh */
         E192S2 ();
         nGXsfl_68_idx = 1;
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_682( ) ;
         bGXsfl_68_Refreshing = true;
         GridsdtrelatorioposicoessContainer.AddObjectProperty("GridName", "Gridsdtrelatorioposicoess");
         GridsdtrelatorioposicoessContainer.AddObjectProperty("CmpContext", "");
         GridsdtrelatorioposicoessContainer.AddObjectProperty("InMasterPage", "false");
         GridsdtrelatorioposicoessContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridsdtrelatorioposicoessContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsdtrelatorioposicoessContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsdtrelatorioposicoessContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Backcolorstyle), 1, 0, ".", "")));
         GridsdtrelatorioposicoessContainer.PageSize = subGridsdtrelatorioposicoess_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_682( ) ;
            E202S2 ();
            if ( ( GRIDSDTRELATORIOPOSICOESS_nCurrentRecord > 0 ) && ( GRIDSDTRELATORIOPOSICOESS_nGridOutOfScope == 0 ) && ( nGXsfl_68_idx == 1 ) )
            {
               GRIDSDTRELATORIOPOSICOESS_nCurrentRecord = 0;
               GRIDSDTRELATORIOPOSICOESS_nGridOutOfScope = 1;
               subgridsdtrelatorioposicoess_firstpage( ) ;
               E202S2 ();
            }
            wbEnd = 68;
            WB2S0( ) ;
         }
         bGXsfl_68_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2S2( )
      {
      }

      protected int subGridsdtrelatorioposicoess_fnc_Pagecount( )
      {
         GRIDSDTRELATORIOPOSICOESS_nRecordCount = subGridsdtrelatorioposicoess_fnc_Recordcount( );
         if ( ((int)((GRIDSDTRELATORIOPOSICOESS_nRecordCount) % (subGridsdtrelatorioposicoess_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOPOSICOESS_nRecordCount/ (decimal)(subGridsdtrelatorioposicoess_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOPOSICOESS_nRecordCount/ (decimal)(subGridsdtrelatorioposicoess_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGridsdtrelatorioposicoess_fnc_Recordcount( )
      {
         return AV15SDTRelatorioPosicoes.Count ;
      }

      protected int subGridsdtrelatorioposicoess_fnc_Recordsperpage( )
      {
         if ( subGridsdtrelatorioposicoess_Rows > 0 )
         {
            return subGridsdtrelatorioposicoess_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdtrelatorioposicoess_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage/ (decimal)(subGridsdtrelatorioposicoess_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgridsdtrelatorioposicoess_firstpage( )
      {
         GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioposicoess_refresh( subGridsdtrelatorioposicoess_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtrelatorioposicoess_nextpage( )
      {
         GRIDSDTRELATORIOPOSICOESS_nRecordCount = subGridsdtrelatorioposicoess_fnc_Recordcount( );
         if ( ( GRIDSDTRELATORIOPOSICOESS_nRecordCount >= subGridsdtrelatorioposicoess_fnc_Recordsperpage( ) ) && ( GRIDSDTRELATORIOPOSICOESS_nEOF == 0 ) )
         {
            GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage+subGridsdtrelatorioposicoess_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsdtrelatorioposicoessContainer.AddObjectProperty("GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage", GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioposicoess_refresh( subGridsdtrelatorioposicoess_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDTRELATORIOPOSICOESS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdtrelatorioposicoess_previouspage( )
      {
         if ( GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage >= subGridsdtrelatorioposicoess_fnc_Recordsperpage( ) )
         {
            GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage-subGridsdtrelatorioposicoess_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioposicoess_refresh( subGridsdtrelatorioposicoess_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtrelatorioposicoess_lastpage( )
      {
         GRIDSDTRELATORIOPOSICOESS_nRecordCount = subGridsdtrelatorioposicoess_fnc_Recordcount( );
         if ( GRIDSDTRELATORIOPOSICOESS_nRecordCount > subGridsdtrelatorioposicoess_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDTRELATORIOPOSICOESS_nRecordCount) % (subGridsdtrelatorioposicoess_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOPOSICOESS_nRecordCount-subGridsdtrelatorioposicoess_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOPOSICOESS_nRecordCount-((int)((GRIDSDTRELATORIOPOSICOESS_nRecordCount) % (subGridsdtrelatorioposicoess_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioposicoess_refresh( subGridsdtrelatorioposicoess_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdtrelatorioposicoess_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = (long)(subGridsdtrelatorioposicoess_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatorioposicoess_refresh( subGridsdtrelatorioposicoess_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSdtrelatorioposicoes__datahora_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__datahora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__datahora_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__placa_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__placa_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__latlng_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__latlng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__latlng_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__ignicao_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__ignicao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__ignicao_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__tensao_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__tensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__tensao_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__velocidade_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__velocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__velocidade_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__odometro_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__odometro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__odometro_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtavSdtrelatorioposicoes__horimetro_Enabled = 0;
         AssignProp("", false, edtavSdtrelatorioposicoes__horimetro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatorioposicoes__horimetro_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtrelatorioposicoes"), AV15SDTRelatorioPosicoes);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV9DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vVEICULOID_DATA"), AV8VeiculoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTRELATORIOPOSICOES"), AV15SDTRelatorioPosicoes);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV23NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_68 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_68"), ",", "."));
            AV18GridSDTRelatorioPosicoessCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDSDTRELATORIOPOSICOESSCURRENTPAGE"), ",", "."));
            AV19GridSDTRelatorioPosicoessPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDSDTRELATORIOPOSICOESSPAGECOUNT"), ",", "."));
            AV29GridSDTRelatorioPosicoessAppliedFilters = cgiGet( "vGRIDSDTRELATORIOPOSICOESSAPPLIEDFILTERS");
            GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage"), ",", "."));
            GRIDSDTRELATORIOPOSICOESS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOPOSICOESS_nEOF"), ",", "."));
            subGridsdtrelatorioposicoess_Rows = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOPOSICOESS_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Rows), 6, 0, ".", "")));
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
            Gridsdtrelatorioposicoesspaginationbar_Class = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Class");
            Gridsdtrelatorioposicoesspaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Showfirst"));
            Gridsdtrelatorioposicoesspaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Showprevious"));
            Gridsdtrelatorioposicoesspaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Shownext"));
            Gridsdtrelatorioposicoesspaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Showlast"));
            Gridsdtrelatorioposicoesspaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Pagestoshow"), ",", "."));
            Gridsdtrelatorioposicoesspaginationbar_Pagingbuttonsposition = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Pagingbuttonsposition");
            Gridsdtrelatorioposicoesspaginationbar_Pagingcaptionposition = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Pagingcaptionposition");
            Gridsdtrelatorioposicoesspaginationbar_Emptygridclass = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Emptygridclass");
            Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageselector"));
            Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Gridsdtrelatorioposicoesspaginationbar_Rowsperpageoptions = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageoptions");
            Gridsdtrelatorioposicoesspaginationbar_Previous = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Previous");
            Gridsdtrelatorioposicoesspaginationbar_Next = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Next");
            Gridsdtrelatorioposicoesspaginationbar_Caption = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Caption");
            Gridsdtrelatorioposicoesspaginationbar_Emptygridcaption = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Emptygridcaption");
            Gridsdtrelatorioposicoesspaginationbar_Rowsperpagecaption = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpagecaption");
            Loaderrelatorioposicao_Loader = cgiGet( "LOADERRELATORIOPOSICAO_Loader");
            Loaderrelatorioposicao_Basecolor = (int)(context.localUtil.CToN( cgiGet( "LOADERRELATORIOPOSICAO_Basecolor"), ",", "."));
            Gridsdtrelatorioposicoess_empowerer_Gridinternalname = cgiGet( "GRIDSDTRELATORIOPOSICOESS_EMPOWERER_Gridinternalname");
            Gridsdtrelatorioposicoesspaginationbar_Selectedpage = cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Selectedpage");
            Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Combo_veiculoid_Selectedvalue_get = cgiGet( "COMBO_VEICULOID_Selectedvalue_get");
            nRC_GXsfl_68 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_68"), ",", "."));
            nGXsfl_68_fel_idx = 0;
            while ( nGXsfl_68_fel_idx < nRC_GXsfl_68 )
            {
               nGXsfl_68_fel_idx = ((subGridsdtrelatorioposicoess_Islastpage==1)&&(nGXsfl_68_fel_idx+1>subGridsdtrelatorioposicoess_fnc_Recordsperpage( )) ? 1 : nGXsfl_68_fel_idx+1);
               sGXsfl_68_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_682( ) ;
               AV32GXV1 = (int)(nGXsfl_68_fel_idx+GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage);
               if ( ( AV15SDTRelatorioPosicoes.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
               {
                  AV15SDTRelatorioPosicoes.CurrentItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1));
               }
            }
            if ( nGXsfl_68_fel_idx == 0 )
            {
               nGXsfl_68_idx = 1;
               sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
               SubsflControlProps_682( ) ;
            }
            nGXsfl_68_fel_idx = 1;
            /* Read variables values. */
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatainicio_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Inicio"}), 1, "vDATAINICIO");
               GX_FocusControl = edtavDatainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13DataInicio = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV13DataInicio", context.localUtil.TToC( AV13DataInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV13DataInicio = context.localUtil.CToT( cgiGet( edtavDatainicio_Internalname));
               AssignAttri("", false, "AV13DataInicio", context.localUtil.TToC( AV13DataInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatafim_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Fim"}), 1, "vDATAFIM");
               GX_FocusControl = edtavDatafim_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14DataFim = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV14DataFim", context.localUtil.TToC( AV14DataFim, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV14DataFim = context.localUtil.CToT( cgiGet( edtavDatafim_Internalname));
               AssignAttri("", false, "AV14DataFim", context.localUtil.TToC( AV14DataFim, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVeiculoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVeiculoid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVEICULOID");
               GX_FocusControl = edtavVeiculoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7VeiculoId = 0;
               AssignAttri("", false, "AV7VeiculoId", StringUtil.LTrimStr( (decimal)(AV7VeiculoId), 8, 0));
            }
            else
            {
               AV7VeiculoId = (int)(context.localUtil.CToN( cgiGet( edtavVeiculoid_Internalname), ",", "."));
               AssignAttri("", false, "AV7VeiculoId", StringUtil.LTrimStr( (decimal)(AV7VeiculoId), 8, 0));
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
         E182S2 ();
         if (returnInSub) return;
      }

      protected void E182S2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV9DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV9DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV11GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV12GAMErrors);
         Combo_veiculoid_Gamoauthtoken = AV11GAMSession.gxTpr_Token;
         ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "GAMOAuthToken", Combo_veiculoid_Gamoauthtoken);
         edtavVeiculoid_Visible = 0;
         AssignProp("", false, edtavVeiculoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVeiculoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOVEICULOID' */
         S112 ();
         if (returnInSub) return;
         Gridsdtrelatorioposicoess_empowerer_Gridinternalname = subGridsdtrelatorioposicoess_Internalname;
         ucGridsdtrelatorioposicoess_empowerer.SendProperty(context, "", false, Gridsdtrelatorioposicoess_empowerer_Internalname, "GridInternalName", Gridsdtrelatorioposicoess_empowerer_Gridinternalname);
         subGridsdtrelatorioposicoess_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Rows), 6, 0, ".", "")));
         Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue = subGridsdtrelatorioposicoess_Rows;
         ucGridsdtrelatorioposicoesspaginationbar.SendProperty(context, "", false, Gridsdtrelatorioposicoesspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue), 9, 0));
         GX_FocusControl = bttBtnconsultar_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E192S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV18GridSDTRelatorioPosicoessCurrentPage = subGridsdtrelatorioposicoess_fnc_Currentpage( );
         AssignAttri("", false, "AV18GridSDTRelatorioPosicoessCurrentPage", StringUtil.LTrimStr( (decimal)(AV18GridSDTRelatorioPosicoessCurrentPage), 10, 0));
         AV19GridSDTRelatorioPosicoessPageCount = subGridsdtrelatorioposicoess_fnc_Pagecount( );
         AssignAttri("", false, "AV19GridSDTRelatorioPosicoessPageCount", StringUtil.LTrimStr( (decimal)(AV19GridSDTRelatorioPosicoessPageCount), 10, 0));
         GX_FocusControl = bttBtnconsultar_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
         /*  Sending Event outputs  */
      }

      private void E202S2( )
      {
         /* Gridsdtrelatorioposicoess_Load Routine */
         returnInSub = false;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV15SDTRelatorioPosicoes.Count )
         {
            AV15SDTRelatorioPosicoes.CurrentItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 68;
            }
            if ( ( subGridsdtrelatorioposicoess_Islastpage == 1 ) || ( subGridsdtrelatorioposicoess_Rows == 0 ) || ( ( GRIDSDTRELATORIOPOSICOESS_nCurrentRecord >= GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage ) && ( GRIDSDTRELATORIOPOSICOESS_nCurrentRecord < GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage + subGridsdtrelatorioposicoess_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_682( ) ;
               GRIDSDTRELATORIOPOSICOESS_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nEOF), 1, 0, ".", "")));
               if ( GRIDSDTRELATORIOPOSICOESS_nCurrentRecord + 1 >= subGridsdtrelatorioposicoess_fnc_Recordcount( ) )
               {
                  GRIDSDTRELATORIOPOSICOESS_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOPOSICOESS_nEOF), 1, 0, ".", "")));
               }
            }
            GRIDSDTRELATORIOPOSICOESS_nCurrentRecord = (long)(GRIDSDTRELATORIOPOSICOESS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_68_Refreshing )
            {
               context.DoAjaxLoad(68, GridsdtrelatorioposicoessRow);
            }
            AV32GXV1 = (int)(AV32GXV1+1);
         }
      }

      protected void E122S2( )
      {
         /* Gridsdtrelatorioposicoesspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridsdtrelatorioposicoesspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgridsdtrelatorioposicoess_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridsdtrelatorioposicoesspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV17PageToGo = subGridsdtrelatorioposicoess_fnc_Currentpage( );
            AV17PageToGo = (int)(AV17PageToGo+1);
            subgridsdtrelatorioposicoess_gotopage( AV17PageToGo) ;
         }
         else
         {
            AV17PageToGo = (int)(NumberUtil.Val( Gridsdtrelatorioposicoesspaginationbar_Selectedpage, "."));
            subgridsdtrelatorioposicoess_gotopage( AV17PageToGo) ;
         }
      }

      protected void E132S2( )
      {
         /* Gridsdtrelatorioposicoesspaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridsdtrelatorioposicoess_Rows = Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOPOSICOESS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatorioposicoess_Rows), 6, 0, ".", "")));
         subgridsdtrelatorioposicoess_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142S2( )
      {
         AV32GXV1 = (int)(nGXsfl_68_idx+GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage);
         if ( AV15SDTRelatorioPosicoes.Count >= AV32GXV1 )
         {
            AV15SDTRelatorioPosicoes.CurrentItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1));
         }
         /* 'DoExportExcel' Routine */
         returnInSub = false;
         new exportrelatorioposicaoexcel(context ).execute(  AV15SDTRelatorioPosicoes, out  AV24ExcelFilename, out  AV25ErrorMessage) ;
         if ( StringUtil.StrCmp(AV24ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV24ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV25ErrorMessage);
         }
      }

      protected void E152S2( )
      {
         AV32GXV1 = (int)(nGXsfl_68_idx+GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage);
         if ( AV15SDTRelatorioPosicoes.Count >= AV32GXV1 )
         {
            AV15SDTRelatorioPosicoes.CurrentItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1));
         }
         /* 'DoExportPDF' Routine */
         returnInSub = false;
         AV21ClientId = AV22Socket.gxTpr_Clientid;
         AV26CacheName = "RelatorioPosicao_" + StringUtil.Trim( AV21ClientId);
         CacheAPI.Database.Set(AV26CacheName, AV15SDTRelatorioPosicoes.ToJSonString(false), 3);
         /* Window Datatype Object Property */
         AV27window.Url = formatLink("aexportrelatorioposicaopdf.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21ClientId)),UrlEncode(DateTimeUtil.FormatDateTimeParm(AV13DataInicio)),UrlEncode(DateTimeUtil.FormatDateTimeParm(AV14DataFim))}, new string[] {"ClientId","DataInicio","DataFim"}) ;
         AV27window.SetReturnParms(new Object[] {});
         AV27window.Height = 800;
         AV27window.Width = 1200;
         context.NewWindow(AV27window);
         /*  Sending Event outputs  */
      }

      protected void E162S2( )
      {
         /* 'DoConsultar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VERIFICARERROS' */
         S122 ();
         if (returnInSub) return;
         if ( ! AV20ExisteErro )
         {
            this.executeUsercontrolMethod("", false, "LOADERRELATORIOPOSICAOContainer", "Insert", "", new Object[] {});
            AV21ClientId = AV22Socket.gxTpr_Clientid;
            new gerarrelatorioposicao(context).executeSubmit(  AV21ClientId,  AV13DataInicio,  AV14DataFim,  AV7VeiculoId) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E112S2( )
      {
         /* Combo_veiculoid_Onoptionclicked Routine */
         returnInSub = false;
         AV7VeiculoId = (int)(NumberUtil.Val( Combo_veiculoid_Selectedvalue_get, "."));
         AssignAttri("", false, "AV7VeiculoId", StringUtil.LTrimStr( (decimal)(AV7VeiculoId), 8, 0));
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOVEICULOID' Routine */
         returnInSub = false;
         AV41GXLvl146 = 0;
         AV42Udparg1 = new buscargamguidusuariologado(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A105VeiculoGAMGUID ,
                                              AV42Udparg1 ,
                                              AV7VeiculoId ,
                                              A98VeiculoId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H002S2 */
         pr_default.execute(0, new Object[] {AV7VeiculoId, AV42Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A105VeiculoGAMGUID = H002S2_A105VeiculoGAMGUID[0];
            A98VeiculoId = H002S2_A98VeiculoId[0];
            A100VeiculoPlaca = H002S2_A100VeiculoPlaca[0];
            AV41GXLvl146 = 1;
            Combo_veiculoid_Selectedtext_set = A100VeiculoPlaca;
            ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedText_set", Combo_veiculoid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV41GXLvl146 == 0 )
         {
            Combo_veiculoid_Selectedtext_set = "";
            ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedText_set", Combo_veiculoid_Selectedtext_set);
         }
         Combo_veiculoid_Selectedvalue_set = ((0==AV7VeiculoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV7VeiculoId), 8, 0)));
         ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedValue_set", Combo_veiculoid_Selectedvalue_set);
      }

      protected void E172S2( )
      {
         AV32GXV1 = (int)(nGXsfl_68_idx+GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage);
         if ( AV15SDTRelatorioPosicoes.Count >= AV32GXV1 )
         {
            AV15SDTRelatorioPosicoes.CurrentItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1));
         }
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         new fixonmessage(context ).execute( ) ;
         AV28JSON = AV23NotificationInfo.gxTpr_Message;
         AssignAttri("", false, "AV28JSON", AV28JSON);
         /* Execute user subroutine: 'CARREGARGRID' */
         S132 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "LOADERRELATORIOPOSICAOContainer", "Remove", "", new Object[] {});
         /*  Sending Event outputs  */
         if ( gx_BV68 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTRelatorioPosicoes", AV15SDTRelatorioPosicoes);
            nGXsfl_68_bak_idx = nGXsfl_68_idx;
            gxgrGridsdtrelatorioposicoess_refresh( subGridsdtrelatorioposicoess_Rows) ;
            nGXsfl_68_idx = nGXsfl_68_bak_idx;
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
         }
      }

      protected void S132( )
      {
         /* 'CARREGARGRID' Routine */
         returnInSub = false;
         AV15SDTRelatorioPosicoes.FromJSonString(AV28JSON, null);
         gx_BV68 = true;
      }

      protected void S122( )
      {
         /* 'VERIFICARERROS' Routine */
         returnInSub = false;
         AV20ExisteErro = false;
         AssignAttri("", false, "AV20ExisteErro", AV20ExisteErro);
         if ( (DateTime.MinValue==AV13DataInicio) || (DateTime.MinValue==AV14DataFim) )
         {
            AV20ExisteErro = true;
            AssignAttri("", false, "AV20ExisteErro", AV20ExisteErro);
            GX_msglist.addItem("Intervalo de consulta inválido.");
         }
         else if ( AV13DataInicio > AV14DataFim )
         {
            AV20ExisteErro = true;
            AssignAttri("", false, "AV20ExisteErro", AV20ExisteErro);
            GX_msglist.addItem("Intervalo de consulta inválido.");
         }
         else if ( ( DateTimeUtil.TDiff( AV14DataFim, AV13DataInicio) / ( double )( 3600 ) / ( double )( 24 ) ) > 30 )
         {
            AV20ExisteErro = true;
            AssignAttri("", false, "AV20ExisteErro", AV20ExisteErro);
            GX_msglist.addItem("Intervalo de consulta máximo é de 30 dias.");
         }
      }

      protected void wb_table1_39_2S2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_68_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatainicio_Internalname, context.localUtil.TToC( AV13DataInicio, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV13DataInicio, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatainicio_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatainicio_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioPosicao.htm");
            GxWebStd.gx_bitmap( context, edtavDatainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RelatorioPosicao.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtdata_Internalname, "<p style='padding-top:8px;padding-left:4px'>até</p>", "", "", lblTxtdata_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 1, "HLP_RelatorioPosicao.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatafim_Internalname, "Data Fim", "gx-form-item AttributeDateTimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_68_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatafim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatafim_Internalname, context.localUtil.TToC( AV14DataFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV14DataFim, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatafim_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatafim_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioPosicao.htm");
            GxWebStd.gx_bitmap( context, edtavDatafim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatafim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RelatorioPosicao.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_39_2S2e( true) ;
         }
         else
         {
            wb_table1_39_2S2e( false) ;
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
         PA2S2( ) ;
         WS2S2( ) ;
         WE2S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918562644", true, true);
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
         context.AddJavascriptSource("relatorioposicao.js", "?202142918562645", false, true);
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

      protected void SubsflControlProps_682( )
      {
         edtavSdtrelatorioposicoes__datahora_Internalname = "SDTRELATORIOPOSICOES__DATAHORA_"+sGXsfl_68_idx;
         edtavSdtrelatorioposicoes__placa_Internalname = "SDTRELATORIOPOSICOES__PLACA_"+sGXsfl_68_idx;
         edtavSdtrelatorioposicoes__latlng_Internalname = "SDTRELATORIOPOSICOES__LATLNG_"+sGXsfl_68_idx;
         edtavSdtrelatorioposicoes__ignicao_Internalname = "SDTRELATORIOPOSICOES__IGNICAO_"+sGXsfl_68_idx;
         edtavSdtrelatorioposicoes__tensao_Internalname = "SDTRELATORIOPOSICOES__TENSAO_"+sGXsfl_68_idx;
         edtavSdtrelatorioposicoes__velocidade_Internalname = "SDTRELATORIOPOSICOES__VELOCIDADE_"+sGXsfl_68_idx;
         edtavSdtrelatorioposicoes__odometro_Internalname = "SDTRELATORIOPOSICOES__ODOMETRO_"+sGXsfl_68_idx;
         edtavSdtrelatorioposicoes__horimetro_Internalname = "SDTRELATORIOPOSICOES__HORIMETRO_"+sGXsfl_68_idx;
      }

      protected void SubsflControlProps_fel_682( )
      {
         edtavSdtrelatorioposicoes__datahora_Internalname = "SDTRELATORIOPOSICOES__DATAHORA_"+sGXsfl_68_fel_idx;
         edtavSdtrelatorioposicoes__placa_Internalname = "SDTRELATORIOPOSICOES__PLACA_"+sGXsfl_68_fel_idx;
         edtavSdtrelatorioposicoes__latlng_Internalname = "SDTRELATORIOPOSICOES__LATLNG_"+sGXsfl_68_fel_idx;
         edtavSdtrelatorioposicoes__ignicao_Internalname = "SDTRELATORIOPOSICOES__IGNICAO_"+sGXsfl_68_fel_idx;
         edtavSdtrelatorioposicoes__tensao_Internalname = "SDTRELATORIOPOSICOES__TENSAO_"+sGXsfl_68_fel_idx;
         edtavSdtrelatorioposicoes__velocidade_Internalname = "SDTRELATORIOPOSICOES__VELOCIDADE_"+sGXsfl_68_fel_idx;
         edtavSdtrelatorioposicoes__odometro_Internalname = "SDTRELATORIOPOSICOES__ODOMETRO_"+sGXsfl_68_fel_idx;
         edtavSdtrelatorioposicoes__horimetro_Internalname = "SDTRELATORIOPOSICOES__HORIMETRO_"+sGXsfl_68_fel_idx;
      }

      protected void sendrow_682( )
      {
         SubsflControlProps_682( ) ;
         WB2S0( ) ;
         if ( ( subGridsdtrelatorioposicoess_Rows * 1 == 0 ) || ( nGXsfl_68_idx <= subGridsdtrelatorioposicoess_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsdtrelatorioposicoessRow = GXWebRow.GetNew(context,GridsdtrelatorioposicoessContainer);
            if ( subGridsdtrelatorioposicoess_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdtrelatorioposicoess_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdtrelatorioposicoess_Class, "") != 0 )
               {
                  subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"Odd";
               }
            }
            else if ( subGridsdtrelatorioposicoess_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdtrelatorioposicoess_Backstyle = 0;
               subGridsdtrelatorioposicoess_Backcolor = subGridsdtrelatorioposicoess_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdtrelatorioposicoess_Class, "") != 0 )
               {
                  subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"Uniform";
               }
            }
            else if ( subGridsdtrelatorioposicoess_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdtrelatorioposicoess_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdtrelatorioposicoess_Class, "") != 0 )
               {
                  subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"Odd";
               }
               subGridsdtrelatorioposicoess_Backcolor = (int)(0x0);
            }
            else if ( subGridsdtrelatorioposicoess_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdtrelatorioposicoess_Backstyle = 1;
               if ( ((int)((nGXsfl_68_idx) % (2))) == 0 )
               {
                  subGridsdtrelatorioposicoess_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtrelatorioposicoess_Class, "") != 0 )
                  {
                     subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"Even";
                  }
               }
               else
               {
                  subGridsdtrelatorioposicoess_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtrelatorioposicoess_Class, "") != 0 )
                  {
                     subGridsdtrelatorioposicoess_Linesclass = subGridsdtrelatorioposicoess_Class+"Odd";
                  }
               }
            }
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_68_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__datahora_Internalname,context.localUtil.TToC( ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Datahora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Datahora, "99/99/9999 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__datahora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__datahora_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__placa_Internalname,((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Placa,StringUtil.RTrim( context.localUtil.Format( ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Placa, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__placa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__placa_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)7,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__latlng_Internalname,((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Latlng,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__latlng_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__latlng_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__ignicao_Internalname,((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Ignicao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__ignicao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__ignicao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__tensao_Internalname,((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Tensao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__tensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__tensao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__velocidade_Internalname,((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Velocidade,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__velocidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__velocidade_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__odometro_Internalname,((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Odometro,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__odometro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__odometro_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatorioposicoessContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatorioposicoessRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatorioposicoes__horimetro_Internalname,((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV15SDTRelatorioPosicoes.Item(AV32GXV1)).gxTpr_Horimetro,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatorioposicoes__horimetro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatorioposicoes__horimetro_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)68,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes2S2( ) ;
            GridsdtrelatorioposicoessContainer.AddRow(GridsdtrelatorioposicoessRow);
            nGXsfl_68_idx = ((subGridsdtrelatorioposicoess_Islastpage==1)&&(nGXsfl_68_idx+1>subGridsdtrelatorioposicoess_fnc_Recordsperpage( )) ? 1 : nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_682( ) ;
         }
         /* End function sendrow_682 */
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
         bttBtnconsultar_Internalname = "BTNCONSULTAR";
         divTbldados_Internalname = "TBLDADOS";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnexportexcel_Internalname = "BTNEXPORTEXCEL";
         bttBtnexportpdf_Internalname = "BTNEXPORTPDF";
         divTableexport_Internalname = "TABLEEXPORT";
         Dvpanel_tableexport_Internalname = "DVPANEL_TABLEEXPORT";
         divTablecontent_Internalname = "TABLECONTENT";
         edtavSdtrelatorioposicoes__datahora_Internalname = "SDTRELATORIOPOSICOES__DATAHORA";
         edtavSdtrelatorioposicoes__placa_Internalname = "SDTRELATORIOPOSICOES__PLACA";
         edtavSdtrelatorioposicoes__latlng_Internalname = "SDTRELATORIOPOSICOES__LATLNG";
         edtavSdtrelatorioposicoes__ignicao_Internalname = "SDTRELATORIOPOSICOES__IGNICAO";
         edtavSdtrelatorioposicoes__tensao_Internalname = "SDTRELATORIOPOSICOES__TENSAO";
         edtavSdtrelatorioposicoes__velocidade_Internalname = "SDTRELATORIOPOSICOES__VELOCIDADE";
         edtavSdtrelatorioposicoes__odometro_Internalname = "SDTRELATORIOPOSICOES__ODOMETRO";
         edtavSdtrelatorioposicoes__horimetro_Internalname = "SDTRELATORIOPOSICOES__HORIMETRO";
         Gridsdtrelatorioposicoesspaginationbar_Internalname = "GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR";
         divGridsdtrelatorioposicoesstablewithpaginationbar_Internalname = "GRIDSDTRELATORIOPOSICOESSTABLEWITHPAGINATIONBAR";
         Loaderrelatorioposicao_Internalname = "LOADERRELATORIOPOSICAO";
         divUcloader_Internalname = "UCLOADER";
         divTablemain_Internalname = "TABLEMAIN";
         edtavVeiculoid_Internalname = "vVEICULOID";
         Gridsdtrelatorioposicoess_empowerer_Internalname = "GRIDSDTRELATORIOPOSICOESS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridsdtrelatorioposicoess_Internalname = "GRIDSDTRELATORIOPOSICOESS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavSdtrelatorioposicoes__horimetro_Jsonclick = "";
         edtavSdtrelatorioposicoes__odometro_Jsonclick = "";
         edtavSdtrelatorioposicoes__velocidade_Jsonclick = "";
         edtavSdtrelatorioposicoes__tensao_Jsonclick = "";
         edtavSdtrelatorioposicoes__ignicao_Jsonclick = "";
         edtavSdtrelatorioposicoes__latlng_Jsonclick = "";
         edtavSdtrelatorioposicoes__placa_Jsonclick = "";
         edtavSdtrelatorioposicoes__datahora_Jsonclick = "";
         edtavDatafim_Jsonclick = "";
         edtavDatafim_Enabled = 1;
         edtavDatainicio_Jsonclick = "";
         edtavDatainicio_Enabled = 1;
         edtavSdtrelatorioposicoes__horimetro_Enabled = -1;
         edtavSdtrelatorioposicoes__odometro_Enabled = -1;
         edtavSdtrelatorioposicoes__velocidade_Enabled = -1;
         edtavSdtrelatorioposicoes__tensao_Enabled = -1;
         edtavSdtrelatorioposicoes__ignicao_Enabled = -1;
         edtavSdtrelatorioposicoes__latlng_Enabled = -1;
         edtavSdtrelatorioposicoes__placa_Enabled = -1;
         edtavSdtrelatorioposicoes__datahora_Enabled = -1;
         edtavVeiculoid_Jsonclick = "";
         edtavVeiculoid_Visible = 1;
         subGridsdtrelatorioposicoess_Allowcollapsing = 0;
         subGridsdtrelatorioposicoess_Allowselection = 0;
         subGridsdtrelatorioposicoess_Header = "";
         edtavSdtrelatorioposicoes__horimetro_Enabled = 0;
         edtavSdtrelatorioposicoes__odometro_Enabled = 0;
         edtavSdtrelatorioposicoes__velocidade_Enabled = 0;
         edtavSdtrelatorioposicoes__tensao_Enabled = 0;
         edtavSdtrelatorioposicoes__ignicao_Enabled = 0;
         edtavSdtrelatorioposicoes__latlng_Enabled = 0;
         edtavSdtrelatorioposicoes__placa_Enabled = 0;
         edtavSdtrelatorioposicoes__datahora_Enabled = 0;
         subGridsdtrelatorioposicoess_Class = "GridWithPaginationBar WorkWith";
         subGridsdtrelatorioposicoess_Backcolorstyle = 0;
         Combo_veiculoid_Caption = "";
         Loaderrelatorioposicao_Basecolor = (int)(0x08A086);
         Loaderrelatorioposicao_Loader = "2";
         Gridsdtrelatorioposicoesspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridsdtrelatorioposicoesspaginationbar_Emptygridcaption = "Nenhum resultado foi encontrado.";
         Gridsdtrelatorioposicoesspaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridsdtrelatorioposicoesspaginationbar_Next = "WWP_PagingNextCaption";
         Gridsdtrelatorioposicoesspaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridsdtrelatorioposicoesspaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue = 10;
         Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridsdtrelatorioposicoesspaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridsdtrelatorioposicoesspaginationbar_Pagingcaptionposition = "Left";
         Gridsdtrelatorioposicoesspaginationbar_Pagingbuttonsposition = "Right";
         Gridsdtrelatorioposicoesspaginationbar_Pagestoshow = 5;
         Gridsdtrelatorioposicoesspaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridsdtrelatorioposicoesspaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridsdtrelatorioposicoesspaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridsdtrelatorioposicoesspaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridsdtrelatorioposicoesspaginationbar_Class = "PaginationBar";
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
         Combo_veiculoid_Datalistproc = "RelatorioPosicaoLoadDVCombo";
         Combo_veiculoid_Cls = "ExtendedCombo Attribute";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Relatório de Posições";
         subGridsdtrelatorioposicoess_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOPOSICOESS_nEOF'},{av:'AV15SDTRelatorioPosicoes',fld:'vSDTRELATORIOPOSICOES',grid:68,pic:''},{av:'nRC_GXsfl_68',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'GridRC'},{av:'subGridsdtrelatorioposicoess_Rows',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'Rows'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV18GridSDTRelatorioPosicoessCurrentPage',fld:'vGRIDSDTRELATORIOPOSICOESSCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV19GridSDTRelatorioPosicoessPageCount',fld:'vGRIDSDTRELATORIOPOSICOESSPAGECOUNT',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRIDSDTRELATORIOPOSICOESS.LOAD","{handler:'E202S2',iparms:[]");
         setEventMetadata("GRIDSDTRELATORIOPOSICOESS.LOAD",",oparms:[]}");
         setEventMetadata("GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR.CHANGEPAGE","{handler:'E122S2',iparms:[{av:'GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOPOSICOESS_nEOF'},{av:'AV15SDTRelatorioPosicoes',fld:'vSDTRELATORIOPOSICOES',grid:68,pic:''},{av:'nRC_GXsfl_68',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'GridRC'},{av:'subGridsdtrelatorioposicoess_Rows',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'Rows'},{av:'Gridsdtrelatorioposicoesspaginationbar_Selectedpage',ctrl:'GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132S2',iparms:[{av:'GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOPOSICOESS_nEOF'},{av:'AV15SDTRelatorioPosicoes',fld:'vSDTRELATORIOPOSICOES',grid:68,pic:''},{av:'nRC_GXsfl_68',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'GridRC'},{av:'subGridsdtrelatorioposicoess_Rows',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'Rows'},{av:'Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDSDTRELATORIOPOSICOESSPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridsdtrelatorioposicoess_Rows',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'Rows'}]}");
         setEventMetadata("'DOEXPORTEXCEL'","{handler:'E142S2',iparms:[{av:'AV15SDTRelatorioPosicoes',fld:'vSDTRELATORIOPOSICOES',grid:68,pic:''},{av:'GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage'},{av:'nRC_GXsfl_68',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'GridRC'}]");
         setEventMetadata("'DOEXPORTEXCEL'",",oparms:[]}");
         setEventMetadata("'DOEXPORTPDF'","{handler:'E152S2',iparms:[{av:'AV15SDTRelatorioPosicoes',fld:'vSDTRELATORIOPOSICOES',grid:68,pic:''},{av:'GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage'},{av:'nRC_GXsfl_68',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'GridRC'},{av:'AV13DataInicio',fld:'vDATAINICIO',pic:'99/99/99 99:99'},{av:'AV14DataFim',fld:'vDATAFIM',pic:'99/99/99 99:99'}]");
         setEventMetadata("'DOEXPORTPDF'",",oparms:[]}");
         setEventMetadata("'DOCONSULTAR'","{handler:'E162S2',iparms:[{av:'AV20ExisteErro',fld:'vEXISTEERRO',pic:''},{av:'AV13DataInicio',fld:'vDATAINICIO',pic:'99/99/99 99:99'},{av:'AV14DataFim',fld:'vDATAFIM',pic:'99/99/99 99:99'},{av:'AV7VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOCONSULTAR'",",oparms:[{av:'AV7VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'},{av:'AV14DataFim',fld:'vDATAFIM',pic:'99/99/99 99:99'},{av:'AV13DataInicio',fld:'vDATAINICIO',pic:'99/99/99 99:99'},{av:'AV20ExisteErro',fld:'vEXISTEERRO',pic:''}]}");
         setEventMetadata("COMBO_VEICULOID.ONOPTIONCLICKED","{handler:'E112S2',iparms:[{av:'Combo_veiculoid_Selectedvalue_get',ctrl:'COMBO_VEICULOID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_VEICULOID.ONOPTIONCLICKED",",oparms:[{av:'AV7VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E172S2',iparms:[{av:'AV23NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''},{av:'AV28JSON',fld:'vJSON',pic:''},{av:'AV15SDTRelatorioPosicoes',fld:'vSDTRELATORIOPOSICOES',grid:68,pic:''},{av:'GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage'},{av:'nRC_GXsfl_68',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'GridRC'},{av:'GRIDSDTRELATORIOPOSICOESS_nEOF'},{av:'subGridsdtrelatorioposicoess_Rows',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'Rows'}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[{av:'AV28JSON',fld:'vJSON',pic:''},{av:'AV15SDTRelatorioPosicoes',fld:'vSDTRELATORIOPOSICOES',grid:68,pic:''},{av:'GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage'},{av:'nRC_GXsfl_68',ctrl:'GRIDSDTRELATORIOPOSICOESS',prop:'GridRC'}]}");
         setEventMetadata("VALIDV_DATAINICIO","{handler:'Validv_Datainicio',iparms:[]");
         setEventMetadata("VALIDV_DATAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_DATAFIM","{handler:'Validv_Datafim',iparms:[]");
         setEventMetadata("VALIDV_DATAFIM",",oparms:[]}");
         setEventMetadata("VALIDV_VEICULOID","{handler:'Validv_Veiculoid',iparms:[]");
         setEventMetadata("VALIDV_VEICULOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv9',iparms:[]");
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
         Gridsdtrelatorioposicoesspaginationbar_Selectedpage = "";
         Combo_veiculoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV15SDTRelatorioPosicoes = new GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem>( context, "SDTRelatorioPosicoesItem", "RastreamentoTCC");
         AV9DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV8VeiculoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29GridSDTRelatorioPosicoessAppliedFilters = "";
         AV23NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV28JSON = "";
         Combo_veiculoid_Selectedvalue_set = "";
         Combo_veiculoid_Selectedtext_set = "";
         Combo_veiculoid_Gamoauthtoken = "";
         Gridsdtrelatorioposicoess_empowerer_Gridinternalname = "";
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
         bttBtnconsultar_Jsonclick = "";
         ucDvpanel_tableexport = new GXUserControl();
         bttBtnexportexcel_Jsonclick = "";
         bttBtnexportpdf_Jsonclick = "";
         GridsdtrelatorioposicoessContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridsdtrelatorioposicoess_Linesclass = "";
         GridsdtrelatorioposicoessColumn = new GXWebColumn();
         ucGridsdtrelatorioposicoesspaginationbar = new GXUserControl();
         ucLoaderrelatorioposicao = new GXUserControl();
         ucGridsdtrelatorioposicoess_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13DataInicio = (DateTime)(DateTime.MinValue);
         AV14DataFim = (DateTime)(DateTime.MinValue);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV12GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GridsdtrelatorioposicoessRow = new GXWebRow();
         AV24ExcelFilename = "";
         AV25ErrorMessage = "";
         AV21ClientId = "";
         AV22Socket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV26CacheName = "";
         AV27window = new GXWindow();
         AV42Udparg1 = "";
         scmdbuf = "";
         A105VeiculoGAMGUID = "";
         H002S2_A105VeiculoGAMGUID = new string[] {""} ;
         H002S2_A98VeiculoId = new int[1] ;
         H002S2_A100VeiculoPlaca = new string[] {""} ;
         A100VeiculoPlaca = "";
         lblTxtdata_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relatorioposicao__default(),
            new Object[][] {
                new Object[] {
               H002S2_A105VeiculoGAMGUID, H002S2_A98VeiculoId, H002S2_A100VeiculoPlaca
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtrelatorioposicoes__datahora_Enabled = 0;
         edtavSdtrelatorioposicoes__placa_Enabled = 0;
         edtavSdtrelatorioposicoes__latlng_Enabled = 0;
         edtavSdtrelatorioposicoes__ignicao_Enabled = 0;
         edtavSdtrelatorioposicoes__tensao_Enabled = 0;
         edtavSdtrelatorioposicoes__velocidade_Enabled = 0;
         edtavSdtrelatorioposicoes__odometro_Enabled = 0;
         edtavSdtrelatorioposicoes__horimetro_Enabled = 0;
      }

      private short GRIDSDTRELATORIOPOSICOESS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridsdtrelatorioposicoess_Backcolorstyle ;
      private short subGridsdtrelatorioposicoess_Titlebackstyle ;
      private short subGridsdtrelatorioposicoess_Allowselection ;
      private short subGridsdtrelatorioposicoess_Allowhovering ;
      private short subGridsdtrelatorioposicoess_Allowcollapsing ;
      private short subGridsdtrelatorioposicoess_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV41GXLvl146 ;
      private short nGXWrapped ;
      private short subGridsdtrelatorioposicoess_Backstyle ;
      private int Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_68 ;
      private int nGXsfl_68_idx=1 ;
      private int subGridsdtrelatorioposicoess_Rows ;
      private int Gridsdtrelatorioposicoesspaginationbar_Pagestoshow ;
      private int Loaderrelatorioposicao_Basecolor ;
      private int subGridsdtrelatorioposicoess_Titlebackcolor ;
      private int subGridsdtrelatorioposicoess_Allbackcolor ;
      private int edtavSdtrelatorioposicoes__datahora_Enabled ;
      private int edtavSdtrelatorioposicoes__placa_Enabled ;
      private int edtavSdtrelatorioposicoes__latlng_Enabled ;
      private int edtavSdtrelatorioposicoes__ignicao_Enabled ;
      private int edtavSdtrelatorioposicoes__tensao_Enabled ;
      private int edtavSdtrelatorioposicoes__velocidade_Enabled ;
      private int edtavSdtrelatorioposicoes__odometro_Enabled ;
      private int edtavSdtrelatorioposicoes__horimetro_Enabled ;
      private int subGridsdtrelatorioposicoess_Selectedindex ;
      private int subGridsdtrelatorioposicoess_Selectioncolor ;
      private int subGridsdtrelatorioposicoess_Hoveringcolor ;
      private int AV32GXV1 ;
      private int AV7VeiculoId ;
      private int edtavVeiculoid_Visible ;
      private int subGridsdtrelatorioposicoess_Islastpage ;
      private int GRIDSDTRELATORIOPOSICOESS_nGridOutOfScope ;
      private int nGXsfl_68_fel_idx=1 ;
      private int AV17PageToGo ;
      private int A98VeiculoId ;
      private int nGXsfl_68_bak_idx=1 ;
      private int edtavDatainicio_Enabled ;
      private int edtavDatafim_Enabled ;
      private int idxLst ;
      private int subGridsdtrelatorioposicoess_Backcolor ;
      private long GRIDSDTRELATORIOPOSICOESS_nFirstRecordOnPage ;
      private long AV18GridSDTRelatorioPosicoessCurrentPage ;
      private long AV19GridSDTRelatorioPosicoessPageCount ;
      private long GRIDSDTRELATORIOPOSICOESS_nCurrentRecord ;
      private long GRIDSDTRELATORIOPOSICOESS_nRecordCount ;
      private string Gridsdtrelatorioposicoesspaginationbar_Selectedpage ;
      private string Combo_veiculoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_68_idx="0001" ;
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
      private string Gridsdtrelatorioposicoesspaginationbar_Class ;
      private string Gridsdtrelatorioposicoesspaginationbar_Pagingbuttonsposition ;
      private string Gridsdtrelatorioposicoesspaginationbar_Pagingcaptionposition ;
      private string Gridsdtrelatorioposicoesspaginationbar_Emptygridclass ;
      private string Gridsdtrelatorioposicoesspaginationbar_Rowsperpageoptions ;
      private string Gridsdtrelatorioposicoesspaginationbar_Previous ;
      private string Gridsdtrelatorioposicoesspaginationbar_Next ;
      private string Gridsdtrelatorioposicoesspaginationbar_Caption ;
      private string Gridsdtrelatorioposicoesspaginationbar_Emptygridcaption ;
      private string Gridsdtrelatorioposicoesspaginationbar_Rowsperpagecaption ;
      private string Loaderrelatorioposicao_Loader ;
      private string Gridsdtrelatorioposicoess_empowerer_Gridinternalname ;
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
      private string TempTags ;
      private string bttBtnconsultar_Internalname ;
      private string bttBtnconsultar_Jsonclick ;
      private string Dvpanel_tableexport_Internalname ;
      private string divTableexport_Internalname ;
      private string bttBtnexportexcel_Internalname ;
      private string bttBtnexportexcel_Jsonclick ;
      private string bttBtnexportpdf_Internalname ;
      private string bttBtnexportpdf_Jsonclick ;
      private string divGridsdtrelatorioposicoesstablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridsdtrelatorioposicoess_Internalname ;
      private string subGridsdtrelatorioposicoess_Class ;
      private string subGridsdtrelatorioposicoess_Linesclass ;
      private string subGridsdtrelatorioposicoess_Header ;
      private string Gridsdtrelatorioposicoesspaginationbar_Internalname ;
      private string divUcloader_Internalname ;
      private string Loaderrelatorioposicao_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavVeiculoid_Internalname ;
      private string edtavVeiculoid_Jsonclick ;
      private string Gridsdtrelatorioposicoess_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavDatainicio_Internalname ;
      private string edtavSdtrelatorioposicoes__datahora_Internalname ;
      private string edtavSdtrelatorioposicoes__placa_Internalname ;
      private string edtavSdtrelatorioposicoes__latlng_Internalname ;
      private string edtavSdtrelatorioposicoes__ignicao_Internalname ;
      private string edtavSdtrelatorioposicoes__tensao_Internalname ;
      private string edtavSdtrelatorioposicoes__velocidade_Internalname ;
      private string edtavSdtrelatorioposicoes__odometro_Internalname ;
      private string edtavSdtrelatorioposicoes__horimetro_Internalname ;
      private string sGXsfl_68_fel_idx="0001" ;
      private string edtavDatafim_Internalname ;
      private string AV42Udparg1 ;
      private string scmdbuf ;
      private string A105VeiculoGAMGUID ;
      private string tblTablemergeddatainicio_Internalname ;
      private string edtavDatainicio_Jsonclick ;
      private string lblTxtdata_Internalname ;
      private string lblTxtdata_Jsonclick ;
      private string edtavDatafim_Jsonclick ;
      private string ROClassString ;
      private string edtavSdtrelatorioposicoes__datahora_Jsonclick ;
      private string edtavSdtrelatorioposicoes__placa_Jsonclick ;
      private string edtavSdtrelatorioposicoes__latlng_Jsonclick ;
      private string edtavSdtrelatorioposicoes__ignicao_Jsonclick ;
      private string edtavSdtrelatorioposicoes__tensao_Jsonclick ;
      private string edtavSdtrelatorioposicoes__velocidade_Jsonclick ;
      private string edtavSdtrelatorioposicoes__odometro_Jsonclick ;
      private string edtavSdtrelatorioposicoes__horimetro_Jsonclick ;
      private DateTime AV13DataInicio ;
      private DateTime AV14DataFim ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20ExisteErro ;
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
      private bool Gridsdtrelatorioposicoesspaginationbar_Showfirst ;
      private bool Gridsdtrelatorioposicoesspaginationbar_Showprevious ;
      private bool Gridsdtrelatorioposicoesspaginationbar_Shownext ;
      private bool Gridsdtrelatorioposicoesspaginationbar_Showlast ;
      private bool Gridsdtrelatorioposicoesspaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_68_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV68 ;
      private string AV28JSON ;
      private string AV29GridSDTRelatorioPosicoessAppliedFilters ;
      private string AV24ExcelFilename ;
      private string AV25ErrorMessage ;
      private string AV21ClientId ;
      private string AV26CacheName ;
      private string A100VeiculoPlaca ;
      private GXWebGrid GridsdtrelatorioposicoessContainer ;
      private GXWebRow GridsdtrelatorioposicoessRow ;
      private GXWebColumn GridsdtrelatorioposicoessColumn ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_veiculoid ;
      private GXUserControl ucDvpanel_tableexport ;
      private GXUserControl ucGridsdtrelatorioposicoesspaginationbar ;
      private GXUserControl ucLoaderrelatorioposicao ;
      private GXUserControl ucGridsdtrelatorioposicoess_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H002S2_A105VeiculoGAMGUID ;
      private int[] H002S2_A98VeiculoId ;
      private string[] H002S2_A100VeiculoPlaca ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV8VeiculoId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12GAMErrors ;
      private GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem> AV15SDTRelatorioPosicoes ;
      private GXWebForm Form ;
      private GXWindow AV27window ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV9DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV11GAMSession ;
      private GeneXus.Core.genexus.server.SdtSocket AV22Socket ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV23NotificationInfo ;
   }

   public class relatorioposicao__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002S2( IGxContext context ,
                                             string A105VeiculoGAMGUID ,
                                             string AV42Udparg1 ,
                                             int AV7VeiculoId ,
                                             int A98VeiculoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT TOP 1 [VeiculoGAMGUID], [VeiculoId], [VeiculoPlaca] FROM [Veiculo]";
         AddWhere(sWhereString, "([VeiculoId] = @AV7VeiculoId)");
         if ( ! new verificaradministrador(context).executeUdp( ) )
         {
            AddWhere(sWhereString, "([VeiculoGAMGUID] = @AV42Udparg1)");
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
                     return conditional_H002S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
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
          Object[] prmH002S2;
          prmH002S2 = new Object[] {
          new Object[] {"@AV7VeiculoId",SqlDbType.Int,8,0} ,
          new Object[] {"@AV42Udparg1",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("H002S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S2,1, GxCacheFrequency.OFF ,false,true )
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
