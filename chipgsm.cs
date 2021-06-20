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
   public class chipgsm : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"CHIPGSMGAMGUIDPROPRIETARIO") == 0 )
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
            GX8ASACHIPGSMGAMGUIDPROPRIETARIO0I19( Gx_BScreen, Gx_mode) ;
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
               AV7ChipGSMId = (int)(NumberUtil.Val( GetPar( "ChipGSMId"), "."));
               AssignAttri("", false, "AV7ChipGSMId", StringUtil.LTrimStr( (decimal)(AV7ChipGSMId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCHIPGSMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ChipGSMId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Chip GSM", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbChipGSMOperadora_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public chipgsm( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public chipgsm( IGxContext context )
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
                           int aP1_ChipGSMId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ChipGSMId = aP1_ChipGSMId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbChipGSMOperadora = new GXCombobox();
         chkChipGSMAtrelado = new GXCheckbox();
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
            return "chipgsm_Execute" ;
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
         A117ChipGSMAtrelado = StringUtil.StrToBool( StringUtil.BoolToStr( A117ChipGSMAtrelado));
         AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChipGSMId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChipGSMId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtChipGSMId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A113ChipGSMId), 8, 0, ",", "")), ((edtChipGSMId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A113ChipGSMId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A113ChipGSMId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChipGSMId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChipGSMId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ChipGSM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChipGSMDataHoraCadastro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChipGSMDataHoraCadastro_Internalname, "Data/Hora da Criação", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtChipGSMDataHoraCadastro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtChipGSMDataHoraCadastro_Internalname, context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A114ChipGSMDataHoraCadastro, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChipGSMDataHoraCadastro_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtChipGSMDataHoraCadastro_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ChipGSM.htm");
         GxWebStd.gx_bitmap( context, edtChipGSMDataHoraCadastro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtChipGSMDataHoraCadastro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ChipGSM.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChipGSMGAMGUIDProprietario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChipGSMGAMGUIDProprietario_Internalname, "GAMGUID do Proprietário", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtChipGSMGAMGUIDProprietario_Internalname, StringUtil.RTrim( A152ChipGSMGAMGUIDProprietario), StringUtil.RTrim( context.localUtil.Format( A152ChipGSMGAMGUIDProprietario, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChipGSMGAMGUIDProprietario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChipGSMGAMGUIDProprietario_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_ChipGSM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbChipGSMOperadora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbChipGSMOperadora_Internalname, "Operadora", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbChipGSMOperadora, cmbChipGSMOperadora_Internalname, StringUtil.RTrim( A115ChipGSMOperadora), 1, cmbChipGSMOperadora_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbChipGSMOperadora.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, "HLP_ChipGSM.htm");
         cmbChipGSMOperadora.CurrentValue = StringUtil.RTrim( A115ChipGSMOperadora);
         AssignProp("", false, cmbChipGSMOperadora_Internalname, "Values", (string)(cmbChipGSMOperadora.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtChipGSMNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtChipGSMNumero_Internalname, "Número", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChipGSMNumero_Internalname, A116ChipGSMNumero, StringUtil.RTrim( context.localUtil.Format( A116ChipGSMNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChipGSMNumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChipGSMNumero_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ChipGSM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkChipGSMAtrelado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkChipGSMAtrelado_Internalname, "Chip GSM no Rastreador?", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkChipGSMAtrelado_Internalname, StringUtil.BoolToStr( A117ChipGSMAtrelado), "", "Chip GSM no Rastreador?", 1, chkChipGSMAtrelado.Enabled, "true", "", StyleString, ClassString, "", "", "");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChipGSM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChipGSM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ChipGSM.htm");
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
         E110I2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z113ChipGSMId = (int)(context.localUtil.CToN( cgiGet( "Z113ChipGSMId"), ",", "."));
               Z114ChipGSMDataHoraCadastro = context.localUtil.CToT( cgiGet( "Z114ChipGSMDataHoraCadastro"), 0);
               Z152ChipGSMGAMGUIDProprietario = cgiGet( "Z152ChipGSMGAMGUIDProprietario");
               Z115ChipGSMOperadora = cgiGet( "Z115ChipGSMOperadora");
               Z116ChipGSMNumero = cgiGet( "Z116ChipGSMNumero");
               Z117ChipGSMAtrelado = StringUtil.StrToBool( cgiGet( "Z117ChipGSMAtrelado"));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7ChipGSMId = (int)(context.localUtil.CToN( cgiGet( "vCHIPGSMID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
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
               A113ChipGSMId = (int)(context.localUtil.CToN( cgiGet( edtChipGSMId_Internalname), ",", "."));
               AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
               A114ChipGSMDataHoraCadastro = context.localUtil.CToT( cgiGet( edtChipGSMDataHoraCadastro_Internalname));
               AssignAttri("", false, "A114ChipGSMDataHoraCadastro", context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
               A152ChipGSMGAMGUIDProprietario = cgiGet( edtChipGSMGAMGUIDProprietario_Internalname);
               AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
               cmbChipGSMOperadora.CurrentValue = cgiGet( cmbChipGSMOperadora_Internalname);
               A115ChipGSMOperadora = cgiGet( cmbChipGSMOperadora_Internalname);
               AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
               A116ChipGSMNumero = cgiGet( edtChipGSMNumero_Internalname);
               AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
               A117ChipGSMAtrelado = StringUtil.StrToBool( cgiGet( chkChipGSMAtrelado_Internalname));
               AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ChipGSM");
               A113ChipGSMId = (int)(context.localUtil.CToN( cgiGet( edtChipGSMId_Internalname), ",", "."));
               AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
               forbiddenHiddens.Add("ChipGSMId", context.localUtil.Format( (decimal)(A113ChipGSMId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A114ChipGSMDataHoraCadastro = context.localUtil.CToT( cgiGet( edtChipGSMDataHoraCadastro_Internalname));
               AssignAttri("", false, "A114ChipGSMDataHoraCadastro", context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
               forbiddenHiddens.Add("ChipGSMDataHoraCadastro", context.localUtil.Format( A114ChipGSMDataHoraCadastro, "99/99/99 99:99"));
               A152ChipGSMGAMGUIDProprietario = cgiGet( edtChipGSMGAMGUIDProprietario_Internalname);
               AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
               forbiddenHiddens.Add("ChipGSMGAMGUIDProprietario", StringUtil.RTrim( context.localUtil.Format( A152ChipGSMGAMGUIDProprietario, "")));
               A117ChipGSMAtrelado = StringUtil.StrToBool( cgiGet( chkChipGSMAtrelado_Internalname));
               AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
               forbiddenHiddens.Add("ChipGSMAtrelado", StringUtil.BoolToStr( A117ChipGSMAtrelado));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A113ChipGSMId != Z113ChipGSMId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("chipgsm:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A113ChipGSMId = (int)(NumberUtil.Val( GetPar( "ChipGSMId"), "."));
                  AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
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
                     sMode19 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode19;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound19 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CHIPGSMID");
                        AnyError = 1;
                        GX_FocusControl = edtChipGSMId_Internalname;
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
                           E110I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120I2 ();
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
            E120I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0I19( ) ;
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
            DisableAttributes0I19( ) ;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I19( ) ;
            }
            else
            {
               CheckExtendedTable0I19( ) ;
               CloseExtendedTableCursors0I19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0I0( )
      {
      }

      protected void E110I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E120I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("chipgsmww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0I19( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z114ChipGSMDataHoraCadastro = T000I3_A114ChipGSMDataHoraCadastro[0];
               Z152ChipGSMGAMGUIDProprietario = T000I3_A152ChipGSMGAMGUIDProprietario[0];
               Z115ChipGSMOperadora = T000I3_A115ChipGSMOperadora[0];
               Z116ChipGSMNumero = T000I3_A116ChipGSMNumero[0];
               Z117ChipGSMAtrelado = T000I3_A117ChipGSMAtrelado[0];
            }
            else
            {
               Z114ChipGSMDataHoraCadastro = A114ChipGSMDataHoraCadastro;
               Z152ChipGSMGAMGUIDProprietario = A152ChipGSMGAMGUIDProprietario;
               Z115ChipGSMOperadora = A115ChipGSMOperadora;
               Z116ChipGSMNumero = A116ChipGSMNumero;
               Z117ChipGSMAtrelado = A117ChipGSMAtrelado;
            }
         }
         if ( GX_JID == -12 )
         {
            Z113ChipGSMId = A113ChipGSMId;
            Z114ChipGSMDataHoraCadastro = A114ChipGSMDataHoraCadastro;
            Z152ChipGSMGAMGUIDProprietario = A152ChipGSMGAMGUIDProprietario;
            Z115ChipGSMOperadora = A115ChipGSMOperadora;
            Z116ChipGSMNumero = A116ChipGSMNumero;
            Z117ChipGSMAtrelado = A117ChipGSMAtrelado;
         }
      }

      protected void standaloneNotModal( )
      {
         edtChipGSMId_Enabled = 0;
         AssignProp("", false, edtChipGSMId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMId_Enabled), 5, 0), true);
         edtChipGSMDataHoraCadastro_Enabled = 0;
         AssignProp("", false, edtChipGSMDataHoraCadastro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMDataHoraCadastro_Enabled), 5, 0), true);
         edtChipGSMGAMGUIDProprietario_Enabled = 0;
         AssignProp("", false, edtChipGSMGAMGUIDProprietario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMGAMGUIDProprietario_Enabled), 5, 0), true);
         chkChipGSMAtrelado.Enabled = 0;
         AssignProp("", false, chkChipGSMAtrelado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkChipGSMAtrelado.Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtChipGSMId_Enabled = 0;
         AssignProp("", false, edtChipGSMId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMId_Enabled), 5, 0), true);
         edtChipGSMDataHoraCadastro_Enabled = 0;
         AssignProp("", false, edtChipGSMDataHoraCadastro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMDataHoraCadastro_Enabled), 5, 0), true);
         edtChipGSMGAMGUIDProprietario_Enabled = 0;
         AssignProp("", false, edtChipGSMGAMGUIDProprietario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMGAMGUIDProprietario_Enabled), 5, 0), true);
         chkChipGSMAtrelado.Enabled = 0;
         AssignProp("", false, chkChipGSMAtrelado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkChipGSMAtrelado.Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ChipGSMId) )
         {
            A113ChipGSMId = AV7ChipGSMId;
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
         }
      }

      protected void standaloneModal( )
      {
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
         if ( IsIns( )  && (DateTime.MinValue==A114ChipGSMDataHoraCadastro) && ( Gx_BScreen == 0 ) )
         {
            A114ChipGSMDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A114ChipGSMDataHoraCadastro", context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A152ChipGSMGAMGUIDProprietario)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A152ChipGSMGAMGUIDProprietario;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A152ChipGSMGAMGUIDProprietario = GXt_char1;
            AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
         }
      }

      protected void Load0I19( )
      {
         /* Using cursor T000I4 */
         pr_default.execute(2, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A114ChipGSMDataHoraCadastro = T000I4_A114ChipGSMDataHoraCadastro[0];
            AssignAttri("", false, "A114ChipGSMDataHoraCadastro", context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
            A152ChipGSMGAMGUIDProprietario = T000I4_A152ChipGSMGAMGUIDProprietario[0];
            AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
            A115ChipGSMOperadora = T000I4_A115ChipGSMOperadora[0];
            AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
            A116ChipGSMNumero = T000I4_A116ChipGSMNumero[0];
            AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
            A117ChipGSMAtrelado = T000I4_A117ChipGSMAtrelado[0];
            AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
            ZM0I19( -12) ;
         }
         pr_default.close(2);
         OnLoadActions0I19( ) ;
      }

      protected void OnLoadActions0I19( )
      {
      }

      protected void CheckExtendedTable0I19( )
      {
         nIsDirty_19 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000I5 */
         pr_default.execute(3, new Object[] {A116ChipGSMNumero, A113ChipGSMId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Número"}), 1, "CHIPGSMNUMERO");
            AnyError = 1;
            GX_FocusControl = edtChipGSMNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A115ChipGSMOperadora, "Claro") == 0 ) || ( StringUtil.StrCmp(A115ChipGSMOperadora, "Vivo") == 0 ) || ( StringUtil.StrCmp(A115ChipGSMOperadora, "Oi") == 0 ) || ( StringUtil.StrCmp(A115ChipGSMOperadora, "TIM") == 0 ) || ( StringUtil.StrCmp(A115ChipGSMOperadora, "Vodafone") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Operadora fora do intervalo", "OutOfRange", 1, "CHIPGSMOPERADORA");
            AnyError = 1;
            GX_FocusControl = cmbChipGSMOperadora_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A115ChipGSMOperadora)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Operadora", "", "", "", "", "", "", "", ""), 1, "CHIPGSMOPERADORA");
            AnyError = 1;
            GX_FocusControl = cmbChipGSMOperadora_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A116ChipGSMNumero)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""), 1, "CHIPGSMNUMERO");
            AnyError = 1;
            GX_FocusControl = edtChipGSMNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( StringUtil.Len( A116ChipGSMNumero) != 11 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( A116ChipGSMNumero)) ) )
         {
            GX_msglist.addItem("Número inválido", 1, "CHIPGSMNUMERO");
            AnyError = 1;
            GX_FocusControl = edtChipGSMNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0I19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I19( )
      {
         /* Using cursor T000I6 */
         pr_default.execute(4, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_default.execute(1, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I19( 12) ;
            RcdFound19 = 1;
            A113ChipGSMId = T000I3_A113ChipGSMId[0];
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            A114ChipGSMDataHoraCadastro = T000I3_A114ChipGSMDataHoraCadastro[0];
            AssignAttri("", false, "A114ChipGSMDataHoraCadastro", context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
            A152ChipGSMGAMGUIDProprietario = T000I3_A152ChipGSMGAMGUIDProprietario[0];
            AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
            A115ChipGSMOperadora = T000I3_A115ChipGSMOperadora[0];
            AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
            A116ChipGSMNumero = T000I3_A116ChipGSMNumero[0];
            AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
            A117ChipGSMAtrelado = T000I3_A117ChipGSMAtrelado[0];
            AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
            Z113ChipGSMId = A113ChipGSMId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0I19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0I19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0I19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I19( ) ;
         if ( RcdFound19 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound19 = 0;
         /* Using cursor T000I7 */
         pr_default.execute(5, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000I7_A113ChipGSMId[0] < A113ChipGSMId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000I7_A113ChipGSMId[0] > A113ChipGSMId ) ) )
            {
               A113ChipGSMId = T000I7_A113ChipGSMId[0];
               AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000I8 */
         pr_default.execute(6, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000I8_A113ChipGSMId[0] > A113ChipGSMId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000I8_A113ChipGSMId[0] < A113ChipGSMId ) ) )
            {
               A113ChipGSMId = T000I8_A113ChipGSMId[0];
               AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbChipGSMOperadora_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0I19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A113ChipGSMId != Z113ChipGSMId )
               {
                  A113ChipGSMId = Z113ChipGSMId;
                  AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CHIPGSMID");
                  AnyError = 1;
                  GX_FocusControl = edtChipGSMId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbChipGSMOperadora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0I19( ) ;
                  GX_FocusControl = cmbChipGSMOperadora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A113ChipGSMId != Z113ChipGSMId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbChipGSMOperadora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0I19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CHIPGSMID");
                     AnyError = 1;
                     GX_FocusControl = edtChipGSMId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbChipGSMOperadora_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0I19( ) ;
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
         if ( A113ChipGSMId != Z113ChipGSMId )
         {
            A113ChipGSMId = Z113ChipGSMId;
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CHIPGSMID");
            AnyError = 1;
            GX_FocusControl = edtChipGSMId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbChipGSMOperadora_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0I19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_default.execute(0, new Object[] {A113ChipGSMId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ChipGSM"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z114ChipGSMDataHoraCadastro != T000I2_A114ChipGSMDataHoraCadastro[0] ) || ( StringUtil.StrCmp(Z152ChipGSMGAMGUIDProprietario, T000I2_A152ChipGSMGAMGUIDProprietario[0]) != 0 ) || ( StringUtil.StrCmp(Z115ChipGSMOperadora, T000I2_A115ChipGSMOperadora[0]) != 0 ) || ( StringUtil.StrCmp(Z116ChipGSMNumero, T000I2_A116ChipGSMNumero[0]) != 0 ) || ( Z117ChipGSMAtrelado != T000I2_A117ChipGSMAtrelado[0] ) )
            {
               if ( Z114ChipGSMDataHoraCadastro != T000I2_A114ChipGSMDataHoraCadastro[0] )
               {
                  GXUtil.WriteLog("chipgsm:[seudo value changed for attri]"+"ChipGSMDataHoraCadastro");
                  GXUtil.WriteLogRaw("Old: ",Z114ChipGSMDataHoraCadastro);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A114ChipGSMDataHoraCadastro[0]);
               }
               if ( StringUtil.StrCmp(Z152ChipGSMGAMGUIDProprietario, T000I2_A152ChipGSMGAMGUIDProprietario[0]) != 0 )
               {
                  GXUtil.WriteLog("chipgsm:[seudo value changed for attri]"+"ChipGSMGAMGUIDProprietario");
                  GXUtil.WriteLogRaw("Old: ",Z152ChipGSMGAMGUIDProprietario);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A152ChipGSMGAMGUIDProprietario[0]);
               }
               if ( StringUtil.StrCmp(Z115ChipGSMOperadora, T000I2_A115ChipGSMOperadora[0]) != 0 )
               {
                  GXUtil.WriteLog("chipgsm:[seudo value changed for attri]"+"ChipGSMOperadora");
                  GXUtil.WriteLogRaw("Old: ",Z115ChipGSMOperadora);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A115ChipGSMOperadora[0]);
               }
               if ( StringUtil.StrCmp(Z116ChipGSMNumero, T000I2_A116ChipGSMNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("chipgsm:[seudo value changed for attri]"+"ChipGSMNumero");
                  GXUtil.WriteLogRaw("Old: ",Z116ChipGSMNumero);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A116ChipGSMNumero[0]);
               }
               if ( Z117ChipGSMAtrelado != T000I2_A117ChipGSMAtrelado[0] )
               {
                  GXUtil.WriteLog("chipgsm:[seudo value changed for attri]"+"ChipGSMAtrelado");
                  GXUtil.WriteLogRaw("Old: ",Z117ChipGSMAtrelado);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A117ChipGSMAtrelado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ChipGSM"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I19( )
      {
         if ( ! IsAuthorized("chipgsm_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I19( 0) ;
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I9 */
                     pr_default.execute(7, new Object[] {A114ChipGSMDataHoraCadastro, A152ChipGSMGAMGUIDProprietario, A115ChipGSMOperadora, A116ChipGSMNumero, A117ChipGSMAtrelado});
                     A113ChipGSMId = T000I9_A113ChipGSMId[0];
                     AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("ChipGSM");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0I0( ) ;
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
               Load0I19( ) ;
            }
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void Update0I19( )
      {
         if ( ! IsAuthorized("chipgsm_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I10 */
                     pr_default.execute(8, new Object[] {A114ChipGSMDataHoraCadastro, A152ChipGSMGAMGUIDProprietario, A115ChipGSMOperadora, A116ChipGSMNumero, A117ChipGSMAtrelado, A113ChipGSMId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ChipGSM");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ChipGSM"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
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
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void DeferredUpdate0I19( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("chipgsm_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I19( ) ;
            AfterConfirm0I19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I11 */
                  pr_default.execute(9, new Object[] {A113ChipGSMId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("ChipGSM");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0I19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000I12 */
            pr_default.execute(10, new Object[] {A113ChipGSMId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Rastreador"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0I19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("chipgsm",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("chipgsm",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I19( )
      {
         /* Scan By routine */
         /* Using cursor T000I13 */
         pr_default.execute(11);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound19 = 1;
            A113ChipGSMId = T000I13_A113ChipGSMId[0];
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I19( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound19 = 1;
            A113ChipGSMId = T000I13_A113ChipGSMId[0];
            AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
         }
      }

      protected void ScanEnd0I19( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0I19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I19( )
      {
         edtChipGSMId_Enabled = 0;
         AssignProp("", false, edtChipGSMId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMId_Enabled), 5, 0), true);
         edtChipGSMDataHoraCadastro_Enabled = 0;
         AssignProp("", false, edtChipGSMDataHoraCadastro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMDataHoraCadastro_Enabled), 5, 0), true);
         edtChipGSMGAMGUIDProprietario_Enabled = 0;
         AssignProp("", false, edtChipGSMGAMGUIDProprietario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMGAMGUIDProprietario_Enabled), 5, 0), true);
         cmbChipGSMOperadora.Enabled = 0;
         AssignProp("", false, cmbChipGSMOperadora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChipGSMOperadora.Enabled), 5, 0), true);
         edtChipGSMNumero_Enabled = 0;
         AssignProp("", false, edtChipGSMNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChipGSMNumero_Enabled), 5, 0), true);
         chkChipGSMAtrelado.Enabled = 0;
         AssignProp("", false, chkChipGSMAtrelado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkChipGSMAtrelado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142918275266", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("chipgsm.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ChipGSMId,8,0))}, new string[] {"Gx_mode","ChipGSMId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ChipGSM");
         forbiddenHiddens.Add("ChipGSMId", context.localUtil.Format( (decimal)(A113ChipGSMId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ChipGSMDataHoraCadastro", context.localUtil.Format( A114ChipGSMDataHoraCadastro, "99/99/99 99:99"));
         forbiddenHiddens.Add("ChipGSMGAMGUIDProprietario", StringUtil.RTrim( context.localUtil.Format( A152ChipGSMGAMGUIDProprietario, "")));
         A117ChipGSMAtrelado = StringUtil.StrToBool( StringUtil.BoolToStr( A117ChipGSMAtrelado));
         AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
         forbiddenHiddens.Add("ChipGSMAtrelado", StringUtil.BoolToStr( A117ChipGSMAtrelado));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("chipgsm:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z113ChipGSMId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z113ChipGSMId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z114ChipGSMDataHoraCadastro", context.localUtil.TToC( Z114ChipGSMDataHoraCadastro, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z152ChipGSMGAMGUIDProprietario", StringUtil.RTrim( Z152ChipGSMGAMGUIDProprietario));
         GxWebStd.gx_hidden_field( context, "Z115ChipGSMOperadora", Z115ChipGSMOperadora);
         GxWebStd.gx_hidden_field( context, "Z116ChipGSMNumero", Z116ChipGSMNumero);
         GxWebStd.gx_boolean_hidden_field( context, "Z117ChipGSMAtrelado", Z117ChipGSMAtrelado);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vCHIPGSMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ChipGSMId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCHIPGSMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ChipGSMId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         return formatLink("chipgsm.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ChipGSMId,8,0))}, new string[] {"Gx_mode","ChipGSMId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ChipGSM" ;
      }

      public override string GetPgmdesc( )
      {
         return "Chip GSM" ;
      }

      protected void InitializeNonKey0I19( )
      {
         A115ChipGSMOperadora = "";
         AssignAttri("", false, "A115ChipGSMOperadora", A115ChipGSMOperadora);
         A116ChipGSMNumero = "";
         AssignAttri("", false, "A116ChipGSMNumero", A116ChipGSMNumero);
         A117ChipGSMAtrelado = false;
         AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
         A114ChipGSMDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "A114ChipGSMDataHoraCadastro", context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
         A152ChipGSMGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
         Z114ChipGSMDataHoraCadastro = (DateTime)(DateTime.MinValue);
         Z152ChipGSMGAMGUIDProprietario = "";
         Z115ChipGSMOperadora = "";
         Z116ChipGSMNumero = "";
         Z117ChipGSMAtrelado = false;
      }

      protected void InitAll0I19( )
      {
         A113ChipGSMId = 0;
         AssignAttri("", false, "A113ChipGSMId", StringUtil.LTrimStr( (decimal)(A113ChipGSMId), 8, 0));
         InitializeNonKey0I19( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A114ChipGSMDataHoraCadastro = i114ChipGSMDataHoraCadastro;
         AssignAttri("", false, "A114ChipGSMDataHoraCadastro", context.localUtil.TToC( A114ChipGSMDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
         A152ChipGSMGAMGUIDProprietario = i152ChipGSMGAMGUIDProprietario;
         AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918275276", true, true);
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
         context.AddJavascriptSource("chipgsm.js", "?202142918275276", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtChipGSMId_Internalname = "CHIPGSMID";
         edtChipGSMDataHoraCadastro_Internalname = "CHIPGSMDATAHORACADASTRO";
         edtChipGSMGAMGUIDProprietario_Internalname = "CHIPGSMGAMGUIDPROPRIETARIO";
         cmbChipGSMOperadora_Internalname = "CHIPGSMOPERADORA";
         edtChipGSMNumero_Internalname = "CHIPGSMNUMERO";
         chkChipGSMAtrelado_Internalname = "CHIPGSMATRELADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Chip GSM";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkChipGSMAtrelado.Enabled = 0;
         edtChipGSMNumero_Jsonclick = "";
         edtChipGSMNumero_Enabled = 1;
         cmbChipGSMOperadora_Jsonclick = "";
         cmbChipGSMOperadora.Enabled = 1;
         edtChipGSMGAMGUIDProprietario_Jsonclick = "";
         edtChipGSMGAMGUIDProprietario_Enabled = 0;
         edtChipGSMDataHoraCadastro_Jsonclick = "";
         edtChipGSMDataHoraCadastro_Enabled = 0;
         edtChipGSMId_Jsonclick = "";
         edtChipGSMId_Enabled = 0;
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

      protected void GX8ASACHIPGSMGAMGUIDPROPRIETARIO0I19( short Gx_BScreen ,
                                                           string Gx_mode )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A152ChipGSMGAMGUIDProprietario)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A152ChipGSMGAMGUIDProprietario;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A152ChipGSMGAMGUIDProprietario = GXt_char1;
            AssignAttri("", false, "A152ChipGSMGAMGUIDProprietario", A152ChipGSMGAMGUIDProprietario);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A152ChipGSMGAMGUIDProprietario))+"\"") ;
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
         chkChipGSMAtrelado.Name = "CHIPGSMATRELADO";
         chkChipGSMAtrelado.WebTags = "";
         chkChipGSMAtrelado.Caption = "";
         AssignProp("", false, chkChipGSMAtrelado_Internalname, "TitleCaption", chkChipGSMAtrelado.Caption, true);
         chkChipGSMAtrelado.CheckedValue = "false";
         A117ChipGSMAtrelado = StringUtil.StrToBool( StringUtil.BoolToStr( A117ChipGSMAtrelado));
         AssignAttri("", false, "A117ChipGSMAtrelado", A117ChipGSMAtrelado);
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

      public void Valid_Chipgsmnumero( )
      {
         /* Using cursor T000I14 */
         pr_default.execute(12, new Object[] {A116ChipGSMNumero, A113ChipGSMId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Número"}), 1, "CHIPGSMNUMERO");
            AnyError = 1;
            GX_FocusControl = edtChipGSMNumero_Internalname;
         }
         pr_default.close(12);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A116ChipGSMNumero)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""), 1, "CHIPGSMNUMERO");
            AnyError = 1;
            GX_FocusControl = edtChipGSMNumero_Internalname;
         }
         if ( ( StringUtil.Len( A116ChipGSMNumero) != 11 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( A116ChipGSMNumero)) ) )
         {
            GX_msglist.addItem("Número inválido", 1, "CHIPGSMNUMERO");
            AnyError = 1;
            GX_FocusControl = edtChipGSMNumero_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ChipGSMId',fld:'vCHIPGSMID',pic:'ZZZZZZZ9',hsh:true},{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ChipGSMId',fld:'vCHIPGSMID',pic:'ZZZZZZZ9',hsh:true},{av:'A113ChipGSMId',fld:'CHIPGSMID',pic:'ZZZZZZZ9'},{av:'A114ChipGSMDataHoraCadastro',fld:'CHIPGSMDATAHORACADASTRO',pic:'99/99/99 99:99'},{av:'A152ChipGSMGAMGUIDProprietario',fld:'CHIPGSMGAMGUIDPROPRIETARIO',pic:''},{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120I2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]}");
         setEventMetadata("VALID_CHIPGSMID","{handler:'Valid_Chipgsmid',iparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]");
         setEventMetadata("VALID_CHIPGSMID",",oparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]}");
         setEventMetadata("VALID_CHIPGSMOPERADORA","{handler:'Valid_Chipgsmoperadora',iparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]");
         setEventMetadata("VALID_CHIPGSMOPERADORA",",oparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]}");
         setEventMetadata("VALID_CHIPGSMNUMERO","{handler:'Valid_Chipgsmnumero',iparms:[{av:'A116ChipGSMNumero',fld:'CHIPGSMNUMERO',pic:''},{av:'A113ChipGSMId',fld:'CHIPGSMID',pic:'ZZZZZZZ9'},{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]");
         setEventMetadata("VALID_CHIPGSMNUMERO",",oparms:[{av:'A117ChipGSMAtrelado',fld:'CHIPGSMATRELADO',pic:''}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z114ChipGSMDataHoraCadastro = (DateTime)(DateTime.MinValue);
         Z152ChipGSMGAMGUIDProprietario = "";
         Z115ChipGSMOperadora = "";
         Z116ChipGSMNumero = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A115ChipGSMOperadora = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A114ChipGSMDataHoraCadastro = (DateTime)(DateTime.MinValue);
         A152ChipGSMGAMGUIDProprietario = "";
         TempTags = "";
         A116ChipGSMNumero = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode19 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000I4_A113ChipGSMId = new int[1] ;
         T000I4_A114ChipGSMDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         T000I4_A152ChipGSMGAMGUIDProprietario = new string[] {""} ;
         T000I4_A115ChipGSMOperadora = new string[] {""} ;
         T000I4_A116ChipGSMNumero = new string[] {""} ;
         T000I4_A117ChipGSMAtrelado = new bool[] {false} ;
         T000I5_A116ChipGSMNumero = new string[] {""} ;
         T000I6_A113ChipGSMId = new int[1] ;
         T000I3_A113ChipGSMId = new int[1] ;
         T000I3_A114ChipGSMDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         T000I3_A152ChipGSMGAMGUIDProprietario = new string[] {""} ;
         T000I3_A115ChipGSMOperadora = new string[] {""} ;
         T000I3_A116ChipGSMNumero = new string[] {""} ;
         T000I3_A117ChipGSMAtrelado = new bool[] {false} ;
         T000I7_A113ChipGSMId = new int[1] ;
         T000I8_A113ChipGSMId = new int[1] ;
         T000I2_A113ChipGSMId = new int[1] ;
         T000I2_A114ChipGSMDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         T000I2_A152ChipGSMGAMGUIDProprietario = new string[] {""} ;
         T000I2_A115ChipGSMOperadora = new string[] {""} ;
         T000I2_A116ChipGSMNumero = new string[] {""} ;
         T000I2_A117ChipGSMAtrelado = new bool[] {false} ;
         T000I9_A113ChipGSMId = new int[1] ;
         T000I12_A106RastreadorId = new int[1] ;
         T000I13_A113ChipGSMId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i114ChipGSMDataHoraCadastro = (DateTime)(DateTime.MinValue);
         i152ChipGSMGAMGUIDProprietario = "";
         GXt_char1 = "";
         T000I14_A116ChipGSMNumero = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.chipgsm__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.chipgsm__default(),
            new Object[][] {
                new Object[] {
               T000I2_A113ChipGSMId, T000I2_A114ChipGSMDataHoraCadastro, T000I2_A152ChipGSMGAMGUIDProprietario, T000I2_A115ChipGSMOperadora, T000I2_A116ChipGSMNumero, T000I2_A117ChipGSMAtrelado
               }
               , new Object[] {
               T000I3_A113ChipGSMId, T000I3_A114ChipGSMDataHoraCadastro, T000I3_A152ChipGSMGAMGUIDProprietario, T000I3_A115ChipGSMOperadora, T000I3_A116ChipGSMNumero, T000I3_A117ChipGSMAtrelado
               }
               , new Object[] {
               T000I4_A113ChipGSMId, T000I4_A114ChipGSMDataHoraCadastro, T000I4_A152ChipGSMGAMGUIDProprietario, T000I4_A115ChipGSMOperadora, T000I4_A116ChipGSMNumero, T000I4_A117ChipGSMAtrelado
               }
               , new Object[] {
               T000I5_A116ChipGSMNumero
               }
               , new Object[] {
               T000I6_A113ChipGSMId
               }
               , new Object[] {
               T000I7_A113ChipGSMId
               }
               , new Object[] {
               T000I8_A113ChipGSMId
               }
               , new Object[] {
               T000I9_A113ChipGSMId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I12_A106RastreadorId
               }
               , new Object[] {
               T000I13_A113ChipGSMId
               }
               , new Object[] {
               T000I14_A116ChipGSMNumero
               }
            }
         );
         Z152ChipGSMGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         A152ChipGSMGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         i152ChipGSMGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         Z114ChipGSMDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         A114ChipGSMDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         i114ChipGSMDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
      }

      private short GxWebError ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound19 ;
      private short GX_JID ;
      private short nIsDirty_19 ;
      private short gxajaxcallmode ;
      private int wcpOAV7ChipGSMId ;
      private int Z113ChipGSMId ;
      private int AV7ChipGSMId ;
      private int trnEnded ;
      private int A113ChipGSMId ;
      private int edtChipGSMId_Enabled ;
      private int edtChipGSMDataHoraCadastro_Enabled ;
      private int edtChipGSMGAMGUIDProprietario_Enabled ;
      private int edtChipGSMNumero_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z152ChipGSMGAMGUIDProprietario ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
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
      private string edtChipGSMId_Internalname ;
      private string edtChipGSMId_Jsonclick ;
      private string edtChipGSMDataHoraCadastro_Internalname ;
      private string edtChipGSMDataHoraCadastro_Jsonclick ;
      private string edtChipGSMGAMGUIDProprietario_Internalname ;
      private string A152ChipGSMGAMGUIDProprietario ;
      private string edtChipGSMGAMGUIDProprietario_Jsonclick ;
      private string TempTags ;
      private string cmbChipGSMOperadora_Jsonclick ;
      private string edtChipGSMNumero_Internalname ;
      private string edtChipGSMNumero_Jsonclick ;
      private string chkChipGSMAtrelado_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode19 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i152ChipGSMGAMGUIDProprietario ;
      private string GXt_char1 ;
      private DateTime Z114ChipGSMDataHoraCadastro ;
      private DateTime A114ChipGSMDataHoraCadastro ;
      private DateTime i114ChipGSMDataHoraCadastro ;
      private bool Z117ChipGSMAtrelado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A117ChipGSMAtrelado ;
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
      private string Z115ChipGSMOperadora ;
      private string Z116ChipGSMNumero ;
      private string A115ChipGSMOperadora ;
      private string A116ChipGSMNumero ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbChipGSMOperadora ;
      private GXCheckbox chkChipGSMAtrelado ;
      private IDataStoreProvider pr_default ;
      private int[] T000I4_A113ChipGSMId ;
      private DateTime[] T000I4_A114ChipGSMDataHoraCadastro ;
      private string[] T000I4_A152ChipGSMGAMGUIDProprietario ;
      private string[] T000I4_A115ChipGSMOperadora ;
      private string[] T000I4_A116ChipGSMNumero ;
      private bool[] T000I4_A117ChipGSMAtrelado ;
      private string[] T000I5_A116ChipGSMNumero ;
      private int[] T000I6_A113ChipGSMId ;
      private int[] T000I3_A113ChipGSMId ;
      private DateTime[] T000I3_A114ChipGSMDataHoraCadastro ;
      private string[] T000I3_A152ChipGSMGAMGUIDProprietario ;
      private string[] T000I3_A115ChipGSMOperadora ;
      private string[] T000I3_A116ChipGSMNumero ;
      private bool[] T000I3_A117ChipGSMAtrelado ;
      private int[] T000I7_A113ChipGSMId ;
      private int[] T000I8_A113ChipGSMId ;
      private int[] T000I2_A113ChipGSMId ;
      private DateTime[] T000I2_A114ChipGSMDataHoraCadastro ;
      private string[] T000I2_A152ChipGSMGAMGUIDProprietario ;
      private string[] T000I2_A115ChipGSMOperadora ;
      private string[] T000I2_A116ChipGSMNumero ;
      private bool[] T000I2_A117ChipGSMAtrelado ;
      private int[] T000I9_A113ChipGSMId ;
      private int[] T000I12_A106RastreadorId ;
      private int[] T000I13_A113ChipGSMId ;
      private string[] T000I14_A116ChipGSMNumero ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class chipgsm__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class chipgsm__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000I4;
        prmT000I4 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I5;
        prmT000I5 = new Object[] {
        new Object[] {"@ChipGSMNumero",SqlDbType.NVarChar,11,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I6;
        prmT000I6 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I3;
        prmT000I3 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I7;
        prmT000I7 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I8;
        prmT000I8 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I2;
        prmT000I2 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I9;
        prmT000I9 = new Object[] {
        new Object[] {"@ChipGSMDataHoraCadastro",SqlDbType.DateTime,8,5} ,
        new Object[] {"@ChipGSMGAMGUIDProprietario",SqlDbType.NChar,40,0} ,
        new Object[] {"@ChipGSMOperadora",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ChipGSMNumero",SqlDbType.NVarChar,11,0} ,
        new Object[] {"@ChipGSMAtrelado",SqlDbType.Bit,4,0}
        };
        Object[] prmT000I10;
        prmT000I10 = new Object[] {
        new Object[] {"@ChipGSMDataHoraCadastro",SqlDbType.DateTime,8,5} ,
        new Object[] {"@ChipGSMGAMGUIDProprietario",SqlDbType.NChar,40,0} ,
        new Object[] {"@ChipGSMOperadora",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ChipGSMNumero",SqlDbType.NVarChar,11,0} ,
        new Object[] {"@ChipGSMAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I11;
        prmT000I11 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I12;
        prmT000I12 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmT000I13;
        prmT000I13 = new Object[] {
        };
        Object[] prmT000I14;
        prmT000I14 = new Object[] {
        new Object[] {"@ChipGSMNumero",SqlDbType.NVarChar,11,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000I2", "SELECT [ChipGSMId], [ChipGSMDataHoraCadastro], [ChipGSMGAMGUIDProprietario], [ChipGSMOperadora], [ChipGSMNumero], [ChipGSMAtrelado] FROM [ChipGSM] WITH (UPDLOCK) WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I3", "SELECT [ChipGSMId], [ChipGSMDataHoraCadastro], [ChipGSMGAMGUIDProprietario], [ChipGSMOperadora], [ChipGSMNumero], [ChipGSMAtrelado] FROM [ChipGSM] WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I4", "SELECT TM1.[ChipGSMId], TM1.[ChipGSMDataHoraCadastro], TM1.[ChipGSMGAMGUIDProprietario], TM1.[ChipGSMOperadora], TM1.[ChipGSMNumero], TM1.[ChipGSMAtrelado] FROM [ChipGSM] TM1 WHERE TM1.[ChipGSMId] = @ChipGSMId ORDER BY TM1.[ChipGSMId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I5", "SELECT [ChipGSMNumero] FROM [ChipGSM] WHERE ([ChipGSMNumero] = @ChipGSMNumero) AND (Not ( [ChipGSMId] = @ChipGSMId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I6", "SELECT [ChipGSMId] FROM [ChipGSM] WHERE [ChipGSMId] = @ChipGSMId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I7", "SELECT TOP 1 [ChipGSMId] FROM [ChipGSM] WHERE ( [ChipGSMId] > @ChipGSMId) ORDER BY [ChipGSMId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I8", "SELECT TOP 1 [ChipGSMId] FROM [ChipGSM] WHERE ( [ChipGSMId] < @ChipGSMId) ORDER BY [ChipGSMId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I9", "INSERT INTO [ChipGSM]([ChipGSMDataHoraCadastro], [ChipGSMGAMGUIDProprietario], [ChipGSMOperadora], [ChipGSMNumero], [ChipGSMAtrelado]) VALUES(@ChipGSMDataHoraCadastro, @ChipGSMGAMGUIDProprietario, @ChipGSMOperadora, @ChipGSMNumero, @ChipGSMAtrelado); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000I9)
           ,new CursorDef("T000I10", "UPDATE [ChipGSM] SET [ChipGSMDataHoraCadastro]=@ChipGSMDataHoraCadastro, [ChipGSMGAMGUIDProprietario]=@ChipGSMGAMGUIDProprietario, [ChipGSMOperadora]=@ChipGSMOperadora, [ChipGSMNumero]=@ChipGSMNumero, [ChipGSMAtrelado]=@ChipGSMAtrelado  WHERE [ChipGSMId] = @ChipGSMId", GxErrorMask.GX_NOMASK,prmT000I10)
           ,new CursorDef("T000I11", "DELETE FROM [ChipGSM]  WHERE [ChipGSMId] = @ChipGSMId", GxErrorMask.GX_NOMASK,prmT000I11)
           ,new CursorDef("T000I12", "SELECT TOP 1 [RastreadorId] FROM [Rastreador] WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I13", "SELECT [ChipGSMId] FROM [ChipGSM] ORDER BY [ChipGSMId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I14", "SELECT [ChipGSMNumero] FROM [ChipGSM] WHERE ([ChipGSMNumero] = @ChipGSMNumero) AND (Not ( [ChipGSMId] = @ChipGSMId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I14,1, GxCacheFrequency.OFF ,true,false )
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
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getBool(6);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getBool(6);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getBool(6);
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
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
           case 10 :
              table[0][0] = rslt.getInt(1);
              return;
           case 11 :
              table[0][0] = rslt.getInt(1);
              return;
           case 12 :
              table[0][0] = rslt.getVarchar(1);
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
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
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
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (bool)parms[4]);
              return;
           case 8 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (bool)parms[4]);
              stmt.SetParameter(6, (int)parms[5]);
              return;
           case 9 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
