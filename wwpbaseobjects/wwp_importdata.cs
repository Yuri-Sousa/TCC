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
   public class wwp_importdata : GXProcedure
   {
      public wwp_importdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_importdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_SelctionName ,
                           string aP1_ImportType ,
                           string aP2_FilePath ,
                           string aP3_ExtraParmsJson ,
                           out GXBaseCollection<SdtMessages_Message> aP4_Messages ,
                           out bool aP5_IsOk )
      {
         this.AV12SelctionName = aP0_SelctionName;
         this.AV9ImportType = aP1_ImportType;
         this.AV8FilePath = aP2_FilePath;
         this.AV14ExtraParmsJson = aP3_ExtraParmsJson;
         this.AV11Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV10IsOk = false ;
         initialize();
         executePrivate();
         aP4_Messages=this.AV11Messages;
         aP5_IsOk=this.AV10IsOk;
      }

      public bool executeUdp( string aP0_SelctionName ,
                              string aP1_ImportType ,
                              string aP2_FilePath ,
                              string aP3_ExtraParmsJson ,
                              out GXBaseCollection<SdtMessages_Message> aP4_Messages )
      {
         execute(aP0_SelctionName, aP1_ImportType, aP2_FilePath, aP3_ExtraParmsJson, out aP4_Messages, out aP5_IsOk);
         return AV10IsOk ;
      }

      public void executeSubmit( string aP0_SelctionName ,
                                 string aP1_ImportType ,
                                 string aP2_FilePath ,
                                 string aP3_ExtraParmsJson ,
                                 out GXBaseCollection<SdtMessages_Message> aP4_Messages ,
                                 out bool aP5_IsOk )
      {
         wwp_importdata objwwp_importdata;
         objwwp_importdata = new wwp_importdata();
         objwwp_importdata.AV12SelctionName = aP0_SelctionName;
         objwwp_importdata.AV9ImportType = aP1_ImportType;
         objwwp_importdata.AV8FilePath = aP2_FilePath;
         objwwp_importdata.AV14ExtraParmsJson = aP3_ExtraParmsJson;
         objwwp_importdata.AV11Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         objwwp_importdata.AV10IsOk = false ;
         objwwp_importdata.context.SetSubmitInitialConfig(context);
         objwwp_importdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_importdata);
         aP4_Messages=this.AV11Messages;
         aP5_IsOk=this.AV10IsOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_importdata)stateInfo).executePrivate();
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
         AV11Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV10IsOk ;
      private string AV12SelctionName ;
      private string AV9ImportType ;
      private string AV8FilePath ;
      private string AV14ExtraParmsJson ;
      private GXBaseCollection<SdtMessages_Message> aP4_Messages ;
      private bool aP5_IsOk ;
      private GXBaseCollection<SdtMessages_Message> AV11Messages ;
   }

}
