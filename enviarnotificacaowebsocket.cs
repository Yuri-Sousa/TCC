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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class enviarnotificacaowebsocket : GXProcedure
   {
      public enviarnotificacaowebsocket( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public enviarnotificacaowebsocket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( SdtSDTNovaPosicao aP0_SDTNovaPosicao )
      {
         this.AV16SDTNovaPosicao = aP0_SDTNovaPosicao;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtSDTNovaPosicao aP0_SDTNovaPosicao )
      {
         enviarnotificacaowebsocket objenviarnotificacaowebsocket;
         objenviarnotificacaowebsocket = new enviarnotificacaowebsocket();
         objenviarnotificacaowebsocket.AV16SDTNovaPosicao = aP0_SDTNovaPosicao;
         objenviarnotificacaowebsocket.context.SetSubmitInitialConfig(context);
         objenviarnotificacaowebsocket.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objenviarnotificacaowebsocket);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((enviarnotificacaowebsocket)stateInfo).executePrivate();
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
         AV13WebNotification = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV13WebNotification.gxTpr_Id = "NovaPosicaoMQTT";
         AV13WebNotification.gxTpr_Object = "Mapa";
         AV13WebNotification.gxTpr_Message = AV16SDTNovaPosicao.ToJSonString(false, true);
         AV14Socket.broadcast( AV13WebNotification);
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
         AV13WebNotification = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV14Socket = new GeneXus.Core.genexus.server.SdtSocket(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GeneXus.Core.genexus.server.SdtNotificationInfo AV13WebNotification ;
      private GeneXus.Core.genexus.server.SdtSocket AV14Socket ;
      private SdtSDTNovaPosicao AV16SDTNovaPosicao ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.enviarnotificacaowebsocket_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class enviarnotificacaowebsocket_services : GxRestService
   {
      [OperationContract(Name = "EnviarNotificacaoWebSocket" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( SdtSDTNovaPosicao_RESTInterface SDTNovaPosicao )
      {
         try
         {
            if ( ! ProcessHeaders("enviarnotificacaowebsocket") )
            {
               return  ;
            }
            enviarnotificacaowebsocket worker = new enviarnotificacaowebsocket(context);
            worker.IsMain = RunAsMain ;
            SdtSDTNovaPosicao gxrSDTNovaPosicao = SDTNovaPosicao.sdt;
            worker.execute(gxrSDTNovaPosicao );
            worker.cleanup( );
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}
