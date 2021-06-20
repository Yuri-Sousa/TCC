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
   public class savemanagefiltersstate : GXProcedure
   {
      public savemanagefiltersstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public savemanagefiltersstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_UserCustomKey ,
                           string aP1_UserCustomValue )
      {
         this.AV9UserCustomKey = aP0_UserCustomKey;
         this.AV10UserCustomValue = aP1_UserCustomValue;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_UserCustomKey ,
                                 string aP1_UserCustomValue )
      {
         savemanagefiltersstate objsavemanagefiltersstate;
         objsavemanagefiltersstate = new savemanagefiltersstate();
         objsavemanagefiltersstate.AV9UserCustomKey = aP0_UserCustomKey;
         objsavemanagefiltersstate.AV10UserCustomValue = aP1_UserCustomValue;
         objsavemanagefiltersstate.context.SetSubmitInitialConfig(context);
         objsavemanagefiltersstate.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsavemanagefiltersstate);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((savemanagefiltersstate)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  AV9UserCustomKey,  AV10UserCustomValue) ;
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

      private string AV9UserCustomKey ;
      private string AV10UserCustomValue ;
   }

}
