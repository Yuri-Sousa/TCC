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
   public class atualizasubscribersmqtt : GXProcedure
   {
      public atualizasubscribersmqtt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public atualizasubscribersmqtt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_RastreadorId ,
                           long aP1_RastreadorSNumber ,
                           long aP2_RastreadorDeviceIdFlespi ,
                           bool aP3_DeletarRegistro )
      {
         this.AV8RastreadorId = aP0_RastreadorId;
         this.AV11RastreadorSNumber = aP1_RastreadorSNumber;
         this.AV10RastreadorDeviceIdFlespi = aP2_RastreadorDeviceIdFlespi;
         this.AV16DeletarRegistro = aP3_DeletarRegistro;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_RastreadorId ,
                                 long aP1_RastreadorSNumber ,
                                 long aP2_RastreadorDeviceIdFlespi ,
                                 bool aP3_DeletarRegistro )
      {
         atualizasubscribersmqtt objatualizasubscribersmqtt;
         objatualizasubscribersmqtt = new atualizasubscribersmqtt();
         objatualizasubscribersmqtt.AV8RastreadorId = aP0_RastreadorId;
         objatualizasubscribersmqtt.AV11RastreadorSNumber = aP1_RastreadorSNumber;
         objatualizasubscribersmqtt.AV10RastreadorDeviceIdFlespi = aP2_RastreadorDeviceIdFlespi;
         objatualizasubscribersmqtt.AV16DeletarRegistro = aP3_DeletarRegistro;
         objatualizasubscribersmqtt.context.SetSubmitInitialConfig(context);
         objatualizasubscribersmqtt.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objatualizasubscribersmqtt);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((atualizasubscribersmqtt)stateInfo).executePrivate();
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
         /* Using cursor P003Q2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A131MqttParametrosJSONSubscribe = P003Q2_A131MqttParametrosJSONSubscribe[0];
            A129MqttParametrosId = P003Q2_A129MqttParametrosId[0];
            AV9SDTSubscribersMQTT.FromJSonString(A131MqttParametrosJSONSubscribe, null);
            AV27SDTSubscribersMQTTOld.FromJSonString(A131MqttParametrosJSONSubscribe, null);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ! AV16DeletarRegistro )
         {
            AV15IsRegistroAtualizado = false;
            AV31GXV1 = 1;
            while ( AV31GXV1 <= AV9SDTSubscribersMQTT.Count )
            {
               AV13SDTSubscribersMQTTItem = ((SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem)AV9SDTSubscribersMQTT.Item(AV31GXV1));
               if ( AV13SDTSubscribersMQTTItem.gxTpr_Rastreadorid == AV8RastreadorId )
               {
                  AV15IsRegistroAtualizado = true;
                  ((SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem)AV9SDTSubscribersMQTT.Item(AV9SDTSubscribersMQTT.IndexOf(AV13SDTSubscribersMQTTItem))).gxTpr_Rastreadordeviceidflespi = AV10RastreadorDeviceIdFlespi;
                  ((SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem)AV9SDTSubscribersMQTT.Item(AV9SDTSubscribersMQTT.IndexOf(AV13SDTSubscribersMQTTItem))).gxTpr_Rastreadorsnumber = AV11RastreadorSNumber;
                  if (true) break;
               }
               AV31GXV1 = (int)(AV31GXV1+1);
            }
            if ( ! AV15IsRegistroAtualizado )
            {
               AV13SDTSubscribersMQTTItem = new SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem(context);
               AV13SDTSubscribersMQTTItem.gxTpr_Rastreadorid = AV8RastreadorId;
               AV13SDTSubscribersMQTTItem.gxTpr_Rastreadorsnumber = AV11RastreadorSNumber;
               AV13SDTSubscribersMQTTItem.gxTpr_Rastreadordeviceidflespi = AV10RastreadorDeviceIdFlespi;
               AV9SDTSubscribersMQTT.Add(AV13SDTSubscribersMQTTItem, 0);
            }
         }
         else
         {
            AV32GXV2 = 1;
            while ( AV32GXV2 <= AV9SDTSubscribersMQTT.Count )
            {
               AV13SDTSubscribersMQTTItem = ((SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem)AV9SDTSubscribersMQTT.Item(AV32GXV2));
               if ( AV13SDTSubscribersMQTTItem.gxTpr_Rastreadorid == AV8RastreadorId )
               {
                  AV9SDTSubscribersMQTT.RemoveItem(AV9SDTSubscribersMQTT.IndexOf(AV13SDTSubscribersMQTTItem));
                  if (true) break;
               }
               AV32GXV2 = (int)(AV32GXV2+1);
            }
         }
         /* Using cursor P003Q3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A131MqttParametrosJSONSubscribe = P003Q3_A131MqttParametrosJSONSubscribe[0];
            A135MqttParametrosCanalFlespi = P003Q3_A135MqttParametrosCanalFlespi[0];
            A129MqttParametrosId = P003Q3_A129MqttParametrosId[0];
            A131MqttParametrosJSONSubscribe = AV9SDTSubscribersMQTT.ToJSonString(false);
            AV18MqttParametrosCanalFlespi = A135MqttParametrosCanalFlespi;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P003Q4 */
            pr_default.execute(2, new Object[] {A131MqttParametrosJSONSubscribe, A129MqttParametrosId});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("MqttParametros");
            if (true) break;
            /* Using cursor P003Q5 */
            pr_default.execute(3, new Object[] {A131MqttParametrosJSONSubscribe, A129MqttParametrosId});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("MqttParametros");
            pr_default.readNext(1);
         }
         pr_default.close(1);
         context.CommitDataStores("atualizasubscribersmqtt",pr_default);
         GXt_guid1 = (Guid)(AV17MqttConnectionGUID);
         new buscarconexaomqtt(context ).execute( out  GXt_guid1) ;
         AV17MqttConnectionGUID = (Guid)((Guid)(GXt_guid1));
         AV25MQTTStatus = AV23MQTT.isconnected(AV17MqttConnectionGUID, out  AV24IsConnected);
         if ( AV24IsConnected )
         {
            AV34GXV3 = 1;
            while ( AV34GXV3 <= AV27SDTSubscribersMQTTOld.Count )
            {
               AV13SDTSubscribersMQTTItem = ((SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem)AV27SDTSubscribersMQTTOld.Item(AV34GXV3));
               AV19Topic = "";
               AV19Topic = "flespi/message/gw/channels/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV18MqttParametrosCanalFlespi), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13SDTSubscribersMQTTItem.gxTpr_Rastreadorsnumber), 16, 0));
               new desinscrevertopicomqtt(context ).execute(  AV17MqttConnectionGUID,  AV19Topic) ;
               AV34GXV3 = (int)(AV34GXV3+1);
            }
            new subscrevermqtt(context).executeSubmit( ) ;
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
         P003Q2_A131MqttParametrosJSONSubscribe = new string[] {""} ;
         P003Q2_A129MqttParametrosId = new int[1] ;
         A131MqttParametrosJSONSubscribe = "";
         AV9SDTSubscribersMQTT = new GXBaseCollection<SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem>( context, "SDTSubscribersMQTTItem", "RastreamentoTCC");
         AV27SDTSubscribersMQTTOld = new GXBaseCollection<SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem>( context, "SDTSubscribersMQTTItem", "RastreamentoTCC");
         AV13SDTSubscribersMQTTItem = new SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem(context);
         P003Q3_A131MqttParametrosJSONSubscribe = new string[] {""} ;
         P003Q3_A135MqttParametrosCanalFlespi = new long[1] ;
         P003Q3_A129MqttParametrosId = new int[1] ;
         AV17MqttConnectionGUID = (Guid)(Guid.Empty);
         GXt_guid1 = (Guid)(Guid.Empty);
         AV25MQTTStatus = new SdtMqttStatus(context);
         AV23MQTT = new SdtMQTT(context);
         AV19Topic = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.atualizasubscribersmqtt__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atualizasubscribersmqtt__default(),
            new Object[][] {
                new Object[] {
               P003Q2_A131MqttParametrosJSONSubscribe, P003Q2_A129MqttParametrosId
               }
               , new Object[] {
               P003Q3_A131MqttParametrosJSONSubscribe, P003Q3_A135MqttParametrosCanalFlespi, P003Q3_A129MqttParametrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8RastreadorId ;
      private int A129MqttParametrosId ;
      private int AV31GXV1 ;
      private int AV32GXV2 ;
      private int AV34GXV3 ;
      private long AV11RastreadorSNumber ;
      private long AV10RastreadorDeviceIdFlespi ;
      private long A135MqttParametrosCanalFlespi ;
      private long AV18MqttParametrosCanalFlespi ;
      private string scmdbuf ;
      private bool AV16DeletarRegistro ;
      private bool AV15IsRegistroAtualizado ;
      private bool AV24IsConnected ;
      private string A131MqttParametrosJSONSubscribe ;
      private string AV19Topic ;
      private Guid AV17MqttConnectionGUID ;
      private Guid GXt_guid1 ;
      private SdtMQTT AV23MQTT ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003Q2_A131MqttParametrosJSONSubscribe ;
      private int[] P003Q2_A129MqttParametrosId ;
      private string[] P003Q3_A131MqttParametrosJSONSubscribe ;
      private long[] P003Q3_A135MqttParametrosCanalFlespi ;
      private int[] P003Q3_A129MqttParametrosId ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem> AV9SDTSubscribersMQTT ;
      private GXBaseCollection<SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem> AV27SDTSubscribersMQTTOld ;
      private SdtSDTSubscribersMQTT_SDTSubscribersMQTTItem AV13SDTSubscribersMQTTItem ;
      private SdtMqttStatus AV25MQTTStatus ;
   }

   public class atualizasubscribersmqtt__gam : DataStoreHelperBase, IDataStoreHelper
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

    public string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class atualizasubscribersmqtt__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003Q2;
        prmP003Q2 = new Object[] {
        };
        Object[] prmP003Q3;
        prmP003Q3 = new Object[] {
        };
        Object[] prmP003Q4;
        prmP003Q4 = new Object[] {
        new Object[] {"@MqttParametrosJSONSubscribe",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        Object[] prmP003Q5;
        prmP003Q5 = new Object[] {
        new Object[] {"@MqttParametrosJSONSubscribe",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@MqttParametrosId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("P003Q2", "SELECT TOP 1 [MqttParametrosJSONSubscribe], [MqttParametrosId] FROM [MqttParametros] ORDER BY [MqttParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Q2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P003Q3", "SELECT TOP 1 [MqttParametrosJSONSubscribe], [MqttParametrosCanalFlespi], [MqttParametrosId] FROM [MqttParametros] WITH (UPDLOCK) ORDER BY [MqttParametrosId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Q3,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P003Q4", "UPDATE [MqttParametros] SET [MqttParametrosJSONSubscribe]=@MqttParametrosJSONSubscribe  WHERE [MqttParametrosId] = @MqttParametrosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003Q4)
           ,new CursorDef("P003Q5", "UPDATE [MqttParametros] SET [MqttParametrosJSONSubscribe]=@MqttParametrosJSONSubscribe  WHERE [MqttParametrosId] = @MqttParametrosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003Q5)
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
              table[0][0] = rslt.getLongVarchar(1);
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
           case 2 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 3 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
