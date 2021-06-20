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
   public class gerarelatoriohorastrabalhadas : GXProcedure
   {
      public gerarelatoriohorastrabalhadas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gerarelatoriohorastrabalhadas( IGxContext context )
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
                           DateTime aP2_DataFim ,
                           int aP3_VeiculoId )
      {
         this.AV8ClientId = aP0_ClientId;
         this.AV9DataInicio = aP1_DataInicio;
         this.AV10DataFim = aP2_DataFim;
         this.AV11VeiculoId = aP3_VeiculoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 DateTime aP1_DataInicio ,
                                 DateTime aP2_DataFim ,
                                 int aP3_VeiculoId )
      {
         gerarelatoriohorastrabalhadas objgerarelatoriohorastrabalhadas;
         objgerarelatoriohorastrabalhadas = new gerarelatoriohorastrabalhadas();
         objgerarelatoriohorastrabalhadas.AV8ClientId = aP0_ClientId;
         objgerarelatoriohorastrabalhadas.AV9DataInicio = aP1_DataInicio;
         objgerarelatoriohorastrabalhadas.AV10DataFim = aP2_DataFim;
         objgerarelatoriohorastrabalhadas.AV11VeiculoId = aP3_VeiculoId;
         objgerarelatoriohorastrabalhadas.context.SetSubmitInitialConfig(context);
         objgerarelatoriohorastrabalhadas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgerarelatoriohorastrabalhadas);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gerarelatoriohorastrabalhadas)stateInfo).executePrivate();
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
         /* Using cursor P00442 */
         pr_default.execute(0, new Object[] {AV11VeiculoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106RastreadorId = P00442_A106RastreadorId[0];
            A98VeiculoId = P00442_A98VeiculoId[0];
            A111RastreadorDeviceIdFlespi = P00442_A111RastreadorDeviceIdFlespi[0];
            A100VeiculoPlaca = P00442_A100VeiculoPlaca[0];
            A111RastreadorDeviceIdFlespi = P00442_A111RastreadorDeviceIdFlespi[0];
            A100VeiculoPlaca = P00442_A100VeiculoPlaca[0];
            AV15RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            AV16VeiculoPlaca = A100VeiculoPlaca;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Execute user subroutine: 'BUSCARDADOSHORIMETRO' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( AV18ChannelMessages.gxTpr_Result.Count != 0 )
         {
            AV19horimetroFinal = (decimal)(((SdtChannelMessages_resultItem)AV18ChannelMessages.gxTpr_Result.Item(AV18ChannelMessages.gxTpr_Result.Count)).gxTpr_Engine_motorhours);
         }
         if ( AV18ChannelMessages.gxTpr_Result.Count != 0 )
         {
            AV20horimetroInicial = (decimal)(((SdtChannelMessages_resultItem)AV18ChannelMessages.gxTpr_Result.Item(1)).gxTpr_Engine_motorhours);
         }
         if ( ! (Convert.ToDecimal(0)==AV19horimetroFinal) && ! (Convert.ToDecimal(0)==AV20horimetroInicial) )
         {
            AV21TempoEmUsoPeriodo = (decimal)(AV19horimetroFinal-AV20horimetroInicial);
            AV21TempoEmUsoPeriodo = (decimal)(AV21TempoEmUsoPeriodo*60*60);
            /* Execute user subroutine: 'GERATEMPODEFUNCIONAMENTO' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'GERATEMPOOCIOSO' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'GERASDTRETORNO' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'ENVIARESULTADOSUCESSO' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'ENVIARESULTADOERRO' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'GERASDTRETORNO' Routine */
         returnInSub = false;
         AV22SDTRelatorioHorasTrabalhadasItem = new SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem(context);
         AV22SDTRelatorioHorasTrabalhadasItem.gxTpr_Datahorainicial = AV9DataInicio;
         AV22SDTRelatorioHorasTrabalhadasItem.gxTpr_Datahorafinal = AV10DataFim;
         AV22SDTRelatorioHorasTrabalhadasItem.gxTpr_Placa = AV16VeiculoPlaca;
         AV22SDTRelatorioHorasTrabalhadasItem.gxTpr_Tempofuncionamento = AV24TempoFuncionamento;
         AV22SDTRelatorioHorasTrabalhadasItem.gxTpr_Tempoocioso = AV25TempoOcioso;
      }

      protected void S121( )
      {
         /* 'GERATEMPODEFUNCIONAMENTO' Routine */
         returnInSub = false;
         AV26DiasEmUso = (short)(NumberUtil.Int( (long)(AV21TempoEmUsoPeriodo/ (decimal)(86400))));
         AV21TempoEmUsoPeriodo = (decimal)(AV21TempoEmUsoPeriodo-(AV26DiasEmUso*86400));
         AV27HorasEmUso = (long)(AV21TempoEmUsoPeriodo/ (decimal)(3600));
         AV28MinutosEmUso = (long)((AV21TempoEmUsoPeriodo-(AV27HorasEmUso*3600))/ (decimal)(60));
         AV29MinutosComDecimal = (decimal)((AV21TempoEmUsoPeriodo-(AV27HorasEmUso*3600))/ (decimal)(60));
         AV30Segundos = (decimal)((AV29MinutosComDecimal-NumberUtil.Int( (long)(AV29MinutosComDecimal)))*100);
         AV31SegundosEmUso = (long)((60*AV30Segundos)/ (decimal)(100));
         AV24TempoFuncionamento = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DiasEmUso), 4, 0)) + "D " + StringUtil.Trim( StringUtil.Str( (decimal)(AV27HorasEmUso), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV28MinutosEmUso), 16, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV31SegundosEmUso), 16, 0));
      }

      protected void S131( )
      {
         /* 'GERATEMPOOCIOSO' Routine */
         returnInSub = false;
         AV32SegundosOciososTotal = (long)((DateTimeUtil.TDiff( AV10DataFim, AV9DataInicio))-AV21TempoEmUsoPeriodo);
         AV33DiasOciosos = (short)(NumberUtil.Int( (long)(AV32SegundosOciososTotal/ (decimal)(86400))));
         AV32SegundosOciososTotal = (long)(AV32SegundosOciososTotal-(AV33DiasOciosos*86400));
         AV34HorasOciosas = (long)(AV32SegundosOciososTotal/ (decimal)(3600));
         AV35MinutosOciosos = (long)((AV32SegundosOciososTotal-(AV34HorasOciosas*3600))/ (decimal)(60));
         AV36MinutosComDecimalOciosos = (decimal)((AV32SegundosOciososTotal-(AV34HorasOciosas*3600))/ (decimal)(60));
         AV37SegundosOciososCalculo = (decimal)((AV36MinutosComDecimalOciosos-NumberUtil.Int( (long)(AV36MinutosComDecimalOciosos)))*100);
         AV38SegundosOciosos = (long)((60*AV37SegundosOciososCalculo)/ (decimal)(100));
         if ( AV38SegundosOciosos + AV31SegundosEmUso != 60 )
         {
            AV38SegundosOciosos = (long)(AV38SegundosOciosos+1);
         }
         AV25TempoOcioso = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DiasOciosos), 4, 0)) + "D " + StringUtil.Trim( StringUtil.Str( (decimal)(AV34HorasOciosas), 10, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV35MinutosOciosos), 16, 0)) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV38SegundosOciosos), 16, 0));
      }

      protected void S141( )
      {
         /* 'ENVIARESULTADOSUCESSO' Routine */
         returnInSub = false;
         AV39WebNotificationInfo.gxTpr_Id = "RelatorioHorasTrabalhadas_Sucesso";
         AV39WebNotificationInfo.gxTpr_Message = AV22SDTRelatorioHorasTrabalhadasItem.ToJSonString(false, true);
         AV39WebNotificationInfo.gxTpr_Object = "RelatorioHorasTrabalhadas";
         AV40ServerSocket.notifyclient( AV8ClientId,  AV39WebNotificationInfo);
      }

      protected void S151( )
      {
         /* 'ENVIARESULTADOERRO' Routine */
         returnInSub = false;
         AV39WebNotificationInfo.gxTpr_Id = "RelatorioHorasTrabalhadas_Erro";
         AV39WebNotificationInfo.gxTpr_Message = "";
         AV39WebNotificationInfo.gxTpr_Object = "RelatorioHorasTrabalhadas";
         AV40ServerSocket.notifyclient( AV8ClientId,  AV39WebNotificationInfo);
      }

      protected void S161( )
      {
         /* 'BUSCARDADOSHORIMETRO' Routine */
         returnInSub = false;
         AV12TimeStampInicial = new SdtUtil(context).datetimetotimestamp(AV9DataInicio);
         AV13TimeStampFinal = new SdtUtil(context).datetimetotimestamp(AV10DataFim);
         AV14URL = "https://flespi.io/gw/devices/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15RastreadorDeviceIdFlespi), 16, 0)) + "/messages?data={\"fields\":\"engine.motorhours\",\"to\":" + StringUtil.Trim( AV13TimeStampFinal) + ",\"from\":" + StringUtil.Trim( AV12TimeStampInicial) + "}";
         /* Using cursor P00443 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A130MqttParametrosTokenFlespi = P00443_A130MqttParametrosTokenFlespi[0];
            A129MqttParametrosId = P00443_A129MqttParametrosId[0];
            AV42Header = "FlespiToken " + StringUtil.Trim( A130MqttParametrosTokenFlespi);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV17HttpClient.AddHeader("Authorization", AV42Header);
         AV17HttpClient.Execute("GET", AV14URL);
         AV18ChannelMessages.FromJSonString(AV17HttpClient.ToString(), null);
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
         scmdbuf = "";
         P00442_A106RastreadorId = new int[1] ;
         P00442_A98VeiculoId = new int[1] ;
         P00442_A111RastreadorDeviceIdFlespi = new long[1] ;
         P00442_A100VeiculoPlaca = new string[] {""} ;
         A100VeiculoPlaca = "";
         AV16VeiculoPlaca = "";
         AV18ChannelMessages = new SdtChannelMessages(context);
         AV22SDTRelatorioHorasTrabalhadasItem = new SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem(context);
         AV24TempoFuncionamento = "";
         AV25TempoOcioso = "";
         AV39WebNotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV40ServerSocket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV12TimeStampInicial = "";
         AV13TimeStampFinal = "";
         AV14URL = "";
         P00443_A130MqttParametrosTokenFlespi = new string[] {""} ;
         P00443_A129MqttParametrosId = new int[1] ;
         A130MqttParametrosTokenFlespi = "";
         AV42Header = "";
         AV17HttpClient = new GxHttpClient( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gerarelatoriohorastrabalhadas__default(),
            new Object[][] {
                new Object[] {
               P00442_A106RastreadorId, P00442_A98VeiculoId, P00442_A111RastreadorDeviceIdFlespi, P00442_A100VeiculoPlaca
               }
               , new Object[] {
               P00443_A130MqttParametrosTokenFlespi, P00443_A129MqttParametrosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV26DiasEmUso ;
      private short AV33DiasOciosos ;
      private int AV11VeiculoId ;
      private int A106RastreadorId ;
      private int A98VeiculoId ;
      private int A129MqttParametrosId ;
      private long A111RastreadorDeviceIdFlespi ;
      private long AV15RastreadorDeviceIdFlespi ;
      private long AV27HorasEmUso ;
      private long AV28MinutosEmUso ;
      private long AV31SegundosEmUso ;
      private long AV32SegundosOciososTotal ;
      private long AV34HorasOciosas ;
      private long AV35MinutosOciosos ;
      private long AV38SegundosOciosos ;
      private decimal AV19horimetroFinal ;
      private decimal AV20horimetroInicial ;
      private decimal AV21TempoEmUsoPeriodo ;
      private decimal AV29MinutosComDecimal ;
      private decimal AV30Segundos ;
      private decimal AV36MinutosComDecimalOciosos ;
      private decimal AV37SegundosOciososCalculo ;
      private string scmdbuf ;
      private DateTime AV9DataInicio ;
      private DateTime AV10DataFim ;
      private bool returnInSub ;
      private string AV8ClientId ;
      private string A100VeiculoPlaca ;
      private string AV16VeiculoPlaca ;
      private string AV24TempoFuncionamento ;
      private string AV25TempoOcioso ;
      private string AV12TimeStampInicial ;
      private string AV13TimeStampFinal ;
      private string AV14URL ;
      private string A130MqttParametrosTokenFlespi ;
      private string AV42Header ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00442_A106RastreadorId ;
      private int[] P00442_A98VeiculoId ;
      private long[] P00442_A111RastreadorDeviceIdFlespi ;
      private string[] P00442_A100VeiculoPlaca ;
      private string[] P00443_A130MqttParametrosTokenFlespi ;
      private int[] P00443_A129MqttParametrosId ;
      private GxHttpClient AV17HttpClient ;
      private SdtChannelMessages AV18ChannelMessages ;
      private SdtSDTRelatorioHorasTrabalhadas_SDTRelatorioHorasTrabalhadasItem AV22SDTRelatorioHorasTrabalhadasItem ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV39WebNotificationInfo ;
      private GeneXus.Core.genexus.server.SdtSocket AV40ServerSocket ;
   }

   public class gerarelatoriohorastrabalhadas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00442;
          prmP00442 = new Object[] {
          new Object[] {"@AV11VeiculoId",SqlDbType.Int,8,0}
          };
          Object[] prmP00443;
          prmP00443 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00442", "SELECT TOP 1 T1.[RastreadorId], T1.[VeiculoId], T2.[RastreadorDeviceIdFlespi], T3.[VeiculoPlaca] FROM (([VeiculoRastreador] T1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = T1.[RastreadorId]) INNER JOIN [Veiculo] T3 ON T3.[VeiculoId] = T1.[VeiculoId]) WHERE T1.[VeiculoId] = @AV11VeiculoId ORDER BY T1.[VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00442,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00443", "SELECT TOP 1 [MqttParametrosTokenFlespi], [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00443,1, GxCacheFrequency.OFF ,false,true )
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
             case 0 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.getInt(2);
                table[2][0] = rslt.getLong(3);
                table[3][0] = rslt.getVarchar(4);
                return;
             case 1 :
                table[0][0] = rslt.getVarchar(1);
                table[1][0] = rslt.getInt(2);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
