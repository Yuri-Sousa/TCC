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
   public class setwwpcontext : GXProcedure
   {
      public setwwpcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public setwwpcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_Context )
      {
         this.AV8Context = aP0_Context;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.wwpbaseobjects.SdtWWPContext aP0_Context )
      {
         setwwpcontext objsetwwpcontext;
         objsetwwpcontext = new setwwpcontext();
         objsetwwpcontext.AV8Context = aP0_Context;
         objsetwwpcontext.context.SetSubmitInitialConfig(context);
         objsetwwpcontext.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsetwwpcontext);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setwwpcontext)stateInfo).executePrivate();
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
         AV9Session.Set("wwpcontext", AV8Context.ToXml(false, true, "WWPContext", "RastreamentoTCC"));
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
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxSession AV9Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8Context ;
   }

}
