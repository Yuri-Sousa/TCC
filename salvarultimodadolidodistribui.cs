using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
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
   public class salvarultimodadolidodistribui : GXProcedure
   {
      public salvarultimodadolidodistribui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public salvarultimodadolidodistribui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_topic ,
                           string aP1_message ,
                           DateTime aP2_messagetimestamp )
      {
         this.AV2topic = aP0_topic;
         this.AV3message = aP1_message;
         this.AV4messagetimestamp = aP2_messagetimestamp;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_topic ,
                                 string aP1_message ,
                                 DateTime aP2_messagetimestamp )
      {
         salvarultimodadolidodistribui objsalvarultimodadolidodistribui;
         objsalvarultimodadolidodistribui = new salvarultimodadolidodistribui();
         objsalvarultimodadolidodistribui.AV2topic = aP0_topic;
         objsalvarultimodadolidodistribui.AV3message = aP1_message;
         objsalvarultimodadolidodistribui.AV4messagetimestamp = aP2_messagetimestamp;
         objsalvarultimodadolidodistribui.context.SetSubmitInitialConfig(context);
         objsalvarultimodadolidodistribui.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsalvarultimodadolidodistribui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((salvarultimodadolidodistribui)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2topic,(string)AV3message,(DateTime)AV4messagetimestamp} ;
         ClassLoader.Execute("asalvarultimodadolidodistribui","GeneXus.Programs","asalvarultimodadolidodistribui", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private DateTime AV4messagetimestamp ;
      private string AV2topic ;
      private string AV3message ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
