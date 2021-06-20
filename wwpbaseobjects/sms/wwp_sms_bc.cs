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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_sms_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_sms_bc( IGxContext context )
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
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
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
               Z15WWPSMSId = A15WWPSMSId;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
                  ZM044( 9) ;
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z29WWPSMSStatus = A29WWPSMSStatus;
            Z35WWPSMSCreated = A35WWPSMSCreated;
            Z36WWPSMSScheduled = A36WWPSMSScheduled;
            Z30WWPSMSProcessed = A30WWPSMSProcessed;
            Z16WWPNotificationId = A16WWPNotificationId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
         }
         if ( GX_JID == -8 )
         {
            Z15WWPSMSId = A15WWPSMSId;
            Z32WWPSMSMessage = A32WWPSMSMessage;
            Z33WWPSMSSenderNumber = A33WWPSMSSenderNumber;
            Z34WWPSMSRecipientNumbers = A34WWPSMSRecipientNumbers;
            Z29WWPSMSStatus = A29WWPSMSStatus;
            Z35WWPSMSCreated = A35WWPSMSCreated;
            Z36WWPSMSScheduled = A36WWPSMSScheduled;
            Z30WWPSMSProcessed = A30WWPSMSProcessed;
            Z31WWPSMSDetail = A31WWPSMSDetail;
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
         if ( IsIns( )  && (0==A29WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A29WWPSMSStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A35WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A36WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load044( )
      {
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
            A32WWPSMSMessage = BC00045_A32WWPSMSMessage[0];
            A33WWPSMSSenderNumber = BC00045_A33WWPSMSSenderNumber[0];
            A34WWPSMSRecipientNumbers = BC00045_A34WWPSMSRecipientNumbers[0];
            A29WWPSMSStatus = BC00045_A29WWPSMSStatus[0];
            A35WWPSMSCreated = BC00045_A35WWPSMSCreated[0];
            A36WWPSMSScheduled = BC00045_A36WWPSMSScheduled[0];
            A30WWPSMSProcessed = BC00045_A30WWPSMSProcessed[0];
            n30WWPSMSProcessed = BC00045_n30WWPSMSProcessed[0];
            A31WWPSMSDetail = BC00045_A31WWPSMSDetail[0];
            n31WWPSMSDetail = BC00045_n31WWPSMSDetail[0];
            A37WWPNotificationCreated = BC00045_A37WWPNotificationCreated[0];
            A16WWPNotificationId = BC00045_A16WWPNotificationId[0];
            n16WWPNotificationId = BC00045_n16WWPNotificationId[0];
            ZM044( -8) ;
         }
         pr_default.close(3);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A29WWPSMSStatus == 1 ) || ( A29WWPSMSStatus == 2 ) || ( A29WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo SMS Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A35WWPSMSCreated) || ( A35WWPSMSCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo SMS Created fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A36WWPSMSScheduled) || ( A36WWPSMSScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo SMS Scheduled fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A30WWPSMSProcessed) || ( A30WWPSMSProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo SMS Processed fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A37WWPNotificationCreated = BC00044_A37WWPNotificationCreated[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A15WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 8) ;
            RcdFound4 = 1;
            A15WWPSMSId = BC00043_A15WWPSMSId[0];
            A32WWPSMSMessage = BC00043_A32WWPSMSMessage[0];
            A33WWPSMSSenderNumber = BC00043_A33WWPSMSSenderNumber[0];
            A34WWPSMSRecipientNumbers = BC00043_A34WWPSMSRecipientNumbers[0];
            A29WWPSMSStatus = BC00043_A29WWPSMSStatus[0];
            A35WWPSMSCreated = BC00043_A35WWPSMSCreated[0];
            A36WWPSMSScheduled = BC00043_A36WWPSMSScheduled[0];
            A30WWPSMSProcessed = BC00043_A30WWPSMSProcessed[0];
            n30WWPSMSProcessed = BC00043_n30WWPSMSProcessed[0];
            A31WWPSMSDetail = BC00043_A31WWPSMSDetail[0];
            n31WWPSMSDetail = BC00043_n31WWPSMSDetail[0];
            A16WWPNotificationId = BC00043_A16WWPNotificationId[0];
            n16WWPNotificationId = BC00043_n16WWPNotificationId[0];
            Z15WWPSMSId = A15WWPSMSId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_040( ) ;
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

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A15WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z29WWPSMSStatus != BC00042_A29WWPSMSStatus[0] ) || ( Z35WWPSMSCreated != BC00042_A35WWPSMSCreated[0] ) || ( Z36WWPSMSScheduled != BC00042_A36WWPSMSScheduled[0] ) || ( Z30WWPSMSProcessed != BC00042_A30WWPSMSProcessed[0] ) || ( Z16WWPNotificationId != BC00042_A16WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00047 */
                     pr_default.execute(5, new Object[] {A32WWPSMSMessage, A33WWPSMSSenderNumber, A34WWPSMSRecipientNumbers, A29WWPSMSStatus, A35WWPSMSCreated, A36WWPSMSScheduled, n30WWPSMSProcessed, A30WWPSMSProcessed, n31WWPSMSDetail, A31WWPSMSDetail, n16WWPNotificationId, A16WWPNotificationId});
                     A15WWPSMSId = BC00047_A15WWPSMSId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00048 */
                     pr_default.execute(6, new Object[] {A32WWPSMSMessage, A33WWPSMSSenderNumber, A34WWPSMSRecipientNumbers, A29WWPSMSStatus, A35WWPSMSCreated, A36WWPSMSScheduled, n30WWPSMSProcessed, A30WWPSMSProcessed, n31WWPSMSDetail, A31WWPSMSDetail, n16WWPNotificationId, A16WWPNotificationId, A15WWPSMSId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00049 */
                  pr_default.execute(7, new Object[] {A15WWPSMSId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_SMS");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000410 */
            pr_default.execute(8, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            A37WWPNotificationCreated = BC000410_A37WWPNotificationCreated[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
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

      public void ScanKeyStart044( )
      {
         /* Using cursor BC000411 */
         pr_default.execute(9, new Object[] {A15WWPSMSId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound4 = 1;
            A15WWPSMSId = BC000411_A15WWPSMSId[0];
            A32WWPSMSMessage = BC000411_A32WWPSMSMessage[0];
            A33WWPSMSSenderNumber = BC000411_A33WWPSMSSenderNumber[0];
            A34WWPSMSRecipientNumbers = BC000411_A34WWPSMSRecipientNumbers[0];
            A29WWPSMSStatus = BC000411_A29WWPSMSStatus[0];
            A35WWPSMSCreated = BC000411_A35WWPSMSCreated[0];
            A36WWPSMSScheduled = BC000411_A36WWPSMSScheduled[0];
            A30WWPSMSProcessed = BC000411_A30WWPSMSProcessed[0];
            n30WWPSMSProcessed = BC000411_n30WWPSMSProcessed[0];
            A31WWPSMSDetail = BC000411_A31WWPSMSDetail[0];
            n31WWPSMSDetail = BC000411_n31WWPSMSDetail[0];
            A37WWPNotificationCreated = BC000411_A37WWPNotificationCreated[0];
            A16WWPNotificationId = BC000411_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000411_n16WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound4 = 1;
            A15WWPSMSId = BC000411_A15WWPSMSId[0];
            A32WWPSMSMessage = BC000411_A32WWPSMSMessage[0];
            A33WWPSMSSenderNumber = BC000411_A33WWPSMSSenderNumber[0];
            A34WWPSMSRecipientNumbers = BC000411_A34WWPSMSRecipientNumbers[0];
            A29WWPSMSStatus = BC000411_A29WWPSMSStatus[0];
            A35WWPSMSCreated = BC000411_A35WWPSMSCreated[0];
            A36WWPSMSScheduled = BC000411_A36WWPSMSScheduled[0];
            A30WWPSMSProcessed = BC000411_A30WWPSMSProcessed[0];
            n30WWPSMSProcessed = BC000411_n30WWPSMSProcessed[0];
            A31WWPSMSDetail = BC000411_A31WWPSMSDetail[0];
            n31WWPSMSDetail = BC000411_n31WWPSMSDetail[0];
            A37WWPNotificationCreated = BC000411_A37WWPNotificationCreated[0];
            A16WWPNotificationId = BC000411_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000411_n16WWPNotificationId[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcwwpbaseobjects_sms_WWP_SMS) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A32WWPSMSMessage = "";
         A33WWPSMSSenderNumber = "";
         A34WWPSMSRecipientNumbers = "";
         A30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n30WWPSMSProcessed = false;
         A31WWPSMSDetail = "";
         n31WWPSMSDetail = false;
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A29WWPSMSStatus = 1;
         A35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z29WWPSMSStatus = 0;
         Z35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z16WWPNotificationId = 0;
      }

      protected void InitAll044( )
      {
         A15WWPSMSId = 0;
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29WWPSMSStatus = i29WWPSMSStatus;
         A35WWPSMSCreated = i35WWPSMSCreated;
         A36WWPSMSScheduled = i36WWPSMSScheduled;
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

      public void VarsToRow4( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Wwpsmsmessage = A32WWPSMSMessage;
         obj4.gxTpr_Wwpsmssendernumber = A33WWPSMSSenderNumber;
         obj4.gxTpr_Wwpsmsrecipientnumbers = A34WWPSMSRecipientNumbers;
         obj4.gxTpr_Wwpsmsprocessed = A30WWPSMSProcessed;
         obj4.gxTpr_Wwpsmsdetail = A31WWPSMSDetail;
         obj4.gxTpr_Wwpnotificationid = A16WWPNotificationId;
         obj4.gxTpr_Wwpnotificationcreated = A37WWPNotificationCreated;
         obj4.gxTpr_Wwpsmsstatus = A29WWPSMSStatus;
         obj4.gxTpr_Wwpsmscreated = A35WWPSMSCreated;
         obj4.gxTpr_Wwpsmsscheduled = A36WWPSMSScheduled;
         obj4.gxTpr_Wwpsmsid = A15WWPSMSId;
         obj4.gxTpr_Wwpsmsid_Z = Z15WWPSMSId;
         obj4.gxTpr_Wwpsmsstatus_Z = Z29WWPSMSStatus;
         obj4.gxTpr_Wwpsmscreated_Z = Z35WWPSMSCreated;
         obj4.gxTpr_Wwpsmsscheduled_Z = Z36WWPSMSScheduled;
         obj4.gxTpr_Wwpsmsprocessed_Z = Z30WWPSMSProcessed;
         obj4.gxTpr_Wwpnotificationid_Z = Z16WWPNotificationId;
         obj4.gxTpr_Wwpnotificationcreated_Z = Z37WWPNotificationCreated;
         obj4.gxTpr_Wwpsmsprocessed_N = (short)(Convert.ToInt16(n30WWPSMSProcessed));
         obj4.gxTpr_Wwpsmsdetail_N = (short)(Convert.ToInt16(n31WWPSMSDetail));
         obj4.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n16WWPNotificationId));
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj4 )
      {
         obj4.gxTpr_Wwpsmsid = A15WWPSMSId;
         return  ;
      }

      public void RowToVars4( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A32WWPSMSMessage = obj4.gxTpr_Wwpsmsmessage;
         A33WWPSMSSenderNumber = obj4.gxTpr_Wwpsmssendernumber;
         A34WWPSMSRecipientNumbers = obj4.gxTpr_Wwpsmsrecipientnumbers;
         A30WWPSMSProcessed = obj4.gxTpr_Wwpsmsprocessed;
         n30WWPSMSProcessed = false;
         A31WWPSMSDetail = obj4.gxTpr_Wwpsmsdetail;
         n31WWPSMSDetail = false;
         A16WWPNotificationId = obj4.gxTpr_Wwpnotificationid;
         n16WWPNotificationId = false;
         A37WWPNotificationCreated = obj4.gxTpr_Wwpnotificationcreated;
         A29WWPSMSStatus = obj4.gxTpr_Wwpsmsstatus;
         A35WWPSMSCreated = obj4.gxTpr_Wwpsmscreated;
         A36WWPSMSScheduled = obj4.gxTpr_Wwpsmsscheduled;
         A15WWPSMSId = obj4.gxTpr_Wwpsmsid;
         Z15WWPSMSId = obj4.gxTpr_Wwpsmsid_Z;
         Z29WWPSMSStatus = obj4.gxTpr_Wwpsmsstatus_Z;
         Z35WWPSMSCreated = obj4.gxTpr_Wwpsmscreated_Z;
         Z36WWPSMSScheduled = obj4.gxTpr_Wwpsmsscheduled_Z;
         Z30WWPSMSProcessed = obj4.gxTpr_Wwpsmsprocessed_Z;
         Z16WWPNotificationId = obj4.gxTpr_Wwpnotificationid_Z;
         Z37WWPNotificationCreated = obj4.gxTpr_Wwpnotificationcreated_Z;
         n30WWPSMSProcessed = (bool)(Convert.ToBoolean(obj4.gxTpr_Wwpsmsprocessed_N));
         n31WWPSMSDetail = (bool)(Convert.ToBoolean(obj4.gxTpr_Wwpsmsdetail_N));
         n16WWPNotificationId = (bool)(Convert.ToBoolean(obj4.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A15WWPSMSId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z15WWPSMSId = A15WWPSMSId;
         }
         ZM044( -8) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z15WWPSMSId = A15WWPSMSId;
         }
         ZM044( -8) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A15WWPSMSId != Z15WWPSMSId )
               {
                  A15WWPSMSId = Z15WWPSMSId;
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
                  Update044( ) ;
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
                  if ( A15WWPSMSId != Z15WWPSMSId )
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
                        Insert044( ) ;
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
                        Insert044( ) ;
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
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcwwpbaseobjects_sms_WWP_SMS) ;
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
            GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS auxBC = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A15WWPSMSId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_sms_WWP_SMS);
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
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         UpdateImpl( ) ;
         VarsToRow4( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
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
         VarsToRow4( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A15WWPSMSId != Z15WWPSMSId )
            {
               A15WWPSMSId = Z15WWPSMSId;
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
            if ( A15WWPSMSId != Z15WWPSMSId )
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
         pr_default.close(1);
         pr_default.close(8);
         context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms_bc",pr_default);
         VarsToRow4( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         Gx_mode = bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_sms_WWP_SMS )
         {
            bcwwpbaseobjects_sms_WWP_SMS = (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
            else
            {
               RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_SMS WWP_SMS_BC
      {
         get {
            return bcwwpbaseobjects_sms_WWP_SMS ;
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
            return "sms_Execute" ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A30WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z32WWPSMSMessage = "";
         A32WWPSMSMessage = "";
         Z33WWPSMSSenderNumber = "";
         A33WWPSMSSenderNumber = "";
         Z34WWPSMSRecipientNumbers = "";
         A34WWPSMSRecipientNumbers = "";
         Z31WWPSMSDetail = "";
         A31WWPSMSDetail = "";
         BC00045_A15WWPSMSId = new long[1] ;
         BC00045_A32WWPSMSMessage = new string[] {""} ;
         BC00045_A33WWPSMSSenderNumber = new string[] {""} ;
         BC00045_A34WWPSMSRecipientNumbers = new string[] {""} ;
         BC00045_A29WWPSMSStatus = new short[1] ;
         BC00045_A35WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00045_A36WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00045_A30WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00045_n30WWPSMSProcessed = new bool[] {false} ;
         BC00045_A31WWPSMSDetail = new string[] {""} ;
         BC00045_n31WWPSMSDetail = new bool[] {false} ;
         BC00045_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00045_A16WWPNotificationId = new long[1] ;
         BC00045_n16WWPNotificationId = new bool[] {false} ;
         BC00044_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00046_A15WWPSMSId = new long[1] ;
         BC00043_A15WWPSMSId = new long[1] ;
         BC00043_A32WWPSMSMessage = new string[] {""} ;
         BC00043_A33WWPSMSSenderNumber = new string[] {""} ;
         BC00043_A34WWPSMSRecipientNumbers = new string[] {""} ;
         BC00043_A29WWPSMSStatus = new short[1] ;
         BC00043_A35WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00043_A36WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00043_A30WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00043_n30WWPSMSProcessed = new bool[] {false} ;
         BC00043_A31WWPSMSDetail = new string[] {""} ;
         BC00043_n31WWPSMSDetail = new bool[] {false} ;
         BC00043_A16WWPNotificationId = new long[1] ;
         BC00043_n16WWPNotificationId = new bool[] {false} ;
         sMode4 = "";
         BC00042_A15WWPSMSId = new long[1] ;
         BC00042_A32WWPSMSMessage = new string[] {""} ;
         BC00042_A33WWPSMSSenderNumber = new string[] {""} ;
         BC00042_A34WWPSMSRecipientNumbers = new string[] {""} ;
         BC00042_A29WWPSMSStatus = new short[1] ;
         BC00042_A35WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00042_A36WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00042_A30WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00042_n30WWPSMSProcessed = new bool[] {false} ;
         BC00042_A31WWPSMSDetail = new string[] {""} ;
         BC00042_n31WWPSMSDetail = new bool[] {false} ;
         BC00042_A16WWPNotificationId = new long[1] ;
         BC00042_n16WWPNotificationId = new bool[] {false} ;
         BC00047_A15WWPSMSId = new long[1] ;
         BC000410_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000411_A15WWPSMSId = new long[1] ;
         BC000411_A32WWPSMSMessage = new string[] {""} ;
         BC000411_A33WWPSMSSenderNumber = new string[] {""} ;
         BC000411_A34WWPSMSRecipientNumbers = new string[] {""} ;
         BC000411_A29WWPSMSStatus = new short[1] ;
         BC000411_A35WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000411_A36WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000411_A30WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000411_n30WWPSMSProcessed = new bool[] {false} ;
         BC000411_A31WWPSMSDetail = new string[] {""} ;
         BC000411_n31WWPSMSDetail = new bool[] {false} ;
         BC000411_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000411_A16WWPNotificationId = new long[1] ;
         BC000411_n16WWPNotificationId = new bool[] {false} ;
         i35WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i36WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A15WWPSMSId, BC00042_A32WWPSMSMessage, BC00042_A33WWPSMSSenderNumber, BC00042_A34WWPSMSRecipientNumbers, BC00042_A29WWPSMSStatus, BC00042_A35WWPSMSCreated, BC00042_A36WWPSMSScheduled, BC00042_A30WWPSMSProcessed, BC00042_n30WWPSMSProcessed, BC00042_A31WWPSMSDetail,
               BC00042_n31WWPSMSDetail, BC00042_A16WWPNotificationId, BC00042_n16WWPNotificationId
               }
               , new Object[] {
               BC00043_A15WWPSMSId, BC00043_A32WWPSMSMessage, BC00043_A33WWPSMSSenderNumber, BC00043_A34WWPSMSRecipientNumbers, BC00043_A29WWPSMSStatus, BC00043_A35WWPSMSCreated, BC00043_A36WWPSMSScheduled, BC00043_A30WWPSMSProcessed, BC00043_n30WWPSMSProcessed, BC00043_A31WWPSMSDetail,
               BC00043_n31WWPSMSDetail, BC00043_A16WWPNotificationId, BC00043_n16WWPNotificationId
               }
               , new Object[] {
               BC00044_A37WWPNotificationCreated
               }
               , new Object[] {
               BC00045_A15WWPSMSId, BC00045_A32WWPSMSMessage, BC00045_A33WWPSMSSenderNumber, BC00045_A34WWPSMSRecipientNumbers, BC00045_A29WWPSMSStatus, BC00045_A35WWPSMSCreated, BC00045_A36WWPSMSScheduled, BC00045_A30WWPSMSProcessed, BC00045_n30WWPSMSProcessed, BC00045_A31WWPSMSDetail,
               BC00045_n31WWPSMSDetail, BC00045_A37WWPNotificationCreated, BC00045_A16WWPNotificationId, BC00045_n16WWPNotificationId
               }
               , new Object[] {
               BC00046_A15WWPSMSId
               }
               , new Object[] {
               BC00047_A15WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000410_A37WWPNotificationCreated
               }
               , new Object[] {
               BC000411_A15WWPSMSId, BC000411_A32WWPSMSMessage, BC000411_A33WWPSMSSenderNumber, BC000411_A34WWPSMSRecipientNumbers, BC000411_A29WWPSMSStatus, BC000411_A35WWPSMSCreated, BC000411_A36WWPSMSScheduled, BC000411_A30WWPSMSProcessed, BC000411_n30WWPSMSProcessed, BC000411_A31WWPSMSDetail,
               BC000411_n31WWPSMSDetail, BC000411_A37WWPNotificationCreated, BC000411_A16WWPNotificationId, BC000411_n16WWPNotificationId
               }
            }
         );
         Z36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i36WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i35WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z29WWPSMSStatus = 1;
         A29WWPSMSStatus = 1;
         i29WWPSMSStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z29WWPSMSStatus ;
      private short A29WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private short i29WWPSMSStatus ;
      private int trnEnded ;
      private long Z15WWPSMSId ;
      private long A15WWPSMSId ;
      private long Z16WWPNotificationId ;
      private long A16WWPNotificationId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode4 ;
      private DateTime Z35WWPSMSCreated ;
      private DateTime A35WWPSMSCreated ;
      private DateTime Z36WWPSMSScheduled ;
      private DateTime A36WWPSMSScheduled ;
      private DateTime Z30WWPSMSProcessed ;
      private DateTime A30WWPSMSProcessed ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime i35WWPSMSCreated ;
      private DateTime i36WWPSMSScheduled ;
      private bool n30WWPSMSProcessed ;
      private bool n31WWPSMSDetail ;
      private bool n16WWPNotificationId ;
      private bool mustCommit ;
      private string Z32WWPSMSMessage ;
      private string A32WWPSMSMessage ;
      private string Z33WWPSMSSenderNumber ;
      private string A33WWPSMSSenderNumber ;
      private string Z34WWPSMSRecipientNumbers ;
      private string A34WWPSMSRecipientNumbers ;
      private string Z31WWPSMSDetail ;
      private string A31WWPSMSDetail ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS bcwwpbaseobjects_sms_WWP_SMS ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00045_A15WWPSMSId ;
      private string[] BC00045_A32WWPSMSMessage ;
      private string[] BC00045_A33WWPSMSSenderNumber ;
      private string[] BC00045_A34WWPSMSRecipientNumbers ;
      private short[] BC00045_A29WWPSMSStatus ;
      private DateTime[] BC00045_A35WWPSMSCreated ;
      private DateTime[] BC00045_A36WWPSMSScheduled ;
      private DateTime[] BC00045_A30WWPSMSProcessed ;
      private bool[] BC00045_n30WWPSMSProcessed ;
      private string[] BC00045_A31WWPSMSDetail ;
      private bool[] BC00045_n31WWPSMSDetail ;
      private DateTime[] BC00045_A37WWPNotificationCreated ;
      private long[] BC00045_A16WWPNotificationId ;
      private bool[] BC00045_n16WWPNotificationId ;
      private DateTime[] BC00044_A37WWPNotificationCreated ;
      private long[] BC00046_A15WWPSMSId ;
      private long[] BC00043_A15WWPSMSId ;
      private string[] BC00043_A32WWPSMSMessage ;
      private string[] BC00043_A33WWPSMSSenderNumber ;
      private string[] BC00043_A34WWPSMSRecipientNumbers ;
      private short[] BC00043_A29WWPSMSStatus ;
      private DateTime[] BC00043_A35WWPSMSCreated ;
      private DateTime[] BC00043_A36WWPSMSScheduled ;
      private DateTime[] BC00043_A30WWPSMSProcessed ;
      private bool[] BC00043_n30WWPSMSProcessed ;
      private string[] BC00043_A31WWPSMSDetail ;
      private bool[] BC00043_n31WWPSMSDetail ;
      private long[] BC00043_A16WWPNotificationId ;
      private bool[] BC00043_n16WWPNotificationId ;
      private long[] BC00042_A15WWPSMSId ;
      private string[] BC00042_A32WWPSMSMessage ;
      private string[] BC00042_A33WWPSMSSenderNumber ;
      private string[] BC00042_A34WWPSMSRecipientNumbers ;
      private short[] BC00042_A29WWPSMSStatus ;
      private DateTime[] BC00042_A35WWPSMSCreated ;
      private DateTime[] BC00042_A36WWPSMSScheduled ;
      private DateTime[] BC00042_A30WWPSMSProcessed ;
      private bool[] BC00042_n30WWPSMSProcessed ;
      private string[] BC00042_A31WWPSMSDetail ;
      private bool[] BC00042_n31WWPSMSDetail ;
      private long[] BC00042_A16WWPNotificationId ;
      private bool[] BC00042_n16WWPNotificationId ;
      private long[] BC00047_A15WWPSMSId ;
      private DateTime[] BC000410_A37WWPNotificationCreated ;
      private long[] BC000411_A15WWPSMSId ;
      private string[] BC000411_A32WWPSMSMessage ;
      private string[] BC000411_A33WWPSMSSenderNumber ;
      private string[] BC000411_A34WWPSMSRecipientNumbers ;
      private short[] BC000411_A29WWPSMSStatus ;
      private DateTime[] BC000411_A35WWPSMSCreated ;
      private DateTime[] BC000411_A36WWPSMSScheduled ;
      private DateTime[] BC000411_A30WWPSMSProcessed ;
      private bool[] BC000411_n30WWPSMSProcessed ;
      private string[] BC000411_A31WWPSMSDetail ;
      private bool[] BC000411_n31WWPSMSDetail ;
      private DateTime[] BC000411_A37WWPNotificationCreated ;
      private long[] BC000411_A16WWPNotificationId ;
      private bool[] BC000411_n16WWPNotificationId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sms_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00045;
        prmBC00045 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00044;
        prmBC00044 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00046;
        prmBC00046 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00043;
        prmBC00043 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00042;
        prmBC00042 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00047;
        prmBC00047 = new Object[] {
        new Object[] {"@WWPSMSMessage",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSSenderNumber",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSRecipientNumbers",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPSMSCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00048;
        prmBC00048 = new Object[] {
        new Object[] {"@WWPSMSMessage",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSSenderNumber",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSRecipientNumbers",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPSMSStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPSMSCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPSMSDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00049;
        prmBC00049 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000410;
        prmBC000410 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000411;
        prmBC000411 = new Object[] {
        new Object[] {"@WWPSMSId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00042", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WITH (UPDLOCK) WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00043", "SELECT [WWPSMSId], [WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00044", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00045", "SELECT TM1.[WWPSMSId], TM1.[WWPSMSMessage], TM1.[WWPSMSSenderNumber], TM1.[WWPSMSRecipientNumbers], TM1.[WWPSMSStatus], TM1.[WWPSMSCreated], TM1.[WWPSMSScheduled], TM1.[WWPSMSProcessed], TM1.[WWPSMSDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_SMS] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPSMSId] = @WWPSMSId ORDER BY TM1.[WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00046", "SELECT [WWPSMSId] FROM [WWP_SMS] WHERE [WWPSMSId] = @WWPSMSId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00047", "INSERT INTO [WWP_SMS]([WWPSMSMessage], [WWPSMSSenderNumber], [WWPSMSRecipientNumbers], [WWPSMSStatus], [WWPSMSCreated], [WWPSMSScheduled], [WWPSMSProcessed], [WWPSMSDetail], [WWPNotificationId]) VALUES(@WWPSMSMessage, @WWPSMSSenderNumber, @WWPSMSRecipientNumbers, @WWPSMSStatus, @WWPSMSCreated, @WWPSMSScheduled, @WWPSMSProcessed, @WWPSMSDetail, @WWPNotificationId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC00047)
           ,new CursorDef("BC00048", "UPDATE [WWP_SMS] SET [WWPSMSMessage]=@WWPSMSMessage, [WWPSMSSenderNumber]=@WWPSMSSenderNumber, [WWPSMSRecipientNumbers]=@WWPSMSRecipientNumbers, [WWPSMSStatus]=@WWPSMSStatus, [WWPSMSCreated]=@WWPSMSCreated, [WWPSMSScheduled]=@WWPSMSScheduled, [WWPSMSProcessed]=@WWPSMSProcessed, [WWPSMSDetail]=@WWPSMSDetail, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmBC00048)
           ,new CursorDef("BC00049", "DELETE FROM [WWP_SMS]  WHERE [WWPSMSId] = @WWPSMSId", GxErrorMask.GX_NOMASK,prmBC00049)
           ,new CursorDef("BC000410", "SELECT [WWPNotificationCreated] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000411", "SELECT TM1.[WWPSMSId], TM1.[WWPSMSMessage], TM1.[WWPSMSSenderNumber], TM1.[WWPSMSRecipientNumbers], TM1.[WWPSMSStatus], TM1.[WWPSMSCreated], TM1.[WWPSMSScheduled], TM1.[WWPSMSProcessed], TM1.[WWPSMSDetail], T2.[WWPNotificationCreated], TM1.[WWPNotificationId] FROM ([WWP_SMS] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) WHERE TM1.[WWPSMSId] = @WWPSMSId ORDER BY TM1.[WWPSMSId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000411,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getGXDateTime(6, true);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.wasNull(9);
              table[11][0] = rslt.getLong(10);
              table[12][0] = rslt.wasNull(10);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getGXDateTime(6, true);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.wasNull(9);
              table[11][0] = rslt.getLong(10);
              table[12][0] = rslt.wasNull(10);
              return;
           case 2 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getGXDateTime(6, true);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.wasNull(9);
              table[11][0] = rslt.getGXDateTime(10, true);
              table[12][0] = rslt.getLong(11);
              table[13][0] = rslt.wasNull(11);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              return;
           case 8 :
              table[0][0] = rslt.getGXDateTime(1, true);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLongVarchar(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getLongVarchar(4);
              table[4][0] = rslt.getShort(5);
              table[5][0] = rslt.getGXDateTime(6, true);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.wasNull(9);
              table[11][0] = rslt.getGXDateTime(10, true);
              table[12][0] = rslt.getLong(11);
              table[13][0] = rslt.wasNull(11);
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
              return;
           case 1 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 2 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 3 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameterDatetime(5, (DateTime)parms[4], true);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(7, (DateTime)parms[7], true);
              }
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 8 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(8, (string)parms[9]);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 9 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(9, (long)parms[11]);
              }
              return;
           case 6 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (short)parms[3]);
              stmt.SetParameterDatetime(5, (DateTime)parms[4], true);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(7, (DateTime)parms[7], true);
              }
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 8 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(8, (string)parms[9]);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 9 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(9, (long)parms[11]);
              }
              stmt.SetParameter(10, (long)parms[12]);
              return;
           case 7 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 8 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
