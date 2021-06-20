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
   public class wwpgetrolename : GXProcedure
   {
      public wwpgetrolename( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwpgetrolename( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPSubscriptionRoleId ,
                           out string aP1_RoleName )
      {
         this.AV8WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV9RoleName = "" ;
         initialize();
         executePrivate();
         aP1_RoleName=this.AV9RoleName;
      }

      public string executeUdp( string aP0_WWPSubscriptionRoleId )
      {
         execute(aP0_WWPSubscriptionRoleId, out aP1_RoleName);
         return AV9RoleName ;
      }

      public void executeSubmit( string aP0_WWPSubscriptionRoleId ,
                                 out string aP1_RoleName )
      {
         wwpgetrolename objwwpgetrolename;
         objwwpgetrolename = new wwpgetrolename();
         objwwpgetrolename.AV8WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         objwwpgetrolename.AV9RoleName = "" ;
         objwwpgetrolename.context.SetSubmitInitialConfig(context);
         objwwpgetrolename.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwpgetrolename);
         aP1_RoleName=this.AV9RoleName;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwpgetrolename)stateInfo).executePrivate();
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
         AV11GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context).getbyguid(AV8WWPSubscriptionRoleId, out  AV10GAMErrorCollection);
         AV9RoleName = AV11GAMRole.gxTpr_Name;
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
         AV9RoleName = "";
         AV11GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8WWPSubscriptionRoleId ;
      private string AV9RoleName ;
      private string aP1_RoleName ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV11GAMRole ;
   }

}
