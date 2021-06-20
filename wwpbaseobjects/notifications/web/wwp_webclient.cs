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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webclient : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A1WWPUserExtendedId) ;
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
            Form.Meta.addItem("description", "WWP_Web Client", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_webclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_webclient( IGxContext context )
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
         cmbWWPWebClientBrowserId = new GXCombobox();
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
            return "webclient_Execute" ;
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
         if ( cmbWWPWebClientBrowserId.ItemCount > 0 )
         {
            A43WWPWebClientBrowserId = (short)(NumberUtil.Val( cmbWWPWebClientBrowserId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0))), "."));
            AssignAttri("", false, "A43WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0));
            AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Values", cmbWWPWebClientBrowserId.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Web Client", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientId_Internalname, "Client Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebClientId_Internalname, StringUtil.RTrim( A18WWPWebClientId), StringUtil.RTrim( context.localUtil.Format( A18WWPWebClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebClientId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebClientId_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbWWPWebClientBrowserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPWebClientBrowserId_Internalname, "Browser Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPWebClientBrowserId, cmbWWPWebClientBrowserId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0)), 1, cmbWWPWebClientBrowserId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPWebClientBrowserId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0));
         AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Values", (string)(cmbWWPWebClientBrowserId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebClientBrowserVersion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientBrowserVersion_Internalname, "Browser Version", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebClientBrowserVersion_Internalname, A44WWPWebClientBrowserVersion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtWWPWebClientBrowserVersion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebClientFirstRegistered_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientFirstRegistered_Internalname, "First Registered", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebClientFirstRegistered_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebClientFirstRegistered_Internalname, context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A45WWPWebClientFirstRegistered, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebClientFirstRegistered_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebClientFirstRegistered_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebClientFirstRegistered_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebClientFirstRegistered_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebClientLastRegistered_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientLastRegistered_Internalname, "Last Registered", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebClientLastRegistered_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebClientLastRegistered_Internalname, context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A46WWPWebClientLastRegistered, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebClientLastRegistered_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebClientLastRegistered_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebClientLastRegistered_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebClientLastRegistered_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, "User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebClient.htm");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z18WWPWebClientId = cgiGet( "Z18WWPWebClientId");
            Z43WWPWebClientBrowserId = (short)(context.localUtil.CToN( cgiGet( "Z43WWPWebClientBrowserId"), ",", "."));
            Z45WWPWebClientFirstRegistered = context.localUtil.CToT( cgiGet( "Z45WWPWebClientFirstRegistered"), 0);
            Z46WWPWebClientLastRegistered = context.localUtil.CToT( cgiGet( "Z46WWPWebClientLastRegistered"), 0);
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
            /* Read variables values. */
            A18WWPWebClientId = cgiGet( edtWWPWebClientId_Internalname);
            AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
            cmbWWPWebClientBrowserId.CurrentValue = cgiGet( cmbWWPWebClientBrowserId_Internalname);
            A43WWPWebClientBrowserId = (short)(NumberUtil.Val( cgiGet( cmbWWPWebClientBrowserId_Internalname), "."));
            AssignAttri("", false, "A43WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0));
            A44WWPWebClientBrowserVersion = cgiGet( edtWWPWebClientBrowserVersion_Internalname);
            AssignAttri("", false, "A44WWPWebClientBrowserVersion", A44WWPWebClientBrowserVersion);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebClientFirstRegistered_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Client First Registered"}), 1, "WWPWEBCLIENTFIRSTREGISTERED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebClientFirstRegistered_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A45WWPWebClientFirstRegistered = context.localUtil.CToT( cgiGet( edtWWPWebClientFirstRegistered_Internalname));
               AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebClientLastRegistered_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Client Last Registered"}), 1, "WWPWEBCLIENTLASTREGISTERED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebClientLastRegistered_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A46WWPWebClientLastRegistered = context.localUtil.CToT( cgiGet( edtWWPWebClientLastRegistered_Internalname));
               AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
            }
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A18WWPWebClientId = GetPar( "WWPWebClientId");
               AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll066( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes066( ) ;
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

      protected void ResetCaption060( )
      {
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z43WWPWebClientBrowserId = T00063_A43WWPWebClientBrowserId[0];
               Z45WWPWebClientFirstRegistered = T00063_A45WWPWebClientFirstRegistered[0];
               Z46WWPWebClientLastRegistered = T00063_A46WWPWebClientLastRegistered[0];
               Z1WWPUserExtendedId = T00063_A1WWPUserExtendedId[0];
            }
            else
            {
               Z43WWPWebClientBrowserId = A43WWPWebClientBrowserId;
               Z45WWPWebClientFirstRegistered = A45WWPWebClientFirstRegistered;
               Z46WWPWebClientLastRegistered = A46WWPWebClientLastRegistered;
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z18WWPWebClientId = A18WWPWebClientId;
            Z43WWPWebClientBrowserId = A43WWPWebClientBrowserId;
            Z44WWPWebClientBrowserVersion = A44WWPWebClientBrowserVersion;
            Z45WWPWebClientFirstRegistered = A45WWPWebClientFirstRegistered;
            Z46WWPWebClientLastRegistered = A46WWPWebClientLastRegistered;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A45WWPWebClientFirstRegistered) && ( Gx_BScreen == 0 ) )
         {
            A45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A46WWPWebClientLastRegistered) && ( Gx_BScreen == 0 ) )
         {
            A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load066( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
            A43WWPWebClientBrowserId = T00065_A43WWPWebClientBrowserId[0];
            AssignAttri("", false, "A43WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0));
            A44WWPWebClientBrowserVersion = T00065_A44WWPWebClientBrowserVersion[0];
            AssignAttri("", false, "A44WWPWebClientBrowserVersion", A44WWPWebClientBrowserVersion);
            A45WWPWebClientFirstRegistered = T00065_A45WWPWebClientFirstRegistered[0];
            AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
            A46WWPWebClientLastRegistered = T00065_A46WWPWebClientLastRegistered[0];
            AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
            A1WWPUserExtendedId = T00065_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00065_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            ZM066( -6) ;
         }
         pr_default.close(3);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A43WWPWebClientBrowserId == 0 ) || ( A43WWPWebClientBrowserId == 1 ) || ( A43WWPWebClientBrowserId == 2 ) || ( A43WWPWebClientBrowserId == 3 ) || ( A43WWPWebClientBrowserId == 5 ) || ( A43WWPWebClientBrowserId == 6 ) || ( A43WWPWebClientBrowserId == 7 ) || ( A43WWPWebClientBrowserId == 8 ) || ( A43WWPWebClientBrowserId == 9 ) ) )
         {
            GX_msglist.addItem("Campo Web Client Browser Id fora do intervalo", "OutOfRange", 1, "WWPWEBCLIENTBROWSERID");
            AnyError = 1;
            GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A45WWPWebClientFirstRegistered) || ( A45WWPWebClientFirstRegistered >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Client First Registered fora do intervalo", "OutOfRange", 1, "WWPWEBCLIENTFIRSTREGISTERED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebClientFirstRegistered_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A46WWPWebClientLastRegistered) || ( A46WWPWebClientLastRegistered >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Client Last Registered fora do intervalo", "OutOfRange", 1, "WWPWEBCLIENTLASTREGISTERED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebClientLastRegistered_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( string A1WWPUserExtendedId )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey066( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 6) ;
            RcdFound6 = 1;
            A18WWPWebClientId = T00063_A18WWPWebClientId[0];
            AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
            A43WWPWebClientBrowserId = T00063_A43WWPWebClientBrowserId[0];
            AssignAttri("", false, "A43WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0));
            A44WWPWebClientBrowserVersion = T00063_A44WWPWebClientBrowserVersion[0];
            AssignAttri("", false, "A44WWPWebClientBrowserVersion", A44WWPWebClientBrowserVersion);
            A45WWPWebClientFirstRegistered = T00063_A45WWPWebClientFirstRegistered[0];
            AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
            A46WWPWebClientLastRegistered = T00063_A46WWPWebClientLastRegistered[0];
            AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
            A1WWPUserExtendedId = T00063_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00063_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            Z18WWPWebClientId = A18WWPWebClientId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00068_A18WWPWebClientId[0], A18WWPWebClientId) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00068_A18WWPWebClientId[0], A18WWPWebClientId) > 0 ) ) )
            {
               A18WWPWebClientId = T00068_A18WWPWebClientId[0];
               AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
               RcdFound6 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00069_A18WWPWebClientId[0], A18WWPWebClientId) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00069_A18WWPWebClientId[0], A18WWPWebClientId) < 0 ) ) )
            {
               A18WWPWebClientId = T00069_A18WWPWebClientId[0];
               AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
               RcdFound6 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( StringUtil.StrCmp(A18WWPWebClientId, Z18WWPWebClientId) != 0 )
               {
                  A18WWPWebClientId = Z18WWPWebClientId;
                  AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPWEBCLIENTID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update066( ) ;
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A18WWPWebClientId, Z18WWPWebClientId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPWEBCLIENTID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPWebClientId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPWebClientId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A18WWPWebClientId, Z18WWPWebClientId) != 0 )
         {
            A18WWPWebClientId = Z18WWPWebClientId;
            AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPWEBCLIENTID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPWEBCLIENTID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound6 != 0 )
            {
               ScanNext066( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A18WWPWebClientId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z43WWPWebClientBrowserId != T00062_A43WWPWebClientBrowserId[0] ) || ( Z45WWPWebClientFirstRegistered != T00062_A45WWPWebClientFirstRegistered[0] ) || ( Z46WWPWebClientLastRegistered != T00062_A46WWPWebClientLastRegistered[0] ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00062_A1WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z43WWPWebClientBrowserId != T00062_A43WWPWebClientBrowserId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPWebClientBrowserId");
                  GXUtil.WriteLogRaw("Old: ",Z43WWPWebClientBrowserId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A43WWPWebClientBrowserId[0]);
               }
               if ( Z45WWPWebClientFirstRegistered != T00062_A45WWPWebClientFirstRegistered[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPWebClientFirstRegistered");
                  GXUtil.WriteLogRaw("Old: ",Z45WWPWebClientFirstRegistered);
                  GXUtil.WriteLogRaw("Current: ",T00062_A45WWPWebClientFirstRegistered[0]);
               }
               if ( Z46WWPWebClientLastRegistered != T00062_A46WWPWebClientLastRegistered[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPWebClientLastRegistered");
                  GXUtil.WriteLogRaw("Old: ",Z46WWPWebClientLastRegistered);
                  GXUtil.WriteLogRaw("Current: ",T00062_A46WWPWebClientLastRegistered[0]);
               }
               if ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00062_A1WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z1WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A1WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebClient"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         if ( ! IsAuthorized("webclient_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000610 */
                     pr_default.execute(8, new Object[] {A18WWPWebClientId, A43WWPWebClientBrowserId, A44WWPWebClientBrowserVersion, A45WWPWebClientFirstRegistered, A46WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         if ( ! IsAuthorized("webclient_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000611 */
                     pr_default.execute(9, new Object[] {A43WWPWebClientBrowserId, A44WWPWebClientBrowserVersion, A45WWPWebClientFirstRegistered, A46WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId, A18WWPWebClientId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption060( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("webclient_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000612 */
                  pr_default.execute(10, new Object[] {A18WWPWebClientId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound6 == 0 )
                        {
                           InitAll066( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption060( ) ;
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_webclient",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webclient",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Using cursor T000613 */
         pr_default.execute(11);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound6 = 1;
            A18WWPWebClientId = T000613_A18WWPWebClientId[0];
            AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound6 = 1;
            A18WWPWebClientId = T000613_A18WWPWebClientId[0];
            AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtWWPWebClientId_Enabled = 0;
         AssignProp("", false, edtWWPWebClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientId_Enabled), 5, 0), true);
         cmbWWPWebClientBrowserId.Enabled = 0;
         AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebClientBrowserId.Enabled), 5, 0), true);
         edtWWPWebClientBrowserVersion_Enabled = 0;
         AssignProp("", false, edtWWPWebClientBrowserVersion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientBrowserVersion_Enabled), 5, 0), true);
         edtWWPWebClientFirstRegistered_Enabled = 0;
         AssignProp("", false, edtWWPWebClientFirstRegistered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientFirstRegistered_Enabled), 5, 0), true);
         edtWWPWebClientLastRegistered_Enabled = 0;
         AssignProp("", false, edtWWPWebClientLastRegistered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientLastRegistered_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815475687", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 8534944), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.wwp_webclient.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z18WWPWebClientId", StringUtil.RTrim( Z18WWPWebClientId));
         GxWebStd.gx_hidden_field( context, "Z43WWPWebClientBrowserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43WWPWebClientBrowserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z45WWPWebClientFirstRegistered", context.localUtil.TToC( Z45WWPWebClientFirstRegistered, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z46WWPWebClientLastRegistered", context.localUtil.TToC( Z46WWPWebClientLastRegistered, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.notifications.web.wwp_webclient.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.WWP_WebClient" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Web Client" ;
      }

      protected void InitializeNonKey066( )
      {
         A43WWPWebClientBrowserId = 0;
         AssignAttri("", false, "A43WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0));
         A44WWPWebClientBrowserVersion = "";
         AssignAttri("", false, "A44WWPWebClientBrowserVersion", A44WWPWebClientBrowserVersion);
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
         A45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
         A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
         Z43WWPWebClientBrowserId = 0;
         Z45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll066( )
      {
         A18WWPWebClientId = "";
         AssignAttri("", false, "A18WWPWebClientId", A18WWPWebClientId);
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A45WWPWebClientFirstRegistered = i45WWPWebClientFirstRegistered;
         AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
         A46WWPWebClientLastRegistered = i46WWPWebClientLastRegistered;
         AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815475699", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/wwp_webclient.js", "?20214281547570", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtWWPWebClientId_Internalname = "WWPWEBCLIENTID";
         cmbWWPWebClientBrowserId_Internalname = "WWPWEBCLIENTBROWSERID";
         edtWWPWebClientBrowserVersion_Internalname = "WWPWEBCLIENTBROWSERVERSION";
         edtWWPWebClientFirstRegistered_Internalname = "WWPWEBCLIENTFIRSTREGISTERED";
         edtWWPWebClientLastRegistered_Internalname = "WWPWEBCLIENTLASTREGISTERED";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "WWP_Web Client";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPWebClientLastRegistered_Jsonclick = "";
         edtWWPWebClientLastRegistered_Enabled = 1;
         edtWWPWebClientFirstRegistered_Jsonclick = "";
         edtWWPWebClientFirstRegistered_Enabled = 1;
         edtWWPWebClientBrowserVersion_Enabled = 1;
         cmbWWPWebClientBrowserId_Jsonclick = "";
         cmbWWPWebClientBrowserId.Enabled = 1;
         edtWWPWebClientId_Jsonclick = "";
         edtWWPWebClientId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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
         cmbWWPWebClientBrowserId.Name = "WWPWEBCLIENTBROWSERID";
         cmbWWPWebClientBrowserId.WebTags = "";
         cmbWWPWebClientBrowserId.addItem("0", "Unknown Agent", 0);
         cmbWWPWebClientBrowserId.addItem("1", "Internet Explorer", 0);
         cmbWWPWebClientBrowserId.addItem("2", "Netscape", 0);
         cmbWWPWebClientBrowserId.addItem("3", "Opera", 0);
         cmbWWPWebClientBrowserId.addItem("5", "Pocket IE", 0);
         cmbWWPWebClientBrowserId.addItem("6", "Firefox", 0);
         cmbWWPWebClientBrowserId.addItem("7", "Chrome", 0);
         cmbWWPWebClientBrowserId.addItem("8", "Safari", 0);
         cmbWWPWebClientBrowserId.addItem("9", "Edge", 0);
         if ( cmbWWPWebClientBrowserId.ItemCount > 0 )
         {
            A43WWPWebClientBrowserId = (short)(NumberUtil.Val( cmbWWPWebClientBrowserId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0))), "."));
            AssignAttri("", false, "A43WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Wwpwebclientid( )
      {
         A43WWPWebClientBrowserId = (short)(NumberUtil.Val( cmbWWPWebClientBrowserId.CurrentValue, "."));
         cmbWWPWebClientBrowserId.CurrentValue = StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPWebClientBrowserId.ItemCount > 0 )
         {
            A43WWPWebClientBrowserId = (short)(NumberUtil.Val( cmbWWPWebClientBrowserId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0))), "."));
            cmbWWPWebClientBrowserId.CurrentValue = StringUtil.LTrimStr( (decimal)(A43WWPWebClientBrowserId), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A43WWPWebClientBrowserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43WWPWebClientBrowserId), 4, 0, ".", "")));
         cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A43WWPWebClientBrowserId), 4, 0));
         AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Values", cmbWWPWebClientBrowserId.ToJavascriptSource(), true);
         AssignAttri("", false, "A44WWPWebClientBrowserVersion", A44WWPWebClientBrowserVersion);
         AssignAttri("", false, "A45WWPWebClientFirstRegistered", context.localUtil.TToC( A45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A46WWPWebClientLastRegistered", context.localUtil.TToC( A46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1WWPUserExtendedId", StringUtil.RTrim( A1WWPUserExtendedId));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z18WWPWebClientId", StringUtil.RTrim( Z18WWPWebClientId));
         GxWebStd.gx_hidden_field( context, "Z43WWPWebClientBrowserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43WWPWebClientBrowserId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z44WWPWebClientBrowserVersion", Z44WWPWebClientBrowserVersion);
         GxWebStd.gx_hidden_field( context, "Z45WWPWebClientFirstRegistered", context.localUtil.TToC( Z45WWPWebClientFirstRegistered, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z46WWPWebClientLastRegistered", context.localUtil.TToC( Z46WWPWebClientLastRegistered, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpuserextendedid( )
      {
         n1WWPUserExtendedId = false;
         /* Using cursor T000614 */
         pr_default.execute(12, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_WWPWEBCLIENTID","{handler:'Valid_Wwpwebclientid',iparms:[{av:'cmbWWPWebClientBrowserId'},{av:'A43WWPWebClientBrowserId',fld:'WWPWEBCLIENTBROWSERID',pic:'ZZZ9'},{av:'A18WWPWebClientId',fld:'WWPWEBCLIENTID',pic:''},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A45WWPWebClientFirstRegistered',fld:'WWPWEBCLIENTFIRSTREGISTERED',pic:'99/99/9999 99:99:99.999'},{av:'A46WWPWebClientLastRegistered',fld:'WWPWEBCLIENTLASTREGISTERED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPWEBCLIENTID",",oparms:[{av:'cmbWWPWebClientBrowserId'},{av:'A43WWPWebClientBrowserId',fld:'WWPWEBCLIENTBROWSERID',pic:'ZZZ9'},{av:'A44WWPWebClientBrowserVersion',fld:'WWPWEBCLIENTBROWSERVERSION',pic:''},{av:'A45WWPWebClientFirstRegistered',fld:'WWPWEBCLIENTFIRSTREGISTERED',pic:'99/99/9999 99:99:99.999'},{av:'A46WWPWebClientLastRegistered',fld:'WWPWEBCLIENTLASTREGISTERED',pic:'99/99/9999 99:99:99.999'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z18WWPWebClientId'},{av:'Z43WWPWebClientBrowserId'},{av:'Z44WWPWebClientBrowserVersion'},{av:'Z45WWPWebClientFirstRegistered'},{av:'Z46WWPWebClientLastRegistered'},{av:'Z1WWPUserExtendedId'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPWEBCLIENTBROWSERID","{handler:'Valid_Wwpwebclientbrowserid',iparms:[]");
         setEventMetadata("VALID_WWPWEBCLIENTBROWSERID",",oparms:[]}");
         setEventMetadata("VALID_WWPWEBCLIENTFIRSTREGISTERED","{handler:'Valid_Wwpwebclientfirstregistered',iparms:[]");
         setEventMetadata("VALID_WWPWEBCLIENTFIRSTREGISTERED",",oparms:[]}");
         setEventMetadata("VALID_WWPWEBCLIENTLASTREGISTERED","{handler:'Valid_Wwpwebclientlastregistered',iparms:[]");
         setEventMetadata("VALID_WWPWEBCLIENTLASTREGISTERED",",oparms:[]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[]}");
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
         Z18WWPWebClientId = "";
         Z45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z1WWPUserExtendedId = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A1WWPUserExtendedId = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A18WWPWebClientId = "";
         A44WWPWebClientBrowserVersion = "";
         A45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         A46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z44WWPWebClientBrowserVersion = "";
         T00065_A18WWPWebClientId = new string[] {""} ;
         T00065_A43WWPWebClientBrowserId = new short[1] ;
         T00065_A44WWPWebClientBrowserVersion = new string[] {""} ;
         T00065_A45WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         T00065_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         T00065_A1WWPUserExtendedId = new string[] {""} ;
         T00065_n1WWPUserExtendedId = new bool[] {false} ;
         T00064_A1WWPUserExtendedId = new string[] {""} ;
         T00064_n1WWPUserExtendedId = new bool[] {false} ;
         T00066_A1WWPUserExtendedId = new string[] {""} ;
         T00066_n1WWPUserExtendedId = new bool[] {false} ;
         T00067_A18WWPWebClientId = new string[] {""} ;
         T00063_A18WWPWebClientId = new string[] {""} ;
         T00063_A43WWPWebClientBrowserId = new short[1] ;
         T00063_A44WWPWebClientBrowserVersion = new string[] {""} ;
         T00063_A45WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         T00063_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         T00063_A1WWPUserExtendedId = new string[] {""} ;
         T00063_n1WWPUserExtendedId = new bool[] {false} ;
         sMode6 = "";
         T00068_A18WWPWebClientId = new string[] {""} ;
         T00069_A18WWPWebClientId = new string[] {""} ;
         T00062_A18WWPWebClientId = new string[] {""} ;
         T00062_A43WWPWebClientBrowserId = new short[1] ;
         T00062_A44WWPWebClientBrowserVersion = new string[] {""} ;
         T00062_A45WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         T00062_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         T00062_A1WWPUserExtendedId = new string[] {""} ;
         T00062_n1WWPUserExtendedId = new bool[] {false} ;
         T000613_A18WWPWebClientId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         i46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         ZZ18WWPWebClientId = "";
         ZZ44WWPWebClientBrowserVersion = "";
         ZZ45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         ZZ46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         ZZ1WWPUserExtendedId = "";
         T000614_A1WWPUserExtendedId = new string[] {""} ;
         T000614_n1WWPUserExtendedId = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient__default(),
            new Object[][] {
                new Object[] {
               T00062_A18WWPWebClientId, T00062_A43WWPWebClientBrowserId, T00062_A44WWPWebClientBrowserVersion, T00062_A45WWPWebClientFirstRegistered, T00062_A46WWPWebClientLastRegistered, T00062_A1WWPUserExtendedId, T00062_n1WWPUserExtendedId
               }
               , new Object[] {
               T00063_A18WWPWebClientId, T00063_A43WWPWebClientBrowserId, T00063_A44WWPWebClientBrowserVersion, T00063_A45WWPWebClientFirstRegistered, T00063_A46WWPWebClientLastRegistered, T00063_A1WWPUserExtendedId, T00063_n1WWPUserExtendedId
               }
               , new Object[] {
               T00064_A1WWPUserExtendedId
               }
               , new Object[] {
               T00065_A18WWPWebClientId, T00065_A43WWPWebClientBrowserId, T00065_A44WWPWebClientBrowserVersion, T00065_A45WWPWebClientFirstRegistered, T00065_A46WWPWebClientLastRegistered, T00065_A1WWPUserExtendedId, T00065_n1WWPUserExtendedId
               }
               , new Object[] {
               T00066_A1WWPUserExtendedId
               }
               , new Object[] {
               T00067_A18WWPWebClientId
               }
               , new Object[] {
               T00068_A18WWPWebClientId
               }
               , new Object[] {
               T00069_A18WWPWebClientId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000613_A18WWPWebClientId
               }
               , new Object[] {
               T000614_A1WWPUserExtendedId
               }
            }
         );
         Z46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
      }

      private short Z43WWPWebClientBrowserId ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A43WWPWebClientBrowserId ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private short gxajaxcallmode ;
      private short ZZ43WWPWebClientBrowserId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPWebClientId_Enabled ;
      private int edtWWPWebClientBrowserVersion_Enabled ;
      private int edtWWPWebClientFirstRegistered_Enabled ;
      private int edtWWPWebClientLastRegistered_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z18WWPWebClientId ;
      private string Z1WWPUserExtendedId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPWebClientId_Internalname ;
      private string cmbWWPWebClientBrowserId_Internalname ;
      private string divTablemain_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string A18WWPWebClientId ;
      private string edtWWPWebClientId_Jsonclick ;
      private string cmbWWPWebClientBrowserId_Jsonclick ;
      private string edtWWPWebClientBrowserVersion_Internalname ;
      private string edtWWPWebClientFirstRegistered_Internalname ;
      private string edtWWPWebClientFirstRegistered_Jsonclick ;
      private string edtWWPWebClientLastRegistered_Internalname ;
      private string edtWWPWebClientLastRegistered_Jsonclick ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode6 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ18WWPWebClientId ;
      private string ZZ1WWPUserExtendedId ;
      private DateTime Z45WWPWebClientFirstRegistered ;
      private DateTime Z46WWPWebClientLastRegistered ;
      private DateTime A45WWPWebClientFirstRegistered ;
      private DateTime A46WWPWebClientLastRegistered ;
      private DateTime i45WWPWebClientFirstRegistered ;
      private DateTime i46WWPWebClientLastRegistered ;
      private DateTime ZZ45WWPWebClientFirstRegistered ;
      private DateTime ZZ46WWPWebClientLastRegistered ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1WWPUserExtendedId ;
      private bool wbErr ;
      private string A44WWPWebClientBrowserVersion ;
      private string Z44WWPWebClientBrowserVersion ;
      private string ZZ44WWPWebClientBrowserVersion ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPWebClientBrowserId ;
      private IDataStoreProvider pr_default ;
      private string[] T00065_A18WWPWebClientId ;
      private short[] T00065_A43WWPWebClientBrowserId ;
      private string[] T00065_A44WWPWebClientBrowserVersion ;
      private DateTime[] T00065_A45WWPWebClientFirstRegistered ;
      private DateTime[] T00065_A46WWPWebClientLastRegistered ;
      private string[] T00065_A1WWPUserExtendedId ;
      private bool[] T00065_n1WWPUserExtendedId ;
      private string[] T00064_A1WWPUserExtendedId ;
      private bool[] T00064_n1WWPUserExtendedId ;
      private string[] T00066_A1WWPUserExtendedId ;
      private bool[] T00066_n1WWPUserExtendedId ;
      private string[] T00067_A18WWPWebClientId ;
      private string[] T00063_A18WWPWebClientId ;
      private short[] T00063_A43WWPWebClientBrowserId ;
      private string[] T00063_A44WWPWebClientBrowserVersion ;
      private DateTime[] T00063_A45WWPWebClientFirstRegistered ;
      private DateTime[] T00063_A46WWPWebClientLastRegistered ;
      private string[] T00063_A1WWPUserExtendedId ;
      private bool[] T00063_n1WWPUserExtendedId ;
      private string[] T00068_A18WWPWebClientId ;
      private string[] T00069_A18WWPWebClientId ;
      private string[] T00062_A18WWPWebClientId ;
      private short[] T00062_A43WWPWebClientBrowserId ;
      private string[] T00062_A44WWPWebClientBrowserVersion ;
      private DateTime[] T00062_A45WWPWebClientFirstRegistered ;
      private DateTime[] T00062_A46WWPWebClientLastRegistered ;
      private string[] T00062_A1WWPUserExtendedId ;
      private bool[] T00062_n1WWPUserExtendedId ;
      private string[] T000613_A18WWPWebClientId ;
      private string[] T000614_A1WWPUserExtendedId ;
      private bool[] T000614_n1WWPUserExtendedId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_webclient__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webclient__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00065;
        prmT00065 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT00064;
        prmT00064 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00066;
        prmT00066 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00067;
        prmT00067 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT00063;
        prmT00063 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT00068;
        prmT00068 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT00069;
        prmT00069 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT00062;
        prmT00062 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT000610;
        prmT000610 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0} ,
        new Object[] {"@WWPWebClientBrowserId",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebClientBrowserVersion",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebClientFirstRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebClientLastRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000611;
        prmT000611 = new Object[] {
        new Object[] {"@WWPWebClientBrowserId",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebClientBrowserVersion",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebClientFirstRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebClientLastRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT000612;
        prmT000612 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmT000613;
        prmT000613 = new Object[] {
        };
        Object[] prmT000614;
        prmT000614 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("T00062", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WITH (UPDLOCK) WHERE [WWPWebClientId] = @WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00063", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WHERE [WWPWebClientId] = @WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00064", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00065", "SELECT TM1.[WWPWebClientId], TM1.[WWPWebClientBrowserId], TM1.[WWPWebClientBrowserVersion], TM1.[WWPWebClientFirstRegistered], TM1.[WWPWebClientLastRegistered], TM1.[WWPUserExtendedId] FROM [WWP_WebClient] TM1 WHERE TM1.[WWPWebClientId] = @WWPWebClientId ORDER BY TM1.[WWPWebClientId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00066", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00067", "SELECT [WWPWebClientId] FROM [WWP_WebClient] WHERE [WWPWebClientId] = @WWPWebClientId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00068", "SELECT TOP 1 [WWPWebClientId] FROM [WWP_WebClient] WHERE ( [WWPWebClientId] > @WWPWebClientId) ORDER BY [WWPWebClientId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00069", "SELECT TOP 1 [WWPWebClientId] FROM [WWP_WebClient] WHERE ( [WWPWebClientId] < @WWPWebClientId) ORDER BY [WWPWebClientId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000610", "INSERT INTO [WWP_WebClient]([WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId]) VALUES(@WWPWebClientId, @WWPWebClientBrowserId, @WWPWebClientBrowserVersion, @WWPWebClientFirstRegistered, @WWPWebClientLastRegistered, @WWPUserExtendedId)", GxErrorMask.GX_NOMASK,prmT000610)
           ,new CursorDef("T000611", "UPDATE [WWP_WebClient] SET [WWPWebClientBrowserId]=@WWPWebClientBrowserId, [WWPWebClientBrowserVersion]=@WWPWebClientBrowserVersion, [WWPWebClientFirstRegistered]=@WWPWebClientFirstRegistered, [WWPWebClientLastRegistered]=@WWPWebClientLastRegistered, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK,prmT000611)
           ,new CursorDef("T000612", "DELETE FROM [WWP_WebClient]  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK,prmT000612)
           ,new CursorDef("T000613", "SELECT [WWPWebClientId] FROM [WWP_WebClient] ORDER BY [WWPWebClientId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000614", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getString(1, 100);
              table[1][0] = rslt.getShort(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getGXDateTime(5, true);
              table[5][0] = rslt.getString(6, 40);
              table[6][0] = rslt.wasNull(6);
              return;
           case 1 :
              table[0][0] = rslt.getString(1, 100);
              table[1][0] = rslt.getShort(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getGXDateTime(5, true);
              table[5][0] = rslt.getString(6, 40);
              table[6][0] = rslt.wasNull(6);
              return;
           case 2 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 100);
              table[1][0] = rslt.getShort(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getGXDateTime(5, true);
              table[5][0] = rslt.getString(6, 40);
              table[6][0] = rslt.wasNull(6);
              return;
           case 4 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 5 :
              table[0][0] = rslt.getString(1, 100);
              return;
           case 6 :
              table[0][0] = rslt.getString(1, 100);
              return;
           case 7 :
              table[0][0] = rslt.getString(1, 100);
              return;
           case 11 :
              table[0][0] = rslt.getString(1, 100);
              return;
           case 12 :
              table[0][0] = rslt.getString(1, 40);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 2 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 3 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 4 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameterDatetime(4, (DateTime)parms[3], true);
              stmt.SetParameterDatetime(5, (DateTime)parms[4], true);
              if ( (bool)parms[5] )
              {
                 stmt.setNull( 6 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(6, (string)parms[6]);
              }
              return;
           case 9 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameterDatetime(3, (DateTime)parms[2], true);
              stmt.SetParameterDatetime(4, (DateTime)parms[3], true);
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 5 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[5]);
              }
              stmt.SetParameter(6, (string)parms[6]);
              return;
           case 10 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 12 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
     }
  }

}

}
