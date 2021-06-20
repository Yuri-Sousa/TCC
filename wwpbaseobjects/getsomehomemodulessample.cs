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
   public class getsomehomemodulessample : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "" ;
         }

      }

      public getsomehomemodulessample( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getsomehomemodulessample( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm3rootcol )
      {
         this.Gxm3rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "RastreamentoTCC") ;
         initialize();
         executePrivate();
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> executeUdp( )
      {
         execute(out aP0_Gxm3rootcol);
         return Gxm3rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm3rootcol )
      {
         getsomehomemodulessample objgetsomehomemodulessample;
         objgetsomehomemodulessample = new getsomehomemodulessample();
         objgetsomehomemodulessample.Gxm3rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "RastreamentoTCC") ;
         objgetsomehomemodulessample.context.SetSubmitInitialConfig(context);
         objgetsomehomemodulessample.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetsomehomemodulessample);
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getsomehomemodulessample)stateInfo).executePrivate();
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
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1 = AV5HomeModulesSDT;
         new GeneXus.Programs.wwpbaseobjects.gethomemodulessample(context ).execute( out  GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1) ;
         AV5HomeModulesSDT = GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1;
         Gxv1skipcount = 0;
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV5HomeModulesSDT.Count )
         {
            AV6HomeModulesSDTItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV12GXV1));
            Gxv1skipcount = (int)(Gxv1skipcount+1);
            Gxm2homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
            Gxm3rootcol.Add(Gxm2homemodulessdt, 0);
            Gxm2homemodulessdt.gxTpr_Optiontitle = AV6HomeModulesSDTItem.gxTpr_Optiontitle;
            Gxm2homemodulessdt.gxTpr_Optioniconthemeclass = AV6HomeModulesSDTItem.gxTpr_Optioniconthemeclass;
            Gxm2homemodulessdt.gxTpr_Optionbackgroundimage = AV6HomeModulesSDTItem.gxTpr_Optionbackgroundimage;
            Gxm2homemodulessdt.gxTpr_Optionbackgroundimage_gxi = AV6HomeModulesSDTItem.gxTpr_Optionbackgroundimage_gxi;
            Gxm2homemodulessdt.gxTpr_Optiondescription = AV6HomeModulesSDTItem.gxTpr_Optiondescription;
            Gxm2homemodulessdt.gxTpr_Optionwclink = AV6HomeModulesSDTItem.gxTpr_Optionwclink;
            if ( ( 6 != 0 ) && ( Gxv1skipcount >= 6 ) )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV5HomeModulesSDT = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "RastreamentoTCC");
         GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "RastreamentoTCC");
         AV6HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int Gxv1skipcount ;
      private int AV12GXV1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm3rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> Gxm3rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> GXt_objcol_SdtHomeModulesSDT_HomeModulesSDTItem1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem AV6HomeModulesSDTItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem Gxm2homemodulessdt ;
   }

}
