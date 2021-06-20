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
   public class wwp_subscribeloggedusertodiscussion : GXProcedure
   {
      public wwp_subscribeloggedusertodiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_subscribeloggedusertodiscussion( IGxContext context )
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
                           string aP3_WWPSubscriptionEntityRecordDescription )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV12WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_WWPSubscriptionEntityRecordDescription )
      {
         wwp_subscribeloggedusertodiscussion objwwp_subscribeloggedusertodiscussion;
         objwwp_subscribeloggedusertodiscussion = new wwp_subscribeloggedusertodiscussion();
         objwwp_subscribeloggedusertodiscussion.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         objwwp_subscribeloggedusertodiscussion.AV12WWPEntityName = aP1_WWPEntityName;
         objwwp_subscribeloggedusertodiscussion.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         objwwp_subscribeloggedusertodiscussion.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         objwwp_subscribeloggedusertodiscussion.context.SetSubmitInitialConfig(context);
         objwwp_subscribeloggedusertodiscussion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_subscribeloggedusertodiscussion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_subscribeloggedusertodiscussion)stateInfo).executePrivate();
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
         AV15GXLvl1 = 0;
         AV16Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV12WWPEntityName);
         /* Using cursor P00302 */
         pr_default.execute(0, new Object[] {AV16Udparg1, AV8WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14WWPNotificationDefinitionId = P00302_A14WWPNotificationDefinitionId[0];
            A10WWPEntityId = P00302_A10WWPEntityId[0];
            A53WWPNotificationDefinitionName = P00302_A53WWPNotificationDefinitionName[0];
            AV15GXLvl1 = 1;
            AV17GXLvl5 = 0;
            AV18Udparg2 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
            /* Optimized UPDATE. */
            /* Using cursor P00303 */
            pr_default.execute(1, new Object[] {AV18Udparg2, A14WWPNotificationDefinitionId, AV9WWPSubscriptionEntityRecordId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               AV17GXLvl5 = 1;
            }
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
            /* End optimized UPDATE. */
            if ( AV17GXLvl5 == 0 )
            {
               AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
               AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = A14WWPNotificationDefinitionId;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
               AV10WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV9WWPSubscriptionEntityRecordId;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
               AV10WWPSubscription.Save();
               if ( AV10WWPSubscription.Success() )
               {
                  context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15GXLvl1 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV19Pgmname,  StringUtil.Format( "WWP_NotificationDefinition not found: %1", AV8WWPNotificationDefinitionName, "", "", "", "", "", "", "", "")) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
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
         P00302_A14WWPNotificationDefinitionId = new long[1] ;
         P00302_A10WWPEntityId = new long[1] ;
         P00302_A53WWPNotificationDefinitionName = new string[] {""} ;
         A53WWPNotificationDefinitionName = "";
         AV18Udparg2 = "";
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         GXt_char1 = "";
         AV19Pgmname = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__default(),
            new Object[][] {
                new Object[] {
               P00302_A14WWPNotificationDefinitionId, P00302_A10WWPEntityId, P00302_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               }
            }
         );
         AV19Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
         /* GeneXus formulas. */
         AV19Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
         context.Gx_err = 0;
      }

      private short AV15GXLvl1 ;
      private short AV17GXLvl5 ;
      private long AV16Udparg1 ;
      private long A14WWPNotificationDefinitionId ;
      private long A10WWPEntityId ;
      private string scmdbuf ;
      private string AV18Udparg2 ;
      private string GXt_char1 ;
      private string AV19Pgmname ;
      private string AV8WWPNotificationDefinitionName ;
      private string AV12WWPEntityName ;
      private string AV9WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private string A53WWPNotificationDefinitionName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00302_A14WWPNotificationDefinitionId ;
      private long[] P00302_A10WWPEntityId ;
      private string[] P00302_A53WWPNotificationDefinitionName ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
   }

   public class wwp_subscribeloggedusertodiscussion__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscribeloggedusertodiscussion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00302;
        prmP00302 = new Object[] {
        new Object[] {"@AV16Udparg1",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV8WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0}
        };
        Object[] prmP00303;
        prmP00303 = new Object[] {
        new Object[] {"@AV18Udparg2",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV9WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0}
        };
        def= new CursorDef[] {
            new CursorDef("P00302", "SELECT [WWPNotificationDefinitionId], [WWPEntityId], [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV16Udparg1) AND ([WWPNotificationDefinitionName] = @AV8WWPNotificationDefinitionName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00302,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00303", "UPDATE [WWP_Subscription] SET [WWPSubscriptionSubscribed]=CONVERT(BIT, 1)  WHERE ([WWPUserExtendedId] = @AV18Udparg2) AND ([WWPNotificationDefinitionId] = @WWPNotificationDefinitionId) AND ([WWPSubscriptionEntityRecordId] = @AV9WWPSubscriptionEntityRecordId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00303)
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
