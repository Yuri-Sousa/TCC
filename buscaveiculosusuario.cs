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
   public class buscaveiculosusuario : GXProcedure
   {
      public buscaveiculosusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public buscaveiculosusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_GAMGUID ,
                           out GxSimpleCollection<int> aP1_VeiculoIdCollection )
      {
         this.AV10GAMGUID = aP0_GAMGUID;
         this.AV9VeiculoIdCollection = new GxSimpleCollection<int>() ;
         initialize();
         executePrivate();
         aP1_VeiculoIdCollection=this.AV9VeiculoIdCollection;
      }

      public GxSimpleCollection<int> executeUdp( string aP0_GAMGUID )
      {
         execute(aP0_GAMGUID, out aP1_VeiculoIdCollection);
         return AV9VeiculoIdCollection ;
      }

      public void executeSubmit( string aP0_GAMGUID ,
                                 out GxSimpleCollection<int> aP1_VeiculoIdCollection )
      {
         buscaveiculosusuario objbuscaveiculosusuario;
         objbuscaveiculosusuario = new buscaveiculosusuario();
         objbuscaveiculosusuario.AV10GAMGUID = aP0_GAMGUID;
         objbuscaveiculosusuario.AV9VeiculoIdCollection = new GxSimpleCollection<int>() ;
         objbuscaveiculosusuario.context.SetSubmitInitialConfig(context);
         objbuscaveiculosusuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbuscaveiculosusuario);
         aP1_VeiculoIdCollection=this.AV9VeiculoIdCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((buscaveiculosusuario)stateInfo).executePrivate();
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
         AV11IsAdministrator = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).checkrole("Administrator");
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11IsAdministrator ,
                                              A105VeiculoGAMGUID ,
                                              AV10GAMGUID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P003F2 */
         pr_default.execute(0, new Object[] {AV10GAMGUID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A105VeiculoGAMGUID = P003F2_A105VeiculoGAMGUID[0];
            A98VeiculoId = P003F2_A98VeiculoId[0];
            AV9VeiculoIdCollection.Add(A98VeiculoId, 0);
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
         AV9VeiculoIdCollection = new GxSimpleCollection<int>();
         scmdbuf = "";
         A105VeiculoGAMGUID = "";
         P003F2_A105VeiculoGAMGUID = new string[] {""} ;
         P003F2_A98VeiculoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.buscaveiculosusuario__default(),
            new Object[][] {
                new Object[] {
               P003F2_A105VeiculoGAMGUID, P003F2_A98VeiculoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A98VeiculoId ;
      private string AV10GAMGUID ;
      private string scmdbuf ;
      private string A105VeiculoGAMGUID ;
      private bool AV11IsAdministrator ;
      private GxSimpleCollection<int> AV9VeiculoIdCollection ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003F2_A105VeiculoGAMGUID ;
      private int[] P003F2_A98VeiculoId ;
      private GxSimpleCollection<int> aP1_VeiculoIdCollection ;
   }

   public class buscaveiculosusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003F2( IGxContext context ,
                                             bool AV11IsAdministrator ,
                                             string A105VeiculoGAMGUID ,
                                             string AV10GAMGUID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [VeiculoGAMGUID], [VeiculoId] FROM [Veiculo]";
         if ( ! AV11IsAdministrator )
         {
            AddWhere(sWhereString, "([VeiculoGAMGUID] = @AV10GAMGUID)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VeiculoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P003F2(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP003F2;
          prmP003F2 = new Object[] {
          new Object[] {"@AV10GAMGUID",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P003F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003F2,100, GxCacheFrequency.OFF ,false,false )
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
                table[1][0] = rslt.getInt(2);
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
                   stmt.SetParameter(sIdx, (string)parms[1]);
                }
                return;
       }
    }

 }

}
