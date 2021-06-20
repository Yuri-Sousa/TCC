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
   public class enviarnotificacaowebsocketdistribui : GXProcedure
   {
      public enviarnotificacaowebsocketdistribui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public enviarnotificacaowebsocketdistribui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( SdtSDTNovaPosicao aP0_SDTNovaPosicao )
      {
         this.AV14SDTNovaPosicao = aP0_SDTNovaPosicao;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtSDTNovaPosicao aP0_SDTNovaPosicao )
      {
         enviarnotificacaowebsocketdistribui objenviarnotificacaowebsocketdistribui;
         objenviarnotificacaowebsocketdistribui = new enviarnotificacaowebsocketdistribui();
         objenviarnotificacaowebsocketdistribui.AV14SDTNovaPosicao = aP0_SDTNovaPosicao;
         objenviarnotificacaowebsocketdistribui.context.SetSubmitInitialConfig(context);
         objenviarnotificacaowebsocketdistribui.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objenviarnotificacaowebsocketdistribui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((enviarnotificacaowebsocketdistribui)stateInfo).executePrivate();
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
         AV9port = 80;
         AV10host = "localhost";
         AV11baseurl = "/TCC/rest/";
         AV12httpclient.Host = AV10host;
         AV12httpclient.Port = AV9port;
         AV12httpclient.BaseURL = AV11baseurl;
         AV13Body = "{\"SDTNovaPosicao\":" + StringUtil.Trim( AV14SDTNovaPosicao.ToJSonString(false, true)) + "}";
         AV12httpclient.AddHeader("Content-type", "application/json");
         AV12httpclient.AddString(AV13Body);
         AV12httpclient.Execute("POST", "EnviarNotificacaoWebSocket");
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
         AV10host = "";
         AV11baseurl = "";
         AV12httpclient = new GxHttpClient( context);
         AV13Body = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9port ;
      private string AV13Body ;
      private string AV10host ;
      private string AV11baseurl ;
      private GxHttpClient AV12httpclient ;
      private SdtSDTNovaPosicao AV14SDTNovaPosicao ;
   }

}
