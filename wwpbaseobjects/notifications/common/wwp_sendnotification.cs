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
   public class wwp_sendnotification : GXProcedure
   {
      public wwp_sendnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_sendnotification( IGxContext context )
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
                           string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                           bool aP10_DoCommit )
      {
         this.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV18WWPEntityName = aP1_WWPEntityName;
         this.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         this.AV9DoCommit = aP10_DoCommit;
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
                                 string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                                 bool aP10_DoCommit )
      {
         wwp_sendnotification objwwp_sendnotification;
         objwwp_sendnotification = new wwp_sendnotification();
         objwwp_sendnotification.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         objwwp_sendnotification.AV18WWPEntityName = aP1_WWPEntityName;
         objwwp_sendnotification.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         objwwp_sendnotification.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         objwwp_sendnotification.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         objwwp_sendnotification.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         objwwp_sendnotification.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         objwwp_sendnotification.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         objwwp_sendnotification.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         objwwp_sendnotification.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         objwwp_sendnotification.AV9DoCommit = aP10_DoCommit;
         objwwp_sendnotification.context.SetSubmitInitialConfig(context);
         objwwp_sendnotification.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_sendnotification);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_sendnotification)stateInfo).executePrivate();
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11ExcludedWWPUserExtendedIdCollectionJson)) )
         {
            AV10ExcludedWWPUserExtendedIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         }
         else
         {
            AV10ExcludedWWPUserExtendedIdCollection.FromJSonString(AV11ExcludedWWPUserExtendedIdCollectionJson, null);
         }
         AV10ExcludedWWPUserExtendedIdCollection.Add(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ), 0);
         AV31Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV18WWPEntityName);
         /* Using cursor P002M2 */
         pr_default.execute(0, new Object[] {AV31Udparg1, AV23WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14WWPNotificationDefinitionId = P002M2_A14WWPNotificationDefinitionId[0];
            A10WWPEntityId = P002M2_A10WWPEntityId[0];
            A53WWPNotificationDefinitionName = P002M2_A53WWPNotificationDefinitionName[0];
            A56WWPNotificationDefinitionIcon = P002M2_A56WWPNotificationDefinitionIcon[0];
            A57WWPNotificationDefinitionTitle = P002M2_A57WWPNotificationDefinitionTitle[0];
            A58WWPNotificationDefinitionShortDescription = P002M2_A58WWPNotificationDefinitionShortDescription[0];
            A59WWPNotificationDefinitionLongDescription = P002M2_A59WWPNotificationDefinitionLongDescription[0];
            A60WWPNotificationDefinitionLink = P002M2_A60WWPNotificationDefinitionLink[0];
            AV20WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13pWWPNotificationDefinitionIcon)) )
            {
               AV19WWPNotificationDefinitionIcon = A56WWPNotificationDefinitionIcon;
            }
            else
            {
               AV19WWPNotificationDefinitionIcon = AV13pWWPNotificationDefinitionIcon;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17pWWPNotificationDefinitionTitle)) )
            {
               AV25WWPNotificationDefinitionTitle = A57WWPNotificationDefinitionTitle;
            }
            else
            {
               AV25WWPNotificationDefinitionTitle = AV17pWWPNotificationDefinitionTitle;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16pWWPNotificationDefinitionShortDescription)) )
            {
               AV24WWPNotificationDefinitionShortDescription = A58WWPNotificationDefinitionShortDescription;
            }
            else
            {
               AV24WWPNotificationDefinitionShortDescription = AV16pWWPNotificationDefinitionShortDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15pWWPNotificationDefinitionLongDescription)) )
            {
               AV22WWPNotificationDefinitionLongDescription = A59WWPNotificationDefinitionLongDescription;
            }
            else
            {
               AV22WWPNotificationDefinitionLongDescription = AV15pWWPNotificationDefinitionLongDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14pWWPNotificationDefinitionLink)) )
            {
               AV21WWPNotificationDefinitionLink = A60WWPNotificationDefinitionLink;
            }
            else
            {
               AV21WWPNotificationDefinitionLink = AV14pWWPNotificationDefinitionLink;
            }
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV27WWPSubscriptionEntityRecordId ,
                                                 A22WWPSubscriptionEntityRecordId ,
                                                 A14WWPNotificationDefinitionId } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            /* Using cursor P002M3 */
            pr_default.execute(1, new Object[] {A14WWPNotificationDefinitionId, AV27WWPSubscriptionEntityRecordId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A22WWPSubscriptionEntityRecordId = P002M3_A22WWPSubscriptionEntityRecordId[0];
               A1WWPUserExtendedId = P002M3_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = P002M3_n1WWPUserExtendedId[0];
               A23WWPSubscriptionSubscribed = P002M3_A23WWPSubscriptionSubscribed[0];
               A11WWPSubscriptionRoleId = P002M3_A11WWPSubscriptionRoleId[0];
               n11WWPSubscriptionRoleId = P002M3_n11WWPSubscriptionRoleId[0];
               A13WWPSubscriptionId = P002M3_A13WWPSubscriptionId[0];
               if ( ! ( (AV10ExcludedWWPUserExtendedIdCollection.IndexOf(StringUtil.RTrim( A1WWPUserExtendedId))>0) ) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) && A23WWPSubscriptionSubscribed )
                  {
                     AV8WWPUserExtendedId = A1WWPUserExtendedId;
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, "Discussion")) ;
                  }
                  else
                  {
                     AV34GXV2 = 1;
                     GXt_objcol_char1 = AV33GXV1;
                     new GeneXus.Programs.wwpbaseobjects.wwp_getusersfromrole(context ).execute(  A11WWPSubscriptionRoleId, out  GXt_objcol_char1) ;
                     AV33GXV1 = GXt_objcol_char1;
                     while ( AV34GXV2 <= AV33GXV1.Count )
                     {
                        AV8WWPUserExtendedId = AV33GXV1.GetString(AV34GXV2);
                        /* Execute user subroutine: 'INCLUDENOTIFICATIONTOUSER' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(1);
                           this.cleanup();
                           if (true) return;
                        }
                        if ( AV12IncludeNotificationToUser )
                        {
                           new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, "Discussion")) ;
                        }
                        AV34GXV2 = (int)(AV34GXV2+1);
                     }
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9DoCommit )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_sendnotification",pr_default);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendpendingnotifications(context).executeSubmit( ) ;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'INCLUDENOTIFICATIONTOUSER' Routine */
         returnInSub = false;
         /* Using cursor P002M5 */
         pr_default.execute(2, new Object[] {AV20WWPNotificationDefinitionId, AV8WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P002M5_A40000GXC1[0];
            n40000GXC1 = P002M5_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(2);
         AV12IncludeNotificationToUser = (bool)((A40000GXC1==0));
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
         AV10ExcludedWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         scmdbuf = "";
         P002M2_A14WWPNotificationDefinitionId = new long[1] ;
         P002M2_A10WWPEntityId = new long[1] ;
         P002M2_A53WWPNotificationDefinitionName = new string[] {""} ;
         P002M2_A56WWPNotificationDefinitionIcon = new string[] {""} ;
         P002M2_A57WWPNotificationDefinitionTitle = new string[] {""} ;
         P002M2_A58WWPNotificationDefinitionShortDescription = new string[] {""} ;
         P002M2_A59WWPNotificationDefinitionLongDescription = new string[] {""} ;
         P002M2_A60WWPNotificationDefinitionLink = new string[] {""} ;
         A53WWPNotificationDefinitionName = "";
         A56WWPNotificationDefinitionIcon = "";
         A57WWPNotificationDefinitionTitle = "";
         A58WWPNotificationDefinitionShortDescription = "";
         A59WWPNotificationDefinitionLongDescription = "";
         A60WWPNotificationDefinitionLink = "";
         AV19WWPNotificationDefinitionIcon = "";
         AV25WWPNotificationDefinitionTitle = "";
         AV24WWPNotificationDefinitionShortDescription = "";
         AV22WWPNotificationDefinitionLongDescription = "";
         AV21WWPNotificationDefinitionLink = "";
         A22WWPSubscriptionEntityRecordId = "";
         P002M3_A14WWPNotificationDefinitionId = new long[1] ;
         P002M3_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         P002M3_A1WWPUserExtendedId = new string[] {""} ;
         P002M3_n1WWPUserExtendedId = new bool[] {false} ;
         P002M3_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         P002M3_A11WWPSubscriptionRoleId = new string[] {""} ;
         P002M3_n11WWPSubscriptionRoleId = new bool[] {false} ;
         P002M3_A13WWPSubscriptionId = new long[1] ;
         A1WWPUserExtendedId = "";
         A11WWPSubscriptionRoleId = "";
         AV8WWPUserExtendedId = "";
         AV33GXV1 = new GxSimpleCollection<string>();
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         P002M5_A40000GXC1 = new int[1] ;
         P002M5_n40000GXC1 = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__default(),
            new Object[][] {
                new Object[] {
               P002M2_A14WWPNotificationDefinitionId, P002M2_A10WWPEntityId, P002M2_A53WWPNotificationDefinitionName, P002M2_A56WWPNotificationDefinitionIcon, P002M2_A57WWPNotificationDefinitionTitle, P002M2_A58WWPNotificationDefinitionShortDescription, P002M2_A59WWPNotificationDefinitionLongDescription, P002M2_A60WWPNotificationDefinitionLink
               }
               , new Object[] {
               P002M3_A14WWPNotificationDefinitionId, P002M3_A22WWPSubscriptionEntityRecordId, P002M3_A1WWPUserExtendedId, P002M3_n1WWPUserExtendedId, P002M3_A23WWPSubscriptionSubscribed, P002M3_A11WWPSubscriptionRoleId, P002M3_n11WWPSubscriptionRoleId, P002M3_A13WWPSubscriptionId
               }
               , new Object[] {
               P002M5_A40000GXC1, P002M5_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV34GXV2 ;
      private int A40000GXC1 ;
      private long AV31Udparg1 ;
      private long A14WWPNotificationDefinitionId ;
      private long A10WWPEntityId ;
      private long AV20WWPNotificationDefinitionId ;
      private long A13WWPSubscriptionId ;
      private string scmdbuf ;
      private string A1WWPUserExtendedId ;
      private string A11WWPSubscriptionRoleId ;
      private string AV8WWPUserExtendedId ;
      private bool AV9DoCommit ;
      private bool n1WWPUserExtendedId ;
      private bool A23WWPSubscriptionSubscribed ;
      private bool n11WWPSubscriptionRoleId ;
      private bool returnInSub ;
      private bool AV12IncludeNotificationToUser ;
      private bool n40000GXC1 ;
      private string AV26WWPNotificationMetadata ;
      private string AV11ExcludedWWPUserExtendedIdCollectionJson ;
      private string AV23WWPNotificationDefinitionName ;
      private string AV18WWPEntityName ;
      private string AV27WWPSubscriptionEntityRecordId ;
      private string AV13pWWPNotificationDefinitionIcon ;
      private string AV17pWWPNotificationDefinitionTitle ;
      private string AV16pWWPNotificationDefinitionShortDescription ;
      private string AV15pWWPNotificationDefinitionLongDescription ;
      private string AV14pWWPNotificationDefinitionLink ;
      private string A53WWPNotificationDefinitionName ;
      private string A56WWPNotificationDefinitionIcon ;
      private string A57WWPNotificationDefinitionTitle ;
      private string A58WWPNotificationDefinitionShortDescription ;
      private string A59WWPNotificationDefinitionLongDescription ;
      private string A60WWPNotificationDefinitionLink ;
      private string AV19WWPNotificationDefinitionIcon ;
      private string AV25WWPNotificationDefinitionTitle ;
      private string AV24WWPNotificationDefinitionShortDescription ;
      private string AV22WWPNotificationDefinitionLongDescription ;
      private string AV21WWPNotificationDefinitionLink ;
      private string A22WWPSubscriptionEntityRecordId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002M2_A14WWPNotificationDefinitionId ;
      private long[] P002M2_A10WWPEntityId ;
      private string[] P002M2_A53WWPNotificationDefinitionName ;
      private string[] P002M2_A56WWPNotificationDefinitionIcon ;
      private string[] P002M2_A57WWPNotificationDefinitionTitle ;
      private string[] P002M2_A58WWPNotificationDefinitionShortDescription ;
      private string[] P002M2_A59WWPNotificationDefinitionLongDescription ;
      private string[] P002M2_A60WWPNotificationDefinitionLink ;
      private long[] P002M3_A14WWPNotificationDefinitionId ;
      private string[] P002M3_A22WWPSubscriptionEntityRecordId ;
      private string[] P002M3_A1WWPUserExtendedId ;
      private bool[] P002M3_n1WWPUserExtendedId ;
      private bool[] P002M3_A23WWPSubscriptionSubscribed ;
      private string[] P002M3_A11WWPSubscriptionRoleId ;
      private bool[] P002M3_n11WWPSubscriptionRoleId ;
      private long[] P002M3_A13WWPSubscriptionId ;
      private int[] P002M5_A40000GXC1 ;
      private bool[] P002M5_n40000GXC1 ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV10ExcludedWWPUserExtendedIdCollection ;
      private GxSimpleCollection<string> AV33GXV1 ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
   }

   public class wwp_sendnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sendnotification__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P002M3( IGxContext context ,
                                           string AV27WWPSubscriptionEntityRecordId ,
                                           string A22WWPSubscriptionEntityRecordId ,
                                           long A14WWPNotificationDefinitionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[2];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT [WWPNotificationDefinitionId], [WWPSubscriptionEntityRecordId], [WWPUserExtendedId], [WWPSubscriptionSubscribed], [WWPSubscriptionRoleId], [WWPSubscriptionId] FROM [WWP_Subscription]";
       AddWhere(sWhereString, "([WWPNotificationDefinitionId] = @WWPNotificationDefinitionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27WWPSubscriptionEntityRecordId)) )
       {
          AddWhere(sWhereString, "([WWPSubscriptionEntityRecordId] = @AV27WWPSubscriptionEntityRecordId)");
       }
       else
       {
          GXv_int2[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [WWPNotificationDefinitionId]";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 1 :
                   return conditional_P002M3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP002M2;
        prmP002M2 = new Object[] {
        new Object[] {"@AV31Udparg1",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV23WWPNotificationDefinitionName",SqlDbType.NVarChar,100,0}
        };
        Object[] prmP002M5;
        prmP002M5 = new Object[] {
        new Object[] {"@AV20WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV8WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmP002M3;
        prmP002M3 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AV27WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0}
        };
        def= new CursorDef[] {
            new CursorDef("P002M2", "SELECT [WWPNotificationDefinitionId], [WWPEntityId], [WWPNotificationDefinitionName], [WWPNotificationDefinitionIcon], [WWPNotificationDefinitionTitle], [WWPNotificationDefinitionShortDescription], [WWPNotificationDefinitionLongDescription], [WWPNotificationDefinitionLink] FROM [WWP_NotificationDefinition] WHERE ([WWPEntityId] = @AV31Udparg1) AND ([WWPNotificationDefinitionName] = @AV23WWPNotificationDefinitionName) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P002M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M3,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P002M5", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM ([WWP_Subscription] T2 INNER JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE (T2.[WWPNotificationDefinitionId] = @AV20WWPNotificationDefinitionId) AND (T2.[WWPUserExtendedId] = @AV8WWPUserExtendedId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M5,1, GxCacheFrequency.OFF ,true,false )
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
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.wasNull(3);
              table[4][0] = rslt.getBool(4);
              table[5][0] = rslt.getString(5, 40);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.wasNull(1);
              return;
     }
  }

  public void setParameters( int cursor ,
                             IFieldSetter stmt ,
                             Object[] parms )
  {
     short sIdx;
     switch ( cursor )
     {
           case 0 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 1 :
              sIdx = 0;
              if ( (short)parms[0] == 0 )
              {
                 sIdx = (short)(sIdx+1);
                 stmt.SetParameter(sIdx, (long)parms[2]);
              }
              if ( (short)parms[1] == 0 )
              {
                 sIdx = (short)(sIdx+1);
                 stmt.SetParameter(sIdx, (string)parms[3]);
              }
              return;
           case 2 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
     }
  }

}

}
