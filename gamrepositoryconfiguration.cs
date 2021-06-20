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
   public class gamrepositoryconfiguration : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamrepositoryconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamrepositoryconfiguration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref long aP0_pId )
      {
         this.AV14pId = aP0_pId;
         executePrivate();
         aP0_pId=this.AV14pId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavRepositorydefaultauthenticationtypename = new GXCombobox();
         chkavRepositorysessionexpiresonipchange = new GXCheckbox();
         chkavRepositoryallowoauthaccess = new GXCheckbox();
         cmbavRepositorydefaultsecuritypolicyid = new GXCombobox();
         cmbavRepositorylogoutbehavior = new GXCombobox();
         cmbavRepositorydefaultroleid = new GXCombobox();
         cmbavRepositoryenabletracing = new GXCombobox();
         cmbavRepositoryuseridentification = new GXCombobox();
         cmbavRepositoryuseractivationmethod = new GXCombobox();
         chkavRepositoryuseremailsunique = new GXCheckbox();
         chkavRepositoryrequiredemail = new GXCheckbox();
         chkavRepositoryrequiredpassword = new GXCheckbox();
         chkavRepositoryrequiredfirstname = new GXCheckbox();
         chkavRepositoryrequiredlastname = new GXCheckbox();
         cmbavRepositorygeneratesessionstatistics = new GXCombobox();
         chkavRepositorygiveanonymoussession = new GXCheckbox();
         cmbavRepositoryuserremembermetype = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pId");
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
               gxfirstwebparm = GetFirstPar( "pId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pId");
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
               AV14pId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV14pId", StringUtil.LTrimStr( (decimal)(AV14pId), 12, 0));
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
            return "gamrepositoryconfiguration_Execute" ;
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
         PA182( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START182( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142815523386", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamrepositoryconfiguration.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV14pId,12,0))}, new string[] {"pId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Id), "ZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Id), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pId), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
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
            WE182( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT182( ) ;
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
         return formatLink("gamrepositoryconfiguration.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV14pId,12,0))}, new string[] {"pId"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMRepositoryConfiguration" ;
      }

      public override string GetPgmdesc( )
      {
         return "Configuração do repositório" ;
      }

      protected void WB180( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "Geral", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMRepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryid_Internalname, "Id", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38RepositoryId), 9, 0, ",", "")), ((edtavRepositoryid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38RepositoryId), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV38RepositoryId), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavRepositoryid_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumShort", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryguid_Internalname, "Guid", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryguid_Internalname, StringUtil.RTrim( AV39RepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV39RepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryguid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavRepositoryguid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositorynamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositorynamespace_Internalname, "Namespace", " ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositorynamespace_Internalname, StringUtil.RTrim( AV40RepositoryNameSpace), StringUtil.RTrim( context.localUtil.Format( AV40RepositoryNameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositorynamespace_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavRepositorynamespace_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "left", true, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryname_Internalname, "Nome", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryname_Internalname, StringUtil.RTrim( AV41RepositoryName), StringUtil.RTrim( context.localUtil.Format( AV41RepositoryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositorydescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositorydescription_Internalname, "Descrição", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositorydescription_Internalname, StringUtil.RTrim( AV42RepositoryDescription), StringUtil.RTrim( context.localUtil.Format( AV42RepositoryDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositorydescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositorydescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepositorydefaultauthenticationtypename_cell_Internalname, 1, 0, "px", 0, "px", divRepositorydefaultauthenticationtypename_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavRepositorydefaultauthenticationtypename.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositorydefaultauthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositorydefaultauthenticationtypename_Internalname, "Tipo de autenticação padrão", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositorydefaultauthenticationtypename, cmbavRepositorydefaultauthenticationtypename_Internalname, StringUtil.RTrim( AV43RepositoryDefaultAuthenticationTypeName), 1, cmbavRepositorydefaultauthenticationtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavRepositorydefaultauthenticationtypename.Visible, cmbavRepositorydefaultauthenticationtypename.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositorydefaultauthenticationtypename.CurrentValue = StringUtil.RTrim( AV43RepositoryDefaultAuthenticationTypeName);
            AssignProp("", false, cmbavRepositorydefaultauthenticationtypename_Internalname, "Values", (string)(cmbavRepositorydefaultauthenticationtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositorysessionexpiresonipchange_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositorysessionexpiresonipchange_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositorysessionexpiresonipchange_Internalname, StringUtil.BoolToStr( AV44RepositorySessionExpiresOnIPChange), "", " ", 1, chkavRepositorysessionexpiresonipchange.Enabled, "true", "A sessão de gam expira com a mudança de ip?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(52, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,52);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositoryallowoauthaccess_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositoryallowoauthaccess_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositoryallowoauthaccess_Internalname, StringUtil.BoolToStr( AV45RepositoryAllowOauthAccess), "", " ", 1, chkavRepositoryallowoauthaccess.Enabled, "true", "Permitir o acesso oauth (smart devices)", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepositorydefaultsecuritypolicyid_cell_Internalname, 1, 0, "px", 0, "px", divRepositorydefaultsecuritypolicyid_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavRepositorydefaultsecuritypolicyid.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositorydefaultsecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositorydefaultsecuritypolicyid_Internalname, "Política de segurança predeterminada", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositorydefaultsecuritypolicyid, cmbavRepositorydefaultsecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0)), 1, cmbavRepositorydefaultsecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavRepositorydefaultsecuritypolicyid.Visible, cmbavRepositorydefaultsecuritypolicyid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositorydefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavRepositorydefaultsecuritypolicyid_Internalname, "Values", (string)(cmbavRepositorydefaultsecuritypolicyid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositorylogoutbehavior_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositorylogoutbehavior_Internalname, "Comportamento de logoff do sso", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositorylogoutbehavior, cmbavRepositorylogoutbehavior_Internalname, StringUtil.RTrim( AV47RepositoryLogoutBehavior), 1, cmbavRepositorylogoutbehavior_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavRepositorylogoutbehavior.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositorylogoutbehavior.CurrentValue = StringUtil.RTrim( AV47RepositoryLogoutBehavior);
            AssignProp("", false, cmbavRepositorylogoutbehavior_Internalname, "Values", (string)(cmbavRepositorylogoutbehavior.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepositorydefaultroleid_cell_Internalname, 1, 0, "px", 0, "px", divRepositorydefaultroleid_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavRepositorydefaultroleid.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositorydefaultroleid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositorydefaultroleid_Internalname, "Perfil padrão", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositorydefaultroleid, cmbavRepositorydefaultroleid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV46RepositoryDefaultRoleId), 12, 0)), 1, cmbavRepositorydefaultroleid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavRepositorydefaultroleid.Visible, cmbavRepositorydefaultroleid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositorydefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46RepositoryDefaultRoleId), 12, 0));
            AssignProp("", false, cmbavRepositorydefaultroleid_Internalname, "Values", (string)(cmbavRepositorydefaultroleid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositoryenabletracing_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositoryenabletracing_Internalname, "Ativar o rastreamento", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositoryenabletracing, cmbavRepositoryenabletracing_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV48RepositoryEnableTracing), 4, 0)), 1, cmbavRepositoryenabletracing_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavRepositoryenabletracing.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositoryenabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48RepositoryEnableTracing), 4, 0));
            AssignProp("", false, cmbavRepositoryenabletracing_Internalname, "Values", (string)(cmbavRepositoryenabletracing.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsers_title_Internalname, "Usuários", "", "", lblUsers_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMRepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Users") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositoryuseridentification_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositoryuseridentification_Internalname, "Id do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositoryuseridentification, cmbavRepositoryuseridentification_Internalname, StringUtil.RTrim( AV32RepositoryUserIdentification), 1, cmbavRepositoryuseridentification_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavRepositoryuseridentification.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositoryuseridentification.CurrentValue = StringUtil.RTrim( AV32RepositoryUserIdentification);
            AssignProp("", false, cmbavRepositoryuseridentification_Internalname, "Values", (string)(cmbavRepositoryuseridentification.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositoryuseractivationmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositoryuseractivationmethod_Internalname, "Método de activação do usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositoryuseractivationmethod, cmbavRepositoryuseractivationmethod_Internalname, StringUtil.RTrim( AV33RepositoryUserActivationMethod), 1, cmbavRepositoryuseractivationmethod_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavRepositoryuseractivationmethod.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositoryuseractivationmethod.CurrentValue = StringUtil.RTrim( AV33RepositoryUserActivationMethod);
            AssignProp("", false, cmbavRepositoryuseractivationmethod_Internalname, "Values", (string)(cmbavRepositoryuseractivationmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryautomaticactivationtimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryautomaticactivationtimeout_Internalname, "Tempo de espera de activação automática do usuário (horas)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryautomaticactivationtimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34RepositoryAutomaticActivationTimeout), 4, 0, ",", "")), ((edtavRepositoryautomaticactivationtimeout_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34RepositoryAutomaticActivationTimeout), "ZZZ9")) : context.localUtil.Format( (decimal)(AV34RepositoryAutomaticActivationTimeout), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryautomaticactivationtimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryautomaticactivationtimeout_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositoryuseremailsunique_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositoryuseremailsunique_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositoryuseremailsunique_Internalname, StringUtil.BoolToStr( AV35RepositoryUserEmailsUnique), "", " ", 1, chkavRepositoryuseremailsunique.Enabled, "true", "E-mail do usuário é único?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(97, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,97);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositoryrequiredemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositoryrequiredemail_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositoryrequiredemail_Internalname, StringUtil.BoolToStr( AV36RepositoryRequiredEmail), "", " ", 1, chkavRepositoryrequiredemail.Enabled, "true", "Email é obrigatório?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(102, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,102);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositoryrequiredpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositoryrequiredpassword_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositoryrequiredpassword_Internalname, StringUtil.BoolToStr( AV37RepositoryRequiredPassword), "", " ", 1, chkavRepositoryrequiredpassword.Enabled, "true", "Senha é obrigatória?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(106, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,106);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositoryrequiredfirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositoryrequiredfirstname_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositoryrequiredfirstname_Internalname, StringUtil.BoolToStr( AV21RepositoryRequiredFirstName), "", " ", 1, chkavRepositoryrequiredfirstname.Enabled, "true", "Nome é obrigatório?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositoryrequiredlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositoryrequiredlastname_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositoryrequiredlastname_Internalname, StringUtil.BoolToStr( AV22RepositoryRequiredLastName), "", " ", 1, chkavRepositoryrequiredlastname.Enabled, "true", "Sobrenome é obrigatório?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(115, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,115);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSession_title_Internalname, "Sessão", "", "", lblSession_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMRepositoryConfiguration.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Session") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositorygeneratesessionstatistics_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositorygeneratesessionstatistics_Internalname, "Gerar estatísticas da sessão?", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositorygeneratesessionstatistics, cmbavRepositorygeneratesessionstatistics_Internalname, StringUtil.RTrim( AV28RepositoryGenerateSessionStatistics), 1, cmbavRepositorygeneratesessionstatistics_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavRepositorygeneratesessionstatistics.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositorygeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV28RepositoryGenerateSessionStatistics);
            AssignProp("", false, cmbavRepositorygeneratesessionstatistics_Internalname, "Values", (string)(cmbavRepositorygeneratesessionstatistics.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryusersessioncachetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryusersessioncachetimeout_Internalname, "Timeout da sessão do usuário (segundos)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryusersessioncachetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27RepositoryUserSessionCacheTimeout), 9, 0, ",", "")), ((edtavRepositoryusersessioncachetimeout_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27RepositoryUserSessionCacheTimeout), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV27RepositoryUserSessionCacheTimeout), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryusersessioncachetimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryusersessioncachetimeout_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRepositorygiveanonymoussession_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRepositorygiveanonymoussession_Internalname, "  ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRepositorygiveanonymoussession_Internalname, StringUtil.BoolToStr( AV26RepositoryGiveAnonymousSession), "", "  ", 1, chkavRepositorygiveanonymoussession.Enabled, "true", "Dar sessão anônima web?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,134);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryloginattemptstolocksession_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryloginattemptstolocksession_Internalname, "Tentativas de login para bloquear sessão", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryloginattemptstolocksession_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49RepositoryLoginAttemptsToLockSession), 2, 0, ",", "")), ((edtavRepositoryloginattemptstolocksession_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV49RepositoryLoginAttemptsToLockSession), "Z9")) : context.localUtil.Format( (decimal)(AV49RepositoryLoginAttemptsToLockSession), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryloginattemptstolocksession_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryloginattemptstolocksession_Enabled, 0, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositorygamunblockusertimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositorygamunblockusertimeout_Internalname, "Desbloquear tempo límite do usuário (minutos)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositorygamunblockusertimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50RepositoryGAMUnblockUserTimeout), 2, 0, ",", "")), ((edtavRepositorygamunblockusertimeout_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV50RepositoryGAMUnblockUserTimeout), "Z9")) : context.localUtil.Format( (decimal)(AV50RepositoryGAMUnblockUserTimeout), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositorygamunblockusertimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositorygamunblockusertimeout_Enabled, 0, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryloginattemptstolockuser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryloginattemptstolockuser_Internalname, "Tentativas de login para bloquear usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryloginattemptstolockuser_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25RepositoryLoginAttemptsToLockUser), 2, 0, ",", "")), ((edtavRepositoryloginattemptstolockuser_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25RepositoryLoginAttemptsToLockUser), "Z9")) : context.localUtil.Format( (decimal)(AV25RepositoryLoginAttemptsToLockUser), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryloginattemptstolockuser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryloginattemptstolockuser_Enabled, 0, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryminimumamountcharactersinlogin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryminimumamountcharactersinlogin_Internalname, "Número mínimo de caracteres login", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryminimumamountcharactersinlogin_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24RepositoryMinimumAmountCharactersInLogin), 2, 0, ",", "")), ((edtavRepositoryminimumamountcharactersinlogin_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24RepositoryMinimumAmountCharactersInLogin), "Z9")) : context.localUtil.Format( (decimal)(AV24RepositoryMinimumAmountCharactersInLogin), "Z9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryminimumamountcharactersinlogin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryminimumamountcharactersinlogin_Enabled, 0, "number", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryuserrecoverypasswordkeytimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryuserrecoverypasswordkeytimeout_Internalname, "Timeout da recuperação da chave da senha do usuário (minutos)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryuserrecoverypasswordkeytimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31RepositoryUserRecoveryPasswordKeyTimeout), 4, 0, ",", "")), ((edtavRepositoryuserrecoverypasswordkeytimeout_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31RepositoryUserRecoveryPasswordKeyTimeout), "ZZZ9")) : context.localUtil.Format( (decimal)(AV31RepositoryUserRecoveryPasswordKeyTimeout), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryuserrecoverypasswordkeytimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryuserrecoverypasswordkeytimeout_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositoryuserremembermetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositoryuserremembermetimeout_Internalname, "Timeout da memória do usuário (dias)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositoryuserremembermetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30RepositoryUserRememberMeTimeout), 4, 0, ",", "")), ((edtavRepositoryuserremembermetimeout_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30RepositoryUserRememberMeTimeout), "ZZZ9")) : context.localUtil.Format( (decimal)(AV30RepositoryUserRememberMeTimeout), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositoryuserremembermetimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositoryuserremembermetimeout_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavRepositoryuserremembermetype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepositoryuserremembermetype_Internalname, "Tipo de memória de usuário", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepositoryuserremembermetype, cmbavRepositoryuserremembermetype_Internalname, StringUtil.RTrim( AV29RepositoryUserRememberMeType), 1, cmbavRepositoryuserremembermetype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavRepositoryuserremembermetype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,165);\"", "", true, "HLP_GAMRepositoryConfiguration.htm");
            cmbavRepositoryuserremembermetype.CurrentValue = StringUtil.RTrim( AV29RepositoryUserRememberMeType);
            AssignProp("", false, cmbavRepositoryuserremembermetype_Internalname, "Values", (string)(cmbavRepositoryuserremembermetype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRepositorycachetimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepositorycachetimeout_Internalname, "Cache timeout (minutos)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepositorycachetimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16RepositoryCacheTimeout), 9, 0, ",", "")), ((edtavRepositorycachetimeout_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16RepositoryCacheTimeout), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV16RepositoryCacheTimeout), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,170);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepositorycachetimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRepositorycachetimeout_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMRepositoryConfiguration.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRepositoryConfiguration.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START182( )
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
            Form.Meta.addItem("description", "Configuração do repositório", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP180( ) ;
      }

      protected void WS182( )
      {
         START182( ) ;
         EVT182( ) ;
      }

      protected void EVT182( )
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
                              E11182 ();
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
                                    E12182 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13182 ();
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

      protected void WE182( )
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

      protected void PA182( )
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
               GX_FocusControl = edtavRepositoryid_Internalname;
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
         if ( cmbavRepositorydefaultauthenticationtypename.ItemCount > 0 )
         {
            AV43RepositoryDefaultAuthenticationTypeName = cmbavRepositorydefaultauthenticationtypename.getValidValue(AV43RepositoryDefaultAuthenticationTypeName);
            AssignAttri("", false, "AV43RepositoryDefaultAuthenticationTypeName", AV43RepositoryDefaultAuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositorydefaultauthenticationtypename.CurrentValue = StringUtil.RTrim( AV43RepositoryDefaultAuthenticationTypeName);
            AssignProp("", false, cmbavRepositorydefaultauthenticationtypename_Internalname, "Values", cmbavRepositorydefaultauthenticationtypename.ToJavascriptSource(), true);
         }
         AV44RepositorySessionExpiresOnIPChange = StringUtil.StrToBool( StringUtil.BoolToStr( AV44RepositorySessionExpiresOnIPChange));
         AssignAttri("", false, "AV44RepositorySessionExpiresOnIPChange", AV44RepositorySessionExpiresOnIPChange);
         AV45RepositoryAllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV45RepositoryAllowOauthAccess));
         AssignAttri("", false, "AV45RepositoryAllowOauthAccess", AV45RepositoryAllowOauthAccess);
         if ( cmbavRepositorydefaultsecuritypolicyid.ItemCount > 0 )
         {
            AV23RepositoryDefaultSecurityPolicyId = (int)(NumberUtil.Val( cmbavRepositorydefaultsecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV23RepositoryDefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositorydefaultsecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavRepositorydefaultsecuritypolicyid_Internalname, "Values", cmbavRepositorydefaultsecuritypolicyid.ToJavascriptSource(), true);
         }
         if ( cmbavRepositorylogoutbehavior.ItemCount > 0 )
         {
            AV47RepositoryLogoutBehavior = cmbavRepositorylogoutbehavior.getValidValue(AV47RepositoryLogoutBehavior);
            AssignAttri("", false, "AV47RepositoryLogoutBehavior", AV47RepositoryLogoutBehavior);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositorylogoutbehavior.CurrentValue = StringUtil.RTrim( AV47RepositoryLogoutBehavior);
            AssignProp("", false, cmbavRepositorylogoutbehavior_Internalname, "Values", cmbavRepositorylogoutbehavior.ToJavascriptSource(), true);
         }
         if ( cmbavRepositorydefaultroleid.ItemCount > 0 )
         {
            AV46RepositoryDefaultRoleId = (long)(NumberUtil.Val( cmbavRepositorydefaultroleid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46RepositoryDefaultRoleId), 12, 0))), "."));
            AssignAttri("", false, "AV46RepositoryDefaultRoleId", StringUtil.LTrimStr( (decimal)(AV46RepositoryDefaultRoleId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositorydefaultroleid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46RepositoryDefaultRoleId), 12, 0));
            AssignProp("", false, cmbavRepositorydefaultroleid_Internalname, "Values", cmbavRepositorydefaultroleid.ToJavascriptSource(), true);
         }
         if ( cmbavRepositoryenabletracing.ItemCount > 0 )
         {
            AV48RepositoryEnableTracing = (short)(NumberUtil.Val( cmbavRepositoryenabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV48RepositoryEnableTracing), 4, 0))), "."));
            AssignAttri("", false, "AV48RepositoryEnableTracing", StringUtil.LTrimStr( (decimal)(AV48RepositoryEnableTracing), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositoryenabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48RepositoryEnableTracing), 4, 0));
            AssignProp("", false, cmbavRepositoryenabletracing_Internalname, "Values", cmbavRepositoryenabletracing.ToJavascriptSource(), true);
         }
         if ( cmbavRepositoryuseridentification.ItemCount > 0 )
         {
            AV32RepositoryUserIdentification = cmbavRepositoryuseridentification.getValidValue(AV32RepositoryUserIdentification);
            AssignAttri("", false, "AV32RepositoryUserIdentification", AV32RepositoryUserIdentification);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositoryuseridentification.CurrentValue = StringUtil.RTrim( AV32RepositoryUserIdentification);
            AssignProp("", false, cmbavRepositoryuseridentification_Internalname, "Values", cmbavRepositoryuseridentification.ToJavascriptSource(), true);
         }
         if ( cmbavRepositoryuseractivationmethod.ItemCount > 0 )
         {
            AV33RepositoryUserActivationMethod = cmbavRepositoryuseractivationmethod.getValidValue(AV33RepositoryUserActivationMethod);
            AssignAttri("", false, "AV33RepositoryUserActivationMethod", AV33RepositoryUserActivationMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositoryuseractivationmethod.CurrentValue = StringUtil.RTrim( AV33RepositoryUserActivationMethod);
            AssignProp("", false, cmbavRepositoryuseractivationmethod_Internalname, "Values", cmbavRepositoryuseractivationmethod.ToJavascriptSource(), true);
         }
         AV35RepositoryUserEmailsUnique = StringUtil.StrToBool( StringUtil.BoolToStr( AV35RepositoryUserEmailsUnique));
         AssignAttri("", false, "AV35RepositoryUserEmailsUnique", AV35RepositoryUserEmailsUnique);
         AV36RepositoryRequiredEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV36RepositoryRequiredEmail));
         AssignAttri("", false, "AV36RepositoryRequiredEmail", AV36RepositoryRequiredEmail);
         AV37RepositoryRequiredPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV37RepositoryRequiredPassword));
         AssignAttri("", false, "AV37RepositoryRequiredPassword", AV37RepositoryRequiredPassword);
         AV21RepositoryRequiredFirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV21RepositoryRequiredFirstName));
         AssignAttri("", false, "AV21RepositoryRequiredFirstName", AV21RepositoryRequiredFirstName);
         AV22RepositoryRequiredLastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV22RepositoryRequiredLastName));
         AssignAttri("", false, "AV22RepositoryRequiredLastName", AV22RepositoryRequiredLastName);
         if ( cmbavRepositorygeneratesessionstatistics.ItemCount > 0 )
         {
            AV28RepositoryGenerateSessionStatistics = cmbavRepositorygeneratesessionstatistics.getValidValue(AV28RepositoryGenerateSessionStatistics);
            AssignAttri("", false, "AV28RepositoryGenerateSessionStatistics", AV28RepositoryGenerateSessionStatistics);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositorygeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV28RepositoryGenerateSessionStatistics);
            AssignProp("", false, cmbavRepositorygeneratesessionstatistics_Internalname, "Values", cmbavRepositorygeneratesessionstatistics.ToJavascriptSource(), true);
         }
         AV26RepositoryGiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV26RepositoryGiveAnonymousSession));
         AssignAttri("", false, "AV26RepositoryGiveAnonymousSession", AV26RepositoryGiveAnonymousSession);
         if ( cmbavRepositoryuserremembermetype.ItemCount > 0 )
         {
            AV29RepositoryUserRememberMeType = cmbavRepositoryuserremembermetype.getValidValue(AV29RepositoryUserRememberMeType);
            AssignAttri("", false, "AV29RepositoryUserRememberMeType", AV29RepositoryUserRememberMeType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepositoryuserremembermetype.CurrentValue = StringUtil.RTrim( AV29RepositoryUserRememberMeType);
            AssignProp("", false, cmbavRepositoryuserremembermetype_Internalname, "Values", cmbavRepositoryuserremembermetype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF182( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavRepositoryid_Enabled = 0;
         AssignProp("", false, edtavRepositoryid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositoryid_Enabled), 5, 0), true);
         edtavRepositoryguid_Enabled = 0;
         AssignProp("", false, edtavRepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositoryguid_Enabled), 5, 0), true);
         edtavRepositorynamespace_Enabled = 0;
         AssignProp("", false, edtavRepositorynamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositorynamespace_Enabled), 5, 0), true);
      }

      protected void RF182( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13182 ();
            WB180( ) ;
         }
      }

      protected void send_integrity_lvl_hashes182( )
      {
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Id), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Id), "ZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavRepositoryid_Enabled = 0;
         AssignProp("", false, edtavRepositoryid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositoryid_Enabled), 5, 0), true);
         edtavRepositoryguid_Enabled = 0;
         AssignProp("", false, edtavRepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositoryguid_Enabled), 5, 0), true);
         edtavRepositorynamespace_Enabled = 0;
         AssignProp("", false, edtavRepositorynamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepositorynamespace_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP180( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11182 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gxuitabspanel_tabs_Pagecount = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), ",", "."));
            Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYID");
               GX_FocusControl = edtavRepositoryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38RepositoryId = 0;
               AssignAttri("", false, "AV38RepositoryId", StringUtil.LTrimStr( (decimal)(AV38RepositoryId), 9, 0));
            }
            else
            {
               AV38RepositoryId = (int)(context.localUtil.CToN( cgiGet( edtavRepositoryid_Internalname), ",", "."));
               AssignAttri("", false, "AV38RepositoryId", StringUtil.LTrimStr( (decimal)(AV38RepositoryId), 9, 0));
            }
            AV39RepositoryGUID = cgiGet( edtavRepositoryguid_Internalname);
            AssignAttri("", false, "AV39RepositoryGUID", AV39RepositoryGUID);
            AV40RepositoryNameSpace = cgiGet( edtavRepositorynamespace_Internalname);
            AssignAttri("", false, "AV40RepositoryNameSpace", AV40RepositoryNameSpace);
            AV41RepositoryName = cgiGet( edtavRepositoryname_Internalname);
            AssignAttri("", false, "AV41RepositoryName", AV41RepositoryName);
            AV42RepositoryDescription = cgiGet( edtavRepositorydescription_Internalname);
            AssignAttri("", false, "AV42RepositoryDescription", AV42RepositoryDescription);
            cmbavRepositorydefaultauthenticationtypename.CurrentValue = cgiGet( cmbavRepositorydefaultauthenticationtypename_Internalname);
            AV43RepositoryDefaultAuthenticationTypeName = cgiGet( cmbavRepositorydefaultauthenticationtypename_Internalname);
            AssignAttri("", false, "AV43RepositoryDefaultAuthenticationTypeName", AV43RepositoryDefaultAuthenticationTypeName);
            AV44RepositorySessionExpiresOnIPChange = StringUtil.StrToBool( cgiGet( chkavRepositorysessionexpiresonipchange_Internalname));
            AssignAttri("", false, "AV44RepositorySessionExpiresOnIPChange", AV44RepositorySessionExpiresOnIPChange);
            AV45RepositoryAllowOauthAccess = StringUtil.StrToBool( cgiGet( chkavRepositoryallowoauthaccess_Internalname));
            AssignAttri("", false, "AV45RepositoryAllowOauthAccess", AV45RepositoryAllowOauthAccess);
            cmbavRepositorydefaultsecuritypolicyid.CurrentValue = cgiGet( cmbavRepositorydefaultsecuritypolicyid_Internalname);
            AV23RepositoryDefaultSecurityPolicyId = (int)(NumberUtil.Val( cgiGet( cmbavRepositorydefaultsecuritypolicyid_Internalname), "."));
            AssignAttri("", false, "AV23RepositoryDefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0));
            cmbavRepositorylogoutbehavior.CurrentValue = cgiGet( cmbavRepositorylogoutbehavior_Internalname);
            AV47RepositoryLogoutBehavior = cgiGet( cmbavRepositorylogoutbehavior_Internalname);
            AssignAttri("", false, "AV47RepositoryLogoutBehavior", AV47RepositoryLogoutBehavior);
            cmbavRepositorydefaultroleid.CurrentValue = cgiGet( cmbavRepositorydefaultroleid_Internalname);
            AV46RepositoryDefaultRoleId = (long)(NumberUtil.Val( cgiGet( cmbavRepositorydefaultroleid_Internalname), "."));
            AssignAttri("", false, "AV46RepositoryDefaultRoleId", StringUtil.LTrimStr( (decimal)(AV46RepositoryDefaultRoleId), 12, 0));
            cmbavRepositoryenabletracing.CurrentValue = cgiGet( cmbavRepositoryenabletracing_Internalname);
            AV48RepositoryEnableTracing = (short)(NumberUtil.Val( cgiGet( cmbavRepositoryenabletracing_Internalname), "."));
            AssignAttri("", false, "AV48RepositoryEnableTracing", StringUtil.LTrimStr( (decimal)(AV48RepositoryEnableTracing), 4, 0));
            cmbavRepositoryuseridentification.CurrentValue = cgiGet( cmbavRepositoryuseridentification_Internalname);
            AV32RepositoryUserIdentification = cgiGet( cmbavRepositoryuseridentification_Internalname);
            AssignAttri("", false, "AV32RepositoryUserIdentification", AV32RepositoryUserIdentification);
            cmbavRepositoryuseractivationmethod.CurrentValue = cgiGet( cmbavRepositoryuseractivationmethod_Internalname);
            AV33RepositoryUserActivationMethod = cgiGet( cmbavRepositoryuseractivationmethod_Internalname);
            AssignAttri("", false, "AV33RepositoryUserActivationMethod", AV33RepositoryUserActivationMethod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryautomaticactivationtimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryautomaticactivationtimeout_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYAUTOMATICACTIVATIONTIMEOUT");
               GX_FocusControl = edtavRepositoryautomaticactivationtimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34RepositoryAutomaticActivationTimeout = 0;
               AssignAttri("", false, "AV34RepositoryAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV34RepositoryAutomaticActivationTimeout), 4, 0));
            }
            else
            {
               AV34RepositoryAutomaticActivationTimeout = (short)(context.localUtil.CToN( cgiGet( edtavRepositoryautomaticactivationtimeout_Internalname), ",", "."));
               AssignAttri("", false, "AV34RepositoryAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV34RepositoryAutomaticActivationTimeout), 4, 0));
            }
            AV35RepositoryUserEmailsUnique = StringUtil.StrToBool( cgiGet( chkavRepositoryuseremailsunique_Internalname));
            AssignAttri("", false, "AV35RepositoryUserEmailsUnique", AV35RepositoryUserEmailsUnique);
            AV36RepositoryRequiredEmail = StringUtil.StrToBool( cgiGet( chkavRepositoryrequiredemail_Internalname));
            AssignAttri("", false, "AV36RepositoryRequiredEmail", AV36RepositoryRequiredEmail);
            AV37RepositoryRequiredPassword = StringUtil.StrToBool( cgiGet( chkavRepositoryrequiredpassword_Internalname));
            AssignAttri("", false, "AV37RepositoryRequiredPassword", AV37RepositoryRequiredPassword);
            AV21RepositoryRequiredFirstName = StringUtil.StrToBool( cgiGet( chkavRepositoryrequiredfirstname_Internalname));
            AssignAttri("", false, "AV21RepositoryRequiredFirstName", AV21RepositoryRequiredFirstName);
            AV22RepositoryRequiredLastName = StringUtil.StrToBool( cgiGet( chkavRepositoryrequiredlastname_Internalname));
            AssignAttri("", false, "AV22RepositoryRequiredLastName", AV22RepositoryRequiredLastName);
            cmbavRepositorygeneratesessionstatistics.CurrentValue = cgiGet( cmbavRepositorygeneratesessionstatistics_Internalname);
            AV28RepositoryGenerateSessionStatistics = cgiGet( cmbavRepositorygeneratesessionstatistics_Internalname);
            AssignAttri("", false, "AV28RepositoryGenerateSessionStatistics", AV28RepositoryGenerateSessionStatistics);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryusersessioncachetimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryusersessioncachetimeout_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYUSERSESSIONCACHETIMEOUT");
               GX_FocusControl = edtavRepositoryusersessioncachetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27RepositoryUserSessionCacheTimeout = 0;
               AssignAttri("", false, "AV27RepositoryUserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV27RepositoryUserSessionCacheTimeout), 9, 0));
            }
            else
            {
               AV27RepositoryUserSessionCacheTimeout = (int)(context.localUtil.CToN( cgiGet( edtavRepositoryusersessioncachetimeout_Internalname), ",", "."));
               AssignAttri("", false, "AV27RepositoryUserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV27RepositoryUserSessionCacheTimeout), 9, 0));
            }
            AV26RepositoryGiveAnonymousSession = StringUtil.StrToBool( cgiGet( chkavRepositorygiveanonymoussession_Internalname));
            AssignAttri("", false, "AV26RepositoryGiveAnonymousSession", AV26RepositoryGiveAnonymousSession);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryloginattemptstolocksession_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryloginattemptstolocksession_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYLOGINATTEMPTSTOLOCKSESSION");
               GX_FocusControl = edtavRepositoryloginattemptstolocksession_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV49RepositoryLoginAttemptsToLockSession = 0;
               AssignAttri("", false, "AV49RepositoryLoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV49RepositoryLoginAttemptsToLockSession), 2, 0));
            }
            else
            {
               AV49RepositoryLoginAttemptsToLockSession = (short)(context.localUtil.CToN( cgiGet( edtavRepositoryloginattemptstolocksession_Internalname), ",", "."));
               AssignAttri("", false, "AV49RepositoryLoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV49RepositoryLoginAttemptsToLockSession), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositorygamunblockusertimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositorygamunblockusertimeout_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYGAMUNBLOCKUSERTIMEOUT");
               GX_FocusControl = edtavRepositorygamunblockusertimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV50RepositoryGAMUnblockUserTimeout = 0;
               AssignAttri("", false, "AV50RepositoryGAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV50RepositoryGAMUnblockUserTimeout), 2, 0));
            }
            else
            {
               AV50RepositoryGAMUnblockUserTimeout = (short)(context.localUtil.CToN( cgiGet( edtavRepositorygamunblockusertimeout_Internalname), ",", "."));
               AssignAttri("", false, "AV50RepositoryGAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV50RepositoryGAMUnblockUserTimeout), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryloginattemptstolockuser_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryloginattemptstolockuser_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYLOGINATTEMPTSTOLOCKUSER");
               GX_FocusControl = edtavRepositoryloginattemptstolockuser_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25RepositoryLoginAttemptsToLockUser = 0;
               AssignAttri("", false, "AV25RepositoryLoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV25RepositoryLoginAttemptsToLockUser), 2, 0));
            }
            else
            {
               AV25RepositoryLoginAttemptsToLockUser = (short)(context.localUtil.CToN( cgiGet( edtavRepositoryloginattemptstolockuser_Internalname), ",", "."));
               AssignAttri("", false, "AV25RepositoryLoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV25RepositoryLoginAttemptsToLockUser), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryminimumamountcharactersinlogin_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryminimumamountcharactersinlogin_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYMINIMUMAMOUNTCHARACTERSINLOGIN");
               GX_FocusControl = edtavRepositoryminimumamountcharactersinlogin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24RepositoryMinimumAmountCharactersInLogin = 0;
               AssignAttri("", false, "AV24RepositoryMinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV24RepositoryMinimumAmountCharactersInLogin), 2, 0));
            }
            else
            {
               AV24RepositoryMinimumAmountCharactersInLogin = (short)(context.localUtil.CToN( cgiGet( edtavRepositoryminimumamountcharactersinlogin_Internalname), ",", "."));
               AssignAttri("", false, "AV24RepositoryMinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV24RepositoryMinimumAmountCharactersInLogin), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryuserrecoverypasswordkeytimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryuserrecoverypasswordkeytimeout_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYUSERRECOVERYPASSWORDKEYTIMEOUT");
               GX_FocusControl = edtavRepositoryuserrecoverypasswordkeytimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31RepositoryUserRecoveryPasswordKeyTimeout = 0;
               AssignAttri("", false, "AV31RepositoryUserRecoveryPasswordKeyTimeout", StringUtil.LTrimStr( (decimal)(AV31RepositoryUserRecoveryPasswordKeyTimeout), 4, 0));
            }
            else
            {
               AV31RepositoryUserRecoveryPasswordKeyTimeout = (short)(context.localUtil.CToN( cgiGet( edtavRepositoryuserrecoverypasswordkeytimeout_Internalname), ",", "."));
               AssignAttri("", false, "AV31RepositoryUserRecoveryPasswordKeyTimeout", StringUtil.LTrimStr( (decimal)(AV31RepositoryUserRecoveryPasswordKeyTimeout), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositoryuserremembermetimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositoryuserremembermetimeout_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYUSERREMEMBERMETIMEOUT");
               GX_FocusControl = edtavRepositoryuserremembermetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30RepositoryUserRememberMeTimeout = 0;
               AssignAttri("", false, "AV30RepositoryUserRememberMeTimeout", StringUtil.LTrimStr( (decimal)(AV30RepositoryUserRememberMeTimeout), 4, 0));
            }
            else
            {
               AV30RepositoryUserRememberMeTimeout = (short)(context.localUtil.CToN( cgiGet( edtavRepositoryuserremembermetimeout_Internalname), ",", "."));
               AssignAttri("", false, "AV30RepositoryUserRememberMeTimeout", StringUtil.LTrimStr( (decimal)(AV30RepositoryUserRememberMeTimeout), 4, 0));
            }
            cmbavRepositoryuserremembermetype.CurrentValue = cgiGet( cmbavRepositoryuserremembermetype_Internalname);
            AV29RepositoryUserRememberMeType = cgiGet( cmbavRepositoryuserremembermetype_Internalname);
            AssignAttri("", false, "AV29RepositoryUserRememberMeType", AV29RepositoryUserRememberMeType);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepositorycachetimeout_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepositorycachetimeout_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREPOSITORYCACHETIMEOUT");
               GX_FocusControl = edtavRepositorycachetimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16RepositoryCacheTimeout = 0;
               AssignAttri("", false, "AV16RepositoryCacheTimeout", StringUtil.LTrimStr( (decimal)(AV16RepositoryCacheTimeout), 9, 0));
            }
            else
            {
               AV16RepositoryCacheTimeout = (int)(context.localUtil.CToN( cgiGet( edtavRepositorycachetimeout_Internalname), ",", "."));
               AssignAttri("", false, "AV16RepositoryCacheTimeout", StringUtil.LTrimStr( (decimal)(AV16RepositoryCacheTimeout), 9, 0));
            }
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
         E11182 ();
         if (returnInSub) return;
      }

      protected void E11182( )
      {
         /* Start Routine */
         returnInSub = false;
         AV12isLoginRepositoryAdm = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV8Errors);
         AssignAttri("", false, "AV12isLoginRepositoryAdm", AV12isLoginRepositoryAdm);
         AV6AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV13Language, out  AV8Errors);
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV6AuthenticationTypes.Count )
         {
            AV5AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV6AuthenticationTypes.Item(AV58GXV1));
            cmbavRepositorydefaultauthenticationtypename.addItem(AV5AuthenticationType.gxTpr_Name, AV5AuthenticationType.gxTpr_Description, 0);
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         AV19SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV10FilterSecPol, out  AV8Errors);
         AV59GXV2 = 1;
         while ( AV59GXV2 <= AV19SecurityPolicies.Count )
         {
            AV20SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV19SecurityPolicies.Item(AV59GXV2));
            cmbavRepositorydefaultsecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV20SecurityPolicy.gxTpr_Id), 9, 0)), AV20SecurityPolicy.gxTpr_Name, 0);
            AV59GXV2 = (int)(AV59GXV2+1);
         }
         AV18Roles = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getroles(AV9FilterRole, out  AV8Errors);
         AV60GXV3 = 1;
         while ( AV60GXV3 <= AV18Roles.Count )
         {
            AV17Role = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV18Roles.Item(AV60GXV3));
            cmbavRepositorydefaultroleid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV17Role.gxTpr_Id), 12, 0)), AV17Role.gxTpr_Name, 0);
            AV60GXV3 = (int)(AV60GXV3+1);
         }
         if ( (0==AV14pId) )
         {
            AV11Id = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getid();
            AssignAttri("", false, "AV11Id", StringUtil.LTrimStr( (decimal)(AV11Id), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Id), "ZZZZZZZZZZZ9"), context));
         }
         else
         {
            AV11Id = AV14pId;
            AssignAttri("", false, "AV11Id", StringUtil.LTrimStr( (decimal)(AV11Id), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11Id), "ZZZZZZZZZZZ9"), context));
         }
         AV15Repository.load( (int)(AV11Id));
         AV38RepositoryId = AV15Repository.gxTpr_Id;
         AssignAttri("", false, "AV38RepositoryId", StringUtil.LTrimStr( (decimal)(AV38RepositoryId), 9, 0));
         AV39RepositoryGUID = AV15Repository.gxTpr_Guid;
         AssignAttri("", false, "AV39RepositoryGUID", AV39RepositoryGUID);
         AV40RepositoryNameSpace = AV15Repository.gxTpr_Namespace;
         AssignAttri("", false, "AV40RepositoryNameSpace", AV40RepositoryNameSpace);
         AV41RepositoryName = AV15Repository.gxTpr_Name;
         AssignAttri("", false, "AV41RepositoryName", AV41RepositoryName);
         AV42RepositoryDescription = AV15Repository.gxTpr_Description;
         AssignAttri("", false, "AV42RepositoryDescription", AV42RepositoryDescription);
         AV43RepositoryDefaultAuthenticationTypeName = AV15Repository.gxTpr_Defaultauthenticationtypename;
         AssignAttri("", false, "AV43RepositoryDefaultAuthenticationTypeName", AV43RepositoryDefaultAuthenticationTypeName);
         AV44RepositorySessionExpiresOnIPChange = AV15Repository.gxTpr_Sessionexpiresonipchange;
         AssignAttri("", false, "AV44RepositorySessionExpiresOnIPChange", AV44RepositorySessionExpiresOnIPChange);
         AV45RepositoryAllowOauthAccess = AV15Repository.gxTpr_Allowoauthaccess;
         AssignAttri("", false, "AV45RepositoryAllowOauthAccess", AV45RepositoryAllowOauthAccess);
         AV32RepositoryUserIdentification = AV15Repository.gxTpr_Useridentification;
         AssignAttri("", false, "AV32RepositoryUserIdentification", AV32RepositoryUserIdentification);
         AV33RepositoryUserActivationMethod = AV15Repository.gxTpr_Useractivationmethod;
         AssignAttri("", false, "AV33RepositoryUserActivationMethod", AV33RepositoryUserActivationMethod);
         AV34RepositoryAutomaticActivationTimeout = AV15Repository.gxTpr_Userautomaticactivationtimeout;
         AssignAttri("", false, "AV34RepositoryAutomaticActivationTimeout", StringUtil.LTrimStr( (decimal)(AV34RepositoryAutomaticActivationTimeout), 4, 0));
         AV35RepositoryUserEmailsUnique = AV15Repository.gxTpr_Useremailisunique;
         AssignAttri("", false, "AV35RepositoryUserEmailsUnique", AV35RepositoryUserEmailsUnique);
         AV28RepositoryGenerateSessionStatistics = AV15Repository.gxTpr_Generatesessionstatistics;
         AssignAttri("", false, "AV28RepositoryGenerateSessionStatistics", AV28RepositoryGenerateSessionStatistics);
         AV29RepositoryUserRememberMeType = AV15Repository.gxTpr_Userremembermetype;
         AssignAttri("", false, "AV29RepositoryUserRememberMeType", AV29RepositoryUserRememberMeType);
         AV30RepositoryUserRememberMeTimeout = AV15Repository.gxTpr_Userremembermetimeout;
         AssignAttri("", false, "AV30RepositoryUserRememberMeTimeout", StringUtil.LTrimStr( (decimal)(AV30RepositoryUserRememberMeTimeout), 4, 0));
         AV31RepositoryUserRecoveryPasswordKeyTimeout = AV15Repository.gxTpr_Userrecoverypasswordkeytimeout;
         AssignAttri("", false, "AV31RepositoryUserRecoveryPasswordKeyTimeout", StringUtil.LTrimStr( (decimal)(AV31RepositoryUserRecoveryPasswordKeyTimeout), 4, 0));
         AV24RepositoryMinimumAmountCharactersInLogin = AV15Repository.gxTpr_Minimumamountcharactersinlogin;
         AssignAttri("", false, "AV24RepositoryMinimumAmountCharactersInLogin", StringUtil.LTrimStr( (decimal)(AV24RepositoryMinimumAmountCharactersInLogin), 2, 0));
         AV25RepositoryLoginAttemptsToLockUser = AV15Repository.gxTpr_Loginattemptstolockuser;
         AssignAttri("", false, "AV25RepositoryLoginAttemptsToLockUser", StringUtil.LTrimStr( (decimal)(AV25RepositoryLoginAttemptsToLockUser), 2, 0));
         AV49RepositoryLoginAttemptsToLockSession = AV15Repository.gxTpr_Loginattemptstolocksession;
         AssignAttri("", false, "AV49RepositoryLoginAttemptsToLockSession", StringUtil.LTrimStr( (decimal)(AV49RepositoryLoginAttemptsToLockSession), 2, 0));
         AV26RepositoryGiveAnonymousSession = AV15Repository.gxTpr_Giveanonymoussession;
         AssignAttri("", false, "AV26RepositoryGiveAnonymousSession", AV26RepositoryGiveAnonymousSession);
         AV27RepositoryUserSessionCacheTimeout = AV15Repository.gxTpr_Usersessioncachetimeout;
         AssignAttri("", false, "AV27RepositoryUserSessionCacheTimeout", StringUtil.LTrimStr( (decimal)(AV27RepositoryUserSessionCacheTimeout), 9, 0));
         AV16RepositoryCacheTimeout = AV15Repository.gxTpr_Cachetimeout;
         AssignAttri("", false, "AV16RepositoryCacheTimeout", StringUtil.LTrimStr( (decimal)(AV16RepositoryCacheTimeout), 9, 0));
         AV23RepositoryDefaultSecurityPolicyId = AV15Repository.gxTpr_Defaultsecuritypolicyid;
         AssignAttri("", false, "AV23RepositoryDefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0));
         AV46RepositoryDefaultRoleId = AV15Repository.gxTpr_Defaultroleid;
         AssignAttri("", false, "AV46RepositoryDefaultRoleId", StringUtil.LTrimStr( (decimal)(AV46RepositoryDefaultRoleId), 12, 0));
         AV21RepositoryRequiredFirstName = AV15Repository.gxTpr_Requiredfirstname;
         AssignAttri("", false, "AV21RepositoryRequiredFirstName", AV21RepositoryRequiredFirstName);
         AV22RepositoryRequiredLastName = AV15Repository.gxTpr_Requiredlastname;
         AssignAttri("", false, "AV22RepositoryRequiredLastName", AV22RepositoryRequiredLastName);
         AV36RepositoryRequiredEmail = AV15Repository.gxTpr_Requiredemail;
         AssignAttri("", false, "AV36RepositoryRequiredEmail", AV36RepositoryRequiredEmail);
         AV37RepositoryRequiredPassword = AV15Repository.gxTpr_Requiredpassword;
         AssignAttri("", false, "AV37RepositoryRequiredPassword", AV37RepositoryRequiredPassword);
         AV50RepositoryGAMUnblockUserTimeout = AV15Repository.gxTpr_Gamunblockusertimeout;
         AssignAttri("", false, "AV50RepositoryGAMUnblockUserTimeout", StringUtil.LTrimStr( (decimal)(AV50RepositoryGAMUnblockUserTimeout), 2, 0));
         AV48RepositoryEnableTracing = AV15Repository.gxTpr_Enabletracing;
         AssignAttri("", false, "AV48RepositoryEnableTracing", StringUtil.LTrimStr( (decimal)(AV48RepositoryEnableTracing), 4, 0));
         AV47RepositoryLogoutBehavior = AV15Repository.gxTpr_Gamremotelogoutbehavior;
         AssignAttri("", false, "AV47RepositoryLogoutBehavior", AV47RepositoryLogoutBehavior);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! AV12isLoginRepositoryAdm ) )
         {
            cmbavRepositorydefaultauthenticationtypename.Visible = 0;
            AssignProp("", false, cmbavRepositorydefaultauthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRepositorydefaultauthenticationtypename.Visible), 5, 0), true);
            divRepositorydefaultauthenticationtypename_cell_Class = "Invisible";
            AssignProp("", false, divRepositorydefaultauthenticationtypename_cell_Internalname, "Class", divRepositorydefaultauthenticationtypename_cell_Class, true);
         }
         else
         {
            cmbavRepositorydefaultauthenticationtypename.Visible = 1;
            AssignProp("", false, cmbavRepositorydefaultauthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRepositorydefaultauthenticationtypename.Visible), 5, 0), true);
            divRepositorydefaultauthenticationtypename_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divRepositorydefaultauthenticationtypename_cell_Internalname, "Class", divRepositorydefaultauthenticationtypename_cell_Class, true);
         }
         if ( ! ( ! AV12isLoginRepositoryAdm ) )
         {
            cmbavRepositorydefaultsecuritypolicyid.Visible = 0;
            AssignProp("", false, cmbavRepositorydefaultsecuritypolicyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRepositorydefaultsecuritypolicyid.Visible), 5, 0), true);
            divRepositorydefaultsecuritypolicyid_cell_Class = "Invisible";
            AssignProp("", false, divRepositorydefaultsecuritypolicyid_cell_Internalname, "Class", divRepositorydefaultsecuritypolicyid_cell_Class, true);
         }
         else
         {
            cmbavRepositorydefaultsecuritypolicyid.Visible = 1;
            AssignProp("", false, cmbavRepositorydefaultsecuritypolicyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRepositorydefaultsecuritypolicyid.Visible), 5, 0), true);
            divRepositorydefaultsecuritypolicyid_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divRepositorydefaultsecuritypolicyid_cell_Internalname, "Class", divRepositorydefaultsecuritypolicyid_cell_Class, true);
         }
         if ( ! ( ! AV12isLoginRepositoryAdm ) )
         {
            cmbavRepositorydefaultroleid.Visible = 0;
            AssignProp("", false, cmbavRepositorydefaultroleid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRepositorydefaultroleid.Visible), 5, 0), true);
            divRepositorydefaultroleid_cell_Class = "Invisible";
            AssignProp("", false, divRepositorydefaultroleid_cell_Internalname, "Class", divRepositorydefaultroleid_cell_Class, true);
         }
         else
         {
            cmbavRepositorydefaultroleid.Visible = 1;
            AssignProp("", false, cmbavRepositorydefaultroleid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRepositorydefaultroleid.Visible), 5, 0), true);
            divRepositorydefaultroleid_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divRepositorydefaultroleid_cell_Internalname, "Class", divRepositorydefaultroleid_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12182 ();
         if (returnInSub) return;
      }

      protected void E12182( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV15Repository.load( (int)(AV11Id));
         AV15Repository.gxTpr_Name = AV41RepositoryName;
         AV15Repository.gxTpr_Description = AV42RepositoryDescription;
         AV15Repository.gxTpr_Defaultauthenticationtypename = AV43RepositoryDefaultAuthenticationTypeName;
         AV15Repository.gxTpr_Sessionexpiresonipchange = AV44RepositorySessionExpiresOnIPChange;
         AV15Repository.gxTpr_Allowoauthaccess = AV45RepositoryAllowOauthAccess;
         AV15Repository.gxTpr_Useridentification = AV32RepositoryUserIdentification;
         AV15Repository.gxTpr_Useractivationmethod = AV33RepositoryUserActivationMethod;
         AV15Repository.gxTpr_Userautomaticactivationtimeout = AV34RepositoryAutomaticActivationTimeout;
         AV15Repository.gxTpr_Useremailisunique = AV35RepositoryUserEmailsUnique;
         AV15Repository.gxTpr_Generatesessionstatistics = AV28RepositoryGenerateSessionStatistics;
         AV15Repository.gxTpr_Userremembermetype = AV29RepositoryUserRememberMeType;
         AV15Repository.gxTpr_Userremembermetimeout = AV30RepositoryUserRememberMeTimeout;
         AV15Repository.gxTpr_Userrecoverypasswordkeytimeout = AV31RepositoryUserRecoveryPasswordKeyTimeout;
         AV15Repository.gxTpr_Minimumamountcharactersinlogin = AV24RepositoryMinimumAmountCharactersInLogin;
         AV15Repository.gxTpr_Loginattemptstolockuser = AV25RepositoryLoginAttemptsToLockUser;
         AV15Repository.gxTpr_Loginattemptstolocksession = AV49RepositoryLoginAttemptsToLockSession;
         AV15Repository.gxTpr_Giveanonymoussession = AV26RepositoryGiveAnonymousSession;
         AV15Repository.gxTpr_Usersessioncachetimeout = AV27RepositoryUserSessionCacheTimeout;
         AV15Repository.gxTpr_Cachetimeout = AV16RepositoryCacheTimeout;
         AV15Repository.gxTpr_Defaultsecuritypolicyid = AV23RepositoryDefaultSecurityPolicyId;
         AV15Repository.gxTpr_Defaultroleid = AV46RepositoryDefaultRoleId;
         AV15Repository.gxTpr_Requiredfirstname = AV21RepositoryRequiredFirstName;
         AV15Repository.gxTpr_Requiredlastname = AV22RepositoryRequiredLastName;
         AV15Repository.gxTpr_Requiredemail = AV36RepositoryRequiredEmail;
         AV15Repository.gxTpr_Requiredpassword = AV37RepositoryRequiredPassword;
         AV15Repository.gxTpr_Gamunblockusertimeout = AV50RepositoryGAMUnblockUserTimeout;
         AV15Repository.gxTpr_Enabletracing = (short)(NumberUtil.Val( StringUtil.Str( (decimal)(AV48RepositoryEnableTracing), 4, 0), "."));
         AV15Repository.gxTpr_Gamremotelogoutbehavior = AV47RepositoryLogoutBehavior;
         AV15Repository.save();
         if ( AV15Repository.success() )
         {
            context.CommitDataStores("gamrepositoryconfiguration",pr_default);
            GX_msglist.addItem(context.GetMessage( "Os dados foram atualizados com sucesso.", ""));
         }
         else
         {
            AV8Errors = AV15Repository.geterrors();
            AV61GXV4 = 1;
            while ( AV61GXV4 <= AV8Errors.Count )
            {
               AV7Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV8Errors.Item(AV61GXV4));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV7Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV7Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV61GXV4 = (int)(AV61GXV4+1);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E13182( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14pId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV14pId", StringUtil.LTrimStr( (decimal)(AV14pId), 12, 0));
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
         PA182( ) ;
         WS182( ) ;
         WE182( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281553111", true, true);
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
         context.AddJavascriptSource("gamrepositoryconfiguration.js", "?20214281553116", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavRepositorydefaultauthenticationtypename.Name = "vREPOSITORYDEFAULTAUTHENTICATIONTYPENAME";
         cmbavRepositorydefaultauthenticationtypename.WebTags = "";
         if ( cmbavRepositorydefaultauthenticationtypename.ItemCount > 0 )
         {
            AV43RepositoryDefaultAuthenticationTypeName = cmbavRepositorydefaultauthenticationtypename.getValidValue(AV43RepositoryDefaultAuthenticationTypeName);
            AssignAttri("", false, "AV43RepositoryDefaultAuthenticationTypeName", AV43RepositoryDefaultAuthenticationTypeName);
         }
         chkavRepositorysessionexpiresonipchange.Name = "vREPOSITORYSESSIONEXPIRESONIPCHANGE";
         chkavRepositorysessionexpiresonipchange.WebTags = "";
         chkavRepositorysessionexpiresonipchange.Caption = "A sessão de gam expira com a mudança de ip?";
         AssignProp("", false, chkavRepositorysessionexpiresonipchange_Internalname, "TitleCaption", chkavRepositorysessionexpiresonipchange.Caption, true);
         chkavRepositorysessionexpiresonipchange.CheckedValue = "false";
         AV44RepositorySessionExpiresOnIPChange = StringUtil.StrToBool( StringUtil.BoolToStr( AV44RepositorySessionExpiresOnIPChange));
         AssignAttri("", false, "AV44RepositorySessionExpiresOnIPChange", AV44RepositorySessionExpiresOnIPChange);
         chkavRepositoryallowoauthaccess.Name = "vREPOSITORYALLOWOAUTHACCESS";
         chkavRepositoryallowoauthaccess.WebTags = "";
         chkavRepositoryallowoauthaccess.Caption = "Permitir o acesso oauth (smart devices)";
         AssignProp("", false, chkavRepositoryallowoauthaccess_Internalname, "TitleCaption", chkavRepositoryallowoauthaccess.Caption, true);
         chkavRepositoryallowoauthaccess.CheckedValue = "false";
         AV45RepositoryAllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV45RepositoryAllowOauthAccess));
         AssignAttri("", false, "AV45RepositoryAllowOauthAccess", AV45RepositoryAllowOauthAccess);
         cmbavRepositorydefaultsecuritypolicyid.Name = "vREPOSITORYDEFAULTSECURITYPOLICYID";
         cmbavRepositorydefaultsecuritypolicyid.WebTags = "";
         if ( cmbavRepositorydefaultsecuritypolicyid.ItemCount > 0 )
         {
            AV23RepositoryDefaultSecurityPolicyId = (int)(NumberUtil.Val( cmbavRepositorydefaultsecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0))), "."));
            AssignAttri("", false, "AV23RepositoryDefaultSecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV23RepositoryDefaultSecurityPolicyId), 9, 0));
         }
         cmbavRepositorylogoutbehavior.Name = "vREPOSITORYLOGOUTBEHAVIOR";
         cmbavRepositorylogoutbehavior.WebTags = "";
         cmbavRepositorylogoutbehavior.addItem("clionl", "Só cliente", 0);
         cmbavRepositorylogoutbehavior.addItem("cliip", "Fornecedor de identidade e cliente", 0);
         cmbavRepositorylogoutbehavior.addItem("all", "Fornecedor de identidade e todos os clientes", 0);
         if ( cmbavRepositorylogoutbehavior.ItemCount > 0 )
         {
            AV47RepositoryLogoutBehavior = cmbavRepositorylogoutbehavior.getValidValue(AV47RepositoryLogoutBehavior);
            AssignAttri("", false, "AV47RepositoryLogoutBehavior", AV47RepositoryLogoutBehavior);
         }
         cmbavRepositorydefaultroleid.Name = "vREPOSITORYDEFAULTROLEID";
         cmbavRepositorydefaultroleid.WebTags = "";
         if ( cmbavRepositorydefaultroleid.ItemCount > 0 )
         {
            AV46RepositoryDefaultRoleId = (long)(NumberUtil.Val( cmbavRepositorydefaultroleid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46RepositoryDefaultRoleId), 12, 0))), "."));
            AssignAttri("", false, "AV46RepositoryDefaultRoleId", StringUtil.LTrimStr( (decimal)(AV46RepositoryDefaultRoleId), 12, 0));
         }
         cmbavRepositoryenabletracing.Name = "vREPOSITORYENABLETRACING";
         cmbavRepositoryenabletracing.WebTags = "";
         cmbavRepositoryenabletracing.addItem("0", "0 - Off", 0);
         cmbavRepositoryenabletracing.addItem("1", "1 - Depurar", 0);
         if ( cmbavRepositoryenabletracing.ItemCount > 0 )
         {
            AV48RepositoryEnableTracing = (short)(NumberUtil.Val( cmbavRepositoryenabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV48RepositoryEnableTracing), 4, 0))), "."));
            AssignAttri("", false, "AV48RepositoryEnableTracing", StringUtil.LTrimStr( (decimal)(AV48RepositoryEnableTracing), 4, 0));
         }
         cmbavRepositoryuseridentification.Name = "vREPOSITORYUSERIDENTIFICATION";
         cmbavRepositoryuseridentification.WebTags = "";
         cmbavRepositoryuseridentification.addItem("name", "Nome", 0);
         cmbavRepositoryuseridentification.addItem("email", "Email", 0);
         cmbavRepositoryuseridentification.addItem("namema", "Nome e Email", 0);
         if ( cmbavRepositoryuseridentification.ItemCount > 0 )
         {
            AV32RepositoryUserIdentification = cmbavRepositoryuseridentification.getValidValue(AV32RepositoryUserIdentification);
            AssignAttri("", false, "AV32RepositoryUserIdentification", AV32RepositoryUserIdentification);
         }
         cmbavRepositoryuseractivationmethod.Name = "vREPOSITORYUSERACTIVATIONMETHOD";
         cmbavRepositoryuseractivationmethod.WebTags = "";
         cmbavRepositoryuseractivationmethod.addItem("A", "Automático", 0);
         cmbavRepositoryuseractivationmethod.addItem("U", "Usuário", 0);
         cmbavRepositoryuseractivationmethod.addItem("D", "Administrador", 0);
         if ( cmbavRepositoryuseractivationmethod.ItemCount > 0 )
         {
            AV33RepositoryUserActivationMethod = cmbavRepositoryuseractivationmethod.getValidValue(AV33RepositoryUserActivationMethod);
            AssignAttri("", false, "AV33RepositoryUserActivationMethod", AV33RepositoryUserActivationMethod);
         }
         chkavRepositoryuseremailsunique.Name = "vREPOSITORYUSEREMAILSUNIQUE";
         chkavRepositoryuseremailsunique.WebTags = "";
         chkavRepositoryuseremailsunique.Caption = "E-mail do usuário é único?";
         AssignProp("", false, chkavRepositoryuseremailsunique_Internalname, "TitleCaption", chkavRepositoryuseremailsunique.Caption, true);
         chkavRepositoryuseremailsunique.CheckedValue = "false";
         AV35RepositoryUserEmailsUnique = StringUtil.StrToBool( StringUtil.BoolToStr( AV35RepositoryUserEmailsUnique));
         AssignAttri("", false, "AV35RepositoryUserEmailsUnique", AV35RepositoryUserEmailsUnique);
         chkavRepositoryrequiredemail.Name = "vREPOSITORYREQUIREDEMAIL";
         chkavRepositoryrequiredemail.WebTags = "";
         chkavRepositoryrequiredemail.Caption = "Email é obrigatório?";
         AssignProp("", false, chkavRepositoryrequiredemail_Internalname, "TitleCaption", chkavRepositoryrequiredemail.Caption, true);
         chkavRepositoryrequiredemail.CheckedValue = "false";
         AV36RepositoryRequiredEmail = StringUtil.StrToBool( StringUtil.BoolToStr( AV36RepositoryRequiredEmail));
         AssignAttri("", false, "AV36RepositoryRequiredEmail", AV36RepositoryRequiredEmail);
         chkavRepositoryrequiredpassword.Name = "vREPOSITORYREQUIREDPASSWORD";
         chkavRepositoryrequiredpassword.WebTags = "";
         chkavRepositoryrequiredpassword.Caption = "Senha é obrigatória?";
         AssignProp("", false, chkavRepositoryrequiredpassword_Internalname, "TitleCaption", chkavRepositoryrequiredpassword.Caption, true);
         chkavRepositoryrequiredpassword.CheckedValue = "false";
         AV37RepositoryRequiredPassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV37RepositoryRequiredPassword));
         AssignAttri("", false, "AV37RepositoryRequiredPassword", AV37RepositoryRequiredPassword);
         chkavRepositoryrequiredfirstname.Name = "vREPOSITORYREQUIREDFIRSTNAME";
         chkavRepositoryrequiredfirstname.WebTags = "";
         chkavRepositoryrequiredfirstname.Caption = "Nome é obrigatório?";
         AssignProp("", false, chkavRepositoryrequiredfirstname_Internalname, "TitleCaption", chkavRepositoryrequiredfirstname.Caption, true);
         chkavRepositoryrequiredfirstname.CheckedValue = "false";
         AV21RepositoryRequiredFirstName = StringUtil.StrToBool( StringUtil.BoolToStr( AV21RepositoryRequiredFirstName));
         AssignAttri("", false, "AV21RepositoryRequiredFirstName", AV21RepositoryRequiredFirstName);
         chkavRepositoryrequiredlastname.Name = "vREPOSITORYREQUIREDLASTNAME";
         chkavRepositoryrequiredlastname.WebTags = "";
         chkavRepositoryrequiredlastname.Caption = "Sobrenome é obrigatório?";
         AssignProp("", false, chkavRepositoryrequiredlastname_Internalname, "TitleCaption", chkavRepositoryrequiredlastname.Caption, true);
         chkavRepositoryrequiredlastname.CheckedValue = "false";
         AV22RepositoryRequiredLastName = StringUtil.StrToBool( StringUtil.BoolToStr( AV22RepositoryRequiredLastName));
         AssignAttri("", false, "AV22RepositoryRequiredLastName", AV22RepositoryRequiredLastName);
         cmbavRepositorygeneratesessionstatistics.Name = "vREPOSITORYGENERATESESSIONSTATISTICS";
         cmbavRepositorygeneratesessionstatistics.WebTags = "";
         cmbavRepositorygeneratesessionstatistics.addItem("None", "(Nenhum)", 0);
         cmbavRepositorygeneratesessionstatistics.addItem("Minimum", "Mínimo (Só usuários autenticados)", 0);
         cmbavRepositorygeneratesessionstatistics.addItem("Detail", "Detalhe (Usuários autenticados e anónimos)", 0);
         cmbavRepositorygeneratesessionstatistics.addItem("Full", "Log completo (Usuários autenticados e anónimos)", 0);
         if ( cmbavRepositorygeneratesessionstatistics.ItemCount > 0 )
         {
            AV28RepositoryGenerateSessionStatistics = cmbavRepositorygeneratesessionstatistics.getValidValue(AV28RepositoryGenerateSessionStatistics);
            AssignAttri("", false, "AV28RepositoryGenerateSessionStatistics", AV28RepositoryGenerateSessionStatistics);
         }
         chkavRepositorygiveanonymoussession.Name = "vREPOSITORYGIVEANONYMOUSSESSION";
         chkavRepositorygiveanonymoussession.WebTags = "";
         chkavRepositorygiveanonymoussession.Caption = "Dar sessão anônima web?";
         AssignProp("", false, chkavRepositorygiveanonymoussession_Internalname, "TitleCaption", chkavRepositorygiveanonymoussession.Caption, true);
         chkavRepositorygiveanonymoussession.CheckedValue = "false";
         AV26RepositoryGiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV26RepositoryGiveAnonymousSession));
         AssignAttri("", false, "AV26RepositoryGiveAnonymousSession", AV26RepositoryGiveAnonymousSession);
         cmbavRepositoryuserremembermetype.Name = "vREPOSITORYUSERREMEMBERMETYPE";
         cmbavRepositoryuserremembermetype.WebTags = "";
         cmbavRepositoryuserremembermetype.addItem("None", "(Nenhum)", 0);
         cmbavRepositoryuserremembermetype.addItem("Login", "Iniciar sessão", 0);
         cmbavRepositoryuserremembermetype.addItem("Auth", "Autenticação", 0);
         cmbavRepositoryuserremembermetype.addItem("Both", "Ambos", 0);
         if ( cmbavRepositoryuserremembermetype.ItemCount > 0 )
         {
            AV29RepositoryUserRememberMeType = cmbavRepositoryuserremembermetype.getValidValue(AV29RepositoryUserRememberMeType);
            AssignAttri("", false, "AV29RepositoryUserRememberMeType", AV29RepositoryUserRememberMeType);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         edtavRepositoryid_Internalname = "vREPOSITORYID";
         edtavRepositoryguid_Internalname = "vREPOSITORYGUID";
         edtavRepositorynamespace_Internalname = "vREPOSITORYNAMESPACE";
         edtavRepositoryname_Internalname = "vREPOSITORYNAME";
         edtavRepositorydescription_Internalname = "vREPOSITORYDESCRIPTION";
         cmbavRepositorydefaultauthenticationtypename_Internalname = "vREPOSITORYDEFAULTAUTHENTICATIONTYPENAME";
         divRepositorydefaultauthenticationtypename_cell_Internalname = "REPOSITORYDEFAULTAUTHENTICATIONTYPENAME_CELL";
         chkavRepositorysessionexpiresonipchange_Internalname = "vREPOSITORYSESSIONEXPIRESONIPCHANGE";
         chkavRepositoryallowoauthaccess_Internalname = "vREPOSITORYALLOWOAUTHACCESS";
         cmbavRepositorydefaultsecuritypolicyid_Internalname = "vREPOSITORYDEFAULTSECURITYPOLICYID";
         divRepositorydefaultsecuritypolicyid_cell_Internalname = "REPOSITORYDEFAULTSECURITYPOLICYID_CELL";
         cmbavRepositorylogoutbehavior_Internalname = "vREPOSITORYLOGOUTBEHAVIOR";
         cmbavRepositorydefaultroleid_Internalname = "vREPOSITORYDEFAULTROLEID";
         divRepositorydefaultroleid_cell_Internalname = "REPOSITORYDEFAULTROLEID_CELL";
         cmbavRepositoryenabletracing_Internalname = "vREPOSITORYENABLETRACING";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblUsers_title_Internalname = "USERS_TITLE";
         cmbavRepositoryuseridentification_Internalname = "vREPOSITORYUSERIDENTIFICATION";
         cmbavRepositoryuseractivationmethod_Internalname = "vREPOSITORYUSERACTIVATIONMETHOD";
         edtavRepositoryautomaticactivationtimeout_Internalname = "vREPOSITORYAUTOMATICACTIVATIONTIMEOUT";
         chkavRepositoryuseremailsunique_Internalname = "vREPOSITORYUSEREMAILSUNIQUE";
         chkavRepositoryrequiredemail_Internalname = "vREPOSITORYREQUIREDEMAIL";
         chkavRepositoryrequiredpassword_Internalname = "vREPOSITORYREQUIREDPASSWORD";
         chkavRepositoryrequiredfirstname_Internalname = "vREPOSITORYREQUIREDFIRSTNAME";
         chkavRepositoryrequiredlastname_Internalname = "vREPOSITORYREQUIREDLASTNAME";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblSession_title_Internalname = "SESSION_TITLE";
         cmbavRepositorygeneratesessionstatistics_Internalname = "vREPOSITORYGENERATESESSIONSTATISTICS";
         edtavRepositoryusersessioncachetimeout_Internalname = "vREPOSITORYUSERSESSIONCACHETIMEOUT";
         chkavRepositorygiveanonymoussession_Internalname = "vREPOSITORYGIVEANONYMOUSSESSION";
         edtavRepositoryloginattemptstolocksession_Internalname = "vREPOSITORYLOGINATTEMPTSTOLOCKSESSION";
         edtavRepositorygamunblockusertimeout_Internalname = "vREPOSITORYGAMUNBLOCKUSERTIMEOUT";
         edtavRepositoryloginattemptstolockuser_Internalname = "vREPOSITORYLOGINATTEMPTSTOLOCKUSER";
         edtavRepositoryminimumamountcharactersinlogin_Internalname = "vREPOSITORYMINIMUMAMOUNTCHARACTERSINLOGIN";
         edtavRepositoryuserrecoverypasswordkeytimeout_Internalname = "vREPOSITORYUSERRECOVERYPASSWORDKEYTIMEOUT";
         edtavRepositoryuserremembermetimeout_Internalname = "vREPOSITORYUSERREMEMBERMETIMEOUT";
         cmbavRepositoryuserremembermetype_Internalname = "vREPOSITORYUSERREMEMBERMETYPE";
         edtavRepositorycachetimeout_Internalname = "vREPOSITORYCACHETIMEOUT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
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
         chkavRepositorygiveanonymoussession.Caption = "  ";
         chkavRepositoryrequiredlastname.Caption = " ";
         chkavRepositoryrequiredfirstname.Caption = " ";
         chkavRepositoryrequiredpassword.Caption = " ";
         chkavRepositoryrequiredemail.Caption = " ";
         chkavRepositoryuseremailsunique.Caption = " ";
         chkavRepositoryallowoauthaccess.Caption = " ";
         chkavRepositorysessionexpiresonipchange.Caption = " ";
         edtavRepositorycachetimeout_Jsonclick = "";
         edtavRepositorycachetimeout_Enabled = 1;
         cmbavRepositoryuserremembermetype_Jsonclick = "";
         cmbavRepositoryuserremembermetype.Enabled = 1;
         edtavRepositoryuserremembermetimeout_Jsonclick = "";
         edtavRepositoryuserremembermetimeout_Enabled = 1;
         edtavRepositoryuserrecoverypasswordkeytimeout_Jsonclick = "";
         edtavRepositoryuserrecoverypasswordkeytimeout_Enabled = 1;
         edtavRepositoryminimumamountcharactersinlogin_Jsonclick = "";
         edtavRepositoryminimumamountcharactersinlogin_Enabled = 1;
         edtavRepositoryloginattemptstolockuser_Jsonclick = "";
         edtavRepositoryloginattemptstolockuser_Enabled = 1;
         edtavRepositorygamunblockusertimeout_Jsonclick = "";
         edtavRepositorygamunblockusertimeout_Enabled = 1;
         edtavRepositoryloginattemptstolocksession_Jsonclick = "";
         edtavRepositoryloginattemptstolocksession_Enabled = 1;
         chkavRepositorygiveanonymoussession.Enabled = 1;
         edtavRepositoryusersessioncachetimeout_Jsonclick = "";
         edtavRepositoryusersessioncachetimeout_Enabled = 1;
         cmbavRepositorygeneratesessionstatistics_Jsonclick = "";
         cmbavRepositorygeneratesessionstatistics.Enabled = 1;
         chkavRepositoryrequiredlastname.Enabled = 1;
         chkavRepositoryrequiredfirstname.Enabled = 1;
         chkavRepositoryrequiredpassword.Enabled = 1;
         chkavRepositoryrequiredemail.Enabled = 1;
         chkavRepositoryuseremailsunique.Enabled = 1;
         edtavRepositoryautomaticactivationtimeout_Jsonclick = "";
         edtavRepositoryautomaticactivationtimeout_Enabled = 1;
         cmbavRepositoryuseractivationmethod_Jsonclick = "";
         cmbavRepositoryuseractivationmethod.Enabled = 1;
         cmbavRepositoryuseridentification_Jsonclick = "";
         cmbavRepositoryuseridentification.Enabled = 1;
         cmbavRepositoryenabletracing_Jsonclick = "";
         cmbavRepositoryenabletracing.Enabled = 1;
         cmbavRepositorydefaultroleid_Jsonclick = "";
         cmbavRepositorydefaultroleid.Enabled = 1;
         cmbavRepositorydefaultroleid.Visible = 1;
         divRepositorydefaultroleid_cell_Class = "col-xs-12 col-sm-6";
         cmbavRepositorylogoutbehavior_Jsonclick = "";
         cmbavRepositorylogoutbehavior.Enabled = 1;
         cmbavRepositorydefaultsecuritypolicyid_Jsonclick = "";
         cmbavRepositorydefaultsecuritypolicyid.Enabled = 1;
         cmbavRepositorydefaultsecuritypolicyid.Visible = 1;
         divRepositorydefaultsecuritypolicyid_cell_Class = "col-xs-12 col-sm-6";
         chkavRepositoryallowoauthaccess.Enabled = 1;
         chkavRepositorysessionexpiresonipchange.Enabled = 1;
         cmbavRepositorydefaultauthenticationtypename_Jsonclick = "";
         cmbavRepositorydefaultauthenticationtypename.Enabled = 1;
         cmbavRepositorydefaultauthenticationtypename.Visible = 1;
         divRepositorydefaultauthenticationtypename_cell_Class = "col-xs-12 col-sm-6";
         edtavRepositorydescription_Jsonclick = "";
         edtavRepositorydescription_Enabled = 1;
         edtavRepositoryname_Jsonclick = "";
         edtavRepositoryname_Enabled = 1;
         edtavRepositorynamespace_Jsonclick = "";
         edtavRepositorynamespace_Enabled = 1;
         edtavRepositoryguid_Jsonclick = "";
         edtavRepositoryguid_Enabled = 1;
         edtavRepositoryid_Jsonclick = "";
         edtavRepositoryid_Enabled = 1;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "";
         Gxuitabspanel_tabs_Pagecount = 3;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Configuração do repositório";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E12182',iparms:[{av:'AV11Id',fld:'vID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV41RepositoryName',fld:'vREPOSITORYNAME',pic:''},{av:'AV42RepositoryDescription',fld:'vREPOSITORYDESCRIPTION',pic:''},{av:'cmbavRepositorydefaultauthenticationtypename'},{av:'AV43RepositoryDefaultAuthenticationTypeName',fld:'vREPOSITORYDEFAULTAUTHENTICATIONTYPENAME',pic:''},{av:'cmbavRepositoryuseridentification'},{av:'AV32RepositoryUserIdentification',fld:'vREPOSITORYUSERIDENTIFICATION',pic:''},{av:'cmbavRepositoryuseractivationmethod'},{av:'AV33RepositoryUserActivationMethod',fld:'vREPOSITORYUSERACTIVATIONMETHOD',pic:''},{av:'AV34RepositoryAutomaticActivationTimeout',fld:'vREPOSITORYAUTOMATICACTIVATIONTIMEOUT',pic:'ZZZ9'},{av:'cmbavRepositorygeneratesessionstatistics'},{av:'AV28RepositoryGenerateSessionStatistics',fld:'vREPOSITORYGENERATESESSIONSTATISTICS',pic:''},{av:'cmbavRepositoryuserremembermetype'},{av:'AV29RepositoryUserRememberMeType',fld:'vREPOSITORYUSERREMEMBERMETYPE',pic:''},{av:'AV30RepositoryUserRememberMeTimeout',fld:'vREPOSITORYUSERREMEMBERMETIMEOUT',pic:'ZZZ9'},{av:'AV31RepositoryUserRecoveryPasswordKeyTimeout',fld:'vREPOSITORYUSERRECOVERYPASSWORDKEYTIMEOUT',pic:'ZZZ9'},{av:'AV24RepositoryMinimumAmountCharactersInLogin',fld:'vREPOSITORYMINIMUMAMOUNTCHARACTERSINLOGIN',pic:'Z9'},{av:'AV25RepositoryLoginAttemptsToLockUser',fld:'vREPOSITORYLOGINATTEMPTSTOLOCKUSER',pic:'Z9'},{av:'AV49RepositoryLoginAttemptsToLockSession',fld:'vREPOSITORYLOGINATTEMPTSTOLOCKSESSION',pic:'Z9'},{av:'AV27RepositoryUserSessionCacheTimeout',fld:'vREPOSITORYUSERSESSIONCACHETIMEOUT',pic:'ZZZZZZZZ9'},{av:'AV16RepositoryCacheTimeout',fld:'vREPOSITORYCACHETIMEOUT',pic:'ZZZZZZZZ9'},{av:'cmbavRepositorydefaultsecuritypolicyid'},{av:'AV23RepositoryDefaultSecurityPolicyId',fld:'vREPOSITORYDEFAULTSECURITYPOLICYID',pic:'ZZZZZZZZ9'},{av:'cmbavRepositorydefaultroleid'},{av:'AV46RepositoryDefaultRoleId',fld:'vREPOSITORYDEFAULTROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV50RepositoryGAMUnblockUserTimeout',fld:'vREPOSITORYGAMUNBLOCKUSERTIMEOUT',pic:'Z9'},{av:'cmbavRepositoryenabletracing'},{av:'AV48RepositoryEnableTracing',fld:'vREPOSITORYENABLETRACING',pic:'ZZZ9'},{av:'cmbavRepositorylogoutbehavior'},{av:'AV47RepositoryLogoutBehavior',fld:'vREPOSITORYLOGOUTBEHAVIOR',pic:''},{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_REPOSITORYLOGOUTBEHAVIOR","{handler:'Validv_Repositorylogoutbehavior',iparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_REPOSITORYLOGOUTBEHAVIOR",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_REPOSITORYENABLETRACING","{handler:'Validv_Repositoryenabletracing',iparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_REPOSITORYENABLETRACING",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_REPOSITORYUSERIDENTIFICATION","{handler:'Validv_Repositoryuseridentification',iparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_REPOSITORYUSERIDENTIFICATION",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_REPOSITORYUSERACTIVATIONMETHOD","{handler:'Validv_Repositoryuseractivationmethod',iparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_REPOSITORYUSERACTIVATIONMETHOD",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_REPOSITORYGENERATESESSIONSTATISTICS","{handler:'Validv_Repositorygeneratesessionstatistics',iparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_REPOSITORYGENERATESESSIONSTATISTICS",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
         setEventMetadata("VALIDV_REPOSITORYUSERREMEMBERMETYPE","{handler:'Validv_Repositoryuserremembermetype',iparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]");
         setEventMetadata("VALIDV_REPOSITORYUSERREMEMBERMETYPE",",oparms:[{av:'AV44RepositorySessionExpiresOnIPChange',fld:'vREPOSITORYSESSIONEXPIRESONIPCHANGE',pic:''},{av:'AV45RepositoryAllowOauthAccess',fld:'vREPOSITORYALLOWOAUTHACCESS',pic:''},{av:'AV35RepositoryUserEmailsUnique',fld:'vREPOSITORYUSEREMAILSUNIQUE',pic:''},{av:'AV36RepositoryRequiredEmail',fld:'vREPOSITORYREQUIREDEMAIL',pic:''},{av:'AV37RepositoryRequiredPassword',fld:'vREPOSITORYREQUIREDPASSWORD',pic:''},{av:'AV21RepositoryRequiredFirstName',fld:'vREPOSITORYREQUIREDFIRSTNAME',pic:''},{av:'AV22RepositoryRequiredLastName',fld:'vREPOSITORYREQUIREDLASTNAME',pic:''},{av:'AV26RepositoryGiveAnonymousSession',fld:'vREPOSITORYGIVEANONYMOUSSESSION',pic:''}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         TempTags = "";
         AV39RepositoryGUID = "";
         AV40RepositoryNameSpace = "";
         AV41RepositoryName = "";
         AV42RepositoryDescription = "";
         AV43RepositoryDefaultAuthenticationTypeName = "";
         AV47RepositoryLogoutBehavior = "";
         lblUsers_title_Jsonclick = "";
         AV32RepositoryUserIdentification = "";
         AV33RepositoryUserActivationMethod = "";
         lblSession_title_Jsonclick = "";
         AV28RepositoryGenerateSessionStatistics = "";
         AV29RepositoryUserRememberMeType = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV6AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV13Language = "";
         AV5AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV19SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV10FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV20SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV18Roles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV9FilterRole = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV17Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV15Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV7Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamrepositoryconfiguration__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamrepositoryconfiguration__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavRepositoryid_Enabled = 0;
         edtavRepositoryguid_Enabled = 0;
         edtavRepositorynamespace_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV48RepositoryEnableTracing ;
      private short AV34RepositoryAutomaticActivationTimeout ;
      private short AV49RepositoryLoginAttemptsToLockSession ;
      private short AV50RepositoryGAMUnblockUserTimeout ;
      private short AV25RepositoryLoginAttemptsToLockUser ;
      private short AV24RepositoryMinimumAmountCharactersInLogin ;
      private short AV31RepositoryUserRecoveryPasswordKeyTimeout ;
      private short AV30RepositoryUserRememberMeTimeout ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int AV38RepositoryId ;
      private int edtavRepositoryid_Enabled ;
      private int edtavRepositoryguid_Enabled ;
      private int edtavRepositorynamespace_Enabled ;
      private int edtavRepositoryname_Enabled ;
      private int edtavRepositorydescription_Enabled ;
      private int AV23RepositoryDefaultSecurityPolicyId ;
      private int edtavRepositoryautomaticactivationtimeout_Enabled ;
      private int AV27RepositoryUserSessionCacheTimeout ;
      private int edtavRepositoryusersessioncachetimeout_Enabled ;
      private int edtavRepositoryloginattemptstolocksession_Enabled ;
      private int edtavRepositorygamunblockusertimeout_Enabled ;
      private int edtavRepositoryloginattemptstolockuser_Enabled ;
      private int edtavRepositoryminimumamountcharactersinlogin_Enabled ;
      private int edtavRepositoryuserrecoverypasswordkeytimeout_Enabled ;
      private int edtavRepositoryuserremembermetimeout_Enabled ;
      private int AV16RepositoryCacheTimeout ;
      private int edtavRepositorycachetimeout_Enabled ;
      private int AV58GXV1 ;
      private int AV59GXV2 ;
      private int AV60GXV3 ;
      private int AV61GXV4 ;
      private int idxLst ;
      private long AV14pId ;
      private long wcpOAV14pId ;
      private long AV11Id ;
      private long AV46RepositoryDefaultRoleId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gxuitabspanel_tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string edtavRepositoryid_Internalname ;
      private string TempTags ;
      private string edtavRepositoryid_Jsonclick ;
      private string edtavRepositoryguid_Internalname ;
      private string AV39RepositoryGUID ;
      private string edtavRepositoryguid_Jsonclick ;
      private string edtavRepositorynamespace_Internalname ;
      private string AV40RepositoryNameSpace ;
      private string edtavRepositorynamespace_Jsonclick ;
      private string edtavRepositoryname_Internalname ;
      private string AV41RepositoryName ;
      private string edtavRepositoryname_Jsonclick ;
      private string edtavRepositorydescription_Internalname ;
      private string AV42RepositoryDescription ;
      private string edtavRepositorydescription_Jsonclick ;
      private string divRepositorydefaultauthenticationtypename_cell_Internalname ;
      private string divRepositorydefaultauthenticationtypename_cell_Class ;
      private string cmbavRepositorydefaultauthenticationtypename_Internalname ;
      private string AV43RepositoryDefaultAuthenticationTypeName ;
      private string cmbavRepositorydefaultauthenticationtypename_Jsonclick ;
      private string chkavRepositorysessionexpiresonipchange_Internalname ;
      private string chkavRepositoryallowoauthaccess_Internalname ;
      private string divRepositorydefaultsecuritypolicyid_cell_Internalname ;
      private string divRepositorydefaultsecuritypolicyid_cell_Class ;
      private string cmbavRepositorydefaultsecuritypolicyid_Internalname ;
      private string cmbavRepositorydefaultsecuritypolicyid_Jsonclick ;
      private string cmbavRepositorylogoutbehavior_Internalname ;
      private string AV47RepositoryLogoutBehavior ;
      private string cmbavRepositorylogoutbehavior_Jsonclick ;
      private string divRepositorydefaultroleid_cell_Internalname ;
      private string divRepositorydefaultroleid_cell_Class ;
      private string cmbavRepositorydefaultroleid_Internalname ;
      private string cmbavRepositorydefaultroleid_Jsonclick ;
      private string cmbavRepositoryenabletracing_Internalname ;
      private string cmbavRepositoryenabletracing_Jsonclick ;
      private string lblUsers_title_Internalname ;
      private string lblUsers_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string cmbavRepositoryuseridentification_Internalname ;
      private string AV32RepositoryUserIdentification ;
      private string cmbavRepositoryuseridentification_Jsonclick ;
      private string cmbavRepositoryuseractivationmethod_Internalname ;
      private string AV33RepositoryUserActivationMethod ;
      private string cmbavRepositoryuseractivationmethod_Jsonclick ;
      private string edtavRepositoryautomaticactivationtimeout_Internalname ;
      private string edtavRepositoryautomaticactivationtimeout_Jsonclick ;
      private string chkavRepositoryuseremailsunique_Internalname ;
      private string chkavRepositoryrequiredemail_Internalname ;
      private string chkavRepositoryrequiredpassword_Internalname ;
      private string chkavRepositoryrequiredfirstname_Internalname ;
      private string chkavRepositoryrequiredlastname_Internalname ;
      private string lblSession_title_Internalname ;
      private string lblSession_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavRepositorygeneratesessionstatistics_Internalname ;
      private string AV28RepositoryGenerateSessionStatistics ;
      private string cmbavRepositorygeneratesessionstatistics_Jsonclick ;
      private string edtavRepositoryusersessioncachetimeout_Internalname ;
      private string edtavRepositoryusersessioncachetimeout_Jsonclick ;
      private string chkavRepositorygiveanonymoussession_Internalname ;
      private string edtavRepositoryloginattemptstolocksession_Internalname ;
      private string edtavRepositoryloginattemptstolocksession_Jsonclick ;
      private string edtavRepositorygamunblockusertimeout_Internalname ;
      private string edtavRepositorygamunblockusertimeout_Jsonclick ;
      private string edtavRepositoryloginattemptstolockuser_Internalname ;
      private string edtavRepositoryloginattemptstolockuser_Jsonclick ;
      private string edtavRepositoryminimumamountcharactersinlogin_Internalname ;
      private string edtavRepositoryminimumamountcharactersinlogin_Jsonclick ;
      private string edtavRepositoryuserrecoverypasswordkeytimeout_Internalname ;
      private string edtavRepositoryuserrecoverypasswordkeytimeout_Jsonclick ;
      private string edtavRepositoryuserremembermetimeout_Internalname ;
      private string edtavRepositoryuserremembermetimeout_Jsonclick ;
      private string cmbavRepositoryuserremembermetype_Internalname ;
      private string AV29RepositoryUserRememberMeType ;
      private string cmbavRepositoryuserremembermetype_Jsonclick ;
      private string edtavRepositorycachetimeout_Internalname ;
      private string edtavRepositorycachetimeout_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV13Language ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool AV44RepositorySessionExpiresOnIPChange ;
      private bool AV45RepositoryAllowOauthAccess ;
      private bool AV35RepositoryUserEmailsUnique ;
      private bool AV36RepositoryRequiredEmail ;
      private bool AV37RepositoryRequiredPassword ;
      private bool AV21RepositoryRequiredFirstName ;
      private bool AV22RepositoryRequiredLastName ;
      private bool AV26RepositoryGiveAnonymousSession ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12isLoginRepositoryAdm ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_pId ;
      private GXCombobox cmbavRepositorydefaultauthenticationtypename ;
      private GXCheckbox chkavRepositorysessionexpiresonipchange ;
      private GXCheckbox chkavRepositoryallowoauthaccess ;
      private GXCombobox cmbavRepositorydefaultsecuritypolicyid ;
      private GXCombobox cmbavRepositorylogoutbehavior ;
      private GXCombobox cmbavRepositorydefaultroleid ;
      private GXCombobox cmbavRepositoryenabletracing ;
      private GXCombobox cmbavRepositoryuseridentification ;
      private GXCombobox cmbavRepositoryuseractivationmethod ;
      private GXCheckbox chkavRepositoryuseremailsunique ;
      private GXCheckbox chkavRepositoryrequiredemail ;
      private GXCheckbox chkavRepositoryrequiredpassword ;
      private GXCheckbox chkavRepositoryrequiredfirstname ;
      private GXCheckbox chkavRepositoryrequiredlastname ;
      private GXCombobox cmbavRepositorygeneratesessionstatistics ;
      private GXCheckbox chkavRepositorygiveanonymoussession ;
      private GXCombobox cmbavRepositoryuserremembermetype ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV6AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV18Roles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV19SecurityPolicies ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV5AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV7Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV9FilterRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV10FilterSecPol ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV15Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV17Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV20SecurityPolicy ;
   }

   public class gamrepositoryconfiguration__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamrepositoryconfiguration__default : DataStoreHelperBase, IDataStoreHelper
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
