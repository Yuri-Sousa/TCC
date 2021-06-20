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
   public class wwp_managefiltersloadsavedfilters : GXProcedure
   {
      public wwp_managefiltersloadsavedfilters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_managefiltersloadsavedfilters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_Key ,
                           string aP1_CleanJSFormat ,
                           string aP2_TableInternalName ,
                           bool aP3_HasAdvancedFilters ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> aP4_ManageFiltersData )
      {
         this.AV8Key = aP0_Key;
         this.AV13CleanJSFormat = aP1_CleanJSFormat;
         this.AV14TableInternalName = aP2_TableInternalName;
         this.AV15HasAdvancedFilters = aP3_HasAdvancedFilters;
         this.AV9ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP4_ManageFiltersData=this.AV9ManageFiltersData;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> executeUdp( string aP0_Key ,
                                                                                                              string aP1_CleanJSFormat ,
                                                                                                              string aP2_TableInternalName ,
                                                                                                              bool aP3_HasAdvancedFilters )
      {
         execute(aP0_Key, aP1_CleanJSFormat, aP2_TableInternalName, aP3_HasAdvancedFilters, out aP4_ManageFiltersData);
         return AV9ManageFiltersData ;
      }

      public void executeSubmit( string aP0_Key ,
                                 string aP1_CleanJSFormat ,
                                 string aP2_TableInternalName ,
                                 bool aP3_HasAdvancedFilters ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> aP4_ManageFiltersData )
      {
         wwp_managefiltersloadsavedfilters objwwp_managefiltersloadsavedfilters;
         objwwp_managefiltersloadsavedfilters = new wwp_managefiltersloadsavedfilters();
         objwwp_managefiltersloadsavedfilters.AV8Key = aP0_Key;
         objwwp_managefiltersloadsavedfilters.AV13CleanJSFormat = aP1_CleanJSFormat;
         objwwp_managefiltersloadsavedfilters.AV14TableInternalName = aP2_TableInternalName;
         objwwp_managefiltersloadsavedfilters.AV15HasAdvancedFilters = aP3_HasAdvancedFilters;
         objwwp_managefiltersloadsavedfilters.AV9ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "") ;
         objwwp_managefiltersloadsavedfilters.context.SetSubmitInitialConfig(context);
         objwwp_managefiltersloadsavedfilters.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_managefiltersloadsavedfilters);
         aP4_ManageFiltersData=this.AV9ManageFiltersData;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_managefiltersloadsavedfilters)stateInfo).executePrivate();
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
         AV9ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV10ManageFiltersDataItem.gxTpr_Title = "Limpar filtros";
         AV10ManageFiltersDataItem.gxTpr_Eventkey = "<#Clean#>";
         AV10ManageFiltersDataItem.gxTpr_Isdivider = false;
         AV10ManageFiltersDataItem.gxTpr_Fonticon = "fa fa-times-circle";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CleanJSFormat)) )
         {
            AV10ManageFiltersDataItem.gxTpr_Jsonclickevent = StringUtil.Format( AV13CleanJSFormat, AV14TableInternalName, "", "", "", "", "", "", "", "");
         }
         AV9ManageFiltersData.Add(AV10ManageFiltersDataItem, 0);
         AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV10ManageFiltersDataItem.gxTpr_Title = "Salvar filtro como...";
         AV10ManageFiltersDataItem.gxTpr_Eventkey = "<#Save#>";
         AV10ManageFiltersDataItem.gxTpr_Isdivider = false;
         AV10ManageFiltersDataItem.gxTpr_Fonticon = "fa fa-save";
         AV9ManageFiltersData.Add(AV10ManageFiltersDataItem, 0);
         if ( AV15HasAdvancedFilters )
         {
            AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV10ManageFiltersDataItem.gxTpr_Title = "Mostrar filtros avançados"+"|"+"Ocultar filtros avançados";
            AV10ManageFiltersDataItem.gxTpr_Eventkey = "<#ADV#>";
            AV10ManageFiltersDataItem.gxTpr_Isdivider = false;
            AV10ManageFiltersDataItem.gxTpr_Fonticon = "fas fa-filter";
            AV9ManageFiltersData.Add(AV10ManageFiltersDataItem, 0);
         }
         AV12ManageFiltersItems.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  AV8Key), null, "Items", "");
         if ( AV12ManageFiltersItems.Count > 0 )
         {
            AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV10ManageFiltersDataItem.gxTpr_Isdivider = true;
            AV9ManageFiltersData.Add(AV10ManageFiltersDataItem, 0);
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV12ManageFiltersItems.Count )
            {
               AV11ManageFiltersItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV12ManageFiltersItems.Item(AV18GXV1));
               AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
               AV10ManageFiltersDataItem.gxTpr_Title = AV11ManageFiltersItem.gxTpr_Title;
               AV10ManageFiltersDataItem.gxTpr_Eventkey = AV11ManageFiltersItem.gxTpr_Title;
               AV10ManageFiltersDataItem.gxTpr_Isdivider = false;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CleanJSFormat)) )
               {
                  AV10ManageFiltersDataItem.gxTpr_Jsonclickevent = StringUtil.Format( AV13CleanJSFormat, AV14TableInternalName, "", "", "", "", "", "", "", "");
               }
               AV9ManageFiltersData.Add(AV10ManageFiltersDataItem, 0);
               if ( AV9ManageFiltersData.Count == 13 )
               {
                  if (true) break;
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
            AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV10ManageFiltersDataItem.gxTpr_Isdivider = true;
            AV9ManageFiltersData.Add(AV10ManageFiltersDataItem, 0);
            AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV10ManageFiltersDataItem.gxTpr_Title = "Gerenciar filtros";
            AV10ManageFiltersDataItem.gxTpr_Eventkey = "<#Manage#>";
            AV10ManageFiltersDataItem.gxTpr_Isdivider = false;
            AV10ManageFiltersDataItem.gxTpr_Fonticon = "fa fa-cog";
            AV10ManageFiltersDataItem.gxTpr_Jsonclickevent = "";
            AV9ManageFiltersData.Add(AV10ManageFiltersDataItem, 0);
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
         AV9ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV10ManageFiltersDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV12ManageFiltersItems = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV11ManageFiltersItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18GXV1 ;
      private bool AV15HasAdvancedFilters ;
      private string AV8Key ;
      private string AV13CleanJSFormat ;
      private string AV14TableInternalName ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> aP4_ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV9ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV12ManageFiltersItems ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV10ManageFiltersDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV11ManageFiltersItem ;
   }

}
