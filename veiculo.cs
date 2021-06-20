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
   public class veiculo : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action13") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A98VeiculoId = (int)(NumberUtil.Val( GetPar( "VeiculoId"), "."));
            AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_13_0F16( Gx_mode, A98VeiculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action14") == 0 )
         {
            AV7VeiculoId = (int)(NumberUtil.Val( GetPar( "VeiculoId"), "."));
            AssignAttri("", false, "AV7VeiculoId", StringUtil.LTrimStr( (decimal)(AV7VeiculoId), 8, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vVEICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VeiculoId), "ZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_14_0F16( AV7VeiculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"VEICULOGAMGUID") == 0 )
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
            GX6ASAVEICULOGAMGUID0F16( Gx_BScreen, Gx_mode) ;
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
               AV7VeiculoId = (int)(NumberUtil.Val( GetPar( "VeiculoId"), "."));
               AssignAttri("", false, "AV7VeiculoId", StringUtil.LTrimStr( (decimal)(AV7VeiculoId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vVEICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VeiculoId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Veículo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVeiculoPlaca_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public veiculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public veiculo( IGxContext context )
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
                           int aP1_VeiculoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VeiculoId = aP1_VeiculoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbVeiculoCor = new GXCombobox();
         cmbVeiculoTipo = new GXCombobox();
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
            return "veiculo_Execute" ;
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
         if ( cmbVeiculoCor.ItemCount > 0 )
         {
            A97VeiculoCor = cmbVeiculoCor.getValidValue(A97VeiculoCor);
            AssignAttri("", false, "A97VeiculoCor", A97VeiculoCor);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVeiculoCor.CurrentValue = StringUtil.RTrim( A97VeiculoCor);
            AssignProp("", false, cmbVeiculoCor_Internalname, "Values", cmbVeiculoCor.ToJavascriptSource(), true);
         }
         if ( cmbVeiculoTipo.ItemCount > 0 )
         {
            A101VeiculoTipo = cmbVeiculoTipo.getValidValue(A101VeiculoTipo);
            AssignAttri("", false, "A101VeiculoTipo", A101VeiculoTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVeiculoTipo.CurrentValue = StringUtil.RTrim( A101VeiculoTipo);
            AssignProp("", false, cmbVeiculoTipo_Internalname, "Values", cmbVeiculoTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVeiculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVeiculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98VeiculoId), 8, 0, ",", "")), ((edtVeiculoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A98VeiculoId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A98VeiculoId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVeiculoDataHoraCadastro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoDataHoraCadastro_Internalname, "Data/Hora do Cadastro", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtVeiculoDataHoraCadastro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVeiculoDataHoraCadastro_Internalname, context.localUtil.TToC( A99VeiculoDataHoraCadastro, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A99VeiculoDataHoraCadastro, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoDataHoraCadastro_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtVeiculoDataHoraCadastro_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Veiculo.htm");
         GxWebStd.gx_bitmap( context, edtVeiculoDataHoraCadastro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVeiculoDataHoraCadastro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Veiculo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVeiculoGAMGUID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoGAMGUID_Internalname, "GAMGUID do Proprietário", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVeiculoGAMGUID_Internalname, StringUtil.RTrim( A105VeiculoGAMGUID), StringUtil.RTrim( context.localUtil.Format( A105VeiculoGAMGUID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoGAMGUID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVeiculoPlaca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoPlaca_Internalname, "Placa", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoPlaca_Internalname, A100VeiculoPlaca, StringUtil.RTrim( context.localUtil.Format( A100VeiculoPlaca, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoPlaca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoPlaca_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVeiculoCor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbVeiculoCor_Internalname, "Cor", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVeiculoCor, cmbVeiculoCor_Internalname, StringUtil.RTrim( A97VeiculoCor), 1, cmbVeiculoCor_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbVeiculoCor.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "", true, "HLP_Veiculo.htm");
         cmbVeiculoCor.CurrentValue = StringUtil.RTrim( A97VeiculoCor);
         AssignProp("", false, cmbVeiculoCor_Internalname, "Values", (string)(cmbVeiculoCor.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVeiculoTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbVeiculoTipo_Internalname, "Tipo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVeiculoTipo, cmbVeiculoTipo_Internalname, StringUtil.RTrim( A101VeiculoTipo), 1, cmbVeiculoTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbVeiculoTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, "HLP_Veiculo.htm");
         cmbVeiculoTipo.CurrentValue = StringUtil.RTrim( A101VeiculoTipo);
         AssignProp("", false, cmbVeiculoTipo_Internalname, "Values", (string)(cmbVeiculoTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVeiculoMarca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoMarca_Internalname, "Marca", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoMarca_Internalname, A102VeiculoMarca, StringUtil.RTrim( context.localUtil.Format( A102VeiculoMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoMarca_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVeiculoModelo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoModelo_Internalname, "Modelo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoModelo_Internalname, A103VeiculoModelo, StringUtil.RTrim( context.localUtil.Format( A103VeiculoModelo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoModelo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoModelo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVeiculoAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoAno_Internalname, "Ano", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoAno_Internalname, A104VeiculoAno, StringUtil.RTrim( context.localUtil.Format( A104VeiculoAno, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoAno_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_rastreadores.SetProperty("Width", Dvpanel_rastreadores_Width);
         ucDvpanel_rastreadores.SetProperty("AutoWidth", Dvpanel_rastreadores_Autowidth);
         ucDvpanel_rastreadores.SetProperty("AutoHeight", Dvpanel_rastreadores_Autoheight);
         ucDvpanel_rastreadores.SetProperty("Cls", Dvpanel_rastreadores_Cls);
         ucDvpanel_rastreadores.SetProperty("Title", Dvpanel_rastreadores_Title);
         ucDvpanel_rastreadores.SetProperty("Collapsible", Dvpanel_rastreadores_Collapsible);
         ucDvpanel_rastreadores.SetProperty("Collapsed", Dvpanel_rastreadores_Collapsed);
         ucDvpanel_rastreadores.SetProperty("ShowCollapseIcon", Dvpanel_rastreadores_Showcollapseicon);
         ucDvpanel_rastreadores.SetProperty("IconPosition", Dvpanel_rastreadores_Iconposition);
         ucDvpanel_rastreadores.SetProperty("AutoScroll", Dvpanel_rastreadores_Autoscroll);
         ucDvpanel_rastreadores.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_rastreadores_Internalname, "DVPANEL_RASTREADORESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_RASTREADORESContainer"+"Rastreadores"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divRastreadores_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0066"+"", StringUtil.RTrim( WebComp_Wcassociationfrotaveiculo_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0066"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcassociationfrotaveiculo), StringUtil.Lower( WebComp_Wcassociationfrotaveiculo_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0066"+"");
               }
               WebComp_Wcassociationfrotaveiculo.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcassociationfrotaveiculo), StringUtil.Lower( WebComp_Wcassociationfrotaveiculo_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Veiculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Veiculo.htm");
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
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
               {
                  WebComp_Wcassociationfrotaveiculo.componentstart();
               }
            }
         }
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
         E110F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z98VeiculoId = (int)(context.localUtil.CToN( cgiGet( "Z98VeiculoId"), ",", "."));
               Z99VeiculoDataHoraCadastro = context.localUtil.CToT( cgiGet( "Z99VeiculoDataHoraCadastro"), 0);
               Z105VeiculoGAMGUID = cgiGet( "Z105VeiculoGAMGUID");
               Z100VeiculoPlaca = cgiGet( "Z100VeiculoPlaca");
               Z97VeiculoCor = cgiGet( "Z97VeiculoCor");
               Z101VeiculoTipo = cgiGet( "Z101VeiculoTipo");
               Z102VeiculoMarca = cgiGet( "Z102VeiculoMarca");
               Z103VeiculoModelo = cgiGet( "Z103VeiculoModelo");
               Z104VeiculoAno = cgiGet( "Z104VeiculoAno");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7VeiculoId = (int)(context.localUtil.CToN( cgiGet( "vVEICULOID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               Dvpanel_rastreadores_Objectcall = cgiGet( "DVPANEL_RASTREADORES_Objectcall");
               Dvpanel_rastreadores_Class = cgiGet( "DVPANEL_RASTREADORES_Class");
               Dvpanel_rastreadores_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Enabled"));
               Dvpanel_rastreadores_Width = cgiGet( "DVPANEL_RASTREADORES_Width");
               Dvpanel_rastreadores_Height = cgiGet( "DVPANEL_RASTREADORES_Height");
               Dvpanel_rastreadores_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Autowidth"));
               Dvpanel_rastreadores_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Autoheight"));
               Dvpanel_rastreadores_Cls = cgiGet( "DVPANEL_RASTREADORES_Cls");
               Dvpanel_rastreadores_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Showheader"));
               Dvpanel_rastreadores_Title = cgiGet( "DVPANEL_RASTREADORES_Title");
               Dvpanel_rastreadores_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Collapsible"));
               Dvpanel_rastreadores_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Collapsed"));
               Dvpanel_rastreadores_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Showcollapseicon"));
               Dvpanel_rastreadores_Iconposition = cgiGet( "DVPANEL_RASTREADORES_Iconposition");
               Dvpanel_rastreadores_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Autoscroll"));
               Dvpanel_rastreadores_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_RASTREADORES_Visible"));
               Dvpanel_rastreadores_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_RASTREADORES_Gxcontroltype"), ",", "."));
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
               A98VeiculoId = (int)(context.localUtil.CToN( cgiGet( edtVeiculoId_Internalname), ",", "."));
               AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
               A99VeiculoDataHoraCadastro = context.localUtil.CToT( cgiGet( edtVeiculoDataHoraCadastro_Internalname));
               AssignAttri("", false, "A99VeiculoDataHoraCadastro", context.localUtil.TToC( A99VeiculoDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
               A105VeiculoGAMGUID = cgiGet( edtVeiculoGAMGUID_Internalname);
               AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
               A100VeiculoPlaca = StringUtil.Upper( cgiGet( edtVeiculoPlaca_Internalname));
               AssignAttri("", false, "A100VeiculoPlaca", A100VeiculoPlaca);
               cmbVeiculoCor.CurrentValue = cgiGet( cmbVeiculoCor_Internalname);
               A97VeiculoCor = cgiGet( cmbVeiculoCor_Internalname);
               AssignAttri("", false, "A97VeiculoCor", A97VeiculoCor);
               cmbVeiculoTipo.CurrentValue = cgiGet( cmbVeiculoTipo_Internalname);
               A101VeiculoTipo = cgiGet( cmbVeiculoTipo_Internalname);
               AssignAttri("", false, "A101VeiculoTipo", A101VeiculoTipo);
               A102VeiculoMarca = cgiGet( edtVeiculoMarca_Internalname);
               AssignAttri("", false, "A102VeiculoMarca", A102VeiculoMarca);
               A103VeiculoModelo = cgiGet( edtVeiculoModelo_Internalname);
               AssignAttri("", false, "A103VeiculoModelo", A103VeiculoModelo);
               A104VeiculoAno = cgiGet( edtVeiculoAno_Internalname);
               AssignAttri("", false, "A104VeiculoAno", A104VeiculoAno);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Veiculo");
               A98VeiculoId = (int)(context.localUtil.CToN( cgiGet( edtVeiculoId_Internalname), ",", "."));
               AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
               forbiddenHiddens.Add("VeiculoId", context.localUtil.Format( (decimal)(A98VeiculoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A99VeiculoDataHoraCadastro = context.localUtil.CToT( cgiGet( edtVeiculoDataHoraCadastro_Internalname));
               AssignAttri("", false, "A99VeiculoDataHoraCadastro", context.localUtil.TToC( A99VeiculoDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
               forbiddenHiddens.Add("VeiculoDataHoraCadastro", context.localUtil.Format( A99VeiculoDataHoraCadastro, "99/99/99 99:99"));
               A105VeiculoGAMGUID = cgiGet( edtVeiculoGAMGUID_Internalname);
               AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
               forbiddenHiddens.Add("VeiculoGAMGUID", StringUtil.RTrim( context.localUtil.Format( A105VeiculoGAMGUID, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A98VeiculoId != Z98VeiculoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("veiculo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A98VeiculoId = (int)(NumberUtil.Val( GetPar( "VeiculoId"), "."));
                  AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
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
                     sMode16 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode16;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound16 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VEICULOID");
                        AnyError = 1;
                        GX_FocusControl = edtVeiculoId_Internalname;
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
                           E110F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120F2 ();
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
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                     if ( nCmpId == 66 )
                     {
                        OldWcassociationfrotaveiculo = cgiGet( "W0066");
                        if ( ( StringUtil.Len( OldWcassociationfrotaveiculo) == 0 ) || ( StringUtil.StrCmp(OldWcassociationfrotaveiculo, WebComp_Wcassociationfrotaveiculo_Component) != 0 ) )
                        {
                           WebComp_Wcassociationfrotaveiculo = getWebComponent(GetType(), "GeneXus.Programs", OldWcassociationfrotaveiculo, new Object[] {context} );
                           WebComp_Wcassociationfrotaveiculo.ComponentInit();
                           WebComp_Wcassociationfrotaveiculo.Name = "OldWcassociationfrotaveiculo";
                           WebComp_Wcassociationfrotaveiculo_Component = OldWcassociationfrotaveiculo;
                        }
                        if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
                        {
                           WebComp_Wcassociationfrotaveiculo.componentprocess("W0066", "", sEvt);
                        }
                        WebComp_Wcassociationfrotaveiculo_Component = OldWcassociationfrotaveiculo;
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
            E120F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F16( ) ;
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
            DisableAttributes0F16( ) ;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F16( ) ;
            }
            else
            {
               CheckExtendedTable0F16( ) ;
               CloseExtendedTableCursors0F16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void E110F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcassociationfrotaveiculo = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcassociationfrotaveiculo_Component), StringUtil.Lower( "AssociationVeiculoRastreador")) != 0 )
         {
            WebComp_Wcassociationfrotaveiculo = getWebComponent(GetType(), "GeneXus.Programs", "associationveiculorastreador", new Object[] {context} );
            WebComp_Wcassociationfrotaveiculo.ComponentInit();
            WebComp_Wcassociationfrotaveiculo.Name = "AssociationVeiculoRastreador";
            WebComp_Wcassociationfrotaveiculo_Component = "AssociationVeiculoRastreador";
         }
         if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
         {
            WebComp_Wcassociationfrotaveiculo.setjustcreated();
            WebComp_Wcassociationfrotaveiculo.componentprepare(new Object[] {(string)"W0066",(string)"",(int)AV7VeiculoId});
            WebComp_Wcassociationfrotaveiculo.componentbind(new Object[] {(string)""});
         }
      }

      protected void E120F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("veiculoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z99VeiculoDataHoraCadastro = T000F3_A99VeiculoDataHoraCadastro[0];
               Z105VeiculoGAMGUID = T000F3_A105VeiculoGAMGUID[0];
               Z100VeiculoPlaca = T000F3_A100VeiculoPlaca[0];
               Z97VeiculoCor = T000F3_A97VeiculoCor[0];
               Z101VeiculoTipo = T000F3_A101VeiculoTipo[0];
               Z102VeiculoMarca = T000F3_A102VeiculoMarca[0];
               Z103VeiculoModelo = T000F3_A103VeiculoModelo[0];
               Z104VeiculoAno = T000F3_A104VeiculoAno[0];
            }
            else
            {
               Z99VeiculoDataHoraCadastro = A99VeiculoDataHoraCadastro;
               Z105VeiculoGAMGUID = A105VeiculoGAMGUID;
               Z100VeiculoPlaca = A100VeiculoPlaca;
               Z97VeiculoCor = A97VeiculoCor;
               Z101VeiculoTipo = A101VeiculoTipo;
               Z102VeiculoMarca = A102VeiculoMarca;
               Z103VeiculoModelo = A103VeiculoModelo;
               Z104VeiculoAno = A104VeiculoAno;
            }
         }
         if ( GX_JID == -15 )
         {
            Z98VeiculoId = A98VeiculoId;
            Z99VeiculoDataHoraCadastro = A99VeiculoDataHoraCadastro;
            Z105VeiculoGAMGUID = A105VeiculoGAMGUID;
            Z100VeiculoPlaca = A100VeiculoPlaca;
            Z97VeiculoCor = A97VeiculoCor;
            Z101VeiculoTipo = A101VeiculoTipo;
            Z102VeiculoMarca = A102VeiculoMarca;
            Z103VeiculoModelo = A103VeiculoModelo;
            Z104VeiculoAno = A104VeiculoAno;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
         edtVeiculoDataHoraCadastro_Enabled = 0;
         AssignProp("", false, edtVeiculoDataHoraCadastro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoDataHoraCadastro_Enabled), 5, 0), true);
         edtVeiculoGAMGUID_Enabled = 0;
         AssignProp("", false, edtVeiculoGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoGAMGUID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
         edtVeiculoDataHoraCadastro_Enabled = 0;
         AssignProp("", false, edtVeiculoDataHoraCadastro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoDataHoraCadastro_Enabled), 5, 0), true);
         edtVeiculoGAMGUID_Enabled = 0;
         AssignProp("", false, edtVeiculoGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoGAMGUID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7VeiculoId) )
         {
            A98VeiculoId = AV7VeiculoId;
            AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A99VeiculoDataHoraCadastro) && ( Gx_BScreen == 0 ) )
         {
            A99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A99VeiculoDataHoraCadastro", context.localUtil.TToC( A99VeiculoDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A105VeiculoGAMGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A105VeiculoGAMGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A105VeiculoGAMGUID = GXt_char1;
            AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound16 = 1;
            A99VeiculoDataHoraCadastro = T000F4_A99VeiculoDataHoraCadastro[0];
            AssignAttri("", false, "A99VeiculoDataHoraCadastro", context.localUtil.TToC( A99VeiculoDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
            A105VeiculoGAMGUID = T000F4_A105VeiculoGAMGUID[0];
            AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
            A100VeiculoPlaca = T000F4_A100VeiculoPlaca[0];
            AssignAttri("", false, "A100VeiculoPlaca", A100VeiculoPlaca);
            A97VeiculoCor = T000F4_A97VeiculoCor[0];
            AssignAttri("", false, "A97VeiculoCor", A97VeiculoCor);
            A101VeiculoTipo = T000F4_A101VeiculoTipo[0];
            AssignAttri("", false, "A101VeiculoTipo", A101VeiculoTipo);
            A102VeiculoMarca = T000F4_A102VeiculoMarca[0];
            AssignAttri("", false, "A102VeiculoMarca", A102VeiculoMarca);
            A103VeiculoModelo = T000F4_A103VeiculoModelo[0];
            AssignAttri("", false, "A103VeiculoModelo", A103VeiculoModelo);
            A104VeiculoAno = T000F4_A104VeiculoAno[0];
            AssignAttri("", false, "A104VeiculoAno", A104VeiculoAno);
            ZM0F16( -15) ;
         }
         pr_default.close(2);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
      }

      protected void CheckExtendedTable0F16( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A100VeiculoPlaca, A98VeiculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Placa"}), 1, "VEICULOPLACA");
            AnyError = 1;
            GX_FocusControl = edtVeiculoPlaca_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A100VeiculoPlaca)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Placa", "", "", "", "", "", "", "", ""), 1, "VEICULOPLACA");
            AnyError = 1;
            GX_FocusControl = edtVeiculoPlaca_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A97VeiculoCor)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Cor", "", "", "", "", "", "", "", ""), 1, "VEICULOCOR");
            AnyError = 1;
            GX_FocusControl = cmbVeiculoCor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A101VeiculoTipo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo", "", "", "", "", "", "", "", ""), 1, "VEICULOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbVeiculoTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A102VeiculoMarca)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Marca", "", "", "", "", "", "", "", ""), 1, "VEICULOMARCA");
            AnyError = 1;
            GX_FocusControl = edtVeiculoMarca_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103VeiculoModelo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Modelo", "", "", "", "", "", "", "", ""), 1, "VEICULOMODELO");
            AnyError = 1;
            GX_FocusControl = edtVeiculoModelo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A104VeiculoAno)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Ano", "", "", "", "", "", "", "", ""), 1, "VEICULOANO");
            AnyError = 1;
            GX_FocusControl = edtVeiculoAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0F16( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F16( )
      {
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F16( 15) ;
            RcdFound16 = 1;
            A98VeiculoId = T000F3_A98VeiculoId[0];
            AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
            A99VeiculoDataHoraCadastro = T000F3_A99VeiculoDataHoraCadastro[0];
            AssignAttri("", false, "A99VeiculoDataHoraCadastro", context.localUtil.TToC( A99VeiculoDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
            A105VeiculoGAMGUID = T000F3_A105VeiculoGAMGUID[0];
            AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
            A100VeiculoPlaca = T000F3_A100VeiculoPlaca[0];
            AssignAttri("", false, "A100VeiculoPlaca", A100VeiculoPlaca);
            A97VeiculoCor = T000F3_A97VeiculoCor[0];
            AssignAttri("", false, "A97VeiculoCor", A97VeiculoCor);
            A101VeiculoTipo = T000F3_A101VeiculoTipo[0];
            AssignAttri("", false, "A101VeiculoTipo", A101VeiculoTipo);
            A102VeiculoMarca = T000F3_A102VeiculoMarca[0];
            AssignAttri("", false, "A102VeiculoMarca", A102VeiculoMarca);
            A103VeiculoModelo = T000F3_A103VeiculoModelo[0];
            AssignAttri("", false, "A103VeiculoModelo", A103VeiculoModelo);
            A104VeiculoAno = T000F3_A104VeiculoAno[0];
            AssignAttri("", false, "A104VeiculoAno", A104VeiculoAno);
            Z98VeiculoId = A98VeiculoId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A98VeiculoId[0] < A98VeiculoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A98VeiculoId[0] > A98VeiculoId ) ) )
            {
               A98VeiculoId = T000F7_A98VeiculoId[0];
               AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000F8_A98VeiculoId[0] > A98VeiculoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000F8_A98VeiculoId[0] < A98VeiculoId ) ) )
            {
               A98VeiculoId = T000F8_A98VeiculoId[0];
               AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVeiculoPlaca_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F16( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A98VeiculoId != Z98VeiculoId )
               {
                  A98VeiculoId = Z98VeiculoId;
                  AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VEICULOID");
                  AnyError = 1;
                  GX_FocusControl = edtVeiculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVeiculoPlaca_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0F16( ) ;
                  GX_FocusControl = edtVeiculoPlaca_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A98VeiculoId != Z98VeiculoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtVeiculoPlaca_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F16( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VEICULOID");
                     AnyError = 1;
                     GX_FocusControl = edtVeiculoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtVeiculoPlaca_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F16( ) ;
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
         if ( A98VeiculoId != Z98VeiculoId )
         {
            A98VeiculoId = Z98VeiculoId;
            AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VEICULOID");
            AnyError = 1;
            GX_FocusControl = edtVeiculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVeiculoPlaca_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Veiculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z99VeiculoDataHoraCadastro != T000F2_A99VeiculoDataHoraCadastro[0] ) || ( StringUtil.StrCmp(Z105VeiculoGAMGUID, T000F2_A105VeiculoGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z100VeiculoPlaca, T000F2_A100VeiculoPlaca[0]) != 0 ) || ( StringUtil.StrCmp(Z97VeiculoCor, T000F2_A97VeiculoCor[0]) != 0 ) || ( StringUtil.StrCmp(Z101VeiculoTipo, T000F2_A101VeiculoTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z102VeiculoMarca, T000F2_A102VeiculoMarca[0]) != 0 ) || ( StringUtil.StrCmp(Z103VeiculoModelo, T000F2_A103VeiculoModelo[0]) != 0 ) || ( StringUtil.StrCmp(Z104VeiculoAno, T000F2_A104VeiculoAno[0]) != 0 ) )
            {
               if ( Z99VeiculoDataHoraCadastro != T000F2_A99VeiculoDataHoraCadastro[0] )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoDataHoraCadastro");
                  GXUtil.WriteLogRaw("Old: ",Z99VeiculoDataHoraCadastro);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A99VeiculoDataHoraCadastro[0]);
               }
               if ( StringUtil.StrCmp(Z105VeiculoGAMGUID, T000F2_A105VeiculoGAMGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoGAMGUID");
                  GXUtil.WriteLogRaw("Old: ",Z105VeiculoGAMGUID);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A105VeiculoGAMGUID[0]);
               }
               if ( StringUtil.StrCmp(Z100VeiculoPlaca, T000F2_A100VeiculoPlaca[0]) != 0 )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoPlaca");
                  GXUtil.WriteLogRaw("Old: ",Z100VeiculoPlaca);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A100VeiculoPlaca[0]);
               }
               if ( StringUtil.StrCmp(Z97VeiculoCor, T000F2_A97VeiculoCor[0]) != 0 )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoCor");
                  GXUtil.WriteLogRaw("Old: ",Z97VeiculoCor);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A97VeiculoCor[0]);
               }
               if ( StringUtil.StrCmp(Z101VeiculoTipo, T000F2_A101VeiculoTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoTipo");
                  GXUtil.WriteLogRaw("Old: ",Z101VeiculoTipo);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A101VeiculoTipo[0]);
               }
               if ( StringUtil.StrCmp(Z102VeiculoMarca, T000F2_A102VeiculoMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoMarca");
                  GXUtil.WriteLogRaw("Old: ",Z102VeiculoMarca);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A102VeiculoMarca[0]);
               }
               if ( StringUtil.StrCmp(Z103VeiculoModelo, T000F2_A103VeiculoModelo[0]) != 0 )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoModelo");
                  GXUtil.WriteLogRaw("Old: ",Z103VeiculoModelo);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A103VeiculoModelo[0]);
               }
               if ( StringUtil.StrCmp(Z104VeiculoAno, T000F2_A104VeiculoAno[0]) != 0 )
               {
                  GXUtil.WriteLog("veiculo:[seudo value changed for attri]"+"VeiculoAno");
                  GXUtil.WriteLogRaw("Old: ",Z104VeiculoAno);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A104VeiculoAno[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Veiculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         if ( ! IsAuthorized("veiculo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F9 */
                     pr_default.execute(7, new Object[] {A99VeiculoDataHoraCadastro, A105VeiculoGAMGUID, A100VeiculoPlaca, A97VeiculoCor, A101VeiculoTipo, A102VeiculoMarca, A103VeiculoModelo, A104VeiculoAno});
                     A98VeiculoId = T000F9_A98VeiculoId[0];
                     AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Veiculo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0F0( ) ;
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         if ( ! IsAuthorized("veiculo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F10 */
                     pr_default.execute(8, new Object[] {A99VeiculoDataHoraCadastro, A105VeiculoGAMGUID, A100VeiculoPlaca, A97VeiculoCor, A101VeiculoTipo, A102VeiculoMarca, A103VeiculoModelo, A104VeiculoAno, A98VeiculoId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Veiculo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Veiculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
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
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("veiculo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F11 */
                  pr_default.execute(9, new Object[] {A98VeiculoId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("Veiculo");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000F12 */
            pr_default.execute(10, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Veiculo Rastreador"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000F13 */
            pr_default.execute(11, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Frota Veiculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("veiculo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            if ( IsIns( )  || IsUpd( )  )
            {
               new atualizarveiculorastreador(context ).execute(  A98VeiculoId) ;
            }
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("veiculo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor T000F14 */
         pr_default.execute(12);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound16 = 1;
            A98VeiculoId = T000F14_A98VeiculoId[0];
            AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound16 = 1;
            A98VeiculoId = T000F14_A98VeiculoId[0];
            AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
         }
      }

      protected void ScanEnd0F16( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
         new desatrelartodosrastreadoresveiculo(context ).execute(  AV7VeiculoId) ;
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
         edtVeiculoDataHoraCadastro_Enabled = 0;
         AssignProp("", false, edtVeiculoDataHoraCadastro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoDataHoraCadastro_Enabled), 5, 0), true);
         edtVeiculoGAMGUID_Enabled = 0;
         AssignProp("", false, edtVeiculoGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoGAMGUID_Enabled), 5, 0), true);
         edtVeiculoPlaca_Enabled = 0;
         AssignProp("", false, edtVeiculoPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoPlaca_Enabled), 5, 0), true);
         cmbVeiculoCor.Enabled = 0;
         AssignProp("", false, cmbVeiculoCor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVeiculoCor.Enabled), 5, 0), true);
         cmbVeiculoTipo.Enabled = 0;
         AssignProp("", false, cmbVeiculoTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVeiculoTipo.Enabled), 5, 0), true);
         edtVeiculoMarca_Enabled = 0;
         AssignProp("", false, edtVeiculoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoMarca_Enabled), 5, 0), true);
         edtVeiculoModelo_Enabled = 0;
         AssignProp("", false, edtVeiculoModelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoModelo_Enabled), 5, 0), true);
         edtVeiculoAno_Enabled = 0;
         AssignProp("", false, edtVeiculoAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoAno_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142918245022", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("veiculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VeiculoId,8,0))}, new string[] {"Gx_mode","VeiculoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Veiculo");
         forbiddenHiddens.Add("VeiculoId", context.localUtil.Format( (decimal)(A98VeiculoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("VeiculoDataHoraCadastro", context.localUtil.Format( A99VeiculoDataHoraCadastro, "99/99/99 99:99"));
         forbiddenHiddens.Add("VeiculoGAMGUID", StringUtil.RTrim( context.localUtil.Format( A105VeiculoGAMGUID, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("veiculo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z98VeiculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98VeiculoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z99VeiculoDataHoraCadastro", context.localUtil.TToC( Z99VeiculoDataHoraCadastro, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z105VeiculoGAMGUID", StringUtil.RTrim( Z105VeiculoGAMGUID));
         GxWebStd.gx_hidden_field( context, "Z100VeiculoPlaca", Z100VeiculoPlaca);
         GxWebStd.gx_hidden_field( context, "Z97VeiculoCor", StringUtil.RTrim( Z97VeiculoCor));
         GxWebStd.gx_hidden_field( context, "Z101VeiculoTipo", Z101VeiculoTipo);
         GxWebStd.gx_hidden_field( context, "Z102VeiculoMarca", Z102VeiculoMarca);
         GxWebStd.gx_hidden_field( context, "Z103VeiculoModelo", Z103VeiculoModelo);
         GxWebStd.gx_hidden_field( context, "Z104VeiculoAno", Z104VeiculoAno);
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
         GxWebStd.gx_hidden_field( context, "vVEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VeiculoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVEICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VeiculoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Objectcall", StringUtil.RTrim( Dvpanel_rastreadores_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Enabled", StringUtil.BoolToStr( Dvpanel_rastreadores_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Width", StringUtil.RTrim( Dvpanel_rastreadores_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Autowidth", StringUtil.BoolToStr( Dvpanel_rastreadores_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Autoheight", StringUtil.BoolToStr( Dvpanel_rastreadores_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Cls", StringUtil.RTrim( Dvpanel_rastreadores_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Title", StringUtil.RTrim( Dvpanel_rastreadores_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Collapsible", StringUtil.BoolToStr( Dvpanel_rastreadores_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Collapsed", StringUtil.BoolToStr( Dvpanel_rastreadores_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_rastreadores_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Iconposition", StringUtil.RTrim( Dvpanel_rastreadores_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_RASTREADORES_Autoscroll", StringUtil.BoolToStr( Dvpanel_rastreadores_Autoscroll));
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
         if ( ! ( WebComp_Wcassociationfrotaveiculo == null ) )
         {
            WebComp_Wcassociationfrotaveiculo.componentjscripts();
         }
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
               {
                  WebComp_Wcassociationfrotaveiculo.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
               {
                  WebComp_Wcassociationfrotaveiculo.componentstart();
               }
            }
         }
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
         return formatLink("veiculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VeiculoId,8,0))}, new string[] {"Gx_mode","VeiculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Veiculo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Veículo" ;
      }

      protected void InitializeNonKey0F16( )
      {
         A100VeiculoPlaca = "";
         AssignAttri("", false, "A100VeiculoPlaca", A100VeiculoPlaca);
         A97VeiculoCor = "";
         AssignAttri("", false, "A97VeiculoCor", A97VeiculoCor);
         A101VeiculoTipo = "";
         AssignAttri("", false, "A101VeiculoTipo", A101VeiculoTipo);
         A102VeiculoMarca = "";
         AssignAttri("", false, "A102VeiculoMarca", A102VeiculoMarca);
         A103VeiculoModelo = "";
         AssignAttri("", false, "A103VeiculoModelo", A103VeiculoModelo);
         A104VeiculoAno = "";
         AssignAttri("", false, "A104VeiculoAno", A104VeiculoAno);
         A99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "A99VeiculoDataHoraCadastro", context.localUtil.TToC( A99VeiculoDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
         A105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
         Z99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         Z105VeiculoGAMGUID = "";
         Z100VeiculoPlaca = "";
         Z97VeiculoCor = "";
         Z101VeiculoTipo = "";
         Z102VeiculoMarca = "";
         Z103VeiculoModelo = "";
         Z104VeiculoAno = "";
      }

      protected void InitAll0F16( )
      {
         A98VeiculoId = 0;
         AssignAttri("", false, "A98VeiculoId", StringUtil.LTrimStr( (decimal)(A98VeiculoId), 8, 0));
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A99VeiculoDataHoraCadastro = i99VeiculoDataHoraCadastro;
         AssignAttri("", false, "A99VeiculoDataHoraCadastro", context.localUtil.TToC( A99VeiculoDataHoraCadastro, 8, 5, 0, 3, "/", ":", " "));
         A105VeiculoGAMGUID = i105VeiculoGAMGUID;
         AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcassociationfrotaveiculo == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
            {
               WebComp_Wcassociationfrotaveiculo.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918245034", true, true);
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
         context.AddJavascriptSource("veiculo.js", "?202142918245034", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtVeiculoId_Internalname = "VEICULOID";
         edtVeiculoDataHoraCadastro_Internalname = "VEICULODATAHORACADASTRO";
         edtVeiculoGAMGUID_Internalname = "VEICULOGAMGUID";
         edtVeiculoPlaca_Internalname = "VEICULOPLACA";
         cmbVeiculoCor_Internalname = "VEICULOCOR";
         cmbVeiculoTipo_Internalname = "VEICULOTIPO";
         edtVeiculoMarca_Internalname = "VEICULOMARCA";
         edtVeiculoModelo_Internalname = "VEICULOMODELO";
         edtVeiculoAno_Internalname = "VEICULOANO";
         divRastreadores_Internalname = "RASTREADORES";
         Dvpanel_rastreadores_Internalname = "DVPANEL_RASTREADORES";
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
         Form.Caption = "Veículo";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Dvpanel_rastreadores_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_rastreadores_Iconposition = "Right";
         Dvpanel_rastreadores_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_rastreadores_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_rastreadores_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_rastreadores_Title = "Rastreadores";
         Dvpanel_rastreadores_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_rastreadores_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_rastreadores_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_rastreadores_Width = "100%";
         edtVeiculoAno_Jsonclick = "";
         edtVeiculoAno_Enabled = 1;
         edtVeiculoModelo_Jsonclick = "";
         edtVeiculoModelo_Enabled = 1;
         edtVeiculoMarca_Jsonclick = "";
         edtVeiculoMarca_Enabled = 1;
         cmbVeiculoTipo_Jsonclick = "";
         cmbVeiculoTipo.Enabled = 1;
         cmbVeiculoCor_Jsonclick = "";
         cmbVeiculoCor.Enabled = 1;
         edtVeiculoPlaca_Jsonclick = "";
         edtVeiculoPlaca_Enabled = 1;
         edtVeiculoGAMGUID_Jsonclick = "";
         edtVeiculoGAMGUID_Enabled = 0;
         edtVeiculoDataHoraCadastro_Jsonclick = "";
         edtVeiculoDataHoraCadastro_Enabled = 0;
         edtVeiculoId_Jsonclick = "";
         edtVeiculoId_Enabled = 0;
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

      protected void GX6ASAVEICULOGAMGUID0F16( short Gx_BScreen ,
                                               string Gx_mode )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A105VeiculoGAMGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A105VeiculoGAMGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A105VeiculoGAMGUID = GXt_char1;
            AssignAttri("", false, "A105VeiculoGAMGUID", A105VeiculoGAMGUID);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A105VeiculoGAMGUID))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_13_0F16( string Gx_mode ,
                                 int A98VeiculoId )
      {
         if ( IsIns( )  || IsUpd( )  )
         {
            new atualizarveiculorastreador(context ).execute(  A98VeiculoId) ;
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

      protected void XC_14_0F16( int AV7VeiculoId )
      {
         new desatrelartodosrastreadoresveiculo(context ).execute(  AV7VeiculoId) ;
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
         cmbVeiculoCor.Name = "VEICULOCOR";
         cmbVeiculoCor.WebTags = "";
         cmbVeiculoCor.addItem("", "Selecione", 0);
         cmbVeiculoCor.addItem("AMARELO", "AMARELO", 0);
         cmbVeiculoCor.addItem("AZUL", "AZUL", 0);
         cmbVeiculoCor.addItem("BEGE", "BEGE", 0);
         cmbVeiculoCor.addItem("BRANCO", "BRANCO", 0);
         cmbVeiculoCor.addItem("CINZA", "CINZA", 0);
         cmbVeiculoCor.addItem("DOURADO", "DOURADO", 0);
         cmbVeiculoCor.addItem("FANTASIA", "FANTASIA", 0);
         cmbVeiculoCor.addItem("GRENA", "GRENA", 0);
         cmbVeiculoCor.addItem("LARANJA", "LARANJA", 0);
         cmbVeiculoCor.addItem("MARROM", "MARROM", 0);
         cmbVeiculoCor.addItem("PRATA", "PRATA", 0);
         cmbVeiculoCor.addItem("PRETO", "PRETO", 0);
         cmbVeiculoCor.addItem("ROSA", "ROSA", 0);
         cmbVeiculoCor.addItem("ROXA", "ROXA", 0);
         cmbVeiculoCor.addItem("VERDE", "VERDE", 0);
         cmbVeiculoCor.addItem("VERMELHA", "VERMELHA", 0);
         if ( cmbVeiculoCor.ItemCount > 0 )
         {
            A97VeiculoCor = cmbVeiculoCor.getValidValue(A97VeiculoCor);
            AssignAttri("", false, "A97VeiculoCor", A97VeiculoCor);
         }
         cmbVeiculoTipo.Name = "VEICULOTIPO";
         cmbVeiculoTipo.WebTags = "";
         cmbVeiculoTipo.addItem("", "Selecione", 0);
         cmbVeiculoTipo.addItem("Carro", "Carro", 0);
         cmbVeiculoTipo.addItem("Moto", "Moto", 0);
         cmbVeiculoTipo.addItem("Caminhão", "Caminhão", 0);
         if ( cmbVeiculoTipo.ItemCount > 0 )
         {
            A101VeiculoTipo = cmbVeiculoTipo.getValidValue(A101VeiculoTipo);
            AssignAttri("", false, "A101VeiculoTipo", A101VeiculoTipo);
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

      public void Valid_Veiculoplaca( )
      {
         /* Using cursor T000F15 */
         pr_default.execute(13, new Object[] {A100VeiculoPlaca, A98VeiculoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Placa"}), 1, "VEICULOPLACA");
            AnyError = 1;
            GX_FocusControl = edtVeiculoPlaca_Internalname;
         }
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A100VeiculoPlaca)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Placa", "", "", "", "", "", "", "", ""), 1, "VEICULOPLACA");
            AnyError = 1;
            GX_FocusControl = edtVeiculoPlaca_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9',hsh:true},{av:'A98VeiculoId',fld:'VEICULOID',pic:'ZZZZZZZ9'},{av:'A99VeiculoDataHoraCadastro',fld:'VEICULODATAHORACADASTRO',pic:'99/99/99 99:99'},{av:'A105VeiculoGAMGUID',fld:'VEICULOGAMGUID',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120F2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_VEICULOID","{handler:'Valid_Veiculoid',iparms:[]");
         setEventMetadata("VALID_VEICULOID",",oparms:[]}");
         setEventMetadata("VALID_VEICULOPLACA","{handler:'Valid_Veiculoplaca',iparms:[{av:'A100VeiculoPlaca',fld:'VEICULOPLACA',pic:'@!'},{av:'A98VeiculoId',fld:'VEICULOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_VEICULOPLACA",",oparms:[]}");
         setEventMetadata("VALID_VEICULOCOR","{handler:'Valid_Veiculocor',iparms:[]");
         setEventMetadata("VALID_VEICULOCOR",",oparms:[]}");
         setEventMetadata("VALID_VEICULOTIPO","{handler:'Valid_Veiculotipo',iparms:[]");
         setEventMetadata("VALID_VEICULOTIPO",",oparms:[]}");
         setEventMetadata("VALID_VEICULOMARCA","{handler:'Valid_Veiculomarca',iparms:[]");
         setEventMetadata("VALID_VEICULOMARCA",",oparms:[]}");
         setEventMetadata("VALID_VEICULOMODELO","{handler:'Valid_Veiculomodelo',iparms:[]");
         setEventMetadata("VALID_VEICULOMODELO",",oparms:[]}");
         setEventMetadata("VALID_VEICULOANO","{handler:'Valid_Veiculoano',iparms:[]");
         setEventMetadata("VALID_VEICULOANO",",oparms:[]}");
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
         Z99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         Z105VeiculoGAMGUID = "";
         Z100VeiculoPlaca = "";
         Z97VeiculoCor = "";
         Z101VeiculoTipo = "";
         Z102VeiculoMarca = "";
         Z103VeiculoModelo = "";
         Z104VeiculoAno = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A97VeiculoCor = "";
         A101VeiculoTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         A105VeiculoGAMGUID = "";
         TempTags = "";
         A100VeiculoPlaca = "";
         A102VeiculoMarca = "";
         A103VeiculoModelo = "";
         A104VeiculoAno = "";
         ucDvpanel_rastreadores = new GXUserControl();
         WebComp_Wcassociationfrotaveiculo_Component = "";
         OldWcassociationfrotaveiculo = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_rastreadores_Objectcall = "";
         Dvpanel_rastreadores_Class = "";
         Dvpanel_rastreadores_Height = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode16 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000F4_A98VeiculoId = new int[1] ;
         T000F4_A99VeiculoDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         T000F4_A105VeiculoGAMGUID = new string[] {""} ;
         T000F4_A100VeiculoPlaca = new string[] {""} ;
         T000F4_A97VeiculoCor = new string[] {""} ;
         T000F4_A101VeiculoTipo = new string[] {""} ;
         T000F4_A102VeiculoMarca = new string[] {""} ;
         T000F4_A103VeiculoModelo = new string[] {""} ;
         T000F4_A104VeiculoAno = new string[] {""} ;
         T000F5_A100VeiculoPlaca = new string[] {""} ;
         T000F6_A98VeiculoId = new int[1] ;
         T000F3_A98VeiculoId = new int[1] ;
         T000F3_A99VeiculoDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         T000F3_A105VeiculoGAMGUID = new string[] {""} ;
         T000F3_A100VeiculoPlaca = new string[] {""} ;
         T000F3_A97VeiculoCor = new string[] {""} ;
         T000F3_A101VeiculoTipo = new string[] {""} ;
         T000F3_A102VeiculoMarca = new string[] {""} ;
         T000F3_A103VeiculoModelo = new string[] {""} ;
         T000F3_A104VeiculoAno = new string[] {""} ;
         T000F7_A98VeiculoId = new int[1] ;
         T000F8_A98VeiculoId = new int[1] ;
         T000F2_A98VeiculoId = new int[1] ;
         T000F2_A99VeiculoDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         T000F2_A105VeiculoGAMGUID = new string[] {""} ;
         T000F2_A100VeiculoPlaca = new string[] {""} ;
         T000F2_A97VeiculoCor = new string[] {""} ;
         T000F2_A101VeiculoTipo = new string[] {""} ;
         T000F2_A102VeiculoMarca = new string[] {""} ;
         T000F2_A103VeiculoModelo = new string[] {""} ;
         T000F2_A104VeiculoAno = new string[] {""} ;
         T000F9_A98VeiculoId = new int[1] ;
         T000F12_A98VeiculoId = new int[1] ;
         T000F12_A106RastreadorId = new int[1] ;
         T000F13_A93FrotaId = new int[1] ;
         T000F13_A98VeiculoId = new int[1] ;
         T000F14_A98VeiculoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         i105VeiculoGAMGUID = "";
         GXt_char1 = "";
         T000F15_A100VeiculoPlaca = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.veiculo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.veiculo__default(),
            new Object[][] {
                new Object[] {
               T000F2_A98VeiculoId, T000F2_A99VeiculoDataHoraCadastro, T000F2_A105VeiculoGAMGUID, T000F2_A100VeiculoPlaca, T000F2_A97VeiculoCor, T000F2_A101VeiculoTipo, T000F2_A102VeiculoMarca, T000F2_A103VeiculoModelo, T000F2_A104VeiculoAno
               }
               , new Object[] {
               T000F3_A98VeiculoId, T000F3_A99VeiculoDataHoraCadastro, T000F3_A105VeiculoGAMGUID, T000F3_A100VeiculoPlaca, T000F3_A97VeiculoCor, T000F3_A101VeiculoTipo, T000F3_A102VeiculoMarca, T000F3_A103VeiculoModelo, T000F3_A104VeiculoAno
               }
               , new Object[] {
               T000F4_A98VeiculoId, T000F4_A99VeiculoDataHoraCadastro, T000F4_A105VeiculoGAMGUID, T000F4_A100VeiculoPlaca, T000F4_A97VeiculoCor, T000F4_A101VeiculoTipo, T000F4_A102VeiculoMarca, T000F4_A103VeiculoModelo, T000F4_A104VeiculoAno
               }
               , new Object[] {
               T000F5_A100VeiculoPlaca
               }
               , new Object[] {
               T000F6_A98VeiculoId
               }
               , new Object[] {
               T000F7_A98VeiculoId
               }
               , new Object[] {
               T000F8_A98VeiculoId
               }
               , new Object[] {
               T000F9_A98VeiculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F12_A98VeiculoId, T000F12_A106RastreadorId
               }
               , new Object[] {
               T000F13_A93FrotaId, T000F13_A98VeiculoId
               }
               , new Object[] {
               T000F14_A98VeiculoId
               }
               , new Object[] {
               T000F15_A100VeiculoPlaca
               }
            }
         );
         WebComp_Wcassociationfrotaveiculo = new GeneXus.Http.GXNullWebComponent();
         Z105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         A105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         i105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         A99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         i99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
      }

      private short GxWebError ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound16 ;
      private short nCmpId ;
      private short GX_JID ;
      private short nIsDirty_16 ;
      private short gxajaxcallmode ;
      private int wcpOAV7VeiculoId ;
      private int Z98VeiculoId ;
      private int A98VeiculoId ;
      private int AV7VeiculoId ;
      private int trnEnded ;
      private int edtVeiculoId_Enabled ;
      private int edtVeiculoDataHoraCadastro_Enabled ;
      private int edtVeiculoGAMGUID_Enabled ;
      private int edtVeiculoPlaca_Enabled ;
      private int edtVeiculoMarca_Enabled ;
      private int edtVeiculoModelo_Enabled ;
      private int edtVeiculoAno_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_rastreadores_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z105VeiculoGAMGUID ;
      private string Z97VeiculoCor ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVeiculoPlaca_Internalname ;
      private string A97VeiculoCor ;
      private string cmbVeiculoCor_Internalname ;
      private string cmbVeiculoTipo_Internalname ;
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
      private string edtVeiculoId_Internalname ;
      private string edtVeiculoId_Jsonclick ;
      private string edtVeiculoDataHoraCadastro_Internalname ;
      private string edtVeiculoDataHoraCadastro_Jsonclick ;
      private string edtVeiculoGAMGUID_Internalname ;
      private string A105VeiculoGAMGUID ;
      private string edtVeiculoGAMGUID_Jsonclick ;
      private string TempTags ;
      private string edtVeiculoPlaca_Jsonclick ;
      private string cmbVeiculoCor_Jsonclick ;
      private string cmbVeiculoTipo_Jsonclick ;
      private string edtVeiculoMarca_Internalname ;
      private string edtVeiculoMarca_Jsonclick ;
      private string edtVeiculoModelo_Internalname ;
      private string edtVeiculoModelo_Jsonclick ;
      private string edtVeiculoAno_Internalname ;
      private string edtVeiculoAno_Jsonclick ;
      private string Dvpanel_rastreadores_Width ;
      private string Dvpanel_rastreadores_Cls ;
      private string Dvpanel_rastreadores_Title ;
      private string Dvpanel_rastreadores_Iconposition ;
      private string Dvpanel_rastreadores_Internalname ;
      private string divRastreadores_Internalname ;
      private string WebComp_Wcassociationfrotaveiculo_Component ;
      private string OldWcassociationfrotaveiculo ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Dvpanel_rastreadores_Objectcall ;
      private string Dvpanel_rastreadores_Class ;
      private string Dvpanel_rastreadores_Height ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode16 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i105VeiculoGAMGUID ;
      private string GXt_char1 ;
      private DateTime Z99VeiculoDataHoraCadastro ;
      private DateTime A99VeiculoDataHoraCadastro ;
      private DateTime i99VeiculoDataHoraCadastro ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_rastreadores_Autowidth ;
      private bool Dvpanel_rastreadores_Autoheight ;
      private bool Dvpanel_rastreadores_Collapsible ;
      private bool Dvpanel_rastreadores_Collapsed ;
      private bool Dvpanel_rastreadores_Showcollapseicon ;
      private bool Dvpanel_rastreadores_Autoscroll ;
      private bool Dvpanel_rastreadores_Enabled ;
      private bool Dvpanel_rastreadores_Showheader ;
      private bool Dvpanel_rastreadores_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool bDynCreated_Wcassociationfrotaveiculo ;
      private bool Gx_longc ;
      private string Z100VeiculoPlaca ;
      private string Z101VeiculoTipo ;
      private string Z102VeiculoMarca ;
      private string Z103VeiculoModelo ;
      private string Z104VeiculoAno ;
      private string A101VeiculoTipo ;
      private string A100VeiculoPlaca ;
      private string A102VeiculoMarca ;
      private string A103VeiculoModelo ;
      private string A104VeiculoAno ;
      private IGxSession AV12WebSession ;
      private GXWebComponent WebComp_Wcassociationfrotaveiculo ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_rastreadores ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVeiculoCor ;
      private GXCombobox cmbVeiculoTipo ;
      private IDataStoreProvider pr_default ;
      private int[] T000F4_A98VeiculoId ;
      private DateTime[] T000F4_A99VeiculoDataHoraCadastro ;
      private string[] T000F4_A105VeiculoGAMGUID ;
      private string[] T000F4_A100VeiculoPlaca ;
      private string[] T000F4_A97VeiculoCor ;
      private string[] T000F4_A101VeiculoTipo ;
      private string[] T000F4_A102VeiculoMarca ;
      private string[] T000F4_A103VeiculoModelo ;
      private string[] T000F4_A104VeiculoAno ;
      private string[] T000F5_A100VeiculoPlaca ;
      private int[] T000F6_A98VeiculoId ;
      private int[] T000F3_A98VeiculoId ;
      private DateTime[] T000F3_A99VeiculoDataHoraCadastro ;
      private string[] T000F3_A105VeiculoGAMGUID ;
      private string[] T000F3_A100VeiculoPlaca ;
      private string[] T000F3_A97VeiculoCor ;
      private string[] T000F3_A101VeiculoTipo ;
      private string[] T000F3_A102VeiculoMarca ;
      private string[] T000F3_A103VeiculoModelo ;
      private string[] T000F3_A104VeiculoAno ;
      private int[] T000F7_A98VeiculoId ;
      private int[] T000F8_A98VeiculoId ;
      private int[] T000F2_A98VeiculoId ;
      private DateTime[] T000F2_A99VeiculoDataHoraCadastro ;
      private string[] T000F2_A105VeiculoGAMGUID ;
      private string[] T000F2_A100VeiculoPlaca ;
      private string[] T000F2_A97VeiculoCor ;
      private string[] T000F2_A101VeiculoTipo ;
      private string[] T000F2_A102VeiculoMarca ;
      private string[] T000F2_A103VeiculoModelo ;
      private string[] T000F2_A104VeiculoAno ;
      private int[] T000F9_A98VeiculoId ;
      private int[] T000F12_A98VeiculoId ;
      private int[] T000F12_A106RastreadorId ;
      private int[] T000F13_A93FrotaId ;
      private int[] T000F13_A98VeiculoId ;
      private int[] T000F14_A98VeiculoId ;
      private string[] T000F15_A100VeiculoPlaca ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class veiculo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class veiculo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000F4;
        prmT000F4 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F5;
        prmT000F5 = new Object[] {
        new Object[] {"@VeiculoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F6;
        prmT000F6 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F3;
        prmT000F3 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F7;
        prmT000F7 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F8;
        prmT000F8 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F2;
        prmT000F2 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F9;
        prmT000F9 = new Object[] {
        new Object[] {"@VeiculoDataHoraCadastro",SqlDbType.DateTime,8,5} ,
        new Object[] {"@VeiculoGAMGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@VeiculoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@VeiculoCor",SqlDbType.NChar,20,0} ,
        new Object[] {"@VeiculoTipo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoMarca",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoModelo",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@VeiculoAno",SqlDbType.NVarChar,10,0}
        };
        Object[] prmT000F10;
        prmT000F10 = new Object[] {
        new Object[] {"@VeiculoDataHoraCadastro",SqlDbType.DateTime,8,5} ,
        new Object[] {"@VeiculoGAMGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@VeiculoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@VeiculoCor",SqlDbType.NChar,20,0} ,
        new Object[] {"@VeiculoTipo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoMarca",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoModelo",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@VeiculoAno",SqlDbType.NVarChar,10,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F11;
        prmT000F11 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F12;
        prmT000F12 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F13;
        prmT000F13 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000F14;
        prmT000F14 = new Object[] {
        };
        Object[] prmT000F15;
        prmT000F15 = new Object[] {
        new Object[] {"@VeiculoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000F2", "SELECT [VeiculoId], [VeiculoDataHoraCadastro], [VeiculoGAMGUID], [VeiculoPlaca], [VeiculoCor], [VeiculoTipo], [VeiculoMarca], [VeiculoModelo], [VeiculoAno] FROM [Veiculo] WITH (UPDLOCK) WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F3", "SELECT [VeiculoId], [VeiculoDataHoraCadastro], [VeiculoGAMGUID], [VeiculoPlaca], [VeiculoCor], [VeiculoTipo], [VeiculoMarca], [VeiculoModelo], [VeiculoAno] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F4", "SELECT TM1.[VeiculoId], TM1.[VeiculoDataHoraCadastro], TM1.[VeiculoGAMGUID], TM1.[VeiculoPlaca], TM1.[VeiculoCor], TM1.[VeiculoTipo], TM1.[VeiculoMarca], TM1.[VeiculoModelo], TM1.[VeiculoAno] FROM [Veiculo] TM1 WHERE TM1.[VeiculoId] = @VeiculoId ORDER BY TM1.[VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F5", "SELECT [VeiculoPlaca] FROM [Veiculo] WHERE ([VeiculoPlaca] = @VeiculoPlaca) AND (Not ( [VeiculoId] = @VeiculoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F6", "SELECT [VeiculoId] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F7", "SELECT TOP 1 [VeiculoId] FROM [Veiculo] WHERE ( [VeiculoId] > @VeiculoId) ORDER BY [VeiculoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F8", "SELECT TOP 1 [VeiculoId] FROM [Veiculo] WHERE ( [VeiculoId] < @VeiculoId) ORDER BY [VeiculoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F9", "INSERT INTO [Veiculo]([VeiculoDataHoraCadastro], [VeiculoGAMGUID], [VeiculoPlaca], [VeiculoCor], [VeiculoTipo], [VeiculoMarca], [VeiculoModelo], [VeiculoAno]) VALUES(@VeiculoDataHoraCadastro, @VeiculoGAMGUID, @VeiculoPlaca, @VeiculoCor, @VeiculoTipo, @VeiculoMarca, @VeiculoModelo, @VeiculoAno); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000F9)
           ,new CursorDef("T000F10", "UPDATE [Veiculo] SET [VeiculoDataHoraCadastro]=@VeiculoDataHoraCadastro, [VeiculoGAMGUID]=@VeiculoGAMGUID, [VeiculoPlaca]=@VeiculoPlaca, [VeiculoCor]=@VeiculoCor, [VeiculoTipo]=@VeiculoTipo, [VeiculoMarca]=@VeiculoMarca, [VeiculoModelo]=@VeiculoModelo, [VeiculoAno]=@VeiculoAno  WHERE [VeiculoId] = @VeiculoId", GxErrorMask.GX_NOMASK,prmT000F10)
           ,new CursorDef("T000F11", "DELETE FROM [Veiculo]  WHERE [VeiculoId] = @VeiculoId", GxErrorMask.GX_NOMASK,prmT000F11)
           ,new CursorDef("T000F12", "SELECT TOP 1 [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F13", "SELECT TOP 1 [FrotaId], [VeiculoId] FROM [FrotaVeiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F14", "SELECT [VeiculoId] FROM [Veiculo] ORDER BY [VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F15", "SELECT [VeiculoPlaca] FROM [Veiculo] WHERE ([VeiculoPlaca] = @VeiculoPlaca) AND (Not ( [VeiculoId] = @VeiculoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F15,1, GxCacheFrequency.OFF ,true,false )
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
              table[4][0] = rslt.getString(5, 20);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 20);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 20);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
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
              table[1][0] = rslt.getInt(2);
              return;
           case 11 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 12 :
              table[0][0] = rslt.getInt(1);
              return;
           case 13 :
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
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              return;
           case 8 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (int)parms[8]);
              return;
           case 9 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 13 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
