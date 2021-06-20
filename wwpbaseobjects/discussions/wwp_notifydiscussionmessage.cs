using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class wwp_notifydiscussionmessage : GXProcedure
   {
      public wwp_notifydiscussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_notifydiscussionmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPUserExtendedFullName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPDiscussionMessageEntityRecordId ,
                           string aP3_MentionWWPUserExtendedIdCollectionJson ,
                           string aP4_SessionValue ,
                           string aP5_NotificationTitle ,
                           string aP6_WWPSubscriptionEntityRecordDescription ,
                           string aP7_WWPNotificationLink )
      {
         this.AV23WWPUserExtendedFullName = aP0_WWPUserExtendedFullName;
         this.AV24WWPEntityName = aP1_WWPEntityName;
         this.AV15WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         this.AV21MentionWWPUserExtendedIdCollectionJson = aP3_MentionWWPUserExtendedIdCollectionJson;
         this.AV14SessionValue = aP4_SessionValue;
         this.AV8NotificationTitle = aP5_NotificationTitle;
         this.AV19WWPSubscriptionEntityRecordDescription = aP6_WWPSubscriptionEntityRecordDescription;
         this.AV18WWPNotificationLink = aP7_WWPNotificationLink;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPUserExtendedFullName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPDiscussionMessageEntityRecordId ,
                                 string aP3_MentionWWPUserExtendedIdCollectionJson ,
                                 string aP4_SessionValue ,
                                 string aP5_NotificationTitle ,
                                 string aP6_WWPSubscriptionEntityRecordDescription ,
                                 string aP7_WWPNotificationLink )
      {
         wwp_notifydiscussionmessage objwwp_notifydiscussionmessage;
         objwwp_notifydiscussionmessage = new wwp_notifydiscussionmessage();
         objwwp_notifydiscussionmessage.AV23WWPUserExtendedFullName = aP0_WWPUserExtendedFullName;
         objwwp_notifydiscussionmessage.AV24WWPEntityName = aP1_WWPEntityName;
         objwwp_notifydiscussionmessage.AV15WWPDiscussionMessageEntityRecordId = aP2_WWPDiscussionMessageEntityRecordId;
         objwwp_notifydiscussionmessage.AV21MentionWWPUserExtendedIdCollectionJson = aP3_MentionWWPUserExtendedIdCollectionJson;
         objwwp_notifydiscussionmessage.AV14SessionValue = aP4_SessionValue;
         objwwp_notifydiscussionmessage.AV8NotificationTitle = aP5_NotificationTitle;
         objwwp_notifydiscussionmessage.AV19WWPSubscriptionEntityRecordDescription = aP6_WWPSubscriptionEntityRecordDescription;
         objwwp_notifydiscussionmessage.AV18WWPNotificationLink = aP7_WWPNotificationLink;
         objwwp_notifydiscussionmessage.context.SetSubmitInitialConfig(context);
         objwwp_notifydiscussionmessage.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_notifydiscussionmessage);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_notifydiscussionmessage)stateInfo).executePrivate();
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
         AV9WWPNotificationMetadataSDT = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
         AV9WWPNotificationMetadataSDT.gxTpr_Sessionkey = "DiscussionThreadIdToOpen";
         AV9WWPNotificationMetadataSDT.gxTpr_Sessionvalue = AV14SessionValue;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MentionWWPUserExtendedIdCollectionJson)) )
         {
            AV10WWPNotificationShortDescription = StringUtil.Format( "%1 mencionou você num comentário em %2: %3", AV23WWPUserExtendedFullName, AV24WWPEntityName, AV19WWPSubscriptionEntityRecordDescription, "", "", "", "", "", "");
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendmentionnotification(context ).execute(  "Mention",  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  "fas fa-at NotificationFontIconInfoLight",  "Você foi mencionado",  AV10WWPNotificationShortDescription,  AV10WWPNotificationShortDescription,  AV18WWPNotificationLink,  AV9WWPNotificationMetadataSDT.ToJSonString(false, true),  AV21MentionWWPUserExtendedIdCollectionJson) ;
            new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribementioneduserstodiscussion(context ).execute(  "Discussion",  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  AV19WWPSubscriptionEntityRecordDescription,  AV21MentionWWPUserExtendedIdCollectionJson) ;
         }
         AV10WWPNotificationShortDescription = StringUtil.Format( "%1 agregou um comentário em %2: %3", AV23WWPUserExtendedFullName, AV24WWPEntityName, AV19WWPSubscriptionEntityRecordDescription, "", "", "", "", "", "");
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "Discussion",  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  "far fa-comment-dots NotificationFontIconInfo",  AV8NotificationTitle,  AV10WWPNotificationShortDescription,  AV10WWPNotificationShortDescription,  AV18WWPNotificationLink,  AV9WWPNotificationMetadataSDT.ToJSonString(false, true),  AV21MentionWWPUserExtendedIdCollectionJson,  true) ;
         new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion(context ).execute(  "Discussion",  AV24WWPEntityName,  AV15WWPDiscussionMessageEntityRecordId,  AV19WWPSubscriptionEntityRecordDescription) ;
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
         AV9WWPNotificationMetadataSDT = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
         AV10WWPNotificationShortDescription = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV21MentionWWPUserExtendedIdCollectionJson ;
      private string AV23WWPUserExtendedFullName ;
      private string AV24WWPEntityName ;
      private string AV15WWPDiscussionMessageEntityRecordId ;
      private string AV14SessionValue ;
      private string AV8NotificationTitle ;
      private string AV19WWPSubscriptionEntityRecordDescription ;
      private string AV18WWPNotificationLink ;
      private string AV10WWPNotificationShortDescription ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata AV9WWPNotificationMetadataSDT ;
   }

}
