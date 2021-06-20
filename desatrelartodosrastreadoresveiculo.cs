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
   public class desatrelartodosrastreadoresveiculo : GXProcedure
   {
      public desatrelartodosrastreadoresveiculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public desatrelartodosrastreadoresveiculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_VeiculoId )
      {
         this.AV9VeiculoId = aP0_VeiculoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_VeiculoId )
      {
         desatrelartodosrastreadoresveiculo objdesatrelartodosrastreadoresveiculo;
         objdesatrelartodosrastreadoresveiculo = new desatrelartodosrastreadoresveiculo();
         objdesatrelartodosrastreadoresveiculo.AV9VeiculoId = aP0_VeiculoId;
         objdesatrelartodosrastreadoresveiculo.context.SetSubmitInitialConfig(context);
         objdesatrelartodosrastreadoresveiculo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdesatrelartodosrastreadoresveiculo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((desatrelartodosrastreadoresveiculo)stateInfo).executePrivate();
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
         /* Using cursor P003O2 */
         pr_default.execute(0, new Object[] {AV9VeiculoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXT3O2 = 0;
            A98VeiculoId = P003O2_A98VeiculoId[0];
            A106RastreadorId = P003O2_A106RastreadorId[0];
            AV8RastreadorId = A106RastreadorId;
            /* Using cursor P003O3 */
            pr_default.execute(1, new Object[] {AV8RastreadorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106RastreadorId = P003O3_A106RastreadorId[0];
               A112RastreadorAtrelado = P003O3_A112RastreadorAtrelado[0];
               A112RastreadorAtrelado = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P003O4 */
               pr_default.execute(2, new Object[] {A112RastreadorAtrelado, A106RastreadorId});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
               if (true) break;
               /* Using cursor P003O5 */
               pr_default.execute(3, new Object[] {A112RastreadorAtrelado, A106RastreadorId});
               pr_default.close(3);
               dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P003O6 */
            pr_default.execute(4, new Object[] {A98VeiculoId, A106RastreadorId});
            pr_default.close(4);
            dsDefault.SmartCacheProvider.SetUpdated("VeiculoRastreador");
            GXT3O2 = 1;
            if ( GXT3O2 == 1 )
            {
               context.CommitDataStores("desatrelartodosrastreadoresveiculo",pr_default);
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
         P003O2_A98VeiculoId = new int[1] ;
         P003O2_A106RastreadorId = new int[1] ;
         P003O3_A106RastreadorId = new int[1] ;
         P003O3_A112RastreadorAtrelado = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.desatrelartodosrastreadoresveiculo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.desatrelartodosrastreadoresveiculo__default(),
            new Object[][] {
                new Object[] {
               P003O2_A98VeiculoId, P003O2_A106RastreadorId
               }
               , new Object[] {
               P003O3_A106RastreadorId, P003O3_A112RastreadorAtrelado
               }
               , new Object[] {
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

      private short GXT3O2 ;
      private int AV9VeiculoId ;
      private int A98VeiculoId ;
      private int A106RastreadorId ;
      private int AV8RastreadorId ;
      private string scmdbuf ;
      private bool A112RastreadorAtrelado ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003O2_A98VeiculoId ;
      private int[] P003O2_A106RastreadorId ;
      private int[] P003O3_A106RastreadorId ;
      private bool[] P003O3_A112RastreadorAtrelado ;
      private IDataStoreProvider pr_gam ;
   }

   public class desatrelartodosrastreadoresveiculo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class desatrelartodosrastreadoresveiculo__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003O2;
        prmP003O2 = new Object[] {
        new Object[] {"@AV9VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmP003O3;
        prmP003O3 = new Object[] {
        new Object[] {"@AV8RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmP003O4;
        prmP003O4 = new Object[] {
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmP003O5;
        prmP003O5 = new Object[] {
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmP003O6;
        prmP003O6 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("P003O2", "SELECT [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WITH (UPDLOCK) WHERE [VeiculoId] = @AV9VeiculoId ORDER BY [VeiculoId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P003O3", "SELECT TOP 1 [RastreadorId], [RastreadorAtrelado] FROM [Rastreador] WITH (UPDLOCK) WHERE [RastreadorId] = @AV8RastreadorId ORDER BY [RastreadorId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003O3,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P003O4", "UPDATE [Rastreador] SET [RastreadorAtrelado]=@RastreadorAtrelado  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003O4)
           ,new CursorDef("P003O5", "UPDATE [Rastreador] SET [RastreadorAtrelado]=@RastreadorAtrelado  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003O5)
           ,new CursorDef("P003O6", "DELETE FROM [VeiculoRastreador]  WHERE [VeiculoId] = @VeiculoId AND [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003O6)
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
              table[1][0] = rslt.getInt(2);
              return;
           case 1 :
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
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 2 :
              stmt.SetParameter(1, (bool)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 3 :
              stmt.SetParameter(1, (bool)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 4 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
