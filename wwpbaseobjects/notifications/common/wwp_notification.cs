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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"WWPUSEREXTENDEDFULLNAME") == 0 )
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
            GX3ASAWWPUSEREXTENDEDFULLNAME088( A1WWPUserExtendedId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A14WWPNotificationDefinitionId = (long)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."));
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A14WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
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
            gxLoad_8( A1WWPUserExtendedId) ;
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
            Form.Meta.addItem("description", "Notification", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_notification( IGxContext context )
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
         chkWWPNotificationIsRead = new GXCheckbox();
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
            return "wwp_notification_Execute" ;
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
         A73WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A73WWPNotificationIsRead));
         AssignAttri("", false, "A73WWPNotificationIsRead", A73WWPNotificationIsRead);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Notification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ",", "")), ((edtWWPNotificationId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, "Notification Definition Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ",", "")), ((edtWWPNotificationDefinitionId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A14WWPNotificationDefinitionId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A14WWPNotificationDefinitionId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A53WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A53WWPNotificationDefinitionName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A37WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationIcon_Internalname, "Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationIcon_Internalname, A68WWPNotificationIcon, StringUtil.RTrim( context.localUtil.Format( A68WWPNotificationIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationIcon_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationTitle_Internalname, "Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationTitle_Internalname, A69WWPNotificationTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", 0, 1, edtWWPNotificationTitle_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationShortDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationShortDescription_Internalname, "Short Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationShortDescription_Internalname, A70WWPNotificationShortDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtWWPNotificationShortDescription_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationLink_Internalname, "Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationLink_Internalname, A71WWPNotificationLink, StringUtil.RTrim( context.localUtil.Format( A71WWPNotificationLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", A71WWPNotificationLink, "_blank", "", "", edtWWPNotificationLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkWWPNotificationIsRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationIsRead_Internalname, "Is Read", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationIsRead_Internalname, StringUtil.BoolToStr( A73WWPNotificationIsRead), "", "Is Read", 1, chkWWPNotificationIsRead.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,68);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPUserExtendedFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "User Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A2WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A2WWPUserExtendedFullName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, "Metadata", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A54WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
            Z16WWPNotificationId = (long)(context.localUtil.CToN( cgiGet( "Z16WWPNotificationId"), ",", "."));
            Z37WWPNotificationCreated = context.localUtil.CToT( cgiGet( "Z37WWPNotificationCreated"), 0);
            Z68WWPNotificationIcon = cgiGet( "Z68WWPNotificationIcon");
            Z69WWPNotificationTitle = cgiGet( "Z69WWPNotificationTitle");
            Z70WWPNotificationShortDescription = cgiGet( "Z70WWPNotificationShortDescription");
            Z71WWPNotificationLink = cgiGet( "Z71WWPNotificationLink");
            Z73WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( "Z73WWPNotificationIsRead"));
            Z14WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( "Z14WWPNotificationDefinitionId"), ",", "."));
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
            /* Read variables values. */
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A14WWPNotificationDefinitionId = 0;
               AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            }
            else
            {
               A14WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", "."));
               AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            }
            A53WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPNotificationCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Notification Created Date"}), 1, "WWPNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A37WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
               AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            A68WWPNotificationIcon = cgiGet( edtWWPNotificationIcon_Internalname);
            AssignAttri("", false, "A68WWPNotificationIcon", A68WWPNotificationIcon);
            A69WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
            AssignAttri("", false, "A69WWPNotificationTitle", A69WWPNotificationTitle);
            A70WWPNotificationShortDescription = cgiGet( edtWWPNotificationShortDescription_Internalname);
            AssignAttri("", false, "A70WWPNotificationShortDescription", A70WWPNotificationShortDescription);
            A71WWPNotificationLink = cgiGet( edtWWPNotificationLink_Internalname);
            AssignAttri("", false, "A71WWPNotificationLink", A71WWPNotificationLink);
            A73WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( chkWWPNotificationIsRead_Internalname));
            AssignAttri("", false, "A73WWPNotificationIsRead", A73WWPNotificationIsRead);
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A54WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n54WWPNotificationMetadata = false;
            AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
            n54WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A54WWPNotificationMetadata)) ? true : false);
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
               A16WWPNotificationId = (long)(NumberUtil.Val( GetPar( "WWPNotificationId"), "."));
               n16WWPNotificationId = false;
               AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
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
               InitAll088( ) ;
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
         DisableAttributes088( ) ;
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

      protected void ResetCaption080( )
      {
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z37WWPNotificationCreated = T00083_A37WWPNotificationCreated[0];
               Z68WWPNotificationIcon = T00083_A68WWPNotificationIcon[0];
               Z69WWPNotificationTitle = T00083_A69WWPNotificationTitle[0];
               Z70WWPNotificationShortDescription = T00083_A70WWPNotificationShortDescription[0];
               Z71WWPNotificationLink = T00083_A71WWPNotificationLink[0];
               Z73WWPNotificationIsRead = T00083_A73WWPNotificationIsRead[0];
               Z14WWPNotificationDefinitionId = T00083_A14WWPNotificationDefinitionId[0];
               Z1WWPUserExtendedId = T00083_A1WWPUserExtendedId[0];
            }
            else
            {
               Z37WWPNotificationCreated = A37WWPNotificationCreated;
               Z68WWPNotificationIcon = A68WWPNotificationIcon;
               Z69WWPNotificationTitle = A69WWPNotificationTitle;
               Z70WWPNotificationShortDescription = A70WWPNotificationShortDescription;
               Z71WWPNotificationLink = A71WWPNotificationLink;
               Z73WWPNotificationIsRead = A73WWPNotificationIsRead;
               Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z16WWPNotificationId = A16WWPNotificationId;
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
            Z68WWPNotificationIcon = A68WWPNotificationIcon;
            Z69WWPNotificationTitle = A69WWPNotificationTitle;
            Z70WWPNotificationShortDescription = A70WWPNotificationShortDescription;
            Z71WWPNotificationLink = A71WWPNotificationLink;
            Z73WWPNotificationIsRead = A73WWPNotificationIsRead;
            Z54WWPNotificationMetadata = A54WWPNotificationMetadata;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
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
         if ( IsIns( )  && (DateTime.MinValue==A37WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
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

      protected void Load088( )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound8 = 1;
            A53WWPNotificationDefinitionName = T00086_A53WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            A37WWPNotificationCreated = T00086_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A68WWPNotificationIcon = T00086_A68WWPNotificationIcon[0];
            AssignAttri("", false, "A68WWPNotificationIcon", A68WWPNotificationIcon);
            A69WWPNotificationTitle = T00086_A69WWPNotificationTitle[0];
            AssignAttri("", false, "A69WWPNotificationTitle", A69WWPNotificationTitle);
            A70WWPNotificationShortDescription = T00086_A70WWPNotificationShortDescription[0];
            AssignAttri("", false, "A70WWPNotificationShortDescription", A70WWPNotificationShortDescription);
            A71WWPNotificationLink = T00086_A71WWPNotificationLink[0];
            AssignAttri("", false, "A71WWPNotificationLink", A71WWPNotificationLink);
            A73WWPNotificationIsRead = T00086_A73WWPNotificationIsRead[0];
            AssignAttri("", false, "A73WWPNotificationIsRead", A73WWPNotificationIsRead);
            A54WWPNotificationMetadata = T00086_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = T00086_n54WWPNotificationMetadata[0];
            AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
            A14WWPNotificationDefinitionId = T00086_A14WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T00086_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00086_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            ZM088( -6) ;
         }
         pr_default.close(4);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A53WWPNotificationDefinitionName = T00084_A53WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A37WWPNotificationCreated) || ( A37WWPNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Notification Created Date fora do intervalo", "OutOfRange", 1, "WWPNOTIFICATIONCREATED");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationCreated_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A71WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de Notification Link não coincide com o padrão especificado", "OutOfRange", 1, "WWPNOTIFICATIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         nIsDirty_8 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( long A14WWPNotificationDefinitionId )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A53WWPNotificationDefinitionName = T00087_A53WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A53WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_8( string A1WWPUserExtendedId )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(6) == 101) )
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
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey088( )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 6) ;
            RcdFound8 = 1;
            A16WWPNotificationId = T00083_A16WWPNotificationId[0];
            n16WWPNotificationId = T00083_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            A37WWPNotificationCreated = T00083_A37WWPNotificationCreated[0];
            AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A68WWPNotificationIcon = T00083_A68WWPNotificationIcon[0];
            AssignAttri("", false, "A68WWPNotificationIcon", A68WWPNotificationIcon);
            A69WWPNotificationTitle = T00083_A69WWPNotificationTitle[0];
            AssignAttri("", false, "A69WWPNotificationTitle", A69WWPNotificationTitle);
            A70WWPNotificationShortDescription = T00083_A70WWPNotificationShortDescription[0];
            AssignAttri("", false, "A70WWPNotificationShortDescription", A70WWPNotificationShortDescription);
            A71WWPNotificationLink = T00083_A71WWPNotificationLink[0];
            AssignAttri("", false, "A71WWPNotificationLink", A71WWPNotificationLink);
            A73WWPNotificationIsRead = T00083_A73WWPNotificationIsRead[0];
            AssignAttri("", false, "A73WWPNotificationIsRead", A73WWPNotificationIsRead);
            A54WWPNotificationMetadata = T00083_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = T00083_n54WWPNotificationMetadata[0];
            AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
            A14WWPNotificationDefinitionId = T00083_A14WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T00083_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00083_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            Z16WWPNotificationId = A16WWPNotificationId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000810_A16WWPNotificationId[0] < A16WWPNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000810_A16WWPNotificationId[0] > A16WWPNotificationId ) ) )
            {
               A16WWPNotificationId = T000810_A16WWPNotificationId[0];
               n16WWPNotificationId = T000810_n16WWPNotificationId[0];
               AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000811_A16WWPNotificationId[0] > A16WWPNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000811_A16WWPNotificationId[0] < A16WWPNotificationId ) ) )
            {
               A16WWPNotificationId = T000811_A16WWPNotificationId[0];
               n16WWPNotificationId = T000811_n16WWPNotificationId[0];
               AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A16WWPNotificationId != Z16WWPNotificationId )
               {
                  A16WWPNotificationId = Z16WWPNotificationId;
                  n16WWPNotificationId = false;
                  AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update088( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A16WWPNotificationId != Z16WWPNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert088( ) ;
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
         if ( A16WWPNotificationId != Z16WWPNotificationId )
         {
            A16WWPNotificationId = Z16WWPNotificationId;
            n16WWPNotificationId = false;
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext088( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z37WWPNotificationCreated != T00082_A37WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z68WWPNotificationIcon, T00082_A68WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z69WWPNotificationTitle, T00082_A69WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z70WWPNotificationShortDescription, T00082_A70WWPNotificationShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z71WWPNotificationLink, T00082_A71WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z73WWPNotificationIsRead != T00082_A73WWPNotificationIsRead[0] ) || ( Z14WWPNotificationDefinitionId != T00082_A14WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00082_A1WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z37WWPNotificationCreated != T00082_A37WWPNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z37WWPNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T00082_A37WWPNotificationCreated[0]);
               }
               if ( StringUtil.StrCmp(Z68WWPNotificationIcon, T00082_A68WWPNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z68WWPNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T00082_A68WWPNotificationIcon[0]);
               }
               if ( StringUtil.StrCmp(Z69WWPNotificationTitle, T00082_A69WWPNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z69WWPNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T00082_A69WWPNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z70WWPNotificationShortDescription, T00082_A70WWPNotificationShortDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationShortDescription");
                  GXUtil.WriteLogRaw("Old: ",Z70WWPNotificationShortDescription);
                  GXUtil.WriteLogRaw("Current: ",T00082_A70WWPNotificationShortDescription[0]);
               }
               if ( StringUtil.StrCmp(Z71WWPNotificationLink, T00082_A71WWPNotificationLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationLink");
                  GXUtil.WriteLogRaw("Old: ",Z71WWPNotificationLink);
                  GXUtil.WriteLogRaw("Current: ",T00082_A71WWPNotificationLink[0]);
               }
               if ( Z73WWPNotificationIsRead != T00082_A73WWPNotificationIsRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIsRead");
                  GXUtil.WriteLogRaw("Old: ",Z73WWPNotificationIsRead);
                  GXUtil.WriteLogRaw("Current: ",T00082_A73WWPNotificationIsRead[0]);
               }
               if ( Z14WWPNotificationDefinitionId != T00082_A14WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z14WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A14WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00082_A1WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z1WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A1WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         if ( ! IsAuthorized("wwp_notification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A37WWPNotificationCreated, A68WWPNotificationIcon, A69WWPNotificationTitle, A70WWPNotificationShortDescription, A71WWPNotificationLink, A73WWPNotificationIsRead, n54WWPNotificationMetadata, A54WWPNotificationMetadata, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A16WWPNotificationId = T000812_A16WWPNotificationId[0];
                     n16WWPNotificationId = T000812_n16WWPNotificationId[0];
                     AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption080( ) ;
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         if ( ! IsAuthorized("wwp_notification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000813 */
                     pr_default.execute(11, new Object[] {A37WWPNotificationCreated, A68WWPNotificationIcon, A69WWPNotificationTitle, A70WWPNotificationShortDescription, A71WWPNotificationLink, A73WWPNotificationIsRead, n54WWPNotificationMetadata, A54WWPNotificationMetadata, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, n16WWPNotificationId, A16WWPNotificationId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption080( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwp_notification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000814 */
                  pr_default.execute(12, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll088( ) ;
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
                        ResetCaption080( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000815 */
            pr_default.execute(13, new Object[] {A14WWPNotificationDefinitionId});
            A53WWPNotificationDefinitionName = T000815_A53WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            pr_default.close(13);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000816 */
            pr_default.execute(14, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000817 */
            pr_default.execute(15, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000818 */
            pr_default.execute(16, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SMS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Using cursor T000819 */
         pr_default.execute(17);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound8 = 1;
            A16WWPNotificationId = T000819_A16WWPNotificationId[0];
            n16WWPNotificationId = T000819_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound8 = 1;
            A16WWPNotificationId = T000819_A16WWPNotificationId[0];
            n16WWPNotificationId = T000819_n16WWPNotificationId[0];
            AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) )
         {
            A1WWPUserExtendedId = "";
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            n1WWPUserExtendedId = true;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         }
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationIcon_Enabled), 5, 0), true);
         edtWWPNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationShortDescription_Enabled = 0;
         AssignProp("", false, edtWWPNotificationShortDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationShortDescription_Enabled), 5, 0), true);
         edtWWPNotificationLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Enabled), 5, 0), true);
         chkWWPNotificationIsRead.Enabled = 0;
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationIsRead.Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815481970", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z37WWPNotificationCreated", context.localUtil.TToC( Z37WWPNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z68WWPNotificationIcon", Z68WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z69WWPNotificationTitle", Z69WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z70WWPNotificationShortDescription", Z70WWPNotificationShortDescription);
         GxWebStd.gx_hidden_field( context, "Z71WWPNotificationLink", Z71WWPNotificationLink);
         GxWebStd.gx_boolean_hidden_field( context, "Z73WWPNotificationIsRead", Z73WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "Z14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14WWPNotificationDefinitionId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_Notification" ;
      }

      public override string GetPgmdesc( )
      {
         return "Notification" ;
      }

      protected void InitializeNonKey088( )
      {
         A2WWPUserExtendedFullName = "";
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A14WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
         A53WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         A68WWPNotificationIcon = "";
         AssignAttri("", false, "A68WWPNotificationIcon", A68WWPNotificationIcon);
         A69WWPNotificationTitle = "";
         AssignAttri("", false, "A69WWPNotificationTitle", A69WWPNotificationTitle);
         A70WWPNotificationShortDescription = "";
         AssignAttri("", false, "A70WWPNotificationShortDescription", A70WWPNotificationShortDescription);
         A71WWPNotificationLink = "";
         AssignAttri("", false, "A71WWPNotificationLink", A71WWPNotificationLink);
         A73WWPNotificationIsRead = false;
         AssignAttri("", false, "A73WWPNotificationIsRead", A73WWPNotificationIsRead);
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
         A54WWPNotificationMetadata = "";
         n54WWPNotificationMetadata = false;
         AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
         n54WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A54WWPNotificationMetadata)) ? true : false);
         A37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z68WWPNotificationIcon = "";
         Z69WWPNotificationTitle = "";
         Z70WWPNotificationShortDescription = "";
         Z71WWPNotificationLink = "";
         Z73WWPNotificationIsRead = false;
         Z14WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll088( )
      {
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         AssignAttri("", false, "A16WWPNotificationId", StringUtil.LTrimStr( (decimal)(A16WWPNotificationId), 10, 0));
         InitializeNonKey088( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A37WWPNotificationCreated = i37WWPNotificationCreated;
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815481987", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notification.js", "?202142815481989", false, true);
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
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationIcon_Internalname = "WWPNOTIFICATIONICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtWWPNotificationShortDescription_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTION";
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK";
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
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
         Form.Caption = "Notification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationMetadata_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         chkWWPNotificationIsRead.Enabled = 1;
         edtWWPNotificationLink_Jsonclick = "";
         edtWWPNotificationLink_Enabled = 1;
         edtWWPNotificationShortDescription_Enabled = 1;
         edtWWPNotificationTitle_Enabled = 1;
         edtWWPNotificationIcon_Jsonclick = "";
         edtWWPNotificationIcon_Enabled = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
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

      protected void GX3ASAWWPUSEREXTENDEDFULLNAME088( string A1WWPUserExtendedId )
      {
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2WWPUserExtendedFullName)+"\"") ;
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
         chkWWPNotificationIsRead.Name = "WWPNOTIFICATIONISREAD";
         chkWWPNotificationIsRead.WebTags = "";
         chkWWPNotificationIsRead.Caption = "";
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "TitleCaption", chkWWPNotificationIsRead.Caption, true);
         chkWWPNotificationIsRead.CheckedValue = "false";
         A73WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A73WWPNotificationIsRead));
         AssignAttri("", false, "A73WWPNotificationIsRead", A73WWPNotificationIsRead);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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

      public void Valid_Wwpnotificationid( )
      {
         n16WWPNotificationId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A73WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A73WWPNotificationIsRead));
         /*  Sending validation outputs */
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A37WWPNotificationCreated", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A68WWPNotificationIcon", A68WWPNotificationIcon);
         AssignAttri("", false, "A69WWPNotificationTitle", A69WWPNotificationTitle);
         AssignAttri("", false, "A70WWPNotificationShortDescription", A70WWPNotificationShortDescription);
         AssignAttri("", false, "A71WWPNotificationLink", A71WWPNotificationLink);
         AssignAttri("", false, "A73WWPNotificationIsRead", A73WWPNotificationIsRead);
         AssignAttri("", false, "A1WWPUserExtendedId", StringUtil.RTrim( A1WWPUserExtendedId));
         AssignAttri("", false, "A54WWPNotificationMetadata", A54WWPNotificationMetadata);
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z16WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37WWPNotificationCreated", context.localUtil.TToC( Z37WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z68WWPNotificationIcon", Z68WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z69WWPNotificationTitle", Z69WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z70WWPNotificationShortDescription", Z70WWPNotificationShortDescription);
         GxWebStd.gx_hidden_field( context, "Z71WWPNotificationLink", Z71WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, "Z73WWPNotificationIsRead", StringUtil.BoolToStr( Z73WWPNotificationIsRead));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z54WWPNotificationMetadata", Z54WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z53WWPNotificationDefinitionName", Z53WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z2WWPUserExtendedFullName", Z2WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000815 */
         pr_default.execute(13, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A53WWPNotificationDefinitionName = T000815_A53WWPNotificationDefinitionName[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n1WWPUserExtendedId = false;
         /* Using cursor T000820 */
         pr_default.execute(18, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         pr_default.close(18);
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A68WWPNotificationIcon',fld:'WWPNOTIFICATIONICON',pic:''},{av:'A69WWPNotificationTitle',fld:'WWPNOTIFICATIONTITLE',pic:''},{av:'A70WWPNotificationShortDescription',fld:'WWPNOTIFICATIONSHORTDESCRIPTION',pic:''},{av:'A71WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A54WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z16WWPNotificationId'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z37WWPNotificationCreated'},{av:'Z68WWPNotificationIcon'},{av:'Z69WWPNotificationTitle'},{av:'Z70WWPNotificationShortDescription'},{av:'Z71WWPNotificationLink'},{av:'Z73WWPNotificationIsRead'},{av:'Z1WWPUserExtendedId'},{av:'Z54WWPNotificationMetadata'},{av:'Z53WWPNotificationDefinitionName'},{av:'Z2WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONCREATED","{handler:'Valid_Wwpnotificationcreated',iparms:[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONCREATED",",oparms:[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK","{handler:'Valid_Wwpnotificationlink',iparms:[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK",",oparms:[{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
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
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z68WWPNotificationIcon = "";
         Z69WWPNotificationTitle = "";
         Z70WWPNotificationShortDescription = "";
         Z71WWPNotificationLink = "";
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
         A53WWPNotificationDefinitionName = "";
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A68WWPNotificationIcon = "";
         A69WWPNotificationTitle = "";
         A70WWPNotificationShortDescription = "";
         A71WWPNotificationLink = "";
         A2WWPUserExtendedFullName = "";
         A54WWPNotificationMetadata = "";
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
         Z54WWPNotificationMetadata = "";
         Z53WWPNotificationDefinitionName = "";
         T00086_A16WWPNotificationId = new long[1] ;
         T00086_n16WWPNotificationId = new bool[] {false} ;
         T00086_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00086_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00086_A68WWPNotificationIcon = new string[] {""} ;
         T00086_A69WWPNotificationTitle = new string[] {""} ;
         T00086_A70WWPNotificationShortDescription = new string[] {""} ;
         T00086_A71WWPNotificationLink = new string[] {""} ;
         T00086_A73WWPNotificationIsRead = new bool[] {false} ;
         T00086_A54WWPNotificationMetadata = new string[] {""} ;
         T00086_n54WWPNotificationMetadata = new bool[] {false} ;
         T00086_A14WWPNotificationDefinitionId = new long[1] ;
         T00086_A1WWPUserExtendedId = new string[] {""} ;
         T00086_n1WWPUserExtendedId = new bool[] {false} ;
         T00084_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00085_A1WWPUserExtendedId = new string[] {""} ;
         T00085_n1WWPUserExtendedId = new bool[] {false} ;
         T00087_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00088_A1WWPUserExtendedId = new string[] {""} ;
         T00088_n1WWPUserExtendedId = new bool[] {false} ;
         T00089_A16WWPNotificationId = new long[1] ;
         T00089_n16WWPNotificationId = new bool[] {false} ;
         T00083_A16WWPNotificationId = new long[1] ;
         T00083_n16WWPNotificationId = new bool[] {false} ;
         T00083_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00083_A68WWPNotificationIcon = new string[] {""} ;
         T00083_A69WWPNotificationTitle = new string[] {""} ;
         T00083_A70WWPNotificationShortDescription = new string[] {""} ;
         T00083_A71WWPNotificationLink = new string[] {""} ;
         T00083_A73WWPNotificationIsRead = new bool[] {false} ;
         T00083_A54WWPNotificationMetadata = new string[] {""} ;
         T00083_n54WWPNotificationMetadata = new bool[] {false} ;
         T00083_A14WWPNotificationDefinitionId = new long[1] ;
         T00083_A1WWPUserExtendedId = new string[] {""} ;
         T00083_n1WWPUserExtendedId = new bool[] {false} ;
         sMode8 = "";
         T000810_A16WWPNotificationId = new long[1] ;
         T000810_n16WWPNotificationId = new bool[] {false} ;
         T000811_A16WWPNotificationId = new long[1] ;
         T000811_n16WWPNotificationId = new bool[] {false} ;
         T00082_A16WWPNotificationId = new long[1] ;
         T00082_n16WWPNotificationId = new bool[] {false} ;
         T00082_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00082_A68WWPNotificationIcon = new string[] {""} ;
         T00082_A69WWPNotificationTitle = new string[] {""} ;
         T00082_A70WWPNotificationShortDescription = new string[] {""} ;
         T00082_A71WWPNotificationLink = new string[] {""} ;
         T00082_A73WWPNotificationIsRead = new bool[] {false} ;
         T00082_A54WWPNotificationMetadata = new string[] {""} ;
         T00082_n54WWPNotificationMetadata = new bool[] {false} ;
         T00082_A14WWPNotificationDefinitionId = new long[1] ;
         T00082_A1WWPUserExtendedId = new string[] {""} ;
         T00082_n1WWPUserExtendedId = new bool[] {false} ;
         T000812_A16WWPNotificationId = new long[1] ;
         T000812_n16WWPNotificationId = new bool[] {false} ;
         T000815_A53WWPNotificationDefinitionName = new string[] {""} ;
         T000816_A20WWPMailId = new long[1] ;
         T000817_A17WWPWebNotificationId = new long[1] ;
         T000818_A15WWPSMSId = new long[1] ;
         T000819_A16WWPNotificationId = new long[1] ;
         T000819_n16WWPNotificationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z2WWPUserExtendedFullName = "";
         ZZ37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ68WWPNotificationIcon = "";
         ZZ69WWPNotificationTitle = "";
         ZZ70WWPNotificationShortDescription = "";
         ZZ71WWPNotificationLink = "";
         ZZ1WWPUserExtendedId = "";
         ZZ54WWPNotificationMetadata = "";
         ZZ53WWPNotificationDefinitionName = "";
         ZZ2WWPUserExtendedFullName = "";
         T000820_A1WWPUserExtendedId = new string[] {""} ;
         T000820_n1WWPUserExtendedId = new bool[] {false} ;
         GXt_char1 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__default(),
            new Object[][] {
                new Object[] {
               T00082_A16WWPNotificationId, T00082_A37WWPNotificationCreated, T00082_A68WWPNotificationIcon, T00082_A69WWPNotificationTitle, T00082_A70WWPNotificationShortDescription, T00082_A71WWPNotificationLink, T00082_A73WWPNotificationIsRead, T00082_A54WWPNotificationMetadata, T00082_n54WWPNotificationMetadata, T00082_A14WWPNotificationDefinitionId,
               T00082_A1WWPUserExtendedId, T00082_n1WWPUserExtendedId
               }
               , new Object[] {
               T00083_A16WWPNotificationId, T00083_A37WWPNotificationCreated, T00083_A68WWPNotificationIcon, T00083_A69WWPNotificationTitle, T00083_A70WWPNotificationShortDescription, T00083_A71WWPNotificationLink, T00083_A73WWPNotificationIsRead, T00083_A54WWPNotificationMetadata, T00083_n54WWPNotificationMetadata, T00083_A14WWPNotificationDefinitionId,
               T00083_A1WWPUserExtendedId, T00083_n1WWPUserExtendedId
               }
               , new Object[] {
               T00084_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               T00085_A1WWPUserExtendedId
               }
               , new Object[] {
               T00086_A16WWPNotificationId, T00086_A53WWPNotificationDefinitionName, T00086_A37WWPNotificationCreated, T00086_A68WWPNotificationIcon, T00086_A69WWPNotificationTitle, T00086_A70WWPNotificationShortDescription, T00086_A71WWPNotificationLink, T00086_A73WWPNotificationIsRead, T00086_A54WWPNotificationMetadata, T00086_n54WWPNotificationMetadata,
               T00086_A14WWPNotificationDefinitionId, T00086_A1WWPUserExtendedId, T00086_n1WWPUserExtendedId
               }
               , new Object[] {
               T00087_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               T00088_A1WWPUserExtendedId
               }
               , new Object[] {
               T00089_A16WWPNotificationId
               }
               , new Object[] {
               T000810_A16WWPNotificationId
               }
               , new Object[] {
               T000811_A16WWPNotificationId
               }
               , new Object[] {
               T000812_A16WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000815_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               T000816_A20WWPMailId
               }
               , new Object[] {
               T000817_A17WWPWebNotificationId
               }
               , new Object[] {
               T000818_A15WWPSMSId
               }
               , new Object[] {
               T000819_A16WWPNotificationId
               }
               , new Object[] {
               T000820_A1WWPUserExtendedId
               }
            }
         );
         Z37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationIcon_Enabled ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationShortDescription_Enabled ;
      private int edtWWPNotificationLink_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z16WWPNotificationId ;
      private long Z14WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private long A16WWPNotificationId ;
      private long ZZ16WWPNotificationId ;
      private long ZZ14WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string Z1WWPUserExtendedId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationId_Internalname ;
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
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationIcon_Internalname ;
      private string edtWWPNotificationIcon_Jsonclick ;
      private string edtWWPNotificationTitle_Internalname ;
      private string edtWWPNotificationShortDescription_Internalname ;
      private string edtWWPNotificationLink_Internalname ;
      private string edtWWPNotificationLink_Jsonclick ;
      private string chkWWPNotificationIsRead_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
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
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1WWPUserExtendedId ;
      private string GXt_char1 ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime i37WWPNotificationCreated ;
      private DateTime ZZ37WWPNotificationCreated ;
      private bool Z73WWPNotificationIsRead ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1WWPUserExtendedId ;
      private bool wbErr ;
      private bool A73WWPNotificationIsRead ;
      private bool n16WWPNotificationId ;
      private bool n54WWPNotificationMetadata ;
      private bool Gx_longc ;
      private bool ZZ73WWPNotificationIsRead ;
      private string A54WWPNotificationMetadata ;
      private string Z54WWPNotificationMetadata ;
      private string ZZ54WWPNotificationMetadata ;
      private string Z68WWPNotificationIcon ;
      private string Z69WWPNotificationTitle ;
      private string Z70WWPNotificationShortDescription ;
      private string Z71WWPNotificationLink ;
      private string A53WWPNotificationDefinitionName ;
      private string A68WWPNotificationIcon ;
      private string A69WWPNotificationTitle ;
      private string A70WWPNotificationShortDescription ;
      private string A71WWPNotificationLink ;
      private string A2WWPUserExtendedFullName ;
      private string Z53WWPNotificationDefinitionName ;
      private string Z2WWPUserExtendedFullName ;
      private string ZZ68WWPNotificationIcon ;
      private string ZZ69WWPNotificationTitle ;
      private string ZZ70WWPNotificationShortDescription ;
      private string ZZ71WWPNotificationLink ;
      private string ZZ53WWPNotificationDefinitionName ;
      private string ZZ2WWPUserExtendedFullName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPNotificationIsRead ;
      private IDataStoreProvider pr_default ;
      private long[] T00086_A16WWPNotificationId ;
      private bool[] T00086_n16WWPNotificationId ;
      private string[] T00086_A53WWPNotificationDefinitionName ;
      private DateTime[] T00086_A37WWPNotificationCreated ;
      private string[] T00086_A68WWPNotificationIcon ;
      private string[] T00086_A69WWPNotificationTitle ;
      private string[] T00086_A70WWPNotificationShortDescription ;
      private string[] T00086_A71WWPNotificationLink ;
      private bool[] T00086_A73WWPNotificationIsRead ;
      private string[] T00086_A54WWPNotificationMetadata ;
      private bool[] T00086_n54WWPNotificationMetadata ;
      private long[] T00086_A14WWPNotificationDefinitionId ;
      private string[] T00086_A1WWPUserExtendedId ;
      private bool[] T00086_n1WWPUserExtendedId ;
      private string[] T00084_A53WWPNotificationDefinitionName ;
      private string[] T00085_A1WWPUserExtendedId ;
      private bool[] T00085_n1WWPUserExtendedId ;
      private string[] T00087_A53WWPNotificationDefinitionName ;
      private string[] T00088_A1WWPUserExtendedId ;
      private bool[] T00088_n1WWPUserExtendedId ;
      private long[] T00089_A16WWPNotificationId ;
      private bool[] T00089_n16WWPNotificationId ;
      private long[] T00083_A16WWPNotificationId ;
      private bool[] T00083_n16WWPNotificationId ;
      private DateTime[] T00083_A37WWPNotificationCreated ;
      private string[] T00083_A68WWPNotificationIcon ;
      private string[] T00083_A69WWPNotificationTitle ;
      private string[] T00083_A70WWPNotificationShortDescription ;
      private string[] T00083_A71WWPNotificationLink ;
      private bool[] T00083_A73WWPNotificationIsRead ;
      private string[] T00083_A54WWPNotificationMetadata ;
      private bool[] T00083_n54WWPNotificationMetadata ;
      private long[] T00083_A14WWPNotificationDefinitionId ;
      private string[] T00083_A1WWPUserExtendedId ;
      private bool[] T00083_n1WWPUserExtendedId ;
      private long[] T000810_A16WWPNotificationId ;
      private bool[] T000810_n16WWPNotificationId ;
      private long[] T000811_A16WWPNotificationId ;
      private bool[] T000811_n16WWPNotificationId ;
      private long[] T00082_A16WWPNotificationId ;
      private bool[] T00082_n16WWPNotificationId ;
      private DateTime[] T00082_A37WWPNotificationCreated ;
      private string[] T00082_A68WWPNotificationIcon ;
      private string[] T00082_A69WWPNotificationTitle ;
      private string[] T00082_A70WWPNotificationShortDescription ;
      private string[] T00082_A71WWPNotificationLink ;
      private bool[] T00082_A73WWPNotificationIsRead ;
      private string[] T00082_A54WWPNotificationMetadata ;
      private bool[] T00082_n54WWPNotificationMetadata ;
      private long[] T00082_A14WWPNotificationDefinitionId ;
      private string[] T00082_A1WWPUserExtendedId ;
      private bool[] T00082_n1WWPUserExtendedId ;
      private long[] T000812_A16WWPNotificationId ;
      private bool[] T000812_n16WWPNotificationId ;
      private string[] T000815_A53WWPNotificationDefinitionName ;
      private long[] T000816_A20WWPMailId ;
      private long[] T000817_A17WWPWebNotificationId ;
      private long[] T000818_A15WWPSMSId ;
      private long[] T000819_A16WWPNotificationId ;
      private bool[] T000819_n16WWPNotificationId ;
      private string[] T000820_A1WWPUserExtendedId ;
      private bool[] T000820_n1WWPUserExtendedId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_notification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00086;
        prmT00086 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00084;
        prmT00084 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00085;
        prmT00085 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00087;
        prmT00087 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00088;
        prmT00088 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00089;
        prmT00089 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00083;
        prmT00083 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000810;
        prmT000810 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000811;
        prmT000811 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00082;
        prmT00082 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000812;
        prmT000812 = new Object[] {
        new Object[] {"@WWPNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPNotificationIcon",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationIsRead",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationMetadata",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000813;
        prmT000813 = new Object[] {
        new Object[] {"@WWPNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPNotificationIcon",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationIsRead",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationMetadata",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000814;
        prmT000814 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000816;
        prmT000816 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000817;
        prmT000817 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000818;
        prmT000818 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000819;
        prmT000819 = new Object[] {
        };
        Object[] prmT000815;
        prmT000815 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000820;
        prmT000820 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("T00082", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescription], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WITH (UPDLOCK) WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00083", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescription], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00084", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00085", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00086", "SELECT TM1.[WWPNotificationId], T2.[WWPNotificationDefinitionName], TM1.[WWPNotificationCreated], TM1.[WWPNotificationIcon], TM1.[WWPNotificationTitle], TM1.[WWPNotificationShortDescription], TM1.[WWPNotificationLink], TM1.[WWPNotificationIsRead], TM1.[WWPNotificationMetadata], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM ([WWP_Notification] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) WHERE TM1.[WWPNotificationId] = @WWPNotificationId ORDER BY TM1.[WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00087", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00088", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00089", "SELECT [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000810", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE ( [WWPNotificationId] > @WWPNotificationId) ORDER BY [WWPNotificationId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000811", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE ( [WWPNotificationId] < @WWPNotificationId) ORDER BY [WWPNotificationId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000812", "INSERT INTO [WWP_Notification]([WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescription], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPNotificationCreated, @WWPNotificationIcon, @WWPNotificationTitle, @WWPNotificationShortDescription, @WWPNotificationLink, @WWPNotificationIsRead, @WWPNotificationMetadata, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000812)
           ,new CursorDef("T000813", "UPDATE [WWP_Notification] SET [WWPNotificationCreated]=@WWPNotificationCreated, [WWPNotificationIcon]=@WWPNotificationIcon, [WWPNotificationTitle]=@WWPNotificationTitle, [WWPNotificationShortDescription]=@WWPNotificationShortDescription, [WWPNotificationLink]=@WWPNotificationLink, [WWPNotificationIsRead]=@WWPNotificationIsRead, [WWPNotificationMetadata]=@WWPNotificationMetadata, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmT000813)
           ,new CursorDef("T000814", "DELETE FROM [WWP_Notification]  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmT000814)
           ,new CursorDef("T000815", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000816", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000817", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000818", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000819", "SELECT [WWPNotificationId] FROM [WWP_Notification] ORDER BY [WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000819,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000820", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000820,1, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getBool(7);
              table[7][0] = rslt.getLongVarchar(8);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLong(9);
              table[10][0] = rslt.getString(10, 40);
              table[11][0] = rslt.wasNull(10);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getBool(7);
              table[7][0] = rslt.getLongVarchar(8);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLong(9);
              table[10][0] = rslt.getString(10, 40);
              table[11][0] = rslt.wasNull(10);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getGXDateTime(3, true);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getBool(8);
              table[8][0] = rslt.getLongVarchar(9);
              table[9][0] = rslt.wasNull(9);
              table[10][0] = rslt.getLong(10);
              table[11][0] = rslt.getString(11, 40);
              table[12][0] = rslt.wasNull(11);
              return;
           case 5 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 6 :
              table[0][0] = rslt.getString(1, 40);
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
              table[0][0] = rslt.getVarchar(1);
              return;
           case 14 :
              table[0][0] = rslt.getLong(1);
              return;
           case 15 :
              table[0][0] = rslt.getLong(1);
              return;
           case 16 :
              table[0][0] = rslt.getLong(1);
              return;
           case 17 :
              table[0][0] = rslt.getLong(1);
              return;
           case 18 :
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 1 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 2 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 3 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
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
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 7 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 8 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 9 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 10 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0], true);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (bool)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(7, (string)parms[7]);
              }
              stmt.SetParameter(8, (long)parms[8]);
              if ( (bool)parms[9] )
              {
                 stmt.setNull( 9 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(9, (string)parms[10]);
              }
              return;
           case 11 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0], true);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (bool)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(7, (string)parms[7]);
              }
              stmt.SetParameter(8, (long)parms[8]);
              if ( (bool)parms[9] )
              {
                 stmt.setNull( 9 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(9, (string)parms[10]);
              }
              if ( (bool)parms[11] )
              {
                 stmt.setNull( 10 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(10, (long)parms[12]);
              }
              return;
           case 12 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 13 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 14 :
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 16 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 18 :
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
