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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"WWPUSEREXTENDEDFULLNAME") == 0 )
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
            GX1ASAWWPUSEREXTENDEDFULLNAME033( A1WWPUserExtendedId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A14WWPNotificationDefinitionId = (long)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."));
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A14WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A10WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
            AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A10WWPEntityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
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
            gxLoad_5( A1WWPUserExtendedId) ;
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
            Form.Meta.addItem("description", "WWP_Subscription", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_subscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_subscription( IGxContext context )
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
         chkWWPSubscriptionSubscribed = new GXCheckbox();
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
            return "wwpsubscription_Execute" ;
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
         A23WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A23WWPSubscriptionSubscribed));
         AssignAttri("", false, "A23WWPSubscriptionSubscribed", A23WWPSubscriptionSubscribed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Subscription", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSubscriptionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13WWPSubscriptionId), 10, 0, ",", "")), ((edtWWPSubscriptionId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A13WWPSubscriptionId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A13WWPSubscriptionId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ",", "")), ((edtWWPNotificationDefinitionId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A14WWPNotificationDefinitionId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A14WWPNotificationDefinitionId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescription_Internalname, "Notification Definition Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescription_Internalname, A25WWPNotificationDefinitionDescription, "", "", 0, 1, edtWWPNotificationDefinitionDescription_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A12WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A12WWPEntityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "left", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A2WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A2WWPUserExtendedFullName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordId_Internalname, "Record Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordId_Internalname, A22WWPSubscriptionEntityRecordId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtWWPSubscriptionEntityRecordId_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordDescription_Internalname, "Record Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordDescription_Internalname, A24WWPSubscriptionEntityRecordDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtWWPSubscriptionEntityRecordDescription_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPSubscriptionRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionRoleId_Internalname, "Role Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionRoleId_Internalname, StringUtil.RTrim( A11WWPSubscriptionRoleId), StringUtil.RTrim( context.localUtil.Format( A11WWPSubscriptionRoleId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionRoleId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "left", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkWWPSubscriptionSubscribed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPSubscriptionSubscribed_Internalname, "Subscribed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPSubscriptionSubscribed_Internalname, StringUtil.BoolToStr( A23WWPSubscriptionSubscribed), "", "Subscribed", 1, chkWWPSubscriptionSubscribed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(73, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,73);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
            Z13WWPSubscriptionId = (long)(context.localUtil.CToN( cgiGet( "Z13WWPSubscriptionId"), ",", "."));
            Z22WWPSubscriptionEntityRecordId = cgiGet( "Z22WWPSubscriptionEntityRecordId");
            Z24WWPSubscriptionEntityRecordDescription = cgiGet( "Z24WWPSubscriptionEntityRecordDescription");
            Z11WWPSubscriptionRoleId = cgiGet( "Z11WWPSubscriptionRoleId");
            n11WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A11WWPSubscriptionRoleId)) ? true : false);
            Z23WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( "Z23WWPSubscriptionSubscribed"));
            Z14WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( "Z14WWPNotificationDefinitionId"), ",", "."));
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            A10WWPEntityId = (long)(context.localUtil.CToN( cgiGet( "WWPENTITYID"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSUBSCRIPTIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPSubscriptionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A13WWPSubscriptionId = 0;
               AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
            }
            else
            {
               A13WWPSubscriptionId = (long)(context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ",", "."));
               AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
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
            A25WWPNotificationDefinitionDescription = cgiGet( edtWWPNotificationDefinitionDescription_Internalname);
            AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
            A12WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
            A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A22WWPSubscriptionEntityRecordId = cgiGet( edtWWPSubscriptionEntityRecordId_Internalname);
            AssignAttri("", false, "A22WWPSubscriptionEntityRecordId", A22WWPSubscriptionEntityRecordId);
            A24WWPSubscriptionEntityRecordDescription = cgiGet( edtWWPSubscriptionEntityRecordDescription_Internalname);
            AssignAttri("", false, "A24WWPSubscriptionEntityRecordDescription", A24WWPSubscriptionEntityRecordDescription);
            A11WWPSubscriptionRoleId = cgiGet( edtWWPSubscriptionRoleId_Internalname);
            n11WWPSubscriptionRoleId = false;
            AssignAttri("", false, "A11WWPSubscriptionRoleId", A11WWPSubscriptionRoleId);
            n11WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A11WWPSubscriptionRoleId)) ? true : false);
            A23WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( chkWWPSubscriptionSubscribed_Internalname));
            AssignAttri("", false, "A23WWPSubscriptionSubscribed", A23WWPSubscriptionSubscribed);
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
               A13WWPSubscriptionId = (long)(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."));
               AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
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
               InitAll033( ) ;
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
         DisableAttributes033( ) ;
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

      protected void ResetCaption030( )
      {
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z22WWPSubscriptionEntityRecordId = T00033_A22WWPSubscriptionEntityRecordId[0];
               Z24WWPSubscriptionEntityRecordDescription = T00033_A24WWPSubscriptionEntityRecordDescription[0];
               Z11WWPSubscriptionRoleId = T00033_A11WWPSubscriptionRoleId[0];
               Z23WWPSubscriptionSubscribed = T00033_A23WWPSubscriptionSubscribed[0];
               Z14WWPNotificationDefinitionId = T00033_A14WWPNotificationDefinitionId[0];
               Z1WWPUserExtendedId = T00033_A1WWPUserExtendedId[0];
            }
            else
            {
               Z22WWPSubscriptionEntityRecordId = A22WWPSubscriptionEntityRecordId;
               Z24WWPSubscriptionEntityRecordDescription = A24WWPSubscriptionEntityRecordDescription;
               Z11WWPSubscriptionRoleId = A11WWPSubscriptionRoleId;
               Z23WWPSubscriptionSubscribed = A23WWPSubscriptionSubscribed;
               Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z13WWPSubscriptionId = A13WWPSubscriptionId;
            Z22WWPSubscriptionEntityRecordId = A22WWPSubscriptionEntityRecordId;
            Z24WWPSubscriptionEntityRecordDescription = A24WWPSubscriptionEntityRecordDescription;
            Z11WWPSubscriptionRoleId = A11WWPSubscriptionRoleId;
            Z23WWPSubscriptionSubscribed = A23WWPSubscriptionSubscribed;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z10WWPEntityId = A10WWPEntityId;
            Z25WWPNotificationDefinitionDescription = A25WWPNotificationDefinitionDescription;
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

      protected void Load033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
            A10WWPEntityId = T00037_A10WWPEntityId[0];
            A25WWPNotificationDefinitionDescription = T00037_A25WWPNotificationDefinitionDescription[0];
            AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
            A12WWPEntityName = T00037_A12WWPEntityName[0];
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
            A22WWPSubscriptionEntityRecordId = T00037_A22WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A22WWPSubscriptionEntityRecordId", A22WWPSubscriptionEntityRecordId);
            A24WWPSubscriptionEntityRecordDescription = T00037_A24WWPSubscriptionEntityRecordDescription[0];
            AssignAttri("", false, "A24WWPSubscriptionEntityRecordDescription", A24WWPSubscriptionEntityRecordDescription);
            A11WWPSubscriptionRoleId = T00037_A11WWPSubscriptionRoleId[0];
            n11WWPSubscriptionRoleId = T00037_n11WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A11WWPSubscriptionRoleId", A11WWPSubscriptionRoleId);
            A23WWPSubscriptionSubscribed = T00037_A23WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A23WWPSubscriptionSubscribed", A23WWPSubscriptionSubscribed);
            A14WWPNotificationDefinitionId = T00037_A14WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T00037_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00037_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            ZM033( -3) ;
         }
         pr_default.close(5);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10WWPEntityId = T00034_A10WWPEntityId[0];
         A25WWPNotificationDefinitionDescription = T00034_A25WWPNotificationDefinitionDescription[0];
         AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
         pr_default.close(2);
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1;
         }
         A12WWPEntityName = T00036_A12WWPEntityName[0];
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         pr_default.close(4);
         /* Using cursor T00035 */
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
         nIsDirty_3 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( long A14WWPNotificationDefinitionId )
      {
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10WWPEntityId = T00038_A10WWPEntityId[0];
         A25WWPNotificationDefinitionDescription = T00038_A25WWPNotificationDefinitionDescription[0];
         AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A25WWPNotificationDefinitionDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_6( long A10WWPEntityId )
      {
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1;
         }
         A12WWPEntityName = T00039_A12WWPEntityName[0];
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A12WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( string A1WWPUserExtendedId )
      {
         /* Using cursor T000310 */
         pr_default.execute(8, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(8) == 101) )
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
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey033( )
      {
         /* Using cursor T000311 */
         pr_default.execute(9, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 3) ;
            RcdFound3 = 1;
            A13WWPSubscriptionId = T00033_A13WWPSubscriptionId[0];
            AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
            A22WWPSubscriptionEntityRecordId = T00033_A22WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A22WWPSubscriptionEntityRecordId", A22WWPSubscriptionEntityRecordId);
            A24WWPSubscriptionEntityRecordDescription = T00033_A24WWPSubscriptionEntityRecordDescription[0];
            AssignAttri("", false, "A24WWPSubscriptionEntityRecordDescription", A24WWPSubscriptionEntityRecordDescription);
            A11WWPSubscriptionRoleId = T00033_A11WWPSubscriptionRoleId[0];
            n11WWPSubscriptionRoleId = T00033_n11WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A11WWPSubscriptionRoleId", A11WWPSubscriptionRoleId);
            A23WWPSubscriptionSubscribed = T00033_A23WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A23WWPSubscriptionSubscribed", A23WWPSubscriptionSubscribed);
            A14WWPNotificationDefinitionId = T00033_A14WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
            A1WWPUserExtendedId = T00033_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00033_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            Z13WWPSubscriptionId = A13WWPSubscriptionId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         RcdFound3 = 0;
         /* Using cursor T000312 */
         pr_default.execute(10, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000312_A13WWPSubscriptionId[0] < A13WWPSubscriptionId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000312_A13WWPSubscriptionId[0] > A13WWPSubscriptionId ) ) )
            {
               A13WWPSubscriptionId = T000312_A13WWPSubscriptionId[0];
               AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T000313 */
         pr_default.execute(11, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000313_A13WWPSubscriptionId[0] > A13WWPSubscriptionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000313_A13WWPSubscriptionId[0] < A13WWPSubscriptionId ) ) )
            {
               A13WWPSubscriptionId = T000313_A13WWPSubscriptionId[0];
               AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A13WWPSubscriptionId != Z13WWPSubscriptionId )
               {
                  A13WWPSubscriptionId = Z13WWPSubscriptionId;
                  AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSUBSCRIPTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A13WWPSubscriptionId != Z13WWPSubscriptionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSUBSCRIPTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( A13WWPSubscriptionId != Z13WWPSubscriptionId )
         {
            A13WWPSubscriptionId = Z13WWPSubscriptionId;
            AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         ScanStart033( ) ;
         if ( RcdFound3 == 0 )
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
         ScanEnd033( ) ;
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
         if ( RcdFound3 == 0 )
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
         if ( RcdFound3 == 0 )
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
         ScanStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound3 != 0 )
            {
               ScanNext033( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd033( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A13WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z22WWPSubscriptionEntityRecordId, T00032_A22WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z24WWPSubscriptionEntityRecordDescription, T00032_A24WWPSubscriptionEntityRecordDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z11WWPSubscriptionRoleId, T00032_A11WWPSubscriptionRoleId[0]) != 0 ) || ( Z23WWPSubscriptionSubscribed != T00032_A23WWPSubscriptionSubscribed[0] ) || ( Z14WWPNotificationDefinitionId != T00032_A14WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00032_A1WWPUserExtendedId[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z22WWPSubscriptionEntityRecordId, T00032_A22WWPSubscriptionEntityRecordId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordId");
                  GXUtil.WriteLogRaw("Old: ",Z22WWPSubscriptionEntityRecordId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A22WWPSubscriptionEntityRecordId[0]);
               }
               if ( StringUtil.StrCmp(Z24WWPSubscriptionEntityRecordDescription, T00032_A24WWPSubscriptionEntityRecordDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordDescription");
                  GXUtil.WriteLogRaw("Old: ",Z24WWPSubscriptionEntityRecordDescription);
                  GXUtil.WriteLogRaw("Current: ",T00032_A24WWPSubscriptionEntityRecordDescription[0]);
               }
               if ( StringUtil.StrCmp(Z11WWPSubscriptionRoleId, T00032_A11WWPSubscriptionRoleId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionRoleId");
                  GXUtil.WriteLogRaw("Old: ",Z11WWPSubscriptionRoleId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A11WWPSubscriptionRoleId[0]);
               }
               if ( Z23WWPSubscriptionSubscribed != T00032_A23WWPSubscriptionSubscribed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionSubscribed");
                  GXUtil.WriteLogRaw("Old: ",Z23WWPSubscriptionSubscribed);
                  GXUtil.WriteLogRaw("Current: ",T00032_A23WWPSubscriptionSubscribed[0]);
               }
               if ( Z14WWPNotificationDefinitionId != T00032_A14WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z14WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A14WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z1WWPUserExtendedId, T00032_A1WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z1WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A1WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         if ( ! IsAuthorized("wwpsubscription_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000314 */
                     pr_default.execute(12, new Object[] {A22WWPSubscriptionEntityRecordId, A24WWPSubscriptionEntityRecordDescription, n11WWPSubscriptionRoleId, A11WWPSubscriptionRoleId, A23WWPSubscriptionSubscribed, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A13WWPSubscriptionId = T000314_A13WWPSubscriptionId[0];
                     AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         if ( ! IsAuthorized("wwpsubscription_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000315 */
                     pr_default.execute(13, new Object[] {A22WWPSubscriptionEntityRecordId, A24WWPSubscriptionEntityRecordDescription, n11WWPSubscriptionRoleId, A11WWPSubscriptionRoleId, A23WWPSubscriptionSubscribed, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, A13WWPSubscriptionId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption030( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpsubscription_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000316 */
                  pr_default.execute(14, new Object[] {A13WWPSubscriptionId});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound3 == 0 )
                        {
                           InitAll033( ) ;
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
                        ResetCaption030( ) ;
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000317 */
            pr_default.execute(15, new Object[] {A14WWPNotificationDefinitionId});
            A10WWPEntityId = T000317_A10WWPEntityId[0];
            A25WWPNotificationDefinitionDescription = T000317_A25WWPNotificationDefinitionDescription[0];
            AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
            pr_default.close(15);
            /* Using cursor T000318 */
            pr_default.execute(16, new Object[] {A10WWPEntityId});
            A12WWPEntityName = T000318_A12WWPEntityName[0];
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
            pr_default.close(16);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Using cursor T000319 */
         pr_default.execute(17);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound3 = 1;
            A13WWPSubscriptionId = T000319_A13WWPSubscriptionId[0];
            AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound3 = 1;
            A13WWPSubscriptionId = T000319_A13WWPSubscriptionId[0];
            AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm033( )
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

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtWWPSubscriptionId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescription_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescription_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordId_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordDescription_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordDescription_Enabled), 5, 0), true);
         edtWWPSubscriptionRoleId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionRoleId_Enabled), 5, 0), true);
         chkWWPSubscriptionSubscribed.Enabled = 0;
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPSubscriptionSubscribed.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815474561", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z13WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13WWPSubscriptionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z22WWPSubscriptionEntityRecordId", Z22WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z24WWPSubscriptionEntityRecordDescription", Z24WWPSubscriptionEntityRecordDescription);
         GxWebStd.gx_hidden_field( context, "Z11WWPSubscriptionRoleId", StringUtil.RTrim( Z11WWPSubscriptionRoleId));
         GxWebStd.gx_boolean_hidden_field( context, "Z23WWPSubscriptionSubscribed", Z23WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, "Z14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Subscriptions.WWP_Subscription" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Subscription" ;
      }

      protected void InitializeNonKey033( )
      {
         A10WWPEntityId = 0;
         AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
         A2WWPUserExtendedFullName = "";
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A14WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A14WWPNotificationDefinitionId), 10, 0));
         A25WWPNotificationDefinitionDescription = "";
         AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
         A12WWPEntityName = "";
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         n1WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ? true : false);
         A22WWPSubscriptionEntityRecordId = "";
         AssignAttri("", false, "A22WWPSubscriptionEntityRecordId", A22WWPSubscriptionEntityRecordId);
         A24WWPSubscriptionEntityRecordDescription = "";
         AssignAttri("", false, "A24WWPSubscriptionEntityRecordDescription", A24WWPSubscriptionEntityRecordDescription);
         A11WWPSubscriptionRoleId = "";
         n11WWPSubscriptionRoleId = false;
         AssignAttri("", false, "A11WWPSubscriptionRoleId", A11WWPSubscriptionRoleId);
         n11WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A11WWPSubscriptionRoleId)) ? true : false);
         A23WWPSubscriptionSubscribed = false;
         AssignAttri("", false, "A23WWPSubscriptionSubscribed", A23WWPSubscriptionSubscribed);
         Z22WWPSubscriptionEntityRecordId = "";
         Z24WWPSubscriptionEntityRecordDescription = "";
         Z11WWPSubscriptionRoleId = "";
         Z23WWPSubscriptionSubscribed = false;
         Z14WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll033( )
      {
         A13WWPSubscriptionId = 0;
         AssignAttri("", false, "A13WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A13WWPSubscriptionId), 10, 0));
         InitializeNonKey033( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815474574", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscription.js", "?202142815474574", false, true);
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
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionDescription_Internalname = "WWPNOTIFICATIONDEFINITIONDESCRIPTION";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPSubscriptionEntityRecordId_Internalname = "WWPSUBSCRIPTIONENTITYRECORDID";
         edtWWPSubscriptionEntityRecordDescription_Internalname = "WWPSUBSCRIPTIONENTITYRECORDDESCRIPTION";
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID";
         chkWWPSubscriptionSubscribed_Internalname = "WWPSUBSCRIPTIONSUBSCRIBED";
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
         Form.Caption = "WWP_Subscription";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPSubscriptionSubscribed.Enabled = 1;
         edtWWPSubscriptionRoleId_Jsonclick = "";
         edtWWPSubscriptionRoleId_Enabled = 1;
         edtWWPSubscriptionEntityRecordDescription_Enabled = 1;
         edtWWPSubscriptionEntityRecordId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPNotificationDefinitionDescription_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPSubscriptionId_Jsonclick = "";
         edtWWPSubscriptionId_Enabled = 1;
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

      protected void GX1ASAWWPUSEREXTENDEDFULLNAME033( string A1WWPUserExtendedId )
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
         chkWWPSubscriptionSubscribed.Name = "WWPSUBSCRIPTIONSUBSCRIBED";
         chkWWPSubscriptionSubscribed.WebTags = "";
         chkWWPSubscriptionSubscribed.Caption = "";
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "TitleCaption", chkWWPSubscriptionSubscribed.Caption, true);
         chkWWPSubscriptionSubscribed.CheckedValue = "false";
         A23WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A23WWPSubscriptionSubscribed));
         AssignAttri("", false, "A23WWPSubscriptionSubscribed", A23WWPSubscriptionSubscribed);
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

      public void Valid_Wwpsubscriptionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A23WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A23WWPSubscriptionSubscribed));
         /*  Sending validation outputs */
         AssignAttri("", false, "A14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A1WWPUserExtendedId", StringUtil.RTrim( A1WWPUserExtendedId));
         AssignAttri("", false, "A22WWPSubscriptionEntityRecordId", A22WWPSubscriptionEntityRecordId);
         AssignAttri("", false, "A24WWPSubscriptionEntityRecordDescription", A24WWPSubscriptionEntityRecordDescription);
         AssignAttri("", false, "A11WWPSubscriptionRoleId", StringUtil.RTrim( A11WWPSubscriptionRoleId));
         AssignAttri("", false, "A23WWPSubscriptionSubscribed", A23WWPSubscriptionSubscribed);
         AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z13WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13WWPSubscriptionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z22WWPSubscriptionEntityRecordId", Z22WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z24WWPSubscriptionEntityRecordDescription", Z24WWPSubscriptionEntityRecordDescription);
         GxWebStd.gx_hidden_field( context, "Z11WWPSubscriptionRoleId", StringUtil.RTrim( Z11WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, "Z23WWPSubscriptionSubscribed", StringUtil.BoolToStr( Z23WWPSubscriptionSubscribed));
         GxWebStd.gx_hidden_field( context, "Z10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z25WWPNotificationDefinitionDescription", Z25WWPNotificationDefinitionDescription);
         GxWebStd.gx_hidden_field( context, "Z12WWPEntityName", Z12WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z2WWPUserExtendedFullName", Z2WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000317 */
         pr_default.execute(15, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A10WWPEntityId = T000317_A10WWPEntityId[0];
         A25WWPNotificationDefinitionDescription = T000317_A25WWPNotificationDefinitionDescription[0];
         pr_default.close(15);
         /* Using cursor T000318 */
         pr_default.execute(16, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1;
         }
         A12WWPEntityName = T000318_A12WWPEntityName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A25WWPNotificationDefinitionDescription", A25WWPNotificationDefinitionDescription);
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n1WWPUserExtendedId = false;
         /* Using cursor T000320 */
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID","{handler:'Valid_Wwpsubscriptionid',iparms:[{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID",",oparms:[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A24WWPSubscriptionEntityRecordDescription',fld:'WWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z13WWPSubscriptionId'},{av:'Z14WWPNotificationDefinitionId'},{av:'Z1WWPUserExtendedId'},{av:'Z22WWPSubscriptionEntityRecordId'},{av:'Z24WWPSubscriptionEntityRecordDescription'},{av:'Z11WWPSubscriptionRoleId'},{av:'Z23WWPSubscriptionSubscribed'},{av:'Z10WWPEntityId'},{av:'Z25WWPNotificationDefinitionDescription'},{av:'Z12WWPEntityName'},{av:'Z2WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
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
         pr_default.close(15);
         pr_default.close(18);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z22WWPSubscriptionEntityRecordId = "";
         Z24WWPSubscriptionEntityRecordDescription = "";
         Z11WWPSubscriptionRoleId = "";
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
         A25WWPNotificationDefinitionDescription = "";
         A12WWPEntityName = "";
         A2WWPUserExtendedFullName = "";
         A22WWPSubscriptionEntityRecordId = "";
         A24WWPSubscriptionEntityRecordDescription = "";
         A11WWPSubscriptionRoleId = "";
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
         Z25WWPNotificationDefinitionDescription = "";
         Z12WWPEntityName = "";
         T00037_A10WWPEntityId = new long[1] ;
         T00037_A13WWPSubscriptionId = new long[1] ;
         T00037_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         T00037_A12WWPEntityName = new string[] {""} ;
         T00037_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00037_A24WWPSubscriptionEntityRecordDescription = new string[] {""} ;
         T00037_A11WWPSubscriptionRoleId = new string[] {""} ;
         T00037_n11WWPSubscriptionRoleId = new bool[] {false} ;
         T00037_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         T00037_A14WWPNotificationDefinitionId = new long[1] ;
         T00037_A1WWPUserExtendedId = new string[] {""} ;
         T00037_n1WWPUserExtendedId = new bool[] {false} ;
         T00034_A10WWPEntityId = new long[1] ;
         T00034_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         T00036_A12WWPEntityName = new string[] {""} ;
         T00035_A1WWPUserExtendedId = new string[] {""} ;
         T00035_n1WWPUserExtendedId = new bool[] {false} ;
         T00038_A10WWPEntityId = new long[1] ;
         T00038_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         T00039_A12WWPEntityName = new string[] {""} ;
         T000310_A1WWPUserExtendedId = new string[] {""} ;
         T000310_n1WWPUserExtendedId = new bool[] {false} ;
         T000311_A13WWPSubscriptionId = new long[1] ;
         T00033_A13WWPSubscriptionId = new long[1] ;
         T00033_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00033_A24WWPSubscriptionEntityRecordDescription = new string[] {""} ;
         T00033_A11WWPSubscriptionRoleId = new string[] {""} ;
         T00033_n11WWPSubscriptionRoleId = new bool[] {false} ;
         T00033_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         T00033_A14WWPNotificationDefinitionId = new long[1] ;
         T00033_A1WWPUserExtendedId = new string[] {""} ;
         T00033_n1WWPUserExtendedId = new bool[] {false} ;
         sMode3 = "";
         T000312_A13WWPSubscriptionId = new long[1] ;
         T000313_A13WWPSubscriptionId = new long[1] ;
         T00032_A13WWPSubscriptionId = new long[1] ;
         T00032_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00032_A24WWPSubscriptionEntityRecordDescription = new string[] {""} ;
         T00032_A11WWPSubscriptionRoleId = new string[] {""} ;
         T00032_n11WWPSubscriptionRoleId = new bool[] {false} ;
         T00032_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         T00032_A14WWPNotificationDefinitionId = new long[1] ;
         T00032_A1WWPUserExtendedId = new string[] {""} ;
         T00032_n1WWPUserExtendedId = new bool[] {false} ;
         T000314_A13WWPSubscriptionId = new long[1] ;
         T000317_A10WWPEntityId = new long[1] ;
         T000317_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         T000318_A12WWPEntityName = new string[] {""} ;
         T000319_A13WWPSubscriptionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z2WWPUserExtendedFullName = "";
         ZZ1WWPUserExtendedId = "";
         ZZ22WWPSubscriptionEntityRecordId = "";
         ZZ24WWPSubscriptionEntityRecordDescription = "";
         ZZ11WWPSubscriptionRoleId = "";
         ZZ25WWPNotificationDefinitionDescription = "";
         ZZ12WWPEntityName = "";
         ZZ2WWPUserExtendedFullName = "";
         T000320_A1WWPUserExtendedId = new string[] {""} ;
         T000320_n1WWPUserExtendedId = new bool[] {false} ;
         GXt_char1 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__default(),
            new Object[][] {
                new Object[] {
               T00032_A13WWPSubscriptionId, T00032_A22WWPSubscriptionEntityRecordId, T00032_A24WWPSubscriptionEntityRecordDescription, T00032_A11WWPSubscriptionRoleId, T00032_n11WWPSubscriptionRoleId, T00032_A23WWPSubscriptionSubscribed, T00032_A14WWPNotificationDefinitionId, T00032_A1WWPUserExtendedId, T00032_n1WWPUserExtendedId
               }
               , new Object[] {
               T00033_A13WWPSubscriptionId, T00033_A22WWPSubscriptionEntityRecordId, T00033_A24WWPSubscriptionEntityRecordDescription, T00033_A11WWPSubscriptionRoleId, T00033_n11WWPSubscriptionRoleId, T00033_A23WWPSubscriptionSubscribed, T00033_A14WWPNotificationDefinitionId, T00033_A1WWPUserExtendedId, T00033_n1WWPUserExtendedId
               }
               , new Object[] {
               T00034_A10WWPEntityId, T00034_A25WWPNotificationDefinitionDescription
               }
               , new Object[] {
               T00035_A1WWPUserExtendedId
               }
               , new Object[] {
               T00036_A12WWPEntityName
               }
               , new Object[] {
               T00037_A10WWPEntityId, T00037_A13WWPSubscriptionId, T00037_A25WWPNotificationDefinitionDescription, T00037_A12WWPEntityName, T00037_A22WWPSubscriptionEntityRecordId, T00037_A24WWPSubscriptionEntityRecordDescription, T00037_A11WWPSubscriptionRoleId, T00037_n11WWPSubscriptionRoleId, T00037_A23WWPSubscriptionSubscribed, T00037_A14WWPNotificationDefinitionId,
               T00037_A1WWPUserExtendedId, T00037_n1WWPUserExtendedId
               }
               , new Object[] {
               T00038_A10WWPEntityId, T00038_A25WWPNotificationDefinitionDescription
               }
               , new Object[] {
               T00039_A12WWPEntityName
               }
               , new Object[] {
               T000310_A1WWPUserExtendedId
               }
               , new Object[] {
               T000311_A13WWPSubscriptionId
               }
               , new Object[] {
               T000312_A13WWPSubscriptionId
               }
               , new Object[] {
               T000313_A13WWPSubscriptionId
               }
               , new Object[] {
               T000314_A13WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000317_A10WWPEntityId, T000317_A25WWPNotificationDefinitionDescription
               }
               , new Object[] {
               T000318_A12WWPEntityName
               }
               , new Object[] {
               T000319_A13WWPSubscriptionId
               }
               , new Object[] {
               T000320_A1WWPUserExtendedId
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
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSubscriptionId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionDescription_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPSubscriptionEntityRecordId_Enabled ;
      private int edtWWPSubscriptionEntityRecordDescription_Enabled ;
      private int edtWWPSubscriptionRoleId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z13WWPSubscriptionId ;
      private long Z14WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private long A10WWPEntityId ;
      private long A13WWPSubscriptionId ;
      private long Z10WWPEntityId ;
      private long ZZ13WWPSubscriptionId ;
      private long ZZ14WWPNotificationDefinitionId ;
      private long ZZ10WWPEntityId ;
      private string sPrefix ;
      private string Z11WWPSubscriptionRoleId ;
      private string Z1WWPUserExtendedId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSubscriptionId_Internalname ;
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
      private string edtWWPSubscriptionId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionDescription_Internalname ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPSubscriptionEntityRecordId_Internalname ;
      private string edtWWPSubscriptionEntityRecordDescription_Internalname ;
      private string edtWWPSubscriptionRoleId_Internalname ;
      private string A11WWPSubscriptionRoleId ;
      private string edtWWPSubscriptionRoleId_Jsonclick ;
      private string chkWWPSubscriptionSubscribed_Internalname ;
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
      private string sMode3 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1WWPUserExtendedId ;
      private string ZZ11WWPSubscriptionRoleId ;
      private string GXt_char1 ;
      private bool Z23WWPSubscriptionSubscribed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1WWPUserExtendedId ;
      private bool wbErr ;
      private bool A23WWPSubscriptionSubscribed ;
      private bool n11WWPSubscriptionRoleId ;
      private bool Gx_longc ;
      private bool ZZ23WWPSubscriptionSubscribed ;
      private string Z22WWPSubscriptionEntityRecordId ;
      private string Z24WWPSubscriptionEntityRecordDescription ;
      private string A25WWPNotificationDefinitionDescription ;
      private string A12WWPEntityName ;
      private string A2WWPUserExtendedFullName ;
      private string A22WWPSubscriptionEntityRecordId ;
      private string A24WWPSubscriptionEntityRecordDescription ;
      private string Z25WWPNotificationDefinitionDescription ;
      private string Z12WWPEntityName ;
      private string Z2WWPUserExtendedFullName ;
      private string ZZ22WWPSubscriptionEntityRecordId ;
      private string ZZ24WWPSubscriptionEntityRecordDescription ;
      private string ZZ25WWPNotificationDefinitionDescription ;
      private string ZZ12WWPEntityName ;
      private string ZZ2WWPUserExtendedFullName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPSubscriptionSubscribed ;
      private IDataStoreProvider pr_default ;
      private long[] T00037_A10WWPEntityId ;
      private long[] T00037_A13WWPSubscriptionId ;
      private string[] T00037_A25WWPNotificationDefinitionDescription ;
      private string[] T00037_A12WWPEntityName ;
      private string[] T00037_A22WWPSubscriptionEntityRecordId ;
      private string[] T00037_A24WWPSubscriptionEntityRecordDescription ;
      private string[] T00037_A11WWPSubscriptionRoleId ;
      private bool[] T00037_n11WWPSubscriptionRoleId ;
      private bool[] T00037_A23WWPSubscriptionSubscribed ;
      private long[] T00037_A14WWPNotificationDefinitionId ;
      private string[] T00037_A1WWPUserExtendedId ;
      private bool[] T00037_n1WWPUserExtendedId ;
      private long[] T00034_A10WWPEntityId ;
      private string[] T00034_A25WWPNotificationDefinitionDescription ;
      private string[] T00036_A12WWPEntityName ;
      private string[] T00035_A1WWPUserExtendedId ;
      private bool[] T00035_n1WWPUserExtendedId ;
      private long[] T00038_A10WWPEntityId ;
      private string[] T00038_A25WWPNotificationDefinitionDescription ;
      private string[] T00039_A12WWPEntityName ;
      private string[] T000310_A1WWPUserExtendedId ;
      private bool[] T000310_n1WWPUserExtendedId ;
      private long[] T000311_A13WWPSubscriptionId ;
      private long[] T00033_A13WWPSubscriptionId ;
      private string[] T00033_A22WWPSubscriptionEntityRecordId ;
      private string[] T00033_A24WWPSubscriptionEntityRecordDescription ;
      private string[] T00033_A11WWPSubscriptionRoleId ;
      private bool[] T00033_n11WWPSubscriptionRoleId ;
      private bool[] T00033_A23WWPSubscriptionSubscribed ;
      private long[] T00033_A14WWPNotificationDefinitionId ;
      private string[] T00033_A1WWPUserExtendedId ;
      private bool[] T00033_n1WWPUserExtendedId ;
      private long[] T000312_A13WWPSubscriptionId ;
      private long[] T000313_A13WWPSubscriptionId ;
      private long[] T00032_A13WWPSubscriptionId ;
      private string[] T00032_A22WWPSubscriptionEntityRecordId ;
      private string[] T00032_A24WWPSubscriptionEntityRecordDescription ;
      private string[] T00032_A11WWPSubscriptionRoleId ;
      private bool[] T00032_n11WWPSubscriptionRoleId ;
      private bool[] T00032_A23WWPSubscriptionSubscribed ;
      private long[] T00032_A14WWPNotificationDefinitionId ;
      private string[] T00032_A1WWPUserExtendedId ;
      private bool[] T00032_n1WWPUserExtendedId ;
      private long[] T000314_A13WWPSubscriptionId ;
      private long[] T000317_A10WWPEntityId ;
      private string[] T000317_A25WWPNotificationDefinitionDescription ;
      private string[] T000318_A12WWPEntityName ;
      private long[] T000319_A13WWPSubscriptionId ;
      private string[] T000320_A1WWPUserExtendedId ;
      private bool[] T000320_n1WWPUserExtendedId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_subscription__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
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
        Object[] prmT00037;
        prmT00037 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00034;
        prmT00034 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00036;
        prmT00036 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00035;
        prmT00035 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00038;
        prmT00038 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00039;
        prmT00039 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000310;
        prmT000310 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000311;
        prmT000311 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00033;
        prmT00033 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000312;
        prmT000312 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000313;
        prmT000313 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT00032;
        prmT00032 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000314;
        prmT000314 = new Object[] {
        new Object[] {"@WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0} ,
        new Object[] {"@WWPSubscriptionEntityRecordDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPSubscriptionRoleId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPSubscriptionSubscribed",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000315;
        prmT000315 = new Object[] {
        new Object[] {"@WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0} ,
        new Object[] {"@WWPSubscriptionEntityRecordDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPSubscriptionRoleId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPSubscriptionSubscribed",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000316;
        prmT000316 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000319;
        prmT000319 = new Object[] {
        };
        Object[] prmT000317;
        prmT000317 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000318;
        prmT000318 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000320;
        prmT000320 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("T00032", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDescription], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WITH (UPDLOCK) WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00033", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDescription], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00034", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescription] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00035", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00036", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00037", "SELECT T2.[WWPEntityId], TM1.[WWPSubscriptionId], T2.[WWPNotificationDefinitionDescription], T3.[WWPEntityName], TM1.[WWPSubscriptionEntityRecordId], TM1.[WWPSubscriptionEntityRecordDescription], TM1.[WWPSubscriptionRoleId], TM1.[WWPSubscriptionSubscribed], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM (([WWP_Subscription] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = T2.[WWPEntityId]) WHERE TM1.[WWPSubscriptionId] = @WWPSubscriptionId ORDER BY TM1.[WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00038", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescription] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00039", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000310", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000311", "SELECT [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000311,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000312", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE ( [WWPSubscriptionId] > @WWPSubscriptionId) ORDER BY [WWPSubscriptionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000312,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000313", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE ( [WWPSubscriptionId] < @WWPSubscriptionId) ORDER BY [WWPSubscriptionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000314", "INSERT INTO [WWP_Subscription]([WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDescription], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPSubscriptionEntityRecordId, @WWPSubscriptionEntityRecordDescription, @WWPSubscriptionRoleId, @WWPSubscriptionSubscribed, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000314)
           ,new CursorDef("T000315", "UPDATE [WWP_Subscription] SET [WWPSubscriptionEntityRecordId]=@WWPSubscriptionEntityRecordId, [WWPSubscriptionEntityRecordDescription]=@WWPSubscriptionEntityRecordDescription, [WWPSubscriptionRoleId]=@WWPSubscriptionRoleId, [WWPSubscriptionSubscribed]=@WWPSubscriptionSubscribed, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmT000315)
           ,new CursorDef("T000316", "DELETE FROM [WWP_Subscription]  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmT000316)
           ,new CursorDef("T000317", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescription] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000318", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000319", "SELECT [WWPSubscriptionId] FROM [WWP_Subscription] ORDER BY [WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000319,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000320", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000320,1, GxCacheFrequency.OFF ,true,false )
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
              table[3][0] = rslt.getString(4, 40);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getBool(5);
              table[6][0] = rslt.getLong(6);
              table[7][0] = rslt.getString(7, 40);
              table[8][0] = rslt.wasNull(7);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getBool(5);
              table[6][0] = rslt.getLong(6);
              table[7][0] = rslt.getString(7, 40);
              table[8][0] = rslt.wasNull(7);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 4 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getString(7, 40);
              table[7][0] = rslt.wasNull(7);
              table[8][0] = rslt.getBool(8);
              table[9][0] = rslt.getLong(9);
              table[10][0] = rslt.getString(10, 40);
              table[11][0] = rslt.wasNull(10);
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 7 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 8 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              return;
           case 11 :
              table[0][0] = rslt.getLong(1);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              return;
           case 15 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 16 :
              table[0][0] = rslt.getVarchar(1);
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              stmt.SetParameter(4, (bool)parms[4]);
              stmt.SetParameter(5, (long)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 6 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(6, (string)parms[7]);
              }
              return;
           case 13 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              stmt.SetParameter(4, (bool)parms[4]);
              stmt.SetParameter(5, (long)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 6 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(6, (string)parms[7]);
              }
              stmt.SetParameter(7, (long)parms[8]);
              return;
           case 14 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 15 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 16 :
              stmt.SetParameter(1, (long)parms[0]);
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
