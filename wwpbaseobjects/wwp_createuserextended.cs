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
   public class wwp_createuserextended : GXProcedure
   {
      public wwp_createuserextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_createuserextended( IGxContext context )
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
                           string aP1_PhotURL )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV9PhotURL = aP1_PhotURL;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 string aP1_PhotURL )
      {
         wwp_createuserextended objwwp_createuserextended;
         objwwp_createuserextended = new wwp_createuserextended();
         objwwp_createuserextended.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         objwwp_createuserextended.AV9PhotURL = aP1_PhotURL;
         objwwp_createuserextended.context.SetSubmitInitialConfig(context);
         objwwp_createuserextended.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_createuserextended);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_createuserextended)stateInfo).executePrivate();
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
         AV8WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV8WWPUserExtended.gxTpr_Wwpuserextendedid = AV10WWPUserExtendedId;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9PhotURL)) )
         {
            AV8WWPUserExtended.gxTpr_Wwpuserextendedphoto = AV9PhotURL;
            AV8WWPUserExtended.gxTpr_Wwpuserextendedphoto_gxi = GXDbFile.PathToUrl( AV9PhotURL);
         }
         AV8WWPUserExtended.gxTpr_Wwpuserextendeddesktopnotif = true;
         AV8WWPUserExtended.gxTpr_Wwpuserextendedemainotif = true;
         AV8WWPUserExtended.gxTpr_Wwpuserextendedsmsnotif = true;
         AV8WWPUserExtended.gxTpr_Wwpuserextendedmobilenotif = true;
         AV8WWPUserExtended.Save();
         if ( AV8WWPUserExtended.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.wwp_createuserextended",pr_default);
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV13Pgmname,  "Create Extended User: "+AV8WWPUserExtended.GetMessages().ToJSonString(false)) ;
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
         AV8WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV13Pgmname = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended__default(),
            new Object[][] {
            }
         );
         AV13Pgmname = "WWPBaseObjects.WWP_CreateUserExtended";
         /* GeneXus formulas. */
         AV13Pgmname = "WWPBaseObjects.WWP_CreateUserExtended";
         context.Gx_err = 0;
      }

      private string AV10WWPUserExtendedId ;
      private string AV13Pgmname ;
      private string AV9PhotURL ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV8WWPUserExtended ;
   }

   public class wwp_createuserextended__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_createuserextended__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
