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
   public class subscrevertopicomqtt : GXProcedure
   {
      public subscrevertopicomqtt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public subscrevertopicomqtt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( Guid aP0_MqttConnectionGUID ,
                           string aP1_Topic ,
                           string aP2_PRCRetorno ,
                           out bool aP3_OcorreuErro )
      {
         this.AV8MqttConnectionGUID = aP0_MqttConnectionGUID;
         this.AV9Topic = aP1_Topic;
         this.AV10PRCRetorno = aP2_PRCRetorno;
         this.AV11OcorreuErro = false ;
         initialize();
         executePrivate();
         aP3_OcorreuErro=this.AV11OcorreuErro;
      }

      public bool executeUdp( Guid aP0_MqttConnectionGUID ,
                              string aP1_Topic ,
                              string aP2_PRCRetorno )
      {
         execute(aP0_MqttConnectionGUID, aP1_Topic, aP2_PRCRetorno, out aP3_OcorreuErro);
         return AV11OcorreuErro ;
      }

      public void executeSubmit( Guid aP0_MqttConnectionGUID ,
                                 string aP1_Topic ,
                                 string aP2_PRCRetorno ,
                                 out bool aP3_OcorreuErro )
      {
         subscrevertopicomqtt objsubscrevertopicomqtt;
         objsubscrevertopicomqtt = new subscrevertopicomqtt();
         objsubscrevertopicomqtt.AV8MqttConnectionGUID = aP0_MqttConnectionGUID;
         objsubscrevertopicomqtt.AV9Topic = aP1_Topic;
         objsubscrevertopicomqtt.AV10PRCRetorno = aP2_PRCRetorno;
         objsubscrevertopicomqtt.AV11OcorreuErro = false ;
         objsubscrevertopicomqtt.context.SetSubmitInitialConfig(context);
         objsubscrevertopicomqtt.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsubscrevertopicomqtt);
         aP3_OcorreuErro=this.AV11OcorreuErro;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((subscrevertopicomqtt)stateInfo).executePrivate();
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
         AV12MqttStatus = new SdtMQTT(context).subscribe(AV8MqttConnectionGUID, AV9Topic, AV10PRCRetorno, 1);
         if ( AV12MqttStatus.gxTpr_Error )
         {
            new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Trim( AV12MqttStatus.gxTpr_Errormessage), AV15Pgmname) ;
            AV11OcorreuErro = true;
         }
         else
         {
            AV11OcorreuErro = false;
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
         AV12MqttStatus = new SdtMqttStatus(context);
         AV15Pgmname = "";
         AV15Pgmname = "SubscreverTopicoMQTT";
         /* GeneXus formulas. */
         AV15Pgmname = "SubscreverTopicoMQTT";
         context.Gx_err = 0;
      }

      private string AV15Pgmname ;
      private bool AV11OcorreuErro ;
      private string AV9Topic ;
      private string AV10PRCRetorno ;
      private Guid AV8MqttConnectionGUID ;
      private bool aP3_OcorreuErro ;
      private SdtMqttStatus AV12MqttStatus ;
   }

}
