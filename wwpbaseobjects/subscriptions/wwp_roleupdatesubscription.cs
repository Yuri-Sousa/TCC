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
   public class wwp_roleupdatesubscription : GXProcedure
   {
      public wwp_roleupdatesubscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_roleupdatesubscription( IGxContext context )
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
                           string aP3_WWPSubscriptionRoleId )
      {
         this.AV8Subscribe = aP0_Subscribe;
         this.AV11WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         this.AV12WWPSubscriptionRoleId = aP3_WWPSubscriptionRoleId;
         initialize();
         executePrivate();
         aP1_WWPSubscriptionId=this.AV11WWPSubscriptionId;
      }

      public void executeSubmit( bool aP0_Subscribe ,
                                 ref long aP1_WWPSubscriptionId ,
                                 long aP2_WWPNotificationDefinitionId ,
                                 string aP3_WWPSubscriptionRoleId )
      {
         wwp_roleupdatesubscription objwwp_roleupdatesubscription;
         objwwp_roleupdatesubscription = new wwp_roleupdatesubscription();
         objwwp_roleupdatesubscription.AV8Subscribe = aP0_Subscribe;
         objwwp_roleupdatesubscription.AV11WWPSubscriptionId = aP1_WWPSubscriptionId;
         objwwp_roleupdatesubscription.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         objwwp_roleupdatesubscription.AV12WWPSubscriptionRoleId = aP3_WWPSubscriptionRoleId;
         objwwp_roleupdatesubscription.context.SetSubmitInitialConfig(context);
         objwwp_roleupdatesubscription.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_roleupdatesubscription);
         aP1_WWPSubscriptionId=this.AV11WWPSubscriptionId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_roleupdatesubscription)stateInfo).executePrivate();
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
         if ( AV8Subscribe )
         {
            AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
            AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = AV9WWPNotificationDefinitionId;
            AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
            AV10WWPSubscription.gxTpr_Wwpsubscriptionroleid = AV12WWPSubscriptionRoleId;
            AV10WWPSubscription.Save();
            AV11WWPSubscriptionId = AV10WWPSubscription.gxTpr_Wwpsubscriptionid;
            GXt_objcol_char1 = AV13WWPUserExtendedIdCollection;
            new GeneXus.Programs.wwpbaseobjects.wwp_getusersfromrole(context ).execute(  AV12WWPSubscriptionRoleId, out  GXt_objcol_char1) ;
            AV13WWPUserExtendedIdCollection = GXt_objcol_char1;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A1WWPUserExtendedId ,
                                                 AV13WWPUserExtendedIdCollection ,
                                                 AV9WWPNotificationDefinitionId ,
                                                 A14WWPNotificationDefinitionId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P00282 */
            pr_default.execute(0, new Object[] {AV9WWPNotificationDefinitionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1WWPUserExtendedId = P00282_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = P00282_n1WWPUserExtendedId[0];
               A14WWPNotificationDefinitionId = P00282_A14WWPNotificationDefinitionId[0];
               A13WWPSubscriptionId = P00282_A13WWPSubscriptionId[0];
               /* Using cursor P00283 */
               pr_default.execute(1, new Object[] {A13WWPSubscriptionId});
               pr_default.close(1);
               dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            AV10WWPSubscription.Load(AV11WWPSubscriptionId);
            AV10WWPSubscription.Delete();
         }
         if ( AV10WWPSubscription.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_roleupdatesubscription",pr_default);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_roleupdatesubscription",pr_default);
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
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         AV13WWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         scmdbuf = "";
         A1WWPUserExtendedId = "";
         P00282_A1WWPUserExtendedId = new string[] {""} ;
         P00282_n1WWPUserExtendedId = new bool[] {false} ;
         P00282_A14WWPNotificationDefinitionId = new long[1] ;
         P00282_A13WWPSubscriptionId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_roleupdatesubscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_roleupdatesubscription__default(),
            new Object[][] {
                new Object[] {
               P00282_A1WWPUserExtendedId, P00282_n1WWPUserExtendedId, P00282_A14WWPNotificationDefinitionId, P00282_A13WWPSubscriptionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV11WWPSubscriptionId ;
      private long AV9WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private long A13WWPSubscriptionId ;
      private string AV12WWPSubscriptionRoleId ;
      private string scmdbuf ;
      private string A1WWPUserExtendedId ;
      private bool AV8Subscribe ;
      private bool n1WWPUserExtendedId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private IDataStoreProvider pr_default ;
      private string[] P00282_A1WWPUserExtendedId ;
      private bool[] P00282_n1WWPUserExtendedId ;
      private long[] P00282_A14WWPNotificationDefinitionId ;
      private long[] P00282_A13WWPSubscriptionId ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV13WWPUserExtendedIdCollection ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
   }

   public class wwp_roleupdatesubscription__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_roleupdatesubscription__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00282( IGxContext context ,
                                           string A1WWPUserExtendedId ,
                                           GxSimpleCollection<string> AV13WWPUserExtendedIdCollection ,
                                           long AV9WWPNotificationDefinitionId ,
                                           long A14WWPNotificationDefinitionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[1];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT [WWPUserExtendedId], [WWPNotificationDefinitionId], [WWPSubscriptionId] FROM [WWP_Subscription] WITH (UPDLOCK)";
       AddWhere(sWhereString, "([WWPNotificationDefinitionId] = @AV9WWPNotificationDefinitionId)");
       AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV13WWPUserExtendedIdCollection, "[WWPUserExtendedId] IN (", ")")+")");
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
             case 0 :
                   return conditional_P00282(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

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
        Object[] prmP00283;
        prmP00283 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmP00282;
        prmP00282 = new Object[] {
        new Object[] {"@AV9WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("P00282", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00282,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00283", "DELETE FROM [WWP_Subscription]  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00283)
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
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.wasNull(1);
              table[2][0] = rslt.getLong(2);
              table[3][0] = rslt.getLong(3);
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
              sIdx = 0;
              if ( (short)parms[0] == 0 )
              {
                 sIdx = (short)(sIdx+1);
                 stmt.SetParameter(sIdx, (long)parms[1]);
              }
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
