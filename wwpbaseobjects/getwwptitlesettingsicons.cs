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
   public class getwwptitlesettingsicons : GXProcedure
   {
      public getwwptitlesettingsicons( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getwwptitlesettingsicons( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons aP0_TitleSettingsIcons )
      {
         this.AV8TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context) ;
         initialize();
         executePrivate();
         aP0_TitleSettingsIcons=this.AV8TitleSettingsIcons;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons executeUdp( )
      {
         execute(out aP0_TitleSettingsIcons);
         return AV8TitleSettingsIcons ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons aP0_TitleSettingsIcons )
      {
         getwwptitlesettingsicons objgetwwptitlesettingsicons;
         objgetwwptitlesettingsicons = new getwwptitlesettingsicons();
         objgetwwptitlesettingsicons.AV8TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context) ;
         objgetwwptitlesettingsicons.context.SetSubmitInitialConfig(context);
         objgetwwptitlesettingsicons.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetwwptitlesettingsicons);
         aP0_TitleSettingsIcons=this.AV8TitleSettingsIcons;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getwwptitlesettingsicons)stateInfo).executePrivate();
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
         AV8TitleSettingsIcons.gxTpr_Default_fi = "fas fa-caret-down CSTitleIcon";
         AV8TitleSettingsIcons.gxTpr_Filtered_fi = "fas fa-filter CSTitleIcon";
         AV8TitleSettingsIcons.gxTpr_Sortedasc_fi = "fas fa-long-arrow-alt-up CSTitleIcon";
         AV8TitleSettingsIcons.gxTpr_Sorteddsc_fi = "fas fa-long-arrow-alt-down CSTitleIcon";
         AV8TitleSettingsIcons.gxTpr_Filteredsortedasc_fi = "fas fa-long-arrow-alt-up CSTitleIconDanger";
         AV8TitleSettingsIcons.gxTpr_Filteredsorteddsc_fi = "fas fa-long-arrow-alt-down CSTitleIconDanger";
         AV8TitleSettingsIcons.gxTpr_Optionsortasc_fi = "fas fa-sort-amount-up CSDropDownFI";
         AV8TitleSettingsIcons.gxTpr_Optionsortdsc_fi = "fas fa-sort-amount-down CSDropDownFI";
         AV8TitleSettingsIcons.gxTpr_Optionapplyfilter_fi = "fas fa-search";
         AV8TitleSettingsIcons.gxTpr_Optionfilteringdata_fi = "fa fa-spinner fa-pulse fa-fw CSDropDownFI";
         AV8TitleSettingsIcons.gxTpr_Optioncleanfilters_fi = "fas fa-times CSDropDownFI";
         AV8TitleSettingsIcons.gxTpr_Selectedoption_fi = "fas fa-filter CSDropDownFilter";
         AV8TitleSettingsIcons.gxTpr_Multiseloption_fi = "far fa-square CSDropDownFilter";
         AV8TitleSettingsIcons.gxTpr_Multiselseloption_fi = "far fa-check-square CSDropDownFilter";
         AV8TitleSettingsIcons.gxTpr_Treeviewcollapse_fi = "fas fa-angle-down";
         AV8TitleSettingsIcons.gxTpr_Treeviewexpand_fi = "fas fa-angle-right";
         AV8TitleSettingsIcons.gxTpr_Fixleft_fi = "fa fa-rotate-270 fa-table CSDropDownFI";
         AV8TitleSettingsIcons.gxTpr_Fixright_fi = "fa fa-rotate-90 fa-table CSDropDownFI";
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
         AV8TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons aP0_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV8TitleSettingsIcons ;
   }

}
