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
   public class wwp_getappliedfiltersdescription : GXProcedure
   {
      public wwp_getappliedfiltersdescription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getappliedfiltersdescription( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_ListObjectName ,
                           out string aP1_AppliedFiltersDescription )
      {
         this.AV14ListObjectName = aP0_ListObjectName;
         this.AV8AppliedFiltersDescription = "" ;
         initialize();
         executePrivate();
         aP1_AppliedFiltersDescription=this.AV8AppliedFiltersDescription;
      }

      public string executeUdp( string aP0_ListObjectName )
      {
         execute(aP0_ListObjectName, out aP1_AppliedFiltersDescription);
         return AV8AppliedFiltersDescription ;
      }

      public void executeSubmit( string aP0_ListObjectName ,
                                 out string aP1_AppliedFiltersDescription )
      {
         wwp_getappliedfiltersdescription objwwp_getappliedfiltersdescription;
         objwwp_getappliedfiltersdescription = new wwp_getappliedfiltersdescription();
         objwwp_getappliedfiltersdescription.AV14ListObjectName = aP0_ListObjectName;
         objwwp_getappliedfiltersdescription.AV8AppliedFiltersDescription = "" ;
         objwwp_getappliedfiltersdescription.context.SetSubmitInitialConfig(context);
         objwwp_getappliedfiltersdescription.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getappliedfiltersdescription);
         aP1_AppliedFiltersDescription=this.AV8AppliedFiltersDescription;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getappliedfiltersdescription)stateInfo).executePrivate();
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
         AV12GridState.FromXml(AV15Session.Get(AV14ListObjectName+"GridState"), null, "WWPGridState", "RastreamentoTCC");
         AV16TotalFilters = (short)(AV12GridState.gxTpr_Filtervalues.Count+AV12GridState.gxTpr_Dynamicfilters.Count);
         AV8AppliedFiltersDescription = "";
         if ( AV16TotalFilters > 0 )
         {
            AV9index = 1;
            AV19GXV1 = 1;
            while ( AV19GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
            {
               AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV19GXV1));
               AV11FilterDescription = AV13GridStateFilterValue.gxTpr_Dsc;
               /* Execute user subroutine: 'ADD FILTER TO DESCRIPTION' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV19GXV1 = (int)(AV19GXV1+1);
            }
            AV20GXV2 = 1;
            while ( AV20GXV2 <= AV12GridState.gxTpr_Dynamicfilters.Count )
            {
               AV10DynamicFiltersItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(AV20GXV2));
               AV11FilterDescription = AV10DynamicFiltersItem.gxTpr_Dsc;
               /* Execute user subroutine: 'ADD FILTER TO DESCRIPTION' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV20GXV2 = (int)(AV20GXV2+1);
            }
            AV8AppliedFiltersDescription = StringUtil.Format( "Filtrando por %1", AV8AppliedFiltersDescription, "", "", "", "", "", "", "", "");
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADD FILTER TO DESCRIPTION' Routine */
         returnInSub = false;
         if ( AV9index >= 6 )
         {
            if ( AV9index == 6 )
            {
               AV8AppliedFiltersDescription += "...";
            }
         }
         else
         {
            if ( AV9index > 1 )
            {
               AV8AppliedFiltersDescription += ((AV9index==AV16TotalFilters) ? " "+"e" : ",") + " ";
            }
            AV8AppliedFiltersDescription += AV11FilterDescription;
         }
         AV9index = (short)(AV9index+1);
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
         AV8AppliedFiltersDescription = "";
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV15Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV11FilterDescription = "";
         AV10DynamicFiltersItem = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16TotalFilters ;
      private short AV9index ;
      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private bool returnInSub ;
      private string AV14ListObjectName ;
      private string AV8AppliedFiltersDescription ;
      private string AV11FilterDescription ;
      private IGxSession AV15Session ;
      private string aP1_AppliedFiltersDescription ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV10DynamicFiltersItem ;
   }

}
