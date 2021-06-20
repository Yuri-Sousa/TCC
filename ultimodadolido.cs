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
   public class ultimodadolido : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A121UltimoDadoLidoPlaca = GetPar( "UltimoDadoLidoPlaca");
            AssignAttri("", false, "A121UltimoDadoLidoPlaca", A121UltimoDadoLidoPlaca);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A121UltimoDadoLidoPlaca) ;
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
               AV7UltimoDadoLidoId = (int)(NumberUtil.Val( GetPar( "UltimoDadoLidoId"), "."));
               AssignAttri("", false, "AV7UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(AV7UltimoDadoLidoId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vULTIMODADOLIDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7UltimoDadoLidoId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Último Dado Lido", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ultimodadolido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ultimodadolido( IGxContext context )
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
                           int aP1_UltimoDadoLidoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7UltimoDadoLidoId = aP1_UltimoDadoLidoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbUltimoDadoLidoIgnicao = new GXCombobox();
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
            return "ultimodadolido_Execute" ;
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
         if ( cmbUltimoDadoLidoIgnicao.ItemCount > 0 )
         {
            A122UltimoDadoLidoIgnicao = (short)(NumberUtil.Val( cmbUltimoDadoLidoIgnicao.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0))), "."));
            AssignAttri("", false, "A122UltimoDadoLidoIgnicao", StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUltimoDadoLidoIgnicao.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
            AssignProp("", false, cmbUltimoDadoLidoIgnicao_Internalname, "Values", cmbUltimoDadoLidoIgnicao.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118UltimoDadoLidoId), 8, 0, ",", "")), ((edtUltimoDadoLidoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A118UltimoDadoLidoId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A118UltimoDadoLidoId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoGAMGUIDProprietario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoGAMGUIDProprietario_Internalname, "GAMGUID do Proprietário", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoGAMGUIDProprietario_Internalname, StringUtil.RTrim( A153UltimoDadoLidoGAMGUIDProprietario), StringUtil.RTrim( context.localUtil.Format( A153UltimoDadoLidoGAMGUIDProprietario, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoGAMGUIDProprietario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoGAMGUIDProprietario_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoDataHoraServidor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoDataHoraServidor_Internalname, "Hora Servidor", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUltimoDadoLidoDataHoraServidor_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoDataHoraServidor_Internalname, context.localUtil.TToC( A119UltimoDadoLidoDataHoraServidor, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A119UltimoDadoLidoDataHoraServidor, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoDataHoraServidor_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtUltimoDadoLidoDataHoraServidor_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_bitmap( context, edtUltimoDadoLidoDataHoraServidor_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUltimoDadoLidoDataHoraServidor_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UltimoDadoLido.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoDataHoraRastreador_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoDataHoraRastreador_Internalname, "Hora Rastreador", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUltimoDadoLidoDataHoraRastreador_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoDataHoraRastreador_Internalname, context.localUtil.TToC( A120UltimoDadoLidoDataHoraRastreador, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A120UltimoDadoLidoDataHoraRastreador, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoDataHoraRastreador_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtUltimoDadoLidoDataHoraRastreador_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_bitmap( context, edtUltimoDadoLidoDataHoraRastreador_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUltimoDadoLidoDataHoraRastreador_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UltimoDadoLido.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoPlaca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoPlaca_Internalname, "Placa", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoPlaca_Internalname, A121UltimoDadoLidoPlaca, StringUtil.RTrim( context.localUtil.Format( A121UltimoDadoLidoPlaca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoPlaca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoPlaca_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoIdent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoIdent_Internalname, "Número do Rastreador", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoIdent_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126UltimoDadoLidoIdent), 16, 0, ",", "")), ((edtUltimoDadoLidoIdent_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A126UltimoDadoLidoIdent), "ZZZZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A126UltimoDadoLidoIdent), "ZZZZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoIdent_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoIdent_Enabled, 0, "number", "1", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbUltimoDadoLidoIgnicao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUltimoDadoLidoIgnicao_Internalname, "Ignição", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUltimoDadoLidoIgnicao, cmbUltimoDadoLidoIgnicao_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0)), 1, cmbUltimoDadoLidoIgnicao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUltimoDadoLidoIgnicao.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, "HLP_UltimoDadoLido.htm");
         cmbUltimoDadoLidoIgnicao.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
         AssignProp("", false, cmbUltimoDadoLidoIgnicao_Internalname, "Values", (string)(cmbUltimoDadoLidoIgnicao.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoVelocidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoVelocidade_Internalname, "Velocidade", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoVelocidade_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125UltimoDadoLidoVelocidade), 3, 0, ",", "")), ((edtUltimoDadoLidoVelocidade_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A125UltimoDadoLidoVelocidade), "ZZ9")) : context.localUtil.Format( (decimal)(A125UltimoDadoLidoVelocidade), "ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoVelocidade_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoVelocidade_Enabled, 0, "number", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoLatitude_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoLatitude_Internalname, "Latitude", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoLatitude_Internalname, A123UltimoDadoLidoLatitude, StringUtil.RTrim( context.localUtil.Format( A123UltimoDadoLidoLatitude, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoLatitude_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoLatitude_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoLongitude_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoLongitude_Internalname, "Longitude", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoLongitude_Internalname, A124UltimoDadoLidoLongitude, StringUtil.RTrim( context.localUtil.Format( A124UltimoDadoLidoLongitude, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoLongitude_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoLongitude_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUltimoDadoLidoGeolocalizacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUltimoDadoLidoGeolocalizacao_Internalname, "Geolocalização", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUltimoDadoLidoGeolocalizacao_Internalname, A127UltimoDadoLidoGeolocalizacao, StringUtil.RTrim( context.localUtil.Format( A127UltimoDadoLidoGeolocalizacao, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUltimoDadoLidoGeolocalizacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUltimoDadoLidoGeolocalizacao_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UltimoDadoLido.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_UltimoDadoLido.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_UltimoDadoLido.htm");
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
         E110J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z118UltimoDadoLidoId = (int)(context.localUtil.CToN( cgiGet( "Z118UltimoDadoLidoId"), ",", "."));
               Z119UltimoDadoLidoDataHoraServidor = context.localUtil.CToT( cgiGet( "Z119UltimoDadoLidoDataHoraServidor"), 0);
               Z120UltimoDadoLidoDataHoraRastreador = context.localUtil.CToT( cgiGet( "Z120UltimoDadoLidoDataHoraRastreador"), 0);
               Z121UltimoDadoLidoPlaca = cgiGet( "Z121UltimoDadoLidoPlaca");
               Z126UltimoDadoLidoIdent = (long)(context.localUtil.CToN( cgiGet( "Z126UltimoDadoLidoIdent"), ",", "."));
               Z122UltimoDadoLidoIgnicao = (short)(context.localUtil.CToN( cgiGet( "Z122UltimoDadoLidoIgnicao"), ",", "."));
               Z125UltimoDadoLidoVelocidade = (short)(context.localUtil.CToN( cgiGet( "Z125UltimoDadoLidoVelocidade"), ",", "."));
               Z123UltimoDadoLidoLatitude = cgiGet( "Z123UltimoDadoLidoLatitude");
               Z124UltimoDadoLidoLongitude = cgiGet( "Z124UltimoDadoLidoLongitude");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7UltimoDadoLidoId = (int)(context.localUtil.CToN( cgiGet( "vULTIMODADOLIDOID"), ",", "."));
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
               A118UltimoDadoLidoId = (int)(context.localUtil.CToN( cgiGet( edtUltimoDadoLidoId_Internalname), ",", "."));
               AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
               A153UltimoDadoLidoGAMGUIDProprietario = cgiGet( edtUltimoDadoLidoGAMGUIDProprietario_Internalname);
               n153UltimoDadoLidoGAMGUIDProprietario = false;
               AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
               if ( context.localUtil.VCDateTime( cgiGet( edtUltimoDadoLidoDataHoraServidor_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Hora Servidor"}), 1, "ULTIMODADOLIDODATAHORASERVIDOR");
                  AnyError = 1;
                  GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A119UltimoDadoLidoDataHoraServidor", context.localUtil.TToC( A119UltimoDadoLidoDataHoraServidor, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A119UltimoDadoLidoDataHoraServidor = context.localUtil.CToT( cgiGet( edtUltimoDadoLidoDataHoraServidor_Internalname));
                  AssignAttri("", false, "A119UltimoDadoLidoDataHoraServidor", context.localUtil.TToC( A119UltimoDadoLidoDataHoraServidor, 8, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtUltimoDadoLidoDataHoraRastreador_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Hora Rastreador"}), 1, "ULTIMODADOLIDODATAHORARASTREADOR");
                  AnyError = 1;
                  GX_FocusControl = edtUltimoDadoLidoDataHoraRastreador_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A120UltimoDadoLidoDataHoraRastreador", context.localUtil.TToC( A120UltimoDadoLidoDataHoraRastreador, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A120UltimoDadoLidoDataHoraRastreador = context.localUtil.CToT( cgiGet( edtUltimoDadoLidoDataHoraRastreador_Internalname));
                  AssignAttri("", false, "A120UltimoDadoLidoDataHoraRastreador", context.localUtil.TToC( A120UltimoDadoLidoDataHoraRastreador, 8, 5, 0, 3, "/", ":", " "));
               }
               A121UltimoDadoLidoPlaca = cgiGet( edtUltimoDadoLidoPlaca_Internalname);
               AssignAttri("", false, "A121UltimoDadoLidoPlaca", A121UltimoDadoLidoPlaca);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUltimoDadoLidoIdent_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUltimoDadoLidoIdent_Internalname), ",", ".") > Convert.ToDecimal( 9999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ULTIMODADOLIDOIDENT");
                  AnyError = 1;
                  GX_FocusControl = edtUltimoDadoLidoIdent_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A126UltimoDadoLidoIdent = 0;
                  AssignAttri("", false, "A126UltimoDadoLidoIdent", StringUtil.LTrimStr( (decimal)(A126UltimoDadoLidoIdent), 16, 0));
               }
               else
               {
                  A126UltimoDadoLidoIdent = (long)(context.localUtil.CToN( cgiGet( edtUltimoDadoLidoIdent_Internalname), ",", "."));
                  AssignAttri("", false, "A126UltimoDadoLidoIdent", StringUtil.LTrimStr( (decimal)(A126UltimoDadoLidoIdent), 16, 0));
               }
               cmbUltimoDadoLidoIgnicao.CurrentValue = cgiGet( cmbUltimoDadoLidoIgnicao_Internalname);
               A122UltimoDadoLidoIgnicao = (short)(NumberUtil.Val( cgiGet( cmbUltimoDadoLidoIgnicao_Internalname), "."));
               AssignAttri("", false, "A122UltimoDadoLidoIgnicao", StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtUltimoDadoLidoVelocidade_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUltimoDadoLidoVelocidade_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ULTIMODADOLIDOVELOCIDADE");
                  AnyError = 1;
                  GX_FocusControl = edtUltimoDadoLidoVelocidade_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A125UltimoDadoLidoVelocidade = 0;
                  AssignAttri("", false, "A125UltimoDadoLidoVelocidade", StringUtil.LTrimStr( (decimal)(A125UltimoDadoLidoVelocidade), 3, 0));
               }
               else
               {
                  A125UltimoDadoLidoVelocidade = (short)(context.localUtil.CToN( cgiGet( edtUltimoDadoLidoVelocidade_Internalname), ",", "."));
                  AssignAttri("", false, "A125UltimoDadoLidoVelocidade", StringUtil.LTrimStr( (decimal)(A125UltimoDadoLidoVelocidade), 3, 0));
               }
               A123UltimoDadoLidoLatitude = cgiGet( edtUltimoDadoLidoLatitude_Internalname);
               AssignAttri("", false, "A123UltimoDadoLidoLatitude", A123UltimoDadoLidoLatitude);
               A124UltimoDadoLidoLongitude = cgiGet( edtUltimoDadoLidoLongitude_Internalname);
               AssignAttri("", false, "A124UltimoDadoLidoLongitude", A124UltimoDadoLidoLongitude);
               A127UltimoDadoLidoGeolocalizacao = cgiGet( edtUltimoDadoLidoGeolocalizacao_Internalname);
               AssignAttri("", false, "A127UltimoDadoLidoGeolocalizacao", A127UltimoDadoLidoGeolocalizacao);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"UltimoDadoLido");
               A118UltimoDadoLidoId = (int)(context.localUtil.CToN( cgiGet( edtUltimoDadoLidoId_Internalname), ",", "."));
               AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
               forbiddenHiddens.Add("UltimoDadoLidoId", context.localUtil.Format( (decimal)(A118UltimoDadoLidoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("ultimodadolido:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A118UltimoDadoLidoId = (int)(NumberUtil.Val( GetPar( "UltimoDadoLidoId"), "."));
                  AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
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
                     sMode20 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode20;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound20 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ULTIMODADOLIDOID");
                        AnyError = 1;
                        GX_FocusControl = edtUltimoDadoLidoId_Internalname;
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
                           E110J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120J2 ();
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
            E120J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0J20( ) ;
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
            DisableAttributes0J20( ) ;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J20( ) ;
            }
            else
            {
               CheckExtendedTable0J20( ) ;
               CloseExtendedTableCursors0J20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0J0( )
      {
      }

      protected void E110J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E120J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("ultimodadolidoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0J20( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z119UltimoDadoLidoDataHoraServidor = T000J3_A119UltimoDadoLidoDataHoraServidor[0];
               Z120UltimoDadoLidoDataHoraRastreador = T000J3_A120UltimoDadoLidoDataHoraRastreador[0];
               Z121UltimoDadoLidoPlaca = T000J3_A121UltimoDadoLidoPlaca[0];
               Z126UltimoDadoLidoIdent = T000J3_A126UltimoDadoLidoIdent[0];
               Z122UltimoDadoLidoIgnicao = T000J3_A122UltimoDadoLidoIgnicao[0];
               Z125UltimoDadoLidoVelocidade = T000J3_A125UltimoDadoLidoVelocidade[0];
               Z123UltimoDadoLidoLatitude = T000J3_A123UltimoDadoLidoLatitude[0];
               Z124UltimoDadoLidoLongitude = T000J3_A124UltimoDadoLidoLongitude[0];
            }
            else
            {
               Z119UltimoDadoLidoDataHoraServidor = A119UltimoDadoLidoDataHoraServidor;
               Z120UltimoDadoLidoDataHoraRastreador = A120UltimoDadoLidoDataHoraRastreador;
               Z121UltimoDadoLidoPlaca = A121UltimoDadoLidoPlaca;
               Z126UltimoDadoLidoIdent = A126UltimoDadoLidoIdent;
               Z122UltimoDadoLidoIgnicao = A122UltimoDadoLidoIgnicao;
               Z125UltimoDadoLidoVelocidade = A125UltimoDadoLidoVelocidade;
               Z123UltimoDadoLidoLatitude = A123UltimoDadoLidoLatitude;
               Z124UltimoDadoLidoLongitude = A124UltimoDadoLidoLongitude;
            }
         }
         if ( GX_JID == -7 )
         {
            Z118UltimoDadoLidoId = A118UltimoDadoLidoId;
            Z119UltimoDadoLidoDataHoraServidor = A119UltimoDadoLidoDataHoraServidor;
            Z120UltimoDadoLidoDataHoraRastreador = A120UltimoDadoLidoDataHoraRastreador;
            Z121UltimoDadoLidoPlaca = A121UltimoDadoLidoPlaca;
            Z126UltimoDadoLidoIdent = A126UltimoDadoLidoIdent;
            Z122UltimoDadoLidoIgnicao = A122UltimoDadoLidoIgnicao;
            Z125UltimoDadoLidoVelocidade = A125UltimoDadoLidoVelocidade;
            Z123UltimoDadoLidoLatitude = A123UltimoDadoLidoLatitude;
            Z124UltimoDadoLidoLongitude = A124UltimoDadoLidoLongitude;
            Z153UltimoDadoLidoGAMGUIDProprietario = A153UltimoDadoLidoGAMGUIDProprietario;
         }
      }

      protected void standaloneNotModal( )
      {
         edtUltimoDadoLidoId_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoId_Enabled), 5, 0), true);
         edtUltimoDadoLidoId_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7UltimoDadoLidoId) )
         {
            A118UltimoDadoLidoId = AV7UltimoDadoLidoId;
            AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
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

      protected void Load0J20( )
      {
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
            A119UltimoDadoLidoDataHoraServidor = T000J5_A119UltimoDadoLidoDataHoraServidor[0];
            AssignAttri("", false, "A119UltimoDadoLidoDataHoraServidor", context.localUtil.TToC( A119UltimoDadoLidoDataHoraServidor, 8, 5, 0, 3, "/", ":", " "));
            A120UltimoDadoLidoDataHoraRastreador = T000J5_A120UltimoDadoLidoDataHoraRastreador[0];
            AssignAttri("", false, "A120UltimoDadoLidoDataHoraRastreador", context.localUtil.TToC( A120UltimoDadoLidoDataHoraRastreador, 8, 5, 0, 3, "/", ":", " "));
            A121UltimoDadoLidoPlaca = T000J5_A121UltimoDadoLidoPlaca[0];
            AssignAttri("", false, "A121UltimoDadoLidoPlaca", A121UltimoDadoLidoPlaca);
            A126UltimoDadoLidoIdent = T000J5_A126UltimoDadoLidoIdent[0];
            AssignAttri("", false, "A126UltimoDadoLidoIdent", StringUtil.LTrimStr( (decimal)(A126UltimoDadoLidoIdent), 16, 0));
            A122UltimoDadoLidoIgnicao = T000J5_A122UltimoDadoLidoIgnicao[0];
            AssignAttri("", false, "A122UltimoDadoLidoIgnicao", StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
            A125UltimoDadoLidoVelocidade = T000J5_A125UltimoDadoLidoVelocidade[0];
            AssignAttri("", false, "A125UltimoDadoLidoVelocidade", StringUtil.LTrimStr( (decimal)(A125UltimoDadoLidoVelocidade), 3, 0));
            A123UltimoDadoLidoLatitude = T000J5_A123UltimoDadoLidoLatitude[0];
            AssignAttri("", false, "A123UltimoDadoLidoLatitude", A123UltimoDadoLidoLatitude);
            A124UltimoDadoLidoLongitude = T000J5_A124UltimoDadoLidoLongitude[0];
            AssignAttri("", false, "A124UltimoDadoLidoLongitude", A124UltimoDadoLidoLongitude);
            A153UltimoDadoLidoGAMGUIDProprietario = T000J5_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = T000J5_n153UltimoDadoLidoGAMGUIDProprietario[0];
            AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
            ZM0J20( -7) ;
         }
         pr_default.close(3);
         OnLoadActions0J20( ) ;
      }

      protected void OnLoadActions0J20( )
      {
         A127UltimoDadoLidoGeolocalizacao = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".") + "," + StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
         AssignAttri("", false, "A127UltimoDadoLidoGeolocalizacao", A127UltimoDadoLidoGeolocalizacao);
      }

      protected void CheckExtendedTable0J20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A126UltimoDadoLidoIdent, A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Número do Rastreador"}), 1, "ULTIMODADOLIDOIDENT");
            AnyError = 1;
            GX_FocusControl = edtUltimoDadoLidoIdent_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A119UltimoDadoLidoDataHoraServidor) || ( A119UltimoDadoLidoDataHoraServidor >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Hora Servidor fora do intervalo", "OutOfRange", 1, "ULTIMODADOLIDODATAHORASERVIDOR");
            AnyError = 1;
            GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A120UltimoDadoLidoDataHoraRastreador) || ( A120UltimoDadoLidoDataHoraRastreador >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Hora Rastreador fora do intervalo", "OutOfRange", 1, "ULTIMODADOLIDODATAHORARASTREADOR");
            AnyError = 1;
            GX_FocusControl = edtUltimoDadoLidoDataHoraRastreador_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A121UltimoDadoLidoPlaca});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A153UltimoDadoLidoGAMGUIDProprietario = T000J4_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = T000J4_n153UltimoDadoLidoGAMGUIDProprietario[0];
            AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
         }
         else
         {
            nIsDirty_20 = 1;
            A153UltimoDadoLidoGAMGUIDProprietario = "";
            n153UltimoDadoLidoGAMGUIDProprietario = false;
            AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
         }
         pr_default.close(2);
         if ( ! ( ( A122UltimoDadoLidoIgnicao == 1 ) || ( A122UltimoDadoLidoIgnicao == 2 ) ) )
         {
            GX_msglist.addItem("Campo Ignição fora do intervalo", "OutOfRange", 1, "ULTIMODADOLIDOIGNICAO");
            AnyError = 1;
            GX_FocusControl = cmbUltimoDadoLidoIgnicao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_20 = 1;
         A127UltimoDadoLidoGeolocalizacao = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".") + "," + StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
         AssignAttri("", false, "A127UltimoDadoLidoGeolocalizacao", A127UltimoDadoLidoGeolocalizacao);
      }

      protected void CloseExtendedTableCursors0J20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( string A121UltimoDadoLidoPlaca )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A121UltimoDadoLidoPlaca});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A153UltimoDadoLidoGAMGUIDProprietario = T000J7_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = T000J7_n153UltimoDadoLidoGAMGUIDProprietario[0];
            AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
         }
         else
         {
            A153UltimoDadoLidoGAMGUIDProprietario = "";
            n153UltimoDadoLidoGAMGUIDProprietario = false;
            AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A153UltimoDadoLidoGAMGUIDProprietario))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey0J20( )
      {
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J20( 7) ;
            RcdFound20 = 1;
            A118UltimoDadoLidoId = T000J3_A118UltimoDadoLidoId[0];
            AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
            A119UltimoDadoLidoDataHoraServidor = T000J3_A119UltimoDadoLidoDataHoraServidor[0];
            AssignAttri("", false, "A119UltimoDadoLidoDataHoraServidor", context.localUtil.TToC( A119UltimoDadoLidoDataHoraServidor, 8, 5, 0, 3, "/", ":", " "));
            A120UltimoDadoLidoDataHoraRastreador = T000J3_A120UltimoDadoLidoDataHoraRastreador[0];
            AssignAttri("", false, "A120UltimoDadoLidoDataHoraRastreador", context.localUtil.TToC( A120UltimoDadoLidoDataHoraRastreador, 8, 5, 0, 3, "/", ":", " "));
            A121UltimoDadoLidoPlaca = T000J3_A121UltimoDadoLidoPlaca[0];
            AssignAttri("", false, "A121UltimoDadoLidoPlaca", A121UltimoDadoLidoPlaca);
            A126UltimoDadoLidoIdent = T000J3_A126UltimoDadoLidoIdent[0];
            AssignAttri("", false, "A126UltimoDadoLidoIdent", StringUtil.LTrimStr( (decimal)(A126UltimoDadoLidoIdent), 16, 0));
            A122UltimoDadoLidoIgnicao = T000J3_A122UltimoDadoLidoIgnicao[0];
            AssignAttri("", false, "A122UltimoDadoLidoIgnicao", StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
            A125UltimoDadoLidoVelocidade = T000J3_A125UltimoDadoLidoVelocidade[0];
            AssignAttri("", false, "A125UltimoDadoLidoVelocidade", StringUtil.LTrimStr( (decimal)(A125UltimoDadoLidoVelocidade), 3, 0));
            A123UltimoDadoLidoLatitude = T000J3_A123UltimoDadoLidoLatitude[0];
            AssignAttri("", false, "A123UltimoDadoLidoLatitude", A123UltimoDadoLidoLatitude);
            A124UltimoDadoLidoLongitude = T000J3_A124UltimoDadoLidoLongitude[0];
            AssignAttri("", false, "A124UltimoDadoLidoLongitude", A124UltimoDadoLidoLongitude);
            Z118UltimoDadoLidoId = A118UltimoDadoLidoId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0J20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0J20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J20( ) ;
         if ( RcdFound20 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound20 = 0;
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000J9_A118UltimoDadoLidoId[0] < A118UltimoDadoLidoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000J9_A118UltimoDadoLidoId[0] > A118UltimoDadoLidoId ) ) )
            {
               A118UltimoDadoLidoId = T000J9_A118UltimoDadoLidoId[0];
               AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000J10 */
         pr_default.execute(8, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A118UltimoDadoLidoId[0] > A118UltimoDadoLidoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A118UltimoDadoLidoId[0] < A118UltimoDadoLidoId ) ) )
            {
               A118UltimoDadoLidoId = T000J10_A118UltimoDadoLidoId[0];
               AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId )
               {
                  A118UltimoDadoLidoId = Z118UltimoDadoLidoId;
                  AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ULTIMODADOLIDOID");
                  AnyError = 1;
                  GX_FocusControl = edtUltimoDadoLidoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0J20( ) ;
                  GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ULTIMODADOLIDOID");
                     AnyError = 1;
                     GX_FocusControl = edtUltimoDadoLidoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J20( ) ;
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
         if ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId )
         {
            A118UltimoDadoLidoId = Z118UltimoDadoLidoId;
            AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ULTIMODADOLIDOID");
            AnyError = 1;
            GX_FocusControl = edtUltimoDadoLidoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUltimoDadoLidoDataHoraServidor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0J20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A118UltimoDadoLidoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UltimoDadoLido"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z119UltimoDadoLidoDataHoraServidor != T000J2_A119UltimoDadoLidoDataHoraServidor[0] ) || ( Z120UltimoDadoLidoDataHoraRastreador != T000J2_A120UltimoDadoLidoDataHoraRastreador[0] ) || ( StringUtil.StrCmp(Z121UltimoDadoLidoPlaca, T000J2_A121UltimoDadoLidoPlaca[0]) != 0 ) || ( Z126UltimoDadoLidoIdent != T000J2_A126UltimoDadoLidoIdent[0] ) || ( Z122UltimoDadoLidoIgnicao != T000J2_A122UltimoDadoLidoIgnicao[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z125UltimoDadoLidoVelocidade != T000J2_A125UltimoDadoLidoVelocidade[0] ) || ( StringUtil.StrCmp(Z123UltimoDadoLidoLatitude, T000J2_A123UltimoDadoLidoLatitude[0]) != 0 ) || ( StringUtil.StrCmp(Z124UltimoDadoLidoLongitude, T000J2_A124UltimoDadoLidoLongitude[0]) != 0 ) )
            {
               if ( Z119UltimoDadoLidoDataHoraServidor != T000J2_A119UltimoDadoLidoDataHoraServidor[0] )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoDataHoraServidor");
                  GXUtil.WriteLogRaw("Old: ",Z119UltimoDadoLidoDataHoraServidor);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A119UltimoDadoLidoDataHoraServidor[0]);
               }
               if ( Z120UltimoDadoLidoDataHoraRastreador != T000J2_A120UltimoDadoLidoDataHoraRastreador[0] )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoDataHoraRastreador");
                  GXUtil.WriteLogRaw("Old: ",Z120UltimoDadoLidoDataHoraRastreador);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A120UltimoDadoLidoDataHoraRastreador[0]);
               }
               if ( StringUtil.StrCmp(Z121UltimoDadoLidoPlaca, T000J2_A121UltimoDadoLidoPlaca[0]) != 0 )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoPlaca");
                  GXUtil.WriteLogRaw("Old: ",Z121UltimoDadoLidoPlaca);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A121UltimoDadoLidoPlaca[0]);
               }
               if ( Z126UltimoDadoLidoIdent != T000J2_A126UltimoDadoLidoIdent[0] )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoIdent");
                  GXUtil.WriteLogRaw("Old: ",Z126UltimoDadoLidoIdent);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A126UltimoDadoLidoIdent[0]);
               }
               if ( Z122UltimoDadoLidoIgnicao != T000J2_A122UltimoDadoLidoIgnicao[0] )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoIgnicao");
                  GXUtil.WriteLogRaw("Old: ",Z122UltimoDadoLidoIgnicao);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A122UltimoDadoLidoIgnicao[0]);
               }
               if ( Z125UltimoDadoLidoVelocidade != T000J2_A125UltimoDadoLidoVelocidade[0] )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoVelocidade");
                  GXUtil.WriteLogRaw("Old: ",Z125UltimoDadoLidoVelocidade);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A125UltimoDadoLidoVelocidade[0]);
               }
               if ( StringUtil.StrCmp(Z123UltimoDadoLidoLatitude, T000J2_A123UltimoDadoLidoLatitude[0]) != 0 )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoLatitude");
                  GXUtil.WriteLogRaw("Old: ",Z123UltimoDadoLidoLatitude);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A123UltimoDadoLidoLatitude[0]);
               }
               if ( StringUtil.StrCmp(Z124UltimoDadoLidoLongitude, T000J2_A124UltimoDadoLidoLongitude[0]) != 0 )
               {
                  GXUtil.WriteLog("ultimodadolido:[seudo value changed for attri]"+"UltimoDadoLidoLongitude");
                  GXUtil.WriteLogRaw("Old: ",Z124UltimoDadoLidoLongitude);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A124UltimoDadoLidoLongitude[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UltimoDadoLido"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J20( )
      {
         if ( ! IsAuthorized("ultimodadolido_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J20( 0) ;
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J11 */
                     pr_default.execute(9, new Object[] {A119UltimoDadoLidoDataHoraServidor, A120UltimoDadoLidoDataHoraRastreador, A121UltimoDadoLidoPlaca, A126UltimoDadoLidoIdent, A122UltimoDadoLidoIgnicao, A125UltimoDadoLidoVelocidade, A123UltimoDadoLidoLatitude, A124UltimoDadoLidoLongitude});
                     A118UltimoDadoLidoId = T000J11_A118UltimoDadoLidoId[0];
                     AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0J0( ) ;
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
               Load0J20( ) ;
            }
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void Update0J20( )
      {
         if ( ! IsAuthorized("ultimodadolido_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J12 */
                     pr_default.execute(10, new Object[] {A119UltimoDadoLidoDataHoraServidor, A120UltimoDadoLidoDataHoraRastreador, A121UltimoDadoLidoPlaca, A126UltimoDadoLidoIdent, A122UltimoDadoLidoIgnicao, A125UltimoDadoLidoVelocidade, A123UltimoDadoLidoLatitude, A124UltimoDadoLidoLongitude, A118UltimoDadoLidoId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UltimoDadoLido"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J20( ) ;
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
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void DeferredUpdate0J20( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("ultimodadolido_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J20( ) ;
            AfterConfirm0J20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J13 */
                  pr_default.execute(11, new Object[] {A118UltimoDadoLidoId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J20( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000J14 */
            pr_default.execute(12, new Object[] {A121UltimoDadoLidoPlaca});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A153UltimoDadoLidoGAMGUIDProprietario = T000J14_A153UltimoDadoLidoGAMGUIDProprietario[0];
               n153UltimoDadoLidoGAMGUIDProprietario = T000J14_n153UltimoDadoLidoGAMGUIDProprietario[0];
               AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
            }
            else
            {
               A153UltimoDadoLidoGAMGUIDProprietario = "";
               n153UltimoDadoLidoGAMGUIDProprietario = false;
               AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
            }
            pr_default.close(12);
            A127UltimoDadoLidoGeolocalizacao = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".") + "," + StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
            AssignAttri("", false, "A127UltimoDadoLidoGeolocalizacao", A127UltimoDadoLidoGeolocalizacao);
         }
      }

      protected void EndLevel0J20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("ultimodadolido",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("ultimodadolido",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J20( )
      {
         /* Scan By routine */
         /* Using cursor T000J15 */
         pr_default.execute(13);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound20 = 1;
            A118UltimoDadoLidoId = T000J15_A118UltimoDadoLidoId[0];
            AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J20( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound20 = 1;
            A118UltimoDadoLidoId = T000J15_A118UltimoDadoLidoId[0];
            AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
         }
      }

      protected void ScanEnd0J20( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0J20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J20( )
      {
         edtUltimoDadoLidoId_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoId_Enabled), 5, 0), true);
         edtUltimoDadoLidoGAMGUIDProprietario_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoGAMGUIDProprietario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoGAMGUIDProprietario_Enabled), 5, 0), true);
         edtUltimoDadoLidoDataHoraServidor_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoDataHoraServidor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoDataHoraServidor_Enabled), 5, 0), true);
         edtUltimoDadoLidoDataHoraRastreador_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoDataHoraRastreador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoDataHoraRastreador_Enabled), 5, 0), true);
         edtUltimoDadoLidoPlaca_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoPlaca_Enabled), 5, 0), true);
         edtUltimoDadoLidoIdent_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoIdent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoIdent_Enabled), 5, 0), true);
         cmbUltimoDadoLidoIgnicao.Enabled = 0;
         AssignProp("", false, cmbUltimoDadoLidoIgnicao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUltimoDadoLidoIgnicao.Enabled), 5, 0), true);
         edtUltimoDadoLidoVelocidade_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoVelocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoVelocidade_Enabled), 5, 0), true);
         edtUltimoDadoLidoLatitude_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoLatitude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoLatitude_Enabled), 5, 0), true);
         edtUltimoDadoLidoLongitude_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoLongitude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoLongitude_Enabled), 5, 0), true);
         edtUltimoDadoLidoGeolocalizacao_Enabled = 0;
         AssignProp("", false, edtUltimoDadoLidoGeolocalizacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUltimoDadoLidoGeolocalizacao_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142918144822", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ultimodadolido.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7UltimoDadoLidoId,8,0))}, new string[] {"Gx_mode","UltimoDadoLidoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"UltimoDadoLido");
         forbiddenHiddens.Add("UltimoDadoLidoId", context.localUtil.Format( (decimal)(A118UltimoDadoLidoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ultimodadolido:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z118UltimoDadoLidoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118UltimoDadoLidoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z119UltimoDadoLidoDataHoraServidor", context.localUtil.TToC( Z119UltimoDadoLidoDataHoraServidor, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z120UltimoDadoLidoDataHoraRastreador", context.localUtil.TToC( Z120UltimoDadoLidoDataHoraRastreador, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z121UltimoDadoLidoPlaca", Z121UltimoDadoLidoPlaca);
         GxWebStd.gx_hidden_field( context, "Z126UltimoDadoLidoIdent", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126UltimoDadoLidoIdent), 16, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z122UltimoDadoLidoIgnicao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z122UltimoDadoLidoIgnicao), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z125UltimoDadoLidoVelocidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125UltimoDadoLidoVelocidade), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z123UltimoDadoLidoLatitude", Z123UltimoDadoLidoLatitude);
         GxWebStd.gx_hidden_field( context, "Z124UltimoDadoLidoLongitude", Z124UltimoDadoLidoLongitude);
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
         GxWebStd.gx_hidden_field( context, "vULTIMODADOLIDOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7UltimoDadoLidoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vULTIMODADOLIDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7UltimoDadoLidoId), "ZZZZZZZ9"), context));
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
         return formatLink("ultimodadolido.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7UltimoDadoLidoId,8,0))}, new string[] {"Gx_mode","UltimoDadoLidoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "UltimoDadoLido" ;
      }

      public override string GetPgmdesc( )
      {
         return "Último Dado Lido" ;
      }

      protected void InitializeNonKey0J20( )
      {
         A127UltimoDadoLidoGeolocalizacao = "";
         AssignAttri("", false, "A127UltimoDadoLidoGeolocalizacao", A127UltimoDadoLidoGeolocalizacao);
         A153UltimoDadoLidoGAMGUIDProprietario = "";
         n153UltimoDadoLidoGAMGUIDProprietario = false;
         AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", A153UltimoDadoLidoGAMGUIDProprietario);
         A119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A119UltimoDadoLidoDataHoraServidor", context.localUtil.TToC( A119UltimoDadoLidoDataHoraServidor, 8, 5, 0, 3, "/", ":", " "));
         A120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A120UltimoDadoLidoDataHoraRastreador", context.localUtil.TToC( A120UltimoDadoLidoDataHoraRastreador, 8, 5, 0, 3, "/", ":", " "));
         A121UltimoDadoLidoPlaca = "";
         AssignAttri("", false, "A121UltimoDadoLidoPlaca", A121UltimoDadoLidoPlaca);
         A126UltimoDadoLidoIdent = 0;
         AssignAttri("", false, "A126UltimoDadoLidoIdent", StringUtil.LTrimStr( (decimal)(A126UltimoDadoLidoIdent), 16, 0));
         A122UltimoDadoLidoIgnicao = 0;
         AssignAttri("", false, "A122UltimoDadoLidoIgnicao", StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
         A125UltimoDadoLidoVelocidade = 0;
         AssignAttri("", false, "A125UltimoDadoLidoVelocidade", StringUtil.LTrimStr( (decimal)(A125UltimoDadoLidoVelocidade), 3, 0));
         A123UltimoDadoLidoLatitude = "";
         AssignAttri("", false, "A123UltimoDadoLidoLatitude", A123UltimoDadoLidoLatitude);
         A124UltimoDadoLidoLongitude = "";
         AssignAttri("", false, "A124UltimoDadoLidoLongitude", A124UltimoDadoLidoLongitude);
         Z119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         Z120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         Z121UltimoDadoLidoPlaca = "";
         Z126UltimoDadoLidoIdent = 0;
         Z122UltimoDadoLidoIgnicao = 0;
         Z125UltimoDadoLidoVelocidade = 0;
         Z123UltimoDadoLidoLatitude = "";
         Z124UltimoDadoLidoLongitude = "";
      }

      protected void InitAll0J20( )
      {
         A118UltimoDadoLidoId = 0;
         AssignAttri("", false, "A118UltimoDadoLidoId", StringUtil.LTrimStr( (decimal)(A118UltimoDadoLidoId), 8, 0));
         InitializeNonKey0J20( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918144830", true, true);
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
         context.AddJavascriptSource("ultimodadolido.js", "?202142918144830", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtUltimoDadoLidoId_Internalname = "ULTIMODADOLIDOID";
         edtUltimoDadoLidoGAMGUIDProprietario_Internalname = "ULTIMODADOLIDOGAMGUIDPROPRIETARIO";
         edtUltimoDadoLidoDataHoraServidor_Internalname = "ULTIMODADOLIDODATAHORASERVIDOR";
         edtUltimoDadoLidoDataHoraRastreador_Internalname = "ULTIMODADOLIDODATAHORARASTREADOR";
         edtUltimoDadoLidoPlaca_Internalname = "ULTIMODADOLIDOPLACA";
         edtUltimoDadoLidoIdent_Internalname = "ULTIMODADOLIDOIDENT";
         cmbUltimoDadoLidoIgnicao_Internalname = "ULTIMODADOLIDOIGNICAO";
         edtUltimoDadoLidoVelocidade_Internalname = "ULTIMODADOLIDOVELOCIDADE";
         edtUltimoDadoLidoLatitude_Internalname = "ULTIMODADOLIDOLATITUDE";
         edtUltimoDadoLidoLongitude_Internalname = "ULTIMODADOLIDOLONGITUDE";
         edtUltimoDadoLidoGeolocalizacao_Internalname = "ULTIMODADOLIDOGEOLOCALIZACAO";
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
         Form.Caption = "Último Dado Lido";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtUltimoDadoLidoGeolocalizacao_Jsonclick = "";
         edtUltimoDadoLidoGeolocalizacao_Enabled = 0;
         edtUltimoDadoLidoLongitude_Jsonclick = "";
         edtUltimoDadoLidoLongitude_Enabled = 1;
         edtUltimoDadoLidoLatitude_Jsonclick = "";
         edtUltimoDadoLidoLatitude_Enabled = 1;
         edtUltimoDadoLidoVelocidade_Jsonclick = "";
         edtUltimoDadoLidoVelocidade_Enabled = 1;
         cmbUltimoDadoLidoIgnicao_Jsonclick = "";
         cmbUltimoDadoLidoIgnicao.Enabled = 1;
         edtUltimoDadoLidoIdent_Jsonclick = "";
         edtUltimoDadoLidoIdent_Enabled = 1;
         edtUltimoDadoLidoPlaca_Jsonclick = "";
         edtUltimoDadoLidoPlaca_Enabled = 1;
         edtUltimoDadoLidoDataHoraRastreador_Jsonclick = "";
         edtUltimoDadoLidoDataHoraRastreador_Enabled = 1;
         edtUltimoDadoLidoDataHoraServidor_Jsonclick = "";
         edtUltimoDadoLidoDataHoraServidor_Enabled = 1;
         edtUltimoDadoLidoGAMGUIDProprietario_Jsonclick = "";
         edtUltimoDadoLidoGAMGUIDProprietario_Enabled = 0;
         edtUltimoDadoLidoId_Jsonclick = "";
         edtUltimoDadoLidoId_Enabled = 0;
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
         cmbUltimoDadoLidoIgnicao.Name = "ULTIMODADOLIDOIGNICAO";
         cmbUltimoDadoLidoIgnicao.WebTags = "";
         cmbUltimoDadoLidoIgnicao.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 1, 0)), "Selecione", 0);
         cmbUltimoDadoLidoIgnicao.addItem("1", "ON", 0);
         cmbUltimoDadoLidoIgnicao.addItem("2", "OFF", 0);
         if ( cmbUltimoDadoLidoIgnicao.ItemCount > 0 )
         {
            A122UltimoDadoLidoIgnicao = (short)(NumberUtil.Val( cmbUltimoDadoLidoIgnicao.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0))), "."));
            AssignAttri("", false, "A122UltimoDadoLidoIgnicao", StringUtil.Str( (decimal)(A122UltimoDadoLidoIgnicao), 1, 0));
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

      public void Valid_Ultimodadolidoplaca( )
      {
         n153UltimoDadoLidoGAMGUIDProprietario = false;
         /* Using cursor T000J14 */
         pr_default.execute(12, new Object[] {A121UltimoDadoLidoPlaca});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A153UltimoDadoLidoGAMGUIDProprietario = T000J14_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = T000J14_n153UltimoDadoLidoGAMGUIDProprietario[0];
         }
         else
         {
            A153UltimoDadoLidoGAMGUIDProprietario = "";
            n153UltimoDadoLidoGAMGUIDProprietario = false;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A153UltimoDadoLidoGAMGUIDProprietario", StringUtil.RTrim( A153UltimoDadoLidoGAMGUIDProprietario));
      }

      public void Valid_Ultimodadolidoident( )
      {
         /* Using cursor T000J16 */
         pr_default.execute(14, new Object[] {A126UltimoDadoLidoIdent, A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Número do Rastreador"}), 1, "ULTIMODADOLIDOIDENT");
            AnyError = 1;
            GX_FocusControl = edtUltimoDadoLidoIdent_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7UltimoDadoLidoId',fld:'vULTIMODADOLIDOID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7UltimoDadoLidoId',fld:'vULTIMODADOLIDOID',pic:'ZZZZZZZ9',hsh:true},{av:'A118UltimoDadoLidoId',fld:'ULTIMODADOLIDOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ULTIMODADOLIDOID","{handler:'Valid_Ultimodadolidoid',iparms:[]");
         setEventMetadata("VALID_ULTIMODADOLIDOID",",oparms:[]}");
         setEventMetadata("VALID_ULTIMODADOLIDODATAHORASERVIDOR","{handler:'Valid_Ultimodadolidodatahoraservidor',iparms:[]");
         setEventMetadata("VALID_ULTIMODADOLIDODATAHORASERVIDOR",",oparms:[]}");
         setEventMetadata("VALID_ULTIMODADOLIDODATAHORARASTREADOR","{handler:'Valid_Ultimodadolidodatahorarastreador',iparms:[]");
         setEventMetadata("VALID_ULTIMODADOLIDODATAHORARASTREADOR",",oparms:[]}");
         setEventMetadata("VALID_ULTIMODADOLIDOPLACA","{handler:'Valid_Ultimodadolidoplaca',iparms:[{av:'A121UltimoDadoLidoPlaca',fld:'ULTIMODADOLIDOPLACA',pic:''},{av:'A153UltimoDadoLidoGAMGUIDProprietario',fld:'ULTIMODADOLIDOGAMGUIDPROPRIETARIO',pic:''}]");
         setEventMetadata("VALID_ULTIMODADOLIDOPLACA",",oparms:[{av:'A153UltimoDadoLidoGAMGUIDProprietario',fld:'ULTIMODADOLIDOGAMGUIDPROPRIETARIO',pic:''}]}");
         setEventMetadata("VALID_ULTIMODADOLIDOIDENT","{handler:'Valid_Ultimodadolidoident',iparms:[{av:'A126UltimoDadoLidoIdent',fld:'ULTIMODADOLIDOIDENT',pic:'ZZZZZZZZZZZZZZZ9'},{av:'A118UltimoDadoLidoId',fld:'ULTIMODADOLIDOID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_ULTIMODADOLIDOIDENT",",oparms:[]}");
         setEventMetadata("VALID_ULTIMODADOLIDOIGNICAO","{handler:'Valid_Ultimodadolidoignicao',iparms:[]");
         setEventMetadata("VALID_ULTIMODADOLIDOIGNICAO",",oparms:[]}");
         setEventMetadata("VALID_ULTIMODADOLIDOLATITUDE","{handler:'Valid_Ultimodadolidolatitude',iparms:[]");
         setEventMetadata("VALID_ULTIMODADOLIDOLATITUDE",",oparms:[]}");
         setEventMetadata("VALID_ULTIMODADOLIDOLONGITUDE","{handler:'Valid_Ultimodadolidolongitude',iparms:[]");
         setEventMetadata("VALID_ULTIMODADOLIDOLONGITUDE",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         Z120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         Z121UltimoDadoLidoPlaca = "";
         Z123UltimoDadoLidoLatitude = "";
         Z124UltimoDadoLidoLongitude = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A121UltimoDadoLidoPlaca = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A153UltimoDadoLidoGAMGUIDProprietario = "";
         TempTags = "";
         A119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         A120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         A123UltimoDadoLidoLatitude = "";
         A124UltimoDadoLidoLongitude = "";
         A127UltimoDadoLidoGeolocalizacao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode20 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z153UltimoDadoLidoGAMGUIDProprietario = "";
         T000J5_A98VeiculoId = new int[1] ;
         T000J5_A118UltimoDadoLidoId = new int[1] ;
         T000J5_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         T000J5_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         T000J5_A121UltimoDadoLidoPlaca = new string[] {""} ;
         T000J5_A126UltimoDadoLidoIdent = new long[1] ;
         T000J5_A122UltimoDadoLidoIgnicao = new short[1] ;
         T000J5_A125UltimoDadoLidoVelocidade = new short[1] ;
         T000J5_A123UltimoDadoLidoLatitude = new string[] {""} ;
         T000J5_A124UltimoDadoLidoLongitude = new string[] {""} ;
         T000J5_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         T000J5_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         T000J6_A126UltimoDadoLidoIdent = new long[1] ;
         T000J4_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         T000J4_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         T000J7_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         T000J7_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         T000J8_A118UltimoDadoLidoId = new int[1] ;
         T000J3_A118UltimoDadoLidoId = new int[1] ;
         T000J3_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         T000J3_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         T000J3_A121UltimoDadoLidoPlaca = new string[] {""} ;
         T000J3_A126UltimoDadoLidoIdent = new long[1] ;
         T000J3_A122UltimoDadoLidoIgnicao = new short[1] ;
         T000J3_A125UltimoDadoLidoVelocidade = new short[1] ;
         T000J3_A123UltimoDadoLidoLatitude = new string[] {""} ;
         T000J3_A124UltimoDadoLidoLongitude = new string[] {""} ;
         T000J9_A118UltimoDadoLidoId = new int[1] ;
         T000J10_A118UltimoDadoLidoId = new int[1] ;
         T000J2_A118UltimoDadoLidoId = new int[1] ;
         T000J2_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         T000J2_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         T000J2_A121UltimoDadoLidoPlaca = new string[] {""} ;
         T000J2_A126UltimoDadoLidoIdent = new long[1] ;
         T000J2_A122UltimoDadoLidoIgnicao = new short[1] ;
         T000J2_A125UltimoDadoLidoVelocidade = new short[1] ;
         T000J2_A123UltimoDadoLidoLatitude = new string[] {""} ;
         T000J2_A124UltimoDadoLidoLongitude = new string[] {""} ;
         T000J11_A118UltimoDadoLidoId = new int[1] ;
         T000J14_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         T000J14_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         T000J15_A118UltimoDadoLidoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000J16_A126UltimoDadoLidoIdent = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ultimodadolido__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ultimodadolido__default(),
            new Object[][] {
                new Object[] {
               T000J2_A118UltimoDadoLidoId, T000J2_A119UltimoDadoLidoDataHoraServidor, T000J2_A120UltimoDadoLidoDataHoraRastreador, T000J2_A121UltimoDadoLidoPlaca, T000J2_A126UltimoDadoLidoIdent, T000J2_A122UltimoDadoLidoIgnicao, T000J2_A125UltimoDadoLidoVelocidade, T000J2_A123UltimoDadoLidoLatitude, T000J2_A124UltimoDadoLidoLongitude
               }
               , new Object[] {
               T000J3_A118UltimoDadoLidoId, T000J3_A119UltimoDadoLidoDataHoraServidor, T000J3_A120UltimoDadoLidoDataHoraRastreador, T000J3_A121UltimoDadoLidoPlaca, T000J3_A126UltimoDadoLidoIdent, T000J3_A122UltimoDadoLidoIgnicao, T000J3_A125UltimoDadoLidoVelocidade, T000J3_A123UltimoDadoLidoLatitude, T000J3_A124UltimoDadoLidoLongitude
               }
               , new Object[] {
               T000J4_A153UltimoDadoLidoGAMGUIDProprietario, T000J4_n153UltimoDadoLidoGAMGUIDProprietario
               }
               , new Object[] {
               T000J5_A98VeiculoId, T000J5_A118UltimoDadoLidoId, T000J5_A119UltimoDadoLidoDataHoraServidor, T000J5_A120UltimoDadoLidoDataHoraRastreador, T000J5_A121UltimoDadoLidoPlaca, T000J5_A126UltimoDadoLidoIdent, T000J5_A122UltimoDadoLidoIgnicao, T000J5_A125UltimoDadoLidoVelocidade, T000J5_A123UltimoDadoLidoLatitude, T000J5_A124UltimoDadoLidoLongitude,
               T000J5_A153UltimoDadoLidoGAMGUIDProprietario, T000J5_n153UltimoDadoLidoGAMGUIDProprietario
               }
               , new Object[] {
               T000J6_A126UltimoDadoLidoIdent
               }
               , new Object[] {
               T000J7_A153UltimoDadoLidoGAMGUIDProprietario, T000J7_n153UltimoDadoLidoGAMGUIDProprietario
               }
               , new Object[] {
               T000J8_A118UltimoDadoLidoId
               }
               , new Object[] {
               T000J9_A118UltimoDadoLidoId
               }
               , new Object[] {
               T000J10_A118UltimoDadoLidoId
               }
               , new Object[] {
               T000J11_A118UltimoDadoLidoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J14_A153UltimoDadoLidoGAMGUIDProprietario, T000J14_n153UltimoDadoLidoGAMGUIDProprietario
               }
               , new Object[] {
               T000J15_A118UltimoDadoLidoId
               }
               , new Object[] {
               T000J16_A126UltimoDadoLidoIdent
               }
            }
         );
      }

      private short Z122UltimoDadoLidoIgnicao ;
      private short Z125UltimoDadoLidoVelocidade ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A122UltimoDadoLidoIgnicao ;
      private short A125UltimoDadoLidoVelocidade ;
      private short RcdFound20 ;
      private short GX_JID ;
      private short nIsDirty_20 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7UltimoDadoLidoId ;
      private int Z118UltimoDadoLidoId ;
      private int AV7UltimoDadoLidoId ;
      private int trnEnded ;
      private int A118UltimoDadoLidoId ;
      private int edtUltimoDadoLidoId_Enabled ;
      private int edtUltimoDadoLidoGAMGUIDProprietario_Enabled ;
      private int edtUltimoDadoLidoDataHoraServidor_Enabled ;
      private int edtUltimoDadoLidoDataHoraRastreador_Enabled ;
      private int edtUltimoDadoLidoPlaca_Enabled ;
      private int edtUltimoDadoLidoIdent_Enabled ;
      private int edtUltimoDadoLidoVelocidade_Enabled ;
      private int edtUltimoDadoLidoLatitude_Enabled ;
      private int edtUltimoDadoLidoLongitude_Enabled ;
      private int edtUltimoDadoLidoGeolocalizacao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long Z126UltimoDadoLidoIdent ;
      private long A126UltimoDadoLidoIdent ;
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
      private string edtUltimoDadoLidoDataHoraServidor_Internalname ;
      private string cmbUltimoDadoLidoIgnicao_Internalname ;
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
      private string edtUltimoDadoLidoId_Internalname ;
      private string edtUltimoDadoLidoId_Jsonclick ;
      private string edtUltimoDadoLidoGAMGUIDProprietario_Internalname ;
      private string A153UltimoDadoLidoGAMGUIDProprietario ;
      private string edtUltimoDadoLidoGAMGUIDProprietario_Jsonclick ;
      private string TempTags ;
      private string edtUltimoDadoLidoDataHoraServidor_Jsonclick ;
      private string edtUltimoDadoLidoDataHoraRastreador_Internalname ;
      private string edtUltimoDadoLidoDataHoraRastreador_Jsonclick ;
      private string edtUltimoDadoLidoPlaca_Internalname ;
      private string edtUltimoDadoLidoPlaca_Jsonclick ;
      private string edtUltimoDadoLidoIdent_Internalname ;
      private string edtUltimoDadoLidoIdent_Jsonclick ;
      private string cmbUltimoDadoLidoIgnicao_Jsonclick ;
      private string edtUltimoDadoLidoVelocidade_Internalname ;
      private string edtUltimoDadoLidoVelocidade_Jsonclick ;
      private string edtUltimoDadoLidoLatitude_Internalname ;
      private string edtUltimoDadoLidoLatitude_Jsonclick ;
      private string edtUltimoDadoLidoLongitude_Internalname ;
      private string edtUltimoDadoLidoLongitude_Jsonclick ;
      private string edtUltimoDadoLidoGeolocalizacao_Internalname ;
      private string edtUltimoDadoLidoGeolocalizacao_Jsonclick ;
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
      private string sMode20 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z153UltimoDadoLidoGAMGUIDProprietario ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z119UltimoDadoLidoDataHoraServidor ;
      private DateTime Z120UltimoDadoLidoDataHoraRastreador ;
      private DateTime A119UltimoDadoLidoDataHoraServidor ;
      private DateTime A120UltimoDadoLidoDataHoraRastreador ;
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
      private bool n153UltimoDadoLidoGAMGUIDProprietario ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z121UltimoDadoLidoPlaca ;
      private string Z123UltimoDadoLidoLatitude ;
      private string Z124UltimoDadoLidoLongitude ;
      private string A121UltimoDadoLidoPlaca ;
      private string A123UltimoDadoLidoLatitude ;
      private string A124UltimoDadoLidoLongitude ;
      private string A127UltimoDadoLidoGeolocalizacao ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUltimoDadoLidoIgnicao ;
      private IDataStoreProvider pr_default ;
      private int[] T000J5_A98VeiculoId ;
      private int[] T000J5_A118UltimoDadoLidoId ;
      private DateTime[] T000J5_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] T000J5_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] T000J5_A121UltimoDadoLidoPlaca ;
      private long[] T000J5_A126UltimoDadoLidoIdent ;
      private short[] T000J5_A122UltimoDadoLidoIgnicao ;
      private short[] T000J5_A125UltimoDadoLidoVelocidade ;
      private string[] T000J5_A123UltimoDadoLidoLatitude ;
      private string[] T000J5_A124UltimoDadoLidoLongitude ;
      private string[] T000J5_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] T000J5_n153UltimoDadoLidoGAMGUIDProprietario ;
      private long[] T000J6_A126UltimoDadoLidoIdent ;
      private string[] T000J4_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] T000J4_n153UltimoDadoLidoGAMGUIDProprietario ;
      private string[] T000J7_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] T000J7_n153UltimoDadoLidoGAMGUIDProprietario ;
      private int[] T000J8_A118UltimoDadoLidoId ;
      private int[] T000J3_A118UltimoDadoLidoId ;
      private DateTime[] T000J3_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] T000J3_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] T000J3_A121UltimoDadoLidoPlaca ;
      private long[] T000J3_A126UltimoDadoLidoIdent ;
      private short[] T000J3_A122UltimoDadoLidoIgnicao ;
      private short[] T000J3_A125UltimoDadoLidoVelocidade ;
      private string[] T000J3_A123UltimoDadoLidoLatitude ;
      private string[] T000J3_A124UltimoDadoLidoLongitude ;
      private int[] T000J9_A118UltimoDadoLidoId ;
      private int[] T000J10_A118UltimoDadoLidoId ;
      private int[] T000J2_A118UltimoDadoLidoId ;
      private DateTime[] T000J2_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] T000J2_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] T000J2_A121UltimoDadoLidoPlaca ;
      private long[] T000J2_A126UltimoDadoLidoIdent ;
      private short[] T000J2_A122UltimoDadoLidoIgnicao ;
      private short[] T000J2_A125UltimoDadoLidoVelocidade ;
      private string[] T000J2_A123UltimoDadoLidoLatitude ;
      private string[] T000J2_A124UltimoDadoLidoLongitude ;
      private int[] T000J11_A118UltimoDadoLidoId ;
      private string[] T000J14_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] T000J14_n153UltimoDadoLidoGAMGUIDProprietario ;
      private int[] T000J15_A118UltimoDadoLidoId ;
      private long[] T000J16_A126UltimoDadoLidoIdent ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class ultimodadolido__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class ultimodadolido__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
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
        Object[] prmT000J5;
        prmT000J5 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J6;
        prmT000J6 = new Object[] {
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0} ,
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J4;
        prmT000J4 = new Object[] {
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0}
        };
        Object[] prmT000J7;
        prmT000J7 = new Object[] {
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0}
        };
        Object[] prmT000J8;
        prmT000J8 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J3;
        prmT000J3 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J9;
        prmT000J9 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J10;
        prmT000J10 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J2;
        prmT000J2 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J11;
        prmT000J11 = new Object[] {
        new Object[] {"@UltimoDadoLidoDataHoraServidor",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoDataHoraRastreador",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0} ,
        new Object[] {"@UltimoDadoLidoIgnicao",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@UltimoDadoLidoVelocidade",SqlDbType.SmallInt,3,0} ,
        new Object[] {"@UltimoDadoLidoLatitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoLongitude",SqlDbType.NVarChar,50,0}
        };
        Object[] prmT000J12;
        prmT000J12 = new Object[] {
        new Object[] {"@UltimoDadoLidoDataHoraServidor",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoDataHoraRastreador",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0} ,
        new Object[] {"@UltimoDadoLidoIgnicao",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@UltimoDadoLidoVelocidade",SqlDbType.SmallInt,3,0} ,
        new Object[] {"@UltimoDadoLidoLatitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoLongitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J13;
        prmT000J13 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmT000J15;
        prmT000J15 = new Object[] {
        };
        Object[] prmT000J14;
        prmT000J14 = new Object[] {
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0}
        };
        Object[] prmT000J16;
        prmT000J16 = new Object[] {
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0} ,
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000J2", "SELECT [UltimoDadoLidoId], [UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoPlaca], [UltimoDadoLidoIdent], [UltimoDadoLidoIgnicao], [UltimoDadoLidoVelocidade], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude] FROM [UltimoDadoLido] WITH (UPDLOCK) WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J3", "SELECT [UltimoDadoLidoId], [UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoPlaca], [UltimoDadoLidoIdent], [UltimoDadoLidoIgnicao], [UltimoDadoLidoVelocidade], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude] FROM [UltimoDadoLido] WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J4", "SELECT COALESCE( [VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM [Veiculo] WHERE [VeiculoPlaca] = @UltimoDadoLidoPlaca ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J5", "SELECT T2.[VeiculoId], TM1.[UltimoDadoLidoId], TM1.[UltimoDadoLidoDataHoraServidor], TM1.[UltimoDadoLidoDataHoraRastreador], TM1.[UltimoDadoLidoPlaca], TM1.[UltimoDadoLidoIdent], TM1.[UltimoDadoLidoIgnicao], TM1.[UltimoDadoLidoVelocidade], TM1.[UltimoDadoLidoLatitude], TM1.[UltimoDadoLidoLongitude], COALESCE( T2.[VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM ([UltimoDadoLido] TM1 LEFT JOIN [Veiculo] T2 ON T2.[VeiculoPlaca] = TM1.[UltimoDadoLidoPlaca]) WHERE TM1.[UltimoDadoLidoId] = @UltimoDadoLidoId ORDER BY TM1.[UltimoDadoLidoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J6", "SELECT [UltimoDadoLidoIdent] FROM [UltimoDadoLido] WHERE ([UltimoDadoLidoIdent] = @UltimoDadoLidoIdent) AND (Not ( [UltimoDadoLidoId] = @UltimoDadoLidoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J7", "SELECT COALESCE( [VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM [Veiculo] WHERE [VeiculoPlaca] = @UltimoDadoLidoPlaca ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J8", "SELECT [UltimoDadoLidoId] FROM [UltimoDadoLido] WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J9", "SELECT TOP 1 [UltimoDadoLidoId] FROM [UltimoDadoLido] WHERE ( [UltimoDadoLidoId] > @UltimoDadoLidoId) ORDER BY [UltimoDadoLidoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J10", "SELECT TOP 1 [UltimoDadoLidoId] FROM [UltimoDadoLido] WHERE ( [UltimoDadoLidoId] < @UltimoDadoLidoId) ORDER BY [UltimoDadoLidoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J11", "INSERT INTO [UltimoDadoLido]([UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoPlaca], [UltimoDadoLidoIdent], [UltimoDadoLidoIgnicao], [UltimoDadoLidoVelocidade], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude]) VALUES(@UltimoDadoLidoDataHoraServidor, @UltimoDadoLidoDataHoraRastreador, @UltimoDadoLidoPlaca, @UltimoDadoLidoIdent, @UltimoDadoLidoIgnicao, @UltimoDadoLidoVelocidade, @UltimoDadoLidoLatitude, @UltimoDadoLidoLongitude); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000J11)
           ,new CursorDef("T000J12", "UPDATE [UltimoDadoLido] SET [UltimoDadoLidoDataHoraServidor]=@UltimoDadoLidoDataHoraServidor, [UltimoDadoLidoDataHoraRastreador]=@UltimoDadoLidoDataHoraRastreador, [UltimoDadoLidoPlaca]=@UltimoDadoLidoPlaca, [UltimoDadoLidoIdent]=@UltimoDadoLidoIdent, [UltimoDadoLidoIgnicao]=@UltimoDadoLidoIgnicao, [UltimoDadoLidoVelocidade]=@UltimoDadoLidoVelocidade, [UltimoDadoLidoLatitude]=@UltimoDadoLidoLatitude, [UltimoDadoLidoLongitude]=@UltimoDadoLidoLongitude  WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId", GxErrorMask.GX_NOMASK,prmT000J12)
           ,new CursorDef("T000J13", "DELETE FROM [UltimoDadoLido]  WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId", GxErrorMask.GX_NOMASK,prmT000J13)
           ,new CursorDef("T000J14", "SELECT COALESCE( [VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM [Veiculo] WHERE [VeiculoPlaca] = @UltimoDadoLidoPlaca ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J15", "SELECT [UltimoDadoLidoId] FROM [UltimoDadoLido] ORDER BY [UltimoDadoLidoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J16", "SELECT [UltimoDadoLidoIdent] FROM [UltimoDadoLido] WHERE ([UltimoDadoLidoIdent] = @UltimoDadoLidoIdent) AND (Not ( [UltimoDadoLidoId] = @UltimoDadoLidoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J16,1, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLong(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getShort(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLong(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getShort(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 2 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.wasNull(1);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getGXDateTime(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLong(6);
              table[6][0] = rslt.getShort(7);
              table[7][0] = rslt.getShort(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getString(11, 40);
              table[11][0] = rslt.wasNull(11);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.wasNull(1);
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
           case 9 :
              table[0][0] = rslt.getInt(1);
              return;
           case 12 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.wasNull(1);
              return;
           case 13 :
              table[0][0] = rslt.getInt(1);
              return;
           case 14 :
              table[0][0] = rslt.getLong(1);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
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
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (long)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameter(6, (short)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              return;
           case 10 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (long)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameter(6, (short)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (int)parms[8]);
              return;
           case 11 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 14 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
