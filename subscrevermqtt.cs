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
   public class subscrevermqtt : GXProcedure
   {
      public subscrevermqtt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public subscrevermqtt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         subscrevermqtt objsubscrevermqtt;
         objsubscrevermqtt = new subscrevermqtt();
         objsubscrevermqtt.context.SetSubmitInitialConfig(context);
         objsubscrevermqtt.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsubscrevermqtt);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((subscrevermqtt)stateInfo).executePrivate();
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
         /* Using cursor P003R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A92MqttConnectionGUID = (Guid)((Guid)(P003R2_A92MqttConnectionGUID[0]));
            A90MqttConnectionId = P003R2_A90MqttConnectionId[0];
            AV8MqttConnectionGUID = (Guid)(A92MqttConnectionGUID);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P003R3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A131MqttParametrosJSONSubscribe = P003R3_A131MqttParametrosJSONSubscribe[0];
            A135MqttParametrosCanalFlespi = P003R3_A135MqttParametrosCanalFlespi[0];
            A129MqttParametrosId = P003R3_A129MqttParametrosId[0];
            AV13SDTSubscribersMQTT.FromJSonString(A131MqttParametrosJSONSubscribe, null);
            AV17MqttParametrosCanalFlespi = A135MqttParametrosCanalFlespi;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV13SDTSubscribersMQTT.Count )
         {
            AV16SDTSubscribersMQTTItem = ((SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem)AV13SDTSubscribersMQTT.Item(AV23GXV1));
            AV10Topic = "";
            AV10Topic = "flespi/message/gw/channels/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV17MqttParametrosCanalFlespi), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16SDTSubscribersMQTTItem.gxTpr_Rastreadorsnumber), 16, 0));
            AV11PRCRetorno = "SalvarUltimoDadoLidoDistribui";
            new subscrevertopicomqtt(context ).execute(  AV8MqttConnectionGUID,  AV10Topic,  AV11PRCRetorno, out  AV12OcorreuErro) ;
            AV23GXV1 = (int)(AV23GXV1+1);
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
         P003R2_A92MqttConnectionGUID = new Guid[] {Guid.Empty} ;
         P003R2_A90MqttConnectionId = new int[1] ;
         A92MqttConnectionGUID = (Guid)(Guid.Empty);
         AV8MqttConnectionGUID = (Guid)(Guid.Empty);
         P003R3_A131MqttParametrosJSONSubscribe = new string[] {""} ;
         P003R3_A135MqttParametrosCanalFlespi = new long[1] ;
         P003R3_A129MqttParametrosId = new int[1] ;
         A131MqttParametrosJSONSubscribe = "";
         AV13SDTSubscribersMQTT = new GXBaseCollection<SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem>( context, "SDTSubscribersMQTTItem", "RastreamentoTCC");
         AV16SDTSubscribersMQTTItem = new SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem(context);
         AV10Topic = "";
         AV11PRCRetorno = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.subscrevermqtt__default(),
            new Object[][] {
                new Object[] {
               P003R2_A92MqttConnectionGUID, P003R2_A90MqttConnectionId
               }
               , new Object[] {
               P003R3_A131MqttParametrosJSONSubscribe, P003R3_A135MqttParametrosCanalFlespi, P003R3_A129MqttParametrosId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A90MqttConnectionId ;
      private int A129MqttParametrosId ;
      private int AV23GXV1 ;
      private long A135MqttParametrosCanalFlespi ;
      private long AV17MqttParametrosCanalFlespi ;
      private string scmdbuf ;
      private bool AV12OcorreuErro ;
      private string A131MqttParametrosJSONSubscribe ;
      private string AV10Topic ;
      private string AV11PRCRetorno ;
      private Guid A92MqttConnectionGUID ;
      private Guid AV8MqttConnectionGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P003R2_A92MqttConnectionGUID ;
      private int[] P003R2_A90MqttConnectionId ;
      private string[] P003R3_A131MqttParametrosJSONSubscribe ;
      private long[] P003R3_A135MqttParametrosCanalFlespi ;
      private int[] P003R3_A129MqttParametrosId ;
      private GXBaseCollection<SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem> AV13SDTSubscribersMQTT ;
      private SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem AV16SDTSubscribersMQTTItem ;
   }

   public class subscrevermqtt__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003R2;
          prmP003R2 = new Object[] {
          };
          Object[] prmP003R3;
          prmP003R3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P003R2", "SELECT TOP 1 [MqttConnectionGUID], [MqttConnectionId] FROM [MqttConnection] ORDER BY [MqttConnectionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003R3", "SELECT TOP 1 [MqttParametrosJSONSubscribe], [MqttParametrosCanalFlespi], [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R3,1, GxCacheFrequency.OFF ,false,true )
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
                table[0][0] = rslt.getGuid(1);
                table[1][0] = rslt.getInt(2);
                return;
             case 1 :
                table[0][0] = rslt.getLongVarchar(1);
                table[1][0] = rslt.getLong(2);
                table[2][0] = rslt.getInt(3);
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
