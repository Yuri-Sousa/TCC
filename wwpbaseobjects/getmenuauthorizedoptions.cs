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
   public class getmenuauthorizedoptions : GXProcedure
   {
      public getmenuauthorizedoptions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getmenuauthorizedoptions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_DVelop_Menu )
      {
         this.AV9DVelop_Menu = aP0_DVelop_Menu;
         initialize();
         executePrivate();
         aP0_DVelop_Menu=this.AV9DVelop_Menu;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( )
      {
         execute(ref aP0_DVelop_Menu);
         return AV9DVelop_Menu ;
      }

      public void executeSubmit( ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_DVelop_Menu )
      {
         getmenuauthorizedoptions objgetmenuauthorizedoptions;
         objgetmenuauthorizedoptions = new getmenuauthorizedoptions();
         objgetmenuauthorizedoptions.AV9DVelop_Menu = aP0_DVelop_Menu;
         objgetmenuauthorizedoptions.context.SetSubmitInitialConfig(context);
         objgetmenuauthorizedoptions.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetmenuauthorizedoptions);
         aP0_DVelop_Menu=this.AV9DVelop_Menu;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getmenuauthorizedoptions)stateInfo).executePrivate();
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
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV9DVelop_Menu.Count )
         {
            AV10DVelop_Menu_Item = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV9DVelop_Menu.Item(AV18GXV1));
            if ( AV10DVelop_Menu_Item.gxTpr_Subitems.Count > 0 )
            {
               new GeneXus.Programs.wwpbaseobjects.getmenuauthorizedoptionsrecursive(context ).execute(  AV10DVelop_Menu_Item.ToJSonString(false, true), out  AV15ResultJson) ;
               AV8Aux_DVelop_Menu_Item.FromJSonString(AV15ResultJson, null);
               if ( AV8Aux_DVelop_Menu_Item.gxTpr_Subitems.Count == 0 )
               {
                  AV14RemoveIds.Add(AV10DVelop_Menu_Item.gxTpr_Id, 0);
               }
               else
               {
                  AV10DVelop_Menu_Item.FromJSonString(AV15ResultJson, null);
               }
            }
            else
            {
               GXt_boolean1 = AV12IsAuthorized;
               new GeneXus.Programs.wwpbaseobjects.ismenuauthorizedoption(context ).execute(  AV10DVelop_Menu_Item, out  GXt_boolean1) ;
               AV12IsAuthorized = GXt_boolean1;
               if ( ! AV12IsAuthorized )
               {
                  AV14RemoveIds.Add(AV10DVelop_Menu_Item.gxTpr_Id, 0);
               }
            }
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         AV11i = 1;
         while ( AV11i <= AV14RemoveIds.Count )
         {
            AV13j = 1;
            while ( AV13j <= AV9DVelop_Menu.Count )
            {
               if ( StringUtil.StrCmp(StringUtil.Trim( ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV9DVelop_Menu.Item(AV13j)).gxTpr_Id), StringUtil.Trim( AV14RemoveIds.GetString(AV11i))) == 0 )
               {
                  AV9DVelop_Menu.RemoveItem(AV13j);
                  if (true) break;
               }
               AV13j = (short)(AV13j+1);
            }
            AV11i = (short)(AV11i+1);
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
         AV10DVelop_Menu_Item = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV15ResultJson = "";
         AV8Aux_DVelop_Menu_Item = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV14RemoveIds = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11i ;
      private short AV13j ;
      private int AV18GXV1 ;
      private bool AV12IsAuthorized ;
      private bool GXt_boolean1 ;
      private string AV15ResultJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_DVelop_Menu ;
      private GxSimpleCollection<string> AV14RemoveIds ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV9DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV10DVelop_Menu_Item ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV8Aux_DVelop_Menu_Item ;
   }

}
