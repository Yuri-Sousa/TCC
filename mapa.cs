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
   public class mapa : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public mapa( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public mapa( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridveiculos") == 0 )
            {
               nRC_GXsfl_32 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_32"), "."));
               nGXsfl_32_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_32_idx"), "."));
               sGXsfl_32_idx = GetPar( "sGXsfl_32_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridveiculos_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridveiculos") == 0 )
            {
               ajax_req_read_hidden_sdt(GetNextPar( ), AV7SDTVeiculosMapa);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridveiculos_refresh( AV7SDTVeiculosMapa) ;
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
            return "mapa_Execute" ;
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
         PA2D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2D2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20215141726718", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("UserControls/MapBoxGLRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mapa.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtveiculosmapa", AV7SDTVeiculosMapa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtveiculosmapa", AV7SDTVeiculosMapa);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_32", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_32), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV39DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVEICULOIDPERCURSO_DATA", AV44VeiculoIdPercurso_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVEICULOIDPERCURSO_DATA", AV44VeiculoIdPercurso_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTVEICULOSMAPA", AV7SDTVeiculosMapa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTVEICULOSMAPA", AV7SDTVeiculosMapa);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISROTANOMAPA", AV33IsRotaNoMapa);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPOLYLINECOLLECTION", AV37PolylineCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPOLYLINECOLLECTION", AV37PolylineCollection);
         }
         GxWebStd.gx_hidden_field( context, "vPONTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14PontosId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPONTOSMAPA", AV12PontosMapa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPONTOSMAPA", AV12PontosMapa);
         }
         GxWebStd.gx_hidden_field( context, "vPLACA", AV25Placa);
         GxWebStd.gx_hidden_field( context, "vIGNICAO", AV26Ignicao);
         GxWebStd.gx_hidden_field( context, "vHORAGPS", context.localUtil.TToC( AV27HoraGPS, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vLATLONG", AV28LatLong);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV18NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV18NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "vHTMLBALAO", AV15HTMLBalao);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTERRORASTREAMENTO", AV45SDTErroRastreamento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTERRORASTREAMENTO", AV45SDTErroRastreamento);
         }
         GxWebStd.gx_hidden_field( context, "MAPA_Mapkey", StringUtil.RTrim( Mapa_Mapkey));
         GxWebStd.gx_hidden_field( context, "MAPA_Height", StringUtil.RTrim( Mapa_Height));
         GxWebStd.gx_hidden_field( context, "MAPA_Adicionarcontrolededesenho", StringUtil.RTrim( Mapa_Adicionarcontrolededesenho));
         GxWebStd.gx_hidden_field( context, "MAPA_Utilizarcontroledistancia", StringUtil.RTrim( Mapa_Utilizarcontroledistancia));
         GxWebStd.gx_hidden_field( context, "MAPA_Utilizarcontrolerota", StringUtil.RTrim( Mapa_Utilizarcontrolerota));
         GxWebStd.gx_hidden_field( context, "MAPA_Utilizarmenumapa", StringUtil.RTrim( Mapa_Utilizarmenumapa));
         GxWebStd.gx_hidden_field( context, "MAPA_Tablemenuinternalname", StringUtil.RTrim( Mapa_Tablemenuinternalname));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Cls", StringUtil.RTrim( Combo_veiculoidpercurso_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Selectedvalue_set", StringUtil.RTrim( Combo_veiculoidpercurso_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Selectedtext_set", StringUtil.RTrim( Combo_veiculoidpercurso_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Gamoauthtoken", StringUtil.RTrim( Combo_veiculoidpercurso_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Datalistproc", StringUtil.RTrim( Combo_veiculoidpercurso_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_veiculoidpercurso_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Width", StringUtil.RTrim( Dvpanel_cardpercurso_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Autowidth", StringUtil.BoolToStr( Dvpanel_cardpercurso_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Autoheight", StringUtil.BoolToStr( Dvpanel_cardpercurso_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Cls", StringUtil.RTrim( Dvpanel_cardpercurso_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Title", StringUtil.RTrim( Dvpanel_cardpercurso_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Collapsible", StringUtil.BoolToStr( Dvpanel_cardpercurso_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Collapsed", StringUtil.BoolToStr( Dvpanel_cardpercurso_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardpercurso_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Iconposition", StringUtil.RTrim( Dvpanel_cardpercurso_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDPERCURSO_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardpercurso_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABMENUMAPA_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabmenumapa_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABMENUMAPA_Class", StringUtil.RTrim( Gxuitabspanel_tabmenumapa_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABMENUMAPA_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabmenumapa_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Selectedvalue_get", StringUtil.RTrim( Combo_veiculoidpercurso_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_Message", AV18NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, "BTNGERARPERCURSO_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttBtngerarpercurso_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "BTNGERARPERCURSO_Caption", StringUtil.RTrim( bttBtngerarpercurso_Caption));
         GxWebStd.gx_hidden_field( context, "COMBO_VEICULOIDPERCURSO_Selectedvalue_get", StringUtil.RTrim( Combo_veiculoidpercurso_Selectedvalue_get));
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
            WE2D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2D2( ) ;
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
         return formatLink("mapa.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Mapa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Mapa" ;
      }

      protected void WB2D0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucMapa.SetProperty("MapKey", Mapa_Mapkey);
            ucMapa.SetProperty("Height", Mapa_Height);
            ucMapa.SetProperty("AdicionarControleDeDesenho", Mapa_Adicionarcontrolededesenho);
            ucMapa.SetProperty("UtilizarControleDistancia", Mapa_Utilizarcontroledistancia);
            ucMapa.SetProperty("UtilizarControleRota", Mapa_Utilizarcontrolerota);
            ucMapa.SetProperty("UtilizarMenuMapa", Mapa_Utilizarmenumapa);
            ucMapa.Render(context, "mapboxgl", Mapa_Internalname, "MAPAContainer");
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
            GxWebStd.gx_div_start( context, divTablemenumapa_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabmenumapa.SetProperty("PageCount", Gxuitabspanel_tabmenumapa_Pagecount);
            ucGxuitabspanel_tabmenumapa.SetProperty("Class", Gxuitabspanel_tabmenumapa_Class);
            ucGxuitabspanel_tabmenumapa.SetProperty("HistoryManagement", Gxuitabspanel_tabmenumapa_Historymanagement);
            ucGxuitabspanel_tabmenumapa.Render(context, "tab", Gxuitabspanel_tabmenumapa_Internalname, "GXUITABSPANEL_TABMENUMAPAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABMENUMAPAContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabveiculo_title_Internalname, "Veículos", "", "", lblTabveiculo_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Mapa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabVeiculo") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABMENUMAPAContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblveiculos_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblveiculo_Internalname, 1, 0, "px", 0, "px", "TCCPaddingTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridveiculosContainer.SetIsFreestyle(true);
            GridveiculosContainer.SetWrapped(nGXWrapped);
            if ( GridveiculosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridveiculosContainer"+"DivS\" data-gxgridid=\"32\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridveiculos_Internalname, subGridveiculos_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridveiculosContainer.AddObjectProperty("GridName", "Gridveiculos");
            }
            else
            {
               GridveiculosContainer.AddObjectProperty("GridName", "Gridveiculos");
               GridveiculosContainer.AddObjectProperty("Header", subGridveiculos_Header);
               GridveiculosContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridveiculosContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridveiculosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Backcolorstyle), 1, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("CmpContext", "");
               GridveiculosContainer.AddObjectProperty("InMasterPage", "false");
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtveiculosmapa__veiculoid_Visible), 5, 0, ".", "")));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridveiculosColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtveiculosmapa__ignicao_Visible), 5, 0, ".", "")));
               GridveiculosContainer.AddColumnProperties(GridveiculosColumn);
               GridveiculosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Selectedindex), 4, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Allowselection), 1, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Selectioncolor), 9, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Allowhovering), 1, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Hoveringcolor), 9, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Allowcollapsing), 1, 0, ".", "")));
               GridveiculosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 32 )
         {
            wbEnd = 0;
            nRC_GXsfl_32 = (int)(nGXsfl_32_idx-1);
            if ( GridveiculosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV49GXV1 = nGXsfl_32_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridveiculosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridveiculos", GridveiculosContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridveiculosContainerData", GridveiculosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridveiculosContainerData"+"V", GridveiculosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridveiculosContainerData"+"V"+"\" value='"+GridveiculosContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABMENUMAPAContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabtrajetos_title_Internalname, "Trajetos", "", "", lblTabtrajetos_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Mapa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabTrajetos") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABMENUMAPAContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbltrajetos_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbltrajeto_Internalname, 1, 0, "px", 0, "px", "TCCPaddingTopMarginLeft", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardpercurso.SetProperty("Width", Dvpanel_cardpercurso_Width);
            ucDvpanel_cardpercurso.SetProperty("AutoWidth", Dvpanel_cardpercurso_Autowidth);
            ucDvpanel_cardpercurso.SetProperty("AutoHeight", Dvpanel_cardpercurso_Autoheight);
            ucDvpanel_cardpercurso.SetProperty("Cls", Dvpanel_cardpercurso_Cls);
            ucDvpanel_cardpercurso.SetProperty("Title", Dvpanel_cardpercurso_Title);
            ucDvpanel_cardpercurso.SetProperty("Collapsible", Dvpanel_cardpercurso_Collapsible);
            ucDvpanel_cardpercurso.SetProperty("Collapsed", Dvpanel_cardpercurso_Collapsed);
            ucDvpanel_cardpercurso.SetProperty("ShowCollapseIcon", Dvpanel_cardpercurso_Showcollapseicon);
            ucDvpanel_cardpercurso.SetProperty("IconPosition", Dvpanel_cardpercurso_Iconposition);
            ucDvpanel_cardpercurso.SetProperty("AutoScroll", Dvpanel_cardpercurso_Autoscroll);
            ucDvpanel_cardpercurso.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardpercurso_Internalname, "DVPANEL_CARDPERCURSOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDPERCURSOContainer"+"CardPercurso"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardpercurso_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop ExtendedComboCell", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedveiculoidpercurso_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_veiculoidpercurso_Internalname, "Placa", "", "", lblTextblockcombo_veiculoidpercurso_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_veiculoidpercurso.SetProperty("Caption", Combo_veiculoidpercurso_Caption);
            ucCombo_veiculoidpercurso.SetProperty("Cls", Combo_veiculoidpercurso_Cls);
            ucCombo_veiculoidpercurso.SetProperty("DataListProc", Combo_veiculoidpercurso_Datalistproc);
            ucCombo_veiculoidpercurso.SetProperty("DataListProcParametersPrefix", Combo_veiculoidpercurso_Datalistprocparametersprefix);
            ucCombo_veiculoidpercurso.SetProperty("DropDownOptionsTitleSettingsIcons", AV39DDO_TitleSettingsIcons);
            ucCombo_veiculoidpercurso.SetProperty("DropDownOptionsData", AV44VeiculoIdPercurso_Data);
            ucCombo_veiculoidpercurso.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_veiculoidpercurso_Internalname, "COMBO_VEICULOIDPERCURSOContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledatainiciopercurso_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdatainiciopercurso_Internalname, "Data Início - Percurso", "", "", lblTextblockdatainiciopercurso_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatainiciopercurso_Internalname, "Data Inicio Percurso", "col-sm-3 AttributeDateTimeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_32_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatainiciopercurso_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatainiciopercurso_Internalname, context.localUtil.TToC( AV30DataInicioPercurso, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV30DataInicioPercurso, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatainiciopercurso_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatainiciopercurso_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Mapa.htm");
            GxWebStd.gx_bitmap( context, edtavDatainiciopercurso_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatainiciopercurso_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Mapa.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledatafimpercurso_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdatafimpercurso_Internalname, "Data Fim - Percurso", "", "", lblTextblockdatafimpercurso_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatafimpercurso_Internalname, "Data Fim Percurso", "col-sm-3 AttributeDateTimeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_32_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatafimpercurso_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatafimpercurso_Internalname, context.localUtil.TToC( AV31DataFimPercurso, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV31DataFimPercurso, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatafimpercurso_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtavDatafimpercurso_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Mapa.htm");
            GxWebStd.gx_bitmap( context, edtavDatafimpercurso_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatafimpercurso_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Mapa.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebotoes_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngerarpercurso_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(32), 2, 0)+","+"null"+");", bttBtngerarpercurso_Caption, bttBtngerarpercurso_Jsonclick, 5, "Gerar", "", StyleString, ClassString, 1, bttBtngerarpercurso_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOGERARPERCURSO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnlimparpercurso_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(32), 2, 0)+","+"null"+");", "Limpar", bttBtnlimparpercurso_Jsonclick, 5, "Limpar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOLIMPARPERCURSO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", "", "flex-grow:1;", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Animar Percurso", 1, 0, "px", 0, "px", "Group", "", "HLP_Mapa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGroupanimacao_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableicons_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIconreset_Internalname, "<i class=\"fas fa-undo-alt\"></i>", "", "", lblIconreset_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112d1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblIconplay_Internalname, "<i class=\"fas fa-play-circle\"></i>", "", "", lblIconplay_Jsonclick, "'"+""+"'"+",false,"+"'"+"e122d1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_32_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVeiculoidpercurso_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43VeiculoIdPercurso), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43VeiculoIdPercurso), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVeiculoidpercurso_Jsonclick, 0, "Attribute", "", "", "", "", edtavVeiculoidpercurso_Visible, 1, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Mapa.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 32 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridveiculosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV49GXV1 = nGXsfl_32_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridveiculosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridveiculos", GridveiculosContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridveiculosContainerData", GridveiculosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridveiculosContainerData"+"V", GridveiculosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridveiculosContainerData"+"V"+"\" value='"+GridveiculosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2D2( )
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
            Form.Meta.addItem("description", "Mapa", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2D0( ) ;
      }

      protected void WS2D2( )
      {
         START2D2( ) ;
         EVT2D2( ) ;
      }

      protected void EVT2D2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_VEICULOIDPERCURSO.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E132D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGERARPERCURSO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoGerarPercurso' */
                              E142D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLIMPARPERCURSO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLimparPercurso' */
                              E152D2 ();
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
                              E162D2 ();
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "GRIDVEICULOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "ICONVISUALIZAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "ICONVISUALIZAR.CLICK") == 0 ) )
                           {
                              nGXsfl_32_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
                              SubsflControlProps_322( ) ;
                              GXCCtl = "DVPANEL_CARDVEICULO_Width_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Width = cgiGet( GXCCtl);
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "Width", Dvpanel_cardveiculo_Width);
                              GXCCtl = "DVPANEL_CARDVEICULO_Autowidth_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Autowidth = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "AutoWidth", StringUtil.BoolToStr( Dvpanel_cardveiculo_Autowidth));
                              GXCCtl = "DVPANEL_CARDVEICULO_Autoheight_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Autoheight = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "AutoHeight", StringUtil.BoolToStr( Dvpanel_cardveiculo_Autoheight));
                              GXCCtl = "DVPANEL_CARDVEICULO_Cls_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Cls = cgiGet( GXCCtl);
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "Cls", Dvpanel_cardveiculo_Cls);
                              GXCCtl = "DVPANEL_CARDVEICULO_Title_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Title = cgiGet( GXCCtl);
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "Title", Dvpanel_cardveiculo_Title);
                              GXCCtl = "DVPANEL_CARDVEICULO_Collapsible_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Collapsible = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "Collapsible", StringUtil.BoolToStr( Dvpanel_cardveiculo_Collapsible));
                              GXCCtl = "DVPANEL_CARDVEICULO_Collapsed_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Collapsed = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "Collapsed", StringUtil.BoolToStr( Dvpanel_cardveiculo_Collapsed));
                              GXCCtl = "DVPANEL_CARDVEICULO_Showcollapseicon_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Showcollapseicon = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "ShowCollapseIcon", StringUtil.BoolToStr( Dvpanel_cardveiculo_Showcollapseicon));
                              GXCCtl = "DVPANEL_CARDVEICULO_Iconposition_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Iconposition = cgiGet( GXCCtl);
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "IconPosition", Dvpanel_cardveiculo_Iconposition);
                              GXCCtl = "DVPANEL_CARDVEICULO_Autoscroll_" + sGXsfl_32_idx;
                              Dvpanel_cardveiculo_Autoscroll = StringUtil.StrToBool( cgiGet( GXCCtl));
                              ucDvpanel_cardveiculo.SendProperty(context, "", false, Dvpanel_cardveiculo_Internalname, "AutoScroll", StringUtil.BoolToStr( Dvpanel_cardveiculo_Autoscroll));
                              AV49GXV1 = nGXsfl_32_idx;
                              if ( ( AV7SDTVeiculosMapa.Count >= AV49GXV1 ) && ( AV49GXV1 > 0 ) )
                              {
                                 AV7SDTVeiculosMapa.CurrentItem = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1));
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
                                    E172D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDVEICULOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E182D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ICONVISUALIZAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E162D2 ();
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
                                    E162D2 ();
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

      protected void WE2D2( )
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

      protected void PA2D2( )
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
               GX_FocusControl = edtavDatainiciopercurso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridveiculos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_322( ) ;
         while ( nGXsfl_32_idx <= nRC_GXsfl_32 )
         {
            sendrow_322( ) ;
            nGXsfl_32_idx = ((subGridveiculos_Islastpage==1)&&(nGXsfl_32_idx+1>subGridveiculos_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_322( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridveiculosContainer)) ;
         /* End function gxnrGridveiculos_newrow */
      }

      protected void gxgrGridveiculos_refresh( GXBaseCollection<SdtSDTVeiculosMapa_SDTVeiculosMapaItem> AV7SDTVeiculosMapa )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDVEICULOS_nCurrentRecord = 0;
         RF2D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridveiculos_refresh */
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
         RF2D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtveiculosmapa__placa_Enabled = 0;
         AssignProp("", false, edtavSdtveiculosmapa__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtveiculosmapa__placa_Enabled), 5, 0), !bGXsfl_32_Refreshing);
         edtavSdtveiculosmapa__marcamodelo_Enabled = 0;
         AssignProp("", false, edtavSdtveiculosmapa__marcamodelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtveiculosmapa__marcamodelo_Enabled), 5, 0), !bGXsfl_32_Refreshing);
      }

      protected void RF2D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridveiculosContainer.ClearRows();
         }
         wbStart = 32;
         nGXsfl_32_idx = 1;
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_322( ) ;
         bGXsfl_32_Refreshing = true;
         GridveiculosContainer.AddObjectProperty("GridName", "Gridveiculos");
         GridveiculosContainer.AddObjectProperty("CmpContext", "");
         GridveiculosContainer.AddObjectProperty("InMasterPage", "false");
         GridveiculosContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridveiculosContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridveiculosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridveiculosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridveiculosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridveiculos_Backcolorstyle), 1, 0, ".", "")));
         GridveiculosContainer.PageSize = subGridveiculos_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_322( ) ;
            E182D2 ();
            wbEnd = 32;
            WB2D0( ) ;
         }
         bGXsfl_32_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2D2( )
      {
      }

      protected int subGridveiculos_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridveiculos_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridveiculos_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridveiculos_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSdtveiculosmapa__placa_Enabled = 0;
         AssignProp("", false, edtavSdtveiculosmapa__placa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtveiculosmapa__placa_Enabled), 5, 0), !bGXsfl_32_Refreshing);
         edtavSdtveiculosmapa__marcamodelo_Enabled = 0;
         AssignProp("", false, edtavSdtveiculosmapa__marcamodelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtveiculosmapa__marcamodelo_Enabled), 5, 0), !bGXsfl_32_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E172D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtveiculosmapa"), AV7SDTVeiculosMapa);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV39DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vVEICULOIDPERCURSO_DATA"), AV44VeiculoIdPercurso_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV18NotificationInfo);
            ajax_req_read_hidden_sdt(cgiGet( "vPOLYLINECOLLECTION"), AV37PolylineCollection);
            /* Read saved values. */
            nRC_GXsfl_32 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_32"), ",", "."));
            AV33IsRotaNoMapa = StringUtil.StrToBool( cgiGet( "vISROTANOMAPA"));
            Mapa_Mapkey = cgiGet( "MAPA_Mapkey");
            Mapa_Height = cgiGet( "MAPA_Height");
            Mapa_Adicionarcontrolededesenho = cgiGet( "MAPA_Adicionarcontrolededesenho");
            Mapa_Utilizarcontroledistancia = cgiGet( "MAPA_Utilizarcontroledistancia");
            Mapa_Utilizarcontrolerota = cgiGet( "MAPA_Utilizarcontrolerota");
            Mapa_Utilizarmenumapa = cgiGet( "MAPA_Utilizarmenumapa");
            Mapa_Tablemenuinternalname = cgiGet( "MAPA_Tablemenuinternalname");
            Combo_veiculoidpercurso_Cls = cgiGet( "COMBO_VEICULOIDPERCURSO_Cls");
            Combo_veiculoidpercurso_Selectedvalue_set = cgiGet( "COMBO_VEICULOIDPERCURSO_Selectedvalue_set");
            Combo_veiculoidpercurso_Selectedtext_set = cgiGet( "COMBO_VEICULOIDPERCURSO_Selectedtext_set");
            Combo_veiculoidpercurso_Gamoauthtoken = cgiGet( "COMBO_VEICULOIDPERCURSO_Gamoauthtoken");
            Combo_veiculoidpercurso_Datalistproc = cgiGet( "COMBO_VEICULOIDPERCURSO_Datalistproc");
            Combo_veiculoidpercurso_Datalistprocparametersprefix = cgiGet( "COMBO_VEICULOIDPERCURSO_Datalistprocparametersprefix");
            Dvpanel_cardpercurso_Width = cgiGet( "DVPANEL_CARDPERCURSO_Width");
            Dvpanel_cardpercurso_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDPERCURSO_Autowidth"));
            Dvpanel_cardpercurso_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDPERCURSO_Autoheight"));
            Dvpanel_cardpercurso_Cls = cgiGet( "DVPANEL_CARDPERCURSO_Cls");
            Dvpanel_cardpercurso_Title = cgiGet( "DVPANEL_CARDPERCURSO_Title");
            Dvpanel_cardpercurso_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDPERCURSO_Collapsible"));
            Dvpanel_cardpercurso_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDPERCURSO_Collapsed"));
            Dvpanel_cardpercurso_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDPERCURSO_Showcollapseicon"));
            Dvpanel_cardpercurso_Iconposition = cgiGet( "DVPANEL_CARDPERCURSO_Iconposition");
            Dvpanel_cardpercurso_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDPERCURSO_Autoscroll"));
            Gxuitabspanel_tabmenumapa_Pagecount = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABMENUMAPA_Pagecount"), ",", "."));
            Gxuitabspanel_tabmenumapa_Class = cgiGet( "GXUITABSPANEL_TABMENUMAPA_Class");
            Gxuitabspanel_tabmenumapa_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABMENUMAPA_Historymanagement"));
            bttBtngerarpercurso_Enabled = (int)(context.localUtil.CToN( cgiGet( "BTNGERARPERCURSO_Enabled"), ",", "."));
            bttBtngerarpercurso_Caption = cgiGet( "BTNGERARPERCURSO_Caption");
            Combo_veiculoidpercurso_Selectedvalue_get = cgiGet( "COMBO_VEICULOIDPERCURSO_Selectedvalue_get");
            nRC_GXsfl_32 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_32"), ",", "."));
            nGXsfl_32_fel_idx = 0;
            while ( nGXsfl_32_fel_idx < nRC_GXsfl_32 )
            {
               nGXsfl_32_fel_idx = ((subGridveiculos_Islastpage==1)&&(nGXsfl_32_fel_idx+1>subGridveiculos_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_fel_idx+1);
               sGXsfl_32_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_322( ) ;
               GXCCtl = "DVPANEL_CARDVEICULO_Width_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Width = cgiGet( GXCCtl);
               GXCCtl = "DVPANEL_CARDVEICULO_Autowidth_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Autowidth = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "DVPANEL_CARDVEICULO_Autoheight_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Autoheight = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "DVPANEL_CARDVEICULO_Cls_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Cls = cgiGet( GXCCtl);
               GXCCtl = "DVPANEL_CARDVEICULO_Title_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Title = cgiGet( GXCCtl);
               GXCCtl = "DVPANEL_CARDVEICULO_Collapsible_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Collapsible = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "DVPANEL_CARDVEICULO_Collapsed_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Collapsed = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "DVPANEL_CARDVEICULO_Showcollapseicon_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Showcollapseicon = StringUtil.StrToBool( cgiGet( GXCCtl));
               GXCCtl = "DVPANEL_CARDVEICULO_Iconposition_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Iconposition = cgiGet( GXCCtl);
               GXCCtl = "DVPANEL_CARDVEICULO_Autoscroll_" + sGXsfl_32_fel_idx;
               Dvpanel_cardveiculo_Autoscroll = StringUtil.StrToBool( cgiGet( GXCCtl));
               AV49GXV1 = nGXsfl_32_fel_idx;
               if ( ( AV7SDTVeiculosMapa.Count >= AV49GXV1 ) && ( AV49GXV1 > 0 ) )
               {
                  AV7SDTVeiculosMapa.CurrentItem = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1));
               }
            }
            if ( nGXsfl_32_fel_idx == 0 )
            {
               nGXsfl_32_idx = 1;
               sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
               SubsflControlProps_322( ) ;
            }
            nGXsfl_32_fel_idx = 1;
            /* Read variables values. */
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatainiciopercurso_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Inicio Percurso"}), 1, "vDATAINICIOPERCURSO");
               GX_FocusControl = edtavDatainiciopercurso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30DataInicioPercurso = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV30DataInicioPercurso", context.localUtil.TToC( AV30DataInicioPercurso, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV30DataInicioPercurso = context.localUtil.CToT( cgiGet( edtavDatainiciopercurso_Internalname));
               AssignAttri("", false, "AV30DataInicioPercurso", context.localUtil.TToC( AV30DataInicioPercurso, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatafimpercurso_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Fim Percurso"}), 1, "vDATAFIMPERCURSO");
               GX_FocusControl = edtavDatafimpercurso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31DataFimPercurso = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV31DataFimPercurso", context.localUtil.TToC( AV31DataFimPercurso, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV31DataFimPercurso = context.localUtil.CToT( cgiGet( edtavDatafimpercurso_Internalname));
               AssignAttri("", false, "AV31DataFimPercurso", context.localUtil.TToC( AV31DataFimPercurso, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVeiculoidpercurso_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVeiculoidpercurso_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVEICULOIDPERCURSO");
               GX_FocusControl = edtavVeiculoidpercurso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43VeiculoIdPercurso = 0;
               AssignAttri("", false, "AV43VeiculoIdPercurso", StringUtil.LTrimStr( (decimal)(AV43VeiculoIdPercurso), 8, 0));
            }
            else
            {
               AV43VeiculoIdPercurso = (int)(context.localUtil.CToN( cgiGet( edtavVeiculoidpercurso_Internalname), ",", "."));
               AssignAttri("", false, "AV43VeiculoIdPercurso", StringUtil.LTrimStr( (decimal)(AV43VeiculoIdPercurso), 8, 0));
            }
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
         E172D2 ();
         if (returnInSub) return;
      }

      protected void E172D2( )
      {
         /* Start Routine */
         returnInSub = false;
         Mapa_Tablemenuinternalname = divTablemenumapa_Internalname;
         ucMapa.SendProperty(context, "", false, Mapa_Internalname, "TableMenuInternalName", Mapa_Tablemenuinternalname);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV39DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV39DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV42GAMErrors);
         Combo_veiculoidpercurso_Gamoauthtoken = AV41GAMSession.gxTpr_Token;
         ucCombo_veiculoidpercurso.SendProperty(context, "", false, Combo_veiculoidpercurso_Internalname, "GAMOAuthToken", Combo_veiculoidpercurso_Gamoauthtoken);
         edtavVeiculoidpercurso_Visible = 0;
         AssignProp("", false, edtavVeiculoidpercurso_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVeiculoidpercurso_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOVEICULOIDPERCURSO' */
         S112 ();
         if (returnInSub) return;
         edtavSdtveiculosmapa__veiculoid_Visible = 0;
         AssignProp("", false, edtavSdtveiculosmapa__veiculoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtveiculosmapa__veiculoid_Visible), 5, 0), !bGXsfl_32_Refreshing);
         edtavSdtveiculosmapa__ignicao_Visible = 0;
         AssignProp("", false, edtavSdtveiculosmapa__ignicao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtveiculosmapa__ignicao_Visible), 5, 0), !bGXsfl_32_Refreshing);
         this.executeUsercontrolMethod("", false, "MAPAContainer", "Resize", "", new Object[] {});
         AV12PontosMapa = new GXBaseCollection<SdtPontosMapa_PontosMapaItem>( context, "PontosMapaItem", "RastreamentoTCC");
         AV14PontosId = 0;
         AssignAttri("", false, "AV14PontosId", StringUtil.LTrimStr( (decimal)(AV14PontosId), 8, 0));
         /* Execute user subroutine: 'BUSCARVEICULOS' */
         S122 ();
         if (returnInSub) return;
      }

      private void E182D2( )
      {
         /* Gridveiculos_Load Routine */
         returnInSub = false;
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV7SDTVeiculosMapa.Count )
         {
            AV7SDTVeiculosMapa.CurrentItem = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1));
            if ( StringUtil.StrCmp(((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Ignicao, "ON") == 0 )
            {
               lblIconignicao_Caption = "<i class='fas fa-power-off' style='float:right;color:lime;margin-left:10px;font-size: 25px'></i>";
            }
            else
            {
               lblIconignicao_Caption = "<i class='fas fa-power-off' style='float:right;color:gray;margin-left:10px;font-size: 25px'></i>";
            }
            if ( StringUtil.StrCmp(((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Veiculotipo, "Carro") == 0 )
            {
               lblIconcar_Caption = "<i class='fas fa-car' style='color:gray;margin-right:10px;font-size: 25px'></i>";
            }
            else if ( StringUtil.StrCmp(((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Veiculotipo, "Moto") == 0 )
            {
               lblIconcar_Caption = "<i class='fas fa-motorcycle' style='color:gray;margin-right:10px;font-size: 25px'></i>";
            }
            else if ( StringUtil.StrCmp(((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Veiculotipo, "Caminhão") == 0 )
            {
               lblIconcar_Caption = "<i class='fas fa-truck' style='color:gray;margin-right:10px;font-size: 25px'></i>";
            }
            else
            {
               lblIconcar_Caption = "<i class='fas fa-car' style='color:gray;margin-right:10px;font-size: 25px'></i>";
            }
            if ( ! ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Isvisible )
            {
               lblIconvisualizar_Caption = "<i class='fas fa-eye-slash' style='float:right;color:gray;margin-left:10px;font-size: 25px'></i>";
            }
            else
            {
               lblIconvisualizar_Caption = "<i class='fas fa-eye' style='float:right;color:gray;margin-left:10px;font-size: 25px'></i>";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 32;
            }
            sendrow_322( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_32_Refreshing )
            {
               context.DoAjaxLoad(32, GridveiculosRow);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E142D2( )
      {
         /* 'DoGerarPercurso' Routine */
         returnInSub = false;
         if ( (0==AV43VeiculoIdPercurso) )
         {
            GX_msglist.addItem("Informe a placa do veículo");
         }
         else if ( (DateTime.MinValue==AV30DataInicioPercurso) )
         {
            GX_msglist.addItem("Informe a data de início do percurso");
         }
         else if ( (DateTime.MinValue==AV31DataFimPercurso) )
         {
            GX_msglist.addItem("Informe a data de fim do percurso");
         }
         else
         {
            if ( AV30DataInicioPercurso > AV31DataFimPercurso )
            {
               GX_msglist.addItem("Informe a data de início do percurso deve ser menor que a data de fim");
            }
            else
            {
               AV37PolylineCollection.Clear();
               AV33IsRotaNoMapa = false;
               AssignAttri("", false, "AV33IsRotaNoMapa", AV33IsRotaNoMapa);
               AV32IsAnimacaoIniciada = false;
               AV35ClientIdSocket = AV36Socket.gxTpr_Clientid;
               new buscapercursoveiculo(context).executeSubmit(  AV43VeiculoIdPercurso,  AV30DataInicioPercurso,  AV31DataFimPercurso,  AV35ClientIdSocket) ;
               bttBtngerarpercurso_Caption = "Gerando...";
               AssignProp("", false, bttBtngerarpercurso_Internalname, "Caption", bttBtngerarpercurso_Caption, true);
               bttBtngerarpercurso_Enabled = 0;
               AssignProp("", false, bttBtngerarpercurso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtngerarpercurso_Enabled), 5, 0), true);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37PolylineCollection", AV37PolylineCollection);
      }

      protected void E152D2( )
      {
         /* 'DoLimparPercurso' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "MAPAContainer", "LimpaRotaMapa", "", new Object[] {});
         AV37PolylineCollection.Clear();
         AV33IsRotaNoMapa = false;
         AssignAttri("", false, "AV33IsRotaNoMapa", AV33IsRotaNoMapa);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37PolylineCollection", AV37PolylineCollection);
      }

      protected void E132D2( )
      {
         /* Combo_veiculoidpercurso_Onoptionclicked Routine */
         returnInSub = false;
         AV43VeiculoIdPercurso = (int)(NumberUtil.Val( Combo_veiculoidpercurso_Selectedvalue_get, "."));
         AssignAttri("", false, "AV43VeiculoIdPercurso", StringUtil.LTrimStr( (decimal)(AV43VeiculoIdPercurso), 8, 0));
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOVEICULOIDPERCURSO' Routine */
         returnInSub = false;
         AV54GXLvl176 = 0;
         AV55Udparg1 = new buscargamguidusuariologado(context).executeUdp( );
         /* Using cursor H002D2 */
         pr_default.execute(0, new Object[] {AV43VeiculoIdPercurso, AV55Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A105VeiculoGAMGUID = H002D2_A105VeiculoGAMGUID[0];
            A98VeiculoId = H002D2_A98VeiculoId[0];
            A100VeiculoPlaca = H002D2_A100VeiculoPlaca[0];
            AV54GXLvl176 = 1;
            Combo_veiculoidpercurso_Selectedtext_set = A100VeiculoPlaca;
            ucCombo_veiculoidpercurso.SendProperty(context, "", false, Combo_veiculoidpercurso_Internalname, "SelectedText_set", Combo_veiculoidpercurso_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV54GXLvl176 == 0 )
         {
            Combo_veiculoidpercurso_Selectedtext_set = "";
            ucCombo_veiculoidpercurso.SendProperty(context, "", false, Combo_veiculoidpercurso_Internalname, "SelectedText_set", Combo_veiculoidpercurso_Selectedtext_set);
         }
         Combo_veiculoidpercurso_Selectedvalue_set = ((0==AV43VeiculoIdPercurso) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV43VeiculoIdPercurso), 8, 0)));
         ucCombo_veiculoidpercurso.SendProperty(context, "", false, Combo_veiculoidpercurso_Internalname, "SelectedValue_set", Combo_veiculoidpercurso_Selectedvalue_set);
      }

      protected void E192D2( )
      {
         AV49GXV1 = nGXsfl_32_idx;
         if ( AV7SDTVeiculosMapa.Count >= AV49GXV1 )
         {
            AV7SDTVeiculosMapa.CurrentItem = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1));
         }
         /* Iconvisualizar_Click Routine */
         returnInSub = false;
         AV14PontosId = (int)(AV14PontosId+1);
         AssignAttri("", false, "AV14PontosId", StringUtil.LTrimStr( (decimal)(AV14PontosId), 8, 0));
         AV15HTMLBalao = "<div>teste</div>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         if ( ! ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Isvisible )
         {
            ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Isvisible = true;
            AV13PontosMapaItem = new SdtPontosMapa_PontosMapaItem(context);
            AV13PontosMapaItem.gxTpr_Pontosid = AV14PontosId;
            AV13PontosMapaItem.gxTpr_Utilizarconteudobalaohtml = true;
            AV25Placa = StringUtil.Trim( StringUtil.Upper( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Placa));
            AssignAttri("", false, "AV25Placa", AV25Placa);
            AV26Ignicao = StringUtil.Trim( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Ignicao);
            AssignAttri("", false, "AV26Ignicao", AV26Ignicao);
            AV27HoraGPS = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Horagps;
            AssignAttri("", false, "AV27HoraGPS", context.localUtil.TToC( AV27HoraGPS, 8, 5, 0, 3, "/", ":", " "));
            AV28LatLong = StringUtil.Trim( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Latlong);
            AssignAttri("", false, "AV28LatLong", AV28LatLong);
            /* Execute user subroutine: 'PREENCHERHTML' */
            S132 ();
            if (returnInSub) return;
            AV13PontosMapaItem.gxTpr_Conteudobalaohtml = AV15HTMLBalao;
            AV13PontosMapaItem.gxTpr_Pontoslatitude = StringUtil.StringReplace( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Latitude, ",", ".");
            AV13PontosMapaItem.gxTpr_Pontoslongitude = StringUtil.StringReplace( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Longitude, ",", ".");
            AV13PontosMapaItem.gxTpr_Veiculoplaca = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Placa;
            if ( StringUtil.StrCmp(((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Ignicao, "ON") == 0 )
            {
               AV13PontosMapaItem.gxTpr_Urlicone = context.convertURL( (string)(context.GetImagePath( "1d0f8bf7-9f21-4a7d-b232-318bdd328d2a", "", context.GetTheme( ))));
            }
            else
            {
               AV13PontosMapaItem.gxTpr_Urlicone = context.convertURL( (string)(context.GetImagePath( "5eeb00e7-f830-4f60-b7a5-21bc3a7eb9e6", "", context.GetTheme( ))));
            }
            AV12PontosMapa.Add(AV13PontosMapaItem, 0);
            this.executeUsercontrolMethod("", false, "MAPAContainer", "adicionaPontosMapa", "", new Object[] {AV12PontosMapa.ToJSonString(false),(bool)false});
            this.executeUsercontrolMethod("", false, "MAPAContainer", "RealizaZoom", "", new Object[] {StringUtil.StringReplace( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Latitude, ",", "."),StringUtil.StringReplace( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Longitude, ",", "."),(short)0});
         }
         else
         {
            ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Isvisible = false;
            AV17PontoIdRemover = 0;
            AV56GXV6 = 1;
            while ( AV56GXV6 <= AV12PontosMapa.Count )
            {
               AV13PontosMapaItem = ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV56GXV6));
               if ( StringUtil.StrCmp(AV13PontosMapaItem.gxTpr_Veiculoplaca, ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)(AV7SDTVeiculosMapa.CurrentItem)).gxTpr_Placa) == 0 )
               {
                  AV17PontoIdRemover = AV13PontosMapaItem.gxTpr_Pontosid;
                  AV12PontosMapa.RemoveItem(AV12PontosMapa.IndexOf(AV13PontosMapaItem));
                  if (true) break;
               }
               AV56GXV6 = (int)(AV56GXV6+1);
            }
            if ( ! (0==AV17PontoIdRemover) )
            {
               this.executeUsercontrolMethod("", false, "MAPAContainer", "removePonto", "", new Object[] {(long)AV17PontoIdRemover});
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12PontosMapa", AV12PontosMapa);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTVeiculosMapa", AV7SDTVeiculosMapa);
         nGXsfl_32_bak_idx = nGXsfl_32_idx;
         gxgrGridveiculos_refresh( AV7SDTVeiculosMapa) ;
         nGXsfl_32_idx = nGXsfl_32_bak_idx;
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_322( ) ;
      }

      protected void E162D2( )
      {
         AV49GXV1 = nGXsfl_32_idx;
         if ( AV7SDTVeiculosMapa.Count >= AV49GXV1 )
         {
            AV7SDTVeiculosMapa.CurrentItem = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1));
         }
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18NotificationInfo.gxTpr_Id, "NovaPosicaoMQTT") == 0 )
         {
            AV23AtualizarMapa = false;
            AV20SDTNovaPosicao = new SdtSDTNovaPosicao(context);
            AV20SDTNovaPosicao.FromJSonString(AV18NotificationInfo.gxTpr_Message, null);
            AV21Index = 0;
            AV57GXV7 = 1;
            while ( AV57GXV7 <= AV7SDTVeiculosMapa.Count )
            {
               AV10SDTVeiculosMapaItem = ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV57GXV7));
               AV21Index = (short)(AV21Index+1);
               if ( AV10SDTVeiculosMapaItem.gxTpr_Ultimodadolidoid == AV20SDTNovaPosicao.gxTpr_Ultimodadolidoid )
               {
                  ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV21Index)).gxTpr_Ignicao = AV20SDTNovaPosicao.gxTpr_Ignicao;
                  ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV21Index)).gxTpr_Latlong = AV20SDTNovaPosicao.gxTpr_Latlong;
                  ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV21Index)).gxTpr_Latitude = StringUtil.StringReplace( AV20SDTNovaPosicao.gxTpr_Latitude, ",", ".");
                  ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV21Index)).gxTpr_Longitude = StringUtil.StringReplace( AV20SDTNovaPosicao.gxTpr_Longitude, ",", ".");
                  if ( ((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV21Index)).gxTpr_Isvisible )
                  {
                     AV22IndexPontoMapa = 0;
                     AV58GXV8 = 1;
                     while ( AV58GXV8 <= AV12PontosMapa.Count )
                     {
                        AV13PontosMapaItem = ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV58GXV8));
                        AV22IndexPontoMapa = (short)(AV22IndexPontoMapa+1);
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV13PontosMapaItem.gxTpr_Veiculoplaca), StringUtil.Trim( AV20SDTNovaPosicao.gxTpr_Placa)) == 0 )
                        {
                           AV25Placa = StringUtil.Trim( StringUtil.Upper( AV20SDTNovaPosicao.gxTpr_Placa));
                           AssignAttri("", false, "AV25Placa", AV25Placa);
                           AV26Ignicao = StringUtil.Trim( AV20SDTNovaPosicao.gxTpr_Ignicao);
                           AssignAttri("", false, "AV26Ignicao", AV26Ignicao);
                           AV27HoraGPS = AV20SDTNovaPosicao.gxTpr_Horagps;
                           AssignAttri("", false, "AV27HoraGPS", context.localUtil.TToC( AV27HoraGPS, 8, 5, 0, 3, "/", ":", " "));
                           AV28LatLong = StringUtil.Trim( AV20SDTNovaPosicao.gxTpr_Latlong);
                           AssignAttri("", false, "AV28LatLong", AV28LatLong);
                           /* Execute user subroutine: 'PREENCHERHTML' */
                           S132 ();
                           if (returnInSub) return;
                           ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV22IndexPontoMapa)).gxTpr_Utilizarconteudobalaohtml = true;
                           ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV22IndexPontoMapa)).gxTpr_Conteudobalaohtml = AV15HTMLBalao;
                           ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV22IndexPontoMapa)).gxTpr_Pontoslatitude = StringUtil.StringReplace( AV20SDTNovaPosicao.gxTpr_Latitude, ",", ".");
                           ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV22IndexPontoMapa)).gxTpr_Pontoslongitude = StringUtil.StringReplace( AV20SDTNovaPosicao.gxTpr_Longitude, ",", ".");
                           if ( StringUtil.StrCmp(AV20SDTNovaPosicao.gxTpr_Ignicao, "ON") == 0 )
                           {
                              ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV22IndexPontoMapa)).gxTpr_Urlicone = context.convertURL( (string)(context.GetImagePath( "1d0f8bf7-9f21-4a7d-b232-318bdd328d2a", "", context.GetTheme( ))));
                           }
                           else
                           {
                              ((SdtPontosMapa_PontosMapaItem)AV12PontosMapa.Item(AV22IndexPontoMapa)).gxTpr_Urlicone = context.convertURL( (string)(context.GetImagePath( "5eeb00e7-f830-4f60-b7a5-21bc3a7eb9e6", "", context.GetTheme( ))));
                           }
                           AV23AtualizarMapa = true;
                           if (true) break;
                        }
                        AV58GXV8 = (int)(AV58GXV8+1);
                     }
                  }
                  if (true) break;
               }
               AV57GXV7 = (int)(AV57GXV7+1);
            }
            if ( AV23AtualizarMapa )
            {
               this.executeUsercontrolMethod("", false, "MAPAContainer", "adicionaPontosMapa", "", new Object[] {AV12PontosMapa.ToJSonString(false),(bool)false});
            }
         }
         else if ( StringUtil.StrCmp(AV18NotificationInfo.gxTpr_Id, "PercursoMapa") == 0 )
         {
            AV45SDTErroRastreamento.gxTpr_Msgerro = "";
            AV45SDTErroRastreamento.FromJSonString(AV18NotificationInfo.gxTpr_Message, null);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45SDTErroRastreamento.gxTpr_Msgerro)) )
            {
               GX_msglist.addItem(AV45SDTErroRastreamento.gxTpr_Msgerro);
               AV45SDTErroRastreamento = new SdtSDTErroRastreamento(context);
               this.executeUsercontrolMethod("", false, "MAPAContainer", "LimpaRotaMapa", "", new Object[] {});
               AV33IsRotaNoMapa = false;
               AssignAttri("", false, "AV33IsRotaNoMapa", AV33IsRotaNoMapa);
            }
            else
            {
               AV37PolylineCollection.FromJSonString(AV18NotificationInfo.gxTpr_Message, null);
               this.executeUsercontrolMethod("", false, "MAPAContainer", "AdicionaRotaMapa", "", new Object[] {AV37PolylineCollection.ToJSonString(false)});
               AV33IsRotaNoMapa = true;
               AssignAttri("", false, "AV33IsRotaNoMapa", AV33IsRotaNoMapa);
            }
            bttBtngerarpercurso_Caption = "Gerar";
            AssignProp("", false, bttBtngerarpercurso_Internalname, "Caption", bttBtngerarpercurso_Caption, true);
            bttBtngerarpercurso_Enabled = 1;
            AssignProp("", false, bttBtngerarpercurso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtngerarpercurso_Enabled), 5, 0), true);
            AV32IsAnimacaoIniciada = false;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7SDTVeiculosMapa", AV7SDTVeiculosMapa);
         nGXsfl_32_bak_idx = nGXsfl_32_idx;
         gxgrGridveiculos_refresh( AV7SDTVeiculosMapa) ;
         nGXsfl_32_idx = nGXsfl_32_bak_idx;
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_322( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12PontosMapa", AV12PontosMapa);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45SDTErroRastreamento", AV45SDTErroRastreamento);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37PolylineCollection", AV37PolylineCollection);
      }

      protected void S122( )
      {
         /* 'BUSCARVEICULOS' Routine */
         returnInSub = false;
         new buscargamguidusuariologado(context ).execute( out  AV9GAMGUID) ;
         AssignAttri("", false, "AV9GAMGUID", AV9GAMGUID);
         AV46IsAdministrator = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).checkrole("Administrator");
         AssignAttri("", false, "AV46IsAdministrator", AV46IsAdministrator);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV46IsAdministrator ,
                                              A105VeiculoGAMGUID ,
                                              AV9GAMGUID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H002D3 */
         pr_default.execute(1, new Object[] {AV9GAMGUID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A105VeiculoGAMGUID = H002D3_A105VeiculoGAMGUID[0];
            A101VeiculoTipo = H002D3_A101VeiculoTipo[0];
            A100VeiculoPlaca = H002D3_A100VeiculoPlaca[0];
            A103VeiculoModelo = H002D3_A103VeiculoModelo[0];
            A102VeiculoMarca = H002D3_A102VeiculoMarca[0];
            A98VeiculoId = H002D3_A98VeiculoId[0];
            A105VeiculoGAMGUID = H002D3_A105VeiculoGAMGUID[0];
            A101VeiculoTipo = H002D3_A101VeiculoTipo[0];
            A100VeiculoPlaca = H002D3_A100VeiculoPlaca[0];
            A103VeiculoModelo = H002D3_A103VeiculoModelo[0];
            A102VeiculoMarca = H002D3_A102VeiculoMarca[0];
            AV10SDTVeiculosMapaItem = new SdtSDTVeiculosMapa_SDTVeiculosMapaItem(context);
            AV10SDTVeiculosMapaItem.gxTpr_Veiculoid = A98VeiculoId;
            AV10SDTVeiculosMapaItem.gxTpr_Veiculotipo = A101VeiculoTipo;
            AV10SDTVeiculosMapaItem.gxTpr_Placa = StringUtil.Trim( StringUtil.Upper( A100VeiculoPlaca));
            AV10SDTVeiculosMapaItem.gxTpr_Marcamodelo = StringUtil.Trim( A102VeiculoMarca)+" "+StringUtil.Trim( A103VeiculoModelo);
            AV10SDTVeiculosMapaItem.gxTpr_Isvisible = false;
            AV11VeiculoPlaca = A100VeiculoPlaca;
            AssignAttri("", false, "AV11VeiculoPlaca", AV11VeiculoPlaca);
            /* Using cursor H002D4 */
            pr_default.execute(2, new Object[] {AV11VeiculoPlaca});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A121UltimoDadoLidoPlaca = H002D4_A121UltimoDadoLidoPlaca[0];
               A122UltimoDadoLidoIgnicao = H002D4_A122UltimoDadoLidoIgnicao[0];
               A118UltimoDadoLidoId = H002D4_A118UltimoDadoLidoId[0];
               A120UltimoDadoLidoDataHoraRastreador = H002D4_A120UltimoDadoLidoDataHoraRastreador[0];
               A124UltimoDadoLidoLongitude = H002D4_A124UltimoDadoLidoLongitude[0];
               A123UltimoDadoLidoLatitude = H002D4_A123UltimoDadoLidoLatitude[0];
               A127UltimoDadoLidoGeolocalizacao = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".") + "," + StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
               AssignAttri("", false, "A127UltimoDadoLidoGeolocalizacao", A127UltimoDadoLidoGeolocalizacao);
               AV10SDTVeiculosMapaItem.gxTpr_Ignicao = gxdomaindomignicao.getDescription(context,A122UltimoDadoLidoIgnicao);
               AV10SDTVeiculosMapaItem.gxTpr_Latlong = A127UltimoDadoLidoGeolocalizacao;
               AV10SDTVeiculosMapaItem.gxTpr_Latitude = StringUtil.Trim( A123UltimoDadoLidoLatitude);
               AV10SDTVeiculosMapaItem.gxTpr_Longitude = StringUtil.Trim( A124UltimoDadoLidoLongitude);
               AV10SDTVeiculosMapaItem.gxTpr_Ultimodadolidoid = A118UltimoDadoLidoId;
               AV10SDTVeiculosMapaItem.gxTpr_Horagps = A120UltimoDadoLidoDataHoraRastreador;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV7SDTVeiculosMapa.Add(AV10SDTVeiculosMapaItem, 0);
            gx_BV32 = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S132( )
      {
         /* 'PREENCHERHTML' Routine */
         returnInSub = false;
         AV15HTMLBalao = "";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao = "<div style=\"margin: 10px;font-size: 13px;\">";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "<strong>" + StringUtil.Trim( AV25Placa) + "</strong>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "<p><strong>Ignição: </strong>" + StringUtil.Trim( AV26Ignicao) + "</p>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "<p><strong>Hora GPS: </strong>" + StringUtil.Trim( context.localUtil.TToC( AV27HoraGPS, 8, 5, 0, 3, "/", ":", " ")) + "</p>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "<p><strong>Lat/Long:</strong>" + StringUtil.Trim( AV28LatLong) + "</p>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "<div style=\"margin-top: 10px;display: flex;flex: 1;justify-content: space-evenly;align-items: center;\">";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "<a href=\"https://www.google.com/maps/search/?api=1&amp;query=" + StringUtil.Trim( AV28LatLong) + "\" target=\"_blank\" style=\"color:black;\"><i class=\"fas fa-map-marker-alt fa-2x\" aria-hidden=\"true\"></i></a>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "<a href=\"http://maps.google.com/maps?q=&amp;layer=c&amp;cbll=" + StringUtil.Trim( AV28LatLong) + "\" target=\"_blank\" style=\"color:black;\"><i class=\"fa fa-street-view fa-2x\" aria-hidden=\"true\"></i></a>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "</div>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
         AV15HTMLBalao += "</div>";
         AssignAttri("", false, "AV15HTMLBalao", AV15HTMLBalao);
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
         PA2D2( ) ;
         WS2D2( ) ;
         WE2D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202151417261326", true, true);
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
         context.AddJavascriptSource("mapa.js", "?202151417261328", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("UserControls/MapBoxGLRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_322( )
      {
         lblIconcar_Internalname = "ICONCAR_"+sGXsfl_32_idx;
         edtavSdtveiculosmapa__placa_Internalname = "SDTVEICULOSMAPA__PLACA_"+sGXsfl_32_idx;
         edtavSdtveiculosmapa__marcamodelo_Internalname = "SDTVEICULOSMAPA__MARCAMODELO_"+sGXsfl_32_idx;
         lblIconvisualizar_Internalname = "ICONVISUALIZAR_"+sGXsfl_32_idx;
         lblIconignicao_Internalname = "ICONIGNICAO_"+sGXsfl_32_idx;
         Dvpanel_cardveiculo_Internalname = "DVPANEL_CARDVEICULO_"+sGXsfl_32_idx;
         edtavSdtveiculosmapa__veiculoid_Internalname = "SDTVEICULOSMAPA__VEICULOID_"+sGXsfl_32_idx;
         edtavSdtveiculosmapa__ignicao_Internalname = "SDTVEICULOSMAPA__IGNICAO_"+sGXsfl_32_idx;
      }

      protected void SubsflControlProps_fel_322( )
      {
         lblIconcar_Internalname = "ICONCAR_"+sGXsfl_32_fel_idx;
         edtavSdtveiculosmapa__placa_Internalname = "SDTVEICULOSMAPA__PLACA_"+sGXsfl_32_fel_idx;
         edtavSdtveiculosmapa__marcamodelo_Internalname = "SDTVEICULOSMAPA__MARCAMODELO_"+sGXsfl_32_fel_idx;
         lblIconvisualizar_Internalname = "ICONVISUALIZAR_"+sGXsfl_32_fel_idx;
         lblIconignicao_Internalname = "ICONIGNICAO_"+sGXsfl_32_fel_idx;
         Dvpanel_cardveiculo_Internalname = "DVPANEL_CARDVEICULO_"+sGXsfl_32_fel_idx;
         edtavSdtveiculosmapa__veiculoid_Internalname = "SDTVEICULOSMAPA__VEICULOID_"+sGXsfl_32_fel_idx;
         edtavSdtveiculosmapa__ignicao_Internalname = "SDTVEICULOSMAPA__IGNICAO_"+sGXsfl_32_fel_idx;
      }

      protected void sendrow_322( )
      {
         SubsflControlProps_322( ) ;
         WB2D0( ) ;
         GridveiculosRow = GXWebRow.GetNew(context,GridveiculosContainer);
         if ( subGridveiculos_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridveiculos_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridveiculos_Class, "") != 0 )
            {
               subGridveiculos_Linesclass = subGridveiculos_Class+"Odd";
            }
         }
         else if ( subGridveiculos_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridveiculos_Backstyle = 0;
            subGridveiculos_Backcolor = subGridveiculos_Allbackcolor;
            if ( StringUtil.StrCmp(subGridveiculos_Class, "") != 0 )
            {
               subGridveiculos_Linesclass = subGridveiculos_Class+"Uniform";
            }
         }
         else if ( subGridveiculos_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridveiculos_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridveiculos_Class, "") != 0 )
            {
               subGridveiculos_Linesclass = subGridveiculos_Class+"Odd";
            }
            subGridveiculos_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridveiculos_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridveiculos_Backstyle = 1;
            if ( ((int)((nGXsfl_32_idx) % (2))) == 0 )
            {
               subGridveiculos_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridveiculos_Class, "") != 0 )
               {
                  subGridveiculos_Linesclass = subGridveiculos_Class+"Even";
               }
            }
            else
            {
               subGridveiculos_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridveiculos_Class, "") != 0 )
               {
                  subGridveiculos_Linesclass = subGridveiculos_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridveiculosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridveiculos_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_32_idx+"\">") ;
         }
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgridveiculos_Internalname+"_"+sGXsfl_32_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 WWFiltersCell",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* User Defined Control */
         GridveiculosRow.AddColumnProperties("usercontrol", -1, isAjaxCallMode( ), new Object[] {(string)"DVPANEL_CARDVEICULOContainer"+"_"+sGXsfl_32_idx,(short)-1});
         GridveiculosRow.AddColumnProperties("usercontrolcontainer", -1, isAjaxCallMode( ), new Object[] {(string)"DVPANEL_CARDVEICULOContainer",(string)"CardVeiculo"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCardveiculo_Internalname+"_"+sGXsfl_32_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"align-items:center;align-content:center;",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;align-self:center;",(string)"div"});
         /* Text block */
         GridveiculosRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblIconcar_Internalname,(string)lblIconcar_Caption,(string)"",(string)"",(string)lblIconcar_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;align-self:center;",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTbldados_Internalname+"_"+sGXsfl_32_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:flex-start;",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;align-self:flex-start;",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridveiculosRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__placa_Internalname,(string)"Placa",(string)"gx-form-item AttributeTitleGridLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "AttributeTitleGrid";
         GridveiculosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__placa_Internalname,((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1)).gxTpr_Placa,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtveiculosmapa__placa_Jsonclick,(short)0,(string)"AttributeTitleGrid",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtveiculosmapa__placa_Enabled,(short)0,(string)"text",(string)"",(short)7,(string)"chr",(short)1,(string)"row",(short)7,(short)0,(short)0,(short)32,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;align-self:flex-start;",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridveiculosRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__marcamodelo_Internalname,(string)"Marca Modelo",(string)"gx-form-item AttributeSubTitleGridLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "AttributeSubTitleGrid";
         GridveiculosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__marcamodelo_Internalname,((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1)).gxTpr_Marcamodelo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtveiculosmapa__marcamodelo_Jsonclick,(short)0,(string)"AttributeSubTitleGrid",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtveiculosmapa__marcamodelo_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)32,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;align-self:center;",(string)"div"});
         /* Text block */
         GridveiculosRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblIconvisualizar_Internalname,(string)lblIconvisualizar_Caption,(string)"",(string)"",(string)lblIconvisualizar_Jsonclick,"'"+""+"'"+",false,"+"'"+"EICONVISUALIZAR.CLICK."+sGXsfl_32_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;align-self:center;",(string)"div"});
         /* Text block */
         GridveiculosRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblIconignicao_Internalname,(string)lblIconignicao_Caption,(string)"",(string)"",(string)lblIconignicao_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"SectionMaxHeight25",(short)0,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         GridveiculosRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgridveiculos_Internalname+"_"+sGXsfl_32_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridveiculosRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridveiculosRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridveiculosRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__veiculoid_Internalname,(string)"Sequência",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = " " + ((edtavSdtveiculosmapa__veiculoid_Enabled!=0)&&(edtavSdtveiculosmapa__veiculoid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 59,'',false,'"+sGXsfl_32_idx+"',32)\"" : " ");
         ROClassString = "Attribute";
         GridveiculosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__veiculoid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1)).gxTpr_Veiculoid), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1)).gxTpr_Veiculoid), "ZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavSdtveiculosmapa__veiculoid_Enabled!=0)&&(edtavSdtveiculosmapa__veiculoid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtveiculosmapa__veiculoid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdtveiculosmapa__veiculoid_Visible,(short)1,(short)0,(string)"number",(string)"1",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)32,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( GridveiculosContainer.GetWrapped() == 1 )
         {
            GridveiculosContainer.CloseTag("cell");
         }
         GridveiculosRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridveiculosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridveiculosRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__ignicao_Internalname,(string)"Ignicao",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         TempTags = " " + ((edtavSdtveiculosmapa__ignicao_Enabled!=0)&&(edtavSdtveiculosmapa__ignicao_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 62,'',false,'"+sGXsfl_32_idx+"',32)\"" : " ");
         ROClassString = "Attribute";
         GridveiculosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtveiculosmapa__ignicao_Internalname,((SdtSDTVeiculosMapa_SDTVeiculosMapaItem)AV7SDTVeiculosMapa.Item(AV49GXV1)).gxTpr_Ignicao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSdtveiculosmapa__ignicao_Enabled!=0)&&(edtavSdtveiculosmapa__ignicao_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,62);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtveiculosmapa__ignicao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSdtveiculosmapa__ignicao_Visible,(short)1,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)32,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( GridveiculosContainer.GetWrapped() == 1 )
         {
            GridveiculosContainer.CloseTag("cell");
         }
         if ( GridveiculosContainer.GetWrapped() == 1 )
         {
            GridveiculosContainer.CloseTag("row");
         }
         if ( GridveiculosContainer.GetWrapped() == 1 )
         {
            GridveiculosContainer.CloseTag("table");
         }
         /* End of table */
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridveiculosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2D2( ) ;
         GXCCtl = "DVPANEL_CARDVEICULO_Width_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardveiculo_Width));
         GXCCtl = "DVPANEL_CARDVEICULO_Autowidth_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardveiculo_Autowidth));
         GXCCtl = "DVPANEL_CARDVEICULO_Autoheight_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardveiculo_Autoheight));
         GXCCtl = "DVPANEL_CARDVEICULO_Cls_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardveiculo_Cls));
         GXCCtl = "DVPANEL_CARDVEICULO_Title_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardveiculo_Title));
         GXCCtl = "DVPANEL_CARDVEICULO_Collapsible_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardveiculo_Collapsible));
         GXCCtl = "DVPANEL_CARDVEICULO_Collapsed_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardveiculo_Collapsed));
         GXCCtl = "DVPANEL_CARDVEICULO_Showcollapseicon_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardveiculo_Showcollapseicon));
         GXCCtl = "DVPANEL_CARDVEICULO_Iconposition_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Dvpanel_cardveiculo_Iconposition));
         GXCCtl = "DVPANEL_CARDVEICULO_Autoscroll_" + sGXsfl_32_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Dvpanel_cardveiculo_Autoscroll));
         /* End of Columns property logic. */
         GridveiculosContainer.AddRow(GridveiculosRow);
         nGXsfl_32_idx = ((subGridveiculos_Islastpage==1)&&(nGXsfl_32_idx+1>subGridveiculos_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_322( ) ;
         /* End function sendrow_322 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Mapa_Internalname = "MAPA";
         divTablecontent_Internalname = "TABLECONTENT";
         lblTabveiculo_title_Internalname = "TABVEICULO_TITLE";
         lblIconcar_Internalname = "ICONCAR";
         edtavSdtveiculosmapa__placa_Internalname = "SDTVEICULOSMAPA__PLACA";
         edtavSdtveiculosmapa__marcamodelo_Internalname = "SDTVEICULOSMAPA__MARCAMODELO";
         divTbldados_Internalname = "TBLDADOS";
         lblIconvisualizar_Internalname = "ICONVISUALIZAR";
         lblIconignicao_Internalname = "ICONIGNICAO";
         divCardveiculo_Internalname = "CARDVEICULO";
         Dvpanel_cardveiculo_Internalname = "DVPANEL_CARDVEICULO";
         edtavSdtveiculosmapa__veiculoid_Internalname = "SDTVEICULOSMAPA__VEICULOID";
         edtavSdtveiculosmapa__ignicao_Internalname = "SDTVEICULOSMAPA__IGNICAO";
         tblUnnamedtablecontentfsgridveiculos_Internalname = "UNNAMEDTABLECONTENTFSGRIDVEICULOS";
         divUnnamedtablefsgridveiculos_Internalname = "UNNAMEDTABLEFSGRIDVEICULOS";
         divTblveiculo_Internalname = "TBLVEICULO";
         divTblveiculos_Internalname = "TBLVEICULOS";
         lblTabtrajetos_title_Internalname = "TABTRAJETOS_TITLE";
         lblTextblockcombo_veiculoidpercurso_Internalname = "TEXTBLOCKCOMBO_VEICULOIDPERCURSO";
         Combo_veiculoidpercurso_Internalname = "COMBO_VEICULOIDPERCURSO";
         divTablesplittedveiculoidpercurso_Internalname = "TABLESPLITTEDVEICULOIDPERCURSO";
         lblTextblockdatainiciopercurso_Internalname = "TEXTBLOCKDATAINICIOPERCURSO";
         edtavDatainiciopercurso_Internalname = "vDATAINICIOPERCURSO";
         divUnnamedtabledatainiciopercurso_Internalname = "UNNAMEDTABLEDATAINICIOPERCURSO";
         lblTextblockdatafimpercurso_Internalname = "TEXTBLOCKDATAFIMPERCURSO";
         edtavDatafimpercurso_Internalname = "vDATAFIMPERCURSO";
         divUnnamedtabledatafimpercurso_Internalname = "UNNAMEDTABLEDATAFIMPERCURSO";
         bttBtngerarpercurso_Internalname = "BTNGERARPERCURSO";
         bttBtnlimparpercurso_Internalname = "BTNLIMPARPERCURSO";
         divTablebotoes_Internalname = "TABLEBOTOES";
         lblIconreset_Internalname = "ICONRESET";
         lblIconplay_Internalname = "ICONPLAY";
         divTableicons_Internalname = "TABLEICONS";
         divGroupanimacao_Internalname = "GROUPANIMACAO";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divCardpercurso_Internalname = "CARDPERCURSO";
         Dvpanel_cardpercurso_Internalname = "DVPANEL_CARDPERCURSO";
         divTbltrajeto_Internalname = "TBLTRAJETO";
         divTbltrajetos_Internalname = "TBLTRAJETOS";
         Gxuitabspanel_tabmenumapa_Internalname = "GXUITABSPANEL_TABMENUMAPA";
         divTablemenumapa_Internalname = "TABLEMENUMAPA";
         divTablemain_Internalname = "TABLEMAIN";
         edtavVeiculoidpercurso_Internalname = "vVEICULOIDPERCURSO";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridveiculos_Internalname = "GRIDVEICULOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavSdtveiculosmapa__ignicao_Jsonclick = "";
         edtavSdtveiculosmapa__ignicao_Enabled = 1;
         edtavSdtveiculosmapa__veiculoid_Jsonclick = "";
         edtavSdtveiculosmapa__veiculoid_Enabled = 1;
         lblIconignicao_Caption = "<i class='fas fa-power-off' style='float:right;color:lime;margin-left:10px;font-size: 25px'></i>";
         lblIconvisualizar_Caption = "<i class='fas fa-eye' style='float:right;color:gray;margin-left:10px;font-size: 25px'></i>";
         edtavSdtveiculosmapa__marcamodelo_Jsonclick = "";
         edtavSdtveiculosmapa__marcamodelo_Enabled = 0;
         edtavSdtveiculosmapa__placa_Jsonclick = "";
         edtavSdtveiculosmapa__placa_Enabled = 0;
         lblIconcar_Caption = "<i class='fas fa-car' style='color:gray;margin-right:10px;font-size: 25px'></i>";
         subGridveiculos_Class = "FreeStyleGrid";
         edtavSdtveiculosmapa__marcamodelo_Enabled = -1;
         edtavSdtveiculosmapa__placa_Enabled = -1;
         Dvpanel_cardveiculo_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardveiculo_Iconposition = "Right";
         Dvpanel_cardveiculo_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardveiculo_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardveiculo_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardveiculo_Title = "Veiculo";
         Dvpanel_cardveiculo_Cls = "PanelNoHeader";
         Dvpanel_cardveiculo_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardveiculo_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardveiculo_Width = "100%";
         edtavVeiculoidpercurso_Jsonclick = "";
         edtavVeiculoidpercurso_Visible = 1;
         bttBtngerarpercurso_Enabled = 1;
         edtavDatafimpercurso_Jsonclick = "";
         edtavDatafimpercurso_Enabled = 1;
         edtavDatainiciopercurso_Jsonclick = "";
         edtavDatainiciopercurso_Enabled = 1;
         Combo_veiculoidpercurso_Caption = "";
         subGridveiculos_Allowcollapsing = 0;
         edtavSdtveiculosmapa__ignicao_Visible = 1;
         edtavSdtveiculosmapa__veiculoid_Visible = 1;
         subGridveiculos_Backcolorstyle = 0;
         bttBtngerarpercurso_Caption = "Gerar";
         Gxuitabspanel_tabmenumapa_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabmenumapa_Class = "";
         Gxuitabspanel_tabmenumapa_Pagecount = 2;
         Dvpanel_cardpercurso_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardpercurso_Iconposition = "Right";
         Dvpanel_cardpercurso_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardpercurso_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardpercurso_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardpercurso_Title = "Percurso";
         Dvpanel_cardpercurso_Cls = "PanelNoHeader";
         Dvpanel_cardpercurso_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardpercurso_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardpercurso_Width = "100%";
         Combo_veiculoidpercurso_Datalistprocparametersprefix = " \"ComboName\": \"VeiculoIdPercurso\"";
         Combo_veiculoidpercurso_Datalistproc = "MapaLoadDVCombo";
         Combo_veiculoidpercurso_Cls = "ExtendedCombo Attribute";
         Mapa_Tablemenuinternalname = "";
         Mapa_Utilizarmenumapa = "Sim";
         Mapa_Utilizarcontrolerota = "Sim";
         Mapa_Utilizarcontroledistancia = "Sim";
         Mapa_Adicionarcontrolededesenho = "Nao";
         Mapa_Height = "calc(100vh - 230px)";
         Mapa_Mapkey = "pk.eyJ1Ijoic2F0Y29tIiwiYSI6ImNrYzB5bDYyajBvNjgzMG9lZjQxaHE4NXkifQ.51HhkvkPU2PQma02C40aJA";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Mapa";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDVEICULOS_nFirstRecordOnPage'},{av:'GRIDVEICULOS_nEOF'},{av:'AV7SDTVeiculosMapa',fld:'vSDTVEICULOSMAPA',grid:32,pic:''},{av:'nRC_GXsfl_32',ctrl:'GRIDVEICULOS',prop:'GridRC'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDVEICULOS.LOAD","{handler:'E182D2',iparms:[{av:'AV7SDTVeiculosMapa',fld:'vSDTVEICULOSMAPA',grid:32,pic:''},{av:'GRIDVEICULOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRIDVEICULOS',prop:'GridRC'}]");
         setEventMetadata("GRIDVEICULOS.LOAD",",oparms:[{av:'lblIconignicao_Caption',ctrl:'ICONIGNICAO',prop:'Caption'},{av:'lblIconcar_Caption',ctrl:'ICONCAR',prop:'Caption'},{av:'lblIconvisualizar_Caption',ctrl:'ICONVISUALIZAR',prop:'Caption'}]}");
         setEventMetadata("'DOICONRESET'","{handler:'E112D1',iparms:[{av:'AV33IsRotaNoMapa',fld:'vISROTANOMAPA',pic:''},{av:'AV37PolylineCollection',fld:'vPOLYLINECOLLECTION',pic:''}]");
         setEventMetadata("'DOICONRESET'",",oparms:[]}");
         setEventMetadata("'DOICONPLAY'","{handler:'E122D1',iparms:[{av:'AV33IsRotaNoMapa',fld:'vISROTANOMAPA',pic:''},{av:'AV37PolylineCollection',fld:'vPOLYLINECOLLECTION',pic:''}]");
         setEventMetadata("'DOICONPLAY'",",oparms:[]}");
         setEventMetadata("'DOGERARPERCURSO'","{handler:'E142D2',iparms:[{av:'AV43VeiculoIdPercurso',fld:'vVEICULOIDPERCURSO',pic:'ZZZZZZZ9'},{av:'AV30DataInicioPercurso',fld:'vDATAINICIOPERCURSO',pic:'99/99/99 99:99'},{av:'AV31DataFimPercurso',fld:'vDATAFIMPERCURSO',pic:'99/99/99 99:99'}]");
         setEventMetadata("'DOGERARPERCURSO'",",oparms:[{av:'AV37PolylineCollection',fld:'vPOLYLINECOLLECTION',pic:''},{av:'AV33IsRotaNoMapa',fld:'vISROTANOMAPA',pic:''},{av:'AV31DataFimPercurso',fld:'vDATAFIMPERCURSO',pic:'99/99/99 99:99'},{av:'AV30DataInicioPercurso',fld:'vDATAINICIOPERCURSO',pic:'99/99/99 99:99'},{av:'AV43VeiculoIdPercurso',fld:'vVEICULOIDPERCURSO',pic:'ZZZZZZZ9'},{ctrl:'BTNGERARPERCURSO',prop:'Caption'},{ctrl:'BTNGERARPERCURSO',prop:'Enabled'}]}");
         setEventMetadata("'DOLIMPARPERCURSO'","{handler:'E152D2',iparms:[]");
         setEventMetadata("'DOLIMPARPERCURSO'",",oparms:[{av:'AV37PolylineCollection',fld:'vPOLYLINECOLLECTION',pic:''},{av:'AV33IsRotaNoMapa',fld:'vISROTANOMAPA',pic:''}]}");
         setEventMetadata("COMBO_VEICULOIDPERCURSO.ONOPTIONCLICKED","{handler:'E132D2',iparms:[{av:'Combo_veiculoidpercurso_Selectedvalue_get',ctrl:'COMBO_VEICULOIDPERCURSO',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_VEICULOIDPERCURSO.ONOPTIONCLICKED",",oparms:[{av:'AV43VeiculoIdPercurso',fld:'vVEICULOIDPERCURSO',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("ICONVISUALIZAR.CLICK","{handler:'E192D2',iparms:[{av:'AV14PontosId',fld:'vPONTOSID',pic:'ZZZZZZZ9'},{av:'AV7SDTVeiculosMapa',fld:'vSDTVEICULOSMAPA',grid:32,pic:''},{av:'GRIDVEICULOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRIDVEICULOS',prop:'GridRC'},{av:'AV12PontosMapa',fld:'vPONTOSMAPA',pic:''},{av:'AV25Placa',fld:'vPLACA',pic:''},{av:'AV26Ignicao',fld:'vIGNICAO',pic:''},{av:'AV27HoraGPS',fld:'vHORAGPS',pic:'99/99/99 99:99'},{av:'AV28LatLong',fld:'vLATLONG',pic:''},{av:'GRIDVEICULOS_nEOF'}]");
         setEventMetadata("ICONVISUALIZAR.CLICK",",oparms:[{av:'AV14PontosId',fld:'vPONTOSID',pic:'ZZZZZZZ9'},{av:'AV15HTMLBalao',fld:'vHTMLBALAO',pic:''},{av:'AV25Placa',fld:'vPLACA',pic:''},{av:'AV26Ignicao',fld:'vIGNICAO',pic:''},{av:'AV27HoraGPS',fld:'vHORAGPS',pic:'99/99/99 99:99'},{av:'AV28LatLong',fld:'vLATLONG',pic:''},{av:'AV12PontosMapa',fld:'vPONTOSMAPA',pic:''},{av:'AV7SDTVeiculosMapa',fld:'vSDTVEICULOSMAPA',grid:32,pic:''},{av:'GRIDVEICULOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRIDVEICULOS',prop:'GridRC'}]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E162D2',iparms:[{av:'AV18NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''},{av:'AV7SDTVeiculosMapa',fld:'vSDTVEICULOSMAPA',grid:32,pic:''},{av:'GRIDVEICULOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRIDVEICULOS',prop:'GridRC'},{av:'AV12PontosMapa',fld:'vPONTOSMAPA',pic:''},{av:'AV15HTMLBalao',fld:'vHTMLBALAO',pic:''},{av:'AV45SDTErroRastreamento',fld:'vSDTERRORASTREAMENTO',pic:''},{av:'AV25Placa',fld:'vPLACA',pic:''},{av:'AV26Ignicao',fld:'vIGNICAO',pic:''},{av:'AV27HoraGPS',fld:'vHORAGPS',pic:'99/99/99 99:99'},{av:'AV28LatLong',fld:'vLATLONG',pic:''},{av:'GRIDVEICULOS_nEOF'}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[{av:'AV7SDTVeiculosMapa',fld:'vSDTVEICULOSMAPA',grid:32,pic:''},{av:'GRIDVEICULOS_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRIDVEICULOS',prop:'GridRC'},{av:'AV25Placa',fld:'vPLACA',pic:''},{av:'AV26Ignicao',fld:'vIGNICAO',pic:''},{av:'AV27HoraGPS',fld:'vHORAGPS',pic:'99/99/99 99:99'},{av:'AV28LatLong',fld:'vLATLONG',pic:''},{av:'AV12PontosMapa',fld:'vPONTOSMAPA',pic:''},{av:'AV45SDTErroRastreamento',fld:'vSDTERRORASTREAMENTO',pic:''},{av:'AV37PolylineCollection',fld:'vPOLYLINECOLLECTION',pic:''},{av:'AV33IsRotaNoMapa',fld:'vISROTANOMAPA',pic:''},{ctrl:'BTNGERARPERCURSO',prop:'Caption'},{ctrl:'BTNGERARPERCURSO',prop:'Enabled'},{av:'AV15HTMLBalao',fld:'vHTMLBALAO',pic:''}]}");
         setEventMetadata("VALIDV_DATAINICIOPERCURSO","{handler:'Validv_Datainiciopercurso',iparms:[]");
         setEventMetadata("VALIDV_DATAINICIOPERCURSO",",oparms:[]}");
         setEventMetadata("VALIDV_DATAFIMPERCURSO","{handler:'Validv_Datafimpercurso',iparms:[]");
         setEventMetadata("VALIDV_DATAFIMPERCURSO",",oparms:[]}");
         setEventMetadata("VALIDV_VEICULOIDPERCURSO","{handler:'Validv_Veiculoidpercurso',iparms:[]");
         setEventMetadata("VALIDV_VEICULOIDPERCURSO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv5',iparms:[]");
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
         Combo_veiculoidpercurso_Selectedvalue_get = "";
         AV18NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7SDTVeiculosMapa = new GXBaseCollection<SdtSDTVeiculosMapa_SDTVeiculosMapaItem>( context, "SDTVeiculosMapaItem", "RastreamentoTCC");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV39DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV44VeiculoIdPercurso_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV37PolylineCollection = new GXBaseCollection<SdtPolyline_PolylineItem>( context, "PolylineItem", "RastreamentoTCC");
         AV12PontosMapa = new GXBaseCollection<SdtPontosMapa_PontosMapaItem>( context, "PontosMapaItem", "RastreamentoTCC");
         AV25Placa = "";
         AV26Ignicao = "";
         AV27HoraGPS = (DateTime)(DateTime.MinValue);
         AV28LatLong = "";
         AV15HTMLBalao = "";
         AV45SDTErroRastreamento = new SdtSDTErroRastreamento(context);
         Combo_veiculoidpercurso_Selectedvalue_set = "";
         Combo_veiculoidpercurso_Selectedtext_set = "";
         Combo_veiculoidpercurso_Gamoauthtoken = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucMapa = new GXUserControl();
         ucGxuitabspanel_tabmenumapa = new GXUserControl();
         lblTabveiculo_title_Jsonclick = "";
         GridveiculosContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridveiculos_Header = "";
         GridveiculosColumn = new GXWebColumn();
         lblTabtrajetos_title_Jsonclick = "";
         ucDvpanel_cardpercurso = new GXUserControl();
         lblTextblockcombo_veiculoidpercurso_Jsonclick = "";
         ucCombo_veiculoidpercurso = new GXUserControl();
         lblTextblockdatainiciopercurso_Jsonclick = "";
         TempTags = "";
         AV30DataInicioPercurso = (DateTime)(DateTime.MinValue);
         lblTextblockdatafimpercurso_Jsonclick = "";
         AV31DataFimPercurso = (DateTime)(DateTime.MinValue);
         bttBtngerarpercurso_Jsonclick = "";
         bttBtnlimparpercurso_Jsonclick = "";
         lblIconreset_Jsonclick = "";
         lblIconplay_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         ucDvpanel_cardveiculo = new GXUserControl();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV42GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GridveiculosRow = new GXWebRow();
         AV35ClientIdSocket = "";
         AV36Socket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV55Udparg1 = "";
         scmdbuf = "";
         H002D2_A105VeiculoGAMGUID = new string[] {""} ;
         H002D2_A98VeiculoId = new int[1] ;
         H002D2_A100VeiculoPlaca = new string[] {""} ;
         A105VeiculoGAMGUID = "";
         A100VeiculoPlaca = "";
         AV13PontosMapaItem = new SdtPontosMapa_PontosMapaItem(context);
         AV20SDTNovaPosicao = new SdtSDTNovaPosicao(context);
         AV10SDTVeiculosMapaItem = new SdtSDTVeiculosMapa_SDTVeiculosMapaItem(context);
         AV9GAMGUID = "";
         H002D3_A105VeiculoGAMGUID = new string[] {""} ;
         H002D3_A101VeiculoTipo = new string[] {""} ;
         H002D3_A100VeiculoPlaca = new string[] {""} ;
         H002D3_A103VeiculoModelo = new string[] {""} ;
         H002D3_A102VeiculoMarca = new string[] {""} ;
         H002D3_A98VeiculoId = new int[1] ;
         A101VeiculoTipo = "";
         A103VeiculoModelo = "";
         A102VeiculoMarca = "";
         AV11VeiculoPlaca = "";
         H002D4_A121UltimoDadoLidoPlaca = new string[] {""} ;
         H002D4_A122UltimoDadoLidoIgnicao = new short[1] ;
         H002D4_A118UltimoDadoLidoId = new int[1] ;
         H002D4_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         H002D4_A124UltimoDadoLidoLongitude = new string[] {""} ;
         H002D4_A123UltimoDadoLidoLatitude = new string[] {""} ;
         A121UltimoDadoLidoPlaca = "";
         A120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         A124UltimoDadoLidoLongitude = "";
         A123UltimoDadoLidoLatitude = "";
         A127UltimoDadoLidoGeolocalizacao = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridveiculos_Linesclass = "";
         lblIconcar_Jsonclick = "";
         ROClassString = "";
         lblIconvisualizar_Jsonclick = "";
         lblIconignicao_Jsonclick = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mapa__default(),
            new Object[][] {
                new Object[] {
               H002D2_A105VeiculoGAMGUID, H002D2_A98VeiculoId, H002D2_A100VeiculoPlaca
               }
               , new Object[] {
               H002D3_A105VeiculoGAMGUID, H002D3_A101VeiculoTipo, H002D3_A100VeiculoPlaca, H002D3_A103VeiculoModelo, H002D3_A102VeiculoMarca, H002D3_A98VeiculoId
               }
               , new Object[] {
               H002D4_A121UltimoDadoLidoPlaca, H002D4_A122UltimoDadoLidoIgnicao, H002D4_A118UltimoDadoLidoId, H002D4_A120UltimoDadoLidoDataHoraRastreador, H002D4_A124UltimoDadoLidoLongitude, H002D4_A123UltimoDadoLidoLatitude
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtveiculosmapa__placa_Enabled = 0;
         edtavSdtveiculosmapa__marcamodelo_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridveiculos_Backcolorstyle ;
      private short subGridveiculos_Allowselection ;
      private short subGridveiculos_Allowhovering ;
      private short subGridveiculos_Allowcollapsing ;
      private short subGridveiculos_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV54GXLvl176 ;
      private short GRIDVEICULOS_nEOF ;
      private short AV21Index ;
      private short AV22IndexPontoMapa ;
      private short A122UltimoDadoLidoIgnicao ;
      private short nGXWrapped ;
      private short subGridveiculos_Backstyle ;
      private int nRC_GXsfl_32 ;
      private int nGXsfl_32_idx=1 ;
      private int AV14PontosId ;
      private int Gxuitabspanel_tabmenumapa_Pagecount ;
      private int bttBtngerarpercurso_Enabled ;
      private int edtavSdtveiculosmapa__veiculoid_Visible ;
      private int edtavSdtveiculosmapa__ignicao_Visible ;
      private int subGridveiculos_Selectedindex ;
      private int subGridveiculos_Selectioncolor ;
      private int subGridveiculos_Hoveringcolor ;
      private int AV49GXV1 ;
      private int edtavDatainiciopercurso_Enabled ;
      private int edtavDatafimpercurso_Enabled ;
      private int AV43VeiculoIdPercurso ;
      private int edtavVeiculoidpercurso_Visible ;
      private int subGridveiculos_Islastpage ;
      private int edtavSdtveiculosmapa__placa_Enabled ;
      private int edtavSdtveiculosmapa__marcamodelo_Enabled ;
      private int nGXsfl_32_fel_idx=1 ;
      private int A98VeiculoId ;
      private int AV56GXV6 ;
      private int nGXsfl_32_bak_idx=1 ;
      private int AV57GXV7 ;
      private int AV58GXV8 ;
      private int A118UltimoDadoLidoId ;
      private int idxLst ;
      private int subGridveiculos_Backcolor ;
      private int subGridveiculos_Allbackcolor ;
      private int edtavSdtveiculosmapa__veiculoid_Enabled ;
      private int edtavSdtveiculosmapa__ignicao_Enabled ;
      private long GRIDVEICULOS_nCurrentRecord ;
      private long AV17PontoIdRemover ;
      private long GRIDVEICULOS_nFirstRecordOnPage ;
      private string Combo_veiculoidpercurso_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_32_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Mapa_Mapkey ;
      private string Mapa_Height ;
      private string Mapa_Adicionarcontrolededesenho ;
      private string Mapa_Utilizarcontroledistancia ;
      private string Mapa_Utilizarcontrolerota ;
      private string Mapa_Utilizarmenumapa ;
      private string Mapa_Tablemenuinternalname ;
      private string Combo_veiculoidpercurso_Cls ;
      private string Combo_veiculoidpercurso_Selectedvalue_set ;
      private string Combo_veiculoidpercurso_Selectedtext_set ;
      private string Combo_veiculoidpercurso_Gamoauthtoken ;
      private string Combo_veiculoidpercurso_Datalistproc ;
      private string Combo_veiculoidpercurso_Datalistprocparametersprefix ;
      private string Dvpanel_cardpercurso_Width ;
      private string Dvpanel_cardpercurso_Cls ;
      private string Dvpanel_cardpercurso_Title ;
      private string Dvpanel_cardpercurso_Iconposition ;
      private string Gxuitabspanel_tabmenumapa_Class ;
      private string bttBtngerarpercurso_Caption ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Mapa_Internalname ;
      private string divTablemenumapa_Internalname ;
      private string Gxuitabspanel_tabmenumapa_Internalname ;
      private string lblTabveiculo_title_Internalname ;
      private string lblTabveiculo_title_Jsonclick ;
      private string divTblveiculos_Internalname ;
      private string divTblveiculo_Internalname ;
      private string sStyleString ;
      private string subGridveiculos_Internalname ;
      private string subGridveiculos_Header ;
      private string lblTabtrajetos_title_Internalname ;
      private string lblTabtrajetos_title_Jsonclick ;
      private string divTbltrajetos_Internalname ;
      private string divTbltrajeto_Internalname ;
      private string Dvpanel_cardpercurso_Internalname ;
      private string divCardpercurso_Internalname ;
      private string divTablesplittedveiculoidpercurso_Internalname ;
      private string lblTextblockcombo_veiculoidpercurso_Internalname ;
      private string lblTextblockcombo_veiculoidpercurso_Jsonclick ;
      private string Combo_veiculoidpercurso_Caption ;
      private string Combo_veiculoidpercurso_Internalname ;
      private string divUnnamedtabledatainiciopercurso_Internalname ;
      private string lblTextblockdatainiciopercurso_Internalname ;
      private string lblTextblockdatainiciopercurso_Jsonclick ;
      private string edtavDatainiciopercurso_Internalname ;
      private string TempTags ;
      private string edtavDatainiciopercurso_Jsonclick ;
      private string divUnnamedtabledatafimpercurso_Internalname ;
      private string lblTextblockdatafimpercurso_Internalname ;
      private string lblTextblockdatafimpercurso_Jsonclick ;
      private string edtavDatafimpercurso_Internalname ;
      private string edtavDatafimpercurso_Jsonclick ;
      private string divTablebotoes_Internalname ;
      private string bttBtngerarpercurso_Internalname ;
      private string bttBtngerarpercurso_Jsonclick ;
      private string bttBtnlimparpercurso_Internalname ;
      private string bttBtnlimparpercurso_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divGroupanimacao_Internalname ;
      private string divTableicons_Internalname ;
      private string lblIconreset_Internalname ;
      private string lblIconreset_Jsonclick ;
      private string lblIconplay_Internalname ;
      private string lblIconplay_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavVeiculoidpercurso_Internalname ;
      private string edtavVeiculoidpercurso_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string Dvpanel_cardveiculo_Width ;
      private string Dvpanel_cardveiculo_Internalname ;
      private string Dvpanel_cardveiculo_Cls ;
      private string Dvpanel_cardveiculo_Title ;
      private string Dvpanel_cardveiculo_Iconposition ;
      private string edtavSdtveiculosmapa__placa_Internalname ;
      private string edtavSdtveiculosmapa__marcamodelo_Internalname ;
      private string sGXsfl_32_fel_idx="0001" ;
      private string edtavSdtveiculosmapa__veiculoid_Internalname ;
      private string edtavSdtveiculosmapa__ignicao_Internalname ;
      private string lblIconignicao_Caption ;
      private string lblIconcar_Caption ;
      private string lblIconvisualizar_Caption ;
      private string AV55Udparg1 ;
      private string scmdbuf ;
      private string A105VeiculoGAMGUID ;
      private string AV9GAMGUID ;
      private string lblIconcar_Internalname ;
      private string lblIconvisualizar_Internalname ;
      private string lblIconignicao_Internalname ;
      private string subGridveiculos_Class ;
      private string subGridveiculos_Linesclass ;
      private string divUnnamedtablefsgridveiculos_Internalname ;
      private string divCardveiculo_Internalname ;
      private string lblIconcar_Jsonclick ;
      private string divTbldados_Internalname ;
      private string ROClassString ;
      private string edtavSdtveiculosmapa__placa_Jsonclick ;
      private string edtavSdtveiculosmapa__marcamodelo_Jsonclick ;
      private string lblIconvisualizar_Jsonclick ;
      private string lblIconignicao_Jsonclick ;
      private string tblUnnamedtablecontentfsgridveiculos_Internalname ;
      private string edtavSdtveiculosmapa__veiculoid_Jsonclick ;
      private string edtavSdtveiculosmapa__ignicao_Jsonclick ;
      private DateTime AV27HoraGPS ;
      private DateTime AV30DataInicioPercurso ;
      private DateTime AV31DataFimPercurso ;
      private DateTime A120UltimoDadoLidoDataHoraRastreador ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV33IsRotaNoMapa ;
      private bool Dvpanel_cardpercurso_Autowidth ;
      private bool Dvpanel_cardpercurso_Autoheight ;
      private bool Dvpanel_cardpercurso_Collapsible ;
      private bool Dvpanel_cardpercurso_Collapsed ;
      private bool Dvpanel_cardpercurso_Showcollapseicon ;
      private bool Dvpanel_cardpercurso_Autoscroll ;
      private bool Gxuitabspanel_tabmenumapa_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool Dvpanel_cardveiculo_Autowidth ;
      private bool Dvpanel_cardveiculo_Autoheight ;
      private bool Dvpanel_cardveiculo_Collapsible ;
      private bool Dvpanel_cardveiculo_Collapsed ;
      private bool Dvpanel_cardveiculo_Showcollapseicon ;
      private bool Dvpanel_cardveiculo_Autoscroll ;
      private bool bGXsfl_32_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV32IsAnimacaoIniciada ;
      private bool AV23AtualizarMapa ;
      private bool AV46IsAdministrator ;
      private bool gx_BV32 ;
      private string AV15HTMLBalao ;
      private string AV25Placa ;
      private string AV26Ignicao ;
      private string AV28LatLong ;
      private string AV35ClientIdSocket ;
      private string A100VeiculoPlaca ;
      private string A101VeiculoTipo ;
      private string A103VeiculoModelo ;
      private string A102VeiculoMarca ;
      private string AV11VeiculoPlaca ;
      private string A121UltimoDadoLidoPlaca ;
      private string A124UltimoDadoLidoLongitude ;
      private string A123UltimoDadoLidoLatitude ;
      private string A127UltimoDadoLidoGeolocalizacao ;
      private GXWebGrid GridveiculosContainer ;
      private GXWebRow GridveiculosRow ;
      private GXWebColumn GridveiculosColumn ;
      private GXUserControl ucMapa ;
      private GXUserControl ucGxuitabspanel_tabmenumapa ;
      private GXUserControl ucDvpanel_cardpercurso ;
      private GXUserControl ucCombo_veiculoidpercurso ;
      private GXUserControl ucDvpanel_cardveiculo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H002D2_A105VeiculoGAMGUID ;
      private int[] H002D2_A98VeiculoId ;
      private string[] H002D2_A100VeiculoPlaca ;
      private string[] H002D3_A105VeiculoGAMGUID ;
      private string[] H002D3_A101VeiculoTipo ;
      private string[] H002D3_A100VeiculoPlaca ;
      private string[] H002D3_A103VeiculoModelo ;
      private string[] H002D3_A102VeiculoMarca ;
      private int[] H002D3_A98VeiculoId ;
      private string[] H002D4_A121UltimoDadoLidoPlaca ;
      private short[] H002D4_A122UltimoDadoLidoIgnicao ;
      private int[] H002D4_A118UltimoDadoLidoId ;
      private DateTime[] H002D4_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] H002D4_A124UltimoDadoLidoLongitude ;
      private string[] H002D4_A123UltimoDadoLidoLatitude ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV44VeiculoIdPercurso_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV42GAMErrors ;
      private GXBaseCollection<SdtPolyline_PolylineItem> AV37PolylineCollection ;
      private GXBaseCollection<SdtPontosMapa_PontosMapaItem> AV12PontosMapa ;
      private GXBaseCollection<SdtSDTVeiculosMapa_SDTVeiculosMapaItem> AV7SDTVeiculosMapa ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV39DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV41GAMSession ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV18NotificationInfo ;
      private SdtPontosMapa_PontosMapaItem AV13PontosMapaItem ;
      private SdtSDTNovaPosicao AV20SDTNovaPosicao ;
      private SdtSDTVeiculosMapa_SDTVeiculosMapaItem AV10SDTVeiculosMapaItem ;
      private GeneXus.Core.genexus.server.SdtSocket AV36Socket ;
      private SdtSDTErroRastreamento AV45SDTErroRastreamento ;
   }

   public class mapa__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002D3( IGxContext context ,
                                             bool AV46IsAdministrator ,
                                             string A105VeiculoGAMGUID ,
                                             string AV9GAMGUID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [VeiculoGAMGUID], [VeiculoTipo], [VeiculoPlaca], [VeiculoModelo], [VeiculoMarca], [VeiculoId] FROM ( SELECT TOP(100) PERCENT T2.[VeiculoGAMGUID], T2.[VeiculoTipo], T2.[VeiculoPlaca], T2.[VeiculoModelo], T2.[VeiculoMarca], T1.[VeiculoId] FROM ([VeiculoRastreador] T1 INNER JOIN [Veiculo] T2 ON T2.[VeiculoId] = T1.[VeiculoId])";
         if ( ! AV46IsAdministrator )
         {
            AddWhere(sWhereString, "(T2.[VeiculoGAMGUID] = @AV9GAMGUID)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VeiculoId]";
         scmdbuf += ") DistinctT";
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
               case 1 :
                     return conditional_H002D3(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002D2;
          prmH002D2 = new Object[] {
          new Object[] {"@AV43VeiculoIdPercurso",SqlDbType.Int,8,0} ,
          new Object[] {"@AV55Udparg1",SqlDbType.NChar,40,0}
          };
          Object[] prmH002D4;
          prmH002D4 = new Object[] {
          new Object[] {"@AV11VeiculoPlaca",SqlDbType.NVarChar,7,0}
          };
          Object[] prmH002D3;
          prmH002D3 = new Object[] {
          new Object[] {"@AV9GAMGUID",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("H002D2", "SELECT TOP 1 [VeiculoGAMGUID], [VeiculoId], [VeiculoPlaca] FROM [Veiculo] WHERE ([VeiculoId] = @AV43VeiculoIdPercurso) AND ([VeiculoGAMGUID] = @AV55Udparg1) ORDER BY [VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002D4", "SELECT TOP 1 [UltimoDadoLidoPlaca], [UltimoDadoLidoIgnicao], [UltimoDadoLidoId], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoLongitude], [UltimoDadoLidoLatitude] FROM [UltimoDadoLido] WHERE [UltimoDadoLidoPlaca] = @AV11VeiculoPlaca ORDER BY [UltimoDadoLidoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D4,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                table[0][0] = rslt.getString(1, 40);
                table[1][0] = rslt.getVarchar(2);
                table[2][0] = rslt.getVarchar(3);
                table[3][0] = rslt.getVarchar(4);
                table[4][0] = rslt.getVarchar(5);
                table[5][0] = rslt.getInt(6);
                return;
             case 2 :
                table[0][0] = rslt.getVarchar(1);
                table[1][0] = rslt.getShort(2);
                table[2][0] = rslt.getInt(3);
                table[3][0] = rslt.getGXDateTime(4);
                table[4][0] = rslt.getVarchar(5);
                table[5][0] = rslt.getVarchar(6);
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
                stmt.SetParameter(1, (int)parms[0]);
                stmt.SetParameter(2, (string)parms[1]);
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[1]);
                }
                return;
             case 2 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
       }
    }

 }

}
