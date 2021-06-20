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
   public class comandoenviado : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"COMANDOENVIADORESPONSAVELGUID") == 0 )
         {
            Gx_BScreen = (short)(NumberUtil.Val( GetPar( "Gx_BScreen"), "."));
            AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASACOMANDOENVIADORESPONSAVELGUID0N24( Gx_BScreen, Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A106RastreadorId = (int)(NumberUtil.Val( GetPar( "RastreadorId"), "."));
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A106RastreadorId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_comando") == 0 )
         {
            nRC_GXsfl_52 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_52"), "."));
            nGXsfl_52_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_52_idx"), "."));
            sGXsfl_52_idx = GetPar( "sGXsfl_52_idx");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridlevel_comando_newrow( ) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7ComandoEnviadoId = (int)(NumberUtil.Val( GetPar( "ComandoEnviadoId"), "."));
               AssignAttri("", false, "AV7ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(AV7ComandoEnviadoId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCOMANDOENVIADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComandoEnviadoId), "ZZZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148565", 0) ;
            }
            Form.Meta.addItem("description", "Comando Enviado", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRastreadorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public comandoenviado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public comandoenviado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ComandoEnviadoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ComandoEnviadoId = aP1_ComandoEnviadoId;
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
            return "comandoenviado_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoEnviadoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoEnviadoId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtComandoEnviadoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A144ComandoEnviadoId), 8, 0, ",", "")), ((edtComandoEnviadoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A144ComandoEnviadoId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A144ComandoEnviadoId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoEnviadoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComandoEnviadoId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoEnviadoResponsavelGUID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoEnviadoResponsavelGUID_Internalname, "GUID do Responsável", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtComandoEnviadoResponsavelGUID_Internalname, StringUtil.RTrim( A145ComandoEnviadoResponsavelGUID), StringUtil.RTrim( context.localUtil.Format( A145ComandoEnviadoResponsavelGUID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoEnviadoResponsavelGUID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComandoEnviadoResponsavelGUID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoEnviadoDataHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoEnviadoDataHora_Internalname, "Data/Hora do Envio", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtComandoEnviadoDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComandoEnviadoDataHora_Internalname, context.localUtil.TToC( A146ComandoEnviadoDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A146ComandoEnviadoDataHora, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoEnviadoDataHora_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtComandoEnviadoDataHora_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ComandoEnviado.htm");
         GxWebStd.gx_bitmap( context, edtComandoEnviadoDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComandoEnviadoDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ComandoEnviado.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedrastreadorid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockrastreadorid_Internalname, "Sequência do Rastreador", "", "", lblTextblockrastreadorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_rastreadorid.SetProperty("Caption", Combo_rastreadorid_Caption);
         ucCombo_rastreadorid.SetProperty("Cls", Combo_rastreadorid_Cls);
         ucCombo_rastreadorid.SetProperty("DataListProc", Combo_rastreadorid_Datalistproc);
         ucCombo_rastreadorid.SetProperty("DataListProcParametersPrefix", Combo_rastreadorid_Datalistprocparametersprefix);
         ucCombo_rastreadorid.SetProperty("EmptyItem", Combo_rastreadorid_Emptyitem);
         ucCombo_rastreadorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_rastreadorid.SetProperty("DropDownOptionsData", AV15RastreadorId_Data);
         ucCombo_rastreadorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_rastreadorid_Internalname, "COMBO_RASTREADORIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRastreadorId_Internalname, "Sequência", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRastreadorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106RastreadorId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A106RastreadorId), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRastreadorId_Jsonclick, 0, "Attribute", "", "", "", "", edtRastreadorId_Visible, edtRastreadorId_Enabled, 1, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRastreadorSNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRastreadorSNumber_Internalname, "ID do Rastreador", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRastreadorSNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110RastreadorSNumber), 16, 0, ",", "")), ((edtRastreadorSNumber_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A110RastreadorSNumber), "ZZZZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A110RastreadorSNumber), "ZZZZZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRastreadorSNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRastreadorSNumber_Enabled, 0, "number", "1", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ComandoEnviado.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_comando_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "left", "top", "", "", "div");
         gxdraw_Gridlevel_comando( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComandoEnviado.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_rastreadorid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComborastreadorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboRastreadorId), 8, 0, ",", "")), ((edtavComborastreadorid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20ComboRastreadorId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV20ComboRastreadorId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComborastreadorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComborastreadorid_Visible, edtavComborastreadorid_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComandoEnviadoSerial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A147ComandoEnviadoSerial), 8, 0, ",", "")), ((edtComandoEnviadoSerial_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A147ComandoEnviadoSerial), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A147ComandoEnviadoSerial), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoEnviadoSerial_Jsonclick, 0, "Attribute", "", "", "", "", edtComandoEnviadoSerial_Visible, edtComandoEnviadoSerial_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ComandoEnviado.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridlevel_comando( )
      {
         /*  Grid Control  */
         Gridlevel_comandoContainer.AddObjectProperty("GridName", "Gridlevel_comando");
         Gridlevel_comandoContainer.AddObjectProperty("Header", subGridlevel_comando_Header);
         Gridlevel_comandoContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_comandoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_comandoContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_comandoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comandoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A148ComandoEnviadoComandoId), 8, 0, ".", "")));
         Gridlevel_comandoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0, ".", "")));
         Gridlevel_comandoContainer.AddColumnProperties(Gridlevel_comandoColumn);
         Gridlevel_comandoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comandoColumn.AddObjectProperty("Value", A149ComandoEnviadoComandoComando);
         Gridlevel_comandoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0, ".", "")));
         Gridlevel_comandoContainer.AddColumnProperties(Gridlevel_comandoColumn);
         Gridlevel_comandoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comandoColumn.AddObjectProperty("Value", A150ComandoEnviadoComandoValor);
         Gridlevel_comandoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0, ".", "")));
         Gridlevel_comandoContainer.AddColumnProperties(Gridlevel_comandoColumn);
         Gridlevel_comandoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Selectedindex), 4, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Allowselection), 1, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Allowhovering), 1, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_comandoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comando_Collapsed), 1, 0, ".", "")));
         nGXsfl_52_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount25 = (short)(subGridlevel_comando_Rows);
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_25 = 1;
               ScanStart0N25( ) ;
               while ( RcdFound25 != 0 )
               {
                  init_level_properties25( ) ;
                  getByPrimaryKey0N25( ) ;
                  AddRow0N25( ) ;
                  ScanNext0N25( ) ;
               }
               ScanEnd0N25( ) ;
               nBlankRcdCount25 = (short)(subGridlevel_comando_Rows);
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0N25( ) ;
            standaloneModal0N25( ) ;
            sMode25 = Gx_mode;
            while ( nGXsfl_52_idx < nRC_GXsfl_52 )
            {
               bGXsfl_52_Refreshing = true;
               ReadRow0N25( ) ;
               edtComandoEnviadoComandoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "COMANDOENVIADOCOMANDOID_"+sGXsfl_52_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtComandoEnviadoComandoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtComandoEnviadoComandoComando_Enabled = (int)(context.localUtil.CToN( cgiGet( "COMANDOENVIADOCOMANDOCOMANDO_"+sGXsfl_52_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtComandoEnviadoComandoComando_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               edtComandoEnviadoComandoValor_Enabled = (int)(context.localUtil.CToN( cgiGet( "COMANDOENVIADOCOMANDOVALOR_"+sGXsfl_52_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtComandoEnviadoComandoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0), !bGXsfl_52_Refreshing);
               if ( ( nRcdExists_25 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0N25( ) ;
               }
               SendRow0N25( ) ;
               bGXsfl_52_Refreshing = false;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount25 = (short)(subGridlevel_comando_Rows);
            nRcdExists_25 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0N25( ) ;
               while ( RcdFound25 != 0 )
               {
                  sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5225( ) ;
                  init_level_properties25( ) ;
                  standaloneNotModal0N25( ) ;
                  getByPrimaryKey0N25( ) ;
                  standaloneModal0N25( ) ;
                  AddRow0N25( ) ;
                  ScanNext0N25( ) ;
               }
               ScanEnd0N25( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode25 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5225( ) ;
            InitAll0N25( ) ;
            init_level_properties25( ) ;
            nRcdExists_25 = 0;
            nIsMod_25 = 0;
            nRcdDeleted_25 = 0;
            nBlankRcdCount25 = (short)(nBlankRcdUsr25+nBlankRcdCount25);
            fRowAdded = 0;
            while ( nBlankRcdCount25 > 0 )
            {
               standaloneNotModal0N25( ) ;
               standaloneModal0N25( ) ;
               AddRow0N25( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
               }
               nBlankRcdCount25 = (short)(nBlankRcdCount25-1);
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_comandoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_comando", Gridlevel_comandoContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_comandoContainerData", Gridlevel_comandoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_comandoContainerData"+"V", Gridlevel_comandoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_comandoContainerData"+"V"+"\" value='"+Gridlevel_comandoContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110N2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vRASTREADORID_DATA"), AV15RastreadorId_Data);
               /* Read saved values. */
               Z144ComandoEnviadoId = (int)(context.localUtil.CToN( cgiGet( "Z144ComandoEnviadoId"), ",", "."));
               Z145ComandoEnviadoResponsavelGUID = cgiGet( "Z145ComandoEnviadoResponsavelGUID");
               Z146ComandoEnviadoDataHora = context.localUtil.CToT( cgiGet( "Z146ComandoEnviadoDataHora"), 0);
               Z147ComandoEnviadoSerial = (int)(context.localUtil.CToN( cgiGet( "Z147ComandoEnviadoSerial"), ",", "."));
               Z106RastreadorId = (int)(context.localUtil.CToN( cgiGet( "Z106RastreadorId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_52 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_52"), ",", "."));
               N106RastreadorId = (int)(context.localUtil.CToN( cgiGet( "N106RastreadorId"), ",", "."));
               AV7ComandoEnviadoId = (int)(context.localUtil.CToN( cgiGet( "vCOMANDOENVIADOID"), ",", "."));
               AV13Insert_RastreadorId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_RASTREADORID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               AV24Pgmname = cgiGet( "vPGMNAME");
               Combo_rastreadorid_Objectcall = cgiGet( "COMBO_RASTREADORID_Objectcall");
               Combo_rastreadorid_Class = cgiGet( "COMBO_RASTREADORID_Class");
               Combo_rastreadorid_Icontype = cgiGet( "COMBO_RASTREADORID_Icontype");
               Combo_rastreadorid_Icon = cgiGet( "COMBO_RASTREADORID_Icon");
               Combo_rastreadorid_Caption = cgiGet( "COMBO_RASTREADORID_Caption");
               Combo_rastreadorid_Tooltip = cgiGet( "COMBO_RASTREADORID_Tooltip");
               Combo_rastreadorid_Cls = cgiGet( "COMBO_RASTREADORID_Cls");
               Combo_rastreadorid_Selectedvalue_set = cgiGet( "COMBO_RASTREADORID_Selectedvalue_set");
               Combo_rastreadorid_Selectedvalue_get = cgiGet( "COMBO_RASTREADORID_Selectedvalue_get");
               Combo_rastreadorid_Selectedtext_set = cgiGet( "COMBO_RASTREADORID_Selectedtext_set");
               Combo_rastreadorid_Selectedtext_get = cgiGet( "COMBO_RASTREADORID_Selectedtext_get");
               Combo_rastreadorid_Gamoauthtoken = cgiGet( "COMBO_RASTREADORID_Gamoauthtoken");
               Combo_rastreadorid_Ddointernalname = cgiGet( "COMBO_RASTREADORID_Ddointernalname");
               Combo_rastreadorid_Titlecontrolalign = cgiGet( "COMBO_RASTREADORID_Titlecontrolalign");
               Combo_rastreadorid_Dropdownoptionstype = cgiGet( "COMBO_RASTREADORID_Dropdownoptionstype");
               Combo_rastreadorid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Enabled"));
               Combo_rastreadorid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Visible"));
               Combo_rastreadorid_Titlecontrolidtoreplace = cgiGet( "COMBO_RASTREADORID_Titlecontrolidtoreplace");
               Combo_rastreadorid_Datalisttype = cgiGet( "COMBO_RASTREADORID_Datalisttype");
               Combo_rastreadorid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Allowmultipleselection"));
               Combo_rastreadorid_Datalistfixedvalues = cgiGet( "COMBO_RASTREADORID_Datalistfixedvalues");
               Combo_rastreadorid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Isgriditem"));
               Combo_rastreadorid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Hasdescription"));
               Combo_rastreadorid_Datalistproc = cgiGet( "COMBO_RASTREADORID_Datalistproc");
               Combo_rastreadorid_Datalistprocparametersprefix = cgiGet( "COMBO_RASTREADORID_Datalistprocparametersprefix");
               Combo_rastreadorid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_RASTREADORID_Datalistupdateminimumcharacters"), ",", "."));
               Combo_rastreadorid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Includeonlyselectedoption"));
               Combo_rastreadorid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Includeselectalloption"));
               Combo_rastreadorid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Emptyitem"));
               Combo_rastreadorid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RASTREADORID_Includeaddnewoption"));
               Combo_rastreadorid_Htmltemplate = cgiGet( "COMBO_RASTREADORID_Htmltemplate");
               Combo_rastreadorid_Multiplevaluestype = cgiGet( "COMBO_RASTREADORID_Multiplevaluestype");
               Combo_rastreadorid_Loadingdata = cgiGet( "COMBO_RASTREADORID_Loadingdata");
               Combo_rastreadorid_Noresultsfound = cgiGet( "COMBO_RASTREADORID_Noresultsfound");
               Combo_rastreadorid_Emptyitemtext = cgiGet( "COMBO_RASTREADORID_Emptyitemtext");
               Combo_rastreadorid_Onlyselectedvalues = cgiGet( "COMBO_RASTREADORID_Onlyselectedvalues");
               Combo_rastreadorid_Selectalltext = cgiGet( "COMBO_RASTREADORID_Selectalltext");
               Combo_rastreadorid_Multiplevaluesseparator = cgiGet( "COMBO_RASTREADORID_Multiplevaluesseparator");
               Combo_rastreadorid_Addnewoptiontext = cgiGet( "COMBO_RASTREADORID_Addnewoptiontext");
               Combo_rastreadorid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_RASTREADORID_Gxcontroltype"), ",", "."));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A144ComandoEnviadoId = (int)(context.localUtil.CToN( cgiGet( edtComandoEnviadoId_Internalname), ",", "."));
               AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
               A145ComandoEnviadoResponsavelGUID = cgiGet( edtComandoEnviadoResponsavelGUID_Internalname);
               AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
               A146ComandoEnviadoDataHora = context.localUtil.CToT( cgiGet( edtComandoEnviadoDataHora_Internalname));
               AssignAttri("", false, "A146ComandoEnviadoDataHora", context.localUtil.TToC( A146ComandoEnviadoDataHora, 8, 5, 0, 3, "/", ":", " "));
               if ( ( ( context.localUtil.CToN( cgiGet( edtRastreadorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRastreadorId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RASTREADORID");
                  AnyError = 1;
                  GX_FocusControl = edtRastreadorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A106RastreadorId = 0;
                  AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
               }
               else
               {
                  A106RastreadorId = (int)(context.localUtil.CToN( cgiGet( edtRastreadorId_Internalname), ",", "."));
                  AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
               }
               A110RastreadorSNumber = (long)(context.localUtil.CToN( cgiGet( edtRastreadorSNumber_Internalname), ",", "."));
               AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
               AV20ComboRastreadorId = (int)(context.localUtil.CToN( cgiGet( edtavComborastreadorid_Internalname), ",", "."));
               AssignAttri("", false, "AV20ComboRastreadorId", StringUtil.LTrimStr( (decimal)(AV20ComboRastreadorId), 8, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtComandoEnviadoSerial_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComandoEnviadoSerial_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMANDOENVIADOSERIAL");
                  AnyError = 1;
                  GX_FocusControl = edtComandoEnviadoSerial_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A147ComandoEnviadoSerial = 0;
                  AssignAttri("", false, "A147ComandoEnviadoSerial", StringUtil.LTrimStr( (decimal)(A147ComandoEnviadoSerial), 8, 0));
               }
               else
               {
                  A147ComandoEnviadoSerial = (int)(context.localUtil.CToN( cgiGet( edtComandoEnviadoSerial_Internalname), ",", "."));
                  AssignAttri("", false, "A147ComandoEnviadoSerial", StringUtil.LTrimStr( (decimal)(A147ComandoEnviadoSerial), 8, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ComandoEnviado");
               A144ComandoEnviadoId = (int)(context.localUtil.CToN( cgiGet( edtComandoEnviadoId_Internalname), ",", "."));
               AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
               forbiddenHiddens.Add("ComandoEnviadoId", context.localUtil.Format( (decimal)(A144ComandoEnviadoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A145ComandoEnviadoResponsavelGUID = cgiGet( edtComandoEnviadoResponsavelGUID_Internalname);
               AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
               forbiddenHiddens.Add("ComandoEnviadoResponsavelGUID", StringUtil.RTrim( context.localUtil.Format( A145ComandoEnviadoResponsavelGUID, "")));
               A146ComandoEnviadoDataHora = context.localUtil.CToT( cgiGet( edtComandoEnviadoDataHora_Internalname));
               AssignAttri("", false, "A146ComandoEnviadoDataHora", context.localUtil.TToC( A146ComandoEnviadoDataHora, 8, 5, 0, 3, "/", ":", " "));
               forbiddenHiddens.Add("ComandoEnviadoDataHora", context.localUtil.Format( A146ComandoEnviadoDataHora, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A144ComandoEnviadoId != Z144ComandoEnviadoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("comandoenviado:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A144ComandoEnviadoId = (int)(NumberUtil.Val( GetPar( "ComandoEnviadoId"), "."));
                  AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode24 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode24;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound24 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0N0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COMANDOENVIADOID");
                        AnyError = 1;
                        GX_FocusControl = edtComandoEnviadoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0N24( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0N24( ) ;
         }
         AssignProp("", false, edtavComborastreadorid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborastreadorid_Enabled), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N24( ) ;
            }
            else
            {
               CheckExtendedTable0N24( ) ;
               CloseExtendedTableCursors0N24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode24 = Gx_mode;
            CONFIRM_0N25( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode24;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0N25( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            ReadRow0N25( ) ;
            if ( ( nRcdExists_25 != 0 ) || ( nIsMod_25 != 0 ) )
            {
               GetKey0N25( ) ;
               if ( ( nRcdExists_25 == 0 ) && ( nRcdDeleted_25 == 0 ) )
               {
                  if ( RcdFound25 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0N25( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0N25( ) ;
                        CloseExtendedTableCursors0N25( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound25 != 0 )
                  {
                     if ( nRcdDeleted_25 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0N25( ) ;
                        Load0N25( ) ;
                        BeforeValidate0N25( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0N25( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_25 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0N25( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0N25( ) ;
                              CloseExtendedTableCursors0N25( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_25 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtComandoEnviadoComandoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A148ComandoEnviadoComandoId), 8, 0, ",", ""))) ;
            ChangePostValue( edtComandoEnviadoComandoComando_Internalname, A149ComandoEnviadoComandoComando) ;
            ChangePostValue( edtComandoEnviadoComandoValor_Internalname, A150ComandoEnviadoComandoValor) ;
            ChangePostValue( "ZT_"+"Z148ComandoEnviadoComandoId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z148ComandoEnviadoComandoId), 8, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z149ComandoEnviadoComandoComando_"+sGXsfl_52_idx, Z149ComandoEnviadoComandoComando) ;
            ChangePostValue( "ZT_"+"Z150ComandoEnviadoComandoValor_"+sGXsfl_52_idx, Z150ComandoEnviadoComandoValor) ;
            ChangePostValue( "nRcdDeleted_25_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_25), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_25_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_25), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_25_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_25), 4, 0, ",", ""))) ;
            if ( nIsMod_25 != 0 )
            {
               ChangePostValue( "COMANDOENVIADOCOMANDOID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMANDOENVIADOCOMANDOCOMANDO_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMANDOENVIADOCOMANDOVALOR_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0N0( )
      {
      }

      protected void E110N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_rastreadorid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_rastreadorid.SendProperty(context, "", false, Combo_rastreadorid_Internalname, "GAMOAuthToken", Combo_rastreadorid_Gamoauthtoken);
         edtRastreadorId_Visible = 0;
         AssignProp("", false, edtRastreadorId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRastreadorId_Visible), 5, 0), true);
         AV20ComboRastreadorId = 0;
         AssignAttri("", false, "AV20ComboRastreadorId", StringUtil.LTrimStr( (decimal)(AV20ComboRastreadorId), 8, 0));
         edtavComborastreadorid_Visible = 0;
         AssignProp("", false, edtavComborastreadorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComborastreadorid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBORASTREADORID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "RastreadorId") == 0 )
               {
                  AV13Insert_RastreadorId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_RastreadorId", StringUtil.LTrimStr( (decimal)(AV13Insert_RastreadorId), 8, 0));
                  if ( ! (0==AV13Insert_RastreadorId) )
                  {
                     AV20ComboRastreadorId = AV13Insert_RastreadorId;
                     AssignAttri("", false, "AV20ComboRastreadorId", StringUtil.LTrimStr( (decimal)(AV20ComboRastreadorId), 8, 0));
                     Combo_rastreadorid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboRastreadorId), 8, 0));
                     ucCombo_rastreadorid.SendProperty(context, "", false, Combo_rastreadorid_Internalname, "SelectedValue_set", Combo_rastreadorid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new comandoenviadoloaddvcombo(context ).execute(  "RastreadorId",  "GET",  false,  AV7ComandoEnviadoId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_rastreadorid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_rastreadorid.SendProperty(context, "", false, Combo_rastreadorid_Internalname, "SelectedText_set", Combo_rastreadorid_Selectedtext_set);
                     Combo_rastreadorid_Enabled = false;
                     ucCombo_rastreadorid.SendProperty(context, "", false, Combo_rastreadorid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_rastreadorid_Enabled));
                  }
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
         edtComandoEnviadoSerial_Visible = 0;
         AssignProp("", false, edtComandoEnviadoSerial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoSerial_Visible), 5, 0), true);
         subGridlevel_comando_Rows = 0;
      }

      protected void E120N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("comandoenviadoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBORASTREADORID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new comandoenviadoloaddvcombo(context ).execute(  "RastreadorId",  Gx_mode,  false,  AV7ComandoEnviadoId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_rastreadorid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_rastreadorid.SendProperty(context, "", false, Combo_rastreadorid_Internalname, "SelectedValue_set", Combo_rastreadorid_Selectedvalue_set);
         Combo_rastreadorid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_rastreadorid.SendProperty(context, "", false, Combo_rastreadorid_Internalname, "SelectedText_set", Combo_rastreadorid_Selectedtext_set);
         AV20ComboRastreadorId = (int)(NumberUtil.Val( AV17ComboSelectedValue, "."));
         AssignAttri("", false, "AV20ComboRastreadorId", StringUtil.LTrimStr( (decimal)(AV20ComboRastreadorId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_rastreadorid_Enabled = false;
            ucCombo_rastreadorid.SendProperty(context, "", false, Combo_rastreadorid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_rastreadorid_Enabled));
         }
      }

      protected void ZM0N24( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z145ComandoEnviadoResponsavelGUID = T000N5_A145ComandoEnviadoResponsavelGUID[0];
               Z146ComandoEnviadoDataHora = T000N5_A146ComandoEnviadoDataHora[0];
               Z147ComandoEnviadoSerial = T000N5_A147ComandoEnviadoSerial[0];
               Z106RastreadorId = T000N5_A106RastreadorId[0];
            }
            else
            {
               Z145ComandoEnviadoResponsavelGUID = A145ComandoEnviadoResponsavelGUID;
               Z146ComandoEnviadoDataHora = A146ComandoEnviadoDataHora;
               Z147ComandoEnviadoSerial = A147ComandoEnviadoSerial;
               Z106RastreadorId = A106RastreadorId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            Z145ComandoEnviadoResponsavelGUID = A145ComandoEnviadoResponsavelGUID;
            Z146ComandoEnviadoDataHora = A146ComandoEnviadoDataHora;
            Z147ComandoEnviadoSerial = A147ComandoEnviadoSerial;
            Z106RastreadorId = A106RastreadorId;
            Z110RastreadorSNumber = A110RastreadorSNumber;
         }
      }

      protected void standaloneNotModal( )
      {
         edtComandoEnviadoId_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoId_Enabled), 5, 0), true);
         edtComandoEnviadoResponsavelGUID_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoResponsavelGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoResponsavelGUID_Enabled), 5, 0), true);
         edtComandoEnviadoDataHora_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoDataHora_Enabled), 5, 0), true);
         AV24Pgmname = "ComandoEnviado";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtComandoEnviadoId_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoId_Enabled), 5, 0), true);
         edtComandoEnviadoResponsavelGUID_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoResponsavelGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoResponsavelGUID_Enabled), 5, 0), true);
         edtComandoEnviadoDataHora_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoDataHora_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ComandoEnviadoId) )
         {
            A144ComandoEnviadoId = AV7ComandoEnviadoId;
            AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_RastreadorId) )
         {
            edtRastreadorId_Enabled = 0;
            AssignProp("", false, edtRastreadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorId_Enabled), 5, 0), true);
         }
         else
         {
            edtRastreadorId_Enabled = 1;
            AssignProp("", false, edtRastreadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_RastreadorId) )
         {
            A106RastreadorId = AV13Insert_RastreadorId;
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
         }
         else
         {
            A106RastreadorId = AV20ComboRastreadorId;
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (DateTime.MinValue==A146ComandoEnviadoDataHora) && ( Gx_BScreen == 0 ) )
         {
            A146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A146ComandoEnviadoDataHora", context.localUtil.TToC( A146ComandoEnviadoDataHora, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A145ComandoEnviadoResponsavelGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char2 = A145ComandoEnviadoResponsavelGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char2) ;
            A145ComandoEnviadoResponsavelGUID = GXt_char2;
            AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000N6 */
            pr_default.execute(4, new Object[] {A106RastreadorId});
            A110RastreadorSNumber = T000N6_A110RastreadorSNumber[0];
            AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
            pr_default.close(4);
         }
      }

      protected void Load0N24( )
      {
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound24 = 1;
            A145ComandoEnviadoResponsavelGUID = T000N7_A145ComandoEnviadoResponsavelGUID[0];
            AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
            A146ComandoEnviadoDataHora = T000N7_A146ComandoEnviadoDataHora[0];
            AssignAttri("", false, "A146ComandoEnviadoDataHora", context.localUtil.TToC( A146ComandoEnviadoDataHora, 8, 5, 0, 3, "/", ":", " "));
            A110RastreadorSNumber = T000N7_A110RastreadorSNumber[0];
            AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
            A147ComandoEnviadoSerial = T000N7_A147ComandoEnviadoSerial[0];
            AssignAttri("", false, "A147ComandoEnviadoSerial", StringUtil.LTrimStr( (decimal)(A147ComandoEnviadoSerial), 8, 0));
            A106RastreadorId = T000N7_A106RastreadorId[0];
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
            ZM0N24( -15) ;
         }
         pr_default.close(5);
         OnLoadActions0N24( ) ;
      }

      protected void OnLoadActions0N24( )
      {
      }

      protected void CheckExtendedTable0N24( )
      {
         nIsDirty_24 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Rastreador'.", "ForeignKeyNotFound", 1, "RASTREADORID");
            AnyError = 1;
            GX_FocusControl = edtRastreadorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A110RastreadorSNumber = T000N6_A110RastreadorSNumber[0];
         AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0N24( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( int A106RastreadorId )
      {
         /* Using cursor T000N8 */
         pr_default.execute(6, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Rastreador'.", "ForeignKeyNotFound", 1, "RASTREADORID");
            AnyError = 1;
            GX_FocusControl = edtRastreadorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A110RastreadorSNumber = T000N8_A110RastreadorSNumber[0];
         AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110RastreadorSNumber), 16, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0N24( )
      {
         /* Using cursor T000N9 */
         pr_default.execute(7, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0N24( 15) ;
            RcdFound24 = 1;
            A144ComandoEnviadoId = T000N5_A144ComandoEnviadoId[0];
            AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
            A145ComandoEnviadoResponsavelGUID = T000N5_A145ComandoEnviadoResponsavelGUID[0];
            AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
            A146ComandoEnviadoDataHora = T000N5_A146ComandoEnviadoDataHora[0];
            AssignAttri("", false, "A146ComandoEnviadoDataHora", context.localUtil.TToC( A146ComandoEnviadoDataHora, 8, 5, 0, 3, "/", ":", " "));
            A147ComandoEnviadoSerial = T000N5_A147ComandoEnviadoSerial[0];
            AssignAttri("", false, "A147ComandoEnviadoSerial", StringUtil.LTrimStr( (decimal)(A147ComandoEnviadoSerial), 8, 0));
            A106RastreadorId = T000N5_A106RastreadorId[0];
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0N24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0N24( ) ;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0N24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N24( ) ;
         if ( RcdFound24 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound24 = 0;
         /* Using cursor T000N10 */
         pr_default.execute(8, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000N10_A144ComandoEnviadoId[0] < A144ComandoEnviadoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000N10_A144ComandoEnviadoId[0] > A144ComandoEnviadoId ) ) )
            {
               A144ComandoEnviadoId = T000N10_A144ComandoEnviadoId[0];
               AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound24 = 0;
         /* Using cursor T000N11 */
         pr_default.execute(9, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000N11_A144ComandoEnviadoId[0] > A144ComandoEnviadoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000N11_A144ComandoEnviadoId[0] < A144ComandoEnviadoId ) ) )
            {
               A144ComandoEnviadoId = T000N11_A144ComandoEnviadoId[0];
               AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRastreadorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N24( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A144ComandoEnviadoId != Z144ComandoEnviadoId )
               {
                  A144ComandoEnviadoId = Z144ComandoEnviadoId;
                  AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COMANDOENVIADOID");
                  AnyError = 1;
                  GX_FocusControl = edtComandoEnviadoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRastreadorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0N24( ) ;
                  GX_FocusControl = edtRastreadorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A144ComandoEnviadoId != Z144ComandoEnviadoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtRastreadorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N24( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COMANDOENVIADOID");
                     AnyError = 1;
                     GX_FocusControl = edtComandoEnviadoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRastreadorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N24( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A144ComandoEnviadoId != Z144ComandoEnviadoId )
         {
            A144ComandoEnviadoId = Z144ComandoEnviadoId;
            AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COMANDOENVIADOID");
            AnyError = 1;
            GX_FocusControl = edtComandoEnviadoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRastreadorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0N24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N4 */
            pr_default.execute(2, new Object[] {A144ComandoEnviadoId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z145ComandoEnviadoResponsavelGUID, T000N4_A145ComandoEnviadoResponsavelGUID[0]) != 0 ) || ( Z146ComandoEnviadoDataHora != T000N4_A146ComandoEnviadoDataHora[0] ) || ( Z147ComandoEnviadoSerial != T000N4_A147ComandoEnviadoSerial[0] ) || ( Z106RastreadorId != T000N4_A106RastreadorId[0] ) )
            {
               if ( StringUtil.StrCmp(Z145ComandoEnviadoResponsavelGUID, T000N4_A145ComandoEnviadoResponsavelGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("comandoenviado:[seudo value changed for attri]"+"ComandoEnviadoResponsavelGUID");
                  GXUtil.WriteLogRaw("Old: ",Z145ComandoEnviadoResponsavelGUID);
                  GXUtil.WriteLogRaw("Current: ",T000N4_A145ComandoEnviadoResponsavelGUID[0]);
               }
               if ( Z146ComandoEnviadoDataHora != T000N4_A146ComandoEnviadoDataHora[0] )
               {
                  GXUtil.WriteLog("comandoenviado:[seudo value changed for attri]"+"ComandoEnviadoDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z146ComandoEnviadoDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000N4_A146ComandoEnviadoDataHora[0]);
               }
               if ( Z147ComandoEnviadoSerial != T000N4_A147ComandoEnviadoSerial[0] )
               {
                  GXUtil.WriteLog("comandoenviado:[seudo value changed for attri]"+"ComandoEnviadoSerial");
                  GXUtil.WriteLogRaw("Old: ",Z147ComandoEnviadoSerial);
                  GXUtil.WriteLogRaw("Current: ",T000N4_A147ComandoEnviadoSerial[0]);
               }
               if ( Z106RastreadorId != T000N4_A106RastreadorId[0] )
               {
                  GXUtil.WriteLog("comandoenviado:[seudo value changed for attri]"+"RastreadorId");
                  GXUtil.WriteLogRaw("Old: ",Z106RastreadorId);
                  GXUtil.WriteLogRaw("Current: ",T000N4_A106RastreadorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComandoEnviado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N24( )
      {
         if ( ! IsAuthorized("comandoenviado_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N24( 0) ;
            CheckOptimisticConcurrency0N24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N12 */
                     pr_default.execute(10, new Object[] {A145ComandoEnviadoResponsavelGUID, A146ComandoEnviadoDataHora, A147ComandoEnviadoSerial, A106RastreadorId});
                     A144ComandoEnviadoId = T000N12_A144ComandoEnviadoId[0];
                     AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N24( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0N0( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0N24( ) ;
            }
            EndLevel0N24( ) ;
         }
         CloseExtendedTableCursors0N24( ) ;
      }

      protected void Update0N24( )
      {
         if ( ! IsAuthorized("comandoenviado_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N13 */
                     pr_default.execute(11, new Object[] {A145ComandoEnviadoResponsavelGUID, A146ComandoEnviadoDataHora, A147ComandoEnviadoSerial, A106RastreadorId, A144ComandoEnviadoId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviado");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N24( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N24( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0N24( ) ;
         }
         CloseExtendedTableCursors0N24( ) ;
      }

      protected void DeferredUpdate0N24( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("comandoenviado_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N24( ) ;
            AfterConfirm0N24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N24( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0N25( ) ;
                  while ( RcdFound25 != 0 )
                  {
                     getByPrimaryKey0N25( ) ;
                     Delete0N25( ) ;
                     ScanNext0N25( ) ;
                  }
                  ScanEnd0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N14 */
                     pr_default.execute(12, new Object[] {A144ComandoEnviadoId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N24( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N24( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000N15 */
            pr_default.execute(13, new Object[] {A106RastreadorId});
            A110RastreadorSNumber = T000N15_A110RastreadorSNumber[0];
            AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel0N25( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            ReadRow0N25( ) ;
            if ( ( nRcdExists_25 != 0 ) || ( nIsMod_25 != 0 ) )
            {
               standaloneNotModal0N25( ) ;
               GetKey0N25( ) ;
               if ( ( nRcdExists_25 == 0 ) && ( nRcdDeleted_25 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0N25( ) ;
               }
               else
               {
                  if ( RcdFound25 != 0 )
                  {
                     if ( ( nRcdDeleted_25 != 0 ) && ( nRcdExists_25 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0N25( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_25 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0N25( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_25 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtComandoEnviadoComandoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A148ComandoEnviadoComandoId), 8, 0, ",", ""))) ;
            ChangePostValue( edtComandoEnviadoComandoComando_Internalname, A149ComandoEnviadoComandoComando) ;
            ChangePostValue( edtComandoEnviadoComandoValor_Internalname, A150ComandoEnviadoComandoValor) ;
            ChangePostValue( "ZT_"+"Z148ComandoEnviadoComandoId_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z148ComandoEnviadoComandoId), 8, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z149ComandoEnviadoComandoComando_"+sGXsfl_52_idx, Z149ComandoEnviadoComandoComando) ;
            ChangePostValue( "ZT_"+"Z150ComandoEnviadoComandoValor_"+sGXsfl_52_idx, Z150ComandoEnviadoComandoValor) ;
            ChangePostValue( "nRcdDeleted_25_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_25), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_25_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_25), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_25_"+sGXsfl_52_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_25), 4, 0, ",", ""))) ;
            if ( nIsMod_25 != 0 )
            {
               ChangePostValue( "COMANDOENVIADOCOMANDOID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMANDOENVIADOCOMANDOCOMANDO_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMANDOENVIADOCOMANDOVALOR_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0N25( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_25 = 0;
         nIsMod_25 = 0;
         nRcdDeleted_25 = 0;
      }

      protected void ProcessLevel0N24( )
      {
         /* Save parent mode. */
         sMode24 = Gx_mode;
         ProcessNestedLevel0N25( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0N24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(13);
            context.CommitDataStores("comandoenviado",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(13);
            context.RollbackDataStores("comandoenviado",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N24( )
      {
         /* Scan By routine */
         /* Using cursor T000N16 */
         pr_default.execute(14);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound24 = 1;
            A144ComandoEnviadoId = T000N16_A144ComandoEnviadoId[0];
            AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N24( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound24 = 1;
            A144ComandoEnviadoId = T000N16_A144ComandoEnviadoId[0];
            AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
         }
      }

      protected void ScanEnd0N24( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0N24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N24( )
      {
         edtComandoEnviadoId_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoId_Enabled), 5, 0), true);
         edtComandoEnviadoResponsavelGUID_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoResponsavelGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoResponsavelGUID_Enabled), 5, 0), true);
         edtComandoEnviadoDataHora_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoDataHora_Enabled), 5, 0), true);
         edtRastreadorId_Enabled = 0;
         AssignProp("", false, edtRastreadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorId_Enabled), 5, 0), true);
         edtRastreadorSNumber_Enabled = 0;
         AssignProp("", false, edtRastreadorSNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorSNumber_Enabled), 5, 0), true);
         edtavComborastreadorid_Enabled = 0;
         AssignProp("", false, edtavComborastreadorid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComborastreadorid_Enabled), 5, 0), true);
         edtComandoEnviadoSerial_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoSerial_Enabled), 5, 0), true);
      }

      protected void ZM0N25( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z149ComandoEnviadoComandoComando = T000N3_A149ComandoEnviadoComandoComando[0];
               Z150ComandoEnviadoComandoValor = T000N3_A150ComandoEnviadoComandoValor[0];
            }
            else
            {
               Z149ComandoEnviadoComandoComando = A149ComandoEnviadoComandoComando;
               Z150ComandoEnviadoComandoValor = A150ComandoEnviadoComandoValor;
            }
         }
         if ( GX_JID == -17 )
         {
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            Z148ComandoEnviadoComandoId = A148ComandoEnviadoComandoId;
            Z149ComandoEnviadoComandoComando = A149ComandoEnviadoComandoComando;
            Z150ComandoEnviadoComandoValor = A150ComandoEnviadoComandoValor;
         }
      }

      protected void standaloneNotModal0N25( )
      {
         edtComandoEnviadoComandoId_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoComandoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtComandoEnviadoComandoComando_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoComandoComando_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtComandoEnviadoComandoValor_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoComandoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void standaloneModal0N25( )
      {
      }

      protected void Load0N25( )
      {
         /* Using cursor T000N17 */
         pr_default.execute(15, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound25 = 1;
            A149ComandoEnviadoComandoComando = T000N17_A149ComandoEnviadoComandoComando[0];
            A150ComandoEnviadoComandoValor = T000N17_A150ComandoEnviadoComandoValor[0];
            ZM0N25( -17) ;
         }
         pr_default.close(15);
         OnLoadActions0N25( ) ;
      }

      protected void OnLoadActions0N25( )
      {
      }

      protected void CheckExtendedTable0N25( )
      {
         nIsDirty_25 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0N25( ) ;
      }

      protected void CloseExtendedTableCursors0N25( )
      {
      }

      protected void enableDisable0N25( )
      {
      }

      protected void GetKey0N25( )
      {
         /* Using cursor T000N18 */
         pr_default.execute(16, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey0N25( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N25( 17) ;
            RcdFound25 = 1;
            InitializeNonKey0N25( ) ;
            A148ComandoEnviadoComandoId = T000N3_A148ComandoEnviadoComandoId[0];
            A149ComandoEnviadoComandoComando = T000N3_A149ComandoEnviadoComandoComando[0];
            A150ComandoEnviadoComandoValor = T000N3_A150ComandoEnviadoComandoValor[0];
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            Z148ComandoEnviadoComandoId = A148ComandoEnviadoComandoId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0N25( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0N25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0N25( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0N25( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0N25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviadoComando"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z149ComandoEnviadoComandoComando, T000N2_A149ComandoEnviadoComandoComando[0]) != 0 ) || ( StringUtil.StrCmp(Z150ComandoEnviadoComandoValor, T000N2_A150ComandoEnviadoComandoValor[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z149ComandoEnviadoComandoComando, T000N2_A149ComandoEnviadoComandoComando[0]) != 0 )
               {
                  GXUtil.WriteLog("comandoenviado:[seudo value changed for attri]"+"ComandoEnviadoComandoComando");
                  GXUtil.WriteLogRaw("Old: ",Z149ComandoEnviadoComandoComando);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A149ComandoEnviadoComandoComando[0]);
               }
               if ( StringUtil.StrCmp(Z150ComandoEnviadoComandoValor, T000N2_A150ComandoEnviadoComandoValor[0]) != 0 )
               {
                  GXUtil.WriteLog("comandoenviado:[seudo value changed for attri]"+"ComandoEnviadoComandoValor");
                  GXUtil.WriteLogRaw("Old: ",Z150ComandoEnviadoComandoValor);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A150ComandoEnviadoComandoValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComandoEnviadoComando"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N25( )
      {
         if ( ! IsAuthorized("comandoenviado_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N25( 0) ;
            CheckOptimisticConcurrency0N25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N19 */
                     pr_default.execute(17, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId, A149ComandoEnviadoComandoComando, A150ComandoEnviadoComandoValor});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviadoComando");
                     if ( (pr_default.getStatus(17) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0N25( ) ;
            }
            EndLevel0N25( ) ;
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void Update0N25( )
      {
         if ( ! IsAuthorized("comandoenviado_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( ( nIsMod_25 != 0 ) || ( nIsDirty_25 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0N25( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0N25( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000N20 */
                        pr_default.execute(18, new Object[] {A149ComandoEnviadoComandoComando, A150ComandoEnviadoComandoValor, A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
                        pr_default.close(18);
                        dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviadoComando");
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviadoComando"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0N25( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0N25( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel0N25( ) ;
            }
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void DeferredUpdate0N25( )
      {
      }

      protected void Delete0N25( )
      {
         if ( ! IsAuthorized("comandoenviado_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N25( ) ;
            AfterConfirm0N25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N21 */
                  pr_default.execute(19, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviadoComando");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N25( )
      {
         standaloneModal0N25( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0N25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N25( )
      {
         /* Scan By routine */
         /* Using cursor T000N22 */
         pr_default.execute(20, new Object[] {A144ComandoEnviadoId});
         RcdFound25 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound25 = 1;
            A148ComandoEnviadoComandoId = T000N22_A148ComandoEnviadoComandoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N25( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound25 = 1;
            A148ComandoEnviadoComandoId = T000N22_A148ComandoEnviadoComandoId[0];
         }
      }

      protected void ScanEnd0N25( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0N25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N25( )
      {
         edtComandoEnviadoComandoId_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoComandoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtComandoEnviadoComandoComando_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoComandoComando_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtComandoEnviadoComandoValor_Enabled = 0;
         AssignProp("", false, edtComandoEnviadoComandoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void send_integrity_lvl_hashes0N25( )
      {
      }

      protected void send_integrity_lvl_hashes0N24( )
      {
      }

      protected void SubsflControlProps_5225( )
      {
         edtComandoEnviadoComandoId_Internalname = "COMANDOENVIADOCOMANDOID_"+sGXsfl_52_idx;
         edtComandoEnviadoComandoComando_Internalname = "COMANDOENVIADOCOMANDOCOMANDO_"+sGXsfl_52_idx;
         edtComandoEnviadoComandoValor_Internalname = "COMANDOENVIADOCOMANDOVALOR_"+sGXsfl_52_idx;
      }

      protected void SubsflControlProps_fel_5225( )
      {
         edtComandoEnviadoComandoId_Internalname = "COMANDOENVIADOCOMANDOID_"+sGXsfl_52_fel_idx;
         edtComandoEnviadoComandoComando_Internalname = "COMANDOENVIADOCOMANDOCOMANDO_"+sGXsfl_52_fel_idx;
         edtComandoEnviadoComandoValor_Internalname = "COMANDOENVIADOCOMANDOVALOR_"+sGXsfl_52_fel_idx;
      }

      protected void AddRow0N25( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5225( ) ;
         SendRow0N25( ) ;
      }

      protected void SendRow0N25( )
      {
         Gridlevel_comandoRow = GXWebRow.GetNew(context);
         if ( subGridlevel_comando_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_comando_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_comando_Class, "") != 0 )
            {
               subGridlevel_comando_Linesclass = subGridlevel_comando_Class+"Odd";
            }
         }
         else if ( subGridlevel_comando_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_comando_Backstyle = 0;
            subGridlevel_comando_Backcolor = subGridlevel_comando_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_comando_Class, "") != 0 )
            {
               subGridlevel_comando_Linesclass = subGridlevel_comando_Class+"Uniform";
            }
         }
         else if ( subGridlevel_comando_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_comando_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_comando_Class, "") != 0 )
            {
               subGridlevel_comando_Linesclass = subGridlevel_comando_Class+"Odd";
            }
            subGridlevel_comando_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_comando_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_comando_Backstyle = 1;
            if ( ((int)((nGXsfl_52_idx) % (2))) == 0 )
            {
               subGridlevel_comando_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_comando_Class, "") != 0 )
               {
                  subGridlevel_comando_Linesclass = subGridlevel_comando_Class+"Even";
               }
            }
            else
            {
               subGridlevel_comando_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_comando_Class, "") != 0 )
               {
                  subGridlevel_comando_Linesclass = subGridlevel_comando_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_comandoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComandoEnviadoComandoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A148ComandoEnviadoComandoId), 8, 0, ",", "")),((edtComandoEnviadoComandoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A148ComandoEnviadoComandoId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A148ComandoEnviadoComandoId), "ZZZZZZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComandoEnviadoComandoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtComandoEnviadoComandoId_Enabled,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)52,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_comandoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComandoEnviadoComandoComando_Internalname,(string)A149ComandoEnviadoComandoComando,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComandoEnviadoComandoComando_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtComandoEnviadoComandoComando_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_comandoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComandoEnviadoComandoValor_Internalname,(string)A150ComandoEnviadoComandoValor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComandoEnviadoComandoValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtComandoEnviadoComandoValor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)256,(short)0,(short)0,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_comandoRow);
         send_integrity_lvl_hashes0N25( ) ;
         GXCCtl = "Z148ComandoEnviadoComandoId_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z148ComandoEnviadoComandoId), 8, 0, ",", "")));
         GXCCtl = "Z149ComandoEnviadoComandoComando_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z149ComandoEnviadoComandoComando);
         GXCCtl = "Z150ComandoEnviadoComandoValor_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z150ComandoEnviadoComandoValor);
         GXCCtl = "nRcdDeleted_25_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_25), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_25_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_25), 4, 0, ",", "")));
         GXCCtl = "nIsMod_25_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_25), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_52_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCOMANDOENVIADOID_" + sGXsfl_52_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComandoEnviadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMANDOENVIADOCOMANDOID_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMANDOENVIADOCOMANDOCOMANDO_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMANDOENVIADOCOMANDOVALOR_"+sGXsfl_52_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_comandoContainer.AddRow(Gridlevel_comandoRow);
      }

      protected void ReadRow0N25( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5225( ) ;
         edtComandoEnviadoComandoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "COMANDOENVIADOCOMANDOID_"+sGXsfl_52_idx+"Enabled"), ",", "."));
         edtComandoEnviadoComandoComando_Enabled = (int)(context.localUtil.CToN( cgiGet( "COMANDOENVIADOCOMANDOCOMANDO_"+sGXsfl_52_idx+"Enabled"), ",", "."));
         edtComandoEnviadoComandoValor_Enabled = (int)(context.localUtil.CToN( cgiGet( "COMANDOENVIADOCOMANDOVALOR_"+sGXsfl_52_idx+"Enabled"), ",", "."));
         A148ComandoEnviadoComandoId = (int)(context.localUtil.CToN( cgiGet( edtComandoEnviadoComandoId_Internalname), ",", "."));
         A149ComandoEnviadoComandoComando = cgiGet( edtComandoEnviadoComandoComando_Internalname);
         A150ComandoEnviadoComandoValor = cgiGet( edtComandoEnviadoComandoValor_Internalname);
         GXCCtl = "Z148ComandoEnviadoComandoId_" + sGXsfl_52_idx;
         Z148ComandoEnviadoComandoId = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z149ComandoEnviadoComandoComando_" + sGXsfl_52_idx;
         Z149ComandoEnviadoComandoComando = cgiGet( GXCCtl);
         GXCCtl = "Z150ComandoEnviadoComandoValor_" + sGXsfl_52_idx;
         Z150ComandoEnviadoComandoValor = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_25_" + sGXsfl_52_idx;
         nRcdDeleted_25 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_25_" + sGXsfl_52_idx;
         nRcdExists_25 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_25_" + sGXsfl_52_idx;
         nIsMod_25 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtComandoEnviadoComandoValor_Enabled = edtComandoEnviadoComandoValor_Enabled;
         defedtComandoEnviadoComandoComando_Enabled = edtComandoEnviadoComandoComando_Enabled;
         defedtComandoEnviadoComandoId_Enabled = edtComandoEnviadoComandoId_Enabled;
      }

      protected void ConfirmValues0N0( )
      {
         nGXsfl_52_idx = 0;
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_5225( ) ;
         while ( nGXsfl_52_idx < nRC_GXsfl_52 )
         {
            nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_5225( ) ;
            ChangePostValue( "Z148ComandoEnviadoComandoId_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z148ComandoEnviadoComandoId_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z148ComandoEnviadoComandoId_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z149ComandoEnviadoComandoComando_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z149ComandoEnviadoComandoComando_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z149ComandoEnviadoComandoComando_"+sGXsfl_52_idx) ;
            ChangePostValue( "Z150ComandoEnviadoComandoValor_"+sGXsfl_52_idx, cgiGet( "ZT_"+"Z150ComandoEnviadoComandoValor_"+sGXsfl_52_idx)) ;
            DeletePostValue( "ZT_"+"Z150ComandoEnviadoComandoValor_"+sGXsfl_52_idx) ;
         }
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
         MasterPageObj.master_styles();
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202142817572416", false, true);
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comandoenviado.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ComandoEnviadoId,8,0))}, new string[] {"Gx_mode","ComandoEnviadoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ComandoEnviado");
         forbiddenHiddens.Add("ComandoEnviadoId", context.localUtil.Format( (decimal)(A144ComandoEnviadoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ComandoEnviadoResponsavelGUID", StringUtil.RTrim( context.localUtil.Format( A145ComandoEnviadoResponsavelGUID, "")));
         forbiddenHiddens.Add("ComandoEnviadoDataHora", context.localUtil.Format( A146ComandoEnviadoDataHora, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("comandoenviado:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z144ComandoEnviadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z144ComandoEnviadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z145ComandoEnviadoResponsavelGUID", StringUtil.RTrim( Z145ComandoEnviadoResponsavelGUID));
         GxWebStd.gx_hidden_field( context, "Z146ComandoEnviadoDataHora", context.localUtil.TToC( Z146ComandoEnviadoDataHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z147ComandoEnviadoSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147ComandoEnviadoSerial), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z106RastreadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106RastreadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_52", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_52_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N106RastreadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106RastreadorId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRASTREADORID_DATA", AV15RastreadorId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRASTREADORID_DATA", AV15RastreadorId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCOMANDOENVIADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComandoEnviadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMANDOENVIADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComandoEnviadoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_RASTREADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_RastreadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Objectcall", StringUtil.RTrim( Combo_rastreadorid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Cls", StringUtil.RTrim( Combo_rastreadorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Selectedvalue_set", StringUtil.RTrim( Combo_rastreadorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Selectedtext_set", StringUtil.RTrim( Combo_rastreadorid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Gamoauthtoken", StringUtil.RTrim( Combo_rastreadorid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Enabled", StringUtil.BoolToStr( Combo_rastreadorid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Datalistproc", StringUtil.RTrim( Combo_rastreadorid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_rastreadorid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_RASTREADORID_Emptyitem", StringUtil.BoolToStr( Combo_rastreadorid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("comandoenviado.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ComandoEnviadoId,8,0))}, new string[] {"Gx_mode","ComandoEnviadoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ComandoEnviado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Comando Enviado" ;
      }

      protected void InitializeNonKey0N24( )
      {
         A106RastreadorId = 0;
         AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
         A110RastreadorSNumber = 0;
         AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
         A147ComandoEnviadoSerial = 0;
         AssignAttri("", false, "A147ComandoEnviadoSerial", StringUtil.LTrimStr( (decimal)(A147ComandoEnviadoSerial), 8, 0));
         A145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
         A146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "A146ComandoEnviadoDataHora", context.localUtil.TToC( A146ComandoEnviadoDataHora, 8, 5, 0, 3, "/", ":", " "));
         Z145ComandoEnviadoResponsavelGUID = "";
         Z146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         Z147ComandoEnviadoSerial = 0;
         Z106RastreadorId = 0;
      }

      protected void InitAll0N24( )
      {
         A144ComandoEnviadoId = 0;
         AssignAttri("", false, "A144ComandoEnviadoId", StringUtil.LTrimStr( (decimal)(A144ComandoEnviadoId), 8, 0));
         InitializeNonKey0N24( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A146ComandoEnviadoDataHora = i146ComandoEnviadoDataHora;
         AssignAttri("", false, "A146ComandoEnviadoDataHora", context.localUtil.TToC( A146ComandoEnviadoDataHora, 8, 5, 0, 3, "/", ":", " "));
         A145ComandoEnviadoResponsavelGUID = i145ComandoEnviadoResponsavelGUID;
         AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
      }

      protected void InitializeNonKey0N25( )
      {
         A149ComandoEnviadoComandoComando = "";
         A150ComandoEnviadoComandoValor = "";
         Z149ComandoEnviadoComandoComando = "";
         Z150ComandoEnviadoComandoValor = "";
      }

      protected void InitAll0N25( )
      {
         A148ComandoEnviadoComandoId = 0;
         InitializeNonKey0N25( ) ;
      }

      protected void StandaloneModalInsert0N25( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142817572467", true, true);
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
         context.AddJavascriptSource("comandoenviado.js", "?202142817572468", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties25( )
      {
         edtComandoEnviadoComandoValor_Enabled = defedtComandoEnviadoComandoValor_Enabled;
         AssignProp("", false, edtComandoEnviadoComandoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoValor_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtComandoEnviadoComandoComando_Enabled = defedtComandoEnviadoComandoComando_Enabled;
         AssignProp("", false, edtComandoEnviadoComandoComando_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoComando_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtComandoEnviadoComandoId_Enabled = defedtComandoEnviadoComandoId_Enabled;
         AssignProp("", false, edtComandoEnviadoComandoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoEnviadoComandoId_Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void init_default_properties( )
      {
         edtComandoEnviadoId_Internalname = "COMANDOENVIADOID";
         edtComandoEnviadoResponsavelGUID_Internalname = "COMANDOENVIADORESPONSAVELGUID";
         edtComandoEnviadoDataHora_Internalname = "COMANDOENVIADODATAHORA";
         lblTextblockrastreadorid_Internalname = "TEXTBLOCKRASTREADORID";
         Combo_rastreadorid_Internalname = "COMBO_RASTREADORID";
         edtRastreadorId_Internalname = "RASTREADORID";
         divTablesplittedrastreadorid_Internalname = "TABLESPLITTEDRASTREADORID";
         edtRastreadorSNumber_Internalname = "RASTREADORSNUMBER";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtComandoEnviadoComandoId_Internalname = "COMANDOENVIADOCOMANDOID";
         edtComandoEnviadoComandoComando_Internalname = "COMANDOENVIADOCOMANDOCOMANDO";
         edtComandoEnviadoComandoValor_Internalname = "COMANDOENVIADOCOMANDOVALOR";
         divTableleaflevel_comando_Internalname = "TABLELEAFLEVEL_COMANDO";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComborastreadorid_Internalname = "vCOMBORASTREADORID";
         divSectionattribute_rastreadorid_Internalname = "SECTIONATTRIBUTE_RASTREADORID";
         edtComandoEnviadoSerial_Internalname = "COMANDOENVIADOSERIAL";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_comando_Internalname = "GRIDLEVEL_COMANDO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Comando Enviado";
         edtComandoEnviadoComandoValor_Jsonclick = "";
         edtComandoEnviadoComandoComando_Jsonclick = "";
         edtComandoEnviadoComandoId_Jsonclick = "";
         subGridlevel_comando_Class = "WorkWith";
         subGridlevel_comando_Backcolorstyle = 0;
         subGridlevel_comando_Rows = 5;
         subGridlevel_comando_Allowcollapsing = 0;
         subGridlevel_comando_Allowselection = 0;
         edtComandoEnviadoComandoValor_Enabled = 0;
         edtComandoEnviadoComandoComando_Enabled = 0;
         edtComandoEnviadoComandoId_Enabled = 0;
         subGridlevel_comando_Header = "";
         edtComandoEnviadoSerial_Jsonclick = "";
         edtComandoEnviadoSerial_Enabled = 1;
         edtComandoEnviadoSerial_Visible = 1;
         edtavComborastreadorid_Jsonclick = "";
         edtavComborastreadorid_Enabled = 0;
         edtavComborastreadorid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtRastreadorSNumber_Jsonclick = "";
         edtRastreadorSNumber_Enabled = 0;
         edtRastreadorId_Jsonclick = "";
         edtRastreadorId_Enabled = 1;
         edtRastreadorId_Visible = 1;
         Combo_rastreadorid_Emptyitem = Convert.ToBoolean( 0);
         Combo_rastreadorid_Datalistprocparametersprefix = " \"ComboName\": \"RastreadorId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ComandoEnviadoId\": 0";
         Combo_rastreadorid_Datalistproc = "ComandoEnviadoLoadDVCombo";
         Combo_rastreadorid_Cls = "ExtendedCombo Attribute";
         Combo_rastreadorid_Caption = "";
         Combo_rastreadorid_Enabled = Convert.ToBoolean( -1);
         edtComandoEnviadoDataHora_Jsonclick = "";
         edtComandoEnviadoDataHora_Enabled = 0;
         edtComandoEnviadoResponsavelGUID_Jsonclick = "";
         edtComandoEnviadoResponsavelGUID_Enabled = 0;
         edtComandoEnviadoId_Jsonclick = "";
         edtComandoEnviadoId_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX10ASACOMANDOENVIADORESPONSAVELGUID0N24( short Gx_BScreen ,
                                                               string Gx_mode )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A145ComandoEnviadoResponsavelGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char2 = A145ComandoEnviadoResponsavelGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char2) ;
            A145ComandoEnviadoResponsavelGUID = GXt_char2;
            AssignAttri("", false, "A145ComandoEnviadoResponsavelGUID", A145ComandoEnviadoResponsavelGUID);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A145ComandoEnviadoResponsavelGUID))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_comando_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5225( ) ;
         while ( nGXsfl_52_idx <= nRC_GXsfl_52 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0N25( ) ;
            standaloneModal0N25( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0N25( ) ;
            nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_5225( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_comandoContainer)) ;
         /* End function gxnrGridlevel_comando_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Rastreadorid( )
      {
         /* Using cursor T000N15 */
         pr_default.execute(13, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Rastreador'.", "ForeignKeyNotFound", 1, "RASTREADORID");
            AnyError = 1;
            GX_FocusControl = edtRastreadorId_Internalname;
         }
         A110RastreadorSNumber = T000N15_A110RastreadorSNumber[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110RastreadorSNumber), 16, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ComandoEnviadoId',fld:'vCOMANDOENVIADOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ComandoEnviadoId',fld:'vCOMANDOENVIADOID',pic:'ZZZZZZZ9',hsh:true},{av:'A144ComandoEnviadoId',fld:'COMANDOENVIADOID',pic:'ZZZZZZZ9'},{av:'A145ComandoEnviadoResponsavelGUID',fld:'COMANDOENVIADORESPONSAVELGUID',pic:''},{av:'A146ComandoEnviadoDataHora',fld:'COMANDOENVIADODATAHORA',pic:'99/99/99 99:99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120N2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_COMANDOENVIADOID","{handler:'Valid_Comandoenviadoid',iparms:[]");
         setEventMetadata("VALID_COMANDOENVIADOID",",oparms:[]}");
         setEventMetadata("VALID_RASTREADORID","{handler:'Valid_Rastreadorid',iparms:[{av:'A106RastreadorId',fld:'RASTREADORID',pic:'ZZZZZZZ9'},{av:'A110RastreadorSNumber',fld:'RASTREADORSNUMBER',pic:'ZZZZZZZZZZZZZZZ9'}]");
         setEventMetadata("VALID_RASTREADORID",",oparms:[{av:'A110RastreadorSNumber',fld:'RASTREADORSNUMBER',pic:'ZZZZZZZZZZZZZZZ9'}]}");
         setEventMetadata("VALIDV_COMBORASTREADORID","{handler:'Validv_Comborastreadorid',iparms:[]");
         setEventMetadata("VALIDV_COMBORASTREADORID",",oparms:[]}");
         setEventMetadata("VALID_COMANDOENVIADOCOMANDOID","{handler:'Valid_Comandoenviadocomandoid',iparms:[]");
         setEventMetadata("VALID_COMANDOENVIADOCOMANDOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Comandoenviadocomandovalor',iparms:[]");
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
         pr_default.close(1);
         pr_default.close(3);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z145ComandoEnviadoResponsavelGUID = "";
         Z146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         Combo_rastreadorid_Selectedvalue_get = "";
         Z149ComandoEnviadoComandoComando = "";
         Z150ComandoEnviadoComandoValor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A145ComandoEnviadoResponsavelGUID = "";
         A146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         lblTextblockrastreadorid_Jsonclick = "";
         ucCombo_rastreadorid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15RastreadorId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_comandoContainer = new GXWebGrid( context);
         Gridlevel_comandoColumn = new GXWebColumn();
         A149ComandoEnviadoComandoComando = "";
         A150ComandoEnviadoComandoValor = "";
         sMode25 = "";
         sStyleString = "";
         AV24Pgmname = "";
         Combo_rastreadorid_Objectcall = "";
         Combo_rastreadorid_Class = "";
         Combo_rastreadorid_Icontype = "";
         Combo_rastreadorid_Icon = "";
         Combo_rastreadorid_Tooltip = "";
         Combo_rastreadorid_Selectedvalue_set = "";
         Combo_rastreadorid_Selectedtext_set = "";
         Combo_rastreadorid_Selectedtext_get = "";
         Combo_rastreadorid_Gamoauthtoken = "";
         Combo_rastreadorid_Ddointernalname = "";
         Combo_rastreadorid_Titlecontrolalign = "";
         Combo_rastreadorid_Dropdownoptionstype = "";
         Combo_rastreadorid_Titlecontrolidtoreplace = "";
         Combo_rastreadorid_Datalisttype = "";
         Combo_rastreadorid_Datalistfixedvalues = "";
         Combo_rastreadorid_Htmltemplate = "";
         Combo_rastreadorid_Multiplevaluestype = "";
         Combo_rastreadorid_Loadingdata = "";
         Combo_rastreadorid_Noresultsfound = "";
         Combo_rastreadorid_Emptyitemtext = "";
         Combo_rastreadorid_Onlyselectedvalues = "";
         Combo_rastreadorid_Selectalltext = "";
         Combo_rastreadorid_Multiplevaluesseparator = "";
         Combo_rastreadorid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode24 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         T000N6_A110RastreadorSNumber = new long[1] ;
         T000N7_A144ComandoEnviadoId = new int[1] ;
         T000N7_A145ComandoEnviadoResponsavelGUID = new string[] {""} ;
         T000N7_A146ComandoEnviadoDataHora = new DateTime[] {DateTime.MinValue} ;
         T000N7_A110RastreadorSNumber = new long[1] ;
         T000N7_A147ComandoEnviadoSerial = new int[1] ;
         T000N7_A106RastreadorId = new int[1] ;
         T000N8_A110RastreadorSNumber = new long[1] ;
         T000N9_A144ComandoEnviadoId = new int[1] ;
         T000N5_A144ComandoEnviadoId = new int[1] ;
         T000N5_A145ComandoEnviadoResponsavelGUID = new string[] {""} ;
         T000N5_A146ComandoEnviadoDataHora = new DateTime[] {DateTime.MinValue} ;
         T000N5_A147ComandoEnviadoSerial = new int[1] ;
         T000N5_A106RastreadorId = new int[1] ;
         T000N10_A144ComandoEnviadoId = new int[1] ;
         T000N11_A144ComandoEnviadoId = new int[1] ;
         T000N4_A144ComandoEnviadoId = new int[1] ;
         T000N4_A145ComandoEnviadoResponsavelGUID = new string[] {""} ;
         T000N4_A146ComandoEnviadoDataHora = new DateTime[] {DateTime.MinValue} ;
         T000N4_A147ComandoEnviadoSerial = new int[1] ;
         T000N4_A106RastreadorId = new int[1] ;
         T000N12_A144ComandoEnviadoId = new int[1] ;
         T000N15_A110RastreadorSNumber = new long[1] ;
         T000N16_A144ComandoEnviadoId = new int[1] ;
         T000N17_A144ComandoEnviadoId = new int[1] ;
         T000N17_A148ComandoEnviadoComandoId = new int[1] ;
         T000N17_A149ComandoEnviadoComandoComando = new string[] {""} ;
         T000N17_A150ComandoEnviadoComandoValor = new string[] {""} ;
         T000N18_A144ComandoEnviadoId = new int[1] ;
         T000N18_A148ComandoEnviadoComandoId = new int[1] ;
         T000N3_A144ComandoEnviadoId = new int[1] ;
         T000N3_A148ComandoEnviadoComandoId = new int[1] ;
         T000N3_A149ComandoEnviadoComandoComando = new string[] {""} ;
         T000N3_A150ComandoEnviadoComandoValor = new string[] {""} ;
         T000N2_A144ComandoEnviadoId = new int[1] ;
         T000N2_A148ComandoEnviadoComandoId = new int[1] ;
         T000N2_A149ComandoEnviadoComandoComando = new string[] {""} ;
         T000N2_A150ComandoEnviadoComandoValor = new string[] {""} ;
         T000N22_A144ComandoEnviadoId = new int[1] ;
         T000N22_A148ComandoEnviadoComandoId = new int[1] ;
         Gridlevel_comandoRow = new GXWebRow();
         subGridlevel_comando_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         i145ComandoEnviadoResponsavelGUID = "";
         GXt_char2 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.comandoenviado__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comandoenviado__default(),
            new Object[][] {
                new Object[] {
               T000N2_A144ComandoEnviadoId, T000N2_A148ComandoEnviadoComandoId, T000N2_A149ComandoEnviadoComandoComando, T000N2_A150ComandoEnviadoComandoValor
               }
               , new Object[] {
               T000N3_A144ComandoEnviadoId, T000N3_A148ComandoEnviadoComandoId, T000N3_A149ComandoEnviadoComandoComando, T000N3_A150ComandoEnviadoComandoValor
               }
               , new Object[] {
               T000N4_A144ComandoEnviadoId, T000N4_A145ComandoEnviadoResponsavelGUID, T000N4_A146ComandoEnviadoDataHora, T000N4_A147ComandoEnviadoSerial, T000N4_A106RastreadorId
               }
               , new Object[] {
               T000N5_A144ComandoEnviadoId, T000N5_A145ComandoEnviadoResponsavelGUID, T000N5_A146ComandoEnviadoDataHora, T000N5_A147ComandoEnviadoSerial, T000N5_A106RastreadorId
               }
               , new Object[] {
               T000N6_A110RastreadorSNumber
               }
               , new Object[] {
               T000N7_A144ComandoEnviadoId, T000N7_A145ComandoEnviadoResponsavelGUID, T000N7_A146ComandoEnviadoDataHora, T000N7_A110RastreadorSNumber, T000N7_A147ComandoEnviadoSerial, T000N7_A106RastreadorId
               }
               , new Object[] {
               T000N8_A110RastreadorSNumber
               }
               , new Object[] {
               T000N9_A144ComandoEnviadoId
               }
               , new Object[] {
               T000N10_A144ComandoEnviadoId
               }
               , new Object[] {
               T000N11_A144ComandoEnviadoId
               }
               , new Object[] {
               T000N12_A144ComandoEnviadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N15_A110RastreadorSNumber
               }
               , new Object[] {
               T000N16_A144ComandoEnviadoId
               }
               , new Object[] {
               T000N17_A144ComandoEnviadoId, T000N17_A148ComandoEnviadoComandoId, T000N17_A149ComandoEnviadoComandoComando, T000N17_A150ComandoEnviadoComandoValor
               }
               , new Object[] {
               T000N18_A144ComandoEnviadoId, T000N18_A148ComandoEnviadoComandoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N22_A144ComandoEnviadoId, T000N22_A148ComandoEnviadoComandoId
               }
            }
         );
         AV24Pgmname = "ComandoEnviado";
         Z145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         A145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         i145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         A146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         i146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
      }

      private short nRcdDeleted_25 ;
      private short nRcdExists_25 ;
      private short nIsMod_25 ;
      private short GxWebError ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridlevel_comando_Backcolorstyle ;
      private short subGridlevel_comando_Allowselection ;
      private short subGridlevel_comando_Allowhovering ;
      private short subGridlevel_comando_Allowcollapsing ;
      private short subGridlevel_comando_Collapsed ;
      private short nBlankRcdCount25 ;
      private short RcdFound25 ;
      private short nBlankRcdUsr25 ;
      private short RcdFound24 ;
      private short GX_JID ;
      private short nIsDirty_24 ;
      private short nIsDirty_25 ;
      private short subGridlevel_comando_Backstyle ;
      private short gxajaxcallmode ;
      private int wcpOAV7ComandoEnviadoId ;
      private int Z144ComandoEnviadoId ;
      private int Z147ComandoEnviadoSerial ;
      private int Z106RastreadorId ;
      private int nRC_GXsfl_52 ;
      private int nGXsfl_52_idx=1 ;
      private int N106RastreadorId ;
      private int Z148ComandoEnviadoComandoId ;
      private int A106RastreadorId ;
      private int AV7ComandoEnviadoId ;
      private int trnEnded ;
      private int A144ComandoEnviadoId ;
      private int edtComandoEnviadoId_Enabled ;
      private int edtComandoEnviadoResponsavelGUID_Enabled ;
      private int edtComandoEnviadoDataHora_Enabled ;
      private int edtRastreadorId_Visible ;
      private int edtRastreadorId_Enabled ;
      private int edtRastreadorSNumber_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV20ComboRastreadorId ;
      private int edtavComborastreadorid_Enabled ;
      private int edtavComborastreadorid_Visible ;
      private int A147ComandoEnviadoSerial ;
      private int edtComandoEnviadoSerial_Enabled ;
      private int edtComandoEnviadoSerial_Visible ;
      private int A148ComandoEnviadoComandoId ;
      private int edtComandoEnviadoComandoId_Enabled ;
      private int edtComandoEnviadoComandoComando_Enabled ;
      private int edtComandoEnviadoComandoValor_Enabled ;
      private int subGridlevel_comando_Selectedindex ;
      private int subGridlevel_comando_Selectioncolor ;
      private int subGridlevel_comando_Hoveringcolor ;
      private int subGridlevel_comando_Rows ;
      private int fRowAdded ;
      private int AV13Insert_RastreadorId ;
      private int Combo_rastreadorid_Datalistupdateminimumcharacters ;
      private int Combo_rastreadorid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV25GXV1 ;
      private int subGridlevel_comando_Backcolor ;
      private int subGridlevel_comando_Allbackcolor ;
      private int defedtComandoEnviadoComandoValor_Enabled ;
      private int defedtComandoEnviadoComandoComando_Enabled ;
      private int defedtComandoEnviadoComandoId_Enabled ;
      private int idxLst ;
      private long A110RastreadorSNumber ;
      private long GRIDLEVEL_COMANDO_nFirstRecordOnPage ;
      private long Z110RastreadorSNumber ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z145ComandoEnviadoResponsavelGUID ;
      private string Combo_rastreadorid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string sGXsfl_52_idx="0001" ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRastreadorId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtComandoEnviadoId_Internalname ;
      private string edtComandoEnviadoId_Jsonclick ;
      private string edtComandoEnviadoResponsavelGUID_Internalname ;
      private string A145ComandoEnviadoResponsavelGUID ;
      private string edtComandoEnviadoResponsavelGUID_Jsonclick ;
      private string edtComandoEnviadoDataHora_Internalname ;
      private string edtComandoEnviadoDataHora_Jsonclick ;
      private string divTablesplittedrastreadorid_Internalname ;
      private string lblTextblockrastreadorid_Internalname ;
      private string lblTextblockrastreadorid_Jsonclick ;
      private string Combo_rastreadorid_Caption ;
      private string Combo_rastreadorid_Cls ;
      private string Combo_rastreadorid_Datalistproc ;
      private string Combo_rastreadorid_Datalistprocparametersprefix ;
      private string Combo_rastreadorid_Internalname ;
      private string TempTags ;
      private string edtRastreadorId_Jsonclick ;
      private string edtRastreadorSNumber_Internalname ;
      private string edtRastreadorSNumber_Jsonclick ;
      private string divTableleaflevel_comando_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_rastreadorid_Internalname ;
      private string edtavComborastreadorid_Internalname ;
      private string edtavComborastreadorid_Jsonclick ;
      private string edtComandoEnviadoSerial_Internalname ;
      private string edtComandoEnviadoSerial_Jsonclick ;
      private string subGridlevel_comando_Header ;
      private string sMode25 ;
      private string edtComandoEnviadoComandoId_Internalname ;
      private string edtComandoEnviadoComandoComando_Internalname ;
      private string edtComandoEnviadoComandoValor_Internalname ;
      private string sStyleString ;
      private string AV24Pgmname ;
      private string Combo_rastreadorid_Objectcall ;
      private string Combo_rastreadorid_Class ;
      private string Combo_rastreadorid_Icontype ;
      private string Combo_rastreadorid_Icon ;
      private string Combo_rastreadorid_Tooltip ;
      private string Combo_rastreadorid_Selectedvalue_set ;
      private string Combo_rastreadorid_Selectedtext_set ;
      private string Combo_rastreadorid_Selectedtext_get ;
      private string Combo_rastreadorid_Gamoauthtoken ;
      private string Combo_rastreadorid_Ddointernalname ;
      private string Combo_rastreadorid_Titlecontrolalign ;
      private string Combo_rastreadorid_Dropdownoptionstype ;
      private string Combo_rastreadorid_Titlecontrolidtoreplace ;
      private string Combo_rastreadorid_Datalisttype ;
      private string Combo_rastreadorid_Datalistfixedvalues ;
      private string Combo_rastreadorid_Htmltemplate ;
      private string Combo_rastreadorid_Multiplevaluestype ;
      private string Combo_rastreadorid_Loadingdata ;
      private string Combo_rastreadorid_Noresultsfound ;
      private string Combo_rastreadorid_Emptyitemtext ;
      private string Combo_rastreadorid_Onlyselectedvalues ;
      private string Combo_rastreadorid_Selectalltext ;
      private string Combo_rastreadorid_Multiplevaluesseparator ;
      private string Combo_rastreadorid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode24 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sGXsfl_52_fel_idx="0001" ;
      private string subGridlevel_comando_Class ;
      private string subGridlevel_comando_Linesclass ;
      private string ROClassString ;
      private string edtComandoEnviadoComandoId_Jsonclick ;
      private string edtComandoEnviadoComandoComando_Jsonclick ;
      private string edtComandoEnviadoComandoValor_Jsonclick ;
      private string GXCCtl ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i145ComandoEnviadoResponsavelGUID ;
      private string subGridlevel_comando_Internalname ;
      private string GXt_char2 ;
      private DateTime Z146ComandoEnviadoDataHora ;
      private DateTime A146ComandoEnviadoDataHora ;
      private DateTime i146ComandoEnviadoDataHora ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_rastreadorid_Emptyitem ;
      private bool bGXsfl_52_Refreshing=false ;
      private bool Combo_rastreadorid_Enabled ;
      private bool Combo_rastreadorid_Visible ;
      private bool Combo_rastreadorid_Allowmultipleselection ;
      private bool Combo_rastreadorid_Isgriditem ;
      private bool Combo_rastreadorid_Hasdescription ;
      private bool Combo_rastreadorid_Includeonlyselectedoption ;
      private bool Combo_rastreadorid_Includeselectalloption ;
      private bool Combo_rastreadorid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z149ComandoEnviadoComandoComando ;
      private string Z150ComandoEnviadoComandoValor ;
      private string A149ComandoEnviadoComandoComando ;
      private string A150ComandoEnviadoComandoValor ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_comandoContainer ;
      private GXWebRow Gridlevel_comandoRow ;
      private GXWebColumn Gridlevel_comandoColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_rastreadorid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T000N6_A110RastreadorSNumber ;
      private int[] T000N7_A144ComandoEnviadoId ;
      private string[] T000N7_A145ComandoEnviadoResponsavelGUID ;
      private DateTime[] T000N7_A146ComandoEnviadoDataHora ;
      private long[] T000N7_A110RastreadorSNumber ;
      private int[] T000N7_A147ComandoEnviadoSerial ;
      private int[] T000N7_A106RastreadorId ;
      private long[] T000N8_A110RastreadorSNumber ;
      private int[] T000N9_A144ComandoEnviadoId ;
      private int[] T000N5_A144ComandoEnviadoId ;
      private string[] T000N5_A145ComandoEnviadoResponsavelGUID ;
      private DateTime[] T000N5_A146ComandoEnviadoDataHora ;
      private int[] T000N5_A147ComandoEnviadoSerial ;
      private int[] T000N5_A106RastreadorId ;
      private int[] T000N10_A144ComandoEnviadoId ;
      private int[] T000N11_A144ComandoEnviadoId ;
      private int[] T000N4_A144ComandoEnviadoId ;
      private string[] T000N4_A145ComandoEnviadoResponsavelGUID ;
      private DateTime[] T000N4_A146ComandoEnviadoDataHora ;
      private int[] T000N4_A147ComandoEnviadoSerial ;
      private int[] T000N4_A106RastreadorId ;
      private int[] T000N12_A144ComandoEnviadoId ;
      private long[] T000N15_A110RastreadorSNumber ;
      private int[] T000N16_A144ComandoEnviadoId ;
      private int[] T000N17_A144ComandoEnviadoId ;
      private int[] T000N17_A148ComandoEnviadoComandoId ;
      private string[] T000N17_A149ComandoEnviadoComandoComando ;
      private string[] T000N17_A150ComandoEnviadoComandoValor ;
      private int[] T000N18_A144ComandoEnviadoId ;
      private int[] T000N18_A148ComandoEnviadoComandoId ;
      private int[] T000N3_A144ComandoEnviadoId ;
      private int[] T000N3_A148ComandoEnviadoComandoId ;
      private string[] T000N3_A149ComandoEnviadoComandoComando ;
      private string[] T000N3_A150ComandoEnviadoComandoValor ;
      private int[] T000N2_A144ComandoEnviadoId ;
      private int[] T000N2_A148ComandoEnviadoComandoId ;
      private string[] T000N2_A149ComandoEnviadoComandoComando ;
      private string[] T000N2_A150ComandoEnviadoComandoValor ;
      private int[] T000N22_A144ComandoEnviadoId ;
      private int[] T000N22_A148ComandoEnviadoComandoId ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15RastreadorId_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
   }

   public class comandoenviado__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class comandoenviado__default : DataStoreHelperBase, IDataStoreHelper
 {
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000N7;
        prmT000N7 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N6;
        prmT000N6 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N8;
        prmT000N8 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N9;
        prmT000N9 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N5;
        prmT000N5 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N10;
        prmT000N10 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N11;
        prmT000N11 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N4;
        prmT000N4 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N12;
        prmT000N12 = new Object[] {
        new Object[] {"@ComandoEnviadoResponsavelGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@ComandoEnviadoDataHora",SqlDbType.DateTime,8,5} ,
        new Object[] {"@ComandoEnviadoSerial",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N13;
        prmT000N13 = new Object[] {
        new Object[] {"@ComandoEnviadoResponsavelGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@ComandoEnviadoDataHora",SqlDbType.DateTime,8,5} ,
        new Object[] {"@ComandoEnviadoSerial",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N14;
        prmT000N14 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N16;
        prmT000N16 = new Object[] {
        };
        Object[] prmT000N17;
        prmT000N17 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N18;
        prmT000N18 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N3;
        prmT000N3 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N2;
        prmT000N2 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N19;
        prmT000N19 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoComando",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoEnviadoComandoValor",SqlDbType.NVarChar,256,0}
        };
        Object[] prmT000N20;
        prmT000N20 = new Object[] {
        new Object[] {"@ComandoEnviadoComandoComando",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoEnviadoComandoValor",SqlDbType.NVarChar,256,0} ,
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N21;
        prmT000N21 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N22;
        prmT000N22 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000N15;
        prmT000N15 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000N2", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor] FROM [ComandoEnviadoComando] WITH (UPDLOCK) WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N3", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N4", "SELECT [ComandoEnviadoId], [ComandoEnviadoResponsavelGUID], [ComandoEnviadoDataHora], [ComandoEnviadoSerial], [RastreadorId] FROM [ComandoEnviado] WITH (UPDLOCK) WHERE [ComandoEnviadoId] = @ComandoEnviadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N5", "SELECT [ComandoEnviadoId], [ComandoEnviadoResponsavelGUID], [ComandoEnviadoDataHora], [ComandoEnviadoSerial], [RastreadorId] FROM [ComandoEnviado] WHERE [ComandoEnviadoId] = @ComandoEnviadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N6", "SELECT [RastreadorSNumber] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N7", "SELECT TM1.[ComandoEnviadoId], TM1.[ComandoEnviadoResponsavelGUID], TM1.[ComandoEnviadoDataHora], T2.[RastreadorSNumber], TM1.[ComandoEnviadoSerial], TM1.[RastreadorId] FROM ([ComandoEnviado] TM1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = TM1.[RastreadorId]) WHERE TM1.[ComandoEnviadoId] = @ComandoEnviadoId ORDER BY TM1.[ComandoEnviadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N8", "SELECT [RastreadorSNumber] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N9", "SELECT [ComandoEnviadoId] FROM [ComandoEnviado] WHERE [ComandoEnviadoId] = @ComandoEnviadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N10", "SELECT TOP 1 [ComandoEnviadoId] FROM [ComandoEnviado] WHERE ( [ComandoEnviadoId] > @ComandoEnviadoId) ORDER BY [ComandoEnviadoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N11", "SELECT TOP 1 [ComandoEnviadoId] FROM [ComandoEnviado] WHERE ( [ComandoEnviadoId] < @ComandoEnviadoId) ORDER BY [ComandoEnviadoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N12", "INSERT INTO [ComandoEnviado]([ComandoEnviadoResponsavelGUID], [ComandoEnviadoDataHora], [ComandoEnviadoSerial], [RastreadorId]) VALUES(@ComandoEnviadoResponsavelGUID, @ComandoEnviadoDataHora, @ComandoEnviadoSerial, @RastreadorId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000N12)
           ,new CursorDef("T000N13", "UPDATE [ComandoEnviado] SET [ComandoEnviadoResponsavelGUID]=@ComandoEnviadoResponsavelGUID, [ComandoEnviadoDataHora]=@ComandoEnviadoDataHora, [ComandoEnviadoSerial]=@ComandoEnviadoSerial, [RastreadorId]=@RastreadorId  WHERE [ComandoEnviadoId] = @ComandoEnviadoId", GxErrorMask.GX_NOMASK,prmT000N13)
           ,new CursorDef("T000N14", "DELETE FROM [ComandoEnviado]  WHERE [ComandoEnviadoId] = @ComandoEnviadoId", GxErrorMask.GX_NOMASK,prmT000N14)
           ,new CursorDef("T000N15", "SELECT [RastreadorSNumber] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N16", "SELECT [ComandoEnviadoId] FROM [ComandoEnviado] ORDER BY [ComandoEnviadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N17", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId and [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId ORDER BY [ComandoEnviadoId], [ComandoEnviadoComandoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N18", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N19", "INSERT INTO [ComandoEnviadoComando]([ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor]) VALUES(@ComandoEnviadoId, @ComandoEnviadoComandoId, @ComandoEnviadoComandoComando, @ComandoEnviadoComandoValor)", GxErrorMask.GX_NOMASK,prmT000N19)
           ,new CursorDef("T000N20", "UPDATE [ComandoEnviadoComando] SET [ComandoEnviadoComandoComando]=@ComandoEnviadoComandoComando, [ComandoEnviadoComandoValor]=@ComandoEnviadoComandoValor  WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId", GxErrorMask.GX_NOMASK,prmT000N20)
           ,new CursorDef("T000N21", "DELETE FROM [ComandoEnviadoComando]  WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId", GxErrorMask.GX_NOMASK,prmT000N21)
           ,new CursorDef("T000N22", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId ORDER BY [ComandoEnviadoId], [ComandoEnviadoComandoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N22,11, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getInt(4);
              table[4][0] = rslt.getInt(5);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getInt(4);
              table[4][0] = rslt.getInt(5);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getLong(4);
              table[4][0] = rslt.getInt(5);
              table[5][0] = rslt.getInt(6);
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 7 :
              table[0][0] = rslt.getInt(1);
              return;
           case 8 :
              table[0][0] = rslt.getInt(1);
              return;
           case 9 :
              table[0][0] = rslt.getInt(1);
              return;
           case 10 :
              table[0][0] = rslt.getInt(1);
              return;
           case 13 :
              table[0][0] = rslt.getLong(1);
              return;
           case 14 :
              table[0][0] = rslt.getInt(1);
              return;
           case 15 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              return;
           case 16 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 20 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
     }
  }

  public void setParameters( int cursor ,
                             IFieldSetter stmt ,
                             Object[] parms )
  {
     switch ( cursor )
     {
           case 0 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 2 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 9 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              return;
           case 11 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              stmt.SetParameter(5, (int)parms[4]);
              return;
           case 12 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 13 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 15 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 16 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 17 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              return;
           case 18 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              return;
           case 19 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 20 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
