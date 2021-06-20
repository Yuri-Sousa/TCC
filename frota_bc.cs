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
   public class frota_bc : GXHttpHandler, IGxSilentTrn
   {
      public frota_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public frota_bc( IGxContext context )
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
         ReadRow0E15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E15( ) ;
         standaloneModal( ) ;
         AddRow0E15( ) ;
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
            /* Execute user event: After Trn */
            E110E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z93FrotaId = A93FrotaId;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E15( ) ;
            }
            else
            {
               CheckExtendedTable0E15( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0E15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E110E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z94FrotaDataHoraCriacao = A94FrotaDataHoraCriacao;
            Z95FrotaNome = A95FrotaNome;
            Z96FrotaProprietarioGAMGUID = A96FrotaProprietarioGAMGUID;
         }
         if ( GX_JID == -5 )
         {
            Z93FrotaId = A93FrotaId;
            Z94FrotaDataHoraCriacao = A94FrotaDataHoraCriacao;
            Z95FrotaNome = A95FrotaNome;
            Z96FrotaProprietarioGAMGUID = A96FrotaProprietarioGAMGUID;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A94FrotaDataHoraCriacao) && ( Gx_BScreen == 0 ) )
         {
            A94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A96FrotaProprietarioGAMGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A96FrotaProprietarioGAMGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A96FrotaProprietarioGAMGUID = GXt_char1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0E15( )
      {
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound15 = 1;
            A94FrotaDataHoraCriacao = BC000E4_A94FrotaDataHoraCriacao[0];
            A95FrotaNome = BC000E4_A95FrotaNome[0];
            A96FrotaProprietarioGAMGUID = BC000E4_A96FrotaProprietarioGAMGUID[0];
            ZM0E15( -5) ;
         }
         pr_default.close(2);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         nIsDirty_15 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A94FrotaDataHoraCriacao) || ( A94FrotaDataHoraCriacao >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Data/Hora da Criação fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A95FrotaNome)) )
         {
            GX_msglist.addItem("Informe o nome da frota.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0E15( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E15( )
      {
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {A93FrotaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 5) ;
            RcdFound15 = 1;
            A93FrotaId = BC000E3_A93FrotaId[0];
            A94FrotaDataHoraCriacao = BC000E3_A94FrotaDataHoraCriacao[0];
            A95FrotaNome = BC000E3_A95FrotaNome[0];
            A96FrotaProprietarioGAMGUID = BC000E3_A96FrotaProprietarioGAMGUID[0];
            Z93FrotaId = A93FrotaId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0E0( ) ;
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

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {A93FrotaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Frota"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z94FrotaDataHoraCriacao != BC000E2_A94FrotaDataHoraCriacao[0] ) || ( StringUtil.StrCmp(Z95FrotaNome, BC000E2_A95FrotaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z96FrotaProprietarioGAMGUID, BC000E2_A96FrotaProprietarioGAMGUID[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Frota"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E6 */
                     pr_default.execute(4, new Object[] {A94FrotaDataHoraCriacao, A95FrotaNome, A96FrotaProprietarioGAMGUID});
                     A93FrotaId = BC000E6_A93FrotaId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Frota");
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
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E7 */
                     pr_default.execute(5, new Object[] {A94FrotaDataHoraCriacao, A95FrotaNome, A96FrotaProprietarioGAMGUID, A93FrotaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Frota");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Frota"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
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
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E8 */
                  pr_default.execute(6, new Object[] {A93FrotaId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Frota");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000E9 */
            pr_default.execute(7, new Object[] {A93FrotaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Frota Veiculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
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

      public void ScanKeyStart0E15( )
      {
         /* Scan By routine */
         /* Using cursor BC000E10 */
         pr_default.execute(8, new Object[] {A93FrotaId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
            A93FrotaId = BC000E10_A93FrotaId[0];
            A94FrotaDataHoraCriacao = BC000E10_A94FrotaDataHoraCriacao[0];
            A95FrotaNome = BC000E10_A95FrotaNome[0];
            A96FrotaProprietarioGAMGUID = BC000E10_A96FrotaProprietarioGAMGUID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound15 = 0;
         ScanKeyLoad0E15( ) ;
      }

      protected void ScanKeyLoad0E15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
            A93FrotaId = BC000E10_A93FrotaId[0];
            A94FrotaDataHoraCriacao = BC000E10_A94FrotaDataHoraCriacao[0];
            A95FrotaNome = BC000E10_A95FrotaNome[0];
            A96FrotaProprietarioGAMGUID = BC000E10_A96FrotaProprietarioGAMGUID[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0E15( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0E15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void AddRow0E15( )
      {
         VarsToRow15( bcFrota) ;
      }

      protected void ReadRow0E15( )
      {
         RowToVars15( bcFrota, 1) ;
      }

      protected void InitializeNonKey0E15( )
      {
         A95FrotaNome = "";
         A94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         A96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z95FrotaNome = "";
         Z96FrotaProprietarioGAMGUID = "";
      }

      protected void InitAll0E15( )
      {
         A93FrotaId = 0;
         InitializeNonKey0E15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A94FrotaDataHoraCriacao = i94FrotaDataHoraCriacao;
         A96FrotaProprietarioGAMGUID = i96FrotaProprietarioGAMGUID;
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

      public void VarsToRow15( SdtFrota obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Frotanome = A95FrotaNome;
         obj15.gxTpr_Frotadatahoracriacao = A94FrotaDataHoraCriacao;
         obj15.gxTpr_Frotaproprietariogamguid = A96FrotaProprietarioGAMGUID;
         obj15.gxTpr_Frotaid = A93FrotaId;
         obj15.gxTpr_Frotaid_Z = Z93FrotaId;
         obj15.gxTpr_Frotadatahoracriacao_Z = Z94FrotaDataHoraCriacao;
         obj15.gxTpr_Frotanome_Z = Z95FrotaNome;
         obj15.gxTpr_Frotaproprietariogamguid_Z = Z96FrotaProprietarioGAMGUID;
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( SdtFrota obj15 )
      {
         obj15.gxTpr_Frotaid = A93FrotaId;
         return  ;
      }

      public void RowToVars15( SdtFrota obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A95FrotaNome = obj15.gxTpr_Frotanome;
         A94FrotaDataHoraCriacao = obj15.gxTpr_Frotadatahoracriacao;
         A96FrotaProprietarioGAMGUID = obj15.gxTpr_Frotaproprietariogamguid;
         A93FrotaId = obj15.gxTpr_Frotaid;
         Z93FrotaId = obj15.gxTpr_Frotaid_Z;
         Z94FrotaDataHoraCriacao = obj15.gxTpr_Frotadatahoracriacao_Z;
         Z95FrotaNome = obj15.gxTpr_Frotanome_Z;
         Z96FrotaProprietarioGAMGUID = obj15.gxTpr_Frotaproprietariogamguid_Z;
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A93FrotaId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E15( ) ;
         ScanKeyStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z93FrotaId = A93FrotaId;
         }
         ZM0E15( -5) ;
         OnLoadActions0E15( ) ;
         AddRow0E15( ) ;
         ScanKeyEnd0E15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcFrota, 0) ;
         ScanKeyStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z93FrotaId = A93FrotaId;
         }
         ZM0E15( -5) ;
         OnLoadActions0E15( ) ;
         AddRow0E15( ) ;
         ScanKeyEnd0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A93FrotaId != Z93FrotaId )
               {
                  A93FrotaId = Z93FrotaId;
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
                  Update0E15( ) ;
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
                  if ( A93FrotaId != Z93FrotaId )
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
                        Insert0E15( ) ;
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
                        Insert0E15( ) ;
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
         RowToVars15( bcFrota, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcFrota) ;
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
         RowToVars15( bcFrota, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcFrota) ;
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
            SdtFrota auxBC = new SdtFrota(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A93FrotaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFrota);
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
         RowToVars15( bcFrota, 1) ;
         UpdateImpl( ) ;
         VarsToRow15( bcFrota) ;
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
         RowToVars15( bcFrota, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E15( ) ;
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
         VarsToRow15( bcFrota) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars15( bcFrota, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0E15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A93FrotaId != Z93FrotaId )
            {
               A93FrotaId = Z93FrotaId;
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
            if ( A93FrotaId != Z93FrotaId )
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
         context.RollbackDataStores("frota_bc",pr_default);
         VarsToRow15( bcFrota) ;
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
         Gx_mode = bcFrota.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFrota.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFrota )
         {
            bcFrota = (SdtFrota)(sdt);
            if ( StringUtil.StrCmp(bcFrota.gxTpr_Mode, "") == 0 )
            {
               bcFrota.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcFrota) ;
            }
            else
            {
               RowToVars15( bcFrota, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFrota.gxTpr_Mode, "") == 0 )
            {
               bcFrota.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcFrota, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtFrota Frota_BC
      {
         get {
            return bcFrota ;
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
            return "frota_Execute" ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         A94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z95FrotaNome = "";
         A95FrotaNome = "";
         Z96FrotaProprietarioGAMGUID = "";
         A96FrotaProprietarioGAMGUID = "";
         GXt_char1 = "";
         BC000E4_A93FrotaId = new int[1] ;
         BC000E4_A94FrotaDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000E4_A95FrotaNome = new string[] {""} ;
         BC000E4_A96FrotaProprietarioGAMGUID = new string[] {""} ;
         BC000E5_A93FrotaId = new int[1] ;
         BC000E3_A93FrotaId = new int[1] ;
         BC000E3_A94FrotaDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000E3_A95FrotaNome = new string[] {""} ;
         BC000E3_A96FrotaProprietarioGAMGUID = new string[] {""} ;
         sMode15 = "";
         BC000E2_A93FrotaId = new int[1] ;
         BC000E2_A94FrotaDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000E2_A95FrotaNome = new string[] {""} ;
         BC000E2_A96FrotaProprietarioGAMGUID = new string[] {""} ;
         BC000E6_A93FrotaId = new int[1] ;
         BC000E9_A93FrotaId = new int[1] ;
         BC000E9_A98VeiculoId = new int[1] ;
         BC000E10_A93FrotaId = new int[1] ;
         BC000E10_A94FrotaDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000E10_A95FrotaNome = new string[] {""} ;
         BC000E10_A96FrotaProprietarioGAMGUID = new string[] {""} ;
         i94FrotaDataHoraCriacao = (DateTime)(DateTime.MinValue);
         i96FrotaProprietarioGAMGUID = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.frota_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frota_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A93FrotaId, BC000E2_A94FrotaDataHoraCriacao, BC000E2_A95FrotaNome, BC000E2_A96FrotaProprietarioGAMGUID
               }
               , new Object[] {
               BC000E3_A93FrotaId, BC000E3_A94FrotaDataHoraCriacao, BC000E3_A95FrotaNome, BC000E3_A96FrotaProprietarioGAMGUID
               }
               , new Object[] {
               BC000E4_A93FrotaId, BC000E4_A94FrotaDataHoraCriacao, BC000E4_A95FrotaNome, BC000E4_A96FrotaProprietarioGAMGUID
               }
               , new Object[] {
               BC000E5_A93FrotaId
               }
               , new Object[] {
               BC000E6_A93FrotaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E9_A93FrotaId, BC000E9_A98VeiculoId
               }
               , new Object[] {
               BC000E10_A93FrotaId, BC000E10_A94FrotaDataHoraCriacao, BC000E10_A95FrotaNome, BC000E10_A96FrotaProprietarioGAMGUID
               }
            }
         );
         Z96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         A96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         i96FrotaProprietarioGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         A94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         i94FrotaDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120E2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private int trnEnded ;
      private int Z93FrotaId ;
      private int A93FrotaId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z96FrotaProprietarioGAMGUID ;
      private string A96FrotaProprietarioGAMGUID ;
      private string GXt_char1 ;
      private string sMode15 ;
      private string i96FrotaProprietarioGAMGUID ;
      private DateTime Z94FrotaDataHoraCriacao ;
      private DateTime A94FrotaDataHoraCriacao ;
      private DateTime i94FrotaDataHoraCriacao ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z95FrotaNome ;
      private string A95FrotaNome ;
      private IGxSession AV12WebSession ;
      private SdtFrota bcFrota ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000E4_A93FrotaId ;
      private DateTime[] BC000E4_A94FrotaDataHoraCriacao ;
      private string[] BC000E4_A95FrotaNome ;
      private string[] BC000E4_A96FrotaProprietarioGAMGUID ;
      private int[] BC000E5_A93FrotaId ;
      private int[] BC000E3_A93FrotaId ;
      private DateTime[] BC000E3_A94FrotaDataHoraCriacao ;
      private string[] BC000E3_A95FrotaNome ;
      private string[] BC000E3_A96FrotaProprietarioGAMGUID ;
      private int[] BC000E2_A93FrotaId ;
      private DateTime[] BC000E2_A94FrotaDataHoraCriacao ;
      private string[] BC000E2_A95FrotaNome ;
      private string[] BC000E2_A96FrotaProprietarioGAMGUID ;
      private int[] BC000E6_A93FrotaId ;
      private int[] BC000E9_A93FrotaId ;
      private int[] BC000E9_A98VeiculoId ;
      private int[] BC000E10_A93FrotaId ;
      private DateTime[] BC000E10_A94FrotaDataHoraCriacao ;
      private string[] BC000E10_A95FrotaNome ;
      private string[] BC000E10_A96FrotaProprietarioGAMGUID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class frota_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class frota_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000E4;
        prmBC000E4 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000E5;
        prmBC000E5 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000E3;
        prmBC000E3 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000E2;
        prmBC000E2 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000E6;
        prmBC000E6 = new Object[] {
        new Object[] {"@FrotaDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@FrotaNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@FrotaProprietarioGAMGUID",SqlDbType.NChar,40,0}
        };
        Object[] prmBC000E7;
        prmBC000E7 = new Object[] {
        new Object[] {"@FrotaDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@FrotaNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@FrotaProprietarioGAMGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000E8;
        prmBC000E8 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000E9;
        prmBC000E9 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000E10;
        prmBC000E10 = new Object[] {
        new Object[] {"@FrotaId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000E2", "SELECT [FrotaId], [FrotaDataHoraCriacao], [FrotaNome], [FrotaProprietarioGAMGUID] FROM [Frota] WITH (UPDLOCK) WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E3", "SELECT [FrotaId], [FrotaDataHoraCriacao], [FrotaNome], [FrotaProprietarioGAMGUID] FROM [Frota] WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E4", "SELECT TM1.[FrotaId], TM1.[FrotaDataHoraCriacao], TM1.[FrotaNome], TM1.[FrotaProprietarioGAMGUID] FROM [Frota] TM1 WHERE TM1.[FrotaId] = @FrotaId ORDER BY TM1.[FrotaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E5", "SELECT [FrotaId] FROM [Frota] WHERE [FrotaId] = @FrotaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E6", "INSERT INTO [Frota]([FrotaDataHoraCriacao], [FrotaNome], [FrotaProprietarioGAMGUID]) VALUES(@FrotaDataHoraCriacao, @FrotaNome, @FrotaProprietarioGAMGUID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000E6)
           ,new CursorDef("BC000E7", "UPDATE [Frota] SET [FrotaDataHoraCriacao]=@FrotaDataHoraCriacao, [FrotaNome]=@FrotaNome, [FrotaProprietarioGAMGUID]=@FrotaProprietarioGAMGUID  WHERE [FrotaId] = @FrotaId", GxErrorMask.GX_NOMASK,prmBC000E7)
           ,new CursorDef("BC000E8", "DELETE FROM [Frota]  WHERE [FrotaId] = @FrotaId", GxErrorMask.GX_NOMASK,prmBC000E8)
           ,new CursorDef("BC000E9", "SELECT TOP 1 [FrotaId], [VeiculoId] FROM [FrotaVeiculo] WHERE [FrotaId] = @FrotaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E10", "SELECT TM1.[FrotaId], TM1.[FrotaDataHoraCriacao], TM1.[FrotaNome], TM1.[FrotaProprietarioGAMGUID] FROM [Frota] TM1 WHERE TM1.[FrotaId] = @FrotaId ORDER BY TM1.[FrotaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E10,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
              return;
           case 7 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 8 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getString(4, 40);
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
              return;
           case 1 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 2 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 4 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              return;
           case 5 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              return;
           case 6 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
