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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class debugtotext : GXProcedure
   {
      public debugtotext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public debugtotext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_pgmnameChamador ,
                           string aP1_mensagem )
      {
         this.AV18pgmnameChamador = aP0_pgmnameChamador;
         this.AV15mensagem = aP1_mensagem;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_pgmnameChamador ,
                                 string aP1_mensagem )
      {
         debugtotext objdebugtotext;
         objdebugtotext = new debugtotext();
         objdebugtotext.AV18pgmnameChamador = aP0_pgmnameChamador;
         objdebugtotext.AV15mensagem = aP1_mensagem;
         objdebugtotext.context.SetSubmitInitialConfig(context);
         objdebugtotext.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdebugtotext);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((debugtotext)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         AV8agora = DateTimeUtil.Now( context);
         AV14LinArq = StringUtil.Format( "%1|%2: %3", context.localUtil.Format( AV8agora, "99/99/9999 99:99"), StringUtil.Trim( AV18pgmnameChamador), AV15mensagem, "", "", "", "", "", "");
         AV10data = DateTimeUtil.Now( context);
         AV9ano = (short)(DateTimeUtil.Year( AV10data));
         AV16mes = (short)(DateTimeUtil.Month( AV10data));
         AV11dia = (short)(DateTimeUtil.Day( AV10data));
         AV17nomeArquivo = "debug_" + StringUtil.Trim( AV19WWPContext.gxTpr_Username) + "_" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV9ano), 4, 0)), 4, "0") + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV16mes), 2, 0)), 2, "0") + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV11dia), 2, 0)), 2, "0") + ".txt";
         AV12dir = "C:\\temp\\";
         AV13ErroTxt = context.FileIOInstance.dfwopen( StringUtil.Trim( AV12dir)+StringUtil.Trim( AV17nomeArquivo), "", "", 1, "iso-8859-1");
         AV13ErroTxt = context.FileIOInstance.dfwptxt( AV14LinArq, 0);
         AV13ErroTxt = context.FileIOInstance.dfwnext( );
         AV13ErroTxt = context.FileIOInstance.dfwclose( );
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
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8agora = (DateTime)(DateTime.MinValue);
         AV14LinArq = "";
         AV10data = (DateTime)(DateTime.MinValue);
         AV17nomeArquivo = "";
         AV12dir = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9ano ;
      private short AV16mes ;
      private short AV11dia ;
      private short AV13ErroTxt ;
      private string AV18pgmnameChamador ;
      private string AV15mensagem ;
      private DateTime AV8agora ;
      private DateTime AV10data ;
      private string AV14LinArq ;
      private string AV17nomeArquivo ;
      private string AV12dir ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.debugtotext_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class debugtotext_services : GxRestService
   {
      [OperationContract(Name = "debugToText" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( string pgmnameChamador ,
                           string mensagem )
      {
         try
         {
            if ( ! ProcessHeaders("debugtotext") )
            {
               return  ;
            }
            debugtotext worker = new debugtotext(context);
            worker.IsMain = RunAsMain ;
            worker.execute(pgmnameChamador,mensagem );
            worker.cleanup( );
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}
