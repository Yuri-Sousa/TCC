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
   public class relatoriohorastrabalhadas : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public relatoriohorastrabalhadas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relatoriohorastrabalhadas( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdtrelatoriohorastrabalhadass") == 0 )
            {
               nRC_GXsfl_66 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_66"), "."));
               nGXsfl_66_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_66_idx"), "."));
               sGXsfl_66_idx = GetPar( "sGXsfl_66_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridsdtrelatoriohorastrabalhadass_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdtrelatoriohorastrabalhadass") == 0 )
            {
               subGridsdtrelatoriohorastrabalhadass_Rows = (int)(NumberUtil.Val( GetPar( "subGridsdtrelatoriohorastrabalhadass_Rows"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridsdtrelatoriohorastrabalhadass_refresh( subGridsdtrelatoriohorastrabalhadass_Rows) ;
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
            return "relatoriohorastrabalhadas_Execute" ;
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
         PA2T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2T2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142918563066", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("relatoriohorastrabalhadas.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtrelatoriohorastrabalhadas", AV7SDTRelatorioHorasTrabalhadas);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtrelatoriohorastrabalhadas", AV7SDTRelatorioHorasTrabalhadas);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_66", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_66), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVEICULOID_DATA", AV11VeiculoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVEICULOID_DATA", AV11VeiculoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOHORASTRABALHADASSCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridSDTRelatorioHorasTrabalhadassCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOHORASTRABALHADASSPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19GridSDTRelatorioHorasTrabalhadassPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDSDTRELATORIOHORASTRABALHADASSAPPLIEDFILTERS", AV28GridSDTRelatorioHorasTrabalhadassAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTRELATORIOHORASTRABALHADAS", AV7SDTRelatorioHorasTrabalhadas);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTRELATORIOHORASTRABALHADAS", AV7SDTRelatorioHorasTrabalhadas);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vEXISTEERRO", AV24ExisteErro);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV26NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV26NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Class", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridsdtrelatoriohorastrabalhadasspaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridsdtrelatoriohorastrabalhadasspaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridsdtrelatoriohorastrabalhadasspaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridsdtrelatoriohorastrabalhadasspaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Previous", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Next", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Caption", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "LOADERRELATORIOHORASTRABALHADAS_Loader", StringUtil.RTrim( Loaderrelatoriohorastrabalhadas_Loader));
         GxWebStd.gx_hidden_field( context, "LOADERRELATORIOHORASTRABALHADAS_Basecolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(Loaderrelatoriohorastrabalhadas_Basecolor), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadass_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOID_Selectedvalue_get", StringUtil.RTrim( Combo_veiculoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_Message", AV26NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            WE2T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2T2( ) ;
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
         return formatLink("relatoriohorastrabalhadas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "RelatorioHorasTrabalhadas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Relatório de Horas Trabalhadas" ;
      }

      protected void WB2T0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_veiculoid_Internalname, "Placa", "", "", lblTextblockcombo_veiculoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_RelatorioHorasTrabalhadas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_veiculoid.SetProperty("Caption", Combo_veiculoid_Caption);
            ucCombo_veiculoid.SetProperty("Cls", Combo_veiculoid_Cls);
            ucCombo_veiculoid.SetProperty("DataListProc", Combo_veiculoid_Datalistproc);
            ucCombo_veiculoid.SetProperty("DataListProcParametersPrefix", Combo_veiculoid_Datalistprocparametersprefix);
            ucCombo_veiculoid.SetProperty("EmptyItemText", Combo_veiculoid_Emptyitemtext);
            ucCombo_veiculoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_veiculoid.SetProperty("DropDownOptionsData", AV11VeiculoId_Data);
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
            GxWebStd.gx_label_ctrl( context, lblTextblockdatainicio_Internalname, "Intervalo de consulta", "", "", lblTextblockdatainicio_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_RelatorioHorasTrabalhadas.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_39_2T2( true) ;
         }
         else
         {
            wb_table1_39_2T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_39_2T2e( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttBtncalcular_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(66), 2, 0)+","+"null"+");", "Calcular", bttBtncalcular_Jsonclick, 5, "Calcular", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCALCULAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RelatorioHorasTrabalhadas.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnexportpdf_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(66), 2, 0)+","+"null"+");", "PDF", bttBtnexportpdf_Jsonclick, 5, "PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTPDF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RelatorioHorasTrabalhadas.htm");
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
            GxWebStd.gx_div_start( context, divGridsdtrelatoriohorastrabalhadasstablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridsdtrelatoriohorastrabalhadassContainer.SetWrapped(nGXWrapped);
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridsdtrelatoriohorastrabalhadassContainer"+"DivS\" data-gxgridid=\"66\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridsdtrelatoriohorastrabalhadass_Internalname, subGridsdtrelatoriohorastrabalhadass_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGridsdtrelatoriohorastrabalhadass_Backcolorstyle == 0 )
               {
                  subGridsdtrelatoriohorastrabalhadass_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGridsdtrelatoriohorastrabalhadass_Class) > 0 )
                  {
                     subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"Title";
                  }
               }
               else
               {
                  subGridsdtrelatoriohorastrabalhadass_Titlebackstyle = 1;
                  if ( subGridsdtrelatoriohorastrabalhadass_Backcolorstyle == 1 )
                  {
                     subGridsdtrelatoriohorastrabalhadass_Titlebackcolor = subGridsdtrelatoriohorastrabalhadass_Allbackcolor;
                     if ( StringUtil.Len( subGridsdtrelatoriohorastrabalhadass_Class) > 0 )
                     {
                        subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGridsdtrelatoriohorastrabalhadass_Class) > 0 )
                     {
                        subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Placa") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tempo de Funcionamento") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tempo Ocioso") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Data/Hora Inicial") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Data/Hora Final") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("GridName", "Gridsdtrelatoriohorastrabalhadass");
            }
            else
            {
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("GridName", "Gridsdtrelatoriohorastrabalhadass");
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Header", subGridsdtrelatoriohorastrabalhadass_Header);
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Backcolorstyle), 1, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("CmpContext", "");
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("InMasterPage", "false");
               GridsdtrelatoriohorastrabalhadassColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatoriohorastrabalhadassColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatoriohorastrabalhadas__placa_Enabled), 5, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddColumnProperties(GridsdtrelatoriohorastrabalhadassColumn);
               GridsdtrelatoriohorastrabalhadassColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatoriohorastrabalhadassColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled), 5, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddColumnProperties(GridsdtrelatoriohorastrabalhadassColumn);
               GridsdtrelatoriohorastrabalhadassColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatoriohorastrabalhadassColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled), 5, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddColumnProperties(GridsdtrelatoriohorastrabalhadassColumn);
               GridsdtrelatoriohorastrabalhadassColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatoriohorastrabalhadassColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled), 5, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddColumnProperties(GridsdtrelatoriohorastrabalhadassColumn);
               GridsdtrelatoriohorastrabalhadassColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridsdtrelatoriohorastrabalhadassColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled), 5, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddColumnProperties(GridsdtrelatoriohorastrabalhadassColumn);
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Selectedindex), 4, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Allowselection), 1, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Selectioncolor), 9, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Allowhovering), 1, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Hoveringcolor), 9, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Allowcollapsing), 1, 0, ".", "")));
               GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 66 )
         {
            wbEnd = 0;
            nRC_GXsfl_66 = (int)(nGXsfl_66_idx-1);
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV31GXV1 = nGXsfl_66_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridsdtrelatoriohorastrabalhadassContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdtrelatoriohorastrabalhadass", GridsdtrelatoriohorastrabalhadassContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsdtrelatoriohorastrabalhadassContainerData", GridsdtrelatoriohorastrabalhadassContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridsdtrelatoriohorastrabalhadassContainerData"+"V", GridsdtrelatoriohorastrabalhadassContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtrelatoriohorastrabalhadassContainerData"+"V"+"\" value='"+GridsdtrelatoriohorastrabalhadassContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("Class", Gridsdtrelatoriohorastrabalhadasspaginationbar_Class);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("ShowFirst", Gridsdtrelatoriohorastrabalhadasspaginationbar_Showfirst);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("ShowPrevious", Gridsdtrelatoriohorastrabalhadasspaginationbar_Showprevious);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("ShowNext", Gridsdtrelatoriohorastrabalhadasspaginationbar_Shownext);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("ShowLast", Gridsdtrelatoriohorastrabalhadasspaginationbar_Showlast);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("PagesToShow", Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagestoshow);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("PagingButtonsPosition", Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingbuttonsposition);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("PagingCaptionPosition", Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingcaptionposition);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("EmptyGridClass", Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridclass);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("RowsPerPageSelector", Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselector);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("RowsPerPageOptions", Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageoptions);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("Previous", Gridsdtrelatoriohorastrabalhadasspaginationbar_Previous);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("Next", Gridsdtrelatoriohorastrabalhadasspaginationbar_Next);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("Caption", Gridsdtrelatoriohorastrabalhadasspaginationbar_Caption);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("EmptyGridCaption", Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridcaption);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("RowsPerPageCaption", Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpagecaption);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("CurrentPage", AV18GridSDTRelatorioHorasTrabalhadassCurrentPage);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("PageCount", AV19GridSDTRelatorioHorasTrabalhadassPageCount);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.SetProperty("AppliedFilters", AV28GridSDTRelatorioHorasTrabalhadassAppliedFilters);
            ucGridsdtrelatoriohorastrabalhadasspaginationbar.Render(context, "dvelop.dvpaginationbar", Gridsdtrelatoriohorastrabalhadasspaginationbar_Internalname, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBARContainer");
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
            ucLoaderrelatoriohorastrabalhadas.SetProperty("Loader", Loaderrelatoriohorastrabalhadas_Loader);
            ucLoaderrelatoriohorastrabalhadas.SetProperty("BaseColor", Loaderrelatoriohorastrabalhadas_Basecolor);
            ucLoaderrelatoriohorastrabalhadas.Render(context, "4rloader", Loaderrelatoriohorastrabalhadas_Internalname, "LOADERRELATORIOHORASTRABALHADASContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_66_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVeiculoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8VeiculoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8VeiculoId), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVeiculoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavVeiculoid_Visible, 1, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioHorasTrabalhadas.htm");
            /* User Defined Control */
            ucGridsdtrelatoriohorastrabalhadass_empowerer.Render(context, "wwp.gridempowerer", Gridsdtrelatoriohorastrabalhadass_empowerer_Internalname, "GRIDSDTRELATORIOHORASTRABALHADASS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 66 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV31GXV1 = nGXsfl_66_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridsdtrelatoriohorastrabalhadassContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsdtrelatoriohorastrabalhadass", GridsdtrelatoriohorastrabalhadassContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtrelatoriohorastrabalhadassContainerData", GridsdtrelatoriohorastrabalhadassContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridsdtrelatoriohorastrabalhadassContainerData"+"V", GridsdtrelatoriohorastrabalhadassContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridsdtrelatoriohorastrabalhadassContainerData"+"V"+"\" value='"+GridsdtrelatoriohorastrabalhadassContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2T2( )
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
            Form.Meta.addItem("description", "Relatório de Horas Trabalhadas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2T0( ) ;
      }

      protected void WS2T2( )
      {
         START2T2( ) ;
         EVT2T2( ) ;
      }

      protected void EVT2T2( )
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
                              E112T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTPDF'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportPDF' */
                              E142T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCALCULAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCalcular' */
                              E152T2 ();
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
                              E162T2 ();
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 38), "GRIDSDTRELATORIOHORASTRABALHADASS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_66_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
                              SubsflControlProps_662( ) ;
                              AV31GXV1 = (int)(nGXsfl_66_idx+GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage);
                              if ( ( AV7SDTRelatorioHorasTrabalhadas.Count >= AV31GXV1 ) && ( AV31GXV1 > 0 ) )
                              {
                                 AV7SDTRelatorioHorasTrabalhadas.CurrentItem = ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1));
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
                                    E172T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E182T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDTRELATORIOHORASTRABALHADASS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E162T2 ();
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
                                    E162T2 ();
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

      protected void WE2T2( )
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

      protected void PA2T2( )
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

      protected void gxnrGridsdtrelatoriohorastrabalhadass_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_662( ) ;
         while ( nGXsfl_66_idx <= nRC_GXsfl_66 )
         {
            sendrow_662( ) ;
            nGXsfl_66_idx = ((subGridsdtrelatoriohorastrabalhadass_Islastpage==1)&&(nGXsfl_66_idx+1>subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )) ? 1 : nGXsfl_66_idx+1);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
            SubsflControlProps_662( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsdtrelatoriohorastrabalhadassContainer)) ;
         /* End function gxnrGridsdtrelatoriohorastrabalhadass_newrow */
      }

      protected void gxgrGridsdtrelatoriohorastrabalhadass_refresh( int subGridsdtrelatoriohorastrabalhadass_Rows )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E182T2 ();
         GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord = 0;
         RF2T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridsdtrelatoriohorastrabalhadass_refresh */
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
         RF2T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtrelatoriohorastrabalhadas__placa_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__placa_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__tempoocioso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__datahorainicial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__datahorafinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled), 5, 0), !bGXsfl_66_Refreshing);
      }

      protected void RF2T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsdtrelatoriohorastrabalhadassContainer.ClearRows();
         }
         wbStart = 66;
         /* Execute user event: Refresh */
         E182T2 ();
         nGXsfl_66_idx = 1;
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_662( ) ;
         bGXsfl_66_Refreshing = true;
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("GridName", "Gridsdtrelatoriohorastrabalhadass");
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("CmpContext", "");
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("InMasterPage", "false");
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Backcolorstyle), 1, 0, ".", "")));
         GridsdtrelatoriohorastrabalhadassContainer.PageSize = subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_662( ) ;
            E192T2 ();
            if ( ( GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord > 0 ) && ( GRIDSDTRELATORIOHORASTRABALHADASS_nGridOutOfScope == 0 ) && ( nGXsfl_66_idx == 1 ) )
            {
               GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord = 0;
               GRIDSDTRELATORIOHORASTRABALHADASS_nGridOutOfScope = 1;
               subgridsdtrelatoriohorastrabalhadass_firstpage( ) ;
               E192T2 ();
            }
            wbEnd = 66;
            WB2T0( ) ;
         }
         bGXsfl_66_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2T2( )
      {
      }

      protected int subGridsdtrelatoriohorastrabalhadass_fnc_Pagecount( )
      {
         GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount = subGridsdtrelatoriohorastrabalhadass_fnc_Recordcount( );
         if ( ((int)((GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount) % (subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount/ (decimal)(subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount/ (decimal)(subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGridsdtrelatoriohorastrabalhadass_fnc_Recordcount( )
      {
         return AV7SDTRelatorioHorasTrabalhadas.Count ;
      }

      protected int subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )
      {
         if ( subGridsdtrelatoriohorastrabalhadass_Rows > 0 )
         {
            return subGridsdtrelatoriohorastrabalhadass_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdtrelatoriohorastrabalhadass_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage/ (decimal)(subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgridsdtrelatoriohorastrabalhadass_firstpage( )
      {
         GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatoriohorastrabalhadass_refresh( subGridsdtrelatoriohorastrabalhadass_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtrelatoriohorastrabalhadass_nextpage( )
      {
         GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount = subGridsdtrelatoriohorastrabalhadass_fnc_Recordcount( );
         if ( ( GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount >= subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ) ) && ( GRIDSDTRELATORIOHORASTRABALHADASS_nEOF == 0 ) )
         {
            GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage+subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsdtrelatoriohorastrabalhadassContainer.AddObjectProperty("GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage", GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatoriohorastrabalhadass_refresh( subGridsdtrelatoriohorastrabalhadass_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDTRELATORIOHORASTRABALHADASS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdtrelatoriohorastrabalhadass_previouspage( )
      {
         if ( GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage >= subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ) )
         {
            GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage-subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatoriohorastrabalhadass_refresh( subGridsdtrelatoriohorastrabalhadass_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdtrelatoriohorastrabalhadass_lastpage( )
      {
         GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount = subGridsdtrelatoriohorastrabalhadass_fnc_Recordcount( );
         if ( GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount > subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount) % (subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount-subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount-((int)((GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount) % (subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatoriohorastrabalhadass_refresh( subGridsdtrelatoriohorastrabalhadass_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdtrelatoriohorastrabalhadass_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = (long)(subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdtrelatoriohorastrabalhadass_refresh( subGridsdtrelatoriohorastrabalhadass_Rows) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSdtrelatoriohorastrabalhadas__placa_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__placa_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__tempoocioso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__datahorainicial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled = 0;
         AssignProp("", false, edtavSdtrelatoriohorastrabalhadas__datahorafinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E172T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtrelatoriohorastrabalhadas"), AV7SDTRelatorioHorasTrabalhadas);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV12DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vVEICULOID_DATA"), AV11VeiculoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTRELATORIOHORASTRABALHADAS"), AV7SDTRelatorioHorasTrabalhadas);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV26NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_66 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_66"), ",", "."));
            AV18GridSDTRelatorioHorasTrabalhadassCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDSDTRELATORIOHORASTRABALHADASSCURRENTPAGE"), ",", "."));
            AV19GridSDTRelatorioHorasTrabalhadassPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDSDTRELATORIOHORASTRABALHADASSPAGECOUNT"), ",", "."));
            AV28GridSDTRelatorioHorasTrabalhadassAppliedFilters = cgiGet( "vGRIDSDTRELATORIOHORASTRABALHADASSAPPLIEDFILTERS");
            GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage"), ",", "."));
            GRIDSDTRELATORIOHORASTRABALHADASS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASS_nEOF"), ",", "."));
            subGridsdtrelatoriohorastrabalhadass_Rows = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASS_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Rows), 6, 0, ".", "")));
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
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Class = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Class");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Showfirst"));
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Showprevious"));
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Shownext"));
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Showlast"));
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Pagestoshow"), ",", "."));
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingbuttonsposition = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Pagingbuttonsposition");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingcaptionposition = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Pagingcaptionposition");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridclass = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Emptygridclass");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageselector"));
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageoptions = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageoptions");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Previous = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Previous");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Next = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Next");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Caption = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Caption");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridcaption = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Emptygridcaption");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpagecaption = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpagecaption");
            Loaderrelatoriohorastrabalhadas_Loader = cgiGet( "LOADERRELATORIOHORASTRABALHADAS_Loader");
            Loaderrelatoriohorastrabalhadas_Basecolor = (int)(context.localUtil.CToN( cgiGet( "LOADERRELATORIOHORASTRABALHADAS_Basecolor"), ",", "."));
            Gridsdtrelatoriohorastrabalhadass_empowerer_Gridinternalname = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASS_EMPOWERER_Gridinternalname");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage = cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Selectedpage");
            Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Combo_veiculoid_Selectedvalue_get = cgiGet( "COMBO_VEICULOID_Selectedvalue_get");
            nRC_GXsfl_66 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_66"), ",", "."));
            nGXsfl_66_fel_idx = 0;
            while ( nGXsfl_66_fel_idx < nRC_GXsfl_66 )
            {
               nGXsfl_66_fel_idx = ((subGridsdtrelatoriohorastrabalhadass_Islastpage==1)&&(nGXsfl_66_fel_idx+1>subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )) ? 1 : nGXsfl_66_fel_idx+1);
               sGXsfl_66_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_662( ) ;
               AV31GXV1 = (int)(nGXsfl_66_fel_idx+GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage);
               if ( ( AV7SDTRelatorioHorasTrabalhadas.Count >= AV31GXV1 ) && ( AV31GXV1 > 0 ) )
               {
                  AV7SDTRelatorioHorasTrabalhadas.CurrentItem = ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1));
               }
            }
            if ( nGXsfl_66_fel_idx == 0 )
            {
               nGXsfl_66_idx = 1;
               sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
               SubsflControlProps_662( ) ;
            }
            nGXsfl_66_fel_idx = 1;
            /* Read variables values. */
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatainicio_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Inicio"}), 1, "vDATAINICIO");
               GX_FocusControl = edtavDatainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9DataInicio = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV9DataInicio", context.localUtil.TToC( AV9DataInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV9DataInicio = context.localUtil.CToT( cgiGet( edtavDatainicio_Internalname));
               AssignAttri("", false, "AV9DataInicio", context.localUtil.TToC( AV9DataInicio, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatafim_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Fim"}), 1, "vDATAFIM");
               GX_FocusControl = edtavDatafim_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10DataFim = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV10DataFim", context.localUtil.TToC( AV10DataFim, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV10DataFim = context.localUtil.CToT( cgiGet( edtavDatafim_Internalname));
               AssignAttri("", false, "AV10DataFim", context.localUtil.TToC( AV10DataFim, 8, 5, 0, 3, "/", ":", " "));
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
         E172T2 ();
         if (returnInSub) return;
      }

      protected void E172T2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV12DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV12DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV14GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV15GAMErrors);
         Combo_veiculoid_Gamoauthtoken = AV14GAMSession.gxTpr_Token;
         ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "GAMOAuthToken", Combo_veiculoid_Gamoauthtoken);
         edtavVeiculoid_Visible = 0;
         AssignProp("", false, edtavVeiculoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVeiculoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOVEICULOID' */
         S112 ();
         if (returnInSub) return;
         Gridsdtrelatoriohorastrabalhadass_empowerer_Gridinternalname = subGridsdtrelatoriohorastrabalhadass_Internalname;
         ucGridsdtrelatoriohorastrabalhadass_empowerer.SendProperty(context, "", false, Gridsdtrelatoriohorastrabalhadass_empowerer_Internalname, "GridInternalName", Gridsdtrelatoriohorastrabalhadass_empowerer_Gridinternalname);
         subGridsdtrelatoriohorastrabalhadass_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Rows), 6, 0, ".", "")));
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue = subGridsdtrelatoriohorastrabalhadass_Rows;
         ucGridsdtrelatoriohorastrabalhadasspaginationbar.SendProperty(context, "", false, Gridsdtrelatoriohorastrabalhadasspaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue), 9, 0));
         GX_FocusControl = bttBtncalcular_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E182T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV18GridSDTRelatorioHorasTrabalhadassCurrentPage = subGridsdtrelatoriohorastrabalhadass_fnc_Currentpage( );
         AssignAttri("", false, "AV18GridSDTRelatorioHorasTrabalhadassCurrentPage", StringUtil.LTrimStr( (decimal)(AV18GridSDTRelatorioHorasTrabalhadassCurrentPage), 10, 0));
         AV19GridSDTRelatorioHorasTrabalhadassPageCount = subGridsdtrelatoriohorastrabalhadass_fnc_Pagecount( );
         AssignAttri("", false, "AV19GridSDTRelatorioHorasTrabalhadassPageCount", StringUtil.LTrimStr( (decimal)(AV19GridSDTRelatorioHorasTrabalhadassPageCount), 10, 0));
         GX_FocusControl = bttBtncalcular_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
         /*  Sending Event outputs  */
      }

      private void E192T2( )
      {
         /* Gridsdtrelatoriohorastrabalhadass_Load Routine */
         returnInSub = false;
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV7SDTRelatorioHorasTrabalhadas.Count )
         {
            AV7SDTRelatorioHorasTrabalhadas.CurrentItem = ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 66;
            }
            if ( ( subGridsdtrelatoriohorastrabalhadass_Islastpage == 1 ) || ( subGridsdtrelatoriohorastrabalhadass_Rows == 0 ) || ( ( GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord >= GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage ) && ( GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord < GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage + subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_662( ) ;
               GRIDSDTRELATORIOHORASTRABALHADASS_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nEOF), 1, 0, ".", "")));
               if ( GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord + 1 >= subGridsdtrelatoriohorastrabalhadass_fnc_Recordcount( ) )
               {
                  GRIDSDTRELATORIOHORASTRABALHADASS_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDTRELATORIOHORASTRABALHADASS_nEOF), 1, 0, ".", "")));
               }
            }
            GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord = (long)(GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_66_Refreshing )
            {
               context.DoAjaxLoad(66, GridsdtrelatoriohorastrabalhadassRow);
            }
            AV31GXV1 = (int)(AV31GXV1+1);
         }
      }

      protected void E122T2( )
      {
         /* Gridsdtrelatoriohorastrabalhadasspaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgridsdtrelatoriohorastrabalhadass_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage, "Next") == 0 )
         {
            AV17PageToGo = subGridsdtrelatoriohorastrabalhadass_fnc_Currentpage( );
            AV17PageToGo = (int)(AV17PageToGo+1);
            subgridsdtrelatoriohorastrabalhadass_gotopage( AV17PageToGo) ;
         }
         else
         {
            AV17PageToGo = (int)(NumberUtil.Val( Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage, "."));
            subgridsdtrelatoriohorastrabalhadass_gotopage( AV17PageToGo) ;
         }
      }

      protected void E132T2( )
      {
         /* Gridsdtrelatoriohorastrabalhadasspaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridsdtrelatoriohorastrabalhadass_Rows = Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDSDTRELATORIOHORASTRABALHADASS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdtrelatoriohorastrabalhadass_Rows), 6, 0, ".", "")));
         subgridsdtrelatoriohorastrabalhadass_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142T2( )
      {
         AV31GXV1 = (int)(nGXsfl_66_idx+GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage);
         if ( AV7SDTRelatorioHorasTrabalhadas.Count >= AV31GXV1 )
         {
            AV7SDTRelatorioHorasTrabalhadas.CurrentItem = ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1));
         }
         /* 'DoExportPDF' Routine */
         returnInSub = false;
         AV21ClientId = AV22Socket.gxTpr_Clientid;
         AV20CacheName = "RelatorioDeHorasTrabalhadas" + StringUtil.Trim( AV21ClientId);
         CacheAPI.Database.Set(AV20CacheName, AV7SDTRelatorioHorasTrabalhadas.ToJSonString(false), 3);
         /* Window Datatype Object Property */
         AV23window.Url = formatLink("aexportrelatoriodehorastrabalhadaspdf.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21ClientId))}, new string[] {"ClientId"}) ;
         AV23window.SetReturnParms(new Object[] {});
         AV23window.Height = 800;
         AV23window.Width = 1200;
         context.NewWindow(AV23window);
         /*  Sending Event outputs  */
      }

      protected void E152T2( )
      {
         /* 'DoCalcular' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VERIFICARERROS' */
         S122 ();
         if (returnInSub) return;
         if ( ! AV24ExisteErro )
         {
            this.executeUsercontrolMethod("", false, "LOADERRELATORIOHORASTRABALHADASContainer", "Insert", "", new Object[] {});
            AV21ClientId = AV22Socket.gxTpr_Clientid;
            new gerarelatoriohorastrabalhadas(context).executeSubmit(  AV21ClientId,  AV9DataInicio,  AV10DataFim,  AV8VeiculoId) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E112T2( )
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
         AV37GXLvl130 = 0;
         AV38Udparg1 = new buscargamguidusuariologado(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A105VeiculoGAMGUID ,
                                              AV38Udparg1 ,
                                              AV8VeiculoId ,
                                              A98VeiculoId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H002T2 */
         pr_default.execute(0, new Object[] {AV8VeiculoId, AV38Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A105VeiculoGAMGUID = H002T2_A105VeiculoGAMGUID[0];
            A98VeiculoId = H002T2_A98VeiculoId[0];
            A100VeiculoPlaca = H002T2_A100VeiculoPlaca[0];
            AV37GXLvl130 = 1;
            Combo_veiculoid_Selectedtext_set = A100VeiculoPlaca;
            ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedText_set", Combo_veiculoid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV37GXLvl130 == 0 )
         {
            Combo_veiculoid_Selectedtext_set = "";
            ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedText_set", Combo_veiculoid_Selectedtext_set);
         }
         Combo_veiculoid_Selectedvalue_set = ((0==AV8VeiculoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV8VeiculoId), 8, 0)));
         ucCombo_veiculoid.SendProperty(context, "", false, Combo_veiculoid_Internalname, "SelectedValue_set", Combo_veiculoid_Selectedvalue_set);
      }

      protected void E162T2( )
      {
         AV31GXV1 = (int)(nGXsfl_66_idx+GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage);
         if ( AV7SDTRelatorioHorasTrabalhadas.Count >= AV31GXV1 )
         {
            AV7SDTRelatorioHorasTrabalhadas.CurrentItem = ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1));
         }
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         new fixonmessage(context ).execute( ) ;
         if ( StringUtil.StrCmp(AV26NotificationInfo.gxTpr_Id, "RelatorioHorasTrabalhadas_Erro") == 0 )
         {
            GX_msglist.addItem("Não foi encontrado resultado para os parâmetros inseridos.");
            this.executeUsercontrolMethod("", false, "LOADERRELATORIOHORASTRABALHADASContainer", "Remove", "", new Object[] {});
         }
         else if ( StringUtil.StrCmp(AV26NotificationInfo.gxTpr_Id, "RelatorioHorasTrabalhadas_Sucesso") == 0 )
         {
            AV27SDTRelatorioHorasTrabalhadasItem = new SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem(context);
            AV27SDTRelatorioHorasTrabalhadasItem.FromJSonString(AV26NotificationInfo.gxTpr_Message, null);
            AV7SDTRelatorioHorasTrabalhadas.Add(AV27SDTRelatorioHorasTrabalhadasItem, 0);
            gx_BV66 = true;
            this.executeUsercontrolMethod("", false, "LOADERRELATORIOHORASTRABALHADASContainer", "Remove", "", new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTRelatorioHorasTrabalhadas", AV7SDTRelatorioHorasTrabalhadas);
         nGXsfl_66_bak_idx = nGXsfl_66_idx;
         gxgrGridsdtrelatoriohorastrabalhadass_refresh( subGridsdtrelatoriohorastrabalhadass_Rows) ;
         nGXsfl_66_idx = nGXsfl_66_bak_idx;
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_662( ) ;
      }

      protected void S122( )
      {
         /* 'VERIFICARERROS' Routine */
         returnInSub = false;
         AV24ExisteErro = false;
         AssignAttri("", false, "AV24ExisteErro", AV24ExisteErro);
         if ( (DateTime.MinValue==AV9DataInicio) || (DateTime.MinValue==AV10DataFim) )
         {
            AV24ExisteErro = true;
            AssignAttri("", false, "AV24ExisteErro", AV24ExisteErro);
            GX_msglist.addItem("Intervalo de consulta inválido.");
         }
         else if ( AV9DataInicio > AV10DataFim )
         {
            AV24ExisteErro = true;
            AssignAttri("", false, "AV24ExisteErro", AV24ExisteErro);
            GX_msglist.addItem("Intervalo de consulta inválido.");
         }
         else if ( ( DateTimeUtil.TDiff( AV10DataFim, AV9DataInicio) / ( double )( 3600 ) / ( double )( 24 ) ) > 31 )
         {
            AV24ExisteErro = true;
            AssignAttri("", false, "AV24ExisteErro", AV24ExisteErro);
            GX_msglist.addItem("Intervalo de consulta máximo é de 31 dias.");
         }
      }

      protected void wb_table1_39_2T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_66_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatainicio_Internalname, context.localUtil.TToC( AV9DataInicio, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV9DataInicio, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatainicio_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatainicio_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioHorasTrabalhadas.htm");
            GxWebStd.gx_bitmap( context, edtavDatainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RelatorioHorasTrabalhadas.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtdata_Internalname, "<p style='padding-top:8px;padding-left:4px'>até</p>", "", "", lblTxtdata_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 1, "HLP_RelatorioHorasTrabalhadas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatafim_Internalname, "Data Fim", "gx-form-item AttributeDateTimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_66_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatafim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatafim_Internalname, context.localUtil.TToC( AV10DataFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV10DataFim, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatafim_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatafim_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_RelatorioHorasTrabalhadas.htm");
            GxWebStd.gx_bitmap( context, edtavDatafim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatafim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RelatorioHorasTrabalhadas.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_39_2T2e( true) ;
         }
         else
         {
            wb_table1_39_2T2e( false) ;
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
         PA2T2( ) ;
         WS2T2( ) ;
         WE2T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918563488", true, true);
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
         context.AddJavascriptSource("relatoriohorastrabalhadas.js", "?202142918563489", false, true);
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

      protected void SubsflControlProps_662( )
      {
         edtavSdtrelatoriohorastrabalhadas__placa_Internalname = "SDTRELATORIOHORASTRABALHADAS__PLACA_"+sGXsfl_66_idx;
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Internalname = "SDTRELATORIOHORASTRABALHADAS__TEMPOFUNCIONAMENTO_"+sGXsfl_66_idx;
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Internalname = "SDTRELATORIOHORASTRABALHADAS__TEMPOOCIOSO_"+sGXsfl_66_idx;
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Internalname = "SDTRELATORIOHORASTRABALHADAS__DATAHORAINICIAL_"+sGXsfl_66_idx;
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Internalname = "SDTRELATORIOHORASTRABALHADAS__DATAHORAFINAL_"+sGXsfl_66_idx;
      }

      protected void SubsflControlProps_fel_662( )
      {
         edtavSdtrelatoriohorastrabalhadas__placa_Internalname = "SDTRELATORIOHORASTRABALHADAS__PLACA_"+sGXsfl_66_fel_idx;
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Internalname = "SDTRELATORIOHORASTRABALHADAS__TEMPOFUNCIONAMENTO_"+sGXsfl_66_fel_idx;
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Internalname = "SDTRELATORIOHORASTRABALHADAS__TEMPOOCIOSO_"+sGXsfl_66_fel_idx;
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Internalname = "SDTRELATORIOHORASTRABALHADAS__DATAHORAINICIAL_"+sGXsfl_66_fel_idx;
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Internalname = "SDTRELATORIOHORASTRABALHADAS__DATAHORAFINAL_"+sGXsfl_66_fel_idx;
      }

      protected void sendrow_662( )
      {
         SubsflControlProps_662( ) ;
         WB2T0( ) ;
         if ( ( subGridsdtrelatoriohorastrabalhadass_Rows * 1 == 0 ) || ( nGXsfl_66_idx <= subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsdtrelatoriohorastrabalhadassRow = GXWebRow.GetNew(context,GridsdtrelatoriohorastrabalhadassContainer);
            if ( subGridsdtrelatoriohorastrabalhadass_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdtrelatoriohorastrabalhadass_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdtrelatoriohorastrabalhadass_Class, "") != 0 )
               {
                  subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"Odd";
               }
            }
            else if ( subGridsdtrelatoriohorastrabalhadass_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdtrelatoriohorastrabalhadass_Backstyle = 0;
               subGridsdtrelatoriohorastrabalhadass_Backcolor = subGridsdtrelatoriohorastrabalhadass_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdtrelatoriohorastrabalhadass_Class, "") != 0 )
               {
                  subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"Uniform";
               }
            }
            else if ( subGridsdtrelatoriohorastrabalhadass_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdtrelatoriohorastrabalhadass_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdtrelatoriohorastrabalhadass_Class, "") != 0 )
               {
                  subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"Odd";
               }
               subGridsdtrelatoriohorastrabalhadass_Backcolor = (int)(0x0);
            }
            else if ( subGridsdtrelatoriohorastrabalhadass_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdtrelatoriohorastrabalhadass_Backstyle = 1;
               if ( ((int)((nGXsfl_66_idx) % (2))) == 0 )
               {
                  subGridsdtrelatoriohorastrabalhadass_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtrelatoriohorastrabalhadass_Class, "") != 0 )
                  {
                     subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"Even";
                  }
               }
               else
               {
                  subGridsdtrelatoriohorastrabalhadass_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdtrelatoriohorastrabalhadass_Class, "") != 0 )
                  {
                     subGridsdtrelatoriohorastrabalhadass_Linesclass = subGridsdtrelatoriohorastrabalhadass_Class+"Odd";
                  }
               }
            }
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_66_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatoriohorastrabalhadassRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatoriohorastrabalhadas__placa_Internalname,((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1)).gxTpr_Placa,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatoriohorastrabalhadas__placa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatoriohorastrabalhadas__placa_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)7,(short)0,(short)0,(short)66,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatoriohorastrabalhadassRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Internalname,((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1)).gxTpr_Tempofuncionamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)66,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatoriohorastrabalhadassRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatoriohorastrabalhadas__tempoocioso_Internalname,((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1)).gxTpr_Tempoocioso,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatoriohorastrabalhadas__tempoocioso_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)66,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatoriohorastrabalhadassRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatoriohorastrabalhadas__datahorainicial_Internalname,context.localUtil.TToC( ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1)).gxTpr_Datahorainicial, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1)).gxTpr_Datahorainicial, "99/99/9999 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatoriohorastrabalhadas__datahorainicial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)66,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsdtrelatoriohorastrabalhadassContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsdtrelatoriohorastrabalhadassRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtrelatoriohorastrabalhadas__datahorafinal_Internalname,context.localUtil.TToC( ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1)).gxTpr_Datahorafinal, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV7SDTRelatorioHorasTrabalhadas.Item(AV31GXV1)).gxTpr_Datahorafinal, "99/99/9999 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtrelatoriohorastrabalhadas__datahorafinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)66,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2T2( ) ;
            GridsdtrelatoriohorastrabalhadassContainer.AddRow(GridsdtrelatoriohorastrabalhadassRow);
            nGXsfl_66_idx = ((subGridsdtrelatoriohorastrabalhadass_Islastpage==1)&&(nGXsfl_66_idx+1>subGridsdtrelatoriohorastrabalhadass_fnc_Recordsperpage( )) ? 1 : nGXsfl_66_idx+1);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
            SubsflControlProps_662( ) ;
         }
         /* End function sendrow_662 */
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
         bttBtncalcular_Internalname = "BTNCALCULAR";
         divTbldados_Internalname = "TBLDADOS";
         divPanel1_Internalname = "PANEL1";
         Dvpanel_panel1_Internalname = "DVPANEL_PANEL1";
         bttBtnexportpdf_Internalname = "BTNEXPORTPDF";
         divTableexport_Internalname = "TABLEEXPORT";
         Dvpanel_tableexport_Internalname = "DVPANEL_TABLEEXPORT";
         divTablecontent_Internalname = "TABLECONTENT";
         edtavSdtrelatoriohorastrabalhadas__placa_Internalname = "SDTRELATORIOHORASTRABALHADAS__PLACA";
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Internalname = "SDTRELATORIOHORASTRABALHADAS__TEMPOFUNCIONAMENTO";
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Internalname = "SDTRELATORIOHORASTRABALHADAS__TEMPOOCIOSO";
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Internalname = "SDTRELATORIOHORASTRABALHADAS__DATAHORAINICIAL";
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Internalname = "SDTRELATORIOHORASTRABALHADAS__DATAHORAFINAL";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Internalname = "GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR";
         divGridsdtrelatoriohorastrabalhadasstablewithpaginationbar_Internalname = "GRIDSDTRELATORIOHORASTRABALHADASSTABLEWITHPAGINATIONBAR";
         Loaderrelatoriohorastrabalhadas_Internalname = "LOADERRELATORIOHORASTRABALHADAS";
         divUcloader_Internalname = "UCLOADER";
         divTablemain_Internalname = "TABLEMAIN";
         edtavVeiculoid_Internalname = "vVEICULOID";
         Gridsdtrelatoriohorastrabalhadass_empowerer_Internalname = "GRIDSDTRELATORIOHORASTRABALHADASS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridsdtrelatoriohorastrabalhadass_Internalname = "GRIDSDTRELATORIOHORASTRABALHADASS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Jsonclick = "";
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Jsonclick = "";
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Jsonclick = "";
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Jsonclick = "";
         edtavSdtrelatoriohorastrabalhadas__placa_Jsonclick = "";
         edtavDatafim_Jsonclick = "";
         edtavDatafim_Enabled = 1;
         edtavDatainicio_Jsonclick = "";
         edtavDatainicio_Enabled = 1;
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled = -1;
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled = -1;
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled = -1;
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled = -1;
         edtavSdtrelatoriohorastrabalhadas__placa_Enabled = -1;
         edtavVeiculoid_Jsonclick = "";
         edtavVeiculoid_Visible = 1;
         subGridsdtrelatoriohorastrabalhadass_Allowcollapsing = 0;
         subGridsdtrelatoriohorastrabalhadass_Allowselection = 0;
         subGridsdtrelatoriohorastrabalhadass_Header = "";
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__placa_Enabled = 0;
         subGridsdtrelatoriohorastrabalhadass_Class = "GridWithPaginationBar WorkWith";
         subGridsdtrelatoriohorastrabalhadass_Backcolorstyle = 0;
         Combo_veiculoid_Caption = "";
         Loaderrelatoriohorastrabalhadas_Basecolor = (int)(0x08A086);
         Loaderrelatoriohorastrabalhadas_Loader = "2";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridcaption = "Nenhum resultado foi encontrado.";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Next = "WWP_PagingNextCaption";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue = 10;
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingcaptionposition = "Left";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingbuttonsposition = "Right";
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagestoshow = 5;
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Class = "PaginationBar";
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
         Combo_veiculoid_Datalistproc = "RelatorioHorasTrabalhadasLoadDVCombo";
         Combo_veiculoid_Cls = "ExtendedCombo Attribute";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Relatório de Horas Trabalhadas";
         subGridsdtrelatoriohorastrabalhadass_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nEOF'},{av:'AV7SDTRelatorioHorasTrabalhadas',fld:'vSDTRELATORIOHORASTRABALHADAS',grid:66,pic:''},{av:'nRC_GXsfl_66',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'GridRC'},{av:'subGridsdtrelatoriohorastrabalhadass_Rows',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'Rows'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV18GridSDTRelatorioHorasTrabalhadassCurrentPage',fld:'vGRIDSDTRELATORIOHORASTRABALHADASSCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV19GridSDTRelatorioHorasTrabalhadassPageCount',fld:'vGRIDSDTRELATORIOHORASTRABALHADASSPAGECOUNT',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRIDSDTRELATORIOHORASTRABALHADASS.LOAD","{handler:'E192T2',iparms:[]");
         setEventMetadata("GRIDSDTRELATORIOHORASTRABALHADASS.LOAD",",oparms:[]}");
         setEventMetadata("GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR.CHANGEPAGE","{handler:'E122T2',iparms:[{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nEOF'},{av:'AV7SDTRelatorioHorasTrabalhadas',fld:'vSDTRELATORIOHORASTRABALHADAS',grid:66,pic:''},{av:'nRC_GXsfl_66',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'GridRC'},{av:'subGridsdtrelatoriohorastrabalhadass_Rows',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'Rows'},{av:'Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132T2',iparms:[{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage'},{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nEOF'},{av:'AV7SDTRelatorioHorasTrabalhadas',fld:'vSDTRELATORIOHORASTRABALHADAS',grid:66,pic:''},{av:'nRC_GXsfl_66',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'GridRC'},{av:'subGridsdtrelatoriohorastrabalhadass_Rows',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'Rows'},{av:'Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDSDTRELATORIOHORASTRABALHADASSPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGridsdtrelatoriohorastrabalhadass_Rows',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'Rows'}]}");
         setEventMetadata("'DOEXPORTPDF'","{handler:'E142T2',iparms:[{av:'AV7SDTRelatorioHorasTrabalhadas',fld:'vSDTRELATORIOHORASTRABALHADAS',grid:66,pic:''},{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage'},{av:'nRC_GXsfl_66',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'GridRC'}]");
         setEventMetadata("'DOEXPORTPDF'",",oparms:[]}");
         setEventMetadata("'DOCALCULAR'","{handler:'E152T2',iparms:[{av:'AV24ExisteErro',fld:'vEXISTEERRO',pic:''},{av:'AV9DataInicio',fld:'vDATAINICIO',pic:'99/99/99 99:99'},{av:'AV10DataFim',fld:'vDATAFIM',pic:'99/99/99 99:99'},{av:'AV8VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("'DOCALCULAR'",",oparms:[{av:'AV8VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'},{av:'AV10DataFim',fld:'vDATAFIM',pic:'99/99/99 99:99'},{av:'AV9DataInicio',fld:'vDATAINICIO',pic:'99/99/99 99:99'},{av:'AV24ExisteErro',fld:'vEXISTEERRO',pic:''}]}");
         setEventMetadata("COMBO_VEICULOID.ONOPTIONCLICKED","{handler:'E112T2',iparms:[{av:'Combo_veiculoid_Selectedvalue_get',ctrl:'COMBO_VEICULOID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_VEICULOID.ONOPTIONCLICKED",",oparms:[{av:'AV8VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E162T2',iparms:[{av:'AV26NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''},{av:'AV7SDTRelatorioHorasTrabalhadas',fld:'vSDTRELATORIOHORASTRABALHADAS',grid:66,pic:''},{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage'},{av:'nRC_GXsfl_66',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'GridRC'},{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nEOF'},{av:'subGridsdtrelatoriohorastrabalhadass_Rows',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'Rows'}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[{av:'AV7SDTRelatorioHorasTrabalhadas',fld:'vSDTRELATORIOHORASTRABALHADAS',grid:66,pic:''},{av:'GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage'},{av:'nRC_GXsfl_66',ctrl:'GRIDSDTRELATORIOHORASTRABALHADASS',prop:'GridRC'}]}");
         setEventMetadata("VALIDV_DATAINICIO","{handler:'Validv_Datainicio',iparms:[]");
         setEventMetadata("VALIDV_DATAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_DATAFIM","{handler:'Validv_Datafim',iparms:[]");
         setEventMetadata("VALIDV_DATAFIM",",oparms:[]}");
         setEventMetadata("VALIDV_VEICULOID","{handler:'Validv_Veiculoid',iparms:[]");
         setEventMetadata("VALIDV_VEICULOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv6',iparms:[]");
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
         Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage = "";
         Combo_veiculoid_Selectedvalue_get = "";
         AV26NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV7SDTRelatorioHorasTrabalhadas = new GXBaseCollection<SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem>( context, "SDTRelatorioHorasTrabalhadasItem", "RastreamentoTCC");
         AV12DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11VeiculoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV28GridSDTRelatorioHorasTrabalhadassAppliedFilters = "";
         Combo_veiculoid_Selectedvalue_set = "";
         Combo_veiculoid_Selectedtext_set = "";
         Combo_veiculoid_Gamoauthtoken = "";
         Gridsdtrelatoriohorastrabalhadass_empowerer_Gridinternalname = "";
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
         GridsdtrelatoriohorastrabalhadassContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridsdtrelatoriohorastrabalhadass_Linesclass = "";
         GridsdtrelatoriohorastrabalhadassColumn = new GXWebColumn();
         ucGridsdtrelatoriohorastrabalhadasspaginationbar = new GXUserControl();
         ucLoaderrelatoriohorastrabalhadas = new GXUserControl();
         ucGridsdtrelatoriohorastrabalhadass_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9DataInicio = (DateTime)(DateTime.MinValue);
         AV10DataFim = (DateTime)(DateTime.MinValue);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV15GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GridsdtrelatoriohorastrabalhadassRow = new GXWebRow();
         AV21ClientId = "";
         AV22Socket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV20CacheName = "";
         AV23window = new GXWindow();
         AV38Udparg1 = "";
         scmdbuf = "";
         A105VeiculoGAMGUID = "";
         H002T2_A105VeiculoGAMGUID = new string[] {""} ;
         H002T2_A98VeiculoId = new int[1] ;
         H002T2_A100VeiculoPlaca = new string[] {""} ;
         A100VeiculoPlaca = "";
         AV27SDTRelatorioHorasTrabalhadasItem = new SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem(context);
         lblTxtdata_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relatoriohorastrabalhadas__default(),
            new Object[][] {
                new Object[] {
               H002T2_A105VeiculoGAMGUID, H002T2_A98VeiculoId, H002T2_A100VeiculoPlaca
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtrelatoriohorastrabalhadas__placa_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled = 0;
         edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled = 0;
      }

      private short GRIDSDTRELATORIOHORASTRABALHADASS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridsdtrelatoriohorastrabalhadass_Backcolorstyle ;
      private short subGridsdtrelatoriohorastrabalhadass_Titlebackstyle ;
      private short subGridsdtrelatoriohorastrabalhadass_Allowselection ;
      private short subGridsdtrelatoriohorastrabalhadass_Allowhovering ;
      private short subGridsdtrelatoriohorastrabalhadass_Allowcollapsing ;
      private short subGridsdtrelatoriohorastrabalhadass_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV37GXLvl130 ;
      private short nGXWrapped ;
      private short subGridsdtrelatoriohorastrabalhadass_Backstyle ;
      private int Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_66 ;
      private int nGXsfl_66_idx=1 ;
      private int subGridsdtrelatoriohorastrabalhadass_Rows ;
      private int Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagestoshow ;
      private int Loaderrelatoriohorastrabalhadas_Basecolor ;
      private int subGridsdtrelatoriohorastrabalhadass_Titlebackcolor ;
      private int subGridsdtrelatoriohorastrabalhadass_Allbackcolor ;
      private int edtavSdtrelatoriohorastrabalhadas__placa_Enabled ;
      private int edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Enabled ;
      private int edtavSdtrelatoriohorastrabalhadas__tempoocioso_Enabled ;
      private int edtavSdtrelatoriohorastrabalhadas__datahorainicial_Enabled ;
      private int edtavSdtrelatoriohorastrabalhadas__datahorafinal_Enabled ;
      private int subGridsdtrelatoriohorastrabalhadass_Selectedindex ;
      private int subGridsdtrelatoriohorastrabalhadass_Selectioncolor ;
      private int subGridsdtrelatoriohorastrabalhadass_Hoveringcolor ;
      private int AV31GXV1 ;
      private int AV8VeiculoId ;
      private int edtavVeiculoid_Visible ;
      private int subGridsdtrelatoriohorastrabalhadass_Islastpage ;
      private int GRIDSDTRELATORIOHORASTRABALHADASS_nGridOutOfScope ;
      private int nGXsfl_66_fel_idx=1 ;
      private int AV17PageToGo ;
      private int A98VeiculoId ;
      private int nGXsfl_66_bak_idx=1 ;
      private int edtavDatainicio_Enabled ;
      private int edtavDatafim_Enabled ;
      private int idxLst ;
      private int subGridsdtrelatoriohorastrabalhadass_Backcolor ;
      private long GRIDSDTRELATORIOHORASTRABALHADASS_nFirstRecordOnPage ;
      private long AV18GridSDTRelatorioHorasTrabalhadassCurrentPage ;
      private long AV19GridSDTRelatorioHorasTrabalhadassPageCount ;
      private long GRIDSDTRELATORIOHORASTRABALHADASS_nCurrentRecord ;
      private long GRIDSDTRELATORIOHORASTRABALHADASS_nRecordCount ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Selectedpage ;
      private string Combo_veiculoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_66_idx="0001" ;
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
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Class ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingbuttonsposition ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Pagingcaptionposition ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridclass ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageoptions ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Previous ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Next ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Caption ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Emptygridcaption ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpagecaption ;
      private string Loaderrelatoriohorastrabalhadas_Loader ;
      private string Gridsdtrelatoriohorastrabalhadass_empowerer_Gridinternalname ;
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
      private string bttBtncalcular_Internalname ;
      private string bttBtncalcular_Jsonclick ;
      private string Dvpanel_tableexport_Internalname ;
      private string divTableexport_Internalname ;
      private string bttBtnexportpdf_Internalname ;
      private string bttBtnexportpdf_Jsonclick ;
      private string divGridsdtrelatoriohorastrabalhadasstablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridsdtrelatoriohorastrabalhadass_Internalname ;
      private string subGridsdtrelatoriohorastrabalhadass_Class ;
      private string subGridsdtrelatoriohorastrabalhadass_Linesclass ;
      private string subGridsdtrelatoriohorastrabalhadass_Header ;
      private string Gridsdtrelatoriohorastrabalhadasspaginationbar_Internalname ;
      private string divUcloader_Internalname ;
      private string Loaderrelatoriohorastrabalhadas_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavVeiculoid_Internalname ;
      private string edtavVeiculoid_Jsonclick ;
      private string Gridsdtrelatoriohorastrabalhadass_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavDatainicio_Internalname ;
      private string edtavSdtrelatoriohorastrabalhadas__placa_Internalname ;
      private string edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Internalname ;
      private string edtavSdtrelatoriohorastrabalhadas__tempoocioso_Internalname ;
      private string edtavSdtrelatoriohorastrabalhadas__datahorainicial_Internalname ;
      private string edtavSdtrelatoriohorastrabalhadas__datahorafinal_Internalname ;
      private string sGXsfl_66_fel_idx="0001" ;
      private string edtavDatafim_Internalname ;
      private string AV38Udparg1 ;
      private string scmdbuf ;
      private string A105VeiculoGAMGUID ;
      private string tblTablemergeddatainicio_Internalname ;
      private string edtavDatainicio_Jsonclick ;
      private string lblTxtdata_Internalname ;
      private string lblTxtdata_Jsonclick ;
      private string edtavDatafim_Jsonclick ;
      private string ROClassString ;
      private string edtavSdtrelatoriohorastrabalhadas__placa_Jsonclick ;
      private string edtavSdtrelatoriohorastrabalhadas__tempofuncionamento_Jsonclick ;
      private string edtavSdtrelatoriohorastrabalhadas__tempoocioso_Jsonclick ;
      private string edtavSdtrelatoriohorastrabalhadas__datahorainicial_Jsonclick ;
      private string edtavSdtrelatoriohorastrabalhadas__datahorafinal_Jsonclick ;
      private DateTime AV9DataInicio ;
      private DateTime AV10DataFim ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV24ExisteErro ;
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
      private bool Gridsdtrelatoriohorastrabalhadasspaginationbar_Showfirst ;
      private bool Gridsdtrelatoriohorastrabalhadasspaginationbar_Showprevious ;
      private bool Gridsdtrelatoriohorastrabalhadasspaginationbar_Shownext ;
      private bool Gridsdtrelatoriohorastrabalhadasspaginationbar_Showlast ;
      private bool Gridsdtrelatoriohorastrabalhadasspaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_66_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV66 ;
      private string AV28GridSDTRelatorioHorasTrabalhadassAppliedFilters ;
      private string AV21ClientId ;
      private string AV20CacheName ;
      private string A100VeiculoPlaca ;
      private GXWebGrid GridsdtrelatoriohorastrabalhadassContainer ;
      private GXWebRow GridsdtrelatoriohorastrabalhadassRow ;
      private GXWebColumn GridsdtrelatoriohorastrabalhadassColumn ;
      private GXUserControl ucDvpanel_panel1 ;
      private GXUserControl ucCombo_veiculoid ;
      private GXUserControl ucDvpanel_tableexport ;
      private GXUserControl ucGridsdtrelatoriohorastrabalhadasspaginationbar ;
      private GXUserControl ucLoaderrelatoriohorastrabalhadas ;
      private GXUserControl ucGridsdtrelatoriohorastrabalhadass_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H002T2_A105VeiculoGAMGUID ;
      private int[] H002T2_A98VeiculoId ;
      private string[] H002T2_A100VeiculoPlaca ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem> AV7SDTRelatorioHorasTrabalhadas ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11VeiculoId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15GAMErrors ;
      private GXWebForm Form ;
      private GXWindow AV23window ;
      private SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem AV27SDTRelatorioHorasTrabalhadasItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV12DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV14GAMSession ;
      private GeneXus.Core.genexus.server.SdtSocket AV22Socket ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV26NotificationInfo ;
   }

   public class relatoriohorastrabalhadas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002T2( IGxContext context ,
                                             string A105VeiculoGAMGUID ,
                                             string AV38Udparg1 ,
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
            AddWhere(sWhereString, "([VeiculoGAMGUID] = @AV38Udparg1)");
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
                     return conditional_H002T2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
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
          Object[] prmH002T2;
          prmH002T2 = new Object[] {
          new Object[] {"@AV8VeiculoId",SqlDbType.Int,8,0} ,
          new Object[] {"@AV38Udparg1",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("H002T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002T2,1, GxCacheFrequency.OFF ,false,true )
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
