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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_cleannotificationurl : GXProcedure
   {
      public wwp_cleannotificationurl( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_cleannotificationurl( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( ref string aP0_Url )
      {
         this.AV8Url = aP0_Url;
         initialize();
         executePrivate();
         aP0_Url=this.AV8Url;
      }

      public string executeUdp( )
      {
         execute(ref aP0_Url);
         return AV8Url ;
      }

      public void executeSubmit( ref string aP0_Url )
      {
         wwp_cleannotificationurl objwwp_cleannotificationurl;
         objwwp_cleannotificationurl = new wwp_cleannotificationurl();
         objwwp_cleannotificationurl.AV8Url = aP0_Url;
         objwwp_cleannotificationurl.context.SetSubmitInitialConfig(context);
         objwwp_cleannotificationurl.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_cleannotificationurl);
         aP0_Url=this.AV8Url;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_cleannotificationurl)stateInfo).executePrivate();
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
         AV8Url = StringUtil.Substring( AV8Url, StringUtil.StringSearchRev( AV8Url, "/", -1)+1, -1);
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

      private string AV8Url ;
      private string aP0_Url ;
   }

}
