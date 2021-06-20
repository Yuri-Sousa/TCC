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
   public class wwp_getloggeduserid : GXProcedure
   {
      public wwp_getloggeduserid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getloggeduserid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out string aP0_WWPUserExtendedId )
      {
         this.AV8WWPUserExtendedId = "" ;
         initialize();
         executePrivate();
         aP0_WWPUserExtendedId=this.AV8WWPUserExtendedId;
      }

      public string executeUdp( )
      {
         execute(out aP0_WWPUserExtendedId);
         return AV8WWPUserExtendedId ;
      }

      public void executeSubmit( out string aP0_WWPUserExtendedId )
      {
         wwp_getloggeduserid objwwp_getloggeduserid;
         objwwp_getloggeduserid = new wwp_getloggeduserid();
         objwwp_getloggeduserid.AV8WWPUserExtendedId = "" ;
         objwwp_getloggeduserid.context.SetSubmitInitialConfig(context);
         objwwp_getloggeduserid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getloggeduserid);
         aP0_WWPUserExtendedId=this.AV8WWPUserExtendedId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getloggeduserid)stateInfo).executePrivate();
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
         AV8WWPUserExtendedId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
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
         AV8WWPUserExtendedId = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8WWPUserExtendedId ;
      private string aP0_WWPUserExtendedId ;
   }

}
