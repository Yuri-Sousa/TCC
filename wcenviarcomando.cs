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
   public class wcenviarcomando : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wcenviarcomando( )
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

      public wcenviarcomando( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_RastreadorId )
      {
         this.AV19RastreadorId = aP0_RastreadorId;
         executePrivate();
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
         cmbavComandofabricantemodulo = new GXCombobox();
         cmbavComandomodelomodulo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "RastreadorId");
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
                  AV19RastreadorId = (int)(NumberUtil.Val( GetPar( "RastreadorId"), "."));
                  AssignAttri(sPrefix, false, "AV19RastreadorId", StringUtil.LTrimStr( (decimal)(AV19RastreadorId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV19RastreadorId});
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
                  gxfirstwebparm = GetFirstPar( "RastreadorId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "RastreadorId");
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
            PA2W2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               cmbavComandofabricantemodulo.Enabled = 0;
               AssignProp(sPrefix, false, cmbavComandofabricantemodulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavComandofabricantemodulo.Enabled), 5, 0), true);
               cmbavComandomodelomodulo.Enabled = 0;
               AssignProp(sPrefix, false, cmbavComandomodelomodulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavComandomodelomodulo.Enabled), 5, 0), true);
               WS2W2( ) ;
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
            context.SendWebValue( "Enviar Comando") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021429183710", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcenviarcomando.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV19RastreadorId,8,0))}, new string[] {"RastreadorId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRASTREADORSNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV21RastreadorSNumber), "ZZZZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMANDOID_DATA", AV11ComandoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMANDOID_DATA", AV11ComandoId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV19RastreadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV19RastreadorId), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV10CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMANDOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137ComandoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMANDOPAYLOAD", A142ComandoPayload);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMANDOPARAMETER_ID", A143ComandoParameter_Id);
         GxWebStd.gx_hidden_field( context, sPrefix+"vRASTREADORSNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21RastreadorSNumber), 16, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRASTREADORSNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV21RastreadorSNumber), "ZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMANDONOME", A138ComandoNome);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vSUCESSO", AV24Sucesso);
         GxWebStd.gx_hidden_field( context, sPrefix+"vRASTREADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RastreadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOMANDONOME", AV22ComandoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOMANDOPAYLOAD", AV18ComandoPayload);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMANDOENVIADO", AV28ComandoEnviado);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMANDOENVIADO", AV28ComandoEnviado);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Cls", StringUtil.RTrim( Combo_comandoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Selectedvalue_set", StringUtil.RTrim( Combo_comandoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Selectedtext_set", StringUtil.RTrim( Combo_comandoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Gamoauthtoken", StringUtil.RTrim( Combo_comandoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Datalistproc", StringUtil.RTrim( Combo_comandoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_comandoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Width", StringUtil.RTrim( Dvpanel_tableenvio_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Autowidth", StringUtil.BoolToStr( Dvpanel_tableenvio_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Autoheight", StringUtil.BoolToStr( Dvpanel_tableenvio_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Cls", StringUtil.RTrim( Dvpanel_tableenvio_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Title", StringUtil.RTrim( Dvpanel_tableenvio_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Collapsible", StringUtil.BoolToStr( Dvpanel_tableenvio_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Collapsed", StringUtil.BoolToStr( Dvpanel_tableenvio_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableenvio_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Iconposition", StringUtil.RTrim( Dvpanel_tableenvio_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEENVIO_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableenvio_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Ddointernalname", StringUtil.RTrim( Combo_comandoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Selectedvalue_get", StringUtil.RTrim( Combo_comandoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Ddointernalname", StringUtil.RTrim( Combo_comandoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_COMANDOID_Selectedvalue_get", StringUtil.RTrim( Combo_comandoid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm2W2( )
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
         return "WCEnviarComando" ;
      }

      public override string GetPgmdesc( )
      {
         return "Enviar Comando" ;
      }

      protected void WB2W0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcenviarcomando.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableenvio.SetProperty("Width", Dvpanel_tableenvio_Width);
            ucDvpanel_tableenvio.SetProperty("AutoWidth", Dvpanel_tableenvio_Autowidth);
            ucDvpanel_tableenvio.SetProperty("AutoHeight", Dvpanel_tableenvio_Autoheight);
            ucDvpanel_tableenvio.SetProperty("Cls", Dvpanel_tableenvio_Cls);
            ucDvpanel_tableenvio.SetProperty("Title", Dvpanel_tableenvio_Title);
            ucDvpanel_tableenvio.SetProperty("Collapsible", Dvpanel_tableenvio_Collapsible);
            ucDvpanel_tableenvio.SetProperty("Collapsed", Dvpanel_tableenvio_Collapsed);
            ucDvpanel_tableenvio.SetProperty("ShowCollapseIcon", Dvpanel_tableenvio_Showcollapseicon);
            ucDvpanel_tableenvio.SetProperty("IconPosition", Dvpanel_tableenvio_Iconposition);
            ucDvpanel_tableenvio.SetProperty("AutoScroll", Dvpanel_tableenvio_Autoscroll);
            ucDvpanel_tableenvio.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableenvio_Internalname, sPrefix+"DVPANEL_TABLEENVIOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEENVIOContainer"+"TableEnvio"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableenvio_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavComandofabricantemodulo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavComandofabricantemodulo_Internalname, "Fabricante", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavComandofabricantemodulo, cmbavComandofabricantemodulo_Internalname, StringUtil.RTrim( AV7ComandoFabricanteModulo), 1, cmbavComandofabricantemodulo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavComandofabricantemodulo.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, "HLP_WCEnviarComando.htm");
            cmbavComandofabricantemodulo.CurrentValue = StringUtil.RTrim( AV7ComandoFabricanteModulo);
            AssignProp(sPrefix, false, cmbavComandofabricantemodulo_Internalname, "Values", (string)(cmbavComandofabricantemodulo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavComandomodelomodulo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavComandomodelomodulo_Internalname, "Modelo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavComandomodelomodulo, cmbavComandomodelomodulo_Internalname, StringUtil.RTrim( AV8ComandoModeloModulo), 1, cmbavComandomodelomodulo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavComandomodelomodulo.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, "HLP_WCEnviarComando.htm");
            cmbavComandomodelomodulo.CurrentValue = StringUtil.RTrim( AV8ComandoModeloModulo);
            AssignProp(sPrefix, false, cmbavComandomodelomodulo_Internalname, "Values", (string)(cmbavComandomodelomodulo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Required ExtendedComboCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcomandoid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_comandoid_Internalname, "Comando", "", "", lblTextblockcombo_comandoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WCEnviarComando.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_comandoid.SetProperty("Caption", Combo_comandoid_Caption);
            ucCombo_comandoid.SetProperty("Cls", Combo_comandoid_Cls);
            ucCombo_comandoid.SetProperty("DataListProc", Combo_comandoid_Datalistproc);
            ucCombo_comandoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_comandoid.SetProperty("DropDownOptionsData", AV11ComandoId_Data);
            ucCombo_comandoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_comandoid_Internalname, sPrefix+"COMBO_COMANDOIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenviarcomando_Internalname, "", "Enviar Comando", bttBtnenviarcomando_Jsonclick, 5, "Enviar Comando", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOENVIARCOMANDO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WCEnviarComando.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavComandoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ComandoId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9ComandoId), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComandoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComandoid_Visible, 1, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WCEnviarComando.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2W2( )
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
               Form.Meta.addItem("description", "Enviar Comando", 0) ;
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
               STRUP2W0( ) ;
            }
         }
      }

      protected void WS2W2( )
      {
         START2W2( ) ;
         EVT2W2( ) ;
      }

      protected void EVT2W2( )
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
                                 STRUP2W0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_COMANDOID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E112W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOENVIARCOMANDO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoEnviarComando' */
                                    E132W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E142W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2W0( ) ;
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
                                 STRUP2W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavComandofabricantemodulo_Internalname;
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

      protected void WE2W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2W2( ) ;
            }
         }
      }

      protected void PA2W2( )
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
               GX_FocusControl = cmbavComandofabricantemodulo_Internalname;
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
         if ( cmbavComandofabricantemodulo.ItemCount > 0 )
         {
            AV7ComandoFabricanteModulo = cmbavComandofabricantemodulo.getValidValue(AV7ComandoFabricanteModulo);
            AssignAttri(sPrefix, false, "AV7ComandoFabricanteModulo", AV7ComandoFabricanteModulo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavComandofabricantemodulo.CurrentValue = StringUtil.RTrim( AV7ComandoFabricanteModulo);
            AssignProp(sPrefix, false, cmbavComandofabricantemodulo_Internalname, "Values", cmbavComandofabricantemodulo.ToJavascriptSource(), true);
         }
         if ( cmbavComandomodelomodulo.ItemCount > 0 )
         {
            AV8ComandoModeloModulo = cmbavComandomodelomodulo.getValidValue(AV8ComandoModeloModulo);
            AssignAttri(sPrefix, false, "AV8ComandoModeloModulo", AV8ComandoModeloModulo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavComandomodelomodulo.CurrentValue = StringUtil.RTrim( AV8ComandoModeloModulo);
            AssignProp(sPrefix, false, cmbavComandomodelomodulo_Internalname, "Values", cmbavComandomodelomodulo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavComandofabricantemodulo.Enabled = 0;
         AssignProp(sPrefix, false, cmbavComandofabricantemodulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavComandofabricantemodulo.Enabled), 5, 0), true);
         cmbavComandomodelomodulo.Enabled = 0;
         AssignProp(sPrefix, false, cmbavComandomodelomodulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavComandomodelomodulo.Enabled), 5, 0), true);
      }

      protected void RF2W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E142W2 ();
            WB2W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2W2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vRASTREADORSNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21RastreadorSNumber), 16, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRASTREADORSNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV21RastreadorSNumber), "ZZZZZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         cmbavComandofabricantemodulo.Enabled = 0;
         AssignProp(sPrefix, false, cmbavComandofabricantemodulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavComandofabricantemodulo.Enabled), 5, 0), true);
         cmbavComandomodelomodulo.Enabled = 0;
         AssignProp(sPrefix, false, cmbavComandomodelomodulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavComandomodelomodulo.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122W2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV12DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOMANDOID_DATA"), AV11ComandoId_Data);
            /* Read saved values. */
            wcpOAV19RastreadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19RastreadorId"), ",", "."));
            Combo_comandoid_Cls = cgiGet( sPrefix+"COMBO_COMANDOID_Cls");
            Combo_comandoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_COMANDOID_Selectedvalue_set");
            Combo_comandoid_Selectedtext_set = cgiGet( sPrefix+"COMBO_COMANDOID_Selectedtext_set");
            Combo_comandoid_Gamoauthtoken = cgiGet( sPrefix+"COMBO_COMANDOID_Gamoauthtoken");
            Combo_comandoid_Datalistproc = cgiGet( sPrefix+"COMBO_COMANDOID_Datalistproc");
            Combo_comandoid_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_COMANDOID_Datalistprocparametersprefix");
            Dvpanel_tableenvio_Width = cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Width");
            Dvpanel_tableenvio_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Autowidth"));
            Dvpanel_tableenvio_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Autoheight"));
            Dvpanel_tableenvio_Cls = cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Cls");
            Dvpanel_tableenvio_Title = cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Title");
            Dvpanel_tableenvio_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Collapsible"));
            Dvpanel_tableenvio_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Collapsed"));
            Dvpanel_tableenvio_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Showcollapseicon"));
            Dvpanel_tableenvio_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Iconposition");
            Dvpanel_tableenvio_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEENVIO_Autoscroll"));
            Combo_comandoid_Ddointernalname = cgiGet( sPrefix+"COMBO_COMANDOID_Ddointernalname");
            Combo_comandoid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_COMANDOID_Selectedvalue_get");
            /* Read variables values. */
            cmbavComandofabricantemodulo.CurrentValue = cgiGet( cmbavComandofabricantemodulo_Internalname);
            AV7ComandoFabricanteModulo = cgiGet( cmbavComandofabricantemodulo_Internalname);
            AssignAttri(sPrefix, false, "AV7ComandoFabricanteModulo", AV7ComandoFabricanteModulo);
            cmbavComandomodelomodulo.CurrentValue = cgiGet( cmbavComandomodelomodulo_Internalname);
            AV8ComandoModeloModulo = cgiGet( cmbavComandomodelomodulo_Internalname);
            AssignAttri(sPrefix, false, "AV8ComandoModeloModulo", AV8ComandoModeloModulo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavComandoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavComandoid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOMANDOID");
               GX_FocusControl = edtavComandoid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9ComandoId = 0;
               AssignAttri(sPrefix, false, "AV9ComandoId", StringUtil.LTrimStr( (decimal)(AV9ComandoId), 8, 0));
            }
            else
            {
               AV9ComandoId = (int)(context.localUtil.CToN( cgiGet( edtavComandoid_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "AV9ComandoId", StringUtil.LTrimStr( (decimal)(AV9ComandoId), 8, 0));
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
         E122W2 ();
         if (returnInSub) return;
      }

      protected void E122W2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = AV34GAMGUID;
         new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
         AV34GAMGUID = GXt_char1;
         AssignAttri(sPrefix, false, "AV34GAMGUID", AV34GAMGUID);
         AV33IsAdministrator = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).checkrole("Administrator");
         AssignAttri(sPrefix, false, "AV33IsAdministrator", AV33IsAdministrator);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV33IsAdministrator ,
                                              A151RastreadorGAMGUIDProprietario ,
                                              AV34GAMGUID ,
                                              AV19RastreadorId ,
                                              A106RastreadorId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H002W2 */
         pr_default.execute(0, new Object[] {AV19RastreadorId, AV34GAMGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A151RastreadorGAMGUIDProprietario = H002W2_A151RastreadorGAMGUIDProprietario[0];
            A106RastreadorId = H002W2_A106RastreadorId[0];
            A111RastreadorDeviceIdFlespi = H002W2_A111RastreadorDeviceIdFlespi[0];
            A108RastreadorFabricante = H002W2_A108RastreadorFabricante[0];
            n108RastreadorFabricante = H002W2_n108RastreadorFabricante[0];
            A109RastreadorModelo = H002W2_A109RastreadorModelo[0];
            n109RastreadorModelo = H002W2_n109RastreadorModelo[0];
            A110RastreadorSNumber = H002W2_A110RastreadorSNumber[0];
            AV20RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            AV7ComandoFabricanteModulo = A108RastreadorFabricante;
            AssignAttri(sPrefix, false, "AV7ComandoFabricanteModulo", AV7ComandoFabricanteModulo);
            AV8ComandoModeloModulo = A109RastreadorModelo;
            AssignAttri(sPrefix, false, "AV8ComandoModeloModulo", AV8ComandoModeloModulo);
            AV21RastreadorSNumber = A110RastreadorSNumber;
            AssignAttri(sPrefix, false, "AV21RastreadorSNumber", StringUtil.LTrimStr( (decimal)(AV21RastreadorSNumber), 16, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRASTREADORSNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV21RastreadorSNumber), "ZZZZZZZZZZZZZZZ9"), context));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV12DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV12DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         AV14GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV15GAMErrors);
         Combo_comandoid_Gamoauthtoken = AV14GAMSession.gxTpr_Token;
         ucCombo_comandoid.SendProperty(context, sPrefix, false, Combo_comandoid_Internalname, "GAMOAuthToken", Combo_comandoid_Gamoauthtoken);
         edtavComandoid_Visible = 0;
         AssignProp(sPrefix, false, edtavComandoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComandoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCOMANDOID' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E132W2( )
      {
         /* 'DoEnviarComando' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV10CheckRequiredFieldsResult )
         {
            /* Execute user subroutine: 'ENVIARCOMANDO' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV28ComandoEnviado", AV28ComandoEnviado);
      }

      protected void E112W2( )
      {
         /* Combo_comandoid_Onoptionclicked Routine */
         returnInSub = false;
         AV9ComandoId = (int)(NumberUtil.Val( Combo_comandoid_Selectedvalue_get, "."));
         AssignAttri(sPrefix, false, "AV9ComandoId", StringUtil.LTrimStr( (decimal)(AV9ComandoId), 8, 0));
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         if ( (0==AV9ComandoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Comando", "", "", "", "", "", "", "", ""),  "error",  Combo_comandoid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCOMANDOID' Routine */
         returnInSub = false;
         Combo_comandoid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"ComandoId\", \"Cond_ComandoModeloModulo\": \"#%1#\", \"Cond_ComandoFabricanteModulo\": \"#%2#\"", cmbavComandomodelomodulo_Internalname, cmbavComandofabricantemodulo_Internalname, "", "", "", "", "", "", "");
         ucCombo_comandoid.SendProperty(context, sPrefix, false, Combo_comandoid_Internalname, "DataListProcParametersPrefix", Combo_comandoid_Datalistprocparametersprefix);
         Combo_comandoid_Selectedtext_set = AV32ComandoIdDescription;
         ucCombo_comandoid.SendProperty(context, sPrefix, false, Combo_comandoid_Internalname, "SelectedText_set", Combo_comandoid_Selectedtext_set);
         Combo_comandoid_Selectedvalue_set = ((0==AV9ComandoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV9ComandoId), 8, 0)));
         ucCombo_comandoid.SendProperty(context, sPrefix, false, Combo_comandoid_Internalname, "SelectedValue_set", Combo_comandoid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'ENVIARCOMANDO' Routine */
         returnInSub = false;
         AV16SDTComandos = new GXBaseCollection<SdtSDTComandos_SDTComandosItem>( context, "SDTComandosItem", "RastreamentoTCC");
         /* Using cursor H002W3 */
         pr_default.execute(1, new Object[] {AV9ComandoId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A137ComandoId = H002W3_A137ComandoId[0];
            A142ComandoPayload = H002W3_A142ComandoPayload[0];
            A143ComandoParameter_Id = H002W3_A143ComandoParameter_Id[0];
            A138ComandoNome = H002W3_A138ComandoNome[0];
            AV17SDTComandosItem = new SdtSDTComandos_SDTComandosItem(context);
            AV18ComandoPayload = A142ComandoPayload;
            AssignAttri(sPrefix, false, "AV18ComandoPayload", AV18ComandoPayload);
            AV17SDTComandosItem.gxTpr_Properties.gxTpr_Parameter_id = A143ComandoParameter_Id;
            AV17SDTComandosItem.gxTpr_Properties.gxTpr_Payload = AV18ComandoPayload;
            AV17SDTComandosItem.gxTpr_Address.gxTpr_Ident = StringUtil.Trim( StringUtil.Str( (decimal)(AV21RastreadorSNumber), 16, 0));
            AV17SDTComandosItem.gxTpr_Address.gxTpr_Type = "connection";
            AV17SDTComandosItem.gxTpr_Name = "custom_binary";
            AV17SDTComandosItem.gxTpr_Ttl = 86400;
            AV16SDTComandos.Add(AV17SDTComandosItem, 0);
            AV22ComandoNome = StringUtil.Trim( A138ComandoNome);
            AssignAttri(sPrefix, false, "AV22ComandoNome", AV22ComandoNome);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         new enviarcomandorastreador(context ).execute(  "9278",  AV16SDTComandos.ToJSonString(false), out  AV24Sucesso, out  AV25SDTResultadoEnvioComando_Canal) ;
         AssignAttri(sPrefix, false, "AV24Sucesso", AV24Sucesso);
         /* Execute user subroutine: 'MENSAGEMRETORNO' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S142( )
      {
         /* 'MENSAGEMRETORNO' Routine */
         returnInSub = false;
         if ( AV24Sucesso )
         {
            GX_msglist.addItem("Comando enviado com sucesso!");
            /* Execute user subroutine: 'SALVAENVIOCOMANDOS' */
            S152 ();
            if (returnInSub) return;
         }
         else
         {
            GX_msglist.addItem("Ocorreu um erro no envio do comando");
         }
      }

      protected void S152( )
      {
         /* 'SALVAENVIOCOMANDOS' Routine */
         returnInSub = false;
         AV28ComandoEnviado = new SdtComandoEnviado(context);
         AV28ComandoEnviado.gxTpr_Rastreadorid = AV19RastreadorId;
         /* Execute user subroutine: 'PREENCHECOMANDOENVIADO' */
         S162 ();
         if (returnInSub) return;
         AV28ComandoEnviado.Insert();
         if ( AV28ComandoEnviado.Success() )
         {
            context.CommitDataStores("wcenviarcomando",pr_default);
         }
         else
         {
            context.RollbackDataStores("wcenviarcomando",pr_default);
            new GeneXus.Core.genexus.common.SdtLog(context).debug(AV28ComandoEnviado.GetMessages().ToJSonString(false), "Erro ao salvar o envio do comando") ;
         }
      }

      protected void S162( )
      {
         /* 'PREENCHECOMANDOENVIADO' Routine */
         returnInSub = false;
         AV29ComandoEnviadoComando = new SdtComandoEnviado_Comando(context);
         AV29ComandoEnviadoComando.gxTpr_Comandoenviadocomandocomando = AV22ComandoNome;
         AV29ComandoEnviadoComando.gxTpr_Comandoenviadocomandovalor = AV18ComandoPayload;
         AV28ComandoEnviado.gxTpr_Comando.Add(AV29ComandoEnviadoComando, 0);
      }

      protected void nextLoad( )
      {
      }

      protected void E142W2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV19RastreadorId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV19RastreadorId", StringUtil.LTrimStr( (decimal)(AV19RastreadorId), 8, 0));
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
         PA2W2( ) ;
         WS2W2( ) ;
         WE2W2( ) ;
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
         sCtrlAV19RastreadorId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2W2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcenviarcomando", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2W2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV19RastreadorId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV19RastreadorId", StringUtil.LTrimStr( (decimal)(AV19RastreadorId), 8, 0));
         }
         wcpOAV19RastreadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19RastreadorId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV19RastreadorId != wcpOAV19RastreadorId ) ) )
         {
            setjustcreated();
         }
         wcpOAV19RastreadorId = AV19RastreadorId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV19RastreadorId = cgiGet( sPrefix+"AV19RastreadorId_CTRL");
         if ( StringUtil.Len( sCtrlAV19RastreadorId) > 0 )
         {
            AV19RastreadorId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV19RastreadorId), ",", "."));
            AssignAttri(sPrefix, false, "AV19RastreadorId", StringUtil.LTrimStr( (decimal)(AV19RastreadorId), 8, 0));
         }
         else
         {
            AV19RastreadorId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV19RastreadorId_PARM"), ",", "."));
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
         PA2W2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2W2( ) ;
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
         WS2W2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV19RastreadorId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RastreadorId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV19RastreadorId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV19RastreadorId_CTRL", StringUtil.RTrim( sCtrlAV19RastreadorId));
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
         WE2W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214291837536", true, true);
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
         context.AddJavascriptSource("wcenviarcomando.js", "?20214291837537", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavComandofabricantemodulo.Name = "vCOMANDOFABRICANTEMODULO";
         cmbavComandofabricantemodulo.WebTags = "";
         cmbavComandofabricantemodulo.addItem("", "Selecione", 0);
         cmbavComandofabricantemodulo.addItem("Maxtrack", "Maxtrack", 0);
         if ( cmbavComandofabricantemodulo.ItemCount > 0 )
         {
         }
         cmbavComandomodelomodulo.Name = "vCOMANDOMODELOMODULO";
         cmbavComandomodelomodulo.WebTags = "";
         cmbavComandomodelomodulo.addItem("", "Selecione", 0);
         cmbavComandomodelomodulo.addItem("MXT140", "MXT140", 0);
         if ( cmbavComandomodelomodulo.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavComandofabricantemodulo_Internalname = sPrefix+"vCOMANDOFABRICANTEMODULO";
         cmbavComandomodelomodulo_Internalname = sPrefix+"vCOMANDOMODELOMODULO";
         lblTextblockcombo_comandoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_COMANDOID";
         Combo_comandoid_Internalname = sPrefix+"COMBO_COMANDOID";
         divTablesplittedcomandoid_Internalname = sPrefix+"TABLESPLITTEDCOMANDOID";
         bttBtnenviarcomando_Internalname = sPrefix+"BTNENVIARCOMANDO";
         divTableenvio_Internalname = sPrefix+"TABLEENVIO";
         Dvpanel_tableenvio_Internalname = sPrefix+"DVPANEL_TABLEENVIO";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavComandoid_Internalname = sPrefix+"vCOMANDOID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
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
         edtavComandoid_Jsonclick = "";
         edtavComandoid_Visible = 1;
         Combo_comandoid_Caption = "";
         cmbavComandomodelomodulo_Jsonclick = "";
         cmbavComandomodelomodulo.Enabled = 1;
         cmbavComandofabricantemodulo_Jsonclick = "";
         cmbavComandofabricantemodulo.Enabled = 1;
         Dvpanel_tableenvio_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableenvio_Iconposition = "Right";
         Dvpanel_tableenvio_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableenvio_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableenvio_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableenvio_Title = "Opções";
         Dvpanel_tableenvio_Cls = "PanelNoHeader";
         Dvpanel_tableenvio_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableenvio_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableenvio_Width = "100%";
         Combo_comandoid_Datalistprocparametersprefix = "";
         Combo_comandoid_Datalistproc = "WCEnviarComandoLoadDVCombo";
         Combo_comandoid_Cls = "ExtendedCombo Attribute";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV21RastreadorSNumber',fld:'vRASTREADORSNUMBER',pic:'ZZZZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOENVIARCOMANDO'","{handler:'E132W2',iparms:[{av:'AV10CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV9ComandoId',fld:'vCOMANDOID',pic:'ZZZZZZZ9'},{av:'Combo_comandoid_Ddointernalname',ctrl:'COMBO_COMANDOID',prop:'DDOInternalName'},{av:'A137ComandoId',fld:'COMANDOID',pic:'ZZZZZZZ9'},{av:'A142ComandoPayload',fld:'COMANDOPAYLOAD',pic:''},{av:'A143ComandoParameter_Id',fld:'COMANDOPARAMETER_ID',pic:''},{av:'AV21RastreadorSNumber',fld:'vRASTREADORSNUMBER',pic:'ZZZZZZZZZZZZZZZ9',hsh:true},{av:'A138ComandoNome',fld:'COMANDONOME',pic:''},{av:'AV24Sucesso',fld:'vSUCESSO',pic:''},{av:'AV19RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV22ComandoNome',fld:'vCOMANDONOME',pic:''},{av:'AV18ComandoPayload',fld:'vCOMANDOPAYLOAD',pic:''},{av:'AV28ComandoEnviado',fld:'vCOMANDOENVIADO',pic:''}]");
         setEventMetadata("'DOENVIARCOMANDO'",",oparms:[{av:'AV10CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV18ComandoPayload',fld:'vCOMANDOPAYLOAD',pic:''},{av:'AV22ComandoNome',fld:'vCOMANDONOME',pic:''},{av:'AV24Sucesso',fld:'vSUCESSO',pic:''},{av:'AV28ComandoEnviado',fld:'vCOMANDOENVIADO',pic:''}]}");
         setEventMetadata("COMBO_COMANDOID.ONOPTIONCLICKED","{handler:'E112W2',iparms:[{av:'Combo_comandoid_Selectedvalue_get',ctrl:'COMBO_COMANDOID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_COMANDOID.ONOPTIONCLICKED",",oparms:[{av:'AV9ComandoId',fld:'vCOMANDOID',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALIDV_COMANDOFABRICANTEMODULO","{handler:'Validv_Comandofabricantemodulo',iparms:[]");
         setEventMetadata("VALIDV_COMANDOFABRICANTEMODULO",",oparms:[]}");
         setEventMetadata("VALIDV_COMANDOMODELOMODULO","{handler:'Validv_Comandomodelomodulo',iparms:[]");
         setEventMetadata("VALIDV_COMANDOMODELOMODULO",",oparms:[]}");
         setEventMetadata("VALIDV_COMANDOID","{handler:'Validv_Comandoid',iparms:[]");
         setEventMetadata("VALIDV_COMANDOID",",oparms:[]}");
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
         Combo_comandoid_Ddointernalname = "";
         Combo_comandoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11ComandoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A142ComandoPayload = "";
         A143ComandoParameter_Id = "";
         A138ComandoNome = "";
         AV22ComandoNome = "";
         AV18ComandoPayload = "";
         AV28ComandoEnviado = new SdtComandoEnviado(context);
         Combo_comandoid_Selectedvalue_set = "";
         Combo_comandoid_Selectedtext_set = "";
         Combo_comandoid_Gamoauthtoken = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableenvio = new GXUserControl();
         TempTags = "";
         AV7ComandoFabricanteModulo = "";
         AV8ComandoModeloModulo = "";
         lblTextblockcombo_comandoid_Jsonclick = "";
         ucCombo_comandoid = new GXUserControl();
         bttBtnenviarcomando_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV34GAMGUID = "";
         GXt_char1 = "";
         scmdbuf = "";
         A151RastreadorGAMGUIDProprietario = "";
         H002W2_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         H002W2_A106RastreadorId = new int[1] ;
         H002W2_A111RastreadorDeviceIdFlespi = new long[1] ;
         H002W2_A108RastreadorFabricante = new string[] {""} ;
         H002W2_n108RastreadorFabricante = new bool[] {false} ;
         H002W2_A109RastreadorModelo = new string[] {""} ;
         H002W2_n109RastreadorModelo = new bool[] {false} ;
         H002W2_A110RastreadorSNumber = new long[1] ;
         A108RastreadorFabricante = "";
         A109RastreadorModelo = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV15GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV32ComandoIdDescription = "";
         AV16SDTComandos = new GXBaseCollection<SdtSDTComandos_SDTComandosItem>( context, "SDTComandosItem", "RastreamentoTCC");
         H002W3_A137ComandoId = new int[1] ;
         H002W3_A142ComandoPayload = new string[] {""} ;
         H002W3_A143ComandoParameter_Id = new string[] {""} ;
         H002W3_A138ComandoNome = new string[] {""} ;
         AV17SDTComandosItem = new SdtSDTComandos_SDTComandosItem(context);
         AV25SDTResultadoEnvioComando_Canal = new SdtSDTResultadoEnvioComando_Canal(context);
         AV29ComandoEnviadoComando = new SdtComandoEnviado_Comando(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV19RastreadorId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wcenviarcomando__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcenviarcomando__default(),
            new Object[][] {
                new Object[] {
               H002W2_A151RastreadorGAMGUIDProprietario, H002W2_A106RastreadorId, H002W2_A111RastreadorDeviceIdFlespi, H002W2_A108RastreadorFabricante, H002W2_n108RastreadorFabricante, H002W2_A109RastreadorModelo, H002W2_n109RastreadorModelo, H002W2_A110RastreadorSNumber
               }
               , new Object[] {
               H002W3_A137ComandoId, H002W3_A142ComandoPayload, H002W3_A143ComandoParameter_Id, H002W3_A138ComandoNome
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavComandofabricantemodulo.Enabled = 0;
         cmbavComandomodelomodulo.Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
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
      private int AV19RastreadorId ;
      private int wcpOAV19RastreadorId ;
      private int A137ComandoId ;
      private int AV9ComandoId ;
      private int edtavComandoid_Visible ;
      private int A106RastreadorId ;
      private int idxLst ;
      private long AV21RastreadorSNumber ;
      private long A111RastreadorDeviceIdFlespi ;
      private long A110RastreadorSNumber ;
      private long AV20RastreadorDeviceIdFlespi ;
      private string Combo_comandoid_Ddointernalname ;
      private string Combo_comandoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string cmbavComandofabricantemodulo_Internalname ;
      private string cmbavComandomodelomodulo_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_comandoid_Cls ;
      private string Combo_comandoid_Selectedvalue_set ;
      private string Combo_comandoid_Selectedtext_set ;
      private string Combo_comandoid_Gamoauthtoken ;
      private string Combo_comandoid_Datalistproc ;
      private string Combo_comandoid_Datalistprocparametersprefix ;
      private string Dvpanel_tableenvio_Width ;
      private string Dvpanel_tableenvio_Cls ;
      private string Dvpanel_tableenvio_Title ;
      private string Dvpanel_tableenvio_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableenvio_Internalname ;
      private string divTableenvio_Internalname ;
      private string TempTags ;
      private string cmbavComandofabricantemodulo_Jsonclick ;
      private string cmbavComandomodelomodulo_Jsonclick ;
      private string divTablesplittedcomandoid_Internalname ;
      private string lblTextblockcombo_comandoid_Internalname ;
      private string lblTextblockcombo_comandoid_Jsonclick ;
      private string Combo_comandoid_Caption ;
      private string Combo_comandoid_Internalname ;
      private string bttBtnenviarcomando_Internalname ;
      private string bttBtnenviarcomando_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavComandoid_Internalname ;
      private string edtavComandoid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV34GAMGUID ;
      private string GXt_char1 ;
      private string scmdbuf ;
      private string A151RastreadorGAMGUIDProprietario ;
      private string sCtrlAV19RastreadorId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool AV24Sucesso ;
      private bool Dvpanel_tableenvio_Autowidth ;
      private bool Dvpanel_tableenvio_Autoheight ;
      private bool Dvpanel_tableenvio_Collapsible ;
      private bool Dvpanel_tableenvio_Collapsed ;
      private bool Dvpanel_tableenvio_Showcollapseicon ;
      private bool Dvpanel_tableenvio_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV33IsAdministrator ;
      private bool n108RastreadorFabricante ;
      private bool n109RastreadorModelo ;
      private string A142ComandoPayload ;
      private string AV18ComandoPayload ;
      private string A143ComandoParameter_Id ;
      private string A138ComandoNome ;
      private string AV22ComandoNome ;
      private string AV7ComandoFabricanteModulo ;
      private string AV8ComandoModeloModulo ;
      private string A108RastreadorFabricante ;
      private string A109RastreadorModelo ;
      private string AV32ComandoIdDescription ;
      private GXUserControl ucDvpanel_tableenvio ;
      private GXUserControl ucCombo_comandoid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavComandofabricantemodulo ;
      private GXCombobox cmbavComandomodelomodulo ;
      private IDataStoreProvider pr_default ;
      private string[] H002W2_A151RastreadorGAMGUIDProprietario ;
      private int[] H002W2_A106RastreadorId ;
      private long[] H002W2_A111RastreadorDeviceIdFlespi ;
      private string[] H002W2_A108RastreadorFabricante ;
      private bool[] H002W2_n108RastreadorFabricante ;
      private string[] H002W2_A109RastreadorModelo ;
      private bool[] H002W2_n109RastreadorModelo ;
      private long[] H002W2_A110RastreadorSNumber ;
      private int[] H002W3_A137ComandoId ;
      private string[] H002W3_A142ComandoPayload ;
      private string[] H002W3_A143ComandoParameter_Id ;
      private string[] H002W3_A138ComandoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11ComandoId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV15GAMErrors ;
      private GXBaseCollection<SdtSDTComandos_SDTComandosItem> AV16SDTComandos ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV12DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV14GAMSession ;
      private SdtSDTComandos_SDTComandosItem AV17SDTComandosItem ;
      private SdtSDTResultadoEnvioComando_Canal AV25SDTResultadoEnvioComando_Canal ;
      private SdtComandoEnviado AV28ComandoEnviado ;
      private SdtComandoEnviado_Comando AV29ComandoEnviadoComando ;
   }

   public class wcenviarcomando__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wcenviarcomando__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H002W2( IGxContext context ,
                                           bool AV33IsAdministrator ,
                                           string A151RastreadorGAMGUIDProprietario ,
                                           string AV34GAMGUID ,
                                           int AV19RastreadorId ,
                                           int A106RastreadorId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int3 = new short[2];
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT TOP 1 [RastreadorGAMGUIDProprietario], [RastreadorId], [RastreadorDeviceIdFlespi], [RastreadorFabricante], [RastreadorModelo], [RastreadorSNumber] FROM [Rastreador]";
       AddWhere(sWhereString, "([RastreadorId] = @AV19RastreadorId)");
       if ( ! AV33IsAdministrator )
       {
          AddWhere(sWhereString, "([RastreadorGAMGUIDProprietario] = @AV34GAMGUID)");
       }
       else
       {
          GXv_int3[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [RastreadorId]";
       GXv_Object4[0] = scmdbuf;
       GXv_Object4[1] = GXv_int3;
       return GXv_Object4 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H002W2(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH002W3;
        prmH002W3 = new Object[] {
        new Object[] {"@AV9ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmH002W2;
        prmH002W2 = new Object[] {
        new Object[] {"@AV19RastreadorId",SqlDbType.Int,8,0} ,
        new Object[] {"@AV34GAMGUID",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("H002W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H002W3", "SELECT TOP 1 [ComandoId], [ComandoPayload], [ComandoParameter_Id], [ComandoNome] FROM [Comando] WHERE [ComandoId] = @AV9ComandoId ORDER BY [ComandoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W3,1, GxCacheFrequency.OFF ,false,true )
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
              table[2][0] = rslt.getLong(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
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
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
