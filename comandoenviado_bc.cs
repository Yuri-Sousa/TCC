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
   public class comandoenviado_bc : GXHttpHandler, IGxSilentTrn
   {
      public comandoenviado_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public comandoenviado_bc( IGxContext context )
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
         ReadRow0N24( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0N24( ) ;
         standaloneModal( ) ;
         AddRow0N24( ) ;
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
            E110N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z144ComandoEnviadoId = A144ComandoEnviadoId;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N24( ) ;
            }
            else
            {
               CheckExtendedTable0N24( ) ;
               if ( AnyError == 0 )
               {
                  ZM0N24( 7) ;
               }
               CloseExtendedTableCursors0N24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode24 = Gx_mode;
            CONFIRM_0N25( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode24;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode24;
         }
      }

      protected void CONFIRM_0N25( )
      {
         nGXsfl_25_idx = 0;
         while ( nGXsfl_25_idx < bcComandoEnviado.gxTpr_Comando.Count )
         {
            ReadRow0N25( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound25 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_25 != 0 ) )
            {
               GetKey0N25( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound25 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0N25( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0N25( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0N25( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound25 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0N25( ) ;
                        Load0N25( ) ;
                        BeforeValidate0N25( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0N25( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_25 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0N25( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0N25( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0N25( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow25( ((SdtComandoEnviado_Comando)bcComandoEnviado.gxTpr_Comando.Item(nGXsfl_25_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120N2( )
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "RastreadorId") == 0 )
               {
                  AV13Insert_RastreadorId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E110N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0N24( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z145ComandoEnviadoResponsavelGUID = A145ComandoEnviadoResponsavelGUID;
            Z146ComandoEnviadoDataHora = A146ComandoEnviadoDataHora;
            Z147ComandoEnviadoSerial = A147ComandoEnviadoSerial;
            Z106RastreadorId = A106RastreadorId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z110RastreadorSNumber = A110RastreadorSNumber;
         }
         if ( GX_JID == -6 )
         {
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            Z145ComandoEnviadoResponsavelGUID = A145ComandoEnviadoResponsavelGUID;
            Z146ComandoEnviadoDataHora = A146ComandoEnviadoDataHora;
            Z147ComandoEnviadoSerial = A147ComandoEnviadoSerial;
            Z106RastreadorId = A106RastreadorId;
            Z110RastreadorSNumber = A110RastreadorSNumber;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "ComandoEnviado_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A146ComandoEnviadoDataHora) && ( Gx_BScreen == 0 ) )
         {
            A146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A145ComandoEnviadoResponsavelGUID)) && ( Gx_BScreen == 0 ) )
         {
            GXt_char1 = A145ComandoEnviadoResponsavelGUID;
            new buscargamguidusuariologado(context ).execute( out  GXt_char1) ;
            A145ComandoEnviadoResponsavelGUID = GXt_char1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0N24( )
      {
         /* Using cursor BC000N7 */
         pr_default.execute(5, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound24 = 1;
            A145ComandoEnviadoResponsavelGUID = BC000N7_A145ComandoEnviadoResponsavelGUID[0];
            A146ComandoEnviadoDataHora = BC000N7_A146ComandoEnviadoDataHora[0];
            A110RastreadorSNumber = BC000N7_A110RastreadorSNumber[0];
            A147ComandoEnviadoSerial = BC000N7_A147ComandoEnviadoSerial[0];
            A106RastreadorId = BC000N7_A106RastreadorId[0];
            ZM0N24( -6) ;
         }
         pr_default.close(5);
         OnLoadActions0N24( ) ;
      }

      protected void OnLoadActions0N24( )
      {
      }

      protected void CheckExtendedTable0N24( )
      {
         nIsDirty_24 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A146ComandoEnviadoDataHora) || ( A146ComandoEnviadoDataHora >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Data/Hora do Envio fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000N6 */
         pr_default.execute(4, new Object[] {A106RastreadorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Rastreador'.", "ForeignKeyNotFound", 1, "RASTREADORID");
            AnyError = 1;
         }
         A110RastreadorSNumber = BC000N6_A110RastreadorSNumber[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0N24( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N24( )
      {
         /* Using cursor BC000N8 */
         pr_default.execute(6, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000N5 */
         pr_default.execute(3, new Object[] {A144ComandoEnviadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0N24( 6) ;
            RcdFound24 = 1;
            A144ComandoEnviadoId = BC000N5_A144ComandoEnviadoId[0];
            A145ComandoEnviadoResponsavelGUID = BC000N5_A145ComandoEnviadoResponsavelGUID[0];
            A146ComandoEnviadoDataHora = BC000N5_A146ComandoEnviadoDataHora[0];
            A147ComandoEnviadoSerial = BC000N5_A147ComandoEnviadoSerial[0];
            A106RastreadorId = BC000N5_A106RastreadorId[0];
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0N24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0N24( ) ;
            }
            Gx_mode = sMode24;
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0N24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode24;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N24( ) ;
         if ( RcdFound24 == 0 )
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
         CONFIRM_0N0( ) ;
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

      protected void CheckOptimisticConcurrency0N24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N4 */
            pr_default.execute(2, new Object[] {A144ComandoEnviadoId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z145ComandoEnviadoResponsavelGUID, BC000N4_A145ComandoEnviadoResponsavelGUID[0]) != 0 ) || ( Z146ComandoEnviadoDataHora != BC000N4_A146ComandoEnviadoDataHora[0] ) || ( Z147ComandoEnviadoSerial != BC000N4_A147ComandoEnviadoSerial[0] ) || ( Z106RastreadorId != BC000N4_A106RastreadorId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComandoEnviado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N24( )
      {
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N24( 0) ;
            CheckOptimisticConcurrency0N24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N9 */
                     pr_default.execute(7, new Object[] {A145ComandoEnviadoResponsavelGUID, A146ComandoEnviadoDataHora, A147ComandoEnviadoSerial, A106RastreadorId});
                     A144ComandoEnviadoId = BC000N9_A144ComandoEnviadoId[0];
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N24( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0N24( ) ;
            }
            EndLevel0N24( ) ;
         }
         CloseExtendedTableCursors0N24( ) ;
      }

      protected void Update0N24( )
      {
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N10 */
                     pr_default.execute(8, new Object[] {A145ComandoEnviadoResponsavelGUID, A146ComandoEnviadoDataHora, A147ComandoEnviadoSerial, A106RastreadorId, A144ComandoEnviadoId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviado");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N24( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N24( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0N24( ) ;
         }
         CloseExtendedTableCursors0N24( ) ;
      }

      protected void DeferredUpdate0N24( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N24( ) ;
            AfterConfirm0N24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N24( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0N25( ) ;
                  while ( RcdFound25 != 0 )
                  {
                     getByPrimaryKey0N25( ) ;
                     Delete0N25( ) ;
                     ScanKeyNext0N25( ) ;
                  }
                  ScanKeyEnd0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N11 */
                     pr_default.execute(9, new Object[] {A144ComandoEnviadoId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviado");
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
         }
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N24( ) ;
         Gx_mode = sMode24;
      }

      protected void OnDeleteControls0N24( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000N12 */
            pr_default.execute(10, new Object[] {A106RastreadorId});
            A110RastreadorSNumber = BC000N12_A110RastreadorSNumber[0];
            pr_default.close(10);
         }
      }

      protected void ProcessNestedLevel0N25( )
      {
         nGXsfl_25_idx = 0;
         while ( nGXsfl_25_idx < bcComandoEnviado.gxTpr_Comando.Count )
         {
            ReadRow0N25( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound25 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_25 != 0 ) )
            {
               standaloneNotModal0N25( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0N25( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0N25( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0N25( ) ;
                  }
               }
            }
            KeyVarsToRow25( ((SdtComandoEnviado_Comando)bcComandoEnviado.gxTpr_Comando.Item(nGXsfl_25_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_25_idx = 0;
            while ( nGXsfl_25_idx < bcComandoEnviado.gxTpr_Comando.Count )
            {
               ReadRow0N25( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound25 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcComandoEnviado.gxTpr_Comando.RemoveElement(nGXsfl_25_idx);
                  nGXsfl_25_idx = (int)(nGXsfl_25_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0N25( ) ;
                  VarsToRow25( ((SdtComandoEnviado_Comando)bcComandoEnviado.gxTpr_Comando.Item(nGXsfl_25_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0N25( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_25 = 0;
         nIsMod_25 = 0;
         Gxremove25 = 0;
      }

      protected void ProcessLevel0N24( )
      {
         /* Save parent mode. */
         sMode24 = Gx_mode;
         ProcessNestedLevel0N25( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode24;
         /* ' Update level parameters */
      }

      protected void EndLevel0N24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N24( ) ;
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

      public void ScanKeyStart0N24( )
      {
         /* Scan By routine */
         /* Using cursor BC000N13 */
         pr_default.execute(11, new Object[] {A144ComandoEnviadoId});
         RcdFound24 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound24 = 1;
            A144ComandoEnviadoId = BC000N13_A144ComandoEnviadoId[0];
            A145ComandoEnviadoResponsavelGUID = BC000N13_A145ComandoEnviadoResponsavelGUID[0];
            A146ComandoEnviadoDataHora = BC000N13_A146ComandoEnviadoDataHora[0];
            A110RastreadorSNumber = BC000N13_A110RastreadorSNumber[0];
            A147ComandoEnviadoSerial = BC000N13_A147ComandoEnviadoSerial[0];
            A106RastreadorId = BC000N13_A106RastreadorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N24( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound24 = 0;
         ScanKeyLoad0N24( ) ;
      }

      protected void ScanKeyLoad0N24( )
      {
         sMode24 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound24 = 1;
            A144ComandoEnviadoId = BC000N13_A144ComandoEnviadoId[0];
            A145ComandoEnviadoResponsavelGUID = BC000N13_A145ComandoEnviadoResponsavelGUID[0];
            A146ComandoEnviadoDataHora = BC000N13_A146ComandoEnviadoDataHora[0];
            A110RastreadorSNumber = BC000N13_A110RastreadorSNumber[0];
            A147ComandoEnviadoSerial = BC000N13_A147ComandoEnviadoSerial[0];
            A106RastreadorId = BC000N13_A106RastreadorId[0];
         }
         Gx_mode = sMode24;
      }

      protected void ScanKeyEnd0N24( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0N24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N24( )
      {
      }

      protected void ZM0N25( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z149ComandoEnviadoComandoComando = A149ComandoEnviadoComandoComando;
            Z150ComandoEnviadoComandoValor = A150ComandoEnviadoComandoValor;
         }
         if ( GX_JID == -8 )
         {
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            Z148ComandoEnviadoComandoId = A148ComandoEnviadoComandoId;
            Z149ComandoEnviadoComandoComando = A149ComandoEnviadoComandoComando;
            Z150ComandoEnviadoComandoValor = A150ComandoEnviadoComandoValor;
         }
      }

      protected void standaloneNotModal0N25( )
      {
      }

      protected void standaloneModal0N25( )
      {
      }

      protected void Load0N25( )
      {
         /* Using cursor BC000N14 */
         pr_default.execute(12, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound25 = 1;
            A149ComandoEnviadoComandoComando = BC000N14_A149ComandoEnviadoComandoComando[0];
            A150ComandoEnviadoComandoValor = BC000N14_A150ComandoEnviadoComandoValor[0];
            ZM0N25( -8) ;
         }
         pr_default.close(12);
         OnLoadActions0N25( ) ;
      }

      protected void OnLoadActions0N25( )
      {
      }

      protected void CheckExtendedTable0N25( )
      {
         nIsDirty_25 = 0;
         Gx_BScreen = 1;
         standaloneModal0N25( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0N25( )
      {
      }

      protected void enableDisable0N25( )
      {
      }

      protected void GetKey0N25( )
      {
         /* Using cursor BC000N15 */
         pr_default.execute(13, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey0N25( )
      {
         /* Using cursor BC000N3 */
         pr_default.execute(1, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N25( 8) ;
            RcdFound25 = 1;
            InitializeNonKey0N25( ) ;
            A148ComandoEnviadoComandoId = BC000N3_A148ComandoEnviadoComandoId[0];
            A149ComandoEnviadoComandoComando = BC000N3_A149ComandoEnviadoComandoComando[0];
            A150ComandoEnviadoComandoValor = BC000N3_A150ComandoEnviadoComandoValor[0];
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
            Z148ComandoEnviadoComandoId = A148ComandoEnviadoComandoId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0N25( ) ;
            Load0N25( ) ;
            Gx_mode = sMode25;
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0N25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0N25( ) ;
            Gx_mode = sMode25;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0N25( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0N25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N2 */
            pr_default.execute(0, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviadoComando"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z149ComandoEnviadoComandoComando, BC000N2_A149ComandoEnviadoComandoComando[0]) != 0 ) || ( StringUtil.StrCmp(Z150ComandoEnviadoComandoValor, BC000N2_A150ComandoEnviadoComandoValor[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComandoEnviadoComando"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N25( )
      {
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N25( 0) ;
            CheckOptimisticConcurrency0N25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N16 */
                     pr_default.execute(14, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId, A149ComandoEnviadoComandoComando, A150ComandoEnviadoComandoValor});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviadoComando");
                     if ( (pr_default.getStatus(14) == 1) )
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
               Load0N25( ) ;
            }
            EndLevel0N25( ) ;
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void Update0N25( )
      {
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N17 */
                     pr_default.execute(15, new Object[] {A149ComandoEnviadoComandoComando, A150ComandoEnviadoComandoValor, A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviadoComando");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComandoEnviadoComando"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N25( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0N25( ) ;
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
            EndLevel0N25( ) ;
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void DeferredUpdate0N25( )
      {
      }

      protected void Delete0N25( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N25( ) ;
            AfterConfirm0N25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000N18 */
                  pr_default.execute(16, new Object[] {A144ComandoEnviadoId, A148ComandoEnviadoComandoId});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("ComandoEnviadoComando");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N25( ) ;
         Gx_mode = sMode25;
      }

      protected void OnDeleteControls0N25( )
      {
         standaloneModal0N25( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0N25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0N25( )
      {
         /* Scan By routine */
         /* Using cursor BC000N19 */
         pr_default.execute(17, new Object[] {A144ComandoEnviadoId});
         RcdFound25 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound25 = 1;
            A148ComandoEnviadoComandoId = BC000N19_A148ComandoEnviadoComandoId[0];
            A149ComandoEnviadoComandoComando = BC000N19_A149ComandoEnviadoComandoComando[0];
            A150ComandoEnviadoComandoValor = BC000N19_A150ComandoEnviadoComandoValor[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N25( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound25 = 0;
         ScanKeyLoad0N25( ) ;
      }

      protected void ScanKeyLoad0N25( )
      {
         sMode25 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound25 = 1;
            A148ComandoEnviadoComandoId = BC000N19_A148ComandoEnviadoComandoId[0];
            A149ComandoEnviadoComandoComando = BC000N19_A149ComandoEnviadoComandoComando[0];
            A150ComandoEnviadoComandoValor = BC000N19_A150ComandoEnviadoComandoValor[0];
         }
         Gx_mode = sMode25;
      }

      protected void ScanKeyEnd0N25( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0N25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N25( )
      {
      }

      protected void send_integrity_lvl_hashes0N25( )
      {
      }

      protected void send_integrity_lvl_hashes0N24( )
      {
      }

      protected void AddRow0N24( )
      {
         VarsToRow24( bcComandoEnviado) ;
      }

      protected void ReadRow0N24( )
      {
         RowToVars24( bcComandoEnviado, 1) ;
      }

      protected void AddRow0N25( )
      {
         SdtComandoEnviado_Comando obj25;
         obj25 = new SdtComandoEnviado_Comando(context);
         VarsToRow25( obj25) ;
         bcComandoEnviado.gxTpr_Comando.Add(obj25, 0);
         obj25.gxTpr_Mode = "UPD";
         obj25.gxTpr_Modified = 0;
      }

      protected void ReadRow0N25( )
      {
         nGXsfl_25_idx = (int)(nGXsfl_25_idx+1);
         RowToVars25( ((SdtComandoEnviado_Comando)bcComandoEnviado.gxTpr_Comando.Item(nGXsfl_25_idx)), 1) ;
      }

      protected void InitializeNonKey0N24( )
      {
         A106RastreadorId = 0;
         A110RastreadorSNumber = 0;
         A147ComandoEnviadoSerial = 0;
         A145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         A146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         Z145ComandoEnviadoResponsavelGUID = "";
         Z146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         Z147ComandoEnviadoSerial = 0;
         Z106RastreadorId = 0;
      }

      protected void InitAll0N24( )
      {
         A144ComandoEnviadoId = 0;
         InitializeNonKey0N24( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A146ComandoEnviadoDataHora = i146ComandoEnviadoDataHora;
         A145ComandoEnviadoResponsavelGUID = i145ComandoEnviadoResponsavelGUID;
      }

      protected void InitializeNonKey0N25( )
      {
         A149ComandoEnviadoComandoComando = "";
         A150ComandoEnviadoComandoValor = "";
         Z149ComandoEnviadoComandoComando = "";
         Z150ComandoEnviadoComandoValor = "";
      }

      protected void InitAll0N25( )
      {
         A148ComandoEnviadoComandoId = 0;
         InitializeNonKey0N25( ) ;
      }

      protected void StandaloneModalInsert0N25( )
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

      public void VarsToRow24( SdtComandoEnviado obj24 )
      {
         obj24.gxTpr_Mode = Gx_mode;
         obj24.gxTpr_Rastreadorid = A106RastreadorId;
         obj24.gxTpr_Rastreadorsnumber = A110RastreadorSNumber;
         obj24.gxTpr_Comandoenviadoserial = A147ComandoEnviadoSerial;
         obj24.gxTpr_Comandoenviadoresponsavelguid = A145ComandoEnviadoResponsavelGUID;
         obj24.gxTpr_Comandoenviadodatahora = A146ComandoEnviadoDataHora;
         obj24.gxTpr_Comandoenviadoid = A144ComandoEnviadoId;
         obj24.gxTpr_Comandoenviadoid_Z = Z144ComandoEnviadoId;
         obj24.gxTpr_Comandoenviadoresponsavelguid_Z = Z145ComandoEnviadoResponsavelGUID;
         obj24.gxTpr_Comandoenviadodatahora_Z = Z146ComandoEnviadoDataHora;
         obj24.gxTpr_Rastreadorid_Z = Z106RastreadorId;
         obj24.gxTpr_Rastreadorsnumber_Z = Z110RastreadorSNumber;
         obj24.gxTpr_Comandoenviadoserial_Z = Z147ComandoEnviadoSerial;
         obj24.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow24( SdtComandoEnviado obj24 )
      {
         obj24.gxTpr_Comandoenviadoid = A144ComandoEnviadoId;
         return  ;
      }

      public void RowToVars24( SdtComandoEnviado obj24 ,
                               int forceLoad )
      {
         Gx_mode = obj24.gxTpr_Mode;
         A106RastreadorId = obj24.gxTpr_Rastreadorid;
         A110RastreadorSNumber = obj24.gxTpr_Rastreadorsnumber;
         A147ComandoEnviadoSerial = obj24.gxTpr_Comandoenviadoserial;
         A145ComandoEnviadoResponsavelGUID = obj24.gxTpr_Comandoenviadoresponsavelguid;
         A146ComandoEnviadoDataHora = obj24.gxTpr_Comandoenviadodatahora;
         A144ComandoEnviadoId = obj24.gxTpr_Comandoenviadoid;
         Z144ComandoEnviadoId = obj24.gxTpr_Comandoenviadoid_Z;
         Z145ComandoEnviadoResponsavelGUID = obj24.gxTpr_Comandoenviadoresponsavelguid_Z;
         Z146ComandoEnviadoDataHora = obj24.gxTpr_Comandoenviadodatahora_Z;
         Z106RastreadorId = obj24.gxTpr_Rastreadorid_Z;
         Z110RastreadorSNumber = obj24.gxTpr_Rastreadorsnumber_Z;
         Z147ComandoEnviadoSerial = obj24.gxTpr_Comandoenviadoserial_Z;
         Gx_mode = obj24.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow25( SdtComandoEnviado_Comando obj25 )
      {
         obj25.gxTpr_Mode = Gx_mode;
         obj25.gxTpr_Comandoenviadocomandocomando = A149ComandoEnviadoComandoComando;
         obj25.gxTpr_Comandoenviadocomandovalor = A150ComandoEnviadoComandoValor;
         obj25.gxTpr_Comandoenviadocomandoid = A148ComandoEnviadoComandoId;
         obj25.gxTpr_Comandoenviadocomandoid_Z = Z148ComandoEnviadoComandoId;
         obj25.gxTpr_Comandoenviadocomandocomando_Z = Z149ComandoEnviadoComandoComando;
         obj25.gxTpr_Comandoenviadocomandovalor_Z = Z150ComandoEnviadoComandoValor;
         obj25.gxTpr_Modified = nIsMod_25;
         return  ;
      }

      public void KeyVarsToRow25( SdtComandoEnviado_Comando obj25 )
      {
         obj25.gxTpr_Comandoenviadocomandoid = A148ComandoEnviadoComandoId;
         return  ;
      }

      public void RowToVars25( SdtComandoEnviado_Comando obj25 ,
                               int forceLoad )
      {
         Gx_mode = obj25.gxTpr_Mode;
         A149ComandoEnviadoComandoComando = obj25.gxTpr_Comandoenviadocomandocomando;
         A150ComandoEnviadoComandoValor = obj25.gxTpr_Comandoenviadocomandovalor;
         A148ComandoEnviadoComandoId = obj25.gxTpr_Comandoenviadocomandoid;
         Z148ComandoEnviadoComandoId = obj25.gxTpr_Comandoenviadocomandoid_Z;
         Z149ComandoEnviadoComandoComando = obj25.gxTpr_Comandoenviadocomandocomando_Z;
         Z150ComandoEnviadoComandoValor = obj25.gxTpr_Comandoenviadocomandovalor_Z;
         nIsMod_25 = obj25.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A144ComandoEnviadoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0N24( ) ;
         ScanKeyStart0N24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
         }
         ZM0N24( -6) ;
         OnLoadActions0N24( ) ;
         AddRow0N24( ) ;
         bcComandoEnviado.gxTpr_Comando.ClearCollection();
         if ( RcdFound24 == 1 )
         {
            ScanKeyStart0N25( ) ;
            nGXsfl_25_idx = 1;
            while ( RcdFound25 != 0 )
            {
               Z144ComandoEnviadoId = A144ComandoEnviadoId;
               Z148ComandoEnviadoComandoId = A148ComandoEnviadoComandoId;
               ZM0N25( -8) ;
               OnLoadActions0N25( ) ;
               nRcdExists_25 = 1;
               nIsMod_25 = 0;
               AddRow0N25( ) ;
               nGXsfl_25_idx = (int)(nGXsfl_25_idx+1);
               ScanKeyNext0N25( ) ;
            }
            ScanKeyEnd0N25( ) ;
         }
         ScanKeyEnd0N24( ) ;
         if ( RcdFound24 == 0 )
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
         RowToVars24( bcComandoEnviado, 0) ;
         ScanKeyStart0N24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z144ComandoEnviadoId = A144ComandoEnviadoId;
         }
         ZM0N24( -6) ;
         OnLoadActions0N24( ) ;
         AddRow0N24( ) ;
         bcComandoEnviado.gxTpr_Comando.ClearCollection();
         if ( RcdFound24 == 1 )
         {
            ScanKeyStart0N25( ) ;
            nGXsfl_25_idx = 1;
            while ( RcdFound25 != 0 )
            {
               Z144ComandoEnviadoId = A144ComandoEnviadoId;
               Z148ComandoEnviadoComandoId = A148ComandoEnviadoComandoId;
               ZM0N25( -8) ;
               OnLoadActions0N25( ) ;
               nRcdExists_25 = 1;
               nIsMod_25 = 0;
               AddRow0N25( ) ;
               nGXsfl_25_idx = (int)(nGXsfl_25_idx+1);
               ScanKeyNext0N25( ) ;
            }
            ScanKeyEnd0N25( ) ;
         }
         ScanKeyEnd0N24( ) ;
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0N24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0N24( ) ;
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A144ComandoEnviadoId != Z144ComandoEnviadoId )
               {
                  A144ComandoEnviadoId = Z144ComandoEnviadoId;
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
                  Update0N24( ) ;
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
                  if ( A144ComandoEnviadoId != Z144ComandoEnviadoId )
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
                        Insert0N24( ) ;
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
                        Insert0N24( ) ;
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
         RowToVars24( bcComandoEnviado, 1) ;
         SaveImpl( ) ;
         VarsToRow24( bcComandoEnviado) ;
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
         RowToVars24( bcComandoEnviado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N24( ) ;
         AfterTrn( ) ;
         VarsToRow24( bcComandoEnviado) ;
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
            SdtComandoEnviado auxBC = new SdtComandoEnviado(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A144ComandoEnviadoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcComandoEnviado);
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
         RowToVars24( bcComandoEnviado, 1) ;
         UpdateImpl( ) ;
         VarsToRow24( bcComandoEnviado) ;
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
         RowToVars24( bcComandoEnviado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N24( ) ;
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
         VarsToRow24( bcComandoEnviado) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars24( bcComandoEnviado, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0N24( ) ;
         if ( RcdFound24 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A144ComandoEnviadoId != Z144ComandoEnviadoId )
            {
               A144ComandoEnviadoId = Z144ComandoEnviadoId;
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
            if ( A144ComandoEnviadoId != Z144ComandoEnviadoId )
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
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(10);
         context.RollbackDataStores("comandoenviado_bc",pr_default);
         VarsToRow24( bcComandoEnviado) ;
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
         Gx_mode = bcComandoEnviado.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcComandoEnviado.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcComandoEnviado )
         {
            bcComandoEnviado = (SdtComandoEnviado)(sdt);
            if ( StringUtil.StrCmp(bcComandoEnviado.gxTpr_Mode, "") == 0 )
            {
               bcComandoEnviado.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow24( bcComandoEnviado) ;
            }
            else
            {
               RowToVars24( bcComandoEnviado, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcComandoEnviado.gxTpr_Mode, "") == 0 )
            {
               bcComandoEnviado.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars24( bcComandoEnviado, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtComandoEnviado ComandoEnviado_BC
      {
         get {
            return bcComandoEnviado ;
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
            return "comandoenviado_Execute" ;
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
         pr_default.close(3);
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
         sMode24 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV24Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z145ComandoEnviadoResponsavelGUID = "";
         A145ComandoEnviadoResponsavelGUID = "";
         Z146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         A146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         BC000N7_A144ComandoEnviadoId = new int[1] ;
         BC000N7_A145ComandoEnviadoResponsavelGUID = new string[] {""} ;
         BC000N7_A146ComandoEnviadoDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N7_A110RastreadorSNumber = new long[1] ;
         BC000N7_A147ComandoEnviadoSerial = new int[1] ;
         BC000N7_A106RastreadorId = new int[1] ;
         BC000N6_A110RastreadorSNumber = new long[1] ;
         BC000N8_A144ComandoEnviadoId = new int[1] ;
         BC000N5_A144ComandoEnviadoId = new int[1] ;
         BC000N5_A145ComandoEnviadoResponsavelGUID = new string[] {""} ;
         BC000N5_A146ComandoEnviadoDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N5_A147ComandoEnviadoSerial = new int[1] ;
         BC000N5_A106RastreadorId = new int[1] ;
         BC000N4_A144ComandoEnviadoId = new int[1] ;
         BC000N4_A145ComandoEnviadoResponsavelGUID = new string[] {""} ;
         BC000N4_A146ComandoEnviadoDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N4_A147ComandoEnviadoSerial = new int[1] ;
         BC000N4_A106RastreadorId = new int[1] ;
         BC000N9_A144ComandoEnviadoId = new int[1] ;
         BC000N12_A110RastreadorSNumber = new long[1] ;
         BC000N13_A144ComandoEnviadoId = new int[1] ;
         BC000N13_A145ComandoEnviadoResponsavelGUID = new string[] {""} ;
         BC000N13_A146ComandoEnviadoDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N13_A110RastreadorSNumber = new long[1] ;
         BC000N13_A147ComandoEnviadoSerial = new int[1] ;
         BC000N13_A106RastreadorId = new int[1] ;
         Z149ComandoEnviadoComandoComando = "";
         A149ComandoEnviadoComandoComando = "";
         Z150ComandoEnviadoComandoValor = "";
         A150ComandoEnviadoComandoValor = "";
         BC000N14_A144ComandoEnviadoId = new int[1] ;
         BC000N14_A148ComandoEnviadoComandoId = new int[1] ;
         BC000N14_A149ComandoEnviadoComandoComando = new string[] {""} ;
         BC000N14_A150ComandoEnviadoComandoValor = new string[] {""} ;
         BC000N15_A144ComandoEnviadoId = new int[1] ;
         BC000N15_A148ComandoEnviadoComandoId = new int[1] ;
         BC000N3_A144ComandoEnviadoId = new int[1] ;
         BC000N3_A148ComandoEnviadoComandoId = new int[1] ;
         BC000N3_A149ComandoEnviadoComandoComando = new string[] {""} ;
         BC000N3_A150ComandoEnviadoComandoValor = new string[] {""} ;
         sMode25 = "";
         BC000N2_A144ComandoEnviadoId = new int[1] ;
         BC000N2_A148ComandoEnviadoComandoId = new int[1] ;
         BC000N2_A149ComandoEnviadoComandoComando = new string[] {""} ;
         BC000N2_A150ComandoEnviadoComandoValor = new string[] {""} ;
         BC000N19_A144ComandoEnviadoId = new int[1] ;
         BC000N19_A148ComandoEnviadoComandoId = new int[1] ;
         BC000N19_A149ComandoEnviadoComandoComando = new string[] {""} ;
         BC000N19_A150ComandoEnviadoComandoValor = new string[] {""} ;
         i146ComandoEnviadoDataHora = (DateTime)(DateTime.MinValue);
         i145ComandoEnviadoResponsavelGUID = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.comandoenviado_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comandoenviado_bc__default(),
            new Object[][] {
                new Object[] {
               BC000N2_A144ComandoEnviadoId, BC000N2_A148ComandoEnviadoComandoId, BC000N2_A149ComandoEnviadoComandoComando, BC000N2_A150ComandoEnviadoComandoValor
               }
               , new Object[] {
               BC000N3_A144ComandoEnviadoId, BC000N3_A148ComandoEnviadoComandoId, BC000N3_A149ComandoEnviadoComandoComando, BC000N3_A150ComandoEnviadoComandoValor
               }
               , new Object[] {
               BC000N4_A144ComandoEnviadoId, BC000N4_A145ComandoEnviadoResponsavelGUID, BC000N4_A146ComandoEnviadoDataHora, BC000N4_A147ComandoEnviadoSerial, BC000N4_A106RastreadorId
               }
               , new Object[] {
               BC000N5_A144ComandoEnviadoId, BC000N5_A145ComandoEnviadoResponsavelGUID, BC000N5_A146ComandoEnviadoDataHora, BC000N5_A147ComandoEnviadoSerial, BC000N5_A106RastreadorId
               }
               , new Object[] {
               BC000N6_A110RastreadorSNumber
               }
               , new Object[] {
               BC000N7_A144ComandoEnviadoId, BC000N7_A145ComandoEnviadoResponsavelGUID, BC000N7_A146ComandoEnviadoDataHora, BC000N7_A110RastreadorSNumber, BC000N7_A147ComandoEnviadoSerial, BC000N7_A106RastreadorId
               }
               , new Object[] {
               BC000N8_A144ComandoEnviadoId
               }
               , new Object[] {
               BC000N9_A144ComandoEnviadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N12_A110RastreadorSNumber
               }
               , new Object[] {
               BC000N13_A144ComandoEnviadoId, BC000N13_A145ComandoEnviadoResponsavelGUID, BC000N13_A146ComandoEnviadoDataHora, BC000N13_A110RastreadorSNumber, BC000N13_A147ComandoEnviadoSerial, BC000N13_A106RastreadorId
               }
               , new Object[] {
               BC000N14_A144ComandoEnviadoId, BC000N14_A148ComandoEnviadoComandoId, BC000N14_A149ComandoEnviadoComandoComando, BC000N14_A150ComandoEnviadoComandoValor
               }
               , new Object[] {
               BC000N15_A144ComandoEnviadoId, BC000N15_A148ComandoEnviadoComandoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N19_A144ComandoEnviadoId, BC000N19_A148ComandoEnviadoComandoId, BC000N19_A149ComandoEnviadoComandoComando, BC000N19_A150ComandoEnviadoComandoValor
               }
            }
         );
         AV24Pgmname = "ComandoEnviado_BC";
         Z145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         A145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         i145ComandoEnviadoResponsavelGUID = new buscargamguidusuariologado(context).executeUdp( );
         Z146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         A146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         i146ComandoEnviadoDataHora = DateTimeUtil.ServerNow( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120N2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_25 ;
      private short RcdFound25 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound24 ;
      private short nIsDirty_24 ;
      private short nRcdExists_25 ;
      private short Gxremove25 ;
      private short nIsDirty_25 ;
      private int trnEnded ;
      private int Z144ComandoEnviadoId ;
      private int A144ComandoEnviadoId ;
      private int nGXsfl_25_idx=1 ;
      private int AV25GXV1 ;
      private int AV13Insert_RastreadorId ;
      private int Z147ComandoEnviadoSerial ;
      private int A147ComandoEnviadoSerial ;
      private int Z106RastreadorId ;
      private int A106RastreadorId ;
      private int Z148ComandoEnviadoComandoId ;
      private int A148ComandoEnviadoComandoId ;
      private long Z110RastreadorSNumber ;
      private long A110RastreadorSNumber ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode24 ;
      private string AV24Pgmname ;
      private string Z145ComandoEnviadoResponsavelGUID ;
      private string A145ComandoEnviadoResponsavelGUID ;
      private string GXt_char1 ;
      private string sMode25 ;
      private string i145ComandoEnviadoResponsavelGUID ;
      private DateTime Z146ComandoEnviadoDataHora ;
      private DateTime A146ComandoEnviadoDataHora ;
      private DateTime i146ComandoEnviadoDataHora ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z149ComandoEnviadoComandoComando ;
      private string A149ComandoEnviadoComandoComando ;
      private string Z150ComandoEnviadoComandoValor ;
      private string A150ComandoEnviadoComandoValor ;
      private IGxSession AV12WebSession ;
      private SdtComandoEnviado bcComandoEnviado ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000N7_A144ComandoEnviadoId ;
      private string[] BC000N7_A145ComandoEnviadoResponsavelGUID ;
      private DateTime[] BC000N7_A146ComandoEnviadoDataHora ;
      private long[] BC000N7_A110RastreadorSNumber ;
      private int[] BC000N7_A147ComandoEnviadoSerial ;
      private int[] BC000N7_A106RastreadorId ;
      private long[] BC000N6_A110RastreadorSNumber ;
      private int[] BC000N8_A144ComandoEnviadoId ;
      private int[] BC000N5_A144ComandoEnviadoId ;
      private string[] BC000N5_A145ComandoEnviadoResponsavelGUID ;
      private DateTime[] BC000N5_A146ComandoEnviadoDataHora ;
      private int[] BC000N5_A147ComandoEnviadoSerial ;
      private int[] BC000N5_A106RastreadorId ;
      private int[] BC000N4_A144ComandoEnviadoId ;
      private string[] BC000N4_A145ComandoEnviadoResponsavelGUID ;
      private DateTime[] BC000N4_A146ComandoEnviadoDataHora ;
      private int[] BC000N4_A147ComandoEnviadoSerial ;
      private int[] BC000N4_A106RastreadorId ;
      private int[] BC000N9_A144ComandoEnviadoId ;
      private long[] BC000N12_A110RastreadorSNumber ;
      private int[] BC000N13_A144ComandoEnviadoId ;
      private string[] BC000N13_A145ComandoEnviadoResponsavelGUID ;
      private DateTime[] BC000N13_A146ComandoEnviadoDataHora ;
      private long[] BC000N13_A110RastreadorSNumber ;
      private int[] BC000N13_A147ComandoEnviadoSerial ;
      private int[] BC000N13_A106RastreadorId ;
      private int[] BC000N14_A144ComandoEnviadoId ;
      private int[] BC000N14_A148ComandoEnviadoComandoId ;
      private string[] BC000N14_A149ComandoEnviadoComandoComando ;
      private string[] BC000N14_A150ComandoEnviadoComandoValor ;
      private int[] BC000N15_A144ComandoEnviadoId ;
      private int[] BC000N15_A148ComandoEnviadoComandoId ;
      private int[] BC000N3_A144ComandoEnviadoId ;
      private int[] BC000N3_A148ComandoEnviadoComandoId ;
      private string[] BC000N3_A149ComandoEnviadoComandoComando ;
      private string[] BC000N3_A150ComandoEnviadoComandoValor ;
      private int[] BC000N2_A144ComandoEnviadoId ;
      private int[] BC000N2_A148ComandoEnviadoComandoId ;
      private string[] BC000N2_A149ComandoEnviadoComandoComando ;
      private string[] BC000N2_A150ComandoEnviadoComandoValor ;
      private int[] BC000N19_A144ComandoEnviadoId ;
      private int[] BC000N19_A148ComandoEnviadoComandoId ;
      private string[] BC000N19_A149ComandoEnviadoComandoComando ;
      private string[] BC000N19_A150ComandoEnviadoComandoValor ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class comandoenviado_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class comandoenviado_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000N7;
        prmBC000N7 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N6;
        prmBC000N6 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N8;
        prmBC000N8 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N5;
        prmBC000N5 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N4;
        prmBC000N4 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N9;
        prmBC000N9 = new Object[] {
        new Object[] {"@ComandoEnviadoResponsavelGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@ComandoEnviadoDataHora",SqlDbType.DateTime,8,5} ,
        new Object[] {"@ComandoEnviadoSerial",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N10;
        prmBC000N10 = new Object[] {
        new Object[] {"@ComandoEnviadoResponsavelGUID",SqlDbType.NChar,40,0} ,
        new Object[] {"@ComandoEnviadoDataHora",SqlDbType.DateTime,8,5} ,
        new Object[] {"@ComandoEnviadoSerial",SqlDbType.Int,8,0} ,
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N11;
        prmBC000N11 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N12;
        prmBC000N12 = new Object[] {
        new Object[] {"@RastreadorId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N13;
        prmBC000N13 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N14;
        prmBC000N14 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N15;
        prmBC000N15 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N3;
        prmBC000N3 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N2;
        prmBC000N2 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N16;
        prmBC000N16 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoComando",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoEnviadoComandoValor",SqlDbType.NVarChar,256,0}
        };
        Object[] prmBC000N17;
        prmBC000N17 = new Object[] {
        new Object[] {"@ComandoEnviadoComandoComando",SqlDbType.NVarChar,60,0} ,
        new Object[] {"@ComandoEnviadoComandoValor",SqlDbType.NVarChar,256,0} ,
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N18;
        prmBC000N18 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0} ,
        new Object[] {"@ComandoEnviadoComandoId",SqlDbType.Int,8,0}
        };
        Object[] prmBC000N19;
        prmBC000N19 = new Object[] {
        new Object[] {"@ComandoEnviadoId",SqlDbType.Int,8,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC000N2", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor] FROM [ComandoEnviadoComando] WITH (UPDLOCK) WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N3", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N4", "SELECT [ComandoEnviadoId], [ComandoEnviadoResponsavelGUID], [ComandoEnviadoDataHora], [ComandoEnviadoSerial], [RastreadorId] FROM [ComandoEnviado] WITH (UPDLOCK) WHERE [ComandoEnviadoId] = @ComandoEnviadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N5", "SELECT [ComandoEnviadoId], [ComandoEnviadoResponsavelGUID], [ComandoEnviadoDataHora], [ComandoEnviadoSerial], [RastreadorId] FROM [ComandoEnviado] WHERE [ComandoEnviadoId] = @ComandoEnviadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N6", "SELECT [RastreadorSNumber] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N7", "SELECT TM1.[ComandoEnviadoId], TM1.[ComandoEnviadoResponsavelGUID], TM1.[ComandoEnviadoDataHora], T2.[RastreadorSNumber], TM1.[ComandoEnviadoSerial], TM1.[RastreadorId] FROM ([ComandoEnviado] TM1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = TM1.[RastreadorId]) WHERE TM1.[ComandoEnviadoId] = @ComandoEnviadoId ORDER BY TM1.[ComandoEnviadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N8", "SELECT [ComandoEnviadoId] FROM [ComandoEnviado] WHERE [ComandoEnviadoId] = @ComandoEnviadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N9", "INSERT INTO [ComandoEnviado]([ComandoEnviadoResponsavelGUID], [ComandoEnviadoDataHora], [ComandoEnviadoSerial], [RastreadorId]) VALUES(@ComandoEnviadoResponsavelGUID, @ComandoEnviadoDataHora, @ComandoEnviadoSerial, @RastreadorId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000N9)
           ,new CursorDef("BC000N10", "UPDATE [ComandoEnviado] SET [ComandoEnviadoResponsavelGUID]=@ComandoEnviadoResponsavelGUID, [ComandoEnviadoDataHora]=@ComandoEnviadoDataHora, [ComandoEnviadoSerial]=@ComandoEnviadoSerial, [RastreadorId]=@RastreadorId  WHERE [ComandoEnviadoId] = @ComandoEnviadoId", GxErrorMask.GX_NOMASK,prmBC000N10)
           ,new CursorDef("BC000N11", "DELETE FROM [ComandoEnviado]  WHERE [ComandoEnviadoId] = @ComandoEnviadoId", GxErrorMask.GX_NOMASK,prmBC000N11)
           ,new CursorDef("BC000N12", "SELECT [RastreadorSNumber] FROM [Rastreador] WHERE [RastreadorId] = @RastreadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N13", "SELECT TM1.[ComandoEnviadoId], TM1.[ComandoEnviadoResponsavelGUID], TM1.[ComandoEnviadoDataHora], T2.[RastreadorSNumber], TM1.[ComandoEnviadoSerial], TM1.[RastreadorId] FROM ([ComandoEnviado] TM1 INNER JOIN [Rastreador] T2 ON T2.[RastreadorId] = TM1.[RastreadorId]) WHERE TM1.[ComandoEnviadoId] = @ComandoEnviadoId ORDER BY TM1.[ComandoEnviadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N14", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId and [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId ORDER BY [ComandoEnviadoId], [ComandoEnviadoComandoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N14,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N15", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N16", "INSERT INTO [ComandoEnviadoComando]([ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor]) VALUES(@ComandoEnviadoId, @ComandoEnviadoComandoId, @ComandoEnviadoComandoComando, @ComandoEnviadoComandoValor)", GxErrorMask.GX_NOMASK,prmBC000N16)
           ,new CursorDef("BC000N17", "UPDATE [ComandoEnviadoComando] SET [ComandoEnviadoComandoComando]=@ComandoEnviadoComandoComando, [ComandoEnviadoComandoValor]=@ComandoEnviadoComandoValor  WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId", GxErrorMask.GX_NOMASK,prmBC000N17)
           ,new CursorDef("BC000N18", "DELETE FROM [ComandoEnviadoComando]  WHERE [ComandoEnviadoId] = @ComandoEnviadoId AND [ComandoEnviadoComandoId] = @ComandoEnviadoComandoId", GxErrorMask.GX_NOMASK,prmBC000N18)
           ,new CursorDef("BC000N19", "SELECT [ComandoEnviadoId], [ComandoEnviadoComandoId], [ComandoEnviadoComandoComando], [ComandoEnviadoComandoValor] FROM [ComandoEnviadoComando] WHERE [ComandoEnviadoId] = @ComandoEnviadoId ORDER BY [ComandoEnviadoId], [ComandoEnviadoComandoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N19,11, GxCacheFrequency.OFF ,true,false )
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
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              return;
           case 1 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              return;
           case 2 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getInt(4);
              table[4][0] = rslt.getInt(5);
              return;
           case 3 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getInt(4);
              table[4][0] = rslt.getInt(5);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              return;
           case 5 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getLong(4);
              table[4][0] = rslt.getInt(5);
              table[5][0] = rslt.getInt(6);
              return;
           case 6 :
              table[0][0] = rslt.getInt(1);
              return;
           case 7 :
              table[0][0] = rslt.getInt(1);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              return;
           case 11 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getString(2, 40);
              table[2][0] = rslt.getGXDateTime(3);
              table[3][0] = rslt.getLong(4);
              table[4][0] = rslt.getInt(5);
              table[5][0] = rslt.getInt(6);
              return;
           case 12 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              return;
           case 13 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              return;
           case 17 :
              table[0][0] = rslt.getInt(1);
              table[1][0] = rslt.getInt(2);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
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
              return;
           case 5 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              return;
           case 8 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameterDatetime(2, (DateTime)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              stmt.SetParameter(5, (int)parms[4]);
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
           case 12 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 13 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 14 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              return;
           case 15 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              return;
           case 16 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              return;
           case 17 :
              stmt.SetParameter(1, (int)parms[0]);
              return;
     }
  }

}

}
