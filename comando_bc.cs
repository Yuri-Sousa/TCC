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
   public class comando_bc : GXHttpHandler, IGxSilentTrn
   {
      public comando_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public comando_bc( IGxContext context )
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
         ReadRow0M23( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0M23( ) ;
         standaloneModal( ) ;
         AddRow0M23( ) ;
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
            E110M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z137ComandoId = A137ComandoId;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M23( ) ;
            }
            else
            {
               CheckExtendedTable0M23( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0M23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E110M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0M23( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z138ComandoNome = A138ComandoNome;
            Z139ComandoDescricao = A139ComandoDescricao;
            Z140ComandoFabricanteModulo = A140ComandoFabricanteModulo;
            Z141ComandoModeloModulo = A141ComandoModeloModulo;
            Z143ComandoParameter_Id = A143ComandoParameter_Id;
         }
         if ( GX_JID == -8 )
         {
            Z137ComandoId = A137ComandoId;
            Z138ComandoNome = A138ComandoNome;
            Z139ComandoDescricao = A139ComandoDescricao;
            Z140ComandoFabricanteModulo = A140ComandoFabricanteModulo;
            Z141ComandoModeloModulo = A141ComandoModeloModulo;
            Z142ComandoPayload = A142ComandoPayload;
            Z143ComandoParameter_Id = A143ComandoParameter_Id;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0M23( )
      {
         /* Using cursor BC000M4 */
         pr_default.execute(2, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A138ComandoNome = BC000M4_A138ComandoNome[0];
            A139ComandoDescricao = BC000M4_A139ComandoDescricao[0];
            A140ComandoFabricanteModulo = BC000M4_A140ComandoFabricanteModulo[0];
            A141ComandoModeloModulo = BC000M4_A141ComandoModeloModulo[0];
            A142ComandoPayload = BC000M4_A142ComandoPayload[0];
            A143ComandoParameter_Id = BC000M4_A143ComandoParameter_Id[0];
            ZM0M23( -8) ;
         }
         pr_default.close(2);
         OnLoadActions0M23( ) ;
      }

      protected void OnLoadActions0M23( )
      {
      }

      protected void CheckExtendedTable0M23( )
      {
         nIsDirty_23 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A138ComandoNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A139ComandoDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A140ComandoFabricanteModulo, "Maxtrack") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Fabricante fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A141ComandoModeloModulo, "MXT140") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Modelo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141ComandoModeloModulo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Modelo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A142ComandoPayload)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Comando", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A143ComandoParameter_Id)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parameter_id", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0M23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M23( )
      {
         /* Using cursor BC000M5 */
         pr_default.execute(3, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000M3 */
         pr_default.execute(1, new Object[] {A137ComandoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M23( 8) ;
            RcdFound23 = 1;
            A137ComandoId = BC000M3_A137ComandoId[0];
            A138ComandoNome = BC000M3_A138ComandoNome[0];
            A139ComandoDescricao = BC000M3_A139ComandoDescricao[0];
            A140ComandoFabricanteModulo = BC000M3_A140ComandoFabricanteModulo[0];
            A141ComandoModeloModulo = BC000M3_A141ComandoModeloModulo[0];
            A142ComandoPayload = BC000M3_A142ComandoPayload[0];
            A143ComandoParameter_Id = BC000M3_A143ComandoParameter_Id[0];
            Z137ComandoId = A137ComandoId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0M23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0M23( ) ;
            }
            Gx_mode = sMode23;
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0M23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode23;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M23( ) ;
         if ( RcdFound23 == 0 )
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
         CONFIRM_0M0( ) ;
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

      protected void CheckOptimisticConcurrency0M23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000M2 */
            pr_default.execute(0, new Object[] {A137ComandoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comando"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z138ComandoNome, BC000M2_A138ComandoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z139ComandoDescricao, BC000M2_A139ComandoDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z140ComandoFabricanteModulo, BC000M2_A140ComandoFabricanteModulo[0]) != 0 ) || ( StringUtil.StrCmp(Z141ComandoModeloModulo, BC000M2_A141ComandoModeloModulo[0]) != 0 ) || ( StringUtil.StrCmp(Z143ComandoParameter_Id, BC000M2_A143ComandoParameter_Id[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Comando"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M23( )
      {
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M23( 0) ;
            CheckOptimisticConcurrency0M23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M6 */
                     pr_default.execute(4, new Object[] {A138ComandoNome, A139ComandoDescricao, A140ComandoFabricanteModulo, A141ComandoModeloModulo, A142ComandoPayload, A143ComandoParameter_Id});
                     A137ComandoId = BC000M6_A137ComandoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Comando");
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
               Load0M23( ) ;
            }
            EndLevel0M23( ) ;
         }
         CloseExtendedTableCursors0M23( ) ;
      }

      protected void Update0M23( )
      {
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M7 */
                     pr_default.execute(5, new Object[] {A138ComandoNome, A139ComandoDescricao, A140ComandoFabricanteModulo, A141ComandoModeloModulo, A142ComandoPayload, A143ComandoParameter_Id, A137ComandoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Comando");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comando"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M23( ) ;
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
            EndLevel0M23( ) ;
         }
         CloseExtendedTableCursors0M23( ) ;
      }

      protected void DeferredUpdate0M23( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M23( ) ;
            AfterConfirm0M23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000M8 */
                  pr_default.execute(6, new Object[] {A137ComandoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Comando");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0M23( ) ;
         Gx_mode = sMode23;
      }

      protected void OnDeleteControls0M23( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0M23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M23( ) ;
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

      public void ScanKeyStart0M23( )
      {
         /* Scan By routine */
         /* Using cursor BC000M9 */
         pr_default.execute(7, new Object[] {A137ComandoId});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound23 = 1;
            A137ComandoId = BC000M9_A137ComandoId[0];
            A138ComandoNome = BC000M9_A138ComandoNome[0];
            A139ComandoDescricao = BC000M9_A139ComandoDescricao[0];
            A140ComandoFabricanteModulo = BC000M9_A140ComandoFabricanteModulo[0];
            A141ComandoModeloModulo = BC000M9_A141ComandoModeloModulo[0];
            A142ComandoPayload = BC000M9_A142ComandoPayload[0];
            A143ComandoParameter_Id = BC000M9_A143ComandoParameter_Id[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0M23( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound23 = 0;
         ScanKeyLoad0M23( ) ;
      }

      protected void ScanKeyLoad0M23( )
      {
         sMode23 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound23 = 1;
            A137ComandoId = BC000M9_A137ComandoId[0];
            A138ComandoNome = BC000M9_A138ComandoNome[0];
            A139ComandoDescricao = BC000M9_A139ComandoDescricao[0];
            A140ComandoFabricanteModulo = BC000M9_A140ComandoFabricanteModulo[0];
            A141ComandoModeloModulo = BC000M9_A141ComandoModeloModulo[0];
            A142ComandoPayload = BC000M9_A142ComandoPayload[0];
            A143ComandoParameter_Id = BC000M9_A143ComandoParameter_Id[0];
         }
         Gx_mode = sMode23;
      }

      protected void ScanKeyEnd0M23( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0M23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M23( )
      {
      }

      protected void send_integrity_lvl_hashes0M23( )
      {
      }

      protected void AddRow0M23( )
      {
         VarsToRow23( bcComando) ;
      }

      protected void ReadRow0M23( )
      {
         RowToVars23( bcComando, 1) ;
      }

      protected void InitializeNonKey0M23( )
      {
         A138ComandoNome = "";
         A139ComandoDescricao = "";
         A140ComandoFabricanteModulo = "";
         A141ComandoModeloModulo = "";
         A142ComandoPayload = "";
         A143ComandoParameter_Id = "";
         Z138ComandoNome = "";
         Z139ComandoDescricao = "";
         Z140ComandoFabricanteModulo = "";
         Z141ComandoModeloModulo = "";
         Z143ComandoParameter_Id = "";
      }

      protected void InitAll0M23( )
      {
         A137ComandoId = 0;
         InitializeNonKey0M23( ) ;
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

      public void VarsToRow23( SdtComando obj23 )
      {
         obj23.gxTpr_Mode = Gx_mode;
         obj23.gxTpr_Comandonome = A138ComandoNome;
         obj23.gxTpr_Comandodescricao = A139ComandoDescricao;
         obj23.gxTpr_Comandofabricantemodulo = A140ComandoFabricanteModulo;
         obj23.gxTpr_Comandomodelomodulo = A141ComandoModeloModulo;
         obj23.gxTpr_Comandopayload = A142ComandoPayload;
         obj23.gxTpr_Comandoparameter_id = A143ComandoParameter_Id;
         obj23.gxTpr_Comandoid = A137ComandoId;
         obj23.gxTpr_Comandoid_Z = Z137ComandoId;
         obj23.gxTpr_Comandonome_Z = Z138ComandoNome;
         obj23.gxTpr_Comandodescricao_Z = Z139ComandoDescricao;
         obj23.gxTpr_Comandofabricantemodulo_Z = Z140ComandoFabricanteModulo;
         obj23.gxTpr_Comandomodelomodulo_Z = Z141ComandoModeloModulo;
         obj23.gxTpr_Comandoparameter_id_Z = Z143ComandoParameter_Id;
         obj23.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow23( SdtComando obj23 )
      {
         obj23.gxTpr_Comandoid = A137ComandoId;
         return  ;
      }

      public void RowToVars23( SdtComando obj23 ,
                               int forceLoad )
      {
         Gx_mode = obj23.gxTpr_Mode;
         A138ComandoNome = obj23.gxTpr_Comandonome;
         A139ComandoDescricao = obj23.gxTpr_Comandodescricao;
         A140ComandoFabricanteModulo = obj23.gxTpr_Comandofabricantemodulo;
         A141ComandoModeloModulo = obj23.gxTpr_Comandomodelomodulo;
         A142ComandoPayload = obj23.gxTpr_Comandopayload;
         A143ComandoParameter_Id = obj23.gxTpr_Comandoparameter_id;
         A137ComandoId = obj23.gxTpr_Comandoid;
         Z137ComandoId = obj23.gxTpr_Comandoid_Z;
         Z138ComandoNome = obj23.gxTpr_Comandonome_Z;
         Z139ComandoDescricao = obj23.gxTpr_Comandodescricao_Z;
         Z140ComandoFabricanteModulo = obj23.gxTpr_Comandofabricantemodulo_Z;
         Z141ComandoModeloModulo = obj23.gxTpr_Comandomodelomodulo_Z;
         Z143ComandoParameter_Id = obj23.gxTpr_Comandoparameter_id_Z;
         Gx_mode = obj23.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A137ComandoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0M23( ) ;
         ScanKeyStart0M23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z137ComandoId = A137ComandoId;
         }
         ZM0M23( -8) ;
         OnLoadActions0M23( ) ;
         AddRow0M23( ) ;
         ScanKeyEnd0M23( ) ;
         if ( RcdFound23 == 0 )
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
         RowToVars23( bcComando, 0) ;
         ScanKeyStart0M23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z137ComandoId = A137ComandoId;
         }
         ZM0M23( -8) ;
         OnLoadActions0M23( ) ;
         AddRow0M23( ) ;
         ScanKeyEnd0M23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0M23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0M23( ) ;
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( A137ComandoId != Z137ComandoId )
               {
                  A137ComandoId = Z137ComandoId;
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
                  Update0M23( ) ;
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
                  if ( A137ComandoId != Z137ComandoId )
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
                        Insert0M23( ) ;
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
                        Insert0M23( ) ;
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
         RowToVars23( bcComando, 1) ;
         SaveImpl( ) ;
         VarsToRow23( bcComando) ;
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
         RowToVars23( bcComando, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M23( ) ;
         AfterTrn( ) ;
         VarsToRow23( bcComando) ;
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
            SdtComando auxBC = new SdtComando(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A137ComandoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcComando);
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
         RowToVars23( bcComando, 1) ;
         UpdateImpl( ) ;
         VarsToRow23( bcComando) ;
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
         RowToVars23( bcComando, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M23( ) ;
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
         VarsToRow23( bcComando) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars23( bcComando, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0M23( ) ;
         if ( RcdFound23 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A137ComandoId != Z137ComandoId )
            {
               A137ComandoId = Z137ComandoId;
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
            if ( A137ComandoId != Z137ComandoId )
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
         context.RollbackDataStores("comando_bc",pr_default);
         VarsToRow23( bcComando) ;
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
         Gx_mode = bcComando.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcComando.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcComando )
         {
            bcComando = (SdtComando)(sdt);
            if ( StringUtil.StrCmp(bcComando.gxTpr_Mode, "") == 0 )
            {
               bcComando.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow23( bcComando) ;
            }
            else
            {
               RowToVars23( bcComando, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcComando.gxTpr_Mode, "") == 0 )
            {
               bcComando.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars23( bcComando, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtComando Comando_BC
      {
         get {
            return bcComando ;
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
            return "comando_Execute" ;
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
         Z138ComandoNome = "";
         A138ComandoNome = "";
         Z139ComandoDescricao = "";
         A139ComandoDescricao = "";
         Z140ComandoFabricanteModulo = "";
         A140ComandoFabricanteModulo = "";
         Z141ComandoModeloModulo = "";
         A141ComandoModeloModulo = "";
         Z143ComandoParameter_Id = "";
         A143ComandoParameter_Id = "";
         Z142ComandoPayload = "";
         A142ComandoPayload = "";
         BC000M4_A137ComandoId = new int[1] ;
         BC000M4_A138ComandoNome = new string[] {""} ;
         BC000M4_A139ComandoDescricao = new string[] {""} ;
         BC000M4_A140ComandoFabricanteModulo = new string[] {""} ;
         BC000M4_A141ComandoModeloModulo = new string[] {""} ;
         BC000M4_A142ComandoPayload = new string[] {""} ;
         BC000M4_A143ComandoParameter_Id = new string[] {""} ;
         BC000M5_A137ComandoId = new int[1] ;
         BC000M3_A137ComandoId = new int[1] ;
         BC000M3_A138ComandoNome = new string[] {""} ;
         BC000M3_A139ComandoDescricao = new string[] {""} ;
         BC000M3_A140ComandoFabricanteModulo = new string[] {""} ;
         BC000M3_A141ComandoModeloModulo = new string[] {""} ;
         BC000M3_A142ComandoPayload = new string[] {""} ;
         BC000M3_A143ComandoParameter_Id = new string[] {""} ;
         sMode23 = "";
         BC000M2_A137ComandoId = new int[1] ;
         BC000M2_A138ComandoNome = new string[] {""} ;
         BC000M2_A139ComandoDescricao = new string[] {""} ;
         BC000M2_A140ComandoFabricanteModulo = new string[] {""} ;
         BC000M2_A141ComandoModeloModulo = new string[] {""} ;
         BC000M2_A142ComandoPayload = new string[] {""} ;
         BC000M2_A143ComandoParameter_Id = new string[] {""} ;
         BC000M6_A137ComandoId = new int[1] ;
         BC000M9_A137ComandoId = new int[1] ;
         BC000M9_A138ComandoNome = new string[] {""} ;
         BC000M9_A139ComandoDescricao = new string[] {""} ;
         BC000M9_A140ComandoFabricanteModulo = new string[] {""} ;
         BC000M9_A141ComandoModeloModulo = new string[] {""} ;
         BC000M9_A142ComandoPayload = new string[] {""} ;
         BC000M9_A143ComandoParameter_Id = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.comando_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comando_bc__default(),
            new Object[][] {
                new Object[] {
               BC000M2_A137ComandoId, BC000M2_A138ComandoNome, BC000M2_A139ComandoDescricao, BC000M2_A140ComandoFabricanteModulo, BC000M2_A141ComandoModeloModulo, BC000M2_A142ComandoPayload, BC000M2_A143ComandoParameter_Id
               }
               , new Object[] {
               BC000M3_A137ComandoId, BC000M3_A138ComandoNome, BC000M3_A139ComandoDescricao, BC000M3_A140ComandoFabricanteModulo, BC000M3_A141ComandoModeloModulo, BC000M3_A142ComandoPayload, BC000M3_A143ComandoParameter_Id
               }
               , new Object[] {
               BC000M4_A137ComandoId, BC000M4_A138ComandoNome, BC000M4_A139ComandoDescricao, BC000M4_A140ComandoFabricanteModulo, BC000M4_A141ComandoModeloModulo, BC000M4_A142ComandoPayload, BC000M4_A143ComandoParameter_Id
               }
               , new Object[] {
               BC000M5_A137ComandoId
               }
               , new Object[] {
               BC000M6_A137ComandoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M9_A137ComandoId, BC000M9_A138ComandoNome, BC000M9_A139ComandoDescricao, BC000M9_A140ComandoFabricanteModulo, BC000M9_A141ComandoModeloModulo, BC000M9_A142ComandoPayload, BC000M9_A143ComandoParameter_Id
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120M2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound23 ;
      private short nIsDirty_23 ;
      private int trnEnded ;
      private int Z137ComandoId ;
      private int A137ComandoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode23 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z142ComandoPayload ;
      private string A142ComandoPayload ;
      private string Z138ComandoNome ;
      private string A138ComandoNome ;
      private string Z139ComandoDescricao ;
      private string A139ComandoDescricao ;
      private string Z140ComandoFabricanteModulo ;
      private string A140ComandoFabricanteModulo ;
      private string Z141ComandoModeloModulo ;
      private string A141ComandoModeloModulo ;
      private string Z143ComandoParameter_Id ;
      private string A143ComandoParameter_Id ;
      private IGxSession AV12WebSession ;
      private SdtComando bcComando ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000M4_A137ComandoId ;
      private string[] BC000M4_A138ComandoNome ;
      private string[] BC000M4_A139ComandoDescricao ;
      private string[] BC000M4_A140ComandoFabricanteModulo ;
      private string[] BC000M4_A141ComandoModeloModulo ;
      private string[] BC000M4_A142ComandoPayload ;
      private string[] BC000M4_A143ComandoParameter_Id ;
      private int[] BC000M5_A137ComandoId ;
      private int[] BC000M3_A137ComandoId ;
      private string[] BC000M3_A138ComandoNome ;
      private string[] BC000M3_A139ComandoDescricao ;
      private string[] BC000M3_A140ComandoFabricanteModulo ;
      private string[] BC000M3_A141ComandoModeloModulo ;
      private string[] BC000M3_A142ComandoPayload ;
      private string[] BC000M3_A143ComandoParameter_Id ;
      private int[] BC000M2_A137ComandoId ;
      private string[] BC000M2_A138ComandoNome ;
      private string[] BC000M2_A139ComandoDescricao ;
      private string[] BC000M2_A140ComandoFabricanteModulo ;
      private string[] BC000M2_A141ComandoModeloModulo ;
      private string[] BC000M2_A142ComandoPayload ;
      private string[] BC000M2_A143ComandoParameter_Id ;
      private int[] BC000M6_A137ComandoId ;
      private int[] BC000M9_A137ComandoId ;
      private string[] BC000M9_A138ComandoNome ;
      private string[] BC000M9_A139ComandoDescricao ;
      private string[] BC000M9_A140ComandoFabricanteModulo ;
      private string[] BC000M9_A141ComandoModeloModulo ;
      private string[] BC000M9_A142ComandoPayload ;
      private string[] BC000M9_A143ComandoParameter_Id ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class comando_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class comando_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000M4;
        prmBC000M4 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000M5;
        prmBC000M5 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000M3;
        prmBC000M3 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000M2;
        prmBC000M2 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000M6;
        prmBC000M6 = new Object[] {
        new Object[] {"@ComandoNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoDescricao",SqlDbType.NVarChar,128,0} ,
        new Object[] {"@ComandoFabricanteModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoModeloModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoPayload",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@ComandoParameter_Id",SqlDbType.NVarChar,40,0}
        };
        Object[] prmBC000M7;
        prmBC000M7 = new Object[] {
        new Object[] {"@ComandoNome",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoDescricao",SqlDbType.NVarChar,128,0} ,
        new Object[] {"@ComandoFabricanteModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoModeloModulo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoPayload",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@ComandoParameter_Id",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000M8;
        prmBC000M8 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000M9;
        prmBC000M9 = new Object[] {
        new Object[] {"@ComandoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000M2", "SELECT [ComandoId], [ComandoNome], [ComandoDescricao], [ComandoFabricanteModulo], [ComandoModeloModulo], [ComandoPayload], [ComandoParameter_Id] FROM [Comando] WITH (UPDLOCK) WHERE [ComandoId] = @ComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M3", "SELECT [ComandoId], [ComandoNome], [ComandoDescricao], [ComandoFabricanteModulo], [ComandoModeloModulo], [ComandoPayload], [ComandoParameter_Id] FROM [Comando] WHERE [ComandoId] = @ComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M4", "SELECT TM1.[ComandoId], TM1.[ComandoNome], TM1.[ComandoDescricao], TM1.[ComandoFabricanteModulo], TM1.[ComandoModeloModulo], TM1.[ComandoPayload], TM1.[ComandoParameter_Id] FROM [Comando] TM1 WHERE TM1.[ComandoId] = @ComandoId ORDER BY TM1.[ComandoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M5", "SELECT [ComandoId] FROM [Comando] WHERE [ComandoId] = @ComandoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M6", "INSERT INTO [Comando]([ComandoNome], [ComandoDescricao], [ComandoFabricanteModulo], [ComandoModeloModulo], [ComandoPayload], [ComandoParameter_Id]) VALUES(@ComandoNome, @ComandoDescricao, @ComandoFabricanteModulo, @ComandoModeloModulo, @ComandoPayload, @ComandoParameter_Id); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000M6)
           ,new CursorDef("BC000M7", "UPDATE [Comando] SET [ComandoNome]=@ComandoNome, [ComandoDescricao]=@ComandoDescricao, [ComandoFabricanteModulo]=@ComandoFabricanteModulo, [ComandoModeloModulo]=@ComandoModeloModulo, [ComandoPayload]=@ComandoPayload, [ComandoParameter_Id]=@ComandoParameter_Id  WHERE [ComandoId] = @ComandoId", GxErrorMask.GX_NOMASK,prmBC000M7)
           ,new CursorDef("BC000M8", "DELETE FROM [Comando]  WHERE [ComandoId] = @ComandoId", GxErrorMask.GX_NOMASK,prmBC000M8)
           ,new CursorDef("BC000M9", "SELECT TM1.[ComandoId], TM1.[ComandoNome], TM1.[ComandoDescricao], TM1.[ComandoFabricanteModulo], TM1.[ComandoModeloModulo], TM1.[ComandoPayload], TM1.[ComandoParameter_Id] FROM [Comando] TM1 WHERE TM1.[ComandoId] = @ComandoId ORDER BY TM1.[ComandoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M9,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
              return;
           case 7 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLongVarchar(6);
              table[6][0] = rslt.getVarchar(7);
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
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (int)parms[6]);
              return;
           case 6 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
