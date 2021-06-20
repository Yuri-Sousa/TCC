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
   public class mqttconnection : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
               AV7MqttConnectionId = (int)(NumberUtil.Val( GetPar( "MqttConnectionId"), "."));
               AssignAttri("", false, "AV7MqttConnectionId", StringUtil.LTrimStr( (decimal)(AV7MqttConnectionId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vMQTTCONNECTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MqttConnectionId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Conexão MQTT", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public mqttconnection( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public mqttconnection( IGxContext context )
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
                           int aP1_MqttConnectionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MqttConnectionId = aP1_MqttConnectionId;
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
            return "mqttconnection_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttConnectionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttConnectionId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMqttConnectionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A90MqttConnectionId), 8, 0, ",", "")), ((edtMqttConnectionId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A90MqttConnectionId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A90MqttConnectionId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttConnectionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttConnectionId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_MqttConnection.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttConnectionDataHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttConnectionDataHora_Internalname, "Data/Hora", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtMqttConnectionDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMqttConnectionDataHora_Internalname, context.localUtil.TToC( A91MqttConnectionDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A91MqttConnectionDataHora, "99/99/9999 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttConnectionDataHora_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtMqttConnectionDataHora_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_MqttConnection.htm");
         GxWebStd.gx_bitmap( context, edtMqttConnectionDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMqttConnectionDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_MqttConnection.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttConnectionGUID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttConnectionGUID_Internalname, "GUID da Conexão", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMqttConnectionGUID_Internalname, A92MqttConnectionGUID.ToString(), A92MqttConnectionGUID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttConnectionGUID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttConnectionGUID_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_MqttConnection.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MqttConnection.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MqttConnection.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MqttConnection.htm");
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
         E110D2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z90MqttConnectionId = (int)(context.localUtil.CToN( cgiGet( "Z90MqttConnectionId"), ",", "."));
               Z91MqttConnectionDataHora = context.localUtil.CToT( cgiGet( "Z91MqttConnectionDataHora"), 0);
               Z92MqttConnectionGUID = (Guid)(StringUtil.StrToGuid( cgiGet( "Z92MqttConnectionGUID")));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7MqttConnectionId = (int)(context.localUtil.CToN( cgiGet( "vMQTTCONNECTIONID"), ",", "."));
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
               A90MqttConnectionId = (int)(context.localUtil.CToN( cgiGet( edtMqttConnectionId_Internalname), ",", "."));
               AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
               A91MqttConnectionDataHora = context.localUtil.CToT( cgiGet( edtMqttConnectionDataHora_Internalname));
               AssignAttri("", false, "A91MqttConnectionDataHora", context.localUtil.TToC( A91MqttConnectionDataHora, 10, 5, 0, 3, "/", ":", " "));
               A92MqttConnectionGUID = (Guid)(StringUtil.StrToGuid( cgiGet( edtMqttConnectionGUID_Internalname)));
               AssignAttri("", false, "A92MqttConnectionGUID", A92MqttConnectionGUID.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MqttConnection");
               A90MqttConnectionId = (int)(context.localUtil.CToN( cgiGet( edtMqttConnectionId_Internalname), ",", "."));
               AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
               forbiddenHiddens.Add("MqttConnectionId", context.localUtil.Format( (decimal)(A90MqttConnectionId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A91MqttConnectionDataHora = context.localUtil.CToT( cgiGet( edtMqttConnectionDataHora_Internalname));
               AssignAttri("", false, "A91MqttConnectionDataHora", context.localUtil.TToC( A91MqttConnectionDataHora, 10, 5, 0, 3, "/", ":", " "));
               forbiddenHiddens.Add("MqttConnectionDataHora", context.localUtil.Format( A91MqttConnectionDataHora, "99/99/9999 99:99"));
               A92MqttConnectionGUID = (Guid)(StringUtil.StrToGuid( cgiGet( edtMqttConnectionGUID_Internalname)));
               AssignAttri("", false, "A92MqttConnectionGUID", A92MqttConnectionGUID.ToString());
               forbiddenHiddens.Add("MqttConnectionGUID", A92MqttConnectionGUID.ToString());
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A90MqttConnectionId != Z90MqttConnectionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("mqttconnection:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A90MqttConnectionId = (int)(NumberUtil.Val( GetPar( "MqttConnectionId"), "."));
                  AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
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
                     sMode14 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode14;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound14 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MQTTCONNECTIONID");
                        AnyError = 1;
                        GX_FocusControl = edtMqttConnectionId_Internalname;
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
                           E110D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120D2 ();
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
            E120D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0D14( ) ;
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
            DisableAttributes0D14( ) ;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D14( ) ;
            }
            else
            {
               CheckExtendedTable0D14( ) ;
               CloseExtendedTableCursors0D14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0D0( )
      {
      }

      protected void E110D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E120D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("mqttconnectionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0D14( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z91MqttConnectionDataHora = T000D3_A91MqttConnectionDataHora[0];
               Z92MqttConnectionGUID = (Guid)(T000D3_A92MqttConnectionGUID[0]);
            }
            else
            {
               Z91MqttConnectionDataHora = A91MqttConnectionDataHora;
               Z92MqttConnectionGUID = (Guid)(A92MqttConnectionGUID);
            }
         }
         if ( GX_JID == -5 )
         {
            Z90MqttConnectionId = A90MqttConnectionId;
            Z91MqttConnectionDataHora = A91MqttConnectionDataHora;
            Z92MqttConnectionGUID = (Guid)(A92MqttConnectionGUID);
         }
      }

      protected void standaloneNotModal( )
      {
         edtMqttConnectionId_Enabled = 0;
         AssignProp("", false, edtMqttConnectionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionId_Enabled), 5, 0), true);
         edtMqttConnectionDataHora_Enabled = 0;
         AssignProp("", false, edtMqttConnectionDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionDataHora_Enabled), 5, 0), true);
         edtMqttConnectionGUID_Enabled = 0;
         AssignProp("", false, edtMqttConnectionGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionGUID_Enabled), 5, 0), true);
         edtMqttConnectionId_Enabled = 0;
         AssignProp("", false, edtMqttConnectionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionId_Enabled), 5, 0), true);
         edtMqttConnectionDataHora_Enabled = 0;
         AssignProp("", false, edtMqttConnectionDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionDataHora_Enabled), 5, 0), true);
         edtMqttConnectionGUID_Enabled = 0;
         AssignProp("", false, edtMqttConnectionGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionGUID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MqttConnectionId) )
         {
            A90MqttConnectionId = AV7MqttConnectionId;
            AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
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

      protected void Load0D14( )
      {
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A90MqttConnectionId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound14 = 1;
            A91MqttConnectionDataHora = T000D4_A91MqttConnectionDataHora[0];
            AssignAttri("", false, "A91MqttConnectionDataHora", context.localUtil.TToC( A91MqttConnectionDataHora, 10, 5, 0, 3, "/", ":", " "));
            A92MqttConnectionGUID = (Guid)((Guid)(T000D4_A92MqttConnectionGUID[0]));
            AssignAttri("", false, "A92MqttConnectionGUID", A92MqttConnectionGUID.ToString());
            ZM0D14( -5) ;
         }
         pr_default.close(2);
         OnLoadActions0D14( ) ;
      }

      protected void OnLoadActions0D14( )
      {
      }

      protected void CheckExtendedTable0D14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0D14( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D14( )
      {
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {A90MqttConnectionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {A90MqttConnectionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D14( 5) ;
            RcdFound14 = 1;
            A90MqttConnectionId = T000D3_A90MqttConnectionId[0];
            AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
            A91MqttConnectionDataHora = T000D3_A91MqttConnectionDataHora[0];
            AssignAttri("", false, "A91MqttConnectionDataHora", context.localUtil.TToC( A91MqttConnectionDataHora, 10, 5, 0, 3, "/", ":", " "));
            A92MqttConnectionGUID = (Guid)((Guid)(T000D3_A92MqttConnectionGUID[0]));
            AssignAttri("", false, "A92MqttConnectionGUID", A92MqttConnectionGUID.ToString());
            Z90MqttConnectionId = A90MqttConnectionId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0D14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0D14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0D14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D14( ) ;
         if ( RcdFound14 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D6 */
         pr_default.execute(4, new Object[] {A90MqttConnectionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000D6_A90MqttConnectionId[0] < A90MqttConnectionId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000D6_A90MqttConnectionId[0] > A90MqttConnectionId ) ) )
            {
               A90MqttConnectionId = T000D6_A90MqttConnectionId[0];
               AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A90MqttConnectionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000D7_A90MqttConnectionId[0] > A90MqttConnectionId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000D7_A90MqttConnectionId[0] < A90MqttConnectionId ) ) )
            {
               A90MqttConnectionId = T000D7_A90MqttConnectionId[0];
               AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A90MqttConnectionId != Z90MqttConnectionId )
               {
                  A90MqttConnectionId = Z90MqttConnectionId;
                  AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MQTTCONNECTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtMqttConnectionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  /* Update record */
                  Update0D14( ) ;
               }
            }
            else
            {
               if ( A90MqttConnectionId != Z90MqttConnectionId )
               {
                  /* Insert record */
                  Insert0D14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MQTTCONNECTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtMqttConnectionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     Insert0D14( ) ;
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
         if ( A90MqttConnectionId != Z90MqttConnectionId )
         {
            A90MqttConnectionId = Z90MqttConnectionId;
            AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MQTTCONNECTIONID");
            AnyError = 1;
            GX_FocusControl = edtMqttConnectionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0D14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {A90MqttConnectionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MqttConnection"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z91MqttConnectionDataHora != T000D2_A91MqttConnectionDataHora[0] ) || ( Z92MqttConnectionGUID != T000D2_A92MqttConnectionGUID[0] ) )
            {
               if ( Z91MqttConnectionDataHora != T000D2_A91MqttConnectionDataHora[0] )
               {
                  GXUtil.WriteLog("mqttconnection:[seudo value changed for attri]"+"MqttConnectionDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z91MqttConnectionDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A91MqttConnectionDataHora[0]);
               }
               if ( Z92MqttConnectionGUID != T000D2_A92MqttConnectionGUID[0] )
               {
                  GXUtil.WriteLog("mqttconnection:[seudo value changed for attri]"+"MqttConnectionGUID");
                  GXUtil.WriteLogRaw("Old: ",Z92MqttConnectionGUID);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A92MqttConnectionGUID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MqttConnection"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D14( )
      {
         if ( ! IsAuthorized("mqttconnection_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D14( 0) ;
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D8 */
                     pr_default.execute(6, new Object[] {A91MqttConnectionDataHora, A92MqttConnectionGUID});
                     A90MqttConnectionId = T000D8_A90MqttConnectionId[0];
                     AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("MqttConnection");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0D0( ) ;
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
               Load0D14( ) ;
            }
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void Update0D14( )
      {
         if ( ! IsAuthorized("mqttconnection_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D9 */
                     pr_default.execute(7, new Object[] {A91MqttConnectionDataHora, A92MqttConnectionGUID, A90MqttConnectionId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("MqttConnection");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MqttConnection"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D14( ) ;
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
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void DeferredUpdate0D14( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("mqttconnection_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D14( ) ;
            AfterConfirm0D14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D10 */
                  pr_default.execute(8, new Object[] {A90MqttConnectionId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("MqttConnection");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D14( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0D14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("mqttconnection",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("mqttconnection",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D14( )
      {
         /* Scan By routine */
         /* Using cursor T000D11 */
         pr_default.execute(9);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound14 = 1;
            A90MqttConnectionId = T000D11_A90MqttConnectionId[0];
            AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D14( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound14 = 1;
            A90MqttConnectionId = T000D11_A90MqttConnectionId[0];
            AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
         }
      }

      protected void ScanEnd0D14( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0D14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D14( )
      {
         edtMqttConnectionId_Enabled = 0;
         AssignProp("", false, edtMqttConnectionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionId_Enabled), 5, 0), true);
         edtMqttConnectionDataHora_Enabled = 0;
         AssignProp("", false, edtMqttConnectionDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionDataHora_Enabled), 5, 0), true);
         edtMqttConnectionGUID_Enabled = 0;
         AssignProp("", false, edtMqttConnectionGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttConnectionGUID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815483021", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mqttconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MqttConnectionId,8,0))}, new string[] {"Gx_mode","MqttConnectionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"MqttConnection");
         forbiddenHiddens.Add("MqttConnectionId", context.localUtil.Format( (decimal)(A90MqttConnectionId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("MqttConnectionDataHora", context.localUtil.Format( A91MqttConnectionDataHora, "99/99/9999 99:99"));
         forbiddenHiddens.Add("MqttConnectionGUID", A92MqttConnectionGUID.ToString());
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("mqttconnection:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z90MqttConnectionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z90MqttConnectionId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z91MqttConnectionDataHora", context.localUtil.TToC( Z91MqttConnectionDataHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z92MqttConnectionGUID", Z92MqttConnectionGUID.ToString());
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
         GxWebStd.gx_hidden_field( context, "vMQTTCONNECTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MqttConnectionId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMQTTCONNECTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MqttConnectionId), "ZZZZZZZ9"), context));
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
         return formatLink("mqttconnection.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MqttConnectionId,8,0))}, new string[] {"Gx_mode","MqttConnectionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "MqttConnection" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conexão MQTT" ;
      }

      protected void InitializeNonKey0D14( )
      {
         A91MqttConnectionDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A91MqttConnectionDataHora", context.localUtil.TToC( A91MqttConnectionDataHora, 10, 5, 0, 3, "/", ":", " "));
         A92MqttConnectionGUID = (Guid)(Guid.Empty);
         AssignAttri("", false, "A92MqttConnectionGUID", A92MqttConnectionGUID.ToString());
         Z91MqttConnectionDataHora = (DateTime)(DateTime.MinValue);
         Z92MqttConnectionGUID = (Guid)(Guid.Empty);
      }

      protected void InitAll0D14( )
      {
         A90MqttConnectionId = 0;
         AssignAttri("", false, "A90MqttConnectionId", StringUtil.LTrimStr( (decimal)(A90MqttConnectionId), 8, 0));
         InitializeNonKey0D14( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815483044", true, true);
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
         context.AddJavascriptSource("mqttconnection.js", "?202142815483045", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMqttConnectionId_Internalname = "MQTTCONNECTIONID";
         edtMqttConnectionDataHora_Internalname = "MQTTCONNECTIONDATAHORA";
         edtMqttConnectionGUID_Internalname = "MQTTCONNECTIONGUID";
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
         Form.Caption = "Conexão MQTT";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMqttConnectionGUID_Jsonclick = "";
         edtMqttConnectionGUID_Enabled = 0;
         edtMqttConnectionDataHora_Jsonclick = "";
         edtMqttConnectionDataHora_Enabled = 0;
         edtMqttConnectionId_Jsonclick = "";
         edtMqttConnectionId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MqttConnectionId',fld:'vMQTTCONNECTIONID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MqttConnectionId',fld:'vMQTTCONNECTIONID',pic:'ZZZZZZZ9',hsh:true},{av:'A90MqttConnectionId',fld:'MQTTCONNECTIONID',pic:'ZZZZZZZ9'},{av:'A91MqttConnectionDataHora',fld:'MQTTCONNECTIONDATAHORA',pic:'99/99/9999 99:99'},{av:'A92MqttConnectionGUID',fld:'MQTTCONNECTIONGUID',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120D2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MQTTCONNECTIONID","{handler:'Valid_Mqttconnectionid',iparms:[]");
         setEventMetadata("VALID_MQTTCONNECTIONID",",oparms:[]}");
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
         Z91MqttConnectionDataHora = (DateTime)(DateTime.MinValue);
         Z92MqttConnectionGUID = (Guid)(Guid.Empty);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A91MqttConnectionDataHora = (DateTime)(DateTime.MinValue);
         A92MqttConnectionGUID = (Guid)(Guid.Empty);
         TempTags = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode14 = "";
         GX_FocusControl = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000D4_A90MqttConnectionId = new int[1] ;
         T000D4_A91MqttConnectionDataHora = new DateTime[] {DateTime.MinValue} ;
         T000D4_A92MqttConnectionGUID = new Guid[] {Guid.Empty} ;
         T000D5_A90MqttConnectionId = new int[1] ;
         T000D3_A90MqttConnectionId = new int[1] ;
         T000D3_A91MqttConnectionDataHora = new DateTime[] {DateTime.MinValue} ;
         T000D3_A92MqttConnectionGUID = new Guid[] {Guid.Empty} ;
         T000D6_A90MqttConnectionId = new int[1] ;
         T000D7_A90MqttConnectionId = new int[1] ;
         T000D2_A90MqttConnectionId = new int[1] ;
         T000D2_A91MqttConnectionDataHora = new DateTime[] {DateTime.MinValue} ;
         T000D2_A92MqttConnectionGUID = new Guid[] {Guid.Empty} ;
         T000D8_A90MqttConnectionId = new int[1] ;
         T000D11_A90MqttConnectionId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.mqttconnection__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mqttconnection__default(),
            new Object[][] {
                new Object[] {
               T000D2_A90MqttConnectionId, T000D2_A91MqttConnectionDataHora, T000D2_A92MqttConnectionGUID
               }
               , new Object[] {
               T000D3_A90MqttConnectionId, T000D3_A91MqttConnectionDataHora, T000D3_A92MqttConnectionGUID
               }
               , new Object[] {
               T000D4_A90MqttConnectionId, T000D4_A91MqttConnectionDataHora, T000D4_A92MqttConnectionGUID
               }
               , new Object[] {
               T000D5_A90MqttConnectionId
               }
               , new Object[] {
               T000D6_A90MqttConnectionId
               }
               , new Object[] {
               T000D7_A90MqttConnectionId
               }
               , new Object[] {
               T000D8_A90MqttConnectionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D11_A90MqttConnectionId
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
      private short RcdFound14 ;
      private short GX_JID ;
      private short nIsDirty_14 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7MqttConnectionId ;
      private int Z90MqttConnectionId ;
      private int AV7MqttConnectionId ;
      private int trnEnded ;
      private int A90MqttConnectionId ;
      private int edtMqttConnectionId_Enabled ;
      private int edtMqttConnectionDataHora_Enabled ;
      private int edtMqttConnectionGUID_Enabled ;
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
      private string edtMqttConnectionId_Internalname ;
      private string edtMqttConnectionId_Jsonclick ;
      private string edtMqttConnectionDataHora_Internalname ;
      private string edtMqttConnectionDataHora_Jsonclick ;
      private string edtMqttConnectionGUID_Internalname ;
      private string edtMqttConnectionGUID_Jsonclick ;
      private string TempTags ;
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
      private string sMode14 ;
      private string GX_FocusControl ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z91MqttConnectionDataHora ;
      private DateTime A91MqttConnectionDataHora ;
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
      private Guid Z92MqttConnectionGUID ;
      private Guid A92MqttConnectionGUID ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000D4_A90MqttConnectionId ;
      private DateTime[] T000D4_A91MqttConnectionDataHora ;
      private Guid[] T000D4_A92MqttConnectionGUID ;
      private int[] T000D5_A90MqttConnectionId ;
      private int[] T000D3_A90MqttConnectionId ;
      private DateTime[] T000D3_A91MqttConnectionDataHora ;
      private Guid[] T000D3_A92MqttConnectionGUID ;
      private int[] T000D6_A90MqttConnectionId ;
      private int[] T000D7_A90MqttConnectionId ;
      private int[] T000D2_A90MqttConnectionId ;
      private DateTime[] T000D2_A91MqttConnectionDataHora ;
      private Guid[] T000D2_A92MqttConnectionGUID ;
      private int[] T000D8_A90MqttConnectionId ;
      private int[] T000D11_A90MqttConnectionId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class mqttconnection__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class mqttconnection__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000D4;
        prmT000D4 = new Object[] {
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D5;
        prmT000D5 = new Object[] {
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D3;
        prmT000D3 = new Object[] {
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D6;
        prmT000D6 = new Object[] {
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D7;
        prmT000D7 = new Object[] {
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D2;
        prmT000D2 = new Object[] {
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D8;
        prmT000D8 = new Object[] {
        new Object[] {"@MqttConnectionDataHora",SqlDbType.DateTime,10,5} ,
        new Object[] {"@MqttConnectionGUID",SqlDbType.UniqueIdentifier,4,0}
        };
        Object[] prmT000D9;
        prmT000D9 = new Object[] {
        new Object[] {"@MqttConnectionDataHora",SqlDbType.DateTime,10,5} ,
        new Object[] {"@MqttConnectionGUID",SqlDbType.UniqueIdentifier,4,0} ,
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D10;
        prmT000D10 = new Object[] {
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmT000D11;
        prmT000D11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000D2", "SELECT [MqttConnectionId], [MqttConnectionDataHora], [MqttConnectionGUID] FROM [MqttConnection] WITH (UPDLOCK) WHERE [MqttConnectionId] = @MqttConnectionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D3", "SELECT [MqttConnectionId], [MqttConnectionDataHora], [MqttConnectionGUID] FROM [MqttConnection] WHERE [MqttConnectionId] = @MqttConnectionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D4", "SELECT TM1.[MqttConnectionId], TM1.[MqttConnectionDataHora], TM1.[MqttConnectionGUID] FROM [MqttConnection] TM1 WHERE TM1.[MqttConnectionId] = @MqttConnectionId ORDER BY TM1.[MqttConnectionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D5", "SELECT [MqttConnectionId] FROM [MqttConnection] WHERE [MqttConnectionId] = @MqttConnectionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D6", "SELECT TOP 1 [MqttConnectionId] FROM [MqttConnection] WHERE ( [MqttConnectionId] > @MqttConnectionId) ORDER BY [MqttConnectionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D7", "SELECT TOP 1 [MqttConnectionId] FROM [MqttConnection] WHERE ( [MqttConnectionId] < @MqttConnectionId) ORDER BY [MqttConnectionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D8", "INSERT INTO [MqttConnection]([MqttConnectionDataHora], [MqttConnectionGUID]) VALUES(@MqttConnectionDataHora, @MqttConnectionGUID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000D8)
           ,new CursorDef("T000D9", "UPDATE [MqttConnection] SET [MqttConnectionDataHora]=@MqttConnectionDataHora, [MqttConnectionGUID]=@MqttConnectionGUID  WHERE [MqttConnectionId] = @MqttConnectionId", GxErrorMask.GX_NOMASK,prmT000D9)
           ,new CursorDef("T000D10", "DELETE FROM [MqttConnection]  WHERE [MqttConnectionId] = @MqttConnectionId", GxErrorMask.GX_NOMASK,prmT000D10)
           ,new CursorDef("T000D11", "SELECT [MqttConnectionId] FROM [MqttConnection] ORDER BY [MqttConnectionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,100, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getGuid(3);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getGuid(3);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getGuid(3);
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
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (Guid)parms[1]);
              return;
           case 7 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (Guid)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
