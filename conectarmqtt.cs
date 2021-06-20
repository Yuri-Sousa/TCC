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
   public class conectarmqtt : GXProcedure
   {
      public conectarmqtt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conectarmqtt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out bool aP0_IsSucessoConexao )
      {
         this.AV11IsSucessoConexao = false ;
         initialize();
         executePrivate();
         aP0_IsSucessoConexao=this.AV11IsSucessoConexao;
      }

      public bool executeUdp( )
      {
         execute(out aP0_IsSucessoConexao);
         return AV11IsSucessoConexao ;
      }

      public void executeSubmit( out bool aP0_IsSucessoConexao )
      {
         conectarmqtt objconectarmqtt;
         objconectarmqtt = new conectarmqtt();
         objconectarmqtt.AV11IsSucessoConexao = false ;
         objconectarmqtt.context.SetSubmitInitialConfig(context);
         objconectarmqtt.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconectarmqtt);
         aP0_IsSucessoConexao=this.AV11IsSucessoConexao;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conectarmqtt)stateInfo).executePrivate();
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
         new getmqttconfig(context ).execute( out  AV9MQTTConfig, out  AV10URL) ;
         new connect(context ).execute(  AV10URL,  AV9MQTTConfig, out  AV8MQTTStatus) ;
         if ( ! AV8MQTTStatus.gxTpr_Error )
         {
            AV14GXLvl6 = 0;
            /* Using cursor P003B2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A91MqttConnectionDataHora = P003B2_A91MqttConnectionDataHora[0];
               A92MqttConnectionGUID = (Guid)((Guid)(P003B2_A92MqttConnectionGUID[0]));
               A90MqttConnectionId = P003B2_A90MqttConnectionId[0];
               AV14GXLvl6 = 1;
               A91MqttConnectionDataHora = DateTimeUtil.ServerNow( context, pr_default);
               A92MqttConnectionGUID = (Guid)(AV8MQTTStatus.gxTpr_Key);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P003B3 */
               pr_default.execute(1, new Object[] {A91MqttConnectionDataHora, A92MqttConnectionGUID, A90MqttConnectionId});
               pr_default.close(1);
               dsDefault.SmartCacheProvider.SetUpdated("MqttConnection");
               if (true) break;
               /* Using cursor P003B4 */
               pr_default.execute(2, new Object[] {A91MqttConnectionDataHora, A92MqttConnectionGUID, A90MqttConnectionId});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("MqttConnection");
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV14GXLvl6 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE MqttConnection

               */
               A91MqttConnectionDataHora = DateTimeUtil.ServerNow( context, pr_default);
               A92MqttConnectionGUID = (Guid)(AV8MQTTStatus.gxTpr_Key);
               /* Using cursor P003B5 */
               pr_default.execute(3, new Object[] {A91MqttConnectionDataHora, A92MqttConnectionGUID});
               A90MqttConnectionId = P003B5_A90MqttConnectionId[0];
               pr_default.close(3);
               dsDefault.SmartCacheProvider.SetUpdated("MqttConnection");
               if ( (pr_default.getStatus(3) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
            }
            context.CommitDataStores("conectarmqtt",pr_default);
            AV11IsSucessoConexao = true;
         }
         else
         {
            AV11IsSucessoConexao = false;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("conectarmqtt",pr_default);
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
         AV9MQTTConfig = new SdtMqttConfig(context);
         AV10URL = "";
         AV8MQTTStatus = new SdtMqttStatus(context);
         scmdbuf = "";
         P003B2_A91MqttConnectionDataHora = new DateTime[] {DateTime.MinValue} ;
         P003B2_A92MqttConnectionGUID = new Guid[] {Guid.Empty} ;
         P003B2_A90MqttConnectionId = new int[1] ;
         A91MqttConnectionDataHora = (DateTime)(DateTime.MinValue);
         A92MqttConnectionGUID = (Guid)(Guid.Empty);
         P003B5_A90MqttConnectionId = new int[1] ;
         Gx_emsg = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.conectarmqtt__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conectarmqtt__default(),
            new Object[][] {
                new Object[] {
               P003B2_A91MqttConnectionDataHora, P003B2_A92MqttConnectionGUID, P003B2_A90MqttConnectionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P003B5_A90MqttConnectionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14GXLvl6 ;
      private int A90MqttConnectionId ;
      private int GX_INS14 ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A91MqttConnectionDataHora ;
      private bool AV11IsSucessoConexao ;
      private string AV10URL ;
      private Guid A92MqttConnectionGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P003B2_A91MqttConnectionDataHora ;
      private Guid[] P003B2_A92MqttConnectionGUID ;
      private int[] P003B2_A90MqttConnectionId ;
      private int[] P003B5_A90MqttConnectionId ;
      private bool aP0_IsSucessoConexao ;
      private IDataStoreProvider pr_gam ;
      private SdtMqttStatus AV8MQTTStatus ;
      private SdtMqttConfig AV9MQTTConfig ;
   }

   public class conectarmqtt__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class conectarmqtt__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003B2;
        prmP003B2 = new Object[] {
        };
        Object[] prmP003B3;
        prmP003B3 = new Object[] {
        new Object[] {"@MqttConnectionDataHora",SqlDbType.DateTime,10,5} ,
        new Object[] {"@MqttConnectionGUID",SqlDbType.UniqueIdentifier,4,0} ,
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmP003B4;
        prmP003B4 = new Object[] {
        new Object[] {"@MqttConnectionDataHora",SqlDbType.DateTime,10,5} ,
        new Object[] {"@MqttConnectionGUID",SqlDbType.UniqueIdentifier,4,0} ,
        new Object[] {"@MqttConnectionId",SqlDbType.Int,8,0}
        };
        Object[] prmP003B5;
        prmP003B5 = new Object[] {
        new Object[] {"@MqttConnectionDataHora",SqlDbType.DateTime,10,5} ,
        new Object[] {"@MqttConnectionGUID",SqlDbType.UniqueIdentifier,4,0}
        };
        def= new CursorDef[] {
            new CursorDef("P003B2", "SELECT TOP 1 [MqttConnectionDataHora], [MqttConnectionGUID], [MqttConnectionId] FROM [MqttConnection] WITH (UPDLOCK) ORDER BY [MqttConnectionId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003B2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P003B3", "UPDATE [MqttConnection] SET [MqttConnectionDataHora]=@MqttConnectionDataHora, [MqttConnectionGUID]=@MqttConnectionGUID  WHERE [MqttConnectionId] = @MqttConnectionId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003B3)
           ,new CursorDef("P003B4", "UPDATE [MqttConnection] SET [MqttConnectionDataHora]=@MqttConnectionDataHora, [MqttConnectionGUID]=@MqttConnectionGUID  WHERE [MqttConnectionId] = @MqttConnectionId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003B4)
           ,new CursorDef("P003B5", "INSERT INTO [MqttConnection]([MqttConnectionDataHora], [MqttConnectionGUID]) VALUES(@MqttConnectionDataHora, @MqttConnectionGUID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP003B5)
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
              table[0][0] = rslt.getGXDateTime(1);
              table[1][0] = rslt.getGuid(2);
              table[2][0] = rslt.getInt(3);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              return;
     }
  }

  public void setParameters( int cursor ,
                             IFieldSetter stmt ,
                             Object[] parms )
  {
     switch ( cursor )
     {
           case 1 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (Guid)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              return;
           case 2 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (Guid)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              return;
           case 3 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (Guid)parms[1]);
              return;
     }
  }

}

}
