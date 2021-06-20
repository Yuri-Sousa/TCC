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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_notification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_notification_bc( IGxContext context )
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
         ReadRow088( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey088( ) ;
         standaloneModal( ) ;
         AddRow088( ) ;
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
               Z16WWPNotificationId = A16WWPNotificationId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               if ( AnyError == 0 )
               {
                  ZM088( 7) ;
                  ZM088( 8) ;
               }
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
            Z68WWPNotificationIcon = A68WWPNotificationIcon;
            Z69WWPNotificationTitle = A69WWPNotificationTitle;
            Z70WWPNotificationShortDescription = A70WWPNotificationShortDescription;
            Z71WWPNotificationLink = A71WWPNotificationLink;
            Z73WWPNotificationIsRead = A73WWPNotificationIsRead;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z2WWPUserExtendedFullName = A2WWPUserExtendedFullName;
         }
         if ( GX_JID == -6 )
         {
            Z16WWPNotificationId = A16WWPNotificationId;
            Z37WWPNotificationCreated = A37WWPNotificationCreated;
            Z68WWPNotificationIcon = A68WWPNotificationIcon;
            Z69WWPNotificationTitle = A69WWPNotificationTitle;
            Z70WWPNotificationShortDescription = A70WWPNotificationShortDescription;
            Z71WWPNotificationLink = A71WWPNotificationLink;
            Z73WWPNotificationIsRead = A73WWPNotificationIsRead;
            Z54WWPNotificationMetadata = A54WWPNotificationMetadata;
            Z14WWPNotificationDefinitionId = A14WWPNotificationDefinitionId;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
            Z53WWPNotificationDefinitionName = A53WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A37WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load088( )
      {
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound8 = 1;
            A53WWPNotificationDefinitionName = BC00086_A53WWPNotificationDefinitionName[0];
            A37WWPNotificationCreated = BC00086_A37WWPNotificationCreated[0];
            A68WWPNotificationIcon = BC00086_A68WWPNotificationIcon[0];
            A69WWPNotificationTitle = BC00086_A69WWPNotificationTitle[0];
            A70WWPNotificationShortDescription = BC00086_A70WWPNotificationShortDescription[0];
            A71WWPNotificationLink = BC00086_A71WWPNotificationLink[0];
            A73WWPNotificationIsRead = BC00086_A73WWPNotificationIsRead[0];
            A54WWPNotificationMetadata = BC00086_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC00086_n54WWPNotificationMetadata[0];
            A14WWPNotificationDefinitionId = BC00086_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC00086_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00086_n1WWPUserExtendedId[0];
            ZM088( -6) ;
         }
         pr_default.close(4);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A14WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWPNotification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A53WWPNotificationDefinitionName = BC00084_A53WWPNotificationDefinitionName[0];
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A37WWPNotificationCreated) || ( A37WWPNotificationCreated >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Notification Created Date fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A71WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de Notification Link não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'User Extended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         nIsDirty_8 = 1;
         GXt_char1 = A2WWPUserExtendedFullName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
         A2WWPUserExtendedFullName = GXt_char1;
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor BC00087 */
         pr_default.execute(5, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 6) ;
            RcdFound8 = 1;
            A16WWPNotificationId = BC00083_A16WWPNotificationId[0];
            n16WWPNotificationId = BC00083_n16WWPNotificationId[0];
            A37WWPNotificationCreated = BC00083_A37WWPNotificationCreated[0];
            A68WWPNotificationIcon = BC00083_A68WWPNotificationIcon[0];
            A69WWPNotificationTitle = BC00083_A69WWPNotificationTitle[0];
            A70WWPNotificationShortDescription = BC00083_A70WWPNotificationShortDescription[0];
            A71WWPNotificationLink = BC00083_A71WWPNotificationLink[0];
            A73WWPNotificationIsRead = BC00083_A73WWPNotificationIsRead[0];
            A54WWPNotificationMetadata = BC00083_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC00083_n54WWPNotificationMetadata[0];
            A14WWPNotificationDefinitionId = BC00083_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC00083_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC00083_n1WWPUserExtendedId[0];
            Z16WWPNotificationId = A16WWPNotificationId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_080( ) ;
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

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z37WWPNotificationCreated != BC00082_A37WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z68WWPNotificationIcon, BC00082_A68WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z69WWPNotificationTitle, BC00082_A69WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z70WWPNotificationShortDescription, BC00082_A70WWPNotificationShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z71WWPNotificationLink, BC00082_A71WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z73WWPNotificationIsRead != BC00082_A73WWPNotificationIsRead[0] ) || ( Z14WWPNotificationDefinitionId != BC00082_A14WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC00082_A1WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00088 */
                     pr_default.execute(6, new Object[] {A37WWPNotificationCreated, A68WWPNotificationIcon, A69WWPNotificationTitle, A70WWPNotificationShortDescription, A71WWPNotificationLink, A73WWPNotificationIsRead, n54WWPNotificationMetadata, A54WWPNotificationMetadata, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     A16WWPNotificationId = BC00088_A16WWPNotificationId[0];
                     n16WWPNotificationId = BC00088_n16WWPNotificationId[0];
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00089 */
                     pr_default.execute(7, new Object[] {A37WWPNotificationCreated, A68WWPNotificationIcon, A69WWPNotificationTitle, A70WWPNotificationShortDescription, A71WWPNotificationLink, A73WWPNotificationIsRead, n54WWPNotificationMetadata, A54WWPNotificationMetadata, A14WWPNotificationDefinitionId, n1WWPUserExtendedId, A1WWPUserExtendedId, n16WWPNotificationId, A16WWPNotificationId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000810 */
                  pr_default.execute(8, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("WWP_Notification");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel088( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000811 */
            pr_default.execute(9, new Object[] {A14WWPNotificationDefinitionId});
            A53WWPNotificationDefinitionName = BC000811_A53WWPNotificationDefinitionName[0];
            pr_default.close(9);
            GXt_char1 = A2WWPUserExtendedFullName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  A1WWPUserExtendedId, out  GXt_char1) ;
            A2WWPUserExtendedFullName = GXt_char1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000812 */
            pr_default.execute(10, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000813 */
            pr_default.execute(11, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000814 */
            pr_default.execute(12, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SMS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
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

      public void ScanKeyStart088( )
      {
         /* Using cursor BC000815 */
         pr_default.execute(13, new Object[] {n16WWPNotificationId, A16WWPNotificationId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A16WWPNotificationId = BC000815_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000815_n16WWPNotificationId[0];
            A53WWPNotificationDefinitionName = BC000815_A53WWPNotificationDefinitionName[0];
            A37WWPNotificationCreated = BC000815_A37WWPNotificationCreated[0];
            A68WWPNotificationIcon = BC000815_A68WWPNotificationIcon[0];
            A69WWPNotificationTitle = BC000815_A69WWPNotificationTitle[0];
            A70WWPNotificationShortDescription = BC000815_A70WWPNotificationShortDescription[0];
            A71WWPNotificationLink = BC000815_A71WWPNotificationLink[0];
            A73WWPNotificationIsRead = BC000815_A73WWPNotificationIsRead[0];
            A54WWPNotificationMetadata = BC000815_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC000815_n54WWPNotificationMetadata[0];
            A14WWPNotificationDefinitionId = BC000815_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000815_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000815_n1WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound8 = 0;
         ScanKeyLoad088( ) ;
      }

      protected void ScanKeyLoad088( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A16WWPNotificationId = BC000815_A16WWPNotificationId[0];
            n16WWPNotificationId = BC000815_n16WWPNotificationId[0];
            A53WWPNotificationDefinitionName = BC000815_A53WWPNotificationDefinitionName[0];
            A37WWPNotificationCreated = BC000815_A37WWPNotificationCreated[0];
            A68WWPNotificationIcon = BC000815_A68WWPNotificationIcon[0];
            A69WWPNotificationTitle = BC000815_A69WWPNotificationTitle[0];
            A70WWPNotificationShortDescription = BC000815_A70WWPNotificationShortDescription[0];
            A71WWPNotificationLink = BC000815_A71WWPNotificationLink[0];
            A73WWPNotificationIsRead = BC000815_A73WWPNotificationIsRead[0];
            A54WWPNotificationMetadata = BC000815_A54WWPNotificationMetadata[0];
            n54WWPNotificationMetadata = BC000815_n54WWPNotificationMetadata[0];
            A14WWPNotificationDefinitionId = BC000815_A14WWPNotificationDefinitionId[0];
            A1WWPUserExtendedId = BC000815_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000815_n1WWPUserExtendedId[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd088( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) )
         {
            A1WWPUserExtendedId = "";
            n1WWPUserExtendedId = false;
            n1WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void AddRow088( )
      {
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
      }

      protected void ReadRow088( )
      {
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
      }

      protected void InitializeNonKey088( )
      {
         A2WWPUserExtendedFullName = "";
         A14WWPNotificationDefinitionId = 0;
         A53WWPNotificationDefinitionName = "";
         A68WWPNotificationIcon = "";
         A69WWPNotificationTitle = "";
         A70WWPNotificationShortDescription = "";
         A71WWPNotificationLink = "";
         A73WWPNotificationIsRead = false;
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         A54WWPNotificationMetadata = "";
         n54WWPNotificationMetadata = false;
         A37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z68WWPNotificationIcon = "";
         Z69WWPNotificationTitle = "";
         Z70WWPNotificationShortDescription = "";
         Z71WWPNotificationLink = "";
         Z73WWPNotificationIsRead = false;
         Z14WWPNotificationDefinitionId = 0;
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll088( )
      {
         A16WWPNotificationId = 0;
         n16WWPNotificationId = false;
         InitializeNonKey088( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A37WWPNotificationCreated = i37WWPNotificationCreated;
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

      public void VarsToRow8( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Wwpuserextendedfullname = A2WWPUserExtendedFullName;
         obj8.gxTpr_Wwpnotificationdefinitionid = A14WWPNotificationDefinitionId;
         obj8.gxTpr_Wwpnotificationdefinitionname = A53WWPNotificationDefinitionName;
         obj8.gxTpr_Wwpnotificationicon = A68WWPNotificationIcon;
         obj8.gxTpr_Wwpnotificationtitle = A69WWPNotificationTitle;
         obj8.gxTpr_Wwpnotificationshortdescription = A70WWPNotificationShortDescription;
         obj8.gxTpr_Wwpnotificationlink = A71WWPNotificationLink;
         obj8.gxTpr_Wwpnotificationisread = A73WWPNotificationIsRead;
         obj8.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj8.gxTpr_Wwpnotificationmetadata = A54WWPNotificationMetadata;
         obj8.gxTpr_Wwpnotificationcreated = A37WWPNotificationCreated;
         obj8.gxTpr_Wwpnotificationid = A16WWPNotificationId;
         obj8.gxTpr_Wwpnotificationid_Z = Z16WWPNotificationId;
         obj8.gxTpr_Wwpnotificationdefinitionid_Z = Z14WWPNotificationDefinitionId;
         obj8.gxTpr_Wwpnotificationdefinitionname_Z = Z53WWPNotificationDefinitionName;
         obj8.gxTpr_Wwpnotificationcreated_Z = Z37WWPNotificationCreated;
         obj8.gxTpr_Wwpnotificationicon_Z = Z68WWPNotificationIcon;
         obj8.gxTpr_Wwpnotificationtitle_Z = Z69WWPNotificationTitle;
         obj8.gxTpr_Wwpnotificationshortdescription_Z = Z70WWPNotificationShortDescription;
         obj8.gxTpr_Wwpnotificationlink_Z = Z71WWPNotificationLink;
         obj8.gxTpr_Wwpnotificationisread_Z = Z73WWPNotificationIsRead;
         obj8.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj8.gxTpr_Wwpuserextendedfullname_Z = Z2WWPUserExtendedFullName;
         obj8.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n16WWPNotificationId));
         obj8.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n1WWPUserExtendedId));
         obj8.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n54WWPNotificationMetadata));
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj8 )
      {
         obj8.gxTpr_Wwpnotificationid = A16WWPNotificationId;
         return  ;
      }

      public void RowToVars8( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A2WWPUserExtendedFullName = obj8.gxTpr_Wwpuserextendedfullname;
         A14WWPNotificationDefinitionId = obj8.gxTpr_Wwpnotificationdefinitionid;
         A53WWPNotificationDefinitionName = obj8.gxTpr_Wwpnotificationdefinitionname;
         A68WWPNotificationIcon = obj8.gxTpr_Wwpnotificationicon;
         A69WWPNotificationTitle = obj8.gxTpr_Wwpnotificationtitle;
         A70WWPNotificationShortDescription = obj8.gxTpr_Wwpnotificationshortdescription;
         A71WWPNotificationLink = obj8.gxTpr_Wwpnotificationlink;
         A73WWPNotificationIsRead = obj8.gxTpr_Wwpnotificationisread;
         A1WWPUserExtendedId = obj8.gxTpr_Wwpuserextendedid;
         n1WWPUserExtendedId = false;
         A54WWPNotificationMetadata = obj8.gxTpr_Wwpnotificationmetadata;
         n54WWPNotificationMetadata = false;
         A37WWPNotificationCreated = obj8.gxTpr_Wwpnotificationcreated;
         A16WWPNotificationId = obj8.gxTpr_Wwpnotificationid;
         n16WWPNotificationId = false;
         Z16WWPNotificationId = obj8.gxTpr_Wwpnotificationid_Z;
         Z14WWPNotificationDefinitionId = obj8.gxTpr_Wwpnotificationdefinitionid_Z;
         Z53WWPNotificationDefinitionName = obj8.gxTpr_Wwpnotificationdefinitionname_Z;
         Z37WWPNotificationCreated = obj8.gxTpr_Wwpnotificationcreated_Z;
         Z68WWPNotificationIcon = obj8.gxTpr_Wwpnotificationicon_Z;
         Z69WWPNotificationTitle = obj8.gxTpr_Wwpnotificationtitle_Z;
         Z70WWPNotificationShortDescription = obj8.gxTpr_Wwpnotificationshortdescription_Z;
         Z71WWPNotificationLink = obj8.gxTpr_Wwpnotificationlink_Z;
         Z73WWPNotificationIsRead = obj8.gxTpr_Wwpnotificationisread_Z;
         Z1WWPUserExtendedId = obj8.gxTpr_Wwpuserextendedid_Z;
         Z2WWPUserExtendedFullName = obj8.gxTpr_Wwpuserextendedfullname_Z;
         n16WWPNotificationId = (bool)(Convert.ToBoolean(obj8.gxTpr_Wwpnotificationid_N));
         n1WWPUserExtendedId = (bool)(Convert.ToBoolean(obj8.gxTpr_Wwpuserextendedid_N));
         n54WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj8.gxTpr_Wwpnotificationmetadata_N));
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A16WWPNotificationId = (long)getParm(obj,0);
         n16WWPNotificationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey088( ) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z16WWPNotificationId = A16WWPNotificationId;
         }
         ZM088( -6) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z16WWPNotificationId = A16WWPNotificationId;
         }
         ZM088( -6) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert088( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A16WWPNotificationId != Z16WWPNotificationId )
               {
                  A16WWPNotificationId = Z16WWPNotificationId;
                  n16WWPNotificationId = false;
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
                  Update088( ) ;
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
                  if ( A16WWPNotificationId != Z16WWPNotificationId )
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
                        Insert088( ) ;
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
                        Insert088( ) ;
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A16WWPNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_Notification);
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         UpdateImpl( ) ;
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
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
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey088( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A16WWPNotificationId != Z16WWPNotificationId )
            {
               A16WWPNotificationId = Z16WWPNotificationId;
               n16WWPNotificationId = false;
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
            if ( A16WWPNotificationId != Z16WWPNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification_bc",pr_default);
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_Notification )
         {
            bcwwpbaseobjects_notifications_common_WWP_Notification = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
            else
            {
               RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Notification WWP_Notification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_Notification ;
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
            return "wwp_notification_Execute" ;
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
         Z37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z68WWPNotificationIcon = "";
         A68WWPNotificationIcon = "";
         Z69WWPNotificationTitle = "";
         A69WWPNotificationTitle = "";
         Z70WWPNotificationShortDescription = "";
         A70WWPNotificationShortDescription = "";
         Z71WWPNotificationLink = "";
         A71WWPNotificationLink = "";
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z2WWPUserExtendedFullName = "";
         A2WWPUserExtendedFullName = "";
         Z53WWPNotificationDefinitionName = "";
         A53WWPNotificationDefinitionName = "";
         Z54WWPNotificationMetadata = "";
         A54WWPNotificationMetadata = "";
         BC00086_A16WWPNotificationId = new long[1] ;
         BC00086_n16WWPNotificationId = new bool[] {false} ;
         BC00086_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC00086_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00086_A68WWPNotificationIcon = new string[] {""} ;
         BC00086_A69WWPNotificationTitle = new string[] {""} ;
         BC00086_A70WWPNotificationShortDescription = new string[] {""} ;
         BC00086_A71WWPNotificationLink = new string[] {""} ;
         BC00086_A73WWPNotificationIsRead = new bool[] {false} ;
         BC00086_A54WWPNotificationMetadata = new string[] {""} ;
         BC00086_n54WWPNotificationMetadata = new bool[] {false} ;
         BC00086_A14WWPNotificationDefinitionId = new long[1] ;
         BC00086_A1WWPUserExtendedId = new string[] {""} ;
         BC00086_n1WWPUserExtendedId = new bool[] {false} ;
         BC00084_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC00085_A1WWPUserExtendedId = new string[] {""} ;
         BC00085_n1WWPUserExtendedId = new bool[] {false} ;
         BC00087_A16WWPNotificationId = new long[1] ;
         BC00087_n16WWPNotificationId = new bool[] {false} ;
         BC00083_A16WWPNotificationId = new long[1] ;
         BC00083_n16WWPNotificationId = new bool[] {false} ;
         BC00083_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00083_A68WWPNotificationIcon = new string[] {""} ;
         BC00083_A69WWPNotificationTitle = new string[] {""} ;
         BC00083_A70WWPNotificationShortDescription = new string[] {""} ;
         BC00083_A71WWPNotificationLink = new string[] {""} ;
         BC00083_A73WWPNotificationIsRead = new bool[] {false} ;
         BC00083_A54WWPNotificationMetadata = new string[] {""} ;
         BC00083_n54WWPNotificationMetadata = new bool[] {false} ;
         BC00083_A14WWPNotificationDefinitionId = new long[1] ;
         BC00083_A1WWPUserExtendedId = new string[] {""} ;
         BC00083_n1WWPUserExtendedId = new bool[] {false} ;
         sMode8 = "";
         BC00082_A16WWPNotificationId = new long[1] ;
         BC00082_n16WWPNotificationId = new bool[] {false} ;
         BC00082_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00082_A68WWPNotificationIcon = new string[] {""} ;
         BC00082_A69WWPNotificationTitle = new string[] {""} ;
         BC00082_A70WWPNotificationShortDescription = new string[] {""} ;
         BC00082_A71WWPNotificationLink = new string[] {""} ;
         BC00082_A73WWPNotificationIsRead = new bool[] {false} ;
         BC00082_A54WWPNotificationMetadata = new string[] {""} ;
         BC00082_n54WWPNotificationMetadata = new bool[] {false} ;
         BC00082_A14WWPNotificationDefinitionId = new long[1] ;
         BC00082_A1WWPUserExtendedId = new string[] {""} ;
         BC00082_n1WWPUserExtendedId = new bool[] {false} ;
         BC00088_A16WWPNotificationId = new long[1] ;
         BC00088_n16WWPNotificationId = new bool[] {false} ;
         BC000811_A53WWPNotificationDefinitionName = new string[] {""} ;
         GXt_char1 = "";
         BC000812_A20WWPMailId = new long[1] ;
         BC000813_A17WWPWebNotificationId = new long[1] ;
         BC000814_A15WWPSMSId = new long[1] ;
         BC000815_A16WWPNotificationId = new long[1] ;
         BC000815_n16WWPNotificationId = new bool[] {false} ;
         BC000815_A53WWPNotificationDefinitionName = new string[] {""} ;
         BC000815_A37WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000815_A68WWPNotificationIcon = new string[] {""} ;
         BC000815_A69WWPNotificationTitle = new string[] {""} ;
         BC000815_A70WWPNotificationShortDescription = new string[] {""} ;
         BC000815_A71WWPNotificationLink = new string[] {""} ;
         BC000815_A73WWPNotificationIsRead = new bool[] {false} ;
         BC000815_A54WWPNotificationMetadata = new string[] {""} ;
         BC000815_n54WWPNotificationMetadata = new bool[] {false} ;
         BC000815_A14WWPNotificationDefinitionId = new long[1] ;
         BC000815_A1WWPUserExtendedId = new string[] {""} ;
         BC000815_n1WWPUserExtendedId = new bool[] {false} ;
         i37WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A16WWPNotificationId, BC00082_A37WWPNotificationCreated, BC00082_A68WWPNotificationIcon, BC00082_A69WWPNotificationTitle, BC00082_A70WWPNotificationShortDescription, BC00082_A71WWPNotificationLink, BC00082_A73WWPNotificationIsRead, BC00082_A54WWPNotificationMetadata, BC00082_n54WWPNotificationMetadata, BC00082_A14WWPNotificationDefinitionId,
               BC00082_A1WWPUserExtendedId, BC00082_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00083_A16WWPNotificationId, BC00083_A37WWPNotificationCreated, BC00083_A68WWPNotificationIcon, BC00083_A69WWPNotificationTitle, BC00083_A70WWPNotificationShortDescription, BC00083_A71WWPNotificationLink, BC00083_A73WWPNotificationIsRead, BC00083_A54WWPNotificationMetadata, BC00083_n54WWPNotificationMetadata, BC00083_A14WWPNotificationDefinitionId,
               BC00083_A1WWPUserExtendedId, BC00083_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00084_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               BC00085_A1WWPUserExtendedId
               }
               , new Object[] {
               BC00086_A16WWPNotificationId, BC00086_A53WWPNotificationDefinitionName, BC00086_A37WWPNotificationCreated, BC00086_A68WWPNotificationIcon, BC00086_A69WWPNotificationTitle, BC00086_A70WWPNotificationShortDescription, BC00086_A71WWPNotificationLink, BC00086_A73WWPNotificationIsRead, BC00086_A54WWPNotificationMetadata, BC00086_n54WWPNotificationMetadata,
               BC00086_A14WWPNotificationDefinitionId, BC00086_A1WWPUserExtendedId, BC00086_n1WWPUserExtendedId
               }
               , new Object[] {
               BC00087_A16WWPNotificationId
               }
               , new Object[] {
               BC00088_A16WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000811_A53WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000812_A20WWPMailId
               }
               , new Object[] {
               BC000813_A17WWPWebNotificationId
               }
               , new Object[] {
               BC000814_A15WWPSMSId
               }
               , new Object[] {
               BC000815_A16WWPNotificationId, BC000815_A53WWPNotificationDefinitionName, BC000815_A37WWPNotificationCreated, BC000815_A68WWPNotificationIcon, BC000815_A69WWPNotificationTitle, BC000815_A70WWPNotificationShortDescription, BC000815_A71WWPNotificationLink, BC000815_A73WWPNotificationIsRead, BC000815_A54WWPNotificationMetadata, BC000815_n54WWPNotificationMetadata,
               BC000815_A14WWPNotificationDefinitionId, BC000815_A1WWPUserExtendedId, BC000815_n1WWPUserExtendedId
               }
            }
         );
         Z37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i37WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private int trnEnded ;
      private long Z16WWPNotificationId ;
      private long A16WWPNotificationId ;
      private long Z14WWPNotificationDefinitionId ;
      private long A14WWPNotificationDefinitionId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string sMode8 ;
      private string GXt_char1 ;
      private DateTime Z37WWPNotificationCreated ;
      private DateTime A37WWPNotificationCreated ;
      private DateTime i37WWPNotificationCreated ;
      private bool Z73WWPNotificationIsRead ;
      private bool A73WWPNotificationIsRead ;
      private bool n16WWPNotificationId ;
      private bool n54WWPNotificationMetadata ;
      private bool n1WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z54WWPNotificationMetadata ;
      private string A54WWPNotificationMetadata ;
      private string Z68WWPNotificationIcon ;
      private string A68WWPNotificationIcon ;
      private string Z69WWPNotificationTitle ;
      private string A69WWPNotificationTitle ;
      private string Z70WWPNotificationShortDescription ;
      private string A70WWPNotificationShortDescription ;
      private string Z71WWPNotificationLink ;
      private string A71WWPNotificationLink ;
      private string Z2WWPUserExtendedFullName ;
      private string A2WWPUserExtendedFullName ;
      private string Z53WWPNotificationDefinitionName ;
      private string A53WWPNotificationDefinitionName ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification bcwwpbaseobjects_notifications_common_WWP_Notification ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00086_A16WWPNotificationId ;
      private bool[] BC00086_n16WWPNotificationId ;
      private string[] BC00086_A53WWPNotificationDefinitionName ;
      private DateTime[] BC00086_A37WWPNotificationCreated ;
      private string[] BC00086_A68WWPNotificationIcon ;
      private string[] BC00086_A69WWPNotificationTitle ;
      private string[] BC00086_A70WWPNotificationShortDescription ;
      private string[] BC00086_A71WWPNotificationLink ;
      private bool[] BC00086_A73WWPNotificationIsRead ;
      private string[] BC00086_A54WWPNotificationMetadata ;
      private bool[] BC00086_n54WWPNotificationMetadata ;
      private long[] BC00086_A14WWPNotificationDefinitionId ;
      private string[] BC00086_A1WWPUserExtendedId ;
      private bool[] BC00086_n1WWPUserExtendedId ;
      private string[] BC00084_A53WWPNotificationDefinitionName ;
      private string[] BC00085_A1WWPUserExtendedId ;
      private bool[] BC00085_n1WWPUserExtendedId ;
      private long[] BC00087_A16WWPNotificationId ;
      private bool[] BC00087_n16WWPNotificationId ;
      private long[] BC00083_A16WWPNotificationId ;
      private bool[] BC00083_n16WWPNotificationId ;
      private DateTime[] BC00083_A37WWPNotificationCreated ;
      private string[] BC00083_A68WWPNotificationIcon ;
      private string[] BC00083_A69WWPNotificationTitle ;
      private string[] BC00083_A70WWPNotificationShortDescription ;
      private string[] BC00083_A71WWPNotificationLink ;
      private bool[] BC00083_A73WWPNotificationIsRead ;
      private string[] BC00083_A54WWPNotificationMetadata ;
      private bool[] BC00083_n54WWPNotificationMetadata ;
      private long[] BC00083_A14WWPNotificationDefinitionId ;
      private string[] BC00083_A1WWPUserExtendedId ;
      private bool[] BC00083_n1WWPUserExtendedId ;
      private long[] BC00082_A16WWPNotificationId ;
      private bool[] BC00082_n16WWPNotificationId ;
      private DateTime[] BC00082_A37WWPNotificationCreated ;
      private string[] BC00082_A68WWPNotificationIcon ;
      private string[] BC00082_A69WWPNotificationTitle ;
      private string[] BC00082_A70WWPNotificationShortDescription ;
      private string[] BC00082_A71WWPNotificationLink ;
      private bool[] BC00082_A73WWPNotificationIsRead ;
      private string[] BC00082_A54WWPNotificationMetadata ;
      private bool[] BC00082_n54WWPNotificationMetadata ;
      private long[] BC00082_A14WWPNotificationDefinitionId ;
      private string[] BC00082_A1WWPUserExtendedId ;
      private bool[] BC00082_n1WWPUserExtendedId ;
      private long[] BC00088_A16WWPNotificationId ;
      private bool[] BC00088_n16WWPNotificationId ;
      private string[] BC000811_A53WWPNotificationDefinitionName ;
      private long[] BC000812_A20WWPMailId ;
      private long[] BC000813_A17WWPWebNotificationId ;
      private long[] BC000814_A15WWPSMSId ;
      private long[] BC000815_A16WWPNotificationId ;
      private bool[] BC000815_n16WWPNotificationId ;
      private string[] BC000815_A53WWPNotificationDefinitionName ;
      private DateTime[] BC000815_A37WWPNotificationCreated ;
      private string[] BC000815_A68WWPNotificationIcon ;
      private string[] BC000815_A69WWPNotificationTitle ;
      private string[] BC000815_A70WWPNotificationShortDescription ;
      private string[] BC000815_A71WWPNotificationLink ;
      private bool[] BC000815_A73WWPNotificationIsRead ;
      private string[] BC000815_A54WWPNotificationMetadata ;
      private bool[] BC000815_n54WWPNotificationMetadata ;
      private long[] BC000815_A14WWPNotificationDefinitionId ;
      private string[] BC000815_A1WWPUserExtendedId ;
      private bool[] BC000815_n1WWPUserExtendedId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00086;
        prmBC00086 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00084;
        prmBC00084 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00085;
        prmBC00085 = new Object[] {
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00087;
        prmBC00087 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00083;
        prmBC00083 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00082;
        prmBC00082 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC00088;
        prmBC00088 = new Object[] {
        new Object[] {"@WWPNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPNotificationIcon",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationIsRead",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationMetadata",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0}
        };
        Object[] prmBC00089;
        prmBC00089 = new Object[] {
        new Object[] {"@WWPNotificationCreated",SqlDbType.DateTime2,10,12} ,
        new Object[] {"@WWPNotificationIcon",SqlDbType.NVarChar,100,0} ,
        new Object[] {"@WWPNotificationTitle",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationShortDescription",SqlDbType.NVarChar,200,0} ,
        new Object[] {"@WWPNotificationLink",SqlDbType.NVarChar,1000,0} ,
        new Object[] {"@WWPNotificationIsRead",SqlDbType.Bit,4,0} ,
        new Object[] {"@WWPNotificationMetadata",SqlDbType.NVarChar,2097152,0} ,
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0} ,
        new Object[] {"@WWPUserExtendedId",SqlDbType.NChar,40,0} ,
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000810;
        prmBC000810 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000811;
        prmBC000811 = new Object[] {
        new Object[] {"@WWPNotificationDefinitionId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000812;
        prmBC000812 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000813;
        prmBC000813 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000814;
        prmBC000814 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        Object[] prmBC000815;
        prmBC000815 = new Object[] {
        new Object[] {"@WWPNotificationId",SqlDbType.Decimal,10,0}
        };
        def= new CursorDef[] {
            new CursorDef("BC00082", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescription], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WITH (UPDLOCK) WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00083", "SELECT [WWPNotificationId], [WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescription], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00084", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00085", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00086", "SELECT TM1.[WWPNotificationId], T2.[WWPNotificationDefinitionName], TM1.[WWPNotificationCreated], TM1.[WWPNotificationIcon], TM1.[WWPNotificationTitle], TM1.[WWPNotificationShortDescription], TM1.[WWPNotificationLink], TM1.[WWPNotificationIsRead], TM1.[WWPNotificationMetadata], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM ([WWP_Notification] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) WHERE TM1.[WWPNotificationId] = @WWPNotificationId ORDER BY TM1.[WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00087", "SELECT [WWPNotificationId] FROM [WWP_Notification] WHERE [WWPNotificationId] = @WWPNotificationId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00088", "INSERT INTO [WWP_Notification]([WWPNotificationCreated], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescription], [WWPNotificationLink], [WWPNotificationIsRead], [WWPNotificationMetadata], [WWPNotificationDefinitionId], [WWPUserExtendedId]) VALUES(@WWPNotificationCreated, @WWPNotificationIcon, @WWPNotificationTitle, @WWPNotificationShortDescription, @WWPNotificationLink, @WWPNotificationIsRead, @WWPNotificationMetadata, @WWPNotificationDefinitionId, @WWPUserExtendedId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC00088)
           ,new CursorDef("BC00089", "UPDATE [WWP_Notification] SET [WWPNotificationCreated]=@WWPNotificationCreated, [WWPNotificationIcon]=@WWPNotificationIcon, [WWPNotificationTitle]=@WWPNotificationTitle, [WWPNotificationShortDescription]=@WWPNotificationShortDescription, [WWPNotificationLink]=@WWPNotificationLink, [WWPNotificationIsRead]=@WWPNotificationIsRead, [WWPNotificationMetadata]=@WWPNotificationMetadata, [WWPNotificationDefinitionId]=@WWPNotificationDefinitionId, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmBC00089)
           ,new CursorDef("BC000810", "DELETE FROM [WWP_Notification]  WHERE [WWPNotificationId] = @WWPNotificationId", GxErrorMask.GX_NOMASK,prmBC000810)
           ,new CursorDef("BC000811", "SELECT [WWPNotificationDefinitionName] FROM [WWP_NotificationDefinition] WHERE [WWPNotificationDefinitionId] = @WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000811,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000812", "SELECT TOP 1 [WWPMailId] FROM [WWP_Mail] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000812,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000813", "SELECT TOP 1 [WWPWebNotificationId] FROM [WWP_WebNotification] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000813,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000814", "SELECT TOP 1 [WWPSMSId] FROM [WWP_SMS] WHERE [WWPNotificationId] = @WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000814,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000815", "SELECT TM1.[WWPNotificationId], T2.[WWPNotificationDefinitionName], TM1.[WWPNotificationCreated], TM1.[WWPNotificationIcon], TM1.[WWPNotificationTitle], TM1.[WWPNotificationShortDescription], TM1.[WWPNotificationLink], TM1.[WWPNotificationIsRead], TM1.[WWPNotificationMetadata], TM1.[WWPNotificationDefinitionId], TM1.[WWPUserExtendedId] FROM ([WWP_Notification] TM1 INNER JOIN [WWP_NotificationDefinition] T2 ON T2.[WWPNotificationDefinitionId] = TM1.[WWPNotificationDefinitionId]) WHERE TM1.[WWPNotificationId] = @WWPNotificationId ORDER BY TM1.[WWPNotificationId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000815,100, GxCacheFrequency.OFF ,true,false )
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
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getBool(7);
              table[7][0] = rslt.getLongVarchar(8);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLong(9);
              table[10][0] = rslt.getString(10, 40);
              table[11][0] = rslt.wasNull(10);
              return;
           case 1 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getGXDateTime(2, true);
              table[2][0] = rslt.getVarchar(3);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getBool(7);
              table[7][0] = rslt.getLongVarchar(8);
              table[8][0] = rslt.wasNull(8);
              table[9][0] = rslt.getLong(9);
              table[10][0] = rslt.getString(10, 40);
              table[11][0] = rslt.wasNull(10);
              return;
           case 2 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 3 :
              table[0][0] = rslt.getString(1, 40);
              return;
           case 4 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getGXDateTime(3, true);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getBool(8);
              table[8][0] = rslt.getLongVarchar(9);
              table[9][0] = rslt.wasNull(9);
              table[10][0] = rslt.getLong(10);
              table[11][0] = rslt.getString(11, 40);
              table[12][0] = rslt.wasNull(11);
              return;
           case 5 :
              table[0][0] = rslt.getLong(1);
              return;
           case 6 :
              table[0][0] = rslt.getLong(1);
              return;
           case 9 :
              table[0][0] = rslt.getVarchar(1);
              return;
           case 10 :
              table[0][0] = rslt.getLong(1);
              return;
           case 11 :
              table[0][0] = rslt.getLong(1);
              return;
           case 12 :
              table[0][0] = rslt.getLong(1);
              return;
           case 13 :
              table[0][0] = rslt.getLong(1);
              table[1][0] = rslt.getVarchar(2);
              table[2][0] = rslt.getGXDateTime(3, true);
              table[3][0] = rslt.getVarchar(4);
              table[4][0] = rslt.getVarchar(5);
              table[5][0] = rslt.getVarchar(6);
              table[6][0] = rslt.getVarchar(7);
              table[7][0] = rslt.getBool(8);
              table[8][0] = rslt.getLongVarchar(9);
              table[9][0] = rslt.wasNull(9);
              table[10][0] = rslt.getLong(10);
              table[11][0] = rslt.getString(11, 40);
              table[12][0] = rslt.wasNull(11);
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
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 1 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 2 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 3 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(1, (string)parms[1]);
              }
              return;
           case 4 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 5 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 6 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0], true);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (bool)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(7, (string)parms[7]);
              }
              stmt.SetParameter(8, (long)parms[8]);
              if ( (bool)parms[9] )
              {
                 stmt.setNull( 9 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(9, (string)parms[10]);
              }
              return;
           case 7 :
              stmt.SetParameterDatetime(1, (DateTime)parms[0], true);
              stmt.SetParameter(2, (string)parms[1]);
              stmt.SetParameter(3, (string)parms[2]);
              stmt.SetParameter(4, (string)parms[3]);
              stmt.SetParameter(5, (string)parms[4]);
              stmt.SetParameter(6, (bool)parms[5]);
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 7 , SqlDbType.NVarChar );
              }
              else
              {
                 stmt.SetParameter(7, (string)parms[7]);
              }
              stmt.SetParameter(8, (long)parms[8]);
              if ( (bool)parms[9] )
              {
                 stmt.setNull( 9 , SqlDbType.NChar );
              }
              else
              {
                 stmt.SetParameter(9, (string)parms[10]);
              }
              if ( (bool)parms[11] )
              {
                 stmt.setNull( 10 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(10, (long)parms[12]);
              }
              return;
           case 8 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 9 :
              stmt.SetParameter(1, (long)parms[0]);
              return;
           case 10 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 11 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 12 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
           case 13 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(1, (long)parms[1]);
              }
              return;
     }
  }

}

}
