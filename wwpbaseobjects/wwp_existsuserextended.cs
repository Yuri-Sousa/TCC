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
   public class wwp_existsuserextended : GXProcedure
   {
      public wwp_existsuserextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_existsuserextended( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out bool aP1_Exists )
      {
         this.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV8Exists = false ;
         initialize();
         executePrivate();
         aP1_Exists=this.AV8Exists;
      }

      public bool executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_Exists);
         return AV8Exists ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out bool aP1_Exists )
      {
         wwp_existsuserextended objwwp_existsuserextended;
         objwwp_existsuserextended = new wwp_existsuserextended();
         objwwp_existsuserextended.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         objwwp_existsuserextended.AV8Exists = false ;
         objwwp_existsuserextended.context.SetSubmitInitialConfig(context);
         objwwp_existsuserextended.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_existsuserextended);
         aP1_Exists=this.AV8Exists;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_existsuserextended)stateInfo).executePrivate();
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
         AV8Exists = false;
         /* Using cursor P001T2 */
         pr_default.execute(0, new Object[] {AV9WWPUserExtendedId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1WWPUserExtendedId = P001T2_A1WWPUserExtendedId[0];
            AV8Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
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
         P001T2_A1WWPUserExtendedId = new string[] {""} ;
         A1WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended__default(),
            new Object[][] {
                new Object[] {
               P001T2_A1WWPUserExtendedId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV9WWPUserExtendedId ;
      private string scmdbuf ;
      private string A1WWPUserExtendedId ;
      private bool AV8Exists ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001T2_A1WWPUserExtendedId ;
      private bool aP1_Exists ;
   }

   public class wwp_existsuserextended__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001T2;
          prmP001T2 = new Object[] {
          new Object[] {"@AV9WWPUserExtendedId",SqlDbType.NChar,40,0}
          };
          def= new CursorDef[] {
              new CursorDef("P001T2", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @AV9WWPUserExtendedId ORDER BY [WWPUserExtendedId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001T2,1, GxCacheFrequency.OFF ,false,true )
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
