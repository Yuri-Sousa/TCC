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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getentitybyname : GXProcedure
   {
      public wwp_getentitybyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getentitybyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPEntityName ,
                           out long aP1_WWPEntityId )
      {
         this.AV8WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPEntityId = 0 ;
         initialize();
         executePrivate();
         aP1_WWPEntityId=this.AV9WWPEntityId;
      }

      public long executeUdp( string aP0_WWPEntityName )
      {
         execute(aP0_WWPEntityName, out aP1_WWPEntityId);
         return AV9WWPEntityId ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 out long aP1_WWPEntityId )
      {
         wwp_getentitybyname objwwp_getentitybyname;
         objwwp_getentitybyname = new wwp_getentitybyname();
         objwwp_getentitybyname.AV8WWPEntityName = aP0_WWPEntityName;
         objwwp_getentitybyname.AV9WWPEntityId = 0 ;
         objwwp_getentitybyname.context.SetSubmitInitialConfig(context);
         objwwp_getentitybyname.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getentitybyname);
         aP1_WWPEntityId=this.AV9WWPEntityId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getentitybyname)stateInfo).executePrivate();
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
         AV13GXLvl1 = 0;
         /* Using cursor P00212 */
         pr_default.execute(0, new Object[] {AV8WWPEntityName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A12WWPEntityName = P00212_A12WWPEntityName[0];
            A10WWPEntityId = P00212_A10WWPEntityId[0];
            AV13GXLvl1 = 1;
            AV9WWPEntityId = A10WWPEntityId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl1 == 0 )
         {
            AV10WWP_Entity = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
            AV10WWP_Entity.gxTpr_Wwpentityname = AV8WWPEntityName;
            AV10WWP_Entity.Save();
            if ( AV10WWP_Entity.Success() )
            {
               AV9WWPEntityId = AV10WWP_Entity.gxTpr_Wwpentityid;
            }
         }
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
         P00212_A12WWPEntityName = new string[] {""} ;
         P00212_A10WWPEntityId = new long[1] ;
         A12WWPEntityName = "";
         AV10WWP_Entity = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname__default(),
            new Object[][] {
                new Object[] {
               P00212_A12WWPEntityName, P00212_A10WWPEntityId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13GXLvl1 ;
      private long AV9WWPEntityId ;
      private long A10WWPEntityId ;
      private string scmdbuf ;
      private string AV8WWPEntityName ;
      private string A12WWPEntityName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00212_A12WWPEntityName ;
      private long[] P00212_A10WWPEntityId ;
      private long aP1_WWPEntityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity AV10WWP_Entity ;
   }

   public class wwp_getentitybyname__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00212;
          prmP00212 = new Object[] {
          new Object[] {"@AV8WWPEntityName",SqlDbType.NVarChar,100,0}
          };
          def= new CursorDef[] {
              new CursorDef("P00212", "SELECT TOP 1 [WWPEntityName], [WWPEntityId] FROM [WWP_Entity] WHERE [WWPEntityName] = @AV8WWPEntityName ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00212,1, GxCacheFrequency.OFF ,false,true )
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
                table[0][0] = rslt.getVarchar(1);
                table[1][0] = rslt.getLong(2);
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
                stmt.SetParameter(1, (string)parms[0]);
                return;
       }
    }

 }

}
