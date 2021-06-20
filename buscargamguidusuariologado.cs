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
namespace GeneXus.Programs {
   public class buscargamguidusuariologado : GXProcedure
   {
      public buscargamguidusuariologado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public buscargamguidusuariologado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out string aP0_GAMGUID )
      {
         this.AV10GAMGUID = "" ;
         initialize();
         executePrivate();
         aP0_GAMGUID=this.AV10GAMGUID;
      }

      public string executeUdp( )
      {
         execute(out aP0_GAMGUID);
         return AV10GAMGUID ;
      }

      public void executeSubmit( out string aP0_GAMGUID )
      {
         buscargamguidusuariologado objbuscargamguidusuariologado;
         objbuscargamguidusuariologado = new buscargamguidusuariologado();
         objbuscargamguidusuariologado.AV10GAMGUID = "" ;
         objbuscargamguidusuariologado.context.SetSubmitInitialConfig(context);
         objbuscargamguidusuariologado.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbuscargamguidusuariologado);
         aP0_GAMGUID=this.AV10GAMGUID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((buscargamguidusuariologado)stateInfo).executePrivate();
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
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         AV10GAMGUID = AV9GAMUser.gxTpr_Guid;
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
         AV10GAMGUID = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV10GAMGUID ;
      private string aP0_GAMGUID ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
   }

}
