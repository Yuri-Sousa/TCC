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
   public class frota : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action8") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A93FrotaId = (int)(NumberUtil.Val( GetPar( "FrotaId"), "."));
            AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_8_0E15( Gx_mode, A93FrotaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"FROTAPROPRIETARIOGAMGUID") == 0 )
         {
            Gx_BScreen = (short)(NumberUtil.Val( GetPar( "Gx_BScreen"), "."));
            AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX6ASAFROTAPROPRIETARIOGAMGUID0E15( Gx_BScreen, Gx_mode) ;
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
               AV7FrotaId = (int)(NumberUtil.Val( GetPar( "FrotaId"), "."));
               AssignAttri("", false, "AV7FrotaId", StringUtil.LTrimStr( (decimal)(AV7FrotaId), 8, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vFROTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FrotaId), "ZZZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148565", 0) ;
            }
            Form.Meta.addItem("description", "Frota", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFrotaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public frota( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public frota( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_FrotaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FrotaId = aP1_FrotaId;
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
            return "frota_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFrotaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFrotaId_Internalname, "Sequência", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFrotaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A93FrotaId), 8, 0, ",", "")), ((edtFrotaId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A93FrotaId), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A93FrotaId), "ZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFrotaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFrotaId_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Frota.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFrotaDataHoraCriacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFrotaDataHoraCriacao_Internalname, "Data/Hora da Criação", " AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtFrotaDataHoraCriacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFrotaDataHoraCriacao_Internalname, context.localUtil.TToC( A94FrotaDataHoraCriacao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A94FrotaDataHoraCriacao, "99/99/99 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFrotaDataHoraCriacao_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtFrotaDataHoraCriacao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Frota.htm");
         GxWebStd.gx_bitmap( context, edtFrotaDataHoraCriacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFrotaDataHoraCriacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Frota.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFrotaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFrotaNome_Internalname, "Nome", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFrotaNome_Internalname, A95FrotaNome, StringUtil.RTrim( context.localUtil.Format( A95FrotaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFrotaNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFrotaNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Frota.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFrotaProprietarioGAMGUID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFrotaProprietarioGAMGUID_Internalname, "GAMGUID do Proprietário", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFrotaProprietarioGAMGUID_Internalname, StringUtil.RTrim( A96FrotaProprietarioGAMGUID), StringUtil.RTrim( context.localUtil.Format( A96FrotaProprietarioGAMGUID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFrotaProprietarioGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFrotaProprietarioGAMGUID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "left", true, "", "HLP_Frota.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_veiculos.SetProperty("Width", Dvpanel_veiculos_Width);
         ucDvpanel_veiculos.SetProperty("AutoWidth", Dvpanel_veiculos_Autowidth);
         ucDvpanel_veiculos.SetProperty("AutoHeight", Dvpanel_veiculos_Autoheight);
         ucDvpanel_veiculos.SetProperty("Cls", Dvpanel_veiculos_Cls);
         ucDvpanel_veiculos.SetProperty("Title", Dvpanel_veiculos_Title);
         ucDvpanel_veiculos.SetProperty("Collapsible", Dvpanel_veiculos_Collapsible);
         ucDvpanel_veiculos.SetProperty("Collapsed", Dvpanel_veiculos_Collapsed);
         ucDvpanel_veiculos.SetProperty("ShowCollapseIcon", Dvpanel_veiculos_Showcollapseicon);
         ucDvpanel_veiculos.SetProperty("IconPosition", Dvpanel_veiculos_Iconposition);
         ucDvpanel_veiculos.SetProperty("AutoScroll", Dvpanel_veiculos_Autoscroll);
         ucDvpanel_veiculos.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_veiculos_Internalname, "DVPANEL_VEICULOSContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_VEICULOSContainer"+"Veiculos"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divVeiculos_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0043"+"", StringUtil.RTrim( WebComp_Wcassociationfrotaveiculo_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0043"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcassociationfrotaveiculo), StringUtil.Lower( WebComp_Wcassociationfrotaveiculo_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               }
               WebComp_Wcassociationfrotaveiculo.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcassociationfrotaveiculo), StringUtil.Lower( WebComp_Wcassociationfrotaveiculo_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Frota.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Frota.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Frota.htm");
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

      protected void UserMain( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
               {
                  WebComp_Wcassociationfrotaveiculo.componentstart();
               }
            }
         }
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110E2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z93FrotaId = (int)(context.localUtil.CToN( cgiGet( "Z93FrotaId"), ",", "."));
               Z94FrotaDataHoraCriacao = context.localUtil.CToT( cgiGet( "Z94FrotaDataHoraCriacao"), 0);
               Z95FrotaNome = cgiGet( "Z95FrotaNome");
               Z96FrotaProprietarioGAMGUID = cgiGet( "Z96FrotaProprietarioGAMGUID");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               AV7FrotaId = (int)(context.localUtil.CToN( cgiGet( "vFROTAID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               Dvpanel_veiculos_Objectcall = cgiGet( "DVPANEL_VEICULOS_Objectcall");
               Dvpanel_veiculos_Class = cgiGet( "DVPANEL_VEICULOS_Class");
               Dvpanel_veiculos_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Enabled"));
               Dvpanel_veiculos_Width = cgiGet( "DVPANEL_VEICULOS_Width");
               Dvpanel_veiculos_Height = cgiGet( "DVPANEL_VEICULOS_Height");
               Dvpanel_veiculos_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Autowidth"));
               Dvpanel_veiculos_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Autoheight"));
               Dvpanel_veiculos_Cls = cgiGet( "DVPANEL_VEICULOS_Cls");
               Dvpanel_veiculos_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Showheader"));
               Dvpanel_veiculos_Title = cgiGet( "DVPANEL_VEICULOS_Title");
               Dvpanel_veiculos_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Collapsible"));
               Dvpanel_veiculos_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Collapsed"));
               Dvpanel_veiculos_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Showcollapseicon"));
               Dvpanel_veiculos_Iconposition = cgiGet( "DVPANEL_VEICULOS_Iconposition");
               Dvpanel_veiculos_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Autoscroll"));
               Dvpanel_veiculos_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_VEICULOS_Visible"));
               Dvpanel_veiculos_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_VEICULOS_Gxcontroltype"), ",", "."));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A93FrotaId = (int)(context.localUtil.CToN( cgiGet( edtFrotaId_Internalname), ",", "."));
               AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
               A94FrotaDataHoraCriacao = context.localUtil.CToT( cgiGet( edtFrotaDataHoraCriacao_Internalname));
               AssignAttri("", false, "A94FrotaDataHoraCriacao", context.localUtil.TToC( A94FrotaDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
               A95FrotaNome = cgiGet( edtFrotaNome_Internalname);
               AssignAttri("", false, "A95FrotaNome", A95FrotaNome);
               A96FrotaProprietarioGAMGUID = cgiGet( edtFrotaProprietarioGAMGUID_Internalname);
               AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Frota");
               A93FrotaId = (int)(context.localUtil.CToN( cgiGet( edtFrotaId_Internalname), ",", "."));
               AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
               forbiddenHiddens.Add("FrotaId", context.localUtil.Format( (decimal)(A93FrotaId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A94FrotaDataHoraCriacao = context.localUtil.CToT( cgiGet( edtFrotaDataHoraCriacao_Internalname));
               AssignAttri("", false, "A94FrotaDataHoraCriacao", context.localUtil.TToC( A94FrotaDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
               forbiddenHiddens.Add("FrotaDataHoraCriacao", context.localUtil.Format( A94FrotaDataHoraCriacao, "99/99/99 99:99"));
               A96FrotaProprietarioGAMGUID = cgiGet( edtFrotaProprietarioGAMGUID_Internalname);
               AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
               forbiddenHiddens.Add("FrotaProprietarioGAMGUID", StringUtil.RTrim( context.localUtil.Format( A96FrotaProprietarioGAMGUID, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A93FrotaId != Z93FrotaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("frota:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A93FrotaId = (int)(NumberUtil.Val( GetPar( "FrotaId"), "."));
                  AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0E0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FROTAID");
                        AnyError = 1;
                        GX_FocusControl = edtFrotaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                     if ( nCmpId == 43 )
                     {
                        OldWcassociationfrotaveiculo = cgiGet( "W0043");
                        if ( ( StringUtil.Len( OldWcassociationfrotaveiculo) == 0 ) || ( StringUtil.StrCmp(OldWcassociationfrotaveiculo, WebComp_Wcassociationfrotaveiculo_Component) != 0 ) )
                        {
                           WebComp_Wcassociationfrotaveiculo = getWebComponent(GetType(), "GeneXus.Programs", OldWcassociationfrotaveiculo, new Object[] {context} );
                           WebComp_Wcassociationfrotaveiculo.ComponentInit();
                           WebComp_Wcassociationfrotaveiculo.Name = "OldWcassociationfrotaveiculo";
                           WebComp_Wcassociationfrotaveiculo_Component = OldWcassociationfrotaveiculo;
                        }
                        if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
                        {
                           WebComp_Wcassociationfrotaveiculo.componentprocess("W0043", "", sEvt);
                        }
                        WebComp_Wcassociationfrotaveiculo_Component = OldWcassociationfrotaveiculo;
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0E15( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0E15( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E15( ) ;
            }
            else
            {
               CheckExtendedTable0E15( ) ;
               CloseExtendedTableCursors0E15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0E0( )
      {
      }

      protected void E110E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcassociationfrotaveiculo = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcassociationfrotaveiculo_Component), StringUtil.Lower( "AssociationFrotaVeiculo")) != 0 )
         {
            WebComp_Wcassociationfrotaveiculo = getWebComponent(GetType(), "GeneXus.Programs", "associationfrotaveiculo", new Object[] {context} );
            WebComp_Wcassociationfrotaveiculo.ComponentInit();
            WebComp_Wcassociationfrotaveiculo.Name = "AssociationFrotaVeiculo";
            WebComp_Wcassociationfrotaveiculo_Component = "AssociationFrotaVeiculo";
         }
         if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
         {
            WebComp_Wcassociationfrotaveiculo.setjustcreated();
            WebComp_Wcassociationfrotaveiculo.componentprepare(new Object[] {(string)"W0043",(string)"",(int)AV7FrotaId});
            WebComp_Wcassociationfrotaveiculo.componentbind(new Object[] {(string)""});
         }
      }

      protected void E120E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("frotaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z94FrotaDataHoraCriacao = T000E3_A94FrotaDataHoraCriacao[0];
               Z95FrotaNome = T000E3_A95FrotaNome[0];
               Z96FrotaProprietarioGAMGUID = T000E3_A96FrotaProprietarioGAMGUID[0];
            }
            else
            {
               Z94FrotaDataHoraCriacao = A94FrotaDataHoraCriacao;
               Z95FrotaNome = A95FrotaNome;
               Z96FrotaProprietarioGAMGUID = A96FrotaProprietarioGAMGUID;
            }
         }
         if ( GX_JID == -9 )
         {
            Z93FrotaId = A93FrotaId;
            Z94FrotaDataHoraCriacao = A94FrotaDataHoraCriacao;
            Z95FrotaNome = A95FrotaNome;
            Z96FrotaProprietarioGAMGUID = A96FrotaProprietarioGAMGUID;
         }
      }

      protected void standaloneNotModal( )
      {
         edtFrotaId_Enabled = 0;
         AssignProp("", false, edtFrotaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaId_Enabled), 5, 0), true);
         edtFrotaDataHoraCriacao_Enabled = 0;
         AssignProp("", false, edtFrotaDataHoraCriacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaDataHoraCriacao_Enabled), 5, 0), true);
         edtFrotaProprietarioGAMGUID_Enabled = 0;
         AssignProp("", false, edtFrotaProprietarioGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaProprietarioGAMGUID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtFrotaId_Enabled = 0;
         AssignProp("", false, edtFrotaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaId_Enabled), 5, 0), true);
         edtFrotaDataHoraCriacao_Enabled = 0;
         AssignProp("", false, edtFrotaDataHoraCriacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaDataHoraCriacao_Enabled), 5, 0), true);
         edtFrotaProprietarioGAMGUID_Enabled = 0;
         AssignProp("", false, edtFrotaProprietarioGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaProprietarioGAMGUID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FrotaId) )
         {
            A93FrotaId = AV7FrotaId;
            AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (DateTime.MinValue==A94FrotaDataHoraCriacao) && ( Gx_BScreen == 0 ) )
         {
            A94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "A94FrotaDataHoraCriacao", context.localUtil.TToC( A94FrotaDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A96FrotaProprietarioGAMGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A96FrotaProprietarioGAMGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A96FrotaProprietarioGAMGUID = GXt_char1;
            AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
         }
      }

      protected void Load0E15( )
      {
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound15 = 1;
            A94FrotaDataHoraCriacao = T000E4_A94FrotaDataHoraCriacao[0];
            AssignAttri("", false, "A94FrotaDataHoraCriacao", context.localUtil.TToC( A94FrotaDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
            A95FrotaNome = T000E4_A95FrotaNome[0];
            AssignAttri("", false, "A95FrotaNome", A95FrotaNome);
            A96FrotaProprietarioGAMGUID = T000E4_A96FrotaProprietarioGAMGUID[0];
            AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
            ZM0E15( -9) ;
         }
         pr_default.close(2);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A95FrotaNome)) )
         {
            GX_msglist.addItem("Informe o nome da frota.", 1, "FROTANOME");
            AnyError = 1;
            GX_FocusControl = edtFrotaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0E15( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E15( )
      {
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 9) ;
            RcdFound15 = 1;
            A93FrotaId = T000E3_A93FrotaId[0];
            AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
            A94FrotaDataHoraCriacao = T000E3_A94FrotaDataHoraCriacao[0];
            AssignAttri("", false, "A94FrotaDataHoraCriacao", context.localUtil.TToC( A94FrotaDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
            A95FrotaNome = T000E3_A95FrotaNome[0];
            AssignAttri("", false, "A95FrotaNome", A95FrotaNome);
            A96FrotaProprietarioGAMGUID = T000E3_A96FrotaProprietarioGAMGUID[0];
            AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
            Z93FrotaId = A93FrotaId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000E6_A93FrotaId[0] < A93FrotaId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000E6_A93FrotaId[0] > A93FrotaId ) ) )
            {
               A93FrotaId = T000E6_A93FrotaId[0];
               AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000E7_A93FrotaId[0] > A93FrotaId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000E7_A93FrotaId[0] < A93FrotaId ) ) )
            {
               A93FrotaId = T000E7_A93FrotaId[0];
               AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFrotaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A93FrotaId != Z93FrotaId )
               {
                  A93FrotaId = Z93FrotaId;
                  AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FROTAID");
                  AnyError = 1;
                  GX_FocusControl = edtFrotaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFrotaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0E15( ) ;
                  GX_FocusControl = edtFrotaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A93FrotaId != Z93FrotaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtFrotaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E15( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FROTAID");
                     AnyError = 1;
                     GX_FocusControl = edtFrotaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFrotaNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E15( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A93FrotaId != Z93FrotaId )
         {
            A93FrotaId = Z93FrotaId;
            AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FROTAID");
            AnyError = 1;
            GX_FocusControl = edtFrotaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFrotaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A93FrotaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Frota"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z94FrotaDataHoraCriacao != T000E2_A94FrotaDataHoraCriacao[0] ) || ( StringUtil.StrCmp(Z95FrotaNome, T000E2_A95FrotaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z96FrotaProprietarioGAMGUID, T000E2_A96FrotaProprietarioGAMGUID[0]) != 0 ) )
            {
               if ( Z94FrotaDataHoraCriacao != T000E2_A94FrotaDataHoraCriacao[0] )
               {
                  GXUtil.WriteLog("frota:[seudo value changed for attri]"+"FrotaDataHoraCriacao");
                  GXUtil.WriteLogRaw("Old: ",Z94FrotaDataHoraCriacao);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A94FrotaDataHoraCriacao[0]);
               }
               if ( StringUtil.StrCmp(Z95FrotaNome, T000E2_A95FrotaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("frota:[seudo value changed for attri]"+"FrotaNome");
                  GXUtil.WriteLogRaw("Old: ",Z95FrotaNome);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A95FrotaNome[0]);
               }
               if ( StringUtil.StrCmp(Z96FrotaProprietarioGAMGUID, T000E2_A96FrotaProprietarioGAMGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("frota:[seudo value changed for attri]"+"FrotaProprietarioGAMGUID");
                  GXUtil.WriteLogRaw("Old: ",Z96FrotaProprietarioGAMGUID);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A96FrotaProprietarioGAMGUID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Frota"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         if ( ! IsAuthorized("frota_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E8 */
                     pr_default.execute(6, new Object[] {A94FrotaDataHoraCriacao, A95FrotaNome, A96FrotaProprietarioGAMGUID});
                     A93FrotaId = T000E8_A93FrotaId[0];
                     AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Frota");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0E0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         if ( ! IsAuthorized("frota_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E9 */
                     pr_default.execute(7, new Object[] {A94FrotaDataHoraCriacao, A95FrotaNome, A96FrotaProprietarioGAMGUID, A93FrotaId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Frota");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Frota"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("frota_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E10 */
                  pr_default.execute(8, new Object[] {A93FrotaId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Frota");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000E11 */
            pr_default.execute(9, new Object[] {A93FrotaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Frota Veiculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("frota",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            if ( IsIns( )  || IsUpd( )  )
            {
               new atualizarfrotaveiculo(context ).execute(  A93FrotaId) ;
            }
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("frota",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E15( )
      {
         /* Scan By routine */
         /* Using cursor T000E12 */
         pr_default.execute(10);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound15 = 1;
            A93FrotaId = T000E12_A93FrotaId[0];
            AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound15 = 1;
            A93FrotaId = T000E12_A93FrotaId[0];
            AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
         }
      }

      protected void ScanEnd0E15( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0E15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
         edtFrotaId_Enabled = 0;
         AssignProp("", false, edtFrotaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaId_Enabled), 5, 0), true);
         edtFrotaDataHoraCriacao_Enabled = 0;
         AssignProp("", false, edtFrotaDataHoraCriacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaDataHoraCriacao_Enabled), 5, 0), true);
         edtFrotaNome_Enabled = 0;
         AssignProp("", false, edtFrotaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaNome_Enabled), 5, 0), true);
         edtFrotaProprietarioGAMGUID_Enabled = 0;
         AssignProp("", false, edtFrotaProprietarioGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFrotaProprietarioGAMGUID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
      {
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
         MasterPageObj.master_styles();
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 8534944), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202142815485946", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("frota.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7FrotaId,8,0))}, new string[] {"Gx_mode","FrotaId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Frota");
         forbiddenHiddens.Add("FrotaId", context.localUtil.Format( (decimal)(A93FrotaId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("FrotaDataHoraCriacao", context.localUtil.Format( A94FrotaDataHoraCriacao, "99/99/99 99:99"));
         forbiddenHiddens.Add("FrotaProprietarioGAMGUID", StringUtil.RTrim( context.localUtil.Format( A96FrotaProprietarioGAMGUID, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("frota:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z93FrotaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z93FrotaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z94FrotaDataHoraCriacao", context.localUtil.TToC( Z94FrotaDataHoraCriacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z95FrotaNome", Z95FrotaNome);
         GxWebStd.gx_hidden_field( context, "Z96FrotaProprietarioGAMGUID", StringUtil.RTrim( Z96FrotaProprietarioGAMGUID));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vFROTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FrotaId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFROTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FrotaId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Objectcall", StringUtil.RTrim( Dvpanel_veiculos_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Enabled", StringUtil.BoolToStr( Dvpanel_veiculos_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Width", StringUtil.RTrim( Dvpanel_veiculos_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Autowidth", StringUtil.BoolToStr( Dvpanel_veiculos_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Autoheight", StringUtil.BoolToStr( Dvpanel_veiculos_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Cls", StringUtil.RTrim( Dvpanel_veiculos_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Title", StringUtil.RTrim( Dvpanel_veiculos_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Collapsible", StringUtil.BoolToStr( Dvpanel_veiculos_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Collapsed", StringUtil.BoolToStr( Dvpanel_veiculos_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_veiculos_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Iconposition", StringUtil.RTrim( Dvpanel_veiculos_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_VEICULOS_Autoscroll", StringUtil.BoolToStr( Dvpanel_veiculos_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
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
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
         if ( ! ( WebComp_Wcassociationfrotaveiculo == null ) )
         {
            WebComp_Wcassociationfrotaveiculo.componentjscripts();
         }
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
               {
                  WebComp_Wcassociationfrotaveiculo.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
               {
                  WebComp_Wcassociationfrotaveiculo.componentstart();
               }
            }
         }
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("frota.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7FrotaId,8,0))}, new string[] {"Gx_mode","FrotaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Frota" ;
      }

      public override string GetPgmdesc( )
      {
         return "Frota" ;
      }

      protected void InitializeNonKey0E15( )
      {
         A95FrotaNome = "";
         AssignAttri("", false, "A95FrotaNome", A95FrotaNome);
         A94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "A94FrotaDataHoraCriacao", context.localUtil.TToC( A94FrotaDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
         A96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
         Z94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z95FrotaNome = "";
         Z96FrotaProprietarioGAMGUID = "";
      }

      protected void InitAll0E15( )
      {
         A93FrotaId = 0;
         AssignAttri("", false, "A93FrotaId", StringUtil.LTrimStr( (decimal)(A93FrotaId), 8, 0));
         InitializeNonKey0E15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A94FrotaDataHoraCriacao = i94FrotaDataHoraCriacao;
         AssignAttri("", false, "A94FrotaDataHoraCriacao", context.localUtil.TToC( A94FrotaDataHoraCriacao, 8, 5, 0, 3, "/", ":", " "));
         A96FrotaProprietarioGAMGUID = i96FrotaProprietarioGAMGUID;
         AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcassociationfrotaveiculo == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcassociationfrotaveiculo_Component) != 0 )
            {
               WebComp_Wcassociationfrotaveiculo.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202142815485983", true, true);
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
         context.AddJavascriptSource("frota.js", "?202142815485983", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtFrotaId_Internalname = "FROTAID";
         edtFrotaDataHoraCriacao_Internalname = "FROTADATAHORACRIACAO";
         edtFrotaNome_Internalname = "FROTANOME";
         edtFrotaProprietarioGAMGUID_Internalname = "FROTAPROPRIETARIOGAMGUID";
         divVeiculos_Internalname = "VEICULOS";
         Dvpanel_veiculos_Internalname = "DVPANEL_VEICULOS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Frota";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Dvpanel_veiculos_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_veiculos_Iconposition = "Right";
         Dvpanel_veiculos_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_veiculos_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_veiculos_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_veiculos_Title = "Veículos";
         Dvpanel_veiculos_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_veiculos_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_veiculos_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_veiculos_Width = "100%";
         edtFrotaProprietarioGAMGUID_Jsonclick = "";
         edtFrotaProprietarioGAMGUID_Enabled = 0;
         edtFrotaNome_Jsonclick = "";
         edtFrotaNome_Enabled = 1;
         edtFrotaDataHoraCriacao_Jsonclick = "";
         edtFrotaDataHoraCriacao_Enabled = 0;
         edtFrotaId_Jsonclick = "";
         edtFrotaId_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX6ASAFROTAPROPRIETARIOGAMGUID0E15( short Gx_BScreen ,
                                                         string Gx_mode )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A96FrotaProprietarioGAMGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A96FrotaProprietarioGAMGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A96FrotaProprietarioGAMGUID = GXt_char1;
            AssignAttri("", false, "A96FrotaProprietarioGAMGUID", A96FrotaProprietarioGAMGUID);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A96FrotaProprietarioGAMGUID))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_8_0E15( string Gx_mode ,
                                int A93FrotaId )
      {
         if ( IsIns( )  || IsUpd( )  )
         {
            new atualizarfrotaveiculo(context ).execute(  A93FrotaId) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7FrotaId',fld:'vFROTAID',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FrotaId',fld:'vFROTAID',pic:'ZZZZZZZ9',hsh:true},{av:'A93FrotaId',fld:'FROTAID',pic:'ZZZZZZZ9'},{av:'A94FrotaDataHoraCriacao',fld:'FROTADATAHORACRIACAO',pic:'99/99/99 99:99'},{av:'A96FrotaProprietarioGAMGUID',fld:'FROTAPROPRIETARIOGAMGUID',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120E2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_FROTAID","{handler:'Valid_Frotaid',iparms:[]");
         setEventMetadata("VALID_FROTAID",",oparms:[]}");
         setEventMetadata("VALID_FROTANOME","{handler:'Valid_Frotanome',iparms:[]");
         setEventMetadata("VALID_FROTANOME",",oparms:[]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z95FrotaNome = "";
         Z96FrotaProprietarioGAMGUID = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         TempTags = "";
         A95FrotaNome = "";
         A96FrotaProprietarioGAMGUID = "";
         ucDvpanel_veiculos = new GXUserControl();
         WebComp_Wcassociationfrotaveiculo_Component = "";
         OldWcassociationfrotaveiculo = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_veiculos_Objectcall = "";
         Dvpanel_veiculos_Class = "";
         Dvpanel_veiculos_Height = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000E4_A93FrotaId = new int[1] ;
         T000E4_A94FrotaDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         T000E4_A95FrotaNome = new string[] {""} ;
         T000E4_A96FrotaProprietarioGAMGUID = new string[] {""} ;
         T000E5_A93FrotaId = new int[1] ;
         T000E3_A93FrotaId = new int[1] ;
         T000E3_A94FrotaDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         T000E3_A95FrotaNome = new string[] {""} ;
         T000E3_A96FrotaProprietarioGAMGUID = new string[] {""} ;
         T000E6_A93FrotaId = new int[1] ;
         T000E7_A93FrotaId = new int[1] ;
         T000E2_A93FrotaId = new int[1] ;
         T000E2_A94FrotaDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         T000E2_A95FrotaNome = new string[] {""} ;
         T000E2_A96FrotaProprietarioGAMGUID = new string[] {""} ;
         T000E8_A93FrotaId = new int[1] ;
         T000E11_A93FrotaId = new int[1] ;
         T000E11_A98VeiculoId = new int[1] ;
         T000E12_A93FrotaId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         i96FrotaProprietarioGAMGUID = "";
         GXt_char1 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.frota__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frota__default(),
            new Object[][] {
                new Object[] {
               T000E2_A93FrotaId, T000E2_A94FrotaDataHoraCriacao, T000E2_A95FrotaNome, T000E2_A96FrotaProprietarioGAMGUID
               }
               , new Object[] {
               T000E3_A93FrotaId, T000E3_A94FrotaDataHoraCriacao, T000E3_A95FrotaNome, T000E3_A96FrotaProprietarioGAMGUID
               }
               , new Object[] {
               T000E4_A93FrotaId, T000E4_A94FrotaDataHoraCriacao, T000E4_A95FrotaNome, T000E4_A96FrotaProprietarioGAMGUID
               }
               , new Object[] {
               T000E5_A93FrotaId
               }
               , new Object[] {
               T000E6_A93FrotaId
               }
               , new Object[] {
               T000E7_A93FrotaId
               }
               , new Object[] {
               T000E8_A93FrotaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E11_A93FrotaId, T000E11_A98VeiculoId
               }
               , new Object[] {
               T000E12_A93FrotaId
               }
            }
         );
         WebComp_Wcassociationfrotaveiculo = new GeneXus.Http.GXNullWebComponent();
         Z96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         A96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         i96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         A94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         i94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
      }

      private short GxWebError ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound15 ;
      private short nCmpId ;
      private short GX_JID ;
      private short nIsDirty_15 ;
      private short gxajaxcallmode ;
      private int wcpOAV7FrotaId ;
      private int Z93FrotaId ;
      private int A93FrotaId ;
      private int AV7FrotaId ;
      private int trnEnded ;
      private int edtFrotaId_Enabled ;
      private int edtFrotaDataHoraCriacao_Enabled ;
      private int edtFrotaNome_Enabled ;
      private int edtFrotaProprietarioGAMGUID_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_veiculos_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z96FrotaProprietarioGAMGUID ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFrotaNome_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtFrotaId_Internalname ;
      private string edtFrotaId_Jsonclick ;
      private string edtFrotaDataHoraCriacao_Internalname ;
      private string edtFrotaDataHoraCriacao_Jsonclick ;
      private string TempTags ;
      private string edtFrotaNome_Jsonclick ;
      private string edtFrotaProprietarioGAMGUID_Internalname ;
      private string A96FrotaProprietarioGAMGUID ;
      private string edtFrotaProprietarioGAMGUID_Jsonclick ;
      private string Dvpanel_veiculos_Width ;
      private string Dvpanel_veiculos_Cls ;
      private string Dvpanel_veiculos_Title ;
      private string Dvpanel_veiculos_Iconposition ;
      private string Dvpanel_veiculos_Internalname ;
      private string divVeiculos_Internalname ;
      private string WebComp_Wcassociationfrotaveiculo_Component ;
      private string OldWcassociationfrotaveiculo ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Dvpanel_veiculos_Objectcall ;
      private string Dvpanel_veiculos_Class ;
      private string Dvpanel_veiculos_Height ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode15 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i96FrotaProprietarioGAMGUID ;
      private string GXt_char1 ;
      private DateTime Z94FrotaDataHoraCriacao ;
      private DateTime A94FrotaDataHoraCriacao ;
      private DateTime i94FrotaDataHoraCriacao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_veiculos_Autowidth ;
      private bool Dvpanel_veiculos_Autoheight ;
      private bool Dvpanel_veiculos_Collapsible ;
      private bool Dvpanel_veiculos_Collapsed ;
      private bool Dvpanel_veiculos_Showcollapseicon ;
      private bool Dvpanel_veiculos_Autoscroll ;
      private bool Dvpanel_veiculos_Enabled ;
      private bool Dvpanel_veiculos_Showheader ;
      private bool Dvpanel_veiculos_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool bDynCreated_Wcassociationfrotaveiculo ;
      private string Z95FrotaNome ;
      private string A95FrotaNome ;
      private IGxSession AV12WebSession ;
      private GXWebComponent WebComp_Wcassociationfrotaveiculo ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_veiculos ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000E4_A93FrotaId ;
      private DateTime[] T000E4_A94FrotaDataHoraCriacao ;
      private string[] T000E4_A95FrotaNome ;
      private string[] T000E4_A96FrotaProprietarioGAMGUID ;
      private int[] T000E5_A93FrotaId ;
      private int[] T000E3_A93FrotaId ;
      private DateTime[] T000E3_A94FrotaDataHoraCriacao ;
      private string[] T000E3_A95FrotaNome ;
      private string[] T000E3_A96FrotaProprietarioGAMGUID ;
      private int[] T000E6_A93FrotaId ;
      private int[] T000E7_A93FrotaId ;
      private int[] T000E2_A93FrotaId ;
      private DateTime[] T000E2_A94FrotaDataHoraCriacao ;
      private string[] T000E2_A95FrotaNome ;
      private string[] T000E2_A96FrotaProprietarioGAMGUID ;
      private int[] T000E8_A93FrotaId ;
      private int[] T000E11_A93FrotaId ;
      private int[] T000E11_A98VeiculoId ;
      private int[] T000E12_A93FrotaId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class frota__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class frota__default : DataStoreHelperBase, IDataStoreHelper
 {
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000E4;
        prmT000E4 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E5;
        prmT000E5 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E3;
        prmT000E3 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E6;
        prmT000E6 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E7;
        prmT000E7 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E2;
        prmT000E2 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E8;
        prmT000E8 = new Object[] {
        new Object[] {"@FrotaDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@FrotaNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@FrotaProprietarioGAMGUID",SqlDbType.NChar,40,0}
        };
        Object[] prmT000E9;
        prmT000E9 = new Object[] {
        new Object[] {"@FrotaDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@FrotaNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@FrotaProprietarioGAMGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E10;
        prmT000E10 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E11;
        prmT000E11 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmT000E12;
        prmT000E12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000E2", "SELECT [FrotaId], [FrotaDataHoraCriacao], [FrotaNome], [FrotaProprietarioGAMGUID] FROM [Frota] WITH (UPDLOCK) WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E3", "SELECT [FrotaId], [FrotaDataHoraCriacao], [FrotaNome], [FrotaProprietarioGAMGUID] FROM [Frota] WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E4", "SELECT TM1.[FrotaId], TM1.[FrotaDataHoraCriacao], TM1.[FrotaNome], TM1.[FrotaProprietarioGAMGUID] FROM [Frota] TM1 WHERE TM1.[FrotaId] = @FrotaId ORDER BY TM1.[FrotaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E5", "SELECT [FrotaId] FROM [Frota] WHERE [FrotaId] = @FrotaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E6", "SELECT TOP 1 [FrotaId] FROM [Frota] WHERE ( [FrotaId] > @FrotaId) ORDER BY [FrotaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E7", "SELECT TOP 1 [FrotaId] FROM [Frota] WHERE ( [FrotaId] < @FrotaId) ORDER BY [FrotaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E8", "INSERT INTO [Frota]([FrotaDataHoraCriacao], [FrotaNome], [FrotaProprietarioGAMGUID]) VALUES(@FrotaDataHoraCriacao, @FrotaNome, @FrotaProprietarioGAMGUID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000E8)
           ,new CursorDef("T000E9", "UPDATE [Frota] SET [FrotaDataHoraCriacao]=@FrotaDataHoraCriacao, [FrotaNome]=@FrotaNome, [FrotaProprietarioGAMGUID]=@FrotaProprietarioGAMGUID  WHERE [FrotaId] = @FrotaId", GxErrorMask.GX_NOMASK,prmT000E9)
           ,new CursorDef("T000E10", "DELETE FROM [Frota]  WHERE [FrotaId] = @FrotaId", GxErrorMask.GX_NOMASK,prmT000E10)
           ,new CursorDef("T000E11", "SELECT TOP 1 [FrotaId], [VeiculoId] FROM [FrotaVeiculo] WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E12", "SELECT [FrotaId] FROM [Frota] ORDER BY [FrotaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E12,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              return;
           case 6 :
              table[0][0] = rslt.getInt(1);
              return;
           case 9 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 10 :
              table[0][0] = rslt.getInt(1);
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
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 2 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 6 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              return;
           case 7 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 9 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
