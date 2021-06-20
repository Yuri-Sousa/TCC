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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webnotification_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_webnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_webnotification_bc( IGxContext context )
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
         ReadRow055( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey055( ) ;
         standaloneModal( ) ;
         AddRow055( ) ;
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
               Z17WWPWebNotificationId = A17WWPWebNotificationId;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               if ( AnyError == 0 )
               {
                  ZM055( 10) ;
                  ZM055( 11) ;
               }
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z38WWPWebNotificationTitle = A38WWPWebNotificationTitle;
            Z39WWPWebNotificationText = A39WWPWebNotificationText;
            Z40WWPWebNotificationIcon = A40WWPWebNotificationIcon;
            Z48WWPWebNotificationStatus = A48WWPWebNotificationStatus;
            Z41WWPWebNotificationCreated = A41WWPWebNotificationCreated;
            Z52WWPWebNotificationScheduled = A52WWPWebNotificationScheduled;
            Z49WWPWebNotificationProcessed = A49WWPWebNotificationProcessed;
            Z42WWPWebNotificationRead = A42WWPWebNotificationRead;
            Z51WWPWebNotificationReceived = A51WWPWebNotificationReceived;
            Z16WWPNotificationId = A16WWPNotificationId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
         }
         if ( GX_JID == -9 )
         {
            Z17WWPWebNotificationId = A17WWPWebNotificationId;
            Z38WWPWebNotificationTitle = A38WWPWebNotificationTitle;
            Z39WWPWebNotificationText = A39WWPWebNotificationText;
            Z40WWPWebNotificationIcon = A40WWPWebNotificationIcon;
            Z47WWPWebNotificationClientId = A47WWPWebNotificationClientId;
            Z48WWPWebNotificationStatus = A48WWPWebNotificationStatus;
            Z41WWPWebNotificationCreated = A41WWPWebNotificationCreated;
            Z52WWPWebNotificationScheduled = A52WWPWebNotificationScheduled;
            Z49WWPWebNotificationProcessed = A49WWPWebNotificationProcessed;
            Z42WWPWebNotificationRead = A42WWPWebNotificationRead;
            Z50WWPWebNotificationDetail = A50WWPWebNotificationDetail;
            Z51WWPWebNotificationReceived = A51WWPWebNotificationReceived;
            Z16WWPNotificationId = A16WWPNotificationId;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
            Z54WWPNotificationMetadata = A54WWPNotificationMetadata;
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A48WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A48WWPWebNotificationStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A41WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A52WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load055( )
      {
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
            A14WWPNotificationDefinitionId = BC00056_A14WWPNotificationDefinitionId[0];
            A38WWPWebNotificationTitle = BC00056_A38WWPWebNotificationTitle[0];
            A37WWPNotificationCreated = BC00056_A37WWPNotificationCreated[0];
            A54WWPNotificationMetadata = BC00056_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC00056_n54WWPNotificationMetadata[0];
            A53WWPNotificationDefinitionName = BC00056_A53WWPNotificationDefinitionName[0];
            A39WWPWebNotificationText = BC00056_A39WWPWebNotificationText[0];
            A40WWPWebNotificationIcon = BC00056_A40WWPWebNotificationIcon[0];
            A47WWPWebNotificationClientId = BC00056_A47WWPWebNotificationClientId[0];
            A48WWPWebNotificationStatus = BC00056_A48WWPWebNotificationStatus[0];
            A41WWPWebNotificationCreated = BC00056_A41WWPWebNotificationCreated[0];
            A52WWPWebNotificationScheduled = BC00056_A52WWPWebNotificationScheduled[0];
            A49WWPWebNotificationProcessed = BC00056_A49WWPWebNotificationProcessed[0];
            A42WWPWebNotificationRead = BC00056_A42WWPWebNotificationRead[0];
            n42WWPWebNotificationRead = BC00056_n42WWPWebNotificationRead[0];
            A50WWPWebNotificationDetail = BC00056_A50WWPWebNotificationDetail[0];
            n50WWPWebNotificationDetail = BC00056_n50WWPWebNotificationDetail[0];
            A51WWPWebNotificationReceived = BC00056_A51WWPWebNotificationReceived[0];
            n51WWPWebNotificationReceived = BC00056_n51WWPWebNotificationReceived[0];
            A16WWPNotificationId = BC00056_A16WWPNotificationId[0];
            n16WWPNotificationId = BC00056_n16WWPNotificationId[0];
            ZM055( -9) ;
         }
         pr_default.close(4);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A16WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A14WWPNotificationDefinitionId = BC00054_A14WWPNotificationDefinitionId[0];
         A37WWPNotificationCreated = BC00054_A37WWPNotificationCreated[0];
         A54WWPNotificationMetadata = BC00054_A54WWPNotificationMetadata[0];
         n54WWPNotificationMetadata = BC00054_n54WWPNotificationMetadata[0];
         pr_default.close(2);
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A14WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "");
               AnyError = 1;
            }
         }
         A53WWPNotificationDefinitionName = BC00055_A53WWPNotificationDefinitionName[0];
         pr_default.close(3);
         if ( ! ( ( A48WWPWebNotificationStatus == 1 ) || ( A48WWPWebNotificationStatus == 2 ) || ( A48WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A41WWPWebNotificationCreated) || ( A41WWPWebNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Created fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A52WWPWebNotificationScheduled) || ( A52WWPWebNotificationScheduled >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Scheduled fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A49WWPWebNotificationProcessed) || ( A49WWPWebNotificationProcessed >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Processed fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A42WWPWebNotificationRead) || ( A42WWPWebNotificationRead >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Read fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor BC00057 */
         pr_default.execute(5, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A17WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 9) ;
            RcdFound5 = 1;
            A17WWPWebNotificationId = BC00053_A17WWPWebNotificationId[0];
            A38WWPWebNotificationTitle = BC00053_A38WWPWebNotificationTitle[0];
            A39WWPWebNotificationText = BC00053_A39WWPWebNotificationText[0];
            A40WWPWebNotificationIcon = BC00053_A40WWPWebNotificationIcon[0];
            A47WWPWebNotificationClientId = BC00053_A47WWPWebNotificationClientId[0];
            A48WWPWebNotificationStatus = BC00053_A48WWPWebNotificationStatus[0];
            A41WWPWebNotificationCreated = BC00053_A41WWPWebNotificationCreated[0];
            A52WWPWebNotificationScheduled = BC00053_A52WWPWebNotificationScheduled[0];
            A49WWPWebNotificationProcessed = BC00053_A49WWPWebNotificationProcessed[0];
            A42WWPWebNotificationRead = BC00053_A42WWPWebNotificationRead[0];
            n42WWPWebNotificationRead = BC00053_n42WWPWebNotificationRead[0];
            A50WWPWebNotificationDetail = BC00053_A50WWPWebNotificationDetail[0];
            n50WWPWebNotificationDetail = BC00053_n50WWPWebNotificationDetail[0];
            A51WWPWebNotificationReceived = BC00053_A51WWPWebNotificationReceived[0];
            n51WWPWebNotificationReceived = BC00053_n51WWPWebNotificationReceived[0];
            A16WWPNotificationId = BC00053_A16WWPNotificationId[0];
            n16WWPNotificationId = BC00053_n16WWPNotificationId[0];
            Z17WWPWebNotificationId = A17WWPWebNotificationId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_050( ) ;
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

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A17WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z38WWPWebNotificationTitle, BC00052_A38WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z39WWPWebNotificationText, BC00052_A39WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z40WWPWebNotificationIcon, BC00052_A40WWPWebNotificationIcon[0]) != 0 ) || ( Z48WWPWebNotificationStatus != BC00052_A48WWPWebNotificationStatus[0] ) || ( Z41WWPWebNotificationCreated != BC00052_A41WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z52WWPWebNotificationScheduled != BC00052_A52WWPWebNotificationScheduled[0] ) || ( Z49WWPWebNotificationProcessed != BC00052_A49WWPWebNotificationProcessed[0] ) || ( Z42WWPWebNotificationRead != BC00052_A42WWPWebNotificationRead[0] ) || ( Z51WWPWebNotificationReceived != BC00052_A51WWPWebNotificationReceived[0] ) || ( Z16WWPNotificationId != BC00052_A16WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00058 */
                     pr_default.execute(6, new Object[] {A38WWPWebNotificationTitle, A39WWPWebNotificationText, A40WWPWebNotificationIcon, A47WWPWebNotificationClientId, A48WWPWebNotificationStatus, A41WWPWebNotificationCreated, A52WWPWebNotificationScheduled, A49WWPWebNotificationProcessed, n42WWPWebNotificationRead, A42WWPWebNotificationRead, n50WWPWebNotificationDetail, A50WWPWebNotificationDetail, n51WWPWebNotificationReceived, A51WWPWebNotificationReceived, n16WWPNotificationId, A16WWPNotificationId});
                     A17WWPWebNotificationId = BC00058_A17WWPWebNotificationId[0];
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00059 */
                     pr_default.execute(7, new Object[] {A38WWPWebNotificationTitle, A39WWPWebNotificationText, A40WWPWebNotificationIcon, A47WWPWebNotificationClientId, A48WWPWebNotificationStatus, A41WWPWebNotificationCreated, A52WWPWebNotificationScheduled, A49WWPWebNotificationProcessed, n42WWPWebNotificationRead, A42WWPWebNotificationRead, n50WWPWebNotificationDetail, A50WWPWebNotificationDetail, n51WWPWebNotificationReceived, A51WWPWebNotificationReceived, n16WWPNotificationId, A16WWPNotificationId, A17WWPWebNotificationId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000510 */
                  pr_default.execute(8, new Object[] {A17WWPWebNotificationId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel055( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000511 */
            pr_default.execute(9, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            A14WWPNotificationDefinitionId = BC000511_A14WWPNotificationDefinitionId[0];
            A37WWPNotificationCreated = BC000511_A37WWPNotificationCreated[0];
            A54WWPNotificationMetadata = BC000511_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC000511_n54WWPNotificationMetadata[0];
            pr_default.close(9);
            /* Using cursor BC000512 */
            pr_default.execute(10, new Object[] {A14WWPNotificationDefinitionId});
            A53WWPNotificationDefinitionName = BC000512_A53WWPNotificationDefinitionName[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
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

      public void ScanKeyStart055( )
      {
         /* Using cursor BC000513 */
         pr_default.execute(11, new Object[] {A17WWPWebNotificationId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A14WWPNotificationDefinitionId = BC000513_A14WWPNotificationDefinitionId[0];
            A17WWPWebNotificationId = BC000513_A17WWPWebNotificationId[0];
            A38WWPWebNotificationTitle = BC000513_A38WWPWebNotificationTitle[0];
            A37WWPNotificationCreated = BC000513_A37WWPNotificationCreated[0];
            A54WWPNotificationMetadata = BC000513_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC000513_n54WWPNotificationMetadata[0];
            A53WWPNotificationDefinitionName = BC000513_A53WWPNotificationDefinitionName[0];
            A39WWPWebNotificationText = BC000513_A39WWPWebNotificationText[0];
            A40WWPWebNotificationIcon = BC000513_A40WWPWebNotificationIcon[0];
            A47WWPWebNotificationClientId = BC000513_A47WWPWebNotificationClientId[0];
            A48WWPWebNotificationStatus = BC000513_A48WWPWebNotificationStatus[0];
            A41WWPWebNotificationCreated = BC000513_A41WWPWebNotificationCreated[0];
            A52WWPWebNotificationScheduled = BC000513_A52WWPWebNotificationScheduled[0];
            A49WWPWebNotificationProcessed = BC000513_A49WWPWebNotificationProcessed[0];
            A42WWPWebNotificationRead = BC000513_A42WWPWebNotificationRead[0];
            n42WWPWebNotificationRead = BC000513_n42WWPWebNotificationRead[0];
            A50WWPWebNotificationDetail = BC000513_A50WWPWebNotificationDetail[0];
            n50WWPWebNotificationDetail = BC000513_n50WWPWebNotificationDetail[0];
            A51WWPWebNotificationReceived = BC000513_A51WWPWebNotificationReceived[0];
            n51WWPWebNotificationReceived = BC000513_n51WWPWebNotificationReceived[0];
            A16WWPNotificationId = BC000513_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000513_n16WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound5 = 0;
         ScanKeyLoad055( ) ;
      }

      protected void ScanKeyLoad055( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A14WWPNotificationDefinitionId = BC000513_A14WWPNotificationDefinitionId[0];
            A17WWPWebNotificationId = BC000513_A17WWPWebNotificationId[0];
            A38WWPWebNotificationTitle = BC000513_A38WWPWebNotificationTitle[0];
            A37WWPNotificationCreated = BC000513_A37WWPNotificationCreated[0];
            A54WWPNotificationMetadata = BC000513_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC000513_n54WWPNotificationMetadata[0];
            A53WWPNotificationDefinitionName = BC000513_A53WWPNotificationDefinitionName[0];
            A39WWPWebNotificationText = BC000513_A39WWPWebNotificationText[0];
            A40WWPWebNotificationIcon = BC000513_A40WWPWebNotificationIcon[0];
            A47WWPWebNotificationClientId = BC000513_A47WWPWebNotificationClientId[0];
            A48WWPWebNotificationStatus = BC000513_A48WWPWebNotificationStatus[0];
            A41WWPWebNotificationCreated = BC000513_A41WWPWebNotificationCreated[0];
            A52WWPWebNotificationScheduled = BC000513_A52WWPWebNotificationScheduled[0];
            A49WWPWebNotificationProcessed = BC000513_A49WWPWebNotificationProcessed[0];
            A42WWPWebNotificationRead = BC000513_A42WWPWebNotificationRead[0];
            n42WWPWebNotificationRead = BC000513_n42WWPWebNotificationRead[0];
            A50WWPWebNotificationDetail = BC000513_A50WWPWebNotificationDetail[0];
            n50WWPWebNotificationDetail = BC000513_n50WWPWebNotificationDetail[0];
            A51WWPWebNotificationReceived = BC000513_A51WWPWebNotificationReceived[0];
            n51WWPWebNotificationReceived = BC000513_n51WWPWebNotificationReceived[0];
            A16WWPNotificationId = BC000513_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000513_n16WWPNotificationId[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd055( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void AddRow055( )
      {
         VarsToRow5( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
      }

      protected void ReadRow055( )
      {
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
      }

      protected void InitializeNonKey055( )
      {
         A14WWPNotificationDefinitionId = 0;
         A38WWPWebNotificationTitle = "";
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A54WWPNotificationMetadata = "";
         n54WWPNotificationMetadata = false;
         A53WWPNotificationDefinitionName = "";
         A39WWPWebNotificationText = "";
         A40WWPWebNotificationIcon = "";
         A47WWPWebNotificationClientId = "";
         A49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n42WWPWebNotificationRead = false;
         A50WWPWebNotificationDetail = "";
         n50WWPWebNotificationDetail = false;
         A51WWPWebNotificationReceived = false;
         n51WWPWebNotificationReceived = false;
         A48WWPWebNotificationStatus = 1;
         A41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z38WWPWebNotificationTitle = "";
         Z39WWPWebNotificationText = "";
         Z40WWPWebNotificationIcon = "";
         Z48WWPWebNotificationStatus = 0;
         Z41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z51WWPWebNotificationReceived = false;
         Z16WWPNotificationId = 0;
      }

      protected void InitAll055( )
      {
         A17WWPWebNotificationId = 0;
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A48WWPWebNotificationStatus = i48WWPWebNotificationStatus;
         A41WWPWebNotificationCreated = i41WWPWebNotificationCreated;
         A52WWPWebNotificationScheduled = i52WWPWebNotificationScheduled;
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

      public void VarsToRow5( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Wwpwebnotificationtitle = A38WWPWebNotificationTitle;
         obj5.gxTpr_Wwpnotificationid = A16WWPNotificationId;
         obj5.gxTpr_Wwpnotificationcreated = A37WWPNotificationCreated;
         obj5.gxTpr_Wwpnotificationmetadata = A54WWPNotificationMetadata;
         obj5.gxTpr_Wwpnotificationdefinitionname = A53WWPNotificationDefinitionName;
         obj5.gxTpr_Wwpwebnotificationtext = A39WWPWebNotificationText;
         obj5.gxTpr_Wwpwebnotificationicon = A40WWPWebNotificationIcon;
         obj5.gxTpr_Wwpwebnotificationclientid = A47WWPWebNotificationClientId;
         obj5.gxTpr_Wwpwebnotificationprocessed = A49WWPWebNotificationProcessed;
         obj5.gxTpr_Wwpwebnotificationread = A42WWPWebNotificationRead;
         obj5.gxTpr_Wwpwebnotificationdetail = A50WWPWebNotificationDetail;
         obj5.gxTpr_Wwpwebnotificationreceived = A51WWPWebNotificationReceived;
         obj5.gxTpr_Wwpwebnotificationstatus = A48WWPWebNotificationStatus;
         obj5.gxTpr_Wwpwebnotificationcreated = A41WWPWebNotificationCreated;
         obj5.gxTpr_Wwpwebnotificationscheduled = A52WWPWebNotificationScheduled;
         obj5.gxTpr_Wwpwebnotificationid = A17WWPWebNotificationId;
         obj5.gxTpr_Wwpwebnotificationid_Z = Z17WWPWebNotificationId;
         obj5.gxTpr_Wwpwebnotificationtitle_Z = Z38WWPWebNotificationTitle;
         obj5.gxTpr_Wwpnotificationid_Z = Z16WWPNotificationId;
         obj5.gxTpr_Wwpnotificationcreated_Z = Z37WWPNotificationCreated;
         obj5.gxTpr_Wwpnotificationdefinitionname_Z = Z53WWPNotificationDefinitionName;
         obj5.gxTpr_Wwpwebnotificationtext_Z = Z39WWPWebNotificationText;
         obj5.gxTpr_Wwpwebnotificationicon_Z = Z40WWPWebNotificationIcon;
         obj5.gxTpr_Wwpwebnotificationstatus_Z = Z48WWPWebNotificationStatus;
         obj5.gxTpr_Wwpwebnotificationcreated_Z = Z41WWPWebNotificationCreated;
         obj5.gxTpr_Wwpwebnotificationscheduled_Z = Z52WWPWebNotificationScheduled;
         obj5.gxTpr_Wwpwebnotificationprocessed_Z = Z49WWPWebNotificationProcessed;
         obj5.gxTpr_Wwpwebnotificationread_Z = Z42WWPWebNotificationRead;
         obj5.gxTpr_Wwpwebnotificationreceived_Z = Z51WWPWebNotificationReceived;
         obj5.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n16WWPNotificationId));
         obj5.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n54WWPNotificationMetadata));
         obj5.gxTpr_Wwpwebnotificationread_N = (short)(Convert.ToInt16(n42WWPWebNotificationRead));
         obj5.gxTpr_Wwpwebnotificationdetail_N = (short)(Convert.ToInt16(n50WWPWebNotificationDetail));
         obj5.gxTpr_Wwpwebnotificationreceived_N = (short)(Convert.ToInt16(n51WWPWebNotificationReceived));
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj5 )
      {
         obj5.gxTpr_Wwpwebnotificationid = A17WWPWebNotificationId;
         return  ;
      }

      public void RowToVars5( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A38WWPWebNotificationTitle = obj5.gxTpr_Wwpwebnotificationtitle;
         A16WWPNotificationId = obj5.gxTpr_Wwpnotificationid;
         n16WWPNotificationId = false;
         A37WWPNotificationCreated = obj5.gxTpr_Wwpnotificationcreated;
         A54WWPNotificationMetadata = obj5.gxTpr_Wwpnotificationmetadata;
         n54WWPNotificationMetadata = false;
         A53WWPNotificationDefinitionName = obj5.gxTpr_Wwpnotificationdefinitionname;
         A39WWPWebNotificationText = obj5.gxTpr_Wwpwebnotificationtext;
         A40WWPWebNotificationIcon = obj5.gxTpr_Wwpwebnotificationicon;
         A47WWPWebNotificationClientId = obj5.gxTpr_Wwpwebnotificationclientid;
         A49WWPWebNotificationProcessed = obj5.gxTpr_Wwpwebnotificationprocessed;
         A42WWPWebNotificationRead = obj5.gxTpr_Wwpwebnotificationread;
         n42WWPWebNotificationRead = false;
         A50WWPWebNotificationDetail = obj5.gxTpr_Wwpwebnotificationdetail;
         n50WWPWebNotificationDetail = false;
         A51WWPWebNotificationReceived = obj5.gxTpr_Wwpwebnotificationreceived;
         n51WWPWebNotificationReceived = false;
         A48WWPWebNotificationStatus = obj5.gxTpr_Wwpwebnotificationstatus;
         A41WWPWebNotificationCreated = obj5.gxTpr_Wwpwebnotificationcreated;
         A52WWPWebNotificationScheduled = obj5.gxTpr_Wwpwebnotificationscheduled;
         A17WWPWebNotificationId = obj5.gxTpr_Wwpwebnotificationid;
         Z17WWPWebNotificationId = obj5.gxTpr_Wwpwebnotificationid_Z;
         Z38WWPWebNotificationTitle = obj5.gxTpr_Wwpwebnotificationtitle_Z;
         Z16WWPNotificationId = obj5.gxTpr_Wwpnotificationid_Z;
         Z37WWPNotificationCreated = obj5.gxTpr_Wwpnotificationcreated_Z;
         Z53WWPNotificationDefinitionName = obj5.gxTpr_Wwpnotificationdefinitionname_Z;
         Z39WWPWebNotificationText = obj5.gxTpr_Wwpwebnotificationtext_Z;
         Z40WWPWebNotificationIcon = obj5.gxTpr_Wwpwebnotificationicon_Z;
         Z48WWPWebNotificationStatus = obj5.gxTpr_Wwpwebnotificationstatus_Z;
         Z41WWPWebNotificationCreated = obj5.gxTpr_Wwpwebnotificationcreated_Z;
         Z52WWPWebNotificationScheduled = obj5.gxTpr_Wwpwebnotificationscheduled_Z;
         Z49WWPWebNotificationProcessed = obj5.gxTpr_Wwpwebnotificationprocessed_Z;
         Z42WWPWebNotificationRead = obj5.gxTpr_Wwpwebnotificationread_Z;
         Z51WWPWebNotificationReceived = obj5.gxTpr_Wwpwebnotificationreceived_Z;
         n16WWPNotificationId = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpnotificationid_N));
         n54WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpnotificationmetadata_N));
         n42WWPWebNotificationRead = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpwebnotificationread_N));
         n50WWPWebNotificationDetail = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpwebnotificationdetail_N));
         n51WWPWebNotificationReceived = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpwebnotificationreceived_N));
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A17WWPWebNotificationId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey055( ) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z17WWPWebNotificationId = A17WWPWebNotificationId;
         }
         ZM055( -9) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z17WWPWebNotificationId = A17WWPWebNotificationId;
         }
         ZM055( -9) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert055( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A17WWPWebNotificationId != Z17WWPWebNotificationId )
               {
                  A17WWPWebNotificationId = Z17WWPWebNotificationId;
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
                  Update055( ) ;
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
                  if ( A17WWPWebNotificationId != Z17WWPWebNotificationId )
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
                        Insert055( ) ;
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
                        Insert055( ) ;
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
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A17WWPWebNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebNotification);
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
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         UpdateImpl( ) ;
         VarsToRow5( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
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
         VarsToRow5( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A17WWPWebNotificationId != Z17WWPWebNotificationId )
            {
               A17WWPWebNotificationId = Z17WWPWebNotificationId;
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
            if ( A17WWPWebNotificationId != Z17WWPWebNotificationId )
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
         pr_default.close(9);
         pr_default.close(10);
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification_bc",pr_default);
         VarsToRow5( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebNotification )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebNotification = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
            else
            {
               RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_WebNotification WWP_WebNotification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
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
            return "webnotification_Execute" ;
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
         pr_default.close(9);
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
         Z38WWPWebNotificationTitle = "";
         A38WWPWebNotificationTitle = "";
         Z39WWPWebNotificationText = "";
         A39WWPWebNotificationText = "";
         Z40WWPWebNotificationIcon = "";
         A40WWPWebNotificationIcon = "";
         Z41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A49WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A42WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z53WWPNotificationDefinitionName = "";
         A53WWPNotificationDefinitionName = "";
         Z47WWPWebNotificationClientId = "";
         A47WWPWebNotificationClientId = "";
         Z50WWPWebNotificationDetail = "";
         A50WWPWebNotificationDetail = "";
         Z54WWPNotificationMetadata = "";
         A54WWPNotificationMetadata = "";
         BC00056_A14WWPNotificationDefinitionId = new long[1] ;
         BC00056_A17WWPWebNotificationId = new long[1] ;
         BC00056_A38WWPWebNotificationTitle = new string[] {""} ;
         BC00056_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00056_A54WWPNotificationMetadata = new string[] {""} ;
         BC00056_n54WWPNotificationMetadata = new bool[] {false} ;
         BC00056_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC00056_A39WWPWebNotificationText = new string[] {""} ;
         BC00056_A40WWPWebNotificationIcon = new string[] {""} ;
         BC00056_A47WWPWebNotificationClientId = new string[] {""} ;
         BC00056_A48WWPWebNotificationStatus = new short[1] ;
         BC00056_A41WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00056_A52WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00056_A49WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00056_A42WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC00056_n42WWPWebNotificationRead = new bool[] {false} ;
         BC00056_A50WWPWebNotificationDetail = new string[] {""} ;
         BC00056_n50WWPWebNotificationDetail = new bool[] {false} ;
         BC00056_A51WWPWebNotificationReceived = new bool[] {false} ;
         BC00056_n51WWPWebNotificationReceived = new bool[] {false} ;
         BC00056_A16WWPNotificationId = new long[1] ;
         BC00056_n16WWPNotificationId = new bool[] {false} ;
         BC00054_A14WWPNotificationDefinitionId = new long[1] ;
         BC00054_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00054_A54WWPNotificationMetadata = new string[] {""} ;
         BC00054_n54WWPNotificationMetadata = new bool[] {false} ;
         BC00055_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC00057_A17WWPWebNotificationId = new long[1] ;
         BC00053_A17WWPWebNotificationId = new long[1] ;
         BC00053_A38WWPWebNotificationTitle = new string[] {""} ;
         BC00053_A39WWPWebNotificationText = new string[] {""} ;
         BC00053_A40WWPWebNotificationIcon = new string[] {""} ;
         BC00053_A47WWPWebNotificationClientId = new string[] {""} ;
         BC00053_A48WWPWebNotificationStatus = new short[1] ;
         BC00053_A41WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00053_A52WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00053_A49WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00053_A42WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC00053_n42WWPWebNotificationRead = new bool[] {false} ;
         BC00053_A50WWPWebNotificationDetail = new string[] {""} ;
         BC00053_n50WWPWebNotificationDetail = new bool[] {false} ;
         BC00053_A51WWPWebNotificationReceived = new bool[] {false} ;
         BC00053_n51WWPWebNotificationReceived = new bool[] {false} ;
         BC00053_A16WWPNotificationId = new long[1] ;
         BC00053_n16WWPNotificationId = new bool[] {false} ;
         sMode5 = "";
         BC00052_A17WWPWebNotificationId = new long[1] ;
         BC00052_A38WWPWebNotificationTitle = new string[] {""} ;
         BC00052_A39WWPWebNotificationText = new string[] {""} ;
         BC00052_A40WWPWebNotificationIcon = new string[] {""} ;
         BC00052_A47WWPWebNotificationClientId = new string[] {""} ;
         BC00052_A48WWPWebNotificationStatus = new short[1] ;
         BC00052_A41WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00052_A52WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00052_A49WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00052_A42WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC00052_n42WWPWebNotificationRead = new bool[] {false} ;
         BC00052_A50WWPWebNotificationDetail = new string[] {""} ;
         BC00052_n50WWPWebNotificationDetail = new bool[] {false} ;
         BC00052_A51WWPWebNotificationReceived = new bool[] {false} ;
         BC00052_n51WWPWebNotificationReceived = new bool[] {false} ;
         BC00052_A16WWPNotificationId = new long[1] ;
         BC00052_n16WWPNotificationId = new bool[] {false} ;
         BC00058_A17WWPWebNotificationId = new long[1] ;
         BC000511_A14WWPNotificationDefinitionId = new long[1] ;
         BC000511_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000511_A54WWPNotificationMetadata = new string[] {""} ;
         BC000511_n54WWPNotificationMetadata = new bool[] {false} ;
         BC000512_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC000513_A14WWPNotificationDefinitionId = new long[1] ;
         BC000513_A17WWPWebNotificationId = new long[1] ;
         BC000513_A38WWPWebNotificationTitle = new string[] {""} ;
         BC000513_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000513_A54WWPNotificationMetadata = new string[] {""} ;
         BC000513_n54WWPNotificationMetadata = new bool[] {false} ;
         BC000513_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC000513_A39WWPWebNotificationText = new string[] {""} ;
         BC000513_A40WWPWebNotificationIcon = new string[] {""} ;
         BC000513_A47WWPWebNotificationClientId = new string[] {""} ;
         BC000513_A48WWPWebNotificationStatus = new short[1] ;
         BC000513_A41WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000513_A52WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000513_A49WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000513_A42WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000513_n42WWPWebNotificationRead = new bool[] {false} ;
         BC000513_A50WWPWebNotificationDetail = new string[] {""} ;
         BC000513_n50WWPWebNotificationDetail = new bool[] {false} ;
         BC000513_A51WWPWebNotificationReceived = new bool[] {false} ;
         BC000513_n51WWPWebNotificationReceived = new bool[] {false} ;
         BC000513_A16WWPNotificationId = new long[1] ;
         BC000513_n16WWPNotificationId = new bool[] {false} ;
         i41WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i52WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A17WWPWebNotificationId, BC00052_A38WWPWebNotificationTitle, BC00052_A39WWPWebNotificationText, BC00052_A40WWPWebNotificationIcon, BC00052_A47WWPWebNotificationClientId, BC00052_A48WWPWebNotificationStatus, BC00052_A41WWPWebNotificationCreated, BC00052_A52WWPWebNotificationScheduled, BC00052_A49WWPWebNotificationProcessed, BC00052_A42WWPWebNotificationRead,
               BC00052_n42WWPWebNotificationRead, BC00052_A50WWPWebNotificationDetail, BC00052_n50WWPWebNotificationDetail, BC00052_A51WWPWebNotificationReceived, BC00052_n51WWPWebNotificationReceived, BC00052_A16WWPNotificationId, BC00052_n16WWPNotificationId
               }
               , new Object[] {
               BC00053_A17WWPWebNotificationId, BC00053_A38WWPWebNotificationTitle, BC00053_A39WWPWebNotificationText, BC00053_A40WWPWebNotificationIcon, BC00053_A47WWPWebNotificationClientId, BC00053_A48WWPWebNotificationStatus, BC00053_A41WWPWebNotificationCreated, BC00053_A52WWPWebNotificationScheduled, BC00053_A49WWPWebNotificationProcessed, BC00053_A42WWPWebNotificationRead,
               BC00053_n42WWPWebNotificationRead, BC00053_A50WWPWebNotificationDetail, BC00053_n50WWPWebNotificationDetail, BC00053_A51WWPWebNotificationReceived, BC00053_n51WWPWebNotificationReceived, BC00053_A16WWPNotificationId, BC00053_n16WWPNotificationId
               }
               , new Object[] {
               BC00054_A14WWPNotificationDefinitionId, BC00054_A37WWPNotificationCreated, BC00054_A54WWPNotificationMetadata, BC00054_n54WWPNotificationMetadata
               }
               , new Object[] {
               BC00055_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               BC00056_A14WWPNotificationDefinitionId, BC00056_A17WWPWebNotificationId, BC00056_A38WWPWebNotificationTitle, BC00056_A37WWPNotificationCreated, BC00056_A54WWPNotificationMetadata, BC00056_n54WWPNotificationMetadata, BC00056_A53WWPNotificationDefinitionName, BC00056_A39WWPWebNotificationText, BC00056_A40WWPWebNotificationIcon, BC00056_A47WWPWebNotificationClientId,
               BC00056_A48WWPWebNotificationStatus, BC00056_A41WWPWebNotificationCreated, BC00056_A52WWPWebNotificationScheduled, BC00056_A49WWPWebNotificationProcessed, BC00056_A42WWPWebNotificationRead, BC00056_n42WWPWebNotificationRead, BC00056_A50WWPWebNotificationDetail, BC00056_n50WWPWebNotificationDetail, BC00056_A51WWPWebNotificationReceived, BC00056_n51WWPWebNotificationReceived,
               BC00056_A16WWPNotificationId, BC00056_n16WWPNotificationId
               }
               , new Object[] {
               BC00057_A17WWPWebNotificationId
               }
               , new Object[] {
               BC00058_A17WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000511_A14WWPNotificationDefinitionId, BC000511_A37WWPNotificationCreated, BC000511_A54WWPNotificationMetadata, BC000511_n54WWPNotificationMetadata
               }
               , new Object[] {
               BC000512_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000513_A14WWPNotificationDefinitionId, BC000513_A17WWPWebNotificationId, BC000513_A38WWPWebNotificationTitle, BC000513_A37WWPNotificationCreated, BC000513_A54WWPNotificationMetadata, BC000513_n54WWPNotificationMetadata, BC000513_A53WWPNotificationDefinitionName, BC000513_A39WWPWebNotificationText, BC000513_A40WWPWebNotificationIcon, BC000513_A47WWPWebNotificationClientId,
               BC000513_A48WWPWebNotificationStatus, BC000513_A41WWPWebNotificationCreated, BC000513_A52WWPWebNotificationScheduled, BC000513_A49WWPWebNotificationProcessed, BC000513_A42WWPWebNotificationRead, BC000513_n42WWPWebNotificationRead, BC000513_A50WWPWebNotificationDetail, BC000513_n50WWPWebNotificationDetail, BC000513_A51WWPWebNotificationReceived, BC000513_n51WWPWebNotificationReceived,
               BC000513_A16WWPNotificationId, BC000513_n16WWPNotificationId
               }
            }
         );
         Z52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i52WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i41WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z48WWPWebNotificationStatus = 1;
         A48WWPWebNotificationStatus = 1;
         i48WWPWebNotificationStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z48WWPWebNotificationStatus ;
      private short A48WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private short i48WWPWebNotificationStatus ;
      private int trnEnded ;
      private long Z17WWPWebNotificationId ;
      private long A17WWPWebNotificationId ;
      private long Z16WWPNotificationId ;
      private long A16WWPNotificationId ;
      private long Z14WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode5 ;
      private DateTime Z41WWPWebNotificationCreated ;
      private DateTime A41WWPWebNotificationCreated ;
      private DateTime Z52WWPWebNotificationScheduled ;
      private DateTime A52WWPWebNotificationScheduled ;
      private DateTime Z49WWPWebNotificationProcessed ;
      private DateTime A49WWPWebNotificationProcessed ;
      private DateTime Z42WWPWebNotificationRead ;
      private DateTime A42WWPWebNotificationRead ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime i41WWPWebNotificationCreated ;
      private DateTime i52WWPWebNotificationScheduled ;
      private bool Z51WWPWebNotificationReceived ;
      private bool A51WWPWebNotificationReceived ;
      private bool n54WWPNotificationMetadata ;
      private bool n42WWPWebNotificationRead ;
      private bool n50WWPWebNotificationDetail ;
      private bool n51WWPWebNotificationReceived ;
      private bool n16WWPNotificationId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z47WWPWebNotificationClientId ;
      private string A47WWPWebNotificationClientId ;
      private string Z50WWPWebNotificationDetail ;
      private string A50WWPWebNotificationDetail ;
      private string Z54WWPNotificationMetadata ;
      private string A54WWPNotificationMetadata ;
      private string Z38WWPWebNotificationTitle ;
      private string A38WWPWebNotificationTitle ;
      private string Z39WWPWebNotificationText ;
      private string A39WWPWebNotificationText ;
      private string Z40WWPWebNotificationIcon ;
      private string A40WWPWebNotificationIcon ;
      private string Z53WWPNotificationDefinitionName ;
      private string A53WWPNotificationDefinitionName ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00056_A14WWPNotificationDefinitionId ;
      private long[] BC00056_A17WWPWebNotificationId ;
      private string[] BC00056_A38WWPWebNotificationTitle ;
      private DateTime[] BC00056_A37WWPNotificationCreated ;
      private string[] BC00056_A54WWPNotificationMetadata ;
      private bool[] BC00056_n54WWPNotificationMetadata ;
      private string[] BC00056_A53WWPNotificationDefinitionName ;
      private string[] BC00056_A39WWPWebNotificationText ;
      private string[] BC00056_A40WWPWebNotificationIcon ;
      private string[] BC00056_A47WWPWebNotificationClientId ;
      private short[] BC00056_A48WWPWebNotificationStatus ;
      private DateTime[] BC00056_A41WWPWebNotificationCreated ;
      private DateTime[] BC00056_A52WWPWebNotificationScheduled ;
      private DateTime[] BC00056_A49WWPWebNotificationProcessed ;
      private DateTime[] BC00056_A42WWPWebNotificationRead ;
      private bool[] BC00056_n42WWPWebNotificationRead ;
      private string[] BC00056_A50WWPWebNotificationDetail ;
      private bool[] BC00056_n50WWPWebNotificationDetail ;
      private bool[] BC00056_A51WWPWebNotificationReceived ;
      private bool[] BC00056_n51WWPWebNotificationReceived ;
      private long[] BC00056_A16WWPNotificationId ;
      private bool[] BC00056_n16WWPNotificationId ;
      private long[] BC00054_A14WWPNotificationDefinitionId ;
      private DateTime[] BC00054_A37WWPNotificationCreated ;
      private string[] BC00054_A54WWPNotificationMetadata ;
      private bool[] BC00054_n54WWPNotificationMetadata ;
      private string[] BC00055_A53WWPNotificationDefinitionName ;
      private long[] BC00057_A17WWPWebNotificationId ;
      private long[] BC00053_A17WWPWebNotificationId ;
      private string[] BC00053_A38WWPWebNotificationTitle ;
      private string[] BC00053_A39WWPWebNotificationText ;
      private string[] BC00053_A40WWPWebNotificationIcon ;
      private string[] BC00053_A47WWPWebNotificationClientId ;
      private short[] BC00053_A48WWPWebNotificationStatus ;
      private DateTime[] BC00053_A41WWPWebNotificationCreated ;
      private DateTime[] BC00053_A52WWPWebNotificationScheduled ;
      private DateTime[] BC00053_A49WWPWebNotificationProcessed ;
      private DateTime[] BC00053_A42WWPWebNotificationRead ;
      private bool[] BC00053_n42WWPWebNotificationRead ;
      private string[] BC00053_A50WWPWebNotificationDetail ;
      private bool[] BC00053_n50WWPWebNotificationDetail ;
      private bool[] BC00053_A51WWPWebNotificationReceived ;
      private bool[] BC00053_n51WWPWebNotificationReceived ;
      private long[] BC00053_A16WWPNotificationId ;
      private bool[] BC00053_n16WWPNotificationId ;
      private long[] BC00052_A17WWPWebNotificationId ;
      private string[] BC00052_A38WWPWebNotificationTitle ;
      private string[] BC00052_A39WWPWebNotificationText ;
      private string[] BC00052_A40WWPWebNotificationIcon ;
      private string[] BC00052_A47WWPWebNotificationClientId ;
      private short[] BC00052_A48WWPWebNotificationStatus ;
      private DateTime[] BC00052_A41WWPWebNotificationCreated ;
      private DateTime[] BC00052_A52WWPWebNotificationScheduled ;
      private DateTime[] BC00052_A49WWPWebNotificationProcessed ;
      private DateTime[] BC00052_A42WWPWebNotificationRead ;
      private bool[] BC00052_n42WWPWebNotificationRead ;
      private string[] BC00052_A50WWPWebNotificationDetail ;
      private bool[] BC00052_n50WWPWebNotificationDetail ;
      private bool[] BC00052_A51WWPWebNotificationReceived ;
      private bool[] BC00052_n51WWPWebNotificationReceived ;
      private long[] BC00052_A16WWPNotificationId ;
      private bool[] BC00052_n16WWPNotificationId ;
      private long[] BC00058_A17WWPWebNotificationId ;
      private long[] BC000511_A14WWPNotificationDefinitionId ;
      private DateTime[] BC000511_A37WWPNotificationCreated ;
      private string[] BC000511_A54WWPNotificationMetadata ;
      private bool[] BC000511_n54WWPNotificationMetadata ;
      private string[] BC000512_A53WWPNotificationDefinitionName ;
      private long[] BC000513_A14WWPNotificationDefinitionId ;
      private long[] BC000513_A17WWPWebNotificationId ;
      private string[] BC000513_A38WWPWebNotificationTitle ;
      private DateTime[] BC000513_A37WWPNotificationCreated ;
      private string[] BC000513_A54WWPNotificationMetadata ;
      private bool[] BC000513_n54WWPNotificationMetadata ;
      private string[] BC000513_A53WWPNotificationDefinitionName ;
      private string[] BC000513_A39WWPWebNotificationText ;
      private string[] BC000513_A40WWPWebNotificationIcon ;
      private string[] BC000513_A47WWPWebNotificationClientId ;
      private short[] BC000513_A48WWPWebNotificationStatus ;
      private DateTime[] BC000513_A41WWPWebNotificationCreated ;
      private DateTime[] BC000513_A52WWPWebNotificationScheduled ;
      private DateTime[] BC000513_A49WWPWebNotificationProcessed ;
      private DateTime[] BC000513_A42WWPWebNotificationRead ;
      private bool[] BC000513_n42WWPWebNotificationRead ;
      private string[] BC000513_A50WWPWebNotificationDetail ;
      private bool[] BC000513_n50WWPWebNotificationDetail ;
      private bool[] BC000513_A51WWPWebNotificationReceived ;
      private bool[] BC000513_n51WWPWebNotificationReceived ;
      private long[] BC000513_A16WWPNotificationId ;
      private bool[] BC000513_n16WWPNotificationId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00056;
        prmBC00056 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00054;
        prmBC00054 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00055;
        prmBC00055 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00057;
        prmBC00057 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00053;
        prmBC00053 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00052;
        prmBC00052 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00058;
        prmBC00058 = new Object[] {
        new Object[] {"@WWPWebNotificationTitle",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPWebNotificationText",SqlDbType.NVarChar,120,0} ,
        new Object[] {"@WWPWebNotificationIcon",SqlDbType.NVarChar,255,0} ,
        new Object[] {"@WWPWebNotificationClientId",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationRead",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationReceived",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00059;
        prmBC00059 = new Object[] {
        new Object[] {"@WWPWebNotificationTitle",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@WWPWebNotificationText",SqlDbType.NVarChar,120,0} ,
        new Object[] {"@WWPWebNotificationIcon",SqlDbType.NVarChar,255,0} ,
        new Object[] {"@WWPWebNotificationClientId",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationStatus",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationScheduled",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationProcessed",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationRead",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebNotificationDetail",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebNotificationReceived",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000510;
        prmBC000510 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000511;
        prmBC000511 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000512;
        prmBC000512 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000513;
        prmBC000513 = new Object[] {
        new Object[] {"@WWPWebNotificationId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00052", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WITH (UPDLOCK) WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00053", "SELECT [WWPWebNotificationId], [WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00054", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00055", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00056", "SELECT T2.[WWPNotificationDefinitionId], TM1.[WWPWebNotificationId], TM1.[WWPWebNotificationTitle], T2.[WWPNotificationCreated], T2.[WWPNotificationMetadata], T3.[WWPNotificationDefinitionName], TM1.[WWPWebNotificationText], TM1.[WWPWebNotificationIcon], TM1.[WWPWebNotificationClientId], TM1.[WWPWebNotificationStatus], TM1.[WWPWebNotificationCreated], TM1.[WWPWebNotificationScheduled], TM1.[WWPWebNotificationProcessed], TM1.[WWPWebNotificationRead], TM1.[WWPWebNotificationDetail], TM1.[WWPWebNotificationReceived], TM1.[WWPNotificationId] FROM (([WWP_WebNotification] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) LEFT JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE TM1.[WWPWebNotificationId] = @WWPWebNotificationId ORDER BY TM1.[WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00057", "SELECT [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPWebNotificationId] = @WWPWebNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00058", "INSERT INTO [WWP_WebNotification]([WWPWebNotificationTitle], [WWPWebNotificationText], [WWPWebNotificationIcon], [WWPWebNotificationClientId], [WWPWebNotificationStatus], [WWPWebNotificationCreated], [WWPWebNotificationScheduled], [WWPWebNotificationProcessed], [WWPWebNotificationRead], [WWPWebNotificationDetail], [WWPWebNotificationReceived], [WWPNotificationId]) VALUES(@WWPWebNotificationTitle, @WWPWebNotificationText, @WWPWebNotificationIcon, @WWPWebNotificationClientId, @WWPWebNotificationStatus, @WWPWebNotificationCreated, @WWPWebNotificationScheduled, @WWPWebNotificationProcessed, @WWPWebNotificationRead, @WWPWebNotificationDetail, @WWPWebNotificationReceived, @WWPNotificationId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC00058)
           ,new CursorDef("BC00059", "UPDATE [WWP_WebNotification] SET [WWPWebNotificationTitle]=@WWPWebNotificationTitle, [WWPWebNotificationText]=@WWPWebNotificationText, [WWPWebNotificationIcon]=@WWPWebNotificationIcon, [WWPWebNotificationClientId]=@WWPWebNotificationClientId, [WWPWebNotificationStatus]=@WWPWebNotificationStatus, [WWPWebNotificationCreated]=@WWPWebNotificationCreated, [WWPWebNotificationScheduled]=@WWPWebNotificationScheduled, [WWPWebNotificationProcessed]=@WWPWebNotificationProcessed, [WWPWebNotificationRead]=@WWPWebNotificationRead, [WWPWebNotificationDetail]=@WWPWebNotificationDetail, [WWPWebNotificationReceived]=@WWPWebNotificationReceived, [WWPNotificationId]=@WWPNotificationId  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmBC00059)
           ,new CursorDef("BC000510", "DELETE FROM [WWP_WebNotification]  WHERE [WWPWebNotificationId] = @WWPWebNotificationId", GxErrorMask.GX_NOMASK,prmBC000510)
           ,new CursorDef("BC000511", "SELECT [WWPNotificationDefinitionId], [WWPNotificationCreated], [WWPNotificationMetadata] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000511,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000512", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000512,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000513", "SELECT T2.[WWPNotificationDefinitionId], TM1.[WWPWebNotificationId], TM1.[WWPWebNotificationTitle], T2.[WWPNotificationCreated], T2.[WWPNotificationMetadata], T3.[WWPNotificationDefinitionName], TM1.[WWPWebNotificationText], TM1.[WWPWebNotificationIcon], TM1.[WWPWebNotificationClientId], TM1.[WWPWebNotificationStatus], TM1.[WWPWebNotificationCreated], TM1.[WWPWebNotificationScheduled], TM1.[WWPWebNotificationProcessed], TM1.[WWPWebNotificationRead], TM1.[WWPWebNotificationDetail], TM1.[WWPWebNotificationReceived], TM1.[WWPNotificationId] FROM (([WWP_WebNotification] TM1 LEFT JOIN [WWP_Notification] T2 ON T2.[WWPNotificationId] = TM1.[WWPNotificationId]) LEFT JOIN [WWP_NotificationDefinition] T3 ON T3.[WWPNotificationDefinitionId] = T2.[WWPNotificationDefinitionId]) WHERE TM1.[WWPWebNotificationId] = @WWPWebNotificationId ORDER BY TM1.[WWPWebNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000513,100, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.getGXDateTime(9, true);
              table[9][0] = rslt.getGXDateTime(10, true);
              table[10][0] = rslt.wasNull(10);
              table[11][0] = rslt.getLongVarchar(11);
              table[12][0] = rslt.wasNull(11);
              table[13][0] = rslt.getBool(12);
              table[14][0] = rslt.wasNull(12);
              table[15][0] = rslt.getLong(13);
              table[16][0] = rslt.wasNull(13);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getGXDateTime(7, true);
              table[7][0] = rslt.getGXDateTime(8, true);
              table[8][0] = rslt.getGXDateTime(9, true);
              table[9][0] = rslt.getGXDateTime(10, true);
              table[10][0] = rslt.wasNull(10);
              table[11][0] = rslt.getLongVarchar(11);
              table[12][0] = rslt.wasNull(11);
              table[13][0] = rslt.getBool(12);
              table[14][0] = rslt.wasNull(12);
              table[15][0] = rslt.getLong(13);
              table[16][0] = rslt.wasNull(13);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.wasNull(3);
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.wasNull(5);
              table[6][0] = rslt.getVarchar(6);
              table[7][0] = rslt.getVarchar(7);
              table[8][0] = rslt.getVarchar(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.getShort(10);
              table[11][0] = rslt.getGXDateTime(11, true);
              table[12][0] = rslt.getGXDateTime(12, true);
              table[13][0] = rslt.getGXDateTime(13, true);
              table[14][0] = rslt.getGXDateTime(14, true);
              table[15][0] = rslt.wasNull(14);
              table[16][0] = rslt.getLongVarchar(15);
              table[17][0] = rslt.wasNull(15);
              table[18][0] = rslt.getBool(16);
              table[19][0] = rslt.wasNull(16);
              table[20][0] = rslt.getLong(17);
              table[21][0] = rslt.wasNull(17);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.wasNull(3);
              return;
           case 10 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 11 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getLongVarchar(5);
              table[5][0] = rslt.wasNull(5);
              table[6][0] = rslt.getVarchar(6);
              table[7][0] = rslt.getVarchar(7);
              table[8][0] = rslt.getVarchar(8);
              table[9][0] = rslt.getLongVarchar(9);
              table[10][0] = rslt.getShort(10);
              table[11][0] = rslt.getGXDateTime(11, true);
              table[12][0] = rslt.getGXDateTime(12, true);
              table[13][0] = rslt.getGXDateTime(13, true);
              table[14][0] = rslt.getGXDateTime(14, true);
              table[15][0] = rslt.wasNull(14);
              table[16][0] = rslt.getLongVarchar(15);
              table[17][0] = rslt.wasNull(15);
              table[18][0] = rslt.getBool(16);
              table[19][0] = rslt.wasNull(16);
              table[20][0] = rslt.getLong(17);
              table[21][0] = rslt.wasNull(17);
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              stmt.SetParameterDatetime(7, (DateTime)parms[6], true);
              stmt.SetParameterDatetime(8, (DateTime)parms[7], true);
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 9 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(9, (DateTime)parms[9], true);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 10 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(10, (string)parms[11]);
              }
              if ( (bool)parms[12] )
              {
                 stmt.setNull( 11 , SqlDbType.Bit );
              }
              else
              {
                 stmt.SetParameter(11, (bool)parms[13]);
              }
              if ( (bool)parms[14] )
              {
                 stmt.setNull( 12 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(12, (long)parms[15]);
              }
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameterDatetime(6, (DateTime)parms[5], true);
              stmt.SetParameterDatetime(7, (DateTime)parms[6], true);
              stmt.SetParameterDatetime(8, (DateTime)parms[7], true);
              if ( (bool)parms[8] )
              {
                 stmt.setNull( 9 , SqlDbType.DateTime2 );
              }
              else
              {
                 stmt.SetParameterDatetime(9, (DateTime)parms[9], true);
              }
              if ( (bool)parms[10] )
              {
                 stmt.setNull( 10 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(10, (string)parms[11]);
              }
              if ( (bool)parms[12] )
              {
                 stmt.setNull( 11 , SqlDbType.Bit );
              }
              else
              {
                 stmt.SetParameter(11, (bool)parms[13]);
              }
              if ( (bool)parms[14] )
              {
                 stmt.setNull( 12 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(12, (long)parms[15]);
              }
              stmt.SetParameter(13, (long)parms[16]);
              return;
           case 8 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 9 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 10 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
