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
   public class veiculo_bc : GXHttpHandler, IGxSilentTrn
   {
      public veiculo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public veiculo_bc( IGxContext context )
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
         ReadRow0F16( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F16( ) ;
         standaloneModal( ) ;
         AddRow0F16( ) ;
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
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F16( ) ;
            }
            else
            {
               CheckExtendedTable0F16( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0F16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z99VeiculoDataHoraCadastro = A99VeiculoDataHoraCadastro;
            Z105VeiculoGAMGUID = A105VeiculoGAMGUID;
            Z100VeiculoPlaca = A100VeiculoPlaca;
            Z97VeiculoCor = A97VeiculoCor;
            Z101VeiculoTipo = A101VeiculoTipo;
            Z102VeiculoMarca = A102VeiculoMarca;
            Z103VeiculoModelo = A103VeiculoModelo;
            Z104VeiculoAno = A104VeiculoAno;
         }
         if ( GX_JID == -10 )
         {
            Z98VeiculoId = A98VeiculoId;
            Z99VeiculoDataHoraCadastro = A99VeiculoDataHoraCadastro;
            Z105VeiculoGAMGUID = A105VeiculoGAMGUID;
            Z100VeiculoPlaca = A100VeiculoPlaca;
            Z97VeiculoCor = A97VeiculoCor;
            Z101VeiculoTipo = A101VeiculoTipo;
            Z102VeiculoMarca = A102VeiculoMarca;
            Z103VeiculoModelo = A103VeiculoModelo;
            Z104VeiculoAno = A104VeiculoAno;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A99VeiculoDataHoraCadastro) && ( Gx_BScreen == 0 ) )
         {
            A99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A105VeiculoGAMGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A105VeiculoGAMGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A105VeiculoGAMGUID = GXt_char1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound16 = 1;
            A99VeiculoDataHoraCadastro = BC000F4_A99VeiculoDataHoraCadastro[0];
            A105VeiculoGAMGUID = BC000F4_A105VeiculoGAMGUID[0];
            A100VeiculoPlaca = BC000F4_A100VeiculoPlaca[0];
            A97VeiculoCor = BC000F4_A97VeiculoCor[0];
            A101VeiculoTipo = BC000F4_A101VeiculoTipo[0];
            A102VeiculoMarca = BC000F4_A102VeiculoMarca[0];
            A103VeiculoModelo = BC000F4_A103VeiculoModelo[0];
            A104VeiculoAno = BC000F4_A104VeiculoAno[0];
            ZM0F16( -10) ;
         }
         pr_default.close(2);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
      }

      protected void CheckExtendedTable0F16( )
      {
         nIsDirty_16 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A100VeiculoPlaca, A98VeiculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Placa"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A99VeiculoDataHoraCadastro) || ( A99VeiculoDataHoraCadastro >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Data/Hora do Cadastro fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A100VeiculoPlaca)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Placa", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A97VeiculoCor)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Cor", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A101VeiculoTipo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A102VeiculoMarca)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Marca", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103VeiculoModelo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Modelo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A104VeiculoAno)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Ano", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0F16( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F16( )
      {
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A98VeiculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F16( 10) ;
            RcdFound16 = 1;
            A98VeiculoId = BC000F3_A98VeiculoId[0];
            A99VeiculoDataHoraCadastro = BC000F3_A99VeiculoDataHoraCadastro[0];
            A105VeiculoGAMGUID = BC000F3_A105VeiculoGAMGUID[0];
            A100VeiculoPlaca = BC000F3_A100VeiculoPlaca[0];
            A97VeiculoCor = BC000F3_A97VeiculoCor[0];
            A101VeiculoTipo = BC000F3_A101VeiculoTipo[0];
            A102VeiculoMarca = BC000F3_A102VeiculoMarca[0];
            A103VeiculoModelo = BC000F3_A103VeiculoModelo[0];
            A104VeiculoAno = BC000F3_A104VeiculoAno[0];
            Z98VeiculoId = A98VeiculoId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
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
         CONFIRM_0F0( ) ;
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

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Veiculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z99VeiculoDataHoraCadastro != BC000F2_A99VeiculoDataHoraCadastro[0] ) || ( StringUtil.StrCmp(Z105VeiculoGAMGUID, BC000F2_A105VeiculoGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z100VeiculoPlaca, BC000F2_A100VeiculoPlaca[0]) != 0 ) || ( StringUtil.StrCmp(Z97VeiculoCor, BC000F2_A97VeiculoCor[0]) != 0 ) || ( StringUtil.StrCmp(Z101VeiculoTipo, BC000F2_A101VeiculoTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z102VeiculoMarca, BC000F2_A102VeiculoMarca[0]) != 0 ) || ( StringUtil.StrCmp(Z103VeiculoModelo, BC000F2_A103VeiculoModelo[0]) != 0 ) || ( StringUtil.StrCmp(Z104VeiculoAno, BC000F2_A104VeiculoAno[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Veiculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F7 */
                     pr_default.execute(5, new Object[] {A99VeiculoDataHoraCadastro, A105VeiculoGAMGUID, A100VeiculoPlaca, A97VeiculoCor, A101VeiculoTipo, A102VeiculoMarca, A103VeiculoModelo, A104VeiculoAno});
                     A98VeiculoId = BC000F7_A98VeiculoId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Veiculo");
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F8 */
                     pr_default.execute(6, new Object[] {A99VeiculoDataHoraCadastro, A105VeiculoGAMGUID, A100VeiculoPlaca, A97VeiculoCor, A101VeiculoTipo, A102VeiculoMarca, A103VeiculoModelo, A104VeiculoAno, A98VeiculoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Veiculo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Veiculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
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
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F9 */
                  pr_default.execute(7, new Object[] {A98VeiculoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Veiculo");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F10 */
            pr_default.execute(8, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Veiculo Rastreador"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000F11 */
            pr_default.execute(9, new Object[] {A98VeiculoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Frota Veiculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
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

      public void ScanKeyStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor BC000F12 */
         pr_default.execute(10, new Object[] {A98VeiculoId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound16 = 1;
            A98VeiculoId = BC000F12_A98VeiculoId[0];
            A99VeiculoDataHoraCadastro = BC000F12_A99VeiculoDataHoraCadastro[0];
            A105VeiculoGAMGUID = BC000F12_A105VeiculoGAMGUID[0];
            A100VeiculoPlaca = BC000F12_A100VeiculoPlaca[0];
            A97VeiculoCor = BC000F12_A97VeiculoCor[0];
            A101VeiculoTipo = BC000F12_A101VeiculoTipo[0];
            A102VeiculoMarca = BC000F12_A102VeiculoMarca[0];
            A103VeiculoModelo = BC000F12_A103VeiculoModelo[0];
            A104VeiculoAno = BC000F12_A104VeiculoAno[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound16 = 0;
         ScanKeyLoad0F16( ) ;
      }

      protected void ScanKeyLoad0F16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound16 = 1;
            A98VeiculoId = BC000F12_A98VeiculoId[0];
            A99VeiculoDataHoraCadastro = BC000F12_A99VeiculoDataHoraCadastro[0];
            A105VeiculoGAMGUID = BC000F12_A105VeiculoGAMGUID[0];
            A100VeiculoPlaca = BC000F12_A100VeiculoPlaca[0];
            A97VeiculoCor = BC000F12_A97VeiculoCor[0];
            A101VeiculoTipo = BC000F12_A101VeiculoTipo[0];
            A102VeiculoMarca = BC000F12_A102VeiculoMarca[0];
            A103VeiculoModelo = BC000F12_A103VeiculoModelo[0];
            A104VeiculoAno = BC000F12_A104VeiculoAno[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0F16( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void AddRow0F16( )
      {
         VarsToRow16( bcVeiculo) ;
      }

      protected void ReadRow0F16( )
      {
         RowToVars16( bcVeiculo, 1) ;
      }

      protected void InitializeNonKey0F16( )
      {
         A100VeiculoPlaca = "";
         A97VeiculoCor = "";
         A101VeiculoTipo = "";
         A102VeiculoMarca = "";
         A103VeiculoModelo = "";
         A104VeiculoAno = "";
         A99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         A105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         Z105VeiculoGAMGUID = "";
         Z100VeiculoPlaca = "";
         Z97VeiculoCor = "";
         Z101VeiculoTipo = "";
         Z102VeiculoMarca = "";
         Z103VeiculoModelo = "";
         Z104VeiculoAno = "";
      }

      protected void InitAll0F16( )
      {
         A98VeiculoId = 0;
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A99VeiculoDataHoraCadastro = i99VeiculoDataHoraCadastro;
         A105VeiculoGAMGUID = i105VeiculoGAMGUID;
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

      public void VarsToRow16( SdtVeiculo obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Veiculoplaca = A100VeiculoPlaca;
         obj16.gxTpr_Veiculocor = A97VeiculoCor;
         obj16.gxTpr_Veiculotipo = A101VeiculoTipo;
         obj16.gxTpr_Veiculomarca = A102VeiculoMarca;
         obj16.gxTpr_Veiculomodelo = A103VeiculoModelo;
         obj16.gxTpr_Veiculoano = A104VeiculoAno;
         obj16.gxTpr_Veiculodatahoracadastro = A99VeiculoDataHoraCadastro;
         obj16.gxTpr_Veiculogamguid = A105VeiculoGAMGUID;
         obj16.gxTpr_Veiculoid = A98VeiculoId;
         obj16.gxTpr_Veiculoid_Z = Z98VeiculoId;
         obj16.gxTpr_Veiculodatahoracadastro_Z = Z99VeiculoDataHoraCadastro;
         obj16.gxTpr_Veiculogamguid_Z = Z105VeiculoGAMGUID;
         obj16.gxTpr_Veiculoplaca_Z = Z100VeiculoPlaca;
         obj16.gxTpr_Veiculocor_Z = Z97VeiculoCor;
         obj16.gxTpr_Veiculotipo_Z = Z101VeiculoTipo;
         obj16.gxTpr_Veiculomarca_Z = Z102VeiculoMarca;
         obj16.gxTpr_Veiculomodelo_Z = Z103VeiculoModelo;
         obj16.gxTpr_Veiculoano_Z = Z104VeiculoAno;
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( SdtVeiculo obj16 )
      {
         obj16.gxTpr_Veiculoid = A98VeiculoId;
         return  ;
      }

      public void RowToVars16( SdtVeiculo obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A100VeiculoPlaca = obj16.gxTpr_Veiculoplaca;
         A97VeiculoCor = obj16.gxTpr_Veiculocor;
         A101VeiculoTipo = obj16.gxTpr_Veiculotipo;
         A102VeiculoMarca = obj16.gxTpr_Veiculomarca;
         A103VeiculoModelo = obj16.gxTpr_Veiculomodelo;
         A104VeiculoAno = obj16.gxTpr_Veiculoano;
         A99VeiculoDataHoraCadastro = obj16.gxTpr_Veiculodatahoracadastro;
         A105VeiculoGAMGUID = obj16.gxTpr_Veiculogamguid;
         A98VeiculoId = obj16.gxTpr_Veiculoid;
         Z98VeiculoId = obj16.gxTpr_Veiculoid_Z;
         Z99VeiculoDataHoraCadastro = obj16.gxTpr_Veiculodatahoracadastro_Z;
         Z105VeiculoGAMGUID = obj16.gxTpr_Veiculogamguid_Z;
         Z100VeiculoPlaca = obj16.gxTpr_Veiculoplaca_Z;
         Z97VeiculoCor = obj16.gxTpr_Veiculocor_Z;
         Z101VeiculoTipo = obj16.gxTpr_Veiculotipo_Z;
         Z102VeiculoMarca = obj16.gxTpr_Veiculomarca_Z;
         Z103VeiculoModelo = obj16.gxTpr_Veiculomodelo_Z;
         Z104VeiculoAno = obj16.gxTpr_Veiculoano_Z;
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A98VeiculoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F16( ) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98VeiculoId = A98VeiculoId;
         }
         ZM0F16( -10) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
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
         RowToVars16( bcVeiculo, 0) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98VeiculoId = A98VeiculoId;
         }
         ZM0F16( -10) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F16( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A98VeiculoId != Z98VeiculoId )
               {
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
                  Update0F16( ) ;
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
                  if ( A98VeiculoId != Z98VeiculoId )
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
                        Insert0F16( ) ;
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
                        Insert0F16( ) ;
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
         RowToVars16( bcVeiculo, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcVeiculo) ;
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
         RowToVars16( bcVeiculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcVeiculo) ;
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
            SdtVeiculo auxBC = new SdtVeiculo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A98VeiculoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcVeiculo);
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
         RowToVars16( bcVeiculo, 1) ;
         UpdateImpl( ) ;
         VarsToRow16( bcVeiculo) ;
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
         RowToVars16( bcVeiculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
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
         VarsToRow16( bcVeiculo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcVeiculo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0F16( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A98VeiculoId != Z98VeiculoId )
            {
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
            if ( A98VeiculoId != Z98VeiculoId )
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
         context.RollbackDataStores("veiculo_bc",pr_default);
         VarsToRow16( bcVeiculo) ;
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
         Gx_mode = bcVeiculo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcVeiculo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcVeiculo )
         {
            bcVeiculo = (SdtVeiculo)(sdt);
            if ( StringUtil.StrCmp(bcVeiculo.gxTpr_Mode, "") == 0 )
            {
               bcVeiculo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcVeiculo) ;
            }
            else
            {
               RowToVars16( bcVeiculo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcVeiculo.gxTpr_Mode, "") == 0 )
            {
               bcVeiculo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcVeiculo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtVeiculo Veiculo_BC
      {
         get {
            return bcVeiculo ;
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
            return "veiculo_Execute" ;
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
         Z99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         A99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         Z105VeiculoGAMGUID = "";
         A105VeiculoGAMGUID = "";
         Z100VeiculoPlaca = "";
         A100VeiculoPlaca = "";
         Z97VeiculoCor = "";
         A97VeiculoCor = "";
         Z101VeiculoTipo = "";
         A101VeiculoTipo = "";
         Z102VeiculoMarca = "";
         A102VeiculoMarca = "";
         Z103VeiculoModelo = "";
         A103VeiculoModelo = "";
         Z104VeiculoAno = "";
         A104VeiculoAno = "";
         GXt_char1 = "";
         BC000F4_A98VeiculoId = new int[1] ;
         BC000F4_A99VeiculoDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         BC000F4_A105VeiculoGAMGUID = new string[] {""} ;
         BC000F4_A100VeiculoPlaca = new string[] {""} ;
         BC000F4_A97VeiculoCor = new string[] {""} ;
         BC000F4_A101VeiculoTipo = new string[] {""} ;
         BC000F4_A102VeiculoMarca = new string[] {""} ;
         BC000F4_A103VeiculoModelo = new string[] {""} ;
         BC000F4_A104VeiculoAno = new string[] {""} ;
         BC000F5_A100VeiculoPlaca = new string[] {""} ;
         BC000F6_A98VeiculoId = new int[1] ;
         BC000F3_A98VeiculoId = new int[1] ;
         BC000F3_A99VeiculoDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         BC000F3_A105VeiculoGAMGUID = new string[] {""} ;
         BC000F3_A100VeiculoPlaca = new string[] {""} ;
         BC000F3_A97VeiculoCor = new string[] {""} ;
         BC000F3_A101VeiculoTipo = new string[] {""} ;
         BC000F3_A102VeiculoMarca = new string[] {""} ;
         BC000F3_A103VeiculoModelo = new string[] {""} ;
         BC000F3_A104VeiculoAno = new string[] {""} ;
         sMode16 = "";
         BC000F2_A98VeiculoId = new int[1] ;
         BC000F2_A99VeiculoDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         BC000F2_A105VeiculoGAMGUID = new string[] {""} ;
         BC000F2_A100VeiculoPlaca = new string[] {""} ;
         BC000F2_A97VeiculoCor = new string[] {""} ;
         BC000F2_A101VeiculoTipo = new string[] {""} ;
         BC000F2_A102VeiculoMarca = new string[] {""} ;
         BC000F2_A103VeiculoModelo = new string[] {""} ;
         BC000F2_A104VeiculoAno = new string[] {""} ;
         BC000F7_A98VeiculoId = new int[1] ;
         BC000F10_A98VeiculoId = new int[1] ;
         BC000F10_A106RastreadorId = new int[1] ;
         BC000F11_A93FrotaId = new int[1] ;
         BC000F11_A98VeiculoId = new int[1] ;
         BC000F12_A98VeiculoId = new int[1] ;
         BC000F12_A99VeiculoDataHoraCadastro = new DateTime[] {DateTime.MinValue} ;
         BC000F12_A105VeiculoGAMGUID = new string[] {""} ;
         BC000F12_A100VeiculoPlaca = new string[] {""} ;
         BC000F12_A97VeiculoCor = new string[] {""} ;
         BC000F12_A101VeiculoTipo = new string[] {""} ;
         BC000F12_A102VeiculoMarca = new string[] {""} ;
         BC000F12_A103VeiculoModelo = new string[] {""} ;
         BC000F12_A104VeiculoAno = new string[] {""} ;
         i99VeiculoDataHoraCadastro = (DateTime)(DateTime.MinValue);
         i105VeiculoGAMGUID = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.veiculo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.veiculo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A98VeiculoId, BC000F2_A99VeiculoDataHoraCadastro, BC000F2_A105VeiculoGAMGUID, BC000F2_A100VeiculoPlaca, BC000F2_A97VeiculoCor, BC000F2_A101VeiculoTipo, BC000F2_A102VeiculoMarca, BC000F2_A103VeiculoModelo, BC000F2_A104VeiculoAno
               }
               , new Object[] {
               BC000F3_A98VeiculoId, BC000F3_A99VeiculoDataHoraCadastro, BC000F3_A105VeiculoGAMGUID, BC000F3_A100VeiculoPlaca, BC000F3_A97VeiculoCor, BC000F3_A101VeiculoTipo, BC000F3_A102VeiculoMarca, BC000F3_A103VeiculoModelo, BC000F3_A104VeiculoAno
               }
               , new Object[] {
               BC000F4_A98VeiculoId, BC000F4_A99VeiculoDataHoraCadastro, BC000F4_A105VeiculoGAMGUID, BC000F4_A100VeiculoPlaca, BC000F4_A97VeiculoCor, BC000F4_A101VeiculoTipo, BC000F4_A102VeiculoMarca, BC000F4_A103VeiculoModelo, BC000F4_A104VeiculoAno
               }
               , new Object[] {
               BC000F5_A100VeiculoPlaca
               }
               , new Object[] {
               BC000F6_A98VeiculoId
               }
               , new Object[] {
               BC000F7_A98VeiculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F10_A98VeiculoId, BC000F10_A106RastreadorId
               }
               , new Object[] {
               BC000F11_A93FrotaId, BC000F11_A98VeiculoId
               }
               , new Object[] {
               BC000F12_A98VeiculoId, BC000F12_A99VeiculoDataHoraCadastro, BC000F12_A105VeiculoGAMGUID, BC000F12_A100VeiculoPlaca, BC000F12_A97VeiculoCor, BC000F12_A101VeiculoTipo, BC000F12_A102VeiculoMarca, BC000F12_A103VeiculoModelo, BC000F12_A104VeiculoAno
               }
            }
         );
         Z105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         A105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         i105VeiculoGAMGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         A99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         i99VeiculoDataHoraCadastro = DateTimeUtil.ServerNow( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound16 ;
      private short nIsDirty_16 ;
      private int trnEnded ;
      private int Z98VeiculoId ;
      private int A98VeiculoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z105VeiculoGAMGUID ;
      private string A105VeiculoGAMGUID ;
      private string Z97VeiculoCor ;
      private string A97VeiculoCor ;
      private string GXt_char1 ;
      private string sMode16 ;
      private string i105VeiculoGAMGUID ;
      private DateTime Z99VeiculoDataHoraCadastro ;
      private DateTime A99VeiculoDataHoraCadastro ;
      private DateTime i99VeiculoDataHoraCadastro ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z100VeiculoPlaca ;
      private string A100VeiculoPlaca ;
      private string Z101VeiculoTipo ;
      private string A101VeiculoTipo ;
      private string Z102VeiculoMarca ;
      private string A102VeiculoMarca ;
      private string Z103VeiculoModelo ;
      private string A103VeiculoModelo ;
      private string Z104VeiculoAno ;
      private string A104VeiculoAno ;
      private IGxSession AV12WebSession ;
      private SdtVeiculo bcVeiculo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000F4_A98VeiculoId ;
      private DateTime[] BC000F4_A99VeiculoDataHoraCadastro ;
      private string[] BC000F4_A105VeiculoGAMGUID ;
      private string[] BC000F4_A100VeiculoPlaca ;
      private string[] BC000F4_A97VeiculoCor ;
      private string[] BC000F4_A101VeiculoTipo ;
      private string[] BC000F4_A102VeiculoMarca ;
      private string[] BC000F4_A103VeiculoModelo ;
      private string[] BC000F4_A104VeiculoAno ;
      private string[] BC000F5_A100VeiculoPlaca ;
      private int[] BC000F6_A98VeiculoId ;
      private int[] BC000F3_A98VeiculoId ;
      private DateTime[] BC000F3_A99VeiculoDataHoraCadastro ;
      private string[] BC000F3_A105VeiculoGAMGUID ;
      private string[] BC000F3_A100VeiculoPlaca ;
      private string[] BC000F3_A97VeiculoCor ;
      private string[] BC000F3_A101VeiculoTipo ;
      private string[] BC000F3_A102VeiculoMarca ;
      private string[] BC000F3_A103VeiculoModelo ;
      private string[] BC000F3_A104VeiculoAno ;
      private int[] BC000F2_A98VeiculoId ;
      private DateTime[] BC000F2_A99VeiculoDataHoraCadastro ;
      private string[] BC000F2_A105VeiculoGAMGUID ;
      private string[] BC000F2_A100VeiculoPlaca ;
      private string[] BC000F2_A97VeiculoCor ;
      private string[] BC000F2_A101VeiculoTipo ;
      private string[] BC000F2_A102VeiculoMarca ;
      private string[] BC000F2_A103VeiculoModelo ;
      private string[] BC000F2_A104VeiculoAno ;
      private int[] BC000F7_A98VeiculoId ;
      private int[] BC000F10_A98VeiculoId ;
      private int[] BC000F10_A106RastreadorId ;
      private int[] BC000F11_A93FrotaId ;
      private int[] BC000F11_A98VeiculoId ;
      private int[] BC000F12_A98VeiculoId ;
      private DateTime[] BC000F12_A99VeiculoDataHoraCadastro ;
      private string[] BC000F12_A105VeiculoGAMGUID ;
      private string[] BC000F12_A100VeiculoPlaca ;
      private string[] BC000F12_A97VeiculoCor ;
      private string[] BC000F12_A101VeiculoTipo ;
      private string[] BC000F12_A102VeiculoMarca ;
      private string[] BC000F12_A103VeiculoModelo ;
      private string[] BC000F12_A104VeiculoAno ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class veiculo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class veiculo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000F4;
        prmBC000F4 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F5;
        prmBC000F5 = new Object[] {
        new Object[] {"@VeiculoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F6;
        prmBC000F6 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F3;
        prmBC000F3 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F2;
        prmBC000F2 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F7;
        prmBC000F7 = new Object[] {
        new Object[] {"@VeiculoDataHoraCadastro",SqlDbType.DateTime,8,5} ,
        new Object[] {"@VeiculoGAMGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@VeiculoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@VeiculoCor",SqlDbType.NChar,20,0} ,
        new Object[] {"@VeiculoTipo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoMarca",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoModelo",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@VeiculoAno",SqlDbType.NVarChar,10,0}
        };
        Object[] prmBC000F8;
        prmBC000F8 = new Object[] {
        new Object[] {"@VeiculoDataHoraCadastro",SqlDbType.DateTime,8,5} ,
        new Object[] {"@VeiculoGAMGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@VeiculoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@VeiculoCor",SqlDbType.NChar,20,0} ,
        new Object[] {"@VeiculoTipo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoMarca",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@VeiculoModelo",SqlDbType.NVarChar,80,0} ,
        new Object[] {"@VeiculoAno",SqlDbType.NVarChar,10,0} ,
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F9;
        prmBC000F9 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F10;
        prmBC000F10 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F11;
        prmBC000F11 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000F12;
        prmBC000F12 = new Object[] {
        new Object[] {"@VeiculoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000F2", "SELECT [VeiculoId], [VeiculoDataHoraCadastro], [VeiculoGAMGUID], [VeiculoPlaca], [VeiculoCor], [VeiculoTipo], [VeiculoMarca], [VeiculoModelo], [VeiculoAno] FROM [Veiculo] WITH (UPDLOCK) WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F3", "SELECT [VeiculoId], [VeiculoDataHoraCadastro], [VeiculoGAMGUID], [VeiculoPlaca], [VeiculoCor], [VeiculoTipo], [VeiculoMarca], [VeiculoModelo], [VeiculoAno] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F4", "SELECT TM1.[VeiculoId], TM1.[VeiculoDataHoraCadastro], TM1.[VeiculoGAMGUID], TM1.[VeiculoPlaca], TM1.[VeiculoCor], TM1.[VeiculoTipo], TM1.[VeiculoMarca], TM1.[VeiculoModelo], TM1.[VeiculoAno] FROM [Veiculo] TM1 WHERE TM1.[VeiculoId] = @VeiculoId ORDER BY TM1.[VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F5", "SELECT [VeiculoPlaca] FROM [Veiculo] WHERE ([VeiculoPlaca] = @VeiculoPlaca) AND (Not ( [VeiculoId] = @VeiculoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F6", "SELECT [VeiculoId] FROM [Veiculo] WHERE [VeiculoId] = @VeiculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F7", "INSERT INTO [Veiculo]([VeiculoDataHoraCadastro], [VeiculoGAMGUID], [VeiculoPlaca], [VeiculoCor], [VeiculoTipo], [VeiculoMarca], [VeiculoModelo], [VeiculoAno]) VALUES(@VeiculoDataHoraCadastro, @VeiculoGAMGUID, @VeiculoPlaca, @VeiculoCor, @VeiculoTipo, @VeiculoMarca, @VeiculoModelo, @VeiculoAno); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000F7)
           ,new CursorDef("BC000F8", "UPDATE [Veiculo] SET [VeiculoDataHoraCadastro]=@VeiculoDataHoraCadastro, [VeiculoGAMGUID]=@VeiculoGAMGUID, [VeiculoPlaca]=@VeiculoPlaca, [VeiculoCor]=@VeiculoCor, [VeiculoTipo]=@VeiculoTipo, [VeiculoMarca]=@VeiculoMarca, [VeiculoModelo]=@VeiculoModelo, [VeiculoAno]=@VeiculoAno  WHERE [VeiculoId] = @VeiculoId", GxErrorMask.GX_NOMASK,prmBC000F8)
           ,new CursorDef("BC000F9", "DELETE FROM [Veiculo]  WHERE [VeiculoId] = @VeiculoId", GxErrorMask.GX_NOMASK,prmBC000F9)
           ,new CursorDef("BC000F10", "SELECT TOP 1 [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F11", "SELECT TOP 1 [FrotaId], [VeiculoId] FROM [FrotaVeiculo] WHERE [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F12", "SELECT TM1.[VeiculoId], TM1.[VeiculoDataHoraCadastro], TM1.[VeiculoGAMGUID], TM1.[VeiculoPlaca], TM1.[VeiculoCor], TM1.[VeiculoTipo], TM1.[VeiculoMarca], TM1.[VeiculoModelo], TM1.[VeiculoAno] FROM [Veiculo] TM1 WHERE TM1.[VeiculoId] = @VeiculoId ORDER BY TM1.[VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F12,100, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 20);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 20);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 20);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 3 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              return;
           case 8 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 9 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 10 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getString(5, 20);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
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
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 4 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 5 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              return;
           case 6 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (string)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (int)parms[8]);
              return;
           case 7 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
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
