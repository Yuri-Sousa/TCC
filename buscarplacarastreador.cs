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
   public class buscarplacarastreador : GXProcedure
   {
      public buscarplacarastreador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public buscarplacarastreador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_UltimoDadoLidoIdent ,
                           out string aP1_UltimoDadoLidoPlaca )
      {
         this.AV8UltimoDadoLidoIdent = aP0_UltimoDadoLidoIdent;
         this.AV9UltimoDadoLidoPlaca = "" ;
         initialize();
         executePrivate();
         aP1_UltimoDadoLidoPlaca=this.AV9UltimoDadoLidoPlaca;
      }

      public string executeUdp( long aP0_UltimoDadoLidoIdent )
      {
         execute(aP0_UltimoDadoLidoIdent, out aP1_UltimoDadoLidoPlaca);
         return AV9UltimoDadoLidoPlaca ;
      }

      public void executeSubmit( long aP0_UltimoDadoLidoIdent ,
                                 out string aP1_UltimoDadoLidoPlaca )
      {
         buscarplacarastreador objbuscarplacarastreador;
         objbuscarplacarastreador = new buscarplacarastreador();
         objbuscarplacarastreador.AV8UltimoDadoLidoIdent = aP0_UltimoDadoLidoIdent;
         objbuscarplacarastreador.AV9UltimoDadoLidoPlaca = "" ;
         objbuscarplacarastreador.context.SetSubmitInitialConfig(context);
         objbuscarplacarastreador.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbuscarplacarastreador);
         aP1_UltimoDadoLidoPlaca=this.AV9UltimoDadoLidoPlaca;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((buscarplacarastreador)stateInfo).executePrivate();
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
         /* Using cursor P003P2 */
         pr_default.execute(0, new Object[] {AV8UltimoDadoLidoIdent});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A110RastreadorSNumber = P003P2_A110RastreadorSNumber[0];
            A106RastreadorId = P003P2_A106RastreadorId[0];
            AV10RastreadorId = A106RastreadorId;
            /* Using cursor P003P3 */
            pr_default.execute(1, new Object[] {AV10RastreadorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A98VeiculoId = P003P3_A98VeiculoId[0];
               A106RastreadorId = P003P3_A106RastreadorId[0];
               A100VeiculoPlaca = P003P3_A100VeiculoPlaca[0];
               A100VeiculoPlaca = P003P3_A100VeiculoPlaca[0];
               AV9UltimoDadoLidoPlaca = A100VeiculoPlaca;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         AV9UltimoDadoLidoPlaca = "";
         scmdbuf = "";
         P003P2_A110RastreadorSNumber = new long[1] ;
         P003P2_A106RastreadorId = new int[1] ;
         P003P3_A98VeiculoId = new int[1] ;
         P003P3_A106RastreadorId = new int[1] ;
         P003P3_A100VeiculoPlaca = new string[] {""} ;
         A100VeiculoPlaca = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.buscarplacarastreador__default(),
            new Object[][] {
                new Object[] {
               P003P2_A110RastreadorSNumber, P003P2_A106RastreadorId
               }
               , new Object[] {
               P003P3_A98VeiculoId, P003P3_A106RastreadorId, P003P3_A100VeiculoPlaca
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A106RastreadorId ;
      private int AV10RastreadorId ;
      private int A98VeiculoId ;
      private long AV8UltimoDadoLidoIdent ;
      private long A110RastreadorSNumber ;
      private string scmdbuf ;
      private string AV9UltimoDadoLidoPlaca ;
      private string A100VeiculoPlaca ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003P2_A110RastreadorSNumber ;
      private int[] P003P2_A106RastreadorId ;
      private int[] P003P3_A98VeiculoId ;
      private int[] P003P3_A106RastreadorId ;
      private string[] P003P3_A100VeiculoPlaca ;
      private string aP1_UltimoDadoLidoPlaca ;
   }

   public class buscarplacarastreador__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003P2;
          prmP003P2 = new Object[] {
          new Object[] {"@AV8UltimoDadoLidoIdent",SqlDbType.Decimal,16,0}
          };
          Object[] prmP003P3;
          prmP003P3 = new Object[] {
          new Object[] {"@AV10RastreadorId",SqlDbType.Int,8,0}
          };
          def= new CursorDef[] {
              new CursorDef("P003P2", "SELECT TOP 1 [RastreadorSNumber], [RastreadorId] FROM [Rastreador] WHERE [RastreadorSNumber] = @AV8UltimoDadoLidoIdent ORDER BY [RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003P2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P003P3", "SELECT TOP 1 T1.[VeiculoId], T1.[RastreadorId], T2.[VeiculoPlaca] FROM ([VeiculoRastreador] T1 INNER JOIN [Veiculo] T2 ON T2.[VeiculoId] = T1.[VeiculoId]) WHERE T1.[RastreadorId] = @AV10RastreadorId ORDER BY T1.[RastreadorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003P3,1, GxCacheFrequency.OFF ,false,true )
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
                table[1][0] = rslt.getInt(2);
                return;
             case 1 :
                table[0][0] = rslt.getInt(1);
                table[1][0] = rslt.getInt(2);
                table[2][0] = rslt.getVarchar(3);
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
                return;
             case 1 :
                stmt.SetParameter(1, (int)parms[0]);
                return;
       }
    }

 }

}
