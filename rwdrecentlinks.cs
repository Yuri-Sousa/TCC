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
   public class rwdrecentlinks : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public rwdrecentlinks( )
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

      public rwdrecentlinks( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_FormCaption ,
                           string aP1_FormPgmName )
      {
         this.AV6FormCaption = aP0_FormCaption;
         this.AV7FormPgmName = aP1_FormPgmName;
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
               gxfirstwebparm = GetFirstPar( "FormCaption");
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
                  AV6FormCaption = GetPar( "FormCaption");
                  AssignAttri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
                  AV7FormPgmName = GetPar( "FormPgmName");
                  AssignAttri(sPrefix, false, "AV7FormPgmName", AV7FormPgmName);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6FormCaption,(string)AV7FormPgmName});
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
                  gxfirstwebparm = GetFirstPar( "FormCaption");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "FormCaption");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Links") == 0 )
               {
                  nRC_GXsfl_8 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_8"), "."));
                  nGXsfl_8_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_8_idx"), "."));
                  sGXsfl_8_idx = GetPar( "sGXsfl_8_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrLinks_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Links") == 0 )
               {
                  AV6FormCaption = GetPar( "FormCaption");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrLinks_refresh( AV6FormCaption, sPrefix) ;
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
            PA052( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS052( ) ;
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
            context.SendWebValue( "Responsive Recent Links") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281546821", false, true);
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
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rwdrecentlinks.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV6FormCaption)),UrlEncode(StringUtil.RTrim(AV7FormPgmName))}, new string[] {"FormCaption","FormPgmName"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_8", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_8), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6FormCaption", StringUtil.RTrim( wcpOAV6FormCaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7FormPgmName", wcpOAV7FormPgmName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFORMCAPTION", StringUtil.RTrim( AV6FormCaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFORMPGMNAME", AV7FormPgmName);
         GxWebStd.gx_hidden_field( context, sPrefix+"MAINTABLE_Class", StringUtil.RTrim( divMaintable_Class));
      }

      protected void RenderHtmlCloseForm052( )
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
         return "RwdRecentLinks" ;
      }

      public override string GetPgmdesc( )
      {
         return "Responsive Recent Links" ;
      }

      protected void WB050( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "rwdrecentlinks.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", divMaintable_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 col-md-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRecenttext_Internalname, "Recents", "", "", lblRecenttext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e11051_client"+"'", "", "RecentsTitle", 7, "", 1, 1, 0, 0, "HLP_RwdRecentLinks.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10 col-md-11", "left", "top", "", "", "div");
            /*  Grid Control  */
            LinksContainer.SetIsFreestyle(true);
            LinksContainer.SetWrapped(nGXWrapped);
            if ( LinksContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"LinksContainer"+"DivS\" data-gxgridid=\"8\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subLinks_Internalname, subLinks_Internalname, "", "RecentLinksGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               LinksContainer.AddObjectProperty("GridName", "Links");
            }
            else
            {
               LinksContainer.AddObjectProperty("GridName", "Links");
               LinksContainer.AddObjectProperty("Header", subLinks_Header);
               LinksContainer.AddObjectProperty("Class", StringUtil.RTrim( "RecentLinksGrid"));
               LinksContainer.AddObjectProperty("Class", "RecentLinksGrid");
               LinksContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               LinksContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               LinksContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Backcolorstyle), 1, 0, ".", "")));
               LinksContainer.AddObjectProperty("CmpContext", sPrefix);
               LinksContainer.AddObjectProperty("InMasterPage", "false");
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               LinksColumn.AddObjectProperty("Value", lblPlace_Caption);
               LinksContainer.AddColumnProperties(LinksColumn);
               LinksContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Selectedindex), 4, 0, ".", "")));
               LinksContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Allowselection), 1, 0, ".", "")));
               LinksContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Selectioncolor), 9, 0, ".", "")));
               LinksContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Allowhovering), 1, 0, ".", "")));
               LinksContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Hoveringcolor), 9, 0, ".", "")));
               LinksContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Allowcollapsing), 1, 0, ".", "")));
               LinksContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 8 )
         {
            wbEnd = 0;
            nRC_GXsfl_8 = (int)(nGXsfl_8_idx-1);
            if ( LinksContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"LinksContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Links", LinksContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"LinksContainerData", LinksContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"LinksContainerData"+"V", LinksContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"LinksContainerData"+"V"+"\" value='"+LinksContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 8 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( LinksContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"LinksContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Links", LinksContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"LinksContainerData", LinksContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"LinksContainerData"+"V", LinksContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"LinksContainerData"+"V"+"\" value='"+LinksContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START052( )
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
               Form.Meta.addItem("description", "Responsive Recent Links", 0) ;
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
               STRUP050( ) ;
            }
         }
      }

      protected void WS052( )
      {
         START052( ) ;
         EVT052( ) ;
      }

      protected void EVT052( )
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
                                 STRUP050( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP050( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "LINKS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP050( ) ;
                              }
                              nGXsfl_8_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_8_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_8_idx), 4, 0), 4, "0");
                              SubsflControlProps_82( ) ;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LINKS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E12052 ();
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
                                       STRUP050( ) ;
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

      protected void WE052( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm052( ) ;
            }
         }
      }

      protected void PA052( )
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

      protected void gxnrLinks_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_82( ) ;
         while ( nGXsfl_8_idx <= nRC_GXsfl_8 )
         {
            sendrow_82( ) ;
            nGXsfl_8_idx = ((subLinks_Islastpage==1)&&(nGXsfl_8_idx+1>subLinks_fnc_Recordsperpage( )) ? 1 : nGXsfl_8_idx+1);
            sGXsfl_8_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_8_idx), 4, 0), 4, "0");
            SubsflControlProps_82( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( LinksContainer)) ;
         /* End function gxnrLinks_newrow */
      }

      protected void gxgrLinks_refresh( string AV6FormCaption ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         LINKS_nCurrentRecord = 0;
         RF052( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrLinks_refresh */
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
         RF052( ) ;
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

      protected void RF052( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            LinksContainer.ClearRows();
         }
         wbStart = 8;
         nGXsfl_8_idx = 1;
         sGXsfl_8_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_8_idx), 4, 0), 4, "0");
         SubsflControlProps_82( ) ;
         bGXsfl_8_Refreshing = true;
         LinksContainer.AddObjectProperty("GridName", "Links");
         LinksContainer.AddObjectProperty("CmpContext", sPrefix);
         LinksContainer.AddObjectProperty("InMasterPage", "false");
         LinksContainer.AddObjectProperty("Class", StringUtil.RTrim( "RecentLinksGrid"));
         LinksContainer.AddObjectProperty("Class", "RecentLinksGrid");
         LinksContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         LinksContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         LinksContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subLinks_Backcolorstyle), 1, 0, ".", "")));
         LinksContainer.PageSize = subLinks_fnc_Recordsperpage( );
         if ( subLinks_Islastpage != 0 )
         {
            LINKS_nFirstRecordOnPage = (long)(subLinks_fnc_Recordcount( )-subLinks_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"LINKS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(LINKS_nFirstRecordOnPage), 15, 0, ".", "")));
            LinksContainer.AddObjectProperty("LINKS_nFirstRecordOnPage", LINKS_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_82( ) ;
            E12052 ();
            wbEnd = 8;
            WB050( ) ;
         }
         bGXsfl_8_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes052( )
      {
      }

      protected int subLinks_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subLinks_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subLinks_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subLinks_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP050( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_8 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_8"), ",", "."));
            wcpOAV6FormCaption = cgiGet( sPrefix+"wcpOAV6FormCaption");
            wcpOAV7FormPgmName = cgiGet( sPrefix+"wcpOAV7FormPgmName");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E12052( )
      {
         /* Links_Load Routine */
         returnInSub = false;
         AV11RecentLinksItems.FromXml(AV8Session.Get("RecentLinks"), null, "LinkList", "GeneXus");
         AV9i = 1;
         while ( AV9i <= AV11RecentLinksItems.Count )
         {
            AV12RecentLinksItem = ((SdtLinkList_LinkItem)AV11RecentLinksItems.Item(AV9i));
            if ( StringUtil.StrCmp(StringUtil.Trim( AV12RecentLinksItem.gxTpr_Caption), StringUtil.Trim( AV6FormCaption)) == 0 )
            {
               AV11RecentLinksItems.RemoveItem(AV9i);
            }
            else
            {
               AV9i = (int)(AV9i+1);
            }
         }
         while ( AV11RecentLinksItems.Count > 8 - 1 )
         {
            AV11RecentLinksItems.RemoveItem(1);
         }
         AV12RecentLinksItem = new SdtLinkList_LinkItem(context);
         AV12RecentLinksItem.gxTpr_Caption = StringUtil.Trim( AV6FormCaption);
         AV12RecentLinksItem.gxTpr_Url = AV10Request.ScriptName+"?"+AV10Request.QueryString;
         AV11RecentLinksItems.Add(AV12RecentLinksItem, 0);
         AV8Session.Set("RecentLinks", AV11RecentLinksItems.ToXml(false, true, "LinkList", "GeneXus"));
         AV9i = 1;
         while ( AV9i <= AV11RecentLinksItems.Count )
         {
            AV12RecentLinksItem = ((SdtLinkList_LinkItem)AV11RecentLinksItems.Item(AV9i));
            AV13PlaceCaption = AV12RecentLinksItem.gxTpr_Caption;
            if ( StringUtil.Len( AV13PlaceCaption) > 20 )
            {
               AV13PlaceCaption = StringUtil.Format( "%1...", StringUtil.Substring( AV13PlaceCaption, 1, 18), "", "", "", "", "", "", "", "");
            }
            lblPlace_Caption = AV13PlaceCaption;
            if ( AV9i < AV11RecentLinksItems.Count )
            {
               lblPlace_Link = formatLink(AV12RecentLinksItem.gxTpr_Url) ;
            }
            else
            {
               lblPlace_Link = "";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 8;
            }
            sendrow_82( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_8_Refreshing )
            {
               context.DoAjaxLoad(8, LinksRow);
            }
            AV9i = (int)(AV9i+1);
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6FormCaption = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
         AV7FormPgmName = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV7FormPgmName", AV7FormPgmName);
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
         PA052( ) ;
         WS052( ) ;
         WE052( ) ;
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
         sCtrlAV6FormCaption = (string)((string)getParm(obj,0));
         sCtrlAV7FormPgmName = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA052( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "rwdrecentlinks", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA052( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6FormCaption = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
            AV7FormPgmName = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV7FormPgmName", AV7FormPgmName);
         }
         wcpOAV6FormCaption = cgiGet( sPrefix+"wcpOAV6FormCaption");
         wcpOAV7FormPgmName = cgiGet( sPrefix+"wcpOAV7FormPgmName");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6FormCaption, wcpOAV6FormCaption) != 0 ) || ( StringUtil.StrCmp(AV7FormPgmName, wcpOAV7FormPgmName) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV6FormCaption = AV6FormCaption;
         wcpOAV7FormPgmName = AV7FormPgmName;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6FormCaption = cgiGet( sPrefix+"AV6FormCaption_CTRL");
         if ( StringUtil.Len( sCtrlAV6FormCaption) > 0 )
         {
            AV6FormCaption = cgiGet( sCtrlAV6FormCaption);
            AssignAttri(sPrefix, false, "AV6FormCaption", AV6FormCaption);
         }
         else
         {
            AV6FormCaption = cgiGet( sPrefix+"AV6FormCaption_PARM");
         }
         sCtrlAV7FormPgmName = cgiGet( sPrefix+"AV7FormPgmName_CTRL");
         if ( StringUtil.Len( sCtrlAV7FormPgmName) > 0 )
         {
            AV7FormPgmName = cgiGet( sCtrlAV7FormPgmName);
            AssignAttri(sPrefix, false, "AV7FormPgmName", AV7FormPgmName);
         }
         else
         {
            AV7FormPgmName = cgiGet( sPrefix+"AV7FormPgmName_PARM");
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
         PA052( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS052( ) ;
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
         WS052( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6FormCaption_PARM", StringUtil.RTrim( AV6FormCaption));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6FormCaption)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6FormCaption_CTRL", StringUtil.RTrim( sCtrlAV6FormCaption));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7FormPgmName_PARM", AV7FormPgmName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7FormPgmName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7FormPgmName_CTRL", StringUtil.RTrim( sCtrlAV7FormPgmName));
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
         WE052( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281546855", true, true);
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
         context.AddJavascriptSource("rwdrecentlinks.js", "?20214281546855", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_82( )
      {
         lblPlace_Internalname = sPrefix+"PLACE_"+sGXsfl_8_idx;
      }

      protected void SubsflControlProps_fel_82( )
      {
         lblPlace_Internalname = sPrefix+"PLACE_"+sGXsfl_8_fel_idx;
      }

      protected void sendrow_82( )
      {
         SubsflControlProps_82( ) ;
         WB050( ) ;
         LinksRow = GXWebRow.GetNew(context,LinksContainer);
         if ( subLinks_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subLinks_Backstyle = 0;
            if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
            {
               subLinks_Linesclass = subLinks_Class+"Odd";
            }
         }
         else if ( subLinks_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subLinks_Backstyle = 0;
            subLinks_Backcolor = subLinks_Allbackcolor;
            if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
            {
               subLinks_Linesclass = subLinks_Class+"Uniform";
            }
         }
         else if ( subLinks_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subLinks_Backstyle = 1;
            if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
            {
               subLinks_Linesclass = subLinks_Class+"Odd";
            }
            subLinks_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subLinks_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subLinks_Backstyle = 1;
            if ( ((int)((nGXsfl_8_idx) % (2))) == 0 )
            {
               subLinks_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
               {
                  subLinks_Linesclass = subLinks_Class+"Even";
               }
            }
            else
            {
               subLinks_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subLinks_Class, "") != 0 )
               {
                  subLinks_Linesclass = subLinks_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( LinksContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subLinks_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_8_idx+"\">") ;
         }
         /* Div Control */
         LinksRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLinkstable_Internalname+"_"+sGXsfl_8_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"RecentLinksTable",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         LinksRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         LinksRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         LinksRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblPlace_Internalname,(string)lblPlace_Caption,(string)lblPlace_Link,(string)"",(string)lblPlace_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"RecentLinkItem",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         LinksRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         LinksRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         LinksRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes052( ) ;
         /* End of Columns property logic. */
         LinksContainer.AddRow(LinksRow);
         nGXsfl_8_idx = ((subLinks_Islastpage==1)&&(nGXsfl_8_idx+1>subLinks_fnc_Recordsperpage( )) ? 1 : nGXsfl_8_idx+1);
         sGXsfl_8_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_8_idx), 4, 0), 4, "0");
         SubsflControlProps_82( ) ;
         /* End function sendrow_82 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblRecenttext_Internalname = sPrefix+"RECENTTEXT";
         lblPlace_Internalname = sPrefix+"PLACE";
         divLinkstable_Internalname = sPrefix+"LINKSTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subLinks_Internalname = sPrefix+"LINKS";
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
         lblPlace_Link = "";
         lblPlace_Caption = "Place.";
         subLinks_Class = "RecentLinksGrid";
         subLinks_Allowcollapsing = 0;
         lblPlace_Caption = "Place.";
         subLinks_Backcolorstyle = 0;
         divMaintable_Class = "RecentLinksMainTable";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'LINKS_nFirstRecordOnPage'},{av:'LINKS_nEOF'},{av:'AV6FormCaption',fld:'vFORMCAPTION',pic:''},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("RECENTTEXT.CLICK","{handler:'E11051',iparms:[{av:'divMaintable_Class',ctrl:'MAINTABLE',prop:'Class'}]");
         setEventMetadata("RECENTTEXT.CLICK",",oparms:[{av:'divMaintable_Class',ctrl:'MAINTABLE',prop:'Class'}]}");
         setEventMetadata("LINKS.LOAD","{handler:'E12052',iparms:[{av:'AV6FormCaption',fld:'vFORMCAPTION',pic:''}]");
         setEventMetadata("LINKS.LOAD",",oparms:[{av:'lblPlace_Caption',ctrl:'PLACE',prop:'Caption'},{av:'lblPlace_Link',ctrl:'PLACE',prop:'Link'}]}");
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
         wcpOAV6FormCaption = "";
         wcpOAV7FormPgmName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         lblRecenttext_Jsonclick = "";
         LinksContainer = new GXWebGrid( context);
         sStyleString = "";
         subLinks_Header = "";
         LinksColumn = new GXWebColumn();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11RecentLinksItems = new GXBaseCollection<SdtLinkList_LinkItem>( context, "LinkItem", "GeneXus");
         AV8Session = context.GetSession();
         AV12RecentLinksItem = new SdtLinkList_LinkItem(context);
         AV10Request = new GxHttpRequest( context);
         AV13PlaceCaption = "";
         LinksRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6FormCaption = "";
         sCtrlAV7FormPgmName = "";
         subLinks_Linesclass = "";
         lblPlace_Jsonclick = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subLinks_Backcolorstyle ;
      private short subLinks_Allowselection ;
      private short subLinks_Allowhovering ;
      private short subLinks_Allowcollapsing ;
      private short subLinks_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subLinks_Backstyle ;
      private short LINKS_nEOF ;
      private int nRC_GXsfl_8 ;
      private int nGXsfl_8_idx=1 ;
      private int subLinks_Selectedindex ;
      private int subLinks_Selectioncolor ;
      private int subLinks_Hoveringcolor ;
      private int subLinks_Islastpage ;
      private int AV9i ;
      private int idxLst ;
      private int subLinks_Backcolor ;
      private int subLinks_Allbackcolor ;
      private long LINKS_nCurrentRecord ;
      private long LINKS_nFirstRecordOnPage ;
      private string AV6FormCaption ;
      private string wcpOAV6FormCaption ;
      private string divMaintable_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_8_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string lblRecenttext_Internalname ;
      private string lblRecenttext_Jsonclick ;
      private string sStyleString ;
      private string subLinks_Internalname ;
      private string subLinks_Header ;
      private string lblPlace_Caption ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblPlace_Link ;
      private string sCtrlAV6FormCaption ;
      private string sCtrlAV7FormPgmName ;
      private string lblPlace_Internalname ;
      private string sGXsfl_8_fel_idx="0001" ;
      private string subLinks_Class ;
      private string subLinks_Linesclass ;
      private string divLinkstable_Internalname ;
      private string lblPlace_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_8_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV7FormPgmName ;
      private string wcpOAV7FormPgmName ;
      private string AV13PlaceCaption ;
      private IGxSession AV8Session ;
      private GXWebGrid LinksContainer ;
      private GXWebRow LinksRow ;
      private GXWebColumn LinksColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10Request ;
      private GXBaseCollection<SdtLinkList_LinkItem> AV11RecentLinksItems ;
      private SdtLinkList_LinkItem AV12RecentLinksItem ;
   }

}
