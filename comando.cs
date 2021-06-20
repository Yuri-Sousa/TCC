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
   public class comando : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
               AV7ComandoId = (int)(NumberUtil.Val( GetPar( "ComandoId"), "."));
               AssignAttri("", false, "AV7ComandoId", StringUtil.LTrimStr( (decimal)(AV7ComandoId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCOMANDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComandoId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Comando", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtComandoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public comando( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public comando( IGxContext context )
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
                           int aP1_ComandoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ComandoId = aP1_ComandoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbComandoFabricanteModulo = new GXCombobox();
         cmbComandoModeloModulo = new GXCombobox();
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
            return "comando_Execute" ;
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
         if ( cmbComandoFabricanteModulo.ItemCount > 0 )
         {
            A140ComandoFabricanteModulo = cmbComandoFabricanteModulo.getValidValue(A140ComandoFabricanteModulo);
            AssignAttri("", false, "A140ComandoFabricanteModulo", A140ComandoFabricanteModulo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbComandoFabricanteModulo.CurrentValue = StringUtil.RTrim( A140ComandoFabricanteModulo);
            AssignProp("", false, cmbComandoFabricanteModulo_Internalname, "Values", cmbComandoFabricanteModulo.ToJavascriptSource(), true);
         }
         if ( cmbComandoModeloModulo.ItemCount > 0 )
         {
            A141ComandoModeloModulo = cmbComandoModeloModulo.getValidValue(A141ComandoModeloModulo);
            AssignAttri("", false, "A141ComandoModeloModulo", A141ComandoModeloModulo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbComandoModeloModulo.CurrentValue = StringUtil.RTrim( A141ComandoModeloModulo);
            AssignProp("", false, cmbComandoModeloModulo_Internalname, "Values", cmbComandoModeloModulo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtComandoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137ComandoId), 8, 0, ",", "")), ((edtComandoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A137ComandoId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A137ComandoId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComandoId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Comando.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoNome_Internalname, "Nome", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComandoNome_Internalname, A138ComandoNome, StringUtil.RTrim( context.localUtil.Format( A138ComandoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComandoNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Comando.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoDescricao_Internalname, "Descrição", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComandoDescricao_Internalname, A139ComandoDescricao, StringUtil.RTrim( context.localUtil.Format( A139ComandoDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoDescricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComandoDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Comando.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbComandoFabricanteModulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbComandoFabricanteModulo_Internalname, "Fabricante", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbComandoFabricanteModulo, cmbComandoFabricanteModulo_Internalname, StringUtil.RTrim( A140ComandoFabricanteModulo), 1, cmbComandoFabricanteModulo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbComandoFabricanteModulo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, "HLP_Comando.htm");
         cmbComandoFabricanteModulo.CurrentValue = StringUtil.RTrim( A140ComandoFabricanteModulo);
         AssignProp("", false, cmbComandoFabricanteModulo_Internalname, "Values", (string)(cmbComandoFabricanteModulo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbComandoModeloModulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbComandoModeloModulo_Internalname, "Modelo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbComandoModeloModulo, cmbComandoModeloModulo_Internalname, StringUtil.RTrim( A141ComandoModeloModulo), 1, cmbComandoModeloModulo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbComandoModeloModulo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "", true, "HLP_Comando.htm");
         cmbComandoModeloModulo.CurrentValue = StringUtil.RTrim( A141ComandoModeloModulo);
         AssignProp("", false, cmbComandoModeloModulo_Internalname, "Values", (string)(cmbComandoModeloModulo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoParameter_Id_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoParameter_Id_Internalname, "Parameter_id", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComandoParameter_Id_Internalname, A143ComandoParameter_Id, StringUtil.RTrim( context.localUtil.Format( A143ComandoParameter_Id, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComandoParameter_Id_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComandoParameter_Id_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Comando.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComandoPayload_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComandoPayload_Internalname, "Comando", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtComandoPayload_Internalname, A142ComandoPayload, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtComandoPayload_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Comando.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comando.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comando.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comando.htm");
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
         E110M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z137ComandoId = (int)(context.localUtil.CToN( cgiGet( "Z137ComandoId"), ",", "."));
               Z138ComandoNome = cgiGet( "Z138ComandoNome");
               Z139ComandoDescricao = cgiGet( "Z139ComandoDescricao");
               Z140ComandoFabricanteModulo = cgiGet( "Z140ComandoFabricanteModulo");
               Z141ComandoModeloModulo = cgiGet( "Z141ComandoModeloModulo");
               Z143ComandoParameter_Id = cgiGet( "Z143ComandoParameter_Id");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7ComandoId = (int)(context.localUtil.CToN( cgiGet( "vCOMANDOID"), ",", "."));
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
               A137ComandoId = (int)(context.localUtil.CToN( cgiGet( edtComandoId_Internalname), ",", "."));
               AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
               A138ComandoNome = cgiGet( edtComandoNome_Internalname);
               AssignAttri("", false, "A138ComandoNome", A138ComandoNome);
               A139ComandoDescricao = cgiGet( edtComandoDescricao_Internalname);
               AssignAttri("", false, "A139ComandoDescricao", A139ComandoDescricao);
               cmbComandoFabricanteModulo.CurrentValue = cgiGet( cmbComandoFabricanteModulo_Internalname);
               A140ComandoFabricanteModulo = cgiGet( cmbComandoFabricanteModulo_Internalname);
               AssignAttri("", false, "A140ComandoFabricanteModulo", A140ComandoFabricanteModulo);
               cmbComandoModeloModulo.CurrentValue = cgiGet( cmbComandoModeloModulo_Internalname);
               A141ComandoModeloModulo = cgiGet( cmbComandoModeloModulo_Internalname);
               AssignAttri("", false, "A141ComandoModeloModulo", A141ComandoModeloModulo);
               A143ComandoParameter_Id = cgiGet( edtComandoParameter_Id_Internalname);
               AssignAttri("", false, "A143ComandoParameter_Id", A143ComandoParameter_Id);
               A142ComandoPayload = cgiGet( edtComandoPayload_Internalname);
               AssignAttri("", false, "A142ComandoPayload", A142ComandoPayload);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Comando");
               A137ComandoId = (int)(context.localUtil.CToN( cgiGet( edtComandoId_Internalname), ",", "."));
               AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
               forbiddenHiddens.Add("ComandoId", context.localUtil.Format( (decimal)(A137ComandoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A137ComandoId != Z137ComandoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("comando:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A137ComandoId = (int)(NumberUtil.Val( GetPar( "ComandoId"), "."));
                  AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
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
                     sMode23 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode23;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound23 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COMANDOID");
                        AnyError = 1;
                        GX_FocusControl = edtComandoId_Internalname;
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
                           E110M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120M2 ();
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
            E120M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0M23( ) ;
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
            DisableAttributes0M23( ) ;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M23( ) ;
            }
            else
            {
               CheckExtendedTable0M23( ) ;
               CloseExtendedTableCursors0M23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0M0( )
      {
      }

      protected void E110M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E120M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("comandoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0M23( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z138ComandoNome = T000M3_A138ComandoNome[0];
               Z139ComandoDescricao = T000M3_A139ComandoDescricao[0];
               Z140ComandoFabricanteModulo = T000M3_A140ComandoFabricanteModulo[0];
               Z141ComandoModeloModulo = T000M3_A141ComandoModeloModulo[0];
               Z143ComandoParameter_Id = T000M3_A143ComandoParameter_Id[0];
            }
            else
            {
               Z138ComandoNome = A138ComandoNome;
               Z139ComandoDescricao = A139ComandoDescricao;
               Z140ComandoFabricanteModulo = A140ComandoFabricanteModulo;
               Z141ComandoModeloModulo = A141ComandoModeloModulo;
               Z143ComandoParameter_Id = A143ComandoParameter_Id;
            }
         }
         if ( GX_JID == -10 )
         {
            Z137ComandoId = A137ComandoId;
            Z138ComandoNome = A138ComandoNome;
            Z139ComandoDescricao = A139ComandoDescricao;
            Z140ComandoFabricanteModulo = A140ComandoFabricanteModulo;
            Z141ComandoModeloModulo = A141ComandoModeloModulo;
            Z142ComandoPayload = A142ComandoPayload;
            Z143ComandoParameter_Id = A143ComandoParameter_Id;
         }
      }

      protected void standaloneNotModal( )
      {
         edtComandoId_Enabled = 0;
         AssignProp("", false, edtComandoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoId_Enabled), 5, 0), true);
         edtComandoId_Enabled = 0;
         AssignProp("", false, edtComandoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ComandoId) )
         {
            A137ComandoId = AV7ComandoId;
            AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
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
      }

      protected void Load0M23( )
      {
         /* Using cursor T000M4 */
         pr_default.execute(2, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A138ComandoNome = T000M4_A138ComandoNome[0];
            AssignAttri("", false, "A138ComandoNome", A138ComandoNome);
            A139ComandoDescricao = T000M4_A139ComandoDescricao[0];
            AssignAttri("", false, "A139ComandoDescricao", A139ComandoDescricao);
            A140ComandoFabricanteModulo = T000M4_A140ComandoFabricanteModulo[0];
            AssignAttri("", false, "A140ComandoFabricanteModulo", A140ComandoFabricanteModulo);
            A141ComandoModeloModulo = T000M4_A141ComandoModeloModulo[0];
            AssignAttri("", false, "A141ComandoModeloModulo", A141ComandoModeloModulo);
            A142ComandoPayload = T000M4_A142ComandoPayload[0];
            AssignAttri("", false, "A142ComandoPayload", A142ComandoPayload);
            A143ComandoParameter_Id = T000M4_A143ComandoParameter_Id[0];
            AssignAttri("", false, "A143ComandoParameter_Id", A143ComandoParameter_Id);
            ZM0M23( -10) ;
         }
         pr_default.close(2);
         OnLoadActions0M23( ) ;
      }

      protected void OnLoadActions0M23( )
      {
      }

      protected void CheckExtendedTable0M23( )
      {
         nIsDirty_23 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A138ComandoNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""), 1, "COMANDONOME");
            AnyError = 1;
            GX_FocusControl = edtComandoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A139ComandoDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "COMANDODESCRICAO");
            AnyError = 1;
            GX_FocusControl = edtComandoDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A140ComandoFabricanteModulo, "Maxtrack") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Fabricante fora do intervalo", "OutOfRange", 1, "COMANDOFABRICANTEMODULO");
            AnyError = 1;
            GX_FocusControl = cmbComandoFabricanteModulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A141ComandoModeloModulo, "MXT140") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Modelo fora do intervalo", "OutOfRange", 1, "COMANDOMODELOMODULO");
            AnyError = 1;
            GX_FocusControl = cmbComandoModeloModulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141ComandoModeloModulo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Modelo", "", "", "", "", "", "", "", ""), 1, "COMANDOMODELOMODULO");
            AnyError = 1;
            GX_FocusControl = cmbComandoModeloModulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A142ComandoPayload)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Comando", "", "", "", "", "", "", "", ""), 1, "COMANDOPAYLOAD");
            AnyError = 1;
            GX_FocusControl = edtComandoPayload_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A143ComandoParameter_Id)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parameter_id", "", "", "", "", "", "", "", ""), 1, "COMANDOPARAMETER_ID");
            AnyError = 1;
            GX_FocusControl = edtComandoParameter_Id_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0M23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M23( )
      {
         /* Using cursor T000M5 */
         pr_default.execute(3, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000M3 */
         pr_default.execute(1, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M23( 10) ;
            RcdFound23 = 1;
            A137ComandoId = T000M3_A137ComandoId[0];
            AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
            A138ComandoNome = T000M3_A138ComandoNome[0];
            AssignAttri("", false, "A138ComandoNome", A138ComandoNome);
            A139ComandoDescricao = T000M3_A139ComandoDescricao[0];
            AssignAttri("", false, "A139ComandoDescricao", A139ComandoDescricao);
            A140ComandoFabricanteModulo = T000M3_A140ComandoFabricanteModulo[0];
            AssignAttri("", false, "A140ComandoFabricanteModulo", A140ComandoFabricanteModulo);
            A141ComandoModeloModulo = T000M3_A141ComandoModeloModulo[0];
            AssignAttri("", false, "A141ComandoModeloModulo", A141ComandoModeloModulo);
            A142ComandoPayload = T000M3_A142ComandoPayload[0];
            AssignAttri("", false, "A142ComandoPayload", A142ComandoPayload);
            A143ComandoParameter_Id = T000M3_A143ComandoParameter_Id[0];
            AssignAttri("", false, "A143ComandoParameter_Id", A143ComandoParameter_Id);
            Z137ComandoId = A137ComandoId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0M23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0M23( ) ;
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0M23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M23( ) ;
         if ( RcdFound23 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound23 = 0;
         /* Using cursor T000M6 */
         pr_default.execute(4, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000M6_A137ComandoId[0] < A137ComandoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000M6_A137ComandoId[0] > A137ComandoId ) ) )
            {
               A137ComandoId = T000M6_A137ComandoId[0];
               AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound23 = 0;
         /* Using cursor T000M7 */
         pr_default.execute(5, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A137ComandoId[0] > A137ComandoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A137ComandoId[0] < A137ComandoId ) ) )
            {
               A137ComandoId = T000M7_A137ComandoId[0];
               AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0M23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtComandoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0M23( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( A137ComandoId != Z137ComandoId )
               {
                  A137ComandoId = Z137ComandoId;
                  AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COMANDOID");
                  AnyError = 1;
                  GX_FocusControl = edtComandoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtComandoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0M23( ) ;
                  GX_FocusControl = edtComandoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A137ComandoId != Z137ComandoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtComandoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0M23( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COMANDOID");
                     AnyError = 1;
                     GX_FocusControl = edtComandoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtComandoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0M23( ) ;
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
         if ( A137ComandoId != Z137ComandoId )
         {
            A137ComandoId = Z137ComandoId;
            AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COMANDOID");
            AnyError = 1;
            GX_FocusControl = edtComandoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtComandoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0M23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M2 */
            pr_default.execute(0, new Object[] {A137ComandoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comando"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z138ComandoNome, T000M2_A138ComandoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z139ComandoDescricao, T000M2_A139ComandoDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z140ComandoFabricanteModulo, T000M2_A140ComandoFabricanteModulo[0]) != 0 ) || ( StringUtil.StrCmp(Z141ComandoModeloModulo, T000M2_A141ComandoModeloModulo[0]) != 0 ) || ( StringUtil.StrCmp(Z143ComandoParameter_Id, T000M2_A143ComandoParameter_Id[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z138ComandoNome, T000M2_A138ComandoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("comando:[seudo value changed for attri]"+"ComandoNome");
                  GXUtil.WriteLogRaw("Old: ",Z138ComandoNome);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A138ComandoNome[0]);
               }
               if ( StringUtil.StrCmp(Z139ComandoDescricao, T000M2_A139ComandoDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("comando:[seudo value changed for attri]"+"ComandoDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z139ComandoDescricao);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A139ComandoDescricao[0]);
               }
               if ( StringUtil.StrCmp(Z140ComandoFabricanteModulo, T000M2_A140ComandoFabricanteModulo[0]) != 0 )
               {
                  GXUtil.WriteLog("comando:[seudo value changed for attri]"+"ComandoFabricanteModulo");
                  GXUtil.WriteLogRaw("Old: ",Z140ComandoFabricanteModulo);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A140ComandoFabricanteModulo[0]);
               }
               if ( StringUtil.StrCmp(Z141ComandoModeloModulo, T000M2_A141ComandoModeloModulo[0]) != 0 )
               {
                  GXUtil.WriteLog("comando:[seudo value changed for attri]"+"ComandoModeloModulo");
                  GXUtil.WriteLogRaw("Old: ",Z141ComandoModeloModulo);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A141ComandoModeloModulo[0]);
               }
               if ( StringUtil.StrCmp(Z143ComandoParameter_Id, T000M2_A143ComandoParameter_Id[0]) != 0 )
               {
                  GXUtil.WriteLog("comando:[seudo value changed for attri]"+"ComandoParameter_Id");
                  GXUtil.WriteLogRaw("Old: ",Z143ComandoParameter_Id);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A143ComandoParameter_Id[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Comando"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M23( )
      {
         if ( ! IsAuthorized("comando_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M23( 0) ;
            CheckOptimisticConcurrency0M23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M8 */
                     pr_default.execute(6, new Object[] {A138ComandoNome, A139ComandoDescricao, A140ComandoFabricanteModulo, A141ComandoModeloModulo, A142ComandoPayload, A143ComandoParameter_Id});
                     A137ComandoId = T000M8_A137ComandoId[0];
                     AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Comando");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0M0( ) ;
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
               Load0M23( ) ;
            }
            EndLevel0M23( ) ;
         }
         CloseExtendedTableCursors0M23( ) ;
      }

      protected void Update0M23( )
      {
         if ( ! IsAuthorized("comando_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M9 */
                     pr_default.execute(7, new Object[] {A138ComandoNome, A139ComandoDescricao, A140ComandoFabricanteModulo, A141ComandoModeloModulo, A142ComandoPayload, A143ComandoParameter_Id, A137ComandoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Comando");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comando"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M23( ) ;
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
            EndLevel0M23( ) ;
         }
         CloseExtendedTableCursors0M23( ) ;
      }

      protected void DeferredUpdate0M23( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("comando_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M23( ) ;
            AfterConfirm0M23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000M10 */
                  pr_default.execute(8, new Object[] {A137ComandoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Comando");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0M23( ) ;
         Gx_mode = sMode23;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M23( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0M23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("comando",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("comando",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0M23( )
      {
         /* Scan By routine */
         /* Using cursor T000M11 */
         pr_default.execute(9);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound23 = 1;
            A137ComandoId = T000M11_A137ComandoId[0];
            AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M23( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound23 = 1;
            A137ComandoId = T000M11_A137ComandoId[0];
            AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
         }
      }

      protected void ScanEnd0M23( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0M23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M23( )
      {
         edtComandoId_Enabled = 0;
         AssignProp("", false, edtComandoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoId_Enabled), 5, 0), true);
         edtComandoNome_Enabled = 0;
         AssignProp("", false, edtComandoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoNome_Enabled), 5, 0), true);
         edtComandoDescricao_Enabled = 0;
         AssignProp("", false, edtComandoDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoDescricao_Enabled), 5, 0), true);
         cmbComandoFabricanteModulo.Enabled = 0;
         AssignProp("", false, cmbComandoFabricanteModulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComandoFabricanteModulo.Enabled), 5, 0), true);
         cmbComandoModeloModulo.Enabled = 0;
         AssignProp("", false, cmbComandoModeloModulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComandoModeloModulo.Enabled), 5, 0), true);
         edtComandoParameter_Id_Enabled = 0;
         AssignProp("", false, edtComandoParameter_Id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoParameter_Id_Enabled), 5, 0), true);
         edtComandoPayload_Enabled = 0;
         AssignProp("", false, edtComandoPayload_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComandoPayload_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0M23( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0M0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815493114", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comando.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ComandoId,8,0))}, new string[] {"Gx_mode","ComandoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Comando");
         forbiddenHiddens.Add("ComandoId", context.localUtil.Format( (decimal)(A137ComandoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("comando:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z137ComandoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137ComandoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z138ComandoNome", Z138ComandoNome);
         GxWebStd.gx_hidden_field( context, "Z139ComandoDescricao", Z139ComandoDescricao);
         GxWebStd.gx_hidden_field( context, "Z140ComandoFabricanteModulo", Z140ComandoFabricanteModulo);
         GxWebStd.gx_hidden_field( context, "Z141ComandoModeloModulo", Z141ComandoModeloModulo);
         GxWebStd.gx_hidden_field( context, "Z143ComandoParameter_Id", Z143ComandoParameter_Id);
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
         GxWebStd.gx_hidden_field( context, "vCOMANDOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComandoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMANDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComandoId), "ZZZZZZZ9"), context));
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
         return formatLink("comando.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ComandoId,8,0))}, new string[] {"Gx_mode","ComandoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Comando" ;
      }

      public override string GetPgmdesc( )
      {
         return "Comando" ;
      }

      protected void InitializeNonKey0M23( )
      {
         A138ComandoNome = "";
         AssignAttri("", false, "A138ComandoNome", A138ComandoNome);
         A139ComandoDescricao = "";
         AssignAttri("", false, "A139ComandoDescricao", A139ComandoDescricao);
         A140ComandoFabricanteModulo = "";
         AssignAttri("", false, "A140ComandoFabricanteModulo", A140ComandoFabricanteModulo);
         A141ComandoModeloModulo = "";
         AssignAttri("", false, "A141ComandoModeloModulo", A141ComandoModeloModulo);
         A142ComandoPayload = "";
         AssignAttri("", false, "A142ComandoPayload", A142ComandoPayload);
         A143ComandoParameter_Id = "";
         AssignAttri("", false, "A143ComandoParameter_Id", A143ComandoParameter_Id);
         Z138ComandoNome = "";
         Z139ComandoDescricao = "";
         Z140ComandoFabricanteModulo = "";
         Z141ComandoModeloModulo = "";
         Z143ComandoParameter_Id = "";
      }

      protected void InitAll0M23( )
      {
         A137ComandoId = 0;
         AssignAttri("", false, "A137ComandoId", StringUtil.LTrimStr( (decimal)(A137ComandoId), 8, 0));
         InitializeNonKey0M23( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815493144", true, true);
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
         context.AddJavascriptSource("comando.js", "?202142815493145", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtComandoId_Internalname = "COMANDOID";
         edtComandoNome_Internalname = "COMANDONOME";
         edtComandoDescricao_Internalname = "COMANDODESCRICAO";
         cmbComandoFabricanteModulo_Internalname = "COMANDOFABRICANTEMODULO";
         cmbComandoModeloModulo_Internalname = "COMANDOMODELOMODULO";
         edtComandoParameter_Id_Internalname = "COMANDOPARAMETER_ID";
         edtComandoPayload_Internalname = "COMANDOPAYLOAD";
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
         Form.Caption = "Comando";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtComandoPayload_Enabled = 1;
         edtComandoParameter_Id_Jsonclick = "";
         edtComandoParameter_Id_Enabled = 1;
         cmbComandoModeloModulo_Jsonclick = "";
         cmbComandoModeloModulo.Enabled = 1;
         cmbComandoFabricanteModulo_Jsonclick = "";
         cmbComandoFabricanteModulo.Enabled = 1;
         edtComandoDescricao_Jsonclick = "";
         edtComandoDescricao_Enabled = 1;
         edtComandoNome_Jsonclick = "";
         edtComandoNome_Enabled = 1;
         edtComandoId_Jsonclick = "";
         edtComandoId_Enabled = 0;
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

      protected void init_web_controls( )
      {
         cmbComandoFabricanteModulo.Name = "COMANDOFABRICANTEMODULO";
         cmbComandoFabricanteModulo.WebTags = "";
         cmbComandoFabricanteModulo.addItem("", "Selecione", 0);
         cmbComandoFabricanteModulo.addItem("Maxtrack", "Maxtrack", 0);
         if ( cmbComandoFabricanteModulo.ItemCount > 0 )
         {
            A140ComandoFabricanteModulo = cmbComandoFabricanteModulo.getValidValue(A140ComandoFabricanteModulo);
            AssignAttri("", false, "A140ComandoFabricanteModulo", A140ComandoFabricanteModulo);
         }
         cmbComandoModeloModulo.Name = "COMANDOMODELOMODULO";
         cmbComandoModeloModulo.WebTags = "";
         cmbComandoModeloModulo.addItem("", "Selecione", 0);
         cmbComandoModeloModulo.addItem("MXT140", "MXT140", 0);
         if ( cmbComandoModeloModulo.ItemCount > 0 )
         {
            A141ComandoModeloModulo = cmbComandoModeloModulo.getValidValue(A141ComandoModeloModulo);
            AssignAttri("", false, "A141ComandoModeloModulo", A141ComandoModeloModulo);
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ComandoId',fld:'vCOMANDOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ComandoId',fld:'vCOMANDOID',pic:'ZZZZZZZ9',hsh:true},{av:'A137ComandoId',fld:'COMANDOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120M2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_COMANDOID","{handler:'Valid_Comandoid',iparms:[]");
         setEventMetadata("VALID_COMANDOID",",oparms:[]}");
         setEventMetadata("VALID_COMANDONOME","{handler:'Valid_Comandonome',iparms:[]");
         setEventMetadata("VALID_COMANDONOME",",oparms:[]}");
         setEventMetadata("VALID_COMANDODESCRICAO","{handler:'Valid_Comandodescricao',iparms:[]");
         setEventMetadata("VALID_COMANDODESCRICAO",",oparms:[]}");
         setEventMetadata("VALID_COMANDOFABRICANTEMODULO","{handler:'Valid_Comandofabricantemodulo',iparms:[]");
         setEventMetadata("VALID_COMANDOFABRICANTEMODULO",",oparms:[]}");
         setEventMetadata("VALID_COMANDOMODELOMODULO","{handler:'Valid_Comandomodelomodulo',iparms:[]");
         setEventMetadata("VALID_COMANDOMODELOMODULO",",oparms:[]}");
         setEventMetadata("VALID_COMANDOPARAMETER_ID","{handler:'Valid_Comandoparameter_id',iparms:[]");
         setEventMetadata("VALID_COMANDOPARAMETER_ID",",oparms:[]}");
         setEventMetadata("VALID_COMANDOPAYLOAD","{handler:'Valid_Comandopayload',iparms:[]");
         setEventMetadata("VALID_COMANDOPAYLOAD",",oparms:[]}");
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
         Z138ComandoNome = "";
         Z139ComandoDescricao = "";
         Z140ComandoFabricanteModulo = "";
         Z141ComandoModeloModulo = "";
         Z143ComandoParameter_Id = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A140ComandoFabricanteModulo = "";
         A141ComandoModeloModulo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A138ComandoNome = "";
         A139ComandoDescricao = "";
         A143ComandoParameter_Id = "";
         A142ComandoPayload = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode23 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z142ComandoPayload = "";
         T000M4_A137ComandoId = new int[1] ;
         T000M4_A138ComandoNome = new string[] {""} ;
         T000M4_A139ComandoDescricao = new string[] {""} ;
         T000M4_A140ComandoFabricanteModulo = new string[] {""} ;
         T000M4_A141ComandoModeloModulo = new string[] {""} ;
         T000M4_A142ComandoPayload = new string[] {""} ;
         T000M4_A143ComandoParameter_Id = new string[] {""} ;
         T000M5_A137ComandoId = new int[1] ;
         T000M3_A137ComandoId = new int[1] ;
         T000M3_A138ComandoNome = new string[] {""} ;
         T000M3_A139ComandoDescricao = new string[] {""} ;
         T000M3_A140ComandoFabricanteModulo = new string[] {""} ;
         T000M3_A141ComandoModeloModulo = new string[] {""} ;
         T000M3_A142ComandoPayload = new string[] {""} ;
         T000M3_A143ComandoParameter_Id = new string[] {""} ;
         T000M6_A137ComandoId = new int[1] ;
         T000M7_A137ComandoId = new int[1] ;
         T000M2_A137ComandoId = new int[1] ;
         T000M2_A138ComandoNome = new string[] {""} ;
         T000M2_A139ComandoDescricao = new string[] {""} ;
         T000M2_A140ComandoFabricanteModulo = new string[] {""} ;
         T000M2_A141ComandoModeloModulo = new string[] {""} ;
         T000M2_A142ComandoPayload = new string[] {""} ;
         T000M2_A143ComandoParameter_Id = new string[] {""} ;
         T000M8_A137ComandoId = new int[1] ;
         T000M11_A137ComandoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.comando__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comando__default(),
            new Object[][] {
                new Object[] {
               T000M2_A137ComandoId, T000M2_A138ComandoNome, T000M2_A139ComandoDescricao, T000M2_A140ComandoFabricanteModulo, T000M2_A141ComandoModeloModulo, T000M2_A142ComandoPayload, T000M2_A143ComandoParameter_Id
               }
               , new Object[] {
               T000M3_A137ComandoId, T000M3_A138ComandoNome, T000M3_A139ComandoDescricao, T000M3_A140ComandoFabricanteModulo, T000M3_A141ComandoModeloModulo, T000M3_A142ComandoPayload, T000M3_A143ComandoParameter_Id
               }
               , new Object[] {
               T000M4_A137ComandoId, T000M4_A138ComandoNome, T000M4_A139ComandoDescricao, T000M4_A140ComandoFabricanteModulo, T000M4_A141ComandoModeloModulo, T000M4_A142ComandoPayload, T000M4_A143ComandoParameter_Id
               }
               , new Object[] {
               T000M5_A137ComandoId
               }
               , new Object[] {
               T000M6_A137ComandoId
               }
               , new Object[] {
               T000M7_A137ComandoId
               }
               , new Object[] {
               T000M8_A137ComandoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000M11_A137ComandoId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound23 ;
      private short GX_JID ;
      private short nIsDirty_23 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7ComandoId ;
      private int Z137ComandoId ;
      private int AV7ComandoId ;
      private int trnEnded ;
      private int A137ComandoId ;
      private int edtComandoId_Enabled ;
      private int edtComandoNome_Enabled ;
      private int edtComandoDescricao_Enabled ;
      private int edtComandoParameter_Id_Enabled ;
      private int edtComandoPayload_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtComandoNome_Internalname ;
      private string cmbComandoFabricanteModulo_Internalname ;
      private string cmbComandoModeloModulo_Internalname ;
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
      private string edtComandoId_Internalname ;
      private string edtComandoId_Jsonclick ;
      private string TempTags ;
      private string edtComandoNome_Jsonclick ;
      private string edtComandoDescricao_Internalname ;
      private string edtComandoDescricao_Jsonclick ;
      private string cmbComandoFabricanteModulo_Jsonclick ;
      private string cmbComandoModeloModulo_Jsonclick ;
      private string edtComandoParameter_Id_Internalname ;
      private string edtComandoParameter_Id_Jsonclick ;
      private string edtComandoPayload_Internalname ;
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
      private string sMode23 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
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
      private string A142ComandoPayload ;
      private string Z142ComandoPayload ;
      private string Z138ComandoNome ;
      private string Z139ComandoDescricao ;
      private string Z140ComandoFabricanteModulo ;
      private string Z141ComandoModeloModulo ;
      private string Z143ComandoParameter_Id ;
      private string A140ComandoFabricanteModulo ;
      private string A141ComandoModeloModulo ;
      private string A138ComandoNome ;
      private string A139ComandoDescricao ;
      private string A143ComandoParameter_Id ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbComandoFabricanteModulo ;
      private GXCombobox cmbComandoModeloModulo ;
      private IDataStoreProvider pr_default ;
      private int[] T000M4_A137ComandoId ;
      private string[] T000M4_A138ComandoNome ;
      private string[] T000M4_A139ComandoDescricao ;
      private string[] T000M4_A140ComandoFabricanteModulo ;
      private string[] T000M4_A141ComandoModeloModulo ;
      private string[] T000M4_A142ComandoPayload ;
      private string[] T000M4_A143ComandoParameter_Id ;
      private int[] T000M5_A137ComandoId ;
      private int[] T000M3_A137ComandoId ;
      private string[] T000M3_A138ComandoNome ;
      private string[] T000M3_A139ComandoDescricao ;
      private string[] T000M3_A140ComandoFabricanteModulo ;
      private string[] T000M3_A141ComandoModeloModulo ;
      private string[] T000M3_A142ComandoPayload ;
      private string[] T000M3_A143ComandoParameter_Id ;
      private int[] T000M6_A137ComandoId ;
      private int[] T000M7_A137ComandoId ;
      private int[] T000M2_A137ComandoId ;
      private string[] T000M2_A138ComandoNome ;
      private string[] T000M2_A139ComandoDescricao ;
      private string[] T000M2_A140ComandoFabricanteModulo ;
      private string[] T000M2_A141ComandoModeloModulo ;
      private string[] T000M2_A142ComandoPayload ;
      private string[] T000M2_A143ComandoParameter_Id ;
      private int[] T000M8_A137ComandoId ;
      private int[] T000M11_A137ComandoId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class comando__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class comando__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000M4;
        prmT000M4 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M5;
        prmT000M5 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M3;
        prmT000M3 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M6;
        prmT000M6 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M7;
        prmT000M7 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M2;
        prmT000M2 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M8;
        prmT000M8 = new Object[] {
        new Object[] {"@ComandoNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoDescricao",SqlDbType.NVarChar,128,0} ,
        new Object[] {"@ComandoFabricanteModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoModeloModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoPayload",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@ComandoParameter_Id",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000M9;
        prmT000M9 = new Object[] {
        new Object[] {"@ComandoNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoDescricao",SqlDbType.NVarChar,128,0} ,
        new Object[] {"@ComandoFabricanteModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoModeloModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoPayload",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@ComandoParameter_Id",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M10;
        prmT000M10 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000M11;
        prmT000M11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000M2", "SELECT [ComandoId], [ComandoNome], [ComandoDescricao], [ComandoFabricanteModulo], [ComandoModeloModulo], [ComandoPayload], [ComandoParameter_Id] FROM [Comando] WITH (UPDLOCK) WHERE [ComandoId] = @ComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M3", "SELECT [ComandoId], [ComandoNome], [ComandoDescricao], [ComandoFabricanteModulo], [ComandoModeloModulo], [ComandoPayload], [ComandoParameter_Id] FROM [Comando] WHERE [ComandoId] = @ComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M4", "SELECT TM1.[ComandoId], TM1.[ComandoNome], TM1.[ComandoDescricao], TM1.[ComandoFabricanteModulo], TM1.[ComandoModeloModulo], TM1.[ComandoPayload], TM1.[ComandoParameter_Id] FROM [Comando] TM1 WHERE TM1.[ComandoId] = @ComandoId ORDER BY TM1.[ComandoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M5", "SELECT [ComandoId] FROM [Comando] WHERE [ComandoId] = @ComandoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M6", "SELECT TOP 1 [ComandoId] FROM [Comando] WHERE ( [ComandoId] > @ComandoId) ORDER BY [ComandoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M7", "SELECT TOP 1 [ComandoId] FROM [Comando] WHERE ( [ComandoId] < @ComandoId) ORDER BY [ComandoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M8", "INSERT INTO [Comando]([ComandoNome], [ComandoDescricao], [ComandoFabricanteModulo], [ComandoModeloModulo], [ComandoPayload], [ComandoParameter_Id]) VALUES(@ComandoNome, @ComandoDescricao, @ComandoFabricanteModulo, @ComandoModeloModulo, @ComandoPayload, @ComandoParameter_Id); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000M8)
           ,new CursorDef("T000M9", "UPDATE [Comando] SET [ComandoNome]=@ComandoNome, [ComandoDescricao]=@ComandoDescricao, [ComandoFabricanteModulo]=@ComandoFabricanteModulo, [ComandoModeloModulo]=@ComandoModeloModulo, [ComandoPayload]=@ComandoPayload, [ComandoParameter_Id]=@ComandoParameter_Id  WHERE [ComandoId] = @ComandoId", GxErrorMask.GX_NOMASK,prmT000M9)
           ,new CursorDef("T000M10", "DELETE FROM [Comando]  WHERE [ComandoId] = @ComandoId", GxErrorMask.GX_NOMASK,prmT000M10)
           ,new CursorDef("T000M11", "SELECT [ComandoId] FROM [Comando] ORDER BY [ComandoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M11,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
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
           case 9 :
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
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (int)parms[6]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
