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
   public class wwp_mailtemplate : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            Form.Meta.addItem("description", "Mail Template", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_mailtemplate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_mailtemplate( IGxContext context )
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
            return "wwpmailtemplate_Execute" ;
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Mail Template", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailTemplateName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateName_Internalname, A19WWPMailTemplateName, StringUtil.RTrim( context.localUtil.Format( A19WWPMailTemplateName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailTemplateDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateDescription_Internalname, A79WWPMailTemplateDescription, StringUtil.RTrim( context.localUtil.Format( A79WWPMailTemplateDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSubject_Internalname, "Subject", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateSubject_Internalname, A80WWPMailTemplateSubject, StringUtil.RTrim( context.localUtil.Format( A80WWPMailTemplateSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailTemplateBody_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateBody_Internalname, "Body", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateBody_Internalname, A65WWPMailTemplateBody, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 1, 1, edtWWPMailTemplateBody_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSenderAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSenderAddress_Internalname, "Sender Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateSenderAddress_Internalname, A66WWPMailTemplateSenderAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", 0, 1, edtWWPMailTemplateSenderAddress_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSenderName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSenderName_Internalname, "Sender Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateSenderName_Internalname, A67WWPMailTemplateSenderName, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", 0, 1, edtWWPMailTemplateSenderName_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         E11092 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z19WWPMailTemplateName = cgiGet( "Z19WWPMailTemplateName");
               Z79WWPMailTemplateDescription = cgiGet( "Z79WWPMailTemplateDescription");
               Z80WWPMailTemplateSubject = cgiGet( "Z80WWPMailTemplateSubject");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               /* Read variables values. */
               A19WWPMailTemplateName = cgiGet( edtWWPMailTemplateName_Internalname);
               AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
               A79WWPMailTemplateDescription = cgiGet( edtWWPMailTemplateDescription_Internalname);
               AssignAttri("", false, "A79WWPMailTemplateDescription", A79WWPMailTemplateDescription);
               A80WWPMailTemplateSubject = cgiGet( edtWWPMailTemplateSubject_Internalname);
               AssignAttri("", false, "A80WWPMailTemplateSubject", A80WWPMailTemplateSubject);
               A65WWPMailTemplateBody = cgiGet( edtWWPMailTemplateBody_Internalname);
               AssignAttri("", false, "A65WWPMailTemplateBody", A65WWPMailTemplateBody);
               A66WWPMailTemplateSenderAddress = cgiGet( edtWWPMailTemplateSenderAddress_Internalname);
               AssignAttri("", false, "A66WWPMailTemplateSenderAddress", A66WWPMailTemplateSenderAddress);
               A67WWPMailTemplateSenderName = cgiGet( edtWWPMailTemplateSenderName_Internalname);
               AssignAttri("", false, "A67WWPMailTemplateSenderName", A67WWPMailTemplateSenderName);
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
                  A19WWPMailTemplateName = GetPar( "WWPMailTemplateName");
                  AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
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
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
            /* Execute user event: After Trn */
            E12092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll099( ) ;
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
         DisableAttributes099( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E12092( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z79WWPMailTemplateDescription = T00093_A79WWPMailTemplateDescription[0];
               Z80WWPMailTemplateSubject = T00093_A80WWPMailTemplateSubject[0];
            }
            else
            {
               Z79WWPMailTemplateDescription = A79WWPMailTemplateDescription;
               Z80WWPMailTemplateSubject = A80WWPMailTemplateSubject;
            }
         }
         if ( GX_JID == -1 )
         {
            Z19WWPMailTemplateName = A19WWPMailTemplateName;
            Z79WWPMailTemplateDescription = A79WWPMailTemplateDescription;
            Z80WWPMailTemplateSubject = A80WWPMailTemplateSubject;
            Z65WWPMailTemplateBody = A65WWPMailTemplateBody;
            Z66WWPMailTemplateSenderAddress = A66WWPMailTemplateSenderAddress;
            Z67WWPMailTemplateSenderName = A67WWPMailTemplateSenderName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load099( )
      {
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound9 = 1;
            A79WWPMailTemplateDescription = T00094_A79WWPMailTemplateDescription[0];
            AssignAttri("", false, "A79WWPMailTemplateDescription", A79WWPMailTemplateDescription);
            A80WWPMailTemplateSubject = T00094_A80WWPMailTemplateSubject[0];
            AssignAttri("", false, "A80WWPMailTemplateSubject", A80WWPMailTemplateSubject);
            A65WWPMailTemplateBody = T00094_A65WWPMailTemplateBody[0];
            AssignAttri("", false, "A65WWPMailTemplateBody", A65WWPMailTemplateBody);
            A66WWPMailTemplateSenderAddress = T00094_A66WWPMailTemplateSenderAddress[0];
            AssignAttri("", false, "A66WWPMailTemplateSenderAddress", A66WWPMailTemplateSenderAddress);
            A67WWPMailTemplateSenderName = T00094_A67WWPMailTemplateSenderName[0];
            AssignAttri("", false, "A67WWPMailTemplateSenderName", A67WWPMailTemplateSenderName);
            ZM099( -1) ;
         }
         pr_default.close(2);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors099( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 1) ;
            RcdFound9 = 1;
            A19WWPMailTemplateName = T00093_A19WWPMailTemplateName[0];
            AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
            A79WWPMailTemplateDescription = T00093_A79WWPMailTemplateDescription[0];
            AssignAttri("", false, "A79WWPMailTemplateDescription", A79WWPMailTemplateDescription);
            A80WWPMailTemplateSubject = T00093_A80WWPMailTemplateSubject[0];
            AssignAttri("", false, "A80WWPMailTemplateSubject", A80WWPMailTemplateSubject);
            A65WWPMailTemplateBody = T00093_A65WWPMailTemplateBody[0];
            AssignAttri("", false, "A65WWPMailTemplateBody", A65WWPMailTemplateBody);
            A66WWPMailTemplateSenderAddress = T00093_A66WWPMailTemplateSenderAddress[0];
            AssignAttri("", false, "A66WWPMailTemplateSenderAddress", A66WWPMailTemplateSenderAddress);
            A67WWPMailTemplateSenderName = T00093_A67WWPMailTemplateSenderName[0];
            AssignAttri("", false, "A67WWPMailTemplateSenderName", A67WWPMailTemplateSenderName);
            Z19WWPMailTemplateName = A19WWPMailTemplateName;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         RcdFound9 = 0;
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00096_A19WWPMailTemplateName[0], A19WWPMailTemplateName) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00096_A19WWPMailTemplateName[0], A19WWPMailTemplateName) > 0 ) ) )
            {
               A19WWPMailTemplateName = T00096_A19WWPMailTemplateName[0];
               AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
               RcdFound9 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A19WWPMailTemplateName});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00097_A19WWPMailTemplateName[0], A19WWPMailTemplateName) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00097_A19WWPMailTemplateName[0], A19WWPMailTemplateName) < 0 ) ) )
            {
               A19WWPMailTemplateName = T00097_A19WWPMailTemplateName[0];
               AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
               RcdFound9 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( StringUtil.StrCmp(A19WWPMailTemplateName, Z19WWPMailTemplateName) != 0 )
               {
                  A19WWPMailTemplateName = Z19WWPMailTemplateName;
                  AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPMAILTEMPLATENAME");
                  AnyError = 1;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update099( ) ;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A19WWPMailTemplateName, Z19WWPMailTemplateName) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPMAILTEMPLATENAME");
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailTemplateName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPMailTemplateName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
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
         if ( StringUtil.StrCmp(A19WWPMailTemplateName, Z19WWPMailTemplateName) != 0 )
         {
            A19WWPMailTemplateName = Z19WWPMailTemplateName;
            AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPMAILTEMPLATENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPMAILTEMPLATENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound9 != 0 )
            {
               ScanNext099( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A19WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z79WWPMailTemplateDescription, T00092_A79WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z80WWPMailTemplateSubject, T00092_A80WWPMailTemplateSubject[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z79WWPMailTemplateDescription, T00092_A79WWPMailTemplateDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mailtemplate:[seudo value changed for attri]"+"WWPMailTemplateDescription");
                  GXUtil.WriteLogRaw("Old: ",Z79WWPMailTemplateDescription);
                  GXUtil.WriteLogRaw("Current: ",T00092_A79WWPMailTemplateDescription[0]);
               }
               if ( StringUtil.StrCmp(Z80WWPMailTemplateSubject, T00092_A80WWPMailTemplateSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mailtemplate:[seudo value changed for attri]"+"WWPMailTemplateSubject");
                  GXUtil.WriteLogRaw("Old: ",Z80WWPMailTemplateSubject);
                  GXUtil.WriteLogRaw("Current: ",T00092_A80WWPMailTemplateSubject[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00098 */
                     pr_default.execute(6, new Object[] {A19WWPMailTemplateName, A79WWPMailTemplateDescription, A80WWPMailTemplateSubject, A65WWPMailTemplateBody, A66WWPMailTemplateSenderAddress, A67WWPMailTemplateSenderName});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption090( ) ;
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00099 */
                     pr_default.execute(7, new Object[] {A79WWPMailTemplateDescription, A80WWPMailTemplateSubject, A65WWPMailTemplateBody, A66WWPMailTemplateSenderAddress, A67WWPMailTemplateSenderName, A19WWPMailTemplateName});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000910 */
                  pr_default.execute(8, new Object[] {A19WWPMailTemplateName});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound9 == 0 )
                        {
                           InitAll099( ) ;
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
                        ResetCaption090( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("wwpbaseobjects.mail.wwp_mailtemplate",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Using cursor T000911 */
         pr_default.execute(9);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A19WWPMailTemplateName = T000911_A19WWPMailTemplateName[0];
            AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
            A19WWPMailTemplateName = T000911_A19WWPMailTemplateName[0];
            AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtWWPMailTemplateName_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateName_Enabled), 5, 0), true);
         edtWWPMailTemplateDescription_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateDescription_Enabled), 5, 0), true);
         edtWWPMailTemplateSubject_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSubject_Enabled), 5, 0), true);
         edtWWPMailTemplateBody_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateBody_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateBody_Enabled), 5, 0), true);
         edtWWPMailTemplateSenderAddress_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSenderAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSenderAddress_Enabled), 5, 0), true);
         edtWWPMailTemplateSenderName_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSenderName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSenderName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815481423", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.wwp_mailtemplate.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z19WWPMailTemplateName", Z19WWPMailTemplateName);
         GxWebStd.gx_hidden_field( context, "Z79WWPMailTemplateDescription", Z79WWPMailTemplateDescription);
         GxWebStd.gx_hidden_field( context, "Z80WWPMailTemplateSubject", Z80WWPMailTemplateSubject);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("wwpbaseobjects.mail.wwp_mailtemplate.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.WWP_MailTemplate" ;
      }

      public override string GetPgmdesc( )
      {
         return "Mail Template" ;
      }

      protected void InitializeNonKey099( )
      {
         A79WWPMailTemplateDescription = "";
         AssignAttri("", false, "A79WWPMailTemplateDescription", A79WWPMailTemplateDescription);
         A80WWPMailTemplateSubject = "";
         AssignAttri("", false, "A80WWPMailTemplateSubject", A80WWPMailTemplateSubject);
         A65WWPMailTemplateBody = "";
         AssignAttri("", false, "A65WWPMailTemplateBody", A65WWPMailTemplateBody);
         A66WWPMailTemplateSenderAddress = "";
         AssignAttri("", false, "A66WWPMailTemplateSenderAddress", A66WWPMailTemplateSenderAddress);
         A67WWPMailTemplateSenderName = "";
         AssignAttri("", false, "A67WWPMailTemplateSenderName", A67WWPMailTemplateSenderName);
         Z79WWPMailTemplateDescription = "";
         Z80WWPMailTemplateSubject = "";
      }

      protected void InitAll099( )
      {
         A19WWPMailTemplateName = "";
         AssignAttri("", false, "A19WWPMailTemplateName", A19WWPMailTemplateName);
         InitializeNonKey099( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815481433", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/wwp_mailtemplate.js", "?202142815481434", false, true);
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
         edtWWPMailTemplateName_Internalname = "WWPMAILTEMPLATENAME";
         edtWWPMailTemplateDescription_Internalname = "WWPMAILTEMPLATEDESCRIPTION";
         edtWWPMailTemplateSubject_Internalname = "WWPMAILTEMPLATESUBJECT";
         edtWWPMailTemplateBody_Internalname = "WWPMAILTEMPLATEBODY";
         edtWWPMailTemplateSenderAddress_Internalname = "WWPMAILTEMPLATESENDERADDRESS";
         edtWWPMailTemplateSenderName_Internalname = "WWPMAILTEMPLATESENDERNAME";
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
         Form.Caption = "Mail Template";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPMailTemplateSenderName_Enabled = 1;
         edtWWPMailTemplateSenderAddress_Enabled = 1;
         edtWWPMailTemplateBody_Enabled = 1;
         edtWWPMailTemplateSubject_Jsonclick = "";
         edtWWPMailTemplateSubject_Enabled = 1;
         edtWWPMailTemplateDescription_Jsonclick = "";
         edtWWPMailTemplateDescription_Enabled = 1;
         edtWWPMailTemplateName_Jsonclick = "";
         edtWWPMailTemplateName_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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

      public void Valid_Wwpmailtemplatename( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A79WWPMailTemplateDescription", A79WWPMailTemplateDescription);
         AssignAttri("", false, "A80WWPMailTemplateSubject", A80WWPMailTemplateSubject);
         AssignAttri("", false, "A65WWPMailTemplateBody", A65WWPMailTemplateBody);
         AssignAttri("", false, "A66WWPMailTemplateSenderAddress", A66WWPMailTemplateSenderAddress);
         AssignAttri("", false, "A67WWPMailTemplateSenderName", A67WWPMailTemplateSenderName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z19WWPMailTemplateName", Z19WWPMailTemplateName);
         GxWebStd.gx_hidden_field( context, "Z79WWPMailTemplateDescription", Z79WWPMailTemplateDescription);
         GxWebStd.gx_hidden_field( context, "Z80WWPMailTemplateSubject", Z80WWPMailTemplateSubject);
         GxWebStd.gx_hidden_field( context, "Z65WWPMailTemplateBody", Z65WWPMailTemplateBody);
         GxWebStd.gx_hidden_field( context, "Z66WWPMailTemplateSenderAddress", Z66WWPMailTemplateSenderAddress);
         GxWebStd.gx_hidden_field( context, "Z67WWPMailTemplateSenderName", Z67WWPMailTemplateSenderName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("AFTER TRN","{handler:'E12092',iparms:[]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILTEMPLATENAME","{handler:'Valid_Wwpmailtemplatename',iparms:[{av:'A19WWPMailTemplateName',fld:'WWPMAILTEMPLATENAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_WWPMAILTEMPLATENAME",",oparms:[{av:'A79WWPMailTemplateDescription',fld:'WWPMAILTEMPLATEDESCRIPTION',pic:''},{av:'A80WWPMailTemplateSubject',fld:'WWPMAILTEMPLATESUBJECT',pic:''},{av:'A65WWPMailTemplateBody',fld:'WWPMAILTEMPLATEBODY',pic:''},{av:'A66WWPMailTemplateSenderAddress',fld:'WWPMAILTEMPLATESENDERADDRESS',pic:''},{av:'A67WWPMailTemplateSenderName',fld:'WWPMAILTEMPLATESENDERNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z19WWPMailTemplateName'},{av:'Z79WWPMailTemplateDescription'},{av:'Z80WWPMailTemplateSubject'},{av:'Z65WWPMailTemplateBody'},{av:'Z66WWPMailTemplateSenderAddress'},{av:'Z67WWPMailTemplateSenderName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z19WWPMailTemplateName = "";
         Z79WWPMailTemplateDescription = "";
         Z80WWPMailTemplateSubject = "";
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
         A19WWPMailTemplateName = "";
         A79WWPMailTemplateDescription = "";
         A80WWPMailTemplateSubject = "";
         A65WWPMailTemplateBody = "";
         A66WWPMailTemplateSenderAddress = "";
         A67WWPMailTemplateSenderName = "";
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
         Z65WWPMailTemplateBody = "";
         Z66WWPMailTemplateSenderAddress = "";
         Z67WWPMailTemplateSenderName = "";
         T00094_A19WWPMailTemplateName = new string[] {""} ;
         T00094_A79WWPMailTemplateDescription = new string[] {""} ;
         T00094_A80WWPMailTemplateSubject = new string[] {""} ;
         T00094_A65WWPMailTemplateBody = new string[] {""} ;
         T00094_A66WWPMailTemplateSenderAddress = new string[] {""} ;
         T00094_A67WWPMailTemplateSenderName = new string[] {""} ;
         T00095_A19WWPMailTemplateName = new string[] {""} ;
         T00093_A19WWPMailTemplateName = new string[] {""} ;
         T00093_A79WWPMailTemplateDescription = new string[] {""} ;
         T00093_A80WWPMailTemplateSubject = new string[] {""} ;
         T00093_A65WWPMailTemplateBody = new string[] {""} ;
         T00093_A66WWPMailTemplateSenderAddress = new string[] {""} ;
         T00093_A67WWPMailTemplateSenderName = new string[] {""} ;
         sMode9 = "";
         T00096_A19WWPMailTemplateName = new string[] {""} ;
         T00097_A19WWPMailTemplateName = new string[] {""} ;
         T00092_A19WWPMailTemplateName = new string[] {""} ;
         T00092_A79WWPMailTemplateDescription = new string[] {""} ;
         T00092_A80WWPMailTemplateSubject = new string[] {""} ;
         T00092_A65WWPMailTemplateBody = new string[] {""} ;
         T00092_A66WWPMailTemplateSenderAddress = new string[] {""} ;
         T00092_A67WWPMailTemplateSenderName = new string[] {""} ;
         T000911_A19WWPMailTemplateName = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ19WWPMailTemplateName = "";
         ZZ79WWPMailTemplateDescription = "";
         ZZ80WWPMailTemplateSubject = "";
         ZZ65WWPMailTemplateBody = "";
         ZZ66WWPMailTemplateSenderAddress = "";
         ZZ67WWPMailTemplateSenderName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate__default(),
            new Object[][] {
                new Object[] {
               T00092_A19WWPMailTemplateName, T00092_A79WWPMailTemplateDescription, T00092_A80WWPMailTemplateSubject, T00092_A65WWPMailTemplateBody, T00092_A66WWPMailTemplateSenderAddress, T00092_A67WWPMailTemplateSenderName
               }
               , new Object[] {
               T00093_A19WWPMailTemplateName, T00093_A79WWPMailTemplateDescription, T00093_A80WWPMailTemplateSubject, T00093_A65WWPMailTemplateBody, T00093_A66WWPMailTemplateSenderAddress, T00093_A67WWPMailTemplateSenderName
               }
               , new Object[] {
               T00094_A19WWPMailTemplateName, T00094_A79WWPMailTemplateDescription, T00094_A80WWPMailTemplateSubject, T00094_A65WWPMailTemplateBody, T00094_A66WWPMailTemplateSenderAddress, T00094_A67WWPMailTemplateSenderName
               }
               , new Object[] {
               T00095_A19WWPMailTemplateName
               }
               , new Object[] {
               T00096_A19WWPMailTemplateName
               }
               , new Object[] {
               T00097_A19WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000911_A19WWPMailTemplateName
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
      private short GX_JID ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPMailTemplateName_Enabled ;
      private int edtWWPMailTemplateDescription_Enabled ;
      private int edtWWPMailTemplateSubject_Enabled ;
      private int edtWWPMailTemplateBody_Enabled ;
      private int edtWWPMailTemplateSenderAddress_Enabled ;
      private int edtWWPMailTemplateSenderName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPMailTemplateName_Internalname ;
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
      private string edtWWPMailTemplateName_Jsonclick ;
      private string edtWWPMailTemplateDescription_Internalname ;
      private string edtWWPMailTemplateDescription_Jsonclick ;
      private string edtWWPMailTemplateSubject_Internalname ;
      private string edtWWPMailTemplateSubject_Jsonclick ;
      private string edtWWPMailTemplateBody_Internalname ;
      private string edtWWPMailTemplateSenderAddress_Internalname ;
      private string edtWWPMailTemplateSenderName_Internalname ;
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
      private string sMode9 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A65WWPMailTemplateBody ;
      private string A66WWPMailTemplateSenderAddress ;
      private string A67WWPMailTemplateSenderName ;
      private string Z65WWPMailTemplateBody ;
      private string Z66WWPMailTemplateSenderAddress ;
      private string Z67WWPMailTemplateSenderName ;
      private string ZZ65WWPMailTemplateBody ;
      private string ZZ66WWPMailTemplateSenderAddress ;
      private string ZZ67WWPMailTemplateSenderName ;
      private string Z19WWPMailTemplateName ;
      private string Z79WWPMailTemplateDescription ;
      private string Z80WWPMailTemplateSubject ;
      private string A19WWPMailTemplateName ;
      private string A79WWPMailTemplateDescription ;
      private string A80WWPMailTemplateSubject ;
      private string ZZ19WWPMailTemplateName ;
      private string ZZ79WWPMailTemplateDescription ;
      private string ZZ80WWPMailTemplateSubject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00094_A19WWPMailTemplateName ;
      private string[] T00094_A79WWPMailTemplateDescription ;
      private string[] T00094_A80WWPMailTemplateSubject ;
      private string[] T00094_A65WWPMailTemplateBody ;
      private string[] T00094_A66WWPMailTemplateSenderAddress ;
      private string[] T00094_A67WWPMailTemplateSenderName ;
      private string[] T00095_A19WWPMailTemplateName ;
      private string[] T00093_A19WWPMailTemplateName ;
      private string[] T00093_A79WWPMailTemplateDescription ;
      private string[] T00093_A80WWPMailTemplateSubject ;
      private string[] T00093_A65WWPMailTemplateBody ;
      private string[] T00093_A66WWPMailTemplateSenderAddress ;
      private string[] T00093_A67WWPMailTemplateSenderName ;
      private string[] T00096_A19WWPMailTemplateName ;
      private string[] T00097_A19WWPMailTemplateName ;
      private string[] T00092_A19WWPMailTemplateName ;
      private string[] T00092_A79WWPMailTemplateDescription ;
      private string[] T00092_A80WWPMailTemplateSubject ;
      private string[] T00092_A65WWPMailTemplateBody ;
      private string[] T00092_A66WWPMailTemplateSenderAddress ;
      private string[] T00092_A67WWPMailTemplateSenderName ;
      private string[] T000911_A19WWPMailTemplateName ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_mailtemplate__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
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
        Object[] prmT00094;
        prmT00094 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT00095;
        prmT00095 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT00093;
        prmT00093 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT00096;
        prmT00096 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT00097;
        prmT00097 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT00092;
        prmT00092 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT00098;
        prmT00098 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPMailTemplateDescription",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPMailTemplateSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailTemplateBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderName",SqlDbType.NVarChar,2097152,0}
        };
        Object[] prmT00099;
        prmT00099 = new Object[] {
        new Object[] {"@WWPMailTemplateDescription",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPMailTemplateSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailTemplateBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateSenderName",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000910;
        prmT000910 = new Object[] {
        new Object[] {"@WWPMailTemplateName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmT000911;
        prmT000911 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00092", "SELECT [WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName] FROM [WWP_MailTemplate] WITH (UPDLOCK) WHERE [WWPMailTemplateName] = @WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00093", "SELECT [WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName] FROM [WWP_MailTemplate] WHERE [WWPMailTemplateName] = @WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00094", "SELECT TM1.[WWPMailTemplateName], TM1.[WWPMailTemplateDescription], TM1.[WWPMailTemplateSubject], TM1.[WWPMailTemplateBody], TM1.[WWPMailTemplateSenderAddress], TM1.[WWPMailTemplateSenderName] FROM [WWP_MailTemplate] TM1 WHERE TM1.[WWPMailTemplateName] = @WWPMailTemplateName ORDER BY TM1.[WWPMailTemplateName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00095", "SELECT [WWPMailTemplateName] FROM [WWP_MailTemplate] WHERE [WWPMailTemplateName] = @WWPMailTemplateName  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00096", "SELECT TOP 1 [WWPMailTemplateName] FROM [WWP_MailTemplate] WHERE ( [WWPMailTemplateName] > @WWPMailTemplateName) ORDER BY [WWPMailTemplateName]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00097", "SELECT TOP 1 [WWPMailTemplateName] FROM [WWP_MailTemplate] WHERE ( [WWPMailTemplateName] < @WWPMailTemplateName) ORDER BY [WWPMailTemplateName] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00098", "INSERT INTO [WWP_MailTemplate]([WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName]) VALUES(@WWPMailTemplateName, @WWPMailTemplateDescription, @WWPMailTemplateSubject, @WWPMailTemplateBody, @WWPMailTemplateSenderAddress, @WWPMailTemplateSenderName)", GxErrorMask.GX_NOMASK,prmT00098)
           ,new CursorDef("T00099", "UPDATE [WWP_MailTemplate] SET [WWPMailTemplateDescription]=@WWPMailTemplateDescription, [WWPMailTemplateSubject]=@WWPMailTemplateSubject, [WWPMailTemplateBody]=@WWPMailTemplateBody, [WWPMailTemplateSenderAddress]=@WWPMailTemplateSenderAddress, [WWPMailTemplateSenderName]=@WWPMailTemplateSenderName  WHERE [WWPMailTemplateName] = @WWPMailTemplateName", GxErrorMask.GX_NOMASK,prmT00099)
           ,new CursorDef("T000910", "DELETE FROM [WWP_MailTemplate]  WHERE [WWPMailTemplateName] = @WWPMailTemplateName", GxErrorMask.GX_NOMASK,prmT000910)
           ,new CursorDef("T000911", "SELECT [WWPMailTemplateName] FROM [WWP_MailTemplate] ORDER BY [WWPMailTemplateName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,100, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              return;
           case 1 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 4 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 5 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 9 :
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 2 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
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
              return;
           case 8 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
     }
  }

}

}
