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
   public class wwp_getuseremail : GXProcedure
   {
      public wwp_getuseremail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getuseremail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out string aP1_WWPUserExtendedEmail )
      {
         this.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV11WWPUserExtendedEmail = "" ;
         initialize();
         executePrivate();
         aP1_WWPUserExtendedEmail=this.AV11WWPUserExtendedEmail;
      }

      public string executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_WWPUserExtendedEmail);
         return AV11WWPUserExtendedEmail ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out string aP1_WWPUserExtendedEmail )
      {
         wwp_getuseremail objwwp_getuseremail;
         objwwp_getuseremail = new wwp_getuseremail();
         objwwp_getuseremail.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         objwwp_getuseremail.AV11WWPUserExtendedEmail = "" ;
         objwwp_getuseremail.context.SetSubmitInitialConfig(context);
         objwwp_getuseremail.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getuseremail);
         aP1_WWPUserExtendedEmail=this.AV11WWPUserExtendedEmail;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getuseremail)stateInfo).executePrivate();
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
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbyguid(AV9WWPUserExtendedId, out  AV8GAMErrorCollection);
         AV11WWPUserExtendedEmail = AV10GAMUser.gxTpr_Email;
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
         AV11WWPUserExtendedEmail = "";
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9WWPUserExtendedId ;
      private string AV11WWPUserExtendedEmail ;
      private string aP1_WWPUserExtendedEmail ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
   }

}
