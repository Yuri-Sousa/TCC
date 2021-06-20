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
   public class getmqttconfig : GXProcedure
   {
      public getmqttconfig( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getmqttconfig( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out SdtMqttConfig aP0_mqttConfig ,
                           out string aP1_URL )
      {
         this.AV8mqttConfig = new SdtMqttConfig(context) ;
         this.AV9URL = "" ;
         initialize();
         executePrivate();
         aP0_mqttConfig=this.AV8mqttConfig;
         aP1_URL=this.AV9URL;
      }

      public string executeUdp( out SdtMqttConfig aP0_mqttConfig )
      {
         execute(out aP0_mqttConfig, out aP1_URL);
         return AV9URL ;
      }

      public void executeSubmit( out SdtMqttConfig aP0_mqttConfig ,
                                 out string aP1_URL )
      {
         getmqttconfig objgetmqttconfig;
         objgetmqttconfig = new getmqttconfig();
         objgetmqttconfig.AV8mqttConfig = new SdtMqttConfig(context) ;
         objgetmqttconfig.AV9URL = "" ;
         objgetmqttconfig.context.SetSubmitInitialConfig(context);
         objgetmqttconfig.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetmqttconfig);
         aP0_mqttConfig=this.AV8mqttConfig;
         aP1_URL=this.AV9URL;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getmqttconfig)stateInfo).executePrivate();
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
         /* Using cursor P00392 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130MqttParametrosTokenFlespi = P00392_A130MqttParametrosTokenFlespi[0];
            A132MqttParametrosClientId = P00392_A132MqttParametrosClientId[0];
            A133MqttParametrosPortaBroker = P00392_A133MqttParametrosPortaBroker[0];
            A134MqttParametrosURLBroker = P00392_A134MqttParametrosURLBroker[0];
            A129MqttParametrosId = P00392_A129MqttParametrosId[0];
            AV8mqttConfig = new SdtMqttConfig(context);
            AV8mqttConfig.gxTpr_Username = StringUtil.Trim( A130MqttParametrosTokenFlespi);
            AV8mqttConfig.gxTpr_Password = StringUtil.Trim( A130MqttParametrosTokenFlespi);
            AV8mqttConfig.gxTpr_Clientid = A132MqttParametrosClientId;
            AV8mqttConfig.gxTpr_Port = A133MqttParametrosPortaBroker;
            AV8mqttConfig.gxTpr_Buffersize = 999999999;
            AV8mqttConfig.gxTpr_Keepalive = 10;
            AV8mqttConfig.gxTpr_Autoreconnectdelay = 30;
            AV8mqttConfig.gxTpr_Mqttconnectionname = "ConexaoRastreamentoTCC";
            AV8mqttConfig.gxTpr_Allowwildcardsintopicfilters = true;
            AV8mqttConfig.gxTpr_Cleansession = false;
            AV8mqttConfig.gxTpr_Connectiontimeout = 60;
            AV8mqttConfig.gxTpr_Sessionexpiryinterval = 3600;
            AV8mqttConfig.gxTpr_Sslconnection = false;
            AV8mqttConfig.gxTpr_Protocolversion = 500;
            AV9URL = A134MqttParametrosURLBroker;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV8mqttConfig = new SdtMqttConfig(context);
         AV9URL = "";
         scmdbuf = "";
         P00392_A130MqttParametrosTokenFlespi = new string[] {""} ;
         P00392_A132MqttParametrosClientId = new string[] {""} ;
         P00392_A133MqttParametrosPortaBroker = new short[1] ;
         P00392_A134MqttParametrosURLBroker = new string[] {""} ;
         P00392_A129MqttParametrosId = new int[1] ;
         A130MqttParametrosTokenFlespi = "";
         A132MqttParametrosClientId = "";
         A134MqttParametrosURLBroker = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getmqttconfig__default(),
            new Object[][] {
                new Object[] {
               P00392_A130MqttParametrosTokenFlespi, P00392_A132MqttParametrosClientId, P00392_A133MqttParametrosPortaBroker, P00392_A134MqttParametrosURLBroker, P00392_A129MqttParametrosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A133MqttParametrosPortaBroker ;
      private int A129MqttParametrosId ;
      private string scmdbuf ;
      private string AV9URL ;
      private string A130MqttParametrosTokenFlespi ;
      private string A132MqttParametrosClientId ;
      private string A134MqttParametrosURLBroker ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00392_A130MqttParametrosTokenFlespi ;
      private string[] P00392_A132MqttParametrosClientId ;
      private short[] P00392_A133MqttParametrosPortaBroker ;
      private string[] P00392_A134MqttParametrosURLBroker ;
      private int[] P00392_A129MqttParametrosId ;
      private SdtMqttConfig aP0_mqttConfig ;
      private string aP1_URL ;
      private SdtMqttConfig AV8mqttConfig ;
   }

   public class getmqttconfig__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00392;
          prmP00392 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00392", "SELECT TOP 1 [MqttParametrosTokenFlespi], [MqttParametrosClientId], [MqttParametrosPortaBroker], [MqttParametrosURLBroker], [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00392,1, GxCacheFrequency.OFF ,false,true )
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
                table[1][0] = rslt.getVarchar(2);
                table[2][0] = rslt.getShort(3);
                table[3][0] = rslt.getVarchar(4);
                table[4][0] = rslt.getInt(5);
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
