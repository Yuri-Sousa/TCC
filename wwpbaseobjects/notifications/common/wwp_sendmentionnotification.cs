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
   public class wwp_sendmentionnotification : GXProcedure
   {
      public wwp_sendmentionnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_sendmentionnotification( IGxContext context )
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
                           string aP3_pWWPNotificationDefinitionIcon ,
                           string aP4_pWWPNotificationDefinitionTitle ,
                           string aP5_pWWPNotificationDefinitionShortDescription ,
                           string aP6_pWWPNotificationDefinitionLongDescription ,
                           string aP7_pWWPNotificationDefinitionLink ,
                           string aP8_WWPNotificationMetadata ,
                           string aP9_MentionWWPUserExtendedIdCollectionJson )
      {
         this.AV25WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV20WWPEntityName = aP1_WWPEntityName;
         this.AV30WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV8pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV12pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV11pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV10pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV9pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV29WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV31MentionWWPUserExtendedIdCollectionJson = aP9_MentionWWPUserExtendedIdCollectionJson;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_pWWPNotificationDefinitionIcon ,
                                 string aP4_pWWPNotificationDefinitionTitle ,
                                 string aP5_pWWPNotificationDefinitionShortDescription ,
                                 string aP6_pWWPNotificationDefinitionLongDescription ,
                                 string aP7_pWWPNotificationDefinitionLink ,
                                 string aP8_WWPNotificationMetadata ,
                                 string aP9_MentionWWPUserExtendedIdCollectionJson )
      {
         wwp_sendmentionnotification objwwp_sendmentionnotification;
         objwwp_sendmentionnotification = new wwp_sendmentionnotification();
         objwwp_sendmentionnotification.AV25WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         objwwp_sendmentionnotification.AV20WWPEntityName = aP1_WWPEntityName;
         objwwp_sendmentionnotification.AV30WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         objwwp_sendmentionnotification.AV8pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         objwwp_sendmentionnotification.AV12pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         objwwp_sendmentionnotification.AV11pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         objwwp_sendmentionnotification.AV10pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         objwwp_sendmentionnotification.AV9pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         objwwp_sendmentionnotification.AV29WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         objwwp_sendmentionnotification.AV31MentionWWPUserExtendedIdCollectionJson = aP9_MentionWWPUserExtendedIdCollectionJson;
         objwwp_sendmentionnotification.context.SetSubmitInitialConfig(context);
         objwwp_sendmentionnotification.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_sendmentionnotification);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_sendmentionnotification)stateInfo).executePrivate();
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
         AV35Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV20WWPEntityName);
         /* Using cursor P002X2 */
         pr_default.execute(0, new Object[] {AV35Udparg1, AV25WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A10WWPEntityId = P002X2_A10WWPEntityId[0];
            A53WWPNotificationDefinitionName = P002X2_A53WWPNotificationDefinitionName[0];
            A14WWPNotificationDefinitionId = P002X2_A14WWPNotificationDefinitionId[0];
            A56WWPNotificationDefinitionIcon = P002X2_A56WWPNotificationDefinitionIcon[0];
            A57WWPNotificationDefinitionTitle = P002X2_A57WWPNotificationDefinitionTitle[0];
            A58WWPNotificationDefinitionShortDescription = P002X2_A58WWPNotificationDefinitionShortDescription[0];
            A59WWPNotificationDefinitionLongDescription = P002X2_A59WWPNotificationDefinitionLongDescription[0];
            A60WWPNotificationDefinitionLink = P002X2_A60WWPNotificationDefinitionLink[0];
            AV22WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8pWWPNotificationDefinitionIcon)) )
            {
               AV21WWPNotificationDefinitionIcon = A56WWPNotificationDefinitionIcon;
            }
            else
            {
               AV21WWPNotificationDefinitionIcon = AV8pWWPNotificationDefinitionIcon;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12pWWPNotificationDefinitionTitle)) )
            {
               AV27WWPNotificationDefinitionTitle = A57WWPNotificationDefinitionTitle;
            }
            else
            {
               AV27WWPNotificationDefinitionTitle = AV12pWWPNotificationDefinitionTitle;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11pWWPNotificationDefinitionShortDescription)) )
            {
               AV26WWPNotificationDefinitionShortDescription = A58WWPNotificationDefinitionShortDescription;
            }
            else
            {
               AV26WWPNotificationDefinitionShortDescription = AV11pWWPNotificationDefinitionShortDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10pWWPNotificationDefinitionLongDescription)) )
            {
               AV24WWPNotificationDefinitionLongDescription = A59WWPNotificationDefinitionLongDescription;
            }
            else
            {
               AV24WWPNotificationDefinitionLongDescription = AV10pWWPNotificationDefinitionLongDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9pWWPNotificationDefinitionLink)) )
            {
               AV23WWPNotificationDefinitionLink = A60WWPNotificationDefinitionLink;
            }
            else
            {
               AV23WWPNotificationDefinitionLink = AV9pWWPNotificationDefinitionLink;
            }
            AV18MentionsWWPUserExtendedIdCollection.FromJSonString(AV31MentionWWPUserExtendedIdCollectionJson, null);
            AV36GXV1 = 1;
            while ( AV36GXV1 <= AV18MentionsWWPUserExtendedIdCollection.Count )
            {
               AV13WWPUserExtendedId = AV18MentionsWWPUserExtendedIdCollection.GetString(AV36GXV1);
               new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV13WWPUserExtendedId,  AV22WWPNotificationDefinitionId,  AV27WWPNotificationDefinitionTitle,  AV26WWPNotificationDefinitionShortDescription,  AV24WWPNotificationDefinitionLongDescription, ref  AV23WWPNotificationDefinitionLink,  AV29WWPNotificationMetadata,  AV21WWPNotificationDefinitionIcon,  true) ;
               AV36GXV1 = (int)(AV36GXV1+1);
            }
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
         P002X2_A10WWPEntityId = new long[1] ;
         P002X2_A53WWPNotificationDefinitionName = new string[] {""} ;
         P002X2_A14WWPNotificationDefinitionId = new long[1] ;
         P002X2_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         P002X2_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         P002X2_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         P002X2_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         P002X2_A60WWPNotificationDefinitionLink = new string[] {""} ;
         A53WWPNotificationDefinitionName = "";
         A56WWPNotificationDefinitionIcon = "";
         A57WWPNotificationDefinitionTitle = "";
         A58WWPNotificationDefinitionShortDescription = "";
         A59WWPNotificationDefinitionLongDescription = "";
         A60WWPNotificationDefinitionLink = "";
         AV21WWPNotificationDefinitionIcon = "";
         AV27WWPNotificationDefinitionTitle = "";
         AV26WWPNotificationDefinitionShortDescription = "";
         AV24WWPNotificationDefinitionLongDescription = "";
         AV23WWPNotificationDefinitionLink = "";
         AV18MentionsWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         AV13WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendmentionnotification__default(),
            new Object[][] {
                new Object[] {
               P002X2_A10WWPEntityId, P002X2_A53WWPNotificationDefinitionName, P002X2_A14WWPNotificationDefinitionId, P002X2_A56WWPNotificationDefinitionIcon, P002X2_A57WWPNotificationDefinitionTitle, P002X2_A58WWPNotificationDefinitionShortDescription, P002X2_A59WWPNotificationDefinitionLongDescription, P002X2_A60WWPNotificationDefinitionLink
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV36GXV1 ;
      private long AV35Udparg1 ;
      private long A10WWPEntityId ;
      private long A14WWPNotificationDefinitionId ;
      private long AV22WWPNotificationDefinitionId ;
      private string scmdbuf ;
      private string AV13WWPUserExtendedId ;
      private string AV29WWPNotificationMetadata ;
      private string AV31MentionWWPUserExtendedIdCollectionJson ;
      private string AV25WWPNotificationDefinitionName ;
      private string AV20WWPEntityName ;
      private string AV30WWPSubscriptionEntityRecordId ;
      private string AV8pWWPNotificationDefinitionIcon ;
      private string AV12pWWPNotificationDefinitionTitle ;
      private string AV11pWWPNotificationDefinitionShortDescription ;
      private string AV10pWWPNotificationDefinitionLongDescription ;
      private string AV9pWWPNotificationDefinitionLink ;
      private string A53WWPNotificationDefinitionName ;
      private string A56WWPNotificationDefinitionIcon ;
      private string A57WWPNotificationDefinitionTitle ;
      private string A58WWPNotificationDefinitionShortDescription ;
      private string A59WWPNotificationDefinitionLongDescription ;
      private string A60WWPNotificationDefinitionLink ;
      private string AV21WWPNotificationDefinitionIcon ;
      private string AV27WWPNotificationDefinitionTitle ;
      private string AV26WWPNotificationDefinitionShortDescription ;
      private string AV24WWPNotificationDefinitionLongDescription ;
      private string AV23WWPNotificationDefinitionLink ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002X2_A10WWPEntityId ;
      private string[] P002X2_A53WWPNotificationDefinitionName ;
      private long[] P002X2_A14WWPNotificationDefinitionId ;
      private string[] P002X2_A56WWPNotificationDefinitionIcon ;
      private string[] P002X2_A57WWPNotificationDefinitionTitle ;
      private string[] P002X2_A58WWPNotificationDefinitionShortDescription ;
      private string[] P002X2_A59WWPNotificationDefinitionLongDescription ;
      private string[] P002X2_A60WWPNotificationDefinitionLink ;
      private GxSimpleCollection<string> AV18MentionsWWPUserExtendedIdCollection ;
   }

   public class wwp_sendmentionnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002X2;
          prmP002X2 = new Object[] {
          new Object[] {"@AV35Udparg1",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV25WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0}
          };
          def= new CursorDef[] {
              new CursorDef("P002X2", "SELECT [WWPEntityId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionId], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV35Udparg1) AND ([WWPNotificationDefinitionName] = @AV25WWPNotificationDefinitionName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X2,100, GxCacheFrequency.OFF ,true,false )
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
                table[1][0] = rslt.getVarchar(2);
                table[2][0] = rslt.getLong(3);
                table[3][0] = rslt.getVarchar(4);
                table[4][0] = rslt.getVarchar(5);
                table[5][0] = rslt.getVarchar(6);
                table[6][0] = rslt.getVarchar(7);
                table[7][0] = rslt.getVarchar(8);
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
       }
    }

 }

}
