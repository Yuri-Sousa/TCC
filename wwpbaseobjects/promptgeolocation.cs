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
   public class promptgeolocation : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public promptgeolocation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public promptgeolocation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref string aP0_Geolocation )
      {
         this.AV7Geolocation = aP0_Geolocation;
         executePrivate();
         aP0_Geolocation=this.AV7Geolocation;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Geolocation");
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
               gxfirstwebparm = GetFirstPar( "Geolocation");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Geolocation");
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
               AV7Geolocation = gxfirstwebparm;
               AssignAttri("", false, "AV7Geolocation", AV7Geolocation);
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
            return "promptgeolocation_Execute" ;
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
            PA0O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0O2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0O2( ) ;
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
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Selecione Geolocalização") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281551264", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("GXGoogleVisualizationLibrary/MAP/mapsproviders.js", "", false, true);
         context.AddJavascriptSource("GXGoogleVisualizationLibrary/MAP/Gxmap.js", "", false, true);
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"FormNoBackgroundColor\" data-gx-class=\"FormNoBackgroundColor\" novalidate action=\""+formatLink("wwpbaseobjects.promptgeolocation.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7Geolocation))}, new string[] {"Geolocation"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "FormNoBackgroundColor", true);
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGXMAPDATA", GxMapData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGXMAPDATA", GxMapData);
         }
         GxWebStd.gx_hidden_field( context, "vLATITUDE", AV10Latitude);
         GxWebStd.gx_hidden_field( context, "vLONGITUDE", AV11Longitude);
         GxWebStd.gx_hidden_field( context, "vGEOLOCATION", AV7Geolocation);
         GxWebStd.gx_hidden_field( context, "GOOGLEMAPCONTROL1_Provider", StringUtil.RTrim( Googlemapcontrol1_Provider));
         GxWebStd.gx_hidden_field( context, "GOOGLEMAPCONTROL1_Type", StringUtil.RTrim( Googlemapcontrol1_Type));
         GxWebStd.gx_hidden_field( context, "GOOGLEMAPCONTROL1_City", StringUtil.RTrim( Googlemapcontrol1_City));
         GxWebStd.gx_hidden_field( context, "GOOGLEMAPCONTROL1_Latitude", StringUtil.RTrim( Googlemapcontrol1_Latitude));
         GxWebStd.gx_hidden_field( context, "GOOGLEMAPCONTROL1_Longitude", StringUtil.RTrim( Googlemapcontrol1_Longitude));
         GxWebStd.gx_hidden_field( context, "GOOGLEMAPCONTROL1_Precision", StringUtil.LTrim( StringUtil.NToC( (decimal)(Googlemapcontrol1_Precision), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GOOGLEMAPCONTROL1_Onclick", StringUtil.RTrim( Googlemapcontrol1_Onclick));
      }

      protected void RenderHtmlCloseForm0O2( )
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
         return "WWPBaseObjects.PromptGeolocation" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selecione Geolocalização" ;
      }

      protected void WB0O0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            wb_table1_2_0O2( true) ;
         }
         else
         {
            wb_table1_2_0O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0O2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true;
      }

      protected void START0O2( )
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
            Form.Meta.addItem("description", "Selecione Geolocalização", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0O0( ) ;
      }

      protected void WS0O2( )
      {
         START0O2( ) ;
         EVT0O2( ) ;
      }

      protected void EVT0O2( )
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
                           E110O2 ();
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
                                 E120O2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E130O2 ();
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

      protected void WE0O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0O2( ) ;
            }
         }
      }

      protected void PA0O2( )
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130O2 ();
            WB0O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0O2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vGXMAPDATA"), GxMapData);
            /* Read saved values. */
            AV10Latitude = cgiGet( "vLATITUDE");
            AV11Longitude = cgiGet( "vLONGITUDE");
            Googlemapcontrol1_Provider = cgiGet( "GOOGLEMAPCONTROL1_Provider");
            Googlemapcontrol1_Type = cgiGet( "GOOGLEMAPCONTROL1_Type");
            Googlemapcontrol1_City = cgiGet( "GOOGLEMAPCONTROL1_City");
            Googlemapcontrol1_Latitude = cgiGet( "GOOGLEMAPCONTROL1_Latitude");
            Googlemapcontrol1_Longitude = cgiGet( "GOOGLEMAPCONTROL1_Longitude");
            Googlemapcontrol1_Precision = (int)(context.localUtil.CToN( cgiGet( "GOOGLEMAPCONTROL1_Precision"), ",", "."));
            Googlemapcontrol1_Onclick = cgiGet( "GOOGLEMAPCONTROL1_Onclick");
            /* Read variables values. */
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
         E110O2 ();
         if (returnInSub) return;
      }

      protected void E110O2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV12SplittedGeolocation = GxRegex.Split(AV7Geolocation,",");
         if ( AV12SplittedGeolocation.Count == 2 )
         {
            GxMapPoint.gxTpr_Pointlat = StringUtil.Trim( AV12SplittedGeolocation.GetString(1));
            GxMapPoint.gxTpr_Pointlong = StringUtil.Trim( AV12SplittedGeolocation.GetString(2));
            GxMapData.gxTpr_Points.Add(GxMapPoint, 0);
            Googlemapcontrol1_Latitude = StringUtil.Trim( AV12SplittedGeolocation.GetString(1));
            ucGooglemapcontrol1.SendProperty(context, "", false, Googlemapcontrol1_Internalname, "Latitude", Googlemapcontrol1_Latitude);
            Googlemapcontrol1_Longitude = StringUtil.Trim( AV12SplittedGeolocation.GetString(2));
            ucGooglemapcontrol1.SendProperty(context, "", false, Googlemapcontrol1_Internalname, "Longitude", Googlemapcontrol1_Longitude);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120O2 ();
         if (returnInSub) return;
      }

      protected void E120O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Latitude)) || ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV7Geolocation))) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Latitude)) )
            {
               AV7Geolocation = AV10Latitude + "," + AV11Longitude;
               AssignAttri("", false, "AV7Geolocation", AV7Geolocation);
            }
            context.setWebReturnParms(new Object[] {(string)AV7Geolocation});
            context.setWebReturnParmsMetadata(new Object[] {"AV7Geolocation"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E130O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_2_0O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(420), 10, 0) + "px" + ";";
            sStyleString += " width: " + StringUtil.LTrimStr( (decimal)(618), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableMain", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='PopupContentCell'>") ;
            wb_table2_8_0O2( true) ;
         }
         else
         {
            wb_table2_8_0O2( false) ;
         }
         return  ;
      }

      protected void wb_table2_8_0O2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divActiongroup_actions_Internalname, 1, 0, "px", 0, "px", "ActionGroupRight", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Selecione Geolocalização", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\PromptGeolocation.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\PromptGeolocation.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0O2e( true) ;
         }
         else
         {
            wb_table1_2_0O2e( false) ;
         }
      }

      protected void wb_table2_8_0O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUtgeolocation_Internalname, tblUtgeolocation_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr class='Table'>") ;
            context.WriteHtmlText( "<td class='Table'>") ;
            /* User Defined Control */
            ucGooglemapcontrol1.SetProperty("Title", Googlemapcontrol1_Title);
            ucGooglemapcontrol1.SetProperty("Provider", Googlemapcontrol1_Provider);
            ucGooglemapcontrol1.SetProperty("Type", Googlemapcontrol1_Type);
            ucGooglemapcontrol1.SetProperty("City", Googlemapcontrol1_City);
            ucGooglemapcontrol1.SetProperty("Latitude", Googlemapcontrol1_Latitude);
            ucGooglemapcontrol1.SetProperty("Longitude", Googlemapcontrol1_Longitude);
            ucGooglemapcontrol1.SetProperty("Precision", Googlemapcontrol1_Precision);
            ucGooglemapcontrol1.SetProperty("GxMap", GxMapData);
            ucGooglemapcontrol1.SetProperty("ClickLatitude", AV10Latitude);
            ucGooglemapcontrol1.SetProperty("ClickLongitude", AV11Longitude);
            ucGooglemapcontrol1.SetProperty("Onclick", Googlemapcontrol1_Onclick);
            ucGooglemapcontrol1.Render(context, "googlemapcontrol", Googlemapcontrol1_Internalname, "GOOGLEMAPCONTROL1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_8_0O2e( true) ;
         }
         else
         {
            wb_table2_8_0O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7Geolocation = (string)getParm(obj,0);
         AssignAttri("", false, "AV7Geolocation", AV7Geolocation);
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
         PA0O2( ) ;
         WS0O2( ) ;
         WE0O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281551299", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/promptgeolocation.js", "?20214281551299", false, true);
         context.AddJavascriptSource("GXGoogleVisualizationLibrary/MAP/mapsproviders.js", "", false, true);
         context.AddJavascriptSource("GXGoogleVisualizationLibrary/MAP/Gxmap.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Googlemapcontrol1_Internalname = "GOOGLEMAPCONTROL1";
         tblUtgeolocation_Internalname = "UTGEOLOCATION";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divActiongroup_actions_Internalname = "ACTIONGROUP_ACTIONS";
         tblTablemain_Internalname = "TABLEMAIN";
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
         Googlemapcontrol1_Title = "Map Title";
         Googlemapcontrol1_Onclick = "getvalue";
         Googlemapcontrol1_Precision = 15;
         Googlemapcontrol1_City = "";
         Googlemapcontrol1_Type = "G_NORMAL_MAP";
         Googlemapcontrol1_Provider = "GOOGLE";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E120O2',iparms:[{av:'AV10Latitude',fld:'vLATITUDE',pic:''},{av:'AV7Geolocation',fld:'vGEOLOCATION',pic:''},{av:'AV11Longitude',fld:'vLONGITUDE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV7Geolocation',fld:'vGEOLOCATION',pic:''}]}");
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
         wcpOAV7Geolocation = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GxMapData = new SdtGxMap(context);
         AV10Latitude = "";
         AV11Longitude = "";
         Googlemapcontrol1_Latitude = "";
         Googlemapcontrol1_Longitude = "";
         GX_FocusControl = "";
         sPrefix = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12SplittedGeolocation = new GxSimpleCollection<string>();
         GxMapPoint = new SdtGxMap_Point(context);
         ucGooglemapcontrol1 = new GXUserControl();
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Googlemapcontrol1_Precision ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Googlemapcontrol1_Provider ;
      private string Googlemapcontrol1_Type ;
      private string Googlemapcontrol1_City ;
      private string Googlemapcontrol1_Latitude ;
      private string Googlemapcontrol1_Longitude ;
      private string Googlemapcontrol1_Onclick ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string Googlemapcontrol1_Internalname ;
      private string sStyleString ;
      private string tblTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divActiongroup_actions_Internalname ;
      private string TempTags ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string tblUtgeolocation_Internalname ;
      private string Googlemapcontrol1_Title ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV7Geolocation ;
      private string wcpOAV7Geolocation ;
      private string AV10Latitude ;
      private string AV11Longitude ;
      private GXUserControl ucGooglemapcontrol1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Geolocation ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV12SplittedGeolocation ;
      private SdtGxMap GxMapData ;
      private SdtGxMap_Point GxMapPoint ;
   }

}
