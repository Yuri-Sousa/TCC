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
   public class wizardstepsbulletwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public wizardstepsbulletwc( )
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

      public wizardstepsbulletwc( IGxContext context )
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
                           string aP1_CurrentStep )
      {
         this.AV15WizardSteps = aP0_WizardSteps;
         this.AV6CurrentStep = aP1_CurrentStep;
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
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV15WizardSteps);
                  AV6CurrentStep = GetPar( "CurrentStep");
                  AssignAttri(sPrefix, false, "AV6CurrentStep", AV6CurrentStep);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)AV15WizardSteps,(string)AV6CurrentStep});
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
                  AV13StepRealNumber = (short)(NumberUtil.Val( GetPar( "StepRealNumber"), "."));
                  AV12StepNumber = (short)(NumberUtil.Val( GetPar( "StepNumber"), "."));
                  AV10SelectedStepNumber = (short)(NumberUtil.Val( GetPar( "SelectedStepNumber"), "."));
                  AV17FirstIsDummy = StringUtil.StrToBool( GetPar( "FirstIsDummy"));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV16WizardStepsAux);
                  AV18LastIsDummy = StringUtil.StrToBool( GetPar( "LastIsDummy"));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV15WizardSteps);
                  AV19PenultimateIsDummy = StringUtil.StrToBool( GetPar( "PenultimateIsDummy"));
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGridwizardsteps_refresh( AV13StepRealNumber, AV12StepNumber, AV10SelectedStepNumber, AV17FirstIsDummy, AV16WizardStepsAux, AV18LastIsDummy, AV15WizardSteps, AV19PenultimateIsDummy, sPrefix) ;
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
            PA0L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               edtavWizardstepsaux__title_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizardstepsaux__title_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizardstepsaux__title_Enabled), 5, 0), !bGXsfl_5_Refreshing);
               WS0L2( ) ;
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
            context.SendWebValue( "Wizard Steps Bullet WC.") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20214281546910", false, true);
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("wwpbaseobjects.wizardstepsbulletwc.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV6CurrentStep))}, new string[] {"WizardSteps","CurrentStep"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13StepRealNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV12StepNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10SelectedStepNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV17FirstIsDummy, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPSAUX", GetSecureSignedToken( sPrefix, AV16WizardStepsAux, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV18LastIsDummy, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV19PenultimateIsDummy, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wizardstepsaux", AV16WizardStepsAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wizardstepsaux", AV16WizardStepsAux);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Wizardstepsaux", GetSecureSignedToken( sPrefix, AV16WizardStepsAux, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_5", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_5), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6CurrentStep", wcpOAV6CurrentStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPREALNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13StepRealNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13StepRealNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12StepNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV12StepNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDSTEPNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10SelectedStepNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10SelectedStepNumber), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFIRSTISDUMMY", AV17FirstIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV17FirstIsDummy, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPSAUX", AV16WizardStepsAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPSAUX", AV16WizardStepsAux);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPSAUX", GetSecureSignedToken( sPrefix, AV16WizardStepsAux, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vLASTISDUMMY", AV18LastIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV18LastIsDummy, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPS", AV15WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPS", AV15WizardSteps);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPENULTIMATEISDUMMY", AV19PenultimateIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV19PenultimateIsDummy, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTSTEP", AV6CurrentStep);
      }

      protected void RenderHtmlCloseForm0L2( )
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
         return "WWPBaseObjects.WizardStepsBulletWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wizard Steps Bullet WC." ;
      }

      protected void WB0L0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wizardstepsbulletwc.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            wb_table1_2_0L2( true) ;
         }
         else
         {
            wb_table1_2_0L2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0L2e( bool wbgen )
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
                  AV25GXV1 = nGXsfl_5_idx;
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

      protected void START0L2( )
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
               Form.Meta.addItem("description", "Wizard Steps Bullet WC.", 0) ;
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
               STRUP0L0( ) ;
            }
         }
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
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
                                 STRUP0L0( ) ;
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
                                 STRUP0L0( ) ;
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
                                 STRUP0L0( ) ;
                              }
                              nGXsfl_5_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_5_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_idx), 4, 0), 4, "0");
                              SubsflControlProps_52( ) ;
                              AV25GXV1 = nGXsfl_5_idx;
                              if ( ( AV16WizardStepsAux.Count >= AV25GXV1 ) && ( AV25GXV1 > 0 ) )
                              {
                                 AV16WizardStepsAux.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV16WizardStepsAux.Item(AV25GXV1));
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
                                          E110L2 ();
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
                                          E120L2 ();
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
                                       STRUP0L0( ) ;
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

      protected void WE0L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0L2( ) ;
            }
         }
      }

      protected void PA0L2( )
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

      protected void gxgrGridwizardsteps_refresh( short AV13StepRealNumber ,
                                                  short AV12StepNumber ,
                                                  short AV10SelectedStepNumber ,
                                                  bool AV17FirstIsDummy ,
                                                  GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV16WizardStepsAux ,
                                                  bool AV18LastIsDummy ,
                                                  GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV15WizardSteps ,
                                                  bool AV19PenultimateIsDummy ,
                                                  string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDWIZARDSTEPS_nCurrentRecord = 0;
         RF0L2( ) ;
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
         RF0L2( ) ;
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

      protected void RF0L2( )
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
            E120L2 ();
            wbEnd = 5;
            WB0L0( ) ;
         }
         bGXsfl_5_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPREALNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13StepRealNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13StepRealNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTEPNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12StepNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV12StepNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDSTEPNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10SelectedStepNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10SelectedStepNumber), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFIRSTISDUMMY", AV17FirstIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV17FirstIsDummy, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDSTEPSAUX", AV16WizardStepsAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDSTEPSAUX", AV16WizardStepsAux);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWIZARDSTEPSAUX", GetSecureSignedToken( sPrefix, AV16WizardStepsAux, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vLASTISDUMMY", AV18LastIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV18LastIsDummy, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPENULTIMATEISDUMMY", AV19PenultimateIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV19PenultimateIsDummy, context));
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

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wizardstepsaux"), AV16WizardStepsAux);
            /* Read saved values. */
            nRC_GXsfl_5 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_5"), ",", "."));
            wcpOAV6CurrentStep = cgiGet( sPrefix+"wcpOAV6CurrentStep");
            nRC_GXsfl_5 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_5"), ",", "."));
            nGXsfl_5_fel_idx = 0;
            while ( nGXsfl_5_fel_idx < nRC_GXsfl_5 )
            {
               nGXsfl_5_fel_idx = ((subGridwizardsteps_Islastpage==1)&&(nGXsfl_5_fel_idx+1>subGridwizardsteps_fnc_Recordsperpage( )) ? 1 : nGXsfl_5_fel_idx+1);
               sGXsfl_5_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_5_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_52( ) ;
               AV25GXV1 = nGXsfl_5_fel_idx;
               if ( ( AV16WizardStepsAux.Count >= AV25GXV1 ) && ( AV25GXV1 > 0 ) )
               {
                  AV16WizardStepsAux.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV16WizardStepsAux.Item(AV25GXV1));
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
         E110L2 ();
         if (returnInSub) return;
      }

      protected void E110L2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV7MaxStepsToShow = 11;
         AV10SelectedStepNumber = 1;
         AssignAttri(sPrefix, false, "AV10SelectedStepNumber", StringUtil.LTrimStr( (decimal)(AV10SelectedStepNumber), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10SelectedStepNumber), "ZZZ9"), context));
         AV27GXV3 = 1;
         while ( AV27GXV3 <= AV15WizardSteps.Count )
         {
            AV5WizardStep = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV15WizardSteps.Item(AV27GXV3));
            if ( StringUtil.StrCmp(AV5WizardStep.gxTpr_Code, AV6CurrentStep) == 0 )
            {
               if (true) break;
            }
            else
            {
               AV10SelectedStepNumber = (short)(AV10SelectedStepNumber+1);
               AssignAttri(sPrefix, false, "AV10SelectedStepNumber", StringUtil.LTrimStr( (decimal)(AV10SelectedStepNumber), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10SelectedStepNumber), "ZZZ9"), context));
            }
            AV27GXV3 = (int)(AV27GXV3+1);
         }
         AV13StepRealNumber = 1;
         AssignAttri(sPrefix, false, "AV13StepRealNumber", StringUtil.LTrimStr( (decimal)(AV13StepRealNumber), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13StepRealNumber), "ZZZ9"), context));
         AV16WizardStepsAux = (GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)(AV15WizardSteps.Clone());
         gx_BV5 = true;
         AV17FirstIsDummy = false;
         AssignAttri(sPrefix, false, "AV17FirstIsDummy", AV17FirstIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV17FirstIsDummy, context));
         AV20SecondIsDummy = false;
         AV19PenultimateIsDummy = false;
         AssignAttri(sPrefix, false, "AV19PenultimateIsDummy", AV19PenultimateIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV19PenultimateIsDummy, context));
         AV18LastIsDummy = false;
         AssignAttri(sPrefix, false, "AV18LastIsDummy", AV18LastIsDummy);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV18LastIsDummy, context));
         if ( AV16WizardStepsAux.Count > AV7MaxStepsToShow )
         {
            if ( AV10SelectedStepNumber > AV16WizardStepsAux.Count )
            {
               AV10SelectedStepNumber = 1;
               AssignAttri(sPrefix, false, "AV10SelectedStepNumber", StringUtil.LTrimStr( (decimal)(AV10SelectedStepNumber), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10SelectedStepNumber), "ZZZ9"), context));
            }
            AV11StartIndex = 1;
            if ( ( AV10SelectedStepNumber + 3 - AV7MaxStepsToShow /  ( decimal )( 2 ) > Convert.ToDecimal( 0 )) )
            {
               AV11StartIndex = (short)(AV10SelectedStepNumber+3-AV7MaxStepsToShow/ (decimal)(2));
               if ( AV11StartIndex + ( AV7MaxStepsToShow - 2 ) > AV16WizardStepsAux.Count + 1 )
               {
                  AV11StartIndex = (short)(AV16WizardStepsAux.Count-(AV7MaxStepsToShow-2)+1);
               }
            }
            if ( AV11StartIndex > 3 )
            {
               AV13StepRealNumber = AV11StartIndex;
               AssignAttri(sPrefix, false, "AV13StepRealNumber", StringUtil.LTrimStr( (decimal)(AV13StepRealNumber), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13StepRealNumber), "ZZZ9"), context));
               AV17FirstIsDummy = true;
               AssignAttri(sPrefix, false, "AV17FirstIsDummy", AV17FirstIsDummy);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vFIRSTISDUMMY", GetSecureSignedToken( sPrefix, AV17FirstIsDummy, context));
               AV20SecondIsDummy = true;
               ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV16WizardStepsAux.Item(2)).gxTpr_Title = "...";
               while ( AV11StartIndex > 3 )
               {
                  AV16WizardStepsAux.RemoveItem(3);
                  gx_BV5 = true;
                  AV11StartIndex = (short)(AV11StartIndex-1);
                  AV10SelectedStepNumber = (short)(AV10SelectedStepNumber-1);
                  AssignAttri(sPrefix, false, "AV10SelectedStepNumber", StringUtil.LTrimStr( (decimal)(AV10SelectedStepNumber), 4, 0));
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSELECTEDSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV10SelectedStepNumber), "ZZZ9"), context));
               }
            }
            if ( AV16WizardStepsAux.Count > AV7MaxStepsToShow )
            {
               AV18LastIsDummy = true;
               AssignAttri(sPrefix, false, "AV18LastIsDummy", AV18LastIsDummy);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vLASTISDUMMY", GetSecureSignedToken( sPrefix, AV18LastIsDummy, context));
               AV19PenultimateIsDummy = true;
               AssignAttri(sPrefix, false, "AV19PenultimateIsDummy", AV19PenultimateIsDummy);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPENULTIMATEISDUMMY", GetSecureSignedToken( sPrefix, AV19PenultimateIsDummy, context));
               ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV16WizardStepsAux.Item(AV16WizardStepsAux.Count-1)).gxTpr_Title = "";
               while ( AV16WizardStepsAux.Count > AV7MaxStepsToShow )
               {
                  AV16WizardStepsAux.RemoveItem(AV16WizardStepsAux.Count-2);
                  gx_BV5 = true;
               }
            }
         }
         AV12StepNumber = 1;
         AssignAttri(sPrefix, false, "AV12StepNumber", StringUtil.LTrimStr( (decimal)(AV12StepNumber), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV12StepNumber), "ZZZ9"), context));
      }

      private void E120L2( )
      {
         /* Gridwizardsteps_Load Routine */
         returnInSub = false;
         AV25GXV1 = 1;
         while ( AV25GXV1 <= AV16WizardStepsAux.Count )
         {
            AV16WizardStepsAux.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV16WizardStepsAux.Item(AV25GXV1));
            AV14TableContainerStepClass = "TableContainerStep";
            lblStepnumber_Visible = 0;
            lblStepnumber_Caption = context.localUtil.Format( (decimal)(AV13StepRealNumber), "ZZZ9");
            tblTablestepbulletlineleft_Class = "TableStepBulletLine";
            AssignProp(sPrefix, false, tblTablestepbulletlineleft_Internalname, "Class", tblTablestepbulletlineleft_Class, !bGXsfl_5_Refreshing);
            tblTablestepbulletlineright_Class = "TableStepBulletLine";
            AssignProp(sPrefix, false, tblTablestepbulletlineright_Internalname, "Class", tblTablestepbulletlineright_Class, !bGXsfl_5_Refreshing);
            if ( AV12StepNumber < AV10SelectedStepNumber )
            {
               divTablestepitem_Class = "TableStepBulletChecked";
               AssignProp(sPrefix, false, divTablestepitem_Internalname, "Class", divTablestepitem_Class, !bGXsfl_5_Refreshing);
               tblTablestepbulletlineleft_Class = "TableStepBulletLineChecked";
               AssignProp(sPrefix, false, tblTablestepbulletlineleft_Internalname, "Class", tblTablestepbulletlineleft_Class, !bGXsfl_5_Refreshing);
               tblTablestepbulletlineright_Class = "TableStepBulletLineChecked";
               AssignProp(sPrefix, false, tblTablestepbulletlineright_Internalname, "Class", tblTablestepbulletlineright_Class, !bGXsfl_5_Refreshing);
               edtavWizardstepsaux__title_Class = "AttributeStepBullet";
            }
            else if ( AV12StepNumber == AV10SelectedStepNumber )
            {
               lblStepnumber_Visible = 1;
               lblStepnumber_Class = "StepNumberBulletSelected";
               divTablestepitem_Class = "TableStepBulletSelected";
               AssignProp(sPrefix, false, divTablestepitem_Internalname, "Class", divTablestepitem_Class, !bGXsfl_5_Refreshing);
               tblTablestepbulletlineleft_Class = "TableStepBulletLineChecked";
               AssignProp(sPrefix, false, tblTablestepbulletlineleft_Internalname, "Class", tblTablestepbulletlineleft_Class, !bGXsfl_5_Refreshing);
               edtavWizardstepsaux__title_Class = "AttributeStepBulletSelected";
            }
            else if ( AV12StepNumber > AV10SelectedStepNumber )
            {
               lblStepnumber_Class = "StepNumberBullet";
               lblStepnumber_Visible = 1;
               divTablestepitem_Class = "TableStepBullet";
               AssignProp(sPrefix, false, divTablestepitem_Internalname, "Class", divTablestepitem_Class, !bGXsfl_5_Refreshing);
               edtavWizardstepsaux__title_Class = "AttributeStepBulletUnSelected";
            }
            if ( ( AV12StepNumber == 1 ) && AV17FirstIsDummy )
            {
               lblStepnumber_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(AV12StepNumber), 4, 0));
            }
            else if ( ( AV12StepNumber == AV16WizardStepsAux.Count ) && AV18LastIsDummy )
            {
               lblStepnumber_Caption = StringUtil.Trim( StringUtil.Str( (decimal)(AV15WizardSteps.Count), 9, 0));
            }
            else if ( ( AV12StepNumber == AV16WizardStepsAux.Count - 1 ) && AV19PenultimateIsDummy )
            {
               lblStepnumber_Caption = "...";
            }
            else if ( ( AV12StepNumber == 2 ) && AV17FirstIsDummy )
            {
            }
            else
            {
               AV13StepRealNumber = (short)(AV13StepRealNumber+1);
               AssignAttri(sPrefix, false, "AV13StepRealNumber", StringUtil.LTrimStr( (decimal)(AV13StepRealNumber), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPREALNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV13StepRealNumber), "ZZZ9"), context));
            }
            AV12StepNumber = (short)(AV12StepNumber+1);
            AssignAttri(sPrefix, false, "AV12StepNumber", StringUtil.LTrimStr( (decimal)(AV12StepNumber), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTEPNUMBER", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV12StepNumber), "ZZZ9"), context));
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
            AV25GXV1 = (int)(AV25GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table1_2_0L2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableWizardSteps TableAlignedCentered", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               GridwizardstepsColumn.AddObjectProperty("Value", lblDummybulletlineleft_Caption);
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
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsColumn.AddObjectProperty("Value", lblDummybulletlineleft_Caption);
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsContainer.AddColumnProperties(GridwizardstepsColumn);
               GridwizardstepsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridwizardstepsColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavWizardstepsaux__title_Class));
               GridwizardstepsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizardstepsaux__title_Enabled), 5, 0, ".", "")));
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
               AV25GXV1 = nGXsfl_5_idx;
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
            wb_table1_2_0L2e( true) ;
         }
         else
         {
            wb_table1_2_0L2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15WizardSteps = (GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)getParm(obj,0);
         AV6CurrentStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV6CurrentStep", AV6CurrentStep);
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
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
         sCtrlAV15WizardSteps = (string)((string)getParm(obj,0));
         sCtrlAV6CurrentStep = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wizardstepsbulletwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV15WizardSteps = (GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)getParm(obj,2);
            AV6CurrentStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV6CurrentStep", AV6CurrentStep);
         }
         wcpOAV6CurrentStep = cgiGet( sPrefix+"wcpOAV6CurrentStep");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6CurrentStep, wcpOAV6CurrentStep) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV6CurrentStep = AV6CurrentStep;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV15WizardSteps = cgiGet( sPrefix+"AV15WizardSteps_CTRL");
         if ( StringUtil.Len( sCtrlAV15WizardSteps) > 0 )
         {
            AV15WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>();
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV15WizardSteps_PARM"), AV15WizardSteps);
         }
         sCtrlAV6CurrentStep = cgiGet( sPrefix+"AV6CurrentStep_CTRL");
         if ( StringUtil.Len( sCtrlAV6CurrentStep) > 0 )
         {
            AV6CurrentStep = cgiGet( sCtrlAV6CurrentStep);
            AssignAttri(sPrefix, false, "AV6CurrentStep", AV6CurrentStep);
         }
         else
         {
            AV6CurrentStep = cgiGet( sPrefix+"AV6CurrentStep_PARM");
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
         PA0L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0L2( ) ;
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
         WS0L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV15WizardSteps_PARM", AV15WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV15WizardSteps_PARM", AV15WizardSteps);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15WizardSteps)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15WizardSteps_CTRL", StringUtil.RTrim( sCtrlAV15WizardSteps));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6CurrentStep_PARM", AV6CurrentStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6CurrentStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6CurrentStep_CTRL", StringUtil.RTrim( sCtrlAV6CurrentStep));
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
         WE0L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20214281546990", true, true);
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
            context.AddJavascriptSource("wwpbaseobjects/wizardstepsbulletwc.js", "?20214281546991", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_52( )
      {
         lblDummybulletlineleft_Internalname = sPrefix+"DUMMYBULLETLINELEFT_"+sGXsfl_5_idx;
         lblStepnumber_Internalname = sPrefix+"STEPNUMBER_"+sGXsfl_5_idx;
         lblDummybulletlineright_Internalname = sPrefix+"DUMMYBULLETLINERIGHT_"+sGXsfl_5_idx;
         edtavWizardstepsaux__title_Internalname = sPrefix+"WIZARDSTEPSAUX__TITLE_"+sGXsfl_5_idx;
      }

      protected void SubsflControlProps_fel_52( )
      {
         lblDummybulletlineleft_Internalname = sPrefix+"DUMMYBULLETLINELEFT_"+sGXsfl_5_fel_idx;
         lblStepnumber_Internalname = sPrefix+"STEPNUMBER_"+sGXsfl_5_fel_idx;
         lblDummybulletlineright_Internalname = sPrefix+"DUMMYBULLETLINERIGHT_"+sGXsfl_5_fel_idx;
         edtavWizardstepsaux__title_Internalname = sPrefix+"WIZARDSTEPSAUX__TITLE_"+sGXsfl_5_fel_idx;
      }

      protected void sendrow_52( )
      {
         SubsflControlProps_52( ) ;
         WB0L0( ) ;
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
         GridwizardstepsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTblcontainerstep_Internalname+"_"+sGXsfl_5_idx,(short)1,(string)"TableContainerStepBullet",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(short)0,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridwizardstepsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Table start */
         GridwizardstepsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablestepbulletline_Internalname+"_"+sGXsfl_5_idx,(short)1,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridwizardstepsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"TableStepBulletLineCell"});
         /* Table start */
         GridwizardstepsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablestepbulletlineleft_Internalname+"_"+sGXsfl_5_idx,(short)1,(string)tblTablestepbulletlineleft_Class,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(short)0,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridwizardstepsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         GridwizardstepsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblDummybulletlineleft_Internalname,(string)" ",(string)"",(string)"",(string)lblDummybulletlineleft_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
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
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayout_tablestepitem_Internalname+"_"+sGXsfl_5_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Section",(string)"left",(string)"top",(string)" "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablestepitem_Internalname+"_"+sGXsfl_5_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divTablestepitem_Class,(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridwizardstepsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 StepNumberBulletCell",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
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
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"TableStepBulletLineCell"});
         /* Table start */
         GridwizardstepsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablestepbulletlineright_Internalname+"_"+sGXsfl_5_idx,(short)1,(string)tblTablestepbulletlineright_Class,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(short)0,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridwizardstepsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         GridwizardstepsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblDummybulletlineright_Internalname,(string)" ",(string)"",(string)"",(string)lblDummybulletlineright_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
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
         sendrow_5230( ) ;
      }

      protected void sendrow_5230( )
      {
         GridwizardstepsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridwizardstepsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"AttributeStepBulletCell"});
         /* Single line edit */
         ROClassString = edtavWizardstepsaux__title_Class;
         GridwizardstepsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizardstepsaux__title_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV16WizardStepsAux.Item(AV25GXV1)).gxTpr_Title,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizardstepsaux__title_Jsonclick,(short)0,(string)edtavWizardstepsaux__title_Class,(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavWizardstepsaux__title_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)5,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
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
         send_integrity_lvl_hashes0L2( ) ;
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
         lblDummybulletlineleft_Internalname = sPrefix+"DUMMYBULLETLINELEFT";
         tblTablestepbulletlineleft_Internalname = sPrefix+"TABLESTEPBULLETLINELEFT";
         lblStepnumber_Internalname = sPrefix+"STEPNUMBER";
         divTablestepitem_Internalname = sPrefix+"TABLESTEPITEM";
         divLayout_tablestepitem_Internalname = sPrefix+"LAYOUT_TABLESTEPITEM";
         lblDummybulletlineright_Internalname = sPrefix+"DUMMYBULLETLINERIGHT";
         tblTablestepbulletlineright_Internalname = sPrefix+"TABLESTEPBULLETLINERIGHT";
         tblTablestepbulletline_Internalname = sPrefix+"TABLESTEPBULLETLINE";
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
         lblStepnumber_Class = "StepNumberBullet";
         lblStepnumber_Caption = "1";
         lblStepnumber_Visible = 1;
         subGridwizardsteps_Class = "FreeStyleSteps";
         subGridwizardsteps_Allowcollapsing = 0;
         edtavWizardstepsaux__title_Enabled = 0;
         edtavWizardstepsaux__title_Class = "AttributeStepBulletUnSelected";
         lblStepnumber_Caption = "1";
         lblDummybulletlineleft_Caption = " ";
         divTablestepitem_Class = "TableStepBullet";
         tblTablestepbulletlineright_Class = "TableStepBulletLine";
         tblTablestepbulletlineleft_Class = "TableStepBulletLine";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDWIZARDSTEPS_nFirstRecordOnPage'},{av:'GRIDWIZARDSTEPS_nEOF'},{av:'AV15WizardSteps',fld:'vWIZARDSTEPS',pic:''},{av:'sPrefix'},{av:'AV16WizardStepsAux',fld:'vWIZARDSTEPSAUX',grid:5,pic:'',hsh:true},{av:'nRC_GXsfl_5',ctrl:'GRIDWIZARDSTEPS',prop:'GridRC'},{av:'AV13StepRealNumber',fld:'vSTEPREALNUMBER',pic:'ZZZ9',hsh:true},{av:'AV12StepNumber',fld:'vSTEPNUMBER',pic:'ZZZ9',hsh:true},{av:'AV10SelectedStepNumber',fld:'vSELECTEDSTEPNUMBER',pic:'ZZZ9',hsh:true},{av:'AV17FirstIsDummy',fld:'vFIRSTISDUMMY',pic:'',hsh:true},{av:'AV18LastIsDummy',fld:'vLASTISDUMMY',pic:'',hsh:true},{av:'AV19PenultimateIsDummy',fld:'vPENULTIMATEISDUMMY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDWIZARDSTEPS.LOAD","{handler:'E120L2',iparms:[{av:'AV13StepRealNumber',fld:'vSTEPREALNUMBER',pic:'ZZZ9',hsh:true},{av:'AV12StepNumber',fld:'vSTEPNUMBER',pic:'ZZZ9',hsh:true},{av:'AV10SelectedStepNumber',fld:'vSELECTEDSTEPNUMBER',pic:'ZZZ9',hsh:true},{av:'AV17FirstIsDummy',fld:'vFIRSTISDUMMY',pic:'',hsh:true},{av:'AV16WizardStepsAux',fld:'vWIZARDSTEPSAUX',grid:5,pic:'',hsh:true},{av:'GRIDWIZARDSTEPS_nFirstRecordOnPage'},{av:'nRC_GXsfl_5',ctrl:'GRIDWIZARDSTEPS',prop:'GridRC'},{av:'AV18LastIsDummy',fld:'vLASTISDUMMY',pic:'',hsh:true},{av:'AV15WizardSteps',fld:'vWIZARDSTEPS',pic:''},{av:'AV19PenultimateIsDummy',fld:'vPENULTIMATEISDUMMY',pic:'',hsh:true}]");
         setEventMetadata("GRIDWIZARDSTEPS.LOAD",",oparms:[{av:'lblStepnumber_Visible',ctrl:'STEPNUMBER',prop:'Visible'},{av:'lblStepnumber_Caption',ctrl:'STEPNUMBER',prop:'Caption'},{av:'tblTablestepbulletlineleft_Class',ctrl:'TABLESTEPBULLETLINELEFT',prop:'Class'},{av:'tblTablestepbulletlineright_Class',ctrl:'TABLESTEPBULLETLINERIGHT',prop:'Class'},{av:'divTablestepitem_Class',ctrl:'TABLESTEPITEM',prop:'Class'},{ctrl:'WIZARDSTEPSAUX__TITLE',prop:'Class'},{av:'lblStepnumber_Class',ctrl:'STEPNUMBER',prop:'Class'},{av:'AV13StepRealNumber',fld:'vSTEPREALNUMBER',pic:'ZZZ9',hsh:true},{av:'AV12StepNumber',fld:'vSTEPNUMBER',pic:'ZZZ9',hsh:true}]}");
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
         AV15WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "RastreamentoTCC");
         wcpOAV6CurrentStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16WizardStepsAux = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "RastreamentoTCC");
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
         AV5WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV14TableContainerStepClass = "";
         GridwizardstepsRow = new GXWebRow();
         subGridwizardsteps_Header = "";
         GridwizardstepsColumn = new GXWebColumn();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV15WizardSteps = "";
         sCtrlAV6CurrentStep = "";
         subGridwizardsteps_Linesclass = "";
         lblDummybulletlineleft_Jsonclick = "";
         lblStepnumber_Jsonclick = "";
         lblDummybulletlineright_Jsonclick = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavWizardstepsaux__title_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13StepRealNumber ;
      private short AV12StepNumber ;
      private short AV10SelectedStepNumber ;
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
      private short AV11StartIndex ;
      private short subGridwizardsteps_Allowselection ;
      private short subGridwizardsteps_Allowhovering ;
      private short subGridwizardsteps_Allowcollapsing ;
      private short subGridwizardsteps_Collapsed ;
      private short subGridwizardsteps_Backstyle ;
      private short GRIDWIZARDSTEPS_nEOF ;
      private int nRC_GXsfl_5 ;
      private int nGXsfl_5_idx=1 ;
      private int edtavWizardstepsaux__title_Enabled ;
      private int AV25GXV1 ;
      private int subGridwizardsteps_Islastpage ;
      private int nGXsfl_5_fel_idx=1 ;
      private int AV27GXV3 ;
      private int lblStepnumber_Visible ;
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
      private string tblTablestepbulletlineleft_Class ;
      private string tblTablestepbulletlineleft_Internalname ;
      private string tblTablestepbulletlineright_Class ;
      private string tblTablestepbulletlineright_Internalname ;
      private string divTablestepitem_Class ;
      private string divTablestepitem_Internalname ;
      private string edtavWizardstepsaux__title_Class ;
      private string lblStepnumber_Class ;
      private string tblTablemain_Internalname ;
      private string subGridwizardsteps_Internalname ;
      private string subGridwizardsteps_Header ;
      private string lblDummybulletlineleft_Caption ;
      private string sCtrlAV15WizardSteps ;
      private string sCtrlAV6CurrentStep ;
      private string lblDummybulletlineleft_Internalname ;
      private string lblStepnumber_Internalname ;
      private string lblDummybulletlineright_Internalname ;
      private string subGridwizardsteps_Class ;
      private string subGridwizardsteps_Linesclass ;
      private string tblTblcontainerstep_Internalname ;
      private string tblTablestepbulletline_Internalname ;
      private string lblDummybulletlineleft_Jsonclick ;
      private string divLayout_tablestepitem_Internalname ;
      private string lblStepnumber_Jsonclick ;
      private string lblDummybulletlineright_Jsonclick ;
      private string ROClassString ;
      private string edtavWizardstepsaux__title_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17FirstIsDummy ;
      private bool AV18LastIsDummy ;
      private bool AV19PenultimateIsDummy ;
      private bool bGXsfl_5_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV5 ;
      private bool AV20SecondIsDummy ;
      private string AV6CurrentStep ;
      private string wcpOAV6CurrentStep ;
      private string AV14TableContainerStepClass ;
      private GXWebGrid GridwizardstepsContainer ;
      private GXWebRow GridwizardstepsRow ;
      private GXWebColumn GridwizardstepsColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV15WizardSteps ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV16WizardStepsAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem AV5WizardStep ;
   }

}
