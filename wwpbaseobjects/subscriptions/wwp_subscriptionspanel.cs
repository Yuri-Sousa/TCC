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
   public class wwp_subscriptionspanel : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_subscriptionspanel( )
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

      public wwp_subscriptionspanel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_RecordAttDescription )
      {
         this.AV6WWPEntityName = aP0_WWPEntityName;
         this.AV7WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV20WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV14RecordAttDescription = aP3_RecordAttDescription;
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
               gxfirstwebparm = GetFirstPar( "WWPEntityName");
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
                  AV6WWPEntityName = GetPar( "WWPEntityName");
                  AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
                  AV7WWPNotificationAppliesTo = (short)(NumberUtil.Val( GetPar( "WWPNotificationAppliesTo"), "."));
                  AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
                  AV20WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
                  AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
                  AV14RecordAttDescription = GetPar( "RecordAttDescription");
                  AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WWPEntityName,(short)AV7WWPNotificationAppliesTo,(string)AV20WWPSubscriptionEntityRecordId,(string)AV14RecordAttDescription});
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
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_9 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."));
                  nGXsfl_9_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."));
                  sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
                  sPrefix = GetPar( "sPrefix");
                  edtWWPNotificationDefinitionId_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
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
                  AV5WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
                  AV7WWPNotificationAppliesTo = (short)(NumberUtil.Val( GetPar( "WWPNotificationAppliesTo"), "."));
                  AV28Pgmname = GetPar( "Pgmname");
                  edtWWPNotificationDefinitionId_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  edtavWwpsubscriptionid_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
                  A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
                  n1WWPUserExtendedId = false;
                  AV31Udparg1 = GetPar( "Udparg1");
                  A23WWPSubscriptionSubscribed = StringUtil.StrToBool( GetPar( "WWPSubscriptionSubscribed"));
                  A11WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
                  n11WWPSubscriptionRoleId = false;
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV23WWPSubscriptionRoleIdCollection);
                  AV8WWPNotificationId = (long)(NumberUtil.Val( GetPar( "WWPNotificationId"), "."));
                  A22WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
                  AV20WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
                  A13WWPSubscriptionId = (long)(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."));
                  AV24WWPNotificationDefinitionId = (long)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."));
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV28Pgmname, A1WWPUserExtendedId, AV31Udparg1, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A22WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A13WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
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
            PA252( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
               context.Gx_err = 0;
               WS252( ) ;
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
            context.SendWebValue( "Subscriptions of an Entity/Record") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142815473764", false, true);
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV6WWPEntityName)),UrlEncode(StringUtil.LTrimStr(AV7WWPNotificationAppliesTo,1,0)),UrlEncode(StringUtil.RTrim(AV20WWPSubscriptionEntityRecordId)),UrlEncode(StringUtil.RTrim(AV14RecordAttDescription))}, new string[] {"WWPEntityName","WWPNotificationAppliesTo","WWPSubscriptionEntityRecordId","RecordAttDescription"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV31Udparg1, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WWPEntityName", wcpOAV6WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPNotificationAppliesTo", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7WWPNotificationAppliesTo), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId", wcpOAV20WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14RecordAttDescription", wcpOAV14RecordAttDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDID", StringUtil.RTrim( A1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV31Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV31Udparg1, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONSUBSCRIBED", A23WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONROLEID", StringUtil.RTrim( A11WWPSubscriptionRoleId));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONENTITYRECORDID", A22WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDID", AV20WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13WWPSubscriptionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRECORDATTDESCRIPTION", AV14RecordAttDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYNAME", AV6WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONAPPLIESTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationAppliesTo), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm252( )
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
         return "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel" ;
      }

      public override string GetPgmdesc( )
      {
         return "Subscriptions of an Entity/Record" ;
      }

      protected void WB250( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainDiscussions", "left", "top", "", "", "div");
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
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV12IncludeNotification));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A25WWPNotificationDefinitionDescription);
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WWPSubscriptionId), 10, 0, ".", "")));
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

      protected void START252( )
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
               Form.Meta.addItem("description", "Subscriptions of an Entity/Record", 0) ;
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
               STRUP250( ) ;
            }
         }
      }

      protected void WS252( )
      {
         START252( ) ;
         EVT252( ) ;
      }

      protected void EVT252( )
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
                                 STRUP250( ) ;
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
                                 STRUP250( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11252 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP250( ) ;
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
                                 STRUP250( ) ;
                              }
                              nGXsfl_9_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV12IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
                              AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
                              A25WWPNotificationDefinitionDescription = cgiGet( edtWWPNotificationDefinitionDescription_Internalname);
                              A14WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", "."));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                                 GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV22WWPSubscriptionId = 0;
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
                              }
                              else
                              {
                                 AV22WWPSubscriptionId = (long)(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", "."));
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
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
                                          E12252 ();
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
                                          E13252 ();
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
                                          E14252 ();
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
                                          E15252 ();
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
                                          E16252 ();
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
                                          E17252 ();
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
                                          E18252 ();
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
                                          E11252 ();
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
                                       STRUP250( ) ;
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

      protected void WE252( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm252( ) ;
            }
         }
      }

      protected void PA252( )
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
                                       long AV5WWPEntityId ,
                                       short AV7WWPNotificationAppliesTo ,
                                       string AV28Pgmname ,
                                       string A1WWPUserExtendedId ,
                                       string AV31Udparg1 ,
                                       bool A23WWPSubscriptionSubscribed ,
                                       string A11WWPSubscriptionRoleId ,
                                       GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ,
                                       long AV8WWPNotificationId ,
                                       string A22WWPSubscriptionEntityRecordId ,
                                       string AV20WWPSubscriptionEntityRecordId ,
                                       long A13WWPSubscriptionId ,
                                       long AV24WWPNotificationDefinitionId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E13252 ();
         GRID_nCurrentRecord = 0;
         RF252( ) ;
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
         RF252( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         context.Gx_err = 0;
      }

      protected void RF252( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E13252 ();
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H00252 */
            pr_default.execute(0, new Object[] {AV5WWPEntityId, AV7WWPNotificationAppliesTo, GXPagingFrom2, GXPagingTo2});
            nGXsfl_9_idx = 1;
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A27WWPNotificationDefinitionAllowUserSubscription = H00252_A27WWPNotificationDefinitionAllowUserSubscription[0];
               A26WWPNotificationDefinitionAppliesTo = H00252_A26WWPNotificationDefinitionAppliesTo[0];
               A10WWPEntityId = H00252_A10WWPEntityId[0];
               A14WWPNotificationDefinitionId = H00252_A14WWPNotificationDefinitionId[0];
               A25WWPNotificationDefinitionDescription = H00252_A25WWPNotificationDefinitionDescription[0];
               E14252 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 9;
            WB250( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes252( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV31Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV31Udparg1, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
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
         AV31Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor H00253 */
         pr_default.execute(1, new Object[] {AV5WWPEntityId, AV7WWPNotificationAppliesTo});
         GRID_nRecordCount = H00253_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV28Pgmname, A1WWPUserExtendedId, AV31Udparg1, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A22WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A13WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV28Pgmname, A1WWPUserExtendedId, AV31Udparg1, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A22WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A13WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV28Pgmname, A1WWPUserExtendedId, AV31Udparg1, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A22WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A13WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV28Pgmname, A1WWPUserExtendedId, AV31Udparg1, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A22WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A13WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV28Pgmname, A1WWPUserExtendedId, AV31Udparg1, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A22WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A13WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP250( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12252 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ",", "."));
            wcpOAV6WWPEntityName = cgiGet( sPrefix+"wcpOAV6WWPEntityName");
            wcpOAV7WWPNotificationAppliesTo = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPNotificationAppliesTo"), ",", "."));
            wcpOAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId");
            wcpOAV14RecordAttDescription = cgiGet( sPrefix+"wcpOAV14RecordAttDescription");
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
         E12252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12252( )
      {
         /* Start Routine */
         returnInSub = false;
         edtWWPNotificationDefinitionId_Visible = 0;
         AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         /* Using cursor H00254 */
         pr_default.execute(2, new Object[] {AV6WWPEntityName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A12WWPEntityName = H00254_A12WWPEntityName[0];
            A10WWPEntityId = H00254_A10WWPEntityId[0];
            AV5WWPEntityId = A10WWPEntityId;
            AssignAttri(sPrefix, false, "AV5WWPEntityId", StringUtil.LTrimStr( (decimal)(AV5WWPEntityId), 10, 0));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         GXt_objcol_char1 = AV23WWPSubscriptionRoleIdCollection;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserroles(context ).execute( out  GXt_objcol_char1) ;
         AV23WWPSubscriptionRoleIdCollection = GXt_objcol_char1;
      }

      protected void E13252( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E14252( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV8WWPNotificationId = A14WWPNotificationDefinitionId;
         AssignAttri(sPrefix, false, "AV8WWPNotificationId", StringUtil.LTrimStr( (decimal)(AV8WWPNotificationId), 10, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         /* Execute user subroutine: 'LOADCHECKINCLUDENOTIFICATIONS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 9;
         }
         sendrow_92( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            context.DoAjaxLoad(9, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E15252( )
      {
         /* 'FirstPage' Routine */
         returnInSub = false;
         subgrid_firstpage( ) ;
      }

      protected void E16252( )
      {
         /* 'PreviousPage' Routine */
         returnInSub = false;
         subgrid_previouspage( ) ;
      }

      protected void E17252( )
      {
         /* 'NextPage' Routine */
         returnInSub = false;
         subgrid_nextpage( ) ;
      }

      protected void E18252( )
      {
         /* 'LastPage' Routine */
         returnInSub = false;
         subgrid_lastpage( ) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV28Pgmname+"GridState"), "") == 0 )
         {
            AV9GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV28Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         else
         {
            AV9GridState.FromXml(AV16Session.Get(AV28Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV9GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV9GridState.gxTpr_Currentpage) ;
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV9GridState.FromXml(AV16Session.Get(AV28Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         AV9GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV9GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV28Pgmname+"GridState",  AV9GridState.ToXml(false, true, "WWPGridState", "RastreamentoTCC")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV17TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17TrnContext.gxTpr_Callerobject = AV28Pgmname;
         AV17TrnContext.gxTpr_Callerondelete = true;
         AV17TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV17TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Notifications.Common.WWP_NotificationDefinition";
         AV16Session.Set("TrnContext", AV17TrnContext.ToXml(false, true, "WWPTransactionContext", "RastreamentoTCC"));
      }

      protected void E11252( )
      {
         /* Tablesubscriptionitem_Click Routine */
         returnInSub = false;
         AV12IncludeNotification = (bool)(!AV12IncludeNotification);
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
         new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription(context ).execute(  AV12IncludeNotification, ref  AV22WWPSubscriptionId,  A14WWPNotificationDefinitionId,  AV20WWPSubscriptionEntityRecordId,  AV14RecordAttDescription) ;
         AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
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
               AV12IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
               A25WWPNotificationDefinitionDescription = cgiGet( edtWWPNotificationDefinitionDescription_Internalname);
               A14WWPNotificationDefinitionId = (long)(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", "."));
               if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                  GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                  wbErr = true;
                  AV22WWPSubscriptionId = 0;
               }
               else
               {
                  AV22WWPSubscriptionId = (long)(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", "."));
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

      protected void S142( )
      {
         /* 'LOADCHECKINCLUDENOTIFICATIONS' Routine */
         returnInSub = false;
         AV12IncludeNotification = false;
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
         AV31Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A11WWPSubscriptionRoleId ,
                                              AV23WWPSubscriptionRoleIdCollection ,
                                              AV20WWPSubscriptionEntityRecordId ,
                                              A22WWPSubscriptionEntityRecordId ,
                                              A1WWPUserExtendedId ,
                                              AV31Udparg1 ,
                                              A23WWPSubscriptionSubscribed ,
                                              AV8WWPNotificationId ,
                                              A14WWPNotificationDefinitionId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H00255 */
         pr_default.execute(3, new Object[] {AV8WWPNotificationId, AV31Udparg1, AV20WWPSubscriptionEntityRecordId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A22WWPSubscriptionEntityRecordId = H00255_A22WWPSubscriptionEntityRecordId[0];
            A14WWPNotificationDefinitionId = H00255_A14WWPNotificationDefinitionId[0];
            A11WWPSubscriptionRoleId = H00255_A11WWPSubscriptionRoleId[0];
            n11WWPSubscriptionRoleId = H00255_n11WWPSubscriptionRoleId[0];
            A23WWPSubscriptionSubscribed = H00255_A23WWPSubscriptionSubscribed[0];
            A1WWPUserExtendedId = H00255_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = H00255_n1WWPUserExtendedId[0];
            A13WWPSubscriptionId = H00255_A13WWPSubscriptionId[0];
            AV22WWPSubscriptionId = A13WWPSubscriptionId;
            AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
            AV12IncludeNotification = true;
            AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A11WWPSubscriptionRoleId)) )
            {
               GXt_boolean2 = AV12IncludeNotification;
               new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed(context ).execute(  AV24WWPNotificationDefinitionId, ref  AV22WWPSubscriptionId, ref  GXt_boolean2) ;
               AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
               AV12IncludeNotification = GXt_boolean2;
               AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WWPEntityName = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
         AV7WWPNotificationAppliesTo = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
         AV20WWPSubscriptionEntityRecordId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
         AV14RecordAttDescription = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
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
         PA252( ) ;
         WS252( ) ;
         WE252( ) ;
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
         sCtrlAV6WWPEntityName = (string)((string)getParm(obj,0));
         sCtrlAV7WWPNotificationAppliesTo = (string)((string)getParm(obj,1));
         sCtrlAV20WWPSubscriptionEntityRecordId = (string)((string)getParm(obj,2));
         sCtrlAV14RecordAttDescription = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA252( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\subscriptions\\wwp_subscriptionspanel", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA252( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WWPEntityName = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
            AV7WWPNotificationAppliesTo = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
            AV20WWPSubscriptionEntityRecordId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
            AV14RecordAttDescription = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
         }
         wcpOAV6WWPEntityName = cgiGet( sPrefix+"wcpOAV6WWPEntityName");
         wcpOAV7WWPNotificationAppliesTo = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPNotificationAppliesTo"), ",", "."));
         wcpOAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId");
         wcpOAV14RecordAttDescription = cgiGet( sPrefix+"wcpOAV14RecordAttDescription");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WWPEntityName, wcpOAV6WWPEntityName) != 0 ) || ( AV7WWPNotificationAppliesTo != wcpOAV7WWPNotificationAppliesTo ) || ( StringUtil.StrCmp(AV20WWPSubscriptionEntityRecordId, wcpOAV20WWPSubscriptionEntityRecordId) != 0 ) || ( StringUtil.StrCmp(AV14RecordAttDescription, wcpOAV14RecordAttDescription) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WWPEntityName = AV6WWPEntityName;
         wcpOAV7WWPNotificationAppliesTo = AV7WWPNotificationAppliesTo;
         wcpOAV20WWPSubscriptionEntityRecordId = AV20WWPSubscriptionEntityRecordId;
         wcpOAV14RecordAttDescription = AV14RecordAttDescription;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WWPEntityName = cgiGet( sPrefix+"AV6WWPEntityName_CTRL");
         if ( StringUtil.Len( sCtrlAV6WWPEntityName) > 0 )
         {
            AV6WWPEntityName = cgiGet( sCtrlAV6WWPEntityName);
            AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
         }
         else
         {
            AV6WWPEntityName = cgiGet( sPrefix+"AV6WWPEntityName_PARM");
         }
         sCtrlAV7WWPNotificationAppliesTo = cgiGet( sPrefix+"AV7WWPNotificationAppliesTo_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPNotificationAppliesTo) > 0 )
         {
            AV7WWPNotificationAppliesTo = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7WWPNotificationAppliesTo), ",", "."));
            AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
         }
         else
         {
            AV7WWPNotificationAppliesTo = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7WWPNotificationAppliesTo_PARM"), ",", "."));
         }
         sCtrlAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"AV20WWPSubscriptionEntityRecordId_CTRL");
         if ( StringUtil.Len( sCtrlAV20WWPSubscriptionEntityRecordId) > 0 )
         {
            AV20WWPSubscriptionEntityRecordId = cgiGet( sCtrlAV20WWPSubscriptionEntityRecordId);
            AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
         }
         else
         {
            AV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"AV20WWPSubscriptionEntityRecordId_PARM");
         }
         sCtrlAV14RecordAttDescription = cgiGet( sPrefix+"AV14RecordAttDescription_CTRL");
         if ( StringUtil.Len( sCtrlAV14RecordAttDescription) > 0 )
         {
            AV14RecordAttDescription = cgiGet( sCtrlAV14RecordAttDescription);
            AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
         }
         else
         {
            AV14RecordAttDescription = cgiGet( sPrefix+"AV14RecordAttDescription_PARM");
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
         PA252( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS252( ) ;
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
         WS252( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPEntityName_PARM", AV6WWPEntityName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WWPEntityName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPEntityName_CTRL", StringUtil.RTrim( sCtrlAV6WWPEntityName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPNotificationAppliesTo_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationAppliesTo), 1, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPNotificationAppliesTo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPNotificationAppliesTo_CTRL", StringUtil.RTrim( sCtrlAV7WWPNotificationAppliesTo));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPSubscriptionEntityRecordId_PARM", AV20WWPSubscriptionEntityRecordId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20WWPSubscriptionEntityRecordId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPSubscriptionEntityRecordId_CTRL", StringUtil.RTrim( sCtrlAV20WWPSubscriptionEntityRecordId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14RecordAttDescription_PARM", AV14RecordAttDescription);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14RecordAttDescription)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14RecordAttDescription_CTRL", StringUtil.RTrim( sCtrlAV14RecordAttDescription));
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
         WE252( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815473935", true, true);
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
            context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscriptionspanel.js", "?202142815473936", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_idx;
         edtWWPNotificationDefinitionDescription_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCRIPTION_"+sGXsfl_9_idx;
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_fel_idx;
         edtWWPNotificationDefinitionDescription_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCRIPTION_"+sGXsfl_9_fel_idx;
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_fel_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         SubsflControlProps_92( ) ;
         WB250( ) ;
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
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,StringUtil.BoolToStr( AV12IncludeNotification),(string)"",(string)"Include Notification",(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(16, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavIncludenotification.Enabled!=0)&&(chkavIncludenotification.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,16);\"" : " ")});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionDescription_Internalname,(string)"Notification Definition Description",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionDescription_Internalname,(string)A25WWPNotificationDefinitionDescription,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0});
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
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,(string)"Notification Definition Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A14WWPNotificationDefinitionId), "ZZZZZZZZZ9"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationDefinitionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPNotificationDefinitionId_Visible,(short)0,(short)0,(string)"number",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)1,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"right",(bool)false,(string)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WWPSubscriptionId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22WWPSubscriptionId), "ZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavWwpsubscriptionid_Enabled!=0)&&(edtavWwpsubscriptionid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,29);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpsubscriptionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpsubscriptionid_Visible,(short)1,(short)0,(string)"number",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            send_integrity_lvl_hashes252( ) ;
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
         edtWWPNotificationDefinitionDescription_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCRIPTION";
         divTablesubscriptionitem_Internalname = sPrefix+"TABLESUBSCRIPTIONITEM";
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID";
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
         edtWWPNotificationDefinitionId_Jsonclick = "";
         chkavIncludenotification.Caption = "Include Notification";
         chkavIncludenotification.Visible = 1;
         chkavIncludenotification.Enabled = 1;
         subGrid_Class = "FreeStyleGrid";
         subGrid_Allowcollapsing = 0;
         subGrid_Backcolorstyle = 0;
         subGrid_Rows = 0;
         edtavWwpsubscriptionid_Visible = 1;
         edtWWPNotificationDefinitionId_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'edtWWPNotificationDefinitionId_Visible',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'sPrefix'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E14252',iparms:[{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV12IncludeNotification',fld:'vINCLUDENOTIFICATION',pic:''},{av:'AV22WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'FIRSTPAGE'","{handler:'E15252',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPNotificationDefinitionId_Visible',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("'FIRSTPAGE'",",oparms:[]}");
         setEventMetadata("'PREVIOUSPAGE'","{handler:'E16252',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPNotificationDefinitionId_Visible',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("'PREVIOUSPAGE'",",oparms:[]}");
         setEventMetadata("'NEXTPAGE'","{handler:'E17252',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPNotificationDefinitionId_Visible',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("'NEXTPAGE'",",oparms:[]}");
         setEventMetadata("'LASTPAGE'","{handler:'E18252',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'AV7WWPNotificationAppliesTo',fld:'vWWPNOTIFICATIONAPPLIESTO',pic:'9'},{av:'AV28Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPNotificationDefinitionId_Visible',ctrl:'WWPNOTIFICATIONDEFINITIONID',prop:'Visible'},{av:'edtavWwpsubscriptionid_Visible',ctrl:'vWWPSUBSCRIPTIONID',prop:'Visible'},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV31Udparg1',fld:'vUDPARG1',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'AV23WWPSubscriptionRoleIdCollection',fld:'vWWPSUBSCRIPTIONROLEIDCOLLECTION',pic:'',hsh:true},{av:'AV8WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A22WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A13WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'AV24WWPNotificationDefinitionId',fld:'vWWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("'LASTPAGE'",",oparms:[]}");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK","{handler:'E11252',iparms:[{av:'AV12IncludeNotification',fld:'vINCLUDENOTIFICATION',grid:9,pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_9',ctrl:'GRID',grid:9,prop:'GridRC'},{av:'AV22WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',grid:9,pic:'ZZZZZZZZZ9'},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',grid:9,pic:'ZZZZZZZZZ9'},{av:'AV20WWPSubscriptionEntityRecordId',fld:'vWWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'AV14RecordAttDescription',fld:'vRECORDATTDESCRIPTION',pic:''}]");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK",",oparms:[{av:'AV12IncludeNotification',fld:'vINCLUDENOTIFICATION',pic:''},{av:'AV22WWPSubscriptionId',fld:'vWWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'}]}");
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
         wcpOAV6WWPEntityName = "";
         wcpOAV20WWPSubscriptionEntityRecordId = "";
         wcpOAV14RecordAttDescription = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV28Pgmname = "";
         A1WWPUserExtendedId = "";
         AV31Udparg1 = "";
         A11WWPSubscriptionRoleId = "";
         AV23WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         A22WWPSubscriptionEntityRecordId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         A25WWPNotificationDefinitionDescription = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00252_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         H00252_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         H00252_A10WWPEntityId = new long[1] ;
         H00252_A14WWPNotificationDefinitionId = new long[1] ;
         H00252_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         H00253_AGRID_nRecordCount = new long[1] ;
         H00254_A12WWPEntityName = new string[] {""} ;
         H00254_A10WWPEntityId = new long[1] ;
         A12WWPEntityName = "";
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV9GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         H00255_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         H00255_A14WWPNotificationDefinitionId = new long[1] ;
         H00255_A11WWPSubscriptionRoleId = new string[] {""} ;
         H00255_n11WWPSubscriptionRoleId = new bool[] {false} ;
         H00255_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         H00255_A1WWPUserExtendedId = new string[] {""} ;
         H00255_n1WWPUserExtendedId = new bool[] {false} ;
         H00255_A13WWPSubscriptionId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WWPEntityName = "";
         sCtrlAV7WWPNotificationAppliesTo = "";
         sCtrlAV20WWPSubscriptionEntityRecordId = "";
         sCtrlAV14RecordAttDescription = "";
         subGrid_Linesclass = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscriptionspanel__default(),
            new Object[][] {
                new Object[] {
               H00252_A27WWPNotificationDefinitionAllowUserSubscription, H00252_A26WWPNotificationDefinitionAppliesTo, H00252_A10WWPEntityId, H00252_A14WWPNotificationDefinitionId, H00252_A25WWPNotificationDefinitionDescription
               }
               , new Object[] {
               H00253_AGRID_nRecordCount
               }
               , new Object[] {
               H00254_A12WWPEntityName, H00254_A10WWPEntityId
               }
               , new Object[] {
               H00255_A22WWPSubscriptionEntityRecordId, H00255_A14WWPNotificationDefinitionId, H00255_A11WWPSubscriptionRoleId, H00255_n11WWPSubscriptionRoleId, H00255_A23WWPSubscriptionSubscribed, H00255_A1WWPUserExtendedId, H00255_n1WWPUserExtendedId, H00255_A13WWPSubscriptionId
               }
            }
         );
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         /* GeneXus formulas. */
         AV28Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         context.Gx_err = 0;
      }

      private short AV7WWPNotificationAppliesTo ;
      private short wcpOAV7WWPNotificationAppliesTo ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
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
      private short A26WWPNotificationDefinitionAppliesTo ;
      private short subGrid_Backstyle ;
      private int edtWWPNotificationDefinitionId_Visible ;
      private int edtavWwpsubscriptionid_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int nGXsfl_9_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavWwpsubscriptionid_Enabled ;
      private long GRID_nFirstRecordOnPage ;
      private long AV5WWPEntityId ;
      private long AV8WWPNotificationId ;
      private long A13WWPSubscriptionId ;
      private long AV24WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private long AV22WWPSubscriptionId ;
      private long GRID_nCurrentRecord ;
      private long A10WWPEntityId ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtavWwpsubscriptionid_Internalname ;
      private string AV28Pgmname ;
      private string A1WWPUserExtendedId ;
      private string AV31Udparg1 ;
      private string A11WWPSubscriptionRoleId ;
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
      private string edtWWPNotificationDefinitionDescription_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string sCtrlAV6WWPEntityName ;
      private string sCtrlAV7WWPNotificationAppliesTo ;
      private string sCtrlAV20WWPSubscriptionEntityRecordId ;
      private string sCtrlAV14RecordAttDescription ;
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
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtavWwpsubscriptionid_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool n1WWPUserExtendedId ;
      private bool A23WWPSubscriptionSubscribed ;
      private bool n11WWPSubscriptionRoleId ;
      private bool wbLoad ;
      private bool AV12IncludeNotification ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool A27WWPNotificationDefinitionAllowUserSubscription ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean2 ;
      private string AV6WWPEntityName ;
      private string AV20WWPSubscriptionEntityRecordId ;
      private string AV14RecordAttDescription ;
      private string wcpOAV6WWPEntityName ;
      private string wcpOAV20WWPSubscriptionEntityRecordId ;
      private string wcpOAV14RecordAttDescription ;
      private string A22WWPSubscriptionEntityRecordId ;
      private string A25WWPNotificationDefinitionDescription ;
      private string A12WWPEntityName ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIncludenotification ;
      private IDataStoreProvider pr_default ;
      private bool[] H00252_A27WWPNotificationDefinitionAllowUserSubscription ;
      private short[] H00252_A26WWPNotificationDefinitionAppliesTo ;
      private long[] H00252_A10WWPEntityId ;
      private long[] H00252_A14WWPNotificationDefinitionId ;
      private string[] H00252_A25WWPNotificationDefinitionDescription ;
      private long[] H00253_AGRID_nRecordCount ;
      private string[] H00254_A12WWPEntityName ;
      private long[] H00254_A10WWPEntityId ;
      private string[] H00255_A22WWPSubscriptionEntityRecordId ;
      private long[] H00255_A14WWPNotificationDefinitionId ;
      private string[] H00255_A11WWPSubscriptionRoleId ;
      private bool[] H00255_n11WWPSubscriptionRoleId ;
      private bool[] H00255_A23WWPSubscriptionSubscribed ;
      private string[] H00255_A1WWPUserExtendedId ;
      private bool[] H00255_n1WWPUserExtendedId ;
      private long[] H00255_A13WWPSubscriptionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV9GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV17TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
   }

   public class wwp_subscriptionspanel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00255( IGxContext context ,
                                             string A11WWPSubscriptionRoleId ,
                                             GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ,
                                             string AV20WWPSubscriptionEntityRecordId ,
                                             string A22WWPSubscriptionEntityRecordId ,
                                             string A1WWPUserExtendedId ,
                                             string AV31Udparg1 ,
                                             bool A23WWPSubscriptionSubscribed ,
                                             long AV8WWPNotificationId ,
                                             long A14WWPNotificationDefinitionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT TOP 1 [WWPSubscriptionEntityRecordId], [WWPNotificationDefinitionId], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPUserExtendedId], [WWPSubscriptionId] FROM [WWP_Subscription]";
         AddWhere(sWhereString, "([WWPNotificationDefinitionId] = @AV8WWPNotificationId)");
         AddWhere(sWhereString, "(( [WWPUserExtendedId] = @AV31Udparg1 and [WWPSubscriptionSubscribed] = 1) or "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV23WWPSubscriptionRoleIdCollection, "[WWPSubscriptionRoleId] IN (", ")")+")");
         if ( StringUtil.StrCmp(AV20WWPSubscriptionEntityRecordId, "") != 0 )
         {
            AddWhere(sWhereString, "([WWPSubscriptionEntityRecordId] = @AV20WWPSubscriptionEntityRecordId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [WWPNotificationDefinitionId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H00255(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00252;
          prmH00252 = new Object[] {
          new Object[] {"@AV5WWPEntityId",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV7WWPNotificationAppliesTo",SqlDbType.SmallInt,1,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          };
          Object[] prmH00253;
          prmH00253 = new Object[] {
          new Object[] {"@AV5WWPEntityId",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV7WWPNotificationAppliesTo",SqlDbType.SmallInt,1,0}
          };
          Object[] prmH00254;
          prmH00254 = new Object[] {
          new Object[] {"@AV6WWPEntityName",SqlDbType.NVarChar,100,0}
          };
          Object[] prmH00255;
          prmH00255 = new Object[] {
          new Object[] {"@AV8WWPNotificationId",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV31Udparg1",SqlDbType.NChar,40,0} ,
          new Object[] {"@AV20WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0}
          };
          def= new CursorDef[] {
              new CursorDef("H00252", "SELECT [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionAppliesTo], [WWPEntityId], [WWPNotificationDefinitionId], [WWPNotificationDefinitionDescription] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV5WWPEntityId) AND ([WWPNotificationDefinitionAllowUserSubscription] = 1) AND ([WWPNotificationDefinitionAppliesTo] = @AV7WWPNotificationAppliesTo) ORDER BY [WWPEntityId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00252,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00253", "SELECT COUNT(*) FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV5WWPEntityId) AND ([WWPNotificationDefinitionAllowUserSubscription] = 1) AND ([WWPNotificationDefinitionAppliesTo] = @AV7WWPNotificationAppliesTo) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00253,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00254", "SELECT TOP 1 [WWPEntityName], [WWPEntityId] FROM [WWP_Entity] WHERE LOWER([WWPEntityName]) = LOWER(@AV6WWPEntityName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00254,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00255", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00255,1, GxCacheFrequency.OFF ,true,true )
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
                table[0][0] = rslt.getBool(1);
                table[1][0] = rslt.getShort(2);
                table[2][0] = rslt.getLong(3);
                table[3][0] = rslt.getLong(4);
                table[4][0] = rslt.getVarchar(5);
                return;
             case 1 :
                table[0][0] = rslt.getLong(1);
                return;
             case 2 :
                table[0][0] = rslt.getVarchar(1);
                table[1][0] = rslt.getLong(2);
                return;
             case 3 :
                table[0][0] = rslt.getVarchar(1);
                table[1][0] = rslt.getLong(2);
                table[2][0] = rslt.getString(3, 40);
                table[3][0] = rslt.wasNull(3);
                table[4][0] = rslt.getBool(4);
                table[5][0] = rslt.getString(5, 40);
                table[6][0] = rslt.wasNull(5);
                table[7][0] = rslt.getLong(6);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx;
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                stmt.SetParameter(4, (int)parms[3]);
                return;
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
             case 3 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[3]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[4]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (string)parms[5]);
                }
                return;
       }
    }

 }

}
