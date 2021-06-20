using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuoptionsdata : GXProcedure
   {
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
            return "" ;
         }

      }

      public menuoptionsdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuoptionsdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "RastreamentoTCC") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         menuoptionsdata objmenuoptionsdata;
         objmenuoptionsdata = new menuoptionsdata();
         objmenuoptionsdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "RastreamentoTCC") ;
         objmenuoptionsdata.context.SetSubmitInitialConfig(context);
         objmenuoptionsdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmenuoptionsdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuoptionsdata)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV5id = 0;
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("homeiot.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-home";
         Gxm1dvelop_menu.gxTpr_Caption = "Home";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("mapa.aspx") ;
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-map";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Mapa";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-desktop";
         Gxm1dvelop_menu.gxTpr_Caption = "Monitoramento";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("ultimodadolidoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Último Dado Lido";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "UltimoDadoLido_execute";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("comandoenviadoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Comandos Enviados";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "ComandoEnviado_execute";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = "";
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Relatórios";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("relatorioposicao.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Posição";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "RelatorioPosicao_execute";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("relatoriohorastrabalhadas.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Horas Trabalhadas";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "RelatorioHorasTrabalhadas_execute";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("relatorioutilizacao.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Utilização";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "RelatorioUtilizacao_execute";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-book";
         Gxm1dvelop_menu.gxTpr_Caption = "Cadastro";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("veiculoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Veículo";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "Veiculo_execute";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("frotaww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Frota";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "Frota_execute";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("rastreadorww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Rastreador";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "Rastreador_execute";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("chipgsmww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Chip GSM";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "ChipGSM_execute";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("comandoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Comando";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "Comando_execute";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fas fa-cogs";
         Gxm1dvelop_menu.gxTpr_Caption = "Configurações";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("mqttconnectionww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Conexões";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "MqttConnection_execute";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("mqttparametrosww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Parâmetros MQTT";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "MqttParametros_execute";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "Segurança de aplicativo";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-key";
         Gxm1dvelop_menu.gxTpr_Caption = "Segurança";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "Usuários";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("gamwwusers.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Usuários";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "Perfis";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("gamwwroles.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Perfis";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("gamchangeyourpassword.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Alterar sua senha";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV5id ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm3dvelop_menu_subitems ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm4dvelop_menu_subitems_subitems ;
   }

}
