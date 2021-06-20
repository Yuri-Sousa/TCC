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
   public class aexportrelatorioposicaopdf : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9DataInicio = context.localUtil.ParseDTimeParm( GetPar( "DataInicio"));
                  AV10DataFim = context.localUtil.ParseDTimeParm( GetPar( "DataFim"));
               }
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

      public aexportrelatorioposicaopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aexportrelatorioposicaopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_ClientId ,
                           DateTime aP1_DataInicio ,
                           DateTime aP2_DataFim )
      {
         this.AV8ClientId = aP0_ClientId;
         this.AV9DataInicio = aP1_DataInicio;
         this.AV10DataFim = aP2_DataFim;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 DateTime aP1_DataInicio ,
                                 DateTime aP2_DataFim )
      {
         aexportrelatorioposicaopdf objaexportrelatorioposicaopdf;
         objaexportrelatorioposicaopdf = new aexportrelatorioposicaopdf();
         objaexportrelatorioposicaopdf.AV8ClientId = aP0_ClientId;
         objaexportrelatorioposicaopdf.AV9DataInicio = aP1_DataInicio;
         objaexportrelatorioposicaopdf.AV10DataFim = aP2_DataFim;
         objaexportrelatorioposicaopdf.context.SetSubmitInitialConfig(context);
         objaexportrelatorioposicaopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaexportrelatorioposicaopdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aexportrelatorioposicaopdf)stateInfo).executePrivate();
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
            AV14InformacoesGeracao = context.localUtil.Format( AV9DataInicio, "99/99/99 99:99") + " até " + context.localUtil.Format( AV10DataFim, "99/99/99 99:99") + ", Gerado em " + context.localUtil.Format( AV23Now, "99/99/99 99:99");
            AV12CacheName = "RelatorioPosicao_" + StringUtil.Trim( AV8ClientId);
            AV13SDTRelatorioPosicoes.FromJSonString(CacheAPI.Database.Get(AV12CacheName), null);
            CacheAPI.Database.Remove(AV12CacheName);
            H3X0( false, 118) ;
            getPrinter().GxDrawRect(0, Gx_line+0, 1138, Gx_line+118, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Relatório de Posições", 30, Gx_line+30, 1108, Gx_line+63, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14InformacoesGeracao, "")), 0, Gx_line+93, 1128, Gx_line+108, 2, 0, 0, 2) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+118);
            H3X0( false, 37) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data/Hora", 22, Gx_line+10, 155, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Placa", 159, Gx_line+10, 292, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Lat/Lng", 296, Gx_line+10, 429, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Ignição", 433, Gx_line+10, 566, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Tensão", 570, Gx_line+10, 703, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Velocidade", 707, Gx_line+10, 840, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Odômetro", 844, Gx_line+10, 978, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Horímetro", 982, Gx_line+10, 1116, Gx_line+27, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+37);
            AV27GXV1 = 1;
            while ( AV27GXV1 <= AV13SDTRelatorioPosicoes.Count )
            {
               AV24SDTRelatorioPosicoesItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV13SDTRelatorioPosicoes.Item(AV27GXV1));
               AV15DataHora = AV24SDTRelatorioPosicoesItem.gxTpr_Datahora;
               AV16Placa = AV24SDTRelatorioPosicoesItem.gxTpr_Placa;
               AV17LatLng = StringUtil.Trim( AV24SDTRelatorioPosicoesItem.gxTpr_Latlng);
               AV18Ignicao = AV24SDTRelatorioPosicoesItem.gxTpr_Ignicao;
               AV19Tensao = AV24SDTRelatorioPosicoesItem.gxTpr_Tensao;
               AV20Velocidade = AV24SDTRelatorioPosicoesItem.gxTpr_Velocidade;
               AV22Horimetro = StringUtil.Trim( AV24SDTRelatorioPosicoesItem.gxTpr_Horimetro);
               AV21Odometro = StringUtil.Trim( AV24SDTRelatorioPosicoesItem.gxTpr_Odometro);
               H3X0( false, 29) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15DataHora, "99/99/99 99:99"), 22, Gx_line+10, 155, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Placa, "")), 159, Gx_line+10, 292, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17LatLng, "")), 296, Gx_line+10, 429, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Ignicao, "")), 433, Gx_line+10, 566, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Tensao, "")), 570, Gx_line+10, 703, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20Velocidade, "")), 707, Gx_line+10, 840, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Odometro, "")), 844, Gx_line+10, 978, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Horimetro, "")), 982, Gx_line+10, 1116, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(20, Gx_line+28, 1118, Gx_line+28, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+29);
               AV27GXV1 = (int)(AV27GXV1+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H3X0( true, 0) ;
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

      protected void H3X0( bool bFoot ,
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
         AV13SDTRelatorioPosicoes = new GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem>( context, "SDTRelatorioPosicoesItem", "RastreamentoTCC");
         AV24SDTRelatorioPosicoesItem = new SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem(context);
         AV15DataHora = (DateTime)(DateTime.MinValue);
         AV16Placa = "";
         AV17LatLng = "";
         AV18Ignicao = "";
         AV19Tensao = "";
         AV20Velocidade = "";
         AV22Horimetro = "";
         AV21Odometro = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aexportrelatorioposicaopdf__default(),
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
      private int AV27GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime AV9DataInicio ;
      private DateTime AV10DataFim ;
      private DateTime AV23Now ;
      private DateTime AV15DataHora ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV8ClientId ;
      private string AV14InformacoesGeracao ;
      private string AV12CacheName ;
      private string AV16Placa ;
      private string AV17LatLng ;
      private string AV18Ignicao ;
      private string AV19Tensao ;
      private string AV20Velocidade ;
      private string AV22Horimetro ;
      private string AV21Odometro ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem> AV13SDTRelatorioPosicoes ;
      private SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem AV24SDTRelatorioPosicoesItem ;
   }

   public class aexportrelatorioposicaopdf__default : DataStoreHelperBase, IDataStoreHelper
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
