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
   public class wwp_webnotification : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A16WWPNotificationId = (long)(NumberUtil.Val( GetPar( "WWPNotificationId"), "."));
            n16WWPNotificationId = false;
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A16WWPNotificationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A14WWPNotificationDefinitionId = (long)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."));
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A14WWPNotificationDefinitionId) ;
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
            Form.Meta.addItem("description", "WWP_Web Notification", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_webnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_webnotification( IGxContext context )
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
         cmbWWPWebNotificationStatus = new GXCombobox();
         chkWWPWebNotificationReceived = new GXCheckbox();
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
            return "webnotification_Execute" ;
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
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A48WWPWebNotificationStatus = (short)(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A48WWPWebNotificationStatus), 4, 0))), "."));
            AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48WWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         }
         A51WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A51WWPWebNotificationReceived));
         n51WWPWebNotificationReceived = false;
         AssignAttri("", false, "A51WWPWebNotificationReceived", A51WWPWebNotificationReceived);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Web Notification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17WWPWebNotificationId), 10, 0, ",", "")), ((edtWWPWebNotificationId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A17WWPWebNotificationId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A17WWPWebNotificationId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationTitle_Internalname, "Notification Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationTitle_Internalname, A38WWPWebNotificationTitle, StringUtil.RTrim( context.localUtil.Format( A38WWPWebNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationTitle_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ",", "")), ((edtWWPNotificationId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, "Notification Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A37WWPNotificationCreated, "99/99/9999 99:99:99.999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, "WWPNotification Metadata", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A54WWPNotificationMetadata, "", "", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, "Notification Definition Internal Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A53WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A53WWPNotificationDefinitionName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationText_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationText_Internalname, "Notification Text", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationText_Internalname, A39WWPWebNotificationText, StringUtil.RTrim( context.localUtil.Format( A39WWPWebNotificationText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationText_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationText_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationIcon_Internalname, "Notification Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationIcon_Internalname, A40WWPWebNotificationIcon, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtWWPWebNotificationIcon_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationClientId_Internalname, "Client Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationClientId_Internalname, A47WWPWebNotificationClientId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", 0, 1, edtWWPWebNotificationClientId_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbWWPWebNotificationStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPWebNotificationStatus_Internalname, "Notification Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPWebNotificationStatus, cmbWWPWebNotificationStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A48WWPWebNotificationStatus), 4, 0)), 1, cmbWWPWebNotificationStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPWebNotificationStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", (string)(cmbWWPWebNotificationStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationCreated_Internalname, "Notification Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationCreated_Internalname, context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A41WWPWebNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationScheduled_Internalname, "Notification Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationScheduled_Internalname, context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A52WWPWebNotificationScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationProcessed_Internalname, "Notification Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationProcessed_Internalname, context.localUtil.TToC( A49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A49WWPWebNotificationProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationRead_Internalname, "Notification Read", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationRead_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationRead_Internalname, context.localUtil.TToC( A42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A42WWPWebNotificationRead, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationRead_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationRead_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationRead_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationRead_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPWebNotificationDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationDetail_Internalname, "Notification Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationDetail_Internalname, A50WWPWebNotificationDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", 0, 1, edtWWPWebNotificationDetail_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkWWPWebNotificationReceived_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPWebNotificationReceived_Internalname, "Notification Received", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPWebNotificationReceived_Internalname, StringUtil.BoolToStr( A51WWPWebNotificationReceived), "", "Notification Received", 1, chkWWPWebNotificationReceived.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,103);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
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
            Z17WWPWebNotificationId = (long)(context.localUtil.CToN( cgiGet( "Z17WWPWebNotificationId"), ",", "."));
            Z38WWPWebNotificationTitle = cgiGet( "Z38WWPWebNotificationTitle");
            Z39WWPWebNotificationText = cgiGet( "Z39WWPWebNotificationText");
            Z40WWPWebNotificationIcon = cgiGet( "Z40WWPWebNotificationIcon");
            Z48WWPWebNotificationStatus = (short)(context.localUtil.CToN( cgiGet( "Z48WWPWebNotificationStatus"), ",", "."));
            Z41WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( "Z41WWPWebNotificationCreated"), 0);
            Z52WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( "Z52WWPWebNotificationScheduled"), 0);
            Z49WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( "Z49WWPWebNotificationProcessed"), 0);
            Z42WWPWebNotificationRead = context.localUtil.CToT( cgiGet( "Z42WWPWebNotificationRead"), 0);
            n42WWPWebNotificationRead = ((DateTime.MinValue==A42WWPWebNotificationRead) ? true : false);
            Z51WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( "Z51WWPWebNotificationReceived"));
            n51WWPWebNotificationReceived = ((false==A51WWPWebNotificationReceived) ? true : false);
            Z16WWPNotificationId = (long)(context.localUtil.CToN( cgiGet( "Z16WWPNotificationId"), ",", "."));
            n16WWPNotificationId = ((0==A16WWPNotificationId) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
            A14WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( "WWPNOTIFICATIONDEFINITIONID"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPWEBNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A17WWPWebNotificationId = 0;
               AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
            }
            else
            {
               A17WWPWebNotificationId = (long)(context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ",", "."));
               AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
            }
            A38WWPWebNotificationTitle = cgiGet( edtWWPWebNotificationTitle_Internalname);
            AssignAttri("", false, "A38WWPWebNotificationTitle", A38WWPWebNotificationTitle);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A16WWPNotificationId = 0;
               n16WWPNotificationId = false;
               AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            }
            else
            {
               A16WWPNotificationId = (long)(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ",", "."));
               n16WWPNotificationId = false;
               AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            }
            n16WWPNotificationId = ((0==A16WWPNotificationId) ? true : false);
            A37WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A54WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n54WWPNotificationMetadata = false;
            AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
            A53WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            A39WWPWebNotificationText = cgiGet( edtWWPWebNotificationText_Internalname);
            AssignAttri("", false, "A39WWPWebNotificationText", A39WWPWebNotificationText);
            A40WWPWebNotificationIcon = cgiGet( edtWWPWebNotificationIcon_Internalname);
            AssignAttri("", false, "A40WWPWebNotificationIcon", A40WWPWebNotificationIcon);
            A47WWPWebNotificationClientId = cgiGet( edtWWPWebNotificationClientId_Internalname);
            AssignAttri("", false, "A47WWPWebNotificationClientId", A47WWPWebNotificationClientId);
            cmbWWPWebNotificationStatus.CurrentValue = cgiGet( cmbWWPWebNotificationStatus_Internalname);
            A48WWPWebNotificationStatus = (short)(NumberUtil.Val( cgiGet( cmbWWPWebNotificationStatus_Internalname), "."));
            AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Created"}), 1, "WWPWEBNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A41WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPWebNotificationCreated_Internalname));
               AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationScheduled_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Scheduled"}), 1, "WWPWEBNOTIFICATIONSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A52WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( edtWWPWebNotificationScheduled_Internalname));
               AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationProcessed_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Processed"}), 1, "WWPWEBNOTIFICATIONPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A49WWPWebNotificationProcessed", context.localUtil.TToC( A49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A49WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( edtWWPWebNotificationProcessed_Internalname));
               AssignAttri("", false, "A49WWPWebNotificationProcessed", context.localUtil.TToC( A49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationRead_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Read"}), 1, "WWPWEBNOTIFICATIONREAD");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationRead_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
               n42WWPWebNotificationRead = false;
               AssignAttri("", false, "A42WWPWebNotificationRead", context.localUtil.TToC( A42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A42WWPWebNotificationRead = context.localUtil.CToT( cgiGet( edtWWPWebNotificationRead_Internalname));
               n42WWPWebNotificationRead = false;
               AssignAttri("", false, "A42WWPWebNotificationRead", context.localUtil.TToC( A42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            }
            n42WWPWebNotificationRead = ((DateTime.MinValue==A42WWPWebNotificationRead) ? true : false);
            A50WWPWebNotificationDetail = cgiGet( edtWWPWebNotificationDetail_Internalname);
            n50WWPWebNotificationDetail = false;
            AssignAttri("", false, "A50WWPWebNotificationDetail", A50WWPWebNotificationDetail);
            n50WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A50WWPWebNotificationDetail)) ? true : false);
            A51WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( chkWWPWebNotificationReceived_Internalname));
            n51WWPWebNotificationReceived = false;
            AssignAttri("", false, "A51WWPWebNotificationReceived", A51WWPWebNotificationReceived);
            n51WWPWebNotificationReceived = ((false==A51WWPWebNotificationReceived) ? true : false);
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
               A17WWPWebNotificationId = (long)(NumberUtil.Val( GetPar( "WWPWebNotificationId"), "."));
               AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
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
               InitAll055( ) ;
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
         DisableAttributes055( ) ;
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

      protected void ResetCaption050( )
      {
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z38WWPWebNotificationTitle = T00053_A38WWPWebNotificationTitle[0];
               Z39WWPWebNotificationText = T00053_A39WWPWebNotificationText[0];
               Z40WWPWebNotificationIcon = T00053_A40WWPWebNotificationIcon[0];
               Z48WWPWebNotificationStatus = T00053_A48WWPWebNotificationStatus[0];
               Z41WWPWebNotificationCreated = T00053_A41WWPWebNotificationCreated[0];
               Z52WWPWebNotificationScheduled = T00053_A52WWPWebNotificationScheduled[0];
               Z49WWPWebNotificationProcessed = T00053_A49WWPWebNotificationProcessed[0];
               Z42WWPWebNotificationRead = T00053_A42WWPWebNotificationRead[0];
               Z51WWPWebNotificationReceived = T00053_A51WWPWebNotificationReceived[0];
               Z16WWPNotificationId = T00053_A16WWPNotificationId[0];
            }
            else
            {
               Z38WWPWebNotificationTitle = A38WWPWebNotificationTitle;
               Z39WWPWebNotificationText = A39WWPWebNotificationText;
               Z40WWPWebNotificationIcon = A40WWPWebNotificationIcon;
               Z48WWPWebNotificationStatus = A48WWPWebNotificationStatus;
               Z41WWPWebNotificationCreated = A41WWPWebNotificationCreated;
               Z52WWPWebNotificationScheduled = A52WWPWebNotificationScheduled;
               Z49WWPWebNotificationProcessed = A49WWPWebNotificationProcessed;
               Z42WWPWebNotificationRead = A42WWPWebNotificationRead;
               Z51WWPWebNotificationReceived = A51WWPWebNotificationReceived;
               Z16WWPNotificationId = A16WWPNotificationId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z17WWPWebNotificationId = A17WWPWebNotificationId;
            Z38WWPWebNotificationTitle = A38WWPWebNotificationTitle;
            Z39WWPWebNotificationText = A39WWPWebNotificationText;
            Z40WWPWebNotificationIcon = A40WWPWebNotificationIcon;
            Z47WWPWebNotificationClientId = A47WWPWebNotificationClientId;
            Z48WWPWebNotificationStatus = A48WWPWebNotificationStatus;
            Z41WWPWebNotificationCreated = A41WWPWebNotificationCreated;
            Z52WWPWebNotificationScheduled = A52WWPWebNotificationScheduled;
            Z49WWPWebNotificationProcessed = A49WWPWebNotificationProcessed;
            Z42WWPWebNotificationRead = A42WWPWebNotificationRead;
            Z50WWPWebNotificationDetail = A50WWPWebNotificationDetail;
            Z51WWPWebNotificationReceived = A51WWPWebNotificationReceived;
            Z16WWPNotificationId = A16WWPNotificationId;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
            Z54WWPNotificationMetadata = A54WWPNotificationMetadata;
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A48WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A48WWPWebNotificationStatus = 1;
            AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A41WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A52WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
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

      protected void Load055( )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
            A14WWPNotificationDefinitionId = T00056_A14WWPNotificationDefinitionId[0];
            A38WWPWebNotificationTitle = T00056_A38WWPWebNotificationTitle[0];
            AssignAttri("", false, "A38WWPWebNotificationTitle", A38WWPWebNotificationTitle);
            A37WWPNotificationCreated = T00056_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A54WWPNotificationMetadata = T00056_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = T00056_n54WWPNotificationMetadata[0];
            AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
            A53WWPNotificationDefinitionName = T00056_A53WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            A39WWPWebNotificationText = T00056_A39WWPWebNotificationText[0];
            AssignAttri("", false, "A39WWPWebNotificationText", A39WWPWebNotificationText);
            A40WWPWebNotificationIcon = T00056_A40WWPWebNotificationIcon[0];
            AssignAttri("", false, "A40WWPWebNotificationIcon", A40WWPWebNotificationIcon);
            A47WWPWebNotificationClientId = T00056_A47WWPWebNotificationClientId[0];
            AssignAttri("", false, "A47WWPWebNotificationClientId", A47WWPWebNotificationClientId);
            A48WWPWebNotificationStatus = T00056_A48WWPWebNotificationStatus[0];
            AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
            A41WWPWebNotificationCreated = T00056_A41WWPWebNotificationCreated[0];
            AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A52WWPWebNotificationScheduled = T00056_A52WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            A49WWPWebNotificationProcessed = T00056_A49WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A49WWPWebNotificationProcessed", context.localUtil.TToC( A49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            A42WWPWebNotificationRead = T00056_A42WWPWebNotificationRead[0];
            n42WWPWebNotificationRead = T00056_n42WWPWebNotificationRead[0];
            AssignAttri("", false, "A42WWPWebNotificationRead", context.localUtil.TToC( A42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            A50WWPWebNotificationDetail = T00056_A50WWPWebNotificationDetail[0];
            n50WWPWebNotificationDetail = T00056_n50WWPWebNotificationDetail[0];
            AssignAttri("", false, "A50WWPWebNotificationDetail", A50WWPWebNotificationDetail);
            A51WWPWebNotificationReceived = T00056_A51WWPWebNotificationReceived[0];
            n51WWPWebNotificationReceived = T00056_n51WWPWebNotificationReceived[0];
            AssignAttri("", false, "A51WWPWebNotificationReceived", A51WWPWebNotificationReceived);
            A16WWPNotificationId = T00056_A16WWPNotificationId[0];
            n16WWPNotificationId = T00056_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            ZM055( -9) ;
         }
         pr_default.close(4);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A14WWPNotificationDefinitionId = T00054_A14WWPNotificationDefinitionId[0];
         A37WWPNotificationCreated = T00054_A37WWPNotificationCreated[0];
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A54WWPNotificationMetadata = T00054_A54WWPNotificationMetadata[0];
         n54WWPNotificationMetadata = T00054_n54WWPNotificationMetadata[0];
         AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A14WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "");
               AnyError = 1;
            }
         }
         A53WWPNotificationDefinitionName = T00055_A53WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         pr_default.close(3);
         if ( ! ( ( A48WWPWebNotificationStatus == 1 ) || ( A48WWPWebNotificationStatus == 2 ) || ( A48WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Status fora do intervalo", "OutOfRange", 1, "WWPWEBNOTIFICATIONSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPWebNotificationStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A41WWPWebNotificationCreated) || ( A41WWPWebNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Created fora do intervalo", "OutOfRange", 1, "WWPWEBNOTIFICATIONCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A52WWPWebNotificationScheduled) || ( A52WWPWebNotificationScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Scheduled fora do intervalo", "OutOfRange", 1, "WWPWEBNOTIFICATIONSCHEDULED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationScheduled_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A49WWPWebNotificationProcessed) || ( A49WWPWebNotificationProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Processed fora do intervalo", "OutOfRange", 1, "WWPWEBNOTIFICATIONPROCESSED");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationProcessed_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A42WWPWebNotificationRead) || ( A42WWPWebNotificationRead >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Read fora do intervalo", "OutOfRange", 1, "WWPWEBNOTIFICATIONREAD");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationRead_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( long A16WWPNotificationId )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A14WWPNotificationDefinitionId = T00057_A14WWPNotificationDefinitionId[0];
         A37WWPNotificationCreated = T00057_A37WWPNotificationCreated[0];
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A54WWPNotificationMetadata = T00057_A54WWPNotificationMetadata[0];
         n54WWPNotificationMetadata = T00057_n54WWPNotificationMetadata[0];
         AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( A54WWPNotificationMetadata)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_11( long A14WWPNotificationDefinitionId )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A14WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "");
               AnyError = 1;
            }
         }
         A53WWPNotificationDefinitionName = T00058_A53WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A53WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 9) ;
            RcdFound5 = 1;
            A17WWPWebNotificationId = T00053_A17WWPWebNotificationId[0];
            AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
            A38WWPWebNotificationTitle = T00053_A38WWPWebNotificationTitle[0];
            AssignAttri("", false, "A38WWPWebNotificationTitle", A38WWPWebNotificationTitle);
            A39WWPWebNotificationText = T00053_A39WWPWebNotificationText[0];
            AssignAttri("", false, "A39WWPWebNotificationText", A39WWPWebNotificationText);
            A40WWPWebNotificationIcon = T00053_A40WWPWebNotificationIcon[0];
            AssignAttri("", false, "A40WWPWebNotificationIcon", A40WWPWebNotificationIcon);
            A47WWPWebNotificationClientId = T00053_A47WWPWebNotificationClientId[0];
            AssignAttri("", false, "A47WWPWebNotificationClientId", A47WWPWebNotificationClientId);
            A48WWPWebNotificationStatus = T00053_A48WWPWebNotificationStatus[0];
            AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
            A41WWPWebNotificationCreated = T00053_A41WWPWebNotificationCreated[0];
            AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A52WWPWebNotificationScheduled = T00053_A52WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            A49WWPWebNotificationProcessed = T00053_A49WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A49WWPWebNotificationProcessed", context.localUtil.TToC( A49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            A42WWPWebNotificationRead = T00053_A42WWPWebNotificationRead[0];
            n42WWPWebNotificationRead = T00053_n42WWPWebNotificationRead[0];
            AssignAttri("", false, "A42WWPWebNotificationRead", context.localUtil.TToC( A42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            A50WWPWebNotificationDetail = T00053_A50WWPWebNotificationDetail[0];
            n50WWPWebNotificationDetail = T00053_n50WWPWebNotificationDetail[0];
            AssignAttri("", false, "A50WWPWebNotificationDetail", A50WWPWebNotificationDetail);
            A51WWPWebNotificationReceived = T00053_A51WWPWebNotificationReceived[0];
            n51WWPWebNotificationReceived = T00053_n51WWPWebNotificationReceived[0];
            AssignAttri("", false, "A51WWPWebNotificationReceived", A51WWPWebNotificationReceived);
            A16WWPNotificationId = T00053_A16WWPNotificationId[0];
            n16WWPNotificationId = T00053_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            Z17WWPWebNotificationId = A17WWPWebNotificationId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
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
         RcdFound5 = 0;
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000510_A17WWPWebNotificationId[0] < A17WWPWebNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000510_A17WWPWebNotificationId[0] > A17WWPWebNotificationId ) ) )
            {
               A17WWPWebNotificationId = T000510_A17WWPWebNotificationId[0];
               AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000511_A17WWPWebNotificationId[0] > A17WWPWebNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000511_A17WWPWebNotificationId[0] < A17WWPWebNotificationId ) ) )
            {
               A17WWPWebNotificationId = T000511_A17WWPWebNotificationId[0];
               AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A17WWPWebNotificationId != Z17WWPWebNotificationId )
               {
                  A17WWPWebNotificationId = Z17WWPWebNotificationId;
                  AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A17WWPWebNotificationId != Z17WWPWebNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPWEBNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
         if ( A17WWPWebNotificationId != Z17WWPWebNotificationId )
         {
            A17WWPWebNotificationId = Z17WWPWebNotificationId;
            AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext055( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A17WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z38WWPWebNotificationTitle, T00052_A38WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z39WWPWebNotificationText, T00052_A39WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z40WWPWebNotificationIcon, T00052_A40WWPWebNotificationIcon[0]) != 0 ) || ( Z48WWPWebNotificationStatus != T00052_A48WWPWebNotificationStatus[0] ) || ( Z41WWPWebNotificationCreated != T00052_A41WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z52WWPWebNotificationScheduled != T00052_A52WWPWebNotificationScheduled[0] ) || ( Z49WWPWebNotificationProcessed != T00052_A49WWPWebNotificationProcessed[0] ) || ( Z42WWPWebNotificationRead != T00052_A42WWPWebNotificationRead[0] ) || ( Z51WWPWebNotificationReceived != T00052_A51WWPWebNotificationReceived[0] ) || ( Z16WWPNotificationId != T00052_A16WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z38WWPWebNotificationTitle, T00052_A38WWPWebNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z38WWPWebNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T00052_A38WWPWebNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z39WWPWebNotificationText, T00052_A39WWPWebNotificationText[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationText");
                  GXUtil.WriteLogRaw("Old: ",Z39WWPWebNotificationText);
                  GXUtil.WriteLogRaw("Current: ",T00052_A39WWPWebNotificationText[0]);
               }
               if ( StringUtil.StrCmp(Z40WWPWebNotificationIcon, T00052_A40WWPWebNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z40WWPWebNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T00052_A40WWPWebNotificationIcon[0]);
               }
               if ( Z48WWPWebNotificationStatus != T00052_A48WWPWebNotificationStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationStatus");
                  GXUtil.WriteLogRaw("Old: ",Z48WWPWebNotificationStatus);
                  GXUtil.WriteLogRaw("Current: ",T00052_A48WWPWebNotificationStatus[0]);
               }
               if ( Z41WWPWebNotificationCreated != T00052_A41WWPWebNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z41WWPWebNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T00052_A41WWPWebNotificationCreated[0]);
               }
               if ( Z52WWPWebNotificationScheduled != T00052_A52WWPWebNotificationScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z52WWPWebNotificationScheduled);
                  GXUtil.WriteLogRaw("Current: ",T00052_A52WWPWebNotificationScheduled[0]);
               }
               if ( Z49WWPWebNotificationProcessed != T00052_A49WWPWebNotificationProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z49WWPWebNotificationProcessed);
                  GXUtil.WriteLogRaw("Current: ",T00052_A49WWPWebNotificationProcessed[0]);
               }
               if ( Z42WWPWebNotificationRead != T00052_A42WWPWebNotificationRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationRead");
                  GXUtil.WriteLogRaw("Old: ",Z42WWPWebNotificationRead);
                  GXUtil.WriteLogRaw("Current: ",T00052_A42WWPWebNotificationRead[0]);
               }
               if ( Z51WWPWebNotificationReceived != T00052_A51WWPWebNotificationReceived[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationReceived");
                  GXUtil.WriteLogRaw("Old: ",Z51WWPWebNotificationReceived);
                  GXUtil.WriteLogRaw("Current: ",T00052_A51WWPWebNotificationReceived[0]);
               }
               if ( Z16WWPNotificationId != T00052_A16WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z16WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A16WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         if ( ! IsAuthorized("webnotification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000512 */
                     pr_default.execute(10, new Object[] {A38WWPWebNotificationTitle, A39WWPWebNotificationText, A40WWPWebNotificationIcon, A47WWPWebNotificationClientId, A48WWPWebNotificationStatus, A41WWPWebNotificationCreated, A52WWPWebNotificationScheduled, A49WWPWebNotificationProcessed, n42WWPWebNotificationRead, A42WWPWebNotificationRead, n50WWPWebNotificationDetail, A50WWPWebNotificationDetail, n51WWPWebNotificationReceived, A51WWPWebNotificationReceived, n16WWPNotificationId, A16WWPNotificationId});
                     A17WWPWebNotificationId = T000512_A17WWPWebNotificationId[0];
                     AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         if ( ! IsAuthorized("webnotification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000513 */
                     pr_default.execute(11, new Object[] {A38WWPWebNotificationTitle, A39WWPWebNotificationText, A40WWPWebNotificationIcon, A47WWPWebNotificationClientId, A48WWPWebNotificationStatus, A41WWPWebNotificationCreated, A52WWPWebNotificationScheduled, A49WWPWebNotificationProcessed, n42WWPWebNotificationRead, A42WWPWebNotificationRead, n50WWPWebNotificationDetail, A50WWPWebNotificationDetail, n51WWPWebNotificationReceived, A51WWPWebNotificationReceived, n16WWPNotificationId, A16WWPNotificationId, A17WWPWebNotificationId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption050( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("webnotification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000514 */
                  pr_default.execute(12, new Object[] {A17WWPWebNotificationId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll055( ) ;
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
                        ResetCaption050( ) ;
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000515 */
            pr_default.execute(13, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            A14WWPNotificationDefinitionId = T000515_A14WWPNotificationDefinitionId[0];
            A37WWPNotificationCreated = T000515_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A54WWPNotificationMetadata = T000515_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = T000515_n54WWPNotificationMetadata[0];
            AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
            pr_default.close(13);
            /* Using cursor T000516 */
            pr_default.execute(14, new Object[] {A14WWPNotificationDefinitionId});
            A53WWPNotificationDefinitionName = T000516_A53WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            pr_default.close(14);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Using cursor T000517 */
         pr_default.execute(15);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
            A17WWPWebNotificationId = T000517_A17WWPWebNotificationId[0];
            AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
            A17WWPWebNotificationId = T000517_A17WWPWebNotificationId[0];
            AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtWWPWebNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationId_Enabled), 5, 0), true);
         edtWWPWebNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPWebNotificationText_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationText_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationText_Enabled), 5, 0), true);
         edtWWPWebNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationIcon_Enabled), 5, 0), true);
         edtWWPWebNotificationClientId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationClientId_Enabled), 5, 0), true);
         cmbWWPWebNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebNotificationStatus.Enabled), 5, 0), true);
         edtWWPWebNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationCreated_Enabled), 5, 0), true);
         edtWWPWebNotificationScheduled_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationScheduled_Enabled), 5, 0), true);
         edtWWPWebNotificationProcessed_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationProcessed_Enabled), 5, 0), true);
         edtWWPWebNotificationRead_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationRead_Enabled), 5, 0), true);
         edtWWPWebNotificationDetail_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationDetail_Enabled), 5, 0), true);
         chkWWPWebNotificationReceived.Enabled = 0;
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPWebNotificationReceived.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.AddJavascriptSource("gxcfg.js", "?20214281548239", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z17WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17WWPWebNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z38WWPWebNotificationTitle", Z38WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z39WWPWebNotificationText", Z39WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z40WWPWebNotificationIcon", Z40WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z48WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48WWPWebNotificationStatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z41WWPWebNotificationCreated", context.localUtil.TToC( Z41WWPWebNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z52WWPWebNotificationScheduled", context.localUtil.TToC( Z52WWPWebNotificationScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z49WWPWebNotificationProcessed", context.localUtil.TToC( Z49WWPWebNotificationProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z42WWPWebNotificationRead", context.localUtil.TToC( Z42WWPWebNotificationRead, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z51WWPWebNotificationReceived", Z51WWPWebNotificationReceived);
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.WWP_WebNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Web Notification" ;
      }

      protected void InitializeNonKey055( )
      {
         A14WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
         A38WWPWebNotificationTitle = "";
         AssignAttri("", false, "A38WWPWebNotificationTitle", A38WWPWebNotificationTitle);
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
         n16WWPNotificationId = ((0==A16WWPNotificationId) ? true : false);
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A54WWPNotificationMetadata = "";
         n54WWPNotificationMetadata = false;
         AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
         A53WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         A39WWPWebNotificationText = "";
         AssignAttri("", false, "A39WWPWebNotificationText", A39WWPWebNotificationText);
         A40WWPWebNotificationIcon = "";
         AssignAttri("", false, "A40WWPWebNotificationIcon", A40WWPWebNotificationIcon);
         A47WWPWebNotificationClientId = "";
         AssignAttri("", false, "A47WWPWebNotificationClientId", A47WWPWebNotificationClientId);
         A49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A49WWPWebNotificationProcessed", context.localUtil.TToC( A49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
         A42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n42WWPWebNotificationRead = false;
         AssignAttri("", false, "A42WWPWebNotificationRead", context.localUtil.TToC( A42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
         n42WWPWebNotificationRead = ((DateTime.MinValue==A42WWPWebNotificationRead) ? true : false);
         A50WWPWebNotificationDetail = "";
         n50WWPWebNotificationDetail = false;
         AssignAttri("", false, "A50WWPWebNotificationDetail", A50WWPWebNotificationDetail);
         n50WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A50WWPWebNotificationDetail)) ? true : false);
         A51WWPWebNotificationReceived = false;
         n51WWPWebNotificationReceived = false;
         AssignAttri("", false, "A51WWPWebNotificationReceived", A51WWPWebNotificationReceived);
         n51WWPWebNotificationReceived = ((false==A51WWPWebNotificationReceived) ? true : false);
         A48WWPWebNotificationStatus = 1;
         AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
         A41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
         Z38WWPWebNotificationTitle = "";
         Z39WWPWebNotificationText = "";
         Z40WWPWebNotificationIcon = "";
         Z48WWPWebNotificationStatus = 0;
         Z41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z51WWPWebNotificationReceived = false;
         Z16WWPNotificationId = 0;
      }

      protected void InitAll055( )
      {
         A17WWPWebNotificationId = 0;
         AssignAttri("", false, "A17WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A17WWPWebNotificationId), 10, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A48WWPWebNotificationStatus = i48WWPWebNotificationStatus;
         AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
         A41WWPWebNotificationCreated = i41WWPWebNotificationCreated;
         AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A52WWPWebNotificationScheduled = i52WWPWebNotificationScheduled;
         AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281548262", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/wwp_webnotification.js", "?20214281548263", false, true);
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
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID";
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPWebNotificationText_Internalname = "WWPWEBNOTIFICATIONTEXT";
         edtWWPWebNotificationIcon_Internalname = "WWPWEBNOTIFICATIONICON";
         edtWWPWebNotificationClientId_Internalname = "WWPWEBNOTIFICATIONCLIENTID";
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS";
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED";
         edtWWPWebNotificationScheduled_Internalname = "WWPWEBNOTIFICATIONSCHEDULED";
         edtWWPWebNotificationProcessed_Internalname = "WWPWEBNOTIFICATIONPROCESSED";
         edtWWPWebNotificationRead_Internalname = "WWPWEBNOTIFICATIONREAD";
         edtWWPWebNotificationDetail_Internalname = "WWPWEBNOTIFICATIONDETAIL";
         chkWWPWebNotificationReceived_Internalname = "WWPWEBNOTIFICATIONRECEIVED";
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
         Form.Caption = "WWP_Web Notification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPWebNotificationReceived.Enabled = 1;
         edtWWPWebNotificationDetail_Enabled = 1;
         edtWWPWebNotificationRead_Jsonclick = "";
         edtWWPWebNotificationRead_Enabled = 1;
         edtWWPWebNotificationProcessed_Jsonclick = "";
         edtWWPWebNotificationProcessed_Enabled = 1;
         edtWWPWebNotificationScheduled_Jsonclick = "";
         edtWWPWebNotificationScheduled_Enabled = 1;
         edtWWPWebNotificationCreated_Jsonclick = "";
         edtWWPWebNotificationCreated_Enabled = 1;
         cmbWWPWebNotificationStatus_Jsonclick = "";
         cmbWWPWebNotificationStatus.Enabled = 1;
         edtWWPWebNotificationClientId_Enabled = 1;
         edtWWPWebNotificationIcon_Enabled = 1;
         edtWWPWebNotificationText_Jsonclick = "";
         edtWWPWebNotificationText_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationMetadata_Enabled = 0;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPWebNotificationTitle_Jsonclick = "";
         edtWWPWebNotificationTitle_Enabled = 1;
         edtWWPWebNotificationId_Jsonclick = "";
         edtWWPWebNotificationId_Enabled = 1;
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
         cmbWWPWebNotificationStatus.Name = "WWPWEBNOTIFICATIONSTATUS";
         cmbWWPWebNotificationStatus.WebTags = "";
         cmbWWPWebNotificationStatus.addItem("1", "Pending", 0);
         cmbWWPWebNotificationStatus.addItem("2", "Sent", 0);
         cmbWWPWebNotificationStatus.addItem("3", "Error", 0);
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            if ( (0==A48WWPWebNotificationStatus) )
            {
               A48WWPWebNotificationStatus = 1;
               AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0));
            }
         }
         chkWWPWebNotificationReceived.Name = "WWPWEBNOTIFICATIONRECEIVED";
         chkWWPWebNotificationReceived.WebTags = "";
         chkWWPWebNotificationReceived.Caption = "";
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "TitleCaption", chkWWPWebNotificationReceived.Caption, true);
         chkWWPWebNotificationReceived.CheckedValue = "false";
         A51WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A51WWPWebNotificationReceived));
         n51WWPWebNotificationReceived = false;
         AssignAttri("", false, "A51WWPWebNotificationReceived", A51WWPWebNotificationReceived);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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

      public void Valid_Wwpwebnotificationid( )
      {
         A48WWPWebNotificationStatus = (short)(NumberUtil.Val( cmbWWPWebNotificationStatus.CurrentValue, "."));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A48WWPWebNotificationStatus = (short)(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A48WWPWebNotificationStatus), 4, 0))), "."));
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A48WWPWebNotificationStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48WWPWebNotificationStatus), 4, 0));
         }
         A51WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A51WWPWebNotificationReceived));
         n51WWPWebNotificationReceived = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A38WWPWebNotificationTitle", A38WWPWebNotificationTitle);
         AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A39WWPWebNotificationText", A39WWPWebNotificationText);
         AssignAttri("", false, "A40WWPWebNotificationIcon", A40WWPWebNotificationIcon);
         AssignAttri("", false, "A47WWPWebNotificationClientId", A47WWPWebNotificationClientId);
         AssignAttri("", false, "A48WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48WWPWebNotificationStatus), 4, 0, ".", "")));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A48WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A41WWPWebNotificationCreated", context.localUtil.TToC( A41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A52WWPWebNotificationScheduled", context.localUtil.TToC( A52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A49WWPWebNotificationProcessed", context.localUtil.TToC( A49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A42WWPWebNotificationRead", context.localUtil.TToC( A42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A50WWPWebNotificationDetail", A50WWPWebNotificationDetail);
         AssignAttri("", false, "A51WWPWebNotificationReceived", A51WWPWebNotificationReceived);
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z17WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17WWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38WWPWebNotificationTitle", Z38WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z39WWPWebNotificationText", Z39WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z40WWPWebNotificationIcon", Z40WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z47WWPWebNotificationClientId", Z47WWPWebNotificationClientId);
         GxWebStd.gx_hidden_field( context, "Z48WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48WWPWebNotificationStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41WWPWebNotificationCreated", context.localUtil.TToC( Z41WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z52WWPWebNotificationScheduled", context.localUtil.TToC( Z52WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z49WWPWebNotificationProcessed", context.localUtil.TToC( Z49WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z42WWPWebNotificationRead", context.localUtil.TToC( Z42WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z50WWPWebNotificationDetail", Z50WWPWebNotificationDetail);
         GxWebStd.gx_hidden_field( context, "Z51WWPWebNotificationReceived", StringUtil.BoolToStr( Z51WWPWebNotificationReceived));
         GxWebStd.gx_hidden_field( context, "Z14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37WWPNotificationCreated", context.localUtil.TToC( Z37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z54WWPNotificationMetadata", Z54WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z53WWPNotificationDefinitionName", Z53WWPNotificationDefinitionName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n16WWPNotificationId = false;
         n54WWPNotificationMetadata = false;
         /* Using cursor T000515 */
         pr_default.execute(13, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A14WWPNotificationDefinitionId = T000515_A14WWPNotificationDefinitionId[0];
         A37WWPNotificationCreated = T000515_A37WWPNotificationCreated[0];
         A54WWPNotificationMetadata = T000515_A54WWPNotificationMetadata[0];
         n54WWPNotificationMetadata = T000515_n54WWPNotificationMetadata[0];
         pr_default.close(13);
         /* Using cursor T000516 */
         pr_default.execute(14, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A14WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "");
               AnyError = 1;
            }
         }
         A53WWPNotificationDefinitionName = T000516_A53WWPNotificationDefinitionName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID","{handler:'Valid_Wwpwebnotificationid',iparms:[{av:'A17WWPWebNotificationId',fld:'WWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'cmbWWPWebNotificationStatus'},{av:'A48WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A41WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A52WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID",",oparms:[{av:'A38WWPWebNotificationTitle',fld:'WWPWEBNOTIFICATIONTITLE',pic:''},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A39WWPWebNotificationText',fld:'WWPWEBNOTIFICATIONTEXT',pic:''},{av:'A40WWPWebNotificationIcon',fld:'WWPWEBNOTIFICATIONICON',pic:''},{av:'A47WWPWebNotificationClientId',fld:'WWPWEBNOTIFICATIONCLIENTID',pic:''},{av:'cmbWWPWebNotificationStatus'},{av:'A48WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A41WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A52WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A49WWPWebNotificationProcessed',fld:'WWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A42WWPWebNotificationRead',fld:'WWPWEBNOTIFICATIONREAD',pic:'99/99/9999 99:99:99.999'},{av:'A50WWPWebNotificationDetail',fld:'WWPWEBNOTIFICATIONDETAIL',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z17WWPWebNotificationId'},{av:'Z38WWPWebNotificationTitle'},{av:'Z16WWPNotificationId'},{av:'Z39WWPWebNotificationText'},{av:'Z40WWPWebNotificationIcon'},{av:'Z47WWPWebNotificationClientId'},{av:'Z48WWPWebNotificationStatus'},{av:'Z41WWPWebNotificationCreated'},{av:'Z52WWPWebNotificationScheduled'},{av:'Z49WWPWebNotificationProcessed'},{av:'Z42WWPWebNotificationRead'},{av:'Z50WWPWebNotificationDetail'},{av:'Z51WWPWebNotificationReceived'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z37WWPNotificationCreated'},{av:'Z54WWPNotificationMetadata'},{av:'Z53WWPNotificationDefinitionName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS","{handler:'Valid_Wwpwebnotificationstatus',iparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS",",oparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONCREATED","{handler:'Valid_Wwpwebnotificationcreated',iparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONCREATED",",oparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSCHEDULED","{handler:'Valid_Wwpwebnotificationscheduled',iparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSCHEDULED",",oparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONPROCESSED","{handler:'Valid_Wwpwebnotificationprocessed',iparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONPROCESSED",",oparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONREAD","{handler:'Valid_Wwpwebnotificationread',iparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONREAD",",oparms:[{av:'A51WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z38WWPWebNotificationTitle = "";
         Z39WWPWebNotificationText = "";
         Z40WWPWebNotificationIcon = "";
         Z41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A38WWPWebNotificationTitle = "";
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A54WWPNotificationMetadata = "";
         A53WWPNotificationDefinitionName = "";
         A39WWPWebNotificationText = "";
         A40WWPWebNotificationIcon = "";
         A47WWPWebNotificationClientId = "";
         A41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A50WWPWebNotificationDetail = "";
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
         Z47WWPWebNotificationClientId = "";
         Z50WWPWebNotificationDetail = "";
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z54WWPNotificationMetadata = "";
         Z53WWPNotificationDefinitionName = "";
         T00056_A14WWPNotificationDefinitionId = new long[1] ;
         T00056_A17WWPWebNotificationId = new long[1] ;
         T00056_A38WWPWebNotificationTitle = new string[] {""} ;
         T00056_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00056_A54WWPNotificationMetadata = new string[] {""} ;
         T00056_n54WWPNotificationMetadata = new bool[] {false} ;
         T00056_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00056_A39WWPWebNotificationText = new string[] {""} ;
         T00056_A40WWPWebNotificationIcon = new string[] {""} ;
         T00056_A47WWPWebNotificationClientId = new string[] {""} ;
         T00056_A48WWPWebNotificationStatus = new short[1] ;
         T00056_A41WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00056_A52WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T00056_A49WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T00056_A42WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T00056_n42WWPWebNotificationRead = new bool[] {false} ;
         T00056_A50WWPWebNotificationDetail = new string[] {""} ;
         T00056_n50WWPWebNotificationDetail = new bool[] {false} ;
         T00056_A51WWPWebNotificationReceived = new bool[] {false} ;
         T00056_n51WWPWebNotificationReceived = new bool[] {false} ;
         T00056_A16WWPNotificationId = new long[1] ;
         T00056_n16WWPNotificationId = new bool[] {false} ;
         T00054_A14WWPNotificationDefinitionId = new long[1] ;
         T00054_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00054_A54WWPNotificationMetadata = new string[] {""} ;
         T00054_n54WWPNotificationMetadata = new bool[] {false} ;
         T00055_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00057_A14WWPNotificationDefinitionId = new long[1] ;
         T00057_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00057_A54WWPNotificationMetadata = new string[] {""} ;
         T00057_n54WWPNotificationMetadata = new bool[] {false} ;
         T00058_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00059_A17WWPWebNotificationId = new long[1] ;
         T00053_A17WWPWebNotificationId = new long[1] ;
         T00053_A38WWPWebNotificationTitle = new string[] {""} ;
         T00053_A39WWPWebNotificationText = new string[] {""} ;
         T00053_A40WWPWebNotificationIcon = new string[] {""} ;
         T00053_A47WWPWebNotificationClientId = new string[] {""} ;
         T00053_A48WWPWebNotificationStatus = new short[1] ;
         T00053_A41WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00053_A52WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T00053_A49WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T00053_A42WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T00053_n42WWPWebNotificationRead = new bool[] {false} ;
         T00053_A50WWPWebNotificationDetail = new string[] {""} ;
         T00053_n50WWPWebNotificationDetail = new bool[] {false} ;
         T00053_A51WWPWebNotificationReceived = new bool[] {false} ;
         T00053_n51WWPWebNotificationReceived = new bool[] {false} ;
         T00053_A16WWPNotificationId = new long[1] ;
         T00053_n16WWPNotificationId = new bool[] {false} ;
         sMode5 = "";
         T000510_A17WWPWebNotificationId = new long[1] ;
         T000511_A17WWPWebNotificationId = new long[1] ;
         T00052_A17WWPWebNotificationId = new long[1] ;
         T00052_A38WWPWebNotificationTitle = new string[] {""} ;
         T00052_A39WWPWebNotificationText = new string[] {""} ;
         T00052_A40WWPWebNotificationIcon = new string[] {""} ;
         T00052_A47WWPWebNotificationClientId = new string[] {""} ;
         T00052_A48WWPWebNotificationStatus = new short[1] ;
         T00052_A41WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00052_A52WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T00052_A49WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T00052_A42WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T00052_n42WWPWebNotificationRead = new bool[] {false} ;
         T00052_A50WWPWebNotificationDetail = new string[] {""} ;
         T00052_n50WWPWebNotificationDetail = new bool[] {false} ;
         T00052_A51WWPWebNotificationReceived = new bool[] {false} ;
         T00052_n51WWPWebNotificationReceived = new bool[] {false} ;
         T00052_A16WWPNotificationId = new long[1] ;
         T00052_n16WWPNotificationId = new bool[] {false} ;
         T000512_A17WWPWebNotificationId = new long[1] ;
         T000515_A14WWPNotificationDefinitionId = new long[1] ;
         T000515_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000515_A54WWPNotificationMetadata = new string[] {""} ;
         T000515_n54WWPNotificationMetadata = new bool[] {false} ;
         T000516_A53WWPNotificationDefinitionName = new string[] {""} ;
         T000517_A17WWPWebNotificationId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ38WWPWebNotificationTitle = "";
         ZZ39WWPWebNotificationText = "";
         ZZ40WWPWebNotificationIcon = "";
         ZZ47WWPWebNotificationClientId = "";
         ZZ41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         ZZ42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         ZZ50WWPWebNotificationDetail = "";
         ZZ37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ54WWPNotificationMetadata = "";
         ZZ53WWPNotificationDefinitionName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__default(),
            new Object[][] {
                new Object[] {
               T00052_A17WWPWebNotificationId, T00052_A38WWPWebNotificationTitle, T00052_A39WWPWebNotificationText, T00052_A40WWPWebNotificationIcon, T00052_A47WWPWebNotificationClientId, T00052_A48WWPWebNotificationStatus, T00052_A41WWPWebNotificationCreated, T00052_A52WWPWebNotificationScheduled, T00052_A49WWPWebNotificationProcessed, T00052_A42WWPWebNotificationRead,
               T00052_n42WWPWebNotificationRead, T00052_A50WWPWebNotificationDetail, T00052_n50WWPWebNotificationDetail, T00052_A51WWPWebNotificationReceived, T00052_n51WWPWebNotificationReceived, T00052_A16WWPNotificationId, T00052_n16WWPNotificationId
               }
               , new Object[] {
               T00053_A17WWPWebNotificationId, T00053_A38WWPWebNotificationTitle, T00053_A39WWPWebNotificationText, T00053_A40WWPWebNotificationIcon, T00053_A47WWPWebNotificationClientId, T00053_A48WWPWebNotificationStatus, T00053_A41WWPWebNotificationCreated, T00053_A52WWPWebNotificationScheduled, T00053_A49WWPWebNotificationProcessed, T00053_A42WWPWebNotificationRead,
               T00053_n42WWPWebNotificationRead, T00053_A50WWPWebNotificationDetail, T00053_n50WWPWebNotificationDetail, T00053_A51WWPWebNotificationReceived, T00053_n51WWPWebNotificationReceived, T00053_A16WWPNotificationId, T00053_n16WWPNotificationId
               }
               , new Object[] {
               T00054_A14WWPNotificationDefinitionId, T00054_A37WWPNotificationCreated, T00054_A54WWPNotificationMetadata, T00054_n54WWPNotificationMetadata
               }
               , new Object[] {
               T00055_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               T00056_A14WWPNotificationDefinitionId, T00056_A17WWPWebNotificationId, T00056_A38WWPWebNotificationTitle, T00056_A37WWPNotificationCreated, T00056_A54WWPNotificationMetadata, T00056_n54WWPNotificationMetadata, T00056_A53WWPNotificationDefinitionName, T00056_A39WWPWebNotificationText, T00056_A40WWPWebNotificationIcon, T00056_A47WWPWebNotificationClientId,
               T00056_A48WWPWebNotificationStatus, T00056_A41WWPWebNotificationCreated, T00056_A52WWPWebNotificationScheduled, T00056_A49WWPWebNotificationProcessed, T00056_A42WWPWebNotificationRead, T00056_n42WWPWebNotificationRead, T00056_A50WWPWebNotificationDetail, T00056_n50WWPWebNotificationDetail, T00056_A51WWPWebNotificationReceived, T00056_n51WWPWebNotificationReceived,
               T00056_A16WWPNotificationId, T00056_n16WWPNotificationId
               }
               , new Object[] {
               T00057_A14WWPNotificationDefinitionId, T00057_A37WWPNotificationCreated, T00057_A54WWPNotificationMetadata, T00057_n54WWPNotificationMetadata
               }
               , new Object[] {
               T00058_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               T00059_A17WWPWebNotificationId
               }
               , new Object[] {
               T000510_A17WWPWebNotificationId
               }
               , new Object[] {
               T000511_A17WWPWebNotificationId
               }
               , new Object[] {
               T000512_A17WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000515_A14WWPNotificationDefinitionId, T000515_A37WWPNotificationCreated, T000515_A54WWPNotificationMetadata, T000515_n54WWPNotificationMetadata
               }
               , new Object[] {
               T000516_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               T000517_A17WWPWebNotificationId
               }
            }
         );
         Z52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z48WWPWebNotificationStatus = 1;
         A48WWPWebNotificationStatus = 1;
         i48WWPWebNotificationStatus = 1;
      }

      private short Z48WWPWebNotificationStatus ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A48WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private short gxajaxcallmode ;
      private short i48WWPWebNotificationStatus ;
      private short ZZ48WWPWebNotificationStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPWebNotificationId_Enabled ;
      private int edtWWPWebNotificationTitle_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPWebNotificationText_Enabled ;
      private int edtWWPWebNotificationIcon_Enabled ;
      private int edtWWPWebNotificationClientId_Enabled ;
      private int edtWWPWebNotificationCreated_Enabled ;
      private int edtWWPWebNotificationScheduled_Enabled ;
      private int edtWWPWebNotificationProcessed_Enabled ;
      private int edtWWPWebNotificationRead_Enabled ;
      private int edtWWPWebNotificationDetail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z17WWPWebNotificationId ;
      private long Z16WWPNotificationId ;
      private long A16WWPNotificationId ;
      private long A14WWPNotificationDefinitionId ;
      private long A17WWPWebNotificationId ;
      private long Z14WWPNotificationDefinitionId ;
      private long ZZ17WWPWebNotificationId ;
      private long ZZ16WWPNotificationId ;
      private long ZZ14WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPWebNotificationId_Internalname ;
      private string cmbWWPWebNotificationStatus_Internalname ;
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
      private string edtWWPWebNotificationId_Jsonclick ;
      private string edtWWPWebNotificationTitle_Internalname ;
      private string edtWWPWebNotificationTitle_Jsonclick ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPWebNotificationText_Internalname ;
      private string edtWWPWebNotificationText_Jsonclick ;
      private string edtWWPWebNotificationIcon_Internalname ;
      private string edtWWPWebNotificationClientId_Internalname ;
      private string cmbWWPWebNotificationStatus_Jsonclick ;
      private string edtWWPWebNotificationCreated_Internalname ;
      private string edtWWPWebNotificationCreated_Jsonclick ;
      private string edtWWPWebNotificationScheduled_Internalname ;
      private string edtWWPWebNotificationScheduled_Jsonclick ;
      private string edtWWPWebNotificationProcessed_Internalname ;
      private string edtWWPWebNotificationProcessed_Jsonclick ;
      private string edtWWPWebNotificationRead_Internalname ;
      private string edtWWPWebNotificationRead_Jsonclick ;
      private string edtWWPWebNotificationDetail_Internalname ;
      private string chkWWPWebNotificationReceived_Internalname ;
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
      private string sMode5 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z41WWPWebNotificationCreated ;
      private DateTime Z52WWPWebNotificationScheduled ;
      private DateTime Z49WWPWebNotificationProcessed ;
      private DateTime Z42WWPWebNotificationRead ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime A41WWPWebNotificationCreated ;
      private DateTime A52WWPWebNotificationScheduled ;
      private DateTime A49WWPWebNotificationProcessed ;
      private DateTime A42WWPWebNotificationRead ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime i41WWPWebNotificationCreated ;
      private DateTime i52WWPWebNotificationScheduled ;
      private DateTime ZZ41WWPWebNotificationCreated ;
      private DateTime ZZ52WWPWebNotificationScheduled ;
      private DateTime ZZ49WWPWebNotificationProcessed ;
      private DateTime ZZ42WWPWebNotificationRead ;
      private DateTime ZZ37WWPNotificationCreated ;
      private bool Z51WWPWebNotificationReceived ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n16WWPNotificationId ;
      private bool wbErr ;
      private bool A51WWPWebNotificationReceived ;
      private bool n51WWPWebNotificationReceived ;
      private bool n42WWPWebNotificationRead ;
      private bool n54WWPNotificationMetadata ;
      private bool n50WWPWebNotificationDetail ;
      private bool Gx_longc ;
      private bool ZZ51WWPWebNotificationReceived ;
      private string A54WWPNotificationMetadata ;
      private string A47WWPWebNotificationClientId ;
      private string A50WWPWebNotificationDetail ;
      private string Z47WWPWebNotificationClientId ;
      private string Z50WWPWebNotificationDetail ;
      private string Z54WWPNotificationMetadata ;
      private string ZZ47WWPWebNotificationClientId ;
      private string ZZ50WWPWebNotificationDetail ;
      private string ZZ54WWPNotificationMetadata ;
      private string Z38WWPWebNotificationTitle ;
      private string Z39WWPWebNotificationText ;
      private string Z40WWPWebNotificationIcon ;
      private string A38WWPWebNotificationTitle ;
      private string A53WWPNotificationDefinitionName ;
      private string A39WWPWebNotificationText ;
      private string A40WWPWebNotificationIcon ;
      private string Z53WWPNotificationDefinitionName ;
      private string ZZ38WWPWebNotificationTitle ;
      private string ZZ39WWPWebNotificationText ;
      private string ZZ40WWPWebNotificationIcon ;
      private string ZZ53WWPNotificationDefinitionName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPWebNotificationStatus ;
      private GXCheckbox chkWWPWebNotificationReceived ;
      private IDataStoreProvider pr_default ;
      private long[] T00056_A14WWPNotificationDefinitionId ;
      private long[] T00056_A17WWPWebNotificationId ;
      private string[] T00056_A38WWPWebNotificationTitle ;
      private DateTime[] T00056_A37WWPNotificationCreated ;
      private string[] T00056_A54WWPNotificationMetadata ;
      private bool[] T00056_n54WWPNotificationMetadata ;
      private string[] T00056_A53WWPNotificationDefinitionName ;
      private string[] T00056_A39WWPWebNotificationText ;
      private string[] T00056_A40WWPWebNotificationIcon ;
      private string[] T00056_A47WWPWebNotificationClientId ;
      private short[] T00056_A48WWPWebNotificationStatus ;
      private DateTime[] T00056_A41WWPWebNotificationCreated ;
      private DateTime[] T00056_A52WWPWebNotificationScheduled ;
      private DateTime[] T00056_A49WWPWebNotificationProcessed ;
      private DateTime[] T00056_A42WWPWebNotificationRead ;
      private bool[] T00056_n42WWPWebNotificationRead ;
      private string[] T00056_A50WWPWebNotificationDetail ;
      private bool[] T00056_n50WWPWebNotificationDetail ;
      private bool[] T00056_A51WWPWebNotificationReceived ;
      private bool[] T00056_n51WWPWebNotificationReceived ;
      private long[] T00056_A16WWPNotificationId ;
      private bool[] T00056_n16WWPNotificationId ;
      private long[] T00054_A14WWPNotificationDefinitionId ;
      private DateTime[] T00054_A37WWPNotificationCreated ;
      private string[] T00054_A54WWPNotificationMetadata ;
      private bool[] T00054_n54WWPNotificationMetadata ;
      private string[] T00055_A53WWPNotificationDefinitionName ;
      private long[] T00057_A14WWPNotificationDefinitionId ;
      private DateTime[] T00057_A37WWPNotificationCreated ;
      private string[] T00057_A54WWPNotificationMetadata ;
      private bool[] T00057_n54WWPNotificationMetadata ;
      private string[] T00058_A53WWPNotificationDefinitionName ;
      private long[] T00059_A17WWPWebNotificationId ;
      private long[] T00053_A17WWPWebNotificationId ;
      private string[] T00053_A38WWPWebNotificationTitle ;
      private string[] T00053_A39WWPWebNotificationText ;
      private string[] T00053_A40WWPWebNotificationIcon ;
      private string[] T00053_A47WWPWebNotificationClientId ;
      private short[] T00053_A48WWPWebNotificationStatus ;
      private DateTime[] T00053_A41WWPWebNotificationCreated ;
      private DateTime[] T00053_A52WWPWebNotificationScheduled ;
      private DateTime[] T00053_A49WWPWebNotificationProcessed ;
      private DateTime[] T00053_A42WWPWebNotificationRead ;
      private bool[] T00053_n42WWPWebNotificationRead ;
      private string[] T00053_A50WWPWebNotificationDetail ;
      private bool[] T00053_n50WWPWebNotificationDetail ;
      private bool[] T00053_A51WWPWebNotificationReceived ;
      private bool[] T00053_n51WWPWebNotificationReceived ;
      private long[] T00053_A16WWPNotificationId ;
      private bool[] T00053_n16WWPNotificationId ;
      private long[] T000510_A17WWPWebNotificationId ;
      private long[] T000511_A17WWPWebNotificationId ;
      private long[] T00052_A17WWPWebNotificationId ;
      private string[] T00052_A38WWPWebNotificationTitle ;
      private string[] T00052_A39WWPWebNotificationText ;
      private string[] T00052_A40WWPWebNotificationIcon ;
      private string[] T00052_A47WWPWebNotificationClientId ;
      private short[] T00052_A48WWPWebNotificationStatus ;
      private DateTime[] T00052_A41WWPWebNotificationCreated ;
      private DateTime[] T00052_A52WWPWebNotificationScheduled ;
      private DateTime[] T00052_A49WWPWebNotificationProcessed ;
      private DateTime[] T00052_A42WWPWebNotificationRead ;
      private bool[] T00052_n42WWPWebNotificationRead ;
      private string[] T00052_A50WWPWebNotificationDetail ;
      private bool[] T00052_n50WWPWebNotificationDetail ;
      private bool[] T00052_A51WWPWebNotificationReceived ;
      private bool[] T00052_n51WWPWebNotificationReceived ;
      private long[] T00052_A16WWPNotificationId ;
      private bool[] T00052_n16WWPNotificationId ;
      private long[] T000512_A17WWPWebNotificationId ;
      private long[] T000515_A14WWPNotificationDefinitionId ;
      private DateTime[] T000515_A37WWPNotificationCreated ;
      private string[] T000515_A54WWPNotificationMetadata ;
      private bool[] T000515_n54WWPNotificationMetadata ;
      private string[] T000516_A53WWPNotificationDefinitionName ;
      private long[] T000517_A17WWPWebNotificationId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_webnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00056;
        prmT00056 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00054;
        prmT00054 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00055;
        prmT00055 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00057;
        prmT00057 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00058;
        prmT00058 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00059;
        prmT00059 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00053;
        prmT00053 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000510;
        prmT000510 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000511;
        prmT000511 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00052;
        prmT00052 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000512;
        prmT000512 = new Object[] {
        new Object[] {"@WWPWebNotificationTitle",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPWebNotificationText",SqlDbType.NVarChar,120,0} ,
        new Object[] {"@WWPWebNotificationIcon",SqlDbType.NVarChar,255,0} ,
        new Object[] {"@WWPWebNotificationClientId",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationRead",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationReceived",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000513;
        prmT000513 = new Object[] {
        new Object[] {"@WWPWebNotificationTitle",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPWebNotificationText",SqlDbType.NVarChar,120,0} ,
        new Object[] {"@WWPWebNotificationIcon",SqlDbType.NVarChar,255,0} ,
        new Object[] {"@WWPWebNotificationClientId",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationRead",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationReceived",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000514;
        prmT000514 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000517;
        prmT000517 = new Object[] {
        };
        Object[] prmT000515;
        prmT000515 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000516;
        prmT000516 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("T00052", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WITH (UPDLOCK) WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00053", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00054", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00055", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00056", "SELECT T2.[WWPNotificationDefinitionId], TM1.[WWPWebNotificationId], TM1.[WWPWebNotificationTitle], T2.[WWPNotificationCreated], T2.[WWPNotificationMetadata], T3.[WWPNotificationDefinitionName], TM1.[WWPWebNotificationText], TM1.[WWPWebNotificationIcon], TM1.[WWPWebNotificationClientId], TM1.[WWPWebNotificationStatus], TM1.[WWPWebNotificationCreated], TM1.[WWPWebNotificationScheduled], TM1.[WWPWebNotificationProcessed], TM1.[WWPWebNotificationRead], TM1.[WWPWebNotificationDetail], TM1.[WWPWebNotificationReceived], TM1.[WWPNotificationId] FROM (([WWP_WebNotification] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) LEFT JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE TM1.[WWPWebNotificationId] = @WWPWebNotificationId ORDER BY TM1.[WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00057", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00058", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00059", "SELECT [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000510", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE ( [WWPWebNotificationId] > @WWPWebNotificationId) ORDER BY [WWPWebNotificationId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000511", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE ( [WWPWebNotificationId] < @WWPWebNotificationId) ORDER BY [WWPWebNotificationId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000512", "INSERT INTO [WWP_WebNotification]([WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId]) VALUES(@WWPWebNotificationTitle, @WWPWebNotificationText, @WWPWebNotificationIcon, @WWPWebNotificationClientId, @WWPWebNotificationStatus, @WWPWebNotificationCreated, @WWPWebNotificationScheduled, @WWPWebNotificationProcessed, @WWPWebNotificationRead, @WWPWebNotificationDetail, @WWPWebNotificationReceived, @WWPNotificationId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000512)
           ,new CursorDef("T000513", "UPDATE [WWP_WebNotification] SET [WWPWebNotificationTitle]=@WWPWebNotificationTitle, [WWPWebNotificationText]=@WWPWebNotificationText, [WWPWebNotificationIcon]=@WWPWebNotificationIcon, [WWPWebNotificationClientId]=@WWPWebNotificationClientId, [WWPWebNotificationStatus]=@WWPWebNotificationStatus, [WWPWebNotificationCreated]=@WWPWebNotificationCreated, [WWPWebNotificationScheduled]=@WWPWebNotificationScheduled, [WWPWebNotificationProcessed]=@WWPWebNotificationProcessed, [WWPWebNotificationRead]=@WWPWebNotificationRead, [WWPWebNotificationDetail]=@WWPWebNotificationDetail, [WWPWebNotificationReceived]=@WWPWebNotificationReceived, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmT000513)
           ,new CursorDef("T000514", "DELETE FROM [WWP_WebNotification]  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmT000514)
           ,new CursorDef("T000515", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000516", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000517", "SELECT [WWPWebNotificationId] FROM [WWP_WebNotification] ORDER BY [WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,100, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.getGXDateTime(9, true);
              table[9][0] = rslt.getGXDateTime(10, true);
              table[10][0] = rslt.wasNull(10);
              table[11][0] = rslt.getLongVarchar(11);
              table[12][0] = rslt.wasNull(11);
              table[13][0] = rslt.getBool(12);
              table[14][0] = rslt.wasNull(12);
              table[15][0] = rslt.getLong(13);
              table[16][0] = rslt.wasNull(13);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.getGXDateTime(9, true);
              table[9][0] = rslt.getGXDateTime(10, true);
              table[10][0] = rslt.wasNull(10);
              table[11][0] = rslt.getLongVarchar(11);
              table[12][0] = rslt.wasNull(11);
              table[13][0] = rslt.getBool(12);
              table[14][0] = rslt.wasNull(12);
              table[15][0] = rslt.getLong(13);
              table[16][0] = rslt.wasNull(13);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.wasNull(3);
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.wasNull(5);
              table[6][0] = rslt.getVarchar(6);
              table[7][0] = rslt.getVarchar(7);
              table[8][0] = rslt.getVarchar(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.getShort(10);
              table[11][0] = rslt.getGXDateTime(11, true);
              table[12][0] = rslt.getGXDateTime(12, true);
              table[13][0] = rslt.getGXDateTime(13, true);
              table[14][0] = rslt.getGXDateTime(14, true);
              table[15][0] = rslt.wasNull(14);
              table[16][0] = rslt.getLongVarchar(15);
              table[17][0] = rslt.wasNull(15);
              table[18][0] = rslt.getBool(16);
              table[19][0] = rslt.wasNull(16);
              table[20][0] = rslt.getLong(17);
              table[21][0] = rslt.wasNull(17);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.wasNull(3);
              return;
           case 6 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 7 :
              table[0][0] = rslt.getLong(1);
              return;
           case 8 :
              table[0][0] = rslt.getLong(1);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              return;
           case 13 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.wasNull(3);
              return;
           case 14 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 15 :
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 2 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 3 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 5 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 6 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              stmt.SetParameterDatetime(7, (DateTime)parms[6], true);
              stmt.SetParameterDatetime(8, (DateTime)parms[7], true);
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 9 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(9, (DateTime)parms[9], true);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 10 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(10, (string)parms[11]);
              }
              if ( (bool)parms[12] )
              {
                 stmt.setNull( 11 , SqlDbType.Bit );
              }
              else
              {
                 stmt.SetParameter(11, (bool)parms[13]);
              }
              if ( (bool)parms[14] )
              {
                 stmt.setNull( 12 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(12, (long)parms[15]);
              }
              return;
           case 11 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              stmt.SetParameterDatetime(7, (DateTime)parms[6], true);
              stmt.SetParameterDatetime(8, (DateTime)parms[7], true);
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 9 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(9, (DateTime)parms[9], true);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 10 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(10, (string)parms[11]);
              }
              if ( (bool)parms[12] )
              {
                 stmt.setNull( 11 , SqlDbType.Bit );
              }
              else
              {
                 stmt.SetParameter(11, (bool)parms[13]);
              }
              if ( (bool)parms[14] )
              {
                 stmt.setNull( 12 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(12, (long)parms[15]);
              }
              stmt.SetParameter(13, (long)parms[16]);
              return;
           case 12 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 13 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 14 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
