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
   public class wwp_userupdatesubscription : GXProcedure
   {
      public wwp_userupdatesubscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_userupdatesubscription( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( bool aP0_Subscribe ,
                           ref long aP1_WWPSubscriptionId ,
                           long aP2_WWPNotificationDefinitionId ,
                           string aP3_WWPSubscriptionEntityRecordId ,
                           string aP4_WWPSubscriptionEntityRecordDescription )
      {
         this.AV12Subscribe = aP0_Subscribe;
         this.AV8WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionEntityRecordId = aP3_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP4_WWPSubscriptionEntityRecordDescription;
         initialize();
         executePrivate();
         aP1_WWPSubscriptionId=this.AV8WWPSubscriptionId;
      }

      public void executeSubmit( bool aP0_Subscribe ,
                                 ref long aP1_WWPSubscriptionId ,
                                 long aP2_WWPNotificationDefinitionId ,
                                 string aP3_WWPSubscriptionEntityRecordId ,
                                 string aP4_WWPSubscriptionEntityRecordDescription )
      {
         wwp_userupdatesubscription objwwp_userupdatesubscription;
         objwwp_userupdatesubscription = new wwp_userupdatesubscription();
         objwwp_userupdatesubscription.AV12Subscribe = aP0_Subscribe;
         objwwp_userupdatesubscription.AV8WWPSubscriptionId = aP1_WWPSubscriptionId;
         objwwp_userupdatesubscription.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         objwwp_userupdatesubscription.AV10WWPSubscriptionEntityRecordId = aP3_WWPSubscriptionEntityRecordId;
         objwwp_userupdatesubscription.AV11WWPSubscriptionEntityRecordDescription = aP4_WWPSubscriptionEntityRecordDescription;
         objwwp_userupdatesubscription.context.SetSubmitInitialConfig(context);
         objwwp_userupdatesubscription.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_userupdatesubscription);
         aP1_WWPSubscriptionId=this.AV8WWPSubscriptionId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_userupdatesubscription)stateInfo).executePrivate();
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
         if ( AV12Subscribe )
         {
            AV13WWPSubscription.Load(AV8WWPSubscriptionId);
            if ( AV13WWPSubscription.Success() )
            {
               AV13WWPSubscription.Delete();
               AV8WWPSubscriptionId = 0;
            }
            else
            {
               AV13WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
               AV13WWPSubscription.gxTpr_Wwpnotificationdefinitionid = AV9WWPNotificationDefinitionId;
               AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV10WWPSubscriptionEntityRecordId;
               AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
               AV13WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
               AV13WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
               AV13WWPSubscription.Save();
               AV8WWPSubscriptionId = AV13WWPSubscription.gxTpr_Wwpsubscriptionid;
            }
         }
         else
         {
            if ( AV8WWPSubscriptionId == 0 )
            {
               /* Execute user subroutine: 'CREATESUBSCRIPTIONNOTSUBSCRIBED' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            else
            {
               AV13WWPSubscription.Load(AV8WWPSubscriptionId);
               if ( StringUtil.StrCmp(AV13WWPSubscription.gxTpr_Wwpuserextendedid, new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( )) == 0 )
               {
                  AV13WWPSubscription.Delete();
               }
               else
               {
                  /* Execute user subroutine: 'CREATESUBSCRIPTIONNOTSUBSCRIBED' */
                  S111 ();
                  if ( returnInSub )
                  {
                     this.cleanup();
                     if (true) return;
                  }
               }
            }
         }
         if ( AV13WWPSubscription.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_userupdatesubscription",pr_default);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CREATESUBSCRIPTIONNOTSUBSCRIBED' Routine */
         returnInSub = false;
         AV13WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         AV13WWPSubscription.gxTpr_Wwpnotificationdefinitionid = AV9WWPNotificationDefinitionId;
         AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV10WWPSubscriptionEntityRecordId;
         AV13WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
         AV13WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = false;
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         AV13WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
         AV13WWPSubscription.Save();
         AV8WWPSubscriptionId = AV13WWPSubscription.gxTpr_Wwpsubscriptionid;
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
         AV13WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         GXt_char1 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV8WWPSubscriptionId ;
      private long AV9WWPNotificationDefinitionId ;
      private string GXt_char1 ;
      private bool AV12Subscribe ;
      private bool returnInSub ;
      private string AV10WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV13WWPSubscription ;
   }

   public class wwp_userupdatesubscription__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userupdatesubscription__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
