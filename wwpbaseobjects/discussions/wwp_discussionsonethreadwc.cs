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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionsonethreadwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_discussionsonethreadwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
      }

      public wwp_discussionsonethreadwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_WWPDiscussionMessageThreadId ,
                           string aP1_WWPSubscriptionEntityRecordDescription ,
                           string aP2_WWPNotificationLink )
      {
         this.AV15WWPDiscussionMessageThreadId = aP0_WWPDiscussionMessageThreadId;
         this.AV21WWPSubscriptionEntityRecordDescription = aP1_WWPSubscriptionEntityRecordDescription;
         this.AV22WWPNotificationLink = aP2_WWPNotificationLink;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPDiscussionMessageThreadId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV15WWPDiscussionMessageThreadId = (long)(NumberUtil.Val( GetPar( "WWPDiscussionMessageThreadId"), "."));
                  AssignAttri(sPrefix, false, "AV15WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0));
                  AV21WWPSubscriptionEntityRecordDescription = GetPar( "WWPSubscriptionEntityRecordDescription");
                  AssignAttri(sPrefix, false, "AV21WWPSubscriptionEntityRecordDescription", AV21WWPSubscriptionEntityRecordDescription);
                  AV22WWPNotificationLink = GetPar( "WWPNotificationLink");
                  AssignAttri(sPrefix, false, "AV22WWPNotificationLink", AV22WWPNotificationLink);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV15WWPDiscussionMessageThreadId,(string)AV21WWPSubscriptionEntityRecordDescription,(string)AV22WWPNotificationLink});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WWPDiscussionMessageThreadId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPDiscussionMessageThreadId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_12 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."));
                  nGXsfl_12_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."));
                  sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
                  sPrefix = GetPar( "sPrefix");
                  edtWWPDiscussionMessageId_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtWWPDiscussionMessageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0), !bGXsfl_12_Refreshing);
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
                  AV15WWPDiscussionMessageThreadId = (long)(NumberUtil.Val( GetPar( "WWPDiscussionMessageThreadId"), "."));
                  AV35Pgmname = GetPar( "Pgmname");
                  edtWWPDiscussionMessageId_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtWWPDiscussionMessageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0), !bGXsfl_12_Refreshing);
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA292( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV35Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadWC";
               context.Gx_err = 0;
               WS292( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Discussions of one thread") ;
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
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20214281548569", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionsonethreadwc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15WWPDiscussionMessageThreadId,10,0)),UrlEncode(StringUtil.RTrim(AV21WWPSubscriptionEntityRecordDescription)),UrlEncode(StringUtil.RTrim(AV22WWPNotificationLink))}, new string[] {"WWPDiscussionMessageThreadId","WWPSubscriptionEntityRecordDescription","WWPNotificationLink"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV15WWPDiscussionMessageThreadId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21WWPSubscriptionEntityRecordDescription", wcpOAV21WWPSubscriptionEntityRecordDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV22WWPNotificationLink", wcpOAV22WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDPHOTO_GXI", A40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDISCUSSIONMESSAGETHREADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONLINK", AV22WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION", AV21WWPSubscriptionEntityRecordDescription);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICATIONINFO", AV24NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICATIONINFO", AV24NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDID", StringUtil.RTrim( A1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCMENTIONS_Gamoauthtoken", StringUtil.RTrim( Ucmentions_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCMENTIONS_Datalistproc", StringUtil.RTrim( Ucmentions_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCMENTIONS_Itemhtmltemplate", StringUtil.RTrim( Ucmentions_Itemhtmltemplate));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCMENTIONS_Selecteditemsjson", StringUtil.RTrim( Ucmentions_Selecteditemsjson));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTIFICATIONINFO_Message", AV24NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPDISCUSSIONMESSAGEID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"UCMENTIONS_Selecteditemsjson", StringUtil.RTrim( Ucmentions_Selecteditemsjson));
      }

      protected void RenderHtmlCloseForm292( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Discussions of one thread" ;
      }

      protected void WB290( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.discussions.wwp_discussionsonethreadwc.aspx");
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "DiscussionsThreadTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"12\">") ;
               sStyleString = "";
               if ( subGrid_Visible == 0 )
               {
                  sStyleString += "display:none;";
               }
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetIsFreestyle(true);
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
               GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A83WWPDiscussionMessageId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV13UserExtendedPhoto));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A2WWPUserExtendedFullName);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A88WWPDiscussionMessageMessage);
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               if ( subGrid_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMessage_Internalname, "Message", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMessage_Internalname, AV16Message, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtavMessage_Enabled, 0, 80, "chr", 5, "row", StyleString, ClassString, "", "", "400", -1, 0, "", "Type a message...", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionsOneThreadWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "align-self:flex-end;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnter_Internalname, "<i class=\"fas fa-paper-plane DiscussionsSendIcon\"></i>", "", "", lblEnter_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", "", "TextBlock", 5, "Confirmar", 1, 1, 0, 1, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionsOneThreadWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUcmentions.SetProperty("DataListProc", Ucmentions_Datalistproc);
            ucUcmentions.Render(context, "wwp.suggest", Ucmentions_Internalname, sPrefix+"UCMENTIONSContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageThreadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0, ",", "")), context.localUtil.Format( (decimal)(A84WWPDiscussionMessageThreadId), "ZZZZZZZZZ9"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageThreadId_Jsonclick, 0, "Attribute", "", "", "", "", edtWWPDiscussionMessageThreadId_Visible, 0, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "WWPBaseObjects\\WWP_Id", "right", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionsOneThreadWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  if ( subGrid_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START292( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148565", 0) ;
               }
               Form.Meta.addItem("description", "Discussions of one thread", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP290( ) ;
            }
         }
      }

      protected void WS292( )
      {
         START292( ) ;
         EVT292( ) ;
      }

      protected void EVT292( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E11292 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavMessage_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E12292 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              nGXsfl_12_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A83WWPDiscussionMessageId = (long)(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), ",", "."));
                              AV13UserExtendedPhoto = cgiGet( edtavUserextendedphoto_Internalname);
                              AssignProp(sPrefix, false, edtavUserextendedphoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV13UserExtendedPhoto)) ? AV34Userextendedphoto_GXI : context.convertURL( context.PathToRelativeUrl( AV13UserExtendedPhoto))), !bGXsfl_12_Refreshing);
                              AssignProp(sPrefix, false, edtavUserextendedphoto_Internalname, "SrcSet", context.GetImageSrcSet( AV13UserExtendedPhoto), true);
                              A2WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
                              A87WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname), 0);
                              A88WWPDiscussionMessageMessage = cgiGet( edtWWPDiscussionMessageMessage_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E13292 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E14292 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E15292 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Onmessage_gx1 */
                                          E12292 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP290( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavMessage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Onmessage_gx1 */
                                          E12292 ();
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE292( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm292( ) ;
            }
         }
      }

      protected void PA292( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavMessage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       long AV15WWPDiscussionMessageThreadId ,
                                       string AV35Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E14292 ();
         GRID_nCurrentRecord = 0;
         RF292( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         RF292( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV35Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadWC";
         context.Gx_err = 0;
      }

      protected void RF292( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E14292 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H00292 */
            pr_default.execute(0, new Object[] {AV15WWPDiscussionMessageThreadId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A40000WWPUserExtendedPhoto_GXI = H00292_A40000WWPUserExtendedPhoto_GXI[0];
               A84WWPDiscussionMessageThreadId = H00292_A84WWPDiscussionMessageThreadId[0];
               n84WWPDiscussionMessageThreadId = H00292_n84WWPDiscussionMessageThreadId[0];
               AssignAttri(sPrefix, false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
               A88WWPDiscussionMessageMessage = H00292_A88WWPDiscussionMessageMessage[0];
               A87WWPDiscussionMessageDate = H00292_A87WWPDiscussionMessageDate[0];
               A83WWPDiscussionMessageId = H00292_A83WWPDiscussionMessageId[0];
               A1WWPUserExtendedId = H00292_A1WWPUserExtendedId[0];
               A40000WWPUserExtendedPhoto_GXI = H00292_A40000WWPUserExtendedPhoto_GXI[0];
               GXt_char1 = A2WWPUserExtendedFullName;
               new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
               A2WWPUserExtendedFullName = GXt_char1;
               E15292 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB290( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes292( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35Pgmname, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         /* Using cursor H00293 */
         pr_default.execute(1, new Object[] {AV15WWPDiscussionMessageThreadId});
         GRID_nRecordCount = H00293_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV35Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadWC";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP290( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13292 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNOTIFICATIONINFO"), AV24NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."));
            wcpOAV15WWPDiscussionMessageThreadId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15WWPDiscussionMessageThreadId"), ",", "."));
            wcpOAV21WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"wcpOAV21WWPSubscriptionEntityRecordDescription");
            wcpOAV22WWPNotificationLink = cgiGet( sPrefix+"wcpOAV22WWPNotificationLink");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ucmentions_Gamoauthtoken = cgiGet( sPrefix+"UCMENTIONS_Gamoauthtoken");
            Ucmentions_Datalistproc = cgiGet( sPrefix+"UCMENTIONS_Datalistproc");
            Ucmentions_Itemhtmltemplate = cgiGet( sPrefix+"UCMENTIONS_Itemhtmltemplate");
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ucmentions_Selecteditemsjson = cgiGet( sPrefix+"UCMENTIONS_Selecteditemsjson");
            /* Read variables values. */
            AV16Message = cgiGet( edtavMessage_Internalname);
            AssignAttri(sPrefix, false, "AV16Message", AV16Message);
            A84WWPDiscussionMessageThreadId = (long)(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), ",", "."));
            n84WWPDiscussionMessageThreadId = false;
            AssignAttri(sPrefix, false, "A84WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A84WWPDiscussionMessageThreadId), 10, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13292 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13292( )
      {
         /* Start Routine */
         returnInSub = false;
         AV31GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV30GAMErrors);
         Ucmentions_Gamoauthtoken = AV31GAMSession.gxTpr_Token;
         ucUcmentions.SendProperty(context, sPrefix, false, Ucmentions_Internalname, "GAMOAuthToken", Ucmentions_Gamoauthtoken);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title, subtitle and image", out  GXt_char1) ;
         Ucmentions_Itemhtmltemplate = GXt_char1;
         ucUcmentions.SendProperty(context, sPrefix, false, Ucmentions_Internalname, "ItemHtmlTemplate", Ucmentions_Itemhtmltemplate);
         this.executeUsercontrolMethod(sPrefix, false, "UCMENTIONSContainer", "Attach", "", new Object[] {(string)"+",(string)edtavMessage_Internalname});
         edtWWPDiscussionMessageId_Visible = 0;
         AssignProp(sPrefix, false, edtWWPDiscussionMessageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Visible), 5, 0), !bGXsfl_12_Refreshing);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         edtWWPDiscussionMessageThreadId_Visible = 0;
         AssignProp(sPrefix, false, edtWWPDiscussionMessageThreadId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageThreadId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GX_FocusControl = edtavMessage_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
         subGrid_Visible = 0;
         AssignProp(sPrefix, false, sPrefix+"GridContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGrid_Visible), 5, 0), true);
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "Textarea_EnterBehaviourToAction", new Object[] {(string)edtavMessage_Internalname,(string)lblEnter_Internalname}, false);
      }

      protected void E14292( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E15292( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         subGrid_Visible = 1;
         AssignProp(sPrefix, false, sPrefix+"GridContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGrid_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(A40000WWPUserExtendedPhoto_GXI, "") == 0 )
         {
            AV13UserExtendedPhoto = context.GetImagePath( "cd361e0f-97cb-4b25-a56f-891cd75b163f", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavUserextendedphoto_Internalname, AV13UserExtendedPhoto);
            AV34Userextendedphoto_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cd361e0f-97cb-4b25-a56f-891cd75b163f", "", context.GetTheme( )));
         }
         else
         {
            AV34Userextendedphoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            AV13UserExtendedPhoto = "";
            AssignAttri(sPrefix, false, edtavUserextendedphoto_Internalname, AV13UserExtendedPhoto);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            context.DoAjaxLoad(12, GridRow);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E11292 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11292( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV20WWPDiscussionMessageThread.Load(AV15WWPDiscussionMessageThreadId);
         if ( AV20WWPDiscussionMessageThread.Success() )
         {
            if ( new GeneXus.Programs.wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage(context).executeUdp(  AV20WWPDiscussionMessageThread.gxTpr_Wwpentityid,  AV15WWPDiscussionMessageThreadId,  AV20WWPDiscussionMessageThread.gxTpr_Wwpdiscussionmessageentityrecordid,  AV16Message,  Ucmentions_Selecteditemsjson,  StringUtil.Str( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0),  "Nova mensagem de discussão",  AV21WWPSubscriptionEntityRecordDescription,  AV22WWPNotificationLink) )
            {
               AV16Message = "";
               AssignAttri(sPrefix, false, "AV16Message", AV16Message);
               gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
               GX_FocusControl = edtavMessage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               context.DoAjaxSetFocus(GX_FocusControl);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV35Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV35Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         else
         {
            AV11GridState.FromXml(AV14Session.Get(AV35Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV14Session.Get(AV35Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV35Pgmname+"GridState",  AV11GridState.ToXml(false, true, "WWPGridState", "RastreamentoTCC")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV35Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Discussions.WWP_DiscussionMessage";
         AV10TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "WWPDiscussionMessageThreadId";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "WWPTransactionContext", "RastreamentoTCC"));
      }

      protected void E12292( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StartsWith( AV24NotificationInfo.gxTpr_Id, "WebNotification#") )
         {
            AV25WebNotification.FromJSonString(AV24NotificationInfo.gxTpr_Message, null);
            if ( StringUtil.StartsWith( AV25WebNotification.gxTpr_Wwpnotificationdefinitionname, "Discussion") )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25WebNotification.gxTpr_Wwpnotificationmetadata)) )
               {
                  AV23WWPNotificationMetadataSDT.FromJSonString(AV25WebNotification.gxTpr_Wwpnotificationmetadata, null);
                  if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Str( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0)), StringUtil.Trim( AV23WWPNotificationMetadataSDT.gxTpr_Sessionvalue)) == 0 )
                  {
                     GXt_int2 = AV25WebNotification.gxTpr_Wwpnotificationid;
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadbyid( ref  GXt_int2) ;
                     AV25WebNotification.gxTpr_Wwpnotificationid = GXt_int2;
                     this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
                  }
               }
               gxgrGrid_refresh( subGrid_Rows, AV15WWPDiscussionMessageThreadId, AV35Pgmname, sPrefix) ;
            }
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15WWPDiscussionMessageThreadId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV15WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0));
         AV21WWPSubscriptionEntityRecordDescription = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV21WWPSubscriptionEntityRecordDescription", AV21WWPSubscriptionEntityRecordDescription);
         AV22WWPNotificationLink = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV22WWPNotificationLink", AV22WWPNotificationLink);
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
         PA292( ) ;
         WS292( ) ;
         WE292( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV15WWPDiscussionMessageThreadId = (string)((string)getParm(obj,0));
         sCtrlAV21WWPSubscriptionEntityRecordDescription = (string)((string)getParm(obj,1));
         sCtrlAV22WWPNotificationLink = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA292( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\discussions\\wwp_discussionsonethreadwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA292( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV15WWPDiscussionMessageThreadId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV15WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0));
            AV21WWPSubscriptionEntityRecordDescription = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV21WWPSubscriptionEntityRecordDescription", AV21WWPSubscriptionEntityRecordDescription);
            AV22WWPNotificationLink = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV22WWPNotificationLink", AV22WWPNotificationLink);
         }
         wcpOAV15WWPDiscussionMessageThreadId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15WWPDiscussionMessageThreadId"), ",", "."));
         wcpOAV21WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"wcpOAV21WWPSubscriptionEntityRecordDescription");
         wcpOAV22WWPNotificationLink = cgiGet( sPrefix+"wcpOAV22WWPNotificationLink");
         if ( ! GetJustCreated( ) && ( ( AV15WWPDiscussionMessageThreadId != wcpOAV15WWPDiscussionMessageThreadId ) || ( StringUtil.StrCmp(AV21WWPSubscriptionEntityRecordDescription, wcpOAV21WWPSubscriptionEntityRecordDescription) != 0 ) || ( StringUtil.StrCmp(AV22WWPNotificationLink, wcpOAV22WWPNotificationLink) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV15WWPDiscussionMessageThreadId = AV15WWPDiscussionMessageThreadId;
         wcpOAV21WWPSubscriptionEntityRecordDescription = AV21WWPSubscriptionEntityRecordDescription;
         wcpOAV22WWPNotificationLink = AV22WWPNotificationLink;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV15WWPDiscussionMessageThreadId = cgiGet( sPrefix+"AV15WWPDiscussionMessageThreadId_CTRL");
         if ( StringUtil.Len( sCtrlAV15WWPDiscussionMessageThreadId) > 0 )
         {
            AV15WWPDiscussionMessageThreadId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV15WWPDiscussionMessageThreadId), ",", "."));
            AssignAttri(sPrefix, false, "AV15WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0));
         }
         else
         {
            AV15WWPDiscussionMessageThreadId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV15WWPDiscussionMessageThreadId_PARM"), ",", "."));
         }
         sCtrlAV21WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"AV21WWPSubscriptionEntityRecordDescription_CTRL");
         if ( StringUtil.Len( sCtrlAV21WWPSubscriptionEntityRecordDescription) > 0 )
         {
            AV21WWPSubscriptionEntityRecordDescription = cgiGet( sCtrlAV21WWPSubscriptionEntityRecordDescription);
            AssignAttri(sPrefix, false, "AV21WWPSubscriptionEntityRecordDescription", AV21WWPSubscriptionEntityRecordDescription);
         }
         else
         {
            AV21WWPSubscriptionEntityRecordDescription = cgiGet( sPrefix+"AV21WWPSubscriptionEntityRecordDescription_PARM");
         }
         sCtrlAV22WWPNotificationLink = cgiGet( sPrefix+"AV22WWPNotificationLink_CTRL");
         if ( StringUtil.Len( sCtrlAV22WWPNotificationLink) > 0 )
         {
            AV22WWPNotificationLink = cgiGet( sCtrlAV22WWPNotificationLink);
            AssignAttri(sPrefix, false, "AV22WWPNotificationLink", AV22WWPNotificationLink);
         }
         else
         {
            AV22WWPNotificationLink = cgiGet( sPrefix+"AV22WWPNotificationLink_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA292( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS292( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS292( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15WWPDiscussionMessageThreadId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15WWPDiscussionMessageThreadId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15WWPDiscussionMessageThreadId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15WWPDiscussionMessageThreadId_CTRL", StringUtil.RTrim( sCtrlAV15WWPDiscussionMessageThreadId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21WWPSubscriptionEntityRecordDescription_PARM", AV21WWPSubscriptionEntityRecordDescription);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21WWPSubscriptionEntityRecordDescription)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21WWPSubscriptionEntityRecordDescription_CTRL", StringUtil.RTrim( sCtrlAV21WWPSubscriptionEntityRecordDescription));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22WWPNotificationLink_PARM", AV22WWPNotificationLink);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22WWPNotificationLink)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22WWPNotificationLink_CTRL", StringUtil.RTrim( sCtrlAV22WWPNotificationLink));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE292( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281549331", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionsonethreadwc.js", "?20214281549336", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtWWPDiscussionMessageId_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEID_"+sGXsfl_12_idx;
         edtavUserextendedphoto_Internalname = sPrefix+"vUSEREXTENDEDPHOTO_"+sGXsfl_12_idx;
         edtWWPUserExtendedFullName_Internalname = sPrefix+"WWPUSEREXTENDEDFULLNAME_"+sGXsfl_12_idx;
         edtWWPDiscussionMessageDate_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEDATE_"+sGXsfl_12_idx;
         edtWWPDiscussionMessageMessage_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEMESSAGE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtWWPDiscussionMessageId_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEID_"+sGXsfl_12_fel_idx;
         edtavUserextendedphoto_Internalname = sPrefix+"vUSEREXTENDEDPHOTO_"+sGXsfl_12_fel_idx;
         edtWWPUserExtendedFullName_Internalname = sPrefix+"WWPUSEREXTENDEDFULLNAME_"+sGXsfl_12_fel_idx;
         edtWWPDiscussionMessageDate_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEDATE_"+sGXsfl_12_fel_idx;
         edtWWPDiscussionMessageMessage_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEMESSAGE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB290( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_12_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageId_Internalname,(string)"Message Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A83WWPDiscussionMessageId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A83WWPDiscussionMessageId), "ZZZZZZZZZ9"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPDiscussionMessageId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPDiscussionMessageId_Visible,(short)0,(short)0,(string)"number",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"right",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellPaddingTop5",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"User Extended Photo",(string)"gx-form-item AttributeDiscussionThreadImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Static Bitmap Variable */
            ClassString = "AttributeDiscussionThreadImage";
            StyleString = "";
            AV13UserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV13UserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( AV34Userextendedphoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV13UserExtendedPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV13UserExtendedPhoto)) ? AV34Userextendedphoto_GXI : context.PathToRelativeUrl( AV13UserExtendedPhoto));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUserextendedphoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV13UserExtendedPhoto_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTabletitle_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablemergedwwpuserextendedfullname_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"TableMerged",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(short)0,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"MergeDataCell"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedFullName_Internalname,(string)"User Full Name",(string)"gx-form-item SimpleCardAttributeTitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "SimpleCardAttributeTitle";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedFullName_Internalname,(string)A2WWPUserExtendedFullName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPUserExtendedFullName_Jsonclick,(short)0,(string)"SimpleCardAttributeTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)-1,(bool)true,(string)"WWPBaseObjects\\WWP_Description",(string)"left",(bool)true,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageDate_Internalname,(string)"Message Date",(string)"gx-form-item AttributeDiscussionDateLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "AttributeDiscussionDate";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageDate_Internalname,context.localUtil.TToC( A87WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A87WWPDiscussionMessageDate, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPDiscussionMessageDate_Jsonclick,(short)0,(string)"AttributeDiscussionDate",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)14,(string)"chr",(short)1,(string)"row",(short)14,(short)0,(short)0,(short)12,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginBottom15",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageMessage_Internalname,(string)"Message",(string)"col-sm-3 AttributeDiscussionDescriptionLabel",(short)0,(bool)true,(string)""});
            /* Multiple line edit */
            ClassString = "AttributeDiscussionDescription";
            StyleString = "";
            ClassString = "AttributeDiscussionDescription";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPDiscussionMessageMessage_Internalname,(string)A88WWPDiscussionMessageMessage,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)5,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"400",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            send_integrity_lvl_hashes292( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtWWPDiscussionMessageId_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEID";
         tblUnnamedtablecontentfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRID";
         edtavUserextendedphoto_Internalname = sPrefix+"vUSEREXTENDEDPHOTO";
         edtWWPUserExtendedFullName_Internalname = sPrefix+"WWPUSEREXTENDEDFULLNAME";
         edtWWPDiscussionMessageDate_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEDATE";
         tblTablemergedwwpuserextendedfullname_Internalname = sPrefix+"TABLEMERGEDWWPUSEREXTENDEDFULLNAME";
         edtWWPDiscussionMessageMessage_Internalname = sPrefix+"WWPDISCUSSIONMESSAGEMESSAGE";
         divTabletitle_Internalname = sPrefix+"TABLETITLE";
         divUnnamedtablefsgrid_Internalname = sPrefix+"UNNAMEDTABLEFSGRID";
         edtavMessage_Internalname = sPrefix+"vMESSAGE";
         lblEnter_Internalname = sPrefix+"ENTER";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Ucmentions_Internalname = sPrefix+"UCMENTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtWWPDiscussionMessageThreadId_Internalname = sPrefix+"WWPDISCUSSIONMESSAGETHREADID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPDiscussionMessageId_Jsonclick = "";
         subGrid_Class = "FreeStyleGrid";
         edtWWPDiscussionMessageThreadId_Jsonclick = "";
         edtWWPDiscussionMessageThreadId_Visible = 1;
         edtavMessage_Enabled = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Backcolorstyle = 0;
         subGrid_Visible = 1;
         Ucmentions_Itemhtmltemplate = "";
         Ucmentions_Datalistproc = "WWPBaseObjects.Discussions.WWP_GetUsersForDiscussionMentions";
         subGrid_Rows = 0;
         edtWWPDiscussionMessageId_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E15292',iparms:[{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV13UserExtendedPhoto',fld:'vUSEREXTENDEDPHOTO',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E11292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV22WWPNotificationLink',fld:'vWWPNOTIFICATIONLINK',pic:''},{av:'AV21WWPSubscriptionEntityRecordDescription',fld:'vWWPSUBSCRIPTIONENTITYRECORDDESCRIPTION',pic:''},{av:'Ucmentions_Selecteditemsjson',ctrl:'UCMENTIONS',prop:'SelectedItemsJson'},{av:'AV16Message',fld:'vMESSAGE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV16Message',fld:'vMESSAGE',pic:''}]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E12292',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV24NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV15WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'edtWWPDiscussionMessageId_Visible',ctrl:'WWPDISCUSSIONMESSAGEID',prop:'Visible'},{av:'sPrefix'},{av:'AV35Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpdiscussionmessagemessage',iparms:[]");
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
      }

      public override void initialize( )
      {
         wcpOAV21WWPSubscriptionEntityRecordDescription = "";
         wcpOAV22WWPNotificationLink = "";
         Ucmentions_Selecteditemsjson = "";
         AV24NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV35Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A1WWPUserExtendedId = "";
         Ucmentions_Gamoauthtoken = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         AV13UserExtendedPhoto = "";
         A2WWPUserExtendedFullName = "";
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A88WWPDiscussionMessageMessage = "";
         TempTags = "";
         AV16Message = "";
         lblEnter_Jsonclick = "";
         ucUcmentions = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV34Userextendedphoto_GXI = "";
         scmdbuf = "";
         H00292_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         H00292_A84WWPDiscussionMessageThreadId = new long[1] ;
         H00292_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         H00292_A88WWPDiscussionMessageMessage = new string[] {""} ;
         H00292_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         H00292_A83WWPDiscussionMessageId = new long[1] ;
         H00292_A1WWPUserExtendedId = new string[] {""} ;
         H00293_AGRID_nRecordCount = new long[1] ;
         AV31GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV30GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_char1 = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV20WWPDiscussionMessageThread = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
         AV14Session = context.GetSession();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV10TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV25WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV23WWPNotificationMetadataSDT = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV15WWPDiscussionMessageThreadId = "";
         sCtrlAV21WWPSubscriptionEntityRecordDescription = "";
         sCtrlAV22WWPNotificationLink = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionsonethreadwc__default(),
            new Object[][] {
                new Object[] {
               H00292_A40000WWPUserExtendedPhoto_GXI, H00292_A84WWPDiscussionMessageThreadId, H00292_n84WWPDiscussionMessageThreadId, H00292_A88WWPDiscussionMessageMessage, H00292_A87WWPDiscussionMessageDate, H00292_A83WWPDiscussionMessageId, H00292_A1WWPUserExtendedId
               }
               , new Object[] {
               H00293_AGRID_nRecordCount
               }
            }
         );
         AV35Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadWC";
         /* GeneXus formulas. */
         AV35Pgmname = "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadWC";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int edtWWPDiscussionMessageId_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int subGrid_Visible ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int edtavMessage_Enabled ;
      private int edtWWPDiscussionMessageThreadId_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private long AV15WWPDiscussionMessageThreadId ;
      private long wcpOAV15WWPDiscussionMessageThreadId ;
      private long GRID_nFirstRecordOnPage ;
      private long A83WWPDiscussionMessageId ;
      private long A84WWPDiscussionMessageThreadId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long GXt_int2 ;
      private string Ucmentions_Selecteditemsjson ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtWWPDiscussionMessageId_Internalname ;
      private string AV35Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A1WWPUserExtendedId ;
      private string Ucmentions_Gamoauthtoken ;
      private string Ucmentions_Datalistproc ;
      private string Ucmentions_Itemhtmltemplate ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Header ;
      private string divUnnamedtable1_Internalname ;
      private string edtavMessage_Internalname ;
      private string TempTags ;
      private string lblEnter_Internalname ;
      private string lblEnter_Jsonclick ;
      private string Ucmentions_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtWWPDiscussionMessageThreadId_Internalname ;
      private string edtWWPDiscussionMessageThreadId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavUserextendedphoto_Internalname ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPDiscussionMessageDate_Internalname ;
      private string edtWWPDiscussionMessageMessage_Internalname ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private string sCtrlAV15WWPDiscussionMessageThreadId ;
      private string sCtrlAV21WWPSubscriptionEntityRecordDescription ;
      private string sCtrlAV22WWPNotificationLink ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string ROClassString ;
      private string edtWWPDiscussionMessageId_Jsonclick ;
      private string sImgUrl ;
      private string divTabletitle_Internalname ;
      private string tblTablemergedwwpuserextendedfullname_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPDiscussionMessageDate_Jsonclick ;
      private DateTime A87WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n84WWPDiscussionMessageThreadId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV13UserExtendedPhoto_IsBlob ;
      private string AV21WWPSubscriptionEntityRecordDescription ;
      private string AV22WWPNotificationLink ;
      private string wcpOAV21WWPSubscriptionEntityRecordDescription ;
      private string wcpOAV22WWPNotificationLink ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A2WWPUserExtendedFullName ;
      private string A88WWPDiscussionMessageMessage ;
      private string AV16Message ;
      private string AV34Userextendedphoto_GXI ;
      private string AV13UserExtendedPhoto ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucUcmentions ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00292_A40000WWPUserExtendedPhoto_GXI ;
      private long[] H00292_A84WWPDiscussionMessageThreadId ;
      private bool[] H00292_n84WWPDiscussionMessageThreadId ;
      private string[] H00292_A88WWPDiscussionMessageMessage ;
      private DateTime[] H00292_A87WWPDiscussionMessageDate ;
      private long[] H00292_A83WWPDiscussionMessageId ;
      private string[] H00292_A1WWPUserExtendedId ;
      private long[] H00293_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV30GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV10TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage AV20WWPDiscussionMessageThread ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata AV23WWPNotificationMetadataSDT ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV24NotificationInfo ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV25WebNotification ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV31GAMSession ;
   }

   public class wwp_discussionsonethreadwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00292;
          prmH00292 = new Object[] {
          new Object[] {"@AV15WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          };
          Object[] prmH00293;
          prmH00293 = new Object[] {
          new Object[] {"@AV15WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0}
          };
          def= new CursorDef[] {
              new CursorDef("H00292", "SELECT T2.[WWPUserExtendedPhoto_GXI], T1.[WWPDiscussionMessageThreadId], T1.[WWPDiscussionMessageMessage], T1.[WWPDiscussionMessageDate], T1.[WWPDiscussionMessageId], T1.[WWPUserExtendedId] FROM ([WWP_DiscussionMessage] T1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = T1.[WWPUserExtendedId]) WHERE T1.[WWPDiscussionMessageThreadId] = @AV15WWPDiscussionMessageThreadId ORDER BY T1.[WWPDiscussionMessageId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00292,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00293", "SELECT COUNT(*) FROM ([WWP_DiscussionMessage] T1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = T1.[WWPUserExtendedId]) WHERE T1.[WWPDiscussionMessageThreadId] = @AV15WWPDiscussionMessageThreadId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00293,1, GxCacheFrequency.OFF ,true,false )
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
                table[0][0] = rslt.getMultimediaUri(1);
                table[1][0] = rslt.getLong(2);
                table[2][0] = rslt.wasNull(2);
                table[3][0] = rslt.getVarchar(3);
                table[4][0] = rslt.getGXDateTime(4);
                table[5][0] = rslt.getLong(5);
                table[6][0] = rslt.getString(6, 40);
                return;
             case 1 :
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
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
       }
    }

 }

}
