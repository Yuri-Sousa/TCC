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
   public class buscarconexaomqtt : GXProcedure
   {
      public buscarconexaomqtt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public buscarconexaomqtt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out Guid aP0_MqttConnectionGUID )
      {
         this.AV9MqttConnectionGUID = Guid.Empty ;
         initialize();
         executePrivate();
         aP0_MqttConnectionGUID=this.AV9MqttConnectionGUID;
      }

      public Guid executeUdp( )
      {
         execute(out aP0_MqttConnectionGUID);
         return AV9MqttConnectionGUID ;
      }

      public void executeSubmit( out Guid aP0_MqttConnectionGUID )
      {
         buscarconexaomqtt objbuscarconexaomqtt;
         objbuscarconexaomqtt = new buscarconexaomqtt();
         objbuscarconexaomqtt.AV9MqttConnectionGUID = Guid.Empty ;
         objbuscarconexaomqtt.context.SetSubmitInitialConfig(context);
         objbuscarconexaomqtt.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbuscarconexaomqtt);
         aP0_MqttConnectionGUID=this.AV9MqttConnectionGUID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((buscarconexaomqtt)stateInfo).executePrivate();
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
         AV12GXLvl1 = 0;
         /* Using cursor P00382 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A92MqttConnectionGUID = (Guid)((Guid)(P00382_A92MqttConnectionGUID[0]));
            A90MqttConnectionId = P00382_A90MqttConnectionId[0];
            AV12GXLvl1 = 1;
            AV9MqttConnectionGUID = (Guid)(A92MqttConnectionGUID);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV12GXLvl1 == 0 )
         {
            AV9MqttConnectionGUID = (Guid)(Guid.Empty);
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
         AV9MqttConnectionGUID = (Guid)(Guid.Empty);
         scmdbuf = "";
         P00382_A92MqttConnectionGUID = new Guid[] {Guid.Empty} ;
         P00382_A90MqttConnectionId = new int[1] ;
         A92MqttConnectionGUID = (Guid)(Guid.Empty);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.buscarconexaomqtt__default(),
            new Object[][] {
                new Object[] {
               P00382_A92MqttConnectionGUID, P00382_A90MqttConnectionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12GXLvl1 ;
      private int A90MqttConnectionId ;
      private string scmdbuf ;
      private Guid AV9MqttConnectionGUID ;
      private Guid A92MqttConnectionGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00382_A92MqttConnectionGUID ;
      private int[] P00382_A90MqttConnectionId ;
      private Guid aP0_MqttConnectionGUID ;
   }

   public class buscarconexaomqtt__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00382;
          prmP00382 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00382", "SELECT TOP 1 [MqttConnectionGUID], [MqttConnectionId] FROM [MqttConnection] ORDER BY [MqttConnectionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00382,1, GxCacheFrequency.OFF ,false,true )
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
