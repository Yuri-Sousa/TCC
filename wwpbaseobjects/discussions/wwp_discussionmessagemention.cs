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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessagemention : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"WWPDISCUSSIONMENTIONUSERNAME") == 0 )
         {
            A85WWPDiscussionMentionUserId = GetPar( "WWPDiscussionMentionUserId");
            AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX1ASAWWPDISCUSSIONMENTIONUSERNAME0C13( A85WWPDiscussionMentionUserId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A83WWPDiscussionMessageId = (long)(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."));
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A83WWPDiscussionMessageId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A85WWPDiscussionMentionUserId = GetPar( "WWPDiscussionMentionUserId");
            AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A85WWPDiscussionMentionUserId) ;
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
            Form.Meta.addItem("description", "Discussion Message Mention", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_discussionmessagemention( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_discussionmessagemention( IGxContext context )
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
            return "wwpdiscussionmessagemention_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Discussion Message Mention", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageId_Internalname, "Message Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A83WWPDiscussionMessageId), 10, 0, ",", "")), ((edtWWPDiscussionMessageId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A83WWPDiscussionMessageId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A83WWPDiscussionMessageId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageDate_Internalname, "Message Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtWWPDiscussionMessageDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageDate_Internalname, context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A87WWPDiscussionMessageDate, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_bitmap( context, edtWWPDiscussionMessageDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPDiscussionMessageDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPDiscussionMentionUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMentionUserId_Internalname, "Mention User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMentionUserId_Internalname, StringUtil.RTrim( A85WWPDiscussionMentionUserId), StringUtil.RTrim( context.localUtil.Format( A85WWPDiscussionMentionUserId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMentionUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMentionUserId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "left", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPDiscussionMentionUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMentionUserName_Internalname, "Mention User Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMentionUserName_Internalname, A86WWPDiscussionMentionUserName, StringUtil.RTrim( context.localUtil.Format( A86WWPDiscussionMentionUserName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMentionUserName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMentionUserName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessageMention.htm");
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
            Z83WWPDiscussionMessageId = (long)(context.localUtil.CToN( cgiGet( "Z83WWPDiscussionMessageId"), ",", "."));
            Z85WWPDiscussionMentionUserId = cgiGet( "Z85WWPDiscussionMentionUserId");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A83WWPDiscussionMessageId = 0;
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            }
            else
            {
               A83WWPDiscussionMessageId = (long)(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), ",", "."));
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            }
            A87WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname));
            AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            A85WWPDiscussionMentionUserId = cgiGet( edtWWPDiscussionMentionUserId_Internalname);
            AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
            A86WWPDiscussionMentionUserName = cgiGet( edtWWPDiscussionMentionUserName_Internalname);
            AssignAttri("", false, "A86WWPDiscussionMentionUserName", A86WWPDiscussionMentionUserName);
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
               A83WWPDiscussionMessageId = (long)(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."));
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
               A85WWPDiscussionMentionUserId = GetPar( "WWPDiscussionMentionUserId");
               AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
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
               InitAll0C13( ) ;
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
         DisableAttributes0C13( ) ;
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

      protected void ResetCaption0C0( )
      {
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -2 )
         {
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z85WWPDiscussionMentionUserId = A85WWPDiscussionMentionUserId;
            Z87WWPDiscussionMessageDate = A87WWPDiscussionMessageDate;
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

      protected void Load0C13( )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
            A87WWPDiscussionMessageDate = T000C6_A87WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            ZM0C13( -2) ;
         }
         pr_default.close(4);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
         GXt_char1 = A86WWPDiscussionMentionUserName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
         A86WWPDiscussionMentionUserName = GXt_char1;
         AssignAttri("", false, "A86WWPDiscussionMentionUserName", A86WWPDiscussionMentionUserName);
      }

      protected void CheckExtendedTable0C13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPDiscussion Message'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A87WWPDiscussionMessageDate = T000C4_A87WWPDiscussionMessageDate[0];
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         pr_default.close(2);
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         nIsDirty_13 = 1;
         GXt_char1 = A86WWPDiscussionMentionUserName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
         A86WWPDiscussionMentionUserName = GXt_char1;
         AssignAttri("", false, "A86WWPDiscussionMentionUserName", A86WWPDiscussionMentionUserName);
      }

      protected void CloseExtendedTableCursors0C13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A83WWPDiscussionMessageId )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPDiscussion Message'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A87WWPDiscussionMessageDate = T000C7_A87WWPDiscussionMessageDate[0];
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( string A85WWPDiscussionMentionUserId )
      {
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey0C13( )
      {
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 2) ;
            RcdFound13 = 1;
            A83WWPDiscussionMessageId = T000C3_A83WWPDiscussionMessageId[0];
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            A85WWPDiscussionMentionUserId = T000C3_A85WWPDiscussionMentionUserId[0];
            AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z85WWPDiscussionMentionUserId = A85WWPDiscussionMentionUserId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
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
         RcdFound13 = 0;
         /* Using cursor T000C10 */
         pr_default.execute(8, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000C10_A83WWPDiscussionMessageId[0] < A83WWPDiscussionMessageId ) || ( T000C10_A83WWPDiscussionMessageId[0] == A83WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T000C10_A85WWPDiscussionMentionUserId[0], A85WWPDiscussionMentionUserId) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000C10_A83WWPDiscussionMessageId[0] > A83WWPDiscussionMessageId ) || ( T000C10_A83WWPDiscussionMessageId[0] == A83WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T000C10_A85WWPDiscussionMentionUserId[0], A85WWPDiscussionMentionUserId) > 0 ) ) )
            {
               A83WWPDiscussionMessageId = T000C10_A83WWPDiscussionMessageId[0];
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
               A85WWPDiscussionMentionUserId = T000C10_A85WWPDiscussionMentionUserId[0];
               AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
               RcdFound13 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C11 */
         pr_default.execute(9, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000C11_A83WWPDiscussionMessageId[0] > A83WWPDiscussionMessageId ) || ( T000C11_A83WWPDiscussionMessageId[0] == A83WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T000C11_A85WWPDiscussionMentionUserId[0], A85WWPDiscussionMentionUserId) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000C11_A83WWPDiscussionMessageId[0] < A83WWPDiscussionMessageId ) || ( T000C11_A83WWPDiscussionMessageId[0] == A83WWPDiscussionMessageId ) && ( StringUtil.StrCmp(T000C11_A85WWPDiscussionMentionUserId[0], A85WWPDiscussionMentionUserId) < 0 ) ) )
            {
               A83WWPDiscussionMessageId = T000C11_A83WWPDiscussionMessageId[0];
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
               A85WWPDiscussionMentionUserId = T000C11_A85WWPDiscussionMentionUserId[0];
               AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
               RcdFound13 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A85WWPDiscussionMentionUserId, Z85WWPDiscussionMentionUserId) != 0 ) )
               {
                  A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
                  AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
                  A85WWPDiscussionMentionUserId = Z85WWPDiscussionMentionUserId;
                  AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0C13( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A85WWPDiscussionMentionUserId, Z85WWPDiscussionMentionUserId) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C13( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPDISCUSSIONMESSAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C13( ) ;
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
         if ( ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A85WWPDiscussionMentionUserId, Z85WWPDiscussionMentionUserId) != 0 ) )
         {
            A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            A85WWPDiscussionMentionUserId = Z85WWPDiscussionMentionUserId;
            AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd0C13( ) ;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0C13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd0C13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessagemention_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C12 */
                     pr_default.execute(10, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption0C0( ) ;
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessagemention_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [WWP_DiscussionMessageMention] */
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0C0( ) ;
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
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessagemention_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C13 */
                  pr_default.execute(11, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound13 == 0 )
                        {
                           InitAll0C13( ) ;
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
                        ResetCaption0C0( ) ;
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000C14 */
            pr_default.execute(12, new Object[] {A83WWPDiscussionMessageId});
            A87WWPDiscussionMessageDate = T000C14_A87WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            pr_default.close(12);
            GXt_char1 = A86WWPDiscussionMentionUserName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
            A86WWPDiscussionMentionUserName = GXt_char1;
            AssignAttri("", false, "A86WWPDiscussionMentionUserName", A86WWPDiscussionMentionUserName);
         }
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C13( )
      {
         /* Using cursor T000C15 */
         pr_default.execute(13);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound13 = 1;
            A83WWPDiscussionMessageId = T000C15_A83WWPDiscussionMessageId[0];
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            A85WWPDiscussionMentionUserId = T000C15_A85WWPDiscussionMentionUserId[0];
            AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound13 = 1;
            A83WWPDiscussionMessageId = T000C15_A83WWPDiscussionMessageId[0];
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            A85WWPDiscussionMentionUserId = T000C15_A85WWPDiscussionMentionUserId[0];
            AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
         }
      }

      protected void ScanEnd0C13( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
         edtWWPDiscussionMessageId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageDate_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageDate_Enabled), 5, 0), true);
         edtWWPDiscussionMentionUserId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMentionUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMentionUserId_Enabled), 5, 0), true);
         edtWWPDiscussionMentionUserName_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMentionUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMentionUserName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815482513", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionmessagemention.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z83WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z83WWPDiscussionMessageId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z85WWPDiscussionMentionUserId", StringUtil.RTrim( Z85WWPDiscussionMentionUserId));
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
         return formatLink("wwpbaseobjects.discussions.wwp_discussionmessagemention.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Discussions.WWP_DiscussionMessageMention" ;
      }

      public override string GetPgmdesc( )
      {
         return "Discussion Message Mention" ;
      }

      protected void InitializeNonKey0C13( )
      {
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         A86WWPDiscussionMentionUserName = "";
         AssignAttri("", false, "A86WWPDiscussionMentionUserName", A86WWPDiscussionMentionUserName);
      }

      protected void InitAll0C13( )
      {
         A83WWPDiscussionMessageId = 0;
         AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
         A85WWPDiscussionMentionUserId = "";
         AssignAttri("", false, "A85WWPDiscussionMentionUserId", A85WWPDiscussionMentionUserId);
         InitializeNonKey0C13( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815482522", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionmessagemention.js", "?202142815482522", false, true);
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
         edtWWPDiscussionMessageId_Internalname = "WWPDISCUSSIONMESSAGEID";
         edtWWPDiscussionMessageDate_Internalname = "WWPDISCUSSIONMESSAGEDATE";
         edtWWPDiscussionMentionUserId_Internalname = "WWPDISCUSSIONMENTIONUSERID";
         edtWWPDiscussionMentionUserName_Internalname = "WWPDISCUSSIONMENTIONUSERNAME";
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
         Form.Caption = "Discussion Message Mention";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPDiscussionMentionUserName_Jsonclick = "";
         edtWWPDiscussionMentionUserName_Enabled = 0;
         edtWWPDiscussionMentionUserId_Jsonclick = "";
         edtWWPDiscussionMentionUserId_Enabled = 1;
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPDiscussionMessageDate_Enabled = 0;
         edtWWPDiscussionMessageId_Jsonclick = "";
         edtWWPDiscussionMessageId_Enabled = 1;
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

      protected void GX1ASAWWPDISCUSSIONMENTIONUSERNAME0C13( string A85WWPDiscussionMentionUserId )
      {
         GXt_char1 = A86WWPDiscussionMentionUserName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
         A86WWPDiscussionMentionUserName = GXt_char1;
         AssignAttri("", false, "A86WWPDiscussionMentionUserName", A86WWPDiscussionMentionUserName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A86WWPDiscussionMentionUserName)+"\"") ;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000C14 */
         pr_default.execute(12, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPDiscussion Message'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A87WWPDiscussionMessageDate = T000C14_A87WWPDiscussionMessageDate[0];
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         pr_default.close(12);
         /* Using cursor T000C16 */
         pr_default.execute(14, new Object[] {A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         if ( AnyError == 0 )
         {
            GX_FocusControl = "";
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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

      public void Valid_Wwpdiscussionmessageid( )
      {
         /* Using cursor T000C14 */
         pr_default.execute(12, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPDiscussion Message'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
         }
         A87WWPDiscussionMessageDate = T000C14_A87WWPDiscussionMessageDate[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
      }

      public void Valid_Wwpdiscussionmentionuserid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000C16 */
         pr_default.execute(14, new Object[] {A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMentionUserId_Internalname;
         }
         pr_default.close(14);
         GXt_char1 = A86WWPDiscussionMentionUserName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
         A86WWPDiscussionMentionUserName = GXt_char1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A86WWPDiscussionMentionUserName", A86WWPDiscussionMentionUserName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z83WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z83WWPDiscussionMessageId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z85WWPDiscussionMentionUserId", StringUtil.RTrim( Z85WWPDiscussionMentionUserId));
         GxWebStd.gx_hidden_field( context, "Z87WWPDiscussionMessageDate", context.localUtil.TToC( Z87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z86WWPDiscussionMentionUserName", Z86WWPDiscussionMentionUserName);
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
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID","{handler:'Valid_Wwpdiscussionmessageid',iparms:[{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID",",oparms:[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}]}");
         setEventMetadata("VALID_WWPDISCUSSIONMENTIONUSERID","{handler:'Valid_Wwpdiscussionmentionuserid',iparms:[{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A85WWPDiscussionMentionUserId',fld:'WWPDISCUSSIONMENTIONUSERID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMENTIONUSERID",",oparms:[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A86WWPDiscussionMentionUserName',fld:'WWPDISCUSSIONMENTIONUSERNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83WWPDiscussionMessageId'},{av:'Z85WWPDiscussionMentionUserId'},{av:'Z87WWPDiscussionMessageDate'},{av:'Z86WWPDiscussionMentionUserName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z85WWPDiscussionMentionUserId = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A85WWPDiscussionMentionUserId = "";
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
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A86WWPDiscussionMentionUserName = "";
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
         Z87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         T000C6_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000C6_A83WWPDiscussionMessageId = new long[1] ;
         T000C6_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000C4_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000C5_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000C7_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000C8_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000C9_A83WWPDiscussionMessageId = new long[1] ;
         T000C9_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000C3_A83WWPDiscussionMessageId = new long[1] ;
         T000C3_A85WWPDiscussionMentionUserId = new string[] {""} ;
         sMode13 = "";
         T000C10_A83WWPDiscussionMessageId = new long[1] ;
         T000C10_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000C11_A83WWPDiscussionMessageId = new long[1] ;
         T000C11_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000C2_A83WWPDiscussionMessageId = new long[1] ;
         T000C2_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000C14_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000C15_A83WWPDiscussionMessageId = new long[1] ;
         T000C15_A85WWPDiscussionMentionUserId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000C16_A85WWPDiscussionMentionUserId = new string[] {""} ;
         Z86WWPDiscussionMentionUserName = "";
         GXt_char1 = "";
         ZZ85WWPDiscussionMentionUserId = "";
         ZZ87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         ZZ86WWPDiscussionMentionUserName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention__default(),
            new Object[][] {
                new Object[] {
               T000C2_A83WWPDiscussionMessageId, T000C2_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C3_A83WWPDiscussionMessageId, T000C3_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C4_A87WWPDiscussionMessageDate
               }
               , new Object[] {
               T000C5_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C6_A87WWPDiscussionMessageDate, T000C6_A83WWPDiscussionMessageId, T000C6_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C7_A87WWPDiscussionMessageDate
               }
               , new Object[] {
               T000C8_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C9_A83WWPDiscussionMessageId, T000C9_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C10_A83WWPDiscussionMessageId, T000C10_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C11_A83WWPDiscussionMessageId, T000C11_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C14_A87WWPDiscussionMessageDate
               }
               , new Object[] {
               T000C15_A83WWPDiscussionMessageId, T000C15_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000C16_A85WWPDiscussionMentionUserId
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
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPDiscussionMessageId_Enabled ;
      private int edtWWPDiscussionMessageDate_Enabled ;
      private int edtWWPDiscussionMentionUserId_Enabled ;
      private int edtWWPDiscussionMentionUserName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z83WWPDiscussionMessageId ;
      private long A83WWPDiscussionMessageId ;
      private long ZZ83WWPDiscussionMessageId ;
      private string sPrefix ;
      private string Z85WWPDiscussionMentionUserId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A85WWPDiscussionMentionUserId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPDiscussionMessageId_Internalname ;
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
      private string edtWWPDiscussionMessageId_Jsonclick ;
      private string edtWWPDiscussionMessageDate_Internalname ;
      private string edtWWPDiscussionMessageDate_Jsonclick ;
      private string edtWWPDiscussionMentionUserId_Internalname ;
      private string edtWWPDiscussionMentionUserId_Jsonclick ;
      private string edtWWPDiscussionMentionUserName_Internalname ;
      private string edtWWPDiscussionMentionUserName_Jsonclick ;
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
      private string sMode13 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXt_char1 ;
      private string ZZ85WWPDiscussionMentionUserId ;
      private DateTime A87WWPDiscussionMessageDate ;
      private DateTime Z87WWPDiscussionMessageDate ;
      private DateTime ZZ87WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string A86WWPDiscussionMentionUserName ;
      private string Z86WWPDiscussionMentionUserName ;
      private string ZZ86WWPDiscussionMentionUserName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000C6_A87WWPDiscussionMessageDate ;
      private long[] T000C6_A83WWPDiscussionMessageId ;
      private string[] T000C6_A85WWPDiscussionMentionUserId ;
      private DateTime[] T000C4_A87WWPDiscussionMessageDate ;
      private string[] T000C5_A85WWPDiscussionMentionUserId ;
      private DateTime[] T000C7_A87WWPDiscussionMessageDate ;
      private string[] T000C8_A85WWPDiscussionMentionUserId ;
      private long[] T000C9_A83WWPDiscussionMessageId ;
      private string[] T000C9_A85WWPDiscussionMentionUserId ;
      private long[] T000C3_A83WWPDiscussionMessageId ;
      private string[] T000C3_A85WWPDiscussionMentionUserId ;
      private long[] T000C10_A83WWPDiscussionMessageId ;
      private string[] T000C10_A85WWPDiscussionMentionUserId ;
      private long[] T000C11_A83WWPDiscussionMessageId ;
      private string[] T000C11_A85WWPDiscussionMentionUserId ;
      private long[] T000C2_A83WWPDiscussionMessageId ;
      private string[] T000C2_A85WWPDiscussionMentionUserId ;
      private DateTime[] T000C14_A87WWPDiscussionMessageDate ;
      private long[] T000C15_A83WWPDiscussionMessageId ;
      private string[] T000C15_A85WWPDiscussionMentionUserId ;
      private string[] T000C16_A85WWPDiscussionMentionUserId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_discussionmessagemention__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessagemention__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
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
        Object[] prmT000C6;
        prmT000C6 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C4;
        prmT000C4 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000C5;
        prmT000C5 = new Object[] {
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C7;
        prmT000C7 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000C8;
        prmT000C8 = new Object[] {
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C9;
        prmT000C9 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C3;
        prmT000C3 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C10;
        prmT000C10 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C11;
        prmT000C11 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C2;
        prmT000C2 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C12;
        prmT000C12 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C13;
        prmT000C13 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000C15;
        prmT000C15 = new Object[] {
        };
        Object[] prmT000C14;
        prmT000C14 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000C16;
        prmT000C16 = new Object[] {
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000C2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C4", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C5", "SELECT [WWPUserExtendedId] AS WWPDiscussionMentionUserId FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C6", "SELECT T2.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM ([WWP_DiscussionMessageMention] TM1 INNER JOIN [WWP_DiscussionMessage] T2 ON T2.[WWPDiscussionMessageId] = TM1.[WWPDiscussionMessageId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId and TM1.[WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ORDER BY TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C7", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C8", "SELECT [WWPUserExtendedId] AS WWPDiscussionMentionUserId FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C9", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C10", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE ( [WWPDiscussionMessageId] > @WWPDiscussionMessageId or [WWPDiscussionMessageId] = @WWPDiscussionMessageId and [WWPDiscussionMentionUserId] > @WWPDiscussionMentionUserId) ORDER BY [WWPDiscussionMessageId], [WWPDiscussionMentionUserId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C11", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE ( [WWPDiscussionMessageId] < @WWPDiscussionMessageId or [WWPDiscussionMessageId] = @WWPDiscussionMessageId and [WWPDiscussionMentionUserId] < @WWPDiscussionMentionUserId) ORDER BY [WWPDiscussionMessageId] DESC, [WWPDiscussionMentionUserId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C12", "INSERT INTO [WWP_DiscussionMessageMention]([WWPDiscussionMessageId], [WWPDiscussionMentionUserId]) VALUES(@WWPDiscussionMessageId, @WWPDiscussionMentionUserId)", GxErrorMask.GX_NOMASK,prmT000C12)
           ,new CursorDef("T000C13", "DELETE FROM [WWP_DiscussionMessageMention]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId", GxErrorMask.GX_NOMASK,prmT000C13)
           ,new CursorDef("T000C14", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C15", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] ORDER BY [WWPDiscussionMessageId], [WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C16", "SELECT [WWPUserExtendedId] AS WWPDiscussionMentionUserId FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C16,1, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getString(2, 40);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 2 :
              table[0][0] = rslt.getGXDateTime(1);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 4 :
              table[0][0] = rslt.getGXDateTime(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getString(3, 40);
              return;
           case 5 :
              table[0][0] = rslt.getGXDateTime(1);
              return;
           case 6 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 7 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 8 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 12 :
              table[0][0] = rslt.getGXDateTime(1);
              return;
           case 13 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 14 :
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 5 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 8 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 10 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 12 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 14 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
     }
  }

}

}
