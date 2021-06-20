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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_userextended_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_userextended_bc( IGxContext context )
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
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
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
               Z1WWPUserExtendedId = A1WWPUserExtendedId;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z5WWPUserExtendedEmaiNotif = A5WWPUserExtendedEmaiNotif;
            Z6WWPUserExtendedSMSNotif = A6WWPUserExtendedSMSNotif;
            Z7WWPUserExtendedMobileNotif = A7WWPUserExtendedMobileNotif;
            Z8WWPUserExtendedDesktopNotif = A8WWPUserExtendedDesktopNotif;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
            Z9WWPUserExtendedPhone = A9WWPUserExtendedPhone;
            Z3WWPUserExtendedEmail = A3WWPUserExtendedEmail;
         }
         if ( GX_JID == -4 )
         {
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z4WWPUserExtendedPhoto = A4WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z5WWPUserExtendedEmaiNotif = A5WWPUserExtendedEmaiNotif;
            Z6WWPUserExtendedSMSNotif = A6WWPUserExtendedSMSNotif;
            Z7WWPUserExtendedMobileNotif = A7WWPUserExtendedMobileNotif;
            Z8WWPUserExtendedDesktopNotif = A8WWPUserExtendedDesktopNotif;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A40000WWPUserExtendedPhoto_GXI = BC00014_A40000WWPUserExtendedPhoto_GXI[0];
            A5WWPUserExtendedEmaiNotif = BC00014_A5WWPUserExtendedEmaiNotif[0];
            A6WWPUserExtendedSMSNotif = BC00014_A6WWPUserExtendedSMSNotif[0];
            A7WWPUserExtendedMobileNotif = BC00014_A7WWPUserExtendedMobileNotif[0];
            A8WWPUserExtendedDesktopNotif = BC00014_A8WWPUserExtendedDesktopNotif[0];
            A4WWPUserExtendedPhoto = BC00014_A4WWPUserExtendedPhoto[0];
            ZM011( -4) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         GXt_char1 = A9WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A9WWPUserExtendedPhone = GXt_char1;
         GXt_char1 = A3WWPUserExtendedEmail;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A3WWPUserExtendedEmail = GXt_char1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
         nIsDirty_1 = 1;
         GXt_char1 = A9WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A9WWPUserExtendedPhone = GXt_char1;
         nIsDirty_1 = 1;
         GXt_char1 = A3WWPUserExtendedEmail;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A3WWPUserExtendedEmail = GXt_char1;
         nIsDirty_1 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 4) ;
            RcdFound1 = 1;
            A1WWPUserExtendedId = BC00013_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00013_n1WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC00013_A40000WWPUserExtendedPhoto_GXI[0];
            A5WWPUserExtendedEmaiNotif = BC00013_A5WWPUserExtendedEmaiNotif[0];
            A6WWPUserExtendedSMSNotif = BC00013_A6WWPUserExtendedSMSNotif[0];
            A7WWPUserExtendedMobileNotif = BC00013_A7WWPUserExtendedMobileNotif[0];
            A8WWPUserExtendedDesktopNotif = BC00013_A8WWPUserExtendedDesktopNotif[0];
            A4WWPUserExtendedPhoto = BC00013_A4WWPUserExtendedPhoto[0];
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_010( ) ;
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

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z5WWPUserExtendedEmaiNotif != BC00012_A5WWPUserExtendedEmaiNotif[0] ) || ( Z6WWPUserExtendedSMSNotif != BC00012_A6WWPUserExtendedSMSNotif[0] ) || ( Z7WWPUserExtendedMobileNotif != BC00012_A7WWPUserExtendedMobileNotif[0] ) || ( Z8WWPUserExtendedDesktopNotif != BC00012_A8WWPUserExtendedDesktopNotif[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00016 */
                     pr_default.execute(4, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId, A4WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A5WWPUserExtendedEmaiNotif, A6WWPUserExtendedSMSNotif, A7WWPUserExtendedMobileNotif, A8WWPUserExtendedDesktopNotif});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A5WWPUserExtendedEmaiNotif, A6WWPUserExtendedSMSNotif, A7WWPUserExtendedMobileNotif, A8WWPUserExtendedDesktopNotif, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00018 */
            pr_default.execute(6, new Object[] {A4WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n1WWPUserExtendedId, A1WWPUserExtendedId});
            pr_default.close(6);
            dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00019 */
                  pr_default.execute(7, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_char1 = A9WWPUserExtendedPhone;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserphone(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A9WWPUserExtendedPhone = GXt_char1;
            GXt_char1 = A3WWPUserExtendedEmail;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuseremail(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A3WWPUserExtendedEmail = GXt_char1;
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000110 */
            pr_default.execute(8, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message Mention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000113 */
            pr_default.execute(11, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Web Client"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000114 */
            pr_default.execute(12, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPSubscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
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

      public void ScanKeyStart011( )
      {
         /* Using cursor BC000115 */
         pr_default.execute(13, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1WWPUserExtendedId = BC000115_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000115_n1WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000115_A40000WWPUserExtendedPhoto_GXI[0];
            A5WWPUserExtendedEmaiNotif = BC000115_A5WWPUserExtendedEmaiNotif[0];
            A6WWPUserExtendedSMSNotif = BC000115_A6WWPUserExtendedSMSNotif[0];
            A7WWPUserExtendedMobileNotif = BC000115_A7WWPUserExtendedMobileNotif[0];
            A8WWPUserExtendedDesktopNotif = BC000115_A8WWPUserExtendedDesktopNotif[0];
            A4WWPUserExtendedPhoto = BC000115_A4WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1WWPUserExtendedId = BC000115_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000115_n1WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000115_A40000WWPUserExtendedPhoto_GXI[0];
            A5WWPUserExtendedEmaiNotif = BC000115_A5WWPUserExtendedEmaiNotif[0];
            A6WWPUserExtendedSMSNotif = BC000115_A6WWPUserExtendedSMSNotif[0];
            A7WWPUserExtendedMobileNotif = BC000115_A7WWPUserExtendedMobileNotif[0];
            A8WWPUserExtendedDesktopNotif = BC000115_A8WWPUserExtendedDesktopNotif[0];
            A4WWPUserExtendedPhoto = BC000115_A4WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2WWPUserExtendedFullName = "";
         A3WWPUserExtendedEmail = "";
         A9WWPUserExtendedPhone = "";
         A4WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A5WWPUserExtendedEmaiNotif = false;
         A6WWPUserExtendedSMSNotif = false;
         A7WWPUserExtendedMobileNotif = false;
         A8WWPUserExtendedDesktopNotif = false;
         Z5WWPUserExtendedEmaiNotif = false;
         Z6WWPUserExtendedSMSNotif = false;
         Z7WWPUserExtendedMobileNotif = false;
         Z8WWPUserExtendedDesktopNotif = false;
      }

      protected void InitAll011( )
      {
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         InitializeNonKey011( ) ;
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

      public void VarsToRow1( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Wwpuserextendedfullname = A2WWPUserExtendedFullName;
         obj1.gxTpr_Wwpuserextendedemail = A3WWPUserExtendedEmail;
         obj1.gxTpr_Wwpuserextendedphone = A9WWPUserExtendedPhone;
         obj1.gxTpr_Wwpuserextendedphoto = A4WWPUserExtendedPhoto;
         obj1.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj1.gxTpr_Wwpuserextendedemainotif = A5WWPUserExtendedEmaiNotif;
         obj1.gxTpr_Wwpuserextendedsmsnotif = A6WWPUserExtendedSMSNotif;
         obj1.gxTpr_Wwpuserextendedmobilenotif = A7WWPUserExtendedMobileNotif;
         obj1.gxTpr_Wwpuserextendeddesktopnotif = A8WWPUserExtendedDesktopNotif;
         obj1.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj1.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj1.gxTpr_Wwpuserextendedfullname_Z = Z2WWPUserExtendedFullName;
         obj1.gxTpr_Wwpuserextendedphone_Z = Z9WWPUserExtendedPhone;
         obj1.gxTpr_Wwpuserextendedemail_Z = Z3WWPUserExtendedEmail;
         obj1.gxTpr_Wwpuserextendedemainotif_Z = Z5WWPUserExtendedEmaiNotif;
         obj1.gxTpr_Wwpuserextendedsmsnotif_Z = Z6WWPUserExtendedSMSNotif;
         obj1.gxTpr_Wwpuserextendedmobilenotif_Z = Z7WWPUserExtendedMobileNotif;
         obj1.gxTpr_Wwpuserextendeddesktopnotif_Z = Z8WWPUserExtendedDesktopNotif;
         obj1.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj1.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n1WWPUserExtendedId));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj1 )
      {
         obj1.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         return  ;
      }

      public void RowToVars1( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2WWPUserExtendedFullName = obj1.gxTpr_Wwpuserextendedfullname;
         A3WWPUserExtendedEmail = obj1.gxTpr_Wwpuserextendedemail;
         A9WWPUserExtendedPhone = obj1.gxTpr_Wwpuserextendedphone;
         A4WWPUserExtendedPhoto = obj1.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj1.gxTpr_Wwpuserextendedphoto_gxi;
         A5WWPUserExtendedEmaiNotif = obj1.gxTpr_Wwpuserextendedemainotif;
         A6WWPUserExtendedSMSNotif = obj1.gxTpr_Wwpuserextendedsmsnotif;
         A7WWPUserExtendedMobileNotif = obj1.gxTpr_Wwpuserextendedmobilenotif;
         A8WWPUserExtendedDesktopNotif = obj1.gxTpr_Wwpuserextendeddesktopnotif;
         A1WWPUserExtendedId = obj1.gxTpr_Wwpuserextendedid;
         n1WWPUserExtendedId = false;
         Z1WWPUserExtendedId = obj1.gxTpr_Wwpuserextendedid_Z;
         Z2WWPUserExtendedFullName = obj1.gxTpr_Wwpuserextendedfullname_Z;
         Z9WWPUserExtendedPhone = obj1.gxTpr_Wwpuserextendedphone_Z;
         Z3WWPUserExtendedEmail = obj1.gxTpr_Wwpuserextendedemail_Z;
         Z5WWPUserExtendedEmaiNotif = obj1.gxTpr_Wwpuserextendedemainotif_Z;
         Z6WWPUserExtendedSMSNotif = obj1.gxTpr_Wwpuserextendedsmsnotif_Z;
         Z7WWPUserExtendedMobileNotif = obj1.gxTpr_Wwpuserextendedmobilenotif_Z;
         Z8WWPUserExtendedDesktopNotif = obj1.gxTpr_Wwpuserextendeddesktopnotif_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj1.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n1WWPUserExtendedId = (bool)(Convert.ToBoolean(obj1.gxTpr_Wwpuserextendedid_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1WWPUserExtendedId = (string)getParm(obj,0);
         n1WWPUserExtendedId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
         ZM011( -4) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
         ZM011( -4) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( StringUtil.StrCmp(A1WWPUserExtendedId, Z1WWPUserExtendedId) != 0 )
               {
                  A1WWPUserExtendedId = Z1WWPUserExtendedId;
                  n1WWPUserExtendedId = false;
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
                  Update011( ) ;
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
                  if ( StringUtil.StrCmp(A1WWPUserExtendedId, Z1WWPUserExtendedId) != 0 )
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
                        Insert011( ) ;
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
                        Insert011( ) ;
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
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
            GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1WWPUserExtendedId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_UserExtended);
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         UpdateImpl( ) ;
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
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
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A1WWPUserExtendedId, Z1WWPUserExtendedId) != 0 )
            {
               A1WWPUserExtendedId = Z1WWPUserExtendedId;
               n1WWPUserExtendedId = false;
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
            if ( StringUtil.StrCmp(A1WWPUserExtendedId, Z1WWPUserExtendedId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_userextended_bc",pr_default);
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_UserExtended )
         {
            bcwwpbaseobjects_WWP_UserExtended = (GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
            }
            else
            {
               RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_UserExtended WWP_UserExtended_BC
      {
         get {
            return bcwwpbaseobjects_WWP_UserExtended ;
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
            return "wwpuserextended_Execute" ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z2WWPUserExtendedFullName = "";
         A2WWPUserExtendedFullName = "";
         Z9WWPUserExtendedPhone = "";
         A9WWPUserExtendedPhone = "";
         Z3WWPUserExtendedEmail = "";
         A3WWPUserExtendedEmail = "";
         Z4WWPUserExtendedPhoto = "";
         A4WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         BC00014_A1WWPUserExtendedId = new string[] {""} ;
         BC00014_n1WWPUserExtendedId = new bool[] {false} ;
         BC00014_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00014_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00014_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00014_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00014_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00014_A4WWPUserExtendedPhoto = new string[] {""} ;
         BC00015_A1WWPUserExtendedId = new string[] {""} ;
         BC00015_n1WWPUserExtendedId = new bool[] {false} ;
         BC00013_A1WWPUserExtendedId = new string[] {""} ;
         BC00013_n1WWPUserExtendedId = new bool[] {false} ;
         BC00013_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00013_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00013_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00013_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00013_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00013_A4WWPUserExtendedPhoto = new string[] {""} ;
         sMode1 = "";
         BC00012_A1WWPUserExtendedId = new string[] {""} ;
         BC00012_n1WWPUserExtendedId = new bool[] {false} ;
         BC00012_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00012_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00012_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00012_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00012_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00012_A4WWPUserExtendedPhoto = new string[] {""} ;
         GXt_char1 = "";
         BC000110_A83WWPDiscussionMessageId = new long[1] ;
         BC000110_A85WWPDiscussionMentionUserId = new string[] {""} ;
         BC000111_A83WWPDiscussionMessageId = new long[1] ;
         BC000112_A16WWPNotificationId = new long[1] ;
         BC000113_A18WWPWebClientId = new string[] {""} ;
         BC000114_A13WWPSubscriptionId = new long[1] ;
         BC000115_A1WWPUserExtendedId = new string[] {""} ;
         BC000115_n1WWPUserExtendedId = new bool[] {false} ;
         BC000115_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000115_A5WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC000115_A6WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC000115_A7WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC000115_A8WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC000115_A4WWPUserExtendedPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1WWPUserExtendedId, BC00012_A40000WWPUserExtendedPhoto_GXI, BC00012_A5WWPUserExtendedEmaiNotif, BC00012_A6WWPUserExtendedSMSNotif, BC00012_A7WWPUserExtendedMobileNotif, BC00012_A8WWPUserExtendedDesktopNotif, BC00012_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00013_A1WWPUserExtendedId, BC00013_A40000WWPUserExtendedPhoto_GXI, BC00013_A5WWPUserExtendedEmaiNotif, BC00013_A6WWPUserExtendedSMSNotif, BC00013_A7WWPUserExtendedMobileNotif, BC00013_A8WWPUserExtendedDesktopNotif, BC00013_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00014_A1WWPUserExtendedId, BC00014_A40000WWPUserExtendedPhoto_GXI, BC00014_A5WWPUserExtendedEmaiNotif, BC00014_A6WWPUserExtendedSMSNotif, BC00014_A7WWPUserExtendedMobileNotif, BC00014_A8WWPUserExtendedDesktopNotif, BC00014_A4WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00015_A1WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000110_A83WWPDiscussionMessageId, BC000110_A85WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000111_A83WWPDiscussionMessageId
               }
               , new Object[] {
               BC000112_A16WWPNotificationId
               }
               , new Object[] {
               BC000113_A18WWPWebClientId
               }
               , new Object[] {
               BC000114_A13WWPSubscriptionId
               }
               , new Object[] {
               BC000115_A1WWPUserExtendedId, BC000115_A40000WWPUserExtendedPhoto_GXI, BC000115_A5WWPUserExtendedEmaiNotif, BC000115_A6WWPUserExtendedSMSNotif, BC000115_A7WWPUserExtendedMobileNotif, BC000115_A8WWPUserExtendedDesktopNotif, BC000115_A4WWPUserExtendedPhoto
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
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string Z9WWPUserExtendedPhone ;
      private string A9WWPUserExtendedPhone ;
      private string sMode1 ;
      private string GXt_char1 ;
      private bool Z5WWPUserExtendedEmaiNotif ;
      private bool A5WWPUserExtendedEmaiNotif ;
      private bool Z6WWPUserExtendedSMSNotif ;
      private bool A6WWPUserExtendedSMSNotif ;
      private bool Z7WWPUserExtendedMobileNotif ;
      private bool A7WWPUserExtendedMobileNotif ;
      private bool Z8WWPUserExtendedDesktopNotif ;
      private bool A8WWPUserExtendedDesktopNotif ;
      private bool n1WWPUserExtendedId ;
      private bool mustCommit ;
      private string Z2WWPUserExtendedFullName ;
      private string A2WWPUserExtendedFullName ;
      private string Z3WWPUserExtendedEmail ;
      private string A3WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z4WWPUserExtendedPhoto ;
      private string A4WWPUserExtendedPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended bcwwpbaseobjects_WWP_UserExtended ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00014_A1WWPUserExtendedId ;
      private bool[] BC00014_n1WWPUserExtendedId ;
      private string[] BC00014_A40000WWPUserExtendedPhoto_GXI ;
      private bool[] BC00014_A5WWPUserExtendedEmaiNotif ;
      private bool[] BC00014_A6WWPUserExtendedSMSNotif ;
      private bool[] BC00014_A7WWPUserExtendedMobileNotif ;
      private bool[] BC00014_A8WWPUserExtendedDesktopNotif ;
      private string[] BC00014_A4WWPUserExtendedPhoto ;
      private string[] BC00015_A1WWPUserExtendedId ;
      private bool[] BC00015_n1WWPUserExtendedId ;
      private string[] BC00013_A1WWPUserExtendedId ;
      private bool[] BC00013_n1WWPUserExtendedId ;
      private string[] BC00013_A40000WWPUserExtendedPhoto_GXI ;
      private bool[] BC00013_A5WWPUserExtendedEmaiNotif ;
      private bool[] BC00013_A6WWPUserExtendedSMSNotif ;
      private bool[] BC00013_A7WWPUserExtendedMobileNotif ;
      private bool[] BC00013_A8WWPUserExtendedDesktopNotif ;
      private string[] BC00013_A4WWPUserExtendedPhoto ;
      private string[] BC00012_A1WWPUserExtendedId ;
      private bool[] BC00012_n1WWPUserExtendedId ;
      private string[] BC00012_A40000WWPUserExtendedPhoto_GXI ;
      private bool[] BC00012_A5WWPUserExtendedEmaiNotif ;
      private bool[] BC00012_A6WWPUserExtendedSMSNotif ;
      private bool[] BC00012_A7WWPUserExtendedMobileNotif ;
      private bool[] BC00012_A8WWPUserExtendedDesktopNotif ;
      private string[] BC00012_A4WWPUserExtendedPhoto ;
      private long[] BC000110_A83WWPDiscussionMessageId ;
      private string[] BC000110_A85WWPDiscussionMentionUserId ;
      private long[] BC000111_A83WWPDiscussionMessageId ;
      private long[] BC000112_A16WWPNotificationId ;
      private string[] BC000113_A18WWPWebClientId ;
      private long[] BC000114_A13WWPSubscriptionId ;
      private string[] BC000115_A1WWPUserExtendedId ;
      private bool[] BC000115_n1WWPUserExtendedId ;
      private string[] BC000115_A40000WWPUserExtendedPhoto_GXI ;
      private bool[] BC000115_A5WWPUserExtendedEmaiNotif ;
      private bool[] BC000115_A6WWPUserExtendedSMSNotif ;
      private bool[] BC000115_A7WWPUserExtendedMobileNotif ;
      private bool[] BC000115_A8WWPUserExtendedDesktopNotif ;
      private string[] BC000115_A4WWPUserExtendedPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_userextended_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00014;
        prmBC00014 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00015;
        prmBC00015 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00013;
        prmBC00013 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00012;
        prmBC00012 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00016;
        prmBC00016 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPUserExtendedPhoto",SqlDbType.VarBinary,1024,0} ,
        new Object[] {"@WWPUserExtendedPhoto_GXI",SqlDbType.VarChar,2048,0} ,
        new Object[] {"@WWPUserExtendedEmaiNotif",SqlDbType.Bit,100,0} ,
        new Object[] {"@WWPUserExtendedSMSNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedMobileNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedDesktopNotif",SqlDbType.Bit,4,0}
        };
        Object[] prmBC00017;
        prmBC00017 = new Object[] {
        new Object[] {"@WWPUserExtendedEmaiNotif",SqlDbType.Bit,100,0} ,
        new Object[] {"@WWPUserExtendedSMSNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedMobileNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedDesktopNotif",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00018;
        prmBC00018 = new Object[] {
        new Object[] {"@WWPUserExtendedPhoto",SqlDbType.VarBinary,1024,0} ,
        new Object[] {"@WWPUserExtendedPhoto_GXI",SqlDbType.VarChar,2048,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00019;
        prmBC00019 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000110;
        prmBC000110 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000111;
        prmBC000111 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000112;
        prmBC000112 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000113;
        prmBC000113 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000114;
        prmBC000114 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000115;
        prmBC000115 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00012", "SELECT [WWPUserExtendedId], [WWPUserExtendedPhoto_GXI], [WWPUserExtendedEmaiNotif], [WWPUserExtendedSMSNotif], [WWPUserExtendedMobileNotif], [WWPUserExtendedDesktopNotif], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WITH (UPDLOCK) WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00013", "SELECT [WWPUserExtendedId], [WWPUserExtendedPhoto_GXI], [WWPUserExtendedEmaiNotif], [WWPUserExtendedSMSNotif], [WWPUserExtendedMobileNotif], [WWPUserExtendedDesktopNotif], [WWPUserExtendedPhoto] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00014", "SELECT TM1.[WWPUserExtendedId], TM1.[WWPUserExtendedPhoto_GXI], TM1.[WWPUserExtendedEmaiNotif], TM1.[WWPUserExtendedSMSNotif], TM1.[WWPUserExtendedMobileNotif], TM1.[WWPUserExtendedDesktopNotif], TM1.[WWPUserExtendedPhoto] FROM [WWP_UserExtended] TM1 WHERE TM1.[WWPUserExtendedId] = @WWPUserExtendedId ORDER BY TM1.[WWPUserExtendedId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00015", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00016", "INSERT INTO [WWP_UserExtended]([WWPUserExtendedId], [WWPUserExtendedPhoto], [WWPUserExtendedPhoto_GXI], [WWPUserExtendedEmaiNotif], [WWPUserExtendedSMSNotif], [WWPUserExtendedMobileNotif], [WWPUserExtendedDesktopNotif]) VALUES(@WWPUserExtendedId, @WWPUserExtendedPhoto, @WWPUserExtendedPhoto_GXI, @WWPUserExtendedEmaiNotif, @WWPUserExtendedSMSNotif, @WWPUserExtendedMobileNotif, @WWPUserExtendedDesktopNotif)", GxErrorMask.GX_NOMASK,prmBC00016)
           ,new CursorDef("BC00017", "UPDATE [WWP_UserExtended] SET [WWPUserExtendedEmaiNotif]=@WWPUserExtendedEmaiNotif, [WWPUserExtendedSMSNotif]=@WWPUserExtendedSMSNotif, [WWPUserExtendedMobileNotif]=@WWPUserExtendedMobileNotif, [WWPUserExtendedDesktopNotif]=@WWPUserExtendedDesktopNotif  WHERE [WWPUserExtendedId] = @WWPUserExtendedId", GxErrorMask.GX_NOMASK,prmBC00017)
           ,new CursorDef("BC00018", "UPDATE [WWP_UserExtended] SET [WWPUserExtendedPhoto]=@WWPUserExtendedPhoto, [WWPUserExtendedPhoto_GXI]=@WWPUserExtendedPhoto_GXI  WHERE [WWPUserExtendedId] = @WWPUserExtendedId", GxErrorMask.GX_NOMASK,prmBC00018)
           ,new CursorDef("BC00019", "DELETE FROM [WWP_UserExtended]  WHERE [WWPUserExtendedId] = @WWPUserExtendedId", GxErrorMask.GX_NOMASK,prmBC00019)
           ,new CursorDef("BC000110", "SELECT TOP 1 [WWPDiscussionMessageId], [WWPDiscussionMentionUserId] FROM [WWP_DiscussionMessageMention] WHERE [WWPDiscussionMentionUserId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000110,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000111", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000112", "SELECT TOP 1 [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000113", "SELECT TOP 1 [WWPWebClientId] FROM [WWP_WebClient] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000114", "SELECT TOP 1 [WWPSubscriptionId] FROM [WWP_Subscription] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000114,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000115", "SELECT TM1.[WWPUserExtendedId], TM1.[WWPUserExtendedPhoto_GXI], TM1.[WWPUserExtendedEmaiNotif], TM1.[WWPUserExtendedSMSNotif], TM1.[WWPUserExtendedMobileNotif], TM1.[WWPUserExtendedDesktopNotif], TM1.[WWPUserExtendedPhoto] FROM [WWP_UserExtended] TM1 WHERE TM1.[WWPUserExtendedId] = @WWPUserExtendedId ORDER BY TM1.[WWPUserExtendedId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000115,100, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.getMultimediaUri(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              table[5][0] = rslt.getBool(6);
              table[6][0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 1 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.getMultimediaUri(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              table[5][0] = rslt.getBool(6);
              table[6][0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 2 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.getMultimediaUri(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              table[5][0] = rslt.getBool(6);
              table[6][0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 8 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getString(2, 40);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              return;
           case 11 :
              table[0][0] = rslt.getString(1, 100);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              return;
           case 13 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.getMultimediaUri(2);
              table[2][0] = rslt.getBool(3);
              table[3][0] = rslt.getBool(4);
              table[4][0] = rslt.getBool(5);
              table[5][0] = rslt.getBool(6);
              table[6][0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 1 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 2 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              stmt.SetParameterBlob(2, (string)parms[2], false);
              stmt.SetParameterMultimedia(3, (string)parms[3], (string)parms[2], "WWP_UserExtended", "WWPUserExtendedPhoto");
              stmt.SetParameter(4, (bool)parms[4]);
              stmt.SetParameter(5, (bool)parms[5]);
              stmt.SetParameter(6, (bool)parms[6]);
              stmt.SetParameter(7, (bool)parms[7]);
              return;
           case 5 :
              stmt.SetParameter(1, (bool)parms[0]);
              stmt.SetParameter(2, (bool)parms[1]);
              stmt.SetParameter(3, (bool)parms[2]);
              stmt.SetParameter(4, (bool)parms[3]);
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 5 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[5]);
              }
              return;
           case 6 :
              stmt.SetParameterBlob(1, (string)parms[0], false);
              stmt.SetParameterMultimedia(2, (string)parms[1], (string)parms[0], "WWP_UserExtended", "WWPUserExtendedPhoto");
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              return;
           case 7 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 8 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 9 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 10 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 11 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 12 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 13 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
     }
  }

}

}
