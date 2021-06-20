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
   public class gamrepositoryentry : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamrepositoryentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamrepositoryentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref int aP1_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV17Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV17Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavAllowoauthaccess = new GXCheckbox();
         chkavCanregisterusers = new GXCheckbox();
         chkavGiveanonymoussession = new GXCheckbox();
         chkavUpdateconnectionfile = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17Id = (int)(NumberUtil.Val( GetPar( "Id"), "."));
                  AssignAttri("", false, "AV17Id", StringUtil.LTrimStr( (decimal)(AV17Id), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17Id), "ZZZZZZZZ9"), context));
               }
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
            return "gamrepositoryentry_Execute" ;
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
         PA192( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START192( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142815521187", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamrepositoryentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV17Id,9,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17Id), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Width", StringUtil.RTrim( Dvpanel_conn_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Autowidth", StringUtil.BoolToStr( Dvpanel_conn_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Autoheight", StringUtil.BoolToStr( Dvpanel_conn_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Cls", StringUtil.RTrim( Dvpanel_conn_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Title", StringUtil.RTrim( Dvpanel_conn_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Collapsible", StringUtil.BoolToStr( Dvpanel_conn_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Collapsed", StringUtil.BoolToStr( Dvpanel_conn_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_conn_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Iconposition", StringUtil.RTrim( Dvpanel_conn_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CONN_Autoscroll", StringUtil.BoolToStr( Dvpanel_conn_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Width", StringUtil.RTrim( Dvpanel_admin_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Autowidth", StringUtil.BoolToStr( Dvpanel_admin_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Autoheight", StringUtil.BoolToStr( Dvpanel_admin_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Cls", StringUtil.RTrim( Dvpanel_admin_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Title", StringUtil.RTrim( Dvpanel_admin_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Collapsible", StringUtil.BoolToStr( Dvpanel_admin_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Collapsed", StringUtil.BoolToStr( Dvpanel_admin_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_admin_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Iconposition", StringUtil.RTrim( Dvpanel_admin_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_ADMIN_Autoscroll", StringUtil.BoolToStr( Dvpanel_admin_Autoscroll));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE192( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT192( ) ;
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
         return formatLink("gamrepositoryentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV17Id,9,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMRepositoryEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Repositório" ;
      }

      protected void WB190( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "Guid", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV16GUID), StringUtil.RTrim( context.localUtil.Format( AV16GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavGuid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV19Name), StringUtil.RTrim( context.localUtil.Format( AV19Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNamespace_Internalname, "Namespace", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNamespace_Internalname, StringUtil.RTrim( AV20Namespace), StringUtil.RTrim( context.localUtil.Format( AV20Namespace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNamespace_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNamespace_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDescription_Internalname, "Descrição", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDescription_Internalname, StringUtil.RTrim( AV11Description), StringUtil.RTrim( context.localUtil.Format( AV11Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDescription_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavAllowoauthaccess_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAllowoauthaccess_Internalname, StringUtil.BoolToStr( AV7AllowOauthAccess), "", "", 1, chkavAllowoauthaccess.Enabled, "true", "Permitir o acesso oauth", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(40, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,40);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavCanregisterusers_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCanregisterusers_Internalname, StringUtil.BoolToStr( AV8CanRegisterUsers), "", "", 1, chkavCanregisterusers.Enabled, "true", "Você pode registrar usuários?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavGiveanonymoussession_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavGiveanonymoussession_Internalname, StringUtil.BoolToStr( AV15GiveAnonymousSession), "", "", 1, chkavGiveanonymoussession.Enabled, "true", "Dar sessão anônima?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDvpanel_conn_cell_Internalname, 1, 0, "px", 0, "px", divDvpanel_conn_cell_Class, "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_conn.SetProperty("Width", Dvpanel_conn_Width);
            ucDvpanel_conn.SetProperty("AutoWidth", Dvpanel_conn_Autowidth);
            ucDvpanel_conn.SetProperty("AutoHeight", Dvpanel_conn_Autoheight);
            ucDvpanel_conn.SetProperty("Cls", Dvpanel_conn_Cls);
            ucDvpanel_conn.SetProperty("Title", Dvpanel_conn_Title);
            ucDvpanel_conn.SetProperty("Collapsible", Dvpanel_conn_Collapsible);
            ucDvpanel_conn.SetProperty("Collapsed", Dvpanel_conn_Collapsed);
            ucDvpanel_conn.SetProperty("ShowCollapseIcon", Dvpanel_conn_Showcollapseicon);
            ucDvpanel_conn.SetProperty("IconPosition", Dvpanel_conn_Iconposition);
            ucDvpanel_conn.SetProperty("AutoScroll", Dvpanel_conn_Autoscroll);
            ucDvpanel_conn.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_conn_Internalname, "DVPANEL_CONNContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CONNContainer"+"Conn"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divConn_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavConnectionusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionusername_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConnectionusername_Internalname, StringUtil.RTrim( AV9ConnectionUserName), StringUtil.RTrim( context.localUtil.Format( AV9ConnectionUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConnectionusername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavConnectionusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMConnectionUser", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavConnectionuserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionuserpassword_Internalname, "Senha", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConnectionuserpassword_Internalname, StringUtil.RTrim( AV10ConnectionUserPassword), StringUtil.RTrim( context.localUtil.Format( AV10ConnectionUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConnectionuserpassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavConnectionuserpassword_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, edtavConnectionuserpassword_Ispassword, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavConfconnectionuserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfconnectionuserpassword_Internalname, "Conf. senha", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfconnectionuserpassword_Internalname, StringUtil.RTrim( AV24ConfConnectionUserPassword), StringUtil.RTrim( context.localUtil.Format( AV24ConfConnectionUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfconnectionuserpassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavConfconnectionuserpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 254, edtavConfconnectionuserpassword_Ispassword, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divDvpanel_admin_cell_Internalname, 1, 0, "px", 0, "px", divDvpanel_admin_cell_Class, "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_admin.SetProperty("Width", Dvpanel_admin_Width);
            ucDvpanel_admin.SetProperty("AutoWidth", Dvpanel_admin_Autowidth);
            ucDvpanel_admin.SetProperty("AutoHeight", Dvpanel_admin_Autoheight);
            ucDvpanel_admin.SetProperty("Cls", Dvpanel_admin_Cls);
            ucDvpanel_admin.SetProperty("Title", Dvpanel_admin_Title);
            ucDvpanel_admin.SetProperty("Collapsible", Dvpanel_admin_Collapsible);
            ucDvpanel_admin.SetProperty("Collapsed", Dvpanel_admin_Collapsed);
            ucDvpanel_admin.SetProperty("ShowCollapseIcon", Dvpanel_admin_Showcollapseicon);
            ucDvpanel_admin.SetProperty("IconPosition", Dvpanel_admin_Iconposition);
            ucDvpanel_admin.SetProperty("AutoScroll", Dvpanel_admin_Autoscroll);
            ucDvpanel_admin.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_admin_Internalname, "DVPANEL_ADMINContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_ADMINContainer"+"Admin"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdmin_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAdministratorusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratorusername_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdministratorusername_Internalname, StringUtil.RTrim( AV5AdministratorUserName), StringUtil.RTrim( context.localUtil.Format( AV5AdministratorUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdministratorusername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAdministratorusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMConnectionUser", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAdministratoruserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratoruserpassword_Internalname, "Senha", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdministratoruserpassword_Internalname, StringUtil.RTrim( AV6AdministratorUserPassword), StringUtil.RTrim( context.localUtil.Format( AV6AdministratorUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdministratoruserpassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAdministratoruserpassword_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, edtavAdministratoruserpassword_Ispassword, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavConfadministratoruserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfadministratoruserpassword_Internalname, "Conf. senha", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfadministratoruserpassword_Internalname, StringUtil.RTrim( AV25ConfAdministratorUserPassword), StringUtil.RTrim( context.localUtil.Format( AV25ConfAdministratorUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfadministratoruserpassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavConfadministratoruserpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 254, edtavConfadministratoruserpassword_Ispassword, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_GAMRepositoryEntry.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUpdateconnectionfile_Internalname, StringUtil.BoolToStr( AV23UpdateConnectionFile), "", "", chkavUpdateconnectionfile.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START192( )
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
            Form.Meta.addItem("description", "Repositório", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP190( ) ;
      }

      protected void WS192( )
      {
         START192( ) ;
         EVT192( ) ;
      }

      protected void EVT192( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11192 ();
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
                                    E12192 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13192 ();
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
      }

      protected void WE192( )
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

      protected void PA192( )
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
               GX_FocusControl = edtavGuid_Internalname;
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
         AV7AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV7AllowOauthAccess));
         AssignAttri("", false, "AV7AllowOauthAccess", AV7AllowOauthAccess);
         AV8CanRegisterUsers = StringUtil.StrToBool( StringUtil.BoolToStr( AV8CanRegisterUsers));
         AssignAttri("", false, "AV8CanRegisterUsers", AV8CanRegisterUsers);
         AV15GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV15GiveAnonymousSession));
         AssignAttri("", false, "AV15GiveAnonymousSession", AV15GiveAnonymousSession);
         AV23UpdateConnectionFile = StringUtil.StrToBool( StringUtil.BoolToStr( AV23UpdateConnectionFile));
         AssignAttri("", false, "AV23UpdateConnectionFile", AV23UpdateConnectionFile);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF192( ) ;
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

      protected void RF192( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13192 ();
            WB190( ) ;
         }
      }

      protected void send_integrity_lvl_hashes192( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17Id), "ZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP190( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11192 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            Dvpanel_conn_Width = cgiGet( "DVPANEL_CONN_Width");
            Dvpanel_conn_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CONN_Autowidth"));
            Dvpanel_conn_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CONN_Autoheight"));
            Dvpanel_conn_Cls = cgiGet( "DVPANEL_CONN_Cls");
            Dvpanel_conn_Title = cgiGet( "DVPANEL_CONN_Title");
            Dvpanel_conn_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CONN_Collapsible"));
            Dvpanel_conn_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CONN_Collapsed"));
            Dvpanel_conn_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CONN_Showcollapseicon"));
            Dvpanel_conn_Iconposition = cgiGet( "DVPANEL_CONN_Iconposition");
            Dvpanel_conn_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CONN_Autoscroll"));
            Dvpanel_admin_Width = cgiGet( "DVPANEL_ADMIN_Width");
            Dvpanel_admin_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_ADMIN_Autowidth"));
            Dvpanel_admin_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_ADMIN_Autoheight"));
            Dvpanel_admin_Cls = cgiGet( "DVPANEL_ADMIN_Cls");
            Dvpanel_admin_Title = cgiGet( "DVPANEL_ADMIN_Title");
            Dvpanel_admin_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_ADMIN_Collapsible"));
            Dvpanel_admin_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_ADMIN_Collapsed"));
            Dvpanel_admin_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_ADMIN_Showcollapseicon"));
            Dvpanel_admin_Iconposition = cgiGet( "DVPANEL_ADMIN_Iconposition");
            Dvpanel_admin_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_ADMIN_Autoscroll"));
            /* Read variables values. */
            AV16GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV16GUID", AV16GUID);
            AV19Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV19Name", AV19Name);
            AV20Namespace = cgiGet( edtavNamespace_Internalname);
            AssignAttri("", false, "AV20Namespace", AV20Namespace);
            AV11Description = cgiGet( edtavDescription_Internalname);
            AssignAttri("", false, "AV11Description", AV11Description);
            AV7AllowOauthAccess = StringUtil.StrToBool( cgiGet( chkavAllowoauthaccess_Internalname));
            AssignAttri("", false, "AV7AllowOauthAccess", AV7AllowOauthAccess);
            AV8CanRegisterUsers = StringUtil.StrToBool( cgiGet( chkavCanregisterusers_Internalname));
            AssignAttri("", false, "AV8CanRegisterUsers", AV8CanRegisterUsers);
            AV15GiveAnonymousSession = StringUtil.StrToBool( cgiGet( chkavGiveanonymoussession_Internalname));
            AssignAttri("", false, "AV15GiveAnonymousSession", AV15GiveAnonymousSession);
            AV9ConnectionUserName = cgiGet( edtavConnectionusername_Internalname);
            AssignAttri("", false, "AV9ConnectionUserName", AV9ConnectionUserName);
            AV10ConnectionUserPassword = cgiGet( edtavConnectionuserpassword_Internalname);
            AssignAttri("", false, "AV10ConnectionUserPassword", AV10ConnectionUserPassword);
            AV24ConfConnectionUserPassword = cgiGet( edtavConfconnectionuserpassword_Internalname);
            AssignAttri("", false, "AV24ConfConnectionUserPassword", AV24ConfConnectionUserPassword);
            AV5AdministratorUserName = cgiGet( edtavAdministratorusername_Internalname);
            AssignAttri("", false, "AV5AdministratorUserName", AV5AdministratorUserName);
            AV6AdministratorUserPassword = cgiGet( edtavAdministratoruserpassword_Internalname);
            AssignAttri("", false, "AV6AdministratorUserPassword", AV6AdministratorUserPassword);
            AV25ConfAdministratorUserPassword = cgiGet( edtavConfadministratoruserpassword_Internalname);
            AssignAttri("", false, "AV25ConfAdministratorUserPassword", AV25ConfAdministratorUserPassword);
            AV23UpdateConnectionFile = StringUtil.StrToBool( cgiGet( chkavUpdateconnectionfile_Internalname));
            AssignAttri("", false, "AV23UpdateConnectionFile", AV23UpdateConnectionFile);
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
         E11192 ();
         if (returnInSub) return;
      }

      protected void E11192( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV21Repository.load( AV17Id);
            if ( AV21Repository.success() )
            {
               AV16GUID = AV21Repository.gxTpr_Guid;
               AssignAttri("", false, "AV16GUID", AV16GUID);
               AV19Name = AV21Repository.gxTpr_Name;
               AssignAttri("", false, "AV19Name", AV19Name);
               AV20Namespace = AV21Repository.gxTpr_Namespace;
               AssignAttri("", false, "AV20Namespace", AV20Namespace);
               AV11Description = AV21Repository.gxTpr_Description;
               AssignAttri("", false, "AV11Description", AV11Description);
               AV7AllowOauthAccess = AV21Repository.gxTpr_Allowoauthaccess;
               AssignAttri("", false, "AV7AllowOauthAccess", AV7AllowOauthAccess);
               AV8CanRegisterUsers = AV21Repository.gxTpr_Canregisterusers;
               AssignAttri("", false, "AV8CanRegisterUsers", AV8CanRegisterUsers);
               AV15GiveAnonymousSession = AV21Repository.gxTpr_Giveanonymoussession;
               AssignAttri("", false, "AV15GiveAnonymousSession", AV15GiveAnonymousSession);
               edtavGuid_Enabled = 0;
               AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               edtavNamespace_Enabled = 0;
               AssignProp("", false, edtavNamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNamespace_Enabled), 5, 0), true);
               edtavDescription_Enabled = 0;
               AssignProp("", false, edtavDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescription_Enabled), 5, 0), true);
               edtavAdministratorusername_Enabled = 0;
               AssignProp("", false, edtavAdministratorusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdministratorusername_Enabled), 5, 0), true);
               edtavAdministratoruserpassword_Enabled = 0;
               AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdministratoruserpassword_Enabled), 5, 0), true);
               chkavAllowoauthaccess.Enabled = 0;
               AssignProp("", false, chkavAllowoauthaccess_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAllowoauthaccess.Enabled), 5, 0), true);
               chkavCanregisterusers.Enabled = 0;
               AssignProp("", false, chkavCanregisterusers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavCanregisterusers.Enabled), 5, 0), true);
               edtavConnectionusername_Enabled = 0;
               AssignProp("", false, edtavConnectionusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionusername_Enabled), 5, 0), true);
               edtavConnectionuserpassword_Enabled = 0;
               AssignProp("", false, edtavConnectionuserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionuserpassword_Enabled), 5, 0), true);
               chkavGiveanonymoussession.Enabled = 0;
               AssignProp("", false, chkavGiveanonymoussession_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavGiveanonymoussession.Enabled), 5, 0), true);
            }
            else
            {
               AV13Errors = AV21Repository.geterrors();
               /* Execute user subroutine: 'DISPLAYERRORS' */
               S112 ();
               if (returnInSub) return;
            }
         }
         else
         {
            edtavAdministratoruserpassword_Ispassword = 1;
            AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Ispassword", StringUtil.Str( (decimal)(edtavAdministratoruserpassword_Ispassword), 1, 0), true);
            edtavConfadministratoruserpassword_Ispassword = 1;
            AssignProp("", false, edtavConfadministratoruserpassword_Internalname, "Ispassword", StringUtil.Str( (decimal)(edtavConfadministratoruserpassword_Ispassword), 1, 0), true);
            edtavConnectionuserpassword_Ispassword = 1;
            AssignProp("", false, edtavConnectionuserpassword_Internalname, "Ispassword", StringUtil.Str( (decimal)(edtavConnectionuserpassword_Ispassword), 1, 0), true);
            edtavConfconnectionuserpassword_Ispassword = 1;
            AssignProp("", false, edtavConfconnectionuserpassword_Internalname, "Ispassword", StringUtil.Str( (decimal)(edtavConfconnectionuserpassword_Ispassword), 1, 0), true);
            edtavGuid_Enabled = 0;
            AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         chkavUpdateconnectionfile.Visible = 0;
         AssignProp("", false, chkavUpdateconnectionfile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUpdateconnectionfile.Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DLT") != 0 ) || ! AV21Repository.success() ) )
         {
            divDvpanel_conn_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_conn_cell_Internalname, "Class", divDvpanel_conn_cell_Class, true);
         }
         else
         {
            divDvpanel_conn_cell_Class = "col-xs-12 CellMarginTop";
            AssignProp("", false, divDvpanel_conn_cell_Internalname, "Class", divDvpanel_conn_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DLT") != 0 ) || ! AV21Repository.success() ) )
         {
            divDvpanel_admin_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_admin_cell_Internalname, "Class", divDvpanel_admin_cell_Class, true);
         }
         else
         {
            divDvpanel_admin_cell_Class = "col-xs-12 CellMarginTop";
            AssignProp("", false, divDvpanel_admin_cell_Internalname, "Class", divDvpanel_admin_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12192 ();
         if (returnInSub) return;
      }

      protected void E12192( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV18isOK = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Trim( AV6AdministratorUserPassword), StringUtil.Trim( AV25ConfAdministratorUserPassword)) != 0 )
            {
               GX_msglist.addItem("A senha do administrador não coincide com a confirmação");
               AV18isOK = false;
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( AV10ConnectionUserPassword), StringUtil.Trim( AV24ConfConnectionUserPassword)) != 0 )
            {
               GX_msglist.addItem("A senha de conexão não coincide com a confirmação");
               AV18isOK = false;
            }
         }
         if ( AV18isOK )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV16GUID = Guid.NewGuid( ).ToString();
               AssignAttri("", false, "AV16GUID", AV16GUID);
               AV22RepositoryCreate.gxTpr_Guid = AV16GUID;
               AV22RepositoryCreate.gxTpr_Name = AV19Name;
               AV22RepositoryCreate.gxTpr_Namespace = AV20Namespace;
               AV22RepositoryCreate.gxTpr_Description = AV11Description;
               AV22RepositoryCreate.gxTpr_Administratorusername = AV5AdministratorUserName;
               AV22RepositoryCreate.gxTpr_Administratoruserpassword = AV6AdministratorUserPassword;
               AV22RepositoryCreate.gxTpr_Allowoauthaccess = AV7AllowOauthAccess;
               AV22RepositoryCreate.gxTpr_Canregisterusers = AV8CanRegisterUsers;
               AV22RepositoryCreate.gxTpr_Connectionusername = AV9ConnectionUserName;
               AV22RepositoryCreate.gxTpr_Connectionuserpassword = AV10ConnectionUserPassword;
               AV22RepositoryCreate.gxTpr_Giveanonymoussession = AV15GiveAnonymousSession;
               AV18isOK = AV14GAM.createrepository(AV22RepositoryCreate, AV23UpdateConnectionFile, out  AV13Errors);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV18isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).deleterepository(AV21Repository.gxTpr_Guid, out  AV13Errors);
            }
         }
         if ( AV18isOK )
         {
            context.CommitDataStores("gamrepositoryentry",pr_default);
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(int)AV17Id});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV17Id"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22RepositoryCreate", AV22RepositoryCreate);
      }

      protected void S112( )
      {
         /* 'DISPLAYERRORS' Routine */
         returnInSub = false;
         AV34GXV1 = 1;
         while ( AV34GXV1 <= AV13Errors.Count )
         {
            AV12Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13Errors.Item(AV34GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV12Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV12Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV34GXV1 = (int)(AV34GXV1+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13192( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV17Id = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV17Id", StringUtil.LTrimStr( (decimal)(AV17Id), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17Id), "ZZZZZZZZ9"), context));
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
         PA192( ) ;
         WS192( ) ;
         WE192( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815523888", true, true);
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
         context.AddJavascriptSource("gamrepositoryentry.js", "?202142815523894", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavAllowoauthaccess.Name = "vALLOWOAUTHACCESS";
         chkavAllowoauthaccess.WebTags = "";
         chkavAllowoauthaccess.Caption = "Permitir o acesso oauth";
         AssignProp("", false, chkavAllowoauthaccess_Internalname, "TitleCaption", chkavAllowoauthaccess.Caption, true);
         chkavAllowoauthaccess.CheckedValue = "false";
         AV7AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV7AllowOauthAccess));
         AssignAttri("", false, "AV7AllowOauthAccess", AV7AllowOauthAccess);
         chkavCanregisterusers.Name = "vCANREGISTERUSERS";
         chkavCanregisterusers.WebTags = "";
         chkavCanregisterusers.Caption = "Você pode registrar usuários?";
         AssignProp("", false, chkavCanregisterusers_Internalname, "TitleCaption", chkavCanregisterusers.Caption, true);
         chkavCanregisterusers.CheckedValue = "false";
         AV8CanRegisterUsers = StringUtil.StrToBool( StringUtil.BoolToStr( AV8CanRegisterUsers));
         AssignAttri("", false, "AV8CanRegisterUsers", AV8CanRegisterUsers);
         chkavGiveanonymoussession.Name = "vGIVEANONYMOUSSESSION";
         chkavGiveanonymoussession.WebTags = "";
         chkavGiveanonymoussession.Caption = "Dar sessão anônima?";
         AssignProp("", false, chkavGiveanonymoussession_Internalname, "TitleCaption", chkavGiveanonymoussession.Caption, true);
         chkavGiveanonymoussession.CheckedValue = "false";
         AV15GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV15GiveAnonymousSession));
         AssignAttri("", false, "AV15GiveAnonymousSession", AV15GiveAnonymousSession);
         chkavUpdateconnectionfile.Name = "vUPDATECONNECTIONFILE";
         chkavUpdateconnectionfile.WebTags = "";
         chkavUpdateconnectionfile.Caption = "";
         AssignProp("", false, chkavUpdateconnectionfile_Internalname, "TitleCaption", chkavUpdateconnectionfile.Caption, true);
         chkavUpdateconnectionfile.CheckedValue = "false";
         AV23UpdateConnectionFile = StringUtil.StrToBool( StringUtil.BoolToStr( AV23UpdateConnectionFile));
         AssignAttri("", false, "AV23UpdateConnectionFile", AV23UpdateConnectionFile);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavGuid_Internalname = "vGUID";
         edtavName_Internalname = "vNAME";
         edtavNamespace_Internalname = "vNAMESPACE";
         edtavDescription_Internalname = "vDESCRIPTION";
         chkavAllowoauthaccess_Internalname = "vALLOWOAUTHACCESS";
         chkavCanregisterusers_Internalname = "vCANREGISTERUSERS";
         chkavGiveanonymoussession_Internalname = "vGIVEANONYMOUSSESSION";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         edtavConnectionusername_Internalname = "vCONNECTIONUSERNAME";
         edtavConnectionuserpassword_Internalname = "vCONNECTIONUSERPASSWORD";
         edtavConfconnectionuserpassword_Internalname = "vCONFCONNECTIONUSERPASSWORD";
         divConn_Internalname = "CONN";
         Dvpanel_conn_Internalname = "DVPANEL_CONN";
         divDvpanel_conn_cell_Internalname = "DVPANEL_CONN_CELL";
         edtavAdministratorusername_Internalname = "vADMINISTRATORUSERNAME";
         edtavAdministratoruserpassword_Internalname = "vADMINISTRATORUSERPASSWORD";
         edtavConfadministratoruserpassword_Internalname = "vCONFADMINISTRATORUSERPASSWORD";
         divAdmin_Internalname = "ADMIN";
         Dvpanel_admin_Internalname = "DVPANEL_ADMIN";
         divDvpanel_admin_cell_Internalname = "DVPANEL_ADMIN_CELL";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavUpdateconnectionfile_Internalname = "vUPDATECONNECTIONFILE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         chkavUpdateconnectionfile.Caption = "";
         chkavGiveanonymoussession.Caption = "";
         chkavCanregisterusers.Caption = "";
         chkavAllowoauthaccess.Caption = "";
         chkavUpdateconnectionfile.Visible = 1;
         edtavConfadministratoruserpassword_Jsonclick = "";
         edtavConfadministratoruserpassword_Ispassword = 0;
         edtavConfadministratoruserpassword_Enabled = 1;
         edtavAdministratoruserpassword_Jsonclick = "";
         edtavAdministratoruserpassword_Ispassword = 0;
         edtavAdministratoruserpassword_Enabled = 1;
         edtavAdministratorusername_Jsonclick = "";
         edtavAdministratorusername_Enabled = 1;
         divDvpanel_admin_cell_Class = "col-xs-12";
         edtavConfconnectionuserpassword_Jsonclick = "";
         edtavConfconnectionuserpassword_Ispassword = 0;
         edtavConfconnectionuserpassword_Enabled = 1;
         edtavConnectionuserpassword_Jsonclick = "";
         edtavConnectionuserpassword_Ispassword = 0;
         edtavConnectionuserpassword_Enabled = 1;
         edtavConnectionusername_Jsonclick = "";
         edtavConnectionusername_Enabled = 1;
         divDvpanel_conn_cell_Class = "col-xs-12";
         chkavGiveanonymoussession.Enabled = 1;
         chkavCanregisterusers.Enabled = 1;
         chkavAllowoauthaccess.Enabled = 1;
         edtavDescription_Jsonclick = "";
         edtavDescription_Enabled = 1;
         edtavNamespace_Jsonclick = "";
         edtavNamespace_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         Dvpanel_admin_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_admin_Iconposition = "Right";
         Dvpanel_admin_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_admin_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_admin_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_admin_Title = "Administrador";
         Dvpanel_admin_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_admin_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_admin_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_admin_Width = "100%";
         Dvpanel_conn_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_conn_Iconposition = "Right";
         Dvpanel_conn_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_conn_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_conn_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_conn_Title = "Usuário da conexão";
         Dvpanel_conn_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_conn_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_conn_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_conn_Width = "100%";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Repositório";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Repositório";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV17Id',fld:'vID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV7AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV8CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:''},{av:'AV15GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV23UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV7AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV8CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:''},{av:'AV15GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV23UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E12192',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV6AdministratorUserPassword',fld:'vADMINISTRATORUSERPASSWORD',pic:''},{av:'AV25ConfAdministratorUserPassword',fld:'vCONFADMINISTRATORUSERPASSWORD',pic:''},{av:'AV10ConnectionUserPassword',fld:'vCONNECTIONUSERPASSWORD',pic:''},{av:'AV24ConfConnectionUserPassword',fld:'vCONFCONNECTIONUSERPASSWORD',pic:''},{av:'AV19Name',fld:'vNAME',pic:''},{av:'AV20Namespace',fld:'vNAMESPACE',pic:''},{av:'AV11Description',fld:'vDESCRIPTION',pic:''},{av:'AV5AdministratorUserName',fld:'vADMINISTRATORUSERNAME',pic:''},{av:'AV9ConnectionUserName',fld:'vCONNECTIONUSERNAME',pic:''},{av:'AV17Id',fld:'vID',pic:'ZZZZZZZZ9',hsh:true},{av:'AV7AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV8CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:''},{av:'AV15GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV23UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV16GUID',fld:'vGUID',pic:''},{av:'AV7AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV8CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:''},{av:'AV15GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV23UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''}]}");
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
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV16GUID = "";
         AV19Name = "";
         AV20Namespace = "";
         AV11Description = "";
         ucDvpanel_conn = new GXUserControl();
         AV9ConnectionUserName = "";
         AV10ConnectionUserPassword = "";
         AV24ConfConnectionUserPassword = "";
         ucDvpanel_admin = new GXUserControl();
         AV5AdministratorUserName = "";
         AV6AdministratorUserPassword = "";
         AV25ConfAdministratorUserPassword = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV21Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV22RepositoryCreate = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryCreate(context);
         AV14GAM = new GeneXus.Programs.genexussecurity.SdtGAM(context);
         AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamrepositoryentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamrepositoryentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short edtavConnectionuserpassword_Ispassword ;
      private short edtavConfconnectionuserpassword_Ispassword ;
      private short edtavAdministratoruserpassword_Ispassword ;
      private short edtavConfadministratoruserpassword_Ispassword ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV17Id ;
      private int wcpOAV17Id ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavNamespace_Enabled ;
      private int edtavDescription_Enabled ;
      private int edtavConnectionusername_Enabled ;
      private int edtavConnectionuserpassword_Enabled ;
      private int edtavConfconnectionuserpassword_Enabled ;
      private int edtavAdministratorusername_Enabled ;
      private int edtavAdministratoruserpassword_Enabled ;
      private int edtavConfadministratoruserpassword_Enabled ;
      private int AV34GXV1 ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_conn_Width ;
      private string Dvpanel_conn_Cls ;
      private string Dvpanel_conn_Title ;
      private string Dvpanel_conn_Iconposition ;
      private string Dvpanel_admin_Width ;
      private string Dvpanel_admin_Cls ;
      private string Dvpanel_admin_Title ;
      private string Dvpanel_admin_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavGuid_Internalname ;
      private string TempTags ;
      private string AV16GUID ;
      private string edtavGuid_Jsonclick ;
      private string edtavName_Internalname ;
      private string AV19Name ;
      private string edtavName_Jsonclick ;
      private string edtavNamespace_Internalname ;
      private string AV20Namespace ;
      private string edtavNamespace_Jsonclick ;
      private string edtavDescription_Internalname ;
      private string AV11Description ;
      private string edtavDescription_Jsonclick ;
      private string chkavAllowoauthaccess_Internalname ;
      private string chkavCanregisterusers_Internalname ;
      private string chkavGiveanonymoussession_Internalname ;
      private string divDvpanel_conn_cell_Internalname ;
      private string divDvpanel_conn_cell_Class ;
      private string Dvpanel_conn_Internalname ;
      private string divConn_Internalname ;
      private string edtavConnectionusername_Internalname ;
      private string AV9ConnectionUserName ;
      private string edtavConnectionusername_Jsonclick ;
      private string edtavConnectionuserpassword_Internalname ;
      private string AV10ConnectionUserPassword ;
      private string edtavConnectionuserpassword_Jsonclick ;
      private string edtavConfconnectionuserpassword_Internalname ;
      private string AV24ConfConnectionUserPassword ;
      private string edtavConfconnectionuserpassword_Jsonclick ;
      private string divDvpanel_admin_cell_Internalname ;
      private string divDvpanel_admin_cell_Class ;
      private string Dvpanel_admin_Internalname ;
      private string divAdmin_Internalname ;
      private string edtavAdministratorusername_Internalname ;
      private string AV5AdministratorUserName ;
      private string edtavAdministratorusername_Jsonclick ;
      private string edtavAdministratoruserpassword_Internalname ;
      private string AV6AdministratorUserPassword ;
      private string edtavAdministratoruserpassword_Jsonclick ;
      private string edtavConfadministratoruserpassword_Internalname ;
      private string AV25ConfAdministratorUserPassword ;
      private string edtavConfadministratoruserpassword_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavUpdateconnectionfile_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_conn_Autowidth ;
      private bool Dvpanel_conn_Autoheight ;
      private bool Dvpanel_conn_Collapsible ;
      private bool Dvpanel_conn_Collapsed ;
      private bool Dvpanel_conn_Showcollapseicon ;
      private bool Dvpanel_conn_Autoscroll ;
      private bool Dvpanel_admin_Autowidth ;
      private bool Dvpanel_admin_Autoheight ;
      private bool Dvpanel_admin_Collapsible ;
      private bool Dvpanel_admin_Collapsed ;
      private bool Dvpanel_admin_Showcollapseicon ;
      private bool Dvpanel_admin_Autoscroll ;
      private bool wbLoad ;
      private bool AV7AllowOauthAccess ;
      private bool AV8CanRegisterUsers ;
      private bool AV15GiveAnonymousSession ;
      private bool AV23UpdateConnectionFile ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18isOK ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_conn ;
      private GXUserControl ucDvpanel_admin ;
      private GeneXus.Programs.genexussecurity.SdtGAM AV14GAM ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private int aP1_Id ;
      private GXCheckbox chkavAllowoauthaccess ;
      private GXCheckbox chkavCanregisterusers ;
      private GXCheckbox chkavGiveanonymoussession ;
      private GXCheckbox chkavUpdateconnectionfile ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryCreate AV22RepositoryCreate ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV21Repository ;
   }

   public class gamrepositoryentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamrepositoryentry__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
