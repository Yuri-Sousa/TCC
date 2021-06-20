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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_getsmsparameters : GXProcedure
   {
      public wwp_getsmsparameters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getsmsparameters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT aP0_SMSParametersSDT )
      {
         this.AV8SMSParametersSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context) ;
         initialize();
         executePrivate();
         aP0_SMSParametersSDT=this.AV8SMSParametersSDT;
      }

      public GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT executeUdp( )
      {
         execute(out aP0_SMSParametersSDT);
         return AV8SMSParametersSDT ;
      }

      public void executeSubmit( out GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT aP0_SMSParametersSDT )
      {
         wwp_getsmsparameters objwwp_getsmsparameters;
         objwwp_getsmsparameters = new wwp_getsmsparameters();
         objwwp_getsmsparameters.AV8SMSParametersSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context) ;
         objwwp_getsmsparameters.context.SetSubmitInitialConfig(context);
         objwwp_getsmsparameters.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getsmsparameters);
         aP0_SMSParametersSDT=this.AV8SMSParametersSDT;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getsmsparameters)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV12Pgmname,  "Getting SMS Parameters") ;
         AV8SMSParametersSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMS_ServicePlanId", ref  AV9TextParameter) ;
         AV8SMSParametersSDT.gxTpr_Serviceplanid = AV9TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMS_Token", ref  AV9TextParameter) ;
         AV8SMSParametersSDT.gxTpr_Token = AV9TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMS_ApplicationKey", ref  AV9TextParameter) ;
         AV8SMSParametersSDT.gxTpr_Applicationkey = AV9TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMS_ApplicationSecret", ref  AV9TextParameter) ;
         AV8SMSParametersSDT.gxTpr_Applicationsecret = AV9TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMS_DefaultSender", ref  AV9TextParameter) ;
         AV8SMSParametersSDT.gxTpr_Defaultsender = AV9TextParameter;
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV12Pgmname,  "SMS Parameters: "+AV8SMSParametersSDT.ToJSonString(false, true)) ;
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
         AV8SMSParametersSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context);
         AV12Pgmname = "";
         AV9TextParameter = "";
         AV12Pgmname = "WWPBaseObjects.SMS.WWP_GetSMSParameters";
         /* GeneXus formulas. */
         AV12Pgmname = "WWPBaseObjects.SMS.WWP_GetSMSParameters";
         context.Gx_err = 0;
      }

      private string AV12Pgmname ;
      private string AV9TextParameter ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT aP0_SMSParametersSDT ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT AV8SMSParametersSDT ;
   }

}
