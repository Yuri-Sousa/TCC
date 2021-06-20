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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessage_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_discussionmessage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_discussionmessage_bc( IGxContext context )
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
         ReadRow0B12( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B12( ) ;
         standaloneModal( ) ;
         AddRow0B12( ) ;
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
               Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B12( ) ;
            }
            else
            {
               CheckExtendedTable0B12( ) ;
               if ( AnyError == 0 )
               {
                  ZM0B12( 7) ;
                  ZM0B12( 8) ;
                  ZM0B12( 9) ;
               }
               CloseExtendedTableCursors0B12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z87WWPDiscussionMessageDate = A87WWPDiscussionMessageDate;
            Z88WWPDiscussionMessageMessage = A88WWPDiscussionMessageMessage;
            Z89WWPDiscussionMessageEntityRecordId = A89WWPDiscussionMessageEntityRecordId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z10WWPEntityId = A10WWPEntityId;
            Z84WWPDiscussionMessageThreadId = A84WWPDiscussionMessageThreadId;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z12WWPEntityName = A12WWPEntityName;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( GX_JID == -6 )
         {
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z87WWPDiscussionMessageDate = A87WWPDiscussionMessageDate;
            Z88WWPDiscussionMessageMessage = A88WWPDiscussionMessageMessage;
            Z89WWPDiscussionMessageEntityRecordId = A89WWPDiscussionMessageEntityRecordId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z10WWPEntityId = A10WWPEntityId;
            Z84WWPDiscussionMessageThreadId = A84WWPDiscussionMessageThreadId;
            Z4WWPUserExtendedPhoto = A4WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z12WWPEntityName = A12WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         A87WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         GXt_char1 = A1WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A1WWPUserExtendedId = GXt_char1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000B4 */
            pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC000B4_A40000WWPUserExtendedPhoto_GXI[0];
            A4WWPUserExtendedPhoto = BC000B4_A4WWPUserExtendedPhoto[0];
            pr_default.close(2);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
         }
      }

      protected void Load0B12( )
      {
         /* Using cursor BC000B7 */
         pr_default.execute(5, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound12 = 1;
            A87WWPDiscussionMessageDate = BC000B7_A87WWPDiscussionMessageDate[0];
            A88WWPDiscussionMessageMessage = BC000B7_A88WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000B7_A40000WWPUserExtendedPhoto_GXI[0];
            A12WWPEntityName = BC000B7_A12WWPEntityName[0];
            A89WWPDiscussionMessageEntityRecordId = BC000B7_A89WWPDiscussionMessageEntityRecordId[0];
            A1WWPUserExtendedId = BC000B7_A1WWPUserExtendedId[0];
            A10WWPEntityId = BC000B7_A10WWPEntityId[0];
            A84WWPDiscussionMessageThreadId = BC000B7_A84WWPDiscussionMessageThreadId[0];
            n84WWPDiscussionMessageThreadId = BC000B7_n84WWPDiscussionMessageThreadId[0];
            A4WWPUserExtendedPhoto = BC000B7_A4WWPUserExtendedPhoto[0];
            ZM0B12( -6) ;
         }
         pr_default.close(5);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
      }

      protected void CheckExtendedTable0B12( )
      {
         nIsDirty_12 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A87WWPDiscussionMessageDate) || ( A87WWPDiscussionMessageDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Message Date fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000B6 */
         pr_default.execute(4, new Object[] {n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A84WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
         }
         A40000WWPUserExtendedPhoto_GXI = BC000B4_A40000WWPUserExtendedPhoto_GXI[0];
         A4WWPUserExtendedPhoto = BC000B4_A4WWPUserExtendedPhoto[0];
         pr_default.close(2);
         nIsDirty_12 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Entity for Discussions and Notifications'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A12WWPEntityName = BC000B5_A12WWPEntityName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0B12( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B12( )
      {
         /* Using cursor BC000B8 */
         pr_default.execute(6, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 6) ;
            RcdFound12 = 1;
            A83WWPDiscussionMessageId = BC000B3_A83WWPDiscussionMessageId[0];
            A87WWPDiscussionMessageDate = BC000B3_A87WWPDiscussionMessageDate[0];
            A88WWPDiscussionMessageMessage = BC000B3_A88WWPDiscussionMessageMessage[0];
            A89WWPDiscussionMessageEntityRecordId = BC000B3_A89WWPDiscussionMessageEntityRecordId[0];
            A1WWPUserExtendedId = BC000B3_A1WWPUserExtendedId[0];
            A10WWPEntityId = BC000B3_A10WWPEntityId[0];
            A84WWPDiscussionMessageThreadId = BC000B3_A84WWPDiscussionMessageThreadId[0];
            n84WWPDiscussionMessageThreadId = BC000B3_n84WWPDiscussionMessageThreadId[0];
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0B12( ) ;
            }
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode12;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B12( ) ;
         if ( RcdFound12 == 0 )
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
         CONFIRM_0B0( ) ;
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

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z87WWPDiscussionMessageDate != BC000B2_A87WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z88WWPDiscussionMessageMessage, BC000B2_A88WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z89WWPDiscussionMessageEntityRecordId, BC000B2_A89WWPDiscussionMessageEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC000B2_A1WWPUserExtendedId[0]) != 0 ) || ( Z10WWPEntityId != BC000B2_A10WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z84WWPDiscussionMessageThreadId != BC000B2_A84WWPDiscussionMessageThreadId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B9 */
                     pr_default.execute(7, new Object[] {A87WWPDiscussionMessageDate, A88WWPDiscussionMessageMessage, A89WWPDiscussionMessageEntityRecordId, A1WWPUserExtendedId, A10WWPEntityId, n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId});
                     A83WWPDiscussionMessageId = BC000B9_A83WWPDiscussionMessageId[0];
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B10 */
                     pr_default.execute(8, new Object[] {A87WWPDiscussionMessageDate, A88WWPDiscussionMessageMessage, A89WWPDiscussionMessageEntityRecordId, A1WWPUserExtendedId, A10WWPEntityId, n84WWPDiscussionMessageThreadId, A84WWPDiscussionMessageThreadId, A83WWPDiscussionMessageId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B11 */
                  pr_default.execute(9, new Object[] {A83WWPDiscussionMessageId});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000B12 */
            pr_default.execute(10, new Object[] {A1WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC000B12_A40000WWPUserExtendedPhoto_GXI[0];
            A4WWPUserExtendedPhoto = BC000B12_A4WWPUserExtendedPhoto[0];
            pr_default.close(10);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
            /* Using cursor BC000B13 */
            pr_default.execute(11, new Object[] {A10WWPEntityId});
            A12WWPEntityName = BC000B13_A12WWPEntityName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000B14 */
            pr_default.execute(12, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000B15 */
            pr_default.execute(13, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message Mention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B12( ) ;
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

      public void ScanKeyStart0B12( )
      {
         /* Using cursor BC000B16 */
         pr_default.execute(14, new Object[] {A83WWPDiscussionMessageId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound12 = 1;
            A83WWPDiscussionMessageId = BC000B16_A83WWPDiscussionMessageId[0];
            A87WWPDiscussionMessageDate = BC000B16_A87WWPDiscussionMessageDate[0];
            A88WWPDiscussionMessageMessage = BC000B16_A88WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000B16_A40000WWPUserExtendedPhoto_GXI[0];
            A12WWPEntityName = BC000B16_A12WWPEntityName[0];
            A89WWPDiscussionMessageEntityRecordId = BC000B16_A89WWPDiscussionMessageEntityRecordId[0];
            A1WWPUserExtendedId = BC000B16_A1WWPUserExtendedId[0];
            A10WWPEntityId = BC000B16_A10WWPEntityId[0];
            A84WWPDiscussionMessageThreadId = BC000B16_A84WWPDiscussionMessageThreadId[0];
            n84WWPDiscussionMessageThreadId = BC000B16_n84WWPDiscussionMessageThreadId[0];
            A4WWPUserExtendedPhoto = BC000B16_A4WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound12 = 0;
         ScanKeyLoad0B12( ) ;
      }

      protected void ScanKeyLoad0B12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound12 = 1;
            A83WWPDiscussionMessageId = BC000B16_A83WWPDiscussionMessageId[0];
            A87WWPDiscussionMessageDate = BC000B16_A87WWPDiscussionMessageDate[0];
            A88WWPDiscussionMessageMessage = BC000B16_A88WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000B16_A40000WWPUserExtendedPhoto_GXI[0];
            A12WWPEntityName = BC000B16_A12WWPEntityName[0];
            A89WWPDiscussionMessageEntityRecordId = BC000B16_A89WWPDiscussionMessageEntityRecordId[0];
            A1WWPUserExtendedId = BC000B16_A1WWPUserExtendedId[0];
            A10WWPEntityId = BC000B16_A10WWPEntityId[0];
            A84WWPDiscussionMessageThreadId = BC000B16_A84WWPDiscussionMessageThreadId[0];
            n84WWPDiscussionMessageThreadId = BC000B16_n84WWPDiscussionMessageThreadId[0];
            A4WWPUserExtendedPhoto = BC000B16_A4WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0B12( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
         if ( (0==A84WWPDiscussionMessageThreadId) )
         {
            A84WWPDiscussionMessageThreadId = 0;
            n84WWPDiscussionMessageThreadId = false;
            n84WWPDiscussionMessageThreadId = true;
         }
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void AddRow0B12( )
      {
         VarsToRow12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
      }

      protected void ReadRow0B12( )
      {
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
      }

      protected void InitializeNonKey0B12( )
      {
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A1WWPUserExtendedId = "";
         A2WWPUserExtendedFullName = "";
         A84WWPDiscussionMessageThreadId = 0;
         n84WWPDiscussionMessageThreadId = false;
         A88WWPDiscussionMessageMessage = "";
         A4WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A10WWPEntityId = 0;
         A12WWPEntityName = "";
         A89WWPDiscussionMessageEntityRecordId = "";
         Z87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z88WWPDiscussionMessageMessage = "";
         Z89WWPDiscussionMessageEntityRecordId = "";
         Z1WWPUserExtendedId = "";
         Z10WWPEntityId = 0;
         Z84WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll0B12( )
      {
         A83WWPDiscussionMessageId = 0;
         InitializeNonKey0B12( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A87WWPDiscussionMessageDate = i87WWPDiscussionMessageDate;
         A1WWPUserExtendedId = i1WWPUserExtendedId;
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

      public void VarsToRow12( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Wwpdiscussionmessagedate = A87WWPDiscussionMessageDate;
         obj12.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj12.gxTpr_Wwpuserextendedfullname = A2WWPUserExtendedFullName;
         obj12.gxTpr_Wwpdiscussionmessagethreadid = A84WWPDiscussionMessageThreadId;
         obj12.gxTpr_Wwpdiscussionmessagemessage = A88WWPDiscussionMessageMessage;
         obj12.gxTpr_Wwpuserextendedphoto = A4WWPUserExtendedPhoto;
         obj12.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj12.gxTpr_Wwpentityid = A10WWPEntityId;
         obj12.gxTpr_Wwpentityname = A12WWPEntityName;
         obj12.gxTpr_Wwpdiscussionmessageentityrecordid = A89WWPDiscussionMessageEntityRecordId;
         obj12.gxTpr_Wwpdiscussionmessageid = A83WWPDiscussionMessageId;
         obj12.gxTpr_Wwpdiscussionmessageid_Z = Z83WWPDiscussionMessageId;
         obj12.gxTpr_Wwpdiscussionmessagedate_Z = Z87WWPDiscussionMessageDate;
         obj12.gxTpr_Wwpdiscussionmessagethreadid_Z = Z84WWPDiscussionMessageThreadId;
         obj12.gxTpr_Wwpdiscussionmessagemessage_Z = Z88WWPDiscussionMessageMessage;
         obj12.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj12.gxTpr_Wwpuserextendedfullname_Z = Z2WWPUserExtendedFullName;
         obj12.gxTpr_Wwpentityid_Z = Z10WWPEntityId;
         obj12.gxTpr_Wwpentityname_Z = Z12WWPEntityName;
         obj12.gxTpr_Wwpdiscussionmessageentityrecordid_Z = Z89WWPDiscussionMessageEntityRecordId;
         obj12.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj12.gxTpr_Wwpdiscussionmessagethreadid_N = (short)(Convert.ToInt16(n84WWPDiscussionMessageThreadId));
         obj12.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow12( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj12 )
      {
         obj12.gxTpr_Wwpdiscussionmessageid = A83WWPDiscussionMessageId;
         return  ;
      }

      public void RowToVars12( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A87WWPDiscussionMessageDate = obj12.gxTpr_Wwpdiscussionmessagedate;
         A1WWPUserExtendedId = obj12.gxTpr_Wwpuserextendedid;
         A2WWPUserExtendedFullName = obj12.gxTpr_Wwpuserextendedfullname;
         A84WWPDiscussionMessageThreadId = obj12.gxTpr_Wwpdiscussionmessagethreadid;
         n84WWPDiscussionMessageThreadId = false;
         A88WWPDiscussionMessageMessage = obj12.gxTpr_Wwpdiscussionmessagemessage;
         A4WWPUserExtendedPhoto = obj12.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj12.gxTpr_Wwpuserextendedphoto_gxi;
         A10WWPEntityId = obj12.gxTpr_Wwpentityid;
         A12WWPEntityName = obj12.gxTpr_Wwpentityname;
         A89WWPDiscussionMessageEntityRecordId = obj12.gxTpr_Wwpdiscussionmessageentityrecordid;
         A83WWPDiscussionMessageId = obj12.gxTpr_Wwpdiscussionmessageid;
         Z83WWPDiscussionMessageId = obj12.gxTpr_Wwpdiscussionmessageid_Z;
         Z87WWPDiscussionMessageDate = obj12.gxTpr_Wwpdiscussionmessagedate_Z;
         Z84WWPDiscussionMessageThreadId = obj12.gxTpr_Wwpdiscussionmessagethreadid_Z;
         Z88WWPDiscussionMessageMessage = obj12.gxTpr_Wwpdiscussionmessagemessage_Z;
         Z1WWPUserExtendedId = obj12.gxTpr_Wwpuserextendedid_Z;
         Z2WWPUserExtendedFullName = obj12.gxTpr_Wwpuserextendedfullname_Z;
         Z10WWPEntityId = obj12.gxTpr_Wwpentityid_Z;
         Z12WWPEntityName = obj12.gxTpr_Wwpentityname_Z;
         Z89WWPDiscussionMessageEntityRecordId = obj12.gxTpr_Wwpdiscussionmessageentityrecordid_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj12.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n84WWPDiscussionMessageThreadId = (bool)(Convert.ToBoolean(obj12.gxTpr_Wwpdiscussionmessagethreadid_N));
         Gx_mode = obj12.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A83WWPDiscussionMessageId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B12( ) ;
         ScanKeyStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
         }
         ZM0B12( -6) ;
         OnLoadActions0B12( ) ;
         AddRow0B12( ) ;
         ScanKeyEnd0B12( ) ;
         if ( RcdFound12 == 0 )
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
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         ScanKeyStart0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
         }
         ZM0B12( -6) ;
         OnLoadActions0B12( ) ;
         AddRow0B12( ) ;
         ScanKeyEnd0B12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0B12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B12( ) ;
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId )
               {
                  A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
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
                  Update0B12( ) ;
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
                  if ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId )
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
                        Insert0B12( ) ;
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
                        Insert0B12( ) ;
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
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         SaveImpl( ) ;
         VarsToRow12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B12( ) ;
         AfterTrn( ) ;
         VarsToRow12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A83WWPDiscussionMessageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessage);
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
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         UpdateImpl( ) ;
         VarsToRow12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B12( ) ;
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
         VarsToRow12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0B12( ) ;
         if ( RcdFound12 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId )
            {
               A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
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
            if ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId )
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
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage_bc",pr_default);
         VarsToRow12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessage )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessage = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
            }
            else
            {
               RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars12( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_DiscussionMessage WWP_DiscussionMessage_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
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
            return "wwpdiscussionmessage_Execute" ;
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
         Z87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z88WWPDiscussionMessageMessage = "";
         A88WWPDiscussionMessageMessage = "";
         Z89WWPDiscussionMessageEntityRecordId = "";
         A89WWPDiscussionMessageEntityRecordId = "";
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z2WWPUserExtendedFullName = "";
         A2WWPUserExtendedFullName = "";
         Z12WWPEntityName = "";
         A12WWPEntityName = "";
         Z4WWPUserExtendedPhoto = "";
         A4WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         BC000B4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000B4_A4WWPUserExtendedPhoto = new string[] {""} ;
         BC000B7_A83WWPDiscussionMessageId = new long[1] ;
         BC000B7_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000B7_A88WWPDiscussionMessageMessage = new string[] {""} ;
         BC000B7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000B7_A12WWPEntityName = new string[] {""} ;
         BC000B7_A89WWPDiscussionMessageEntityRecordId = new string[] {""} ;
         BC000B7_A1WWPUserExtendedId = new string[] {""} ;
         BC000B7_A10WWPEntityId = new long[1] ;
         BC000B7_A84WWPDiscussionMessageThreadId = new long[1] ;
         BC000B7_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000B7_A4WWPUserExtendedPhoto = new string[] {""} ;
         BC000B6_A84WWPDiscussionMessageThreadId = new long[1] ;
         BC000B6_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000B5_A12WWPEntityName = new string[] {""} ;
         BC000B8_A83WWPDiscussionMessageId = new long[1] ;
         BC000B3_A83WWPDiscussionMessageId = new long[1] ;
         BC000B3_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A88WWPDiscussionMessageMessage = new string[] {""} ;
         BC000B3_A89WWPDiscussionMessageEntityRecordId = new string[] {""} ;
         BC000B3_A1WWPUserExtendedId = new string[] {""} ;
         BC000B3_A10WWPEntityId = new long[1] ;
         BC000B3_A84WWPDiscussionMessageThreadId = new long[1] ;
         BC000B3_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode12 = "";
         BC000B2_A83WWPDiscussionMessageId = new long[1] ;
         BC000B2_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A88WWPDiscussionMessageMessage = new string[] {""} ;
         BC000B2_A89WWPDiscussionMessageEntityRecordId = new string[] {""} ;
         BC000B2_A1WWPUserExtendedId = new string[] {""} ;
         BC000B2_A10WWPEntityId = new long[1] ;
         BC000B2_A84WWPDiscussionMessageThreadId = new long[1] ;
         BC000B2_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000B9_A83WWPDiscussionMessageId = new long[1] ;
         BC000B12_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000B12_A4WWPUserExtendedPhoto = new string[] {""} ;
         GXt_char1 = "";
         BC000B13_A12WWPEntityName = new string[] {""} ;
         BC000B14_A84WWPDiscussionMessageThreadId = new long[1] ;
         BC000B14_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000B15_A83WWPDiscussionMessageId = new long[1] ;
         BC000B15_A85WWPDiscussionMentionUserId = new string[] {""} ;
         BC000B16_A83WWPDiscussionMessageId = new long[1] ;
         BC000B16_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000B16_A88WWPDiscussionMessageMessage = new string[] {""} ;
         BC000B16_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000B16_A12WWPEntityName = new string[] {""} ;
         BC000B16_A89WWPDiscussionMessageEntityRecordId = new string[] {""} ;
         BC000B16_A1WWPUserExtendedId = new string[] {""} ;
         BC000B16_A10WWPEntityId = new long[1] ;
         BC000B16_A84WWPDiscussionMessageThreadId = new long[1] ;
         BC000B16_n84WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000B16_A4WWPUserExtendedPhoto = new string[] {""} ;
         i87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i1WWPUserExtendedId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A83WWPDiscussionMessageId, BC000B2_A87WWPDiscussionMessageDate, BC000B2_A88WWPDiscussionMessageMessage, BC000B2_A89WWPDiscussionMessageEntityRecordId, BC000B2_A1WWPUserExtendedId, BC000B2_A10WWPEntityId, BC000B2_A84WWPDiscussionMessageThreadId, BC000B2_n84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000B3_A83WWPDiscussionMessageId, BC000B3_A87WWPDiscussionMessageDate, BC000B3_A88WWPDiscussionMessageMessage, BC000B3_A89WWPDiscussionMessageEntityRecordId, BC000B3_A1WWPUserExtendedId, BC000B3_A10WWPEntityId, BC000B3_A84WWPDiscussionMessageThreadId, BC000B3_n84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000B4_A40000WWPUserExtendedPhoto_GXI, BC000B4_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000B5_A12WWPEntityName
               }
               , new Object[] {
               BC000B6_A84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000B7_A83WWPDiscussionMessageId, BC000B7_A87WWPDiscussionMessageDate, BC000B7_A88WWPDiscussionMessageMessage, BC000B7_A40000WWPUserExtendedPhoto_GXI, BC000B7_A12WWPEntityName, BC000B7_A89WWPDiscussionMessageEntityRecordId, BC000B7_A1WWPUserExtendedId, BC000B7_A10WWPEntityId, BC000B7_A84WWPDiscussionMessageThreadId, BC000B7_n84WWPDiscussionMessageThreadId,
               BC000B7_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000B8_A83WWPDiscussionMessageId
               }
               , new Object[] {
               BC000B9_A83WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B12_A40000WWPUserExtendedPhoto_GXI, BC000B12_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000B13_A12WWPEntityName
               }
               , new Object[] {
               BC000B14_A84WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000B15_A83WWPDiscussionMessageId, BC000B15_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000B16_A83WWPDiscussionMessageId, BC000B16_A87WWPDiscussionMessageDate, BC000B16_A88WWPDiscussionMessageMessage, BC000B16_A40000WWPUserExtendedPhoto_GXI, BC000B16_A12WWPEntityName, BC000B16_A89WWPDiscussionMessageEntityRecordId, BC000B16_A1WWPUserExtendedId, BC000B16_A10WWPEntityId, BC000B16_A84WWPDiscussionMessageThreadId, BC000B16_n84WWPDiscussionMessageThreadId,
               BC000B16_A4WWPUserExtendedPhoto
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
      private short Gx_BScreen ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private int trnEnded ;
      private long Z83WWPDiscussionMessageId ;
      private long A83WWPDiscussionMessageId ;
      private long Z10WWPEntityId ;
      private long A10WWPEntityId ;
      private long Z84WWPDiscussionMessageThreadId ;
      private long A84WWPDiscussionMessageThreadId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string sMode12 ;
      private string GXt_char1 ;
      private string i1WWPUserExtendedId ;
      private DateTime Z87WWPDiscussionMessageDate ;
      private DateTime A87WWPDiscussionMessageDate ;
      private DateTime i87WWPDiscussionMessageDate ;
      private bool n84WWPDiscussionMessageThreadId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z88WWPDiscussionMessageMessage ;
      private string A88WWPDiscussionMessageMessage ;
      private string Z89WWPDiscussionMessageEntityRecordId ;
      private string A89WWPDiscussionMessageEntityRecordId ;
      private string Z2WWPUserExtendedFullName ;
      private string A2WWPUserExtendedFullName ;
      private string Z12WWPEntityName ;
      private string A12WWPEntityName ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z4WWPUserExtendedPhoto ;
      private string A4WWPUserExtendedPhoto ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000B4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000B4_A4WWPUserExtendedPhoto ;
      private long[] BC000B7_A83WWPDiscussionMessageId ;
      private DateTime[] BC000B7_A87WWPDiscussionMessageDate ;
      private string[] BC000B7_A88WWPDiscussionMessageMessage ;
      private string[] BC000B7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000B7_A12WWPEntityName ;
      private string[] BC000B7_A89WWPDiscussionMessageEntityRecordId ;
      private string[] BC000B7_A1WWPUserExtendedId ;
      private long[] BC000B7_A10WWPEntityId ;
      private long[] BC000B7_A84WWPDiscussionMessageThreadId ;
      private bool[] BC000B7_n84WWPDiscussionMessageThreadId ;
      private string[] BC000B7_A4WWPUserExtendedPhoto ;
      private long[] BC000B6_A84WWPDiscussionMessageThreadId ;
      private bool[] BC000B6_n84WWPDiscussionMessageThreadId ;
      private string[] BC000B5_A12WWPEntityName ;
      private long[] BC000B8_A83WWPDiscussionMessageId ;
      private long[] BC000B3_A83WWPDiscussionMessageId ;
      private DateTime[] BC000B3_A87WWPDiscussionMessageDate ;
      private string[] BC000B3_A88WWPDiscussionMessageMessage ;
      private string[] BC000B3_A89WWPDiscussionMessageEntityRecordId ;
      private string[] BC000B3_A1WWPUserExtendedId ;
      private long[] BC000B3_A10WWPEntityId ;
      private long[] BC000B3_A84WWPDiscussionMessageThreadId ;
      private bool[] BC000B3_n84WWPDiscussionMessageThreadId ;
      private long[] BC000B2_A83WWPDiscussionMessageId ;
      private DateTime[] BC000B2_A87WWPDiscussionMessageDate ;
      private string[] BC000B2_A88WWPDiscussionMessageMessage ;
      private string[] BC000B2_A89WWPDiscussionMessageEntityRecordId ;
      private string[] BC000B2_A1WWPUserExtendedId ;
      private long[] BC000B2_A10WWPEntityId ;
      private long[] BC000B2_A84WWPDiscussionMessageThreadId ;
      private bool[] BC000B2_n84WWPDiscussionMessageThreadId ;
      private long[] BC000B9_A83WWPDiscussionMessageId ;
      private string[] BC000B12_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000B12_A4WWPUserExtendedPhoto ;
      private string[] BC000B13_A12WWPEntityName ;
      private long[] BC000B14_A84WWPDiscussionMessageThreadId ;
      private bool[] BC000B14_n84WWPDiscussionMessageThreadId ;
      private long[] BC000B15_A83WWPDiscussionMessageId ;
      private string[] BC000B15_A85WWPDiscussionMentionUserId ;
      private long[] BC000B16_A83WWPDiscussionMessageId ;
      private DateTime[] BC000B16_A87WWPDiscussionMessageDate ;
      private string[] BC000B16_A88WWPDiscussionMessageMessage ;
      private string[] BC000B16_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000B16_A12WWPEntityName ;
      private string[] BC000B16_A89WWPDiscussionMessageEntityRecordId ;
      private string[] BC000B16_A1WWPUserExtendedId ;
      private long[] BC000B16_A10WWPEntityId ;
      private long[] BC000B16_A84WWPDiscussionMessageThreadId ;
      private bool[] BC000B16_n84WWPDiscussionMessageThreadId ;
      private string[] BC000B16_A4WWPUserExtendedPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_discussionmessage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000B7;
        prmBC000B7 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B6;
        prmBC000B6 = new Object[] {
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B4;
        prmBC000B4 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000B5;
        prmBC000B5 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B8;
        prmBC000B8 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B3;
        prmBC000B3 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B2;
        prmBC000B2 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B9;
        prmBC000B9 = new Object[] {
        new Object[] {"@WWPDiscussionMessageDate",SqlDbType.DateTime,8,5} ,
        new Object[] {"@WWPDiscussionMessageMessage",SqlDbType.NVarChar,400,0} ,
        new Object[] {"@WWPDiscussionMessageEntityRecordId",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B10;
        prmBC000B10 = new Object[] {
        new Object[] {"@WWPDiscussionMessageDate",SqlDbType.DateTime,8,5} ,
        new Object[] {"@WWPDiscussionMessageMessage",SqlDbType.NVarChar,400,0} ,
        new Object[] {"@WWPDiscussionMessageEntityRecordId",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMessageThreadId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B11;
        prmBC000B11 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B12;
        prmBC000B12 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000B13;
        prmBC000B13 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B14;
        prmBC000B14 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B15;
        prmBC000B15 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000B16;
        prmBC000B16 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000B2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityRecordId], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityRecordId], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B4", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B5", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B6", "SELECT [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B7", "SELECT TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageMessage], T2.[WWPUserExtendedPhoto_GXI], T3.[WWPEntityName], TM1.[WWPDiscussionMessageEntityRecordId], TM1.[WWPUserExtendedId], TM1.[WWPEntityId], TM1.[WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId, T2.[WWPUserExtendedPhoto] FROM (([WWP_DiscussionMessage] TM1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId ORDER BY TM1.[WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B8", "SELECT [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B9", "INSERT INTO [WWP_DiscussionMessage]([WWPDiscussionMessageDate], [WWPDiscussionMessageMessage], [WWPDiscussionMessageEntityRecordId], [WWPUserExtendedId], [WWPEntityId], [WWPDiscussionMessageThreadId]) VALUES(@WWPDiscussionMessageDate, @WWPDiscussionMessageMessage, @WWPDiscussionMessageEntityRecordId, @WWPUserExtendedId, @WWPEntityId, @WWPDiscussionMessageThreadId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000B9)
           ,new CursorDef("BC000B10", "UPDATE [WWP_DiscussionMessage] SET [WWPDiscussionMessageDate]=@WWPDiscussionMessageDate, [WWPDiscussionMessageMessage]=@WWPDiscussionMessageMessage, [WWPDiscussionMessageEntityRecordId]=@WWPDiscussionMessageEntityRecordId, [WWPUserExtendedId]=@WWPUserExtendedId, [WWPEntityId]=@WWPEntityId, [WWPDiscussionMessageThreadId]=@WWPDiscussionMessageThreadId  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmBC000B10)
           ,new CursorDef("BC000B11", "DELETE FROM [WWP_DiscussionMessage]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId", GxErrorMask.GX_NOMASK,prmBC000B11)
           ,new CursorDef("BC000B12", "SELECT [WWPUserExtendedPhoto_GXI], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B13", "SELECT [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B14", "SELECT TOP 1 [WWPDiscussionMessageId] AS WWPDiscussionMessageThreadId FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageThreadId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000B15", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000B16", "SELECT TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageMessage], T2.[WWPUserExtendedPhoto_GXI], T3.[WWPEntityName], TM1.[WWPDiscussionMessageEntityRecordId], TM1.[WWPUserExtendedId], TM1.[WWPEntityId], TM1.[WWPDiscussionMessageThreadId] AS WWPDiscussionMessageThreadId, T2.[WWPUserExtendedPhoto] FROM (([WWP_DiscussionMessage] TM1 INNER JOIN [WWP_UserExtended] T2 ON T2.[WWPUserExtendedId] = TM1.[WWPUserExtendedId]) INNER JOIN [WWP_Entity] T3 ON T3.[WWPEntityId] = TM1.[WWPEntityId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId ORDER BY TM1.[WWPDiscussionMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B16,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 40);
              table[5][0] = rslt.getLong(6);
              table[6][0] = rslt.getLong(7);
              table[7][0] = rslt.wasNull(7);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 40);
              table[5][0] = rslt.getLong(6);
              table[6][0] = rslt.getLong(7);
              table[7][0] = rslt.wasNull(7);
              return;
           case 2 :
              table[0][0] = rslt.getMultimediaUri(1);
              table[1][0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getMultimediaUri(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getString(7, 40);
              table[7][0] = rslt.getLong(8);
              table[8][0] = rslt.getLong(9);
              table[9][0] = rslt.wasNull(9);
              table[10][0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 7 :
              table[0][0] = rslt.getLong(1);
              return;
           case 10 :
              table[0][0] = rslt.getMultimediaUri(1);
              table[1][0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 11 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              return;
           case 13 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 14 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getMultimediaUri(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getString(7, 40);
              table[7][0] = rslt.getLong(8);
              table[8][0] = rslt.getLong(9);
              table[9][0] = rslt.wasNull(9);
              table[10][0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
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
              stmt.SetParameter(1, (string)parms[0]);
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
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (long)parms[4]);
              if ( (bool)parms[5] )
              {
                 stmt.setNull( 6 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(6, (long)parms[6]);
              }
              return;
           case 8 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (long)parms[4]);
              if ( (bool)parms[5] )
              {
                 stmt.setNull( 6 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(6, (long)parms[6]);
              }
              stmt.SetParameter(7, (long)parms[7]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 11 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 12 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 13 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 14 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
