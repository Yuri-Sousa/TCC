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
   public class wwp_getuserphone : GXProcedure
   {
      public wwp_getuserphone( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getuserphone( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out string aP1_WWPUserExtendedPhone )
      {
         this.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV11WWPUserExtendedPhone = "" ;
         initialize();
         executePrivate();
         aP1_WWPUserExtendedPhone=this.AV11WWPUserExtendedPhone;
      }

      public string executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_WWPUserExtendedPhone);
         return AV11WWPUserExtendedPhone ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out string aP1_WWPUserExtendedPhone )
      {
         wwp_getuserphone objwwp_getuserphone;
         objwwp_getuserphone = new wwp_getuserphone();
         objwwp_getuserphone.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         objwwp_getuserphone.AV11WWPUserExtendedPhone = "" ;
         objwwp_getuserphone.context.SetSubmitInitialConfig(context);
         objwwp_getuserphone.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getuserphone);
         aP1_WWPUserExtendedPhone=this.AV11WWPUserExtendedPhone;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getuserphone)stateInfo).executePrivate();
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
         AV11WWPUserExtendedPhone = AV10GAMUser.gxTpr_Phone;
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
         AV11WWPUserExtendedPhone = "";
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9WWPUserExtendedId ;
      private string AV11WWPUserExtendedPhone ;
      private string aP1_WWPUserExtendedPhone ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
   }

}
