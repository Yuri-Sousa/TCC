using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
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
   public class aexportrelatoriodehorastrabalhadaspdf : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ClientId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8ClientId = gxfirstwebparm;
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aexportrelatoriodehorastrabalhadaspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aexportrelatoriodehorastrabalhadaspdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_ClientId )
      {
         this.AV8ClientId = aP0_ClientId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId )
      {
         aexportrelatoriodehorastrabalhadaspdf objaexportrelatoriodehorastrabalhadaspdf;
         objaexportrelatoriodehorastrabalhadaspdf = new aexportrelatoriodehorastrabalhadaspdf();
         objaexportrelatoriodehorastrabalhadaspdf.AV8ClientId = aP0_ClientId;
         objaexportrelatoriodehorastrabalhadaspdf.context.SetSubmitInitialConfig(context);
         objaexportrelatoriodehorastrabalhadaspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaexportrelatoriodehorastrabalhadaspdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aexportrelatoriodehorastrabalhadaspdf)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV23Now = DateTimeUtil.ServerNow( context, pr_default);
            AV14InformacoesGeracao = "Gerado em " + context.localUtil.Format( AV23Now, "99/99/99 99:99");
            AV12CacheName = "RelatorioDeHorasTrabalhadas" + StringUtil.Trim( AV8ClientId);
            AV25SDTRelatorioHorasTrabalhadas.FromJSonString(CacheAPI.Database.Get(AV12CacheName), null);
            CacheAPI.Database.Remove(AV12CacheName);
            H430( false, 118) ;
            getPrinter().GxDrawRect(0, Gx_line+0, 796, Gx_line+118, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Relatório de Horas Trabalhadas", 30, Gx_line+30, 766, Gx_line+63, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14InformacoesGeracao, "")), 0, Gx_line+93, 786, Gx_line+108, 2, 0, 0, 2) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+118);
            H430( false, 37) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Placa", 22, Gx_line+10, 169, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Tempo de Funcionamento", 173, Gx_line+10, 320, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Tempo Ocioso", 324, Gx_line+10, 471, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Data Inicial", 475, Gx_line+10, 622, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Data Final", 626, Gx_line+10, 774, Gx_line+27, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+37);
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV25SDTRelatorioHorasTrabalhadas.Count )
            {
               AV30SDTRelatorioHorasTrabalhadasItem = ((SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem)AV25SDTRelatorioHorasTrabalhadas.Item(AV33GXV1));
               AV16Placa = StringUtil.Trim( AV30SDTRelatorioHorasTrabalhadasItem.gxTpr_Placa);
               AV28DataInicial = AV30SDTRelatorioHorasTrabalhadasItem.gxTpr_Datahorainicial;
               AV29DataFinal = AV30SDTRelatorioHorasTrabalhadasItem.gxTpr_Datahorafinal;
               AV26TempoDeFuncionamento = StringUtil.Trim( AV30SDTRelatorioHorasTrabalhadasItem.gxTpr_Tempofuncionamento);
               AV27TempoOcioso = StringUtil.Trim( AV30SDTRelatorioHorasTrabalhadasItem.gxTpr_Tempoocioso);
               H430( false, 29) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Placa, "")), 22, Gx_line+10, 169, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TempoDeFuncionamento, "")), 173, Gx_line+10, 320, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TempoOcioso, "")), 324, Gx_line+10, 471, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV28DataInicial, "99/99/99 99:99"), 475, Gx_line+10, 622, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV29DataFinal, "99/99/99 99:99"), 626, Gx_line+10, 774, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(20, Gx_line+28, 776, Gx_line+28, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+29);
               AV33GXV1 = (int)(AV33GXV1+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H430( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException e )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException e )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H430( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV23Now = (DateTime)(DateTime.MinValue);
         AV14InformacoesGeracao = "";
         AV12CacheName = "";
         AV25SDTRelatorioHorasTrabalhadas = new GXBaseCollection<SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem>( context, "SDTRelatorioHorasTrabalhadasItem", "RastreamentoTCC");
         AV30SDTRelatorioHorasTrabalhadasItem = new SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem(context);
         AV16Placa = "";
         AV28DataInicial = (DateTime)(DateTime.MinValue);
         AV29DataFinal = (DateTime)(DateTime.MinValue);
         AV26TempoDeFuncionamento = "";
         AV27TempoOcioso = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aexportrelatoriodehorastrabalhadaspdf__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV33GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime AV23Now ;
      private DateTime AV28DataInicial ;
      private DateTime AV29DataFinal ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV8ClientId ;
      private string AV14InformacoesGeracao ;
      private string AV12CacheName ;
      private string AV16Placa ;
      private string AV26TempoDeFuncionamento ;
      private string AV27TempoOcioso ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem> AV25SDTRelatorioHorasTrabalhadas ;
      private SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem AV30SDTRelatorioHorasTrabalhadasItem ;
   }

   public class aexportrelatoriodehorastrabalhadaspdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       dynamic table = buf;
       switch ( cursor )
       {
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

 }

}
