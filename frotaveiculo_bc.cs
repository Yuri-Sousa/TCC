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
namespace GeneXus.Programs {
   public class frotaveiculo_bc : GXHttpHandler, IGxSilentTrn
   {
      public frotaveiculo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public frotaveiculo_bc( IGxContext context )
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
         ReadRow0G17( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G17( ) ;
         standaloneModal( ) ;
         AddRow0G17( ) ;
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
               Z93FrotaId = A93FrotaId;
               Z98VeiculoId = A98VeiculoId;
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G17( ) ;
            }
            else
            {
               CheckExtendedTable0G17( ) ;
               if ( AnyError == 0 )
               {
                  ZM0G17( 2) ;
                  ZM0G17( 3) ;
               }
               CloseExtendedTableCursors0G17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z93FrotaId = A93FrotaId;
            Z98VeiculoId = A98VeiculoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0G17( )
      {
         /* Using cursor BC000G6 */
         pr_default.execute(4, new Object[] {A93FrotaId, A98VeiculoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound17 = 1;
            ZM0G17( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         nIsDirty_17 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000G4 */
         pr_default.execute(2, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Frota'.", "ForeignKeyNotFound", 1, "FROTAID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC000G5 */
         pr_default.execute(3, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Veiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0G17( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G17( )
      {
         /* Using cursor BC000G7 */
         pr_default.execute(5, new Object[] {A93FrotaId, A98VeiculoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {A93FrotaId, A98VeiculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G17( 1) ;
            RcdFound17 = 1;
            A93FrotaId = BC000G3_A93FrotaId[0];
            A98VeiculoId = BC000G3_A98VeiculoId[0];
            Z93FrotaId = A93FrotaId;
            Z98VeiculoId = A98VeiculoId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode17;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
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
         CONFIRM_0G0( ) ;
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

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {A93FrotaId, A98VeiculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FrotaVeiculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FrotaVeiculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G8 */
                     pr_default.execute(6, new Object[] {A93FrotaId, A98VeiculoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("FrotaVeiculo");
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [FrotaVeiculo] */
                     DeferredUpdate0G17( ) ;
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
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G9 */
                  pr_default.execute(7, new Object[] {A93FrotaId, A98VeiculoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("FrotaVeiculo");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
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

      public void ScanKeyStart0G17( )
      {
         /* Using cursor BC000G10 */
         pr_default.execute(8, new Object[] {A93FrotaId, A98VeiculoId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound17 = 1;
            A93FrotaId = BC000G10_A93FrotaId[0];
            A98VeiculoId = BC000G10_A98VeiculoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G17( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound17 = 0;
         ScanKeyLoad0G17( ) ;
      }

      protected void ScanKeyLoad0G17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound17 = 1;
            A93FrotaId = BC000G10_A93FrotaId[0];
            A98VeiculoId = BC000G10_A98VeiculoId[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0G17( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void AddRow0G17( )
      {
         VarsToRow17( bcFrotaVeiculo) ;
      }

      protected void ReadRow0G17( )
      {
         RowToVars17( bcFrotaVeiculo, 1) ;
      }

      protected void InitializeNonKey0G17( )
      {
      }

      protected void InitAll0G17( )
      {
         A93FrotaId = 0;
         A98VeiculoId = 0;
         InitializeNonKey0G17( ) ;
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

      public void VarsToRow17( SdtFrotaVeiculo obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Frotaid = A93FrotaId;
         obj17.gxTpr_Veiculoid = A98VeiculoId;
         obj17.gxTpr_Frotaid_Z = Z93FrotaId;
         obj17.gxTpr_Veiculoid_Z = Z98VeiculoId;
         obj17.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow17( SdtFrotaVeiculo obj17 )
      {
         obj17.gxTpr_Frotaid = A93FrotaId;
         obj17.gxTpr_Veiculoid = A98VeiculoId;
         return  ;
      }

      public void RowToVars17( SdtFrotaVeiculo obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A93FrotaId = obj17.gxTpr_Frotaid;
         A98VeiculoId = obj17.gxTpr_Veiculoid;
         Z93FrotaId = obj17.gxTpr_Frotaid_Z;
         Z98VeiculoId = obj17.gxTpr_Veiculoid_Z;
         Gx_mode = obj17.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A93FrotaId = (int)getParm(obj,0);
         A98VeiculoId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G17( ) ;
         ScanKeyStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000G11 */
            pr_default.execute(9, new Object[] {A93FrotaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Frota'.", "ForeignKeyNotFound", 1, "FROTAID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000G12 */
            pr_default.execute(10, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Veiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z93FrotaId = A93FrotaId;
            Z98VeiculoId = A98VeiculoId;
         }
         ZM0G17( -1) ;
         OnLoadActions0G17( ) ;
         AddRow0G17( ) ;
         ScanKeyEnd0G17( ) ;
         if ( RcdFound17 == 0 )
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
         RowToVars17( bcFrotaVeiculo, 0) ;
         ScanKeyStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000G11 */
            pr_default.execute(9, new Object[] {A93FrotaId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Frota'.", "ForeignKeyNotFound", 1, "FROTAID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000G12 */
            pr_default.execute(10, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Veiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z93FrotaId = A93FrotaId;
            Z98VeiculoId = A98VeiculoId;
         }
         ZM0G17( -1) ;
         OnLoadActions0G17( ) ;
         AddRow0G17( ) ;
         ScanKeyEnd0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G17( ) ;
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( ( A93FrotaId != Z93FrotaId ) || ( A98VeiculoId != Z98VeiculoId ) )
               {
                  A93FrotaId = Z93FrotaId;
                  A98VeiculoId = Z98VeiculoId;
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
                  Update0G17( ) ;
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
                  if ( ( A93FrotaId != Z93FrotaId ) || ( A98VeiculoId != Z98VeiculoId ) )
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
                        Insert0G17( ) ;
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
                        Insert0G17( ) ;
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
         RowToVars17( bcFrotaVeiculo, 1) ;
         SaveImpl( ) ;
         VarsToRow17( bcFrotaVeiculo) ;
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
         RowToVars17( bcFrotaVeiculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G17( ) ;
         AfterTrn( ) ;
         VarsToRow17( bcFrotaVeiculo) ;
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
            SdtFrotaVeiculo auxBC = new SdtFrotaVeiculo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A93FrotaId, A98VeiculoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFrotaVeiculo);
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
         RowToVars17( bcFrotaVeiculo, 1) ;
         UpdateImpl( ) ;
         VarsToRow17( bcFrotaVeiculo) ;
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
         RowToVars17( bcFrotaVeiculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G17( ) ;
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
         VarsToRow17( bcFrotaVeiculo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars17( bcFrotaVeiculo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0G17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A93FrotaId != Z93FrotaId ) || ( A98VeiculoId != Z98VeiculoId ) )
            {
               A93FrotaId = Z93FrotaId;
               A98VeiculoId = Z98VeiculoId;
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
            if ( ( A93FrotaId != Z93FrotaId ) || ( A98VeiculoId != Z98VeiculoId ) )
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
         context.RollbackDataStores("frotaveiculo_bc",pr_default);
         VarsToRow17( bcFrotaVeiculo) ;
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
         Gx_mode = bcFrotaVeiculo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFrotaVeiculo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFrotaVeiculo )
         {
            bcFrotaVeiculo = (SdtFrotaVeiculo)(sdt);
            if ( StringUtil.StrCmp(bcFrotaVeiculo.gxTpr_Mode, "") == 0 )
            {
               bcFrotaVeiculo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow17( bcFrotaVeiculo) ;
            }
            else
            {
               RowToVars17( bcFrotaVeiculo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFrotaVeiculo.gxTpr_Mode, "") == 0 )
            {
               bcFrotaVeiculo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars17( bcFrotaVeiculo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtFrotaVeiculo FrotaVeiculo_BC
      {
         get {
            return bcFrotaVeiculo ;
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
            return "frotaveiculo_Execute" ;
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
         BC000G6_A93FrotaId = new int[1] ;
         BC000G6_A98VeiculoId = new int[1] ;
         BC000G4_A93FrotaId = new int[1] ;
         BC000G5_A98VeiculoId = new int[1] ;
         BC000G7_A93FrotaId = new int[1] ;
         BC000G7_A98VeiculoId = new int[1] ;
         BC000G3_A93FrotaId = new int[1] ;
         BC000G3_A98VeiculoId = new int[1] ;
         sMode17 = "";
         BC000G2_A93FrotaId = new int[1] ;
         BC000G2_A98VeiculoId = new int[1] ;
         BC000G10_A93FrotaId = new int[1] ;
         BC000G10_A98VeiculoId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000G11_A93FrotaId = new int[1] ;
         BC000G12_A98VeiculoId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.frotaveiculo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frotaveiculo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A93FrotaId, BC000G2_A98VeiculoId
               }
               , new Object[] {
               BC000G3_A93FrotaId, BC000G3_A98VeiculoId
               }
               , new Object[] {
               BC000G4_A93FrotaId
               }
               , new Object[] {
               BC000G5_A98VeiculoId
               }
               , new Object[] {
               BC000G6_A93FrotaId, BC000G6_A98VeiculoId
               }
               , new Object[] {
               BC000G7_A93FrotaId, BC000G7_A98VeiculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G10_A93FrotaId, BC000G10_A98VeiculoId
               }
               , new Object[] {
               BC000G11_A93FrotaId
               }
               , new Object[] {
               BC000G12_A98VeiculoId
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
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private int trnEnded ;
      private int Z93FrotaId ;
      private int A93FrotaId ;
      private int Z98VeiculoId ;
      private int A98VeiculoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode17 ;
      private bool mustCommit ;
      private SdtFrotaVeiculo bcFrotaVeiculo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000G6_A93FrotaId ;
      private int[] BC000G6_A98VeiculoId ;
      private int[] BC000G4_A93FrotaId ;
      private int[] BC000G5_A98VeiculoId ;
      private int[] BC000G7_A93FrotaId ;
      private int[] BC000G7_A98VeiculoId ;
      private int[] BC000G3_A93FrotaId ;
      private int[] BC000G3_A98VeiculoId ;
      private int[] BC000G2_A93FrotaId ;
      private int[] BC000G2_A98VeiculoId ;
      private int[] BC000G10_A93FrotaId ;
      private int[] BC000G10_A98VeiculoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC000G11_A93FrotaId ;
      private int[] BC000G12_A98VeiculoId ;
      private IDataStoreProvider pr_gam ;
   }

   public class frotaveiculo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class frotaveiculo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000G6;
        prmBC000G6 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G4;
        prmBC000G4 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G5;
        prmBC000G5 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G7;
        prmBC000G7 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G3;
        prmBC000G3 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G2;
        prmBC000G2 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G8;
        prmBC000G8 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G9;
        prmBC000G9 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G10;
        prmBC000G10 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G11;
        prmBC000G11 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000G12;
        prmBC000G12 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000G2", "SELECT [FrotaId], [VeiculoId] FROM [FrotaVeiculo] WITH (UPDLOCK) WHERE [FrotaId] = @FrotaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G3", "SELECT [FrotaId], [VeiculoId] FROM [FrotaVeiculo] WHERE [FrotaId] = @FrotaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G4", "SELECT [FrotaId] FROM [Frota] WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G5", "SELECT [VeiculoId] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G6", "SELECT TM1.[FrotaId], TM1.[VeiculoId] FROM [FrotaVeiculo] TM1 WHERE TM1.[FrotaId] = @FrotaId and TM1.[VeiculoId] = @VeiculoId ORDER BY TM1.[FrotaId], TM1.[VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G7", "SELECT [FrotaId], [VeiculoId] FROM [FrotaVeiculo] WHERE [FrotaId] = @FrotaId AND [VeiculoId] = @VeiculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G8", "INSERT INTO [FrotaVeiculo]([FrotaId], [VeiculoId]) VALUES(@FrotaId, @VeiculoId)", GxErrorMask.GX_NOMASK,prmBC000G8)
           ,new CursorDef("BC000G9", "DELETE FROM [FrotaVeiculo]  WHERE [FrotaId] = @FrotaId AND [VeiculoId] = @VeiculoId", GxErrorMask.GX_NOMASK,prmBC000G9)
           ,new CursorDef("BC000G10", "SELECT TM1.[FrotaId], TM1.[VeiculoId] FROM [FrotaVeiculo] TM1 WHERE TM1.[FrotaId] = @FrotaId and TM1.[VeiculoId] = @VeiculoId ORDER BY TM1.[FrotaId], TM1.[VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G11", "SELECT [FrotaId] FROM [Frota] WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G12", "SELECT [VeiculoId] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G12,1, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 8 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 9 :
              table[0][0] = rslt.getInt(1);
              return;
           case 10 :
              table[0][0] = rslt.getInt(1);
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
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 2 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 5 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 6 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 7 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 9 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
