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
   public class atualizarveiculorastreador : GXProcedure
   {
      public atualizarveiculorastreador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public atualizarveiculorastreador( IGxContext context )
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
         this.AV12VeiculoId = aP0_VeiculoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_VeiculoId )
      {
         atualizarveiculorastreador objatualizarveiculorastreador;
         objatualizarveiculorastreador = new atualizarveiculorastreador();
         objatualizarveiculorastreador.AV12VeiculoId = aP0_VeiculoId;
         objatualizarveiculorastreador.context.SetSubmitInitialConfig(context);
         objatualizarveiculorastreador.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objatualizarveiculorastreador);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((atualizarveiculorastreador)stateInfo).executePrivate();
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
         AV9NotAddedKeyList.FromJSonString(AV10WebSession.Get("RastreadoresNaoSelecionados"), null);
         AV11AddedKeyList.FromJSonString(AV10WebSession.Get("RastreadoresSelecionados"), null);
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV11AddedKeyList.Count )
         {
            AV15RastreadorId = (int)(AV11AddedKeyList.GetNumeric(AV19GXV1));
            AV13Exist = false;
            /* Using cursor P003L2 */
            pr_default.execute(0, new Object[] {AV12VeiculoId, AV15RastreadorId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A98VeiculoId = P003L2_A98VeiculoId[0];
               A106RastreadorId = P003L2_A106RastreadorId[0];
               AV13Exist = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( ! AV13Exist )
            {
               AV16VeiculoRastreador = new SdtVeiculoRastreador(context);
               AV16VeiculoRastreador.gxTpr_Rastreadorid = AV15RastreadorId;
               AV16VeiculoRastreador.gxTpr_Veiculoid = AV12VeiculoId;
               AV16VeiculoRastreador.Insert();
               if ( AV16VeiculoRastreador.Success() )
               {
                  context.CommitDataStores("atualizarveiculorastreador",pr_default);
               }
               else
               {
                  context.RollbackDataStores("atualizarveiculorastreador",pr_default);
               }
            }
            new atrelarrastreador(context ).execute(  AV15RastreadorId) ;
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         AV21GXV2 = 1;
         while ( AV21GXV2 <= AV9NotAddedKeyList.Count )
         {
            AV15RastreadorId = (int)(AV9NotAddedKeyList.GetNumeric(AV21GXV2));
            AV13Exist = false;
            /* Using cursor P003L3 */
            pr_default.execute(1, new Object[] {AV12VeiculoId, AV15RastreadorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A98VeiculoId = P003L3_A98VeiculoId[0];
               A106RastreadorId = P003L3_A106RastreadorId[0];
               AV13Exist = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV13Exist )
            {
               AV16VeiculoRastreador = new SdtVeiculoRastreador(context);
               AV16VeiculoRastreador.Load(AV12VeiculoId, AV15RastreadorId);
               AV16VeiculoRastreador.Delete();
               if ( AV16VeiculoRastreador.Success() )
               {
                  context.CommitDataStores("atualizarveiculorastreador",pr_default);
               }
            }
            new desatrelarrastreador(context ).execute(  AV15RastreadorId) ;
            AV21GXV2 = (int)(AV21GXV2+1);
         }
         AV10WebSession.Remove("RastreadoresNaoSelecionados");
         AV10WebSession.Remove("RastreadoresSelecionados");
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
         AV9NotAddedKeyList = new GxSimpleCollection<int>();
         AV10WebSession = context.GetSession();
         AV11AddedKeyList = new GxSimpleCollection<int>();
         scmdbuf = "";
         P003L2_A98VeiculoId = new int[1] ;
         P003L2_A106RastreadorId = new int[1] ;
         AV16VeiculoRastreador = new SdtVeiculoRastreador(context);
         P003L3_A98VeiculoId = new int[1] ;
         P003L3_A106RastreadorId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.atualizarveiculorastreador__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atualizarveiculorastreador__default(),
            new Object[][] {
                new Object[] {
               P003L2_A98VeiculoId, P003L2_A106RastreadorId
               }
               , new Object[] {
               P003L3_A98VeiculoId, P003L3_A106RastreadorId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12VeiculoId ;
      private int AV19GXV1 ;
      private int AV15RastreadorId ;
      private int A98VeiculoId ;
      private int A106RastreadorId ;
      private int AV21GXV2 ;
      private string scmdbuf ;
      private bool AV13Exist ;
      private GxSimpleCollection<int> AV9NotAddedKeyList ;
      private GxSimpleCollection<int> AV11AddedKeyList ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003L2_A98VeiculoId ;
      private int[] P003L2_A106RastreadorId ;
      private int[] P003L3_A98VeiculoId ;
      private int[] P003L3_A106RastreadorId ;
      private IDataStoreProvider pr_gam ;
      private SdtVeiculoRastreador AV16VeiculoRastreador ;
   }

   public class atualizarveiculorastreador__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class atualizarveiculorastreador__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003L2;
        prmP003L2 = new Object[] {
        new Object[] {"@AV12VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@AV15RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmP003L3;
        prmP003L3 = new Object[] {
        new Object[] {"@AV12VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@AV15RastreadorId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("P003L2", "SELECT [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @AV12VeiculoId and [RastreadorId] = @AV15RastreadorId ORDER BY [VeiculoId], [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003L2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P003L3", "SELECT [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @AV12VeiculoId and [RastreadorId] = @AV15RastreadorId ORDER BY [VeiculoId], [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003L3,1, GxCacheFrequency.OFF ,false,true )
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
              table[1][0] = rslt.getInt(2);
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
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
     }
  }

}

}
