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
   public class verificaradministrador : GXProcedure
   {
      public verificaradministrador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public verificaradministrador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out bool aP0_IsAdministrator )
      {
         this.AV8IsAdministrator = false ;
         initialize();
         executePrivate();
         aP0_IsAdministrator=this.AV8IsAdministrator;
      }

      public bool executeUdp( )
      {
         execute(out aP0_IsAdministrator);
         return AV8IsAdministrator ;
      }

      public void executeSubmit( out bool aP0_IsAdministrator )
      {
         verificaradministrador objverificaradministrador;
         objverificaradministrador = new verificaradministrador();
         objverificaradministrador.AV8IsAdministrator = false ;
         objverificaradministrador.context.SetSubmitInitialConfig(context);
         objverificaradministrador.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objverificaradministrador);
         aP0_IsAdministrator=this.AV8IsAdministrator;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((verificaradministrador)stateInfo).executePrivate();
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
         AV8IsAdministrator = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).checkrole("Administrator");
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

      private bool AV8IsAdministrator ;
      private bool aP0_IsAdministrator ;
   }

}
