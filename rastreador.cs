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
   public class rastreador : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action19") == 0 )
         {
            A113ChipGSMId = (int)(NumberUtil.Val( GetPar( "ChipGSMId"), "."));
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_19_0H18( A113ChipGSMId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action20") == 0 )
         {
            A113ChipGSMId = (int)(NumberUtil.Val( GetPar( "ChipGSMId"), "."));
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_20_0H18( A113ChipGSMId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action21") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_21_0H18( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action22") == 0 )
         {
            A113ChipGSMId = (int)(NumberUtil.Val( GetPar( "ChipGSMId"), "."));
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_22_0H18( A113ChipGSMId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"RASTREADORGAMGUIDPROPRIETARIO") == 0 )
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
            GX13ASARASTREADORGAMGUIDPROPRIETARIO0H18( Gx_BScreen, Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A113ChipGSMId = (int)(NumberUtil.Val( GetPar( "ChipGSMId"), "."));
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A113ChipGSMId) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7RastreadorId = (int)(NumberUtil.Val( GetPar( "RastreadorId"), "."));
               AssignAttri("", false, "AV7RastreadorId", StringUtil.LTrimStr( (decimal)(AV7RastreadorId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vRASTREADORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RastreadorId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Rastreador", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbRastreadorFabricante_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public rastreador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rastreador( IGxContext context )
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
                           int aP1_RastreadorId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RastreadorId = aP1_RastreadorId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbRastreadorFabricante = new GXCombobox();
         cmbRastreadorModelo = new GXCombobox();
         chkRastreadorAtrelado = new GXCheckbox();
         cmbChipGSMOperadora = new GXCombobox();
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
            return "rastreador_Execute" ;
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
         if ( cmbRastreadorFabricante.ItemCount > 0 )
         {
            A108RastreadorFabricante = cmbRastreadorFabricante.getValidValue(A108RastreadorFabricante);
            n108RastreadorFabricante = false;
            AssignAttri("", false, "A108RastreadorFabricante", A108RastreadorFabricante);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRastreadorFabricante.CurrentValue = StringUtil.RTrim( A108RastreadorFabricante);
            AssignProp("", false, cmbRastreadorFabricante_Internalname, "Values", cmbRastreadorFabricante.ToJavascriptSource(), true);
         }
         if ( cmbRastreadorModelo.ItemCount > 0 )
         {
            A109RastreadorModelo = cmbRastreadorModelo.getValidValue(A109RastreadorModelo);
            n109RastreadorModelo = false;
            AssignAttri("", false, "A109RastreadorModelo", A109RastreadorModelo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRastreadorModelo.CurrentValue = StringUtil.RTrim( A109RastreadorModelo);
            AssignProp("", false, cmbRastreadorModelo_Internalname, "Values", cmbRastreadorModelo.ToJavascriptSource(), true);
         }
         A112RastreadorAtrelado = StringUtil.StrToBool( StringUtil.BoolToStr( A112RastreadorAtrelado));
         AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
         if ( cmbChipGSMOperadora.ItemCount > 0 )
         {
            A115ChipGSMOperadora = cmbChipGSMOperadora.getValidValue(A115ChipGSMOperadora);
            AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChipGSMOperadora.CurrentValue = StringUtil.RTrim( A115ChipGSMOperadora);
            AssignProp("", false, cmbChipGSMOperadora_Internalname, "Values", cmbChipGSMOperadora.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRastreadorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRastreadorId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRastreadorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106RastreadorId), 8, 0, ",", "")), ((edtRastreadorId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A106RastreadorId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A106RastreadorId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRastreadorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRastreadorId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Rastreador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRastreadorDataHoraCriacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRastreadorDataHoraCriacao_Internalname, "Data/Hora da Criação", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtRastreadorDataHoraCriacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRastreadorDataHoraCriacao_Internalname, context.localUtil.TToC( A107RastreadorDataHoraCriacao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A107RastreadorDataHoraCriacao, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRastreadorDataHoraCriacao_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtRastreadorDataHoraCriacao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Rastreador.htm");
         GxWebStd.gx_bitmap( context, edtRastreadorDataHoraCriacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRastreadorDataHoraCriacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Rastreador.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRastreadorGAMGUIDProprietario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRastreadorGAMGUIDProprietario_Internalname, "GAMGUID do Proprietário", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRastreadorGAMGUIDProprietario_Internalname, StringUtil.RTrim( A151RastreadorGAMGUIDProprietario), StringUtil.RTrim( context.localUtil.Format( A151RastreadorGAMGUIDProprietario, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRastreadorGAMGUIDProprietario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRastreadorGAMGUIDProprietario_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_Rastreador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbRastreadorFabricante_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRastreadorFabricante_Internalname, "Fabricante", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRastreadorFabricante, cmbRastreadorFabricante_Internalname, StringUtil.RTrim( A108RastreadorFabricante), 1, cmbRastreadorFabricante_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbRastreadorFabricante.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, "HLP_Rastreador.htm");
         cmbRastreadorFabricante.CurrentValue = StringUtil.RTrim( A108RastreadorFabricante);
         AssignProp("", false, cmbRastreadorFabricante_Internalname, "Values", (string)(cmbRastreadorFabricante.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbRastreadorModelo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRastreadorModelo_Internalname, "Modelo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRastreadorModelo, cmbRastreadorModelo_Internalname, StringUtil.RTrim( A109RastreadorModelo), 1, cmbRastreadorModelo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbRastreadorModelo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "", true, "HLP_Rastreador.htm");
         cmbRastreadorModelo.CurrentValue = StringUtil.RTrim( A109RastreadorModelo);
         AssignProp("", false, cmbRastreadorModelo_Internalname, "Values", (string)(cmbRastreadorModelo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRastreadorSNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRastreadorSNumber_Internalname, "ID do Rastreador", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRastreadorSNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110RastreadorSNumber), 16, 0, ",", "")), ((edtRastreadorSNumber_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A110RastreadorSNumber), "ZZZZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A110RastreadorSNumber), "ZZZZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRastreadorSNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRastreadorSNumber_Enabled, 0, "number", "1", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Rastreador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRastreadorDeviceIdFlespi_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRastreadorDeviceIdFlespi_Internalname, "Id no Flespi", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRastreadorDeviceIdFlespi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A111RastreadorDeviceIdFlespi), 16, 0, ",", "")), ((edtRastreadorDeviceIdFlespi_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A111RastreadorDeviceIdFlespi), "ZZZZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A111RastreadorDeviceIdFlespi), "ZZZZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRastreadorDeviceIdFlespi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRastreadorDeviceIdFlespi_Enabled, 0, "number", "1", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Rastreador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkRastreadorAtrelado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkRastreadorAtrelado_Internalname, "Rastreador no Veículo?", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkRastreadorAtrelado_Internalname, StringUtil.BoolToStr( A112RastreadorAtrelado), "", "Rastreador no Veículo?", 1, chkRastreadorAtrelado.Enabled, "true", "", StyleString, ClassString, "", "", "");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChipGSMId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChipGSMId_Internalname, "Sequência do ChipGSM", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChipGSMId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A113ChipGSMId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A113ChipGSMId), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChipGSMId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChipGSMId_Enabled, 1, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Rastreador.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_113_Internalname, sImgUrl, imgprompt_113_Link, "", "", context.GetTheme( ), imgprompt_113_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Rastreador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbChipGSMOperadora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbChipGSMOperadora_Internalname, "Operadora", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbChipGSMOperadora, cmbChipGSMOperadora_Internalname, StringUtil.RTrim( A115ChipGSMOperadora), 1, cmbChipGSMOperadora_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbChipGSMOperadora.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, "HLP_Rastreador.htm");
         cmbChipGSMOperadora.CurrentValue = StringUtil.RTrim( A115ChipGSMOperadora);
         AssignProp("", false, cmbChipGSMOperadora_Internalname, "Values", (string)(cmbChipGSMOperadora.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChipGSMNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChipGSMNumero_Internalname, "Número", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtChipGSMNumero_Internalname, A116ChipGSMNumero, StringUtil.RTrim( context.localUtil.Format( A116ChipGSMNumero, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChipGSMNumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChipGSMNumero_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Rastreador.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Rastreador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Rastreador.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Rastreador.htm");
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
         E110H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z106RastreadorId = (int)(context.localUtil.CToN( cgiGet( "Z106RastreadorId"), ",", "."));
               Z107RastreadorDataHoraCriacao = context.localUtil.CToT( cgiGet( "Z107RastreadorDataHoraCriacao"), 0);
               Z151RastreadorGAMGUIDProprietario = cgiGet( "Z151RastreadorGAMGUIDProprietario");
               Z108RastreadorFabricante = cgiGet( "Z108RastreadorFabricante");
               n108RastreadorFabricante = (String.IsNullOrEmpty(StringUtil.RTrim( A108RastreadorFabricante)) ? true : false);
               Z109RastreadorModelo = cgiGet( "Z109RastreadorModelo");
               n109RastreadorModelo = (String.IsNullOrEmpty(StringUtil.RTrim( A109RastreadorModelo)) ? true : false);
               Z110RastreadorSNumber = (long)(context.localUtil.CToN( cgiGet( "Z110RastreadorSNumber"), ",", "."));
               Z111RastreadorDeviceIdFlespi = (long)(context.localUtil.CToN( cgiGet( "Z111RastreadorDeviceIdFlespi"), ",", "."));
               Z112RastreadorAtrelado = StringUtil.StrToBool( cgiGet( "Z112RastreadorAtrelado"));
               Z113ChipGSMId = (int)(context.localUtil.CToN( cgiGet( "Z113ChipGSMId"), ",", "."));
               O113ChipGSMId = (int)(context.localUtil.CToN( cgiGet( "O113ChipGSMId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N113ChipGSMId = (int)(context.localUtil.CToN( cgiGet( "N113ChipGSMId"), ",", "."));
               AV7RastreadorId = (int)(context.localUtil.CToN( cgiGet( "vRASTREADORID"), ",", "."));
               AV13Insert_ChipGSMId = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CHIPGSMID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               AV24Pgmname = cgiGet( "vPGMNAME");
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
               A106RastreadorId = (int)(context.localUtil.CToN( cgiGet( edtRastreadorId_Internalname), ",", "."));
               AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
               A107RastreadorDataHoraCriacao = context.localUtil.CToT( cgiGet( edtRastreadorDataHoraCriacao_Internalname));
               AssignAttri("", false, "A107RastreadorDataHoraCriacao", context.localUtil.TToC( A107RastreadorDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
               A151RastreadorGAMGUIDProprietario = cgiGet( edtRastreadorGAMGUIDProprietario_Internalname);
               AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
               cmbRastreadorFabricante.CurrentValue = cgiGet( cmbRastreadorFabricante_Internalname);
               A108RastreadorFabricante = cgiGet( cmbRastreadorFabricante_Internalname);
               n108RastreadorFabricante = false;
               AssignAttri("", false, "A108RastreadorFabricante", A108RastreadorFabricante);
               n108RastreadorFabricante = (String.IsNullOrEmpty(StringUtil.RTrim( A108RastreadorFabricante)) ? true : false);
               cmbRastreadorModelo.CurrentValue = cgiGet( cmbRastreadorModelo_Internalname);
               A109RastreadorModelo = cgiGet( cmbRastreadorModelo_Internalname);
               n109RastreadorModelo = false;
               AssignAttri("", false, "A109RastreadorModelo", A109RastreadorModelo);
               n109RastreadorModelo = (String.IsNullOrEmpty(StringUtil.RTrim( A109RastreadorModelo)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRastreadorSNumber_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRastreadorSNumber_Internalname), ",", ".") > Convert.ToDecimal( 9999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RASTREADORSNUMBER");
                  AnyError = 1;
                  GX_FocusControl = edtRastreadorSNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A110RastreadorSNumber = 0;
                  AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
               }
               else
               {
                  A110RastreadorSNumber = (long)(context.localUtil.CToN( cgiGet( edtRastreadorSNumber_Internalname), ",", "."));
                  AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtRastreadorDeviceIdFlespi_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRastreadorDeviceIdFlespi_Internalname), ",", ".") > Convert.ToDecimal( 9999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RASTREADORDEVICEIDFLESPI");
                  AnyError = 1;
                  GX_FocusControl = edtRastreadorDeviceIdFlespi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A111RastreadorDeviceIdFlespi = 0;
                  AssignAttri("", false, "A111RastreadorDeviceIdFlespi", StringUtil.LTrimStr( (decimal)(A111RastreadorDeviceIdFlespi), 16, 0));
               }
               else
               {
                  A111RastreadorDeviceIdFlespi = (long)(context.localUtil.CToN( cgiGet( edtRastreadorDeviceIdFlespi_Internalname), ",", "."));
                  AssignAttri("", false, "A111RastreadorDeviceIdFlespi", StringUtil.LTrimStr( (decimal)(A111RastreadorDeviceIdFlespi), 16, 0));
               }
               A112RastreadorAtrelado = StringUtil.StrToBool( cgiGet( chkRastreadorAtrelado_Internalname));
               AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
               if ( ( ( context.localUtil.CToN( cgiGet( edtChipGSMId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtChipGSMId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHIPGSMID");
                  AnyError = 1;
                  GX_FocusControl = edtChipGSMId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A113ChipGSMId = 0;
                  AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
               }
               else
               {
                  A113ChipGSMId = (int)(context.localUtil.CToN( cgiGet( edtChipGSMId_Internalname), ",", "."));
                  AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
               }
               cmbChipGSMOperadora.CurrentValue = cgiGet( cmbChipGSMOperadora_Internalname);
               A115ChipGSMOperadora = cgiGet( cmbChipGSMOperadora_Internalname);
               AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
               A116ChipGSMNumero = cgiGet( edtChipGSMNumero_Internalname);
               AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Rastreador");
               A106RastreadorId = (int)(context.localUtil.CToN( cgiGet( edtRastreadorId_Internalname), ",", "."));
               AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
               forbiddenHiddens.Add("RastreadorId", context.localUtil.Format( (decimal)(A106RastreadorId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A107RastreadorDataHoraCriacao = context.localUtil.CToT( cgiGet( edtRastreadorDataHoraCriacao_Internalname));
               AssignAttri("", false, "A107RastreadorDataHoraCriacao", context.localUtil.TToC( A107RastreadorDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
               forbiddenHiddens.Add("RastreadorDataHoraCriacao", context.localUtil.Format( A107RastreadorDataHoraCriacao, "99/99/99 99:99"));
               A151RastreadorGAMGUIDProprietario = cgiGet( edtRastreadorGAMGUIDProprietario_Internalname);
               AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
               forbiddenHiddens.Add("RastreadorGAMGUIDProprietario", StringUtil.RTrim( context.localUtil.Format( A151RastreadorGAMGUIDProprietario, "")));
               A112RastreadorAtrelado = StringUtil.StrToBool( cgiGet( chkRastreadorAtrelado_Internalname));
               AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
               forbiddenHiddens.Add("RastreadorAtrelado", StringUtil.BoolToStr( A112RastreadorAtrelado));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A106RastreadorId != Z106RastreadorId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("rastreador:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A106RastreadorId = (int)(NumberUtil.Val( GetPar( "RastreadorId"), "."));
                  AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
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
                     sMode18 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode18;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound18 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RASTREADORID");
                        AnyError = 1;
                        GX_FocusControl = edtRastreadorId_Internalname;
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
                           E110H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120H2 ();
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
            E120H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0H18( ) ;
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
            DisableAttributes0H18( ) ;
         }
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H18( ) ;
            }
            else
            {
               CheckExtendedTable0H18( ) ;
               CloseExtendedTableCursors0H18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0H0( )
      {
      }

      protected void E110H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ChipGSMId") == 0 )
               {
                  AV13Insert_ChipGSMId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_ChipGSMId", StringUtil.LTrimStr( (decimal)(AV13Insert_ChipGSMId), 8, 0));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
      }

      protected void E120H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("rastreadorww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0H18( short GX_JID )
      {
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z107RastreadorDataHoraCriacao = T000H3_A107RastreadorDataHoraCriacao[0];
               Z151RastreadorGAMGUIDProprietario = T000H3_A151RastreadorGAMGUIDProprietario[0];
               Z108RastreadorFabricante = T000H3_A108RastreadorFabricante[0];
               Z109RastreadorModelo = T000H3_A109RastreadorModelo[0];
               Z110RastreadorSNumber = T000H3_A110RastreadorSNumber[0];
               Z111RastreadorDeviceIdFlespi = T000H3_A111RastreadorDeviceIdFlespi[0];
               Z112RastreadorAtrelado = T000H3_A112RastreadorAtrelado[0];
               Z113ChipGSMId = T000H3_A113ChipGSMId[0];
            }
            else
            {
               Z107RastreadorDataHoraCriacao = A107RastreadorDataHoraCriacao;
               Z151RastreadorGAMGUIDProprietario = A151RastreadorGAMGUIDProprietario;
               Z108RastreadorFabricante = A108RastreadorFabricante;
               Z109RastreadorModelo = A109RastreadorModelo;
               Z110RastreadorSNumber = A110RastreadorSNumber;
               Z111RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
               Z112RastreadorAtrelado = A112RastreadorAtrelado;
               Z113ChipGSMId = A113ChipGSMId;
            }
         }
         if ( GX_JID == -26 )
         {
            Z106RastreadorId = A106RastreadorId;
            Z107RastreadorDataHoraCriacao = A107RastreadorDataHoraCriacao;
            Z151RastreadorGAMGUIDProprietario = A151RastreadorGAMGUIDProprietario;
            Z108RastreadorFabricante = A108RastreadorFabricante;
            Z109RastreadorModelo = A109RastreadorModelo;
            Z110RastreadorSNumber = A110RastreadorSNumber;
            Z111RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            Z112RastreadorAtrelado = A112RastreadorAtrelado;
            Z113ChipGSMId = A113ChipGSMId;
            Z115ChipGSMOperadora = A115ChipGSMOperadora;
            Z116ChipGSMNumero = A116ChipGSMNumero;
         }
      }

      protected void standaloneNotModal( )
      {
         edtRastreadorId_Enabled = 0;
         AssignProp("", false, edtRastreadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorId_Enabled), 5, 0), true);
         edtRastreadorDataHoraCriacao_Enabled = 0;
         AssignProp("", false, edtRastreadorDataHoraCriacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorDataHoraCriacao_Enabled), 5, 0), true);
         edtRastreadorGAMGUIDProprietario_Enabled = 0;
         AssignProp("", false, edtRastreadorGAMGUIDProprietario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorGAMGUIDProprietario_Enabled), 5, 0), true);
         chkRastreadorAtrelado.Enabled = 0;
         AssignProp("", false, chkRastreadorAtrelado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkRastreadorAtrelado.Enabled), 5, 0), true);
         AV24Pgmname = "Rastreador";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_113_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"chipgsmprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CHIPGSMID"+"'), id:'"+"CHIPGSMID"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtRastreadorId_Enabled = 0;
         AssignProp("", false, edtRastreadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorId_Enabled), 5, 0), true);
         edtRastreadorDataHoraCriacao_Enabled = 0;
         AssignProp("", false, edtRastreadorDataHoraCriacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorDataHoraCriacao_Enabled), 5, 0), true);
         edtRastreadorGAMGUIDProprietario_Enabled = 0;
         AssignProp("", false, edtRastreadorGAMGUIDProprietario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorGAMGUIDProprietario_Enabled), 5, 0), true);
         chkRastreadorAtrelado.Enabled = 0;
         AssignProp("", false, chkRastreadorAtrelado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkRastreadorAtrelado.Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RastreadorId) )
         {
            A106RastreadorId = AV7RastreadorId;
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ChipGSMId) )
         {
            edtChipGSMId_Enabled = 0;
            AssignProp("", false, edtChipGSMId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMId_Enabled), 5, 0), true);
         }
         else
         {
            edtChipGSMId_Enabled = 1;
            AssignProp("", false, edtChipGSMId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ChipGSMId) )
         {
            A113ChipGSMId = AV13Insert_ChipGSMId;
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A107RastreadorDataHoraCriacao) && ( Gx_BScreen == 0 ) )
         {
            A107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A107RastreadorDataHoraCriacao", context.localUtil.TToC( A107RastreadorDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A151RastreadorGAMGUIDProprietario)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A151RastreadorGAMGUIDProprietario;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A151RastreadorGAMGUIDProprietario = GXt_char1;
            AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000H4 */
            pr_default.execute(2, new Object[] {A113ChipGSMId});
            A115ChipGSMOperadora = T000H4_A115ChipGSMOperadora[0];
            AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
            A116ChipGSMNumero = T000H4_A116ChipGSMNumero[0];
            AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
            pr_default.close(2);
         }
      }

      protected void Load0H18( )
      {
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound18 = 1;
            A107RastreadorDataHoraCriacao = T000H5_A107RastreadorDataHoraCriacao[0];
            AssignAttri("", false, "A107RastreadorDataHoraCriacao", context.localUtil.TToC( A107RastreadorDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
            A151RastreadorGAMGUIDProprietario = T000H5_A151RastreadorGAMGUIDProprietario[0];
            AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
            A108RastreadorFabricante = T000H5_A108RastreadorFabricante[0];
            n108RastreadorFabricante = T000H5_n108RastreadorFabricante[0];
            AssignAttri("", false, "A108RastreadorFabricante", A108RastreadorFabricante);
            A109RastreadorModelo = T000H5_A109RastreadorModelo[0];
            n109RastreadorModelo = T000H5_n109RastreadorModelo[0];
            AssignAttri("", false, "A109RastreadorModelo", A109RastreadorModelo);
            A110RastreadorSNumber = T000H5_A110RastreadorSNumber[0];
            AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
            A111RastreadorDeviceIdFlespi = T000H5_A111RastreadorDeviceIdFlespi[0];
            AssignAttri("", false, "A111RastreadorDeviceIdFlespi", StringUtil.LTrimStr( (decimal)(A111RastreadorDeviceIdFlespi), 16, 0));
            A112RastreadorAtrelado = T000H5_A112RastreadorAtrelado[0];
            AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
            A115ChipGSMOperadora = T000H5_A115ChipGSMOperadora[0];
            AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
            A116ChipGSMNumero = T000H5_A116ChipGSMNumero[0];
            AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
            A113ChipGSMId = T000H5_A113ChipGSMId[0];
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            ZM0H18( -26) ;
         }
         pr_default.close(3);
         OnLoadActions0H18( ) ;
      }

      protected void OnLoadActions0H18( )
      {
      }

      protected void CheckExtendedTable0H18( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A108RastreadorFabricante, "Maxtrack") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A108RastreadorFabricante)) ) )
         {
            GX_msglist.addItem("Campo Fabricante fora do intervalo", "OutOfRange", 1, "RASTREADORFABRICANTE");
            AnyError = 1;
            GX_FocusControl = cmbRastreadorFabricante_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108RastreadorFabricante)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Fabricante", "", "", "", "", "", "", "", ""), 1, "RASTREADORFABRICANTE");
            AnyError = 1;
            GX_FocusControl = cmbRastreadorFabricante_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A109RastreadorModelo, "MXT140") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A109RastreadorModelo)) ) )
         {
            GX_msglist.addItem("Campo Modelo fora do intervalo", "OutOfRange", 1, "RASTREADORMODELO");
            AnyError = 1;
            GX_FocusControl = cmbRastreadorModelo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109RastreadorModelo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Modelo", "", "", "", "", "", "", "", ""), 1, "RASTREADORMODELO");
            AnyError = 1;
            GX_FocusControl = cmbRastreadorModelo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A110RastreadorSNumber) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Rastreador", "", "", "", "", "", "", "", ""), 1, "RASTREADORSNUMBER");
            AnyError = 1;
            GX_FocusControl = edtRastreadorSNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A111RastreadorDeviceIdFlespi) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Id no Flespi", "", "", "", "", "", "", "", ""), 1, "RASTREADORDEVICEIDFLESPI");
            AnyError = 1;
            GX_FocusControl = edtRastreadorDeviceIdFlespi_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Chip GSM'.", "ForeignKeyNotFound", 1, "CHIPGSMID");
            AnyError = 1;
            GX_FocusControl = edtChipGSMId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A115ChipGSMOperadora = T000H4_A115ChipGSMOperadora[0];
         AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
         A116ChipGSMNumero = T000H4_A116ChipGSMNumero[0];
         AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0H18( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_27( int A113ChipGSMId )
      {
         /* Using cursor T000H6 */
         pr_default.execute(4, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Chip GSM'.", "ForeignKeyNotFound", 1, "CHIPGSMID");
            AnyError = 1;
            GX_FocusControl = edtChipGSMId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A115ChipGSMOperadora = T000H6_A115ChipGSMOperadora[0];
         AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
         A116ChipGSMNumero = T000H6_A116ChipGSMNumero[0];
         AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A115ChipGSMOperadora)+"\""+","+"\""+GXUtil.EncodeJSConstant( A116ChipGSMNumero)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0H18( )
      {
         /* Using cursor T000H7 */
         pr_default.execute(5, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H18( 26) ;
            RcdFound18 = 1;
            A106RastreadorId = T000H3_A106RastreadorId[0];
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
            A107RastreadorDataHoraCriacao = T000H3_A107RastreadorDataHoraCriacao[0];
            AssignAttri("", false, "A107RastreadorDataHoraCriacao", context.localUtil.TToC( A107RastreadorDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
            A151RastreadorGAMGUIDProprietario = T000H3_A151RastreadorGAMGUIDProprietario[0];
            AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
            A108RastreadorFabricante = T000H3_A108RastreadorFabricante[0];
            n108RastreadorFabricante = T000H3_n108RastreadorFabricante[0];
            AssignAttri("", false, "A108RastreadorFabricante", A108RastreadorFabricante);
            A109RastreadorModelo = T000H3_A109RastreadorModelo[0];
            n109RastreadorModelo = T000H3_n109RastreadorModelo[0];
            AssignAttri("", false, "A109RastreadorModelo", A109RastreadorModelo);
            A110RastreadorSNumber = T000H3_A110RastreadorSNumber[0];
            AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
            A111RastreadorDeviceIdFlespi = T000H3_A111RastreadorDeviceIdFlespi[0];
            AssignAttri("", false, "A111RastreadorDeviceIdFlespi", StringUtil.LTrimStr( (decimal)(A111RastreadorDeviceIdFlespi), 16, 0));
            A112RastreadorAtrelado = T000H3_A112RastreadorAtrelado[0];
            AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
            A113ChipGSMId = T000H3_A113ChipGSMId[0];
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            O113ChipGSMId = A113ChipGSMId;
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            Z106RastreadorId = A106RastreadorId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0H18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0H18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0H18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H18( ) ;
         if ( RcdFound18 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound18 = 0;
         /* Using cursor T000H8 */
         pr_default.execute(6, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000H8_A106RastreadorId[0] < A106RastreadorId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000H8_A106RastreadorId[0] > A106RastreadorId ) ) )
            {
               A106RastreadorId = T000H8_A106RastreadorId[0];
               AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000H9 */
         pr_default.execute(7, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000H9_A106RastreadorId[0] > A106RastreadorId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000H9_A106RastreadorId[0] < A106RastreadorId ) ) )
            {
               A106RastreadorId = T000H9_A106RastreadorId[0];
               AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbRastreadorFabricante_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A106RastreadorId != Z106RastreadorId )
               {
                  A106RastreadorId = Z106RastreadorId;
                  AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RASTREADORID");
                  AnyError = 1;
                  GX_FocusControl = edtRastreadorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbRastreadorFabricante_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0H18( ) ;
                  GX_FocusControl = cmbRastreadorFabricante_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A106RastreadorId != Z106RastreadorId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbRastreadorFabricante_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H18( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RASTREADORID");
                     AnyError = 1;
                     GX_FocusControl = edtRastreadorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbRastreadorFabricante_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H18( ) ;
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
         if ( A106RastreadorId != Z106RastreadorId )
         {
            A106RastreadorId = Z106RastreadorId;
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RASTREADORID");
            AnyError = 1;
            GX_FocusControl = edtRastreadorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbRastreadorFabricante_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0H18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rastreador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z107RastreadorDataHoraCriacao != T000H2_A107RastreadorDataHoraCriacao[0] ) || ( StringUtil.StrCmp(Z151RastreadorGAMGUIDProprietario, T000H2_A151RastreadorGAMGUIDProprietario[0]) != 0 ) || ( StringUtil.StrCmp(Z108RastreadorFabricante, T000H2_A108RastreadorFabricante[0]) != 0 ) || ( StringUtil.StrCmp(Z109RastreadorModelo, T000H2_A109RastreadorModelo[0]) != 0 ) || ( Z110RastreadorSNumber != T000H2_A110RastreadorSNumber[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z111RastreadorDeviceIdFlespi != T000H2_A111RastreadorDeviceIdFlespi[0] ) || ( Z112RastreadorAtrelado != T000H2_A112RastreadorAtrelado[0] ) || ( Z113ChipGSMId != T000H2_A113ChipGSMId[0] ) )
            {
               if ( Z107RastreadorDataHoraCriacao != T000H2_A107RastreadorDataHoraCriacao[0] )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"RastreadorDataHoraCriacao");
                  GXUtil.WriteLogRaw("Old: ",Z107RastreadorDataHoraCriacao);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A107RastreadorDataHoraCriacao[0]);
               }
               if ( StringUtil.StrCmp(Z151RastreadorGAMGUIDProprietario, T000H2_A151RastreadorGAMGUIDProprietario[0]) != 0 )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"RastreadorGAMGUIDProprietario");
                  GXUtil.WriteLogRaw("Old: ",Z151RastreadorGAMGUIDProprietario);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A151RastreadorGAMGUIDProprietario[0]);
               }
               if ( StringUtil.StrCmp(Z108RastreadorFabricante, T000H2_A108RastreadorFabricante[0]) != 0 )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"RastreadorFabricante");
                  GXUtil.WriteLogRaw("Old: ",Z108RastreadorFabricante);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A108RastreadorFabricante[0]);
               }
               if ( StringUtil.StrCmp(Z109RastreadorModelo, T000H2_A109RastreadorModelo[0]) != 0 )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"RastreadorModelo");
                  GXUtil.WriteLogRaw("Old: ",Z109RastreadorModelo);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A109RastreadorModelo[0]);
               }
               if ( Z110RastreadorSNumber != T000H2_A110RastreadorSNumber[0] )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"RastreadorSNumber");
                  GXUtil.WriteLogRaw("Old: ",Z110RastreadorSNumber);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A110RastreadorSNumber[0]);
               }
               if ( Z111RastreadorDeviceIdFlespi != T000H2_A111RastreadorDeviceIdFlespi[0] )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"RastreadorDeviceIdFlespi");
                  GXUtil.WriteLogRaw("Old: ",Z111RastreadorDeviceIdFlespi);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A111RastreadorDeviceIdFlespi[0]);
               }
               if ( Z112RastreadorAtrelado != T000H2_A112RastreadorAtrelado[0] )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"RastreadorAtrelado");
                  GXUtil.WriteLogRaw("Old: ",Z112RastreadorAtrelado);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A112RastreadorAtrelado[0]);
               }
               if ( Z113ChipGSMId != T000H2_A113ChipGSMId[0] )
               {
                  GXUtil.WriteLog("rastreador:[seudo value changed for attri]"+"ChipGSMId");
                  GXUtil.WriteLogRaw("Old: ",Z113ChipGSMId);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A113ChipGSMId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Rastreador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H18( )
      {
         if ( ! IsAuthorized("rastreador_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H18( 0) ;
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H10 */
                     pr_default.execute(8, new Object[] {A107RastreadorDataHoraCriacao, A151RastreadorGAMGUIDProprietario, n108RastreadorFabricante, A108RastreadorFabricante, n109RastreadorModelo, A109RastreadorModelo, A110RastreadorSNumber, A111RastreadorDeviceIdFlespi, A112RastreadorAtrelado, A113ChipGSMId});
                     A106RastreadorId = T000H10_A106RastreadorId[0];
                     AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( ! (0==A113ChipGSMId) ) )
                        {
                           new atrelarchipgsm(context ).execute(  A113ChipGSMId) ;
                        }
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0H0( ) ;
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
               Load0H18( ) ;
            }
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void Update0H18( )
      {
         if ( ! IsAuthorized("rastreador_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H11 */
                     pr_default.execute(9, new Object[] {A107RastreadorDataHoraCriacao, A151RastreadorGAMGUIDProprietario, n108RastreadorFabricante, A108RastreadorFabricante, n109RastreadorModelo, A109RastreadorModelo, A110RastreadorSNumber, A111RastreadorDeviceIdFlespi, A112RastreadorAtrelado, A113ChipGSMId, A106RastreadorId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rastreador"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( ! (0==A113ChipGSMId) ) )
                        {
                           new atrelarchipgsm(context ).execute(  A113ChipGSMId) ;
                        }
                        if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( (0==A113ChipGSMId) ) )
                        {
                           new desatrelarchipgsm(context ).execute(  O113ChipGSMId) ;
                        }
                        /* End of After( update) rules */
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
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void DeferredUpdate0H18( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("rastreador_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H18( ) ;
            AfterConfirm0H18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H12 */
                  pr_default.execute(10, new Object[] {A106RastreadorId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000H13 */
            pr_default.execute(11, new Object[] {A113ChipGSMId});
            A115ChipGSMOperadora = T000H13_A115ChipGSMOperadora[0];
            AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
            A116ChipGSMNumero = T000H13_A116ChipGSMNumero[0];
            AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000H14 */
            pr_default.execute(12, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Comando Enviado"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000H15 */
            pr_default.execute(13, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Veiculo Rastreador"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0H18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("rastreador",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            if ( IsIns( )  )
            {
               new atualizasubscribersmqtt(context ).execute(  AV7RastreadorId,  A110RastreadorSNumber,  A111RastreadorDeviceIdFlespi,  true) ;
            }
            if ( IsUpd( )  )
            {
               new atualizasubscribersmqtt(context ).execute(  AV7RastreadorId,  A110RastreadorSNumber,  A111RastreadorDeviceIdFlespi,  false) ;
            }
            if ( IsIns( )  )
            {
               new atualizasubscribersmqtt(context ).execute(  A106RastreadorId,  A110RastreadorSNumber,  A111RastreadorDeviceIdFlespi,  false) ;
            }
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("rastreador",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H18( )
      {
         /* Scan By routine */
         /* Using cursor T000H16 */
         pr_default.execute(14);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound18 = 1;
            A106RastreadorId = T000H16_A106RastreadorId[0];
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H18( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound18 = 1;
            A106RastreadorId = T000H16_A106RastreadorId[0];
            AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
         }
      }

      protected void ScanEnd0H18( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0H18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H18( )
      {
         /* Before Delete Rules */
         new desatrelarchipgsm(context ).execute(  A113ChipGSMId) ;
      }

      protected void BeforeComplete0H18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H18( )
      {
         edtRastreadorId_Enabled = 0;
         AssignProp("", false, edtRastreadorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorId_Enabled), 5, 0), true);
         edtRastreadorDataHoraCriacao_Enabled = 0;
         AssignProp("", false, edtRastreadorDataHoraCriacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorDataHoraCriacao_Enabled), 5, 0), true);
         edtRastreadorGAMGUIDProprietario_Enabled = 0;
         AssignProp("", false, edtRastreadorGAMGUIDProprietario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorGAMGUIDProprietario_Enabled), 5, 0), true);
         cmbRastreadorFabricante.Enabled = 0;
         AssignProp("", false, cmbRastreadorFabricante_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRastreadorFabricante.Enabled), 5, 0), true);
         cmbRastreadorModelo.Enabled = 0;
         AssignProp("", false, cmbRastreadorModelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRastreadorModelo.Enabled), 5, 0), true);
         edtRastreadorSNumber_Enabled = 0;
         AssignProp("", false, edtRastreadorSNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorSNumber_Enabled), 5, 0), true);
         edtRastreadorDeviceIdFlespi_Enabled = 0;
         AssignProp("", false, edtRastreadorDeviceIdFlespi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRastreadorDeviceIdFlespi_Enabled), 5, 0), true);
         chkRastreadorAtrelado.Enabled = 0;
         AssignProp("", false, chkRastreadorAtrelado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkRastreadorAtrelado.Enabled), 5, 0), true);
         edtChipGSMId_Enabled = 0;
         AssignProp("", false, edtChipGSMId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMId_Enabled), 5, 0), true);
         cmbChipGSMOperadora.Enabled = 0;
         AssignProp("", false, cmbChipGSMOperadora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChipGSMOperadora.Enabled), 5, 0), true);
         edtChipGSMNumero_Enabled = 0;
         AssignProp("", false, edtChipGSMNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMNumero_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0H18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0H0( )
      {
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
         context.AddJavascriptSource("gxcfg.js", "?202142918275512", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rastreador.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7RastreadorId,8,0))}, new string[] {"Gx_mode","RastreadorId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Rastreador");
         forbiddenHiddens.Add("RastreadorId", context.localUtil.Format( (decimal)(A106RastreadorId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("RastreadorDataHoraCriacao", context.localUtil.Format( A107RastreadorDataHoraCriacao, "99/99/99 99:99"));
         forbiddenHiddens.Add("RastreadorGAMGUIDProprietario", StringUtil.RTrim( context.localUtil.Format( A151RastreadorGAMGUIDProprietario, "")));
         A112RastreadorAtrelado = StringUtil.StrToBool( StringUtil.BoolToStr( A112RastreadorAtrelado));
         AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
         forbiddenHiddens.Add("RastreadorAtrelado", StringUtil.BoolToStr( A112RastreadorAtrelado));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("rastreador:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z106RastreadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106RastreadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z107RastreadorDataHoraCriacao", context.localUtil.TToC( Z107RastreadorDataHoraCriacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z151RastreadorGAMGUIDProprietario", StringUtil.RTrim( Z151RastreadorGAMGUIDProprietario));
         GxWebStd.gx_hidden_field( context, "Z108RastreadorFabricante", Z108RastreadorFabricante);
         GxWebStd.gx_hidden_field( context, "Z109RastreadorModelo", Z109RastreadorModelo);
         GxWebStd.gx_hidden_field( context, "Z110RastreadorSNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110RastreadorSNumber), 16, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z111RastreadorDeviceIdFlespi", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z111RastreadorDeviceIdFlespi), 16, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z112RastreadorAtrelado", Z112RastreadorAtrelado);
         GxWebStd.gx_hidden_field( context, "Z113ChipGSMId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z113ChipGSMId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O113ChipGSMId", StringUtil.LTrim( StringUtil.NToC( (decimal)(O113ChipGSMId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N113ChipGSMId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A113ChipGSMId), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vRASTREADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RastreadorId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRASTREADORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RastreadorId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CHIPGSMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ChipGSMId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
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
         return formatLink("rastreador.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7RastreadorId,8,0))}, new string[] {"Gx_mode","RastreadorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Rastreador" ;
      }

      public override string GetPgmdesc( )
      {
         return "Rastreador" ;
      }

      protected void InitializeNonKey0H18( )
      {
         A113ChipGSMId = 0;
         AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
         A108RastreadorFabricante = "";
         n108RastreadorFabricante = false;
         AssignAttri("", false, "A108RastreadorFabricante", A108RastreadorFabricante);
         n108RastreadorFabricante = (String.IsNullOrEmpty(StringUtil.RTrim( A108RastreadorFabricante)) ? true : false);
         A109RastreadorModelo = "";
         n109RastreadorModelo = false;
         AssignAttri("", false, "A109RastreadorModelo", A109RastreadorModelo);
         n109RastreadorModelo = (String.IsNullOrEmpty(StringUtil.RTrim( A109RastreadorModelo)) ? true : false);
         A110RastreadorSNumber = 0;
         AssignAttri("", false, "A110RastreadorSNumber", StringUtil.LTrimStr( (decimal)(A110RastreadorSNumber), 16, 0));
         A111RastreadorDeviceIdFlespi = 0;
         AssignAttri("", false, "A111RastreadorDeviceIdFlespi", StringUtil.LTrimStr( (decimal)(A111RastreadorDeviceIdFlespi), 16, 0));
         A112RastreadorAtrelado = false;
         AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
         A115ChipGSMOperadora = "";
         AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
         A116ChipGSMNumero = "";
         AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
         A107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "A107RastreadorDataHoraCriacao", context.localUtil.TToC( A107RastreadorDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
         A151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
         O113ChipGSMId = A113ChipGSMId;
         AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
         Z107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z151RastreadorGAMGUIDProprietario = "";
         Z108RastreadorFabricante = "";
         Z109RastreadorModelo = "";
         Z110RastreadorSNumber = 0;
         Z111RastreadorDeviceIdFlespi = 0;
         Z112RastreadorAtrelado = false;
         Z113ChipGSMId = 0;
      }

      protected void InitAll0H18( )
      {
         A106RastreadorId = 0;
         AssignAttri("", false, "A106RastreadorId", StringUtil.LTrimStr( (decimal)(A106RastreadorId), 8, 0));
         InitializeNonKey0H18( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A107RastreadorDataHoraCriacao = i107RastreadorDataHoraCriacao;
         AssignAttri("", false, "A107RastreadorDataHoraCriacao", context.localUtil.TToC( A107RastreadorDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
         A151RastreadorGAMGUIDProprietario = i151RastreadorGAMGUIDProprietario;
         AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918275548", true, true);
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
         context.AddJavascriptSource("rastreador.js", "?202142918275549", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtRastreadorId_Internalname = "RASTREADORID";
         edtRastreadorDataHoraCriacao_Internalname = "RASTREADORDATAHORACRIACAO";
         edtRastreadorGAMGUIDProprietario_Internalname = "RASTREADORGAMGUIDPROPRIETARIO";
         cmbRastreadorFabricante_Internalname = "RASTREADORFABRICANTE";
         cmbRastreadorModelo_Internalname = "RASTREADORMODELO";
         edtRastreadorSNumber_Internalname = "RASTREADORSNUMBER";
         edtRastreadorDeviceIdFlespi_Internalname = "RASTREADORDEVICEIDFLESPI";
         chkRastreadorAtrelado_Internalname = "RASTREADORATRELADO";
         edtChipGSMId_Internalname = "CHIPGSMID";
         cmbChipGSMOperadora_Internalname = "CHIPGSMOPERADORA";
         edtChipGSMNumero_Internalname = "CHIPGSMNUMERO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_113_Internalname = "PROMPT_113";
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
         Form.Caption = "Rastreador";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtChipGSMNumero_Jsonclick = "";
         edtChipGSMNumero_Enabled = 0;
         cmbChipGSMOperadora_Jsonclick = "";
         cmbChipGSMOperadora.Enabled = 0;
         imgprompt_113_Visible = 1;
         imgprompt_113_Link = "";
         edtChipGSMId_Jsonclick = "";
         edtChipGSMId_Enabled = 1;
         chkRastreadorAtrelado.Enabled = 0;
         edtRastreadorDeviceIdFlespi_Jsonclick = "";
         edtRastreadorDeviceIdFlespi_Enabled = 1;
         edtRastreadorSNumber_Jsonclick = "";
         edtRastreadorSNumber_Enabled = 1;
         cmbRastreadorModelo_Jsonclick = "";
         cmbRastreadorModelo.Enabled = 1;
         cmbRastreadorFabricante_Jsonclick = "";
         cmbRastreadorFabricante.Enabled = 1;
         edtRastreadorGAMGUIDProprietario_Jsonclick = "";
         edtRastreadorGAMGUIDProprietario_Enabled = 0;
         edtRastreadorDataHoraCriacao_Jsonclick = "";
         edtRastreadorDataHoraCriacao_Enabled = 0;
         edtRastreadorId_Jsonclick = "";
         edtRastreadorId_Enabled = 0;
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

      protected void GX13ASARASTREADORGAMGUIDPROPRIETARIO0H18( short Gx_BScreen ,
                                                               string Gx_mode )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A151RastreadorGAMGUIDProprietario)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A151RastreadorGAMGUIDProprietario;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A151RastreadorGAMGUIDProprietario = GXt_char1;
            AssignAttri("", false, "A151RastreadorGAMGUIDProprietario", A151RastreadorGAMGUIDProprietario);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A151RastreadorGAMGUIDProprietario))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_19_0H18( int A113ChipGSMId )
      {
         if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( ! (0==A113ChipGSMId) ) )
         {
            new atrelarchipgsm(context ).execute(  A113ChipGSMId) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_20_0H18( int A113ChipGSMId )
      {
         if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( ! (0==A113ChipGSMId) ) )
         {
            new atrelarchipgsm(context ).execute(  A113ChipGSMId) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_21_0H18( )
      {
         if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( (0==A113ChipGSMId) ) )
         {
            new desatrelarchipgsm(context ).execute(  O113ChipGSMId) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_22_0H18( int A113ChipGSMId )
      {
         new desatrelarchipgsm(context ).execute(  A113ChipGSMId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbRastreadorFabricante.Name = "RASTREADORFABRICANTE";
         cmbRastreadorFabricante.WebTags = "";
         cmbRastreadorFabricante.addItem("", "Selecione", 0);
         cmbRastreadorFabricante.addItem("Maxtrack", "Maxtrack", 0);
         if ( cmbRastreadorFabricante.ItemCount > 0 )
         {
            A108RastreadorFabricante = cmbRastreadorFabricante.getValidValue(A108RastreadorFabricante);
            n108RastreadorFabricante = false;
            AssignAttri("", false, "A108RastreadorFabricante", A108RastreadorFabricante);
         }
         cmbRastreadorModelo.Name = "RASTREADORMODELO";
         cmbRastreadorModelo.WebTags = "";
         cmbRastreadorModelo.addItem("", "Selecione", 0);
         cmbRastreadorModelo.addItem("MXT140", "MXT140", 0);
         if ( cmbRastreadorModelo.ItemCount > 0 )
         {
            A109RastreadorModelo = cmbRastreadorModelo.getValidValue(A109RastreadorModelo);
            n109RastreadorModelo = false;
            AssignAttri("", false, "A109RastreadorModelo", A109RastreadorModelo);
         }
         chkRastreadorAtrelado.Name = "RASTREADORATRELADO";
         chkRastreadorAtrelado.WebTags = "";
         chkRastreadorAtrelado.Caption = "";
         AssignProp("", false, chkRastreadorAtrelado_Internalname, "TitleCaption", chkRastreadorAtrelado.Caption, true);
         chkRastreadorAtrelado.CheckedValue = "false";
         A112RastreadorAtrelado = StringUtil.StrToBool( StringUtil.BoolToStr( A112RastreadorAtrelado));
         AssignAttri("", false, "A112RastreadorAtrelado", A112RastreadorAtrelado);
         cmbChipGSMOperadora.Name = "CHIPGSMOPERADORA";
         cmbChipGSMOperadora.WebTags = "";
         cmbChipGSMOperadora.addItem("", "Selecione", 0);
         cmbChipGSMOperadora.addItem("Claro", "Claro", 0);
         cmbChipGSMOperadora.addItem("Vivo", "Vivo", 0);
         cmbChipGSMOperadora.addItem("Oi", "Oi", 0);
         cmbChipGSMOperadora.addItem("TIM", "TIM", 0);
         cmbChipGSMOperadora.addItem("Vodafone", "Vodafone", 0);
         if ( cmbChipGSMOperadora.ItemCount > 0 )
         {
            A115ChipGSMOperadora = cmbChipGSMOperadora.getValidValue(A115ChipGSMOperadora);
            AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
         }
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

      public void Valid_Chipgsmid( )
      {
         A115ChipGSMOperadora = cmbChipGSMOperadora.CurrentValue;
         cmbChipGSMOperadora.CurrentValue = A115ChipGSMOperadora;
         /* Using cursor T000H13 */
         pr_default.execute(11, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("Não existe 'Chip GSM'.", "ForeignKeyNotFound", 1, "CHIPGSMID");
            AnyError = 1;
            GX_FocusControl = edtChipGSMId_Internalname;
         }
         A115ChipGSMOperadora = T000H13_A115ChipGSMOperadora[0];
         cmbChipGSMOperadora.CurrentValue = A115ChipGSMOperadora;
         A116ChipGSMNumero = T000H13_A116ChipGSMNumero[0];
         pr_default.close(11);
         dynload_actions( ) ;
         if ( cmbChipGSMOperadora.ItemCount > 0 )
         {
            A115ChipGSMOperadora = cmbChipGSMOperadora.getValidValue(A115ChipGSMOperadora);
            cmbChipGSMOperadora.CurrentValue = A115ChipGSMOperadora;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChipGSMOperadora.CurrentValue = StringUtil.RTrim( A115ChipGSMOperadora);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
         cmbChipGSMOperadora.CurrentValue = StringUtil.RTrim( A115ChipGSMOperadora);
         AssignProp("", false, cmbChipGSMOperadora_Internalname, "Values", cmbChipGSMOperadora.ToJavascriptSource(), true);
         AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9',hsh:true},{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9',hsh:true},{av:'A106RastreadorId',fld:'RASTREADORID',pic:'ZZZZZZZ9'},{av:'A107RastreadorDataHoraCriacao',fld:'RASTREADORDATAHORACRIACAO',pic:'99/99/99 99:99'},{av:'A151RastreadorGAMGUIDProprietario',fld:'RASTREADORGAMGUIDPROPRIETARIO',pic:''},{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120H2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("VALID_RASTREADORID","{handler:'Valid_Rastreadorid',iparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("VALID_RASTREADORID",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("VALID_RASTREADORFABRICANTE","{handler:'Valid_Rastreadorfabricante',iparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("VALID_RASTREADORFABRICANTE",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("VALID_RASTREADORMODELO","{handler:'Valid_Rastreadormodelo',iparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("VALID_RASTREADORMODELO",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("VALID_RASTREADORSNUMBER","{handler:'Valid_Rastreadorsnumber',iparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("VALID_RASTREADORSNUMBER",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("VALID_RASTREADORDEVICEIDFLESPI","{handler:'Valid_Rastreadordeviceidflespi',iparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("VALID_RASTREADORDEVICEIDFLESPI",",oparms:[{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
         setEventMetadata("VALID_CHIPGSMID","{handler:'Valid_Chipgsmid',iparms:[{av:'A113ChipGSMId',fld:'CHIPGSMID',pic:'ZZZZZZZ9'},{av:'cmbChipGSMOperadora'},{av:'A115ChipGSMOperadora',fld:'CHIPGSMOPERADORA',pic:''},{av:'A116ChipGSMNumero',fld:'CHIPGSMNUMERO',pic:''},{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]");
         setEventMetadata("VALID_CHIPGSMID",",oparms:[{av:'cmbChipGSMOperadora'},{av:'A115ChipGSMOperadora',fld:'CHIPGSMOPERADORA',pic:''},{av:'A116ChipGSMNumero',fld:'CHIPGSMNUMERO',pic:''},{av:'A112RastreadorAtrelado',fld:'RASTREADORATRELADO',pic:''}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z151RastreadorGAMGUIDProprietario = "";
         Z108RastreadorFabricante = "";
         Z109RastreadorModelo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A108RastreadorFabricante = "";
         A109RastreadorModelo = "";
         A115ChipGSMOperadora = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         A151RastreadorGAMGUIDProprietario = "";
         TempTags = "";
         sImgUrl = "";
         A116ChipGSMNumero = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV24Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode18 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z115ChipGSMOperadora = "";
         Z116ChipGSMNumero = "";
         T000H4_A115ChipGSMOperadora = new string[] {""} ;
         T000H4_A116ChipGSMNumero = new string[] {""} ;
         T000H5_A106RastreadorId = new int[1] ;
         T000H5_A107RastreadorDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         T000H5_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         T000H5_A108RastreadorFabricante = new string[] {""} ;
         T000H5_n108RastreadorFabricante = new bool[] {false} ;
         T000H5_A109RastreadorModelo = new string[] {""} ;
         T000H5_n109RastreadorModelo = new bool[] {false} ;
         T000H5_A110RastreadorSNumber = new long[1] ;
         T000H5_A111RastreadorDeviceIdFlespi = new long[1] ;
         T000H5_A112RastreadorAtrelado = new bool[] {false} ;
         T000H5_A115ChipGSMOperadora = new string[] {""} ;
         T000H5_A116ChipGSMNumero = new string[] {""} ;
         T000H5_A113ChipGSMId = new int[1] ;
         T000H6_A115ChipGSMOperadora = new string[] {""} ;
         T000H6_A116ChipGSMNumero = new string[] {""} ;
         T000H7_A106RastreadorId = new int[1] ;
         T000H3_A106RastreadorId = new int[1] ;
         T000H3_A107RastreadorDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         T000H3_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         T000H3_A108RastreadorFabricante = new string[] {""} ;
         T000H3_n108RastreadorFabricante = new bool[] {false} ;
         T000H3_A109RastreadorModelo = new string[] {""} ;
         T000H3_n109RastreadorModelo = new bool[] {false} ;
         T000H3_A110RastreadorSNumber = new long[1] ;
         T000H3_A111RastreadorDeviceIdFlespi = new long[1] ;
         T000H3_A112RastreadorAtrelado = new bool[] {false} ;
         T000H3_A113ChipGSMId = new int[1] ;
         T000H8_A106RastreadorId = new int[1] ;
         T000H9_A106RastreadorId = new int[1] ;
         T000H2_A106RastreadorId = new int[1] ;
         T000H2_A107RastreadorDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         T000H2_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         T000H2_A108RastreadorFabricante = new string[] {""} ;
         T000H2_n108RastreadorFabricante = new bool[] {false} ;
         T000H2_A109RastreadorModelo = new string[] {""} ;
         T000H2_n109RastreadorModelo = new bool[] {false} ;
         T000H2_A110RastreadorSNumber = new long[1] ;
         T000H2_A111RastreadorDeviceIdFlespi = new long[1] ;
         T000H2_A112RastreadorAtrelado = new bool[] {false} ;
         T000H2_A113ChipGSMId = new int[1] ;
         T000H10_A106RastreadorId = new int[1] ;
         T000H13_A115ChipGSMOperadora = new string[] {""} ;
         T000H13_A116ChipGSMNumero = new string[] {""} ;
         T000H14_A144ComandoEnviadoId = new int[1] ;
         T000H15_A98VeiculoId = new int[1] ;
         T000H15_A106RastreadorId = new int[1] ;
         T000H16_A106RastreadorId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         i151RastreadorGAMGUIDProprietario = "";
         GXt_char1 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.rastreador__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rastreador__default(),
            new Object[][] {
                new Object[] {
               T000H2_A106RastreadorId, T000H2_A107RastreadorDataHoraCriacao, T000H2_A151RastreadorGAMGUIDProprietario, T000H2_A108RastreadorFabricante, T000H2_n108RastreadorFabricante, T000H2_A109RastreadorModelo, T000H2_n109RastreadorModelo, T000H2_A110RastreadorSNumber, T000H2_A111RastreadorDeviceIdFlespi, T000H2_A112RastreadorAtrelado,
               T000H2_A113ChipGSMId
               }
               , new Object[] {
               T000H3_A106RastreadorId, T000H3_A107RastreadorDataHoraCriacao, T000H3_A151RastreadorGAMGUIDProprietario, T000H3_A108RastreadorFabricante, T000H3_n108RastreadorFabricante, T000H3_A109RastreadorModelo, T000H3_n109RastreadorModelo, T000H3_A110RastreadorSNumber, T000H3_A111RastreadorDeviceIdFlespi, T000H3_A112RastreadorAtrelado,
               T000H3_A113ChipGSMId
               }
               , new Object[] {
               T000H4_A115ChipGSMOperadora, T000H4_A116ChipGSMNumero
               }
               , new Object[] {
               T000H5_A106RastreadorId, T000H5_A107RastreadorDataHoraCriacao, T000H5_A151RastreadorGAMGUIDProprietario, T000H5_A108RastreadorFabricante, T000H5_n108RastreadorFabricante, T000H5_A109RastreadorModelo, T000H5_n109RastreadorModelo, T000H5_A110RastreadorSNumber, T000H5_A111RastreadorDeviceIdFlespi, T000H5_A112RastreadorAtrelado,
               T000H5_A115ChipGSMOperadora, T000H5_A116ChipGSMNumero, T000H5_A113ChipGSMId
               }
               , new Object[] {
               T000H6_A115ChipGSMOperadora, T000H6_A116ChipGSMNumero
               }
               , new Object[] {
               T000H7_A106RastreadorId
               }
               , new Object[] {
               T000H8_A106RastreadorId
               }
               , new Object[] {
               T000H9_A106RastreadorId
               }
               , new Object[] {
               T000H10_A106RastreadorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H13_A115ChipGSMOperadora, T000H13_A116ChipGSMNumero
               }
               , new Object[] {
               T000H14_A144ComandoEnviadoId
               }
               , new Object[] {
               T000H15_A98VeiculoId, T000H15_A106RastreadorId
               }
               , new Object[] {
               T000H16_A106RastreadorId
               }
            }
         );
         AV24Pgmname = "Rastreador";
         Z151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         A151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         i151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         Z107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         A107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         i107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
      }

      private short GxWebError ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound18 ;
      private short GX_JID ;
      private short nIsDirty_18 ;
      private short gxajaxcallmode ;
      private int wcpOAV7RastreadorId ;
      private int Z106RastreadorId ;
      private int Z113ChipGSMId ;
      private int O113ChipGSMId ;
      private int N113ChipGSMId ;
      private int A113ChipGSMId ;
      private int AV7RastreadorId ;
      private int trnEnded ;
      private int A106RastreadorId ;
      private int edtRastreadorId_Enabled ;
      private int edtRastreadorDataHoraCriacao_Enabled ;
      private int edtRastreadorGAMGUIDProprietario_Enabled ;
      private int edtRastreadorSNumber_Enabled ;
      private int edtRastreadorDeviceIdFlespi_Enabled ;
      private int edtChipGSMId_Enabled ;
      private int imgprompt_113_Visible ;
      private int edtChipGSMNumero_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV13Insert_ChipGSMId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV25GXV1 ;
      private int idxLst ;
      private long Z110RastreadorSNumber ;
      private long Z111RastreadorDeviceIdFlespi ;
      private long A110RastreadorSNumber ;
      private long A111RastreadorDeviceIdFlespi ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z151RastreadorGAMGUIDProprietario ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbRastreadorFabricante_Internalname ;
      private string cmbRastreadorModelo_Internalname ;
      private string cmbChipGSMOperadora_Internalname ;
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
      private string edtRastreadorId_Internalname ;
      private string edtRastreadorId_Jsonclick ;
      private string edtRastreadorDataHoraCriacao_Internalname ;
      private string edtRastreadorDataHoraCriacao_Jsonclick ;
      private string edtRastreadorGAMGUIDProprietario_Internalname ;
      private string A151RastreadorGAMGUIDProprietario ;
      private string edtRastreadorGAMGUIDProprietario_Jsonclick ;
      private string TempTags ;
      private string cmbRastreadorFabricante_Jsonclick ;
      private string cmbRastreadorModelo_Jsonclick ;
      private string edtRastreadorSNumber_Internalname ;
      private string edtRastreadorSNumber_Jsonclick ;
      private string edtRastreadorDeviceIdFlespi_Internalname ;
      private string edtRastreadorDeviceIdFlespi_Jsonclick ;
      private string chkRastreadorAtrelado_Internalname ;
      private string edtChipGSMId_Internalname ;
      private string edtChipGSMId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_113_Internalname ;
      private string imgprompt_113_Link ;
      private string cmbChipGSMOperadora_Jsonclick ;
      private string edtChipGSMNumero_Internalname ;
      private string edtChipGSMNumero_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV24Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode18 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i151RastreadorGAMGUIDProprietario ;
      private string GXt_char1 ;
      private DateTime Z107RastreadorDataHoraCriacao ;
      private DateTime A107RastreadorDataHoraCriacao ;
      private DateTime i107RastreadorDataHoraCriacao ;
      private bool Z112RastreadorAtrelado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n108RastreadorFabricante ;
      private bool n109RastreadorModelo ;
      private bool A112RastreadorAtrelado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z108RastreadorFabricante ;
      private string Z109RastreadorModelo ;
      private string A108RastreadorFabricante ;
      private string A109RastreadorModelo ;
      private string A115ChipGSMOperadora ;
      private string A116ChipGSMNumero ;
      private string Z115ChipGSMOperadora ;
      private string Z116ChipGSMNumero ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbRastreadorFabricante ;
      private GXCombobox cmbRastreadorModelo ;
      private GXCheckbox chkRastreadorAtrelado ;
      private GXCombobox cmbChipGSMOperadora ;
      private IDataStoreProvider pr_default ;
      private string[] T000H4_A115ChipGSMOperadora ;
      private string[] T000H4_A116ChipGSMNumero ;
      private int[] T000H5_A106RastreadorId ;
      private DateTime[] T000H5_A107RastreadorDataHoraCriacao ;
      private string[] T000H5_A151RastreadorGAMGUIDProprietario ;
      private string[] T000H5_A108RastreadorFabricante ;
      private bool[] T000H5_n108RastreadorFabricante ;
      private string[] T000H5_A109RastreadorModelo ;
      private bool[] T000H5_n109RastreadorModelo ;
      private long[] T000H5_A110RastreadorSNumber ;
      private long[] T000H5_A111RastreadorDeviceIdFlespi ;
      private bool[] T000H5_A112RastreadorAtrelado ;
      private string[] T000H5_A115ChipGSMOperadora ;
      private string[] T000H5_A116ChipGSMNumero ;
      private int[] T000H5_A113ChipGSMId ;
      private string[] T000H6_A115ChipGSMOperadora ;
      private string[] T000H6_A116ChipGSMNumero ;
      private int[] T000H7_A106RastreadorId ;
      private int[] T000H3_A106RastreadorId ;
      private DateTime[] T000H3_A107RastreadorDataHoraCriacao ;
      private string[] T000H3_A151RastreadorGAMGUIDProprietario ;
      private string[] T000H3_A108RastreadorFabricante ;
      private bool[] T000H3_n108RastreadorFabricante ;
      private string[] T000H3_A109RastreadorModelo ;
      private bool[] T000H3_n109RastreadorModelo ;
      private long[] T000H3_A110RastreadorSNumber ;
      private long[] T000H3_A111RastreadorDeviceIdFlespi ;
      private bool[] T000H3_A112RastreadorAtrelado ;
      private int[] T000H3_A113ChipGSMId ;
      private int[] T000H8_A106RastreadorId ;
      private int[] T000H9_A106RastreadorId ;
      private int[] T000H2_A106RastreadorId ;
      private DateTime[] T000H2_A107RastreadorDataHoraCriacao ;
      private string[] T000H2_A151RastreadorGAMGUIDProprietario ;
      private string[] T000H2_A108RastreadorFabricante ;
      private bool[] T000H2_n108RastreadorFabricante ;
      private string[] T000H2_A109RastreadorModelo ;
      private bool[] T000H2_n109RastreadorModelo ;
      private long[] T000H2_A110RastreadorSNumber ;
      private long[] T000H2_A111RastreadorDeviceIdFlespi ;
      private bool[] T000H2_A112RastreadorAtrelado ;
      private int[] T000H2_A113ChipGSMId ;
      private int[] T000H10_A106RastreadorId ;
      private string[] T000H13_A115ChipGSMOperadora ;
      private string[] T000H13_A116ChipGSMNumero ;
      private int[] T000H14_A144ComandoEnviadoId ;
      private int[] T000H15_A98VeiculoId ;
      private int[] T000H15_A106RastreadorId ;
      private int[] T000H16_A106RastreadorId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class rastreador__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class rastreador__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000H5;
        prmT000H5 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H4;
        prmT000H4 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H6;
        prmT000H6 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H7;
        prmT000H7 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H3;
        prmT000H3 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H8;
        prmT000H8 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H9;
        prmT000H9 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H2;
        prmT000H2 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H10;
        prmT000H10 = new Object[] {
        new Object[] {"@RastreadorDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@RastreadorGAMGUIDProprietario",SqlDbType.NChar,40,0} ,
        new Object[] {"@RastreadorFabricante",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorModelo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorSNumber",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorDeviceIdFlespi",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H11;
        prmT000H11 = new Object[] {
        new Object[] {"@RastreadorDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@RastreadorGAMGUIDProprietario",SqlDbType.NChar,40,0} ,
        new Object[] {"@RastreadorFabricante",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorModelo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorSNumber",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorDeviceIdFlespi",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H12;
        prmT000H12 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H14;
        prmT000H14 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H15;
        prmT000H15 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmT000H16;
        prmT000H16 = new Object[] {
        };
        Object[] prmT000H13;
        prmT000H13 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000H2", "SELECT [RastreadorId], [RastreadorDataHoraCriacao], [RastreadorGAMGUIDProprietario], [RastreadorFabricante], [RastreadorModelo], [RastreadorSNumber], [RastreadorDeviceIdFlespi], [RastreadorAtrelado], [ChipGSMId] FROM [Rastreador] WITH (UPDLOCK) WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H3", "SELECT [RastreadorId], [RastreadorDataHoraCriacao], [RastreadorGAMGUIDProprietario], [RastreadorFabricante], [RastreadorModelo], [RastreadorSNumber], [RastreadorDeviceIdFlespi], [RastreadorAtrelado], [ChipGSMId] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H4", "SELECT [ChipGSMOperadora], [ChipGSMNumero] FROM [ChipGSM] WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H5", "SELECT TM1.[RastreadorId], TM1.[RastreadorDataHoraCriacao], TM1.[RastreadorGAMGUIDProprietario], TM1.[RastreadorFabricante], TM1.[RastreadorModelo], TM1.[RastreadorSNumber], TM1.[RastreadorDeviceIdFlespi], TM1.[RastreadorAtrelado], T2.[ChipGSMOperadora], T2.[ChipGSMNumero], TM1.[ChipGSMId] FROM ([Rastreador] TM1 INNER JOIN [ChipGSM] T2 ON T2.[ChipGSMId] = TM1.[ChipGSMId]) WHERE TM1.[RastreadorId] = @RastreadorId ORDER BY TM1.[RastreadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H6", "SELECT [ChipGSMOperadora], [ChipGSMNumero] FROM [ChipGSM] WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H7", "SELECT [RastreadorId] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H8", "SELECT TOP 1 [RastreadorId] FROM [Rastreador] WHERE ( [RastreadorId] > @RastreadorId) ORDER BY [RastreadorId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H9", "SELECT TOP 1 [RastreadorId] FROM [Rastreador] WHERE ( [RastreadorId] < @RastreadorId) ORDER BY [RastreadorId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H10", "INSERT INTO [Rastreador]([RastreadorDataHoraCriacao], [RastreadorGAMGUIDProprietario], [RastreadorFabricante], [RastreadorModelo], [RastreadorSNumber], [RastreadorDeviceIdFlespi], [RastreadorAtrelado], [ChipGSMId]) VALUES(@RastreadorDataHoraCriacao, @RastreadorGAMGUIDProprietario, @RastreadorFabricante, @RastreadorModelo, @RastreadorSNumber, @RastreadorDeviceIdFlespi, @RastreadorAtrelado, @ChipGSMId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000H10)
           ,new CursorDef("T000H11", "UPDATE [Rastreador] SET [RastreadorDataHoraCriacao]=@RastreadorDataHoraCriacao, [RastreadorGAMGUIDProprietario]=@RastreadorGAMGUIDProprietario, [RastreadorFabricante]=@RastreadorFabricante, [RastreadorModelo]=@RastreadorModelo, [RastreadorSNumber]=@RastreadorSNumber, [RastreadorDeviceIdFlespi]=@RastreadorDeviceIdFlespi, [RastreadorAtrelado]=@RastreadorAtrelado, [ChipGSMId]=@ChipGSMId  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK,prmT000H11)
           ,new CursorDef("T000H12", "DELETE FROM [Rastreador]  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK,prmT000H12)
           ,new CursorDef("T000H13", "SELECT [ChipGSMOperadora], [ChipGSMNumero] FROM [ChipGSM] WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H14", "SELECT TOP 1 [ComandoEnviadoId] FROM [ComandoEnviado] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H15", "SELECT TOP 1 [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H16", "SELECT [RastreadorId] FROM [Rastreador] ORDER BY [RastreadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H16,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              table[8][0] = rslt.getLong(7);
              table[9][0] = rslt.getBool(8);
              table[10][0] = rslt.getInt(9);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              table[8][0] = rslt.getLong(7);
              table[9][0] = rslt.getBool(8);
              table[10][0] = rslt.getInt(9);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              table[8][0] = rslt.getLong(7);
              table[9][0] = rslt.getBool(8);
              table[10][0] = rslt.getVarchar(9);
              table[11][0] = rslt.getVarchar(10);
              table[12][0] = rslt.getInt(11);
              return;
           case 4 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              return;
           case 6 :
              table[0][0] = rslt.getInt(1);
              return;
           case 7 :
              table[0][0] = rslt.getInt(1);
              return;
           case 8 :
              table[0][0] = rslt.getInt(1);
              return;
           case 11 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 12 :
              table[0][0] = rslt.getInt(1);
              return;
           case 13 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 14 :
              table[0][0] = rslt.getInt(1);
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
              return;
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
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
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 4 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(4, (string)parms[5]);
              }
              stmt.SetParameter(5, (long)parms[6]);
              stmt.SetParameter(6, (long)parms[7]);
              stmt.SetParameter(7, (bool)parms[8]);
              stmt.SetParameter(8, (int)parms[9]);
              return;
           case 9 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 4 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(4, (string)parms[5]);
              }
              stmt.SetParameter(5, (long)parms[6]);
              stmt.SetParameter(6, (long)parms[7]);
              stmt.SetParameter(7, (bool)parms[8]);
              stmt.SetParameter(8, (int)parms[9]);
              stmt.SetParameter(9, (int)parms[10]);
              return;
           case 10 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 13 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
