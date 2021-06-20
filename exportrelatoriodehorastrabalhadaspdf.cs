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
   public class exportrelatoriodehorastrabalhadaspdf : GXProcedure
   {
      public exportrelatoriodehorastrabalhadaspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public exportrelatoriodehorastrabalhadaspdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_ClientId )
      {
         this.AV2ClientId = aP0_ClientId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId )
      {
         exportrelatoriodehorastrabalhadaspdf objexportrelatoriodehorastrabalhadaspdf;
         objexportrelatoriodehorastrabalhadaspdf = new exportrelatoriodehorastrabalhadaspdf();
         objexportrelatoriodehorastrabalhadaspdf.AV2ClientId = aP0_ClientId;
         objexportrelatoriodehorastrabalhadaspdf.context.SetSubmitInitialConfig(context);
         objexportrelatoriodehorastrabalhadaspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportrelatoriodehorastrabalhadaspdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportrelatoriodehorastrabalhadaspdf)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2ClientId} ;
         ClassLoader.Execute("aexportrelatoriodehorastrabalhadaspdf","GeneXus.Programs","aexportrelatoriodehorastrabalhadaspdf", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
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

      private string AV2ClientId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
