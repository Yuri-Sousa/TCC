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
   public class asalvarultimodadolidodistribui : GXProcedure
   {
      public asalvarultimodadolidodistribui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public asalvarultimodadolidodistribui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_topic ,
                           string aP1_message ,
                           DateTime aP2_messagetimestamp )
      {
         this.AV10topic = aP0_topic;
         this.AV9message = aP1_message;
         this.AV8messagetimestamp = aP2_messagetimestamp;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_topic ,
                                 string aP1_message ,
                                 DateTime aP2_messagetimestamp )
      {
         asalvarultimodadolidodistribui objasalvarultimodadolidodistribui;
         objasalvarultimodadolidodistribui = new asalvarultimodadolidodistribui();
         objasalvarultimodadolidodistribui.AV10topic = aP0_topic;
         objasalvarultimodadolidodistribui.AV9message = aP1_message;
         objasalvarultimodadolidodistribui.AV8messagetimestamp = aP2_messagetimestamp;
         objasalvarultimodadolidodistribui.context.SetSubmitInitialConfig(context);
         objasalvarultimodadolidodistribui.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objasalvarultimodadolidodistribui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((asalvarultimodadolidodistribui)stateInfo).executePrivate();
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
         new salvarultimodadolido(context).executeSubmit(  AV10topic,  AV9message,  AV8messagetimestamp) ;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private DateTime AV8messagetimestamp ;
      private string AV10topic ;
      private string AV9message ;
   }

}
