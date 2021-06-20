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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_subscribementioneduserstodiscussion : GXProcedure
   {
      public wwp_subscribementioneduserstodiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_subscribementioneduserstodiscussion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_WWPSubscriptionEntityRecordDescription ,
                           string aP4_MentionWWPUserExtendedIdCollectionJson )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV14WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         this.AV15MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_WWPSubscriptionEntityRecordDescription ,
                                 string aP4_MentionWWPUserExtendedIdCollectionJson )
      {
         wwp_subscribementioneduserstodiscussion objwwp_subscribementioneduserstodiscussion;
         objwwp_subscribementioneduserstodiscussion = new wwp_subscribementioneduserstodiscussion();
         objwwp_subscribementioneduserstodiscussion.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         objwwp_subscribementioneduserstodiscussion.AV14WWPEntityName = aP1_WWPEntityName;
         objwwp_subscribementioneduserstodiscussion.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         objwwp_subscribementioneduserstodiscussion.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         objwwp_subscribementioneduserstodiscussion.AV15MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         objwwp_subscribementioneduserstodiscussion.context.SetSubmitInitialConfig(context);
         objwwp_subscribementioneduserstodiscussion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_subscribementioneduserstodiscussion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_subscribementioneduserstodiscussion)stateInfo).executePrivate();
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
         AV12MentionWWPUserExtendedIdCollection.FromJSonString(AV15MentionWWPUserExtendedIdCollectionJson, null);
         AV18GXLvl2 = 0;
         AV19Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV14WWPEntityName);
         /* Using cursor P002Z2 */
         pr_default.execute(0, new Object[] {AV19Udparg1, AV8WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14WWPNotificationDefinitionId = P002Z2_A14WWPNotificationDefinitionId[0];
            A10WWPEntityId = P002Z2_A10WWPEntityId[0];
            A53WWPNotificationDefinitionName = P002Z2_A53WWPNotificationDefinitionName[0];
            AV18GXLvl2 = 1;
            AV20GXV1 = 1;
            while ( AV20GXV1 <= AV12MentionWWPUserExtendedIdCollection.Count )
            {
               AV13WWPUserExtendedId = AV12MentionWWPUserExtendedIdCollection.GetString(AV20GXV1);
               AV21GXLvl6 = 0;
               /* Optimized UPDATE. */
               /* Using cursor P002Z3 */
               pr_default.execute(1, new Object[] {AV13WWPUserExtendedId, A14WWPNotificationDefinitionId, AV9WWPSubscriptionEntityRecordId});
               if ( (pr_default.getStatus(1) != 101) )
               {
                  AV21GXLvl6 = 1;
               }
               pr_default.close(1);
               dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
               /* End optimized UPDATE. */
               if ( AV21GXLvl6 == 0 )
               {
                  AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
                  AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = A14WWPNotificationDefinitionId;
                  AV10WWPSubscription.gxTpr_Wwpuserextendedid = AV13WWPUserExtendedId;
                  AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV9WWPSubscriptionEntityRecordId;
                  AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
                  AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
                  AV10WWPSubscription.Save();
                  if ( ! AV10WWPSubscription.Success() )
                  {
                     new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  "Subscribe Mentioned User",  AV10WWPSubscription.GetMessages().ToJSonString(false)) ;
                  }
               }
               AV20GXV1 = (int)(AV20GXV1+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV18GXLvl2 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV22Pgmname,  StringUtil.Format( "WWP_NotificationDefinition not found: %1", AV8WWPNotificationDefinitionName, "", "", "", "", "", "", "", "")) ;
         }
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion",pr_default);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion",pr_default);
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
         AV12MentionWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         scmdbuf = "";
         P002Z2_A14WWPNotificationDefinitionId = new long[1] ;
         P002Z2_A10WWPEntityId = new long[1] ;
         P002Z2_A53WWPNotificationDefinitionName = new string[] {""} ;
         A53WWPNotificationDefinitionName = "";
         AV13WWPUserExtendedId = "";
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         AV22Pgmname = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion__default(),
            new Object[][] {
                new Object[] {
               P002Z2_A14WWPNotificationDefinitionId, P002Z2_A10WWPEntityId, P002Z2_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               }
            }
         );
         AV22Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeMentionedUsersToDiscussion";
         /* GeneXus formulas. */
         AV22Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeMentionedUsersToDiscussion";
         context.Gx_err = 0;
      }

      private short AV18GXLvl2 ;
      private short AV21GXLvl6 ;
      private int AV20GXV1 ;
      private long AV19Udparg1 ;
      private long A14WWPNotificationDefinitionId ;
      private long A10WWPEntityId ;
      private string scmdbuf ;
      private string AV13WWPUserExtendedId ;
      private string AV22Pgmname ;
      private string AV15MentionWWPUserExtendedIdCollectionJson ;
      private string AV8WWPNotificationDefinitionName ;
      private string AV14WWPEntityName ;
      private string AV9WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private string A53WWPNotificationDefinitionName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002Z2_A14WWPNotificationDefinitionId ;
      private long[] P002Z2_A10WWPEntityId ;
      private string[] P002Z2_A53WWPNotificationDefinitionName ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV12MentionWWPUserExtendedIdCollection ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
   }

   public class wwp_subscribementioneduserstodiscussion__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscribementioneduserstodiscussion__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP002Z2;
        prmP002Z2 = new Object[] {
        new Object[] {"@AV19Udparg1",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV8WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0}
        };
        Object[] prmP002Z3;
        prmP002Z3 = new Object[] {
        new Object[] {"@AV13WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV9WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0}
        };
        def= new CursorDef[] {
            new CursorDef("P002Z2", "SELECT [WWPNotificationDefinitionId], [WWPEntityId], [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV19Udparg1) AND ([WWPNotificationDefinitionName] = @AV8WWPNotificationDefinitionName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Z2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P002Z3", "UPDATE [WWP_Subscription] SET [WWPSubscriptionSubscribed]=CONVERT(BIT, 1)  WHERE ([WWPUserExtendedId] = @AV13WWPUserExtendedId) AND ([WWPNotificationDefinitionId] = @WWPNotificationDefinitionId) AND ([WWPSubscriptionEntityRecordId] = @AV9WWPSubscriptionEntityRecordId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002Z3)
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
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getVarchar(3);
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
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 1 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (long)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              return;
     }
  }

}

}
