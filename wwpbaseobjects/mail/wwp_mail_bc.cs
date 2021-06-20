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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_mail_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_mail_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0A10( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A10( ) ;
         standaloneModal( ) ;
         AddRow0A10( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z20WWPMailId = A20WWPMailId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A10( ) ;
            }
            else
            {
               CheckExtendedTable0A10( ) ;
               if ( AnyError == 0 )
               {
                  ZM0A10( 9) ;
               }
               CloseExtendedTableCursors0A10( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode10 = Gx_mode;
            CONFIRM_0A11( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode10;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode10;
         }
      }

      protected void CONFIRM_0A11( )
      {
         nGXsfl_11_idx = 0;
         while ( nGXsfl_11_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0A11( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound11 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_11 != 0 ) )
            {
               GetKey0A11( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0A11( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0A11( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0A11( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0A11( ) ;
                        Load0A11( ) ;
                        BeforeValidate0A11( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0A11( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0A11( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0A11( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0A11( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow11( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_11_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z61WWPMailSubject = A61WWPMailSubject;
            Z72WWPMailStatus = A72WWPMailStatus;
            Z81WWPMailCreated = A81WWPMailCreated;
            Z82WWPMailScheduled = A82WWPMailScheduled;
            Z77WWPMailProcessed = A77WWPMailProcessed;
            Z16WWPNotificationId = A16WWPNotificationId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
         }
         if ( GX_JID == -8 )
         {
            Z20WWPMailId = A20WWPMailId;
            Z61WWPMailSubject = A61WWPMailSubject;
            Z55WWPMailBody = A55WWPMailBody;
            Z62WWPMailTo = A62WWPMailTo;
            Z74WWPMailCC = A74WWPMailCC;
            Z75WWPMailBCC = A75WWPMailBCC;
            Z63WWPMailSenderAddress = A63WWPMailSenderAddress;
            Z64WWPMailSenderName = A64WWPMailSenderName;
            Z72WWPMailStatus = A72WWPMailStatus;
            Z81WWPMailCreated = A81WWPMailCreated;
            Z82WWPMailScheduled = A82WWPMailScheduled;
            Z77WWPMailProcessed = A77WWPMailProcessed;
            Z78WWPMailDetail = A78WWPMailDetail;
            Z16WWPNotificationId = A16WWPNotificationId;
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A72WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A72WWPMailStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A81WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A82WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0A10( )
      {
         /* Using cursor BC000A7 */
         pr_default.execute(5, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound10 = 1;
            A61WWPMailSubject = BC000A7_A61WWPMailSubject[0];
            A55WWPMailBody = BC000A7_A55WWPMailBody[0];
            A62WWPMailTo = BC000A7_A62WWPMailTo[0];
            n62WWPMailTo = BC000A7_n62WWPMailTo[0];
            A74WWPMailCC = BC000A7_A74WWPMailCC[0];
            n74WWPMailCC = BC000A7_n74WWPMailCC[0];
            A75WWPMailBCC = BC000A7_A75WWPMailBCC[0];
            n75WWPMailBCC = BC000A7_n75WWPMailBCC[0];
            A63WWPMailSenderAddress = BC000A7_A63WWPMailSenderAddress[0];
            A64WWPMailSenderName = BC000A7_A64WWPMailSenderName[0];
            A72WWPMailStatus = BC000A7_A72WWPMailStatus[0];
            A81WWPMailCreated = BC000A7_A81WWPMailCreated[0];
            A82WWPMailScheduled = BC000A7_A82WWPMailScheduled[0];
            A77WWPMailProcessed = BC000A7_A77WWPMailProcessed[0];
            n77WWPMailProcessed = BC000A7_n77WWPMailProcessed[0];
            A78WWPMailDetail = BC000A7_A78WWPMailDetail[0];
            n78WWPMailDetail = BC000A7_n78WWPMailDetail[0];
            A37WWPNotificationCreated = BC000A7_A37WWPNotificationCreated[0];
            A16WWPNotificationId = BC000A7_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000A7_n16WWPNotificationId[0];
            ZM0A10( -8) ;
         }
         pr_default.close(5);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A72WWPMailStatus == 1 ) || ( A72WWPMailStatus == 2 ) || ( A72WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Mail Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A81WWPMailCreated) || ( A81WWPMailCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Mail Created fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A82WWPMailScheduled) || ( A82WWPMailScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Mail Scheduled fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A77WWPMailProcessed) || ( A77WWPMailProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Mail Processed fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000A6 */
         pr_default.execute(4, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A37WWPNotificationCreated = BC000A6_A37WWPNotificationCreated[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0A10( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A10( )
      {
         /* Using cursor BC000A8 */
         pr_default.execute(6, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A20WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0A10( 8) ;
            RcdFound10 = 1;
            A20WWPMailId = BC000A5_A20WWPMailId[0];
            A61WWPMailSubject = BC000A5_A61WWPMailSubject[0];
            A55WWPMailBody = BC000A5_A55WWPMailBody[0];
            A62WWPMailTo = BC000A5_A62WWPMailTo[0];
            n62WWPMailTo = BC000A5_n62WWPMailTo[0];
            A74WWPMailCC = BC000A5_A74WWPMailCC[0];
            n74WWPMailCC = BC000A5_n74WWPMailCC[0];
            A75WWPMailBCC = BC000A5_A75WWPMailBCC[0];
            n75WWPMailBCC = BC000A5_n75WWPMailBCC[0];
            A63WWPMailSenderAddress = BC000A5_A63WWPMailSenderAddress[0];
            A64WWPMailSenderName = BC000A5_A64WWPMailSenderName[0];
            A72WWPMailStatus = BC000A5_A72WWPMailStatus[0];
            A81WWPMailCreated = BC000A5_A81WWPMailCreated[0];
            A82WWPMailScheduled = BC000A5_A82WWPMailScheduled[0];
            A77WWPMailProcessed = BC000A5_A77WWPMailProcessed[0];
            n77WWPMailProcessed = BC000A5_n77WWPMailProcessed[0];
            A78WWPMailDetail = BC000A5_A78WWPMailDetail[0];
            n78WWPMailDetail = BC000A5_n78WWPMailDetail[0];
            A16WWPNotificationId = BC000A5_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000A5_n16WWPNotificationId[0];
            Z20WWPMailId = A20WWPMailId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0A0( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A4 */
            pr_default.execute(2, new Object[] {A20WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z61WWPMailSubject, BC000A4_A61WWPMailSubject[0]) != 0 ) || ( Z72WWPMailStatus != BC000A4_A72WWPMailStatus[0] ) || ( Z81WWPMailCreated != BC000A4_A81WWPMailCreated[0] ) || ( Z82WWPMailScheduled != BC000A4_A82WWPMailScheduled[0] ) || ( Z77WWPMailProcessed != BC000A4_A77WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z16WWPNotificationId != BC000A4_A16WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A9 */
                     pr_default.execute(7, new Object[] {A61WWPMailSubject, A55WWPMailBody, n62WWPMailTo, A62WWPMailTo, n74WWPMailCC, A74WWPMailCC, n75WWPMailBCC, A75WWPMailBCC, A63WWPMailSenderAddress, A64WWPMailSenderName, A72WWPMailStatus, A81WWPMailCreated, A82WWPMailScheduled, n77WWPMailProcessed, A77WWPMailProcessed, n78WWPMailDetail, A78WWPMailDetail, n16WWPNotificationId, A16WWPNotificationId});
                     A20WWPMailId = BC000A9_A20WWPMailId[0];
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A10( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A10 */
                     pr_default.execute(8, new Object[] {A61WWPMailSubject, A55WWPMailBody, n62WWPMailTo, A62WWPMailTo, n74WWPMailCC, A74WWPMailCC, n75WWPMailBCC, A75WWPMailBCC, A63WWPMailSenderAddress, A64WWPMailSenderName, A72WWPMailStatus, A81WWPMailCreated, A82WWPMailScheduled, n77WWPMailProcessed, A77WWPMailProcessed, n78WWPMailDetail, A78WWPMailDetail, n16WWPNotificationId, A16WWPNotificationId, A20WWPMailId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A10( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0A11( ) ;
                  while ( RcdFound11 != 0 )
                  {
                     getByPrimaryKey0A11( ) ;
                     Delete0A11( ) ;
                     ScanKeyNext0A11( ) ;
                  }
                  ScanKeyEnd0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A11 */
                     pr_default.execute(9, new Object[] {A20WWPMailId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000A12 */
            pr_default.execute(10, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            A37WWPNotificationCreated = BC000A12_A37WWPNotificationCreated[0];
            pr_default.close(10);
         }
      }

      protected void ProcessNestedLevel0A11( )
      {
         nGXsfl_11_idx = 0;
         while ( nGXsfl_11_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0A11( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound11 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_11 != 0 ) )
            {
               standaloneNotModal0A11( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0A11( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0A11( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0A11( ) ;
                  }
               }
            }
            KeyVarsToRow11( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_11_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_11_idx = 0;
            while ( nGXsfl_11_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
            {
               ReadRow0A11( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.RemoveElement(nGXsfl_11_idx);
                  nGXsfl_11_idx = (int)(nGXsfl_11_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0A11( ) ;
                  VarsToRow11( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_11_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0A11( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         Gxremove11 = 0;
      }

      protected void ProcessLevel0A10( )
      {
         /* Save parent mode. */
         sMode10 = Gx_mode;
         ProcessNestedLevel0A11( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode10;
         /* ' Update level parameters */
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0A10( )
      {
         /* Using cursor BC000A13 */
         pr_default.execute(11, new Object[] {A20WWPMailId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound10 = 1;
            A20WWPMailId = BC000A13_A20WWPMailId[0];
            A61WWPMailSubject = BC000A13_A61WWPMailSubject[0];
            A55WWPMailBody = BC000A13_A55WWPMailBody[0];
            A62WWPMailTo = BC000A13_A62WWPMailTo[0];
            n62WWPMailTo = BC000A13_n62WWPMailTo[0];
            A74WWPMailCC = BC000A13_A74WWPMailCC[0];
            n74WWPMailCC = BC000A13_n74WWPMailCC[0];
            A75WWPMailBCC = BC000A13_A75WWPMailBCC[0];
            n75WWPMailBCC = BC000A13_n75WWPMailBCC[0];
            A63WWPMailSenderAddress = BC000A13_A63WWPMailSenderAddress[0];
            A64WWPMailSenderName = BC000A13_A64WWPMailSenderName[0];
            A72WWPMailStatus = BC000A13_A72WWPMailStatus[0];
            A81WWPMailCreated = BC000A13_A81WWPMailCreated[0];
            A82WWPMailScheduled = BC000A13_A82WWPMailScheduled[0];
            A77WWPMailProcessed = BC000A13_A77WWPMailProcessed[0];
            n77WWPMailProcessed = BC000A13_n77WWPMailProcessed[0];
            A78WWPMailDetail = BC000A13_A78WWPMailDetail[0];
            n78WWPMailDetail = BC000A13_n78WWPMailDetail[0];
            A37WWPNotificationCreated = BC000A13_A37WWPNotificationCreated[0];
            A16WWPNotificationId = BC000A13_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000A13_n16WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound10 = 0;
         ScanKeyLoad0A10( ) ;
      }

      protected void ScanKeyLoad0A10( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound10 = 1;
            A20WWPMailId = BC000A13_A20WWPMailId[0];
            A61WWPMailSubject = BC000A13_A61WWPMailSubject[0];
            A55WWPMailBody = BC000A13_A55WWPMailBody[0];
            A62WWPMailTo = BC000A13_A62WWPMailTo[0];
            n62WWPMailTo = BC000A13_n62WWPMailTo[0];
            A74WWPMailCC = BC000A13_A74WWPMailCC[0];
            n74WWPMailCC = BC000A13_n74WWPMailCC[0];
            A75WWPMailBCC = BC000A13_A75WWPMailBCC[0];
            n75WWPMailBCC = BC000A13_n75WWPMailBCC[0];
            A63WWPMailSenderAddress = BC000A13_A63WWPMailSenderAddress[0];
            A64WWPMailSenderName = BC000A13_A64WWPMailSenderName[0];
            A72WWPMailStatus = BC000A13_A72WWPMailStatus[0];
            A81WWPMailCreated = BC000A13_A81WWPMailCreated[0];
            A82WWPMailScheduled = BC000A13_A82WWPMailScheduled[0];
            A77WWPMailProcessed = BC000A13_A77WWPMailProcessed[0];
            n77WWPMailProcessed = BC000A13_n77WWPMailProcessed[0];
            A78WWPMailDetail = BC000A13_A78WWPMailDetail[0];
            n78WWPMailDetail = BC000A13_n78WWPMailDetail[0];
            A37WWPNotificationCreated = BC000A13_A37WWPNotificationCreated[0];
            A16WWPNotificationId = BC000A13_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000A13_n16WWPNotificationId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0A10( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
      }

      protected void ZM0A11( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -10 )
         {
            Z20WWPMailId = A20WWPMailId;
            Z21WWPMailAttachmentName = A21WWPMailAttachmentName;
            Z76WWPMailAttachmentFile = A76WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0A11( )
      {
      }

      protected void standaloneModal0A11( )
      {
      }

      protected void Load0A11( )
      {
         /* Using cursor BC000A14 */
         pr_default.execute(12, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound11 = 1;
            A76WWPMailAttachmentFile = BC000A14_A76WWPMailAttachmentFile[0];
            ZM0A11( -10) ;
         }
         pr_default.close(12);
         OnLoadActions0A11( ) ;
      }

      protected void OnLoadActions0A11( )
      {
      }

      protected void CheckExtendedTable0A11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal0A11( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0A11( )
      {
      }

      protected void enableDisable0A11( )
      {
      }

      protected void GetKey0A11( )
      {
         /* Using cursor BC000A15 */
         pr_default.execute(13, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey0A11( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A11( 10) ;
            RcdFound11 = 1;
            InitializeNonKey0A11( ) ;
            A21WWPMailAttachmentName = BC000A3_A21WWPMailAttachmentName[0];
            A76WWPMailAttachmentFile = BC000A3_A76WWPMailAttachmentFile[0];
            Z20WWPMailId = A20WWPMailId;
            Z21WWPMailAttachmentName = A21WWPMailAttachmentName;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0A11( ) ;
            Load0A11( ) ;
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0A11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0A11( ) ;
            Gx_mode = sMode11;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0A11( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0A11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A11( 0) ;
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A16 */
                     pr_default.execute(14, new Object[] {A20WWPMailId, A21WWPMailAttachmentName, A76WWPMailAttachmentFile});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(14) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0A11( ) ;
            }
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void Update0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A17 */
                     pr_default.execute(15, new Object[] {A76WWPMailAttachmentFile, A20WWPMailId, A21WWPMailAttachmentName});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A11( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0A11( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void DeferredUpdate0A11( )
      {
      }

      protected void Delete0A11( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A11( ) ;
            AfterConfirm0A11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A18 */
                  pr_default.execute(16, new Object[] {A20WWPMailId, A21WWPMailAttachmentName});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A11( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0A11( )
      {
         standaloneModal0A11( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0A11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0A11( )
      {
         /* Scan By routine */
         /* Using cursor BC000A19 */
         pr_default.execute(17, new Object[] {A20WWPMailId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound11 = 1;
            A21WWPMailAttachmentName = BC000A19_A21WWPMailAttachmentName[0];
            A76WWPMailAttachmentFile = BC000A19_A76WWPMailAttachmentFile[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A11( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound11 = 0;
         ScanKeyLoad0A11( ) ;
      }

      protected void ScanKeyLoad0A11( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound11 = 1;
            A21WWPMailAttachmentName = BC000A19_A21WWPMailAttachmentName[0];
            A76WWPMailAttachmentFile = BC000A19_A76WWPMailAttachmentFile[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0A11( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0A11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A11( )
      {
      }

      protected void send_integrity_lvl_hashes0A11( )
      {
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void AddRow0A10( )
      {
         VarsToRow10( bcwwpbaseobjects_mail_WWP_Mail) ;
      }

      protected void ReadRow0A10( )
      {
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
      }

      protected void AddRow0A11( )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj11;
         obj11 = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments(context);
         VarsToRow11( obj11) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Add(obj11, 0);
         obj11.gxTpr_Mode = "UPD";
         obj11.gxTpr_Modified = 0;
      }

      protected void ReadRow0A11( )
      {
         nGXsfl_11_idx = (int)(nGXsfl_11_idx+1);
         RowToVars11( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_11_idx)), 1) ;
      }

      protected void InitializeNonKey0A10( )
      {
         A61WWPMailSubject = "";
         A55WWPMailBody = "";
         A62WWPMailTo = "";
         n62WWPMailTo = false;
         A74WWPMailCC = "";
         n74WWPMailCC = false;
         A75WWPMailBCC = "";
         n75WWPMailBCC = false;
         A63WWPMailSenderAddress = "";
         A64WWPMailSenderName = "";
         A77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n77WWPMailProcessed = false;
         A78WWPMailDetail = "";
         n78WWPMailDetail = false;
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A72WWPMailStatus = 1;
         A81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z61WWPMailSubject = "";
         Z72WWPMailStatus = 0;
         Z81WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z16WWPNotificationId = 0;
      }

      protected void InitAll0A10( )
      {
         A20WWPMailId = 0;
         InitializeNonKey0A10( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A72WWPMailStatus = i72WWPMailStatus;
         A81WWPMailCreated = i81WWPMailCreated;
         A82WWPMailScheduled = i82WWPMailScheduled;
      }

      protected void InitializeNonKey0A11( )
      {
         A76WWPMailAttachmentFile = "";
      }

      protected void InitAll0A11( )
      {
         A21WWPMailAttachmentName = "";
         InitializeNonKey0A11( ) ;
      }

      protected void StandaloneModalInsert0A11( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow10( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Wwpmailsubject = A61WWPMailSubject;
         obj10.gxTpr_Wwpmailbody = A55WWPMailBody;
         obj10.gxTpr_Wwpmailto = A62WWPMailTo;
         obj10.gxTpr_Wwpmailcc = A74WWPMailCC;
         obj10.gxTpr_Wwpmailbcc = A75WWPMailBCC;
         obj10.gxTpr_Wwpmailsenderaddress = A63WWPMailSenderAddress;
         obj10.gxTpr_Wwpmailsendername = A64WWPMailSenderName;
         obj10.gxTpr_Wwpmailprocessed = A77WWPMailProcessed;
         obj10.gxTpr_Wwpmaildetail = A78WWPMailDetail;
         obj10.gxTpr_Wwpnotificationid = A16WWPNotificationId;
         obj10.gxTpr_Wwpnotificationcreated = A37WWPNotificationCreated;
         obj10.gxTpr_Wwpmailstatus = A72WWPMailStatus;
         obj10.gxTpr_Wwpmailcreated = A81WWPMailCreated;
         obj10.gxTpr_Wwpmailscheduled = A82WWPMailScheduled;
         obj10.gxTpr_Wwpmailid = A20WWPMailId;
         obj10.gxTpr_Wwpmailid_Z = Z20WWPMailId;
         obj10.gxTpr_Wwpmailsubject_Z = Z61WWPMailSubject;
         obj10.gxTpr_Wwpmailstatus_Z = Z72WWPMailStatus;
         obj10.gxTpr_Wwpmailcreated_Z = Z81WWPMailCreated;
         obj10.gxTpr_Wwpmailscheduled_Z = Z82WWPMailScheduled;
         obj10.gxTpr_Wwpmailprocessed_Z = Z77WWPMailProcessed;
         obj10.gxTpr_Wwpnotificationid_Z = Z16WWPNotificationId;
         obj10.gxTpr_Wwpnotificationcreated_Z = Z37WWPNotificationCreated;
         obj10.gxTpr_Wwpmailto_N = (short)(Convert.ToInt16(n62WWPMailTo));
         obj10.gxTpr_Wwpmailcc_N = (short)(Convert.ToInt16(n74WWPMailCC));
         obj10.gxTpr_Wwpmailbcc_N = (short)(Convert.ToInt16(n75WWPMailBCC));
         obj10.gxTpr_Wwpmailprocessed_N = (short)(Convert.ToInt16(n77WWPMailProcessed));
         obj10.gxTpr_Wwpmaildetail_N = (short)(Convert.ToInt16(n78WWPMailDetail));
         obj10.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n16WWPNotificationId));
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj10 )
      {
         obj10.gxTpr_Wwpmailid = A20WWPMailId;
         return  ;
      }

      public void RowToVars10( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A61WWPMailSubject = obj10.gxTpr_Wwpmailsubject;
         A55WWPMailBody = obj10.gxTpr_Wwpmailbody;
         A62WWPMailTo = obj10.gxTpr_Wwpmailto;
         n62WWPMailTo = false;
         A74WWPMailCC = obj10.gxTpr_Wwpmailcc;
         n74WWPMailCC = false;
         A75WWPMailBCC = obj10.gxTpr_Wwpmailbcc;
         n75WWPMailBCC = false;
         A63WWPMailSenderAddress = obj10.gxTpr_Wwpmailsenderaddress;
         A64WWPMailSenderName = obj10.gxTpr_Wwpmailsendername;
         A77WWPMailProcessed = obj10.gxTpr_Wwpmailprocessed;
         n77WWPMailProcessed = false;
         A78WWPMailDetail = obj10.gxTpr_Wwpmaildetail;
         n78WWPMailDetail = false;
         A16WWPNotificationId = obj10.gxTpr_Wwpnotificationid;
         n16WWPNotificationId = false;
         A37WWPNotificationCreated = obj10.gxTpr_Wwpnotificationcreated;
         A72WWPMailStatus = obj10.gxTpr_Wwpmailstatus;
         A81WWPMailCreated = obj10.gxTpr_Wwpmailcreated;
         A82WWPMailScheduled = obj10.gxTpr_Wwpmailscheduled;
         A20WWPMailId = obj10.gxTpr_Wwpmailid;
         Z20WWPMailId = obj10.gxTpr_Wwpmailid_Z;
         Z61WWPMailSubject = obj10.gxTpr_Wwpmailsubject_Z;
         Z72WWPMailStatus = obj10.gxTpr_Wwpmailstatus_Z;
         Z81WWPMailCreated = obj10.gxTpr_Wwpmailcreated_Z;
         Z82WWPMailScheduled = obj10.gxTpr_Wwpmailscheduled_Z;
         Z77WWPMailProcessed = obj10.gxTpr_Wwpmailprocessed_Z;
         Z16WWPNotificationId = obj10.gxTpr_Wwpnotificationid_Z;
         Z37WWPNotificationCreated = obj10.gxTpr_Wwpnotificationcreated_Z;
         n62WWPMailTo = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpmailto_N));
         n74WWPMailCC = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpmailcc_N));
         n75WWPMailBCC = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpmailbcc_N));
         n77WWPMailProcessed = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpmailprocessed_N));
         n78WWPMailDetail = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpmaildetail_N));
         n16WWPNotificationId = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow11( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Wwpmailattachmentfile = A76WWPMailAttachmentFile;
         obj11.gxTpr_Wwpmailattachmentname = A21WWPMailAttachmentName;
         obj11.gxTpr_Wwpmailattachmentname_Z = Z21WWPMailAttachmentName;
         obj11.gxTpr_Modified = nIsMod_11;
         return  ;
      }

      public void KeyVarsToRow11( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj11 )
      {
         obj11.gxTpr_Wwpmailattachmentname = A21WWPMailAttachmentName;
         return  ;
      }

      public void RowToVars11( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A76WWPMailAttachmentFile = obj11.gxTpr_Wwpmailattachmentfile;
         A21WWPMailAttachmentName = obj11.gxTpr_Wwpmailattachmentname;
         Z21WWPMailAttachmentName = obj11.gxTpr_Wwpmailattachmentname_Z;
         nIsMod_11 = obj11.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A20WWPMailId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A10( ) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20WWPMailId = A20WWPMailId;
         }
         ZM0A10( -8) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound10 == 1 )
         {
            ScanKeyStart0A11( ) ;
            nGXsfl_11_idx = 1;
            while ( RcdFound11 != 0 )
            {
               Z20WWPMailId = A20WWPMailId;
               Z21WWPMailAttachmentName = A21WWPMailAttachmentName;
               ZM0A11( -10) ;
               OnLoadActions0A11( ) ;
               nRcdExists_11 = 1;
               nIsMod_11 = 0;
               AddRow0A11( ) ;
               nGXsfl_11_idx = (int)(nGXsfl_11_idx+1);
               ScanKeyNext0A11( ) ;
            }
            ScanKeyEnd0A11( ) ;
         }
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20WWPMailId = A20WWPMailId;
         }
         ZM0A10( -8) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound10 == 1 )
         {
            ScanKeyStart0A11( ) ;
            nGXsfl_11_idx = 1;
            while ( RcdFound11 != 0 )
            {
               Z20WWPMailId = A20WWPMailId;
               Z21WWPMailAttachmentName = A21WWPMailAttachmentName;
               ZM0A11( -10) ;
               OnLoadActions0A11( ) ;
               nRcdExists_11 = 1;
               nIsMod_11 = 0;
               AddRow0A11( ) ;
               nGXsfl_11_idx = (int)(nGXsfl_11_idx+1);
               ScanKeyNext0A11( ) ;
            }
            ScanKeyEnd0A11( ) ;
         }
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A10( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A20WWPMailId != Z20WWPMailId )
               {
                  A20WWPMailId = Z20WWPMailId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0A10( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A20WWPMailId != Z20WWPMailId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0A10( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0A10( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A20WWPMailId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_Mail);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         UpdateImpl( ) ;
         VarsToRow10( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow10( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0A10( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A20WWPMailId != Z20WWPMailId )
            {
               A20WWPMailId = Z20WWPMailId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A20WWPMailId != Z20WWPMailId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(10);
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail_bc",pr_default);
         VarsToRow10( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_Mail )
         {
            bcwwpbaseobjects_mail_WWP_Mail = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
            else
            {
               RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Mail WWP_Mail_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_Mail ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwpmail_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode10 = "";
         Z61WWPMailSubject = "";
         A61WWPMailSubject = "";
         Z81WWPMailCreated = (DateTime)(DateTime.MinValue);
         A81WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A77WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z55WWPMailBody = "";
         A55WWPMailBody = "";
         Z62WWPMailTo = "";
         A62WWPMailTo = "";
         Z74WWPMailCC = "";
         A74WWPMailCC = "";
         Z75WWPMailBCC = "";
         A75WWPMailBCC = "";
         Z63WWPMailSenderAddress = "";
         A63WWPMailSenderAddress = "";
         Z64WWPMailSenderName = "";
         A64WWPMailSenderName = "";
         Z78WWPMailDetail = "";
         A78WWPMailDetail = "";
         BC000A7_A20WWPMailId = new long[1] ;
         BC000A7_A61WWPMailSubject = new string[] {""} ;
         BC000A7_A55WWPMailBody = new string[] {""} ;
         BC000A7_A62WWPMailTo = new string[] {""} ;
         BC000A7_n62WWPMailTo = new bool[] {false} ;
         BC000A7_A74WWPMailCC = new string[] {""} ;
         BC000A7_n74WWPMailCC = new bool[] {false} ;
         BC000A7_A75WWPMailBCC = new string[] {""} ;
         BC000A7_n75WWPMailBCC = new bool[] {false} ;
         BC000A7_A63WWPMailSenderAddress = new string[] {""} ;
         BC000A7_A64WWPMailSenderName = new string[] {""} ;
         BC000A7_A72WWPMailStatus = new short[1] ;
         BC000A7_A81WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A7_A82WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A7_A77WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A7_n77WWPMailProcessed = new bool[] {false} ;
         BC000A7_A78WWPMailDetail = new string[] {""} ;
         BC000A7_n78WWPMailDetail = new bool[] {false} ;
         BC000A7_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A7_A16WWPNotificationId = new long[1] ;
         BC000A7_n16WWPNotificationId = new bool[] {false} ;
         BC000A6_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A8_A20WWPMailId = new long[1] ;
         BC000A5_A20WWPMailId = new long[1] ;
         BC000A5_A61WWPMailSubject = new string[] {""} ;
         BC000A5_A55WWPMailBody = new string[] {""} ;
         BC000A5_A62WWPMailTo = new string[] {""} ;
         BC000A5_n62WWPMailTo = new bool[] {false} ;
         BC000A5_A74WWPMailCC = new string[] {""} ;
         BC000A5_n74WWPMailCC = new bool[] {false} ;
         BC000A5_A75WWPMailBCC = new string[] {""} ;
         BC000A5_n75WWPMailBCC = new bool[] {false} ;
         BC000A5_A63WWPMailSenderAddress = new string[] {""} ;
         BC000A5_A64WWPMailSenderName = new string[] {""} ;
         BC000A5_A72WWPMailStatus = new short[1] ;
         BC000A5_A81WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A5_A82WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A5_A77WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A5_n77WWPMailProcessed = new bool[] {false} ;
         BC000A5_A78WWPMailDetail = new string[] {""} ;
         BC000A5_n78WWPMailDetail = new bool[] {false} ;
         BC000A5_A16WWPNotificationId = new long[1] ;
         BC000A5_n16WWPNotificationId = new bool[] {false} ;
         BC000A4_A20WWPMailId = new long[1] ;
         BC000A4_A61WWPMailSubject = new string[] {""} ;
         BC000A4_A55WWPMailBody = new string[] {""} ;
         BC000A4_A62WWPMailTo = new string[] {""} ;
         BC000A4_n62WWPMailTo = new bool[] {false} ;
         BC000A4_A74WWPMailCC = new string[] {""} ;
         BC000A4_n74WWPMailCC = new bool[] {false} ;
         BC000A4_A75WWPMailBCC = new string[] {""} ;
         BC000A4_n75WWPMailBCC = new bool[] {false} ;
         BC000A4_A63WWPMailSenderAddress = new string[] {""} ;
         BC000A4_A64WWPMailSenderName = new string[] {""} ;
         BC000A4_A72WWPMailStatus = new short[1] ;
         BC000A4_A81WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A4_A82WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A4_A77WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A4_n77WWPMailProcessed = new bool[] {false} ;
         BC000A4_A78WWPMailDetail = new string[] {""} ;
         BC000A4_n78WWPMailDetail = new bool[] {false} ;
         BC000A4_A16WWPNotificationId = new long[1] ;
         BC000A4_n16WWPNotificationId = new bool[] {false} ;
         BC000A9_A20WWPMailId = new long[1] ;
         BC000A12_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A13_A20WWPMailId = new long[1] ;
         BC000A13_A61WWPMailSubject = new string[] {""} ;
         BC000A13_A55WWPMailBody = new string[] {""} ;
         BC000A13_A62WWPMailTo = new string[] {""} ;
         BC000A13_n62WWPMailTo = new bool[] {false} ;
         BC000A13_A74WWPMailCC = new string[] {""} ;
         BC000A13_n74WWPMailCC = new bool[] {false} ;
         BC000A13_A75WWPMailBCC = new string[] {""} ;
         BC000A13_n75WWPMailBCC = new bool[] {false} ;
         BC000A13_A63WWPMailSenderAddress = new string[] {""} ;
         BC000A13_A64WWPMailSenderName = new string[] {""} ;
         BC000A13_A72WWPMailStatus = new short[1] ;
         BC000A13_A81WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A13_A82WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A13_A77WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A13_n77WWPMailProcessed = new bool[] {false} ;
         BC000A13_A78WWPMailDetail = new string[] {""} ;
         BC000A13_n78WWPMailDetail = new bool[] {false} ;
         BC000A13_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A13_A16WWPNotificationId = new long[1] ;
         BC000A13_n16WWPNotificationId = new bool[] {false} ;
         Z21WWPMailAttachmentName = "";
         A21WWPMailAttachmentName = "";
         Z76WWPMailAttachmentFile = "";
         A76WWPMailAttachmentFile = "";
         BC000A14_A20WWPMailId = new long[1] ;
         BC000A14_A21WWPMailAttachmentName = new string[] {""} ;
         BC000A14_A76WWPMailAttachmentFile = new string[] {""} ;
         BC000A15_A20WWPMailId = new long[1] ;
         BC000A15_A21WWPMailAttachmentName = new string[] {""} ;
         BC000A3_A20WWPMailId = new long[1] ;
         BC000A3_A21WWPMailAttachmentName = new string[] {""} ;
         BC000A3_A76WWPMailAttachmentFile = new string[] {""} ;
         sMode11 = "";
         BC000A2_A20WWPMailId = new long[1] ;
         BC000A2_A21WWPMailAttachmentName = new string[] {""} ;
         BC000A2_A76WWPMailAttachmentFile = new string[] {""} ;
         BC000A19_A20WWPMailId = new long[1] ;
         BC000A19_A21WWPMailAttachmentName = new string[] {""} ;
         BC000A19_A76WWPMailAttachmentFile = new string[] {""} ;
         i81WWPMailCreated = (DateTime)(DateTime.MinValue);
         i82WWPMailScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A20WWPMailId, BC000A2_A21WWPMailAttachmentName, BC000A2_A76WWPMailAttachmentFile
               }
               , new Object[] {
               BC000A3_A20WWPMailId, BC000A3_A21WWPMailAttachmentName, BC000A3_A76WWPMailAttachmentFile
               }
               , new Object[] {
               BC000A4_A20WWPMailId, BC000A4_A61WWPMailSubject, BC000A4_A55WWPMailBody, BC000A4_A62WWPMailTo, BC000A4_n62WWPMailTo, BC000A4_A74WWPMailCC, BC000A4_n74WWPMailCC, BC000A4_A75WWPMailBCC, BC000A4_n75WWPMailBCC, BC000A4_A63WWPMailSenderAddress,
               BC000A4_A64WWPMailSenderName, BC000A4_A72WWPMailStatus, BC000A4_A81WWPMailCreated, BC000A4_A82WWPMailScheduled, BC000A4_A77WWPMailProcessed, BC000A4_n77WWPMailProcessed, BC000A4_A78WWPMailDetail, BC000A4_n78WWPMailDetail, BC000A4_A16WWPNotificationId, BC000A4_n16WWPNotificationId
               }
               , new Object[] {
               BC000A5_A20WWPMailId, BC000A5_A61WWPMailSubject, BC000A5_A55WWPMailBody, BC000A5_A62WWPMailTo, BC000A5_n62WWPMailTo, BC000A5_A74WWPMailCC, BC000A5_n74WWPMailCC, BC000A5_A75WWPMailBCC, BC000A5_n75WWPMailBCC, BC000A5_A63WWPMailSenderAddress,
               BC000A5_A64WWPMailSenderName, BC000A5_A72WWPMailStatus, BC000A5_A81WWPMailCreated, BC000A5_A82WWPMailScheduled, BC000A5_A77WWPMailProcessed, BC000A5_n77WWPMailProcessed, BC000A5_A78WWPMailDetail, BC000A5_n78WWPMailDetail, BC000A5_A16WWPNotificationId, BC000A5_n16WWPNotificationId
               }
               , new Object[] {
               BC000A6_A37WWPNotificationCreated
               }
               , new Object[] {
               BC000A7_A20WWPMailId, BC000A7_A61WWPMailSubject, BC000A7_A55WWPMailBody, BC000A7_A62WWPMailTo, BC000A7_n62WWPMailTo, BC000A7_A74WWPMailCC, BC000A7_n74WWPMailCC, BC000A7_A75WWPMailBCC, BC000A7_n75WWPMailBCC, BC000A7_A63WWPMailSenderAddress,
               BC000A7_A64WWPMailSenderName, BC000A7_A72WWPMailStatus, BC000A7_A81WWPMailCreated, BC000A7_A82WWPMailScheduled, BC000A7_A77WWPMailProcessed, BC000A7_n77WWPMailProcessed, BC000A7_A78WWPMailDetail, BC000A7_n78WWPMailDetail, BC000A7_A37WWPNotificationCreated, BC000A7_A16WWPNotificationId,
               BC000A7_n16WWPNotificationId
               }
               , new Object[] {
               BC000A8_A20WWPMailId
               }
               , new Object[] {
               BC000A9_A20WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A12_A37WWPNotificationCreated
               }
               , new Object[] {
               BC000A13_A20WWPMailId, BC000A13_A61WWPMailSubject, BC000A13_A55WWPMailBody, BC000A13_A62WWPMailTo, BC000A13_n62WWPMailTo, BC000A13_A74WWPMailCC, BC000A13_n74WWPMailCC, BC000A13_A75WWPMailBCC, BC000A13_n75WWPMailBCC, BC000A13_A63WWPMailSenderAddress,
               BC000A13_A64WWPMailSenderName, BC000A13_A72WWPMailStatus, BC000A13_A81WWPMailCreated, BC000A13_A82WWPMailScheduled, BC000A13_A77WWPMailProcessed, BC000A13_n77WWPMailProcessed, BC000A13_A78WWPMailDetail, BC000A13_n78WWPMailDetail, BC000A13_A37WWPNotificationCreated, BC000A13_A16WWPNotificationId,
               BC000A13_n16WWPNotificationId
               }
               , new Object[] {
               BC000A14_A20WWPMailId, BC000A14_A21WWPMailAttachmentName, BC000A14_A76WWPMailAttachmentFile
               }
               , new Object[] {
               BC000A15_A20WWPMailId, BC000A15_A21WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A19_A20WWPMailId, BC000A19_A21WWPMailAttachmentName, BC000A19_A76WWPMailAttachmentFile
               }
            }
         );
         Z82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i82WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i81WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z72WWPMailStatus = 1;
         A72WWPMailStatus = 1;
         i72WWPMailStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_11 ;
      private short RcdFound11 ;
      private short GX_JID ;
      private short Z72WWPMailStatus ;
      private short A72WWPMailStatus ;
      private short Gx_BScreen ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private short nRcdExists_11 ;
      private short Gxremove11 ;
      private short nIsDirty_11 ;
      private short i72WWPMailStatus ;
      private int trnEnded ;
      private int nGXsfl_11_idx=1 ;
      private long Z20WWPMailId ;
      private long A20WWPMailId ;
      private long Z16WWPNotificationId ;
      private long A16WWPNotificationId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode10 ;
      private string sMode11 ;
      private DateTime Z81WWPMailCreated ;
      private DateTime A81WWPMailCreated ;
      private DateTime Z82WWPMailScheduled ;
      private DateTime A82WWPMailScheduled ;
      private DateTime Z77WWPMailProcessed ;
      private DateTime A77WWPMailProcessed ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime i81WWPMailCreated ;
      private DateTime i82WWPMailScheduled ;
      private bool n62WWPMailTo ;
      private bool n74WWPMailCC ;
      private bool n75WWPMailBCC ;
      private bool n77WWPMailProcessed ;
      private bool n78WWPMailDetail ;
      private bool n16WWPNotificationId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z55WWPMailBody ;
      private string A55WWPMailBody ;
      private string Z62WWPMailTo ;
      private string A62WWPMailTo ;
      private string Z74WWPMailCC ;
      private string A74WWPMailCC ;
      private string Z75WWPMailBCC ;
      private string A75WWPMailBCC ;
      private string Z63WWPMailSenderAddress ;
      private string A63WWPMailSenderAddress ;
      private string Z64WWPMailSenderName ;
      private string A64WWPMailSenderName ;
      private string Z78WWPMailDetail ;
      private string A78WWPMailDetail ;
      private string Z76WWPMailAttachmentFile ;
      private string A76WWPMailAttachmentFile ;
      private string Z61WWPMailSubject ;
      private string A61WWPMailSubject ;
      private string Z21WWPMailAttachmentName ;
      private string A21WWPMailAttachmentName ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail bcwwpbaseobjects_mail_WWP_Mail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000A7_A20WWPMailId ;
      private string[] BC000A7_A61WWPMailSubject ;
      private string[] BC000A7_A55WWPMailBody ;
      private string[] BC000A7_A62WWPMailTo ;
      private bool[] BC000A7_n62WWPMailTo ;
      private string[] BC000A7_A74WWPMailCC ;
      private bool[] BC000A7_n74WWPMailCC ;
      private string[] BC000A7_A75WWPMailBCC ;
      private bool[] BC000A7_n75WWPMailBCC ;
      private string[] BC000A7_A63WWPMailSenderAddress ;
      private string[] BC000A7_A64WWPMailSenderName ;
      private short[] BC000A7_A72WWPMailStatus ;
      private DateTime[] BC000A7_A81WWPMailCreated ;
      private DateTime[] BC000A7_A82WWPMailScheduled ;
      private DateTime[] BC000A7_A77WWPMailProcessed ;
      private bool[] BC000A7_n77WWPMailProcessed ;
      private string[] BC000A7_A78WWPMailDetail ;
      private bool[] BC000A7_n78WWPMailDetail ;
      private DateTime[] BC000A7_A37WWPNotificationCreated ;
      private long[] BC000A7_A16WWPNotificationId ;
      private bool[] BC000A7_n16WWPNotificationId ;
      private DateTime[] BC000A6_A37WWPNotificationCreated ;
      private long[] BC000A8_A20WWPMailId ;
      private long[] BC000A5_A20WWPMailId ;
      private string[] BC000A5_A61WWPMailSubject ;
      private string[] BC000A5_A55WWPMailBody ;
      private string[] BC000A5_A62WWPMailTo ;
      private bool[] BC000A5_n62WWPMailTo ;
      private string[] BC000A5_A74WWPMailCC ;
      private bool[] BC000A5_n74WWPMailCC ;
      private string[] BC000A5_A75WWPMailBCC ;
      private bool[] BC000A5_n75WWPMailBCC ;
      private string[] BC000A5_A63WWPMailSenderAddress ;
      private string[] BC000A5_A64WWPMailSenderName ;
      private short[] BC000A5_A72WWPMailStatus ;
      private DateTime[] BC000A5_A81WWPMailCreated ;
      private DateTime[] BC000A5_A82WWPMailScheduled ;
      private DateTime[] BC000A5_A77WWPMailProcessed ;
      private bool[] BC000A5_n77WWPMailProcessed ;
      private string[] BC000A5_A78WWPMailDetail ;
      private bool[] BC000A5_n78WWPMailDetail ;
      private long[] BC000A5_A16WWPNotificationId ;
      private bool[] BC000A5_n16WWPNotificationId ;
      private long[] BC000A4_A20WWPMailId ;
      private string[] BC000A4_A61WWPMailSubject ;
      private string[] BC000A4_A55WWPMailBody ;
      private string[] BC000A4_A62WWPMailTo ;
      private bool[] BC000A4_n62WWPMailTo ;
      private string[] BC000A4_A74WWPMailCC ;
      private bool[] BC000A4_n74WWPMailCC ;
      private string[] BC000A4_A75WWPMailBCC ;
      private bool[] BC000A4_n75WWPMailBCC ;
      private string[] BC000A4_A63WWPMailSenderAddress ;
      private string[] BC000A4_A64WWPMailSenderName ;
      private short[] BC000A4_A72WWPMailStatus ;
      private DateTime[] BC000A4_A81WWPMailCreated ;
      private DateTime[] BC000A4_A82WWPMailScheduled ;
      private DateTime[] BC000A4_A77WWPMailProcessed ;
      private bool[] BC000A4_n77WWPMailProcessed ;
      private string[] BC000A4_A78WWPMailDetail ;
      private bool[] BC000A4_n78WWPMailDetail ;
      private long[] BC000A4_A16WWPNotificationId ;
      private bool[] BC000A4_n16WWPNotificationId ;
      private long[] BC000A9_A20WWPMailId ;
      private DateTime[] BC000A12_A37WWPNotificationCreated ;
      private long[] BC000A13_A20WWPMailId ;
      private string[] BC000A13_A61WWPMailSubject ;
      private string[] BC000A13_A55WWPMailBody ;
      private string[] BC000A13_A62WWPMailTo ;
      private bool[] BC000A13_n62WWPMailTo ;
      private string[] BC000A13_A74WWPMailCC ;
      private bool[] BC000A13_n74WWPMailCC ;
      private string[] BC000A13_A75WWPMailBCC ;
      private bool[] BC000A13_n75WWPMailBCC ;
      private string[] BC000A13_A63WWPMailSenderAddress ;
      private string[] BC000A13_A64WWPMailSenderName ;
      private short[] BC000A13_A72WWPMailStatus ;
      private DateTime[] BC000A13_A81WWPMailCreated ;
      private DateTime[] BC000A13_A82WWPMailScheduled ;
      private DateTime[] BC000A13_A77WWPMailProcessed ;
      private bool[] BC000A13_n77WWPMailProcessed ;
      private string[] BC000A13_A78WWPMailDetail ;
      private bool[] BC000A13_n78WWPMailDetail ;
      private DateTime[] BC000A13_A37WWPNotificationCreated ;
      private long[] BC000A13_A16WWPNotificationId ;
      private bool[] BC000A13_n16WWPNotificationId ;
      private long[] BC000A14_A20WWPMailId ;
      private string[] BC000A14_A21WWPMailAttachmentName ;
      private string[] BC000A14_A76WWPMailAttachmentFile ;
      private long[] BC000A15_A20WWPMailId ;
      private string[] BC000A15_A21WWPMailAttachmentName ;
      private long[] BC000A3_A20WWPMailId ;
      private string[] BC000A3_A21WWPMailAttachmentName ;
      private string[] BC000A3_A76WWPMailAttachmentFile ;
      private long[] BC000A2_A20WWPMailId ;
      private string[] BC000A2_A21WWPMailAttachmentName ;
      private string[] BC000A2_A76WWPMailAttachmentFile ;
      private long[] BC000A19_A20WWPMailId ;
      private string[] BC000A19_A21WWPMailAttachmentName ;
      private string[] BC000A19_A76WWPMailAttachmentFile ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mail_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000A7;
        prmBC000A7 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A6;
        prmBC000A6 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A8;
        prmBC000A8 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A5;
        prmBC000A5 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A4;
        prmBC000A4 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A9;
        prmBC000A9 = new Object[] {
        new Object[] {"@WWPMailSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTo",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailBCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderName",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPMailCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A10;
        prmBC000A10 = new Object[] {
        new Object[] {"@WWPMailSubject",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@WWPMailBody",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailTo",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailBCC",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderAddress",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailSenderName",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPMailCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPMailDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A11;
        prmBC000A11 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A12;
        prmBC000A12 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A13;
        prmBC000A13 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000A14;
        prmBC000A14 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC000A15;
        prmBC000A15 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC000A3;
        prmBC000A3 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC000A2;
        prmBC000A2 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC000A16;
        prmBC000A16 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPMailAttachmentFile",SqlDbType.NVarChar,2097152,0}
        };
        Object[] prmBC000A17;
        prmBC000A17 = new Object[] {
        new Object[] {"@WWPMailAttachmentFile",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC000A18;
        prmBC000A18 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPMailAttachmentName",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC000A19;
        prmBC000A19 = new Object[] {
        new Object[] {"@WWPMailId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000A2", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A3", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A4", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WITH (UPDLOCK) WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A5", "SELECT [WWPMailId], [WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A6", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A7", "SELECT TM1.[WWPMailId], TM1.[WWPMailSubject], TM1.[WWPMailBody], TM1.[WWPMailTo], TM1.[WWPMailCC], TM1.[WWPMailBCC], TM1.[WWPMailSenderAddress], TM1.[WWPMailSenderName], TM1.[WWPMailStatus], TM1.[WWPMailCreated], TM1.[WWPMailScheduled], TM1.[WWPMailProcessed], TM1.[WWPMailDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_Mail] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPMailId] = @WWPMailId ORDER BY TM1.[WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A8", "SELECT [WWPMailId] FROM [WWP_Mail] WHERE [WWPMailId] = @WWPMailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A9", "INSERT INTO [WWP_Mail]([WWPMailSubject], [WWPMailBody], [WWPMailTo], [WWPMailCC], [WWPMailBCC], [WWPMailSenderAddress], [WWPMailSenderName], [WWPMailStatus], [WWPMailCreated], [WWPMailScheduled], [WWPMailProcessed], [WWPMailDetail], [WWPNotificationId]) VALUES(@WWPMailSubject, @WWPMailBody, @WWPMailTo, @WWPMailCC, @WWPMailBCC, @WWPMailSenderAddress, @WWPMailSenderName, @WWPMailStatus, @WWPMailCreated, @WWPMailScheduled, @WWPMailProcessed, @WWPMailDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000A9)
           ,new CursorDef("BC000A10", "UPDATE [WWP_Mail] SET [WWPMailSubject]=@WWPMailSubject, [WWPMailBody]=@WWPMailBody, [WWPMailTo]=@WWPMailTo, [WWPMailCC]=@WWPMailCC, [WWPMailBCC]=@WWPMailBCC, [WWPMailSenderAddress]=@WWPMailSenderAddress, [WWPMailSenderName]=@WWPMailSenderName, [WWPMailStatus]=@WWPMailStatus, [WWPMailCreated]=@WWPMailCreated, [WWPMailScheduled]=@WWPMailScheduled, [WWPMailProcessed]=@WWPMailProcessed, [WWPMailDetail]=@WWPMailDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmBC000A10)
           ,new CursorDef("BC000A11", "DELETE FROM [WWP_Mail]  WHERE [WWPMailId] = @WWPMailId", GxErrorMask.GX_NOMASK,prmBC000A11)
           ,new CursorDef("BC000A12", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A13", "SELECT TM1.[WWPMailId], TM1.[WWPMailSubject], TM1.[WWPMailBody], TM1.[WWPMailTo], TM1.[WWPMailCC], TM1.[WWPMailBCC], TM1.[WWPMailSenderAddress], TM1.[WWPMailSenderName], TM1.[WWPMailStatus], TM1.[WWPMailCreated], TM1.[WWPMailScheduled], TM1.[WWPMailProcessed], TM1.[WWPMailDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_Mail] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPMailId] = @WWPMailId ORDER BY TM1.[WWPMailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A14", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId and [WWPMailAttachmentName] = @WWPMailAttachmentName ORDER BY [WWPMailId], [WWPMailAttachmentName]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A14,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A15", "SELECT [WWPMailId], [WWPMailAttachmentName] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A16", "INSERT INTO [WWP_MailAttachments]([WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile]) VALUES(@WWPMailId, @WWPMailAttachmentName, @WWPMailAttachmentFile)", GxErrorMask.GX_NOMASK,prmBC000A16)
           ,new CursorDef("BC000A17", "UPDATE [WWP_MailAttachments] SET [WWPMailAttachmentFile]=@WWPMailAttachmentFile  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmBC000A17)
           ,new CursorDef("BC000A18", "DELETE FROM [WWP_MailAttachments]  WHERE [WWPMailId] = @WWPMailId AND [WWPMailAttachmentName] = @WWPMailAttachmentName", GxErrorMask.GX_NOMASK,prmBC000A18)
           ,new CursorDef("BC000A19", "SELECT [WWPMailId], [WWPMailAttachmentName], [WWPMailAttachmentFile] FROM [WWP_MailAttachments] WHERE [WWPMailId] = @WWPMailId ORDER BY [WWPMailId], [WWPMailAttachmentName]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A19,11, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getLongVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLongVarchar(6);
              table[8][0] = rslt.wasNull(6);
              table[9][0] = rslt.getLongVarchar(7);
              table[10][0] = rslt.getLongVarchar(8);
              table[11][0] = rslt.getShort(9);
              table[12][0] = rslt.getGXDateTime(10, true);
              table[13][0] = rslt.getGXDateTime(11, true);
              table[14][0] = rslt.getGXDateTime(12, true);
              table[15][0] = rslt.wasNull(12);
              table[16][0] = rslt.getLongVarchar(13);
              table[17][0] = rslt.wasNull(13);
              table[18][0] = rslt.getLong(14);
              table[19][0] = rslt.wasNull(14);
              return;
           case 3 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getLongVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLongVarchar(6);
              table[8][0] = rslt.wasNull(6);
              table[9][0] = rslt.getLongVarchar(7);
              table[10][0] = rslt.getLongVarchar(8);
              table[11][0] = rslt.getShort(9);
              table[12][0] = rslt.getGXDateTime(10, true);
              table[13][0] = rslt.getGXDateTime(11, true);
              table[14][0] = rslt.getGXDateTime(12, true);
              table[15][0] = rslt.wasNull(12);
              table[16][0] = rslt.getLongVarchar(13);
              table[17][0] = rslt.wasNull(13);
              table[18][0] = rslt.getLong(14);
              table[19][0] = rslt.wasNull(14);
              return;
           case 4 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getLongVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLongVarchar(6);
              table[8][0] = rslt.wasNull(6);
              table[9][0] = rslt.getLongVarchar(7);
              table[10][0] = rslt.getLongVarchar(8);
              table[11][0] = rslt.getShort(9);
              table[12][0] = rslt.getGXDateTime(10, true);
              table[13][0] = rslt.getGXDateTime(11, true);
              table[14][0] = rslt.getGXDateTime(12, true);
              table[15][0] = rslt.wasNull(12);
              table[16][0] = rslt.getLongVarchar(13);
              table[17][0] = rslt.wasNull(13);
              table[18][0] = rslt.getGXDateTime(14, true);
              table[19][0] = rslt.getLong(15);
              table[20][0] = rslt.wasNull(15);
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 7 :
              table[0][0] = rslt.getLong(1);
              return;
           case 10 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 11 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getLongVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLongVarchar(6);
              table[8][0] = rslt.wasNull(6);
              table[9][0] = rslt.getLongVarchar(7);
              table[10][0] = rslt.getLongVarchar(8);
              table[11][0] = rslt.getShort(9);
              table[12][0] = rslt.getGXDateTime(10, true);
              table[13][0] = rslt.getGXDateTime(11, true);
              table[14][0] = rslt.getGXDateTime(12, true);
              table[15][0] = rslt.wasNull(12);
              table[16][0] = rslt.getLongVarchar(13);
              table[17][0] = rslt.wasNull(13);
              table[18][0] = rslt.getGXDateTime(14, true);
              table[19][0] = rslt.getLong(15);
              table[20][0] = rslt.wasNull(15);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              return;
           case 13 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 17 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
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
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 2 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 4 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 5 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 4 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(4, (string)parms[5]);
              }
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 5 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[7]);
              }
              stmt.SetParameter(6, (string)parms[8]);
              stmt.SetParameter(7, (string)parms[9]);
              stmt.SetParameter(8, (short)parms[10]);
              stmt.SetParameterDatetime(9, (DateTime)parms[11], true);
              stmt.SetParameterDatetime(10, (DateTime)parms[12], true);
              if ( (bool)parms[13] )
              {
                 stmt.setNull( 11 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(11, (DateTime)parms[14], true);
              }
              if ( (bool)parms[15] )
              {
                 stmt.setNull( 12 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(12, (string)parms[16]);
              }
              if ( (bool)parms[17] )
              {
                 stmt.setNull( 13 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(13, (long)parms[18]);
              }
              return;
           case 8 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 4 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(4, (string)parms[5]);
              }
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 5 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[7]);
              }
              stmt.SetParameter(6, (string)parms[8]);
              stmt.SetParameter(7, (string)parms[9]);
              stmt.SetParameter(8, (short)parms[10]);
              stmt.SetParameterDatetime(9, (DateTime)parms[11], true);
              stmt.SetParameterDatetime(10, (DateTime)parms[12], true);
              if ( (bool)parms[13] )
              {
                 stmt.setNull( 11 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(11, (DateTime)parms[14], true);
              }
              if ( (bool)parms[15] )
              {
                 stmt.setNull( 12 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(12, (string)parms[16]);
              }
              if ( (bool)parms[17] )
              {
                 stmt.setNull( 13 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(13, (long)parms[18]);
              }
              stmt.SetParameter(14, (long)parms[19]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 10 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 13 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 14 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              return;
           case 15 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (long)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              return;
           case 16 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 17 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
