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
   public class enviarcomandorastreador : GXProcedure
   {
      public enviarcomandorastreador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public enviarcomandorastreador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_ChannelId ,
                           string aP1_JsonEnvio ,
                           out bool aP2_Sucesso ,
                           out SdtSDTResultadoEnvioComando_Canal aP3_SDTResultadoEnvioComando_Canal )
      {
         this.AV12ChannelId = aP0_ChannelId;
         this.AV13JsonEnvio = aP1_JsonEnvio;
         this.AV10Sucesso = false ;
         this.AV11SDTResultadoEnvioComando_Canal = new SdtSDTResultadoEnvioComando_Canal(context) ;
         initialize();
         executePrivate();
         aP2_Sucesso=this.AV10Sucesso;
         aP3_SDTResultadoEnvioComando_Canal=this.AV11SDTResultadoEnvioComando_Canal;
      }

      public SdtSDTResultadoEnvioComando_Canal executeUdp( string aP0_ChannelId ,
                                                           string aP1_JsonEnvio ,
                                                           out bool aP2_Sucesso )
      {
         execute(aP0_ChannelId, aP1_JsonEnvio, out aP2_Sucesso, out aP3_SDTResultadoEnvioComando_Canal);
         return AV11SDTResultadoEnvioComando_Canal ;
      }

      public void executeSubmit( string aP0_ChannelId ,
                                 string aP1_JsonEnvio ,
                                 out bool aP2_Sucesso ,
                                 out SdtSDTResultadoEnvioComando_Canal aP3_SDTResultadoEnvioComando_Canal )
      {
         enviarcomandorastreador objenviarcomandorastreador;
         objenviarcomandorastreador = new enviarcomandorastreador();
         objenviarcomandorastreador.AV12ChannelId = aP0_ChannelId;
         objenviarcomandorastreador.AV13JsonEnvio = aP1_JsonEnvio;
         objenviarcomandorastreador.AV10Sucesso = false ;
         objenviarcomandorastreador.AV11SDTResultadoEnvioComando_Canal = new SdtSDTResultadoEnvioComando_Canal(context) ;
         objenviarcomandorastreador.context.SetSubmitInitialConfig(context);
         objenviarcomandorastreador.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objenviarcomandorastreador);
         aP2_Sucesso=this.AV10Sucesso;
         aP3_SDTResultadoEnvioComando_Canal=this.AV11SDTResultadoEnvioComando_Canal;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((enviarcomandorastreador)stateInfo).executePrivate();
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
         AV14URL = "https://flespi.io/gw/channels/" + StringUtil.Trim( AV12ChannelId) + "/commands-queue";
         /* Using cursor P004B2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130MqttParametrosTokenFlespi = P004B2_A130MqttParametrosTokenFlespi[0];
            A129MqttParametrosId = P004B2_A129MqttParametrosId[0];
            AV16Header = "FlespiToken " + StringUtil.Trim( A130MqttParametrosTokenFlespi);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15HttpClient.AddHeader("Authorization", AV16Header);
         AV15HttpClient.AddHeader("Content-Type", "application/json");
         AV15HttpClient.AddString(AV13JsonEnvio);
         AV15HttpClient.Execute("POST", AV14URL);
         if ( AV15HttpClient.StatusCode == 200 )
         {
            AV10Sucesso = true;
            AV11SDTResultadoEnvioComando_Canal.FromJSonString(AV15HttpClient.ToString(), null);
         }
         else
         {
            new GeneXus.Core.genexus.common.SdtLog(context).error(AV15HttpClient.ToString(), "Erro ao enviar o comando") ;
            AV10Sucesso = false;
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
         AV11SDTResultadoEnvioComando_Canal = new SdtSDTResultadoEnvioComando_Canal(context);
         AV14URL = "";
         scmdbuf = "";
         P004B2_A130MqttParametrosTokenFlespi = new string[] {""} ;
         P004B2_A129MqttParametrosId = new int[1] ;
         A130MqttParametrosTokenFlespi = "";
         AV16Header = "";
         AV15HttpClient = new GxHttpClient( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enviarcomandorastreador__default(),
            new Object[][] {
                new Object[] {
               P004B2_A130MqttParametrosTokenFlespi, P004B2_A129MqttParametrosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A129MqttParametrosId ;
      private string scmdbuf ;
      private bool AV10Sucesso ;
      private string AV13JsonEnvio ;
      private string AV12ChannelId ;
      private string AV14URL ;
      private string A130MqttParametrosTokenFlespi ;
      private string AV16Header ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004B2_A130MqttParametrosTokenFlespi ;
      private int[] P004B2_A129MqttParametrosId ;
      private bool aP2_Sucesso ;
      private SdtSDTResultadoEnvioComando_Canal aP3_SDTResultadoEnvioComando_Canal ;
      private GxHttpClient AV15HttpClient ;
      private SdtSDTResultadoEnvioComando_Canal AV11SDTResultadoEnvioComando_Canal ;
   }

   public class enviarcomandorastreador__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP004B2;
          prmP004B2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P004B2", "SELECT TOP 1 [MqttParametrosTokenFlespi], [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B2,1, GxCacheFrequency.OFF ,false,true )
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
       }
    }

 }

}
