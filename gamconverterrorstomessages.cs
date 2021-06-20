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
namespace GeneXus.Programs {
   public class gamconverterrorstomessages : GXProcedure
   {
      public gamconverterrorstomessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gamconverterrorstomessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection ,
                           out GXBaseCollection<SdtMessages_Message> aP1_Messages )
      {
         this.AV9GAMErrorCollection = aP0_GAMErrorCollection;
         this.AV11Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP1_Messages=this.AV11Messages;
      }

      public GXBaseCollection<SdtMessages_Message> executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection )
      {
         execute(aP0_GAMErrorCollection, out aP1_Messages);
         return AV11Messages ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection ,
                                 out GXBaseCollection<SdtMessages_Message> aP1_Messages )
      {
         gamconverterrorstomessages objgamconverterrorstomessages;
         objgamconverterrorstomessages = new gamconverterrorstomessages();
         objgamconverterrorstomessages.AV9GAMErrorCollection = aP0_GAMErrorCollection;
         objgamconverterrorstomessages.AV11Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         objgamconverterrorstomessages.context.SetSubmitInitialConfig(context);
         objgamconverterrorstomessages.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgamconverterrorstomessages);
         aP1_Messages=this.AV11Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamconverterrorstomessages)stateInfo).executePrivate();
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
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV9GAMErrorCollection.Count )
         {
            AV8GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(AV14GXV1));
            AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV10Message.gxTpr_Type = 1;
            AV10Message.gxTpr_Description = AV8GAMError.gxTpr_Message;
            AV10Message.gxTpr_Id = StringUtil.Format( "GAM%2", StringUtil.LTrimStr( (decimal)(AV8GAMError.gxTpr_Code), 12, 0), "", "", "", "", "", "", "", "");
            AV11Messages.Add(AV10Message, 0);
            AV14GXV1 = (int)(AV14GXV1+1);
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
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV11Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV8GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV14GXV1 ;
      private GXBaseCollection<SdtMessages_Message> aP1_Messages ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private GXBaseCollection<SdtMessages_Message> AV11Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV8GAMError ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
   }

}
