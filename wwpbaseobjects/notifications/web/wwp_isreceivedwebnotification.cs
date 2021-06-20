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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_isreceivedwebnotification : GXProcedure
   {
      public wwp_isreceivedwebnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_isreceivedwebnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_WebNotificationId ,
                           out bool aP1_IsRecived )
      {
         this.AV8WebNotificationId = aP0_WebNotificationId;
         this.AV9IsRecived = false ;
         initialize();
         executePrivate();
         aP1_IsRecived=this.AV9IsRecived;
      }

      public bool executeUdp( long aP0_WebNotificationId )
      {
         execute(aP0_WebNotificationId, out aP1_IsRecived);
         return AV9IsRecived ;
      }

      public void executeSubmit( long aP0_WebNotificationId ,
                                 out bool aP1_IsRecived )
      {
         wwp_isreceivedwebnotification objwwp_isreceivedwebnotification;
         objwwp_isreceivedwebnotification = new wwp_isreceivedwebnotification();
         objwwp_isreceivedwebnotification.AV8WebNotificationId = aP0_WebNotificationId;
         objwwp_isreceivedwebnotification.AV9IsRecived = false ;
         objwwp_isreceivedwebnotification.context.SetSubmitInitialConfig(context);
         objwwp_isreceivedwebnotification.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_isreceivedwebnotification);
         aP1_IsRecived=this.AV9IsRecived;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_isreceivedwebnotification)stateInfo).executePrivate();
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
         AV9IsRecived = false;
         /* Using cursor P002K2 */
         pr_default.execute(0, new Object[] {AV8WebNotificationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A17WWPWebNotificationId = P002K2_A17WWPWebNotificationId[0];
            A51WWPWebNotificationReceived = P002K2_A51WWPWebNotificationReceived[0];
            n51WWPWebNotificationReceived = P002K2_n51WWPWebNotificationReceived[0];
            if ( A51WWPWebNotificationReceived )
            {
               AV9IsRecived = true;
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
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
         scmdbuf = "";
         P002K2_A17WWPWebNotificationId = new long[1] ;
         P002K2_A51WWPWebNotificationReceived = new bool[] {false} ;
         P002K2_n51WWPWebNotificationReceived = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_isreceivedwebnotification__default(),
            new Object[][] {
                new Object[] {
               P002K2_A17WWPWebNotificationId, P002K2_A51WWPWebNotificationReceived, P002K2_n51WWPWebNotificationReceived
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV8WebNotificationId ;
      private long A17WWPWebNotificationId ;
      private string scmdbuf ;
      private bool AV9IsRecived ;
      private bool A51WWPWebNotificationReceived ;
      private bool n51WWPWebNotificationReceived ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002K2_A17WWPWebNotificationId ;
      private bool[] P002K2_A51WWPWebNotificationReceived ;
      private bool[] P002K2_n51WWPWebNotificationReceived ;
      private bool aP1_IsRecived ;
   }

   public class wwp_isreceivedwebnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002K2;
          prmP002K2 = new Object[] {
          new Object[] {"@AV8WebNotificationId",SqlDbType.Decimal,10,0}
          };
          def= new CursorDef[] {
              new CursorDef("P002K2", "SELECT TOP 1 [WWPWebNotificationId], [WWPWebNotificationReceived] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @AV8WebNotificationId ORDER BY [WWPWebNotificationId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K2,1, GxCacheFrequency.OFF ,false,true )
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
                table[0][0] = rslt.getLong(1);
                table[1][0] = rslt.getBool(2);
                table[2][0] = rslt.wasNull(2);
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
                stmt.SetParameter(1, (long)parms[0]);
                return;
       }
    }

 }

}
