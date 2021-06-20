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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_subscription_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_subscription_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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
               Z13WWPSubscriptionId = A13WWPSubscriptionId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
                  ZM033( 4) ;
                  ZM033( 5) ;
                  ZM033( 6) ;
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z22WWPSubscriptionEntityRecordId = A22WWPSubscriptionEntityRecordId;
            Z24WWPSubscriptionEntityRecordDescription = A24WWPSubscriptionEntityRecordDescription;
            Z11WWPSubscriptionRoleId = A11WWPSubscriptionRoleId;
            Z23WWPSubscriptionSubscribed = A23WWPSubscriptionSubscribed;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z10WWPEntityId = A10WWPEntityId;
            Z25WWPNotificationDefinitionDescription = A25WWPNotificationDefinitionDescription;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z12WWPEntityName = A12WWPEntityName;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( GX_JID == -3 )
         {
            Z13WWPSubscriptionId = A13WWPSubscriptionId;
            Z22WWPSubscriptionEntityRecordId = A22WWPSubscriptionEntityRecordId;
            Z24WWPSubscriptionEntityRecordDescription = A24WWPSubscriptionEntityRecordDescription;
            Z11WWPSubscriptionRoleId = A11WWPSubscriptionRoleId;
            Z23WWPSubscriptionSubscribed = A23WWPSubscriptionSubscribed;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z10WWPEntityId = A10WWPEntityId;
            Z25WWPNotificationDefinitionDescription = A25WWPNotificationDefinitionDescription;
            Z12WWPEntityName = A12WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00037 */
         pr_default.execute(5, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
            A10WWPEntityId = BC00037_A10WWPEntityId[0];
            A25WWPNotificationDefinitionDescription = BC00037_A25WWPNotificationDefinitionDescription[0];
            A12WWPEntityName = BC00037_A12WWPEntityName[0];
            A22WWPSubscriptionEntityRecordId = BC00037_A22WWPSubscriptionEntityRecordId[0];
            A24WWPSubscriptionEntityRecordDescription = BC00037_A24WWPSubscriptionEntityRecordDescription[0];
            A11WWPSubscriptionRoleId = BC00037_A11WWPSubscriptionRoleId[0];
            n11WWPSubscriptionRoleId = BC00037_n11WWPSubscriptionRoleId[0];
            A23WWPSubscriptionSubscribed = BC00037_A23WWPSubscriptionSubscribed[0];
            A14WWPNotificationDefinitionId = BC00037_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC00037_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00037_n1WWPUserExtendedId[0];
            ZM033( -3) ;
         }
         pr_default.close(5);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A10WWPEntityId = BC00034_A10WWPEntityId[0];
         A25WWPNotificationDefinitionDescription = BC00034_A25WWPNotificationDefinitionDescription[0];
         pr_default.close(2);
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "");
            AnyError = 1;
         }
         A12WWPEntityName = BC00036_A12WWPEntityName[0];
         pr_default.close(4);
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         nIsDirty_3 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00038 */
         pr_default.execute(6, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A13WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 3) ;
            RcdFound3 = 1;
            A13WWPSubscriptionId = BC00033_A13WWPSubscriptionId[0];
            A22WWPSubscriptionEntityRecordId = BC00033_A22WWPSubscriptionEntityRecordId[0];
            A24WWPSubscriptionEntityRecordDescription = BC00033_A24WWPSubscriptionEntityRecordDescription[0];
            A11WWPSubscriptionRoleId = BC00033_A11WWPSubscriptionRoleId[0];
            n11WWPSubscriptionRoleId = BC00033_n11WWPSubscriptionRoleId[0];
            A23WWPSubscriptionSubscribed = BC00033_A23WWPSubscriptionSubscribed[0];
            A14WWPNotificationDefinitionId = BC00033_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC00033_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00033_n1WWPUserExtendedId[0];
            Z13WWPSubscriptionId = A13WWPSubscriptionId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
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

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A13WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z22WWPSubscriptionEntityRecordId, BC00032_A22WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z24WWPSubscriptionEntityRecordDescription, BC00032_A24WWPSubscriptionEntityRecordDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z11WWPSubscriptionRoleId, BC00032_A11WWPSubscriptionRoleId[0]) != 0 ) || ( Z23WWPSubscriptionSubscribed != BC00032_A23WWPSubscriptionSubscribed[0] ) || ( Z14WWPNotificationDefinitionId != BC00032_A14WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC00032_A1WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00039 */
                     pr_default.execute(7, new Object[] {A22WWPSubscriptionEntityRecordId, A24WWPSubscriptionEntityRecordDescription, n11WWPSubscriptionRoleId, A11WWPSubscriptionRoleId, A23WWPSubscriptionSubscribed, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A13WWPSubscriptionId = BC00039_A13WWPSubscriptionId[0];
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000310 */
                     pr_default.execute(8, new Object[] {A22WWPSubscriptionEntityRecordId, A24WWPSubscriptionEntityRecordDescription, n11WWPSubscriptionRoleId, A11WWPSubscriptionRoleId, A23WWPSubscriptionSubscribed, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, A13WWPSubscriptionId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000311 */
                  pr_default.execute(9, new Object[] {A13WWPSubscriptionId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_Subscription");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000312 */
            pr_default.execute(10, new Object[] {A14WWPNotificationDefinitionId});
            A10WWPEntityId = BC000312_A10WWPEntityId[0];
            A25WWPNotificationDefinitionDescription = BC000312_A25WWPNotificationDefinitionDescription[0];
            pr_default.close(10);
            /* Using cursor BC000313 */
            pr_default.execute(11, new Object[] {A10WWPEntityId});
            A12WWPEntityName = BC000313_A12WWPEntityName[0];
            pr_default.close(11);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Using cursor BC000314 */
         pr_default.execute(12, new Object[] {A13WWPSubscriptionId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A10WWPEntityId = BC000314_A10WWPEntityId[0];
            A13WWPSubscriptionId = BC000314_A13WWPSubscriptionId[0];
            A25WWPNotificationDefinitionDescription = BC000314_A25WWPNotificationDefinitionDescription[0];
            A12WWPEntityName = BC000314_A12WWPEntityName[0];
            A22WWPSubscriptionEntityRecordId = BC000314_A22WWPSubscriptionEntityRecordId[0];
            A24WWPSubscriptionEntityRecordDescription = BC000314_A24WWPSubscriptionEntityRecordDescription[0];
            A11WWPSubscriptionRoleId = BC000314_A11WWPSubscriptionRoleId[0];
            n11WWPSubscriptionRoleId = BC000314_n11WWPSubscriptionRoleId[0];
            A23WWPSubscriptionSubscribed = BC000314_A23WWPSubscriptionSubscribed[0];
            A14WWPNotificationDefinitionId = BC000314_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000314_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000314_n1WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A10WWPEntityId = BC000314_A10WWPEntityId[0];
            A13WWPSubscriptionId = BC000314_A13WWPSubscriptionId[0];
            A25WWPNotificationDefinitionDescription = BC000314_A25WWPNotificationDefinitionDescription[0];
            A12WWPEntityName = BC000314_A12WWPEntityName[0];
            A22WWPSubscriptionEntityRecordId = BC000314_A22WWPSubscriptionEntityRecordId[0];
            A24WWPSubscriptionEntityRecordDescription = BC000314_A24WWPSubscriptionEntityRecordDescription[0];
            A11WWPSubscriptionRoleId = BC000314_A11WWPSubscriptionRoleId[0];
            n11WWPSubscriptionRoleId = BC000314_n11WWPSubscriptionRoleId[0];
            A23WWPSubscriptionSubscribed = BC000314_A23WWPSubscriptionSubscribed[0];
            A14WWPNotificationDefinitionId = BC000314_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000314_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000314_n1WWPUserExtendedId[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) )
         {
            A1WWPUserExtendedId = "";
            n1WWPUserExtendedId = false;
            n1WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A10WWPEntityId = 0;
         A2WWPUserExtendedFullName = "";
         A14WWPNotificationDefinitionId = 0;
         A25WWPNotificationDefinitionDescription = "";
         A12WWPEntityName = "";
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         A22WWPSubscriptionEntityRecordId = "";
         A24WWPSubscriptionEntityRecordDescription = "";
         A11WWPSubscriptionRoleId = "";
         n11WWPSubscriptionRoleId = false;
         A23WWPSubscriptionSubscribed = false;
         Z22WWPSubscriptionEntityRecordId = "";
         Z24WWPSubscriptionEntityRecordDescription = "";
         Z11WWPSubscriptionRoleId = "";
         Z23WWPSubscriptionSubscribed = false;
         Z14WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll033( )
      {
         A13WWPSubscriptionId = 0;
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
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

      public void VarsToRow3( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Wwpuserextendedfullname = A2WWPUserExtendedFullName;
         obj3.gxTpr_Wwpnotificationdefinitionid = A14WWPNotificationDefinitionId;
         obj3.gxTpr_Wwpnotificationdefinitiondescription = A25WWPNotificationDefinitionDescription;
         obj3.gxTpr_Wwpentityname = A12WWPEntityName;
         obj3.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj3.gxTpr_Wwpsubscriptionentityrecordid = A22WWPSubscriptionEntityRecordId;
         obj3.gxTpr_Wwpsubscriptionentityrecorddescription = A24WWPSubscriptionEntityRecordDescription;
         obj3.gxTpr_Wwpsubscriptionroleid = A11WWPSubscriptionRoleId;
         obj3.gxTpr_Wwpsubscriptionsubscribed = A23WWPSubscriptionSubscribed;
         obj3.gxTpr_Wwpsubscriptionid = A13WWPSubscriptionId;
         obj3.gxTpr_Wwpsubscriptionid_Z = Z13WWPSubscriptionId;
         obj3.gxTpr_Wwpnotificationdefinitionid_Z = Z14WWPNotificationDefinitionId;
         obj3.gxTpr_Wwpnotificationdefinitiondescription_Z = Z25WWPNotificationDefinitionDescription;
         obj3.gxTpr_Wwpentityname_Z = Z12WWPEntityName;
         obj3.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj3.gxTpr_Wwpuserextendedfullname_Z = Z2WWPUserExtendedFullName;
         obj3.gxTpr_Wwpsubscriptionentityrecordid_Z = Z22WWPSubscriptionEntityRecordId;
         obj3.gxTpr_Wwpsubscriptionentityrecorddescription_Z = Z24WWPSubscriptionEntityRecordDescription;
         obj3.gxTpr_Wwpsubscriptionroleid_Z = Z11WWPSubscriptionRoleId;
         obj3.gxTpr_Wwpsubscriptionsubscribed_Z = Z23WWPSubscriptionSubscribed;
         obj3.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n1WWPUserExtendedId));
         obj3.gxTpr_Wwpsubscriptionroleid_N = (short)(Convert.ToInt16(n11WWPSubscriptionRoleId));
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj3 )
      {
         obj3.gxTpr_Wwpsubscriptionid = A13WWPSubscriptionId;
         return  ;
      }

      public void RowToVars3( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A2WWPUserExtendedFullName = obj3.gxTpr_Wwpuserextendedfullname;
         A14WWPNotificationDefinitionId = obj3.gxTpr_Wwpnotificationdefinitionid;
         A25WWPNotificationDefinitionDescription = obj3.gxTpr_Wwpnotificationdefinitiondescription;
         A12WWPEntityName = obj3.gxTpr_Wwpentityname;
         A1WWPUserExtendedId = obj3.gxTpr_Wwpuserextendedid;
         n1WWPUserExtendedId = false;
         A22WWPSubscriptionEntityRecordId = obj3.gxTpr_Wwpsubscriptionentityrecordid;
         A24WWPSubscriptionEntityRecordDescription = obj3.gxTpr_Wwpsubscriptionentityrecorddescription;
         A11WWPSubscriptionRoleId = obj3.gxTpr_Wwpsubscriptionroleid;
         n11WWPSubscriptionRoleId = false;
         A23WWPSubscriptionSubscribed = obj3.gxTpr_Wwpsubscriptionsubscribed;
         A13WWPSubscriptionId = obj3.gxTpr_Wwpsubscriptionid;
         Z13WWPSubscriptionId = obj3.gxTpr_Wwpsubscriptionid_Z;
         Z14WWPNotificationDefinitionId = obj3.gxTpr_Wwpnotificationdefinitionid_Z;
         Z25WWPNotificationDefinitionDescription = obj3.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z12WWPEntityName = obj3.gxTpr_Wwpentityname_Z;
         Z1WWPUserExtendedId = obj3.gxTpr_Wwpuserextendedid_Z;
         Z2WWPUserExtendedFullName = obj3.gxTpr_Wwpuserextendedfullname_Z;
         Z22WWPSubscriptionEntityRecordId = obj3.gxTpr_Wwpsubscriptionentityrecordid_Z;
         Z24WWPSubscriptionEntityRecordDescription = obj3.gxTpr_Wwpsubscriptionentityrecorddescription_Z;
         Z11WWPSubscriptionRoleId = obj3.gxTpr_Wwpsubscriptionroleid_Z;
         Z23WWPSubscriptionSubscribed = obj3.gxTpr_Wwpsubscriptionsubscribed_Z;
         n1WWPUserExtendedId = (bool)(Convert.ToBoolean(obj3.gxTpr_Wwpuserextendedid_N));
         n11WWPSubscriptionRoleId = (bool)(Convert.ToBoolean(obj3.gxTpr_Wwpsubscriptionroleid_N));
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A13WWPSubscriptionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13WWPSubscriptionId = A13WWPSubscriptionId;
         }
         ZM033( -3) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13WWPSubscriptionId = A13WWPSubscriptionId;
         }
         ZM033( -3) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A13WWPSubscriptionId != Z13WWPSubscriptionId )
               {
                  A13WWPSubscriptionId = Z13WWPSubscriptionId;
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
                  Update033( ) ;
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
                  if ( A13WWPSubscriptionId != Z13WWPSubscriptionId )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
            GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription auxBC = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A13WWPSubscriptionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_subscriptions_WWP_Subscription);
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
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         UpdateImpl( ) ;
         VarsToRow3( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
         VarsToRow3( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A13WWPSubscriptionId != Z13WWPSubscriptionId )
            {
               A13WWPSubscriptionId = Z13WWPSubscriptionId;
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
            if ( A13WWPSubscriptionId != Z13WWPSubscriptionId )
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
         pr_default.close(10);
         pr_default.close(11);
         context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription_bc",pr_default);
         VarsToRow3( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         Gx_mode = bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_subscriptions_WWP_Subscription )
         {
            bcwwpbaseobjects_subscriptions_WWP_Subscription = (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
            else
            {
               RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Subscription WWP_Subscription_BC
      {
         get {
            return bcwwpbaseobjects_subscriptions_WWP_Subscription ;
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
            return "wwpsubscription_Execute" ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z22WWPSubscriptionEntityRecordId = "";
         A22WWPSubscriptionEntityRecordId = "";
         Z24WWPSubscriptionEntityRecordDescription = "";
         A24WWPSubscriptionEntityRecordDescription = "";
         Z11WWPSubscriptionRoleId = "";
         A11WWPSubscriptionRoleId = "";
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z2WWPUserExtendedFullName = "";
         A2WWPUserExtendedFullName = "";
         Z25WWPNotificationDefinitionDescription = "";
         A25WWPNotificationDefinitionDescription = "";
         Z12WWPEntityName = "";
         A12WWPEntityName = "";
         BC00037_A10WWPEntityId = new long[1] ;
         BC00037_A13WWPSubscriptionId = new long[1] ;
         BC00037_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC00037_A12WWPEntityName = new string[] {""} ;
         BC00037_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00037_A24WWPSubscriptionEntityRecordDescription = new string[] {""} ;
         BC00037_A11WWPSubscriptionRoleId = new string[] {""} ;
         BC00037_n11WWPSubscriptionRoleId = new bool[] {false} ;
         BC00037_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00037_A14WWPNotificationDefinitionId = new long[1] ;
         BC00037_A1WWPUserExtendedId = new string[] {""} ;
         BC00037_n1WWPUserExtendedId = new bool[] {false} ;
         BC00034_A10WWPEntityId = new long[1] ;
         BC00034_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC00036_A12WWPEntityName = new string[] {""} ;
         BC00035_A1WWPUserExtendedId = new string[] {""} ;
         BC00035_n1WWPUserExtendedId = new bool[] {false} ;
         BC00038_A13WWPSubscriptionId = new long[1] ;
         BC00033_A13WWPSubscriptionId = new long[1] ;
         BC00033_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00033_A24WWPSubscriptionEntityRecordDescription = new string[] {""} ;
         BC00033_A11WWPSubscriptionRoleId = new string[] {""} ;
         BC00033_n11WWPSubscriptionRoleId = new bool[] {false} ;
         BC00033_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00033_A14WWPNotificationDefinitionId = new long[1] ;
         BC00033_A1WWPUserExtendedId = new string[] {""} ;
         BC00033_n1WWPUserExtendedId = new bool[] {false} ;
         sMode3 = "";
         BC00032_A13WWPSubscriptionId = new long[1] ;
         BC00032_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00032_A24WWPSubscriptionEntityRecordDescription = new string[] {""} ;
         BC00032_A11WWPSubscriptionRoleId = new string[] {""} ;
         BC00032_n11WWPSubscriptionRoleId = new bool[] {false} ;
         BC00032_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00032_A14WWPNotificationDefinitionId = new long[1] ;
         BC00032_A1WWPUserExtendedId = new string[] {""} ;
         BC00032_n1WWPUserExtendedId = new bool[] {false} ;
         BC00039_A13WWPSubscriptionId = new long[1] ;
         BC000312_A10WWPEntityId = new long[1] ;
         BC000312_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC000313_A12WWPEntityName = new string[] {""} ;
         GXt_char1 = "";
         BC000314_A10WWPEntityId = new long[1] ;
         BC000314_A13WWPSubscriptionId = new long[1] ;
         BC000314_A25WWPNotificationDefinitionDescription = new string[] {""} ;
         BC000314_A12WWPEntityName = new string[] {""} ;
         BC000314_A22WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000314_A24WWPSubscriptionEntityRecordDescription = new string[] {""} ;
         BC000314_A11WWPSubscriptionRoleId = new string[] {""} ;
         BC000314_n11WWPSubscriptionRoleId = new bool[] {false} ;
         BC000314_A23WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000314_A14WWPNotificationDefinitionId = new long[1] ;
         BC000314_A1WWPUserExtendedId = new string[] {""} ;
         BC000314_n1WWPUserExtendedId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A13WWPSubscriptionId, BC00032_A22WWPSubscriptionEntityRecordId, BC00032_A24WWPSubscriptionEntityRecordDescription, BC00032_A11WWPSubscriptionRoleId, BC00032_n11WWPSubscriptionRoleId, BC00032_A23WWPSubscriptionSubscribed, BC00032_A14WWPNotificationDefinitionId, BC00032_A1WWPUserExtendedId, BC00032_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00033_A13WWPSubscriptionId, BC00033_A22WWPSubscriptionEntityRecordId, BC00033_A24WWPSubscriptionEntityRecordDescription, BC00033_A11WWPSubscriptionRoleId, BC00033_n11WWPSubscriptionRoleId, BC00033_A23WWPSubscriptionSubscribed, BC00033_A14WWPNotificationDefinitionId, BC00033_A1WWPUserExtendedId, BC00033_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00034_A10WWPEntityId, BC00034_A25WWPNotificationDefinitionDescription
               }
               , new Object[] {
               BC00035_A1WWPUserExtendedId
               }
               , new Object[] {
               BC00036_A12WWPEntityName
               }
               , new Object[] {
               BC00037_A10WWPEntityId, BC00037_A13WWPSubscriptionId, BC00037_A25WWPNotificationDefinitionDescription, BC00037_A12WWPEntityName, BC00037_A22WWPSubscriptionEntityRecordId, BC00037_A24WWPSubscriptionEntityRecordDescription, BC00037_A11WWPSubscriptionRoleId, BC00037_n11WWPSubscriptionRoleId, BC00037_A23WWPSubscriptionSubscribed, BC00037_A14WWPNotificationDefinitionId,
               BC00037_A1WWPUserExtendedId, BC00037_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00038_A13WWPSubscriptionId
               }
               , new Object[] {
               BC00039_A13WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000312_A10WWPEntityId, BC000312_A25WWPNotificationDefinitionDescription
               }
               , new Object[] {
               BC000313_A12WWPEntityName
               }
               , new Object[] {
               BC000314_A10WWPEntityId, BC000314_A13WWPSubscriptionId, BC000314_A25WWPNotificationDefinitionDescription, BC000314_A12WWPEntityName, BC000314_A22WWPSubscriptionEntityRecordId, BC000314_A24WWPSubscriptionEntityRecordDescription, BC000314_A11WWPSubscriptionRoleId, BC000314_n11WWPSubscriptionRoleId, BC000314_A23WWPSubscriptionSubscribed, BC000314_A14WWPNotificationDefinitionId,
               BC000314_A1WWPUserExtendedId, BC000314_n1WWPUserExtendedId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private int trnEnded ;
      private long Z13WWPSubscriptionId ;
      private long A13WWPSubscriptionId ;
      private long Z14WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private long Z10WWPEntityId ;
      private long A10WWPEntityId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z11WWPSubscriptionRoleId ;
      private string A11WWPSubscriptionRoleId ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string sMode3 ;
      private string GXt_char1 ;
      private bool Z23WWPSubscriptionSubscribed ;
      private bool A23WWPSubscriptionSubscribed ;
      private bool n11WWPSubscriptionRoleId ;
      private bool n1WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z22WWPSubscriptionEntityRecordId ;
      private string A22WWPSubscriptionEntityRecordId ;
      private string Z24WWPSubscriptionEntityRecordDescription ;
      private string A24WWPSubscriptionEntityRecordDescription ;
      private string Z2WWPUserExtendedFullName ;
      private string A2WWPUserExtendedFullName ;
      private string Z25WWPNotificationDefinitionDescription ;
      private string A25WWPNotificationDefinitionDescription ;
      private string Z12WWPEntityName ;
      private string A12WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription bcwwpbaseobjects_subscriptions_WWP_Subscription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00037_A10WWPEntityId ;
      private long[] BC00037_A13WWPSubscriptionId ;
      private string[] BC00037_A25WWPNotificationDefinitionDescription ;
      private string[] BC00037_A12WWPEntityName ;
      private string[] BC00037_A22WWPSubscriptionEntityRecordId ;
      private string[] BC00037_A24WWPSubscriptionEntityRecordDescription ;
      private string[] BC00037_A11WWPSubscriptionRoleId ;
      private bool[] BC00037_n11WWPSubscriptionRoleId ;
      private bool[] BC00037_A23WWPSubscriptionSubscribed ;
      private long[] BC00037_A14WWPNotificationDefinitionId ;
      private string[] BC00037_A1WWPUserExtendedId ;
      private bool[] BC00037_n1WWPUserExtendedId ;
      private long[] BC00034_A10WWPEntityId ;
      private string[] BC00034_A25WWPNotificationDefinitionDescription ;
      private string[] BC00036_A12WWPEntityName ;
      private string[] BC00035_A1WWPUserExtendedId ;
      private bool[] BC00035_n1WWPUserExtendedId ;
      private long[] BC00038_A13WWPSubscriptionId ;
      private long[] BC00033_A13WWPSubscriptionId ;
      private string[] BC00033_A22WWPSubscriptionEntityRecordId ;
      private string[] BC00033_A24WWPSubscriptionEntityRecordDescription ;
      private string[] BC00033_A11WWPSubscriptionRoleId ;
      private bool[] BC00033_n11WWPSubscriptionRoleId ;
      private bool[] BC00033_A23WWPSubscriptionSubscribed ;
      private long[] BC00033_A14WWPNotificationDefinitionId ;
      private string[] BC00033_A1WWPUserExtendedId ;
      private bool[] BC00033_n1WWPUserExtendedId ;
      private long[] BC00032_A13WWPSubscriptionId ;
      private string[] BC00032_A22WWPSubscriptionEntityRecordId ;
      private string[] BC00032_A24WWPSubscriptionEntityRecordDescription ;
      private string[] BC00032_A11WWPSubscriptionRoleId ;
      private bool[] BC00032_n11WWPSubscriptionRoleId ;
      private bool[] BC00032_A23WWPSubscriptionSubscribed ;
      private long[] BC00032_A14WWPNotificationDefinitionId ;
      private string[] BC00032_A1WWPUserExtendedId ;
      private bool[] BC00032_n1WWPUserExtendedId ;
      private long[] BC00039_A13WWPSubscriptionId ;
      private long[] BC000312_A10WWPEntityId ;
      private string[] BC000312_A25WWPNotificationDefinitionDescription ;
      private string[] BC000313_A12WWPEntityName ;
      private long[] BC000314_A10WWPEntityId ;
      private long[] BC000314_A13WWPSubscriptionId ;
      private string[] BC000314_A25WWPNotificationDefinitionDescription ;
      private string[] BC000314_A12WWPEntityName ;
      private string[] BC000314_A22WWPSubscriptionEntityRecordId ;
      private string[] BC000314_A24WWPSubscriptionEntityRecordDescription ;
      private string[] BC000314_A11WWPSubscriptionRoleId ;
      private bool[] BC000314_n11WWPSubscriptionRoleId ;
      private bool[] BC000314_A23WWPSubscriptionSubscribed ;
      private long[] BC000314_A14WWPNotificationDefinitionId ;
      private string[] BC000314_A1WWPUserExtendedId ;
      private bool[] BC000314_n1WWPUserExtendedId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_subscription_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00037;
        prmBC00037 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00034;
        prmBC00034 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00036;
        prmBC00036 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00035;
        prmBC00035 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00038;
        prmBC00038 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00033;
        prmBC00033 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00032;
        prmBC00032 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00039;
        prmBC00039 = new Object[] {
        new Object[] {"@WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0} ,
        new Object[] {"@WWPSubscriptionEntityRecordDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPSubscriptionRoleId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPSubscriptionSubscribed",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000310;
        prmBC000310 = new Object[] {
        new Object[] {"@WWPSubscriptionEntityRecordId",SqlDbType.NVarChar,2000,0} ,
        new Object[] {"@WWPSubscriptionEntityRecordDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPSubscriptionRoleId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPSubscriptionSubscribed",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000311;
        prmBC000311 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000312;
        prmBC000312 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000313;
        prmBC000313 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000314;
        prmBC000314 = new Object[] {
        new Object[] {"@WWPSubscriptionId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00032", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDescription], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WITH (UPDLOCK) WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00033", "SELECT [WWPSubscriptionId], [WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDescription], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00034", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescription] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00035", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00036", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00037", "SELECT T2.[WWPEntityId], TM1.[WWPSubscriptionId], T2.[WWPNotificationDefinitionDescription], T3.[WWPEntityName], TM1.[WWPSubscriptionEntityRecordId], TM1.[WWPSubscriptionEntityRecordDescription], TM1.[WWPSubscriptionRoleId], TM1.[WWPSubscriptionSubscribed], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM (([WWP_Subscription] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = T2.[WWPEntityId]) WHERE TM1.[WWPSubscriptionId] = @WWPSubscriptionId ORDER BY TM1.[WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00038", "SELECT [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPSubscriptionId] = @WWPSubscriptionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00038,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00039", "INSERT INTO [WWP_Subscription]([WWPSubscriptionEntityRecordId], [WWPSubscriptionEntityRecordDescription], [WWPSubscriptionRoleId], [WWPSubscriptionSubscribed], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPSubscriptionEntityRecordId, @WWPSubscriptionEntityRecordDescription, @WWPSubscriptionRoleId, @WWPSubscriptionSubscribed, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC00039)
           ,new CursorDef("BC000310", "UPDATE [WWP_Subscription] SET [WWPSubscriptionEntityRecordId]=@WWPSubscriptionEntityRecordId, [WWPSubscriptionEntityRecordDescription]=@WWPSubscriptionEntityRecordDescription, [WWPSubscriptionRoleId]=@WWPSubscriptionRoleId, [WWPSubscriptionSubscribed]=@WWPSubscriptionSubscribed, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmBC000310)
           ,new CursorDef("BC000311", "DELETE FROM [WWP_Subscription]  WHERE [WWPSubscriptionId] = @WWPSubscriptionId", GxErrorMask.GX_NOMASK,prmBC000311)
           ,new CursorDef("BC000312", "SELECT [WWPEntityId], [WWPNotificationDefinitionDescription] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000313", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000314", "SELECT T2.[WWPEntityId], TM1.[WWPSubscriptionId], T2.[WWPNotificationDefinitionDescription], T3.[WWPEntityName], TM1.[WWPSubscriptionEntityRecordId], TM1.[WWPSubscriptionEntityRecordDescription], TM1.[WWPSubscriptionRoleId], TM1.[WWPSubscriptionSubscribed], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM (([WWP_Subscription] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = T2.[WWPEntityId]) WHERE TM1.[WWPSubscriptionId] = @WWPSubscriptionId ORDER BY TM1.[WWPSubscriptionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000314,100, GxCacheFrequency.OFF ,true,false )
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
              table[3][0] = rslt.getString(4, 40);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getBool(5);
              table[6][0] = rslt.getLong(6);
              table[7][0] = rslt.getString(7, 40);
              table[8][0] = rslt.wasNull(7);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getBool(5);
              table[6][0] = rslt.getLong(6);
              table[7][0] = rslt.getString(7, 40);
              table[8][0] = rslt.wasNull(7);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 4 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getString(7, 40);
              table[7][0] = rslt.wasNull(7);
              table[8][0] = rslt.getBool(8);
              table[9][0] = rslt.getLong(9);
              table[10][0] = rslt.getString(10, 40);
              table[11][0] = rslt.wasNull(10);
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 7 :
              table[0][0] = rslt.getLong(1);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 11 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getString(7, 40);
              table[7][0] = rslt.wasNull(7);
              table[8][0] = rslt.getBool(8);
              table[9][0] = rslt.getLong(9);
              table[10][0] = rslt.getString(10, 40);
              table[11][0] = rslt.wasNull(10);
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 3 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
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
                 stmt.setNull( 3 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              stmt.SetParameter(4, (bool)parms[4]);
              stmt.SetParameter(5, (long)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 6 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(6, (string)parms[7]);
              }
              return;
           case 8 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              stmt.SetParameter(4, (bool)parms[4]);
              stmt.SetParameter(5, (long)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 6 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(6, (string)parms[7]);
              }
              stmt.SetParameter(7, (long)parms[8]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
