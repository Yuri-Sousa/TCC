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
   public class gethomemodulessample : GXProcedure
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

      public gethomemodulessample( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gethomemodulessample( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "RastreamentoTCC") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol )
      {
         gethomemodulessample objgethomemodulessample;
         objgethomemodulessample = new gethomemodulessample();
         objgethomemodulessample.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "RastreamentoTCC") ;
         objgethomemodulessample.context.SetSubmitInitialConfig(context);
         objgethomemodulessample.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgethomemodulessample);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gethomemodulessample)stateInfo).executePrivate();
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
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Dashboards";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-home";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "d085396f-788e-4174-bb1c-d2d0832ea599", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris tempus vestib ulum mauris quis aliquam.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Lists";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-tasks";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "8b339ea3-0806-4fdc-b87f-6f4b66cf669e", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris tempus vestib ulum mauris quis aliquam.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Feature of Lists";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-tags";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4688f42a-4096-4b76-bddb-a886e286486f", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris tempus vestib ulum mauris quis aliquam.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Wizards";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-briefcase";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "4c659b0a-96d5-4099-bfb6-c43d7184e732", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris tempus vestib ulum mauris quis aliquam.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Associations";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fas fa-exchange-alt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "3ff1b1cd-90c1-4922-90c7-923fe81ed0ed", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris tempus vestib ulum mauris quis aliquam.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Sales Invoice";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-credit-card";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionbackgroundimage = context.convertURL( (string)(context.GetImagePath( "a245472c-9d22-48bd-b724-960d555d3688", "", context.GetTheme( ))));
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris tempus vestib ulum mauris quis aliquam.";
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Users";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-user";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Issues";
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Opened Issues: 24";
         Gxm1homemodulessdt.gxTpr_Optiontype = 2;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionprogressvalue = 24;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Roles";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-cog";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Repository";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-database";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Other Configs";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-bullseye";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Change Password";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-key";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Applications";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-file";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Active Sales";
         Gxm1homemodulessdt.gxTpr_Optiontype = 3;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionprogressvalue = 46;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Create a User";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-user-plus";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Comments";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-comments";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Social Media";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-rss";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Trips";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-plane";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Accounts";
         Gxm1homemodulessdt.gxTpr_Optiondescription = "Accounts that will expire: 56";
         Gxm1homemodulessdt.gxTpr_Optiontype = 2;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
         Gxm1homemodulessdt.gxTpr_Optionprogressvalue = 56;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Emails";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "fa fa-envelope";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "My Profile";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "far fa-id-card";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Pending receipts";
         Gxm1homemodulessdt.gxTpr_Optiontype = 3;
         Gxm1homemodulessdt.gxTpr_Optionsize = 1;
         Gxm1homemodulessdt.gxTpr_Optionprogressvalue = 15;
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         Gxm2rootcol.Add(Gxm1homemodulessdt, 0);
         Gxm1homemodulessdt.gxTpr_Optiontitle = "Projects & Expirations";
         Gxm1homemodulessdt.gxTpr_Optioniconthemeclass = "far fa-calendar-alt";
         Gxm1homemodulessdt.gxTpr_Optiontype = 1;
         Gxm1homemodulessdt.gxTpr_Optionsize = 2;
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
         Gxm1homemodulessdt = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem Gxm1homemodulessdt ;
   }

}
