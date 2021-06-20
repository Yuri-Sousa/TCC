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
   public class wwp_subscriptionssettings : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_subscriptionssettings( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_subscriptionssettings( IGxContext context )
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
         chkavMail = new GXCheckbox();
         chkavSms = new GXCheckbox();
         chkavDesktop = new GXCheckbox();
         chkavSd = new GXCheckbox();
         chkavNotifshowonlysubscribedevents = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_43 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."));
               nGXsfl_43_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."));
               sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
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
               AV41Pgmname = GetPar( "Pgmname");
               AV17NotifShowOnlySubscribedEvents = StringUtil.StrToBool( GetPar( "NotifShowOnlySubscribedEvents"));
               AV7FilterFullText = GetPar( "FilterFullText");
               A12WWPEntityName = GetPar( "WWPEntityName");
               A10WWPEntityId = (long)(NumberUtil.Val( GetPar( "WWPEntityId"), "."));
               A27WWPNotificationDefinitionAllowUserSubscription = StringUtil.StrToBool( GetPar( "WWPNotificationDefinitionAllowUserSubscription"));
               A1WWPUserExtendedId = GetPar( "WWPUserExtendedId");
               n1WWPUserExtendedId = false;
               AV44Udparg2 = GetPar( "Udparg2");
               A23WWPSubscriptionSubscribed = StringUtil.StrToBool( GetPar( "WWPSubscriptionSubscribed"));
               A11WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
               n11WWPSubscriptionRoleId = false;
               A14WWPNotificationDefinitionId = (long)(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."));
               AV15Mail = StringUtil.StrToBool( GetPar( "Mail"));
               AV22Sms = StringUtil.StrToBool( GetPar( "Sms"));
               AV5Desktop = StringUtil.StrToBool( GetPar( "Desktop"));
               AV19SD = StringUtil.StrToBool( GetPar( "SD"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV41Pgmname, AV17NotifShowOnlySubscribedEvents, AV7FilterFullText, A12WWPEntityName, A10WWPEntityId, A27WWPNotificationDefinitionAllowUserSubscription, A1WWPUserExtendedId, AV44Udparg2, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, A14WWPNotificationDefinitionId, AV15Mail, AV22Sms, AV5Desktop, AV19SD) ;
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
            return "wwpsubscriptionssettings_Execute" ;
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

      public override short ExecuteStartEvent( )
      {
         PA202( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START202( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202142815571597", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG2", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Udparg2, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV36GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPENTITYNAME", A12WWPEntityName);
         GxWebStd.gx_hidden_field( context, "WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION", A27WWPNotificationDefinitionAllowUserSubscription);
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDID", StringUtil.RTrim( A1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "vUDPARG2", StringUtil.RTrim( AV44Udparg2));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG2", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Udparg2, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "WWPSUBSCRIPTIONSUBSCRIBED", A23WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, "WWPSUBSCRIPTIONROLEID", StringUtil.RTrim( A11WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Width", StringUtil.RTrim( Dvpanel_unnamedtable2_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Cls", StringUtil.RTrim( Dvpanel_unnamedtable2_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Title", StringUtil.RTrim( Dvpanel_unnamedtable2_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable2_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
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
         if ( ! ( WebComp_Grid_dwc == null ) )
         {
            WebComp_Grid_dwc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE202( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT202( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings" ;
      }

      public override string GetPgmdesc( )
      {
         return "Manage my Subscriptions" ;
      }

      protected void WB200( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMail_Internalname, "Mail", "gx-form-item AttributeCheckNoBorderCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_43_idx + "',0)\"";
            ClassString = "AttributeCheckNoBorderCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMail_Internalname, StringUtil.BoolToStr( AV15Mail), "", "Mail", 1, chkavMail.Enabled, "true", "Email", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,14);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSms_Internalname, "Sms", "gx-form-item AttributeCheckNoBorderCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_43_idx + "',0)\"";
            ClassString = "AttributeCheckNoBorderCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSms_Internalname, StringUtil.BoolToStr( AV22Sms), "", "Sms", 1, chkavSms.Enabled, "true", "SMS", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,17);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDesktop_Internalname, "Desktop", "gx-form-item AttributeCheckNoBorderCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_43_idx + "',0)\"";
            ClassString = "AttributeCheckNoBorderCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDesktop_Internalname, StringUtil.BoolToStr( AV5Desktop), "", "Desktop", 1, chkavDesktop.Enabled, "true", "Desktop notifications", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,20);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSd_Internalname, "SD", "gx-form-item AttributeCheckNoBorderCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_43_idx + "',0)\"";
            ClassString = "AttributeCheckNoBorderCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSd_Internalname, StringUtil.BoolToStr( AV19SD), "", "SD", 1, chkavSd.Enabled, "true", "Mobile notifications", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,23);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable2.SetProperty("Width", Dvpanel_unnamedtable2_Width);
            ucDvpanel_unnamedtable2.SetProperty("AutoWidth", Dvpanel_unnamedtable2_Autowidth);
            ucDvpanel_unnamedtable2.SetProperty("AutoHeight", Dvpanel_unnamedtable2_Autoheight);
            ucDvpanel_unnamedtable2.SetProperty("Cls", Dvpanel_unnamedtable2_Cls);
            ucDvpanel_unnamedtable2.SetProperty("Title", Dvpanel_unnamedtable2_Title);
            ucDvpanel_unnamedtable2.SetProperty("Collapsible", Dvpanel_unnamedtable2_Collapsible);
            ucDvpanel_unnamedtable2.SetProperty("Collapsed", Dvpanel_unnamedtable2_Collapsed);
            ucDvpanel_unnamedtable2.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable2_Showcollapseicon);
            ucDvpanel_unnamedtable2.SetProperty("IconPosition", Dvpanel_unnamedtable2_Iconposition);
            ucDvpanel_unnamedtable2.SetProperty("AutoScroll", Dvpanel_unnamedtable2_Autoscroll);
            ucDvpanel_unnamedtable2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable2_Internalname, "DVPANEL_UNNAMEDTABLE2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE2Container"+"UnnamedTable2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNotifshowonlysubscribedevents_Internalname, "Notif Show Only Subscribed Events", "gx-form-item AttributeCheckNoBorderCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_43_idx + "',0)\"";
            ClassString = "AttributeCheckNoBorderCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNotifshowonlysubscribedevents_Internalname, StringUtil.BoolToStr( AV17NotifShowOnlySubscribedEvents), "", "Notif Show Only Subscribed Events", 1, chkavNotifshowonlysubscribedevents.Enabled, "true", "Show only my subscribed events", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,34);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV7FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV7FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "WWPFullTextFilter", "left", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_SubscriptionsSettings.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridNoTitleCell CellMarginTop HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Entity") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", AV30WWPEntityName);
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpentityname_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29WWPEntityId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpentityid_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV6DetailWebComponent));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0, ".", "")));
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
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV8GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV9GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV36GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_grid_dwc_Internalname, 1, 0, "px", 0, "px", divCell_grid_dwc_Class, "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0052"+"", StringUtil.RTrim( WebComp_Grid_dwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0052"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGrid_dwc), StringUtil.Lower( WebComp_Grid_dwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
                  }
                  WebComp_Grid_dwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGrid_dwc), StringUtil.Lower( WebComp_Grid_dwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 43 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START202( )
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
            Form.Meta.addItem("description", "Manage my Subscriptions", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP200( ) ;
      }

      protected void WS202( )
      {
         START202( ) ;
         EVT202( ) ;
      }

      protected void EVT202( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMAIL.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSMS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSD.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E15202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDESKTOP.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTIFSHOWONLYSUBSCRIBEDEVENTS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17202 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_43_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              AV30WWPEntityName = cgiGet( edtavWwpentityname_Internalname);
                              AssignAttri("", false, edtavWwpentityname_Internalname, AV30WWPEntityName);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpentityid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpentityid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPENTITYID");
                                 GX_FocusControl = edtavWwpentityid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV29WWPEntityId = 0;
                                 AssignAttri("", false, edtavWwpentityid_Internalname, StringUtil.LTrimStr( (decimal)(AV29WWPEntityId), 10, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vWWPENTITYID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV29WWPEntityId), "ZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV29WWPEntityId = (long)(context.localUtil.CToN( cgiGet( edtavWwpentityid_Internalname), ",", "."));
                                 AssignAttri("", false, edtavWwpentityid_Internalname, StringUtil.LTrimStr( (decimal)(AV29WWPEntityId), 10, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vWWPENTITYID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV29WWPEntityId), "ZZZZZZZZZ9"), context));
                              }
                              AV6DetailWebComponent = cgiGet( edtavDetailwebcomponent_Internalname);
                              AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV6DetailWebComponent);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18202 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E19202 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E20202 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 52 )
                        {
                           OldGrid_dwc = cgiGet( "W0052");
                           if ( ( StringUtil.Len( OldGrid_dwc) == 0 ) || ( StringUtil.StrCmp(OldGrid_dwc, WebComp_Grid_dwc_Component) != 0 ) )
                           {
                              WebComp_Grid_dwc = getWebComponent(GetType(), "GeneXus.Programs", OldGrid_dwc, new Object[] {context} );
                              WebComp_Grid_dwc.ComponentInit();
                              WebComp_Grid_dwc.Name = "OldGrid_dwc";
                              WebComp_Grid_dwc_Component = OldGrid_dwc;
                           }
                           if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
                           {
                              WebComp_Grid_dwc.componentprocess("W0052", "", sEvt);
                           }
                           WebComp_Grid_dwc_Component = OldGrid_dwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE202( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA202( )
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
               GX_FocusControl = chkavMail_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV41Pgmname ,
                                       bool AV17NotifShowOnlySubscribedEvents ,
                                       string AV7FilterFullText ,
                                       string A12WWPEntityName ,
                                       long A10WWPEntityId ,
                                       bool A27WWPNotificationDefinitionAllowUserSubscription ,
                                       string A1WWPUserExtendedId ,
                                       string AV44Udparg2 ,
                                       bool A23WWPSubscriptionSubscribed ,
                                       string A11WWPSubscriptionRoleId ,
                                       long A14WWPNotificationDefinitionId ,
                                       bool AV15Mail ,
                                       bool AV22Sms ,
                                       bool AV5Desktop ,
                                       bool AV19SD )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E19202 ();
         GRID_nCurrentRecord = 0;
         RF202( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPENTITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV29WWPEntityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29WWPEntityId), 10, 0, ".", "")));
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
         AV15Mail = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Mail));
         AssignAttri("", false, "AV15Mail", AV15Mail);
         AV22Sms = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Sms));
         AssignAttri("", false, "AV22Sms", AV22Sms);
         AV5Desktop = StringUtil.StrToBool( StringUtil.BoolToStr( AV5Desktop));
         AssignAttri("", false, "AV5Desktop", AV5Desktop);
         AV19SD = StringUtil.StrToBool( StringUtil.BoolToStr( AV19SD));
         AssignAttri("", false, "AV19SD", AV19SD);
         AV17NotifShowOnlySubscribedEvents = StringUtil.StrToBool( StringUtil.BoolToStr( AV17NotifShowOnlySubscribedEvents));
         AssignAttri("", false, "AV17NotifShowOnlySubscribedEvents", AV17NotifShowOnlySubscribedEvents);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF202( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV41Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         context.Gx_err = 0;
         edtavWwpentityname_Enabled = 0;
         AssignProp("", false, edtavWwpentityname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpentityname_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavWwpentityid_Enabled = 0;
         AssignProp("", false, edtavWwpentityid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpentityid_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDetailwebcomponent_Enabled = 0;
         AssignProp("", false, edtavDetailwebcomponent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void RF202( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E19202 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
               {
                  WebComp_Grid_dwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_432( ) ;
            E20202 ();
            if ( ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_43_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E20202 ();
            }
            wbEnd = 43;
            WB200( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes202( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG2", StringUtil.RTrim( AV44Udparg2));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG2", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Udparg2, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPENTITYID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV29WWPEntityId), "ZZZZZZZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41Pgmname, AV17NotifShowOnlySubscribedEvents, AV7FilterFullText, A12WWPEntityName, A10WWPEntityId, A27WWPNotificationDefinitionAllowUserSubscription, A1WWPUserExtendedId, AV44Udparg2, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, A14WWPNotificationDefinitionId, AV15Mail, AV22Sms, AV5Desktop, AV19SD) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41Pgmname, AV17NotifShowOnlySubscribedEvents, AV7FilterFullText, A12WWPEntityName, A10WWPEntityId, A27WWPNotificationDefinitionAllowUserSubscription, A1WWPUserExtendedId, AV44Udparg2, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, A14WWPNotificationDefinitionId, AV15Mail, AV22Sms, AV5Desktop, AV19SD) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41Pgmname, AV17NotifShowOnlySubscribedEvents, AV7FilterFullText, A12WWPEntityName, A10WWPEntityId, A27WWPNotificationDefinitionAllowUserSubscription, A1WWPUserExtendedId, AV44Udparg2, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, A14WWPNotificationDefinitionId, AV15Mail, AV22Sms, AV5Desktop, AV19SD) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41Pgmname, AV17NotifShowOnlySubscribedEvents, AV7FilterFullText, A12WWPEntityName, A10WWPEntityId, A27WWPNotificationDefinitionAllowUserSubscription, A1WWPUserExtendedId, AV44Udparg2, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, A14WWPNotificationDefinitionId, AV15Mail, AV22Sms, AV5Desktop, AV19SD) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV41Pgmname, AV17NotifShowOnlySubscribedEvents, AV7FilterFullText, A12WWPEntityName, A10WWPEntityId, A27WWPNotificationDefinitionAllowUserSubscription, A1WWPUserExtendedId, AV44Udparg2, A23WWPSubscriptionSubscribed, A11WWPSubscriptionRoleId, A14WWPNotificationDefinitionId, AV15Mail, AV22Sms, AV5Desktop, AV19SD) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV41Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         context.Gx_err = 0;
         edtavWwpentityname_Enabled = 0;
         AssignProp("", false, edtavWwpentityname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpentityname_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavWwpentityid_Enabled = 0;
         AssignProp("", false, edtavWwpentityid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpentityid_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDetailwebcomponent_Enabled = 0;
         AssignProp("", false, edtavDetailwebcomponent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP200( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18202 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ",", "."));
            AV8GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."));
            AV9GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."));
            AV36GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Dvpanel_unnamedtable2_Width = cgiGet( "DVPANEL_UNNAMEDTABLE2_Width");
            Dvpanel_unnamedtable2_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Autowidth"));
            Dvpanel_unnamedtable2_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Autoheight"));
            Dvpanel_unnamedtable2_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE2_Cls");
            Dvpanel_unnamedtable2_Title = cgiGet( "DVPANEL_UNNAMEDTABLE2_Title");
            Dvpanel_unnamedtable2_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Collapsible"));
            Dvpanel_unnamedtable2_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Collapsed"));
            Dvpanel_unnamedtable2_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Showcollapseicon"));
            Dvpanel_unnamedtable2_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE2_Iconposition");
            Dvpanel_unnamedtable2_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Autoscroll"));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            /* Read variables values. */
            AV15Mail = StringUtil.StrToBool( cgiGet( chkavMail_Internalname));
            AssignAttri("", false, "AV15Mail", AV15Mail);
            AV22Sms = StringUtil.StrToBool( cgiGet( chkavSms_Internalname));
            AssignAttri("", false, "AV22Sms", AV22Sms);
            AV5Desktop = StringUtil.StrToBool( cgiGet( chkavDesktop_Internalname));
            AssignAttri("", false, "AV5Desktop", AV5Desktop);
            AV19SD = StringUtil.StrToBool( cgiGet( chkavSd_Internalname));
            AssignAttri("", false, "AV19SD", AV19SD);
            AV17NotifShowOnlySubscribedEvents = StringUtil.StrToBool( cgiGet( chkavNotifshowonlysubscribedevents_Internalname));
            AssignAttri("", false, "AV17NotifShowOnlySubscribedEvents", AV17NotifShowOnlySubscribedEvents);
            AV7FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
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
         E18202 ();
         if (returnInSub) return;
      }

      protected void E18202( )
      {
         /* Start Routine */
         returnInSub = false;
         divCell_grid_dwc_Class = "Invisible WCD_"+StringUtil.Upper( subGrid_Internalname);
         AssignProp("", false, divCell_grid_dwc_Internalname, "Class", divCell_grid_dwc_Class, true);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Form.Caption = "Manage my Subscriptions";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV40Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor H00202 */
         pr_default.execute(0, new Object[] {AV40Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1WWPUserExtendedId = H00202_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = H00202_n1WWPUserExtendedId[0];
            A6WWPUserExtendedSMSNotif = H00202_A6WWPUserExtendedSMSNotif[0];
            A5WWPUserExtendedEmaiNotif = H00202_A5WWPUserExtendedEmaiNotif[0];
            A8WWPUserExtendedDesktopNotif = H00202_A8WWPUserExtendedDesktopNotif[0];
            A7WWPUserExtendedMobileNotif = H00202_A7WWPUserExtendedMobileNotif[0];
            AV22Sms = A6WWPUserExtendedSMSNotif;
            AssignAttri("", false, "AV22Sms", AV22Sms);
            AV15Mail = A5WWPUserExtendedEmaiNotif;
            AssignAttri("", false, "AV15Mail", AV15Mail);
            AV5Desktop = A8WWPUserExtendedDesktopNotif;
            AssignAttri("", false, "AV5Desktop", AV5Desktop);
            AV19SD = A7WWPUserExtendedMobileNotif;
            AssignAttri("", false, "AV19SD", AV19SD);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void E19202( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV27WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         AV8GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV8GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV8GridCurrentPage), 10, 0));
         GXt_char1 = AV36GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV41Pgmname, out  GXt_char1) ;
         AV36GridAppliedFilters = GXt_char1;
         AssignAttri("", false, "AV36GridAppliedFilters", AV36GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E11202( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV18PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV18PageToGo) ;
         }
      }

      protected void E12202( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E20202( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV10GridRecordCount = 0;
         GXt_objcol_char2 = AV35WWPSubscriptionRoleIdCollection;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserroles(context ).execute( out  GXt_objcol_char2) ;
         AV35WWPSubscriptionRoleIdCollection = GXt_objcol_char2;
         /* Using cursor H00204 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A10WWPEntityId = H00204_A10WWPEntityId[0];
            A12WWPEntityName = H00204_A12WWPEntityName[0];
            A40000GXC1 = H00204_A40000GXC1[0];
            n40000GXC1 = H00204_n40000GXC1[0];
            A40000GXC1 = H00204_A40000GXC1[0];
            n40000GXC1 = H00204_n40000GXC1[0];
            AV6DetailWebComponent = "<i class=\"fas fa-angle-right ArrowIcon\"></i>";
            AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV6DetailWebComponent);
            AV30WWPEntityName = A12WWPEntityName;
            AssignAttri("", false, edtavWwpentityname_Internalname, AV30WWPEntityName);
            AV29WWPEntityId = A10WWPEntityId;
            AssignAttri("", false, edtavWwpentityid_Internalname, StringUtil.LTrimStr( (decimal)(AV29WWPEntityId), 10, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vWWPENTITYID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV29WWPEntityId), "ZZZZZZZZZ9"), context));
            AV31EntityHasItemsToShow = false;
            AV16NotificationsForEntityCount = (short)(A40000GXC1);
            if ( ( AV16NotificationsForEntityCount > 0 ) && ! AV17NotifShowOnlySubscribedEvents )
            {
               AV31EntityHasItemsToShow = true;
            }
            else
            {
               AV44Udparg2 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
               pr_default.dynParam(2, new Object[]{ new Object[]{
                                                    A11WWPSubscriptionRoleId ,
                                                    AV35WWPSubscriptionRoleIdCollection ,
                                                    A10WWPEntityId ,
                                                    A27WWPNotificationDefinitionAllowUserSubscription ,
                                                    A1WWPUserExtendedId ,
                                                    AV44Udparg2 ,
                                                    A23WWPSubscriptionSubscribed } ,
                                                    new int[]{
                                                    TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor H00205 */
               pr_default.execute(2, new Object[] {A10WWPEntityId, AV44Udparg2});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A11WWPSubscriptionRoleId = H00205_A11WWPSubscriptionRoleId[0];
                  n11WWPSubscriptionRoleId = H00205_n11WWPSubscriptionRoleId[0];
                  A23WWPSubscriptionSubscribed = H00205_A23WWPSubscriptionSubscribed[0];
                  A1WWPUserExtendedId = H00205_A1WWPUserExtendedId[0];
                  n1WWPUserExtendedId = H00205_n1WWPUserExtendedId[0];
                  A27WWPNotificationDefinitionAllowUserSubscription = H00205_A27WWPNotificationDefinitionAllowUserSubscription[0];
                  A14WWPNotificationDefinitionId = H00205_A14WWPNotificationDefinitionId[0];
                  A27WWPNotificationDefinitionAllowUserSubscription = H00205_A27WWPNotificationDefinitionAllowUserSubscription[0];
                  AV31EntityHasItemsToShow = true;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A11WWPSubscriptionRoleId)) )
                  {
                     GXt_int3 = 0;
                     new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed(context ).execute(  A14WWPNotificationDefinitionId, ref  GXt_int3, ref  AV31EntityHasItemsToShow) ;
                  }
                  if ( AV31EntityHasItemsToShow )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
            if ( AV31EntityHasItemsToShow )
            {
               AV10GridRecordCount = (short)(AV10GridRecordCount+1);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 43;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_432( ) ;
                  GRID_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
                  if ( ( subGrid_Islastpage == 1 ) && ( ((int)((GRID_nCurrentRecord) % (subGrid_fnc_Recordsperpage( )))) == 0 ) )
                  {
                     GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
                  }
               }
               if ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) )
               {
                  GRID_nEOF = 0;
                  GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               }
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
               {
                  context.DoAjaxLoad(43, GridRow);
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV9GridPageCount = (long)(AV10GridRecordCount/ (decimal)(subGrid_Rows)+((((int)((AV10GridRecordCount) % (subGrid_Rows)))>0) ? 1 : 0));
         AssignAttri("", false, "AV9GridPageCount", StringUtil.LTrimStr( (decimal)(AV9GridPageCount), 10, 0));
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV41Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV41Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV41Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "NOTIFSHOWONLYSUBSCRIBEDEVENTS") == 0 )
            {
               AV17NotifShowOnlySubscribedEvents = BooleanUtil.Val( AV12GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV17NotifShowOnlySubscribedEvents", AV17NotifShowOnlySubscribedEvents);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV7FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV41Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "NOTIFSHOWONLYSUBSCRIBEDEVENTS",  "",  !(false==AV17NotifShowOnlySubscribedEvents),  0,  StringUtil.Trim( StringUtil.BoolToStr( AV17NotifShowOnlySubscribedEvents)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV7FilterFullText)),  0,  AV7FilterFullText,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV41Pgmname+"GridState",  AV11GridState.ToXml(false, true, "WWPGridState", "RastreamentoTCC")) ;
      }

      protected void E13202( )
      {
         /* Mail_Click Routine */
         returnInSub = false;
         AV34WWPUserExtended.Load(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ));
         AV34WWPUserExtended.gxTpr_Wwpuserextendedemainotif = AV15Mail;
         AV34WWPUserExtended.Save();
         if ( AV34WWPUserExtended.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscriptionssettings",pr_default);
         }
      }

      protected void E14202( )
      {
         /* Sms_Click Routine */
         returnInSub = false;
         AV34WWPUserExtended.Load(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ));
         AV34WWPUserExtended.gxTpr_Wwpuserextendedsmsnotif = AV22Sms;
         AV34WWPUserExtended.Save();
         if ( AV34WWPUserExtended.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscriptionssettings",pr_default);
         }
      }

      protected void E15202( )
      {
         /* Sd_Click Routine */
         returnInSub = false;
         AV34WWPUserExtended.Load(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ));
         AV34WWPUserExtended.gxTpr_Wwpuserextendedmobilenotif = AV19SD;
         AV34WWPUserExtended.Save();
         if ( AV34WWPUserExtended.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscriptionssettings",pr_default);
         }
      }

      protected void E16202( )
      {
         /* Desktop_Click Routine */
         returnInSub = false;
         AV34WWPUserExtended.Load(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ));
         AV34WWPUserExtended.gxTpr_Wwpuserextendeddesktopnotif = AV5Desktop;
         AV34WWPUserExtended.Save();
         if ( AV34WWPUserExtended.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscriptionssettings",pr_default);
         }
      }

      protected void E17202( )
      {
         /* Notifshowonlysubscribedevents_Click Routine */
         returnInSub = false;
         context.DoAjaxRefreshCmp("W0052"+"");
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA202( ) ;
         WS202( ) ;
         WE202( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Grid_dwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
            {
               WebComp_Grid_dwc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815571749", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscriptionssettings.js", "?202142815571749", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtavWwpentityname_Internalname = "vWWPENTITYNAME_"+sGXsfl_43_idx;
         edtavWwpentityid_Internalname = "vWWPENTITYID_"+sGXsfl_43_idx;
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtavWwpentityname_Internalname = "vWWPENTITYNAME_"+sGXsfl_43_fel_idx;
         edtavWwpentityid_Internalname = "vWWPENTITYID_"+sGXsfl_43_fel_idx;
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         SubsflControlProps_432( ) ;
         WB200( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavWwpentityname_Enabled!=0)&&(edtavWwpentityname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 44,'',false,'"+sGXsfl_43_idx+"',43)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpentityname_Internalname,(string)AV30WWPEntityName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavWwpentityname_Enabled!=0)&&(edtavWwpentityname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,44);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpentityname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwpentityname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavWwpentityid_Enabled!=0)&&(edtavWwpentityid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 45,'',false,'"+sGXsfl_43_idx+"',43)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpentityid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29WWPEntityId), 10, 0, ",", "")),((edtavWwpentityid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29WWPEntityId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV29WWPEntityId), "ZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavWwpentityid_Enabled!=0)&&(edtavWwpentityid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpentityid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWwpentityid_Enabled,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDetailwebcomponent_Enabled!=0)&&(edtavDetailwebcomponent_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 46,'',false,'"+sGXsfl_43_idx+"',43)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetailwebcomponent_Internalname,StringUtil.RTrim( AV6DetailWebComponent),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetailwebcomponent_Enabled!=0)&&(edtavDetailwebcomponent_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,46);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e21202_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetailwebcomponent_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn WCD_ActionColumn",(string)"",(short)-1,(int)edtavDetailwebcomponent_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes202( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         chkavMail.Name = "vMAIL";
         chkavMail.WebTags = "";
         chkavMail.Caption = "Email";
         AssignProp("", false, chkavMail_Internalname, "TitleCaption", chkavMail.Caption, true);
         chkavMail.CheckedValue = "false";
         AV15Mail = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Mail));
         AssignAttri("", false, "AV15Mail", AV15Mail);
         chkavSms.Name = "vSMS";
         chkavSms.WebTags = "";
         chkavSms.Caption = "SMS";
         AssignProp("", false, chkavSms_Internalname, "TitleCaption", chkavSms.Caption, true);
         chkavSms.CheckedValue = "false";
         AV22Sms = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Sms));
         AssignAttri("", false, "AV22Sms", AV22Sms);
         chkavDesktop.Name = "vDESKTOP";
         chkavDesktop.WebTags = "";
         chkavDesktop.Caption = "Desktop notifications";
         AssignProp("", false, chkavDesktop_Internalname, "TitleCaption", chkavDesktop.Caption, true);
         chkavDesktop.CheckedValue = "false";
         AV5Desktop = StringUtil.StrToBool( StringUtil.BoolToStr( AV5Desktop));
         AssignAttri("", false, "AV5Desktop", AV5Desktop);
         chkavSd.Name = "vSD";
         chkavSd.WebTags = "";
         chkavSd.Caption = "Mobile notifications";
         AssignProp("", false, chkavSd_Internalname, "TitleCaption", chkavSd.Caption, true);
         chkavSd.CheckedValue = "false";
         AV19SD = StringUtil.StrToBool( StringUtil.BoolToStr( AV19SD));
         AssignAttri("", false, "AV19SD", AV19SD);
         chkavNotifshowonlysubscribedevents.Name = "vNOTIFSHOWONLYSUBSCRIBEDEVENTS";
         chkavNotifshowonlysubscribedevents.WebTags = "";
         chkavNotifshowonlysubscribedevents.Caption = "Show only my subscribed events";
         AssignProp("", false, chkavNotifshowonlysubscribedevents_Internalname, "TitleCaption", chkavNotifshowonlysubscribedevents.Caption, true);
         chkavNotifshowonlysubscribedevents.CheckedValue = "false";
         AV17NotifShowOnlySubscribedEvents = StringUtil.StrToBool( StringUtil.BoolToStr( AV17NotifShowOnlySubscribedEvents));
         AssignAttri("", false, "AV17NotifShowOnlySubscribedEvents", AV17NotifShowOnlySubscribedEvents);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavMail_Internalname = "vMAIL";
         chkavSms_Internalname = "vSMS";
         chkavDesktop_Internalname = "vDESKTOP";
         chkavSd_Internalname = "vSD";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         chkavNotifshowonlysubscribedevents_Internalname = "vNOTIFSHOWONLYSUBSCRIBEDEVENTS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavWwpentityname_Internalname = "vWWPENTITYNAME";
         edtavWwpentityid_Internalname = "vWWPENTITYID";
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divCell_grid_dwc_Internalname = "CELL_GRID_DWC";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         Dvpanel_unnamedtable2_Internalname = "DVPANEL_UNNAMEDTABLE2";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavNotifshowonlysubscribedevents.Caption = "Notif Show Only Subscribed Events";
         chkavSd.Caption = "SD";
         chkavDesktop.Caption = "Desktop";
         chkavSms.Caption = "Sms";
         chkavMail.Caption = "Mail";
         edtavDetailwebcomponent_Jsonclick = "";
         edtavDetailwebcomponent_Visible = -1;
         edtavWwpentityid_Jsonclick = "";
         edtavWwpentityid_Visible = 0;
         edtavWwpentityname_Jsonclick = "";
         edtavWwpentityname_Visible = -1;
         divCell_grid_dwc_Class = "col-xs-12";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDetailwebcomponent_Enabled = 1;
         edtavWwpentityid_Enabled = 1;
         edtavWwpentityname_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         chkavNotifshowonlysubscribedevents.Enabled = 1;
         chkavSd.Enabled = 1;
         chkavDesktop.Enabled = 1;
         chkavSms.Enabled = 1;
         chkavMail.Enabled = 1;
         Dvpanel_unnamedtable2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Iconposition = "Right";
         Dvpanel_unnamedtable2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Title = "";
         Dvpanel_unnamedtable2_Cls = "PanelNoHeader";
         Dvpanel_unnamedtable2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Width = "100%";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = "Receive notifications by";
         Dvpanel_unnamedtable1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Manage my Subscriptions";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV8GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV36GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11202',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12202',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV41Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV7FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E20202',iparms:[{av:'A12WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A10WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A27WWPNotificationDefinitionAllowUserSubscription',fld:'WWPNOTIFICATIONDEFINITIONALLOWUSERSUBSCRIPTION',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'AV44Udparg2',fld:'vUDPARG2',pic:'',hsh:true},{av:'A23WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''},{av:'A11WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A14WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV6DetailWebComponent',fld:'vDETAILWEBCOMPONENT',pic:''},{av:'AV30WWPEntityName',fld:'vWWPENTITYNAME',pic:''},{av:'AV29WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9',hsh:true},{av:'A40000GXC1',fld:'GXC1',pic:'999999999'},{av:'AV9GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK","{handler:'E21202',iparms:[{av:'AV29WWPEntityId',fld:'vWWPENTITYID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK",",oparms:[{ctrl:'GRID_DWC'},{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("VMAIL.CLICK","{handler:'E13202',iparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("VMAIL.CLICK",",oparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("VSMS.CLICK","{handler:'E14202',iparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("VSMS.CLICK",",oparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("VSD.CLICK","{handler:'E15202',iparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("VSD.CLICK",",oparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("VDESKTOP.CLICK","{handler:'E16202',iparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("VDESKTOP.CLICK",",oparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("VNOTIFSHOWONLYSUBSCRIBEDEVENTS.CLICK","{handler:'E17202',iparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("VNOTIFSHOWONLYSUBSCRIBEDEVENTS.CLICK",",oparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Detailwebcomponent',iparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV15Mail',fld:'vMAIL',pic:''},{av:'AV22Sms',fld:'vSMS',pic:''},{av:'AV5Desktop',fld:'vDESKTOP',pic:''},{av:'AV19SD',fld:'vSD',pic:''},{av:'AV17NotifShowOnlySubscribedEvents',fld:'vNOTIFSHOWONLYSUBSCRIBEDEVENTS',pic:''}]}");
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
         Gridpaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV41Pgmname = "";
         AV7FilterFullText = "";
         A12WWPEntityName = "";
         A1WWPUserExtendedId = "";
         AV44Udparg2 = "";
         A11WWPSubscriptionRoleId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV36GridAppliedFilters = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_unnamedtable1 = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_unnamedtable2 = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV30WWPEntityName = "";
         AV6DetailWebComponent = "";
         ucGridpaginationbar = new GXUserControl();
         WebComp_Grid_dwc_Component = "";
         OldGrid_dwc = "";
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV40Udparg1 = "";
         scmdbuf = "";
         H00202_A1WWPUserExtendedId = new string[] {""} ;
         H00202_n1WWPUserExtendedId = new bool[] {false} ;
         H00202_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         H00202_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         H00202_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         H00202_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         AV27WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char1 = "";
         AV35WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         GXt_objcol_char2 = new GxSimpleCollection<string>();
         H00204_A10WWPEntityId = new long[1] ;
         H00204_A12WWPEntityName = new string[] {""} ;
         H00204_A40000GXC1 = new int[1] ;
         H00204_n40000GXC1 = new bool[] {false} ;
         H00205_A13WWPSubscriptionId = new long[1] ;
         H00205_A10WWPEntityId = new long[1] ;
         H00205_A11WWPSubscriptionRoleId = new string[] {""} ;
         H00205_n11WWPSubscriptionRoleId = new bool[] {false} ;
         H00205_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         H00205_A1WWPUserExtendedId = new string[] {""} ;
         H00205_n1WWPUserExtendedId = new bool[] {false} ;
         H00205_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         H00205_A14WWPNotificationDefinitionId = new long[1] ;
         GridRow = new GXWebRow();
         AV21Session = context.GetSession();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscriptionssettings__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscriptionssettings__default(),
            new Object[][] {
                new Object[] {
               H00202_A1WWPUserExtendedId, H00202_A6WWPUserExtendedSMSNotif, H00202_A5WWPUserExtendedEmaiNotif, H00202_A8WWPUserExtendedDesktopNotif, H00202_A7WWPUserExtendedMobileNotif
               }
               , new Object[] {
               H00204_A10WWPEntityId, H00204_A12WWPEntityName, H00204_A40000GXC1, H00204_n40000GXC1
               }
               , new Object[] {
               H00205_A13WWPSubscriptionId, H00205_A10WWPEntityId, H00205_A11WWPSubscriptionRoleId, H00205_n11WWPSubscriptionRoleId, H00205_A23WWPSubscriptionSubscribed, H00205_A1WWPUserExtendedId, H00205_n1WWPUserExtendedId, H00205_A27WWPNotificationDefinitionAllowUserSubscription, H00205_A14WWPNotificationDefinitionId
               }
            }
         );
         WebComp_Grid_dwc = new GeneXus.Http.GXNullWebComponent();
         AV41Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         /* GeneXus formulas. */
         AV41Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         context.Gx_err = 0;
         edtavWwpentityname_Enabled = 0;
         edtavWwpentityid_Enabled = 0;
         edtavDetailwebcomponent_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV10GridRecordCount ;
      private short AV16NotificationsForEntityCount ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavWwpentityname_Enabled ;
      private int edtavWwpentityid_Enabled ;
      private int edtavDetailwebcomponent_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int subGrid_Recordcount ;
      private int AV18PageToGo ;
      private int A40000GXC1 ;
      private int AV45GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavWwpentityname_Visible ;
      private int edtavWwpentityid_Visible ;
      private int edtavDetailwebcomponent_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long A10WWPEntityId ;
      private long A14WWPNotificationDefinitionId ;
      private long AV8GridCurrentPage ;
      private long AV9GridPageCount ;
      private long AV29WWPEntityId ;
      private long GRID_nCurrentRecord ;
      private long GXt_int3 ;
      private string Gridpaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV41Pgmname ;
      private string A1WWPUserExtendedId ;
      private string AV44Udparg2 ;
      private string A11WWPSubscriptionRoleId ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Dvpanel_unnamedtable2_Width ;
      private string Dvpanel_unnamedtable2_Cls ;
      private string Dvpanel_unnamedtable2_Title ;
      private string Dvpanel_unnamedtable2_Iconposition ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string chkavMail_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string chkavSms_Internalname ;
      private string chkavDesktop_Internalname ;
      private string chkavSd_Internalname ;
      private string Dvpanel_unnamedtable2_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divTableheader_Internalname ;
      private string chkavNotifshowonlysubscribedevents_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string AV6DetailWebComponent ;
      private string Gridpaginationbar_Internalname ;
      private string divCell_grid_dwc_Internalname ;
      private string divCell_grid_dwc_Class ;
      private string WebComp_Grid_dwc_Component ;
      private string OldGrid_dwc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavWwpentityname_Internalname ;
      private string edtavWwpentityid_Internalname ;
      private string edtavDetailwebcomponent_Internalname ;
      private string AV40Udparg1 ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string ROClassString ;
      private string edtavWwpentityname_Jsonclick ;
      private string edtavWwpentityid_Jsonclick ;
      private string edtavDetailwebcomponent_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17NotifShowOnlySubscribedEvents ;
      private bool A27WWPNotificationDefinitionAllowUserSubscription ;
      private bool n1WWPUserExtendedId ;
      private bool A23WWPSubscriptionSubscribed ;
      private bool n11WWPSubscriptionRoleId ;
      private bool AV15Mail ;
      private bool AV22Sms ;
      private bool AV5Desktop ;
      private bool AV19SD ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Dvpanel_unnamedtable2_Autowidth ;
      private bool Dvpanel_unnamedtable2_Autoheight ;
      private bool Dvpanel_unnamedtable2_Collapsible ;
      private bool Dvpanel_unnamedtable2_Collapsed ;
      private bool Dvpanel_unnamedtable2_Showcollapseicon ;
      private bool Dvpanel_unnamedtable2_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A6WWPUserExtendedSMSNotif ;
      private bool A5WWPUserExtendedEmaiNotif ;
      private bool A8WWPUserExtendedDesktopNotif ;
      private bool A7WWPUserExtendedMobileNotif ;
      private bool gx_refresh_fired ;
      private bool n40000GXC1 ;
      private bool AV31EntityHasItemsToShow ;
      private string AV7FilterFullText ;
      private string A12WWPEntityName ;
      private string AV36GridAppliedFilters ;
      private string AV30WWPEntityName ;
      private IGxSession AV21Session ;
      private GXWebComponent WebComp_Grid_dwc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucDvpanel_unnamedtable2 ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavMail ;
      private GXCheckbox chkavSms ;
      private GXCheckbox chkavDesktop ;
      private GXCheckbox chkavSd ;
      private GXCheckbox chkavNotifshowonlysubscribedevents ;
      private IDataStoreProvider pr_default ;
      private string[] H00202_A1WWPUserExtendedId ;
      private bool[] H00202_n1WWPUserExtendedId ;
      private bool[] H00202_A6WWPUserExtendedSMSNotif ;
      private bool[] H00202_A5WWPUserExtendedEmaiNotif ;
      private bool[] H00202_A8WWPUserExtendedDesktopNotif ;
      private bool[] H00202_A7WWPUserExtendedMobileNotif ;
      private long[] H00204_A10WWPEntityId ;
      private string[] H00204_A12WWPEntityName ;
      private int[] H00204_A40000GXC1 ;
      private bool[] H00204_n40000GXC1 ;
      private long[] H00205_A13WWPSubscriptionId ;
      private long[] H00205_A10WWPEntityId ;
      private string[] H00205_A11WWPSubscriptionRoleId ;
      private bool[] H00205_n11WWPSubscriptionRoleId ;
      private bool[] H00205_A23WWPSubscriptionSubscribed ;
      private string[] H00205_A1WWPUserExtendedId ;
      private bool[] H00205_n1WWPUserExtendedId ;
      private bool[] H00205_A27WWPNotificationDefinitionAllowUserSubscription ;
      private long[] H00205_A14WWPNotificationDefinitionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV35WWPSubscriptionRoleIdCollection ;
      private GxSimpleCollection<string> GXt_objcol_char2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV27WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV34WWPUserExtended ;
   }

   public class wwp_subscriptionssettings__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscriptionssettings__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H00205( IGxContext context ,
                                           string A11WWPSubscriptionRoleId ,
                                           GxSimpleCollection<string> AV35WWPSubscriptionRoleIdCollection ,
                                           long A10WWPEntityId ,
                                           bool A27WWPNotificationDefinitionAllowUserSubscription ,
                                           string A1WWPUserExtendedId ,
                                           string AV44Udparg2 ,
                                           bool A23WWPSubscriptionSubscribed )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int4 = new short[2];
       Object[] GXv_Object5 = new Object[2];
       scmdbuf = "SELECT T1.[WWPSubscriptionId], T2.[WWPEntityId], T1.[WWPSubscriptionRoleId], T1.[WWPSubscriptionSubscribed], T1.[WWPUserExtendedId], T2.[WWPNotificationDefinitionAllowUserSubscription], T1.[WWPNotificationDefinitionId] FROM ([WWP_Subscription] T1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = T1.[WWPNotificationDefinitionId])";
       AddWhere(sWhereString, "(T2.[WWPEntityId] = @WWPEntityId)");
       AddWhere(sWhereString, "(T2.[WWPNotificationDefinitionAllowUserSubscription] = 1)");
       AddWhere(sWhereString, "(( T1.[WWPUserExtendedId] = @AV44Udparg2 and T1.[WWPSubscriptionSubscribed] = 1) or "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV35WWPSubscriptionRoleIdCollection, "T1.[WWPSubscriptionRoleId] IN (", ")")+")");
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY T1.[WWPSubscriptionId]";
       GXv_Object5[0] = scmdbuf;
       GXv_Object5[1] = GXv_int4;
       return GXv_Object5 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 2 :
                   return conditional_H00205(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] );
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH00202;
        prmH00202 = new Object[] {
        new Object[] {"@AV40Udparg1",SqlDbType.NChar,40,0}
        };
        Object[] prmH00204;
        prmH00204 = new Object[] {
        };
        Object[] prmH00205;
        prmH00205 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV44Udparg2",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("H00202", "SELECT [WWPUserExtendedId], [WWPUserExtendedSMSNotif], [WWPUserExtendedEmaiNotif], [WWPUserExtendedDesktopNotif], [WWPUserExtendedMobileNotif] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @AV40Udparg1 ORDER BY [WWPUserExtendedId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00202,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("H00204", "SELECT T1.[WWPEntityId], T1.[WWPEntityName], COALESCE( T2.[GXC1], 0) AS GXC1 FROM ([WWP_Entity] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [WWPEntityId] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionAppliesTo] <> 2 and [WWPNotificationDefinitionAllowUserSubscription] = 1 GROUP BY [WWPEntityId] ) T2 ON T2.[WWPEntityId] = T1.[WWPEntityId]) ORDER BY T1.[WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00204,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00205", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00205,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getBool(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getInt(3);
              table[3][0] = rslt.wasNull(3);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.wasNull(3);
              table[4][0] = rslt.getBool(4);
              table[5][0] = rslt.getString(5, 40);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getBool(6);
              table[8][0] = rslt.getLong(7);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 2 :
              sIdx = 0;
              if ( (short)parms[0] == 0 )
              {
                 sIdx = (short)(sIdx+1);
                 stmt.SetParameter(sIdx, (long)parms[2]);
              }
              if ( (short)parms[1] == 0 )
              {
                 sIdx = (short)(sIdx+1);
                 stmt.SetParameter(sIdx, (string)parms[3]);
              }
              return;
     }
  }

}

}
