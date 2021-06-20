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
   public class wwp_columnsselector_add : GXProcedure
   {
      public wwp_columnsselector_add( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_columnsselector_add( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector aP0_ColumnsSelector ,
                           string aP1_ColumnName ,
                           string aP2_Category ,
                           string aP3_DisplayName ,
                           bool aP4_IsVisible ,
                           string aP5_Fixed )
      {
         this.AV8ColumnsSelector = aP0_ColumnsSelector;
         this.AV9ColumnName = aP1_ColumnName;
         this.AV10Category = aP2_Category;
         this.AV11DisplayName = aP3_DisplayName;
         this.AV13IsVisible = aP4_IsVisible;
         this.AV12Fixed = aP5_Fixed;
         initialize();
         executePrivate();
         aP0_ColumnsSelector=this.AV8ColumnsSelector;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector aP0_ColumnsSelector ,
                                 string aP1_ColumnName ,
                                 string aP2_Category ,
                                 string aP3_DisplayName ,
                                 bool aP4_IsVisible ,
                                 string aP5_Fixed )
      {
         wwp_columnsselector_add objwwp_columnsselector_add;
         objwwp_columnsselector_add = new wwp_columnsselector_add();
         objwwp_columnsselector_add.AV8ColumnsSelector = aP0_ColumnsSelector;
         objwwp_columnsselector_add.AV9ColumnName = aP1_ColumnName;
         objwwp_columnsselector_add.AV10Category = aP2_Category;
         objwwp_columnsselector_add.AV11DisplayName = aP3_DisplayName;
         objwwp_columnsselector_add.AV13IsVisible = aP4_IsVisible;
         objwwp_columnsselector_add.AV12Fixed = aP5_Fixed;
         objwwp_columnsselector_add.context.SetSubmitInitialConfig(context);
         objwwp_columnsselector_add.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_columnsselector_add);
         aP0_ColumnsSelector=this.AV8ColumnsSelector;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_columnsselector_add)stateInfo).executePrivate();
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
         AV14Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV14Column.gxTpr_Columnname = AV9ColumnName;
         AV14Column.gxTpr_Displayname = AV11DisplayName;
         AV14Column.gxTpr_Isvisible = AV13IsVisible;
         AV14Column.gxTpr_Order = (short)(AV8ColumnsSelector.gxTpr_Columns.Count+1);
         AV14Column.gxTpr_Category = AV10Category;
         AV8ColumnsSelector.gxTpr_Columns.Add(AV14Column, 0);
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
         AV14Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV13IsVisible ;
      private string AV9ColumnName ;
      private string AV10Category ;
      private string AV11DisplayName ;
      private string AV12Fixed ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector aP0_ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV8ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV14Column ;
   }

}
