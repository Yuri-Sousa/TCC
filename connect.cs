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
   public class connect : GXProcedure
   {
      public connect( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public connect( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_URL ,
                           SdtMqttConfig aP1_MqttConfig ,
                           out SdtMqttStatus aP2_MqttStatus )
      {
         this.AV9URL = aP0_URL;
         this.AV10MqttConfig = aP1_MqttConfig;
         this.AV8MqttStatus = new SdtMqttStatus(context) ;
         initialize();
         executePrivate();
         aP2_MqttStatus=this.AV8MqttStatus;
      }

      public SdtMqttStatus executeUdp( string aP0_URL ,
                                       SdtMqttConfig aP1_MqttConfig )
      {
         execute(aP0_URL, aP1_MqttConfig, out aP2_MqttStatus);
         return AV8MqttStatus ;
      }

      public void executeSubmit( string aP0_URL ,
                                 SdtMqttConfig aP1_MqttConfig ,
                                 out SdtMqttStatus aP2_MqttStatus )
      {
         connect objconnect;
         objconnect = new connect();
         objconnect.AV9URL = aP0_URL;
         objconnect.AV10MqttConfig = aP1_MqttConfig;
         objconnect.AV8MqttStatus = new SdtMqttStatus(context) ;
         objconnect.context.SetSubmitInitialConfig(context);
         objconnect.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconnect);
         aP2_MqttStatus=this.AV8MqttStatus;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((connect)stateInfo).executePrivate();
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
         AV8MqttStatus = new SdtMQTT(context).connect(AV9URL, AV10MqttConfig);
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
         AV8MqttStatus = new SdtMqttStatus(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9URL ;
      private SdtMqttStatus aP2_MqttStatus ;
      private SdtMqttConfig AV10MqttConfig ;
      private SdtMqttStatus AV8MqttStatus ;
   }

}
