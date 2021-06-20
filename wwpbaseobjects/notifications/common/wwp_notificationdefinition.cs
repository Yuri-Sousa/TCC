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
   public class wwp_notificationdefinition : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A10WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
            AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A10WWPEntityId) ;
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
            Form.Meta.addItem("description", "Notification Definition", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notificationdefinition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_notificationdefinition( IGxContext context )
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
         cmbWWPNotificationDefinitionAppliesTo = new GXCombobox();
         chkWWPNotificationDefinitionAllowUserSubscription = new GXCheckbox();
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
            return "wwpnotificationdefinition_Execute" ;
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
         if ( cmbWWPNotificationDefinitionAppliesTo.ItemCount > 0 )
         {
            A26WWPNotificationDefinitionAppliesTo = (short)(NumberUtil.Val( cmbWWPNotificationDefinitionAppliesTo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0))), "."));
            AssignAttri("", false, "A26WWPNotificationDefinitionAppliesTo", StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppliesTo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
            AssignProp("", false, cmbWWPNotificationDefinitionAppliesTo_Internalname, "Values", cmbWWPNotificationDefinitionAppliesTo.ToJavascriptSource(), true);
         }
         A27WWPNotificationDefinitionAllowUserSubscription = StringUtil.StrToBool( StringUtil.BoolToStr( A27WWPNotificationDefinitionAllowUserSubscription));
         AssignAttri("", false, "A27WWPNotificationDefinitionAllowUserSubscription", A27WWPNotificationDefinitionAllowUserSubscription);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Notification Definition", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ",", "")), ((edtWWPNotificationDefinitionId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A14WWPNotificationDefinitionId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A14WWPNotificationDefinitionId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, "Internal Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A53WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A53WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbWWPNotificationDefinitionAppliesTo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPNotificationDefinitionAppliesTo_Internalname, "Applies To", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPNotificationDefinitionAppliesTo, cmbWWPNotificationDefinitionAppliesTo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0)), 1, cmbWWPNotificationDefinitionAppliesTo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPNotificationDefinitionAppliesTo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         cmbWWPNotificationDefinitionAppliesTo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppliesTo_Internalname, "Values", (string)(cmbWWPNotificationDefinitionAppliesTo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkWWPNotificationDefinitionAllowUserSubscription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationDefinitionAllowUserSubscription_Internalname, "Allow User Subscription", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationDefinitionAllowUserSubscription_Internalname, StringUtil.BoolToStr( A27WWPNotificationDefinitionAllowUserSubscription), "", "Allow User Subscription", 1, chkWWPNotificationDefinitionAllowUserSubscription.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(43, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,43);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescription_Internalname, A25WWPNotificationDefinitionDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", 0, 1, edtWWPNotificationDefinitionDescription_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionIcon_Internalname, "Default Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionIcon_Internalname, A56WWPNotificationDefinitionIcon, StringUtil.RTrim( context.localUtil.Format( A56WWPNotificationDefinitionIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionIcon_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionTitle_Internalname, "Default Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionTitle_Internalname, A57WWPNotificationDefinitionTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtWWPNotificationDefinitionTitle_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionShortDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionShortDescription_Internalname, "Default Short Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionShortDescription_Internalname, A58WWPNotificationDefinitionShortDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtWWPNotificationDefinitionShortDescription_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLongDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLongDescription_Internalname, "Default Long Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionLongDescription_Internalname, A59WWPNotificationDefinitionLongDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", 0, 1, edtWWPNotificationDefinitionLongDescription_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLink_Internalname, "Default Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionLink_Internalname, A60WWPNotificationDefinitionLink, StringUtil.RTrim( context.localUtil.Format( A60WWPNotificationDefinitionLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", A60WWPNotificationDefinitionLink, "_blank", "", "", edtWWPNotificationDefinitionLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPEntityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityId_Internalname, "Entity Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ",", "")), ((edtWWPEntityId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A10WWPEntityId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A10WWPEntityId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPEntityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityName_Internalname, "Entity Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A12WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A12WWPEntityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_NotificationDefinition.htm");
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
            Z14WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( "Z14WWPNotificationDefinitionId"), ",", "."));
            Z53WWPNotificationDefinitionName = cgiGet( "Z53WWPNotificationDefinitionName");
            Z26WWPNotificationDefinitionAppliesTo = (short)(context.localUtil.CToN( cgiGet( "Z26WWPNotificationDefinitionAppliesTo"), ",", "."));
            Z27WWPNotificationDefinitionAllowUserSubscription = StringUtil.StrToBool( cgiGet( "Z27WWPNotificationDefinitionAllowUserSubscription"));
            Z25WWPNotificationDefinitionDescription = cgiGet( "Z25WWPNotificationDefinitionDescription");
            Z56WWPNotificationDefinitionIcon = cgiGet( "Z56WWPNotificationDefinitionIcon");
            Z57WWPNotificationDefinitionTitle = cgiGet( "Z57WWPNotificationDefinitionTitle");
            Z58WWPNotificationDefinitionShortDescription = cgiGet( "Z58WWPNotificationDefinitionShortDescription");
            Z59WWPNotificationDefinitionLongDescription = cgiGet( "Z59WWPNotificationDefinitionLongDescription");
            Z60WWPNotificationDefinitionLink = cgiGet( "Z60WWPNotificationDefinitionLink");
            Z10WWPEntityId = (long)(context.localUtil.CToN( cgiGet( "Z10WWPEntityId"), ",", "."));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            cmbWWPNotificationDefinitionAppliesTo.CurrentValue = cgiGet( cmbWWPNotificationDefinitionAppliesTo_Internalname);
            A26WWPNotificationDefinitionAppliesTo = (short)(NumberUtil.Val( cgiGet( cmbWWPNotificationDefinitionAppliesTo_Internalname), "."));
            AssignAttri("", false, "A26WWPNotificationDefinitionAppliesTo", StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
            A27WWPNotificationDefinitionAllowUserSubscription = StringUtil.StrToBool( cgiGet( chkWWPNotificationDefinitionAllowUserSubscription_Internalname));
            AssignAttri("", false, "A27WWPNotificationDefinitionAllowUserSubscription", A27WWPNotificationDefinitionAllowUserSubscription);
            A25WWPNotificationDefinitionDescription = cgiGet( edtWWPNotificationDefinitionDescription_Internalname);
            AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
            A56WWPNotificationDefinitionIcon = cgiGet( edtWWPNotificationDefinitionIcon_Internalname);
            AssignAttri("", false, "A56WWPNotificationDefinitionIcon", A56WWPNotificationDefinitionIcon);
            A57WWPNotificationDefinitionTitle = cgiGet( edtWWPNotificationDefinitionTitle_Internalname);
            AssignAttri("", false, "A57WWPNotificationDefinitionTitle", A57WWPNotificationDefinitionTitle);
            A58WWPNotificationDefinitionShortDescription = cgiGet( edtWWPNotificationDefinitionShortDescription_Internalname);
            AssignAttri("", false, "A58WWPNotificationDefinitionShortDescription", A58WWPNotificationDefinitionShortDescription);
            A59WWPNotificationDefinitionLongDescription = cgiGet( edtWWPNotificationDefinitionLongDescription_Internalname);
            AssignAttri("", false, "A59WWPNotificationDefinitionLongDescription", A59WWPNotificationDefinitionLongDescription);
            A60WWPNotificationDefinitionLink = cgiGet( edtWWPNotificationDefinitionLink_Internalname);
            AssignAttri("", false, "A60WWPNotificationDefinitionLink", A60WWPNotificationDefinitionLink);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPENTITYID");
               AnyError = 1;
               GX_FocusControl = edtWWPEntityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A10WWPEntityId = 0;
               AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            }
            else
            {
               A10WWPEntityId = (long)(context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ",", "."));
               AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            }
            A12WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
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
               A14WWPNotificationDefinitionId = (long)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."));
               AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
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
               InitAll077( ) ;
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
         DisableAttributes077( ) ;
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

      protected void ResetCaption070( )
      {
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z53WWPNotificationDefinitionName = T00073_A53WWPNotificationDefinitionName[0];
               Z26WWPNotificationDefinitionAppliesTo = T00073_A26WWPNotificationDefinitionAppliesTo[0];
               Z27WWPNotificationDefinitionAllowUserSubscription = T00073_A27WWPNotificationDefinitionAllowUserSubscription[0];
               Z25WWPNotificationDefinitionDescription = T00073_A25WWPNotificationDefinitionDescription[0];
               Z56WWPNotificationDefinitionIcon = T00073_A56WWPNotificationDefinitionIcon[0];
               Z57WWPNotificationDefinitionTitle = T00073_A57WWPNotificationDefinitionTitle[0];
               Z58WWPNotificationDefinitionShortDescription = T00073_A58WWPNotificationDefinitionShortDescription[0];
               Z59WWPNotificationDefinitionLongDescription = T00073_A59WWPNotificationDefinitionLongDescription[0];
               Z60WWPNotificationDefinitionLink = T00073_A60WWPNotificationDefinitionLink[0];
               Z10WWPEntityId = T00073_A10WWPEntityId[0];
            }
            else
            {
               Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
               Z26WWPNotificationDefinitionAppliesTo = A26WWPNotificationDefinitionAppliesTo;
               Z27WWPNotificationDefinitionAllowUserSubscription = A27WWPNotificationDefinitionAllowUserSubscription;
               Z25WWPNotificationDefinitionDescription = A25WWPNotificationDefinitionDescription;
               Z56WWPNotificationDefinitionIcon = A56WWPNotificationDefinitionIcon;
               Z57WWPNotificationDefinitionTitle = A57WWPNotificationDefinitionTitle;
               Z58WWPNotificationDefinitionShortDescription = A58WWPNotificationDefinitionShortDescription;
               Z59WWPNotificationDefinitionLongDescription = A59WWPNotificationDefinitionLongDescription;
               Z60WWPNotificationDefinitionLink = A60WWPNotificationDefinitionLink;
               Z10WWPEntityId = A10WWPEntityId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
            Z26WWPNotificationDefinitionAppliesTo = A26WWPNotificationDefinitionAppliesTo;
            Z27WWPNotificationDefinitionAllowUserSubscription = A27WWPNotificationDefinitionAllowUserSubscription;
            Z25WWPNotificationDefinitionDescription = A25WWPNotificationDefinitionDescription;
            Z56WWPNotificationDefinitionIcon = A56WWPNotificationDefinitionIcon;
            Z57WWPNotificationDefinitionTitle = A57WWPNotificationDefinitionTitle;
            Z58WWPNotificationDefinitionShortDescription = A58WWPNotificationDefinitionShortDescription;
            Z59WWPNotificationDefinitionLongDescription = A59WWPNotificationDefinitionLongDescription;
            Z60WWPNotificationDefinitionLink = A60WWPNotificationDefinitionLink;
            Z10WWPEntityId = A10WWPEntityId;
            Z12WWPEntityName = A12WWPEntityName;
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

      protected void Load077( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A53WWPNotificationDefinitionName = T00075_A53WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            A26WWPNotificationDefinitionAppliesTo = T00075_A26WWPNotificationDefinitionAppliesTo[0];
            AssignAttri("", false, "A26WWPNotificationDefinitionAppliesTo", StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
            A27WWPNotificationDefinitionAllowUserSubscription = T00075_A27WWPNotificationDefinitionAllowUserSubscription[0];
            AssignAttri("", false, "A27WWPNotificationDefinitionAllowUserSubscription", A27WWPNotificationDefinitionAllowUserSubscription);
            A25WWPNotificationDefinitionDescription = T00075_A25WWPNotificationDefinitionDescription[0];
            AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
            A56WWPNotificationDefinitionIcon = T00075_A56WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A56WWPNotificationDefinitionIcon", A56WWPNotificationDefinitionIcon);
            A57WWPNotificationDefinitionTitle = T00075_A57WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A57WWPNotificationDefinitionTitle", A57WWPNotificationDefinitionTitle);
            A58WWPNotificationDefinitionShortDescription = T00075_A58WWPNotificationDefinitionShortDescription[0];
            AssignAttri("", false, "A58WWPNotificationDefinitionShortDescription", A58WWPNotificationDefinitionShortDescription);
            A59WWPNotificationDefinitionLongDescription = T00075_A59WWPNotificationDefinitionLongDescription[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionLongDescription", A59WWPNotificationDefinitionLongDescription);
            A60WWPNotificationDefinitionLink = T00075_A60WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A60WWPNotificationDefinitionLink", A60WWPNotificationDefinitionLink);
            A12WWPEntityName = T00075_A12WWPEntityName[0];
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
            A10WWPEntityId = T00075_A10WWPEntityId[0];
            AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            ZM077( -3) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( A26WWPNotificationDefinitionAppliesTo == 1 ) || ( A26WWPNotificationDefinitionAppliesTo == 2 ) ) )
         {
            GX_msglist.addItem("Campo Notification Definition Applies To fora do intervalo", "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONAPPLIESTO");
            AnyError = 1;
            GX_FocusControl = cmbWWPNotificationDefinitionAppliesTo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A60WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de Notification Definition Default Link não coincide com o padrão especificado", "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A12WWPEntityName = T00074_A12WWPEntityName[0];
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( long A10WWPEntityId )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A12WWPEntityName = T00076_A12WWPEntityName[0];
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A12WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey077( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 3) ;
            RcdFound7 = 1;
            A14WWPNotificationDefinitionId = T00073_A14WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            A53WWPNotificationDefinitionName = T00073_A53WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
            A26WWPNotificationDefinitionAppliesTo = T00073_A26WWPNotificationDefinitionAppliesTo[0];
            AssignAttri("", false, "A26WWPNotificationDefinitionAppliesTo", StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
            A27WWPNotificationDefinitionAllowUserSubscription = T00073_A27WWPNotificationDefinitionAllowUserSubscription[0];
            AssignAttri("", false, "A27WWPNotificationDefinitionAllowUserSubscription", A27WWPNotificationDefinitionAllowUserSubscription);
            A25WWPNotificationDefinitionDescription = T00073_A25WWPNotificationDefinitionDescription[0];
            AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
            A56WWPNotificationDefinitionIcon = T00073_A56WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A56WWPNotificationDefinitionIcon", A56WWPNotificationDefinitionIcon);
            A57WWPNotificationDefinitionTitle = T00073_A57WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A57WWPNotificationDefinitionTitle", A57WWPNotificationDefinitionTitle);
            A58WWPNotificationDefinitionShortDescription = T00073_A58WWPNotificationDefinitionShortDescription[0];
            AssignAttri("", false, "A58WWPNotificationDefinitionShortDescription", A58WWPNotificationDefinitionShortDescription);
            A59WWPNotificationDefinitionLongDescription = T00073_A59WWPNotificationDefinitionLongDescription[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionLongDescription", A59WWPNotificationDefinitionLongDescription);
            A60WWPNotificationDefinitionLink = T00073_A60WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A60WWPNotificationDefinitionLink", A60WWPNotificationDefinitionLink);
            A10WWPEntityId = T00073_A10WWPEntityId[0];
            AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
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
         RcdFound7 = 0;
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00078_A14WWPNotificationDefinitionId[0] < A14WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00078_A14WWPNotificationDefinitionId[0] > A14WWPNotificationDefinitionId ) ) )
            {
               A14WWPNotificationDefinitionId = T00078_A14WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00079_A14WWPNotificationDefinitionId[0] > A14WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00079_A14WWPNotificationDefinitionId[0] < A14WWPNotificationDefinitionId ) ) )
            {
               A14WWPNotificationDefinitionId = T00079_A14WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A14WWPNotificationDefinitionId != Z14WWPNotificationDefinitionId )
               {
                  A14WWPNotificationDefinitionId = Z14WWPNotificationDefinitionId;
                  AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A14WWPNotificationDefinitionId != Z14WWPNotificationDefinitionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
         if ( A14WWPNotificationDefinitionId != Z14WWPNotificationDefinitionId )
         {
            A14WWPNotificationDefinitionId = Z14WWPNotificationDefinitionId;
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd077( ) ;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         ScanStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound7 != 0 )
            {
               ScanNext077( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd077( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A14WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z53WWPNotificationDefinitionName, T00072_A53WWPNotificationDefinitionName[0]) != 0 ) || ( Z26WWPNotificationDefinitionAppliesTo != T00072_A26WWPNotificationDefinitionAppliesTo[0] ) || ( Z27WWPNotificationDefinitionAllowUserSubscription != T00072_A27WWPNotificationDefinitionAllowUserSubscription[0] ) || ( StringUtil.StrCmp(Z25WWPNotificationDefinitionDescription, T00072_A25WWPNotificationDefinitionDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z56WWPNotificationDefinitionIcon, T00072_A56WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z57WWPNotificationDefinitionTitle, T00072_A57WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z58WWPNotificationDefinitionShortDescription, T00072_A58WWPNotificationDefinitionShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z59WWPNotificationDefinitionLongDescription, T00072_A59WWPNotificationDefinitionLongDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z60WWPNotificationDefinitionLink, T00072_A60WWPNotificationDefinitionLink[0]) != 0 ) || ( Z10WWPEntityId != T00072_A10WWPEntityId[0] ) )
            {
               if ( StringUtil.StrCmp(Z53WWPNotificationDefinitionName, T00072_A53WWPNotificationDefinitionName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionName");
                  GXUtil.WriteLogRaw("Old: ",Z53WWPNotificationDefinitionName);
                  GXUtil.WriteLogRaw("Current: ",T00072_A53WWPNotificationDefinitionName[0]);
               }
               if ( Z26WWPNotificationDefinitionAppliesTo != T00072_A26WWPNotificationDefinitionAppliesTo[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAppliesTo");
                  GXUtil.WriteLogRaw("Old: ",Z26WWPNotificationDefinitionAppliesTo);
                  GXUtil.WriteLogRaw("Current: ",T00072_A26WWPNotificationDefinitionAppliesTo[0]);
               }
               if ( Z27WWPNotificationDefinitionAllowUserSubscription != T00072_A27WWPNotificationDefinitionAllowUserSubscription[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAllowUserSubscription");
                  GXUtil.WriteLogRaw("Old: ",Z27WWPNotificationDefinitionAllowUserSubscription);
                  GXUtil.WriteLogRaw("Current: ",T00072_A27WWPNotificationDefinitionAllowUserSubscription[0]);
               }
               if ( StringUtil.StrCmp(Z25WWPNotificationDefinitionDescription, T00072_A25WWPNotificationDefinitionDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionDescription");
                  GXUtil.WriteLogRaw("Old: ",Z25WWPNotificationDefinitionDescription);
                  GXUtil.WriteLogRaw("Current: ",T00072_A25WWPNotificationDefinitionDescription[0]);
               }
               if ( StringUtil.StrCmp(Z56WWPNotificationDefinitionIcon, T00072_A56WWPNotificationDefinitionIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionIcon");
                  GXUtil.WriteLogRaw("Old: ",Z56WWPNotificationDefinitionIcon);
                  GXUtil.WriteLogRaw("Current: ",T00072_A56WWPNotificationDefinitionIcon[0]);
               }
               if ( StringUtil.StrCmp(Z57WWPNotificationDefinitionTitle, T00072_A57WWPNotificationDefinitionTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionTitle");
                  GXUtil.WriteLogRaw("Old: ",Z57WWPNotificationDefinitionTitle);
                  GXUtil.WriteLogRaw("Current: ",T00072_A57WWPNotificationDefinitionTitle[0]);
               }
               if ( StringUtil.StrCmp(Z58WWPNotificationDefinitionShortDescription, T00072_A58WWPNotificationDefinitionShortDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionShortDescription");
                  GXUtil.WriteLogRaw("Old: ",Z58WWPNotificationDefinitionShortDescription);
                  GXUtil.WriteLogRaw("Current: ",T00072_A58WWPNotificationDefinitionShortDescription[0]);
               }
               if ( StringUtil.StrCmp(Z59WWPNotificationDefinitionLongDescription, T00072_A59WWPNotificationDefinitionLongDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLongDescription");
                  GXUtil.WriteLogRaw("Old: ",Z59WWPNotificationDefinitionLongDescription);
                  GXUtil.WriteLogRaw("Current: ",T00072_A59WWPNotificationDefinitionLongDescription[0]);
               }
               if ( StringUtil.StrCmp(Z60WWPNotificationDefinitionLink, T00072_A60WWPNotificationDefinitionLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLink");
                  GXUtil.WriteLogRaw("Old: ",Z60WWPNotificationDefinitionLink);
                  GXUtil.WriteLogRaw("Current: ",T00072_A60WWPNotificationDefinitionLink[0]);
               }
               if ( Z10WWPEntityId != T00072_A10WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z10WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A10WWPEntityId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000710 */
                     pr_default.execute(8, new Object[] {A53WWPNotificationDefinitionName, A26WWPNotificationDefinitionAppliesTo, A27WWPNotificationDefinitionAllowUserSubscription, A25WWPNotificationDefinitionDescription, A56WWPNotificationDefinitionIcon, A57WWPNotificationDefinitionTitle, A58WWPNotificationDefinitionShortDescription, A59WWPNotificationDefinitionLongDescription, A60WWPNotificationDefinitionLink, A10WWPEntityId});
                     A14WWPNotificationDefinitionId = T000710_A14WWPNotificationDefinitionId[0];
                     AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A53WWPNotificationDefinitionName, A26WWPNotificationDefinitionAppliesTo, A27WWPNotificationDefinitionAllowUserSubscription, A25WWPNotificationDefinitionDescription, A56WWPNotificationDefinitionIcon, A57WWPNotificationDefinitionTitle, A58WWPNotificationDefinitionShortDescription, A59WWPNotificationDefinitionLongDescription, A60WWPNotificationDefinitionLink, A10WWPEntityId, A14WWPNotificationDefinitionId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption070( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000712 */
                  pr_default.execute(10, new Object[] {A14WWPNotificationDefinitionId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound7 == 0 )
                        {
                           InitAll077( ) ;
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
                        ResetCaption070( ) ;
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000713 */
            pr_default.execute(11, new Object[] {A10WWPEntityId});
            A12WWPEntityName = T000713_A12WWPEntityName[0];
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000714 */
            pr_default.execute(12, new Object[] {A14WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000715 */
            pr_default.execute(13, new Object[] {A14WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPSubscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Using cursor T000716 */
         pr_default.execute(14);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound7 = 1;
            A14WWPNotificationDefinitionId = T000716_A14WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound7 = 1;
            A14WWPNotificationDefinitionId = T000716_A14WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         cmbWWPNotificationDefinitionAppliesTo.Enabled = 0;
         AssignProp("", false, cmbWWPNotificationDefinitionAppliesTo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPNotificationDefinitionAppliesTo.Enabled), 5, 0), true);
         chkWWPNotificationDefinitionAllowUserSubscription.Enabled = 0;
         AssignProp("", false, chkWWPNotificationDefinitionAllowUserSubscription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationDefinitionAllowUserSubscription.Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescription_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescription_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionIcon_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionTitle_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionShortDescription_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionShortDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionShortDescription_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLongDescription_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLongDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLongDescription_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLink_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.AddJavascriptSource("gxcfg.js", "?20214281548718", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z53WWPNotificationDefinitionName", Z53WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z26WWPNotificationDefinitionAppliesTo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26WWPNotificationDefinitionAppliesTo), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z27WWPNotificationDefinitionAllowUserSubscription", Z27WWPNotificationDefinitionAllowUserSubscription);
         GxWebStd.gx_hidden_field( context, "Z25WWPNotificationDefinitionDescription", Z25WWPNotificationDefinitionDescription);
         GxWebStd.gx_hidden_field( context, "Z56WWPNotificationDefinitionIcon", Z56WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z57WWPNotificationDefinitionTitle", Z57WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z58WWPNotificationDefinitionShortDescription", Z58WWPNotificationDefinitionShortDescription);
         GxWebStd.gx_hidden_field( context, "Z59WWPNotificationDefinitionLongDescription", Z59WWPNotificationDefinitionLongDescription);
         GxWebStd.gx_hidden_field( context, "Z60WWPNotificationDefinitionLink", Z60WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10WWPEntityId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_NotificationDefinition" ;
      }

      public override string GetPgmdesc( )
      {
         return "Notification Definition" ;
      }

      protected void InitializeNonKey077( )
      {
         A53WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         A26WWPNotificationDefinitionAppliesTo = 0;
         AssignAttri("", false, "A26WWPNotificationDefinitionAppliesTo", StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
         A27WWPNotificationDefinitionAllowUserSubscription = false;
         AssignAttri("", false, "A27WWPNotificationDefinitionAllowUserSubscription", A27WWPNotificationDefinitionAllowUserSubscription);
         A25WWPNotificationDefinitionDescription = "";
         AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
         A56WWPNotificationDefinitionIcon = "";
         AssignAttri("", false, "A56WWPNotificationDefinitionIcon", A56WWPNotificationDefinitionIcon);
         A57WWPNotificationDefinitionTitle = "";
         AssignAttri("", false, "A57WWPNotificationDefinitionTitle", A57WWPNotificationDefinitionTitle);
         A58WWPNotificationDefinitionShortDescription = "";
         AssignAttri("", false, "A58WWPNotificationDefinitionShortDescription", A58WWPNotificationDefinitionShortDescription);
         A59WWPNotificationDefinitionLongDescription = "";
         AssignAttri("", false, "A59WWPNotificationDefinitionLongDescription", A59WWPNotificationDefinitionLongDescription);
         A60WWPNotificationDefinitionLink = "";
         AssignAttri("", false, "A60WWPNotificationDefinitionLink", A60WWPNotificationDefinitionLink);
         A10WWPEntityId = 0;
         AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
         A12WWPEntityName = "";
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         Z53WWPNotificationDefinitionName = "";
         Z26WWPNotificationDefinitionAppliesTo = 0;
         Z27WWPNotificationDefinitionAllowUserSubscription = false;
         Z25WWPNotificationDefinitionDescription = "";
         Z56WWPNotificationDefinitionIcon = "";
         Z57WWPNotificationDefinitionTitle = "";
         Z58WWPNotificationDefinitionShortDescription = "";
         Z59WWPNotificationDefinitionLongDescription = "";
         Z60WWPNotificationDefinitionLink = "";
         Z10WWPEntityId = 0;
      }

      protected void InitAll077( )
      {
         A14WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
         InitializeNonKey077( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281548731", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notificationdefinition.js", "?20214281548732", false, true);
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
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         cmbWWPNotificationDefinitionAppliesTo_Internalname = "WWPNOTIFICATIONDEFINITIONAPPLIESTO";
         chkWWPNotificationDefinitionAllowUserSubscription_Internalname = "WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION";
         edtWWPNotificationDefinitionDescription_Internalname = "WWPNOTIFICATIONDEFINITIONDESCRIPTION";
         edtWWPNotificationDefinitionIcon_Internalname = "WWPNOTIFICATIONDEFINITIONICON";
         edtWWPNotificationDefinitionTitle_Internalname = "WWPNOTIFICATIONDEFINITIONTITLE";
         edtWWPNotificationDefinitionShortDescription_Internalname = "WWPNOTIFICATIONDEFINITIONSHORTDESCRIPTION";
         edtWWPNotificationDefinitionLongDescription_Internalname = "WWPNOTIFICATIONDEFINITIONLONGDESCRIPTION";
         edtWWPNotificationDefinitionLink_Internalname = "WWPNOTIFICATIONDEFINITIONLINK";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
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
         Form.Caption = "Notification Definition";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPNotificationDefinitionLink_Jsonclick = "";
         edtWWPNotificationDefinitionLink_Enabled = 1;
         edtWWPNotificationDefinitionLongDescription_Enabled = 1;
         edtWWPNotificationDefinitionShortDescription_Enabled = 1;
         edtWWPNotificationDefinitionTitle_Enabled = 1;
         edtWWPNotificationDefinitionIcon_Jsonclick = "";
         edtWWPNotificationDefinitionIcon_Enabled = 1;
         edtWWPNotificationDefinitionDescription_Enabled = 1;
         chkWWPNotificationDefinitionAllowUserSubscription.Enabled = 1;
         cmbWWPNotificationDefinitionAppliesTo_Jsonclick = "";
         cmbWWPNotificationDefinitionAppliesTo.Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 1;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
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
         cmbWWPNotificationDefinitionAppliesTo.Name = "WWPNOTIFICATIONDEFINITIONAPPLIESTO";
         cmbWWPNotificationDefinitionAppliesTo.WebTags = "";
         cmbWWPNotificationDefinitionAppliesTo.addItem("1", "Any record", 0);
         cmbWWPNotificationDefinitionAppliesTo.addItem("2", "Specific record", 0);
         if ( cmbWWPNotificationDefinitionAppliesTo.ItemCount > 0 )
         {
            A26WWPNotificationDefinitionAppliesTo = (short)(NumberUtil.Val( cmbWWPNotificationDefinitionAppliesTo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0))), "."));
            AssignAttri("", false, "A26WWPNotificationDefinitionAppliesTo", StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
         }
         chkWWPNotificationDefinitionAllowUserSubscription.Name = "WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION";
         chkWWPNotificationDefinitionAllowUserSubscription.WebTags = "";
         chkWWPNotificationDefinitionAllowUserSubscription.Caption = "";
         AssignProp("", false, chkWWPNotificationDefinitionAllowUserSubscription_Internalname, "TitleCaption", chkWWPNotificationDefinitionAllowUserSubscription.Caption, true);
         chkWWPNotificationDefinitionAllowUserSubscription.CheckedValue = "false";
         A27WWPNotificationDefinitionAllowUserSubscription = StringUtil.StrToBool( StringUtil.BoolToStr( A27WWPNotificationDefinitionAllowUserSubscription));
         AssignAttri("", false, "A27WWPNotificationDefinitionAllowUserSubscription", A27WWPNotificationDefinitionAllowUserSubscription);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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

      public void Valid_Wwpnotificationdefinitionid( )
      {
         A26WWPNotificationDefinitionAppliesTo = (short)(NumberUtil.Val( cmbWWPNotificationDefinitionAppliesTo.CurrentValue, "."));
         cmbWWPNotificationDefinitionAppliesTo.CurrentValue = StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPNotificationDefinitionAppliesTo.ItemCount > 0 )
         {
            A26WWPNotificationDefinitionAppliesTo = (short)(NumberUtil.Val( cmbWWPNotificationDefinitionAppliesTo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0))), "."));
            cmbWWPNotificationDefinitionAppliesTo.CurrentValue = StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppliesTo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
         }
         A27WWPNotificationDefinitionAllowUserSubscription = StringUtil.StrToBool( StringUtil.BoolToStr( A27WWPNotificationDefinitionAllowUserSubscription));
         /*  Sending validation outputs */
         AssignAttri("", false, "A53WWPNotificationDefinitionName", A53WWPNotificationDefinitionName);
         AssignAttri("", false, "A26WWPNotificationDefinitionAppliesTo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0, ".", "")));
         cmbWWPNotificationDefinitionAppliesTo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppliesTo_Internalname, "Values", cmbWWPNotificationDefinitionAppliesTo.ToJavascriptSource(), true);
         AssignAttri("", false, "A27WWPNotificationDefinitionAllowUserSubscription", A27WWPNotificationDefinitionAllowUserSubscription);
         AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
         AssignAttri("", false, "A56WWPNotificationDefinitionIcon", A56WWPNotificationDefinitionIcon);
         AssignAttri("", false, "A57WWPNotificationDefinitionTitle", A57WWPNotificationDefinitionTitle);
         AssignAttri("", false, "A58WWPNotificationDefinitionShortDescription", A58WWPNotificationDefinitionShortDescription);
         AssignAttri("", false, "A59WWPNotificationDefinitionLongDescription", A59WWPNotificationDefinitionLongDescription);
         AssignAttri("", false, "A60WWPNotificationDefinitionLink", A60WWPNotificationDefinitionLink);
         AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z53WWPNotificationDefinitionName", Z53WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z26WWPNotificationDefinitionAppliesTo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26WWPNotificationDefinitionAppliesTo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27WWPNotificationDefinitionAllowUserSubscription", StringUtil.BoolToStr( Z27WWPNotificationDefinitionAllowUserSubscription));
         GxWebStd.gx_hidden_field( context, "Z25WWPNotificationDefinitionDescription", Z25WWPNotificationDefinitionDescription);
         GxWebStd.gx_hidden_field( context, "Z56WWPNotificationDefinitionIcon", Z56WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z57WWPNotificationDefinitionTitle", Z57WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z58WWPNotificationDefinitionShortDescription", Z58WWPNotificationDefinitionShortDescription);
         GxWebStd.gx_hidden_field( context, "Z59WWPNotificationDefinitionLongDescription", Z59WWPNotificationDefinitionLongDescription);
         GxWebStd.gx_hidden_field( context, "Z60WWPNotificationDefinitionLink", Z60WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12WWPEntityName", Z12WWPEntityName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T000713 */
         pr_default.execute(11, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A12WWPEntityName = T000713_A12WWPEntityName[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'cmbWWPNotificationDefinitionAppliesTo'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A53WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'cmbWWPNotificationDefinitionAppliesTo'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A56WWPNotificationDefinitionIcon',fld:'WWPNOTIFICATIONDEFINITIONICON',pic:''},{av:'A57WWPNotificationDefinitionTitle',fld:'WWPNOTIFICATIONDEFINITIONTITLE',pic:''},{av:'A58WWPNotificationDefinitionShortDescription',fld:'WWPNOTIFICATIONDEFINITIONSHORTDESCRIPTION',pic:''},{av:'A59WWPNotificationDefinitionLongDescription',fld:'WWPNOTIFICATIONDEFINITIONLONGDESCRIPTION',pic:''},{av:'A60WWPNotificationDefinitionLink',fld:'WWPNOTIFICATIONDEFINITIONLINK',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z53WWPNotificationDefinitionName'},{av:'Z26WWPNotificationDefinitionAppliesTo'},{av:'Z27WWPNotificationDefinitionAllowUserSubscription'},{av:'Z25WWPNotificationDefinitionDescription'},{av:'Z56WWPNotificationDefinitionIcon'},{av:'Z57WWPNotificationDefinitionTitle'},{av:'Z58WWPNotificationDefinitionShortDescription'},{av:'Z59WWPNotificationDefinitionLongDescription'},{av:'Z60WWPNotificationDefinitionLink'},{av:'Z10WWPEntityId'},{av:'Z12WWPEntityName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLIESTO","{handler:'Valid_Wwpnotificationdefinitionappliesto',iparms:[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLIESTO",",oparms:[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK","{handler:'Valid_Wwpnotificationdefinitionlink',iparms:[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK",",oparms:[{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]}");
         setEventMetadata("VALID_WWPENTITYID","{handler:'Valid_Wwpentityid',iparms:[{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]");
         setEventMetadata("VALID_WWPENTITYID",",oparms:[{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''}]}");
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
         Z53WWPNotificationDefinitionName = "";
         Z25WWPNotificationDefinitionDescription = "";
         Z56WWPNotificationDefinitionIcon = "";
         Z57WWPNotificationDefinitionTitle = "";
         Z58WWPNotificationDefinitionShortDescription = "";
         Z59WWPNotificationDefinitionLongDescription = "";
         Z60WWPNotificationDefinitionLink = "";
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
         A53WWPNotificationDefinitionName = "";
         A25WWPNotificationDefinitionDescription = "";
         A56WWPNotificationDefinitionIcon = "";
         A57WWPNotificationDefinitionTitle = "";
         A58WWPNotificationDefinitionShortDescription = "";
         A59WWPNotificationDefinitionLongDescription = "";
         A60WWPNotificationDefinitionLink = "";
         A12WWPEntityName = "";
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
         Z12WWPEntityName = "";
         T00075_A14WWPNotificationDefinitionId = new long[1] ;
         T00075_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00075_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         T00075_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         T00075_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         T00075_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         T00075_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         T00075_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         T00075_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         T00075_A60WWPNotificationDefinitionLink = new string[] {""} ;
         T00075_A12WWPEntityName = new string[] {""} ;
         T00075_A10WWPEntityId = new long[1] ;
         T00074_A12WWPEntityName = new string[] {""} ;
         T00076_A12WWPEntityName = new string[] {""} ;
         T00077_A14WWPNotificationDefinitionId = new long[1] ;
         T00073_A14WWPNotificationDefinitionId = new long[1] ;
         T00073_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00073_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         T00073_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         T00073_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         T00073_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         T00073_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         T00073_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         T00073_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         T00073_A60WWPNotificationDefinitionLink = new string[] {""} ;
         T00073_A10WWPEntityId = new long[1] ;
         sMode7 = "";
         T00078_A14WWPNotificationDefinitionId = new long[1] ;
         T00079_A14WWPNotificationDefinitionId = new long[1] ;
         T00072_A14WWPNotificationDefinitionId = new long[1] ;
         T00072_A53WWPNotificationDefinitionName = new string[] {""} ;
         T00072_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         T00072_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         T00072_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         T00072_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         T00072_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         T00072_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         T00072_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         T00072_A60WWPNotificationDefinitionLink = new string[] {""} ;
         T00072_A10WWPEntityId = new long[1] ;
         T000710_A14WWPNotificationDefinitionId = new long[1] ;
         T000713_A12WWPEntityName = new string[] {""} ;
         T000714_A16WWPNotificationId = new long[1] ;
         T000715_A13WWPSubscriptionId = new long[1] ;
         T000716_A14WWPNotificationDefinitionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ53WWPNotificationDefinitionName = "";
         ZZ25WWPNotificationDefinitionDescription = "";
         ZZ56WWPNotificationDefinitionIcon = "";
         ZZ57WWPNotificationDefinitionTitle = "";
         ZZ58WWPNotificationDefinitionShortDescription = "";
         ZZ59WWPNotificationDefinitionLongDescription = "";
         ZZ60WWPNotificationDefinitionLink = "";
         ZZ12WWPEntityName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__default(),
            new Object[][] {
                new Object[] {
               T00072_A14WWPNotificationDefinitionId, T00072_A53WWPNotificationDefinitionName, T00072_A26WWPNotificationDefinitionAppliesTo, T00072_A27WWPNotificationDefinitionAllowUserSubscription, T00072_A25WWPNotificationDefinitionDescription, T00072_A56WWPNotificationDefinitionIcon, T00072_A57WWPNotificationDefinitionTitle, T00072_A58WWPNotificationDefinitionShortDescription, T00072_A59WWPNotificationDefinitionLongDescription, T00072_A60WWPNotificationDefinitionLink,
               T00072_A10WWPEntityId
               }
               , new Object[] {
               T00073_A14WWPNotificationDefinitionId, T00073_A53WWPNotificationDefinitionName, T00073_A26WWPNotificationDefinitionAppliesTo, T00073_A27WWPNotificationDefinitionAllowUserSubscription, T00073_A25WWPNotificationDefinitionDescription, T00073_A56WWPNotificationDefinitionIcon, T00073_A57WWPNotificationDefinitionTitle, T00073_A58WWPNotificationDefinitionShortDescription, T00073_A59WWPNotificationDefinitionLongDescription, T00073_A60WWPNotificationDefinitionLink,
               T00073_A10WWPEntityId
               }
               , new Object[] {
               T00074_A12WWPEntityName
               }
               , new Object[] {
               T00075_A14WWPNotificationDefinitionId, T00075_A53WWPNotificationDefinitionName, T00075_A26WWPNotificationDefinitionAppliesTo, T00075_A27WWPNotificationDefinitionAllowUserSubscription, T00075_A25WWPNotificationDefinitionDescription, T00075_A56WWPNotificationDefinitionIcon, T00075_A57WWPNotificationDefinitionTitle, T00075_A58WWPNotificationDefinitionShortDescription, T00075_A59WWPNotificationDefinitionLongDescription, T00075_A60WWPNotificationDefinitionLink,
               T00075_A12WWPEntityName, T00075_A10WWPEntityId
               }
               , new Object[] {
               T00076_A12WWPEntityName
               }
               , new Object[] {
               T00077_A14WWPNotificationDefinitionId
               }
               , new Object[] {
               T00078_A14WWPNotificationDefinitionId
               }
               , new Object[] {
               T00079_A14WWPNotificationDefinitionId
               }
               , new Object[] {
               T000710_A14WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000713_A12WWPEntityName
               }
               , new Object[] {
               T000714_A16WWPNotificationId
               }
               , new Object[] {
               T000715_A13WWPSubscriptionId
               }
               , new Object[] {
               T000716_A14WWPNotificationDefinitionId
               }
            }
         );
      }

      private short Z26WWPNotificationDefinitionAppliesTo ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A26WWPNotificationDefinitionAppliesTo ;
      private short GX_JID ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ26WWPNotificationDefinitionAppliesTo ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationDefinitionDescription_Enabled ;
      private int edtWWPNotificationDefinitionIcon_Enabled ;
      private int edtWWPNotificationDefinitionTitle_Enabled ;
      private int edtWWPNotificationDefinitionShortDescription_Enabled ;
      private int edtWWPNotificationDefinitionLongDescription_Enabled ;
      private int edtWWPNotificationDefinitionLink_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z14WWPNotificationDefinitionId ;
      private long Z10WWPEntityId ;
      private long A10WWPEntityId ;
      private long A14WWPNotificationDefinitionId ;
      private long ZZ14WWPNotificationDefinitionId ;
      private long ZZ10WWPEntityId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string cmbWWPNotificationDefinitionAppliesTo_Internalname ;
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
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string cmbWWPNotificationDefinitionAppliesTo_Jsonclick ;
      private string chkWWPNotificationDefinitionAllowUserSubscription_Internalname ;
      private string edtWWPNotificationDefinitionDescription_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Jsonclick ;
      private string edtWWPNotificationDefinitionTitle_Internalname ;
      private string edtWWPNotificationDefinitionShortDescription_Internalname ;
      private string edtWWPNotificationDefinitionLongDescription_Internalname ;
      private string edtWWPNotificationDefinitionLink_Internalname ;
      private string edtWWPNotificationDefinitionLink_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
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
      private string sMode7 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z27WWPNotificationDefinitionAllowUserSubscription ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A27WWPNotificationDefinitionAllowUserSubscription ;
      private bool Gx_longc ;
      private bool ZZ27WWPNotificationDefinitionAllowUserSubscription ;
      private string Z53WWPNotificationDefinitionName ;
      private string Z25WWPNotificationDefinitionDescription ;
      private string Z56WWPNotificationDefinitionIcon ;
      private string Z57WWPNotificationDefinitionTitle ;
      private string Z58WWPNotificationDefinitionShortDescription ;
      private string Z59WWPNotificationDefinitionLongDescription ;
      private string Z60WWPNotificationDefinitionLink ;
      private string A53WWPNotificationDefinitionName ;
      private string A25WWPNotificationDefinitionDescription ;
      private string A56WWPNotificationDefinitionIcon ;
      private string A57WWPNotificationDefinitionTitle ;
      private string A58WWPNotificationDefinitionShortDescription ;
      private string A59WWPNotificationDefinitionLongDescription ;
      private string A60WWPNotificationDefinitionLink ;
      private string A12WWPEntityName ;
      private string Z12WWPEntityName ;
      private string ZZ53WWPNotificationDefinitionName ;
      private string ZZ25WWPNotificationDefinitionDescription ;
      private string ZZ56WWPNotificationDefinitionIcon ;
      private string ZZ57WWPNotificationDefinitionTitle ;
      private string ZZ58WWPNotificationDefinitionShortDescription ;
      private string ZZ59WWPNotificationDefinitionLongDescription ;
      private string ZZ60WWPNotificationDefinitionLink ;
      private string ZZ12WWPEntityName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPNotificationDefinitionAppliesTo ;
      private GXCheckbox chkWWPNotificationDefinitionAllowUserSubscription ;
      private IDataStoreProvider pr_default ;
      private long[] T00075_A14WWPNotificationDefinitionId ;
      private string[] T00075_A53WWPNotificationDefinitionName ;
      private short[] T00075_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] T00075_A27WWPNotificationDefinitionAllowUserSubscription ;
      private string[] T00075_A25WWPNotificationDefinitionDescription ;
      private string[] T00075_A56WWPNotificationDefinitionIcon ;
      private string[] T00075_A57WWPNotificationDefinitionTitle ;
      private string[] T00075_A58WWPNotificationDefinitionShortDescription ;
      private string[] T00075_A59WWPNotificationDefinitionLongDescription ;
      private string[] T00075_A60WWPNotificationDefinitionLink ;
      private string[] T00075_A12WWPEntityName ;
      private long[] T00075_A10WWPEntityId ;
      private string[] T00074_A12WWPEntityName ;
      private string[] T00076_A12WWPEntityName ;
      private long[] T00077_A14WWPNotificationDefinitionId ;
      private long[] T00073_A14WWPNotificationDefinitionId ;
      private string[] T00073_A53WWPNotificationDefinitionName ;
      private short[] T00073_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] T00073_A27WWPNotificationDefinitionAllowUserSubscription ;
      private string[] T00073_A25WWPNotificationDefinitionDescription ;
      private string[] T00073_A56WWPNotificationDefinitionIcon ;
      private string[] T00073_A57WWPNotificationDefinitionTitle ;
      private string[] T00073_A58WWPNotificationDefinitionShortDescription ;
      private string[] T00073_A59WWPNotificationDefinitionLongDescription ;
      private string[] T00073_A60WWPNotificationDefinitionLink ;
      private long[] T00073_A10WWPEntityId ;
      private long[] T00078_A14WWPNotificationDefinitionId ;
      private long[] T00079_A14WWPNotificationDefinitionId ;
      private long[] T00072_A14WWPNotificationDefinitionId ;
      private string[] T00072_A53WWPNotificationDefinitionName ;
      private short[] T00072_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] T00072_A27WWPNotificationDefinitionAllowUserSubscription ;
      private string[] T00072_A25WWPNotificationDefinitionDescription ;
      private string[] T00072_A56WWPNotificationDefinitionIcon ;
      private string[] T00072_A57WWPNotificationDefinitionTitle ;
      private string[] T00072_A58WWPNotificationDefinitionShortDescription ;
      private string[] T00072_A59WWPNotificationDefinitionLongDescription ;
      private string[] T00072_A60WWPNotificationDefinitionLink ;
      private long[] T00072_A10WWPEntityId ;
      private long[] T000710_A14WWPNotificationDefinitionId ;
      private string[] T000713_A12WWPEntityName ;
      private long[] T000714_A16WWPNotificationId ;
      private long[] T000715_A13WWPSubscriptionId ;
      private long[] T000716_A14WWPNotificationDefinitionId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_notificationdefinition__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00075;
        prmT00075 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00074;
        prmT00074 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00076;
        prmT00076 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00077;
        prmT00077 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00073;
        prmT00073 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00078;
        prmT00078 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00079;
        prmT00079 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00072;
        prmT00072 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000710;
        prmT000710 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationDefinitionAppliesTo",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@WWPNotificationDefinitionAllowUserSubscription",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionIcon",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPNotificationDefinitionTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionLongDescription",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationDefinitionLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000711;
        prmT000711 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationDefinitionAppliesTo",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@WWPNotificationDefinitionAllowUserSubscription",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionIcon",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPNotificationDefinitionTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationDefinitionLongDescription",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationDefinitionLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000712;
        prmT000712 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000714;
        prmT000714 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000715;
        prmT000715 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000716;
        prmT000716 = new Object[] {
        };
        Object[] prmT000713;
        prmT000713 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppliesTo], [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionDescription], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink], [WWPEntityId] FROM [WWP_NotificationDefinition] WITH (UPDLOCK) WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionAppliesTo], [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionDescription], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink], [WWPEntityId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT TM1.[WWPNotificationDefinitionId], TM1.[WWPNotificationDefinitionName], TM1.[WWPNotificationDefinitionAppliesTo], TM1.[WWPNotificationDefinitionAllowUserSubscription], TM1.[WWPNotificationDefinitionDescription], TM1.[WWPNotificationDefinitionIcon], TM1.[WWPNotificationDefinitionTitle], TM1.[WWPNotificationDefinitionShortDescription], TM1.[WWPNotificationDefinitionLongDescription], TM1.[WWPNotificationDefinitionLink], T2.[WWPEntityName], TM1.[WWPEntityId] FROM ([WWP_NotificationDefinition] TM1 INNER JOIN [WWP_Entity] T2 ON T2.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ORDER BY TM1.[WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00077", "SELECT [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00078", "SELECT TOP 1 [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE ( [WWPNotificationDefinitionId] > @WWPNotificationDefinitionId) ORDER BY [WWPNotificationDefinitionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00079", "SELECT TOP 1 [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE ( [WWPNotificationDefinitionId] < @WWPNotificationDefinitionId) ORDER BY [WWPNotificationDefinitionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000710", "INSERT INTO [WWP_NotificationDefinition]([WWPNotificationDefinitionName], [WWPNotificationDefinitionAppliesTo], [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionDescription], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink], [WWPEntityId]) VALUES(@WWPNotificationDefinitionName, @WWPNotificationDefinitionAppliesTo, @WWPNotificationDefinitionAllowUserSubscription, @WWPNotificationDefinitionDescription, @WWPNotificationDefinitionIcon, @WWPNotificationDefinitionTitle, @WWPNotificationDefinitionShortDescription, @WWPNotificationDefinitionLongDescription, @WWPNotificationDefinitionLink, @WWPEntityId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000710)
           ,new CursorDef("T000711", "UPDATE [WWP_NotificationDefinition] SET [WWPNotificationDefinitionName]=@WWPNotificationDefinitionName, [WWPNotificationDefinitionAppliesTo]=@WWPNotificationDefinitionAppliesTo, [WWPNotificationDefinitionAllowUserSubscription]=@WWPNotificationDefinitionAllowUserSubscription, [WWPNotificationDefinitionDescription]=@WWPNotificationDefinitionDescription, [WWPNotificationDefinitionIcon]=@WWPNotificationDefinitionIcon, [WWPNotificationDefinitionTitle]=@WWPNotificationDefinitionTitle, [WWPNotificationDefinitionShortDescription]=@WWPNotificationDefinitionShortDescription, [WWPNotificationDefinitionLongDescription]=@WWPNotificationDefinitionLongDescription, [WWPNotificationDefinitionLink]=@WWPNotificationDefinitionLink, [WWPEntityId]=@WWPEntityId  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmT000711)
           ,new CursorDef("T000712", "DELETE FROM [WWP_NotificationDefinition]  WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId", GxErrorMask.GX_NOMASK,prmT000712)
           ,new CursorDef("T000713", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000714", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000715", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000716", "SELECT [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] ORDER BY [WWPNotificationDefinitionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,100, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getShort(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getLong(11);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getShort(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getLong(11);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 3 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getShort(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getVarchar(11);
              table[11][0] = rslt.getLong(12);
              return;
           case 4 :
              table[0][0] = rslt.getVarchar(1);
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
              table[0][0] = rslt.getVarchar(1);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              return;
           case 13 :
              table[0][0] = rslt.getLong(1);
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 2 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
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
              stmt.SetParameter(2, (short)parms[1]);
              stmt.SetParameter(3, (bool)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (string)parms[8]);
              stmt.SetParameter(10, (long)parms[9]);
              return;
           case 9 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              stmt.SetParameter(3, (bool)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (string)parms[8]);
              stmt.SetParameter(10, (long)parms[9]);
              stmt.SetParameter(11, (long)parms[10]);
              return;
           case 10 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 13 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
