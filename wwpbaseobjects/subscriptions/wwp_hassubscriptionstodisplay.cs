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
   public class wwp_hassubscriptionstodisplay : GXProcedure
   {
      public wwp_hassubscriptionstodisplay( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_hassubscriptionstodisplay( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           out bool aP2_HasSubscriptions )
      {
         this.AV11WWPEntityName = aP0_WWPEntityName;
         this.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV9HasSubscriptions = false ;
         initialize();
         executePrivate();
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      public bool executeUdp( string aP0_WWPEntityName ,
                              short aP1_WWPNotificationAppliesTo )
      {
         execute(aP0_WWPEntityName, aP1_WWPNotificationAppliesTo, out aP2_HasSubscriptions);
         return AV9HasSubscriptions ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 short aP1_WWPNotificationAppliesTo ,
                                 out bool aP2_HasSubscriptions )
      {
         wwp_hassubscriptionstodisplay objwwp_hassubscriptionstodisplay;
         objwwp_hassubscriptionstodisplay = new wwp_hassubscriptionstodisplay();
         objwwp_hassubscriptionstodisplay.AV11WWPEntityName = aP0_WWPEntityName;
         objwwp_hassubscriptionstodisplay.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         objwwp_hassubscriptionstodisplay.AV9HasSubscriptions = false ;
         objwwp_hassubscriptionstodisplay.context.SetSubmitInitialConfig(context);
         objwwp_hassubscriptionstodisplay.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_hassubscriptionstodisplay);
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_hassubscriptionstodisplay)stateInfo).executePrivate();
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
         GXt_int1 = AV8WWPEntityId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  AV11WWPEntityName, out  GXt_int1) ;
         AV8WWPEntityId = GXt_int1;
         AV9HasSubscriptions = false;
         /* Using cursor P002W2 */
         pr_default.execute(0, new Object[] {AV8WWPEntityId, AV10WWPNotificationAppliesTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A10WWPEntityId = P002W2_A10WWPEntityId[0];
            A26WWPNotificationDefinitionAppliesTo = P002W2_A26WWPNotificationDefinitionAppliesTo[0];
            A27WWPNotificationDefinitionAllowUserSubscription = P002W2_A27WWPNotificationDefinitionAllowUserSubscription[0];
            A14WWPNotificationDefinitionId = P002W2_A14WWPNotificationDefinitionId[0];
            AV9HasSubscriptions = true;
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
         scmdbuf = "";
         P002W2_A10WWPEntityId = new long[1] ;
         P002W2_A26WWPNotificationDefinitionAppliesTo = new short[1] ;
         P002W2_A27WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         P002W2_A14WWPNotificationDefinitionId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay__default(),
            new Object[][] {
                new Object[] {
               P002W2_A10WWPEntityId, P002W2_A26WWPNotificationDefinitionAppliesTo, P002W2_A27WWPNotificationDefinitionAllowUserSubscription, P002W2_A14WWPNotificationDefinitionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10WWPNotificationAppliesTo ;
      private short A26WWPNotificationDefinitionAppliesTo ;
      private long AV8WWPEntityId ;
      private long GXt_int1 ;
      private long A10WWPEntityId ;
      private long A14WWPNotificationDefinitionId ;
      private string scmdbuf ;
      private bool AV9HasSubscriptions ;
      private bool A27WWPNotificationDefinitionAllowUserSubscription ;
      private string AV11WWPEntityName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002W2_A10WWPEntityId ;
      private short[] P002W2_A26WWPNotificationDefinitionAppliesTo ;
      private bool[] P002W2_A27WWPNotificationDefinitionAllowUserSubscription ;
      private long[] P002W2_A14WWPNotificationDefinitionId ;
      private bool aP2_HasSubscriptions ;
   }

   public class wwp_hassubscriptionstodisplay__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002W2;
          prmP002W2 = new Object[] {
          new Object[] {"@AV8WWPEntityId",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV10WWPNotificationAppliesTo",SqlDbType.SmallInt,1,0}
          };
          def= new CursorDef[] {
              new CursorDef("P002W2", "SELECT TOP 1 [WWPEntityId], [WWPNotificationDefinitionAppliesTo], [WWPNotificationDefinitionAllowUserSubscription], [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV8WWPEntityId) AND ([WWPNotificationDefinitionAllowUserSubscription] = 1) AND ([WWPNotificationDefinitionAppliesTo] = @AV10WWPNotificationAppliesTo) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002W2,1, GxCacheFrequency.OFF ,false,true )
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
                table[1][0] = rslt.getShort(2);
                table[2][0] = rslt.getBool(3);
                table[3][0] = rslt.getLong(4);
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
                stmt.SetParameter(2, (short)parms[1]);
                return;
       }
    }

 }

}
