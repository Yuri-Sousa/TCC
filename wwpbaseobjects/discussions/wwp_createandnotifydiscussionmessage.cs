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
   public class wwp_createandnotifydiscussionmessage : GXProcedure
   {
      public wwp_createandnotifydiscussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_createandnotifydiscussionmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_WWPEntityId ,
                           long aP1_WWPDiscussionMessageThreadId ,
                           string aP2_WWPDiscussionMessageEntityRecordId ,
                           string aP3_Message ,
                           string aP4_MentionWWPUserExtendedIdCollectionJson ,
                           string aP5_SessionValue ,
                           string aP6_NotificationTitle ,
                           string aP7_WWPSubscriptionEntityRecordDescription ,
                           string aP8_WWPNotificationLink ,
                           out bool aP9_DiscussionMessageCreated )
      {
         this.AV18WWPEntityId = aP0_WWPEntityId;
         this.AV17WWPDiscussionMessageThreadId = aP1_WWPDiscussionMessageThreadId;
         this.AV16WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         this.AV14Message = aP3_Message;
         this.AV13MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         this.AV15SessionValue = aP5_SessionValue;
         this.AV19NotificationTitle = aP6_NotificationTitle;
         this.AV21WWPSubscriptionEntityRecordDescription = aP7_WWPSubscriptionEntityRecordDescription;
         this.AV20WWPNotificationLink = aP8_WWPNotificationLink;
         this.AV11DiscussionMessageCreated = false ;
         initialize();
         executePrivate();
         aP9_DiscussionMessageCreated=this.AV11DiscussionMessageCreated;
      }

      public bool executeUdp( long aP0_WWPEntityId ,
                              long aP1_WWPDiscussionMessageThreadId ,
                              string aP2_WWPDiscussionMessageEntityRecordId ,
                              string aP3_Message ,
                              string aP4_MentionWWPUserExtendedIdCollectionJson ,
                              string aP5_SessionValue ,
                              string aP6_NotificationTitle ,
                              string aP7_WWPSubscriptionEntityRecordDescription ,
                              string aP8_WWPNotificationLink )
      {
         execute(aP0_WWPEntityId, aP1_WWPDiscussionMessageThreadId, aP2_WWPDiscussionMessageEntityRecordId, aP3_Message, aP4_MentionWWPUserExtendedIdCollectionJson, aP5_SessionValue, aP6_NotificationTitle, aP7_WWPSubscriptionEntityRecordDescription, aP8_WWPNotificationLink, out aP9_DiscussionMessageCreated);
         return AV11DiscussionMessageCreated ;
      }

      public void executeSubmit( long aP0_WWPEntityId ,
                                 long aP1_WWPDiscussionMessageThreadId ,
                                 string aP2_WWPDiscussionMessageEntityRecordId ,
                                 string aP3_Message ,
                                 string aP4_MentionWWPUserExtendedIdCollectionJson ,
                                 string aP5_SessionValue ,
                                 string aP6_NotificationTitle ,
                                 string aP7_WWPSubscriptionEntityRecordDescription ,
                                 string aP8_WWPNotificationLink ,
                                 out bool aP9_DiscussionMessageCreated )
      {
         wwp_createandnotifydiscussionmessage objwwp_createandnotifydiscussionmessage;
         objwwp_createandnotifydiscussionmessage = new wwp_createandnotifydiscussionmessage();
         objwwp_createandnotifydiscussionmessage.AV18WWPEntityId = aP0_WWPEntityId;
         objwwp_createandnotifydiscussionmessage.AV17WWPDiscussionMessageThreadId = aP1_WWPDiscussionMessageThreadId;
         objwwp_createandnotifydiscussionmessage.AV16WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         objwwp_createandnotifydiscussionmessage.AV14Message = aP3_Message;
         objwwp_createandnotifydiscussionmessage.AV13MentionWWPUserExtendedIdCollectionJson = aP4_MentionWWPUserExtendedIdCollectionJson;
         objwwp_createandnotifydiscussionmessage.AV15SessionValue = aP5_SessionValue;
         objwwp_createandnotifydiscussionmessage.AV19NotificationTitle = aP6_NotificationTitle;
         objwwp_createandnotifydiscussionmessage.AV21WWPSubscriptionEntityRecordDescription = aP7_WWPSubscriptionEntityRecordDescription;
         objwwp_createandnotifydiscussionmessage.AV20WWPNotificationLink = aP8_WWPNotificationLink;
         objwwp_createandnotifydiscussionmessage.AV11DiscussionMessageCreated = false ;
         objwwp_createandnotifydiscussionmessage.context.SetSubmitInitialConfig(context);
         objwwp_createandnotifydiscussionmessage.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_createandnotifydiscussionmessage);
         aP9_DiscussionMessageCreated=this.AV11DiscussionMessageCreated;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_createandnotifydiscussionmessage)stateInfo).executePrivate();
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
         AV9WWPDiscussionMessage = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
         AV9WWPDiscussionMessage.gxTpr_Wwpentityid = AV18WWPEntityId;
         AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessageentityrecordid = AV16WWPDiscussionMessageEntityRecordId;
         AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessagethreadid = AV17WWPDiscussionMessageThreadId;
         AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessagemessage = AV14Message;
         AV9WWPDiscussionMessage.Save();
         if ( AV9WWPDiscussionMessage.Success() )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13MentionWWPUserExtendedIdCollectionJson)) )
            {
               AV12MentionWWPUserExtendedIdCollection.FromJSonString(AV13MentionWWPUserExtendedIdCollectionJson, null);
               AV8ExcludedWWPUserExtendedIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV25GXV1 = 1;
               while ( AV25GXV1 <= AV12MentionWWPUserExtendedIdCollection.Count )
               {
                  AV22WWPUserExtendedId = AV12MentionWWPUserExtendedIdCollection.GetString(AV25GXV1);
                  AV10WWPDiscussionMessageMention = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
                  AV10WWPDiscussionMessageMention.gxTpr_Wwpdiscussionmessageid = AV9WWPDiscussionMessage.gxTpr_Wwpdiscussionmessageid;
                  AV10WWPDiscussionMessageMention.gxTpr_Wwpdiscussionmentionuserid = AV22WWPUserExtendedId;
                  AV10WWPDiscussionMessageMention.Save();
                  AV8ExcludedWWPUserExtendedIdCollection.Add(StringUtil.Trim( AV22WWPUserExtendedId), 0);
                  AV25GXV1 = (int)(AV25GXV1+1);
               }
            }
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage",pr_default);
            new GeneXus.Programs.wwpbaseobjects.discussions.wwp_notifydiscussionmessage(context ).execute(  AV9WWPDiscussionMessage.gxTpr_Wwpuserextendedfullname,  AV9WWPDiscussionMessage.gxTpr_Wwpentityname,  AV16WWPDiscussionMessageEntityRecordId,  AV8ExcludedWWPUserExtendedIdCollection.ToJSonString(false),  AV15SessionValue,  AV19NotificationTitle,  AV21WWPSubscriptionEntityRecordDescription,  AV20WWPNotificationLink) ;
            AV11DiscussionMessageCreated = true;
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
         AV9WWPDiscussionMessage = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
         AV12MentionWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         AV8ExcludedWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         AV22WWPUserExtendedId = "";
         AV10WWPDiscussionMessageMention = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_createandnotifydiscussionmessage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV25GXV1 ;
      private long AV18WWPEntityId ;
      private long AV17WWPDiscussionMessageThreadId ;
      private string AV22WWPUserExtendedId ;
      private bool AV11DiscussionMessageCreated ;
      private string AV13MentionWWPUserExtendedIdCollectionJson ;
      private string AV16WWPDiscussionMessageEntityRecordId ;
      private string AV14Message ;
      private string AV15SessionValue ;
      private string AV19NotificationTitle ;
      private string AV21WWPSubscriptionEntityRecordDescription ;
      private string AV20WWPNotificationLink ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP9_DiscussionMessageCreated ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV12MentionWWPUserExtendedIdCollection ;
      private GxSimpleCollection<string> AV8ExcludedWWPUserExtendedIdCollection ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage AV9WWPDiscussionMessage ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention AV10WWPDiscussionMessageMention ;
   }

   public class wwp_createandnotifydiscussionmessage__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_createandnotifydiscussionmessage__default : DataStoreHelperBase, IDataStoreHelper
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
