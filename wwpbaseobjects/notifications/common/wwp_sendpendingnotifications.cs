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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_sendpendingnotifications : GXProcedure
   {
      public wwp_sendpendingnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_sendpendingnotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         wwp_sendpendingnotifications objwwp_sendpendingnotifications;
         objwwp_sendpendingnotifications = new wwp_sendpendingnotifications();
         objwwp_sendpendingnotifications.context.SetSubmitInitialConfig(context);
         objwwp_sendpendingnotifications.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_sendpendingnotifications);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_sendpendingnotifications)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'SENDPENDINGMAILS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGSMS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGWEBNOTIFICATIONS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGMOBILENOTIFICATIONS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SENDPENDINGMAILS' Routine */
         returnInSub = false;
         GXt_SdtWWP_SMTPParametersSDT1 = AV8SMTPParametersSDT;
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_getsmtpparameters(context ).execute( out  GXt_SdtWWP_SMTPParametersSDT1) ;
         AV8SMTPParametersSDT = GXt_SdtWWP_SMTPParametersSDT1;
         AV9SmtpSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV9SmtpSession.Host = AV8SMTPParametersSDT.gxTpr_Host;
         AV9SmtpSession.Port = AV8SMTPParametersSDT.gxTpr_Port;
         AV9SmtpSession.UserName = AV8SMTPParametersSDT.gxTpr_Username;
         AV9SmtpSession.Password = AV8SMTPParametersSDT.gxTpr_Password;
         AV9SmtpSession.Authentication = AV8SMTPParametersSDT.gxTpr_Authentication;
         AV9SmtpSession.Secure = AV8SMTPParametersSDT.gxTpr_Secure;
         AV9SmtpSession.Timeout = AV8SMTPParametersSDT.gxTpr_Timeout;
         AV14StatusCode = AV9SmtpSession.Login();
         if ( AV14StatusCode != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV17Pgmname,  "Error during SMTP Login: "+AV9SmtpSession.ErrDescription) ;
         }
         else
         {
            /* Using cursor P002O2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A72WWPMailStatus = P002O2_A72WWPMailStatus[0];
               A20WWPMailId = P002O2_A20WWPMailId[0];
               GXt_int2 = AV14StatusCode;
               new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail(context ).execute(  A20WWPMailId,  AV9SmtpSession, out  GXt_int2) ;
               AV14StatusCode = GXt_int2;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV9SmtpSession.Logout();
         }
      }

      protected void S121( )
      {
         /* 'SENDPENDINGSMS' Routine */
         returnInSub = false;
         GXt_SdtWWP_SMSParametersSDT3 = AV10SMSParametersSDT;
         new GeneXus.Programs.wwpbaseobjects.sms.wwp_getsmsparameters(context ).execute( out  GXt_SdtWWP_SMSParametersSDT3) ;
         AV10SMSParametersSDT = GXt_SdtWWP_SMSParametersSDT3;
         /* Using cursor P002O3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29WWPSMSStatus = P002O3_A29WWPSMSStatus[0];
            A15WWPSMSId = P002O3_A15WWPSMSId[0];
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_sendsms(context ).execute(  A15WWPSMSId,  AV10SMSParametersSDT, out  AV12Success, out  AV13SendSMSResultSDT) ;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S131( )
      {
         /* 'SENDPENDINGWEBNOTIFICATIONS' Routine */
         returnInSub = false;
         /* Using cursor P002O4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A48WWPWebNotificationStatus = P002O4_A48WWPWebNotificationStatus[0];
            A17WWPWebNotificationId = P002O4_A17WWPWebNotificationId[0];
            GXt_int2 = AV11SendStatus;
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_sendwebnotification(context ).execute(  A17WWPWebNotificationId, out  GXt_int2) ;
            AV11SendStatus = GXt_int2;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S141( )
      {
         /* 'SENDPENDINGMOBILENOTIFICATIONS' Routine */
         returnInSub = false;
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
         AV8SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         GXt_SdtWWP_SMTPParametersSDT1 = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         AV9SmtpSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV17Pgmname = "";
         scmdbuf = "";
         P002O2_A72WWPMailStatus = new short[1] ;
         P002O2_A20WWPMailId = new long[1] ;
         AV10SMSParametersSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context);
         GXt_SdtWWP_SMSParametersSDT3 = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context);
         P002O3_A29WWPSMSStatus = new short[1] ;
         P002O3_A15WWPSMSId = new long[1] ;
         AV13SendSMSResultSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT(context);
         P002O4_A48WWPWebNotificationStatus = new short[1] ;
         P002O4_A17WWPWebNotificationId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendpendingnotifications__default(),
            new Object[][] {
                new Object[] {
               P002O2_A72WWPMailStatus, P002O2_A20WWPMailId
               }
               , new Object[] {
               P002O3_A29WWPSMSStatus, P002O3_A15WWPSMSId
               }
               , new Object[] {
               P002O4_A48WWPWebNotificationStatus, P002O4_A17WWPWebNotificationId
               }
            }
         );
         AV17Pgmname = "WWPBaseObjects.Notifications.Common.WWP_SendPendingNotifications";
         /* GeneXus formulas. */
         AV17Pgmname = "WWPBaseObjects.Notifications.Common.WWP_SendPendingNotifications";
         context.Gx_err = 0;
      }

      private short AV14StatusCode ;
      private short A72WWPMailStatus ;
      private short A29WWPSMSStatus ;
      private short A48WWPWebNotificationStatus ;
      private short AV11SendStatus ;
      private short GXt_int2 ;
      private long A20WWPMailId ;
      private long A15WWPSMSId ;
      private long A17WWPWebNotificationId ;
      private string AV17Pgmname ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV12Success ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002O2_A72WWPMailStatus ;
      private long[] P002O2_A20WWPMailId ;
      private short[] P002O3_A29WWPSMSStatus ;
      private long[] P002O3_A15WWPSMSId ;
      private short[] P002O4_A48WWPWebNotificationStatus ;
      private long[] P002O4_A17WWPWebNotificationId ;
      private GeneXus.Mail.GXSMTPSession AV9SmtpSession ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT AV8SMTPParametersSDT ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT GXt_SdtWWP_SMTPParametersSDT1 ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT AV10SMSParametersSDT ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT GXt_SdtWWP_SMSParametersSDT3 ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT AV13SendSMSResultSDT ;
   }

   public class wwp_sendpendingnotifications__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002O2;
          prmP002O2 = new Object[] {
          };
          Object[] prmP002O3;
          prmP002O3 = new Object[] {
          };
          Object[] prmP002O4;
          prmP002O4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P002O2", "SELECT [WWPMailStatus], [WWPMailId] FROM [WWP_Mail] WHERE [WWPMailStatus] = 1 ORDER BY [WWPMailId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002O3", "SELECT [WWPSMSStatus], [WWPSMSId] FROM [WWP_SMS] WHERE [WWPSMSStatus] = 1 ORDER BY [WWPSMSId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002O4", "SELECT [WWPWebNotificationStatus], [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationStatus] = 1 ORDER BY [WWPWebNotificationId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O4,100, GxCacheFrequency.OFF ,true,false )
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
                table[0][0] = rslt.getShort(1);
                table[1][0] = rslt.getLong(2);
                return;
             case 1 :
                table[0][0] = rslt.getShort(1);
                table[1][0] = rslt.getLong(2);
                return;
             case 2 :
                table[0][0] = rslt.getShort(1);
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
       }
    }

 }

}
