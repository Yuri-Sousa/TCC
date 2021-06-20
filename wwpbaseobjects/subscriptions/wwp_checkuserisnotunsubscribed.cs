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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_checkuserisnotunsubscribed : GXProcedure
   {
      public wwp_checkuserisnotunsubscribed( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_checkuserisnotunsubscribed( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_WWPNotificationDefinitionId ,
                           ref long aP1_WWPSubscriptionId ,
                           ref bool aP2_IncludeNotification )
      {
         this.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV8IncludeNotification = aP2_IncludeNotification;
         initialize();
         executePrivate();
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      public bool executeUdp( long aP0_WWPNotificationDefinitionId ,
                              ref long aP1_WWPSubscriptionId )
      {
         execute(aP0_WWPNotificationDefinitionId, ref aP1_WWPSubscriptionId, ref aP2_IncludeNotification);
         return AV8IncludeNotification ;
      }

      public void executeSubmit( long aP0_WWPNotificationDefinitionId ,
                                 ref long aP1_WWPSubscriptionId ,
                                 ref bool aP2_IncludeNotification )
      {
         wwp_checkuserisnotunsubscribed objwwp_checkuserisnotunsubscribed;
         objwwp_checkuserisnotunsubscribed = new wwp_checkuserisnotunsubscribed();
         objwwp_checkuserisnotunsubscribed.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         objwwp_checkuserisnotunsubscribed.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         objwwp_checkuserisnotunsubscribed.AV8IncludeNotification = aP2_IncludeNotification;
         objwwp_checkuserisnotunsubscribed.context.SetSubmitInitialConfig(context);
         objwwp_checkuserisnotunsubscribed.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_checkuserisnotunsubscribed);
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_checkuserisnotunsubscribed)stateInfo).executePrivate();
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
         AV14Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P00262 */
         pr_default.execute(0, new Object[] {AV14Udparg1, AV9WWPNotificationDefinitionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A23WWPSubscriptionSubscribed = P00262_A23WWPSubscriptionSubscribed[0];
            A1WWPUserExtendedId = P00262_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = P00262_n1WWPUserExtendedId[0];
            A14WWPNotificationDefinitionId = P00262_A14WWPNotificationDefinitionId[0];
            A13WWPSubscriptionId = P00262_A13WWPSubscriptionId[0];
            AV8IncludeNotification = false;
            AV10WWPSubscriptionId = A13WWPSubscriptionId;
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
         AV14Udparg1 = "";
         scmdbuf = "";
         P00262_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         P00262_A1WWPUserExtendedId = new string[] {""} ;
         P00262_n1WWPUserExtendedId = new bool[] {false} ;
         P00262_A14WWPNotificationDefinitionId = new long[1] ;
         P00262_A13WWPSubscriptionId = new long[1] ;
         A1WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed__default(),
            new Object[][] {
                new Object[] {
               P00262_A23WWPSubscriptionSubscribed, P00262_A1WWPUserExtendedId, P00262_n1WWPUserExtendedId, P00262_A14WWPNotificationDefinitionId, P00262_A13WWPSubscriptionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV9WWPNotificationDefinitionId ;
      private long AV10WWPSubscriptionId ;
      private long A14WWPNotificationDefinitionId ;
      private long A13WWPSubscriptionId ;
      private string AV14Udparg1 ;
      private string scmdbuf ;
      private string A1WWPUserExtendedId ;
      private bool AV8IncludeNotification ;
      private bool A23WWPSubscriptionSubscribed ;
      private bool n1WWPUserExtendedId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private bool aP2_IncludeNotification ;
      private IDataStoreProvider pr_default ;
      private bool[] P00262_A23WWPSubscriptionSubscribed ;
      private string[] P00262_A1WWPUserExtendedId ;
      private bool[] P00262_n1WWPUserExtendedId ;
      private long[] P00262_A14WWPNotificationDefinitionId ;
      private long[] P00262_A13WWPSubscriptionId ;
   }

   public class wwp_checkuserisnotunsubscribed__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00262;
          prmP00262 = new Object[] {
          new Object[] {"@AV14Udparg1",SqlDbType.NChar,40,0} ,
          new Object[] {"@AV9WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
          };
          def= new CursorDef[] {
              new CursorDef("P00262", "SELECT TOP 1 [WWPSubscriptionSubscribed], [WWPUserExtendedId], [WWPNotificationDefinitionId], [WWPSubscriptionId] FROM [WWP_Subscription] WHERE ([WWPUserExtendedId] = @AV14Udparg1) AND ([WWPNotificationDefinitionId] = @AV9WWPNotificationDefinitionId) AND ([WWPSubscriptionSubscribed] = 0) ORDER BY [WWPUserExtendedId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00262,1, GxCacheFrequency.OFF ,false,true )
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
                table[0][0] = rslt.getBool(1);
                table[1][0] = rslt.getString(2, 40);
                table[2][0] = rslt.wasNull(2);
                table[3][0] = rslt.getLong(3);
                table[4][0] = rslt.getLong(4);
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
                stmt.SetParameter(1, (string)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
       }
    }

 }

}
