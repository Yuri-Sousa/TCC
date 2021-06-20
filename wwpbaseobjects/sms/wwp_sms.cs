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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
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
            gxLoad_9( A16WWPNotificationId) ;
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
            Form.Meta.addItem("description", "WWP_SMS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_sms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_sms( IGxContext context )
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
         cmbWWPSMSStatus = new GXCombobox();
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
            return "sms_Execute" ;
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
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A29WWPSMSStatus = (short)(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A29WWPSMSStatus), 4, 0))), "."));
            AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A29WWPSMSStatus), 4, 0));
            AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_SMS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSMSId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15WWPSMSId), 10, 0, ",", "")), ((edtWWPSMSId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A15WWPSMSId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A15WWPSMSId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSMessage_Internalname, "Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSMessage_Internalname, A32WWPSMSMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", 0, 1, edtWWPSMSMessage_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSSenderNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSSenderNumber_Internalname, "Sender Number", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSSenderNumber_Internalname, A33WWPSMSSenderNumber, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtWWPSMSSenderNumber_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSRecipientNumbers_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSRecipientNumbers_Internalname, "Recipient Numbers", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSRecipientNumbers_Internalname, A34WWPSMSRecipientNumbers, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, 1, edtWWPSMSRecipientNumbers_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbWWPSMSStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPSMSStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPSMSStatus, cmbWWPSMSStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A29WWPSMSStatus), 4, 0)), 1, cmbWWPSMSStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPSMSStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A29WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", (string)(cmbWWPSMSStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSCreated_Internalname, "Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSCreated_Internalname, context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A35WWPSMSCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSScheduled_Internalname, "Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSScheduled_Internalname, context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A36WWPSMSScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSProcessed_Internalname, "Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSProcessed_Internalname, context.localUtil.TToC( A30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A30WWPSMSProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSMSDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSDetail_Internalname, "Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSDetail_Internalname, A31WWPSMSDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", 0, 1, edtWWPSMSDetail_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ",", "")), ((edtWWPNotificationId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A37WWPNotificationCreated, "99/99/9999 99:99:99.999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
            Z15WWPSMSId = (long)(context.localUtil.CToN( cgiGet( "Z15WWPSMSId"), ",", "."));
            Z29WWPSMSStatus = (short)(context.localUtil.CToN( cgiGet( "Z29WWPSMSStatus"), ",", "."));
            Z35WWPSMSCreated = context.localUtil.CToT( cgiGet( "Z35WWPSMSCreated"), 0);
            Z36WWPSMSScheduled = context.localUtil.CToT( cgiGet( "Z36WWPSMSScheduled"), 0);
            Z30WWPSMSProcessed = context.localUtil.CToT( cgiGet( "Z30WWPSMSProcessed"), 0);
            n30WWPSMSProcessed = ((DateTime.MinValue==A30WWPSMSProcessed) ? true : false);
            Z16WWPNotificationId = (long)(context.localUtil.CToN( cgiGet( "Z16WWPNotificationId"), ",", "."));
            n16WWPNotificationId = ((0==A16WWPNotificationId) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSMSID");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A15WWPSMSId = 0;
               AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
            }
            else
            {
               A15WWPSMSId = (long)(context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ",", "."));
               AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
            }
            A32WWPSMSMessage = cgiGet( edtWWPSMSMessage_Internalname);
            AssignAttri("", false, "A32WWPSMSMessage", A32WWPSMSMessage);
            A33WWPSMSSenderNumber = cgiGet( edtWWPSMSSenderNumber_Internalname);
            AssignAttri("", false, "A33WWPSMSSenderNumber", A33WWPSMSSenderNumber);
            A34WWPSMSRecipientNumbers = cgiGet( edtWWPSMSRecipientNumbers_Internalname);
            AssignAttri("", false, "A34WWPSMSRecipientNumbers", A34WWPSMSRecipientNumbers);
            cmbWWPSMSStatus.CurrentValue = cgiGet( cmbWWPSMSStatus_Internalname);
            A29WWPSMSStatus = (short)(NumberUtil.Val( cgiGet( cmbWWPSMSStatus_Internalname), "."));
            AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Created"}), 1, "WWPSMSCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A35WWPSMSCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A35WWPSMSCreated = context.localUtil.CToT( cgiGet( edtWWPSMSCreated_Internalname));
               AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSScheduled_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Scheduled"}), 1, "WWPSMSSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A36WWPSMSScheduled = context.localUtil.CToT( cgiGet( edtWWPSMSScheduled_Internalname));
               AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSProcessed_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Processed"}), 1, "WWPSMSPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
               n30WWPSMSProcessed = false;
               AssignAttri("", false, "A30WWPSMSProcessed", context.localUtil.TToC( A30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A30WWPSMSProcessed = context.localUtil.CToT( cgiGet( edtWWPSMSProcessed_Internalname));
               n30WWPSMSProcessed = false;
               AssignAttri("", false, "A30WWPSMSProcessed", context.localUtil.TToC( A30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            n30WWPSMSProcessed = ((DateTime.MinValue==A30WWPSMSProcessed) ? true : false);
            A31WWPSMSDetail = cgiGet( edtWWPSMSDetail_Internalname);
            n31WWPSMSDetail = false;
            AssignAttri("", false, "A31WWPSMSDetail", A31WWPSMSDetail);
            n31WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A31WWPSMSDetail)) ? true : false);
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
               A15WWPSMSId = (long)(NumberUtil.Val( GetPar( "WWPSMSId"), "."));
               AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
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
               InitAll044( ) ;
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
         DisableAttributes044( ) ;
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

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z29WWPSMSStatus = T00043_A29WWPSMSStatus[0];
               Z35WWPSMSCreated = T00043_A35WWPSMSCreated[0];
               Z36WWPSMSScheduled = T00043_A36WWPSMSScheduled[0];
               Z30WWPSMSProcessed = T00043_A30WWPSMSProcessed[0];
               Z16WWPNotificationId = T00043_A16WWPNotificationId[0];
            }
            else
            {
               Z29WWPSMSStatus = A29WWPSMSStatus;
               Z35WWPSMSCreated = A35WWPSMSCreated;
               Z36WWPSMSScheduled = A36WWPSMSScheduled;
               Z30WWPSMSProcessed = A30WWPSMSProcessed;
               Z16WWPNotificationId = A16WWPNotificationId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z15WWPSMSId = A15WWPSMSId;
            Z32WWPSMSMessage = A32WWPSMSMessage;
            Z33WWPSMSSenderNumber = A33WWPSMSSenderNumber;
            Z34WWPSMSRecipientNumbers = A34WWPSMSRecipientNumbers;
            Z29WWPSMSStatus = A29WWPSMSStatus;
            Z35WWPSMSCreated = A35WWPSMSCreated;
            Z36WWPSMSScheduled = A36WWPSMSScheduled;
            Z30WWPSMSProcessed = A30WWPSMSProcessed;
            Z31WWPSMSDetail = A31WWPSMSDetail;
            Z16WWPNotificationId = A16WWPNotificationId;
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A29WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A29WWPSMSStatus = 1;
            AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A35WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A36WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
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

      protected void Load044( )
      {
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
            A32WWPSMSMessage = T00045_A32WWPSMSMessage[0];
            AssignAttri("", false, "A32WWPSMSMessage", A32WWPSMSMessage);
            A33WWPSMSSenderNumber = T00045_A33WWPSMSSenderNumber[0];
            AssignAttri("", false, "A33WWPSMSSenderNumber", A33WWPSMSSenderNumber);
            A34WWPSMSRecipientNumbers = T00045_A34WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A34WWPSMSRecipientNumbers", A34WWPSMSRecipientNumbers);
            A29WWPSMSStatus = T00045_A29WWPSMSStatus[0];
            AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
            A35WWPSMSCreated = T00045_A35WWPSMSCreated[0];
            AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            A36WWPSMSScheduled = T00045_A36WWPSMSScheduled[0];
            AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            A30WWPSMSProcessed = T00045_A30WWPSMSProcessed[0];
            n30WWPSMSProcessed = T00045_n30WWPSMSProcessed[0];
            AssignAttri("", false, "A30WWPSMSProcessed", context.localUtil.TToC( A30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            A31WWPSMSDetail = T00045_A31WWPSMSDetail[0];
            n31WWPSMSDetail = T00045_n31WWPSMSDetail[0];
            AssignAttri("", false, "A31WWPSMSDetail", A31WWPSMSDetail);
            A37WWPNotificationCreated = T00045_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A16WWPNotificationId = T00045_A16WWPNotificationId[0];
            n16WWPNotificationId = T00045_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            ZM044( -8) ;
         }
         pr_default.close(3);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A29WWPSMSStatus == 1 ) || ( A29WWPSMSStatus == 2 ) || ( A29WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo SMS Status fora do intervalo", "OutOfRange", 1, "WWPSMSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPSMSStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A35WWPSMSCreated) || ( A35WWPSMSCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo SMS Created fora do intervalo", "OutOfRange", 1, "WWPSMSCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A36WWPSMSScheduled) || ( A36WWPSMSScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo SMS Scheduled fora do intervalo", "OutOfRange", 1, "WWPSMSSCHEDULED");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSScheduled_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A30WWPSMSProcessed) || ( A30WWPSMSProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo SMS Processed fora do intervalo", "OutOfRange", 1, "WWPSMSPROCESSED");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSProcessed_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00044 */
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
         A37WWPNotificationCreated = T00044_A37WWPNotificationCreated[0];
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A16WWPNotificationId )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A37WWPNotificationCreated = T00046_A37WWPNotificationCreated[0];
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 8) ;
            RcdFound4 = 1;
            A15WWPSMSId = T00043_A15WWPSMSId[0];
            AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
            A32WWPSMSMessage = T00043_A32WWPSMSMessage[0];
            AssignAttri("", false, "A32WWPSMSMessage", A32WWPSMSMessage);
            A33WWPSMSSenderNumber = T00043_A33WWPSMSSenderNumber[0];
            AssignAttri("", false, "A33WWPSMSSenderNumber", A33WWPSMSSenderNumber);
            A34WWPSMSRecipientNumbers = T00043_A34WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A34WWPSMSRecipientNumbers", A34WWPSMSRecipientNumbers);
            A29WWPSMSStatus = T00043_A29WWPSMSStatus[0];
            AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
            A35WWPSMSCreated = T00043_A35WWPSMSCreated[0];
            AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            A36WWPSMSScheduled = T00043_A36WWPSMSScheduled[0];
            AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            A30WWPSMSProcessed = T00043_A30WWPSMSProcessed[0];
            n30WWPSMSProcessed = T00043_n30WWPSMSProcessed[0];
            AssignAttri("", false, "A30WWPSMSProcessed", context.localUtil.TToC( A30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            A31WWPSMSDetail = T00043_A31WWPSMSDetail[0];
            n31WWPSMSDetail = T00043_n31WWPSMSDetail[0];
            AssignAttri("", false, "A31WWPSMSDetail", A31WWPSMSDetail);
            A16WWPNotificationId = T00043_A16WWPNotificationId[0];
            n16WWPNotificationId = T00043_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            Z15WWPSMSId = A15WWPSMSId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0;
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00048_A15WWPSMSId[0] < A15WWPSMSId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00048_A15WWPSMSId[0] > A15WWPSMSId ) ) )
            {
               A15WWPSMSId = T00048_A15WWPSMSId[0];
               AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00049_A15WWPSMSId[0] > A15WWPSMSId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00049_A15WWPSMSId[0] < A15WWPSMSId ) ) )
            {
               A15WWPSMSId = T00049_A15WWPSMSId[0];
               AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A15WWPSMSId != Z15WWPSMSId )
               {
                  A15WWPSMSId = Z15WWPSMSId;
                  AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSMSID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A15WWPSMSId != Z15WWPSMSId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSMSID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( A15WWPSMSId != Z15WWPSMSId )
         {
            A15WWPSMSId = Z15WWPSMSId;
            AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSMSId_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A15WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z29WWPSMSStatus != T00042_A29WWPSMSStatus[0] ) || ( Z35WWPSMSCreated != T00042_A35WWPSMSCreated[0] ) || ( Z36WWPSMSScheduled != T00042_A36WWPSMSScheduled[0] ) || ( Z30WWPSMSProcessed != T00042_A30WWPSMSProcessed[0] ) || ( Z16WWPNotificationId != T00042_A16WWPNotificationId[0] ) )
            {
               if ( Z29WWPSMSStatus != T00042_A29WWPSMSStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSStatus");
                  GXUtil.WriteLogRaw("Old: ",Z29WWPSMSStatus);
                  GXUtil.WriteLogRaw("Current: ",T00042_A29WWPSMSStatus[0]);
               }
               if ( Z35WWPSMSCreated != T00042_A35WWPSMSCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSCreated");
                  GXUtil.WriteLogRaw("Old: ",Z35WWPSMSCreated);
                  GXUtil.WriteLogRaw("Current: ",T00042_A35WWPSMSCreated[0]);
               }
               if ( Z36WWPSMSScheduled != T00042_A36WWPSMSScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z36WWPSMSScheduled);
                  GXUtil.WriteLogRaw("Current: ",T00042_A36WWPSMSScheduled[0]);
               }
               if ( Z30WWPSMSProcessed != T00042_A30WWPSMSProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z30WWPSMSProcessed);
                  GXUtil.WriteLogRaw("Current: ",T00042_A30WWPSMSProcessed[0]);
               }
               if ( Z16WWPNotificationId != T00042_A16WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z16WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A16WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         if ( ! IsAuthorized("sms_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000410 */
                     pr_default.execute(8, new Object[] {A32WWPSMSMessage, A33WWPSMSSenderNumber, A34WWPSMSRecipientNumbers, A29WWPSMSStatus, A35WWPSMSCreated, A36WWPSMSScheduled, n30WWPSMSProcessed, A30WWPSMSProcessed, n31WWPSMSDetail, A31WWPSMSDetail, n16WWPNotificationId, A16WWPNotificationId});
                     A15WWPSMSId = T000410_A15WWPSMSId[0];
                     AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         if ( ! IsAuthorized("sms_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000411 */
                     pr_default.execute(9, new Object[] {A32WWPSMSMessage, A33WWPSMSSenderNumber, A34WWPSMSRecipientNumbers, A29WWPSMSStatus, A35WWPSMSCreated, A36WWPSMSScheduled, n30WWPSMSProcessed, A30WWPSMSProcessed, n31WWPSMSDetail, A31WWPSMSDetail, n16WWPNotificationId, A16WWPNotificationId, A15WWPSMSId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("sms_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000412 */
                  pr_default.execute(10, new Object[] {A15WWPSMSId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_SMS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll044( ) ;
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
                        ResetCaption040( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000413 */
            pr_default.execute(11, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            A37WWPNotificationCreated = T000413_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            pr_default.close(11);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Using cursor T000414 */
         pr_default.execute(12);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound4 = 1;
            A15WWPSMSId = T000414_A15WWPSMSId[0];
            AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound4 = 1;
            A15WWPSMSId = T000414_A15WWPSMSId[0];
            AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtWWPSMSId_Enabled = 0;
         AssignProp("", false, edtWWPSMSId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSId_Enabled), 5, 0), true);
         edtWWPSMSMessage_Enabled = 0;
         AssignProp("", false, edtWWPSMSMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSMessage_Enabled), 5, 0), true);
         edtWWPSMSSenderNumber_Enabled = 0;
         AssignProp("", false, edtWWPSMSSenderNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSSenderNumber_Enabled), 5, 0), true);
         edtWWPSMSRecipientNumbers_Enabled = 0;
         AssignProp("", false, edtWWPSMSRecipientNumbers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSRecipientNumbers_Enabled), 5, 0), true);
         cmbWWPSMSStatus.Enabled = 0;
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPSMSStatus.Enabled), 5, 0), true);
         edtWWPSMSCreated_Enabled = 0;
         AssignProp("", false, edtWWPSMSCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSCreated_Enabled), 5, 0), true);
         edtWWPSMSScheduled_Enabled = 0;
         AssignProp("", false, edtWWPSMSScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSScheduled_Enabled), 5, 0), true);
         edtWWPSMSProcessed_Enabled = 0;
         AssignProp("", false, edtWWPSMSProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSProcessed_Enabled), 5, 0), true);
         edtWWPSMSDetail_Enabled = 0;
         AssignProp("", false, edtWWPSMSDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815475350", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.sms.wwp_sms.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z15WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15WWPSMSId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z29WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29WWPSMSStatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z35WWPSMSCreated", context.localUtil.TToC( Z35WWPSMSCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z36WWPSMSScheduled", context.localUtil.TToC( Z36WWPSMSScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z30WWPSMSProcessed", context.localUtil.TToC( Z30WWPSMSProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.sms.wwp_sms.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SMS.WWP_SMS" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_SMS" ;
      }

      protected void InitializeNonKey044( )
      {
         A32WWPSMSMessage = "";
         AssignAttri("", false, "A32WWPSMSMessage", A32WWPSMSMessage);
         A33WWPSMSSenderNumber = "";
         AssignAttri("", false, "A33WWPSMSSenderNumber", A33WWPSMSSenderNumber);
         A34WWPSMSRecipientNumbers = "";
         AssignAttri("", false, "A34WWPSMSRecipientNumbers", A34WWPSMSRecipientNumbers);
         A30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n30WWPSMSProcessed = false;
         AssignAttri("", false, "A30WWPSMSProcessed", context.localUtil.TToC( A30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
         n30WWPSMSProcessed = ((DateTime.MinValue==A30WWPSMSProcessed) ? true : false);
         A31WWPSMSDetail = "";
         n31WWPSMSDetail = false;
         AssignAttri("", false, "A31WWPSMSDetail", A31WWPSMSDetail);
         n31WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A31WWPSMSDetail)) ? true : false);
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
         n16WWPNotificationId = ((0==A16WWPNotificationId) ? true : false);
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A29WWPSMSStatus = 1;
         AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
         A35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         A36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
         Z29WWPSMSStatus = 0;
         Z35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z16WWPNotificationId = 0;
      }

      protected void InitAll044( )
      {
         A15WWPSMSId = 0;
         AssignAttri("", false, "A15WWPSMSId", StringUtil.LTrimStr( (decimal)(A15WWPSMSId), 10, 0));
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29WWPSMSStatus = i29WWPSMSStatus;
         AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
         A35WWPSMSCreated = i35WWPSMSCreated;
         AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         A36WWPSMSScheduled = i36WWPSMSScheduled;
         AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815475367", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/sms/wwp_sms.js", "?202142815475368", false, true);
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
         edtWWPSMSId_Internalname = "WWPSMSID";
         edtWWPSMSMessage_Internalname = "WWPSMSMESSAGE";
         edtWWPSMSSenderNumber_Internalname = "WWPSMSSENDERNUMBER";
         edtWWPSMSRecipientNumbers_Internalname = "WWPSMSRECIPIENTNUMBERS";
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS";
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED";
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED";
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED";
         edtWWPSMSDetail_Internalname = "WWPSMSDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
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
         Form.Caption = "WWP_SMS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPSMSDetail_Enabled = 1;
         edtWWPSMSProcessed_Jsonclick = "";
         edtWWPSMSProcessed_Enabled = 1;
         edtWWPSMSScheduled_Jsonclick = "";
         edtWWPSMSScheduled_Enabled = 1;
         edtWWPSMSCreated_Jsonclick = "";
         edtWWPSMSCreated_Enabled = 1;
         cmbWWPSMSStatus_Jsonclick = "";
         cmbWWPSMSStatus.Enabled = 1;
         edtWWPSMSRecipientNumbers_Enabled = 1;
         edtWWPSMSSenderNumber_Enabled = 1;
         edtWWPSMSMessage_Enabled = 1;
         edtWWPSMSId_Jsonclick = "";
         edtWWPSMSId_Enabled = 1;
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
         cmbWWPSMSStatus.Name = "WWPSMSSTATUS";
         cmbWWPSMSStatus.WebTags = "";
         cmbWWPSMSStatus.addItem("1", "Pending", 0);
         cmbWWPSMSStatus.addItem("2", "Sent", 0);
         cmbWWPSMSStatus.addItem("3", "Error", 0);
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            if ( (0==A29WWPSMSStatus) )
            {
               A29WWPSMSStatus = 1;
               AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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

      public void Valid_Wwpsmsid( )
      {
         A29WWPSMSStatus = (short)(NumberUtil.Val( cmbWWPSMSStatus.CurrentValue, "."));
         cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A29WWPSMSStatus = (short)(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A29WWPSMSStatus), 4, 0))), "."));
            cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A29WWPSMSStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A29WWPSMSStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A32WWPSMSMessage", A32WWPSMSMessage);
         AssignAttri("", false, "A33WWPSMSSenderNumber", A33WWPSMSSenderNumber);
         AssignAttri("", false, "A34WWPSMSRecipientNumbers", A34WWPSMSRecipientNumbers);
         AssignAttri("", false, "A29WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29WWPSMSStatus), 4, 0, ".", "")));
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A29WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A35WWPSMSCreated", context.localUtil.TToC( A35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A36WWPSMSScheduled", context.localUtil.TToC( A36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A30WWPSMSProcessed", context.localUtil.TToC( A30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A31WWPSMSDetail", A31WWPSMSDetail);
         AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z15WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15WWPSMSId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z32WWPSMSMessage", Z32WWPSMSMessage);
         GxWebStd.gx_hidden_field( context, "Z33WWPSMSSenderNumber", Z33WWPSMSSenderNumber);
         GxWebStd.gx_hidden_field( context, "Z34WWPSMSRecipientNumbers", Z34WWPSMSRecipientNumbers);
         GxWebStd.gx_hidden_field( context, "Z29WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29WWPSMSStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z35WWPSMSCreated", context.localUtil.TToC( Z35WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z36WWPSMSScheduled", context.localUtil.TToC( Z36WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z30WWPSMSProcessed", context.localUtil.TToC( Z30WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z31WWPSMSDetail", Z31WWPSMSDetail);
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37WWPNotificationCreated", context.localUtil.TToC( Z37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n16WWPNotificationId = false;
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A37WWPNotificationCreated = T000413_A37WWPNotificationCreated[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
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
         setEventMetadata("VALID_WWPSMSID","{handler:'Valid_Wwpsmsid',iparms:[{av:'A15WWPSMSId',fld:'WWPSMSID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'cmbWWPSMSStatus'},{av:'A29WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'},{av:'A35WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A36WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPSMSID",",oparms:[{av:'A32WWPSMSMessage',fld:'WWPSMSMESSAGE',pic:''},{av:'A33WWPSMSSenderNumber',fld:'WWPSMSSENDERNUMBER',pic:''},{av:'A34WWPSMSRecipientNumbers',fld:'WWPSMSRECIPIENTNUMBERS',pic:''},{av:'cmbWWPSMSStatus'},{av:'A29WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'},{av:'A35WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A36WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A30WWPSMSProcessed',fld:'WWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A31WWPSMSDetail',fld:'WWPSMSDETAIL',pic:''},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z15WWPSMSId'},{av:'Z32WWPSMSMessage'},{av:'Z33WWPSMSSenderNumber'},{av:'Z34WWPSMSRecipientNumbers'},{av:'Z29WWPSMSStatus'},{av:'Z35WWPSMSCreated'},{av:'Z36WWPSMSScheduled'},{av:'Z30WWPSMSProcessed'},{av:'Z31WWPSMSDetail'},{av:'Z16WWPNotificationId'},{av:'Z37WWPNotificationCreated'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPSMSSTATUS","{handler:'Valid_Wwpsmsstatus',iparms:[]");
         setEventMetadata("VALID_WWPSMSSTATUS",",oparms:[]}");
         setEventMetadata("VALID_WWPSMSCREATED","{handler:'Valid_Wwpsmscreated',iparms:[]");
         setEventMetadata("VALID_WWPSMSCREATED",",oparms:[]}");
         setEventMetadata("VALID_WWPSMSSCHEDULED","{handler:'Valid_Wwpsmsscheduled',iparms:[]");
         setEventMetadata("VALID_WWPSMSSCHEDULED",",oparms:[]}");
         setEventMetadata("VALID_WWPSMSPROCESSED","{handler:'Valid_Wwpsmsprocessed',iparms:[]");
         setEventMetadata("VALID_WWPSMSPROCESSED",",oparms:[]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]}");
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
         Z35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
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
         A32WWPSMSMessage = "";
         A33WWPSMSSenderNumber = "";
         A34WWPSMSRecipientNumbers = "";
         A35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A31WWPSMSDetail = "";
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
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
         Z32WWPSMSMessage = "";
         Z33WWPSMSSenderNumber = "";
         Z34WWPSMSRecipientNumbers = "";
         Z31WWPSMSDetail = "";
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T00045_A15WWPSMSId = new long[1] ;
         T00045_A32WWPSMSMessage = new string[] {""} ;
         T00045_A33WWPSMSSenderNumber = new string[] {""} ;
         T00045_A34WWPSMSRecipientNumbers = new string[] {""} ;
         T00045_A29WWPSMSStatus = new short[1] ;
         T00045_A35WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00045_A36WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00045_A30WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00045_n30WWPSMSProcessed = new bool[] {false} ;
         T00045_A31WWPSMSDetail = new string[] {""} ;
         T00045_n31WWPSMSDetail = new bool[] {false} ;
         T00045_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00045_A16WWPNotificationId = new long[1] ;
         T00045_n16WWPNotificationId = new bool[] {false} ;
         T00044_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00046_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00047_A15WWPSMSId = new long[1] ;
         T00043_A15WWPSMSId = new long[1] ;
         T00043_A32WWPSMSMessage = new string[] {""} ;
         T00043_A33WWPSMSSenderNumber = new string[] {""} ;
         T00043_A34WWPSMSRecipientNumbers = new string[] {""} ;
         T00043_A29WWPSMSStatus = new short[1] ;
         T00043_A35WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00043_A36WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00043_A30WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00043_n30WWPSMSProcessed = new bool[] {false} ;
         T00043_A31WWPSMSDetail = new string[] {""} ;
         T00043_n31WWPSMSDetail = new bool[] {false} ;
         T00043_A16WWPNotificationId = new long[1] ;
         T00043_n16WWPNotificationId = new bool[] {false} ;
         sMode4 = "";
         T00048_A15WWPSMSId = new long[1] ;
         T00049_A15WWPSMSId = new long[1] ;
         T00042_A15WWPSMSId = new long[1] ;
         T00042_A32WWPSMSMessage = new string[] {""} ;
         T00042_A33WWPSMSSenderNumber = new string[] {""} ;
         T00042_A34WWPSMSRecipientNumbers = new string[] {""} ;
         T00042_A29WWPSMSStatus = new short[1] ;
         T00042_A35WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00042_A36WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00042_A30WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00042_n30WWPSMSProcessed = new bool[] {false} ;
         T00042_A31WWPSMSDetail = new string[] {""} ;
         T00042_n31WWPSMSDetail = new bool[] {false} ;
         T00042_A16WWPNotificationId = new long[1] ;
         T00042_n16WWPNotificationId = new bool[] {false} ;
         T000410_A15WWPSMSId = new long[1] ;
         T000413_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000414_A15WWPSMSId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ32WWPSMSMessage = "";
         ZZ33WWPSMSSenderNumber = "";
         ZZ34WWPSMSRecipientNumbers = "";
         ZZ35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         ZZ36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         ZZ31WWPSMSDetail = "";
         ZZ37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__default(),
            new Object[][] {
                new Object[] {
               T00042_A15WWPSMSId, T00042_A32WWPSMSMessage, T00042_A33WWPSMSSenderNumber, T00042_A34WWPSMSRecipientNumbers, T00042_A29WWPSMSStatus, T00042_A35WWPSMSCreated, T00042_A36WWPSMSScheduled, T00042_A30WWPSMSProcessed, T00042_n30WWPSMSProcessed, T00042_A31WWPSMSDetail,
               T00042_n31WWPSMSDetail, T00042_A16WWPNotificationId, T00042_n16WWPNotificationId
               }
               , new Object[] {
               T00043_A15WWPSMSId, T00043_A32WWPSMSMessage, T00043_A33WWPSMSSenderNumber, T00043_A34WWPSMSRecipientNumbers, T00043_A29WWPSMSStatus, T00043_A35WWPSMSCreated, T00043_A36WWPSMSScheduled, T00043_A30WWPSMSProcessed, T00043_n30WWPSMSProcessed, T00043_A31WWPSMSDetail,
               T00043_n31WWPSMSDetail, T00043_A16WWPNotificationId, T00043_n16WWPNotificationId
               }
               , new Object[] {
               T00044_A37WWPNotificationCreated
               }
               , new Object[] {
               T00045_A15WWPSMSId, T00045_A32WWPSMSMessage, T00045_A33WWPSMSSenderNumber, T00045_A34WWPSMSRecipientNumbers, T00045_A29WWPSMSStatus, T00045_A35WWPSMSCreated, T00045_A36WWPSMSScheduled, T00045_A30WWPSMSProcessed, T00045_n30WWPSMSProcessed, T00045_A31WWPSMSDetail,
               T00045_n31WWPSMSDetail, T00045_A37WWPNotificationCreated, T00045_A16WWPNotificationId, T00045_n16WWPNotificationId
               }
               , new Object[] {
               T00046_A37WWPNotificationCreated
               }
               , new Object[] {
               T00047_A15WWPSMSId
               }
               , new Object[] {
               T00048_A15WWPSMSId
               }
               , new Object[] {
               T00049_A15WWPSMSId
               }
               , new Object[] {
               T000410_A15WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000413_A37WWPNotificationCreated
               }
               , new Object[] {
               T000414_A15WWPSMSId
               }
            }
         );
         Z36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z29WWPSMSStatus = 1;
         A29WWPSMSStatus = 1;
         i29WWPSMSStatus = 1;
      }

      private short Z29WWPSMSStatus ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A29WWPSMSStatus ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private short gxajaxcallmode ;
      private short i29WWPSMSStatus ;
      private short ZZ29WWPSMSStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSMSId_Enabled ;
      private int edtWWPSMSMessage_Enabled ;
      private int edtWWPSMSSenderNumber_Enabled ;
      private int edtWWPSMSRecipientNumbers_Enabled ;
      private int edtWWPSMSCreated_Enabled ;
      private int edtWWPSMSScheduled_Enabled ;
      private int edtWWPSMSProcessed_Enabled ;
      private int edtWWPSMSDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z15WWPSMSId ;
      private long Z16WWPNotificationId ;
      private long A16WWPNotificationId ;
      private long A15WWPSMSId ;
      private long ZZ15WWPSMSId ;
      private long ZZ16WWPNotificationId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSMSId_Internalname ;
      private string cmbWWPSMSStatus_Internalname ;
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
      private string edtWWPSMSId_Jsonclick ;
      private string edtWWPSMSMessage_Internalname ;
      private string edtWWPSMSSenderNumber_Internalname ;
      private string edtWWPSMSRecipientNumbers_Internalname ;
      private string cmbWWPSMSStatus_Jsonclick ;
      private string edtWWPSMSCreated_Internalname ;
      private string edtWWPSMSCreated_Jsonclick ;
      private string edtWWPSMSScheduled_Internalname ;
      private string edtWWPSMSScheduled_Jsonclick ;
      private string edtWWPSMSProcessed_Internalname ;
      private string edtWWPSMSProcessed_Jsonclick ;
      private string edtWWPSMSDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
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
      private string sMode4 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z35WWPSMSCreated ;
      private DateTime Z36WWPSMSScheduled ;
      private DateTime Z30WWPSMSProcessed ;
      private DateTime A35WWPSMSCreated ;
      private DateTime A36WWPSMSScheduled ;
      private DateTime A30WWPSMSProcessed ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime i35WWPSMSCreated ;
      private DateTime i36WWPSMSScheduled ;
      private DateTime ZZ35WWPSMSCreated ;
      private DateTime ZZ36WWPSMSScheduled ;
      private DateTime ZZ30WWPSMSProcessed ;
      private DateTime ZZ37WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n16WWPNotificationId ;
      private bool wbErr ;
      private bool n30WWPSMSProcessed ;
      private bool n31WWPSMSDetail ;
      private string A32WWPSMSMessage ;
      private string A33WWPSMSSenderNumber ;
      private string A34WWPSMSRecipientNumbers ;
      private string A31WWPSMSDetail ;
      private string Z32WWPSMSMessage ;
      private string Z33WWPSMSSenderNumber ;
      private string Z34WWPSMSRecipientNumbers ;
      private string Z31WWPSMSDetail ;
      private string ZZ32WWPSMSMessage ;
      private string ZZ33WWPSMSSenderNumber ;
      private string ZZ34WWPSMSRecipientNumbers ;
      private string ZZ31WWPSMSDetail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPSMSStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T00045_A15WWPSMSId ;
      private string[] T00045_A32WWPSMSMessage ;
      private string[] T00045_A33WWPSMSSenderNumber ;
      private string[] T00045_A34WWPSMSRecipientNumbers ;
      private short[] T00045_A29WWPSMSStatus ;
      private DateTime[] T00045_A35WWPSMSCreated ;
      private DateTime[] T00045_A36WWPSMSScheduled ;
      private DateTime[] T00045_A30WWPSMSProcessed ;
      private bool[] T00045_n30WWPSMSProcessed ;
      private string[] T00045_A31WWPSMSDetail ;
      private bool[] T00045_n31WWPSMSDetail ;
      private DateTime[] T00045_A37WWPNotificationCreated ;
      private long[] T00045_A16WWPNotificationId ;
      private bool[] T00045_n16WWPNotificationId ;
      private DateTime[] T00044_A37WWPNotificationCreated ;
      private DateTime[] T00046_A37WWPNotificationCreated ;
      private long[] T00047_A15WWPSMSId ;
      private long[] T00043_A15WWPSMSId ;
      private string[] T00043_A32WWPSMSMessage ;
      private string[] T00043_A33WWPSMSSenderNumber ;
      private string[] T00043_A34WWPSMSRecipientNumbers ;
      private short[] T00043_A29WWPSMSStatus ;
      private DateTime[] T00043_A35WWPSMSCreated ;
      private DateTime[] T00043_A36WWPSMSScheduled ;
      private DateTime[] T00043_A30WWPSMSProcessed ;
      private bool[] T00043_n30WWPSMSProcessed ;
      private string[] T00043_A31WWPSMSDetail ;
      private bool[] T00043_n31WWPSMSDetail ;
      private long[] T00043_A16WWPNotificationId ;
      private bool[] T00043_n16WWPNotificationId ;
      private long[] T00048_A15WWPSMSId ;
      private long[] T00049_A15WWPSMSId ;
      private long[] T00042_A15WWPSMSId ;
      private string[] T00042_A32WWPSMSMessage ;
      private string[] T00042_A33WWPSMSSenderNumber ;
      private string[] T00042_A34WWPSMSRecipientNumbers ;
      private short[] T00042_A29WWPSMSStatus ;
      private DateTime[] T00042_A35WWPSMSCreated ;
      private DateTime[] T00042_A36WWPSMSScheduled ;
      private DateTime[] T00042_A30WWPSMSProcessed ;
      private bool[] T00042_n30WWPSMSProcessed ;
      private string[] T00042_A31WWPSMSDetail ;
      private bool[] T00042_n31WWPSMSDetail ;
      private long[] T00042_A16WWPNotificationId ;
      private bool[] T00042_n16WWPNotificationId ;
      private long[] T000410_A15WWPSMSId ;
      private DateTime[] T000413_A37WWPNotificationCreated ;
      private long[] T000414_A15WWPSMSId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_sms__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00045;
        prmT00045 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00044;
        prmT00044 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00046;
        prmT00046 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00047;
        prmT00047 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00043;
        prmT00043 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00048;
        prmT00048 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00049;
        prmT00049 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00042;
        prmT00042 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000410;
        prmT000410 = new Object[] {
        new Object[] {"@WWPSMSMessage",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSSenderNumber",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSRecipientNumbers",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPSMSCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000411;
        prmT000411 = new Object[] {
        new Object[] {"@WWPSMSMessage",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSSenderNumber",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSRecipientNumbers",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPSMSCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000412;
        prmT000412 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000414;
        prmT000414 = new Object[] {
        };
        Object[] prmT000413;
        prmT000413 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("T00042", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WITH (UPDLOCK) WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00043", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00044", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00045", "SELECT TM1.[WWPSMSId], TM1.[WWPSMSMessage], TM1.[WWPSMSSenderNumber], TM1.[WWPSMSRecipientNumbers], TM1.[WWPSMSStatus], TM1.[WWPSMSCreated], TM1.[WWPSMSScheduled], TM1.[WWPSMSProcessed], TM1.[WWPSMSDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_SMS] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPSMSId] = @WWPSMSId ORDER BY TM1.[WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00046", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00047", "SELECT [WWPSMSId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00048", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE ( [WWPSMSId] > @WWPSMSId) ORDER BY [WWPSMSId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00049", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE ( [WWPSMSId] < @WWPSMSId) ORDER BY [WWPSMSId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000410", "INSERT INTO [WWP_SMS]([WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId]) VALUES(@WWPSMSMessage, @WWPSMSSenderNumber, @WWPSMSRecipientNumbers, @WWPSMSStatus, @WWPSMSCreated, @WWPSMSScheduled, @WWPSMSProcessed, @WWPSMSDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000410)
           ,new CursorDef("T000411", "UPDATE [WWP_SMS] SET [WWPSMSMessage]=@WWPSMSMessage, [WWPSMSSenderNumber]=@WWPSMSSenderNumber, [WWPSMSRecipientNumbers]=@WWPSMSRecipientNumbers, [WWPSMSStatus]=@WWPSMSStatus, [WWPSMSCreated]=@WWPSMSCreated, [WWPSMSScheduled]=@WWPSMSScheduled, [WWPSMSProcessed]=@WWPSMSProcessed, [WWPSMSDetail]=@WWPSMSDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmT000411)
           ,new CursorDef("T000412", "DELETE FROM [WWP_SMS]  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmT000412)
           ,new CursorDef("T000413", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000414", "SELECT [WWPSMSId] FROM [WWP_SMS] ORDER BY [WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getGXDateTime(6, true);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.wasNull(9);
              table[11][0] = rslt.getLong(10);
              table[12][0] = rslt.wasNull(10);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getGXDateTime(6, true);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.wasNull(9);
              table[11][0] = rslt.getLong(10);
              table[12][0] = rslt.wasNull(10);
              return;
           case 2 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getGXDateTime(6, true);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.wasNull(9);
              table[11][0] = rslt.getGXDateTime(10, true);
              table[12][0] = rslt.getLong(11);
              table[13][0] = rslt.wasNull(11);
              return;
           case 4 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 7 :
              table[0][0] = rslt.getLong(1);
              return;
           case 8 :
              table[0][0] = rslt.getLong(1);
              return;
           case 11 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 12 :
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 5 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameterDatetime(5, (DateTime)parms[4], true);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(7, (DateTime)parms[7], true);
              }
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 8 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(8, (string)parms[9]);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 9 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(9, (long)parms[11]);
              }
              return;
           case 9 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameterDatetime(5, (DateTime)parms[4], true);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(7, (DateTime)parms[7], true);
              }
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 8 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(8, (string)parms[9]);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 9 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(9, (long)parms[11]);
              }
              stmt.SetParameter(10, (long)parms[12]);
              return;
           case 10 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 11 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
     }
  }

}

}
