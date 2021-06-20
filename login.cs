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
   public class login : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public login( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public login( IGxContext context )
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
            ValidateSpaRequest();
            PA082( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS082( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE082( ) ;
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
         context.SendWebValue( "Login") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214199235693", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("login.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONCLIENTID", StringUtil.RTrim( AV36ApplicationClientId));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV20Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Enablefixobjectfitcover", StringUtil.BoolToStr( Wwputilities_Enablefixobjectfitcover));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Enableconvertcombotobootstrapselect", StringUtil.BoolToStr( Wwputilities_Enableconvertcombotobootstrapselect));
      }

      protected void RenderHtmlCloseForm082( )
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
         return "Login" ;
      }

      public override string GetPgmdesc( )
      {
         return "Login" ;
      }

      protected void WB080( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table100x100H", "left", "top", "", "", "div");
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
            sImgUrl = (string)(context.GetImagePath( "59dd788a-0e8f-4879-8a58-1c0f3b889781", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeaderoriginal_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLogin", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "Iniciar Sessão", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLogonto_cell_Internalname, 1, 0, "px", 0, "px", divLogonto_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Log On To", "col-sm-3 AttributeLoginLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV22LogOnTo), 1, cmbavLogonto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeLogin", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, "HLP_Login.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV22LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User Name", "col-sm-3 AttributeLoginLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV31UserName, StringUtil.RTrim( context.localUtil.Format( AV31UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Email", edtavUsername_Jsonclick, 0, "AttributeLogin", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "User Password", "col-sm-3 AttributeLoginLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV32UserPassword), StringUtil.RTrim( context.localUtil.Format( AV32UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Senha", edtavUserpassword_Jsonclick, 0, "AttributeLogin", "", "", "", "", 1, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblForgotpassword_Internalname, "Esqueceu sua senha?", "", "", lblForgotpassword_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11081_client"+"'", "", "DataDescriptionLogin", 7, "", 1, 1, 0, 1, "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKeepmeloggedin_cell_Internalname, 1, 0, "px", 0, "px", divKeepmeloggedin_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavKeepmeloggedin_Internalname, "Keep Me Logged In", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV19KeepMeLoggedIn), "", "Keep Me Logged In", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "Mantenha-me conectado", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(40, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,40);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRememberme_cell_Internalname, 1, 0, "px", 0, "px", divRememberme_cell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavRememberme_Internalname, "Remember Me", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV24RememberMe), "", "Remember Me", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "Lembrar-me", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableActionsCellLogin", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Iniciar sessão", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRegisteruser_Internalname, "Cadastre-se", lblRegisteruser_Link, "", lblRegisteruser_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescriptionLogin", 0, "", 1, 1, 0, 0, "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table1_53_082( true) ;
         }
         else
         {
            wb_table1_53_082( false) ;
         }
         return  ;
      }

      protected void wb_table1_53_082e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilities.SetProperty("EnableFixObjectFitCover", Wwputilities_Enablefixobjectfitcover);
            ucWwputilities.SetProperty("EnableConvertComboToBootstrapSelect", Wwputilities_Enableconvertcombotobootstrapselect);
            ucWwputilities.Render(context, "dvelop.workwithplusutilities_f5", Wwputilities_Internalname, "WWPUTILITIESContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrl_Internalname, AV30URL, StringUtil.RTrim( context.localUtil.Format( AV30URL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrl_Jsonclick, 0, "Attribute", "", "", "", "", edtavUrl_Visible, 1, 0, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "left", true, "", "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START082( )
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
            Form.Meta.addItem("description", "Login", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
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
                           E12082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E13082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOFACEBOOK'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoFacebook' */
                           E14082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOTWITTER'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoTwitter' */
                           E15082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOGOOGLE'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoGoogle' */
                           E16082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOREMOTE'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoRemote' */
                           E17082 ();
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
                                 E18082 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E19082 ();
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

      protected void WE082( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm082( ) ;
            }
         }
      }

      protected void PA082( )
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
               GX_FocusControl = cmbavLogonto_Internalname;
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
            AV22LogOnTo = cmbavLogonto.getValidValue(AV22LogOnTo);
            AssignAttri("", false, "AV22LogOnTo", AV22LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV22LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV19KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV19KeepMeLoggedIn));
         AssignAttri("", false, "AV19KeepMeLoggedIn", AV19KeepMeLoggedIn);
         AV24RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV24RememberMe));
         AssignAttri("", false, "AV24RememberMe", AV24RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF082( ) ;
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

      protected void RF082( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13082 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E19082 ();
            WB080( ) ;
         }
      }

      protected void send_integrity_lvl_hashes082( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV20Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12082 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enablefixobjectfitcover"));
            Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enableconvertcombotobootstrapselect"));
            /* Read variables values. */
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV22LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV22LogOnTo", AV22LogOnTo);
            AV31UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV31UserName", AV31UserName);
            AV32UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
            AV19KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV19KeepMeLoggedIn", AV19KeepMeLoggedIn);
            AV24RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV24RememberMe", AV24RememberMe);
            AV30URL = cgiGet( edtavUrl_Internalname);
            AssignAttri("", false, "AV30URL", AV30URL);
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
         E12082 ();
         if (returnInSub) return;
      }

      protected void E12082( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         lblRegisteruser_Link = formatLink("gamregisteruser.aspx") ;
         AssignProp("", false, lblRegisteruser_Internalname, "Link", lblRegisteruser_Link, true);
         AV17isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         if ( ! AV17isOK )
         {
            AV9ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
            if ( AV9ConnectionInfoCollection.Count > 0 )
            {
               AV17isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV9ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV11Errors);
            }
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         edtavUrl_Visible = 0;
         AssignProp("", false, edtavUrl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrl_Visible), 5, 0), true);
      }

      protected void E13082( )
      {
         /* Refresh Routine */
         returnInSub = false;
         divTableloginerror_Visible = 0;
         AssignProp("", false, divTableloginerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableloginerror_Visible), 5, 0), true);
         AV18isRedirect = false;
         AV12ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV12ErrorsLogin.Count > 0 )
         {
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12ErrorsLogin.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12ErrorsLogin.Item(1)).gxTpr_Code == 23 ) )
            {
               CallWebObject(formatLink("gamchangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV36ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
               context.wjLocDisableFrm = 1;
               AV18isRedirect = true;
            }
            else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12ErrorsLogin.Item(1)).gxTpr_Code == 161 )
            {
               CallWebObject(formatLink("gamupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV36ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
               context.wjLocDisableFrm = 1;
               AV18isRedirect = true;
            }
            else
            {
               AV32UserPassword = "";
               AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
               AV11Errors = AV12ErrorsLogin;
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         if ( ! AV18isRedirect )
         {
            AV28SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV27Session, out  AV11Errors);
            if ( AV28SessionValid && ! AV27Session.gxTpr_Isanonymous )
            {
               AV30URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               AssignAttri("", false, "AV30URL", AV30URL);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30URL)) )
               {
                  AV41GAMApplicationCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplications(AV40GAMApplicationFilter, out  AV11Errors);
                  AV45GXV1 = 1;
                  while ( AV45GXV1 <= AV41GAMApplicationCollection.Count )
                  {
                     AV42GAMApplication = ((GeneXus.Programs.genexussecurity.SdtGAMApplication)AV41GAMApplicationCollection.Item(AV45GXV1));
                     if ( StringUtil.StrCmp(AV42GAMApplication.gxTpr_Guid, "8d9934db-05db-4d64-adba-5e0466c3appU") != 0 )
                     {
                        if (true) break;
                     }
                     AV45GXV1 = (int)(AV45GXV1+1);
                  }
                  AV42GAMApplication = AV42GAMApplication.get();
                  if ( StringUtil.StrCmp(AV42GAMApplication.gxTpr_Homeobject, "") != 0 )
                  {
                     new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome(AV42GAMApplication.gxTpr_Guid) ;
                  }
                  else
                  {
                     CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
               }
               else
               {
                  CallWebObject(formatLink(AV30URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV20Language, out  AV11Errors);
               AV46GXV2 = 1;
               while ( AV46GXV2 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV46GXV2));
                  if ( AV6AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV6AuthenticationType.gxTpr_Name, AV6AuthenticationType.gxTpr_Description, 0);
                  }
                  AV46GXV2 = (int)(AV46GXV2+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               else
               {
                  AV22LogOnTo = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(1)).gxTpr_Name;
                  AssignAttri("", false, "AV22LogOnTo", AV22LogOnTo);
               }
               AV17isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV22LogOnTo, out  AV31UserName, out  AV33UserRememberMe, out  AV11Errors);
               if ( AV33UserRememberMe == 2 )
               {
                  AV24RememberMe = true;
                  AssignAttri("", false, "AV24RememberMe", AV24RememberMe);
               }
               AV25Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV22LogOnTo = AV25Repository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV22LogOnTo", AV22LogOnTo);
               }
               if ( StringUtil.StrCmp(AV25Repository.gxTpr_Userremembermetype, "Login") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV25Repository.gxTpr_Userremembermetype, "Auth") == 0 )
               {
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV25Repository.gxTpr_Userremembermetype, "Both") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               else
               {
                  chkavRememberme.Visible = 0;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
                  chkavKeepmeloggedin.Visible = 0;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
               S112 ();
               if (returnInSub) return;
            }
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV22LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
      }

      protected void E14082( )
      {
         /* 'DoFacebook' Routine */
         returnInSub = false;
         new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).loginfacebook() ;
      }

      protected void E15082( )
      {
         /* 'DoTwitter' Routine */
         returnInSub = false;
         new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).logintwitter() ;
      }

      protected void E16082( )
      {
         /* 'DoGoogle' Routine */
         returnInSub = false;
         new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).logingoogle() ;
      }

      protected void E17082( )
      {
         /* 'DoRemote' Routine */
         returnInSub = false;
         new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).logingamremote() ;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E18082 ();
         if (returnInSub) return;
      }

      protected void E18082( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV19KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV24RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV22LogOnTo;
         AV21LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV31UserName, AV32UserPassword, AV5AdditionalParameter, out  AV11Errors);
         if ( AV21LoginOK )
         {
            AV34ApplicationData = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).getapplicationdata();
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ApplicationData)) )
            {
               AV35GAMExampleSDTApplicationData.FromJSonString(AV34ApplicationData, null);
            }
            AV30URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            AssignAttri("", false, "AV30URL", AV30URL);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30URL)) )
            {
               AV41GAMApplicationCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplications(AV40GAMApplicationFilter, out  AV11Errors);
               AV47GXV3 = 1;
               while ( AV47GXV3 <= AV41GAMApplicationCollection.Count )
               {
                  AV42GAMApplication = ((GeneXus.Programs.genexussecurity.SdtGAMApplication)AV41GAMApplicationCollection.Item(AV47GXV3));
                  if ( StringUtil.StrCmp(AV42GAMApplication.gxTpr_Guid, "8d9934db-05db-4d64-adba-5e0466c3appU") != 0 )
                  {
                     if (true) break;
                  }
                  AV47GXV3 = (int)(AV47GXV3+1);
               }
               AV42GAMApplication = AV42GAMApplication.get();
               if ( StringUtil.StrCmp(AV42GAMApplication.gxTpr_Homeobject, "") != 0 )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome(AV42GAMApplication.gxTpr_Guid) ;
               }
               else
               {
                  CallWebObject(formatLink("wwpbaseobjects.home.aspx") );
                  context.wjLocDisableFrm = 1;
               }
            }
            else
            {
               CallWebObject(formatLink(AV30URL) );
               context.wjLocDisableFrm = 0;
            }
         }
         else
         {
            if ( AV11Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("gamchangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV36ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11Errors.Item(1)).gxTpr_Code == 161 )
               {
                  CallWebObject(formatLink("gamupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV36ApplicationClientId))}, new string[] {"ApplicationClientId"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV32UserPassword = "";
                  AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("Facebook") ) )
         {
            lblFacebook_Visible = 0;
            AssignProp("", false, lblFacebook_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblFacebook_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("Twitter") ) )
         {
            lblTwitter_Visible = 0;
            AssignProp("", false, lblTwitter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTwitter_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("Google") ) )
         {
            lblGoogle_Visible = 0;
            AssignProp("", false, lblGoogle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblGoogle_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("GAMRemote") ) )
         {
            lblRemote_Visible = 0;
            AssignProp("", false, lblRemote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblRemote_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( cmbavLogonto.ItemCount > 1 ) ) )
         {
            cmbavLogonto.Visible = 0;
            AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
            divLogonto_cell_Class = "Invisible";
            AssignProp("", false, divLogonto_cell_Internalname, "Class", divLogonto_cell_Class, true);
         }
         else
         {
            cmbavLogonto.Visible = 1;
            AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
            divLogonto_cell_Class = "col-xs-12 DataContentCellLogin CellPaddingLogin";
            AssignProp("", false, divLogonto_cell_Internalname, "Class", divLogonto_cell_Class, true);
         }
         if ( ! ( ( 1 == 1 ) ) )
         {
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            divKeepmeloggedin_cell_Class = "Invisible";
            AssignProp("", false, divKeepmeloggedin_cell_Internalname, "Class", divKeepmeloggedin_cell_Class, true);
         }
         else
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            divKeepmeloggedin_cell_Class = "col-xs-12 DataContentCellLogin";
            AssignProp("", false, divKeepmeloggedin_cell_Internalname, "Class", divKeepmeloggedin_cell_Class, true);
         }
         if ( ! ( ( 1 == 1 ) ) )
         {
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
            divRememberme_cell_Class = "Invisible";
            AssignProp("", false, divRememberme_cell_Internalname, "Class", divRememberme_cell_Class, true);
         }
         else
         {
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
            divRememberme_cell_Class = "col-xs-12 DataContentCellLogin";
            AssignProp("", false, divRememberme_cell_Internalname, "Class", divRememberme_cell_Class, true);
         }
         tblTableotherlogins_Visible = ((new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("Facebook")||new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("Twitter")||new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("Google")||new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).canauthenticatewith("GAMRemote")) ? 1 : 0);
         AssignProp("", false, tblTableotherlogins_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableotherlogins_Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV48GXV4 = 1;
         while ( AV48GXV4 <= AV11Errors.Count )
         {
            AV10Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV11Errors.Item(AV48GXV4));
            if ( ( AV10Error.gxTpr_Code != 13 ) && ( AV10Error.gxTpr_Code != 42 ) && ( AV10Error.gxTpr_Code != 2 ) )
            {
               divTableloginerror_Visible = 1;
               AssignProp("", false, divTableloginerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableloginerror_Visible), 5, 0), true);
               GX_msglist.addItem(StringUtil.Format( "%1", AV10Error.gxTpr_Message, "", "", "", "", "", "", "", ""));
            }
            AV48GXV4 = (int)(AV48GXV4+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E19082( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_53_082( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTableotherlogins_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTableotherlogins_Internalname, tblTableotherlogins_Internalname, "", "CellMarginTop", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLoginwith_Internalname, "Ou começar com", "", "", lblLoginwith_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescriptionLogin", 0, "", 1, 1, 0, 1, "HLP_Login.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFacebook_Internalname, "<i class=\"fab fa-facebook-f GAMIconLogin\"></i>", "", "", lblFacebook_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFACEBOOK\\'."+"'", "", "TextBlock", 5, "", lblFacebook_Visible, 1, 0, 1, "HLP_Login.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTwitter_Internalname, "<i class=\"fab fa-twitter GAMIconLogin\"></i>", "", "", lblTwitter_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOTWITTER\\'."+"'", "", "TextBlock", 5, "", lblTwitter_Visible, 1, 0, 1, "HLP_Login.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGoogle_Internalname, "<i class=\"fab fa-google GAMIconLogin\"></i>", "", "", lblGoogle_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOGOOGLE\\'."+"'", "", "TextBlock", 5, "", lblGoogle_Visible, 1, 0, 1, "HLP_Login.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRemote_Internalname, "<i class=\"fa fa-lock GAMIconLogin\"></i>", "", "", lblRemote_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOREMOTE\\'."+"'", "", "TextBlock", 5, "", lblRemote_Visible, 1, 0, 1, "HLP_Login.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_53_082e( true) ;
         }
         else
         {
            wb_table1_53_082e( false) ;
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
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_v5/css/fontawesome.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_v5/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214199242820", true, true);
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
         context.AddJavascriptSource("login.js", "?20214199242824", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV22LogOnTo = cmbavLogonto.getValidValue(AV22LogOnTo);
            AssignAttri("", false, "AV22LogOnTo", AV22LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "Mantenha-me conectado";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV19KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV19KeepMeLoggedIn));
         AssignAttri("", false, "AV19KeepMeLoggedIn", AV19KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "Lembrar-me";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV24RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV24RememberMe));
         AssignAttri("", false, "AV24RememberMe", AV24RememberMe);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeaderoriginal_Internalname = "HEADERORIGINAL";
         lblSignin_Internalname = "SIGNIN";
         cmbavLogonto_Internalname = "vLOGONTO";
         divLogonto_cell_Internalname = "LOGONTO_CELL";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         lblForgotpassword_Internalname = "FORGOTPASSWORD";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         divKeepmeloggedin_cell_Internalname = "KEEPMELOGGEDIN_CELL";
         chkavRememberme_Internalname = "vREMEMBERME";
         divRememberme_cell_Internalname = "REMEMBERME_CELL";
         bttBtnenter_Internalname = "BTNENTER";
         lblRegisteruser_Internalname = "REGISTERUSER";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         lblLoginwith_Internalname = "LOGINWITH";
         lblFacebook_Internalname = "FACEBOOK";
         lblTwitter_Internalname = "TWITTER";
         lblGoogle_Internalname = "GOOGLE";
         lblRemote_Internalname = "REMOTE";
         tblTableotherlogins_Internalname = "TABLEOTHERLOGINS";
         divTablelogin_Internalname = "TABLELOGIN";
         divTableloginerror_Internalname = "TABLELOGINERROR";
         divTablecontent_Internalname = "TABLECONTENT";
         Wwputilities_Internalname = "WWPUTILITIES";
         divTablemain_Internalname = "TABLEMAIN";
         edtavUrl_Internalname = "vURL";
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
         chkavRememberme.Caption = "Remember Me";
         chkavKeepmeloggedin.Caption = "Keep Me Logged In";
         lblRemote_Visible = 1;
         lblGoogle_Visible = 1;
         lblTwitter_Visible = 1;
         lblFacebook_Visible = 1;
         tblTableotherlogins_Visible = 1;
         edtavUrl_Jsonclick = "";
         edtavUrl_Visible = 1;
         divTableloginerror_Visible = 1;
         lblRegisteruser_Link = "";
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         divRememberme_cell_Class = "col-xs-12";
         chkavKeepmeloggedin.Enabled = 1;
         chkavKeepmeloggedin.Visible = 1;
         divKeepmeloggedin_cell_Class = "col-xs-12";
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Visible = 1;
         cmbavLogonto.Enabled = 1;
         divLogonto_cell_Class = "col-xs-12";
         divLayoutmaintable_Class = "Table";
         Wwputilities_Enableconvertcombotobootstrapselect = Convert.ToBoolean( -1);
         Wwputilities_Enablefixobjectfitcover = Convert.ToBoolean( -1);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV36ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV31UserName',fld:'vUSERNAME',pic:''},{av:'AV20Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV33UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'divTableloginerror_Visible',ctrl:'TABLELOGINERROR',prop:'Visible'},{av:'AV36ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV32UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV30URL',fld:'vURL',pic:''},{av:'cmbavLogonto'},{av:'AV22LogOnTo',fld:'vLOGONTO',pic:''},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'divLogonto_cell_Class',ctrl:'LOGONTO_CELL',prop:'Class'},{av:'divKeepmeloggedin_cell_Class',ctrl:'KEEPMELOGGEDIN_CELL',prop:'Class'},{av:'divRememberme_cell_Class',ctrl:'REMEMBERME_CELL',prop:'Class'},{av:'tblTableotherlogins_Visible',ctrl:'TABLEOTHERLOGINS',prop:'Visible'},{av:'lblFacebook_Visible',ctrl:'FACEBOOK',prop:'Visible'},{av:'lblTwitter_Visible',ctrl:'TWITTER',prop:'Visible'},{av:'lblGoogle_Visible',ctrl:'GOOGLE',prop:'Visible'},{av:'lblRemote_Visible',ctrl:'REMOTE',prop:'Visible'},{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'DOFACEBOOK'","{handler:'E14082',iparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'DOFACEBOOK'",",oparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'DOTWITTER'","{handler:'E15082',iparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'DOTWITTER'",",oparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'DOGOOGLE'","{handler:'E16082',iparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'DOGOOGLE'",",oparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'DOREMOTE'","{handler:'E17082',iparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'DOREMOTE'",",oparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E18082',iparms:[{av:'cmbavLogonto'},{av:'AV22LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV31UserName',fld:'vUSERNAME',pic:''},{av:'AV32UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV36ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV30URL',fld:'vURL',pic:''},{av:'AV36ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV32UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'divTableloginerror_Visible',ctrl:'TABLELOGINERROR',prop:'Visible'},{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("FORGOTPASSWORD.CLICK","{handler:'E11081',iparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("FORGOTPASSWORD.CLICK",",oparms:[{av:'AV19KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV24RememberMe',fld:'vREMEMBERME',pic:''}]}");
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
         AV20Language = "";
         GXKey = "";
         AV36ApplicationClientId = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblSignin_Jsonclick = "";
         TempTags = "";
         AV22LogOnTo = "";
         AV31UserName = "";
         AV32UserPassword = "";
         lblForgotpassword_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         lblRegisteruser_Jsonclick = "";
         ucWwputilities = new GXUserControl();
         AV30URL = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV11Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV27Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV41GAMApplicationCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplication", "GeneXus.Programs");
         AV40GAMApplicationFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter(context);
         AV42GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV7AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV6AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV25Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV5AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV34ApplicationData = "";
         AV35GAMExampleSDTApplicationData = new SdtGAMExampleSDTApplicationData(context);
         AV10Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         lblLoginwith_Jsonclick = "";
         lblFacebook_Jsonclick = "";
         lblTwitter_Jsonclick = "";
         lblGoogle_Jsonclick = "";
         lblRemote_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short AV33UserRememberMe ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Enabled ;
      private int divTableloginerror_Visible ;
      private int edtavUrl_Visible ;
      private int AV45GXV1 ;
      private int AV46GXV2 ;
      private int AV47GXV3 ;
      private int lblFacebook_Visible ;
      private int lblTwitter_Visible ;
      private int lblGoogle_Visible ;
      private int lblRemote_Visible ;
      private int tblTableotherlogins_Visible ;
      private int AV48GXV4 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV20Language ;
      private string GXKey ;
      private string AV36ApplicationClientId ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeaderoriginal_Internalname ;
      private string divTablelogin_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divLogonto_cell_Internalname ;
      private string divLogonto_cell_Class ;
      private string cmbavLogonto_Internalname ;
      private string TempTags ;
      private string cmbavLogonto_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string AV32UserPassword ;
      private string edtavUserpassword_Jsonclick ;
      private string lblForgotpassword_Internalname ;
      private string lblForgotpassword_Jsonclick ;
      private string divKeepmeloggedin_cell_Internalname ;
      private string divKeepmeloggedin_cell_Class ;
      private string chkavKeepmeloggedin_Internalname ;
      private string divRememberme_cell_Internalname ;
      private string divRememberme_cell_Class ;
      private string chkavRememberme_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string lblRegisteruser_Internalname ;
      private string lblRegisteruser_Link ;
      private string lblRegisteruser_Jsonclick ;
      private string divTableloginerror_Internalname ;
      private string Wwputilities_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavUrl_Internalname ;
      private string edtavUrl_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblFacebook_Internalname ;
      private string lblTwitter_Internalname ;
      private string lblGoogle_Internalname ;
      private string lblRemote_Internalname ;
      private string tblTableotherlogins_Internalname ;
      private string sStyleString ;
      private string lblLoginwith_Internalname ;
      private string lblLoginwith_Jsonclick ;
      private string lblFacebook_Jsonclick ;
      private string lblTwitter_Jsonclick ;
      private string lblGoogle_Jsonclick ;
      private string lblRemote_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool wbLoad ;
      private bool AV19KeepMeLoggedIn ;
      private bool AV24RememberMe ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV17isOK ;
      private bool AV18isRedirect ;
      private bool AV28SessionValid ;
      private bool AV21LoginOK ;
      private string AV34ApplicationData ;
      private string AV22LogOnTo ;
      private string AV31UserName ;
      private string AV30URL ;
      private GXUserControl ucWwputilities ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV7AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV9ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12ErrorsLogin ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication> AV41GAMApplicationCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV6AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV10Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV25Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV27Session ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV42GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter AV40GAMApplicationFilter ;
      private SdtGAMExampleSDTApplicationData AV35GAMExampleSDTApplicationData ;
   }

}
