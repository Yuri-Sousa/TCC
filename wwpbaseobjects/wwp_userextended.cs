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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"WWPUSEREXTENDEDPHONE") == 0 )
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
            GX1ASAWWPUSEREXTENDEDPHONE011( A1WWPUserExtendedId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel2"+"_"+"WWPUSEREXTENDEDEMAIL") == 0 )
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
            GX2ASAWWPUSEREXTENDEDEMAIL011( A1WWPUserExtendedId) ;
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
            GX3ASAWWPUSEREXTENDEDFULLNAME011( A1WWPUserExtendedId) ;
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
            Form.Meta.addItem("description", "Extended User from GAMUser", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_userextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_userextended( IGxContext context )
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
         chkWWPUserExtendedSMSNotif = new GXCheckbox();
         chkWWPUserExtendedMobileNotif = new GXCheckbox();
         chkWWPUserExtendedDesktopNotif = new GXCheckbox();
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
            return "wwpuserextended_Execute" ;
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
         A6WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A6WWPUserExtendedSMSNotif", A6WWPUserExtendedSMSNotif);
         A7WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A7WWPUserExtendedMobileNotif", A7WWPUserExtendedMobileNotif);
         A8WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A8WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A8WWPUserExtendedDesktopNotif", A8WWPUserExtendedDesktopNotif);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Extended User from GAMUser", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "left", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgWWPUserExtendedPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A4WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", "", "", 0, A4WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A4WWPUserExtendedPhoto)), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A4WWPUserExtendedPhoto_IsBlob), true);
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
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A2WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A2WWPUserExtendedFullName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPUserExtendedPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedPhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A9WWPUserExtendedPhone);
         }
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedPhone_Internalname, StringUtil.RTrim( A9WWPUserExtendedPhone), StringUtil.RTrim( context.localUtil.Format( A9WWPUserExtendedPhone, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtWWPUserExtendedPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmail_Internalname, A3WWPUserExtendedEmail, StringUtil.RTrim( context.localUtil.Format( A3WWPUserExtendedEmail, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A3WWPUserExtendedEmail, "", "", "", edtWWPUserExtendedEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmaiNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmaiNotif_Internalname, "Email Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmaiNotif_Internalname, StringUtil.BoolToStr( A5WWPUserExtendedEmaiNotif), StringUtil.BoolToStr( A5WWPUserExtendedEmaiNotif), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedEmaiNotif_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmaiNotif_Enabled, 0, "text", "", 100, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkWWPUserExtendedSMSNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedSMSNotif_Internalname, "SMS Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedSMSNotif_Internalname, StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif), "", "SMS Notifications", 1, chkWWPUserExtendedSMSNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(58, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,58);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkWWPUserExtendedMobileNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedMobileNotif_Internalname, "Mobile Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedMobileNotif_Internalname, StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif), "", "Mobile Notifications", 1, chkWWPUserExtendedMobileNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(63, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,63);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkWWPUserExtendedDesktopNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedDesktopNotif_Internalname, "Destkop Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedDesktopNotif_Internalname, StringUtil.BoolToStr( A8WWPUserExtendedDesktopNotif), "", "Destkop Notifications", 1, chkWWPUserExtendedDesktopNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,68);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            Z5WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( "Z5WWPUserExtendedEmaiNotif"));
            Z6WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( "Z6WWPUserExtendedSMSNotif"));
            Z7WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( "Z7WWPUserExtendedMobileNotif"));
            Z8WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( "Z8WWPUserExtendedDesktopNotif"));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
            /* Read variables values. */
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A4WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            A9WWPUserExtendedPhone = cgiGet( edtWWPUserExtendedPhone_Internalname);
            AssignAttri("", false, "A9WWPUserExtendedPhone", A9WWPUserExtendedPhone);
            A3WWPUserExtendedEmail = cgiGet( edtWWPUserExtendedEmail_Internalname);
            AssignAttri("", false, "A3WWPUserExtendedEmail", A3WWPUserExtendedEmail);
            A5WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( edtWWPUserExtendedEmaiNotif_Internalname));
            AssignAttri("", false, "A5WWPUserExtendedEmaiNotif", A5WWPUserExtendedEmaiNotif);
            A6WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedSMSNotif_Internalname));
            AssignAttri("", false, "A6WWPUserExtendedSMSNotif", A6WWPUserExtendedSMSNotif);
            A7WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedMobileNotif_Internalname));
            AssignAttri("", false, "A7WWPUserExtendedMobileNotif", A7WWPUserExtendedMobileNotif);
            A8WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedDesktopNotif_Internalname));
            AssignAttri("", false, "A8WWPUserExtendedDesktopNotif", A8WWPUserExtendedDesktopNotif);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgWWPUserExtendedPhoto_Internalname, ref  A4WWPUserExtendedPhoto, ref  A40000WWPUserExtendedPhoto_GXI);
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
               A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
               n1WWPUserExtendedId = false;
               AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
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
               InitAll011( ) ;
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
         DisableAttributes011( ) ;
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

      protected void ResetCaption010( )
      {
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z5WWPUserExtendedEmaiNotif = T00013_A5WWPUserExtendedEmaiNotif[0];
               Z6WWPUserExtendedSMSNotif = T00013_A6WWPUserExtendedSMSNotif[0];
               Z7WWPUserExtendedMobileNotif = T00013_A7WWPUserExtendedMobileNotif[0];
               Z8WWPUserExtendedDesktopNotif = T00013_A8WWPUserExtendedDesktopNotif[0];
            }
            else
            {
               Z5WWPUserExtendedEmaiNotif = A5WWPUserExtendedEmaiNotif;
               Z6WWPUserExtendedSMSNotif = A6WWPUserExtendedSMSNotif;
               Z7WWPUserExtendedMobileNotif = A7WWPUserExtendedMobileNotif;
               Z8WWPUserExtendedDesktopNotif = A8WWPUserExtendedDesktopNotif;
            }
         }
         if ( GX_JID == -4 )
         {
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z4WWPUserExtendedPhoto = A4WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z5WWPUserExtendedEmaiNotif = A5WWPUserExtendedEmaiNotif;
            Z6WWPUserExtendedSMSNotif = A6WWPUserExtendedSMSNotif;
            Z7WWPUserExtendedMobileNotif = A7WWPUserExtendedMobileNotif;
            Z8WWPUserExtendedDesktopNotif = A8WWPUserExtendedDesktopNotif;
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

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A40000WWPUserExtendedPhoto_GXI = T00014_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A5WWPUserExtendedEmaiNotif = T00014_A5WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A5WWPUserExtendedEmaiNotif", A5WWPUserExtendedEmaiNotif);
            A6WWPUserExtendedSMSNotif = T00014_A6WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A6WWPUserExtendedSMSNotif", A6WWPUserExtendedSMSNotif);
            A7WWPUserExtendedMobileNotif = T00014_A7WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A7WWPUserExtendedMobileNotif", A7WWPUserExtendedMobileNotif);
            A8WWPUserExtendedDesktopNotif = T00014_A8WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A8WWPUserExtendedDesktopNotif", A8WWPUserExtendedDesktopNotif);
            A4WWPUserExtendedPhoto = T00014_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            ZM011( -4) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         GXt_char1 = A9WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A9WWPUserExtendedPhone = GXt_char1;
         AssignAttri("", false, "A9WWPUserExtendedPhone", A9WWPUserExtendedPhone);
         GXt_char1 = A3WWPUserExtendedEmail;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A3WWPUserExtendedEmail = GXt_char1;
         AssignAttri("", false, "A3WWPUserExtendedEmail", A3WWPUserExtendedEmail);
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         nIsDirty_1 = 1;
         GXt_char1 = A9WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A9WWPUserExtendedPhone = GXt_char1;
         AssignAttri("", false, "A9WWPUserExtendedPhone", A9WWPUserExtendedPhone);
         nIsDirty_1 = 1;
         GXt_char1 = A3WWPUserExtendedEmail;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A3WWPUserExtendedEmail = GXt_char1;
         AssignAttri("", false, "A3WWPUserExtendedEmail", A3WWPUserExtendedEmail);
         nIsDirty_1 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 4) ;
            RcdFound1 = 1;
            A1WWPUserExtendedId = T00013_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T00013_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A40000WWPUserExtendedPhoto_GXI = T00013_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A5WWPUserExtendedEmaiNotif = T00013_A5WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A5WWPUserExtendedEmaiNotif", A5WWPUserExtendedEmaiNotif);
            A6WWPUserExtendedSMSNotif = T00013_A6WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A6WWPUserExtendedSMSNotif", A6WWPUserExtendedSMSNotif);
            A7WWPUserExtendedMobileNotif = T00013_A7WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A7WWPUserExtendedMobileNotif", A7WWPUserExtendedMobileNotif);
            A8WWPUserExtendedDesktopNotif = T00013_A8WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A8WWPUserExtendedDesktopNotif", A8WWPUserExtendedDesktopNotif);
            A4WWPUserExtendedPhoto = T00013_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00016_A1WWPUserExtendedId[0], A1WWPUserExtendedId) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00016_A1WWPUserExtendedId[0], A1WWPUserExtendedId) > 0 ) ) )
            {
               A1WWPUserExtendedId = T00016_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = T00016_n1WWPUserExtendedId[0];
               AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00017_A1WWPUserExtendedId[0], A1WWPUserExtendedId) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00017_A1WWPUserExtendedId[0], A1WWPUserExtendedId) < 0 ) ) )
            {
               A1WWPUserExtendedId = T00017_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = T00017_n1WWPUserExtendedId[0];
               AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( StringUtil.StrCmp(A1WWPUserExtendedId, Z1WWPUserExtendedId) != 0 )
               {
                  A1WWPUserExtendedId = Z1WWPUserExtendedId;
                  n1WWPUserExtendedId = false;
                  AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPUSEREXTENDEDID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A1WWPUserExtendedId, Z1WWPUserExtendedId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPUSEREXTENDEDID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( StringUtil.StrCmp(A1WWPUserExtendedId, Z1WWPUserExtendedId) != 0 )
         {
            A1WWPUserExtendedId = Z1WWPUserExtendedId;
            n1WWPUserExtendedId = false;
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z5WWPUserExtendedEmaiNotif != T00012_A5WWPUserExtendedEmaiNotif[0] ) || ( Z6WWPUserExtendedSMSNotif != T00012_A6WWPUserExtendedSMSNotif[0] ) || ( Z7WWPUserExtendedMobileNotif != T00012_A7WWPUserExtendedMobileNotif[0] ) || ( Z8WWPUserExtendedDesktopNotif != T00012_A8WWPUserExtendedDesktopNotif[0] ) )
            {
               if ( Z5WWPUserExtendedEmaiNotif != T00012_A5WWPUserExtendedEmaiNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedEmaiNotif");
                  GXUtil.WriteLogRaw("Old: ",Z5WWPUserExtendedEmaiNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5WWPUserExtendedEmaiNotif[0]);
               }
               if ( Z6WWPUserExtendedSMSNotif != T00012_A6WWPUserExtendedSMSNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedSMSNotif");
                  GXUtil.WriteLogRaw("Old: ",Z6WWPUserExtendedSMSNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A6WWPUserExtendedSMSNotif[0]);
               }
               if ( Z7WWPUserExtendedMobileNotif != T00012_A7WWPUserExtendedMobileNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedMobileNotif");
                  GXUtil.WriteLogRaw("Old: ",Z7WWPUserExtendedMobileNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A7WWPUserExtendedMobileNotif[0]);
               }
               if ( Z8WWPUserExtendedDesktopNotif != T00012_A8WWPUserExtendedDesktopNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDesktopNotif");
                  GXUtil.WriteLogRaw("Old: ",Z8WWPUserExtendedDesktopNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A8WWPUserExtendedDesktopNotif[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         if ( ! IsAuthorized("wwpuserextended_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId, A4WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A5WWPUserExtendedEmaiNotif, A6WWPUserExtendedSMSNotif, A7WWPUserExtendedMobileNotif, A8WWPUserExtendedDesktopNotif});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         if ( ! IsAuthorized("wwpuserextended_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {A5WWPUserExtendedEmaiNotif, A6WWPUserExtendedSMSNotif, A7WWPUserExtendedMobileNotif, A8WWPUserExtendedDesktopNotif, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption010( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000110 */
            pr_default.execute(8, new Object[] {A4WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n1WWPUserExtendedId, A1WWPUserExtendedId});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpuserextended_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000111 */
                  pr_default.execute(9, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll011( ) ;
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
                        ResetCaption010( ) ;
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_char1 = A9WWPUserExtendedPhone;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A9WWPUserExtendedPhone = GXt_char1;
            AssignAttri("", false, "A9WWPUserExtendedPhone", A9WWPUserExtendedPhone);
            GXt_char1 = A3WWPUserExtendedEmail;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A3WWPUserExtendedEmail = GXt_char1;
            AssignAttri("", false, "A3WWPUserExtendedEmail", A3WWPUserExtendedEmail);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000112 */
            pr_default.execute(10, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message Mention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000113 */
            pr_default.execute(11, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000115 */
            pr_default.execute(13, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Web Client"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000116 */
            pr_default.execute(14, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPSubscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("wwpbaseobjects.wwp_userextended",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("wwpbaseobjects.wwp_userextended",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Using cursor T000117 */
         pr_default.execute(15);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound1 = 1;
            A1WWPUserExtendedId = T000117_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T000117_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound1 = 1;
            A1WWPUserExtendedId = T000117_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = T000117_n1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPUserExtendedPhone_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedPhone_Enabled), 5, 0), true);
         edtWWPUserExtendedEmail_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmail_Enabled), 5, 0), true);
         edtWWPUserExtendedEmaiNotif_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmaiNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmaiNotif_Enabled), 5, 0), true);
         chkWWPUserExtendedSMSNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedSMSNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedMobileNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedMobileNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedDesktopNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedDesktopNotif.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.AddJavascriptSource("gxcfg.js", "?20214281547290", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_userextended.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_boolean_hidden_field( context, "Z5WWPUserExtendedEmaiNotif", Z5WWPUserExtendedEmaiNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z6WWPUserExtendedSMSNotif", Z6WWPUserExtendedSMSNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z7WWPUserExtendedMobileNotif", Z7WWPUserExtendedMobileNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z8WWPUserExtendedDesktopNotif", Z8WWPUserExtendedDesktopNotif);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDPHOTO_GXI", A40000WWPUserExtendedPhoto_GXI);
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A4WWPUserExtendedPhoto);
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
         return formatLink("wwpbaseobjects.wwp_userextended.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WWP_UserExtended" ;
      }

      public override string GetPgmdesc( )
      {
         return "Extended User from GAMUser" ;
      }

      protected void InitializeNonKey011( )
      {
         A2WWPUserExtendedFullName = "";
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A3WWPUserExtendedEmail = "";
         AssignAttri("", false, "A3WWPUserExtendedEmail", A3WWPUserExtendedEmail);
         A9WWPUserExtendedPhone = "";
         AssignAttri("", false, "A9WWPUserExtendedPhone", A9WWPUserExtendedPhone);
         A4WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A5WWPUserExtendedEmaiNotif = false;
         AssignAttri("", false, "A5WWPUserExtendedEmaiNotif", A5WWPUserExtendedEmaiNotif);
         A6WWPUserExtendedSMSNotif = false;
         AssignAttri("", false, "A6WWPUserExtendedSMSNotif", A6WWPUserExtendedSMSNotif);
         A7WWPUserExtendedMobileNotif = false;
         AssignAttri("", false, "A7WWPUserExtendedMobileNotif", A7WWPUserExtendedMobileNotif);
         A8WWPUserExtendedDesktopNotif = false;
         AssignAttri("", false, "A8WWPUserExtendedDesktopNotif", A8WWPUserExtendedDesktopNotif);
         Z5WWPUserExtendedEmaiNotif = false;
         Z6WWPUserExtendedSMSNotif = false;
         Z7WWPUserExtendedMobileNotif = false;
         Z8WWPUserExtendedDesktopNotif = false;
      }

      protected void InitAll011( )
      {
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815472913", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_userextended.js", "?202142815472914", false, true);
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
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPUserExtendedPhone_Internalname = "WWPUSEREXTENDEDPHONE";
         edtWWPUserExtendedEmail_Internalname = "WWPUSEREXTENDEDEMAIL";
         edtWWPUserExtendedEmaiNotif_Internalname = "WWPUSEREXTENDEDEMAINOTIF";
         chkWWPUserExtendedSMSNotif_Internalname = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedMobileNotif_Internalname = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedDesktopNotif_Internalname = "WWPUSEREXTENDEDDESKTOPNOTIF";
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
         Form.Caption = "Extended User from GAMUser";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPUserExtendedDesktopNotif.Enabled = 1;
         chkWWPUserExtendedMobileNotif.Enabled = 1;
         chkWWPUserExtendedSMSNotif.Enabled = 1;
         edtWWPUserExtendedEmaiNotif_Jsonclick = "";
         edtWWPUserExtendedEmaiNotif_Enabled = 1;
         edtWWPUserExtendedEmail_Jsonclick = "";
         edtWWPUserExtendedEmail_Enabled = 0;
         edtWWPUserExtendedPhone_Jsonclick = "";
         edtWWPUserExtendedPhone_Enabled = 0;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         imgWWPUserExtendedPhoto_Enabled = 1;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
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

      protected void GX1ASAWWPUSEREXTENDEDPHONE011( string A1WWPUserExtendedId )
      {
         GXt_char1 = A9WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A9WWPUserExtendedPhone = GXt_char1;
         AssignAttri("", false, "A9WWPUserExtendedPhone", A9WWPUserExtendedPhone);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A9WWPUserExtendedPhone))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX2ASAWWPUSEREXTENDEDEMAIL011( string A1WWPUserExtendedId )
      {
         GXt_char1 = A3WWPUserExtendedEmail;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A3WWPUserExtendedEmail = GXt_char1;
         AssignAttri("", false, "A3WWPUserExtendedEmail", A3WWPUserExtendedEmail);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A3WWPUserExtendedEmail)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX3ASAWWPUSEREXTENDEDFULLNAME011( string A1WWPUserExtendedId )
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
         chkWWPUserExtendedSMSNotif.Name = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedSMSNotif.WebTags = "";
         chkWWPUserExtendedSMSNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "TitleCaption", chkWWPUserExtendedSMSNotif.Caption, true);
         chkWWPUserExtendedSMSNotif.CheckedValue = "false";
         A6WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A6WWPUserExtendedSMSNotif", A6WWPUserExtendedSMSNotif);
         chkWWPUserExtendedMobileNotif.Name = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedMobileNotif.WebTags = "";
         chkWWPUserExtendedMobileNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "TitleCaption", chkWWPUserExtendedMobileNotif.Caption, true);
         chkWWPUserExtendedMobileNotif.CheckedValue = "false";
         A7WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A7WWPUserExtendedMobileNotif", A7WWPUserExtendedMobileNotif);
         chkWWPUserExtendedDesktopNotif.Name = "WWPUSEREXTENDEDDESKTOPNOTIF";
         chkWWPUserExtendedDesktopNotif.WebTags = "";
         chkWWPUserExtendedDesktopNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "TitleCaption", chkWWPUserExtendedDesktopNotif.Caption, true);
         chkWWPUserExtendedDesktopNotif.CheckedValue = "false";
         A8WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A8WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A8WWPUserExtendedDesktopNotif", A8WWPUserExtendedDesktopNotif);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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

      public void Valid_Wwpuserextendedid( )
      {
         n1WWPUserExtendedId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         GXt_char1 = A9WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A9WWPUserExtendedPhone = GXt_char1;
         GXt_char1 = A3WWPUserExtendedEmail;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A3WWPUserExtendedEmail = GXt_char1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         dynload_actions( ) ;
         A6WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A6WWPUserExtendedSMSNotif));
         A7WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A7WWPUserExtendedMobileNotif));
         A8WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A8WWPUserExtendedDesktopNotif));
         /*  Sending validation outputs */
         AssignAttri("", false, "A4WWPUserExtendedPhoto", context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A5WWPUserExtendedEmaiNotif", A5WWPUserExtendedEmaiNotif);
         AssignAttri("", false, "A6WWPUserExtendedSMSNotif", A6WWPUserExtendedSMSNotif);
         AssignAttri("", false, "A7WWPUserExtendedMobileNotif", A7WWPUserExtendedMobileNotif);
         AssignAttri("", false, "A8WWPUserExtendedDesktopNotif", A8WWPUserExtendedDesktopNotif);
         AssignAttri("", false, "A9WWPUserExtendedPhone", StringUtil.RTrim( A9WWPUserExtendedPhone));
         AssignAttri("", false, "A3WWPUserExtendedEmail", A3WWPUserExtendedEmail);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z4WWPUserExtendedPhoto", context.PathToRelativeUrl( Z4WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z5WWPUserExtendedEmaiNotif", StringUtil.BoolToStr( Z5WWPUserExtendedEmaiNotif));
         GxWebStd.gx_hidden_field( context, "Z6WWPUserExtendedSMSNotif", StringUtil.BoolToStr( Z6WWPUserExtendedSMSNotif));
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedMobileNotif", StringUtil.BoolToStr( Z7WWPUserExtendedMobileNotif));
         GxWebStd.gx_hidden_field( context, "Z8WWPUserExtendedDesktopNotif", StringUtil.BoolToStr( Z8WWPUserExtendedDesktopNotif));
         GxWebStd.gx_hidden_field( context, "Z9WWPUserExtendedPhone", StringUtil.RTrim( Z9WWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "Z3WWPUserExtendedEmail", Z3WWPUserExtendedEmail);
         GxWebStd.gx_hidden_field( context, "Z2WWPUserExtendedFullName", Z2WWPUserExtendedFullName);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A5WWPUserExtendedEmaiNotif',fld:'WWPUSEREXTENDEDEMAINOTIF',pic:''},{av:'A9WWPUserExtendedPhone',fld:'WWPUSEREXTENDEDPHONE',pic:''},{av:'A3WWPUserExtendedEmail',fld:'WWPUSEREXTENDEDEMAIL',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1WWPUserExtendedId'},{av:'Z4WWPUserExtendedPhoto'},{av:'Z40000WWPUserExtendedPhoto_GXI'},{av:'Z5WWPUserExtendedEmaiNotif'},{av:'Z6WWPUserExtendedSMSNotif'},{av:'Z7WWPUserExtendedMobileNotif'},{av:'Z8WWPUserExtendedDesktopNotif'},{av:'Z9WWPUserExtendedPhone'},{av:'Z3WWPUserExtendedEmail'},{av:'Z2WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A6WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A7WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A8WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''}]}");
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
         A4WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         sImgUrl = "";
         A2WWPUserExtendedFullName = "";
         gxphoneLink = "";
         A9WWPUserExtendedPhone = "";
         A3WWPUserExtendedEmail = "";
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
         Z4WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         T00014_A1WWPUserExtendedId = new string[] {""} ;
         T00014_n1WWPUserExtendedId = new bool[] {false} ;
         T00014_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00014_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00014_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00014_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00014_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00014_A4WWPUserExtendedPhoto = new string[] {""} ;
         T00015_A1WWPUserExtendedId = new string[] {""} ;
         T00015_n1WWPUserExtendedId = new bool[] {false} ;
         T00013_A1WWPUserExtendedId = new string[] {""} ;
         T00013_n1WWPUserExtendedId = new bool[] {false} ;
         T00013_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00013_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00013_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00013_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00013_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00013_A4WWPUserExtendedPhoto = new string[] {""} ;
         sMode1 = "";
         T00016_A1WWPUserExtendedId = new string[] {""} ;
         T00016_n1WWPUserExtendedId = new bool[] {false} ;
         T00017_A1WWPUserExtendedId = new string[] {""} ;
         T00017_n1WWPUserExtendedId = new bool[] {false} ;
         T00012_A1WWPUserExtendedId = new string[] {""} ;
         T00012_n1WWPUserExtendedId = new bool[] {false} ;
         T00012_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00012_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00012_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00012_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00012_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00012_A4WWPUserExtendedPhoto = new string[] {""} ;
         T000112_A83WWPDiscussionMessageId = new long[1] ;
         T000112_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000113_A83WWPDiscussionMessageId = new long[1] ;
         T000114_A16WWPNotificationId = new long[1] ;
         T000115_A18WWPWebClientId = new string[] {""} ;
         T000116_A13WWPSubscriptionId = new long[1] ;
         T000117_A1WWPUserExtendedId = new string[] {""} ;
         T000117_n1WWPUserExtendedId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Z9WWPUserExtendedPhone = "";
         Z3WWPUserExtendedEmail = "";
         Z2WWPUserExtendedFullName = "";
         GXt_char1 = "";
         ZZ1WWPUserExtendedId = "";
         ZZ4WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ9WWPUserExtendedPhone = "";
         ZZ3WWPUserExtendedEmail = "";
         ZZ2WWPUserExtendedFullName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__default(),
            new Object[][] {
                new Object[] {
               T00012_A1WWPUserExtendedId, T00012_A40000WWPUserExtendedPhoto_GXI, T00012_A5WWPUserExtendedEmaiNotif, T00012_A6WWPUserExtendedSMSNotif, T00012_A7WWPUserExtendedMobileNotif, T00012_A8WWPUserExtendedDesktopNotif, T00012_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T00013_A1WWPUserExtendedId, T00013_A40000WWPUserExtendedPhoto_GXI, T00013_A5WWPUserExtendedEmaiNotif, T00013_A6WWPUserExtendedSMSNotif, T00013_A7WWPUserExtendedMobileNotif, T00013_A8WWPUserExtendedDesktopNotif, T00013_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T00014_A1WWPUserExtendedId, T00014_A40000WWPUserExtendedPhoto_GXI, T00014_A5WWPUserExtendedEmaiNotif, T00014_A6WWPUserExtendedSMSNotif, T00014_A7WWPUserExtendedMobileNotif, T00014_A8WWPUserExtendedDesktopNotif, T00014_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T00015_A1WWPUserExtendedId
               }
               , new Object[] {
               T00016_A1WWPUserExtendedId
               }
               , new Object[] {
               T00017_A1WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000112_A83WWPDiscussionMessageId, T000112_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000113_A83WWPDiscussionMessageId
               }
               , new Object[] {
               T000114_A16WWPNotificationId
               }
               , new Object[] {
               T000115_A18WWPWebClientId
               }
               , new Object[] {
               T000116_A13WWPSubscriptionId
               }
               , new Object[] {
               T000117_A1WWPUserExtendedId
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
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPUserExtendedPhone_Enabled ;
      private int edtWWPUserExtendedEmail_Enabled ;
      private int edtWWPUserExtendedEmaiNotif_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
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
      private string edtWWPUserExtendedId_Internalname ;
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
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string sImgUrl ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPUserExtendedPhone_Internalname ;
      private string gxphoneLink ;
      private string A9WWPUserExtendedPhone ;
      private string edtWWPUserExtendedPhone_Jsonclick ;
      private string edtWWPUserExtendedEmail_Internalname ;
      private string edtWWPUserExtendedEmail_Jsonclick ;
      private string edtWWPUserExtendedEmaiNotif_Internalname ;
      private string edtWWPUserExtendedEmaiNotif_Jsonclick ;
      private string chkWWPUserExtendedSMSNotif_Internalname ;
      private string chkWWPUserExtendedMobileNotif_Internalname ;
      private string chkWWPUserExtendedDesktopNotif_Internalname ;
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
      private string sMode1 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string Z9WWPUserExtendedPhone ;
      private string GXt_char1 ;
      private string ZZ1WWPUserExtendedId ;
      private string ZZ9WWPUserExtendedPhone ;
      private bool Z5WWPUserExtendedEmaiNotif ;
      private bool Z6WWPUserExtendedSMSNotif ;
      private bool Z7WWPUserExtendedMobileNotif ;
      private bool Z8WWPUserExtendedDesktopNotif ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1WWPUserExtendedId ;
      private bool wbErr ;
      private bool A6WWPUserExtendedSMSNotif ;
      private bool A7WWPUserExtendedMobileNotif ;
      private bool A8WWPUserExtendedDesktopNotif ;
      private bool A4WWPUserExtendedPhoto_IsBlob ;
      private bool A5WWPUserExtendedEmaiNotif ;
      private bool ZZ5WWPUserExtendedEmaiNotif ;
      private bool ZZ6WWPUserExtendedSMSNotif ;
      private bool ZZ7WWPUserExtendedMobileNotif ;
      private bool ZZ8WWPUserExtendedDesktopNotif ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A2WWPUserExtendedFullName ;
      private string A3WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string Z3WWPUserExtendedEmail ;
      private string Z2WWPUserExtendedFullName ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ3WWPUserExtendedEmail ;
      private string ZZ2WWPUserExtendedFullName ;
      private string A4WWPUserExtendedPhoto ;
      private string Z4WWPUserExtendedPhoto ;
      private string ZZ4WWPUserExtendedPhoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPUserExtendedSMSNotif ;
      private GXCheckbox chkWWPUserExtendedMobileNotif ;
      private GXCheckbox chkWWPUserExtendedDesktopNotif ;
      private IDataStoreProvider pr_default ;
      private string[] T00014_A1WWPUserExtendedId ;
      private bool[] T00014_n1WWPUserExtendedId ;
      private string[] T00014_A40000WWPUserExtendedPhoto_GXI ;
      private bool[] T00014_A5WWPUserExtendedEmaiNotif ;
      private bool[] T00014_A6WWPUserExtendedSMSNotif ;
      private bool[] T00014_A7WWPUserExtendedMobileNotif ;
      private bool[] T00014_A8WWPUserExtendedDesktopNotif ;
      private string[] T00014_A4WWPUserExtendedPhoto ;
      private string[] T00015_A1WWPUserExtendedId ;
      private bool[] T00015_n1WWPUserExtendedId ;
      private string[] T00013_A1WWPUserExtendedId ;
      private bool[] T00013_n1WWPUserExtendedId ;
      private string[] T00013_A40000WWPUserExtendedPhoto_GXI ;
      private bool[] T00013_A5WWPUserExtendedEmaiNotif ;
      private bool[] T00013_A6WWPUserExtendedSMSNotif ;
      private bool[] T00013_A7WWPUserExtendedMobileNotif ;
      private bool[] T00013_A8WWPUserExtendedDesktopNotif ;
      private string[] T00013_A4WWPUserExtendedPhoto ;
      private string[] T00016_A1WWPUserExtendedId ;
      private bool[] T00016_n1WWPUserExtendedId ;
      private string[] T00017_A1WWPUserExtendedId ;
      private bool[] T00017_n1WWPUserExtendedId ;
      private string[] T00012_A1WWPUserExtendedId ;
      private bool[] T00012_n1WWPUserExtendedId ;
      private string[] T00012_A40000WWPUserExtendedPhoto_GXI ;
      private bool[] T00012_A5WWPUserExtendedEmaiNotif ;
      private bool[] T00012_A6WWPUserExtendedSMSNotif ;
      private bool[] T00012_A7WWPUserExtendedMobileNotif ;
      private bool[] T00012_A8WWPUserExtendedDesktopNotif ;
      private string[] T00012_A4WWPUserExtendedPhoto ;
      private long[] T000112_A83WWPDiscussionMessageId ;
      private string[] T000112_A85WWPDiscussionMentionUserId ;
      private long[] T000113_A83WWPDiscussionMessageId ;
      private long[] T000114_A16WWPNotificationId ;
      private string[] T000115_A18WWPWebClientId ;
      private long[] T000116_A13WWPSubscriptionId ;
      private string[] T000117_A1WWPUserExtendedId ;
      private bool[] T000117_n1WWPUserExtendedId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_userextended__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
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
        Object[] prmT00014;
        prmT00014 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00015;
        prmT00015 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00013;
        prmT00013 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00016;
        prmT00016 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00017;
        prmT00017 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00012;
        prmT00012 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT00018;
        prmT00018 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPUserExtendedPhoto",SqlDbType.VarBinary,1024,0} ,
        new Object[] {"@WWPUserExtendedPhoto_GXI",SqlDbType.VarChar,2048,0} ,
        new Object[] {"@WWPUserExtendedEmaiNotif",SqlDbType.Bit,100,0} ,
        new Object[] {"@WWPUserExtendedSMSNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedMobileNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedDesktopNotif",SqlDbType.Bit,4,0}
        };
        Object[] prmT00019;
        prmT00019 = new Object[] {
        new Object[] {"@WWPUserExtendedEmaiNotif",SqlDbType.Bit,100,0} ,
        new Object[] {"@WWPUserExtendedSMSNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedMobileNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedDesktopNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000110;
        prmT000110 = new Object[] {
        new Object[] {"@WWPUserExtendedPhoto",SqlDbType.VarBinary,1024,0} ,
        new Object[] {"@WWPUserExtendedPhoto_GXI",SqlDbType.VarChar,2048,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000111;
        prmT000111 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000112;
        prmT000112 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000113;
        prmT000113 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000114;
        prmT000114 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000115;
        prmT000115 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000116;
        prmT000116 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000117;
        prmT000117 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00012", "SELECT [WWPUserExtendedId], [WWPUserExtendedPhoto_GXI], [WWPUserExtendedEmaiNotif], [WWPUserExtendedSMSNotif], [WWPUserExtendedMobileNotif], [WWPUserExtendedDesktopNotif], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WITH (UPDLOCK) WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00013", "SELECT [WWPUserExtendedId], [WWPUserExtendedPhoto_GXI], [WWPUserExtendedEmaiNotif], [WWPUserExtendedSMSNotif], [WWPUserExtendedMobileNotif], [WWPUserExtendedDesktopNotif], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00014", "SELECT TM1.[WWPUserExtendedId], TM1.[WWPUserExtendedPhoto_GXI], TM1.[WWPUserExtendedEmaiNotif], TM1.[WWPUserExtendedSMSNotif], TM1.[WWPUserExtendedMobileNotif], TM1.[WWPUserExtendedDesktopNotif], TM1.[WWPUserExtendedPhoto] FROM [WWP_UserExtended] TM1 WHERE TM1.[WWPUserExtendedId] = @WWPUserExtendedId ORDER BY TM1.[WWPUserExtendedId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00015", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00016", "SELECT TOP 1 [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE ( [WWPUserExtendedId] > @WWPUserExtendedId) ORDER BY [WWPUserExtendedId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00017", "SELECT TOP 1 [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE ( [WWPUserExtendedId] < @WWPUserExtendedId) ORDER BY [WWPUserExtendedId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00018", "INSERT INTO [WWP_UserExtended]([WWPUserExtendedId], [WWPUserExtendedPhoto], [WWPUserExtendedPhoto_GXI], [WWPUserExtendedEmaiNotif], [WWPUserExtendedSMSNotif], [WWPUserExtendedMobileNotif], [WWPUserExtendedDesktopNotif]) VALUES(@WWPUserExtendedId, @WWPUserExtendedPhoto, @WWPUserExtendedPhoto_GXI, @WWPUserExtendedEmaiNotif, @WWPUserExtendedSMSNotif, @WWPUserExtendedMobileNotif, @WWPUserExtendedDesktopNotif)", GxErrorMask.GX_NOMASK,prmT00018)
           ,new CursorDef("T00019", "UPDATE [WWP_UserExtended] SET [WWPUserExtendedEmaiNotif]=@WWPUserExtendedEmaiNotif, [WWPUserExtendedSMSNotif]=@WWPUserExtendedSMSNotif, [WWPUserExtendedMobileNotif]=@WWPUserExtendedMobileNotif, [WWPUserExtendedDesktopNotif]=@WWPUserExtendedDesktopNotif  WHERE [WWPUserExtendedId] = @WWPUserExtendedId", GxErrorMask.GX_NOMASK,prmT00019)
           ,new CursorDef("T000110", "UPDATE [WWP_UserExtended] SET [WWPUserExtendedPhoto]=@WWPUserExtendedPhoto, [WWPUserExtendedPhoto_GXI]=@WWPUserExtendedPhoto_GXI  WHERE [WWPUserExtendedId] = @WWPUserExtendedId", GxErrorMask.GX_NOMASK,prmT000110)
           ,new CursorDef("T000111", "DELETE FROM [WWP_UserExtended]  WHERE [WWPUserExtendedId] = @WWPUserExtendedId", GxErrorMask.GX_NOMASK,prmT000111)
           ,new CursorDef("T000112", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMentionUserId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000113", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000114", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000115", "SELECT TOP 1 [WWPWebClientId] FROM [WWP_WebClient] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000116", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000117", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] ORDER BY [WWPUserExtendedId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,100, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.getMultimediaUri(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              table[5][0] = rslt.getBool(6);
              table[6][0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 1 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.getMultimediaUri(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              table[5][0] = rslt.getBool(6);
              table[6][0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 2 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.getMultimediaUri(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              table[5][0] = rslt.getBool(6);
              table[6][0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 4 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 5 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 11 :
              table[0][0] = rslt.getLong(1);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              return;
           case 13 :
              table[0][0] = rslt.getString(1, 100);
              return;
           case 14 :
              table[0][0] = rslt.getLong(1);
              return;
           case 15 :
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
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 1 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
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
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 5 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
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
              stmt.SetParameterBlob(2, (string)parms[2], false);
              stmt.SetParameterMultimedia(3, (string)parms[3], (string)parms[2], "WWP_UserExtended", "WWPUserExtendedPhoto");
              stmt.SetParameter(4, (bool)parms[4]);
              stmt.SetParameter(5, (bool)parms[5]);
              stmt.SetParameter(6, (bool)parms[6]);
              stmt.SetParameter(7, (bool)parms[7]);
              return;
           case 7 :
              stmt.SetParameter(1, (bool)parms[0]);
              stmt.SetParameter(2, (bool)parms[1]);
              stmt.SetParameter(3, (bool)parms[2]);
              stmt.SetParameter(4, (bool)parms[3]);
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 5 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[5]);
              }
              return;
           case 8 :
              stmt.SetParameterBlob(1, (string)parms[0], false);
              stmt.SetParameterMultimedia(2, (string)parms[1], (string)parms[0], "WWP_UserExtended", "WWPUserExtendedPhoto");
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              return;
           case 9 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 10 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 11 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
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
           case 13 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 14 :
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
