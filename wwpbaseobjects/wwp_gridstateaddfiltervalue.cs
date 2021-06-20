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
   public class wwp_gridstateaddfiltervalue : GXProcedure
   {
      public wwp_gridstateaddfiltervalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_gridstateaddfiltervalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                           string aP1_FilterName ,
                           string aP2_FilterDsc ,
                           bool aP3_AddFitler ,
                           short aP4_FilterOperator ,
                           string aP5_FilterValue ,
                           string aP6_FilterValueTo )
      {
         this.AV12GridState = aP0_GridState;
         this.AV8FilterName = aP1_FilterName;
         this.AV15FilterDsc = aP2_FilterDsc;
         this.AV11AddFitler = aP3_AddFitler;
         this.AV14FilterOperator = aP4_FilterOperator;
         this.AV10FilterValue = aP5_FilterValue;
         this.AV9FilterValueTo = aP6_FilterValueTo;
         initialize();
         executePrivate();
         aP0_GridState=this.AV12GridState;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                                 string aP1_FilterName ,
                                 string aP2_FilterDsc ,
                                 bool aP3_AddFitler ,
                                 short aP4_FilterOperator ,
                                 string aP5_FilterValue ,
                                 string aP6_FilterValueTo )
      {
         wwp_gridstateaddfiltervalue objwwp_gridstateaddfiltervalue;
         objwwp_gridstateaddfiltervalue = new wwp_gridstateaddfiltervalue();
         objwwp_gridstateaddfiltervalue.AV12GridState = aP0_GridState;
         objwwp_gridstateaddfiltervalue.AV8FilterName = aP1_FilterName;
         objwwp_gridstateaddfiltervalue.AV15FilterDsc = aP2_FilterDsc;
         objwwp_gridstateaddfiltervalue.AV11AddFitler = aP3_AddFitler;
         objwwp_gridstateaddfiltervalue.AV14FilterOperator = aP4_FilterOperator;
         objwwp_gridstateaddfiltervalue.AV10FilterValue = aP5_FilterValue;
         objwwp_gridstateaddfiltervalue.AV9FilterValueTo = aP6_FilterValueTo;
         objwwp_gridstateaddfiltervalue.context.SetSubmitInitialConfig(context);
         objwwp_gridstateaddfiltervalue.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_gridstateaddfiltervalue);
         aP0_GridState=this.AV12GridState;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_gridstateaddfiltervalue)stateInfo).executePrivate();
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
         if ( AV11AddFitler )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = AV8FilterName;
            AV13GridStateFilterValue.gxTpr_Dsc = AV15FilterDsc;
            AV13GridStateFilterValue.gxTpr_Operator = AV14FilterOperator;
            AV13GridStateFilterValue.gxTpr_Value = AV10FilterValue;
            AV13GridStateFilterValue.gxTpr_Valueto = AV9FilterValueTo;
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
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
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14FilterOperator ;
      private bool AV11AddFitler ;
      private string AV8FilterName ;
      private string AV15FilterDsc ;
      private string AV10FilterValue ;
      private string AV9FilterValueTo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
   }

}
