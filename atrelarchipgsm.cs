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
namespace GeneXus.Programs {
   public class atrelarchipgsm : GXProcedure
   {
      public atrelarchipgsm( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public atrelarchipgsm( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_ChipGSMId )
      {
         this.AV8ChipGSMId = aP0_ChipGSMId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_ChipGSMId )
      {
         atrelarchipgsm objatrelarchipgsm;
         objatrelarchipgsm = new atrelarchipgsm();
         objatrelarchipgsm.AV8ChipGSMId = aP0_ChipGSMId;
         objatrelarchipgsm.context.SetSubmitInitialConfig(context);
         objatrelarchipgsm.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objatrelarchipgsm);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((atrelarchipgsm)stateInfo).executePrivate();
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
         /* Using cursor P003I2 */
         pr_default.execute(0, new Object[] {AV8ChipGSMId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A113ChipGSMId = P003I2_A113ChipGSMId[0];
            A117ChipGSMAtrelado = P003I2_A117ChipGSMAtrelado[0];
            A117ChipGSMAtrelado = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P003I3 */
            pr_default.execute(1, new Object[] {A117ChipGSMAtrelado, A113ChipGSMId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("ChipGSM");
            if (true) break;
            /* Using cursor P003I4 */
            pr_default.execute(2, new Object[] {A117ChipGSMAtrelado, A113ChipGSMId});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("ChipGSM");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         context.CommitDataStores("atrelarchipgsm",pr_default);
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
         P003I2_A113ChipGSMId = new int[1] ;
         P003I2_A117ChipGSMAtrelado = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.atrelarchipgsm__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atrelarchipgsm__default(),
            new Object[][] {
                new Object[] {
               P003I2_A113ChipGSMId, P003I2_A117ChipGSMAtrelado
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8ChipGSMId ;
      private int A113ChipGSMId ;
      private string scmdbuf ;
      private bool A117ChipGSMAtrelado ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003I2_A113ChipGSMId ;
      private bool[] P003I2_A117ChipGSMAtrelado ;
      private IDataStoreProvider pr_gam ;
   }

   public class atrelarchipgsm__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class atrelarchipgsm__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003I2;
        prmP003I2 = new Object[] {
        new Object[] {"@AV8ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmP003I3;
        prmP003I3 = new Object[] {
        new Object[] {"@ChipGSMAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmP003I4;
        prmP003I4 = new Object[] {
        new Object[] {"@ChipGSMAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("P003I2", "SELECT TOP 1 [ChipGSMId], [ChipGSMAtrelado] FROM [ChipGSM] WITH (UPDLOCK) WHERE [ChipGSMId] = @AV8ChipGSMId ORDER BY [ChipGSMId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P003I3", "UPDATE [ChipGSM] SET [ChipGSMAtrelado]=@ChipGSMAtrelado  WHERE [ChipGSMId] = @ChipGSMId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003I3)
           ,new CursorDef("P003I4", "UPDATE [ChipGSM] SET [ChipGSMAtrelado]=@ChipGSMAtrelado  WHERE [ChipGSMId] = @ChipGSMId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003I4)
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
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getBool(2);
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
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (bool)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 2 :
              stmt.SetParameter(1, (bool)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
