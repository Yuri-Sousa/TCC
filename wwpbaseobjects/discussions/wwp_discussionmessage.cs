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
   public class wwp_discussionmessage : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel2"+"_"+"WWPUSEREXTENDEDFULLNAME") == 0 )
         {
            A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX2ASAWWPUSEREXTENDEDFULLNAME0B12( A1WWPUserExtendedId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"WWPUSEREXTENDEDID") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAWWPUSEREXTENDEDID0B12( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A84WWPDiscussionMessageThreadId = (long)(NumberUtil.Val( GetPar( "WWPDiscussionMessageThreadId"), "."));
            n84WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A84WWPDiscussionMessageThreadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A10WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
            AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A10WWPEntityId) ;
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
            Form.Meta.addItem("description", "Discussion Message", 0) ;
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

      public wwp_discussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_discussionmessage( IGxContext context )
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
            return "wwpdiscussionmessage_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Discussion Message", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A83WWPDiscussionMessageId), 10, 0, ",", "")), ((edtWWPDiscussionMessageId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A83WWPDiscussionMessageId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A83WWPDiscussionMessageId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageDate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPDiscussionMessageDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageDate_Internalname, context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A87WWPDiscussionMessageDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_bitmap( context, edtWWPDiscussionMessageDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPDiscussionMessageDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageThreadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageThreadId_Internalname, "Thread Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageThreadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0, ",", "")), ((edtWWPDiscussionMessageThreadId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A84WWPDiscussionMessageThreadId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A84WWPDiscussionMessageThreadId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageThreadId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageThreadId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageMessage_Internalname, "Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPDiscussionMessageMessage_Internalname, A88WWPDiscussionMessageMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, 1, edtWWPDiscussionMessageMessage_Enabled, 0, 80, "chr", 5, "row", StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A1WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A1WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "left", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_label_element( context, "", "User Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A4WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 0, A4WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "User Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A2WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A2WWPUserExtendedFullName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ",", "")), ((edtWWPEntityId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A10WWPEntityId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A10WWPEntityId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A12WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A12WWPEntityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPBaseObjects\\WWP_Description", "left", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageEntityRecordId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageEntityRecordId_Internalname, "Record Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageEntityRecordId_Internalname, A89WWPDiscussionMessageEntityRecordId, StringUtil.RTrim( context.localUtil.Format( A89WWPDiscussionMessageEntityRecordId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageEntityRecordId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageEntityRecordId_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
            Z87WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( "Z87WWPDiscussionMessageDate"), 0);
            Z88WWPDiscussionMessageMessage = cgiGet( "Z88WWPDiscussionMessageMessage");
            Z89WWPDiscussionMessageEntityRecordId = cgiGet( "Z89WWPDiscussionMessageEntityRecordId");
            Z1WWPUserExtendedId = cgiGet( "Z1WWPUserExtendedId");
            Z10WWPEntityId = (long)(context.localUtil.CToN( cgiGet( "Z10WWPEntityId"), ",", "."));
            Z84WWPDiscussionMessageThreadId = (long)(context.localUtil.CToN( cgiGet( "Z84WWPDiscussionMessageThreadId"), ",", "."));
            n84WWPDiscussionMessageThreadId = ((0==A84WWPDiscussionMessageThreadId) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
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
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPDiscussionMessageDate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Message Date"}), 1, "WWPDISCUSSIONMESSAGEDATE");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A87WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname));
               AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A84WWPDiscussionMessageThreadId = 0;
               n84WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
            }
            else
            {
               A84WWPDiscussionMessageThreadId = (long)(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), ",", "."));
               n84WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
            }
            n84WWPDiscussionMessageThreadId = ((0==A84WWPDiscussionMessageThreadId) ? true : false);
            A88WWPDiscussionMessageMessage = cgiGet( edtWWPDiscussionMessageMessage_Internalname);
            AssignAttri("", false, "A88WWPDiscussionMessageMessage", A88WWPDiscussionMessageMessage);
            A1WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A4WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
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
            A89WWPDiscussionMessageEntityRecordId = cgiGet( edtWWPDiscussionMessageEntityRecordId_Internalname);
            AssignAttri("", false, "A89WWPDiscussionMessageEntityRecordId", A89WWPDiscussionMessageEntityRecordId);
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
               A83WWPDiscussionMessageId = (long)(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."));
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
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
               InitAll0B12( ) ;
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
         DisableAttributes0B12( ) ;
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

      protected void ResetCaption0B0( )
      {
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z87WWPDiscussionMessageDate = T000B3_A87WWPDiscussionMessageDate[0];
               Z88WWPDiscussionMessageMessage = T000B3_A88WWPDiscussionMessageMessage[0];
               Z89WWPDiscussionMessageEntityRecordId = T000B3_A89WWPDiscussionMessageEntityRecordId[0];
               Z1WWPUserExtendedId = T000B3_A1WWPUserExtendedId[0];
               Z10WWPEntityId = T000B3_A10WWPEntityId[0];
               Z84WWPDiscussionMessageThreadId = T000B3_A84WWPDiscussionMessageThreadId[0];
            }
            else
            {
               Z87WWPDiscussionMessageDate = A87WWPDiscussionMessageDate;
               Z88WWPDiscussionMessageMessage = A88WWPDiscussionMessageMessage;
               Z89WWPDiscussionMessageEntityRecordId = A89WWPDiscussionMessageEntityRecordId;
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
               Z10WWPEntityId = A10WWPEntityId;
               Z84WWPDiscussionMessageThreadId = A84WWPDiscussionMessageThreadId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z87WWPDiscussionMessageDate = A87WWPDiscussionMessageDate;
            Z88WWPDiscussionMessageMessage = A88WWPDiscussionMessageMessage;
            Z89WWPDiscussionMessageEntityRecordId = A89WWPDiscussionMessageEntityRecordId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z10WWPEntityId = A10WWPEntityId;
            Z84WWPDiscussionMessageThreadId = A84WWPDiscussionMessageThreadId;
            Z4WWPUserExtendedPhoto = A4WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z12WWPEntityName = A12WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         A87WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         GXt_char1 = A1WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A1WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
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
            /* Using cursor T000B4 */
            pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T000B4_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A4WWPUserExtendedPhoto = T000B4_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            pr_default.close(2);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         }
      }

      protected void Load0B12( )
      {
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound12 = 1;
            A87WWPDiscussionMessageDate = T000B7_A87WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            A88WWPDiscussionMessageMessage = T000B7_A88WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A88WWPDiscussionMessageMessage", A88WWPDiscussionMessageMessage);
            A40000WWPUserExtendedPhoto_GXI = T000B7_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A12WWPEntityName = T000B7_A12WWPEntityName[0];
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
            A89WWPDiscussionMessageEntityRecordId = T000B7_A89WWPDiscussionMessageEntityRecordId[0];
            AssignAttri("", false, "A89WWPDiscussionMessageEntityRecordId", A89WWPDiscussionMessageEntityRecordId);
            A1WWPUserExtendedId = T000B7_A1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A10WWPEntityId = T000B7_A10WWPEntityId[0];
            AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            A84WWPDiscussionMessageThreadId = T000B7_A84WWPDiscussionMessageThreadId[0];
            n84WWPDiscussionMessageThreadId = T000B7_n84WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
            A4WWPUserExtendedPhoto = T000B7_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            ZM0B12( -6) ;
         }
         pr_default.close(5);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      protected void CheckExtendedTable0B12( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A87WWPDiscussionMessageDate) || ( A87WWPDiscussionMessageDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Message Date fora do intervalo", "OutOfRange", 1, "WWPDISCUSSIONMESSAGEDATE");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A84WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T000B4_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A4WWPUserExtendedPhoto = T000B4_A4WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         pr_default.close(2);
         nIsDirty_12 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A12WWPEntityName = T000B5_A12WWPEntityName[0];
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0B12( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A84WWPDiscussionMessageThreadId )
      {
         /* Using cursor T000B8 */
         pr_default.execute(6, new Object[] {n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A84WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
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

      protected void gxLoad_7( string A1WWPUserExtendedId )
      {
         /* Using cursor T000B9 */
         pr_default.execute(7, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T000B9_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A4WWPUserExtendedPhoto = T000B9_A4WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A4WWPUserExtendedPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000WWPUserExtendedPhoto_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_8( long A10WWPEntityId )
      {
         /* Using cursor T000B10 */
         pr_default.execute(8, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A12WWPEntityName = T000B10_A12WWPEntityName[0];
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A12WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0B12( )
      {
         /* Using cursor T000B11 */
         pr_default.execute(9, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 6) ;
            RcdFound12 = 1;
            A83WWPDiscussionMessageId = T000B3_A83WWPDiscussionMessageId[0];
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
            A87WWPDiscussionMessageDate = T000B3_A87WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            A88WWPDiscussionMessageMessage = T000B3_A88WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A88WWPDiscussionMessageMessage", A88WWPDiscussionMessageMessage);
            A89WWPDiscussionMessageEntityRecordId = T000B3_A89WWPDiscussionMessageEntityRecordId[0];
            AssignAttri("", false, "A89WWPDiscussionMessageEntityRecordId", A89WWPDiscussionMessageEntityRecordId);
            A1WWPUserExtendedId = T000B3_A1WWPUserExtendedId[0];
            AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
            A10WWPEntityId = T000B3_A10WWPEntityId[0];
            AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
            A84WWPDiscussionMessageThreadId = T000B3_A84WWPDiscussionMessageThreadId[0];
            n84WWPDiscussionMessageThreadId = T000B3_n84WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0B12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0B12( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B12( ) ;
         if ( RcdFound12 == 0 )
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
         RcdFound12 = 0;
         /* Using cursor T000B12 */
         pr_default.execute(10, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000B12_A83WWPDiscussionMessageId[0] < A83WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000B12_A83WWPDiscussionMessageId[0] > A83WWPDiscussionMessageId ) ) )
            {
               A83WWPDiscussionMessageId = T000B12_A83WWPDiscussionMessageId[0];
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T000B13 */
         pr_default.execute(11, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000B13_A83WWPDiscussionMessageId[0] > A83WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000B13_A83WWPDiscussionMessageId[0] < A83WWPDiscussionMessageId ) ) )
            {
               A83WWPDiscussionMessageId = T000B13_A83WWPDiscussionMessageId[0];
               AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B12( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId )
               {
                  A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
                  AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
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
                  Update0B12( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B12( ) ;
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
                     Insert0B12( ) ;
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
         if ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId )
         {
            A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B12( ) ;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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
         ScanStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound12 != 0 )
            {
               ScanNext0B12( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B12( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z87WWPDiscussionMessageDate != T000B2_A87WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z88WWPDiscussionMessageMessage, T000B2_A88WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z89WWPDiscussionMessageEntityRecordId, T000B2_A89WWPDiscussionMessageEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, T000B2_A1WWPUserExtendedId[0]) != 0 ) || ( Z10WWPEntityId != T000B2_A10WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z84WWPDiscussionMessageThreadId != T000B2_A84WWPDiscussionMessageThreadId[0] ) )
            {
               if ( Z87WWPDiscussionMessageDate != T000B2_A87WWPDiscussionMessageDate[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageDate");
                  GXUtil.WriteLogRaw("Old: ",Z87WWPDiscussionMessageDate);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A87WWPDiscussionMessageDate[0]);
               }
               if ( StringUtil.StrCmp(Z88WWPDiscussionMessageMessage, T000B2_A88WWPDiscussionMessageMessage[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageMessage");
                  GXUtil.WriteLogRaw("Old: ",Z88WWPDiscussionMessageMessage);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A88WWPDiscussionMessageMessage[0]);
               }
               if ( StringUtil.StrCmp(Z89WWPDiscussionMessageEntityRecordId, T000B2_A89WWPDiscussionMessageEntityRecordId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageEntityRecordId");
                  GXUtil.WriteLogRaw("Old: ",Z89WWPDiscussionMessageEntityRecordId);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A89WWPDiscussionMessageEntityRecordId[0]);
               }
               if ( StringUtil.StrCmp(Z1WWPUserExtendedId, T000B2_A1WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z1WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A1WWPUserExtendedId[0]);
               }
               if ( Z10WWPEntityId != T000B2_A10WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z10WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A10WWPEntityId[0]);
               }
               if ( Z84WWPDiscussionMessageThreadId != T000B2_A84WWPDiscussionMessageThreadId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageThreadId");
                  GXUtil.WriteLogRaw("Old: ",Z84WWPDiscussionMessageThreadId);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A84WWPDiscussionMessageThreadId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B14 */
                     pr_default.execute(12, new Object[] {A87WWPDiscussionMessageDate, A88WWPDiscussionMessageMessage, A89WWPDiscussionMessageEntityRecordId, A1WWPUserExtendedId, A10WWPEntityId, n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId});
                     A83WWPDiscussionMessageId = T000B14_A83WWPDiscussionMessageId[0];
                     AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0B0( ) ;
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B15 */
                     pr_default.execute(13, new Object[] {A87WWPDiscussionMessageDate, A88WWPDiscussionMessageMessage, A89WWPDiscussionMessageEntityRecordId, A1WWPUserExtendedId, A10WWPEntityId, n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId, A83WWPDiscussionMessageId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0B0( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B16 */
                  pr_default.execute(14, new Object[] {A83WWPDiscussionMessageId});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound12 == 0 )
                        {
                           InitAll0B12( ) ;
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
                        ResetCaption0B0( ) ;
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000B17 */
            pr_default.execute(15, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T000B17_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            A4WWPUserExtendedPhoto = T000B17_A4WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
            pr_default.close(15);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
            AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
            /* Using cursor T000B18 */
            pr_default.execute(16, new Object[] {A10WWPEntityId});
            A12WWPEntityName = T000B18_A12WWPEntityName[0];
            AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000B19 */
            pr_default.execute(17, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000B20 */
            pr_default.execute(18, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message Mention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
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
            context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B12( )
      {
         /* Using cursor T000B21 */
         pr_default.execute(19);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound12 = 1;
            A83WWPDiscussionMessageId = T000B21_A83WWPDiscussionMessageId[0];
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound12 = 1;
            A83WWPDiscussionMessageId = T000B21_A83WWPDiscussionMessageId[0];
            AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
         }
      }

      protected void ScanEnd0B12( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
         if ( (0==A84WWPDiscussionMessageThreadId) )
         {
            A84WWPDiscussionMessageThreadId = 0;
            n84WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
            n84WWPDiscussionMessageThreadId = true;
            AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
         }
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
         edtWWPDiscussionMessageId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageDate_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageDate_Enabled), 5, 0), true);
         edtWWPDiscussionMessageThreadId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageThreadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageThreadId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageMessage_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageMessage_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPDiscussionMessageEntityRecordId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageEntityRecordId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageEntityRecordId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202142815482585", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z87WWPDiscussionMessageDate", context.localUtil.TToC( Z87WWPDiscussionMessageDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z88WWPDiscussionMessageMessage", Z88WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z89WWPDiscussionMessageEntityRecordId", Z89WWPDiscussionMessageEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z84WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84WWPDiscussionMessageThreadId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Discussions.WWP_DiscussionMessage" ;
      }

      public override string GetPgmdesc( )
      {
         return "Discussion Message" ;
      }

      protected void InitializeNonKey0B12( )
      {
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         A1WWPUserExtendedId = "";
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         A2WWPUserExtendedFullName = "";
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         A84WWPDiscussionMessageThreadId = 0;
         n84WWPDiscussionMessageThreadId = false;
         AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
         n84WWPDiscussionMessageThreadId = ((0==A84WWPDiscussionMessageThreadId) ? true : false);
         A88WWPDiscussionMessageMessage = "";
         AssignAttri("", false, "A88WWPDiscussionMessageMessage", A88WWPDiscussionMessageMessage);
         A4WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A4WWPUserExtendedPhoto", A4WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A4WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A4WWPUserExtendedPhoto), true);
         A10WWPEntityId = 0;
         AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrimStr( (decimal)(A10WWPEntityId), 10, 0));
         A12WWPEntityName = "";
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         A89WWPDiscussionMessageEntityRecordId = "";
         AssignAttri("", false, "A89WWPDiscussionMessageEntityRecordId", A89WWPDiscussionMessageEntityRecordId);
         Z87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z88WWPDiscussionMessageMessage = "";
         Z89WWPDiscussionMessageEntityRecordId = "";
         Z1WWPUserExtendedId = "";
         Z10WWPEntityId = 0;
         Z84WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll0B12( )
      {
         A83WWPDiscussionMessageId = 0;
         AssignAttri("", false, "A83WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A83WWPDiscussionMessageId), 10, 0));
         InitializeNonKey0B12( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A87WWPDiscussionMessageDate = i87WWPDiscussionMessageDate;
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         A1WWPUserExtendedId = i1WWPUserExtendedId;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281548264", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionmessage.js", "?20214281548265", false, true);
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
         edtWWPDiscussionMessageThreadId_Internalname = "WWPDISCUSSIONMESSAGETHREADID";
         edtWWPDiscussionMessageMessage_Internalname = "WWPDISCUSSIONMESSAGEMESSAGE";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPDiscussionMessageEntityRecordId_Internalname = "WWPDISCUSSIONMESSAGEENTITYRECORDID";
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
         Form.Caption = "Discussion Message";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPDiscussionMessageEntityRecordId_Jsonclick = "";
         edtWWPDiscussionMessageEntityRecordId_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         imgWWPUserExtendedPhoto_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPDiscussionMessageMessage_Enabled = 1;
         edtWWPDiscussionMessageThreadId_Jsonclick = "";
         edtWWPDiscussionMessageThreadId_Enabled = 1;
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPDiscussionMessageDate_Enabled = 1;
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

      protected void GX2ASAWWPUSEREXTENDEDFULLNAME0B12( string A1WWPUserExtendedId )
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

      protected void GX4ASAWWPUSEREXTENDEDID0B12( string Gx_mode )
      {
         GXt_char1 = A1WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A1WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A1WWPUserExtendedId", A1WWPUserExtendedId);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1WWPUserExtendedId))+"\"") ;
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
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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

      public void Valid_Wwpdiscussionmessageid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A87WWPDiscussionMessageDate", context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1WWPUserExtendedId", StringUtil.RTrim( A1WWPUserExtendedId));
         AssignAttri("", false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         AssignAttri("", false, "A88WWPDiscussionMessageMessage", A88WWPDiscussionMessageMessage);
         AssignAttri("", false, "A10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A89WWPDiscussionMessageEntityRecordId", A89WWPDiscussionMessageEntityRecordId);
         AssignAttri("", false, "A4WWPUserExtendedPhoto", context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
         AssignAttri("", false, "A12WWPEntityName", A12WWPEntityName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z83WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z83WWPDiscussionMessageId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z87WWPDiscussionMessageDate", context.localUtil.TToC( Z87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1WWPUserExtendedId", StringUtil.RTrim( Z1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z84WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z88WWPDiscussionMessageMessage", Z88WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z10WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z89WWPDiscussionMessageEntityRecordId", Z89WWPDiscussionMessageEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z4WWPUserExtendedPhoto", context.PathToRelativeUrl( Z4WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z2WWPUserExtendedFullName", Z2WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z12WWPEntityName", Z12WWPEntityName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpdiscussionmessagethreadid( )
      {
         n84WWPDiscussionMessageThreadId = false;
         /* Using cursor T000B22 */
         pr_default.execute(20, new Object[] {n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A84WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
            }
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Wwpuserextendedid( )
      {
         /* Using cursor T000B17 */
         pr_default.execute(15, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
         }
         A40000WWPUserExtendedPhoto_GXI = T000B17_A40000WWPUserExtendedPhoto_GXI[0];
         A4WWPUserExtendedPhoto = T000B17_A4WWPUserExtendedPhoto[0];
         pr_default.close(15);
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A4WWPUserExtendedPhoto", context.PathToRelativeUrl( A4WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A2WWPUserExtendedFullName", A2WWPUserExtendedFullName);
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T000B18 */
         pr_default.execute(16, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A12WWPEntityName = T000B18_A12WWPEntityName[0];
         pr_default.close(16);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID","{handler:'Valid_Wwpdiscussionmessageid',iparms:[{av:'A83WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID",",oparms:[{av:'A87WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A84WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'A88WWPDiscussionMessageMessage',fld:'WWPDISCUSSIONMESSAGEMESSAGE',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A89WWPDiscussionMessageEntityRecordId',fld:'WWPDISCUSSIONMESSAGEENTITYRECORDID',pic:''},{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83WWPDiscussionMessageId'},{av:'Z87WWPDiscussionMessageDate'},{av:'Z1WWPUserExtendedId'},{av:'Z84WWPDiscussionMessageThreadId'},{av:'Z88WWPDiscussionMessageMessage'},{av:'Z10WWPEntityId'},{av:'Z89WWPDiscussionMessageEntityRecordId'},{av:'Z4WWPUserExtendedPhoto'},{av:'Z40000WWPUserExtendedPhoto_GXI'},{av:'Z2WWPUserExtendedFullName'},{av:'Z12WWPEntityName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEDATE","{handler:'Valid_Wwpdiscussionmessagedate',iparms:[]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEDATE",",oparms:[]}");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGETHREADID","{handler:'Valid_Wwpdiscussionmessagethreadid',iparms:[{av:'A84WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGETHREADID",",oparms:[]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A4WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A2WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''}]}");
         setEventMetadata("VALID_WWPENTITYID","{handler:'Valid_Wwpentityid',iparms:[{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''}]");
         setEventMetadata("VALID_WWPENTITYID",",oparms:[{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''}]}");
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
         pr_default.close(16);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z88WWPDiscussionMessageMessage = "";
         Z89WWPDiscussionMessageEntityRecordId = "";
         Z1WWPUserExtendedId = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A1WWPUserExtendedId = "";
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
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A88WWPDiscussionMessageMessage = "";
         A4WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         sImgUrl = "";
         A2WWPUserExtendedFullName = "";
         A12WWPEntityName = "";
         A89WWPDiscussionMessageEntityRecordId = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z4WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         Z12WWPEntityName = "";
         T000B4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000B4_A4WWPUserExtendedPhoto = new string[] {""} ;
         T000B7_A83WWPDiscussionMessageId = new long[1] ;
         T000B7_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000B7_A88WWPDiscussionMessageMessage = new string[] {""} ;
         T000B7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000B7_A12WWPEntityName = new string[] {""} ;
         T000B7_A89WWPDiscussionMessageEntityRecordId = new string[] {""} ;
         T000B7_A1WWPUserExtendedId = new string[] {""} ;
         T000B7_A10WWPEntityId = new long[1] ;
         T000B7_A84WWPDiscussionMessageThreadId = new long[1] ;
         T000B7_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000B7_A4WWPUserExtendedPhoto = new string[] {""} ;
         T000B6_A84WWPDiscussionMessageThreadId = new long[1] ;
         T000B6_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000B5_A12WWPEntityName = new string[] {""} ;
         T000B8_A84WWPDiscussionMessageThreadId = new long[1] ;
         T000B8_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000B9_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000B9_A4WWPUserExtendedPhoto = new string[] {""} ;
         T000B10_A12WWPEntityName = new string[] {""} ;
         T000B11_A83WWPDiscussionMessageId = new long[1] ;
         T000B3_A83WWPDiscussionMessageId = new long[1] ;
         T000B3_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000B3_A88WWPDiscussionMessageMessage = new string[] {""} ;
         T000B3_A89WWPDiscussionMessageEntityRecordId = new string[] {""} ;
         T000B3_A1WWPUserExtendedId = new string[] {""} ;
         T000B3_A10WWPEntityId = new long[1] ;
         T000B3_A84WWPDiscussionMessageThreadId = new long[1] ;
         T000B3_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode12 = "";
         T000B12_A83WWPDiscussionMessageId = new long[1] ;
         T000B13_A83WWPDiscussionMessageId = new long[1] ;
         T000B2_A83WWPDiscussionMessageId = new long[1] ;
         T000B2_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000B2_A88WWPDiscussionMessageMessage = new string[] {""} ;
         T000B2_A89WWPDiscussionMessageEntityRecordId = new string[] {""} ;
         T000B2_A1WWPUserExtendedId = new string[] {""} ;
         T000B2_A10WWPEntityId = new long[1] ;
         T000B2_A84WWPDiscussionMessageThreadId = new long[1] ;
         T000B2_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000B14_A83WWPDiscussionMessageId = new long[1] ;
         T000B17_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000B17_A4WWPUserExtendedPhoto = new string[] {""} ;
         T000B18_A12WWPEntityName = new string[] {""} ;
         T000B19_A84WWPDiscussionMessageThreadId = new long[1] ;
         T000B19_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000B20_A83WWPDiscussionMessageId = new long[1] ;
         T000B20_A85WWPDiscussionMentionUserId = new string[] {""} ;
         T000B21_A83WWPDiscussionMessageId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i1WWPUserExtendedId = "";
         Z2WWPUserExtendedFullName = "";
         ZZ87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         ZZ1WWPUserExtendedId = "";
         ZZ88WWPDiscussionMessageMessage = "";
         ZZ89WWPDiscussionMessageEntityRecordId = "";
         ZZ4WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ2WWPUserExtendedFullName = "";
         ZZ12WWPEntityName = "";
         T000B22_A84WWPDiscussionMessageThreadId = new long[1] ;
         T000B22_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         GXt_char1 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__default(),
            new Object[][] {
                new Object[] {
               T000B2_A83WWPDiscussionMessageId, T000B2_A87WWPDiscussionMessageDate, T000B2_A88WWPDiscussionMessageMessage, T000B2_A89WWPDiscussionMessageEntityRecordId, T000B2_A1WWPUserExtendedId, T000B2_A10WWPEntityId, T000B2_A84WWPDiscussionMessageThreadId, T000B2_n84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000B3_A83WWPDiscussionMessageId, T000B3_A87WWPDiscussionMessageDate, T000B3_A88WWPDiscussionMessageMessage, T000B3_A89WWPDiscussionMessageEntityRecordId, T000B3_A1WWPUserExtendedId, T000B3_A10WWPEntityId, T000B3_A84WWPDiscussionMessageThreadId, T000B3_n84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000B4_A40000WWPUserExtendedPhoto_GXI, T000B4_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T000B5_A12WWPEntityName
               }
               , new Object[] {
               T000B6_A84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000B7_A83WWPDiscussionMessageId, T000B7_A87WWPDiscussionMessageDate, T000B7_A88WWPDiscussionMessageMessage, T000B7_A40000WWPUserExtendedPhoto_GXI, T000B7_A12WWPEntityName, T000B7_A89WWPDiscussionMessageEntityRecordId, T000B7_A1WWPUserExtendedId, T000B7_A10WWPEntityId, T000B7_A84WWPDiscussionMessageThreadId, T000B7_n84WWPDiscussionMessageThreadId,
               T000B7_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T000B8_A84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000B9_A40000WWPUserExtendedPhoto_GXI, T000B9_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T000B10_A12WWPEntityName
               }
               , new Object[] {
               T000B11_A83WWPDiscussionMessageId
               }
               , new Object[] {
               T000B12_A83WWPDiscussionMessageId
               }
               , new Object[] {
               T000B13_A83WWPDiscussionMessageId
               }
               , new Object[] {
               T000B14_A83WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B17_A40000WWPUserExtendedPhoto_GXI, T000B17_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               T000B18_A12WWPEntityName
               }
               , new Object[] {
               T000B19_A84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000B20_A83WWPDiscussionMessageId, T000B20_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000B21_A83WWPDiscussionMessageId
               }
               , new Object[] {
               T000B22_A84WWPDiscussionMessageThreadId
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
      private short Gx_BScreen ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPDiscussionMessageId_Enabled ;
      private int edtWWPDiscussionMessageDate_Enabled ;
      private int edtWWPDiscussionMessageThreadId_Enabled ;
      private int edtWWPDiscussionMessageMessage_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPDiscussionMessageEntityRecordId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z83WWPDiscussionMessageId ;
      private long Z10WWPEntityId ;
      private long Z84WWPDiscussionMessageThreadId ;
      private long A84WWPDiscussionMessageThreadId ;
      private long A10WWPEntityId ;
      private long A83WWPDiscussionMessageId ;
      private long ZZ83WWPDiscussionMessageId ;
      private long ZZ84WWPDiscussionMessageThreadId ;
      private long ZZ10WWPEntityId ;
      private string sPrefix ;
      private string Z1WWPUserExtendedId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1WWPUserExtendedId ;
      private string Gx_mode ;
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
      private string edtWWPDiscussionMessageThreadId_Internalname ;
      private string edtWWPDiscussionMessageThreadId_Jsonclick ;
      private string edtWWPDiscussionMessageMessage_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string sImgUrl ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPDiscussionMessageEntityRecordId_Internalname ;
      private string edtWWPDiscussionMessageEntityRecordId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode12 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i1WWPUserExtendedId ;
      private string ZZ1WWPUserExtendedId ;
      private string GXt_char1 ;
      private DateTime Z87WWPDiscussionMessageDate ;
      private DateTime A87WWPDiscussionMessageDate ;
      private DateTime i87WWPDiscussionMessageDate ;
      private DateTime ZZ87WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n84WWPDiscussionMessageThreadId ;
      private bool wbErr ;
      private bool A4WWPUserExtendedPhoto_IsBlob ;
      private bool Gx_longc ;
      private string Z88WWPDiscussionMessageMessage ;
      private string Z89WWPDiscussionMessageEntityRecordId ;
      private string A88WWPDiscussionMessageMessage ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A2WWPUserExtendedFullName ;
      private string A12WWPEntityName ;
      private string A89WWPDiscussionMessageEntityRecordId ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string Z12WWPEntityName ;
      private string Z2WWPUserExtendedFullName ;
      private string ZZ88WWPDiscussionMessageMessage ;
      private string ZZ89WWPDiscussionMessageEntityRecordId ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ2WWPUserExtendedFullName ;
      private string ZZ12WWPEntityName ;
      private string A4WWPUserExtendedPhoto ;
      private string Z4WWPUserExtendedPhoto ;
      private string ZZ4WWPUserExtendedPhoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000B4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000B4_A4WWPUserExtendedPhoto ;
      private long[] T000B7_A83WWPDiscussionMessageId ;
      private DateTime[] T000B7_A87WWPDiscussionMessageDate ;
      private string[] T000B7_A88WWPDiscussionMessageMessage ;
      private string[] T000B7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000B7_A12WWPEntityName ;
      private string[] T000B7_A89WWPDiscussionMessageEntityRecordId ;
      private string[] T000B7_A1WWPUserExtendedId ;
      private long[] T000B7_A10WWPEntityId ;
      private long[] T000B7_A84WWPDiscussionMessageThreadId ;
      private bool[] T000B7_n84WWPDiscussionMessageThreadId ;
      private string[] T000B7_A4WWPUserExtendedPhoto ;
      private long[] T000B6_A84WWPDiscussionMessageThreadId ;
      private bool[] T000B6_n84WWPDiscussionMessageThreadId ;
      private string[] T000B5_A12WWPEntityName ;
      private long[] T000B8_A84WWPDiscussionMessageThreadId ;
      private bool[] T000B8_n84WWPDiscussionMessageThreadId ;
      private string[] T000B9_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000B9_A4WWPUserExtendedPhoto ;
      private string[] T000B10_A12WWPEntityName ;
      private long[] T000B11_A83WWPDiscussionMessageId ;
      private long[] T000B3_A83WWPDiscussionMessageId ;
      private DateTime[] T000B3_A87WWPDiscussionMessageDate ;
      private string[] T000B3_A88WWPDiscussionMessageMessage ;
      private string[] T000B3_A89WWPDiscussionMessageEntityRecordId ;
      private string[] T000B3_A1WWPUserExtendedId ;
      private long[] T000B3_A10WWPEntityId ;
      private long[] T000B3_A84WWPDiscussionMessageThreadId ;
      private bool[] T000B3_n84WWPDiscussionMessageThreadId ;
      private long[] T000B12_A83WWPDiscussionMessageId ;
      private long[] T000B13_A83WWPDiscussionMessageId ;
      private long[] T000B2_A83WWPDiscussionMessageId ;
      private DateTime[] T000B2_A87WWPDiscussionMessageDate ;
      private string[] T000B2_A88WWPDiscussionMessageMessage ;
      private string[] T000B2_A89WWPDiscussionMessageEntityRecordId ;
      private string[] T000B2_A1WWPUserExtendedId ;
      private long[] T000B2_A10WWPEntityId ;
      private long[] T000B2_A84WWPDiscussionMessageThreadId ;
      private bool[] T000B2_n84WWPDiscussionMessageThreadId ;
      private long[] T000B14_A83WWPDiscussionMessageId ;
      private string[] T000B17_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000B17_A4WWPUserExtendedPhoto ;
      private string[] T000B18_A12WWPEntityName ;
      private long[] T000B19_A84WWPDiscussionMessageThreadId ;
      private bool[] T000B19_n84WWPDiscussionMessageThreadId ;
      private long[] T000B20_A83WWPDiscussionMessageId ;
      private string[] T000B20_A85WWPDiscussionMentionUserId ;
      private long[] T000B21_A83WWPDiscussionMessageId ;
      private long[] T000B22_A84WWPDiscussionMessageThreadId ;
      private bool[] T000B22_n84WWPDiscussionMessageThreadId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_discussionmessage__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000B7;
        prmT000B7 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B6;
        prmT000B6 = new Object[] {
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B4;
        prmT000B4 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000B5;
        prmT000B5 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B8;
        prmT000B8 = new Object[] {
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B9;
        prmT000B9 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000B10;
        prmT000B10 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B11;
        prmT000B11 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B3;
        prmT000B3 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B12;
        prmT000B12 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B13;
        prmT000B13 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B2;
        prmT000B2 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B14;
        prmT000B14 = new Object[] {
        new Object[] {"@WWPDiscussionMessageDate",SqlDbType.DateTime,8,5} ,
        new Object[] {"@WWPDiscussionMessageMessage",SqlDbType.NVarChar,400,0} ,
        new Object[] {"@WWPDiscussionMessageEntityRecordId",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B15;
        prmT000B15 = new Object[] {
        new Object[] {"@WWPDiscussionMessageDate",SqlDbType.DateTime,8,5} ,
        new Object[] {"@WWPDiscussionMessageMessage",SqlDbType.NVarChar,400,0} ,
        new Object[] {"@WWPDiscussionMessageEntityRecordId",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B16;
        prmT000B16 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B19;
        prmT000B19 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B20;
        prmT000B20 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B21;
        prmT000B21 = new Object[] {
        };
        Object[] prmT000B22;
        prmT000B22 = new Object[] {
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0}
        };
        Object[] prmT000B17;
        prmT000B17 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmT000B18;
        prmT000B18 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("T000B2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityRecordId], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityRecordId], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B4", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B5", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B6", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B7", "SELECT TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageMessage], T2.[WWPUserExtendedPhoto_GXI], T3.[WWPEntityName], TM1.[WWPDiscussionMessageEntityRecordId], TM1.[WWPUserExtendedId], TM1.[WWPEntityId], TM1.[WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId, T2.[WWPUserExtendedPhoto] FROM (([WWP_DiscussionMessage] TM1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId ORDER BY TM1.[WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B8", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B9", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B10", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B11", "SELECT [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B12", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE ( [WWPDiscussionMessageId] > @WWPDiscussionMessageId) ORDER BY [WWPDiscussionMessageId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B13", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE ( [WWPDiscussionMessageId] < @WWPDiscussionMessageId) ORDER BY [WWPDiscussionMessageId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B14", "INSERT INTO [WWP_DiscussionMessage]([WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityRecordId], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId]) VALUES(@WWPDiscussionMessageDate, @WWPDiscussionMessageMessage, @WWPDiscussionMessageEntityRecordId, @WWPUserExtendedId, @WWPEntityId, @WWPDiscussionMessageThreadId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000B14)
           ,new CursorDef("T000B15", "UPDATE [WWP_DiscussionMessage] SET [WWPDiscussionMessageDate]=@WWPDiscussionMessageDate, [WWPDiscussionMessageMessage]=@WWPDiscussionMessageMessage, [WWPDiscussionMessageEntityRecordId]=@WWPDiscussionMessageEntityRecordId, [WWPUserExtendedId]=@WWPUserExtendedId, [WWPEntityId]=@WWPEntityId, [WWPDiscussionMessageThreadId]=@WWPDiscussionMessageThreadId  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmT000B15)
           ,new CursorDef("T000B16", "DELETE FROM [WWP_DiscussionMessage]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmT000B16)
           ,new CursorDef("T000B17", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B18", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B19", "SELECT TOP 1 [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageThreadId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B20", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B21", "SELECT [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] ORDER BY [WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B21,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B22", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B22,1, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 40);
              table[5][0] = rslt.getLong(6);
              table[6][0] = rslt.getLong(7);
              table[7][0] = rslt.wasNull(7);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 40);
              table[5][0] = rslt.getLong(6);
              table[6][0] = rslt.getLong(7);
              table[7][0] = rslt.wasNull(7);
              return;
           case 2 :
              table[0][0] = rslt.getMultimediaUri(1);
              table[1][0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getMultimediaUri(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getString(7, 40);
              table[7][0] = rslt.getLong(8);
              table[8][0] = rslt.getLong(9);
              table[9][0] = rslt.wasNull(9);
              table[10][0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 7 :
              table[0][0] = rslt.getMultimediaUri(1);
              table[1][0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 8 :
              table[0][0] = rslt.getVarchar(1);
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
              table[0][0] = rslt.getMultimediaUri(1);
              table[1][0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 16 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 17 :
              table[0][0] = rslt.getLong(1);
              return;
           case 18 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 19 :
              table[0][0] = rslt.getLong(1);
              return;
           case 20 :
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
              stmt.SetParameter(1, (string)parms[0]);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (long)parms[0]);
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
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (long)parms[4]);
              if ( (bool)parms[5] )
              {
                 stmt.setNull( 6 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(6, (long)parms[6]);
              }
              return;
           case 13 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (long)parms[4]);
              if ( (bool)parms[5] )
              {
                 stmt.setNull( 6 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(6, (long)parms[6]);
              }
              stmt.SetParameter(7, (long)parms[7]);
              return;
           case 14 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 15 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 16 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 17 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 18 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 20 :
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
