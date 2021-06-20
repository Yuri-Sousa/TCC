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
   public class atualizarfrotaveiculo : GXProcedure
   {
      public atualizarfrotaveiculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public atualizarfrotaveiculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( int aP0_FrotaId )
      {
         this.AV8FrotaId = aP0_FrotaId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_FrotaId )
      {
         atualizarfrotaveiculo objatualizarfrotaveiculo;
         objatualizarfrotaveiculo = new atualizarfrotaveiculo();
         objatualizarfrotaveiculo.AV8FrotaId = aP0_FrotaId;
         objatualizarfrotaveiculo.context.SetSubmitInitialConfig(context);
         objatualizarfrotaveiculo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objatualizarfrotaveiculo);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((atualizarfrotaveiculo)stateInfo).executePrivate();
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
         AV9NotAddedKeyList.FromJSonString(AV10WebSession.Get("PlacasNaoSelecionadas"), null);
         AV11AddedKeyList.FromJSonString(AV10WebSession.Get("PlacasSelecionadas"), null);
         AV17GXV1 = 1;
         while ( AV17GXV1 <= AV11AddedKeyList.Count )
         {
            AV12VeiculoId = (int)(AV11AddedKeyList.GetNumeric(AV17GXV1));
            AV13Exist = false;
            /* Using cursor P003G2 */
            pr_default.execute(0, new Object[] {AV8FrotaId, AV12VeiculoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A98VeiculoId = P003G2_A98VeiculoId[0];
               A93FrotaId = P003G2_A93FrotaId[0];
               AV13Exist = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( ! AV13Exist )
            {
               AV14FrotaVeiculo = new SdtFrotaVeiculo(context);
               AV14FrotaVeiculo.gxTpr_Frotaid = AV8FrotaId;
               AV14FrotaVeiculo.gxTpr_Veiculoid = AV12VeiculoId;
               AV14FrotaVeiculo.Insert();
               if ( AV14FrotaVeiculo.Success() )
               {
                  context.CommitDataStores("atualizarfrotaveiculo",pr_default);
               }
            }
            AV17GXV1 = (int)(AV17GXV1+1);
         }
         AV19GXV2 = 1;
         while ( AV19GXV2 <= AV9NotAddedKeyList.Count )
         {
            AV12VeiculoId = (int)(AV9NotAddedKeyList.GetNumeric(AV19GXV2));
            AV13Exist = false;
            /* Using cursor P003G3 */
            pr_default.execute(1, new Object[] {AV8FrotaId, AV12VeiculoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A98VeiculoId = P003G3_A98VeiculoId[0];
               A93FrotaId = P003G3_A93FrotaId[0];
               AV13Exist = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV13Exist )
            {
               AV14FrotaVeiculo = new SdtFrotaVeiculo(context);
               AV14FrotaVeiculo.Load(AV8FrotaId, AV12VeiculoId);
               AV14FrotaVeiculo.Delete();
               if ( AV14FrotaVeiculo.Success() )
               {
                  context.CommitDataStores("atualizarfrotaveiculo",pr_default);
               }
            }
            AV19GXV2 = (int)(AV19GXV2+1);
         }
         AV10WebSession.Remove("PlacasNaoSelecionadas");
         AV10WebSession.Remove("PlacasSelecionadas");
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
         P003G2_A98VeiculoId = new int[1] ;
         P003G2_A93FrotaId = new int[1] ;
         AV14FrotaVeiculo = new SdtFrotaVeiculo(context);
         P003G3_A98VeiculoId = new int[1] ;
         P003G3_A93FrotaId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.atualizarfrotaveiculo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atualizarfrotaveiculo__default(),
            new Object[][] {
                new Object[] {
               P003G2_A98VeiculoId, P003G2_A93FrotaId
               }
               , new Object[] {
               P003G3_A98VeiculoId, P003G3_A93FrotaId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8FrotaId ;
      private int AV17GXV1 ;
      private int AV12VeiculoId ;
      private int A98VeiculoId ;
      private int A93FrotaId ;
      private int AV19GXV2 ;
      private string scmdbuf ;
      private bool AV13Exist ;
      private GxSimpleCollection<int> AV9NotAddedKeyList ;
      private GxSimpleCollection<int> AV11AddedKeyList ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003G2_A98VeiculoId ;
      private int[] P003G2_A93FrotaId ;
      private int[] P003G3_A98VeiculoId ;
      private int[] P003G3_A93FrotaId ;
      private IDataStoreProvider pr_gam ;
      private SdtFrotaVeiculo AV14FrotaVeiculo ;
   }

   public class atualizarfrotaveiculo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class atualizarfrotaveiculo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP003G2;
        prmP003G2 = new Object[] {
        new Object[] {"@AV8FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@AV12VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmP003G3;
        prmP003G3 = new Object[] {
        new Object[] {"@AV8FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@AV12VeiculoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("P003G2", "SELECT [VeiculoId], [FrotaId] FROM [FrotaVeiculo] WHERE [FrotaId] = @AV8FrotaId and [VeiculoId] = @AV12VeiculoId ORDER BY [FrotaId], [VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P003G3", "SELECT [VeiculoId], [FrotaId] FROM [FrotaVeiculo] WHERE [FrotaId] = @AV8FrotaId and [VeiculoId] = @AV12VeiculoId ORDER BY [FrotaId], [VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G3,1, GxCacheFrequency.OFF ,false,true )
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
