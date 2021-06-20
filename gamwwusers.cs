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
namespace GeneXus.Programs {
   public class gamwwusers : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gamwwusers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamwwusers( IGxContext context )
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
         cmbavFilauttype = new GXCombobox();
         cmbavFilrol = new GXCombobox();
         cmbavGridactions = new GXCombobox();
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
               nRC_GXsfl_52 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_52"), "."));
               nGXsfl_52_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_52_idx"), "."));
               sGXsfl_52_idx = GetPar( "sGXsfl_52_idx");
               edtavBtnrole_Title = GetNextPar( );
               AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_52_Refreshing);
               edtavBtnsetpwd_Title = GetNextPar( );
               AssignProp("", false, edtavBtnsetpwd_Internalname, "Title", edtavBtnsetpwd_Title, !bGXsfl_52_Refreshing);
               edtavBtnpermissions_Title = GetNextPar( );
               AssignProp("", false, edtavBtnpermissions_Internalname, "Title", edtavBtnpermissions_Title, !bGXsfl_52_Refreshing);
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
               AV76ManageFiltersExecutionStep = (short)(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV67ColumnsSelector);
               AV95Pgmname = GetPar( "Pgmname");
               AV18FilAutType = GetPar( "FilAutType");
               AV40Search = GetPar( "Search");
               AV41FilRol = (long)(NumberUtil.Val( GetPar( "FilRol"), "."));
               edtavBtnrole_Title = GetNextPar( );
               AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_52_Refreshing);
               edtavBtnsetpwd_Title = GetNextPar( );
               AssignProp("", false, edtavBtnsetpwd_Internalname, "Title", edtavBtnsetpwd_Title, !bGXsfl_52_Refreshing);
               edtavBtnpermissions_Title = GetNextPar( );
               AssignProp("", false, edtavBtnpermissions_Internalname, "Title", edtavBtnpermissions_Title, !bGXsfl_52_Refreshing);
               AV83FirstIndex = (short)(NumberUtil.Val( GetPar( "FirstIndex"), "."));
               AV86IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
               AV87IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
               AV88IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
               AV24GAMUserIsDeleted = StringUtil.StrToBool( GetPar( "GAMUserIsDeleted"));
               AV30IsAuthorized_BtnRole = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnRole"));
               AV89IsAuthorized_BtnPermissions = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnPermissions"));
               AV31IsAuthorized_BtnSetPwd = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnSetPwd"));
               AV23GAMUserIsAutoRegisteredUser = StringUtil.StrToBool( GetPar( "GAMUserIsAutoRegisteredUser"));
               AV44IsAuthorized_Name = StringUtil.StrToBool( GetPar( "IsAuthorized_Name"));
               AV90IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV95Pgmname, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV86IsAuthorized_Display, AV87IsAuthorized_Update, AV88IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV89IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV90IsAuthorized_Insert) ;
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
            return "gamwwusers_Execute" ;
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
         PA1Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1Q2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142815555636", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwwusers.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV86IsAuthorized_Display, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV87IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV88IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISDELETED", GetSecureSignedToken( "", AV24GAMUserIsDeleted, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV89IsAuthorized_BtnPermissions, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISAUTOREGISTEREDUSER", GetSecureSignedToken( "", AV23GAMUserIsAutoRegisteredUser, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV90IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_52", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_52), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV80ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV80ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV85GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV73DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV73DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV67ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV67ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFIRSTINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83FirstIndex), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV86IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV86IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV87IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV87IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV88IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV88IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISDELETED", AV24GAMUserIsDeleted);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISDELETED", GetSecureSignedToken( "", AV24GAMUserIsDeleted, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNROLE", AV30IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNPERMISSIONS", AV89IsAuthorized_BtnPermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV89IsAuthorized_BtnPermissions, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNSETPWD", AV31IsAuthorized_BtnSetPwd);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISAUTOREGISTEREDUSER", AV23GAMUserIsAutoRegisteredUser);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISAUTOREGISTEREDUSER", GetSecureSignedToken( "", AV23GAMUserIsAutoRegisteredUser, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NAME", AV44IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV53GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV53GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV90IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV90IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "vBTNROLE_Title", StringUtil.RTrim( edtavBtnrole_Title));
         GxWebStd.gx_hidden_field( context, "vBTNSETPWD_Title", StringUtil.RTrim( edtavBtnsetpwd_Title));
         GxWebStd.gx_hidden_field( context, "vBTNPERMISSIONS_Title", StringUtil.RTrim( edtavBtnpermissions_Title));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE1Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1Q2( ) ;
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
         return formatLink("gamwwusers.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "GAMWWUsers" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuários" ;
      }

      protected void WB1Q0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "TableCellsWidthAuto", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(52), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUsers.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(52), 2, 0)+","+"null"+");", "Seleciona colunas", bttBtneditcolumns_Jsonclick, 0, "Seleciona colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUsers.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-8", "Right", "top", "", "", "div");
            wb_table1_26_1Q2( true) ;
         }
         else
         {
            wb_table1_26_1Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_26_1Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "left", "top", "", "", "div");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"52\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavGridactions_Class+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnrole_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( edtavBtnrole_Title) ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnpermissions_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( edtavBtnpermissions_Title) ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavBtnsetpwd_Class+"\" "+" style=\""+((edtavBtnsetpwd_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( edtavBtnsetpwd_Title) ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavName_Class+"\" "+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nome") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavFirstname_Class+"\" "+" style=\""+((edtavFirstname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nome") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavLastname_Class+"\" "+" style=\""+((edtavLastname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Sobrenome") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavAuthenticationtypename_Class+"\" "+" style=\""+((edtavAuthenticationtypename_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Autenticação") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
               GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV82GridActions), 4, 0, ".", "")));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12BtnRole));
               GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnrole_Title));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnrole_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnrole_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnrole_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV14BtnPermissions));
               GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnpermissions_Title));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnpermissions_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnpermissions_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnpermissions_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV13BtnSetPwd));
               GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnsetpwd_Title));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavBtnsetpwd_Class));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnsetpwd_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnsetpwd_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnsetpwd_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", AV34Name);
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavName_Class));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavName_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV22FirstName));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavFirstname_Class));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstname_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFirstname_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV33LastName));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavLastname_Class));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLastname_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLastname_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV9AuthenticationTypeName));
               GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavAuthenticationtypename_Class));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAuthenticationtypename_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV28GUID));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGuid_Enabled), 5, 0, ".", "")));
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
         if ( wbEnd == 52 )
         {
            wbEnd = 0;
            nRC_GXsfl_52 = (int)(nGXsfl_52_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV26GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV27GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV85GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV73DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV73DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV67ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamuserscount_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GAMUsersCount), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39GAMUsersCount), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamuserscount_Jsonclick, 0, "Attribute", "", "", "", "", edtavGamuserscount_Visible, 1, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_GAMWWUsers.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 52 )
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

      protected void START1Q2( )
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
            Form.Meta.addItem("description", "Usuários", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1Q0( ) ;
      }

      protected void WS1Q2( )
      {
         START1Q2( ) ;
         EVT1Q2( ) ;
      }

      protected void EVT1Q2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E111Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E151Q2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_52_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
                              SubsflControlProps_522( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV82GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV82GridActions), 4, 0));
                              AV12BtnRole = cgiGet( edtavBtnrole_Internalname);
                              AssignAttri("", false, edtavBtnrole_Internalname, AV12BtnRole);
                              AV14BtnPermissions = cgiGet( edtavBtnpermissions_Internalname);
                              AssignAttri("", false, edtavBtnpermissions_Internalname, AV14BtnPermissions);
                              AV13BtnSetPwd = cgiGet( edtavBtnsetpwd_Internalname);
                              AssignAttri("", false, edtavBtnsetpwd_Internalname, AV13BtnSetPwd);
                              AV34Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV34Name);
                              AV22FirstName = cgiGet( edtavFirstname_Internalname);
                              AssignAttri("", false, edtavFirstname_Internalname, AV22FirstName);
                              AV33LastName = cgiGet( edtavLastname_Internalname);
                              AssignAttri("", false, edtavLastname_Internalname, AV33LastName);
                              AV9AuthenticationTypeName = cgiGet( edtavAuthenticationtypename_Internalname);
                              AssignAttri("", false, edtavAuthenticationtypename_Internalname, AV9AuthenticationTypeName);
                              AV28GUID = cgiGet( edtavGuid_Internalname);
                              AssignAttri("", false, edtavGuid_Internalname, AV28GUID);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E161Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E171Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E181Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191Q2 ();
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

      protected void WE1Q2( )
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

      protected void PA1Q2( )
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
               GX_FocusControl = edtavSearch_Internalname;
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
         SubsflControlProps_522( ) ;
         while ( nGXsfl_52_idx <= nRC_GXsfl_52 )
         {
            sendrow_522( ) ;
            nGXsfl_52_idx = ((subGrid_Islastpage==1)&&(nGXsfl_52_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_522( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV76ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV67ColumnsSelector ,
                                       string AV95Pgmname ,
                                       string AV18FilAutType ,
                                       string AV40Search ,
                                       long AV41FilRol ,
                                       short AV83FirstIndex ,
                                       bool AV86IsAuthorized_Display ,
                                       bool AV87IsAuthorized_Update ,
                                       bool AV88IsAuthorized_Delete ,
                                       bool AV24GAMUserIsDeleted ,
                                       bool AV30IsAuthorized_BtnRole ,
                                       bool AV89IsAuthorized_BtnPermissions ,
                                       bool AV31IsAuthorized_BtnSetPwd ,
                                       bool AV23GAMUserIsAutoRegisteredUser ,
                                       bool AV44IsAuthorized_Name ,
                                       bool AV90IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E171Q2 ();
         GRID_nCurrentRecord = 0;
         RF1Q2( ) ;
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
         if ( cmbavFilauttype.ItemCount > 0 )
         {
            AV18FilAutType = cmbavFilauttype.getValidValue(AV18FilAutType);
            AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV18FilAutType);
            AssignProp("", false, cmbavFilauttype_Internalname, "Values", cmbavFilauttype.ToJavascriptSource(), true);
         }
         if ( cmbavFilrol.ItemCount > 0 )
         {
            AV41FilRol = (long)(NumberUtil.Val( cmbavFilrol.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0))), "."));
            AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilrol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0));
            AssignProp("", false, cmbavFilrol_Internalname, "Values", cmbavFilrol.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV95Pgmname = "GAMWWUsers";
         context.Gx_err = 0;
         edtavBtnrole_Enabled = 0;
         AssignProp("", false, edtavBtnrole_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnrole_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavBtnpermissions_Enabled = 0;
         AssignProp("", false, edtavBtnpermissions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnpermissions_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavBtnsetpwd_Enabled = 0;
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnsetpwd_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void RF1Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 52;
         /* Execute user event: Refresh */
         E171Q2 ();
         nGXsfl_52_idx = 1;
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_522( ) ;
         bGXsfl_52_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_522( ) ;
            E181Q2 ();
            if ( ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_52_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E181Q2 ();
            }
            wbEnd = 52;
            WB1Q0( ) ;
         }
         bGXsfl_52_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFIRSTINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83FirstIndex), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV86IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV86IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV87IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV87IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV88IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV88IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISDELETED", AV24GAMUserIsDeleted);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISDELETED", GetSecureSignedToken( "", AV24GAMUserIsDeleted, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNROLE", AV30IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNPERMISSIONS", AV89IsAuthorized_BtnPermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV89IsAuthorized_BtnPermissions, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNSETPWD", AV31IsAuthorized_BtnSetPwd);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         GxWebStd.gx_boolean_hidden_field( context, "vGAMUSERISAUTOREGISTEREDUSER", AV23GAMUserIsAutoRegisteredUser);
         GxWebStd.gx_hidden_field( context, "gxhash_vGAMUSERISAUTOREGISTEREDUSER", GetSecureSignedToken( "", AV23GAMUserIsAutoRegisteredUser, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NAME", AV44IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV90IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV90IsAuthorized_Insert, context));
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
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV95Pgmname, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV86IsAuthorized_Display, AV87IsAuthorized_Update, AV88IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV89IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV90IsAuthorized_Insert) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV95Pgmname, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV86IsAuthorized_Display, AV87IsAuthorized_Update, AV88IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV89IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV90IsAuthorized_Insert) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV95Pgmname, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV86IsAuthorized_Display, AV87IsAuthorized_Update, AV88IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV89IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV90IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV95Pgmname, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV86IsAuthorized_Display, AV87IsAuthorized_Update, AV88IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV89IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV90IsAuthorized_Insert) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV76ManageFiltersExecutionStep, AV67ColumnsSelector, AV95Pgmname, AV18FilAutType, AV40Search, AV41FilRol, AV83FirstIndex, AV86IsAuthorized_Display, AV87IsAuthorized_Update, AV88IsAuthorized_Delete, AV24GAMUserIsDeleted, AV30IsAuthorized_BtnRole, AV89IsAuthorized_BtnPermissions, AV31IsAuthorized_BtnSetPwd, AV23GAMUserIsAutoRegisteredUser, AV44IsAuthorized_Name, AV90IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV95Pgmname = "GAMWWUsers";
         context.Gx_err = 0;
         edtavBtnrole_Enabled = 0;
         AssignProp("", false, edtavBtnrole_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnrole_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavBtnpermissions_Enabled = 0;
         AssignProp("", false, edtavBtnpermissions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnpermissions_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavBtnsetpwd_Enabled = 0;
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBtnsetpwd_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavFirstname_Enabled = 0;
         AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavLastname_Enabled = 0;
         AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavAuthenticationtypename_Enabled = 0;
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E161Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV80ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV73DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV67ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_52 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_52"), ",", "."));
            AV26GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."));
            AV27GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."));
            AV85GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."));
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV40Search = cgiGet( edtavSearch_Internalname);
            AssignAttri("", false, "AV40Search", AV40Search);
            cmbavFilauttype.Name = cmbavFilauttype_Internalname;
            cmbavFilauttype.CurrentValue = cgiGet( cmbavFilauttype_Internalname);
            AV18FilAutType = cgiGet( cmbavFilauttype_Internalname);
            AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
            cmbavFilrol.Name = cmbavFilrol_Internalname;
            cmbavFilrol.CurrentValue = cgiGet( cmbavFilrol_Internalname);
            AV41FilRol = (long)(NumberUtil.Val( cgiGet( cmbavFilrol_Internalname), "."));
            AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGamuserscount_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGamuserscount_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGAMUSERSCOUNT");
               GX_FocusControl = edtavGamuserscount_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39GAMUsersCount = 0;
               AssignAttri("", false, "AV39GAMUsersCount", StringUtil.LTrimStr( (decimal)(AV39GAMUsersCount), 4, 0));
            }
            else
            {
               AV39GAMUsersCount = (short)(context.localUtil.CToN( cgiGet( edtavGamuserscount_Internalname), ",", "."));
               AssignAttri("", false, "AV39GAMUsersCount", StringUtil.LTrimStr( (decimal)(AV39GAMUsersCount), 4, 0));
            }
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
         E161Q2 ();
         if (returnInSub) return;
      }

      protected void E161Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE>";
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "Caption", Gridpaginationbar_Caption);
         Gridpaginationbar_Pagestoshow = 0;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "PagesToShow", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0));
         Gridpaginationbar_Showlast = false;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "ShowLast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         edtavGamuserscount_Visible = 0;
         AssignProp("", false, edtavGamuserscount_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGamuserscount_Visible), 5, 0), true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV49HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         GXt_boolean1 = AV44IsAuthorized_Name;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV44IsAuthorized_Name = GXt_boolean1;
         AssignAttri("", false, "AV44IsAuthorized_Name", AV44IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV44IsAuthorized_Name, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Usuários";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV73DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV73DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         cmbavFilauttype.removeAllItems();
         cmbavFilauttype.addItem("", "Todos", 0);
         AV10AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV20FilterAutType, out  AV17Errors);
         AV93GXV1 = 1;
         while ( AV93GXV1 <= AV10AuthenticationTypes.Count )
         {
            AV8AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV10AuthenticationTypes.Item(AV93GXV1));
            cmbavFilauttype.addItem(AV8AuthenticationType.gxTpr_Name, AV8AuthenticationType.gxTpr_Description, 0);
            AV93GXV1 = (int)(AV93GXV1+1);
         }
         cmbavFilrol.removeAllItems();
         cmbavFilrol.addItem("0", "Todos", 0);
         cmbavFilrol.addItem("-1", "Sem perfil", 0);
         AV45Roles = AV36Repository.getroles(AV43FilterRoles, out  AV17Errors);
         AV94GXV2 = 1;
         while ( AV94GXV2 <= AV45Roles.Count )
         {
            AV42Role = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV45Roles.Item(AV94GXV2));
            cmbavFilrol.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV42Role.gxTpr_Id), 12, 0)), AV42Role.gxTpr_Name, 0);
            AV94GXV2 = (int)(AV94GXV2+1);
         }
         edtavBtnrole_Title = "Perfis";
         AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_52_Refreshing);
         edtavBtnsetpwd_Title = "Senha";
         AssignProp("", false, edtavBtnsetpwd_Internalname, "Title", edtavBtnsetpwd_Title, !bGXsfl_52_Refreshing);
         edtavBtnpermissions_Title = "Permissões";
         AssignProp("", false, edtavBtnpermissions_Internalname, "Title", edtavBtnpermissions_Title, !bGXsfl_52_Refreshing);
      }

      protected void E171Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV36Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV50WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV76ManageFiltersExecutionStep == 1 )
         {
            AV76ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV76ManageFiltersExecutionStep == 2 )
         {
            AV76ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV72Session.Get("GAMWWUsersColumnsSelector"), "") != 0 )
         {
            AV55ColumnsSelectorXML = AV72Session.Get("GAMWWUsersColumnsSelector");
            AV67ColumnsSelector.FromXml(AV55ColumnsSelectorXML, null, "WWPColumnsSelector", "RastreamentoTCC");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S152 ();
            if (returnInSub) return;
         }
         edtavName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), !bGXsfl_52_Refreshing);
         edtavFirstname_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavFirstname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFirstname_Visible), 5, 0), !bGXsfl_52_Refreshing);
         edtavLastname_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavLastname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLastname_Visible), 5, 0), !bGXsfl_52_Refreshing);
         edtavAuthenticationtypename_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV67ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Visible), 5, 0), !bGXsfl_52_Refreshing);
         AV26GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV26GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV26GridCurrentPage), 10, 0));
         GXt_char3 = AV85GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV95Pgmname, out  GXt_char3) ;
         AV85GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV85GridAppliedFilters", AV85GridAppliedFilters);
         AV26GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV26GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV26GridCurrentPage), 10, 0));
         AV6GridPageSize = subGrid_Rows;
         AV19Filter.gxTpr_Authenticationtypename = AV18FilAutType;
         AV19Filter.gxTpr_Loadcustomattributes = true;
         AV19Filter.gxTpr_Returnanonymoususer = false;
         AV19Filter.gxTpr_Limit = (int)(AV6GridPageSize+1);
         AV83FirstIndex = (short)((AV26GridCurrentPage-1)*AV6GridPageSize+1);
         AssignAttri("", false, "AV83FirstIndex", StringUtil.LTrimStr( (decimal)(AV83FirstIndex), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFIRSTINDEX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83FirstIndex), "ZZZ9"), context));
         AV19Filter.gxTpr_Start = AV83FirstIndex-1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Search)) )
         {
            AV19Filter.gxTpr_Searchable = "%"+AV40Search;
         }
         if ( AV41FilRol == -1 )
         {
            AV19Filter.gxTpr_Withoutroles = true;
         }
         else
         {
            AV19Filter.gxTpr_Roleid = AV41FilRol;
         }
         AV25GAMUsers = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusersorderby(AV19Filter, 0, out  AV17Errors);
         if ( cmbavFilauttype.ItemCount == 2 )
         {
            edtavAuthenticationtypename_Visible = 0;
            AssignProp("", false, edtavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAuthenticationtypename_Visible), 5, 0), !bGXsfl_52_Refreshing);
         }
         if ( AV25GAMUsers.Count == AV19Filter.gxTpr_Limit )
         {
            AV7GridRecordCount = (long)(AV26GridCurrentPage*AV6GridPageSize+1);
            AV27GridPageCount = (long)(AV26GridCurrentPage+1);
            AssignAttri("", false, "AV27GridPageCount", StringUtil.LTrimStr( (decimal)(AV27GridPageCount), 10, 0));
         }
         else
         {
            AV7GridRecordCount = (long)((AV26GridCurrentPage-1)*AV6GridPageSize+AV25GAMUsers.Count);
            AV27GridPageCount = AV26GridCurrentPage;
            AssignAttri("", false, "AV27GridPageCount", StringUtil.LTrimStr( (decimal)(AV27GridPageCount), 10, 0));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36Repository", AV36Repository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
      }

      protected void E121Q2( )
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
            AV35PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV35PageToGo) ;
         }
      }

      protected void E131Q2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E181Q2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV64i = 1;
         while ( AV64i <= AV83FirstIndex - 1 )
         {
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 52;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_522( ) ;
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
            if ( isFullAjaxMode( ) && ! bGXsfl_52_Refreshing )
            {
               context.DoAjaxLoad(52, GridRow);
            }
            AV64i = (long)(AV64i+1);
         }
         AV96GXV3 = 1;
         while ( AV96GXV3 <= AV25GAMUsers.Count )
         {
            AV38User = ((GeneXus.Programs.genexussecurity.SdtGAMUser)AV25GAMUsers.Item(AV96GXV3));
            AV9AuthenticationTypeName = AV38User.gxTpr_Authenticationtypename;
            AssignAttri("", false, edtavAuthenticationtypename_Internalname, AV9AuthenticationTypeName);
            AV28GUID = AV38User.gxTpr_Guid;
            AssignAttri("", false, edtavGuid_Internalname, AV28GUID);
            AV34Name = AV38User.gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV34Name);
            AV22FirstName = AV38User.gxTpr_Firstname;
            AssignAttri("", false, edtavFirstname_Internalname, AV22FirstName);
            AV33LastName = AV38User.gxTpr_Lastname;
            AssignAttri("", false, edtavLastname_Internalname, AV33LastName);
            if ( AV38User.gxTpr_Isenabledinrepository )
            {
               edtavName_Class = "ReadonlyAttribute";
               edtavFirstname_Class = "ReadonlyAttribute";
               edtavLastname_Class = "ReadonlyAttribute";
               edtavAuthenticationtypename_Class = "ReadonlyAttribute";
            }
            else
            {
               edtavName_Class = "AttributeInactive";
               edtavFirstname_Class = "AttributeInactive";
               edtavLastname_Class = "AttributeInactive";
               edtavAuthenticationtypename_Class = "AttributeInactive";
            }
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            if ( AV86IsAuthorized_Display )
            {
               cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Mostrar", "fa fa-search", "", "", "", "", "", "", ""), 0);
            }
            if ( AV87IsAuthorized_Update )
            {
               if ( ! ( ( StringUtil.StrCmp(StringUtil.Trim( AV28GUID), StringUtil.Trim( AV36Repository.gxTpr_Anonymoususerguid)) == 0 ) || AV38User.gxTpr_Isautoregistereduser ) )
               {
                  cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( AV88IsAuthorized_Delete )
            {
               if ( ! ( ( StringUtil.StrCmp(StringUtil.Trim( AV28GUID), StringUtil.Trim( AV36Repository.gxTpr_Anonymoususerguid)) == 0 ) || AV24GAMUserIsDeleted ) )
               {
                  cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( cmbavGridactions.ItemCount == 1 )
            {
               cmbavGridactions_Class = "Invisible";
            }
            else
            {
               cmbavGridactions_Class = "ConvertToDDO";
            }
            AV12BtnRole = "<i class=\"fa fa-cog\"></i>";
            AssignAttri("", false, edtavBtnrole_Internalname, AV12BtnRole);
            if ( AV30IsAuthorized_BtnRole )
            {
               edtavBtnrole_Link = formatLink("gamwwuserroles.aspx", new object[] {UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)))}, new string[] {"UserId"}) ;
            }
            AV14BtnPermissions = "<i class=\"fa fa-lock\"></i>";
            AssignAttri("", false, edtavBtnpermissions_Internalname, AV14BtnPermissions);
            if ( AV89IsAuthorized_BtnPermissions )
            {
               edtavBtnpermissions_Link = formatLink("gamwwuserpermissions.aspx", new object[] {UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID))),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"UserId","pApplicationId"}) ;
            }
            AV13BtnSetPwd = "<i class=\"fa fa-key\"></i>";
            AssignAttri("", false, edtavBtnsetpwd_Internalname, AV13BtnSetPwd);
            if ( AV31IsAuthorized_BtnSetPwd )
            {
               if ( ! ( ( StringUtil.StrCmp(StringUtil.Trim( AV28GUID), StringUtil.Trim( AV36Repository.gxTpr_Anonymoususerguid)) == 0 ) || AV23GAMUserIsAutoRegisteredUser ) )
               {
                  edtavBtnsetpwd_Link = formatLink("gamsetpassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)))}, new string[] {"UserId"}) ;
                  edtavBtnsetpwd_Class = "Attribute";
               }
               else
               {
                  edtavBtnsetpwd_Link = "";
                  edtavBtnsetpwd_Class = "Invisible";
               }
            }
            if ( AV44IsAuthorized_Name )
            {
               edtavName_Link = formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)))}, new string[] {"Mode","UserId"}) ;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 52;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_522( ) ;
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
            if ( isFullAjaxMode( ) && ! bGXsfl_52_Refreshing )
            {
               context.DoAjaxLoad(52, GridRow);
            }
            AV96GXV3 = (int)(AV96GXV3+1);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV82GridActions), 4, 0));
      }

      protected void E141Q2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV55ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV67ColumnsSelector.FromJSonString(AV55ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "GAMWWUsersColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV55ColumnsSelectorXML)) ? "" : AV67ColumnsSelector.ToXml(false, true, "WWPColumnsSelector", "RastreamentoTCC"))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36Repository", AV36Repository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
      }

      protected void E111Q2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if (returnInSub) return;
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("GAMWWUsersFilters")),UrlEncode(StringUtil.RTrim(AV95Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV76ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("GAMWWUsersFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV76ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV76ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV76ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV77ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "GAMWWUsersFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV77ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV95Pgmname+"GridState",  AV77ManageFiltersXml) ;
               AV53GridState.FromXml(AV77ManageFiltersXml, null, "WWPGridState", "RastreamentoTCC");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
               context.DoAjaxRefresh();
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
         cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV18FilAutType);
         AssignProp("", false, cmbavFilauttype_Internalname, "Values", cmbavFilauttype.ToJavascriptSource(), true);
         cmbavFilrol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0));
         AssignProp("", false, cmbavFilrol_Internalname, "Values", cmbavFilrol.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36Repository", AV36Repository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
      }

      protected void E191Q2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV82GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S182 ();
            if (returnInSub) return;
         }
         else if ( AV82GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S192 ();
            if (returnInSub) return;
         }
         else if ( AV82GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S202 ();
            if (returnInSub) return;
         }
         AV82GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV82GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV82GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36Repository", AV36Repository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
      }

      protected void E151Q2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV90IsAuthorized_Insert )
         {
            CallWebObject(formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36Repository", AV36Repository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67ColumnsSelector", AV67ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Filter", AV19Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV80ManageFiltersData", AV80ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53GridState", AV53GridState);
      }

      protected void S152( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV67ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&Name",  "",  "WWP_GAM_Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&FirstName",  "",  "WWP_GAM_FirstName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&LastName",  "",  "WWP_GAM_LastName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV67ColumnsSelector,  "&AuthenticationTypeName",  "",  "WWP_GAM_Authentication",  true,  "") ;
         GXt_char3 = AV62UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "GAMWWUsersColumnsSelector", out  GXt_char3) ;
         AV62UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62UserCustomValue)) ) )
         {
            AV84ColumnsSelectorAux.FromXml(AV62UserCustomValue, null, "WWPColumnsSelector", "RastreamentoTCC");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV84ColumnsSelectorAux, ref  AV67ColumnsSelector) ;
         }
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV86IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV86IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV86IsAuthorized_Display", AV86IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV86IsAuthorized_Display, context));
         GXt_boolean1 = AV87IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV87IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV87IsAuthorized_Update", AV87IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV87IsAuthorized_Update, context));
         GXt_boolean1 = AV88IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV88IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV88IsAuthorized_Delete", AV88IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV88IsAuthorized_Delete, context));
         GXt_boolean1 = AV30IsAuthorized_BtnRole;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwuserroles_Execute", out  GXt_boolean1) ;
         AV30IsAuthorized_BtnRole = GXt_boolean1;
         AssignAttri("", false, "AV30IsAuthorized_BtnRole", AV30IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV30IsAuthorized_BtnRole, context));
         if ( ! ( AV30IsAuthorized_BtnRole ) )
         {
            edtavBtnrole_Visible = 0;
            AssignProp("", false, edtavBtnrole_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnrole_Visible), 5, 0), !bGXsfl_52_Refreshing);
         }
         GXt_boolean1 = AV89IsAuthorized_BtnPermissions;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamexamplewwuserpermissions_Execute", out  GXt_boolean1) ;
         AV89IsAuthorized_BtnPermissions = GXt_boolean1;
         AssignAttri("", false, "AV89IsAuthorized_BtnPermissions", AV89IsAuthorized_BtnPermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPERMISSIONS", GetSecureSignedToken( "", AV89IsAuthorized_BtnPermissions, context));
         if ( ! ( AV89IsAuthorized_BtnPermissions ) )
         {
            edtavBtnpermissions_Visible = 0;
            AssignProp("", false, edtavBtnpermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnpermissions_Visible), 5, 0), !bGXsfl_52_Refreshing);
         }
         GXt_boolean1 = AV31IsAuthorized_BtnSetPwd;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamsetpassword_Execute", out  GXt_boolean1) ;
         AV31IsAuthorized_BtnSetPwd = GXt_boolean1;
         AssignAttri("", false, "AV31IsAuthorized_BtnSetPwd", AV31IsAuthorized_BtnSetPwd);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNSETPWD", GetSecureSignedToken( "", AV31IsAuthorized_BtnSetPwd, context));
         if ( ! ( AV31IsAuthorized_BtnSetPwd ) )
         {
            edtavBtnsetpwd_Visible = 0;
            AssignProp("", false, edtavBtnsetpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnsetpwd_Visible), 5, 0), !bGXsfl_52_Refreshing);
         }
         GXt_boolean1 = AV90IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserentry_Execute", out  GXt_boolean1) ;
         AV90IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV90IsAuthorized_Insert", AV90IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV90IsAuthorized_Insert, context));
         if ( ! ( AV90IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV80ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "GAMWWUsersFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV80ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV40Search = "";
         AssignAttri("", false, "AV40Search", AV40Search);
         AV18FilAutType = "";
         AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
         AV41FilRol = 0;
         AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
      }

      protected void S182( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV86IsAuthorized_Display )
         {
            CallWebObject(formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S192( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV87IsAuthorized_Update )
         {
            CallWebObject(formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S202( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV88IsAuthorized_Delete )
         {
            CallWebObject(formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(StringUtil.Trim( AV28GUID)))}, new string[] {"Mode","UserId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV72Session.Get(AV95Pgmname+"GridState"), "") == 0 )
         {
            AV53GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV95Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         else
         {
            AV53GridState.FromXml(AV72Session.Get(AV95Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV53GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV53GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV53GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV97GXV4 = 1;
         while ( AV97GXV4 <= AV53GridState.gxTpr_Filtervalues.Count )
         {
            AV54GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV53GridState.gxTpr_Filtervalues.Item(AV97GXV4));
            if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "SEARCH") == 0 )
            {
               AV40Search = AV54GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40Search", AV40Search);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "FILAUTTYPE") == 0 )
            {
               AV18FilAutType = AV54GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "FILROL") == 0 )
            {
               AV41FilRol = (long)(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
            }
            AV97GXV4 = (int)(AV97GXV4+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV53GridState.FromXml(AV72Session.Get(AV95Pgmname+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         AV53GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV53GridState,  "SEARCH",  "Procurar",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40Search)),  0,  AV40Search,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV53GridState,  "FILAUTTYPE",  "Autenticação",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18FilAutType)),  0,  AV18FilAutType,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV53GridState,  "FILROL",  "Perfil",  !(0==AV41FilRol),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0)),  "") ;
         AV53GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV53GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV95Pgmname+"GridState",  AV53GridState.ToXml(false, true, "WWPGridState", "RastreamentoTCC")) ;
      }

      protected void wb_table1_26_1Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table100x100", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTopPaddingTop2'>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV80ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavSearch_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSearch_Internalname, "Procurar", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSearch_Internalname, AV40Search, StringUtil.RTrim( context.localUtil.Format( AV40Search, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Login / nome / email", edtavSearch_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSearch_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMWWUsers.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilauttype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilauttype_Internalname, "Autenticação", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_52_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilauttype, cmbavFilauttype_Internalname, StringUtil.RTrim( AV18FilAutType), 1, cmbavFilauttype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFilauttype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, "HLP_GAMWWUsers.htm");
            cmbavFilauttype.CurrentValue = StringUtil.RTrim( AV18FilAutType);
            AssignProp("", false, cmbavFilauttype_Internalname, "Values", (string)(cmbavFilauttype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellFormGroupMarginBottom5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilrol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilrol_Internalname, "Perfil", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_52_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilrol, cmbavFilrol_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0)), 1, cmbavFilrol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavFilrol.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, "HLP_GAMWWUsers.htm");
            cmbavFilrol.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0));
            AssignProp("", false, cmbavFilrol_Internalname, "Values", (string)(cmbavFilrol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_26_1Q2e( true) ;
         }
         else
         {
            wb_table1_26_1Q2e( false) ;
         }
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
         PA1Q2( ) ;
         WS1Q2( ) ;
         WE1Q2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815564633", true, true);
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
         context.AddJavascriptSource("gamwwusers.js", "?202142815564638", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_522( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_52_idx;
         edtavBtnrole_Internalname = "vBTNROLE_"+sGXsfl_52_idx;
         edtavBtnpermissions_Internalname = "vBTNPERMISSIONS_"+sGXsfl_52_idx;
         edtavBtnsetpwd_Internalname = "vBTNSETPWD_"+sGXsfl_52_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_52_idx;
         edtavFirstname_Internalname = "vFIRSTNAME_"+sGXsfl_52_idx;
         edtavLastname_Internalname = "vLASTNAME_"+sGXsfl_52_idx;
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME_"+sGXsfl_52_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_52_idx;
      }

      protected void SubsflControlProps_fel_522( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_52_fel_idx;
         edtavBtnrole_Internalname = "vBTNROLE_"+sGXsfl_52_fel_idx;
         edtavBtnpermissions_Internalname = "vBTNPERMISSIONS_"+sGXsfl_52_fel_idx;
         edtavBtnsetpwd_Internalname = "vBTNSETPWD_"+sGXsfl_52_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_52_fel_idx;
         edtavFirstname_Internalname = "vFIRSTNAME_"+sGXsfl_52_fel_idx;
         edtavLastname_Internalname = "vLASTNAME_"+sGXsfl_52_fel_idx;
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME_"+sGXsfl_52_fel_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_52_fel_idx;
      }

      protected void sendrow_522( )
      {
         SubsflControlProps_522( ) ;
         WB1Q0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_52_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_52_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_52_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 53,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_52_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV82GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV82GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV82GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV82GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_52_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,53);\"" : " "),(string)"",(bool)true});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV82GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_52_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnrole_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnrole_Enabled!=0)&&(edtavBtnrole_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 54,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnrole_Internalname,StringUtil.RTrim( AV12BtnRole),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnrole_Enabled!=0)&&(edtavBtnrole_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,54);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnrole_Link,(string)"",(string)"Perfis",(string)"",(string)edtavBtnrole_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnrole_Visible,(int)edtavBtnrole_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnpermissions_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnpermissions_Enabled!=0)&&(edtavBtnpermissions_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 55,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnpermissions_Internalname,StringUtil.RTrim( AV14BtnPermissions),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnpermissions_Enabled!=0)&&(edtavBtnpermissions_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,55);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnpermissions_Link,(string)"",(string)"Permissões",(string)"",(string)edtavBtnpermissions_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnpermissions_Visible,(int)edtavBtnpermissions_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavBtnsetpwd_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavBtnsetpwd_Enabled!=0)&&(edtavBtnsetpwd_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 56,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = edtavBtnsetpwd_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnsetpwd_Internalname,StringUtil.RTrim( AV13BtnSetPwd),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavBtnsetpwd_Enabled!=0)&&(edtavBtnsetpwd_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,56);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnsetpwd_Link,(string)"",(string)"Atribuir nova senha",(string)"",(string)edtavBtnsetpwd_Jsonclick,(short)0,(string)edtavBtnsetpwd_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnsetpwd_Visible,(int)edtavBtnsetpwd_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 57,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = edtavName_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,(string)AV34Name,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,57);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavName_Link,(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)edtavName_Class,(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavName_Visible,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)52,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavFirstname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 58,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = edtavFirstname_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFirstname_Internalname,StringUtil.RTrim( AV22FirstName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavFirstname_Enabled!=0)&&(edtavFirstname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,58);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFirstname_Jsonclick,(short)0,(string)edtavFirstname_Class,(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtavFirstname_Visible,(int)edtavFirstname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavLastname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 59,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = edtavLastname_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLastname_Internalname,StringUtil.RTrim( AV33LastName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavLastname_Enabled!=0)&&(edtavLastname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,59);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLastname_Jsonclick,(short)0,(string)edtavLastname_Class,(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtavLastname_Visible,(int)edtavLastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavAuthenticationtypename_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 60,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = edtavAuthenticationtypename_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAuthenticationtypename_Internalname,StringUtil.RTrim( AV9AuthenticationTypeName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAuthenticationtypename_Enabled!=0)&&(edtavAuthenticationtypename_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,60);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAuthenticationtypename_Jsonclick,(short)0,(string)edtavAuthenticationtypename_Class,(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtavAuthenticationtypename_Visible,(int)edtavAuthenticationtypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 61,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGuid_Internalname,StringUtil.RTrim( AV28GUID),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavGuid_Enabled!=0)&&(edtavGuid_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,61);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGuid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavGuid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)52,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes1Q2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_52_idx = ((subGrid_Islastpage==1)&&(nGXsfl_52_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_522( ) ;
         }
         /* End function sendrow_522 */
      }

      protected void init_web_controls( )
      {
         cmbavFilauttype.Name = "vFILAUTTYPE";
         cmbavFilauttype.WebTags = "";
         if ( cmbavFilauttype.ItemCount > 0 )
         {
            AV18FilAutType = cmbavFilauttype.getValidValue(AV18FilAutType);
            AssignAttri("", false, "AV18FilAutType", AV18FilAutType);
         }
         cmbavFilrol.Name = "vFILROL";
         cmbavFilrol.WebTags = "";
         if ( cmbavFilrol.ItemCount > 0 )
         {
            AV41FilRol = (long)(NumberUtil.Val( cmbavFilrol.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41FilRol), 12, 0))), "."));
            AssignAttri("", false, "AV41FilRol", StringUtil.LTrimStr( (decimal)(AV41FilRol), 12, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_52_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV82GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV82GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV82GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavSearch_Internalname = "vSEARCH";
         cmbavFilauttype_Internalname = "vFILAUTTYPE";
         cmbavFilrol_Internalname = "vFILROL";
         divTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtavBtnrole_Internalname = "vBTNROLE";
         edtavBtnpermissions_Internalname = "vBTNPERMISSIONS";
         edtavBtnsetpwd_Internalname = "vBTNSETPWD";
         edtavName_Internalname = "vNAME";
         edtavFirstname_Internalname = "vFIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         edtavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME";
         edtavGuid_Internalname = "vGUID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         edtavGamuserscount_Internalname = "vGAMUSERSCOUNT";
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
         edtavGuid_Jsonclick = "";
         edtavGuid_Visible = 0;
         edtavAuthenticationtypename_Jsonclick = "";
         edtavLastname_Jsonclick = "";
         edtavFirstname_Jsonclick = "";
         edtavName_Jsonclick = "";
         edtavBtnsetpwd_Jsonclick = "";
         edtavBtnpermissions_Jsonclick = "";
         edtavBtnrole_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         cmbavFilrol_Jsonclick = "";
         cmbavFilrol.Enabled = 1;
         cmbavFilauttype_Jsonclick = "";
         cmbavFilauttype.Enabled = 1;
         edtavSearch_Jsonclick = "";
         edtavSearch_Enabled = 1;
         edtavGamuserscount_Jsonclick = "";
         edtavGamuserscount_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavName_Link = "";
         edtavBtnsetpwd_Link = "";
         edtavBtnpermissions_Link = "";
         edtavBtnrole_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavGuid_Enabled = 1;
         edtavAuthenticationtypename_Enabled = 1;
         edtavAuthenticationtypename_Class = "Attribute";
         edtavAuthenticationtypename_Visible = -1;
         edtavLastname_Enabled = 1;
         edtavLastname_Class = "Attribute";
         edtavLastname_Visible = -1;
         edtavFirstname_Enabled = 1;
         edtavFirstname_Class = "Attribute";
         edtavFirstname_Visible = -1;
         edtavName_Enabled = 1;
         edtavName_Class = "Attribute";
         edtavName_Visible = -1;
         edtavBtnsetpwd_Enabled = 1;
         edtavBtnsetpwd_Class = "Attribute";
         edtavBtnsetpwd_Visible = -1;
         edtavBtnpermissions_Enabled = 1;
         edtavBtnpermissions_Visible = -1;
         edtavBtnrole_Enabled = 1;
         edtavBtnrole_Visible = -1;
         cmbavGridactions_Class = "ConvertToDDO";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Seleciona colunas";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Columnssortvalues = "|||";
         Ddo_grid_Columnids = "4:Name|5:FirstName|6:LastName|7:AuthenticationTypeName";
         Ddo_grid_Gridinternalname = "";
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
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuários";
         subGrid_Rows = 0;
         edtavBtnpermissions_Title = "";
         edtavBtnsetpwd_Title = "";
         edtavBtnrole_Title = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E121Q2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E131Q2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E181Q2',iparms:[{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV9AuthenticationTypeName',fld:'vAUTHENTICATIONTYPENAME',pic:''},{av:'AV28GUID',fld:'vGUID',pic:''},{av:'AV34Name',fld:'vNAME',pic:''},{av:'AV22FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV33LastName',fld:'vLASTNAME',pic:''},{av:'edtavName_Class',ctrl:'vNAME',prop:'Class'},{av:'edtavFirstname_Class',ctrl:'vFIRSTNAME',prop:'Class'},{av:'edtavLastname_Class',ctrl:'vLASTNAME',prop:'Class'},{av:'edtavAuthenticationtypename_Class',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Class'},{av:'cmbavGridactions'},{av:'AV82GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV12BtnRole',fld:'vBTNROLE',pic:''},{av:'edtavBtnrole_Link',ctrl:'vBTNROLE',prop:'Link'},{av:'AV14BtnPermissions',fld:'vBTNPERMISSIONS',pic:''},{av:'edtavBtnpermissions_Link',ctrl:'vBTNPERMISSIONS',prop:'Link'},{av:'AV13BtnSetPwd',fld:'vBTNSETPWD',pic:''},{av:'edtavBtnsetpwd_Link',ctrl:'vBTNSETPWD',prop:'Link'},{av:'edtavBtnsetpwd_Class',ctrl:'vBTNSETPWD',prop:'Class'},{av:'edtavName_Link',ctrl:'vNAME',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E141Q2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E111Q2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E191Q2',iparms:[{av:'cmbavGridactions'},{av:'AV82GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV28GUID',fld:'vGUID',pic:''}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV82GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV28GUID',fld:'vGUID',pic:''},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E151Q2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavFilauttype'},{av:'AV18FilAutType',fld:'vFILAUTTYPE',pic:''},{av:'AV40Search',fld:'vSEARCH',pic:''},{av:'cmbavFilrol'},{av:'AV41FilRol',fld:'vFILROL',pic:'ZZZZZZZZZZZ9'},{av:'edtavBtnrole_Title',ctrl:'vBTNROLE',prop:'Title'},{av:'edtavBtnsetpwd_Title',ctrl:'vBTNSETPWD',prop:'Title'},{av:'edtavBtnpermissions_Title',ctrl:'vBTNPERMISSIONS',prop:'Title'},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV24GAMUserIsDeleted',fld:'vGAMUSERISDELETED',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'AV23GAMUserIsAutoRegisteredUser',fld:'vGAMUSERISAUTOREGISTEREDUSER',pic:'',hsh:true},{av:'AV44IsAuthorized_Name',fld:'vISAUTHORIZED_NAME',pic:'',hsh:true},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV76ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV67ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavFirstname_Visible',ctrl:'vFIRSTNAME',prop:'Visible'},{av:'edtavLastname_Visible',ctrl:'vLASTNAME',prop:'Visible'},{av:'edtavAuthenticationtypename_Visible',ctrl:'vAUTHENTICATIONTYPENAME',prop:'Visible'},{av:'AV26GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV83FirstIndex',fld:'vFIRSTINDEX',pic:'ZZZ9',hsh:true},{av:'AV27GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86IsAuthorized_Display',fld:'vISAUTHORIZED_DISPLAY',pic:'',hsh:true},{av:'AV87IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV88IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV30IsAuthorized_BtnRole',fld:'vISAUTHORIZED_BTNROLE',pic:'',hsh:true},{av:'edtavBtnrole_Visible',ctrl:'vBTNROLE',prop:'Visible'},{av:'AV89IsAuthorized_BtnPermissions',fld:'vISAUTHORIZED_BTNPERMISSIONS',pic:'',hsh:true},{av:'edtavBtnpermissions_Visible',ctrl:'vBTNPERMISSIONS',prop:'Visible'},{av:'AV31IsAuthorized_BtnSetPwd',fld:'vISAUTHORIZED_BTNSETPWD',pic:'',hsh:true},{av:'edtavBtnsetpwd_Visible',ctrl:'vBTNSETPWD',prop:'Visible'},{av:'AV90IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV80ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV53GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Guid',iparms:[]");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV67ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV95Pgmname = "";
         AV18FilAutType = "";
         AV40Search = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV80ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV85GridAppliedFilters = "";
         AV73DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV53GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         AV12BtnRole = "";
         AV14BtnPermissions = "";
         AV13BtnSetPwd = "";
         AV34Name = "";
         AV22FirstName = "";
         AV33LastName = "";
         AV9AuthenticationTypeName = "";
         AV28GUID = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV49HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV20FilterAutType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV17Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV45Roles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV43FilterRoles = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV36Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV42Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV50WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV72Session = context.GetSession();
         AV55ColumnsSelectorXML = "";
         AV19Filter = new GeneXus.Programs.genexussecurity.SdtGAMUserFilter(context);
         AV25GAMUsers = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser>( context, "GeneXus.Programs.genexussecurity.SdtGAMUser", "GeneXus.Programs");
         GridRow = new GXWebRow();
         AV38User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV77ManageFiltersXml = "";
         AV62UserCustomValue = "";
         GXt_char3 = "";
         AV84ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV54GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GXCCtl = "";
         ROClassString = "";
         AV95Pgmname = "GAMWWUsers";
         /* GeneXus formulas. */
         AV95Pgmname = "GAMWWUsers";
         context.Gx_err = 0;
         edtavBtnrole_Enabled = 0;
         edtavBtnpermissions_Enabled = 0;
         edtavBtnsetpwd_Enabled = 0;
         edtavName_Enabled = 0;
         edtavFirstname_Enabled = 0;
         edtavLastname_Enabled = 0;
         edtavAuthenticationtypename_Enabled = 0;
         edtavGuid_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV76ManageFiltersExecutionStep ;
      private short AV83FirstIndex ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV82GridActions ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short AV39GAMUsersCount ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_52 ;
      private int nGXsfl_52_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavBtnrole_Visible ;
      private int edtavBtnpermissions_Visible ;
      private int edtavBtnsetpwd_Visible ;
      private int edtavName_Visible ;
      private int edtavFirstname_Visible ;
      private int edtavLastname_Visible ;
      private int edtavAuthenticationtypename_Visible ;
      private int edtavBtnrole_Enabled ;
      private int edtavBtnpermissions_Enabled ;
      private int edtavBtnsetpwd_Enabled ;
      private int edtavName_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavAuthenticationtypename_Enabled ;
      private int edtavGuid_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int edtavGamuserscount_Visible ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int subGrid_Recordcount ;
      private int AV93GXV1 ;
      private int AV94GXV2 ;
      private int AV35PageToGo ;
      private int AV96GXV3 ;
      private int AV97GXV4 ;
      private int edtavSearch_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavGuid_Visible ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41FilRol ;
      private long AV26GridCurrentPage ;
      private long AV27GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long AV6GridPageSize ;
      private long AV7GridRecordCount ;
      private long AV64i ;
      private string edtavBtnrole_Title ;
      private string edtavBtnsetpwd_Title ;
      private string edtavBtnpermissions_Title ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_52_idx="0001" ;
      private string edtavBtnrole_Internalname ;
      private string edtavBtnsetpwd_Internalname ;
      private string edtavBtnpermissions_Internalname ;
      private string AV95Pgmname ;
      private string AV18FilAutType ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Fixable ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string cmbavGridactions_Class ;
      private string edtavBtnsetpwd_Class ;
      private string edtavName_Class ;
      private string edtavFirstname_Class ;
      private string edtavLastname_Class ;
      private string edtavAuthenticationtypename_Class ;
      private string subGrid_Header ;
      private string AV12BtnRole ;
      private string edtavBtnrole_Link ;
      private string AV14BtnPermissions ;
      private string edtavBtnpermissions_Link ;
      private string AV13BtnSetPwd ;
      private string edtavBtnsetpwd_Link ;
      private string edtavName_Link ;
      private string AV22FirstName ;
      private string AV33LastName ;
      private string AV9AuthenticationTypeName ;
      private string AV28GUID ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string edtavGamuserscount_Internalname ;
      private string edtavGamuserscount_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtavName_Internalname ;
      private string edtavFirstname_Internalname ;
      private string edtavLastname_Internalname ;
      private string edtavAuthenticationtypename_Internalname ;
      private string edtavGuid_Internalname ;
      private string edtavSearch_Internalname ;
      private string cmbavFilauttype_Internalname ;
      private string cmbavFilrol_Internalname ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavSearch_Jsonclick ;
      private string cmbavFilauttype_Jsonclick ;
      private string cmbavFilrol_Jsonclick ;
      private string sGXsfl_52_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtavBtnrole_Jsonclick ;
      private string edtavBtnpermissions_Jsonclick ;
      private string edtavBtnsetpwd_Jsonclick ;
      private string edtavName_Jsonclick ;
      private string edtavFirstname_Jsonclick ;
      private string edtavLastname_Jsonclick ;
      private string edtavAuthenticationtypename_Jsonclick ;
      private string edtavGuid_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_52_Refreshing=false ;
      private bool AV86IsAuthorized_Display ;
      private bool AV87IsAuthorized_Update ;
      private bool AV88IsAuthorized_Delete ;
      private bool AV24GAMUserIsDeleted ;
      private bool AV30IsAuthorized_BtnRole ;
      private bool AV89IsAuthorized_BtnPermissions ;
      private bool AV31IsAuthorized_BtnSetPwd ;
      private bool AV23GAMUserIsAutoRegisteredUser ;
      private bool AV44IsAuthorized_Name ;
      private bool AV90IsAuthorized_Insert ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private string AV55ColumnsSelectorXML ;
      private string AV77ManageFiltersXml ;
      private string AV62UserCustomValue ;
      private string AV40Search ;
      private string AV85GridAppliedFilters ;
      private string AV34Name ;
      private IGxSession AV72Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV36Repository ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFilauttype ;
      private GXCombobox cmbavFilrol ;
      private GXCombobox cmbavGridactions ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV49HTTPRequest ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV10AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV17Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMUser> AV25GAMUsers ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV45Roles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV80ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV8AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserFilter AV19Filter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter AV20FilterAutType ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV38User ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV42Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV43FilterRoles ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV50WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV53GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV54GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV67ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV84ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV73DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
   }

}
