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
   public class rastreador_bc : GXHttpHandler, IGxSilentTrn
   {
      public rastreador_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rastreador_bc( IGxContext context )
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
         ReadRow0H18( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H18( ) ;
         standaloneModal( ) ;
         AddRow0H18( ) ;
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
            E110H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H18( ) ;
            }
            else
            {
               CheckExtendedTable0H18( ) ;
               if ( AnyError == 0 )
               {
                  ZM0H18( 18) ;
               }
               CloseExtendedTableCursors0H18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ChipGSMId") == 0 )
               {
                  AV13Insert_ChipGSMId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E110H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0H18( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z107RastreadorDataHoraCriacao = A107RastreadorDataHoraCriacao;
            Z151RastreadorGAMGUIDProprietario = A151RastreadorGAMGUIDProprietario;
            Z108RastreadorFabricante = A108RastreadorFabricante;
            Z109RastreadorModelo = A109RastreadorModelo;
            Z110RastreadorSNumber = A110RastreadorSNumber;
            Z111RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            Z112RastreadorAtrelado = A112RastreadorAtrelado;
            Z113ChipGSMId = A113ChipGSMId;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z115ChipGSMOperadora = A115ChipGSMOperadora;
            Z116ChipGSMNumero = A116ChipGSMNumero;
         }
         if ( GX_JID == -17 )
         {
            Z106RastreadorId = A106RastreadorId;
            Z107RastreadorDataHoraCriacao = A107RastreadorDataHoraCriacao;
            Z151RastreadorGAMGUIDProprietario = A151RastreadorGAMGUIDProprietario;
            Z108RastreadorFabricante = A108RastreadorFabricante;
            Z109RastreadorModelo = A109RastreadorModelo;
            Z110RastreadorSNumber = A110RastreadorSNumber;
            Z111RastreadorDeviceIdFlespi = A111RastreadorDeviceIdFlespi;
            Z112RastreadorAtrelado = A112RastreadorAtrelado;
            Z113ChipGSMId = A113ChipGSMId;
            Z115ChipGSMOperadora = A115ChipGSMOperadora;
            Z116ChipGSMNumero = A116ChipGSMNumero;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "Rastreador_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A107RastreadorDataHoraCriacao) && ( Gx_BScreen == 0 ) )
         {
            A107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A151RastreadorGAMGUIDProprietario)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A151RastreadorGAMGUIDProprietario;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A151RastreadorGAMGUIDProprietario = GXt_char1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0H18( )
      {
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound18 = 1;
            A107RastreadorDataHoraCriacao = BC000H5_A107RastreadorDataHoraCriacao[0];
            A151RastreadorGAMGUIDProprietario = BC000H5_A151RastreadorGAMGUIDProprietario[0];
            A108RastreadorFabricante = BC000H5_A108RastreadorFabricante[0];
            n108RastreadorFabricante = BC000H5_n108RastreadorFabricante[0];
            A109RastreadorModelo = BC000H5_A109RastreadorModelo[0];
            n109RastreadorModelo = BC000H5_n109RastreadorModelo[0];
            A110RastreadorSNumber = BC000H5_A110RastreadorSNumber[0];
            A111RastreadorDeviceIdFlespi = BC000H5_A111RastreadorDeviceIdFlespi[0];
            A112RastreadorAtrelado = BC000H5_A112RastreadorAtrelado[0];
            A115ChipGSMOperadora = BC000H5_A115ChipGSMOperadora[0];
            A116ChipGSMNumero = BC000H5_A116ChipGSMNumero[0];
            A113ChipGSMId = BC000H5_A113ChipGSMId[0];
            ZM0H18( -17) ;
         }
         pr_default.close(3);
         OnLoadActions0H18( ) ;
      }

      protected void OnLoadActions0H18( )
      {
      }

      protected void CheckExtendedTable0H18( )
      {
         nIsDirty_18 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A107RastreadorDataHoraCriacao) || ( A107RastreadorDataHoraCriacao >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Data/Hora da Criação fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A108RastreadorFabricante, "Maxtrack") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A108RastreadorFabricante)) ) )
         {
            GX_msglist.addItem("Campo Fabricante fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108RastreadorFabricante)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Fabricante", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A109RastreadorModelo, "MXT140") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A109RastreadorModelo)) ) )
         {
            GX_msglist.addItem("Campo Modelo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109RastreadorModelo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Modelo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (0==A110RastreadorSNumber) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Rastreador", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (0==A111RastreadorDeviceIdFlespi) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Id no Flespi", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A113ChipGSMId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Chip GSM'.", "ForeignKeyNotFound", 1, "CHIPGSMID");
            AnyError = 1;
         }
         A115ChipGSMOperadora = BC000H4_A115ChipGSMOperadora[0];
         A116ChipGSMNumero = BC000H4_A116ChipGSMNumero[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0H18( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H18( )
      {
         /* Using cursor BC000H6 */
         pr_default.execute(4, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H18( 17) ;
            RcdFound18 = 1;
            A106RastreadorId = BC000H3_A106RastreadorId[0];
            A107RastreadorDataHoraCriacao = BC000H3_A107RastreadorDataHoraCriacao[0];
            A151RastreadorGAMGUIDProprietario = BC000H3_A151RastreadorGAMGUIDProprietario[0];
            A108RastreadorFabricante = BC000H3_A108RastreadorFabricante[0];
            n108RastreadorFabricante = BC000H3_n108RastreadorFabricante[0];
            A109RastreadorModelo = BC000H3_A109RastreadorModelo[0];
            n109RastreadorModelo = BC000H3_n109RastreadorModelo[0];
            A110RastreadorSNumber = BC000H3_A110RastreadorSNumber[0];
            A111RastreadorDeviceIdFlespi = BC000H3_A111RastreadorDeviceIdFlespi[0];
            A112RastreadorAtrelado = BC000H3_A112RastreadorAtrelado[0];
            A113ChipGSMId = BC000H3_A113ChipGSMId[0];
            O113ChipGSMId = A113ChipGSMId;
            Z106RastreadorId = A106RastreadorId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0H18( ) ;
            }
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0H18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode18;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H18( ) ;
         if ( RcdFound18 == 0 )
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
         CONFIRM_0H0( ) ;
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

      protected void CheckOptimisticConcurrency0H18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rastreador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z107RastreadorDataHoraCriacao != BC000H2_A107RastreadorDataHoraCriacao[0] ) || ( StringUtil.StrCmp(Z151RastreadorGAMGUIDProprietario, BC000H2_A151RastreadorGAMGUIDProprietario[0]) != 0 ) || ( StringUtil.StrCmp(Z108RastreadorFabricante, BC000H2_A108RastreadorFabricante[0]) != 0 ) || ( StringUtil.StrCmp(Z109RastreadorModelo, BC000H2_A109RastreadorModelo[0]) != 0 ) || ( Z110RastreadorSNumber != BC000H2_A110RastreadorSNumber[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z111RastreadorDeviceIdFlespi != BC000H2_A111RastreadorDeviceIdFlespi[0] ) || ( Z112RastreadorAtrelado != BC000H2_A112RastreadorAtrelado[0] ) || ( Z113ChipGSMId != BC000H2_A113ChipGSMId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Rastreador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H18( 0) ;
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H7 */
                     pr_default.execute(5, new Object[] {A107RastreadorDataHoraCriacao, A151RastreadorGAMGUIDProprietario, n108RastreadorFabricante, A108RastreadorFabricante, n109RastreadorModelo, A109RastreadorModelo, A110RastreadorSNumber, A111RastreadorDeviceIdFlespi, A112RastreadorAtrelado, A113ChipGSMId});
                     A106RastreadorId = BC000H7_A106RastreadorId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( ! (0==A113ChipGSMId) ) )
                        {
                           new atrelarchipgsm(context ).execute(  A113ChipGSMId) ;
                        }
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
               Load0H18( ) ;
            }
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void Update0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H8 */
                     pr_default.execute(6, new Object[] {A107RastreadorDataHoraCriacao, A151RastreadorGAMGUIDProprietario, n108RastreadorFabricante, A108RastreadorFabricante, n109RastreadorModelo, A109RastreadorModelo, A110RastreadorSNumber, A111RastreadorDeviceIdFlespi, A112RastreadorAtrelado, A113ChipGSMId, A106RastreadorId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rastreador"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( ! (0==A113ChipGSMId) ) )
                        {
                           new atrelarchipgsm(context ).execute(  A113ChipGSMId) ;
                        }
                        if ( ( ( A113ChipGSMId != O113ChipGSMId ) ) && ( (0==A113ChipGSMId) ) )
                        {
                           new desatrelarchipgsm(context ).execute(  O113ChipGSMId) ;
                        }
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
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void DeferredUpdate0H18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H18( ) ;
            AfterConfirm0H18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H9 */
                  pr_default.execute(7, new Object[] {A106RastreadorId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Rastreador");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0H18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000H10 */
            pr_default.execute(8, new Object[] {A113ChipGSMId});
            A115ChipGSMOperadora = BC000H10_A115ChipGSMOperadora[0];
            A116ChipGSMNumero = BC000H10_A116ChipGSMNumero[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000H11 */
            pr_default.execute(9, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Comando Enviado"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000H12 */
            pr_default.execute(10, new Object[] {A106RastreadorId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Veiculo Rastreador"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0H18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            if ( IsIns( )  )
            {
               new atualizasubscribersmqtt(context ).execute(  A106RastreadorId,  A110RastreadorSNumber,  A111RastreadorDeviceIdFlespi,  false) ;
            }
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

      public void ScanKeyStart0H18( )
      {
         /* Scan By routine */
         /* Using cursor BC000H13 */
         pr_default.execute(11, new Object[] {A106RastreadorId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound18 = 1;
            A106RastreadorId = BC000H13_A106RastreadorId[0];
            A107RastreadorDataHoraCriacao = BC000H13_A107RastreadorDataHoraCriacao[0];
            A151RastreadorGAMGUIDProprietario = BC000H13_A151RastreadorGAMGUIDProprietario[0];
            A108RastreadorFabricante = BC000H13_A108RastreadorFabricante[0];
            n108RastreadorFabricante = BC000H13_n108RastreadorFabricante[0];
            A109RastreadorModelo = BC000H13_A109RastreadorModelo[0];
            n109RastreadorModelo = BC000H13_n109RastreadorModelo[0];
            A110RastreadorSNumber = BC000H13_A110RastreadorSNumber[0];
            A111RastreadorDeviceIdFlespi = BC000H13_A111RastreadorDeviceIdFlespi[0];
            A112RastreadorAtrelado = BC000H13_A112RastreadorAtrelado[0];
            A115ChipGSMOperadora = BC000H13_A115ChipGSMOperadora[0];
            A116ChipGSMNumero = BC000H13_A116ChipGSMNumero[0];
            A113ChipGSMId = BC000H13_A113ChipGSMId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H18( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound18 = 0;
         ScanKeyLoad0H18( ) ;
      }

      protected void ScanKeyLoad0H18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound18 = 1;
            A106RastreadorId = BC000H13_A106RastreadorId[0];
            A107RastreadorDataHoraCriacao = BC000H13_A107RastreadorDataHoraCriacao[0];
            A151RastreadorGAMGUIDProprietario = BC000H13_A151RastreadorGAMGUIDProprietario[0];
            A108RastreadorFabricante = BC000H13_A108RastreadorFabricante[0];
            n108RastreadorFabricante = BC000H13_n108RastreadorFabricante[0];
            A109RastreadorModelo = BC000H13_A109RastreadorModelo[0];
            n109RastreadorModelo = BC000H13_n109RastreadorModelo[0];
            A110RastreadorSNumber = BC000H13_A110RastreadorSNumber[0];
            A111RastreadorDeviceIdFlespi = BC000H13_A111RastreadorDeviceIdFlespi[0];
            A112RastreadorAtrelado = BC000H13_A112RastreadorAtrelado[0];
            A115ChipGSMOperadora = BC000H13_A115ChipGSMOperadora[0];
            A116ChipGSMNumero = BC000H13_A116ChipGSMNumero[0];
            A113ChipGSMId = BC000H13_A113ChipGSMId[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0H18( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0H18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H18( )
      {
         /* Before Delete Rules */
         new desatrelarchipgsm(context ).execute(  A113ChipGSMId) ;
      }

      protected void BeforeComplete0H18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H18( )
      {
      }

      protected void send_integrity_lvl_hashes0H18( )
      {
      }

      protected void AddRow0H18( )
      {
         VarsToRow18( bcRastreador) ;
      }

      protected void ReadRow0H18( )
      {
         RowToVars18( bcRastreador, 1) ;
      }

      protected void InitializeNonKey0H18( )
      {
         A108RastreadorFabricante = "";
         n108RastreadorFabricante = false;
         A109RastreadorModelo = "";
         n109RastreadorModelo = false;
         A110RastreadorSNumber = 0;
         A111RastreadorDeviceIdFlespi = 0;
         A112RastreadorAtrelado = false;
         A113ChipGSMId = 0;
         A115ChipGSMOperadora = "";
         A116ChipGSMNumero = "";
         A107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         A151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         O113ChipGSMId = A113ChipGSMId;
         Z107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z151RastreadorGAMGUIDProprietario = "";
         Z108RastreadorFabricante = "";
         Z109RastreadorModelo = "";
         Z110RastreadorSNumber = 0;
         Z111RastreadorDeviceIdFlespi = 0;
         Z112RastreadorAtrelado = false;
         Z113ChipGSMId = 0;
      }

      protected void InitAll0H18( )
      {
         A106RastreadorId = 0;
         InitializeNonKey0H18( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A107RastreadorDataHoraCriacao = i107RastreadorDataHoraCriacao;
         A151RastreadorGAMGUIDProprietario = i151RastreadorGAMGUIDProprietario;
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

      public void VarsToRow18( SdtRastreador obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Rastreadorfabricante = A108RastreadorFabricante;
         obj18.gxTpr_Rastreadormodelo = A109RastreadorModelo;
         obj18.gxTpr_Rastreadorsnumber = A110RastreadorSNumber;
         obj18.gxTpr_Rastreadordeviceidflespi = A111RastreadorDeviceIdFlespi;
         obj18.gxTpr_Rastreadoratrelado = A112RastreadorAtrelado;
         obj18.gxTpr_Chipgsmid = A113ChipGSMId;
         obj18.gxTpr_Chipgsmoperadora = A115ChipGSMOperadora;
         obj18.gxTpr_Chipgsmnumero = A116ChipGSMNumero;
         obj18.gxTpr_Rastreadordatahoracriacao = A107RastreadorDataHoraCriacao;
         obj18.gxTpr_Rastreadorgamguidproprietario = A151RastreadorGAMGUIDProprietario;
         obj18.gxTpr_Rastreadorid = A106RastreadorId;
         obj18.gxTpr_Rastreadorid_Z = Z106RastreadorId;
         obj18.gxTpr_Rastreadordatahoracriacao_Z = Z107RastreadorDataHoraCriacao;
         obj18.gxTpr_Rastreadorgamguidproprietario_Z = Z151RastreadorGAMGUIDProprietario;
         obj18.gxTpr_Rastreadorfabricante_Z = Z108RastreadorFabricante;
         obj18.gxTpr_Rastreadormodelo_Z = Z109RastreadorModelo;
         obj18.gxTpr_Rastreadorsnumber_Z = Z110RastreadorSNumber;
         obj18.gxTpr_Rastreadordeviceidflespi_Z = Z111RastreadorDeviceIdFlespi;
         obj18.gxTpr_Rastreadoratrelado_Z = Z112RastreadorAtrelado;
         obj18.gxTpr_Chipgsmid_Z = Z113ChipGSMId;
         obj18.gxTpr_Chipgsmoperadora_Z = Z115ChipGSMOperadora;
         obj18.gxTpr_Chipgsmnumero_Z = Z116ChipGSMNumero;
         obj18.gxTpr_Rastreadorfabricante_N = (short)(Convert.ToInt16(n108RastreadorFabricante));
         obj18.gxTpr_Rastreadormodelo_N = (short)(Convert.ToInt16(n109RastreadorModelo));
         obj18.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow18( SdtRastreador obj18 )
      {
         obj18.gxTpr_Rastreadorid = A106RastreadorId;
         return  ;
      }

      public void RowToVars18( SdtRastreador obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A108RastreadorFabricante = obj18.gxTpr_Rastreadorfabricante;
         n108RastreadorFabricante = false;
         A109RastreadorModelo = obj18.gxTpr_Rastreadormodelo;
         n109RastreadorModelo = false;
         A110RastreadorSNumber = obj18.gxTpr_Rastreadorsnumber;
         A111RastreadorDeviceIdFlespi = obj18.gxTpr_Rastreadordeviceidflespi;
         A112RastreadorAtrelado = obj18.gxTpr_Rastreadoratrelado;
         A113ChipGSMId = obj18.gxTpr_Chipgsmid;
         A115ChipGSMOperadora = obj18.gxTpr_Chipgsmoperadora;
         A116ChipGSMNumero = obj18.gxTpr_Chipgsmnumero;
         A107RastreadorDataHoraCriacao = obj18.gxTpr_Rastreadordatahoracriacao;
         A151RastreadorGAMGUIDProprietario = obj18.gxTpr_Rastreadorgamguidproprietario;
         A106RastreadorId = obj18.gxTpr_Rastreadorid;
         Z106RastreadorId = obj18.gxTpr_Rastreadorid_Z;
         Z107RastreadorDataHoraCriacao = obj18.gxTpr_Rastreadordatahoracriacao_Z;
         Z151RastreadorGAMGUIDProprietario = obj18.gxTpr_Rastreadorgamguidproprietario_Z;
         Z108RastreadorFabricante = obj18.gxTpr_Rastreadorfabricante_Z;
         Z109RastreadorModelo = obj18.gxTpr_Rastreadormodelo_Z;
         Z110RastreadorSNumber = obj18.gxTpr_Rastreadorsnumber_Z;
         Z111RastreadorDeviceIdFlespi = obj18.gxTpr_Rastreadordeviceidflespi_Z;
         Z112RastreadorAtrelado = obj18.gxTpr_Rastreadoratrelado_Z;
         Z113ChipGSMId = obj18.gxTpr_Chipgsmid_Z;
         O113ChipGSMId = obj18.gxTpr_Chipgsmid_Z;
         Z115ChipGSMOperadora = obj18.gxTpr_Chipgsmoperadora_Z;
         Z116ChipGSMNumero = obj18.gxTpr_Chipgsmnumero_Z;
         n108RastreadorFabricante = (bool)(Convert.ToBoolean(obj18.gxTpr_Rastreadorfabricante_N));
         n109RastreadorModelo = (bool)(Convert.ToBoolean(obj18.gxTpr_Rastreadormodelo_N));
         Gx_mode = obj18.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A106RastreadorId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H18( ) ;
         ScanKeyStart0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106RastreadorId = A106RastreadorId;
            O113ChipGSMId = A113ChipGSMId;
         }
         ZM0H18( -17) ;
         OnLoadActions0H18( ) ;
         AddRow0H18( ) ;
         ScanKeyEnd0H18( ) ;
         if ( RcdFound18 == 0 )
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
         RowToVars18( bcRastreador, 0) ;
         ScanKeyStart0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106RastreadorId = A106RastreadorId;
            O113ChipGSMId = A113ChipGSMId;
         }
         ZM0H18( -17) ;
         OnLoadActions0H18( ) ;
         AddRow0H18( ) ;
         ScanKeyEnd0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0H18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H18( ) ;
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A106RastreadorId != Z106RastreadorId )
               {
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
                  Update0H18( ) ;
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
                  if ( A106RastreadorId != Z106RastreadorId )
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
                        Insert0H18( ) ;
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
                        Insert0H18( ) ;
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
         RowToVars18( bcRastreador, 1) ;
         SaveImpl( ) ;
         VarsToRow18( bcRastreador) ;
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
         RowToVars18( bcRastreador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H18( ) ;
         AfterTrn( ) ;
         VarsToRow18( bcRastreador) ;
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
            SdtRastreador auxBC = new SdtRastreador(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A106RastreadorId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcRastreador);
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
         RowToVars18( bcRastreador, 1) ;
         UpdateImpl( ) ;
         VarsToRow18( bcRastreador) ;
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
         RowToVars18( bcRastreador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H18( ) ;
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
         VarsToRow18( bcRastreador) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars18( bcRastreador, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0H18( ) ;
         if ( RcdFound18 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A106RastreadorId != Z106RastreadorId )
            {
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
            if ( A106RastreadorId != Z106RastreadorId )
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
         context.RollbackDataStores("rastreador_bc",pr_default);
         VarsToRow18( bcRastreador) ;
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
         Gx_mode = bcRastreador.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcRastreador.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcRastreador )
         {
            bcRastreador = (SdtRastreador)(sdt);
            if ( StringUtil.StrCmp(bcRastreador.gxTpr_Mode, "") == 0 )
            {
               bcRastreador.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow18( bcRastreador) ;
            }
            else
            {
               RowToVars18( bcRastreador, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcRastreador.gxTpr_Mode, "") == 0 )
            {
               bcRastreador.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars18( bcRastreador, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtRastreador Rastreador_BC
      {
         get {
            return bcRastreador ;
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
            return "rastreador_Execute" ;
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
         AV24Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         A107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         Z151RastreadorGAMGUIDProprietario = "";
         A151RastreadorGAMGUIDProprietario = "";
         Z108RastreadorFabricante = "";
         A108RastreadorFabricante = "";
         Z109RastreadorModelo = "";
         A109RastreadorModelo = "";
         Z115ChipGSMOperadora = "";
         A115ChipGSMOperadora = "";
         Z116ChipGSMNumero = "";
         A116ChipGSMNumero = "";
         GXt_char1 = "";
         BC000H5_A106RastreadorId = new int[1] ;
         BC000H5_A107RastreadorDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000H5_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         BC000H5_A108RastreadorFabricante = new string[] {""} ;
         BC000H5_n108RastreadorFabricante = new bool[] {false} ;
         BC000H5_A109RastreadorModelo = new string[] {""} ;
         BC000H5_n109RastreadorModelo = new bool[] {false} ;
         BC000H5_A110RastreadorSNumber = new long[1] ;
         BC000H5_A111RastreadorDeviceIdFlespi = new long[1] ;
         BC000H5_A112RastreadorAtrelado = new bool[] {false} ;
         BC000H5_A115ChipGSMOperadora = new string[] {""} ;
         BC000H5_A116ChipGSMNumero = new string[] {""} ;
         BC000H5_A113ChipGSMId = new int[1] ;
         BC000H4_A115ChipGSMOperadora = new string[] {""} ;
         BC000H4_A116ChipGSMNumero = new string[] {""} ;
         BC000H6_A106RastreadorId = new int[1] ;
         BC000H3_A106RastreadorId = new int[1] ;
         BC000H3_A107RastreadorDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000H3_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         BC000H3_A108RastreadorFabricante = new string[] {""} ;
         BC000H3_n108RastreadorFabricante = new bool[] {false} ;
         BC000H3_A109RastreadorModelo = new string[] {""} ;
         BC000H3_n109RastreadorModelo = new bool[] {false} ;
         BC000H3_A110RastreadorSNumber = new long[1] ;
         BC000H3_A111RastreadorDeviceIdFlespi = new long[1] ;
         BC000H3_A112RastreadorAtrelado = new bool[] {false} ;
         BC000H3_A113ChipGSMId = new int[1] ;
         sMode18 = "";
         BC000H2_A106RastreadorId = new int[1] ;
         BC000H2_A107RastreadorDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000H2_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         BC000H2_A108RastreadorFabricante = new string[] {""} ;
         BC000H2_n108RastreadorFabricante = new bool[] {false} ;
         BC000H2_A109RastreadorModelo = new string[] {""} ;
         BC000H2_n109RastreadorModelo = new bool[] {false} ;
         BC000H2_A110RastreadorSNumber = new long[1] ;
         BC000H2_A111RastreadorDeviceIdFlespi = new long[1] ;
         BC000H2_A112RastreadorAtrelado = new bool[] {false} ;
         BC000H2_A113ChipGSMId = new int[1] ;
         BC000H7_A106RastreadorId = new int[1] ;
         BC000H10_A115ChipGSMOperadora = new string[] {""} ;
         BC000H10_A116ChipGSMNumero = new string[] {""} ;
         BC000H11_A144ComandoEnviadoId = new int[1] ;
         BC000H12_A98VeiculoId = new int[1] ;
         BC000H12_A106RastreadorId = new int[1] ;
         BC000H13_A106RastreadorId = new int[1] ;
         BC000H13_A107RastreadorDataHoraCriacao = new DateTime[] {DateTime.MinValue} ;
         BC000H13_A151RastreadorGAMGUIDProprietario = new string[] {""} ;
         BC000H13_A108RastreadorFabricante = new string[] {""} ;
         BC000H13_n108RastreadorFabricante = new bool[] {false} ;
         BC000H13_A109RastreadorModelo = new string[] {""} ;
         BC000H13_n109RastreadorModelo = new bool[] {false} ;
         BC000H13_A110RastreadorSNumber = new long[1] ;
         BC000H13_A111RastreadorDeviceIdFlespi = new long[1] ;
         BC000H13_A112RastreadorAtrelado = new bool[] {false} ;
         BC000H13_A115ChipGSMOperadora = new string[] {""} ;
         BC000H13_A116ChipGSMNumero = new string[] {""} ;
         BC000H13_A113ChipGSMId = new int[1] ;
         i107RastreadorDataHoraCriacao = (DateTime)(DateTime.MinValue);
         i151RastreadorGAMGUIDProprietario = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.rastreador_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rastreador_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A106RastreadorId, BC000H2_A107RastreadorDataHoraCriacao, BC000H2_A151RastreadorGAMGUIDProprietario, BC000H2_A108RastreadorFabricante, BC000H2_n108RastreadorFabricante, BC000H2_A109RastreadorModelo, BC000H2_n109RastreadorModelo, BC000H2_A110RastreadorSNumber, BC000H2_A111RastreadorDeviceIdFlespi, BC000H2_A112RastreadorAtrelado,
               BC000H2_A113ChipGSMId
               }
               , new Object[] {
               BC000H3_A106RastreadorId, BC000H3_A107RastreadorDataHoraCriacao, BC000H3_A151RastreadorGAMGUIDProprietario, BC000H3_A108RastreadorFabricante, BC000H3_n108RastreadorFabricante, BC000H3_A109RastreadorModelo, BC000H3_n109RastreadorModelo, BC000H3_A110RastreadorSNumber, BC000H3_A111RastreadorDeviceIdFlespi, BC000H3_A112RastreadorAtrelado,
               BC000H3_A113ChipGSMId
               }
               , new Object[] {
               BC000H4_A115ChipGSMOperadora, BC000H4_A116ChipGSMNumero
               }
               , new Object[] {
               BC000H5_A106RastreadorId, BC000H5_A107RastreadorDataHoraCriacao, BC000H5_A151RastreadorGAMGUIDProprietario, BC000H5_A108RastreadorFabricante, BC000H5_n108RastreadorFabricante, BC000H5_A109RastreadorModelo, BC000H5_n109RastreadorModelo, BC000H5_A110RastreadorSNumber, BC000H5_A111RastreadorDeviceIdFlespi, BC000H5_A112RastreadorAtrelado,
               BC000H5_A115ChipGSMOperadora, BC000H5_A116ChipGSMNumero, BC000H5_A113ChipGSMId
               }
               , new Object[] {
               BC000H6_A106RastreadorId
               }
               , new Object[] {
               BC000H7_A106RastreadorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H10_A115ChipGSMOperadora, BC000H10_A116ChipGSMNumero
               }
               , new Object[] {
               BC000H11_A144ComandoEnviadoId
               }
               , new Object[] {
               BC000H12_A98VeiculoId, BC000H12_A106RastreadorId
               }
               , new Object[] {
               BC000H13_A106RastreadorId, BC000H13_A107RastreadorDataHoraCriacao, BC000H13_A151RastreadorGAMGUIDProprietario, BC000H13_A108RastreadorFabricante, BC000H13_n108RastreadorFabricante, BC000H13_A109RastreadorModelo, BC000H13_n109RastreadorModelo, BC000H13_A110RastreadorSNumber, BC000H13_A111RastreadorDeviceIdFlespi, BC000H13_A112RastreadorAtrelado,
               BC000H13_A115ChipGSMOperadora, BC000H13_A116ChipGSMNumero, BC000H13_A113ChipGSMId
               }
            }
         );
         AV24Pgmname = "Rastreador_BC";
         Z151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         A151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         i151RastreadorGAMGUIDProprietario = new buscargamguidusuariologado(context).executeUdp( );
         Z107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         A107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         i107RastreadorDataHoraCriacao = DateTimeUtil.ServerNow( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120H2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound18 ;
      private short nIsDirty_18 ;
      private int trnEnded ;
      private int Z106RastreadorId ;
      private int A106RastreadorId ;
      private int AV25GXV1 ;
      private int AV13Insert_ChipGSMId ;
      private int Z113ChipGSMId ;
      private int A113ChipGSMId ;
      private int O113ChipGSMId ;
      private long Z110RastreadorSNumber ;
      private long A110RastreadorSNumber ;
      private long Z111RastreadorDeviceIdFlespi ;
      private long A111RastreadorDeviceIdFlespi ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string Z151RastreadorGAMGUIDProprietario ;
      private string A151RastreadorGAMGUIDProprietario ;
      private string GXt_char1 ;
      private string sMode18 ;
      private string i151RastreadorGAMGUIDProprietario ;
      private DateTime Z107RastreadorDataHoraCriacao ;
      private DateTime A107RastreadorDataHoraCriacao ;
      private DateTime i107RastreadorDataHoraCriacao ;
      private bool returnInSub ;
      private bool Z112RastreadorAtrelado ;
      private bool A112RastreadorAtrelado ;
      private bool n108RastreadorFabricante ;
      private bool n109RastreadorModelo ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z108RastreadorFabricante ;
      private string A108RastreadorFabricante ;
      private string Z109RastreadorModelo ;
      private string A109RastreadorModelo ;
      private string Z115ChipGSMOperadora ;
      private string A115ChipGSMOperadora ;
      private string Z116ChipGSMNumero ;
      private string A116ChipGSMNumero ;
      private IGxSession AV12WebSession ;
      private SdtRastreador bcRastreador ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000H5_A106RastreadorId ;
      private DateTime[] BC000H5_A107RastreadorDataHoraCriacao ;
      private string[] BC000H5_A151RastreadorGAMGUIDProprietario ;
      private string[] BC000H5_A108RastreadorFabricante ;
      private bool[] BC000H5_n108RastreadorFabricante ;
      private string[] BC000H5_A109RastreadorModelo ;
      private bool[] BC000H5_n109RastreadorModelo ;
      private long[] BC000H5_A110RastreadorSNumber ;
      private long[] BC000H5_A111RastreadorDeviceIdFlespi ;
      private bool[] BC000H5_A112RastreadorAtrelado ;
      private string[] BC000H5_A115ChipGSMOperadora ;
      private string[] BC000H5_A116ChipGSMNumero ;
      private int[] BC000H5_A113ChipGSMId ;
      private string[] BC000H4_A115ChipGSMOperadora ;
      private string[] BC000H4_A116ChipGSMNumero ;
      private int[] BC000H6_A106RastreadorId ;
      private int[] BC000H3_A106RastreadorId ;
      private DateTime[] BC000H3_A107RastreadorDataHoraCriacao ;
      private string[] BC000H3_A151RastreadorGAMGUIDProprietario ;
      private string[] BC000H3_A108RastreadorFabricante ;
      private bool[] BC000H3_n108RastreadorFabricante ;
      private string[] BC000H3_A109RastreadorModelo ;
      private bool[] BC000H3_n109RastreadorModelo ;
      private long[] BC000H3_A110RastreadorSNumber ;
      private long[] BC000H3_A111RastreadorDeviceIdFlespi ;
      private bool[] BC000H3_A112RastreadorAtrelado ;
      private int[] BC000H3_A113ChipGSMId ;
      private int[] BC000H2_A106RastreadorId ;
      private DateTime[] BC000H2_A107RastreadorDataHoraCriacao ;
      private string[] BC000H2_A151RastreadorGAMGUIDProprietario ;
      private string[] BC000H2_A108RastreadorFabricante ;
      private bool[] BC000H2_n108RastreadorFabricante ;
      private string[] BC000H2_A109RastreadorModelo ;
      private bool[] BC000H2_n109RastreadorModelo ;
      private long[] BC000H2_A110RastreadorSNumber ;
      private long[] BC000H2_A111RastreadorDeviceIdFlespi ;
      private bool[] BC000H2_A112RastreadorAtrelado ;
      private int[] BC000H2_A113ChipGSMId ;
      private int[] BC000H7_A106RastreadorId ;
      private string[] BC000H10_A115ChipGSMOperadora ;
      private string[] BC000H10_A116ChipGSMNumero ;
      private int[] BC000H11_A144ComandoEnviadoId ;
      private int[] BC000H12_A98VeiculoId ;
      private int[] BC000H12_A106RastreadorId ;
      private int[] BC000H13_A106RastreadorId ;
      private DateTime[] BC000H13_A107RastreadorDataHoraCriacao ;
      private string[] BC000H13_A151RastreadorGAMGUIDProprietario ;
      private string[] BC000H13_A108RastreadorFabricante ;
      private bool[] BC000H13_n108RastreadorFabricante ;
      private string[] BC000H13_A109RastreadorModelo ;
      private bool[] BC000H13_n109RastreadorModelo ;
      private long[] BC000H13_A110RastreadorSNumber ;
      private long[] BC000H13_A111RastreadorDeviceIdFlespi ;
      private bool[] BC000H13_A112RastreadorAtrelado ;
      private string[] BC000H13_A115ChipGSMOperadora ;
      private string[] BC000H13_A116ChipGSMNumero ;
      private int[] BC000H13_A113ChipGSMId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class rastreador_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class rastreador_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000H5;
        prmBC000H5 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H4;
        prmBC000H4 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H6;
        prmBC000H6 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H3;
        prmBC000H3 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H2;
        prmBC000H2 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H7;
        prmBC000H7 = new Object[] {
        new Object[] {"@RastreadorDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@RastreadorGAMGUIDProprietario",SqlDbType.NChar,40,0} ,
        new Object[] {"@RastreadorFabricante",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorModelo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorSNumber",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorDeviceIdFlespi",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H8;
        prmBC000H8 = new Object[] {
        new Object[] {"@RastreadorDataHoraCriacao",SqlDbType.DateTime,8,5} ,
        new Object[] {"@RastreadorGAMGUIDProprietario",SqlDbType.NChar,40,0} ,
        new Object[] {"@RastreadorFabricante",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorModelo",SqlDbType.NVarChar,40,0} ,
        new Object[] {"@RastreadorSNumber",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorDeviceIdFlespi",SqlDbType.Decimal,16,0} ,
        new Object[] {"@RastreadorAtrelado",SqlDbType.Bit,4,0} ,
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H9;
        prmBC000H9 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H10;
        prmBC000H10 = new Object[] {
        new Object[] {"@ChipGSMId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H11;
        prmBC000H11 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H12;
        prmBC000H12 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000H13;
        prmBC000H13 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000H2", "SELECT [RastreadorId], [RastreadorDataHoraCriacao], [RastreadorGAMGUIDProprietario], [RastreadorFabricante], [RastreadorModelo], [RastreadorSNumber], [RastreadorDeviceIdFlespi], [RastreadorAtrelado], [ChipGSMId] FROM [Rastreador] WITH (UPDLOCK) WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H3", "SELECT [RastreadorId], [RastreadorDataHoraCriacao], [RastreadorGAMGUIDProprietario], [RastreadorFabricante], [RastreadorModelo], [RastreadorSNumber], [RastreadorDeviceIdFlespi], [RastreadorAtrelado], [ChipGSMId] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H4", "SELECT [ChipGSMOperadora], [ChipGSMNumero] FROM [ChipGSM] WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H5", "SELECT TM1.[RastreadorId], TM1.[RastreadorDataHoraCriacao], TM1.[RastreadorGAMGUIDProprietario], TM1.[RastreadorFabricante], TM1.[RastreadorModelo], TM1.[RastreadorSNumber], TM1.[RastreadorDeviceIdFlespi], TM1.[RastreadorAtrelado], T2.[ChipGSMOperadora], T2.[ChipGSMNumero], TM1.[ChipGSMId] FROM ([Rastreador] TM1 INNER JOIN [ChipGSM] T2 ON T2.[ChipGSMId] = TM1.[ChipGSMId]) WHERE TM1.[RastreadorId] = @RastreadorId ORDER BY TM1.[RastreadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H6", "SELECT [RastreadorId] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H7", "INSERT INTO [Rastreador]([RastreadorDataHoraCriacao], [RastreadorGAMGUIDProprietario], [RastreadorFabricante], [RastreadorModelo], [RastreadorSNumber], [RastreadorDeviceIdFlespi], [RastreadorAtrelado], [ChipGSMId]) VALUES(@RastreadorDataHoraCriacao, @RastreadorGAMGUIDProprietario, @RastreadorFabricante, @RastreadorModelo, @RastreadorSNumber, @RastreadorDeviceIdFlespi, @RastreadorAtrelado, @ChipGSMId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000H7)
           ,new CursorDef("BC000H8", "UPDATE [Rastreador] SET [RastreadorDataHoraCriacao]=@RastreadorDataHoraCriacao, [RastreadorGAMGUIDProprietario]=@RastreadorGAMGUIDProprietario, [RastreadorFabricante]=@RastreadorFabricante, [RastreadorModelo]=@RastreadorModelo, [RastreadorSNumber]=@RastreadorSNumber, [RastreadorDeviceIdFlespi]=@RastreadorDeviceIdFlespi, [RastreadorAtrelado]=@RastreadorAtrelado, [ChipGSMId]=@ChipGSMId  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK,prmBC000H8)
           ,new CursorDef("BC000H9", "DELETE FROM [Rastreador]  WHERE [RastreadorId] = @RastreadorId", GxErrorMask.GX_NOMASK,prmBC000H9)
           ,new CursorDef("BC000H10", "SELECT [ChipGSMOperadora], [ChipGSMNumero] FROM [ChipGSM] WHERE [ChipGSMId] = @ChipGSMId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H11", "SELECT TOP 1 [ComandoEnviadoId] FROM [ComandoEnviado] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000H12", "SELECT TOP 1 [VeiculoId], [RastreadorId] FROM [VeiculoRastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000H13", "SELECT TM1.[RastreadorId], TM1.[RastreadorDataHoraCriacao], TM1.[RastreadorGAMGUIDProprietario], TM1.[RastreadorFabricante], TM1.[RastreadorModelo], TM1.[RastreadorSNumber], TM1.[RastreadorDeviceIdFlespi], TM1.[RastreadorAtrelado], T2.[ChipGSMOperadora], T2.[ChipGSMNumero], TM1.[ChipGSMId] FROM ([Rastreador] TM1 INNER JOIN [ChipGSM] T2 ON T2.[ChipGSMId] = TM1.[ChipGSMId]) WHERE TM1.[RastreadorId] = @RastreadorId ORDER BY TM1.[RastreadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H13,100, GxCacheFrequency.OFF ,true,false )
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
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              table[8][0] = rslt.getLong(7);
              table[9][0] = rslt.getBool(8);
              table[10][0] = rslt.getInt(9);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              table[8][0] = rslt.getLong(7);
              table[9][0] = rslt.getBool(8);
              table[10][0] = rslt.getInt(9);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              table[8][0] = rslt.getLong(7);
              table[9][0] = rslt.getBool(8);
              table[10][0] = rslt.getVarchar(9);
              table[11][0] = rslt.getVarchar(10);
              table[12][0] = rslt.getInt(11);
              return;
           case 4 :
              table[0][0] = rslt.getInt(1);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              return;
           case 8 :
              table[0][0] = rslt.getVarchar(1);
              table[1][0] = rslt.getVarchar(2);
              return;
           case 9 :
              table[0][0] = rslt.getInt(1);
              return;
           case 10 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 11 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getString(3, 40);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.wasNull(4);
              table[5][0] = rslt.getVarchar(5);
              table[6][0] = rslt.wasNull(5);
              table[7][0] = rslt.getLong(6);
              table[8][0] = rslt.getLong(7);
              table[9][0] = rslt.getBool(8);
              table[10][0] = rslt.getVarchar(9);
              table[11][0] = rslt.getVarchar(10);
              table[12][0] = rslt.getInt(11);
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
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 5 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 4 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(4, (string)parms[5]);
              }
              stmt.SetParameter(5, (long)parms[6]);
              stmt.SetParameter(6, (long)parms[7]);
              stmt.SetParameter(7, (bool)parms[8]);
              stmt.SetParameter(8, (int)parms[9]);
              return;
           case 6 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(3, (string)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 4 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(4, (string)parms[5]);
              }
              stmt.SetParameter(5, (long)parms[6]);
              stmt.SetParameter(6, (long)parms[7]);
              stmt.SetParameter(7, (bool)parms[8]);
              stmt.SetParameter(8, (int)parms[9]);
              stmt.SetParameter(9, (int)parms[10]);
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
           case 11 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
