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
   public class getfilterbyname : GXProcedure
   {
      public getfilterbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getfilterbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_UserCustomKey ,
                           string aP1_FilterName ,
                           out string aP2_FilterXML )
      {
         this.AV12UserCustomKey = aP0_UserCustomKey;
         this.AV8FilterName = aP1_FilterName;
         this.AV9FilterXML = "" ;
         initialize();
         executePrivate();
         aP2_FilterXML=this.AV9FilterXML;
      }

      public string executeUdp( string aP0_UserCustomKey ,
                                string aP1_FilterName )
      {
         execute(aP0_UserCustomKey, aP1_FilterName, out aP2_FilterXML);
         return AV9FilterXML ;
      }

      public void executeSubmit( string aP0_UserCustomKey ,
                                 string aP1_FilterName ,
                                 out string aP2_FilterXML )
      {
         getfilterbyname objgetfilterbyname;
         objgetfilterbyname = new getfilterbyname();
         objgetfilterbyname.AV12UserCustomKey = aP0_UserCustomKey;
         objgetfilterbyname.AV8FilterName = aP1_FilterName;
         objgetfilterbyname.AV9FilterXML = "" ;
         objgetfilterbyname.context.SetSubmitInitialConfig(context);
         objgetfilterbyname.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetfilterbyname);
         aP2_FilterXML=this.AV9FilterXML;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getfilterbyname)stateInfo).executePrivate();
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
         AV10GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  AV12UserCustomKey), null, "Items", "");
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV10GridStateCollection.Count )
         {
            AV11GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV10GridStateCollection.Item(AV15GXV1));
            if ( StringUtil.StrCmp(AV11GridStateCollectionItem.gxTpr_Title, AV8FilterName) == 0 )
            {
               AV9FilterXML = AV11GridStateCollectionItem.gxTpr_Gridstatexml;
               if (true) break;
            }
            AV15GXV1 = (int)(AV15GXV1+1);
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
         AV9FilterXML = "";
         AV10GridStateCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV11GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV15GXV1 ;
      private string AV9FilterXML ;
      private string AV12UserCustomKey ;
      private string AV8FilterName ;
      private string aP2_FilterXML ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV10GridStateCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV11GridStateCollectionItem ;
   }

}
