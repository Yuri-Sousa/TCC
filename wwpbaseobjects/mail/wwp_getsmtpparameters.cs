using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class wwp_getsmtpparameters : GXProcedure
   {
      public wwp_getsmtpparameters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getsmtpparameters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT aP0_SMTPParametersSDT )
      {
         this.AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context) ;
         initialize();
         executePrivate();
         aP0_SMTPParametersSDT=this.AV10SMTPParametersSDT;
      }

      public GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT executeUdp( )
      {
         execute(out aP0_SMTPParametersSDT);
         return AV10SMTPParametersSDT ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT aP0_SMTPParametersSDT )
      {
         wwp_getsmtpparameters objwwp_getsmtpparameters;
         objwwp_getsmtpparameters = new wwp_getsmtpparameters();
         objwwp_getsmtpparameters.AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context) ;
         objwwp_getsmtpparameters.context.SetSubmitInitialConfig(context);
         objwwp_getsmtpparameters.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getsmtpparameters);
         aP0_SMTPParametersSDT=this.AV10SMTPParametersSDT;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getsmtpparameters)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV14Pgmname,  "Getting SMTP Parameters") ;
         AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMTP_Host", ref  AV11TextParameter) ;
         AV10SMTPParametersSDT.gxTpr_Host = AV11TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_integer(  "SMTP_Port", ref  AV9IntegerParameter) ;
         AV10SMTPParametersSDT.gxTpr_Port = (short)(AV9IntegerParameter);
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMTP_Username", ref  AV11TextParameter) ;
         AV10SMTPParametersSDT.gxTpr_Username = AV11TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMTP_Password", ref  AV11TextParameter) ;
         AV10SMTPParametersSDT.gxTpr_Password = AV11TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_boolean(  "SMTP_Authentication", ref  AV8BooleanParameter) ;
         if ( AV8BooleanParameter )
         {
            AV10SMTPParametersSDT.gxTpr_Authentication = 1;
         }
         else
         {
            AV10SMTPParametersSDT.gxTpr_Authentication = 0;
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_boolean(  "SMTP_Secure", ref  AV8BooleanParameter) ;
         if ( AV8BooleanParameter )
         {
            AV10SMTPParametersSDT.gxTpr_Secure = 1;
         }
         else
         {
            AV10SMTPParametersSDT.gxTpr_Secure = 0;
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_integer(  "SMTP_Timeout", ref  AV9IntegerParameter) ;
         AV10SMTPParametersSDT.gxTpr_Timeout = (short)(AV9IntegerParameter);
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV14Pgmname,  "SMTP Parameters: "+AV10SMTPParametersSDT.ToJSonString(false, true)) ;
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
         AV10SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         AV14Pgmname = "";
         AV11TextParameter = "";
         AV14Pgmname = "WWPBaseObjects.Mail.WWP_GetSMTPParameters";
         /* GeneXus formulas. */
         AV14Pgmname = "WWPBaseObjects.Mail.WWP_GetSMTPParameters";
         context.Gx_err = 0;
      }

      private long AV9IntegerParameter ;
      private string AV14Pgmname ;
      private bool AV8BooleanParameter ;
      private string AV11TextParameter ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT aP0_SMTPParametersSDT ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT AV10SMTPParametersSDT ;
   }

}
