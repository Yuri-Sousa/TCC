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
   public class buscapercursoveiculo : GXProcedure
   {
      public buscapercursoveiculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public buscapercursoveiculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_VeiculoIdPercurso ,
                           DateTime aP1_DataInicioPercurso ,
                           DateTime aP2_DataFimPercurso ,
                           string aP3_ClientIdSocket )
      {
         this.AV8VeiculoIdPercurso = aP0_VeiculoIdPercurso;
         this.AV9DataInicioPercurso = aP1_DataInicioPercurso;
         this.AV10DataFimPercurso = aP2_DataFimPercurso;
         this.AV11ClientIdSocket = aP3_ClientIdSocket;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_VeiculoIdPercurso ,
                                 DateTime aP1_DataInicioPercurso ,
                                 DateTime aP2_DataFimPercurso ,
                                 string aP3_ClientIdSocket )
      {
         buscapercursoveiculo objbuscapercursoveiculo;
         objbuscapercursoveiculo = new buscapercursoveiculo();
         objbuscapercursoveiculo.AV8VeiculoIdPercurso = aP0_VeiculoIdPercurso;
         objbuscapercursoveiculo.AV9DataInicioPercurso = aP1_DataInicioPercurso;
         objbuscapercursoveiculo.AV10DataFimPercurso = aP2_DataFimPercurso;
         objbuscapercursoveiculo.AV11ClientIdSocket = aP3_ClientIdSocket;
         objbuscapercursoveiculo.context.SetSubmitInitialConfig(context);
         objbuscapercursoveiculo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbuscapercursoveiculo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((buscapercursoveiculo)stateInfo).executePrivate();
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
         AV12IsBuscaPosicaoRealizada = false;
         AV13PolylineCollection.Clear();
         AV35GXLvl7 = 0;
         /* Using cursor P004G2 */
         pr_default.execute(0, new Object[] {AV8VeiculoIdPercurso});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106RastreadorId = P004G2_A106RastreadorId[0];
            A98VeiculoId = P004G2_A98VeiculoId[0];
            A100VeiculoPlaca = P004G2_A100VeiculoPlaca[0];
            A101VeiculoTipo = P004G2_A101VeiculoTipo[0];
            A111RastreadorDeviceIdFlespi = P004G2_A111RastreadorDeviceIdFlespi[0];
            A111RastreadorDeviceIdFlespi = P004G2_A111RastreadorDeviceIdFlespi[0];
            A100VeiculoPlaca = P004G2_A100VeiculoPlaca[0];
            A101VeiculoTipo = P004G2_A101VeiculoTipo[0];
            AV35GXLvl7 = 1;
            AV21VeiculoPlaca = A100VeiculoPlaca;
            AV15VeiculoTipo = A101VeiculoTipo;
            AV23RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            /* Execute user subroutine: 'CONFIGURAPOLYLINE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV19ContadorDePontos = 0;
            /* Execute user subroutine: 'BUSCARPOSICOES' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV20Polyline.gxTpr_Pontos.Sort("DataHoraPosicao");
            AV13PolylineCollection.Add(AV20Polyline, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV35GXLvl7 == 0 )
         {
            AV16WebNotificationInfo.gxTpr_Id = "PercursoMapa";
            AV17SDTErroRastreamento.gxTpr_Msgerro = "Não foi encontrado um rastreador para esta placa.";
            AV16WebNotificationInfo.gxTpr_Message = AV17SDTErroRastreamento.ToJSonString(false, true);
            AV18ServerSocket.notifyclient( AV11ClientIdSocket,  AV16WebNotificationInfo);
            this.cleanup();
            if (true) return;
         }
         AV16WebNotificationInfo.gxTpr_Id = "PercursoMapa";
         AV16WebNotificationInfo.gxTpr_Message = AV13PolylineCollection.ToJSonString(false);
         AV18ServerSocket.notifyclient( AV11ClientIdSocket,  AV16WebNotificationInfo);
         /* User Code */
          }
         /* User Code */
          catch (Exception e)
         /* User Code */
          {
         /* User Code */
          AV22Exception = e.ToString();
         new GeneXus.Core.genexus.common.SdtLog(context).debug(AV36Pgmname+" - &Exception", AV22Exception) ;
         AV13PolylineCollection.Clear();
         AV16WebNotificationInfo.gxTpr_Id = "PercursoMapa";
         AV16WebNotificationInfo.gxTpr_Message = AV13PolylineCollection.ToJSonString(false);
         AV18ServerSocket.notifyclient( AV11ClientIdSocket,  AV16WebNotificationInfo);
         /* User Code */
          }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CONFIGURAPOLYLINE' Routine */
         returnInSub = false;
         AV13PolylineCollection = new GXBaseCollection<SdtPolyline_PolylineItem>( context, "PolylineItem", "RastreamentoTCC");
         AV20Polyline = new SdtPolyline_PolylineItem(context);
         AV20Polyline.gxTpr_Polylineid = 1;
         AV20Polyline.gxTpr_Stroke = true;
         AV20Polyline.gxTpr_Strokecolor = "#0ac6a6";
         AV20Polyline.gxTpr_Strokeopacity = 0.5m;
         AV20Polyline.gxTpr_Strokeweight = 3;
         AV20Polyline.gxTpr_Placa = StringUtil.Trim( StringUtil.Upper( AV21VeiculoPlaca));
         AV20Polyline.gxTpr_Urliconeinicio = context.convertURL( (string)(context.GetImagePath( "9e59c207-5645-4650-98da-45fb482108eb", "", context.GetTheme( ))));
         AV20Polyline.gxTpr_Urliconefim = context.convertURL( (string)(context.GetImagePath( "0a6fb65f-c1ce-46b9-9d82-86e046cacd07", "", context.GetTheme( ))));
         AV20Polyline.gxTpr_Urliconedurantetrajeto = context.convertURL( (string)(context.GetImagePath( "4c587bb6-0823-41a0-aa18-c8ba030cadbd", "", context.GetTheme( ))));
         if ( StringUtil.StrCmp(AV15VeiculoTipo, "Carro") == 0 )
         {
            AV20Polyline.gxTpr_Urliconanimation = context.convertURL( (string)(context.GetImagePath( "e31ea55c-7c05-44aa-a783-465d6b4a2b04", "", context.GetTheme( ))));
         }
         else if ( StringUtil.StrCmp(AV15VeiculoTipo, "Moto") == 0 )
         {
            AV20Polyline.gxTpr_Urliconanimation = context.convertURL( (string)(context.GetImagePath( "3e661ae6-b3ba-4975-a260-9296c6e8b6e1", "", context.GetTheme( ))));
         }
         else if ( StringUtil.StrCmp(AV15VeiculoTipo, "Caminhão") == 0 )
         {
            AV20Polyline.gxTpr_Urliconanimation = context.convertURL( (string)(context.GetImagePath( "b815971e-357e-43db-8fa7-00dc77ed063a", "", context.GetTheme( ))));
         }
         else
         {
            AV20Polyline.gxTpr_Urliconanimation = context.convertURL( (string)(context.GetImagePath( "e31ea55c-7c05-44aa-a783-465d6b4a2b04", "", context.GetTheme( ))));
         }
      }

      protected void S121( )
      {
         /* 'BUSCARPOSICOES' Routine */
         returnInSub = false;
         AV25TimeStampInicial = new SdtUtil(context).datetimetotimestamp(AV9DataInicioPercurso);
         AV26TimeStampFinal = new SdtUtil(context).datetimetotimestamp(AV10DataFimPercurso);
         AV24URL = "https://flespi.io/gw/devices/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV23RastreadorDeviceIdFlespi), 16, 0)) + "/messages?data={\"fields\":\"engine.ignition.status,position.latitude,position.longitude,server.timestamp,ident,position.speed\",\"to\":" + StringUtil.Trim( AV26TimeStampFinal) + ",\"from\":" + StringUtil.Trim( AV25TimeStampInicial) + "}";
         AV27HttpClient.AddHeader("Authorization", "FlespiToken MSaFurA9YsAcDImy70MgVsygAxdJ71dIHcd1tEZhWpjoWuMRkmX3Fja3GbCC0Fax");
         AV27HttpClient.Execute("GET", AV24URL);
         AV28ChannelMessages.FromJSonString(AV27HttpClient.ToString(), null);
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV28ChannelMessages.gxTpr_Result.Count )
         {
            AV29ChannelMessagesResult = ((SdtChannelMessages_resultItem)AV28ChannelMessages.gxTpr_Result.Item(AV37GXV1));
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Substring( StringUtil.Trim( StringUtil.Str( AV29ChannelMessagesResult.gxTpr_Position_latitude, 16, 6)), 1, 3)), "0.0") != 0 )
            {
               AV32DataHora = (DateTime)(DateTime.MinValue);
               AV32DataHora = new SdtUtil(context).timestamptodatetime((decimal)(AV29ChannelMessagesResult.gxTpr_Server_timestamp));
               AV32DataHora = DateTimeUtil.TAdd( AV32DataHora, 3600*(3));
               AV30PolylinePontos = new SdtPolyline_PolylineItem_Pontos(context);
               AV30PolylinePontos.gxTpr_Pontoid = AV19ContadorDePontos;
               AV30PolylinePontos.gxTpr_Lat = NumberUtil.Val( StringUtil.StringReplace( StringUtil.Trim( StringUtil.Str( AV29ChannelMessagesResult.gxTpr_Position_latitude, 16, 6)), ",", "."), ".");
               AV30PolylinePontos.gxTpr_Lng = NumberUtil.Val( StringUtil.StringReplace( StringUtil.Trim( StringUtil.Str( AV29ChannelMessagesResult.gxTpr_Position_longitude, 16, 6)), ",", "."), ".");
               AV30PolylinePontos.gxTpr_Ignicao = ((AV29ChannelMessagesResult.gxTpr_Engine_ignition_status) ? "ON" : "OFF");
               AV30PolylinePontos.gxTpr_Velocidade = StringUtil.Trim( StringUtil.Str( (decimal)(AV29ChannelMessagesResult.gxTpr_Position_speed), 16, 0));
               AV30PolylinePontos.gxTpr_Datahoraposicao = StringUtil.Trim( context.localUtil.TToC( AV32DataHora, 8, 5, 0, 3, "/", ":", " "));
               AV20Polyline.gxTpr_Pontos.Add(AV30PolylinePontos, 0);
               AV19ContadorDePontos = (long)(AV19ContadorDePontos+1);
            }
            AV37GXV1 = (int)(AV37GXV1+1);
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
         AV13PolylineCollection = new GXBaseCollection<SdtPolyline_PolylineItem>( context, "PolylineItem", "RastreamentoTCC");
         scmdbuf = "";
         P004G2_A106RastreadorId = new int[1] ;
         P004G2_A98VeiculoId = new int[1] ;
         P004G2_A100VeiculoPlaca = new string[] {""} ;
         P004G2_A101VeiculoTipo = new string[] {""} ;
         P004G2_A111RastreadorDeviceIdFlespi = new long[1] ;
         A100VeiculoPlaca = "";
         A101VeiculoTipo = "";
         AV21VeiculoPlaca = "";
         AV15VeiculoTipo = "";
         AV20Polyline = new SdtPolyline_PolylineItem(context);
         AV16WebNotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV17SDTErroRastreamento = new SdtSDTErroRastreamento(context);
         AV18ServerSocket = new GeneXus.Core.genexus.server.SdtSocket(context);
         AV22Exception = "";
         AV36Pgmname = "";
         AV25TimeStampInicial = "";
         AV26TimeStampFinal = "";
         AV24URL = "";
         AV27HttpClient = new GxHttpClient( context);
         AV28ChannelMessages = new SdtChannelMessages(context);
         AV29ChannelMessagesResult = new SdtChannelMessages_resultItem(context);
         AV32DataHora = (DateTime)(DateTime.MinValue);
         AV30PolylinePontos = new SdtPolyline_PolylineItem_Pontos(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.buscapercursoveiculo__default(),
            new Object[][] {
                new Object[] {
               P004G2_A106RastreadorId, P004G2_A98VeiculoId, P004G2_A100VeiculoPlaca, P004G2_A101VeiculoTipo, P004G2_A111RastreadorDeviceIdFlespi
               }
            }
         );
         AV36Pgmname = "BuscaPercursoVeiculo";
         /* GeneXus formulas. */
         AV36Pgmname = "BuscaPercursoVeiculo";
         context.Gx_err = 0;
      }

      private short AV35GXLvl7 ;
      private int AV8VeiculoIdPercurso ;
      private int A106RastreadorId ;
      private int A98VeiculoId ;
      private int AV37GXV1 ;
      private long A111RastreadorDeviceIdFlespi ;
      private long AV23RastreadorDeviceIdFlespi ;
      private long AV19ContadorDePontos ;
      private string scmdbuf ;
      private string AV36Pgmname ;
      private DateTime AV9DataInicioPercurso ;
      private DateTime AV10DataFimPercurso ;
      private DateTime AV32DataHora ;
      private bool AV12IsBuscaPosicaoRealizada ;
      private bool returnInSub ;
      private string AV22Exception ;
      private string AV11ClientIdSocket ;
      private string A100VeiculoPlaca ;
      private string A101VeiculoTipo ;
      private string AV21VeiculoPlaca ;
      private string AV15VeiculoTipo ;
      private string AV25TimeStampInicial ;
      private string AV26TimeStampFinal ;
      private string AV24URL ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004G2_A106RastreadorId ;
      private int[] P004G2_A98VeiculoId ;
      private string[] P004G2_A100VeiculoPlaca ;
      private string[] P004G2_A101VeiculoTipo ;
      private long[] P004G2_A111RastreadorDeviceIdFlespi ;
      private GxHttpClient AV27HttpClient ;
      private GXBaseCollection<SdtPolyline_PolylineItem> AV13PolylineCollection ;
      private SdtPolyline_PolylineItem AV20Polyline ;
      private SdtPolyline_PolylineItem_Pontos AV30PolylinePontos ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV16WebNotificationInfo ;
      private SdtSDTErroRastreamento AV17SDTErroRastreamento ;
      private GeneXus.Core.genexus.server.SdtSocket AV18ServerSocket ;
      private SdtChannelMessages AV28ChannelMessages ;
      private SdtChannelMessages_resultItem AV29ChannelMessagesResult ;
   }

   public class buscapercursoveiculo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004G2;
          prmP004G2 = new Object[] {
          new Object[] {"@AV8VeiculoIdPercurso",SqlDbType.Int,8,0}
          };
          def= new CursorDef[] {
              new CursorDef("P004G2", "SELECT T1.[RastreadorId], T1.[VeiculoId], T3.[VeiculoPlaca], T3.[VeiculoTipo], T2.[RastreadorDeviceIdFlespi] FROM (([VeiculoRastreador] T1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = T1.[RastreadorId]) INNER JOIN [Veiculo] T3 ON T3.[VeiculoId] = T1.[VeiculoId]) WHERE T1.[VeiculoId] = @AV8VeiculoIdPercurso ORDER BY T1.[VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004G2,100, GxCacheFrequency.OFF ,true,false )
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
                table[2][0] = rslt.getVarchar(3);
                table[3][0] = rslt.getVarchar(4);
                table[4][0] = rslt.getLong(5);
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
