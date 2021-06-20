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
   public class editbookmark : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public editbookmark( )
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

      public editbookmark( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref string aP0_InBookmarkURL ,
                           string aP1_BookmarkPageDescription )
      {
         this.AV16InBookmarkURL = aP0_InBookmarkURL;
         this.AV9BookmarkPageDescription = aP1_BookmarkPageDescription;
         executePrivate();
         aP0_InBookmarkURL=this.AV16InBookmarkURL;
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
               gxfirstwebparm = GetFirstPar( "InBookmarkURL");
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
                  AV16InBookmarkURL = GetPar( "InBookmarkURL");
                  AssignAttri(sPrefix, false, "AV16InBookmarkURL", AV16InBookmarkURL);
                  AV9BookmarkPageDescription = GetPar( "BookmarkPageDescription");
                  AssignAttri(sPrefix, false, "AV9BookmarkPageDescription", AV9BookmarkPageDescription);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV16InBookmarkURL,(string)AV9BookmarkPageDescription});
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
                  gxfirstwebparm = GetFirstPar( "InBookmarkURL");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "InBookmarkURL");
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
            PA2B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS2B2( ) ;
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
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2021428154607", false, true);
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
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wwpbaseobjects.editbookmark.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16InBookmarkURL)),UrlEncode(StringUtil.RTrim(AV9BookmarkPageDescription))}, new string[] {"InBookmarkURL","BookmarkPageDescription"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV29i), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16InBookmarkURL", wcpOAV16InBookmarkURL);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9BookmarkPageDescription", wcpOAV9BookmarkPageDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29i), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV29i), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISEDIT", AV18IsEdit);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINBOOKMARKURL", AV16InBookmarkURL);
         GxWebStd.gx_hidden_field( context, sPrefix+"vBOOKMARKPAGEDESCRIPTION", AV9BookmarkPageDescription);
      }

      protected void RenderHtmlCloseForm2B2( )
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
         return "WWPBaseObjects.EditBookmark" ;
      }

      public override string GetPgmdesc( )
      {
         return "Add/Edit Bookmark" ;
      }

      protected void WB2B0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.editbookmark.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PopupContentCell", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablebookmarkname_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockbookmarkname_Internalname, "Nome", "", "", lblTextblockbookmarkname_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\EditBookmark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBookmarkname_Internalname, "Bookmark Name", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBookmarkname_Internalname, AV5BookmarkName, StringUtil.RTrim( context.localUtil.Format( AV5BookmarkName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBookmarkname_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtavBookmarkname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\EditBookmark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablebookmarkurl_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockbookmarkurl_Internalname, "Endereço", "", "", lblTextblockbookmarkurl_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\EditBookmark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBookmarkurl_Internalname, "Bookmark URL", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBookmarkurl_Internalname, AV10BookmarkURL, StringUtil.RTrim( context.localUtil.Format( AV10BookmarkURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", AV10BookmarkURL, "_blank", "", "", edtavBookmarkurl_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtavBookmarkurl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Url", "left", true, "", "HLP_WWPBaseObjects\\EditBookmark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupRight", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Salvar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\EditBookmark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndel_Internalname, "", "REMOVE", bttBtndel_Jsonclick, 5, "REMOVE", "", StyleString, ClassString, bttBtndel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\EditBookmark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnusercancel_Internalname, "", "Fechar", bttBtnusercancel_Jsonclick, 7, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e112b1_client"+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\EditBookmark.htm");
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

      protected void START2B2( )
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
               Form.Meta.addItem("description", "Add/Edit Bookmark", 0) ;
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
               STRUP2B0( ) ;
            }
         }
      }

      protected void WS2B2( )
      {
         START2B2( ) ;
         EVT2B2( ) ;
      }

      protected void EVT2B2( )
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
                                 STRUP2B0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODEL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDel' */
                                    E132B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2B0( ) ;
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
                                          E142B2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E152B2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavBookmarkname_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE2B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2B2( ) ;
            }
         }
      }

      protected void PA2B2( )
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
               GX_FocusControl = edtavBookmarkname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         RF2B2( ) ;
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

      protected void RF2B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152B2 ();
            WB2B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2B2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29i), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV29i), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122B2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV16InBookmarkURL = cgiGet( sPrefix+"wcpOAV16InBookmarkURL");
            wcpOAV9BookmarkPageDescription = cgiGet( sPrefix+"wcpOAV9BookmarkPageDescription");
            /* Read variables values. */
            AV5BookmarkName = cgiGet( edtavBookmarkname_Internalname);
            AssignAttri(sPrefix, false, "AV5BookmarkName", AV5BookmarkName);
            AV10BookmarkURL = cgiGet( edtavBookmarkurl_Internalname);
            AssignAttri(sPrefix, false, "AV10BookmarkURL", AV10BookmarkURL);
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
         E122B2 ();
         if (returnInSub) return;
      }

      protected void E122B2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10BookmarkURL = AV16InBookmarkURL;
         AssignAttri(sPrefix, false, "AV10BookmarkURL", AV10BookmarkURL);
         AV5BookmarkName = AV9BookmarkPageDescription;
         AssignAttri(sPrefix, false, "AV5BookmarkName", AV5BookmarkName);
         AV13GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
         AV29i = 1;
         AssignAttri(sPrefix, false, "AV29i", StringUtil.LTrimStr( (decimal)(AV29i), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV29i), "ZZZ9"), context));
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV13GridStateCollection.Count )
         {
            AV14GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV13GridStateCollection.Item(AV33GXV1));
            if ( StringUtil.StrCmp(AV14GridStateCollectionItem.gxTpr_Gridstatexml, AV10BookmarkURL) == 0 )
            {
               AV30ProgramDescription = AV14GridStateCollectionItem.gxTpr_Title;
               if (true) break;
            }
            else
            {
               AV29i = (short)(AV29i+1);
               AssignAttri(sPrefix, false, "AV29i", StringUtil.LTrimStr( (decimal)(AV29i), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV29i), "ZZZ9"), context));
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
         if ( AV29i > AV13GridStateCollection.Count )
         {
            bttBtndel_Visible = 0;
            AssignProp(sPrefix, false, bttBtndel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndel_Visible), 5, 0), true);
            Form.Caption = "Favoritar esta página";
            AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
         }
         else
         {
            Form.Caption = "Edit Bookmark for this page";
            AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
         }
      }

      protected void E132B2( )
      {
         /* 'DoDel' Routine */
         returnInSub = false;
         AV13GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
         if ( AV29i <= AV13GridStateCollection.Count )
         {
            AV13GridStateCollection.RemoveItem(AV29i);
            new GeneXus.Programs.wwpbaseobjects.savemanagefiltersstate(context ).execute(  "AppBookmarks",  AV13GridStateCollection.ToXml(false, true, "Items", "")) ;
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)""}, false);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E142B2 ();
         if (returnInSub) return;
      }

      protected void E142B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV5BookmarkName = StringUtil.Trim( AV5BookmarkName);
         AssignAttri(sPrefix, false, "AV5BookmarkName", AV5BookmarkName);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5BookmarkName)) )
         {
            GX_msglist.addItem("Empty");
         }
         else
         {
            AV13GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
            AV19IsNameUnique = true;
            AV34GXV2 = 1;
            while ( AV34GXV2 <= AV13GridStateCollection.Count )
            {
               AV14GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV13GridStateCollection.Item(AV34GXV2));
               if ( StringUtil.StrCmp(AV14GridStateCollectionItem.gxTpr_Gridstatexml, AV10BookmarkURL) == 0 )
               {
                  AV18IsEdit = true;
                  AssignAttri(sPrefix, false, "AV18IsEdit", AV18IsEdit);
               }
               AV34GXV2 = (int)(AV34GXV2+1);
            }
            if ( AV18IsEdit )
            {
               AV35GXV3 = 1;
               while ( AV35GXV3 <= AV13GridStateCollection.Count )
               {
                  AV14GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV13GridStateCollection.Item(AV35GXV3));
                  if ( StringUtil.StrCmp(AV14GridStateCollectionItem.gxTpr_Gridstatexml, AV10BookmarkURL) == 0 )
                  {
                     AV14GridStateCollectionItem.gxTpr_Title = AV5BookmarkName;
                  }
                  AV35GXV3 = (int)(AV35GXV3+1);
               }
            }
            else
            {
               AV14GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
               AV14GridStateCollectionItem.gxTpr_Title = AV5BookmarkName;
               AV14GridStateCollectionItem.gxTpr_Gridstatexml = AV10BookmarkURL;
               AV13GridStateCollection.Add(AV14GridStateCollectionItem, 1);
            }
            new GeneXus.Programs.wwpbaseobjects.savemanagefiltersstate(context ).execute(  "AppBookmarks",  AV13GridStateCollection.ToXml(false, true, "Items", "")) ;
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)""}, false);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E152B2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16InBookmarkURL = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV16InBookmarkURL", AV16InBookmarkURL);
         AV9BookmarkPageDescription = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV9BookmarkPageDescription", AV9BookmarkPageDescription);
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
         PA2B2( ) ;
         WS2B2( ) ;
         WE2B2( ) ;
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
         sCtrlAV16InBookmarkURL = (string)((string)getParm(obj,0));
         sCtrlAV9BookmarkPageDescription = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2B2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\editbookmark", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2B2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV16InBookmarkURL = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV16InBookmarkURL", AV16InBookmarkURL);
            AV9BookmarkPageDescription = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV9BookmarkPageDescription", AV9BookmarkPageDescription);
         }
         wcpOAV16InBookmarkURL = cgiGet( sPrefix+"wcpOAV16InBookmarkURL");
         wcpOAV9BookmarkPageDescription = cgiGet( sPrefix+"wcpOAV9BookmarkPageDescription");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV16InBookmarkURL, wcpOAV16InBookmarkURL) != 0 ) || ( StringUtil.StrCmp(AV9BookmarkPageDescription, wcpOAV9BookmarkPageDescription) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV16InBookmarkURL = AV16InBookmarkURL;
         wcpOAV9BookmarkPageDescription = AV9BookmarkPageDescription;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV16InBookmarkURL = cgiGet( sPrefix+"AV16InBookmarkURL_CTRL");
         if ( StringUtil.Len( sCtrlAV16InBookmarkURL) > 0 )
         {
            AV16InBookmarkURL = cgiGet( sCtrlAV16InBookmarkURL);
            AssignAttri(sPrefix, false, "AV16InBookmarkURL", AV16InBookmarkURL);
         }
         else
         {
            AV16InBookmarkURL = cgiGet( sPrefix+"AV16InBookmarkURL_PARM");
         }
         sCtrlAV9BookmarkPageDescription = cgiGet( sPrefix+"AV9BookmarkPageDescription_CTRL");
         if ( StringUtil.Len( sCtrlAV9BookmarkPageDescription) > 0 )
         {
            AV9BookmarkPageDescription = cgiGet( sCtrlAV9BookmarkPageDescription);
            AssignAttri(sPrefix, false, "AV9BookmarkPageDescription", AV9BookmarkPageDescription);
         }
         else
         {
            AV9BookmarkPageDescription = cgiGet( sPrefix+"AV9BookmarkPageDescription_PARM");
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
         PA2B2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2B2( ) ;
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
         WS2B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16InBookmarkURL_PARM", AV16InBookmarkURL);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16InBookmarkURL)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16InBookmarkURL_CTRL", StringUtil.RTrim( sCtrlAV16InBookmarkURL));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9BookmarkPageDescription_PARM", AV9BookmarkPageDescription);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9BookmarkPageDescription)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9BookmarkPageDescription_CTRL", StringUtil.RTrim( sCtrlAV9BookmarkPageDescription));
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
         WE2B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281546121", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/editbookmark.js", "?20214281546123", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockbookmarkname_Internalname = sPrefix+"TEXTBLOCKBOOKMARKNAME";
         edtavBookmarkname_Internalname = sPrefix+"vBOOKMARKNAME";
         divUnnamedtablebookmarkname_Internalname = sPrefix+"UNNAMEDTABLEBOOKMARKNAME";
         lblTextblockbookmarkurl_Internalname = sPrefix+"TEXTBLOCKBOOKMARKURL";
         edtavBookmarkurl_Internalname = sPrefix+"vBOOKMARKURL";
         divUnnamedtablebookmarkurl_Internalname = sPrefix+"UNNAMEDTABLEBOOKMARKURL";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtndel_Internalname = sPrefix+"BTNDEL";
         bttBtnusercancel_Internalname = sPrefix+"BTNUSERCANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         bttBtndel_Visible = 1;
         edtavBookmarkurl_Jsonclick = "";
         edtavBookmarkurl_Enabled = 1;
         edtavBookmarkname_Jsonclick = "";
         edtavBookmarkname_Enabled = 1;
         Form.Caption = "Add/Edit Bookmark";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV29i',fld:'vI',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DODEL'","{handler:'E132B2',iparms:[{av:'AV29i',fld:'vI',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DODEL'",",oparms:[]}");
         setEventMetadata("'DOUSERCANCEL'","{handler:'E112B1',iparms:[]");
         setEventMetadata("'DOUSERCANCEL'",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E142B2',iparms:[{av:'AV5BookmarkName',fld:'vBOOKMARKNAME',pic:''},{av:'AV10BookmarkURL',fld:'vBOOKMARKURL',pic:''},{av:'AV18IsEdit',fld:'vISEDIT',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV5BookmarkName',fld:'vBOOKMARKNAME',pic:''},{av:'AV18IsEdit',fld:'vISEDIT',pic:''}]}");
         setEventMetadata("VALIDV_BOOKMARKURL","{handler:'Validv_Bookmarkurl',iparms:[]");
         setEventMetadata("VALIDV_BOOKMARKURL",",oparms:[]}");
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
         wcpOAV16InBookmarkURL = "";
         wcpOAV9BookmarkPageDescription = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblTextblockbookmarkname_Jsonclick = "";
         TempTags = "";
         AV5BookmarkName = "";
         lblTextblockbookmarkurl_Jsonclick = "";
         AV10BookmarkURL = "";
         bttBtnenter_Jsonclick = "";
         bttBtndel_Jsonclick = "";
         bttBtnusercancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13GridStateCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV14GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         AV30ProgramDescription = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV16InBookmarkURL = "";
         sCtrlAV9BookmarkPageDescription = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short AV29i ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavBookmarkname_Enabled ;
      private int edtavBookmarkurl_Enabled ;
      private int bttBtndel_Visible ;
      private int AV33GXV1 ;
      private int AV34GXV2 ;
      private int AV35GXV3 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtablebookmarkname_Internalname ;
      private string lblTextblockbookmarkname_Internalname ;
      private string lblTextblockbookmarkname_Jsonclick ;
      private string edtavBookmarkname_Internalname ;
      private string TempTags ;
      private string edtavBookmarkname_Jsonclick ;
      private string divUnnamedtablebookmarkurl_Internalname ;
      private string lblTextblockbookmarkurl_Internalname ;
      private string lblTextblockbookmarkurl_Jsonclick ;
      private string edtavBookmarkurl_Internalname ;
      private string edtavBookmarkurl_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtndel_Internalname ;
      private string bttBtndel_Jsonclick ;
      private string bttBtnusercancel_Internalname ;
      private string bttBtnusercancel_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlAV16InBookmarkURL ;
      private string sCtrlAV9BookmarkPageDescription ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18IsEdit ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19IsNameUnique ;
      private string AV16InBookmarkURL ;
      private string AV9BookmarkPageDescription ;
      private string wcpOAV16InBookmarkURL ;
      private string wcpOAV9BookmarkPageDescription ;
      private string AV5BookmarkName ;
      private string AV10BookmarkURL ;
      private string AV30ProgramDescription ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_InBookmarkURL ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV13GridStateCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV14GridStateCollectionItem ;
   }

}
