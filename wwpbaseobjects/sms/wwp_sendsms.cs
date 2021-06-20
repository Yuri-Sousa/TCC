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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sendsms : GXProcedure
   {
      public wwp_sendsms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_sendsms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_SMSId ,
                           GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT aP1_SMSParametersSDT ,
                           out bool aP2_Success ,
                           out GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT aP3_SendSMSResultSDT )
      {
         this.AV14SMSId = aP0_SMSId;
         this.AV15SMSParametersSDT = aP1_SMSParametersSDT;
         this.AV16Success = false ;
         this.AV12SendSMSResultSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT(context) ;
         initialize();
         executePrivate();
         aP2_Success=this.AV16Success;
         aP3_SendSMSResultSDT=this.AV12SendSMSResultSDT;
      }

      public GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT executeUdp( long aP0_SMSId ,
                                                                                     GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT aP1_SMSParametersSDT ,
                                                                                     out bool aP2_Success )
      {
         execute(aP0_SMSId, aP1_SMSParametersSDT, out aP2_Success, out aP3_SendSMSResultSDT);
         return AV12SendSMSResultSDT ;
      }

      public void executeSubmit( long aP0_SMSId ,
                                 GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT aP1_SMSParametersSDT ,
                                 out bool aP2_Success ,
                                 out GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT aP3_SendSMSResultSDT )
      {
         wwp_sendsms objwwp_sendsms;
         objwwp_sendsms = new wwp_sendsms();
         objwwp_sendsms.AV14SMSId = aP0_SMSId;
         objwwp_sendsms.AV15SMSParametersSDT = aP1_SMSParametersSDT;
         objwwp_sendsms.AV16Success = false ;
         objwwp_sendsms.AV12SendSMSResultSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT(context) ;
         objwwp_sendsms.context.SetSubmitInitialConfig(context);
         objwwp_sendsms.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_sendsms);
         aP2_Success=this.AV16Success;
         aP3_SendSMSResultSDT=this.AV12SendSMSResultSDT;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_sendsms)stateInfo).executePrivate();
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
         AV16Success = false;
         AV13SMS.Load(AV14SMSId);
         if ( AV13SMS.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV19Pgmname,  "SMS not found with id: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV14SMSId), 10, 0))) ;
            this.cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13SMS.gxTpr_Wwpsmsmessage)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV19Pgmname,  "SMS message cannot be empty: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV14SMSId), 10, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_updatesmsstatus(context ).execute(  AV14SMSId,  3,  "SMS message cannot be empty") ;
            this.cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13SMS.gxTpr_Wwpsmssendernumber)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV19Pgmname,  "SMS sender cannot be empty: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV14SMSId), 10, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_updatesmsstatus(context ).execute(  AV14SMSId,  3,  "SMS sender cannot be empty") ;
            this.cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13SMS.gxTpr_Wwpsmsrecipientnumbers)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV19Pgmname,  "SMS recipient cannot be empty: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV14SMSId), 10, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_updatesmsstatus(context ).execute(  AV14SMSId,  3,  "SMS recipient cannot be empty") ;
            this.cleanup();
            if (true) return;
         }
         GXt_objcol_vchar1 = AV9RecipientPhoneList;
         new GeneXus.Programs.wwpbaseobjects.sms.wwp_parsephonenumberslist(context ).execute(  AV13SMS.gxTpr_Wwpsmsrecipientnumbers, out  GXt_objcol_vchar1) ;
         AV9RecipientPhoneList = GXt_objcol_vchar1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SMS.gxTpr_Wwpsmsrecipientnumbers)) && ( AV9RecipientPhoneList.Count == 0 ) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV19Pgmname,  "SMS recipient is not valid phone list: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV14SMSId), 10, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_updatesmsstatus(context ).execute(  AV14SMSId,  3,  "SMS recipient is not valid") ;
            this.cleanup();
            if (true) return;
         }
         AV10RequestBody = "{\"from\": \"%1\", \"to\": %2, \"body\": \"%3\" }";
         AV10RequestBody = StringUtil.Format( AV10RequestBody, StringUtil.Trim( AV13SMS.gxTpr_Wwpsmssendernumber), AV9RecipientPhoneList.ToJSonString(false), StringUtil.Trim( AV13SMS.gxTpr_Wwpsmsmessage), "", "", "", "", "", "");
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV19Pgmname,  "Calling Sinch API with body: "+AV10RequestBody) ;
         AV8HttpClient = new GxHttpClient( context);
         AV8HttpClient.Secure = 1;
         AV8HttpClient.Host = "sms.api.sinch.com";
         AV8HttpClient.BaseURL = StringUtil.Format( "xms/v1/%1/", AV15SMSParametersSDT.gxTpr_Serviceplanid, "", "", "", "", "", "", "", "");
         AV8HttpClient.AddHeader("Authorization", "Bearer "+StringUtil.Trim( AV15SMSParametersSDT.gxTpr_Token));
         AV8HttpClient.AddHeader("Content-Type", "application/json");
         AV8HttpClient.AddString(AV10RequestBody);
         AV8HttpClient.Execute("POST", "batches");
         AV11Response = AV8HttpClient.ToString();
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV19Pgmname,  "Sinch API response: "+AV11Response) ;
         AV12SendSMSResultSDT.FromJSonString(AV11Response, null);
         if ( AV8HttpClient.StatusCode != 201 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV19Pgmname,  StringUtil.Format( "Error sending sms with id: %1 - Code: %2 - %3", StringUtil.Trim( StringUtil.Str( (decimal)(AV14SMSId), 10, 0)), StringUtil.Trim( StringUtil.Str( (decimal)(AV8HttpClient.ErrCode), 10, 2)), AV8HttpClient.ErrDescription, "", "", "", "", "", "")) ;
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_updatesmsstatus(context ).execute(  AV14SMSId,  3,  StringUtil.Format( "Code: %1 - %2", StringUtil.Trim( StringUtil.Str( (decimal)(AV8HttpClient.ErrCode), 10, 2)), AV8HttpClient.ErrDescription, "", "", "", "", "", "", "")) ;
            this.cleanup();
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.sms.wwp_updatesmsstatus(context ).execute(  AV14SMSId,  2,  AV11Response) ;
         AV16Success = true;
         context.CommitDataStores("wwpbaseobjects.sms.wwp_sendsms",pr_default);
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
         AV12SendSMSResultSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT(context);
         AV13SMS = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         AV19Pgmname = "";
         AV9RecipientPhoneList = new GxSimpleCollection<string>();
         GXt_objcol_vchar1 = new GxSimpleCollection<string>();
         AV10RequestBody = "";
         AV8HttpClient = new GxHttpClient( context);
         AV11Response = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sendsms__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sendsms__default(),
            new Object[][] {
            }
         );
         AV19Pgmname = "WWPBaseObjects.SMS.WWP_SendSMS";
         /* GeneXus formulas. */
         AV19Pgmname = "WWPBaseObjects.SMS.WWP_SendSMS";
         context.Gx_err = 0;
      }

      private long AV14SMSId ;
      private string AV19Pgmname ;
      private bool AV16Success ;
      private string AV10RequestBody ;
      private string AV11Response ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP2_Success ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT aP3_SendSMSResultSDT ;
      private IDataStoreProvider pr_gam ;
      private GxHttpClient AV8HttpClient ;
      private GxSimpleCollection<string> AV9RecipientPhoneList ;
      private GxSimpleCollection<string> GXt_objcol_vchar1 ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT AV12SendSMSResultSDT ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS AV13SMS ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT AV15SMSParametersSDT ;
   }

   public class wwp_sendsms__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sendsms__default : DataStoreHelperBase, IDataStoreHelper
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
