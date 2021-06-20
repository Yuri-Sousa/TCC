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
   public class gerarrelatorioposicao : GXProcedure
   {
      public gerarrelatorioposicao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public gerarrelatorioposicao( IGxContext context )
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
                           DateTime aP1_DataInicial ,
                           DateTime aP2_DataFinal ,
                           int aP3_VeiculoId )
      {
         this.AV8ClientId = aP0_ClientId;
         this.AV9DataInicial = aP1_DataInicial;
         this.AV10DataFinal = aP2_DataFinal;
         this.AV12VeiculoId = aP3_VeiculoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 DateTime aP1_DataInicial ,
                                 DateTime aP2_DataFinal ,
                                 int aP3_VeiculoId )
      {
         gerarrelatorioposicao objgerarrelatorioposicao;
         objgerarrelatorioposicao = new gerarrelatorioposicao();
         objgerarrelatorioposicao.AV8ClientId = aP0_ClientId;
         objgerarrelatorioposicao.AV9DataInicial = aP1_DataInicial;
         objgerarrelatorioposicao.AV10DataFinal = aP2_DataFinal;
         objgerarrelatorioposicao.AV12VeiculoId = aP3_VeiculoId;
         objgerarrelatorioposicao.context.SetSubmitInitialConfig(context);
         objgerarrelatorioposicao.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgerarrelatorioposicao);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gerarrelatorioposicao)stateInfo).executePrivate();
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
         /* User Code */
          try
         /* User Code */
          {
         /* Using cursor P003V2 */
         pr_default.execute(0, new Object[] {AV12VeiculoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106RastreadorId = P003V2_A106RastreadorId[0];
            A98VeiculoId = P003V2_A98VeiculoId[0];
            A111RastreadorDeviceIdFlespi = P003V2_A111RastreadorDeviceIdFlespi[0];
            A100VeiculoPlaca = P003V2_A100VeiculoPlaca[0];
            A111RastreadorDeviceIdFlespi = P003V2_A111RastreadorDeviceIdFlespi[0];
            A100VeiculoPlaca = P003V2_A100VeiculoPlaca[0];
            AV17RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            AV23VeiculoPlaca = A100VeiculoPlaca;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV14TimeStampInicial = new SdtUtil(context).datetimetotimestamp(AV9DataInicial);
         AV15TimeStampFinal = new SdtUtil(context).datetimetotimestamp(AV10DataFinal);
         AV16URL = "https://flespi.io/gw/devices/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV17RastreadorDeviceIdFlespi), 16, 0)) + "/messages?data={\"fields\":\"engine.ignition.status,external.powersource.voltage,position.latitude,position.longitude,timestamp,server.timestamp,ident,position.speed,engine.ignition.on.duration,engine.motorhours,vehicle.mileage,gnss.vehicle.mileage\",\"to\":" + StringUtil.Trim( AV15TimeStampFinal) + ",\"from\":" + StringUtil.Trim( AV14TimeStampInicial) + "}";
         /* Using cursor P003V3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A130MqttParametrosTokenFlespi = P003V3_A130MqttParametrosTokenFlespi[0];
            A129MqttParametrosId = P003V3_A129MqttParametrosId[0];
            AV31Header = "FlespiToken " + StringUtil.Trim( A130MqttParametrosTokenFlespi);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV18HttpClient.AddHeader("Authorization", AV31Header);
         AV18HttpClient.Execute("GET", AV16URL);
         AV19ChannelMessages.FromJSonString(AV18HttpClient.ToString(), null);
         AV21SDTRelatorioPosicoes = new GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem>( context, "SDTRelatorioPosicoesItem", "RastreamentoTCC");
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV19ChannelMessages.gxTpr_Result.Count )
         {
            AV20ChannelMessagesResult = ((SdtChannelMessages_resultItem)AV19ChannelMessages.gxTpr_Result.Item(AV36GXV1));
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Substring( StringUtil.Trim( StringUtil.Str( AV20ChannelMessagesResult.gxTpr_Position_latitude, 16, 6)), 1, 3)), "0.0") != 0 )
            {
               AV22SDTRelatorioPosicoesItem = new SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem(context);
               AV22SDTRelatorioPosicoesItem.gxTpr_Datahora = new SdtUtil(context).timestamptodatetime((decimal)(AV20ChannelMessagesResult.gxTpr_Server_timestamp));
               AV22SDTRelatorioPosicoesItem.gxTpr_Ignicao = ((AV20ChannelMessagesResult.gxTpr_Engine_ignition_status) ? "ON" : "OFF");
               AV22SDTRelatorioPosicoesItem.gxTpr_Horimetro = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ChannelMessagesResult.gxTpr_Engine_motorhours), 15, 0));
               AV22SDTRelatorioPosicoesItem.gxTpr_Odometro = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ChannelMessagesResult.gxTpr_Gnss_vehicle_mileage), 10, 0));
               AV22SDTRelatorioPosicoesItem.gxTpr_Tensao = StringUtil.Trim( StringUtil.Str( AV20ChannelMessagesResult.gxTpr_External_powersource_voltage, 16, 3))+" (v)";
               AV22SDTRelatorioPosicoesItem.gxTpr_Tensaonumeric = AV20ChannelMessagesResult.gxTpr_External_powersource_voltage;
               AV22SDTRelatorioPosicoesItem.gxTpr_Velocidade = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ChannelMessagesResult.gxTpr_Position_speed), 16, 0))+" KM/H";
               AV22SDTRelatorioPosicoesItem.gxTpr_Velocidadenumeric = AV20ChannelMessagesResult.gxTpr_Position_speed;
               AV22SDTRelatorioPosicoesItem.gxTpr_Placa = StringUtil.Trim( AV23VeiculoPlaca);
               AV22SDTRelatorioPosicoesItem.gxTpr_Latlng = StringUtil.StringReplace( StringUtil.Trim( StringUtil.Str( AV20ChannelMessagesResult.gxTpr_Position_latitude, 16, 6)), ",", ".")+","+StringUtil.StringReplace( StringUtil.Trim( StringUtil.Str( AV20ChannelMessagesResult.gxTpr_Position_longitude, 16, 6)), ",", ".");
               AV21SDTRelatorioPosicoes.Add(AV22SDTRelatorioPosicoesItem, 0);
            }
            AV36GXV1 = (int)(AV36GXV1+1);
         }
         AV21SDTRelatorioPosicoes.Sort("[DataHora]");
         AV26WebNotificationInfo.gxTpr_Id = "RelatorioPosicao";
         AV26WebNotificationInfo.gxTpr_Message = AV21SDTRelatorioPosicoes.ToJSonString(false);
         AV26WebNotificationInfo.gxTpr_Object = "RelatorioPosicao";
         AV27ServerSocket.notifyclient( AV8ClientId,  AV26WebNotificationInfo);
         /* User Code */
          }
         /* User Code */
          catch (Exception e)
         /* User Code */
          {
         /* User Code */
          AV28Exception = e.ToString();
         new GeneXus.Core.genexus.common.SdtLog(context).error(AV28Exception, AV37Pgmname) ;
         /* User Code */
          }
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
         scmdbuf = "";
         P003V2_A106RastreadorId = new int[1] ;
         P003V2_A98VeiculoId = new int[1] ;
         P003V2_A111RastreadorDeviceIdFlespi = new long[1] ;
         P003V2_A100VeiculoPlaca = new string[] {""} ;
         A100VeiculoPlaca = "";
         AV23VeiculoPlaca = "";
         AV14TimeStampInicial = "";
         AV15TimeStampFinal = "";
         AV16URL = "";
         P003V3_A130MqttParametrosTokenFlespi = new string[] {""} ;
         P003V3_A129MqttParametrosId = new int[1] ;
         A130MqttParametrosTokenFlespi = "";
         AV31Header = "";
         AV18HttpClient = new GxHttpClient( context);
         AV19ChannelMessages = new SdtChannelMessages(context);
         AV21SDTRelatorioPosicoes = new GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem>( context, "SDTRelatorioPosicoesItem", "RastreamentoTCC");
         AV20ChannelMessagesResult = new SdtChannelMessages_resultItem(context);
         AV22SDTRelatorioPosicoesItem = new SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem(context);
         AV26WebNotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV27ServerSocket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV28Exception = "";
         AV37Pgmname = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gerarrelatorioposicao__default(),
            new Object[][] {
                new Object[] {
               P003V2_A106RastreadorId, P003V2_A98VeiculoId, P003V2_A111RastreadorDeviceIdFlespi, P003V2_A100VeiculoPlaca
               }
               , new Object[] {
               P003V3_A130MqttParametrosTokenFlespi, P003V3_A129MqttParametrosId
               }
            }
         );
         AV37Pgmname = "GerarRelatorioPosicao";
         /* GeneXus formulas. */
         AV37Pgmname = "GerarRelatorioPosicao";
         context.Gx_err = 0;
      }

      private int AV12VeiculoId ;
      private int A106RastreadorId ;
      private int A98VeiculoId ;
      private int A129MqttParametrosId ;
      private int AV36GXV1 ;
      private long A111RastreadorDeviceIdFlespi ;
      private long AV17RastreadorDeviceIdFlespi ;
      private string scmdbuf ;
      private string AV37Pgmname ;
      private DateTime AV9DataInicial ;
      private DateTime AV10DataFinal ;
      private string AV16URL ;
      private string AV31Header ;
      private string AV28Exception ;
      private string AV8ClientId ;
      private string A100VeiculoPlaca ;
      private string AV23VeiculoPlaca ;
      private string AV14TimeStampInicial ;
      private string AV15TimeStampFinal ;
      private string A130MqttParametrosTokenFlespi ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003V2_A106RastreadorId ;
      private int[] P003V2_A98VeiculoId ;
      private long[] P003V2_A111RastreadorDeviceIdFlespi ;
      private string[] P003V2_A100VeiculoPlaca ;
      private string[] P003V3_A130MqttParametrosTokenFlespi ;
      private int[] P003V3_A129MqttParametrosId ;
      private GxHttpClient AV18HttpClient ;
      private GXBaseCollection<SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem> AV21SDTRelatorioPosicoes ;
      private SdtChannelMessages AV19ChannelMessages ;
      private SdtChannelMessages_resultItem AV20ChannelMessagesResult ;
      private SdtSDTRelatorioPosicoes_SDTRelatorioPosicoesItem AV22SDTRelatorioPosicoesItem ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV26WebNotificationInfo ;
      private GeneXus.Core.genexus.server.SdtSocket AV27ServerSocket ;
   }

   public class gerarrelatorioposicao__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003V2;
          prmP003V2 = new Object[] {
          new Object[] {"@AV12VeiculoId",SqlDbType.Int,8,0}
          };
          Object[] prmP003V3;
          prmP003V3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P003V2", "SELECT TOP 1 T1.[RastreadorId], T1.[VeiculoId], T2.[RastreadorDeviceIdFlespi], T3.[VeiculoPlaca] FROM (([VeiculoRastreador] T1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = T1.[RastreadorId]) INNER JOIN [Veiculo] T3 ON T3.[VeiculoId] = T1.[VeiculoId]) WHERE T1.[VeiculoId] = @AV12VeiculoId ORDER BY T1.[VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003V2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003V3", "SELECT TOP 1 [MqttParametrosTokenFlespi], [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003V3,1, GxCacheFrequency.OFF ,false,true )
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
