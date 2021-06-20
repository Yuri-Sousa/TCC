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
   public class desatrelarrastreador : GXProcedure
   {
      public desatrelarrastreador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public desatrelarrastreador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_RastreadorId )
      {
         this.AV9RastreadorId = aP0_RastreadorId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_RastreadorId )
      {
         desatrelarrastreador objdesatrelarrastreador;
         objdesatrelarrastreador = new desatrelarrastreador();
         objdesatrelarrastreador.AV9RastreadorId = aP0_RastreadorId;
         objdesatrelarrastreador.context.SetSubmitInitialConfig(context);
         objdesatrelarrastreador.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdesatrelarrastreador);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((desatrelarrastreador)stateInfo).executePrivate();
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
         /* Using cursor P003N2 */
         pr_default.execute(0, new Object[] {AV9RastreadorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106RastreadorId = P003N2_A106RastreadorId[0];
            A112RastreadorAtrelado = P003N2_A112RastreadorAtrelado[0];
            A112RastreadorAtrelado = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P003N3 */
            pr_default.execute(1, new Object[] {A112RastreadorAtrelado, A106RastreadorId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
            if (true) break;
            /* Using cursor P003N4 */
            pr_default.execute(2, new Object[] {A112RastreadorAtrelado, A106RastreadorId});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         context.CommitDataStores("desatrelarrastreador",pr_default);
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
         P003N2_A106RastreadorId = new int[1] ;
         P003N2_A112RastreadorAtrelado = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.desatrelarrastreador__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.desatrelarrastreador__default(),
            new Object[][] {
                new Object[] {
               P003N2_A106RastreadorId, P003N2_A112RastreadorAtrelado
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

      private int AV9RastreadorId ;
      private int A106RastreadorId ;
      private string scmdbuf ;
      private bool A112RastreadorAtrelado ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003N2_A106RastreadorId ;
      private bool[] P003N2_A112RastreadorAtrelado ;
      private IDataStoreProvider pr_gam ;
   }

   public class desatrelarrastreador__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class desatrelarrastreador__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP003N2;
        prmP003N2 = new Object[] {
        new Object[] {"@AV9RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmP003N3;
        prmP003N3 = new Object[] {
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmP003N4;
        prmP003N4 = new Object[] {
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("P003N2", "SELECT TOP 1 [RastreadorId], [RastreadorAtrelado] FROM [Rastreador] WITH (UPDLOCK) WHERE [RastreadorId] = @AV9RastreadorId ORDER BY [RastreadorId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003N2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P003N3", "UPDATE [Rastreador] SET [RastreadorAtrelado]=@RastreadorAtrelado  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003N3)
           ,new CursorDef("P003N4", "UPDATE [Rastreador] SET [RastreadorAtrelado]=@RastreadorAtrelado  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003N4)
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
