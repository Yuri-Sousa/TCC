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
   public class listwwpprograms : GXProcedure
   {
      public listwwpprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listwwpprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "RastreamentoTCC") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         listwwpprograms objlistwwpprograms;
         objlistwwpprograms = new listwwpprograms();
         objlistwwpprograms.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "RastreamentoTCC") ;
         objlistwwpprograms.context.SetSubmitInitialConfig(context);
         objlistwwpprograms.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlistwwpprograms);
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listwwpprograms)stateInfo).executePrivate();
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
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "RastreamentoTCC");
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV13name = "ComandoEnviadoWW";
         AV14description = " Comando Enviado";
         AV15link = formatLink("comandoenviadoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "FrotaWW";
         AV14description = " Frota";
         AV15link = formatLink("frotaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "ChipGSMWW";
         AV14description = " Chip GSM";
         AV15link = formatLink("chipgsmww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWAuthTypes";
         AV14description = "Tipos de autenticação";
         AV15link = formatLink("gamwwauthtypes.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "ComandoWW";
         AV14description = " Comando";
         AV15link = formatLink("comandoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "VeiculoWW";
         AV14description = " Veículo";
         AV15link = formatLink("veiculoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWSecurityPolicy";
         AV14description = "Políticas de segurança";
         AV15link = formatLink("gamwwsecuritypolicy.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWConnections";
         AV14description = "Conexões";
         AV15link = formatLink("gamwwconnections.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "UltimoDadoLidoWW";
         AV14description = " Último Dado Lido";
         AV15link = formatLink("ultimodadolidoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWApplications";
         AV14description = "Aplicações";
         AV15link = formatLink("gamwwapplications.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWRepositories";
         AV14description = "Repositórios";
         AV15link = formatLink("gamwwrepositories.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         AV14description = "Visualize all notifications";
         AV15link = formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWEventSubscriptions";
         AV14description = "Subscrições a eventos";
         AV15link = formatLink("gamwweventsubscriptions.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         AV14description = "Manage my Subscriptions";
         AV15link = formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWRoles";
         AV14description = "Perfis";
         AV15link = formatLink("gamwwroles.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "MqttParametrosWW";
         AV14description = " Parâmetros Mqtt";
         AV15link = formatLink("mqttparametrosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWUsers";
         AV14description = "Usuários";
         AV15link = formatLink("gamwwusers.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "RastreadorWW";
         AV14description = " Rastreador";
         AV15link = formatLink("rastreadorww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "MqttConnectionWW";
         AV14description = " Lista de Conexões MQTT";
         AV15link = formatLink("mqttconnectionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         AV8IsAuthorized = true;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV13name;
            AV10ProgramName.gxTpr_Description = AV14description;
            AV10ProgramName.gxTpr_Link = AV15link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
         }
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
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "RastreamentoTCC");
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13name = "";
         AV14description = "";
         AV15link = "";
         AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private string AV13name ;
      private string AV14description ;
      private string AV15link ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> AV9ProgramNames ;
      private GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName AV10ProgramName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
   }

}
