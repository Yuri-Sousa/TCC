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
   public class wwp_discussionmessagemention_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_discussionmessagemention_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_discussionmessagemention_bc( IGxContext context )
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
         ReadRow0C13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C13( ) ;
         standaloneModal( ) ;
         AddRow0C13( ) ;
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
               Z85WWPDiscussionMentionUserId = A85WWPDiscussionMentionUserId;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C13( ) ;
            }
            else
            {
               CheckExtendedTable0C13( ) ;
               if ( AnyError == 0 )
               {
                  ZM0C13( 3) ;
                  ZM0C13( 4) ;
               }
               CloseExtendedTableCursors0C13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z86WWPDiscussionMentionUserName = A86WWPDiscussionMentionUserName;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z87WWPDiscussionMessageDate = A87WWPDiscussionMessageDate;
            Z86WWPDiscussionMentionUserName = A86WWPDiscussionMentionUserName;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z86WWPDiscussionMentionUserName = A86WWPDiscussionMentionUserName;
         }
         if ( GX_JID == -2 )
         {
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z85WWPDiscussionMentionUserId = A85WWPDiscussionMentionUserId;
            Z87WWPDiscussionMessageDate = A87WWPDiscussionMessageDate;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C13( )
      {
         /* Using cursor BC000C6 */
         pr_default.execute(4, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
            A87WWPDiscussionMessageDate = BC000C6_A87WWPDiscussionMessageDate[0];
            ZM0C13( -2) ;
         }
         pr_default.close(4);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
         GXt_char1 = A86WWPDiscussionMentionUserName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
         A86WWPDiscussionMentionUserName = GXt_char1;
      }

      protected void CheckExtendedTable0C13( )
      {
         nIsDirty_13 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A83WWPDiscussionMessageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPDiscussion Message'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
         }
         A87WWPDiscussionMessageDate = BC000C4_A87WWPDiscussionMessageDate[0];
         pr_default.close(2);
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
         }
         pr_default.close(3);
         nIsDirty_13 = 1;
         GXt_char1 = A86WWPDiscussionMentionUserName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
         A86WWPDiscussionMentionUserName = GXt_char1;
      }

      protected void CloseExtendedTableCursors0C13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor BC000C7 */
         pr_default.execute(5, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 2) ;
            RcdFound13 = 1;
            A83WWPDiscussionMessageId = BC000C3_A83WWPDiscussionMessageId[0];
            A85WWPDiscussionMentionUserId = BC000C3_A85WWPDiscussionMentionUserId[0];
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z85WWPDiscussionMentionUserId = A85WWPDiscussionMentionUserId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
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
         CONFIRM_0C0( ) ;
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

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C8 */
                     pr_default.execute(6, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [WWP_DiscussionMessageMention] */
                     DeferredUpdate0C13( ) ;
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
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C9 */
                  pr_default.execute(7, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000C10 */
            pr_default.execute(8, new Object[] {A83WWPDiscussionMessageId});
            A87WWPDiscussionMessageDate = BC000C10_A87WWPDiscussionMessageDate[0];
            pr_default.close(8);
            GXt_char1 = A86WWPDiscussionMentionUserName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A85WWPDiscussionMentionUserId, out  GXt_char1) ;
            A86WWPDiscussionMentionUserName = GXt_char1;
         }
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
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

      public void ScanKeyStart0C13( )
      {
         /* Using cursor BC000C11 */
         pr_default.execute(9, new Object[] {A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A87WWPDiscussionMessageDate = BC000C11_A87WWPDiscussionMessageDate[0];
            A83WWPDiscussionMessageId = BC000C11_A83WWPDiscussionMessageId[0];
            A85WWPDiscussionMentionUserId = BC000C11_A85WWPDiscussionMentionUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound13 = 0;
         ScanKeyLoad0C13( ) ;
      }

      protected void ScanKeyLoad0C13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A87WWPDiscussionMessageDate = BC000C11_A87WWPDiscussionMessageDate[0];
            A83WWPDiscussionMessageId = BC000C11_A83WWPDiscussionMessageId[0];
            A85WWPDiscussionMentionUserId = BC000C11_A85WWPDiscussionMentionUserId[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0C13( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void AddRow0C13( )
      {
         VarsToRow13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
      }

      protected void ReadRow0C13( )
      {
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
      }

      protected void InitializeNonKey0C13( )
      {
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A86WWPDiscussionMentionUserName = "";
      }

      protected void InitAll0C13( )
      {
         A83WWPDiscussionMessageId = 0;
         A85WWPDiscussionMentionUserId = "";
         InitializeNonKey0C13( ) ;
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

      public void VarsToRow13( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Wwpdiscussionmessagedate = A87WWPDiscussionMessageDate;
         obj13.gxTpr_Wwpdiscussionmentionusername = A86WWPDiscussionMentionUserName;
         obj13.gxTpr_Wwpdiscussionmessageid = A83WWPDiscussionMessageId;
         obj13.gxTpr_Wwpdiscussionmentionuserid = A85WWPDiscussionMentionUserId;
         obj13.gxTpr_Wwpdiscussionmessageid_Z = Z83WWPDiscussionMessageId;
         obj13.gxTpr_Wwpdiscussionmessagedate_Z = Z87WWPDiscussionMessageDate;
         obj13.gxTpr_Wwpdiscussionmentionuserid_Z = Z85WWPDiscussionMentionUserId;
         obj13.gxTpr_Wwpdiscussionmentionusername_Z = Z86WWPDiscussionMentionUserName;
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj13 )
      {
         obj13.gxTpr_Wwpdiscussionmessageid = A83WWPDiscussionMessageId;
         obj13.gxTpr_Wwpdiscussionmentionuserid = A85WWPDiscussionMentionUserId;
         return  ;
      }

      public void RowToVars13( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A87WWPDiscussionMessageDate = obj13.gxTpr_Wwpdiscussionmessagedate;
         A86WWPDiscussionMentionUserName = obj13.gxTpr_Wwpdiscussionmentionusername;
         A83WWPDiscussionMessageId = obj13.gxTpr_Wwpdiscussionmessageid;
         A85WWPDiscussionMentionUserId = obj13.gxTpr_Wwpdiscussionmentionuserid;
         Z83WWPDiscussionMessageId = obj13.gxTpr_Wwpdiscussionmessageid_Z;
         Z87WWPDiscussionMessageDate = obj13.gxTpr_Wwpdiscussionmessagedate_Z;
         Z85WWPDiscussionMentionUserId = obj13.gxTpr_Wwpdiscussionmentionuserid_Z;
         Z86WWPDiscussionMentionUserName = obj13.gxTpr_Wwpdiscussionmentionusername_Z;
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A83WWPDiscussionMessageId = (long)getParm(obj,0);
         A85WWPDiscussionMentionUserId = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C13( ) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000C10 */
            pr_default.execute(8, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem("Não existe 'WWPDiscussion Message'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A87WWPDiscussionMessageDate = BC000C10_A87WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000C12 */
            pr_default.execute(10, new Object[] {A85WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z85WWPDiscussionMentionUserId = A85WWPDiscussionMentionUserId;
         }
         ZM0C13( -2) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
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
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000C10 */
            pr_default.execute(8, new Object[] {A83WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem("Não existe 'WWPDiscussion Message'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A87WWPDiscussionMessageDate = BC000C10_A87WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000C12 */
            pr_default.execute(10, new Object[] {A85WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z83WWPDiscussionMessageId = A83WWPDiscussionMessageId;
            Z85WWPDiscussionMentionUserId = A85WWPDiscussionMentionUserId;
         }
         ZM0C13( -2) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A85WWPDiscussionMentionUserId, Z85WWPDiscussionMentionUserId) != 0 ) )
               {
                  A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
                  A85WWPDiscussionMentionUserId = Z85WWPDiscussionMentionUserId;
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
                  Update0C13( ) ;
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
                  if ( ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A85WWPDiscussionMentionUserId, Z85WWPDiscussionMentionUserId) != 0 ) )
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
                        Insert0C13( ) ;
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
                        Insert0C13( ) ;
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
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A83WWPDiscussionMessageId, A85WWPDiscussionMentionUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention);
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
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         UpdateImpl( ) ;
         VarsToRow13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
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
         VarsToRow13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0C13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A85WWPDiscussionMentionUserId, Z85WWPDiscussionMentionUserId) != 0 ) )
            {
               A83WWPDiscussionMessageId = Z83WWPDiscussionMessageId;
               A85WWPDiscussionMentionUserId = Z85WWPDiscussionMentionUserId;
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
            if ( ( A83WWPDiscussionMessageId != Z83WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A85WWPDiscussionMentionUserId, Z85WWPDiscussionMentionUserId) != 0 ) )
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
         pr_default.close(10);
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention_bc",pr_default);
         VarsToRow13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
            }
            else
            {
               RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_DiscussionMessageMention WWP_DiscussionMessageMention_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
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
            return "wwpdiscussionmessagemention_Execute" ;
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
         Z85WWPDiscussionMentionUserId = "";
         A85WWPDiscussionMentionUserId = "";
         Z86WWPDiscussionMentionUserName = "";
         A86WWPDiscussionMentionUserName = "";
         Z87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A87WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         BC000C6_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000C6_A83WWPDiscussionMessageId = new long[1] ;
         BC000C6_A85WWPDiscussionMentionUserId = new string[] {""} ;
         BC000C4_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000C5_A85WWPDiscussionMentionUserId = new string[] {""} ;
         BC000C7_A83WWPDiscussionMessageId = new long[1] ;
         BC000C7_A85WWPDiscussionMentionUserId = new string[] {""} ;
         BC000C3_A83WWPDiscussionMessageId = new long[1] ;
         BC000C3_A85WWPDiscussionMentionUserId = new string[] {""} ;
         sMode13 = "";
         BC000C2_A83WWPDiscussionMessageId = new long[1] ;
         BC000C2_A85WWPDiscussionMentionUserId = new string[] {""} ;
         BC000C10_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         GXt_char1 = "";
         BC000C11_A87WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000C11_A83WWPDiscussionMessageId = new long[1] ;
         BC000C11_A85WWPDiscussionMentionUserId = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000C12_A85WWPDiscussionMentionUserId = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A83WWPDiscussionMessageId, BC000C2_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000C3_A83WWPDiscussionMessageId, BC000C3_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000C4_A87WWPDiscussionMessageDate
               }
               , new Object[] {
               BC000C5_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000C6_A87WWPDiscussionMessageDate, BC000C6_A83WWPDiscussionMessageId, BC000C6_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000C7_A83WWPDiscussionMessageId, BC000C7_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C10_A87WWPDiscussionMessageDate
               }
               , new Object[] {
               BC000C11_A87WWPDiscussionMessageDate, BC000C11_A83WWPDiscussionMessageId, BC000C11_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000C12_A85WWPDiscussionMentionUserId
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
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private int trnEnded ;
      private long Z83WWPDiscussionMessageId ;
      private long A83WWPDiscussionMessageId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z85WWPDiscussionMentionUserId ;
      private string A85WWPDiscussionMentionUserId ;
      private string sMode13 ;
      private string GXt_char1 ;
      private DateTime Z87WWPDiscussionMessageDate ;
      private DateTime A87WWPDiscussionMessageDate ;
      private bool mustCommit ;
      private string Z86WWPDiscussionMentionUserName ;
      private string A86WWPDiscussionMentionUserName ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] BC000C6_A87WWPDiscussionMessageDate ;
      private long[] BC000C6_A83WWPDiscussionMessageId ;
      private string[] BC000C6_A85WWPDiscussionMentionUserId ;
      private DateTime[] BC000C4_A87WWPDiscussionMessageDate ;
      private string[] BC000C5_A85WWPDiscussionMentionUserId ;
      private long[] BC000C7_A83WWPDiscussionMessageId ;
      private string[] BC000C7_A85WWPDiscussionMentionUserId ;
      private long[] BC000C3_A83WWPDiscussionMessageId ;
      private string[] BC000C3_A85WWPDiscussionMentionUserId ;
      private long[] BC000C2_A83WWPDiscussionMessageId ;
      private string[] BC000C2_A85WWPDiscussionMentionUserId ;
      private DateTime[] BC000C10_A87WWPDiscussionMessageDate ;
      private DateTime[] BC000C11_A87WWPDiscussionMessageDate ;
      private long[] BC000C11_A83WWPDiscussionMessageId ;
      private string[] BC000C11_A85WWPDiscussionMentionUserId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] BC000C12_A85WWPDiscussionMentionUserId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_discussionmessagemention_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessagemention_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000C6;
        prmBC000C6 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C4;
        prmBC000C4 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000C5;
        prmBC000C5 = new Object[] {
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C7;
        prmBC000C7 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C3;
        prmBC000C3 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C2;
        prmBC000C2 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C8;
        prmBC000C8 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C9;
        prmBC000C9 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C11;
        prmBC000C11 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000C10;
        prmBC000C10 = new Object[] {
        new Object[] {"@WWPDiscussionMessageId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000C12;
        prmBC000C12 = new Object[] {
        new Object[] {"@WWPDiscussionMentionUserId",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000C2", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WITH (UPDLOCK) WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C3", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C4", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C5", "SELECT [WWPUserExtendedId] AS WWPDiscussionMentionUserId FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C6", "SELECT T2.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM ([WWP_DiscussionMessageMention] TM1 INNER JOIN [WWP_DiscussionMessage] T2 ON T2.[WWPDiscussionMessageId] = TM1.[WWPDiscussionMessageId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId and TM1.[WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ORDER BY TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C7", "SELECT [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C8", "INSERT INTO [WWP_DiscussionMessageMention]([WWPDiscussionMessageId], [WWPDiscussionMentionUserId]) VALUES(@WWPDiscussionMessageId, @WWPDiscussionMentionUserId)", GxErrorMask.GX_NOMASK,prmBC000C8)
           ,new CursorDef("BC000C9", "DELETE FROM [WWP_DiscussionMessageMention]  WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId AND [WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId", GxErrorMask.GX_NOMASK,prmBC000C9)
           ,new CursorDef("BC000C10", "SELECT [WWPDiscussionMessageDate] FROM [WWP_DiscussionMessage] WHERE [WWPDiscussionMessageId] = @WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C11", "SELECT T2.[WWPDiscussionMessageDate], TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId] AS WWPDiscussionMentionUserId FROM ([WWP_DiscussionMessageMention] TM1 INNER JOIN [WWP_DiscussionMessage] T2 ON T2.[WWPDiscussionMessageId] = TM1.[WWPDiscussionMessageId]) WHERE TM1.[WWPDiscussionMessageId] = @WWPDiscussionMessageId and TM1.[WWPDiscussionMentionUserId] = @WWPDiscussionMentionUserId ORDER BY TM1.[WWPDiscussionMessageId], TM1.[WWPDiscussionMentionUserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C11,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C12", "SELECT [WWPUserExtendedId] AS WWPDiscussionMentionUserId FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C12,1, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getString(2, 40);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 2 :
              table[0][0] = rslt.getGXDateTime(1);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 4 :
              table[0][0] = rslt.getGXDateTime(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getString(3, 40);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 8 :
              table[0][0] = rslt.getGXDateTime(1);
              return;
           case 9 :
              table[0][0] = rslt.getGXDateTime(1);
              table[1][0] = rslt.getLong(2);
              table[2][0] = rslt.getString(3, 40);
              return;
           case 10 :
              table[0][0] = rslt.getString(1, 40);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 5 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 6 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 7 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 8 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              return;
           case 10 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
     }
  }

}

}
