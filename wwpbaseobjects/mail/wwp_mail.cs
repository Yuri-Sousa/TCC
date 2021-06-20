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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwwp_mail_attachments") == 0 )
         {
            nRC_GXsfl_104 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_104"), "."));
            nGXsfl_104_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_104_idx"), "."));
            sGXsfl_104_idx = GetPar( "sGXsfl_104_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridwwp_mail_attachments_newrow( ) ;
            return  ;
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
            Form.Meta.addItem("description", "Mail", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_mail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_mail( IGxContext context )
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
         cmbWWPMailStatus = new GXCombobox();
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
            return "wwpmail_Execute" ;
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
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A72WWPMailStatus = (short)(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A72WWPMailStatus), 4, 0))), "."));
            AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A72WWPMailStatus), 4, 0));
            AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Mail", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20WWPMailId), 10, 0, ",", "")), ((edtWWPMailId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A20WWPMailId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A20WWPMailId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSubject_Internalname, "Subject", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailSubject_Internalname, A61WWPMailSubject, StringUtil.RTrim( context.localUtil.Format( A61WWPMailSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailBody_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBody_Internalname, "Body", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBody_Internalname, A55WWPMailBody, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 1, 1, edtWWPMailBody_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailTo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTo_Internalname, "To", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTo_Internalname, A62WWPMailTo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, 1, edtWWPMailTo_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCC_Internalname, "CC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailCC_Internalname, A74WWPMailCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", 0, 1, edtWWPMailCC_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailBCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBCC_Internalname, "BCC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBCC_Internalname, A75WWPMailBCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", 0, 1, edtWWPMailBCC_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailSenderAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderAddress_Internalname, "Sender Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderAddress_Internalname, A63WWPMailSenderAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtWWPMailSenderAddress_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailSenderName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderName_Internalname, "Sender Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderName_Internalname, A64WWPMailSenderName, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtWWPMailSenderName_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbWWPMailStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPMailStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPMailStatus, cmbWWPMailStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A72WWPMailStatus), 4, 0)), 1, cmbWWPMailStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPMailStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A72WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", (string)(cmbWWPMailStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCreated_Internalname, "Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailCreated_Internalname, context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A81WWPMailCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailScheduled_Internalname, "Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailScheduled_Internalname, context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A82WWPMailScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailProcessed_Internalname, "Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailProcessed_Internalname, context.localUtil.TToC( A77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A77WWPMailProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailDetail_Internalname, "Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailDetail_Internalname, A78WWPMailDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", 0, 1, edtWWPMailDetail_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ",", "")), ((edtWWPNotificationId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A37WWPNotificationCreated, "99/99/9999 99:99:99.999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleattachments_Internalname, "Attachments", "", "", lblTitleattachments_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridwwp_mail_attachments( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridwwp_mail_attachments( )
      {
         /*  Grid Control  */
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("GridName", "Gridwwp_mail_attachments");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Header", subGridwwp_mail_attachments_Header);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Class", "Grid");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Backcolorstyle), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("CmpContext", "");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("InMasterPage", "false");
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", A21WWPMailAttachmentName);
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", A76WWPMailAttachmentFile);
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectedindex), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowselection), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectioncolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowhovering), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Hoveringcolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowcollapsing), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Collapsed), 1, 0, ".", "")));
         nGXsfl_104_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount11 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_11 = 1;
               ScanStart0A11( ) ;
               while ( RcdFound11 != 0 )
               {
                  init_level_properties11( ) ;
                  getByPrimaryKey0A11( ) ;
                  AddRow0A11( ) ;
                  ScanNext0A11( ) ;
               }
               ScanEnd0A11( ) ;
               nBlankRcdCount11 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0A11( ) ;
            standaloneModal0A11( ) ;
            sMode11 = Gx_mode;
            while ( nGXsfl_104_idx < nRC_GXsfl_104 )
            {
               bGXsfl_104_Refreshing = true;
               ReadRow0A11( ) ;
               edtWWPMailAttachmentName_Enabled = (int)(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_104_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtWWPMailAttachmentFile_Enabled = (int)(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_104_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               if ( ( nRcdExists_11 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0A11( ) ;
               }
               SendRow0A11( ) ;
               bGXsfl_104_Refreshing = false;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount11 = 5;
            nRcdExists_11 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0A11( ) ;
               while ( RcdFound11 != 0 )
               {
                  sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_10411( ) ;
                  init_level_properties11( ) ;
                  standaloneNotModal0A11( ) ;
                  getByPrimaryKey0A11( ) ;
                  standaloneModal0A11( ) ;
                  AddRow0A11( ) ;
                  ScanNext0A11( ) ;
               }
               ScanEnd0A11( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode11 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx+1), 4, 0), 4, "0");
         SubsflControlProps_10411( ) ;
         InitAll0A11( ) ;
         init_level_properties11( ) ;
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
         nBlankRcdCount11 = (short)(nBlankRcdUsr11+nBlankRcdCount11);
         fRowAdded = 0;
         while ( nBlankRcdCount11 > 0 )
         {
            standaloneNotModal0A11( ) ;
            standaloneModal0A11( ) ;
            AddRow0A11( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtWWPMailAttachmentName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount11 = (short)(nBlankRcdCount11-1);
         }
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridwwp_mail_attachmentsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwp_mail_attachments", Gridwwp_mail_attachmentsContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData", Gridwwp_mail_attachmentsContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData"+"V", Gridwwp_mail_attachmentsContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridwwp_mail_attachmentsContainerData"+"V"+"\" value='"+Gridwwp_mail_attachmentsContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z20WWPMailId = (long)(context.localUtil.CToN( cgiGet( "Z20WWPMailId"), ",", "."));
            Z61WWPMailSubject = cgiGet( "Z61WWPMailSubject");
            Z72WWPMailStatus = (short)(context.localUtil.CToN( cgiGet( "Z72WWPMailStatus"), ",", "."));
            Z81WWPMailCreated = context.localUtil.CToT( cgiGet( "Z81WWPMailCreated"), 0);
            Z82WWPMailScheduled = context.localUtil.CToT( cgiGet( "Z82WWPMailScheduled"), 0);
            Z77WWPMailProcessed = context.localUtil.CToT( cgiGet( "Z77WWPMailProcessed"), 0);
            n77WWPMailProcessed = ((DateTime.MinValue==A77WWPMailProcessed) ? true : false);
            Z16WWPNotificationId = (long)(context.localUtil.CToN( cgiGet( "Z16WWPNotificationId"), ",", "."));
            n16WWPNotificationId = ((0==A16WWPNotificationId) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_104 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_104"), ",", "."));
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPMAILID");
               AnyError = 1;
               GX_FocusControl = edtWWPMailId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A20WWPMailId = 0;
               AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
            }
            else
            {
               A20WWPMailId = (long)(context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ",", "."));
               AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
            }
            A61WWPMailSubject = cgiGet( edtWWPMailSubject_Internalname);
            AssignAttri("", false, "A61WWPMailSubject", A61WWPMailSubject);
            A55WWPMailBody = cgiGet( edtWWPMailBody_Internalname);
            AssignAttri("", false, "A55WWPMailBody", A55WWPMailBody);
            A62WWPMailTo = cgiGet( edtWWPMailTo_Internalname);
            n62WWPMailTo = false;
            AssignAttri("", false, "A62WWPMailTo", A62WWPMailTo);
            n62WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A62WWPMailTo)) ? true : false);
            A74WWPMailCC = cgiGet( edtWWPMailCC_Internalname);
            n74WWPMailCC = false;
            AssignAttri("", false, "A74WWPMailCC", A74WWPMailCC);
            n74WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A74WWPMailCC)) ? true : false);
            A75WWPMailBCC = cgiGet( edtWWPMailBCC_Internalname);
            n75WWPMailBCC = false;
            AssignAttri("", false, "A75WWPMailBCC", A75WWPMailBCC);
            n75WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A75WWPMailBCC)) ? true : false);
            A63WWPMailSenderAddress = cgiGet( edtWWPMailSenderAddress_Internalname);
            AssignAttri("", false, "A63WWPMailSenderAddress", A63WWPMailSenderAddress);
            A64WWPMailSenderName = cgiGet( edtWWPMailSenderName_Internalname);
            AssignAttri("", false, "A64WWPMailSenderName", A64WWPMailSenderName);
            cmbWWPMailStatus.Name = cmbWWPMailStatus_Internalname;
            cmbWWPMailStatus.CurrentValue = cgiGet( cmbWWPMailStatus_Internalname);
            A72WWPMailStatus = (short)(NumberUtil.Val( cgiGet( cmbWWPMailStatus_Internalname), "."));
            AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Created"}), 1, "WWPMAILCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A81WWPMailCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A81WWPMailCreated = context.localUtil.CToT( cgiGet( edtWWPMailCreated_Internalname));
               AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailScheduled_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Scheduled"}), 1, "WWPMAILSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A82WWPMailScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A82WWPMailScheduled = context.localUtil.CToT( cgiGet( edtWWPMailScheduled_Internalname));
               AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailProcessed_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Processed"}), 1, "WWPMAILPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A77WWPMailProcessed = (DateTime)(DateTime.MinValue);
               n77WWPMailProcessed = false;
               AssignAttri("", false, "A77WWPMailProcessed", context.localUtil.TToC( A77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A77WWPMailProcessed = context.localUtil.CToT( cgiGet( edtWWPMailProcessed_Internalname));
               n77WWPMailProcessed = false;
               AssignAttri("", false, "A77WWPMailProcessed", context.localUtil.TToC( A77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            n77WWPMailProcessed = ((DateTime.MinValue==A77WWPMailProcessed) ? true : false);
            A78WWPMailDetail = cgiGet( edtWWPMailDetail_Internalname);
            n78WWPMailDetail = false;
            AssignAttri("", false, "A78WWPMailDetail", A78WWPMailDetail);
            n78WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A78WWPMailDetail)) ? true : false);
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
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A20WWPMailId = (long)(NumberUtil.Val( GetPar( "WWPMailId"), "."));
               AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll0A10( ) ;
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
         DisableAttributes0A10( ) ;
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

      protected void CONFIRM_0A11( )
      {
         nGXsfl_104_idx = 0;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            ReadRow0A11( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               GetKey0A11( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0A11( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0A11( ) ;
                        CloseExtendedTableCursors0A11( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_104_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( nRcdDeleted_11 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0A11( ) ;
                        Load0A11( ) ;
                        BeforeValidate0A11( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0A11( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0A11( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0A11( ) ;
                              CloseExtendedTableCursors0A11( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_104_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A21WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A76WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z21WWPMailAttachmentName_"+sGXsfl_104_idx, Z21WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z61WWPMailSubject = T000A5_A61WWPMailSubject[0];
               Z72WWPMailStatus = T000A5_A72WWPMailStatus[0];
               Z81WWPMailCreated = T000A5_A81WWPMailCreated[0];
               Z82WWPMailScheduled = T000A5_A82WWPMailScheduled[0];
               Z77WWPMailProcessed = T000A5_A77WWPMailProcessed[0];
               Z16WWPNotificationId = T000A5_A16WWPNotificationId[0];
            }
            else
            {
               Z61WWPMailSubject = A61WWPMailSubject;
               Z72WWPMailStatus = A72WWPMailStatus;
               Z81WWPMailCreated = A81WWPMailCreated;
               Z82WWPMailScheduled = A82WWPMailScheduled;
               Z77WWPMailProcessed = A77WWPMailProcessed;
               Z16WWPNotificationId = A16WWPNotificationId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z20WWPMailId = A20WWPMailId;
            Z61WWPMailSubject = A61WWPMailSubject;
            Z55WWPMailBody = A55WWPMailBody;
            Z62WWPMailTo = A62WWPMailTo;
            Z74WWPMailCC = A74WWPMailCC;
            Z75WWPMailBCC = A75WWPMailBCC;
            Z63WWPMailSenderAddress = A63WWPMailSenderAddress;
            Z64WWPMailSenderName = A64WWPMailSenderName;
            Z72WWPMailStatus = A72WWPMailStatus;
            Z81WWPMailCreated = A81WWPMailCreated;
            Z82WWPMailScheduled = A82WWPMailScheduled;
            Z77WWPMailProcessed = A77WWPMailProcessed;
            Z78WWPMailDetail = A78WWPMailDetail;
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
         if ( IsIns( )  && (0==A72WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A72WWPMailStatus = 1;
            AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A81WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A82WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
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

      protected void Load0A10( )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound10 = 1;
            A61WWPMailSubject = T000A7_A61WWPMailSubject[0];
            AssignAttri("", false, "A61WWPMailSubject", A61WWPMailSubject);
            A55WWPMailBody = T000A7_A55WWPMailBody[0];
            AssignAttri("", false, "A55WWPMailBody", A55WWPMailBody);
            A62WWPMailTo = T000A7_A62WWPMailTo[0];
            n62WWPMailTo = T000A7_n62WWPMailTo[0];
            AssignAttri("", false, "A62WWPMailTo", A62WWPMailTo);
            A74WWPMailCC = T000A7_A74WWPMailCC[0];
            n74WWPMailCC = T000A7_n74WWPMailCC[0];
            AssignAttri("", false, "A74WWPMailCC", A74WWPMailCC);
            A75WWPMailBCC = T000A7_A75WWPMailBCC[0];
            n75WWPMailBCC = T000A7_n75WWPMailBCC[0];
            AssignAttri("", false, "A75WWPMailBCC", A75WWPMailBCC);
            A63WWPMailSenderAddress = T000A7_A63WWPMailSenderAddress[0];
            AssignAttri("", false, "A63WWPMailSenderAddress", A63WWPMailSenderAddress);
            A64WWPMailSenderName = T000A7_A64WWPMailSenderName[0];
            AssignAttri("", false, "A64WWPMailSenderName", A64WWPMailSenderName);
            A72WWPMailStatus = T000A7_A72WWPMailStatus[0];
            AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
            A81WWPMailCreated = T000A7_A81WWPMailCreated[0];
            AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            A82WWPMailScheduled = T000A7_A82WWPMailScheduled[0];
            AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            A77WWPMailProcessed = T000A7_A77WWPMailProcessed[0];
            n77WWPMailProcessed = T000A7_n77WWPMailProcessed[0];
            AssignAttri("", false, "A77WWPMailProcessed", context.localUtil.TToC( A77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            A78WWPMailDetail = T000A7_A78WWPMailDetail[0];
            n78WWPMailDetail = T000A7_n78WWPMailDetail[0];
            AssignAttri("", false, "A78WWPMailDetail", A78WWPMailDetail);
            A37WWPNotificationCreated = T000A7_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A16WWPNotificationId = T000A7_A16WWPNotificationId[0];
            n16WWPNotificationId = T000A7_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            ZM0A10( -8) ;
         }
         pr_default.close(5);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A72WWPMailStatus == 1 ) || ( A72WWPMailStatus == 2 ) || ( A72WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Mail Status fora do intervalo", "OutOfRange", 1, "WWPMAILSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPMailStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A81WWPMailCreated) || ( A81WWPMailCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Mail Created fora do intervalo", "OutOfRange", 1, "WWPMAILCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPMailCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A82WWPMailScheduled) || ( A82WWPMailScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Mail Scheduled fora do intervalo", "OutOfRange", 1, "WWPMAILSCHEDULED");
            AnyError = 1;
            GX_FocusControl = edtWWPMailScheduled_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A77WWPMailProcessed) || ( A77WWPMailProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Mail Processed fora do intervalo", "OutOfRange", 1, "WWPMAILPROCESSED");
            AnyError = 1;
            GX_FocusControl = edtWWPMailProcessed_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A6 */
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
         A37WWPNotificationCreated = T000A6_A37WWPNotificationCreated[0];
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0A10( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A16WWPNotificationId )
      {
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A37WWPNotificationCreated = T000A8_A37WWPNotificationCreated[0];
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0A10( )
      {
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0A10( 8) ;
            RcdFound10 = 1;
            A20WWPMailId = T000A5_A20WWPMailId[0];
            AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
            A61WWPMailSubject = T000A5_A61WWPMailSubject[0];
            AssignAttri("", false, "A61WWPMailSubject", A61WWPMailSubject);
            A55WWPMailBody = T000A5_A55WWPMailBody[0];
            AssignAttri("", false, "A55WWPMailBody", A55WWPMailBody);
            A62WWPMailTo = T000A5_A62WWPMailTo[0];
            n62WWPMailTo = T000A5_n62WWPMailTo[0];
            AssignAttri("", false, "A62WWPMailTo", A62WWPMailTo);
            A74WWPMailCC = T000A5_A74WWPMailCC[0];
            n74WWPMailCC = T000A5_n74WWPMailCC[0];
            AssignAttri("", false, "A74WWPMailCC", A74WWPMailCC);
            A75WWPMailBCC = T000A5_A75WWPMailBCC[0];
            n75WWPMailBCC = T000A5_n75WWPMailBCC[0];
            AssignAttri("", false, "A75WWPMailBCC", A75WWPMailBCC);
            A63WWPMailSenderAddress = T000A5_A63WWPMailSenderAddress[0];
            AssignAttri("", false, "A63WWPMailSenderAddress", A63WWPMailSenderAddress);
            A64WWPMailSenderName = T000A5_A64WWPMailSenderName[0];
            AssignAttri("", false, "A64WWPMailSenderName", A64WWPMailSenderName);
            A72WWPMailStatus = T000A5_A72WWPMailStatus[0];
            AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
            A81WWPMailCreated = T000A5_A81WWPMailCreated[0];
            AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            A82WWPMailScheduled = T000A5_A82WWPMailScheduled[0];
            AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            A77WWPMailProcessed = T000A5_A77WWPMailProcessed[0];
            n77WWPMailProcessed = T000A5_n77WWPMailProcessed[0];
            AssignAttri("", false, "A77WWPMailProcessed", context.localUtil.TToC( A77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            A78WWPMailDetail = T000A5_A78WWPMailDetail[0];
            n78WWPMailDetail = T000A5_n78WWPMailDetail[0];
            AssignAttri("", false, "A78WWPMailDetail", A78WWPMailDetail);
            A16WWPNotificationId = T000A5_A16WWPNotificationId[0];
            n16WWPNotificationId = T000A5_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            Z20WWPMailId = A20WWPMailId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
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
         RcdFound10 = 0;
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000A10_A20WWPMailId[0] < A20WWPMailId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000A10_A20WWPMailId[0] > A20WWPMailId ) ) )
            {
               A20WWPMailId = T000A10_A20WWPMailId[0];
               AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000A11 */
         pr_default.execute(9, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000A11_A20WWPMailId[0] > A20WWPMailId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000A11_A20WWPMailId[0] < A20WWPMailId ) ) )
            {
               A20WWPMailId = T000A11_A20WWPMailId[0];
               AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A10( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A20WWPMailId != Z20WWPMailId )
               {
                  A20WWPMailId = Z20WWPMailId;
                  AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPMAILID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A10( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A20WWPMailId != Z20WWPMailId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A10( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPMAILID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A10( ) ;
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
         if ( A20WWPMailId != Z20WWPMailId )
         {
            A20WWPMailId = Z20WWPMailId;
            AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPMailId_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A10( ) ;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         ScanStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound10 != 0 )
            {
               ScanNext0A10( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A10( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A4 */
            pr_default.execute(2, new Object[] {A20WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z61WWPMailSubject, T000A4_A61WWPMailSubject[0]) != 0 ) || ( Z72WWPMailStatus != T000A4_A72WWPMailStatus[0] ) || ( Z81WWPMailCreated != T000A4_A81WWPMailCreated[0] ) || ( Z82WWPMailScheduled != T000A4_A82WWPMailScheduled[0] ) || ( Z77WWPMailProcessed != T000A4_A77WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z16WWPNotificationId != T000A4_A16WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z61WWPMailSubject, T000A4_A61WWPMailSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailSubject");
                  GXUtil.WriteLogRaw("Old: ",Z61WWPMailSubject);
                  GXUtil.WriteLogRaw("Current: ",T000A4_A61WWPMailSubject[0]);
               }
               if ( Z72WWPMailStatus != T000A4_A72WWPMailStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailStatus");
                  GXUtil.WriteLogRaw("Old: ",Z72WWPMailStatus);
                  GXUtil.WriteLogRaw("Current: ",T000A4_A72WWPMailStatus[0]);
               }
               if ( Z81WWPMailCreated != T000A4_A81WWPMailCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailCreated");
                  GXUtil.WriteLogRaw("Old: ",Z81WWPMailCreated);
                  GXUtil.WriteLogRaw("Current: ",T000A4_A81WWPMailCreated[0]);
               }
               if ( Z82WWPMailScheduled != T000A4_A82WWPMailScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z82WWPMailScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000A4_A82WWPMailScheduled[0]);
               }
               if ( Z77WWPMailProcessed != T000A4_A77WWPMailProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z77WWPMailProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000A4_A77WWPMailProcessed[0]);
               }
               if ( Z16WWPNotificationId != T000A4_A16WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z16WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000A4_A16WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         if ( ! IsAuthorized("wwpmail_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A12 */
                     pr_default.execute(10, new Object[] {A61WWPMailSubject, A55WWPMailBody, n62WWPMailTo, A62WWPMailTo, n74WWPMailCC, A74WWPMailCC, n75WWPMailBCC, A75WWPMailBCC, A63WWPMailSenderAddress, A64WWPMailSenderName, A72WWPMailStatus, A81WWPMailCreated, A82WWPMailScheduled, n77WWPMailProcessed, A77WWPMailProcessed, n78WWPMailDetail, A78WWPMailDetail, n16WWPNotificationId, A16WWPNotificationId});
                     A20WWPMailId = T000A12_A20WWPMailId[0];
                     AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A10( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0A0( ) ;
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
            else
            {
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         if ( ! IsAuthorized("wwpmail_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A13 */
                     pr_default.execute(11, new Object[] {A61WWPMailSubject, A55WWPMailBody, n62WWPMailTo, A62WWPMailTo, n74WWPMailCC, A74WWPMailCC, n75WWPMailBCC, A75WWPMailBCC, A63WWPMailSenderAddress, A64WWPMailSenderName, A72WWPMailStatus, A81WWPMailCreated, A82WWPMailScheduled, n77WWPMailProcessed, A77WWPMailProcessed, n78WWPMailDetail, A78WWPMailDetail, n16WWPNotificationId, A16WWPNotificationId, A20WWPMailId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A10( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption0A0( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpmail_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0A11( ) ;
                  while ( RcdFound11 != 0 )
                  {
                     getByPrimaryKey0A11( ) ;
                     Delete0A11( ) ;
                     ScanNext0A11( ) ;
                  }
                  ScanEnd0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A14 */
                     pr_default.execute(12, new Object[] {A20WWPMailId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound10 == 0 )
                           {
                              InitAll0A10( ) ;
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
                           ResetCaption0A0( ) ;
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
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000A15 */
            pr_default.execute(13, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            A37WWPNotificationCreated = T000A15_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel0A11( )
      {
         nGXsfl_104_idx = 0;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            ReadRow0A11( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               standaloneNotModal0A11( ) ;
               GetKey0A11( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0A11( ) ;
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( ( nRcdDeleted_11 != 0 ) && ( nRcdExists_11 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0A11( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0A11( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_104_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A21WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A76WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z21WWPMailAttachmentName_"+sGXsfl_104_idx, Z21WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0A11( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
      }

      protected void ProcessLevel0A10( )
      {
         /* Save parent mode. */
         sMode10 = Gx_mode;
         ProcessNestedLevel0A11( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(13);
            context.CommitDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(13);
            context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A10( )
      {
         /* Using cursor T000A16 */
         pr_default.execute(14);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound10 = 1;
            A20WWPMailId = T000A16_A20WWPMailId[0];
            AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound10 = 1;
            A20WWPMailId = T000A16_A20WWPMailId[0];
            AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
         }
      }

      protected void ScanEnd0A10( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
         edtWWPMailId_Enabled = 0;
         AssignProp("", false, edtWWPMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailId_Enabled), 5, 0), true);
         edtWWPMailSubject_Enabled = 0;
         AssignProp("", false, edtWWPMailSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSubject_Enabled), 5, 0), true);
         edtWWPMailBody_Enabled = 0;
         AssignProp("", false, edtWWPMailBody_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBody_Enabled), 5, 0), true);
         edtWWPMailTo_Enabled = 0;
         AssignProp("", false, edtWWPMailTo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTo_Enabled), 5, 0), true);
         edtWWPMailCC_Enabled = 0;
         AssignProp("", false, edtWWPMailCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCC_Enabled), 5, 0), true);
         edtWWPMailBCC_Enabled = 0;
         AssignProp("", false, edtWWPMailBCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBCC_Enabled), 5, 0), true);
         edtWWPMailSenderAddress_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderAddress_Enabled), 5, 0), true);
         edtWWPMailSenderName_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderName_Enabled), 5, 0), true);
         cmbWWPMailStatus.Enabled = 0;
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPMailStatus.Enabled), 5, 0), true);
         edtWWPMailCreated_Enabled = 0;
         AssignProp("", false, edtWWPMailCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCreated_Enabled), 5, 0), true);
         edtWWPMailScheduled_Enabled = 0;
         AssignProp("", false, edtWWPMailScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailScheduled_Enabled), 5, 0), true);
         edtWWPMailProcessed_Enabled = 0;
         AssignProp("", false, edtWWPMailProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailProcessed_Enabled), 5, 0), true);
         edtWWPMailDetail_Enabled = 0;
         AssignProp("", false, edtWWPMailDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void ZM0A11( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -10 )
         {
            Z20WWPMailId = A20WWPMailId;
            Z21WWPMailAttachmentName = A21WWPMailAttachmentName;
            Z76WWPMailAttachmentFile = A76WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0A11( )
      {
      }

      protected void standaloneModal0A11( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPMailAttachmentName_Enabled = 0;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         }
         else
         {
            edtWWPMailAttachmentName_Enabled = 1;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         }
      }

      protected void Load0A11( )
      {
         /* Using cursor T000A17 */
         pr_default.execute(15, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound11 = 1;
            A76WWPMailAttachmentFile = T000A17_A76WWPMailAttachmentFile[0];
            ZM0A11( -10) ;
         }
         pr_default.close(15);
         OnLoadActions0A11( ) ;
      }

      protected void OnLoadActions0A11( )
      {
      }

      protected void CheckExtendedTable0A11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0A11( ) ;
      }

      protected void CloseExtendedTableCursors0A11( )
      {
      }

      protected void enableDisable0A11( )
      {
      }

      protected void GetKey0A11( )
      {
         /* Using cursor T000A18 */
         pr_default.execute(16, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey0A11( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A11( 10) ;
            RcdFound11 = 1;
            InitializeNonKey0A11( ) ;
            A21WWPMailAttachmentName = T000A3_A21WWPMailAttachmentName[0];
            A76WWPMailAttachmentFile = T000A3_A76WWPMailAttachmentFile[0];
            Z20WWPMailId = A20WWPMailId;
            Z21WWPMailAttachmentName = A21WWPMailAttachmentName;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0A11( ) ;
            Load0A11( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0A11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0A11( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0A11( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0A11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A11( )
      {
         if ( ! IsAuthorized("wwpmail_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A11( 0) ;
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A19 */
                     pr_default.execute(17, new Object[] {A20WWPMailId, A21WWPMailAttachmentName, A76WWPMailAttachmentFile});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load0A11( ) ;
            }
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void Update0A11( )
      {
         if ( ! IsAuthorized("wwpmail_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( ( nIsMod_11 != 0 ) || ( nIsDirty_11 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0A11( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0A11( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000A20 */
                        pr_default.execute(18, new Object[] {A76WWPMailAttachmentFile, A20WWPMailId, A21WWPMailAttachmentName});
                        pr_default.close(18);
                        dsDefault.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                        if ( (pr_default.getStatus(18) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0A11( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0A11( ) ;
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
               EndLevel0A11( ) ;
            }
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void DeferredUpdate0A11( )
      {
      }

      protected void Delete0A11( )
      {
         if ( ! IsAuthorized("wwpmail_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A11( ) ;
            AfterConfirm0A11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A21 */
                  pr_default.execute(19, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A11( )
      {
         standaloneModal0A11( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0A11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A11( )
      {
         /* Scan By routine */
         /* Using cursor T000A22 */
         pr_default.execute(20, new Object[] {A20WWPMailId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound11 = 1;
            A21WWPMailAttachmentName = T000A22_A21WWPMailAttachmentName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A11( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound11 = 1;
            A21WWPMailAttachmentName = T000A22_A21WWPMailAttachmentName[0];
         }
      }

      protected void ScanEnd0A11( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0A11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A11( )
      {
         edtWWPMailAttachmentName_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtWWPMailAttachmentFile_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_104_Refreshing);
      }

      protected void send_integrity_lvl_hashes0A11( )
      {
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void SubsflControlProps_10411( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_104_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_104_idx;
      }

      protected void SubsflControlProps_fel_10411( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_104_fel_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_104_fel_idx;
      }

      protected void AddRow0A11( )
      {
         nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10411( ) ;
         SendRow0A11( ) ;
      }

      protected void SendRow0A11( )
      {
         Gridwwp_mail_attachmentsRow = GXWebRow.GetNew(context);
         if ( subGridwwp_mail_attachments_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            subGridwwp_mail_attachments_Backcolor = subGridwwp_mail_attachments_Allbackcolor;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Uniform";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
            subGridwwp_mail_attachments_Backcolor = (int)(0x0);
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( ((int)((nGXsfl_104_idx) % (2))) == 0 )
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Even";
               }
            }
            else
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentName_Internalname,(string)A21WWPMailAttachmentName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentName_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)104,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentFile_Internalname,(string)A76WWPMailAttachmentFile,(string)A76WWPMailAttachmentFile,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentFile_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentFile_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)104,(short)1,(short)0,(short)-1,(bool)true,(string)"",(string)"left",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridwwp_mail_attachmentsRow);
         send_integrity_lvl_hashes0A11( ) ;
         GXCCtl = "Z21WWPMailAttachmentName_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z21WWPMailAttachmentName);
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_11_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", "")));
         GXCCtl = "nIsMod_11_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTNAME_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTFILE_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridwwp_mail_attachmentsContainer.AddRow(Gridwwp_mail_attachmentsRow);
      }

      protected void ReadRow0A11( )
      {
         nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10411( ) ;
         edtWWPMailAttachmentName_Enabled = (int)(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_104_idx+"Enabled"), ",", "."));
         edtWWPMailAttachmentFile_Enabled = (int)(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_104_idx+"Enabled"), ",", "."));
         A21WWPMailAttachmentName = cgiGet( edtWWPMailAttachmentName_Internalname);
         A76WWPMailAttachmentFile = cgiGet( edtWWPMailAttachmentFile_Internalname);
         GXCCtl = "Z21WWPMailAttachmentName_" + sGXsfl_104_idx;
         Z21WWPMailAttachmentName = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_104_idx;
         nRcdDeleted_11 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_11_" + sGXsfl_104_idx;
         nRcdExists_11 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_11_" + sGXsfl_104_idx;
         nIsMod_11 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtWWPMailAttachmentName_Enabled = edtWWPMailAttachmentName_Enabled;
      }

      protected void ConfirmValues0A0( )
      {
         nGXsfl_104_idx = 0;
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10411( ) ;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_10411( ) ;
            ChangePostValue( "Z21WWPMailAttachmentName_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z21WWPMailAttachmentName_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z21WWPMailAttachmentName_"+sGXsfl_104_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?202142815483569", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.wwp_mail.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z20WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20WWPMailId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z61WWPMailSubject", Z61WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z72WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72WWPMailStatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z81WWPMailCreated", context.localUtil.TToC( Z81WWPMailCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z82WWPMailScheduled", context.localUtil.TToC( Z82WWPMailScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z77WWPMailProcessed", context.localUtil.TToC( Z77WWPMailProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_104", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_104_idx), 8, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.mail.wwp_mail.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.WWP_Mail" ;
      }

      public override string GetPgmdesc( )
      {
         return "Mail" ;
      }

      protected void InitializeNonKey0A10( )
      {
         A61WWPMailSubject = "";
         AssignAttri("", false, "A61WWPMailSubject", A61WWPMailSubject);
         A55WWPMailBody = "";
         AssignAttri("", false, "A55WWPMailBody", A55WWPMailBody);
         A62WWPMailTo = "";
         n62WWPMailTo = false;
         AssignAttri("", false, "A62WWPMailTo", A62WWPMailTo);
         n62WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A62WWPMailTo)) ? true : false);
         A74WWPMailCC = "";
         n74WWPMailCC = false;
         AssignAttri("", false, "A74WWPMailCC", A74WWPMailCC);
         n74WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A74WWPMailCC)) ? true : false);
         A75WWPMailBCC = "";
         n75WWPMailBCC = false;
         AssignAttri("", false, "A75WWPMailBCC", A75WWPMailBCC);
         n75WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A75WWPMailBCC)) ? true : false);
         A63WWPMailSenderAddress = "";
         AssignAttri("", false, "A63WWPMailSenderAddress", A63WWPMailSenderAddress);
         A64WWPMailSenderName = "";
         AssignAttri("", false, "A64WWPMailSenderName", A64WWPMailSenderName);
         A77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n77WWPMailProcessed = false;
         AssignAttri("", false, "A77WWPMailProcessed", context.localUtil.TToC( A77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
         n77WWPMailProcessed = ((DateTime.MinValue==A77WWPMailProcessed) ? true : false);
         A78WWPMailDetail = "";
         n78WWPMailDetail = false;
         AssignAttri("", false, "A78WWPMailDetail", A78WWPMailDetail);
         n78WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A78WWPMailDetail)) ? true : false);
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
         n16WWPNotificationId = ((0==A16WWPNotificationId) ? true : false);
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A72WWPMailStatus = 1;
         AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
         A81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         A82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
         Z61WWPMailSubject = "";
         Z72WWPMailStatus = 0;
         Z81WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z16WWPNotificationId = 0;
      }

      protected void InitAll0A10( )
      {
         A20WWPMailId = 0;
         AssignAttri("", false, "A20WWPMailId", StringUtil.LTrimStr( (decimal)(A20WWPMailId), 10, 0));
         InitializeNonKey0A10( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A72WWPMailStatus = i72WWPMailStatus;
         AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
         A81WWPMailCreated = i81WWPMailCreated;
         AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         A82WWPMailScheduled = i82WWPMailScheduled;
         AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
      }

      protected void InitializeNonKey0A11( )
      {
         A76WWPMailAttachmentFile = "";
      }

      protected void InitAll0A11( )
      {
         A21WWPMailAttachmentName = "";
         InitializeNonKey0A11( ) ;
      }

      protected void StandaloneModalInsert0A11( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815483594", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/wwp_mail.js", "?202142815483595", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties11( )
      {
         edtWWPMailAttachmentName_Enabled = defedtWWPMailAttachmentName_Enabled;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_104_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtWWPMailId_Internalname = "WWPMAILID";
         edtWWPMailSubject_Internalname = "WWPMAILSUBJECT";
         edtWWPMailBody_Internalname = "WWPMAILBODY";
         edtWWPMailTo_Internalname = "WWPMAILTO";
         edtWWPMailCC_Internalname = "WWPMAILCC";
         edtWWPMailBCC_Internalname = "WWPMAILBCC";
         edtWWPMailSenderAddress_Internalname = "WWPMAILSENDERADDRESS";
         edtWWPMailSenderName_Internalname = "WWPMAILSENDERNAME";
         cmbWWPMailStatus_Internalname = "WWPMAILSTATUS";
         edtWWPMailCreated_Internalname = "WWPMAILCREATED";
         edtWWPMailScheduled_Internalname = "WWPMAILSCHEDULED";
         edtWWPMailProcessed_Internalname = "WWPMAILPROCESSED";
         edtWWPMailDetail_Internalname = "WWPMAILDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         lblTitleattachments_Internalname = "TITLEATTACHMENTS";
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME";
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridwwp_mail_attachments_Internalname = "GRIDWWP_MAIL_ATTACHMENTS";
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
         Form.Caption = "Mail";
         edtWWPMailAttachmentFile_Jsonclick = "";
         edtWWPMailAttachmentName_Jsonclick = "";
         subGridwwp_mail_attachments_Class = "Grid";
         subGridwwp_mail_attachments_Backcolorstyle = 0;
         subGridwwp_mail_attachments_Allowcollapsing = 0;
         subGridwwp_mail_attachments_Allowselection = 0;
         edtWWPMailAttachmentFile_Enabled = 1;
         edtWWPMailAttachmentName_Enabled = 1;
         subGridwwp_mail_attachments_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPMailDetail_Enabled = 1;
         edtWWPMailProcessed_Jsonclick = "";
         edtWWPMailProcessed_Enabled = 1;
         edtWWPMailScheduled_Jsonclick = "";
         edtWWPMailScheduled_Enabled = 1;
         edtWWPMailCreated_Jsonclick = "";
         edtWWPMailCreated_Enabled = 1;
         cmbWWPMailStatus_Jsonclick = "";
         cmbWWPMailStatus.Enabled = 1;
         edtWWPMailSenderName_Enabled = 1;
         edtWWPMailSenderAddress_Enabled = 1;
         edtWWPMailBCC_Enabled = 1;
         edtWWPMailCC_Enabled = 1;
         edtWWPMailTo_Enabled = 1;
         edtWWPMailBody_Enabled = 1;
         edtWWPMailSubject_Jsonclick = "";
         edtWWPMailSubject_Enabled = 1;
         edtWWPMailId_Jsonclick = "";
         edtWWPMailId_Enabled = 1;
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

      protected void gxnrGridwwp_mail_attachments_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_10411( ) ;
         while ( nGXsfl_104_idx <= nRC_GXsfl_104 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0A11( ) ;
            standaloneModal0A11( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0A11( ) ;
            nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_10411( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridwwp_mail_attachmentsContainer)) ;
         /* End function gxnrGridwwp_mail_attachments_newrow */
      }

      protected void init_web_controls( )
      {
         cmbWWPMailStatus.Name = "WWPMAILSTATUS";
         cmbWWPMailStatus.WebTags = "";
         cmbWWPMailStatus.addItem("1", "Pending", 0);
         cmbWWPMailStatus.addItem("2", "Sent", 0);
         cmbWWPMailStatus.addItem("3", "Error", 0);
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            if ( (0==A72WWPMailStatus) )
            {
               A72WWPMailStatus = 1;
               AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPMailSubject_Internalname;
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

      public void Valid_Wwpmailid( )
      {
         A72WWPMailStatus = (short)(NumberUtil.Val( cmbWWPMailStatus.CurrentValue, "."));
         cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A72WWPMailStatus = (short)(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A72WWPMailStatus), 4, 0))), "."));
            cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A72WWPMailStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A72WWPMailStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A61WWPMailSubject", A61WWPMailSubject);
         AssignAttri("", false, "A55WWPMailBody", A55WWPMailBody);
         AssignAttri("", false, "A62WWPMailTo", A62WWPMailTo);
         AssignAttri("", false, "A74WWPMailCC", A74WWPMailCC);
         AssignAttri("", false, "A75WWPMailBCC", A75WWPMailBCC);
         AssignAttri("", false, "A63WWPMailSenderAddress", A63WWPMailSenderAddress);
         AssignAttri("", false, "A64WWPMailSenderName", A64WWPMailSenderName);
         AssignAttri("", false, "A72WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A72WWPMailStatus), 4, 0, ".", "")));
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A72WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A81WWPMailCreated", context.localUtil.TToC( A81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A82WWPMailScheduled", context.localUtil.TToC( A82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A77WWPMailProcessed", context.localUtil.TToC( A77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A78WWPMailDetail", A78WWPMailDetail);
         AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z20WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20WWPMailId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z61WWPMailSubject", Z61WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z55WWPMailBody", Z55WWPMailBody);
         GxWebStd.gx_hidden_field( context, "Z62WWPMailTo", Z62WWPMailTo);
         GxWebStd.gx_hidden_field( context, "Z74WWPMailCC", Z74WWPMailCC);
         GxWebStd.gx_hidden_field( context, "Z75WWPMailBCC", Z75WWPMailBCC);
         GxWebStd.gx_hidden_field( context, "Z63WWPMailSenderAddress", Z63WWPMailSenderAddress);
         GxWebStd.gx_hidden_field( context, "Z64WWPMailSenderName", Z64WWPMailSenderName);
         GxWebStd.gx_hidden_field( context, "Z72WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72WWPMailStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z81WWPMailCreated", context.localUtil.TToC( Z81WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z82WWPMailScheduled", context.localUtil.TToC( Z82WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z77WWPMailProcessed", context.localUtil.TToC( Z77WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z78WWPMailDetail", Z78WWPMailDetail);
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37WWPNotificationCreated", context.localUtil.TToC( Z37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n16WWPNotificationId = false;
         /* Using cursor T000A15 */
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
         A37WWPNotificationCreated = T000A15_A37WWPNotificationCreated[0];
         pr_default.close(13);
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
         setEventMetadata("VALID_WWPMAILID","{handler:'Valid_Wwpmailid',iparms:[{av:'A20WWPMailId',fld:'WWPMAILID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'cmbWWPMailStatus'},{av:'A72WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'},{av:'A81WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A82WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPMAILID",",oparms:[{av:'A61WWPMailSubject',fld:'WWPMAILSUBJECT',pic:''},{av:'A55WWPMailBody',fld:'WWPMAILBODY',pic:''},{av:'A62WWPMailTo',fld:'WWPMAILTO',pic:''},{av:'A74WWPMailCC',fld:'WWPMAILCC',pic:''},{av:'A75WWPMailBCC',fld:'WWPMAILBCC',pic:''},{av:'A63WWPMailSenderAddress',fld:'WWPMAILSENDERADDRESS',pic:''},{av:'A64WWPMailSenderName',fld:'WWPMAILSENDERNAME',pic:''},{av:'cmbWWPMailStatus'},{av:'A72WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'},{av:'A81WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A82WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A77WWPMailProcessed',fld:'WWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A78WWPMailDetail',fld:'WWPMAILDETAIL',pic:''},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z20WWPMailId'},{av:'Z61WWPMailSubject'},{av:'Z55WWPMailBody'},{av:'Z62WWPMailTo'},{av:'Z74WWPMailCC'},{av:'Z75WWPMailBCC'},{av:'Z63WWPMailSenderAddress'},{av:'Z64WWPMailSenderName'},{av:'Z72WWPMailStatus'},{av:'Z81WWPMailCreated'},{av:'Z82WWPMailScheduled'},{av:'Z77WWPMailProcessed'},{av:'Z78WWPMailDetail'},{av:'Z16WWPNotificationId'},{av:'Z37WWPNotificationCreated'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPMAILSTATUS","{handler:'Valid_Wwpmailstatus',iparms:[]");
         setEventMetadata("VALID_WWPMAILSTATUS",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILCREATED","{handler:'Valid_Wwpmailcreated',iparms:[]");
         setEventMetadata("VALID_WWPMAILCREATED",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILSCHEDULED","{handler:'Valid_Wwpmailscheduled',iparms:[]");
         setEventMetadata("VALID_WWPMAILSCHEDULED",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILPROCESSED","{handler:'Valid_Wwpmailprocessed',iparms:[]");
         setEventMetadata("VALID_WWPMAILPROCESSED",",oparms:[]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]}");
         setEventMetadata("VALID_WWPMAILATTACHMENTNAME","{handler:'Valid_Wwpmailattachmentname',iparms:[]");
         setEventMetadata("VALID_WWPMAILATTACHMENTNAME",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpmailattachmentfile',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(3);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z61WWPMailSubject = "";
         Z81WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z21WWPMailAttachmentName = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
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
         A61WWPMailSubject = "";
         A55WWPMailBody = "";
         A62WWPMailTo = "";
         A74WWPMailCC = "";
         A75WWPMailBCC = "";
         A63WWPMailSenderAddress = "";
         A64WWPMailSenderName = "";
         A81WWPMailCreated = (DateTime)(DateTime.MinValue);
         A82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A78WWPMailDetail = "";
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         lblTitleattachments_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridwwp_mail_attachmentsContainer = new GXWebGrid( context);
         Gridwwp_mail_attachmentsColumn = new GXWebColumn();
         A21WWPMailAttachmentName = "";
         A76WWPMailAttachmentFile = "";
         sMode11 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         Z55WWPMailBody = "";
         Z62WWPMailTo = "";
         Z74WWPMailCC = "";
         Z75WWPMailBCC = "";
         Z63WWPMailSenderAddress = "";
         Z64WWPMailSenderName = "";
         Z78WWPMailDetail = "";
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T000A7_A20WWPMailId = new long[1] ;
         T000A7_A61WWPMailSubject = new string[] {""} ;
         T000A7_A55WWPMailBody = new string[] {""} ;
         T000A7_A62WWPMailTo = new string[] {""} ;
         T000A7_n62WWPMailTo = new bool[] {false} ;
         T000A7_A74WWPMailCC = new string[] {""} ;
         T000A7_n74WWPMailCC = new bool[] {false} ;
         T000A7_A75WWPMailBCC = new string[] {""} ;
         T000A7_n75WWPMailBCC = new bool[] {false} ;
         T000A7_A63WWPMailSenderAddress = new string[] {""} ;
         T000A7_A64WWPMailSenderName = new string[] {""} ;
         T000A7_A72WWPMailStatus = new short[1] ;
         T000A7_A81WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000A7_A82WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A7_A77WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A7_n77WWPMailProcessed = new bool[] {false} ;
         T000A7_A78WWPMailDetail = new string[] {""} ;
         T000A7_n78WWPMailDetail = new bool[] {false} ;
         T000A7_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A7_A16WWPNotificationId = new long[1] ;
         T000A7_n16WWPNotificationId = new bool[] {false} ;
         T000A6_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A8_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A9_A20WWPMailId = new long[1] ;
         T000A5_A20WWPMailId = new long[1] ;
         T000A5_A61WWPMailSubject = new string[] {""} ;
         T000A5_A55WWPMailBody = new string[] {""} ;
         T000A5_A62WWPMailTo = new string[] {""} ;
         T000A5_n62WWPMailTo = new bool[] {false} ;
         T000A5_A74WWPMailCC = new string[] {""} ;
         T000A5_n74WWPMailCC = new bool[] {false} ;
         T000A5_A75WWPMailBCC = new string[] {""} ;
         T000A5_n75WWPMailBCC = new bool[] {false} ;
         T000A5_A63WWPMailSenderAddress = new string[] {""} ;
         T000A5_A64WWPMailSenderName = new string[] {""} ;
         T000A5_A72WWPMailStatus = new short[1] ;
         T000A5_A81WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000A5_A82WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A5_A77WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A5_n77WWPMailProcessed = new bool[] {false} ;
         T000A5_A78WWPMailDetail = new string[] {""} ;
         T000A5_n78WWPMailDetail = new bool[] {false} ;
         T000A5_A16WWPNotificationId = new long[1] ;
         T000A5_n16WWPNotificationId = new bool[] {false} ;
         sMode10 = "";
         T000A10_A20WWPMailId = new long[1] ;
         T000A11_A20WWPMailId = new long[1] ;
         T000A4_A20WWPMailId = new long[1] ;
         T000A4_A61WWPMailSubject = new string[] {""} ;
         T000A4_A55WWPMailBody = new string[] {""} ;
         T000A4_A62WWPMailTo = new string[] {""} ;
         T000A4_n62WWPMailTo = new bool[] {false} ;
         T000A4_A74WWPMailCC = new string[] {""} ;
         T000A4_n74WWPMailCC = new bool[] {false} ;
         T000A4_A75WWPMailBCC = new string[] {""} ;
         T000A4_n75WWPMailBCC = new bool[] {false} ;
         T000A4_A63WWPMailSenderAddress = new string[] {""} ;
         T000A4_A64WWPMailSenderName = new string[] {""} ;
         T000A4_A72WWPMailStatus = new short[1] ;
         T000A4_A81WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000A4_A82WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A4_A77WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A4_n77WWPMailProcessed = new bool[] {false} ;
         T000A4_A78WWPMailDetail = new string[] {""} ;
         T000A4_n78WWPMailDetail = new bool[] {false} ;
         T000A4_A16WWPNotificationId = new long[1] ;
         T000A4_n16WWPNotificationId = new bool[] {false} ;
         T000A12_A20WWPMailId = new long[1] ;
         T000A15_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A16_A20WWPMailId = new long[1] ;
         Z76WWPMailAttachmentFile = "";
         T000A17_A20WWPMailId = new long[1] ;
         T000A17_A21WWPMailAttachmentName = new string[] {""} ;
         T000A17_A76WWPMailAttachmentFile = new string[] {""} ;
         T000A18_A20WWPMailId = new long[1] ;
         T000A18_A21WWPMailAttachmentName = new string[] {""} ;
         T000A3_A20WWPMailId = new long[1] ;
         T000A3_A21WWPMailAttachmentName = new string[] {""} ;
         T000A3_A76WWPMailAttachmentFile = new string[] {""} ;
         T000A2_A20WWPMailId = new long[1] ;
         T000A2_A21WWPMailAttachmentName = new string[] {""} ;
         T000A2_A76WWPMailAttachmentFile = new string[] {""} ;
         T000A22_A20WWPMailId = new long[1] ;
         T000A22_A21WWPMailAttachmentName = new string[] {""} ;
         Gridwwp_mail_attachmentsRow = new GXWebRow();
         subGridwwp_mail_attachments_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i81WWPMailCreated = (DateTime)(DateTime.MinValue);
         i82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         ZZ61WWPMailSubject = "";
         ZZ55WWPMailBody = "";
         ZZ62WWPMailTo = "";
         ZZ74WWPMailCC = "";
         ZZ75WWPMailBCC = "";
         ZZ63WWPMailSenderAddress = "";
         ZZ64WWPMailSenderName = "";
         ZZ81WWPMailCreated = (DateTime)(DateTime.MinValue);
         ZZ82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         ZZ77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         ZZ78WWPMailDetail = "";
         ZZ37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__default(),
            new Object[][] {
                new Object[] {
               T000A2_A20WWPMailId, T000A2_A21WWPMailAttachmentName, T000A2_A76WWPMailAttachmentFile
               }
               , new Object[] {
               T000A3_A20WWPMailId, T000A3_A21WWPMailAttachmentName, T000A3_A76WWPMailAttachmentFile
               }
               , new Object[] {
               T000A4_A20WWPMailId, T000A4_A61WWPMailSubject, T000A4_A55WWPMailBody, T000A4_A62WWPMailTo, T000A4_n62WWPMailTo, T000A4_A74WWPMailCC, T000A4_n74WWPMailCC, T000A4_A75WWPMailBCC, T000A4_n75WWPMailBCC, T000A4_A63WWPMailSenderAddress,
               T000A4_A64WWPMailSenderName, T000A4_A72WWPMailStatus, T000A4_A81WWPMailCreated, T000A4_A82WWPMailScheduled, T000A4_A77WWPMailProcessed, T000A4_n77WWPMailProcessed, T000A4_A78WWPMailDetail, T000A4_n78WWPMailDetail, T000A4_A16WWPNotificationId, T000A4_n16WWPNotificationId
               }
               , new Object[] {
               T000A5_A20WWPMailId, T000A5_A61WWPMailSubject, T000A5_A55WWPMailBody, T000A5_A62WWPMailTo, T000A5_n62WWPMailTo, T000A5_A74WWPMailCC, T000A5_n74WWPMailCC, T000A5_A75WWPMailBCC, T000A5_n75WWPMailBCC, T000A5_A63WWPMailSenderAddress,
               T000A5_A64WWPMailSenderName, T000A5_A72WWPMailStatus, T000A5_A81WWPMailCreated, T000A5_A82WWPMailScheduled, T000A5_A77WWPMailProcessed, T000A5_n77WWPMailProcessed, T000A5_A78WWPMailDetail, T000A5_n78WWPMailDetail, T000A5_A16WWPNotificationId, T000A5_n16WWPNotificationId
               }
               , new Object[] {
               T000A6_A37WWPNotificationCreated
               }
               , new Object[] {
               T000A7_A20WWPMailId, T000A7_A61WWPMailSubject, T000A7_A55WWPMailBody, T000A7_A62WWPMailTo, T000A7_n62WWPMailTo, T000A7_A74WWPMailCC, T000A7_n74WWPMailCC, T000A7_A75WWPMailBCC, T000A7_n75WWPMailBCC, T000A7_A63WWPMailSenderAddress,
               T000A7_A64WWPMailSenderName, T000A7_A72WWPMailStatus, T000A7_A81WWPMailCreated, T000A7_A82WWPMailScheduled, T000A7_A77WWPMailProcessed, T000A7_n77WWPMailProcessed, T000A7_A78WWPMailDetail, T000A7_n78WWPMailDetail, T000A7_A37WWPNotificationCreated, T000A7_A16WWPNotificationId,
               T000A7_n16WWPNotificationId
               }
               , new Object[] {
               T000A8_A37WWPNotificationCreated
               }
               , new Object[] {
               T000A9_A20WWPMailId
               }
               , new Object[] {
               T000A10_A20WWPMailId
               }
               , new Object[] {
               T000A11_A20WWPMailId
               }
               , new Object[] {
               T000A12_A20WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A15_A37WWPNotificationCreated
               }
               , new Object[] {
               T000A16_A20WWPMailId
               }
               , new Object[] {
               T000A17_A20WWPMailId, T000A17_A21WWPMailAttachmentName, T000A17_A76WWPMailAttachmentFile
               }
               , new Object[] {
               T000A18_A20WWPMailId, T000A18_A21WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A22_A20WWPMailId, T000A22_A21WWPMailAttachmentName
               }
            }
         );
         Z82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z72WWPMailStatus = 1;
         A72WWPMailStatus = 1;
         i72WWPMailStatus = 1;
      }

      private short Z72WWPMailStatus ;
      private short nRcdDeleted_11 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A72WWPMailStatus ;
      private short subGridwwp_mail_attachments_Backcolorstyle ;
      private short subGridwwp_mail_attachments_Allowselection ;
      private short subGridwwp_mail_attachments_Allowhovering ;
      private short subGridwwp_mail_attachments_Allowcollapsing ;
      private short subGridwwp_mail_attachments_Collapsed ;
      private short nBlankRcdCount11 ;
      private short RcdFound11 ;
      private short nBlankRcdUsr11 ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private short nIsDirty_11 ;
      private short subGridwwp_mail_attachments_Backstyle ;
      private short gxajaxcallmode ;
      private short i72WWPMailStatus ;
      private short ZZ72WWPMailStatus ;
      private int nRC_GXsfl_104 ;
      private int nGXsfl_104_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPMailId_Enabled ;
      private int edtWWPMailSubject_Enabled ;
      private int edtWWPMailBody_Enabled ;
      private int edtWWPMailTo_Enabled ;
      private int edtWWPMailCC_Enabled ;
      private int edtWWPMailBCC_Enabled ;
      private int edtWWPMailSenderAddress_Enabled ;
      private int edtWWPMailSenderName_Enabled ;
      private int edtWWPMailCreated_Enabled ;
      private int edtWWPMailScheduled_Enabled ;
      private int edtWWPMailProcessed_Enabled ;
      private int edtWWPMailDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtWWPMailAttachmentName_Enabled ;
      private int edtWWPMailAttachmentFile_Enabled ;
      private int subGridwwp_mail_attachments_Selectedindex ;
      private int subGridwwp_mail_attachments_Selectioncolor ;
      private int subGridwwp_mail_attachments_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridwwp_mail_attachments_Backcolor ;
      private int subGridwwp_mail_attachments_Allbackcolor ;
      private int defedtWWPMailAttachmentName_Enabled ;
      private int idxLst ;
      private long Z20WWPMailId ;
      private long Z16WWPNotificationId ;
      private long A16WWPNotificationId ;
      private long A20WWPMailId ;
      private long GRIDWWP_MAIL_ATTACHMENTS_nFirstRecordOnPage ;
      private long ZZ20WWPMailId ;
      private long ZZ16WWPNotificationId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_104_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPMailId_Internalname ;
      private string cmbWWPMailStatus_Internalname ;
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
      private string edtWWPMailId_Jsonclick ;
      private string edtWWPMailSubject_Internalname ;
      private string edtWWPMailSubject_Jsonclick ;
      private string edtWWPMailBody_Internalname ;
      private string edtWWPMailTo_Internalname ;
      private string edtWWPMailCC_Internalname ;
      private string edtWWPMailBCC_Internalname ;
      private string edtWWPMailSenderAddress_Internalname ;
      private string edtWWPMailSenderName_Internalname ;
      private string cmbWWPMailStatus_Jsonclick ;
      private string edtWWPMailCreated_Internalname ;
      private string edtWWPMailCreated_Jsonclick ;
      private string edtWWPMailScheduled_Internalname ;
      private string edtWWPMailScheduled_Jsonclick ;
      private string edtWWPMailProcessed_Internalname ;
      private string edtWWPMailProcessed_Jsonclick ;
      private string edtWWPMailDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string lblTitleattachments_Internalname ;
      private string lblTitleattachments_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridwwp_mail_attachments_Header ;
      private string sMode11 ;
      private string edtWWPMailAttachmentName_Internalname ;
      private string edtWWPMailAttachmentFile_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode10 ;
      private string sGXsfl_104_fel_idx="0001" ;
      private string subGridwwp_mail_attachments_Class ;
      private string subGridwwp_mail_attachments_Linesclass ;
      private string ROClassString ;
      private string edtWWPMailAttachmentName_Jsonclick ;
      private string edtWWPMailAttachmentFile_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridwwp_mail_attachments_Internalname ;
      private DateTime Z81WWPMailCreated ;
      private DateTime Z82WWPMailScheduled ;
      private DateTime Z77WWPMailProcessed ;
      private DateTime A81WWPMailCreated ;
      private DateTime A82WWPMailScheduled ;
      private DateTime A77WWPMailProcessed ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime i81WWPMailCreated ;
      private DateTime i82WWPMailScheduled ;
      private DateTime ZZ81WWPMailCreated ;
      private DateTime ZZ82WWPMailScheduled ;
      private DateTime ZZ77WWPMailProcessed ;
      private DateTime ZZ37WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n16WWPNotificationId ;
      private bool wbErr ;
      private bool bGXsfl_104_Refreshing=false ;
      private bool n77WWPMailProcessed ;
      private bool n62WWPMailTo ;
      private bool n74WWPMailCC ;
      private bool n75WWPMailBCC ;
      private bool n78WWPMailDetail ;
      private bool Gx_longc ;
      private string A55WWPMailBody ;
      private string A62WWPMailTo ;
      private string A74WWPMailCC ;
      private string A75WWPMailBCC ;
      private string A63WWPMailSenderAddress ;
      private string A64WWPMailSenderName ;
      private string A78WWPMailDetail ;
      private string A76WWPMailAttachmentFile ;
      private string Z55WWPMailBody ;
      private string Z62WWPMailTo ;
      private string Z74WWPMailCC ;
      private string Z75WWPMailBCC ;
      private string Z63WWPMailSenderAddress ;
      private string Z64WWPMailSenderName ;
      private string Z78WWPMailDetail ;
      private string Z76WWPMailAttachmentFile ;
      private string ZZ55WWPMailBody ;
      private string ZZ62WWPMailTo ;
      private string ZZ74WWPMailCC ;
      private string ZZ75WWPMailBCC ;
      private string ZZ63WWPMailSenderAddress ;
      private string ZZ64WWPMailSenderName ;
      private string ZZ78WWPMailDetail ;
      private string Z61WWPMailSubject ;
      private string Z21WWPMailAttachmentName ;
      private string A61WWPMailSubject ;
      private string A21WWPMailAttachmentName ;
      private string ZZ61WWPMailSubject ;
      private GXWebGrid Gridwwp_mail_attachmentsContainer ;
      private GXWebRow Gridwwp_mail_attachmentsRow ;
      private GXWebColumn Gridwwp_mail_attachmentsColumn ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPMailStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T000A7_A20WWPMailId ;
      private string[] T000A7_A61WWPMailSubject ;
      private string[] T000A7_A55WWPMailBody ;
      private string[] T000A7_A62WWPMailTo ;
      private bool[] T000A7_n62WWPMailTo ;
      private string[] T000A7_A74WWPMailCC ;
      private bool[] T000A7_n74WWPMailCC ;
      private string[] T000A7_A75WWPMailBCC ;
      private bool[] T000A7_n75WWPMailBCC ;
      private string[] T000A7_A63WWPMailSenderAddress ;
      private string[] T000A7_A64WWPMailSenderName ;
      private short[] T000A7_A72WWPMailStatus ;
      private DateTime[] T000A7_A81WWPMailCreated ;
      private DateTime[] T000A7_A82WWPMailScheduled ;
      private DateTime[] T000A7_A77WWPMailProcessed ;
      private bool[] T000A7_n77WWPMailProcessed ;
      private string[] T000A7_A78WWPMailDetail ;
      private bool[] T000A7_n78WWPMailDetail ;
      private DateTime[] T000A7_A37WWPNotificationCreated ;
      private long[] T000A7_A16WWPNotificationId ;
      private bool[] T000A7_n16WWPNotificationId ;
      private DateTime[] T000A6_A37WWPNotificationCreated ;
      private DateTime[] T000A8_A37WWPNotificationCreated ;
      private long[] T000A9_A20WWPMailId ;
      private long[] T000A5_A20WWPMailId ;
      private string[] T000A5_A61WWPMailSubject ;
      private string[] T000A5_A55WWPMailBody ;
      private string[] T000A5_A62WWPMailTo ;
      private bool[] T000A5_n62WWPMailTo ;
      private string[] T000A5_A74WWPMailCC ;
      private bool[] T000A5_n74WWPMailCC ;
      private string[] T000A5_A75WWPMailBCC ;
      private bool[] T000A5_n75WWPMailBCC ;
      private string[] T000A5_A63WWPMailSenderAddress ;
      private string[] T000A5_A64WWPMailSenderName ;
      private short[] T000A5_A72WWPMailStatus ;
      private DateTime[] T000A5_A81WWPMailCreated ;
      private DateTime[] T000A5_A82WWPMailScheduled ;
      private DateTime[] T000A5_A77WWPMailProcessed ;
      private bool[] T000A5_n77WWPMailProcessed ;
      private string[] T000A5_A78WWPMailDetail ;
      private bool[] T000A5_n78WWPMailDetail ;
      private long[] T000A5_A16WWPNotificationId ;
      private bool[] T000A5_n16WWPNotificationId ;
      private long[] T000A10_A20WWPMailId ;
      private long[] T000A11_A20WWPMailId ;
      private long[] T000A4_A20WWPMailId ;
      private string[] T000A4_A61WWPMailSubject ;
      private string[] T000A4_A55WWPMailBody ;
      private string[] T000A4_A62WWPMailTo ;
      private bool[] T000A4_n62WWPMailTo ;
      private string[] T000A4_A74WWPMailCC ;
      private bool[] T000A4_n74WWPMailCC ;
      private string[] T000A4_A75WWPMailBCC ;
      private bool[] T000A4_n75WWPMailBCC ;
      private string[] T000A4_A63WWPMailSenderAddress ;
      private string[] T000A4_A64WWPMailSenderName ;
      private short[] T000A4_A72WWPMailStatus ;
      private DateTime[] T000A4_A81WWPMailCreated ;
      private DateTime[] T000A4_A82WWPMailScheduled ;
      private DateTime[] T000A4_A77WWPMailProcessed ;
      private bool[] T000A4_n77WWPMailProcessed ;
      private string[] T000A4_A78WWPMailDetail ;
      private bool[] T000A4_n78WWPMailDetail ;
      private long[] T000A4_A16WWPNotificationId ;
      private bool[] T000A4_n16WWPNotificationId ;
      private long[] T000A12_A20WWPMailId ;
      private DateTime[] T000A15_A37WWPNotificationCreated ;
      private long[] T000A16_A20WWPMailId ;
      private long[] T000A17_A20WWPMailId ;
      private string[] T000A17_A21WWPMailAttachmentName ;
      private string[] T000A17_A76WWPMailAttachmentFile ;
      private long[] T000A18_A20WWPMailId ;
      private string[] T000A18_A21WWPMailAttachmentName ;
      private long[] T000A3_A20WWPMailId ;
      private string[] T000A3_A21WWPMailAttachmentName ;
      private string[] T000A3_A76WWPMailAttachmentFile ;
      private long[] T000A2_A20WWPMailId ;
      private string[] T000A2_A21WWPMailAttachmentName ;
      private string[] T000A2_A76WWPMailAttachmentFile ;
      private long[] T000A22_A20WWPMailId ;
      private string[] T000A22_A21WWPMailAttachmentName ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_mail__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000A7;
        prmT000A7 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A6;
        prmT000A6 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A8;
        prmT000A8 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A9;
        prmT000A9 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A5;
        prmT000A5 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A10;
        prmT000A10 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A11;
        prmT000A11 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A4;
        prmT000A4 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A12;
        prmT000A12 = new Object[] {
        new Object[] {"@WWPMailSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTo",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailBCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderName",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPMailCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A13;
        prmT000A13 = new Object[] {
        new Object[] {"@WWPMailSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTo",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailBCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderName",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPMailCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A14;
        prmT000A14 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A16;
        prmT000A16 = new Object[] {
        };
        Object[] prmT000A17;
        prmT000A17 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000A18;
        prmT000A18 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000A3;
        prmT000A3 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000A2;
        prmT000A2 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000A19;
        prmT000A19 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPMailAttachmentFile",SqlDbType.NVarChar,2097152,0}
        };
        Object[] prmT000A20;
        prmT000A20 = new Object[] {
        new Object[] {"@WWPMailAttachmentFile",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000A21;
        prmT000A21 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000A22;
        prmT000A22 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000A15;
        prmT000A15 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000A2", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A3", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A4", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A5", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A6", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A7", "SELECT TM1.[WWPMailId], TM1.[WWPMailSubject], TM1.[WWPMailBody], TM1.[WWPMailTo], TM1.[WWPMailCC], TM1.[WWPMailBCC], TM1.[WWPMailSenderAddress], TM1.[WWPMailSenderName], TM1.[WWPMailStatus], TM1.[WWPMailCreated], TM1.[WWPMailScheduled], TM1.[WWPMailProcessed], TM1.[WWPMailDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_Mail] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPMailId] = @WWPMailId ORDER BY TM1.[WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A8", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A9", "SELECT [WWPMailId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A10", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE ( [WWPMailId] > @WWPMailId) ORDER BY [WWPMailId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A11", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE ( [WWPMailId] < @WWPMailId) ORDER BY [WWPMailId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A12", "INSERT INTO [WWP_Mail]([WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId]) VALUES(@WWPMailSubject, @WWPMailBody, @WWPMailTo, @WWPMailCC, @WWPMailBCC, @WWPMailSenderAddress, @WWPMailSenderName, @WWPMailStatus, @WWPMailCreated, @WWPMailScheduled, @WWPMailProcessed, @WWPMailDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000A12)
           ,new CursorDef("T000A13", "UPDATE [WWP_Mail] SET [WWPMailSubject]=@WWPMailSubject, [WWPMailBody]=@WWPMailBody, [WWPMailTo]=@WWPMailTo, [WWPMailCC]=@WWPMailCC, [WWPMailBCC]=@WWPMailBCC, [WWPMailSenderAddress]=@WWPMailSenderAddress, [WWPMailSenderName]=@WWPMailSenderName, [WWPMailStatus]=@WWPMailStatus, [WWPMailCreated]=@WWPMailCreated, [WWPMailScheduled]=@WWPMailScheduled, [WWPMailProcessed]=@WWPMailProcessed, [WWPMailDetail]=@WWPMailDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmT000A13)
           ,new CursorDef("T000A14", "DELETE FROM [WWP_Mail]  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmT000A14)
           ,new CursorDef("T000A15", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A16", "SELECT [WWPMailId] FROM [WWP_Mail] ORDER BY [WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A17", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId and [WWPMailAttachmentName] = @WWPMailAttachmentName ORDER BY [WWPMailId], [WWPMailAttachmentName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A18", "SELECT [WWPMailId], [WWPMailAttachmentName] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A19", "INSERT INTO [WWP_MailAttachments]([WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile]) VALUES(@WWPMailId, @WWPMailAttachmentName, @WWPMailAttachmentFile)", GxErrorMask.GX_NOMASK,prmT000A19)
           ,new CursorDef("T000A20", "UPDATE [WWP_MailAttachments] SET [WWPMailAttachmentFile]=@WWPMailAttachmentFile  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmT000A20)
           ,new CursorDef("T000A21", "DELETE FROM [WWP_MailAttachments]  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmT000A21)
           ,new CursorDef("T000A22", "SELECT [WWPMailId], [WWPMailAttachmentName] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId ORDER BY [WWPMailId], [WWPMailAttachmentName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A22,11, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getLongVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLongVarchar(6);
              table[8][0] = rslt.wasNull(6);
              table[9][0] = rslt.getLongVarchar(7);
              table[10][0] = rslt.getLongVarchar(8);
              table[11][0] = rslt.getShort(9);
              table[12][0] = rslt.getGXDateTime(10, true);
              table[13][0] = rslt.getGXDateTime(11, true);
              table[14][0] = rslt.getGXDateTime(12, true);
              table[15][0] = rslt.wasNull(12);
              table[16][0] = rslt.getLongVarchar(13);
              table[17][0] = rslt.wasNull(13);
              table[18][0] = rslt.getLong(14);
              table[19][0] = rslt.wasNull(14);
              return;
           case 3 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getLongVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLongVarchar(6);
              table[8][0] = rslt.wasNull(6);
              table[9][0] = rslt.getLongVarchar(7);
              table[10][0] = rslt.getLongVarchar(8);
              table[11][0] = rslt.getShort(9);
              table[12][0] = rslt.getGXDateTime(10, true);
              table[13][0] = rslt.getGXDateTime(11, true);
              table[14][0] = rslt.getGXDateTime(12, true);
              table[15][0] = rslt.wasNull(12);
              table[16][0] = rslt.getLongVarchar(13);
              table[17][0] = rslt.wasNull(13);
              table[18][0] = rslt.getLong(14);
              table[19][0] = rslt.wasNull(14);
              return;
           case 4 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getLongVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLongVarchar(6);
              table[8][0] = rslt.wasNull(6);
              table[9][0] = rslt.getLongVarchar(7);
              table[10][0] = rslt.getLongVarchar(8);
              table[11][0] = rslt.getShort(9);
              table[12][0] = rslt.getGXDateTime(10, true);
              table[13][0] = rslt.getGXDateTime(11, true);
              table[14][0] = rslt.getGXDateTime(12, true);
              table[15][0] = rslt.wasNull(12);
              table[16][0] = rslt.getLongVarchar(13);
              table[17][0] = rslt.wasNull(13);
              table[18][0] = rslt.getGXDateTime(14, true);
              table[19][0] = rslt.getLong(15);
              table[20][0] = rslt.wasNull(15);
              return;
           case 6 :
              table[0][0] = rslt.getGXDateTime(1, true);
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
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 14 :
              table[0][0] = rslt.getLong(1);
              return;
           case 15 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              return;
           case 16 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 20 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
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
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 2 :
              stmt.SetParameter(1, (long)parms[0]);
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
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
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 5 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[7]);
              }
              stmt.SetParameter(6, (string)parms[8]);
              stmt.SetParameter(7, (string)parms[9]);
              stmt.SetParameter(8, (short)parms[10]);
              stmt.SetParameterDatetime(9, (DateTime)parms[11], true);
              stmt.SetParameterDatetime(10, (DateTime)parms[12], true);
              if ( (bool)parms[13] )
              {
                 stmt.setNull( 11 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(11, (DateTime)parms[14], true);
              }
              if ( (bool)parms[15] )
              {
                 stmt.setNull( 12 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(12, (string)parms[16]);
              }
              if ( (bool)parms[17] )
              {
                 stmt.setNull( 13 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(13, (long)parms[18]);
              }
              return;
           case 11 :
              stmt.SetParameter(1, (string)parms[0]);
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
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 5 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[7]);
              }
              stmt.SetParameter(6, (string)parms[8]);
              stmt.SetParameter(7, (string)parms[9]);
              stmt.SetParameter(8, (short)parms[10]);
              stmt.SetParameterDatetime(9, (DateTime)parms[11], true);
              stmt.SetParameterDatetime(10, (DateTime)parms[12], true);
              if ( (bool)parms[13] )
              {
                 stmt.setNull( 11 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(11, (DateTime)parms[14], true);
              }
              if ( (bool)parms[15] )
              {
                 stmt.setNull( 12 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(12, (string)parms[16]);
              }
              if ( (bool)parms[17] )
              {
                 stmt.setNull( 13 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(13, (long)parms[18]);
              }
              stmt.SetParameter(14, (long)parms[19]);
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
           case 15 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 16 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 17 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              return;
           case 18 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (long)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              return;
           case 19 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 20 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
