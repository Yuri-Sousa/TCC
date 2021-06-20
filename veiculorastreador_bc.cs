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
   public class veiculorastreador_bc : GXHttpHandler, IGxSilentTrn
   {
      public veiculorastreador_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public veiculorastreador_bc( IGxContext context )
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
         ReadRow0K21( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0K21( ) ;
         standaloneModal( ) ;
         AddRow0K21( ) ;
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
               Z98VeiculoId = A98VeiculoId;
               Z106RastreadorId = A106RastreadorId;
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

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K21( ) ;
            }
            else
            {
               CheckExtendedTable0K21( ) ;
               if ( AnyError == 0 )
               {
                  ZM0K21( 2) ;
                  ZM0K21( 3) ;
               }
               CloseExtendedTableCursors0K21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0K21( short GX_JID )
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
            Z98VeiculoId = A98VeiculoId;
            Z106RastreadorId = A106RastreadorId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0K21( )
      {
         /* Using cursor BC000K6 */
         pr_default.execute(4, new Object[] {A98VeiculoId, A106RastreadorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound21 = 1;
            ZM0K21( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0K21( ) ;
      }

      protected void OnLoadActions0K21( )
      {
      }

      protected void CheckExtendedTable0K21( )
      {
         nIsDirty_21 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000K4 */
         pr_default.execute(2, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Veiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC000K5 */
         pr_default.execute(3, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Rastreador'.", "ForeignKeyNotFound", 1, "RASTREADORID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0K21( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K21( )
      {
         /* Using cursor BC000K7 */
         pr_default.execute(5, new Object[] {A98VeiculoId, A106RastreadorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000K3 */
         pr_default.execute(1, new Object[] {A98VeiculoId, A106RastreadorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K21( 1) ;
            RcdFound21 = 1;
            A98VeiculoId = BC000K3_A98VeiculoId[0];
            A106RastreadorId = BC000K3_A106RastreadorId[0];
            Z98VeiculoId = A98VeiculoId;
            Z106RastreadorId = A106RastreadorId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0K21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0K21( ) ;
            }
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0K21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode21;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K21( ) ;
         if ( RcdFound21 == 0 )
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
         CONFIRM_0K0( ) ;
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

      protected void CheckOptimisticConcurrency0K21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000K2 */
            pr_default.execute(0, new Object[] {A98VeiculoId, A106RastreadorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VeiculoRastreador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"VeiculoRastreador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K21( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K21( 0) ;
            CheckOptimisticConcurrency0K21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K8 */
                     pr_default.execute(6, new Object[] {A98VeiculoId, A106RastreadorId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("VeiculoRastreador");
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
               Load0K21( ) ;
            }
            EndLevel0K21( ) ;
         }
         CloseExtendedTableCursors0K21( ) ;
      }

      protected void Update0K21( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [VeiculoRastreador] */
                     DeferredUpdate0K21( ) ;
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
            EndLevel0K21( ) ;
         }
         CloseExtendedTableCursors0K21( ) ;
      }

      protected void DeferredUpdate0K21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K21( ) ;
            AfterConfirm0K21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000K9 */
                  pr_default.execute(7, new Object[] {A98VeiculoId, A106RastreadorId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("VeiculoRastreador");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0K21( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0K21( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0K21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K21( ) ;
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

      public void ScanKeyStart0K21( )
      {
         /* Using cursor BC000K10 */
         pr_default.execute(8, new Object[] {A98VeiculoId, A106RastreadorId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound21 = 1;
            A98VeiculoId = BC000K10_A98VeiculoId[0];
            A106RastreadorId = BC000K10_A106RastreadorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0K21( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound21 = 0;
         ScanKeyLoad0K21( ) ;
      }

      protected void ScanKeyLoad0K21( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound21 = 1;
            A98VeiculoId = BC000K10_A98VeiculoId[0];
            A106RastreadorId = BC000K10_A106RastreadorId[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0K21( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0K21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K21( )
      {
      }

      protected void send_integrity_lvl_hashes0K21( )
      {
      }

      protected void AddRow0K21( )
      {
         VarsToRow21( bcVeiculoRastreador) ;
      }

      protected void ReadRow0K21( )
      {
         RowToVars21( bcVeiculoRastreador, 1) ;
      }

      protected void InitializeNonKey0K21( )
      {
      }

      protected void InitAll0K21( )
      {
         A98VeiculoId = 0;
         A106RastreadorId = 0;
         InitializeNonKey0K21( ) ;
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

      public void VarsToRow21( SdtVeiculoRastreador obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Veiculoid = A98VeiculoId;
         obj21.gxTpr_Rastreadorid = A106RastreadorId;
         obj21.gxTpr_Veiculoid_Z = Z98VeiculoId;
         obj21.gxTpr_Rastreadorid_Z = Z106RastreadorId;
         obj21.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow21( SdtVeiculoRastreador obj21 )
      {
         obj21.gxTpr_Veiculoid = A98VeiculoId;
         obj21.gxTpr_Rastreadorid = A106RastreadorId;
         return  ;
      }

      public void RowToVars21( SdtVeiculoRastreador obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A98VeiculoId = obj21.gxTpr_Veiculoid;
         A106RastreadorId = obj21.gxTpr_Rastreadorid;
         Z98VeiculoId = obj21.gxTpr_Veiculoid_Z;
         Z106RastreadorId = obj21.gxTpr_Rastreadorid_Z;
         Gx_mode = obj21.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A98VeiculoId = (int)getParm(obj,0);
         A106RastreadorId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0K21( ) ;
         ScanKeyStart0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000K11 */
            pr_default.execute(9, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Veiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000K12 */
            pr_default.execute(10, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Rastreador'.", "ForeignKeyNotFound", 1, "RASTREADORID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z98VeiculoId = A98VeiculoId;
            Z106RastreadorId = A106RastreadorId;
         }
         ZM0K21( -1) ;
         OnLoadActions0K21( ) ;
         AddRow0K21( ) ;
         ScanKeyEnd0K21( ) ;
         if ( RcdFound21 == 0 )
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
         RowToVars21( bcVeiculoRastreador, 0) ;
         ScanKeyStart0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000K11 */
            pr_default.execute(9, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Veiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000K12 */
            pr_default.execute(10, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Rastreador'.", "ForeignKeyNotFound", 1, "RASTREADORID");
               AnyError = 1;
            }
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z98VeiculoId = A98VeiculoId;
            Z106RastreadorId = A106RastreadorId;
         }
         ZM0K21( -1) ;
         OnLoadActions0K21( ) ;
         AddRow0K21( ) ;
         ScanKeyEnd0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0K21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0K21( ) ;
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( ( A98VeiculoId != Z98VeiculoId ) || ( A106RastreadorId != Z106RastreadorId ) )
               {
                  A98VeiculoId = Z98VeiculoId;
                  A106RastreadorId = Z106RastreadorId;
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
                  Update0K21( ) ;
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
                  if ( ( A98VeiculoId != Z98VeiculoId ) || ( A106RastreadorId != Z106RastreadorId ) )
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
                        Insert0K21( ) ;
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
                        Insert0K21( ) ;
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
         RowToVars21( bcVeiculoRastreador, 1) ;
         SaveImpl( ) ;
         VarsToRow21( bcVeiculoRastreador) ;
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
         RowToVars21( bcVeiculoRastreador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K21( ) ;
         AfterTrn( ) ;
         VarsToRow21( bcVeiculoRastreador) ;
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
            SdtVeiculoRastreador auxBC = new SdtVeiculoRastreador(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A98VeiculoId, A106RastreadorId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcVeiculoRastreador);
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
         RowToVars21( bcVeiculoRastreador, 1) ;
         UpdateImpl( ) ;
         VarsToRow21( bcVeiculoRastreador) ;
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
         RowToVars21( bcVeiculoRastreador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K21( ) ;
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
         VarsToRow21( bcVeiculoRastreador) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars21( bcVeiculoRastreador, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0K21( ) ;
         if ( RcdFound21 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A98VeiculoId != Z98VeiculoId ) || ( A106RastreadorId != Z106RastreadorId ) )
            {
               A98VeiculoId = Z98VeiculoId;
               A106RastreadorId = Z106RastreadorId;
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
            if ( ( A98VeiculoId != Z98VeiculoId ) || ( A106RastreadorId != Z106RastreadorId ) )
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
         context.RollbackDataStores("veiculorastreador_bc",pr_default);
         VarsToRow21( bcVeiculoRastreador) ;
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
         Gx_mode = bcVeiculoRastreador.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcVeiculoRastreador.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcVeiculoRastreador )
         {
            bcVeiculoRastreador = (SdtVeiculoRastreador)(sdt);
            if ( StringUtil.StrCmp(bcVeiculoRastreador.gxTpr_Mode, "") == 0 )
            {
               bcVeiculoRastreador.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow21( bcVeiculoRastreador) ;
            }
            else
            {
               RowToVars21( bcVeiculoRastreador, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcVeiculoRastreador.gxTpr_Mode, "") == 0 )
            {
               bcVeiculoRastreador.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars21( bcVeiculoRastreador, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtVeiculoRastreador VeiculoRastreador_BC
      {
         get {
            return bcVeiculoRastreador ;
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
            return "veiculorastreador_Execute" ;
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
         BC000K6_A98VeiculoId = new int[1] ;
         BC000K6_A106RastreadorId = new int[1] ;
         BC000K4_A98VeiculoId = new int[1] ;
         BC000K5_A106RastreadorId = new int[1] ;
         BC000K7_A98VeiculoId = new int[1] ;
         BC000K7_A106RastreadorId = new int[1] ;
         BC000K3_A98VeiculoId = new int[1] ;
         BC000K3_A106RastreadorId = new int[1] ;
         sMode21 = "";
         BC000K2_A98VeiculoId = new int[1] ;
         BC000K2_A106RastreadorId = new int[1] ;
         BC000K10_A98VeiculoId = new int[1] ;
         BC000K10_A106RastreadorId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000K11_A98VeiculoId = new int[1] ;
         BC000K12_A106RastreadorId = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.veiculorastreador_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.veiculorastreador_bc__default(),
            new Object[][] {
                new Object[] {
               BC000K2_A98VeiculoId, BC000K2_A106RastreadorId
               }
               , new Object[] {
               BC000K3_A98VeiculoId, BC000K3_A106RastreadorId
               }
               , new Object[] {
               BC000K4_A98VeiculoId
               }
               , new Object[] {
               BC000K5_A106RastreadorId
               }
               , new Object[] {
               BC000K6_A98VeiculoId, BC000K6_A106RastreadorId
               }
               , new Object[] {
               BC000K7_A98VeiculoId, BC000K7_A106RastreadorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K10_A98VeiculoId, BC000K10_A106RastreadorId
               }
               , new Object[] {
               BC000K11_A98VeiculoId
               }
               , new Object[] {
               BC000K12_A106RastreadorId
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
      private short RcdFound21 ;
      private short nIsDirty_21 ;
      private int trnEnded ;
      private int Z98VeiculoId ;
      private int A98VeiculoId ;
      private int Z106RastreadorId ;
      private int A106RastreadorId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode21 ;
      private bool mustCommit ;
      private SdtVeiculoRastreador bcVeiculoRastreador ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000K6_A98VeiculoId ;
      private int[] BC000K6_A106RastreadorId ;
      private int[] BC000K4_A98VeiculoId ;
      private int[] BC000K5_A106RastreadorId ;
      private int[] BC000K7_A98VeiculoId ;
      private int[] BC000K7_A106RastreadorId ;
      private int[] BC000K3_A98VeiculoId ;
      private int[] BC000K3_A106RastreadorId ;
      private int[] BC000K2_A98VeiculoId ;
      private int[] BC000K2_A106RastreadorId ;
      private int[] BC000K10_A98VeiculoId ;
      private int[] BC000K10_A106RastreadorId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] BC000K11_A98VeiculoId ;
      private int[] BC000K12_A106RastreadorId ;
      private IDataStoreProvider pr_gam ;
   }

   public class veiculorastreador_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class veiculorastreador_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000K6;
        prmBC000K6 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K4;
        prmBC000K4 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K5;
        prmBC000K5 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K7;
        prmBC000K7 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K3;
        prmBC000K3 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K2;
        prmBC000K2 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K8;
        prmBC000K8 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K9;
        prmBC000K9 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K10;
        prmBC000K10 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K11;
        prmBC000K11 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000K12;
        prmBC000K12 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000K2", "SELECT [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WITH (UPDLOCK) WHERE [VeiculoId] = @VeiculoId AND [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K3", "SELECT [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @VeiculoId AND [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K4", "SELECT [VeiculoId] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K5", "SELECT [RastreadorId] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K6", "SELECT TM1.[VeiculoId], TM1.[RastreadorId] FROM [VeiculoRastreador] TM1 WHERE TM1.[VeiculoId] = @VeiculoId and TM1.[RastreadorId] = @RastreadorId ORDER BY TM1.[VeiculoId], TM1.[RastreadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K7", "SELECT [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @VeiculoId AND [RastreadorId] = @RastreadorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K8", "INSERT INTO [VeiculoRastreador]([VeiculoId], [RastreadorId]) VALUES(@VeiculoId, @RastreadorId)", GxErrorMask.GX_NOMASK,prmBC000K8)
           ,new CursorDef("BC000K9", "DELETE FROM [VeiculoRastreador]  WHERE [VeiculoId] = @VeiculoId AND [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK,prmBC000K9)
           ,new CursorDef("BC000K10", "SELECT TM1.[VeiculoId], TM1.[RastreadorId] FROM [VeiculoRastreador] TM1 WHERE TM1.[VeiculoId] = @VeiculoId and TM1.[RastreadorId] = @RastreadorId ORDER BY TM1.[VeiculoId], TM1.[RastreadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K11", "SELECT [VeiculoId] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K12", "SELECT [RastreadorId] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K12,1, GxCacheFrequency.OFF ,true,false )
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
