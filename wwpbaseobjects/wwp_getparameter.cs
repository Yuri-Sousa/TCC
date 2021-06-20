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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getparameter : GXProcedure
   {
      public wwp_getparameter( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_getparameter( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
         wwp_getparameter objwwp_getparameter;
         objwwp_getparameter = new wwp_getparameter();
         objwwp_getparameter.context.SetSubmitInitialConfig(context);
         objwwp_getparameter.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_getparameter);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getparameter)stateInfo).executePrivate();
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
         this.cleanup();
      }

      public void gxep_text( string aP0_ParameterName ,
                             ref string aP1_TextParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV15TextParameter = aP1_TextParameter;
         initialize();
         initialized = 1;
         /* Text Constructor */
         if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Host") == 0 )
         {
            AV15TextParameter = "smtp.gmail.com";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Username") == 0 )
         {
            AV15TextParameter = "samplemail@gmail.com";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Password") == 0 )
         {
            AV15TextParameter = "samplemail_password";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_ServicePlanId") == 0 )
         {
            AV15TextParameter = "dddddddddddddddddddddddddddddddd";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_Token") == 0 )
         {
            AV15TextParameter = "dddddddddddddddddddddddddddddddd";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_ApplicationKey") == 0 )
         {
            AV15TextParameter = "dddddddd-dddd-dddd-dddd-dddddddddddd";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_ApplicationSecret") == 0 )
         {
            AV15TextParameter = "dddddddddddddddddddddd==";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMS_DefaultSender") == 0 )
         {
            AV15TextParameter = "+111111111111";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "Sender_Name") == 0 )
         {
            AV15TextParameter = "smtp.gmail.com";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "Sender_Address") == 0 )
         {
            AV15TextParameter = "samplemail@gmail.com";
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "Notification_BaseURL") == 0 )
         {
            AV15TextParameter = AV12HTTPRequest.BaseURL;
         }
         executePrivate();
         aP1_TextParameter=this.AV15TextParameter;
         this.cleanup();
      }

      public void gxep_integer( string aP0_ParameterName ,
                                ref long aP1_IntegerParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV13IntegerParameter = aP1_IntegerParameter;
         initialize();
         initialized = 1;
         /* Integer Constructor */
         if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Port") == 0 )
         {
            AV13IntegerParameter = 587;
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Timeout") == 0 )
         {
            AV13IntegerParameter = 30;
         }
         executePrivate();
         aP1_IntegerParameter=this.AV13IntegerParameter;
         this.cleanup();
      }

      public void gxep_decimal( string aP0_ParameterName ,
                                ref decimal aP1_DecimalParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV11DecimalParameter = aP1_DecimalParameter;
         initialize();
         initialized = 1;
         /* Decimal Constructor */
         executePrivate();
         aP1_DecimalParameter=this.AV11DecimalParameter;
         this.cleanup();
      }

      public void gxep_boolean( string aP0_ParameterName ,
                                ref bool aP1_BooleanParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV8BooleanParameter = aP1_BooleanParameter;
         initialize();
         initialized = 1;
         /* Boolean Constructor */
         if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Authentication") == 0 )
         {
            AV8BooleanParameter = true;
         }
         else if ( StringUtil.StrCmp(AV14ParameterName, "SMTP_Secure") == 0 )
         {
            /* User Code */
             AV8BooleanParameter = true;
         }
         executePrivate();
         aP1_BooleanParameter=this.AV8BooleanParameter;
         this.cleanup();
      }

      public void gxep_date( string aP0_ParameterName ,
                             ref DateTime aP1_DateParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV9DateParameter = aP1_DateParameter;
         initialize();
         initialized = 1;
         /* Date Constructor */
         executePrivate();
         aP1_DateParameter=this.AV9DateParameter;
         this.cleanup();
      }

      public void gxep_datetime( string aP0_ParameterName ,
                                 ref DateTime aP1_DateTimeParameter )
      {
         this.AV14ParameterName = aP0_ParameterName;
         this.AV10DateTimeParameter = aP1_DateTimeParameter;
         initialize();
         initialized = 1;
         /* DateTime Constructor */
         executePrivate();
         aP1_DateTimeParameter=this.AV10DateTimeParameter;
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
         AV12HTTPRequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short initialized ;
      private long AV13IntegerParameter ;
      private decimal AV11DecimalParameter ;
      private DateTime AV10DateTimeParameter ;
      private DateTime AV9DateParameter ;
      private bool AV8BooleanParameter ;
      private string AV15TextParameter ;
      private string AV14ParameterName ;
      private string aP1_TextParameter ;
      private long aP1_IntegerParameter ;
      private decimal aP1_DecimalParameter ;
      private bool aP1_BooleanParameter ;
      private DateTime aP1_DateParameter ;
      private DateTime aP1_DateTimeParameter ;
      private GxHttpRequest AV12HTTPRequest ;
   }

}
