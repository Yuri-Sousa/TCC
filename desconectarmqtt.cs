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
namespace GeneXus.Programs {
   public class desconectarmqtt : GXProcedure
   {
      public desconectarmqtt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public desconectarmqtt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out bool aP0_IsSucessoDesconexao )
      {
         this.AV12IsSucessoDesconexao = false ;
         initialize();
         executePrivate();
         aP0_IsSucessoDesconexao=this.AV12IsSucessoDesconexao;
      }

      public bool executeUdp( )
      {
         execute(out aP0_IsSucessoDesconexao);
         return AV12IsSucessoDesconexao ;
      }

      public void executeSubmit( out bool aP0_IsSucessoDesconexao )
      {
         desconectarmqtt objdesconectarmqtt;
         objdesconectarmqtt = new desconectarmqtt();
         objdesconectarmqtt.AV12IsSucessoDesconexao = false ;
         objdesconectarmqtt.context.SetSubmitInitialConfig(context);
         objdesconectarmqtt.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdesconectarmqtt);
         aP0_IsSucessoDesconexao=this.AV12IsSucessoDesconexao;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((desconectarmqtt)stateInfo).executePrivate();
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
         GXt_guid1 = (Guid)(AV13MqttConnectionGUID);
         new buscarguidconexaomqtt(context ).execute( out  GXt_guid1) ;
         AV13MqttConnectionGUID = (Guid)((Guid)(GXt_guid1));
         AV8MQTTStatus = new SdtMQTT(context).isconnected(AV13MqttConnectionGUID, out  AV14IsConnected);
         if ( AV14IsConnected )
         {
            AV8MQTTStatus = new SdtMQTT(context).disconnect(AV13MqttConnectionGUID);
            if ( ! AV8MQTTStatus.gxTpr_Error )
            {
               AV12IsSucessoDesconexao = true;
            }
            else
            {
               AV12IsSucessoDesconexao = false;
            }
         }
         else
         {
            AV12IsSucessoDesconexao = true;
         }
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
         AV13MqttConnectionGUID = (Guid)(Guid.Empty);
         GXt_guid1 = (Guid)(Guid.Empty);
         AV8MQTTStatus = new SdtMqttStatus(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV12IsSucessoDesconexao ;
      private bool AV14IsConnected ;
      private Guid AV13MqttConnectionGUID ;
      private Guid GXt_guid1 ;
      private bool aP0_IsSucessoDesconexao ;
      private SdtMqttStatus AV8MQTTStatus ;
   }

}
