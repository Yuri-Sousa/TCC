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
   public class wwp_getuserfullname : GXProcedure
   {
      public wwp_getuserfullname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getuserfullname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out string aP1_WWPUserExtendedFullName )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV9WWPUserExtendedFullName = "" ;
         initialize();
         executePrivate();
         aP1_WWPUserExtendedFullName=this.AV9WWPUserExtendedFullName;
      }

      public string executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_WWPUserExtendedFullName);
         return AV9WWPUserExtendedFullName ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out string aP1_WWPUserExtendedFullName )
      {
         wwp_getuserfullname objwwp_getuserfullname;
         objwwp_getuserfullname = new wwp_getuserfullname();
         objwwp_getuserfullname.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         objwwp_getuserfullname.AV9WWPUserExtendedFullName = "" ;
         objwwp_getuserfullname.context.SetSubmitInitialConfig(context);
         objwwp_getuserfullname.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getuserfullname);
         aP1_WWPUserExtendedFullName=this.AV9WWPUserExtendedFullName;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getuserfullname)stateInfo).executePrivate();
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
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbyguid(AV10WWPUserExtendedId, out  AV8GAMErrorCollection);
         AV9WWPUserExtendedFullName = (String.IsNullOrEmpty(StringUtil.RTrim( AV11GAMUser.gxTpr_Firstname)) ? AV11GAMUser.gxTpr_Name : StringUtil.Trim( AV11GAMUser.gxTpr_Firstname)+" "+StringUtil.Trim( AV11GAMUser.gxTpr_Lastname));
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
         AV9WWPUserExtendedFullName = "";
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV10WWPUserExtendedId ;
      private string AV9WWPUserExtendedFullName ;
      private string aP1_WWPUserExtendedFullName ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
   }

}
