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
   public class gerarelatorioutilizacao : GXProcedure
   {
      public gerarelatorioutilizacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gerarelatorioutilizacao( IGxContext context )
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
                           int aP3_VeiculoId ,
                           decimal aP4_ValorCombustivelParametro ,
                           int aP5_ConsumoPresumido )
      {
         this.AV8ClientId = aP0_ClientId;
         this.AV9DataInicio = aP1_DataInicio;
         this.AV10DataFim = aP2_DataFim;
         this.AV11VeiculoId = aP3_VeiculoId;
         this.AV30ValorCombustivelParametro = aP4_ValorCombustivelParametro;
         this.AV13ConsumoPresumido = aP5_ConsumoPresumido;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 DateTime aP1_DataInicio ,
                                 DateTime aP2_DataFim ,
                                 int aP3_VeiculoId ,
                                 decimal aP4_ValorCombustivelParametro ,
                                 int aP5_ConsumoPresumido )
      {
         gerarelatorioutilizacao objgerarelatorioutilizacao;
         objgerarelatorioutilizacao = new gerarelatorioutilizacao();
         objgerarelatorioutilizacao.AV8ClientId = aP0_ClientId;
         objgerarelatorioutilizacao.AV9DataInicio = aP1_DataInicio;
         objgerarelatorioutilizacao.AV10DataFim = aP2_DataFim;
         objgerarelatorioutilizacao.AV11VeiculoId = aP3_VeiculoId;
         objgerarelatorioutilizacao.AV30ValorCombustivelParametro = aP4_ValorCombustivelParametro;
         objgerarelatorioutilizacao.AV13ConsumoPresumido = aP5_ConsumoPresumido;
         objgerarelatorioutilizacao.context.SetSubmitInitialConfig(context);
         objgerarelatorioutilizacao.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgerarelatorioutilizacao);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gerarelatorioutilizacao)stateInfo).executePrivate();
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
         /* Using cursor P00472 */
         pr_default.execute(0, new Object[] {AV11VeiculoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106RastreadorId = P00472_A106RastreadorId[0];
            A98VeiculoId = P00472_A98VeiculoId[0];
            A111RastreadorDeviceIdFlespi = P00472_A111RastreadorDeviceIdFlespi[0];
            A100VeiculoPlaca = P00472_A100VeiculoPlaca[0];
            A111RastreadorDeviceIdFlespi = P00472_A111RastreadorDeviceIdFlespi[0];
            A100VeiculoPlaca = P00472_A100VeiculoPlaca[0];
            AV17RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            AV18VeiculoPlaca = A100VeiculoPlaca;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Execute user subroutine: 'BUSCARDADOSODOMETRO' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( AV21ChannelMessages.gxTpr_Result.Count != 0 )
         {
            AV22OdometroFinal = (decimal)(((SdtChannelMessages_resultItem)AV21ChannelMessages.gxTpr_Result.Item(AV21ChannelMessages.gxTpr_Result.Count)).gxTpr_Gnss_vehicle_mileage);
         }
         if ( AV21ChannelMessages.gxTpr_Result.Count != 0 )
         {
            AV23OdometroInicial = (decimal)(((SdtChannelMessages_resultItem)AV21ChannelMessages.gxTpr_Result.Item(1)).gxTpr_Gnss_vehicle_mileage);
         }
         if ( ! (Convert.ToDecimal(0)==AV22OdometroFinal) && ! (Convert.ToDecimal(0)==AV23OdometroInicial) )
         {
            AV28DistanciaTotal = (decimal)(AV22OdometroFinal-AV23OdometroInicial);
            AV29ConsumoTotal = (decimal)(AV28DistanciaTotal/ (decimal)(AV13ConsumoPresumido));
            AV12ValorCombustivel = (decimal)(AV29ConsumoTotal*AV30ValorCombustivelParametro);
            AV27SDTRelatorioUtilizacaoItem = new SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem(context);
            AV27SDTRelatorioUtilizacaoItem.gxTpr_Datahorainicial = AV9DataInicio;
            AV27SDTRelatorioUtilizacaoItem.gxTpr_Datahorafinal = AV10DataFim;
            AV27SDTRelatorioUtilizacaoItem.gxTpr_Consumototal = AV29ConsumoTotal;
            AV27SDTRelatorioUtilizacaoItem.gxTpr_Distanciatotal = AV28DistanciaTotal;
            AV27SDTRelatorioUtilizacaoItem.gxTpr_Placa = AV18VeiculoPlaca;
            AV27SDTRelatorioUtilizacaoItem.gxTpr_Valorcombustivel = AV12ValorCombustivel;
            AV26WebNotificationInfo.gxTpr_Id = "RelatorioUtilizacao_Sucesso";
            AV26WebNotificationInfo.gxTpr_Message = AV27SDTRelatorioUtilizacaoItem.ToJSonString(false, true);
            AV26WebNotificationInfo.gxTpr_Object = "RelatorioUtilizacao";
            AV25ServerSocket.notifyclient( AV8ClientId,  AV26WebNotificationInfo);
         }
         else
         {
            AV26WebNotificationInfo.gxTpr_Id = "RelatorioUtilizacao_Erro";
            AV26WebNotificationInfo.gxTpr_Message = "";
            AV26WebNotificationInfo.gxTpr_Object = "RelatorioUtilizacao";
            AV25ServerSocket.notifyclient( AV8ClientId,  AV26WebNotificationInfo);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'BUSCARDADOSODOMETRO' Routine */
         returnInSub = false;
         AV14TimeStampInicial = new SdtUtil(context).datetimetotimestamp(AV9DataInicio);
         AV15TimeStampFinal = new SdtUtil(context).datetimetotimestamp(AV10DataFim);
         AV20URL = "https://flespi.io/gw/devices/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV17RastreadorDeviceIdFlespi), 16, 0)) + "/messages?data={\"fields\":\"gnss.vehicle.mileage\",\"to\":" + StringUtil.Trim( AV15TimeStampFinal) + ",\"from\":" + StringUtil.Trim( AV14TimeStampInicial) + "}";
         /* Using cursor P00473 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A130MqttParametrosTokenFlespi = P00473_A130MqttParametrosTokenFlespi[0];
            A129MqttParametrosId = P00473_A129MqttParametrosId[0];
            AV31Header = "FlespiToken " + StringUtil.Trim( A130MqttParametrosTokenFlespi);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV19HttpClient.AddHeader("Authorization", AV31Header);
         AV19HttpClient.Execute("GET", AV20URL);
         AV21ChannelMessages.FromJSonString(AV19HttpClient.ToString(), null);
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
         P00472_A106RastreadorId = new int[1] ;
         P00472_A98VeiculoId = new int[1] ;
         P00472_A111RastreadorDeviceIdFlespi = new long[1] ;
         P00472_A100VeiculoPlaca = new string[] {""} ;
         A100VeiculoPlaca = "";
         AV18VeiculoPlaca = "";
         AV21ChannelMessages = new SdtChannelMessages(context);
         AV27SDTRelatorioUtilizacaoItem = new SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem(context);
         AV26WebNotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV25ServerSocket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV14TimeStampInicial = "";
         AV15TimeStampFinal = "";
         AV20URL = "";
         P00473_A130MqttParametrosTokenFlespi = new string[] {""} ;
         P00473_A129MqttParametrosId = new int[1] ;
         A130MqttParametrosTokenFlespi = "";
         AV31Header = "";
         AV19HttpClient = new GxHttpClient( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gerarelatorioutilizacao__default(),
            new Object[][] {
                new Object[] {
               P00472_A106RastreadorId, P00472_A98VeiculoId, P00472_A111RastreadorDeviceIdFlespi, P00472_A100VeiculoPlaca
               }
               , new Object[] {
               P00473_A130MqttParametrosTokenFlespi, P00473_A129MqttParametrosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11VeiculoId ;
      private int AV13ConsumoPresumido ;
      private int A106RastreadorId ;
      private int A98VeiculoId ;
      private int A129MqttParametrosId ;
      private long A111RastreadorDeviceIdFlespi ;
      private long AV17RastreadorDeviceIdFlespi ;
      private decimal AV30ValorCombustivelParametro ;
      private decimal AV22OdometroFinal ;
      private decimal AV23OdometroInicial ;
      private decimal AV28DistanciaTotal ;
      private decimal AV29ConsumoTotal ;
      private decimal AV12ValorCombustivel ;
      private string scmdbuf ;
      private DateTime AV9DataInicio ;
      private DateTime AV10DataFim ;
      private bool returnInSub ;
      private string AV8ClientId ;
      private string A100VeiculoPlaca ;
      private string AV18VeiculoPlaca ;
      private string AV14TimeStampInicial ;
      private string AV15TimeStampFinal ;
      private string AV20URL ;
      private string A130MqttParametrosTokenFlespi ;
      private string AV31Header ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00472_A106RastreadorId ;
      private int[] P00472_A98VeiculoId ;
      private long[] P00472_A111RastreadorDeviceIdFlespi ;
      private string[] P00472_A100VeiculoPlaca ;
      private string[] P00473_A130MqttParametrosTokenFlespi ;
      private int[] P00473_A129MqttParametrosId ;
      private GxHttpClient AV19HttpClient ;
      private SdtChannelMessages AV21ChannelMessages ;
      private GeneXus.Core.genexus.server.SdtSocket AV25ServerSocket ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV26WebNotificationInfo ;
      private SdtSDTRelatorioUtilizacao_SDTRelatorioUtilizacaoItem AV27SDTRelatorioUtilizacaoItem ;
   }

   public class gerarelatorioutilizacao__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00472;
          prmP00472 = new Object[] {
          new Object[] {"@AV11VeiculoId",SqlDbType.Int,8,0}
          };
          Object[] prmP00473;
          prmP00473 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00472", "SELECT TOP 1 T1.[RastreadorId], T1.[VeiculoId], T2.[RastreadorDeviceIdFlespi], T3.[VeiculoPlaca] FROM (([VeiculoRastreador] T1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = T1.[RastreadorId]) INNER JOIN [Veiculo] T3 ON T3.[VeiculoId] = T1.[VeiculoId]) WHERE T1.[VeiculoId] = @AV11VeiculoId ORDER BY T1.[VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00472,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00473", "SELECT TOP 1 [MqttParametrosTokenFlespi], [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00473,1, GxCacheFrequency.OFF ,false,true )
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
