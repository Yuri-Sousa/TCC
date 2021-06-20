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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportrelatorioposicaoexcel : GXProcedure
   {
      public exportrelatorioposicaoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public exportrelatorioposicaoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem> aP0_SDTRelatorioPosicoes ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV8SDTRelatorioPosicoes = aP0_SDTRelatorioPosicoes;
         this.AV15Filename = "" ;
         this.AV10ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV15Filename;
         aP2_ErrorMessage=this.AV10ErrorMessage;
      }

      public string executeUdp( GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem> aP0_SDTRelatorioPosicoes ,
                                out string aP1_Filename )
      {
         execute(aP0_SDTRelatorioPosicoes, out aP1_Filename, out aP2_ErrorMessage);
         return AV10ErrorMessage ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem> aP0_SDTRelatorioPosicoes ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         exportrelatorioposicaoexcel objexportrelatorioposicaoexcel;
         objexportrelatorioposicaoexcel = new exportrelatorioposicaoexcel();
         objexportrelatorioposicaoexcel.AV8SDTRelatorioPosicoes = aP0_SDTRelatorioPosicoes;
         objexportrelatorioposicaoexcel.AV15Filename = "" ;
         objexportrelatorioposicaoexcel.AV10ErrorMessage = "" ;
         objexportrelatorioposicaoexcel.context.SetSubmitInitialConfig(context);
         objexportrelatorioposicaoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportrelatorioposicaoexcel);
         aP1_Filename=this.AV15Filename;
         aP2_ErrorMessage=this.AV10ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportrelatorioposicaoexcel)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = 1;
         AV13FirstColumn = 1;
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV14Random = (int)(NumberUtil.Random( )*10000);
         AV15Filename = "RelatorioPosicao-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
         AV16ExcelDocument.Open(AV15Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV16ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Data/Hora";
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = "Placa";
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = "Lat/Lng";
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = "Ignição";
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "Tensão";
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = "Velocidade";
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = "Odômetro";
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Color = 11;
         AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = "Horímetro";
      }

      protected void S141( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV8SDTRelatorioPosicoes.Count )
         {
            AV11SDTRelatorioPosicoesItem = ((SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem)AV8SDTRelatorioPosicoes.Item(AV19GXV1));
            AV12CellRow = (int)(AV12CellRow+1);
            AV16ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Date = AV11SDTRelatorioPosicoesItem.gxTpr_Datahora;
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = AV11SDTRelatorioPosicoesItem.gxTpr_Placa;
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = AV11SDTRelatorioPosicoesItem.gxTpr_Latlng;
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = AV11SDTRelatorioPosicoesItem.gxTpr_Ignicao;
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = AV11SDTRelatorioPosicoesItem.gxTpr_Tensao;
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = AV11SDTRelatorioPosicoesItem.gxTpr_Velocidade;
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = AV11SDTRelatorioPosicoesItem.gxTpr_Odometro;
            AV16ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = AV11SDTRelatorioPosicoesItem.gxTpr_Horimetro;
            AV19GXV1 = (int)(AV19GXV1+1);
         }
      }

      protected void S151( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV16ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV16ExcelDocument.Close();
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV16ExcelDocument.ErrCode != 0 )
         {
            AV15Filename = "";
            AV10ErrorMessage = AV16ExcelDocument.ErrDescription;
            AV16ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
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
         AV15Filename = "";
         AV10ErrorMessage = "";
         AV16ExcelDocument = new ExcelDocumentI();
         AV11SDTRelatorioPosicoesItem = new SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int AV14Random ;
      private int AV19GXV1 ;
      private bool returnInSub ;
      private string AV15Filename ;
      private string AV10ErrorMessage ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
      private ExcelDocumentI AV16ExcelDocument ;
      private GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem> AV8SDTRelatorioPosicoes ;
      private SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem AV11SDTRelatorioPosicoesItem ;
   }

}
