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
   public class wwp_entity_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_entity_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_entity_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
               Z10WWPEntityId = A10WWPEntityId;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z12WWPEntityName = A12WWPEntityName;
         }
         if ( GX_JID == -1 )
         {
            Z10WWPEntityId = A10WWPEntityId;
            Z12WWPEntityName = A12WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound2 = 1;
            A12WWPEntityName = BC00024_A12WWPEntityName[0];
            ZM022( -1) ;
         }
         pr_default.close(2);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors022( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A10WWPEntityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 1) ;
            RcdFound2 = 1;
            A10WWPEntityId = BC00023_A10WWPEntityId[0];
            A12WWPEntityName = BC00023_A12WWPEntityName[0];
            Z10WWPEntityId = A10WWPEntityId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
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

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A10WWPEntityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z12WWPEntityName, BC00022_A12WWPEntityName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Entity"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00026 */
                     pr_default.execute(4, new Object[] {A12WWPEntityName});
                     A10WWPEntityId = BC00026_A10WWPEntityId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Entity");
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00027 */
                     pr_default.execute(5, new Object[] {A12WWPEntityName, A10WWPEntityId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Entity");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00028 */
                  pr_default.execute(6, new Object[] {A10WWPEntityId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_Entity");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00029 */
            pr_default.execute(7, new Object[] {A10WWPEntityId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPDiscussion Message"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
            /* Using cursor BC000210 */
            pr_default.execute(8, new Object[] {A10WWPEntityId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Using cursor BC000211 */
         pr_default.execute(9, new Object[] {A10WWPEntityId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A10WWPEntityId = BC000211_A10WWPEntityId[0];
            A12WWPEntityName = BC000211_A12WWPEntityName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A10WWPEntityId = BC000211_A10WWPEntityId[0];
            A12WWPEntityName = BC000211_A12WWPEntityName[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcwwpbaseobjects_WWP_Entity) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A12WWPEntityName = "";
         Z12WWPEntityName = "";
      }

      protected void InitAll022( )
      {
         A10WWPEntityId = 0;
         InitializeNonKey022( ) ;
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

      public void VarsToRow2( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Wwpentityname = A12WWPEntityName;
         obj2.gxTpr_Wwpentityid = A10WWPEntityId;
         obj2.gxTpr_Wwpentityid_Z = Z10WWPEntityId;
         obj2.gxTpr_Wwpentityname_Z = Z12WWPEntityName;
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj2 )
      {
         obj2.gxTpr_Wwpentityid = A10WWPEntityId;
         return  ;
      }

      public void RowToVars2( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A12WWPEntityName = obj2.gxTpr_Wwpentityname;
         A10WWPEntityId = obj2.gxTpr_Wwpentityid;
         Z10WWPEntityId = obj2.gxTpr_Wwpentityid_Z;
         Z12WWPEntityName = obj2.gxTpr_Wwpentityname_Z;
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A10WWPEntityId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10WWPEntityId = A10WWPEntityId;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10WWPEntityId = A10WWPEntityId;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A10WWPEntityId != Z10WWPEntityId )
               {
                  A10WWPEntityId = Z10WWPEntityId;
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
                  Update022( ) ;
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
                  if ( A10WWPEntityId != Z10WWPEntityId )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcwwpbaseobjects_WWP_Entity) ;
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
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcwwpbaseobjects_WWP_Entity) ;
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
            GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A10WWPEntityId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_Entity);
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
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 1) ;
         UpdateImpl( ) ;
         VarsToRow2( bcwwpbaseobjects_WWP_Entity) ;
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
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
         VarsToRow2( bcwwpbaseobjects_WWP_Entity) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A10WWPEntityId != Z10WWPEntityId )
            {
               A10WWPEntityId = Z10WWPEntityId;
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
            if ( A10WWPEntityId != Z10WWPEntityId )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_entity_bc",pr_default);
         VarsToRow2( bcwwpbaseobjects_WWP_Entity) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_Entity.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_Entity )
         {
            bcwwpbaseobjects_WWP_Entity = (GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcwwpbaseobjects_WWP_Entity) ;
            }
            else
            {
               RowToVars2( bcwwpbaseobjects_WWP_Entity, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcwwpbaseobjects_WWP_Entity, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Entity WWP_Entity_BC
      {
         get {
            return bcwwpbaseobjects_WWP_Entity ;
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
            return "wwpentity_Execute" ;
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
         Z12WWPEntityName = "";
         A12WWPEntityName = "";
         BC00024_A10WWPEntityId = new long[1] ;
         BC00024_A12WWPEntityName = new string[] {""} ;
         BC00025_A10WWPEntityId = new long[1] ;
         BC00023_A10WWPEntityId = new long[1] ;
         BC00023_A12WWPEntityName = new string[] {""} ;
         sMode2 = "";
         BC00022_A10WWPEntityId = new long[1] ;
         BC00022_A12WWPEntityName = new string[] {""} ;
         BC00026_A10WWPEntityId = new long[1] ;
         BC00029_A83WWPDiscussionMessageId = new long[1] ;
         BC000210_A14WWPNotificationDefinitionId = new long[1] ;
         BC000211_A10WWPEntityId = new long[1] ;
         BC000211_A12WWPEntityName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A10WWPEntityId, BC00022_A12WWPEntityName
               }
               , new Object[] {
               BC00023_A10WWPEntityId, BC00023_A12WWPEntityName
               }
               , new Object[] {
               BC00024_A10WWPEntityId, BC00024_A12WWPEntityName
               }
               , new Object[] {
               BC00025_A10WWPEntityId
               }
               , new Object[] {
               BC00026_A10WWPEntityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00029_A83WWPDiscussionMessageId
               }
               , new Object[] {
               BC000210_A14WWPNotificationDefinitionId
               }
               , new Object[] {
               BC000211_A10WWPEntityId, BC000211_A12WWPEntityName
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
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private int trnEnded ;
      private long Z10WWPEntityId ;
      private long A10WWPEntityId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private bool mustCommit ;
      private string Z12WWPEntityName ;
      private string A12WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity bcwwpbaseobjects_WWP_Entity ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00024_A10WWPEntityId ;
      private string[] BC00024_A12WWPEntityName ;
      private long[] BC00025_A10WWPEntityId ;
      private long[] BC00023_A10WWPEntityId ;
      private string[] BC00023_A12WWPEntityName ;
      private long[] BC00022_A10WWPEntityId ;
      private string[] BC00022_A12WWPEntityName ;
      private long[] BC00026_A10WWPEntityId ;
      private long[] BC00029_A83WWPDiscussionMessageId ;
      private long[] BC000210_A14WWPNotificationDefinitionId ;
      private long[] BC000211_A10WWPEntityId ;
      private string[] BC000211_A12WWPEntityName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_entity_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_entity_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00024;
        prmBC00024 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00025;
        prmBC00025 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00023;
        prmBC00023 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00022;
        prmBC00022 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00026;
        prmBC00026 = new Object[] {
        new Object[] {"@WWPEntityName",SqlDbType.NVarChar,100,0}
        };
        Object[] prmBC00027;
        prmBC00027 = new Object[] {
        new Object[] {"@WWPEntityName",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00028;
        prmBC00028 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00029;
        prmBC00029 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000210;
        prmBC000210 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000211;
        prmBC000211 = new Object[] {
        new Object[] {"@WWPEntityId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00022", "SELECT [WWPEntityId], [WWPEntityName] FROM [WWP_Entity] WITH (UPDLOCK) WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00023", "SELECT [WWPEntityId], [WWPEntityName] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00024", "SELECT TM1.[WWPEntityId], TM1.[WWPEntityName] FROM [WWP_Entity] TM1 WHERE TM1.[WWPEntityId] = @WWPEntityId ORDER BY TM1.[WWPEntityId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00025", "SELECT [WWPEntityId] FROM [WWP_Entity] WHERE [WWPEntityId] = @WWPEntityId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00026", "INSERT INTO [WWP_Entity]([WWPEntityName]) VALUES(@WWPEntityName); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC00026)
           ,new CursorDef("BC00027", "UPDATE [WWP_Entity] SET [WWPEntityName]=@WWPEntityName  WHERE [WWPEntityId] = @WWPEntityId", GxErrorMask.GX_NOMASK,prmBC00027)
           ,new CursorDef("BC00028", "DELETE FROM [WWP_Entity]  WHERE [WWPEntityId] = @WWPEntityId", GxErrorMask.GX_NOMASK,prmBC00028)
           ,new CursorDef("BC00029", "SELECT TOP 1 [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000210", "SELECT TOP 1 [WWPNotificationDefinitionId] FROM [WWP_NotificationDefinition] WHERE [WWPEntityId] = @WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000211", "SELECT TM1.[WWPEntityId], TM1.[WWPEntityName] FROM [WWP_Entity] TM1 WHERE TM1.[WWPEntityId] = @WWPEntityId ORDER BY TM1.[WWPEntityId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 2 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 3 :
              table[0][0] = rslt.getLong(1);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 7 :
              table[0][0] = rslt.getLong(1);
              return;
           case 8 :
              table[0][0] = rslt.getLong(1);
              return;
           case 9 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
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
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (long)parms[1]);
              return;
           case 6 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
     }
  }

}

}
