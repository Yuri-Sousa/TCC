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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webclient_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_webclient_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_webclient_bc( IGxContext context )
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
         ReadRow066( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey066( ) ;
         standaloneModal( ) ;
         AddRow066( ) ;
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
               Z18WWPWebClientId = A18WWPWebClientId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               if ( AnyError == 0 )
               {
                  ZM066( 7) ;
               }
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z43WWPWebClientBrowserId = A43WWPWebClientBrowserId;
            Z45WWPWebClientFirstRegistered = A45WWPWebClientFirstRegistered;
            Z46WWPWebClientLastRegistered = A46WWPWebClientLastRegistered;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -6 )
         {
            Z18WWPWebClientId = A18WWPWebClientId;
            Z43WWPWebClientBrowserId = A43WWPWebClientBrowserId;
            Z44WWPWebClientBrowserVersion = A44WWPWebClientBrowserVersion;
            Z45WWPWebClientFirstRegistered = A45WWPWebClientFirstRegistered;
            Z46WWPWebClientLastRegistered = A46WWPWebClientLastRegistered;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A45WWPWebClientFirstRegistered) && ( Gx_BScreen == 0 ) )
         {
            A45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A46WWPWebClientLastRegistered) && ( Gx_BScreen == 0 ) )
         {
            A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load066( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
            A43WWPWebClientBrowserId = BC00065_A43WWPWebClientBrowserId[0];
            A44WWPWebClientBrowserVersion = BC00065_A44WWPWebClientBrowserVersion[0];
            A45WWPWebClientFirstRegistered = BC00065_A45WWPWebClientFirstRegistered[0];
            A46WWPWebClientLastRegistered = BC00065_A46WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC00065_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00065_n1WWPUserExtendedId[0];
            ZM066( -6) ;
         }
         pr_default.close(3);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A43WWPWebClientBrowserId == 0 ) || ( A43WWPWebClientBrowserId == 1 ) || ( A43WWPWebClientBrowserId == 2 ) || ( A43WWPWebClientBrowserId == 3 ) || ( A43WWPWebClientBrowserId == 5 ) || ( A43WWPWebClientBrowserId == 6 ) || ( A43WWPWebClientBrowserId == 7 ) || ( A43WWPWebClientBrowserId == 8 ) || ( A43WWPWebClientBrowserId == 9 ) ) )
         {
            GX_msglist.addItem("Campo Web Client Browser Id fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A45WWPWebClientFirstRegistered) || ( A45WWPWebClientFirstRegistered >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Client First Registered fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A46WWPWebClientLastRegistered) || ( A46WWPWebClientLastRegistered >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Web Client Last Registered fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A18WWPWebClientId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 6) ;
            RcdFound6 = 1;
            A18WWPWebClientId = BC00063_A18WWPWebClientId[0];
            A43WWPWebClientBrowserId = BC00063_A43WWPWebClientBrowserId[0];
            A44WWPWebClientBrowserVersion = BC00063_A44WWPWebClientBrowserVersion[0];
            A45WWPWebClientFirstRegistered = BC00063_A45WWPWebClientFirstRegistered[0];
            A46WWPWebClientLastRegistered = BC00063_A46WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC00063_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00063_n1WWPUserExtendedId[0];
            Z18WWPWebClientId = A18WWPWebClientId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A18WWPWebClientId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z43WWPWebClientBrowserId != BC00062_A43WWPWebClientBrowserId[0] ) || ( Z45WWPWebClientFirstRegistered != BC00062_A45WWPWebClientFirstRegistered[0] ) || ( Z46WWPWebClientLastRegistered != BC00062_A46WWPWebClientLastRegistered[0] ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC00062_A1WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebClient"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00067 */
                     pr_default.execute(5, new Object[] {A18WWPWebClientId, A43WWPWebClientBrowserId, A44WWPWebClientBrowserVersion, A45WWPWebClientFirstRegistered, A46WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00068 */
                     pr_default.execute(6, new Object[] {A43WWPWebClientBrowserId, A44WWPWebClientBrowserVersion, A45WWPWebClientFirstRegistered, A46WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId, A18WWPWebClientId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00069 */
                  pr_default.execute(7, new Object[] {A18WWPWebClientId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_WebClient");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel066( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
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

      public void ScanKeyStart066( )
      {
         /* Using cursor BC000610 */
         pr_default.execute(8, new Object[] {A18WWPWebClientId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound6 = 1;
            A18WWPWebClientId = BC000610_A18WWPWebClientId[0];
            A43WWPWebClientBrowserId = BC000610_A43WWPWebClientBrowserId[0];
            A44WWPWebClientBrowserVersion = BC000610_A44WWPWebClientBrowserVersion[0];
            A45WWPWebClientFirstRegistered = BC000610_A45WWPWebClientFirstRegistered[0];
            A46WWPWebClientLastRegistered = BC000610_A46WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC000610_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000610_n1WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound6 = 0;
         ScanKeyLoad066( ) ;
      }

      protected void ScanKeyLoad066( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound6 = 1;
            A18WWPWebClientId = BC000610_A18WWPWebClientId[0];
            A43WWPWebClientBrowserId = BC000610_A43WWPWebClientBrowserId[0];
            A44WWPWebClientBrowserVersion = BC000610_A44WWPWebClientBrowserVersion[0];
            A45WWPWebClientFirstRegistered = BC000610_A45WWPWebClientFirstRegistered[0];
            A46WWPWebClientLastRegistered = BC000610_A46WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC000610_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000610_n1WWPUserExtendedId[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd066( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void AddRow066( )
      {
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
      }

      protected void ReadRow066( )
      {
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
      }

      protected void InitializeNonKey066( )
      {
         A43WWPWebClientBrowserId = 0;
         A44WWPWebClientBrowserVersion = "";
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         A45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z43WWPWebClientBrowserId = 0;
         Z45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll066( )
      {
         A18WWPWebClientId = "";
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A45WWPWebClientFirstRegistered = i45WWPWebClientFirstRegistered;
         A46WWPWebClientLastRegistered = i46WWPWebClientLastRegistered;
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

      public void VarsToRow6( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Wwpwebclientbrowserid = A43WWPWebClientBrowserId;
         obj6.gxTpr_Wwpwebclientbrowserversion = A44WWPWebClientBrowserVersion;
         obj6.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj6.gxTpr_Wwpwebclientfirstregistered = A45WWPWebClientFirstRegistered;
         obj6.gxTpr_Wwpwebclientlastregistered = A46WWPWebClientLastRegistered;
         obj6.gxTpr_Wwpwebclientid = A18WWPWebClientId;
         obj6.gxTpr_Wwpwebclientid_Z = Z18WWPWebClientId;
         obj6.gxTpr_Wwpwebclientbrowserid_Z = Z43WWPWebClientBrowserId;
         obj6.gxTpr_Wwpwebclientfirstregistered_Z = Z45WWPWebClientFirstRegistered;
         obj6.gxTpr_Wwpwebclientlastregistered_Z = Z46WWPWebClientLastRegistered;
         obj6.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj6.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n1WWPUserExtendedId));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj6 )
      {
         obj6.gxTpr_Wwpwebclientid = A18WWPWebClientId;
         return  ;
      }

      public void RowToVars6( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A43WWPWebClientBrowserId = obj6.gxTpr_Wwpwebclientbrowserid;
         A44WWPWebClientBrowserVersion = obj6.gxTpr_Wwpwebclientbrowserversion;
         A1WWPUserExtendedId = obj6.gxTpr_Wwpuserextendedid;
         n1WWPUserExtendedId = false;
         A45WWPWebClientFirstRegistered = obj6.gxTpr_Wwpwebclientfirstregistered;
         A46WWPWebClientLastRegistered = obj6.gxTpr_Wwpwebclientlastregistered;
         A18WWPWebClientId = obj6.gxTpr_Wwpwebclientid;
         Z18WWPWebClientId = obj6.gxTpr_Wwpwebclientid_Z;
         Z43WWPWebClientBrowserId = obj6.gxTpr_Wwpwebclientbrowserid_Z;
         Z45WWPWebClientFirstRegistered = obj6.gxTpr_Wwpwebclientfirstregistered_Z;
         Z46WWPWebClientLastRegistered = obj6.gxTpr_Wwpwebclientlastregistered_Z;
         Z1WWPUserExtendedId = obj6.gxTpr_Wwpuserextendedid_Z;
         n1WWPUserExtendedId = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpuserextendedid_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A18WWPWebClientId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey066( ) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z18WWPWebClientId = A18WWPWebClientId;
         }
         ZM066( -6) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z18WWPWebClientId = A18WWPWebClientId;
         }
         ZM066( -6) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert066( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( StringUtil.StrCmp(A18WWPWebClientId, Z18WWPWebClientId) != 0 )
               {
                  A18WWPWebClientId = Z18WWPWebClientId;
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
                  Update066( ) ;
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
                  if ( StringUtil.StrCmp(A18WWPWebClientId, Z18WWPWebClientId) != 0 )
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
                        Insert066( ) ;
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
                        Insert066( ) ;
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A18WWPWebClientId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebClient);
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         UpdateImpl( ) ;
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
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
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey066( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A18WWPWebClientId, Z18WWPWebClientId) != 0 )
            {
               A18WWPWebClientId = Z18WWPWebClientId;
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
            if ( StringUtil.StrCmp(A18WWPWebClientId, Z18WWPWebClientId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webclient_bc",pr_default);
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebClient )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebClient = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
            else
            {
               RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_WebClient WWP_WebClient_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebClient ;
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
            return "webclient_Execute" ;
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
         Z18WWPWebClientId = "";
         A18WWPWebClientId = "";
         Z45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         A45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z44WWPWebClientBrowserVersion = "";
         A44WWPWebClientBrowserVersion = "";
         BC00065_A18WWPWebClientId = new string[] {""} ;
         BC00065_A43WWPWebClientBrowserId = new short[1] ;
         BC00065_A44WWPWebClientBrowserVersion = new string[] {""} ;
         BC00065_A45WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00065_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00065_A1WWPUserExtendedId = new string[] {""} ;
         BC00065_n1WWPUserExtendedId = new bool[] {false} ;
         BC00064_A1WWPUserExtendedId = new string[] {""} ;
         BC00064_n1WWPUserExtendedId = new bool[] {false} ;
         BC00066_A18WWPWebClientId = new string[] {""} ;
         BC00063_A18WWPWebClientId = new string[] {""} ;
         BC00063_A43WWPWebClientBrowserId = new short[1] ;
         BC00063_A44WWPWebClientBrowserVersion = new string[] {""} ;
         BC00063_A45WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00063_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00063_A1WWPUserExtendedId = new string[] {""} ;
         BC00063_n1WWPUserExtendedId = new bool[] {false} ;
         sMode6 = "";
         BC00062_A18WWPWebClientId = new string[] {""} ;
         BC00062_A43WWPWebClientBrowserId = new short[1] ;
         BC00062_A44WWPWebClientBrowserVersion = new string[] {""} ;
         BC00062_A45WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00062_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00062_A1WWPUserExtendedId = new string[] {""} ;
         BC00062_n1WWPUserExtendedId = new bool[] {false} ;
         BC000610_A18WWPWebClientId = new string[] {""} ;
         BC000610_A43WWPWebClientBrowserId = new short[1] ;
         BC000610_A44WWPWebClientBrowserVersion = new string[] {""} ;
         BC000610_A45WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000610_A46WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000610_A1WWPUserExtendedId = new string[] {""} ;
         BC000610_n1WWPUserExtendedId = new bool[] {false} ;
         i45WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         i46WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A18WWPWebClientId, BC00062_A43WWPWebClientBrowserId, BC00062_A44WWPWebClientBrowserVersion, BC00062_A45WWPWebClientFirstRegistered, BC00062_A46WWPWebClientLastRegistered, BC00062_A1WWPUserExtendedId, BC00062_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00063_A18WWPWebClientId, BC00063_A43WWPWebClientBrowserId, BC00063_A44WWPWebClientBrowserVersion, BC00063_A45WWPWebClientFirstRegistered, BC00063_A46WWPWebClientLastRegistered, BC00063_A1WWPUserExtendedId, BC00063_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00064_A1WWPUserExtendedId
               }
               , new Object[] {
               BC00065_A18WWPWebClientId, BC00065_A43WWPWebClientBrowserId, BC00065_A44WWPWebClientBrowserVersion, BC00065_A45WWPWebClientFirstRegistered, BC00065_A46WWPWebClientLastRegistered, BC00065_A1WWPUserExtendedId, BC00065_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00066_A18WWPWebClientId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000610_A18WWPWebClientId, BC000610_A43WWPWebClientBrowserId, BC000610_A44WWPWebClientBrowserVersion, BC000610_A45WWPWebClientFirstRegistered, BC000610_A46WWPWebClientLastRegistered, BC000610_A1WWPUserExtendedId, BC000610_n1WWPUserExtendedId
               }
            }
         );
         Z46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i46WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i45WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z43WWPWebClientBrowserId ;
      private short A43WWPWebClientBrowserId ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z18WWPWebClientId ;
      private string A18WWPWebClientId ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string sMode6 ;
      private DateTime Z45WWPWebClientFirstRegistered ;
      private DateTime A45WWPWebClientFirstRegistered ;
      private DateTime Z46WWPWebClientLastRegistered ;
      private DateTime A46WWPWebClientLastRegistered ;
      private DateTime i45WWPWebClientFirstRegistered ;
      private DateTime i46WWPWebClientLastRegistered ;
      private bool n1WWPUserExtendedId ;
      private bool mustCommit ;
      private string Z44WWPWebClientBrowserVersion ;
      private string A44WWPWebClientBrowserVersion ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient bcwwpbaseobjects_notifications_web_WWP_WebClient ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00065_A18WWPWebClientId ;
      private short[] BC00065_A43WWPWebClientBrowserId ;
      private string[] BC00065_A44WWPWebClientBrowserVersion ;
      private DateTime[] BC00065_A45WWPWebClientFirstRegistered ;
      private DateTime[] BC00065_A46WWPWebClientLastRegistered ;
      private string[] BC00065_A1WWPUserExtendedId ;
      private bool[] BC00065_n1WWPUserExtendedId ;
      private string[] BC00064_A1WWPUserExtendedId ;
      private bool[] BC00064_n1WWPUserExtendedId ;
      private string[] BC00066_A18WWPWebClientId ;
      private string[] BC00063_A18WWPWebClientId ;
      private short[] BC00063_A43WWPWebClientBrowserId ;
      private string[] BC00063_A44WWPWebClientBrowserVersion ;
      private DateTime[] BC00063_A45WWPWebClientFirstRegistered ;
      private DateTime[] BC00063_A46WWPWebClientLastRegistered ;
      private string[] BC00063_A1WWPUserExtendedId ;
      private bool[] BC00063_n1WWPUserExtendedId ;
      private string[] BC00062_A18WWPWebClientId ;
      private short[] BC00062_A43WWPWebClientBrowserId ;
      private string[] BC00062_A44WWPWebClientBrowserVersion ;
      private DateTime[] BC00062_A45WWPWebClientFirstRegistered ;
      private DateTime[] BC00062_A46WWPWebClientLastRegistered ;
      private string[] BC00062_A1WWPUserExtendedId ;
      private bool[] BC00062_n1WWPUserExtendedId ;
      private string[] BC000610_A18WWPWebClientId ;
      private short[] BC000610_A43WWPWebClientBrowserId ;
      private string[] BC000610_A44WWPWebClientBrowserVersion ;
      private DateTime[] BC000610_A45WWPWebClientFirstRegistered ;
      private DateTime[] BC000610_A46WWPWebClientLastRegistered ;
      private string[] BC000610_A1WWPUserExtendedId ;
      private bool[] BC000610_n1WWPUserExtendedId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webclient_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webclient_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00065;
        prmBC00065 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmBC00064;
        prmBC00064 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00066;
        prmBC00066 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmBC00063;
        prmBC00063 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmBC00062;
        prmBC00062 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmBC00067;
        prmBC00067 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0} ,
        new Object[] {"@WWPWebClientBrowserId",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebClientBrowserVersion",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebClientFirstRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebClientLastRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00068;
        prmBC00068 = new Object[] {
        new Object[] {"@WWPWebClientBrowserId",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@WWPWebClientBrowserVersion",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPWebClientFirstRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPWebClientLastRegistered",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmBC00069;
        prmBC00069 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        Object[] prmBC000610;
        prmBC000610 = new Object[] {
        new Object[] {"@WWPWebClientId",SqlDbType.NChar,100,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00062", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WITH (UPDLOCK) WHERE [WWPWebClientId] = @WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00063", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WHERE [WWPWebClientId] = @WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00064", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00065", "SELECT TM1.[WWPWebClientId], TM1.[WWPWebClientBrowserId], TM1.[WWPWebClientBrowserVersion], TM1.[WWPWebClientFirstRegistered], TM1.[WWPWebClientLastRegistered], TM1.[WWPUserExtendedId] FROM [WWP_WebClient] TM1 WHERE TM1.[WWPWebClientId] = @WWPWebClientId ORDER BY TM1.[WWPWebClientId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00066", "SELECT [WWPWebClientId] FROM [WWP_WebClient] WHERE [WWPWebClientId] = @WWPWebClientId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00067", "INSERT INTO [WWP_WebClient]([WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId]) VALUES(@WWPWebClientId, @WWPWebClientBrowserId, @WWPWebClientBrowserVersion, @WWPWebClientFirstRegistered, @WWPWebClientLastRegistered, @WWPUserExtendedId)", GxErrorMask.GX_NOMASK,prmBC00067)
           ,new CursorDef("BC00068", "UPDATE [WWP_WebClient] SET [WWPWebClientBrowserId]=@WWPWebClientBrowserId, [WWPWebClientBrowserVersion]=@WWPWebClientBrowserVersion, [WWPWebClientFirstRegistered]=@WWPWebClientFirstRegistered, [WWPWebClientLastRegistered]=@WWPWebClientLastRegistered, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK,prmBC00068)
           ,new CursorDef("BC00069", "DELETE FROM [WWP_WebClient]  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK,prmBC00069)
           ,new CursorDef("BC000610", "SELECT TM1.[WWPWebClientId], TM1.[WWPWebClientBrowserId], TM1.[WWPWebClientBrowserVersion], TM1.[WWPWebClientFirstRegistered], TM1.[WWPWebClientLastRegistered], TM1.[WWPUserExtendedId] FROM [WWP_WebClient] TM1 WHERE TM1.[WWPWebClientId] = @WWPWebClientId ORDER BY TM1.[WWPWebClientId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,100, GxCacheFrequency.OFF ,true,false )
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
              table[0][0] = rslt.getString(1, 100);
              table[1][0] = rslt.getShort(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getGXDateTime(5, true);
              table[5][0] = rslt.getString(6, 40);
              table[6][0] = rslt.wasNull(6);
              return;
           case 1 :
              table[0][0] = rslt.getString(1, 100);
              table[1][0] = rslt.getShort(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getGXDateTime(5, true);
              table[5][0] = rslt.getString(6, 40);
              table[6][0] = rslt.wasNull(6);
              return;
           case 2 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 100);
              table[1][0] = rslt.getShort(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getGXDateTime(5, true);
              table[5][0] = rslt.getString(6, 40);
              table[6][0] = rslt.wasNull(6);
              return;
           case 4 :
              table[0][0] = rslt.getString(1, 100);
              return;
           case 8 :
              table[0][0] = rslt.getString(1, 100);
              table[1][0] = rslt.getShort(2);
              table[2][0] = rslt.getLongVarchar(3);
              table[3][0] = rslt.getGXDateTime(4, true);
              table[4][0] = rslt.getGXDateTime(5, true);
              table[5][0] = rslt.getString(6, 40);
              table[6][0] = rslt.wasNull(6);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (string)parms[0]);
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
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (string)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameterDatetime(4, (DateTime)parms[3], true);
              stmt.SetParameterDatetime(5, (DateTime)parms[4], true);
              if ( (bool)parms[5] )
              {
                 stmt.setNull( 6 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(6, (string)parms[6]);
              }
              return;
           case 6 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameterDatetime(3, (DateTime)parms[2], true);
              stmt.SetParameterDatetime(4, (DateTime)parms[3], true);
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 5 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(5, (string)parms[5]);
              }
              stmt.SetParameter(6, (string)parms[6]);
              return;
           case 7 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
           case 8 :
              stmt.SetParameter(1, (string)parms[0]);
              return;
     }
  }

}

}
