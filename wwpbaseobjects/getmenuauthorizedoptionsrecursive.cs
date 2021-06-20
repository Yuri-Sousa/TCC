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
   public class getmenuauthorizedoptionsrecursive : GXProcedure
   {
      public getmenuauthorizedoptionsrecursive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getmenuauthorizedoptionsrecursive( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_ParentItemJson ,
                           out string aP1_ResultJson )
      {
         this.AV13ParentItemJson = aP0_ParentItemJson;
         this.AV16ResultJson = "" ;
         initialize();
         executePrivate();
         aP1_ResultJson=this.AV16ResultJson;
      }

      public string executeUdp( string aP0_ParentItemJson )
      {
         execute(aP0_ParentItemJson, out aP1_ResultJson);
         return AV16ResultJson ;
      }

      public void executeSubmit( string aP0_ParentItemJson ,
                                 out string aP1_ResultJson )
      {
         getmenuauthorizedoptionsrecursive objgetmenuauthorizedoptionsrecursive;
         objgetmenuauthorizedoptionsrecursive = new getmenuauthorizedoptionsrecursive();
         objgetmenuauthorizedoptionsrecursive.AV13ParentItemJson = aP0_ParentItemJson;
         objgetmenuauthorizedoptionsrecursive.AV16ResultJson = "" ;
         objgetmenuauthorizedoptionsrecursive.context.SetSubmitInitialConfig(context);
         objgetmenuauthorizedoptionsrecursive.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetmenuauthorizedoptionsrecursive);
         aP1_ResultJson=this.AV16ResultJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getmenuauthorizedoptionsrecursive)stateInfo).executePrivate();
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
         AV14RemoveIds.Clear();
         AV10DVelop_Menu_Item.FromJSonString(AV13ParentItemJson, null);
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV10DVelop_Menu_Item.gxTpr_Subitems.Count )
         {
            AV9AuxDVelop_Menu_Item = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV10DVelop_Menu_Item.gxTpr_Subitems.Item(AV19GXV1));
            if ( AV9AuxDVelop_Menu_Item.gxTpr_Subitems.Count > 0 )
            {
               new GeneXus.Programs.wwpbaseobjects.getmenuauthorizedoptionsrecursive(context ).execute(  AV9AuxDVelop_Menu_Item.ToJSonString(false, true), out  AV15Result2Json) ;
               AV9AuxDVelop_Menu_Item.FromJSonString(AV15Result2Json, null);
               if ( AV9AuxDVelop_Menu_Item.gxTpr_Subitems.Count == 0 )
               {
                  AV14RemoveIds.Add(AV9AuxDVelop_Menu_Item.gxTpr_Id, 0);
               }
            }
            else
            {
               GXt_boolean1 = AV8IsAuthorized;
               new GeneXus.Programs.wwpbaseobjects.ismenuauthorizedoption(context ).execute(  AV9AuxDVelop_Menu_Item, out  GXt_boolean1) ;
               AV8IsAuthorized = GXt_boolean1;
               if ( ! AV8IsAuthorized )
               {
                  AV14RemoveIds.Add(AV9AuxDVelop_Menu_Item.gxTpr_Id, 0);
               }
            }
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         AV11i = 1;
         while ( AV11i <= AV14RemoveIds.Count )
         {
            AV12j = 0;
            AV20GXV2 = 1;
            while ( AV20GXV2 <= AV10DVelop_Menu_Item.gxTpr_Subitems.Count )
            {
               AV9AuxDVelop_Menu_Item = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV10DVelop_Menu_Item.gxTpr_Subitems.Item(AV20GXV2));
               AV12j = (short)(AV12j+1);
               if ( StringUtil.StrCmp(StringUtil.Trim( AV9AuxDVelop_Menu_Item.gxTpr_Id), StringUtil.Trim( AV14RemoveIds.GetString(AV11i))) == 0 )
               {
                  AV10DVelop_Menu_Item.gxTpr_Subitems.RemoveItem(AV12j);
                  if (true) break;
               }
               AV20GXV2 = (int)(AV20GXV2+1);
            }
            AV11i = (short)(AV11i+1);
         }
         AV16ResultJson = AV10DVelop_Menu_Item.ToJSonString(false, true);
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
         AV16ResultJson = "";
         AV14RemoveIds = new GxSimpleCollection<string>();
         AV10DVelop_Menu_Item = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV9AuxDVelop_Menu_Item = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV15Result2Json = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11i ;
      private short AV12j ;
      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string AV13ParentItemJson ;
      private string AV16ResultJson ;
      private string AV15Result2Json ;
      private string aP1_ResultJson ;
      private GxSimpleCollection<string> AV14RemoveIds ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV10DVelop_Menu_Item ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV9AuxDVelop_Menu_Item ;
   }

}
