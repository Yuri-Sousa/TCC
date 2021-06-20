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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_updatemailstatus : GXProcedure
   {
      public wwp_updatemailstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_updatemailstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_MailId ,
                           short aP1_MailStatus ,
                           string aP2_MailDetail )
      {
         this.AV10MailId = aP0_MailId;
         this.AV11MailStatus = aP1_MailStatus;
         this.AV9MailDetail = aP2_MailDetail;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_MailId ,
                                 short aP1_MailStatus ,
                                 string aP2_MailDetail )
      {
         wwp_updatemailstatus objwwp_updatemailstatus;
         objwwp_updatemailstatus = new wwp_updatemailstatus();
         objwwp_updatemailstatus.AV10MailId = aP0_MailId;
         objwwp_updatemailstatus.AV11MailStatus = aP1_MailStatus;
         objwwp_updatemailstatus.AV9MailDetail = aP2_MailDetail;
         objwwp_updatemailstatus.context.SetSubmitInitialConfig(context);
         objwwp_updatemailstatus.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_updatemailstatus);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_updatemailstatus)stateInfo).executePrivate();
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
         AV8Mail.Load(AV10MailId);
         if ( AV8Mail.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV14Pgmname,  "Mail not found with id: "+StringUtil.Str( (decimal)(AV10MailId), 10, 0)) ;
            this.cleanup();
            if (true) return;
         }
         AV8Mail.gxTpr_Wwpmailprocessed = DateTimeUtil.ServerNowMs( context, pr_default);
         AV8Mail.gxTpr_Wwpmailstatus = AV11MailStatus;
         AV8Mail.gxTpr_Wwpmaildetail = AV9MailDetail;
         AV8Mail.Save();
         if ( AV8Mail.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV14Pgmname,  "Error updating mail status with id: "+StringUtil.Str( (decimal)(AV10MailId), 10, 0)) ;
            this.cleanup();
            if (true) return;
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
         AV8Mail = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         AV14Pgmname = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus__default(),
            new Object[][] {
            }
         );
         AV14Pgmname = "WWPBaseObjects.Mail.WWP_UpdateMailStatus";
         /* GeneXus formulas. */
         AV14Pgmname = "WWPBaseObjects.Mail.WWP_UpdateMailStatus";
         context.Gx_err = 0;
      }

      private short AV11MailStatus ;
      private long AV10MailId ;
      private string AV14Pgmname ;
      private string AV9MailDetail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail AV8Mail ;
   }

   public class wwp_updatemailstatus__default : DataStoreHelperBase, IDataStoreHelper
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
