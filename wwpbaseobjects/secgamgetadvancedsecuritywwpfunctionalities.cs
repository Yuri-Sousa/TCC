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
   public class secgamgetadvancedsecuritywwpfunctionalities : GXProcedure
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

      public secgamgetadvancedsecuritywwpfunctionalities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public secgamgetadvancedsecuritywwpfunctionalities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "RastreamentoTCC") ;
         initialize();
         executePrivate();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm1rootcol )
      {
         secgamgetadvancedsecuritywwpfunctionalities objsecgamgetadvancedsecuritywwpfunctionalities;
         objsecgamgetadvancedsecuritywwpfunctionalities = new secgamgetadvancedsecuritywwpfunctionalities();
         objsecgamgetadvancedsecuritywwpfunctionalities.Gxm1rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad>( context, "SecGAMFunctionalitiesToLoad", "RastreamentoTCC") ;
         objsecgamgetadvancedsecuritywwpfunctionalities.context.SetSubmitInitialConfig(context);
         objsecgamgetadvancedsecuritywwpfunctionalities.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsecgamgetadvancedsecuritywwpfunctionalities);
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((secgamgetadvancedsecuritywwpfunctionalities)stateInfo).executePrivate();
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> aP0_Gxm1rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecGAMFunctionalitiesToLoad> Gxm1rootcol ;
   }

}
