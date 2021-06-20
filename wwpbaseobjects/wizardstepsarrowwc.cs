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
   public class wizardstepsarrowwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wizardstepsarrowwc( )
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

      public wizardstepsarrowwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> aP0_WizardSteps ,
                           string aP1_SelectedStep )
      {
         this.AV18WizardSteps = aP0_WizardSteps;
         this.AV11SelectedStep = aP1_SelectedStep;
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
               gxfirstwebparm = GetFirstPar( "WizardSteps");
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
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV18WizardSteps);
                  AV11SelectedStep = GetPar( "SelectedStep");
                  AssignAttri(sPrefix, false, "AV11SelectedStep", AV11SelectedStep);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)AV18WizardSteps,(string)AV11SelectedStep});
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
                  gxfirstwebparm = GetFirstPar( "WizardSteps");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WizardSteps");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwizardsteps") == 0 )
               {
                  nRC_GXsfl_5 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_5"), "."));
                  nGXsfl_5_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_5_idx"), "."));
                  sGXsfl_5_idx = GetPar( "sGXsfl_5_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGridwizardsteps_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridwizardsteps") == 0 )
               {
                  AV15StepRealNumber = (short)(NumberUtil.Val( GetPar( "StepRealNumber"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV19WizardStepsAux);
                  AV11SelectedStep = GetPar( "SelectedStep");
                  AV9PreviousSelected = StringUtil.StrToBool( GetPar( "PreviousSelected"));
                  AV14StepNumber = (short)(NumberUtil.Val( GetPar( "StepNumber"), "."));
                  AV5FirstIsDummy = StringUtil.StrToBool( GetPar( "FirstIsDummy"));
                  AV6LastIsDummy = StringUtil.StrToBool( GetPar( "LastIsDummy"));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV18WizardSteps);
                  AV10SecondIsDummy = StringUtil.StrToBool( GetPar( "SecondIsDummy"));
                  AV8PenultimateIsDummy = StringUtil.StrToBool( GetPar( "PenultimateIsDummy"));
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGridwizardsteps_refresh( AV15StepRealNumber, AV19WizardStepsAux, AV11SelectedStep, AV9PreviousSelected, AV14StepNumber, AV5FirstIsDummy, AV6LastIsDummy, AV18WizardSteps, AV10SecondIsDummy, AV8PenultimateIsDummy, sPrefix) ;
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
            PA0K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavWizardstepsaux__title_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizardstepsaux__title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizardstepsaux__title_Enabled), 5, 0), !bGXsfl_5_Refreshing);
               WS0K2( ) ;
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
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
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
            context.SendWebValue( "Wizard Steps Arrow WC") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281546765", false, true);
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
            context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("wwpbaseobjects.wizardstepsarrowwc.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11SelectedStep))}, new string[] {"WizardSteps","SelectedStep"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "Form", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15StepRealNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPSAUX", GetSecureSignedToken( sPrefix, AV19WizardStepsAux, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREVIOUSSELECTED", GetSecureSignedToken( sPrefix, AV9PreviousSelected, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14StepNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV5FirstIsDummy, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV6LastIsDummy, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECONDISDUMMY", GetSecureSignedToken( sPrefix, AV10SecondIsDummy, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV8PenultimateIsDummy, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wizardstepsaux", AV19WizardStepsAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wizardstepsaux", AV19WizardStepsAux);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Wizardstepsaux", GetSecureSignedToken( sPrefix, AV19WizardStepsAux, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_5", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_5), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11SelectedStep", wcpOAV11SelectedStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPREALNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15StepRealNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15StepRealNumber), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPSAUX", AV19WizardStepsAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPSAUX", AV19WizardStepsAux);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPSAUX", GetSecureSignedToken( sPrefix, AV19WizardStepsAux, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDSTEP", AV11SelectedStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPREVIOUSSELECTED", AV9PreviousSelected);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREVIOUSSELECTED", GetSecureSignedToken( sPrefix, AV9PreviousSelected, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14StepNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14StepNumber), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFIRSTISDUMMY", AV5FirstIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV5FirstIsDummy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vLASTISDUMMY", AV6LastIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV6LastIsDummy, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPS", AV18WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPS", AV18WizardSteps);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vSECONDISDUMMY", AV10SecondIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECONDISDUMMY", GetSecureSignedToken( sPrefix, AV10SecondIsDummy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPENULTIMATEISDUMMY", AV8PenultimateIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV8PenultimateIsDummy, context));
      }

      protected void RenderHtmlCloseForm0K2( )
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
         return "WWPBaseObjects.WizardStepsArrowWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wizard Steps Arrow WC" ;
      }

      protected void WB0K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wizardstepsarrowwc.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_0K2( true) ;
         }
         else
         {
            wb_table1_2_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         if ( wbEnd == 5 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridwizardstepsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV24GXV1 = nGXsfl_5_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridwizardstepsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridwizardsteps", GridwizardstepsContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridwizardstepsContainerData", GridwizardstepsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridwizardstepsContainerData"+"V", GridwizardstepsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridwizardstepsContainerData"+"V"+"\" value='"+GridwizardstepsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0K2( )
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
               Form.Meta.addItem("description", "Wizard Steps Arrow WC", 0) ;
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
               STRUP0K0( ) ;
            }
         }
      }

      protected void WS0K2( )
      {
         START0K2( ) ;
         EVT0K2( ) ;
      }

      protected void EVT0K2( )
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
                                 STRUP0K0( ) ;
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
                                 STRUP0K0( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "GRIDWIZARDSTEPS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0K0( ) ;
                              }
                              nGXsfl_5_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_5_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_idx), 4, 0), 4, "0");
                              SubsflControlProps_52( ) ;
                              AV24GXV1 = nGXsfl_5_idx;
                              if ( ( AV19WizardStepsAux.Count >= AV24GXV1 ) && ( AV24GXV1 > 0 ) )
                              {
                                 AV19WizardStepsAux.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV19WizardStepsAux.Item(AV24GXV1));
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
                                          /* Execute user event: Start */
                                          E110K2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDWIZARDSTEPS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E120K2 ();
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
                                       STRUP0K0( ) ;
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

      protected void WE0K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0K2( ) ;
            }
         }
      }

      protected void PA0K2( )
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

      protected void gxnrGridwizardsteps_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_52( ) ;
         while ( nGXsfl_5_idx <= nRC_GXsfl_5 )
         {
            sendrow_52( ) ;
            nGXsfl_5_idx = ((subGridwizardsteps_Islastpage==1)&&(nGXsfl_5_idx+1>subGridwizardsteps_fnc_Recordsperpage( )) ? 1 : nGXsfl_5_idx+1);
            sGXsfl_5_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_idx), 4, 0), 4, "0");
            SubsflControlProps_52( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridwizardstepsContainer)) ;
         /* End function gxnrGridwizardsteps_newrow */
      }

      protected void gxgrGridwizardsteps_refresh( short AV15StepRealNumber ,
                                                  GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV19WizardStepsAux ,
                                                  string AV11SelectedStep ,
                                                  bool AV9PreviousSelected ,
                                                  short AV14StepNumber ,
                                                  bool AV5FirstIsDummy ,
                                                  bool AV6LastIsDummy ,
                                                  GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV18WizardSteps ,
                                                  bool AV10SecondIsDummy ,
                                                  bool AV8PenultimateIsDummy ,
                                                  string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDWIZARDSTEPS_nCurrentRecord = 0;
         RF0K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridwizardsteps_refresh */
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
         RF0K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavWizardstepsaux__title_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizardstepsaux__title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizardstepsaux__title_Enabled), 5, 0), !bGXsfl_5_Refreshing);
      }

      protected void RF0K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridwizardstepsContainer.ClearRows();
         }
         wbStart = 5;
         nGXsfl_5_idx = 1;
         sGXsfl_5_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_idx), 4, 0), 4, "0");
         SubsflControlProps_52( ) ;
         bGXsfl_5_Refreshing = true;
         GridwizardstepsContainer.AddObjectProperty("GridName", "Gridwizardsteps");
         GridwizardstepsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridwizardstepsContainer.AddObjectProperty("InMasterPage", "false");
         GridwizardstepsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleSteps"));
         GridwizardstepsContainer.AddObjectProperty("Class", "FreeStyleSteps");
         GridwizardstepsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridwizardstepsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridwizardstepsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Backcolorstyle), 1, 0, ".", "")));
         GridwizardstepsContainer.PageSize = subGridwizardsteps_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_52( ) ;
            E120K2 ();
            wbEnd = 5;
            WB0K0( ) ;
         }
         bGXsfl_5_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0K2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPREALNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15StepRealNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15StepRealNumber), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPSAUX", AV19WizardStepsAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPSAUX", AV19WizardStepsAux);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPSAUX", GetSecureSignedToken( sPrefix, AV19WizardStepsAux, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPREVIOUSSELECTED", AV9PreviousSelected);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREVIOUSSELECTED", GetSecureSignedToken( sPrefix, AV9PreviousSelected, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14StepNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14StepNumber), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFIRSTISDUMMY", AV5FirstIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV5FirstIsDummy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vLASTISDUMMY", AV6LastIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV6LastIsDummy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vSECONDISDUMMY", AV10SecondIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECONDISDUMMY", GetSecureSignedToken( sPrefix, AV10SecondIsDummy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPENULTIMATEISDUMMY", AV8PenultimateIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV8PenultimateIsDummy, context));
      }

      protected int subGridwizardsteps_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridwizardsteps_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridwizardsteps_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridwizardsteps_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavWizardstepsaux__title_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizardstepsaux__title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizardstepsaux__title_Enabled), 5, 0), !bGXsfl_5_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wizardstepsaux"), AV19WizardStepsAux);
            /* Read saved values. */
            nRC_GXsfl_5 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_5"), ",", "."));
            wcpOAV11SelectedStep = cgiGet( sPrefix+"wcpOAV11SelectedStep");
            nRC_GXsfl_5 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_5"), ",", "."));
            nGXsfl_5_fel_idx = 0;
            while ( nGXsfl_5_fel_idx < nRC_GXsfl_5 )
            {
               nGXsfl_5_fel_idx = ((subGridwizardsteps_Islastpage==1)&&(nGXsfl_5_fel_idx+1>subGridwizardsteps_fnc_Recordsperpage( )) ? 1 : nGXsfl_5_fel_idx+1);
               sGXsfl_5_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_52( ) ;
               AV24GXV1 = nGXsfl_5_fel_idx;
               if ( ( AV19WizardStepsAux.Count >= AV24GXV1 ) && ( AV24GXV1 > 0 ) )
               {
                  AV19WizardStepsAux.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV19WizardStepsAux.Item(AV24GXV1));
               }
            }
            if ( nGXsfl_5_fel_idx == 0 )
            {
               nGXsfl_5_idx = 1;
               sGXsfl_5_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_idx), 4, 0), 4, "0");
               SubsflControlProps_52( ) ;
            }
            nGXsfl_5_fel_idx = 1;
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

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110K2 ();
         if (returnInSub) return;
      }

      protected void E110K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV7MaxStepsToShow = 8;
         AV19WizardStepsAux = (GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)(AV18WizardSteps.Clone());
         gx_BV5 = true;
         AV14StepNumber = 1;
         AssignAttri(sPrefix, false, "AV14StepNumber", StringUtil.LTrimStr( (decimal)(AV14StepNumber), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14StepNumber), "ZZZ9"), context));
         AV15StepRealNumber = 1;
         AssignAttri(sPrefix, false, "AV15StepRealNumber", StringUtil.LTrimStr( (decimal)(AV15StepRealNumber), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15StepRealNumber), "ZZZ9"), context));
         AV9PreviousSelected = false;
         AssignAttri(sPrefix, false, "AV9PreviousSelected", AV9PreviousSelected);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREVIOUSSELECTED", GetSecureSignedToken( sPrefix, AV9PreviousSelected, context));
         AV5FirstIsDummy = false;
         AssignAttri(sPrefix, false, "AV5FirstIsDummy", AV5FirstIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV5FirstIsDummy, context));
         AV10SecondIsDummy = false;
         AssignAttri(sPrefix, false, "AV10SecondIsDummy", AV10SecondIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECONDISDUMMY", GetSecureSignedToken( sPrefix, AV10SecondIsDummy, context));
         AV8PenultimateIsDummy = false;
         AssignAttri(sPrefix, false, "AV8PenultimateIsDummy", AV8PenultimateIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV8PenultimateIsDummy, context));
         AV6LastIsDummy = false;
         AssignAttri(sPrefix, false, "AV6LastIsDummy", AV6LastIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV6LastIsDummy, context));
         if ( AV19WizardStepsAux.Count > AV7MaxStepsToShow )
         {
            AV7MaxStepsToShow = (short)(AV7MaxStepsToShow-1);
            AV12SelectedStepIndex = 1;
            AV26GXV3 = 1;
            while ( AV26GXV3 <= AV19WizardStepsAux.Count )
            {
               AV17WizardStep = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV19WizardStepsAux.Item(AV26GXV3));
               if ( StringUtil.StrCmp(AV17WizardStep.gxTpr_Code, AV11SelectedStep) == 0 )
               {
                  if (true) break;
               }
               AV12SelectedStepIndex = (short)(AV12SelectedStepIndex+1);
               AV26GXV3 = (int)(AV26GXV3+1);
            }
            if ( AV12SelectedStepIndex > AV19WizardStepsAux.Count )
            {
               AV12SelectedStepIndex = 1;
            }
            AV13StartIndex = 1;
            if ( (Convert.ToDecimal( AV12SelectedStepIndex + 1 ) > ( AV7MaxStepsToShow ) /  ( decimal )( 2 ) ) )
            {
               AV13StartIndex = (short)(AV12SelectedStepIndex+1-(AV7MaxStepsToShow)/ (decimal)(2));
               if ( AV13StartIndex + AV7MaxStepsToShow > AV19WizardStepsAux.Count + 1 )
               {
                  AV13StartIndex = (short)(AV19WizardStepsAux.Count+1-AV7MaxStepsToShow);
               }
            }
            AV15StepRealNumber = AV13StartIndex;
            AssignAttri(sPrefix, false, "AV15StepRealNumber", StringUtil.LTrimStr( (decimal)(AV15StepRealNumber), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15StepRealNumber), "ZZZ9"), context));
            if ( AV13StartIndex > 1 )
            {
               AV5FirstIsDummy = true;
               AssignAttri(sPrefix, false, "AV5FirstIsDummy", AV5FirstIsDummy);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV5FirstIsDummy, context));
               AV7MaxStepsToShow = (short)(AV7MaxStepsToShow+1);
               if ( AV13StartIndex > 2 )
               {
                  AV10SecondIsDummy = true;
                  AssignAttri(sPrefix, false, "AV10SecondIsDummy", AV10SecondIsDummy);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECONDISDUMMY", GetSecureSignedToken( sPrefix, AV10SecondIsDummy, context));
                  AV7MaxStepsToShow = (short)(AV7MaxStepsToShow+1);
                  ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV19WizardStepsAux.Item(2)).gxTpr_Title = "...";
                  while ( AV13StartIndex > 3 )
                  {
                     AV19WizardStepsAux.RemoveItem(3);
                     gx_BV5 = true;
                     AV13StartIndex = (short)(AV13StartIndex-1);
                  }
               }
            }
            if ( AV19WizardStepsAux.Count > AV7MaxStepsToShow )
            {
               AV6LastIsDummy = true;
               AssignAttri(sPrefix, false, "AV6LastIsDummy", AV6LastIsDummy);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV6LastIsDummy, context));
               if ( AV19WizardStepsAux.Count > AV7MaxStepsToShow + 1 )
               {
                  AV8PenultimateIsDummy = true;
                  AssignAttri(sPrefix, false, "AV8PenultimateIsDummy", AV8PenultimateIsDummy);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV8PenultimateIsDummy, context));
                  ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV19WizardStepsAux.Item(AV19WizardStepsAux.Count-1)).gxTpr_Title = "...";
                  while ( AV19WizardStepsAux.Count > AV7MaxStepsToShow + 2 )
                  {
                     AV19WizardStepsAux.RemoveItem(AV19WizardStepsAux.Count-2);
                     gx_BV5 = true;
                  }
               }
            }
         }
      }

      private void E120K2( )
      {
         /* Gridwizardsteps_Load Routine */
         returnInSub = false;
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV19WizardStepsAux.Count )
         {
            AV19WizardStepsAux.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV19WizardStepsAux.Item(AV24GXV1));
            AV16TableContainerStepClass = "TableContainerStep";
            lblStepnumber_Caption = context.localUtil.Format( (decimal)(AV15StepRealNumber), "ZZZ9");
            if ( StringUtil.StrCmp(((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)(AV19WizardStepsAux.CurrentItem)).gxTpr_Code, AV11SelectedStep) == 0 )
            {
               edtavWizardstepsaux__title_Class = "AttributeStepSelected";
               imgStepimg_Bitmap = context.GetImagePath( "8f7f2ead-3d17-4e23-a450-7d98b62b7f40", "", context.GetTheme( ));
               imgStepimg_Class = "StepImage";
               AV16TableContainerStepClass = "TableContainerStepSelected";
               lblStepnumber_Class = "StepNumberSelected";
               divTblstep_Class = "TableStepSelected";
               AssignProp(sPrefix, false, divTblstep_Internalname, "Class", divTblstep_Class, !bGXsfl_5_Refreshing);
               AV9PreviousSelected = true;
               AssignAttri(sPrefix, false, "AV9PreviousSelected", AV9PreviousSelected);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREVIOUSSELECTED", GetSecureSignedToken( sPrefix, AV9PreviousSelected, context));
            }
            else
            {
               imgStepimg_Bitmap = context.GetImagePath( "2fe377a7-df7d-42aa-84d4-4f1b853d50aa", "", context.GetTheme( ));
               if ( AV9PreviousSelected )
               {
                  imgStepimg_Class = "StepImage";
               }
               else
               {
                  imgStepimg_Class = "StepImageUnSelected";
               }
               lblStepnumber_Class = "StepNumber";
               divTblstep_Class = "TableStep";
               AssignProp(sPrefix, false, divTblstep_Internalname, "Class", divTblstep_Class, !bGXsfl_5_Refreshing);
               edtavWizardstepsaux__title_Class = "AttributeStep";
               AV9PreviousSelected = false;
               AssignAttri(sPrefix, false, "AV9PreviousSelected", AV9PreviousSelected);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPREVIOUSSELECTED", GetSecureSignedToken( sPrefix, AV9PreviousSelected, context));
            }
            if ( AV14StepNumber == 1 )
            {
               imgStepimg_Visible = 0;
               AV16TableContainerStepClass += " " + "TableContainerStepFirst";
            }
            else
            {
               if ( AV14StepNumber == AV19WizardStepsAux.Count )
               {
                  AV16TableContainerStepClass += " " + "TableContainerStepLast";
               }
               imgStepimg_Visible = 1;
            }
            tblTblcontainerstep_Class = AV16TableContainerStepClass;
            AssignProp(sPrefix, false, tblTblcontainerstep_Internalname, "Class", tblTblcontainerstep_Class, !bGXsfl_5_Refreshing);
            divTblstep_Visible = 1;
            AssignProp(sPrefix, false, divTblstep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblstep_Visible), 5, 0), !bGXsfl_5_Refreshing);
            lblStepnumber_Visible = 1;
            edtavWizardstepsaux__title_Visible = 1;
            if ( ( AV14StepNumber == 1 ) && AV5FirstIsDummy )
            {
               lblStepnumber_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(AV14StepNumber), 4, 0));
               edtavWizardstepsaux__title_Visible = 0;
            }
            else if ( ( AV14StepNumber == AV19WizardStepsAux.Count ) && AV6LastIsDummy )
            {
               lblStepnumber_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(AV18WizardSteps.Count), 9, 0));
               edtavWizardstepsaux__title_Visible = 0;
            }
            else if ( ( ( AV14StepNumber == 2 ) && AV10SecondIsDummy ) || ( ( AV14StepNumber == AV19WizardStepsAux.Count - 1 ) && AV8PenultimateIsDummy ) )
            {
               lblStepnumber_Visible = 0;
               divTblstep_Visible = 0;
               AssignProp(sPrefix, false, divTblstep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblstep_Visible), 5, 0), !bGXsfl_5_Refreshing);
            }
            else
            {
               AV15StepRealNumber = (short)(AV15StepRealNumber+1);
               AssignAttri(sPrefix, false, "AV15StepRealNumber", StringUtil.LTrimStr( (decimal)(AV15StepRealNumber), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15StepRealNumber), "ZZZ9"), context));
            }
            AV14StepNumber = (short)(AV14StepNumber+1);
            AssignAttri(sPrefix, false, "AV14StepNumber", StringUtil.LTrimStr( (decimal)(AV14StepNumber), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14StepNumber), "ZZZ9"), context));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 5;
            }
            sendrow_52( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_5_Refreshing )
            {
               context.DoAjaxLoad(5, GridwizardstepsRow);
            }
            AV24GXV1 = (int)(AV24GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table1_2_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableWizardStepsArrow", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='WizardStepsContainerCell'>") ;
            /*  Grid Control  */
            GridwizardstepsContainer.SetIsFreestyle(true);
            GridwizardstepsContainer.SetWrapped(nGXWrapped);
            if ( GridwizardstepsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridwizardstepsContainer"+"DivS\" data-gxgridid=\"5\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridwizardsteps_Internalname, subGridwizardsteps_Internalname, "", "FreeStyleSteps", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridwizardstepsContainer.AddObjectProperty("GridName", "Gridwizardsteps");
            }
            else
            {
               GridwizardstepsContainer.AddObjectProperty("GridName", "Gridwizardsteps");
               GridwizardstepsContainer.AddObjectProperty("Header", subGridwizardsteps_Header);
               GridwizardstepsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleSteps"));
               GridwizardstepsContainer.AddObjectProperty("Class", "FreeStyleSteps");
               GridwizardstepsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Backcolorstyle), 1, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("CmpContext", sPrefix);
               GridwizardstepsContainer.AddObjectProperty("InMasterPage", "false");
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsColumn.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "2fe377a7-df7d-42aa-84d4-4f1b853d50aa", "", context.GetTheme( ))));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsColumn.AddObjectProperty("Value", lblStepnumber_Caption);
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavWizardstepsaux__title_Class));
               GridwizardstepsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizardstepsaux__title_Enabled), 5, 0, ".", "")));
               GridwizardstepsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizardstepsaux__title_Visible), 5, 0, ".", "")));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Selectedindex), 4, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Allowselection), 1, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Selectioncolor), 9, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Allowhovering), 1, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Hoveringcolor), 9, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Allowcollapsing), 1, 0, ".", "")));
               GridwizardstepsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwizardsteps_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 5 )
         {
            wbEnd = 0;
            nRC_GXsfl_5 = (int)(nGXsfl_5_idx-1);
            if ( GridwizardstepsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV24GXV1 = nGXsfl_5_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridwizardstepsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridwizardsteps", GridwizardstepsContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridwizardstepsContainerData", GridwizardstepsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridwizardstepsContainerData"+"V", GridwizardstepsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridwizardstepsContainerData"+"V"+"\" value='"+GridwizardstepsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0K2e( true) ;
         }
         else
         {
            wb_table1_2_0K2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV18WizardSteps = (GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)getParm(obj,0);
         AV11SelectedStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV11SelectedStep", AV11SelectedStep);
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
         PA0K2( ) ;
         WS0K2( ) ;
         WE0K2( ) ;
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
         sCtrlAV18WizardSteps = (string)((string)getParm(obj,0));
         sCtrlAV11SelectedStep = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wizardstepsarrowwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV18WizardSteps = (GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)getParm(obj,2);
            AV11SelectedStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV11SelectedStep", AV11SelectedStep);
         }
         wcpOAV11SelectedStep = cgiGet( sPrefix+"wcpOAV11SelectedStep");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV11SelectedStep, wcpOAV11SelectedStep) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV11SelectedStep = AV11SelectedStep;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV18WizardSteps = cgiGet( sPrefix+"AV18WizardSteps_CTRL");
         if ( StringUtil.Len( sCtrlAV18WizardSteps) > 0 )
         {
            AV18WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>();
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV18WizardSteps_PARM"), AV18WizardSteps);
         }
         sCtrlAV11SelectedStep = cgiGet( sPrefix+"AV11SelectedStep_CTRL");
         if ( StringUtil.Len( sCtrlAV11SelectedStep) > 0 )
         {
            AV11SelectedStep = cgiGet( sCtrlAV11SelectedStep);
            AssignAttri(sPrefix, false, "AV11SelectedStep", AV11SelectedStep);
         }
         else
         {
            AV11SelectedStep = cgiGet( sPrefix+"AV11SelectedStep_PARM");
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
         PA0K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0K2( ) ;
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
         WS0K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV18WizardSteps_PARM", AV18WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV18WizardSteps_PARM", AV18WizardSteps);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18WizardSteps)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18WizardSteps_CTRL", StringUtil.RTrim( sCtrlAV18WizardSteps));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11SelectedStep_PARM", AV11SelectedStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11SelectedStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11SelectedStep_CTRL", StringUtil.RTrim( sCtrlAV11SelectedStep));
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
         WE0K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281546835", true, true);
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
            context.AddJavascriptSource("wwpbaseobjects/wizardstepsarrowwc.js", "?20214281546836", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_52( )
      {
         imgStepimg_Internalname = sPrefix+"STEPIMG_"+sGXsfl_5_idx;
         lblStepnumber_Internalname = sPrefix+"STEPNUMBER_"+sGXsfl_5_idx;
         edtavWizardstepsaux__title_Internalname = sPrefix+"WIZARDSTEPSAUX__TITLE_"+sGXsfl_5_idx;
      }

      protected void SubsflControlProps_fel_52( )
      {
         imgStepimg_Internalname = sPrefix+"STEPIMG_"+sGXsfl_5_fel_idx;
         lblStepnumber_Internalname = sPrefix+"STEPNUMBER_"+sGXsfl_5_fel_idx;
         edtavWizardstepsaux__title_Internalname = sPrefix+"WIZARDSTEPSAUX__TITLE_"+sGXsfl_5_fel_idx;
      }

      protected void sendrow_52( )
      {
         SubsflControlProps_52( ) ;
         WB0K0( ) ;
         GridwizardstepsRow = GXWebRow.GetNew(context,GridwizardstepsContainer);
         if ( subGridwizardsteps_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridwizardsteps_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridwizardsteps_Class, "") != 0 )
            {
               subGridwizardsteps_Linesclass = subGridwizardsteps_Class+"Odd";
            }
         }
         else if ( subGridwizardsteps_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridwizardsteps_Backstyle = 0;
            subGridwizardsteps_Backcolor = subGridwizardsteps_Allbackcolor;
            if ( StringUtil.StrCmp(subGridwizardsteps_Class, "") != 0 )
            {
               subGridwizardsteps_Linesclass = subGridwizardsteps_Class+"Uniform";
            }
         }
         else if ( subGridwizardsteps_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridwizardsteps_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridwizardsteps_Class, "") != 0 )
            {
               subGridwizardsteps_Linesclass = subGridwizardsteps_Class+"Odd";
            }
            subGridwizardsteps_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridwizardsteps_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridwizardsteps_Backstyle = 1;
            subGridwizardsteps_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subGridwizardsteps_Class, "") != 0 )
            {
               subGridwizardsteps_Linesclass = subGridwizardsteps_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         GridwizardstepsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)subGridwizardsteps_Linesclass,(string)""});
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Table start */
         GridwizardstepsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTblcontainerstep_Internalname+"_"+sGXsfl_5_idx,(short)1,(string)tblTblcontainerstep_Class,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(short)0,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridwizardstepsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Static images/pictures */
         ClassString = imgStepimg_Class;
         StyleString = "";
         sImgUrl = imgStepimg_Bitmap;
         GridwizardstepsRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgStepimg_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)imgStepimg_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         if ( GridwizardstepsContainer.GetWrapped() == 1 )
         {
            GridwizardstepsContainer.CloseTag("cell");
         }
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"TableStepNumberCell"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayout_tblstep_Internalname+"_"+sGXsfl_5_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section",(string)"left",(string)"top",(string)" "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTblstep_Internalname+"_"+sGXsfl_5_idx,(int)divTblstep_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)divTblstep_Class,(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 StepNumberCell",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         GridwizardstepsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblStepnumber_Internalname,(string)lblStepnumber_Caption,(string)"",(string)"",(string)lblStepnumber_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)lblStepnumber_Class,(short)0,(string)"",(int)lblStepnumber_Visible,(short)1,(short)0,(short)0});
         GridwizardstepsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridwizardstepsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridwizardstepsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridwizardstepsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridwizardstepsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( GridwizardstepsContainer.GetWrapped() == 1 )
         {
            GridwizardstepsContainer.CloseTag("cell");
         }
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"AttributeStepCell"});
         /* Single line edit */
         ROClassString = edtavWizardstepsaux__title_Class;
         GridwizardstepsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizardstepsaux__title_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV19WizardStepsAux.Item(AV24GXV1)).gxTpr_Title,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizardstepsaux__title_Jsonclick,(short)0,(string)edtavWizardstepsaux__title_Class,(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWizardstepsaux__title_Visible,(int)edtavWizardstepsaux__title_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)5,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         if ( GridwizardstepsContainer.GetWrapped() == 1 )
         {
            GridwizardstepsContainer.CloseTag("cell");
         }
         if ( GridwizardstepsContainer.GetWrapped() == 1 )
         {
            GridwizardstepsContainer.CloseTag("row");
         }
         if ( GridwizardstepsContainer.GetWrapped() == 1 )
         {
            GridwizardstepsContainer.CloseTag("table");
         }
         /* End of table */
         if ( GridwizardstepsContainer.GetWrapped() == 1 )
         {
            GridwizardstepsContainer.CloseTag("cell");
         }
         if ( GridwizardstepsContainer.GetWrapped() == 1 )
         {
            GridwizardstepsContainer.CloseTag("row");
         }
         send_integrity_lvl_hashes0K2( ) ;
         /* End of Columns property logic. */
         GridwizardstepsContainer.AddRow(GridwizardstepsRow);
         nGXsfl_5_idx = ((subGridwizardsteps_Islastpage==1)&&(nGXsfl_5_idx+1>subGridwizardsteps_fnc_Recordsperpage( )) ? 1 : nGXsfl_5_idx+1);
         sGXsfl_5_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_idx), 4, 0), 4, "0");
         SubsflControlProps_52( ) ;
         /* End function sendrow_52 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgStepimg_Internalname = sPrefix+"STEPIMG";
         lblStepnumber_Internalname = sPrefix+"STEPNUMBER";
         divTblstep_Internalname = sPrefix+"TBLSTEP";
         divLayout_tblstep_Internalname = sPrefix+"LAYOUT_TBLSTEP";
         edtavWizardstepsaux__title_Internalname = sPrefix+"WIZARDSTEPSAUX__TITLE";
         tblTblcontainerstep_Internalname = sPrefix+"TBLCONTAINERSTEP";
         tblTablemain_Internalname = sPrefix+"TABLEMAIN";
         Form.Internalname = sPrefix+"FORM";
         subGridwizardsteps_Internalname = sPrefix+"GRIDWIZARDSTEPS";
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
         edtavWizardstepsaux__title_Jsonclick = "";
         lblStepnumber_Class = "StepNumber";
         lblStepnumber_Caption = "1";
         lblStepnumber_Visible = 1;
         divTblstep_Visible = 1;
         imgStepimg_Class = "StepImageUnSelected";
         imgStepimg_Visible = 1;
         imgStepimg_Bitmap = (string)(context.GetImagePath( "2fe377a7-df7d-42aa-84d4-4f1b853d50aa", "", context.GetTheme( )));
         subGridwizardsteps_Class = "FreeStyleSteps";
         subGridwizardsteps_Allowcollapsing = 0;
         edtavWizardstepsaux__title_Visible = 1;
         edtavWizardstepsaux__title_Enabled = 0;
         edtavWizardstepsaux__title_Class = "AttributeStep";
         lblStepnumber_Caption = "1";
         tblTblcontainerstep_Class = "TableContainerStep";
         divTblstep_Class = "TableStep";
         subGridwizardsteps_Backcolorstyle = 0;
         edtavWizardstepsaux__title_Enabled = -1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDWIZARDSTEPS_nFirstRecordOnPage'},{av:'GRIDWIZARDSTEPS_nEOF'},{av:'AV11SelectedStep',fld:'vSELECTEDSTEP',pic:''},{av:'AV18WizardSteps',fld:'vWIZARDSTEPS',pic:''},{av:'sPrefix'},{av:'AV19WizardStepsAux',fld:'vWIZARDSTEPSAUX',grid:5,pic:'',hsh:true},{av:'nRC_GXsfl_5',ctrl:'GRIDWIZARDSTEPS',prop:'GridRC'},{av:'AV15StepRealNumber',fld:'vSTEPREALNUMBER',pic:'ZZZ9',hsh:true},{av:'AV9PreviousSelected',fld:'vPREVIOUSSELECTED',pic:'',hsh:true},{av:'AV14StepNumber',fld:'vSTEPNUMBER',pic:'ZZZ9',hsh:true},{av:'AV5FirstIsDummy',fld:'vFIRSTISDUMMY',pic:'',hsh:true},{av:'AV6LastIsDummy',fld:'vLASTISDUMMY',pic:'',hsh:true},{av:'AV10SecondIsDummy',fld:'vSECONDISDUMMY',pic:'',hsh:true},{av:'AV8PenultimateIsDummy',fld:'vPENULTIMATEISDUMMY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDWIZARDSTEPS.LOAD","{handler:'E120K2',iparms:[{av:'AV15StepRealNumber',fld:'vSTEPREALNUMBER',pic:'ZZZ9',hsh:true},{av:'AV19WizardStepsAux',fld:'vWIZARDSTEPSAUX',grid:5,pic:'',hsh:true},{av:'GRIDWIZARDSTEPS_nFirstRecordOnPage'},{av:'nRC_GXsfl_5',ctrl:'GRIDWIZARDSTEPS',prop:'GridRC'},{av:'AV11SelectedStep',fld:'vSELECTEDSTEP',pic:''},{av:'AV9PreviousSelected',fld:'vPREVIOUSSELECTED',pic:'',hsh:true},{av:'AV14StepNumber',fld:'vSTEPNUMBER',pic:'ZZZ9',hsh:true},{av:'AV5FirstIsDummy',fld:'vFIRSTISDUMMY',pic:'',hsh:true},{av:'AV6LastIsDummy',fld:'vLASTISDUMMY',pic:'',hsh:true},{av:'AV18WizardSteps',fld:'vWIZARDSTEPS',pic:''},{av:'AV10SecondIsDummy',fld:'vSECONDISDUMMY',pic:'',hsh:true},{av:'AV8PenultimateIsDummy',fld:'vPENULTIMATEISDUMMY',pic:'',hsh:true}]");
         setEventMetadata("GRIDWIZARDSTEPS.LOAD",",oparms:[{av:'lblStepnumber_Caption',ctrl:'STEPNUMBER',prop:'Caption'},{ctrl:'WIZARDSTEPSAUX__TITLE',prop:'Class'},{av:'imgStepimg_Class',ctrl:'STEPIMG',prop:'Class'},{av:'lblStepnumber_Class',ctrl:'STEPNUMBER',prop:'Class'},{av:'divTblstep_Class',ctrl:'TBLSTEP',prop:'Class'},{av:'AV9PreviousSelected',fld:'vPREVIOUSSELECTED',pic:'',hsh:true},{av:'imgStepimg_Visible',ctrl:'STEPIMG',prop:'Visible'},{av:'tblTblcontainerstep_Class',ctrl:'TBLCONTAINERSTEP',prop:'Class'},{av:'divTblstep_Visible',ctrl:'TBLSTEP',prop:'Visible'},{av:'lblStepnumber_Visible',ctrl:'STEPNUMBER',prop:'Visible'},{ctrl:'WIZARDSTEPSAUX__TITLE',prop:'Visible'},{av:'AV15StepRealNumber',fld:'vSTEPREALNUMBER',pic:'ZZZ9',hsh:true},{av:'AV14StepNumber',fld:'vSTEPNUMBER',pic:'ZZZ9',hsh:true}]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv2',iparms:[]");
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
         AV18WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "RastreamentoTCC");
         wcpOAV11SelectedStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV19WizardStepsAux = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "RastreamentoTCC");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         GridwizardstepsContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV16TableContainerStepClass = "";
         GridwizardstepsRow = new GXWebRow();
         subGridwizardsteps_Header = "";
         GridwizardstepsColumn = new GXWebColumn();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV18WizardSteps = "";
         sCtrlAV11SelectedStep = "";
         subGridwizardsteps_Linesclass = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblStepnumber_Jsonclick = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavWizardstepsaux__title_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV15StepRealNumber ;
      private short AV14StepNumber ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridwizardsteps_Backcolorstyle ;
      private short AV7MaxStepsToShow ;
      private short AV12SelectedStepIndex ;
      private short AV13StartIndex ;
      private short subGridwizardsteps_Allowselection ;
      private short subGridwizardsteps_Allowhovering ;
      private short subGridwizardsteps_Allowcollapsing ;
      private short subGridwizardsteps_Collapsed ;
      private short subGridwizardsteps_Backstyle ;
      private short GRIDWIZARDSTEPS_nEOF ;
      private int nRC_GXsfl_5 ;
      private int nGXsfl_5_idx=1 ;
      private int edtavWizardstepsaux__title_Enabled ;
      private int AV24GXV1 ;
      private int subGridwizardsteps_Islastpage ;
      private int nGXsfl_5_fel_idx=1 ;
      private int AV26GXV3 ;
      private int imgStepimg_Visible ;
      private int divTblstep_Visible ;
      private int lblStepnumber_Visible ;
      private int edtavWizardstepsaux__title_Visible ;
      private int subGridwizardsteps_Selectedindex ;
      private int subGridwizardsteps_Selectioncolor ;
      private int subGridwizardsteps_Hoveringcolor ;
      private int idxLst ;
      private int subGridwizardsteps_Backcolor ;
      private int subGridwizardsteps_Allbackcolor ;
      private long GRIDWIZARDSTEPS_nCurrentRecord ;
      private long GRIDWIZARDSTEPS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_5_idx="0001" ;
      private string edtavWizardstepsaux__title_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sStyleString ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_5_fel_idx="0001" ;
      private string lblStepnumber_Caption ;
      private string edtavWizardstepsaux__title_Class ;
      private string imgStepimg_Class ;
      private string lblStepnumber_Class ;
      private string divTblstep_Class ;
      private string divTblstep_Internalname ;
      private string tblTblcontainerstep_Class ;
      private string tblTblcontainerstep_Internalname ;
      private string tblTablemain_Internalname ;
      private string subGridwizardsteps_Internalname ;
      private string subGridwizardsteps_Header ;
      private string sCtrlAV18WizardSteps ;
      private string sCtrlAV11SelectedStep ;
      private string imgStepimg_Internalname ;
      private string lblStepnumber_Internalname ;
      private string subGridwizardsteps_Class ;
      private string subGridwizardsteps_Linesclass ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string divLayout_tblstep_Internalname ;
      private string lblStepnumber_Jsonclick ;
      private string ROClassString ;
      private string edtavWizardstepsaux__title_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9PreviousSelected ;
      private bool AV5FirstIsDummy ;
      private bool AV6LastIsDummy ;
      private bool AV10SecondIsDummy ;
      private bool AV8PenultimateIsDummy ;
      private bool bGXsfl_5_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV5 ;
      private string AV11SelectedStep ;
      private string wcpOAV11SelectedStep ;
      private string AV16TableContainerStepClass ;
      private string imgStepimg_Bitmap ;
      private GXWebGrid GridwizardstepsContainer ;
      private GXWebRow GridwizardstepsRow ;
      private GXWebColumn GridwizardstepsColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV18WizardSteps ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV19WizardStepsAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem AV17WizardStep ;
   }

}
