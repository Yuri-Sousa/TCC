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
   public class mqttparametros : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
               AV7MqttParametrosId = (int)(NumberUtil.Val( GetPar( "MqttParametrosId"), "."));
               AssignAttri("", false, "AV7MqttParametrosId", StringUtil.LTrimStr( (decimal)(AV7MqttParametrosId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vMQTTPARAMETROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MqttParametrosId), "ZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Parâmetros Mqtt", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public mqttparametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public mqttparametros( IGxContext context )
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
                           int aP1_MqttParametrosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MqttParametrosId = aP1_MqttParametrosId;
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
            return "mqttparametros_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttParametrosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttParametrosId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMqttParametrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A129MqttParametrosId), 8, 0, ",", "")), ((edtMqttParametrosId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A129MqttParametrosId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A129MqttParametrosId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttParametrosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttParametrosId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttParametrosTokenFlespi_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttParametrosTokenFlespi_Internalname, "Token Flespi", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMqttParametrosTokenFlespi_Internalname, A130MqttParametrosTokenFlespi, StringUtil.RTrim( context.localUtil.Format( A130MqttParametrosTokenFlespi, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttParametrosTokenFlespi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttParametrosTokenFlespi_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttParametrosClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttParametrosClientId_Internalname, "ClientId", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMqttParametrosClientId_Internalname, A132MqttParametrosClientId, StringUtil.RTrim( context.localUtil.Format( A132MqttParametrosClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttParametrosClientId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttParametrosClientId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttParametrosPortaBroker_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttParametrosPortaBroker_Internalname, "Porta Broker", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMqttParametrosPortaBroker_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133MqttParametrosPortaBroker), 4, 0, ",", "")), ((edtMqttParametrosPortaBroker_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A133MqttParametrosPortaBroker), "ZZZ9")) : context.localUtil.Format( (decimal)(A133MqttParametrosPortaBroker), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttParametrosPortaBroker_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttParametrosPortaBroker_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttParametrosURLBroker_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttParametrosURLBroker_Internalname, "URL Broker", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMqttParametrosURLBroker_Internalname, A134MqttParametrosURLBroker, StringUtil.RTrim( context.localUtil.Format( A134MqttParametrosURLBroker, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", A134MqttParametrosURLBroker, "_blank", "", "", edtMqttParametrosURLBroker_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttParametrosURLBroker_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttParametrosCanalFlespi_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttParametrosCanalFlespi_Internalname, "Canal Flespi", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMqttParametrosCanalFlespi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135MqttParametrosCanalFlespi), 10, 0, ",", "")), ((edtMqttParametrosCanalFlespi_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A135MqttParametrosCanalFlespi), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A135MqttParametrosCanalFlespi), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMqttParametrosCanalFlespi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMqttParametrosCanalFlespi_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMqttParametrosJSONSubscribe_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMqttParametrosJSONSubscribe_Internalname, "JSON Subscribe", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMqttParametrosJSONSubscribe_Internalname, A131MqttParametrosJSONSubscribe, "", "", 0, 1, edtMqttParametrosJSONSubscribe_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_MqttParametros.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MqttParametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MqttParametros.htm");
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
         E110L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z129MqttParametrosId = (int)(context.localUtil.CToN( cgiGet( "Z129MqttParametrosId"), ",", "."));
               Z130MqttParametrosTokenFlespi = cgiGet( "Z130MqttParametrosTokenFlespi");
               Z132MqttParametrosClientId = cgiGet( "Z132MqttParametrosClientId");
               Z133MqttParametrosPortaBroker = (short)(context.localUtil.CToN( cgiGet( "Z133MqttParametrosPortaBroker"), ",", "."));
               Z134MqttParametrosURLBroker = cgiGet( "Z134MqttParametrosURLBroker");
               Z135MqttParametrosCanalFlespi = (long)(context.localUtil.CToN( cgiGet( "Z135MqttParametrosCanalFlespi"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7MqttParametrosId = (int)(context.localUtil.CToN( cgiGet( "vMQTTPARAMETROSID"), ",", "."));
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
               A129MqttParametrosId = (int)(context.localUtil.CToN( cgiGet( edtMqttParametrosId_Internalname), ",", "."));
               AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
               A130MqttParametrosTokenFlespi = cgiGet( edtMqttParametrosTokenFlespi_Internalname);
               AssignAttri("", false, "A130MqttParametrosTokenFlespi", A130MqttParametrosTokenFlespi);
               A132MqttParametrosClientId = cgiGet( edtMqttParametrosClientId_Internalname);
               AssignAttri("", false, "A132MqttParametrosClientId", A132MqttParametrosClientId);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMqttParametrosPortaBroker_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMqttParametrosPortaBroker_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MQTTPARAMETROSPORTABROKER");
                  AnyError = 1;
                  GX_FocusControl = edtMqttParametrosPortaBroker_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A133MqttParametrosPortaBroker = 0;
                  AssignAttri("", false, "A133MqttParametrosPortaBroker", StringUtil.LTrimStr( (decimal)(A133MqttParametrosPortaBroker), 4, 0));
               }
               else
               {
                  A133MqttParametrosPortaBroker = (short)(context.localUtil.CToN( cgiGet( edtMqttParametrosPortaBroker_Internalname), ",", "."));
                  AssignAttri("", false, "A133MqttParametrosPortaBroker", StringUtil.LTrimStr( (decimal)(A133MqttParametrosPortaBroker), 4, 0));
               }
               A134MqttParametrosURLBroker = cgiGet( edtMqttParametrosURLBroker_Internalname);
               AssignAttri("", false, "A134MqttParametrosURLBroker", A134MqttParametrosURLBroker);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMqttParametrosCanalFlespi_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMqttParametrosCanalFlespi_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MQTTPARAMETROSCANALFLESPI");
                  AnyError = 1;
                  GX_FocusControl = edtMqttParametrosCanalFlespi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A135MqttParametrosCanalFlespi = 0;
                  AssignAttri("", false, "A135MqttParametrosCanalFlespi", StringUtil.LTrimStr( (decimal)(A135MqttParametrosCanalFlespi), 10, 0));
               }
               else
               {
                  A135MqttParametrosCanalFlespi = (long)(context.localUtil.CToN( cgiGet( edtMqttParametrosCanalFlespi_Internalname), ",", "."));
                  AssignAttri("", false, "A135MqttParametrosCanalFlespi", StringUtil.LTrimStr( (decimal)(A135MqttParametrosCanalFlespi), 10, 0));
               }
               A131MqttParametrosJSONSubscribe = cgiGet( edtMqttParametrosJSONSubscribe_Internalname);
               AssignAttri("", false, "A131MqttParametrosJSONSubscribe", A131MqttParametrosJSONSubscribe);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MqttParametros");
               A129MqttParametrosId = (int)(context.localUtil.CToN( cgiGet( edtMqttParametrosId_Internalname), ",", "."));
               AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
               forbiddenHiddens.Add("MqttParametrosId", context.localUtil.Format( (decimal)(A129MqttParametrosId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A131MqttParametrosJSONSubscribe = cgiGet( edtMqttParametrosJSONSubscribe_Internalname);
               AssignAttri("", false, "A131MqttParametrosJSONSubscribe", A131MqttParametrosJSONSubscribe);
               forbiddenHiddens.Add("MqttParametrosJSONSubscribe", A131MqttParametrosJSONSubscribe);
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A129MqttParametrosId != Z129MqttParametrosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("mqttparametros:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A129MqttParametrosId = (int)(NumberUtil.Val( GetPar( "MqttParametrosId"), "."));
                  AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
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
                     sMode22 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode22;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound22 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MQTTPARAMETROSID");
                        AnyError = 1;
                        GX_FocusControl = edtMqttParametrosId_Internalname;
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
                           E110L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120L2 ();
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
            E120L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0L22( ) ;
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
            DisableAttributes0L22( ) ;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L22( ) ;
            }
            else
            {
               CheckExtendedTable0L22( ) ;
               CloseExtendedTableCursors0L22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0L0( )
      {
      }

      protected void E110L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E120L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("mqttparametrosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0L22( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z130MqttParametrosTokenFlespi = T000L3_A130MqttParametrosTokenFlespi[0];
               Z132MqttParametrosClientId = T000L3_A132MqttParametrosClientId[0];
               Z133MqttParametrosPortaBroker = T000L3_A133MqttParametrosPortaBroker[0];
               Z134MqttParametrosURLBroker = T000L3_A134MqttParametrosURLBroker[0];
               Z135MqttParametrosCanalFlespi = T000L3_A135MqttParametrosCanalFlespi[0];
            }
            else
            {
               Z130MqttParametrosTokenFlespi = A130MqttParametrosTokenFlespi;
               Z132MqttParametrosClientId = A132MqttParametrosClientId;
               Z133MqttParametrosPortaBroker = A133MqttParametrosPortaBroker;
               Z134MqttParametrosURLBroker = A134MqttParametrosURLBroker;
               Z135MqttParametrosCanalFlespi = A135MqttParametrosCanalFlespi;
            }
         }
         if ( GX_JID == -10 )
         {
            Z129MqttParametrosId = A129MqttParametrosId;
            Z130MqttParametrosTokenFlespi = A130MqttParametrosTokenFlespi;
            Z131MqttParametrosJSONSubscribe = A131MqttParametrosJSONSubscribe;
            Z132MqttParametrosClientId = A132MqttParametrosClientId;
            Z133MqttParametrosPortaBroker = A133MqttParametrosPortaBroker;
            Z134MqttParametrosURLBroker = A134MqttParametrosURLBroker;
            Z135MqttParametrosCanalFlespi = A135MqttParametrosCanalFlespi;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMqttParametrosId_Enabled = 0;
         AssignProp("", false, edtMqttParametrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosId_Enabled), 5, 0), true);
         edtMqttParametrosJSONSubscribe_Enabled = 0;
         AssignProp("", false, edtMqttParametrosJSONSubscribe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosJSONSubscribe_Enabled), 5, 0), true);
         edtMqttParametrosId_Enabled = 0;
         AssignProp("", false, edtMqttParametrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosId_Enabled), 5, 0), true);
         edtMqttParametrosJSONSubscribe_Enabled = 0;
         AssignProp("", false, edtMqttParametrosJSONSubscribe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosJSONSubscribe_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MqttParametrosId) )
         {
            A129MqttParametrosId = AV7MqttParametrosId;
            AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
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

      protected void Load0L22( )
      {
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {A129MqttParametrosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A130MqttParametrosTokenFlespi = T000L4_A130MqttParametrosTokenFlespi[0];
            AssignAttri("", false, "A130MqttParametrosTokenFlespi", A130MqttParametrosTokenFlespi);
            A131MqttParametrosJSONSubscribe = T000L4_A131MqttParametrosJSONSubscribe[0];
            AssignAttri("", false, "A131MqttParametrosJSONSubscribe", A131MqttParametrosJSONSubscribe);
            A132MqttParametrosClientId = T000L4_A132MqttParametrosClientId[0];
            AssignAttri("", false, "A132MqttParametrosClientId", A132MqttParametrosClientId);
            A133MqttParametrosPortaBroker = T000L4_A133MqttParametrosPortaBroker[0];
            AssignAttri("", false, "A133MqttParametrosPortaBroker", StringUtil.LTrimStr( (decimal)(A133MqttParametrosPortaBroker), 4, 0));
            A134MqttParametrosURLBroker = T000L4_A134MqttParametrosURLBroker[0];
            AssignAttri("", false, "A134MqttParametrosURLBroker", A134MqttParametrosURLBroker);
            A135MqttParametrosCanalFlespi = T000L4_A135MqttParametrosCanalFlespi[0];
            AssignAttri("", false, "A135MqttParametrosCanalFlespi", StringUtil.LTrimStr( (decimal)(A135MqttParametrosCanalFlespi), 10, 0));
            ZM0L22( -10) ;
         }
         pr_default.close(2);
         OnLoadActions0L22( ) ;
      }

      protected void OnLoadActions0L22( )
      {
      }

      protected void CheckExtendedTable0L22( )
      {
         nIsDirty_22 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A130MqttParametrosTokenFlespi)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Token Flespi", "", "", "", "", "", "", "", ""), 1, "MQTTPARAMETROSTOKENFLESPI");
            AnyError = 1;
            GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A132MqttParametrosClientId)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ClientId", "", "", "", "", "", "", "", ""), 1, "MQTTPARAMETROSCLIENTID");
            AnyError = 1;
            GX_FocusControl = edtMqttParametrosClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A133MqttParametrosPortaBroker) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Porta Broker", "", "", "", "", "", "", "", ""), 1, "MQTTPARAMETROSPORTABROKER");
            AnyError = 1;
            GX_FocusControl = edtMqttParametrosPortaBroker_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A134MqttParametrosURLBroker,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de URL Broker não coincide com o padrão especificado", "OutOfRange", 1, "MQTTPARAMETROSURLBROKER");
            AnyError = 1;
            GX_FocusControl = edtMqttParametrosURLBroker_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A134MqttParametrosURLBroker)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "URL Broker", "", "", "", "", "", "", "", ""), 1, "MQTTPARAMETROSURLBROKER");
            AnyError = 1;
            GX_FocusControl = edtMqttParametrosURLBroker_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A135MqttParametrosCanalFlespi) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Canal Flespi", "", "", "", "", "", "", "", ""), 1, "MQTTPARAMETROSCANALFLESPI");
            AnyError = 1;
            GX_FocusControl = edtMqttParametrosCanalFlespi_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0L22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L22( )
      {
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A129MqttParametrosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A129MqttParametrosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L22( 10) ;
            RcdFound22 = 1;
            A129MqttParametrosId = T000L3_A129MqttParametrosId[0];
            AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
            A130MqttParametrosTokenFlespi = T000L3_A130MqttParametrosTokenFlespi[0];
            AssignAttri("", false, "A130MqttParametrosTokenFlespi", A130MqttParametrosTokenFlespi);
            A131MqttParametrosJSONSubscribe = T000L3_A131MqttParametrosJSONSubscribe[0];
            AssignAttri("", false, "A131MqttParametrosJSONSubscribe", A131MqttParametrosJSONSubscribe);
            A132MqttParametrosClientId = T000L3_A132MqttParametrosClientId[0];
            AssignAttri("", false, "A132MqttParametrosClientId", A132MqttParametrosClientId);
            A133MqttParametrosPortaBroker = T000L3_A133MqttParametrosPortaBroker[0];
            AssignAttri("", false, "A133MqttParametrosPortaBroker", StringUtil.LTrimStr( (decimal)(A133MqttParametrosPortaBroker), 4, 0));
            A134MqttParametrosURLBroker = T000L3_A134MqttParametrosURLBroker[0];
            AssignAttri("", false, "A134MqttParametrosURLBroker", A134MqttParametrosURLBroker);
            A135MqttParametrosCanalFlespi = T000L3_A135MqttParametrosCanalFlespi[0];
            AssignAttri("", false, "A135MqttParametrosCanalFlespi", StringUtil.LTrimStr( (decimal)(A135MqttParametrosCanalFlespi), 10, 0));
            Z129MqttParametrosId = A129MqttParametrosId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0L22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0L22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0L22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L22( ) ;
         if ( RcdFound22 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound22 = 0;
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A129MqttParametrosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A129MqttParametrosId[0] < A129MqttParametrosId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A129MqttParametrosId[0] > A129MqttParametrosId ) ) )
            {
               A129MqttParametrosId = T000L6_A129MqttParametrosId[0];
               AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {A129MqttParametrosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A129MqttParametrosId[0] > A129MqttParametrosId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A129MqttParametrosId[0] < A129MqttParametrosId ) ) )
            {
               A129MqttParametrosId = T000L7_A129MqttParametrosId[0];
               AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A129MqttParametrosId != Z129MqttParametrosId )
               {
                  A129MqttParametrosId = Z129MqttParametrosId;
                  AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MQTTPARAMETROSID");
                  AnyError = 1;
                  GX_FocusControl = edtMqttParametrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0L22( ) ;
                  GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A129MqttParametrosId != Z129MqttParametrosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MQTTPARAMETROSID");
                     AnyError = 1;
                     GX_FocusControl = edtMqttParametrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L22( ) ;
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
         if ( A129MqttParametrosId != Z129MqttParametrosId )
         {
            A129MqttParametrosId = Z129MqttParametrosId;
            AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MQTTPARAMETROSID");
            AnyError = 1;
            GX_FocusControl = edtMqttParametrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMqttParametrosTokenFlespi_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0L22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A129MqttParametrosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MqttParametros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z130MqttParametrosTokenFlespi, T000L2_A130MqttParametrosTokenFlespi[0]) != 0 ) || ( StringUtil.StrCmp(Z132MqttParametrosClientId, T000L2_A132MqttParametrosClientId[0]) != 0 ) || ( Z133MqttParametrosPortaBroker != T000L2_A133MqttParametrosPortaBroker[0] ) || ( StringUtil.StrCmp(Z134MqttParametrosURLBroker, T000L2_A134MqttParametrosURLBroker[0]) != 0 ) || ( Z135MqttParametrosCanalFlespi != T000L2_A135MqttParametrosCanalFlespi[0] ) )
            {
               if ( StringUtil.StrCmp(Z130MqttParametrosTokenFlespi, T000L2_A130MqttParametrosTokenFlespi[0]) != 0 )
               {
                  GXUtil.WriteLog("mqttparametros:[seudo value changed for attri]"+"MqttParametrosTokenFlespi");
                  GXUtil.WriteLogRaw("Old: ",Z130MqttParametrosTokenFlespi);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A130MqttParametrosTokenFlespi[0]);
               }
               if ( StringUtil.StrCmp(Z132MqttParametrosClientId, T000L2_A132MqttParametrosClientId[0]) != 0 )
               {
                  GXUtil.WriteLog("mqttparametros:[seudo value changed for attri]"+"MqttParametrosClientId");
                  GXUtil.WriteLogRaw("Old: ",Z132MqttParametrosClientId);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A132MqttParametrosClientId[0]);
               }
               if ( Z133MqttParametrosPortaBroker != T000L2_A133MqttParametrosPortaBroker[0] )
               {
                  GXUtil.WriteLog("mqttparametros:[seudo value changed for attri]"+"MqttParametrosPortaBroker");
                  GXUtil.WriteLogRaw("Old: ",Z133MqttParametrosPortaBroker);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A133MqttParametrosPortaBroker[0]);
               }
               if ( StringUtil.StrCmp(Z134MqttParametrosURLBroker, T000L2_A134MqttParametrosURLBroker[0]) != 0 )
               {
                  GXUtil.WriteLog("mqttparametros:[seudo value changed for attri]"+"MqttParametrosURLBroker");
                  GXUtil.WriteLogRaw("Old: ",Z134MqttParametrosURLBroker);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A134MqttParametrosURLBroker[0]);
               }
               if ( Z135MqttParametrosCanalFlespi != T000L2_A135MqttParametrosCanalFlespi[0] )
               {
                  GXUtil.WriteLog("mqttparametros:[seudo value changed for attri]"+"MqttParametrosCanalFlespi");
                  GXUtil.WriteLogRaw("Old: ",Z135MqttParametrosCanalFlespi);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A135MqttParametrosCanalFlespi[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MqttParametros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L22( )
      {
         if ( ! IsAuthorized("mqttparametros_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L22( 0) ;
            CheckOptimisticConcurrency0L22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L8 */
                     pr_default.execute(6, new Object[] {A130MqttParametrosTokenFlespi, A131MqttParametrosJSONSubscribe, A132MqttParametrosClientId, A133MqttParametrosPortaBroker, A134MqttParametrosURLBroker, A135MqttParametrosCanalFlespi});
                     A129MqttParametrosId = T000L8_A129MqttParametrosId[0];
                     AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("MqttParametros");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0L0( ) ;
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
               Load0L22( ) ;
            }
            EndLevel0L22( ) ;
         }
         CloseExtendedTableCursors0L22( ) ;
      }

      protected void Update0L22( )
      {
         if ( ! IsAuthorized("mqttparametros_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L9 */
                     pr_default.execute(7, new Object[] {A130MqttParametrosTokenFlespi, A131MqttParametrosJSONSubscribe, A132MqttParametrosClientId, A133MqttParametrosPortaBroker, A134MqttParametrosURLBroker, A135MqttParametrosCanalFlespi, A129MqttParametrosId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("MqttParametros");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MqttParametros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L22( ) ;
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
            EndLevel0L22( ) ;
         }
         CloseExtendedTableCursors0L22( ) ;
      }

      protected void DeferredUpdate0L22( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("mqttparametros_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L22( ) ;
            AfterConfirm0L22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L10 */
                  pr_default.execute(8, new Object[] {A129MqttParametrosId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("MqttParametros");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0L22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("mqttparametros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("mqttparametros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L22( )
      {
         /* Scan By routine */
         /* Using cursor T000L11 */
         pr_default.execute(9);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A129MqttParametrosId = T000L11_A129MqttParametrosId[0];
            AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L22( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A129MqttParametrosId = T000L11_A129MqttParametrosId[0];
            AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
         }
      }

      protected void ScanEnd0L22( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0L22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L22( )
      {
         edtMqttParametrosId_Enabled = 0;
         AssignProp("", false, edtMqttParametrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosId_Enabled), 5, 0), true);
         edtMqttParametrosTokenFlespi_Enabled = 0;
         AssignProp("", false, edtMqttParametrosTokenFlespi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosTokenFlespi_Enabled), 5, 0), true);
         edtMqttParametrosClientId_Enabled = 0;
         AssignProp("", false, edtMqttParametrosClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosClientId_Enabled), 5, 0), true);
         edtMqttParametrosPortaBroker_Enabled = 0;
         AssignProp("", false, edtMqttParametrosPortaBroker_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosPortaBroker_Enabled), 5, 0), true);
         edtMqttParametrosURLBroker_Enabled = 0;
         AssignProp("", false, edtMqttParametrosURLBroker_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosURLBroker_Enabled), 5, 0), true);
         edtMqttParametrosCanalFlespi_Enabled = 0;
         AssignProp("", false, edtMqttParametrosCanalFlespi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosCanalFlespi_Enabled), 5, 0), true);
         edtMqttParametrosJSONSubscribe_Enabled = 0;
         AssignProp("", false, edtMqttParametrosJSONSubscribe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMqttParametrosJSONSubscribe_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815492630", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mqttparametros.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MqttParametrosId,8,0))}, new string[] {"Gx_mode","MqttParametrosId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"MqttParametros");
         forbiddenHiddens.Add("MqttParametrosId", context.localUtil.Format( (decimal)(A129MqttParametrosId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("MqttParametrosJSONSubscribe", A131MqttParametrosJSONSubscribe);
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("mqttparametros:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z129MqttParametrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z129MqttParametrosId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z130MqttParametrosTokenFlespi", Z130MqttParametrosTokenFlespi);
         GxWebStd.gx_hidden_field( context, "Z132MqttParametrosClientId", Z132MqttParametrosClientId);
         GxWebStd.gx_hidden_field( context, "Z133MqttParametrosPortaBroker", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133MqttParametrosPortaBroker), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z134MqttParametrosURLBroker", Z134MqttParametrosURLBroker);
         GxWebStd.gx_hidden_field( context, "Z135MqttParametrosCanalFlespi", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135MqttParametrosCanalFlespi), 10, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vMQTTPARAMETROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MqttParametrosId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMQTTPARAMETROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MqttParametrosId), "ZZZZZZZ9"), context));
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
         return formatLink("mqttparametros.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MqttParametrosId,8,0))}, new string[] {"Gx_mode","MqttParametrosId"})  ;
      }

      public override string GetPgmname( )
      {
         return "MqttParametros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parâmetros Mqtt" ;
      }

      protected void InitializeNonKey0L22( )
      {
         A130MqttParametrosTokenFlespi = "";
         AssignAttri("", false, "A130MqttParametrosTokenFlespi", A130MqttParametrosTokenFlespi);
         A131MqttParametrosJSONSubscribe = "";
         AssignAttri("", false, "A131MqttParametrosJSONSubscribe", A131MqttParametrosJSONSubscribe);
         A132MqttParametrosClientId = "";
         AssignAttri("", false, "A132MqttParametrosClientId", A132MqttParametrosClientId);
         A133MqttParametrosPortaBroker = 0;
         AssignAttri("", false, "A133MqttParametrosPortaBroker", StringUtil.LTrimStr( (decimal)(A133MqttParametrosPortaBroker), 4, 0));
         A134MqttParametrosURLBroker = "";
         AssignAttri("", false, "A134MqttParametrosURLBroker", A134MqttParametrosURLBroker);
         A135MqttParametrosCanalFlespi = 0;
         AssignAttri("", false, "A135MqttParametrosCanalFlespi", StringUtil.LTrimStr( (decimal)(A135MqttParametrosCanalFlespi), 10, 0));
         Z130MqttParametrosTokenFlespi = "";
         Z132MqttParametrosClientId = "";
         Z133MqttParametrosPortaBroker = 0;
         Z134MqttParametrosURLBroker = "";
         Z135MqttParametrosCanalFlespi = 0;
      }

      protected void InitAll0L22( )
      {
         A129MqttParametrosId = 0;
         AssignAttri("", false, "A129MqttParametrosId", StringUtil.LTrimStr( (decimal)(A129MqttParametrosId), 8, 0));
         InitializeNonKey0L22( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815492657", true, true);
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
         context.AddJavascriptSource("mqttparametros.js", "?202142815492657", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMqttParametrosId_Internalname = "MQTTPARAMETROSID";
         edtMqttParametrosTokenFlespi_Internalname = "MQTTPARAMETROSTOKENFLESPI";
         edtMqttParametrosClientId_Internalname = "MQTTPARAMETROSCLIENTID";
         edtMqttParametrosPortaBroker_Internalname = "MQTTPARAMETROSPORTABROKER";
         edtMqttParametrosURLBroker_Internalname = "MQTTPARAMETROSURLBROKER";
         edtMqttParametrosCanalFlespi_Internalname = "MQTTPARAMETROSCANALFLESPI";
         edtMqttParametrosJSONSubscribe_Internalname = "MQTTPARAMETROSJSONSUBSCRIBE";
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
         Form.Caption = "Parâmetros Mqtt";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMqttParametrosJSONSubscribe_Enabled = 0;
         edtMqttParametrosCanalFlespi_Jsonclick = "";
         edtMqttParametrosCanalFlespi_Enabled = 1;
         edtMqttParametrosURLBroker_Jsonclick = "";
         edtMqttParametrosURLBroker_Enabled = 1;
         edtMqttParametrosPortaBroker_Jsonclick = "";
         edtMqttParametrosPortaBroker_Enabled = 1;
         edtMqttParametrosClientId_Jsonclick = "";
         edtMqttParametrosClientId_Enabled = 1;
         edtMqttParametrosTokenFlespi_Jsonclick = "";
         edtMqttParametrosTokenFlespi_Enabled = 1;
         edtMqttParametrosId_Jsonclick = "";
         edtMqttParametrosId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MqttParametrosId',fld:'vMQTTPARAMETROSID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MqttParametrosId',fld:'vMQTTPARAMETROSID',pic:'ZZZZZZZ9',hsh:true},{av:'A129MqttParametrosId',fld:'MQTTPARAMETROSID',pic:'ZZZZZZZ9'},{av:'A131MqttParametrosJSONSubscribe',fld:'MQTTPARAMETROSJSONSUBSCRIBE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120L2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MQTTPARAMETROSID","{handler:'Valid_Mqttparametrosid',iparms:[]");
         setEventMetadata("VALID_MQTTPARAMETROSID",",oparms:[]}");
         setEventMetadata("VALID_MQTTPARAMETROSTOKENFLESPI","{handler:'Valid_Mqttparametrostokenflespi',iparms:[]");
         setEventMetadata("VALID_MQTTPARAMETROSTOKENFLESPI",",oparms:[]}");
         setEventMetadata("VALID_MQTTPARAMETROSCLIENTID","{handler:'Valid_Mqttparametrosclientid',iparms:[]");
         setEventMetadata("VALID_MQTTPARAMETROSCLIENTID",",oparms:[]}");
         setEventMetadata("VALID_MQTTPARAMETROSPORTABROKER","{handler:'Valid_Mqttparametrosportabroker',iparms:[]");
         setEventMetadata("VALID_MQTTPARAMETROSPORTABROKER",",oparms:[]}");
         setEventMetadata("VALID_MQTTPARAMETROSURLBROKER","{handler:'Valid_Mqttparametrosurlbroker',iparms:[]");
         setEventMetadata("VALID_MQTTPARAMETROSURLBROKER",",oparms:[]}");
         setEventMetadata("VALID_MQTTPARAMETROSCANALFLESPI","{handler:'Valid_Mqttparametroscanalflespi',iparms:[]");
         setEventMetadata("VALID_MQTTPARAMETROSCANALFLESPI",",oparms:[]}");
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
         Z130MqttParametrosTokenFlespi = "";
         Z132MqttParametrosClientId = "";
         Z134MqttParametrosURLBroker = "";
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
         TempTags = "";
         A130MqttParametrosTokenFlespi = "";
         A132MqttParametrosClientId = "";
         A134MqttParametrosURLBroker = "";
         A131MqttParametrosJSONSubscribe = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode22 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z131MqttParametrosJSONSubscribe = "";
         T000L4_A129MqttParametrosId = new int[1] ;
         T000L4_A130MqttParametrosTokenFlespi = new string[] {""} ;
         T000L4_A131MqttParametrosJSONSubscribe = new string[] {""} ;
         T000L4_A132MqttParametrosClientId = new string[] {""} ;
         T000L4_A133MqttParametrosPortaBroker = new short[1] ;
         T000L4_A134MqttParametrosURLBroker = new string[] {""} ;
         T000L4_A135MqttParametrosCanalFlespi = new long[1] ;
         T000L5_A129MqttParametrosId = new int[1] ;
         T000L3_A129MqttParametrosId = new int[1] ;
         T000L3_A130MqttParametrosTokenFlespi = new string[] {""} ;
         T000L3_A131MqttParametrosJSONSubscribe = new string[] {""} ;
         T000L3_A132MqttParametrosClientId = new string[] {""} ;
         T000L3_A133MqttParametrosPortaBroker = new short[1] ;
         T000L3_A134MqttParametrosURLBroker = new string[] {""} ;
         T000L3_A135MqttParametrosCanalFlespi = new long[1] ;
         T000L6_A129MqttParametrosId = new int[1] ;
         T000L7_A129MqttParametrosId = new int[1] ;
         T000L2_A129MqttParametrosId = new int[1] ;
         T000L2_A130MqttParametrosTokenFlespi = new string[] {""} ;
         T000L2_A131MqttParametrosJSONSubscribe = new string[] {""} ;
         T000L2_A132MqttParametrosClientId = new string[] {""} ;
         T000L2_A133MqttParametrosPortaBroker = new short[1] ;
         T000L2_A134MqttParametrosURLBroker = new string[] {""} ;
         T000L2_A135MqttParametrosCanalFlespi = new long[1] ;
         T000L8_A129MqttParametrosId = new int[1] ;
         T000L11_A129MqttParametrosId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.mqttparametros__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mqttparametros__default(),
            new Object[][] {
                new Object[] {
               T000L2_A129MqttParametrosId, T000L2_A130MqttParametrosTokenFlespi, T000L2_A131MqttParametrosJSONSubscribe, T000L2_A132MqttParametrosClientId, T000L2_A133MqttParametrosPortaBroker, T000L2_A134MqttParametrosURLBroker, T000L2_A135MqttParametrosCanalFlespi
               }
               , new Object[] {
               T000L3_A129MqttParametrosId, T000L3_A130MqttParametrosTokenFlespi, T000L3_A131MqttParametrosJSONSubscribe, T000L3_A132MqttParametrosClientId, T000L3_A133MqttParametrosPortaBroker, T000L3_A134MqttParametrosURLBroker, T000L3_A135MqttParametrosCanalFlespi
               }
               , new Object[] {
               T000L4_A129MqttParametrosId, T000L4_A130MqttParametrosTokenFlespi, T000L4_A131MqttParametrosJSONSubscribe, T000L4_A132MqttParametrosClientId, T000L4_A133MqttParametrosPortaBroker, T000L4_A134MqttParametrosURLBroker, T000L4_A135MqttParametrosCanalFlespi
               }
               , new Object[] {
               T000L5_A129MqttParametrosId
               }
               , new Object[] {
               T000L6_A129MqttParametrosId
               }
               , new Object[] {
               T000L7_A129MqttParametrosId
               }
               , new Object[] {
               T000L8_A129MqttParametrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L11_A129MqttParametrosId
               }
            }
         );
      }

      private short Z133MqttParametrosPortaBroker ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A133MqttParametrosPortaBroker ;
      private short RcdFound22 ;
      private short GX_JID ;
      private short nIsDirty_22 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7MqttParametrosId ;
      private int Z129MqttParametrosId ;
      private int AV7MqttParametrosId ;
      private int trnEnded ;
      private int A129MqttParametrosId ;
      private int edtMqttParametrosId_Enabled ;
      private int edtMqttParametrosTokenFlespi_Enabled ;
      private int edtMqttParametrosClientId_Enabled ;
      private int edtMqttParametrosPortaBroker_Enabled ;
      private int edtMqttParametrosURLBroker_Enabled ;
      private int edtMqttParametrosCanalFlespi_Enabled ;
      private int edtMqttParametrosJSONSubscribe_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long Z135MqttParametrosCanalFlespi ;
      private long A135MqttParametrosCanalFlespi ;
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
      private string edtMqttParametrosTokenFlespi_Internalname ;
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
      private string edtMqttParametrosId_Internalname ;
      private string edtMqttParametrosId_Jsonclick ;
      private string TempTags ;
      private string edtMqttParametrosTokenFlespi_Jsonclick ;
      private string edtMqttParametrosClientId_Internalname ;
      private string edtMqttParametrosClientId_Jsonclick ;
      private string edtMqttParametrosPortaBroker_Internalname ;
      private string edtMqttParametrosPortaBroker_Jsonclick ;
      private string edtMqttParametrosURLBroker_Internalname ;
      private string edtMqttParametrosURLBroker_Jsonclick ;
      private string edtMqttParametrosCanalFlespi_Internalname ;
      private string edtMqttParametrosCanalFlespi_Jsonclick ;
      private string edtMqttParametrosJSONSubscribe_Internalname ;
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
      private string sMode22 ;
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
      private string A131MqttParametrosJSONSubscribe ;
      private string Z131MqttParametrosJSONSubscribe ;
      private string Z130MqttParametrosTokenFlespi ;
      private string Z132MqttParametrosClientId ;
      private string Z134MqttParametrosURLBroker ;
      private string A130MqttParametrosTokenFlespi ;
      private string A132MqttParametrosClientId ;
      private string A134MqttParametrosURLBroker ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000L4_A129MqttParametrosId ;
      private string[] T000L4_A130MqttParametrosTokenFlespi ;
      private string[] T000L4_A131MqttParametrosJSONSubscribe ;
      private string[] T000L4_A132MqttParametrosClientId ;
      private short[] T000L4_A133MqttParametrosPortaBroker ;
      private string[] T000L4_A134MqttParametrosURLBroker ;
      private long[] T000L4_A135MqttParametrosCanalFlespi ;
      private int[] T000L5_A129MqttParametrosId ;
      private int[] T000L3_A129MqttParametrosId ;
      private string[] T000L3_A130MqttParametrosTokenFlespi ;
      private string[] T000L3_A131MqttParametrosJSONSubscribe ;
      private string[] T000L3_A132MqttParametrosClientId ;
      private short[] T000L3_A133MqttParametrosPortaBroker ;
      private string[] T000L3_A134MqttParametrosURLBroker ;
      private long[] T000L3_A135MqttParametrosCanalFlespi ;
      private int[] T000L6_A129MqttParametrosId ;
      private int[] T000L7_A129MqttParametrosId ;
      private int[] T000L2_A129MqttParametrosId ;
      private string[] T000L2_A130MqttParametrosTokenFlespi ;
      private string[] T000L2_A131MqttParametrosJSONSubscribe ;
      private string[] T000L2_A132MqttParametrosClientId ;
      private short[] T000L2_A133MqttParametrosPortaBroker ;
      private string[] T000L2_A134MqttParametrosURLBroker ;
      private long[] T000L2_A135MqttParametrosCanalFlespi ;
      private int[] T000L8_A129MqttParametrosId ;
      private int[] T000L11_A129MqttParametrosId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class mqttparametros__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class mqttparametros__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000L4;
        prmT000L4 = new Object[] {
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L5;
        prmT000L5 = new Object[] {
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L3;
        prmT000L3 = new Object[] {
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L6;
        prmT000L6 = new Object[] {
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L7;
        prmT000L7 = new Object[] {
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L2;
        prmT000L2 = new Object[] {
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L8;
        prmT000L8 = new Object[] {
        new Object[] {"@MqttParametrosTokenFlespi",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@MqttParametrosJSONSubscribe",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@MqttParametrosClientId",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@MqttParametrosPortaBroker",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@MqttParametrosURLBroker",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@MqttParametrosCanalFlespi",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000L9;
        prmT000L9 = new Object[] {
        new Object[] {"@MqttParametrosTokenFlespi",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@MqttParametrosJSONSubscribe",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@MqttParametrosClientId",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@MqttParametrosPortaBroker",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@MqttParametrosURLBroker",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@MqttParametrosCanalFlespi",SqlDbType.Decimal,10,0} ,
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L10;
        prmT000L10 = new Object[] {
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmT000L11;
        prmT000L11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000L2", "SELECT [MqttParametrosId], [MqttParametrosTokenFlespi], [MqttParametrosJSONSubscribe], [MqttParametrosClientId], [MqttParametrosPortaBroker], [MqttParametrosURLBroker], [MqttParametrosCanalFlespi] FROM [MqttParametros] WITH (UPDLOCK) WHERE [MqttParametrosId] = @MqttParametrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L3", "SELECT [MqttParametrosId], [MqttParametrosTokenFlespi], [MqttParametrosJSONSubscribe], [MqttParametrosClientId], [MqttParametrosPortaBroker], [MqttParametrosURLBroker], [MqttParametrosCanalFlespi] FROM [MqttParametros] WHERE [MqttParametrosId] = @MqttParametrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L4", "SELECT TM1.[MqttParametrosId], TM1.[MqttParametrosTokenFlespi], TM1.[MqttParametrosJSONSubscribe], TM1.[MqttParametrosClientId], TM1.[MqttParametrosPortaBroker], TM1.[MqttParametrosURLBroker], TM1.[MqttParametrosCanalFlespi] FROM [MqttParametros] TM1 WHERE TM1.[MqttParametrosId] = @MqttParametrosId ORDER BY TM1.[MqttParametrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L5", "SELECT [MqttParametrosId] FROM [MqttParametros] WHERE [MqttParametrosId] = @MqttParametrosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L6", "SELECT TOP 1 [MqttParametrosId] FROM [MqttParametros] WHERE ( [MqttParametrosId] > @MqttParametrosId) ORDER BY [MqttParametrosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L7", "SELECT TOP 1 [MqttParametrosId] FROM [MqttParametros] WHERE ( [MqttParametrosId] < @MqttParametrosId) ORDER BY [MqttParametrosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L8", "INSERT INTO [MqttParametros]([MqttParametrosTokenFlespi], [MqttParametrosJSONSubscribe], [MqttParametrosClientId], [MqttParametrosPortaBroker], [MqttParametrosURLBroker], [MqttParametrosCanalFlespi]) VALUES(@MqttParametrosTokenFlespi, @MqttParametrosJSONSubscribe, @MqttParametrosClientId, @MqttParametrosPortaBroker, @MqttParametrosURLBroker, @MqttParametrosCanalFlespi); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000L8)
           ,new CursorDef("T000L9", "UPDATE [MqttParametros] SET [MqttParametrosTokenFlespi]=@MqttParametrosTokenFlespi, [MqttParametrosJSONSubscribe]=@MqttParametrosJSONSubscribe, [MqttParametrosClientId]=@MqttParametrosClientId, [MqttParametrosPortaBroker]=@MqttParametrosPortaBroker, [MqttParametrosURLBroker]=@MqttParametrosURLBroker, [MqttParametrosCanalFlespi]=@MqttParametrosCanalFlespi  WHERE [MqttParametrosId] = @MqttParametrosId", GxErrorMask.GX_NOMASK,prmT000L9)
           ,new CursorDef("T000L10", "DELETE FROM [MqttParametros]  WHERE [MqttParametrosId] = @MqttParametrosId", GxErrorMask.GX_NOMASK,prmT000L10)
           ,new CursorDef("T000L11", "SELECT [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L11,100, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getLong(7);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getLong(7);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getLong(7);
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
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (long)parms[5]);
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (long)parms[5]);
              stmt.SetParameter(7, (int)parms[6]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
