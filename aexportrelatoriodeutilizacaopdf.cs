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
   public class aexportrelatoriodeutilizacaopdf : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public aexportrelatoriodeutilizacaopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aexportrelatoriodeutilizacaopdf( IGxContext context )
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
         aexportrelatoriodeutilizacaopdf objaexportrelatoriodeutilizacaopdf;
         objaexportrelatoriodeutilizacaopdf = new aexportrelatoriodeutilizacaopdf();
         objaexportrelatoriodeutilizacaopdf.AV8ClientId = aP0_ClientId;
         objaexportrelatoriodeutilizacaopdf.context.SetSubmitInitialConfig(context);
         objaexportrelatoriodeutilizacaopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaexportrelatoriodeutilizacaopdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aexportrelatoriodeutilizacaopdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 9, 11909, 16834, 0, 1, 1, 0, 1, 1) )
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
            AV12CacheName = "RelatorioUtilizacao_" + StringUtil.Trim( AV8ClientId);
            AV31SDTRelatorioUtilizacao.FromJSonString(CacheAPI.Database.Get(AV12CacheName), null);
            CacheAPI.Database.Remove(AV12CacheName);
            H490( false, 118) ;
            getPrinter().GxDrawRect(0, Gx_line+0, 1138, Gx_line+118, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Relatório de Utilização", 30, Gx_line+30, 1108, Gx_line+63, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14InformacoesGeracao, "")), 0, Gx_line+93, 1128, Gx_line+108, 2, 0, 0, 2) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+118);
            H490( false, 37) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Placa", 22, Gx_line+10, 201, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Distância Total (Km)", 205, Gx_line+10, 384, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Data Inicial", 388, Gx_line+10, 567, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Data Final", 571, Gx_line+10, 750, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Consumo Total (L)", 754, Gx_line+10, 933, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Total Gasto (R$)", 937, Gx_line+10, 1116, Gx_line+27, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+37);
            AV38GXV1 = 1;
            while ( AV38GXV1 <= AV31SDTRelatorioUtilizacao.Count )
            {
               AV35SDTRelatorioUtilizacaoItem = ((SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem)AV31SDTRelatorioUtilizacao.Item(AV38GXV1));
               AV16Placa = StringUtil.Trim( AV35SDTRelatorioUtilizacaoItem.gxTpr_Placa);
               AV32DistanciaTotal = StringUtil.Trim( StringUtil.Str( AV35SDTRelatorioUtilizacaoItem.gxTpr_Distanciatotal, 10, 2));
               AV28DataInicial = AV35SDTRelatorioUtilizacaoItem.gxTpr_Datahorainicial;
               AV29DataFinal = AV35SDTRelatorioUtilizacaoItem.gxTpr_Datahorafinal;
               AV33ConsumoTotal = StringUtil.Trim( StringUtil.Str( AV35SDTRelatorioUtilizacaoItem.gxTpr_Consumototal, 10, 2));
               AV34ValorCombustivel = StringUtil.Trim( StringUtil.Str( AV35SDTRelatorioUtilizacaoItem.gxTpr_Valorcombustivel, 16, 2));
               H490( false, 29) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Placa, "")), 22, Gx_line+10, 201, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DistanciaTotal, "")), 205, Gx_line+10, 384, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV28DataInicial, "99/99/99 99:99"), 388, Gx_line+10, 567, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV29DataFinal, "99/99/99 99:99"), 571, Gx_line+10, 750, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33ConsumoTotal, "")), 754, Gx_line+10, 933, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34ValorCombustivel, "")), 937, Gx_line+10, 1116, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(20, Gx_line+28, 1118, Gx_line+28, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+29);
               AV38GXV1 = (int)(AV38GXV1+1);
            }
            H490( false, 25) ;
            getPrinter().GxDrawRect(0, Gx_line+0, 1138, Gx_line+25, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Observação: O cálculo da distância(km) no intervalo de tempo analisado é feito por GPS, logo pode existir uma diferença (+/-) de 5 a 10%.", 30, Gx_line+5, 1108, Gx_line+20, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+25);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H490( true, 0) ;
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

      protected void H490( bool bFoot ,
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
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         AV31SDTRelatorioUtilizacao = new GXBaseCollection<SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem>( context, "SDTRelatorioUtilizacaoItem", "RastreamentoTCC");
         AV35SDTRelatorioUtilizacaoItem = new SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem(context);
         AV16Placa = "";
         AV32DistanciaTotal = "";
         AV28DataInicial = (DateTime)(DateTime.MinValue);
         AV29DataFinal = (DateTime)(DateTime.MinValue);
         AV33ConsumoTotal = "";
         AV34ValorCombustivel = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aexportrelatoriodeutilizacaopdf__default(),
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
      private int AV38GXV1 ;
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
      private string AV32DistanciaTotal ;
      private string AV33ConsumoTotal ;
      private string AV34ValorCombustivel ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem> AV31SDTRelatorioUtilizacao ;
      private SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem AV35SDTRelatorioUtilizacaoItem ;
   }

   public class aexportrelatoriodeutilizacaopdf__default : DataStoreHelperBase, IDataStoreHelper
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
