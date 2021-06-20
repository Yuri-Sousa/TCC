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
   public class associationveiculorastreador : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public associationveiculorastreador( )
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

      public associationveiculorastreador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_VeiculoId )
      {
         this.AV8VeiculoId = aP0_VeiculoId;
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
         lstavNotassociatedrecords = new GXListbox();
         lstavAssociatedrecords = new GXListbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "VeiculoId");
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
                  AV8VeiculoId = (int)(NumberUtil.Val( GetPar( "VeiculoId"), "."));
                  AssignAttri(sPrefix, false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV8VeiculoId});
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
                  gxfirstwebparm = GetFirstPar( "VeiculoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "VeiculoId");
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
            PA2P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS2P2( ) ;
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
            context.SendWebValue( "Association Veiculo Rastreador") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202142918365536", false, true);
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
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("associationveiculorastreador.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8VeiculoId,8,0))}, new string[] {"VeiculoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8VeiculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8VeiculoId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vADDEDKEYLIST", AV21AddedKeyList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vADDEDKEYLIST", AV21AddedKeyList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vADDEDDSCLIST", AV23AddedDscList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vADDEDDSCLIST", AV23AddedDscList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTADDEDKEYLIST", AV22NotAddedKeyList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTADDEDKEYLIST", AV22NotAddedKeyList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTADDEDDSCLIST", AV24NotAddedDscList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTADDEDDSCLIST", AV24NotAddedDscList);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vADDEDKEYLISTXML", AV17AddedKeyListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"vADDEDDSCLISTXML", AV19AddedDscListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTADDEDKEYLISTXML", AV18NotAddedKeyListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTADDEDDSCLISTXML", AV20NotAddedDscListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"VEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A98VeiculoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8VeiculoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"RASTREADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106RastreadorId), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVEICULORASTREADOR", AV12VeiculoRastreador);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVEICULORASTREADOR", AV12VeiculoRastreador);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vRASTREADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9RastreadorId), 8, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm2P2( )
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
         return "AssociationVeiculoRastreador" ;
      }

      public override string GetPgmdesc( )
      {
         return "Association Veiculo Rastreador" ;
      }

      protected void WB2P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "associationveiculorastreador.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefullcontent_Internalname, 1, 0, "px", 0, "px", "TableAssociation", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotassociated_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 AssociationTitleCell", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotassociatedrecordstitle_Internalname, "Registros Não Associados", "", "", lblNotassociatedrecordstitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "AssociationTitle", 0, "", 1, 1, 0, 0, "HLP_AssociationVeiculoRastreador.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, lstavNotassociatedrecords_Internalname, "Not Associated Records", "col-sm-3 AssociationListAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            /* ListBox */
            GxWebStd.gx_listbox_ctrl1( context, lstavNotassociatedrecords, lstavNotassociatedrecords_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0)), 2, lstavNotassociatedrecords_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, lstavNotassociatedrecords.Enabled, 0, 0, 8, "em", 0, "row", "", "AssociationListAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, "HLP_AssociationVeiculoRastreador.htm");
            lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
            AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", (string)(lstavNotassociatedrecords.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellTableAssociationButtons", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableassociationbuttons_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 hidden-sm hidden-md hidden-lg", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "6591e2a3-49b6-43b7-b8e3-a292564a32a4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageassociateall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImageassociateall_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ASSOCIATE ALL\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssociationVeiculoRastreador.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "56a5f17b-0bc3-48b5-b303-afa6e0585b6d", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageassociateselected_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImageassociateselected_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ASSOCIATE SELECTED\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssociationVeiculoRastreador.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "a3800d0c-bf04-4575-bc01-11fe5d7b3525", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImagedisassociateselected_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImagedisassociateselected_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DISASSOCIATE SELECTED\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssociationVeiculoRastreador.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c619e28f-4b32-4ff9-baaf-b3063fe4f782", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImagedisassociateall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImagedisassociateall_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DISASSOCIATE ALL\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssociationVeiculoRastreador.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableassociated_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 AssociationTitleCell", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAssociatedrecordstitle_Internalname, "Registros Associados", "", "", lblAssociatedrecordstitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "AssociationTitle", 0, "", 1, 1, 0, 0, "HLP_AssociationVeiculoRastreador.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, lstavAssociatedrecords_Internalname, "Associated Records", "col-sm-3 AssociationListAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            /* ListBox */
            GxWebStd.gx_listbox_ctrl1( context, lstavAssociatedrecords, lstavAssociatedrecords_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0)), 2, lstavAssociatedrecords_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, lstavAssociatedrecords.Enabled, 0, 0, 8, "em", 0, "row", "", "AssociationListAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, "HLP_AssociationVeiculoRastreador.htm");
            lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
            AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", (string)(lstavAssociatedrecords.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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

      protected void START2P2( )
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
               Form.Meta.addItem("description", "Association Veiculo Rastreador", 0) ;
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
               STRUP2P0( ) ;
            }
         }
      }

      protected void WS2P2( )
      {
         START2P2( ) ;
         EVT2P2( ) ;
      }

      protected void EVT2P2( )
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
                                 STRUP2P0( ) ;
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
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E122P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
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
                                          E132P2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DISASSOCIATE SELECTED'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Disassociate Selected' */
                                    E142P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ASSOCIATE SELECTED'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Associate selected' */
                                    E152P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ASSOCIATE ALL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Associate All' */
                                    E162P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DISASSOCIATE ALL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Disassociate All' */
                                    E172P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E182P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E192P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E202P2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = lstavNotassociatedrecords_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E182P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E192P2 ();
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

      protected void WE2P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2P2( ) ;
            }
         }
      }

      protected void PA2P2( )
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
               GX_FocusControl = lstavNotassociatedrecords_Internalname;
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
         if ( lstavNotassociatedrecords.ItemCount > 0 )
         {
            AV26NotAssociatedRecords = (int)(NumberUtil.Val( lstavNotassociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV26NotAssociatedRecords", StringUtil.LTrimStr( (decimal)(AV26NotAssociatedRecords), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
            AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
         }
         if ( lstavAssociatedrecords.ItemCount > 0 )
         {
            AV25AssociatedRecords = (int)(NumberUtil.Val( lstavAssociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0))), "."));
            AssignAttri(sPrefix, false, "AV25AssociatedRecords", StringUtil.LTrimStr( (decimal)(AV25AssociatedRecords), 8, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
            AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2P2( ) ;
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

      protected void RF2P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E122P2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E202P2 ();
            WB2P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2P2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV8VeiculoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8VeiculoId"), ",", "."));
            /* Read variables values. */
            lstavNotassociatedrecords.CurrentValue = cgiGet( lstavNotassociatedrecords_Internalname);
            AV26NotAssociatedRecords = (int)(NumberUtil.Val( cgiGet( lstavNotassociatedrecords_Internalname), "."));
            AssignAttri(sPrefix, false, "AV26NotAssociatedRecords", StringUtil.LTrimStr( (decimal)(AV26NotAssociatedRecords), 8, 0));
            lstavAssociatedrecords.CurrentValue = cgiGet( lstavAssociatedrecords_Internalname);
            AV25AssociatedRecords = (int)(NumberUtil.Val( cgiGet( lstavAssociatedrecords_Internalname), "."));
            AssignAttri(sPrefix, false, "AV25AssociatedRecords", StringUtil.LTrimStr( (decimal)(AV25AssociatedRecords), 8, 0));
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
         E112P2 ();
         if (returnInSub) return;
      }

      protected void E112P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         GXt_char1 = AV29GAMGUID;
         new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
         AV29GAMGUID = GXt_char1;
         AssignAttri(sPrefix, false, "AV29GAMGUID", AV29GAMGUID);
         AV30IsAdministrator = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).checkrole("Administrator");
         AssignAttri(sPrefix, false, "AV30IsAdministrator", AV30IsAdministrator);
         if ( ! (0==AV8VeiculoId) )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV30IsAdministrator ,
                                                 A151RastreadorGAMGUIDProprietario ,
                                                 AV29GAMGUID } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H002P2 */
            pr_default.execute(0, new Object[] {AV29GAMGUID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A106RastreadorId = H002P2_A106RastreadorId[0];
               A151RastreadorGAMGUIDProprietario = H002P2_A151RastreadorGAMGUIDProprietario[0];
               A110RastreadorSNumber = H002P2_A110RastreadorSNumber[0];
               A112RastreadorAtrelado = H002P2_A112RastreadorAtrelado[0];
               AV11Exist = false;
               /* Using cursor H002P3 */
               pr_default.execute(1, new Object[] {AV8VeiculoId, A106RastreadorId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A98VeiculoId = H002P3_A98VeiculoId[0];
                  AV11Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               AV14Description = StringUtil.Trim( StringUtil.Str( (decimal)(A110RastreadorSNumber), 16, 0));
               if ( AV11Exist )
               {
                  AV21AddedKeyList.Add(A106RastreadorId, 0);
                  AV23AddedDscList.Add(AV14Description, 0);
               }
               else
               {
                  if ( ! A112RastreadorAtrelado )
                  {
                     AV22NotAddedKeyList.Add(A106RastreadorId, 0);
                     AV24NotAddedDscList.Add(AV14Description, 0);
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         if ( 1 == 2 )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
            if ( StringUtil.StrCmp(AV10HTTPRequest.Method, "GET") == 0 )
            {
               AV35GXLvl47 = 0;
               /* Using cursor H002P4 */
               pr_default.execute(2, new Object[] {AV8VeiculoId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A98VeiculoId = H002P4_A98VeiculoId[0];
                  AV35GXLvl47 = 1;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               if ( AV35GXLvl47 == 0 )
               {
                  GX_msglist.addItem("Registro não encontrado");
               }
               /* Using cursor H002P5 */
               pr_default.execute(3);
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A106RastreadorId = H002P5_A106RastreadorId[0];
                  AV11Exist = false;
                  /* Using cursor H002P6 */
                  pr_default.execute(4, new Object[] {AV8VeiculoId, A106RastreadorId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A98VeiculoId = H002P6_A98VeiculoId[0];
                     AV11Exist = true;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
                  AV14Description = context.localUtil.Format( (decimal)(A106RastreadorId), "ZZZZZZZ9");
                  if ( AV11Exist )
                  {
                     AV21AddedKeyList.Add(A106RastreadorId, 0);
                     AV23AddedDscList.Add(AV14Description, 0);
                  }
                  else
                  {
                     AV22NotAddedKeyList.Add(A106RastreadorId, 0);
                     AV24NotAddedDscList.Add(AV14Description, 0);
                  }
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               /* Execute user subroutine: 'SAVELISTS' */
               S112 ();
               if (returnInSub) return;
            }
         }
      }

      protected void E122P2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E132P2 ();
         if (returnInSub) return;
      }

      protected void E132P2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV13Success = true;
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV21AddedKeyList.Count )
         {
            AV9RastreadorId = (int)(AV21AddedKeyList.GetNumeric(AV38GXV1));
            AssignAttri(sPrefix, false, "AV9RastreadorId", StringUtil.LTrimStr( (decimal)(AV9RastreadorId), 8, 0));
            if ( AV13Success )
            {
               AV11Exist = false;
               /* Using cursor H002P7 */
               pr_default.execute(5, new Object[] {AV8VeiculoId, AV9RastreadorId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A106RastreadorId = H002P7_A106RastreadorId[0];
                  A98VeiculoId = H002P7_A98VeiculoId[0];
                  AV11Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
               if ( ! AV11Exist )
               {
                  AV12VeiculoRastreador = new SdtVeiculoRastreador(context);
                  AV12VeiculoRastreador.gxTpr_Veiculoid = AV8VeiculoId;
                  AV12VeiculoRastreador.gxTpr_Rastreadorid = AV9RastreadorId;
                  AV12VeiculoRastreador.Save();
                  if ( ! AV12VeiculoRastreador.Success() )
                  {
                     AV13Success = false;
                  }
               }
            }
            AV15i = (int)(AV15i+1);
            AV38GXV1 = (int)(AV38GXV1+1);
         }
         AV15i = 1;
         AV40GXV2 = 1;
         while ( AV40GXV2 <= AV22NotAddedKeyList.Count )
         {
            AV9RastreadorId = (int)(AV22NotAddedKeyList.GetNumeric(AV40GXV2));
            AssignAttri(sPrefix, false, "AV9RastreadorId", StringUtil.LTrimStr( (decimal)(AV9RastreadorId), 8, 0));
            if ( AV13Success )
            {
               AV11Exist = false;
               /* Using cursor H002P8 */
               pr_default.execute(6, new Object[] {AV8VeiculoId, AV9RastreadorId});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A106RastreadorId = H002P8_A106RastreadorId[0];
                  A98VeiculoId = H002P8_A98VeiculoId[0];
                  AV11Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(6);
               if ( AV11Exist )
               {
                  AV12VeiculoRastreador = new SdtVeiculoRastreador(context);
                  AV12VeiculoRastreador.Load(AV8VeiculoId, AV9RastreadorId);
                  if ( AV12VeiculoRastreador.Success() )
                  {
                     AV12VeiculoRastreador.Delete();
                  }
                  if ( ! AV12VeiculoRastreador.Success() )
                  {
                     AV13Success = false;
                  }
               }
            }
            AV15i = (int)(AV15i+1);
            AV40GXV2 = (int)(AV40GXV2+1);
         }
         if ( AV13Success )
         {
            context.CommitDataStores("associationveiculorastreador",pr_default);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            /* Execute user subroutine: 'SHOW ERROR MESSAGES' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12VeiculoRastreador", AV12VeiculoRastreador);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
      }

      protected void E142P2( )
      {
         /* 'Disassociate Selected' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISASSOCIATESELECTED' */
         S152 ();
         if (returnInSub) return;
         AV28WebSession.Set("RastreadoresNaoSelecionados", AV22NotAddedKeyList.ToJSonString(false));
         AV28WebSession.Set("RastreadoresSelecionados", AV21AddedKeyList.ToJSonString(false));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E152P2( )
      {
         /* 'Associate selected' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATESELECTED' */
         S162 ();
         if (returnInSub) return;
         AV28WebSession.Set("RastreadoresNaoSelecionados", AV22NotAddedKeyList.ToJSonString(false));
         AV28WebSession.Set("RastreadoresSelecionados", AV21AddedKeyList.ToJSonString(false));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E162P2( )
      {
         /* 'Associate All' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATEALL' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         AV28WebSession.Set("RastreadoresNaoSelecionados", AV22NotAddedKeyList.ToJSonString(false));
         AV28WebSession.Set("RastreadoresSelecionados", AV21AddedKeyList.ToJSonString(false));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E172P2( )
      {
         /* 'Disassociate All' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATEALL' */
         S172 ();
         if (returnInSub) return;
         AV22NotAddedKeyList = (GxSimpleCollection<int>)(AV21AddedKeyList.Clone());
         AV24NotAddedDscList = (GxSimpleCollection<string>)(AV23AddedDscList.Clone());
         AV23AddedDscList.Clear();
         AV21AddedKeyList.Clear();
         /* Execute user subroutine: 'SAVELISTS' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         AV28WebSession.Set("RastreadoresNaoSelecionados", AV22NotAddedKeyList.ToJSonString(false));
         AV28WebSession.Set("RastreadoresSelecionados", AV21AddedKeyList.ToJSonString(false));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E182P2( )
      {
         /* Associatedrecords_Dblclick Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISASSOCIATESELECTED' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E192P2( )
      {
         /* Notassociatedrecords_Dblclick Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATESELECTED' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AddedKeyList", AV21AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23AddedDscList", AV23AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22NotAddedKeyList", AV22NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24NotAddedDscList", AV24NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25AssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26NotAssociatedRecords), 8, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'UPDATEASSOCIATIONVARIABLES' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         lstavAssociatedrecords.removeAllItems();
         lstavNotassociatedrecords.removeAllItems();
         AV15i = 1;
         AV42GXV3 = 1;
         while ( AV42GXV3 <= AV21AddedKeyList.Count )
         {
            AV9RastreadorId = (int)(AV21AddedKeyList.GetNumeric(AV42GXV3));
            AssignAttri(sPrefix, false, "AV9RastreadorId", StringUtil.LTrimStr( (decimal)(AV9RastreadorId), 8, 0));
            AV14Description = ((string)AV23AddedDscList.Item(AV15i));
            lstavAssociatedrecords.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV9RastreadorId), 8, 0)), StringUtil.Trim( AV14Description), 0);
            AV15i = (int)(AV15i+1);
            AV42GXV3 = (int)(AV42GXV3+1);
         }
         AV15i = 1;
         AV43GXV4 = 1;
         while ( AV43GXV4 <= AV22NotAddedKeyList.Count )
         {
            AV9RastreadorId = (int)(AV22NotAddedKeyList.GetNumeric(AV43GXV4));
            AssignAttri(sPrefix, false, "AV9RastreadorId", StringUtil.LTrimStr( (decimal)(AV9RastreadorId), 8, 0));
            AV14Description = ((string)AV24NotAddedDscList.Item(AV15i));
            lstavNotassociatedrecords.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV9RastreadorId), 8, 0)), StringUtil.Trim( AV14Description), 0);
            AV15i = (int)(AV15i+1);
            AV43GXV4 = (int)(AV43GXV4+1);
         }
      }

      protected void S142( )
      {
         /* 'SHOW ERROR MESSAGES' Routine */
         returnInSub = false;
         AV45GXV6 = 1;
         AV44GXV5 = AV12VeiculoRastreador.GetMessages();
         while ( AV45GXV6 <= AV44GXV5.Count )
         {
            AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV44GXV5.Item(AV45GXV6));
            if ( AV16Message.gxTpr_Type == 1 )
            {
               GX_msglist.addItem(AV16Message.gxTpr_Description);
            }
            AV45GXV6 = (int)(AV45GXV6+1);
         }
      }

      protected void S132( )
      {
         /* 'LOADLISTS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17AddedKeyListXml)) )
         {
            AV23AddedDscList.FromXml(AV19AddedDscListXml, null, "Collection", "");
            AV21AddedKeyList.FromXml(AV17AddedKeyListXml, null, "Collection", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18NotAddedKeyListXml)) )
         {
            AV22NotAddedKeyList.FromXml(AV18NotAddedKeyListXml, null, "Collection", "");
            AV24NotAddedDscList.FromXml(AV20NotAddedDscListXml, null, "Collection", "");
         }
      }

      protected void S112( )
      {
         /* 'SAVELISTS' Routine */
         returnInSub = false;
         if ( AV21AddedKeyList.Count > 0 )
         {
            AV17AddedKeyListXml = AV21AddedKeyList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV17AddedKeyListXml", AV17AddedKeyListXml);
            AV19AddedDscListXml = AV23AddedDscList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV19AddedDscListXml", AV19AddedDscListXml);
         }
         else
         {
            AV17AddedKeyListXml = "";
            AssignAttri(sPrefix, false, "AV17AddedKeyListXml", AV17AddedKeyListXml);
            AV19AddedDscListXml = "";
            AssignAttri(sPrefix, false, "AV19AddedDscListXml", AV19AddedDscListXml);
         }
         if ( AV22NotAddedKeyList.Count > 0 )
         {
            AV18NotAddedKeyListXml = AV22NotAddedKeyList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV18NotAddedKeyListXml", AV18NotAddedKeyListXml);
            AV20NotAddedDscListXml = AV24NotAddedDscList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV20NotAddedDscListXml", AV20NotAddedDscListXml);
         }
         else
         {
            AV18NotAddedKeyListXml = "";
            AssignAttri(sPrefix, false, "AV18NotAddedKeyListXml", AV18NotAddedKeyListXml);
            AV20NotAddedDscListXml = "";
            AssignAttri(sPrefix, false, "AV20NotAddedDscListXml", AV20NotAddedDscListXml);
         }
      }

      protected void S172( )
      {
         /* 'ASSOCIATEALL' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV27InsertIndex = 1;
         AV46GXV7 = 1;
         while ( AV46GXV7 <= AV22NotAddedKeyList.Count )
         {
            AV9RastreadorId = (int)(AV22NotAddedKeyList.GetNumeric(AV46GXV7));
            AssignAttri(sPrefix, false, "AV9RastreadorId", StringUtil.LTrimStr( (decimal)(AV9RastreadorId), 8, 0));
            AV14Description = ((string)AV24NotAddedDscList.Item(AV15i));
            while ( ( AV27InsertIndex <= AV23AddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV23AddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV21AddedKeyList.Add(AV9RastreadorId, AV27InsertIndex);
            AV23AddedDscList.Add(AV14Description, AV27InsertIndex);
            AV15i = (int)(AV15i+1);
            AV46GXV7 = (int)(AV46GXV7+1);
         }
         AV22NotAddedKeyList.Clear();
         AV24NotAddedDscList.Clear();
         /* Execute user subroutine: 'SAVELISTS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'ASSOCIATESELECTED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV47GXV8 = 1;
         while ( AV47GXV8 <= AV22NotAddedKeyList.Count )
         {
            AV9RastreadorId = (int)(AV22NotAddedKeyList.GetNumeric(AV47GXV8));
            AssignAttri(sPrefix, false, "AV9RastreadorId", StringUtil.LTrimStr( (decimal)(AV9RastreadorId), 8, 0));
            if ( AV9RastreadorId == AV26NotAssociatedRecords )
            {
               if (true) break;
            }
            AV15i = (int)(AV15i+1);
            AV47GXV8 = (int)(AV47GXV8+1);
         }
         if ( AV15i <= AV22NotAddedKeyList.Count )
         {
            AV14Description = ((string)AV24NotAddedDscList.Item(AV15i));
            AV27InsertIndex = 1;
            while ( ( AV27InsertIndex <= AV23AddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV23AddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV21AddedKeyList.Add(AV26NotAssociatedRecords, AV27InsertIndex);
            AV23AddedDscList.Add(AV14Description, AV27InsertIndex);
            AV22NotAddedKeyList.RemoveItem(AV15i);
            AV24NotAddedDscList.RemoveItem(AV15i);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'DISASSOCIATESELECTED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV15i = 1;
         AV48GXV9 = 1;
         while ( AV48GXV9 <= AV21AddedKeyList.Count )
         {
            AV9RastreadorId = (int)(AV21AddedKeyList.GetNumeric(AV48GXV9));
            AssignAttri(sPrefix, false, "AV9RastreadorId", StringUtil.LTrimStr( (decimal)(AV9RastreadorId), 8, 0));
            if ( AV9RastreadorId == AV25AssociatedRecords )
            {
               if (true) break;
            }
            AV15i = (int)(AV15i+1);
            AV48GXV9 = (int)(AV48GXV9+1);
         }
         if ( AV15i <= AV21AddedKeyList.Count )
         {
            AV14Description = ((string)AV23AddedDscList.Item(AV15i));
            AV27InsertIndex = 1;
            while ( ( AV27InsertIndex <= AV24NotAddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV24NotAddedDscList.Item(AV27InsertIndex)), AV14Description) < 0 ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV22NotAddedKeyList.Add(AV25AssociatedRecords, AV27InsertIndex);
            AV24NotAddedDscList.Add(AV14Description, AV27InsertIndex);
            AV21AddedKeyList.RemoveItem(AV15i);
            AV23AddedDscList.RemoveItem(AV15i);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E202P2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8VeiculoId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 8, 0));
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
         PA2P2( ) ;
         WS2P2( ) ;
         WE2P2( ) ;
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
         sCtrlAV8VeiculoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "associationveiculorastreador", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2P2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8VeiculoId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 8, 0));
         }
         wcpOAV8VeiculoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8VeiculoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV8VeiculoId != wcpOAV8VeiculoId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8VeiculoId = AV8VeiculoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8VeiculoId = cgiGet( sPrefix+"AV8VeiculoId_CTRL");
         if ( StringUtil.Len( sCtrlAV8VeiculoId) > 0 )
         {
            AV8VeiculoId = (int)(context.localUtil.CToN( cgiGet( sCtrlAV8VeiculoId), ",", "."));
            AssignAttri(sPrefix, false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 8, 0));
         }
         else
         {
            AV8VeiculoId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV8VeiculoId_PARM"), ",", "."));
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
         PA2P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2P2( ) ;
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
         WS2P2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8VeiculoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8VeiculoId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8VeiculoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8VeiculoId_CTRL", StringUtil.RTrim( sCtrlAV8VeiculoId));
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
         WE2P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142918365819", true, true);
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
         context.AddJavascriptSource("associationveiculorastreador.js", "?202142918365820", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         lstavNotassociatedrecords.Name = "vNOTASSOCIATEDRECORDS";
         lstavNotassociatedrecords.WebTags = "";
         if ( lstavNotassociatedrecords.ItemCount > 0 )
         {
         }
         lstavAssociatedrecords.Name = "vASSOCIATEDRECORDS";
         lstavAssociatedrecords.WebTags = "";
         if ( lstavAssociatedrecords.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblNotassociatedrecordstitle_Internalname = sPrefix+"NOTASSOCIATEDRECORDSTITLE";
         lstavNotassociatedrecords_Internalname = sPrefix+"vNOTASSOCIATEDRECORDS";
         divTablenotassociated_Internalname = sPrefix+"TABLENOTASSOCIATED";
         imgImageassociateall_Internalname = sPrefix+"IMAGEASSOCIATEALL";
         imgImageassociateselected_Internalname = sPrefix+"IMAGEASSOCIATESELECTED";
         imgImagedisassociateselected_Internalname = sPrefix+"IMAGEDISASSOCIATESELECTED";
         imgImagedisassociateall_Internalname = sPrefix+"IMAGEDISASSOCIATEALL";
         divUnnamedtableassociationbuttons_Internalname = sPrefix+"UNNAMEDTABLEASSOCIATIONBUTTONS";
         lblAssociatedrecordstitle_Internalname = sPrefix+"ASSOCIATEDRECORDSTITLE";
         lstavAssociatedrecords_Internalname = sPrefix+"vASSOCIATEDRECORDS";
         divTableassociated_Internalname = sPrefix+"TABLEASSOCIATED";
         divTablefullcontent_Internalname = sPrefix+"TABLEFULLCONTENT";
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
         lstavAssociatedrecords_Jsonclick = "";
         lstavAssociatedrecords.Enabled = 1;
         lstavNotassociatedrecords_Jsonclick = "";
         lstavNotassociatedrecords.Enabled = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E132P2',iparms:[{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'A98VeiculoId',fld:'VEICULOID',pic:'ZZZZZZZ9'},{av:'AV8VeiculoId',fld:'vVEICULOID',pic:'ZZZZZZZ9'},{av:'A106RastreadorId',fld:'RASTREADORID',pic:'ZZZZZZZ9'},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'AV12VeiculoRastreador',fld:'vVEICULORASTREADOR',pic:''},{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV12VeiculoRastreador',fld:'vVEICULORASTREADOR',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''}]}");
         setEventMetadata("'DISASSOCIATE SELECTED'","{handler:'E142P2',iparms:[{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'DISASSOCIATE SELECTED'",",oparms:[{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("'ASSOCIATE SELECTED'","{handler:'E152P2',iparms:[{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'ASSOCIATE SELECTED'",",oparms:[{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("'ASSOCIATE ALL'","{handler:'E162P2',iparms:[{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'ASSOCIATE ALL'",",oparms:[{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]}");
         setEventMetadata("'DISASSOCIATE ALL'","{handler:'E172P2',iparms:[{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'DISASSOCIATE ALL'",",oparms:[{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VASSOCIATEDRECORDS.DBLCLICK","{handler:'E182P2',iparms:[{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("VASSOCIATEDRECORDS.DBLCLICK",",oparms:[{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VNOTASSOCIATEDRECORDS.DBLCLICK","{handler:'E192P2',iparms:[{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("VNOTASSOCIATEDRECORDS.DBLCLICK",",oparms:[{av:'AV9RastreadorId',fld:'vRASTREADORID',pic:'ZZZZZZZ9'},{av:'AV21AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV23AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV22NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV24NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV17AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV19AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV18NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV20NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV25AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV26NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZZZ9'}]}");
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
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV21AddedKeyList = new GxSimpleCollection<int>();
         AV23AddedDscList = new GxSimpleCollection<string>();
         AV22NotAddedKeyList = new GxSimpleCollection<int>();
         AV24NotAddedDscList = new GxSimpleCollection<string>();
         AV17AddedKeyListXml = "";
         AV19AddedDscListXml = "";
         AV18NotAddedKeyListXml = "";
         AV20NotAddedDscListXml = "";
         AV12VeiculoRastreador = new SdtVeiculoRastreador(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblNotassociatedrecordstitle_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         imgImageassociateall_Jsonclick = "";
         imgImageassociateselected_Jsonclick = "";
         imgImagedisassociateselected_Jsonclick = "";
         imgImagedisassociateall_Jsonclick = "";
         lblAssociatedrecordstitle_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29GAMGUID = "";
         GXt_char1 = "";
         scmdbuf = "";
         A151RastreadorGAMGUIDProprietario = "";
         H002P2_A106RastreadorId = new int[1] ;
         H002P2_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         H002P2_A110RastreadorSNumber = new long[1] ;
         H002P2_A112RastreadorAtrelado = new bool[] {false} ;
         H002P3_A106RastreadorId = new int[1] ;
         H002P3_A98VeiculoId = new int[1] ;
         AV14Description = "";
         AV10HTTPRequest = new GxHttpRequest( context);
         H002P4_A98VeiculoId = new int[1] ;
         H002P5_A106RastreadorId = new int[1] ;
         H002P6_A106RastreadorId = new int[1] ;
         H002P6_A98VeiculoId = new int[1] ;
         H002P7_A106RastreadorId = new int[1] ;
         H002P7_A98VeiculoId = new int[1] ;
         H002P8_A106RastreadorId = new int[1] ;
         H002P8_A98VeiculoId = new int[1] ;
         AV28WebSession = context.GetSession();
         AV44GXV5 = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8VeiculoId = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.associationveiculorastreador__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.associationveiculorastreador__default(),
            new Object[][] {
                new Object[] {
               H002P2_A106RastreadorId, H002P2_A151RastreadorGAMGUIDProprietario, H002P2_A110RastreadorSNumber, H002P2_A112RastreadorAtrelado
               }
               , new Object[] {
               H002P3_A106RastreadorId, H002P3_A98VeiculoId
               }
               , new Object[] {
               H002P4_A98VeiculoId
               }
               , new Object[] {
               H002P5_A106RastreadorId
               }
               , new Object[] {
               H002P6_A106RastreadorId, H002P6_A98VeiculoId
               }
               , new Object[] {
               H002P7_A106RastreadorId, H002P7_A98VeiculoId
               }
               , new Object[] {
               H002P8_A106RastreadorId, H002P8_A98VeiculoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV35GXLvl47 ;
      private short nGXWrapped ;
      private int AV8VeiculoId ;
      private int wcpOAV8VeiculoId ;
      private int A98VeiculoId ;
      private int A106RastreadorId ;
      private int AV9RastreadorId ;
      private int AV26NotAssociatedRecords ;
      private int AV25AssociatedRecords ;
      private int AV15i ;
      private int AV38GXV1 ;
      private int AV40GXV2 ;
      private int AV42GXV3 ;
      private int AV43GXV4 ;
      private int AV45GXV6 ;
      private int AV27InsertIndex ;
      private int AV46GXV7 ;
      private int AV47GXV8 ;
      private int AV48GXV9 ;
      private int idxLst ;
      private long A110RastreadorSNumber ;
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
      private string divTablefullcontent_Internalname ;
      private string divTablenotassociated_Internalname ;
      private string lblNotassociatedrecordstitle_Internalname ;
      private string lblNotassociatedrecordstitle_Jsonclick ;
      private string lstavNotassociatedrecords_Internalname ;
      private string TempTags ;
      private string lstavNotassociatedrecords_Jsonclick ;
      private string divUnnamedtableassociationbuttons_Internalname ;
      private string sImgUrl ;
      private string imgImageassociateall_Internalname ;
      private string imgImageassociateall_Jsonclick ;
      private string imgImageassociateselected_Internalname ;
      private string imgImageassociateselected_Jsonclick ;
      private string imgImagedisassociateselected_Internalname ;
      private string imgImagedisassociateselected_Jsonclick ;
      private string imgImagedisassociateall_Internalname ;
      private string imgImagedisassociateall_Jsonclick ;
      private string divTableassociated_Internalname ;
      private string lblAssociatedrecordstitle_Internalname ;
      private string lblAssociatedrecordstitle_Jsonclick ;
      private string lstavAssociatedrecords_Internalname ;
      private string lstavAssociatedrecords_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV29GAMGUID ;
      private string GXt_char1 ;
      private string scmdbuf ;
      private string A151RastreadorGAMGUIDProprietario ;
      private string sCtrlAV8VeiculoId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV30IsAdministrator ;
      private bool A112RastreadorAtrelado ;
      private bool AV11Exist ;
      private bool AV13Success ;
      private string AV17AddedKeyListXml ;
      private string AV19AddedDscListXml ;
      private string AV18NotAddedKeyListXml ;
      private string AV20NotAddedDscListXml ;
      private string AV14Description ;
      private GxSimpleCollection<int> AV21AddedKeyList ;
      private GxSimpleCollection<int> AV22NotAddedKeyList ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXListbox lstavNotassociatedrecords ;
      private GXListbox lstavAssociatedrecords ;
      private IDataStoreProvider pr_default ;
      private int[] H002P2_A106RastreadorId ;
      private string[] H002P2_A151RastreadorGAMGUIDProprietario ;
      private long[] H002P2_A110RastreadorSNumber ;
      private bool[] H002P2_A112RastreadorAtrelado ;
      private int[] H002P3_A106RastreadorId ;
      private int[] H002P3_A98VeiculoId ;
      private int[] H002P4_A98VeiculoId ;
      private int[] H002P5_A106RastreadorId ;
      private int[] H002P6_A106RastreadorId ;
      private int[] H002P6_A98VeiculoId ;
      private int[] H002P7_A106RastreadorId ;
      private int[] H002P7_A98VeiculoId ;
      private int[] H002P8_A106RastreadorId ;
      private int[] H002P8_A98VeiculoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV28WebSession ;
      private GxSimpleCollection<string> AV23AddedDscList ;
      private GxSimpleCollection<string> AV24NotAddedDscList ;
      private GXBaseCollection<SdtMessages_Message> AV44GXV5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtVeiculoRastreador AV12VeiculoRastreador ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
   }

   public class associationveiculorastreador__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class associationveiculorastreador__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H002P2( IGxContext context ,
                                           bool AV30IsAdministrator ,
                                           string A151RastreadorGAMGUIDProprietario ,
                                           string AV29GAMGUID )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[1];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT [RastreadorId], [RastreadorGAMGUIDProprietario], [RastreadorSNumber], [RastreadorAtrelado] FROM [Rastreador]";
       if ( ! AV30IsAdministrator )
       {
          AddWhere(sWhereString, "([RastreadorGAMGUIDProprietario] = @AV29GAMGUID)");
       }
       else
       {
          GXv_int2[0] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [RastreadorId]";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H002P2(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
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
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH002P3;
        prmH002P3 = new Object[] {
        new Object[] {"@AV8VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmH002P4;
        prmH002P4 = new Object[] {
        new Object[] {"@AV8VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmH002P5;
        prmH002P5 = new Object[] {
        };
        Object[] prmH002P6;
        prmH002P6 = new Object[] {
        new Object[] {"@AV8VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmH002P7;
        prmH002P7 = new Object[] {
        new Object[] {"@AV8VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@AV9RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmH002P8;
        prmH002P8 = new Object[] {
        new Object[] {"@AV8VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@AV9RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmH002P2;
        prmH002P2 = new Object[] {
        new Object[] {"@AV29GAMGUID",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("H002P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H002P3", "SELECT [RastreadorId], [VeiculoId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @AV8VeiculoId and [RastreadorId] = @RastreadorId ORDER BY [VeiculoId], [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P3,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H002P4", "SELECT [VeiculoId] FROM [Veiculo] WHERE [VeiculoId] = @AV8VeiculoId ORDER BY [VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P4,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H002P5", "SELECT [RastreadorId] FROM [Rastreador] ORDER BY [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H002P6", "SELECT [RastreadorId], [VeiculoId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @AV8VeiculoId and [RastreadorId] = @RastreadorId ORDER BY [VeiculoId], [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P6,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H002P7", "SELECT [RastreadorId], [VeiculoId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @AV8VeiculoId and [RastreadorId] = @AV9RastreadorId ORDER BY [VeiculoId], [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P7,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H002P8", "SELECT [RastreadorId], [VeiculoId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @AV8VeiculoId and [RastreadorId] = @AV9RastreadorId ORDER BY [VeiculoId], [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002P8,1, GxCacheFrequency.OFF ,false,true )
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
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getLong(3);
              table[3][0] = rslt.getBool(4);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 6 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
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
              sIdx = 0;
              if ( (short)parms[0] == 0 )
              {
                 sIdx = (short)(sIdx+1);
                 stmt.SetParameter(sIdx, (string)parms[1]);
              }
              return;
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 2 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 5 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 6 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
