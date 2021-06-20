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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscriptionssettingsbyrolewc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_subscriptionssettingsbyrolewc( )
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

      public wwp_subscriptionssettingsbyrolewc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_WWPEntityId ,
                           bool aP1_NotifShowOnlySubscribedEvents ,
                           string aP2_WWPSubscriptionRoleId )
      {
         this.AV13WWPEntityId = aP0_WWPEntityId;
         this.AV10NotifShowOnlySubscribedEvents = aP1_NotifShowOnlySubscribedEvents;
         this.AV16WWPSubscriptionRoleId = aP2_WWPSubscriptionRoleId;
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
         chkavIncludenotification = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPEntityId");
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
                  AV13WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
                  AssignAttri(sPrefix, false, "AV13WWPEntityId", StringUtil.LTrimStr( (decimal)(AV13WWPEntityId), 10, 0));
                  AV10NotifShowOnlySubscribedEvents = StringUtil.StrToBool( GetPar( "NotifShowOnlySubscribedEvents"));
                  AssignAttri(sPrefix, false, "AV10NotifShowOnlySubscribedEvents", AV10NotifShowOnlySubscribedEvents);
                  AV16WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
                  AssignAttri(sPrefix, false, "AV16WWPSubscriptionRoleId", AV16WWPSubscriptionRoleId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV13WWPEntityId,(bool)AV10NotifShowOnlySubscribedEvents,(string)AV16WWPSubscriptionRoleId});
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
                  gxfirstwebparm = GetFirstPar( "WWPEntityId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPEntityId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_9 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."));
                  nGXsfl_9_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."));
                  sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
                  sPrefix = GetPar( "sPrefix");
                  edtavWwpnotificationdefinitionid_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  edtavWwpsubscriptionid_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
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
                  AV28Pgmname = GetPar( "Pgmname");
                  edtavWwpnotificationdefinitionid_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  edtavWwpsubscriptionid_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  A10WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
                  AV13WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
                  A26WWPNotificationDefinitionAppliesTo = (short)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionAppliesTo"), "."));
                  A14WWPNotificationDefinitionId = (long)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."));
                  A25WWPNotificationDefinitionDescription = GetPar( "WWPNotificationDefinitionDescription");
                  A11WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
                  n11WWPSubscriptionRoleId = false;
                  AV16WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
                  A13WWPSubscriptionId = (long)(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."));
                  AV10NotifShowOnlySubscribedEvents = StringUtil.StrToBool( GetPar( "NotifShowOnlySubscribedEvents"));
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A10WWPEntityId, AV13WWPEntityId, A26WWPNotificationDefinitionAppliesTo, A14WWPNotificationDefinitionId, A25WWPNotificationDefinitionDescription, A11WWPSubscriptionRoleId, AV16WWPSubscriptionRoleId, A13WWPSubscriptionId, AV10NotifShowOnlySubscribedEvents, sPrefix) ;
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
            PA232( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsByRoleWC";
               context.Gx_err = 0;
               edtavWwpnotificationdescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavWwpnotificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdescription_Enabled), 5, 0), !bGXsfl_9_Refreshing);
               WS232( ) ;
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
            context.SendWebValue( "Subscriptions Settings by Role") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281548363", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettingsbyrolewc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13WWPEntityId,10,0)),UrlEncode(StringUtil.BoolToStr(AV10NotifShowOnlySubscribedEvents)),UrlEncode(StringUtil.RTrim(AV16WWPSubscriptionRoleId))}, new string[] {"WWPEntityId","NotifShowOnlySubscribedEvents","WWPSubscriptionRoleId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV13WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV13WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV10NotifShowOnlySubscribedEvents", wcpOAV10NotifShowOnlySubscribedEvents);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16WWPSubscriptionRoleId", StringUtil.RTrim( wcpOAV16WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONAPPLIESTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26WWPNotificationDefinitionAppliesTo), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONDESCRIPTION", A25WWPNotificationDefinitionDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONROLEID", StringUtil.RTrim( A11WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONROLEID", StringUtil.RTrim( AV16WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13WWPSubscriptionId), 10, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vNOTIFSHOWONLYSUBSCRIBEDEVENTS", AV10NotifShowOnlySubscribedEvents);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm232( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsByRoleWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Subscriptions Settings by Role" ;
      }

      protected void WB230( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.subscriptions.wwp_subscriptionssettingsbyrolewc.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SubscriptionsPanelCell", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"9\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
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
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV9IncludeNotification));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", AV14WWPNotificationDescription);
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationdescription_Enabled), 5, 0, ".", "")));
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPNotificationDefinitionId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6WWPSubscriptionId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 9 )
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
                  sStyleString = "";
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

      protected void START232( )
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
               Form.Meta.addItem("description", "Subscriptions Settings by Role", 0) ;
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
               STRUP230( ) ;
            }
         }
      }

      protected void WS232( )
      {
         START232( ) ;
         EVT232( ) ;
      }

      protected void EVT232( )
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
                                 STRUP230( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP230( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11232 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP230( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavIncludenotification_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'FIRSTPAGE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'PREVIOUSPAGE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'NEXTPAGE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'LASTPAGE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "TABLESUBSCRIPTIONITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP230( ) ;
                              }
                              nGXsfl_9_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV9IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
                              AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV9IncludeNotification);
                              AV14WWPNotificationDescription = cgiGet( edtavWwpnotificationdescription_Internalname);
                              AssignAttri(sPrefix, false, edtavWwpnotificationdescription_Internalname, AV14WWPNotificationDescription);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPNOTIFICATIONDEFINITIONID");
                                 GX_FocusControl = edtavWwpnotificationdefinitionid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV5WWPNotificationDefinitionId = 0;
                                 AssignAttri(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, StringUtil.LTrimStr( (decimal)(AV5WWPNotificationDefinitionId), 10, 0));
                              }
                              else
                              {
                                 AV5WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), ",", "."));
                                 AssignAttri(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, StringUtil.LTrimStr( (decimal)(AV5WWPNotificationDefinitionId), 10, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                                 GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV6WWPSubscriptionId = 0;
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV6WWPSubscriptionId), 10, 0));
                              }
                              else
                              {
                                 AV6WWPSubscriptionId = (long)(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", "."));
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV6WWPSubscriptionId), 10, 0));
                              }
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E12232 ();
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E13232 ();
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
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E14232 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'FIRSTPAGE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'FirstPage' */
                                          E15232 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'PREVIOUSPAGE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'PreviousPage' */
                                          E16232 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'NEXTPAGE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'NextPage' */
                                          E17232 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'LASTPAGE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'LastPage' */
                                          E18232 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E11232 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP230( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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

      protected void WE232( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm232( ) ;
            }
         }
      }

      protected void PA232( )
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
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV28Pgmname ,
                                       long A10WWPEntityId ,
                                       long AV13WWPEntityId ,
                                       short A26WWPNotificationDefinitionAppliesTo ,
                                       long A14WWPNotificationDefinitionId ,
                                       string A25WWPNotificationDefinitionDescription ,
                                       string A11WWPSubscriptionRoleId ,
                                       string AV16WWPSubscriptionRoleId ,
                                       long A13WWPSubscriptionId ,
                                       bool AV10NotifShowOnlySubscribedEvents ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E13232 ();
         GRID_nCurrentRecord = 0;
         RF232( ) ;
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
         RF232( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsByRoleWC";
         context.Gx_err = 0;
         edtavWwpnotificationdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavWwpnotificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdescription_Enabled), 5, 0), !bGXsfl_9_Refreshing);
      }

      protected void RF232( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E13232 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            E14232 ();
            wbEnd = 9;
            WB230( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes232( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
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
         return (int)(((subGrid_Islastpage==1) ? subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( ))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : (decimal)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1))) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A10WWPEntityId, AV13WWPEntityId, A26WWPNotificationDefinitionAppliesTo, A14WWPNotificationDefinitionId, A25WWPNotificationDefinitionDescription, A11WWPSubscriptionRoleId, AV16WWPSubscriptionRoleId, A13WWPSubscriptionId, AV10NotifShowOnlySubscribedEvents, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A10WWPEntityId, AV13WWPEntityId, A26WWPNotificationDefinitionAppliesTo, A14WWPNotificationDefinitionId, A25WWPNotificationDefinitionDescription, A11WWPSubscriptionRoleId, AV16WWPSubscriptionRoleId, A13WWPSubscriptionId, AV10NotifShowOnlySubscribedEvents, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A10WWPEntityId, AV13WWPEntityId, A26WWPNotificationDefinitionAppliesTo, A14WWPNotificationDefinitionId, A25WWPNotificationDefinitionDescription, A11WWPSubscriptionRoleId, AV16WWPSubscriptionRoleId, A13WWPSubscriptionId, AV10NotifShowOnlySubscribedEvents, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A10WWPEntityId, AV13WWPEntityId, A26WWPNotificationDefinitionAppliesTo, A14WWPNotificationDefinitionId, A25WWPNotificationDefinitionDescription, A11WWPSubscriptionRoleId, AV16WWPSubscriptionRoleId, A13WWPSubscriptionId, AV10NotifShowOnlySubscribedEvents, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A10WWPEntityId, AV13WWPEntityId, A26WWPNotificationDefinitionAppliesTo, A14WWPNotificationDefinitionId, A25WWPNotificationDefinitionDescription, A11WWPSubscriptionRoleId, AV16WWPSubscriptionRoleId, A13WWPSubscriptionId, AV10NotifShowOnlySubscribedEvents, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsByRoleWC";
         context.Gx_err = 0;
         edtavWwpnotificationdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavWwpnotificationdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdescription_Enabled), 5, 0), !bGXsfl_9_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP230( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12232 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ",", "."));
            wcpOAV13WWPEntityId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV13WWPEntityId"), ",", "."));
            wcpOAV10NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV10NotifShowOnlySubscribedEvents"));
            wcpOAV16WWPSubscriptionRoleId = cgiGet( sPrefix+"wcpOAV16WWPSubscriptionRoleId");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
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
         E12232 ();
         if (returnInSub) return;
      }

      protected void E12232( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavWwpnotificationdefinitionid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationdefinitionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E13232( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
      }

      private void E14232( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV7GridRecordCount = 0;
         /* Using cursor H00232 */
         pr_default.execute(0, new Object[] {AV13WWPEntityId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14WWPNotificationDefinitionId = H00232_A14WWPNotificationDefinitionId[0];
            A26WWPNotificationDefinitionAppliesTo = H00232_A26WWPNotificationDefinitionAppliesTo[0];
            A10WWPEntityId = H00232_A10WWPEntityId[0];
            A25WWPNotificationDefinitionDescription = H00232_A25WWPNotificationDefinitionDescription[0];
            AV5WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            AssignAttri(sPrefix, false, edtavWwpnotificationdefinitionid_Internalname, StringUtil.LTrimStr( (decimal)(AV5WWPNotificationDefinitionId), 10, 0));
            AV15WWPNotificationDescriptionBase = A25WWPNotificationDefinitionDescription;
            AV14WWPNotificationDescription = AV15WWPNotificationDescriptionBase;
            AssignAttri(sPrefix, false, edtavWwpnotificationdescription_Internalname, AV14WWPNotificationDescription);
            AV9IncludeNotification = false;
            AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV9IncludeNotification);
            AV6WWPSubscriptionId = 0;
            AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV6WWPSubscriptionId), 10, 0));
            /* Using cursor H00233 */
            pr_default.execute(1, new Object[] {A14WWPNotificationDefinitionId, AV16WWPSubscriptionRoleId, A26WWPNotificationDefinitionAppliesTo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11WWPSubscriptionRoleId = H00233_A11WWPSubscriptionRoleId[0];
               n11WWPSubscriptionRoleId = H00233_n11WWPSubscriptionRoleId[0];
               A13WWPSubscriptionId = H00233_A13WWPSubscriptionId[0];
               AV6WWPSubscriptionId = A13WWPSubscriptionId;
               AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV6WWPSubscriptionId), 10, 0));
               AV7GridRecordCount = (short)(AV7GridRecordCount+1);
               AV9IncludeNotification = true;
               AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV9IncludeNotification);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 9;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_92( ) ;
                  GRID_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
                  if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
                  {
                     GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
                  }
               }
               if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
               {
                  GRID_nEOF = 0;
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               }
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
               {
                  context.DoAjaxLoad(9, GridRow);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( ! AV9IncludeNotification && ! AV10NotifShowOnlySubscribedEvents )
            {
               AV7GridRecordCount = (short)(AV7GridRecordCount+1);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 9;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_92( ) ;
                  GRID_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
                  if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
                  {
                     GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
                  }
               }
               if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
               {
                  GRID_nEOF = 0;
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               }
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
               {
                  context.DoAjaxLoad(9, GridRow);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV23GridPageCount = (short)(AV7GridRecordCount/ (decimal)(subGrid_Rows)+((((int)((AV7GridRecordCount) % (subGrid_Rows)))>0) ? 1 : 0));
         /*  Sending Event outputs  */
      }

      protected void E15232( )
      {
         /* 'FirstPage' Routine */
         returnInSub = false;
         subgrid_firstpage( ) ;
      }

      protected void E16232( )
      {
         /* 'PreviousPage' Routine */
         returnInSub = false;
         subgrid_previouspage( ) ;
      }

      protected void E17232( )
      {
         /* 'NextPage' Routine */
         returnInSub = false;
         subgrid_nextpage( ) ;
      }

      protected void E18232( )
      {
         /* 'LastPage' Routine */
         returnInSub = false;
         subgrid_lastpage( ) ;
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV11Session.Get(AV28Pgmname+"GridState"), "") == 0 )
         {
            AV8GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV28Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         else
         {
            AV8GridState.FromXml(AV11Session.Get(AV28Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV8GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV8GridState.gxTpr_Currentpage) ;
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV8GridState.FromXml(AV11Session.Get(AV28Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         AV8GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV8GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV28Pgmname+"GridState",  AV8GridState.ToXml(false, true, "WWPGridState", "RastreamentoTCC")) ;
      }

      protected void E11232( )
      {
         /* Tablesubscriptionitem_Click Routine */
         returnInSub = false;
         AV9IncludeNotification = (bool)(!AV9IncludeNotification);
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV9IncludeNotification);
         new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_roleupdatesubscription(context ).execute(  AV9IncludeNotification, ref  AV6WWPSubscriptionId,  AV5WWPNotificationDefinitionId,  AV16WWPSubscriptionRoleId) ;
         AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV6WWPSubscriptionId), 10, 0));
         if ( 1 == 0 )
         {
            /* Start For Each Line */
            nRC_GXsfl_9 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ",", "."));
            nGXsfl_9_fel_idx = 0;
            while ( nGXsfl_9_fel_idx < nRC_GXsfl_9 )
            {
               nGXsfl_9_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_fel_idx+1);
               sGXsfl_9_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_92( ) ;
               AV9IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
               AV14WWPNotificationDescription = cgiGet( edtavWwpnotificationdescription_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPNOTIFICATIONDEFINITIONID");
                  GX_FocusControl = edtavWwpnotificationdefinitionid_Internalname;
                  wbErr = true;
                  AV5WWPNotificationDefinitionId = 0;
               }
               else
               {
                  AV5WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( edtavWwpnotificationdefinitionid_Internalname), ",", "."));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                  GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                  wbErr = true;
                  AV6WWPSubscriptionId = 0;
               }
               else
               {
                  AV6WWPSubscriptionId = (long)(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", "."));
               }
               /* End For Each Line */
            }
            if ( nGXsfl_9_fel_idx == 0 )
            {
               nGXsfl_9_idx = 1;
               sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
               SubsflControlProps_92( ) ;
            }
            nGXsfl_9_fel_idx = 1;
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13WWPEntityId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV13WWPEntityId", StringUtil.LTrimStr( (decimal)(AV13WWPEntityId), 10, 0));
         AV10NotifShowOnlySubscribedEvents = (bool)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV10NotifShowOnlySubscribedEvents", AV10NotifShowOnlySubscribedEvents);
         AV16WWPSubscriptionRoleId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV16WWPSubscriptionRoleId", AV16WWPSubscriptionRoleId);
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
         PA232( ) ;
         WS232( ) ;
         WE232( ) ;
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
         sCtrlAV13WWPEntityId = (string)((string)getParm(obj,0));
         sCtrlAV10NotifShowOnlySubscribedEvents = (string)((string)getParm(obj,1));
         sCtrlAV16WWPSubscriptionRoleId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA232( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\subscriptions\\wwp_subscriptionssettingsbyrolewc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA232( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV13WWPEntityId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV13WWPEntityId", StringUtil.LTrimStr( (decimal)(AV13WWPEntityId), 10, 0));
            AV10NotifShowOnlySubscribedEvents = (bool)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV10NotifShowOnlySubscribedEvents", AV10NotifShowOnlySubscribedEvents);
            AV16WWPSubscriptionRoleId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV16WWPSubscriptionRoleId", AV16WWPSubscriptionRoleId);
         }
         wcpOAV13WWPEntityId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV13WWPEntityId"), ",", "."));
         wcpOAV10NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV10NotifShowOnlySubscribedEvents"));
         wcpOAV16WWPSubscriptionRoleId = cgiGet( sPrefix+"wcpOAV16WWPSubscriptionRoleId");
         if ( ! GetJustCreated( ) && ( ( AV13WWPEntityId != wcpOAV13WWPEntityId ) || ( AV10NotifShowOnlySubscribedEvents != wcpOAV10NotifShowOnlySubscribedEvents ) || ( StringUtil.StrCmp(AV16WWPSubscriptionRoleId, wcpOAV16WWPSubscriptionRoleId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV13WWPEntityId = AV13WWPEntityId;
         wcpOAV10NotifShowOnlySubscribedEvents = AV10NotifShowOnlySubscribedEvents;
         wcpOAV16WWPSubscriptionRoleId = AV16WWPSubscriptionRoleId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV13WWPEntityId = cgiGet( sPrefix+"AV13WWPEntityId_CTRL");
         if ( StringUtil.Len( sCtrlAV13WWPEntityId) > 0 )
         {
            AV13WWPEntityId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV13WWPEntityId), ",", "."));
            AssignAttri(sPrefix, false, "AV13WWPEntityId", StringUtil.LTrimStr( (decimal)(AV13WWPEntityId), 10, 0));
         }
         else
         {
            AV13WWPEntityId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV13WWPEntityId_PARM"), ",", "."));
         }
         sCtrlAV10NotifShowOnlySubscribedEvents = cgiGet( sPrefix+"AV10NotifShowOnlySubscribedEvents_CTRL");
         if ( StringUtil.Len( sCtrlAV10NotifShowOnlySubscribedEvents) > 0 )
         {
            AV10NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sCtrlAV10NotifShowOnlySubscribedEvents));
            AssignAttri(sPrefix, false, "AV10NotifShowOnlySubscribedEvents", AV10NotifShowOnlySubscribedEvents);
         }
         else
         {
            AV10NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( sPrefix+"AV10NotifShowOnlySubscribedEvents_PARM"));
         }
         sCtrlAV16WWPSubscriptionRoleId = cgiGet( sPrefix+"AV16WWPSubscriptionRoleId_CTRL");
         if ( StringUtil.Len( sCtrlAV16WWPSubscriptionRoleId) > 0 )
         {
            AV16WWPSubscriptionRoleId = cgiGet( sCtrlAV16WWPSubscriptionRoleId);
            AssignAttri(sPrefix, false, "AV16WWPSubscriptionRoleId", AV16WWPSubscriptionRoleId);
         }
         else
         {
            AV16WWPSubscriptionRoleId = cgiGet( sPrefix+"AV16WWPSubscriptionRoleId_PARM");
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
         PA232( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS232( ) ;
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
         WS232( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV13WWPEntityId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13WWPEntityId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV13WWPEntityId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV13WWPEntityId_CTRL", StringUtil.RTrim( sCtrlAV13WWPEntityId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10NotifShowOnlySubscribedEvents_PARM", StringUtil.BoolToStr( AV10NotifShowOnlySubscribedEvents));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10NotifShowOnlySubscribedEvents)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10NotifShowOnlySubscribedEvents_CTRL", StringUtil.RTrim( sCtrlAV10NotifShowOnlySubscribedEvents));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPSubscriptionRoleId_PARM", StringUtil.RTrim( AV16WWPSubscriptionRoleId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16WWPSubscriptionRoleId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPSubscriptionRoleId_CTRL", StringUtil.RTrim( sCtrlAV16WWPSubscriptionRoleId));
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
         WE232( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281548479", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscriptionssettingsbyrolewc.js", "?20214281548480", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_idx;
         edtavWwpnotificationdescription_Internalname = sPrefix+"vWWPNOTIFICATIONDESCRIPTION_"+sGXsfl_9_idx;
         edtavWwpnotificationdefinitionid_Internalname = sPrefix+"vWWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_fel_idx;
         edtavWwpnotificationdescription_Internalname = sPrefix+"vWWPNOTIFICATIONDESCRIPTION_"+sGXsfl_9_fel_idx;
         edtavWwpnotificationdefinitionid_Internalname = sPrefix+"vWWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_fel_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         SubsflControlProps_92( ) ;
         WB230( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_9_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
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
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SubscriptionItem",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablesubscriptionitem_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,(string)"Include Notification",(string)"gx-form-item AttributeCheckBoxLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Check box */
            TempTags = " " + ((chkavIncludenotification.Enabled!=0)&&(chkavIncludenotification.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 16,'"+sPrefix+"',false,'"+sGXsfl_9_idx+"',9)\"" : " ");
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_9_idx;
            chkavIncludenotification.Name = GXCCtl;
            chkavIncludenotification.WebTags = "";
            chkavIncludenotification.Caption = "";
            AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_9_Refreshing);
            chkavIncludenotification.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,StringUtil.BoolToStr( AV9IncludeNotification),(string)"",(string)"Include Notification",(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(16, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavIncludenotification.Enabled!=0)&&(chkavIncludenotification.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,16);\"" : " ")});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdescription_Internalname,(string)"WWPNotification Description",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            TempTags = " " + ((edtavWwpnotificationdescription_Enabled!=0)&&(edtavWwpnotificationdescription_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 19,'"+sPrefix+"',false,'"+sGXsfl_9_idx+"',9)\"" : " ");
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdescription_Internalname,(string)AV14WWPNotificationDescription,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavWwpnotificationdescription_Enabled!=0)&&(edtavWwpnotificationdescription_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,19);\"" : " "),(short)0,(short)1,(int)edtavWwpnotificationdescription_Enabled,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_9_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdefinitionid_Internalname,(string)"WWPNotification Definition Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = " " + ((edtavWwpnotificationdefinitionid_Enabled!=0)&&(edtavWwpnotificationdefinitionid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'"+sPrefix+"',false,'"+sGXsfl_9_idx+"',9)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationdefinitionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPNotificationDefinitionId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5WWPNotificationDefinitionId), "ZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavWwpnotificationdefinitionid_Enabled!=0)&&(edtavWwpnotificationdefinitionid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpnotificationdefinitionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpnotificationdefinitionid_Visible,(short)1,(short)0,(string)"number",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,(string)"WWPSubscription Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = " " + ((edtavWwpsubscriptionid_Enabled!=0)&&(edtavWwpsubscriptionid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 29,'"+sPrefix+"',false,'"+sGXsfl_9_idx+"',9)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6WWPSubscriptionId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6WWPSubscriptionId), "ZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavWwpsubscriptionid_Enabled!=0)&&(edtavWwpsubscriptionid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,29);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpsubscriptionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpsubscriptionid_Visible,(short)1,(short)0,(string)"number",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            send_integrity_lvl_hashes232( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_9_idx;
         chkavIncludenotification.Name = GXCCtl;
         chkavIncludenotification.WebTags = "";
         chkavIncludenotification.Caption = "";
         AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_9_Refreshing);
         chkavIncludenotification.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION";
         edtavWwpnotificationdescription_Internalname = sPrefix+"vWWPNOTIFICATIONDESCRIPTION";
         divTablesubscriptionitem_Internalname = sPrefix+"TABLESUBSCRIPTIONITEM";
         edtavWwpnotificationdefinitionid_Internalname = sPrefix+"vWWPNOTIFICATIONDEFINITIONID";
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID";
         tblUnnamedtablecontentfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRID";
         divUnnamedtablefsgrid_Internalname = sPrefix+"UNNAMEDTABLEFSGRID";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtavWwpsubscriptionid_Jsonclick = "";
         edtavWwpsubscriptionid_Enabled = 1;
         edtavWwpnotificationdefinitionid_Jsonclick = "";
         edtavWwpnotificationdefinitionid_Enabled = 1;
         edtavWwpnotificationdescription_Visible = 1;
         chkavIncludenotification.Caption = "Include Notification";
         chkavIncludenotification.Visible = 1;
         chkavIncludenotification.Enabled = 1;
         subGrid_Class = "FreeStyleGrid";
         subGrid_Allowcollapsing = 0;
         edtavWwpnotificationdescription_Enabled = 1;
         subGrid_Backcolorstyle = 0;
         subGrid_Rows = 0;
         edtavWwpsubscriptionid_Visible = 1;
         edtavWwpnotificationdefinitionid_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtavWwpnotificationdefinitionid_Visible',ctrl:'vWWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV13WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV16WWPSubscriptionRoleId',fld:'vWWPSUBSCRIPTIONROLEID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV10NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''},{av:'sPrefix'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E14232',iparms:[{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV13WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV16WWPSubscriptionRoleId',fld:'vWWPSUBSCRIPTIONROLEID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV10NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV5WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'AV14WWPNotificationDescription',fld:'vWWPNOTIFICATIONDESCRIPTION',pic:''},{av:'AV9IncludeNotification',fld:'vINCLUDENOTIFICATION',pic:''},{av:'AV6WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'FIRSTPAGE'","{handler:'E15232',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtavWwpnotificationdefinitionid_Visible',ctrl:'vWWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV13WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV16WWPSubscriptionRoleId',fld:'vWWPSUBSCRIPTIONROLEID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV10NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'FIRSTPAGE'",",oparms:[]}");
         setEventMetadata("'PREVIOUSPAGE'","{handler:'E16232',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtavWwpnotificationdefinitionid_Visible',ctrl:'vWWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV13WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV16WWPSubscriptionRoleId',fld:'vWWPSUBSCRIPTIONROLEID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV10NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'PREVIOUSPAGE'",",oparms:[]}");
         setEventMetadata("'NEXTPAGE'","{handler:'E17232',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtavWwpnotificationdefinitionid_Visible',ctrl:'vWWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV13WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV16WWPSubscriptionRoleId',fld:'vWWPSUBSCRIPTIONROLEID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV10NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'NEXTPAGE'",",oparms:[]}");
         setEventMetadata("'LASTPAGE'","{handler:'E18232',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtavWwpnotificationdefinitionid_Visible',ctrl:'vWWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV13WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A26WWPNotificationDefinitionAppliesTo',fld:'WWPNOTIFICATIONDEFINITIONAPPLIESTO',pic:'9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A25WWPNotificationDefinitionDescription',fld:'WWPNOTIFICATIONDEFINITIONDESCRIPTION',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV16WWPSubscriptionRoleId',fld:'vWWPSUBSCRIPTIONROLEID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV10NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''},{av:'sPrefix'}]");
         setEventMetadata("'LASTPAGE'",",oparms:[]}");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK","{handler:'E11232',iparms:[{av:'AV9IncludeNotification',fld:'vINCLUDENOTIFICATION',grid:9,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_9',ctrl:'GRID',grid:9,prop:'GridRC'},{av:'AV6WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',grid:9,pic:'ZZZZZZZZZ9'},{av:'AV5WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',grid:9,pic:'ZZZZZZZZZ9'},{av:'AV16WWPSubscriptionRoleId',fld:'vWWPSUBSCRIPTIONROLEID',pic:''}]");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK",",oparms:[{av:'AV9IncludeNotification',fld:'vINCLUDENOTIFICATION',pic:''},{av:'AV6WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Validv_Wwpsubscriptionid',iparms:[]");
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
         wcpOAV16WWPSubscriptionRoleId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV28Pgmname = "";
         A25WWPNotificationDefinitionDescription = "";
         A11WWPSubscriptionRoleId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         AV14WWPNotificationDescription = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         H00232_A14WWPNotificationDefinitionId = new long[1] ;
         H00232_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         H00232_A10WWPEntityId = new long[1] ;
         H00232_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         AV15WWPNotificationDescriptionBase = "";
         H00233_A14WWPNotificationDefinitionId = new long[1] ;
         H00233_A11WWPSubscriptionRoleId = new string[] {""} ;
         H00233_n11WWPSubscriptionRoleId = new bool[] {false} ;
         H00233_A13WWPSubscriptionId = new long[1] ;
         GridRow = new GXWebRow();
         AV11Session = context.GetSession();
         AV8GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV13WWPEntityId = "";
         sCtrlAV10NotifShowOnlySubscribedEvents = "";
         sCtrlAV16WWPSubscriptionRoleId = "";
         subGrid_Linesclass = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscriptionssettingsbyrolewc__default(),
            new Object[][] {
                new Object[] {
               H00232_A14WWPNotificationDefinitionId, H00232_A26WWPNotificationDefinitionAppliesTo, H00232_A10WWPEntityId, H00232_A25WWPNotificationDefinitionDescription
               }
               , new Object[] {
               H00233_A14WWPNotificationDefinitionId, H00233_A11WWPSubscriptionRoleId, H00233_n11WWPSubscriptionRoleId, H00233_A13WWPSubscriptionId
               }
            }
         );
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsByRoleWC";
         /* GeneXus formulas. */
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettingsByRoleWC";
         context.Gx_err = 0;
         edtavWwpnotificationdescription_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A26WWPNotificationDefinitionAppliesTo ;
      private short initialized ;
      private short nGXWrapped ;
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
      private short AV7GridRecordCount ;
      private short AV23GridPageCount ;
      private short subGrid_Backstyle ;
      private int edtavWwpnotificationdefinitionid_Visible ;
      private int edtavWwpsubscriptionid_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int edtavWwpnotificationdescription_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int subGrid_Recordcount ;
      private int nGXsfl_9_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavWwpnotificationdescription_Visible ;
      private int edtavWwpnotificationdefinitionid_Enabled ;
      private int edtavWwpsubscriptionid_Enabled ;
      private long AV13WWPEntityId ;
      private long wcpOAV13WWPEntityId ;
      private long GRID_nFirstRecordOnPage ;
      private long A10WWPEntityId ;
      private long A14WWPNotificationDefinitionId ;
      private long A13WWPSubscriptionId ;
      private long AV5WWPNotificationDefinitionId ;
      private long AV6WWPSubscriptionId ;
      private long GRID_nCurrentRecord ;
      private string AV16WWPSubscriptionRoleId ;
      private string wcpOAV16WWPSubscriptionRoleId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string edtavWwpnotificationdefinitionid_Internalname ;
      private string edtavWwpsubscriptionid_Internalname ;
      private string AV28Pgmname ;
      private string A11WWPSubscriptionRoleId ;
      private string edtavWwpnotificationdescription_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Header ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavIncludenotification_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string sCtrlAV13WWPEntityId ;
      private string sCtrlAV10NotifShowOnlySubscribedEvents ;
      private string sCtrlAV16WWPSubscriptionRoleId ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string divTablesubscriptionitem_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string ROClassString ;
      private string edtavWwpnotificationdefinitionid_Jsonclick ;
      private string edtavWwpsubscriptionid_Jsonclick ;
      private bool AV10NotifShowOnlySubscribedEvents ;
      private bool wcpOAV10NotifShowOnlySubscribedEvents ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool n11WWPSubscriptionRoleId ;
      private bool wbLoad ;
      private bool AV9IncludeNotification ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A25WWPNotificationDefinitionDescription ;
      private string AV14WWPNotificationDescription ;
      private string AV15WWPNotificationDescriptionBase ;
      private IGxSession AV11Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIncludenotification ;
      private IDataStoreProvider pr_default ;
      private long[] H00232_A14WWPNotificationDefinitionId ;
      private short[] H00232_A26WWPNotificationDefinitionAppliesTo ;
      private long[] H00232_A10WWPEntityId ;
      private string[] H00232_A25WWPNotificationDefinitionDescription ;
      private long[] H00233_A14WWPNotificationDefinitionId ;
      private string[] H00233_A11WWPSubscriptionRoleId ;
      private bool[] H00233_n11WWPSubscriptionRoleId ;
      private long[] H00233_A13WWPSubscriptionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV8GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
   }

   public class wwp_subscriptionssettingsbyrolewc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00232;
          prmH00232 = new Object[] {
          new Object[] {"@AV13WWPEntityId",SqlDbType.Decimal,10,0}
          };
          Object[] prmH00233;
          prmH00233 = new Object[] {
          new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV16WWPSubscriptionRoleId",SqlDbType.NChar,40,0} ,
          new Object[] {"@WWPNotificationDefinitionAppliesTo",SqlDbType.SmallInt,1,0}
          };
          def= new CursorDef[] {
              new CursorDef("H00232", "SELECT [WWPNotificationDefinitionId], [WWPNotificationDefinitionAppliesTo], [WWPEntityId], [WWPNotificationDefinitionDescription] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV13WWPEntityId) AND ([WWPNotificationDefinitionAppliesTo] = 1) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00232,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00233", "SELECT [WWPNotificationDefinitionId], [WWPSubscriptionRoleId], [WWPSubscriptionId] FROM [WWP_Subscription] WHERE ([WWPNotificationDefinitionId] = @WWPNotificationDefinitionId) AND ([WWPSubscriptionRoleId] = @AV16WWPSubscriptionRoleId) AND (@WWPNotificationDefinitionAppliesTo = 1) ORDER BY [WWPNotificationDefinitionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00233,100, GxCacheFrequency.OFF ,false,false )
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
                table[1][0] = rslt.getShort(2);
                table[2][0] = rslt.getLong(3);
                table[3][0] = rslt.getVarchar(4);
                return;
             case 1 :
                table[0][0] = rslt.getLong(1);
                table[1][0] = rslt.getString(2, 40);
                table[2][0] = rslt.wasNull(2);
                table[3][0] = rslt.getLong(3);
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
                stmt.SetParameter(2, (string)parms[1]);
                stmt.SetParameter(3, (short)parms[2]);
                return;
       }
    }

 }

}
