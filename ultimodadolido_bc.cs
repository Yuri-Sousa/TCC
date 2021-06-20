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
   public class ultimodadolido_bc : GXHttpHandler, IGxSilentTrn
   {
      public ultimodadolido_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ultimodadolido_bc( IGxContext context )
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
         ReadRow0J20( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0J20( ) ;
         standaloneModal( ) ;
         AddRow0J20( ) ;
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
            E110J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z118UltimoDadoLidoId = A118UltimoDadoLidoId;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J20( ) ;
            }
            else
            {
               CheckExtendedTable0J20( ) ;
               if ( AnyError == 0 )
               {
                  ZM0J20( 7) ;
               }
               CloseExtendedTableCursors0J20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "WWPTransactionContext", "RastreamentoTCC");
      }

      protected void E110J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0J20( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z119UltimoDadoLidoDataHoraServidor = A119UltimoDadoLidoDataHoraServidor;
            Z120UltimoDadoLidoDataHoraRastreador = A120UltimoDadoLidoDataHoraRastreador;
            Z121UltimoDadoLidoPlaca = A121UltimoDadoLidoPlaca;
            Z126UltimoDadoLidoIdent = A126UltimoDadoLidoIdent;
            Z122UltimoDadoLidoIgnicao = A122UltimoDadoLidoIgnicao;
            Z125UltimoDadoLidoVelocidade = A125UltimoDadoLidoVelocidade;
            Z123UltimoDadoLidoLatitude = A123UltimoDadoLidoLatitude;
            Z124UltimoDadoLidoLongitude = A124UltimoDadoLidoLongitude;
            Z153UltimoDadoLidoGAMGUIDProprietario = A153UltimoDadoLidoGAMGUIDProprietario;
            Z127UltimoDadoLidoGeolocalizacao = A127UltimoDadoLidoGeolocalizacao;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z153UltimoDadoLidoGAMGUIDProprietario = A153UltimoDadoLidoGAMGUIDProprietario;
            Z127UltimoDadoLidoGeolocalizacao = A127UltimoDadoLidoGeolocalizacao;
         }
         if ( GX_JID == -5 )
         {
            Z118UltimoDadoLidoId = A118UltimoDadoLidoId;
            Z119UltimoDadoLidoDataHoraServidor = A119UltimoDadoLidoDataHoraServidor;
            Z120UltimoDadoLidoDataHoraRastreador = A120UltimoDadoLidoDataHoraRastreador;
            Z121UltimoDadoLidoPlaca = A121UltimoDadoLidoPlaca;
            Z126UltimoDadoLidoIdent = A126UltimoDadoLidoIdent;
            Z122UltimoDadoLidoIgnicao = A122UltimoDadoLidoIgnicao;
            Z125UltimoDadoLidoVelocidade = A125UltimoDadoLidoVelocidade;
            Z123UltimoDadoLidoLatitude = A123UltimoDadoLidoLatitude;
            Z124UltimoDadoLidoLongitude = A124UltimoDadoLidoLongitude;
            Z153UltimoDadoLidoGAMGUIDProprietario = A153UltimoDadoLidoGAMGUIDProprietario;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0J20( )
      {
         /* Using cursor BC000J5 */
         pr_default.execute(3, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
            A119UltimoDadoLidoDataHoraServidor = BC000J5_A119UltimoDadoLidoDataHoraServidor[0];
            A120UltimoDadoLidoDataHoraRastreador = BC000J5_A120UltimoDadoLidoDataHoraRastreador[0];
            A121UltimoDadoLidoPlaca = BC000J5_A121UltimoDadoLidoPlaca[0];
            A126UltimoDadoLidoIdent = BC000J5_A126UltimoDadoLidoIdent[0];
            A122UltimoDadoLidoIgnicao = BC000J5_A122UltimoDadoLidoIgnicao[0];
            A125UltimoDadoLidoVelocidade = BC000J5_A125UltimoDadoLidoVelocidade[0];
            A123UltimoDadoLidoLatitude = BC000J5_A123UltimoDadoLidoLatitude[0];
            A124UltimoDadoLidoLongitude = BC000J5_A124UltimoDadoLidoLongitude[0];
            A153UltimoDadoLidoGAMGUIDProprietario = BC000J5_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = BC000J5_n153UltimoDadoLidoGAMGUIDProprietario[0];
            ZM0J20( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0J20( ) ;
      }

      protected void OnLoadActions0J20( )
      {
         A127UltimoDadoLidoGeolocalizacao = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".") + "," + StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
      }

      protected void CheckExtendedTable0J20( )
      {
         nIsDirty_20 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000J6 */
         pr_default.execute(4, new Object[] {A126UltimoDadoLidoIdent, A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Número do Rastreador"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A119UltimoDadoLidoDataHoraServidor) || ( A119UltimoDadoLidoDataHoraServidor >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Hora Servidor fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A120UltimoDadoLidoDataHoraRastreador) || ( A120UltimoDadoLidoDataHoraRastreador >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Hora Rastreador fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000J4 */
         pr_default.execute(2, new Object[] {A121UltimoDadoLidoPlaca});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A153UltimoDadoLidoGAMGUIDProprietario = BC000J4_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = BC000J4_n153UltimoDadoLidoGAMGUIDProprietario[0];
         }
         else
         {
            nIsDirty_20 = 1;
            A153UltimoDadoLidoGAMGUIDProprietario = "";
            n153UltimoDadoLidoGAMGUIDProprietario = false;
         }
         pr_default.close(2);
         if ( ! ( ( A122UltimoDadoLidoIgnicao == 1 ) || ( A122UltimoDadoLidoIgnicao == 2 ) ) )
         {
            GX_msglist.addItem("Campo Ignição fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         nIsDirty_20 = 1;
         A127UltimoDadoLidoGeolocalizacao = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".") + "," + StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
      }

      protected void CloseExtendedTableCursors0J20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J20( )
      {
         /* Using cursor BC000J7 */
         pr_default.execute(5, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000J3 */
         pr_default.execute(1, new Object[] {A118UltimoDadoLidoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J20( 5) ;
            RcdFound20 = 1;
            A118UltimoDadoLidoId = BC000J3_A118UltimoDadoLidoId[0];
            A119UltimoDadoLidoDataHoraServidor = BC000J3_A119UltimoDadoLidoDataHoraServidor[0];
            A120UltimoDadoLidoDataHoraRastreador = BC000J3_A120UltimoDadoLidoDataHoraRastreador[0];
            A121UltimoDadoLidoPlaca = BC000J3_A121UltimoDadoLidoPlaca[0];
            A126UltimoDadoLidoIdent = BC000J3_A126UltimoDadoLidoIdent[0];
            A122UltimoDadoLidoIgnicao = BC000J3_A122UltimoDadoLidoIgnicao[0];
            A125UltimoDadoLidoVelocidade = BC000J3_A125UltimoDadoLidoVelocidade[0];
            A123UltimoDadoLidoLatitude = BC000J3_A123UltimoDadoLidoLatitude[0];
            A124UltimoDadoLidoLongitude = BC000J3_A124UltimoDadoLidoLongitude[0];
            Z118UltimoDadoLidoId = A118UltimoDadoLidoId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0J20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0J20( ) ;
            }
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0J20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode20;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J20( ) ;
         if ( RcdFound20 == 0 )
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
         CONFIRM_0J0( ) ;
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

      protected void CheckOptimisticConcurrency0J20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000J2 */
            pr_default.execute(0, new Object[] {A118UltimoDadoLidoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UltimoDadoLido"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z119UltimoDadoLidoDataHoraServidor != BC000J2_A119UltimoDadoLidoDataHoraServidor[0] ) || ( Z120UltimoDadoLidoDataHoraRastreador != BC000J2_A120UltimoDadoLidoDataHoraRastreador[0] ) || ( StringUtil.StrCmp(Z121UltimoDadoLidoPlaca, BC000J2_A121UltimoDadoLidoPlaca[0]) != 0 ) || ( Z126UltimoDadoLidoIdent != BC000J2_A126UltimoDadoLidoIdent[0] ) || ( Z122UltimoDadoLidoIgnicao != BC000J2_A122UltimoDadoLidoIgnicao[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z125UltimoDadoLidoVelocidade != BC000J2_A125UltimoDadoLidoVelocidade[0] ) || ( StringUtil.StrCmp(Z123UltimoDadoLidoLatitude, BC000J2_A123UltimoDadoLidoLatitude[0]) != 0 ) || ( StringUtil.StrCmp(Z124UltimoDadoLidoLongitude, BC000J2_A124UltimoDadoLidoLongitude[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UltimoDadoLido"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J20( 0) ;
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J8 */
                     pr_default.execute(6, new Object[] {A119UltimoDadoLidoDataHoraServidor, A120UltimoDadoLidoDataHoraRastreador, A121UltimoDadoLidoPlaca, A126UltimoDadoLidoIdent, A122UltimoDadoLidoIgnicao, A125UltimoDadoLidoVelocidade, A123UltimoDadoLidoLatitude, A124UltimoDadoLidoLongitude});
                     A118UltimoDadoLidoId = BC000J8_A118UltimoDadoLidoId[0];
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
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
               Load0J20( ) ;
            }
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void Update0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J9 */
                     pr_default.execute(7, new Object[] {A119UltimoDadoLidoDataHoraServidor, A120UltimoDadoLidoDataHoraRastreador, A121UltimoDadoLidoPlaca, A126UltimoDadoLidoIdent, A122UltimoDadoLidoIgnicao, A125UltimoDadoLidoVelocidade, A123UltimoDadoLidoLatitude, A124UltimoDadoLidoLongitude, A118UltimoDadoLidoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UltimoDadoLido"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J20( ) ;
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
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void DeferredUpdate0J20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J20( ) ;
            AfterConfirm0J20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000J10 */
                  pr_default.execute(8, new Object[] {A118UltimoDadoLidoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("UltimoDadoLido");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0J20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0J20( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000J11 */
            pr_default.execute(9, new Object[] {A121UltimoDadoLidoPlaca});
            if ( (pr_default.getStatus(9) != 101) )
            {
               A153UltimoDadoLidoGAMGUIDProprietario = BC000J11_A153UltimoDadoLidoGAMGUIDProprietario[0];
               n153UltimoDadoLidoGAMGUIDProprietario = BC000J11_n153UltimoDadoLidoGAMGUIDProprietario[0];
            }
            else
            {
               A153UltimoDadoLidoGAMGUIDProprietario = "";
               n153UltimoDadoLidoGAMGUIDProprietario = false;
            }
            pr_default.close(9);
            A127UltimoDadoLidoGeolocalizacao = StringUtil.StringReplace( StringUtil.Trim( A123UltimoDadoLidoLatitude), ",", ".") + "," + StringUtil.StringReplace( StringUtil.Trim( A124UltimoDadoLidoLongitude), ",", ".");
         }
      }

      protected void EndLevel0J20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J20( ) ;
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

      public void ScanKeyStart0J20( )
      {
         /* Scan By routine */
         /* Using cursor BC000J12 */
         pr_default.execute(10, new Object[] {A118UltimoDadoLidoId});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound20 = 1;
            A118UltimoDadoLidoId = BC000J12_A118UltimoDadoLidoId[0];
            A119UltimoDadoLidoDataHoraServidor = BC000J12_A119UltimoDadoLidoDataHoraServidor[0];
            A120UltimoDadoLidoDataHoraRastreador = BC000J12_A120UltimoDadoLidoDataHoraRastreador[0];
            A121UltimoDadoLidoPlaca = BC000J12_A121UltimoDadoLidoPlaca[0];
            A126UltimoDadoLidoIdent = BC000J12_A126UltimoDadoLidoIdent[0];
            A122UltimoDadoLidoIgnicao = BC000J12_A122UltimoDadoLidoIgnicao[0];
            A125UltimoDadoLidoVelocidade = BC000J12_A125UltimoDadoLidoVelocidade[0];
            A123UltimoDadoLidoLatitude = BC000J12_A123UltimoDadoLidoLatitude[0];
            A124UltimoDadoLidoLongitude = BC000J12_A124UltimoDadoLidoLongitude[0];
            A153UltimoDadoLidoGAMGUIDProprietario = BC000J12_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = BC000J12_n153UltimoDadoLidoGAMGUIDProprietario[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0J20( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound20 = 0;
         ScanKeyLoad0J20( ) ;
      }

      protected void ScanKeyLoad0J20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound20 = 1;
            A118UltimoDadoLidoId = BC000J12_A118UltimoDadoLidoId[0];
            A119UltimoDadoLidoDataHoraServidor = BC000J12_A119UltimoDadoLidoDataHoraServidor[0];
            A120UltimoDadoLidoDataHoraRastreador = BC000J12_A120UltimoDadoLidoDataHoraRastreador[0];
            A121UltimoDadoLidoPlaca = BC000J12_A121UltimoDadoLidoPlaca[0];
            A126UltimoDadoLidoIdent = BC000J12_A126UltimoDadoLidoIdent[0];
            A122UltimoDadoLidoIgnicao = BC000J12_A122UltimoDadoLidoIgnicao[0];
            A125UltimoDadoLidoVelocidade = BC000J12_A125UltimoDadoLidoVelocidade[0];
            A123UltimoDadoLidoLatitude = BC000J12_A123UltimoDadoLidoLatitude[0];
            A124UltimoDadoLidoLongitude = BC000J12_A124UltimoDadoLidoLongitude[0];
            A153UltimoDadoLidoGAMGUIDProprietario = BC000J12_A153UltimoDadoLidoGAMGUIDProprietario[0];
            n153UltimoDadoLidoGAMGUIDProprietario = BC000J12_n153UltimoDadoLidoGAMGUIDProprietario[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0J20( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0J20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J20( )
      {
      }

      protected void send_integrity_lvl_hashes0J20( )
      {
      }

      protected void AddRow0J20( )
      {
         VarsToRow20( bcUltimoDadoLido) ;
      }

      protected void ReadRow0J20( )
      {
         RowToVars20( bcUltimoDadoLido, 1) ;
      }

      protected void InitializeNonKey0J20( )
      {
         A127UltimoDadoLidoGeolocalizacao = "";
         A153UltimoDadoLidoGAMGUIDProprietario = "";
         n153UltimoDadoLidoGAMGUIDProprietario = false;
         A119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         A120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         A121UltimoDadoLidoPlaca = "";
         A126UltimoDadoLidoIdent = 0;
         A122UltimoDadoLidoIgnicao = 0;
         A125UltimoDadoLidoVelocidade = 0;
         A123UltimoDadoLidoLatitude = "";
         A124UltimoDadoLidoLongitude = "";
         Z119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         Z120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         Z121UltimoDadoLidoPlaca = "";
         Z126UltimoDadoLidoIdent = 0;
         Z122UltimoDadoLidoIgnicao = 0;
         Z125UltimoDadoLidoVelocidade = 0;
         Z123UltimoDadoLidoLatitude = "";
         Z124UltimoDadoLidoLongitude = "";
      }

      protected void InitAll0J20( )
      {
         A118UltimoDadoLidoId = 0;
         InitializeNonKey0J20( ) ;
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

      public void VarsToRow20( SdtUltimoDadoLido obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Ultimodadolidogeolocalizacao = A127UltimoDadoLidoGeolocalizacao;
         obj20.gxTpr_Ultimodadolidogamguidproprietario = A153UltimoDadoLidoGAMGUIDProprietario;
         obj20.gxTpr_Ultimodadolidodatahoraservidor = A119UltimoDadoLidoDataHoraServidor;
         obj20.gxTpr_Ultimodadolidodatahorarastreador = A120UltimoDadoLidoDataHoraRastreador;
         obj20.gxTpr_Ultimodadolidoplaca = A121UltimoDadoLidoPlaca;
         obj20.gxTpr_Ultimodadolidoident = A126UltimoDadoLidoIdent;
         obj20.gxTpr_Ultimodadolidoignicao = A122UltimoDadoLidoIgnicao;
         obj20.gxTpr_Ultimodadolidovelocidade = A125UltimoDadoLidoVelocidade;
         obj20.gxTpr_Ultimodadolidolatitude = A123UltimoDadoLidoLatitude;
         obj20.gxTpr_Ultimodadolidolongitude = A124UltimoDadoLidoLongitude;
         obj20.gxTpr_Ultimodadolidoid = A118UltimoDadoLidoId;
         obj20.gxTpr_Ultimodadolidoid_Z = Z118UltimoDadoLidoId;
         obj20.gxTpr_Ultimodadolidogamguidproprietario_Z = Z153UltimoDadoLidoGAMGUIDProprietario;
         obj20.gxTpr_Ultimodadolidodatahoraservidor_Z = Z119UltimoDadoLidoDataHoraServidor;
         obj20.gxTpr_Ultimodadolidodatahorarastreador_Z = Z120UltimoDadoLidoDataHoraRastreador;
         obj20.gxTpr_Ultimodadolidoplaca_Z = Z121UltimoDadoLidoPlaca;
         obj20.gxTpr_Ultimodadolidoident_Z = Z126UltimoDadoLidoIdent;
         obj20.gxTpr_Ultimodadolidoignicao_Z = Z122UltimoDadoLidoIgnicao;
         obj20.gxTpr_Ultimodadolidovelocidade_Z = Z125UltimoDadoLidoVelocidade;
         obj20.gxTpr_Ultimodadolidolatitude_Z = Z123UltimoDadoLidoLatitude;
         obj20.gxTpr_Ultimodadolidolongitude_Z = Z124UltimoDadoLidoLongitude;
         obj20.gxTpr_Ultimodadolidogeolocalizacao_Z = Z127UltimoDadoLidoGeolocalizacao;
         obj20.gxTpr_Ultimodadolidogamguidproprietario_N = (short)(Convert.ToInt16(n153UltimoDadoLidoGAMGUIDProprietario));
         obj20.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow20( SdtUltimoDadoLido obj20 )
      {
         obj20.gxTpr_Ultimodadolidoid = A118UltimoDadoLidoId;
         return  ;
      }

      public void RowToVars20( SdtUltimoDadoLido obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A127UltimoDadoLidoGeolocalizacao = obj20.gxTpr_Ultimodadolidogeolocalizacao;
         A153UltimoDadoLidoGAMGUIDProprietario = obj20.gxTpr_Ultimodadolidogamguidproprietario;
         n153UltimoDadoLidoGAMGUIDProprietario = false;
         A119UltimoDadoLidoDataHoraServidor = obj20.gxTpr_Ultimodadolidodatahoraservidor;
         A120UltimoDadoLidoDataHoraRastreador = obj20.gxTpr_Ultimodadolidodatahorarastreador;
         A121UltimoDadoLidoPlaca = obj20.gxTpr_Ultimodadolidoplaca;
         A126UltimoDadoLidoIdent = obj20.gxTpr_Ultimodadolidoident;
         A122UltimoDadoLidoIgnicao = obj20.gxTpr_Ultimodadolidoignicao;
         A125UltimoDadoLidoVelocidade = obj20.gxTpr_Ultimodadolidovelocidade;
         A123UltimoDadoLidoLatitude = obj20.gxTpr_Ultimodadolidolatitude;
         A124UltimoDadoLidoLongitude = obj20.gxTpr_Ultimodadolidolongitude;
         A118UltimoDadoLidoId = obj20.gxTpr_Ultimodadolidoid;
         Z118UltimoDadoLidoId = obj20.gxTpr_Ultimodadolidoid_Z;
         Z153UltimoDadoLidoGAMGUIDProprietario = obj20.gxTpr_Ultimodadolidogamguidproprietario_Z;
         Z119UltimoDadoLidoDataHoraServidor = obj20.gxTpr_Ultimodadolidodatahoraservidor_Z;
         Z120UltimoDadoLidoDataHoraRastreador = obj20.gxTpr_Ultimodadolidodatahorarastreador_Z;
         Z121UltimoDadoLidoPlaca = obj20.gxTpr_Ultimodadolidoplaca_Z;
         Z126UltimoDadoLidoIdent = obj20.gxTpr_Ultimodadolidoident_Z;
         Z122UltimoDadoLidoIgnicao = obj20.gxTpr_Ultimodadolidoignicao_Z;
         Z125UltimoDadoLidoVelocidade = obj20.gxTpr_Ultimodadolidovelocidade_Z;
         Z123UltimoDadoLidoLatitude = obj20.gxTpr_Ultimodadolidolatitude_Z;
         Z124UltimoDadoLidoLongitude = obj20.gxTpr_Ultimodadolidolongitude_Z;
         Z127UltimoDadoLidoGeolocalizacao = obj20.gxTpr_Ultimodadolidogeolocalizacao_Z;
         n153UltimoDadoLidoGAMGUIDProprietario = (bool)(Convert.ToBoolean(obj20.gxTpr_Ultimodadolidogamguidproprietario_N));
         Gx_mode = obj20.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A118UltimoDadoLidoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0J20( ) ;
         ScanKeyStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z118UltimoDadoLidoId = A118UltimoDadoLidoId;
         }
         ZM0J20( -5) ;
         OnLoadActions0J20( ) ;
         AddRow0J20( ) ;
         ScanKeyEnd0J20( ) ;
         if ( RcdFound20 == 0 )
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
         RowToVars20( bcUltimoDadoLido, 0) ;
         ScanKeyStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z118UltimoDadoLidoId = A118UltimoDadoLidoId;
         }
         ZM0J20( -5) ;
         OnLoadActions0J20( ) ;
         AddRow0J20( ) ;
         ScanKeyEnd0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0J20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0J20( ) ;
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId )
               {
                  A118UltimoDadoLidoId = Z118UltimoDadoLidoId;
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
                  Update0J20( ) ;
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
                  if ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId )
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
                        Insert0J20( ) ;
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
                        Insert0J20( ) ;
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
         RowToVars20( bcUltimoDadoLido, 1) ;
         SaveImpl( ) ;
         VarsToRow20( bcUltimoDadoLido) ;
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
         RowToVars20( bcUltimoDadoLido, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J20( ) ;
         AfterTrn( ) ;
         VarsToRow20( bcUltimoDadoLido) ;
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
            SdtUltimoDadoLido auxBC = new SdtUltimoDadoLido(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A118UltimoDadoLidoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUltimoDadoLido);
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
         RowToVars20( bcUltimoDadoLido, 1) ;
         UpdateImpl( ) ;
         VarsToRow20( bcUltimoDadoLido) ;
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
         RowToVars20( bcUltimoDadoLido, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J20( ) ;
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
         VarsToRow20( bcUltimoDadoLido) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars20( bcUltimoDadoLido, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0J20( ) ;
         if ( RcdFound20 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId )
            {
               A118UltimoDadoLidoId = Z118UltimoDadoLidoId;
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
            if ( A118UltimoDadoLidoId != Z118UltimoDadoLidoId )
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
         context.RollbackDataStores("ultimodadolido_bc",pr_default);
         VarsToRow20( bcUltimoDadoLido) ;
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
         Gx_mode = bcUltimoDadoLido.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcUltimoDadoLido.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUltimoDadoLido )
         {
            bcUltimoDadoLido = (SdtUltimoDadoLido)(sdt);
            if ( StringUtil.StrCmp(bcUltimoDadoLido.gxTpr_Mode, "") == 0 )
            {
               bcUltimoDadoLido.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow20( bcUltimoDadoLido) ;
            }
            else
            {
               RowToVars20( bcUltimoDadoLido, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUltimoDadoLido.gxTpr_Mode, "") == 0 )
            {
               bcUltimoDadoLido.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars20( bcUltimoDadoLido, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtUltimoDadoLido UltimoDadoLido_BC
      {
         get {
            return bcUltimoDadoLido ;
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
            return "ultimodadolido_Execute" ;
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
         Z119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         A119UltimoDadoLidoDataHoraServidor = (DateTime)(DateTime.MinValue);
         Z120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         A120UltimoDadoLidoDataHoraRastreador = (DateTime)(DateTime.MinValue);
         Z121UltimoDadoLidoPlaca = "";
         A121UltimoDadoLidoPlaca = "";
         Z123UltimoDadoLidoLatitude = "";
         A123UltimoDadoLidoLatitude = "";
         Z124UltimoDadoLidoLongitude = "";
         A124UltimoDadoLidoLongitude = "";
         Z153UltimoDadoLidoGAMGUIDProprietario = "";
         A153UltimoDadoLidoGAMGUIDProprietario = "";
         Z127UltimoDadoLidoGeolocalizacao = "";
         A127UltimoDadoLidoGeolocalizacao = "";
         BC000J5_A98VeiculoId = new int[1] ;
         BC000J5_A118UltimoDadoLidoId = new int[1] ;
         BC000J5_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         BC000J5_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         BC000J5_A121UltimoDadoLidoPlaca = new string[] {""} ;
         BC000J5_A126UltimoDadoLidoIdent = new long[1] ;
         BC000J5_A122UltimoDadoLidoIgnicao = new short[1] ;
         BC000J5_A125UltimoDadoLidoVelocidade = new short[1] ;
         BC000J5_A123UltimoDadoLidoLatitude = new string[] {""} ;
         BC000J5_A124UltimoDadoLidoLongitude = new string[] {""} ;
         BC000J5_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         BC000J5_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         BC000J6_A126UltimoDadoLidoIdent = new long[1] ;
         BC000J4_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         BC000J4_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         BC000J7_A118UltimoDadoLidoId = new int[1] ;
         BC000J3_A118UltimoDadoLidoId = new int[1] ;
         BC000J3_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         BC000J3_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         BC000J3_A121UltimoDadoLidoPlaca = new string[] {""} ;
         BC000J3_A126UltimoDadoLidoIdent = new long[1] ;
         BC000J3_A122UltimoDadoLidoIgnicao = new short[1] ;
         BC000J3_A125UltimoDadoLidoVelocidade = new short[1] ;
         BC000J3_A123UltimoDadoLidoLatitude = new string[] {""} ;
         BC000J3_A124UltimoDadoLidoLongitude = new string[] {""} ;
         sMode20 = "";
         BC000J2_A118UltimoDadoLidoId = new int[1] ;
         BC000J2_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         BC000J2_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         BC000J2_A121UltimoDadoLidoPlaca = new string[] {""} ;
         BC000J2_A126UltimoDadoLidoIdent = new long[1] ;
         BC000J2_A122UltimoDadoLidoIgnicao = new short[1] ;
         BC000J2_A125UltimoDadoLidoVelocidade = new short[1] ;
         BC000J2_A123UltimoDadoLidoLatitude = new string[] {""} ;
         BC000J2_A124UltimoDadoLidoLongitude = new string[] {""} ;
         BC000J8_A118UltimoDadoLidoId = new int[1] ;
         BC000J11_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         BC000J11_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         BC000J12_A98VeiculoId = new int[1] ;
         BC000J12_A118UltimoDadoLidoId = new int[1] ;
         BC000J12_A119UltimoDadoLidoDataHoraServidor = new DateTime[] {DateTime.MinValue} ;
         BC000J12_A120UltimoDadoLidoDataHoraRastreador = new DateTime[] {DateTime.MinValue} ;
         BC000J12_A121UltimoDadoLidoPlaca = new string[] {""} ;
         BC000J12_A126UltimoDadoLidoIdent = new long[1] ;
         BC000J12_A122UltimoDadoLidoIgnicao = new short[1] ;
         BC000J12_A125UltimoDadoLidoVelocidade = new short[1] ;
         BC000J12_A123UltimoDadoLidoLatitude = new string[] {""} ;
         BC000J12_A124UltimoDadoLidoLongitude = new string[] {""} ;
         BC000J12_A153UltimoDadoLidoGAMGUIDProprietario = new string[] {""} ;
         BC000J12_n153UltimoDadoLidoGAMGUIDProprietario = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ultimodadolido_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ultimodadolido_bc__default(),
            new Object[][] {
                new Object[] {
               BC000J2_A118UltimoDadoLidoId, BC000J2_A119UltimoDadoLidoDataHoraServidor, BC000J2_A120UltimoDadoLidoDataHoraRastreador, BC000J2_A121UltimoDadoLidoPlaca, BC000J2_A126UltimoDadoLidoIdent, BC000J2_A122UltimoDadoLidoIgnicao, BC000J2_A125UltimoDadoLidoVelocidade, BC000J2_A123UltimoDadoLidoLatitude, BC000J2_A124UltimoDadoLidoLongitude
               }
               , new Object[] {
               BC000J3_A118UltimoDadoLidoId, BC000J3_A119UltimoDadoLidoDataHoraServidor, BC000J3_A120UltimoDadoLidoDataHoraRastreador, BC000J3_A121UltimoDadoLidoPlaca, BC000J3_A126UltimoDadoLidoIdent, BC000J3_A122UltimoDadoLidoIgnicao, BC000J3_A125UltimoDadoLidoVelocidade, BC000J3_A123UltimoDadoLidoLatitude, BC000J3_A124UltimoDadoLidoLongitude
               }
               , new Object[] {
               BC000J4_A153UltimoDadoLidoGAMGUIDProprietario, BC000J4_n153UltimoDadoLidoGAMGUIDProprietario
               }
               , new Object[] {
               BC000J5_A98VeiculoId, BC000J5_A118UltimoDadoLidoId, BC000J5_A119UltimoDadoLidoDataHoraServidor, BC000J5_A120UltimoDadoLidoDataHoraRastreador, BC000J5_A121UltimoDadoLidoPlaca, BC000J5_A126UltimoDadoLidoIdent, BC000J5_A122UltimoDadoLidoIgnicao, BC000J5_A125UltimoDadoLidoVelocidade, BC000J5_A123UltimoDadoLidoLatitude, BC000J5_A124UltimoDadoLidoLongitude,
               BC000J5_A153UltimoDadoLidoGAMGUIDProprietario, BC000J5_n153UltimoDadoLidoGAMGUIDProprietario
               }
               , new Object[] {
               BC000J6_A126UltimoDadoLidoIdent
               }
               , new Object[] {
               BC000J7_A118UltimoDadoLidoId
               }
               , new Object[] {
               BC000J8_A118UltimoDadoLidoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J11_A153UltimoDadoLidoGAMGUIDProprietario, BC000J11_n153UltimoDadoLidoGAMGUIDProprietario
               }
               , new Object[] {
               BC000J12_A98VeiculoId, BC000J12_A118UltimoDadoLidoId, BC000J12_A119UltimoDadoLidoDataHoraServidor, BC000J12_A120UltimoDadoLidoDataHoraRastreador, BC000J12_A121UltimoDadoLidoPlaca, BC000J12_A126UltimoDadoLidoIdent, BC000J12_A122UltimoDadoLidoIgnicao, BC000J12_A125UltimoDadoLidoVelocidade, BC000J12_A123UltimoDadoLidoLatitude, BC000J12_A124UltimoDadoLidoLongitude,
               BC000J12_A153UltimoDadoLidoGAMGUIDProprietario, BC000J12_n153UltimoDadoLidoGAMGUIDProprietario
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120J2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z122UltimoDadoLidoIgnicao ;
      private short A122UltimoDadoLidoIgnicao ;
      private short Z125UltimoDadoLidoVelocidade ;
      private short A125UltimoDadoLidoVelocidade ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private int trnEnded ;
      private int Z118UltimoDadoLidoId ;
      private int A118UltimoDadoLidoId ;
      private long Z126UltimoDadoLidoIdent ;
      private long A126UltimoDadoLidoIdent ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z153UltimoDadoLidoGAMGUIDProprietario ;
      private string A153UltimoDadoLidoGAMGUIDProprietario ;
      private string sMode20 ;
      private DateTime Z119UltimoDadoLidoDataHoraServidor ;
      private DateTime A119UltimoDadoLidoDataHoraServidor ;
      private DateTime Z120UltimoDadoLidoDataHoraRastreador ;
      private DateTime A120UltimoDadoLidoDataHoraRastreador ;
      private bool returnInSub ;
      private bool n153UltimoDadoLidoGAMGUIDProprietario ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z121UltimoDadoLidoPlaca ;
      private string A121UltimoDadoLidoPlaca ;
      private string Z123UltimoDadoLidoLatitude ;
      private string A123UltimoDadoLidoLatitude ;
      private string Z124UltimoDadoLidoLongitude ;
      private string A124UltimoDadoLidoLongitude ;
      private string Z127UltimoDadoLidoGeolocalizacao ;
      private string A127UltimoDadoLidoGeolocalizacao ;
      private IGxSession AV12WebSession ;
      private SdtUltimoDadoLido bcUltimoDadoLido ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000J5_A98VeiculoId ;
      private int[] BC000J5_A118UltimoDadoLidoId ;
      private DateTime[] BC000J5_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] BC000J5_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] BC000J5_A121UltimoDadoLidoPlaca ;
      private long[] BC000J5_A126UltimoDadoLidoIdent ;
      private short[] BC000J5_A122UltimoDadoLidoIgnicao ;
      private short[] BC000J5_A125UltimoDadoLidoVelocidade ;
      private string[] BC000J5_A123UltimoDadoLidoLatitude ;
      private string[] BC000J5_A124UltimoDadoLidoLongitude ;
      private string[] BC000J5_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] BC000J5_n153UltimoDadoLidoGAMGUIDProprietario ;
      private long[] BC000J6_A126UltimoDadoLidoIdent ;
      private string[] BC000J4_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] BC000J4_n153UltimoDadoLidoGAMGUIDProprietario ;
      private int[] BC000J7_A118UltimoDadoLidoId ;
      private int[] BC000J3_A118UltimoDadoLidoId ;
      private DateTime[] BC000J3_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] BC000J3_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] BC000J3_A121UltimoDadoLidoPlaca ;
      private long[] BC000J3_A126UltimoDadoLidoIdent ;
      private short[] BC000J3_A122UltimoDadoLidoIgnicao ;
      private short[] BC000J3_A125UltimoDadoLidoVelocidade ;
      private string[] BC000J3_A123UltimoDadoLidoLatitude ;
      private string[] BC000J3_A124UltimoDadoLidoLongitude ;
      private int[] BC000J2_A118UltimoDadoLidoId ;
      private DateTime[] BC000J2_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] BC000J2_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] BC000J2_A121UltimoDadoLidoPlaca ;
      private long[] BC000J2_A126UltimoDadoLidoIdent ;
      private short[] BC000J2_A122UltimoDadoLidoIgnicao ;
      private short[] BC000J2_A125UltimoDadoLidoVelocidade ;
      private string[] BC000J2_A123UltimoDadoLidoLatitude ;
      private string[] BC000J2_A124UltimoDadoLidoLongitude ;
      private int[] BC000J8_A118UltimoDadoLidoId ;
      private string[] BC000J11_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] BC000J11_n153UltimoDadoLidoGAMGUIDProprietario ;
      private int[] BC000J12_A98VeiculoId ;
      private int[] BC000J12_A118UltimoDadoLidoId ;
      private DateTime[] BC000J12_A119UltimoDadoLidoDataHoraServidor ;
      private DateTime[] BC000J12_A120UltimoDadoLidoDataHoraRastreador ;
      private string[] BC000J12_A121UltimoDadoLidoPlaca ;
      private long[] BC000J12_A126UltimoDadoLidoIdent ;
      private short[] BC000J12_A122UltimoDadoLidoIgnicao ;
      private short[] BC000J12_A125UltimoDadoLidoVelocidade ;
      private string[] BC000J12_A123UltimoDadoLidoLatitude ;
      private string[] BC000J12_A124UltimoDadoLidoLongitude ;
      private string[] BC000J12_A153UltimoDadoLidoGAMGUIDProprietario ;
      private bool[] BC000J12_n153UltimoDadoLidoGAMGUIDProprietario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class ultimodadolido_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class ultimodadolido_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000J5;
        prmBC000J5 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000J6;
        prmBC000J6 = new Object[] {
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0} ,
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000J4;
        prmBC000J4 = new Object[] {
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0}
        };
        Object[] prmBC000J7;
        prmBC000J7 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000J3;
        prmBC000J3 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000J2;
        prmBC000J2 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000J8;
        prmBC000J8 = new Object[] {
        new Object[] {"@UltimoDadoLidoDataHoraServidor",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoDataHoraRastreador",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0} ,
        new Object[] {"@UltimoDadoLidoIgnicao",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@UltimoDadoLidoVelocidade",SqlDbType.SmallInt,3,0} ,
        new Object[] {"@UltimoDadoLidoLatitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoLongitude",SqlDbType.NVarChar,50,0}
        };
        Object[] prmBC000J9;
        prmBC000J9 = new Object[] {
        new Object[] {"@UltimoDadoLidoDataHoraServidor",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoDataHoraRastreador",SqlDbType.DateTime,8,5} ,
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0} ,
        new Object[] {"@UltimoDadoLidoIdent",SqlDbType.Decimal,16,0} ,
        new Object[] {"@UltimoDadoLidoIgnicao",SqlDbType.SmallInt,1,0} ,
        new Object[] {"@UltimoDadoLidoVelocidade",SqlDbType.SmallInt,3,0} ,
        new Object[] {"@UltimoDadoLidoLatitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoLongitude",SqlDbType.NVarChar,50,0} ,
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000J10;
        prmBC000J10 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000J11;
        prmBC000J11 = new Object[] {
        new Object[] {"@UltimoDadoLidoPlaca",SqlDbType.NVarChar,7,0}
        };
        Object[] prmBC000J12;
        prmBC000J12 = new Object[] {
        new Object[] {"@UltimoDadoLidoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000J2", "SELECT [UltimoDadoLidoId], [UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoPlaca], [UltimoDadoLidoIdent], [UltimoDadoLidoIgnicao], [UltimoDadoLidoVelocidade], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude] FROM [UltimoDadoLido] WITH (UPDLOCK) WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J3", "SELECT [UltimoDadoLidoId], [UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoPlaca], [UltimoDadoLidoIdent], [UltimoDadoLidoIgnicao], [UltimoDadoLidoVelocidade], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude] FROM [UltimoDadoLido] WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J4", "SELECT COALESCE( [VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM [Veiculo] WHERE [VeiculoPlaca] = @UltimoDadoLidoPlaca ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J5", "SELECT T2.[VeiculoId], TM1.[UltimoDadoLidoId], TM1.[UltimoDadoLidoDataHoraServidor], TM1.[UltimoDadoLidoDataHoraRastreador], TM1.[UltimoDadoLidoPlaca], TM1.[UltimoDadoLidoIdent], TM1.[UltimoDadoLidoIgnicao], TM1.[UltimoDadoLidoVelocidade], TM1.[UltimoDadoLidoLatitude], TM1.[UltimoDadoLidoLongitude], COALESCE( T2.[VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM ([UltimoDadoLido] TM1 LEFT JOIN [Veiculo] T2 ON T2.[VeiculoPlaca] = TM1.[UltimoDadoLidoPlaca]) WHERE TM1.[UltimoDadoLidoId] = @UltimoDadoLidoId ORDER BY TM1.[UltimoDadoLidoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J6", "SELECT [UltimoDadoLidoIdent] FROM [UltimoDadoLido] WHERE ([UltimoDadoLidoIdent] = @UltimoDadoLidoIdent) AND (Not ( [UltimoDadoLidoId] = @UltimoDadoLidoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J7", "SELECT [UltimoDadoLidoId] FROM [UltimoDadoLido] WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J8", "INSERT INTO [UltimoDadoLido]([UltimoDadoLidoDataHoraServidor], [UltimoDadoLidoDataHoraRastreador], [UltimoDadoLidoPlaca], [UltimoDadoLidoIdent], [UltimoDadoLidoIgnicao], [UltimoDadoLidoVelocidade], [UltimoDadoLidoLatitude], [UltimoDadoLidoLongitude]) VALUES(@UltimoDadoLidoDataHoraServidor, @UltimoDadoLidoDataHoraRastreador, @UltimoDadoLidoPlaca, @UltimoDadoLidoIdent, @UltimoDadoLidoIgnicao, @UltimoDadoLidoVelocidade, @UltimoDadoLidoLatitude, @UltimoDadoLidoLongitude); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000J8)
           ,new CursorDef("BC000J9", "UPDATE [UltimoDadoLido] SET [UltimoDadoLidoDataHoraServidor]=@UltimoDadoLidoDataHoraServidor, [UltimoDadoLidoDataHoraRastreador]=@UltimoDadoLidoDataHoraRastreador, [UltimoDadoLidoPlaca]=@UltimoDadoLidoPlaca, [UltimoDadoLidoIdent]=@UltimoDadoLidoIdent, [UltimoDadoLidoIgnicao]=@UltimoDadoLidoIgnicao, [UltimoDadoLidoVelocidade]=@UltimoDadoLidoVelocidade, [UltimoDadoLidoLatitude]=@UltimoDadoLidoLatitude, [UltimoDadoLidoLongitude]=@UltimoDadoLidoLongitude  WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId", GxErrorMask.GX_NOMASK,prmBC000J9)
           ,new CursorDef("BC000J10", "DELETE FROM [UltimoDadoLido]  WHERE [UltimoDadoLidoId] = @UltimoDadoLidoId", GxErrorMask.GX_NOMASK,prmBC000J10)
           ,new CursorDef("BC000J11", "SELECT COALESCE( [VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM [Veiculo] WHERE [VeiculoPlaca] = @UltimoDadoLidoPlaca ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J12", "SELECT T2.[VeiculoId], TM1.[UltimoDadoLidoId], TM1.[UltimoDadoLidoDataHoraServidor], TM1.[UltimoDadoLidoDataHoraRastreador], TM1.[UltimoDadoLidoPlaca], TM1.[UltimoDadoLidoIdent], TM1.[UltimoDadoLidoIgnicao], TM1.[UltimoDadoLidoVelocidade], TM1.[UltimoDadoLidoLatitude], TM1.[UltimoDadoLidoLongitude], COALESCE( T2.[VeiculoGAMGUID], '') AS UltimoDadoLidoGAMGUIDProprietario FROM ([UltimoDadoLido] TM1 LEFT JOIN [Veiculo] T2 ON T2.[VeiculoPlaca] = TM1.[UltimoDadoLidoPlaca]) WHERE TM1.[UltimoDadoLidoId] = @UltimoDadoLidoId ORDER BY TM1.[UltimoDadoLidoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J12,100, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLong(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getShort(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getGXDateTime(2);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getLong(5);
              table[5][0] = rslt.getShort(6);
              table[6][0] = rslt.getShort(7);
              table[7][0] = rslt.getVarchar(8);
              table[8][0] = rslt.getVarchar(9);
              return;
           case 2 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.wasNull(1);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getGXDateTime(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLong(6);
              table[6][0] = rslt.getShort(7);
              table[7][0] = rslt.getShort(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getString(11, 40);
              table[11][0] = rslt.wasNull(11);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              return;
           case 6 :
              table[0][0] = rslt.getInt(1);
              return;
           case 9 :
              table[0][0] = rslt.getString(1, 40);
              table[1][0] = rslt.wasNull(1);
              return;
           case 10 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getGXDateTime(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getLong(6);
              table[6][0] = rslt.getShort(7);
              table[7][0] = rslt.getShort(8);
              table[8][0] = rslt.getVarchar(9);
              table[9][0] = rslt.getVarchar(10);
              table[10][0] = rslt.getString(11, 40);
              table[11][0] = rslt.wasNull(11);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (long)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 5 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 6 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (long)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameter(6, (short)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              return;
           case 7 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (long)parms[3]);
              stmt.SetParameter(5, (short)parms[4]);
              stmt.SetParameter(6, (short)parms[5]);
              stmt.SetParameter(7, (string)parms[6]);
              stmt.SetParameter(8, (string)parms[7]);
              stmt.SetParameter(9, (int)parms[8]);
              return;
           case 8 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 9 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 10 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
