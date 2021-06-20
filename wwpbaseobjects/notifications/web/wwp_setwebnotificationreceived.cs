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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_setwebnotificationreceived : GXProcedure
   {
      public wwp_setwebnotificationreceived( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_setwebnotificationreceived( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_WebNotificationId )
      {
         this.AV8WebNotificationId = aP0_WebNotificationId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_WebNotificationId )
      {
         wwp_setwebnotificationreceived objwwp_setwebnotificationreceived;
         objwwp_setwebnotificationreceived = new wwp_setwebnotificationreceived();
         objwwp_setwebnotificationreceived.AV8WebNotificationId = aP0_WebNotificationId;
         objwwp_setwebnotificationreceived.context.SetSubmitInitialConfig(context);
         objwwp_setwebnotificationreceived.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_setwebnotificationreceived);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_setwebnotificationreceived)stateInfo).executePrivate();
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
         n51WWPWebNotificationReceived = false;
         /* Optimized UPDATE. */
         /* Using cursor P002L2 */
         pr_default.execute(0, new Object[] {AV8WebNotificationId});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("WWP_WebNotification");
         /* End optimized UPDATE. */
         context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived",pr_default);
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
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV8WebNotificationId ;
      private bool n51WWPWebNotificationReceived ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_setwebnotificationreceived__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_setwebnotificationreceived__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP002L2;
        prmP002L2 = new Object[] {
        new Object[] {"@AV8WebNotificationId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("P002L2", "UPDATE [WWP_WebNotification] SET [WWPWebNotificationReceived]=CONVERT(BIT, 1)  WHERE [WWPWebNotificationId] = @AV8WebNotificationId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002L2)
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
           case 0 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
