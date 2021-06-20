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
namespace GeneXus.Programs {
   public class gamremotelogin : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public gamremotelogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamremotelogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref string aP0_ApplicationClientId )
      {
         this.AV32ApplicationClientId = aP0_ApplicationClientId;
         executePrivate();
         aP0_ApplicationClientId=this.AV32ApplicationClientId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavLogonto = new GXCombobox();
         chkavKeepmeloggedin = new GXCheckbox();
         chkavRememberme = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ApplicationClientId");
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
               gxfirstwebparm = GetFirstPar( "ApplicationClientId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ApplicationClientId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV32ApplicationClientId = gxfirstwebparm;
               AssignAttri("", false, "AV32ApplicationClientId", AV32ApplicationClientId);
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            PA0F2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavCmpname_Enabled = 0;
               AssignProp("", false, edtavCmpname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCmpname_Enabled), 5, 0), true);
               WS0F2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0F2( ) ;
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Remote Login ") ;
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
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202142815511659", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( 0) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamremotelogin.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV32ApplicationClientId))}, new string[] {"ApplicationClientId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30UserRememberMe), "Z9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONCLIENTID", StringUtil.RTrim( AV32ApplicationClientId));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV18Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30UserRememberMe), "Z9"), context));
      }

      protected void RenderHtmlCloseForm0F2( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GAMRemoteLogin" ;
      }

      public override string GetPgmdesc( )
      {
         return "Remote Login " ;
      }

      protected void WB0F0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLogin", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeaderoriginal_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLoginWithLeftImage", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "Provedor de identidade", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table1_21_0F2( true) ;
         }
         else
         {
            wb_table1_21_0F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_0F2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableloginerror_Internalname, divTableloginerror_Visible, 0, "px", 0, "px", "TableLoginError", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0F2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148565", 0) ;
            }
            Form.Meta.addItem("description", "Remote Login ", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0F0( ) ;
      }

      protected void WS0F2( )
      {
         START0F2( ) ;
         EVT0F2( ) ;
      }

      protected void EVT0F2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E120F2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E130F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E140F2 ();
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
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

      protected void WE0F2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0F2( ) ;
            }
         }
      }

      protected void PA0F2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavCmpname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV21LogOnTo = cmbavLogonto.getValidValue(AV21LogOnTo);
            AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV21LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV17KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV17KeepMeLoggedIn));
         AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
         AV22RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV22RememberMe));
         AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCmpname_Enabled = 0;
         AssignProp("", false, edtavCmpname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCmpname_Enabled), 5, 0), true);
      }

      protected void RF0F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E130F2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140F2 ();
            WB0F0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0F2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV18Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30UserRememberMe), "Z9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCmpname_Enabled = 0;
         AssignProp("", false, edtavCmpname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCmpname_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV20LogoAppClient = cgiGet( imgavLogoappclient_Internalname);
            AV34CmpName = cgiGet( edtavCmpname_Internalname);
            AssignAttri("", false, "AV34CmpName", AV34CmpName);
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV21LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
            AV28UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV28UserName", AV28UserName);
            AV29UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV29UserPassword", AV29UserPassword);
            AV17KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
            AV22RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110F2 ();
         if (returnInSub) return;
      }

      protected void E110F2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Backcolor = GXUtil.RGB( 238, 238, 238);
         AssignProp("", false, "FORM", "Backcolor", StringUtil.LTrimStr( (decimal)(Form.Backcolor), 9, 0), true);
         AV15isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         if ( ! AV15isOK )
         {
            AV8ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
            if ( AV8ConnectionInfoCollection.Count > 0 )
            {
               AV15isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV8ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV10Errors);
            }
         }
         if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV32ApplicationClientId) )
         {
            AV31GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getremoteapplication(AV32ApplicationClientId, out  AV10Errors);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31GAMApplication.gxTpr_Clientimageurl)) )
            {
               AV34CmpName = AV31GAMApplication.gxTpr_Name;
               AssignAttri("", false, "AV34CmpName", AV34CmpName);
            }
         }
         else
         {
            GX_msglist.addItem(StringUtil.Format( "Id aplicativo cliente não encontrado (%1)", AV32ApplicationClientId, "", "", "", "", "", "", "", ""));
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         divTableloginerror_Visible = 0;
         AssignProp("", false, divTableloginerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableloginerror_Visible), 5, 0), true);
         lblForgotpassword_Link = formatLink("gamrecoverpasswordstep1.aspx") ;
         AssignProp("", false, lblForgotpassword_Internalname, "Link", lblForgotpassword_Link, true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120F2 ();
         if (returnInSub) return;
      }

      protected void E120F2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV17KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = (short)((AV17KeepMeLoggedIn ? 3 : 1));
         }
         else
         {
            if ( AV22RememberMe )
            {
               AV5AdditionalParameter.gxTpr_Rememberusertype = (short)((AV22RememberMe ? 2 : 1));
            }
            else
            {
               AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
            }
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV21LogOnTo;
         AV19LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV28UserName, AV29UserPassword, AV5AdditionalParameter, out  AV10Errors);
         if ( AV19LoginOK )
         {
         }
         else
         {
            if ( AV10Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("gamchangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV32ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(1)).gxTpr_Code == 161 )
               {
                  CallWebObject(formatLink("gamupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV32ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV29UserPassword = "";
                  AssignAttri("", false, "AV29UserPassword", AV29UserPassword);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31GAMApplication.gxTpr_Clientimageurl)) ) )
         {
            imgavLogoappclient_Visible = 0;
            AssignProp("", false, imgavLogoappclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavLogoappclient_Visible), 5, 0), true);
            cellLogoappclient_cell_Class = "Invisible";
            AssignProp("", false, cellLogoappclient_cell_Internalname, "Class", cellLogoappclient_cell_Class, true);
         }
         else
         {
            imgavLogoappclient_Visible = 1;
            AssignProp("", false, imgavLogoappclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavLogoappclient_Visible), 5, 0), true);
            cellLogoappclient_cell_Class = "";
            AssignProp("", false, cellLogoappclient_cell_Internalname, "Class", cellLogoappclient_cell_Class, true);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV31GAMApplication.gxTpr_Clientimageurl)) ) )
         {
            edtavCmpname_Visible = 0;
            AssignProp("", false, edtavCmpname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCmpname_Visible), 5, 0), true);
            cellCmpname_cell_Class = "Invisible";
            AssignProp("", false, cellCmpname_cell_Internalname, "Class", cellCmpname_cell_Class, true);
         }
         else
         {
            edtavCmpname_Visible = 1;
            AssignProp("", false, edtavCmpname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCmpname_Visible), 5, 0), true);
            cellCmpname_cell_Class = "DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, cellCmpname_cell_Internalname, "Class", cellCmpname_cell_Class, true);
         }
         if ( ! ( ( cmbavLogonto.ItemCount > 1 ) ) )
         {
            cmbavLogonto.Visible = 0;
            AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
            cellLogonto_cell_Class = "Invisible";
            AssignProp("", false, cellLogonto_cell_Internalname, "Class", cellLogonto_cell_Class, true);
         }
         else
         {
            cmbavLogonto.Visible = 1;
            AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
            cellLogonto_cell_Class = "DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, cellLogonto_cell_Internalname, "Class", cellLogonto_cell_Class, true);
         }
         if ( ! ( ( 1 == 1 ) ) )
         {
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            cellKeepmeloggedin_cell_Class = "Invisible";
            AssignProp("", false, cellKeepmeloggedin_cell_Internalname, "Class", cellKeepmeloggedin_cell_Class, true);
         }
         else
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            cellKeepmeloggedin_cell_Class = "DataContentCellLogin";
            AssignProp("", false, cellKeepmeloggedin_cell_Internalname, "Class", cellKeepmeloggedin_cell_Class, true);
         }
         if ( ! ( ( 1 == 1 ) ) )
         {
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
            cellRememberme_cell_Class = "Invisible";
            AssignProp("", false, cellRememberme_cell_Internalname, "Class", cellRememberme_cell_Class, true);
         }
         else
         {
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
            cellRememberme_cell_Class = "DataContentCellLogin";
            AssignProp("", false, cellRememberme_cell_Internalname, "Class", cellRememberme_cell_Class, true);
         }
      }

      protected void E130F2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV33hasError = false;
         AV11ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV11ErrorsLogin.Count > 0 )
         {
            AV33hasError = true;
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 23 ) )
            {
               CallWebObject(formatLink("gamchangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV32ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
               context.wjLocDisableFrm = 1;
            }
            else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11ErrorsLogin.Item(1)).gxTpr_Code == 161 )
            {
               CallWebObject(formatLink("gamupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV32ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               AV29UserPassword = "";
               AssignAttri("", false, "AV29UserPassword", AV29UserPassword);
               AV10Errors = AV11ErrorsLogin;
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         if ( ! AV33hasError )
         {
            AV26SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV25Session, out  AV10Errors);
            if ( AV26SessionValid && ! AV25Session.gxTpr_Isanonymous )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV32ApplicationClientId) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV32ApplicationClientId) ;
               }
               else
               {
                  AV27URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27URL)) )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).gohome() ;
                  }
                  else
                  {
                     CallWebObject(formatLink(AV27URL) );
                     context.wjLocDisableFrm = 0;
                  }
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV18Language, out  AV10Errors);
               AV39GXV1 = 1;
               while ( AV39GXV1 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV39GXV1));
                  if ( AV6AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV6AuthenticationType.gxTpr_Name, AV6AuthenticationType.gxTpr_Description, 0);
                  }
                  AV39GXV1 = (int)(AV39GXV1+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               AV15isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV21LogOnTo, out  AV28UserName, out  AV30UserRememberMe, out  AV10Errors);
               if ( AV30UserRememberMe == 2 )
               {
                  AV22RememberMe = true;
                  AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
               }
               AV23Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV21LogOnTo = AV23Repository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
               }
               chkavRememberme.Visible = 0;
               AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               chkavKeepmeloggedin.Visible = 0;
               AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               if ( StringUtil.StrCmp(AV23Repository.gxTpr_Userremembermetype, "Login") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV23Repository.gxTpr_Userremembermetype, "Auth") == 0 )
               {
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV23Repository.gxTpr_Userremembermetype, "Both") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
            }
         }
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV21LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         divTableloginerror_Visible = 1;
         AssignProp("", false, divTableloginerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableloginerror_Visible), 5, 0), true);
         AV40GXV2 = 1;
         while ( AV40GXV2 <= AV10Errors.Count )
         {
            AV9Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10Errors.Item(AV40GXV2));
            if ( AV9Error.gxTpr_Code != 13 )
            {
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV9Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV9Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            }
            AV40GXV2 = (int)(AV40GXV2+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140F2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_21_0F2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellLogoappclient_cell_Internalname+"\" data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\" class='"+cellLogoappclient_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Logo App Client", "gx-form-item ReadonlyAttributeLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            AV20LogoAppClient_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient))&&String.IsNullOrEmpty(StringUtil.RTrim( AV41Logoappclient_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20LogoAppClient)) ? AV41Logoappclient_GXI : context.PathToRelativeUrl( AV20LogoAppClient));
            GxWebStd.gx_bitmap( context, imgavLogoappclient_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavLogoappclient_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV20LogoAppClient_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellCmpname_cell_Internalname+"\" data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\" class='"+cellCmpname_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmpname_Internalname, "Cmp Name", "gx-form-item AttributeLoginImageLeftLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmpname_Internalname, AV34CmpName, StringUtil.RTrim( context.localUtil.Format( AV34CmpName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmpname_Jsonclick, 0, "AttributeLoginImageLeft", "", "", "", "", edtavCmpname_Visible, edtavCmpname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellLogonto_cell_Internalname+"\"  class='"+cellLogonto_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Log On To", "gx-form-item AttributeLoginImageLeftLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV21LogOnTo), 1, cmbavLogonto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeLoginImageLeft", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, "HLP_GAMRemoteLogin.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV21LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellLogin CellPaddingLogin DscTop'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableusername_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockusername_Internalname, "Email", "", "", lblTextblockusername_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User Name", "col-sm-3 AttributeLoginImageLeftLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV28UserName, StringUtil.RTrim( context.localUtil.Format( AV28UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "AttributeLoginImageLeft", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellLogin CellPaddingLogin DscTop'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableuserpassword_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockuserpassword_Internalname, "Senha", "", "", lblTextblockuserpassword_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "User Password", "col-sm-3 AttributeLoginImageLeftLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV29UserPassword), StringUtil.RTrim( context.localUtil.Format( AV29UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserpassword_Jsonclick, 0, "AttributeLoginImageLeft", "", "", "", "", 1, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMRemoteLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellLogin CellPaddingLogin'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblForgotpassword_Internalname, "Esqueceu sua senha?", lblForgotpassword_Link, "", lblForgotpassword_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescriptionLogin", 0, "", 1, 1, 0, 1, "HLP_GAMRemoteLogin.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellKeepmeloggedin_cell_Internalname+"\"  class='"+cellKeepmeloggedin_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavKeepmeloggedin_Internalname, "Keep Me Logged In", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV17KeepMeLoggedIn), "", "Keep Me Logged In", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", " Keep me logged in", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(58, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,58);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellRememberme_cell_Internalname+"\"  class='"+cellRememberme_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRememberme_Internalname, "Remember Me", "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV22RememberMe), "", "Remember Me", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "Lembrar-me", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(62, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,62);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellLogin CellPaddingLogin'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Iniciar sessão", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRemoteLogin.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_0F2e( true) ;
         }
         else
         {
            wb_table1_21_0F2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV32ApplicationClientId = (string)getParm(obj,0);
         AssignAttri("", false, "AV32ApplicationClientId", AV32ApplicationClientId);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0F2( ) ;
         WS0F2( ) ;
         WE0F2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815514184", true, true);
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
         context.AddJavascriptSource("gamremotelogin.js", "?202142815514188", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV21LogOnTo = cmbavLogonto.getValidValue(AV21LogOnTo);
            AssignAttri("", false, "AV21LogOnTo", AV21LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = " Keep me logged in";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV17KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV17KeepMeLoggedIn));
         AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "Lembrar-me";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV22RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV22RememberMe));
         AssignAttri("", false, "AV22RememberMe", AV22RememberMe);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeaderoriginal_Internalname = "HEADERORIGINAL";
         lblSignin_Internalname = "SIGNIN";
         imgavLogoappclient_Internalname = "vLOGOAPPCLIENT";
         cellLogoappclient_cell_Internalname = "LOGOAPPCLIENT_CELL";
         edtavCmpname_Internalname = "vCMPNAME";
         cellCmpname_cell_Internalname = "CMPNAME_CELL";
         cmbavLogonto_Internalname = "vLOGONTO";
         cellLogonto_cell_Internalname = "LOGONTO_CELL";
         lblTextblockusername_Internalname = "TEXTBLOCKUSERNAME";
         edtavUsername_Internalname = "vUSERNAME";
         divUnnamedtableusername_Internalname = "UNNAMEDTABLEUSERNAME";
         lblTextblockuserpassword_Internalname = "TEXTBLOCKUSERPASSWORD";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         divUnnamedtableuserpassword_Internalname = "UNNAMEDTABLEUSERPASSWORD";
         lblForgotpassword_Internalname = "FORGOTPASSWORD";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         cellKeepmeloggedin_cell_Internalname = "KEEPMELOGGEDIN_CELL";
         chkavRememberme_Internalname = "vREMEMBERME";
         cellRememberme_cell_Internalname = "REMEMBERME_CELL";
         bttBtnenter_Internalname = "BTNENTER";
         tblUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablelogin_Internalname = "TABLELOGIN";
         divTableloginerror_Internalname = "TABLELOGINERROR";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         chkavRememberme.Caption = "Remember Me";
         chkavKeepmeloggedin.Caption = "Keep Me Logged In";
         chkavRememberme.Enabled = 1;
         cellRememberme_cell_Class = "";
         chkavKeepmeloggedin.Enabled = 1;
         cellKeepmeloggedin_cell_Class = "";
         lblForgotpassword_Link = "";
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cellLogonto_cell_Class = "";
         edtavCmpname_Jsonclick = "";
         edtavCmpname_Enabled = 1;
         cellCmpname_cell_Class = "";
         cellLogoappclient_cell_Class = "";
         chkavRememberme.Visible = 1;
         chkavKeepmeloggedin.Visible = 1;
         cmbavLogonto.Visible = 1;
         edtavCmpname_Visible = 1;
         imgavLogoappclient_Visible = 1;
         divTableloginerror_Visible = 1;
         Form.Backcolor = (int)(0xFFFFFF);
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV32ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV28UserName',fld:'vUSERNAME',pic:''},{av:'AV18Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV30UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV32ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV29UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'cmbavLogonto'},{av:'AV21LogOnTo',fld:'vLOGONTO',pic:''},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'divTableloginerror_Visible',ctrl:'TABLELOGINERROR',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E120F2',iparms:[{av:'cmbavLogonto'},{av:'AV21LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV28UserName',fld:'vUSERNAME',pic:''},{av:'AV29UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV32ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV32ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV29UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'divTableloginerror_Visible',ctrl:'TABLELOGINERROR',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV22RememberMe',fld:'vREMEMBERME',pic:''}]}");
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
      }

      public override void initialize( )
      {
         wcpOAV32ApplicationClientId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV18Language = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblSignin_Jsonclick = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV21LogOnTo = "";
         AV20LogoAppClient = "";
         AV34CmpName = "";
         AV28UserName = "";
         AV29UserPassword = "";
         AV8ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV10Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV31GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV5AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV11ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV25Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV27URL = "";
         AV7AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV6AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV23Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV9Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         AV41Logoappclient_GXI = "";
         TempTags = "";
         lblTextblockusername_Jsonclick = "";
         lblTextblockuserpassword_Jsonclick = "";
         lblForgotpassword_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCmpname_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short AV30UserRememberMe ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavCmpname_Enabled ;
      private int divTableloginerror_Visible ;
      private int imgavLogoappclient_Visible ;
      private int edtavCmpname_Visible ;
      private int AV39GXV1 ;
      private int AV40GXV2 ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Enabled ;
      private int idxLst ;
      private string AV32ApplicationClientId ;
      private string wcpOAV32ApplicationClientId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string edtavCmpname_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV18Language ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeaderoriginal_Internalname ;
      private string divTablelogin_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divTableloginerror_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavLogonto_Internalname ;
      private string imgavLogoappclient_Internalname ;
      private string edtavUsername_Internalname ;
      private string AV29UserPassword ;
      private string edtavUserpassword_Internalname ;
      private string chkavKeepmeloggedin_Internalname ;
      private string chkavRememberme_Internalname ;
      private string lblForgotpassword_Link ;
      private string lblForgotpassword_Internalname ;
      private string cellLogoappclient_cell_Class ;
      private string cellLogoappclient_cell_Internalname ;
      private string cellCmpname_cell_Class ;
      private string cellCmpname_cell_Internalname ;
      private string cellLogonto_cell_Class ;
      private string cellLogonto_cell_Internalname ;
      private string cellKeepmeloggedin_cell_Class ;
      private string cellKeepmeloggedin_cell_Internalname ;
      private string cellRememberme_cell_Class ;
      private string cellRememberme_cell_Internalname ;
      private string sStyleString ;
      private string tblUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtavCmpname_Jsonclick ;
      private string cmbavLogonto_Jsonclick ;
      private string divUnnamedtableusername_Internalname ;
      private string lblTextblockusername_Internalname ;
      private string lblTextblockusername_Jsonclick ;
      private string edtavUsername_Jsonclick ;
      private string divUnnamedtableuserpassword_Internalname ;
      private string lblTextblockuserpassword_Internalname ;
      private string lblTextblockuserpassword_Jsonclick ;
      private string edtavUserpassword_Jsonclick ;
      private string lblForgotpassword_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV17KeepMeLoggedIn ;
      private bool AV22RememberMe ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15isOK ;
      private bool AV19LoginOK ;
      private bool AV33hasError ;
      private bool AV26SessionValid ;
      private bool AV20LogoAppClient_IsBlob ;
      private string AV21LogOnTo ;
      private string AV34CmpName ;
      private string AV28UserName ;
      private string AV27URL ;
      private string AV41Logoappclient_GXI ;
      private string AV20LogoAppClient ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_ApplicationClientId ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV7AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV8ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11ErrorsLogin ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV6AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV9Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV31GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV23Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV25Session ;
   }

}
