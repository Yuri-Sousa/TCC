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
   public class wwp_updateuserextendedphoto : GXProcedure
   {
      public wwp_updateuserextendedphoto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_updateuserextendedphoto( IGxContext context )
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
                           string aP1_PhotoUrl )
      {
         this.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV10PhotoUrl = aP1_PhotoUrl;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 string aP1_PhotoUrl )
      {
         wwp_updateuserextendedphoto objwwp_updateuserextendedphoto;
         objwwp_updateuserextendedphoto = new wwp_updateuserextendedphoto();
         objwwp_updateuserextendedphoto.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         objwwp_updateuserextendedphoto.AV10PhotoUrl = aP1_PhotoUrl;
         objwwp_updateuserextendedphoto.context.SetSubmitInitialConfig(context);
         objwwp_updateuserextendedphoto.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_updateuserextendedphoto);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_updateuserextendedphoto)stateInfo).executePrivate();
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10PhotoUrl)) )
         {
            AV8WWPUserExtended.Load(AV9WWPUserExtendedId);
            if ( AV8WWPUserExtended.Success() )
            {
               AV8WWPUserExtended.gxTpr_Wwpuserextendedphoto = AV10PhotoUrl;
               AV8WWPUserExtended.gxTpr_Wwpuserextendedphoto_gxi = GXDbFile.PathToUrl( AV10PhotoUrl);
               AV8WWPUserExtended.Save();
               if ( AV8WWPUserExtended.Success() )
               {
                  context.CommitDataStores("wwpbaseobjects.wwp_updateuserextendedphoto",pr_default);
               }
               else
               {
                  new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV14Pgmname,  "Update User Extended: "+AV8WWPUserExtended.GetMessages().ToJSonString(false)) ;
               }
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
         AV8WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV14Pgmname = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_updateuserextendedphoto__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_updateuserextendedphoto__default(),
            new Object[][] {
            }
         );
         AV14Pgmname = "WWPBaseObjects.WWP_UpdateUserExtendedPhoto";
         /* GeneXus formulas. */
         AV14Pgmname = "WWPBaseObjects.WWP_UpdateUserExtendedPhoto";
         context.Gx_err = 0;
      }

      private string AV9WWPUserExtendedId ;
      private string AV14Pgmname ;
      private string AV10PhotoUrl ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV8WWPUserExtended ;
   }

   public class wwp_updateuserextendedphoto__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_updateuserextendedphoto__default : DataStoreHelperBase, IDataStoreHelper
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
