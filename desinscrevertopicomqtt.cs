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
   public class desinscrevertopicomqtt : GXProcedure
   {
      public desinscrevertopicomqtt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public desinscrevertopicomqtt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( Guid aP0_MqttConnectionGUID ,
                           string aP1_Topic )
      {
         this.AV8MqttConnectionGUID = aP0_MqttConnectionGUID;
         this.AV12Topic = aP1_Topic;
         initialize();
         executePrivate();
      }

      public void executeSubmit( Guid aP0_MqttConnectionGUID ,
                                 string aP1_Topic )
      {
         desinscrevertopicomqtt objdesinscrevertopicomqtt;
         objdesinscrevertopicomqtt = new desinscrevertopicomqtt();
         objdesinscrevertopicomqtt.AV8MqttConnectionGUID = aP0_MqttConnectionGUID;
         objdesinscrevertopicomqtt.AV12Topic = aP1_Topic;
         objdesinscrevertopicomqtt.context.SetSubmitInitialConfig(context);
         objdesinscrevertopicomqtt.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdesinscrevertopicomqtt);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((desinscrevertopicomqtt)stateInfo).executePrivate();
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
         AV9MqttStatus = new SdtMQTT(context).unsubscribe(AV8MqttConnectionGUID, AV12Topic);
         if ( AV9MqttStatus.gxTpr_Error )
         {
            new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Trim( AV9MqttStatus.gxTpr_Errormessage), AV15Pgmname) ;
            AV10OcorreuErro = true;
         }
         else
         {
            AV10OcorreuErro = false;
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
         AV9MqttStatus = new SdtMqttStatus(context);
         AV15Pgmname = "";
         AV15Pgmname = "DesinscreverTopicoMQTT";
         /* GeneXus formulas. */
         AV15Pgmname = "DesinscreverTopicoMQTT";
         context.Gx_err = 0;
      }

      private string AV15Pgmname ;
      private bool AV10OcorreuErro ;
      private string AV12Topic ;
      private Guid AV8MqttConnectionGUID ;
      private SdtMqttStatus AV9MqttStatus ;
   }

}
