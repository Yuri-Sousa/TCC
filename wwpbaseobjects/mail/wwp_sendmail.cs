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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_sendmail : GXProcedure
   {
      public wwp_sendmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_sendmail( IGxContext context )
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
                           GeneXus.Mail.GXSMTPSession aP1_SMTPSession ,
                           out short aP2_SendStatus )
      {
         this.AV14MailId = aP0_MailId;
         this.AV18SMTPSession = aP1_SMTPSession;
         this.AV17SendStatus = 0 ;
         initialize();
         executePrivate();
         aP2_SendStatus=this.AV17SendStatus;
      }

      public short executeUdp( long aP0_MailId ,
                               GeneXus.Mail.GXSMTPSession aP1_SMTPSession )
      {
         execute(aP0_MailId, aP1_SMTPSession, out aP2_SendStatus);
         return AV17SendStatus ;
      }

      public void executeSubmit( long aP0_MailId ,
                                 GeneXus.Mail.GXSMTPSession aP1_SMTPSession ,
                                 out short aP2_SendStatus )
      {
         wwp_sendmail objwwp_sendmail;
         objwwp_sendmail = new wwp_sendmail();
         objwwp_sendmail.AV14MailId = aP0_MailId;
         objwwp_sendmail.AV18SMTPSession = aP1_SMTPSession;
         objwwp_sendmail.AV17SendStatus = 0 ;
         objwwp_sendmail.context.SetSubmitInitialConfig(context);
         objwwp_sendmail.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_sendmail);
         aP2_SendStatus=this.AV17SendStatus;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_sendmail)stateInfo).executePrivate();
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
         AV17SendStatus = -1;
         AV13Mail.Load(AV14MailId);
         if ( AV13Mail.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Mail not found with id: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            this.cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailsenderaddress)) || String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailsendername)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Sender address/name cannot be empty: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Sender address/name cannot be empty") ;
            this.cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailsubject)) || String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailbody)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Mail subject/body cannot be empty: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail subject/body cannot be empty") ;
            this.cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailto)) && String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailcc)) && String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailbcc)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Mail recipient cannot be empty: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail recipient cannot be empty") ;
            this.cleanup();
            if (true) return;
         }
         GXt_objcol_vchar1 = AV20ToAddressList;
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_parsemailaddresslist(context ).execute(  AV13Mail.gxTpr_Wwpmailto, out  GXt_objcol_vchar1) ;
         AV20ToAddressList = GXt_objcol_vchar1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailto)) && ( AV20ToAddressList.Count == 0 ) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Mail recipient is not valid address list: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail To is invalid") ;
            this.cleanup();
            if (true) return;
         }
         GXt_objcol_vchar1 = AV11CCAddressList;
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_parsemailaddresslist(context ).execute(  AV13Mail.gxTpr_Wwpmailcc, out  GXt_objcol_vchar1) ;
         AV11CCAddressList = GXt_objcol_vchar1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailcc)) && ( AV11CCAddressList.Count == 0 ) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Mail recipient is not valid address list: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail CC is invalid") ;
            this.cleanup();
            if (true) return;
         }
         GXt_objcol_vchar1 = AV10BCCAddressList;
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_parsemailaddresslist(context ).execute(  AV13Mail.gxTpr_Wwpmailbcc, out  GXt_objcol_vchar1) ;
         AV10BCCAddressList = GXt_objcol_vchar1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Mail.gxTpr_Wwpmailbcc)) && ( AV10BCCAddressList.Count == 0 ) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Mail recipient is not valid address list: "+StringUtil.Str( (decimal)(AV14MailId), 10, 0)) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Mail BCC is invalid") ;
            this.cleanup();
            if (true) return;
         }
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV13Mail.gxTpr_Attachments.Count )
         {
            AV9Attachment = ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)AV13Mail.gxTpr_Attachments.Item(AV24GXV1));
            AV12FileExists = (bool)(((context.FileExists( AV9Attachment.gxTpr_Wwpmailattachmentfile)==1)));
            if ( ! AV12FileExists )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  "Attachment is not a valid file: "+AV9Attachment.gxTpr_Wwpmailattachmentfile) ;
               new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  "Attachment invalid") ;
               this.cleanup();
               if (true) return;
            }
            AV24GXV1 = (int)(AV24GXV1+1);
         }
         AV15MailMessage = new GeneXus.Mail.GXMailMessage();
         AV15MailMessage.From.Address = AV13Mail.gxTpr_Wwpmailsenderaddress;
         AV15MailMessage.From.Name = AV13Mail.gxTpr_Wwpmailsendername;
         AV15MailMessage.Subject = AV13Mail.gxTpr_Wwpmailsubject;
         AV15MailMessage.HTMLText = AV13Mail.gxTpr_Wwpmailbody;
         AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV16MailRecipient.Address = AV13Mail.gxTpr_Wwpmailsenderaddress;
         AV16MailRecipient.Name = AV13Mail.gxTpr_Wwpmailsendername;
         AV18SMTPSession.Sender = AV16MailRecipient;
         AV25GXV2 = 1;
         while ( AV25GXV2 <= AV20ToAddressList.Count )
         {
            AV8Address = ((string)AV20ToAddressList.Item(AV25GXV2));
            AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
            AV16MailRecipient.Address = AV8Address;
            AV15MailMessage.To.Add(AV16MailRecipient);
            AV25GXV2 = (int)(AV25GXV2+1);
         }
         AV26GXV3 = 1;
         while ( AV26GXV3 <= AV11CCAddressList.Count )
         {
            AV8Address = ((string)AV11CCAddressList.Item(AV26GXV3));
            AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
            AV16MailRecipient.Address = AV8Address;
            AV15MailMessage.CC.Add(AV16MailRecipient);
            AV26GXV3 = (int)(AV26GXV3+1);
         }
         AV27GXV4 = 1;
         while ( AV27GXV4 <= AV10BCCAddressList.Count )
         {
            AV8Address = ((string)AV10BCCAddressList.Item(AV27GXV4));
            AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
            AV16MailRecipient.Address = AV8Address;
            AV15MailMessage.BCC.Add(AV16MailRecipient);
            AV27GXV4 = (int)(AV27GXV4+1);
         }
         AV28GXV5 = 1;
         while ( AV28GXV5 <= AV13Mail.gxTpr_Attachments.Count )
         {
            AV9Attachment = ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)AV13Mail.gxTpr_Attachments.Item(AV28GXV5));
            AV15MailMessage.Attachments.Add(AV9Attachment.gxTpr_Wwpmailattachmentfile);
            AV28GXV5 = (int)(AV28GXV5+1);
         }
         AV17SendStatus = AV18SMTPSession.Send(AV15MailMessage);
         GXt_char2 = AV19StatusMessage;
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_getstatuscodemessage(context ).execute(  AV17SendStatus, out  GXt_char2) ;
         AV19StatusMessage = GXt_char2;
         if ( AV17SendStatus != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV23Pgmname,  StringUtil.Format( "Error sending mail with id: %1 - Code: %2 - %3", StringUtil.Str( (decimal)(AV14MailId), 10, 0), StringUtil.Trim( StringUtil.Str( (decimal)(AV17SendStatus), 4, 0)), AV19StatusMessage, "", "", "", "", "", "")) ;
            new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  3,  StringUtil.Format( "Code: %1 - Message: %2", StringUtil.Trim( StringUtil.Str( (decimal)(AV17SendStatus), 4, 0)), AV19StatusMessage, "", "", "", "", "", "", "")) ;
            this.cleanup();
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_updatemailstatus(context ).execute(  AV14MailId,  2,  "OK") ;
         context.CommitDataStores("wwpbaseobjects.mail.wwp_sendmail",pr_default);
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
         AV13Mail = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         AV23Pgmname = "";
         AV20ToAddressList = new GxSimpleCollection<string>();
         AV11CCAddressList = new GxSimpleCollection<string>();
         AV10BCCAddressList = new GxSimpleCollection<string>();
         GXt_objcol_vchar1 = new GxSimpleCollection<string>();
         AV9Attachment = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments(context);
         AV15MailMessage = new GeneXus.Mail.GXMailMessage();
         AV16MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV8Address = "";
         AV19StatusMessage = "";
         GXt_char2 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail__default(),
            new Object[][] {
            }
         );
         AV23Pgmname = "WWPBaseObjects.Mail.WWP_SendMail";
         /* GeneXus formulas. */
         AV23Pgmname = "WWPBaseObjects.Mail.WWP_SendMail";
         context.Gx_err = 0;
      }

      private short AV17SendStatus ;
      private int AV24GXV1 ;
      private int AV25GXV2 ;
      private int AV26GXV3 ;
      private int AV27GXV4 ;
      private int AV28GXV5 ;
      private long AV14MailId ;
      private string AV23Pgmname ;
      private string GXt_char2 ;
      private bool AV12FileExists ;
      private string AV8Address ;
      private string AV19StatusMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short aP2_SendStatus ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Mail.GXMailMessage AV15MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV16MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV18SMTPSession ;
      private GxSimpleCollection<string> AV20ToAddressList ;
      private GxSimpleCollection<string> AV11CCAddressList ;
      private GxSimpleCollection<string> AV10BCCAddressList ;
      private GxSimpleCollection<string> GXt_objcol_vchar1 ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail AV13Mail ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments AV9Attachment ;
   }

   public class wwp_sendmail__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sendmail__default : DataStoreHelperBase, IDataStoreHelper
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
