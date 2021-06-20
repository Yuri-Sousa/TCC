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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_changenotificationstatus : GXProcedure
   {
      public wwp_changenotificationstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_changenotificationstatus( IGxContext context )
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
         wwp_changenotificationstatus objwwp_changenotificationstatus;
         objwwp_changenotificationstatus = new wwp_changenotificationstatus();
         objwwp_changenotificationstatus.context.SetSubmitInitialConfig(context);
         objwwp_changenotificationstatus.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_changenotificationstatus);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_changenotificationstatus)stateInfo).executePrivate();
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
         this.cleanup();
      }

      public void gxep_setnotificationreadunreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         initialized = 1;
         /* SetNotificationReadUnreadById Constructor */
         /* Using cursor P002S2 */
         pr_default.execute(0, new Object[] {AV8WWPNotificationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A16WWPNotificationId = P002S2_A16WWPNotificationId[0];
            A73WWPNotificationIsRead = P002S2_A73WWPNotificationIsRead[0];
            if ( A73WWPNotificationIsRead )
            {
               A73WWPNotificationIsRead = false;
            }
            else
            {
               A73WWPNotificationIsRead = true;
            }
            /* Using cursor P002S3 */
            pr_default.execute(1, new Object[] {A73WWPNotificationIsRead, A16WWPNotificationId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         executePrivate();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         this.cleanup();
      }

      public void gxep_setnotificationreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         initialized = 1;
         /* SetNotificationReadById Constructor */
         /* Optimized UPDATE. */
         /* Using cursor P002S4 */
         pr_default.execute(2, new Object[] {AV8WWPNotificationId});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
         executePrivate();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         this.cleanup();
      }

      public void gxep_setallnotificationsofloggeduserread( )
      {
         initialize();
         initialized = 1;
         /* SetAllNotificationsOfLoggedUserRead Constructor */
         AV14Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Optimized UPDATE. */
         /* Using cursor P002S5 */
         pr_default.execute(3, new Object[] {AV14Udparg1});
         pr_default.close(3);
         dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
         executePrivate();
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_changenotificationstatus",pr_default);
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
         P002S2_A16WWPNotificationId = new long[1] ;
         P002S2_A73WWPNotificationIsRead = new bool[] {false} ;
         AV14Udparg1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus__default(),
            new Object[][] {
                new Object[] {
               P002S2_A16WWPNotificationId, P002S2_A73WWPNotificationIsRead
               }
               , new Object[] {
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

      private short initialized ;
      private long AV8WWPNotificationId ;
      private long A16WWPNotificationId ;
      private string scmdbuf ;
      private string AV14Udparg1 ;
      private bool A73WWPNotificationIsRead ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_WWPNotificationId ;
      private IDataStoreProvider pr_default ;
      private long[] P002S2_A16WWPNotificationId ;
      private bool[] P002S2_A73WWPNotificationIsRead ;
   }

   public class wwp_changenotificationstatus__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002S2;
          prmP002S2 = new Object[] {
          new Object[] {"@AV8WWPNotificationId",SqlDbType.Decimal,10,0}
          };
          Object[] prmP002S3;
          prmP002S3 = new Object[] {
          new Object[] {"@WWPNotificationIsRead",SqlDbType.Bit,4,0} ,
          new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
          };
          Object[] prmP002S4;
          prmP002S4 = new Object[] {
          new Object[] {"@AV8WWPNotificationId",SqlDbType.Decimal,10,0}
          };
          Object[] prmP002S5;
          prmP002S5 = new Object[] {
          new Object[] {"@AV14Udparg1",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P002S2", "SELECT [WWPNotificationId], [WWPNotificationIsRead] FROM [WWP_Notification] WITH (UPDLOCK) WHERE [WWPNotificationId] = @AV8WWPNotificationId ORDER BY [WWPNotificationId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002S2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002S3", "UPDATE [WWP_Notification] SET [WWPNotificationIsRead]=@WWPNotificationIsRead  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002S3)
             ,new CursorDef("P002S4", "UPDATE [WWP_Notification] SET [WWPNotificationIsRead]=CONVERT(BIT, 1)  WHERE [WWPNotificationId] = @AV8WWPNotificationId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002S4)
             ,new CursorDef("P002S5", "UPDATE [WWP_Notification] SET [WWPNotificationIsRead]=CONVERT(BIT, 1)  WHERE [WWPUserExtendedId] = @AV14Udparg1", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002S5)
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
             case 1 :
                stmt.SetParameter(1, (bool)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
             case 2 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (string)parms[0]);
                return;
       }
    }

 }

}
