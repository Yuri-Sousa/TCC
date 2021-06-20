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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_visualizeallnotifications : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_visualizeallnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_visualizeallnotifications( IGxContext context )
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
               nRC_GXsfl_26 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_26"), "."));
               nGXsfl_26_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_26_idx"), "."));
               sGXsfl_26_idx = GetPar( "sGXsfl_26_idx");
               edtWWPNotificationId_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtWWPNotificationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Visible), 5, 0), !bGXsfl_26_Refreshing);
               edtWWPNotificationLink_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtWWPNotificationLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Visible), 5, 0), !bGXsfl_26_Refreshing);
               edtWWPNotificationMetadata_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0), !bGXsfl_26_Refreshing);
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
               AV22Pgmname = GetPar( "Pgmname");
               edtWWPNotificationId_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtWWPNotificationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Visible), 5, 0), !bGXsfl_26_Refreshing);
               edtWWPNotificationLink_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtWWPNotificationLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Visible), 5, 0), !bGXsfl_26_Refreshing);
               edtWWPNotificationMetadata_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0), !bGXsfl_26_Refreshing);
               AV15IsAuthorized_ManageSubscriptions = StringUtil.StrToBool( GetPar( "IsAuthorized_ManageSubscriptions"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
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
         PA242( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START242( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142918174698", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGESUBSCRIPTIONS", GetSecureSignedToken( "", AV15IsAuthorized_ManageSubscriptions, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_26", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_26), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONICON", A68WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONCREATED", context.localUtil.TToC( A37WWPNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "WWPNOTIFICATIONISREAD", A73WWPNotificationIsRead);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGESUBSCRIPTIONS", AV15IsAuthorized_ManageSubscriptions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGESUBSCRIPTIONS", GetSecureSignedToken( "", AV15IsAuthorized_ManageSubscriptions, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONLINK_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationLink_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONMETADATA_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE242( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT242( ) ;
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications" ;
      }

      public override string GetPgmdesc( )
      {
         return "Visualize all notifications" ;
      }

      protected void WB240( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, divTablemain_Width, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmarkallasread_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(26), 2, 0)+","+"null"+");", "Marcar tudo como lido", bttBtnmarkallasread_Jsonclick, 5, "Marcar tudo como lido", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOMARKALLASREAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmanagesubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(26), 2, 0)+","+"null"+");", "Administrar as minhas subscrições", bttBtnmanagesubscriptions_Jsonclick, 5, "Administrar as minhas subscrições", "", StyleString, ClassString, bttBtnmanagesubscriptions_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOMANAGESUBSCRIPTIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNonotifications_Internalname, "Você não recebeu nehuma notificação ainda", "", "", lblNonotifications_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleWWP", 0, "", lblNonotifications_Visible, 1, 0, 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"26\">") ;
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
               GridContainer.AddObjectProperty("CmpContext", "");
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
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", lblNotificationitemicon_Caption);
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
               GridColumn.AddObjectProperty("Value", A69WWPNotificationTitle);
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtWWPNotificationTitle_Class));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.TToC( AV18WWPNotificationCreated, 10, 8, 0, 3, "/", ":", " "));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationcreated_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", lblVisualize_Caption);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", lblMarkasread_Caption);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A70WWPNotificationShortDescription);
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A71WWPNotificationLink);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationLink_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A54WWPNotificationMetadata);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0, ".", "")));
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
         if ( wbEnd == 26 )
         {
            wbEnd = 0;
            nRC_GXsfl_26 = (int)(nGXsfl_26_idx-1);
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 26 )
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

      protected void START242( )
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
            Form.Meta.addItem("description", "Visualize all notifications", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP240( ) ;
      }

      protected void WS242( )
      {
         START242( ) ;
         EVT242( ) ;
      }

      protected void EVT242( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOMARKALLASREAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoMarkAllAsRead' */
                              E11242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMANAGESUBSCRIPTIONS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoManageSubscriptions' */
                              E12242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOMARKASREAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOMARKASREAD'") == 0 ) )
                           {
                              nGXsfl_26_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
                              SubsflControlProps_262( ) ;
                              A69WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
                              if ( context.localUtil.VCDateTime( cgiGet( edtavWwpnotificationcreated_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"WWPNotification Created"}), 1, "vWWPNOTIFICATIONCREATED");
                                 GX_FocusControl = edtavWwpnotificationcreated_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV18WWPNotificationCreated = (DateTime)(DateTime.MinValue);
                                 AssignAttri("", false, edtavWwpnotificationcreated_Internalname, context.localUtil.TToC( AV18WWPNotificationCreated, 8, 5, 0, 3, "/", ":", " "));
                              }
                              else
                              {
                                 AV18WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtavWwpnotificationcreated_Internalname), 0);
                                 AssignAttri("", false, edtavWwpnotificationcreated_Internalname, context.localUtil.TToC( AV18WWPNotificationCreated, 8, 5, 0, 3, "/", ":", " "));
                              }
                              A70WWPNotificationShortDescription = cgiGet( edtWWPNotificationShortDescription_Internalname);
                              A16WWPNotificationId = (long)(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ",", "."));
                              A71WWPNotificationLink = cgiGet( edtWWPNotificationLink_Internalname);
                              A54WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
                              n54WWPNotificationMetadata = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E14242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E15242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOMARKASREAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMarkAsRead' */
                                    E16242 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE242( )
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

      protected void PA242( )
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_262( ) ;
         while ( nGXsfl_26_idx <= nRC_GXsfl_26 )
         {
            sendrow_262( ) ;
            nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV22Pgmname ,
                                       bool AV15IsAuthorized_ManageSubscriptions )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E14242 ();
         GRID_nCurrentRecord = 0;
         RF242( ) ;
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
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_26_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF242( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV22Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         context.Gx_err = 0;
         edtavWwpnotificationcreated_Enabled = 0;
         AssignProp("", false, edtavWwpnotificationcreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationcreated_Enabled), 5, 0), !bGXsfl_26_Refreshing);
      }

      protected void RF242( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 26;
         /* Execute user event: Refresh */
         E14242 ();
         nGXsfl_26_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         bGXsfl_26_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_262( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H00242 */
            pr_default.execute(0, new Object[] {AV21Udparg1, GXPagingFrom2, GXPagingTo2});
            nGXsfl_26_idx = (int)(1+GRID_nFirstRecordOnPage);
            sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
            SubsflControlProps_262( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1WWPUserExtendedId = H00242_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = H00242_n1WWPUserExtendedId[0];
               A68WWPNotificationIcon = H00242_A68WWPNotificationIcon[0];
               A73WWPNotificationIsRead = H00242_A73WWPNotificationIsRead[0];
               A37WWPNotificationCreated = H00242_A37WWPNotificationCreated[0];
               A54WWPNotificationMetadata = H00242_A54WWPNotificationMetadata[0];
               n54WWPNotificationMetadata = H00242_n54WWPNotificationMetadata[0];
               A71WWPNotificationLink = H00242_A71WWPNotificationLink[0];
               A16WWPNotificationId = H00242_A16WWPNotificationId[0];
               A70WWPNotificationShortDescription = H00242_A70WWPNotificationShortDescription[0];
               A69WWPNotificationTitle = H00242_A69WWPNotificationTitle[0];
               E15242 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 26;
            WB240( ) ;
         }
         bGXsfl_26_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes242( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGESUBSCRIPTIONS", AV15IsAuthorized_ManageSubscriptions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGESUBSCRIPTIONS", GetSecureSignedToken( "", AV15IsAuthorized_ManageSubscriptions, context));
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
         AV21Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor H00243 */
         pr_default.execute(1, new Object[] {AV21Udparg1});
         GRID_nRecordCount = H00243_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
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
         if ( GRID_nEOF == 1 )
         {
            GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV22Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         context.Gx_err = 0;
         edtavWwpnotificationcreated_Enabled = 0;
         AssignProp("", false, edtavWwpnotificationcreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWwpnotificationcreated_Enabled), 5, 0), !bGXsfl_26_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP240( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13242 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_26 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_26"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
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
         E13242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13242( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablemain_Width = 700;
         AssignProp("", false, divTablemain_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablemain_Width), 9, 0), true);
         edtWWPNotificationId_Visible = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Visible), 5, 0), !bGXsfl_26_Refreshing);
         edtWWPNotificationLink_Visible = 0;
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Visible), 5, 0), !bGXsfl_26_Refreshing);
         edtWWPNotificationMetadata_Visible = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0), !bGXsfl_26_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Visualize all notifications";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
      }

      protected void E14242( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblNonotifications_Visible = 1;
         AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
         subGrid_Visible = 0;
         AssignProp("", false, "GridContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGrid_Visible), 5, 0), true);
         AV21Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /*  Sending Event outputs  */
      }

      private void E15242( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         lblNonotifications_Visible = 0;
         AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
         subGrid_Visible = 1;
         AssignProp("", false, "GridContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGrid_Visible), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A71WWPNotificationLink)) )
         {
            lblVisualize_Visible = 1;
         }
         else
         {
            lblVisualize_Visible = 0;
         }
         lblNotificationitemicon_Caption = StringUtil.Format( "<i class='%1 %2'></i>", "NotificationFontIcon", A68WWPNotificationIcon, "", "", "", "", "", "", "");
         AV18WWPNotificationCreated = A37WWPNotificationCreated;
         AssignAttri("", false, edtavWwpnotificationcreated_Internalname, context.localUtil.TToC( AV18WWPNotificationCreated, 8, 5, 0, 3, "/", ":", " "));
         if ( A73WWPNotificationIsRead )
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope DiscussionsSendIcon\"></i>";
            lblMarkasread_Tooltiptext = "Mark as unread";
            edtWWPNotificationTitle_Class = "SimpleCardAttributeTitleLight";
         }
         else
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>";
            lblMarkasread_Tooltiptext = "Mark as read";
            edtWWPNotificationTitle_Class = "SimpleCardAttributeTitle";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 26;
         }
         sendrow_262( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_26_Refreshing )
         {
            context.DoAjaxLoad(26, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E16242( )
      {
         /* 'DoMarkAsRead' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadunreadbyid( ref  A16WWPNotificationId) ;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_26_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
         /*  Sending Event outputs  */
      }

      protected void E11242( )
      {
         /* 'DoMarkAllAsRead' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setallnotificationsofloggeduserread( ) ;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_26_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         gxgrGrid_refresh( subGrid_Rows, AV22Pgmname, AV15IsAuthorized_ManageSubscriptions) ;
         /*  Sending Event outputs  */
      }

      protected void E12242( )
      {
         /* 'DoManageSubscriptions' Routine */
         returnInSub = false;
         if ( AV15IsAuthorized_ManageSubscriptions )
         {
            CallWebObject(formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV15IsAuthorized_ManageSubscriptions;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wwpsubscriptionssettings_Execute", out  GXt_boolean1) ;
         AV15IsAuthorized_ManageSubscriptions = GXt_boolean1;
         AssignAttri("", false, "AV15IsAuthorized_ManageSubscriptions", AV15IsAuthorized_ManageSubscriptions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGESUBSCRIPTIONS", GetSecureSignedToken( "", AV15IsAuthorized_ManageSubscriptions, context));
         if ( ! ( AV15IsAuthorized_ManageSubscriptions ) )
         {
            bttBtnmanagesubscriptions_Visible = 0;
            AssignProp("", false, bttBtnmanagesubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnmanagesubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Session.Get(AV22Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV22Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         else
         {
            AV11GridState.FromXml(AV13Session.Get(AV22Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV13Session.Get(AV22Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV22Pgmname+"GridState",  AV11GridState.ToXml(false, true, "WWPGridState", "RastreamentoTCC")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV22Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Notifications.Common.WWP_Notification";
         AV13Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "WWPTransactionContext", "RastreamentoTCC"));
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
         PA242( ) ;
         WS242( ) ;
         WE242( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918174765", true, true);
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
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_visualizeallnotifications.js", "?202142918174765", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_262( )
      {
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON_"+sGXsfl_26_idx;
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE_"+sGXsfl_26_idx;
         edtavWwpnotificationcreated_Internalname = "vWWPNOTIFICATIONCREATED_"+sGXsfl_26_idx;
         lblVisualize_Internalname = "VISUALIZE_"+sGXsfl_26_idx;
         lblMarkasread_Internalname = "MARKASREAD_"+sGXsfl_26_idx;
         edtWWPNotificationShortDescription_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTION_"+sGXsfl_26_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_26_idx;
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK_"+sGXsfl_26_idx;
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA_"+sGXsfl_26_idx;
      }

      protected void SubsflControlProps_fel_262( )
      {
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON_"+sGXsfl_26_fel_idx;
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE_"+sGXsfl_26_fel_idx;
         edtavWwpnotificationcreated_Internalname = "vWWPNOTIFICATIONCREATED_"+sGXsfl_26_fel_idx;
         lblVisualize_Internalname = "VISUALIZE_"+sGXsfl_26_fel_idx;
         lblMarkasread_Internalname = "MARKASREAD_"+sGXsfl_26_fel_idx;
         edtWWPNotificationShortDescription_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTION_"+sGXsfl_26_fel_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_26_fel_idx;
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK_"+sGXsfl_26_fel_idx;
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA_"+sGXsfl_26_fel_idx;
      }

      protected void sendrow_262( )
      {
         SubsflControlProps_262( ) ;
         WB240( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_26_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_26_idx) % (2))) == 0 )
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
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_26_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_26_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginTop",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablefscard_Internalname+"_"+sGXsfl_26_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"NotificationCardTable",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable1_Internalname+"_"+sGXsfl_26_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellPaddingTop5",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNotificationitemicon_Internalname,(string)lblNotificationitemicon_Caption,(string)"",(string)"",(string)lblNotificationitemicon_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecontent_Internalname+"_"+sGXsfl_26_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable2_Internalname+"_"+sGXsfl_26_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationTitle_Internalname,(string)"Notification Title",(string)"gx-form-item SimpleCardAttributeTitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            ClassString = edtWWPNotificationTitle_Class;
            StyleString = "";
            ClassString = edtWWPNotificationTitle_Class;
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationTitle_Internalname,(string)A69WWPNotificationTitle,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginLeft CellPaddingTop5",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationcreated_Internalname,(string)"WWPNotification Created",(string)"gx-form-item NotificationItemDatetimeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = " " + ((edtavWwpnotificationcreated_Enabled!=0)&&(edtavWwpnotificationcreated_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 46,'',false,'"+sGXsfl_26_idx+"',26)\"" : " ");
            ROClassString = "NotificationItemDatetime";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationcreated_Internalname,context.localUtil.TToC( AV18WWPNotificationCreated, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( AV18WWPNotificationCreated, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+((edtavWwpnotificationcreated_Enabled!=0)&&(edtavWwpnotificationcreated_Visible!=0) ? " onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,46);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpnotificationcreated_Jsonclick,(short)0,(string)"NotificationItemDatetime",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavWwpnotificationcreated_Enabled,(short)0,(string)"text",(string)"",(short)14,(string)"chr",(short)1,(string)"row",(short)14,(short)0,(short)0,(short)26,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblVisualize_Internalname,(string)"<i class=\"fas fa-search DiscussionsSendIcon\"></i>",(string)"",(string)"",(string)lblVisualize_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e17242_client"+"'",(string)"",(string)"TextBlock",(short)7,(string)"",(int)lblVisualize_Visible,(short)1,(short)0,(short)1});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginLeft",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblMarkasread_Internalname,(string)lblMarkasread_Caption,(string)"",(string)"",(string)lblMarkasread_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOMARKASREAD\\'."+sGXsfl_26_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)lblMarkasread_Tooltiptext,(short)1,(short)1,(short)0,(short)1});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationShortDescription_Internalname,(string)"Notification Short Description",(string)"col-sm-3 CardNotificationAttributeDescriptionLabel",(short)0,(bool)true,(string)""});
            /* Multiple line edit */
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationShortDescription_Internalname,(string)A70WWPNotificationShortDescription,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
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
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_26_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            sendrow_26230( ) ;
         }
      }

      protected void sendrow_26230( )
      {
         GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationId_Internalname,(string)"Notification Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16WWPNotificationId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A16WWPNotificationId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPNotificationId_Visible,(short)0,(short)0,(string)"number",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)26,(short)1,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"right",(bool)false,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationLink_Internalname,(string)"Notification Link",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationLink_Internalname,(string)A71WWPNotificationLink,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)A71WWPNotificationLink,(string)"_blank",(string)"",(string)"",(string)edtWWPNotificationLink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPNotificationLink_Visible,(short)0,(short)0,(string)"url",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)1000,(short)0,(short)0,(short)26,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"left",(bool)true,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationMetadata_Internalname,(string)"WWPNotification Metadata",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationMetadata_Internalname,(string)A54WWPNotificationMetadata,(string)"",(string)"",(short)0,(int)edtWWPNotificationMetadata_Visible,(short)0,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"2097152",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
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
         send_integrity_lvl_hashes242( ) ;
         /* End of Columns property logic. */
         GridContainer.AddRow(GridRow);
         nGXsfl_26_idx = ((subGrid_Islastpage==1)&&(nGXsfl_26_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_26_idx+1);
         sGXsfl_26_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_26_idx), 4, 0), 4, "0");
         SubsflControlProps_262( ) ;
         /* End function sendrow_262 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnmarkallasread_Internalname = "BTNMARKALLASREAD";
         bttBtnmanagesubscriptions_Internalname = "BTNMANAGESUBSCRIPTIONS";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         lblNonotifications_Internalname = "NONOTIFICATIONS";
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtavWwpnotificationcreated_Internalname = "vWWPNOTIFICATIONCREATED";
         lblVisualize_Internalname = "VISUALIZE";
         lblMarkasread_Internalname = "MARKASREAD";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtWWPNotificationShortDescription_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTION";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablefscard_Internalname = "TABLEFSCARD";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
         tblUnnamedtablecontentfsgrid_Internalname = "UNNAMEDTABLECONTENTFSGRID";
         divUnnamedtablefsgrid_Internalname = "UNNAMEDTABLEFSGRID";
         divTablemain_Internalname = "TABLEMAIN";
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
         edtWWPNotificationLink_Jsonclick = "";
         edtWWPNotificationId_Jsonclick = "";
         lblMarkasread_Tooltiptext = "";
         lblMarkasread_Caption = "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>";
         lblVisualize_Visible = 1;
         edtavWwpnotificationcreated_Jsonclick = "";
         edtavWwpnotificationcreated_Visible = 1;
         lblNotificationitemicon_Caption = "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>";
         subGrid_Class = "FreeStyleGrid";
         subGrid_Allowcollapsing = 0;
         lblMarkasread_Caption = "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>";
         lblVisualize_Caption = "<i class=\"fas fa-search DiscussionsSendIcon\"></i>";
         edtavWwpnotificationcreated_Enabled = 1;
         edtWWPNotificationTitle_Class = "SimpleCardAttributeTitle";
         lblNotificationitemicon_Caption = "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>";
         subGrid_Backcolorstyle = 0;
         subGrid_Visible = 1;
         lblNonotifications_Visible = 1;
         bttBtnmanagesubscriptions_Visible = 1;
         divTablemain_Width = 0;
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Opções";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Visualize all notifications";
         subGrid_Rows = 50;
         edtWWPNotificationMetadata_Visible = 1;
         edtWWPNotificationLink_Visible = 1;
         edtWWPNotificationId_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E15242',iparms:[{av:'A71WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:''},{av:'A68WWPNotificationIcon',fld:'WWPNOTIFICATIONICON',pic:''},{av:'A37WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A73WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'lblVisualize_Visible',ctrl:'VISUALIZE',prop:'Visible'},{av:'lblNotificationitemicon_Caption',ctrl:'NOTIFICATIONITEMICON',prop:'Caption'},{av:'AV18WWPNotificationCreated',fld:'vWWPNOTIFICATIONCREATED',pic:'99/99/99 99:99'},{av:'lblMarkasread_Caption',ctrl:'MARKASREAD',prop:'Caption'},{av:'lblMarkasread_Tooltiptext',ctrl:'MARKASREAD',prop:'Tooltiptext'},{av:'edtWWPNotificationTitle_Class',ctrl:'WWPNOTIFICATIONTITLE',prop:'Class'}]}");
         setEventMetadata("'DOVISUALIZE'","{handler:'E17242',iparms:[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("'DOVISUALIZE'",",oparms:[{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'DOMARKASREAD'","{handler:'E16242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'A16WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("'DOMARKASREAD'",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("'DOMARKALLASREAD'","{handler:'E11242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true}]");
         setEventMetadata("'DOMARKALLASREAD'",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("'DOMANAGESUBSCRIPTIONS'","{handler:'E12242',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true}]");
         setEventMetadata("'DOMANAGESUBSCRIPTIONS'",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'AV15IsAuthorized_ManageSubscriptions',fld:'vISAUTHORIZED_MANAGESUBSCRIPTIONS',pic:'',hsh:true},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("VALIDV_WWPNOTIFICATIONCREATED","{handler:'Validv_Wwpnotificationcreated',iparms:[]");
         setEventMetadata("VALIDV_WWPNOTIFICATIONCREATED",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpnotificationmetadata',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV22Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A68WWPNotificationIcon = "";
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         bttBtnmarkallasread_Jsonclick = "";
         bttBtnmanagesubscriptions_Jsonclick = "";
         lblNonotifications_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         A69WWPNotificationTitle = "";
         AV18WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A70WWPNotificationShortDescription = "";
         A71WWPNotificationLink = "";
         A54WWPNotificationMetadata = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         scmdbuf = "";
         AV21Udparg1 = "";
         H00242_A1WWPUserExtendedId = new string[] {""} ;
         H00242_n1WWPUserExtendedId = new bool[] {false} ;
         H00242_A68WWPNotificationIcon = new string[] {""} ;
         H00242_A73WWPNotificationIsRead = new bool[] {false} ;
         H00242_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         H00242_A54WWPNotificationMetadata = new string[] {""} ;
         H00242_n54WWPNotificationMetadata = new bool[] {false} ;
         H00242_A71WWPNotificationLink = new string[] {""} ;
         H00242_A16WWPNotificationId = new long[1] ;
         H00242_A70WWPNotificationShortDescription = new string[] {""} ;
         H00242_A69WWPNotificationTitle = new string[] {""} ;
         A1WWPUserExtendedId = "";
         H00243_AGRID_nRecordCount = new long[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV13Session = context.GetSession();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         lblNotificationitemicon_Jsonclick = "";
         ROClassString = "";
         lblVisualize_Jsonclick = "";
         lblMarkasread_Jsonclick = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_visualizeallnotifications__default(),
            new Object[][] {
                new Object[] {
               H00242_A1WWPUserExtendedId, H00242_n1WWPUserExtendedId, H00242_A68WWPNotificationIcon, H00242_A73WWPNotificationIsRead, H00242_A37WWPNotificationCreated, H00242_A54WWPNotificationMetadata, H00242_n54WWPNotificationMetadata, H00242_A71WWPNotificationLink, H00242_A16WWPNotificationId, H00242_A70WWPNotificationShortDescription,
               H00242_A69WWPNotificationTitle
               }
               , new Object[] {
               H00243_AGRID_nRecordCount
               }
            }
         );
         AV22Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         /* GeneXus formulas. */
         AV22Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         context.Gx_err = 0;
         edtavWwpnotificationcreated_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private int edtWWPNotificationId_Visible ;
      private int edtWWPNotificationLink_Visible ;
      private int edtWWPNotificationMetadata_Visible ;
      private int nRC_GXsfl_26 ;
      private int nGXsfl_26_idx=1 ;
      private int subGrid_Rows ;
      private int divTablemain_Width ;
      private int bttBtnmanagesubscriptions_Visible ;
      private int lblNonotifications_Visible ;
      private int subGrid_Visible ;
      private int edtavWwpnotificationcreated_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int lblVisualize_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavWwpnotificationcreated_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long A16WWPNotificationId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_26_idx="0001" ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationLink_Internalname ;
      private string edtWWPNotificationMetadata_Internalname ;
      private string AV22Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string TempTags ;
      private string bttBtnmarkallasread_Internalname ;
      private string bttBtnmarkallasread_Jsonclick ;
      private string bttBtnmanagesubscriptions_Internalname ;
      private string bttBtnmanagesubscriptions_Jsonclick ;
      private string lblNonotifications_Internalname ;
      private string lblNonotifications_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Header ;
      private string lblNotificationitemicon_Caption ;
      private string edtWWPNotificationTitle_Class ;
      private string lblVisualize_Caption ;
      private string lblMarkasread_Caption ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtWWPNotificationTitle_Internalname ;
      private string edtavWwpnotificationcreated_Internalname ;
      private string edtWWPNotificationShortDescription_Internalname ;
      private string GXCCtl ;
      private string scmdbuf ;
      private string AV21Udparg1 ;
      private string A1WWPUserExtendedId ;
      private string lblMarkasread_Tooltiptext ;
      private string lblNotificationitemicon_Internalname ;
      private string lblVisualize_Internalname ;
      private string lblMarkasread_Internalname ;
      private string sGXsfl_26_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string divTablefscard_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblNotificationitemicon_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string ROClassString ;
      private string edtavWwpnotificationcreated_Jsonclick ;
      private string lblVisualize_Jsonclick ;
      private string lblMarkasread_Jsonclick ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationLink_Jsonclick ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime AV18WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_26_Refreshing=false ;
      private bool AV15IsAuthorized_ManageSubscriptions ;
      private bool A73WWPNotificationIsRead ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n54WWPNotificationMetadata ;
      private bool gxdyncontrolsrefreshing ;
      private bool n1WWPUserExtendedId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string A54WWPNotificationMetadata ;
      private string A68WWPNotificationIcon ;
      private string A69WWPNotificationTitle ;
      private string A70WWPNotificationShortDescription ;
      private string A71WWPNotificationLink ;
      private IGxSession AV13Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00242_A1WWPUserExtendedId ;
      private bool[] H00242_n1WWPUserExtendedId ;
      private string[] H00242_A68WWPNotificationIcon ;
      private bool[] H00242_A73WWPNotificationIsRead ;
      private DateTime[] H00242_A37WWPNotificationCreated ;
      private string[] H00242_A54WWPNotificationMetadata ;
      private bool[] H00242_n54WWPNotificationMetadata ;
      private string[] H00242_A71WWPNotificationLink ;
      private long[] H00242_A16WWPNotificationId ;
      private string[] H00242_A70WWPNotificationShortDescription ;
      private string[] H00242_A69WWPNotificationTitle ;
      private long[] H00243_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
   }

   public class wwp_visualizeallnotifications__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00242;
          prmH00242 = new Object[] {
          new Object[] {"@AV21Udparg1",SqlDbType.NChar,40,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          };
          Object[] prmH00243;
          prmH00243 = new Object[] {
          new Object[] {"@AV21Udparg1",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("H00242", "SELECT [WWPUserExtendedId], [WWPNotificationIcon], [WWPNotificationIsRead], [WWPNotificationCreated], [WWPNotificationMetadata], [WWPNotificationLink], [WWPNotificationId], [WWPNotificationShortDescription], [WWPNotificationTitle] FROM [WWP_Notification] WHERE [WWPUserExtendedId] = @AV21Udparg1 ORDER BY [WWPNotificationCreated] DESC  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00242,51, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00243", "SELECT COUNT(*) FROM [WWP_Notification] WHERE [WWPUserExtendedId] = @AV21Udparg1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00243,1, GxCacheFrequency.OFF ,true,false )
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
                table[1][0] = rslt.wasNull(1);
                table[2][0] = rslt.getVarchar(2);
                table[3][0] = rslt.getBool(3);
                table[4][0] = rslt.getGXDateTime(4, true);
                table[5][0] = rslt.getLongVarchar(5);
                table[6][0] = rslt.wasNull(5);
                table[7][0] = rslt.getVarchar(6);
                table[8][0] = rslt.getLong(7);
                table[9][0] = rslt.getVarchar(8);
                table[10][0] = rslt.getVarchar(9);
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
                stmt.SetParameter(1, (string)parms[0]);
                stmt.SetParameter(2, (int)parms[1]);
                stmt.SetParameter(3, (int)parms[2]);
                return;
             case 1 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
       }
    }

 }

}
